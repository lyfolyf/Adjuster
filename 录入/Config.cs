using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 拼接
{
    [Serializable]
    public class SysConfig
    {
        public List<string> DefectTypes { get; set; } = new List<string>();
        public Dictionary<Camera, RotateFlipType> DictCamRotate { get; set; } = new Dictionary<Camera, RotateFlipType>()
        {
            { Camera.TC_CAM,RotateFlipType.RotateNoneFlipNone},
            { Camera.LCM_CAM,RotateFlipType.RotateNoneFlipNone},
            { Camera.Mandrel_CAM,RotateFlipType.RotateNoneFlipNone},
            { Camera.Logo_CAM,RotateFlipType.RotateNoneFlipNone},
            { Camera.Corner_CAM1,RotateFlipType.RotateNoneFlipNone},
            { Camera.Corner_CAM2,RotateFlipType.RotateNoneFlipNone},
            { Camera.Side_CAM1,RotateFlipType.RotateNoneFlipNone},
            { Camera.Side_CAM2,RotateFlipType.RotateNoneFlipNone},
            { Camera.Side_CAM3,RotateFlipType.RotateNoneFlipNone},
            { Camera.Side_CAM4,RotateFlipType.RotateNoneFlipNone},
            { Camera.Side_CAM5,RotateFlipType.RotateNoneFlipNone},
            { Camera.Side_CAM6,RotateFlipType.RotateNoneFlipNone},
            { Camera.DH_CAM,RotateFlipType.RotateNoneFlipNone},
            { Camera.BC_CAM,RotateFlipType.RotateNoneFlipNone},
        };
        public void SetCamRotate(Camera camera, RotateFlipType rotate)
        {
            if (DictCamRotate.ContainsKey(camera))
            {
                DictCamRotate[camera] = rotate;
            }
        }

        public void SetSurfaceCfg(Surface surface, SurfaceConfig config)
        {
            if (DictSurfaceCfg.ContainsKey(surface))
            {
                DictSurfaceCfg[surface] = config;
            }
        }

        /*TC,
        LCM,
        Mandrel,
        Logo,
        Corner1,
        Corner2,
        Corner3,
        Corner4,
        Side1_3,
        Side4_5,
        Side6_8,
        Side9_10,
        DH,
        BC*/
        public Dictionary<Surface, SurfaceConfig> DictSurfaceCfg { get; set; } = new Dictionary<Surface, SurfaceConfig>()
        {
            {Surface.TC,new SurfaceConfig(3,4) },
            {Surface.LCM,new SurfaceConfig(3,4) },
            {Surface.Mandrel,new SurfaceConfig(1,4) },
            {Surface.Logo,new SurfaceConfig(1,1) },
            {Surface.Corner1,new SurfaceConfig(1,1) },
            {Surface.Corner2,new SurfaceConfig(1,1) },
            {Surface.Corner3,new SurfaceConfig(1,1) },
            {Surface.Corner4,new SurfaceConfig(1,1) },
            {Surface.Side1_3,new SurfaceConfig(3,3) },
            {Surface.Side4_5,new SurfaceConfig(3,2) },
            {Surface.Side6_8,new SurfaceConfig(3,3) },
            {Surface.Side9_10,new SurfaceConfig(3,2) },
            {Surface.DH,new SurfaceConfig(3,4) },
            {Surface.BC,new SurfaceConfig(3,4) }
        };

    }

    [Serializable]
    public class SurfaceConfig
    {
        public int HCount
        {
            get { return hCount; }
            set
            {
                hCount = value;
                InitList();
            }
        }

        public SurfaceConfig(int hCount, int vCount)
        {
            HCount = hCount;
            VCount = vCount;
        }

        public int VCount
        {
            get { return vCount; }
            set
            {
                vCount = value;
                InitList();
            }
        }
        public Dictionary<Point, string> DictBlock = new Dictionary<Point, string>()
        {
            {new Point(1,1),"1_4" },
            {new Point(1,2),"2_4" },
            {new Point(1,3),"3_4" },
            {new Point(2,1),"1_3" },
            {new Point(2,2),"2_3" },
            {new Point(2,3),"3_3" },
            {new Point(3,1),"1_2" },
            {new Point(3,2),"2_2" },
            {new Point(3,3),"3_2" },
            {new Point(4,1),"1_1" },
            {new Point(4,2),"2_1" },
            {new Point(4,3),"3_1" }
        };
        private int hCount = 3;
        private int vCount = 4;
        public void Set(Point point, string pos)
        {
            if (DictBlock.ContainsKey(point))
            {
                DictBlock[point] = pos;
            }
        }
        public void InitList()
        {
            DictBlock.Clear();
            List<Point> points = new List<Point>();
            for (int x = 0; x < VCount; x++)
            {
                for (int y = 0; y < HCount; y++)
                {
                    Point p = new Point(x + 1, y + 1);
                    points.Add(p);
                }
            }
            foreach (var point in points)
            {
                DictBlock.Add(point, $"{point.Y}_{VCount + 1 - point.X}");
            }
        }
    }
}
