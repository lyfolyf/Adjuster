using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Adjuster.Camera;
using Adjuster.Tools;
using Adjuster.UC;
using Bing.Viewer;

namespace Adjuster
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 操作ROI
        /// </summary>
        BingRectangle roiRect = new BingRectangle(100, 120, 200f, 100f) { Activated = true };
        private int lvl = 5;
        private bool startFoucs;
        private bool startHistogram;
        private IMatching matchingTool = null;
        private string plugPath;
        List<Type> algorithmTypeList = new List<Type>();
        double sx, sy, sAngle;
        private object synLock1 = new object();
        private object synLock6 = new object();
        private object synUnionLock = new object();
        private bool busy1 = false;
        private bool busy6 = false;

        private Bitmap unionBmp1;
        private Bitmap unionBmp2;
        private Bitmap unionBmp3;

        BingRectangle roiRect2 = new BingRectangle(1500, 1500, 500f, 500f) { Activated = true };
        IntensityInfo intensityInfo1 = new IntensityInfo();
        IntensityInfo intensityInfo2 = new IntensityInfo();
        IntensityInfo intensityInfo3 = new IntensityInfo();
        IntensityInfo intensityInfo1p = new IntensityInfo();
        IntensityInfo intensityInfo2p = new IntensityInfo();
        IntensityInfo intensityInfo3p = new IntensityInfo();

        ManualResetEvent mre1 = new ManualResetEvent(false);
        ManualResetEvent mre2 = new ManualResetEvent(false);
        ManualResetEvent mre3 = new ManualResetEvent(false);
        IntensityInfo intensityInfoStd = new IntensityInfo();
        int calcNum = 100;
        double calcLimit = 0.001;
        CalcMode calcMode = CalcMode.Bright;
        int calcStep = 1;
        private bool infinite = true;
        private bool imgBack1 = false;
        private bool imgBack2 = false;
        private bool imgBack3 = false;
        enum CalcMode
        {
            Bright,
            Color
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            cbRotate1.Items.Add("0°");
            cbRotate1.Items.Add("90°");
            cbRotate1.Items.Add("180°");
            cbRotate1.Items.Add("270°");
            cbRotate1.SelectedIndex = 0;

            cbRotate2.Items.Add("0°");
            cbRotate2.Items.Add("90°");
            cbRotate2.Items.Add("180°");
            cbRotate2.Items.Add("270°");
            cbRotate2.SelectedIndex = 0;

            cbRotate3.Items.Add("0°");
            cbRotate3.Items.Add("90°");
            cbRotate3.Items.Add("180°");
            cbRotate3.Items.Add("270°");
            cbRotate3.SelectedIndex = 0;

            ResetAreas();

            plugPath = $@"{Application.StartupPath}\matching plugs";
            LoadPlugs();
            imageViewer1.ClearRoi();
            imageViewer1.AddRoi(roiRect);
            imageViewer6.ClearRoi();
            imageViewer6.AddRoi(roiRect);
            ucCamera1.ImageTook += UcCamera1_ImageTook;
            ucCamera5.ImageTook += UcCamera5_ImageTook;
            ucCamera4.ImageTook += UcCamera4_ImageTook;
            ucCamera3.ImageTook += UcCamera3_ImageTook;
            ucCamera2.ImageTook += UcCamera2_ImageTook;
            ucCamUnion1.ImageTook += UcCamUnion1_ImageTook;
            ucCamUnion2.ImageTook += UcCamUnion2_ImageTook;
            ucCamUnion3.ImageTook += UcCamUnion3_ImageTook;

            ucCameraBright.ImageTook += UcCameraBright_ImageTook;
            ucViewerBright.AreaInfoChanged += UcViewerBright_AreaInfoChanged;

            ucImageViewer1.ClearRoi();
            ucImageViewer1.AddRoi(roiRect2);
            ucImageViewer2.ClearRoi();
            ucImageViewer2.AddRoi(roiRect2);
            ucImageViewer3.ClearRoi();
            ucImageViewer3.AddRoi(roiRect2);
            ucCamera6.ImageTook += UcCamera6_ImageTook;
            ucCamera7.ImageTook += UcCamera7_ImageTook;
            ucCamera8.ImageTook += UcCamera8_ImageTook;
            ucCamera9.ImageTook += UcCamera9_ImageTook;

        }

        private void UcCamera9_ImageTook(object sender, ImageTookEventArgs e)
        {
            this.Invoke(new Action(() => { advancedViewer1.Image = e.Image; }));
        }

        private void UcCamera6_ImageTook(object sender, ImageTookEventArgs e)
        {
            this.Invoke(new Action(() =>
            {
                ucImageViewer1.Image = e.Image;
                var cut = ImageProcessing.GetCutImage(e.Image, roiRect2);
                intensityInfo1p = intensityInfo1;
                intensityInfo1 = ImageProcessing.Intensity(cut);
                ucIntensityInfo1.IntensityInfo = intensityInfo1;
                switch (calcMode)
                {
                    case CalcMode.Bright:
                        if (intensityInfo1p.Bright != intensityInfo1.Bright)
                        {
                            if (intensityInfo1p.Bright != 0 && intensityInfoStd.Bright != 0)
                            {
                                if ((intensityInfoStd.Bright > intensityInfo1p.Bright && intensityInfo1.Bright > intensityInfo1p.Bright) || (intensityInfoStd.Bright < intensityInfo1p.Bright && intensityInfo1.Bright < intensityInfo1p.Bright))
                                {
                                    calcStep = (int)(((intensityInfo1.Bright - intensityInfo1p.Bright) / calcStep) * (intensityInfoStd.Bright - intensityInfo1p.Bright));
                                }
                                if (Math.Abs(intensityInfo1.Bright - intensityInfo1p.Bright) < 1)
                                {
                                    calcStep *= 10;
                                }
                            }
                        }
                        else { calcStep = 50; }
                        break;
                    case CalcMode.Color:
                        calcStep = 1;
                        break;
                }
                mre1.Set();
            }));
            imgBack1 = true;
        }
        private void UcCamera7_ImageTook(object sender, ImageTookEventArgs e)
        {
            this.Invoke(new Action(() =>
            {
                ucImageViewer2.Image = e.Image;
                var cut = ImageProcessing.GetCutImage(e.Image, roiRect2);
                intensityInfo2p = intensityInfo2;
                intensityInfo2 = ImageProcessing.Intensity(cut);
                ucIntensityInfo2.IntensityInfo = intensityInfo2;
                switch (calcMode)
                {
                    case CalcMode.Bright:
                        if (intensityInfo2p.Bright != intensityInfo2.Bright)
                        {
                            if (intensityInfo2p.Bright != 0 && intensityInfoStd.Bright != 0)
                            {
                                if ((intensityInfoStd.Bright > intensityInfo2p.Bright && intensityInfo2.Bright > intensityInfo2p.Bright) || (intensityInfoStd.Bright < intensityInfo2p.Bright && intensityInfo2.Bright < intensityInfo2p.Bright))
                                {
                                    calcStep = (int)(((intensityInfo2.Bright - intensityInfo2p.Bright) / calcStep) * (intensityInfoStd.Bright - intensityInfo2p.Bright));
                                }
                                if (Math.Abs(intensityInfo2.Bright - intensityInfo2p.Bright) < 1)
                                {
                                    calcStep *= 10;
                                }
                            }
                        }
                        else { calcStep = 50; }
                        break;
                    case CalcMode.Color:
                        calcStep = 1;
                        break;
                }
                mre2.Set();

            }));
            imgBack2 = true;
        }
        private void UcCamera8_ImageTook(object sender, ImageTookEventArgs e)
        {
            this.Invoke(new Action(() =>
            {
                ucImageViewer3.Image = e.Image;
                var cut = ImageProcessing.GetCutImage(e.Image, roiRect2);
                intensityInfo3p = intensityInfo3;
                intensityInfo3 = ImageProcessing.Intensity(cut);
                ucIntensityInfo3.IntensityInfo = intensityInfo3;
                switch (calcMode)
                {
                    case CalcMode.Bright:
                        if (intensityInfo3p.Bright != intensityInfo3.Bright)
                        {
                            if (intensityInfo3p.Bright != 0 && intensityInfoStd.Bright != 0)
                            {
                                if ((intensityInfoStd.Bright > intensityInfo3p.Bright && intensityInfo3.Bright > intensityInfo3p.Bright) || (intensityInfoStd.Bright < intensityInfo3p.Bright && intensityInfo3.Bright < intensityInfo3p.Bright))
                                {
                                    calcStep = (int)(((intensityInfo3.Bright - intensityInfo3p.Bright) / calcStep) * (intensityInfoStd.Bright - intensityInfo3p.Bright));
                                }
                                if (Math.Abs(intensityInfo3.Bright - intensityInfo3p.Bright) < 1)
                                {
                                    calcStep *= 10;
                                }
                            }
                        }
                        else { calcStep = 50; }
                        break;
                    case CalcMode.Color:
                        calcStep = 1;
                        break;
                }
                mre3.Set();
            }));
            imgBack3 = true;
        }
        private void UcViewerBright_AreaInfoChanged(List<AreaInfo> obj)
        {
            this.Invoke(new Action(() => { ucAreaSelect1.SetAreaInfos(obj); }));
        }

        private void UcCameraBright_ImageTook(object sender, ImageTookEventArgs e)
        {
            this.Invoke(new Action(() => { ucViewerBright.Image = e.Image; }));
        }

        private void UcCamUnion1_ImageTook(object sender, ImageTookEventArgs e)
        {
            int index = 0;
            this.Invoke(new Action(() => { index = cbRotate1.SelectedIndex; }));
            lock (synUnionLock)
            {
                if (e.Success)
                {
                    unionBmp1 = e.Image;
                    RotateFlipType rotate;
                    switch (index)
                    {
                        case 0:
                            rotate = RotateFlipType.RotateNoneFlipNone;
                            break;
                        case 1:
                            rotate = RotateFlipType.Rotate90FlipNone;
                            break;
                        case 2:
                            rotate = RotateFlipType.Rotate180FlipNone;
                            break;
                        case 3:
                            rotate = RotateFlipType.Rotate270FlipNone;
                            break;
                        default:
                            rotate = RotateFlipType.RotateNoneFlipNone;
                            break;
                    }
                    unionBmp1.RotateFlip(rotate);
                    UnionImage();
                }
            }
        }
        private void UcCamUnion2_ImageTook(object sender, ImageTookEventArgs e)
        {
            int index = 0;
            this.Invoke(new Action(() => { index = cbRotate2.SelectedIndex; }));
            lock (synUnionLock)
            {
                if (e.Success)
                {
                    unionBmp2 = e.Image;
                    RotateFlipType rotate;
                    switch (index)
                    {
                        case 0:
                            rotate = RotateFlipType.RotateNoneFlipNone;
                            break;
                        case 1:
                            rotate = RotateFlipType.Rotate90FlipNone;
                            break;
                        case 2:
                            rotate = RotateFlipType.Rotate180FlipNone;
                            break;
                        case 3:
                            rotate = RotateFlipType.Rotate270FlipNone;
                            break;
                        default:
                            rotate = RotateFlipType.RotateNoneFlipNone;
                            break;
                    }
                    unionBmp2.RotateFlip(rotate);
                    UnionImage();
                }
            }
        }
        private void UcCamUnion3_ImageTook(object sender, ImageTookEventArgs e)
        {
            int index = 0;
            this.Invoke(new Action(() => { index = cbRotate3.SelectedIndex; }));
            lock (synUnionLock)
            {
                if (e.Success)
                {
                    unionBmp3 = e.Image;
                    RotateFlipType rotate;
                    switch (index)
                    {
                        case 0:
                            rotate = RotateFlipType.RotateNoneFlipNone;
                            break;
                        case 1:
                            rotate = RotateFlipType.Rotate90FlipNone;
                            break;
                        case 2:
                            rotate = RotateFlipType.Rotate180FlipNone;
                            break;
                        case 3:
                            rotate = RotateFlipType.Rotate270FlipNone;
                            break;
                        default:
                            rotate = RotateFlipType.RotateNoneFlipNone;
                            break;
                    }
                    unionBmp3.RotateFlip(rotate);
                    UnionImage();
                }
            }
        }


        private void UnionImage()
        {
            bool vh = false;
            bool u1 = false, u2 = false, u3 = false;
            this.Invoke(new Action(() =>
            {
                vh = ckbVH.Checked;
                u1 = ckbUsed1.Checked;
                u2 = ckbUsed2.Checked;
                u3 = ckbUsed3.Checked;
            }));
            int w = 0;
            int h = 0;
            int xs = 0;
            int ys = 0;
            Bitmap unionBmp;
            if (vh)
            {
                if (u1 && unionBmp1 != null)
                {
                    w = w < unionBmp1.Width ? unionBmp1.Width : w;
                    h += unionBmp1.Height;
                }

                if (u2 && unionBmp2 != null)
                {
                    w = w < unionBmp2.Width ? unionBmp2.Width : w;
                    h += unionBmp2.Height;
                }

                if (u3 && unionBmp3 != null)
                {
                    w = w < unionBmp3.Width ? unionBmp3.Width : w;
                    h += unionBmp3.Height;
                }
                if (w == 0 || h == 0)
                {
                    return;
                }
                unionBmp = new Bitmap(w, h);
                using (var g = Graphics.FromImage(unionBmp))
                {
                    if (u1 && unionBmp1 != null)
                    {
                        var rect = new RectangleF(xs, ys, unionBmp1.Width, unionBmp1.Height);
                        g.DrawImage(unionBmp1, rect);
                        ys += unionBmp1.Height;
                    }
                    if (u2 && unionBmp2 != null)
                    {
                        var rect = new RectangleF(xs, ys, unionBmp2.Width, unionBmp2.Height);
                        g.DrawImage(unionBmp2, rect);
                        ys += unionBmp2.Height;
                    }

                    if (u3 && unionBmp3 != null)
                    {
                        var rect = new RectangleF(xs, ys, unionBmp3.Width, unionBmp3.Height);
                        g.DrawImage(unionBmp3, rect);
                        ys += unionBmp3.Height;
                    }

                }
            }
            else
            {
                if (u1 && unionBmp1 != null)
                {
                    h = h < unionBmp1.Height ? unionBmp1.Height : h;
                    w += unionBmp1.Width;
                }

                if (u2 && unionBmp2 != null)
                {
                    h = h < unionBmp2.Height ? unionBmp2.Height : h;
                    w += unionBmp2.Width;
                }

                if (u3 && unionBmp3 != null)
                {
                    h = h < unionBmp3.Height ? unionBmp3.Height : h;
                    w += unionBmp3.Width;
                }
                if (w == 0 || h == 0)
                {
                    return;
                }
                unionBmp = new Bitmap(w, h);
                using (var g = Graphics.FromImage(unionBmp))
                {
                    if (u1 && unionBmp1 != null)
                    {
                        var rect = new RectangleF(xs, ys, unionBmp1.Width, unionBmp1.Height);
                        g.DrawImage(unionBmp1, rect);
                        xs += unionBmp1.Width;
                    }
                    if (u2 && unionBmp2 != null)
                    {
                        var rect = new RectangleF(xs, ys, unionBmp2.Width, unionBmp2.Height);
                        g.DrawImage(unionBmp2, rect);
                        xs += unionBmp2.Width;
                    }

                    if (u3 && unionBmp3 != null)
                    {
                        var rect = new RectangleF(xs, ys, unionBmp3.Width, unionBmp3.Height);
                        g.DrawImage(unionBmp3, rect);
                        xs += unionBmp3.Width;
                    }

                }
            }
            this.Invoke(new Action(() => { ucImageViewerUnion.Image = unionBmp; }));

        }


        private void UcCamera2_ImageTook(object sender, ImageTookEventArgs e)
        {
            imageViewer3.Image = e.Image;
        }

        private void UcCamera3_ImageTook(object sender, ImageTookEventArgs e)
        {
            imageViewer4.Image = e.Image;
        }

        private void UcCamera4_ImageTook(object sender, ImageTookEventArgs e)
        {
            imageViewer5.Image = e.Image;
        }

        private void UcCamera5_ImageTook(object sender, ImageTookEventArgs e)
        {
            //if (!busy6)
            lock (synLock6)
            {
                imageViewer6.Image = e.Image;
            }
        }

        private void UcCamera1_ImageTook(object sender, ImageTookEventArgs e)
        {
            //if (!busy1)
            lock (synLock1)
            {
                imageViewer1.Image = e.Image;
            }
        }


        private void rbLvl_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            int.TryParse(rb.Tag.ToString(), out lvl);
            ucFocus1.Max = 0;
            ucFocus1.Level = lvl;
        }

        void LoadPlugs()
        {
            algorithmTypeList = AsmLoader.LoadPlugs<IMatching>(plugPath);
            cbAlgorithm.Items.Clear();
            for (int i = 0; i < algorithmTypeList.Count; i++)
            {
                cbAlgorithm.Items.Add(algorithmTypeList[i].Name);
            }

            if (algorithmTypeList.Count > 0)
                cbAlgorithm.SelectedIndex = 0;
        }
        private void btnRunFoucs_Click(object sender, EventArgs e)
        {
            if (!startFoucs)
            {
                startFoucs = true;
                ucFocus1.Current = 0;
                ucFocus1.Max = 0;
                btnRunFoucs.Text = @"停止";
                ucFocus1.Level = lvl;
                Task.Run(() =>
                {
                    while (startFoucs)
                    {
                        busy1 = true;
                        try
                        {
                            Invoke(new Action(() =>
                            {
                                lock (synLock1)
                                {
                                    var image = imageViewer1.Image;
                                    var cut = ImageProcessing.GetCutImage(image, roiRect);
                                    imageViewer2.Image = cut;
                                    ucFocus1.Image = cut;
                                }
                            }));
                        }
                        catch { }
                        Thread.Sleep(50);
                        busy1 = false;
                    }
                    Invoke(new Action(() => btnRunFoucs.Text = @"开始"));
                });
            }
            else
            {
                startFoucs = false;
                btnRunFoucs.Text = "开始";
            }
        }

        private void btnHistogram_Click(object sender, EventArgs e)
        {
            if (!startHistogram)
            {
                startHistogram = true;
                btnHistogram.Text = @"停止";
                Task.Run(() =>
                {
                    while (startHistogram)
                    {
                        busy6 = true;
                        try
                        {
                            Invoke(new Action(() =>
                            {
                                lock (synLock6)
                                {
                                    var image = imageViewer6.Image;
                                    var cut = ImageProcessing.GetCutImage(imageViewer6.Image, roiRect);
                                    ucHistogram1.Image = cut;
                                    ucHistogramR.Image = cut;
                                    ucHistogramG.Image = cut;
                                    ucHistogramB.Image = cut;
                                    lblBright.Text = $@"亮度比：{ucHistogram1.Bright}%";//平均值：
                                    lbAvg.Text = $@"平均值：{ucHistogram1.Mean}";
                                }
                            }));
                        }
                        catch { }
                        Thread.Sleep(50);
                        busy6 = false;
                    }
                    Invoke(new Action(() => btnHistogram.Text = @"直方图"));
                });
            }
            else
            {
                startHistogram = false;
                btnHistogram.Text = "直方图";
            }
        }

        private void cbAlgorithm_SelectedIndexChanged(object sender, EventArgs e)
        {
            var index = cbAlgorithm.SelectedIndex;
            matchingTool = AsmLoader.CreateInstance<IMatching>(algorithmTypeList[index]);
        }

        private void btnShowROI_Click(object sender, EventArgs e)
        {
            imageViewer3.ClearRoi();
            imageViewer3.AddRoi(roiRect);
        }

        private void btnHideROI_Click(object sender, EventArgs e)
        {
            imageViewer3.ClearRoi();
        }

        private void btnCreateModel_Click(object sender, EventArgs e)
        {
            var cut = ImageProcessing.GetCutImage(imageViewer3.Image, roiRect);
            matchingTool.TrainImage = cut;
            matchingTool.CreateModel();
            try
            {
                matchingTool.FindModel(imageViewer3.Image, out sx, out sy, out sAngle);
                ucLocation1.Stdx = sx;
                ucLocation1.Stdy = sy;
                ucLocation2.Stdx = sx;
                ucLocation2.Stdy = sy;
                ucLocation3.Stdx = sx;
                ucLocation3.Stdy = sy;
                btnCreateModel.BackColor = Color.Aquamarine;
            }
            catch (Exception exception)
            {

            }

        }



        private void btnResetModel_Click(object sender, EventArgs e)
        {
            matchingTool.Reset();
            btnCreateModel.BackColor = Color.Gray;
        }

        private void btnFind1_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ckbSnop1.Checked)
                {
                    ucCamera2.Snop();
                    Thread.Sleep(500);
                }
                double x, y, angle;
                matchingTool.FindModel(imageViewer3.Image, out x, out y, out angle);
                ucLocation1.Currentx = x;
                ucLocation1.Currenty = y;
                BingCircle circle = new BingCircle((float)x, (float)y, 50);
                circle.Activated = false;
                circle.SelectedColor = Color.Magenta;
                imageViewer3.ClearRoi();
                imageViewer3.AddRoi(circle);
                pStatus1.BackColor = Color.Lime;
            }
            catch (Exception exception)
            {
                pStatus1.BackColor = Color.Red;
            }

        }

        private void btnResetFoucs_Click(object sender, EventArgs e)
        {
            ucFocus1.Current = 0;
            ucFocus1.Max = 0;
        }

        private void ucCamera1_Load(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (System.IO.File.Exists($@"{Environment.CurrentDirectory}\拼接.exe"))
            {
                Process.Start($@"{Environment.CurrentDirectory}\拼接.exe");
            }
        }

        private void btnFind2_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ckbSnop2.Checked)
                {
                    ucCamera3.Snop();
                    Thread.Sleep(500);
                }
                double x, y, angle;
                matchingTool.FindModel(imageViewer4.Image, out x, out y, out angle);
                ucLocation2.Currentx = x;
                ucLocation2.Currenty = y;
                BingCircle circle = new BingCircle((float)x, (float)y, 50);
                circle.Activated = false;
                circle.SelectedColor = Color.Magenta;
                imageViewer4.ClearRoi();
                imageViewer4.AddRoi(circle);
                pStatus2.BackColor = Color.Lime;
            }
            catch (Exception exception)
            {
                pStatus2.BackColor = Color.Red;
            }
        }

        private void numericUdHcount_ValueChanged(object sender, EventArgs e)
        {
            ucAreaSelect1.ClearAreas();
            ucAreaSelect1.HCount = (int)numericUdHcount.Value;
            ucViewerBright.HCount = (int)numericUdHcount.Value;
            ResetAreas();
        }

        private void numericUdVcount_ValueChanged(object sender, EventArgs e)
        {
            ucAreaSelect1.ClearAreas();
            ucAreaSelect1.VCount = (int)numericUdVcount.Value;
            ucViewerBright.VCount = (int)numericUdVcount.Value;
            ResetAreas();
        }

        private void btnBright_Click(object sender, EventArgs e)
        {
            //ucViewerBright.ShowBright = true;
            //ucViewerBright.Invalidate();
            //ucViewerBright.ShowBright = false;
        }

        private void btnSetAsStrand1_Click(object sender, EventArgs e)
        {
            intensityInfoStd = intensityInfo1;
            ucIntensityInfoStd.IntensityInfo = intensityInfoStd;
            btnSetAsStrand1.Text = "基准";
            btnSetAsStrand2.Text = "设为基准";
            btnSetAsStrand3.Text = "设为基准";
            //btnLoopCalc1.Enabled = false;
            //btnLoopCalc2.Enabled = true;
            //btnLoopCalc3.Enabled = true;
            txtTargetBright.Text = $"{intensityInfoStd.Bright}";
            txtTargetBG.Text = $"{intensityInfoStd.BG}";
            txtTargetRG.Text = $"{intensityInfoStd.RG}";
        }

        private void btnSetAsStrand2_Click(object sender, EventArgs e)
        {
            intensityInfoStd = intensityInfo2;
            ucIntensityInfoStd.IntensityInfo = intensityInfoStd;
            btnSetAsStrand1.Text = "设为基准";
            btnSetAsStrand2.Text = "基准";
            btnSetAsStrand3.Text = "设为基准";
            //btnLoopCalc1.Enabled = true;
            //btnLoopCalc2.Enabled = false;
            //btnLoopCalc3.Enabled = true;
            txtTargetBright.Text = $"{intensityInfoStd.Bright}";
            txtTargetBG.Text = $"{intensityInfoStd.BG}";
            txtTargetRG.Text = $"{intensityInfoStd.RG}";
        }

        private void btnSetAsStrand3_Click(object sender, EventArgs e)
        {
            intensityInfoStd = intensityInfo3;
            ucIntensityInfoStd.IntensityInfo = intensityInfoStd;
            btnSetAsStrand1.Text = "设为基准";
            btnSetAsStrand2.Text = "设为基准";
            btnSetAsStrand3.Text = "基准";
            //btnLoopCalc1.Enabled = true;
            //btnLoopCalc2.Enabled = true;
            //btnLoopCalc3.Enabled = false;
            txtTargetBright.Text = $"{intensityInfoStd.Bright}";
            txtTargetBG.Text = $"{intensityInfoStd.BG}";
            txtTargetRG.Text = $"{intensityInfoStd.RG}";
        }

        private void btnLoopCalc1_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                this.Invoke(new Action(() => { btnLoopCalc1.Enabled = false; }));
                while (calcNum > 0 || infinite)
                {
                    if (!infinite)
                    {
                        calcNum--;
                    }
                    switch (calcMode)
                    {
                        case CalcMode.Bright:
                            {
                                if (Math.Abs(intensityInfo1.Bright - intensityInfoStd.Bright) <= calcLimit)
                                {
                                    if (!infinite)
                                        calcNum = 0;
                                    else { infinite = false; }
                                    break;
                                }
                                if (intensityInfo1.Bright > intensityInfoStd.Bright)
                                {
                                    ucCamera6.Exposure -= calcStep;
                                }
                                else
                                {
                                    ucCamera6.Exposure += calcStep;
                                }
                                break;
                            }
                        case CalcMode.Color:
                            {
                                if (Math.Abs(intensityInfo1.RG - intensityInfoStd.RG) <= calcLimit && Math.Abs(intensityInfo1.BG - intensityInfoStd.BG) <= calcLimit)
                                {
                                    if (!infinite)
                                        calcNum = 0;
                                    else { infinite = false; }
                                    break;
                                }
                                if (intensityInfo1.RG > intensityInfoStd.RG)
                                {
                                    ucCamera6.RatioR -= 1;
                                }
                                else
                                {
                                    ucCamera6.RatioR += 1;
                                }
                                if (intensityInfo1.BG > intensityInfoStd.BG)
                                {
                                    ucCamera6.RatioB -= 1;
                                }
                                else
                                {
                                    ucCamera6.RatioB += 1;
                                }
                                break;
                            }
                    }
                    imgBack1 = false;
                    ucCamera6.Snop();
                    this.Invoke(new Action(() =>
                    {
                        txtCalcNum.Text = $"{calcNum}";
                        ckbInfinite.Checked = infinite;
                    }));
                    mre1.WaitOne();
                    int index = 1000;
                    while (!imgBack1 && index > 0)
                    {
                        Thread.Sleep(5);
                        index--;
                    }
                }
                this.Invoke(new Action(() => { btnLoopCalc1.Enabled = true; }));
            });
        }

        private void btnLoopCalc2_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                this.Invoke(new Action(() => { btnLoopCalc2.Enabled = false; }));
                while (calcNum > 0 || infinite)
                {
                    if (!infinite)
                    {
                        calcNum--;
                    }
                    switch (calcMode)
                    {
                        case CalcMode.Bright:
                            {
                                if (Math.Abs(intensityInfo2.Bright - intensityInfoStd.Bright) <= calcLimit)
                                {
                                    if (!infinite)
                                        calcNum = 0;
                                    else { infinite = false; }
                                    break;
                                }
                                if (intensityInfo2.Bright > intensityInfoStd.Bright)
                                {
                                    ucCamera7.Exposure -= calcStep;
                                }
                                else
                                {
                                    ucCamera7.Exposure += calcStep;
                                }
                                break;
                            }
                        case CalcMode.Color:
                            {
                                if (Math.Abs(intensityInfo2.RG - intensityInfoStd.RG) <= calcLimit && Math.Abs(intensityInfo2.BG - intensityInfoStd.BG) <= calcLimit)
                                {
                                    if (!infinite)
                                        calcNum = 0;
                                    else { infinite = false; }
                                    break;
                                }
                                if (intensityInfo2.RG > intensityInfoStd.RG)
                                {
                                    ucCamera7.RatioR -= 1;
                                }
                                else
                                {
                                    ucCamera7.RatioR += 1;
                                }
                                if (intensityInfo2.BG > intensityInfoStd.BG)
                                {
                                    ucCamera7.RatioB -= 1;
                                }
                                else
                                {
                                    ucCamera7.RatioB += 1;
                                }
                                break;
                            }
                    }
                    imgBack2 = false;
                    ucCamera7.Snop();
                    this.Invoke(new Action(() =>
                    {
                        txtCalcNum.Text = $"{calcNum}";
                        ckbInfinite.Checked = infinite;
                    }));
                    mre2.WaitOne();
                    int index = 1000;
                    while (!imgBack2 && index > 0)
                    {
                        Thread.Sleep(5);
                        index--;
                    }
                }
                this.Invoke(new Action(() => { btnLoopCalc2.Enabled = true; }));
            });
        }

        private void btnLoopCalc3_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                this.Invoke(new Action(() => { btnLoopCalc3.Enabled = false; }));
                while (calcNum > 0 || infinite)
                {
                    if (!infinite)
                    {
                        calcNum--;
                    }
                    switch (calcMode)
                    {
                        case CalcMode.Bright:
                            {
                                if (Math.Abs(intensityInfo3.Bright - intensityInfoStd.Bright) <= calcLimit)
                                {
                                    if (!infinite)
                                        calcNum = 0;
                                    else { infinite = false; }
                                    break;
                                }
                                if (intensityInfo3.Bright > intensityInfoStd.Bright)
                                {
                                    ucCamera8.Exposure -= calcStep;
                                }
                                else
                                {
                                    ucCamera8.Exposure += calcStep;
                                }
                                break;
                            }
                        case CalcMode.Color:
                            {
                                if (Math.Abs(intensityInfo3.RG - intensityInfoStd.RG) <= calcLimit && Math.Abs(intensityInfo3.BG - intensityInfoStd.BG) <= calcLimit)
                                {
                                    if (!infinite)
                                        calcNum = 0;
                                    else { infinite = false; }
                                    break;
                                }
                                if (intensityInfo3.RG > intensityInfoStd.RG)
                                {
                                    ucCamera8.RatioR -= 1;
                                }
                                else
                                {
                                    ucCamera8.RatioR += 1;
                                }
                                if (intensityInfo3.BG > intensityInfoStd.BG)
                                {
                                    ucCamera8.RatioB -= 1;
                                }
                                else
                                {
                                    ucCamera8.RatioB += 1;
                                }
                                break;
                            }
                    }
                    imgBack3 = false;
                    ucCamera8.Snop();
                    this.Invoke(new Action(() =>
                    {
                        txtCalcNum.Text = $"{calcNum}";
                        ckbInfinite.Checked = infinite;
                    }));
                    mre3.WaitOne();
                    int index = 1000;
                    while (!imgBack3 && index > 0)
                    {
                        Thread.Sleep(5);
                        index--;
                    }
                }
                this.Invoke(new Action(() => { btnLoopCalc3.Enabled = true; }));
            });

        }

        private void rbBrightMode_CheckedChanged(object sender, EventArgs e)
        {
            calcMode = CalcMode.Bright;
        }

        private void rbColorMode_CheckedChanged(object sender, EventArgs e)
        {
            calcMode = CalcMode.Color;
        }

        private void txtCalcNum_TextChanged(object sender, EventArgs e)
        {
            calcNum = GetIValue(txtCalcNum);
            //txtCalcNum.Text = $"{calcNum}";
        }
        private double GetDValue(TextBox textBox)
        {
            double val = 0;
            double.TryParse(textBox.Text, out val);
            return val;
        }
        private int GetIValue(TextBox textBox)
        {
            int val = 0;
            int.TryParse(textBox.Text, out val);
            return val;
        }

        private void txtCalcLimit_TextChanged(object sender, EventArgs e)
        {
            calcLimit = GetDValue(txtCalcLimit);
            //txtCalcLimit.Text = $"{calcLimit}";
        }

        private void ckbInfinite_CheckedChanged(object sender, EventArgs e)
        {
            infinite = ckbInfinite.Checked;
        }

        private void btnLoadLocalImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Bitmap bitmap = new Bitmap(ofd.FileName);
                    ucImageViewer2.Image = bitmap;
                }
                catch (Exception)
                {

                }
            }
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            var cut = ImageProcessing.GetCutImage(ucImageViewer2.Image, roiRect2);
            intensityInfo2 = ImageProcessing.Intensity(cut);
            ucIntensityInfo2.IntensityInfo = intensityInfo2;
        }

        private void txtTargetBright_TextChanged(object sender, EventArgs e)
        {
            intensityInfoStd.Bright = GetDValue(txtTargetBright);
            ucIntensityInfoStd.IntensityInfo = intensityInfoStd;
        }

        private void txtTargetRG_TextChanged(object sender, EventArgs e)
        {
            intensityInfoStd.RG = GetDValue(txtTargetRG);
            ucIntensityInfoStd.IntensityInfo = intensityInfoStd;
        }

        private void txtTargetBG_TextChanged(object sender, EventArgs e)
        {
            intensityInfoStd.BG = GetDValue(txtTargetBG);
            ucIntensityInfoStd.IntensityInfo = intensityInfoStd;
        }

        private void btnFind3_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ckbSnop3.Checked)
                {
                    ucCamera4.Snop();
                    Thread.Sleep(500);
                }
                double x, y, angle;
                matchingTool.FindModel(imageViewer5.Image, out x, out y, out angle);
                ucLocation3.Currentx = x;
                ucLocation3.Currenty = y;
                BingCircle circle = new BingCircle((float)x, (float)y, 50);
                circle.Activated = false;
                circle.SelectedColor = Color.Magenta;
                imageViewer5.ClearRoi();
                imageViewer5.AddRoi(circle);
                pStatus3.BackColor = Color.Lime;
            }
            catch (Exception exception)
            {
                pStatus3.BackColor = Color.Red;
            }
        }

        private void ResetAreas()
        {
            var index = 0;
            for (int x = 0; x < ucAreaSelect1.VCount; x++)
            {
                for (int y = 0; y < ucAreaSelect1.HCount; y++)
                {
                    index++;
                    AreaInfo areaInfo = new AreaInfo()
                    {
                        Color = Color.Blue,
                        Column = x + 1,
                        Row = y + 1,
                        Block = index.ToString(),
                        Info = index.ToString(),
                        Selected = false
                    };
                    ucAreaSelect1.AddArea(areaInfo);
                }
            }
        }
    }

}
