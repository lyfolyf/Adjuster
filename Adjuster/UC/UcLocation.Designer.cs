namespace Adjuster.UC
{
    partial class UcLocation
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtAcceptThreshold = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtYRange = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtXRange = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ucCoordStd = new Adjuster.UC.UcCoord();
            this.ucCoordCurrent = new Adjuster.UC.UcCoord();
            this.ucCoordDelta = new Adjuster.UC.UcCoord();
            this.groupBox3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.txtAcceptThreshold);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.txtYRange);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.txtXRange);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Font = new System.Drawing.Font("宋体", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(142, 100);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "设置";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(2, 71);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 10);
            this.label8.TabIndex = 9;
            this.label8.Text = "容许范围（0~1）";
            // 
            // txtAcceptThreshold
            // 
            this.txtAcceptThreshold.Font = new System.Drawing.Font("宋体", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtAcceptThreshold.Location = new System.Drawing.Point(92, 69);
            this.txtAcceptThreshold.Margin = new System.Windows.Forms.Padding(2);
            this.txtAcceptThreshold.Name = "txtAcceptThreshold";
            this.txtAcceptThreshold.Size = new System.Drawing.Size(41, 19);
            this.txtAcceptThreshold.TabIndex = 8;
            this.txtAcceptThreshold.Text = "0.1";
            this.txtAcceptThreshold.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtAcceptThreshold.TextChanged += new System.EventHandler(this.txtAcceptThreshold_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(2, 47);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 10);
            this.label7.TabIndex = 7;
            this.label7.Text = "Y 最大范围";
            // 
            // txtYRange
            // 
            this.txtYRange.Font = new System.Drawing.Font("宋体", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtYRange.Location = new System.Drawing.Point(63, 42);
            this.txtYRange.Margin = new System.Windows.Forms.Padding(2);
            this.txtYRange.Name = "txtYRange";
            this.txtYRange.Size = new System.Drawing.Size(71, 19);
            this.txtYRange.TabIndex = 6;
            this.txtYRange.Text = "100";
            this.txtYRange.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtYRange.TextChanged += new System.EventHandler(this.txtYRange_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(2, 21);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 10);
            this.label6.TabIndex = 5;
            this.label6.Text = "X 最大范围";
            // 
            // txtXRange
            // 
            this.txtXRange.Font = new System.Drawing.Font("宋体", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtXRange.Location = new System.Drawing.Point(63, 17);
            this.txtXRange.Margin = new System.Windows.Forms.Padding(2);
            this.txtXRange.Name = "txtXRange";
            this.txtXRange.Size = new System.Drawing.Size(71, 19);
            this.txtXRange.TabIndex = 4;
            this.txtXRange.Text = "100";
            this.txtXRange.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtXRange.TextChanged += new System.EventHandler(this.txtXRange_TextChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 142F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.ucCoordStd, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.ucCoordCurrent, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.ucCoordDelta, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(386, 222);
            this.tableLayoutPanel1.TabIndex = 18;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(142, 100);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Font = new System.Drawing.Font("宋体", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel2.Location = new System.Drawing.Point(144, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.panel2.Name = "panel2";
            this.tableLayoutPanel1.SetRowSpan(this.panel2, 4);
            this.panel2.Size = new System.Drawing.Size(242, 222);
            this.panel2.TabIndex = 1;
            // 
            // ucCoordStd
            // 
            this.ucCoordStd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucCoordStd.BackColor = System.Drawing.Color.DarkGray;
            this.ucCoordStd.Description = "标准位置";
            this.ucCoordStd.Font = new System.Drawing.Font("楷体", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucCoordStd.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.ucCoordStd.Location = new System.Drawing.Point(2, 102);
            this.ucCoordStd.Margin = new System.Windows.Forms.Padding(2);
            this.ucCoordStd.Name = "ucCoordStd";
            this.ucCoordStd.Radius = 2;
            this.ucCoordStd.Size = new System.Drawing.Size(138, 36);
            this.ucCoordStd.TabIndex = 0;
            this.ucCoordStd.X = 0D;
            this.ucCoordStd.Y = 0D;
            // 
            // ucCoordCurrent
            // 
            this.ucCoordCurrent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucCoordCurrent.BackColor = System.Drawing.Color.DarkGray;
            this.ucCoordCurrent.Description = "当前位置";
            this.ucCoordCurrent.Font = new System.Drawing.Font("楷体", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucCoordCurrent.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.ucCoordCurrent.Location = new System.Drawing.Point(2, 142);
            this.ucCoordCurrent.Margin = new System.Windows.Forms.Padding(2);
            this.ucCoordCurrent.Name = "ucCoordCurrent";
            this.ucCoordCurrent.Radius = 2;
            this.ucCoordCurrent.Size = new System.Drawing.Size(138, 36);
            this.ucCoordCurrent.TabIndex = 1;
            this.ucCoordCurrent.X = 0D;
            this.ucCoordCurrent.Y = 0D;
            // 
            // ucCoordDelta
            // 
            this.ucCoordDelta.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucCoordDelta.BackColor = System.Drawing.Color.DarkGray;
            this.ucCoordDelta.Description = "位置偏差";
            this.ucCoordDelta.Font = new System.Drawing.Font("楷体", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucCoordDelta.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.ucCoordDelta.Location = new System.Drawing.Point(2, 182);
            this.ucCoordDelta.Margin = new System.Windows.Forms.Padding(2);
            this.ucCoordDelta.Name = "ucCoordDelta";
            this.ucCoordDelta.Radius = 2;
            this.ucCoordDelta.Size = new System.Drawing.Size(138, 38);
            this.ucCoordDelta.TabIndex = 2;
            this.ucCoordDelta.X = 0D;
            this.ucCoordDelta.Y = 0D;
            // 
            // UcLocation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(5F, 10F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("宋体", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "UcLocation";
            this.Size = new System.Drawing.Size(386, 222);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private UcCoord ucCoordStd;
        private UcCoord ucCoordCurrent;
        private UcCoord ucCoordDelta;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtAcceptThreshold;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtYRange;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtXRange;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}
