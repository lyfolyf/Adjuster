using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Adjuster.JL
{
    public class JLFast : ILightController
    {
        private const string TimeOut = "&";
        public string PortName { get; set; } = "COM1";
        public int BaudRate { get; set; } = 115200;
        public int DataBits { get; set; } = 8;
        StringBuilder _strRec = new StringBuilder();
        private bool _busy = false;
        private bool _mesBack = false;
        Stopwatch sw = new Stopwatch();
        private readonly object _synLock = new object();
        readonly int[] _ints = new int[8];
        readonly bool[] _ens = new bool[8];

        readonly SerialPort _serialPort = new SerialPort();
        private double elapsed;

        /// <summary>
        /// 指令耗时
        /// </summary>
        public double Elapsed
        {
            get
            {
                return elapsed;
            }
        }

        //    命令格式   $ 3 1 0 6 4 1 4
        //              |-|-|-|-----|----------$:  起始符号（1个字符）：  必须为“$”
        //                |-|-|-----|----------3:  命令字（1个字符）:   1、打开对应通道（上电默认打开状态）
        //                  | |     |                                 2、关闭对应通道
        //                  | |     |                                 3、设置对应通道亮度值
        //                  | |     |                                 4、读取对应通道亮度值
        //                  |-|-----|----------1:   通道（1个字符）：  0、代表所有通道（读取时，不能使用“0”）
        //                    |     |                                1~8、分别代表该通道
        //                    |-----|----------064：数据（3个字符）：  命令字为“1”、“2”、“4”、“5”时，数据可以是000-0FF的任意值，建议用“000”。
        //                          |                                命令字为“3”时，将0-255的亮度值转换为16进制数（即0-FF），不足3个字符高位补0。
        //                          |----------14： 校验位（2个字符）：将前6位字符对应的ASCII码以2进制按位进行异或运算，
        //                                                           2进制异或结果的高4位对应的16进制数作为校验位的第1个字符，低4位对应的16进制数作为校验位的第2个字符。
        bool connected = false;

        public event Action<string> Info;
        public event Action<string> Warn;
        public event Action<string> Error;

        public JLFast()
        {

        }
        public JLFast(ComConfig comConfig)
        {
            this.PortName = comConfig.PortName;
            this.BaudRate = comConfig.BaudRate;
            this.DataBits = comConfig.DataBits;
        }


        ~JLFast()
        {
            Dispose();
        }

        private void Dispose()
        {
            Disconnect();
        }

        public bool Connected
        {
            get
            {
                return connected;
            }
        }

        public string Name { get; set; }

        public bool Connect()
        {
            _serialPort.BaudRate = BaudRate;
            _serialPort.PortName = PortName;
            _serialPort.DataBits = DataBits;
            _serialPort.Parity = Parity.None;
            try
            {
                _serialPort.DataReceived += new SerialDataReceivedEventHandler(PortDataReceive);
                _serialPort.Open();
                TurnOn();
                connected = true;
                return true;
            }
            catch (Exception ex)
            {
                Error?.Invoke($"光源控制器{Name}连接失败！异常信息：{ex.Message}");
                connected = false;
                return false;
            }
        }
        private void PortDataReceive(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                int readLen = _serialPort.BytesToRead;
                //readLen = 1 ,设置亮度时，控制器接收到指令后返回的指令为$或&，因此为1个字节
                //readLen = 8 ,232通讯 ，获取亮度时，新款控制器接收到指令后返回的指令为8个字节
                //readLen = 9 ,232通讯 获取亮度时，部分老款控制器接收到指令后返回的指令为9个字节，前置多一个"$"，因此删除
                //readLen = 3 ,485通讯，成功返回3位
                //readLen = 10 ,485通讯，获取亮度成功返回11位
                byte[] dataRec = new byte[readLen];
                _serialPort.Read(dataRec, 0, readLen);
                string recDataBuffer = Encoding.ASCII.GetString(dataRec);
                _strRec.Clear();
                if (readLen == 9)
                    recDataBuffer = recDataBuffer.Replace("$$", "$");
                sw.Stop();
                elapsed = sw.ElapsedMilliseconds;
                Info?.Invoke($"{Name} Message Back :{recDataBuffer}");
                _strRec = new StringBuilder(recDataBuffer);
                _serialPort.DiscardInBuffer();
            }
            catch (Exception ex)
            {
                Warn?.Invoke($"光源控制器{Name}接收异常！异常信息：{ex.Message}");
            }
            finally { _mesBack = true; }
        }
        public bool Disconnect()
        {
            try
            {
                if (Connected)
                    SetMultiIntensity(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, new int[] { 0, 0, 0, 0, 0, 0, 0, 0 });
                _busy = false;
                if (_serialPort.IsOpen)
                {
                    _serialPort.Close();
                    _serialPort.DataReceived -= new SerialDataReceivedEventHandler(PortDataReceive);
                    connected = false;
                    return true;
                }
            }
            catch (Exception ex)
            {
                Error?.Invoke($"光源控制器{Name}断开连接失败！异常信息：{ex.Message}");
                return false;
            }
            return false;
        }

        public bool SetIntensity(int channel, int value)
        {

            sw.Restart();
            return CheckState(() =>
            {
                if (value < 0 || value > 255)
                {
                    return false;
                }
                _mesBack = false;
                string msg = GetChannelIntenStr(channel, value);
                SendMsg(msg);
                var ret = GetMessageBack() != TimeOut;
                if (channel != 0)
                    _ints[channel - 1] = value;
                return ret;
            });
        }

        public void SendMsg(string order)
        {
            if (Connected)
            {
                _serialPort.Write(order);
                Info?.Invoke($"{Name} Send Order:{order}");
            }

        }

        private string GetChannelIntenStr(int channel, int value)
        {
            string valueStr = value.ToString("X");
            if (valueStr.Length == 1)
            {
                valueStr = "00" + valueStr;
            }

            while (valueStr.Length < 3)
            {
                valueStr = $"0{valueStr}";
            }

            string msg = string.Empty;
            msg = $@"$3{channel}{valueStr}";
            msg = msg + XorCheck(msg);
            return msg;
        }

        private string XorCheck(string msg)
        {
            //获取字节数组
            byte[] b = Encoding.ASCII.GetBytes(msg);
            // xorResult 存放校验结注意：初值首元素值
            byte xorResult = b[0];
            // 求xor校验注意：XOR运算第二元素始
            for (int i = 1; i < b.Length; i++)
            {
                xorResult ^= b[i];
            }
            // 运算xorResultXOR校验结，^=为异或符号
            // MessageBox.Show();
            return xorResult.ToString("X");
        }

        private T CheckState<T>(Func<T> act)
        {
            T r = default(T);
            int num = 0;
            while (_busy)
            {
                Thread.Sleep(2);
                num++;
                if (num == 25)
                    break;
            }
            if (!_busy)
            {
                lock (_synLock)
                {
                    _busy = true;
                    if (act != null) r = act.Invoke();
                    _busy = false;
                }
            }
            //Thread.Sleep(20);
            Info?.Invoke($"控制器{Name}操作 耗时: {Elapsed} ms");
            return r;
        }

        private string GetMessageBack()
        {
            int num = 0;
            while (!_mesBack)
            {
                Thread.Sleep(2);
                num++;
                if (num == 25)
                    break;
            }
            if (_mesBack)
            {
                _mesBack = false;
                return _strRec.ToString();
            }

            return TimeOut;
        }
        public bool TurnOff()
        {
            sw.Restart();
            return CheckState(() =>
            {
                _mesBack = false;
                string msg = string.Empty;
                msg = $@"$20000";
                msg = msg + XorCheck(msg);
                SendMsg(msg);
                bool ret = GetMessageBack() != TimeOut;
                if (ret)
                {
                    for (int i = 0; i < 8; i++)
                    {
                        _ens[i] = false;
                    }
                }
                return ret;
            });
        }

        public bool TurnOn()
        {
            sw.Restart();
            return CheckState(() =>
            {
                _mesBack = false;
                string msg = string.Empty;
                msg = $@"$10000";
                msg = msg + XorCheck(msg);
                SendMsg(msg);
                bool ret = GetMessageBack() != TimeOut;
                if (ret)
                {
                    for (int i = 0; i < 8; i++)
                    {
                        _ens[i] = true;
                    }
                }
                return ret;
            });
        }

        public int ReadIntensity(int channel)
        {
            sw.Restart();
            return CheckState(() =>
            {
                _mesBack = false;
                string msg = string.Empty;

                msg = $@"$4{channel}000";
                msg = msg + XorCheck(msg);
                SendMsg(msg);
                var ret = GetMessageBack();
                if (ret != TimeOut)
                {
                    ret = _strRec.ToString().Substring(5, 3);
                    int intensity = 0;
                    int.TryParse(ret, out intensity);
                    _ints[channel - 1] = intensity;
                    return intensity;
                }
                return 0;
            });
        }

        public bool TurnOnChannel(int channel)
        {
            sw.Restart();
            return CheckState(() =>
            {
                _mesBack = false;
                string msg = string.Empty;

                msg = $@"$1{channel}000";
                msg = msg + XorCheck(msg);
                SendMsg(msg);
                bool ret = GetMessageBack() != TimeOut;
                if (ret)
                {
                    _ens[channel - 1] = true;
                }
                return ret;
            });
        }

        public bool TurnOffChannel(int channel)
        {
            sw.Restart();
            return CheckState(() =>
            {
                _mesBack = false;
                string msg = string.Empty;

                msg = $@"$2{channel}000";
                msg = msg + XorCheck(msg);
                SendMsg(msg);
                bool ret = GetMessageBack() != TimeOut;
                if (ret)
                {
                    _ens[channel - 1] = false;
                }
                return ret;
            });
        }

        public bool TurnOnMultiChannel(int channelNum, int[] chs)
        {
            for (int i = 0; i < channelNum; i++)
            {
                TurnOnChannel(chs[i]);
            }
            return true;
        }

        public bool TurnOffMultiChannel(int channelNum, int[] chs)
        {
            int[] intensitys = new int[chs.Length];
            return SetMultiIntensity(chs, intensitys);
        }

        public bool SetMultiIntensity(int[] channels, int[] intensitys)
        {
            sw.Restart();
            return CheckState(() =>
            {
                _mesBack = false;

                string msg = string.Empty;
                int length = Math.Min(channels.Length, intensitys.Length);
                for (int i = 0; i < length; i++)
                {
                    msg += GetChannelIntenStr(channels[i], intensitys[i]);
                }
                SendMsg(msg);
                var ret = GetMessageBack() != TimeOut;
                for (int i = 0; i < length; i++)
                {
                    _ints[channels[i] - 1] = intensitys[i];
                }
                return ret;
            });
        }

        public int[] ReadMultiIntensity(int[] channels)
        {
            int[] intens = new int[channels.Length];
            for (int i = 0; i < channels.Length; i++)
            {
                intens[i] = ReadIntensity(channels[i]);
            }
            return intens;
        }

        public bool ApplyConfig(ILightConfig config)
        {
            BaseLightConfig cfg = (BaseLightConfig)config;
            return SetMultiIntensity(cfg.Channels, cfg.Intensitys);
        }
    }
}
