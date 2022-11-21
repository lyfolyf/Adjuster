
namespace 拼接
{
    partial class FrmSetting
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
            this.txtDefectType = new System.Windows.Forms.TextBox();
            this.btnSetCameraRotate = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCamPos = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUdX = new System.Windows.Forms.NumericUpDown();
            this.numericUdY = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSet = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cbSurface = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.numericUdVcount = new System.Windows.Forms.NumericUpDown();
            this.numericUdHcount = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.ucAreaSelect1 = new 拼接.UcAreaSelect();
            this.cbDefectTypes = new System.Windows.Forms.ComboBox();
            this.btnDelDefectType = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUdX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUdY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUdVcount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUdHcount)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDelDefectType);
            this.groupBox1.Controls.Add(this.cbDefectTypes);
            this.groupBox1.Controls.Add(this.txtDefectType);
            this.groupBox1.Controls.Add(this.btnSetCameraRotate);
            this.groupBox1.Location = new System.Drawing.Point(2, 13);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(554, 67);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "缺陷类型设置";
            // 
            // txtDefectType
            // 
            this.txtDefectType.Location = new System.Drawing.Point(10, 27);
            this.txtDefectType.Name = "txtDefectType";
            this.txtDefectType.Size = new System.Drawing.Size(155, 23);
            this.txtDefectType.TabIndex = 88;
            this.txtDefectType.Text = "Dent";
            // 
            // btnSetCameraRotate
            // 
            this.btnSetCameraRotate.Location = new System.Drawing.Point(185, 25);
            this.btnSetCameraRotate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSetCameraRotate.Name = "btnSetCameraRotate";
            this.btnSetCameraRotate.Size = new System.Drawing.Size(69, 26);
            this.btnSetCameraRotate.TabIndex = 87;
            this.btnSetCameraRotate.Text = "新增类型";
            this.btnSetCameraRotate.UseVisualStyleBackColor = true;
            this.btnSetCameraRotate.Click += new System.EventHandler(this.btnSetCameraRotate_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtCamPos);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.numericUdX);
            this.groupBox2.Controls.Add(this.numericUdY);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.btnSet);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.cbSurface);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.numericUdVcount);
            this.groupBox2.Controls.Add(this.numericUdHcount);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.ucAreaSelect1);
            this.groupBox2.Location = new System.Drawing.Point(2, 88);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(554, 341);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "图像分布设置";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(396, 195);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 17);
            this.label7.TabIndex = 94;
            this.label7.Text = "CAM_POS";
            // 
            // txtCamPos
            // 
            this.txtCamPos.Location = new System.Drawing.Point(467, 192);
            this.txtCamPos.Name = "txtCamPos";
            this.txtCamPos.Size = new System.Drawing.Size(66, 23);
            this.txtCamPos.TabIndex = 93;
            this.txtCamPos.Text = "1_4";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(441, 154);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 17);
            this.label4.TabIndex = 89;
            this.label4.Text = "纵";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // numericUdX
            // 
            this.numericUdX.Location = new System.Drawing.Point(467, 152);
            this.numericUdX.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUdX.Name = "numericUdX";
            this.numericUdX.Size = new System.Drawing.Size(66, 23);
            this.numericUdX.TabIndex = 92;
            this.numericUdX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUdX.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUdX.ValueChanged += new System.EventHandler(this.NumericUdXY_ValueChanged);
            // 
            // numericUdY
            // 
            this.numericUdY.Location = new System.Drawing.Point(467, 123);
            this.numericUdY.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUdY.Name = "numericUdY";
            this.numericUdY.Size = new System.Drawing.Size(66, 23);
            this.numericUdY.TabIndex = 90;
            this.numericUdY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUdY.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUdY.ValueChanged += new System.EventHandler(this.NumericUdXY_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(441, 125);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(20, 17);
            this.label6.TabIndex = 91;
            this.label6.Text = "横";
            // 
            // btnSet
            // 
            this.btnSet.Location = new System.Drawing.Point(467, 222);
            this.btnSet.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSet.Name = "btnSet";
            this.btnSet.Size = new System.Drawing.Size(69, 26);
            this.btnSet.TabIndex = 88;
            this.btnSet.Text = "设置";
            this.btnSet.UseVisualStyleBackColor = true;
            this.btnSet.Click += new System.EventHandler(this.btnSet_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 17);
            this.label3.TabIndex = 80;
            this.label3.Text = "检测面";
            // 
            // cbSurface
            // 
            this.cbSurface.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSurface.FormattingEnabled = true;
            this.cbSurface.Location = new System.Drawing.Point(55, 23);
            this.cbSurface.Name = "cbSurface";
            this.cbSurface.Size = new System.Drawing.Size(222, 25);
            this.cbSurface.TabIndex = 79;
            this.cbSurface.SelectedIndexChanged += new System.EventHandler(this.cbSurface_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(383, 58);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(44, 17);
            this.label12.TabIndex = 70;
            this.label12.Text = "相机数";
            // 
            // numericUdVcount
            // 
            this.numericUdVcount.Location = new System.Drawing.Point(433, 83);
            this.numericUdVcount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUdVcount.Name = "numericUdVcount";
            this.numericUdVcount.Size = new System.Drawing.Size(66, 23);
            this.numericUdVcount.TabIndex = 73;
            this.numericUdVcount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUdVcount.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numericUdVcount.ValueChanged += new System.EventHandler(this.numericUdVcount_ValueChanged);
            // 
            // numericUdHcount
            // 
            this.numericUdHcount.Location = new System.Drawing.Point(433, 56);
            this.numericUdHcount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUdHcount.Name = "numericUdHcount";
            this.numericUdHcount.Size = new System.Drawing.Size(66, 23);
            this.numericUdHcount.TabIndex = 71;
            this.numericUdHcount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUdHcount.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUdHcount.ValueChanged += new System.EventHandler(this.numericUdHcount_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(383, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 17);
            this.label2.TabIndex = 72;
            this.label2.Text = "点位数";
            // 
            // ucAreaSelect1
            // 
            this.ucAreaSelect1.BackColor = System.Drawing.Color.Silver;
            this.ucAreaSelect1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ucAreaSelect1.HCount = 3;
            this.ucAreaSelect1.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.ucAreaSelect1.HighlightTransparency = ((byte)(100));
            this.ucAreaSelect1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.ucAreaSelect1.Location = new System.Drawing.Point(8, 56);
            this.ucAreaSelect1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ucAreaSelect1.Name = "ucAreaSelect1";
            this.ucAreaSelect1.ShowDefect = false;
            this.ucAreaSelect1.Size = new System.Drawing.Size(369, 275);
            this.ucAreaSelect1.TabIndex = 0;
            this.ucAreaSelect1.VCount = 4;
            // 
            // cbDefectTypes
            // 
            this.cbDefectTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDefectTypes.FormattingEnabled = true;
            this.cbDefectTypes.Location = new System.Drawing.Point(277, 26);
            this.cbDefectTypes.Name = "cbDefectTypes";
            this.cbDefectTypes.Size = new System.Drawing.Size(206, 25);
            this.cbDefectTypes.TabIndex = 89;
            // 
            // btnDelDefectType
            // 
            this.btnDelDefectType.Location = new System.Drawing.Point(489, 25);
            this.btnDelDefectType.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDelDefectType.Name = "btnDelDefectType";
            this.btnDelDefectType.Size = new System.Drawing.Size(56, 26);
            this.btnDelDefectType.TabIndex = 90;
            this.btnDelDefectType.Text = "删除";
            this.btnDelDefectType.UseVisualStyleBackColor = true;
            this.btnDelDefectType.Click += new System.EventHandler(this.btnDelDefectType_Click);
            // 
            // FrmSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 432);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmSetting";
            this.Text = "FrmSetting";
            this.Load += new System.EventHandler(this.FrmSetting_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUdX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUdY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUdVcount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUdHcount)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSetCameraRotate;
        private System.Windows.Forms.GroupBox groupBox2;
        private UcAreaSelect ucAreaSelect1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown numericUdVcount;
        private System.Windows.Forms.NumericUpDown numericUdHcount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUdX;
        private System.Windows.Forms.NumericUpDown numericUdY;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnSet;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbSurface;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCamPos;
        private System.Windows.Forms.TextBox txtDefectType;
        private System.Windows.Forms.Button btnDelDefectType;
        private System.Windows.Forms.ComboBox cbDefectTypes;
    }
}