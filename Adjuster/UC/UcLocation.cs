using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Adjuster.UC
{
    public partial class UcLocation : UserControl
    {
        internal class UcLocate : UcPanel
        {
            public UcLocate()
            {
                InitializeComponent();
                this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
                this.SetStyle(ControlStyles.DoubleBuffer, true);
                this.SetStyle(ControlStyles.ResizeRedraw, true);
                this.SetStyle(ControlStyles.Selectable, true);
                this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
                this.SetStyle(ControlStyles.UserPaint, true);
            }
            float xp = 0.0F;
            float yp = 0.0F;
            float ap = 0.1f;
            private bool pass = false;
            protected override void OnPaint(PaintEventArgs e)
            {
                Drawing(e.Graphics);
                base.OnPaint(e);
            }

            private void Drawing(Graphics g)
            {
                if (Width <= 0 || Height <= 0)
                {
                    return;
                }
                g.Clear(BackColor);

                Point xm1 = new Point(0, Height / 2);
                Point xm2 = new Point(Width, Height / 2);
                Point ym1 = new Point(Width / 2, 0);
                Point ym2 = new Point(Width / 2, Height);
                g.DrawLine(Pens.Red, xm1, xm2);
                g.DrawLine(Pens.Red, ym1, ym2);
                if (Xp < -1)
                    Xp = -1;
                if (Yp < -1)
                    Yp = -1;
                if (Xp > 1)
                    Xp = 1;
                if (Yp > 1)
                    Yp = 1;
                SizeF fontSize = g.MeasureString("量", this.Font);
                g.DrawString($"X偏差 : {Xp * 100:0.00}%", this.Font, Brushes.DimGray, new PointF(0, 0));
                g.DrawString($"Y偏差 : {Yp * 100:0.00}%", this.Font, Brushes.DimGray, new PointF(0, 0) + new SizeF(0, fontSize.Height + 3));
                g.DrawString($"阈值 : {Ap * 100:0.00}%", this.Font, Brushes.Green, new PointF(0, 0) + new SizeF(0, 2 * fontSize.Height + 6));
                PointF center = new PointF(Width / 2 * (1 + Xp), Height / 2 * (1 - Yp));
                Pen pen = new Pen(Color.Red);
                SolidBrush brush = new SolidBrush(Color.Red);
                float offset = Width > Height ? (Height / 2) * Ap : (Width / 2) * Ap;
                float sx = Width / 2 - offset;
                float sy = Height / 2 - offset;
                if (Math.Sqrt(Math.Pow(center.X - Width / 2, 2) + Math.Pow(center.Y - Height / 2, 2)) <= offset)
                {
                    pass = true;
                }
                else
                    pass = false;
                if (pass)
                {
                    pen = new Pen(Color.LimeGreen);
                    brush = new SolidBrush(Color.LimeGreen);
                }
                g.DrawLine(pen, center - new SizeF(0, 10), center + new SizeF(0, 10));
                g.DrawLine(pen, center - new SizeF(10, 0), center + new SizeF(10, 0));
                g.FillRectangle(brush, new RectangleF(center - new SizeF(2, 2), new SizeF(4, 4)));

                g.DrawEllipse(pen, new RectangleF(new PointF(sx, sy), new SizeF(offset * 2, offset * 2)));

            }

            public float Xp
            {
                get
                {
                    return xp;
                }

                set
                {
                    if (xp != value)
                    {
                        xp = value;
                        Invalidate();
                    }
                }
            }

            public float Yp
            {
                get
                {
                    return yp;
                }

                set
                {
                    if (yp != value)
                    {
                        yp = value;
                        Invalidate();
                    }
                }
            }

            public float Ap
            {
                get
                {
                    return ap;
                }

                set
                {
                    if (ap != value)
                    {
                        ap = value;
                        Invalidate();
                    }
                }
            }

            #region 设计器

            /// <summary> 
            /// 必需的设计器变量。
            /// </summary>
            private System.ComponentModel.IContainer components = null;

            /// <summary> 
            /// 清理所有正在使用的资源。
            /// </summary>
            /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
            protected override void Dispose(bool disposing)
            {
                if (disposing && (components != null))
                {
                    components.Dispose();
                }
                base.Dispose(disposing);
            }

            #region 组件设计器生成的代码

            /// <summary> 
            /// 设计器支持所需的方法 - 不要修改
            /// 使用代码编辑器修改此方法的内容。
            /// </summary>
            private void InitializeComponent()
            {
                components = new System.ComponentModel.Container();
                //this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            }

            #endregion

            #endregion
        }

        UcLocate ucLocate = new UcLocate();
        double stdx = 0;
        double stdy = 0;
        double currentx = 0;
        double currenty = 0;
        double deltax = 0;
        double deltay = 0;
        double rangex = 100;
        double rangey = 100;
        float acceptThreshold = 0.1f;
        private bool init = false;
        public UcLocation()
        {
            InitializeComponent();
            ucLocate.Dock = DockStyle.Fill;
            ucLocate.BackColor = BackColor;
            panel2.Controls.Add(ucLocate);
            Load += UcLocation_Load;
        }
        private void UcLocation_Load(object sender, EventArgs e)
        {
            init = true;
        }
        public double Stdx
        {
            get { return stdx; }
            set
            {
                stdx = value;
                DataUpdate();
            }
        }

        public double Stdy
        {
            get { return stdy; }
            set
            {
                stdy = value;
                DataUpdate();
            }
        }

        public double Currentx
        {
            get { return currentx; }
            set
            {
                currentx = value;
                DataUpdate();
            }
        }

        public double Currenty
        {
            get { return currenty; }
            set
            {
                currenty = value;
                DataUpdate();
            }
        }


        private void txtXRange_TextChanged(object sender, EventArgs e)
        {
            double.TryParse(txtXRange.Text, out rangex);
            DataUpdate();
        }

        private void txtYRange_TextChanged(object sender, EventArgs e)
        {
            double.TryParse(txtYRange.Text, out rangey);
            DataUpdate();
        }

        private void txtAcceptThreshold_TextChanged(object sender, EventArgs e)
        {
            float.TryParse(txtAcceptThreshold.Text, out acceptThreshold);
            if (acceptThreshold <= 0)
                acceptThreshold = 0;
            if (acceptThreshold >= 1)
                acceptThreshold = 1;
            DataUpdate();
        }

        public void DataUpdate()
        {
            if (!init)
            {
                return;
            }
            this.Invoke(new Action(() =>
            {
                deltax = currentx - stdx;
                deltay = currenty - stdy;
                ucCoordStd.X = stdx;
                ucCoordStd.Y = stdy;

                ucCoordCurrent.X = currentx;
                ucCoordCurrent.Y = currenty;

                ucCoordDelta.X = deltax;
                ucCoordDelta.Y = deltay;
                float xp = (float)deltax / (float)rangex;
                float yp = (float)deltay / (float)rangey;
                ucLocate.Ap = acceptThreshold;
                ucLocate.Xp = xp;
                ucLocate.Yp = yp;
            }));
        }
    }
}
