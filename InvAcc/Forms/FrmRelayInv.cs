using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using ProShared.GeneralM;using ProShared;
using ProShared.Stock_Data;
using SSSDateTime.Date;
using SSSLanguage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial  class FrmRelayInv : Form
    { void avs(int arln)

{ 
}
        private void langloads(object sender, EventArgs e)
        {
              avs(ProShared. GeneralM.VarGeneral.currentintlanguage);;
        }
   
        public class ColumnDictinary
        {
            public string AText = "";
            public string EText = "";
            public bool IfDefault = false;
            public string Format = "";
            public ColumnDictinary(string aText, string eText, bool ifDefault, string format)
            {
                AText = aText;
                EText = eText;
                IfDefault = ifDefault;
                Format = format;
            }
        }
        public Dictionary<string, ColumnDictinary> columns_Names_visible = new Dictionary<string, ColumnDictinary>();
        public Dictionary<string, ColumnDictinary> columns_Names_visible2 = new Dictionary<string, ColumnDictinary>();
        private HijriGreg.HijriGregDates n = new HijriGreg.HijriGregDates();
        private T_AccDef _AccDefBind = new T_AccDef();
        private int LangArEn = 0;
        protected bool ifOkDelete;
        public bool CanEdit = true;
        protected bool CanInsert = true;
#pragma warning disable CS0414 // The field 'FrmRelayInv.FlagUpdate' is assigned but its value is never used
        private string FlagUpdate = "";
#pragma warning restore CS0414 // The field 'FrmRelayInv.FlagUpdate' is assigned but its value is never used
        public ViewState ViewState = ViewState.Deiles;
        private FormState statex;
        private T_SYSSETTING _SysSetting = new T_SYSSETTING();
        private List<T_SYSSETTING> listSysSetting = new List<T_SYSSETTING>();
        private T_INVSETTING _InvSetting = new T_INVSETTING();
        private List<T_INVSETTING> listInvSetting = new List<T_INVSETTING>();
        private T_GDHEAD _GdHead = new T_GDHEAD();
        private List<T_GDHEAD> listGdHead = new List<T_GDHEAD>();
        private T_GDDET _GdDet = new T_GDDET();
        private List<T_GDDET> listGdDet = new List<T_GDDET>();
        private List<T_GdAuto> listGdAuto = new List<T_GdAuto>();
        private T_GdAuto _GdAuto = new T_GdAuto();
        public List<Control> controls;
        public Control codeControl = new Control();
        private bool canUpdate = true;
        private Stock_DataDataContext dbInstance;
        private Rate_DataDataContext dbInstanceRate;
        private T_User Permmission = new T_User();
        private ScriptNumber ScriptNumber1 = new ScriptNumber();
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
        public Softgroup.NetResize.NetResize netResize1;
        private GroupPanel groupPanel2;
        private ComboBoxEx CmbUser;
        private Label label3;
        private GroupPanel groupPanel1;
        private ButtonX ButOk;
        private Label label_Balance;
        private ButtonX buttonX_Close;
        public FormState State
        {
            get
            {
                return statex;
            }
            set
            {
                statex = value;
            }
        }
        protected bool CanUpdate
        {
            get
            {
                return canUpdate;
            }
            set
            {
                canUpdate = value;
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
        private Rate_DataDataContext dbc
        {
            get
            {
                if (dbInstanceRate == null)
                {
                    dbInstanceRate = new Rate_DataDataContext(VarGeneral.BranchRt);
                }
                return dbInstanceRate;
            }
        }
        public FrmRelayInv()
        {
            InitializeComponent();this.Load += langloads;
        }
        private void FillCombo()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                List<T_User> LUsr = (from t in dbc.T_Users
                                     where t.Usr_ID != 1
                                     orderby t.UsrNo
                                     select t).ToList();
                LUsr.Insert(0, new T_User());
                CmbUser.DataSource = LUsr;
                CmbUser.DisplayMember = "UsrNamA";
                CmbUser.ValueMember = "UsrNo";
            }
            else
            {
                List<T_User> LUsr = (from t in dbc.T_Users
                                     where t.Usr_ID != 1
                                     orderby t.UsrNo
                                     select t).ToList();
                LUsr.Insert(0, new T_User());
                CmbUser.DataSource = LUsr;
                CmbUser.DisplayMember = "UsrNamE";
                CmbUser.ValueMember = "UsrNo";
            }
            CmbUser.SelectedIndex = 0;
        }
        private void FrmRelayInv_Load(object sender, EventArgs e)
        {
            try
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmRelayInv));
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                {
                    Language.ChangeLanguage("ar-SA", this, resources);
                    LangArEn = 0;
                    ButOk.Text = "ترحيل F2";
                    buttonX_Close.Text = "إغلاق Esc";
                    Text = "فواتير نقاط البيع";
                }
                else
                {
                    Language.ChangeLanguage("en", this, resources);
                    LangArEn = 1;
                    ButOk.Text = "Relay F2";
                    buttonX_Close.Text = "Close Esc";
                    Text = "POS Invoices";
                }
                Permmission = dbc.Get_PermissionID(VarGeneral.UserID);
                FillCombo();
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Load:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void GetInvSetting()
        {
            _InvSetting = new T_INVSETTING();
            _SysSetting = new T_SYSSETTING();
            _InvSetting = db.StockInvSetting( VarGeneral.InvTyp);
            _SysSetting = db.SystemSettingStock();
        }
        private void ButOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (CmbUser.SelectedIndex <= 0)
                {
                    MessageBox.Show((LangArEn == 0) ? "تأكد من اسم المستخدم ثم حاول مرة اخرى" : "Check User Name", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    CmbUser.Focus();
                }
                else if (double.Parse(label_Balance.Text) <= 0.0)
                {
                    MessageBox.Show((LangArEn == 0) ? "جميع فواتير نقطة البيع هذه مرحل\u0651ة.. " : "All point of sale bills migrated", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                else
                {
                    db.ExecuteCommand("UPDATE T_INVHED SET T_INVHED.InvId = 0  WHERE SalsManNo = '" + CmbUser.SelectedValue.ToString() + "' and T_INVHED.InvId > 0");
                    MessageBox.Show((LangArEn == 0) ? "تمت عملية الترحيل بنجاح .." : "Relay Is Done", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    CmbUser.SelectedIndex = 0;
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("FrmRelayInv_Load:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void FrmRelayInv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2 && ButOk.Enabled && ButOk.Visible)
            {
                ButOk_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
        private void buttonX_Close_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void CmbUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (CmbUser.SelectedIndex <= 0)
                {
                    label_Balance.Text = "0";
                    return;
                }
                List<T_INVHED> list = (from t in db.T_INVHEDs
                                       orderby t.InvHed_ID
                                       where t.InvTyp == (int?)1
                                       where t.IfDel == (int?)0
                                       where t.IfRet == (int?)0
                                       where t.InvId.HasValue && t.InvId > (double?)0.0
                                       where t.SalsManNo == CmbUser.SelectedValue.ToString()
                                       select t).ToList();
                if (list.Count > 0)
                {
                    label_Balance.Text = list.Count.ToString();
                }
                else
                {
                    label_Balance.Text = "0";
                }
            }
            catch
            {
                label_Balance.Text = "0";
            }
        }
    }
}
