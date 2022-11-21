using Adjuster.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Adjuster.UC
{
    public partial class UcIntensityInfo : UcPanel
    {
        public UcIntensityInfo()
        {
            InitializeComponent();
        }

        IntensityInfo intensityInfo = new IntensityInfo();

        public IntensityInfo IntensityInfo
        {
            get
            {
                return intensityInfo;
            }
            set
            {
                intensityInfo = value;
                this.Invoke(new Action(() =>
                {
                    lblBG.Text = $"{value.BG}";
                    lblBright.Text = $"{value.Bright}";
                    lblMax.Text = $"{value.Maximum}";
                    lblMean.Text = $"{value.Mean}";
                    lblMeanB.Text = $"{value.MeanBlue}";
                    lblMeanG.Text = $"{value.MeanGreen}";
                    lblMeanR.Text = $"{value.MeanRed}";
                    lblMedian.Text = $"{value.Median}";
                    lblMin.Text = $"{value.Minimum}";
                    lblRG.Text = $"{value.RG}";
                    lblStandardDeviation.Text = $"{value.StandardDeviation}";
                    lblVariance.Text = $"{value.Variance}";
                }));
            }
        }

    }
}
