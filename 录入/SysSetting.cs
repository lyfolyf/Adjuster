using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 拼接
{
    internal static class SysSetting
    {
        public static SysConfig SysConfig { get; set; } = new SysConfig();

        public static void LoadConfig()
        {
            var path = $@"{Environment.CurrentDirectory}\SysCfg.scf";
            if (System.IO.File.Exists(path))
                SysConfig = Serialize.BinaryDeserialize<SysConfig>(path);
        }

        public static void SaveConfig()
        {
            var path = $@"{Environment.CurrentDirectory}\SysCfg.scf";
            Serialize.BinarySerialize(path, SysConfig);
        }
    }
}
