using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Adjuster.Camera;

namespace Adjuster.UC
{
    public partial class UcCamera : UcPanel
    {
        public UcCamera()
        {
            InitializeComponent();
        }
        internal List<CameraInfo> cameraInfos { get; set; } = new List<CameraInfo>();
        HikCamera camera = new HikCamera();
        public event ImageTookEventHandler ImageTook;
        public bool continueMode = false;
        bool ready = true;
        bool load = false;
        private void UcCamera_Load(object sender, EventArgs e)
        {
            camera.ImageTook += Camera_ImageTook;
            camera.DataBack += Camera_DataBack;
            camera.DataTranslation += Camera_DataTranslation;
            load = true;
            //InitCameraList();
        }

        private void Camera_DataTranslation(double elapsed)
        {
            this.Invoke(new Action(() => { label8.Text = $"转换：{elapsed}ms"; }));
        }

        private void Camera_DataBack()
        {
            this.Invoke(new Action(() => { label7.Text = $"回传：{camera.Elapsed}ms"; }));
        }

        private void Camera_ImageTook(object sender, ImageTookEventArgs e)
        {
            ImageTook?.Invoke(sender, e);
            ready = true;
        }

        private void InitCameraList()
        {
            cameraInfos = HikCamera.DeviceList();
            cbDeviceList.Items.Clear();
            for (int i = 0; i < cameraInfos.Count; i++)
            {
                cbDeviceList.Items.Add(cameraInfos[i].ToString());
            }

            if (cameraInfos.Count > 0)
            {
                cbDeviceList.SelectedIndex = 0;
            }
        }
        private void ShowCameraStatus(CameraStatus status)
        {
            Invoke(new Action(() =>
            {
                switch (status)
                {
                    case CameraStatus.Accessible:
                        pStatus.BackColor = Color.Yellow;
                        break;
                    case CameraStatus.UnAccessible:
                        pStatus.BackColor = Color.OrangeRed;
                        break;
                    case CameraStatus.Opened:
                        pStatus.BackColor = Color.Lime;
                        break;
                    default:
                        pStatus.BackColor = Color.Gray;
                        break;
                }
            }));
        }
        enum CameraStatus
        {
            Accessible,
            UnAccessible,
            Opened
        }
        private void btnRefreshCameraList_Click(object sender, EventArgs e)
        {
            InitCameraList();
        }

        private void cbDeviceList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var index = cbDeviceList.SelectedIndex;
            CameraInfo cameraInfo = cameraInfos[index];
            camera.SN = cameraInfo.SN;
            var accessible = camera.Accessible;
            CameraStatus status = accessible ? CameraStatus.Accessible : CameraStatus.UnAccessible;
            ShowCameraStatus(status);
            if (accessible)
            {
                btnOpenCamera.Enabled = true;
            }
        }

