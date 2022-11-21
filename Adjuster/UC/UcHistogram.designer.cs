namespace Adjuster.UC
{
    partial class UcHistogram
    {
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.StripLine stripLine1 = new System.Windows.Forms.DataVisualization.Charting.StripLine();
            System.Windows.Forms.DataVisualization.Charting.StripLine stripLine2 = new System.Windows.Forms.DataVisualization.Charting.StripLine();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.lblMin = new System.Windows.Forms.Label();
            this.lblMax = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.rbCount = new System.Windows.Forms.RadioButton();
            this.rbBili = new System.Windows.Forms.RadioButton();
            this.lbVariance = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbStandardDeviation = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbBright = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            this.chart1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chart1.BackColor = System.Drawing.Color.WhiteSmoke;
            chartArea1.AxisX.InterlacedColor = System.Drawing.Color.White;
            chartArea1.AxisX.MajorGrid.Enabled = false;
            chartArea1.AxisX.MajorGrid.Interval = 0D;
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            chartArea1.AxisX.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            chartArea1.AxisX.MajorTickMark.Interval = 0D;
            chartArea1.AxisX.MajorTickMark.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Auto;
            chartArea1.AxisX.MajorTickMark.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            stripLine1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            stripLine1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.VerticalCenter;
            stripLine1.BackSecondaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            stripLine1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            stripLine1.ForeColor = System.Drawing.Color.MediumPurple;
            stripLine1.IntervalOffset = 1D;
            stripLine1.StripWidth = 0.02D;
            stripLine1.Text = "中值";
            stripLine1.TextLineAlignment = System.Drawing.StringAlignment.Center;
            stripLine1.TextOrientation = System.Windows.Forms.DataVisualization.Charting.TextOrientation.Horizontal;
            stripLine2.BackColor = System.Drawing.Color.Yellow;
            stripLine2.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.VerticalCenter;
            stripLine2.BackSecondaryColor = System.Drawing.Color.LimeGreen;
            stripLine2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            stripLine2.ForeColor = System.Drawing.Color.ForestGreen;
            stripLine2.IntervalOffset = 4.5D;
            stripLine2.StripWidth = 0.02D;
            stripLine2.Text = "平均值";
            stripLine2.TextOrientation = System.Windows.Forms.DataVisualization.Charting.TextOrientation.Horizontal;
            chartArea1.AxisX.StripLines.Add(stripLine1);
            chartArea1.AxisX.StripLines.Add(stripLine2);
            chartArea1.AxisX.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 5.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisX.TitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            chartArea1.AxisX2.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
            chartArea1.AxisX2.LineColor = System.Drawing.Color.DimGray;
            chartArea1.AxisX2.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea1.AxisX2.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 5.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisY.MajorGrid.Interval = 0D;
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.Lavender;
            chartArea1.AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            chartArea1.AxisY.MajorTickMark.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            chartArea1.AxisY.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 5.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisY.TitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            chartArea1.AxisY2.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 5.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.BackColor = System.Drawing.Color.WhiteSmoke;
            chartArea1.Name = "ChartArea1";
            chartArea1.ShadowColor = System.Drawing.Color.Gray;
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            legend1.Enabled = false;
            legend1.Name = "Legend1";
            legend1.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(0, 0);
            this.chart1.Margin = new System.Windows.Forms.Padding(2);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            this.chart1.PaletteCustomColors = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))))};
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series1.IsVisibleInLegend = false;
            series1.IsXValueIndexed = true;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(298, 185);
            this.chart1.TabIndex = 1;
            this.chart1.Text = "chart1";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(304, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 10);
            this.label1.TabIndex = 2;
            this.label1.Text = "最小值";
            // 
            // lblMin
            // 
            this.lblMin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMin.BackColor = System.Drawing.SystemColors.Info;
            this.lblMin.Location = new System.Drawing.Point(312, 18);
            this.lblMin.Name = "lblMin";
            this.lblMin.Size = new System.Drawing.Size(30, 10);
            this.lblMin.TabIndex = 3;
            this.lblMin.Text = "0";
            this.lblMin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMax
            // 
            this.lblMax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMax.BackColor = System.Drawing.SystemColors.Info;
            this.lblMax.Location = new System.Drawing.Point(312, 46);
            this.lblMax.Name = "lblMax";
            this.lblMax.Size = new System.Drawing.Size(30, 10);
            this.lblMax.TabIndex = 5;
            this.lblMax.Text = "255";
            this.lblMax.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(304, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 10);
            this.label4.TabIndex = 4;
            this.label4.Text = "最大值";
            // 
            // rbCount
            // 
            this.rbCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbCount.AutoSize = true;
            this.rbCount.Location = new System.Drawing.Point(299, 148);
            this.rbCount.Name = "rbCount";
            this.rbCount.Size = new System.Drawing.Size(43, 14);
            this.rbCount.TabIndex = 6;
            this.rbCount.Text = "数量";
            this.rbCount.UseVisualStyleBackColor = true;
            this.rbCount.Visible = false;
            this.rbCount.CheckedChanged += new System.EventHandler(this.rbMode_CheckedChanged);
            // 
            // rbBili
            // 
            this.rbBili.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbBili.AutoSize = true;
            this.rbBili.Checked = true;
            this.rbBili.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.rbBili.Location = new System.Drawing.Point(299, 168);
            this.rbBili.Name = "rbBili";
            this.rbBili.Size = new System.Drawing.Size(43, 14);
            this.rbBili.TabIndex = 7;
            this.rbBili.TabStop = true;
            this.rbBili.Text = "占比";
            this.rbBili.UseVisualStyleBackColor = true;
            this.rbBili.Visible = false;
            this.rbBili.CheckedChanged += new System.EventHandler(this.rbMode_CheckedChanged);
            // 
            // lbVariance
            // 
            this.lbVariance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbVariance.BackColor = System.Drawing.SystemColors.Info;
            this.lbVariance.Location = new System.Drawing.Point(311, 130);
            this.lbVariance.Name = "lbVariance";
            this.lbVariance.Size = new System.Drawing.Size(30, 10);
            this.lbVariance.TabIndex = 11;
            this.lbVariance.Text = "255";
            this.lbVariance.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbVariance.Visible = false;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(303, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 10);
            this.label3.TabIndex = 10;
            this.label3.Text = "方差";
            this.label3.Visible = false;
            // 
            // lbStandardDeviation
            // 
            this.lbStandardDeviation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbStandardDeviation.BackColor = System.Drawing.SystemColors.Info;
            this.lbStandardDeviation.Location = new System.Drawing.Point(311, 102);
            this.lbStandardDeviation.Name = "lbStandardDeviation";
            this.lbStandardDeviation.Size = new System.Drawing.Size(30, 10);
            this.lbStandardDeviation.TabIndex = 9;
            this.lbStandardDeviation.Text = "0";
            this.lbStandardDeviation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbStandardDeviation.Visible = false;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(303, 88);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 10);
            this.label6.TabIndex = 8;
            this.label6.Text = "标准差";
            this.label6.Visible = false;
            // 
            // lbBright
            // 
            this.lbBright.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbBright.BackColor = System.Drawing.SystemColors.Info;
            this.lbBright.Location = new System.Drawing.Point(312, 74);
            this.lbBright.Name = "lbBright";
            this.lbBright.Size = new System.Drawing.Size(30, 10);
            this.lbBright.TabIndex = 13;
            this.lbBright.Text = "0";
            this.lbBright.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(304, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(25, 10);
            this.label5.TabIndex = 12;
            this.label5.Text = "亮度";
            // 
            // UcHistogram
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(5F, 10F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Controls.Add(this.lbBright);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lbVariance);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbStandardDeviation);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.rbBili);
            this.Controls.Add(this.rbCount);
            this.Controls.Add(this.lblMax);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblMin);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chart1);
            this.Font = new System.Drawing.Font("宋体", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "UcHistogram";
            this.Size = new System.Drawing.Size(345, 185);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblMin;
        private System.Windows.Forms.Label lblMax;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton rbCount;
        private System.Windows.Forms.RadioButton rbBili;
        private System.Windows.Forms.Label lbVariance;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbStandardDeviation;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbBright;
        private System.Windows.Forms.Label label5;
    }
}
