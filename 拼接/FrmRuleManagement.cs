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
    public partial class FrmRuleManagement : Form
    {
        public FrmRuleManagement()
        {
            InitializeComponent();
            cbRotate.DataSource = Enum.GetNames(typeof(RotateFlipType)).ToList();
            ucAreaSelect1.AeraClick += UcAreaSelect1_AeraClick;
        }
        Point p;
        ImageStackingUnit isu;
        private void UcAreaSelect1_AeraClick(object sender, AreaSelectEventArgs e)
        {
            p = new Point(e.Column, e.Row);
            ucAreaSelect1.SetAreaSelected(e.Row, e.Column, true);
            if (SysSetting.Rules.FindRule(listBox1.SelectedItem.ToString(), out Rule rule))
            {
                if (rule.FindUnit(p, out ImageStackingUnit stackingUnit))
                {
                    isu = stackingUnit;
                    listBox2.DataSource = null;
                    listBox2.DataSource = stackingUnit.Keywords;
                    txtBlockDispName.Text = stackingUnit.DisplayName;
                    cbRotate.Text = stackingUnit.Rotate.ToString();
                }
            }
        }

        private void FrmRuleManagement_Load(object sender, EventArgs e)
        {
            listBox1.DataSource = null;
            listBox1.DataSource = SysSetting.Rules.RuleNames;
        }

        private void btnAddNewRule_Click(object sender, EventArgs e)
        {
            FrmNewRule frmNewRule = new FrmNewRule();
            if (frmNewRule.ShowDialog() == DialogResult.OK)
            {
                SysSetting.Rules.AddRule(frmNewRule.Rule);
                listBox1.DataSource = null;
                listBox1.DataSource = SysSetting.Rules.RuleNames;
                SysSetting.SaveConfig();
            }
        }

        private void btnDelteRule_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                var name = listBox1.SelectedItem as string;
                SysSetting.Rules.Remove(name);
                listBox1.DataSource = null;
                listBox1.DataSource = SysSetting.Rules.RuleNames;
                SysSetting.SaveConfig();
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
            {
                return;
            }
            if (SysSetting.Rules.FindRule(listBox1.SelectedItem.ToString(), out Rule rule))
                ResetAreas(rule);
        }

        private void ResetAreas(Rule rule)
        {
            txtRuleName.Text = rule.Name;
            txtHCount.Text = rule.HCount.ToString();
            txtVCount.Text = rule.VCount.ToString();
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

        private void btnApply_Click(object sender, EventArgs e)
        {
            if (SysSetting.Rules.FindRule(listBox1.SelectedItem.ToString(), out Rule rule))
            {
                SysSetting.Rules.ReName(listBox1.SelectedItem.ToString(), txtRuleName.Text);
                //rule.Name = txtRuleName.Text;
                if (int.TryParse(txtHCount.Text, out int num))
                {
                    rule.HCount = num;
                }
                if (int.TryParse(txtVCount.Text, out int num2))
                {
                    rule.VCount = num2;
                }
                SysSetting.SaveConfig();
                ResetAreas(rule);
                listBox1.DataSource = null;
                listBox1.DataSource = SysSetting.Rules.RuleNames;
                listBox2.DataSource = null;
            }
        }

        private void btnAppayToBlock_Click(object sender, EventArgs e)
        {
            if (SysSetting.Rules.FindRule(listBox1.SelectedItem.ToString(), out Rule rule))
            {
                rule.SetDisplayName(p, txtBlockDispName.Text);
                rule.SetRotate(p, (RotateFlipType)Enum.Parse(typeof(RotateFlipType), cbRotate.Text));
                SysSetting.SaveConfig();
                ResetAreas(rule);
            }

        }

        private void btnAddNewKeywork_Click(object sender, EventArgs e)
        {
            var key = txtNewKeywork.Text;
            if (SysSetting.Rules.FindRule(listBox1.SelectedItem.ToString(), out Rule rule))
            {
                rule.AddKeyWord(p, key);
                SysSetting.SaveConfig();
                listBox2.DataSource = null;
                listBox2.DataSource = isu.Keywords;
            }
        }

        private void btnDelKeywork_Click(object sender, EventArgs e)
        {
            var key = listBox2.Text;
            if (SysSetting.Rules.FindRule(listBox1.SelectedItem.ToString(), out Rule rule))
            {
                rule.RemoveKeyWord(p, key);
                SysSetting.SaveConfig();
                listBox2.DataSource = null;
                listBox2.DataSource = isu.Keywords;
            }
        }

        private void btnAddNewKeyworkToAllBlock_Click(object sender, EventArgs e)
        {
            var key = txtNewKeywork.Text;
            if (SysSetting.Rules.FindRule(listBox1.SelectedItem.ToString(), out Rule rule))
            {
                rule.AddKeyWordToAll(key);
                SysSetting.SaveConfig();
                listBox2.DataSource = null;
                listBox2.DataSource = isu.Keywords;
            }
        }

        private void btnDelKeyworkAll_Click(object sender, EventArgs e)
        {
            var key = listBox2.Text;
            if (SysSetting.Rules.FindRule(listBox1.SelectedItem.ToString(), out Rule rule))
            {
                rule.RemoveKeyWordToAll(key);
                SysSetting.SaveConfig();
                listBox2.DataSource = null;
                listBox2.DataSource = isu.Keywords;
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

            if (SysSetting.Rules.FindRule(listBox1.SelectedItem.ToString(), out Rule rule))
            {
                var key = rule.GetDisplayName(p);
                rule.AddKeyWord(p, key);
                SysSetting.SaveConfig();
                listBox2.DataSource = null;
                listBox2.DataSource = isu.Keywords;
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {
            if (SysSetting.Rules.FindRule(listBox1.SelectedItem.ToString(), out Rule rule))
            {
                rule.SetRotateToAll((RotateFlipType)Enum.Parse(typeof(RotateFlipType), cbRotate.Text));
                SysSetting.SaveConfig();
                ResetAreas(rule);
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {
            if (SysSetting.Rules.FindRule(listBox1.SelectedItem.ToString(), out Rule rule))
            {
                var copy = rule.Clone();
                copy.Name = rule.Name + "- copy";
                SysSetting.Rules.AddRule(copy);
                listBox1.DataSource = null;
                listBox1.DataSource = SysSetting.Rules.RuleNames;
                SysSetting.SaveConfig();
            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtNewKeywork.Text = listBox2.Text;
        }
    }
}
