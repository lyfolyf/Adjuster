using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using HalconDotNet;

namespace HalconMatching
{
    public static class HExtension
    {
        [DllImport("kernel32.dll")]
        public static extern void CopyMemory(int Destination, int add, int Length);
        public static HObject ToHObject(this Bitmap bitmap)
        {
            HObject hObject;
            HOperatorSet.GenEmptyObj(out hObject);
            hObject.Dispose();
            hObject = bitmap.ToHImage();
            return hObject;
        }
        /// <summary>
        /// Bitmap 转 HImage
        /// </summary>
        /// <param name="bitmap"></param>
        /// <returns></returns>
        public static HImage ToHImage(this Bitmap bitmap)
        {
            HImage hImg = new HImage();
            try
            {
                Bitmap image = (Bitmap)bitmap.Clone();
                BitmapData bmData = image.LockBits(new Rectangle(0, 0, image.Width, image.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppRgb);
                unsafe
                {
                    // Create HALCON image from the pointer.
                    hImg.GenImageInterleaved(bmData.Scan0, "bgrx", image.Width, image.Height, -1, "byte", image.Width, image.Height, 0, 0, -1, 0);
                }
                // Don't forget to unlock the bits again. 
                image.UnlockBits(bmData);
                image.Dispose();
            }
            catch
            {
                //h_img = tmp;
            }
            return hImg;
        }

        /// <summary>
        /// HObject转24位Bitmap,net4.5及以上版本
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        public static Bitmap ToRgbBmp(this HObject image)
        {
            Bitmap bmp = null;
            try
            {
                HTuple hred, hgreen, hblue, type, width, height;

                HOperatorSet.GetImagePointer3(image, out hred, out hgreen, out hblue, out type, out width, out height);
                bmp = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format32bppRgb);
                Rectangle rect = new Rectangle(0, 0, width, height);
                BitmapData bitmapData = bmp.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format32bppRgb);
                int imglength = width * height;
                unsafe
                {
                    byte* bptr = (byte*)bitmapData.Scan0;
                    byte* r = ((byte*)hred.L);
                    byte* g = ((byte*)hgreen.L);
                    byte* b = ((byte*)hblue.L);
                    for (int i = 0; i < imglength; i++)
                    {
                        bptr[i * 4] = (b)[i];
                        bptr[i * 4 + 1] = (g)[i];
                        bptr[i * 4 + 2] = (r)[i];
                        bptr[i * 4 + 3] = 255;
                    }
                }

                bmp.UnlockBits(bitmapData);
            }
            catch (Exception ex)
            {
                bmp = null;
            }
            return bmp;
        }

        public static Bitmap ToRgbBmp2(this HObject image)
        {
            Bitmap bmp = null;
            try
            {
                HTuple hred, hgreen, hblue, type, width, height;

                HOperatorSet.GetImagePointer3(image, out hred, out hgreen, out hblue, out type, out width, out height);
                bmp = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format32bppRgb);
                Rectangle rect = new Rectangle(0, 0, width, height);
                BitmapData bitmapData = bmp.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format32bppRgb);
                int imglength = width * height;
                unsafe
                {
                    byte* bptr = (byte*)bitmapData.Scan0;
                    byte* r = ((byte*)hred.I);
                    byte* g = ((byte*)hgreen.I);
                    byte* b = ((byte*)hblue.I);
                    for (int i = 0; i < imglength; i++)
                    {
                        bptr[i * 4] = (b)[i];
                        bptr[i * 4 + 1] = (g)[i];
                        bptr[i * 4 + 2] = (r)[i];
                        bptr[i * 4 + 3] = 255;
                    }
                }

                bmp.UnlockBits(bitmapData);
            }
            catch (Exception ex)
            {
                bmp = null;
            }
            return bmp;
        }

        public static Bitmap ToGrayBmp(this HObject image)
        {
            Bitmap bmp = null;
            try
            {
                HTuple hpoint, type, width, height;

                const int Alpha = 255;
                int[] ptr = new int[2];
                HOperatorSet.GetImagePointer1(image, out hpoint, out type, out width, out height);

                bmp = new Bitmap(width, height, PixelFormat.Format8bppIndexed);
                ColorPalette pal = bmp.Palette;
                for (int i = 0; i <= 255; i++)
                {
                    pal.Entries[i] = Color.FromArgb(Alpha, i, i, i);
                }
                bmp.Palette = pal;
                Rectangle rect = new Rectangle(0, 0, width, height);
                BitmapData bitmapData = bmp.LockBits(rect, ImageLockMode.WriteOnly, PixelFormat.Format8bppIndexed);
                int PixelSize = Bitmap.GetPixelFormatSize(bitmapData.PixelFormat) / 8;
                ptr[0] = bitmapData.Scan0.ToInt32();
                ptr[1] = hpoint.I;
                if (width % 4 == 0)
                    CopyMemory(ptr[0], ptr[1], width * height * PixelSize);
                else
                {
                    for (int i = 0; i < height - 1; i++)
                    {
                        ptr[1] += width;
                        CopyMemory(ptr[0], ptr[1], width * PixelSize);
                        ptr[0] += bitmapData.Stride;
                    }
                }
                bmp.UnlockBits(bitmapData);
            }
            catch (Exception ex)
            {
                bmp = null;
            }
            return bmp;
        }
        public static void SaveImage(this Bitmap currentImage, string savePath, long photoIndex, string res = "")
        {
            if (currentImage != null)
            {
                try
                {
                    Bitmap saveimg = (Bitmap)currentImage.Clone();
                    new Thread(() =>
                        {
                            long cameranumber = photoIndex;
                            string path = savePath;
                            try
                            {
                                if (!Directory.Exists(path))
                                {
                                    Directory.CreateDirectory(path);
                                }

                                DriveInfo driveinfo = new DriveInfo(savePath);
                                long data = driveinfo.AvailableFreeSpace / (1024 * 1024 * 1024);
                                if (data > 1)//1G空间以下时删除图片
                                {
                                    //saveimg.ToSave(path + "\\" + cameranumber + "_" + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + ".tiff");
                                    saveimg.Save(path + "\\" + cameranumber + "_" + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + res + ".bmp", ImageFormat.Bmp);
                                }
                                else
                                {
                                    Directory.Delete(path, true);
                                    new Thread(new ThreadStart(delegate ()
                                        {
                                            MessageBox.Show("磁盘空间有限,删除已保存的图片");
                                        }))
                                        { IsBackground = false }.Start();
                                }
                            }
                            catch (Exception ex)
                            {


                            }


                        })
                        { IsBackground = true }.Start();
                }
                catch (Exception ex)
                {


                }
            }
        }
    }
}