   

namespace InvAcc.Forms
{
partial class FrmAutoAlarmEqar
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
            this.PanelSpecialContainer = new System.Windows.Forms.Panel();

            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn1 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn2 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn3 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn4 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn5 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.Style.Background background1 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.Style.Background background2 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.Style.Background background3 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.Style.Background background4 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn6 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn7 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn8 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn9 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn10 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn11 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.Style.Background background5 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.Style.Background background6 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.Style.Background background7 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.Style.Background background8 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAutoAlarmEqar));
            this.ribbonBar1 = new DevComponents.DotNetBar.RibbonBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl1 = new DevComponents.DotNetBar.TabControl();
            this.tabControlPanel2 = new DevComponents.DotNetBar.TabControlPanel();
            this.tabControl2 = new DevComponents.DotNetBar.TabControl();
            this.tabControlPanel6 = new DevComponents.DotNetBar.TabControlPanel();
            this.superGridControl_Contracts = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            this.tabItem_Contracts = new DevComponents.DotNetBar.TabItem(this.components);
            this.tabControlPanel10 = new DevComponents.DotNetBar.TabControlPanel();
            this.superGridControl_Rent = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            this.tabItem_Rents = new DevComponents.DotNetBar.TabItem(this.components);
            this.tabItem_EqarDoc = new DevComponents.DotNetBar.TabItem(this.components);
            this.tabControlPanel32 = new DevComponents.DotNetBar.TabControlPanel();
            this.tabControlPanel18 = new DevComponents.DotNetBar.TabControlPanel();
            this.tabControlPanel16 = new DevComponents.DotNetBar.TabControlPanel();
            this.netResize1 = new Softgroup.NetResize.NetResize(this.components);
            this.netResize1.AfterControlResize += new Softgroup.NetResize.NetResize.AfterControlResizeEventHandler(this.netResize1_AfterControlResize);
            this.Shown += new System.EventHandler(this.FrmInvSale_Shown);
            this.SizeChanged += new System.EventHandler(this.FrmInvSale_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).BeginInit();

            this.ribbonBar1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabControlPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl2)).BeginInit();
            this.tabControl2.SuspendLayout();
            this.tabControlPanel6.SuspendLayout();
            this.tabControlPanel10.SuspendLayout();

            this.PanelSpecialContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelSpecialContainer.Location = new System.Drawing.Point(0, 0);
            this.PanelSpecialContainer.Name = "PanelSpecialContainer";
            this.PanelSpecialContainer.Size = new System.Drawing.Size(1278, 514);
            this.PanelSpecialContainer.TabIndex = 1220;
            this.Controls.Add(this.PanelSpecialContainer);
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
            this.ribbonBar1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.ribbonBar1.Location = new System.Drawing.Point(0, 0);
            this.ribbonBar1.Name = "ribbonBar1";
            this.ribbonBar1.Size = new System.Drawing.Size(745, 406);
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
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(745, 389);
            this.panel1.TabIndex = 1104;
            // 
            // tabControl1
            // 
            this.tabControl1.BackColor = System.Drawing.Color.Gainsboro;
            this.tabControl1.CanReorderTabs = true;
            this.tabControl1.Controls.Add(this.tabControlPanel2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Tahoma", 8F);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tabControl1.SelectedTabFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.tabControl1.SelectedTabIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(745, 389);
            this.tabControl1.Style = DevComponents.DotNetBar.eTabStripStyle.Metro;
            this.tabControl1.TabIndex = 855;
            this.tabControl1.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.MultilineNoNavigationBox;
            this.tabControl1.Tabs.Add(this.tabItem_EqarDoc);
            // 
            // tabControlPanel2
            // 
            this.tabControlPanel2.Controls.Add(this.tabControl2);
            this.tabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel2.Location = new System.Drawing.Point(0, 27);
            this.tabControlPanel2.Name = "tabControlPanel2";
            this.tabControlPanel2.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel2.Size = new System.Drawing.Size(745, 362);
            this.tabControlPanel2.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.tabControlPanel2.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(210)))), ((int)(((byte)(255)))));
            this.tabControlPanel2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel2.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(165)))), ((int)(((byte)(199)))));
            this.tabControlPanel2.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right)
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel2.Style.GradientAngle = 90;
            this.tabControlPanel2.TabIndex = 2;
            this.tabControlPanel2.TabItem = this.tabItem_EqarDoc;
            // 
            // tabControl2
            // 
            this.tabControl2.BackColor = System.Drawing.Color.Transparent;
            this.tabControl2.CanReorderTabs = true;
            this.tabControl2.ColorScheme.TabItemBackgroundColorBlend.AddRange(new DevComponents.DotNetBar.BackgroundColorBlend[] {
            new DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(220)))), ((int)(((byte)(244))))), 0F),
            new DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(210)))), ((int)(((byte)(254))))), 0.45F),
            new DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(191)))), ((int)(((byte)(243))))), 0.45F),
            new DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(204)))), ((int)(((byte)(233))))), 1F)});
            this.tabControl2.ColorScheme.TabItemHotBackgroundColorBlend.AddRange(new DevComponents.DotNetBar.BackgroundColorBlend[] {
            new DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(237)))), ((int)(((byte)(255))))), 0F),
            new DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(232)))), ((int)(((byte)(255))))), 0.45F),
            new DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(210)))), ((int)(((byte)(255))))), 0.45F),
            new DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(218)))), ((int)(((byte)(255))))), 1F)});
            this.tabControl2.ColorScheme.TabItemHotText = System.Drawing.Color.Black;
            this.tabControl2.ColorScheme.TabItemSelectedBackgroundColorBlend.AddRange(new DevComponents.DotNetBar.BackgroundColorBlend[] {
            new DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(227)))), ((int)(((byte)(217))))), 0F),
            new DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(189)))), ((int)(((byte)(116))))), 0.45F),
            new DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(180)))), ((int)(((byte)(89))))), 0.45F),
            new DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255))))), 1F)});
            this.tabControl2.ColorScheme.TabItemSelectedText = System.Drawing.Color.Black;
            this.tabControl2.ColorScheme.TabItemText = System.Drawing.Color.Black;
            this.tabControl2.Controls.Add(this.tabControlPanel6);
            this.tabControl2.Controls.Add(this.tabControlPanel10);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.tabControl2.ForeColor = System.Drawing.Color.White;
            this.tabControl2.Location = new System.Drawing.Point(1, 1);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tabControl2.SelectedTabFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.tabControl2.SelectedTabIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(743, 360);
            this.tabControl2.Style = DevComponents.DotNetBar.eTabStripStyle.RoundHeader;
            this.tabControl2.TabIndex = 852;
            this.tabControl2.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox;
            this.tabControl2.Tabs.Add(this.tabItem_Contracts);
            this.tabControl2.Tabs.Add(this.tabItem_Rents);
            this.tabControl2.Text = "tabControl2";
            // 
            // tabControlPanel6
            // 
            this.tabControlPanel6.Controls.Add(this.superGridControl_Contracts);
            this.tabControlPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel6.Location = new System.Drawing.Point(0, 25);
            this.tabControlPanel6.Name = "tabControlPanel6";
            this.tabControlPanel6.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel6.Size = new System.Drawing.Size(743, 335);
            this.tabControlPanel6.Style.BackColor1.Color = System.Drawing.Color.White;
            this.tabControlPanel6.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(215)))));
            this.tabControlPanel6.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel6.Style.BorderColor.Color = System.Drawing.SystemColors.ControlDarkDark;
            this.tabControlPanel6.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right)
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel6.Style.GradientAngle = 90;
            this.tabControlPanel6.TabIndex = 7;
            this.tabControlPanel6.TabItem = this.tabItem_Contracts;
            // 
            // superGridControl_Contracts
            // 
            this.superGridControl_Contracts.BackColor = System.Drawing.SystemColors.ControlLight;
            this.superGridControl_Contracts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superGridControl_Contracts.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            this.superGridControl_Contracts.ForeColor = System.Drawing.Color.Black;
            this.superGridControl_Contracts.HScrollBarVisible = false;
            this.superGridControl_Contracts.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.superGridControl_Contracts.Location = new System.Drawing.Point(1, 1);
            this.superGridControl_Contracts.Name = "superGridControl_Contracts";
            this.superGridControl_Contracts.PrimaryGrid.AllowRowHeaderResize = true;
            this.superGridControl_Contracts.PrimaryGrid.AllowRowResize = true;
            this.superGridControl_Contracts.PrimaryGrid.ColumnHeader.RowHeight = 30;
            this.superGridControl_Contracts.PrimaryGrid.ColumnHeader.SortImageAlignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gridColumn1.EnableFiltering = DevComponents.DotNetBar.SuperGrid.Style.Tbool.False;
            gridColumn1.HeaderText = "تاريخ نهاية العقد";
            gridColumn1.Name = "EndContract";
            gridColumn1.Width = 130;
            gridColumn2.EnableFiltering = DevComponents.DotNetBar.SuperGrid.Style.Tbool.False;
            gridColumn2.HeaderText = "تاريخ بداية العقد";
            gridColumn2.Name = "StartContract";
            gridColumn2.Width = 130;
            gridColumn3.EnableFiltering = DevComponents.DotNetBar.SuperGrid.Style.Tbool.False;
            gridColumn3.HeaderText = "إسم المستأجر";
            gridColumn3.Name = "TenantName";
            gridColumn3.Width = 250;
            gridColumn4.EnableFiltering = DevComponents.DotNetBar.SuperGrid.Style.Tbool.False;
            gridColumn4.HeaderText = "رقم المستأجر";
            gridColumn4.Name = "TenantNo";
            gridColumn4.Width = 120;
            gridColumn5.HeaderText = "رقم العقد";
            gridColumn5.Name = "ContractNo";
            gridColumn5.Width = 110;
            this.superGridControl_Contracts.PrimaryGrid.Columns.Add(gridColumn1);
            this.superGridControl_Contracts.PrimaryGrid.Columns.Add(gridColumn2);
            this.superGridControl_Contracts.PrimaryGrid.Columns.Add(gridColumn3);
            this.superGridControl_Contracts.PrimaryGrid.Columns.Add(gridColumn4);
            this.superGridControl_Contracts.PrimaryGrid.Columns.Add(gridColumn5);
            this.superGridControl_Contracts.PrimaryGrid.DefaultRowHeight = 24;
            background1.Color1 = System.Drawing.Color.White;
            background1.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.superGridControl_Contracts.PrimaryGrid.DefaultVisualStyles.AlternateColumnCellStyles.Default.Background = background1;
            background2.Color1 = System.Drawing.Color.White;
            background2.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.superGridControl_Contracts.PrimaryGrid.DefaultVisualStyles.AlternateRowCellStyles.Default.Background = background2;
            this.superGridControl_Contracts.PrimaryGrid.DefaultVisualStyles.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            background3.Color1 = System.Drawing.SystemColors.ActiveCaption;
            background3.Color2 = System.Drawing.SystemColors.GradientInactiveCaption;
            this.superGridControl_Contracts.PrimaryGrid.DefaultVisualStyles.ColumnHeaderStyles.Default.Background = background3;
            this.superGridControl_Contracts.PrimaryGrid.DefaultVisualStyles.FilterColumnHeaderStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            background4.Color1 = System.Drawing.SystemColors.ActiveCaption;
            this.superGridControl_Contracts.PrimaryGrid.DefaultVisualStyles.FilterColumnHeaderStyles.Default.Background = background4;
            this.superGridControl_Contracts.PrimaryGrid.EnableColumnFiltering = true;
            this.superGridControl_Contracts.PrimaryGrid.EnableFiltering = true;
            this.superGridControl_Contracts.PrimaryGrid.EnableRowFiltering = true;
            this.superGridControl_Contracts.PrimaryGrid.FilterLevel = ((DevComponents.DotNetBar.SuperGrid.FilterLevel)((DevComponents.DotNetBar.SuperGrid.FilterLevel.Root | DevComponents.DotNetBar.SuperGrid.FilterLevel.Expanded)));
            this.superGridControl_Contracts.PrimaryGrid.FilterMatchType = DevComponents.DotNetBar.SuperGrid.FilterMatchType.RegularExpressions;
            this.superGridControl_Contracts.PrimaryGrid.MultiSelect = false;
            this.superGridControl_Contracts.PrimaryGrid.NullString = "-----";
            this.superGridControl_Contracts.PrimaryGrid.RowHeaderWidth = 45;
            this.superGridControl_Contracts.PrimaryGrid.ShowRowHeaders = false;
            this.superGridControl_Contracts.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.superGridControl_Contracts.Size = new System.Drawing.Size(741, 333);
            this.superGridControl_Contracts.TabIndex = 485;
            // 
            // tabItem_Contracts
            // 
            this.tabItem_Contracts.AttachedControl = this.tabControlPanel6;
            this.tabItem_Contracts.Name = "tabItem_Contracts";
            this.tabItem_Contracts.Text = "تنبيه بالعقود";
            // 
            // tabControlPanel10
            // 
            this.tabControlPanel10.Controls.Add(this.superGridControl_Rent);
            this.tabControlPanel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel10.Location = new System.Drawing.Point(0, 25);
            this.tabControlPanel10.Name = "tabControlPanel10";
            this.tabControlPanel10.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel10.Size = new System.Drawing.Size(743, 335);
            this.tabControlPanel10.Style.BackColor1.Color = System.Drawing.Color.White;
            this.tabControlPanel10.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(215)))));
            this.tabControlPanel10.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel10.Style.BorderColor.Color = System.Drawing.SystemColors.ControlDarkDark;
            this.tabControlPanel10.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right)
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel10.Style.GradientAngle = 90;
            this.tabControlPanel10.TabIndex = 3;
            this.tabControlPanel10.TabItem = this.tabItem_Rents;
            // 
            // superGridControl_Rent
            // 
            this.superGridControl_Rent.BackColor = System.Drawing.SystemColors.ControlLight;
            this.superGridControl_Rent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superGridControl_Rent.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            this.superGridControl_Rent.ForeColor = System.Drawing.Color.Black;
            this.superGridControl_Rent.HScrollBarVisible = false;
            this.superGridControl_Rent.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.superGridControl_Rent.Location = new System.Drawing.Point(1, 1);
            this.superGridControl_Rent.Name = "superGridControl_Rent";
            this.superGridControl_Rent.PrimaryGrid.AllowRowHeaderResize = true;
            this.superGridControl_Rent.PrimaryGrid.AllowRowResize = true;
            this.superGridControl_Rent.PrimaryGrid.ColumnHeader.RowHeight = 30;
            this.superGridControl_Rent.PrimaryGrid.ColumnHeader.SortImageAlignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gridColumn6.HeaderText = "تاريخه";
            gridColumn6.Name = "Date";
            gridColumn7.HeaderText = "المبلغ المستحق";
            gridColumn7.Name = "RentValue";
            gridColumn7.Width = 120;
            gridColumn8.HeaderText = "رقم العين";
            gridColumn8.Name = "EyeNo";
            gridColumn9.HeaderText = "رقم العقار";
            gridColumn9.Name = "EqarNo";
            gridColumn10.HeaderText = "إسم المستأجر";
            gridColumn10.Name = "TenantName";
            gridColumn10.Width = 220;
            gridColumn11.HeaderText = "رقم المستأجر";
            gridColumn11.Name = "TenantNo";
            this.superGridControl_Rent.PrimaryGrid.Columns.Add(gridColumn6);
            this.superGridControl_Rent.PrimaryGrid.Columns.Add(gridColumn7);
            this.superGridControl_Rent.PrimaryGrid.Columns.Add(gridColumn8);
            this.superGridControl_Rent.PrimaryGrid.Columns.Add(gridColumn9);
            this.superGridControl_Rent.PrimaryGrid.Columns.Add(gridColumn10);
            this.superGridControl_Rent.PrimaryGrid.Columns.Add(gridColumn11);
            this.superGridControl_Rent.PrimaryGrid.DefaultRowHeight = 24;
            background5.Color1 = System.Drawing.Color.White;
            background5.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.superGridControl_Rent.PrimaryGrid.DefaultVisualStyles.AlternateColumnCellStyles.Default.Background = background5;
            background6.Color1 = System.Drawing.Color.White;
            background6.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.superGridControl_Rent.PrimaryGrid.DefaultVisualStyles.AlternateRowCellStyles.Default.Background = background6;
            this.superGridControl_Rent.PrimaryGrid.DefaultVisualStyles.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            background7.Color1 = System.Drawing.SystemColors.ActiveCaption;
            background7.Color2 = System.Drawing.SystemColors.GradientInactiveCaption;
            this.superGridControl_Rent.PrimaryGrid.DefaultVisualStyles.ColumnHeaderStyles.Default.Background = background7;
            this.superGridControl_Rent.PrimaryGrid.DefaultVisualStyles.FilterColumnHeaderStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            background8.Color1 = System.Drawing.SystemColors.ActiveCaption;
            this.superGridControl_Rent.PrimaryGrid.DefaultVisualStyles.FilterColumnHeaderStyles.Default.Background = background8;
            this.superGridControl_Rent.PrimaryGrid.EnableColumnFiltering = true;
            this.superGridControl_Rent.PrimaryGrid.EnableFiltering = true;
            this.superGridControl_Rent.PrimaryGrid.EnableRowFiltering = true;
            this.superGridControl_Rent.PrimaryGrid.FilterLevel = ((DevComponents.DotNetBar.SuperGrid.FilterLevel)((DevComponents.DotNetBar.SuperGrid.FilterLevel.Root | DevComponents.DotNetBar.SuperGrid.FilterLevel.Expanded)));
            this.superGridControl_Rent.PrimaryGrid.FilterMatchType = DevComponents.DotNetBar.SuperGrid.FilterMatchType.RegularExpressions;
            this.superGridControl_Rent.PrimaryGrid.MultiSelect = false;
            this.superGridControl_Rent.PrimaryGrid.NullString = "-----";
            this.superGridControl_Rent.PrimaryGrid.RowHeaderWidth = 45;
            this.superGridControl_Rent.PrimaryGrid.ShowRowGridIndex = true;
            this.superGridControl_Rent.PrimaryGrid.ShowRowHeaders = false;
            this.superGridControl_Rent.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.superGridControl_Rent.Size = new System.Drawing.Size(741, 333);
            this.superGridControl_Rent.TabIndex = 486;
            // 
            // tabItem_Rents
            // 
            this.tabItem_Rents.AttachedControl = this.tabControlPanel10;
            this.tabItem_Rents.Name = "tabItem_Rents";
            this.tabItem_Rents.Text = "تنبيه بالإيجار";
            // 
            // tabItem_EqarDoc
            // 
            this.tabItem_EqarDoc.AttachedControl = this.tabControlPanel2;
            this.tabItem_EqarDoc.Name = "tabItem_EqarDoc";
            this.tabItem_EqarDoc.Text = "";
            // 
            // tabControlPanel32
            // 
            this.tabControlPanel32.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel32.Location = new System.Drawing.Point(0, 25);
            this.tabControlPanel32.Name = "tabControlPanel32";
            this.tabControlPanel32.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel32.Size = new System.Drawing.Size(840, 455);
            this.tabControlPanel32.Style.BackColor1.Color = System.Drawing.Color.White;
            this.tabControlPanel32.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(215)))));
            this.tabControlPanel32.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel32.Style.BorderColor.Color = System.Drawing.SystemColors.ControlDarkDark;
            this.tabControlPanel32.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right)
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel32.Style.GradientAngle = 90;
            this.tabControlPanel32.TabIndex = 3;
            // 
            // tabControlPanel18
            // 
            this.tabControlPanel18.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel18.Location = new System.Drawing.Point(0, 25);
            this.tabControlPanel18.Name = "tabControlPanel18";
            this.tabControlPanel18.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel18.Size = new System.Drawing.Size(840, 455);
            this.tabControlPanel18.Style.BackColor1.Color = System.Drawing.Color.White;
            this.tabControlPanel18.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(215)))));
            this.tabControlPanel18.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel18.Style.BorderColor.Color = System.Drawing.SystemColors.ControlDarkDark;
            this.tabControlPanel18.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right)
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel18.Style.GradientAngle = 90;
            this.tabControlPanel18.TabIndex = 3;
            // 
            // tabControlPanel16
            // 
            this.tabControlPanel16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel16.Location = new System.Drawing.Point(0, 24);
            this.tabControlPanel16.Name = "tabControlPanel16";
            this.tabControlPanel16.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel16.Size = new System.Drawing.Size(950, 456);
            this.tabControlPanel16.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.tabControlPanel16.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel16.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(157)))), ((int)(((byte)(189)))));
            this.tabControlPanel16.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right)
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel16.Style.GradientAngle = 90;
            this.tabControlPanel16.TabIndex = 3;
            // 
            // FrmAutoAlarmEqar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 406);
            this.PanelSpecialContainer.Controls.Add(this.ribbonBar1);
            this.ribbonBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(InvAcc.Properties.Resources.favicon));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "FrmAutoAlarmEqar";
            this.netResize1.AutoSaveLayout = true;
            this.netResize1.ParentControl = this;
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تنبيهات الــــوثائق";
            this.Load += new System.EventHandler(this.FrmAutoAlarmEqar_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmAutoAlarmEqar_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FrmAutoAlarmEqar_KeyPress);
            this.ribbonBar1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabControlPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabControl2)).EndInit();
            this.tabControl2.ResumeLayout(false);
            this.tabControlPanel6.ResumeLayout(false);
            this.tabControlPanel10.ResumeLayout(false);
            this.Icon = ((System.Drawing.Icon)(InvAcc.Properties.Resources.favicon));
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).EndInit();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.ResumeLayout(false);
        }//###########&&&&&&&&&&

}
}
