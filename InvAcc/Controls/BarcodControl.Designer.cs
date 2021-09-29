namespace InvAcc.Controls
{
    partial class BarcodControl
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
            this.txtpageCount = new DevComponents.Editors.IntegerInput();
            this.label33 = new System.Windows.Forms.Label();
            this.txtNumRows = new DevComponents.Editors.DoubleInput();
            this.txtNumCols = new DevComponents.Editors.DoubleInput();
            this.checkBox_Collate = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ButWithoutSave = new DevComponents.DotNetBar.ButtonX();
            this.ButWithSave = new DevComponents.DotNetBar.ButtonX();
            this.txtLeftM = new DevComponents.Editors.DoubleInput();
            this.txtTopM = new DevComponents.Editors.DoubleInput();
            this.CmbPrinter = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.txtWidth = new DevComponents.Editors.DoubleInput();
            this.txtHeight = new DevComponents.Editors.DoubleInput();
            this.txtBarWidth = new DevComponents.Editors.IntegerInput();
            this.txtBarHeigth = new DevComponents.Editors.IntegerInput();
            this.label9 = new System.Windows.Forms.Label();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBox_previewPrint = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.ribbonBar1 = new DevComponents.DotNetBar.RibbonBar();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.CmbPrintP2 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.CmbPrintP = new System.Windows.Forms.ComboBox();
            this.CmbDir = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.txtpageCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumRows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumCols)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtLeftM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTopM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBarWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBarHeigth)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.ribbonBar1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
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
            this.txtpageCount.Location = new System.Drawing.Point(20, 17);
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
            this.label33.Location = new System.Drawing.Point(83, 21);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(69, 13);
            this.label33.TabIndex = 1000;
            this.label33.Text = "عدد النسخ :";
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
            this.txtNumRows.Location = new System.Drawing.Point(416, 17);
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
            this.txtNumCols.Location = new System.Drawing.Point(204, 17);
            this.txtNumCols.MinValue = 0D;
            this.txtNumCols.Name = "txtNumCols";
            this.txtNumCols.ShowUpDown = true;
            this.txtNumCols.Size = new System.Drawing.Size(62, 20);
            this.txtNumCols.TabIndex = 9;
            this.txtNumCols.Value = 1D;
            // 
            // checkBox_Collate
            // 
            this.checkBox_Collate.AutoSize = true;
            this.checkBox_Collate.BackColor = System.Drawing.Color.Transparent;
            this.checkBox_Collate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.checkBox_Collate.ForeColor = System.Drawing.Color.Maroon;
            this.checkBox_Collate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.checkBox_Collate.Location = new System.Drawing.Point(66, 53);
            this.checkBox_Collate.Name = "checkBox_Collate";
            this.checkBox_Collate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBox_Collate.Size = new System.Drawing.Size(71, 17);
            this.checkBox_Collate.TabIndex = 1022;
            this.checkBox_Collate.Text = "تجـميــــع";
            this.checkBox_Collate.UseVisualStyleBackColor = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(478, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 13);
            this.label8.TabIndex = 989;
            this.label8.Text = "عدد الكروت طوليا :";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.groupBox2.Controls.Add(this.ButWithoutSave);
            this.groupBox2.Controls.Add(this.ButWithSave);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 387);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(600, 54);
            this.groupBox2.TabIndex = 990;
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
            this.ButWithoutSave.Symbol = "";
            this.ButWithoutSave.SymbolSize = 12F;
            this.ButWithoutSave.TabIndex = 13;
            this.ButWithoutSave.Text = "خــــروج";
            this.ButWithoutSave.TextColor = System.Drawing.Color.Black;
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
            this.ButWithSave.Symbol = "";
            this.ButWithSave.SymbolSize = 12F;
            this.ButWithSave.TabIndex = 12;
            this.ButWithSave.Text = "حفــــظ";
            this.ButWithSave.TextColor = System.Drawing.Color.White;
            this.ButWithSave.Click += new System.EventHandler(this.ButWithSave_Click);
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
            this.txtLeftM.Location = new System.Drawing.Point(20, 21);
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
            this.txtTopM.Location = new System.Drawing.Point(153, 21);
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
            this.CmbPrinter.Location = new System.Drawing.Point(296, 21);
            this.CmbPrinter.Name = "CmbPrinter";
            this.CmbPrinter.Size = new System.Drawing.Size(202, 20);
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
            this.txtBarWidth.Location = new System.Drawing.Point(430, 51);
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
            this.txtBarHeigth.Location = new System.Drawing.Point(291, 51);
            this.txtBarHeigth.MinValue = 0;
            this.txtBarHeigth.Name = "txtBarHeigth";
            this.txtBarHeigth.ShowUpDown = true;
            this.txtBarHeigth.Size = new System.Drawing.Size(68, 21);
            this.txtBarHeigth.TabIndex = 5;
            this.txtBarHeigth.Value = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label9.Location = new System.Drawing.Point(265, 21);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(97, 13);
            this.label9.TabIndex = 990;
            this.label9.Text = "عدد الكروت عرضيا :";
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
            this.labelX1.Size = new System.Drawing.Size(600, 30);
            this.labelX1.TabIndex = 991;
            this.labelX1.Text = "إعدادات طباعة الباركود";
            this.labelX1.TextAlignment = System.Drawing.StringAlignment.Center;
            this.labelX1.Click += new System.EventHandler(this.labelX1_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(143, 88);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(127, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "الإرتفاع بين كروت الباركود :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(367, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "الإرتفـــاع :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(498, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "العـــرض :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(401, 88);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(156, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "البعد العرضي بين كروت الباركود :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(498, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "اختيار الطابعة :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(201, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "هامش اعلى :";
            // 
            // checkBox_previewPrint
            // 
            this.checkBox_previewPrint.AutoSize = true;
            this.checkBox_previewPrint.BackColor = System.Drawing.Color.Transparent;
            this.checkBox_previewPrint.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.checkBox_previewPrint.ForeColor = System.Drawing.Color.Blue;
            this.checkBox_previewPrint.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.checkBox_previewPrint.Location = new System.Drawing.Point(402, 36);
            this.checkBox_previewPrint.Name = "checkBox_previewPrint";
            this.checkBox_previewPrint.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBox_previewPrint.Size = new System.Drawing.Size(177, 17);
            this.checkBox_previewPrint.TabIndex = 1021;
            this.checkBox_previewPrint.Text = "تعيين إعدادات الطابعة الإفتراضية ";
            this.checkBox_previewPrint.UseVisualStyleBackColor = false;
            this.checkBox_previewPrint.CheckedChanged += new System.EventHandler(this.checkBox_previewPrint_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.checkBox_Collate);
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
            this.groupBox1.Location = new System.Drawing.Point(3, 37);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(585, 110);
            this.groupBox1.TabIndex = 983;
            this.groupBox1.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label10.Location = new System.Drawing.Point(68, 25);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(70, 13);
            this.label10.TabIndex = 6;
            this.label10.Text = "هامش يسار :";
            // 
            // ribbonBar1
            // 
            this.ribbonBar1.AutoOverflowEnabled = true;
            this.ribbonBar1.BackColor = System.Drawing.Color.Silver;
            // 
            // 
            // 
            this.ribbonBar1.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar1.ContainerControlProcessDialogKey = true;
            this.ribbonBar1.Controls.Add(this.checkBox_previewPrint);
            this.ribbonBar1.Controls.Add(this.groupBox1);
            this.ribbonBar1.Controls.Add(this.groupBox3);
            this.ribbonBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonBar1.Tag= "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.ribbonBar1.Location = new System.Drawing.Point(0, 0);
            this.ribbonBar1.Name = "ribbonBar1";
            this.ribbonBar1.Size = new System.Drawing.Size(600, 441);
            this.ribbonBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this.ribbonBar1.TabIndex = 989;
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
            this.ribbonBar1.ItemClick += new System.EventHandler(this.ribbonBar1_ItemClick);
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
            this.groupBox3.Location = new System.Drawing.Point(7, 144);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(581, 45);
            this.groupBox3.TabIndex = 990;
            this.groupBox3.TabStop = false;
            // 
            // CmbPrintP2
            // 
            this.CmbPrintP2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbPrintP2.FormattingEnabled = true;
            this.CmbPrintP2.Location = new System.Drawing.Point(69, 453);
            this.CmbPrintP2.Name = "CmbPrintP2";
            this.CmbPrintP2.Size = new System.Drawing.Size(140, 21);
            this.CmbPrintP2.TabIndex = 987;
            // 
            // button1
            // 
            this.button1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button1.Location = new System.Drawing.Point(547, 351);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 25);
            this.button1.TabIndex = 988;
            this.button1.Text = "شكل توضيح";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // CmbPrintP
            // 
            this.CmbPrintP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbPrintP.FormattingEnabled = true;
            this.CmbPrintP.Location = new System.Drawing.Point(234, 451);
            this.CmbPrintP.Name = "CmbPrintP";
            this.CmbPrintP.Size = new System.Drawing.Size(140, 21);
            this.CmbPrintP.TabIndex = 986;
            // 
            // CmbDir
            // 
            this.CmbDir.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbDir.FormattingEnabled = true;
            this.CmbDir.Location = new System.Drawing.Point(385, 453);
            this.CmbDir.Name = "CmbDir";
            this.CmbDir.Size = new System.Drawing.Size(140, 21);
            this.CmbDir.TabIndex = 985;
            // 
            // BarcodControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.ribbonBar1);
            this.Controls.Add(this.CmbPrintP2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.CmbPrintP);
            this.Controls.Add(this.CmbDir);
            this.Name = "BarcodControl";
            this.Size = new System.Drawing.Size(600, 441);
            this.Load += new System.EventHandler(this.BarcodControl_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BarcodControl_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.BarcodControl_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.txtpageCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumRows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumCols)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtLeftM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTopM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBarWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBarHeigth)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ribbonBar1.ResumeLayout(false);
            this.ribbonBar1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
         //   this.Icon = ((System.Drawing.Icon)(InvAcc.Properties.Resources.favicon));
this.ResumeLayout(false);
        }
        #endregion
        private DevComponents.Editors.IntegerInput txtpageCount;
        private System.Windows.Forms.Label label33;
        private DevComponents.Editors.DoubleInput txtNumRows;
        private DevComponents.Editors.DoubleInput txtNumCols;
        private System.Windows.Forms.CheckBox checkBox_Collate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox2;
        private DevComponents.DotNetBar.ButtonX ButWithoutSave;
        private DevComponents.DotNetBar.ButtonX ButWithSave;
        private DevComponents.Editors.DoubleInput txtLeftM;
        private DevComponents.Editors.DoubleInput txtTopM;
        private DevComponents.DotNetBar.Controls.ComboBoxEx CmbPrinter;
        private DevComponents.Editors.DoubleInput txtWidth;
        private DevComponents.Editors.DoubleInput txtHeight;
        private DevComponents.Editors.IntegerInput txtBarWidth;
        private DevComponents.Editors.IntegerInput txtBarHeigth;
        private System.Windows.Forms.Label label9;
        private DevComponents.DotNetBar.LabelX labelX1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBox_previewPrint;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label10;
        private DevComponents.DotNetBar.RibbonBar ribbonBar1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox CmbPrintP2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox CmbPrintP;
        private System.Windows.Forms.ComboBox CmbDir;
    }
}
