   

namespace InvAcc.Forms
{
partial class FMBarCodeUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FMBarCodeUser));
            this.CmbPrintP2 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.CmbPrintP = new System.Windows.Forms.ComboBox();
            this.CmbDir = new System.Windows.Forms.ComboBox();
            this.ribbonBar1 = new DevComponents.DotNetBar.RibbonBar();
            this.CmbUnit = new System.Windows.Forms.ComboBox();
            this.FlxFiles = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtLeftM = new DevComponents.Editors.DoubleInput();
            this.txtTopM = new DevComponents.Editors.DoubleInput();
            this.CmbPrinter = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.txtWidth = new DevComponents.Editors.DoubleInput();
            this.txtHeight = new DevComponents.Editors.DoubleInput();
            this.txtBarWidth = new DevComponents.Editors.IntegerInput();
            this.txtBarHeigth = new DevComponents.Editors.IntegerInput();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtpageCount = new DevComponents.Editors.IntegerInput();
            this.label33 = new System.Windows.Forms.Label();
            this.txtNumRows = new DevComponents.Editors.DoubleInput();
            this.txtNumCols = new DevComponents.Editors.DoubleInput();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ButWithoutSave = new DevComponents.DotNetBar.ButtonX();
            this.ButWithSave = new DevComponents.DotNetBar.ButtonX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.ribbonBar1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FlxFiles)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtLeftM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTopM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBarWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBarHeigth)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtpageCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumRows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumCols)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // CmbPrintP2
            // 
            this.CmbPrintP2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbPrintP2.FormattingEnabled = true;
            this.CmbPrintP2.Location = new System.Drawing.Point(132, 486);
            this.CmbPrintP2.Name = "CmbPrintP2";
            this.CmbPrintP2.Size = new System.Drawing.Size(140, 21);
            this.CmbPrintP2.TabIndex = 33;
            // 
            // button1
            // 
            this.button1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button1.Location = new System.Drawing.Point(610, 384);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 25);
            this.button1.TabIndex = 34;
            this.button1.Text = "?????? ??????????";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // CmbPrintP
            // 
            this.CmbPrintP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbPrintP.FormattingEnabled = true;
            this.CmbPrintP.Location = new System.Drawing.Point(297, 484);
            this.CmbPrintP.Name = "CmbPrintP";
            this.CmbPrintP.Size = new System.Drawing.Size(140, 21);
            this.CmbPrintP.TabIndex = 32;
            // 
            // CmbDir
            // 
            this.CmbDir.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbDir.FormattingEnabled = true;
            this.CmbDir.Location = new System.Drawing.Point(448, 486);
            this.CmbDir.Name = "CmbDir";
            this.CmbDir.Size = new System.Drawing.Size(140, 21);
            this.CmbDir.TabIndex = 31;
            // 
            // ribbonBar1
            // 
            this.ribbonBar1.AutoOverflowEnabled = true;
            this.ribbonBar1.BackColor = System.Drawing.Color.Gainsboro;
            // 
            // 
            // 
            this.ribbonBar1.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar1.BackgroundStyle.BackColor = System.Drawing.Color.Gainsboro;
            this.ribbonBar1.BackgroundStyle.BackColor2 = System.Drawing.Color.Gainsboro;
            this.ribbonBar1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar1.ContainerControlProcessDialogKey = true;
            this.ribbonBar1.Controls.Add(this.CmbUnit);
            this.ribbonBar1.Controls.Add(this.FlxFiles);
            this.ribbonBar1.Controls.Add(this.groupBox1);
            this.ribbonBar1.Controls.Add(this.groupBox3);
            this.ribbonBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonBar1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.ribbonBar1.Location = new System.Drawing.Point(0, 0);
            this.ribbonBar1.Name = "ribbonBar1";
            this.ribbonBar1.Size = new System.Drawing.Size(594, 549);
            this.ribbonBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this.ribbonBar1.TabIndex = 980;
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
            // CmbUnit
            // 
            this.CmbUnit.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbUnit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.CmbUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbUnit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CmbUnit.FormattingEnabled = true;
            this.CmbUnit.Items.AddRange(new object[] {
            "mm",
            "doc",
            "in",
            "point",
            "pixel"});
            this.CmbUnit.Location = new System.Drawing.Point(7, 172);
            this.CmbUnit.Name = "CmbUnit";
            this.CmbUnit.Size = new System.Drawing.Size(97, 21);
            this.CmbUnit.TabIndex = 991;
            // 
            // FlxFiles
            // 
            this.FlxFiles.ColumnInfo = resources.GetString("FlxFiles.ColumnInfo");
            this.FlxFiles.Font = new System.Drawing.Font("Tahoma", 8F);
            this.FlxFiles.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross;
            this.FlxFiles.Location = new System.Drawing.Point(7, 32);
            this.FlxFiles.Name = "FlxFiles";
            this.FlxFiles.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.FlxFiles.Rows.Count = 20;
            this.FlxFiles.Rows.DefaultSize = 19;
            this.FlxFiles.Size = new System.Drawing.Size(581, 134);
            this.FlxFiles.StyleInfo = resources.GetString("FlxFiles.StyleInfo");
            this.FlxFiles.TabIndex = 11;
            this.FlxFiles.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.System;
            this.FlxFiles.AfterEdit += new C1.Win.C1FlexGrid.RowColEventHandler(this.FlxFiles_AfterEdit);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.txtLeftM);
            this.groupBox1.Controls.Add(this.txtTopM);
            this.groupBox1.Controls.Add(this.CmbPrinter);
            this.groupBox1.Controls.Add(this.txtWidth);
            this.groupBox1.Controls.Add(this.txtHeight);
            this.groupBox1.Controls.Add(this.txtBarWidth);
            this.groupBox1.Controls.Add(this.txtBarHeigth);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(644, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(581, 110);
            this.groupBox1.TabIndex = 983;
            this.groupBox1.TabStop = false;
            // 
            // txtLeftM
            // 
            this.txtLeftM.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtLeftM.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtLeftM.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtLeftM.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtLeftM.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.txtLeftM.Increment = 1D;
            this.txtLeftM.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtLeftM.Location = new System.Drawing.Point(20, 16);
            this.txtLeftM.MinValue = 0D;
            this.txtLeftM.Name = "txtLeftM";
            this.txtLeftM.Size = new System.Drawing.Size(47, 20);
            this.txtLeftM.TabIndex = 3;
            // 
            // txtTopM
            // 
            this.txtTopM.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtTopM.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtTopM.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtTopM.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtTopM.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.txtTopM.Increment = 1D;
            this.txtTopM.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtTopM.Location = new System.Drawing.Point(153, 16);
            this.txtTopM.MinValue = 0D;
            this.txtTopM.Name = "txtTopM";
            this.txtTopM.Size = new System.Drawing.Size(47, 20);
            this.txtTopM.TabIndex = 2;
            // 
            // CmbPrinter
            // 
            this.CmbPrinter.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbPrinter.DisplayMember = "Text";
            this.CmbPrinter.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.CmbPrinter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbPrinter.FormattingEnabled = true;
            this.CmbPrinter.ItemHeight = 14;
            this.CmbPrinter.Location = new System.Drawing.Point(291, 16);
            this.CmbPrinter.Name = "CmbPrinter";
            this.CmbPrinter.Size = new System.Drawing.Size(207, 20);
            this.CmbPrinter.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.CmbPrinter.TabIndex = 1;
            // 
            // txtWidth
            // 
            this.txtWidth.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtWidth.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtWidth.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtWidth.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtWidth.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.txtWidth.Increment = 1D;
            this.txtWidth.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtWidth.Location = new System.Drawing.Point(310, 84);
            this.txtWidth.MinValue = 0D;
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.ShowUpDown = true;
            this.txtWidth.Size = new System.Drawing.Size(85, 20);
            this.txtWidth.TabIndex = 6;
            // 
            // txtHeight
            // 
            this.txtHeight.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtHeight.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtHeight.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtHeight.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtHeight.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.txtHeight.Increment = 1D;
            this.txtHeight.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtHeight.Location = new System.Drawing.Point(52, 81);
            this.txtHeight.MinValue = 0D;
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.ShowUpDown = true;
            this.txtHeight.Size = new System.Drawing.Size(85, 20);
            this.txtHeight.TabIndex = 7;
            this.txtHeight.Value = 2D;
            // 
            // txtBarWidth
            // 
            this.txtBarWidth.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtBarWidth.BackgroundStyle.BackColor = System.Drawing.Color.AliceBlue;
            this.txtBarWidth.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtBarWidth.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtBarWidth.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtBarWidth.DisplayFormat = "0";
            this.txtBarWidth.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtBarWidth.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtBarWidth.Location = new System.Drawing.Point(327, 51);
            this.txtBarWidth.MinValue = 0;
            this.txtBarWidth.Name = "txtBarWidth";
            this.txtBarWidth.ShowUpDown = true;
            this.txtBarWidth.Size = new System.Drawing.Size(68, 21);
            this.txtBarWidth.TabIndex = 4;
            this.txtBarWidth.Value = 1;
            // 
            // txtBarHeigth
            // 
            this.txtBarHeigth.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtBarHeigth.BackgroundStyle.BackColor = System.Drawing.Color.AliceBlue;
            this.txtBarHeigth.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtBarHeigth.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtBarHeigth.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtBarHeigth.DisplayFormat = "0";
            this.txtBarHeigth.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtBarHeigth.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtBarHeigth.Location = new System.Drawing.Point(69, 51);
            this.txtBarHeigth.MinValue = 0;
            this.txtBarHeigth.Name = "txtBarHeigth";
            this.txtBarHeigth.ShowUpDown = true;
            this.txtBarHeigth.Size = new System.Drawing.Size(68, 21);
            this.txtBarHeigth.TabIndex = 5;
            this.txtBarHeigth.Value = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(143, 88);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(127, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "???????????????? ?????? ???????? ???????????????? :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label10.Location = new System.Drawing.Point(68, 20);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(70, 13);
            this.label10.TabIndex = 6;
            this.label10.Text = "???????? ???????? :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(143, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "?????????????????????? :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(401, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "???????????????? :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(401, 88);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(156, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "?????????? ???????????? ?????? ???????? ???????????????? :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(498, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "???????????? ?????????????? :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(201, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "???????? ???????? :";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.txtpageCount);
            this.groupBox3.Controls.Add(this.label33);
            this.groupBox3.Controls.Add(this.txtNumRows);
            this.groupBox3.Controls.Add(this.txtNumCols);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Location = new System.Drawing.Point(797, 270);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(581, 52);
            this.groupBox3.TabIndex = 990;
            this.groupBox3.TabStop = false;
            // 
            // txtpageCount
            // 
            this.txtpageCount.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtpageCount.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(198)))));
            this.txtpageCount.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtpageCount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtpageCount.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtpageCount.DisplayFormat = "0";
            this.txtpageCount.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtpageCount.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtpageCount.Location = new System.Drawing.Point(96, 20);
            this.txtpageCount.MinValue = 1;
            this.txtpageCount.Name = "txtpageCount";
            this.txtpageCount.ShowUpDown = true;
            this.txtpageCount.Size = new System.Drawing.Size(62, 21);
            this.txtpageCount.TabIndex = 1001;
            this.txtpageCount.Value = 1;
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label33.ForeColor = System.Drawing.Color.Blue;
            this.label33.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label33.Location = new System.Drawing.Point(159, 24);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(69, 13);
            this.label33.TabIndex = 1000;
            this.label33.Text = "?????? ?????????? :";
            // 
            // txtNumRows
            // 
            this.txtNumRows.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtNumRows.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(198)))));
            this.txtNumRows.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtNumRows.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtNumRows.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtNumRows.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.txtNumRows.Increment = 1D;
            this.txtNumRows.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtNumRows.Location = new System.Drawing.Point(419, 20);
            this.txtNumRows.MinValue = 0D;
            this.txtNumRows.Name = "txtNumRows";
            this.txtNumRows.ShowUpDown = true;
            this.txtNumRows.Size = new System.Drawing.Size(62, 20);
            this.txtNumRows.TabIndex = 8;
            this.txtNumRows.Value = 1D;
            // 
            // txtNumCols
            // 
            this.txtNumCols.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtNumCols.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(198)))));
            this.txtNumCols.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtNumCols.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtNumCols.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtNumCols.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.txtNumCols.Increment = 1D;
            this.txtNumCols.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtNumCols.Location = new System.Drawing.Point(246, 20);
            this.txtNumCols.MinValue = 0D;
            this.txtNumCols.Name = "txtNumCols";
            this.txtNumCols.ShowUpDown = true;
            this.txtNumCols.Size = new System.Drawing.Size(62, 20);
            this.txtNumCols.TabIndex = 9;
            this.txtNumCols.Value = 1D;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label9.Location = new System.Drawing.Point(307, 24);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(97, 13);
            this.label9.TabIndex = 990;
            this.label9.Text = "?????? ???????????? ?????????? :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(481, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 13);
            this.label8.TabIndex = 989;
            this.label8.Text = "?????? ???????????? ?????????? :";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Gainsboro;
            this.groupBox2.Controls.Add(this.ButWithoutSave);
            this.groupBox2.Controls.Add(this.ButWithSave);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 549);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(594, 54);
            this.groupBox2.TabIndex = 983;
            this.groupBox2.TabStop = false;
            // 
            // ButWithoutSave
            // 
            this.ButWithoutSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.ButWithoutSave.Checked = true;
            this.ButWithoutSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.ButWithoutSave.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.ButWithoutSave.Location = new System.Drawing.Point(15, 14);
            this.ButWithoutSave.Name = "ButWithoutSave";
            this.ButWithoutSave.Size = new System.Drawing.Size(280, 35);
            this.ButWithoutSave.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ButWithoutSave.Symbol = "???";
            this.ButWithoutSave.SymbolSize = 12F;
            this.ButWithoutSave.TabIndex = 13;
            this.ButWithoutSave.Text = "???????????????? Esc";
            this.ButWithoutSave.TextColor = System.Drawing.Color.Black;
            this.ButWithoutSave.Click += new System.EventHandler(this.ButWithoutSave_Click);
            // 
            // ButWithSave
            // 
            this.ButWithSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.ButWithSave.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.ButWithSave.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.ButWithSave.Location = new System.Drawing.Point(303, 14);
            this.ButWithSave.Name = "ButWithSave";
            this.ButWithSave.Size = new System.Drawing.Size(280, 35);
            this.ButWithSave.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ButWithSave.Symbol = "???";
            this.ButWithSave.SymbolSize = 12F;
            this.ButWithSave.TabIndex = 12;
            this.ButWithSave.Text = "?????????????? F2";
            this.ButWithSave.TextColor = System.Drawing.Color.White;
            this.ButWithSave.Click += new System.EventHandler(this.ButWithSave_Click);
            // 
            // labelX1
            // 
            this.labelX1.BackColor = System.Drawing.Color.DimGray;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelX1.Font = new System.Drawing.Font("Tahoma", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.labelX1.ForeColor = System.Drawing.Color.White;
            this.labelX1.Location = new System.Drawing.Point(0, 0);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(594, 26);
            this.labelX1.TabIndex = 984;
            this.labelX1.Text = "?????????????? ?????????? ????????????????";
            this.labelX1.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // FMBarCodeUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(594, 269);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.ribbonBar1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.CmbPrintP2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.CmbPrintP);
            this.Controls.Add(this.CmbDir);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(InvAcc.Properties.Resources.favicon));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FMBarCodeUser";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FMBarCodeUser_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Frm_KeyPress);
            this.ribbonBar1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FlxFiles)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtLeftM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTopM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBarWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBarHeigth)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtpageCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumRows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumCols)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.Icon = ((System.Drawing.Icon)(InvAcc.Properties.Resources.favicon));
            this.ResumeLayout(false);

        }//###########&&&&&&&&&&

}
}
