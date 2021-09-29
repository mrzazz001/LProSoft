using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using InvAcc.GeneralM;
using InvAcc.Stock_Data;
using SSSLanguage;
using System;
using System.ComponentModel;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial  class FrmTableType : Form
    { void avs(int arln)

{ 
}
        private void langloads(object sender, EventArgs e)
        {
             avs(GeneralM.VarGeneral.currentintlanguage);
        }
   
        private int LangArEn = 0;
        private string vItemNo = string.Empty;
        public int vSize_ = 0;
        public bool vSts_Op = false;
        private Stock_DataDataContext dbInstance;
       // private IContainer components = null;
        private RibbonBar ribbonBar1;
        private GroupPanel groupPanel1;
        private ButtonX button_Unit2;
        private ButtonX button_Unit3;
        private ButtonX button_Unit4;
        protected Label label4E;
        protected Label label3E;
        protected Label label1E;
        protected Label label2E;
        protected Label label4;
        private ButtonX button_Close;
        protected Label label3;
        protected Label label1;
        protected Label label2;
        private ButtonX button_Unit1;
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
        public FrmTableType()
        {
            InitializeComponent();this.Load += langloads;
        }
        private void FrmTableType_Load(object sender, EventArgs e)
        {
            try
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmTableType));
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                {
                    Language.ChangeLanguage("ar-SA", this, resources);
                    LangArEn = 0;
                    button_Close.Text = "تــــراجــــــع";
                }
                else
                {
                    Language.ChangeLanguage("en", this, resources);
                    LangArEn = 1;
                    button_Close.Text = "Back";
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
            vSize = 0;
            Close();
        }
        private void FrmTableType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                button_Close_Click(sender, e);
            }
        }
        private void FrmTableType_KeyPress(object sender, KeyPressEventArgs e)
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
                vSize = 1;
                Close();
            }
        }
        private void button_Unit2_Click(object sender, EventArgs e)
        {
            if (button_Unit2.Checked)
            {
                vStsOp = true;
                vSize = 2;
                Close();
            }
        }
        private void button_Unit3_Click(object sender, EventArgs e)
        {
            if (button_Unit3.Checked)
            {
                vStsOp = true;
                vSize = 3;
                Close();
            }
        }
        private void button_Unit4_Click(object sender, EventArgs e)
        {
            if (button_Unit4.Checked)
            {
                vStsOp = true;
                vSize = 4;
                Close();
            }
        }
    }
}
