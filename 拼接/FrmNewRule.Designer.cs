
namespace 拼接
{
    partial class FrmNewRule
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.txtHCount = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtVCount = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRuleName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ucAreaSelect1 = new 拼接.UcAreaSelect();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(352, 203);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 33);
            this.btnCancel.TabIndex = 19;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(472, 203);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(80, 33);
            this.btnApply.TabIndex = 18;
            this.btnApply.Text = "确认";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // txtHCount
            // 
            this.txtHCount.Location = new System.Drawing.Point(424, 140);
            this.txtHCount.Name = "txtHCount";
            this.txtHCount.Size = new System.Drawing.Size(128, 21);
            this.txtHCount.TabIndex = 15;
            this.txtHCount.Text = "1";
            this.txtHCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtHCount.TextChanged += new System.EventHandler(this.txtHCount_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(365, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 14;
            this.label3.Text = "堆叠列数";
            // 
            // txtVCount
            // 
            this.txtVCount.Location = new System.Drawing.Point(424, 88);
            this.txtVCount.Name = "txtVCount";
            this.txtVCount.Size = new System.Drawing.Size(128, 21);
            this.txtVCount.TabIndex = 13;
            this.txtVCount.Text = "1";
            this.txtVCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtVCount.TextChanged += new System.EventHandler(this.txtVCount_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(365, 143);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 12;
            this.label2.Text = "堆叠行数";
            // 
            // txtRuleName
            // 
            this.txtRuleName.Location = new System.Drawing.Point(424, 36);
            this.txtRuleName.Name = "txtRuleName";
            this.txtRuleName.Size = new System.Drawing.Size(128, 21);
            this.txtRuleName.TabIndex = 11;
            this.txtRuleName.Text = "DH均匀光";
            this.txtRuleName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(389, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "名称";
            // 
            // ucAreaSelect1
            // 
            this.ucAreaSelect1.BackColor = System.Drawing.Color.Silver;
            this.ucAreaSelect1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ucAreaSelect1.HCount = 1;
            this.ucAreaSelect1.HighlightColor = System.Drawing.Color.Yellow;
            this.ucAreaSelect1.HighlightTransparency = ((byte)(100));
            this.ucAreaSelect1.LineColor = System.Drawing.Color.Yellow;
            this.ucAreaSelect1.Location = new System.Drawing.Point(4, 6);
            this.ucAreaSelect1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ucAreaSelect1.Name = "ucAreaSelect1";
            this.ucAreaSelect1.ShowBlock = true;
            this.ucAreaSelect1.Size = new System.Drawing.Size(327, 250);
            this.ucAreaSelect1.TabIndex = 20;
            this.ucAreaSelect1.VCount = 1;
            // 
            // FrmNewRule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 266);
            this.Controls.Add(this.ucAreaSelect1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.txtHCount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtVCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtRuleName);
            this.Controls.Add(this.label1);
            this.Name = "FrmNewRule";
            this.Text = "添加新的图片堆叠规则";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.TextBox txtHCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtVCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtRuleName;
        private System.Windows.Forms.Label label1;
        private UcAreaSelect ucAreaSelect1;
    }
}