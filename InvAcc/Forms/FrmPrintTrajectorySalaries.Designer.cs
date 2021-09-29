   

namespace InvAcc.Forms
{
partial class FrmPrintTrajectorySalaries
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
    
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrintTrajectorySalaries));
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
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.buttonItem_ListSal = new DevComponents.DotNetBar.ButtonItem();
            this.ToolStripMenuItem_PrintSalary = new DevComponents.DotNetBar.ButtonItem();
            this.ToolStripMenuItem_PrintSalaryDet = new DevComponents.DotNetBar.ButtonItem();
            this.ToolStripMenuItem_PrintBankID = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem_ListAdd = new DevComponents.DotNetBar.ButtonItem();
            this.ToolStripMenuItem_PrintAllownces = new DevComponents.DotNetBar.ButtonItem();
            this.ToolStripMenuItem_PrintAdd = new DevComponents.DotNetBar.ButtonItem();
            this.ToolStripMenuItem_PrintReward = new DevComponents.DotNetBar.ButtonItem();
            this.ToolStripMenuItem_PrintDiscount = new DevComponents.DotNetBar.ButtonItem();
            this.ToolStripMenuItem_PrintAdvances = new DevComponents.DotNetBar.ButtonItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ButClose = new DevComponents.DotNetBar.ButtonX();
            this.comboBox_Month = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboBox_OrderBy = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_DayOfMonth = new DevComponents.Editors.IntegerInput();
            this.label3 = new System.Windows.Forms.Label();
            this.netResize1 = new Softgroup.NetResize.NetResize(this.components);  this.netResize1.LabelsAutoEllipse = false;
            this.netResize1.AfterControlResize += new Softgroup.NetResize.NetResize.AfterControlResizeEventHandler(this.netResize1_AfterControlResize);
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
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_DayOfMonth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).BeginInit();
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
            this.ribbonBar1.BackgroundStyle.BackColor = System.Drawing.Color.AliceBlue;
            this.ribbonBar1.BackgroundStyle.BackColor2 = System.Drawing.SystemColors.GradientActiveCaption;
            this.ribbonBar1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar1.ContainerControlProcessDialogKey = true;
            this.ribbonBar1.Controls.Add(this.panel1);
            this.ribbonBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonBar1.Tag= "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.ribbonBar1.Location = new System.Drawing.Point(0, 0);
            this.ribbonBar1.Name = "ribbonBar1";
            this.ribbonBar1.Size = new System.Drawing.Size(314, 269);
            this.ribbonBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this.ribbonBar1.TabIndex = 1104;
            // 
            // 
            // 
            this.ribbonBar1.TitleStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
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
            this.panel1.Controls.Add(this.bar1);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(314, 252);
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
            this.expandablePanel_Girds.ExpandedBounds = new System.Drawing.Rectangle(0, 27, 314, 225);
            this.expandablePanel_Girds.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.expandablePanel_Girds.Location = new System.Drawing.Point(0, 25);
            this.expandablePanel_Girds.Name = "expandablePanel_Girds";
            this.expandablePanel_Girds.Size = new System.Drawing.Size(30, 227);
            this.expandablePanel_Girds.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanel_Girds.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.expandablePanel_Girds.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandablePanel_Girds.Style.GradientAngle = 90;
            this.expandablePanel_Girds.TabIndex = 6781;
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
            this.expandablePanel_Emp.ExpandedChanging += new DevComponents.DotNetBar.ExpandChangeEventHandler(this.expandablePanel_Emp_ExpandedChanging);
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
            this.itemPanel4.Tag= "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
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
            this.dataGridViewX_Emp.Tag= "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
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
            this.dataGridViewX_Emp.PrimaryGrid.FilterLevel = ((DevComponents.DotNetBar.SuperGrid.FilterLevel.Root | DevComponents.DotNetBar.SuperGrid.FilterLevel.Expanded));
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
            this.expandablePanel_Job.ExpandedChanging += new DevComponents.DotNetBar.ExpandChangeEventHandler(this.expandablePanel_Job_ExpandedChanging);
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
            this.itemPanel3.Tag= "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
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
            this.dataGridViewX_Job.Tag= "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
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
            this.dataGridViewX_Job.PrimaryGrid.FilterLevel = ((DevComponents.DotNetBar.SuperGrid.FilterLevel.Root | DevComponents.DotNetBar.SuperGrid.FilterLevel.Expanded));
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
            this.expandablePanel_Section.ExpandedChanging += new DevComponents.DotNetBar.ExpandChangeEventHandler(this.expandablePanel_Section_ExpandedChanging);
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
            this.itemPanel2.Tag= "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
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
            this.dataGridViewX_Section.Tag= "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
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
            this.dataGridViewX_Section.PrimaryGrid.FilterLevel = ((DevComponents.DotNetBar.SuperGrid.FilterLevel.Root | DevComponents.DotNetBar.SuperGrid.FilterLevel.Expanded));
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
            this.expandablePanel_Dept.ExpandedBounds = new System.Drawing.Rectangle(0, 26, 30, 120);
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
            this.expandablePanel_Dept.ExpandedChanging += new DevComponents.DotNetBar.ExpandChangeEventHandler(this.expandablePanel_Dept_ExpandedChanging);
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
            this.itemPanel1.Tag= "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
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
            this.dataGridViewX_Dept.Tag= "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
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
            this.dataGridViewX_Dept.PrimaryGrid.FilterLevel = ((DevComponents.DotNetBar.SuperGrid.FilterLevel.Root | DevComponents.DotNetBar.SuperGrid.FilterLevel.Expanded));
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
            // bar1
            // 
            this.bar1.AntiAlias = true;
            this.bar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.bar1.DockSide = DevComponents.DotNetBar.eDockSide.Document;
            this.bar1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.buttonItem_ListSal,
            this.buttonItem_ListAdd});
            this.bar1.Location = new System.Drawing.Point(0, 0);
            this.bar1.Name = "bar1";
            this.bar1.Size = new System.Drawing.Size(314, 25);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar1.TabIndex = 6777;
            this.bar1.TabStop = false;
            this.bar1.Text = "bar1";
            // 
            // buttonItem_ListSal
            // 
            this.buttonItem_ListSal.BeginGroup = true;
            this.buttonItem_ListSal.Checked = true;
            this.buttonItem_ListSal.FontBold = true;
            this.buttonItem_ListSal.Name = "buttonItem_ListSal";
            this.buttonItem_ListSal.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.ToolStripMenuItem_PrintSalary,
            this.ToolStripMenuItem_PrintSalaryDet,
            this.ToolStripMenuItem_PrintBankID});
            this.buttonItem_ListSal.SubItemsExpandWidth = 45;
            this.buttonItem_ListSal.Text = "المســــيّرات";
            // 
            // ToolStripMenuItem_PrintSalary
            // 
            this.ToolStripMenuItem_PrintSalary.BeginGroup = true;
            this.ToolStripMenuItem_PrintSalary.Name = "ToolStripMenuItem_PrintSalary";
            this.ToolStripMenuItem_PrintSalary.SymbolSize = 9F;
            this.ToolStripMenuItem_PrintSalary.Text = "مسّير رواتب الموظفين";
            this.ToolStripMenuItem_PrintSalary.Click += new System.EventHandler(this.ToolStripMenuItem_PrintSalary_Click);
            // 
            // ToolStripMenuItem_PrintSalaryDet
            // 
            this.ToolStripMenuItem_PrintSalaryDet.Name = "ToolStripMenuItem_PrintSalaryDet";
            this.ToolStripMenuItem_PrintSalaryDet.SymbolSize = 9F;
            this.ToolStripMenuItem_PrintSalaryDet.Text = "تقرير راتــــــب الموظف ";
            this.ToolStripMenuItem_PrintSalaryDet.Click += new System.EventHandler(this.ToolStripMenuItem_PrintSalaryDet_Click);
            // 
            // ToolStripMenuItem_PrintBankID
            // 
            this.ToolStripMenuItem_PrintBankID.BeginGroup = true;
            this.ToolStripMenuItem_PrintBankID.Checked = true;
            this.ToolStripMenuItem_PrintBankID.FontBold = true;
            this.ToolStripMenuItem_PrintBankID.Name = "ToolStripMenuItem_PrintBankID";
            this.ToolStripMenuItem_PrintBankID.Text = "تقرير البنـــك";
            this.ToolStripMenuItem_PrintBankID.Click += new System.EventHandler(this.ToolStripMenuItem_PrintBankID_Click);
            // 
            // buttonItem_ListAdd
            // 
            this.buttonItem_ListAdd.FontBold = true;
            this.buttonItem_ListAdd.Name = "buttonItem_ListAdd";
            this.buttonItem_ListAdd.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.ToolStripMenuItem_PrintAllownces,
            this.ToolStripMenuItem_PrintAdd,
            this.ToolStripMenuItem_PrintReward,
            this.ToolStripMenuItem_PrintDiscount,
            this.ToolStripMenuItem_PrintAdvances});
            this.buttonItem_ListAdd.SubItemsExpandWidth = 45;
            this.buttonItem_ListAdd.Text = "المستحقات والمستقطعات";
            // 
            // ToolStripMenuItem_PrintAllownces
            // 
            this.ToolStripMenuItem_PrintAllownces.BeginGroup = true;
            this.ToolStripMenuItem_PrintAllownces.Checked = true;
            this.ToolStripMenuItem_PrintAllownces.FontBold = true;
            this.ToolStripMenuItem_PrintAllownces.Name = "ToolStripMenuItem_PrintAllownces";
            this.ToolStripMenuItem_PrintAllownces.SymbolSize = 11F;
            this.ToolStripMenuItem_PrintAllownces.Text = "تقرير البدلات";
            this.ToolStripMenuItem_PrintAllownces.Click += new System.EventHandler(this.ToolStripMenuItem_PrintAllownces_Click);
            // 
            // ToolStripMenuItem_PrintAdd
            // 
            this.ToolStripMenuItem_PrintAdd.BeginGroup = true;
            this.ToolStripMenuItem_PrintAdd.Name = "ToolStripMenuItem_PrintAdd";
            this.ToolStripMenuItem_PrintAdd.SymbolSize = 9F;
            this.ToolStripMenuItem_PrintAdd.Text = "تقرير بالإضافــي";
            this.ToolStripMenuItem_PrintAdd.Click += new System.EventHandler(this.ToolStripMenuItem_PrintAdd_Click);
            // 
            // ToolStripMenuItem_PrintReward
            // 
            this.ToolStripMenuItem_PrintReward.Name = "ToolStripMenuItem_PrintReward";
            this.ToolStripMenuItem_PrintReward.SymbolSize = 9F;
            this.ToolStripMenuItem_PrintReward.Text = "تقرير بالحوافز";
            this.ToolStripMenuItem_PrintReward.Click += new System.EventHandler(this.ToolStripMenuItem_PrintReward_Click);
            // 
            // ToolStripMenuItem_PrintDiscount
            // 
            this.ToolStripMenuItem_PrintDiscount.BeginGroup = true;
            this.ToolStripMenuItem_PrintDiscount.Name = "ToolStripMenuItem_PrintDiscount";
            this.ToolStripMenuItem_PrintDiscount.SymbolSize = 9F;
            this.ToolStripMenuItem_PrintDiscount.Text = "تقرير بالخصــم";
            this.ToolStripMenuItem_PrintDiscount.Click += new System.EventHandler(this.ToolStripMenuItem_PrintDiscount_Click);
            // 
            // ToolStripMenuItem_PrintAdvances
            // 
            this.ToolStripMenuItem_PrintAdvances.Name = "ToolStripMenuItem_PrintAdvances";
            this.ToolStripMenuItem_PrintAdvances.SymbolSize = 9F;
            this.ToolStripMenuItem_PrintAdvances.Text = "تقرير بالسلــف";
            this.ToolStripMenuItem_PrintAdvances.Click += new System.EventHandler(this.ToolStripMenuItem_PrintAdvances_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ButClose);
            this.groupBox1.Controls.Add(this.comboBox_Month);
            this.groupBox1.Controls.Add(this.comboBox_OrderBy);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBox_DayOfMonth);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(40, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(262, 205);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // ButClose
            // 
            this.ButClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.ButClose.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.ButClose.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.ButClose.Location = new System.Drawing.Point(66, 133);
            this.ButClose.Name = "ButClose";
            this.ButClose.Size = new System.Drawing.Size(122, 33);
            this.ButClose.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ButClose.Symbol = "";
            this.ButClose.TabIndex = 1595;
            this.ButClose.Text = "إغلاق";
            this.ButClose.TextColor = System.Drawing.Color.White;
            this.ButClose.Click += new System.EventHandler(this.ButClose_Click);
            // 
            // comboBox_Month
            // 
            this.comboBox_Month.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox_Month.DisplayMember = "Text";
            this.comboBox_Month.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBox_Month.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Month.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.comboBox_Month.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.comboBox_Month.FormattingEnabled = true;
            this.comboBox_Month.ItemHeight = 18;
            this.comboBox_Month.Location = new System.Drawing.Point(44, 88);
            this.comboBox_Month.Name = "comboBox_Month";
            this.comboBox_Month.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.comboBox_Month.Size = new System.Drawing.Size(173, 24);
            this.comboBox_Month.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBox_Month.TabIndex = 1594;
            this.comboBox_Month.WatermarkText = "لا يوجد رواتب مرّحلة";
            // 
            // comboBox_OrderBy
            // 
            this.comboBox_OrderBy.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox_OrderBy.DisplayMember = "Text";
            this.comboBox_OrderBy.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBox_OrderBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_OrderBy.FormattingEnabled = true;
            this.comboBox_OrderBy.ItemHeight = 14;
            this.comboBox_OrderBy.Location = new System.Drawing.Point(67, 221);
            this.comboBox_OrderBy.Name = "comboBox_OrderBy";
            this.comboBox_OrderBy.Size = new System.Drawing.Size(169, 20);
            this.comboBox_OrderBy.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBox_OrderBy.TabIndex = 1593;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(77, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 14);
            this.label1.TabIndex = 70;
            this.label1.Text = "تقرير رواتب شهــر";
            // 
            // textBox_DayOfMonth
            // 
            this.textBox_DayOfMonth.AllowEmptyState = false;
            // 
            // 
            // 
            this.textBox_DayOfMonth.BackgroundStyle.Class = "DateTimeInputBackground";
            this.textBox_DayOfMonth.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBox_DayOfMonth.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.textBox_DayOfMonth.Enabled = false;
            this.textBox_DayOfMonth.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.textBox_DayOfMonth.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.textBox_DayOfMonth.Location = new System.Drawing.Point(-334, 35);
            this.textBox_DayOfMonth.MaxValue = 31;
            this.textBox_DayOfMonth.MinValue = 1;
            this.textBox_DayOfMonth.Name = "textBox_DayOfMonth";
            this.textBox_DayOfMonth.Size = new System.Drawing.Size(95, 20);
            this.textBox_DayOfMonth.TabIndex = 5;
            this.textBox_DayOfMonth.Value = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(-233, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 69;
            this.label3.Text = "عدد الأيام :";
            // 
            // netResize1
            // 
            this.netResize1.ParentControl = this;
            // 
            // FrmPrintTrajectorySalaries
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 269);
            this.Controls.Add(this.ribbonBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "FrmPrintTrajectorySalaries";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "طبــــــاعة الــــرواتب";
            this.Load += new System.EventHandler(this.FrmPrintTrajectorySalaries_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmPrintTrajectorySalaries_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FrmPrintTrajectorySalaries_KeyPress);
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
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_DayOfMonth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).EndInit();
            this.ResumeLayout(false);
        }//###########&&&&&&&&&&

}
}
