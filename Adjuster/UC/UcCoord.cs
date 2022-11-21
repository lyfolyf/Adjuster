using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Adjuster.UC
{
    public partial class UcCoord : UcPanel
    {
        public UcCoord()
        {
            InitializeComponent();
        }

        double x = 0;
        double y = 0;

        public double X
        {
            get
            {
                return x;
            }

            set
            {
                x = value;
                lblX.Text = value.ToString("0.000");
            }
        }

        public double Y
        {
            get
            {
                return y;
            }

            set
            {
                y = value;
                lblY.Text = value.ToString("0.000");
            }
        }

        public string Description
        {
            get
            {
                return label3.Text;
            }
            set
            {
                label3.Text = value;
            }
        }
    }
}
