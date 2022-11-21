using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adjuster
{
    public class HeatMapViewer : Bing.Viewer.ImageViewer
    {
        public HeatMapViewer()
        {
            AutoFit = true;
            // 构建一组颜色映射以将我们的灰度蒙版重新映射为全色
            colorMaps = CreatePalette();
        }
        public Bitmap HotMap
        {
            set
            {
                var bmp = ConvertTo8BitBitmap(value as Bitmap);
                this.Image = Colorize(bmp);
            }
        }
        ColorMap[] colorMaps;
        public Bitmap Colorize(Bitmap mask)
        {
            //创建新的位图，为上色做准备
            Bitmap output = new Bitmap(mask.Width, mask.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            //同理，从Bitmap获得Graphics GDI+ 绘图图面
            Graphics graphics = Graphics.FromImage(output);
            //清除整个绘图面并以透明填充
            graphics.Clear(System.Drawing.Color.Transparent);

            // 创建新的图像属性类来处理颜色重新映射
            // 注入我们的颜色映射数组来指示图像属性类如何进行着色
            ImageAttributes Remapper = new ImageAttributes();
            Remapper.SetRemapTable(colorMaps);
            // 使用新的颜色映射方案将我们的蒙版绘制到我们的内存位图工作表面上
            graphics.DrawImage(mask, new System.Drawing.Rectangle(0, 0, mask.Width, mask.Height), 0, 0, mask.Width, mask.Height, GraphicsUnit.Pixel, Remapper);
            return output;
        }

        //创建调色板，颜色映射
        private ColorMap[] CreatePalette()
        {
            ColorMap[] colorMaps = new ColorMap[256];
            List<Color> newColors = new List<Color>();

            //颜色集合
            newColors.AddRange(GetGradientColorList(Color.Red, Color.Yellow, 64));
            newColors.AddRange(GetGradientColorList(Color.Yellow, Color.Green, 64));
            newColors.AddRange(GetGradientColorList(Color.Green, Color.Blue, 64));
            newColors.AddRange(GetGradientColorList(Color.Blue, Color.Navy, 64));

            ////颜色调色板展示
            //Bitmap colorBitmap = new Bitmap(colorPanel.Width, colorPanel.Height);

            //Graphics graphic = Graphics.FromImage(colorBitmap);
            //for (int i = 0; i < 256; i++)
            //{
            //    SolidBrush solidBrush = new SolidBrush(newColors[i]);
            //    RectangleF rectangle = new RectangleF(i * (float)colorPanel.Width / 255, 0, (float)colorPanel.Width / 255, colorPanel.Height);
            //    graphic.FillRectangle(solidBrush, rectangle);
            //    graphic.Save();
            //    solidBrush.Dispose();
            //}
            //colorPanel.BackgroundImage = colorBitmap;

            // 遍历每个像素并创建一个新的颜色映射
            for (int X = 0; X <= 255; X++)
            {
                colorMaps[X] = new ColorMap();
                colorMaps[X].OldColor = System.Drawing.Color.FromArgb(X, X, X);
                colorMaps[X].NewColor = System.Drawing.Color.FromArgb(255, newColors[255 - X]);
            }
            return colorMaps;
        }

        /// <summary>
        /// 获得两个颜色之间渐进颜色的集合
        /// </summary>
        /// <param name="sourceColor">起始颜色</param>
        /// <param name="destColor">终止颜色</param>
        /// <param name="count">渐进颜色的个数</param>
        /// <returns>返回颜色集合</returns>
        public static List<Color> GetGradientColorList(Color srcColor, Color desColor, int count)
        {
            List<Color> colorFactorList = new List<Color>();
            int redSpan = desColor.R - srcColor.R;
            int greenSpan = desColor.G - srcColor.G;
            int blueSpan = desColor.B - srcColor.B;
            for (int i = 0; i < count; i++)
            {
                Color color = Color.FromArgb(
                    srcColor.R + (int)((double)i / count * redSpan),
                    srcColor.G + (int)((double)i / count * greenSpan),
                    srcColor.B + (int)((double)i / count * blueSpan)
                );
                colorFactorList.Add(color);
            }
            return colorFactorList;
        }

        public static unsafe Bitmap ConvertTo8BitBitmap(Bitmap source)
        {
            var bit = new Bitmap(source.Width, source.Height, PixelFormat.Format8bppIndexed);
            BitmapData data = source.LockBits(new Rectangle(0, 0, source.Width, source.Height), ImageLockMode.ReadOnly,
                                           PixelFormat.Format24bppRgb);
            var bp = (byte*)data.Scan0.ToPointer();
            BitmapData data2 = bit.LockBits(new Rectangle(0, 0, bit.Width, bit.Height), ImageLockMode.ReadWrite,
                                            PixelFormat.Format8bppIndexed);
            var bp2 = (byte*)data2.Scan0.ToPointer();
            for (int i = 0; i != data.Height; i++)
            {
                for (int j = 0; j != data.Width; j++)
                {
                    //0.3R+0.59G+0.11B
                    float value = 0.11F * bp[i * data.Stride + j * 3] + 0.59F * bp[i * data.Stride + j * 3 + 1] +
                                  0.3F * bp[i * data.Stride + j * 3 + 2];
                    bp2[i * data2.Stride + j] = (byte)value;
                }
            }
            source.UnlockBits(data);
            bit.UnlockBits(data2);
            ColorPalette palette = bit.Palette;
            for (int i = 0; i != palette.Entries.Length; i++)
            {
                palette.Entries[i] = Color.FromArgb(i, i, i);
            }
            bit.Palette = palette;
            return bit;
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // HeatMapViewer
            // 
            this.AutoFit = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.Name = "HeatMapViewer";
            this.ShowCrood = true;
            this.ResumeLayout(false);

        }
    }
}
