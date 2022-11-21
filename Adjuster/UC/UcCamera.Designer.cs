namespace Adjuster.UC
{
    partial class UcCamera
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
            this.components = new System.ComponentModel.Container();
            this.btnSnop = new System.Windows.Forms.Button();
            this.btnrefleshCameraList = new System.Windows.Forms.Button();
            this.gbCameraSetting = new System.Windows.Forms.GroupBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtBRatio = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtGRatio = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtRRatio = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFrameRate = new System.Windows.Forms.TextBox();
            this.ckbTriggerMode = new System.Windows.Forms.CheckBox();
            this.btnSetParam = new System.Windows.Forms.Button();
            this.btnGetParam = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtGain = new System.Windows.Forms.TextBox();
            this.txtExposure = new System.Windows.Forms.TextBox();
            this.chkBalanceWhiteAuto = new System.Windows.Forms.CheckBox();
            this.btnOpenCamera = new System.Windows.Forms.Button();
            this.cbDeviceList = new System.Windows.Forms.ComboBox();
            this.pStatus = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnMWB = new System.Windows.Forms.Button();
            this.ckbUseLsc = new System.Windows.Forms.CheckBox();
            this.btnResetLsc = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.gbCameraSetting.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSnop
            // 
            this.btnSnop.BackColor = System.Drawing.Color.DarkGray;
            this.btnSnop.Enabled = false;
            this.btnSnop.FlatAppearance.BorderSize = 0;
            this.btnSnop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSnop.ForeColor = System.Drawing.Color.White;
            this.btnSnop.Location = new System.Drawing.Point(257, 158);
            this.btnSnop.Margin = new System.Windows.Forms.Padding(0);
            this.btnSnop.Name = "btnSnop";
            this.btnSnop.Size = new System.Drawing.Size(68, 19);
            this.btnSnop.TabIndex = 37;
            this.btnSnop.Text = "手动拍照";
            this.btnSnop.UseVisualStyleBackColor = false;
            this.btnSnop.Click += new System.EventHandler(this.btnGetOneImage_Click);
            // 
            // btnrefleshCameraList
            // 
            this.btnrefleshCameraList.BackColor = System.Drawing.Color.DarkGray;
            this.btnrefleshCameraList.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnrefleshCameraList.FlatAppearance.BorderSize = 0;
            this.btnrefleshCameraList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnrefleshCameraList.ForeColor = System.Drawing.Color.White;
            this.btnrefleshCameraList.Location = new System.Drawing.Point(257, 32);
            this.btnrefleshCameraList.Margin = new System.Windows.Forms.Padding(2);
            this.btnrefleshCameraList.Name = "btnrefleshCameraList";
            this.btnrefleshCameraList.Size = new System.Drawing.Size(68, 26);
            this.btnrefleshCameraList.TabIndex = 36;
            this.btnrefleshCameraList.Text = "刷新列表";
            this.btnrefleshCameraList.UseVisualStyleBackColor = false;
            this.btnrefleshCameraList.Click += new System.EventHandler(this.btnRefreshCameraList_Click);
            // 
            // gbCameraSetting
            // 
            this.gbCameraSetting.Controls.Add(this.btnLoad);
            this.gbCameraSetting.Controls.Add(this.btnSave);
            this.gbCameraSetting.Controls.Add(this.label8);
            this.gbCameraSetting.Controls.Add(this.label7);
            this.gbCameraSetting.Controls.Add(this.txtBRatio);
            this.gbCameraSetting.Controls.Add(this.label6);
            this.gbCameraSetting.Controls.Add(this.txtGRatio);
            this.gbCameraSetting.Controls.Add(this.label5);
            this.gbCameraSetting.Controls.Add(this.txtRRatio);
            this.gbCameraSetting.Controls.Add(this.label4);
            this.gbCameraSetting.Controls.Add(this.txtFrameRate);
            this.gbCameraSetting.Controls.Add(this.ckbTriggerMode);
            this.gbCameraSetting.Controls.Add(this.btnSetParam);
            this.gbCameraSetting.Controls.Add(this.btnGetParam);
            this.gbCameraSetting.Controls.Add(this.label3);
            this.gbCameraSetting.Controls.Add(this.label2);
            this.gbCameraSetting.Controls.Add(this.label1);
            this.gbCameraSetting.Controls.Add(this.txtGain);
            this.gbCameraSetting.Controls.Add(this.txtExposure);
            this.gbCameraSetting.Enabled = false;
            this.gbCameraSetting.Location = new System.Drawing.Point(3, 30);
            this.gbCameraSetting.Margin = new System.Windows.Forms.Padding(2);
            this.gbCameraSetting.Name = "gbCameraSetting";
            this.gbCameraSetting.Padding = new System.Windows.Forms.Padding(2);
            this.gbCameraSetting.Size = new System.Drawing.Size(246, 156);
            this.gbCameraSetting.TabIndex = 35;
            this.gbCameraSetting.TabStop = false;
            this.gbCameraSetting.Text = "参数";
            // 
            // btnLoad
            // 
            this.btnLoad.BackColor = System.Drawing.Color.DarkGray;
            this.btnLoad.FlatAppearance.BorderSize = 0;
            this.btnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoad.ForeColor = System.Drawing.Color.White;
            this.btnLoad.Location = new System.Drawing.Point(165, 128);
            this.btnLoad.Margin = new System.Windows.Forms.Padding(0);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(68, 19);
            this.btnLoad.TabIndex = 46;
            this.btnLoad.Text = "加载白平衡";
            this.btnLoad.UseVisualStyleBackColor = false;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.DarkGray;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(165, 107);
            this.btnSave.Margin = new System.Windows.Forms.Padding(0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(68, 19);
            this.btnSave.TabIndex = 45;
            this.btnSave.Text = "保存白平衡";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(85, 135);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 10);
            this.label8.TabIndex = 44;
            this.label8.Text = "转换耗时";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 135);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 10);
            this.label7.TabIndex = 43;
            this.label7.Text = "传输耗时";
            // 
            // txtBRatio
            // 
            this.txtBRatio.Font = new System.Drawing.Font("宋体", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtBRatio.Location = new System.Drawing.Point(165, 85);
            this.txtBRatio.Margin = new System.Windows.Forms.Padding(2);
            this.txtBRatio.Name = "txtBRatio";
            this.txtBRatio.Size = new System.Drawing.Size(71, 19);
            this.txtBRatio.TabIndex = 15;
            this.txtBRatio.Text = "0";
            this.txtBRatio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(152, 72);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 10);
            this.label6.TabIndex = 14;
            this.label6.Text = "B Ratio";
            // 
            // txtGRatio
            // 
            this.txtGRatio.Font = new System.Drawing.Font("宋体", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtGRatio.Location = new System.Drawing.Point(165, 52);
            this.txtGRatio.Margin = new System.Windows.Forms.Padding(2);
            this.txtGRatio.Name = "txtGRatio";
            this.txtGRatio.Size = new System.Drawing.Size(71, 19);
            this.txtGRatio.TabIndex = 13;
            this.txtGRatio.Text = "0";
            this.txtGRatio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(152, 40);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 10);
            this.label5.TabIndex = 12;
            this.label5.Text = "G Ratio";
            // 
            // txtRRatio
            // 
            this.txtRRatio.Font = new System.Drawing.Font("宋体", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtRRatio.Location = new System.Drawing.Point(165, 21);
            this.txtRRatio.Margin = new System.Windows.Forms.Padding(2);
            this.txtRRatio.Name = "txtRRatio";
            this.txtRRatio.Size = new System.Drawing.Size(71, 19);
            this.txtRRatio.TabIndex = 11;
            this.txtRRatio.Text = "0";
            this.txtRRatio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(152, 8);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 10);
            this.label4.TabIndex = 10;
            this.label4.Text = "R Ratio";
            // 
            // txtFrameRate
            // 
            this.txtFrameRate.BackColor = System.Drawing.Color.White;
            this.txtFrameRate.Font = new System.Drawing.Font("宋体", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtFrameRate.Location = new System.Drawing.Point(42, 57);
            this.txtFrameRate.Margin = new System.Windows.Forms.Padding(2);
            this.txtFrameRate.Name = "txtFrameRate";
            this.txtFrameRate.ReadOnly = true;
            this.txtFrameRate.Size = new System.Drawing.Size(84, 19);
            this.txtFrameRate.TabIndex = 2;
            this.txtFrameRate.Text = "20";
            this.txtFrameRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ckbTriggerMode
            // 
            this.ckbTriggerMode.AutoSize = true;
            this.ckbTriggerMode.Location = new System.Drawing.Point(42, 86);
            this.ckbTriggerMode.Margin = new System.Windows.Forms.Padding(2);
            this.ckbTriggerMode.Name = "ckbTriggerMode";
            this.ckbTriggerMode.Size = new System.Drawing.Size(64, 14);
            this.ckbTriggerMode.TabIndex = 8;
            this.ckbTriggerMode.Text = "连续模式";
            this.ckbTriggerMode.UseVisualStyleBackColor = true;
            this.ckbTriggerMode.CheckedChanged += new System.EventHandler(this.ckbTriggerMode_CheckedChanged);
            // 
            // btnSetParam
            // 
            this.btnSetParam.BackColor = System.Drawing.Color.DarkGray;
            this.btnSetParam.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnSetParam.FlatAppearance.BorderSize = 0;
            this.btnSetParam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetParam.ForeColor = System.Drawing.Color.White;
            this.btnSetParam.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSetParam.Location = new System.Drawing.Point(78, 107);
            this.btnSetParam.Margin = new System.Windows.Forms.Padding(2);
            this.btnSetParam.Name = "btnSetParam";
            this.btnSetParam.Size = new System.Drawing.Size(56, 19);
            this.btnSetParam.TabIndex = 7;
            this.btnSetParam.Text = "设置参数";
            this.btnSetParam.UseVisualStyleBackColor = false;
            this.btnSetParam.Click += new System.EventHandler(this.btnSetParam_Click);
            // 
            // btnGetParam
            // 
            this.btnGetParam.BackColor = System.Drawing.Color.DarkGray;
            this.btnGetParam.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnGetParam.FlatAppearance.BorderSize = 0;
            this.btnGetParam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGetParam.ForeColor = System.Drawing.Color.White;
            this.btnGetParam.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnGetParam.Location = new System.Drawing.Point(18, 107);
            this.btnGetParam.Margin = new System.Windows.Forms.Padding(2);
            this.btnGetParam.Name = "btnGetParam";
            this.btnGetParam.Size = new System.Drawing.Size(56, 19);
            this.btnGetParam.TabIndex = 6;
            this.btnGetParam.Text = "获取参数";
            this.btnGetParam.UseVisualStyleBackColor = false;
            this.btnGetParam.Click += new System.EventHandler(this.btnGetParam_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(9, 62);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 10);
            this.label3.TabIndex = 5;
            this.label3.Text = "帧率";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(9, 40);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 10);
            this.label2.TabIndex = 4;
            this.label2.Text = "增益";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(9, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 10);
            this.label1.TabIndex = 3;
            this.label1.Text = "曝光";
            // 
            // txtGain
            // 
            this.txtGain.Font = new System.Drawing.Font("宋体", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtGain.Location = new System.Drawing.Point(42, 36);
            this.txtGain.Margin = new System.Windows.Forms.Padding(2);
            this.txtGain.Name = "txtGain";
            this.txtGain.Size = new System.Drawing.Size(84, 19);
            this.txtGain.TabIndex = 1;
            this.txtGain.Text = "0";
            this.txtGain.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtExposure
            // 
            this.txtExposure.Font = new System.Drawing.Font("宋体", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtExposure.Location = new System.Drawing.Point(42, 14);
            this.txtExposure.Margin = new System.Windows.Forms.Padding(2);
            this.txtExposure.Name = "txtExposure";
            this.txtExposure.Size = new System.Drawing.Size(84, 19);
            this.txtExposure.TabIndex = 0;
            this.txtExposure.Text = "0";
            this.txtExposure.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chkBalanceWhiteAuto
            // 
            this.chkBalanceWhiteAuto.AutoSize = true;
            this.chkBalanceWhiteAuto.Location = new System.Drawing.Point(257, 140);
            this.chkBalanceWhiteAuto.Margin = new System.Windows.Forms.Padding(2);
            this.chkBalanceWhiteAuto.Name = "chkBalanceWhiteAuto";
            this.chkBalanceWhiteAuto.Size = new System.Drawing.Size(74, 14);
            this.chkBalanceWhiteAuto.TabIndex = 9;
            this.chkBalanceWhiteAuto.Text = "自动白平衡";
            this.chkBalanceWhiteAuto.UseVisualStyleBackColor = true;
            this.chkBalanceWhiteAuto.CheckedChanged += new System.EventHandler(this.chkBalanceWhiteAuto_CheckedChanged);
            // 
            // btnOpenCamera
            // 
            this.btnOpenCamera.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnOpenCamera.Enabled = false;
            this.btnOpenCamera.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnOpenCamera.FlatAppearance.BorderSize = 0;
            this.btnOpenCamera.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenCamera.Location = new System.Drawing.Point(265, 5);
            this.btnOpenCamera.Margin = new System.Windows.Forms.Padding(2);
            this.btnOpenCamera.Name = "btnOpenCamera";
            this.btnOpenCamera.Size = new System.Drawing.Size(36, 19);
            this.btnOpenCamera.TabIndex = 34;
            this.btnOpenCamera.Text = "打开";
            this.btnOpenCamera.UseVisualStyleBackColor = false;
            this.btnOpenCamera.Click += new System.EventHandler(this.btnOpenCamera_Click);
            // 
            // cbDeviceList
            // 
            this.cbDeviceList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDeviceList.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbDeviceList.FormattingEnabled = true;
            this.cbDeviceList.Location = new System.Drawing.Point(27, 5);
            this.cbDeviceList.Margin = new System.Windows.Forms.Padding(2);
            this.cbDeviceList.Name = "cbDeviceList";
            this.cbDeviceList.Size = new System.Drawing.Size(234, 24);
            this.cbDeviceList.TabIndex = 33;
            this.cbDeviceList.SelectedIndexChanged += new System.EventHandler(this.cbDeviceList_SelectedIndexChanged);
            // 
            // pStatus
            // 
            this.pStatus.BackColor = System.Drawing.Color.Gray;
            this.pStatus.Location = new System.Drawing.Point(4, 7);
            this.pStatus.Margin = new System.Windows.Forms.Padding(0);
            this.pStatus.Name = "pStatus";
            this.pStatus.Size = new System.Drawing.Size(17, 17);
            this.pStatus.TabIndex = 38;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Gray;
            this.btnClose.Enabled = false;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(306, 6);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(36, 19);
            this.btnClose.TabIndex = 39;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnMWB
            // 
            this.btnMWB.BackColor = System.Drawing.Color.DarkGray;
            this.btnMWB.Enabled = false;
            this.btnMWB.FlatAppearance.BorderSize = 0;
            this.btnMWB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMWB.ForeColor = System.Drawing.Color.White;
            this.btnMWB.Location = new System.Drawing.Point(257, 116);
            this.btnMWB.Margin = new System.Windows.Forms.Padding(0);
            this.btnMWB.Name = "btnMWB";
            this.btnMWB.Size = new System.Drawing.Size(68, 19);
            this.btnMWB.TabIndex = 40;
            this.btnMWB.Text = "手动白平衡";
            this.btnMWB.UseVisualStyleBackColor = false;
            this.btnMWB.Click += new System.EventHandler(this.btnMWB_Click);
            // 
            // ckbUseLsc
            // 
            this.ckbUseLsc.AutoSize = true;
            this.ckbUseLsc.Enabled = false;
            this.ckbUseLsc.Location = new System.Drawing.Point(257, 93);
            this.ckbUseLsc.Margin = new System.Windows.Forms.Padding(2);
            this.ckbUseLsc.Name = "ckbUseLsc";
            this.ckbUseLsc.Size = new System.Drawing.Size(59, 14);
            this.ckbUseLsc.TabIndex = 41;
            this.ckbUseLsc.Text = "开启LSC";
            this.ckbUseLsc.UseVisualStyleBackColor = true;
            this.ckbUseLsc.Visible = false;
            this.ckbUseLsc.CheckedChanged += new System.EventHandler(this.ckbUseLsc_CheckedChanged);
            // 
            // btnResetLsc
            // 
            this.btnResetLsc.BackColor = System.Drawing.Color.DarkGray;
            this.btnResetLsc.Enabled = false;
            this.btnResetLsc.FlatAppearance.BorderSize = 0;
            this.btnResetLsc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResetLsc.ForeColor = System.Drawing.Color.White;
            this.btnResetLsc.Location = new System.Drawing.Point(257, 66);
            this.btnResetLsc.Margin = new System.Windows.Forms.Padding(0);
            this.btnResetLsc.Name = "btnResetLsc";
            this.btnResetLsc.Size = new System.Drawing.Size(68, 19);
            this.btnResetLsc.TabIndex = 42;
            this.btnResetLsc.Text = "重置LSC";
            this.btnResetLsc.UseVisualStyleBackColor = false;
            this.btnResetLsc.Visible = false;
            this.btnResetLsc.Click += new System.EventHandler(this.btnResetLsc_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // UcCamera
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(5F, 10F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnResetLsc);
            this.Controls.Add(this.ckbUseLsc);
            this.Controls.Add(this.btnMWB);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.pStatus);
            this.Controls.Add(this.btnSnop);
            this.Controls.Add(this.btnrefleshCameraList);
            this.Controls.Add(this.gbCameraSetting);
            this.Controls.Add(this.btnOpenCamera);
            this.Controls.Add(this.cbDeviceList);
            this.Controls.Add(this.chkBalanceWhiteAuto);
            this.Font = new System.Drawing.Font("宋体", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "UcCamera";
            this.Size = new System.Drawing.Size(346, 187);
            this.Load += new System.EventHandler(this.UcCamera_Load);
            this.gbCameraSetting.ResumeLayout(false);
            this.gbCameraSetting.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSnop;
        private System.Windows.Forms.Button btnrefleshCameraList;
        private System.Windows.Forms.GroupBox gbCameraSetting;
        private System.Windows.Forms.CheckBox ckbTriggerMode;
        private System.Windows.Forms.Button btnSetParam;
        private System.Windows.Forms.Button btnGetParam;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFrameRate;
        private System.Windows.Forms.TextBox txtGain;
        private System.Windows.Forms.TextBox txtExposure;
        private System.Windows.Forms.Button btnOpenCamera;
        private System.Windows.Forms.ComboBox cbDeviceList;
        private System.Windows.Forms.Panel pStatus;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtBRatio;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtGRatio;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtRRatio;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkBalanceWhiteAuto;
        private System.Windows.Forms.Button btnMWB;
        private System.Windows.Forms.CheckBox ckbUseLsc;
        private System.Windows.Forms.Button btnResetLsc;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnLoad;
    }
}
