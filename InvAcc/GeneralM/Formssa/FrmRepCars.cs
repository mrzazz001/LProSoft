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
    public partial class FrmRepCars : Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InvAcc.Forms.FrmRepCars));
            this.PanelSpecialContainer = new System.Windows.Forms.Panel();
            components = new System.ComponentModel.Container();
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
            expandablePanel_CarsType = new DevComponents.DotNetBar.ExpandablePanel();
            itemPanel2 = new DevComponents.DotNetBar.ItemPanel();
            dataGridViewX_CarType = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            expandablePanel_Cars = new DevComponents.DotNetBar.ExpandablePanel();
            itemPanel1 = new DevComponents.DotNetBar.ItemPanel();
            dataGridViewX_Cars = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            ButExit = new DevComponents.DotNetBar.ButtonX();
            ButOk = new DevComponents.DotNetBar.ButtonX();
            groupBox1 = new System.Windows.Forms.GroupBox();
            TextBox_CarsNoFrom = new DevComponents.DotNetBar.Controls.TextBoxX();
            TextBox_CarsNoTo = new DevComponents.DotNetBar.Controls.TextBoxX();
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
            expandablePanel_CarsType.SuspendLayout();
            itemPanel2.SuspendLayout();
            expandablePanel_Cars.SuspendLayout();
            itemPanel1.SuspendLayout();
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
            panel1.Controls.Add(ButExit);
            panel1.Controls.Add(ButOk);
            panel1.Controls.Add(groupBox1);
            resources.ApplyResources(panel1, "panel1");
            panel1.Name = "panel1";
            expandablePanel_Girds.CanvasColor = System.Drawing.SystemColors.Control;
            expandablePanel_Girds.CollapseDirection = DevComponents.DotNetBar.eCollapseDirection.RightToLeft;
            expandablePanel_Girds.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            expandablePanel_Girds.Controls.Add(expandablePanel_CarsType);
            expandablePanel_Girds.Controls.Add(expandablePanel_Cars);
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
            expandablePanel_CarsType.CanvasColor = System.Drawing.SystemColors.Control;
            expandablePanel_CarsType.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            expandablePanel_CarsType.Controls.Add(itemPanel2);
            resources.ApplyResources(expandablePanel_CarsType, "expandablePanel_CarsType");
            expandablePanel_CarsType.Expanded = false;
            expandablePanel_CarsType.ExpandedBounds = new System.Drawing.Rectangle(0, 52, 314, 173);
            expandablePanel_CarsType.ExpandOnTitleClick = true;
            expandablePanel_CarsType.Name = "expandablePanel_CarsType";
            expandablePanel_CarsType.Style.Alignment = System.Drawing.StringAlignment.Center;
            expandablePanel_CarsType.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            expandablePanel_CarsType.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            expandablePanel_CarsType.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            expandablePanel_CarsType.Style.GradientAngle = 90;
            expandablePanel_CarsType.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            expandablePanel_CarsType.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            expandablePanel_CarsType.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            expandablePanel_CarsType.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            expandablePanel_CarsType.TitleStyle.GradientAngle = 90;
            expandablePanel_CarsType.TitleStyle.MarginLeft = 12;
            expandablePanel_CarsType.ExpandedChanging += new DevComponents.DotNetBar.ExpandChangeEventHandler(expandablePanel_CarsType_ExpandedChanging);
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
            itemPanel2.Controls.Add(dataGridViewX_CarType);
            resources.ApplyResources(itemPanel2, "itemPanel2");
            itemPanel2.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            itemPanel2.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            itemPanel2.Name = "itemPanel2";
            dataGridViewX_CarType.BackColor = System.Drawing.SystemColors.ControlLight;
            resources.ApplyResources(dataGridViewX_CarType, "dataGridViewX_CarType");
            dataGridViewX_CarType.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            dataGridViewX_CarType.ForeColor = System.Drawing.Color.Black;
            dataGridViewX_CarType.HScrollBarVisible = false;
            dataGridViewX_CarType.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            dataGridViewX_CarType.Name = "dataGridViewX_CarType";
            dataGridViewX_CarType.PrimaryGrid.AllowRowHeaderResize = true;
            dataGridViewX_CarType.PrimaryGrid.AllowRowResize = true;
            dataGridViewX_CarType.PrimaryGrid.ColumnHeader.RowHeight = 30;
            dataGridViewX_CarType.PrimaryGrid.ColumnHeader.SortImageAlignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            dataGridViewX_CarType.PrimaryGrid.ColumnHeader.Visible = false;
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
            gridColumn20.Name = "رقم / إسم الإدارة";
            gridColumn20.ReadOnly = true;
            gridColumn20.Width = 263;
            gridColumn21.ReadOnly = true;
            gridColumn21.Visible = false;
            dataGridViewX_CarType.PrimaryGrid.Columns.Add(gridColumn19);
            dataGridViewX_CarType.PrimaryGrid.Columns.Add(gridColumn20);
            dataGridViewX_CarType.PrimaryGrid.Columns.Add(gridColumn21);
            dataGridViewX_CarType.PrimaryGrid.DefaultRowHeight = 24;
            background13.Color1 = System.Drawing.Color.White;
            background13.Color2 = System.Drawing.Color.FromArgb(255, 255, 192);
            dataGridViewX_CarType.PrimaryGrid.DefaultVisualStyles.AlternateColumnCellStyles.Default.Background = background13;
            background14.Color1 = System.Drawing.Color.White;
            background14.Color2 = System.Drawing.Color.FromArgb(255, 255, 192);
            dataGridViewX_CarType.PrimaryGrid.DefaultVisualStyles.AlternateRowCellStyles.Default.Background = background14;
            dataGridViewX_CarType.PrimaryGrid.DefaultVisualStyles.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            dataGridViewX_CarType.PrimaryGrid.DefaultVisualStyles.FilterColumnHeaderStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            dataGridViewX_CarType.PrimaryGrid.EnableColumnFiltering = true;
            dataGridViewX_CarType.PrimaryGrid.EnableFiltering = true;
            dataGridViewX_CarType.PrimaryGrid.EnableRowFiltering = true;
            dataGridViewX_CarType.PrimaryGrid.Filter.Visible = true;
            dataGridViewX_CarType.PrimaryGrid.FilterLevel = DevComponents.DotNetBar.SuperGrid.FilterLevel.All;
            dataGridViewX_CarType.PrimaryGrid.FilterMatchType = DevComponents.DotNetBar.SuperGrid.FilterMatchType.RegularExpressions;
            dataGridViewX_CarType.PrimaryGrid.MultiSelect = false;
            dataGridViewX_CarType.PrimaryGrid.NullString = "-----";
            dataGridViewX_CarType.PrimaryGrid.RowHeaderWidth = 45;
            dataGridViewX_CarType.PrimaryGrid.ShowColumnHeader = false;
            dataGridViewX_CarType.PrimaryGrid.ShowRowGridIndex = true;
            dataGridViewX_CarType.PrimaryGrid.ShowRowHeaders = false;
            dataGridViewX_CarType.PrimaryGrid.UseAlternateRowStyle = true;
            expandablePanel_Cars.CanvasColor = System.Drawing.SystemColors.Control;
            expandablePanel_Cars.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            expandablePanel_Cars.Controls.Add(itemPanel1);
            resources.ApplyResources(expandablePanel_Cars, "expandablePanel_Cars");
            expandablePanel_Cars.Expanded = false;
            expandablePanel_Cars.ExpandedBounds = new System.Drawing.Rectangle(0, 26, 314, 173);
            expandablePanel_Cars.ExpandOnTitleClick = true;
            expandablePanel_Cars.Name = "expandablePanel_Cars";
            expandablePanel_Cars.Style.Alignment = System.Drawing.StringAlignment.Center;
            expandablePanel_Cars.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            expandablePanel_Cars.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            expandablePanel_Cars.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            expandablePanel_Cars.Style.GradientAngle = 90;
            expandablePanel_Cars.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            expandablePanel_Cars.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            expandablePanel_Cars.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            expandablePanel_Cars.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            expandablePanel_Cars.TitleStyle.GradientAngle = 90;
            expandablePanel_Cars.TitleStyle.MarginLeft = 12;
            expandablePanel_Cars.ExpandedChanging += new DevComponents.DotNetBar.ExpandChangeEventHandler(expandablePanel_Cars_ExpandedChanging);
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
            itemPanel1.Controls.Add(dataGridViewX_Cars);
            resources.ApplyResources(itemPanel1, "itemPanel1");
            itemPanel1.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            itemPanel1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            itemPanel1.Name = "itemPanel1";
            dataGridViewX_Cars.BackColor = System.Drawing.SystemColors.ControlLight;
            resources.ApplyResources(dataGridViewX_Cars, "dataGridViewX_Cars");
            dataGridViewX_Cars.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            dataGridViewX_Cars.ForeColor = System.Drawing.Color.Black;
            dataGridViewX_Cars.HScrollBarVisible = false;
            dataGridViewX_Cars.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            dataGridViewX_Cars.Name = "dataGridViewX_Cars";
            dataGridViewX_Cars.PrimaryGrid.AllowRowHeaderResize = true;
            dataGridViewX_Cars.PrimaryGrid.AllowRowResize = true;
            dataGridViewX_Cars.PrimaryGrid.ColumnHeader.RowHeight = 30;
            dataGridViewX_Cars.PrimaryGrid.ColumnHeader.SortImageAlignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            dataGridViewX_Cars.PrimaryGrid.ColumnHeader.Visible = false;
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
            gridColumn23.Name = "رقم / إسم الإدارة";
            gridColumn23.ReadOnly = true;
            gridColumn23.Width = 263;
            gridColumn24.ReadOnly = true;
            gridColumn24.Visible = false;
            dataGridViewX_Cars.PrimaryGrid.Columns.Add(gridColumn22);
            dataGridViewX_Cars.PrimaryGrid.Columns.Add(gridColumn23);
            dataGridViewX_Cars.PrimaryGrid.Columns.Add(gridColumn24);
            dataGridViewX_Cars.PrimaryGrid.DefaultRowHeight = 24;
            background15.Color1 = System.Drawing.Color.White;
            background15.Color2 = System.Drawing.Color.FromArgb(255, 255, 192);
            dataGridViewX_Cars.PrimaryGrid.DefaultVisualStyles.AlternateColumnCellStyles.Default.Background = background15;
            background16.Color1 = System.Drawing.Color.White;
            background16.Color2 = System.Drawing.Color.FromArgb(255, 255, 192);
            dataGridViewX_Cars.PrimaryGrid.DefaultVisualStyles.AlternateRowCellStyles.Default.Background = background16;
            dataGridViewX_Cars.PrimaryGrid.DefaultVisualStyles.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            dataGridViewX_Cars.PrimaryGrid.DefaultVisualStyles.FilterColumnHeaderStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            dataGridViewX_Cars.PrimaryGrid.EnableColumnFiltering = true;
            dataGridViewX_Cars.PrimaryGrid.EnableFiltering = true;
            dataGridViewX_Cars.PrimaryGrid.EnableRowFiltering = true;
            dataGridViewX_Cars.PrimaryGrid.Filter.Visible = true;
            dataGridViewX_Cars.PrimaryGrid.FilterLevel = DevComponents.DotNetBar.SuperGrid.FilterLevel.All;
            dataGridViewX_Cars.PrimaryGrid.FilterMatchType = DevComponents.DotNetBar.SuperGrid.FilterMatchType.RegularExpressions;
            dataGridViewX_Cars.PrimaryGrid.MultiSelect = false;
            dataGridViewX_Cars.PrimaryGrid.NullString = "-----";
            dataGridViewX_Cars.PrimaryGrid.RowHeaderWidth = 45;
            dataGridViewX_Cars.PrimaryGrid.ShowColumnHeader = false;
            dataGridViewX_Cars.PrimaryGrid.ShowRowGridIndex = true;
            dataGridViewX_Cars.PrimaryGrid.ShowRowHeaders = false;
            dataGridViewX_Cars.PrimaryGrid.UseAlternateRowStyle = true;
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
            groupBox1.BackColor = System.Drawing.Color.Transparent;
            groupBox1.Controls.Add(TextBox_CarsNoFrom);
            groupBox1.Controls.Add(TextBox_CarsNoTo);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(label5);
            resources.ApplyResources(groupBox1, "groupBox1");
            groupBox1.Name = "groupBox1";
            groupBox1.TabStop = false;
            TextBox_CarsNoFrom.BackColor = System.Drawing.Color.DarkSeaGreen;
            TextBox_CarsNoFrom.Border.Class = "TextBoxBorder";
            TextBox_CarsNoFrom.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            TextBox_CarsNoFrom.ButtonCustom.Visible = true;
            resources.ApplyResources(TextBox_CarsNoFrom, "TextBox_CarsNoFrom");
            TextBox_CarsNoFrom.Name = "TextBox_CarsNoFrom";
            TextBox_CarsNoFrom.ButtonCustomClick += new System.EventHandler(comboBox_CarsNo_ButtonCustomClick);
            TextBox_CarsNoTo.BackColor = System.Drawing.Color.DarkSeaGreen;
            TextBox_CarsNoTo.Border.Class = "TextBoxBorder";
            TextBox_CarsNoTo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            TextBox_CarsNoTo.ButtonCustom.Visible = true;
            resources.ApplyResources(TextBox_CarsNoTo, "TextBox_CarsNoTo");
            TextBox_CarsNoTo.Name = "TextBox_CarsNoTo";
            TextBox_CarsNoTo.ButtonCustomClick += new System.EventHandler(comboBox_CarsNoTo_ButtonCustomClick);
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
            base.Name = "FrmRepCars";
            base.Load += new System.EventHandler(FrmRepCars_Load);
            base.KeyPress += new System.Windows.Forms.KeyPressEventHandler(FrmRepCars_KeyPress);
            base.KeyDown += new System.Windows.Forms.KeyEventHandler(FrmRepCars_KeyDown);
            ribbonBar1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            expandablePanel_Girds.ResumeLayout(false);
            expandablePanel_CarsType.ResumeLayout(false);
            itemPanel2.ResumeLayout(false);
            expandablePanel_Cars.ResumeLayout(false);
            itemPanel1.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }
        public FrmRepCars()
        {
            InitializeComponent();
        }
        private void RibunButtons()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                ButOk.Text = ((VarGeneral.GeneralPrinter.nTyp_Setting.Substring(2, 1) == "0") ? "طبـــاعة F5" : "عــــرض F5");
                ButExit.Text = "خـــروج Esc";
                expandablePanel_Cars.Text = "السيــارات";
                expandablePanel_CarsType.Text = "أنواع السيــارات";
                expandablePanel_Girds.TitleText = "على حسب";
                Text = "تقرير السيــــارات";
            }
            else
            {
                ButOk.Text = ((VarGeneral.GeneralPrinter.nTyp_Setting.Substring(2, 1) == "0") ? "Print F5" : "Show F5");
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
