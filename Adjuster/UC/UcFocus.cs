using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Adjuster.Tools;

namespace Adjuster.UC
{
    public partial class UcFocus : UcPanel
    {
        public UcFocus()
        {
            InitializeComponent();
            //this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            //this.SetStyle(ControlStyles.DoubleBuffer, true);
            //this.SetStyle(ControlStyles.ResizeRedraw, true);
            //this.SetStyle(ControlStyles.Selectable, true);
            //this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            //this.SetStyle(ControlStyles.UserPaint, true);
            Load += UcFocus_Load;
        }

        private void UcFocus_Load(object sender, EventArgs e)
        {
            init = true;
        }

        double max = 0;
        private bool init = false;
        public List<double> datas = new List<double>();
        double current;
        private int level = 1;
        public Bitmap Image
        {
            set
            {
                var temp = value.Clone() as Bitmap;
                Analysis(temp);
                UpdateChart();
            }
        }
        public double Current
        {
            set
            {
                current = value;
            }
            get
            {
                return current;
            }
        }
        void Analysis(Bitmap bmp)
        {
            var focus = ImageProcessing.GetFocusValue(bmp, level);
            Current = focus;
        }
        private void UpdateChart()
        {
            if (!init)
                return;
            this.Invoke(new Action(() =>
            {
                label1.Text = $@"当前值：{current}";
                if (datas.Count > 10)
                {
                    datas.RemoveAt(0);
                }

                datas.Add(current);
                chart1.Series[0].Points.DataBindY(datas.ToArray());
                if (current > Max)
                {
                    Max = current;
                }

                chart1.ChartAreas[0].AxisY.StripLines[0].IntervalOffset = Max;
                chart1.ChartAreas[0].AxisY.StripLines[0].Text = $"最佳值：{Max}";
                if (chart1.ChartAreas[0].AxisY.Maximum < 1.5f * Max)
                    chart1.ChartAreas[0].AxisY.Maximum = 1.5f * Max;
            }));
        }

        public double Max
        {
            get
            {
                return max;
            }
            set
            {
                max = value;
                if (max == 0)
                    chart1.ChartAreas[0].AxisY.Maximum = 1;
            }
        }

        public int Level
        {
            get { return level; }
            set { level = value; }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
        }
    }
}
