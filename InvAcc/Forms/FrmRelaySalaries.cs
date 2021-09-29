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
    public partial  class FrmRelaySalaries : Form
    { void avs(int arln)

{ 
 label1.Text=   (arln == 0 ? "  الشهـــــر :  " : "  month:") ; Button_OK.Text=   (arln == 0 ? "  ترحيـــــــل  " : "  deportation") ; checkBox_AccID.Text=   (arln == 0 ? "  إصدار قيد محاسبي تلقائي  " : "  Issuance of automatic accounting entry") ; label8.Text=   (arln == 0 ? "  العملــــــــة :  " : "  work:") ; label6.Text=   (arln == 0 ? "  مركز التكلفة :  " : "  cost center:") ; button_Close.Text=   (arln == 0 ? "  خـــروج  " : "  Close") ; Text = "ترحيل الرواتب";this.Text=   (arln == 0 ? "  ترحيل الرواتب  " : "  Salary posting") ;}
        private void langloads(object sender, EventArgs e)
        {
             avs(GeneralM.VarGeneral.currentintlanguage);
        }
   
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
            InitializeComponent();this.Load += langloads;
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
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {
        }
    }
}
