using Check_Data.Forms;
using DevComponents.DotNetBar;
using ProShared.GeneralM;using ProShared;
using ProShared.Stock_Data;
using SSSLanguage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial  class FrmNewDB : Form
    { void avs(int arln)

{ 
}
        private void langloads(object sender, EventArgs e)
        {
              avs(ProShared. GeneralM.VarGeneral.currentintlanguage);;
        }
   
       // private IContainer components = null;
        private void netResize1_AfterControlResize(object sender, Softgroup.NetResize.AfterControlResizeEventArgs e)
        {
            if (e.Control.GetType() == typeof(Label))
            {
                Label c = (e.Control as Label); if ((c.BackColor != System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))))) && (c.BackColor != System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))))) && (c.BackColor != System.Drawing.Color.SteelBlue))
                    c.BackColor = Color.Transparent; Size cc = c.PreferredSize;
                c.AutoSize = false;
                c.Size = cc;
                //  e.Control.Font= new System.Drawing.Font("Tahoma",(float) (c-0.5));
            }
        }
        private void FrmInvSale_Shown(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            this.WindowState = FormWindowState.Maximized;
        }
        private void FrmInvSale_SizeChanged(object sender, EventArgs e)
        {
            netResize1.Refresh();
        }
        private Panel PanelSpecialContainer;
        public Softgroup.NetResize.NetResize netResize1;
        private LabelX label3;
        private ButtonX buttonX_Close;
        private RibbonBar ribbonBar1;
        private Panel panel1;
        private Label label1;
        protected TextBox textBox_DataBaseNm;
        private ButtonX buttonX_OK;
        private int LangArEn = 0;
        private Stock_DataDataContext dbInstance;
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
        public FrmNewDB()
        {
            InitializeComponent();this.Load += langloads;
        }
        private void RibunButtons()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                buttonX_Close.Text = "إغلاق";
                buttonX_OK.Text = "موافق";
                label1.Text = "إسم قاعدة البيانات :";
                label3.Text = "إضافة قاعدة بيانات جديدة";
            }
            else
            {
                buttonX_Close.Text = "Close";
                buttonX_OK.Text = "OK";
                label1.Text = "Data Base Name :";
                label3.Text = "ADD NEW DATA BASE";
            }
        }
        protected override void OnParentRightToLeftChanged(EventArgs e)
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmNewDB));
                if (base.Parent.RightToLeft == RightToLeft.Yes)
                {
                    Language.ChangeLanguage("ar-SA", this, resources);
                    LangArEn = 0;
                }
                else
                {
                    Language.ChangeLanguage("en", this, resources);
                    LangArEn = 1;
                }
            }
        }
        private void FrmNewDB_Load(object sender, EventArgs e)
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmNewDB));
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                Language.ChangeLanguage("ar-SA", this, resources);
                LangArEn = 0;
            }
            else
            {
                Language.ChangeLanguage("en", this, resources);
                LangArEn = 1;
            }
        }
        private void FrmNewDB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
        private void buttonX_OK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_DataBaseNm.Text))
            {
                return;
            }
            List<string> q = db.ExecuteQuery<string>("SELECT name FROM sys.databases Where name = 'DBSSS_" + textBox_DataBaseNm.Text + "' ORDER BY name ", new object[0]).ToList();
            if (q.Count > 0)
            {
                MessageBox.Show((LangArEn == 0) ? " اسم قاعدة البيانات الجديدة موجود في السيرفر الحالي ..\n الرجاء تغيير الاسم والمحاولة مرة اخرى ؟" : " name the new database exists in the current server ..\n Please change the name and try again ?", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            try
            {
                Rate_DataDataContext dbc = new Rate_DataDataContext("Server=" + VarGeneral.gServerName + ";Database=;UID=" + VarGeneral.UsrName + ";PWD=" + VarGeneral.UsrPass);
                FrmMain frm = new FrmMain(null, dbc, textBox_DataBaseNm.Text, 0);
            }
            catch (Exception error)
            {
                MessageBox.Show((LangArEn == 0) ? ("خطأ .. لم يتم اضافة قاعدة البيانات بنجاح \n " + error.Message) : ("Error .. Don't Add Data Base Successfully \n " + error.Message), VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                VarGeneral.DebLog.writeLog("buttonItem_AddData_Click:", error, enable: true);
                Application.ExitThread();
            }
            MessageBox.Show((LangArEn == 0) ? (" تم اضافة قاعدة البيانات : " + textBox_DataBaseNm.Text) : (" .. Add Data Base is : " + textBox_DataBaseNm.Text), VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            Close();
        }
        private void buttonX_Close_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void textBox_DataBaseNm_Enter(object sender, EventArgs e)
        {
            Language.Switch("EN");
        }
        private void textBox_DataBaseNm_KeyPress(object sender, KeyPressEventArgs e)
        {
            Language.Switch("EN");
        }
    }
}
