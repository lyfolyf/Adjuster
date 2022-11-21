using System;

namespace Adjuster.Tools
{

    public struct IntensityInfo
    {
        public double Mean { get; set; }
        public double MeanRed { get; set; }
        public double MeanGreen { get; set; }
        public double MeanBlue { get; set; }
        public int Median { get; set; }
        public int Minimum { get; set; }
        public int Maximum { get; set; }
        public double StandardDeviation { get; set; }
        public double Variance { get; set; }
        public double Bright
        {
            get { return Math.Round(Mean / 255, 3); }
            internal set { Mean = 255 * value; }
        }
        public double RG
        {
            get { return Math.Round(MeanRed / MeanGreen, 3); }
            internal set { MeanRed = MeanGreen * value; }
        }
        public double BG
        {
            get { return Math.Round(MeanBlue / MeanGreen, 3); }
            internal set { MeanBlue = MeanGreen * value; }
        }
    }
}
