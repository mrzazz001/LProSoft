namespace InvAcc.Controls
{
    partial class catPanel
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevComponents.DotNetBar.SuperGrid.Style.BorderColor borderColor1 = new DevComponents.DotNetBar.SuperGrid.Style.BorderColor();
            DevComponents.DotNetBar.SuperGrid.Style.BorderPattern borderPattern1 = new DevComponents.DotNetBar.SuperGrid.Style.BorderPattern();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn1 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridRow gridRow1 = new DevComponents.DotNetBar.SuperGrid.GridRow();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(catPanel));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.superGridControl1 = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            this.itemPanel1 = new DevComponents.DotNetBar.ItemPanel();
            this.SpecialContainer = new DevComponents.DotNetBar.ItemContainer();
            this.ITemCOntrolCOntainer = new DevComponents.DotNetBar.ItemContainer();
            this.PItems = new System.Windows.Forms.FlowLayoutPanel();
            this.Pitem2 = new System.Windows.Forms.FlowLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.Letel_Text = new DevComponents.Editors.DoubleInput();
            this.Tot_Text = new DevComponents.Editors.DoubleInput();
            this.Tot_Label = new System.Windows.Forms.Label();
            this.letel_Label = new System.Windows.Forms.Label();
            this.Safi_Label = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.Safi_Text = new DevComponents.Editors.DoubleInput();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX2 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX3 = new DevComponents.DotNetBar.ButtonX();
            this.btnPrevPage = new DevComponents.DotNetBar.ButtonItem();
            this.btnNxtPage = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem_BestSeller = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem1 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem2 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem3 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem4 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem5 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem6 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem7 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem8 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem9 = new DevComponents.DotNetBar.ButtonItem();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.controlContainerItem1 = new DevComponents.DotNetBar.ControlContainerItem();
            this.labelItem1 = new DevComponents.DotNetBar.LabelItem();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.PItems.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Letel_Text)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tot_Text)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Safi_Text)).BeginInit();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.superGridControl1);
            this.splitContainer1.Panel1.Controls.Add(this.itemPanel1);
            this.splitContainer1.Panel1.Controls.Add(this.PItems);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.Size = new System.Drawing.Size(698, 342);
            this.splitContainer1.SplitterDistance = 306;
            this.splitContainer1.TabIndex = 0;
            this.splitContainer1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer1_SplitterMoved);
            this.splitContainer1.SizeChanged += new System.EventHandler(this.splitContainer1_SizeChanged);
            // 
            // superGridControl1
            // 
            borderColor1.Bottom = System.Drawing.Color.Transparent;
            borderColor1.Left = System.Drawing.Color.Transparent;
            borderColor1.Right = System.Drawing.Color.Transparent;
            borderColor1.Top = System.Drawing.Color.Transparent;
            this.superGridControl1.DefaultVisualStyles.GridPanelStyle.BorderColor = borderColor1;
            borderPattern1.Bottom = DevComponents.DotNetBar.SuperGrid.Style.LinePattern.None;
            borderPattern1.Left = DevComponents.DotNetBar.SuperGrid.Style.LinePattern.None;
            borderPattern1.Right = DevComponents.DotNetBar.SuperGrid.Style.LinePattern.None;
            borderPattern1.Top = DevComponents.DotNetBar.SuperGrid.Style.LinePattern.None;
            this.superGridControl1.DefaultVisualStyles.GridPanelStyle.BorderPattern = borderPattern1;
            this.superGridControl1.DefaultVisualStyles.GridPanelStyle.HeaderHLinePattern = DevComponents.DotNetBar.SuperGrid.Style.LinePattern.None;
            this.superGridControl1.DefaultVisualStyles.GridPanelStyle.HorizontalLineColor = System.Drawing.Color.Transparent;
            this.superGridControl1.DefaultVisualStyles.GridPanelStyle.VerticalLineColor = System.Drawing.Color.Transparent;
            this.superGridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superGridControl1.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            this.superGridControl1.Tag= "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.superGridControl1.Location = new System.Drawing.Point(0, 0);
            this.superGridControl1.Name = "superGridControl1";
            this.superGridControl1.PrimaryGrid.AllowEdit = false;
            this.superGridControl1.PrimaryGrid.ColumnHeader.ShowHeaderImages = false;
            this.superGridControl1.PrimaryGrid.ColumnHeader.Visible = false;
            gridColumn1.Name = "";
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn1);
            this.superGridControl1.PrimaryGrid.DefaultVisualStyles.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.TopLeft;
            this.superGridControl1.PrimaryGrid.DefaultVisualStyles.CellStyles.Default.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.superGridControl1.PrimaryGrid.DefaultVisualStyles.CellStyles.Default.TextColor = System.Drawing.Color.White;
            this.superGridControl1.PrimaryGrid.GroupRowHeaderVisibility = DevComponents.DotNetBar.SuperGrid.RowHeaderVisibility.Never;
            this.superGridControl1.PrimaryGrid.Header.AllowSelection = false;
            this.superGridControl1.PrimaryGrid.Header.BackgroundImageLayout = DevComponents.DotNetBar.SuperGrid.GridBackgroundImageLayout.Stretch;
            this.superGridControl1.PrimaryGrid.Header.EnableMarkup = false;
            this.superGridControl1.PrimaryGrid.Header.RowHeaderVisibility = DevComponents.DotNetBar.SuperGrid.RowHeaderVisibility.Never;
            this.superGridControl1.PrimaryGrid.Header.Visible = false;
            this.superGridControl1.PrimaryGrid.InitialActiveRow = DevComponents.DotNetBar.SuperGrid.RelativeRow.None;
            this.superGridControl1.PrimaryGrid.InitialSelection = DevComponents.DotNetBar.SuperGrid.RelativeSelection.None;
            this.superGridControl1.PrimaryGrid.MultiSelect = false;
            gridRow1.AllowSelection = false;
            gridRow1.ShowCheckBox = false;
            gridRow1.ShowTreeButton = false;
            this.superGridControl1.PrimaryGrid.Rows.Add(gridRow1);
            this.superGridControl1.PrimaryGrid.ShowCellInfo = false;
            this.superGridControl1.PrimaryGrid.ShowCheckBox = false;
            this.superGridControl1.PrimaryGrid.ShowColumnHeader = false;
            this.superGridControl1.PrimaryGrid.ShowDropShadow = false;
            this.superGridControl1.PrimaryGrid.ShowEditingImage = false;
            this.superGridControl1.PrimaryGrid.ShowGroupExpand = false;
            this.superGridControl1.PrimaryGrid.ShowGroupUnderline = false;
            this.superGridControl1.PrimaryGrid.ShowInsertRowImage = false;
            this.superGridControl1.PrimaryGrid.ShowRowDirtyMarker = false;
            this.superGridControl1.PrimaryGrid.ShowRowHeaders = false;
            this.superGridControl1.PrimaryGrid.ShowRowInfo = false;
            this.superGridControl1.PrimaryGrid.ShowToolTips = false;
            this.superGridControl1.PrimaryGrid.ShowTreeButton = false;
            this.superGridControl1.PrimaryGrid.ShowWhitespaceRowLines = false;
            this.superGridControl1.Size = new System.Drawing.Size(698, 306);
            this.superGridControl1.TabIndex = 1197;
            this.superGridControl1.Text = "superGridControl1";
            this.superGridControl1.CellActivating += new System.EventHandler<DevComponents.DotNetBar.SuperGrid.GridCellActivatingEventArgs>(this.superGridControl1_CellActivating);
            this.superGridControl1.CellClick += new System.EventHandler<DevComponents.DotNetBar.SuperGrid.GridCellClickEventArgs>(this.superGridControl1_CellClick);
            this.superGridControl1.CellMouseDown += new System.EventHandler<DevComponents.DotNetBar.SuperGrid.GridCellMouseEventArgs>(this.superGridControl1_CellMouseDown);
            this.superGridControl1.EditorValueChanged += new System.EventHandler<DevComponents.DotNetBar.SuperGrid.GridEditEventArgs>(this.superGridControl1_EditorValueChanged);
            this.superGridControl1.RowDeleting += new System.EventHandler<DevComponents.DotNetBar.SuperGrid.GridRowDeletingEventArgs>(this.superGridControl1_RowDeleting);
            this.superGridControl1.Click += new System.EventHandler(this.superGridControl1_Click_1);
            this.superGridControl1.Enter += new System.EventHandler(this.superGridControl1_Enter);
            this.superGridControl1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.superGridControl1_MouseDown);
            // 
            // itemPanel1
            // 
            this.itemPanel1.AutoScroll = true;
            // 
            // 
            // 
            this.itemPanel1.BackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.itemPanel1.BackgroundStyle.BackColorGradientAngle = 90;
            this.itemPanel1.BackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.itemPanel1.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.itemPanel1.BackgroundStyle.BorderBottomWidth = 1;
            this.itemPanel1.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.itemPanel1.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.itemPanel1.BackgroundStyle.BorderLeftWidth = 1;
            this.itemPanel1.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.itemPanel1.BackgroundStyle.BorderRightWidth = 1;
            this.itemPanel1.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.itemPanel1.BackgroundStyle.BorderTopWidth = 1;
            this.itemPanel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.itemPanel1.ContainerControlProcessDialogKey = true;
            this.itemPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.itemPanel1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.SpecialContainer,
            this.ITemCOntrolCOntainer});
            this.itemPanel1.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.itemPanel1.Tag= "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.itemPanel1.Location = new System.Drawing.Point(0, 0);
            this.itemPanel1.Name = "itemPanel1";
            this.itemPanel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.itemPanel1.Size = new System.Drawing.Size(698, 306);
            this.itemPanel1.TabIndex = 1198;
            this.itemPanel1.Text = "itemPanel1";
            this.itemPanel1.ItemClick += new System.EventHandler(this.itemPanel1_ItemClick);
            this.itemPanel1.VisibleChanged += new System.EventHandler(this.itemPanel1_VisibleChanged);
            // 
            // SpecialContainer
            // 
            // 
            // 
            // 
            this.SpecialContainer.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.SpecialContainer.MultiLine = true;
            this.SpecialContainer.Name = "SpecialContainer";
            // 
            // 
            // 
            this.SpecialContainer.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // ITemCOntrolCOntainer
            // 
            // 
            // 
            // 
            this.ITemCOntrolCOntainer.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ITemCOntrolCOntainer.MultiLine = true;
            this.ITemCOntrolCOntainer.Name = "ITemCOntrolCOntainer";
            // 
            // 
            // 
            this.ITemCOntrolCOntainer.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // PItems
            // 
            this.PItems.AutoScroll = true;
            this.PItems.BackColor = System.Drawing.Color.Gainsboro;
            this.PItems.Controls.Add(this.Pitem2);
            this.PItems.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.PItems.Location = new System.Drawing.Point(440, 0);
            this.PItems.Margin = new System.Windows.Forms.Padding(0);
            this.PItems.Name = "PItems";
            this.PItems.Size = new System.Drawing.Size(110, 306);
            this.PItems.TabIndex = 3;
            this.PItems.SizeChanged += new System.EventHandler(this.PItems_SizeChanged);
            this.PItems.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.PItems_ControlAdded);
            this.PItems.Paint += new System.Windows.Forms.PaintEventHandler(this.PItems_Paint_3);
            this.PItems.Resize += new System.EventHandler(this.PItems_Resize);
            // 
            // Pitem2
            // 
            this.Pitem2.AutoScroll = true;
            this.Pitem2.BackColor = System.Drawing.Color.PaleGreen;
            this.Pitem2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Pitem2.Location = new System.Drawing.Point(0, 0);
            this.Pitem2.Margin = new System.Windows.Forms.Padding(0);
            this.Pitem2.Name = "Pitem2";
            this.Pitem2.Size = new System.Drawing.Size(0, 0);
            this.Pitem2.TabIndex = 4;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tableLayoutPanel1.ColumnCount = 11;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37.46032F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.4127F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.5873F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.53968F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 63F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 76F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 243F));
            this.tableLayoutPanel1.Controls.Add(this.Letel_Text, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.Tot_Text, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.Tot_Label, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.letel_Label, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.Safi_Label, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.checkBox1, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.Safi_Text, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(698, 32);
            this.tableLayoutPanel1.TabIndex = 0;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint_1);
            // 
            // Letel_Text
            // 
            this.Letel_Text.AllowEmptyState = false;
            // 
            // 
            // 
            this.Letel_Text.BackgroundStyle.Class = "DateTimeInputBackground";
            this.Letel_Text.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Letel_Text.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.Letel_Text.DisplayFormat = "0.00";
            this.Letel_Text.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Letel_Text.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Letel_Text.Increment = 0D;
            this.Letel_Text.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.Letel_Text.IsInputReadOnly = true;
            this.Letel_Text.Location = new System.Drawing.Point(115, 3);
            this.Letel_Text.MinValue = 0D;
            this.Letel_Text.Name = "Letel_Text";
            this.Letel_Text.Size = new System.Drawing.Size(26, 21);
            this.Letel_Text.TabIndex = 1142;
            // 
            // Tot_Text
            // 
            this.Tot_Text.AllowEmptyState = false;
            // 
            // 
            // 
            this.Tot_Text.BackgroundStyle.Class = "DateTimeInputBackground";
            this.Tot_Text.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Tot_Text.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.Tot_Text.DisplayFormat = "0.00";
            this.Tot_Text.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Tot_Text.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Tot_Text.Increment = 0D;
            this.Tot_Text.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.Tot_Text.IsInputReadOnly = true;
            this.Tot_Text.Location = new System.Drawing.Point(183, 3);
            this.Tot_Text.MinValue = 0D;
            this.Tot_Text.Name = "Tot_Text";
            this.Tot_Text.Size = new System.Drawing.Size(31, 21);
            this.Tot_Text.TabIndex = 1142;
            // 
            // Tot_Label
            // 
            this.Tot_Label.AutoSize = true;
            this.Tot_Label.Dock = System.Windows.Forms.DockStyle.Right;
            this.Tot_Label.Location = new System.Drawing.Point(220, 0);
            this.Tot_Label.Name = "Tot_Label";
            this.Tot_Label.Size = new System.Drawing.Size(52, 27);
            this.Tot_Label.TabIndex = 13;
            this.Tot_Label.Text = "الاجمالي:";
            this.Tot_Label.Click += new System.EventHandler(this.Tot_Label_Click);
            // 
            // letel_Label
            // 
            this.letel_Label.AutoSize = true;
            this.letel_Label.Dock = System.Windows.Forms.DockStyle.Right;
            this.letel_Label.Location = new System.Drawing.Point(147, 0);
            this.letel_Label.Name = "letel_Label";
            this.letel_Label.Size = new System.Drawing.Size(30, 27);
            this.letel_Label.TabIndex = 14;
            this.letel_Label.Text = "الاقل";
            // 
            // Safi_Label
            // 
            this.Safi_Label.AutoSize = true;
            this.Safi_Label.Dock = System.Windows.Forms.DockStyle.Right;
            this.Safi_Label.Location = new System.Drawing.Point(68, 0);
            this.Safi_Label.Name = "Safi_Label";
            this.Safi_Label.Size = new System.Drawing.Size(41, 27);
            this.Safi_Label.TabIndex = 17;
            this.Safi_Label.Text = "الصافي";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(278, 3);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(33, 17);
            this.checkBox1.TabIndex = 19;
            this.checkBox1.Text = "الكل";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // Safi_Text
            // 
            this.Safi_Text.AllowEmptyState = false;
            // 
            // 
            // 
            this.Safi_Text.BackgroundStyle.Class = "DateTimeInputBackground";
            this.Safi_Text.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Safi_Text.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.Safi_Text.DisplayFormat = "0.00";
            this.Safi_Text.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Safi_Text.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Safi_Text.Increment = 0D;
            this.Safi_Text.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.Safi_Text.IsInputReadOnly = true;
            this.Safi_Text.Location = new System.Drawing.Point(3, 3);
            this.Safi_Text.MinValue = 0D;
            this.Safi_Text.Name = "Safi_Text";
            this.Safi_Text.Size = new System.Drawing.Size(59, 21);
            this.Safi_Text.TabIndex = 1142;
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.buttonX1.Location = new System.Drawing.Point(319, 3);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(72, 26);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX1.Symbol = "";
            this.buttonX1.SymbolSize = 10F;
            this.buttonX1.TabIndex = 1;
            this.buttonX1.Text = "السابق";
            this.buttonX1.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonX2
            // 
            this.buttonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX2.Font = new System.Drawing.Font("Tahoma", 7F);
            this.buttonX2.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.buttonX2.Location = new System.Drawing.Point(240, 19);
            this.buttonX2.Name = "buttonX2";
            this.buttonX2.Size = new System.Drawing.Size(69, 26);
            this.buttonX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX2.Symbol = "";
            this.buttonX2.SymbolSize = 10F;
            this.buttonX2.TabIndex = 1143;
            this.buttonX2.Text = "التالي";
            this.buttonX2.Click += new System.EventHandler(this.buttonX2_Click);
            // 
            // buttonX3
            // 
            this.buttonX3.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX3.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX3.Font = new System.Drawing.Font("Tahoma", 1F);
            this.buttonX3.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.buttonX3.Location = new System.Drawing.Point(252, 19);
            this.buttonX3.Name = "buttonX3";
            this.buttonX3.Size = new System.Drawing.Size(46, 26);
            this.buttonX3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX3.Symbol = "";
            this.buttonX3.SymbolSize = 12F;
            this.buttonX3.TabIndex = 1143;
            this.buttonX3.Click += new System.EventHandler(this.buttonX3_Click);
            // 
            // btnPrevPage
            // 
            this.btnPrevPage.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnPrevPage.Checked = true;
            this.btnPrevPage.FontBold = true;
            this.btnPrevPage.FontItalic = true;
            this.btnPrevPage.ForeColor = System.Drawing.Color.SteelBlue;
            this.btnPrevPage.Image = ((System.Drawing.Image)(resources.GetObject("btnPrevPage.Image")));
            this.btnPrevPage.ImageFixedSize = new System.Drawing.Size(28, 28);
            this.btnPrevPage.ImagePaddingHorizontal = 10;
            this.btnPrevPage.ImagePaddingVertical = 11;
            this.btnPrevPage.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnPrevPage.Name = "btnPrevPage";
            this.btnPrevPage.Stretch = true;
            this.btnPrevPage.SubItemsExpandWidth = 14;
            this.btnPrevPage.Symbol = "";
            this.btnPrevPage.SymbolSize = 15F;
            this.btnPrevPage.Text = "السابق";
            this.btnPrevPage.Tooltip = "السجل السابق";
            // 
            // btnNxtPage
            // 
            this.btnNxtPage.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnNxtPage.Checked = true;
            this.btnNxtPage.FontBold = true;
            this.btnNxtPage.FontItalic = true;
            this.btnNxtPage.ForeColor = System.Drawing.Color.SteelBlue;
            this.btnNxtPage.Image = ((System.Drawing.Image)(resources.GetObject("btnNxtPage.Image")));
            this.btnNxtPage.ImageFixedSize = new System.Drawing.Size(28, 28);
            this.btnNxtPage.ImagePaddingHorizontal = 10;
            this.btnNxtPage.ImagePaddingVertical = 11;
            this.btnNxtPage.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnNxtPage.Name = "btnNxtPage";
            this.btnNxtPage.Stretch = true;
            this.btnNxtPage.SubItemsExpandWidth = 14;
            this.btnNxtPage.Symbol = "";
            this.btnNxtPage.SymbolSize = 15F;
            this.btnNxtPage.Text = "التالي";
            this.btnNxtPage.Tooltip = " السجل التالي";
            // 
            // buttonItem_BestSeller
            // 
            this.buttonItem_BestSeller.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonItem_BestSeller.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.buttonItem_BestSeller.FontBold = true;
            this.buttonItem_BestSeller.FontItalic = true;
            this.buttonItem_BestSeller.ForeColor = System.Drawing.Color.SaddleBrown;
            this.buttonItem_BestSeller.Image = ((System.Drawing.Image)(resources.GetObject("buttonItem_BestSeller.Image")));
            this.buttonItem_BestSeller.ImageFixedSize = new System.Drawing.Size(28, 28);
            this.buttonItem_BestSeller.ImagePaddingHorizontal = 12;
            this.buttonItem_BestSeller.ImagePaddingVertical = 11;
            this.buttonItem_BestSeller.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.buttonItem_BestSeller.Name = "buttonItem_BestSeller";
            this.buttonItem_BestSeller.Stretch = true;
            this.buttonItem_BestSeller.SubItemsExpandWidth = 14;
            this.buttonItem_BestSeller.Symbol = "";
            this.buttonItem_BestSeller.SymbolSize = 15F;
            // 
            // buttonItem1
            // 
            this.buttonItem1.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonItem1.Checked = true;
            this.buttonItem1.FontBold = true;
            this.buttonItem1.FontItalic = true;
            this.buttonItem1.ForeColor = System.Drawing.Color.SteelBlue;
            this.buttonItem1.Image = ((System.Drawing.Image)(resources.GetObject("buttonItem1.Image")));
            this.buttonItem1.ImageFixedSize = new System.Drawing.Size(28, 28);
            this.buttonItem1.ImagePaddingHorizontal = 10;
            this.buttonItem1.ImagePaddingVertical = 11;
            this.buttonItem1.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.buttonItem1.Name = "buttonItem1";
            this.buttonItem1.Stretch = true;
            this.buttonItem1.SubItemsExpandWidth = 14;
            this.buttonItem1.Symbol = "";
            this.buttonItem1.SymbolSize = 15F;
            this.buttonItem1.Text = "السابق";
            this.buttonItem1.Tooltip = "السجل السابق";
            // 
            // buttonItem2
            // 
            this.buttonItem2.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonItem2.Checked = true;
            this.buttonItem2.FontBold = true;
            this.buttonItem2.FontItalic = true;
            this.buttonItem2.ForeColor = System.Drawing.Color.SteelBlue;
            this.buttonItem2.Image = ((System.Drawing.Image)(resources.GetObject("buttonItem2.Image")));
            this.buttonItem2.ImageFixedSize = new System.Drawing.Size(28, 28);
            this.buttonItem2.ImagePaddingHorizontal = 10;
            this.buttonItem2.ImagePaddingVertical = 11;
            this.buttonItem2.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.buttonItem2.Name = "buttonItem2";
            this.buttonItem2.Stretch = true;
            this.buttonItem2.SubItemsExpandWidth = 14;
            this.buttonItem2.Symbol = "";
            this.buttonItem2.SymbolSize = 15F;
            this.buttonItem2.Text = "التالي";
            this.buttonItem2.Tooltip = " السجل التالي";
            // 
            // buttonItem3
            // 
            this.buttonItem3.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonItem3.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.buttonItem3.FontBold = true;
            this.buttonItem3.FontItalic = true;
            this.buttonItem3.ForeColor = System.Drawing.Color.SaddleBrown;
            this.buttonItem3.Image = ((System.Drawing.Image)(resources.GetObject("buttonItem3.Image")));
            this.buttonItem3.ImageFixedSize = new System.Drawing.Size(28, 28);
            this.buttonItem3.ImagePaddingHorizontal = 12;
            this.buttonItem3.ImagePaddingVertical = 11;
            this.buttonItem3.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.buttonItem3.Name = "buttonItem3";
            this.buttonItem3.Stretch = true;
            this.buttonItem3.SubItemsExpandWidth = 14;
            this.buttonItem3.Symbol = "";
            this.buttonItem3.SymbolSize = 15F;
            // 
            // buttonItem4
            // 
            this.buttonItem4.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonItem4.Checked = true;
            this.buttonItem4.FontBold = true;
            this.buttonItem4.FontItalic = true;
            this.buttonItem4.ForeColor = System.Drawing.Color.SteelBlue;
            this.buttonItem4.Image = ((System.Drawing.Image)(resources.GetObject("buttonItem4.Image")));
            this.buttonItem4.ImageFixedSize = new System.Drawing.Size(28, 28);
            this.buttonItem4.ImagePaddingHorizontal = 10;
            this.buttonItem4.ImagePaddingVertical = 11;
            this.buttonItem4.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.buttonItem4.Name = "buttonItem4";
            this.buttonItem4.Stretch = true;
            this.buttonItem4.SubItemsExpandWidth = 14;
            this.buttonItem4.Symbol = "";
            this.buttonItem4.SymbolSize = 15F;
            this.buttonItem4.Text = "السابق";
            this.buttonItem4.Tooltip = "السجل السابق";
            // 
            // buttonItem5
            // 
            this.buttonItem5.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonItem5.Checked = true;
            this.buttonItem5.FontBold = true;
            this.buttonItem5.FontItalic = true;
            this.buttonItem5.ForeColor = System.Drawing.Color.SteelBlue;
            this.buttonItem5.Image = ((System.Drawing.Image)(resources.GetObject("buttonItem5.Image")));
            this.buttonItem5.ImageFixedSize = new System.Drawing.Size(28, 28);
            this.buttonItem5.ImagePaddingHorizontal = 10;
            this.buttonItem5.ImagePaddingVertical = 11;
            this.buttonItem5.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.buttonItem5.Name = "buttonItem5";
            this.buttonItem5.Stretch = true;
            this.buttonItem5.SubItemsExpandWidth = 14;
            this.buttonItem5.Symbol = "";
            this.buttonItem5.SymbolSize = 15F;
            this.buttonItem5.Text = "التالي";
            this.buttonItem5.Tooltip = " السجل التالي";
            // 
            // buttonItem6
            // 
            this.buttonItem6.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonItem6.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.buttonItem6.FontBold = true;
            this.buttonItem6.FontItalic = true;
            this.buttonItem6.ForeColor = System.Drawing.Color.SaddleBrown;
            this.buttonItem6.Image = ((System.Drawing.Image)(resources.GetObject("buttonItem6.Image")));
            this.buttonItem6.ImageFixedSize = new System.Drawing.Size(28, 28);
            this.buttonItem6.ImagePaddingHorizontal = 12;
            this.buttonItem6.ImagePaddingVertical = 11;
            this.buttonItem6.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.buttonItem6.Name = "buttonItem6";
            this.buttonItem6.Stretch = true;
            this.buttonItem6.SubItemsExpandWidth = 14;
            this.buttonItem6.Symbol = "";
            this.buttonItem6.SymbolSize = 15F;
            // 
            // buttonItem7
            // 
            this.buttonItem7.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonItem7.Checked = true;
            this.buttonItem7.FontBold = true;
            this.buttonItem7.FontItalic = true;
            this.buttonItem7.ForeColor = System.Drawing.Color.SteelBlue;
            this.buttonItem7.Image = ((System.Drawing.Image)(resources.GetObject("buttonItem7.Image")));
            this.buttonItem7.ImageFixedSize = new System.Drawing.Size(28, 28);
            this.buttonItem7.ImagePaddingHorizontal = 10;
            this.buttonItem7.ImagePaddingVertical = 11;
            this.buttonItem7.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.buttonItem7.Name = "buttonItem7";
            this.buttonItem7.Stretch = true;
            this.buttonItem7.SubItemsExpandWidth = 14;
            this.buttonItem7.Symbol = "";
            this.buttonItem7.SymbolSize = 15F;
            this.buttonItem7.Text = "السابق";
            this.buttonItem7.Tooltip = "السجل السابق";
            // 
            // buttonItem8
            // 
            this.buttonItem8.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonItem8.Checked = true;
            this.buttonItem8.FontBold = true;
            this.buttonItem8.FontItalic = true;
            this.buttonItem8.ForeColor = System.Drawing.Color.SteelBlue;
            this.buttonItem8.Image = ((System.Drawing.Image)(resources.GetObject("buttonItem8.Image")));
            this.buttonItem8.ImageFixedSize = new System.Drawing.Size(28, 28);
            this.buttonItem8.ImagePaddingHorizontal = 10;
            this.buttonItem8.ImagePaddingVertical = 11;
            this.buttonItem8.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.buttonItem8.Name = "buttonItem8";
            this.buttonItem8.Stretch = true;
            this.buttonItem8.SubItemsExpandWidth = 14;
            this.buttonItem8.Symbol = "";
            this.buttonItem8.SymbolSize = 15F;
            this.buttonItem8.Text = "التالي";
            this.buttonItem8.Tooltip = " السجل التالي";
            // 
            // buttonItem9
            // 
            this.buttonItem9.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonItem9.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.buttonItem9.FontBold = true;
            this.buttonItem9.FontItalic = true;
            this.buttonItem9.ForeColor = System.Drawing.Color.SaddleBrown;
            this.buttonItem9.Image = ((System.Drawing.Image)(resources.GetObject("buttonItem9.Image")));
            this.buttonItem9.ImageFixedSize = new System.Drawing.Size(28, 28);
            this.buttonItem9.ImagePaddingHorizontal = 12;
            this.buttonItem9.ImagePaddingVertical = 11;
            this.buttonItem9.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.buttonItem9.Name = "buttonItem9";
            this.buttonItem9.Stretch = true;
            this.buttonItem9.SubItemsExpandWidth = 14;
            this.buttonItem9.Symbol = "";
            this.buttonItem9.SymbolSize = 15F;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Location = new System.Drawing.Point(3, 3);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.panel1);
            this.splitContainer2.Size = new System.Drawing.Size(520, 342);
            this.splitContainer2.SplitterDistance = 409;
            this.splitContainer2.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.propertyGrid1);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(107, 342);
            this.panel1.TabIndex = 2;
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid1.Location = new System.Drawing.Point(0, 21);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(107, 321);
            this.propertyGrid1.TabIndex = 0;
            this.propertyGrid1.Click += new System.EventHandler(this.propertyGrid1_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "PITEMS",
            "items",
            "panel"});
            this.comboBox1.Location = new System.Drawing.Point(0, 0);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(107, 21);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.SelectedValueChanged += new System.EventHandler(this.comboBox1_SelectedValueChanged);
            // 
            // controlContainerItem1
            // 
            this.controlContainerItem1.AllowItemResize = true;
            this.controlContainerItem1.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways;
            this.controlContainerItem1.Name = "controlContainerItem1";
            this.controlContainerItem1.Text = "controlContainerItem1";
            // 
            // labelItem1
            // 
            this.labelItem1.Name = "labelItem1";
            this.labelItem1.Text = "labelItem1";
            // 
            // catPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.splitContainer2);
            this.Name = "catPanel";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Size = new System.Drawing.Size(704, 348);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.PItems.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Letel_Text)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tot_Text)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Safi_Text)).EndInit();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.FlowLayoutPanel PItems;
        private System.Windows.Forms.Label Safi_Label;
        private System.Windows.Forms.Label letel_Label;
        private System.Windows.Forms.Label Tot_Label;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel Pitem2;
        private System.Windows.Forms.CheckBox checkBox1;
        private DevComponents.Editors.DoubleInput Letel_Text;
        private DevComponents.Editors.DoubleInput Tot_Text;
        private DevComponents.Editors.DoubleInput Safi_Text;
        private DevComponents.DotNetBar.SuperGrid.SuperGridControl superGridControl1;
     //   private DevComponents.DotNetBar.Layout.LayoutControl layoutControl1;
        protected DevComponents.DotNetBar.ButtonItem btnPrevPage;
        protected DevComponents.DotNetBar.ButtonItem btnNxtPage;
        protected DevComponents.DotNetBar.ButtonItem buttonItem_BestSeller;
        protected DevComponents.DotNetBar.ButtonItem buttonItem1;
        protected DevComponents.DotNetBar.ButtonItem buttonItem2;
        protected DevComponents.DotNetBar.ButtonItem buttonItem3;
        protected DevComponents.DotNetBar.ButtonItem buttonItem4;
        protected DevComponents.DotNetBar.ButtonItem buttonItem5;
        protected DevComponents.DotNetBar.ButtonItem buttonItem6;
        protected DevComponents.DotNetBar.ButtonItem buttonItem7;
        protected DevComponents.DotNetBar.ButtonItem buttonItem8;
        protected DevComponents.DotNetBar.ButtonItem buttonItem9;
        private DevComponents.DotNetBar.ButtonX buttonX3;
        private DevComponents.DotNetBar.ButtonX buttonX2;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.ComboBox comboBox1;
        private DevComponents.DotNetBar.ItemPanel itemPanel1;
        private DevComponents.DotNetBar.ItemContainer SpecialContainer;
        private DevComponents.DotNetBar.ItemContainer ITemCOntrolCOntainer;
        private DevComponents.DotNetBar.ControlContainerItem controlContainerItem1;
        private DevComponents.DotNetBar.LabelItem labelItem1;
        private System.Windows.Forms.Panel panel1;
    }
}
