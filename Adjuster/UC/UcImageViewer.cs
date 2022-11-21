using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using Adjuster.Tools;
using System.Diagnostics;
using System.Threading;
using System.Drawing.Imaging;

namespace Adjuster.UC
{
    public partial class UcImageViewer : Bing.Viewer.ImageViewer
    {
        Dictionary<Point, RectangleF> rectfDict = new Dictionary<Point, RectangleF>();
        private List<AreaInfo> areaInfos = new List<AreaInfo>();
        Dictionary<Point, GrayInfo> grayInfoDict = new Dictionary<Point, GrayInfo>();
        //private Dictionary<AreaInfo, Bitmap> DictImage = new Dictionary<AreaInfo, Bitmap>();
        private bool busy = false;
        private int busyCount = 0;
        public event Action<List<AreaInfo>> AreaInfoChanged;
        class GrayInfo
        {
            public int R;
            public int B;
            public int G;
            public int Gray;
            public int Count;
            public GrayInfo(int r, int b, int g, int gray)
            {
                R = r;
                B = b;
                G = g;
                Gray = gray;
            }
        }
        public UcImageViewer()
        {
            InitializeComponent();
            this.ImageChanged += UcImageViewer_ImageChanged;
        }

        private void UcImageViewer_ImageChanged()
        {
            if (Image == null)
            {
                return;
            }
            if (!ShowBlock)
                return;
            if (!_showBright)
                return;
            imageChanged = false;
            busyCount++;
            if (busy && busyCount < 1500)
            {
                return;
            }
            busyCount = 0;

            Task.Run(() =>
            {
                Bitmap bmp = new Bitmap(Image);
                Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
                var bitmapData = bmp.LockBits(rect, ImageLockMode.ReadWrite,
                                              bmp.PixelFormat);
                int width = bmp.Width;
                int height = bmp.Height;
                var xstep = width / VCount;
                var ystep = height / HCount;

                int Depth = Image.GetPixelFormatSize(bmp.PixelFormat);
                int PixelCount = width * height;
                //Rectangle rawRect = new Rectangle(0, 0, Width, Height);
                if (Depth != 8 && Depth != 24 && Depth != 32)
                {
                    throw new ArgumentException("Only 8, 24 and 32 bpp images are supported.");
                }
                int step = Depth / 8;
                byte[] Pixels = new byte[PixelCount * step];
                IntPtr Iptr = IntPtr.Zero;
                Iptr = bitmapData.Scan0;
                // Copy data from pointer to array
                System.Runtime.InteropServices.Marshal.Copy(Iptr, Pixels, 0, Pixels.Length);
                bmp.UnlockBits(bitmapData);
                busy = true;
                Stopwatch sw = new Stopwatch();
                sw.Start();
                var result = Parallel.ForEach(areaInfos, item =>
                  {

                      Point point = new Point(item.Column, item.Row);
                      var sx = rectfDict[point].X;
                      var sy = rectfDict[point].Y;


                      var xStart = (item.Column - 1) * xstep;
                      var yStart = (item.Row - 1) * ystep;
                      var w = xstep * item.ColumnSpan;
                      var h = ystep * item.RowSpan;
                      Rectangle cropRect = new Rectangle((int)xStart, (int)yStart, (int)w, (int)h);
                      var info = ImageProcessing.Intensity(Pixels, Depth, width, height, cropRect);

                      item.Info = $"R = {info.MeanRed:0.0}\r\nG = {info.MeanBlue:0.0}\r\nB = {info.MeanBlue:0.0}\r\nGray = {info.Mean:0.0}";

                  });
                bool x = result.IsCompleted;

                sw.Stop();
                AreaInfoChanged?.Invoke(areaInfos);

                //MessageBox.Show($"{sw.Elapsed.TotalMilliseconds:0.00} ms");
                busy = false;
                GC.Collect();
                Invalidate();
            });
        }

        private int radius = 5;
        private int _vCount = 8;//列数，X
        private int _hCount = 8;//行数，Y
        private bool _showBlock = false;
        private bool _showBright = false;
        private bool imageChanged = false;
        public int Radius
        {
            get { return radius; }
            set
            {
                radius = value;
                Invalidate();
            }
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
                InitAreaInfos();
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
                InitAreaInfos();
                Invalidate();
            }
        }

        public bool ShowBlock
        {
            get { return _showBlock; }
            set
            {
                _showBlock = value;
                Invalidate();
            }
        }

