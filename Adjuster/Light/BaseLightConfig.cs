using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adjuster
{
    [Serializable]
    public class BaseLightConfig : ILightConfig
    {
        int[] channels;
        int[] intensitys;

        public int[] Channels
        {
            get { return channels; }
            set
            {
                channels = value;
            }
        }

        public int[] Intensitys
        {
            get { return intensitys; }
            set
            {
                intensitys = value;
            }
        }
    }
}
