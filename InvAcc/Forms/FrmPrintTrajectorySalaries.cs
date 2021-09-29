//
using CrystalDecisions.CrystalReports.Engine;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.DotNetBar.SuperGrid;
using DevComponents.Editors;
using InvAcc.GeneralM;
using InvAcc.Stock_Data;
using Library.RepShow;
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
    public partial  class FrmPrintTrajectorySalaries : Form
    { void avs(int arln)

{ 
 itemPanel4.Text=   (arln == 0 ? "  itemPanel4  " : "  itemPanel4") ; itemPanel3.Text=   (arln == 0 ? "  itemPanel3  " : "  itemPanel3") ; itemPanel2.Text=   (arln == 0 ? "  itemPanel2  " : "  itemPanel2") ; itemPanel1.Text=   (arln == 0 ? "  itemPanel1  " : "  itemPanel1") ; bar1.Text=   (arln == 0 ? "  bar1  " : "  bar1") ; buttonItem_ListSal.Text=   (arln == 0 ? "  المســــيّرات  " : "  the marches") ; ToolStripMenuItem_PrintSalary.Text=   (arln == 0 ? "  مسّير رواتب الموظفين  " : "  Employee Payroll Manager") ; ToolStripMenuItem_PrintSalaryDet.Text=   (arln == 0 ? "  تقرير راتــــــب الموظف   " : "  Employee salary report") ; ToolStripMenuItem_PrintBankID.Text=   (arln == 0 ? "  تقرير البنـــك  " : "  bank report") ; buttonItem_ListAdd.Text=   (arln == 0 ? "  المستحقات والمستقطعات  " : "  Receivables and deductions") ; ToolStripMenuItem_PrintAllownces.Text=   (arln == 0 ? "  تقرير البدلات  " : "  Allowance Report") ; ToolStripMenuItem_PrintAdd.Text=   (arln == 0 ? "  تقرير بالإضافــي  " : "  additional report") ; ToolStripMenuItem_PrintReward.Text=   (arln == 0 ? "  تقرير بالحوافز  " : "  incentive report") ; ToolStripMenuItem_PrintDiscount.Text=   (arln == 0 ? "  تقرير بالخصــم  " : "  discount report") ; ToolStripMenuItem_PrintAdvances.Text=   (arln == 0 ? "  تقرير بالسلــف  " : "  advance report") ; ButClose.Text=   (arln == 0 ? "  إغلاق  " : "  Close") ; label1.Text=   (arln == 0 ? "  تقرير رواتب شهــر  " : "  Monthly salary report") ; label3.Text=   (arln == 0 ? "  عدد الأيام :  " : "  The number of days :") ; Text = "طبــــــاعة الــــرواتب";this.Text=   (arln == 0 ? "  طبــــــاعة الــــرواتب  " : "  Payroll printing") ;}
        private void langloads(object sender, EventArgs e)
        {
             avs(GeneralM.VarGeneral.currentintlanguage);
        }
   
        public class ColumnDictinaryRep
        {
            public string EmpName = string.Empty;
            public string EmpNo = string.Empty;
            public string JOb = string.Empty;
            public double MainSalary = 0.0;
            public double VAdd = 0.0;
            public double VSub = 0.0;
            public double TotSal = 0.0;
            public ColumnDictinaryRep(string empNo, string empName, string jOb, double mainSalary, double vAdd, double vSub, double totSal)
            {
                EmpName = empName;
                EmpNo = empNo;
                JOb = jOb;
                MainSalary = mainSalary;
                VAdd = vAdd;
                VSub = vSub;
                TotSal = totSal;
            }
        }
        public class ColumnDictinaryPrintRep
        {
            public string EmpName = string.Empty;
            public string EmpNo = string.Empty;
            public string CodBank = string.Empty;
            public string BankNameA = string.Empty;
            public string IDAcc = string.Empty;
            public double TotSal = 0.0;
            public ColumnDictinaryPrintRep(string empNo, string empName, string codBank, string bankNameA, string idAcc, double totSal)
            {
                EmpName = empName;
                EmpNo = empNo;
                CodBank = codBank;
                BankNameA = bankNameA;
                IDAcc = idAcc;
                TotSal = totSal;
            }
        }
        private T_Branch vBr = new T_Branch();
        private int LangArEn = 0;
        private Dictionary<long, ColumnDictinaryRep> columns_Names_visible = new Dictionary<long, ColumnDictinaryRep>();
        private Dictionary<long, ColumnDictinaryPrintRep> columns_Names_visiblePrinRep = new Dictionary<long, ColumnDictinaryPrintRep>();
        private HijriGreg.HijriGregDates n = new HijriGreg.HijriGregDates();
        private RepShow _RepShow = new RepShow();
        private ReportDocument MainCryRep = new ReportDocument();
        public List<Control> controls;
        private Stock_DataDataContext dbInstance;
        private Rate_DataDataContext dbInstanceRate;
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
        private RibbonBar ribbonBar1;
        private Panel panel1;
        private Bar bar1;
        private ButtonItem buttonItem_ListSal;
        private ButtonItem buttonItem_ListAdd;
        private ButtonItem ToolStripMenuItem_PrintSalary;
        private ButtonItem ToolStripMenuItem_PrintSalaryDet;
        private ButtonItem ToolStripMenuItem_PrintAdd;
        private ButtonItem ToolStripMenuItem_PrintReward;
        protected GroupBox groupBox1;
        protected Label label1;
        private IntegerInput textBox_DayOfMonth;
        protected Label label3;
        private ExpandablePanel expandablePanel_Girds;
        private ExpandablePanel expandablePanel_Emp;
        private ItemPanel itemPanel4;
        private SuperGridControl dataGridViewX_Emp;
        private ExpandablePanel expandablePanel_Job;
        private ItemPanel itemPanel3;
        private SuperGridControl dataGridViewX_Job;
        private ExpandablePanel expandablePanel_Section;
        private ItemPanel itemPanel2;
        private SuperGridControl dataGridViewX_Section;
        private ExpandablePanel expandablePanel_Dept;
        private ItemPanel itemPanel1;
        private SuperGridControl dataGridViewX_Dept;
        private ComboBoxEx comboBox_OrderBy;
        private ComboBoxEx comboBox_Month;
        private ButtonItem ToolStripMenuItem_PrintBankID;
        private ButtonItem ToolStripMenuItem_PrintAllownces;
        private ButtonItem ToolStripMenuItem_PrintDiscount;
        private ButtonItem ToolStripMenuItem_PrintAdvances;
        private Softgroup.NetResize.NetResize netResize1;
        private ButtonX ButClose;
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
        public FrmPrintTrajectorySalaries()
        {
            InitializeComponent();this.Load += langloads;
        }
        private void RibunButtons()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
            {
                buttonItem_ListSal.Text = "المســــي\u0651رات";
                buttonItem_ListAdd.Text = "المستحقات والمستقطعات";
                ToolStripMenuItem_PrintAdd.Text = "تقرير بالإضافــي";
                ToolStripMenuItem_PrintAdvances.Text = "تقرير بالسلــف";
                ToolStripMenuItem_PrintAllownces.Text = "تقرير بــدلات الموظف";
                ToolStripMenuItem_PrintBankID.Text = "تقرير البنك";
                ToolStripMenuItem_PrintDiscount.Text = "تقرير بالخصــم";
                ToolStripMenuItem_PrintReward.Text = "تقرير بالحوافز";
                ToolStripMenuItem_PrintSalary.Text = "مس\u0651ير رواتب الموظفين";
                ToolStripMenuItem_PrintSalaryDet.Text = "تقرير راتـــــــب الموظف ";
                ButClose.Text = "خـــــــــروج";
                expandablePanel_Dept.Text = "الإدارة";
                expandablePanel_Section.Text = "القسم";
                expandablePanel_Job.Text = "الوظيفة";
                expandablePanel_Emp.Text = "الموظف";
                expandablePanel_Girds.TitleText = "على حسب";
                comboBox_Month.WatermarkText = "لا يوجد رواتب مر\u0651حلة";
                Text = "طبــــــاعة الــــرواتب";
            }
            else
            {
                buttonItem_ListSal.Text = "Marches";
                buttonItem_ListAdd.Text = "Dues and Discounts";
                ToolStripMenuItem_PrintAdd.Text = "Add Report";
                ToolStripMenuItem_PrintAdvances.Text = "Advance Report";
                ToolStripMenuItem_PrintAllownces.Text = "Allowances Report";
                ToolStripMenuItem_PrintBankID.Text = "Bank Report";
                ToolStripMenuItem_PrintDiscount.Text = "Discount Report";
                ToolStripMenuItem_PrintReward.Text = "Reward Report";
                ToolStripMenuItem_PrintSalary.Text = "Marche Salary of Employee";
                ToolStripMenuItem_PrintSalaryDet.Text = "Employee Salary Report";
                ButClose.Text = "Close";
                expandablePanel_Dept.Text = "Department";
                expandablePanel_Section.Text = "Section";
                expandablePanel_Job.Text = "Job";
                expandablePanel_Emp.Text = "Employee";
                expandablePanel_Girds.TitleText = "depend on";
                comboBox_Month.WatermarkText = "Not found salaries of Relay";
                Text = "Printable salaries";
            }
        }
        private void FrmPrintTrajectorySalaries_Load(object sender, EventArgs e)
        {
            try
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmPrintTrajectorySalaries));
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
                RibunButtons();
                SuperGridColumns();
                FillCombo();
                FillGrid();
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Load:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void SuperGridColumns()
        {
            dataGridViewX_Emp.PrimaryGrid.Columns[1].HeaderText = ((LangArEn == 0) ? "الموظف" : "Employee");
            dataGridViewX_Dept.PrimaryGrid.Columns[1].HeaderText = ((LangArEn == 0) ? "الادارة" : "Management");
            dataGridViewX_Job.PrimaryGrid.Columns[1].HeaderText = ((LangArEn == 0) ? "الوظيفة" : "Job");
            dataGridViewX_Section.PrimaryGrid.Columns[1].HeaderText = ((LangArEn == 0) ? "القسم" : "Section");
            dataGridViewX_Emp.PrimaryGrid.DefaultVisualStyles.FilterColumnHeaderStyles.Default.Background.Color1 = SystemColors.ActiveCaption;
            dataGridViewX_Dept.PrimaryGrid.DefaultVisualStyles.FilterColumnHeaderStyles.Default.Background.Color1 = SystemColors.ActiveCaption;
            dataGridViewX_Job.PrimaryGrid.DefaultVisualStyles.FilterColumnHeaderStyles.Default.Background.Color1 = SystemColors.ActiveCaption;
            dataGridViewX_Section.PrimaryGrid.DefaultVisualStyles.FilterColumnHeaderStyles.Default.Background.Color1 = SystemColors.ActiveCaption;
            dataGridViewX_Emp.PrimaryGrid.UseAlternateColumnStyle = false;
            dataGridViewX_Dept.PrimaryGrid.UseAlternateColumnStyle = false;
            dataGridViewX_Job.PrimaryGrid.UseAlternateColumnStyle = false;
            dataGridViewX_Section.PrimaryGrid.UseAlternateColumnStyle = false;
        }
        private void FillCombo()
        {
            try
            {
                comboBox_OrderBy.Items.Clear();
                comboBox_OrderBy.Items.Add((LangArEn == 0) ? "رت\u0651ب حسب : الرقــــــم" : "Order By No");
                comboBox_OrderBy.Items.Add((LangArEn == 0) ? "رت\u0651ب حسب : الإســـــــم" : "Order By Name");
                comboBox_OrderBy.Items.Add((LangArEn == 0) ? "رت\u0651ب حسب : قيمة الراتب" : "Order By Salary");
                comboBox_OrderBy.SelectedIndex = 0;
                List<string> listMonth = (from t in db.T_Salaries
                                          orderby t.SalMonth, t.SalYear
                                          where t.SalaryStatus == (bool?)true
                                          select string.Concat(t.SalYear + "/", t.SalMonth)).ToList();
                if (listMonth.Count > 0)
                {
                    comboBox_Month.DataSource = listMonth.Distinct().ToList();
                    comboBox_Month.DisplayMember = "SalYear/SalMonth";
                    comboBox_Month.SelectedIndex = 0;
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("comboBox_Branch_SelectedIndexChanged:", error, enable: true);
                comboBox_Month.DataSource = null;
            }
        }
        private void FillGrid()
        {
            dataGridViewX_Dept.PrimaryGrid.Rows.Clear();
            dataGridViewX_Emp.PrimaryGrid.Rows.Clear();
            dataGridViewX_Job.PrimaryGrid.Rows.Clear();
            dataGridViewX_Section.PrimaryGrid.Rows.Clear();
            GridRow row = new GridRow();
            List<T_Emp> listEmp = db.FillEmps_2(string.Empty).ToList();
            for (int i = 0; i < listEmp.Count; i++)
            {
                row = new GridRow();
                row.Cells.Add(new GridCell(string.Empty));
                row.Cells.Add(new GridCell(string.Empty));
                row.Cells.Add(new GridCell(string.Empty));
                dataGridViewX_Emp.PrimaryGrid.Rows.Add(row);
                dataGridViewX_Emp.PrimaryGrid.GetCell(i, 1).Value = ((LangArEn == 0) ? listEmp[i].NameA.ToString() : listEmp[i].NameE.ToString());
                dataGridViewX_Emp.PrimaryGrid.GetCell(i, 2).Value = listEmp[i].Emp_ID.ToString();
            }
            List<T_Dept> listDept = db.FillDept_2(string.Empty).ToList();
            for (int i = 0; i < listDept.Count; i++)
            {
                row = new GridRow();
                row.Cells.Add(new GridCell(string.Empty));
                row.Cells.Add(new GridCell(string.Empty));
                row.Cells.Add(new GridCell(string.Empty));
                dataGridViewX_Dept.PrimaryGrid.Rows.Add(row);
                dataGridViewX_Dept.PrimaryGrid.GetCell(i, 1).Value = ((LangArEn == 0) ? listDept[i].NameA.ToString() : listDept[i].NameE.ToString());
                dataGridViewX_Dept.PrimaryGrid.GetCell(i, 2).Value = listDept[i].Dept_No.ToString();
            }
            List<T_Section> listSection = db.FillSection_2(string.Empty).ToList();
            for (int i = 0; i < listSection.Count; i++)
            {
                row = new GridRow();
                row.Cells.Add(new GridCell(string.Empty));
                row.Cells.Add(new GridCell(string.Empty));
                row.Cells.Add(new GridCell(string.Empty));
                dataGridViewX_Section.PrimaryGrid.Rows.Add(row);
                dataGridViewX_Section.PrimaryGrid.GetCell(i, 1).Value = ((LangArEn == 0) ? listSection[i].NameA.ToString() : listSection[i].NameE.ToString());
                dataGridViewX_Section.PrimaryGrid.GetCell(i, 2).Value = listSection[i].Section_No.ToString();
            }
            List<T_Job> listJob = db.FillJob_2(string.Empty).ToList();
            for (int i = 0; i < listJob.Count; i++)
            {
                row = new GridRow();
                row.Cells.Add(new GridCell(string.Empty));
                row.Cells.Add(new GridCell(string.Empty));
                row.Cells.Add(new GridCell(string.Empty));
                dataGridViewX_Job.PrimaryGrid.Rows.Add(row);
                dataGridViewX_Job.PrimaryGrid.GetCell(i, 1).Value = ((LangArEn == 0) ? listJob[i].NameA.ToString() : listJob[i].NameE.ToString());
                dataGridViewX_Job.PrimaryGrid.GetCell(i, 2).Value = listJob[i].Job_No.ToString();
            }
        }
        private string[] getDeptNo()
        {
            string[] listSalse = new string[dataGridViewX_Dept.PrimaryGrid.Rows.Count];
            for (int i = 0; i < dataGridViewX_Dept.PrimaryGrid.Rows.Count; i++)
            {
                if (dataGridViewX_Dept.PrimaryGrid.GetCell(i, 0).Value.ToString() == "True")
                {
                    listSalse[i] = dataGridViewX_Dept.PrimaryGrid.GetCell(i, 2).Value.ToString();
                }
            }
            return listSalse;
        }
        private string[] getEmpNo()
        {
            string[] listSalse = new string[dataGridViewX_Emp.PrimaryGrid.Rows.Count];
            for (int i = 0; i < dataGridViewX_Emp.PrimaryGrid.Rows.Count; i++)
            {
                if (dataGridViewX_Emp.PrimaryGrid.GetCell(i, 0).Value.ToString() == "True")
                {
                    listSalse[i] = dataGridViewX_Emp.PrimaryGrid.GetCell(i, 2).Value.ToString();
                }
            }
            return listSalse;
        }
        private string[] getJobNo()
        {
            string[] listSalse = new string[dataGridViewX_Job.PrimaryGrid.Rows.Count];
            for (int i = 0; i < dataGridViewX_Job.PrimaryGrid.Rows.Count; i++)
            {
                if (dataGridViewX_Job.PrimaryGrid.GetCell(i, 0).Value.ToString() == "True")
                {
                    listSalse[i] = dataGridViewX_Job.PrimaryGrid.GetCell(i, 2).Value.ToString();
                }
            }
            return listSalse;
        }
        private string[] getSectionNo()
        {
            string[] listSalse = new string[dataGridViewX_Section.PrimaryGrid.Rows.Count];
            for (int i = 0; i < dataGridViewX_Section.PrimaryGrid.Rows.Count; i++)
            {
                if (dataGridViewX_Section.PrimaryGrid.GetCell(i, 0).Value.ToString() == "True")
                {
                    listSalse[i] = dataGridViewX_Section.PrimaryGrid.GetCell(i, 2).Value.ToString();
                }
            }
            return listSalse;
        }
        private void expandablePanel_Girds_ExpandedChanging(object sender, ExpandedChangeEventArgs e)
        {
            if (!expandablePanel_Girds.ExpandButtonVisible)
            {
                e.Cancel = true;
                return;
            }
            expandablePanel_Emp.Expanded = false;
            expandablePanel_Dept.Expanded = false;
            expandablePanel_Job.Expanded = false;
            expandablePanel_Section.Expanded = false;
        }
        private void expandablePanel_Girds_ExpandedChanged(object sender, ExpandedChangeEventArgs e)
        {
            expandablePanel_Emp.Expanded = false;
            expandablePanel_Dept.Expanded = false;
            expandablePanel_Job.Expanded = false;
            expandablePanel_Section.Expanded = false;
        }
        private void expandablePanel_Dept_ExpandedChanging(object sender, ExpandedChangeEventArgs e)
        {
            if (!expandablePanel_Girds.Expanded)
            {
                e.Cancel = true;
            }
        }
        private void expandablePanel_Emp_ExpandedChanging(object sender, ExpandedChangeEventArgs e)
        {
            if (!expandablePanel_Girds.Expanded)
            {
                e.Cancel = true;
            }
        }
        private void expandablePanel_Job_ExpandedChanging(object sender, ExpandedChangeEventArgs e)
        {
            if (!expandablePanel_Girds.Expanded)
            {
                e.Cancel = true;
            }
        }
        private void expandablePanel_Section_ExpandedChanging(object sender, ExpandedChangeEventArgs e)
        {
            if (!expandablePanel_Girds.Expanded)
            {
                e.Cancel = true;
            }
        }
        private void FrmPrintTrajectorySalaries_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                SendKeys.Send("{Tab}");
            }
        }
        private void FrmPrintTrajectorySalaries_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
        private void ButClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        private bool Validata()
        {
            try
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
                List<T_Salary> Query = db.GetEmpSalary(Convert.ToDateTime(comboBox_Month.Text).ToString("yyyy/MM/dd"));
                if (Query.Count <= 0)
                {
                    MessageBox.Show((LangArEn == 0) ? "لم يتم ترحيل رواتب لهذا الشهر" : "There are no salaries by date you entered", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return false;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        private string GetConditions()
        {
            string QStr = string.Empty;
            string tmpStr = string.Empty;
            string[] GetSql = getDeptNo();
            for (int num2 = 0; num2 < GetSql.Length; num2++)
            {
                if (!string.IsNullOrEmpty(GetSql[num2]))
                {
                    tmpStr = ((!string.IsNullOrEmpty(tmpStr)) ? (tmpStr + " OR ") : (tmpStr + " AND ( "));
                    tmpStr = tmpStr + " ( T_Salary.DeptNo = " + GetSql[num2].Trim() + " ) ";
                }
            }
            QStr += ((tmpStr != string.Empty) ? (tmpStr + " )") : string.Empty);
            tmpStr = string.Empty;
            GetSql = getJobNo();
            for (int num2 = 0; num2 < GetSql.Length; num2++)
            {
                if (!string.IsNullOrEmpty(GetSql[num2]))
                {
                    tmpStr = ((!string.IsNullOrEmpty(tmpStr)) ? (tmpStr + " OR ") : (tmpStr + " AND ( "));
                    tmpStr = tmpStr + " ( T_Salary.Job = " + GetSql[num2].Trim() + " ) ";
                }
            }
            QStr += ((tmpStr != string.Empty) ? (tmpStr + " )") : string.Empty);
            tmpStr = string.Empty;
            GetSql = getEmpNo();
            for (int num2 = 0; num2 < GetSql.Length; num2++)
            {
                if (!string.IsNullOrEmpty(GetSql[num2]))
                {
                    tmpStr = ((!string.IsNullOrEmpty(tmpStr)) ? (tmpStr + " OR ") : (tmpStr + " AND ( "));
                    tmpStr = tmpStr + " ( T_Salary.EmpID = '" + GetSql[num2].Trim() + "' ) ";
                }
            }
            QStr += ((tmpStr != string.Empty) ? (tmpStr + " )") : string.Empty);
            tmpStr = string.Empty;
            GetSql = getSectionNo();
            for (int num2 = 0; num2 < GetSql.Length; num2++)
            {
                if (!string.IsNullOrEmpty(GetSql[num2]))
                {
                    tmpStr = ((!string.IsNullOrEmpty(tmpStr)) ? (tmpStr + " OR ") : (tmpStr + " AND ( "));
                    tmpStr = tmpStr + " ( T_Salary.SectionNo = " + GetSql[num2].Trim() + " ) ";
                }
            }
            QStr += ((tmpStr != string.Empty) ? (tmpStr + " )") : string.Empty);
            tmpStr = string.Empty;
            return QStr;
        }
        private void ToolStripMenuItem_PrintSalary_Click(object sender, EventArgs e)
        {
            VarGeneral.vTitle = ToolStripMenuItem_PrintSalary.Text;
            RepActive(1);
        }
        private void ToolStripMenuItem_PrintSalaryDet_Click(object sender, EventArgs e)
        {
            VarGeneral.vTitle = ToolStripMenuItem_PrintSalaryDet.Text;
            RepActive(2);
        }
        private void ToolStripMenuItem_PrintAdvances_Click(object sender, EventArgs e)
        {
            VarGeneral.vTitle = ToolStripMenuItem_PrintAdvances.Text;
            RepActive(3);
        }
        private void ToolStripMenuItem_PrintReward_Click(object sender, EventArgs e)
        {
            VarGeneral.vTitle = ToolStripMenuItem_PrintReward.Text;
            RepActive(4);
        }
        private void ToolStripMenuItem_PrintDiscount_Click(object sender, EventArgs e)
        {
            VarGeneral.vTitle = ToolStripMenuItem_PrintDiscount.Text;
            RepActive(5);
        }
        private void ToolStripMenuItem_PrintAdd_Click(object sender, EventArgs e)
        {
            VarGeneral.vTitle = ToolStripMenuItem_PrintAdd.Text;
            RepActive(6);
        }
        private void ToolStripMenuItem_PrintAllownces_Click(object sender, EventArgs e)
        {
            VarGeneral.vTitle = ToolStripMenuItem_PrintAllownces.Text;
            RepActive(7);
        }
        private void ToolStripMenuItem_PrintBankID_Click(object sender, EventArgs e)
        {
            VarGeneral.vTitle = ToolStripMenuItem_PrintBankID.Text;
            RepActive(8);
        }
        private void RepActive(int vValue)
        {
            if (Validata())
            {
                string QStr = " Where T_Salary.SalYear = '" + Convert.ToDateTime(comboBox_Month.Text).ToString("yyyy/MM/dd").Substring(0, 4) + "' AND T_Salary.SalMonth = '" + Convert.ToDateTime(comboBox_Month.Text).ToString("yyyy/MM/dd").Substring(5, 2) + "'";
                QStr += GetConditions();
                QStr = ((comboBox_OrderBy.SelectedIndex == 0) ? (QStr + " ORDER BY T_Emp.Emp_No ") : ((comboBox_OrderBy.SelectedIndex != 1) ? (QStr + " ORDER BY T_Salary.Salary ") : (QStr + " ORDER BY T_Emp.NameA ")));
                FrmReportsViewer frm = new FrmReportsViewer();
                frm.Tag = LangArEn;
                frm.SqlWhere = QStr;
                switch (vValue)
                {
                    case 1:
                        frm.Repvalue = "PrintEmpsSal";
                        break;
                    case 2:
                        frm.Repvalue = "PrintEmpsSalDet";
                        break;
                    case 3:
                        frm.Repvalue = "PrintAdvancRep";
                        break;
                    case 4:
                        frm.Repvalue = "PrintRewardRep";
                        break;
                    case 5:
                        frm.Repvalue = "PrintDisSal";
                        break;
                    case 6:
                        frm.Repvalue = "PrintAddSal";
                        break;
                    case 7:
                        frm.Repvalue = "PrintAllownceRep";
                        break;
                    case 8:
                        frm.Repvalue = "PrintBankSal";
                        break;
                }
                VarGeneral.AutoAlarmitms = new List<string>();
                VarGeneral.AutoAlarmitms.Add(string.Empty);
                VarGeneral.AutoAlarmitms[0] = "الشهر : " + comboBox_Month.Text + "    الفرع : " + VarGeneral.BranchNameA;
                frm.TopMost = true;
                frm.ShowDialog();
            }
        }
    }
}
