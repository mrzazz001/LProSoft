//
using CrystalDecisions.CrystalReports.Engine;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.DotNetBar.SuperGrid;
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
    public partial  class FrmRepCars : Form
    { void avs(int arln)

{ 
}
        private void langloads(object sender, EventArgs e)
        {
              avs(ProShared. GeneralM.VarGeneral.currentintlanguage);;
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
                        frm.Repvalue = "CarRep";
                        frm.Repvalue = "CarRep";
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
        private ExpandablePanel expandablePanel_Girds;
        private ExpandablePanel expandablePanel_CarsType;
        private ItemPanel itemPanel2;
        private SuperGridControl dataGridViewX_CarType;
        private ExpandablePanel expandablePanel_Cars;
        private ItemPanel itemPanel1;
        private SuperGridControl dataGridViewX_Cars;
        private GroupBox groupBox1;
        private TextBoxX TextBox_CarsNoTo;
        private Label label1;
        private Label label5;
        private TextBoxX TextBox_CarsNoFrom;
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
        private Dictionary<string, ColumnDictinary> Dir_ButSearch = new Dictionary<string, ColumnDictinary>();
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
        public FrmRepCars()
        {
            InitializeComponent();this.Load += langloads;
        }
        private void RibunButtons()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                ButOk.Text = ((VarGeneral.GeneralPrinter.ISdirectPrinting) ? "طبـــاعة F5" : "عــــرض F5");
                ButExit.Text = "خـــروج Esc";
                expandablePanel_Cars.Text = "السيــارات";
                expandablePanel_CarsType.Text = "أنواع السيــارات";
                expandablePanel_Girds.TitleText = "على حسب";
                Text = "تقرير السيــــارات";
            }
            else
            {
                ButOk.Text = ((VarGeneral.GeneralPrinter.ISdirectPrinting) ? "Print F5" : "Show F5");
                ButExit.Text = "Close Esc";
                expandablePanel_Cars.Text = "Cars";
                expandablePanel_CarsType.Text = "Car Type";
                expandablePanel_Girds.TitleText = "depend on";
                Text = "Car Report";
            }
        }
        private void FrmRepCars_Load(object sender, EventArgs e)
        {
            try
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmRepCars));
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
            dataGridViewX_Cars.PrimaryGrid.Columns[1].HeaderText = ((LangArEn == 0) ? "السيارات" : "Cars");
            dataGridViewX_CarType.PrimaryGrid.Columns[1].HeaderText = ((LangArEn == 0) ? "أنواع السيارات" : "Cart Type");
        }
        private void FillGrid()
        {
            dataGridViewX_Cars.PrimaryGrid.Rows.Clear();
            dataGridViewX_CarType.PrimaryGrid.Rows.Clear();
            GridRow row = new GridRow();
            List<T_CarTyp> listCarType = db.FillCarTyp_2("").ToList();
            for (int i = 0; i < listCarType.Count; i++)
            {
                row = new GridRow();
                row.Cells.Add(new GridCell(""));
                row.Cells.Add(new GridCell(""));
                row.Cells.Add(new GridCell(""));
                dataGridViewX_CarType.PrimaryGrid.Rows.Add(row);
                dataGridViewX_CarType.PrimaryGrid.GetCell(i, 1).Value = ((LangArEn == 0) ? listCarType[i].NameA.ToString() : listCarType[i].NameE.ToString());
                dataGridViewX_CarType.PrimaryGrid.GetCell(i, 2).Value = listCarType[i].CarTyp_No.ToString();
            }
            List<T_Car> listCarS = db.FillCars_2("").ToList();
            for (int i = 0; i < listCarS.Count; i++)
            {
                row = new GridRow();
                row.Cells.Add(new GridCell(""));
                row.Cells.Add(new GridCell(""));
                row.Cells.Add(new GridCell(""));
                dataGridViewX_Cars.PrimaryGrid.Rows.Add(row);
                dataGridViewX_Cars.PrimaryGrid.GetCell(i, 1).Value = ((LangArEn == 0) ? listCarS[i].NameA.ToString() : listCarS[i].NameE.ToString());
                dataGridViewX_Cars.PrimaryGrid.GetCell(i, 2).Value = listCarS[i].Car_No.ToString();
            }
        }
        private string[] getCartTypeNo()
        {
            string[] listSalse = new string[dataGridViewX_CarType.PrimaryGrid.Rows.Count];
            for (int i = 0; i < dataGridViewX_CarType.PrimaryGrid.Rows.Count; i++)
            {
                if (dataGridViewX_CarType.PrimaryGrid.GetCell(i, 0).Value.ToString() == "True")
                {
                    listSalse[i] = dataGridViewX_CarType.PrimaryGrid.GetCell(i, 2).Value.ToString();
                }
            }
            return listSalse;
        }
        private string[] getCarsNo()
        {
            string[] listSalse = new string[dataGridViewX_Cars.PrimaryGrid.Rows.Count];
            for (int i = 0; i < dataGridViewX_Cars.PrimaryGrid.Rows.Count; i++)
            {
                if (dataGridViewX_Cars.PrimaryGrid.GetCell(i, 0).Value.ToString() == "True")
                {
                    listSalse[i] = dataGridViewX_Cars.PrimaryGrid.GetCell(i, 2).Value.ToString();
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
            expandablePanel_Cars.Expanded = false;
            expandablePanel_CarsType.Expanded = false;
        }
        private void expandablePanel_Girds_ExpandedChanged(object sender, ExpandedChangeEventArgs e)
        {
            expandablePanel_Cars.Expanded = false;
            expandablePanel_CarsType.Expanded = false;
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
        private void FrmRepCars_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                SendKeys.Send("{Tab}");
            }
        }
        private void FrmRepCars_KeyDown(object sender, KeyEventArgs e)
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
        private void ButOk_Click(object sender, EventArgs e)
        {
            try
            {
                VarGeneral.IsGeneralUsed = true;
                FrmReportsViewer frm = new FrmReportsViewer();
                frm.Repvalue = "CarRep";
                frm.Tag = LangArEn;
                frm.Repvalue = "CarRep";
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
            string QStr = "";
            string tmpStr = "";
            string[] GetSql = getCartTypeNo();
            for (int num2 = 0; num2 < GetSql.Length; num2++)
            {
                if (!string.IsNullOrEmpty(GetSql[num2]))
                {
                    tmpStr = ((!string.IsNullOrEmpty(tmpStr)) ? (tmpStr + " OR ") : (tmpStr + " AND ( "));
                    tmpStr = tmpStr + " ( CarType = " + GetSql[num2].Trim() + " ) ";
                }
            }
            QStr += ((tmpStr != "") ? (tmpStr + " )") : "");
            tmpStr = "";
            GetSql = getCarsNo();
            for (int num2 = 0; num2 < GetSql.Length; num2++)
            {
                if (!string.IsNullOrEmpty(GetSql[num2]))
                {
                    tmpStr = ((!string.IsNullOrEmpty(tmpStr)) ? (tmpStr + " OR ") : (tmpStr + " AND ( "));
                    tmpStr = tmpStr + " ( Car_No = " + GetSql[num2].Trim() + " ) ";
                }
            }
            QStr += ((tmpStr != "") ? (tmpStr + " )") : "");
            if (!string.IsNullOrEmpty(TextBox_CarsNoFrom.Text))
            {
                QStr = QStr + " AND ( [Car_No] >= '" + TextBox_CarsNoFrom.Tag.ToString().Trim() + "' ) ";
            }
            if (!string.IsNullOrEmpty(TextBox_CarsNoTo.Text))
            {
                QStr = QStr + " AND ( [Car_No] <= '" + TextBox_CarsNoTo.Tag.ToString().Trim() + "' ) ";
            }
            return QStr;
        }
        private void ButExit_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void comboBox_CarsNo_ButtonCustomClick(object sender, EventArgs e)
        {
            try
            {
                Dir_ButSearch.Add("Car_No", new ColumnDictinary("رقم السيارة", "Car No", ifDefault: true, ""));
                Dir_ButSearch.Add("NameA", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, ""));
                Dir_ButSearch.Add("NameE", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, ""));
                Dir_ButSearch.Add("Note", new ColumnDictinary("الملاحظات", "Note", ifDefault: false, ""));
                FrmSearch frm = new FrmSearch();
                frm.Tag = LangArEn;
                ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = Dir_ButSearch;
                foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
                {
                    frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, ""));
                }
                VarGeneral.SFrmTyp = "T_Car";
                VarGeneral.FrmEmpStat = true;
                frm.TopMost = true;
                frm.ShowDialog();
                if (frm.SerachNo != "")
                {
                    T_Car q = db.CarsEmp(int.Parse(frm.Serach_No));
                    TextBox_CarsNoFrom.Text = ((LangArEn == 0) ? (q.Car_No + " - " + q.NameA) : (q.Car_No + " - " + q.NameE));
                    TextBox_CarsNoFrom.Tag = q.Car_No;
                }
                else
                {
                    TextBox_CarsNoFrom.Text = "";
                    TextBox_CarsNoFrom.Tag = "";
                }
                Dir_ButSearch.Clear();
            }
            catch (Exception error)
            {
                TextBox_CarsNoFrom.Text = "";
                TextBox_CarsNoFrom.Tag = "";
                VarGeneral.DebLog.writeLog("button_SrchEmp_Click:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void comboBox_CarsNoTo_ButtonCustomClick(object sender, EventArgs e)
        {
            try
            {
                Dir_ButSearch.Add("Car_No", new ColumnDictinary("رقم السيارة", "Car No", ifDefault: true, ""));
                Dir_ButSearch.Add("NameA", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, ""));
                Dir_ButSearch.Add("NameE", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, ""));
                Dir_ButSearch.Add("Note", new ColumnDictinary("الملاحظات", "Note", ifDefault: false, ""));
                FrmSearch frm = new FrmSearch();
                frm.Tag = LangArEn;
                ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = Dir_ButSearch;
                foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
                {
                    frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, ""));
                }
                VarGeneral.SFrmTyp = "T_Car";
                VarGeneral.FrmEmpStat = true;
                frm.TopMost = true;
                frm.ShowDialog();
                if (frm.SerachNo != "")
                {
                    T_Car q = db.CarsEmp(int.Parse(frm.Serach_No));
                    TextBox_CarsNoTo.Text = ((LangArEn == 0) ? (q.Car_No + " - " + q.NameA) : (q.Car_No + " - " + q.NameE));
                    TextBox_CarsNoTo.Tag = q.Car_No;
                }
                else
                {
                    TextBox_CarsNoTo.Text = "";
                    TextBox_CarsNoTo.Tag = "";
                }
                Dir_ButSearch.Clear();
            }
            catch (Exception error)
            {
                TextBox_CarsNoTo.Text = "";
                TextBox_CarsNoTo.Tag = "";
                VarGeneral.DebLog.writeLog("button_SrchEmp_Click:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void expandablePanel_Cars_ExpandedChanging(object sender, ExpandedChangeEventArgs e)
        {
            if (!expandablePanel_Girds.Expanded)
            {
                e.Cancel = true;
            }
        }
        private void expandablePanel_CarsType_ExpandedChanging(object sender, ExpandedChangeEventArgs e)
        {
            if (!expandablePanel_Girds.Expanded)
            {
                e.Cancel = true;
            }
        }
    }
}
