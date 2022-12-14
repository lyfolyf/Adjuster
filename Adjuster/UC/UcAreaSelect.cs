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

namespace Adjuster.UC
{
    [DefaultEvent("AeraClick")]
    public partial class UcAreaSelect : UcPanel
    {

        private int _vCount = 4;//列数，X
        private int _hCount = 3;//行数，Y
        private Color _lineColor = Color.Yellow;
        Dictionary<Point, RectangleF> rectfDict = new Dictionary<Point, RectangleF>();
        private Color _highlightColor = Color.Yellow;
        private byte highlightTransparency = 100;
        private List<AreaInfo> areaInfos = new List<AreaInfo>();
        private bool mouseDown = false;

        public event Action<object, AreaSelectEventArgs> AeraClick;
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
        }

        private void UcAreaSelect_MouseLeave(object sender, EventArgs e)
        {
            foreach (var item in areaInfos)
            {
                item.Selected = false;
            }
            Invalidate();
        }

        private void UcAreaSelect_MouseMove(object sender, MouseEventArgs e)
        {
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
                    item.Selected = true;
                }
                else
                {
                    item.Selected = false;
                }
            }

            Invalidate();
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
                            break;
                        case MouseButtons.None:
                            break;
                        case MouseButtons.Right:
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
                    //item.Selected = true;
                    AreaSelectEventArgs args = new AreaSelectEventArgs
                    {
                        RectF = rect,
                        Button = e.Button,
                        Row = item.Row,
                        Column = item.Column,
                        Block = item.Block
                    };
                    AeraClick?.Invoke(this, args);
                }
                else
                {
                    //item.Selected = false;
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
            for (int x = 0; x <= VCount; x++)
            {
                var sx = x * vStep;
                for (int y = 0; y < HCount; y++)
                {
                    var sy = y * hStep;
                    var rect = new RectangleF(sx, sy, vStep, hStep);

                    Point point = new Point(x + 1, y + 1);
                    rectfDict.Add(point, rect);
                }
            }
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
                    var rect = new RectangleF(sx + 1, sy + 1, vStep * item.ColumnSpan - 2, hStep * item.RowSpan - 2);
                    if (/*mouseDown &&*/ item.Selected)
                        g.FillRectangle(new SolidBrush(Color.FromArgb(HighlightTransparency, HighlightColor)), rect);
                    g.DrawRectangle(pen, rect.X, rect.Y, rect.Width, rect.Height);
                    g.DrawString($"{item.Info}", this.Font, new SolidBrush(Color.DeepSkyBlue), rect, new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                }
        }
    }


    public class AreaSelectEventArgs : EventArgs
    {
        public RectangleF RectF { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
        public string Block { get; set; } = string.Empty;
        public MouseButtons Button { get; set; }
    }

    [Serializable]
    public class AreaInfo
    {
        public bool Selected { get; internal set; } = false;
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
