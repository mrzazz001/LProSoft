using Check_Data.Forms;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using ProShared.GeneralM;using ProShared;
using ProShared.Stock_Data;
using SSSLanguage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial  class FMBranchSelect : Form
    { void avs(int arln)

{ 
 labelX1.Text=   (arln == 0 ? "  تغيير مسار قاعدة البيانات ( تغيير الفرع )  " : "  Change database path (change branch)") ; buttonX_Close.Text=   (arln == 0 ? "  إغلاق  " : "  Close") ; buttonX_Ok.Text=   (arln == 0 ? "  موافــــق  " : "  ok") ;}
        private void langloads(object sender, EventArgs e)
        {
              avs(ProShared. GeneralM.VarGeneral.currentintlanguage);;
        }
   
        private T_Branch _Branch = new T_Branch();
        private List<T_Branch> list = new List<T_Branch>();
        private int LangArEn = 0;
        private Rate_DataDataContext dbInstance;
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
        private RibbonBar ribbonBar1;
        private Panel panel1;
        private TextBox txtOldBranch;
        private LabelX labelX1;
        private ButtonX buttonX_Close;
        private ComboBoxEx CmbNewBranch;
        private ButtonX buttonX_Ok;
        private Rate_DataDataContext dbc
        {
            get
            {
                if (dbInstance == null)
                {
                    dbInstance = new Rate_DataDataContext(VarGeneral.BranchRt);
                }
                return dbInstance;
            }
        }
        public FMBranchSelect()
        {
            InitializeComponent();this.Load += langloads;
        }
        private void RibunButtons()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                buttonX_Close.Text = "إغلاق";
                buttonX_Ok.Text = "موافــــق";
                labelX1.Text = " تغيير الفرع الحالي ";
            }
            else
            {
                buttonX_Close.Text = "Close";
                buttonX_Ok.Text = "OK";
                labelX1.Text = "Change Branch";
            }
        }
        protected override void OnLoad(EventArgs e)
        {
            try
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(FMBranchSelect));
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                {
                    Language.ChangeLanguage("ar-SA", this, resources);
                    LangArEn = 0;
                }
                else if (VarGeneral.CurrentLang.ToString() == "1")
                {
                    Language.ChangeLanguage("en", this, resources);
                    LangArEn = 1;
                }
                FillData();
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("OnLoad:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        protected override void OnParentRightToLeftChanged(EventArgs e)
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FMBranchSelect));
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                RightToLeft = RightToLeft.Yes;
                Language.ChangeLanguage("ar-SA", this, resources);
                LangArEn = 0;
            }
            else if (VarGeneral.CurrentLang.ToString() == "1")
            {
                RightToLeft = RightToLeft.No;
                Language.ChangeLanguage("en", this, resources);
                LangArEn = 1;
            }
            FillData();
        }
        private void FillData()
        {
            try
            {
                txtOldBranch.Tag = VarGeneral.BranchNumber;
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                {
                    List<T_Branch> listBranch = new List<T_Branch>(dbc.T_Branches.Where((T_Branch item) => item.Branch_no != VarGeneral.BranchNumber).ToList());
                    CmbNewBranch.DataSource = listBranch;
                    CmbNewBranch.DisplayMember = "Branch_Name";
                    CmbNewBranch.ValueMember = "Branch_no";
                }
                else
                {
                    List<T_Branch> listBranch = new List<T_Branch>(dbc.T_Branches.Where((T_Branch item) => item.Branch_no != VarGeneral.BranchNumber).ToList());
                    CmbNewBranch.DataSource = listBranch;
                    CmbNewBranch.DisplayMember = "Branch_NameE";
                    CmbNewBranch.ValueMember = "Branch_no";
                }
                RibunButtons();
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("FillData:", error, enable: true);
            }
        }
        private void buttonX_Ok_Click(object sender, EventArgs e)
        {
            try
            {
                if (!(CmbNewBranch.Text != "") || CmbNewBranch.SelectedIndex < 0)
                {
                    return;
                }
                if (File.Exists(Application.StartupPath + "\\SqlPath.xml"))
                {
                    T_Branch br = dbc.RateBranch(CmbNewBranch.SelectedValue.ToString());
                    VarGeneral.BranchNumber = br.Branch_no;
                    VarGeneral.BranchNameA = br.Branch_Name;
                    VarGeneral.BranchNameE = br.Branch_NameE;
                    VarGeneral.ChangBr_ = true;
                    new FrmMain(null, null, VarGeneral.BranchNumber, 0);
                    MessageBox.Show((LangArEn == 0) ? " تم تغيير مسار قاعدة البيانات بنجاح..  " : "Data Base Path is Changed successfully .. ", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    try
                    {
                        new FrmMain(null, null, VarGeneral.BranchNumber, 0);
                        //VarGeneral.currentDbVersion =ProShared. DBUdate.DbUpdates.GetDatabaseVersion();
                        //if (VarGeneral.currentDbVersion == "ERROR" || VarGeneral.currentDbVersion == "old")
                        //{
                        //    MessageBox.Show("إصدار قاعدة البيانات لهذا الفرع قديمة اضغط موافق للتحديث وانتضر قليلا");
                        //    this.Enabled = false;
                        //   ProShared. DBUdate.DbUpdates.internalupdate(0);
                        //    this.Enabled = true;
                        //}
                    }
                    catch
                    {
                    }
                    Close();
                }
                else
                {
                    MessageBox.Show((LangArEn == 0) ? "خطأ .. لم يتم الوصول الى الملف الخاص ببيانات السيرفر ؟" : "Error .. Not Found Data Server File ?", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
            catch (Exception error)
            {
                VarGeneral.ChangBr_ = false;
                MessageBox.Show((LangArEn == 0) ? "لم يتم تغيير مسار قاعدة البيانات بنجاح.." : "Data Base Path not Changed", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                VarGeneral.DebLog.writeLog("buttonX_Ok_Click:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void buttonX_Close_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void Frm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                SendKeys.Send("{Tab}");
            }
        }
        private void Frm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2 && buttonX_Ok.Enabled && buttonX_Ok.Visible)
            {
                buttonX_Ok_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
        private void FMBranchSelect_Load(object sender, EventArgs e)
        {
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}
