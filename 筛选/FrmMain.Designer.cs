
namespace 筛选
{
    partial class FrmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.viewer1 = new Bing.Viewer.ImageViewer();
            this.viewer2 = new Bing.Viewer.ImageViewer();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblPos = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnToList = new System.Windows.Forms.Button();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDefectType = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtfileName = new System.Windows.Forms.TextBox();
            this.txtDefectInfo = new System.Windows.Forms.TextBox();
            this.lblCursor = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnRotate270 = new System.Windows.Forms.Button();
            this.btnRotate90 = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnBefore = new System.Windows.Forms.Button();
            this.lblInfo = new System.Windows.Forms.Label();
            this.btnReflesh2 = new System.Windows.Forms.Button();
            this.btnSetPath2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtInfoPath = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnDeleteSelected = new System.Windows.Forms.Button();
            this.lblTotalAll = new System.Windows.Forms.Label();
            this.btnShowAll = new System.Windows.Forms.Button();
            this.lblTotal = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btnSaveToFile = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.defectTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.imageFileDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pickPointDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rotateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.defectInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.cbDefectTypes = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.defectInfoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 62.28522F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37.71478F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.viewer2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 46.70658F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 53.29342F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1150, 636);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.viewer1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.tableLayoutPanel1.SetRowSpan(this.panel1, 2);
            this.panel1.Size = new System.Drawing.Size(710, 630);
            this.panel1.TabIndex = 0;
            // 
            // viewer1
            // 
            this.viewer1.AutoFit = true;
            this.viewer1.BackColor = System.Drawing.Color.Gainsboro;
            this.viewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewer1.Image = null;
            this.viewer1.Location = new System.Drawing.Point(0, 0);
            this.viewer1.Name = "viewer1";
            this.viewer1.Rect = ((System.Drawing.RectangleF)(resources.GetObject("viewer1.Rect")));
            this.viewer1.ShowCrood = false;
            this.viewer1.ShowInfo = false;
            this.viewer1.Size = new System.Drawing.Size(710, 630);
            this.viewer1.TabIndex = 0;
            // 
            // viewer2
            // 
            this.viewer2.AutoFit = true;
            this.viewer2.BackColor = System.Drawing.Color.Gainsboro;
            this.viewer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewer2.Image = null;
            this.viewer2.Location = new System.Drawing.Point(719, 3);
            this.viewer2.Name = "viewer2";
            this.viewer2.Rect = ((System.Drawing.RectangleF)(resources.GetObject("viewer2.Rect")));
            this.viewer2.ShowCrood = false;
            this.viewer2.ShowInfo = false;
            this.viewer2.Size = new System.Drawing.Size(428, 291);
            this.viewer2.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblPos);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.btnToList);
            this.panel2.Controls.Add(this.txtDescription);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtDefectType);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.txtfileName);
            this.panel2.Controls.Add(this.txtDefectInfo);
            this.panel2.Controls.Add(this.lblCursor);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.btnRotate270);
            this.panel2.Controls.Add(this.btnRotate90);
            this.panel2.Controls.Add(this.btnNext);
            this.panel2.Controls.Add(this.btnBefore);
            this.panel2.Controls.Add(this.lblInfo);
            this.panel2.Controls.Add(this.btnReflesh2);
            this.panel2.Controls.Add(this.btnSetPath2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.txtInfoPath);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(719, 300);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(428, 333);
            this.panel2.TabIndex = 2;
            // 
            // lblPos
            // 
            this.lblPos.AutoSize = true;
            this.lblPos.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPos.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblPos.Location = new System.Drawing.Point(241, 203);
            this.lblPos.Name = "lblPos";
            this.lblPos.Size = new System.Drawing.Size(102, 17);
            this.lblPos.TabIndex = 117;
            this.lblPos.Text = "X : 0  Y : 0  R : 0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(205, 205);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 116;
            this.label5.Text = "位置";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 179);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 115;
            this.label4.Text = "现场录入信息";
            // 
            // btnToList
            // 
            this.btnToList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnToList.Location = new System.Drawing.Point(237, 288);
            this.btnToList.Name = "btnToList";
            this.btnToList.Size = new System.Drawing.Size(174, 42);
            this.btnToList.TabIndex = 114;
            this.btnToList.Text = "标注统计";
            this.btnToList.UseVisualStyleBackColor = true;
            this.btnToList.Click += new System.EventHandler(this.btnToList_Click);
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtDescription.Location = new System.Drawing.Point(237, 227);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(174, 55);
            this.txtDescription.TabIndex = 113;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(205, 227);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 112;
            this.label3.Text = "注释";
            // 
            // txtDefectType
            // 
            this.txtDefectType.Location = new System.Drawing.Point(264, 177);
            this.txtDefectType.Name = "txtDefectType";
            this.txtDefectType.Size = new System.Drawing.Size(147, 21);
            this.txtDefectType.TabIndex = 111;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(205, 182);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 110;
            this.label2.Text = "缺陷类型";
            // 
            // txtfileName
            // 
            this.txtfileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtfileName.Location = new System.Drawing.Point(2, 140);
            this.txtfileName.Name = "txtfileName";
            this.txtfileName.ReadOnly = true;
            this.txtfileName.Size = new System.Drawing.Size(423, 21);
            this.txtfileName.TabIndex = 109;
            // 
            // txtDefectInfo
            // 
            this.txtDefectInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtDefectInfo.ForeColor = System.Drawing.Color.Maroon;
            this.txtDefectInfo.Location = new System.Drawing.Point(5, 197);
            this.txtDefectInfo.Multiline = true;
            this.txtDefectInfo.Name = "txtDefectInfo";
            this.txtDefectInfo.ReadOnly = true;
            this.txtDefectInfo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtDefectInfo.Size = new System.Drawing.Size(159, 133);
            this.txtDefectInfo.TabIndex = 108;
            // 
            // lblCursor
            // 
            this.lblCursor.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCursor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblCursor.Location = new System.Drawing.Point(4, 83);
            this.lblCursor.Name = "lblCursor";
            this.lblCursor.Size = new System.Drawing.Size(47, 20);
            this.lblCursor.TabIndex = 107;
            this.lblCursor.Text = "0";
            this.lblCursor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel3.Location = new System.Drawing.Point(4, 168);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(422, 1);
            this.panel3.TabIndex = 106;
            // 
            // btnRotate270
            // 
            this.btnRotate270.Location = new System.Drawing.Point(150, 56);
            this.btnRotate270.Name = "btnRotate270";
            this.btnRotate270.Size = new System.Drawing.Size(75, 78);
            this.btnRotate270.TabIndex = 105;
            this.btnRotate270.Text = "旋转-90°";
            this.btnRotate270.UseVisualStyleBackColor = true;
            this.btnRotate270.Click += new System.EventHandler(this.btnRotate270_Click);
            // 
            // btnRotate90
            // 
            this.btnRotate90.Location = new System.Drawing.Point(243, 56);
            this.btnRotate90.Name = "btnRotate90";
            this.btnRotate90.Size = new System.Drawing.Size(75, 78);
            this.btnRotate90.TabIndex = 104;
            this.btnRotate90.Text = "旋转+90°";
            this.btnRotate90.UseVisualStyleBackColor = true;
            this.btnRotate90.Click += new System.EventHandler(this.btnRotate90_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(336, 56);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 78);
            this.btnNext.TabIndex = 103;
            this.btnNext.Text = "下一张";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnBefore
            // 
            this.btnBefore.Location = new System.Drawing.Point(57, 56);
            this.btnBefore.Name = "btnBefore";
            this.btnBefore.Size = new System.Drawing.Size(75, 78);
            this.btnBefore.TabIndex = 102;
            this.btnBefore.Text = "上一张";
            this.btnBefore.UseVisualStyleBackColor = true;
            this.btnBefore.Click += new System.EventHandler(this.btnBefore_Click);
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("微软雅黑", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblInfo.Location = new System.Drawing.Point(34, 37);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(0, 16);
            this.lblInfo.TabIndex = 101;
            // 
            // btnReflesh2
            // 
            this.btnReflesh2.Location = new System.Drawing.Point(343, 11);
            this.btnReflesh2.Name = "btnReflesh2";
            this.btnReflesh2.Size = new System.Drawing.Size(38, 23);
            this.btnReflesh2.TabIndex = 100;
            this.btnReflesh2.Text = "刷新";
            this.btnReflesh2.UseVisualStyleBackColor = true;
            this.btnReflesh2.Click += new System.EventHandler(this.btnReflesh2_Click);
            // 
            // btnSetPath2
            // 
            this.btnSetPath2.Location = new System.Drawing.Point(387, 11);
            this.btnSetPath2.Name = "btnSetPath2";
            this.btnSetPath2.Size = new System.Drawing.Size(38, 23);
            this.btnSetPath2.TabIndex = 99;
            this.btnSetPath2.Text = "选择";
            this.btnSetPath2.UseVisualStyleBackColor = true;
            this.btnSetPath2.Click += new System.EventHandler(this.btnSetPath2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 98;
            this.label1.Text = "路径";
            // 
            // txtInfoPath
            // 
            this.txtInfoPath.Location = new System.Drawing.Point(34, 12);
            this.txtInfoPath.Name = "txtInfoPath";
            this.txtInfoPath.ReadOnly = true;
            this.txtInfoPath.Size = new System.Drawing.Size(306, 21);
            this.txtInfoPath.TabIndex = 97;
            this.txtInfoPath.Text = "D:\\DefectImages";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1164, 668);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tableLayoutPanel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1156, 642);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "查看";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnDeleteSelected);
            this.tabPage2.Controls.Add(this.lblTotalAll);
            this.tabPage2.Controls.Add(this.btnShowAll);
            this.tabPage2.Controls.Add(this.lblTotal);
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Controls.Add(this.btnSaveToFile);
            this.tabPage2.Controls.Add(this.dataGridView1);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.cbDefectTypes);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1156, 642);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "统计";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnDeleteSelected
            // 
            this.btnDeleteSelected.Location = new System.Drawing.Point(546, 11);
            this.btnDeleteSelected.Name = "btnDeleteSelected";
            this.btnDeleteSelected.Size = new System.Drawing.Size(79, 23);
            this.btnDeleteSelected.TabIndex = 105;
            this.btnDeleteSelected.Text = "删除所选";
            this.btnDeleteSelected.UseVisualStyleBackColor = true;
            this.btnDeleteSelected.Click += new System.EventHandler(this.btnDeleteSelected_Click);
            // 
            // lblTotalAll
            // 
            this.lblTotalAll.AutoSize = true;
            this.lblTotalAll.Location = new System.Drawing.Point(409, 40);
            this.lblTotalAll.Name = "lblTotalAll";
            this.lblTotalAll.Size = new System.Drawing.Size(0, 12);
            this.lblTotalAll.TabIndex = 104;
            // 
            // btnShowAll
            // 
            this.btnShowAll.Location = new System.Drawing.Point(407, 12);
            this.btnShowAll.Name = "btnShowAll";
            this.btnShowAll.Size = new System.Drawing.Size(79, 23);
            this.btnShowAll.TabIndex = 103;
            this.btnShowAll.Text = "显示所有";
            this.btnShowAll.UseVisualStyleBackColor = true;
            this.btnShowAll.Click += new System.EventHandler(this.btnShowAll_Click);
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(65, 37);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(0, 12);
            this.lblTotal.TabIndex = 102;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(295, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(38, 23);
            this.button1.TabIndex = 101;
            this.button1.Text = "刷新";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnSaveToFile
            // 
            this.btnSaveToFile.Location = new System.Drawing.Point(1050, 14);
            this.btnSaveToFile.Name = "btnSaveToFile";
            this.btnSaveToFile.Size = new System.Drawing.Size(79, 23);
            this.btnSaveToFile.TabIndex = 86;
            this.btnSaveToFile.Text = "保存到文件";
            this.btnSaveToFile.UseVisualStyleBackColor = true;
            this.btnSaveToFile.Click += new System.EventHandler(this.btnSaveToFile_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.defectTypeDataGridViewTextBoxColumn,
            this.descriptionDataGridViewTextBoxColumn,
            this.imageFileDataGridViewTextBoxColumn,
            this.pickPointDataGridViewTextBoxColumn,
            this.rotateDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.defectInfoBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(3, 61);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1150, 578);
            this.dataGridView1.TabIndex = 85;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // defectTypeDataGridViewTextBoxColumn
            // 
            this.defectTypeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.defectTypeDataGridViewTextBoxColumn.DataPropertyName = "DefectType";
            this.defectTypeDataGridViewTextBoxColumn.HeaderText = "缺陷类型";
            this.defectTypeDataGridViewTextBoxColumn.Name = "defectTypeDataGridViewTextBoxColumn";
            this.defectTypeDataGridViewTextBoxColumn.Width = 78;
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            this.descriptionDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "Description";
            this.descriptionDataGridViewTextBoxColumn.HeaderText = "注释";
            this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            this.descriptionDataGridViewTextBoxColumn.Width = 54;
            // 
            // imageFileDataGridViewTextBoxColumn
            // 
            this.imageFileDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.imageFileDataGridViewTextBoxColumn.DataPropertyName = "ImageFile";
            this.imageFileDataGridViewTextBoxColumn.HeaderText = "图像名称";
            this.imageFileDataGridViewTextBoxColumn.Name = "imageFileDataGridViewTextBoxColumn";
            this.imageFileDataGridViewTextBoxColumn.Width = 78;
            // 
            // pickPointDataGridViewTextBoxColumn
            // 
            this.pickPointDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.pickPointDataGridViewTextBoxColumn.DataPropertyName = "PickPoint";
            this.pickPointDataGridViewTextBoxColumn.HeaderText = "坐标";
            this.pickPointDataGridViewTextBoxColumn.Name = "pickPointDataGridViewTextBoxColumn";
            this.pickPointDataGridViewTextBoxColumn.Width = 54;
            // 
            // rotateDataGridViewTextBoxColumn
            // 
            this.rotateDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.rotateDataGridViewTextBoxColumn.DataPropertyName = "Rotate";
            this.rotateDataGridViewTextBoxColumn.HeaderText = "图像旋转";
            this.rotateDataGridViewTextBoxColumn.Name = "rotateDataGridViewTextBoxColumn";
            // 
            // defectInfoBindingSource
            // 
            this.defectInfoBindingSource.DataSource = typeof(筛选.DefectInfo);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 84;
            this.label6.Text = "缺陷类型";
            // 
            // cbDefectTypes
            // 
            this.cbDefectTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDefectTypes.FormattingEnabled = true;
            this.cbDefectTypes.Location = new System.Drawing.Point(67, 14);
            this.cbDefectTypes.Name = "cbDefectTypes";
            this.cbDefectTypes.Size = new System.Drawing.Size(222, 20);
            this.cbDefectTypes.TabIndex = 83;
            this.cbDefectTypes.SelectedIndexChanged += new System.EventHandler(this.cbDefectTypes_SelectedIndexChanged);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1164, 668);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMain";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.defectInfoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private Bing.Viewer.ImageViewer viewer1;
        private Bing.Viewer.ImageViewer viewer2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnReflesh2;
        private System.Windows.Forms.Button btnSetPath2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtInfoPath;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Button btnRotate270;
        private System.Windows.Forms.Button btnRotate90;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnBefore;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblCursor;
        private System.Windows.Forms.TextBox txtfileName;
        private System.Windows.Forms.TextBox txtDefectInfo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnToList;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDefectType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblPos;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnSaveToFile;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbDefectTypes;
        private System.Windows.Forms.DataGridViewTextBoxColumn defectTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn imageFileDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pickPointDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rotateDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource defectInfoBindingSource;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblTotalAll;
        private System.Windows.Forms.Button btnShowAll;
        private System.Windows.Forms.Button btnDeleteSelected;
    }
}

