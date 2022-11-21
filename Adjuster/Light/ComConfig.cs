using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adjuster
{
    [Serializable]
    public class ComConfig
    {
        public string PortName { get; set; } = "COM1";
        public int BaudRate { get; set; } = 115200;
        public int DataBits { get; set; } = 8;
    }
    [Serializable]
    public class TcpConfig
    {
        public string Ip { get; set; } = "192.168.1.10";
        public int Port { get; set; } = 34565;
    }
}
