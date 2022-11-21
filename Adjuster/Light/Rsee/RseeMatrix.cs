using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Adjuster.Rsee
{
    public class RseeMatrix : ILightController
    {
        private const string TimeOut = "&";
        private bool _busy = false;
        private bool _mesBack = false;
        Stopwatch sw = new Stopwatch();
        private readonly object _synLock = new object();
        StringBuilder _strRec = new StringBuilder();

        Socket _clientSocket;
        Thread _threadReceive;

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
        public string Ip { get; set; } = "192.168.1.252";
        public int Port { get; set; } = 8234;
        public int LightMode
        {
            get { return lightMode; }
            set
            {
                lightMode = value;
            }
        }

        public byte Step
        {
            get { return step; }
            set
            {
                step = value;
            }
        }

        private int lightMode = 1;
        private byte step = 1;

        bool[] stepFlags = new bool[8] { false, false, false, false, false, false, false, false };
        bool connected = false;

        public RseeMatrix(string iP, int port)
        {
            this.Port = port;
            this.Ip = iP;
            stepFlags = new bool[8] { false, false, false, false, false, false, false, false };
        }

        public bool Connected
        {
            get
            {
                return connected;
            }
        }
        public event Action<string> Info;
        public event Action<string> Warn;
        public event Action<string> Error;
        public string Name { get; set; }
        public bool Connect()
        {
            if (Connected)
            {
                Disconnect();
            }
            IPAddress ip = IPAddress.Parse(Ip);
            _clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                //连接服务器
                _clientSocket.Connect(ip, Port);
                //开启线程不停接收服务器发送的数据
                _threadReceive = new Thread(TcpDataReceive) { IsBackground = true };
                _threadReceive.Start();
                connected = true;
                //SetMode(1);
                return true;
            }
            catch (Exception ex)
            {
                Error?.Invoke($"光源控制器{Name}连接失败！异常信息：{ex.Message}");
                connected = false;
            }
            return false;
        }
        public bool Disconnect()
        {
            try
            {
                if (Connected)
                {
                    TurnOff();
                    _busy = false;
                    _clientSocket.Close();
                    if (_threadReceive != null)
                        _threadReceive.Abort();
                    connected = false;
                }
                return true;
            }
            catch (Exception ex)
            {
                Error?.Invoke($"光源控制器{Name}断开连接失败！异常信息：{ex.Message}");
                return false;
            }
        }


        private void TcpDataReceive()
        {
            try
            {
                while (Connected)
                {
                    byte[] buff = new byte[1024];
                    int r = _clientSocket.Receive(buff);
                    var recDataBuffer = Encoding.Default.GetString(buff, 0, r);
                    _mesBack = true;
                    sw.Stop();
                    elapsed = sw.ElapsedMilliseconds;
                    Info?.Invoke($"{Name} Message Back :{recDataBuffer}");
                    _strRec = new StringBuilder(recDataBuffer);
                }
            }
            catch (Exception ex)
            {
                Warn?.Invoke($"光源控制器{Name}接收异常！异常信息：{ex.Message}");
            }
            finally { _mesBack = true; }
        }

        private void SendMsg(string order)
        {
            sw.Restart();
            var buffer = Encoding.Default.GetBytes(order.Trim());
            _clientSocket.Send(buffer);
            Info?.Invoke($"{Name} Send Order:{order}");
        }
        private void SendMsg(byte[] order)
        {
            _clientSocket.Send(order);
            Info?.Invoke($"{Name} Send Order:{order}");
        }
        private T CheckState<T>(Func<T> act)
        {
            sw.Restart();
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

        public bool SetIntensity(byte value)
        {
            return CheckState(() =>
            {
                if (value > 255)
                {
                    return false;
                }
                _mesBack = false;

                var order = GetOrderBytes("@A5", new[] { value });

                SendMsg(order);
                var ret = GetMessageBack() != TimeOut;//返回：_A5\r\n
                return ret;
            });
        }

        public bool TurnOff()
        {
            int[] lightnesses = new int[56];
            return SetStripes(lightnesses);
        }

        /// <summary>
        /// 常亮常灭模式设置
        /// </summary>
        /// <param name="mode">0 常灭/1 常亮</param>
        /// <returns></returns>
        public bool SetMode(byte mode)
        {
            return CheckState(() =>
            {
                if (mode != 1 && mode != 0)
                {
                    return false;
                }
                _mesBack = false;

                var order = GetOrderBytes("@A8", new[] { mode });

                SendMsg(order);
                var ret = GetMessageBack() != TimeOut;//返回：_A8\r\n
                lightMode = mode;
                return ret;
                //return true;
            });
        }
        /// <summary>
        /// 设置条纹宽度
        /// </summary>
        /// <param name="width">条纹宽度 1~4</param>
        /// <returns></returns>
        public bool SetStripWidth(byte width)
        {
            return CheckState(() =>
            {
                if (width > 4 || width <= 0)
                {
                    return false;
                }
                _mesBack = false;

                var order = GetOrderBytes("@E1", new[] { width });

                SendMsg(order);
                var ret = GetMessageBack() != TimeOut;//返回：_E1\r\n
                return ret;
                //return true;
            });
        }
        /// <summary>
        /// 步骤切换
        /// </summary>
        /// <param name="step">步骤 1~8 纵向 1~4 横向 5~8</param>
        /// <returns></returns>
        public bool SetStep(byte step)
        {
            return CheckState(() =>
            {
                if (step > 8 || step <= 0)
                {
                    return false;
                }
                _mesBack = false;

                var order = GetOrderBytes("@E2", new[] { step });

                SendMsg(order);
                var ret = GetMessageBack() != TimeOut;//返回：_E2\r\n
                return ret;
                //return true;
            });
        }
        /// <summary>
        /// 根据数组长度56、32自动设置纵向、横向条纹
        /// </summary>
        /// <param name="arr">条纹</param>
        /// <param name="width">条纹宽度</param>
        /// <param name="step">步骤</param>
        /// <returns></returns>
        public bool SetStripes(int[] arr, byte width = 1, byte step = 1)
        {
            Step = GetStepFormChs(arr);
            if (Step > 0)
            {
                if (stepFlags[Step - 1])
                {
                    return SetStep(Step);
                }
            }
            if (arr.Length == 56)
            {
                step = Step > 0 ? Step : (byte)4;
            }
            else
            if (arr.Length == 32)
            {
                step = Step > 0 ? Step : (byte)8;
            }
            if (stepFlags[step - 1])
            {
                return SetStep(step);
            }

            return CheckState(() =>
            {
                var len = arr.Length;
                string stra = string.Empty;
                for (int i = 0; i < len; i++)
                {
                    stra = $"{arr[i]}{stra}";
                }

                byte[] order;

                if (len == 56)//设置纵向条纹
                {
                    byte[] data = new byte[9];
                    data[0] = width;//宽度（1~4）
                    data[1] = step; //步骤（1~4）
                    int index = 0;
                    for (int i = 2; i < 9; i++)
                    {
                        var binData = stra.Substring(index, 8);
                        data[i] = Convert.ToByte(binData, 2);
                        index += 8;
                    }
                    order = GetOrderBytes("@E3", data);
                }
                else if (len == 32)//设置横向条纹
                {
                    if (step < 5)
                    {
                        step = 5;
                    }
                    byte[] data = new byte[6];
                    data[0] = width;//宽度（1~4）
                    data[1] = step; //步骤（5~8）
                    int index = 0;
                    for (int i = 2; i < 6; i++)
                    {
                        var binData = stra.Substring(index, 8);
                        data[i] = Convert.ToByte(binData, 2);
                        index += 8;
                    }
                    order = GetOrderBytes("@E4", data);
                }
                else//错误的格式
                {
                    return false;
                }

                SendMsg(order);
                var ret = GetMessageBack() != TimeOut;//返回：_E3\r\n 或 _E4\r\n
                if (Step > 0)
                    stepFlags[Step - 1] = ret;
                return ret;
                //return true;
            });
        }
        private byte[] GetOrderBytes(string orderStr, byte[] data = default(byte[]))
        {
            var len = data?.Length ?? 0;
            byte[] order = new byte[7 + len];
            int index = 0;
            byte[] ors = System.Text.Encoding.ASCII.GetBytes(orderStr);
            for (int i = 0; i < ors.Length; i++)
            {
                order[index] = ors[i];
                index++;
            }

            order[index] = (byte)len; //数据长度
            index++;

            if (data != null)
            {
                for (int i = 0; i < data.Length; i++)
                {
                    order[index] = data[i];//数据
                    index++;
                }
            }

            byte xor = order[1];
            for (int i = 2; i < order.Length - 3; i++)
            {
                xor ^= order[i];
            }

            var binCode = Convert.ToString(xor, 2);

            while (binCode.Length < 8)
            {
                binCode = $"0{binCode}";
            }

            var hcrc = binCode.Substring(0, 4);
            var lcrc = binCode.Substring(4, 4);

            var h = Convert.ToByte(hcrc, 2);
            var l = Convert.ToByte(lcrc, 2);

            order[index] = h; //高位CRC
            index++;

            order[index] = l; //低位CRC
            index++;

            byte[] ore = System.Text.Encoding.ASCII.GetBytes("#");
            for (int i = 0; i < ore.Length; i++)
            {
                order[index] = ore[i];
                index++;
            }
            return order;
        }

        private byte GetStepFormChs(int[] chs)
        {
            if (chs == null && chs.Length != 56 && chs.Length != 32)
                return 0;
            if (chs.Length == 56)
            {
                if (chs[0] == 1 && chs[1] == 0)
                {
                    return 1;
                }
                else if (chs[0] == 0 && chs[1] == 1)
                {
                    return 2;
                }
            }

            if (chs.Length == 32)
            {
                if (chs[0] == 1 && chs[1] == 0)
                {
                    return 5;
                }
                else if (chs[0] == 0 && chs[1] == 1)
                {
                    return 6;
                }
            }

            return 0;
        }


        public bool TurnOn()
        {
            throw new NotImplementedException();
        }

        public bool SetIntensity(int channel, int value)
        {
            return SetIntensity((byte)value);
        }

        public int ReadIntensity(int channel)
        {
            throw new NotImplementedException();
        }

        public bool TurnOnChannel(int channel)
        {
            throw new NotImplementedException();
        }

        public bool TurnOffChannel(int channel)
        {
            return TurnOff();
        }

        public bool TurnOnMultiChannel(int channelNum, int[] chs)
        {
            throw new NotImplementedException();
        }

        public bool TurnOffMultiChannel(int channelNum, int[] chs)
        {
            return TurnOff();
        }

        public bool SetMultiIntensity(int[] channels, int[] intensitys)
        {
            int lightness = 0;
            if (intensitys != null)
            {
                if (intensitys.Length <= 0)
                    return false;

                foreach (var item in intensitys)
                {
                    lightness = lightness > item ? lightness : item;
                }

                SetIntensity((byte)lightness);
                Info?.Invoke($"设置{Name}亮度[{lightness}] 耗时: {Elapsed} ms");
            }

            if (channels.Length != intensitys.Length)
            {
                return false;
            }
            var chst = channels.Clone() as int[];
            var str = string.Empty;
            for (int i = 0; i < chst.Length; i++)
            {
                if (intensitys[i] > 0)
                {
                    chst[i] = 1;
                    str = $"{str}1";
                }
                else
                {
                    chst[i] = 0;
                    str = $"{str}0";
                }
            }
            bool ret = false;
            if (lightness == 0)
            {
                ret = TurnOff();
            }
            else
            {
                ret = SetStripes(chst);
            }
            Info?.Invoke($"设置{Name}条纹[{str}] 耗时: {Elapsed} ms");
            return ret;
        }

        public int[] ReadMultiIntensity(int[] channels)
        {
            throw new NotImplementedException();
        }

        public bool ApplyConfig(ILightConfig config)
        {
            BaseLightConfig cfg = (BaseLightConfig)config;
            return SetMultiIntensity(cfg.Channels, cfg.Intensitys);
        }
    }
}
