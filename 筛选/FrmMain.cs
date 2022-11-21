using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 筛选
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
            //viewer1.PointPicked += Viewer1_PointPicked;

        }

        private void Viewer1_PointPicked(Point obj)
        {
            pickPoint = obj;
            lblPos.Text = $"X : {pickPoint.X}  Y : {pickPoint.Y}  R : {rotate}";
        }
        DefectLibrary defectLibrary = new DefectLibrary();
        string defectImagesPath = @"D:\DefectImages";
        List<string> folders = new List<string>();
        List<string> images = new List<string>();
        private int cursor = 0;
        private Image image;
        private int rotate = 0;
        Point pickPoint = new Point(0, 0);
        private int selected = 0;
        private void btnReflesh2_Click(object sender, EventArgs e)
        {
            UpdateList();
        }

        private void UpdateList()
        {
            folders = System.IO.Directory.GetDirectories(defectImagesPath).ToList();
            images = SearchImageFiles(defectImagesPath);
            lblInfo.Text = $"共 {folders.Count} 个产品信息，{images.Count} 张图像";
            if (images.Count > 0)
            {
                cursor = 0;
                rotate = 0;
                pickPoint = new Point(0, 0);
                lblPos.Text = $"X : {pickPoint.X}  Y : {pickPoint.Y}  R : {rotate}";
                var file = images[cursor];
                string sn;
                string info;
                AnalysisFile(file, out sn, out info);
                image = Image.FromFile(file);
                viewer1.Image = image;
            }
        }

        private void btnSetPath2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                defectImagesPath = folderBrowserDialog.SelectedPath;
                txtInfoPath.Text = defectImagesPath;
                UpdateList();
            }
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

        private List<string> SearchImageFiles(string path)
        {
            List<string> files = new List<string>();
            var dirs = System.IO.Directory.GetFiles(path, "*.jpg", System.IO.SearchOption.AllDirectories);
            files = dirs.ToList();
            return files;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (cursor < images.Count - 1)
            {
                cursor++;
            }
            else
            {
                cursor = 0;
            }
            rotate = 0;
            pickPoint = new Point(0, 0);
            lblPos.Text = $"X : {pickPoint.X}  Y : {pickPoint.Y}  R : {rotate}";
            lblCursor.Text = $"{cursor}";
            var file = images[cursor];
            string sn;
            string info;
            AnalysisFile(file, out sn, out info);
            image = Image.FromFile(file);
            viewer1.Image = image;
        }

        private void btnBefore_Click(object sender, EventArgs e)
        {
            if (cursor > 0)
            {
                cursor--;
            }
            else
            {
                cursor = images.Count - 1;
            }
            rotate = 0;
            pickPoint = new Point(0, 0);
            lblPos.Text = $"X : {pickPoint.X}  Y : {pickPoint.Y}  R : {rotate}";
            lblCursor.Text = $"{cursor}";
            var file = images[cursor];
            string sn;
            string info;
            AnalysisFile(file, out sn, out info);
            image = Image.FromFile(file);
            viewer1.Image = image;
        }

        private void btnRotate90_Click(object sender, EventArgs e)
        {
            image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            viewer1.Image = image;
            rotate += 90;
            lblPos.Text = $"X : {pickPoint.X}  Y : {pickPoint.Y}  R : {rotate}";
        }

        private void btnRotate270_Click(object sender, EventArgs e)
        {
            image.RotateFlip(RotateFlipType.Rotate270FlipNone);
            viewer1.Image = image;
            rotate -= 90;
            lblPos.Text = $"X : {pickPoint.X}  Y : {pickPoint.Y}  R : {rotate}";
        }

        void AnalysisFile(string file, out string sn, out string info)
        {
            info = string.Empty;
            System.IO.FileInfo fileInfo = new System.IO.FileInfo(file);
            var array = file.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
            var fSurface = array[array.Length - 4];
            if (fSurface == "Side1" || fSurface == "Side2" || fSurface == "Side3")
            {
                fSurface = "Side1";
            }
            if (fSurface == "Side4" || fSurface == "Side5")
            {
                fSurface = "Side4";
            }
            if (fSurface == "Side6" || fSurface == "Side7" || fSurface == "Side8")
            {
                fSurface = "Side6";
            }
            if (fSurface == "Side9" || fSurface == "Side10")
            {
                fSurface = "Side9";
            }

            txtfileName.Text = fileInfo.Name;
            var directoryInfo = fileInfo.Directory.Parent;
            sn = directoryInfo.Name;
            var infoFolder = $@"{directoryInfo.FullName}\Info";
            if (Directory.Exists(infoFolder))
            {
                var infoFile = $@"{infoFolder}\{sn}.txt";
                if (File.Exists(infoFile))
                {
                    var infos = File.ReadAllLines(infoFile);
                    foreach (var item in infos)
                    {
                        var strarray = item.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        if (strarray.Length < 4)
                        {
                            continue;
                        }
                        if (file.Contains($"{strarray[0]}") && file.Contains($"{strarray[1]}"))
                        {
                            if (info == string.Empty)
                            {
                                info = $"{item}";
                            }
                            else
                                info = $"{info}\r\n{item}";
                        }
                    }
                }
                var infoImages = Directory.GetFiles(infoFolder, "*.bmp");
                foreach (var item in infoImages)
                {
                    var strarray = item.Split(new char[] { '_', '.' }, StringSplitOptions.RemoveEmptyEntries);
                    var surface = strarray[1];
                    if (surface == fSurface)
                    {
                        var infoImage = Image.FromFile(item);
                        viewer2.Image = infoImage;
                        break;
                    }
                }
            }

            txtDefectInfo.Text = info;
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            defectLibrary = DefectLibrary.LoadConfig();
            UpdateList();
            cbDefectTypes.DataSource = null;
            cbDefectTypes.DataSource = defectLibrary.DefectTypes;
        }

        private void btnToList_Click(object sender, EventArgs e)
        {
            DefectInfo defectInfo = new DefectInfo()
            {
                DefectType = txtDefectType.Text,
                PickPoint = pickPoint,
                Description = txtDescription.Text,
                ImageFile = txtfileName.Text,
                Rotate = rotate
            };
            defectLibrary.AddNew(defectInfo);
            defectLibrary.SaveConfig();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cbDefectTypes.DataSource = null;
            cbDefectTypes.DataSource = defectLibrary.DefectTypes;
        }

        private void cbDefectTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbDefectTypes.Text != "")
            {
                dataGridView1.DataSource = null;
                var list = defectLibrary[cbDefectTypes.Text].List;
                dataGridView1.DataSource = list;
                lblTotal.Text = $"[{cbDefectTypes.Text}] 型缺陷共有 {list.Count} 条记录";
            }

        }

        private void btnSaveToFile_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog { Filter = @"CSV文件|*.csv|文本格式|*.txt|所有文件|*.*" };
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                defectLibrary.SaveTofile(saveFile.FileName);
            }
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            var list = defectLibrary.List;
            dataGridView1.DataSource = list;
            lblTotalAll.Text = $"共有 {list.Count} 条记录";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnDeleteSelected_Click(object sender, EventArgs e)
        {

            var list = defectLibrary.List;

            var info = list[selected];
            defectLibrary.RemoveAt(info);
            btnShowAll_Click(null, null);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selected = e.RowIndex;
        }
    }
}
