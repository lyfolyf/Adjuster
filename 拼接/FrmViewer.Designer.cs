namespace 拼接
{
    partial class FrmViewer
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmViewer));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblMsg = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSn = new System.Windows.Forms.TextBox();
            this.btnReflesh = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.btnSetting = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbProducts = new System.Windows.Forms.ComboBox();
            this.btnSetPath = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.cbRule = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbRes1_8 = new System.Windows.Forms.RadioButton();
            this.rbRes1_4 = new System.Windows.Forms.RadioButton();
            this.rbRes1_2 = new System.Windows.Forms.RadioButton();
            this.rbRes1 = new System.Windows.Forms.RadioButton();
            this.ucAreaSelect1 = new 拼接.UcAreaSelect();
            this.panel2 = new System.Windows.Forms.Panel();
            this.viewer1 = new 拼接.AdvancedViewer();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Jpg文件|*.jpg|bmp文件|*.bmp";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 500F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1460, 722);
            this.tableLayoutPanel1.TabIndex = 72;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblMsg);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.txtSn);
            this.panel1.Controls.Add(this.btnReflesh);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.btnSetting);
            this.panel1.Controls.Add(this.listBox1);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.cbProducts);
            this.panel1.Controls.Add(this.btnSetPath);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtPath);
            this.panel1.Controls.Add(this.cbRule);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.ucAreaSelect1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(494, 716);
            this.panel1.TabIndex = 0;
            // 
            // lblMsg
            // 
            this.lblMsg.Location = new System.Drawing.Point(2, 312);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(486, 47);
            this.lblMsg.TabIndex = 99;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(26, 452);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(25, 17);
            this.label7.TabIndex = 98;
            this.label7.Text = "SN";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel4.Location = new System.Drawing.Point(2, 311);
            this.panel4.Margin = new System.Windows.Forms.Padding(0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(489, 1);
            this.panel4.TabIndex = 90;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(223, 450);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(59, 23);
            this.btnSearch.TabIndex = 92;
            this.btnSearch.Text = "查找";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSn
            // 
            this.txtSn.Location = new System.Drawing.Point(60, 449);
            this.txtSn.Name = "txtSn";
            this.txtSn.Size = new System.Drawing.Size(137, 23);
            this.txtSn.TabIndex = 91;
            // 
            // btnReflesh
            // 
            this.btnReflesh.Location = new System.Drawing.Point(370, 371);
            this.btnReflesh.Name = "btnReflesh";
            this.btnReflesh.Size = new System.Drawing.Size(59, 23);
            this.btnReflesh.TabIndex = 90;
            this.btnReflesh.Text = "刷新";
            this.btnReflesh.UseVisualStyleBackColor = true;
            this.btnReflesh.Click += new System.EventHandler(this.btnReflesh_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel3.Location = new System.Drawing.Point(2, 362);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(489, 1);
            this.panel3.TabIndex = 89;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(389, 457);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(87, 38);
            this.button2.TabIndex = 88;
            this.button2.Text = "堆叠显示";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnSetting
            // 
            this.btnSetting.Location = new System.Drawing.Point(389, 413);
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Size = new System.Drawing.Size(87, 25);
            this.btnSetting.TabIndex = 87;
            this.btnSetting.Text = "设置";
            this.btnSetting.UseVisualStyleBackColor = true;
            this.btnSetting.Click += new System.EventHandler(this.btnSetting_Click);
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox1.Font = new System.Drawing.Font("微软雅黑", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(10, 531);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(478, 180);
            this.listBox1.TabIndex = 86;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(207, 512);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 17);
            this.label8.TabIndex = 85;
            this.label8.Text = "找到0个图像";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(63, 430);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 17);
            this.label6.TabIndex = 83;
            this.label6.Text = "共0个文件夹";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 408);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 17);
            this.label5.TabIndex = 82;
            this.label5.Text = "产品";
            // 
            // cbProducts
            // 
            this.cbProducts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProducts.FormattingEnabled = true;
            this.cbProducts.Location = new System.Drawing.Point(60, 404);
            this.cbProducts.Name = "cbProducts";
            this.cbProducts.Size = new System.Drawing.Size(222, 25);
            this.cbProducts.TabIndex = 81;
            this.cbProducts.SelectedIndexChanged += new System.EventHandler(this.cbProducts_SelectedIndexChanged);
            // 
            // btnSetPath
            // 
            this.btnSetPath.Location = new System.Drawing.Point(430, 371);
            this.btnSetPath.Name = "btnSetPath";
            this.btnSetPath.Size = new System.Drawing.Size(59, 23);
            this.btnSetPath.TabIndex = 80;
            this.btnSetPath.Text = "选择";
            this.btnSetPath.UseVisualStyleBackColor = true;
            this.btnSetPath.Click += new System.EventHandler(this.btnSetPath_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 482);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 17);
            this.label3.TabIndex = 78;
            this.label3.Text = "规则";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 374);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 17);
            this.label2.TabIndex = 77;
            this.label2.Text = "图像路径";
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(61, 371);
            this.txtPath.Name = "txtPath";
            this.txtPath.ReadOnly = true;
            this.txtPath.Size = new System.Drawing.Size(306, 23);
            this.txtPath.TabIndex = 76;
            this.txtPath.Text = "D:\\Images";
            // 
            // cbRule
            // 
            this.cbRule.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRule.FormattingEnabled = true;
            this.cbRule.Location = new System.Drawing.Point(60, 478);
            this.cbRule.Name = "cbRule";
            this.cbRule.Size = new System.Drawing.Size(222, 25);
            this.cbRule.TabIndex = 74;
            this.cbRule.SelectedIndexChanged += new System.EventHandler(this.cbRule_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbRes1_8);
            this.groupBox2.Controls.Add(this.rbRes1_4);
            this.groupBox2.Controls.Add(this.rbRes1_2);
            this.groupBox2.Controls.Add(this.rbRes1);
            this.groupBox2.Location = new System.Drawing.Point(288, 400);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(95, 107);
            this.groupBox2.TabIndex = 72;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "分辨率";
            // 
            // rbRes1_8
            // 
            this.rbRes1_8.AutoSize = true;
            this.rbRes1_8.Location = new System.Drawing.Point(9, 83);
            this.rbRes1_8.Name = "rbRes1_8";
            this.rbRes1_8.Size = new System.Drawing.Size(77, 21);
            this.rbRes1_8.TabIndex = 3;
            this.rbRes1_8.Text = "1/8 * 1/8";
            this.rbRes1_8.UseVisualStyleBackColor = true;
            this.rbRes1_8.CheckedChanged += new System.EventHandler(this.rbRes1_8_CheckedChanged);
            // 
            // rbRes1_4
            // 
            this.rbRes1_4.AutoSize = true;
            this.rbRes1_4.Location = new System.Drawing.Point(9, 61);
            this.rbRes1_4.Name = "rbRes1_4";
            this.rbRes1_4.Size = new System.Drawing.Size(77, 21);
            this.rbRes1_4.TabIndex = 2;
            this.rbRes1_4.Text = "1/4 * 1/4";
            this.rbRes1_4.UseVisualStyleBackColor = true;
            this.rbRes1_4.CheckedChanged += new System.EventHandler(this.rbRes1_4_CheckedChanged);
            // 
            // rbRes1_2
            // 
            this.rbRes1_2.AutoSize = true;
            this.rbRes1_2.Location = new System.Drawing.Point(9, 39);
            this.rbRes1_2.Name = "rbRes1_2";
            this.rbRes1_2.Size = new System.Drawing.Size(77, 21);
            this.rbRes1_2.TabIndex = 1;
            this.rbRes1_2.Text = "1/2 * 1/2";
            this.rbRes1_2.UseVisualStyleBackColor = true;
            this.rbRes1_2.CheckedChanged += new System.EventHandler(this.rbRes1_2_CheckedChanged);
            // 
            // rbRes1
            // 
            this.rbRes1.AutoSize = true;
            this.rbRes1.Checked = true;
            this.rbRes1.Location = new System.Drawing.Point(9, 17);
            this.rbRes1.Name = "rbRes1";
            this.rbRes1.Size = new System.Drawing.Size(53, 21);
            this.rbRes1.TabIndex = 0;
            this.rbRes1.TabStop = true;
            this.rbRes1.Text = "1 * 1";
            this.rbRes1.UseVisualStyleBackColor = true;
            this.rbRes1.CheckedChanged += new System.EventHandler(this.rbRes1_CheckedChanged);
            // 
            // ucAreaSelect1
            // 
            this.ucAreaSelect1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ucAreaSelect1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ucAreaSelect1.HCount = 3;
            this.ucAreaSelect1.HighlightColor = System.Drawing.Color.Yellow;
            this.ucAreaSelect1.HighlightTransparency = ((byte)(100));
            this.ucAreaSelect1.LineColor = System.Drawing.Color.Yellow;
            this.ucAreaSelect1.Location = new System.Drawing.Point(0, 0);
            this.ucAreaSelect1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ucAreaSelect1.Name = "ucAreaSelect1";
            this.ucAreaSelect1.ShowBlock = true;
            this.ucAreaSelect1.Size = new System.Drawing.Size(488, 307);
            this.ucAreaSelect1.TabIndex = 70;
            this.ucAreaSelect1.VCount = 4;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.viewer1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(503, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(954, 716);
            this.panel2.TabIndex = 1;
            // 
            // viewer1
            // 
            this.viewer1.AutoFit = true;
            this.viewer1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.viewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewer1.Image = null;
            this.viewer1.Location = new System.Drawing.Point(0, 0);
            this.viewer1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.viewer1.Name = "viewer1";
            this.viewer1.Size = new System.Drawing.Size(954, 716);
            this.viewer1.TabIndex = 0;
            // 
            // FrmViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1460, 722);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmViewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "查看 - 17";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private AdvancedViewer viewer1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private UcAreaSelect ucAreaSelect1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbRes1_4;
        private System.Windows.Forms.RadioButton rbRes1_2;
        private System.Windows.Forms.RadioButton rbRes1;
        private System.Windows.Forms.RadioButton rbRes1_8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbProducts;
        private System.Windows.Forms.Button btnSetPath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.ComboBox cbRule;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button btnSetting;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnReflesh;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSn;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblMsg;
    }
}

