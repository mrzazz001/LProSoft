using DevComponents.DotNetBar;
using DevComponents.Editors;
using Framework.Date;
using Framework.UI;
using InvAcc.GeneralM;
using InvAcc.Stock_Data;
using Library.RepShow;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial class FrmEqarAccRep : Form
    {
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
        private int LangArEn = 0;
        private T_User _User = new T_User();
        public Dictionary<string, ColumnDictinary> columns_Names_visible = new Dictionary<string, ColumnDictinary>();
        private Stock_DataDataContext dbInstance;
        private Rate_DataDataContext dbInstanceRate;
        private IContainer components = null;
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (!keyData.ToString().Contains("Control") && !keyData.ToString().ToLower().Contains("delete") && keyData.ToString().Contains("Alt"))
            {
                try
                {
                    VarGeneral.Print_set_Gen_Stat = true;
                    FrmReportsViewer.IsSettingOnly = true;
                    VarGeneral.IsGeneralUsed = true;

                    {

                        FrmReportsViewer frm = new FrmReportsViewer();
                        frm.Repvalue = "AccountEqar";


                        frm.Repvalue = "AccountEqar";
                        //ADDADD





                        frm.Tag = LangArEn;
                        frm.ShowDialog();
                        VarGeneral.IsGeneralUsed = false;
                    }
                    FrmReportsViewer.IsSettingOnly = false;
                }
                catch
                {
                    VarGeneral.Print_set_Gen_Stat = false;
                }


            }
            return base.ProcessCmdKey(ref msg, keyData);
        }


        private TextBox txtFromAccNo;
        private RibbonBar ribbonBar1;
        private TextBox txtIntoAccName;
        private TextBox txtEqarName;
        private TextBox txtFromAccName;
        private TextBox txtIntoAccNo;
        private TextBox txtEqarNo;
        private ButtonX ButExit;
        private ButtonX ButOk;
        private Label label7;
        private Label label6;
        private Label label5;
        private ButtonX button_SrchEqarNo;
        private ButtonX button_SrchAccTo;
        private ButtonX button_SrchAccFrom;
        private GroupBox groupBox4;
        private MaskedTextBox txtMToDate;
        private MaskedTextBox txtMFromDate;
        private Label label1;
        private Label label2;
        private GroupBox groupBox3;
        private DoubleInput txtMBalanceB;
        private DoubleInput txtMBalanceS;
        private Label label3;
        private Label label4;
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
        public FrmEqarAccRep()
        {
            InitializeComponent();
            _User = dbc.StockUser(VarGeneral.UserNumber);
            HijriGregDates dateFormatter = new HijriGregDates();
            if (VarGeneral.Settings_Sys.Calendr.Value == 0)
            {
                txtMFromDate.Text = VarGeneral.Gdate.Substring(0, 4) + "/01/01";
                txtMToDate.Text = dateFormatter.FormatGreg(VarGeneral.Gdate, "yyyy/MM/dd");
            }
            else
            {
                txtMFromDate.Text = VarGeneral.Hdate.Substring(0, 4) + "/01/01";
                txtMToDate.Text = dateFormatter.FormatGreg(VarGeneral.Hdate, "yyyy/MM/dd");
            }
            if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49))
            {
                txtMBalanceB.DisplayFormat = VarGeneral.DicemalMask;
                txtMBalanceS.DisplayFormat = VarGeneral.DicemalMask;
            }
        }
        protected override void OnLoad(EventArgs e)
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmEqarAccRep));
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
            RibunButtons();
            try
            {
                VarGeneral.itmDesIndex = 0;
                VarGeneral.itmDes = "";
                VarGeneral._DTFrom = "";
                VarGeneral._DTTo = "";
            }
            catch
            {
            }
        }
        protected override void OnParentRightToLeftChanged(EventArgs e)
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmEqarAccRep));
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
        private string BuildRuleList()
        {
            HijriGregDates dateFormatter = new HijriGregDates();
            string Rule = "Where T_GDHEAD.gdLok = 0 ";
            if (txtMBalanceB.LockUpdateChecked)
            {
                object obj = Rule;
                Rule = string.Concat(obj, " and ", txtMBalanceB.Tag, " >= ", txtMBalanceB.Value);
            }
            if (txtMBalanceS.LockUpdateChecked)
            {
                object obj = Rule;
                Rule = string.Concat(obj, " and ", txtMBalanceS.Tag, " <= ", txtMBalanceS.Value);
            }
            try
            {
                if (!string.IsNullOrEmpty(txtEqarNo.Text) && !string.IsNullOrEmpty(txtEqarNo.Tag.ToString()))
                {
                    object obj = Rule;
                    Rule = string.Concat(obj, " and ", txtEqarName.Tag, " = '", txtEqarNo.Tag.ToString().Trim(), "'");
                }
            }
            catch
            {
            }
            if (VarGeneral.CheckDate(txtMFromDate.Text) && txtMFromDate.Text.Length == 10)
            {
                Rule = ((int.Parse(txtMFromDate.Text.Substring(0, 4)) >= 1800) ? (Rule + " and  T_GDHEAD.gdGDate  >= '" + dateFormatter.FormatGreg(txtMFromDate.Text, "yyyy/MM/dd") + "'") : (Rule + " and  T_GDHEAD.gdHDate  >= '" + dateFormatter.FormatHijri(txtMFromDate.Text, "yyyy/MM/dd") + "'"));
            }
            if (VarGeneral.CheckDate(txtMToDate.Text) && txtMToDate.Text.Length == 10)
            {
                Rule = ((int.Parse(txtMToDate.Text.Substring(0, 4)) >= 1800) ? (Rule + " and  T_GDHEAD.gdGDate  <= '" + dateFormatter.FormatGreg(txtMToDate.Text, "yyyy/MM/dd") + "'") : (Rule + " and  T_GDHEAD.gdHDate  <= '" + dateFormatter.FormatHijri(txtMToDate.Text, "yyyy/MM/dd") + "'"));
            }
            return Rule;
        }
        private void ButOk_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    if (string.IsNullOrEmpty(txtEqarNo.Text) || string.IsNullOrEmpty(txtEqarNo.Tag.ToString()))
                    {
                        MessageBox.Show((LangArEn == 0) ? "يجب تحديد رقم العقار " : "must specify the account number ", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        txtEqarNo.Focus();
                        return;
                    }
                }
                catch
                {
                    MessageBox.Show((LangArEn == 0) ? "يجب تحديد رقم العقار " : "must specify the account number ", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    txtEqarNo.Focus();
                    return;
                }
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_GDDET LEFT OUTER JOIN  T_GDHEAD ON T_GDDET.gdID = T_GDHEAD.gdhead_ID  LEFT OUTER JOIN  T_AccDef ON T_GDDET.AccNo = T_AccDef.AccDef_No  LEFT OUTER JOIN T_EqarsData ON T_GDDET.AccNo = T_EqarsData.AccNo  LEFT OUTER JOIN T_Curency ON T_GDHEAD.CurTyp = T_Curency.Curency_ID  LEFT OUTER JOIN T_INVSETTING On T_GDHEAD.gdTyp = T_INVSETTING.InvID  LEFT OUTER JOIN T_SYSSETTING ON T_GDHEAD.CompanyID = T_SYSSETTING.SYSSETTING_ID";
                string Fields = "";
                Fields = ((LangArEn != 0) ? (" T_GDDET.AccNo as AccDef_No,(select Eng_Des from T_AccDef where T_AccDef.AccDef_No = T_GDDET.AccNo) as AccDefNm, T_GDHEAD.gdNo,T_INVSETTING.InvNamA as InvNm,T_GDHEAD.gdHDate,T_GDHEAD.gdGDate,T_GDDET.gdDes,CASE WHEN T_GDDET.gdValue > 0 THEN T_GDDET.gdValue ELSE 0 END as Debit,CASE WHEN T_GDDET.gdValue < 0 THEN Abs(T_GDDET.gdValue) ELSE 0 END as Credit , (Round(T_GDDET.gdValue," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + "))  as Balance,T_SYSSETTING.LogImg,T_SYSSETTING.Calendr,'" + txtEqarNo.Text + "' as tenantNo,'" + txtEqarName.Text + "' as TenantNmA,'" + txtEqarNo.Text + "' as TenantNmE ") : (" T_GDDET.AccNo as AccDef_No,(select Arb_Des from T_AccDef where T_AccDef.AccDef_No = T_GDDET.AccNo) as AccDefNm, T_GDHEAD.gdNo,T_INVSETTING.InvNamA as InvNm,T_GDHEAD.gdHDate,T_GDHEAD.gdGDate,T_GDDET.gdDes,CASE WHEN T_GDDET.gdValue > 0 THEN T_GDDET.gdValue ELSE 0 END as Debit,CASE WHEN T_GDDET.gdValue < 0 THEN Abs(T_GDDET.gdValue) ELSE 0 END as Credit , (Round(T_GDDET.gdValue," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + "))  as Balance,T_SYSSETTING.LogImg,T_SYSSETTING.Calendr,'" + txtEqarNo.Text + "' as tenantNo,'" + txtEqarName.Text + "' as TenantNmA,'" + txtEqarNo.Text + "' as TenantNmE "));
                _RepShow.Rule = BuildRuleList() + " order by T_GDHEAD.gdTyp, T_GDHEAD.gdNo ";
                _RepShow.Fields = Fields;
                try
                {
                    _RepShow = _RepShow.Save();
                    VarGeneral.RepData = _RepShow.RepData;
                }
                catch (Exception ex2)
                {
                    MessageBox.Show(ex2.Message);
                }
                if (VarGeneral.RepData.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show((LangArEn == 0) ? "عفوا .. لا يوجد بيانات لعرضها في التقرير " : "Sorry .. there is no data to display in the report ", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
                try
                {
                    VarGeneral.IsGeneralUsed = true;
                    FrmReportsViewer frm = new FrmReportsViewer();
                    frm.Repvalue = "AccountEqar";



                    frm.Tag = LangArEn;
                    frm.Repvalue = "AccountEqar";
                    VarGeneral.vTitle = Text;
                    if (VarGeneral.CheckDate(txtMFromDate.Text))
                    {
                        VarGeneral._DTFrom = txtMFromDate.Text;
                    }
                    else
                    {
                        VarGeneral._DTFrom = "";
                    }
                    if (VarGeneral.CheckDate(txtMToDate.Text))
                    {
                        VarGeneral._DTTo = txtMToDate.Text;
                    }
                    else
                    {
                        VarGeneral._DTTo = "";
                    }
                    frm.TopMost = true;
                    frm.ShowDialog();
                    VarGeneral.IsGeneralUsed = false;

                }
                catch (Exception error)
                {
                    VarGeneral.DebLog.writeLog("button_ShowRep_Click:", error, enable: true);
                    MessageBox.Show(error.Message);
                }
            }
            catch (Exception ex2)
            {
                MessageBox.Show(ex2.Message);
            }
        }
        private void ButExit_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void button_SrchAccTo_Click(object sender, EventArgs e)
        {
            columns_Names_visible.Clear();
            columns_Names_visible.Add("AccDef_No", new ColumnDictinary("الرقم ", " No", ifDefault: true, ""));
            columns_Names_visible.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, ""));
            columns_Names_visible.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, ""));
            columns_Names_visible.Add("AccDef_ID", new ColumnDictinary(" ", " ", ifDefault: false, ""));
            columns_Names_visible.Add("Mobile", new ColumnDictinary("الجوال", "Mobile", ifDefault: false, ""));
            columns_Names_visible.Add("TaxNo", new ColumnDictinary("الرقم الضريبي", "Tax No", ifDefault: false, ""));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, ""));
            }
            VarGeneral.SFrmTyp = "AccDefID_Setting";
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != "")
            {
                txtIntoAccNo.Text = db.StockAccDefs(int.Parse(frm.Serach_No)).AccDef_No;
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                {
                    txtIntoAccName.Text = db.StockAccDefs(int.Parse(frm.Serach_No)).Arb_Des;
                }
                else
                {
                    txtIntoAccName.Text = db.StockAccDefs(int.Parse(frm.Serach_No)).Eng_Des;
                }
            }
            else
            {
                txtIntoAccNo.Text = "";
                txtIntoAccName.Text = "";
            }
        }
        private void button_SrchAccFrom_Click(object sender, EventArgs e)
        {
            columns_Names_visible.Clear();
            columns_Names_visible.Add("AccDef_No", new ColumnDictinary("الرقم ", " No", ifDefault: true, ""));
            columns_Names_visible.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, ""));
            columns_Names_visible.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, ""));
            columns_Names_visible.Add("AccDef_ID", new ColumnDictinary(" ", " ", ifDefault: false, ""));
            columns_Names_visible.Add("Mobile", new ColumnDictinary("الجوال", "Mobile", ifDefault: false, ""));
            columns_Names_visible.Add("TaxNo", new ColumnDictinary("الرقم الضريبي", "Tax No", ifDefault: false, ""));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, ""));
            }
            VarGeneral.SFrmTyp = "AccDefID_Setting";
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != "")
            {
                txtFromAccNo.Text = db.StockAccDefs(int.Parse(frm.Serach_No)).AccDef_No;
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                {
                    txtFromAccName.Text = db.StockAccDefs(int.Parse(frm.Serach_No)).Arb_Des;
                }
                else
                {
                    txtFromAccName.Text = db.StockAccDefs(int.Parse(frm.Serach_No)).Eng_Des;
                }
            }
            else
            {
                txtFromAccNo.Text = "";
                txtFromAccName.Text = "";
            }
        }
        private void txtMFromDate_Click(object sender, EventArgs e)
        {
            txtMFromDate.SelectAll();
        }
        private void txtMToDate_Click(object sender, EventArgs e)
        {
            txtMToDate.SelectAll();
        }
        private void txtMFromDate_Leave(object sender, EventArgs e)
        {
            try
            {
                if (VarGeneral.CheckDate(txtMFromDate.Text))
                {
                    txtMFromDate.Text = Convert.ToDateTime(txtMFromDate.Text).ToString("yyyy/MM/dd");
                }
                else
                {
                    txtMFromDate.Text = "";
                }
            }
            catch
            {
                txtMFromDate.Text = "";
            }
        }
        private void txtMToDate_Leave(object sender, EventArgs e)
        {
            try
            {
                if (VarGeneral.CheckDate(txtMToDate.Text))
                {
                    txtMToDate.Text = Convert.ToDateTime(txtMToDate.Text).ToString("yyyy/MM/dd");
                }
                else
                {
                    txtMToDate.Text = "";
                }
            }
            catch
            {
                txtMToDate.Text = "";
            }
        }
        private void RibunButtons()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                ButExit.Text = "خــــروج Esc";
                ButOk.Text = ((VarGeneral.GeneralPrinter.nTyp_Setting.Substring(2, 1) == "0") ? "طبـــاعة F5" : "عــــرض F5");
                groupBox3.Text = "الرصيــــد";
                groupBox4.Text = "التاريــــخ";
                label1.Text = "مـــــن :";
                label2.Text = "إلـــــى :";
                label7.Text = "العقــــــــــار :";
                Text = "كشف حساب عقــار";
            }
            else
            {
                ButExit.Text = "Exit Esc";
                ButOk.Text = ((VarGeneral.GeneralPrinter.nTyp_Setting.Substring(2, 1) == "0") ? "Print F5" : "Show F5");
                groupBox3.Text = "Balance";
                groupBox4.Text = "Date";
                label1.Text = "From :";
                label2.Text = "To :";
                label7.Text = "Real estate :";
                Text = "Real estate account statement";
            }
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
            if (e.KeyCode == Keys.F5 && ButOk.Enabled && ButOk.Visible)
            {
                ButOk_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
        private void FrmEqarAccRep_Load(object sender, EventArgs e)
        {
        }
        private void button_SrchTenantNo_Click(object sender, EventArgs e)
        {
            columns_Names_visible.Clear();
            columns_Names_visible.Add("EqarNo", new ColumnDictinary("الرقم ", " No", ifDefault: true, ""));
            columns_Names_visible.Add("NameA", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, ""));
            columns_Names_visible.Add("NameE", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, ""));
            columns_Names_visible.Add("ContractValue", new ColumnDictinary("قيمة العقار", "Property value", ifDefault: true, ""));
            columns_Names_visible.Add("ContractRentValue", new ColumnDictinary("إيجار العقار", "Rent the property", ifDefault: false, ""));
            columns_Names_visible.Add("FloorsCount", new ColumnDictinary("عدد الطوابق", "Floors Count", ifDefault: false, ""));
            columns_Names_visible.Add("EyesCount", new ColumnDictinary("عدد العيون", "Eyes Count", ifDefault: false, ""));
            columns_Names_visible.Add("Space", new ColumnDictinary("مساحة العقار", "Space", ifDefault: false, ""));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, ""));
            }
            VarGeneral.SFrmTyp = "T_EqarsData";
            frm.TopMost = true;
            frm.ShowDialog();
            try
            {
                if (frm.SerachNo != "")
                {
                    T_EqarsData _Eqar = db.EqarsDataEmp(int.Parse(frm.Serach_No));
                    txtEqarNo.Text = frm.Serach_No;
                    txtEqarNo.Tag = _Eqar.AccNo;
                    if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                    {
                        txtEqarName.Text = _Eqar.NameA;
                    }
                    else
                    {
                        txtEqarName.Text = _Eqar.NameE;
                    }
                }
                else
                {
                    txtEqarNo.Text = "";
                    txtEqarName.Text = "";
                    txtEqarNo.Tag = "";
                }
            }
            catch
            {
                txtEqarNo.Text = "";
                txtEqarName.Text = "";
                txtEqarNo.Tag = "";
            }
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InvAcc.Forms.FrmEqarAccRep));
            txtFromAccNo = new System.Windows.Forms.TextBox();
            ribbonBar1 = new DevComponents.DotNetBar.RibbonBar();
            groupBox3 = new System.Windows.Forms.GroupBox();
            txtMBalanceB = new DevComponents.Editors.DoubleInput();
            txtMBalanceS = new DevComponents.Editors.DoubleInput();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            groupBox4 = new System.Windows.Forms.GroupBox();
            txtMToDate = new System.Windows.Forms.MaskedTextBox();
            txtMFromDate = new System.Windows.Forms.MaskedTextBox();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            txtIntoAccName = new System.Windows.Forms.TextBox();
            txtFromAccName = new System.Windows.Forms.TextBox();
            txtIntoAccNo = new System.Windows.Forms.TextBox();
            txtEqarNo = new System.Windows.Forms.TextBox();
            ButExit = new DevComponents.DotNetBar.ButtonX();
            ButOk = new DevComponents.DotNetBar.ButtonX();
            label7 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            button_SrchEqarNo = new DevComponents.DotNetBar.ButtonX();
            button_SrchAccTo = new DevComponents.DotNetBar.ButtonX();
            button_SrchAccFrom = new DevComponents.DotNetBar.ButtonX();
            txtEqarName = new System.Windows.Forms.TextBox();
            ribbonBar1.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtMBalanceB).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtMBalanceS).BeginInit();
            groupBox4.SuspendLayout();
            SuspendLayout();
            txtFromAccNo.AccessibleDescription = null;
            txtFromAccNo.AccessibleName = null;
            resources.ApplyResources(txtFromAccNo, "txtFromAccNo");
            txtFromAccNo.BackColor = System.Drawing.Color.White;
            txtFromAccNo.BackgroundImage = null;
            txtFromAccNo.Font = null;
            txtFromAccNo.Name = "txtFromAccNo";
            txtFromAccNo.ReadOnly = true;
            txtFromAccNo.Tag = " T_GDDET.AccNo ";
            ribbonBar1.AccessibleDescription = null;
            ribbonBar1.AccessibleName = null;
            resources.ApplyResources(ribbonBar1, "ribbonBar1");
            ribbonBar1.AutoOverflowEnabled = true;
            ribbonBar1.BackgroundImage = null;
            ribbonBar1.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            ribbonBar1.BackgroundStyle.BackColor = System.Drawing.Color.AliceBlue;
            ribbonBar1.BackgroundStyle.BackColor2 = System.Drawing.SystemColors.GradientActiveCaption;
            ribbonBar1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            ribbonBar1.ContainerControlProcessDialogKey = true;
            ribbonBar1.Controls.Add(groupBox3);
            ribbonBar1.Controls.Add(groupBox4);
            ribbonBar1.Controls.Add(txtIntoAccName);
            ribbonBar1.Controls.Add(txtFromAccName);
            ribbonBar1.Controls.Add(txtFromAccNo);
            ribbonBar1.Controls.Add(txtIntoAccNo);
            ribbonBar1.Controls.Add(txtEqarNo);
            ribbonBar1.Controls.Add(ButExit);
            ribbonBar1.Controls.Add(ButOk);
            ribbonBar1.Controls.Add(label7);
            ribbonBar1.Controls.Add(label6);
            ribbonBar1.Controls.Add(label5);
            ribbonBar1.Controls.Add(button_SrchEqarNo);
            ribbonBar1.Controls.Add(button_SrchAccTo);
            ribbonBar1.Controls.Add(button_SrchAccFrom);
            ribbonBar1.Controls.Add(txtEqarName);
            ribbonBar1.Font = null;
            ribbonBar1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            ribbonBar1.Name = "ribbonBar1";
            ribbonBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            ribbonBar1.TitleStyle.BackColor = System.Drawing.Color.FromArgb(227, 239, 255);
            ribbonBar1.TitleStyle.BackColor2 = System.Drawing.Color.FromArgb(101, 147, 207);
            ribbonBar1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            ribbonBar1.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            groupBox3.AccessibleDescription = null;
            groupBox3.AccessibleName = null;
            resources.ApplyResources(groupBox3, "groupBox3");
            groupBox3.BackColor = System.Drawing.Color.Transparent;
            groupBox3.BackgroundImage = null;
            groupBox3.Controls.Add(txtMBalanceB);
            groupBox3.Controls.Add(txtMBalanceS);
            groupBox3.Controls.Add(label3);
            groupBox3.Controls.Add(label4);
            groupBox3.Name = "groupBox3";
            groupBox3.TabStop = false;
            txtMBalanceB.AccessibleDescription = null;
            txtMBalanceB.AccessibleName = null;
            txtMBalanceB.AllowEmptyState = false;
            resources.ApplyResources(txtMBalanceB, "txtMBalanceB");
            txtMBalanceB.BackgroundImage = null;
            txtMBalanceB.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            txtMBalanceB.BackgroundStyle.Class = "DateTimeInputBackground";
            txtMBalanceB.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            txtMBalanceB.ButtonCalculator.DisplayPosition = (int)resources.GetObject("txtMBalanceB.ButtonCalculator.DisplayPosition");
            txtMBalanceB.ButtonCalculator.Image = null;
            txtMBalanceB.ButtonCalculator.Text = resources.GetString("txtMBalanceB.ButtonCalculator.Text");
            txtMBalanceB.ButtonClear.DisplayPosition = (int)resources.GetObject("txtMBalanceB.ButtonClear.DisplayPosition");
            txtMBalanceB.ButtonClear.Image = null;
            txtMBalanceB.ButtonClear.Text = resources.GetString("txtMBalanceB.ButtonClear.Text");
            txtMBalanceB.ButtonCustom.DisplayPosition = (int)resources.GetObject("txtMBalanceB.ButtonCustom.DisplayPosition");
            txtMBalanceB.ButtonCustom.Image = null;
            txtMBalanceB.ButtonCustom.Text = resources.GetString("txtMBalanceB.ButtonCustom.Text");
            txtMBalanceB.ButtonCustom2.DisplayPosition = (int)resources.GetObject("txtMBalanceB.ButtonCustom2.DisplayPosition");
            txtMBalanceB.ButtonCustom2.Image = null;
            txtMBalanceB.ButtonCustom2.Text = resources.GetString("txtMBalanceB.ButtonCustom2.Text");
            txtMBalanceB.ButtonDropDown.DisplayPosition = (int)resources.GetObject("txtMBalanceB.ButtonDropDown.DisplayPosition");
            txtMBalanceB.ButtonDropDown.Image = null;
            txtMBalanceB.ButtonDropDown.Text = resources.GetString("txtMBalanceB.ButtonDropDown.Text");
            txtMBalanceB.ButtonFreeText.DisplayPosition = (int)resources.GetObject("txtMBalanceB.ButtonFreeText.DisplayPosition");
            txtMBalanceB.ButtonFreeText.Image = null;
            txtMBalanceB.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            txtMBalanceB.ButtonFreeText.Text = resources.GetString("txtMBalanceB.ButtonFreeText.Text");
            txtMBalanceB.CommandParameter = null;
            txtMBalanceB.Increment = 1.0;
            txtMBalanceB.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            txtMBalanceB.LockUpdateChecked = false;
            txtMBalanceB.Name = "txtMBalanceB";
            txtMBalanceB.ShowCheckBox = true;
            txtMBalanceB.ShowUpDown = true;
            txtMBalanceB.Tag = "T_GDDET.gdValue";
            txtMBalanceS.AccessibleDescription = null;
            txtMBalanceS.AccessibleName = null;
            txtMBalanceS.AllowEmptyState = false;
            resources.ApplyResources(txtMBalanceS, "txtMBalanceS");
            txtMBalanceS.BackgroundImage = null;
            txtMBalanceS.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            txtMBalanceS.BackgroundStyle.Class = "DateTimeInputBackground";
            txtMBalanceS.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            txtMBalanceS.ButtonCalculator.DisplayPosition = (int)resources.GetObject("txtMBalanceS.ButtonCalculator.DisplayPosition");
            txtMBalanceS.ButtonCalculator.Image = null;
            txtMBalanceS.ButtonCalculator.Text = resources.GetString("txtMBalanceS.ButtonCalculator.Text");
            txtMBalanceS.ButtonClear.DisplayPosition = (int)resources.GetObject("txtMBalanceS.ButtonClear.DisplayPosition");
            txtMBalanceS.ButtonClear.Image = null;
            txtMBalanceS.ButtonClear.Text = resources.GetString("txtMBalanceS.ButtonClear.Text");
            txtMBalanceS.ButtonCustom.DisplayPosition = (int)resources.GetObject("txtMBalanceS.ButtonCustom.DisplayPosition");
            txtMBalanceS.ButtonCustom.Image = null;
            txtMBalanceS.ButtonCustom.Text = resources.GetString("txtMBalanceS.ButtonCustom.Text");
            txtMBalanceS.ButtonCustom2.DisplayPosition = (int)resources.GetObject("txtMBalanceS.ButtonCustom2.DisplayPosition");
            txtMBalanceS.ButtonCustom2.Image = null;
            txtMBalanceS.ButtonCustom2.Text = resources.GetString("txtMBalanceS.ButtonCustom2.Text");
            txtMBalanceS.ButtonDropDown.DisplayPosition = (int)resources.GetObject("txtMBalanceS.ButtonDropDown.DisplayPosition");
            txtMBalanceS.ButtonDropDown.Image = null;
            txtMBalanceS.ButtonDropDown.Text = resources.GetString("txtMBalanceS.ButtonDropDown.Text");
            txtMBalanceS.ButtonFreeText.DisplayPosition = (int)resources.GetObject("txtMBalanceS.ButtonFreeText.DisplayPosition");
            txtMBalanceS.ButtonFreeText.Image = null;
            txtMBalanceS.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            txtMBalanceS.ButtonFreeText.Text = resources.GetString("txtMBalanceS.ButtonFreeText.Text");
            txtMBalanceS.CommandParameter = null;
            txtMBalanceS.Increment = 1.0;
            txtMBalanceS.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            txtMBalanceS.LockUpdateChecked = false;
            txtMBalanceS.Name = "txtMBalanceS";
            txtMBalanceS.ShowCheckBox = true;
            txtMBalanceS.ShowUpDown = true;
            txtMBalanceS.Tag = "T_GDDET.gdValue";
            label3.AccessibleDescription = null;
            label3.AccessibleName = null;
            resources.ApplyResources(label3, "label3");
            label3.BackColor = System.Drawing.Color.Transparent;
            label3.Name = "label3";
            label4.AccessibleDescription = null;
            label4.AccessibleName = null;
            resources.ApplyResources(label4, "label4");
            label4.BackColor = System.Drawing.Color.Transparent;
            label4.Name = "label4";
            groupBox4.AccessibleDescription = null;
            groupBox4.AccessibleName = null;
            resources.ApplyResources(groupBox4, "groupBox4");
            groupBox4.BackColor = System.Drawing.Color.Transparent;
            groupBox4.BackgroundImage = null;
            groupBox4.Controls.Add(txtMToDate);
            groupBox4.Controls.Add(txtMFromDate);
            groupBox4.Controls.Add(label1);
            groupBox4.Controls.Add(label2);
            groupBox4.Name = "groupBox4";
            groupBox4.TabStop = false;
            txtMToDate.AccessibleDescription = null;
            txtMToDate.AccessibleName = null;
            resources.ApplyResources(txtMToDate, "txtMToDate");
            txtMToDate.BackgroundImage = null;
            txtMToDate.Font = null;
            txtMToDate.Name = "txtMToDate";
            txtMToDate.Leave += new System.EventHandler(txtMToDate_Leave);
            txtMToDate.Click += new System.EventHandler(txtMToDate_Click);
            txtMFromDate.AccessibleDescription = null;
            txtMFromDate.AccessibleName = null;
            resources.ApplyResources(txtMFromDate, "txtMFromDate");
            txtMFromDate.BackgroundImage = null;
            txtMFromDate.Font = null;
            txtMFromDate.Name = "txtMFromDate";
            txtMFromDate.Leave += new System.EventHandler(txtMFromDate_Leave);
            txtMFromDate.Click += new System.EventHandler(txtMFromDate_Click);
            label1.AccessibleDescription = null;
            label1.AccessibleName = null;
            resources.ApplyResources(label1, "label1");
            label1.BackColor = System.Drawing.Color.Transparent;
            label1.Name = "label1";
            label2.AccessibleDescription = null;
            label2.AccessibleName = null;
            resources.ApplyResources(label2, "label2");
            label2.BackColor = System.Drawing.Color.Transparent;
            label2.Name = "label2";
            txtIntoAccName.AccessibleDescription = null;
            txtIntoAccName.AccessibleName = null;
            resources.ApplyResources(txtIntoAccName, "txtIntoAccName");
            txtIntoAccName.BackColor = System.Drawing.Color.DarkSeaGreen;
            txtIntoAccName.BackgroundImage = null;
            txtIntoAccName.Font = null;
            txtIntoAccName.ForeColor = System.Drawing.Color.White;
            txtIntoAccName.Name = "txtIntoAccName";
            txtIntoAccName.ReadOnly = true;
            txtFromAccName.AccessibleDescription = null;
            txtFromAccName.AccessibleName = null;
            resources.ApplyResources(txtFromAccName, "txtFromAccName");
            txtFromAccName.BackColor = System.Drawing.Color.DarkSeaGreen;
            txtFromAccName.BackgroundImage = null;
            txtFromAccName.Font = null;
            txtFromAccName.ForeColor = System.Drawing.Color.White;
            txtFromAccName.Name = "txtFromAccName";
            txtFromAccName.ReadOnly = true;
            txtIntoAccNo.AccessibleDescription = null;
            txtIntoAccNo.AccessibleName = null;
            resources.ApplyResources(txtIntoAccNo, "txtIntoAccNo");
            txtIntoAccNo.BackColor = System.Drawing.Color.White;
            txtIntoAccNo.BackgroundImage = null;
            txtIntoAccNo.Font = null;
            txtIntoAccNo.Name = "txtIntoAccNo";
            txtIntoAccNo.ReadOnly = true;
            txtIntoAccNo.Tag = " T_GDDET.AccNo ";
            txtEqarNo.AccessibleDescription = null;
            txtEqarNo.AccessibleName = null;
            resources.ApplyResources(txtEqarNo, "txtEqarNo");
            txtEqarNo.BackColor = System.Drawing.Color.White;
            txtEqarNo.BackgroundImage = null;
            txtEqarNo.Font = null;
            txtEqarNo.Name = "txtEqarNo";
            txtEqarNo.ReadOnly = true;
            txtEqarNo.Tag = "";
            ButExit.AccessibleDescription = null;
            ButExit.AccessibleName = null;
            ButExit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            resources.ApplyResources(ButExit, "ButExit");
            ButExit.BackgroundImage = null;
            ButExit.Checked = true;
            ButExit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            ButExit.CommandParameter = null;
            ButExit.Name = "ButExit";
            ButExit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            ButExit.Symbol = "\uf011";
            ButExit.SymbolSize = 16f;
            ButExit.TextColor = System.Drawing.Color.Black;
            ButExit.Click += new System.EventHandler(ButExit_Click);
            ButOk.AccessibleDescription = null;
            ButOk.AccessibleName = null;
            ButOk.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            resources.ApplyResources(ButOk, "ButOk");
            ButOk.BackgroundImage = null;
            ButOk.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            ButOk.CommandParameter = null;
            ButOk.Name = "ButOk";
            ButOk.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            ButOk.Symbol = "\uf0c5";
            ButOk.SymbolSize = 16f;
            ButOk.TextColor = System.Drawing.Color.White;
            ButOk.Click += new System.EventHandler(ButOk_Click);
            label7.AccessibleDescription = null;
            label7.AccessibleName = null;
            resources.ApplyResources(label7, "label7");
            label7.BackColor = System.Drawing.Color.Transparent;
            label7.Name = "label7";
            label6.AccessibleDescription = null;
            label6.AccessibleName = null;
            resources.ApplyResources(label6, "label6");
            label6.BackColor = System.Drawing.Color.Transparent;
            label6.Name = "label6";
            label5.AccessibleDescription = null;
            label5.AccessibleName = null;
            resources.ApplyResources(label5, "label5");
            label5.BackColor = System.Drawing.Color.Transparent;
            label5.Name = "label5";
            button_SrchEqarNo.AccessibleDescription = null;
            button_SrchEqarNo.AccessibleName = null;
            button_SrchEqarNo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            resources.ApplyResources(button_SrchEqarNo, "button_SrchEqarNo");
            button_SrchEqarNo.BackgroundImage = null;
            button_SrchEqarNo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            button_SrchEqarNo.CommandParameter = null;
            button_SrchEqarNo.Font = null;
            button_SrchEqarNo.Name = "button_SrchEqarNo";
            button_SrchEqarNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            button_SrchEqarNo.Symbol = "\uf002";
            button_SrchEqarNo.SymbolSize = 12f;
            button_SrchEqarNo.TextColor = System.Drawing.Color.SteelBlue;
            button_SrchEqarNo.Click += new System.EventHandler(button_SrchTenantNo_Click);
            button_SrchAccTo.AccessibleDescription = null;
            button_SrchAccTo.AccessibleName = null;
            button_SrchAccTo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            resources.ApplyResources(button_SrchAccTo, "button_SrchAccTo");
            button_SrchAccTo.BackgroundImage = null;
            button_SrchAccTo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            button_SrchAccTo.CommandParameter = null;
            button_SrchAccTo.Font = null;
            button_SrchAccTo.Name = "button_SrchAccTo";
            button_SrchAccTo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            button_SrchAccTo.Symbol = "\uf002";
            button_SrchAccTo.SymbolSize = 12f;
            button_SrchAccTo.TextColor = System.Drawing.Color.SteelBlue;
            button_SrchAccTo.Click += new System.EventHandler(button_SrchAccTo_Click);
            button_SrchAccFrom.AccessibleDescription = null;
            button_SrchAccFrom.AccessibleName = null;
            button_SrchAccFrom.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            resources.ApplyResources(button_SrchAccFrom, "button_SrchAccFrom");
            button_SrchAccFrom.BackgroundImage = null;
            button_SrchAccFrom.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            button_SrchAccFrom.CommandParameter = null;
            button_SrchAccFrom.Font = null;
            button_SrchAccFrom.Name = "button_SrchAccFrom";
            button_SrchAccFrom.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            button_SrchAccFrom.Symbol = "\uf002";
            button_SrchAccFrom.SymbolSize = 12f;
            button_SrchAccFrom.TextColor = System.Drawing.Color.SteelBlue;
            button_SrchAccFrom.Click += new System.EventHandler(button_SrchAccFrom_Click);
            txtEqarName.AccessibleDescription = null;
            txtEqarName.AccessibleName = null;
            resources.ApplyResources(txtEqarName, "txtEqarName");
            txtEqarName.BackColor = System.Drawing.Color.DarkSeaGreen;
            txtEqarName.BackgroundImage = null;
            txtEqarName.Font = null;
            txtEqarName.ForeColor = System.Drawing.Color.White;
            txtEqarName.Name = "txtEqarName";
            txtEqarName.ReadOnly = true;
            txtEqarName.Tag = "T_GDDET.AccNo";
            base.AccessibleDescription = null;
            base.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackgroundImage = null;
            base.Controls.Add(ribbonBar1);
            Font = null;
            base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            base.KeyPreview = true;
            base.MaximizeBox = false;
            base.Name = "FrmEqarAccRep";
            base.Load += new System.EventHandler(FrmEqarAccRep_Load);
            base.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Frm_KeyPress);
            base.KeyDown += new System.Windows.Forms.KeyEventHandler(Frm_KeyDown);
            ribbonBar1.ResumeLayout(false);
            ribbonBar1.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)txtMBalanceB).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtMBalanceS).EndInit();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ResumeLayout(false);
        }
    }
}
