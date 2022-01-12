using DevComponents.DotNetBar;
using DevComponents.Editors;
using Framework.Date;
using Framework.UI;
using ProShared.GeneralM;using ProShared;
using ProShared.Stock_Data;
using Library.RepShow;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial  class FrmEqarAccTenantRep : Form
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
        private int LangArEn = 0;
        private T_User _User = new T_User();
        public Dictionary<string, ColumnDictinary> columns_Names_visible = new Dictionary<string, ColumnDictinary>();
        private Stock_DataDataContext dbInstance;
        private Rate_DataDataContext dbInstanceRate;
       // private IContainer components = null;
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData.ToString().Contains("Control") && !keyData.ToString().ToLower().Contains("delete") && keyData.ToString().Contains("Alt"))
            {
                try
                {
                    VarGeneral.Print_set_Gen_Stat = true;
                    FrmReportsViewer.IsSettingOnly = true;
                    VarGeneral.IsGeneralUsed = true;
                    {
                        FrmReportsViewer frm = new FrmReportsViewer();
                        frm.Repvalue = "AccountTrancEqar";
                        frm.Repvalue = "AccountTrancEqar";
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
        private TextBox txtTenantName;
        private TextBox txtFromAccName;
        private TextBox txtIntoAccNo;
        private TextBox txtTenantNo;
        private ButtonX ButExit;
        private ButtonX ButOk;
        private Label label7;
        private Label label6;
        private Label label5;
        private ButtonX button_SrchTenantNo;
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
        public FrmEqarAccTenantRep()
        {
            InitializeComponent();this.Load += langloads;
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
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmEqarAccTenantRep));
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
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmEqarAccTenantRep));
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
                if (!string.IsNullOrEmpty(txtTenantNo.Text) && !string.IsNullOrEmpty(txtTenantNo.Tag.ToString()))
                {
                    object obj = Rule;
                    Rule = string.Concat(obj, " and ", txtTenantName.Tag, " = '", txtTenantNo.Tag.ToString().Trim(), "'");
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
                    if (string.IsNullOrEmpty(txtTenantNo.Text) || string.IsNullOrEmpty(txtTenantNo.Tag.ToString()))
                    {
                        MessageBox.Show((LangArEn == 0) ? "يجب تحديد رقم المستأجر " : "must specify the account number ", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        txtTenantNo.Focus();
                        return;
                    }
                }
                catch
                {
                    MessageBox.Show((LangArEn == 0) ? "يجب تحديد رقم المستأجر " : "must specify the account number ", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    txtTenantNo.Focus();
                    return;
                }
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_GDDET LEFT OUTER JOIN  T_GDHEAD ON T_GDDET.gdID = T_GDHEAD.gdhead_ID  LEFT OUTER JOIN  T_TenantContract ON T_GDHEAD.gdTp = T_TenantContract.tenant_ID  LEFT OUTER JOIN T_Tenant ON T_TenantContract.tenant_ID = T_Tenant.tenantID  LEFT OUTER JOIN T_Curency ON T_GDHEAD.CurTyp = T_Curency.Curency_ID  LEFT OUTER JOIN T_INVSETTING On T_GDHEAD.gdTyp = T_INVSETTING.InvID  LEFT OUTER JOIN T_SYSSETTING ON T_GDHEAD.CompanyID = T_SYSSETTING.SYSSETTING_ID";
                string Fields = "";
                Fields = ((LangArEn != 0) ? (" T_GDDET.AccNo as AccDef_No,(select Eng_Des from T_AccDef where T_AccDef.AccDef_No = T_GDDET.AccNo) as AccDefNm, T_GDHEAD.gdNo,T_INVSETTING.InvNamA as InvNm,T_GDHEAD.gdHDate,T_GDHEAD.gdGDate,T_GDDET.gdDes,CASE WHEN T_GDDET.gdValue > 0 THEN T_GDDET.gdValue ELSE 0 END as Debit,CASE WHEN T_GDDET.gdValue < 0 THEN Abs(T_GDDET.gdValue) ELSE 0 END as Credit , (Round(T_GDDET.gdValue," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + "))  as Balance,T_SYSSETTING.LogImg,T_SYSSETTING.Calendr,T_Tenant.tenantNo,T_Tenant.tenantID,'" + txtTenantNo.Text + "' as tenantNo,'" + txtTenantName.Text + "' as TenantNmA,'" + txtTenantNo.Text + "' as TenantNmE ") : (" T_GDDET.AccNo as AccDef_No,(select Arb_Des from T_AccDef where T_AccDef.AccDef_No = T_GDDET.AccNo) as AccDefNm, T_GDHEAD.gdNo,T_INVSETTING.InvNamA as InvNm,T_GDHEAD.gdHDate,T_GDHEAD.gdGDate,T_GDDET.gdDes,CASE WHEN T_GDDET.gdValue > 0 THEN T_GDDET.gdValue ELSE 0 END as Debit,CASE WHEN T_GDDET.gdValue < 0 THEN Abs(T_GDDET.gdValue) ELSE 0 END as Credit , (Round(T_GDDET.gdValue," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + "))  as Balance,T_SYSSETTING.LogImg,T_SYSSETTING.Calendr,T_Tenant.tenantNo,T_Tenant.tenantID,'" + txtTenantNo.Text + "' as tenantNo,'" + txtTenantName.Text + "' as TenantNmA,'" + txtTenantNo.Text + "' as TenantNmE "));
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
                    frm.Repvalue = "AccountTrancEqar";
                    frm.Tag = LangArEn;
                    frm.Repvalue = "AccountTrancEqar";
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
                ButOk.Text = ((VarGeneral.GeneralPrinter.ISdirectPrinting) ? "طبـــاعة F5" : "عــــرض F5");
                groupBox3.Text = "الرصيــــد";
                groupBox4.Text = "التاريــــخ";
                label1.Text = "مـــــن :";
                label2.Text = "إلـــــى :";
                label7.Text = "المستأجـــر :";
                Text = "كشف حساب المستأجر";
            }
            else
            {
                ButExit.Text = "Exit Esc";
                ButOk.Text = ((VarGeneral.GeneralPrinter.ISdirectPrinting) ? "Print F5" : "Show F5");
                groupBox3.Text = "Balance";
                groupBox4.Text = "Date";
                label1.Text = "From :";
                label2.Text = "To :";
                label7.Text = "Tenant :";
                Text = "Tenant statement";
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
        private void FrmEqarAccTenantRep_Load(object sender, EventArgs e)
        {
        }
        private void button_SrchTenantNo_Click(object sender, EventArgs e)
        {
            columns_Names_visible.Clear();
            columns_Names_visible.Add("tenantNo", new ColumnDictinary("الرقم ", " No", ifDefault: true, ""));
            columns_Names_visible.Add("NameA", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, ""));
            columns_Names_visible.Add("NameE", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, ""));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, ""));
            }
            VarGeneral.SFrmTyp = "T_Tenant";
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != "")
            {
                T_Tenant Q = db.StockTenantData(int.Parse(frm.Serach_No));
                txtTenantNo.Tag = Q.AccNo;
                txtTenantNo.Text = Q.tenantNo.ToString();
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                {
                    txtTenantName.Text = Q.NameA;
                }
                else
                {
                    txtTenantName.Text = Q.NameA;
                }
            }
            else
            {
                txtTenantNo.Text = "";
                txtTenantName.Text = "";
                txtTenantNo.Tag = "";
            }
        }
    }
}
