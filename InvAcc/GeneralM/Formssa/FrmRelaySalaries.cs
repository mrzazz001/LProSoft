using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using Framework.Data;
using Framework.UI;
using InvAcc.GeneralM;
using InvAcc.Stock_Data;
using SSSDateTime.Date;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial class FrmRelaySalaries : Form
    {
        public class ColumnDictinary
        {
            public string AText = string.Empty;
            public string EText = string.Empty;
            public bool IfDefault = false;
            public string Format = string.Empty;
            public ColumnDictinary(string aText, string eText, bool ifDefault, string format)
            {
                AText = aText;
                EText = eText;
                IfDefault = ifDefault;
                Format = format;
            }
        }
        private int LangArEn = 0;
        private HijriGreg.HijriGregDates n = new HijriGreg.HijriGregDates();
        private ScriptNumber ScriptNumber1 = new ScriptNumber();
        private string vDate = string.Empty;
        private T_DaysOfMonth data_this_Dayofmonth;
        private T_Salary data_this_salary;
        private T_Sal data_this_sal;
        private T_Vacation data_this_Vac;
        private T_SYSSETTING data_this_info;
        private Stock_DataDataContext dbInstance;
        public Dictionary<string, ColumnDictinary> columns_Names_visible2 = new Dictionary<string, ColumnDictinary>();
        private T_GDHEAD _GdHead = new T_GDHEAD();
        private TextBox txtBXBankNo;
        private TextBox txtBXCostCenterNo;
        private IContainer components = null;
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

        protected Label label1;
        private ButtonX Button_OK;
        private RibbonBar ribbonBar1;
        private Panel panel1;
        private ButtonX button_Close;
        private TextBox txtBXCostCenterName;
        private ButtonX button_SrchCostCenter;
        private SwitchButton switchButton_AccType;
        private TextBox txtBXBankName;
        private ButtonX button_SrchBXBankNo;
        internal Label label6;
        private CheckBoxX checkBox_AccID;
        private ComboBoxEx comboBox_Month;
        internal Label label8;
        private ComboBoxEx CmbCurr;
        private ButtonX button_SrchMonth;
        public T_DaysOfMonth DataThis_Dayofmonth
        {
            get
            {
                return data_this_Dayofmonth;
            }
            set
            {
                data_this_Dayofmonth = value;
            }
        }
        public T_Salary Datathis_salary
        {
            get
            {
                return data_this_salary;
            }
            set
            {
                data_this_salary = value;
            }
        }
        public T_Sal Datathis_sal
        {
            get
            {
                return data_this_sal;
            }
            set
            {
                data_this_sal = value;
            }
        }
        public T_Vacation Data_this_Vac
        {
            get
            {
                return data_this_Vac;
            }
            set
            {
                data_this_Vac = value;
            }
        }
        public T_SYSSETTING Data_this_info
        {
            get
            {
                return data_this_info;
            }
            set
            {
                data_this_info = value;
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
        public FrmRelaySalaries()
        {
            InitializeComponent();
        }
        private void RibunButtons()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
            {
                Button_OK.Text = "ترحيـــــــل";
                button_Close.Text = "خـــروج";
                Text = "ترحيــل الرواتـــب";
                checkBox_AccID.Text = "إصدار قيد محاسبي تلقائي";
                comboBox_Month.WatermarkText = "لا يوجد رواتب غير مر\u0651حلة";
                switchButton_AccType.OffText = "الصندوق";
                switchButton_AccType.OnText = "البنك";
            }
            else
            {
                Button_OK.Text = "Relay";
                button_Close.Text = "Close";
                Text = "Relay salaries";
                checkBox_AccID.Text = "Create Gaid";
                comboBox_Month.WatermarkText = "Not found salaries of not Relay";
                switchButton_AccType.OffText = "Box";
                switchButton_AccType.OnText = "Bank";
            }
        }
        private void FrmRelaySalaries_Load(object sender, EventArgs e)
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmRelaySalaries));
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
            {
                Language.ChangeLanguage("ar-SA", this, resources);
                LangArEn = 0;
            }
            else
            {
                Language.ChangeLanguage("en", this, resources);
                LangArEn = 1;
            }
            try
            {
                RibunButtons();
                FillCombo();
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("FrmRelaySalaries_Load:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void FillCombo()
        {
            if (VarGeneral.SSSLev == "D" || VarGeneral.SSSLev == "E")
            {
                Button_OK.Enabled = true;
                button_Close.Enabled = true;
                checkBox_AccID.Checked = false;
                try
                {
                    List<string> listMonth = (from t in db.T_Salaries
                                              orderby t.SalMonth, t.SalYear
                                              where t.SalaryStatus == (bool?)false
                                              select string.Concat(t.SalYear + "/", t.SalMonth)).ToList();
                    if (listMonth.Count > 0)
                    {
                        comboBox_Month.DataSource = listMonth.Distinct().ToList();
                        comboBox_Month.DisplayMember = "SalYear/SalMonth";
                        comboBox_Month.SelectedIndex = 0;
                    }
                    else
                    {
                        comboBox_Month.DataSource = null;
                    }
                }
                catch (Exception error)
                {
                    VarGeneral.DebLog.writeLog("comboBox_Branch_SelectedIndexChanged:", error, enable: true);
                    comboBox_Month.DataSource = null;
                }
            }
            else
            {
                Button_OK.Enabled = true;
                button_Close.Enabled = true;
                checkBox_AccID.Checked = false;
                try
                {
                    List<string> listMonth = (from t in db.T_Sals
                                              orderby t.SalMonth, t.SalYear
                                              where t.SalaryStatus == (bool?)false
                                              select string.Concat(t.SalYear + "/", t.SalMonth)).ToList();
                    if (listMonth.Count > 0)
                    {
                        comboBox_Month.DataSource = listMonth.Distinct().ToList();
                        comboBox_Month.DisplayMember = "SalYear/SalMonth";
                        comboBox_Month.SelectedIndex = 0;
                    }
                    else
                    {
                        comboBox_Month.DataSource = null;
                    }
                }
                catch (Exception error)
                {
                    VarGeneral.DebLog.writeLog("comboBox_Branch_SelectedIndexChanged:", error, enable: true);
                    comboBox_Month.DataSource = null;
                }
            }
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
            {
                List<T_Curency> listAccCat = new List<T_Curency>(db.T_Curencies.Select((T_Curency item) => item).ToList());
                CmbCurr.DataSource = listAccCat;
                CmbCurr.DisplayMember = "Arb_Des";
                CmbCurr.ValueMember = "Curency_ID";
            }
            else
            {
                List<T_Curency> listCurr = new List<T_Curency>(db.T_Curencies.Select((T_Curency item) => item).ToList());
                CmbCurr.DataSource = listCurr;
                CmbCurr.DisplayMember = "Eng_Des";
                CmbCurr.ValueMember = "Curency_ID";
            }
            try
            {
                CmbCurr.SelectedValue = int.Parse(VarGeneral.Settings_Sys.ImportIp.ToString());
            }
            catch
            {
            }
        }
        private void checkBox_AccID_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_AccID.Checked)
            {
                txtBXBankName.Enabled = true;
                switchButton_AccType.Enabled = true;
                txtBXBankName.Enabled = true;
                button_SrchBXBankNo.Enabled = true;
                txtBXCostCenterName.Enabled = true;
                button_SrchCostCenter.Enabled = true;
                CmbCurr.Enabled = true;
                return;
            }
            txtBXBankName.Enabled = false;
            switchButton_AccType.Enabled = false;
            txtBXBankName.Enabled = false;
            button_SrchBXBankNo.Enabled = false;
            txtBXCostCenterName.Enabled = false;
            button_SrchCostCenter.Enabled = false;
            CmbCurr.Enabled = false;

            txtBXBankName.Text = string.Empty;
            txtBXBankNo.Text = string.Empty;
            txtBXCostCenterName.Text = string.Empty;
            txtBXCostCenterNo.Text = string.Empty;
        }
        private void switchButton_AccType_ValueChanged(object sender, EventArgs e)
        {
            txtBXBankNo.Text = string.Empty;
            txtBXBankName.Text = string.Empty;
        }
        private void button_SrchBXBankNo_Click(object sender, EventArgs e)
        {
            FrmSearch frm;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection;
            if (!switchButton_AccType.Value)
            {
                columns_Names_visible2.Clear();
                columns_Names_visible2.Add("AccDef_No", new ColumnDictinary("الرقم ", " No", ifDefault: true, string.Empty));
                columns_Names_visible2.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, string.Empty));
                columns_Names_visible2.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, string.Empty));
                columns_Names_visible2.Add("AccDef_ID", new ColumnDictinary(" ", " ", ifDefault: false, string.Empty));
                columns_Names_visible2.Add("Mobile", new ColumnDictinary("الجوال", "Mobile", ifDefault: false, string.Empty));
                frm = new FrmSearch();
                frm.Tag = LangArEn;
                animalsAsCollection = columns_Names_visible2;
                foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
                {
                    frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
                }
                VarGeneral.SFrmTyp = "T_AccDef2";
                VarGeneral.AccTyp = 2;
                frm.TopMost = true;
                frm.ShowDialog();
                if (frm.SerachNo != string.Empty)
                {
                    T_AccDef _AccDef = db.StockAccDefs(int.Parse(frm.Serach_No));
                    txtBXBankNo.Text = _AccDef.AccDef_No.ToString();
                    if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                    {
                        txtBXBankName.Text = _AccDef.Arb_Des.ToString();
                    }
                    else
                    {
                        txtBXBankName.Text = _AccDef.Eng_Des.ToString();
                    }
                }
                else
                {
                    txtBXBankNo.Text = string.Empty;
                    txtBXBankName.Text = string.Empty;
                }
                return;
            }
            columns_Names_visible2.Clear();
            columns_Names_visible2.Add("AccDef_No", new ColumnDictinary("الرقم ", " No", ifDefault: true, string.Empty));
            columns_Names_visible2.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, string.Empty));
            columns_Names_visible2.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, string.Empty));
            columns_Names_visible2.Add("AccDef_ID", new ColumnDictinary(" ", " ", ifDefault: false, string.Empty));
            columns_Names_visible2.Add("Mobile", new ColumnDictinary("الجوال", "Mobile", ifDefault: false, string.Empty));
            frm = new FrmSearch();
            frm.Tag = LangArEn;
            animalsAsCollection = columns_Names_visible2;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
            }
            VarGeneral.SFrmTyp = "T_AccDef2";
            VarGeneral.AccTyp = 3;
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != string.Empty)
            {
                T_AccDef _AccDef = db.StockAccDefs(int.Parse(frm.Serach_No));
                txtBXBankNo.Text = _AccDef.AccDef_No.ToString();
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                {
                    txtBXBankName.Text = _AccDef.Arb_Des.ToString();
                }
                else
                {
                    txtBXBankName.Text = _AccDef.Eng_Des.ToString();
                }
            }
            else
            {
                txtBXBankNo.Text = string.Empty;
                txtBXBankName.Text = string.Empty;
            }
        }
        private void button_SrchCostCenter_Click(object sender, EventArgs e)
        {
            columns_Names_visible2.Clear();
            columns_Names_visible2.Add("Cst_No", new ColumnDictinary("الرقم", "No", ifDefault: true, string.Empty));
            columns_Names_visible2.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, string.Empty));
            columns_Names_visible2.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, string.Empty));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible2;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
            }
            VarGeneral.SFrmTyp = "T_CstTbl";
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != string.Empty)
            {
                txtBXCostCenterNo.Text = db.StockCst(frm.Serach_No).Cst_ID.ToString();
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                {
                    txtBXCostCenterName.Text = db.StockCst(frm.Serach_No).Arb_Des.ToString();
                }
                else
                {
                    txtBXCostCenterName.Text = db.StockCst(frm.Serach_No).Eng_Des.ToString();
                }
            }
            else
            {
                txtBXCostCenterNo.Text = string.Empty;
                txtBXCostCenterName.Text = string.Empty;
            }
        }
        private bool ValidData()
        {
            try
            {
                if (comboBox_Month.SelectedIndex == -1)
                {
                    MessageBox.Show((LangArEn == 0) ? "تأكد من صحة التاريخ" : "Date Is UnCorrecte", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    comboBox_Month.Focus();
                    return false;
                }
                if (!VarGeneral.CheckDate(comboBox_Month.Text))
                {
                    MessageBox.Show((LangArEn == 0) ? "تأكد من صحة التاريخ" : "Date Is UnCorrecte", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    comboBox_Month.Focus();
                    return false;
                }
            }
            catch
            {
                return false;
            }
            List<T_Salary> vData = db.GetEmpSalary2(comboBox_Month.Text);
            if (vData.Count > 0)
            {
                MessageBox.Show((LangArEn == 0) ? "لقد تم احتساب راتب هذا الشهر وترحيلها سابقا" : "Salaries this month is Carryover", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }
            List<T_Salary> vData2 = db.GetEmpSalary3(comboBox_Month.Text);
            if (vData2.Count <= 0)
            {
                MessageBox.Show((LangArEn == 0) ? "لم تقم باصدار رواتب للموظفين لهذا الشهر ,, يرجى اصدار الرواتب أولا" : "The issue was not the employees' salaries for this month,, Please issuing salaries first", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }
            if (checkBox_AccID.Checked)
            {
                if (!switchButton_AccType.Value && txtBXBankName.Text == string.Empty)
                {
                    if (!switchButton_AccType.Value)
                    {
                        MessageBox.Show((LangArEn == 0) ? "تأكد من حساب الصندوق" : "Box Account is Rong", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        txtBXBankName.Focus();
                        return false;
                    }
                    MessageBox.Show((LangArEn == 0) ? "تأكد من حساب البنك" : "Bank Account is Rong", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    txtBXBankName.Focus();
                    return false;
                }
                List<T_Salary> newdata = db.GetEmpSalary(comboBox_Month.Text);
                for (int iicnt = 0; iicnt < newdata.Count; iicnt++)
                {
                    if (string.IsNullOrEmpty(newdata[iicnt].SalAcc))
                    {
                        T_Emp q = db.EmpsEmp(newdata[iicnt].EmpID);
                        MessageBox.Show((LangArEn == 0) ? ("  تأكد من حساب الراتب للموظف : \n [ " + q.NameA + " ]") : (" not found the Salary Account \n [ " + q.NameE + " ]"), VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        return false;
                    }
                    if (string.IsNullOrEmpty(newdata[iicnt].LoanAcc))
                    {
                        T_Emp q = db.EmpsEmp(newdata[iicnt].EmpID);
                        MessageBox.Show((LangArEn == 0) ? (" تأكد من حساب السلف للموظف : \n [ " + q.NameA + " ]") : (" not found the Loans Account \n [ " + q.NameE + " ]"), VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        return false;
                    }
                    if (string.IsNullOrEmpty(newdata[iicnt].HouseAcc))
                    {
                        T_Emp q = db.EmpsEmp(newdata[iicnt].EmpID);
                        MessageBox.Show((LangArEn == 0) ? (" تأكد من حساب بدل السكن للموظف : \n [ " + q.NameA + " ]") : (" not found the Housing Allownce Accont \n [ " + q.NameE + " ]"), VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        return false;
                    }
                }
            }
            return true;
        }
        private bool ValidDataSal()
        {
            try
            {
                if (comboBox_Month.SelectedIndex == -1)
                {
                    MessageBox.Show((LangArEn == 0) ? "تأكد من صحة التاريخ" : "Date Is UnCorrecte", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    comboBox_Month.Focus();
                    return false;
                }
                if (!VarGeneral.CheckDate(comboBox_Month.Text))
                {
                    MessageBox.Show((LangArEn == 0) ? "تأكد من صحة التاريخ" : "Date Is UnCorrecte", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    comboBox_Month.Focus();
                    return false;
                }
            }
            catch
            {
                return false;
            }
            List<T_Sal> vData = db.GetEmpSal2(comboBox_Month.Text);
            if (vData.Count > 0)
            {
                MessageBox.Show((LangArEn == 0) ? "لقد تم احتساب راتب هذا الشهر وترحيلها سابقا" : "Salaries this month is Carryover", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }
            List<T_Sal> vData2 = db.GetEmpSal3(comboBox_Month.Text);
            if (vData2.Count <= 0)
            {
                MessageBox.Show((LangArEn == 0) ? "لم تقم باصدار رواتب للموظفين لهذا الشهر ,, يرجى اصدار الرواتب أولا" : "The issue was not the employees' salaries for this month,, Please issuing salaries first", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }
            if (checkBox_AccID.Checked)
            {
                if (!switchButton_AccType.Value && txtBXBankName.Text == string.Empty)
                {
                    if (!switchButton_AccType.Value)
                    {
                        MessageBox.Show((LangArEn == 0) ? "تأكد من حساب الصندوق" : "Box Account is Rong", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        txtBXBankName.Focus();
                        return false;
                    }
                    MessageBox.Show((LangArEn == 0) ? "تأكد من حساب البنك" : "Bank Account is Rong", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    txtBXBankName.Focus();
                    return false;
                }
                List<T_Sal> newdata = db.GetEmpSal(comboBox_Month.Text);
                for (int iicnt = 0; iicnt < newdata.Count; iicnt++)
                {
                    if (string.IsNullOrEmpty(newdata[iicnt].SalAcc))
                    {
                        T_Emp q = db.EmpsEmp(newdata[iicnt].EmpID);
                        MessageBox.Show((LangArEn == 0) ? ("  تأكد من حساب الراتب للموظف : \n [ " + q.NameA + " ]") : (" not found the Salary Account \n [ " + q.NameE + " ]"), VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        return false;
                    }
                    if (string.IsNullOrEmpty(newdata[iicnt].LoanAcc))
                    {
                        T_Emp q = db.EmpsEmp(newdata[iicnt].EmpID);
                        MessageBox.Show((LangArEn == 0) ? (" تأكد من حساب السلف للموظف : \n [ " + q.NameA + " ]") : (" not found the Loans Account \n [ " + q.NameE + " ]"), VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        return false;
                    }
                    if (string.IsNullOrEmpty(newdata[iicnt].HouseAcc))
                    {
                        T_Emp q = db.EmpsEmp(newdata[iicnt].EmpID);
                        MessageBox.Show((LangArEn == 0) ? (" تأكد من حساب بدل السكن للموظف : \n [ " + q.NameA + " ]") : (" not found the Housing Allownce Accont \n [ " + q.NameE + " ]"), VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        return false;
                    }
                }
            }
            return true;
        }
        private void Button_OK_Click(object sender, EventArgs e)
        {
            if (VarGeneral.SSSLev == "D" || VarGeneral.SSSLev == "E")
            {
                try
                {
                    if (!ValidData())
                    {
                        return;
                    }
                    vDate = Convert.ToDateTime(comboBox_Month.Text).ToString("yyyy/MM/dd");
                    string BDate = vDate;
                    Button_OK.Enabled = false;
                    button_Close.Enabled = false;
                    if (checkBox_AccID.Checked)
                    {
                        IDatabase db_ = Database.GetDatabase(VarGeneral.BranchCS);
                        List<T_Salary> newdata = db.GetEmpSalary(comboBox_Month.Text);
                        Stock_DataDataContext dbc = new Stock_DataDataContext(VarGeneral.BranchCS);
                        int Line = 2;
                        double vCrdit = 0.0;
                        double vAdds = 0.0;
                        double vDis = 0.0;
                        if (newdata.Count > 0)
                        {
                            vCrdit = newdata.Sum((T_Salary g) => g.Total.HasValue ? g.Total.Value : 0.0);
                        }
                        GetDataGd(vCrdit);
                        _GdHead.DATE_CREATED = DateTime.Now;
                        dbc.T_GDHEADs.InsertOnSubmit(_GdHead);
                        dbc.SubmitChanges();
                        db_.StartTransaction();
                        db_.ClearParameters();
                        db_.AddParameter("GDDET_ID", DbType.Int32, 0);
                        db_.AddParameter("gdID", DbType.Int32, _GdHead.gdhead_ID);
                        db_.AddParameter("gdNo", DbType.String, _GdHead.gdNo);
                        db_.AddParameter("gdDes", DbType.String, "ترحيل رواتب شهر | " + Convert.ToDateTime(comboBox_Month.Text).Month);
                        db_.AddParameter("gdDesE", DbType.String, "Relay Salaries Month | " + Convert.ToDateTime(comboBox_Month.Text).Month);
                        db_.AddParameter("recptTyp", DbType.String, VarGeneral.InvTyp);
                        db_.AddParameter("AccNo", DbType.String, txtBXBankNo.Text);
                        db_.AddParameter("AccName", DbType.String, string.Empty);
                        db_.AddParameter("gdValue", DbType.Double, 0.0 - vCrdit);
                        db_.AddParameter("recptNo", DbType.String, _GdHead.gdNo);
                        db_.AddParameter("Lin", DbType.Int32, 1);
                        db_.AddParameter("AccNoDestruction", DbType.String, null);
                        db_.ExecuteNonQueryWithoutCommit(storedProcedure: true, "S_T_GDDET_INSERT");
                        db_.EndTransaction();
                        for (int i = 0; i < newdata.Count; i++)
                        {
                            vAdds = (newdata[i].AddDay.HasValue ? newdata[i].AddDay.Value : 0.0) + (newdata[i].AddHour.HasValue ? newdata[i].AddHour.Value : 0.0) + (newdata[i].MandateDay.HasValue ? newdata[i].MandateDay.Value : 0.0) + (newdata[i].Rewards.HasValue ? newdata[i].Rewards.Value : 0.0);
                            vDis = (newdata[i].LateHours.HasValue ? newdata[i].LateHours.Value : 0.0) + (newdata[i].SubDay.HasValue ? newdata[i].SubDay.Value : 0.0) + (newdata[i].SubJaza.HasValue ? newdata[i].SubJaza.Value : 0.0) + (newdata[i].SubOther.HasValue ? newdata[i].SubOther.Value : 0.0) + (newdata[i].SubCallPhone.HasValue ? newdata[i].SubCallPhone.Value : 0.0) + (newdata[i].SubCommentary.HasValue ? newdata[i].SubCommentary.Value : 0.0) + (newdata[i].InsuranceMedical.HasValue ? newdata[i].InsuranceMedical.Value : 0.0) + (newdata[i].SocialInsurance.HasValue ? newdata[i].SocialInsurance.Value : 0.0);
                            if (newdata[i].Salary.Value > 0.0)
                            {
                                db_.StartTransaction();
                                db_.ClearParameters();
                                db_.AddParameter("GDDET_ID", DbType.Int32, 0);
                                db_.AddParameter("gdID", DbType.Int32, _GdHead.gdhead_ID);
                                db_.AddParameter("gdNo", DbType.String, _GdHead.gdNo);
                                db_.AddParameter("gdDes", DbType.String, "ترحيل رواتب شهر | " + Convert.ToDateTime(comboBox_Month.Text).Month);
                                db_.AddParameter("gdDesE", DbType.String, "Relay Salaries Month | " + Convert.ToDateTime(comboBox_Month.Text).Month);
                                db_.AddParameter("recptTyp", DbType.String, VarGeneral.InvTyp);
                                db_.AddParameter("AccNo", DbType.String, newdata[i].SalAcc);
                                db_.AddParameter("AccName", DbType.String, string.Empty);
                                db_.AddParameter("gdValue", DbType.Double, newdata[i].Salary.Value + newdata[i].TransferAllowance.Value + newdata[i].OtherAllowance.Value);
                                db_.AddParameter("recptNo", DbType.String, _GdHead.gdNo);
                                db_.AddParameter("Lin", DbType.Int32, Line);
                                db_.AddParameter("AccNoDestruction", DbType.String, null);
                                db_.ExecuteNonQueryWithoutCommit(storedProcedure: true, "S_T_GDDET_INSERT");
                                db_.EndTransaction();
                                Line++;
                            }
                            if (newdata[i].HousingAllowance.Value > 0.0)
                            {
                                db_.StartTransaction();
                                db_.ClearParameters();
                                db_.AddParameter("GDDET_ID", DbType.Int32, 0);
                                db_.AddParameter("gdID", DbType.Int32, _GdHead.gdhead_ID);
                                db_.AddParameter("gdNo", DbType.String, _GdHead.gdNo);
                                db_.AddParameter("gdDes", DbType.String, "ترحيل بدل سكن شهر | " + Convert.ToDateTime(comboBox_Month.Text).Month);
                                db_.AddParameter("gdDesE", DbType.String, "Relay Housing Allownce Month | " + Convert.ToDateTime(comboBox_Month.Text).Month);
                                db_.AddParameter("recptTyp", DbType.String, VarGeneral.InvTyp);
                                db_.AddParameter("AccNo", DbType.String, newdata[i].HouseAcc);
                                db_.AddParameter("AccName", DbType.String, string.Empty);
                                db_.AddParameter("gdValue", DbType.Double, newdata[i].HousingAllowance.Value);
                                db_.AddParameter("recptNo", DbType.String, _GdHead.gdNo);
                                db_.AddParameter("Lin", DbType.Int32, Line);
                                db_.AddParameter("AccNoDestruction", DbType.String, null);
                                db_.ExecuteNonQueryWithoutCommit(storedProcedure: true, "S_T_GDDET_INSERT");
                                db_.EndTransaction();
                                Line++;
                            }
                            if (vAdds > 0.0)
                            {
                                db_.StartTransaction();
                                db_.ClearParameters();
                                db_.AddParameter("GDDET_ID", DbType.Int32, 0);
                                db_.AddParameter("gdID", DbType.Int32, _GdHead.gdhead_ID);
                                db_.AddParameter("gdNo", DbType.String, _GdHead.gdNo);
                                db_.AddParameter("gdDes", DbType.String, "ترحيل مستحقات شهر | " + Convert.ToDateTime(comboBox_Month.Text).Month);
                                db_.AddParameter("gdDesE", DbType.String, "Relay Adds Month | " + Convert.ToDateTime(comboBox_Month.Text).Month);
                                db_.AddParameter("recptTyp", DbType.String, VarGeneral.InvTyp);
                                db_.AddParameter("AccNo", DbType.String, newdata[i].SalAcc);
                                db_.AddParameter("AccName", DbType.String, string.Empty);
                                db_.AddParameter("gdValue", DbType.Double, vAdds);
                                db_.AddParameter("recptNo", DbType.String, _GdHead.gdNo);
                                db_.AddParameter("Lin", DbType.Int32, Line);
                                db_.AddParameter("AccNoDestruction", DbType.String, null);
                                db_.ExecuteNonQueryWithoutCommit(storedProcedure: true, "S_T_GDDET_INSERT");
                                db_.EndTransaction();
                                Line++;
                            }
                            if (vDis > 0.0)
                            {
                                db_.StartTransaction();
                                db_.ClearParameters();
                                db_.AddParameter("GDDET_ID", DbType.Int32, 0);
                                db_.AddParameter("gdID", DbType.Int32, _GdHead.gdhead_ID);
                                db_.AddParameter("gdNo", DbType.String, _GdHead.gdNo);
                                db_.AddParameter("gdDes", DbType.String, "ترحيل مستقطعات شهر | " + Convert.ToDateTime(comboBox_Month.Text).Month);
                                db_.AddParameter("gdDesE", DbType.String, "Relay Discount Month | " + Convert.ToDateTime(comboBox_Month.Text).Month);
                                db_.AddParameter("recptTyp", DbType.String, VarGeneral.InvTyp);
                                db_.AddParameter("AccNo", DbType.String, newdata[i].SalAcc);
                                db_.AddParameter("AccName", DbType.String, string.Empty);
                                db_.AddParameter("gdValue", DbType.Double, 0.0 - vDis);
                                db_.AddParameter("recptNo", DbType.String, _GdHead.gdNo);
                                db_.AddParameter("Lin", DbType.Int32, Line);
                                db_.AddParameter("AccNoDestruction", DbType.String, null);
                                db_.ExecuteNonQueryWithoutCommit(storedProcedure: true, "S_T_GDDET_INSERT");
                                db_.EndTransaction();
                                Line++;
                            }
                            if (newdata[i].Advance.Value > 0.0)
                            {
                                db_.StartTransaction();
                                db_.ClearParameters();
                                db_.AddParameter("GDDET_ID", DbType.Int32, 0);
                                db_.AddParameter("gdID", DbType.Int32, _GdHead.gdhead_ID);
                                db_.AddParameter("gdNo", DbType.String, _GdHead.gdNo);
                                db_.AddParameter("gdDes", DbType.String, "ترحيل \u064dسلف شهر | " + Convert.ToDateTime(comboBox_Month.Text).Month);
                                db_.AddParameter("gdDesE", DbType.String, "Relay Loans Month | " + Convert.ToDateTime(comboBox_Month.Text).Month);
                                db_.AddParameter("recptTyp", DbType.String, VarGeneral.InvTyp);
                                db_.AddParameter("AccNo", DbType.String, newdata[i].LoanAcc);
                                db_.AddParameter("AccName", DbType.String, string.Empty);
                                db_.AddParameter("gdValue", DbType.Double, 0.0 - newdata[i].Advance.Value);
                                db_.AddParameter("recptNo", DbType.String, _GdHead.gdNo);
                                db_.AddParameter("Lin", DbType.Int32, Line);
                                db_.AddParameter("AccNoDestruction", DbType.String, null);
                                db_.ExecuteNonQueryWithoutCommit(storedProcedure: true, "S_T_GDDET_INSERT");
                                db_.EndTransaction();
                                Line++;
                            }
                        }
                    }
                    using (Stock_DataDataContext stock_DataDataContext = new Stock_DataDataContext(VarGeneral.BranchCS))
                    {
                        List<T_Salary> newdata4 = stock_DataDataContext.GetEmpSalary(comboBox_Month.Text);
                        for (int i = 0; i < newdata4.Count; i++)
                        {
                            Datathis_salary = new T_Salary();
                            data_this_salary = newdata4[i];
                            try
                            {
                                if (checkBox_AccID.Checked && !string.IsNullOrEmpty(_GdHead.gdhead_ID.ToString()) && _GdHead.gdhead_ID != 0)
                                {
                                    data_this_salary.GadeId = _GdHead.gdhead_ID;
                                }
                            }
                            catch
                            {
                                data_this_salary.GadeId = null;
                            }
                            data_this_salary.SalaryStatus = true;
                            stock_DataDataContext.Log = VarGeneral.DebugLog;
                            stock_DataDataContext.SubmitChanges(ConflictMode.ContinueOnConflict);
                        }
                    }
                    db.OpTestWithBr(Convert.ToDateTime(vDate).ToString("yyyy/MM"), vValue: true);
                    MessageBox.Show((LangArEn == 0) ? ("تمت بنجاح عملية ترحيل رواتب الشهر : [" + Convert.ToDateTime(comboBox_Month.Text).ToString("yyyy/MM") + "]") : "The process has been successfully", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    FillCombo();
                }
                catch (Exception error2)
                {
                    VarGeneral.DebLog.writeLog("bubbleButton_Ok_Click:", error2, enable: true);
                    MessageBox.Show(error2.Message);
                }
                return;
            }
            try
            {
                if (!ValidDataSal())
                {
                    return;
                }
                vDate = Convert.ToDateTime(comboBox_Month.Text).ToString("yyyy/MM/dd");
                string BDate = vDate;
                Button_OK.Enabled = false;
                button_Close.Enabled = false;
                if (checkBox_AccID.Checked)
                {
                    IDatabase db_ = Database.GetDatabase(VarGeneral.BranchCS);
                    List<T_Sal> newdata2 = db.GetEmpSal(comboBox_Month.Text);
                    Stock_DataDataContext dbc = new Stock_DataDataContext(VarGeneral.BranchCS);
                    int Line = 2;
                    double vCrdit = 0.0;
                    double vAdds = 0.0;
                    double vDis = 0.0;
                    if (newdata2.Count > 0)
                    {
                        vCrdit = newdata2.Sum((T_Sal g) => g.Total.HasValue ? g.Total.Value : 0.0);
                    }
                    GetDataGd(vCrdit);
                    _GdHead.DATE_CREATED = DateTime.Now;
                    dbc.T_GDHEADs.InsertOnSubmit(_GdHead);
                    dbc.SubmitChanges();
                    db_.StartTransaction();
                    db_.ClearParameters();
                    db_.AddParameter("GDDET_ID", DbType.Int32, 0);
                    db_.AddParameter("gdID", DbType.Int32, _GdHead.gdhead_ID);
                    db_.AddParameter("gdNo", DbType.String, _GdHead.gdNo);
                    db_.AddParameter("gdDes", DbType.String, "ترحيل رواتب شهر | " + Convert.ToDateTime(comboBox_Month.Text).Month);
                    db_.AddParameter("gdDesE", DbType.String, "Relay Salaries Month | " + Convert.ToDateTime(comboBox_Month.Text).Month);
                    db_.AddParameter("recptTyp", DbType.String, VarGeneral.InvTyp);
                    db_.AddParameter("AccNo", DbType.String, txtBXBankNo.Text);
                    db_.AddParameter("AccName", DbType.String, string.Empty);
                    db_.AddParameter("gdValue", DbType.Double, 0.0 - vCrdit);
                    db_.AddParameter("recptNo", DbType.String, _GdHead.gdNo);
                    db_.AddParameter("Lin", DbType.Int32, 1);
                    db_.AddParameter("AccNoDestruction", DbType.String, null);
                    db_.ExecuteNonQueryWithoutCommit(storedProcedure: true, "S_T_GDDET_INSERT");
                    db_.EndTransaction();
                    for (int i = 0; i < newdata2.Count; i++)
                    {
                        vAdds = (newdata2[i].AddDay.HasValue ? newdata2[i].AddDay.Value : 0.0) + (newdata2[i].AddHour.HasValue ? newdata2[i].AddHour.Value : 0.0) + (newdata2[i].MandateDay.HasValue ? newdata2[i].MandateDay.Value : 0.0) + (newdata2[i].Rewards.HasValue ? newdata2[i].Rewards.Value : 0.0);
                        vDis = (newdata2[i].LateHours.HasValue ? newdata2[i].LateHours.Value : 0.0) + (newdata2[i].SubDay.HasValue ? newdata2[i].SubDay.Value : 0.0) + (newdata2[i].SubJaza.HasValue ? newdata2[i].SubJaza.Value : 0.0) + (newdata2[i].SubOther.HasValue ? newdata2[i].SubOther.Value : 0.0) + (newdata2[i].SubCallPhone.HasValue ? newdata2[i].SubCallPhone.Value : 0.0) + (newdata2[i].SubCommentary.HasValue ? newdata2[i].SubCommentary.Value : 0.0) + (newdata2[i].InsuranceMedical.HasValue ? newdata2[i].InsuranceMedical.Value : 0.0) + (newdata2[i].SocialInsurance.HasValue ? newdata2[i].SocialInsurance.Value : 0.0);
                        if (newdata2[i].Salary.Value > 0.0)
                        {
                            db_.StartTransaction();
                            db_.ClearParameters();
                            db_.AddParameter("GDDET_ID", DbType.Int32, 0);
                            db_.AddParameter("gdID", DbType.Int32, _GdHead.gdhead_ID);
                            db_.AddParameter("gdNo", DbType.String, _GdHead.gdNo);
                            db_.AddParameter("gdDes", DbType.String, "ترحيل رواتب شهر | " + Convert.ToDateTime(comboBox_Month.Text).Month);
                            db_.AddParameter("gdDesE", DbType.String, "Relay Salaries Month | " + Convert.ToDateTime(comboBox_Month.Text).Month);
                            db_.AddParameter("recptTyp", DbType.String, VarGeneral.InvTyp);
                            db_.AddParameter("AccNo", DbType.String, newdata2[i].SalAcc);
                            db_.AddParameter("AccName", DbType.String, string.Empty);
                            db_.AddParameter("gdValue", DbType.Double, newdata2[i].Salary.Value + newdata2[i].TransferAllowance.Value + newdata2[i].OtherAllowance.Value);
                            db_.AddParameter("recptNo", DbType.String, _GdHead.gdNo);
                            db_.AddParameter("Lin", DbType.Int32, Line);
                            db_.AddParameter("AccNoDestruction", DbType.String, null);
                            db_.ExecuteNonQueryWithoutCommit(storedProcedure: true, "S_T_GDDET_INSERT");
                            db_.EndTransaction();
                            Line++;
                        }
                        if (newdata2[i].HousingAllowance.Value > 0.0)
                        {
                            db_.StartTransaction();
                            db_.ClearParameters();
                            db_.AddParameter("GDDET_ID", DbType.Int32, 0);
                            db_.AddParameter("gdID", DbType.Int32, _GdHead.gdhead_ID);
                            db_.AddParameter("gdNo", DbType.String, _GdHead.gdNo);
                            db_.AddParameter("gdDes", DbType.String, "ترحيل بدل سكن شهر | " + Convert.ToDateTime(comboBox_Month.Text).Month);
                            db_.AddParameter("gdDesE", DbType.String, "Relay Housing Allownce Month | " + Convert.ToDateTime(comboBox_Month.Text).Month);
                            db_.AddParameter("recptTyp", DbType.String, VarGeneral.InvTyp);
                            db_.AddParameter("AccNo", DbType.String, newdata2[i].HouseAcc);
                            db_.AddParameter("AccName", DbType.String, string.Empty);
                            db_.AddParameter("gdValue", DbType.Double, newdata2[i].HousingAllowance.Value);
                            db_.AddParameter("recptNo", DbType.String, _GdHead.gdNo);
                            db_.AddParameter("Lin", DbType.Int32, Line);
                            db_.AddParameter("AccNoDestruction", DbType.String, null);
                            db_.ExecuteNonQueryWithoutCommit(storedProcedure: true, "S_T_GDDET_INSERT");
                            db_.EndTransaction();
                            Line++;
                        }
                        if (vAdds > 0.0)
                        {
                            db_.StartTransaction();
                            db_.ClearParameters();
                            db_.AddParameter("GDDET_ID", DbType.Int32, 0);
                            db_.AddParameter("gdID", DbType.Int32, _GdHead.gdhead_ID);
                            db_.AddParameter("gdNo", DbType.String, _GdHead.gdNo);
                            db_.AddParameter("gdDes", DbType.String, "ترحيل مستحقات شهر | " + Convert.ToDateTime(comboBox_Month.Text).Month);
                            db_.AddParameter("gdDesE", DbType.String, "Relay Adds Month | " + Convert.ToDateTime(comboBox_Month.Text).Month);
                            db_.AddParameter("recptTyp", DbType.String, VarGeneral.InvTyp);
                            db_.AddParameter("AccNo", DbType.String, newdata2[i].SalAcc);
                            db_.AddParameter("AccName", DbType.String, string.Empty);
                            db_.AddParameter("gdValue", DbType.Double, vAdds);
                            db_.AddParameter("recptNo", DbType.String, _GdHead.gdNo);
                            db_.AddParameter("Lin", DbType.Int32, Line);
                            db_.AddParameter("AccNoDestruction", DbType.String, null);
                            db_.ExecuteNonQueryWithoutCommit(storedProcedure: true, "S_T_GDDET_INSERT");
                            db_.EndTransaction();
                            Line++;
                        }
                        if (vDis > 0.0)
                        {
                            db_.StartTransaction();
                            db_.ClearParameters();
                            db_.AddParameter("GDDET_ID", DbType.Int32, 0);
                            db_.AddParameter("gdID", DbType.Int32, _GdHead.gdhead_ID);
                            db_.AddParameter("gdNo", DbType.String, _GdHead.gdNo);
                            db_.AddParameter("gdDes", DbType.String, "ترحيل مستقطعات شهر | " + Convert.ToDateTime(comboBox_Month.Text).Month);
                            db_.AddParameter("gdDesE", DbType.String, "Relay Discount Month | " + Convert.ToDateTime(comboBox_Month.Text).Month);
                            db_.AddParameter("recptTyp", DbType.String, VarGeneral.InvTyp);
                            db_.AddParameter("AccNo", DbType.String, newdata2[i].SalAcc);
                            db_.AddParameter("AccName", DbType.String, string.Empty);
                            db_.AddParameter("gdValue", DbType.Double, 0.0 - vDis);
                            db_.AddParameter("recptNo", DbType.String, _GdHead.gdNo);
                            db_.AddParameter("Lin", DbType.Int32, Line);
                            db_.AddParameter("AccNoDestruction", DbType.String, null);
                            db_.ExecuteNonQueryWithoutCommit(storedProcedure: true, "S_T_GDDET_INSERT");
                            db_.EndTransaction();
                            Line++;
                        }
                        if (newdata2[i].Advance.Value > 0.0)
                        {
                            db_.StartTransaction();
                            db_.ClearParameters();
                            db_.AddParameter("GDDET_ID", DbType.Int32, 0);
                            db_.AddParameter("gdID", DbType.Int32, _GdHead.gdhead_ID);
                            db_.AddParameter("gdNo", DbType.String, _GdHead.gdNo);
                            db_.AddParameter("gdDes", DbType.String, "ترحيل \u064dسلف شهر | " + Convert.ToDateTime(comboBox_Month.Text).Month);
                            db_.AddParameter("gdDesE", DbType.String, "Relay Loans Month | " + Convert.ToDateTime(comboBox_Month.Text).Month);
                            db_.AddParameter("recptTyp", DbType.String, VarGeneral.InvTyp);
                            db_.AddParameter("AccNo", DbType.String, newdata2[i].LoanAcc);
                            db_.AddParameter("AccName", DbType.String, string.Empty);
                            db_.AddParameter("gdValue", DbType.Double, 0.0 - newdata2[i].Advance.Value);
                            db_.AddParameter("recptNo", DbType.String, _GdHead.gdNo);
                            db_.AddParameter("Lin", DbType.Int32, Line);
                            db_.AddParameter("AccNoDestruction", DbType.String, null);
                            db_.ExecuteNonQueryWithoutCommit(storedProcedure: true, "S_T_GDDET_INSERT");
                            db_.EndTransaction();
                            Line++;
                        }
                    }
                }
                using (Stock_DataDataContext stock_DataDataContext = new Stock_DataDataContext(VarGeneral.BranchCS))
                {
                    List<T_Sal> newdata3 = stock_DataDataContext.GetEmpSal(comboBox_Month.Text);
                    for (int i = 0; i < newdata3.Count; i++)
                    {
                        Datathis_sal = new T_Sal();
                        data_this_sal = newdata3[i];
                        try
                        {
                            if (checkBox_AccID.Checked && !string.IsNullOrEmpty(_GdHead.gdhead_ID.ToString()) && _GdHead.gdhead_ID != 0)
                            {
                                data_this_sal.GadeId = _GdHead.gdhead_ID;
                            }
                        }
                        catch
                        {
                            data_this_sal.GadeId = null;
                        }
                        data_this_sal.SalaryStatus = true;
                        stock_DataDataContext.Log = VarGeneral.DebugLog;
                        stock_DataDataContext.SubmitChanges(ConflictMode.ContinueOnConflict);
                    }
                }
                MessageBox.Show((LangArEn == 0) ? "تمت عملية ترحيل الرواتب نجاح" : "The process has been successfully", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                FillCombo();
            }
            catch (Exception error2)
            {
                VarGeneral.DebLog.writeLog("bubbleButton_Ok_Click:", error2, enable: true);
                MessageBox.Show(error2.Message);
            }
        }
        private T_GDHEAD GetDataGd(double vCrdit)
        {
            _GdHead.gdHDate = VarGeneral.Hdate;
            _GdHead.gdGDate = VarGeneral.Gdate;
            _GdHead.gdNo = db.MaxGDHEADsNo.ToString();
            _GdHead.ArbTaf = ScriptNumber1.ScriptNum(decimal.Parse("0" + vCrdit));
            _GdHead.BName = _GdHead.BName;
            _GdHead.ChekNo = string.Empty;
            _GdHead.CurTyp = int.Parse(CmbCurr.SelectedValue.ToString());
            _GdHead.EngTaf = ScriptNumber1.TafEng(decimal.Parse("0" + vCrdit));
            if (!string.IsNullOrEmpty(txtBXCostCenterNo.Text))
            {
                _GdHead.gdCstNo = int.Parse(txtBXCostCenterNo.Text);
            }
            else
            {
                _GdHead.gdCstNo = null;
            }
            _GdHead.gdID = 0;
            _GdHead.gdLok = false;
            _GdHead.AdminLock = false;
            _GdHead.gdMem = "سند ترحيل رواتب الموظفين لشهر | " + Convert.ToDateTime(comboBox_Month.Text).Month + " | Relay Salaries to the employee Month";
            _GdHead.gdMnd = null;
            _GdHead.gdRcptID = (_GdHead.gdRcptID.HasValue ? _GdHead.gdRcptID.Value : 0.0);
            _GdHead.gdTot = vCrdit;
            _GdHead.gdTp = (_GdHead.gdTp.HasValue ? _GdHead.gdTp.Value : 0);
            _GdHead.gdTyp = VarGeneral.InvTyp;
            _GdHead.RefNo = string.Empty;
            _GdHead.DATE_MODIFIED = DateTime.Now;
            _GdHead.salMonth = string.Empty;
            _GdHead.gdUser = VarGeneral.UserNumber;
            _GdHead.gdUserNam = VarGeneral.UserNameA;
            _GdHead.CompanyID = 1;
            return _GdHead;
        }
        private void button_Close_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void FrmRelaySalaries_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2 && Button_OK.Enabled && Button_OK.Visible)
            {
                Button_OK_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
        private void FrmRelaySalaries_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                SendKeys.Send("{Tab}");
            }
        }
        private void button_SrchMonth_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox_Month.Items.Count <= 0)
                {
                    return;
                }
                columns_Names_visible2.Clear();
                columns_Names_visible2.Add("Date", new ColumnDictinary("التاريخ ", " Date", ifDefault: true, string.Empty));
                FrmSearch frm = new FrmSearch();
                frm.Tag = LangArEn;
                ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible2;
                foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
                {
                    frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
                }
                if (VarGeneral.SSSLev == "D" || VarGeneral.SSSLev == "E")
                {
                    VarGeneral.SFrmTyp = "Months";
                }
                else
                {
                    VarGeneral.SFrmTyp = "Months2";
                }
                frm.TopMost = true;
                frm.ShowDialog();
                if (frm.SerachNo != string.Empty)
                {
                    comboBox_Month.Text = frm.SerachNo;
                }
            }
            catch
            {
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRelaySalaries));
            this.PanelSpecialContainer = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.Button_OK = new DevComponents.DotNetBar.ButtonX();
            this.ribbonBar1 = new DevComponents.DotNetBar.RibbonBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBox_AccID = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.label8 = new System.Windows.Forms.Label();
            this.CmbCurr = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.txtBXCostCenterName = new System.Windows.Forms.TextBox();
            this.button_SrchCostCenter = new DevComponents.DotNetBar.ButtonX();
            this.switchButton_AccType = new DevComponents.DotNetBar.Controls.SwitchButton();
            this.txtBXBankName = new System.Windows.Forms.TextBox();
            this.button_SrchBXBankNo = new DevComponents.DotNetBar.ButtonX();
            this.label6 = new System.Windows.Forms.Label();
            this.button_Close = new DevComponents.DotNetBar.ButtonX();
            this.button_SrchMonth = new DevComponents.DotNetBar.ButtonX();
            this.comboBox_Month = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.netResize1 = new Softgroup.NetResize.NetResize(this.components);
            this.txtBXBankNo = new System.Windows.Forms.TextBox();
            this.txtBXCostCenterNo = new System.Windows.Forms.TextBox();
            this.netResize1.AfterControlResize += new Softgroup.NetResize.NetResize.AfterControlResizeEventHandler(this.netResize1_AfterControlResize);
            this.ribbonBar1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelSpecialContainer
            // 
            this.PanelSpecialContainer.Location = new System.Drawing.Point(0, 0);
            this.PanelSpecialContainer.Name = "PanelSpecialContainer";
            this.PanelSpecialContainer.Size = new System.Drawing.Size(200, 100);
            this.PanelSpecialContainer.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(262, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 70;
            this.label1.Text = "الشهـــــر :";
            // 
            // Button_OK
            // 
            this.Button_OK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.Button_OK.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.Button_OK.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.Button_OK.Location = new System.Drawing.Point(206, 245);
            this.Button_OK.Name = "Button_OK";
            this.Button_OK.Size = new System.Drawing.Size(191, 39);
            this.Button_OK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.Button_OK.Symbol = "";
            this.Button_OK.SymbolSize = 16F;
            this.Button_OK.TabIndex = 18;
            this.Button_OK.Text = "ترحيـــــــل";
            this.Button_OK.TextColor = System.Drawing.Color.White;
            this.Button_OK.Click += new System.EventHandler(this.Button_OK_Click);
            // 
            // ribbonBar1
            // 
            this.ribbonBar1.AutoOverflowEnabled = true;
            // 
            // 
            // 
            this.ribbonBar1.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar1.BackgroundStyle.BackColor = System.Drawing.Color.AliceBlue;
            this.ribbonBar1.BackgroundStyle.BackColor2 = System.Drawing.SystemColors.GradientActiveCaption;
            this.ribbonBar1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar1.ContainerControlProcessDialogKey = true;
            this.ribbonBar1.Controls.Add(this.panel1);
            this.ribbonBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonBar1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.ribbonBar1.Location = new System.Drawing.Point(0, 0);
            this.ribbonBar1.Name = "ribbonBar1";
            this.ribbonBar1.Size = new System.Drawing.Size(433, 304);
            this.ribbonBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this.ribbonBar1.TabIndex = 1103;
            // 
            // 
            // 
            this.ribbonBar1.TitleStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.ribbonBar1.TitleStyle.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.ribbonBar1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar1.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.txtBXCostCenterNo);
            this.panel1.Controls.Add(this.txtBXBankNo);
            this.panel1.Controls.Add(this.button_Close);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.checkBox_AccID);
            this.panel1.Controls.Add(this.Button_OK);
            this.panel1.Controls.Add(this.comboBox_Month);
            this.panel1.Controls.Add(this.CmbCurr);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtBXCostCenterName);
            this.panel1.Controls.Add(this.button_SrchMonth);
            this.panel1.Controls.Add(this.button_SrchCostCenter);
            this.panel1.Controls.Add(this.button_SrchBXBankNo);
            this.panel1.Controls.Add(this.txtBXBankName);
            this.panel1.Controls.Add(this.switchButton_AccType);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(433, 287);
            this.panel1.TabIndex = 1104;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // checkBox_AccID
            // 
            // 
            // 
            // 
            this.checkBox_AccID.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBox_AccID.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.checkBox_AccID.Location = new System.Drawing.Point(238, 80);
            this.checkBox_AccID.Name = "checkBox_AccID";
            this.checkBox_AccID.Size = new System.Drawing.Size(159, 23);
            this.checkBox_AccID.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBox_AccID.TabIndex = 8556;
            this.checkBox_AccID.Text = "إصدار قيد محاسبي تلقائي";
            this.checkBox_AccID.CheckedChanged += new System.EventHandler(this.checkBox_AccID_CheckedChanged);
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Enabled = false;
            this.label8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label8.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label8.ForeColor = System.Drawing.Color.Navy;
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(301, 181);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 13);
            this.label8.TabIndex = 1126;
            this.label8.Text = "العملــــــــة :";
            // 
            // CmbCurr
            // 
            this.CmbCurr.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbCurr.DisplayMember = "Text";
            this.CmbCurr.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.CmbCurr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbCurr.Enabled = false;
            this.CmbCurr.FormattingEnabled = true;
            this.CmbCurr.ItemHeight = 14;
            this.CmbCurr.Location = new System.Drawing.Point(61, 181);
            this.CmbCurr.Name = "CmbCurr";
            this.CmbCurr.Size = new System.Drawing.Size(234, 20);
            this.CmbCurr.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.CmbCurr.TabIndex = 1125;
            // 
            // txtBXCostCenterName
            // 
            this.txtBXCostCenterName.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtBXCostCenterName.BackColor = System.Drawing.Color.White;
            this.txtBXCostCenterName.Enabled = false;
            this.txtBXCostCenterName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtBXCostCenterName.Location = new System.Drawing.Point(61, 155);
            this.txtBXCostCenterName.Name = "txtBXCostCenterName";
            this.txtBXCostCenterName.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtBXCostCenterName, false);
            this.txtBXCostCenterName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtBXCostCenterName.Size = new System.Drawing.Size(234, 20);
            this.txtBXCostCenterName.TabIndex = 1063;
            this.txtBXCostCenterName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button_SrchCostCenter
            // 
            this.button_SrchCostCenter.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchCostCenter.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.button_SrchCostCenter.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchCostCenter.Enabled = false;
            this.button_SrchCostCenter.Location = new System.Drawing.Point(15, 155);
            this.button_SrchCostCenter.Name = "button_SrchCostCenter";
            this.button_SrchCostCenter.Size = new System.Drawing.Size(26, 21);
            this.button_SrchCostCenter.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchCostCenter.Symbol = "";
            this.button_SrchCostCenter.SymbolSize = 12F;
            this.button_SrchCostCenter.TabIndex = 1061;
            this.button_SrchCostCenter.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchCostCenter.Click += new System.EventHandler(this.button_SrchCostCenter_Click);
            // 
            // switchButton_AccType
            // 
            this.switchButton_AccType.Anchor = System.Windows.Forms.AnchorStyles.Right;
            // 
            // 
            // 
            this.switchButton_AccType.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.switchButton_AccType.Enabled = false;
            this.switchButton_AccType.Location = new System.Drawing.Point(298, 128);
            this.switchButton_AccType.Name = "switchButton_AccType";
            this.switchButton_AccType.OffText = "الصندوق";
            this.switchButton_AccType.OnText = "البنك";
            this.switchButton_AccType.Size = new System.Drawing.Size(107, 21);
            this.switchButton_AccType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.switchButton_AccType.TabIndex = 1056;
            this.switchButton_AccType.ValueChanged += new System.EventHandler(this.switchButton_AccType_ValueChanged);
            // 
            // txtBXBankName
            // 
            this.txtBXBankName.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtBXBankName.BackColor = System.Drawing.Color.White;
            this.txtBXBankName.Enabled = false;
            this.txtBXBankName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtBXBankName.Location = new System.Drawing.Point(61, 128);
            this.txtBXBankName.Name = "txtBXBankName";
            this.txtBXBankName.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtBXBankName, false);
            this.txtBXBankName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtBXBankName.Size = new System.Drawing.Size(234, 20);
            this.txtBXBankName.TabIndex = 1054;
            this.txtBXBankName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button_SrchBXBankNo
            // 
            this.button_SrchBXBankNo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchBXBankNo.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.button_SrchBXBankNo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchBXBankNo.Enabled = false;
            this.button_SrchBXBankNo.Location = new System.Drawing.Point(15, 128);
            this.button_SrchBXBankNo.Name = "button_SrchBXBankNo";
            this.button_SrchBXBankNo.Size = new System.Drawing.Size(26, 21);
            this.button_SrchBXBankNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchBXBankNo.Symbol = "";
            this.button_SrchBXBankNo.SymbolSize = 12F;
            this.button_SrchBXBankNo.TabIndex = 1050;
            this.button_SrchBXBankNo.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchBXBankNo.Click += new System.EventHandler(this.button_SrchBXBankNo_Click);
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Enabled = false;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label6.ForeColor = System.Drawing.Color.Navy;
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(296, 159);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 13);
            this.label6.TabIndex = 1062;
            this.label6.Text = "مركز التكلفة :";
            // 
            // button_Close
            // 
            this.button_Close.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_Close.Checked = true;
            this.button_Close.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_Close.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.button_Close.Location = new System.Drawing.Point(12, 245);
            this.button_Close.Name = "button_Close";
            this.button_Close.Size = new System.Drawing.Size(191, 38);
            this.button_Close.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_Close.Symbol = "";
            this.button_Close.SymbolSize = 16F;
            this.button_Close.TabIndex = 19;
            this.button_Close.Text = "خـــروج";
            this.button_Close.TextColor = System.Drawing.Color.Black;
            this.button_Close.Click += new System.EventHandler(this.button_Close_Click);
            // 
            // button_SrchMonth
            // 
            this.button_SrchMonth.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchMonth.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.button_SrchMonth.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchMonth.Location = new System.Drawing.Point(51, 26);
            this.button_SrchMonth.Name = "button_SrchMonth";
            this.button_SrchMonth.Size = new System.Drawing.Size(26, 24);
            this.button_SrchMonth.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchMonth.Symbol = "";
            this.button_SrchMonth.SymbolSize = 12F;
            this.button_SrchMonth.TabIndex = 1586;
            this.button_SrchMonth.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchMonth.Click += new System.EventHandler(this.button_SrchMonth_Click);
            // 
            // comboBox_Month
            // 
            this.comboBox_Month.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox_Month.DisplayMember = "Text";
            this.comboBox_Month.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBox_Month.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Month.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.comboBox_Month.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.comboBox_Month.FormattingEnabled = true;
            this.comboBox_Month.ItemHeight = 18;
            this.comboBox_Month.Location = new System.Drawing.Point(83, 27);
            this.comboBox_Month.Name = "comboBox_Month";
            this.comboBox_Month.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.comboBox_Month.Size = new System.Drawing.Size(173, 24);
            this.comboBox_Month.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBox_Month.TabIndex = 1585;
            this.comboBox_Month.WatermarkText = "لا يوجد رواتب غير مرّحلة";
            // 
            // netResize1
            // 
            this.netResize1.ParentControl = this;
            // 
            // txtBXBankNo
            // 
            this.txtBXBankNo.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtBXBankNo.BackColor = System.Drawing.Color.White;
            this.txtBXBankNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtBXBankNo.Location = new System.Drawing.Point(262, 311);
            this.txtBXBankNo.MaxLength = 30;
            this.txtBXBankNo.Name = "txtBXBankNo";
            this.txtBXBankNo.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtBXBankNo, false);
            this.txtBXBankNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtBXBankNo.Size = new System.Drawing.Size(108, 20);
            this.txtBXBankNo.TabIndex = 8557;
            this.txtBXBankNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtBXCostCenterNo
            // 
            this.txtBXCostCenterNo.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtBXCostCenterNo.BackColor = System.Drawing.Color.White;
            this.txtBXCostCenterNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtBXCostCenterNo.Location = new System.Drawing.Point(83, 311);
            this.txtBXCostCenterNo.Name = "txtBXCostCenterNo";
            this.txtBXCostCenterNo.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtBXCostCenterNo, false);
            this.txtBXCostCenterNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtBXCostCenterNo.Size = new System.Drawing.Size(169, 20);
            this.txtBXCostCenterNo.TabIndex = 8558;
            this.txtBXCostCenterNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // FrmRelaySalaries
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 304);
            this.Controls.Add(this.ribbonBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "FrmRelaySalaries";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ترحيل الرواتب";
            this.Load += new System.EventHandler(this.FrmRelaySalaries_Load);
            this.Shown += new System.EventHandler(this.FrmInvSale_Shown);
            this.SizeChanged += new System.EventHandler(this.FrmInvSale_SizeChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmRelaySalaries_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FrmRelaySalaries_KeyPress);
            this.ribbonBar1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).EndInit();
            this.ResumeLayout(false);

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
