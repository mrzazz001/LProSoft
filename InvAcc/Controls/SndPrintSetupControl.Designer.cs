namespace InvAcc.Controls
{
    partial class SndPrintSetupControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SndPrintSetupControl));
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBox_previewPrint = new System.Windows.Forms.CheckBox();
            this.CmbInvType = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.CmbPaperSize = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label9 = new System.Windows.Forms.Label();
            this.txtpageCount = new DevComponents.Editors.IntegerInput();
            this.label33 = new System.Windows.Forms.Label();
            this.txtDistance = new DevComponents.Editors.DoubleInput();
            this.txtLinePage = new DevComponents.Editors.IntegerInput();
            this.CmbPrinter = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.txtTopM = new DevComponents.Editors.DoubleInput();
            this.txtBottM = new DevComponents.Editors.DoubleInput();
            this.txtRight = new DevComponents.Editors.DoubleInput();
            this.txtLeftM = new DevComponents.Editors.DoubleInput();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.ChkPTable = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.RedButCasher = new System.Windows.Forms.RadioButton();
            this.RedButPaperA4 = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ButWithoutSave = new DevComponents.DotNetBar.ButtonX();
            this.ButWithSave = new DevComponents.DotNetBar.ButtonX();
            this.ribbonBar1 = new DevComponents.DotNetBar.RibbonBar();
            this.RButLandscape = new System.Windows.Forms.RadioButton();
            this.RButPortrait = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtpageCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDistance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLinePage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTopM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBottM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLeftM)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.ribbonBar1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelX1
            // 
            this.labelX1.BackColor = System.Drawing.Color.SteelBlue;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelX1.Font = new System.Drawing.Font("Tahoma", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.labelX1.ForeColor = System.Drawing.Color.White;
            this.labelX1.Location = new System.Drawing.Point(0, 0);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(598, 26);
            this.labelX1.TabIndex = 88;
            this.labelX1.Text = "?????????????? ?????????? ??????????????";
            this.labelX1.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.checkBox_previewPrint);
            this.panel1.Controls.Add(this.CmbInvType);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.labelX1);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.ChkPTable);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(600, 436);
            this.panel1.TabIndex = 858;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // checkBox_previewPrint
            // 
            this.checkBox_previewPrint.AutoSize = true;
            this.checkBox_previewPrint.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.checkBox_previewPrint.ForeColor = System.Drawing.Color.Blue;
            this.checkBox_previewPrint.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.checkBox_previewPrint.Location = new System.Drawing.Point(263, 126);
            this.checkBox_previewPrint.Name = "checkBox_previewPrint";
            this.checkBox_previewPrint.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBox_previewPrint.Size = new System.Drawing.Size(177, 17);
            this.checkBox_previewPrint.TabIndex = 1020;
            this.checkBox_previewPrint.Text = "?????????? ?????????????? ?????????????? ???????????????????? ";
            this.checkBox_previewPrint.UseVisualStyleBackColor = true;
            this.checkBox_previewPrint.CheckedChanged += new System.EventHandler(this.checkBox_previewPrint_CheckedChanged);
            // 
            // CmbInvType
            // 
            this.CmbInvType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbInvType.DisplayMember = "Text";
            this.CmbInvType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.CmbInvType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbInvType.FormattingEnabled = true;
            this.CmbInvType.ItemHeight = 14;
            this.CmbInvType.Location = new System.Drawing.Point(151, 55);
            this.CmbInvType.Name = "CmbInvType";
            this.CmbInvType.Size = new System.Drawing.Size(198, 20);
            this.CmbInvType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.CmbInvType.TabIndex = 1;
            this.CmbInvType.SelectedIndexChanged += new System.EventHandler(this.CmbInvType_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.CmbPaperSize);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtpageCount);
            this.groupBox1.Controls.Add(this.label33);
            this.groupBox1.Controls.Add(this.txtDistance);
            this.groupBox1.Controls.Add(this.txtLinePage);
            this.groupBox1.Controls.Add(this.CmbPrinter);
            this.groupBox1.Controls.Add(this.txtTopM);
            this.groupBox1.Controls.Add(this.txtBottM);
            this.groupBox1.Controls.Add(this.txtRight);
            this.groupBox1.Controls.Add(this.txtLeftM);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Location = new System.Drawing.Point(15, 127);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(435, 256);
            this.groupBox1.TabIndex = 90;
            this.groupBox1.TabStop = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.RButLandscape);
            this.groupBox4.Controls.Add(this.RButPortrait);
            this.groupBox4.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.groupBox4.Location = new System.Drawing.Point(21, 114);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(144, 131);
            this.groupBox4.TabIndex = 1016;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "????????????????????????";
            // 
            // CmbPaperSize
            // 
            this.CmbPaperSize.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbPaperSize.DisplayMember = "Text";
            this.CmbPaperSize.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.CmbPaperSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbPaperSize.FormattingEnabled = true;
            this.CmbPaperSize.ItemHeight = 14;
            this.CmbPaperSize.Location = new System.Drawing.Point(181, 195);
            this.CmbPaperSize.Name = "CmbPaperSize";
            this.CmbPaperSize.Size = new System.Drawing.Size(223, 20);
            this.CmbPaperSize.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.CmbPaperSize.TabIndex = 1014;
            this.CmbPaperSize.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CmbPaperSize_MouseDown);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label9.Location = new System.Drawing.Point(332, 175);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 13);
            this.label9.TabIndex = 1015;
            this.label9.Text = "?????? ???????????? :";
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
            this.txtpageCount.Location = new System.Drawing.Point(236, 132);
            this.txtpageCount.MinValue = 1;
            this.txtpageCount.Name = "txtpageCount";
            this.txtpageCount.ShowUpDown = true;
            this.txtpageCount.Size = new System.Drawing.Size(68, 21);
            this.txtpageCount.TabIndex = 1003;
            this.txtpageCount.Value = 1;
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label33.ForeColor = System.Drawing.Color.Blue;
            this.label33.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label33.Location = new System.Drawing.Point(307, 136);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(69, 13);
            this.label33.TabIndex = 1002;
            this.label33.Text = "?????? ?????????? :";
            // 
            // txtDistance
            // 
            this.txtDistance.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtDistance.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(198)))));
            this.txtDistance.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtDistance.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDistance.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtDistance.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.txtDistance.Increment = 1D;
            this.txtDistance.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtDistance.Location = new System.Drawing.Point(-223, 108);
            this.txtDistance.MinValue = 0D;
            this.txtDistance.Name = "txtDistance";
            this.txtDistance.ShowUpDown = true;
            this.txtDistance.Size = new System.Drawing.Size(68, 20);
            this.txtDistance.TabIndex = 10;
            // 
            // txtLinePage
            // 
            this.txtLinePage.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtLinePage.BackgroundStyle.BackColor = System.Drawing.Color.AliceBlue;
            this.txtLinePage.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtLinePage.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtLinePage.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtLinePage.DisplayFormat = "0";
            this.txtLinePage.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtLinePage.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtLinePage.Location = new System.Drawing.Point(236, 108);
            this.txtLinePage.LockUpdateChecked = false;
            this.txtLinePage.MinValue = 0;
            this.txtLinePage.Name = "txtLinePage";
            this.txtLinePage.ShowCheckBox = true;
            this.txtLinePage.ShowUpDown = true;
            this.txtLinePage.Size = new System.Drawing.Size(68, 21);
            this.txtLinePage.TabIndex = 9;
            // 
            // CmbPrinter
            // 
            this.CmbPrinter.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbPrinter.DisplayMember = "Text";
            this.CmbPrinter.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.CmbPrinter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbPrinter.FormattingEnabled = true;
            this.CmbPrinter.ItemHeight = 14;
            this.CmbPrinter.Location = new System.Drawing.Point(21, 30);
            this.CmbPrinter.Name = "CmbPrinter";
            this.CmbPrinter.Size = new System.Drawing.Size(252, 20);
            this.CmbPrinter.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.CmbPrinter.TabIndex = 3;
            this.CmbPrinter.SelectedIndexChanged += new System.EventHandler(this.CmbPrinter_SelectedIndexChanged);
            // 
            // txtTopM
            // 
            this.txtTopM.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtTopM.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(198)))));
            this.txtTopM.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtTopM.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtTopM.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtTopM.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.txtTopM.Increment = 1D;
            this.txtTopM.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtTopM.Location = new System.Drawing.Point(236, 62);
            this.txtTopM.Name = "txtTopM";
            this.txtTopM.ShowUpDown = true;
            this.txtTopM.Size = new System.Drawing.Size(68, 20);
            this.txtTopM.TabIndex = 5;
            // 
            // txtBottM
            // 
            this.txtBottM.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtBottM.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(198)))));
            this.txtBottM.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtBottM.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtBottM.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtBottM.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.txtBottM.Increment = 1D;
            this.txtBottM.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtBottM.Location = new System.Drawing.Point(236, 85);
            this.txtBottM.Name = "txtBottM";
            this.txtBottM.ShowUpDown = true;
            this.txtBottM.Size = new System.Drawing.Size(68, 20);
            this.txtBottM.TabIndex = 7;
            // 
            // txtRight
            // 
            this.txtRight.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtRight.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(198)))));
            this.txtRight.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtRight.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtRight.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtRight.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.txtRight.Increment = 1D;
            this.txtRight.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtRight.Location = new System.Drawing.Point(21, 62);
            this.txtRight.Name = "txtRight";
            this.txtRight.ShowUpDown = true;
            this.txtRight.Size = new System.Drawing.Size(68, 20);
            this.txtRight.TabIndex = 6;
            // 
            // txtLeftM
            // 
            this.txtLeftM.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtLeftM.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(198)))));
            this.txtLeftM.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtLeftM.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtLeftM.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtLeftM.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.txtLeftM.Increment = 1D;
            this.txtLeftM.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtLeftM.Location = new System.Drawing.Point(21, 85);
            this.txtLeftM.Name = "txtLeftM";
            this.txtLeftM.ShowUpDown = true;
            this.txtLeftM.Size = new System.Drawing.Size(68, 20);
            this.txtLeftM.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(-149, 112);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "?????????????? ?????? ???????????? :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(95, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "???????????? ???????????? :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(308, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "???????????? ???????????? :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(95, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "???????????? ???????????? :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(308, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "???????????? ???????????? :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(308, 112);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "???????????? ???? ???????????? :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(277, 34);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(145, 13);
            this.label7.TabIndex = 48;
            this.label7.Text = "?????????? ?????????? ???????????????? ???????????????? :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(355, 58);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 13);
            this.label8.TabIndex = 41;
            this.label8.Text = " ?????? ????????????????:";
            // 
            // ChkPTable
            // 
            this.ChkPTable.AutoSize = true;
            this.ChkPTable.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.ChkPTable.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ChkPTable.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ChkPTable.Location = new System.Drawing.Point(83, 96);
            this.ChkPTable.Name = "ChkPTable";
            this.ChkPTable.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ChkPTable.Size = new System.Drawing.Size(193, 17);
            this.ChkPTable.TabIndex = 2;
            this.ChkPTable.Text = "?????????? ?????????? ???????????? ??????????????????";
            this.ChkPTable.UseVisualStyleBackColor = true;
            this.ChkPTable.CheckedChanged += new System.EventHandler(this.ChkPTable_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.RedButCasher);
            this.groupBox2.Controls.Add(this.RedButPaperA4);
            this.groupBox2.Location = new System.Drawing.Point(-239, 39);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(207, 88);
            this.groupBox2.TabIndex = 89;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "?????????? ??????????????";
            // 
            // RedButCasher
            // 
            this.RedButCasher.AutoSize = true;
            this.RedButCasher.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.RedButCasher.Location = new System.Drawing.Point(34, 56);
            this.RedButCasher.Name = "RedButCasher";
            this.RedButCasher.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RedButCasher.Size = new System.Drawing.Size(137, 17);
            this.RedButCasher.TabIndex = 46;
            this.RedButCasher.Text = "?????????? ?????? ?????? ??????????????";
            this.RedButCasher.UseVisualStyleBackColor = true;
            // 
            // RedButPaperA4
            // 
            this.RedButPaperA4.AutoSize = true;
            this.RedButPaperA4.Checked = true;
            this.RedButPaperA4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.RedButPaperA4.Location = new System.Drawing.Point(56, 24);
            this.RedButPaperA4.Name = "RedButPaperA4";
            this.RedButPaperA4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RedButPaperA4.Size = new System.Drawing.Size(115, 17);
            this.RedButPaperA4.TabIndex = 45;
            this.RedButPaperA4.TabStop = true;
            this.RedButPaperA4.Text = "?????????? ?????? ?????? A4";
            this.RedButPaperA4.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.groupBox3.Controls.Add(this.ButWithoutSave);
            this.groupBox3.Controls.Add(this.ButWithSave);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox3.Location = new System.Drawing.Point(0, 399);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(600, 54);
            this.groupBox3.TabIndex = 987;
            this.groupBox3.TabStop = false;
            // 
            // ButWithoutSave
            // 
            this.ButWithoutSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.ButWithoutSave.Checked = true;
            this.ButWithoutSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.ButWithoutSave.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.ButWithoutSave.Location = new System.Drawing.Point(10, 14);
            this.ButWithoutSave.Name = "ButWithoutSave";
            this.ButWithoutSave.Size = new System.Drawing.Size(221, 35);
            this.ButWithoutSave.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ButWithoutSave.Symbol = "???";
            this.ButWithoutSave.SymbolSize = 12F;
            this.ButWithoutSave.TabIndex = 12;
            this.ButWithoutSave.Text = "????????????????";
            this.ButWithoutSave.TextColor = System.Drawing.Color.Black;
            // 
            // ButWithSave
            // 
            this.ButWithSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.ButWithSave.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.ButWithSave.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.ButWithSave.Location = new System.Drawing.Point(238, 14);
            this.ButWithSave.Name = "ButWithSave";
            this.ButWithSave.Size = new System.Drawing.Size(221, 35);
            this.ButWithSave.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ButWithSave.Symbol = "???";
            this.ButWithSave.SymbolSize = 12F;
            this.ButWithSave.TabIndex = 11;
            this.ButWithSave.Text = "??????????????";
            this.ButWithSave.TextColor = System.Drawing.Color.White;
            this.ButWithSave.Click += new System.EventHandler(this.ButWithSave_Click);
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
            this.ribbonBar1.Size = new System.Drawing.Size(600, 453);
            this.ribbonBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this.ribbonBar1.TabIndex = 986;
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
            // RButLandscape
            // 
            this.RButLandscape.AutoSize = true;
            this.RButLandscape.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.RButLandscape.ForeColor = System.Drawing.Color.SteelBlue;
            this.RButLandscape.Image = ((System.Drawing.Image)(resources.GetObject("RButLandscape.Image")));
            this.RButLandscape.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.RButLandscape.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.RButLandscape.Location = new System.Drawing.Point(12, 76);
            this.RButLandscape.Name = "RButLandscape";
            this.RButLandscape.Size = new System.Drawing.Size(115, 40);
            this.RButLandscape.TabIndex = 1008;
            this.RButLandscape.Text = "????????                  ";
            this.RButLandscape.UseVisualStyleBackColor = true;
            // 
            // RButPortrait
            // 
            this.RButPortrait.AutoSize = true;
            this.RButPortrait.Checked = true;
            this.RButPortrait.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.RButPortrait.ForeColor = System.Drawing.Color.SteelBlue;
            this.RButPortrait.Image = ((System.Drawing.Image)(resources.GetObject("RButPortrait.Image")));
            this.RButPortrait.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.RButPortrait.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.RButPortrait.Location = new System.Drawing.Point(12, 27);
            this.RButPortrait.Name = "RButPortrait";
            this.RButPortrait.Size = new System.Drawing.Size(114, 40);
            this.RButPortrait.TabIndex = 1007;
            this.RButPortrait.TabStop = true;
            this.RButPortrait.Text = "????????                   ";
            this.RButPortrait.UseVisualStyleBackColor = true;
            // 
            // SndPrintSetupControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.ribbonBar1);
            this.Name = "SndPrintSetupControl";
            this.Size = new System.Drawing.Size(600, 453);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SndPrintSetupControl_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SndPrintSetupControl_KeyPress);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtpageCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDistance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLinePage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTopM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBottM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLeftM)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ribbonBar1.ResumeLayout(false);
          //  this.Icon = ((System.Drawing.Icon)(InvAcc.Properties.Resources.favicon));
