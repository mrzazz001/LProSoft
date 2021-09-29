   

namespace InvAcc.Forms
{
partial class FrmEndYear
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEndYear));
            this.PanelSpecialContainer = new System.Windows.Forms.Panel();
            this.ribbonBar1 = new DevComponents.DotNetBar.RibbonBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.switchButton_CloseOption = new DevComponents.DotNetBar.Controls.SwitchButton();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDateMonth = new DevComponents.Editors.IntegerInput();
            this.txtDateDay = new DevComponents.Editors.IntegerInput();
            this.txtTotalPointReturn = new DevComponents.Editors.DoubleInput();
            this.txtTotalPointAvalible = new DevComponents.Editors.DoubleInput();
            this.txtTotalPointUsed = new DevComponents.Editors.DoubleInput();
            this.txtTotalPointAll = new DevComponents.Editors.DoubleInput();
            this.CmbCurr = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDateAlarm = new DevComponents.Editors.IntegerInput();
            this.ButOk = new DevComponents.DotNetBar.ButtonX();
            this.groupBox_Options = new System.Windows.Forms.GroupBox();
            this.chk7 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.chk6 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chk4 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chk5 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chk1 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chk2 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chk3 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.textBox_EndsPath = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label25 = new System.Windows.Forms.Label();
            this.ButExit = new DevComponents.DotNetBar.ButtonX();
            this.FlexType = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.netResize1 = new Softgroup.NetResize.NetResize(this.components);  this.netResize1.LabelsAutoEllipse = false;
            this.netResize1.AfterControlResize += new Softgroup.NetResize.NetResize.AfterControlResizeEventHandler(this.netResize1_AfterControlResize);
            this.ribbonBar1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateMonth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateDay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalPointReturn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalPointAvalible)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalPointUsed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalPointAll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateAlarm)).BeginInit();
            this.groupBox_Options.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FlexType)).BeginInit();
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
            this.ribbonBar1.Controls.Add(this.panel1);
            this.ribbonBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonBar1.Tag= "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.ribbonBar1.Location = new System.Drawing.Point(0, 0);
            this.ribbonBar1.Name = "ribbonBar1";
            this.ribbonBar1.Size = new System.Drawing.Size(572, 370);
            this.ribbonBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this.ribbonBar1.TabIndex = 1103;
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
            this.panel1.AutoSize = true;
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.switchButton_CloseOption);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtDateMonth);
            this.panel1.Controls.Add(this.txtDateDay);
            this.panel1.Controls.Add(this.txtTotalPointReturn);
            this.panel1.Controls.Add(this.txtTotalPointAvalible);
            this.panel1.Controls.Add(this.txtTotalPointUsed);
            this.panel1.Controls.Add(this.txtTotalPointAll);
            this.panel1.Controls.Add(this.CmbCurr);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtDateAlarm);
            this.panel1.Controls.Add(this.ButOk);
            this.panel1.Controls.Add(this.groupBox_Options);
            this.panel1.Controls.Add(this.textBox_EndsPath);
            this.panel1.Controls.Add(this.label25);
            this.panel1.Controls.Add(this.ButExit);
            this.panel1.Controls.Add(this.FlexType);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(572, 353);
            this.panel1.TabIndex = 0;
            // 
            // switchButton_CloseOption
            // 
            this.switchButton_CloseOption.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            // 
            // 
            // 
            this.switchButton_CloseOption.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.switchButton_CloseOption.Location = new System.Drawing.Point(10, 88);
            this.switchButton_CloseOption.Name = "switchButton_CloseOption";
            this.switchButton_CloseOption.OffBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(80)))), ((int)(((byte)(77)))));
            this.switchButton_CloseOption.OffText = "إقفال جميع الفروع";
            this.switchButton_CloseOption.OffTextColor = System.Drawing.Color.White;
            this.switchButton_CloseOption.OnText = "تحديد الفروع";
            this.switchButton_CloseOption.Size = new System.Drawing.Size(179, 29);
            this.switchButton_CloseOption.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.switchButton_CloseOption.TabIndex = 6750;
            this.switchButton_CloseOption.ValueChanged += new System.EventHandler(this.switchButton_CloseOption_ValueChanged);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(9, 4);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(553, 27);
            this.label5.TabIndex = 6747;
            this.label5.Text = "طريقة الإقفــــال";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtDateMonth
            // 
            this.txtDateMonth.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtDateMonth.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtDateMonth.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtDateMonth.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDateMonth.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtDateMonth.DisplayFormat = "0";
            this.txtDateMonth.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtDateMonth.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtDateMonth.IsInputReadOnly = true;
            this.txtDateMonth.Location = new System.Drawing.Point(321, 33);
            this.txtDateMonth.LockUpdateChecked = false;
            this.txtDateMonth.MinValue = 0;
            this.txtDateMonth.Name = "txtDateMonth";
            this.txtDateMonth.Size = new System.Drawing.Size(46, 21);
            this.txtDateMonth.TabIndex = 6745;
            this.txtDateMonth.Value = 12;
            // 
            // txtDateDay
            // 
            this.txtDateDay.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtDateDay.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtDateDay.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtDateDay.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDateDay.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtDateDay.DisplayFormat = "0";
            this.txtDateDay.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtDateDay.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtDateDay.IsInputReadOnly = true;
            this.txtDateDay.Location = new System.Drawing.Point(370, 33);
            this.txtDateDay.LockUpdateChecked = false;
            this.txtDateDay.MinValue = 0;
            this.txtDateDay.Name = "txtDateDay";
            this.txtDateDay.ShowCheckBox = true;
            this.txtDateDay.Size = new System.Drawing.Size(46, 21);
            this.txtDateDay.TabIndex = 6744;
            this.txtDateDay.Value = 31;
            this.txtDateDay.LockUpdateChanged += new System.EventHandler(this.txtDateDay_LockUpdateChanged);
            // 
            // txtTotalPointReturn
            // 
            this.txtTotalPointReturn.AllowEmptyState = false;
            this.txtTotalPointReturn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtTotalPointReturn.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtTotalPointReturn.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtTotalPointReturn.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtTotalPointReturn.DisplayFormat = "0.00";
            this.txtTotalPointReturn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtTotalPointReturn.Increment = 0D;
            this.txtTotalPointReturn.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtTotalPointReturn.IsInputReadOnly = true;
            this.txtTotalPointReturn.Location = new System.Drawing.Point(278, -49);
            this.txtTotalPointReturn.Name = "txtTotalPointReturn";
            this.txtTotalPointReturn.Size = new System.Drawing.Size(137, 21);
            this.txtTotalPointReturn.TabIndex = 6743;
            this.txtTotalPointReturn.Visible = false;
            // 
            // txtTotalPointAvalible
            // 
            this.txtTotalPointAvalible.AllowEmptyState = false;
            this.txtTotalPointAvalible.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtTotalPointAvalible.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtTotalPointAvalible.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtTotalPointAvalible.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtTotalPointAvalible.DisplayFormat = "0.00";
            this.txtTotalPointAvalible.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtTotalPointAvalible.Increment = 0D;
            this.txtTotalPointAvalible.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtTotalPointAvalible.IsInputReadOnly = true;
            this.txtTotalPointAvalible.Location = new System.Drawing.Point(278, -26);
            this.txtTotalPointAvalible.Name = "txtTotalPointAvalible";
            this.txtTotalPointAvalible.Size = new System.Drawing.Size(137, 21);
            this.txtTotalPointAvalible.TabIndex = 6742;
            this.txtTotalPointAvalible.Visible = false;
            // 
            // txtTotalPointUsed
            // 
            this.txtTotalPointUsed.AllowEmptyState = false;
            this.txtTotalPointUsed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtTotalPointUsed.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtTotalPointUsed.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtTotalPointUsed.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtTotalPointUsed.DisplayFormat = "0.00";
            this.txtTotalPointUsed.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtTotalPointUsed.Increment = 0D;
            this.txtTotalPointUsed.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtTotalPointUsed.IsInputReadOnly = true;
            this.txtTotalPointUsed.Location = new System.Drawing.Point(278, -72);
            this.txtTotalPointUsed.Name = "txtTotalPointUsed";
            this.txtTotalPointUsed.Size = new System.Drawing.Size(137, 21);
            this.txtTotalPointUsed.TabIndex = 6741;
            this.txtTotalPointUsed.Visible = false;
            // 
            // txtTotalPointAll
            // 
            this.txtTotalPointAll.AllowEmptyState = false;
            this.txtTotalPointAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtTotalPointAll.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtTotalPointAll.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtTotalPointAll.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtTotalPointAll.DisplayFormat = "0.00";
            this.txtTotalPointAll.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtTotalPointAll.Increment = 0D;
            this.txtTotalPointAll.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtTotalPointAll.IsInputReadOnly = true;
            this.txtTotalPointAll.Location = new System.Drawing.Point(278, -95);
            this.txtTotalPointAll.Name = "txtTotalPointAll";
            this.txtTotalPointAll.Size = new System.Drawing.Size(137, 21);
            this.txtTotalPointAll.TabIndex = 6740;
            this.txtTotalPointAll.Visible = false;
            // 
            // CmbCurr
            // 
            this.CmbCurr.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbCurr.DisplayMember = "Text";
            this.CmbCurr.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.CmbCurr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbCurr.Enabled = false;
            this.CmbCurr.FormattingEnabled = true;
            this.CmbCurr.ItemHeight = 14;
            this.CmbCurr.Location = new System.Drawing.Point(194, 282);
            this.CmbCurr.Name = "CmbCurr";
            this.CmbCurr.Size = new System.Drawing.Size(368, 20);
            this.CmbCurr.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.CmbCurr.TabIndex = 6739;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(418, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 21);
            this.label3.TabIndex = 941;
            this.label3.Text = "السنــــــة";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtDateAlarm
            // 
            this.txtDateAlarm.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtDateAlarm.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(198)))));
            this.txtDateAlarm.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtDateAlarm.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDateAlarm.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtDateAlarm.DisplayFormat = "0";
            this.txtDateAlarm.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtDateAlarm.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtDateAlarm.Location = new System.Drawing.Point(9, 33);
            this.txtDateAlarm.MinValue = 0;
            this.txtDateAlarm.Name = "txtDateAlarm";
            this.txtDateAlarm.Size = new System.Drawing.Size(309, 21);
            this.txtDateAlarm.TabIndex = 940;
            this.txtDateAlarm.Leave += new System.EventHandler(this.txtDateAlarm_Leave);
            // 
            // ButOk
            // 
            this.ButOk.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.ButOk.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.ButOk.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.ButOk.Location = new System.Drawing.Point(194, 309);
            this.ButOk.Name = "ButOk";
            this.ButOk.Size = new System.Drawing.Size(368, 36);
            this.ButOk.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ButOk.Symbol = "";
            this.ButOk.SymbolSize = 16F;
            this.ButOk.TabIndex = 1;
            this.ButOk.Text = "إقفـــال";
            this.ButOk.TextColor = System.Drawing.Color.White;
            this.ButOk.Click += new System.EventHandler(this.ButOk_Click);
            // 
            // groupBox_Options
            // 
            this.groupBox_Options.AutoSize = true;
            this.groupBox_Options.Controls.Add(this.chk7);
            this.groupBox_Options.Controls.Add(this.label2);
            this.groupBox_Options.Controls.Add(this.label1);
            this.groupBox_Options.Controls.Add(this.chk6);
            this.groupBox_Options.Controls.Add(this.chk4);
            this.groupBox_Options.Controls.Add(this.chk5);
            this.groupBox_Options.Controls.Add(this.chk1);
            this.groupBox_Options.Controls.Add(this.chk2);
            this.groupBox_Options.Controls.Add(this.chk3);
            this.groupBox_Options.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.groupBox_Options.ForeColor = System.Drawing.Color.SteelBlue;
            this.groupBox_Options.Location = new System.Drawing.Point(194, 82);
            this.groupBox_Options.Name = "groupBox_Options";
            this.groupBox_Options.Size = new System.Drawing.Size(368, 201);
            this.groupBox_Options.TabIndex = 938;
            this.groupBox_Options.TabStop = false;
            this.groupBox_Options.Text = "خيارات الإقفال";
            // 
            // chk7
            // 
            this.chk7.AutoSize = true;
            this.chk7.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chk7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chk7.Checked = true;
            this.chk7.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk7.CheckValue = "Y";
            this.chk7.Location = new System.Drawing.Point(176, 95);
            this.chk7.Name = "chk7";
            this.chk7.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chk7.Size = new System.Drawing.Size(164, 15);
            this.chk7.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chk7.TabIndex = 941;
            this.chk7.Text = "نقل النقاط العملاء المستحقة";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(77, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 12);
            this.label2.TabIndex = 940;
            this.label2.Text = "[ الإيرادات - المصروفات ]";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(164, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 12);
            this.label1.TabIndex = 939;
            this.label1.Text = "[ الميزانية ]";
            // 
            // chk6
            // 
            this.chk6.AutoSize = true;
            this.chk6.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chk6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chk6.Location = new System.Drawing.Point(183, 71);
            this.chk6.Name = "chk6";
            this.chk6.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chk6.Size = new System.Drawing.Size(156, 15);
            this.chk6.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chk6.TabIndex = 938;
            this.chk6.Text = "نقل أرصدة الأرباح والخسائر";
            this.chk6.CheckedChanged += new System.EventHandler(this.chk6_CheckedChanged);
            // 
            // chk4
            // 
            this.chk4.AutoSize = true;
            this.chk4.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chk4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chk4.Location = new System.Drawing.Point(192, 119);
            this.chk4.Name = "chk4";
            this.chk4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chk4.Size = new System.Drawing.Size(148, 15);
            this.chk4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chk4.TabIndex = 936;
            this.chk4.Text = "مسح جميع بيانات الفندق";
            this.chk4.Visible = false;
            this.chk4.CheckedChanged += new System.EventHandler(this.chk4_CheckedChanged);
            // 
            // chk5
            // 
            this.chk5.AutoSize = true;
            this.chk5.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chk5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chk5.Location = new System.Drawing.Point(107, 167);
            this.chk5.Name = "chk5";
            this.chk5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chk5.Size = new System.Drawing.Size(231, 15);
            this.chk5.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chk5.TabIndex = 937;
            this.chk5.Text = "حذف حسابات النـــزلاء الذين ارصدتهم صفر";
            this.chk5.Visible = false;
            // 
            // chk1
            // 
            this.chk1.AutoSize = true;
            this.chk1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chk1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chk1.Checked = true;
            this.chk1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk1.CheckValue = "Y";
            this.chk1.Location = new System.Drawing.Point(215, 47);
            this.chk1.Name = "chk1";
            this.chk1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chk1.Size = new System.Drawing.Size(125, 15);
            this.chk1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chk1.TabIndex = 4;
            this.chk1.Text = "نقل أرصدة الحسابات ";
            // 
            // chk2
            // 
            this.chk2.AutoSize = true;
            this.chk2.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chk2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chk2.Checked = true;
            this.chk2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk2.CheckValue = "Y";
            this.chk2.Location = new System.Drawing.Point(68, 23);
            this.chk2.Name = "chk2";
            this.chk2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chk2.Size = new System.Drawing.Size(268, 15);
            this.chk2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chk2.TabIndex = 5;
            this.chk2.Text = "نقل الكميات الى السنة الجديدة كبضاعة أول المدة";
            // 
            // chk3
            // 
            this.chk3.AutoSize = true;
            this.chk3.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chk3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chk3.Location = new System.Drawing.Point(73, 143);
            this.chk3.Name = "chk3";
            this.chk3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chk3.Size = new System.Drawing.Size(263, 15);
            this.chk3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chk3.TabIndex = 935;
            this.chk3.Text = "مسح جميع بيانات الفندق | النزلاء المغادرين فقط";
            this.chk3.Visible = false;
            this.chk3.CheckedChanged += new System.EventHandler(this.chk3_CheckedChanged);
            // 
            // textBox_EndsPath
            // 
            this.textBox_EndsPath.BackColor = System.Drawing.SystemColors.ActiveCaption;
            // 
            // 
            // 
            this.textBox_EndsPath.Border.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.textBox_EndsPath.Border.BorderBottomWidth = 1;
            this.textBox_EndsPath.Border.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.textBox_EndsPath.Border.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.textBox_EndsPath.Border.BorderLeftWidth = 1;
            this.textBox_EndsPath.Border.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.textBox_EndsPath.Border.BorderRightWidth = 1;
            this.textBox_EndsPath.Border.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.textBox_EndsPath.Border.BorderTopWidth = 1;
            this.textBox_EndsPath.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBox_EndsPath.Font = new System.Drawing.Font("Tahoma", 6.75F);
            this.textBox_EndsPath.ForeColor = System.Drawing.Color.White;
            this.textBox_EndsPath.Location = new System.Drawing.Point(9, 55);
            this.textBox_EndsPath.Multiline = true;
            this.textBox_EndsPath.Name = "textBox_EndsPath";
            this.textBox_EndsPath.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_EndsPath, false);
            this.textBox_EndsPath.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBox_EndsPath.Size = new System.Drawing.Size(407, 22);
            this.textBox_EndsPath.TabIndex = 6;
            this.textBox_EndsPath.WatermarkColor = System.Drawing.Color.White;
            this.textBox_EndsPath.Click += new System.EventHandler(this.textBox_EndsPath_Click);
            // 
            // label25
            // 
            this.label25.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label25.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label25.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label25.ForeColor = System.Drawing.Color.Black;
            this.label25.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label25.Location = new System.Drawing.Point(418, 56);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(144, 21);
            this.label25.TabIndex = 932;
            this.label25.Text = "مسار الإقفـــــال";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ButExit
            // 
            this.ButExit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.ButExit.Checked = true;
            this.ButExit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.ButExit.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.ButExit.Location = new System.Drawing.Point(6, 309);
            this.ButExit.Name = "ButExit";
            this.ButExit.Size = new System.Drawing.Size(182, 36);
            this.ButExit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ButExit.Symbol = "";
            this.ButExit.SymbolSize = 16F;
            this.ButExit.TabIndex = 3;
            this.ButExit.Text = "خـــروج";
            this.ButExit.TextColor = System.Drawing.Color.Black;
            this.ButExit.Click += new System.EventHandler(this.ButExit_Click);
            // 
            // FlexType
            // 
            this.FlexType.AllowEditing = false;
            this.FlexType.BackColor = System.Drawing.Color.White;
            this.FlexType.ColumnInfo = resources.GetString("FlexType.ColumnInfo");
            this.FlexType.Font = new System.Drawing.Font("Tahoma", 8F);
            this.FlexType.Location = new System.Drawing.Point(9, 121);
            this.FlexType.Name = "FlexType";
            this.FlexType.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.FlexType.Rows.Count = 1;
            this.FlexType.Rows.DefaultSize = 19;
            this.FlexType.Rows.Fixed = 0;
            this.FlexType.Size = new System.Drawing.Size(179, 182);
            this.FlexType.StyleInfo = resources.GetString("FlexType.StyleInfo");
            this.FlexType.TabIndex = 6748;
            this.FlexType.Tag = " T_INVHED.InvCashPay ";
            this.FlexType.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.System;
            // 
            // netResize1
            // 
            this.netResize1.ParentControl = this;
            // 
            // FrmEndYear
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 370);
            this.Controls.Add(this.ribbonBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "FrmEndYear";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "إقفال السنـــــة";
            this.Load += new System.EventHandler(this.FrmEndYear_Load);
            this.Shown += new System.EventHandler(this.FrmInvSale_Shown);
            this.SizeChanged += new System.EventHandler(this.FrmInvSale_SizeChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmEndYear_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FrmEndYear_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmEndYear_KeyUp);
            this.ribbonBar1.ResumeLayout(false);
            this.ribbonBar1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateMonth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateDay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalPointReturn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalPointAvalible)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalPointUsed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalPointAll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateAlarm)).EndInit();
            this.groupBox_Options.ResumeLayout(false);
            this.groupBox_Options.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FlexType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).EndInit();
            this.ResumeLayout(false);

        }//###########&&&&&&&&&&

}
}
