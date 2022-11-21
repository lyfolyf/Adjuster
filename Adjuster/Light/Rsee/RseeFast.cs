using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Adjuster.Rsee
{
    public class RseeFast : ILightController
    {
        public RseeFast()
        {
            ConnectMode = 0;
        }

        public RseeFast(TcpConfig tcpConfig)
        {
            this.Ip = tcpConfig.Ip;
            this.Port = tcpConfig.Port;
            this.ConnectMode = 0;
        }
        public RseeFast(ComConfig comConfig)
        {
            this.PortName = comConfig.PortName;
            this.BaudRate = comConfig.BaudRate;
            this.DataBits = comConfig.DataBits;
            this.ConnectMode = 1;
        }

        private const string TimeOut = "&";
        public string Ip { get; set; } = "192.168.5.252";
        public int Port { get; set; } = 8234;
        public string PortName { get; set; }
        public int BaudRate { get; set; } = 115200;
        public int DataBits { get; set; } = 8;
        StringBuilder _strRec = new StringBuilder();
        private bool _busy = false;
        private bool _mesBack = false;
        Stopwatch sw = new Stopwatch();
        private readonly object _synLock = new object();
        readonly int[] _ints = new int[8];
        readonly bool[] _ens = new bool[8];

        Socket _clientSocket;
        Thread _threadReceive;

        /// <summary>
        /// 连接模式, 0为网口, 1为232串口
        /// </summary>
        public int ConnectMode { get; set; } = 0;

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
            if (ConnectMode == 0)
            {
                IPAddress ip = IPAddress.Parse(Ip.Trim());
                _clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                try
                {   //连接服务器
                    _clientSocket.Connect(ip, Port);
                    //开启线程不停接收服务器发送的数据
                    _threadReceive = new Thread(new ThreadStart(TcpDataReceive)) { IsBackground = true };
                    _threadReceive.Start();
                    //设置连接按钮在连接服务端后状态为不可点
                    connected = true;
                    TurnOn();
                    return true;
                }
                catch (Exception ex)
                {
                    Error?.Invoke($"光源控制器{Name}连接失败！异常信息：{ex.Message}");
                    connected = false;
                    return false;
                }
            }
            else if (ConnectMode == 1)
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
            return false;
        }
        private void TcpDataReceive()
        {
            while (true)
            {
                try
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
                catch (Exception ex)
                {
                    Warn?.Invoke($"光源控制器{Name}接收异常！异常信息：{ex.Message}");
                }
                finally { _mesBack = true; }
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
            if (Connected)
            {
                TurnOff();
                _busy = false;
                if (ConnectMode == 0)
                {
                    try
                    {
                        _clientSocket.Close();
                        _threadReceive.Abort();
                        connected = false;
                        return true;
                    }
                    catch (Exception ex)
                    {
                        Error?.Invoke($"光源控制器{Name}断开连接失败！异常信息：{ex.Message}");
                        return false;
                    }
                }
                else if (ConnectMode == 1 || ConnectMode == 2)
                {
                    try
                    {
                        if (_serialPort.IsOpen)
                        {
                            _serialPort.Close();
                            _serialPort.DataReceived -= PortDataReceive;
                            connected = false;
                            return true;
                        }
                    }
                    catch (Exception ex)
                    {
                        Error?.Invoke($"光源控制器{Name}断开连接失败！异常信息：{ex.Message}");
                        return false;
                    }
                }
            }
            return false;
        }

        public void SendMsg(string order)
        {
            switch (ConnectMode)
            {
                case 0://网口模式
                    var buffer = Encoding.Default.GetBytes(order.Trim());
                    _clientSocket.Send(buffer);
                    break;
                case 1:
                case 2://串口485模式
                    _serialPort.Write(order);
                    break;
                default: break;
            }
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

        public bool SetIntensity(int channel, int value)
        {
            return CheckState(() =>
            {
                if (value < 0 || value > 255)
                {
                    return false;
                }
                _mesBack = false;
                string intensity = value > 99 ? $"{value}" : value > 9 ? $"0{value}" : $"00{value}";
                var order = $"S0{channel}{intensity}#";
                SendMsg(order);
                var ret = GetMessageBack() != TimeOut;
                if (channel != 0)
                    _ints[channel - 1] = value;
                return ret;
            });
        }

        public int ReadIntensity(int channel)
        {
            return CheckState(() =>
            {
                _mesBack = false;
                var order = $"S0{channel}#";
                SendMsg(order);
                var ret = GetMessageBack();
                if (ret != TimeOut)
                {
                    //控制器返回 _0Xxxx
                    ret = _strRec.ToString().Substring(3, 3);
                    int intensity = 0;
                    int.TryParse(ret, out intensity);
                    _ints[channel - 1] = intensity;
                    return intensity;
                }
                return -1;
            });
        }
        public bool SetPulseWidth(int channel, int value)
        {
            return CheckState(() =>
            {
                if (value < 0 || value > 255)
                {
                    return false;
                }
                _mesBack = false;
                string pulseWidth = value > 99 ? $"{value}" : value > 9 ? $"0{value}" : $"00{value}";
                var order = $"SP0{channel}{pulseWidth}#";
                SendMsg(order);
                var ret = GetMessageBack() != TimeOut;
                if (channel != 0)
                    _ints[channel - 1] = value;
                return ret;
            });
        }

        public int ReadPulseWidth(int channel)
        {
            return CheckState(() =>
            {
                _mesBack = false;
                var order = $"SP0{channel}#";
                SendMsg(order);
                var ret = GetMessageBack();
                if (ret != TimeOut)
                {
                    //控制器返回 _0Xxxx
                    ret = _strRec.ToString().Substring(4, 3);
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
            return CheckState(() =>
            {
                _mesBack = false;
                string intensity = _ints[channel - 1] > 99 ? $"{ _ints[channel - 1]}" : _ints[channel - 1] > 9 ? $"0{ _ints[channel - 1]}" : $"00{ _ints[channel - 1]}";
                var order = $"S0{channel}{intensity}#";
                SendMsg(order);
                var ret = GetMessageBack() != TimeOut;
                return ret;
            });
        }

        public bool TurnOffChannel(int channel)
        {
            return CheckState(() =>
            {
                _mesBack = false;
                var order = $"S0{channel}000#";
                SendMsg(order);
                var ret = GetMessageBack() != TimeOut;
                return ret;
            });
        }

        public bool TurnOnMultiChannel(int channelNum, int[] chs)
        {
            return CheckState(() =>
            {
                _mesBack = false;
                var order = string.Empty;
                for (int i = 0; i < channelNum; i++)
                {
                    int channel = chs[i];
                    string intensity = _ints[channel - 1] > 99 ? $"{ _ints[channel - 1]}" : _ints[channel - 1] > 9 ? $"0{ _ints[channel - 1]}" : $"00{ _ints[channel - 1]}";
                    order += $"S0{channel}{intensity}#";
                }
                SendMsg(order);
                var ret = GetMessageBack() != TimeOut;
                return ret;
            });
        }

        public bool TurnOffMultiChannel(int channelNum, int[] chs)
        {
            return CheckState(() =>
            {
                _mesBack = false;
                var order = string.Empty;
                for (int i = 0; i < channelNum; i++)
                {
                    int channel = chs[i];
                    order += $"S0{channel}000#";
                }
                SendMsg(order);
                var ret = GetMessageBack() != TimeOut;
                return ret;
            });
        }

        public bool TurnOff()
        {
            return CheckState(() =>
            {
                _mesBack = false;
                var order = string.Empty;
                for (int i = 0; i < 8; i++)
                {
                    int channel = i + 1;
                    order += $"S0{channel}000#";
                }
                SendMsg(order);
                var ret = GetMessageBack() != TimeOut;
                return ret;
            });
        }

        public bool TurnOn()
        {
            return CheckState(() =>
            {
                _mesBack = false;
                var order = string.Empty;
                for (int i = 0; i < 8; i++)
                {
                    int channel = i + 1;

                    string intensity = _ints[channel - 1] > 99 ? $"{ _ints[channel - 1]}" : _ints[channel - 1] > 9 ? $"0{ _ints[channel - 1]}" : $"00{ _ints[channel - 1]}";
                    order += $"S0{channel}{intensity}#";
                }
                SendMsg(order);
                var ret = GetMessageBack() != TimeOut;
                return ret;
            });
        }

        public string ReadInfo()
        {
            return CheckState(() =>
            {
                _mesBack = false;
                var order = $"SV#";
                SendMsg(order);
                var ret = GetMessageBack();
                return ret;
            });
        }
        public bool SetIp(string ip)
        {
            IPAddress address;
            var b = IPAddress.TryParse(ip, out address);
            if (!b) return false;
            return CheckState(() =>
            {
                _mesBack = false;
                var bytes = address.GetAddressBytes();
                var order = $"SIP{bytes[0]} {bytes[1]} {bytes[2]} {bytes[3]}#";
                SendMsg(order);
                var msg = GetMessageBack();
                var ret = msg != TimeOut;
                if (ret)
                {
                    //设置失败：\r\nIP set failed\r\n
                    //设置成功：\r\nIP set successful\r\n
                    if (msg == "\r\nIP set successful\r\n")
                    {
                        return true;
                    }
                    return false;
                }
                return false;

            });
        }

        public bool SetMask(string mask)
        {
            IPAddress address;
            var b = IPAddress.TryParse(mask, out address);
            if (!b) return false;
            return CheckState(() =>
            {
                _mesBack = false;
                var bytes = address.GetAddressBytes();
                var order = $"SMA{bytes[0]} {bytes[1]} {bytes[2]} {bytes[3]}#";
                SendMsg(order);
                var msg = GetMessageBack();
                var ret = msg != TimeOut;
                if (ret)
                {
                    //设置失败：\r\nNetmask set failed\r\n
                    //设置成功：\r\nNetmask set successful\r\n
                    if (msg == "\r\nNetmask set successful\r\n")
                    {
                        return true;
                    }
                    return false;
                }
                return false;

            });
        }
        public bool SetGate(string gate)
        {
            IPAddress address;
            var b = IPAddress.TryParse(gate, out address);
            if (!b) return false;
            return CheckState(() =>
            {
                _mesBack = false;
                var bytes = address.GetAddressBytes();
                var order = $"SMA{bytes[0]} {bytes[1]} {bytes[2]} {bytes[3]}#";
                SendMsg(order);
                var msg = GetMessageBack();
                var ret = msg != TimeOut;
                if (ret)
                {
                    //设置失败：\r\nGateway set failed\r\n
                    //设置成功：\r\nGateway set successful\r\n
                    if (msg == "\r\nGateway set successful\r\n")
                    {
                        return true;
                    }
                    return false;
                }
                return false;

            });
        }

        public bool SetPort(int port)
        {
            if (port < 0 || port > 65535) return false;
            return CheckState(() =>
            {
                _mesBack = false;
                string p = port.ToString();
                while (p.Length < 5)
                {
                    p = $"0{p}";
                }
                var order = $"PORT{p}#";
                SendMsg(order);
                var msg = GetMessageBack();
                var ret = msg != TimeOut;
                if (ret)
                {
                    //设置失败：\r\nTcpPort set failed\r\n
                    //设置成功：\r\nTcpPort set successful\r\n
                    if (msg == "\r\nTcpPort set successful\r\n")
                    {
                        return true;
                    }
                    return false;
                }
                return false;

            });
        }
        /// <summary>
        /// 设置工作模式
        /// </summary>
        /// <param name="mode">1、常灭， 2、常亮，3、频闪</param>
        /// <returns></returns>
        public bool SetWorkMode(int mode)
        {
            return CheckState(() =>
            {
                _mesBack = false;
                string m = mode == 1 ? "L" : mode == 2 ? "H" : "P";
                var order = $"S{m}#";
                SendMsg(order);
                var ret = GetMessageBack() != TimeOut;
                return ret;
            });
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
                    string intensity = intensitys[i].ToString();
                    while (intensity.Length < 3)
                    {
                        intensity = $"0{intensity}";
                    }
                    order += $"S0{channel}{intensity}#";
                }
                SendMsg(order);
                var ret = GetMessageBack() != TimeOut;
                return ret;
            });
        }

        public int[] ReadMultiIntensity(int[] channels)
        {
            return CheckState(() =>
            {
                int[] intensitys = new int[channels.Length];
                _mesBack = false;
                var order = string.Empty;
                for (int i = 0; i < channels.Length; i++)
                {
                    int channel = channels[i];
                    order += $"S0{channel}#";
                }
                SendMsg(order);
                var ret = GetMessageBack();
                if (ret != TimeOut)
                {
                    var strs = ret.Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < strs.Length; i++)
                    {
                        ret = strs[i].Substring(2, 3);
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
