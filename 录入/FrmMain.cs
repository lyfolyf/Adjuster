using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 拼接
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
            txtSN.MouseEnter += TxtSN_MouseEnter;
        }

        private void TxtSN_MouseEnter(object sender, EventArgs e)
        {
            txtSN.SelectAll();
        }

        private string sn = string.Empty;
        private string currentBlock = string.Empty;
        private string currentDefectInfo = string.Empty;
        private UcAreaSelect currentUcAreaSelect;
        private bool onReading = false;
        private bool alltxtselected = false;
        private string color = "Gold";
        private void FrmMain_Load(object sender, EventArgs e)
        {
            currentUcAreaSelect = ucASTC;
            UpdateDefectTypes();
            usAsEvents();
            UpdateAreas();
            btnDeepBlue.BackColor = Color.AliceBlue;
            btnGold.BackColor = Color.AliceBlue;
            btnGray.BackColor = Color.AliceBlue;
            btnSilver.BackColor = Color.AliceBlue;

            btnDeepBlue.ForeColor = Color.Black;
            btnGold.ForeColor = Color.Black;
            btnGray.ForeColor = Color.Black;
            btnSilver.ForeColor = Color.Black;

        }

        private void usAsEvents()
        {
            ucASBC.AeraClick += Uc_AeraClick;
            ucASCorner1.AeraClick += Uc_AeraClick;
            ucASCorner2.AeraClick += Uc_AeraClick;
            ucASCorner3.AeraClick += Uc_AeraClick;
            ucASCorner4.AeraClick += Uc_AeraClick;
            ucASDH.AeraClick += Uc_AeraClick;
            ucASLCM.AeraClick += Uc_AeraClick;
            ucASLogo.AeraClick += Uc_AeraClick;
            ucASMandrel.AeraClick += Uc_AeraClick;
            ucASSide1_3.AeraClick += Uc_AeraClick;
            ucASSide4_5.AeraClick += Uc_AeraClick;
            ucASSide6_8.AeraClick += Uc_AeraClick;
            ucASSide9_10.AeraClick += Uc_AeraClick;
            ucASTC.AeraClick += Uc_AeraClick;
        }

        private void Uc_AeraClick(object sender, AreaSelectEventArgs e)
        {
            currentUcAreaSelect = (UcAreaSelect)sender;
            currentBlock = e.Info;
            if (e.Button == MouseButtons.Left)
            {
                tabControl1.Enabled = false;
                flowLayoutPanel1.Enabled = true;
            }
            UpdateDefectTypes();
        }

        private void UpdateAreas()
        {
            var surfaceCfg = SysSetting.SysConfig.DictSurfaceCfg[Surface.BC];
            ResetAreas(ucASBC, surfaceCfg);
            surfaceCfg = SysSetting.SysConfig.DictSurfaceCfg[Surface.Corner1];
            ResetAreas(ucASCorner1, surfaceCfg);
            surfaceCfg = SysSetting.SysConfig.DictSurfaceCfg[Surface.Corner2];
            ResetAreas(ucASCorner2, surfaceCfg);
            surfaceCfg = SysSetting.SysConfig.DictSurfaceCfg[Surface.Corner3];
            ResetAreas(ucASCorner3, surfaceCfg);
            surfaceCfg = SysSetting.SysConfig.DictSurfaceCfg[Surface.Corner4];
            ResetAreas(ucASCorner4, surfaceCfg);
            surfaceCfg = SysSetting.SysConfig.DictSurfaceCfg[Surface.DH];
            ResetAreas(ucASDH, surfaceCfg);
            surfaceCfg = SysSetting.SysConfig.DictSurfaceCfg[Surface.LCM];
            ResetAreas(ucASLCM, surfaceCfg);
            surfaceCfg = SysSetting.SysConfig.DictSurfaceCfg[Surface.Logo];
            ResetAreas(ucASLogo, surfaceCfg);
            surfaceCfg = SysSetting.SysConfig.DictSurfaceCfg[Surface.Mandrel];
            ResetAreas(ucASMandrel, surfaceCfg);
            surfaceCfg = SysSetting.SysConfig.DictSurfaceCfg[Surface.Side1_3];
            ResetAreas(ucASSide1_3, surfaceCfg);
            surfaceCfg = SysSetting.SysConfig.DictSurfaceCfg[Surface.Side4_5];
            ResetAreas(ucASSide4_5, surfaceCfg);
            surfaceCfg = SysSetting.SysConfig.DictSurfaceCfg[Surface.Side6_8];
            ResetAreas(ucASSide6_8, surfaceCfg);
            surfaceCfg = SysSetting.SysConfig.DictSurfaceCfg[Surface.Side9_10];
            ResetAreas(ucASSide9_10, surfaceCfg);
            surfaceCfg = SysSetting.SysConfig.DictSurfaceCfg[Surface.TC];
            ResetAreas(ucASTC, surfaceCfg);
        }

        private void ResetAreas(UcAreaSelect areaSelect, SurfaceConfig surfaceCfg)
        {
            areaSelect.HCount = surfaceCfg.HCount;
            areaSelect.VCount = surfaceCfg.VCount;
            areaSelect.ClearAreas();
            var index = 0;
            for (int x = 0; x < areaSelect.VCount; x++)
            {
                for (int y = 0; y < areaSelect.HCount; y++)
                {
                    Point p = new Point(x + 1, y + 1);
                    var msg = surfaceCfg.DictBlock[p];
                    index++;
                    AreaInfo areaInfo = new AreaInfo()
                    {
                        Color = Color.Cyan,
                        Column = x + 1,
                        Row = y + 1,
                        Block = msg,
                        Info = msg,
                        Selected = false
                    };
                    areaSelect.AddArea(areaInfo);
                }
            }
        }

        private void UpdateDefectTypes()
        {
            flowLayoutPanel1.Controls.Clear();
            var types = SysSetting.SysConfig.DefectTypes;
            foreach (var item in types)
            {
                RadioButton rb = new RadioButton();
                rb.Text = item;
                rb.Checked = false;
                rb.CheckedChanged += Rb_CheckedChanged;
                flowLayoutPanel1.Controls.Add(rb);
            }
        }
        private void UpdateDefectList()
        {
            List<Defect> defects = new List<Defect>();
            defects.AddRange(ucASBC.Defects);
            defects.AddRange(ucASCorner1.Defects);
            defects.AddRange(ucASCorner2.Defects);
            defects.AddRange(ucASCorner3.Defects);
            defects.AddRange(ucASCorner4.Defects);
            defects.AddRange(ucASDH.Defects);
            defects.AddRange(ucASLCM.Defects);
            defects.AddRange(ucASLogo.Defects);
            defects.AddRange(ucASMandrel.Defects);
            defects.AddRange(ucASSide1_3.Defects);
            defects.AddRange(ucASSide4_5.Defects);
            defects.AddRange(ucASSide6_8.Defects);
            defects.AddRange(ucASSide9_10.Defects);
            defects.AddRange(ucASTC.Defects);
            txtDetail.Clear();
            foreach (var item in defects)
            {
                txtDetail.AppendText($"{item.Surface},{item.Block},{item.Info},{item.Size}\r\n");
            }
        }
        public void Save(string folder)
        {
            ucASBC.SaveDefectInfo(folder);
            ucASCorner1.SaveDefectInfo(folder);
            ucASCorner2.SaveDefectInfo(folder);
            ucASCorner3.SaveDefectInfo(folder);
            ucASCorner4.SaveDefectInfo(folder);
            ucASDH.SaveDefectInfo(folder);
            ucASLCM.SaveDefectInfo(folder);
            ucASLogo.SaveDefectInfo(folder);
            ucASMandrel.SaveDefectInfo(folder);
            ucASSide1_3.SaveDefectInfo(folder);
            ucASSide4_5.SaveDefectInfo(folder);
            ucASSide6_8.SaveDefectInfo(folder);
            ucASSide9_10.SaveDefectInfo(folder);
            ucASTC.SaveDefectInfo(folder);

            ucASBC.ClearDefects();
            ucASCorner1.ClearDefects();
            ucASCorner2.ClearDefects();
            ucASCorner3.ClearDefects();
            ucASCorner4.ClearDefects();
            ucASDH.ClearDefects();
            ucASLCM.ClearDefects();
            ucASLogo.ClearDefects();
            ucASMandrel.ClearDefects();
            ucASSide1_3.ClearDefects();
            ucASSide4_5.ClearDefects();
            ucASSide6_8.ClearDefects();
            ucASSide9_10.ClearDefects();
            ucASTC.ClearDefects();
            //txtDetail.Clear();
        }
        private void Rb_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            currentDefectInfo = rb.Text;
            currentUcAreaSelect.SetDefectInfo(currentDefectInfo);

            UpdateDefectList();
            tabControl1.Enabled = true;
            flowLayoutPanel1.Enabled = false;
        }

        private void txtSN_TextChanged(object sender, EventArgs e)
        {
            alltxtselected = false;
            onReading = true;
            sn = txtSN.Text;
            ucASBC.Sn = sn;
            ucASCorner1.Sn = sn;
            ucASCorner2.Sn = sn;
            ucASCorner3.Sn = sn;
            ucASCorner4.Sn = sn;
            ucASDH.Sn = sn;
            ucASLCM.Sn = sn;
            ucASLogo.Sn = sn;
            ucASMandrel.Sn = sn;
            ucASSide1_3.Sn = sn;
            ucASSide4_5.Sn = sn;
            ucASSide6_8.Sn = sn;
            ucASSide9_10.Sn = sn;
            ucASTC.Sn = sn;
            Task.Run(() => { Thread.Sleep(2000); onReading = false; });
            btnApply.Enabled = true;
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            FrmSetting frmSetting = new FrmSetting();
            frmSetting.FormClosing += (s, args) =>
            {
                UpdateDefectTypes();
                UpdateAreas();
            };
            frmSetting.ShowDialog();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            btnApply.Enabled = false;
            if (sn == string.Empty || sn == "SN")
            {
                btnApply.Enabled = true;
                return;
            }
            string folder = $@"D:\DefectInfos\{DateTime.Now:yyyy-MM-dd}";
            if (!System.IO.Directory.Exists(folder))
            {
                System.IO.Directory.CreateDirectory(folder);
            }
            var folders = System.IO.Directory.GetDirectories(folder);
            var find = folders.Contains($@"D:\DefectInfos\{DateTime.Now:yyyy-MM-dd}\{sn}");
            if (find)
            {
                if (MessageBox.Show($"检测到 【{sn}】 已经录入,是否重新录入？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    btnApply.Enabled = true;
                    return;
                }
            }
            if (!System.IO.Directory.Exists($@"{folder}\{sn}"))
            {
                System.IO.Directory.CreateDirectory($@"{folder}\{sn}");
            }
            var file = $@"{folder}\{sn}\{sn}.txt";
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(file, true))
            {
                sw.WriteLine($"Color_{color}");
            }
            Save(folder);
            UpdateDefectTypes();
            this.Text = $"上片物料-[{sn}]";
            txtSN.Text = string.Empty;
            txtDetail.Text = string.Empty;
            tabControl1.Enabled = true;
            flowLayoutPanel1.Enabled = false;
            btnDeepBlue.BackColor = Color.AliceBlue;
            btnGold.BackColor = Color.AliceBlue;
            btnGray.BackColor = Color.AliceBlue;
            btnSilver.BackColor = Color.AliceBlue;
            btnDeepBlue.ForeColor = Color.Black;
            btnGold.ForeColor = Color.Black;
            btnGray.ForeColor = Color.Black;
            btnSilver.ForeColor = Color.Black;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!onReading && !alltxtselected)
            {
                txtSN.Focus();
                txtSN.SelectAll();
                alltxtselected = true;
            }
        }

        private void btnDeepBlue_Click(object sender, EventArgs e)
        {
            btnDeepBlue.BackColor = Color.Navy;
            btnGold.BackColor = Color.AliceBlue;
            btnGray.BackColor = Color.AliceBlue;
            btnSilver.BackColor = Color.AliceBlue;
            btnDeepBlue.ForeColor = Color.White;
            btnGold.ForeColor = Color.Black;
            btnGray.ForeColor = Color.Black;
            btnSilver.ForeColor = Color.Black;
            color = "DeepBlue";
        }

        private void btnGold_Click(object sender, EventArgs e)
        {
            btnDeepBlue.BackColor = Color.AliceBlue;
            btnGold.BackColor = Color.Gold;
            btnGray.BackColor = Color.AliceBlue;
            btnSilver.BackColor = Color.AliceBlue;
            btnDeepBlue.ForeColor = Color.Black;
            btnGold.ForeColor = Color.Black;
            btnGray.ForeColor = Color.Black;
            btnSilver.ForeColor = Color.Black;
            color = "Gold";
        }

        private void btnGray_Click(object sender, EventArgs e)
        {
            btnDeepBlue.BackColor = Color.AliceBlue;
            btnGold.BackColor = Color.AliceBlue;
            btnGray.BackColor = Color.Gray;
            btnSilver.BackColor = Color.AliceBlue;
            btnDeepBlue.ForeColor = Color.Black;
            btnGold.ForeColor = Color.Black;
            btnGray.ForeColor = Color.White;
            btnSilver.ForeColor = Color.Black;
            color = "Gray";
        }

        private void btnSilver_Click(object sender, EventArgs e)
        {
            btnDeepBlue.BackColor = Color.AliceBlue;
            btnGold.BackColor = Color.AliceBlue;
            btnGray.BackColor = Color.AliceBlue;
            btnSilver.BackColor = Color.Silver;
            btnDeepBlue.ForeColor = Color.Black;
            btnGold.ForeColor = Color.Black;
            btnGray.ForeColor = Color.Black;
            btnSilver.ForeColor = Color.DodgerBlue;
            color = "Silver";
        }
    }
}
