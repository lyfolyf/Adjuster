using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using Adjuster.Tools;

namespace Adjuster
{
    public partial class AdvancedViewer : UserControl
    {
        Bing.Viewer.ImageViewer viewer = new Bing.Viewer.ImageViewer();
        string path = Application.StartupPath + "\\roilist.json";
        RoiStorage roiStorage = new RoiStorage();
        long quality = 75;
        CalcType calcType = CalcType.Irgb;
        public AdvancedViewer()
        {
            InitializeComponent();
            viewer.Dock = DockStyle.Fill;
            panel1.Controls.Add(viewer);
            roiStorage = RoiStorage.LoadConfig(path);
            if (roiStorage == null)
            {
                roiStorage = new RoiStorage();
            }
            UpdateRois();
            tscmbCalcType.SelectedIndex = 0;
            tscmbCalcType.SelectedIndexChanged += TscmbCalcType_SelectedIndexChanged;
        }

        private void TscmbCalcType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tscmbCalcType.SelectedIndex)
            {
                case 0:
                    calcType = CalcType.Irgb;
                    break;
                case 1:
                    calcType = CalcType.极值;
                    break;
                case 2:
                    calcType = CalcType.Avg;
                    break;
            }
            tsbCalc_Click(null, null);
        }

        public Image Image
        {
            get
            {
                return viewer.Image;
            }
            set
            {
                viewer.Image = value;
            }

        }
        public bool AutoFit
        {
            get { return viewer.AutoFit; }
            set { viewer.AutoFit = value; }
        }
        private void tsbOpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog() { Filter = "*.json文件|*.json", InitialDirectory = Application.StartupPath };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                path = ofd.FileName;
                roiStorage = RoiStorage.LoadConfig(path);
                UpdateRois();
            }

        }

        private void UpdateRois()
        {
            viewer.ClearRoi();
            foreach (var item in roiStorage)
            {
                var rect = new Bing.Viewer.BingRectangle(item.X, item.Y, item.Width, item.Height);
                rect.ShowInfo = true;
                viewer.AddRoi(rect);
            }
        }
        private void UpdateRois(Bing.Viewer.BingRectangle rect)
        {
            rect.Activated = true;
            viewer.AddRoi(rect);
        }

        private void tsbSaveFile_Click(object sender, EventArgs e)
        {
            UpdateRoiStorage();
            roiStorage.SaveConfig(path);
        }

        private void tsbAdd_Click(object sender, EventArgs e)
        {
            var dialog = new FrmAddNewRectRoi();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var roi = dialog.Rect;
                roi.Activated = true;
                roi.ShowInfo = true;
                roi.Info = "New Rect";
                UpdateRois(roi);
                UpdateRoiStorage();
            }
        }

        private void tsbDelete_Click(object sender, EventArgs e)
        {

            viewer.RemoveActiveRoi();

            UpdateRoiStorage();
        }

        private void UpdateRoiStorage()
        {
            roiStorage.Clear();
            foreach (var roi in viewer.Rois)
            {
                if (roi is Bing.Viewer.BingRectangle)
                {
                    var brect = (Bing.Viewer.BingRectangle)roi;
                    roiStorage.Add(new RectangleF(brect.X, brect.Y, brect.Width, brect.Height));
                }
            }
        }

        private void tsbCalc_Click(object sender, EventArgs e)
        {
            //System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            //sw.Start();
            Bitmap bmp = (Bitmap)Image;// new Bitmap(Image);
            Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            var bitmapData = bmp.LockBits(rect, ImageLockMode.ReadWrite,
                                          bmp.PixelFormat);
            int width = bmp.Width;
            int height = bmp.Height;

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


            Parallel.ForEach(viewer.Rois, roi =>
            {
                if (roi is Bing.Viewer.BingRectangle)
                {
                    var brect = (Bing.Viewer.BingRectangle)roi;
                    Rectangle cropRect = new Rectangle((int)brect.X, (int)brect.Y, (int)brect.Width, (int)brect.Height);
                    var infos = ImageProcessing.Intensity(Pixels, Depth, width, height, cropRect);
                    switch (calcType)
                    {
                        case CalcType.Irgb:
                            {
                                roi.Info = $"Gray:{infos.Mean:0.0}\r\nR:{infos.MeanRed:0.0}\r\nG:{infos.MeanGreen:0.0}\r\nB:{infos.MeanBlue:0.0}";
                                break;
                            }
                        case CalcType.极值:
                            {
                                var max = Math.Max(infos.MeanRed, infos.MeanGreen);
                                max = Math.Max(max, infos.MeanBlue);
                                var min = Math.Min(infos.MeanRed, infos.MeanGreen);
                                min = Math.Min(min, infos.MeanBlue);
                                var abs = Math.Abs(max - min);
                                roi.Info = $"{abs:0.0}";
                                break;
                            }
                        case CalcType.Avg:
                            {
                                roi.Info = $"{infos.Mean:0.0}";
                                break;
                            }
                    }

                }
            });

            //sw.Stop();
            //MessageBox.Show($"耗时:{sw.Elapsed.TotalMilliseconds:0.00} ms");
        }

        private void tsbHotmap_Click(object sender, EventArgs e)
        {
            FrmShowHotmap frmHotmap = new FrmShowHotmap() { Image = viewer.Image as Bitmap };
            frmHotmap.ShowDialog();
        }

        private void tsbSaveImageToFile_Click(object sender, EventArgs e)
        {
            SaveFileDialog ofd = new SaveFileDialog() { Filter = "Jpeg|*.jpg" };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                long.TryParse(tstbJpgQuality.Text, out quality);
                if (quality < 0)
                {
                    quality = 0;
                }
                if (quality > 100)
                {
                    quality = 100;
                }
                new Bitmap(this.Image).SaveBitmapToJepgFile(ofd.FileName, quality);
                tstbJpgQuality.Text = $"{quality}";
            }

        }
    }

    enum CalcType
    {
        Irgb,
        极值,
        Avg
    }
}
