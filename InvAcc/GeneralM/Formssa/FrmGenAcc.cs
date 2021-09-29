using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.DotNetBar.SuperGrid;
using DevComponents.Editors;
using DevComponents.Editors.DateTimeAdv;
using InvAcc.GeneralM;
using InvAcc.Stock_Data;
using SSSDateTime.Date;
using SSSLanguage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial class FrmGenAcc : Form
    {
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
        private TextBoxX textBox_AccLoan;
        private TextBoxX textBox_AccSal;
        private Label label1;
        private Label label5;
        private TextBoxX textBox_AccHousing;
        private Label label2;
        private int LangArEn = 0;
        private HijriGreg.HijriGregDates n = new HijriGreg.HijriGregDates();
        private Dictionary<string, ColumnDictinary> columns_Names_visible = new Dictionary<string, ColumnDictinary>();
        private T_Branch vBr = new T_Branch();
        public List<Control> controls;
        public Control codeControl = new Control();
        private List<string> pkeys = new List<string>();
        private T_Emp data_this;
        private T_Attend Data_this_Attend;
        private BindingList<T_Attend> Update_Attend;
        private Stock_DataDataContext dbInstance;
        private Rate_DataDataContext dbInstanceRate;
        public Dictionary<string, ColumnDictinary> columns_Names_visible2 = new Dictionary<string, ColumnDictinary>();
        public List<string> PKeys
        {
            get
            {
                return pkeys;
            }
            set
            {
                pkeys = value;
            }
        }
        public T_Emp DataThis
        {
            get
            {
                return data_this;
            }
            set
            {
                data_this = value;
                SetData(data_this);
            }
        }
        public T_Attend Datathis_Attend
        {
            get
            {
                return Data_this_Attend;
            }
            set
            {
                Data_this_Attend = value;
            }
        }
        public BindingList<T_Attend> UpdateAttend
        {
            get
            {
                return Update_Attend;
            }
            set
            {
                Update_Attend = value;
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
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn1 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn2 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn3 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.Style.Background background1 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.Style.Background background2 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn4 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn5 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn6 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.Style.Background background3 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.Style.Background background4 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn7 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn8 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn9 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.Style.Background background5 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.Style.Background background6 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn10 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn11 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn12 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.Style.Background background7 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.Style.Background background8 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmGenAcc));
            this.ribbonBar1 = new DevComponents.DotNetBar.RibbonBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.expandablePanel_Girds = new DevComponents.DotNetBar.ExpandablePanel();
            this.expandablePanel_Emp = new DevComponents.DotNetBar.ExpandablePanel();
            this.itemPanel4 = new DevComponents.DotNetBar.ItemPanel();
            this.dataGridViewX_Emp = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            this.expandablePanel_Job = new DevComponents.DotNetBar.ExpandablePanel();
            this.itemPanel3 = new DevComponents.DotNetBar.ItemPanel();
            this.dataGridViewX_Job = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            this.expandablePanel_Section = new DevComponents.DotNetBar.ExpandablePanel();
            this.itemPanel2 = new DevComponents.DotNetBar.ItemPanel();
            this.dataGridViewX_Section = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            this.expandablePanel_Dept = new DevComponents.DotNetBar.ExpandablePanel();
            this.itemPanel1 = new DevComponents.DotNetBar.ItemPanel();
            this.dataGridViewX_Dept = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            this.ButExit = new DevComponents.DotNetBar.ButtonX();
            this.ButOk = new DevComponents.DotNetBar.ButtonX();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_AccHousing = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.textBox_AccLoan = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.textBox_AccSal = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.ribbonBar1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.expandablePanel_Girds.SuspendLayout();
            this.expandablePanel_Emp.SuspendLayout();
            this.itemPanel4.SuspendLayout();
            this.expandablePanel_Job.SuspendLayout();
            this.itemPanel3.SuspendLayout();
            this.expandablePanel_Section.SuspendLayout();
            this.itemPanel2.SuspendLayout();
            this.expandablePanel_Dept.SuspendLayout();
            this.itemPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ribbonBar1
            // 
            this.ribbonBar1.AutoOverflowEnabled = true;
            // 
            // 
            // 
            this.ribbonBar1.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar1.BackgroundStyle.BackColor = System.Drawing.Color.Silver;
            this.ribbonBar1.BackgroundStyle.BackColor2 = System.Drawing.SystemColors.GradientActiveCaption;
            this.ribbonBar1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar1.ContainerControlProcessDialogKey = true;
            this.ribbonBar1.Controls.Add(this.panel1);
            this.ribbonBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonBar1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.ribbonBar1.Location = new System.Drawing.Point(0, 0);
            this.ribbonBar1.Name = "ribbonBar1";
            this.ribbonBar1.Size = new System.Drawing.Size(315, 243);
            this.ribbonBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this.ribbonBar1.TabIndex = 1104;
            // 
            // 
            // 
            this.ribbonBar1.TitleStyle.BackColor = System.Drawing.Color.Black;
            this.ribbonBar1.TitleStyle.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.ribbonBar1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar1.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.expandablePanel_Girds);
            this.panel1.Controls.Add(this.ButExit);
            this.panel1.Controls.Add(this.ButOk);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(315, 226);
            this.panel1.TabIndex = 1104;
            // 
            // expandablePanel_Girds
            // 
            this.expandablePanel_Girds.CanvasColor = System.Drawing.SystemColors.Control;
            this.expandablePanel_Girds.CollapseDirection = DevComponents.DotNetBar.eCollapseDirection.RightToLeft;
            this.expandablePanel_Girds.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.expandablePanel_Girds.Controls.Add(this.expandablePanel_Emp);
            this.expandablePanel_Girds.Controls.Add(this.expandablePanel_Job);
            this.expandablePanel_Girds.Controls.Add(this.expandablePanel_Section);
            this.expandablePanel_Girds.Controls.Add(this.expandablePanel_Dept);
            this.expandablePanel_Girds.Dock = System.Windows.Forms.DockStyle.Left;
            this.expandablePanel_Girds.Expanded = false;
            this.expandablePanel_Girds.ExpandedBounds = new System.Drawing.Rectangle(0, 0, 314, 226);
            this.expandablePanel_Girds.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.expandablePanel_Girds.Location = new System.Drawing.Point(0, 0);
            this.expandablePanel_Girds.Name = "expandablePanel_Girds";
            this.expandablePanel_Girds.Size = new System.Drawing.Size(30, 226);
            this.expandablePanel_Girds.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanel_Girds.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.expandablePanel_Girds.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandablePanel_Girds.Style.GradientAngle = 90;
            this.expandablePanel_Girds.TabIndex = 6792;
            this.expandablePanel_Girds.TitleStyle.Alignment = System.Drawing.StringAlignment.Far;
            this.expandablePanel_Girds.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandablePanel_Girds.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            this.expandablePanel_Girds.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandablePanel_Girds.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.expandablePanel_Girds.TitleStyle.GradientAngle = 90;
            this.expandablePanel_Girds.TitleStyle.MarginLeft = 6;
            this.expandablePanel_Girds.TitleText = "على حسب";
            this.expandablePanel_Girds.ExpandedChanging += new DevComponents.DotNetBar.ExpandChangeEventHandler(this.expandablePanel_Girds_ExpandedChanging);
            this.expandablePanel_Girds.ExpandedChanged += new DevComponents.DotNetBar.ExpandChangeEventHandler(this.expandablePanel_Girds_ExpandedChanged);
            // 
            // expandablePanel_Emp
            // 
            this.expandablePanel_Emp.CanvasColor = System.Drawing.SystemColors.Control;
            this.expandablePanel_Emp.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.expandablePanel_Emp.Controls.Add(this.itemPanel4);
            this.expandablePanel_Emp.Dock = System.Windows.Forms.DockStyle.Top;
            this.expandablePanel_Emp.Expanded = false;
            this.expandablePanel_Emp.ExpandedBounds = new System.Drawing.Rectangle(0, 104, 314, 120);
            this.expandablePanel_Emp.ExpandOnTitleClick = true;
            this.expandablePanel_Emp.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.expandablePanel_Emp.Location = new System.Drawing.Point(0, 104);
            this.expandablePanel_Emp.Name = "expandablePanel_Emp";
            this.expandablePanel_Emp.Size = new System.Drawing.Size(30, 26);
            this.expandablePanel_Emp.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanel_Emp.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.expandablePanel_Emp.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.expandablePanel_Emp.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandablePanel_Emp.Style.GradientAngle = 90;
            this.expandablePanel_Emp.TabIndex = 6;
            this.expandablePanel_Emp.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandablePanel_Emp.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            this.expandablePanel_Emp.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandablePanel_Emp.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.expandablePanel_Emp.TitleStyle.GradientAngle = 90;
            this.expandablePanel_Emp.TitleStyle.MarginLeft = 12;
            this.expandablePanel_Emp.TitleText = "الموظف";
            // 
            // itemPanel4
            // 
            // 
            // 
            // 
            this.itemPanel4.BackgroundStyle.BackColor = System.Drawing.Color.AliceBlue;
            this.itemPanel4.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.itemPanel4.BackgroundStyle.BorderBottomWidth = 1;
            this.itemPanel4.BackgroundStyle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            this.itemPanel4.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.itemPanel4.BackgroundStyle.BorderLeftWidth = 1;
            this.itemPanel4.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.itemPanel4.BackgroundStyle.BorderRightWidth = 1;
            this.itemPanel4.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.itemPanel4.BackgroundStyle.BorderTopWidth = 1;
            this.itemPanel4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.itemPanel4.BackgroundStyle.PaddingBottom = 1;
            this.itemPanel4.BackgroundStyle.PaddingLeft = 1;
            this.itemPanel4.BackgroundStyle.PaddingRight = 1;
            this.itemPanel4.BackgroundStyle.PaddingTop = 1;
            this.itemPanel4.ContainerControlProcessDialogKey = true;
            this.itemPanel4.Controls.Add(this.dataGridViewX_Emp);
            this.itemPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.itemPanel4.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.itemPanel4.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.itemPanel4.Location = new System.Drawing.Point(0, 26);
            this.itemPanel4.Name = "itemPanel4";
            this.itemPanel4.Size = new System.Drawing.Size(30, 0);
            this.itemPanel4.TabIndex = 3;
            this.itemPanel4.Text = "itemPanel4";
            // 
            // dataGridViewX_Emp
            // 
            this.dataGridViewX_Emp.BackColor = System.Drawing.SystemColors.ControlLight;
            this.dataGridViewX_Emp.Dock = System.Windows.Forms.DockStyle.Left;
            this.dataGridViewX_Emp.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            this.dataGridViewX_Emp.ForeColor = System.Drawing.Color.Black;
            this.dataGridViewX_Emp.HScrollBarVisible = false;
            this.dataGridViewX_Emp.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.dataGridViewX_Emp.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewX_Emp.Name = "dataGridViewX_Emp";
            this.dataGridViewX_Emp.PrimaryGrid.AllowRowHeaderResize = true;
            this.dataGridViewX_Emp.PrimaryGrid.AllowRowResize = true;
            this.dataGridViewX_Emp.PrimaryGrid.ColumnHeader.RowHeight = 30;
            this.dataGridViewX_Emp.PrimaryGrid.ColumnHeader.SortImageAlignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            this.dataGridViewX_Emp.PrimaryGrid.ColumnHeader.Visible = false;
            gridColumn1.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleLeft;
            gridColumn1.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridCheckBoxXEditControl);
            gridColumn1.FilterEditType = DevComponents.DotNetBar.SuperGrid.FilterEditType.None;
            gridColumn1.HeaderStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gridColumn1.Name = "*";
            gridColumn1.Width = 50;
            gridColumn2.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleLeft;
            gridColumn2.ColumnSortMode = DevComponents.DotNetBar.SuperGrid.ColumnSortMode.None;
            gridColumn2.FilterAutoScan = true;
            gridColumn2.HeaderStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gridColumn2.InfoImageAlignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gridColumn2.Name = "رقم / إسم الإدارة";
            gridColumn2.ReadOnly = true;
            gridColumn2.Width = 263;
            gridColumn3.ReadOnly = true;
            gridColumn3.Visible = false;
            this.dataGridViewX_Emp.PrimaryGrid.Columns.Add(gridColumn1);
            this.dataGridViewX_Emp.PrimaryGrid.Columns.Add(gridColumn2);
            this.dataGridViewX_Emp.PrimaryGrid.Columns.Add(gridColumn3);
            this.dataGridViewX_Emp.PrimaryGrid.DefaultRowHeight = 24;
            background1.Color1 = System.Drawing.Color.White;
            background1.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dataGridViewX_Emp.PrimaryGrid.DefaultVisualStyles.AlternateColumnCellStyles.Default.Background = background1;
            background2.Color1 = System.Drawing.Color.White;
            background2.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dataGridViewX_Emp.PrimaryGrid.DefaultVisualStyles.AlternateRowCellStyles.Default.Background = background2;
            this.dataGridViewX_Emp.PrimaryGrid.DefaultVisualStyles.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            this.dataGridViewX_Emp.PrimaryGrid.DefaultVisualStyles.FilterColumnHeaderStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            this.dataGridViewX_Emp.PrimaryGrid.EnableColumnFiltering = true;
            this.dataGridViewX_Emp.PrimaryGrid.EnableFiltering = true;
            this.dataGridViewX_Emp.PrimaryGrid.EnableRowFiltering = true;
            this.dataGridViewX_Emp.PrimaryGrid.Filter.Visible = true;
            this.dataGridViewX_Emp.PrimaryGrid.FilterLevel = ((DevComponents.DotNetBar.SuperGrid.FilterLevel)((DevComponents.DotNetBar.SuperGrid.FilterLevel.Root | DevComponents.DotNetBar.SuperGrid.FilterLevel.Expanded)));
            this.dataGridViewX_Emp.PrimaryGrid.FilterMatchType = DevComponents.DotNetBar.SuperGrid.FilterMatchType.RegularExpressions;
            this.dataGridViewX_Emp.PrimaryGrid.MultiSelect = false;
            this.dataGridViewX_Emp.PrimaryGrid.NullString = "-----";
            this.dataGridViewX_Emp.PrimaryGrid.RowHeaderWidth = 45;
            this.dataGridViewX_Emp.PrimaryGrid.ShowColumnHeader = false;
            this.dataGridViewX_Emp.PrimaryGrid.ShowRowGridIndex = true;
            this.dataGridViewX_Emp.PrimaryGrid.ShowRowHeaders = false;
            this.dataGridViewX_Emp.PrimaryGrid.UseAlternateRowStyle = true;
            this.dataGridViewX_Emp.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dataGridViewX_Emp.Size = new System.Drawing.Size(313, 0);
            this.dataGridViewX_Emp.TabIndex = 481;
            // 
            // expandablePanel_Job
            // 
            this.expandablePanel_Job.CanvasColor = System.Drawing.SystemColors.Control;
            this.expandablePanel_Job.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.expandablePanel_Job.Controls.Add(this.itemPanel3);
            this.expandablePanel_Job.Dock = System.Windows.Forms.DockStyle.Top;
            this.expandablePanel_Job.Expanded = false;
            this.expandablePanel_Job.ExpandedBounds = new System.Drawing.Rectangle(0, 78, 314, 120);
            this.expandablePanel_Job.ExpandOnTitleClick = true;
            this.expandablePanel_Job.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.expandablePanel_Job.Location = new System.Drawing.Point(0, 78);
            this.expandablePanel_Job.Name = "expandablePanel_Job";
            this.expandablePanel_Job.Size = new System.Drawing.Size(30, 26);
            this.expandablePanel_Job.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanel_Job.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.expandablePanel_Job.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.expandablePanel_Job.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandablePanel_Job.Style.GradientAngle = 90;
            this.expandablePanel_Job.TabIndex = 5;
            this.expandablePanel_Job.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandablePanel_Job.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            this.expandablePanel_Job.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandablePanel_Job.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.expandablePanel_Job.TitleStyle.GradientAngle = 90;
            this.expandablePanel_Job.TitleStyle.MarginLeft = 12;
            this.expandablePanel_Job.TitleText = "الوظيفة";
            // 
            // itemPanel3
            // 
            // 
            // 
            // 
            this.itemPanel3.BackgroundStyle.BackColor = System.Drawing.Color.AliceBlue;
            this.itemPanel3.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.itemPanel3.BackgroundStyle.BorderBottomWidth = 1;
            this.itemPanel3.BackgroundStyle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            this.itemPanel3.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.itemPanel3.BackgroundStyle.BorderLeftWidth = 1;
            this.itemPanel3.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.itemPanel3.BackgroundStyle.BorderRightWidth = 1;
            this.itemPanel3.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.itemPanel3.BackgroundStyle.BorderTopWidth = 1;
            this.itemPanel3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.itemPanel3.BackgroundStyle.PaddingBottom = 1;
            this.itemPanel3.BackgroundStyle.PaddingLeft = 1;
            this.itemPanel3.BackgroundStyle.PaddingRight = 1;
            this.itemPanel3.BackgroundStyle.PaddingTop = 1;
            this.itemPanel3.ContainerControlProcessDialogKey = true;
            this.itemPanel3.Controls.Add(this.dataGridViewX_Job);
            this.itemPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.itemPanel3.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.itemPanel3.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.itemPanel3.Location = new System.Drawing.Point(0, 26);
            this.itemPanel3.Name = "itemPanel3";
            this.itemPanel3.Size = new System.Drawing.Size(30, 0);
            this.itemPanel3.TabIndex = 3;
            this.itemPanel3.Text = "itemPanel3";
            // 
            // dataGridViewX_Job
            // 
            this.dataGridViewX_Job.BackColor = System.Drawing.SystemColors.ControlLight;
            this.dataGridViewX_Job.Dock = System.Windows.Forms.DockStyle.Left;
            this.dataGridViewX_Job.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            this.dataGridViewX_Job.ForeColor = System.Drawing.Color.Black;
            this.dataGridViewX_Job.HScrollBarVisible = false;
            this.dataGridViewX_Job.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.dataGridViewX_Job.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewX_Job.Name = "dataGridViewX_Job";
            this.dataGridViewX_Job.PrimaryGrid.AllowRowHeaderResize = true;
            this.dataGridViewX_Job.PrimaryGrid.AllowRowResize = true;
            this.dataGridViewX_Job.PrimaryGrid.ColumnHeader.RowHeight = 30;
            this.dataGridViewX_Job.PrimaryGrid.ColumnHeader.SortImageAlignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            this.dataGridViewX_Job.PrimaryGrid.ColumnHeader.Visible = false;
            gridColumn4.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleLeft;
            gridColumn4.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridCheckBoxXEditControl);
            gridColumn4.FilterEditType = DevComponents.DotNetBar.SuperGrid.FilterEditType.None;
            gridColumn4.HeaderStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gridColumn4.Name = "*";
            gridColumn4.Width = 50;
            gridColumn5.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleLeft;
            gridColumn5.ColumnSortMode = DevComponents.DotNetBar.SuperGrid.ColumnSortMode.None;
            gridColumn5.FilterAutoScan = true;
            gridColumn5.HeaderStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gridColumn5.InfoImageAlignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gridColumn5.Name = "رقم / إسم الإدارة";
            gridColumn5.ReadOnly = true;
            gridColumn5.Width = 263;
            gridColumn6.ReadOnly = true;
            gridColumn6.Visible = false;
            this.dataGridViewX_Job.PrimaryGrid.Columns.Add(gridColumn4);
            this.dataGridViewX_Job.PrimaryGrid.Columns.Add(gridColumn5);
            this.dataGridViewX_Job.PrimaryGrid.Columns.Add(gridColumn6);
            this.dataGridViewX_Job.PrimaryGrid.DefaultRowHeight = 24;
            background3.Color1 = System.Drawing.Color.White;
            background3.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dataGridViewX_Job.PrimaryGrid.DefaultVisualStyles.AlternateColumnCellStyles.Default.Background = background3;
            background4.Color1 = System.Drawing.Color.White;
            background4.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dataGridViewX_Job.PrimaryGrid.DefaultVisualStyles.AlternateRowCellStyles.Default.Background = background4;
            this.dataGridViewX_Job.PrimaryGrid.DefaultVisualStyles.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            this.dataGridViewX_Job.PrimaryGrid.DefaultVisualStyles.FilterColumnHeaderStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            this.dataGridViewX_Job.PrimaryGrid.EnableColumnFiltering = true;
            this.dataGridViewX_Job.PrimaryGrid.EnableFiltering = true;
            this.dataGridViewX_Job.PrimaryGrid.EnableRowFiltering = true;
            this.dataGridViewX_Job.PrimaryGrid.Filter.Visible = true;
            this.dataGridViewX_Job.PrimaryGrid.FilterLevel = ((DevComponents.DotNetBar.SuperGrid.FilterLevel)((DevComponents.DotNetBar.SuperGrid.FilterLevel.Root | DevComponents.DotNetBar.SuperGrid.FilterLevel.Expanded)));
            this.dataGridViewX_Job.PrimaryGrid.FilterMatchType = DevComponents.DotNetBar.SuperGrid.FilterMatchType.RegularExpressions;
            this.dataGridViewX_Job.PrimaryGrid.MultiSelect = false;
            this.dataGridViewX_Job.PrimaryGrid.NullString = "-----";
            this.dataGridViewX_Job.PrimaryGrid.RowHeaderWidth = 45;
            this.dataGridViewX_Job.PrimaryGrid.ShowColumnHeader = false;
            this.dataGridViewX_Job.PrimaryGrid.ShowRowGridIndex = true;
            this.dataGridViewX_Job.PrimaryGrid.ShowRowHeaders = false;
            this.dataGridViewX_Job.PrimaryGrid.UseAlternateRowStyle = true;
            this.dataGridViewX_Job.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dataGridViewX_Job.Size = new System.Drawing.Size(313, 0);
            this.dataGridViewX_Job.TabIndex = 481;
            // 
            // expandablePanel_Section
            // 
            this.expandablePanel_Section.CanvasColor = System.Drawing.SystemColors.Control;
            this.expandablePanel_Section.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.expandablePanel_Section.Controls.Add(this.itemPanel2);
            this.expandablePanel_Section.Dock = System.Windows.Forms.DockStyle.Top;
            this.expandablePanel_Section.Expanded = false;
            this.expandablePanel_Section.ExpandedBounds = new System.Drawing.Rectangle(0, 52, 314, 120);
            this.expandablePanel_Section.ExpandOnTitleClick = true;
            this.expandablePanel_Section.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.expandablePanel_Section.Location = new System.Drawing.Point(0, 52);
            this.expandablePanel_Section.Name = "expandablePanel_Section";
            this.expandablePanel_Section.Size = new System.Drawing.Size(30, 26);
            this.expandablePanel_Section.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanel_Section.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.expandablePanel_Section.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.expandablePanel_Section.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandablePanel_Section.Style.GradientAngle = 90;
            this.expandablePanel_Section.TabIndex = 4;
            this.expandablePanel_Section.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandablePanel_Section.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            this.expandablePanel_Section.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandablePanel_Section.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.expandablePanel_Section.TitleStyle.GradientAngle = 90;
            this.expandablePanel_Section.TitleStyle.MarginLeft = 12;
            this.expandablePanel_Section.TitleText = "القسم";
            // 
            // itemPanel2
            // 
            // 
            // 
            // 
            this.itemPanel2.BackgroundStyle.BackColor = System.Drawing.Color.AliceBlue;
            this.itemPanel2.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.itemPanel2.BackgroundStyle.BorderBottomWidth = 1;
            this.itemPanel2.BackgroundStyle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            this.itemPanel2.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.itemPanel2.BackgroundStyle.BorderLeftWidth = 1;
            this.itemPanel2.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.itemPanel2.BackgroundStyle.BorderRightWidth = 1;
            this.itemPanel2.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.itemPanel2.BackgroundStyle.BorderTopWidth = 1;
            this.itemPanel2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.itemPanel2.BackgroundStyle.PaddingBottom = 1;
            this.itemPanel2.BackgroundStyle.PaddingLeft = 1;
            this.itemPanel2.BackgroundStyle.PaddingRight = 1;
            this.itemPanel2.BackgroundStyle.PaddingTop = 1;
            this.itemPanel2.ContainerControlProcessDialogKey = true;
            this.itemPanel2.Controls.Add(this.dataGridViewX_Section);
            this.itemPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.itemPanel2.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.itemPanel2.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.itemPanel2.Location = new System.Drawing.Point(0, 26);
            this.itemPanel2.Name = "itemPanel2";
            this.itemPanel2.Size = new System.Drawing.Size(30, 0);
            this.itemPanel2.TabIndex = 3;
            this.itemPanel2.Text = "itemPanel2";
            // 
            // dataGridViewX_Section
            // 
            this.dataGridViewX_Section.BackColor = System.Drawing.SystemColors.ControlLight;
            this.dataGridViewX_Section.Dock = System.Windows.Forms.DockStyle.Left;
            this.dataGridViewX_Section.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            this.dataGridViewX_Section.ForeColor = System.Drawing.Color.Black;
            this.dataGridViewX_Section.HScrollBarVisible = false;
            this.dataGridViewX_Section.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.dataGridViewX_Section.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewX_Section.Name = "dataGridViewX_Section";
            this.dataGridViewX_Section.PrimaryGrid.AllowRowHeaderResize = true;
            this.dataGridViewX_Section.PrimaryGrid.AllowRowResize = true;
            this.dataGridViewX_Section.PrimaryGrid.ColumnHeader.RowHeight = 30;
            this.dataGridViewX_Section.PrimaryGrid.ColumnHeader.SortImageAlignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            this.dataGridViewX_Section.PrimaryGrid.ColumnHeader.Visible = false;
            gridColumn7.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleLeft;
            gridColumn7.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridCheckBoxXEditControl);
            gridColumn7.FilterEditType = DevComponents.DotNetBar.SuperGrid.FilterEditType.None;
            gridColumn7.HeaderStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gridColumn7.Name = "*";
            gridColumn7.Width = 50;
            gridColumn8.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleLeft;
            gridColumn8.ColumnSortMode = DevComponents.DotNetBar.SuperGrid.ColumnSortMode.None;
            gridColumn8.FilterAutoScan = true;
            gridColumn8.HeaderStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gridColumn8.InfoImageAlignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gridColumn8.Name = "رقم / إسم الإدارة";
            gridColumn8.ReadOnly = true;
            gridColumn8.Width = 263;
            gridColumn9.ReadOnly = true;
            gridColumn9.Visible = false;
            this.dataGridViewX_Section.PrimaryGrid.Columns.Add(gridColumn7);
            this.dataGridViewX_Section.PrimaryGrid.Columns.Add(gridColumn8);
            this.dataGridViewX_Section.PrimaryGrid.Columns.Add(gridColumn9);
            this.dataGridViewX_Section.PrimaryGrid.DefaultRowHeight = 24;
            background5.Color1 = System.Drawing.Color.White;
            background5.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dataGridViewX_Section.PrimaryGrid.DefaultVisualStyles.AlternateColumnCellStyles.Default.Background = background5;
            background6.Color1 = System.Drawing.Color.White;
            background6.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dataGridViewX_Section.PrimaryGrid.DefaultVisualStyles.AlternateRowCellStyles.Default.Background = background6;
            this.dataGridViewX_Section.PrimaryGrid.DefaultVisualStyles.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            this.dataGridViewX_Section.PrimaryGrid.DefaultVisualStyles.FilterColumnHeaderStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            this.dataGridViewX_Section.PrimaryGrid.EnableColumnFiltering = true;
            this.dataGridViewX_Section.PrimaryGrid.EnableFiltering = true;
            this.dataGridViewX_Section.PrimaryGrid.EnableRowFiltering = true;
            this.dataGridViewX_Section.PrimaryGrid.Filter.Visible = true;
            this.dataGridViewX_Section.PrimaryGrid.FilterLevel = ((DevComponents.DotNetBar.SuperGrid.FilterLevel)((DevComponents.DotNetBar.SuperGrid.FilterLevel.Root | DevComponents.DotNetBar.SuperGrid.FilterLevel.Expanded)));
            this.dataGridViewX_Section.PrimaryGrid.FilterMatchType = DevComponents.DotNetBar.SuperGrid.FilterMatchType.RegularExpressions;
            this.dataGridViewX_Section.PrimaryGrid.MultiSelect = false;
            this.dataGridViewX_Section.PrimaryGrid.NullString = "-----";
            this.dataGridViewX_Section.PrimaryGrid.RowHeaderWidth = 45;
            this.dataGridViewX_Section.PrimaryGrid.ShowColumnHeader = false;
            this.dataGridViewX_Section.PrimaryGrid.ShowRowGridIndex = true;
            this.dataGridViewX_Section.PrimaryGrid.ShowRowHeaders = false;
            this.dataGridViewX_Section.PrimaryGrid.UseAlternateRowStyle = true;
            this.dataGridViewX_Section.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dataGridViewX_Section.Size = new System.Drawing.Size(313, 0);
            this.dataGridViewX_Section.TabIndex = 481;
            // 
            // expandablePanel_Dept
            // 
            this.expandablePanel_Dept.CanvasColor = System.Drawing.SystemColors.Control;
            this.expandablePanel_Dept.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.expandablePanel_Dept.Controls.Add(this.itemPanel1);
            this.expandablePanel_Dept.Dock = System.Windows.Forms.DockStyle.Top;
            this.expandablePanel_Dept.Expanded = false;
            this.expandablePanel_Dept.ExpandedBounds = new System.Drawing.Rectangle(0, 26, 314, 120);
            this.expandablePanel_Dept.ExpandOnTitleClick = true;
            this.expandablePanel_Dept.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.expandablePanel_Dept.Location = new System.Drawing.Point(0, 26);
            this.expandablePanel_Dept.Name = "expandablePanel_Dept";
            this.expandablePanel_Dept.Size = new System.Drawing.Size(30, 26);
            this.expandablePanel_Dept.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanel_Dept.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.expandablePanel_Dept.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.expandablePanel_Dept.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandablePanel_Dept.Style.GradientAngle = 90;
            this.expandablePanel_Dept.TabIndex = 3;
            this.expandablePanel_Dept.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandablePanel_Dept.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            this.expandablePanel_Dept.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandablePanel_Dept.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.expandablePanel_Dept.TitleStyle.GradientAngle = 90;
            this.expandablePanel_Dept.TitleStyle.MarginLeft = 12;
            this.expandablePanel_Dept.TitleText = "الإدارة";
            // 
            // itemPanel1
            // 
            // 
            // 
            // 
            this.itemPanel1.BackgroundStyle.BackColor = System.Drawing.Color.AliceBlue;
            this.itemPanel1.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.itemPanel1.BackgroundStyle.BorderBottomWidth = 1;
            this.itemPanel1.BackgroundStyle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            this.itemPanel1.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.itemPanel1.BackgroundStyle.BorderLeftWidth = 1;
            this.itemPanel1.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.itemPanel1.BackgroundStyle.BorderRightWidth = 1;
            this.itemPanel1.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.itemPanel1.BackgroundStyle.BorderTopWidth = 1;
            this.itemPanel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.itemPanel1.BackgroundStyle.PaddingBottom = 1;
            this.itemPanel1.BackgroundStyle.PaddingLeft = 1;
            this.itemPanel1.BackgroundStyle.PaddingRight = 1;
            this.itemPanel1.BackgroundStyle.PaddingTop = 1;
            this.itemPanel1.ContainerControlProcessDialogKey = true;
            this.itemPanel1.Controls.Add(this.dataGridViewX_Dept);
            this.itemPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.itemPanel1.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.itemPanel1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.itemPanel1.Location = new System.Drawing.Point(0, 26);
            this.itemPanel1.Name = "itemPanel1";
            this.itemPanel1.Size = new System.Drawing.Size(30, 0);
            this.itemPanel1.TabIndex = 3;
            this.itemPanel1.Text = "itemPanel1";
            // 
            // dataGridViewX_Dept
            // 
            this.dataGridViewX_Dept.BackColor = System.Drawing.SystemColors.ControlLight;
            this.dataGridViewX_Dept.Dock = System.Windows.Forms.DockStyle.Left;
            this.dataGridViewX_Dept.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            this.dataGridViewX_Dept.ForeColor = System.Drawing.Color.Black;
            this.dataGridViewX_Dept.HScrollBarVisible = false;
            this.dataGridViewX_Dept.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.dataGridViewX_Dept.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewX_Dept.Name = "dataGridViewX_Dept";
            this.dataGridViewX_Dept.PrimaryGrid.AllowRowHeaderResize = true;
            this.dataGridViewX_Dept.PrimaryGrid.AllowRowResize = true;
            this.dataGridViewX_Dept.PrimaryGrid.ColumnHeader.RowHeight = 30;
            this.dataGridViewX_Dept.PrimaryGrid.ColumnHeader.SortImageAlignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            this.dataGridViewX_Dept.PrimaryGrid.ColumnHeader.Visible = false;
            gridColumn10.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleLeft;
            gridColumn10.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridCheckBoxXEditControl);
            gridColumn10.FilterEditType = DevComponents.DotNetBar.SuperGrid.FilterEditType.None;
            gridColumn10.HeaderStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gridColumn10.Name = "*";
            gridColumn10.Width = 50;
            gridColumn11.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleLeft;
            gridColumn11.ColumnSortMode = DevComponents.DotNetBar.SuperGrid.ColumnSortMode.None;
            gridColumn11.FilterAutoScan = true;
            gridColumn11.HeaderStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gridColumn11.InfoImageAlignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gridColumn11.Name = "رقم / إسم الإدارة";
            gridColumn11.ReadOnly = true;
            gridColumn11.Width = 263;
            gridColumn12.ReadOnly = true;
            gridColumn12.Visible = false;
            this.dataGridViewX_Dept.PrimaryGrid.Columns.Add(gridColumn10);
            this.dataGridViewX_Dept.PrimaryGrid.Columns.Add(gridColumn11);
            this.dataGridViewX_Dept.PrimaryGrid.Columns.Add(gridColumn12);
            this.dataGridViewX_Dept.PrimaryGrid.DefaultRowHeight = 24;
            background7.Color1 = System.Drawing.Color.White;
            background7.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dataGridViewX_Dept.PrimaryGrid.DefaultVisualStyles.AlternateColumnCellStyles.Default.Background = background7;
            background8.Color1 = System.Drawing.Color.White;
            background8.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dataGridViewX_Dept.PrimaryGrid.DefaultVisualStyles.AlternateRowCellStyles.Default.Background = background8;
            this.dataGridViewX_Dept.PrimaryGrid.DefaultVisualStyles.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            this.dataGridViewX_Dept.PrimaryGrid.DefaultVisualStyles.FilterColumnHeaderStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            this.dataGridViewX_Dept.PrimaryGrid.EnableColumnFiltering = true;
            this.dataGridViewX_Dept.PrimaryGrid.EnableFiltering = true;
            this.dataGridViewX_Dept.PrimaryGrid.EnableRowFiltering = true;
            this.dataGridViewX_Dept.PrimaryGrid.Filter.Visible = true;
            this.dataGridViewX_Dept.PrimaryGrid.FilterLevel = ((DevComponents.DotNetBar.SuperGrid.FilterLevel)((DevComponents.DotNetBar.SuperGrid.FilterLevel.Root | DevComponents.DotNetBar.SuperGrid.FilterLevel.Expanded)));
            this.dataGridViewX_Dept.PrimaryGrid.FilterMatchType = DevComponents.DotNetBar.SuperGrid.FilterMatchType.RegularExpressions;
            this.dataGridViewX_Dept.PrimaryGrid.MultiSelect = false;
            this.dataGridViewX_Dept.PrimaryGrid.NullString = "-----";
            this.dataGridViewX_Dept.PrimaryGrid.RowHeaderWidth = 45;
            this.dataGridViewX_Dept.PrimaryGrid.ShowColumnHeader = false;
            this.dataGridViewX_Dept.PrimaryGrid.ShowRowGridIndex = true;
            this.dataGridViewX_Dept.PrimaryGrid.ShowRowHeaders = false;
            this.dataGridViewX_Dept.PrimaryGrid.UseAlternateRowStyle = true;
            this.dataGridViewX_Dept.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dataGridViewX_Dept.Size = new System.Drawing.Size(313, 0);
            this.dataGridViewX_Dept.TabIndex = 481;
            // 
            // ButExit
            // 
            this.ButExit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.ButExit.Checked = true;
            this.ButExit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.ButExit.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.ButExit.Location = new System.Drawing.Point(36, 187);
            this.ButExit.Name = "ButExit";
            this.ButExit.Size = new System.Drawing.Size(135, 33);
            this.ButExit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ButExit.Symbol = "";
            this.ButExit.SymbolSize = 16F;
            this.ButExit.TabIndex = 5;
            this.ButExit.Text = "خـــروج";
            this.ButExit.TextColor = System.Drawing.Color.Black;
            this.ButExit.Click += new System.EventHandler(this.ButExit_Click);
            // 
            // ButOk
            // 
            this.ButOk.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.ButOk.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.ButOk.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.ButOk.Location = new System.Drawing.Point(173, 187);
            this.ButOk.Name = "ButOk";
            this.ButOk.Size = new System.Drawing.Size(135, 33);
            this.ButOk.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ButOk.Symbol = "";
            this.ButOk.SymbolSize = 16F;
            this.ButOk.TabIndex = 4;
            this.ButOk.Text = "تحـــديث";
            this.ButOk.TextColor = System.Drawing.Color.White;
            this.ButOk.Click += new System.EventHandler(this.ButOk_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.textBox_AccHousing);
            this.groupBox1.Controls.Add(this.textBox_AccLoan);
            this.groupBox1.Controls.Add(this.textBox_AccSal);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.groupBox1.ForeColor = System.Drawing.Color.Maroon;
            this.groupBox1.Location = new System.Drawing.Point(35, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(272, 167);
            this.groupBox1.TabIndex = 6795;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "حسابات الموظف";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(195, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 6799;
            this.label2.Text = "بدل السكن :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(195, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 6796;
            this.label1.Text = "الســـــــلف :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(195, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 6795;
            this.label5.Text = "الـــراتـــــب :";
            // 
            // textBox_AccHousing
            // 
            this.textBox_AccHousing.BackColor = System.Drawing.Color.DarkSeaGreen;
            // 
            // 
            // 
            this.textBox_AccHousing.Border.Class = "TextBoxBorder";
            this.textBox_AccHousing.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBox_AccHousing.ButtonCustom.Visible = true;
            this.textBox_AccHousing.Font = new System.Drawing.Font("Tahoma", 9F);
            this.textBox_AccHousing.Location = new System.Drawing.Point(8, 122);
            this.textBox_AccHousing.Name = "textBox_AccHousing";
            this.textBox_AccHousing.Size = new System.Drawing.Size(185, 22);
            this.textBox_AccHousing.TabIndex = 3;
            this.textBox_AccHousing.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_AccHousing.ButtonCustomClick += new System.EventHandler(this.textBox_AccHousing_ButtonCustomClick);
            // 
            // textBox_AccLoan
            // 
            this.textBox_AccLoan.BackColor = System.Drawing.Color.DarkSeaGreen;
            // 
            // 
            // 
            this.textBox_AccLoan.Border.Class = "TextBoxBorder";
            this.textBox_AccLoan.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBox_AccLoan.ButtonCustom.Visible = true;
            this.textBox_AccLoan.Font = new System.Drawing.Font("Tahoma", 9F);
            this.textBox_AccLoan.Location = new System.Drawing.Point(8, 80);
            this.textBox_AccLoan.Name = "textBox_AccLoan";
            this.textBox_AccLoan.Size = new System.Drawing.Size(185, 22);
            this.textBox_AccLoan.TabIndex = 2;
            this.textBox_AccLoan.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_AccLoan.ButtonCustomClick += new System.EventHandler(this.textBox_AccLoan_ButtonCustomClick);
            // 
            // textBox_AccSal
            // 
            this.textBox_AccSal.BackColor = System.Drawing.Color.DarkSeaGreen;
            // 
            // 
            // 
            this.textBox_AccSal.Border.Class = "TextBoxBorder";
            this.textBox_AccSal.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBox_AccSal.ButtonCustom.Visible = true;
            this.textBox_AccSal.Font = new System.Drawing.Font("Tahoma", 9F);
            this.textBox_AccSal.Location = new System.Drawing.Point(8, 38);
            this.textBox_AccSal.Name = "textBox_AccSal";
            this.textBox_AccSal.Size = new System.Drawing.Size(185, 22);
            this.textBox_AccSal.TabIndex = 1;
            this.textBox_AccSal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_AccSal.ButtonCustomClick += new System.EventHandler(this.textBox_AccSal_ButtonCustomClick);
            // 
            // FrmGenAcc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(315, 243);
            this.Controls.Add(this.ribbonBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(InvAcc.Properties.Resources.favicon));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "FrmGenAcc";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تحــــديث حسابات الموظفــــين";
            this.Load += new System.EventHandler(this.FrmGenAcc_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmGenAcc_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FrmGenAcc_KeyPress);
            this.ribbonBar1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.expandablePanel_Girds.ResumeLayout(false);
            this.expandablePanel_Emp.ResumeLayout(false);
            this.itemPanel4.ResumeLayout(false);
            this.expandablePanel_Job.ResumeLayout(false);
            this.itemPanel3.ResumeLayout(false);
            this.expandablePanel_Section.ResumeLayout(false);
            this.itemPanel2.ResumeLayout(false);
            this.expandablePanel_Dept.ResumeLayout(false);
            this.itemPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.Icon = ((System.Drawing.Icon)(InvAcc.Properties.Resources.favicon));
            this.ResumeLayout(false);
        }
        public void RefreshPKeys()
        {
            PKeys.Clear();
            var qkeys = from item in db.T_Emps
                        orderby item.Emp_No
                        where item.EmpState == (bool?)true
                        select new
                        {
                            Code = item.Emp_No
                        };
            int count = 0;
            foreach (var item2 in qkeys)
            {
                count++;
                PKeys.Add(item2.Code);
            }
        }
        public FrmGenAcc()
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
                ButOk.Text = "تعميـــم F6";
                ButExit.Text = "خـــروج Esc";
                expandablePanel_Dept.Text = "الإدارة";
                expandablePanel_Section.Text = "القسم";
                expandablePanel_Job.Text = "الوظيفة";
                expandablePanel_Emp.Text = "الموظف";
                expandablePanel_Girds.TitleText = "على حسب";
                Text = "تحــــديث حسابات الموظفــــين";
            }
            else
            {
                ButOk.Text = "Update F6";
                ButExit.Text = "Close Esc";
                expandablePanel_Dept.Text = "Department";
                expandablePanel_Section.Text = "Section";
                expandablePanel_Job.Text = "Job";
                expandablePanel_Emp.Text = "Employee";
                expandablePanel_Girds.TitleText = "depend on";
                Text = "Update Acconunting of Employee";
            }
        }
        private void FrmGenAcc_Load(object sender, EventArgs e)
        {
            try
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmGenAcc));
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
                try
                {
                    ADD_Controls();
                    Clear();
                    FillGrid();
                    RefreshPKeys();
                }
                catch (Exception error2)
                {
                    VarGeneral.DebLog.writeLog("FrmGenAttend_Load:", error2, enable: true);
                    MessageBox.Show(error2.Message);
                }
            }
            catch (Exception error2)
            {
                VarGeneral.DebLog.writeLog("Load:", error2, enable: true);
                MessageBox.Show(error2.Message);
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
        public void Clear()
        {
            data_this = new T_Emp();
            Data_this_Attend = new T_Attend();
            Update_Attend = new BindingList<T_Attend>();
            for (int i = 0; i < controls.Count; i++)
            {
                if (controls[i].GetType() == typeof(DateTimePicker))
                {
                    int? calendr = VarGeneral.Settings_Sys.Calendr;
                    if (calendr.Value == 0 && calendr.HasValue)
                    {
                        (controls[i] as DateTimePicker).Text = VarGeneral.Gdate;
                    }
                    else
                    {
                        (controls[i] as DateTimePicker).Text = VarGeneral.Hdate;
                    }
                }
                else if (controls[i].GetType() == typeof(DateTimeInput))
                {
                    (controls[i] as DateTimeInput).Value = DateTime.Now;
                }
                else if (controls[i].GetType() == typeof(ComboBox) && (controls[i] as ComboBox).Items.Count > 0)
                {
                    try
                    {
                        (controls[i] as ComboBox).SelectedIndex = 0;
                    }
                    catch
                    {
                        (controls[i] as ComboBox).SelectedIndex = -1;
                    }
                }
                else if (controls[i].GetType() == typeof(CheckBox))
                {
                    (controls[i] as CheckBox).Checked = false;
                }
                else if (controls[i].GetType() == typeof(PictureBox))
                {
                    (controls[i] as PictureBox).Image = null;
                }
                else if (!(controls[i].Name == codeControl.Name))
                {
                    if (controls[i].GetType() == typeof(DoubleInput))
                    {
                        (controls[i] as DoubleInput).Value = 0.0;
                    }
                    else if (controls[i].GetType() == typeof(IntegerInput))
                    {
                        (controls[i] as IntegerInput).Value = 0;
                    }
                    else if (controls[i].GetType() == typeof(TextBox) || controls[i].GetType() == typeof(TextBoxX) || controls[i].GetType() == typeof(MaskedTextBox))
                    {
                        controls[i].Text = "";
                    }
                    else if (controls[i].GetType() == typeof(CheckBox))
                    {
                        (controls[i] as CheckBox).Checked = false;
                    }
                    else if (controls[i].GetType() == typeof(RadioButton))
                    {
                        (controls[i] as RadioButton).Checked = false;
                    }
                }
            }
        }
        private void ADD_Controls()
        {
            try
            {
                controls = new List<Control>();
                controls.Add(textBox_AccSal);
                controls.Add(textBox_AccLoan);
                controls.Add(textBox_AccHousing);
            }
            catch (SqlException)
            {
            }
        }
        private void expandablePanel_Section_ExpandedChanging(object sender, ExpandedChangeEventArgs e)
        {
            if (!expandablePanel_Girds.ExpandButtonVisible)
            {
                e.Cancel = true;
            }
        }
        private void FrmGenAcc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                SendKeys.Send("{Tab}");
            }
        }
        private void FrmGenAcc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F6 && ButOk.Enabled && ButOk.Visible)
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
                if (MessageBox.Show((LangArEn == 0) ? "سيتم تحديث حسابات الموظفين .. هل تريد المتابعة ?" : "Staff will update the accounts .. Do you want to continue ?", VarGeneral.ProdectNam, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.No)
                {
                    Save(value: true);
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Button_Ok_Click:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void Save(bool value)
        {
            string tmpStr = "";
            string QStr = "";
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
            if (!string.IsNullOrEmpty(textBox_AccSal.Text))
            {
                db.ExecuteCommand(string.Concat("UPDATE [dbo].[T_Emp] Set SalAcc = '", textBox_AccSal.Tag, "' WHERE EmpState = 1 ", QStr));
            }
            else
            {
                db.ExecuteCommand("UPDATE [dbo].[T_Emp] Set SalAcc = null WHERE EmpState = 1 " + QStr);
            }
            if (!string.IsNullOrEmpty(textBox_AccLoan.Text))
            {
                db.ExecuteCommand(string.Concat("UPDATE [dbo].[T_Emp] Set LoanAcc = '", textBox_AccLoan.Tag, "' WHERE EmpState = 1 ", QStr));
            }
            else
            {
                db.ExecuteCommand("UPDATE [dbo].[T_Emp] Set LoanAcc = null WHERE EmpState = 1 " + QStr);
            }
            if (!string.IsNullOrEmpty(textBox_AccHousing.Text))
            {
                db.ExecuteCommand(string.Concat("UPDATE [dbo].[T_Emp] Set HouseAcc = '", textBox_AccHousing.Tag, "' WHERE EmpState = 1 ", QStr));
            }
            else
            {
                db.ExecuteCommand("UPDATE [dbo].[T_Emp] Set HouseAcc = null WHERE EmpState = 1 " + QStr);
            }
            MessageBox.Show((LangArEn == 0) ? "تمت عملية التحديث بنجاح " : "The completion of the process has been successfully", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
        public void SetData(T_Emp value)
        {
            Update_Attend = new BindingList<T_Attend>(value.T_Attends);
        }
        private T_Emp GetData()
        {
            try
            {
                data_this.Emp_No = data_this.Emp_No;
            }
            catch
            {
            }
            return data_this;
        }
        private void ButExit_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void textBox_AccSal_ButtonCustomClick(object sender, EventArgs e)
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
            VarGeneral.SFrmTyp = "AccDefID_Setting";
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != "")
            {
                textBox_AccSal.Tag = db.StockAccDefs(int.Parse(frm.Serach_No)).AccDef_No;
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                {
                    textBox_AccSal.Text = db.StockAccDefs(int.Parse(frm.Serach_No)).Arb_Des;
                }
                else
                {
                    textBox_AccSal.Text = db.StockAccDefs(int.Parse(frm.Serach_No)).Eng_Des;
                }
            }
            else
            {
                textBox_AccSal.Tag = "";
                textBox_AccSal.Text = "";
            }
        }
        private void textBox_AccLoan_ButtonCustomClick(object sender, EventArgs e)
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
            VarGeneral.SFrmTyp = "AccDefID_Setting";
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != "")
            {
                textBox_AccLoan.Tag = db.StockAccDefs(int.Parse(frm.Serach_No)).AccDef_No;
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                {
                    textBox_AccLoan.Text = db.StockAccDefs(int.Parse(frm.Serach_No)).Arb_Des;
                }
                else
                {
                    textBox_AccLoan.Text = db.StockAccDefs(int.Parse(frm.Serach_No)).Eng_Des;
                }
            }
            else
            {
                textBox_AccLoan.Tag = "";
                textBox_AccLoan.Text = "";
            }
        }
        private void textBox_AccHousing_ButtonCustomClick(object sender, EventArgs e)
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
            VarGeneral.SFrmTyp = "AccDefID_Setting";
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != "")
            {
                textBox_AccHousing.Tag = db.StockAccDefs(int.Parse(frm.Serach_No)).AccDef_No;
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                {
                    textBox_AccHousing.Text = db.StockAccDefs(int.Parse(frm.Serach_No)).Arb_Des;
                }
                else
                {
                    textBox_AccHousing.Text = db.StockAccDefs(int.Parse(frm.Serach_No)).Eng_Des;
                }
            }
            else
            {
                textBox_AccHousing.Tag = "";
                textBox_AccHousing.Text = "";
            }
        }
    }
}
