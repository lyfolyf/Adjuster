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
            cbCamera.DataSource = Enum.GetNames(typeof(Camera)).ToList();
            cbRotate.Items.Add("0°");
            cbRotate.Items.Add("90°");
            cbRotate.Items.Add("180°");
            cbRotate.Items.Add("270°");
            cbRotate.SelectedIndex = 0;
            //cbRotate.DataSource = Enum.GetNames(typeof(RotateFlipType)).ToList();
            cbSurface.DataSource = Enum.GetNames(typeof(Surface)).ToList();
            cbCamera_SelectedIndexChanged(null, null);
            cbSurface_SelectedIndexChanged(null, null);
        }

        private void btnSetCameraRotate_Click(object sender, EventArgs e)
        {
            Camera camera = (Camera)Enum.Parse(typeof(Camera), cbCamera.Text);
            RotateFlipType rotate;
            switch (cbRotate.SelectedIndex)
            {
                case 0:
                    rotate = RotateFlipType.RotateNoneFlipNone;
                    break;
                case 1:
                    rotate = RotateFlipType.Rotate90FlipNone;
                    break;
                case 2:
                    rotate = RotateFlipType.Rotate180FlipNone;
                    break;
                case 3:
                    rotate = RotateFlipType.Rotate270FlipNone;
                    break;
                default:
                    rotate = RotateFlipType.RotateNoneFlipNone;
                    break;
            }
            //RotateFlipType rotate = (RotateFlipType)Enum.Parse(typeof(RotateFlipType), cbRotate.Text);
            SysSetting.SysConfig.SetCamRotate(camera, rotate);
            SysSetting.SaveConfig();
        }

        private void cbCamera_SelectedIndexChanged(object sender, EventArgs e)
        {
            Camera camera = (Camera)Enum.Parse(typeof(Camera), cbCamera.Text);
            RotateFlipType rotate = SysSetting.SysConfig.DictCamRotate[camera];
            switch (rotate)
            {
                case RotateFlipType.RotateNoneFlipNone:
                    cbRotate.SelectedIndex = 0;
                    break;
                case RotateFlipType.Rotate90FlipNone:
                    cbRotate.SelectedIndex = 1;
                    break;
                case RotateFlipType.Rotate180FlipNone:
                    cbRotate.SelectedIndex = 2;
                    break;
                case RotateFlipType.Rotate270FlipNone:
                    cbRotate.SelectedIndex = 3;
                    break;
                default:
                    cbRotate.SelectedIndex = 0;
                    break;
            }
        }

        private void cbSurface_SelectedIndexChanged(object sender, EventArgs e)
        {
            Surface surface = (Surface)Enum.Parse(typeof(Surface), cbSurface.Text);
            var surfaceCfg = SysSetting.SysConfig.DictSurfaceCfg[surface];
            numericUdHcount.Value = surfaceCfg.HCount;
            numericUdVcount.Value = surfaceCfg.VCount;
            ucAreaSelect1.ClearAreas();
            ucAreaSelect1.HCount = (int)numericUdHcount.Value;
            ucAreaSelect1.VCount = (int)numericUdVcount.Value;
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
    }
}
