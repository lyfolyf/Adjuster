using Adjuster.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Adjuster.UC
{
    public partial class UcHistogramRGB : UcPanel
    {
        public UcHistogramRGB()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.Selectable, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.SetStyle(ControlStyles.UserPaint, true);
        }

        List<double> xs = new List<double>();
        List<double> ys = new List<double>();
        List<double> p = new List<double>();

        double mean = 0;
        int median = 0;
        int minimum = 0;
        int maximum = 0;
        double standardDeviation = 0;
        double variance = 0;
        bool countMode = false;
        double bright = 0;
        public Bitmap Image
        {
            set
            {
                Clear();
                Analysis(value);
                UpdateChart();
            }
        }
        int rgb = 0;

        public double Bright
        {
            get { return bright; }
        }

        public double Mean
        {
            get { return mean; }
        }

        public int Median { get { return median; } }

        public int Minimum { get { return minimum; } }

        public int Maximum { get { return maximum; } }

        public double StandardDeviation { get { return standardDeviation; } }

        public int Rgb
        {
            get { return rgb; }
            set
            {
                rgb = value;
                chart1.Series[0].BorderWidth = 1;
                switch (rgb)
                {
                    case 0:
                        chart1.Series[0].Color = Color.Gray;
                        break;
                    case 1:
                        chart1.Series[0].Color = Color.Red;
                        break;
                    case 2:
                        chart1.Series[0].Color = Color.Green;
                        break;
                    case 3:
                        chart1.Series[0].Color = Color.Blue;
                        break;
                }
            }
        }

        private void UpdateChart()
        {
            if (countMode)
            {
                chart1.Series[0].Points.DataBindXY(xs, ys);
            }
            else
            {
                chart1.Series[0].Points.DataBindXY(xs, p);
            }
            chart1.ChartAreas[0].AxisX.StripLines[0].IntervalOffset = median;
            chart1.ChartAreas[0].AxisX.StripLines[0].Text = $"中值:{median}";
            chart1.ChartAreas[0].AxisX.StripLines[1].IntervalOffset = mean;
            chart1.ChartAreas[0].AxisX.StripLines[1].Text = $"平均值:{mean}";
            lblMin.Text = minimum.ToString();
            lblMax.Text = maximum.ToString();
            lbStandardDeviation.Text = standardDeviation.ToString("0.0");
            lbVariance.Text = variance.ToString("0.0");
            lbBright.Text = bright.ToString();
        }

        void Analysis(Bitmap bmp)
        {
            List<int> total = new List<int>();
            bright = 0;

            LockBitmap lockbmp = new LockBitmap(bmp);
            lockbmp.LockBits();
            for (int x = 0; x < lockbmp.Width; x++)
            {
                for (int y = 0; y < lockbmp.Height; y++)
                {
                    //var color = lockbmp.GetPixel(x, y);
                    byte r = 0;
                    byte g = 0;
                    byte b = 0;
                    byte a = 0;
                    lockbmp.GetPixel(x, y, out r, out g, out b, out a);
                    int grayVal = (byte)(.299 * r + .587 * g + .114 * b);
                    switch (Rgb)
                    {
                        case 0:
                            {
                                ys[grayVal]++;
                                total.Add(grayVal);
                                bright += grayVal;
                                break;
                            }
                        case 1:
                            {
                                ys[r]++;
                                total.Add(r);
                                bright += r;
                                break;
                            }
                        case 2:
                            {
                                ys[g]++;
                                total.Add(g);
                                bright += g;
                                break;
                            }
                        case 3:
                            {
                                ys[b]++;
                                total.Add(b);
                                bright += b;
                                break;
                            }
                    }

                }
            }
            lockbmp.UnlockBits();
            mean = Math.Round(bright / total.Count, 2);
            total.Sort();
            minimum = total[0];
            maximum = total[total.Count - 1];
            int m = total.Count / 2;
            median = total[m];
            for (int i = 0; i < 256; i++)
            {
                p[i] = ys[i] / (bmp.Width * bmp.Height) * 100;

            }
            foreach (var item in total)
            {
                standardDeviation += Math.Abs(item - mean);
                variance += Math.Pow(item - mean, 2);
            }
            standardDeviation = standardDeviation / total.Count;
            variance = variance / total.Count;
            bright = Math.Round(bright / (bmp.Width * bmp.Height * 255) * 100, 1);
        }

        private void Clear()
        {
            xs.Clear();
            ys.Clear();
            p.Clear();
            for (int i = 0; i < 256; i++)
            {
                xs.Add(i);
                ys.Add(0);
                p.Add(0);
            }
        }

        private void rbMode_CheckedChanged(object sender, EventArgs e)
        {
            countMode = rbCount.Checked;
            UpdateChart();
        }
    }
}
