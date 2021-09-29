using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
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
    public partial class FrmEqarRentRep : Form
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
                        frm.Repvalue = "RentData";


                        frm.Repvalue = "RentData";
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
        private Label label10;
        private ComboBoxEx CmbStatus;
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
        public FrmEqarRentRep()
        {
            InitializeComponent();
            _User = dbc.StockUser(VarGeneral.UserNumber);
        }
        public void FillCombo()
        {
            CmbStatus.Items.Clear();
            CmbStatus.Items.Add((LangArEn == 0) ? "الكـــــل" : "ALL");
            CmbStatus.Items.Add((LangArEn == 0) ? "المسدد فقط" : "Only paid");
            CmbStatus.Items.Add((LangArEn == 0) ? "الغير مسدد فقط" : "Only the unpaid");
            CmbStatus.SelectedIndex = 0;
        }
        protected override void OnLoad(EventArgs e)
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmEqarRentRep));
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
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmEqarRentRep));
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
            string Rule = "Where 1 = 1 ";
            if (CmbStatus.SelectedIndex > 0)
            {
                Rule = ((CmbStatus.SelectedIndex != 1) ? (Rule + " and T_TenantPayment.SndNo is null") : (Rule + " and T_TenantPayment.SndNo > 0"));
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
                Rule = ((int.Parse(txtMFromDate.Text.Substring(0, 4)) >= 1800) ? (Rule + " and  T_TenantPayment.PayMonth  >= '" + dateFormatter.FormatGreg(txtMFromDate.Text, "yyyy/MM") + "'") : (Rule + " and  T_TenantPayment.PayMonth  >= '" + dateFormatter.FormatHijri(txtMFromDate.Text, "yyyy/MM") + "'"));
            }
            if (VarGeneral.CheckDate(txtMToDate.Text) && txtMToDate.Text.Length == 10)
            {
                Rule = ((int.Parse(txtMToDate.Text.Substring(0, 4)) >= 1800) ? (Rule + " and  T_TenantPayment.PayMonth  <= '" + dateFormatter.FormatGreg(txtMToDate.Text, "yyyy/MM") + "'") : (Rule + " and  T_TenantPayment.PayMonth  <= '" + dateFormatter.FormatHijri(txtMToDate.Text, "yyyy/MM") + "'"));
            }
            return Rule;
        }
        private void ButOk_Click(object sender, EventArgs e)
        {
            try
            {
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = "  T_TenantPayment LEFT JOIN\r\n                                      T_TenantContract ON T_TenantPayment.tenantContract_ID = T_TenantContract.ContractID LEFT JOIN\r\n                                      T_Tenant ON T_TenantContract.tenant_ID = T_Tenant.tenantID LEFT JOIN\r\n                                      T_GDHEAD ON T_TenantPayment.SndNo = T_GDHEAD.gdhead_ID LEFT JOIN\r\n                                      T_EqarsData ON T_TenantContract.Eqar_ID = T_EqarsData.EqarID LEFT JOIN\r\n                                      T_AccDef ON T_EqarsData.AccNo = T_AccDef.AccDef_No LEFT JOIN\r\n                                      T_AinsData ON T_TenantContract.Ain_ID = T_AinsData.AinID AND T_EqarsData.EqarID = T_AinsData.EqarID ";
                string Fields = "    T_TenantPayment.PaymentID, T_TenantPayment.PaymentNo, T_TenantPayment.PayMonth, T_TenantPayment.Value, \r\n                                      (case when T_TenantPayment.SndNo > 0 then '" + ((LangArEn == 0) ? "مسدد" : "Paid") + "'  else '" + ((LangArEn == 0) ? "غير مسدد" : "Unpaid") + "' end) as Statue, T_TenantPayment.SndNo, T_TenantContract.ContractNo, T_Tenant.tenantNo, T_Tenant.NameA as TenantNmA, \r\n                                      T_Tenant.NameE as TenantNmE, T_GDHEAD.gdNo, T_GDHEAD.gdTot, T_AinsData.AinNo, T_EqarsData.EqarNo, T_EqarsData.NameA AS EqarNmA, T_EqarsData.NameE AS EqarNmE ";
                _RepShow.Rule = BuildRuleList() + " order by T_EqarsData.EqarNo, T_TenantPayment.tenantContract_ID,  T_TenantPayment.PayMonth, T_Tenant.tenantNo ";
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
                    frm.Repvalue = "RentData";



                    frm.Tag = LangArEn;
                    frm.Repvalue = "RentData";
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
                    txtMFromDate.Text = Convert.ToDateTime(txtMFromDate.Text).ToString("yyyy/MM");
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
                    txtMToDate.Text = Convert.ToDateTime(txtMToDate.Text).ToString("yyyy/MM");
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
                groupBox4.Text = "التاريــــخ";
                label1.Text = "مـــــن :";
                label2.Text = "إلـــــى :";
                label7.Text = "العقــــــــــــار :";
                Text = "كشف تحصيل الإيجار";
            }
            else
            {
                ButExit.Text = "Exit Esc";
                ButOk.Text = ((VarGeneral.GeneralPrinter.nTyp_Setting.Substring(2, 1) == "0") ? "Print F5" : "Show F5");
                groupBox4.Text = "Date";
                label1.Text = "From :";
                label2.Text = "To :";
                label7.Text = "Real estate :";
                Text = "Rent collection report";
            }
            FillCombo();
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
        private void FrmEqarRentRep_Load(object sender, EventArgs e)
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InvAcc.Forms.FrmEqarRentRep));
            txtFromAccNo = new System.Windows.Forms.TextBox();
            ribbonBar1 = new DevComponents.DotNetBar.RibbonBar();
            label10 = new System.Windows.Forms.Label();
            CmbStatus = new DevComponents.DotNetBar.Controls.ComboBoxEx();
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
            groupBox4.SuspendLayout();
            SuspendLayout();
            txtFromAccNo.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(txtFromAccNo, "txtFromAccNo");
            txtFromAccNo.Name = "txtFromAccNo";
            txtFromAccNo.ReadOnly = true;
            txtFromAccNo.Tag = " T_GDDET.AccNo ";
            ribbonBar1.AutoOverflowEnabled = true;
            ribbonBar1.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            ribbonBar1.BackgroundStyle.BackColor = System.Drawing.Color.AliceBlue;
            ribbonBar1.BackgroundStyle.BackColor2 = System.Drawing.SystemColors.GradientActiveCaption;
            ribbonBar1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            ribbonBar1.ContainerControlProcessDialogKey = true;
            ribbonBar1.Controls.Add(label10);
            ribbonBar1.Controls.Add(CmbStatus);
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
            resources.ApplyResources(ribbonBar1, "ribbonBar1");
            ribbonBar1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            ribbonBar1.Name = "ribbonBar1";
            ribbonBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            ribbonBar1.TitleStyle.BackColor = System.Drawing.Color.FromArgb(227, 239, 255);
            ribbonBar1.TitleStyle.BackColor2 = System.Drawing.Color.FromArgb(101, 147, 207);
            ribbonBar1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            ribbonBar1.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            resources.ApplyResources(label10, "label10");
            label10.BackColor = System.Drawing.Color.Transparent;
            label10.Name = "label10";
            CmbStatus.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            CmbStatus.DisplayMember = "Text";
            CmbStatus.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            CmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(CmbStatus, "CmbStatus");
            CmbStatus.FormattingEnabled = true;
            CmbStatus.Name = "CmbStatus";
            CmbStatus.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            groupBox4.BackColor = System.Drawing.Color.Transparent;
            groupBox4.Controls.Add(txtMToDate);
            groupBox4.Controls.Add(txtMFromDate);
            groupBox4.Controls.Add(label1);
            groupBox4.Controls.Add(label2);
            resources.ApplyResources(groupBox4, "groupBox4");
            groupBox4.Name = "groupBox4";
            groupBox4.TabStop = false;
            resources.ApplyResources(txtMToDate, "txtMToDate");
            txtMToDate.Name = "txtMToDate";
            txtMToDate.Leave += new System.EventHandler(txtMToDate_Leave);
            txtMToDate.Click += new System.EventHandler(txtMToDate_Click);
            resources.ApplyResources(txtMFromDate, "txtMFromDate");
            txtMFromDate.Name = "txtMFromDate";
            txtMFromDate.Leave += new System.EventHandler(txtMFromDate_Leave);
            txtMFromDate.Click += new System.EventHandler(txtMFromDate_Click);
            resources.ApplyResources(label1, "label1");
            label1.BackColor = System.Drawing.Color.Transparent;
            label1.Name = "label1";
            resources.ApplyResources(label2, "label2");
            label2.BackColor = System.Drawing.Color.Transparent;
            label2.Name = "label2";
            txtIntoAccName.BackColor = System.Drawing.Color.DarkSeaGreen;
            txtIntoAccName.ForeColor = System.Drawing.Color.White;
            resources.ApplyResources(txtIntoAccName, "txtIntoAccName");
            txtIntoAccName.Name = "txtIntoAccName";
            txtIntoAccName.ReadOnly = true;
            txtFromAccName.BackColor = System.Drawing.Color.DarkSeaGreen;
            txtFromAccName.ForeColor = System.Drawing.Color.White;
            resources.ApplyResources(txtFromAccName, "txtFromAccName");
            txtFromAccName.Name = "txtFromAccName";
            txtFromAccName.ReadOnly = true;
            txtIntoAccNo.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(txtIntoAccNo, "txtIntoAccNo");
            txtIntoAccNo.Name = "txtIntoAccNo";
            txtIntoAccNo.ReadOnly = true;
            txtIntoAccNo.Tag = " T_GDDET.AccNo ";
            txtEqarNo.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(txtEqarNo, "txtEqarNo");
            txtEqarNo.Name = "txtEqarNo";
            txtEqarNo.ReadOnly = true;
            txtEqarNo.Tag = "";
            ButExit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            ButExit.Checked = true;
            ButExit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            resources.ApplyResources(ButExit, "ButExit");
            ButExit.Name = "ButExit";
            ButExit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            ButExit.Symbol = "\uf011";
            ButExit.SymbolSize = 16f;
            ButExit.TextColor = System.Drawing.Color.Black;
            ButExit.Click += new System.EventHandler(ButExit_Click);
            ButOk.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            ButOk.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            resources.ApplyResources(ButOk, "ButOk");
            ButOk.Name = "ButOk";
            ButOk.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            ButOk.Symbol = "\uf0c5";
            ButOk.SymbolSize = 16f;
            ButOk.TextColor = System.Drawing.Color.White;
            ButOk.Click += new System.EventHandler(ButOk_Click);
            resources.ApplyResources(label7, "label7");
            label7.BackColor = System.Drawing.Color.Transparent;
            label7.Name = "label7";
            resources.ApplyResources(label6, "label6");
            label6.BackColor = System.Drawing.Color.Transparent;
            label6.Name = "label6";
            resources.ApplyResources(label5, "label5");
            label5.BackColor = System.Drawing.Color.Transparent;
            label5.Name = "label5";
            button_SrchEqarNo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            button_SrchEqarNo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            resources.ApplyResources(button_SrchEqarNo, "button_SrchEqarNo");
            button_SrchEqarNo.Name = "button_SrchEqarNo";
            button_SrchEqarNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            button_SrchEqarNo.Symbol = "\uf002";
            button_SrchEqarNo.SymbolSize = 12f;
            button_SrchEqarNo.TextColor = System.Drawing.Color.SteelBlue;
            button_SrchEqarNo.Click += new System.EventHandler(button_SrchTenantNo_Click);
            button_SrchAccTo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            button_SrchAccTo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            resources.ApplyResources(button_SrchAccTo, "button_SrchAccTo");
            button_SrchAccTo.Name = "button_SrchAccTo";
            button_SrchAccTo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            button_SrchAccTo.Symbol = "\uf002";
            button_SrchAccTo.SymbolSize = 12f;
            button_SrchAccTo.TextColor = System.Drawing.Color.SteelBlue;
            button_SrchAccTo.Click += new System.EventHandler(button_SrchAccTo_Click);
            button_SrchAccFrom.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            button_SrchAccFrom.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            resources.ApplyResources(button_SrchAccFrom, "button_SrchAccFrom");
            button_SrchAccFrom.Name = "button_SrchAccFrom";
            button_SrchAccFrom.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            button_SrchAccFrom.Symbol = "\uf002";
            button_SrchAccFrom.SymbolSize = 12f;
            button_SrchAccFrom.TextColor = System.Drawing.Color.SteelBlue;
            button_SrchAccFrom.Click += new System.EventHandler(button_SrchAccFrom_Click);
            txtEqarName.BackColor = System.Drawing.Color.DarkSeaGreen;
            txtEqarName.ForeColor = System.Drawing.Color.White;
            resources.ApplyResources(txtEqarName, "txtEqarName");
            txtEqarName.Name = "txtEqarName";
            txtEqarName.ReadOnly = true;
            txtEqarName.Tag = "T_AccDef.AccDef_No";
            resources.ApplyResources(this, "$this");
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            base.Controls.Add(ribbonBar1);
            base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            base.KeyPreview = true;
            base.MaximizeBox = false;
            base.Name = "FrmEqarRentRep";
            base.Load += new System.EventHandler(FrmEqarRentRep_Load);
            base.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Frm_KeyPress);
            base.KeyDown += new System.Windows.Forms.KeyEventHandler(Frm_KeyDown);
            ribbonBar1.ResumeLayout(false);
            ribbonBar1.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ResumeLayout(false);
        }
    }
}
