using System;
using System.Drawing;
using System.Windows.Forms;

namespace 拼接
{
    public partial class FrmNewRule : Form
    {
        public FrmNewRule()
        {
            InitializeComponent();
            ResetAreas();
        }

        public Rule Rule
        {
            get
            {
                return new Rule()
                {
                    Name = txtRuleName.Text,
                    VCount = ucAreaSelect1.VCount,
                    HCount = ucAreaSelect1.HCount
                };
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }
        private void ResetAreas()
        {
            var index = 0;
            for (int x = 0; x < ucAreaSelect1.VCount; x++)
            {
                for (int y = 0; y < ucAreaSelect1.HCount; y++)
                {
                    Point p = new Point(x + 1, y + 1);
                    index++;
                    AreaInfo areaInfo = new AreaInfo()
                    {
                        Color = Color.Blue,
                        Column = x + 1,
                        Row = y + 1,
                        Selected = false,
                        Block = index.ToString(),
                        Info = index.ToString()
                    };
                    ucAreaSelect1.AddArea(areaInfo);
                }
            }
        }

        private void txtHCount_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(txtHCount.Text, out int num))
            {
                if (num > 0)
                {
                    ucAreaSelect1.ClearAreas();
                    ucAreaSelect1.HCount = num;
                    ResetAreas();
                }
            }
        }

        private void txtVCount_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(txtVCount.Text, out int num))
            {
                if (num > 0)
                {
                    ucAreaSelect1.ClearAreas();
                    ucAreaSelect1.VCount = num;
                    ResetAreas();
                }
            }
        }
    }
}