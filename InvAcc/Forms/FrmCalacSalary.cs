using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.DotNetBar.SuperGrid;
using DevComponents.Editors;
using Framework.Data;
using InvAcc.GeneralM;
using InvAcc.Stock_Data;
using Microsoft.Win32;
using SSSDateTime.Date;
using SSSLanguage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial  class FrmCalacSalary : Form
    { void avs(int arln)

{ 
 checkBox_AccID.Text=   (arln == 0 ? "  إصدار قيد إثبات مصروف الموظفين  " : "  Issuance of employee expense record entry قيد") ; label8.Text=   (arln == 0 ? "  العملــــــــة :  " : "  work:") ; label2.Text=   (arln == 0 ? "  حساب المصروف :  " : "  Expense account:") ; label6.Text=   (arln == 0 ? "  مركـــز التكلفـــة :  " : "  Cost center:") ; label1.Text=   (arln == 0 ? "  الشهـــــر :  " : "  month:") ; label4.Text=   (arln == 0 ? "  إجمالي الرواتب :  " : "  Total salary:") ; Button_OK.Text=   (arln == 0 ? "  إصدار الرواتب  " : "  Payroll Issuance") ; button_Close.Text=   (arln == 0 ? "  الخـــــــروج  " : "  Close") ; Text = "إصدار رواتب الموظفين";this.Text=   (arln == 0 ? "  إصدار رواتب الموظفين  " : "  Issuance of employee salaries") ;}
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
        private SuperTabControl superTabControl1;
        private ButtonItem Button_OK;
        private ButtonItem button_Close;
        private SuperTabControlPanel superTabControlPanel5;
        private SuperTabItem superTabItem_General;
        private SuperGridControl DVG_ACC;
        private DoubleInput txtSumDebit;
        protected Label label1;
        private MaskedTextBox textBox_Date;
        private CheckBoxX checkBox_AccID;
        private Panel panel_Acc;
        internal Label label2;
        private TextBox txtBXCostCenterNo;
        private TextBox txtBXCostCenterName;
        private ButtonX button_SrchCostCenter;
        private TextBox txtBXBankName;
        private ButtonX button_SrchBXBankNo;
        private TextBox txtBXBankNo;
        internal Label label6;
        protected Label label4;
        internal Label label8;
        private ComboBoxEx CmbCurr;
        private SwitchButton switchButton_DisBalance;
        private HijriGreg.HijriGregDates n = new HijriGreg.HijriGregDates();
        private ScriptNumber ScriptNumber1 = new ScriptNumber();
        private string vDate = "";
        private T_Sal data_this_salary;
        public Dictionary<string, ColumnDictinary> columns_Names_visible = new Dictionary<string, ColumnDictinary>();
        private List<T_INVSETTING> listInvSetting = new List<T_INVSETTING>();
        private T_INVSETTING _InvSetting = new T_INVSETTING();
        private List<T_SYSSETTING> listSysSetting = new List<T_SYSSETTING>();
        private T_SYSSETTING _SysSetting = new T_SYSSETTING();
        private List<T_Company> listCompany = new List<T_Company>();
        private T_Company _Company = new T_Company();
        private List<T_GdAuto> listGdAuto = new List<T_GdAuto>();
        private T_GdAuto _GdAuto = new T_GdAuto();
        private List<T_InfoTb> listInfotb = new List<T_InfoTb>();
        private T_InfoTb _Infotb = new T_InfoTb();
        private int LangArEn = 0;
        private Stock_DataDataContext dbInstance;
        public bool CanEdit = true;
        protected bool CanInsert = true;
        private FormState statex;
        public List<Control> controls;
        public Control codeControl = new Control();
        private bool canUpdate = true;
        private T_GDHEAD _GdHead = new T_GDHEAD();
        public Dictionary<string, ColumnDictinary> columns_Names_visible2 = new Dictionary<string, ColumnDictinary>();
        public T_Sal Datathis_salary
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
        public bool SetReadOnly
        {
            set
            {
                if (value)
                {
                    State = FormState.Saved;
                }
                Button_OK.Enabled = !value;
            }
        }
        public FrmCalacSalary()
        {
            InitializeComponent();this.Load += langloads;
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
            if (e.KeyCode == Keys.F2)
            {
                Button_OK_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
        protected override void OnParentRightToLeftChanged(EventArgs e)
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmCalacSalary));
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
            RibunButtons();
        }
        private bool ValidData()
        {
            if (textBox_Date.Text.Length != 7 || !VarGeneral.CheckDate(textBox_Date.Text))
            {
                return false;
            }
            for (int i = 0; i < DVG_ACC.PrimaryGrid.Rows.Count; i++)
            {
                if (string.IsNullOrEmpty(DVG_ACC.PrimaryGrid.GetCell(i, 3).Value.ToString()))
                {
                    MessageBox.Show((LangArEn == 0) ? "لا يمكن إتمام العملية .. تأكد من تعبئة جميع البيانات المطلوبة" : "We must not be empty value .. Please make sure there are items in the bill.", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return false;
                }
            }
            if (false)
            {
#pragma warning disable CS0162 // Unreachable code detected
                Environment.Exit(0);
#pragma warning restore CS0162 // Unreachable code detected
                return false;
            }
            return true;
        }
        private bool CheckRemotDate()
        {
            try
            {
                if (VarGeneral.gUserName != "runsetting")
                {
                    bool User_Remotly = CheckUserIFRemote();
                    RegistryKey hKeyNew = Registry.CurrentUser.OpenSubKey("Software\\MrdHrdw\\ItIntel", writable: true);
                    RegistryKey hKey = Registry.CurrentUser.OpenSubKey("Software\\PRS AND PR Settings\\WinSystemOperation", writable: true);
                    long regval = 0L;
                    long regvalNew = 0L;
                    if (hKey != null)
                    {
                        try
                        {
                            object q = hKey.GetValue("vRemotly");
                            if (string.IsNullOrEmpty(q.ToString()))
                            {
                                hKey.CreateSubKey("vRemotly");
                                hKey.SetValue("vRemotly", "0");
                            }
                        }
                        catch
                        {
                            hKey.CreateSubKey("vRemotly");
                            hKey.SetValue("vRemotly", "0");
                        }
                        try
                        {
                            object t = hKeyNew.GetValue("vRemotly_New");
                            if (string.IsNullOrEmpty(t.ToString()))
                            {
                                hKeyNew.CreateSubKey("vRemotly_New");
                                hKeyNew.SetValue("vRemotly_New", "0");
                            }
                        }
                        catch
                        {
                            hKeyNew.CreateSubKey("vRemotly_New");
                            hKeyNew.SetValue("vRemotly_New", "0");
                        }
                        regval = long.Parse(hKey.GetValue("vRemotly").ToString());
                        regvalNew = long.Parse(hKeyNew.GetValue("vRemotly_New").ToString());
                    }
                    if (User_Remotly || regval == 1 || regvalNew == 1)
                    {
                        try
                        {
                            if (VarGeneral.vDemo)
                            {
                                return false;
                            }
                            string dtAction = (n.IsHijri(textBox_Date.Text + "/01") ? (textBox_Date.Text + "/01") : n.GregToHijri(textBox_Date.Text + "/01", "yyyy/MM/dd"));
                            if (Convert.ToDateTime(n.GregToHijri(hKeyNew.GetValue("vBackup_New").ToString(), "yyyy/MM/dd")) < Convert.ToDateTime(n.FormatHijri(dtAction, "yyyy/MM/dd")))
                            {
                                MessageBox.Show((LangArEn == 0) ? "لا يمكن إتمام العملية .. لقد تخطيت السنة المالية المحدد للنظام \n يرجى التواصل مع الإدارة لللإشتراك في خدمات النسخة " : "We can not complete the operation .. have you skip the fiscal year specified for the system", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                return false;
                            }
                        }
                        catch
                        {
                            MessageBox.Show((LangArEn == 0) ? "لا يمكن إتمام العملية .. لقد تخطيت السنة المالية المحدد للنظام \n يرجى التواصل مع الإدارة لللإشتراك في خدمات النسخة " : "We can not complete the operation .. have you skip the fiscal year specified for the system", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            return false;
                        }
                    }
                }
            }
            catch
            {
                return false;
            }
            return true;
        }
        private bool CheckUserIFRemote()
        {
            try
            {
#pragma warning disable CS0162 // Unreachable code detected
               return false; if (SystemInformation.TerminalServerSession)
#pragma warning restore CS0162 // Unreachable code detected
                {
                    return true;
                }
                return false;
            }
            catch
            {
                return true;
            }
        }
        private void RibunButtons()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                Button_OK.Text = "إصدار الرواتب";
                Button_OK.Tooltip = "F2";
                button_Close.Text = "الخـــــــروج";
                button_Close.Tooltip = "Esc";
                switchButton_DisBalance.OnText = "خصم الرصيد السابق المستحق عليه  خلال الشهر من الراتب";
                switchButton_DisBalance.OffText = "خصم الرصيد السابق المستحق عليه  خلال الشهر من الراتب";
                Text = "إصدار رواتب الموظفين";
            }
            else
            {
                Button_OK.Text = "Calculating salaries";
                button_Close.Text = "Exit";
                Button_OK.Tooltip = "F2";
                button_Close.Tooltip = "Esc";
                switchButton_DisBalance.OnText = "Deduction of the previous balance payable during the month of salary";
                switchButton_DisBalance.OffText = "Deduction of the previous balance payable during the month of salary";
                Text = "Salary Employees calculation";
            }
        }
        private void SettingGridLate()
        {
            DVG_ACC.PrimaryGrid.Columns[0].HeaderText = ((LangArEn == 0) ? "الراتب والبدلات" : "Salary");
            DVG_ACC.PrimaryGrid.Columns[1].HeaderText = ((LangArEn == 0) ? "المستوى" : "Level");
            DVG_ACC.PrimaryGrid.Columns[2].HeaderText = ((LangArEn == 0) ? "إسم الموظف" : "Employee Name");
            DVG_ACC.PrimaryGrid.Columns[3].HeaderText = ((LangArEn == 0) ? "رقم الموظف" : "Employee No");
        }
        private void FillCombo()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
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
        private void FrmCalacSalary_Load(object sender, EventArgs e)
        {
            try
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmCalacSalary));
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
                FillCombo();
                SettingGridLate();
                int? calendr = VarGeneral.Settings_Sys.Calendr;
                if (calendr.Value == 0 && calendr.HasValue)
                {
                    textBox_Date.Text = n.FormatGreg(VarGeneral.Gdate, "yyyy/MM");
                }
                else
                {
                    textBox_Date.Text = n.FormatHijri(VarGeneral.Hdate, "yyyy/MM");
                }
                FillGraidEmps();
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Load:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void FillGraidEmps()
        {
            Stock_DataDataContext newDB = new Stock_DataDataContext(VarGeneral.BranchCS);
            List<T_AccDef> list = newDB.FillAccDef_2("").ToList();
            list = list.Where((T_AccDef q) => q.AccCat == 6 && q.Lev == 4).ToList();
            double _vRequired = 0.0;
            if (switchButton_DisBalance.Value)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    _vRequired = 0.0;
                    try
                    {
                        _vRequired = list[i].T_GDDETs.Where((T_GDDET g) => !g.T_GDHEAD.gdLok && g.T_GDHEAD.gdTyp == 13 && ((!n.IsGreg(textBox_Date.Text + "/01")) ? (g.T_GDHEAD.gdHDate.Substring(5, 2) == textBox_Date.Text.Substring(5, 2) && g.T_GDHEAD.gdHDate.Substring(0, 4) == textBox_Date.Text.Substring(0, 4)) : (g.T_GDHEAD.gdGDate.Substring(5, 2) == textBox_Date.Text.Substring(5, 2) && g.T_GDHEAD.gdGDate.Substring(0, 4) == textBox_Date.Text.Substring(0, 4)))).Sum((T_GDDET g) => g.gdValue.Value);
                        if (_vRequired < 0.0)
                        {
                            _vRequired = 0.0;
                        }
                    }
                    catch
                    {
                        _vRequired = 0.0;
                    }
                    T_AccDef t_AccDef = list[i];
                    t_AccDef.MainSal -= _vRequired;
                }
            }
            try
            {
                DVG_ACC.PrimaryGrid.Rows.Clear();
            }
            catch
            {
            }
            for (int i = 0; i < list.Count; i++)
            {
                GridRow row = new GridRow();
                row.Cells.Add(new GridCell(""));
                row.Cells.Add(new GridCell(""));
                row.Cells.Add(new GridCell(""));
                row.Cells.Add(new GridCell(""));
                row.Cells.Add(new GridCell(""));
                row.Cells.Add(new GridCell(""));
                row.Cells[3].Value = list[i].AccDef_No;
                row.Cells[2].Value = ((LangArEn == 0) ? list[i].Arb_Des : list[i].Eng_Des);
                row.Cells[1].Value = list[i].Lev.Value;
                try
                {
                    row.Cells[0].Value = list[i].MainSal.Value;
                }
                catch
                {
                    row.Cells[0].Value = 0;
                }
                DVG_ACC.PrimaryGrid.Rows.Add(row);
            }
            txtSumDebit.Value = CellSum(0);
        }
        private void textbox_Arb_Des_Enter(object sender, EventArgs e)
        {
            Language.Switch("AR");
        }
        private void textbox_Eng_Des_Enter(object sender, EventArgs e)
        {
            Language.Switch("EN");
        }
        private void txtHeadingR3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsNumber(e.KeyChar) & (e.KeyChar != '\b')) && e.KeyChar != '-' && e.KeyChar != '\\')
            {
                e.Handled = true;
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
        private double CellSum(int col)
        {
            double sum = 0.0;
            for (int i = 0; i < DVG_ACC.PrimaryGrid.Rows.Count; i++)
            {
                double d = 0.0;
                d = double.Parse(DVG_ACC.PrimaryGrid.GetCell(i, col).Value.ToString());
                sum += d;
            }
            return sum;
        }
        private void DVG_ACC_EndEdit(object sender, GridEditEventArgs e)
        {
            txtSumDebit.Value = CellSum(0);
        }
        private void Button_OK_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidData())
                {
                    return;
                }
                vDate = Convert.ToDateTime(textBox_Date.Text).ToString("yyyy/MM/dd");
                string BDate = vDate;
                Button_OK.Enabled = false;
                button_Close.Enabled = false;
                List<T_Sal> newdata = db.GetEmpSal(textBox_Date.Text);
                if (newdata.Count > 0)
                {
                    for (int j = 0; j < newdata.Count; j++)
                    {
                        if (newdata[j].SalaryStatus == true)
                        {
                            MessageBox.Show((LangArEn == 0) ? "لقد تم احتساب راتب هذا الشهر وترحيلها سابقا" : "Salaries this month is Carryover", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            Button_OK.Enabled = true;
                            button_Close.Enabled = true;
                            return;
                        }
                    }
                }
                try
                {
                    if (newdata.FirstOrDefault().GadeId2.HasValue && MessageBox.Show((LangArEn == 0) ? " لقد تم إصدار قيد إثبات مصروف لرواتب هذا الشهر  \n وسيتم حذف هذا القيد هل تريد المتابعة ؟" : "Will filter all advances and holidays between the dates specified \n Are you sure you want to Carryover the data?", VarGeneral.ProdectNam, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                    {
                        Button_OK.Enabled = true;
                        button_Close.Enabled = true;
                        return;
                    }
                }
                catch
                {
                }
                int i;
                for (i = 0; i < newdata.Count; i++)
                {
                    if (!newdata[i].GadeId2.HasValue)
                    {
                        continue;
                    }
                    try
                    {
                        List<T_GDHEAD> gdData = db.T_GDHEADs.Where((T_GDHEAD t) => t.gdhead_ID == int.Parse(newdata[i].GadeId2.Value.ToString()) && t.gdTyp == (int?)11).ToList();
                        if (gdData.Count > 0)
                        {
                            IDatabase db_ = Database.GetDatabase(VarGeneral.BranchCS);
                            try
                            {
                                T_GDHEAD data_this = gdData.FirstOrDefault();
                                db_ = Database.GetDatabase(VarGeneral.BranchCS);
                                db_.StartTransaction();
                                db_.ClearParameters();
                                db_.AddParameter("gdhead_ID", DbType.Int32, data_this.gdhead_ID);
                                db_.ExecuteNonQueryWithoutCommit(storedProcedure: true, "S_T_GDHEAD_DELETE");
                                db_.EndTransaction();
                            }
                            catch (SqlException)
                            {
                                MessageBox.Show((LangArEn == 0) ? "حدث خطأ اثناء محاولة اصدار رواتب الشهر .. " : "An error occurred while trying to issue a month salaries ..", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                Button_OK.Enabled = true;
                                button_Close.Enabled = true;
                                return;
                            }
                        }
                    }
                    catch
                    {
                        MessageBox.Show((LangArEn == 0) ? "حدث خطأ اثناء محاولة اصدار رواتب الشهر .. " : "An error occurred while trying to issue a month salaries ..", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        Button_OK.Enabled = true;
                        button_Close.Enabled = true;
                        return;
                    }
                }
                db.ExecuteCommand("delete T_Sal WHERE SalaryStatus = 0 AND SalYear = " + int.Parse(Convert.ToDateTime(vDate).ToString("yyyy/MM/dd").Substring(0, 4)) + " AND SalMonth = " + int.Parse(Convert.ToDateTime(vDate).ToString("yyyy/MM/dd").Substring(5, 2)));
                if (DVG_ACC.PrimaryGrid.Rows.Count() > 0)
                {
                    for (int j = 0; j < DVG_ACC.PrimaryGrid.Rows.Count; j++)
                    {
                        try
                        {
                            try
                            {
                                T_Sal vQ2 = db.GetEmpSalWithRqst2(vDate, DVG_ACC.PrimaryGrid.GetCell(j, 3).Value.ToString());
                                if (vQ2 != null && !string.IsNullOrEmpty(vQ2.SalaryID))
                                {
                                    continue;
                                }
                            }
                            catch
                            {
                            }
                            if (Convert.ToDateTime(Convert.ToDateTime(vDate).ToString("yyyy/MM")) >= Convert.ToDateTime(Convert.ToDateTime(db.StockAccDefWithOutBalance(DVG_ACC.PrimaryGrid.GetCell(j, 3).Value.ToString()).DateAppointment).ToString("yyyy/MM")))
                            {
                                T_Sal vQ = db.GetEmpSalWithRqst(vDate, DVG_ACC.PrimaryGrid.GetCell(j, 3).Value.ToString());
                                if (vQ == null || string.IsNullOrEmpty(vQ.SalaryID))
                                {
                                    Datathis_salary = new T_Sal();
                                    Guid id = Guid.NewGuid();
                                    data_this_salary.SalaryID = id.ToString();
                                    data_this_salary.SalMonth = int.Parse(Convert.ToDateTime(vDate).ToString("yyyy/MM/dd").Substring(5, 2));
                                    data_this_salary.SalYear = int.Parse(Convert.ToDateTime(vDate).ToString("yyyy/MM/dd").Substring(0, 4));
                                    data_this_salary.EmpID = DVG_ACC.PrimaryGrid.GetCell(j, 3).Value.ToString();
                                    data_this_salary.DirBoss = null;
                                    data_this_salary.DeptNo = null;
                                    data_this_salary.SectionNo = null;
                                    data_this_salary.Job = null;
                                    data_this_salary.Salary = double.Parse(VarGeneral.TString.TEmpty(DVG_ACC.PrimaryGrid.GetCell(j, 0).Value.ToString()));
                                    data_this_salary.SalaryStatus = false;
                                    data_this_salary.IsPrint = false;
                                    data_this_salary.SalAcc = DVG_ACC.PrimaryGrid.GetCell(j, 3).Value.ToString();
                                    data_this_salary.LoanAcc = DVG_ACC.PrimaryGrid.GetCell(j, 3).Value.ToString();
                                    data_this_salary.HouseAcc = DVG_ACC.PrimaryGrid.GetCell(j, 3).Value.ToString();
                                    data_this_salary.CostCenterEmp = null;
                                    data_this_salary.HousingAllowance = 0.0;
                                    data_this_salary.TransferAllowance = 0.0;
                                    data_this_salary.OtherAllowance = 0.0;
                                    data_this_salary.SocialInsuranceComp = 0.0;
                                    data_this_salary.SocialInsurance = 0.0;
                                    data_this_salary.InsuranceMedical = 0.0;
                                    data_this_salary.InsuranceMedicalCom = 0.0;
                                    data_this_salary.SubDay = 0.0;
                                    data_this_salary.LateHours = 0.0;
                                    data_this_salary.SubJaza = 0.0;
                                    data_this_salary.SubOther = 0.0;
                                    data_this_salary.SubCallPhone = 0.0;
                                    data_this_salary.SubCommentary = 0.0;
                                    data_this_salary.AddDay = 0.0;
                                    data_this_salary.AddHour = 0.0;
                                    data_this_salary.MandateDay = 0.0;
                                    data_this_salary.Advance = 0.0;
                                    data_this_salary.Rewards = 0.0;
                                    data_this_salary.Bank = null;
                                    data_this_salary.AccountNo = "";
                                    data_this_salary.IsPrint = false;
                                    data_this_salary.Total = double.Parse(VarGeneral.TString.TEmpty(string.Concat(data_this_salary.Salary.Value)));
                                    data_this_salary.SalSpell = ScriptNumber1.ScriptNum(decimal.Parse(VarGeneral.TString.TEmpty(string.Concat(data_this_salary.Total))));
                                    db.T_Sals.InsertOnSubmit(data_this_salary);
                                    db.SubmitChanges();
                                }
                            }
                        }
                        catch
                        {
                        }
                    }
                    if (checkBox_AccID.Checked)
                    {
                        IDatabase db_ = Database.GetDatabase(VarGeneral.BranchCS);
                        List<T_Sal> newdata22 = db.GetEmpSal(textBox_Date.Text);
                        Stock_DataDataContext dbc = new Stock_DataDataContext(VarGeneral.BranchCS);
                        int Line = 1;
                        double vCrdit = 0.0;
                        double vAdds = 0.0;
                        double vDis = 0.0;
                        if (newdata22.Count > 0)
                        {
                            vCrdit = newdata22.Sum((T_Sal g) => g.T_AccDef.MainSal.HasValue ? g.T_AccDef.MainSal.Value : 0.0);
                        }
                        GetDataGd(vCrdit);
                        _GdHead.DATE_CREATED = DateTime.Now;
                        dbc.T_GDHEADs.InsertOnSubmit(_GdHead);
                        dbc.SubmitChanges();
                        for (int j = 0; j < newdata22.Count; j++)
                        {
                            vAdds = (newdata22[j].AddDay.HasValue ? newdata22[j].AddDay.Value : 0.0) + (newdata22[j].AddHour.HasValue ? newdata22[j].AddHour.Value : 0.0) + (newdata22[j].MandateDay.HasValue ? newdata22[j].MandateDay.Value : 0.0) + (newdata22[j].Rewards.HasValue ? newdata22[j].Rewards.Value : 0.0);
                            vDis = (newdata22[j].LateHours.HasValue ? newdata22[j].LateHours.Value : 0.0) + (newdata22[j].SubDay.HasValue ? newdata22[j].SubDay.Value : 0.0) + (newdata22[j].SubJaza.HasValue ? newdata22[j].SubJaza.Value : 0.0) + (newdata22[j].SubOther.HasValue ? newdata22[j].SubOther.Value : 0.0) + (newdata22[j].SubCallPhone.HasValue ? newdata22[j].SubCallPhone.Value : 0.0) + (newdata22[j].SubCommentary.HasValue ? newdata22[j].SubCommentary.Value : 0.0) + (newdata22[j].InsuranceMedical.HasValue ? newdata22[j].InsuranceMedical.Value : 0.0) + (newdata22[j].SocialInsurance.HasValue ? newdata22[j].SocialInsurance.Value : 0.0);
                            if (newdata22[j].T_AccDef.MainSal.Value > 0.0)
                            {
                                db_.StartTransaction();
                                db_.ClearParameters();
                                db_.AddParameter("GDDET_ID", DbType.Int32, 0);
                                db_.AddParameter("gdID", DbType.Int32, _GdHead.gdhead_ID);
                                db_.AddParameter("gdNo", DbType.String, _GdHead.gdNo);
                                db_.AddParameter("gdDes", DbType.String, "إثبات رواتب شهر | " + Convert.ToDateTime(textBox_Date.Text).Month);
                                db_.AddParameter("gdDesE", DbType.String, "Proof Salaries Month | " + Convert.ToDateTime(textBox_Date.Text).Month);
                                db_.AddParameter("recptTyp", DbType.String, VarGeneral.InvTyp);
                                db_.AddParameter("AccNo", DbType.String, newdata22[j].SalAcc);
                                db_.AddParameter("AccName", DbType.String, "");
                                db_.AddParameter("gdValue", DbType.Double, 0.0 - (newdata22[j].T_AccDef.MainSal.Value + newdata22[j].TransferAllowance.Value + newdata22[j].OtherAllowance.Value));
                                db_.AddParameter("recptNo", DbType.String, _GdHead.gdNo);
                                db_.AddParameter("Lin", DbType.Int32, Line);
                                db_.AddParameter("AccNoDestruction", DbType.String, null);
                                db_.ExecuteNonQueryWithoutCommit(storedProcedure: true, "S_T_GDDET_INSERT");
                                db_.EndTransaction();
                                Line++;
                            }
                            if (newdata22[j].HousingAllowance.Value > 0.0)
                            {
                                db_.StartTransaction();
                                db_.ClearParameters();
                                db_.AddParameter("GDDET_ID", DbType.Int32, 0);
                                db_.AddParameter("gdID", DbType.Int32, _GdHead.gdhead_ID);
                                db_.AddParameter("gdNo", DbType.String, _GdHead.gdNo);
                                db_.AddParameter("gdDes", DbType.String, "إثبات بدل سكن شهر | " + Convert.ToDateTime(textBox_Date.Text).Month);
                                db_.AddParameter("gdDesE", DbType.String, "Proof Housing Allownce Month | " + Convert.ToDateTime(textBox_Date.Text).Month);
                                db_.AddParameter("recptTyp", DbType.String, VarGeneral.InvTyp);
                                db_.AddParameter("AccNo", DbType.String, newdata22[j].HouseAcc);
                                db_.AddParameter("AccName", DbType.String, "");
                                db_.AddParameter("gdValue", DbType.Double, 0.0 - newdata22[j].HousingAllowance.Value);
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
                                db_.AddParameter("gdDes", DbType.String, "إثبات مستحقات شهر | " + Convert.ToDateTime(textBox_Date.Text).Month);
                                db_.AddParameter("gdDesE", DbType.String, "Proof Adds Month | " + Convert.ToDateTime(textBox_Date.Text).Month);
                                db_.AddParameter("recptTyp", DbType.String, VarGeneral.InvTyp);
                                db_.AddParameter("AccNo", DbType.String, newdata22[j].SalAcc);
                                db_.AddParameter("AccName", DbType.String, "");
                                db_.AddParameter("gdValue", DbType.Double, 0.0 - vAdds);
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
                                db_.AddParameter("gdDes", DbType.String, "إثبات مستقطعات شهر | " + Convert.ToDateTime(textBox_Date.Text).Month);
                                db_.AddParameter("gdDesE", DbType.String, "Proof Discount Month | " + Convert.ToDateTime(textBox_Date.Text).Month);
                                db_.AddParameter("recptTyp", DbType.String, VarGeneral.InvTyp);
                                db_.AddParameter("AccNo", DbType.String, newdata22[j].SalAcc);
                                db_.AddParameter("AccName", DbType.String, "");
                                db_.AddParameter("gdValue", DbType.Double, vDis);
                                db_.AddParameter("recptNo", DbType.String, _GdHead.gdNo);
                                db_.AddParameter("Lin", DbType.Int32, Line);
                                db_.AddParameter("AccNoDestruction", DbType.String, null);
                                db_.ExecuteNonQueryWithoutCommit(storedProcedure: true, "S_T_GDDET_INSERT");
                                db_.EndTransaction();
                                Line++;
                            }
                            if (newdata22[j].Advance.Value > 0.0)
                            {
                                db_.StartTransaction();
                                db_.ClearParameters();
                                db_.AddParameter("GDDET_ID", DbType.Int32, 0);
                                db_.AddParameter("gdID", DbType.Int32, _GdHead.gdhead_ID);
                                db_.AddParameter("gdNo", DbType.String, _GdHead.gdNo);
                                db_.AddParameter("gdDes", DbType.String, "إثبات \u064dسلف شهر | " + Convert.ToDateTime(textBox_Date.Text).Month);
                                db_.AddParameter("gdDesE", DbType.String, "Proof Loans Month | " + Convert.ToDateTime(textBox_Date.Text).Month);
                                db_.AddParameter("recptTyp", DbType.String, VarGeneral.InvTyp);
                                db_.AddParameter("AccNo", DbType.String, newdata22[j].LoanAcc);
                                db_.AddParameter("AccName", DbType.String, "");
                                db_.AddParameter("gdValue", DbType.Double, newdata22[j].Advance.Value);
                                db_.AddParameter("recptNo", DbType.String, _GdHead.gdNo);
                                db_.AddParameter("Lin", DbType.Int32, Line);
                                db_.AddParameter("AccNoDestruction", DbType.String, null);
                                db_.ExecuteNonQueryWithoutCommit(storedProcedure: true, "S_T_GDDET_INSERT");
                                db_.EndTransaction();
                                Line++;
                            }
                        }
                        db_.StartTransaction();
                        db_.ClearParameters();
                        db_.AddParameter("GDDET_ID", DbType.Int32, 0);
                        db_.AddParameter("gdID", DbType.Int32, _GdHead.gdhead_ID);
                        db_.AddParameter("gdNo", DbType.String, _GdHead.gdNo);
                        db_.AddParameter("gdDes", DbType.String, "إثبات رواتب شهر | " + Convert.ToDateTime(textBox_Date.Text).Month);
                        db_.AddParameter("gdDesE", DbType.String, "Proof Salaries Month | " + Convert.ToDateTime(textBox_Date.Text).Month);
                        db_.AddParameter("recptTyp", DbType.String, VarGeneral.InvTyp);
                        db_.AddParameter("AccNo", DbType.String, txtBXBankNo.Text);
                        db_.AddParameter("AccName", DbType.String, "");
                        db_.AddParameter("gdValue", DbType.Double, vCrdit);
                        db_.AddParameter("recptNo", DbType.String, _GdHead.gdNo);
                        db_.AddParameter("Lin", DbType.Int32, Line);
                        db_.AddParameter("AccNoDestruction", DbType.String, null);
                        db_.ExecuteNonQueryWithoutCommit(storedProcedure: true, "S_T_GDDET_INSERT");
                        db_.EndTransaction();
                        Line++;
                    }
                    Stock_DataDataContext _DBC = new Stock_DataDataContext(VarGeneral.BranchCS);
                    List<T_Sal> newdata2 = _DBC.GetEmpSal(textBox_Date.Text);
                    for (int j = 0; j < newdata2.Count; j++)
                    {
                        Datathis_salary = new T_Sal();
                        data_this_salary = newdata2[j];
                        try
                        {
                            if (checkBox_AccID.Checked && !string.IsNullOrEmpty(_GdHead.gdhead_ID.ToString()) && _GdHead.gdhead_ID != 0)
                            {
                                data_this_salary.GadeId2 = _GdHead.gdhead_ID;
                            }
                        }
                        catch
                        {
                            data_this_salary.GadeId2 = null;
                        }
                        _DBC.Log = VarGeneral.DebugLog;
                        _DBC.SubmitChanges(ConflictMode.ContinueOnConflict);
                    }
                }
                MessageBox.Show((LangArEn == 0) ? "تمت عملية إصدار الرواتب بنجاح .." : "Issuing salaries process has successfully ..", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                Close();
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("bubbleButton_Ok_Click:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private T_GDHEAD GetDataGd(double vCrdit)
        {
            _GdHead.gdHDate = VarGeneral.Hdate;
            _GdHead.gdGDate = VarGeneral.Gdate;
            _GdHead.gdNo = db.MaxGDHEADsNo.ToString();
            _GdHead.ArbTaf = ScriptNumber1.ScriptNum(decimal.Parse("0" + vCrdit));
            _GdHead.BName = _GdHead.BName;
            _GdHead.ChekNo = _GdHead.ChekNo;
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
            _GdHead.gdMem = "إثبات مصروف رواتب  شهر | " + Convert.ToDateTime(textBox_Date.Text).Month + " | Expenses the employee Month ";
            _GdHead.gdMnd = null;
            _GdHead.gdRcptID = (_GdHead.gdRcptID.HasValue ? _GdHead.gdRcptID.Value : 0.0);
            _GdHead.gdTot = vCrdit;
            _GdHead.gdTp = (_GdHead.gdTp.HasValue ? _GdHead.gdTp.Value : 0);
            _GdHead.gdTyp = VarGeneral.InvTyp;
            _GdHead.RefNo = "";
            _GdHead.DATE_MODIFIED = DateTime.Now;
            _GdHead.salMonth = "";
            _GdHead.gdUser = VarGeneral.UserNumber;
            _GdHead.gdUserNam = VarGeneral.UserNameA;
            _GdHead.CompanyID = 1;
            return _GdHead;
        }
        private void button_Close_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void textBox_Date_Leave(object sender, EventArgs e)
        {
            try
            {
                if (VarGeneral.CheckDate(textBox_Date.Text))
                {
                    textBox_Date.Text = Convert.ToDateTime(textBox_Date.Text).ToString("yyyy/MM");
                }
                else
                {
                    int? calendr = VarGeneral.Settings_Sys.Calendr;
                    if (calendr.Value == 0 && calendr.HasValue)
                    {
                        textBox_Date.Text = n.FormatGreg(VarGeneral.Gdate, "yyyy/MM");
                    }
                    else
                    {
                        textBox_Date.Text = n.FormatHijri(VarGeneral.Hdate, "yyyy/MM");
                    }
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("textBox_Date_Leave:", error, enable: true);
            }
            FillGraidEmps();
        }
        private void textBox_Date_Click(object sender, EventArgs e)
        {
            textBox_Date.SelectAll();
        }
        private void checkBox_AccID_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_AccID.Checked)
            {
                panel_Acc.Enabled = true;
                return;
            }
            panel_Acc.Enabled = false;
            txtBXBankName.Text = "";
            txtBXBankNo.Text = "";
            txtBXCostCenterName.Text = "";
            txtBXCostCenterNo.Text = "";
        }
        private void button_SrchBXBankNo_Click(object sender, EventArgs e)
        {
            columns_Names_visible2.Clear();
            columns_Names_visible2.Add("AccDef_No", new ColumnDictinary("الرقم ", " No", ifDefault: true, ""));
            columns_Names_visible2.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, ""));
            columns_Names_visible2.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, ""));
            columns_Names_visible2.Add("AccDef_ID", new ColumnDictinary(" ", " ", ifDefault: false, ""));
            columns_Names_visible2.Add("Mobile", new ColumnDictinary("الجوال", "Mobile", ifDefault: false, ""));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible2;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, ""));
            }
            VarGeneral.SFrmTyp = "T_AccDef";
            VarGeneral.AccTyp = 8;
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != "")
            {
                T_AccDef _AccDef = db.StockAccDefs(int.Parse(frm.Serach_No));
                txtBXBankNo.Text = _AccDef.AccDef_No.ToString();
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
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
                txtBXBankNo.Text = "";
                txtBXBankName.Text = "";
            }
        }
        private void button_SrchCostCenter_Click(object sender, EventArgs e)
        {
            columns_Names_visible2.Clear();
            columns_Names_visible2.Add("Cst_No", new ColumnDictinary("الرقم", "No", ifDefault: true, ""));
            columns_Names_visible2.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, ""));
            columns_Names_visible2.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, ""));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible2;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, ""));
            }
            VarGeneral.SFrmTyp = "T_CstTbl";
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != "")
            {
                txtBXCostCenterNo.Text = db.StockCst(frm.Serach_No).Cst_ID.ToString();
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
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
                txtBXCostCenterNo.Text = "";
                txtBXCostCenterName.Text = "";
            }
        }
        private void switchButton_DisBalance_ValueChanged(object sender, EventArgs e)
        {
            FillGraidEmps();
        }
    }
}
