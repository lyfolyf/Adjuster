using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 拼接
{
    public partial class FrmShowHotmap : Form
    {
        public FrmShowHotmap()
        {
            InitializeComponent();
        }

        public Bitmap Image
        {
            set
            {
                this.heatMapViewer1.HotMap = value;
            }
        }
    }
}
