using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adjuster.Camera
{
    public class CameraInfo
    {
        public string SN { get; internal set; }

        public string UserDefinedName { get; set; }

        /// <summary>
        /// 型号
        /// </summary>
        public string Model { get; set; }

        public override string ToString()
        {
            return $"{UserDefinedName} [{SN}]";
        }
    }
}
