using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bing.Viewer;
using System.Drawing.Imaging;

namespace Adjuster.Tools
{
    internal static class ImageProcessing
    {

        public static ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();

            foreach (var item in codecs)
            {
                if (item.FormatID == format.Guid)
                {
                    return item;
                }
            }
            return null;
        }

        public static void SaveBitmapToJepgFile(this Bitmap bmp, string path, long quality)
        {
            if (bmp == null)
            {
                return;
            }
            Bitmap tmp = bmp.Clone() as Bitmap;
            System.Drawing.Imaging.Encoder myEncoder = System.Drawing.Imaging.Encoder.Quality;
            ImageCodecInfo jpgEncoder = GetEncoder(ImageFormat.Jpeg);
            EncoderParameters myEncoderParameters = new EncoderParameters(1);
            EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, quality);
            myEncoderParameters.Param[0] = myEncoderParameter;
            tmp.Save(path, jpgEncoder, myEncoderParameters);
            tmp.Dispose();
        }
        public static Bitmap GetCutImage(Image image, Bing.Viewer.BingRectangle rect)
        {
            Bitmap bmp = new Bitmap((int)rect.Width, (int)rect.Height);// new Rectangle(0, 0, image.Width, image.Height)
            Rectangle cropRect = new Rectangle((int)rect.X, (int)rect.Y, (int)rect.Width, (int)rect.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.DrawImage(image, 0, 0,
                    cropRect,
                    GraphicsUnit.Pixel);
            }
            return bmp;
        }
        public static double GetFocusValue(Image image, int level)
        {
            double rt = 0;
            Bitmap bmp = new Bitmap(image);
            //level = bmp.Height / level;
            LockBitmap lockBitmap = new LockBitmap(bmp);
            lockBitmap.LockBits();
            for (int y = 0; y < lockBitmap.Height - 1; y += level)
            {
                for (int x = 0; x < lockBitmap.Width - 1; x++)
                {

                    int val0 = lockBitmap.GetGray(x, y);
                    int val1 = lockBitmap.GetGray(x, y + 1);
                    int val2 = lockBitmap.GetGray(x + 1, y);

                    double val = Math.Pow((val1 - val0), 2) + Math.Pow((val2 - val0), 2);
                    rt += val;
                }
            }
            lockBitmap.UnlockBits();
            rt = Math.Round(Math.Sqrt(rt), 2);
            return rt;
        }

        public static void Intensity(Bitmap bmp, out double mean, out int median, out int minimum, out int maximum, out double standardDeviation, out double variance, out double bright)
        {
            List<int> total = new List<int>();
            bright = 0;
            standardDeviation = 0;
            variance = 0;
            LockBitmap lockbmp = new LockBitmap(bmp);
            lockbmp.LockBits();
            var cCount = lockbmp.Depth / 8;
            for (int i = 0; i < lockbmp.Pixels.Length; i += cCount)
            {
                int r = lockbmp.Pixels[i + 2];
                int g = lockbmp.Pixels[i + 1];
                int b = lockbmp.Pixels[i];
                int grayVal = (byte)(.299 * r + .587 * g + .114 * b);
                total.Add(grayVal);
                bright += grayVal;
            }
            lockbmp.UnlockBits();
            mean = Math.Round(bright / total.Count, 2);
            total.Sort();
            minimum = total[0];
            maximum = total[total.Count - 1];
            int m = total.Count / 2;
            median = total[m];
            foreach (var item in total)
            {
                standardDeviation += Math.Abs(item - mean);
                variance += Math.Pow(item - mean, 2);
            }
            standardDeviation = standardDeviation / total.Count;
            variance = variance / total.Count;
            bright = Math.Round(bright / (bmp.Width * bmp.Height * 255) * 100, 1);
        }

        public static IntensityInfo Intensity(Bitmap bmp, Rectangle rect)
        {
            var bitmapData = bmp.LockBits(rect, ImageLockMode.ReadWrite,
                                           bmp.PixelFormat);
            var intensityInfo = Intensity(bitmapData);
            bmp.UnlockBits(bitmapData);
            return intensityInfo;
        }

        public static IntensityInfo Intensity(byte[] Pixels, int Depth, int Width, int Height, Rectangle rect)
        {
            IntensityInfo intensityInfo = new IntensityInfo();

            try
            {
                long count = rect.Width * rect.Height;
                //List<int> total = new List<int>();
                //List<int> totalR = new List<int>();
                //List<int> totalG = new List<int>();
                //List<int> totalB = new List<int>();
                //double bright = 0;
                //double brightR = 0;
                //double brightG = 0;
                //double brightB = 0;
                double standardDeviation = 0;
                double variance = 0;
                double mean = 0;
                double meanR = 0;
                double meanG = 0;
                double meanB = 0;
                int minimum = 0;
                int maximum = 0;
                int median = 0;

                var cCount = Depth / 8;
                Rectangle rawRect = new Rectangle(0, 0, Width, Height);
                if (rect != rawRect)
                {
                    int sx = rect.X;
                    int ex = rect.X + rect.Width;

                    for (int y = rect.Y; y < rect.Y + rect.Height; y++)
                    {
                        int si = ((y * Width) + sx) * cCount;
                        int ei = ((y * Width) + ex) * cCount;

                        for (int i = si; i < ei - cCount; i += cCount)
                        {
                            int r = Pixels[i + 2];
                            int g = Pixels[i + 1];
                            int b = Pixels[i];
                            int grayVal = (byte)(.299 * r + .587 * g + .114 * b);
                            //total.Add(grayVal);
                            //totalR.Add(r);
                            //totalG.Add(g);
                            //totalB.Add(b);

                            //brightR += r;
                            //brightG += g;
                            //brightB += b;
                            //bright += grayVal;

                            mean += (double)grayVal / count;
                            meanR += (double)r / count;
                            meanG += (double)g / count;
                            meanB += (double)b / count;

                            minimum = minimum < grayVal ? minimum : grayVal;
                            maximum = maximum > grayVal ? maximum : grayVal;

                        }
                    }
                }
                else
                {
                    for (int i = 0; i < Pixels.Length; i += cCount)
                    {
                        int r = Pixels[i + 2];
                        int g = Pixels[i + 1];
                        int b = Pixels[i];
                        int grayVal = (byte)(.299 * r + .587 * g + .114 * b);
                        //total.Add(grayVal);
                        //totalR.Add(r);
                        //totalG.Add(g);
                        //totalB.Add(b);

                        //brightR += r;
                        //brightG += g;
                        //brightB += b;
                        //bright += grayVal;

                        mean += (double)grayVal / count;
                        meanR += (double)r / count;
                        meanG += (double)g / count;
                        meanB += (double)b / count;

                        minimum = minimum < grayVal ? minimum : grayVal;
                        maximum = maximum > grayVal ? maximum : grayVal;
                    }
                }


                //total.Sort();
                //minimum = total[0];
                //maximum = total[total.Count - 1];
                //int m = total.Count / 2;
                //median = total[m];
                //foreach (var item in total)
                //{
                //    standardDeviation += Math.Abs(item - mean);
                //    variance += Math.Pow(item - mean, 2);
                //}
                //standardDeviation = Math.Round(standardDeviation / total.Count, 3);
                //variance = Math.Round(variance / total.Count, 3);
                //bright = Math.Round(bright / (Width * Height * 255) * 100, 1);
                //intensityInfo.Bright = bright;
                intensityInfo.Maximum = maximum;
                intensityInfo.Mean = mean;
                intensityInfo.MeanBlue = meanB;
                intensityInfo.MeanGreen = meanG;
                intensityInfo.MeanRed = meanR;
                intensityInfo.Median = median;
                intensityInfo.Minimum = minimum;
                intensityInfo.StandardDeviation = standardDeviation;
                intensityInfo.Variance = variance;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return intensityInfo;
        }

        public static IntensityInfo Intensity(BitmapData bmpData, Rectangle rect)
        {
            try
            {
                int Depth = Image.GetPixelFormatSize(bmpData.PixelFormat);
                var Width = bmpData.Width;
                var Height = bmpData.Height;
                int PixelCount = Width * Height;
                Rectangle rawRect = new Rectangle(0, 0, Width, Height);
                if (Depth != 8 && Depth != 24 && Depth != 32)
                {
                    throw new ArgumentException("Only 8, 24 and 32 bpp images are supported.");
                }
                int step = Depth / 8;
                byte[] Pixels = new byte[PixelCount * step];
                IntPtr Iptr = IntPtr.Zero;
                Iptr = bmpData.Scan0;
                // Copy data from pointer to array
                System.Runtime.InteropServices.Marshal.Copy(Iptr, Pixels, 0, Pixels.Length);

                return Intensity(Pixels, Depth, Width, Height, rect);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public static IntensityInfo Intensity(BitmapData bmpData)
        {

            Rectangle rect = new Rectangle(0, 0, bmpData.Width, bmpData.Height);
            return Intensity(bmpData, rect);
        }
        public static IntensityInfo Intensity(Bitmap bmp)
        {
            Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            return Intensity(bmp, rect);
        }
    }
}
