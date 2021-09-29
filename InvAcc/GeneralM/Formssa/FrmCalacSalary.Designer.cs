   

namespace InvAcc.Forms
{
partial class FrmCalacSalary
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
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn4 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.Style.Background background1 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.Style.Background background2 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCalacSalary));
            this.PanelSpecialContainer = new System.Windows.Forms.Panel();
            this.ribbonBar1 = new DevComponents.DotNetBar.RibbonBar();
            this.superTabControl1 = new DevComponents.DotNetBar.SuperTabControl();
            this.superTabControlPanel5 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.switchButton_DisBalance = new DevComponents.DotNetBar.Controls.SwitchButton();
            this.checkBox_AccID = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.panel_Acc = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.CmbCurr = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.txtBXCostCenterNo = new System.Windows.Forms.TextBox();
            this.txtBXCostCenterName = new System.Windows.Forms.TextBox();
            this.button_SrchCostCenter = new DevComponents.DotNetBar.ButtonX();
            this.txtBXBankName = new System.Windows.Forms.TextBox();
            this.button_SrchBXBankNo = new DevComponents.DotNetBar.ButtonX();
            this.txtBXBankNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_Date = new System.Windows.Forms.MaskedTextBox();
            this.DVG_ACC = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            this.txtSumDebit = new DevComponents.Editors.DoubleInput();
            this.label4 = new System.Windows.Forms.Label();
            this.superTabItem_General = new DevComponents.DotNetBar.SuperTabItem();
            this.Button_OK = new DevComponents.DotNetBar.ButtonItem();
            this.button_Close = new DevComponents.DotNetBar.ButtonItem();
            this.netResize1 = new Softgroup.NetResize.NetResize(this.components);
            this.netResize1.AfterControlResize += new Softgroup.NetResize.NetResize.AfterControlResizeEventHandler(this.netResize1_AfterControlResize);
            this.ribbonBar1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl1)).BeginInit();
            this.superTabControl1.SuspendLayout();
            this.superTabControlPanel5.SuspendLayout();
            this.panel_Acc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSumDebit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelSpecialContainer
            // 
            this.PanelSpecialContainer.Location = new System.Drawing.Point(0, 0);
            this.PanelSpecialContainer.Name = "PanelSpecialContainer";
            this.PanelSpecialContainer.Size = new System.Drawing.Size(200, 100);
            this.PanelSpecialContainer.TabIndex = 0;
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
            this.ribbonBar1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar1.ContainerControlProcessDialogKey = true;
            this.ribbonBar1.Controls.Add(this.superTabControl1);
            this.ribbonBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonBar1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.ribbonBar1.Location = new System.Drawing.Point(0, 0);
            this.ribbonBar1.Name = "ribbonBar1";
            this.ribbonBar1.Size = new System.Drawing.Size(500, 499);
            this.ribbonBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonBar1.TabIndex = 868;
            // 
            // 
            // 
            this.ribbonBar1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar1.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // superTabControl1
            // 
            this.superTabControl1.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.superTabControl1.ControlBox.Category = null;
            // 
            // 
            // 
            this.superTabControl1.ControlBox.CloseBox.Category = null;
            this.superTabControl1.ControlBox.CloseBox.Description = null;
            this.superTabControl1.ControlBox.CloseBox.Name = "";
            this.superTabControl1.ControlBox.CloseBox.Tag = null;
            this.superTabControl1.ControlBox.Description = null;
            // 
            // 
            // 
            this.superTabControl1.ControlBox.MenuBox.Category = null;
            this.superTabControl1.ControlBox.MenuBox.Description = null;
            this.superTabControl1.ControlBox.MenuBox.Name = "";
            this.superTabControl1.ControlBox.MenuBox.Tag = null;
            this.superTabControl1.ControlBox.Name = "";
            this.superTabControl1.ControlBox.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.superTabControl1.ControlBox.MenuBox,
            this.superTabControl1.ControlBox.CloseBox});
            this.superTabControl1.ControlBox.Tag = null;
            this.superTabControl1.ControlBox.Visible = false;
            this.superTabControl1.Controls.Add(this.superTabControlPanel5);
            this.superTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControl1.ForeColor = System.Drawing.Color.Black;
            this.superTabControl1.Location = new System.Drawing.Point(0, 0);
            this.superTabControl1.Name = "superTabControl1";
            this.superTabControl1.ReorderTabsEnabled = true;
            this.superTabControl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.superTabControl1.SelectedTabFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.superTabControl1.SelectedTabIndex = 0;
            this.superTabControl1.Size = new System.Drawing.Size(500, 484);
            this.superTabControl1.TabFont = new System.Drawing.Font("Tahoma", 8F);
            this.superTabControl1.TabHorizontalSpacing = 0;
            this.superTabControl1.TabIndex = 0;
            this.superTabControl1.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.superTabItem_General,
            this.Button_OK,
            this.button_Close});
            this.superTabControl1.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.WinMediaPlayer12;
            this.superTabControl1.TabVerticalSpacing = 8;
            this.superTabControl1.TextAlignment = DevComponents.DotNetBar.eItemAlignment.Center;
            // 
            // superTabControlPanel5
            // 
            this.superTabControlPanel5.AutoSize = true;
            this.superTabControlPanel5.Controls.Add(this.switchButton_DisBalance);
            this.superTabControlPanel5.Controls.Add(this.checkBox_AccID);
            this.superTabControlPanel5.Controls.Add(this.panel_Acc);
            this.superTabControlPanel5.Controls.Add(this.label1);
            this.superTabControlPanel5.Controls.Add(this.textBox_Date);
            this.superTabControlPanel5.Controls.Add(this.DVG_ACC);
            this.superTabControlPanel5.Controls.Add(this.txtSumDebit);
            this.superTabControlPanel5.Controls.Add(this.label4);
            this.superTabControlPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel5.Location = new System.Drawing.Point(0, 31);
            this.superTabControlPanel5.Name = "superTabControlPanel5";
            this.superTabControlPanel5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.superTabControlPanel5.Size = new System.Drawing.Size(500, 453);
            this.superTabControlPanel5.TabIndex = 0;
            this.superTabControlPanel5.TabItem = this.superTabItem_General;
            // 
            // switchButton_DisBalance
            // 
            // 
            // 
            // 
            this.switchButton_DisBalance.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.switchButton_DisBalance.Font = new System.Drawing.Font("Tahoma", 7F);
            this.switchButton_DisBalance.Location = new System.Drawing.Point(23, 162);
            this.switchButton_DisBalance.Name = "switchButton_DisBalance";
            this.switchButton_DisBalance.OffBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(80)))), ((int)(((byte)(77)))));
            this.switchButton_DisBalance.OffText = "خصم الرصيد المستحق عليه من الراتب";
            this.switchButton_DisBalance.OffTextColor = System.Drawing.Color.White;
            this.switchButton_DisBalance.OnText = "خصم الرصيد المستحق عليه من الراتب";
            this.switchButton_DisBalance.Size = new System.Drawing.Size(452, 21);
            this.switchButton_DisBalance.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.switchButton_DisBalance.TabIndex = 8561;
            this.switchButton_DisBalance.ValueChanged += new System.EventHandler(this.switchButton_DisBalance_ValueChanged);
            // 
            // checkBox_AccID
            // 
            this.checkBox_AccID.AutoSize = true;
            this.checkBox_AccID.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.checkBox_AccID.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBox_AccID.Font = new System.Drawing.Font("Tahoma", 8F);
            this.checkBox_AccID.Location = new System.Drawing.Point(300, 56);
            this.checkBox_AccID.Name = "checkBox_AccID";
            this.checkBox_AccID.Size = new System.Drawing.Size(167, 15);
            this.checkBox_AccID.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBox_AccID.TabIndex = 8558;
            this.checkBox_AccID.Text = "إصدار قيد إثبات مصروف الموظفين";
            this.checkBox_AccID.CheckedChanged += new System.EventHandler(this.checkBox_AccID_CheckedChanged);
            // 
            // panel_Acc
            // 
            this.panel_Acc.BackColor = System.Drawing.Color.Transparent;
            this.panel_Acc.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_Acc.Controls.Add(this.label8);
            this.panel_Acc.Controls.Add(this.CmbCurr);
            this.panel_Acc.Controls.Add(this.txtBXCostCenterNo);
            this.panel_Acc.Controls.Add(this.txtBXCostCenterName);
            this.panel_Acc.Controls.Add(this.button_SrchCostCenter);
            this.panel_Acc.Controls.Add(this.txtBXBankName);
            this.panel_Acc.Controls.Add(this.button_SrchBXBankNo);
            this.panel_Acc.Controls.Add(this.txtBXBankNo);
            this.panel_Acc.Controls.Add(this.label2);
            this.panel_Acc.Controls.Add(this.label6);
            this.panel_Acc.Enabled = false;
            this.panel_Acc.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.panel_Acc.Location = new System.Drawing.Point(23, 63);
            this.panel_Acc.Name = "panel_Acc";
            this.panel_Acc.Size = new System.Drawing.Size(452, 98);
            this.panel_Acc.TabIndex = 8557;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label8.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label8.ForeColor = System.Drawing.Color.Navy;
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(314, 64);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 13);
            this.label8.TabIndex = 1126;
            this.label8.Text = "العملــــــــة :";
            // 
            // CmbCurr
            // 
            this.CmbCurr.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbCurr.DisplayMember = "Text";
            this.CmbCurr.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.CmbCurr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbCurr.FormattingEnabled = true;
            this.CmbCurr.ItemHeight = 15;
            this.CmbCurr.Location = new System.Drawing.Point(74, 66);
            this.CmbCurr.Name = "CmbCurr";
            this.CmbCurr.Size = new System.Drawing.Size(234, 21);
            this.CmbCurr.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.CmbCurr.TabIndex = 1125;
            // 
            // txtBXCostCenterNo
            // 
            this.txtBXCostCenterNo.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtBXCostCenterNo.BackColor = System.Drawing.Color.White;
            this.txtBXCostCenterNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtBXCostCenterNo.Location = new System.Drawing.Point(58, 178);
            this.txtBXCostCenterNo.Name = "txtBXCostCenterNo";
            this.txtBXCostCenterNo.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtBXCostCenterNo, false);
            this.txtBXCostCenterNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtBXCostCenterNo.Size = new System.Drawing.Size(169, 21);
            this.txtBXCostCenterNo.TabIndex = 1064;
            this.txtBXCostCenterNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtBXCostCenterName
            // 
            this.txtBXCostCenterName.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtBXCostCenterName.BackColor = System.Drawing.Color.White;
            this.txtBXCostCenterName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtBXCostCenterName.Location = new System.Drawing.Point(74, 42);
            this.txtBXCostCenterName.Name = "txtBXCostCenterName";
            this.txtBXCostCenterName.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtBXCostCenterName, false);
            this.txtBXCostCenterName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtBXCostCenterName.Size = new System.Drawing.Size(234, 21);
            this.txtBXCostCenterName.TabIndex = 1063;
            this.txtBXCostCenterName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button_SrchCostCenter
            // 
            this.button_SrchCostCenter.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchCostCenter.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.button_SrchCostCenter.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchCostCenter.Location = new System.Drawing.Point(46, 42);
            this.button_SrchCostCenter.Name = "button_SrchCostCenter";
            this.button_SrchCostCenter.Size = new System.Drawing.Size(26, 21);
            this.button_SrchCostCenter.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchCostCenter.Symbol = "";
            this.button_SrchCostCenter.SymbolSize = 12F;
            this.button_SrchCostCenter.TabIndex = 1061;
            this.button_SrchCostCenter.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchCostCenter.Click += new System.EventHandler(this.button_SrchCostCenter_Click);
            // 
            // txtBXBankName
            // 
            this.txtBXBankName.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtBXBankName.BackColor = System.Drawing.Color.White;
            this.txtBXBankName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtBXBankName.Location = new System.Drawing.Point(74, 18);
            this.txtBXBankName.Name = "txtBXBankName";
            this.txtBXBankName.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtBXBankName, false);
            this.txtBXBankName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtBXBankName.Size = new System.Drawing.Size(234, 21);
            this.txtBXBankName.TabIndex = 1054;
            this.txtBXBankName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button_SrchBXBankNo
            // 
            this.button_SrchBXBankNo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchBXBankNo.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.button_SrchBXBankNo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchBXBankNo.Location = new System.Drawing.Point(46, 18);
            this.button_SrchBXBankNo.Name = "button_SrchBXBankNo";
            this.button_SrchBXBankNo.Size = new System.Drawing.Size(26, 21);
            this.button_SrchBXBankNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchBXBankNo.Symbol = "";
            this.button_SrchBXBankNo.SymbolSize = 12F;
            this.button_SrchBXBankNo.TabIndex = 1050;
            this.button_SrchBXBankNo.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchBXBankNo.Click += new System.EventHandler(this.button_SrchBXBankNo_Click);
            // 
            // txtBXBankNo
            // 
            this.txtBXBankNo.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtBXBankNo.BackColor = System.Drawing.Color.White;
            this.txtBXBankNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtBXBankNo.Location = new System.Drawing.Point(216, 165);
            this.txtBXBankNo.MaxLength = 30;
            this.txtBXBankNo.Name = "txtBXBankNo";
            this.txtBXBankNo.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtBXBankNo, false);
            this.txtBXBankNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtBXBankNo.Size = new System.Drawing.Size(108, 21);
            this.txtBXBankNo.TabIndex = 1049;
            this.txtBXBankNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(314, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 1065;
            this.label2.Text = "حساب المصروف :";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label6.ForeColor = System.Drawing.Color.Navy;
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(314, 46);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 13);
            this.label6.TabIndex = 1062;
            this.label6.Text = "مركـــز التكلفـــة :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(423, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 72;
            this.label1.Text = "الشهـــــر :";
            // 
            // textBox_Date
            // 
            this.textBox_Date.BackColor = System.Drawing.Color.Red;
            this.textBox_Date.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.textBox_Date.ForeColor = System.Drawing.Color.White;
            this.textBox_Date.Location = new System.Drawing.Point(251, 22);
            this.textBox_Date.Mask = "0000/00";
            this.textBox_Date.Name = "textBox_Date";
            this.textBox_Date.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox_Date.Size = new System.Drawing.Size(169, 21);
            this.textBox_Date.TabIndex = 71;
            this.textBox_Date.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_Date.Click += new System.EventHandler(this.textBox_Date_Click);
            this.textBox_Date.Leave += new System.EventHandler(this.textBox_Date_Leave);
            // 
            // DVG_ACC
            // 
            this.DVG_ACC.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.DVG_ACC.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            this.DVG_ACC.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.DVG_ACC.HScrollBarVisible = false;
            this.DVG_ACC.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.DVG_ACC.Location = new System.Drawing.Point(0, 188);
            this.DVG_ACC.Name = "DVG_ACC";
            gridColumn1.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.None;
            gridColumn1.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gridColumn1.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridDoubleInputEditControl);
            gridColumn1.EnableFiltering = DevComponents.DotNetBar.SuperGrid.Style.Tbool.True;
            gridColumn1.FilterAutoScan = true;
            gridColumn1.FilterMatchType = DevComponents.DotNetBar.SuperGrid.FilterMatchType.Wildcards;
            gridColumn1.Name = "";
            gridColumn1.Width = 110;
            gridColumn2.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.None;
            gridColumn2.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gridColumn2.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridIntegerInputEditControl);
            gridColumn2.EnableFiltering = DevComponents.DotNetBar.SuperGrid.Style.Tbool.True;
            gridColumn2.FilterAutoScan = true;
            gridColumn2.FilterMatchType = DevComponents.DotNetBar.SuperGrid.FilterMatchType.Wildcards;
            gridColumn2.Name = "";
            gridColumn2.ReadOnly = true;
            gridColumn2.Visible = false;
            gridColumn2.Width = 60;
            gridColumn3.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.None;
            gridColumn3.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gridColumn3.CellStyles.Default.AllowWrap = DevComponents.DotNetBar.SuperGrid.Style.Tbool.True;
            gridColumn3.EnableFiltering = DevComponents.DotNetBar.SuperGrid.Style.Tbool.True;
            gridColumn3.FilterAutoScan = true;
            gridColumn3.FilterMatchType = DevComponents.DotNetBar.SuperGrid.FilterMatchType.RegularExpressions;
            gridColumn3.Name = "";
            gridColumn3.ReadOnly = true;
            gridColumn3.Width = 280;
            gridColumn4.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.None;
            gridColumn4.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gridColumn4.EnableFiltering = DevComponents.DotNetBar.SuperGrid.Style.Tbool.True;
            gridColumn4.FilterAutoScan = true;
            gridColumn4.FilterMatchType = DevComponents.DotNetBar.SuperGrid.FilterMatchType.Wildcards;
            gridColumn4.Name = "";
            gridColumn4.ReadOnly = true;
            gridColumn4.Width = 110;
            this.DVG_ACC.PrimaryGrid.Columns.Add(gridColumn1);
            this.DVG_ACC.PrimaryGrid.Columns.Add(gridColumn2);
            this.DVG_ACC.PrimaryGrid.Columns.Add(gridColumn3);
            this.DVG_ACC.PrimaryGrid.Columns.Add(gridColumn4);
            this.DVG_ACC.PrimaryGrid.DefaultVisualStyles.AlternateColumnCellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            this.DVG_ACC.PrimaryGrid.DefaultVisualStyles.AlternateRowCellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            background1.Color1 = System.Drawing.SystemColors.ActiveCaption;
            background1.Color2 = System.Drawing.SystemColors.GradientInactiveCaption;
            this.DVG_ACC.PrimaryGrid.DefaultVisualStyles.ColumnHeaderStyles.Default.Background = background1;
            background2.Color1 = System.Drawing.SystemColors.ActiveCaption;
            this.DVG_ACC.PrimaryGrid.DefaultVisualStyles.FilterColumnHeaderStyles.Default.Background = background2;
            this.DVG_ACC.PrimaryGrid.EnableColumnFiltering = true;
            this.DVG_ACC.PrimaryGrid.EnableFiltering = true;
            this.DVG_ACC.PrimaryGrid.EnableRowFiltering = true;
            this.DVG_ACC.PrimaryGrid.Filter.Visible = true;
            this.DVG_ACC.PrimaryGrid.ShowRowGridIndex = true;
            this.DVG_ACC.PrimaryGrid.ShowRowHeaders = false;
            this.DVG_ACC.PrimaryGrid.UseAlternateColumnStyle = true;
            this.DVG_ACC.Size = new System.Drawing.Size(500, 265);
            this.DVG_ACC.SizingStyle = DevComponents.DotNetBar.SuperGrid.Style.StyleType.NotSelectable;
            this.DVG_ACC.TabIndex = 0;
            this.DVG_ACC.EndEdit += new System.EventHandler<DevComponents.DotNetBar.SuperGrid.GridEditEventArgs>(this.DVG_ACC_EndEdit);
            // 
            // txtSumDebit
            // 
            // 
            // 
            // 
            this.txtSumDebit.BackgroundStyle.BackColor = System.Drawing.Color.LightSlateGray;
            this.txtSumDebit.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtSumDebit.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtSumDebit.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtSumDebit.DisplayFormat = "0";
            this.txtSumDebit.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.txtSumDebit.ForeColor = System.Drawing.Color.White;
            this.txtSumDebit.Increment = 1D;
            this.txtSumDebit.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtSumDebit.IsInputReadOnly = true;
            this.txtSumDebit.Location = new System.Drawing.Point(23, 21);
            this.txtSumDebit.Name = "txtSumDebit";
            this.txtSumDebit.Size = new System.Drawing.Size(93, 22);
            this.txtSumDebit.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(118, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 13);
            this.label4.TabIndex = 8560;
            this.label4.Text = "إجمالي الرواتب :";
            // 
            // superTabItem_General
            // 
            this.superTabItem_General.AttachedControl = this.superTabControlPanel5;
            this.superTabItem_General.GlobalItem = false;
            this.superTabItem_General.Name = "superTabItem_General";
            // 
            // Button_OK
            // 
            this.Button_OK.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.Button_OK.Checked = true;
            this.Button_OK.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.Button_OK.FontBold = true;
            this.Button_OK.Name = "Button_OK";
            this.Button_OK.Stretch = true;
            this.Button_OK.Symbol = "";
            this.Button_OK.SymbolSize = 8F;
            this.Button_OK.Text = "إصدار الرواتب";
            this.Button_OK.Click += new System.EventHandler(this.Button_OK_Click);
            // 
            // button_Close
            // 
            this.button_Close.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.button_Close.Checked = true;
            this.button_Close.FontBold = true;
            this.button_Close.Name = "button_Close";
            this.button_Close.Stretch = true;
            this.button_Close.Symbol = "";
            this.button_Close.SymbolSize = 8F;
            this.button_Close.Text = "الخـــــــروج";
            this.button_Close.Click += new System.EventHandler(this.button_Close_Click);
            // 
            // netResize1
            // 
            this.netResize1.ParentControl = this;
            // 
            // FrmCalacSalary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 499);
            this.Controls.Add(this.ribbonBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "FrmCalacSalary";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "إصدار رواتب الموظفين";
            this.Load += new System.EventHandler(this.FrmCalacSalary_Load);
            this.Shown += new System.EventHandler(this.FrmInvSale_Shown);
            this.SizeChanged += new System.EventHandler(this.FrmInvSale_SizeChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Frm_KeyPress);
            this.ribbonBar1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl1)).EndInit();
            this.superTabControl1.ResumeLayout(false);
            this.superTabControl1.PerformLayout();
            this.superTabControlPanel5.ResumeLayout(false);
            this.superTabControlPanel5.PerformLayout();
            this.panel_Acc.ResumeLayout(false);
            this.panel_Acc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSumDebit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).EndInit();
            this.ResumeLayout(false);

        }//###########&&&&&&&&&&

}
}