        public bool ShowBright
        {
            get { return _showBright; }
            set
            {
                _showBright = value;
            }
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
        public bool RemoveArea(int row, int column)
        {
            if (areaInfos.Count(k => k.Row == row && k.Column == column) > 0)
            {
                areaInfos.RemoveAll(k => k.Row == row && k.Column == column);
                Invalidate();
                return true;
            }
            return false;
        }

        public void ClearAreas()
        {
            areaInfos.Clear();
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var grp = e.Graphics;
            Pen pen = new Pen(Color.Lime);
            pen.Width = 0.5f;
            if (ShowBlock)
            {
                if (rectfDict != null)
                {
                    if (this.Rect != null)
                    {
                        InitAreas();
                        e.Graphics.DrawRectangles(pen, rectfDict.Values.ToArray());
                    }
                    if (_showBright)
                    {
                        if (areaInfos != null)
                        {
                            foreach (var item in areaInfos)
                            {
                                var vStep = this.Rect.Width / VCount;
                                var hStep = this.Rect.Height / HCount;

                                Point point = new Point(item.Column, item.Row);
                                var sx = rectfDict[point].X;
                                var sy = rectfDict[point].Y;
                                var rect = new RectangleF(sx + 0.5f, sy + 0.5f, vStep * item.ColumnSpan - 1, hStep * item.RowSpan - 1);
                                if (/*mouseDown &&*/ item.Selected)
                                    grp.FillRectangle(new SolidBrush(Color.FromArgb(200, Color.Yellow)), rect);
                                grp.DrawRectangle(pen, rect.X, rect.Y, rect.Width, rect.Height);
                                grp.DrawString($"{item.Info}", this.Font, new SolidBrush(item.Color), rect, new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                            }
                        }
                    }
                }
            }
            Rectangle rectR = new Rectangle(0, 0, Width, Height);
            var path = CreateRoundedRectanglePath(rectR, radius);
            Region region = new Region(path);
            this.Region = region;
        }

        public GraphicsPath CreateRoundedRectanglePath(Rectangle rect, int cornerRadius)
        {
            GraphicsPath roundedRect = new GraphicsPath();
            roundedRect.AddArc(rect.X, rect.Y, cornerRadius * 2, cornerRadius * 2, 180, 90);
            roundedRect.AddLine(rect.X + cornerRadius, rect.Y, rect.Right - cornerRadius * 2, rect.Y);
            roundedRect.AddArc(rect.X + rect.Width - cornerRadius * 2, rect.Y, cornerRadius * 2, cornerRadius * 2, 270, 90);
            roundedRect.AddLine(rect.Right, rect.Y + cornerRadius * 2, rect.Right, rect.Y + rect.Height - cornerRadius * 2);
            roundedRect.AddArc(rect.X + rect.Width - cornerRadius * 2, rect.Y + rect.Height - cornerRadius * 2, cornerRadius * 2, cornerRadius * 2, 0, 90);
            roundedRect.AddLine(rect.Right - cornerRadius * 2, rect.Bottom, rect.X + cornerRadius * 2, rect.Bottom);
            roundedRect.AddArc(rect.X, rect.Bottom - cornerRadius * 2, cornerRadius * 2, cornerRadius * 2, 90, 90);
            roundedRect.AddLine(rect.X, rect.Bottom - cornerRadius * 2, rect.X, rect.Y + cornerRadius * 2);
            roundedRect.CloseFigure();
            return roundedRect;
        }

        private void InitAreas()
        {
            rectfDict = new Dictionary<Point, RectangleF>();
            var vStep = this.Rect.Width / VCount;
            var hStep = this.Rect.Height / HCount;
            for (int x = 0; x < VCount; x++)
            {
                var sx = x * vStep + this.Rect.X;
                for (int y = 0; y < HCount; y++)
                {
                    var sy = y * hStep + this.Rect.Y;
                    var rect = new RectangleF(sx, sy, vStep, hStep);

                    Point point = new Point(x + 1, y + 1);
                    rectfDict.Add(point, rect);

                }
            }

        }

        private void InitAreaInfos()
        {
            ClearAreas();
            grayInfoDict = new Dictionary<Point, GrayInfo>();
            var index = 0;
            for (int x = 0; x < VCount; x++)
            {
                for (int y = 0; y < HCount; y++)
                {
                    index++;
                    AreaInfo areaInfo = new AreaInfo()
                    {
                        Color = Color.Cyan,
                        Column = x + 1,
                        Row = y + 1,
                        Block = index.ToString(),
                        Info = string.Empty,
                        Selected = false
                    };
                    AddArea(areaInfo);
                    grayInfoDict.Add(new Point(areaInfo.Column, areaInfo.Row), new GrayInfo(0, 0, 0, 0));
                }
            }
        }
    }
}