this.ResumeLayout(false);
        }
        #endregion
        private DevComponents.DotNetBar.LabelX labelX1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox checkBox_previewPrint;
        private DevComponents.DotNetBar.Controls.ComboBoxEx CmbInvType;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton RButLandscape;
        private System.Windows.Forms.RadioButton RButPortrait;
        private DevComponents.DotNetBar.Controls.ComboBoxEx CmbPaperSize;
        private System.Windows.Forms.Label label9;
        private DevComponents.Editors.IntegerInput txtpageCount;
        private System.Windows.Forms.Label label33;
        private DevComponents.Editors.DoubleInput txtDistance;
        private DevComponents.Editors.IntegerInput txtLinePage;
        private DevComponents.DotNetBar.Controls.ComboBoxEx CmbPrinter;
        private DevComponents.Editors.DoubleInput txtTopM;
        private DevComponents.Editors.DoubleInput txtBottM;
        private DevComponents.Editors.DoubleInput txtRight;
        private DevComponents.Editors.DoubleInput txtLeftM;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox ChkPTable;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton RedButCasher;
        private System.Windows.Forms.RadioButton RedButPaperA4;
        private System.Windows.Forms.GroupBox groupBox3;
        private DevComponents.DotNetBar.ButtonX ButWithoutSave;
        private DevComponents.DotNetBar.ButtonX ButWithSave;
        private DevComponents.DotNetBar.RibbonBar ribbonBar1;
    }
}
