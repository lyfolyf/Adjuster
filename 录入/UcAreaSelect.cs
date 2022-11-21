using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 拼接
{
    [DefaultEvent("AeraClick")]
    public partial class UcAreaSelect : UserControl
    {

        private int _vCount = 4;//列数，X
        private int _hCount = 3;//行数，Y
        private Color _lineColor = Color.Yellow;
        Dictionary<Point, RectangleF> rectfDict = new Dictionary<Point, RectangleF>();
        private Color _highlightColor = Color.Yellow;
        private byte highlightTransparency = 250;
        private List<AreaInfo> areaInfos = new List<AreaInfo>();
        private bool mouseDown = false;
        private bool showDefect = true;
        private List<Defect> defects = new List<Defect>();
        public event Action<object, AreaSelectEventArgs> AeraClick;
        public string Sn { get; set; } = "SN";
        public string Surface { get; set; } = "TC";
        public UcAreaSelect()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.Selectable, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            InitAreas();
            this.MouseDown += UcAreaSelect_MouseDown;
            this.MouseUp += UcAreaSelect_MouseUp;
            this.Resize += UcAreaSelect_Resize;
            this.MouseMove += UcAreaSelect_MouseMove;
            this.MouseLeave += UcAreaSelect_MouseLeave;
            this.MouseWheel += UcAreaSelect_MouseWheel;
        }

        private void UcAreaSelect_MouseWheel(object sender, MouseEventArgs e)
        {
            if (defects.Count <= 0)
                return;
            var p = defects[defects.Count - 1];
            if (e.Delta > 0)
            {
                p.Size += 5;
            }
            else
            {
                if (p.Size > 10)
                {
                    p.Size -= 5;
                }
            }
            Invalidate();
        }

        private void UcAreaSelect_MouseLeave(object sender, EventArgs e)
        {
            //foreach (var item in areaInfos)
            //{
            //    item.Selected = false;
            //}
            Invalidate();
        }

        private void UcAreaSelect_MouseMove(object sender, MouseEventArgs e)
        {
            //var vStep = this.Width / VCount;
            //var hStep = this.Height / HCount;
            //foreach (var item in areaInfos)
            //{
            //    Point point = new Point(item.Column, item.Row);
            //    var sx = rectfDict[point].X;
            //    var sy = rectfDict[point].Y;
            //    var rect = new RectangleF(sx, sy, vStep * item.ColumnSpan, hStep * item.RowSpan);
            //    if (rect.Contains(e.X, e.Y))
            //    {
            //        item.Selected = true;
            //    }
            //    else
            //    {
            //        item.Selected = false;
            //    }
            //}

            //Invalidate();
        }

        public void ClearDefects()
        {
            defects.Clear();
            Invalidate();
        }
        public void SaveDefectInfo(string folder)
        {
            if (!System.IO.Directory.Exists(folder))
            {
                System.IO.Directory.CreateDirectory(folder);
            }
            if (!System.IO.Directory.Exists($@"{folder}\{Sn}"))
            {
                System.IO.Directory.CreateDirectory($@"{folder}\{Sn}");
            }
            SaveBitmapToFile($@"{folder}\{Sn}\{Sn}_{Surface}.bmp");
            AddInfoToFile(Surface, $@"{folder}\{Sn}\{Sn}.txt");
        }

        public void SaveBitmapToFile(string path)
        {
            Bitmap bitmap = new Bitmap(this.ClientRectangle.Width, this.ClientRectangle.Height);
            this.DrawToBitmap(bitmap, this.ClientRectangle);
            bitmap.Save(path);
        }
        public void AddInfoToFile(string head, string path)
        {
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(path, true))
            {
                foreach (var item in defects)
                {
                    sw.WriteLine($"{head},{item.Block},{item.Info},{item.Size}");
                }
            }
        }
        private void UcAreaSelect_Resize(object sender, EventArgs e)
        {
            InitAreas();
            Invalidate();
        }

        private void UcAreaSelect_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
            //foreach (var item in areaInfos)
            //{
            //    item.Selected = false;
            //}
            Invalidate();
        }

        private void UcAreaSelect_MouseDown(object sender, MouseEventArgs e)
        {
            Point point1 = new Point(e.Location.X, e.Location.Y);
            mouseDown = true;
            var vStep = this.Width / VCount;
            var hStep = this.Height / HCount;
            foreach (var item in areaInfos)
            {
                Point point = new Point(item.Column, item.Row);
                var sx = rectfDict[point].X;
                var sy = rectfDict[point].Y;
                var rect = new RectangleF(sx, sy, vStep * item.ColumnSpan, hStep * item.RowSpan);
                if (rect.Contains(e.X, e.Y))
                {
                    switch (e.Button)
                    {
                        case MouseButtons.Left:
                            defects.Add(new Defect(point1, 20) { Surface = Surface, Block = item.Info });
                            break;
                        case MouseButtons.None:
                            break;
                        case MouseButtons.Right:
                            if (defects.Count > 0)
                                defects.RemoveAt(defects.Count - 1);
                            break;
                        case MouseButtons.Middle:
                            break;
                        case MouseButtons.XButton1:
                            break;
                        case MouseButtons.XButton2:
                            break;
                        default:
                            break;
                    }
                    item.Selected = true;
                    AreaSelectEventArgs args = new AreaSelectEventArgs
                    {
                        RectF = rect,
                        Button = e.Button,
                        Row = item.Row,
                        Column = item.Column,
                        Block = item.Block,
                        Info = item.Info
                    };
                    AeraClick?.Invoke(this, args);
                }
                else
                {
                    item.Selected = false;
                }
            }

            Invalidate();
        }
        public void SetAreaInfo(int row, int column, string info)
        {
            var areaInfo = areaInfos.Find(k => k.Row == row && k.Column == column);
            areaInfo.Info = info;
            Invalidate();
        }
        public void SetAreaSelected(int row, int column, bool selected)
        {
            foreach (var item in areaInfos)
            {
                item.Selected = false;
            }
            var areaInfo = areaInfos.Find(k => k.Row == row && k.Column == column);
            areaInfo.Selected = selected;
            Invalidate();
        }
        /// <summary>
        /// 列数，X
        /// </summary>
        public int VCount
        {
            get { return _vCount; }
            set
            {
                _vCount = value;
                InitAreas();
                ResetAreaInfos();
                Invalidate();
            }
        }
        /// <summary>
        /// 行数，Y
        /// </summary>
        public int HCount
        {
            get { return _hCount; }
            set
            {
                _hCount = value;
                InitAreas();
                ResetAreaInfos();
                Invalidate();
            }
        }


        public Color LineColor
        {
            get { return _lineColor; }
            set
            {
                _lineColor = value;
                Invalidate();
            }
        }
        public Color HighlightColor
        {
            get { return _highlightColor; }
            set
            {
                _highlightColor = value;
                Invalidate();
            }
        }
        public byte HighlightTransparency
        {
            get { return highlightTransparency; }
            set
            {
                highlightTransparency = value;
                Invalidate();
            }
        }

        public bool ShowDefect
        {
            get { return showDefect; }
            set
            {
                showDefect = value;
                Invalidate();
            }
        }

        public List<Defect> Defects
        {
            get { return defects; }
        }

        public List<AreaInfo> GetAreaInfos()
        { return areaInfos; }
        public void SetAreaInfos(List<AreaInfo> value)
        {
            areaInfos = value;
            InitAreas();
            Invalidate();
        }

        public bool AddArea(AreaInfo areaInfo)
        {
            if (areaInfos.Count(k => k.Block == areaInfo.Block) > 0)
            {
                int index = areaInfos.FindIndex(k => k.Block == areaInfo.Block);
                areaInfos[index] = areaInfo;
                return true;
            }
            areaInfo.Id = areaInfos.Count + 1;
            areaInfos.Add(areaInfo);
            Invalidate();
            return true;
        }
        public bool RemoveArea(int id)
        {
            if (areaInfos.Count(k => k.Id == id) > 0)
            {
                areaInfos.RemoveAll(k => k.Id == id);
                foreach (var item in areaInfos)
                {
                    if (item.Id > id)
                    {
                        item.Id--;
                    }
                }
                Invalidate();
                return true;
            }
            return false;
        }

        public void ClearAreas()
        {
            areaInfos.Clear();
            Invalidate();
        }

        private void InitAreas()
        {
            rectfDict = new Dictionary<Point, RectangleF>();
            var vStep = this.Width / VCount;
            var hStep = this.Height / HCount;
            int index = 0;
            for (int x = 0; x <= VCount; x++)
            {
                var sx = x * vStep;
                for (int y = 0; y < HCount; y++)
                {
                    var sy = y * hStep;
                    var rect = new RectangleF(sx, sy, vStep, hStep);

                    Point point = new Point(x + 1, y + 1);
                    rectfDict.Add(point, rect);
                    index++;
                }
            }
        }

        private void ResetAreaInfos()
        {
            areaInfos = new List<AreaInfo>();
            var index = 0;
            for (int x = 0; x < this.VCount; x++)
            {
                for (int y = 0; y < this.HCount; y++)
                {
                    index++;
                    AreaInfo areaInfo = new AreaInfo()
                    {
                        Color = Color.Cyan,
                        Column = x + 1,
                        Row = y + 1,
                        Block = index.ToString(),
                        Info = index.ToString(),
                        Selected = false
                    };
                    this.AddArea(areaInfo);
                }
            }
        }
        public void SetDefectInfo(string info)
        {
            if (defects.Count <= 0)
                return;
            var p = defects[defects.Count - 1];
            p.Info = info;
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var g = e.Graphics;
            Pen pen = new Pen(LineColor);
            var vStep = this.Width / VCount;
            var hStep = this.Height / HCount;
            if (areaInfos != null)
                foreach (var item in areaInfos)
                {
                    Point point = new Point(item.Column, item.Row);
                    var sx = rectfDict[point].X;
                    var sy = rectfDict[point].Y;
                    var rect = new RectangleF(sx + 0.1f, sy + 0.1f, vStep * item.ColumnSpan - 0.2f, hStep * item.RowSpan - 0.2f);
                    //if (/*mouseDown &&*/ item.Selected)
                    //    g.FillRectangle(new SolidBrush(Color.FromArgb(HighlightTransparency, HighlightColor)), rect);
                    g.DrawRectangle(pen, rect.X, rect.Y, rect.Width, rect.Height);
                    g.DrawString($"{item.Info}", this.Font, new SolidBrush(item.Color), rect, new StringFormat() { Alignment = StringAlignment.Near, LineAlignment = StringAlignment.Near });
                }
            if (showDefect)
            {
                if (defects.Count > 0)
                {
                    Font font = new Font(Font.FontFamily, Font.Size / 2);
                    for (int i = 0; i < defects.Count; i++)
                    {
                        var defect = defects[i];
                        var rect = new Rectangle(defect.Locate.X - defect.Size, defect.Locate.Y - defect.Size, defect.Size * 2, defect.Size * 2);
                        if (i != defects.Count - 1)
                        {
                            g.DrawEllipse(Pens.Red, rect);
                        }
                        else
                        {
                            g.DrawEllipse(Pens.Magenta, rect);
                        }
                        g.DrawString($"{defect.Info}", font, new SolidBrush(Color.Orange), rect, new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                    }
                }
            }
        }
    }


    public class AreaSelectEventArgs : EventArgs
    {
        public RectangleF RectF { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
        public string Block { get; set; } = string.Empty;
        public string Info { get; set; } = string.Empty;
        public MouseButtons Button { get; set; }
    }

    [Serializable]
    public class AreaInfo
    {
        public bool Selected { get; set; } = false;
        public int Row { get; set; }
        public int Column { get; set; }
        public int RowSpan { get; set; } = 1;
        public int ColumnSpan { get; set; } = 1;
        public int Id { get; set; } = 1;
        public Color Color { get; set; } = Color.Cyan;
        public string Info { get; set; } = string.Empty;
        public string Block { get; set; } = string.Empty;
        /// <summary>
        /// 示例图片路径
        /// </summary>
        public string ModelPath { get; set; } = string.Empty;
    }
}
