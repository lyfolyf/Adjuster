using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adjuster.Camera
{
    public delegate void ImageTookEventHandler(object sender, ImageTookEventArgs e);
    public class ImageTookEventArgs : EventArgs
    {
        public bool Success { get; set; } = false;
        public string CameraName { get; set; } = string.Empty;
        public Bitmap Image { get; set; }
        public string ErrorMessage { get; internal set; }
    }

    [Serializable]
    public enum TriggerModeConstants
    {
        /// <summary>
        /// 外触发
        /// </summary>
        Extern,
        /// <summary>
        /// 软触发
        /// </summary>
        Software,
        Off
    }
}
