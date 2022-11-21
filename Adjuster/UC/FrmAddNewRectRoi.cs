using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bing.Viewer;

namespace Adjuster
{
    public partial class FrmAddNewRectRoi : Form
    {
        public FrmAddNewRectRoi()
        {
            InitializeComponent();
        }
        int x = 200;
        int y = 200;
        int width = 500;
        int height = 500;
        Bing.Viewer.BingRectangle rect = new Bing.Viewer.BingRectangle();

        public BingRectangle Rect
        {
            get
            {
                int.TryParse(textBox1.Text, out x);
                int.TryParse(textBox2.Text, out y);
                int.TryParse(textBox3.Text, out width);
                int.TryParse(textBox4.Text, out height);
                rect = new BingRectangle(x, y, width, height);
                return rect;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Close();
        }
    }
}
