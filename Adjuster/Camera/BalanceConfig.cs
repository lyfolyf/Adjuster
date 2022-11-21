using Adjuster.Tools;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Adjuster.Camera
{
    [Serializable]
    public class BalanceConfig
    {
        public BalanceConfig()
        {

        }
        public BalanceConfig(string cameraId)
        {
            CameraId = cameraId;
        }

        public int GreenRatio { get; set; } = 1000;
        public int RedRatio { get; set; } = 1000;
        public int BlueRatio { get; set; } = 1000;
        public string CameraId { get; set; } = string.Empty;
        public void SaveConfig()
        {
            var path = $@"{Environment.CurrentDirectory}\CameraBalanceConfig";
            if (!System.IO.Directory.Exists(path))
            {
                System.IO.Directory.CreateDirectory(path);
            }
            Serialize.XmlSerialize($@"{path}\{CameraId}.cfg", this);
        }
        public static BalanceConfig LoadConfig(string id)
        {
            var path = $@"{Environment.CurrentDirectory}\CameraBalanceConfig\{id}.cfg";
            if (!System.IO.File.Exists(path))
            {
                BalanceConfig cfg = new BalanceConfig(id);
                cfg.SaveConfig();
            }
            return Serialize.XmlDeserailize<BalanceConfig>(path);
        }

    }
}
