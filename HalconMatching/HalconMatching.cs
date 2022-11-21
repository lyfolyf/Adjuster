using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using HalconDotNet;

namespace HalconMatching
{
    public class HalconMatching : IMatching
    {
        private HTuple hv_ModelID;
        private HImage pattern = new HImage();
        HImage ho_SearchImage = new HImage();
        private Image trainImage = null;
        private bool modelCreated = false;
        public Image TrainImage
        {
            get { return trainImage; }

            set
            {
                trainImage = value;
            }
        }

        public string Name
        {
            get { return nameof(this.GetType); }
        }

        public void CreateModel()
        {
            pattern.Dispose();
            pattern = new Bitmap(trainImage).ToHImage();
            HOperatorSet.CreateShapeModel(pattern, "auto", -0.39, 0.79, "auto", "auto",
                "use_polarity", "auto", "auto", out hv_ModelID);
            modelCreated = true;
        }

        public void FindModel(Image image, out double x, out double y, out double angle)
        {
            if (!modelCreated)
            {
                x = y = angle = -1;
                return;
            }
            ho_SearchImage.Dispose();
            ho_SearchImage = new Bitmap(image).ToHImage();
            HTuple hv_Row = new HTuple(), hv_Column = new HTuple();
            HTuple hv_Angle = new HTuple(), hv_Score = new HTuple();
            HOperatorSet.FindShapeModel(ho_SearchImage, hv_ModelID, -0.39, 0.79, 0.1, 1,
                0.5, "least_squares", 0, 0.9, out hv_Row, out hv_Column, out hv_Angle,
                out hv_Score);
            if (hv_Row.Length > 0)
            {
                x = hv_Column;
                y = hv_Row;
                angle = hv_Angle;
            }
            else
            {
                x = y = angle = -1;
            }
        }

        public void Reset()
        {
            HOperatorSet.ClearShapeModel(hv_ModelID);
            pattern.Dispose();
            ho_SearchImage.Dispose();
            trainImage = null;
            modelCreated = false;
        }
    }
}
