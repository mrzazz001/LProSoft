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
    public partial class FrmRepPassport : Form
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
                        frm.Repvalue = "PassportRep";


                        frm.Repvalue = "PassportRep";
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
        private GroupBox groupBox1;
        private TextBoxX textBox_EmpTo;
        private TextBoxX textBox_EmpFrom;
        private Label label1;
        private Label label5;
        private GroupBox groupBox_Date;
        private MaskedTextBox dateTimeInput_StartVacationTo;
        private MaskedTextBox dateTimeInput_StartVacationFrom;
        private Label label3;
        private Label label4;
        private GroupBox groupBox2;
        private MaskedTextBox dateTimeInput_EndVacationTo;
        private MaskedTextBox dateTimeInput_EndVacationFrom;
        private Label label2;
        private Label label6;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InvAcc.Forms.FrmRepPassport));
            this.PanelSpecialContainer = new System.Windows.Forms.Panel();
            components = new System.ComponentModel.Container();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn13 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn14 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn15 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.Style.Background background17 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.Style.Background background10 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn16 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn17 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn18 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.Style.Background background11 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.Style.Background background12 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn19 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn20 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn21 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.Style.Background background13 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.Style.Background background14 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn22 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn23 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn24 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.Style.Background background15 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.Style.Background background16 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
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
            groupBox_Date = new System.Windows.Forms.GroupBox();
            dateTimeInput_StartVacationTo = new System.Windows.Forms.MaskedTextBox();
            dateTimeInput_StartVacationFrom = new System.Windows.Forms.MaskedTextBox();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            ButExit = new DevComponents.DotNetBar.ButtonX();
            ButOk = new DevComponents.DotNetBar.ButtonX();
            groupBox2 = new System.Windows.Forms.GroupBox();
            dateTimeInput_EndVacationTo = new System.Windows.Forms.MaskedTextBox();
            dateTimeInput_EndVacationFrom = new System.Windows.Forms.MaskedTextBox();
            label2 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            groupBox1 = new System.Windows.Forms.GroupBox();
            textBox_EmpTo = new DevComponents.DotNetBar.Controls.TextBoxX();
            textBox_EmpFrom = new DevComponents.DotNetBar.Controls.TextBoxX();
            label1 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            this.netResize1 = new Softgroup.NetResize.NetResize(this.components);
            this.netResize1.AfterControlResize += new Softgroup.NetResize.NetResize.AfterControlResizeEventHandler(this.netResize1_AfterControlResize);
            this.Shown += new System.EventHandler(this.FrmInvSale_Shown);
            this.SizeChanged += new System.EventHandler(this.FrmInvSale_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).BeginInit();
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
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
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
            panel1.Controls.Add(expandablePanel_Girds);
            panel1.Controls.Add(groupBox_Date);
            panel1.Controls.Add(ButExit);
            panel1.Controls.Add(ButOk);
            panel1.Controls.Add(groupBox2);
            panel1.Controls.Add(groupBox1);
            resources.ApplyResources(panel1, "panel1");
            panel1.Name = "panel1";
            expandablePanel_Girds.CanvasColor = System.Drawing.SystemColors.Control;
            expandablePanel_Girds.CollapseDirection = DevComponents.DotNetBar.eCollapseDirection.RightToLeft;
            expandablePanel_Girds.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            expandablePanel_Girds.Controls.Add(expandablePanel_Emp);
            expandablePanel_Girds.Controls.Add(expandablePanel_Job);
            expandablePanel_Girds.Controls.Add(expandablePanel_Section);
            expandablePanel_Girds.Controls.Add(expandablePanel_Dept);
            resources.ApplyResources(expandablePanel_Girds, "expandablePanel_Girds");
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
            expandablePanel_Emp.CanvasColor = System.Drawing.SystemColors.Control;
            expandablePanel_Emp.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            expandablePanel_Emp.Controls.Add(itemPanel4);
            resources.ApplyResources(expandablePanel_Emp, "expandablePanel_Emp");
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
            resources.ApplyResources(itemPanel4, "itemPanel4");
            itemPanel4.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            itemPanel4.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            itemPanel4.Name = "itemPanel4";
            dataGridViewX_Emp.BackColor = System.Drawing.SystemColors.ControlLight;
            resources.ApplyResources(dataGridViewX_Emp, "dataGridViewX_Emp");
            dataGridViewX_Emp.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            dataGridViewX_Emp.ForeColor = System.Drawing.Color.Black;
            dataGridViewX_Emp.HScrollBarVisible = false;
            dataGridViewX_Emp.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            dataGridViewX_Emp.Name = "dataGridViewX_Emp";
            dataGridViewX_Emp.PrimaryGrid.AllowRowHeaderResize = true;
            dataGridViewX_Emp.PrimaryGrid.AllowRowResize = true;
            dataGridViewX_Emp.PrimaryGrid.ColumnHeader.RowHeight = 30;
            dataGridViewX_Emp.PrimaryGrid.ColumnHeader.SortImageAlignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            dataGridViewX_Emp.PrimaryGrid.ColumnHeader.Visible = false;
            gridColumn13.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleLeft;
            gridColumn13.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridCheckBoxXEditControl);
            gridColumn13.FilterEditType = DevComponents.DotNetBar.SuperGrid.FilterEditType.None;
            gridColumn13.HeaderStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gridColumn13.Name = "*";
            gridColumn13.Width = 50;
            gridColumn14.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleLeft;
            gridColumn14.ColumnSortMode = DevComponents.DotNetBar.SuperGrid.ColumnSortMode.None;
            gridColumn14.FilterAutoScan = true;
            gridColumn14.HeaderStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gridColumn14.InfoImageAlignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gridColumn14.Name = "?????? / ?????? ??????????????";
            gridColumn14.ReadOnly = true;
            gridColumn14.Width = 263;
            gridColumn15.ReadOnly = true;
            gridColumn15.Visible = false;
            dataGridViewX_Emp.PrimaryGrid.Columns.Add(gridColumn13);
            dataGridViewX_Emp.PrimaryGrid.Columns.Add(gridColumn14);
            dataGridViewX_Emp.PrimaryGrid.Columns.Add(gridColumn15);
            dataGridViewX_Emp.PrimaryGrid.DefaultRowHeight = 24;
            background17.Color1 = System.Drawing.Color.White;
            background17.Color2 = System.Drawing.Color.FromArgb(255, 255, 192);
            dataGridViewX_Emp.PrimaryGrid.DefaultVisualStyles.AlternateColumnCellStyles.Default.Background = background17;
            background10.Color1 = System.Drawing.Color.White;
            background10.Color2 = System.Drawing.Color.FromArgb(255, 255, 192);
            dataGridViewX_Emp.PrimaryGrid.DefaultVisualStyles.AlternateRowCellStyles.Default.Background = background10;
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
            expandablePanel_Job.CanvasColor = System.Drawing.SystemColors.Control;
            expandablePanel_Job.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            expandablePanel_Job.Controls.Add(itemPanel3);
            resources.ApplyResources(expandablePanel_Job, "expandablePanel_Job");
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
            resources.ApplyResources(itemPanel3, "itemPanel3");
            itemPanel3.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            itemPanel3.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            itemPanel3.Name = "itemPanel3";
            dataGridViewX_Job.BackColor = System.Drawing.SystemColors.ControlLight;
            resources.ApplyResources(dataGridViewX_Job, "dataGridViewX_Job");
            dataGridViewX_Job.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            dataGridViewX_Job.ForeColor = System.Drawing.Color.Black;
            dataGridViewX_Job.HScrollBarVisible = false;
            dataGridViewX_Job.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            dataGridViewX_Job.Name = "dataGridViewX_Job";
            dataGridViewX_Job.PrimaryGrid.AllowRowHeaderResize = true;
            dataGridViewX_Job.PrimaryGrid.AllowRowResize = true;
            dataGridViewX_Job.PrimaryGrid.ColumnHeader.RowHeight = 30;
            dataGridViewX_Job.PrimaryGrid.ColumnHeader.SortImageAlignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            dataGridViewX_Job.PrimaryGrid.ColumnHeader.Visible = false;
            gridColumn16.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleLeft;
            gridColumn16.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridCheckBoxXEditControl);
            gridColumn16.FilterEditType = DevComponents.DotNetBar.SuperGrid.FilterEditType.None;
            gridColumn16.HeaderStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gridColumn16.Name = "*";
            gridColumn16.Width = 50;
            gridColumn17.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleLeft;
            gridColumn17.ColumnSortMode = DevComponents.DotNetBar.SuperGrid.ColumnSortMode.None;
            gridColumn17.FilterAutoScan = true;
            gridColumn17.HeaderStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gridColumn17.InfoImageAlignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gridColumn17.Name = "?????? / ?????? ??????????????";
            gridColumn17.ReadOnly = true;
            gridColumn17.Width = 263;
            gridColumn18.ReadOnly = true;
            gridColumn18.Visible = false;
            dataGridViewX_Job.PrimaryGrid.Columns.Add(gridColumn16);
            dataGridViewX_Job.PrimaryGrid.Columns.Add(gridColumn17);
            dataGridViewX_Job.PrimaryGrid.Columns.Add(gridColumn18);
            dataGridViewX_Job.PrimaryGrid.DefaultRowHeight = 24;
            background11.Color1 = System.Drawing.Color.White;
            background11.Color2 = System.Drawing.Color.FromArgb(255, 255, 192);
            dataGridViewX_Job.PrimaryGrid.DefaultVisualStyles.AlternateColumnCellStyles.Default.Background = background11;
            background12.Color1 = System.Drawing.Color.White;
            background12.Color2 = System.Drawing.Color.FromArgb(255, 255, 192);
            dataGridViewX_Job.PrimaryGrid.DefaultVisualStyles.AlternateRowCellStyles.Default.Background = background12;
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
            expandablePanel_Section.CanvasColor = System.Drawing.SystemColors.Control;
            expandablePanel_Section.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            expandablePanel_Section.Controls.Add(itemPanel2);
            resources.ApplyResources(expandablePanel_Section, "expandablePanel_Section");
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
            resources.ApplyResources(itemPanel2, "itemPanel2");
            itemPanel2.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            itemPanel2.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            itemPanel2.Name = "itemPanel2";
            dataGridViewX_Section.BackColor = System.Drawing.SystemColors.ControlLight;
            resources.ApplyResources(dataGridViewX_Section, "dataGridViewX_Section");
            dataGridViewX_Section.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            dataGridViewX_Section.ForeColor = System.Drawing.Color.Black;
            dataGridViewX_Section.HScrollBarVisible = false;
            dataGridViewX_Section.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            dataGridViewX_Section.Name = "dataGridViewX_Section";
            dataGridViewX_Section.PrimaryGrid.AllowRowHeaderResize = true;
            dataGridViewX_Section.PrimaryGrid.AllowRowResize = true;
            dataGridViewX_Section.PrimaryGrid.ColumnHeader.RowHeight = 30;
            dataGridViewX_Section.PrimaryGrid.ColumnHeader.SortImageAlignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            dataGridViewX_Section.PrimaryGrid.ColumnHeader.Visible = false;
            gridColumn19.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleLeft;
            gridColumn19.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridCheckBoxXEditControl);
            gridColumn19.FilterEditType = DevComponents.DotNetBar.SuperGrid.FilterEditType.None;
            gridColumn19.HeaderStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gridColumn19.Name = "*";
            gridColumn19.Width = 50;
            gridColumn20.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleLeft;
            gridColumn20.ColumnSortMode = DevComponents.DotNetBar.SuperGrid.ColumnSortMode.None;
            gridColumn20.FilterAutoScan = true;
            gridColumn20.HeaderStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gridColumn20.InfoImageAlignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gridColumn20.Name = "?????? / ?????? ??????????????";
            gridColumn20.ReadOnly = true;
            gridColumn20.Width = 263;
            gridColumn21.ReadOnly = true;
            gridColumn21.Visible = false;
            dataGridViewX_Section.PrimaryGrid.Columns.Add(gridColumn19);
            dataGridViewX_Section.PrimaryGrid.Columns.Add(gridColumn20);
            dataGridViewX_Section.PrimaryGrid.Columns.Add(gridColumn21);
            dataGridViewX_Section.PrimaryGrid.DefaultRowHeight = 24;
            background13.Color1 = System.Drawing.Color.White;
            background13.Color2 = System.Drawing.Color.FromArgb(255, 255, 192);
            dataGridViewX_Section.PrimaryGrid.DefaultVisualStyles.AlternateColumnCellStyles.Default.Background = background13;
            background14.Color1 = System.Drawing.Color.White;
            background14.Color2 = System.Drawing.Color.FromArgb(255, 255, 192);
            dataGridViewX_Section.PrimaryGrid.DefaultVisualStyles.AlternateRowCellStyles.Default.Background = background14;
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
            expandablePanel_Dept.CanvasColor = System.Drawing.SystemColors.Control;
            expandablePanel_Dept.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            expandablePanel_Dept.Controls.Add(itemPanel1);
            resources.ApplyResources(expandablePanel_Dept, "expandablePanel_Dept");
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
            resources.ApplyResources(itemPanel1, "itemPanel1");
            itemPanel1.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            itemPanel1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            itemPanel1.Name = "itemPanel1";
            dataGridViewX_Dept.BackColor = System.Drawing.SystemColors.ControlLight;
            resources.ApplyResources(dataGridViewX_Dept, "dataGridViewX_Dept");
            dataGridViewX_Dept.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            dataGridViewX_Dept.ForeColor = System.Drawing.Color.Black;
            dataGridViewX_Dept.HScrollBarVisible = false;
            dataGridViewX_Dept.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            dataGridViewX_Dept.Name = "dataGridViewX_Dept";
            dataGridViewX_Dept.PrimaryGrid.AllowRowHeaderResize = true;
            dataGridViewX_Dept.PrimaryGrid.AllowRowResize = true;
            dataGridViewX_Dept.PrimaryGrid.ColumnHeader.RowHeight = 30;
            dataGridViewX_Dept.PrimaryGrid.ColumnHeader.SortImageAlignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            dataGridViewX_Dept.PrimaryGrid.ColumnHeader.Visible = false;
            gridColumn22.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleLeft;
            gridColumn22.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridCheckBoxXEditControl);
            gridColumn22.FilterEditType = DevComponents.DotNetBar.SuperGrid.FilterEditType.None;
            gridColumn22.HeaderStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gridColumn22.Name = "*";
            gridColumn22.Width = 50;
            gridColumn23.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleLeft;
            gridColumn23.ColumnSortMode = DevComponents.DotNetBar.SuperGrid.ColumnSortMode.None;
            gridColumn23.FilterAutoScan = true;
            gridColumn23.HeaderStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gridColumn23.InfoImageAlignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gridColumn23.Name = "?????? / ?????? ??????????????";
            gridColumn23.ReadOnly = true;
            gridColumn23.Width = 263;
            gridColumn24.ReadOnly = true;
            gridColumn24.Visible = false;
            dataGridViewX_Dept.PrimaryGrid.Columns.Add(gridColumn22);
            dataGridViewX_Dept.PrimaryGrid.Columns.Add(gridColumn23);
            dataGridViewX_Dept.PrimaryGrid.Columns.Add(gridColumn24);
            dataGridViewX_Dept.PrimaryGrid.DefaultRowHeight = 24;
            background15.Color1 = System.Drawing.Color.White;
            background15.Color2 = System.Drawing.Color.FromArgb(255, 255, 192);
            dataGridViewX_Dept.PrimaryGrid.DefaultVisualStyles.AlternateColumnCellStyles.Default.Background = background15;
            background16.Color1 = System.Drawing.Color.White;
            background16.Color2 = System.Drawing.Color.FromArgb(255, 255, 192);
            dataGridViewX_Dept.PrimaryGrid.DefaultVisualStyles.AlternateRowCellStyles.Default.Background = background16;
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
            groupBox_Date.BackColor = System.Drawing.Color.Transparent;
            groupBox_Date.Controls.Add(dateTimeInput_StartVacationTo);
            groupBox_Date.Controls.Add(dateTimeInput_StartVacationFrom);
            groupBox_Date.Controls.Add(label3);
            groupBox_Date.Controls.Add(label4);
            resources.ApplyResources(groupBox_Date, "groupBox_Date");
            groupBox_Date.Name = "groupBox_Date";
            groupBox_Date.TabStop = false;
            resources.ApplyResources(dateTimeInput_StartVacationTo, "dateTimeInput_StartVacationTo");
            dateTimeInput_StartVacationTo.Name = "dateTimeInput_StartVacationTo";
            dateTimeInput_StartVacationTo.Leave += new System.EventHandler(dateTimeInput_StartVacationTo_Leave);
            dateTimeInput_StartVacationTo.Click += new System.EventHandler(dateTimeInput_StartVacationTo_Click);
            resources.ApplyResources(dateTimeInput_StartVacationFrom, "dateTimeInput_StartVacationFrom");
            dateTimeInput_StartVacationFrom.Name = "dateTimeInput_StartVacationFrom";
            dateTimeInput_StartVacationFrom.Leave += new System.EventHandler(dateTimeInput_StartVacationFrom_Leave);
            dateTimeInput_StartVacationFrom.Click += new System.EventHandler(dateTimeInput_StartVacationFrom_Click);
            resources.ApplyResources(label3, "label3");
            label3.BackColor = System.Drawing.Color.Transparent;
            label3.Name = "label3";
            resources.ApplyResources(label4, "label4");
            label4.BackColor = System.Drawing.Color.Transparent;
            label4.Name = "label4";
            ButExit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            ButExit.Checked = true;
            ButExit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            resources.ApplyResources(ButExit, "ButExit");
            ButExit.Name = "ButExit";
            ButExit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            ButExit.Symbol = "\uf011";
            ButExit.SymbolSize = 16f;
            ButExit.TextColor = System.Drawing.Color.Black;
            ButExit.Click += new System.EventHandler(ButExit_Click);
            ButOk.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            ButOk.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            resources.ApplyResources(ButOk, "ButOk");
            ButOk.Name = "ButOk";
            ButOk.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            ButOk.Symbol = "\uf0c5";
            ButOk.SymbolSize = 16f;
            ButOk.TextColor = System.Drawing.Color.White;
            ButOk.Click += new System.EventHandler(ButOk_Click);
            groupBox2.BackColor = System.Drawing.Color.Transparent;
            groupBox2.Controls.Add(dateTimeInput_EndVacationTo);
            groupBox2.Controls.Add(dateTimeInput_EndVacationFrom);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(label6);
            resources.ApplyResources(groupBox2, "groupBox2");
            groupBox2.Name = "groupBox2";
            groupBox2.TabStop = false;
            resources.ApplyResources(dateTimeInput_EndVacationTo, "dateTimeInput_EndVacationTo");
            dateTimeInput_EndVacationTo.Name = "dateTimeInput_EndVacationTo";
            dateTimeInput_EndVacationTo.Leave += new System.EventHandler(dateTimeInput_EndVacationTo_Leave);
            dateTimeInput_EndVacationTo.Click += new System.EventHandler(dateTimeInput_EndVacationTo_Click);
            resources.ApplyResources(dateTimeInput_EndVacationFrom, "dateTimeInput_EndVacationFrom");
            dateTimeInput_EndVacationFrom.Name = "dateTimeInput_EndVacationFrom";
            dateTimeInput_EndVacationFrom.Leave += new System.EventHandler(dateTimeInput_EndVacationFrom_Leave);
            dateTimeInput_EndVacationFrom.Click += new System.EventHandler(dateTimeInput_EndVacationFrom_Click);
            resources.ApplyResources(label2, "label2");
            label2.BackColor = System.Drawing.Color.Transparent;
            label2.Name = "label2";
            resources.ApplyResources(label6, "label6");
            label6.BackColor = System.Drawing.Color.Transparent;
            label6.Name = "label6";
            groupBox1.BackColor = System.Drawing.Color.Transparent;
            groupBox1.Controls.Add(textBox_EmpTo);
            groupBox1.Controls.Add(textBox_EmpFrom);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(label5);
            resources.ApplyResources(groupBox1, "groupBox1");
            groupBox1.Name = "groupBox1";
            groupBox1.TabStop = false;
            textBox_EmpTo.BackColor = System.Drawing.Color.DarkSeaGreen;
            textBox_EmpTo.Border.Class = "TextBoxBorder";
            textBox_EmpTo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            textBox_EmpTo.ButtonCustom.Visible = true;
            resources.ApplyResources(textBox_EmpTo, "textBox_EmpTo");
            textBox_EmpTo.Name = "textBox_EmpTo";
            textBox_EmpTo.ButtonCustomClick += new System.EventHandler(textBox_EmpTo_ButtonCustomClick);
            textBox_EmpFrom.BackColor = System.Drawing.Color.DarkSeaGreen;
            textBox_EmpFrom.Border.Class = "TextBoxBorder";
            textBox_EmpFrom.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            textBox_EmpFrom.ButtonCustom.Visible = true;
            resources.ApplyResources(textBox_EmpFrom, "textBox_EmpFrom");
            textBox_EmpFrom.Name = "textBox_EmpFrom";
            textBox_EmpFrom.ButtonCustomClick += new System.EventHandler(textBox_EmpFrom_ButtonCustomClick);
            resources.ApplyResources(label1, "label1");
            label1.BackColor = System.Drawing.Color.Transparent;
            label1.Name = "label1";
            resources.ApplyResources(label5, "label5");
            label5.BackColor = System.Drawing.Color.Transparent;
            label5.Name = "label5";
            resources.ApplyResources(this, "$this");
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            base.Controls.Add(ribbonBar1);
            base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            base.KeyPreview = true;
            base.MaximizeBox = false;
            base.Name = "FrmRepPassport";
            base.Load += new System.EventHandler(FrmRepPassport_Load);
            base.KeyPress += new System.Windows.Forms.KeyPressEventHandler(FrmRepPassport_KeyPress);
            base.KeyDown += new System.Windows.Forms.KeyEventHandler(FrmRepPassport_KeyDown);
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
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }
        public FrmRepPassport()
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
                ButOk.Text = ((VarGeneral.GeneralPrinter.nTyp_Setting.Substring(2, 1) == "0") ? "???????????????? F5" : "?????????????? F5");
                ButExit.Text = "?????????????? Esc";
                expandablePanel_Dept.Text = "??????????????";
                expandablePanel_Section.Text = "??????????";
                expandablePanel_Job.Text = "??????????????";
                expandablePanel_Emp.Text = "????????????";
                expandablePanel_Girds.TitleText = "?????? ??????";
                Text = "?????????? ???????????? ????????????????";
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
                Text = "Passports Report of Employee";
            }
        }
        private void FrmRepPassport_Load(object sender, EventArgs e)
        {
            try
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmRepPassport));
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
                var q = (from t in db.T_Emps
                         orderby t.Passport_Date, t.Passport_DateEnd
                         where t.Passport_Date != ""
                         select new
                         {
                             t.Passport_Date,
                             t.Passport_DateEnd
                         }).ToList();
                if (q.Count == 0)
                {
                    dateTimeInput_StartVacationFrom.Text = "";
                    dateTimeInput_StartVacationTo.Text = "";
                    dateTimeInput_EndVacationFrom.Text = "";
                    dateTimeInput_EndVacationTo.Text = "";
                }
                else
                {
                    dateTimeInput_StartVacationFrom.Text = Convert.ToDateTime(q.First().Passport_Date).ToString("yyyy/MM/dd");
                    dateTimeInput_EndVacationFrom.Text = Convert.ToDateTime(q.Last().Passport_Date).ToString("yyyy/MM/dd");
                    dateTimeInput_StartVacationTo.Text = Convert.ToDateTime(q.First().Passport_DateEnd).ToString("yyyy/MM/dd");
                    dateTimeInput_EndVacationTo.Text = Convert.ToDateTime(q.Last().Passport_DateEnd).ToString("yyyy/MM/dd");
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
            dataGridViewX_Emp.PrimaryGrid.Columns[1].HeaderText = ((LangArEn == 0) ? "????????????" : "Employee");
            dataGridViewX_Dept.PrimaryGrid.Columns[1].HeaderText = ((LangArEn == 0) ? "??????????????" : "Management");
            dataGridViewX_Job.PrimaryGrid.Columns[1].HeaderText = ((LangArEn == 0) ? "??????????????" : "Job");
            dataGridViewX_Section.PrimaryGrid.Columns[1].HeaderText = ((LangArEn == 0) ? "??????????" : "Section");
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
        private void FrmRepPassport_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                SendKeys.Send("{Tab}");
            }
        }
        private void FrmRepPassport_KeyDown(object sender, KeyEventArgs e)
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
                frm.Repvalue = "PassportRep";



                frm.Tag = LangArEn;
                frm.Repvalue = "PassportRep";
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
            string[] GetSql = getDeptNo();
            for (int num2 = 0; num2 < GetSql.Length; num2++)
            {
                if (!string.IsNullOrEmpty(GetSql[num2]))
                {
                    tmpStr = ((!string.IsNullOrEmpty(tmpStr)) ? (tmpStr + " OR ") : (tmpStr + " AND ( "));
                    tmpStr = tmpStr + " ( Dept = " + GetSql[num2].Trim() + " ) ";
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
                    tmpStr = tmpStr + " ( Job = " + GetSql[num2].Trim() + " ) ";
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
                    tmpStr = tmpStr + " ( Section = " + GetSql[num2].Trim() + " ) ";
                }
            }
            QStr += ((tmpStr != "") ? (tmpStr + " )") : "");
            tmpStr = "";
            if (!string.IsNullOrEmpty(textBox_EmpFrom.Text))
            {
                QStr = QStr + " AND ( [Emp_No] >= '" + textBox_EmpFrom.Tag.ToString().Trim() + "' ) ";
            }
            if (!string.IsNullOrEmpty(textBox_EmpTo.Text))
            {
                QStr = QStr + " AND ( [Emp_No] <= '" + textBox_EmpTo.Tag.ToString().Trim() + "' ) ";
            }
            if (dateTimeInput_StartVacationFrom.Text != "    /  /" && dateTimeInput_StartVacationFrom.Text.Length == 10)
            {
                QStr = QStr + " AND ( Passport_Date >= '" + Convert.ToDateTime(dateTimeInput_StartVacationFrom.Text).ToString("yyyy/MM/dd") + "' ) ";
            }
            if (dateTimeInput_StartVacationTo.Text != "    /  /" && dateTimeInput_StartVacationTo.Text.Length == 10)
            {
                QStr = QStr + " AND ( Passport_Date <= '" + Convert.ToDateTime(dateTimeInput_StartVacationTo.Text).ToString("yyyy/MM/dd") + "' ) ";
            }
            if (dateTimeInput_EndVacationFrom.Text != "    /  /" && dateTimeInput_EndVacationFrom.Text.Length == 10)
            {
                QStr = QStr + " AND ( Passport_DateEnd >= '" + Convert.ToDateTime(dateTimeInput_EndVacationFrom.Text).ToString("yyyy/MM/dd") + "' ) ";
            }
            if (dateTimeInput_EndVacationTo.Text != "    /  /" && dateTimeInput_EndVacationTo.Text.Length == 10)
            {
                QStr = QStr + " AND ( Passport_DateEnd <= '" + Convert.ToDateTime(dateTimeInput_EndVacationTo.Text).ToString("yyyy/MM/dd") + "' ) ";
            }
            return QStr;
        }
        private void textBox_EmpFrom_ButtonCustomClick(object sender, EventArgs e)
        {
            try
            {
                Dir_ButSearch.Add("Emp_No", new ColumnDictinary("?????? ????????????", "Employee No", ifDefault: true, ""));
                Dir_ButSearch.Add("NameA", new ColumnDictinary("?????????? ????????", "Arabic Name", ifDefault: true, ""));
                Dir_ButSearch.Add("NameE", new ColumnDictinary("?????????? ??????????????????", "English Name", ifDefault: false, ""));
                Dir_ButSearch.Add("DateAppointment", new ColumnDictinary("?????????? ??????????????", "Appointment Date", ifDefault: false, ""));
                Dir_ButSearch.Add("StartContr", new ColumnDictinary("?????????? ??????????", "Start Contract Date", ifDefault: false, ""));
                Dir_ButSearch.Add("EndContr", new ColumnDictinary("?????????? ??????????", "End Contract Date", ifDefault: false, ""));
                Dir_ButSearch.Add("MainSal", new ColumnDictinary("???????????? ??????????????", "Main Salary", ifDefault: false, ""));
                Dir_ButSearch.Add("ID_No", new ColumnDictinary("?????? ????????????", "ID No", ifDefault: false, ""));
                Dir_ButSearch.Add("Passport_No", new ColumnDictinary("?????? ????????????", "Passport No", ifDefault: false, ""));
                Dir_ButSearch.Add("AddressA", new ColumnDictinary("??????????????", "Address", ifDefault: false, ""));
                Dir_ButSearch.Add("Tel", new ColumnDictinary("????????????", "Tel", ifDefault: false, ""));
                Dir_ButSearch.Add("Note", new ColumnDictinary(" ??????????????????????", "Note", ifDefault: false, ""));
                FrmSearch frm = new FrmSearch();
                frm.Tag = LangArEn;
                ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = Dir_ButSearch;
                foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
                {
                    frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, ""));
                }
                VarGeneral.SFrmTyp = "T_Emp";
                VarGeneral.FrmEmpStat = true;
                frm.TopMost = true;
                frm.ShowDialog();
                if (frm.SerachNo != "")
                {
                    T_Emp q = db.EmpsEmpNo(frm.Serach_No);
                    textBox_EmpFrom.Text = ((LangArEn == 0) ? (q.Emp_No + " - " + q.NameA) : (q.Emp_No + " - " + q.NameE));
                    textBox_EmpFrom.Tag = q.Emp_No;
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
                Dir_ButSearch.Add("Emp_No", new ColumnDictinary("?????? ????????????", "Employee No", ifDefault: true, ""));
                Dir_ButSearch.Add("NameA", new ColumnDictinary("?????????? ????????", "Arabic Name", ifDefault: true, ""));
                Dir_ButSearch.Add("NameE", new ColumnDictinary("?????????? ??????????????????", "English Name", ifDefault: false, ""));
                Dir_ButSearch.Add("DateAppointment", new ColumnDictinary("?????????? ??????????????", "Appointment Date", ifDefault: false, ""));
                Dir_ButSearch.Add("StartContr", new ColumnDictinary("?????????? ??????????", "Start Contract Date", ifDefault: false, ""));
                Dir_ButSearch.Add("EndContr", new ColumnDictinary("?????????? ??????????", "End Contract Date", ifDefault: false, ""));
                Dir_ButSearch.Add("MainSal", new ColumnDictinary("???????????? ??????????????", "Main Salary", ifDefault: false, ""));
                Dir_ButSearch.Add("ID_No", new ColumnDictinary("?????? ????????????", "ID No", ifDefault: false, ""));
                Dir_ButSearch.Add("Passport_No", new ColumnDictinary("?????? ????????????", "Passport No", ifDefault: false, ""));
                Dir_ButSearch.Add("AddressA", new ColumnDictinary("??????????????", "Address", ifDefault: false, ""));
                Dir_ButSearch.Add("Tel", new ColumnDictinary("????????????", "Tel", ifDefault: false, ""));
                Dir_ButSearch.Add("Note", new ColumnDictinary(" ??????????????????????", "Note", ifDefault: false, ""));
                FrmSearch frm = new FrmSearch();
                frm.Tag = LangArEn;
                ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = Dir_ButSearch;
                foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
                {
                    frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, ""));
                }
                VarGeneral.SFrmTyp = "T_Emp";
                VarGeneral.FrmEmpStat = true;
                frm.TopMost = true;
                frm.ShowDialog();
                if (frm.SerachNo != "")
                {
                    T_Emp q = db.EmpsEmpNo(frm.Serach_No);
                    textBox_EmpTo.Text = ((LangArEn == 0) ? (q.Emp_No + " - " + q.NameA) : (q.Emp_No + " - " + q.NameE));
                    textBox_EmpTo.Tag = q.Emp_No;
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
                textBox_EmpFrom.Text = "";
                textBox_EmpFrom.Tag = "";
                VarGeneral.DebLog.writeLog("button_SrchEmp_Click:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void ButExit_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void dateTimeInput_StartVacationFrom_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_StartVacationFrom.Text = Convert.ToDateTime(dateTimeInput_StartVacationFrom.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_StartVacationFrom.Text = "";
            }
        }
        private void dateTimeInput_StartVacationTo_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_StartVacationTo.Text = Convert.ToDateTime(dateTimeInput_StartVacationTo.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_StartVacationTo.Text = "";
            }
        }
        private void dateTimeInput_EndVacationFrom_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_EndVacationFrom.Text = Convert.ToDateTime(dateTimeInput_EndVacationFrom.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_EndVacationFrom.Text = "";
            }
        }
        private void dateTimeInput_EndVacationTo_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_EndVacationTo.Text = Convert.ToDateTime(dateTimeInput_EndVacationTo.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_EndVacationTo.Text = "";
            }
        }
        private void dateTimeInput_StartVacationFrom_Click(object sender, EventArgs e)
        {
            dateTimeInput_StartVacationFrom.SelectAll();
        }
        private void dateTimeInput_StartVacationTo_Click(object sender, EventArgs e)
        {
            dateTimeInput_StartVacationTo.SelectAll();
        }
        private void dateTimeInput_EndVacationFrom_Click(object sender, EventArgs e)
        {
            dateTimeInput_EndVacationFrom.SelectAll();
        }
        private void dateTimeInput_EndVacationTo_Click(object sender, EventArgs e)
        {
            dateTimeInput_EndVacationTo.SelectAll();
        }
    }
}
