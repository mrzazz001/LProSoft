using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.Editors;
using InvAcc.GeneralM;
using InvAcc.Stock_Data;
using SSSDateTime.Date;
using SSSLanguage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial  class FrmPhoneCall : Form
    { void avs(int arln)

{ 
 panelEx2.Text=   (arln == 0 ? "  Click to collapse  " : "  Click to collapse") ; label4.Text=   (arln == 0 ? "  الضريبة  " : "  Tax") ; label3.Text=   (arln == 0 ? "  سعر الدقيقة للمكالمات  " : "  Per minute rate for calls") ; label1.Text=   (arln == 0 ? "  عبر الأقمار الصناعية :  " : "  Via satellite:") ; label2.Text=   (arln == 0 ? "  حول الدول الأجنبية :  " : "  About foreign countries:") ; labelx.Text=   (arln == 0 ? "  حــول الدول العربية :  " : "  About the Arab countries:") ; labelxx.Text=   (arln == 0 ? "  المكالمات الداخلية :  " : "  Internal calls:") ; label38.Text=   (arln == 0 ? "  المكالمات المحلية :  " : "  local calls:") ; label72.Text=   (arln == 0 ? "  حساب القيد التلقائي لمستخدمين الخدمة  " : "  Automatic enrollment account for service users") ; superTabControl_Main1.Text=   (arln == 0 ? "  superTabControl3  " : "  superTabControl3") ; Button_Close.Text=   (arln == 0 ? "  إغلاق  " : "  Close") ; Button_Save.Text=   (arln == 0 ? "  حفظ  " : "  save") ; ToolStripMenuItem_Rep.Text=   (arln == 0 ? "  إظهار التقرير  " : "  Show report") ; ToolStripMenuItem_Det.Text=   (arln == 0 ? "  إظهار التفاصيل  " : "  Show details") ; Text = "كرت تعديل أسعار المكالمات";this.Text=   (arln == 0 ? "  كرت تعديل أسعار المكالمات  " : "  Call rate adjustment card") ;}
        private void langloads(object sender, EventArgs e)
        {
             avs(GeneralM.VarGeneral.currentintlanguage);
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
       // private IContainer components = null;
        private Timer timer1;
        private PanelEx panelEx2;
        private RibbonBar ribbonBar1;
        private System.Windows.Forms. SaveFileDialog saveFileDialog1;
        private Timer timerInfoBallon;
        private System.Windows.Forms.OpenFileDialog  openFileDialog1;
        private Panel panel1;
        private DockSite barTopDockSite;
        private DockSite barBottomDockSite;
        public DotNetBarManager dotNetBarManager1;
        private ImageList imageList1;
        private DockSite barLeftDockSite;
        private DockSite barRightDockSite;
        private DockSite dockSite4;
        private DockSite dockSite1;
        private DockSite dockSite2;
        private DockSite dockSite3;
        protected ContextMenuStrip contextMenuStrip1;
        protected ToolStripMenuItem ToolStripMenuItem_Rep;
        protected ToolStripMenuItem ToolStripMenuItem_Det;
        protected ContextMenuStrip contextMenuStrip2;
        private RibbonBar ribbonBar_Tasks;
        private SuperTabControl superTabControl_Main1;
        protected ButtonItem Button_Close;
        protected ButtonItem Button_Save;
        protected LabelItem labelItem2;
        private DoubleInput txtInsideComm;
        private DoubleInput txtArCountryComm;
        private DoubleInput txtEngCountryComm;
        private DoubleInput txtByMoonComm;
        private DoubleInput txtLocalComm;
        protected Label label4;
        private TextBoxX txtServiceAccName;
        private TextBoxX txtServiceAcc;
        private Label label72;
        protected Label label3;
        private DoubleInput txtInside;
        private DoubleInput txtArCountry;
        private DoubleInput txtEngCountry;
        private DoubleInput txtByMoon;
        private DoubleInput txtLocal;
        protected Label label1;
        protected Label label2;
        protected Label labelx;
        protected Label labelxx;
        protected Label label38;
        public Dictionary<string, ColumnDictinary> columns_Names_visible = new Dictionary<string, ColumnDictinary>();
        public Dictionary<string, ColumnDictinary> columns_Names_visible2 = new Dictionary<string, ColumnDictinary>();
        private HijriGreg.HijriGregDates n = new HijriGreg.HijriGregDates();
        private T_AccDef _AccDefBind = new T_AccDef();
        private int LangArEn = 0;
        protected bool ifOkDelete;
        public bool CanEdit = true;
        protected bool CanInsert = true;
#pragma warning disable CS0414 // The field 'FrmPhoneCall.FlagUpdate' is assigned but its value is never used
        private string FlagUpdate = "";
#pragma warning restore CS0414 // The field 'FrmPhoneCall.FlagUpdate' is assigned but its value is never used
        public ViewState ViewState = ViewState.Deiles;
        private FormState statex;
        public List<Control> controls;
        public Control codeControl = new Control();
        private bool canUpdate = true;
        private List<string> pkeys = new List<string>();
        private Stock_DataDataContext dbInstance;
        private Rate_DataDataContext dbInstanceRate;
        private T_User permission = new T_User();
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
        public bool IfSave
        {
            set
            {
                Button_Save.Visible = value;
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
        public List<string> PKeys
        {
            get
            {
                return pkeys;
            }
            set
            {
                pkeys = value;
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
        public T_User Permmission
        {
            get
            {
                return permission;
            }
            set
            {
                if (value != null && value.UsrNo != "")
                {
                    permission = value;
                    if (!VarGeneral.TString.ChkStatShow(value.RepAcc4, 11))
                    {
                        CanEdit = false;
                    }
                    else
                    {
                        CanEdit = true;
                    }
                }
            }
        }
        public bool SetReadOnly
        {
            set
            {
                if (value)
                {
                    State = FormState.Saved;
                }
                Button_Save.Enabled = !value;
            }
        }
        protected bool ContinueIfEditOrNew()
        {
            if (State == FormState.Edit || State == FormState.New)
            {
                if (MessageBox.Show((LangArEn == 0) ? "تم تعديل السجل الحالي دون حفظ التغييرات .. هل تريد المتابعة؟" : "Not saved the changes, do you really want to continue?", VarGeneral.ProdectNam, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
                {
                    return false;
                }
                return true;
            }
            return true;
        }
        private void Button_Close_Click(object sender, EventArgs e)
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
            if (e.KeyCode == Keys.F2 && Button_Save.Enabled && Button_Save.Visible && State != 0)
            {
                Button_Save_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
        public FrmPhoneCall()
        {
            InitializeComponent();this.Load += langloads;
            controls = new List<Control>();
            codeControl = txtArCountryComm;
            controls.Add(txtArCountry);
            controls.Add(txtArCountryComm);
            controls.Add(txtByMoon);
            controls.Add(txtByMoonComm);
            controls.Add(txtEngCountry);
            controls.Add(txtEngCountryComm);
            controls.Add(txtInside);
            controls.Add(txtInsideComm);
            controls.Add(txtLocal);
            controls.Add(txtLocalComm);
            controls.Add(txtServiceAcc);
            controls.Add(txtServiceAccName);
            Button_Close.Click += Button_Close_Click;
            txtArCountry.Click += Button_Edit_Click;
            txtArCountryComm.Click += Button_Edit_Click;
            txtByMoon.Click += Button_Edit_Click;
            txtByMoonComm.Click += Button_Edit_Click;
            txtEngCountry.Click += Button_Edit_Click;
            txtEngCountryComm.Click += Button_Edit_Click;
            txtInside.Click += Button_Edit_Click;
            txtInsideComm.Click += Button_Edit_Click;
            txtLocal.Click += Button_Edit_Click;
            txtLocalComm.Click += Button_Edit_Click;
        }
        private void RibunButtons()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                Button_Close.Text = "اغلاق";
                Button_Save.Text = "حفظ";
                Button_Close.Tooltip = "Esc";
                Button_Save.Tooltip = "F2";
                Text = "كرت تعديل أسعار المكالمات";
            }
            else
            {
                Button_Close.Text = "Close";
                Button_Save.Text = "Save";
                Button_Close.Tooltip = "Esc";
                Button_Save.Tooltip = "F2";
                Text = "Call rate adjustment card";
            }
        }
        private void FrmPhoneCall_Load(object sender, EventArgs e)
        {
            try
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmPhoneCall));
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
                Permmission = dbc.Get_PermissionID(VarGeneral.UserID);
                RibunButtons();
                BinData();
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Load:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        public void BinData()
        {
            try
            {
                State = FormState.Saved;
                Button_Save.Enabled = false;
                txtLocal.Value = db.StockTelMn(0).price.Value;
                txtLocalComm.Value = db.StockTelMn(0).d.Value;
                txtInside.Value = db.StockTelMn(1).price.Value;
                txtInsideComm.Value = db.StockTelMn(1).d.Value;
                txtArCountry.Value = db.StockTelMn(2).price.Value;
                txtArCountryComm.Value = db.StockTelMn(2).d.Value;
                txtEngCountry.Value = db.StockTelMn(3).price.Value;
                txtEngCountryComm.Value = db.StockTelMn(3).d.Value;
                txtByMoon.Value = db.StockTelMn(4).price.Value;
                txtByMoonComm.Value = db.StockTelMn(4).d.Value;
                try
                {
                    if (!string.IsNullOrEmpty(db.StockTelMn(0).accno))
                    {
                        txtServiceAcc.Text = db.StockTelMn(0).accno;
                        txtServiceAccName.Text = ((LangArEn == 0) ? db.StockAccDefWithOutBalance(db.StockTelMn(0).accno).Arb_Des : db.StockAccDefWithOutBalance(db.StockTelMn(0).accno).Eng_Des);
                    }
                    else
                    {
                        txtServiceAcc.Text = "";
                        txtServiceAccName.Text = "";
                    }
                }
                catch
                {
                    txtServiceAcc.Text = "";
                    txtServiceAccName.Text = "";
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("SetData:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void Button_Edit_Click(object sender, EventArgs e)
        {
            if (CanEdit && State != FormState.Edit && State != FormState.New)
            {
                if (State != FormState.New)
                {
                    State = FormState.Edit;
                }
                SetReadOnly = false;
            }
        }
        private void Button_Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Button_Save.Enabled)
                {
                    return;
                }
                if (State == FormState.Edit && !CanEdit)
                {
                    MessageBox.Show((LangArEn == 0) ? "لا يمكن اتمام هذه العملية .. الرجاء مراجعة صلاحيات المستخدمين !" : "Can not complete this process .. please see the powers of the users!", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                try
                {
                    db.ExecuteCommand("UPDATE [T_telmn] SET [price] = " + txtLocal.Value + " ,[d] = " + txtLocalComm.Value + ",accno = '" + txtServiceAcc.Text + "' WHERE pl = 0");
                    db.ExecuteCommand("UPDATE [T_telmn] SET [price] = " + txtInside.Value + " ,[d] = " + txtInsideComm.Value + ",accno = '" + txtServiceAcc.Text + "' WHERE pl = 1");
                    db.ExecuteCommand("UPDATE [T_telmn] SET [price] = " + txtArCountry.Value + " ,[d] = " + txtArCountryComm.Value + ",accno = '" + txtServiceAcc.Text + "' WHERE pl = 2");
                    db.ExecuteCommand("UPDATE [T_telmn] SET [price] = " + txtEngCountry.Value + " ,[d] = " + txtEngCountryComm.Value + ",accno = '" + txtServiceAcc.Text + "' WHERE pl = 3");
                    db.ExecuteCommand("UPDATE [T_telmn] SET [price] = " + txtByMoon.Value + " ,[d] = " + txtByMoonComm.Value + ",accno = '" + txtServiceAcc.Text + "' WHERE pl = 4");
                }
                catch (SqlException)
                {
                    return;
                }
                Close();
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Save:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void txtServiceAcc_ButtonCustomClick(object sender, EventArgs e)
        {
            Button_Edit_Click(sender, e);
            columns_Names_visible.Clear();
            columns_Names_visible.Add("AccDef_No", new ColumnDictinary("الرقم ", " No", ifDefault: true, ""));
            columns_Names_visible.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, ""));
            columns_Names_visible.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, ""));
            columns_Names_visible.Add("AccDef_ID", new ColumnDictinary(" ", " ", ifDefault: false, ""));
            columns_Names_visible.Add("Mobile", new ColumnDictinary("الجوال", "Mobile", ifDefault: false, ""));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, ""));
            }
            VarGeneral.SFrmTyp = "AccDefID_Setting";
            VarGeneral.AccTyp = 11;
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != "")
            {
                T_AccDef _AccDef = db.StockAccDefs(int.Parse(frm.Serach_No));
                txtServiceAcc.Text = _AccDef.AccDef_No.ToString();
                txtServiceAccName.Text = ((LangArEn == 0) ? db.StockAccDefWithOutBalance(txtServiceAcc.Text).Arb_Des : db.StockAccDefWithOutBalance(txtServiceAcc.Text).Eng_Des);
            }
            else
            {
                txtServiceAcc.Text = "";
                txtServiceAccName.Text = "";
            }
        }
        private void txtServiceAcc_Click(object sender, EventArgs e)
        {
            txtServiceAcc.SelectAll();
        }
        private void txtServiceAccName_Click(object sender, EventArgs e)
        {
            txtServiceAccName.SelectAll();
        }
    }
}
