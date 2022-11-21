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

        public static RuleCollection Rules { get; set; } = new RuleCollection();

        public static void LoadConfig()
        {
            var path = $@"{Environment.CurrentDirectory}\SysSetting.cfg";
            if (System.IO.File.Exists(path))
                Rules = Serialize.JsonDeserializeObject<RuleCollection>(path);
        }

        public static void SaveConfig()
        {
            var path = $@"{Environment.CurrentDirectory}\SysSetting.cfg";
            Serialize.JsonSerialize(path, Rules);
        }
    }
}
