using C1.Win.C1TrueDBGrid;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using Framework.Keyboard;
using InvAcc.GeneralM;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial  class FMFind : Form
    { void avs(int arln)

{ 
 c1TrueDBGrid1.Text=   (arln == 0 ? "  c1TrueDBGrid1  " : "  c1TrueDBGrid1") ; labelX1.Text=   (arln == 0 ? "  البحث الســريع - Quick Search  " : "  Quick Search - Quick Search") ; txtSearch.Text=   (arln == 0 ? "  F10  " : "  F10") ; txtSearch.Text=   (arln == 0 ? "    " : "    ") ; radioButton1.Text=   (arln == 0 ? "  بحث محتوى  " : "  content search") ; radioButton2.Text=   (arln == 0 ? "  بحث مطابق  " : "  matching search") ; buttonItem_Exit.Text=   (arln == 0 ? "  خروج | ESC  " : "  exit | ESC") ; ButOK.Text=   (arln == 0 ? "  موافق | OK  " : "  ok | OK") ; c1Button1.Text=   (arln == 0 ? "  مسح | CLEAR  " : "  scan | CLEAR") ; Text =    (arln == 0 ? "  .  " : "  .") ;}
        private void langloads(object sender, EventArgs e)
        {
             avs(GeneralM.VarGeneral.currentintlanguage);
        }
   
        public string Serach_No = "";
       // private IContainer components = null;
        private C1TrueDBGrid c1TrueDBGrid1;
        private BindingSource categoryBindingSource;
        private DataSet dataSet1;
        private LabelX labelX1;
        private GroupBox groupBoxTxtSearch;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private C1.Win.C1Input.C1Button buttonItem_Exit;
        private C1.Win.C1Input.C1Button ButOK;
        private C1.Win.C1Input.C1Button c1Button1;
        private TextBoxX txtSearch;
        public string SerachNo
        {
            get
            {
                return Serach_No;
            }
            set
            {
                Serach_No = value;
            }
        }
        public FMFind(string filter, int index)
        {
            InitializeComponent();this.Load += langloads;
            DataSetFill();
            c1TrueDBGrid1.DataSource = dataSet1.Tables[0];
            c1TrueDBGrid1.EditActive = true;
            c1TrueDBGrid1.FilterBar = true;
            c1TrueDBGrid1.AllowFilter = true;
            c1TrueDBGrid1.EditActive = true;
            for (int iiCnt = 0; iiCnt < c1TrueDBGrid1.Columns.Count; iiCnt++)
            {
                if (iiCnt == 1)
                {
                    c1TrueDBGrid1.Splits[0].DisplayColumns[iiCnt].Width = c1TrueDBGrid1.Width / 6;
                }
                if (iiCnt == 2 || iiCnt == 3)
                {
                    c1TrueDBGrid1.Splits[0].DisplayColumns[iiCnt].Width = c1TrueDBGrid1.Width / 3;
                }
                if (iiCnt == 4)
                {
                    c1TrueDBGrid1.Splits[0].DisplayColumns[iiCnt].Width = c1TrueDBGrid1.Width / 9;
                }
                c1TrueDBGrid1.Splits[0].DisplayColumns[iiCnt].HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center;
                c1TrueDBGrid1.Splits[0].DisplayColumns[c1TrueDBGrid1.Columns.Count - 1].AllowFocus = true;
            }
            if (VarGeneral.InvTyp == 11 || VarGeneral.InvTyp == 12 || VarGeneral.InvTyp == 13)
            {
                base.Width -= c1TrueDBGrid1.Width / 9;
            }
            c1TrueDBGrid1.Splits[0].DisplayColumns[0].Visible = false;
            c1TrueDBGrid1.FocusedSplit.AllowFocus = true;
            c1TrueDBGrid1.Focus();
            c1TrueDBGrid1.Col = 1;
            if (filter != "")
            {
                c1TrueDBGrid1.Columns[index].FilterText = filter;
                c1TrueDBGrid1.Col = index;
            }
            c1TrueDBGrid1.FilterActive = true;
            SendKeys.Send("{F2}");
            SendKeys.Send("{End}");
        }
        protected override void OnLoad(EventArgs e)
        {
        }
        private void button1_Click(object sender, EventArgs e)
        {
            SerachNo = "";
            Close();
        }
        private void c1TrueDBGrid1_FilterChange(object sender, EventArgs e)
        {
            try
            {
                txtSearch.TextChanged -= txtSearch_TextChanged;
                txtSearch.Text = "";
                txtSearch.TextChanged += txtSearch_TextChanged;
            }
            catch
            {
            }
        }
        private void DataSetFill()
        {
            try
            {
                dataSet1 = VarGeneral.RepData;
            }
            catch
            {
            }
        }
        private void c1TrueDBGrid1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (c1TrueDBGrid1.Row >= 0)
                {
                    int Index = c1TrueDBGrid1.Row;
                    SerachNo = c1TrueDBGrid1.Columns[0].CellValue(c1TrueDBGrid1.Row).ToString();
                    Close();
                }
                else
                {
                    SerachNo = "";
                    Close();
                }
            }
            catch
            {
                SerachNo = "";
                Close();
            }
        }
        private void c1TrueDBGrid1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Return)
                {
                    if (c1TrueDBGrid1.Row >= 0)
                    {
                        int Index = c1TrueDBGrid1.Row;
                        SerachNo = c1TrueDBGrid1.Columns[0].CellValue(c1TrueDBGrid1.Row).ToString();
                        Close();
                    }
                    else
                    {
                        SerachNo = "";
                        Close();
                    }
                }
            }
            catch
            {
                SerachNo = "";
                Close();
            }
        }
        private void ButClear_Click(object sender, EventArgs e)
        {
        }
        private void FMFind_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                ButClear_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                button1_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F10)
            {
                txtSearch_ButtonCustom2Click(sender, e);
            }
        }
        private void c1TrueDBGrid1_RowColChange(object sender, RowColChangeEventArgs e)
        {
            if (c1TrueDBGrid1.Col == 1)
            {
                Language.Switch("English");
            }
            if (c1TrueDBGrid1.Col == 2)
            {
                Language.Switch("Arabic");
            }
            if (c1TrueDBGrid1.Col == 3)
            {
                Language.Switch("English");
            }
        }
        private void ButOK_Click(object sender, EventArgs e)
        {
            c1TrueDBGrid1_DoubleClick(sender, e);
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                c1TrueDBGrid1.FilterChange -= c1TrueDBGrid1_FilterChange;
                for (int i = 0; i < c1TrueDBGrid1.Columns.Count; i++)
                {
                    c1TrueDBGrid1.Columns[i].FilterText = "";
                }
                c1TrueDBGrid1.FilterChange += c1TrueDBGrid1_FilterChange;
                (c1TrueDBGrid1.DataSource as DataTable).DefaultView.RowFilter = string.Format("[" + dataSet1.Tables[0].Columns[(c1TrueDBGrid1.Columns.Count <= 4) ? 1 : 0].Caption + "] LIKE '%{0}%' OR [" + dataSet1.Tables[0].Columns[1].Caption + "] LIKE '%{0}%' OR [" + dataSet1.Tables[0].Columns[2].Caption + "] LIKE '%{0}%' OR [" + dataSet1.Tables[0].Columns[3].Caption + "] LIKE '%{0}%'", txtSearch.Text);
            }
            catch
            {
            }
        }
        private void txtSearch_ButtonCustomClick(object sender, EventArgs e)
        {
            txtSearch.Text = "";
        }
        private void FMFind_Load(object sender, EventArgs e)
        {
            try
            {
                if (VarGeneral.gUserName == "runsetting")
                {
                    SendKeys.Send("%{TAB}");
                }
            }
            catch
            {
            }
        }
        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
        }
        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == '\r')
                {
                    c1TrueDBGrid1.Focus();
                    c1TrueDBGrid1.Col = 1;
                    c1TrueDBGrid1.Row = 0;
                }
            }
            catch
            {
            }
        }
        private void txtSearch_ButtonCustom2Click(object sender, EventArgs e)
        {
            txtSearch.Focus();
        }
    }
}
