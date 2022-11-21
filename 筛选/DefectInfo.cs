using System;
using System.Drawing;

namespace 筛选
{
    [Serializable]
    public class DefectInfo
    {
        string defectType = "";
        string imageFile = string.Empty;
        int rotate = 0;
        Point pickPoint = new Point(0, 0);
        public string Description { get; set; }
        public string DefectType
        {
            get { return defectType; }
            set
            {
                defectType = value;
            }
        }
        public string ImageFile
        {
            get { return imageFile; }
            set
            {
                imageFile = value;
            }
        }

        public int Rotate
        {
            get { return rotate; }
            set
            {
                rotate = value;
            }
        }

        public Point PickPoint
        {
            get { return pickPoint; }
            set
            {
                pickPoint = value;
            }
        }
    }
}
