using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 拼接
{
    public partial class FrmSetting : Form
    {
        public FrmSetting()
        {
            InitializeComponent();
        }

        private void FrmSetting_Load(object sender, EventArgs e)
        {
            cbDefectTypes.DataSource = SysSetting.SysConfig.DefectTypes;
            //cbRotate.DataSource = Enum.GetNames(typeof(RotateFlipType)).ToList();
            cbSurface.DataSource = Enum.GetNames(typeof(Surface)).ToList();
            cbSurface_SelectedIndexChanged(null, null);

        }

        private void btnSetCameraRotate_Click(object sender, EventArgs e)
        {
            if (!SysSetting.SysConfig.DefectTypes.Contains(txtDefectType.Text))
                SysSetting.SysConfig.DefectTypes.Add(txtDefectType.Text);
            cbDefectTypes.DataSource = SysSetting.SysConfig.DefectTypes;
            SysSetting.SaveConfig();
        }
        private void cbSurface_SelectedIndexChanged(object sender, EventArgs e)
        {
            Surface surface = (Surface)Enum.Parse(typeof(Surface), cbSurface.Text);
            var surfaceCfg = SysSetting.SysConfig.DictSurfaceCfg[surface];
            numericUdHcount.Value = surfaceCfg.HCount;
            numericUdVcount.Value = surfaceCfg.VCount;
            ucAreaSelect1.HCount = (int)numericUdHcount.Value;
            ucAreaSelect1.VCount = (int)numericUdVcount.Value;
            ucAreaSelect1.ClearAreas();
            numericUdY.Maximum = (int)numericUdHcount.Value;
            numericUdX.Maximum = (int)numericUdVcount.Value;
            ResetAreas(surfaceCfg);
        }
        private void ResetAreas(SurfaceConfig surfaceCfg)
        {
            var index = 0;
            for (int x = 0; x < ucAreaSelect1.VCount; x++)
            {
                for (int y = 0; y < ucAreaSelect1.HCount; y++)
                {
                    Point p = new Point(x + 1, y + 1);
                    var msg = surfaceCfg.DictBlock[p];
                    index++;
                    AreaInfo areaInfo = new AreaInfo()
                    {
                        Color = Color.Blue,
                        Column = x + 1,
                        Row = y + 1,
                        Block = msg,
                        Info = msg,
                        Selected = false
                    };
                    ucAreaSelect1.AddArea(areaInfo);
                }
            }
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            Surface surface = (Surface)Enum.Parse(typeof(Surface), cbSurface.Text);
            Point p = new Point((int)numericUdX.Value, (int)numericUdY.Value);
            var march = txtCamPos.Text;
            SysSetting.SysConfig.DictSurfaceCfg[surface].Set(p, march);
            ucAreaSelect1.SetAreaInfo(p.Y, p.X, march);
            SysSetting.SaveConfig();
        }

        private void numericUdHcount_ValueChanged(object sender, EventArgs e)
        {
            Surface surface = (Surface)Enum.Parse(typeof(Surface), cbSurface.Text);
            var surfaceCfg = SysSetting.SysConfig.DictSurfaceCfg[surface];
            surfaceCfg.HCount = (int)numericUdHcount.Value;
            ucAreaSelect1.ClearAreas();
            ucAreaSelect1.HCount = (int)numericUdHcount.Value;
            numericUdY.Maximum = (int)numericUdHcount.Value;
            ResetAreas(surfaceCfg);
        }

        private void numericUdVcount_ValueChanged(object sender, EventArgs e)
        {
            Surface surface = (Surface)Enum.Parse(typeof(Surface), cbSurface.Text);
            var surfaceCfg = SysSetting.SysConfig.DictSurfaceCfg[surface];
            surfaceCfg.VCount = (int)numericUdVcount.Value;
            ucAreaSelect1.ClearAreas();
            ucAreaSelect1.VCount = (int)numericUdVcount.Value;
            numericUdX.Maximum = (int)numericUdVcount.Value;
            ResetAreas(surfaceCfg);
        }

        private void NumericUdXY_ValueChanged(object sender, EventArgs e)
        {
            Point p = new Point((int)numericUdX.Value, (int)numericUdY.Value);
            Surface surface = (Surface)Enum.Parse(typeof(Surface), cbSurface.Text);
            var surfaceCfg = SysSetting.SysConfig.DictSurfaceCfg[surface];
            txtCamPos.Text = surfaceCfg.DictBlock[p];
            ucAreaSelect1.SetAreaSelected(p.Y, p.X, true);
        }

        private void btnDelDefectType_Click(object sender, EventArgs e)
        {
            SysSetting.SysConfig.DefectTypes.Remove(cbDefectTypes.Text);
            cbDefectTypes.DataSource = SysSetting.SysConfig.DefectTypes;
            SysSetting.SaveConfig();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
