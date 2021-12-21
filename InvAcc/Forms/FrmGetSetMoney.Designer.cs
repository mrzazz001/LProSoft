   

namespace InvAcc.Forms
{
partial class FrmGetSetMoney
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
            DevComponents.DotNetBar.SuperGrid.Style.Background background1 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.Style.Background background2 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.Style.Background background3 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.Style.BorderColor borderColor1 = new DevComponents.DotNetBar.SuperGrid.Style.BorderColor();
            DevComponents.DotNetBar.SuperGrid.Style.BorderColor borderColor2 = new DevComponents.DotNetBar.SuperGrid.Style.BorderColor();
            DevComponents.DotNetBar.SuperGrid.Style.BaseTreeButtonVisualStyle baseTreeButtonVisualStyle1 = new DevComponents.DotNetBar.SuperGrid.Style.BaseTreeButtonVisualStyle();
            DevComponents.DotNetBar.SuperGrid.Style.BaseTreeButtonVisualStyle baseTreeButtonVisualStyle2 = new DevComponents.DotNetBar.SuperGrid.Style.BaseTreeButtonVisualStyle();
            DevComponents.DotNetBar.SuperGrid.Style.Background background4 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmGetSetMoney));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.DGV_Main = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.CmbCurr = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label2 = new System.Windows.Forms.Label();
            this.switchButton_AccType = new DevComponents.DotNetBar.Controls.SwitchButton();
            this.txtBXBankName = new System.Windows.Forms.TextBox();
            this.button_SrchBXBankNo = new DevComponents.DotNetBar.ButtonX();
            this.txtBXBankNo = new System.Windows.Forms.TextBox();
            this.txtBrancheName = new System.Windows.Forms.TextBox();
            this.switchButton_PageTyp = new DevComponents.DotNetBar.Controls.SwitchButton();
            this.label1 = new System.Windows.Forms.Label();
            this.button_SrchBrancheNo = new DevComponents.DotNetBar.ButtonX();
            this.txtBrancheNo = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.checkBox_Yes = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.checkBox_No = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.button_OK = new DevComponents.DotNetBar.ButtonX();
            this.button_Return = new DevComponents.DotNetBar.ButtonX();
            this.vcr1 = new SuperGridDemo.VcrControl();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.timerInfoBallon = new System.Windows.Forms.Timer(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.superTabStrip1 = new DevComponents.DotNetBar.SuperTabStrip();
            this.superTabItem = new DevComponents.DotNetBar.SuperTabItem();
            this.buttonItem_Close = new DevComponents.DotNetBar.ButtonItem();
            this.button_AddPage = new DevComponents.DotNetBar.ButtonItem();
            this.netResize1 = new Softgroup.NetResize.NetResize(this.components);
            this.panel1.SuspendLayout();
            this.groupPanel2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.superTabStrip1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "*.rtf";
            this.openFileDialog1.Filter = "Text Files (*.txt)|*.txt|RTF Files (*.rtf)|*.rtf|All Files(*.*)|*.*";
            this.openFileDialog1.FilterIndex = 2;
            this.openFileDialog1.Title = "Open File";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "*.rtf";
            this.saveFileDialog1.FileName = "doc1";
            this.saveFileDialog1.Filter = "Text Files (*.txt)|*.txt|RTF Files (*.rtf)|*.rtf|All Files(*.*)|*.*";
            this.saveFileDialog1.FilterIndex = 2;
            this.saveFileDialog1.Title = "Save File";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.DGV_Main);
            this.panel1.Controls.Add(this.groupPanel2);
            this.panel1.Controls.Add(this.vcr1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(626, 376);
            this.panel1.TabIndex = 877;
            // 
            // DGV_Main
            // 
            this.DGV_Main.BackColor = System.Drawing.Color.Transparent;
            background1.BackFillType = DevComponents.DotNetBar.SuperGrid.Style.BackFillType.ForwardDiagonalCenter;
            background1.Color1 = System.Drawing.SystemColors.GradientActiveCaption;
            background1.Color2 = System.Drawing.Color.White;
            this.DGV_Main.DefaultVisualStyles.GroupByStyles.Default.Background = background1;
            background2.BackFillType = DevComponents.DotNetBar.SuperGrid.Style.BackFillType.Center;
            background2.Color1 = System.Drawing.Color.LightSteelBlue;
            this.DGV_Main.DefaultVisualStyles.RowStyles.Default.Background = background2;
            background3.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.DGV_Main.DefaultVisualStyles.RowStyles.MouseOver.Background = background3;
            this.DGV_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGV_Main.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            this.DGV_Main.Font = new System.Drawing.Font("Tahoma", 9F);
            this.DGV_Main.ForeColor = System.Drawing.Color.Black;
            this.DGV_Main.Location = new System.Drawing.Point(0, 180);
            this.DGV_Main.Name = "DGV_Main";
            // 
            // 
            // 
            this.DGV_Main.PrimaryGrid.ActiveRowIndicatorStyle = DevComponents.DotNetBar.SuperGrid.ActiveRowIndicatorStyle.Both;
            this.DGV_Main.PrimaryGrid.AllowEdit = false;
            // 
            // 
            // 
            this.DGV_Main.PrimaryGrid.Caption.BackgroundImageLayout = DevComponents.DotNetBar.SuperGrid.GridBackgroundImageLayout.Center;
            this.DGV_Main.PrimaryGrid.Caption.Text = "";
            this.DGV_Main.PrimaryGrid.Caption.Visible = false;
            this.DGV_Main.PrimaryGrid.DefaultVisualStyles.AlternateColumnCellStyles.Default.AllowWrap = DevComponents.DotNetBar.SuperGrid.Style.Tbool.False;
            this.DGV_Main.PrimaryGrid.DefaultVisualStyles.AlternateColumnCellStyles.Default.TextColor = System.Drawing.Color.Black;
            this.DGV_Main.PrimaryGrid.DefaultVisualStyles.AlternateRowCellStyles.Default.AllowWrap = DevComponents.DotNetBar.SuperGrid.Style.Tbool.False;
            this.DGV_Main.PrimaryGrid.DefaultVisualStyles.AlternateRowCellStyles.Default.TextColor = System.Drawing.Color.Black;
            this.DGV_Main.PrimaryGrid.DefaultVisualStyles.CaptionStyles.Default.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DGV_Main.PrimaryGrid.DefaultVisualStyles.CaptionStyles.Default.TextColor = System.Drawing.Color.White;
            this.DGV_Main.PrimaryGrid.DefaultVisualStyles.CaptionStyles.ReadOnly.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            this.DGV_Main.PrimaryGrid.DefaultVisualStyles.CellStyles.Selected.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            this.DGV_Main.PrimaryGrid.DefaultVisualStyles.ColumnHeaderRowStyles.Default.RowHeader.AllowWrap = DevComponents.DotNetBar.SuperGrid.Style.Tbool.True;
            borderColor1.Bottom = System.Drawing.Color.Black;
            borderColor1.Left = System.Drawing.Color.Black;
            borderColor1.Right = System.Drawing.Color.Black;
            borderColor1.Top = System.Drawing.Color.Black;
            this.DGV_Main.PrimaryGrid.DefaultVisualStyles.ColumnHeaderStyles.Default.BorderColor = borderColor1;
            this.DGV_Main.PrimaryGrid.DefaultVisualStyles.ColumnHeaderStyles.Default.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DGV_Main.PrimaryGrid.DefaultVisualStyles.ColumnHeaderStyles.Default.TextColor = System.Drawing.Color.SteelBlue;
            this.DGV_Main.PrimaryGrid.DefaultVisualStyles.FilterColumnHeaderStyles.Default.TextColor = System.Drawing.Color.White;
            this.DGV_Main.PrimaryGrid.DefaultVisualStyles.FooterStyles.Default.TextColor = System.Drawing.Color.White;
            this.DGV_Main.PrimaryGrid.DefaultVisualStyles.GridPanelStyle.AllowWrap = DevComponents.DotNetBar.SuperGrid.Style.Tbool.False;
            borderColor2.Bottom = System.Drawing.Color.Black;
            borderColor2.Left = System.Drawing.Color.Black;
            borderColor2.Right = System.Drawing.Color.Black;
            borderColor2.Top = System.Drawing.Color.Black;
            this.DGV_Main.PrimaryGrid.DefaultVisualStyles.GridPanelStyle.BorderColor = borderColor2;
            baseTreeButtonVisualStyle1.BorderColor = System.Drawing.Color.White;
            baseTreeButtonVisualStyle1.LineColor = System.Drawing.Color.White;
            this.DGV_Main.PrimaryGrid.DefaultVisualStyles.GridPanelStyle.CircleTreeButtonStyle.ExpandButton = baseTreeButtonVisualStyle1;
            this.DGV_Main.PrimaryGrid.DefaultVisualStyles.GridPanelStyle.HeaderHLinePattern = DevComponents.DotNetBar.SuperGrid.Style.LinePattern.None;
            background4.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            baseTreeButtonVisualStyle2.Background = background4;
            this.DGV_Main.PrimaryGrid.DefaultVisualStyles.GridPanelStyle.SquareTreeButtonStyle.ExpandButton = baseTreeButtonVisualStyle2;
            this.DGV_Main.PrimaryGrid.DefaultVisualStyles.GridPanelStyle.TextColor = System.Drawing.Color.White;
            this.DGV_Main.PrimaryGrid.DefaultVisualStyles.TitleStyles.Default.RowHeaderStyle.TextAlignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            // 
            // 
            // 
            this.DGV_Main.PrimaryGrid.GroupByRow.RowHeaderVisibility = DevComponents.DotNetBar.SuperGrid.RowHeaderVisibility.Never;
            this.DGV_Main.PrimaryGrid.GroupByRow.Text = "أوراق القبــــــض";
            this.DGV_Main.PrimaryGrid.GroupByRow.WatermarkText = "";
            this.DGV_Main.PrimaryGrid.InitialActiveRow = DevComponents.DotNetBar.SuperGrid.RelativeRow.None;
            this.DGV_Main.PrimaryGrid.InitialSelection = DevComponents.DotNetBar.SuperGrid.RelativeSelection.None;
            this.DGV_Main.PrimaryGrid.MultiSelect = false;
            this.DGV_Main.PrimaryGrid.SelectionGranularity = DevComponents.DotNetBar.SuperGrid.SelectionGranularity.Row;
            this.DGV_Main.PrimaryGrid.ShowRowHeaders = false;
            // 
            // 
            // 
            this.DGV_Main.PrimaryGrid.Title.AllowSelection = false;
            this.DGV_Main.PrimaryGrid.Title.Text = "";
            this.DGV_Main.PrimaryGrid.Title.Visible = false;
            this.DGV_Main.PrimaryGrid.Visible = false;
            this.DGV_Main.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.DGV_Main.Size = new System.Drawing.Size(626, 166);
            this.DGV_Main.TabIndex = 1037;
            this.DGV_Main.Tag = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.DGV_Main.RowClick += new System.EventHandler<DevComponents.DotNetBar.SuperGrid.GridRowClickEventArgs>(this.DGV_Main_RowClick);
            // 
            // groupPanel2
            // 
            this.groupPanel2.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.CmbCurr);
            this.groupPanel2.Controls.Add(this.label2);
            this.groupPanel2.Controls.Add(this.switchButton_AccType);
            this.groupPanel2.Controls.Add(this.txtBXBankName);
            this.groupPanel2.Controls.Add(this.button_SrchBXBankNo);
            this.groupPanel2.Controls.Add(this.txtBXBankNo);
            this.groupPanel2.Controls.Add(this.txtBrancheName);
            this.groupPanel2.Controls.Add(this.switchButton_PageTyp);
            this.groupPanel2.Controls.Add(this.label1);
            this.groupPanel2.Controls.Add(this.button_SrchBrancheNo);
            this.groupPanel2.Controls.Add(this.txtBrancheNo);
            this.groupPanel2.Controls.Add(this.groupBox5);
            this.groupPanel2.Controls.Add(this.button_OK);
            this.groupPanel2.Controls.Add(this.button_Return);
            this.groupPanel2.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupPanel2.Location = new System.Drawing.Point(0, 0);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupPanel2.Size = new System.Drawing.Size(626, 180);
            // 
            // 
            // 
            this.groupPanel2.Style.BackColor2 = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupPanel2.Style.BackColorGradientAngle = 90;
            this.groupPanel2.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel2.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderBottomWidth = 1;
            this.groupPanel2.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel2.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderLeftWidth = 1;
            this.groupPanel2.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderRightWidth = 1;
            this.groupPanel2.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderTopWidth = 1;
            this.groupPanel2.Style.CornerDiameter = 4;
            this.groupPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel2.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel2.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            // 
            // 
            // 
            this.groupPanel2.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel2.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel2.TabIndex = 969;
            this.groupPanel2.Text = "عمليـــات السحب والإيـــداع";
            this.groupPanel2.TitleImagePosition = DevComponents.DotNetBar.eTitleImagePosition.Center;
            // 
            // CmbCurr
            // 
            this.CmbCurr.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbCurr.DisplayMember = "Text";
            this.CmbCurr.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.CmbCurr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbCurr.Font = new System.Drawing.Font("Tahoma", 9F);
            this.CmbCurr.FormattingEnabled = true;
            this.CmbCurr.ItemHeight = 17;
            this.CmbCurr.Location = new System.Drawing.Point(178, 6);
            this.CmbCurr.Name = "CmbCurr";
            this.CmbCurr.Size = new System.Drawing.Size(203, 23);
            this.CmbCurr.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.CmbCurr.TabIndex = 1045;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(310, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 1044;
            this.label2.Text = "حساب الدائن :";
            // 
            // switchButton_AccType
            // 
            // 
            // 
            // 
            this.switchButton_AccType.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.switchButton_AccType.IsReadOnly = true;
            this.switchButton_AccType.Location = new System.Drawing.Point(310, -54);
            this.switchButton_AccType.Name = "switchButton_AccType";
            this.switchButton_AccType.OffText = "الصندوق";
            this.switchButton_AccType.OnText = "البنك";
            this.switchButton_AccType.Size = new System.Drawing.Size(116, 22);
            this.switchButton_AccType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.switchButton_AccType.TabIndex = 1043;
            this.switchButton_AccType.Value = true;
            this.switchButton_AccType.ValueObject = "Y";
            // 
            // txtBXBankName
            // 
            this.txtBXBankName.BackColor = System.Drawing.Color.White;
            this.txtBXBankName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtBXBankName.Location = new System.Drawing.Point(5, 47);
            this.txtBXBankName.Name = "txtBXBankName";
            this.txtBXBankName.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtBXBankName, false);
            this.txtBXBankName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtBXBankName.Size = new System.Drawing.Size(171, 20);
            this.txtBXBankName.TabIndex = 1042;
            this.txtBXBankName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button_SrchBXBankNo
            // 
            this.button_SrchBXBankNo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchBXBankNo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchBXBankNo.Enabled = false;
            this.button_SrchBXBankNo.Location = new System.Drawing.Point(178, 47);
            this.button_SrchBXBankNo.Name = "button_SrchBXBankNo";
            this.button_SrchBXBankNo.Size = new System.Drawing.Size(26, 20);
            this.button_SrchBXBankNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchBXBankNo.Symbol = "";
            this.button_SrchBXBankNo.SymbolSize = 12F;
            this.button_SrchBXBankNo.TabIndex = 1041;
            this.button_SrchBXBankNo.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchBXBankNo.Click += new System.EventHandler(this.button_SrchBXBankNo_Click);
            // 
            // txtBXBankNo
            // 
            this.txtBXBankNo.BackColor = System.Drawing.Color.White;
            this.txtBXBankNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtBXBankNo.Location = new System.Drawing.Point(206, 47);
            this.txtBXBankNo.MaxLength = 30;
            this.txtBXBankNo.Name = "txtBXBankNo";
            this.txtBXBankNo.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtBXBankNo, false);
            this.txtBXBankNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtBXBankNo.Size = new System.Drawing.Size(98, 20);
            this.txtBXBankNo.TabIndex = 1040;
            this.txtBXBankNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtBrancheName
            // 
            this.txtBrancheName.BackColor = System.Drawing.Color.White;
            this.txtBrancheName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtBrancheName.Location = new System.Drawing.Point(7, 75);
            this.txtBrancheName.Name = "txtBrancheName";
            this.txtBrancheName.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtBrancheName, false);
            this.txtBrancheName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtBrancheName.Size = new System.Drawing.Size(171, 20);
            this.txtBrancheName.TabIndex = 1038;
            this.txtBrancheName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // switchButton_PageTyp
            // 
            // 
            // 
            // 
            this.switchButton_PageTyp.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.switchButton_PageTyp.Location = new System.Drawing.Point(9, 6);
            this.switchButton_PageTyp.Name = "switchButton_PageTyp";
            this.switchButton_PageTyp.OffText = "إيـــــداع";
            this.switchButton_PageTyp.OnText = "سحـــــب";
            this.switchButton_PageTyp.Size = new System.Drawing.Size(167, 22);
            this.switchButton_PageTyp.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.switchButton_PageTyp.TabIndex = 1034;
            this.switchButton_PageTyp.ValueChanged += new System.EventHandler(this.switchButton_PageTyp_ValueChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(310, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 1032;
            this.label1.Text = "حساب المدين :";
            // 
            // button_SrchBrancheNo
            // 
            this.button_SrchBrancheNo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchBrancheNo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchBrancheNo.Enabled = false;
            this.button_SrchBrancheNo.Location = new System.Drawing.Point(180, 75);
            this.button_SrchBrancheNo.Name = "button_SrchBrancheNo";
            this.button_SrchBrancheNo.Size = new System.Drawing.Size(26, 20);
            this.button_SrchBrancheNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchBrancheNo.Symbol = "";
            this.button_SrchBrancheNo.SymbolSize = 12F;
            this.button_SrchBrancheNo.TabIndex = 1031;
            this.button_SrchBrancheNo.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchBrancheNo.Click += new System.EventHandler(this.button_SrchBrancheNo_Click);
            // 
            // txtBrancheNo
            // 
            this.txtBrancheNo.BackColor = System.Drawing.Color.White;
            this.txtBrancheNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtBrancheNo.Location = new System.Drawing.Point(208, 75);
            this.txtBrancheNo.MaxLength = 30;
            this.txtBrancheNo.Name = "txtBrancheNo";
            this.txtBrancheNo.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtBrancheNo, false);
            this.txtBrancheNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtBrancheNo.Size = new System.Drawing.Size(98, 20);
            this.txtBrancheNo.TabIndex = 1030;
            this.txtBrancheNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.BackColor = System.Drawing.Color.Transparent;
            this.groupBox5.Controls.Add(this.checkBox_Yes);
            this.groupBox5.Controls.Add(this.checkBox_No);
            this.groupBox5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.groupBox5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupBox5.Location = new System.Drawing.Point(7, 98);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox5.Size = new System.Drawing.Size(421, 56);
            this.groupBox5.TabIndex = 1023;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "الإيصالات";
            // 
            // checkBox_Yes
            // 
            this.checkBox_Yes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox_Yes.AutoSize = true;
            this.checkBox_Yes.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.checkBox_Yes.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBox_Yes.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.checkBox_Yes.CheckSignSize = new System.Drawing.Size(14, 14);
            this.checkBox_Yes.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.checkBox_Yes.Location = new System.Drawing.Point(85, 29);
            this.checkBox_Yes.Name = "checkBox_Yes";
            this.checkBox_Yes.Size = new System.Drawing.Size(79, 16);
            this.checkBox_Yes.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBox_Yes.TabIndex = 16;
            this.checkBox_Yes.Tag = "1";
            this.checkBox_Yes.Text = "المرّحـــــلة";
            this.checkBox_Yes.CheckedChanged += new System.EventHandler(this.checkBox_Yes_CheckedChanged);
            // 
            // checkBox_No
            // 
            this.checkBox_No.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox_No.AutoSize = true;
            this.checkBox_No.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.checkBox_No.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBox_No.BackgroundStyle.TextShadowColor = System.Drawing.SystemColors.ControlLight;
            this.checkBox_No.BackgroundStyle.TextShadowOffset = new System.Drawing.Point(3, 3);
            this.checkBox_No.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.checkBox_No.Checked = true;
            this.checkBox_No.CheckSignSize = new System.Drawing.Size(14, 14);
            this.checkBox_No.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_No.CheckValue = "Y";
            this.checkBox_No.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.checkBox_No.Location = new System.Drawing.Point(254, 29);
            this.checkBox_No.Name = "checkBox_No";
            this.checkBox_No.Size = new System.Drawing.Size(95, 16);
            this.checkBox_No.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBox_No.TabIndex = 15;
            this.checkBox_No.Tag = "0";
            this.checkBox_No.Text = "الغير مرّحــــلة";
            this.checkBox_No.CheckedChanged += new System.EventHandler(this.checkBox_No_CheckedChanged);
            // 
            // button_OK
            // 
            this.button_OK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_OK.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.button_OK.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.button_OK.Location = new System.Drawing.Point(448, 28);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(150, 110);
            this.button_OK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_OK.Symbol = "";
            this.button_OK.SymbolSize = 12F;
            this.button_OK.TabIndex = 1025;
            this.button_OK.Text = "ترحيــــل";
            this.button_OK.TextColor = System.Drawing.Color.White;
            this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
            // 
            // button_Return
            // 
            this.button_Return.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_Return.Checked = true;
            this.button_Return.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_Return.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.button_Return.Location = new System.Drawing.Point(448, 28);
            this.button_Return.Name = "button_Return";
            this.button_Return.Size = new System.Drawing.Size(150, 110);
            this.button_Return.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_Return.Symbol = "";
            this.button_Return.SymbolSize = 12F;
            this.button_Return.TabIndex = 1024;
            this.button_Return.Text = "التراجع عن الترحيل";
            this.button_Return.TextColor = System.Drawing.Color.Black;
            this.button_Return.Click += new System.EventHandler(this.button_Return_Click);
            // 
            // vcr1
            // 
            this.vcr1.BackColor = System.Drawing.Color.Transparent;
            this.vcr1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.vcr1.Location = new System.Drawing.Point(0, 346);
            this.vcr1.Margin = new System.Windows.Forms.Padding(36623249, 452271, 36623249, 452271);
            this.vcr1.Name = "vcr1";
            this.vcr1.Size = new System.Drawing.Size(626, 30);
            this.vcr1.TabIndex = 1257;
            this.vcr1.FirstClick += new System.EventHandler<System.EventArgs>(this.VcrFirstClick);
            this.vcr1.PreviousClick += new System.EventHandler<System.EventArgs>(this.VcrPreviousClick);
            this.vcr1.NextClick += new System.EventHandler<System.EventArgs>(this.VcrNextClick);
            this.vcr1.LastClick += new System.EventHandler<System.EventArgs>(this.VcrLastClick);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Magenta;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            this.imageList1.Images.SetKeyName(2, "");
            this.imageList1.Images.SetKeyName(3, "");
            this.imageList1.Images.SetKeyName(4, "");
            this.imageList1.Images.SetKeyName(5, "");
            this.imageList1.Images.SetKeyName(6, "");
            this.imageList1.Images.SetKeyName(7, "");
            this.imageList1.Images.SetKeyName(8, "");
            this.imageList1.Images.SetKeyName(9, "");
            this.imageList1.Images.SetKeyName(10, "");
            this.imageList1.Images.SetKeyName(11, "");
            this.imageList1.Images.SetKeyName(12, "");
            this.imageList1.Images.SetKeyName(13, "");
            this.imageList1.Images.SetKeyName(14, "");
            this.imageList1.Images.SetKeyName(15, "");
            this.imageList1.Images.SetKeyName(16, "");
            this.imageList1.Images.SetKeyName(17, "");
            this.imageList1.Images.SetKeyName(18, "");
            this.imageList1.Images.SetKeyName(19, "");
            this.imageList1.Images.SetKeyName(20, "");
            this.imageList1.Images.SetKeyName(21, "");
            this.imageList1.Images.SetKeyName(22, "");
            this.imageList1.Images.SetKeyName(23, "");
            // 
            // timerInfoBallon
            // 
            this.timerInfoBallon.Interval = 3000;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            // 
            // superTabStrip1
            // 
            this.superTabStrip1.AutoSelectAttachedControl = false;
            // 
            // 
            // 
            this.superTabStrip1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.superTabStrip1.ContainerControlProcessDialogKey = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.superTabStrip1.ControlBox.CloseBox.Name = "";
            this.superTabStrip1.ControlBox.CloseBox.Tag = "";
            // 
            // 
            // 
            this.superTabStrip1.ControlBox.MenuBox.Name = "";
            this.superTabStrip1.ControlBox.MenuBox.Tag = "";
            this.superTabStrip1.ControlBox.Name = "";
            this.superTabStrip1.ControlBox.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.superTabStrip1.ControlBox.MenuBox,
            this.superTabStrip1.ControlBox.CloseBox});
            this.superTabStrip1.ControlBox.Tag = "";
            this.superTabStrip1.ControlBox.Visible = false;
            this.superTabStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.superTabStrip1.Location = new System.Drawing.Point(0, 376);
            this.superTabStrip1.Name = "superTabStrip1";
            this.superTabStrip1.ReorderTabsEnabled = true;
            this.superTabStrip1.SelectedTabFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.superTabStrip1.SelectedTabIndex = 0;
            this.superTabStrip1.Size = new System.Drawing.Size(626, 28);
            this.superTabStrip1.TabCloseButtonHot = null;
            this.superTabStrip1.TabFont = new System.Drawing.Font("Tahoma", 8F);
            this.superTabStrip1.TabIndex = 879;
            this.superTabStrip1.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.superTabItem,
            this.buttonItem_Close,
            this.button_AddPage});
            this.superTabStrip1.Text = "superTabStrip1";
            // 
            // superTabItem
            // 
            this.superTabItem.GlobalItem = false;
            this.superTabItem.ImageAlignment = DevComponents.DotNetBar.ImageAlignment.MiddleCenter;
            this.superTabItem.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Center;
            this.superTabItem.Name = "superTabItem";
            this.superTabItem.Stretch = true;
            this.superTabItem.TabFont = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.superTabItem.Text = "....";
            this.superTabItem.TextAlignment = DevComponents.DotNetBar.eItemAlignment.Center;
            // 
            // buttonItem_Close
            // 
            this.buttonItem_Close.Checked = true;
            this.buttonItem_Close.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.buttonItem_Close.Name = "buttonItem_Close";
            this.buttonItem_Close.Stretch = true;
            this.buttonItem_Close.Symbol = "";
            this.buttonItem_Close.SymbolSize = 12F;
            this.buttonItem_Close.Text = "خــــروج";
            this.buttonItem_Close.Click += new System.EventHandler(this.Button_Close_Click);
            // 
            // button_AddPage
            // 
            this.button_AddPage.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.button_AddPage.ColorTable = DevComponents.DotNetBar.eButtonColor.Blue;
            this.button_AddPage.Name = "button_AddPage";
            this.button_AddPage.Stretch = true;
            this.button_AddPage.Symbol = "";
            this.button_AddPage.SymbolSize = 12F;
            this.button_AddPage.Text = "تسجيل العمليــات البنكية وتعديلها  F1";
            this.button_AddPage.Click += new System.EventHandler(this.button_AddPage_Click);
            // 
            // netResize1
            // 
            this.netResize1.LabelsAutoEllipse = false;
            this.netResize1.ParentControl = this;
            this.netResize1.AfterControlResize += new Softgroup.NetResize.NetResize.AfterControlResizeEventHandler(this.netResize1_AfterControlResize);
            // 
            // FrmGetSetMoney
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(626, 404);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.superTabStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "FrmGetSetMoney";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "العمليات البنكية";
            this.Load += new System.EventHandler(this.FrmGetSetMoney_Load);
            this.Shown += new System.EventHandler(this.FrmInvSale_Shown);
            this.SizeChanged += new System.EventHandler(this.FrmInvSale_SizeChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Frm_KeyPress);
            this.panel1.ResumeLayout(false);
            this.groupPanel2.ResumeLayout(false);
            this.groupPanel2.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.superTabStrip1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).EndInit();
            this.ResumeLayout(false);

        }//###########&&&&&&&&&&

}
}
