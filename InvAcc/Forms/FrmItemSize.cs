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
    public partial  class FrmItemSize : Form
    { void avs(int arln)

        {
            // groupPanel1.Text=   (arln == 0 ? "  Units   -   الوحدات  " : "  Units") ; label5E.Text=   (arln == 0 ? "  كبـــير  " : "  big") ; label4E.Text=   (arln == 0 ? "  وســـط  " : "  middle") ; label3E.Text=   (arln == 0 ? "  كبـــير  " : "  big") ; label1E.Text=   (arln == 0 ? "  صغـــير  " : "  small") ; label2E.Text=   (arln == 0 ? "  وســـط  " : "  middle") ; label5.Text=   (arln == 0 ? "  كبـــير  " : "  big") ; label4.Text=   (arln == 0 ? "  وســـط  " : "  middle") ; button_Close.Text=   (arln == 0 ? "  تــــراجــــــع  " : "  backtrack") ; label3.Text=   (arln == 0 ? "  كبـــير  " : "  big") ; label1.Text=   (arln == 0 ? "  صغـــير  " : "  small") ; label2.Text=   (arln == 0 ? "  وســـط  " : "  middle") ;}
        }    private void langloads(object sender, EventArgs e)
        {
             avs(GeneralM.VarGeneral.currentintlanguage);
        }
   
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
#pragma warning disable CS0414 // The field 'FrmItemSize.LangArEn' is assigned but its value is never used
        private int LangArEn = 0;
#pragma warning restore CS0414 // The field 'FrmItemSize.LangArEn' is assigned but its value is never used
        private string vItemNo = "";
        public int vSize_ = 0;
        public bool vSts_Op = false;
        private Stock_DataDataContext dbInstance;
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
        public FrmItemSize(string itmNo)
        {
            InitializeComponent();this.Load += langloads;
            vItemNo = itmNo;
        }
        private void FrmItemSize_Load(object sender, EventArgs e)
        {
            try
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmItemSize));
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
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
                if (string.IsNullOrEmpty(vItemNo))
                {
                    button_Close_Click(sender, e);
                }
                T_Item q = db.StockItem(vItemNo);
                if (q == null || string.IsNullOrEmpty(q.Itm_No))
                {
                    button_Close_Click(sender, e);
                    return;
                }
                if (q.Unit1.HasValue)
                {
                    label1.Text = q.T_Unit.Arb_Des;
                    label1E.Text = q.T_Unit.Eng_Des;
                }
                else
                {
                    label1.Text = "";
                    label1E.Text = "";
                    button_Unit1.Checked = false;
                }
                if (q.Unit2.HasValue)
                {
                    label2.Text = q.T_Unit1.Arb_Des;
                    label2E.Text = q.T_Unit1.Eng_Des;
                }
                else
                {
                    label2.Text = "";
                    label2E.Text = "";
                    button_Unit2.Checked = false;
                }
                if (q.Unit3.HasValue)
                {
                    label3.Text = q.T_Unit2.Arb_Des;
                    label3E.Text = q.T_Unit2.Eng_Des;
                }
                else
                {
                    label3.Text = "";
                    label3E.Text = "";
                    button_Unit3.Checked = false;
                }
                if (q.Unit4.HasValue)
                {
                    label4.Text = q.T_Unit3.Arb_Des;
                    label4E.Text = q.T_Unit3.Eng_Des;
                }
                else
                {
                    label4.Text = "";
                    label4E.Text = "";
                    button_Unit4.Checked = false;
                }
                if (q.Unit5.HasValue)
                {
                    label5.Text = q.T_Unit4.Arb_Des;
                    label5E.Text = q.T_Unit4.Eng_Des;
                }
                else
                {
                    label5.Text = "";
                    label5E.Text = "";
                    button_Unit5.Checked = false;
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
        private void FrmItemSize_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                button_Close_Click(sender, e);
            }
        }
        private void FrmItemSize_KeyPress(object sender, KeyPressEventArgs e)
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
        private void button_Unit3_Click(object sender, EventArgs e)
        {
            if (button_Unit3.Checked)
            {
                vStsOp = true;
                vSize = 2;
                Close();
            }
        }
        private void button_Unit4_Click(object sender, EventArgs e)
        {
            if (button_Unit4.Checked)
            {
                vStsOp = true;
                vSize = 3;
                Close();
            }
        }
        private void button_Unit5_Click(object sender, EventArgs e)
        {
            if (button_Unit5.Checked)
            {
                vStsOp = true;
                vSize = 4;
                Close();
            }
        }
        private void groupPanel1_Click(object sender, EventArgs e)
        {
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
