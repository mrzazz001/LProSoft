//
using CrystalDecisions.CrystalReports.Engine;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.DotNetBar.SuperGrid;
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
    public partial  class FrmRepEmployees : Form
    { void avs(int arln)

{ 
 itemPanel4.Text=   (arln == 0 ? "  itemPanel4  " : "  itemPanel4") ; label2.Text=   (arln == 0 ? "  ترتيب البيانات حسب  " : "  Sort data by") ; ButExit.Text=   (arln == 0 ? "  خـــروج  " : "  Close") ; ButOk.Text=   (arln == 0 ? "  طبـــاعة  " : "  print") ; groupBox1.Text=   (arln == 0 ? "  حسب رقم الموظف  " : "  According to the employee number") ; label1.Text=   (arln == 0 ? "  إلـــــى :  " : "  to:") ; label5.Text=   (arln == 0 ? "  مـــــن :  " : "  from:") ; groupBox_Date.Text=   (arln == 0 ? "  حسب تاريخ التعــيين  " : "  According to the date of appointment") ; label3.Text=   (arln == 0 ? "  مـــــن :  " : "  from:") ; label4.Text=   (arln == 0 ? "  إلـــــى :  " : "  to:") ; Text = "تقرير بيانات الموظفين";this.Text=   (arln == 0 ? "  تقرير بيانات الموظفين  " : "  Employee data report") ;}
        private void langloads(object sender, EventArgs e)
        {
             avs(GeneralM.VarGeneral.currentintlanguage);
        }
   
        public class ColumnDictinaryRep
        {
            public string EmpName = "";
            public string EmpNo = "";
            public string JOb = "";
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
            public string EmpName = "";
            public string EmpNo = "";
            public string CodBank = "";
            public string BankNameA = "";
            public string IDAcc = "";
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
        private T_Branch vBr = new T_Branch();
        private int LangArEn = 0;
        private Dictionary<long, ColumnDictinaryRep> columns_Names_visible = new Dictionary<long, ColumnDictinaryRep>();
        private Dictionary<long, ColumnDictinaryPrintRep> columns_Names_visiblePrinRep = new Dictionary<long, ColumnDictinaryPrintRep>();
        private HijriGreg.HijriGregDates n = new HijriGreg.HijriGregDates();
        private RepShow _RepShow = new RepShow();
        private ReportDocument MainCryRep = new ReportDocument();
        public List<Control> controls;
        private int frmType = 0;
        private Stock_DataDataContext dbInstance;
        private Rate_DataDataContext dbInstanceRate;
        private Dictionary<string, ColumnDictinary> Dir_ButSearch = new Dictionary<string, ColumnDictinary>();
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
                        frm.Repvalue = ((frmType == 0) ? "EmpsRepShort_" : "EmpsRepDocumnts_");
                        frm.Repvalue = ((frmType == 0) ? "EmpsRepShort_" : "EmpsRepDocumnts_");
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
        private ButtonX ButExit;
        private ButtonX ButOk;
        private GroupBox groupBox1;
        private TextBoxX textBox_EmpTo;
        private TextBoxX textBox_EmpFrom;
        private Label label1;
        private Label label5;
        private GroupBox groupBox_Date;
        private MaskedTextBox dateTimeInput_DateAppointmentTo;
        private MaskedTextBox dateTimeInput_DateAppointmentFrom;
        private Label label3;
        private Label label4;
        private Label label2;
        private ExpandablePanel expandablePanel_Girds;
        private ExpandablePanel expandablePanel_Emp;
        private ItemPanel itemPanel4;
        private SuperGridControl dataGridViewX_Emp;
        private ComboBoxEx comboBox_DocTyp;
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
        public FrmRepEmployees(int frmTyp)
        {
            InitializeComponent();this.Load += langloads;
            frmType = frmTyp;
        }
        private void RibunButtons()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                ButOk.Text = ((VarGeneral.GeneralPrinter.nTyp_Setting.Substring(2, 1) == "0") ? "طبـــاعة F5" : "عــــرض F5");
                ButExit.Text = "خـــروج Esc";
                expandablePanel_Girds.TitleText = "على حسب الموظف";
                if (frmType == 0)
                {
                    groupBox_Date.Text = "حسب تاريخ التعــيين";
                    comboBox_DocTyp.Visible = false;
                }
                else
                {
                    groupBox_Date.Text = "حسب نوع الوثيقة";
                    comboBox_DocTyp.Visible = true;
                }
                Text = ((frmType == 0) ? "تقرير الموظفــين" : "وثائق الموظفـــين");
                return;
            }
            ButOk.Text = ((VarGeneral.GeneralPrinter.nTyp_Setting.Substring(2, 1) == "0") ? "Print F5" : "Show F5");
            ButExit.Text = "Close Esc";
            expandablePanel_Girds.TitleText = "depend on Employee";
            if (frmType == 0)
            {
                groupBox_Date.Text = "Appointment Date :";
                comboBox_DocTyp.Visible = false;
                label3.Visible = true;
                dateTimeInput_DateAppointmentFrom.Visible = true;
                label4.Visible = true;
                dateTimeInput_DateAppointmentTo.Visible = true;
            }
            else
            {
                groupBox_Date.Text = "Document Type :";
                comboBox_DocTyp.Visible = true;
                label3.Visible = false;
                dateTimeInput_DateAppointmentFrom.Visible = false;
                label4.Visible = false;
                dateTimeInput_DateAppointmentTo.Visible = false;
            }
            Text = ((LangArEn == 0) ? "Employee Report" : "Employees Documents");
        }
        private void FrmRepEmployees_Load(object sender, EventArgs e)
        {
            try
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmRepEmployees));
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
                SuperGridColumns();
                RibunButtons();
                FillCombo();
                FillGrid();
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Load:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        public void FillCombo()
        {
            comboBox_DocTyp.Items.Clear();
            comboBox_DocTyp.Items.Add((LangArEn == 0) ? "الكل" : "All");
            comboBox_DocTyp.Items.Add((LangArEn == 0) ? "هويات الموظفين" : "Identification Documents");
            comboBox_DocTyp.Items.Add((LangArEn == 0) ? "جوازات سفر الموظفين" : "Passport Documents");
            comboBox_DocTyp.Items.Add((LangArEn == 0) ? "تأمينات الموظفين الصحية" : "Health Insurance Documents");
            comboBox_DocTyp.SelectedIndex = 0;
        }
        private void SuperGridColumns()
        {
            dataGridViewX_Emp.PrimaryGrid.Columns[1].HeaderText = ((LangArEn == 0) ? "" : "");
        }
        private void FillGrid()
        {
            dataGridViewX_Emp.PrimaryGrid.Rows.Clear();
            GridRow row = new GridRow();
            List<T_AccDef> listEmp = db.FillAccDef_2("", 4, 6).ToList();
            for (int i = 0; i < listEmp.Count; i++)
            {
                row = new GridRow();
                row.Cells.Add(new GridCell(""));
                row.Cells.Add(new GridCell(""));
                row.Cells.Add(new GridCell(""));
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
        private void FrmRepEmployees_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                SendKeys.Send("{Tab}");
            }
        }
        private void FrmRepEmployees_KeyDown(object sender, KeyEventArgs e)
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
        private void dateTimeInput_DateAppointmentFrom_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_DateAppointmentFrom.Text = Convert.ToDateTime(dateTimeInput_DateAppointmentFrom.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_DateAppointmentFrom.Text = "";
            }
        }
        private void dateTimeInput_DateAppointmentTo_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_DateAppointmentTo.Text = Convert.ToDateTime(dateTimeInput_DateAppointmentTo.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_DateAppointmentTo.Text = "";
            }
        }
        private void ButOk_Click(object sender, EventArgs e)
        {
            try
            {
                VarGeneral.IsGeneralUsed = true;
                FrmReportsViewer frm = new FrmReportsViewer();
                frm.Repvalue = ((frmType == 0) ? "EmpsRepShort_" : "EmpsRepDocumnts_");
                frm.Tag = LangArEn;
                frm.Repvalue = ((frmType == 0) ? "EmpsRepShort_" : "EmpsRepDocumnts_");
                VarGeneral.EmpDocType = comboBox_DocTyp.SelectedIndex;
                frm.SqlWhere = GetSqlWhere();
                VarGeneral.vTitle = Text;
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
        private string GetSqlWhere()
        {
            string tmpStr = "";
            string QStr = "";
            string[] GetSql = getEmpNo();
            for (int num2 = 0; num2 < GetSql.Length; num2++)
            {
                if (!string.IsNullOrEmpty(GetSql[num2]))
                {
                    tmpStr = ((!string.IsNullOrEmpty(tmpStr)) ? (tmpStr + " OR ") : (tmpStr + " AND ( "));
                    tmpStr = tmpStr + " ( AccDef_No = '" + GetSql[num2].Trim() + "' ) ";
                }
            }
            QStr += ((tmpStr != "") ? (tmpStr + " )") : "");
            tmpStr = "";
            if (!string.IsNullOrEmpty(textBox_EmpFrom.Text))
            {
                QStr = QStr + " AND ( T_AccDef.AccDef_No >= '" + textBox_EmpFrom.Tag.ToString().Trim() + "' ) ";
            }
            if (!string.IsNullOrEmpty(textBox_EmpTo.Text))
            {
                QStr = QStr + " AND ( T_AccDef.AccDef_No <= '" + textBox_EmpTo.Tag.ToString().Trim() + "' ) ";
            }
            if (dateTimeInput_DateAppointmentFrom.Text != "    /  /" && dateTimeInput_DateAppointmentFrom.Text.Length == 10)
            {
                QStr = QStr + " AND ( T_AccDef.DateAppointment >= '" + Convert.ToDateTime(dateTimeInput_DateAppointmentFrom.Text).ToString("yyyy/MM/dd") + "' ) ";
            }
            if (dateTimeInput_DateAppointmentTo.Text != "    /  /" && dateTimeInput_DateAppointmentTo.Text.Length == 10)
            {
                QStr = QStr + " AND ( T_AccDef.DateAppointment <= '" + Convert.ToDateTime(dateTimeInput_DateAppointmentTo.Text).ToString("yyyy/MM/dd") + "' ) ";
            }
            return QStr + " AND T_AccDef.AccCat = 6 AND T_AccDef.Lev = 4 ORDER BY T_AccDef.AccDef_No";
        }
        private void textBox_EmpFrom_ButtonCustomClick(object sender, EventArgs e)
        {
            try
            {
                Dir_ButSearch.Add("AccDef_No", new ColumnDictinary("الرقم ", " No", ifDefault: true, ""));
                Dir_ButSearch.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, ""));
                Dir_ButSearch.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, ""));
                Dir_ButSearch.Add("AccDef_ID", new ColumnDictinary(" ", " ", ifDefault: false, ""));
                FrmSearch frm = new FrmSearch();
                frm.Tag = LangArEn;
                ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = Dir_ButSearch;
                foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
                {
                    frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, ""));
                }
                VarGeneral.SFrmTyp = "T_AccDef_Suppliers";
                VarGeneral.AccTyp = 6;
                frm.TopMost = true;
                frm.ShowDialog();
                if (frm.SerachNo != "")
                {
                    textBox_EmpFrom.Text = ((LangArEn == 0) ? db.StockAccDefs(int.Parse(frm.Serach_No)).Arb_Des : db.StockAccDefs(int.Parse(frm.Serach_No)).Eng_Des);
                    textBox_EmpFrom.Tag = db.StockAccDefs(int.Parse(frm.Serach_No)).AccDef_No;
                }
                else
                {
                    textBox_EmpFrom.Text = "";
                    textBox_EmpFrom.Tag = "";
                }
                Dir_ButSearch.Clear();
            }
            catch (Exception error)
            {
                textBox_EmpFrom.Text = "";
                textBox_EmpFrom.Tag = "";
                VarGeneral.DebLog.writeLog("button_SrchEmp_Click:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void textBox_EmpTo_ButtonCustomClick(object sender, EventArgs e)
        {
            try
            {
                Dir_ButSearch.Add("AccDef_No", new ColumnDictinary("الرقم ", " No", ifDefault: true, ""));
                Dir_ButSearch.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, ""));
                Dir_ButSearch.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, ""));
                Dir_ButSearch.Add("AccDef_ID", new ColumnDictinary(" ", " ", ifDefault: false, ""));
                FrmSearch frm = new FrmSearch();
                frm.Tag = LangArEn;
                ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = Dir_ButSearch;
                foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
                {
                    frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, ""));
                }
                VarGeneral.SFrmTyp = "T_AccDef_Suppliers";
                VarGeneral.AccTyp = 6;
                frm.TopMost = true;
                frm.ShowDialog();
                if (frm.SerachNo != "")
                {
                    textBox_EmpTo.Text = ((LangArEn == 0) ? db.StockAccDefs(int.Parse(frm.Serach_No)).Arb_Des : db.StockAccDefs(int.Parse(frm.Serach_No)).Eng_Des);
                    textBox_EmpTo.Tag = db.StockAccDefs(int.Parse(frm.Serach_No)).AccDef_No;
                }
                else
                {
                    textBox_EmpTo.Text = "";
                    textBox_EmpTo.Tag = "";
                }
                Dir_ButSearch.Clear();
            }
            catch (Exception error)
            {
                textBox_EmpTo.Text = "";
                textBox_EmpTo.Tag = "";
                VarGeneral.DebLog.writeLog("button_SrchEmp_Click:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void ButExit_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void dateTimeInput_DateAppointmentFrom_Click(object sender, EventArgs e)
        {
            dateTimeInput_DateAppointmentFrom.SelectAll();
        }
        private void dateTimeInput_DateAppointmentTo_Click(object sender, EventArgs e)
        {
            dateTimeInput_DateAppointmentTo.SelectAll();
        }
    }
}
