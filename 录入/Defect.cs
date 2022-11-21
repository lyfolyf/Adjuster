using System.Drawing;

namespace 拼接
{

    public class Defect
    {
        public Defect(Point locate, int size)
        {
            Locate = locate;
            Size = size;
        }

        public Point Locate { get; set; }
        public int Size { get; set; }
        public string Surface { get; set; }
        public string Block { get; set; }
        public string Info { get; set; }
    }
}
