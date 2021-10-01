using DevComponents.DotNetBar;
using DevComponents.DotNetBar.SuperGrid;
using ProShared.GeneralM;using ProShared;
using ProShared.Stock_Data;
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
    public partial  class FrmAutoAlarmEmployee : Form
    { void avs(int arln)

{ 
}
        private void langloads(object sender, EventArgs e)
        {
              avs(ProShared. GeneralM.VarGeneral.currentintlanguage);;
        }
   
        public class ColumnDictinary
        {
            public string EmpNo;
            public ColumnDictinary(string empNo)
            {
                EmpNo = empNo;
            }
        }
        private int LangArEn = 0;
        private GridRow row;
        private HijriGreg.HijriGregDates n = new HijriGreg.HijriGregDates();
        private Dictionary<string, ColumnDictinary> FlagLte = new Dictionary<string, ColumnDictinary>();
        private Dictionary<string, ColumnDictinary> FlagSlp = new Dictionary<string, ColumnDictinary>();
        protected bool ifOkDelete;
        public bool CanEdit = true;
        protected bool CanInsert = true;
        private FormState statex;
        public List<Control> controls;
        public Control codeControl = new Control();
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
        private DevComponents.DotNetBar.TabControl tabControl1;
        private TabControlPanel tabControlPanel2;
        private DevComponents.DotNetBar.TabControl tabControl2;
        private TabControlPanel tabControlPanel6;
        private SuperGridControl superGridControl_Id;
        private TabItem tabItem_ID;
        private TabControlPanel tabControlPanel10;
        private SuperGridControl superGridControl_Passport;
        private TabItem tabItem_Passport;
        private TabControlPanel tabControlPanel7;
        private SuperGridControl superGridControl_Allownc;
        private TabItem tabItem_EmpAllownce;
        private TabItem tabItem_EmployeeDoc;
        private TabControlPanel tabControlPanel16;
        private TabControlPanel tabControlPanel32;
        private TabControlPanel tabControlPanel18;
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
        public FrmAutoAlarmEmployee()
        {
            InitializeComponent();this.Load += langloads;
        }
        private void FrmAutoAlarmEmployee_Load(object sender, EventArgs e)
        {
            try
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmAutoAlarmEmployee));
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
                try
                {
                    tabItem_EmployeeDoc.Parent.Visible = false;
                    SettingGrid();
                    try
                    {
                        tabControl1.SelectedTabIndex = VarGeneral.vTabAutoAlarm;
                    }
                    catch
                    {
                        tabControl1.SelectedTabIndex = 0;
                    }
                }
                catch (Exception error2)
                {
                    VarGeneral.DebLog.writeLog("FrmAttendLate_Load:", error2, enable: true);
                    MessageBox.Show(error2.Message);
                }
            }
            catch (Exception error2)
            {
                VarGeneral.DebLog.writeLog("Load:", error2, enable: true);
                MessageBox.Show(error2.Message);
            }
        }
        private int getTotalDays(string dt1, string dt2)
        {
            try
            {
                DateTime d1 = Convert.ToDateTime(dt1);
                DateTime d2 = Convert.ToDateTime(dt2);
                return d1.Subtract(d2).Days;
            }
            catch
            {
                return 0;
            }
        }
        private void FillEmpDoc()
        {
            List<T_AccDef> vEmp = db.ExecuteQuery<T_AccDef>("Select * From T_AccDef Where T_AccDef.AccCat = 6 AND T_AccDef.Lev = 4 AND DATEADD(DAY, -" + VarGeneral.Settings_Sys.AlarmEmployee.Value + ", CONVERT(DATE, ID_DateEnd)) <= CASE WHEN substring(ID_DateEnd,1,4) < 1800 THEN CONVERT(DATE, '" + VarGeneral.Hdate + "') ELSE '" + VarGeneral.Gdate + "' END", new object[0]).ToList();
            for (int i = 0; i < vEmp.Count(); i++)
            {
                if (VarGeneral.CheckDate(vEmp[i].ID_DateEnd))
                {
                    row = new GridRow();
                    row.Cells.Add(new GridCell(""));
                    row.Cells.Add(new GridCell(""));
                    row.Cells.Add(new GridCell(""));
                    row.Cells.Add(new GridCell(""));
                    row.Cells.Add(new GridCell(""));
                    row.Cells.Add(new GridCell(""));
                    row.Cells.Add(new GridCell(""));
                    superGridControl_Id.PrimaryGrid.Rows.Add(row);
                    superGridControl_Id.PrimaryGrid.GetCell(i, 0).Value = getTotalDays(vEmp[i].ID_DateEnd, n.IsGreg(vEmp[i].ID_DateEnd) ? VarGeneral.Gdate : VarGeneral.Hdate);
                    superGridControl_Id.PrimaryGrid.GetCell(i, 1).Value = vEmp[i].ID_DateEnd;
                    superGridControl_Id.PrimaryGrid.GetCell(i, 2).Value = vEmp[i].ID_Date;
                    superGridControl_Id.PrimaryGrid.GetCell(i, 3).Value = vEmp[i].ID_From;
                    superGridControl_Id.PrimaryGrid.GetCell(i, 4).Value = vEmp[i].ID_No;
                    superGridControl_Id.PrimaryGrid.GetCell(i, 5).Value = ((LangArEn == 0) ? vEmp[i].Arb_Des : vEmp[i].Eng_Des);
                    superGridControl_Id.PrimaryGrid.GetCell(i, 6).Value = vEmp[i].AccDef_No;
                }
            }
            vEmp = db.ExecuteQuery<T_AccDef>("Select * From T_AccDef Where T_AccDef.AccCat = 6 AND T_AccDef.Lev = 4 AND DATEADD(DAY, -" + VarGeneral.Settings_Sys.AlarmEmployee.Value + ", CONVERT(DATE, Passport_DateEnd)) <= CASE WHEN substring(Passport_DateEnd,1,4) < 1800 THEN CONVERT(DATE, '" + VarGeneral.Hdate + "') ELSE '" + VarGeneral.Gdate + "' END", new object[0]).ToList();
            for (int i = 0; i < vEmp.Count(); i++)
            {
                if (VarGeneral.CheckDate(vEmp[i].Passport_DateEnd))
                {
                    row = new GridRow();
                    row.Cells.Add(new GridCell(""));
                    row.Cells.Add(new GridCell(""));
                    row.Cells.Add(new GridCell(""));
                    row.Cells.Add(new GridCell(""));
                    row.Cells.Add(new GridCell(""));
                    row.Cells.Add(new GridCell(""));
                    row.Cells.Add(new GridCell(""));
                    superGridControl_Passport.PrimaryGrid.Rows.Add(row);
                    superGridControl_Passport.PrimaryGrid.GetCell(i, 0).Value = getTotalDays(vEmp[i].Passport_DateEnd, n.IsGreg(vEmp[i].Passport_DateEnd) ? VarGeneral.Gdate : VarGeneral.Hdate);
                    superGridControl_Passport.PrimaryGrid.GetCell(i, 1).Value = vEmp[i].Passport_DateEnd;
                    superGridControl_Passport.PrimaryGrid.GetCell(i, 2).Value = vEmp[i].Passport_Date;
                    superGridControl_Passport.PrimaryGrid.GetCell(i, 3).Value = vEmp[i].Passport_From;
                    superGridControl_Passport.PrimaryGrid.GetCell(i, 4).Value = vEmp[i].Passport_No;
                    superGridControl_Passport.PrimaryGrid.GetCell(i, 5).Value = ((LangArEn == 0) ? vEmp[i].Arb_Des : vEmp[i].Eng_Des);
                    superGridControl_Passport.PrimaryGrid.GetCell(i, 6).Value = vEmp[i].AccDef_No;
                }
            }
            vEmp = db.ExecuteQuery<T_AccDef>("Select * From T_AccDef Where T_AccDef.AccCat = 6 AND T_AccDef.Lev = 4 AND DATEADD(DAY, -" + VarGeneral.Settings_Sys.AlarmEmployee.Value + ", CONVERT(DATE, Insurance_DateEnd)) <= CASE WHEN substring(Insurance_DateEnd,1,4) < 1800 THEN CONVERT(DATE, '" + VarGeneral.Hdate + "') ELSE '" + VarGeneral.Gdate + "' END", new object[0]).ToList();
            for (int i = 0; i < vEmp.Count(); i++)
            {
                if (VarGeneral.CheckDate(vEmp[i].Insurance_DateEnd))
                {
                    row = new GridRow();
                    row.Cells.Add(new GridCell(""));
                    row.Cells.Add(new GridCell(""));
                    row.Cells.Add(new GridCell(""));
                    row.Cells.Add(new GridCell(""));
                    row.Cells.Add(new GridCell(""));
                    row.Cells.Add(new GridCell(""));
                    row.Cells.Add(new GridCell(""));
                    superGridControl_Allownc.PrimaryGrid.Rows.Add(row);
                    superGridControl_Allownc.PrimaryGrid.GetCell(i, 0).Value = getTotalDays(vEmp[i].Insurance_DateEnd, n.IsGreg(vEmp[i].Insurance_DateEnd) ? VarGeneral.Gdate : VarGeneral.Hdate);
                    superGridControl_Allownc.PrimaryGrid.GetCell(i, 1).Value = vEmp[i].Insurance_DateEnd;
                    superGridControl_Allownc.PrimaryGrid.GetCell(i, 2).Value = vEmp[i].Insurance_Date;
                    superGridControl_Allownc.PrimaryGrid.GetCell(i, 3).Value = vEmp[i].Insurance_From;
                    superGridControl_Allownc.PrimaryGrid.GetCell(i, 4).Value = vEmp[i].Insurance_No;
                    superGridControl_Allownc.PrimaryGrid.GetCell(i, 5).Value = ((LangArEn == 0) ? vEmp[i].Arb_Des : vEmp[i].Eng_Des);
                    superGridControl_Allownc.PrimaryGrid.GetCell(i, 6).Value = vEmp[i].AccDef_No;
                }
            }
        }
        private void SettingGrid()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                tabItem_EmployeeDoc.Text = "وثائق الموظفين";
                tabItem_ID.Text = "هويات الموظفين";
                tabItem_Passport.Text = "الجـوازات";
                tabItem_EmpAllownce.Text = "التامين الصحي";
                Text = "تنبيهات الــــوثائق";
            }
            else
            {
                tabItem_EmployeeDoc.Text = "Employee Documents";
                tabItem_ID.Text = "ID";
                tabItem_Passport.Text = "Passport";
                tabItem_EmpAllownce.Text = "Insurances";
                Text = "Documents Alarms";
            }
            superGridControl_Id.PrimaryGrid.Columns[0].HeaderText = ((LangArEn == 0) ? "الأيام" : "Days");
            superGridControl_Id.PrimaryGrid.Columns[1].HeaderText = ((LangArEn == 0) ? "تاريخ إنتهاء الهوية" : "Expir Date");
            superGridControl_Id.PrimaryGrid.Columns[2].HeaderText = ((LangArEn == 0) ? "تاريخ الإصدار" : "Release Date");
            superGridControl_Id.PrimaryGrid.Columns[3].HeaderText = ((LangArEn == 0) ? "مكان الإصدار" : "Place of Issue");
            superGridControl_Id.PrimaryGrid.Columns[4].HeaderText = ((LangArEn == 0) ? "رقم الهوية" : "ID No");
            superGridControl_Id.PrimaryGrid.Columns[5].HeaderText = ((LangArEn == 0) ? "الإســـم" : "Name");
            superGridControl_Id.PrimaryGrid.Columns[6].HeaderText = ((LangArEn == 0) ? "الرقم" : "No");
            superGridControl_Passport.PrimaryGrid.Columns[0].HeaderText = ((LangArEn == 0) ? "الأيام" : "Days");
            superGridControl_Passport.PrimaryGrid.Columns[1].HeaderText = ((LangArEn == 0) ? "تاريخ إنتهاء الجواز" : "Expir Date");
            superGridControl_Passport.PrimaryGrid.Columns[2].HeaderText = ((LangArEn == 0) ? "تاريخ الإصدار" : "Release Date");
            superGridControl_Passport.PrimaryGrid.Columns[3].HeaderText = ((LangArEn == 0) ? "مكان الإصدار" : "Place of Issue");
            superGridControl_Passport.PrimaryGrid.Columns[4].HeaderText = ((LangArEn == 0) ? "رقم جواز السفر" : "Passport No");
            superGridControl_Passport.PrimaryGrid.Columns[5].HeaderText = ((LangArEn == 0) ? "الإســـم" : "Name");
            superGridControl_Passport.PrimaryGrid.Columns[6].HeaderText = ((LangArEn == 0) ? "الرقم" : "No");
            superGridControl_Allownc.PrimaryGrid.Columns[0].HeaderText = ((LangArEn == 0) ? "الأيام" : "Days");
            superGridControl_Allownc.PrimaryGrid.Columns[1].HeaderText = ((LangArEn == 0) ? "تاريخ إنتهاء التأمين" : "Expir Date");
            superGridControl_Allownc.PrimaryGrid.Columns[2].HeaderText = ((LangArEn == 0) ? "تاريخ الإصدار" : "Release Date");
            superGridControl_Allownc.PrimaryGrid.Columns[3].HeaderText = ((LangArEn == 0) ? "مكان الإصدار" : "Place of Issue");
            superGridControl_Allownc.PrimaryGrid.Columns[4].HeaderText = ((LangArEn == 0) ? "رقم التأمين الصحي" : "Allownce No");
            superGridControl_Allownc.PrimaryGrid.Columns[5].HeaderText = ((LangArEn == 0) ? "الإســـم" : "Name");
            superGridControl_Allownc.PrimaryGrid.Columns[6].HeaderText = ((LangArEn == 0) ? "الرقم" : "No");
            superGridControl_Id.PrimaryGrid.ReadOnly = true;
            superGridControl_Passport.PrimaryGrid.ReadOnly = true;
            superGridControl_Allownc.PrimaryGrid.ReadOnly = true;
            if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 23))
            {
                FillEmpDoc();
            }
        }
        private void FrmAutoAlarmEmployee_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                SendKeys.Send("{Tab}");
            }
        }
        private void FrmAutoAlarmEmployee_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void toolStripButton_Close_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
