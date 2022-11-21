
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace 图片搬运
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string srcPath1 = @"\\192.168.7.1\d\Images";
        string srcPath2 = @"\\192.168.7.2\d\Images";
        string srcPath3 = @"\\192.168.7.3\d\Images";
        string dstPath = @"D:\Images";

        Queue<MoveInfo> qMoveInfos = new Queue<MoveInfo>();
        object synLock = new object();
        private bool closing = false;
        private bool runing = false;
        private bool busy = false;
        private bool copyOnly = false;
        private bool findEmptyFolder = false;

        List<string> files = new List<string>();
        List<string> folders = new List<string>();
        void Push(string srcPath, string dstPath)
        {
            lock (synLock)
            {
                MoveInfo moveInfo = new MoveInfo(srcPath, dstPath);
                qMoveInfos.Enqueue(moveInfo);
            }
        }

        void Push(MoveInfo moveInfo)
        {
            lock (synLock)
            {
                qMoveInfos.Enqueue(moveInfo);
            }
        }
        MoveInfo TakeOne()
        {
            lock (synLock)
            {
                if (qMoveInfos.Count > 0)
                {
                    return qMoveInfos.Peek();
                }
                return null;
            }
        }

        void RemoveOne()
        {
            lock (synLock)
            {
                if (qMoveInfos.Count > 0)
                {
                    qMoveInfos.Dequeue();
                }
            }
        }

        int QCount()
        {
            lock (synLock)
            {
                return qMoveInfos.Count;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                txtSrcPath1.Text = fbd.SelectedPath;
                srcPath1 = fbd.SelectedPath;
                fileSystemWatcher1.Path = fbd.SelectedPath;
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                txtSrcPath2.Text = fbd.SelectedPath;
                srcPath2 = fbd.SelectedPath;
                fileSystemWatcher2.Path = fbd.SelectedPath;
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                txtSrcPath3.Text = fbd.SelectedPath;
                srcPath3 = fbd.SelectedPath;
                fileSystemWatcher3.Path = fbd.SelectedPath;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                txtTargetPath.Text = fbd.SelectedPath;
                dstPath = fbd.SelectedPath;
            }
        }

        private void fileSystemWatcher1_Created(object sender, System.IO.FileSystemEventArgs e)
        {
            FileInfo fileInfo = new FileInfo(e.FullPath);
            var fileName = fileInfo.Name;
            var folder = fileInfo.Directory.Name;
            var dstFolder = $@"{dstPath}\{folder}";
            if (!Directory.Exists(dstFolder))
            {
                Directory.CreateDirectory(dstFolder);
            }
            Push(fileInfo.FullName, $@"{dstFolder}\{fileName}");
            var count = QCount();
            this.Invoke(new Action(() => { lblCount.Text = $@"待传输数量：{count}"; }));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                while (!closing)
                {
                    busy = true;
                    if (!runing)
                    {
                        if (!closing)
                            this.Invoke(new Action(() => { lblMsg.Text = $@"暂停传输..."; }));
                        Thread.Sleep(10);
                        continue;
                    }
                    //this.Invoke(new Action(() => { lblMsg.Text = $@"传输中..."; }));
                    var count = QCount();
                    if (count == 0)
                    {
                        btnSwitch_Click(null, null);
                    }
                    this.Invoke(new Action(() => { lblCount.Text = $@"待传输数量：{count}"; }));
                    if (count > 0)
                    {
                        findEmptyFolder = true;
                        MoveInfo moveInfo = TakeOne();
                        try
                        {

                            //FileInfo fileInfo = new FileInfo(moveInfo.SrcPath);
                            //DirectoryInfo directoryInfo = fileInfo.Directory;
                            if (File.Exists(moveInfo.SrcPath))
                            {
                                File.Copy(moveInfo.SrcPath, moveInfo.DstPath, true);
                                if (!copyOnly)
                                    File.Delete(moveInfo.SrcPath);
                                //File.Move(moveInfo.SrcPath, moveInfo.DstPath);
                                this.Invoke(new Action(() => { lblMsg.Text = $"{moveInfo.SrcPath} \r\n成功搬运至 \r\n{moveInfo.DstPath}"; }));
                            }

                            RemoveOne();
                        }
                        catch (Exception ex)
                        {
                            this.Invoke(new Action(() => { lblMsg.Text = $@"{ex.Message}"; }));
                            RemoveOne();
                            Push(moveInfo);
                        }
                        Thread.Sleep(1);
                    }
                    else
                    {
                        if (findEmptyFolder)
                        {

                            var folders = Directory.EnumerateDirectories(srcPath1);
                            foreach (var folder in folders)
                            {
                                DirectoryInfo directoryInfo = new DirectoryInfo(folder);
                                if (directoryInfo.GetFiles().Length + directoryInfo.GetDirectories().Length == 0)
                                    try
                                    {
                                        directoryInfo.Delete();
                                    }
                                    catch { }
                            }
                            folders = Directory.EnumerateDirectories(srcPath2);
                            foreach (var folder in folders)
                            {
                                DirectoryInfo directoryInfo = new DirectoryInfo(folder);
                                if (directoryInfo.GetFiles().Length + directoryInfo.GetDirectories().Length == 0)
                                    try
                                    {
                                        directoryInfo.Delete();
                                    }
                                    catch { }
                            }
                            folders = Directory.EnumerateDirectories(srcPath3);
                            foreach (var folder in folders)
                            {
                                DirectoryInfo directoryInfo = new DirectoryInfo(folder);
                                if (directoryInfo.GetFiles().Length + directoryInfo.GetDirectories().Length == 0)
                                    try
                                    {
                                        directoryInfo.Delete();
                                    }
                                    catch { }
                            }
                            findEmptyFolder = false;
                        }
                        Thread.Sleep(1);
                    }
                    busy = false;
                }
                busy = false;
            });
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            closing = true;
            while (busy)
            {
                Thread.Sleep(50);
                Application.DoEvents();
            }
        }

        private void ckbCopyOnly_CheckedChanged(object sender, EventArgs e)
        {
            copyOnly = ckbCopyOnly.Checked;
        }

        private void Search(string path, bool initList)
        {
            if (initList)
            {
                files = new List<string>();
                folders = new List<string>();
            }
            files.AddRange(Directory.GetFiles(path));
            var dirs = System.IO.Directory.GetDirectories(path);
            folders.AddRange(dirs);
            foreach (var item in dirs)
            {
                Search(item, false);
            }

        }

        private void btnSwitch_Click(object sender, EventArgs e)
        {
            runing = !runing;
            if (runing)
            {
                btnSwitch.Text = "运行中，点击停止";
                btnSwitch.ForeColor = Color.Lime;
                btnSearch.Enabled = false;
            }
            else
            {
                btnSwitch.Text = "暂停中，点击运行";
                btnSwitch.ForeColor = Color.Red;
                btnSearch.Enabled = true;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                this.Invoke(new Action(() =>
                {
                    btnSearch.Enabled = false;
                    btnSwitch.Enabled = false;
                    btnClearList.Enabled = false;
                    lblMsg.Text = "开始搜索...";
                }));
                Search(srcPath1, true);
                Search(srcPath2, false);
                Search(srcPath3, false);
                foreach (var item in files)
                {
                    if (qMoveInfos.Count(k => k.SrcPath == item) == 0)
                    {
                        FileInfo fileInfo = new FileInfo(item);
                        var fileName = fileInfo.Name;
                        var folder = fileInfo.Directory.Name;
                        var dstFolder = $@"{dstPath}\{folder}";
                        if (!Directory.Exists(dstFolder))
                        {
                            Directory.CreateDirectory(dstFolder);
                        }
                        Push(fileInfo.FullName, $@"{dstFolder}\{fileName}");
                        var count = QCount();
                        this.Invoke(new Action(() => { lblCount.Text = $@"待传输数量：{count}"; }));
                    }
                }
                this.Invoke(new Action(() =>
                {
                    btnSearch.Enabled = true;
                    btnSwitch.Enabled = true;
                    btnClearList.Enabled = true;
                    lblMsg.Text = $"搜索完成，共发现{folders.Count}个文件夹，{files.Count}个文件";
                }));
            });
        }

        private void btnClearList_Click(object sender, EventArgs e)
        {
            qMoveInfos.Clear();
            var count = QCount();
            this.Invoke(new Action(() => { lblCount.Text = $@"待传输数量：{count}"; }));
        }

        private void fileSystemWatcher1_Changed(object sender, FileSystemEventArgs e)
        {

        }
    }

    class MoveInfo
    {
        string srcPath = @"D:\Images";
        string dstPath = @"\\192.168.7.4\d\Images";

        public MoveInfo(string srcPath, string dstPath)
        {
            SrcPath = srcPath;
            DstPath = dstPath;
        }

        public string SrcPath
        {
            get { return srcPath; }
            set
            {
                srcPath = value;
            }
        }
        public string DstPath
        {
            get { return dstPath; }
            set
            {
                dstPath = value;
            }
        }
    }
}
