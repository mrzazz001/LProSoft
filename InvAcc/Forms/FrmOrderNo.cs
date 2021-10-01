using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using ProShared.GeneralM;using ProShared;
using ProShared.Stock_Data;
using System;
using System.ComponentModel;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial  class FrmOrderNo : Form
    { void avs(int arln)

{ 
}
        private void langloads(object sender, EventArgs e)
        {
              avs(ProShared. GeneralM.VarGeneral.currentintlanguage);;
        }
   
#pragma warning disable CS0414 // The field 'FrmOrderNo.LangArEn' is assigned but its value is never used
        private int LangArEn = 0;
#pragma warning restore CS0414 // The field 'FrmOrderNo.LangArEn' is assigned but its value is never used
        public int vSize_ = 0;
        public bool vSts_Op = false;
        private Stock_DataDataContext dbInstance;
       // private IContainer components = null;
        private RibbonBar ribbonBar1;
        private GroupPanel groupPanel1;
        private ButtonX button_Unit2;
        private ButtonX button_Unit3;
        private ButtonX button_Unit4;
        private ButtonX button_Unit5;
        protected Label label5E;
        protected Label label4E;
        protected Label label3E;
        protected Label label1E;
        protected Label label2E;
        protected Label label5;
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
        public FrmOrderNo()
        {
            InitializeComponent();this.Load += langloads;
        }
        private void FrmOrderNo_Load(object sender, EventArgs e)
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
            vSize = 0;
            Close();
        }
        private void FrmOrderNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                button_Close_Click(sender, e);
            }
        }
        private void FrmOrderNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                SendKeys.Send("{Tab}");
            }
        }
        private void button_Unit1_Click(object sender, EventArgs e)
        {
            vStsOp = true;
            vSize = 1;
            Close();
        }
        private void button_Unit2_Click(object sender, EventArgs e)
        {
            vStsOp = true;
            vSize = 2;
            Close();
        }
        private void button_Unit3_Click(object sender, EventArgs e)
        {
            vStsOp = true;
            vSize = 3;
            Close();
        }
        private void button_Unit4_Click(object sender, EventArgs e)
        {
            vStsOp = true;
            vSize = 4;
            Close();
        }
        private void button_Unit5_Click(object sender, EventArgs e)
        {
            vStsOp = true;
            vSize = 5;
            Close();
        }
    }
}
