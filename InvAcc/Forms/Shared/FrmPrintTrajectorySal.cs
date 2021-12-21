using CrystalDecisions.CrystalReports.Engine;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.DotNetBar.SuperGrid;
using DevComponents.Editors;
using ProShared.GeneralM;using ProShared;
using ProShared.Stock_Data;
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
    public partial  class FrmPrintTrajectorySal : Form
    { void avs(int arln)

{ 
 itemPanel4.Text=   (arln == 0 ? "  itemPanel4  " : "  itemPanel4") ; bar1.Text=   (arln == 0 ? "  bar1  " : "  bar1") ; button_Close.Text=   (arln == 0 ? "  خـــروج  " : "  Close") ; Button_OK.Text=   (arln == 0 ? "  طباعة  " : "  Print") ; label1.Text=   (arln == 0 ? "  تقرير رواتب شهــر  " : "  Monthly salary report") ; label3.Text=   (arln == 0 ? "  عدد الأيام :  " : "  The number of days :") ; Text = "طبــــــاعة الــــرواتب";this.Text=   (arln == 0 ? "  طبــــــاعة الــــرواتب  " : "  Payroll printing") ;}
        private void langloads(object sender, EventArgs e)
        {
              avs(ProShared. GeneralM.VarGeneral.currentintlanguage);;
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
        private Bar bar1;
        protected GroupBox groupBox1;
        protected Label label1;
        private IntegerInput textBox_DayOfMonth;
        protected Label label3;
        private ExpandablePanel expandablePanel_Girds;
        private ExpandablePanel expandablePanel_Emp;
        private ItemPanel itemPanel4;
        private SuperGridControl dataGridViewX_Emp;
        private ComboBoxEx comboBox_OrderBy;
        private ComboBoxEx comboBox_Month;
        private ButtonX button_Close;
        private ButtonX Button_OK;
        private T_Branch vBr = new T_Branch();
        private int LangArEn = 0;
        private int vTyp_ = 0;
        private Dictionary<long, ColumnDictinaryRep> columns_Names_visible = new Dictionary<long, ColumnDictinaryRep>();
        private Dictionary<long, ColumnDictinaryPrintRep> columns_Names_visiblePrinRep = new Dictionary<long, ColumnDictinaryPrintRep>();
        private HijriGreg.HijriGregDates n = new HijriGreg.HijriGregDates();
        private RepShow _RepShow = new RepShow();
        private ReportDocument MainCryRep = new ReportDocument();
        public List<Control> controls;
        private Stock_DataDataContext dbInstance;
        private Rate_DataDataContext dbInstanceRate;
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
        public FrmPrintTrajectorySal(int _vTp)
        {
            InitializeComponent();this.Load += langloads;
            vTyp_ = _vTp;
        }
        private void RibunButtons()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
            {
                expandablePanel_Emp.Text = "الموظف";
                expandablePanel_Girds.TitleText = "على حسب الموظف";
                button_Close.Text = "خـــروج";
                Button_OK.Text = "طباعة";
                if (vTyp_ == 0)
                {
                    comboBox_Month.WatermarkText = "لا يوجد رواتب مر\u0651حلة";
                    Text = "طبــــــاعة الــــرواتب";
                }
                else if (vTyp_ == 1)
                {
                    Text = "الحسابات ومسي\u0651ر الرواتب";
                    comboBox_Month.WatermarkText = "لا يوجد قيود لرواتب صادرة";
                    expandablePanel_Girds.Visible = false;
                    label1.Text = "القيود المحاسبية للرواتب الصادرة";
                    base.Width -= 30;
                    groupBox1.Location = new Point(9, 8);
                    label1.Location = new Point(31, 55);
                }
                else if (vTyp_ == 2)
                {
                    Text = "الحسابات ومسي\u0651ر الرواتب";
                    comboBox_Month.WatermarkText = "لا يوجد قيود لرواتب مر\u0651حلة";
                    expandablePanel_Girds.Visible = false;
                    label1.Text = "القيود المحاسبية للرواتب المر\u0651حلة";
                    base.Width -= 30;
                    groupBox1.Location = new Point(9, 8);
                    label1.Location = new Point(31, 55);
                }
            }
            else
            {
                button_Close.Text = "Close";
                expandablePanel_Emp.Text = "Employee";
                expandablePanel_Girds.TitleText = "depend on Employee";
                Button_OK.Text = "Print";
                if (vTyp_ == 0)
                {
                    comboBox_Month.WatermarkText = "Not found salaries of Relay";
                    Text = "Printable salaries";
                }
                else if (vTyp_ == 1)
                {
                    Text = "Accounting and Salaries";
                    comboBox_Month.WatermarkText = string.Empty;
                    expandablePanel_Girds.Visible = false;
                    label1.Text = "Gaid ccounting for salaries issued";
                    base.Width -= 30;
                    groupBox1.Location = new Point(9, 8);
                    label1.Location = new Point(31, 55);
                }
                else if (vTyp_ == 2)
                {
                    Text = "Accounting and Salaries";
                    comboBox_Month.WatermarkText = string.Empty;
                    expandablePanel_Girds.Visible = false;
                    label1.Text = "Gaid ccounting for salaries Relayed";
                    base.Width -= 30;
                    groupBox1.Location = new Point(9, 8);
                    label1.Location = new Point(31, 55);
                }
            }
        }
        private void FrmPrintTrajectorySal_Load(object sender, EventArgs e)
        {
            try
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmPrintTrajectorySal));
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
            dataGridViewX_Emp.PrimaryGrid.Columns[1].HeaderText = ((LangArEn == 0) ? string.Empty : string.Empty);
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
                if (vTyp_ == 0)
                {
                    List<string> listMonth = (from t in db.T_Sals
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
                else if (vTyp_ == 1)
                {
                    List<string> listMonth = (from t in db.T_Sals
                                              orderby t.SalMonth, t.SalYear
                                              where t.GadeId2.HasValue
                                              select string.Concat(t.SalYear + "/", t.SalMonth)).ToList();
                    if (listMonth.Count > 0)
                    {
                        comboBox_Month.DataSource = listMonth.Distinct().ToList();
                        comboBox_Month.DisplayMember = "SalYear/SalMonth";
                        comboBox_Month.SelectedIndex = 0;
                    }
                }
                else
                {
                    List<string> listMonth = (from t in db.T_Sals
                                              orderby t.SalMonth, t.SalYear
                                              where t.GadeId.HasValue
                                              select string.Concat(t.SalYear + "/", t.SalMonth)).ToList();
                    if (listMonth.Count > 0)
                    {
                        comboBox_Month.DataSource = listMonth.Distinct().ToList();
                        comboBox_Month.DisplayMember = "SalYear/SalMonth";
                        comboBox_Month.SelectedIndex = 0;
                    }
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
            dataGridViewX_Emp.PrimaryGrid.Rows.Clear();
            GridRow row = new GridRow();
            List<T_AccDef> listEmp = db.FillAccDef_2(string.Empty, 4, 6).ToList();
            for (int i = 0; i < listEmp.Count; i++)
            {
                row = new GridRow();
                row.Cells.Add(new GridCell(string.Empty));
                row.Cells.Add(new GridCell(string.Empty));
                row.Cells.Add(new GridCell(string.Empty));
                dataGridViewX_Emp.PrimaryGrid.Rows.Add(row);
                dataGridViewX_Emp.PrimaryGrid.GetCell(i, 0).Value = false;
                dataGridViewX_Emp.PrimaryGrid.GetCell(i, 1).Value = ((LangArEn == 0) ? listEmp[i].Arb_Des.ToString() : listEmp[i].Eng_Des.ToString());
                dataGridViewX_Emp.PrimaryGrid.GetCell(i, 2).Value = listEmp[i].AccDef_No.ToString();
            }
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
        private void expandablePanel_Girds_ExpandedChanging(object sender, ExpandedChangeEventArgs e)
        {
            if (!expandablePanel_Girds.ExpandButtonVisible)
            {
                e.Cancel = true;
            }
            else
            {
                expandablePanel_Emp.Expanded = false;
            }
        }
        private void expandablePanel_Girds_ExpandedChanged(object sender, ExpandedChangeEventArgs e)
        {
            if (!expandablePanel_Girds.Expanded)
            {
                expandablePanel_Emp.Expanded = false;
            }
            else
            {
                expandablePanel_Emp.Expanded = true;
            }
        }
        private void expandablePanel_Emp_ExpandedChanging(object sender, ExpandedChangeEventArgs e)
        {
            if (!expandablePanel_Girds.Expanded)
            {
                e.Cancel = true;
            }
        }
        private void FrmPrintTrajectorySal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                SendKeys.Send("{Tab}");
            }
        }
        private void FrmPrintTrajectorySal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
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
                List<T_Sal> Query = db.GetEmpSal(Convert.ToDateTime(comboBox_Month.Text).ToString("yyyy/MM/dd"));
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
            string[] GetSql = getEmpNo();
            for (int num2 = 0; num2 < GetSql.Length; num2++)
            {
                if (!string.IsNullOrEmpty(GetSql[num2]))
                {
                    tmpStr = ((!string.IsNullOrEmpty(tmpStr)) ? (tmpStr + " OR ") : (tmpStr + " AND ( "));
                    tmpStr = tmpStr + " ( T_Sal.EmpID = '" + GetSql[num2].Trim() + "' ) ";
                }
            }
            QStr += ((tmpStr != string.Empty) ? (tmpStr + " )") : string.Empty);
            tmpStr = string.Empty;
            return QStr;
        }
        private void RepActive(int vValue)
        {
            if (!Validata())
            {
                return;
            }
            if (vTyp_ == 0)
            {
                string QStr = " Where T_Sal.SalYear = '" + Convert.ToDateTime(comboBox_Month.Text).ToString("yyyy/MM/dd").Substring(0, 4) + "' AND T_Sal.SalMonth = '" + Convert.ToDateTime(comboBox_Month.Text).ToString("yyyy/MM/dd").Substring(5, 2) + "'";
                QStr += GetConditions();
                QStr += " ORDER BY T_Sal.EmpID ";
                FrmReportsViewer frm = new FrmReportsViewer();
                frm.Tag = LangArEn;
                frm.SqlWhere = QStr;
                frm.Repvalue = "PrintEmpsSal_";
                VarGeneral.AutoAlarmitms = new List<string>();
                VarGeneral.AutoAlarmitms.Add(string.Empty);
                VarGeneral.AutoAlarmitms[0] = ((LangArEn == 0) ? ("رواتب شهر : " + comboBox_Month.Text) : ("Salary of Month : " + comboBox_Month.Text));
                VarGeneral.vTitle = Text;
                frm.TopMost = true;
                frm.ShowDialog();
                return;
            }
            if (vTyp_ == 1)
            {
                try
                {
                    List<T_Sal> newdata = db.GetEmpSal(comboBox_Month.Text);
                    if (newdata.Count <= 0 || !newdata.FirstOrDefault().GadeId2.HasValue)
                    {
                        return;
                    }
                    RepShow _RepShow = new RepShow();
                    _RepShow.Tables = "T_GDDET LEFT OUTER JOIN T_GDHEAD ON T_GDDET.gdID = T_GDHEAD.gdhead_ID LEFT OUTER JOIN T_INVSETTING ON T_GDHEAD.gdTyp = T_INVSETTING.InvID  LEFT OUTER JOIN T_Curency ON T_GDHEAD.CurTyp = T_Curency.Curency_ID LEFT OUTER JOIN T_CstTbl ON T_GDHEAD.gdCstNo = T_CstTbl.Cst_ID LEFT OUTER JOIN T_Mndob ON T_GDHEAD.gdMnd = T_Mndob.Mnd_ID LEFT OUTER JOIN T_AccDef ON T_GDDET.AccNo = T_AccDef.AccDef_No LEFT OUTER JOIN T_SYSSETTING ON T_GDHEAD.CompanyID = T_SYSSETTING.SYSSETTING_ID ";
                    string Fields = " CASE WHEN T_GDDET.gdValue > 0 THEN T_GDDET.gdValue ELSE 0 END as DebitBala , CASE WHEN T_GDDET.gdValue < 0 THEN Abs(T_GDDET.gdValue) ELSE 0 END as CreditBala , T_Curency.Arb_Des as Arb_Cur , T_Curency.Eng_Des as Eng_Cur , T_CstTbl.Arb_Des as CostCenteNm , T_Mndob.Arb_Des as MndNm , T_GDHEAD.* , T_GDDET.AccNo as AccDef_No," + ((LangArEn == 0) ? "T_AccDef.Arb_Des as AccDefNm" : "T_AccDef.Eng_Des as AccDefNm") + "," + ((LangArEn == 0) ? "T_GDDET.gdDes as gdDesDet" : "T_GDDET.gdDesE as gdDesDet") + ",T_SYSSETTING.LogImg";
                    VarGeneral.HeaderRep[0] = Text;
                    VarGeneral.HeaderRep[1] = string.Empty;
                    VarGeneral.HeaderRep[2] = string.Empty;
                    _RepShow.Rule = " where T_GDHEAD.gdLok = 0 AND T_GDHEAD.gdhead_ID = " + newdata.FirstOrDefault().GadeId2 + " Order by T_GDDET.Lin ";
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
                    if (VarGeneral.RepData.Tables[0].Rows.Count != 0)
                    {
                        try
                        {
                            FrmReportsViewer frm = new FrmReportsViewer();
                            frm.Tag = LangArEn;
                            frm.Repvalue = "RepGaid";
                            VarGeneral.vTitle = Text;
                            frm.TopMost = true;
                            frm.ShowDialog();
                        }
                        catch (Exception error4)
                        {
                            VarGeneral.DebLog.writeLog("buttonItem_Print_Click:", error4, enable: true);
                            MessageBox.Show(error4.Message);
                        }
                    }
                }
                catch (Exception error4)
                {
                    MessageBox.Show((LangArEn == 0) ? "عفوا .. لا يوجد بيانات لعرضها في التقرير " : "Sorry .. there is no data to display in the report ", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    VarGeneral.DebLog.writeLog("buttonItem_Print_Click:", error4, enable: true);
                    MessageBox.Show(error4.Message);
                }
                return;
            }
            try
            {
                List<T_Sal> newdata = db.GetEmpSal(comboBox_Month.Text);
                if (newdata.Count <= 0 || !newdata.FirstOrDefault().GadeId.HasValue)
                {
                    return;
                }
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = "T_GDDET LEFT OUTER JOIN T_GDHEAD ON T_GDDET.gdID = T_GDHEAD.gdhead_ID LEFT OUTER JOIN T_INVSETTING ON T_GDHEAD.gdTyp = T_INVSETTING.InvID  LEFT OUTER JOIN T_Curency ON T_GDHEAD.CurTyp = T_Curency.Curency_ID LEFT OUTER JOIN T_CstTbl ON T_GDHEAD.gdCstNo = T_CstTbl.Cst_ID LEFT OUTER JOIN T_Mndob ON T_GDHEAD.gdMnd = T_Mndob.Mnd_ID LEFT OUTER JOIN T_AccDef ON T_GDDET.AccNo = T_AccDef.AccDef_No LEFT OUTER JOIN T_SYSSETTING ON T_GDHEAD.CompanyID = T_SYSSETTING.SYSSETTING_ID ";
                string Fields = " CASE WHEN T_GDDET.gdValue > 0 THEN T_GDDET.gdValue ELSE 0 END as DebitBala , CASE WHEN T_GDDET.gdValue < 0 THEN Abs(T_GDDET.gdValue) ELSE 0 END as CreditBala , T_Curency.Arb_Des as Arb_Cur , T_Curency.Eng_Des as Eng_Cur , T_CstTbl.Arb_Des as CostCenteNm , T_Mndob.Arb_Des as MndNm , T_GDHEAD.* , T_GDDET.AccNo as AccDef_No," + ((LangArEn == 0) ? "T_AccDef.Arb_Des as AccDefNm" : "T_AccDef.Eng_Des as AccDefNm") + "," + ((LangArEn == 0) ? "T_GDDET.gdDes as gdDesDet" : "T_GDDET.gdDesE as gdDesDet") + ",T_SYSSETTING.LogImg";
                VarGeneral.HeaderRep[0] = Text;
                VarGeneral.HeaderRep[1] = string.Empty;
                VarGeneral.HeaderRep[2] = string.Empty;
                _RepShow.Rule = " where T_GDHEAD.gdLok = 0 AND T_GDHEAD.gdhead_ID = " + newdata.FirstOrDefault().GadeId + " Order by T_GDDET.Lin ";
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
                if (VarGeneral.RepData.Tables[0].Rows.Count != 0)
                {
                    try
                    {
                        FrmReportsViewer frm = new FrmReportsViewer();
                        frm.Tag = LangArEn;
                        frm.Repvalue = "RepGaid";
                        VarGeneral.vTitle = Text;
                        frm.TopMost = true;
                        frm.ShowDialog();
                    }
                    catch (Exception error4)
                    {
                        VarGeneral.DebLog.writeLog("buttonItem_Print_Click:", error4, enable: true);
                        MessageBox.Show(error4.Message);
                    }
                }
            }
            catch (Exception error4)
            {
                MessageBox.Show((LangArEn == 0) ? "عفوا .. لا يوجد بيانات لعرضها في التقرير " : "Sorry .. there is no data to display in the report ", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                VarGeneral.DebLog.writeLog("buttonItem_Print_Click:", error4, enable: true);
                MessageBox.Show(error4.Message);
            }
        }
        private void Button_OK_Click(object sender, EventArgs e)
        {
            RepActive(1);
        }
        private void button_Close_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
