
namespace 拼接
{
    partial class FrmRuleManagement
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDelRule = new System.Windows.Forms.Button();
            this.btnAddNewRule = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.ucAreaSelect1 = new 拼接.UcAreaSelect();
            this.txtHCount = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtVCount = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRuleName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnAppayToBlock = new System.Windows.Forms.Button();
            this.cbRotate = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtBlockDispName = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtNewKeywork = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnDelKeywork = new System.Windows.Forms.Button();
            this.btnAddNewKeywork = new System.Windows.Forms.Button();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.btnApply = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAddNewKeyworkToAllBlock = new System.Windows.Forms.Button();
            this.btnDelKeyworkAll = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.btnDelRule);
            this.groupBox1.Controls.Add(this.btnAddNewRule);
            this.groupBox1.Controls.Add(this.listBox1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(322, 486);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "规则列表";
            // 
            // btnDelRule
            // 
            this.btnDelRule.Location = new System.Drawing.Point(171, 438);
            this.btnDelRule.Name = "btnDelRule";
            this.btnDelRule.Size = new System.Drawing.Size(111, 34);
            this.btnDelRule.TabIndex = 2;
            this.btnDelRule.Text = "删除规则";
            this.btnDelRule.UseVisualStyleBackColor = true;
            this.btnDelRule.Click += new System.EventHandler(this.btnDelteRule_Click);
            // 
            // btnAddNewRule
            // 
            this.btnAddNewRule.Location = new System.Drawing.Point(26, 438);
            this.btnAddNewRule.Name = "btnAddNewRule";
            this.btnAddNewRule.Size = new System.Drawing.Size(111, 34);
            this.btnAddNewRule.TabIndex = 1;
            this.btnAddNewRule.Text = "添加规则";
            this.btnAddNewRule.UseVisualStyleBackColor = true;
            this.btnAddNewRule.Click += new System.EventHandler(this.btnAddNewRule_Click);
            // 
            // listBox1
            // 
            this.listBox1.DisplayMember = "Name";
            this.listBox1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 21;
            this.listBox1.Location = new System.Drawing.Point(6, 20);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(310, 403);
            this.listBox1.TabIndex = 0;
            this.listBox1.ValueMember = "Name";
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // ucAreaSelect1
            // 
            this.ucAreaSelect1.BackColor = System.Drawing.Color.Silver;
            this.ucAreaSelect1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ucAreaSelect1.HCount = 1;
            this.ucAreaSelect1.HighlightColor = System.Drawing.Color.Yellow;
            this.ucAreaSelect1.HighlightTransparency = ((byte)(100));
            this.ucAreaSelect1.LineColor = System.Drawing.Color.Gold;
            this.ucAreaSelect1.Location = new System.Drawing.Point(20, 41);
            this.ucAreaSelect1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ucAreaSelect1.Name = "ucAreaSelect1";
            this.ucAreaSelect1.ShowBlock = true;
            this.ucAreaSelect1.Size = new System.Drawing.Size(327, 250);
            this.ucAreaSelect1.TabIndex = 27;
            this.ucAreaSelect1.VCount = 1;
            // 
            // txtHCount
            // 
            this.txtHCount.Location = new System.Drawing.Point(77, 420);
            this.txtHCount.Name = "txtHCount";
            this.txtHCount.Size = new System.Drawing.Size(128, 21);
            this.txtHCount.TabIndex = 26;
            this.txtHCount.Text = "1";
            this.txtHCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 371);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 25;
            this.label3.Text = "堆叠列数";
            // 
            // txtVCount
            // 
            this.txtVCount.Location = new System.Drawing.Point(77, 368);
            this.txtVCount.Name = "txtVCount";
            this.txtVCount.Size = new System.Drawing.Size(128, 21);
            this.txtVCount.TabIndex = 24;
            this.txtVCount.Text = "1";
            this.txtVCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 423);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 23;
            this.label2.Text = "堆叠行数";
            // 
            // txtRuleName
            // 
            this.txtRuleName.Location = new System.Drawing.Point(77, 316);
            this.txtRuleName.Name = "txtRuleName";
            this.txtRuleName.Size = new System.Drawing.Size(128, 21);
            this.txtRuleName.TabIndex = 22;
            this.txtRuleName.Text = "DH均匀光";
            this.txtRuleName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 319);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 21;
            this.label1.Text = "规则名称";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.btnApply);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.ucAreaSelect1);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtHCount);
            this.groupBox2.Controls.Add(this.txtRuleName);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtVCount);
            this.groupBox2.Location = new System.Drawing.Point(341, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(665, 486);
            this.groupBox2.TabIndex = 28;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "详细";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnAppayToBlock);
            this.groupBox4.Controls.Add(this.cbRotate);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.txtBlockDispName);
            this.groupBox4.Controls.Add(this.groupBox3);
            this.groupBox4.Location = new System.Drawing.Point(363, 22);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(302, 458);
            this.groupBox4.TabIndex = 31;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "区域详细";
            // 
            // btnAppayToBlock
            // 
            this.btnAppayToBlock.Location = new System.Drawing.Point(245, 393);
            this.btnAppayToBlock.Name = "btnAppayToBlock";
            this.btnAppayToBlock.Size = new System.Drawing.Size(45, 55);
            this.btnAppayToBlock.TabIndex = 87;
            this.btnAppayToBlock.Text = "应用修改";
            this.btnAppayToBlock.UseVisualStyleBackColor = true;
            this.btnAppayToBlock.Click += new System.EventHandler(this.btnAppayToBlock_Click);
            // 
            // cbRotate
            // 
            this.cbRotate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRotate.FormattingEnabled = true;
            this.cbRotate.Location = new System.Drawing.Point(99, 428);
            this.cbRotate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbRotate.Name = "cbRotate";
            this.cbRotate.Size = new System.Drawing.Size(140, 20);
            this.cbRotate.TabIndex = 86;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 431);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 12);
            this.label7.TabIndex = 33;
            this.label7.Text = "图片旋转\\翻转";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 395);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 31;
            this.label6.Text = "显示名称";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // txtBlockDispName
            // 
            this.txtBlockDispName.Location = new System.Drawing.Point(99, 392);
            this.txtBlockDispName.Name = "txtBlockDispName";
            this.txtBlockDispName.Size = new System.Drawing.Size(140, 21);
            this.txtBlockDispName.TabIndex = 32;
            this.txtBlockDispName.Text = "1_1";
            this.txtBlockDispName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnDelKeyworkAll);
            this.groupBox3.Controls.Add(this.btnAddNewKeyworkToAllBlock);
            this.groupBox3.Controls.Add(this.txtNewKeywork);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.btnDelKeywork);
            this.groupBox3.Controls.Add(this.btnAddNewKeywork);
            this.groupBox3.Controls.Add(this.listBox2);
            this.groupBox3.Location = new System.Drawing.Point(6, 20);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(290, 366);
            this.groupBox3.TabIndex = 30;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "区域关键词列表";
            // 
            // txtNewKeywork
            // 
            this.txtNewKeywork.Location = new System.Drawing.Point(9, 295);
            this.txtNewKeywork.Name = "txtNewKeywork";
            this.txtNewKeywork.Size = new System.Drawing.Size(177, 21);
            this.txtNewKeywork.TabIndex = 33;
            this.txtNewKeywork.Text = "DH";
            this.txtNewKeywork.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(6, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(268, 38);
            this.label5.TabIndex = 29;
            this.label5.Text = "通过区域关键词会搜索返回第一个匹配到的图片文件";
            // 
            // btnDelKeywork
            // 
            this.btnDelKeywork.Location = new System.Drawing.Point(192, 326);
            this.btnDelKeywork.Name = "btnDelKeywork";
            this.btnDelKeywork.Size = new System.Drawing.Size(82, 26);
            this.btnDelKeywork.TabIndex = 2;
            this.btnDelKeywork.Text = "删除关键词";
            this.btnDelKeywork.UseVisualStyleBackColor = true;
            this.btnDelKeywork.Click += new System.EventHandler(this.btnDelKeywork_Click);
            // 
            // btnAddNewKeywork
            // 
            this.btnAddNewKeywork.Location = new System.Drawing.Point(192, 294);
            this.btnAddNewKeywork.Name = "btnAddNewKeywork";
            this.btnAddNewKeywork.Size = new System.Drawing.Size(82, 26);
            this.btnAddNewKeywork.TabIndex = 1;
            this.btnAddNewKeywork.Text = "添加关键词";
            this.btnAddNewKeywork.UseVisualStyleBackColor = true;
            this.btnAddNewKeywork.Click += new System.EventHandler(this.btnAddNewKeywork_Click);
            // 
            // listBox2
            // 
            this.listBox2.DisplayMember = "Name";
            this.listBox2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 21;
            this.listBox2.Location = new System.Drawing.Point(6, 66);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(278, 214);
            this.listBox2.TabIndex = 0;
            this.listBox2.ValueMember = "Name";
            this.listBox2.SelectedIndexChanged += new System.EventHandler(this.listBox2_SelectedIndexChanged);
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(245, 316);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(102, 33);
            this.btnApply.TabIndex = 29;
            this.btnApply.Text = "应用修改";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(20, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(176, 17);
            this.label4.TabIndex = 28;
            this.label4.Text = "点击对应区域可编辑区域关键词";
            // 
            // btnAddNewKeyworkToAllBlock
            // 
            this.btnAddNewKeyworkToAllBlock.Location = new System.Drawing.Point(9, 326);
            this.btnAddNewKeyworkToAllBlock.Name = "btnAddNewKeyworkToAllBlock";
            this.btnAddNewKeyworkToAllBlock.Size = new System.Drawing.Size(82, 26);
            this.btnAddNewKeyworkToAllBlock.TabIndex = 34;
            this.btnAddNewKeyworkToAllBlock.Text = "添加至所有";
            this.btnAddNewKeyworkToAllBlock.UseVisualStyleBackColor = true;
            this.btnAddNewKeyworkToAllBlock.Click += new System.EventHandler(this.btnAddNewKeyworkToAllBlock_Click);
            // 
            // btnDelKeyworkAll
            // 
            this.btnDelKeyworkAll.Location = new System.Drawing.Point(97, 325);
            this.btnDelKeyworkAll.Name = "btnDelKeyworkAll";
            this.btnDelKeyworkAll.Size = new System.Drawing.Size(89, 26);
            this.btnDelKeyworkAll.TabIndex = 35;
            this.btnDelKeyworkAll.Text = "从所有中删除";
            this.btnDelKeyworkAll.UseVisualStyleBackColor = true;
            this.btnDelKeyworkAll.Click += new System.EventHandler(this.btnDelKeyworkAll_Click);
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(286, 443);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(28, 27);
            this.label8.TabIndex = 3;
            this.label8.Text = "☺";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // FrmRuleManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1011, 515);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmRuleManagement";
            this.Text = "堆叠规则管理";
            this.Load += new System.EventHandler(this.FrmRuleManagement_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button btnDelRule;
        private System.Windows.Forms.Button btnAddNewRule;
        private UcAreaSelect ucAreaSelect1;
        private System.Windows.Forms.TextBox txtHCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtVCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtRuleName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnDelKeywork;
        private System.Windows.Forms.Button btnAddNewKeywork;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtBlockDispName;
        private System.Windows.Forms.ComboBox cbRotate;
        private System.Windows.Forms.Button btnAppayToBlock;
        private System.Windows.Forms.TextBox txtNewKeywork;
        private System.Windows.Forms.Button btnAddNewKeyworkToAllBlock;
        private System.Windows.Forms.Button btnDelKeyworkAll;
        private System.Windows.Forms.Label label8;
    }
}