        private void btnOpenCamera_Click(object sender, EventArgs e)
        {
            if (camera.Open())
            {
                cbDeviceList.Enabled = false;
                btnClose.Enabled = true;
                btnOpenCamera.Enabled = false;
                btnrefleshCameraList.Enabled = false;
                gbCameraSetting.Enabled = true;
                btnSnop.Enabled = true;
                btnMWB.Enabled = true;
                ckbUseLsc.Enabled = true;
                btnResetLsc.Enabled = true;
                ShowCameraStatus(CameraStatus.Opened);
                btnGetParam_Click(null, null);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            ckbTriggerMode.Checked = false;
            continueMode = ckbTriggerMode.Checked;
            if (camera.Close())
            {
                cbDeviceList.Enabled = true;
                btnOpenCamera.Enabled = true;
                btnClose.Enabled = false;
                btnrefleshCameraList.Enabled = true;
                gbCameraSetting.Enabled = false;
                btnSnop.Enabled = false;
                btnMWB.Enabled = false;
                ckbUseLsc.Enabled = false;
                btnResetLsc.Enabled = false;
                ShowCameraStatus(CameraStatus.Accessible);
            }
        }

        private void ckbTriggerMode_CheckedChanged(object sender, EventArgs e)
        {
            //camera.TriggerMode = ckbTriggerMode.Checked ? TriggerModeConstants.Software : TriggerModeConstants.Off;
            continueMode = ckbTriggerMode.Checked;
        }

        private void chkBalanceWhiteAuto_CheckedChanged(object sender, EventArgs e)
        {
            uint mode = chkBalanceWhiteAuto.Checked ? 1u : 0;
            camera.BalanceWhiteAuto = mode;
        }

        private void btnGetParam_Click(object sender, EventArgs e)
        {
            GetParams();
        }

        private void GetParams()
        {
            if (!load)
            {
                return;
            }
            if (camera != null)
            {
                this.Invoke(new Action(() =>
                {
                    txtExposure.Text = camera.Exposure.ToString();
                    txtGain.Text = camera.Gain.ToString();
                    txtFrameRate.Text = camera.FrameRate.ToString();
                    //ckbTriggerMode.Checked = camera.TriggerMode == TriggerModeConstants.Software;
                    try
                    {
                        txtRRatio.Text = camera.RatioR.ToString();
                    }
                    catch (Exception)
                    {
                        // ignored
                    }
                    try
                    {
                        txtGRatio.Text = camera.RatioG.ToString();
                    }
                    catch (Exception)
                    {
                        // ignored
                    }
                    try
                    {
                        txtBRatio.Text = camera.RatioB.ToString();
                    }
                    catch (Exception)
                    {
                        // ignored
                    }
                    try
                    {
                        chkBalanceWhiteAuto.Checked = camera.BalanceWhiteAuto == 1u;
                    }
                    catch (Exception)
                    {
                        // ignored
                    }

                    ckbUseLsc.Checked = camera.UseLsc;
                }));
            }
        }

        private void btnSetParam_Click(object sender, EventArgs e)
        {
            if (camera != null)
            {
                this.Invoke(new Action(() =>
                {
                    camera.Exposure = GetDValue(txtExposure);
                    camera.Gain = GetDValue(txtGain);
                    try
                    {
                        camera.RatioR = GetUValue(txtRRatio);
                    }
                    catch (Exception)
                    {
                        // ignored
                    }
                    try
                    {
                        camera.RatioG = GetUValue(txtGRatio);
                    }
                    catch (Exception)
                    {
                        // ignored
                    }
                    try
                    {
                        camera.RatioB = GetUValue(txtBRatio);
                    }
                    catch (Exception)
                    {
                        // ignored
                    }
                }));
            }
        }

        private double GetDValue(TextBox textBox)
        {
            double val = 0;
            double.TryParse(textBox.Text, out val);
            return val;
        }
        private int GetIValue(TextBox textBox)
        {
            int val = 0;
            int.TryParse(textBox.Text, out val);
            return val;
        }

        private uint GetUValue(TextBox textBox)
        {
            uint val = 0;
            uint.TryParse(textBox.Text, out val);
            return val;
        }

        private void btnGetOneImage_Click(object sender, EventArgs e)
        {
            Snop();
        }

        public void Snop()
        {
            camera?.TriggerOnce();
        }

        private void btnMWB_Click(object sender, EventArgs e)
        {
            camera.RunBalanceWhiteAuto();
            btnGetParam_Click(null, null);
        }

        private void ckbUseLsc_CheckedChanged(object sender, EventArgs e)
        {
            camera.UseLsc = ckbUseLsc.Checked;
        }

        private void btnResetLsc_Click(object sender, EventArgs e)
        {
            camera.IsNeedLSCCalib = true;
            camera.TriggerOnce();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (continueMode)
            {
                if (ready)
                {
                    ready = false;
                    camera.TriggerOnce();
                }
            }
        }
        public uint RatioR
        {
            set
            {
                if (camera != null)
                    camera.RatioR = value;
                GetParams();
            }
            get { return camera.RatioR; }
        }
        public uint RatioG
        {
            set
            {
                if (camera != null)
                    camera.RatioG = value;
                GetParams();
            }
            get { return camera.RatioG; }
        }

        public uint RatioB
        {
            set
            {
                if (camera != null)
                    camera.RatioB = value;
                GetParams();
            }
            get { return camera.RatioB; }
        }
        public double Exposure
        {
            set
            {
                if (camera != null)
                    camera.Exposure = value;
                GetParams();
            }
            get { return camera.Exposure; }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            int r = (int)camera.RatioR;
            int g = (int)camera.RatioG;
            int b = (int)camera.RatioB;
            BalanceConfig balanceConfig = new BalanceConfig(camera.SN);
            balanceConfig.RedRatio = r;
            balanceConfig.GreenRatio = g;
            balanceConfig.BlueRatio = b;
            balanceConfig.SaveConfig();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            var path = $@"{Environment.CurrentDirectory}\CameraBalanceConfig\{camera.SN}.cfg";
            if (System.IO.File.Exists(path))
            {
                BalanceConfig balanceConfig = BalanceConfig.LoadConfig(camera.SN);
                camera.RatioR = (uint)balanceConfig.RedRatio;
                camera.RatioG = (uint)balanceConfig.GreenRatio;
                camera.RatioB = (uint)balanceConfig.BlueRatio;
                btnGetParam_Click(null, null);
            }
        }
    }
}
