using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 拼接
{
    public partial class FrmViewer : Form
    {
        private string path = @"D:\Images";

        private List<string> productList = new List<string>();

        /// <summary>
        /// 保存图像分辨率
        /// </summary>
        private float res = 1f;

        private List<string> selectImages = new List<string>();

        private string selectProduct = string.Empty;

        private string sn = string.Empty;

        public FrmViewer()
        {
            InitializeComponent();
            ucAreaSelect1.AeraClick += UcAreaSelect1_AeraClick;
        }
        private void btnReflesh_Click(object sender, EventArgs e)
        {
            GetProductList();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var sn = txtSn.Text;
            if (sn == String.Empty)
            {
                return;
            }
            if (productList.Count(k => k.Contains(sn)) > 0)
            {
                var f = productList.First(k => k.Contains(sn));
                cbProducts.Text = f;
            }
        }

        private void btnSetPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                path = folderBrowserDialog.SelectedPath;
                txtPath.Text = path;
                GetProductList();
            }
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            FrmRuleManagement frmRuleManagement = new FrmRuleManagement();
            frmRuleManagement.Show();
            frmRuleManagement.FormClosed += (s, arge) =>
            {
                cbRule.DataSource = null;
                cbRule.DataSource = SysSetting.Rules.RuleNames;
            };

        }

        //J413.Silver2.CosmeticAOI.20211213.183757.TC.Polarize.1_1.jpg
        private void button2_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                Rule rule = new Rule();
                this.Invoke(new Action(() =>
                {
                    viewer1.Enabled = false;
                    panel1.Enabled = false;
                    if (cbRule.SelectedIndex == -1)
                    {
                        return;
                    }
                    if (!SysSetting.Rules.FindRule(cbRule.SelectedItem.ToString(), out rule))
                        return;
                }));
                Dictionary<Point, Bitmap> imgDict = new Dictionary<Point, Bitmap>();

                foreach (var file in selectImages)
                {

                    Bitmap bitmap = new Bitmap(file);
                    Point p = new Point(1, 1);
                    if (rule.Matching(file, out ImageStackingUnit stackingUnit))
                    {
                        var rotate = stackingUnit.Rotate;
                        this.Invoke(new Action(() => ucAreaSelect1.SetAreaSelected(stackingUnit.Pos.Y, stackingUnit.Pos.X, true)));
                        bitmap.RotateFlip(rotate);
                        p = stackingUnit.Pos;

                        FileInfo fileInfo = new FileInfo(file);
                        var infos = fileInfo.Name.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
                        var pos = infos[8];

                        if (imgDict.ContainsKey(p))
                        {
                            imgDict[p] = bitmap;
                        }
                        else
                        {
                            imgDict.Add(p, bitmap);
                        }
                        this.Invoke(new Action(() => { viewer1.Image = imgDict[p]; }));
                    }

                }
                System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
                sw.Start();
                Union(imgDict);
                sw.Stop();
                this.Invoke(new Action(() =>
                {
                    lblMsg.Text = $"合成耗时 {sw.Elapsed.TotalMilliseconds:0.00} ms";
                    panel1.Enabled = true;
                    viewer1.Enabled = true;
                }));
            });
        }

        private void cbProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Invoke(new Action(() =>
            {
                selectProduct = cbProducts.Text;
                DirectoryInfo directoryInfo = new DirectoryInfo(selectProduct);
                sn = directoryInfo.Name;
                txtSn.Text = sn;
                if (Directory.Exists(selectProduct))
                {
                    if (cbRule.SelectedIndex == -1)
                    {
                        return;
                    }
                    if (SysSetting.Rules.FindRule(cbRule.SelectedItem.ToString(), out Rule rule))
                    {
                        ResetAreas(rule);
                        Search(rule);
                    }
                }
            }));
        }

        private void cbRule_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbRule.SelectedIndex == -1)
            {
                return;
            }
            if (SysSetting.Rules.FindRule(cbRule.SelectedItem.ToString(), out Rule rule))
            {
                ResetAreas(rule);
                Search(rule);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GetProductList();
            cbRule.DataSource = null;
            cbRule.DataSource = SysSetting.Rules.RuleNames;
        }

        private void GetProductList()
        {
            productList = new List<string>();
            if (System.IO.Directory.Exists(path))
            {
                productList = System.IO.Directory.GetDirectories(path).ToList();
                cbProducts.DataSource = productList;
                label6.Text = $"共{productList.Count}个文件夹";
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Bitmap bitmap = new Bitmap(listBox1.Text);
            if (cbRule.SelectedIndex == -1)
            {
                return;
            }
            if (SysSetting.Rules.FindRule(cbRule.SelectedItem.ToString(), out Rule rule))
            {
                var file = listBox1.Text;
                if (rule.Matching(file, out ImageStackingUnit stackingUnit))
                {
                    var rotate = stackingUnit.Rotate;
                    ucAreaSelect1.SetAreaSelected(stackingUnit.Pos.Y, stackingUnit.Pos.X, true);
                    bitmap.RotateFlip(rotate);
                }
            }

            viewer1.Image = bitmap;
        }

        private void rbRes1_2_CheckedChanged(object sender, EventArgs e)
        {
            res = 0.5f;
        }

        private void rbRes1_4_CheckedChanged(object sender, EventArgs e)
        {
            res = 0.25f;
        }

        private void rbRes1_8_CheckedChanged(object sender, EventArgs e)
        {
            res = 0.125f;
        }

        private void rbRes1_CheckedChanged(object sender, EventArgs e)
        {
            res = 1f;
        }

        private void ResetAreas(Rule rule)
        {
            ucAreaSelect1.ClearAreas();
            ucAreaSelect1.HCount = rule.HCount;
            ucAreaSelect1.VCount = rule.VCount;
            var index = 0;
            for (int x = 0; x < ucAreaSelect1.VCount; x++)
            {
                for (int y = 0; y < ucAreaSelect1.HCount; y++)
                {
                    Point p = new Point(x + 1, y + 1);
                    index++;

                    var dispyName = rule.GetDisplayName(p);
                    AreaInfo areaInfo = new AreaInfo()
                    {
                        Color = Color.Blue,
                        Column = x + 1,
                        Row = y + 1,
                        Selected = false,
                        Block = dispyName,
                        Info = dispyName
                    };
                    ucAreaSelect1.AddArea(areaInfo);
                }
            }
        }
        private void Search(Rule rule)
        {
            if (!Directory.Exists(selectProduct))
                return;
            selectImages = new List<string>();
            var allFiles = Directory.GetFiles(selectProduct);
            List<string> mFiles = new List<string>();
            foreach (var file in allFiles)
            {
                if (rule.Matching(file, out ImageStackingUnit stackingUnit))
                {
                    mFiles.Add(file);
                }
            }
            selectImages = mFiles;
            listBox1.DataSource = selectImages;
            label8.Text = $"找到{selectImages.Count}张图像";
        }

        private List<string> SearchDirectories(string path, bool add)
        {
            List<string> folders = new List<string>();
            var dirs = System.IO.Directory.GetDirectories(path);
            if (add)
            {
                folders.AddRange(dirs);
            }
            foreach (var item in dirs)
            {
                folders.AddRange(SearchDirectories(item, !add));
            }
            return folders;
        }

        private void UcAreaSelect1_AeraClick(object sender, AreaSelectEventArgs e)
        {
            Point p = new Point(e.Column, e.Row);
            ucAreaSelect1.SetAreaSelected(e.Row, e.Column, true);
            if (cbRule.SelectedIndex == -1)
            {
                return;
            }
            if (SysSetting.Rules.FindRule(cbRule.SelectedItem.ToString(), out Rule rule))
            {
                if (rule.FindUnit(p, out ImageStackingUnit stackingUnit))
                {
                    foreach (var file in selectImages)
                    {
                        if (stackingUnit.Matching(file))
                        {
                            listBox1.Text = file;
                            break;
                        }
                    }
                }

            }
        }

        private void Union(Dictionary<Point, Bitmap> imgDict)
        {
            int xs = 0;
            int ys = 0;
            int xl = 0;
            int yl = 0;
            int h = 0;
            int VC = 0;
            int HC = 0;
            this.Invoke(new Action(() =>
            {
                if (cbRule.SelectedIndex == -1)
                {
                    return;
                }
                if (SysSetting.Rules.FindRule(cbRule.SelectedItem.ToString(), out Rule rule))
                {
                    VC = rule.VCount;
                    HC = rule.HCount;
                }
            }));

            for (int x = 0; x < VC; x++)
            {
                ys = 0;
                for (int y = 0; y < HC; y++)
                {
                    Point p = new Point(x + 1, y + 1);
                    if (!imgDict.ContainsKey(p))
                    {
                        ys += yl;
                        continue;
                    }
                    Bitmap bitmap = imgDict[p];

                    xl = xl > bitmap.Width ? xl : bitmap.Width;
                    yl = yl > bitmap.Height ? yl : bitmap.Height;
                    ys += yl;
                }
                xs += xl;
                h = h > ys ? h : ys;
            }

            Bitmap bmp = new Bitmap(xs, h);

            xs = 0;
            ys = 0;
            xl = 0;
            yl = 0;
            using (var g = Graphics.FromImage(bmp))
            {
                for (int x = 0; x < VC; x++)
                {
                    ys = 0;
                    for (int y = 0; y < HC; y++)
                    {
                        //System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
                        //sw.Start();

                        Point p = new Point(x + 1, y + 1);
                        if (!imgDict.ContainsKey(p))
                        {
                            ys += yl;
                            continue;
                        }
                        Bitmap bitmap = imgDict[p];
                        var rect = new RectangleF(xs, ys, bitmap.Width, bitmap.Height);
                        g.DrawImage(bitmap, rect);
                        xl = xl > bitmap.Width ? xl : bitmap.Width;
                        yl = yl > bitmap.Height ? yl : bitmap.Height;
                        ys += yl;

                        //sw.Stop();
                        //MessageBox.Show($" {p.X}_{p.Y} 写入大图耗时 : {sw.Elapsed.TotalMilliseconds:0.00} ms");
                    }
                    xs += xl;
                }
            }
            if (res != 1)
            {
                RectangleF srcRect = new RectangleF(0, 0, bmp.Width, bmp.Height);
                RectangleF destRect = new RectangleF(0, 0, bmp.Width * res, bmp.Height * res);
                Bitmap bmpRes = new Bitmap((int)(destRect.Width), (int)(destRect.Height));

                using (Graphics g = Graphics.FromImage(bmpRes))
                {
                    g.DrawImage(bmp, destRect, srcRect, GraphicsUnit.Pixel);
                }
                this.Invoke(new Action(() => { viewer1.Image = bmpRes; }));

                bmp.Dispose();
            }
            else
            {
                this.Invoke(new Action(() => { viewer1.Image = bmp; }));
            }
            imgDict.Clear();
            GC.Collect();
        }
    }
}