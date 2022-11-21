namespace Adjuster
{
    partial class FrmShowHotmap
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmShowHotmap));
            this.heatMapViewer1 = new HeatMapViewer();
            this.SuspendLayout();
            // 
            // heatMapViewer1
            // 
            this.heatMapViewer1.AutoFit = false;
            this.heatMapViewer1.BackColor = System.Drawing.Color.Silver;
            this.heatMapViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.heatMapViewer1.Image = null;
            this.heatMapViewer1.Location = new System.Drawing.Point(0, 0);
            this.heatMapViewer1.Name = "heatMapViewer1";
            this.heatMapViewer1.Rect = ((System.Drawing.RectangleF)(resources.GetObject("heatMapViewer1.Rect")));
            this.heatMapViewer1.ShowCrood = false;
            this.heatMapViewer1.ShowInfo = false;
            this.heatMapViewer1.Size = new System.Drawing.Size(871, 684);
            this.heatMapViewer1.TabIndex = 0;
            // 
            // FrmShowHotmap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 684);
            this.Controls.Add(this.heatMapViewer1);
            this.Name = "FrmShowHotmap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "热力图";
            this.ResumeLayout(false);

        }

        #endregion

        private HeatMapViewer heatMapViewer1;
    }
}