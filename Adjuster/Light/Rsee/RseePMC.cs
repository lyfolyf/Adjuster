using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Adjuster.Rsee
{
    public class RseePMC : ILightController
    {
        public RseePMC()
        {

        }
        public RseePMC(ComConfig comConfig)
        {
            this.PortName = comConfig.PortName;
            this.BaudRate = comConfig.BaudRate;
            this.DataBits = comConfig.DataBits;
        }

        private const string TimeOut = "&";

        public string PortName { get; set; }

        public int BaudRate { get; set; } = 19200;
        public int DataBits { get; set; } = 8;
        StringBuilder _strRec = new StringBuilder();
        private bool _busy = false;
        private bool _mesBack = false;
        Stopwatch sw = new Stopwatch();
        private readonly object _synLock = new object();
        readonly int[] _ints = new int[2];
        readonly bool[] _ens = new bool[2];

        readonly SerialPort _serialPort = new SerialPort();
        bool connected = false;
        public bool Connected
        {
            get
            {
                return connected;
            }
        }

        private double elapsed = 0;
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
        public string Name { get; set; }
        public event Action<string> Info;
        public event Action<string> Warn;
        public event Action<string> Error;
        public bool Connect()
        {
            _serialPort.BaudRate = BaudRate;
            _serialPort.PortName = PortName;
            _serialPort.DataBits = DataBits;
            _serialPort.Parity = Parity.None;
            _serialPort.DataReceived += PortDataReceive;
            try
            {
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
                _mesBack = true;
                int readLen = _serialPort.BytesToRead;
                byte[] dataRec = new byte[readLen];
                _serialPort.Read(dataRec, 0, readLen);
                string recDataBuffer = Encoding.ASCII.GetString(dataRec);
                _strRec.Clear();
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
                    TurnOff();
                _busy = false;
                if (_serialPort.IsOpen)
                {
                    _serialPort.Close();
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

        public void SendMsg(string order)
        {
            if (Connected)
            {
                _serialPort.Write(order);
                Info?.Invoke($"{Name} Send Order:{order}");
            }
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
                string intensity = value > 99 ? $"{value}" : value > 9 ? $"0{value}" : $"00{value}";
                string ch = channel == 1 ? "A" : "B";
                var order = $"S{ch}0{intensity}#";
                SendMsg(order);
                var ret = GetMessageBack() != TimeOut;
                if (channel != 0)
                    _ints[channel - 1] = value;
                return ret;
            });
        }

        public int ReadIntensity(int channel)
        {
            sw.Restart();
            return CheckState(() =>
            {
                _mesBack = false;
                string ch = channel == 1 ? "A" : "B";
                var order = $"S{ch}#";
                SendMsg(order);
                var ret = GetMessageBack();
                if (ret != TimeOut)
                {
                    //控制器返回 _0Xxxx
                    ret = _strRec.ToString().Substring(2, 3);
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
            return SetIntensity(channel, _ints[channel - 1]);
        }

        public bool TurnOffChannel(int channel)
        {
            sw.Restart();
            return CheckState(() =>
            {
                _mesBack = false;
                string ch = channel == 1 ? "A" : "B";
                var order = $"S{ch}0000#";
                SendMsg(order);
                var ret = GetMessageBack() != TimeOut;
                return ret;
            });
        }

        public bool TurnOnMultiChannel(int channelNum, int[] chs)
        {
            return TurnOn();
        }

        public bool TurnOffMultiChannel(int channelNum, int[] chs)
        {
            return TurnOff();
        }

        public bool TurnOff()
        {
            return SetMultiIntensity(new int[2] { 1, 2 }, new int[2] { 0, 0 });
        }

        public bool TurnOn()
        {
            return SetMultiIntensity(new int[2] { 1, 2 }, new int[2] { _ints[0], _ints[1] });
        }


        public bool SetMultiIntensity(int[] channels, int[] intensitys)
        {
            return CheckState(() =>
            {
                _mesBack = false;
                var order = string.Empty;
                for (int i = 0; i < channels.Length; i++)
                {
                    int channel = channels[i];
                    string ch = channel == 1 ? "A" : "B";
                    string intensity = intensitys[i].ToString();
                    while (intensity.Length < 3)
                    {
                        intensity = $"0{intensity}";
                    }
                    order += $"S{ch}0{intensity}#";
                }
                SendMsg(order);
                var ret = GetMessageBack() != TimeOut;
                return ret;
            });
        }

        public int[] ReadMultiIntensity(int[] channels)
        {
            sw.Restart();
            return CheckState(() =>
            {
                int[] intensitys = new int[channels.Length];
                _mesBack = false;
                var order = string.Empty;
                for (int i = 0; i < channels.Length; i++)
                {
                    int channel = channels[i];
                    string ch = channel == 1 ? "A" : "B";
                    order += $"S{ch}#";
                }
                SendMsg(order);
                var ret = GetMessageBack();
                if (ret != TimeOut)
                {
                    var strs = ret.Split(new char[] { 'a', 'b' }, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < strs.Length; i++)
                    {
                        ret = strs[i].Substring(1, 3);
                        int intensity = 0;
                        int.TryParse(ret, out intensity);
                        intensitys[i] = intensity;
                    }
                }
                return intensitys;
            });
        }

        public bool ApplyConfig(ILightConfig config)
        {
            BaseLightConfig cfg = (BaseLightConfig)config;
            return SetMultiIntensity(cfg.Channels, cfg.Intensitys);
        }
    }
}
