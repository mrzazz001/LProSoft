using CrystalDecisions.CrystalReports.Engine;
using DevComponents.DotNetBar;
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
    public partial class FrmRepSalary : Form
    {
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
                        frm.Repvalue = "EmpsSalRep";


                        frm.Repvalue = "EmpsSalRep";
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


        private RibbonBar ribbonBar1;
        private Panel panel1;
        private ButtonX ButExit;
        private ButtonX ButOk;
        private GroupBox groupBox_Date;
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
        private MaskedTextBox textBox_SalDateFrom;
        private GroupBox groupBox1;
        private MaskedTextBox textBox_SalDateTo;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InvAcc.Forms.FrmRepSalary));
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn1 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn5 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn6 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.Style.Background background1 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.Style.Background background2 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn7 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn8 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn9 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.Style.Background background3 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.Style.Background background4 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn10 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn11 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn12 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.Style.Background background5 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.Style.Background background6 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn2 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn3 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn4 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.Style.Background background7 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.Style.Background background8 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            ribbonBar1 = new DevComponents.DotNetBar.RibbonBar();
            panel1 = new System.Windows.Forms.Panel();
            expandablePanel_Girds = new DevComponents.DotNetBar.ExpandablePanel();
            expandablePanel_Emp = new DevComponents.DotNetBar.ExpandablePanel();
            itemPanel4 = new DevComponents.DotNetBar.ItemPanel();
            dataGridViewX_Emp = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            expandablePanel_Job = new DevComponents.DotNetBar.ExpandablePanel();
            itemPanel3 = new DevComponents.DotNetBar.ItemPanel();
            dataGridViewX_Job = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            expandablePanel_Section = new DevComponents.DotNetBar.ExpandablePanel();
            itemPanel2 = new DevComponents.DotNetBar.ItemPanel();
            dataGridViewX_Section = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            expandablePanel_Dept = new DevComponents.DotNetBar.ExpandablePanel();
            itemPanel1 = new DevComponents.DotNetBar.ItemPanel();
            dataGridViewX_Dept = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            ButExit = new DevComponents.DotNetBar.ButtonX();
            ButOk = new DevComponents.DotNetBar.ButtonX();
            groupBox_Date = new System.Windows.Forms.GroupBox();
            textBox_SalDateFrom = new System.Windows.Forms.MaskedTextBox();
            groupBox1 = new System.Windows.Forms.GroupBox();
            textBox_SalDateTo = new System.Windows.Forms.MaskedTextBox();
            ribbonBar1.SuspendLayout();
            panel1.SuspendLayout();
            expandablePanel_Girds.SuspendLayout();
            expandablePanel_Emp.SuspendLayout();
            itemPanel4.SuspendLayout();
            expandablePanel_Job.SuspendLayout();
            itemPanel3.SuspendLayout();
            expandablePanel_Section.SuspendLayout();
            itemPanel2.SuspendLayout();
            expandablePanel_Dept.SuspendLayout();
            itemPanel1.SuspendLayout();
            groupBox_Date.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            ribbonBar1.AccessibleDescription = null;
            ribbonBar1.AccessibleName = null;
            resources.ApplyResources(ribbonBar1, "ribbonBar1");
            ribbonBar1.AutoOverflowEnabled = true;
            ribbonBar1.BackgroundImage = null;
            ribbonBar1.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            ribbonBar1.BackgroundStyle.BackColor = System.Drawing.Color.AliceBlue;
            ribbonBar1.BackgroundStyle.BackColor2 = System.Drawing.SystemColors.GradientActiveCaption;
            ribbonBar1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            ribbonBar1.ContainerControlProcessDialogKey = true;
            ribbonBar1.Controls.Add(panel1);
            ribbonBar1.Font = null;
            ribbonBar1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            ribbonBar1.Name = "ribbonBar1";
            ribbonBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            ribbonBar1.TitleStyle.BackColor = System.Drawing.Color.FromArgb(227, 239, 255);
            ribbonBar1.TitleStyle.BackColor2 = System.Drawing.Color.FromArgb(101, 147, 207);
            ribbonBar1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            ribbonBar1.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            panel1.AccessibleDescription = null;
            panel1.AccessibleName = null;
            resources.ApplyResources(panel1, "panel1");
            panel1.BackColor = System.Drawing.Color.Transparent;
            panel1.BackgroundImage = null;
            panel1.Controls.Add(expandablePanel_Girds);
            panel1.Controls.Add(ButExit);
            panel1.Controls.Add(ButOk);
            panel1.Controls.Add(groupBox_Date);
            panel1.Controls.Add(groupBox1);
            panel1.Font = null;
            panel1.Name = "panel1";
            expandablePanel_Girds.AccessibleDescription = null;
            expandablePanel_Girds.AccessibleName = null;
            resources.ApplyResources(expandablePanel_Girds, "expandablePanel_Girds");
            expandablePanel_Girds.CanvasColor = System.Drawing.SystemColors.Control;
            expandablePanel_Girds.CollapseDirection = DevComponents.DotNetBar.eCollapseDirection.RightToLeft;
            expandablePanel_Girds.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            expandablePanel_Girds.Controls.Add(expandablePanel_Emp);
            expandablePanel_Girds.Controls.Add(expandablePanel_Job);
            expandablePanel_Girds.Controls.Add(expandablePanel_Section);
            expandablePanel_Girds.Controls.Add(expandablePanel_Dept);
            expandablePanel_Girds.Expanded = false;
            expandablePanel_Girds.ExpandedBounds = new System.Drawing.Rectangle(0, 0, 314, 226);
            expandablePanel_Girds.Name = "expandablePanel_Girds";
            expandablePanel_Girds.Style.Alignment = System.Drawing.StringAlignment.Center;
            expandablePanel_Girds.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            expandablePanel_Girds.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            expandablePanel_Girds.Style.GradientAngle = 90;
            expandablePanel_Girds.TitleStyle.Alignment = System.Drawing.StringAlignment.Far;
            expandablePanel_Girds.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            expandablePanel_Girds.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            expandablePanel_Girds.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            expandablePanel_Girds.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            expandablePanel_Girds.TitleStyle.GradientAngle = 90;
            expandablePanel_Girds.TitleStyle.MarginLeft = 6;
            expandablePanel_Girds.ExpandedChanged += new DevComponents.DotNetBar.ExpandChangeEventHandler(expandablePanel_Girds_ExpandedChanged);
            expandablePanel_Girds.ExpandedChanging += new DevComponents.DotNetBar.ExpandChangeEventHandler(expandablePanel_Girds_ExpandedChanging);
            expandablePanel_Emp.AccessibleDescription = null;
            expandablePanel_Emp.AccessibleName = null;
            resources.ApplyResources(expandablePanel_Emp, "expandablePanel_Emp");
            expandablePanel_Emp.CanvasColor = System.Drawing.SystemColors.Control;
            expandablePanel_Emp.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            expandablePanel_Emp.Controls.Add(itemPanel4);
            expandablePanel_Emp.Expanded = false;
            expandablePanel_Emp.ExpandedBounds = new System.Drawing.Rectangle(0, 104, 314, 120);
            expandablePanel_Emp.ExpandOnTitleClick = true;
            expandablePanel_Emp.Name = "expandablePanel_Emp";
            expandablePanel_Emp.Style.Alignment = System.Drawing.StringAlignment.Center;
            expandablePanel_Emp.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            expandablePanel_Emp.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            expandablePanel_Emp.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            expandablePanel_Emp.Style.GradientAngle = 90;
            expandablePanel_Emp.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            expandablePanel_Emp.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            expandablePanel_Emp.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            expandablePanel_Emp.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            expandablePanel_Emp.TitleStyle.GradientAngle = 90;
            expandablePanel_Emp.TitleStyle.MarginLeft = 12;
            itemPanel4.AccessibleDescription = null;
            itemPanel4.AccessibleName = null;
            resources.ApplyResources(itemPanel4, "itemPanel4");
            itemPanel4.BackgroundImage = null;
            itemPanel4.BackgroundStyle.BackColor = System.Drawing.Color.AliceBlue;
            itemPanel4.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            itemPanel4.BackgroundStyle.BorderBottomWidth = 1;
            itemPanel4.BackgroundStyle.BorderColor = System.Drawing.Color.FromArgb(127, 157, 185);
            itemPanel4.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            itemPanel4.BackgroundStyle.BorderLeftWidth = 1;
            itemPanel4.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            itemPanel4.BackgroundStyle.BorderRightWidth = 1;
            itemPanel4.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            itemPanel4.BackgroundStyle.BorderTopWidth = 1;
            itemPanel4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            itemPanel4.BackgroundStyle.PaddingBottom = 1;
            itemPanel4.BackgroundStyle.PaddingLeft = 1;
            itemPanel4.BackgroundStyle.PaddingRight = 1;
            itemPanel4.BackgroundStyle.PaddingTop = 1;
            itemPanel4.ContainerControlProcessDialogKey = true;
            itemPanel4.Controls.Add(dataGridViewX_Emp);
            itemPanel4.Font = null;
            itemPanel4.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            itemPanel4.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            itemPanel4.Name = "itemPanel4";
            dataGridViewX_Emp.AccessibleDescription = null;
            dataGridViewX_Emp.AccessibleName = null;
            resources.ApplyResources(dataGridViewX_Emp, "dataGridViewX_Emp");
            dataGridViewX_Emp.BackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewX_Emp.BackgroundImage = null;
            dataGridViewX_Emp.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            dataGridViewX_Emp.Font = null;
            dataGridViewX_Emp.ForeColor = System.Drawing.Color.Black;
            dataGridViewX_Emp.HScrollBarVisible = false;
            dataGridViewX_Emp.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            dataGridViewX_Emp.Name = "dataGridViewX_Emp";
            dataGridViewX_Emp.PrimaryGrid.AllowRowHeaderResize = true;
            dataGridViewX_Emp.PrimaryGrid.AllowRowResize = true;
            dataGridViewX_Emp.PrimaryGrid.ColumnHeader.RowHeight = 30;
            dataGridViewX_Emp.PrimaryGrid.ColumnHeader.SortImageAlignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            dataGridViewX_Emp.PrimaryGrid.ColumnHeader.Visible = false;
            gridColumn1.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleLeft;
            gridColumn1.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridCheckBoxXEditControl);
            gridColumn1.FilterEditType = DevComponents.DotNetBar.SuperGrid.FilterEditType.None;
            gridColumn1.HeaderStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gridColumn1.HeaderText = null;
            gridColumn1.Name = "*";
            gridColumn1.Width = 50;
            gridColumn5.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleLeft;
            gridColumn5.ColumnSortMode = DevComponents.DotNetBar.SuperGrid.ColumnSortMode.None;
            gridColumn5.FilterAutoScan = true;
            gridColumn5.HeaderStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gridColumn5.HeaderText = null;
            gridColumn5.InfoImageAlignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gridColumn5.Name = "رقم / إسم الإدارة";
            gridColumn5.ReadOnly = true;
            gridColumn5.Width = 263;
            gridColumn6.HeaderText = null;
            gridColumn6.ReadOnly = true;
            gridColumn6.Visible = false;
            dataGridViewX_Emp.PrimaryGrid.Columns.Add(gridColumn1);
            dataGridViewX_Emp.PrimaryGrid.Columns.Add(gridColumn5);
            dataGridViewX_Emp.PrimaryGrid.Columns.Add(gridColumn6);
            dataGridViewX_Emp.PrimaryGrid.DefaultRowHeight = 24;
            background1.Color1 = System.Drawing.Color.White;
            background1.Color2 = System.Drawing.Color.FromArgb(255, 255, 192);
            dataGridViewX_Emp.PrimaryGrid.DefaultVisualStyles.AlternateColumnCellStyles.Default.Background = background1;
            background2.Color1 = System.Drawing.Color.White;
            background2.Color2 = System.Drawing.Color.FromArgb(255, 255, 192);
            dataGridViewX_Emp.PrimaryGrid.DefaultVisualStyles.AlternateRowCellStyles.Default.Background = background2;
            dataGridViewX_Emp.PrimaryGrid.DefaultVisualStyles.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            dataGridViewX_Emp.PrimaryGrid.DefaultVisualStyles.FilterColumnHeaderStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            dataGridViewX_Emp.PrimaryGrid.EnableColumnFiltering = true;
            dataGridViewX_Emp.PrimaryGrid.EnableFiltering = true;
            dataGridViewX_Emp.PrimaryGrid.EnableRowFiltering = true;
            dataGridViewX_Emp.PrimaryGrid.Filter.Visible = true;
            dataGridViewX_Emp.PrimaryGrid.FilterLevel = DevComponents.DotNetBar.SuperGrid.FilterLevel.All;
            dataGridViewX_Emp.PrimaryGrid.FilterMatchType = DevComponents.DotNetBar.SuperGrid.FilterMatchType.RegularExpressions;
            dataGridViewX_Emp.PrimaryGrid.MultiSelect = false;
            dataGridViewX_Emp.PrimaryGrid.NullString = "-----";
            dataGridViewX_Emp.PrimaryGrid.RowHeaderWidth = 45;
            dataGridViewX_Emp.PrimaryGrid.ShowColumnHeader = false;
            dataGridViewX_Emp.PrimaryGrid.ShowRowGridIndex = true;
            dataGridViewX_Emp.PrimaryGrid.ShowRowHeaders = false;
            dataGridViewX_Emp.PrimaryGrid.UseAlternateRowStyle = true;
            expandablePanel_Job.AccessibleDescription = null;
            expandablePanel_Job.AccessibleName = null;
            resources.ApplyResources(expandablePanel_Job, "expandablePanel_Job");
            expandablePanel_Job.CanvasColor = System.Drawing.SystemColors.Control;
            expandablePanel_Job.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            expandablePanel_Job.Controls.Add(itemPanel3);
            expandablePanel_Job.Expanded = false;
            expandablePanel_Job.ExpandedBounds = new System.Drawing.Rectangle(0, 78, 314, 120);
            expandablePanel_Job.ExpandOnTitleClick = true;
            expandablePanel_Job.Name = "expandablePanel_Job";
            expandablePanel_Job.Style.Alignment = System.Drawing.StringAlignment.Center;
            expandablePanel_Job.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            expandablePanel_Job.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            expandablePanel_Job.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            expandablePanel_Job.Style.GradientAngle = 90;
            expandablePanel_Job.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            expandablePanel_Job.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            expandablePanel_Job.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            expandablePanel_Job.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            expandablePanel_Job.TitleStyle.GradientAngle = 90;
            expandablePanel_Job.TitleStyle.MarginLeft = 12;
            itemPanel3.AccessibleDescription = null;
            itemPanel3.AccessibleName = null;
            resources.ApplyResources(itemPanel3, "itemPanel3");
            itemPanel3.BackgroundImage = null;
            itemPanel3.BackgroundStyle.BackColor = System.Drawing.Color.AliceBlue;
            itemPanel3.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            itemPanel3.BackgroundStyle.BorderBottomWidth = 1;
            itemPanel3.BackgroundStyle.BorderColor = System.Drawing.Color.FromArgb(127, 157, 185);
            itemPanel3.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            itemPanel3.BackgroundStyle.BorderLeftWidth = 1;
            itemPanel3.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            itemPanel3.BackgroundStyle.BorderRightWidth = 1;
            itemPanel3.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            itemPanel3.BackgroundStyle.BorderTopWidth = 1;
            itemPanel3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            itemPanel3.BackgroundStyle.PaddingBottom = 1;
            itemPanel3.BackgroundStyle.PaddingLeft = 1;
            itemPanel3.BackgroundStyle.PaddingRight = 1;
            itemPanel3.BackgroundStyle.PaddingTop = 1;
            itemPanel3.ContainerControlProcessDialogKey = true;
            itemPanel3.Controls.Add(dataGridViewX_Job);
            itemPanel3.Font = null;
            itemPanel3.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            itemPanel3.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            itemPanel3.Name = "itemPanel3";
            dataGridViewX_Job.AccessibleDescription = null;
            dataGridViewX_Job.AccessibleName = null;
            resources.ApplyResources(dataGridViewX_Job, "dataGridViewX_Job");
            dataGridViewX_Job.BackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewX_Job.BackgroundImage = null;
            dataGridViewX_Job.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            dataGridViewX_Job.Font = null;
            dataGridViewX_Job.ForeColor = System.Drawing.Color.Black;
            dataGridViewX_Job.HScrollBarVisible = false;
            dataGridViewX_Job.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            dataGridViewX_Job.Name = "dataGridViewX_Job";
            dataGridViewX_Job.PrimaryGrid.AllowRowHeaderResize = true;
            dataGridViewX_Job.PrimaryGrid.AllowRowResize = true;
            dataGridViewX_Job.PrimaryGrid.ColumnHeader.RowHeight = 30;
            dataGridViewX_Job.PrimaryGrid.ColumnHeader.SortImageAlignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            dataGridViewX_Job.PrimaryGrid.ColumnHeader.Visible = false;
            gridColumn7.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleLeft;
            gridColumn7.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridCheckBoxXEditControl);
            gridColumn7.FilterEditType = DevComponents.DotNetBar.SuperGrid.FilterEditType.None;
            gridColumn7.HeaderStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gridColumn7.HeaderText = null;
            gridColumn7.Name = "*";
            gridColumn7.Width = 50;
            gridColumn8.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleLeft;
            gridColumn8.ColumnSortMode = DevComponents.DotNetBar.SuperGrid.ColumnSortMode.None;
            gridColumn8.FilterAutoScan = true;
            gridColumn8.HeaderStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gridColumn8.HeaderText = null;
            gridColumn8.InfoImageAlignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gridColumn8.Name = "رقم / إسم الإدارة";
            gridColumn8.ReadOnly = true;
            gridColumn8.Width = 263;
            gridColumn9.HeaderText = null;
            gridColumn9.ReadOnly = true;
            gridColumn9.Visible = false;
            dataGridViewX_Job.PrimaryGrid.Columns.Add(gridColumn7);
            dataGridViewX_Job.PrimaryGrid.Columns.Add(gridColumn8);
            dataGridViewX_Job.PrimaryGrid.Columns.Add(gridColumn9);
            dataGridViewX_Job.PrimaryGrid.DefaultRowHeight = 24;
            background3.Color1 = System.Drawing.Color.White;
            background3.Color2 = System.Drawing.Color.FromArgb(255, 255, 192);
            dataGridViewX_Job.PrimaryGrid.DefaultVisualStyles.AlternateColumnCellStyles.Default.Background = background3;
            background4.Color1 = System.Drawing.Color.White;
            background4.Color2 = System.Drawing.Color.FromArgb(255, 255, 192);
            dataGridViewX_Job.PrimaryGrid.DefaultVisualStyles.AlternateRowCellStyles.Default.Background = background4;
            dataGridViewX_Job.PrimaryGrid.DefaultVisualStyles.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            dataGridViewX_Job.PrimaryGrid.DefaultVisualStyles.FilterColumnHeaderStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            dataGridViewX_Job.PrimaryGrid.EnableColumnFiltering = true;
            dataGridViewX_Job.PrimaryGrid.EnableFiltering = true;
            dataGridViewX_Job.PrimaryGrid.EnableRowFiltering = true;
            dataGridViewX_Job.PrimaryGrid.Filter.Visible = true;
            dataGridViewX_Job.PrimaryGrid.FilterLevel = DevComponents.DotNetBar.SuperGrid.FilterLevel.All;
            dataGridViewX_Job.PrimaryGrid.FilterMatchType = DevComponents.DotNetBar.SuperGrid.FilterMatchType.RegularExpressions;
            dataGridViewX_Job.PrimaryGrid.MultiSelect = false;
            dataGridViewX_Job.PrimaryGrid.NullString = "-----";
            dataGridViewX_Job.PrimaryGrid.RowHeaderWidth = 45;
            dataGridViewX_Job.PrimaryGrid.ShowColumnHeader = false;
            dataGridViewX_Job.PrimaryGrid.ShowRowGridIndex = true;
            dataGridViewX_Job.PrimaryGrid.ShowRowHeaders = false;
            dataGridViewX_Job.PrimaryGrid.UseAlternateRowStyle = true;
            expandablePanel_Section.AccessibleDescription = null;
            expandablePanel_Section.AccessibleName = null;
            resources.ApplyResources(expandablePanel_Section, "expandablePanel_Section");
            expandablePanel_Section.CanvasColor = System.Drawing.SystemColors.Control;
            expandablePanel_Section.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            expandablePanel_Section.Controls.Add(itemPanel2);
            expandablePanel_Section.Expanded = false;
            expandablePanel_Section.ExpandedBounds = new System.Drawing.Rectangle(0, 52, 314, 120);
            expandablePanel_Section.ExpandOnTitleClick = true;
            expandablePanel_Section.Name = "expandablePanel_Section";
            expandablePanel_Section.Style.Alignment = System.Drawing.StringAlignment.Center;
            expandablePanel_Section.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            expandablePanel_Section.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            expandablePanel_Section.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            expandablePanel_Section.Style.GradientAngle = 90;
            expandablePanel_Section.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            expandablePanel_Section.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            expandablePanel_Section.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            expandablePanel_Section.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            expandablePanel_Section.TitleStyle.GradientAngle = 90;
            expandablePanel_Section.TitleStyle.MarginLeft = 12;
            itemPanel2.AccessibleDescription = null;
            itemPanel2.AccessibleName = null;
            resources.ApplyResources(itemPanel2, "itemPanel2");
            itemPanel2.BackgroundImage = null;
            itemPanel2.BackgroundStyle.BackColor = System.Drawing.Color.AliceBlue;
            itemPanel2.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            itemPanel2.BackgroundStyle.BorderBottomWidth = 1;
            itemPanel2.BackgroundStyle.BorderColor = System.Drawing.Color.FromArgb(127, 157, 185);
            itemPanel2.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            itemPanel2.BackgroundStyle.BorderLeftWidth = 1;
            itemPanel2.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            itemPanel2.BackgroundStyle.BorderRightWidth = 1;
            itemPanel2.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            itemPanel2.BackgroundStyle.BorderTopWidth = 1;
            itemPanel2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            itemPanel2.BackgroundStyle.PaddingBottom = 1;
            itemPanel2.BackgroundStyle.PaddingLeft = 1;
            itemPanel2.BackgroundStyle.PaddingRight = 1;
            itemPanel2.BackgroundStyle.PaddingTop = 1;
            itemPanel2.ContainerControlProcessDialogKey = true;
            itemPanel2.Controls.Add(dataGridViewX_Section);
            itemPanel2.Font = null;
            itemPanel2.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            itemPanel2.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            itemPanel2.Name = "itemPanel2";
            dataGridViewX_Section.AccessibleDescription = null;
            dataGridViewX_Section.AccessibleName = null;
            resources.ApplyResources(dataGridViewX_Section, "dataGridViewX_Section");
            dataGridViewX_Section.BackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewX_Section.BackgroundImage = null;
            dataGridViewX_Section.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            dataGridViewX_Section.Font = null;
            dataGridViewX_Section.ForeColor = System.Drawing.Color.Black;
            dataGridViewX_Section.HScrollBarVisible = false;
            dataGridViewX_Section.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            dataGridViewX_Section.Name = "dataGridViewX_Section";
            dataGridViewX_Section.PrimaryGrid.AllowRowHeaderResize = true;
            dataGridViewX_Section.PrimaryGrid.AllowRowResize = true;
            dataGridViewX_Section.PrimaryGrid.ColumnHeader.RowHeight = 30;
            dataGridViewX_Section.PrimaryGrid.ColumnHeader.SortImageAlignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            dataGridViewX_Section.PrimaryGrid.ColumnHeader.Visible = false;
            gridColumn10.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleLeft;
            gridColumn10.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridCheckBoxXEditControl);
            gridColumn10.FilterEditType = DevComponents.DotNetBar.SuperGrid.FilterEditType.None;
            gridColumn10.HeaderStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gridColumn10.HeaderText = null;
            gridColumn10.Name = "*";
            gridColumn10.Width = 50;
            gridColumn11.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleLeft;
            gridColumn11.ColumnSortMode = DevComponents.DotNetBar.SuperGrid.ColumnSortMode.None;
            gridColumn11.FilterAutoScan = true;
            gridColumn11.HeaderStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gridColumn11.HeaderText = null;
            gridColumn11.InfoImageAlignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gridColumn11.Name = "رقم / إسم الإدارة";
            gridColumn11.ReadOnly = true;
            gridColumn11.Width = 263;
            gridColumn12.HeaderText = null;
            gridColumn12.ReadOnly = true;
            gridColumn12.Visible = false;
            dataGridViewX_Section.PrimaryGrid.Columns.Add(gridColumn10);
            dataGridViewX_Section.PrimaryGrid.Columns.Add(gridColumn11);
            dataGridViewX_Section.PrimaryGrid.Columns.Add(gridColumn12);
            dataGridViewX_Section.PrimaryGrid.DefaultRowHeight = 24;
            background5.Color1 = System.Drawing.Color.White;
            background5.Color2 = System.Drawing.Color.FromArgb(255, 255, 192);
            dataGridViewX_Section.PrimaryGrid.DefaultVisualStyles.AlternateColumnCellStyles.Default.Background = background5;
            background6.Color1 = System.Drawing.Color.White;
            background6.Color2 = System.Drawing.Color.FromArgb(255, 255, 192);
            dataGridViewX_Section.PrimaryGrid.DefaultVisualStyles.AlternateRowCellStyles.Default.Background = background6;
            dataGridViewX_Section.PrimaryGrid.DefaultVisualStyles.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            dataGridViewX_Section.PrimaryGrid.DefaultVisualStyles.FilterColumnHeaderStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            dataGridViewX_Section.PrimaryGrid.EnableColumnFiltering = true;
            dataGridViewX_Section.PrimaryGrid.EnableFiltering = true;
            dataGridViewX_Section.PrimaryGrid.EnableRowFiltering = true;
            dataGridViewX_Section.PrimaryGrid.Filter.Visible = true;
            dataGridViewX_Section.PrimaryGrid.FilterLevel = DevComponents.DotNetBar.SuperGrid.FilterLevel.All;
            dataGridViewX_Section.PrimaryGrid.FilterMatchType = DevComponents.DotNetBar.SuperGrid.FilterMatchType.RegularExpressions;
            dataGridViewX_Section.PrimaryGrid.MultiSelect = false;
            dataGridViewX_Section.PrimaryGrid.NullString = "-----";
            dataGridViewX_Section.PrimaryGrid.RowHeaderWidth = 45;
            dataGridViewX_Section.PrimaryGrid.ShowColumnHeader = false;
            dataGridViewX_Section.PrimaryGrid.ShowRowGridIndex = true;
            dataGridViewX_Section.PrimaryGrid.ShowRowHeaders = false;
            dataGridViewX_Section.PrimaryGrid.UseAlternateRowStyle = true;
            expandablePanel_Dept.AccessibleDescription = null;
            expandablePanel_Dept.AccessibleName = null;
            resources.ApplyResources(expandablePanel_Dept, "expandablePanel_Dept");
            expandablePanel_Dept.CanvasColor = System.Drawing.SystemColors.Control;
            expandablePanel_Dept.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            expandablePanel_Dept.Controls.Add(itemPanel1);
            expandablePanel_Dept.Expanded = false;
            expandablePanel_Dept.ExpandedBounds = new System.Drawing.Rectangle(0, 26, 314, 120);
            expandablePanel_Dept.ExpandOnTitleClick = true;
            expandablePanel_Dept.Name = "expandablePanel_Dept";
            expandablePanel_Dept.Style.Alignment = System.Drawing.StringAlignment.Center;
            expandablePanel_Dept.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            expandablePanel_Dept.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            expandablePanel_Dept.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            expandablePanel_Dept.Style.GradientAngle = 90;
            expandablePanel_Dept.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            expandablePanel_Dept.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            expandablePanel_Dept.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            expandablePanel_Dept.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            expandablePanel_Dept.TitleStyle.GradientAngle = 90;
            expandablePanel_Dept.TitleStyle.MarginLeft = 12;
            itemPanel1.AccessibleDescription = null;
            itemPanel1.AccessibleName = null;
            resources.ApplyResources(itemPanel1, "itemPanel1");
            itemPanel1.BackgroundImage = null;
            itemPanel1.BackgroundStyle.BackColor = System.Drawing.Color.AliceBlue;
            itemPanel1.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            itemPanel1.BackgroundStyle.BorderBottomWidth = 1;
            itemPanel1.BackgroundStyle.BorderColor = System.Drawing.Color.FromArgb(127, 157, 185);
            itemPanel1.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            itemPanel1.BackgroundStyle.BorderLeftWidth = 1;
            itemPanel1.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            itemPanel1.BackgroundStyle.BorderRightWidth = 1;
            itemPanel1.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            itemPanel1.BackgroundStyle.BorderTopWidth = 1;
            itemPanel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            itemPanel1.BackgroundStyle.PaddingBottom = 1;
            itemPanel1.BackgroundStyle.PaddingLeft = 1;
            itemPanel1.BackgroundStyle.PaddingRight = 1;
            itemPanel1.BackgroundStyle.PaddingTop = 1;
            itemPanel1.ContainerControlProcessDialogKey = true;
            itemPanel1.Controls.Add(dataGridViewX_Dept);
            itemPanel1.Font = null;
            itemPanel1.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            itemPanel1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            itemPanel1.Name = "itemPanel1";
            dataGridViewX_Dept.AccessibleDescription = null;
            dataGridViewX_Dept.AccessibleName = null;
            resources.ApplyResources(dataGridViewX_Dept, "dataGridViewX_Dept");
            dataGridViewX_Dept.BackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewX_Dept.BackgroundImage = null;
            dataGridViewX_Dept.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            dataGridViewX_Dept.Font = null;
            dataGridViewX_Dept.ForeColor = System.Drawing.Color.Black;
            dataGridViewX_Dept.HScrollBarVisible = false;
            dataGridViewX_Dept.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            dataGridViewX_Dept.Name = "dataGridViewX_Dept";
            dataGridViewX_Dept.PrimaryGrid.AllowRowHeaderResize = true;
            dataGridViewX_Dept.PrimaryGrid.AllowRowResize = true;
            dataGridViewX_Dept.PrimaryGrid.ColumnHeader.RowHeight = 30;
            dataGridViewX_Dept.PrimaryGrid.ColumnHeader.SortImageAlignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            dataGridViewX_Dept.PrimaryGrid.ColumnHeader.Visible = false;
            gridColumn2.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleLeft;
            gridColumn2.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridCheckBoxXEditControl);
            gridColumn2.FilterEditType = DevComponents.DotNetBar.SuperGrid.FilterEditType.None;
            gridColumn2.HeaderStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gridColumn2.HeaderText = null;
            gridColumn2.Name = "*";
            gridColumn2.Width = 50;
            gridColumn3.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleLeft;
            gridColumn3.ColumnSortMode = DevComponents.DotNetBar.SuperGrid.ColumnSortMode.None;
            gridColumn3.FilterAutoScan = true;
            gridColumn3.HeaderStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gridColumn3.HeaderText = null;
            gridColumn3.InfoImageAlignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gridColumn3.Name = "رقم / إسم الإدارة";
            gridColumn3.ReadOnly = true;
            gridColumn3.Width = 263;
            gridColumn4.HeaderText = null;
            gridColumn4.ReadOnly = true;
            gridColumn4.Visible = false;
            dataGridViewX_Dept.PrimaryGrid.Columns.Add(gridColumn2);
            dataGridViewX_Dept.PrimaryGrid.Columns.Add(gridColumn3);
            dataGridViewX_Dept.PrimaryGrid.Columns.Add(gridColumn4);
            dataGridViewX_Dept.PrimaryGrid.DefaultRowHeight = 24;
            background7.Color1 = System.Drawing.Color.White;
            background7.Color2 = System.Drawing.Color.FromArgb(255, 255, 192);
            dataGridViewX_Dept.PrimaryGrid.DefaultVisualStyles.AlternateColumnCellStyles.Default.Background = background7;
            background8.Color1 = System.Drawing.Color.White;
            background8.Color2 = System.Drawing.Color.FromArgb(255, 255, 192);
            dataGridViewX_Dept.PrimaryGrid.DefaultVisualStyles.AlternateRowCellStyles.Default.Background = background8;
            dataGridViewX_Dept.PrimaryGrid.DefaultVisualStyles.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            dataGridViewX_Dept.PrimaryGrid.DefaultVisualStyles.FilterColumnHeaderStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            dataGridViewX_Dept.PrimaryGrid.EnableColumnFiltering = true;
            dataGridViewX_Dept.PrimaryGrid.EnableFiltering = true;
            dataGridViewX_Dept.PrimaryGrid.EnableRowFiltering = true;
            dataGridViewX_Dept.PrimaryGrid.Filter.Visible = true;
            dataGridViewX_Dept.PrimaryGrid.FilterLevel = DevComponents.DotNetBar.SuperGrid.FilterLevel.All;
            dataGridViewX_Dept.PrimaryGrid.FilterMatchType = DevComponents.DotNetBar.SuperGrid.FilterMatchType.RegularExpressions;
            dataGridViewX_Dept.PrimaryGrid.MultiSelect = false;
            dataGridViewX_Dept.PrimaryGrid.NullString = "-----";
            dataGridViewX_Dept.PrimaryGrid.RowHeaderWidth = 45;
            dataGridViewX_Dept.PrimaryGrid.ShowColumnHeader = false;
            dataGridViewX_Dept.PrimaryGrid.ShowRowGridIndex = true;
            dataGridViewX_Dept.PrimaryGrid.ShowRowHeaders = false;
            dataGridViewX_Dept.PrimaryGrid.UseAlternateRowStyle = true;
            ButExit.AccessibleDescription = null;
            ButExit.AccessibleName = null;
            ButExit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            resources.ApplyResources(ButExit, "ButExit");
            ButExit.BackgroundImage = null;
            ButExit.Checked = true;
            ButExit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            ButExit.CommandParameter = null;
            ButExit.Name = "ButExit";
            ButExit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            ButExit.Symbol = "\uf011";
            ButExit.SymbolSize = 16f;
            ButExit.TextColor = System.Drawing.Color.Black;
            ButExit.Click += new System.EventHandler(ButExit_Click);
            ButOk.AccessibleDescription = null;
            ButOk.AccessibleName = null;
            ButOk.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            resources.ApplyResources(ButOk, "ButOk");
            ButOk.BackgroundImage = null;
            ButOk.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            ButOk.CommandParameter = null;
            ButOk.Name = "ButOk";
            ButOk.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            ButOk.Symbol = "\uf0c5";
            ButOk.SymbolSize = 16f;
            ButOk.TextColor = System.Drawing.Color.White;
            ButOk.Click += new System.EventHandler(ButOk_Click);
            groupBox_Date.AccessibleDescription = null;
            groupBox_Date.AccessibleName = null;
            resources.ApplyResources(groupBox_Date, "groupBox_Date");
            groupBox_Date.BackColor = System.Drawing.Color.Transparent;
            groupBox_Date.BackgroundImage = null;
            groupBox_Date.Controls.Add(textBox_SalDateFrom);
            groupBox_Date.ForeColor = System.Drawing.Color.Navy;
            groupBox_Date.Name = "groupBox_Date";
            groupBox_Date.TabStop = false;
            textBox_SalDateFrom.AccessibleDescription = null;
            textBox_SalDateFrom.AccessibleName = null;
            resources.ApplyResources(textBox_SalDateFrom, "textBox_SalDateFrom");
            textBox_SalDateFrom.BackColor = System.Drawing.Color.DarkSeaGreen;
            textBox_SalDateFrom.BackgroundImage = null;
            textBox_SalDateFrom.Font = null;
            textBox_SalDateFrom.Name = "textBox_SalDateFrom";
            textBox_SalDateFrom.Leave += new System.EventHandler(textBox_SalDateFrom_Leave);
            textBox_SalDateFrom.Click += new System.EventHandler(textBox_SalDateFrom_Click);
            groupBox1.AccessibleDescription = null;
            groupBox1.AccessibleName = null;
            resources.ApplyResources(groupBox1, "groupBox1");
            groupBox1.BackColor = System.Drawing.Color.Transparent;
            groupBox1.BackgroundImage = null;
            groupBox1.Controls.Add(textBox_SalDateTo);
            groupBox1.ForeColor = System.Drawing.Color.Navy;
            groupBox1.Name = "groupBox1";
            groupBox1.TabStop = false;
            textBox_SalDateTo.AccessibleDescription = null;
            textBox_SalDateTo.AccessibleName = null;
            resources.ApplyResources(textBox_SalDateTo, "textBox_SalDateTo");
            textBox_SalDateTo.BackColor = System.Drawing.Color.DarkSeaGreen;
            textBox_SalDateTo.BackgroundImage = null;
            textBox_SalDateTo.Font = null;
            textBox_SalDateTo.Name = "textBox_SalDateTo";
            textBox_SalDateTo.Leave += new System.EventHandler(textBox_SalDateTo_Leave);
            textBox_SalDateTo.Click += new System.EventHandler(textBox_SalDateTo_Click);
            base.AccessibleDescription = null;
            base.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackgroundImage = null;
            base.Controls.Add(ribbonBar1);
            Font = null;
            base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            base.Icon = null;
            base.KeyPreview = true;
            base.MaximizeBox = false;
            base.Name = "FrmRepSalary";
            base.ShowIcon = false;
            base.Load += new System.EventHandler(FrmRepSalary_Load);
            base.KeyPress += new System.Windows.Forms.KeyPressEventHandler(FrmRepSalary_KeyPress);
            base.KeyDown += new System.Windows.Forms.KeyEventHandler(FrmRepSalary_KeyDown);
            ribbonBar1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            expandablePanel_Girds.ResumeLayout(false);
            expandablePanel_Emp.ResumeLayout(false);
            itemPanel4.ResumeLayout(false);
            expandablePanel_Job.ResumeLayout(false);
            itemPanel3.ResumeLayout(false);
            expandablePanel_Section.ResumeLayout(false);
            itemPanel2.ResumeLayout(false);
            expandablePanel_Dept.ResumeLayout(false);
            itemPanel1.ResumeLayout(false);
            groupBox_Date.ResumeLayout(false);
            groupBox_Date.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }
        public FrmRepSalary()
        {
            InitializeComponent();
            expandablePanel_Dept.ExpandedChanging += expandablePanel_Dept_ExpandedChanging;
            expandablePanel_Emp.ExpandedChanging += expandablePanel_Emp_ExpandedChanging;
            expandablePanel_Section.ExpandedChanging += expandablePanel_Section_ExpandedChanging;
            expandablePanel_Job.ExpandedChanging += expandablePanel_Job_ExpandedChanging;
        }
        private void RibunButtons()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                ButOk.Text = ((VarGeneral.GeneralPrinter.nTyp_Setting.Substring(2, 1) == "0") ? "طبـــاعة F5" : "عــــرض F5");
                ButExit.Text = "خـــروج Esc";
                expandablePanel_Dept.Text = "الإدارة";
                expandablePanel_Section.Text = "القسم";
                expandablePanel_Job.Text = "الوظيفة";
                expandablePanel_Emp.Text = "الموظف";
                expandablePanel_Girds.TitleText = "على حسب";
                Text = "تقرير الــــرواتب";
            }
            else
            {
                ButOk.Text = ((VarGeneral.GeneralPrinter.nTyp_Setting.Substring(2, 1) == "0") ? "Print F5" : "Show F5");
                ButExit.Text = "Close Esc";
                expandablePanel_Dept.Text = "Department";
                expandablePanel_Section.Text = "Section";
                expandablePanel_Job.Text = "Job";
                expandablePanel_Emp.Text = "Employee";
                expandablePanel_Girds.TitleText = "depend on";
                Text = "Salary Report";
            }
        }
        private void FrmRepSalary_Load(object sender, EventArgs e)
        {
            try
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmRepSalary));
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
                int? calendr = VarGeneral.Settings_Sys.Calendr;
                if (calendr.Value == 0 && calendr.HasValue)
                {
                    textBox_SalDateFrom.Text = n.FormatGreg(VarGeneral.Gdate, "yyyy/MM");
                    textBox_SalDateTo.Text = n.FormatGreg(VarGeneral.Gdate, "yyyy/MM");
                }
                else
                {
                    textBox_SalDateFrom.Text = n.FormatHijri(VarGeneral.Hdate, "yyyy/MM");
                    textBox_SalDateTo.Text = n.FormatHijri(VarGeneral.Hdate, "yyyy/MM");
                }
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
        private void FillGrid()
        {
            dataGridViewX_Dept.PrimaryGrid.Rows.Clear();
            dataGridViewX_Emp.PrimaryGrid.Rows.Clear();
            dataGridViewX_Job.PrimaryGrid.Rows.Clear();
            dataGridViewX_Section.PrimaryGrid.Rows.Clear();
            GridRow row = new GridRow();
            List<T_Emp> listEmp = db.FillEmps_2("").ToList();
            for (int i = 0; i < listEmp.Count; i++)
            {
                row = new GridRow();
                row.Cells.Add(new GridCell(""));
                row.Cells.Add(new GridCell(""));
                row.Cells.Add(new GridCell(""));
                dataGridViewX_Emp.PrimaryGrid.Rows.Add(row);
                dataGridViewX_Emp.PrimaryGrid.GetCell(i, 1).Value = ((LangArEn == 0) ? listEmp[i].NameA.ToString() : listEmp[i].NameE.ToString());
                dataGridViewX_Emp.PrimaryGrid.GetCell(i, 2).Value = listEmp[i].Emp_ID.ToString();
            }
            List<T_Dept> listDept = db.FillDept_2("").ToList();
            for (int i = 0; i < listDept.Count; i++)
            {
                row = new GridRow();
                row.Cells.Add(new GridCell(""));
                row.Cells.Add(new GridCell(""));
                row.Cells.Add(new GridCell(""));
                dataGridViewX_Dept.PrimaryGrid.Rows.Add(row);
                dataGridViewX_Dept.PrimaryGrid.GetCell(i, 1).Value = ((LangArEn == 0) ? listDept[i].NameA.ToString() : listDept[i].NameE.ToString());
                dataGridViewX_Dept.PrimaryGrid.GetCell(i, 2).Value = listDept[i].Dept_No.ToString();
            }
            List<T_Section> listSection = db.FillSection_2("").ToList();
            for (int i = 0; i < listSection.Count; i++)
            {
                row = new GridRow();
                row.Cells.Add(new GridCell(""));
                row.Cells.Add(new GridCell(""));
                row.Cells.Add(new GridCell(""));
                dataGridViewX_Section.PrimaryGrid.Rows.Add(row);
                dataGridViewX_Section.PrimaryGrid.GetCell(i, 1).Value = ((LangArEn == 0) ? listSection[i].NameA.ToString() : listSection[i].NameE.ToString());
                dataGridViewX_Section.PrimaryGrid.GetCell(i, 2).Value = listSection[i].Section_No.ToString();
            }
            List<T_Job> listJob = db.FillJob_2("").ToList();
            for (int i = 0; i < listJob.Count; i++)
            {
                row = new GridRow();
                row.Cells.Add(new GridCell(""));
                row.Cells.Add(new GridCell(""));
                row.Cells.Add(new GridCell(""));
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
            expandablePanel_Dept.Expanded = false;
            expandablePanel_Emp.Expanded = false;
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
        private void FrmRepSalary_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                SendKeys.Send("{Tab}");
            }
        }
        private void FrmRepSalary_KeyDown(object sender, KeyEventArgs e)
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
        private void textBox_SalDateFrom_Leave(object sender, EventArgs e)
        {
            try
            {
                textBox_SalDateFrom.Text = Convert.ToDateTime(textBox_SalDateFrom.Text).ToString("yyyy/MM");
            }
            catch
            {
                int? calendr = VarGeneral.Settings_Sys.Calendr;
                if (calendr.Value == 0 && calendr.HasValue)
                {
                    textBox_SalDateFrom.Text = n.FormatGreg(VarGeneral.Gdate, "yyyy/MM");
                }
                else
                {
                    textBox_SalDateFrom.Text = n.FormatHijri(VarGeneral.Hdate, "yyyy/MM");
                }
            }
        }
        private void textBox_SalDateTo_Leave(object sender, EventArgs e)
        {
            try
            {
                textBox_SalDateTo.Text = Convert.ToDateTime(textBox_SalDateTo.Text).ToString("yyyy/MM");
            }
            catch
            {
                int? calendr = VarGeneral.Settings_Sys.Calendr;
                if (calendr.Value == 0 && calendr.HasValue)
                {
                    textBox_SalDateTo.Text = n.FormatGreg(VarGeneral.Gdate, "yyyy/MM");
                }
                else
                {
                    textBox_SalDateTo.Text = n.FormatHijri(VarGeneral.Hdate, "yyyy/MM");
                }
            }
        }
        private void ButExit_Click(object sender, EventArgs e)
        {
            Close();
        }
        private string GetSqlWhere()
        {
            string QStr = "";
            string tmpStr = "";
            string[] GetSql = getDeptNo();
            for (int num2 = 0; num2 < GetSql.Length; num2++)
            {
                if (!string.IsNullOrEmpty(GetSql[num2]))
                {
                    tmpStr = ((!string.IsNullOrEmpty(tmpStr)) ? (tmpStr + " OR ") : (tmpStr + " AND ( "));
                    tmpStr = tmpStr + " ( T_Emp.Dept = " + GetSql[num2].Trim() + " ) ";
                }
            }
            QStr += ((tmpStr != "") ? (tmpStr + " )") : "");
            tmpStr = "";
            GetSql = getEmpNo();
            for (int num2 = 0; num2 < GetSql.Length; num2++)
            {
                if (!string.IsNullOrEmpty(GetSql[num2]))
                {
                    tmpStr = ((!string.IsNullOrEmpty(tmpStr)) ? (tmpStr + " OR ") : (tmpStr + " AND ( "));
                    tmpStr = tmpStr + " ( T_Emp.Emp_ID = '" + GetSql[num2].Trim() + "' ) ";
                }
            }
            QStr += ((tmpStr != "") ? (tmpStr + " )") : "");
            tmpStr = "";
            GetSql = getJobNo();
            for (int num2 = 0; num2 < GetSql.Length; num2++)
            {
                if (!string.IsNullOrEmpty(GetSql[num2]))
                {
                    tmpStr = ((!string.IsNullOrEmpty(tmpStr)) ? (tmpStr + " OR ") : (tmpStr + " AND ( "));
                    tmpStr = tmpStr + " ( T_Emp.Job = " + GetSql[num2].Trim() + " ) ";
                }
            }
            QStr += ((tmpStr != "") ? (tmpStr + " )") : "");
            tmpStr = "";
            GetSql = getSectionNo();
            for (int num2 = 0; num2 < GetSql.Length; num2++)
            {
                if (!string.IsNullOrEmpty(GetSql[num2]))
                {
                    tmpStr = ((!string.IsNullOrEmpty(tmpStr)) ? (tmpStr + " OR ") : (tmpStr + " AND ( "));
                    tmpStr = tmpStr + " ( T_Emp.Section = " + GetSql[num2].Trim() + " ) ";
                }
            }
            QStr += ((tmpStr != "") ? (tmpStr + " )") : "");
            tmpStr = "";
            if (textBox_SalDateFrom.Text != "    /" && textBox_SalDateFrom.Text.Length == 7)
            {
                QStr = QStr + " AND CONVERT(varchar(10),SalYear) + '/' + CONVERT(varchar(10),SalMonth) >= '" + Convert.ToDateTime(textBox_SalDateFrom.Text).ToString("yyyy/M") + "'";
            }
            if (textBox_SalDateTo.Text != "    /" && textBox_SalDateTo.Text.Length == 7)
            {
                QStr = QStr + " AND CONVERT(varchar(10),SalYear) + '/' + CONVERT(varchar(10),SalMonth) <= '" + Convert.ToDateTime(textBox_SalDateTo.Text).ToString("yyyy/M") + "'";
            }
            return QStr;
        }
        private void textBox_SalDateFrom_Click(object sender, EventArgs e)
        {
            textBox_SalDateFrom.SelectAll();
        }
        private void textBox_SalDateTo_Click(object sender, EventArgs e)
        {
            textBox_SalDateTo.SelectAll();
        }
        private void ButOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox_SalDateFrom.Text == "    /" || textBox_SalDateFrom.Text.Length != 7)
                {
                    MessageBox.Show("تاكد من تاريخ الشهر الأول", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    textBox_SalDateFrom.Focus();
                    return;
                }
                if (textBox_SalDateTo.Text == "    /" || textBox_SalDateTo.Text.Length != 7)
                {
                    MessageBox.Show("تاكد من تاريخ الشهر الأخير", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    textBox_SalDateTo.Focus();
                    return;
                }
                if (Convert.ToDateTime(textBox_SalDateFrom.Text) > Convert.ToDateTime(textBox_SalDateTo.Text))
                {
                    MessageBox.Show("تاريخ البداية أكبر من تاريخ النهاية", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    textBox_SalDateTo.Focus();
                    return;
                }
                VarGeneral.IsGeneralUsed = true;
                FrmReportsViewer frm = new FrmReportsViewer();
                frm.Repvalue = "EmpsSalRep";



                frm.Tag = LangArEn;
                frm.Repvalue = "EmpsSalRep";
                frm.SqlWhere = GetSqlWhere();
                VarGeneral.vTitle = Text;
                VarGeneral.dtFrom = textBox_SalDateFrom.Text;
                VarGeneral.dtTo = textBox_SalDateTo.Text;
                frm.TopMost = true;
                frm.ShowDialog();
                VarGeneral.IsGeneralUsed = false;

            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("FrmSalaryRep_Load:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
    }
}
