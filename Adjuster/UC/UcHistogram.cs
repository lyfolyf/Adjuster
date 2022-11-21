using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Adjuster.Tools;

namespace Adjuster.UC
{
    public partial class UcHistogram : UcPanel
    {
        public UcHistogram()
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
                Analysis(value);
                UpdateChart();
            }
        }

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
            Clear();
            LockBitmap lockbmp = new LockBitmap(bmp);
            lockbmp.LockBits();
            for (int x = 0; x < lockbmp.Width; x++)
            {
                for (int y = 0; y < lockbmp.Height; y++)
                {
                    int grayVal = lockbmp.GetGray(x, y);
                    ys[grayVal]++;
                    total.Add(grayVal);
                    bright += grayVal;
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
