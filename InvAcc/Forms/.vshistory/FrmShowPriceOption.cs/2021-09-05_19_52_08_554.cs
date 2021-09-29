using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using InvAcc.GeneralM;
using InvAcc.Stock_Data;
using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial  class FrmShowPriceOption : Form
    { void avs(int arln)

        {
            //groupPanel1.Text=   (arln == 0 ? "  Options   -   خيارات  " : "  Options - Options") ; button_Unit2.Text=   (arln == 0 ? "  موردين | <font color" : "  Suppliers | <font color") ; button_Close.Text=   (arln == 0 ? "  تـراجـع - Back  " : "  Back") ; button_Unit1.Text=   (arln == 0 ? "  عملاء | <font color" : "  Clients | <font color") ;}
        }
        private void langloads(object sender, EventArgs e)
        {
             avs(GeneralM.VarGeneral.currentintlanguage);
        }
   
        private int LangArEn = 0;
        private string vItemNo = "";
        public int vSize_ = 0;
        public bool vSts_Op = false;
        private Stock_DataDataContext dbInstance;
       // private IContainer components = null;
        private RibbonBar ribbonBar1;
        private GroupPanel groupPanel1;
        private ButtonX button_Close;
        public ButtonX button_Unit2;
        public ButtonX button_Unit1;
        public int vSize
        {
            get
            {
                return vSize_;
            }
            set
            {
                vSize_ = value;
            }
        }
        public bool vStsOp
        {
            get
            {
                return vSts_Op;
            }
            set
            {
                vSts_Op = value;
            }
        }
        private Stock_DataDataContext db
        {
            get
            {
                if (dbInstance == null)
                {
                    dbInstance = new Stock_DataDataContext(VarGeneral.BranchCS);
                }
                return dbInstance;
            }
        }
        public FrmShowPriceOption()
        {
            InitializeComponent();this.Load += langloads;
            if (File.Exists(Application.StartupPath + "\\Script\\SecriptStons.dll"))
            {
                button_Unit2.Text = ((LangArEn == 0) ? "أمر تحميل" : "Order");
            }
        }
        private void FrmShowPriceOption_Load(object sender, EventArgs e)
        {
            try
            {
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                {
                    LangArEn = 0;
                }
                else
                {
                    LangArEn = 1;
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Load:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void button_Close_Click(object sender, EventArgs e)
        {
            vStsOp = false;
            Close();
        }
        private void FrmShowPriceOption_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                button_Close_Click(sender, e);
            }
        }
        private void FrmShowPriceOption_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                SendKeys.Send("{Tab}");
            }
        }
        private void button_Unit1_Click(object sender, EventArgs e)
        {
            if (button_Unit1.Checked)
            {
                vStsOp = true;
                vSize = 0;
                Close();
            }
        }
        private void button_Unit2_Click(object sender, EventArgs e)
        {
            if (button_Unit2.Checked)
            {
                vStsOp = true;
                vSize = 1;
                Close();
            }
        }
    }
}
