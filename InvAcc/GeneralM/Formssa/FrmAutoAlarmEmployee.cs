using DevComponents.DotNetBar;
using DevComponents.DotNetBar.SuperGrid;
using InvAcc.GeneralM;
using InvAcc.Stock_Data;
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
    public partial class FrmAutoAlarmEmployee : Form
    {
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
            InitializeComponent();
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
            components = new System.ComponentModel.Container();
            this.PanelSpecialContainer = new System.Windows.Forms.Panel();

            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InvAcc.Forms.FrmAutoAlarmEmployee));
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn1 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn12 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn15 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn16 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn17 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn18 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn19 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.Style.Background background1 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.Style.Background background5 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.Style.Background background6 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.Style.Background background7 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn7 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn8 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn9 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn10 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn11 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn13 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn14 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.Style.Background background12 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.Style.Background background2 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.Style.Background background3 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.Style.Background background4 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn20 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn21 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn2 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn3 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn4 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn5 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn6 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.Style.Background background8 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.Style.Background background9 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.Style.Background background10 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.Style.Background background11 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            ribbonBar1 = new DevComponents.DotNetBar.RibbonBar();
            panel1 = new System.Windows.Forms.Panel();
            tabControl1 = new DevComponents.DotNetBar.TabControl();
            tabControlPanel2 = new DevComponents.DotNetBar.TabControlPanel();
            tabControl2 = new DevComponents.DotNetBar.TabControl();
            tabControlPanel6 = new DevComponents.DotNetBar.TabControlPanel();
            superGridControl_Id = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            tabItem_ID = new DevComponents.DotNetBar.TabItem(components);
            tabControlPanel7 = new DevComponents.DotNetBar.TabControlPanel();
            superGridControl_Allownc = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            tabItem_EmpAllownce = new DevComponents.DotNetBar.TabItem(components);
            tabControlPanel10 = new DevComponents.DotNetBar.TabControlPanel();
            superGridControl_Passport = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            tabItem_Passport = new DevComponents.DotNetBar.TabItem(components);
            tabItem_EmployeeDoc = new DevComponents.DotNetBar.TabItem(components);
            tabControlPanel32 = new DevComponents.DotNetBar.TabControlPanel();
            tabControlPanel18 = new DevComponents.DotNetBar.TabControlPanel();
            tabControlPanel16 = new DevComponents.DotNetBar.TabControlPanel();
            this.netResize1 = new Softgroup.NetResize.NetResize(this.components);
            this.netResize1.AfterControlResize += new Softgroup.NetResize.NetResize.AfterControlResizeEventHandler(this.netResize1_AfterControlResize);
            this.Shown += new System.EventHandler(this.FrmInvSale_Shown);
            this.SizeChanged += new System.EventHandler(this.FrmInvSale_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).BeginInit();

            ribbonBar1.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tabControl1).BeginInit();
            tabControl1.SuspendLayout();
            tabControlPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tabControl2).BeginInit();
            tabControl2.SuspendLayout();
            tabControlPanel6.SuspendLayout();
            tabControlPanel7.SuspendLayout();
            tabControlPanel10.SuspendLayout();
            SuspendLayout();
            ribbonBar1.AutoOverflowEnabled = true;
            ribbonBar1.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            ribbonBar1.BackgroundStyle.BackColor = System.Drawing.Color.AliceBlue;
            ribbonBar1.BackgroundStyle.BackColor2 = System.Drawing.SystemColors.GradientActiveCaption;
            ribbonBar1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            ribbonBar1.ContainerControlProcessDialogKey = true;
            ribbonBar1.Controls.Add(panel1);
            resources.ApplyResources(ribbonBar1, "ribbonBar1");
            ribbonBar1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            ribbonBar1.Name = "ribbonBar1";
            ribbonBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            ribbonBar1.TitleStyle.BackColor = System.Drawing.Color.FromArgb(227, 239, 255);
            ribbonBar1.TitleStyle.BackColor2 = System.Drawing.Color.FromArgb(101, 147, 207);
            ribbonBar1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            ribbonBar1.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            panel1.BackColor = System.Drawing.Color.Transparent;
            panel1.Controls.Add(tabControl1);
            resources.ApplyResources(panel1, "panel1");
            panel1.Name = "panel1";
            tabControl1.BackColor = System.Drawing.Color.Transparent;
            tabControl1.CanReorderTabs = true;
            tabControl1.Controls.Add(tabControlPanel2);
            resources.ApplyResources(tabControl1, "tabControl1");
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedTabFont = new System.Drawing.Font("Tahoma", 8f, System.Drawing.FontStyle.Bold);
            tabControl1.SelectedTabIndex = 0;
            tabControl1.Style = DevComponents.DotNetBar.eTabStripStyle.Metro;
            tabControl1.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.MultilineNoNavigationBox;
            tabControl1.Tabs.Add(tabItem_EmployeeDoc);
            tabControlPanel2.Controls.Add(tabControl2);
            resources.ApplyResources(tabControlPanel2, "tabControlPanel2");
            tabControlPanel2.Name = "tabControlPanel2";
            tabControlPanel2.Style.BackColor1.Color = System.Drawing.Color.FromArgb(227, 239, 255);
            tabControlPanel2.Style.BackColor2.Color = System.Drawing.Color.FromArgb(176, 210, 255);
            tabControlPanel2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            tabControlPanel2.Style.BorderColor.Color = System.Drawing.Color.FromArgb(146, 165, 199);
            tabControlPanel2.Style.BorderSide = DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right | DevComponents.DotNetBar.eBorderSide.Bottom;
            tabControlPanel2.Style.GradientAngle = 90;
            tabControlPanel2.TabItem = tabItem_EmployeeDoc;
            tabControl2.BackColor = System.Drawing.Color.Transparent;
            tabControl2.CanReorderTabs = true;
            tabControl2.ColorScheme.TabItemBackgroundColorBlend.AddRange(new DevComponents.DotNetBar.BackgroundColorBlend[4]
            {
                new DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(200, 220, 244), 0f),
                new DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(175, 210, 254), 0.45f),
                new DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(150, 191, 243), 0.45f),
                new DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(181, 204, 233), 1f)
            });
            tabControl2.ColorScheme.TabItemHotBackgroundColorBlend.AddRange(new DevComponents.DotNetBar.BackgroundColorBlend[4]
            {
                new DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(224, 237, 255), 0f),
                new DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(215, 232, 255), 0.45f),
                new DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(176, 210, 255), 0.45f),
                new DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(190, 218, 255), 1f)
            });
            tabControl2.ColorScheme.TabItemHotText = System.Drawing.Color.Black;
            tabControl2.ColorScheme.TabItemSelectedBackgroundColorBlend.AddRange(new DevComponents.DotNetBar.BackgroundColorBlend[4]
            {
                new DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(235, 227, 217), 0f),
                new DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(253, 189, 116), 0.45f),
                new DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(249, 180, 89), 0.45f),
                new DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(255, 255, 255), 1f)
            });
            tabControl2.ColorScheme.TabItemSelectedText = System.Drawing.Color.Black;
            tabControl2.ColorScheme.TabItemText = System.Drawing.Color.Black;
            tabControl2.Controls.Add(tabControlPanel6);
            tabControl2.Controls.Add(tabControlPanel10);
            tabControl2.Controls.Add(tabControlPanel7);
            resources.ApplyResources(tabControl2, "tabControl2");
            tabControl2.ForeColor = System.Drawing.Color.White;
            tabControl2.Name = "tabControl2";
            tabControl2.SelectedTabFont = new System.Drawing.Font("Tahoma", 8f, System.Drawing.FontStyle.Bold);
            tabControl2.SelectedTabIndex = 0;
            tabControl2.Style = DevComponents.DotNetBar.eTabStripStyle.RoundHeader;
            tabControl2.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox;
            tabControl2.Tabs.Add(tabItem_ID);
            tabControl2.Tabs.Add(tabItem_Passport);
            tabControl2.Tabs.Add(tabItem_EmpAllownce);
            tabControlPanel6.Controls.Add(superGridControl_Id);
            resources.ApplyResources(tabControlPanel6, "tabControlPanel6");
            tabControlPanel6.Name = "tabControlPanel6";
            tabControlPanel6.Style.BackColor1.Color = System.Drawing.Color.White;
            tabControlPanel6.Style.BackColor2.Color = System.Drawing.Color.FromArgb(236, 233, 215);
            tabControlPanel6.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            tabControlPanel6.Style.BorderColor.Color = System.Drawing.SystemColors.ControlDarkDark;
            tabControlPanel6.Style.BorderSide = DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right | DevComponents.DotNetBar.eBorderSide.Bottom;
            tabControlPanel6.Style.GradientAngle = 90;
            tabControlPanel6.TabItem = tabItem_ID;
            superGridControl_Id.BackColor = System.Drawing.SystemColors.ControlLight;
            resources.ApplyResources(superGridControl_Id, "superGridControl_Id");
            superGridControl_Id.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            superGridControl_Id.ForeColor = System.Drawing.Color.Black;
            superGridControl_Id.HScrollBarVisible = false;
            superGridControl_Id.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            superGridControl_Id.Name = "superGridControl_Id";
            superGridControl_Id.PrimaryGrid.AllowRowHeaderResize = true;
            superGridControl_Id.PrimaryGrid.AllowRowResize = true;
            superGridControl_Id.PrimaryGrid.ColumnHeader.RowHeight = 30;
            superGridControl_Id.PrimaryGrid.ColumnHeader.SortImageAlignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gridColumn1.EnableFiltering = DevComponents.DotNetBar.SuperGrid.Style.Tbool.False;
            gridColumn1.Name = "";
            gridColumn1.Visible = false;
            gridColumn1.Width = 60;
            gridColumn12.EnableFiltering = DevComponents.DotNetBar.SuperGrid.Style.Tbool.False;
            gridColumn12.Name = "EndDate";
            gridColumn12.Width = 130;
            gridColumn15.EnableFiltering = DevComponents.DotNetBar.SuperGrid.Style.Tbool.False;
            gridColumn15.Name = "IssDate";
            gridColumn15.Visible = false;
            gridColumn15.Width = 90;
            gridColumn16.EnableFiltering = DevComponents.DotNetBar.SuperGrid.Style.Tbool.False;
            gridColumn16.Name = "Place";
            gridColumn16.Visible = false;
            gridColumn16.Width = 120;
            gridColumn17.EnableFiltering = DevComponents.DotNetBar.SuperGrid.Style.Tbool.False;
            gridColumn17.Name = "No";
            gridColumn17.Width = 120;
            gridColumn18.EnableFiltering = DevComponents.DotNetBar.SuperGrid.Style.Tbool.False;
            gridColumn18.Name = "EmpName";
            gridColumn18.Width = 220;
            gridColumn19.EnableFiltering = DevComponents.DotNetBar.SuperGrid.Style.Tbool.False;
            gridColumn19.Name = "EmpNo";
            gridColumn19.Visible = false;
            superGridControl_Id.PrimaryGrid.Columns.Add(gridColumn1);
            superGridControl_Id.PrimaryGrid.Columns.Add(gridColumn12);
            superGridControl_Id.PrimaryGrid.Columns.Add(gridColumn15);
            superGridControl_Id.PrimaryGrid.Columns.Add(gridColumn16);
            superGridControl_Id.PrimaryGrid.Columns.Add(gridColumn17);
            superGridControl_Id.PrimaryGrid.Columns.Add(gridColumn18);
            superGridControl_Id.PrimaryGrid.Columns.Add(gridColumn19);
            superGridControl_Id.PrimaryGrid.DefaultRowHeight = 24;
            background1.Color1 = System.Drawing.Color.White;
            background1.Color2 = System.Drawing.Color.FromArgb(255, 255, 192);
            superGridControl_Id.PrimaryGrid.DefaultVisualStyles.AlternateColumnCellStyles.Default.Background = background1;
            background5.Color1 = System.Drawing.Color.White;
            background5.Color2 = System.Drawing.Color.FromArgb(255, 255, 192);
            superGridControl_Id.PrimaryGrid.DefaultVisualStyles.AlternateRowCellStyles.Default.Background = background5;
            superGridControl_Id.PrimaryGrid.DefaultVisualStyles.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            background6.Color1 = System.Drawing.SystemColors.ActiveCaption;
            background6.Color2 = System.Drawing.SystemColors.GradientInactiveCaption;
            superGridControl_Id.PrimaryGrid.DefaultVisualStyles.ColumnHeaderStyles.Default.Background = background6;
            superGridControl_Id.PrimaryGrid.DefaultVisualStyles.FilterColumnHeaderStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            background7.Color1 = System.Drawing.SystemColors.ActiveCaption;
            superGridControl_Id.PrimaryGrid.DefaultVisualStyles.FilterColumnHeaderStyles.Default.Background = background7;
            superGridControl_Id.PrimaryGrid.EnableColumnFiltering = true;
            superGridControl_Id.PrimaryGrid.EnableFiltering = true;
            superGridControl_Id.PrimaryGrid.EnableRowFiltering = true;
            superGridControl_Id.PrimaryGrid.FilterLevel = DevComponents.DotNetBar.SuperGrid.FilterLevel.All;
            superGridControl_Id.PrimaryGrid.FilterMatchType = DevComponents.DotNetBar.SuperGrid.FilterMatchType.RegularExpressions;
            superGridControl_Id.PrimaryGrid.MultiSelect = false;
            superGridControl_Id.PrimaryGrid.NullString = "-----";
            superGridControl_Id.PrimaryGrid.RowHeaderWidth = 45;
            superGridControl_Id.PrimaryGrid.ShowRowHeaders = false;
            tabItem_ID.AttachedControl = tabControlPanel6;
            tabItem_ID.Name = "tabItem_ID";
            resources.ApplyResources(tabItem_ID, "tabItem_ID");
            tabControlPanel7.Controls.Add(superGridControl_Allownc);
            resources.ApplyResources(tabControlPanel7, "tabControlPanel7");
            tabControlPanel7.Name = "tabControlPanel7";
            tabControlPanel7.Style.BackColor1.Color = System.Drawing.Color.White;
            tabControlPanel7.Style.BackColor2.Color = System.Drawing.Color.FromArgb(236, 233, 215);
            tabControlPanel7.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            tabControlPanel7.Style.BorderColor.Color = System.Drawing.SystemColors.ControlDarkDark;
            tabControlPanel7.Style.BorderSide = DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right | DevComponents.DotNetBar.eBorderSide.Bottom;
            tabControlPanel7.Style.GradientAngle = 90;
            tabControlPanel7.TabItem = tabItem_EmpAllownce;
            superGridControl_Allownc.BackColor = System.Drawing.SystemColors.ControlLight;
            resources.ApplyResources(superGridControl_Allownc, "superGridControl_Allownc");
            superGridControl_Allownc.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            superGridControl_Allownc.ForeColor = System.Drawing.Color.Black;
            superGridControl_Allownc.HScrollBarVisible = false;
            superGridControl_Allownc.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            superGridControl_Allownc.Name = "superGridControl_Allownc";
            superGridControl_Allownc.PrimaryGrid.AllowRowHeaderResize = true;
            superGridControl_Allownc.PrimaryGrid.AllowRowResize = true;
            superGridControl_Allownc.PrimaryGrid.ColumnHeader.RowHeight = 30;
            superGridControl_Allownc.PrimaryGrid.ColumnHeader.SortImageAlignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gridColumn7.Name = "";
            gridColumn7.Visible = false;
            gridColumn7.Width = 60;
            gridColumn8.Name = "EndDate";
            gridColumn8.Width = 130;
            gridColumn9.Name = "IssDate";
            gridColumn9.Visible = false;
            gridColumn9.Width = 90;
            gridColumn10.Name = "Place";
            gridColumn10.Visible = false;
            gridColumn10.Width = 120;
            gridColumn11.Name = "No";
            gridColumn11.Width = 120;
            gridColumn13.Name = "EmpName";
            gridColumn13.Width = 220;
            gridColumn14.Name = "EmpNo";
            gridColumn14.Visible = false;
            superGridControl_Allownc.PrimaryGrid.Columns.Add(gridColumn7);
            superGridControl_Allownc.PrimaryGrid.Columns.Add(gridColumn8);
            superGridControl_Allownc.PrimaryGrid.Columns.Add(gridColumn9);
            superGridControl_Allownc.PrimaryGrid.Columns.Add(gridColumn10);
            superGridControl_Allownc.PrimaryGrid.Columns.Add(gridColumn11);
            superGridControl_Allownc.PrimaryGrid.Columns.Add(gridColumn13);
            superGridControl_Allownc.PrimaryGrid.Columns.Add(gridColumn14);
            superGridControl_Allownc.PrimaryGrid.DefaultRowHeight = 24;
            background12.Color1 = System.Drawing.Color.White;
            background12.Color2 = System.Drawing.Color.FromArgb(255, 255, 192);
            superGridControl_Allownc.PrimaryGrid.DefaultVisualStyles.AlternateColumnCellStyles.Default.Background = background12;
            background2.Color1 = System.Drawing.Color.White;
            background2.Color2 = System.Drawing.Color.FromArgb(255, 255, 192);
            superGridControl_Allownc.PrimaryGrid.DefaultVisualStyles.AlternateRowCellStyles.Default.Background = background2;
            superGridControl_Allownc.PrimaryGrid.DefaultVisualStyles.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            background3.Color1 = System.Drawing.SystemColors.ActiveCaption;
            background3.Color2 = System.Drawing.SystemColors.GradientInactiveCaption;
            superGridControl_Allownc.PrimaryGrid.DefaultVisualStyles.ColumnHeaderStyles.Default.Background = background3;
            superGridControl_Allownc.PrimaryGrid.DefaultVisualStyles.FilterColumnHeaderStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            background4.Color1 = System.Drawing.SystemColors.ActiveCaption;
            superGridControl_Allownc.PrimaryGrid.DefaultVisualStyles.FilterColumnHeaderStyles.Default.Background = background4;
            superGridControl_Allownc.PrimaryGrid.EnableColumnFiltering = true;
            superGridControl_Allownc.PrimaryGrid.EnableFiltering = true;
            superGridControl_Allownc.PrimaryGrid.EnableRowFiltering = true;
            superGridControl_Allownc.PrimaryGrid.FilterLevel = DevComponents.DotNetBar.SuperGrid.FilterLevel.All;
            superGridControl_Allownc.PrimaryGrid.FilterMatchType = DevComponents.DotNetBar.SuperGrid.FilterMatchType.RegularExpressions;
            superGridControl_Allownc.PrimaryGrid.MultiSelect = false;
            superGridControl_Allownc.PrimaryGrid.NullString = "-----";
            superGridControl_Allownc.PrimaryGrid.RowHeaderWidth = 45;
            superGridControl_Allownc.PrimaryGrid.ShowRowGridIndex = true;
            superGridControl_Allownc.PrimaryGrid.ShowRowHeaders = false;
            tabItem_EmpAllownce.AttachedControl = tabControlPanel7;
            tabItem_EmpAllownce.Name = "tabItem_EmpAllownce";
            resources.ApplyResources(tabItem_EmpAllownce, "tabItem_EmpAllownce");
            tabControlPanel10.Controls.Add(superGridControl_Passport);
            resources.ApplyResources(tabControlPanel10, "tabControlPanel10");
            tabControlPanel10.Name = "tabControlPanel10";
            tabControlPanel10.Style.BackColor1.Color = System.Drawing.Color.White;
            tabControlPanel10.Style.BackColor2.Color = System.Drawing.Color.FromArgb(236, 233, 215);
            tabControlPanel10.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            tabControlPanel10.Style.BorderColor.Color = System.Drawing.SystemColors.ControlDarkDark;
            tabControlPanel10.Style.BorderSide = DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right | DevComponents.DotNetBar.eBorderSide.Bottom;
            tabControlPanel10.Style.GradientAngle = 90;
            tabControlPanel10.TabItem = tabItem_Passport;
            superGridControl_Passport.BackColor = System.Drawing.SystemColors.ControlLight;
            resources.ApplyResources(superGridControl_Passport, "superGridControl_Passport");
            superGridControl_Passport.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            superGridControl_Passport.ForeColor = System.Drawing.Color.Black;
            superGridControl_Passport.HScrollBarVisible = false;
            superGridControl_Passport.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            superGridControl_Passport.Name = "superGridControl_Passport";
            superGridControl_Passport.PrimaryGrid.AllowRowHeaderResize = true;
            superGridControl_Passport.PrimaryGrid.AllowRowResize = true;
            superGridControl_Passport.PrimaryGrid.ColumnHeader.RowHeight = 30;
            superGridControl_Passport.PrimaryGrid.ColumnHeader.SortImageAlignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gridColumn20.Name = "";
            gridColumn20.Visible = false;
            gridColumn20.Width = 60;
            gridColumn21.Name = "EndDate";
            gridColumn21.Width = 130;
            gridColumn2.Name = "IssDate";
            gridColumn2.Visible = false;
            gridColumn2.Width = 90;
            gridColumn3.Name = "Place";
            gridColumn3.Visible = false;
            gridColumn3.Width = 120;
            gridColumn4.Name = "No";
            gridColumn4.Width = 120;
            gridColumn5.Name = "EmpName";
            gridColumn5.Width = 220;
            gridColumn6.Name = "EmpNo";
            gridColumn6.Visible = false;
            superGridControl_Passport.PrimaryGrid.Columns.Add(gridColumn20);
            superGridControl_Passport.PrimaryGrid.Columns.Add(gridColumn21);
            superGridControl_Passport.PrimaryGrid.Columns.Add(gridColumn2);
            superGridControl_Passport.PrimaryGrid.Columns.Add(gridColumn3);
            superGridControl_Passport.PrimaryGrid.Columns.Add(gridColumn4);
            superGridControl_Passport.PrimaryGrid.Columns.Add(gridColumn5);
            superGridControl_Passport.PrimaryGrid.Columns.Add(gridColumn6);
            superGridControl_Passport.PrimaryGrid.DefaultRowHeight = 24;
            background8.Color1 = System.Drawing.Color.White;
            background8.Color2 = System.Drawing.Color.FromArgb(255, 255, 192);
            superGridControl_Passport.PrimaryGrid.DefaultVisualStyles.AlternateColumnCellStyles.Default.Background = background8;
            background9.Color1 = System.Drawing.Color.White;
            background9.Color2 = System.Drawing.Color.FromArgb(255, 255, 192);
            superGridControl_Passport.PrimaryGrid.DefaultVisualStyles.AlternateRowCellStyles.Default.Background = background9;
            superGridControl_Passport.PrimaryGrid.DefaultVisualStyles.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            background10.Color1 = System.Drawing.SystemColors.ActiveCaption;
            background10.Color2 = System.Drawing.SystemColors.GradientInactiveCaption;
            superGridControl_Passport.PrimaryGrid.DefaultVisualStyles.ColumnHeaderStyles.Default.Background = background10;
            superGridControl_Passport.PrimaryGrid.DefaultVisualStyles.FilterColumnHeaderStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            background11.Color1 = System.Drawing.SystemColors.ActiveCaption;
            superGridControl_Passport.PrimaryGrid.DefaultVisualStyles.FilterColumnHeaderStyles.Default.Background = background11;
            superGridControl_Passport.PrimaryGrid.EnableColumnFiltering = true;
            superGridControl_Passport.PrimaryGrid.EnableFiltering = true;
            superGridControl_Passport.PrimaryGrid.EnableRowFiltering = true;
            superGridControl_Passport.PrimaryGrid.FilterLevel = DevComponents.DotNetBar.SuperGrid.FilterLevel.All;
            superGridControl_Passport.PrimaryGrid.FilterMatchType = DevComponents.DotNetBar.SuperGrid.FilterMatchType.RegularExpressions;
            superGridControl_Passport.PrimaryGrid.MultiSelect = false;
            superGridControl_Passport.PrimaryGrid.NullString = "-----";
            superGridControl_Passport.PrimaryGrid.RowHeaderWidth = 45;
            superGridControl_Passport.PrimaryGrid.ShowRowGridIndex = true;
            superGridControl_Passport.PrimaryGrid.ShowRowHeaders = false;
            tabItem_Passport.AttachedControl = tabControlPanel10;
            tabItem_Passport.Name = "tabItem_Passport";
            resources.ApplyResources(tabItem_Passport, "tabItem_Passport");
            tabItem_EmployeeDoc.AttachedControl = tabControlPanel2;
            tabItem_EmployeeDoc.Name = "tabItem_EmployeeDoc";
            resources.ApplyResources(tabItem_EmployeeDoc, "tabItem_EmployeeDoc");
            resources.ApplyResources(tabControlPanel32, "tabControlPanel32");
            tabControlPanel32.Name = "tabControlPanel32";
            tabControlPanel32.Style.BackColor1.Color = System.Drawing.Color.White;
            tabControlPanel32.Style.BackColor2.Color = System.Drawing.Color.FromArgb(236, 233, 215);
            tabControlPanel32.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            tabControlPanel32.Style.BorderColor.Color = System.Drawing.SystemColors.ControlDarkDark;
            tabControlPanel32.Style.BorderSide = DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right | DevComponents.DotNetBar.eBorderSide.Bottom;
            tabControlPanel32.Style.GradientAngle = 90;
            resources.ApplyResources(tabControlPanel18, "tabControlPanel18");
            tabControlPanel18.Name = "tabControlPanel18";
            tabControlPanel18.Style.BackColor1.Color = System.Drawing.Color.White;
            tabControlPanel18.Style.BackColor2.Color = System.Drawing.Color.FromArgb(236, 233, 215);
            tabControlPanel18.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            tabControlPanel18.Style.BorderColor.Color = System.Drawing.SystemColors.ControlDarkDark;
            tabControlPanel18.Style.BorderSide = DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right | DevComponents.DotNetBar.eBorderSide.Bottom;
            tabControlPanel18.Style.GradientAngle = 90;
            resources.ApplyResources(tabControlPanel16, "tabControlPanel16");
            tabControlPanel16.Name = "tabControlPanel16";
            tabControlPanel16.Style.BackColor1.Color = System.Drawing.Color.FromArgb(255, 255, 255);
            tabControlPanel16.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            tabControlPanel16.Style.BorderColor.Color = System.Drawing.Color.FromArgb(132, 157, 189);
            tabControlPanel16.Style.BorderSide = DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right | DevComponents.DotNetBar.eBorderSide.Bottom;
            tabControlPanel16.Style.GradientAngle = 90;
            resources.ApplyResources(this, "$this");
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            base.Controls.Add(ribbonBar1);
            base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            base.KeyPreview = true;
            base.MaximizeBox = false;
            base.Name = "FrmAutoAlarmEmployee";
            base.Load += new System.EventHandler(FrmAutoAlarmEmployee_Load);
            base.KeyPress += new System.Windows.Forms.KeyPressEventHandler(FrmAutoAlarmEmployee_KeyPress);
            base.KeyDown += new System.Windows.Forms.KeyEventHandler(FrmAutoAlarmEmployee_KeyDown);
            ribbonBar1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)tabControl1).EndInit();
            tabControl1.ResumeLayout(false);
            tabControlPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)tabControl2).EndInit();
            tabControl2.ResumeLayout(false);
            tabControlPanel6.ResumeLayout(false);
            tabControlPanel7.ResumeLayout(false);
            tabControlPanel10.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}
