   

namespace InvAcc.Forms
{
partial class FMSndPrintSetup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FMSndPrintSetup));
            this.PanelSpecialContainer = new System.Windows.Forms.Panel();
            this.ribbonBar1 = new DevComponents.DotNetBar.RibbonBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBox_previewPrint3 = new System.Windows.Forms.CheckBox();
            this.CmbInvType3 = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.groupBox13 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.RButLandscape3 = new System.Windows.Forms.RadioButton();
            this.RButPortrait3 = new System.Windows.Forms.RadioButton();
            this.CmbPaperSize3 = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label9 = new System.Windows.Forms.Label();
            this.txtpageCount3 = new DevComponents.Editors.IntegerInput();
            this.label33 = new System.Windows.Forms.Label();
            this.txtDistance = new DevComponents.Editors.DoubleInput();
            this.txtLinePage3 = new DevComponents.Editors.IntegerInput();
            this.CmbPrinter3 = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.txtTopM3 = new DevComponents.Editors.DoubleInput();
            this.txtBottM3 = new DevComponents.Editors.DoubleInput();
            this.txtRight3 = new DevComponents.Editors.DoubleInput();
            this.txtLeftM3 = new DevComponents.Editors.DoubleInput();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.label8 = new System.Windows.Forms.Label();
            this.ChkPTable3 = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.RedButCasher = new System.Windows.Forms.RadioButton();
            this.RedButPaperA4 = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ButWithoutSave = new DevComponents.DotNetBar.ButtonX();
            this.ButWithSave = new DevComponents.DotNetBar.ButtonX();
            this.netResize1 = new Softgroup.NetResize.NetResize(this.components);
            this.PanelSpecialContainer.SuspendLayout();
            this.ribbonBar1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox13.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtpageCount3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDistance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLinePage3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTopM3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBottM3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRight3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLeftM3)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelSpecialContainer
            // 
            this.PanelSpecialContainer.Controls.Add(this.ribbonBar1);
            this.PanelSpecialContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelSpecialContainer.Location = new System.Drawing.Point(0, 0);
            this.PanelSpecialContainer.Name = "PanelSpecialContainer";
            this.PanelSpecialContainer.Size = new System.Drawing.Size(916, 411);
            this.PanelSpecialContainer.TabIndex = 1220;
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
            this.ribbonBar1.BackgroundStyle.BackColor = System.Drawing.Color.Gainsboro;
            this.ribbonBar1.BackgroundStyle.BackColor2 = System.Drawing.Color.Gainsboro;
            this.ribbonBar1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar1.ContainerControlProcessDialogKey = true;
            this.ribbonBar1.Controls.Add(this.panel1);
            this.ribbonBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonBar1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.ribbonBar1.Location = new System.Drawing.Point(0, 0);
            this.ribbonBar1.Name = "ribbonBar1";
            this.ribbonBar1.Size = new System.Drawing.Size(916, 411);
            this.ribbonBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this.ribbonBar1.TabIndex = 871;
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
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.checkBox_previewPrint3);
            this.panel1.Controls.Add(this.CmbInvType3);
            this.panel1.Controls.Add(this.groupBox13);
            this.panel1.Controls.Add(this.labelX1);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.ChkPTable3);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(916, 394);
            this.panel1.TabIndex = 858;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // checkBox_previewPrint3
            // 
            this.checkBox_previewPrint3.AutoSize = true;
            this.checkBox_previewPrint3.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.checkBox_previewPrint3.ForeColor = System.Drawing.Color.Blue;
            this.checkBox_previewPrint3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.checkBox_previewPrint3.Location = new System.Drawing.Point(263, 126);
            this.checkBox_previewPrint3.Name = "checkBox_previewPrint3";
            this.checkBox_previewPrint3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBox_previewPrint3.Size = new System.Drawing.Size(177, 17);
            this.checkBox_previewPrint3.TabIndex = 1020;
            this.checkBox_previewPrint3.Text = "تعيين إعدادات الطابعة الإفتراضية ";
            this.checkBox_previewPrint3.UseVisualStyleBackColor = true;
            this.checkBox_previewPrint3.CheckedChanged += new System.EventHandler(this.checkBox_previewPrint_CheckedChanged);
            // 
            // CmbInvType3
            // 
            this.CmbInvType3.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbInvType3.DisplayMember = "Text";
            this.CmbInvType3.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.CmbInvType3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbInvType3.FormattingEnabled = true;
            this.CmbInvType3.ItemHeight = 14;
            this.CmbInvType3.Location = new System.Drawing.Point(151, 55);
            this.CmbInvType3.Name = "CmbInvType3";
            this.CmbInvType3.Size = new System.Drawing.Size(198, 20);
            this.CmbInvType3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.CmbInvType3.TabIndex = 1;
            this.CmbInvType3.SelectedIndexChanged += new System.EventHandler(this.CmbInvType_SelectedIndexChanged);
            // 
            // groupBox13
            // 
            this.groupBox13.BackColor = System.Drawing.Color.Transparent;
            this.groupBox13.Controls.Add(this.groupBox4);
            this.groupBox13.Controls.Add(this.CmbPaperSize3);
            this.groupBox13.Controls.Add(this.label9);
            this.groupBox13.Controls.Add(this.txtpageCount3);
            this.groupBox13.Controls.Add(this.label33);
            this.groupBox13.Controls.Add(this.txtDistance);
            this.groupBox13.Controls.Add(this.txtLinePage3);
            this.groupBox13.Controls.Add(this.CmbPrinter3);
            this.groupBox13.Controls.Add(this.txtTopM3);
            this.groupBox13.Controls.Add(this.txtBottM3);
            this.groupBox13.Controls.Add(this.txtRight3);
            this.groupBox13.Controls.Add(this.txtLeftM3);
            this.groupBox13.Controls.Add(this.label6);
            this.groupBox13.Controls.Add(this.label4);
            this.groupBox13.Controls.Add(this.label3);
            this.groupBox13.Controls.Add(this.label2);
            this.groupBox13.Controls.Add(this.label1);
            this.groupBox13.Controls.Add(this.label5);
            this.groupBox13.Controls.Add(this.label7);
            this.groupBox13.Location = new System.Drawing.Point(15, 127);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Size = new System.Drawing.Size(435, 256);
            this.groupBox13.TabIndex = 90;
            this.groupBox13.TabStop = false;
            this.groupBox13.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.RButLandscape3);
            this.groupBox4.Controls.Add(this.RButPortrait3);
            this.groupBox4.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.groupBox4.Location = new System.Drawing.Point(21, 114);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(144, 131);
            this.groupBox4.TabIndex = 1016;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "الإتجـــــاه";
            this.groupBox4.Enter += new System.EventHandler(this.groupBox4_Enter);
            // 
            // RButLandscape3
            // 
            this.RButLandscape3.AutoSize = true;
            this.RButLandscape3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.RButLandscape3.ForeColor = System.Drawing.Color.SteelBlue;
            this.RButLandscape3.Image = ((System.Drawing.Image)(resources.GetObject("RButLandscape3.Image")));
            this.RButLandscape3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.RButLandscape3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.RButLandscape3.Location = new System.Drawing.Point(12, 76);
            this.RButLandscape3.Name = "RButLandscape3";
            this.RButLandscape3.Size = new System.Drawing.Size(115, 40);
            this.RButLandscape3.TabIndex = 1008;
            this.RButLandscape3.Text = "عرضي                  ";
            this.RButLandscape3.UseVisualStyleBackColor = true;
            this.RButLandscape3.CheckedChanged += new System.EventHandler(this.RButLandscape3_CheckedChanged);
            // 
            // RButPortrait3
            // 
            this.RButPortrait3.AutoSize = true;
            this.RButPortrait3.Checked = true;
            this.RButPortrait3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.RButPortrait3.ForeColor = System.Drawing.Color.SteelBlue;
            this.RButPortrait3.Image = ((System.Drawing.Image)(resources.GetObject("RButPortrait3.Image")));
            this.RButPortrait3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.RButPortrait3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.RButPortrait3.Location = new System.Drawing.Point(12, 27);
            this.RButPortrait3.Name = "RButPortrait3";
            this.RButPortrait3.Size = new System.Drawing.Size(114, 40);
            this.RButPortrait3.TabIndex = 1007;
            this.RButPortrait3.TabStop = true;
            this.RButPortrait3.Text = "طولي                   ";
            this.RButPortrait3.UseVisualStyleBackColor = true;
            this.RButPortrait3.CheckedChanged += new System.EventHandler(this.RButPortrait3_CheckedChanged);
            // 
            // CmbPaperSize3
            // 
            this.CmbPaperSize3.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbPaperSize3.DisplayMember = "Text";
            this.CmbPaperSize3.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.CmbPaperSize3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbPaperSize3.FormattingEnabled = true;
            this.CmbPaperSize3.ItemHeight = 14;
            this.CmbPaperSize3.Location = new System.Drawing.Point(181, 195);
            this.CmbPaperSize3.Name = "CmbPaperSize3";
            this.CmbPaperSize3.Size = new System.Drawing.Size(223, 20);
            this.CmbPaperSize3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.CmbPaperSize3.TabIndex = 1014;
            this.CmbPaperSize3.SelectedIndexChanged += new System.EventHandler(this.CmbPaperSize3_SelectedIndexChanged);
            this.CmbPaperSize3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CmbPaperSize_MouseClick);
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
            this.label9.Text = "حجم الورقة :";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // txtpageCount3
            // 
            this.txtpageCount3.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtpageCount3.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(198)))));
            this.txtpageCount3.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtpageCount3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtpageCount3.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtpageCount3.DisplayFormat = "0";
            this.txtpageCount3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtpageCount3.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtpageCount3.Location = new System.Drawing.Point(236, 132);
            this.txtpageCount3.MinValue = 1;
            this.txtpageCount3.Name = "txtpageCount3";
            this.txtpageCount3.ShowUpDown = true;
            this.txtpageCount3.Size = new System.Drawing.Size(68, 21);
            this.txtpageCount3.TabIndex = 1003;
            this.txtpageCount3.Value = 1;
            this.txtpageCount3.ValueChanged += new System.EventHandler(this.txtpageCount3_ValueChanged);
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
            this.label33.Text = "عدد النسخ :";
            this.label33.Click += new System.EventHandler(this.label33_Click);
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
            this.txtDistance.ValueChanged += new System.EventHandler(this.txtDistance_ValueChanged);
            // 
            // txtLinePage3
            // 
            this.txtLinePage3.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtLinePage3.BackgroundStyle.BackColor = System.Drawing.Color.AliceBlue;
            this.txtLinePage3.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtLinePage3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtLinePage3.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtLinePage3.DisplayFormat = "0";
            this.txtLinePage3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtLinePage3.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtLinePage3.Location = new System.Drawing.Point(236, 108);
            this.txtLinePage3.LockUpdateChecked = false;
            this.txtLinePage3.MinValue = 0;
            this.txtLinePage3.Name = "txtLinePage3";
            this.txtLinePage3.ShowCheckBox = true;
            this.txtLinePage3.ShowUpDown = true;
            this.txtLinePage3.Size = new System.Drawing.Size(68, 21);
            this.txtLinePage3.TabIndex = 9;
            this.txtLinePage3.ValueChanged += new System.EventHandler(this.txtLinePage_ValueChanged);
            this.txtLinePage3.LockUpdateChanged += new System.EventHandler(this.txtLinePage_LockUpdateChanged);
            // 
            // CmbPrinter3
            // 
            this.CmbPrinter3.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbPrinter3.DisplayMember = "Text";
            this.CmbPrinter3.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.CmbPrinter3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbPrinter3.FormattingEnabled = true;
            this.CmbPrinter3.ItemHeight = 14;
            this.CmbPrinter3.Location = new System.Drawing.Point(21, 30);
            this.CmbPrinter3.Name = "CmbPrinter3";
            this.CmbPrinter3.Size = new System.Drawing.Size(252, 20);
            this.CmbPrinter3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.CmbPrinter3.TabIndex = 3;
            this.CmbPrinter3.SelectedIndexChanged += new System.EventHandler(this.CmbPrinter_SelectedIndexChanged);
            // 
            // txtTopM3
            // 
            this.txtTopM3.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtTopM3.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(198)))));
            this.txtTopM3.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtTopM3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtTopM3.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtTopM3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.txtTopM3.Increment = 1D;
            this.txtTopM3.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtTopM3.Location = new System.Drawing.Point(236, 62);
            this.txtTopM3.Name = "txtTopM3";
            this.txtTopM3.ShowUpDown = true;
            this.txtTopM3.Size = new System.Drawing.Size(68, 20);
            this.txtTopM3.TabIndex = 5;
            this.txtTopM3.ValueChanged += new System.EventHandler(this.txtTopM3_ValueChanged);
            // 
            // txtBottM3
            // 
            this.txtBottM3.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtBottM3.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(198)))));
            this.txtBottM3.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtBottM3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtBottM3.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtBottM3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.txtBottM3.Increment = 1D;
            this.txtBottM3.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtBottM3.Location = new System.Drawing.Point(236, 85);
            this.txtBottM3.Name = "txtBottM3";
            this.txtBottM3.ShowUpDown = true;
            this.txtBottM3.Size = new System.Drawing.Size(68, 20);
            this.txtBottM3.TabIndex = 7;
            this.txtBottM3.ValueChanged += new System.EventHandler(this.txtBottM3_ValueChanged);
            // 
            // txtRight3
            // 
            this.txtRight3.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtRight3.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(198)))));
            this.txtRight3.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtRight3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtRight3.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtRight3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.txtRight3.Increment = 1D;
            this.txtRight3.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtRight3.Location = new System.Drawing.Point(21, 62);
            this.txtRight3.Name = "txtRight3";
            this.txtRight3.ShowUpDown = true;
            this.txtRight3.Size = new System.Drawing.Size(68, 20);
            this.txtRight3.TabIndex = 6;
            this.txtRight3.ValueChanged += new System.EventHandler(this.txtRight3_ValueChanged);
            // 
            // txtLeftM3
            // 
            this.txtLeftM3.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtLeftM3.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(198)))));
            this.txtLeftM3.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtLeftM3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtLeftM3.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtLeftM3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.txtLeftM3.Increment = 1D;
            this.txtLeftM3.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtLeftM3.Location = new System.Drawing.Point(21, 85);
            this.txtLeftM3.Name = "txtLeftM3";
            this.txtLeftM3.ShowUpDown = true;
            this.txtLeftM3.Size = new System.Drawing.Size(68, 20);
            this.txtLeftM3.TabIndex = 8;
            this.txtLeftM3.ValueChanged += new System.EventHandler(this.txtLeftM3_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(-149, 112);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "المسافة بين السطور :";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(95, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "الهامش الأيسر :";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(308, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "الهامش الأسفل :";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(95, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "الهامش الأيمن :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(308, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "الهامش الأعلى :";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(308, 112);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "السطور في الصفحة :";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(277, 34);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(145, 13);
            this.label7.TabIndex = 48;
            this.label7.Text = "تحديد طابعة افتراضية للفاتورة :";
            this.label7.Click += new System.EventHandler(this.label7_Click);
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
            this.labelX1.Size = new System.Drawing.Size(914, 26);
            this.labelX1.TabIndex = 88;
            this.labelX1.Text = "اعدادات طباعة السندات";
            this.labelX1.TextAlignment = System.Drawing.StringAlignment.Center;
            this.labelX1.Click += new System.EventHandler(this.labelX1_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(355, 58);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 13);
            this.label8.TabIndex = 41;
            this.label8.Text = " نوع الفاتورة:";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // ChkPTable3
            // 
            this.ChkPTable3.AutoSize = true;
            this.ChkPTable3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.ChkPTable3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ChkPTable3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ChkPTable3.Location = new System.Drawing.Point(83, 96);
            this.ChkPTable3.Name = "ChkPTable3";
            this.ChkPTable3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ChkPTable3.Size = new System.Drawing.Size(193, 17);
            this.ChkPTable3.TabIndex = 2;
            this.ChkPTable3.Text = "طباعة السند بالشكل الإفتراضي";
            this.ChkPTable3.UseVisualStyleBackColor = true;
            this.ChkPTable3.CheckedChanged += new System.EventHandler(this.ChkPTable_CheckedChanged);
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
            this.groupBox2.Text = "طريقة الطباعة";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
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
            this.RedButCasher.Text = "طباعة على ورق الكاشير";
            this.RedButCasher.UseVisualStyleBackColor = true;
            this.RedButCasher.CheckedChanged += new System.EventHandler(this.RedButCasher_CheckedChanged);
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
            this.RedButPaperA4.Text = "طباعة على ورق A4";
            this.RedButPaperA4.UseVisualStyleBackColor = true;
            this.RedButPaperA4.CheckedChanged += new System.EventHandler(this.RedButPaperA4_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Gainsboro;
            this.groupBox3.Controls.Add(this.ButWithoutSave);
            this.groupBox3.Controls.Add(this.ButWithSave);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox3.Location = new System.Drawing.Point(0, 411);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(916, 54);
            this.groupBox3.TabIndex = 985;
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
            this.ButWithoutSave.Symbol = "";
            this.ButWithoutSave.SymbolSize = 12F;
            this.ButWithoutSave.TabIndex = 12;
            this.ButWithoutSave.Text = "خــــروج";
            this.ButWithoutSave.TextColor = System.Drawing.Color.Black;
            this.ButWithoutSave.Click += new System.EventHandler(this.ButWithoutSave_Click);
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
            this.ButWithSave.Symbol = "";
            this.ButWithSave.SymbolSize = 12F;
            this.ButWithSave.TabIndex = 11;
            this.ButWithSave.Text = "حفــــظ";
            this.ButWithSave.TextColor = System.Drawing.Color.White;
            this.ButWithSave.Click += new System.EventHandler(this.ButWithSave_Click);
            // 
            // netResize1
            // 
            this.netResize1.AutoSaveLayout = true;
            this.netResize1.ParentControl = this;
            this.netResize1.AfterControlResize += new Softgroup.NetResize.NetResize.AfterControlResizeEventHandler(this.netResize1_AfterControlResize);
            // 
            // FMSndPrintSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(916, 465);
            this.Controls.Add(this.PanelSpecialContainer);
            this.Controls.Add(this.groupBox3);
            this.Icon = global::InvAcc.Properties.Resources.favicon;
            this.KeyPreview = true;
            this.Name = "FMSndPrintSetup";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FMSndPrintSetup_Load);
            this.Shown += new System.EventHandler(this.FrmInvSale_Shown);
            this.SizeChanged += new System.EventHandler(this.FrmInvSale_SizeChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Frm_KeyPress);
            this.PanelSpecialContainer.ResumeLayout(false);
            this.ribbonBar1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox13.ResumeLayout(false);
            this.groupBox13.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtpageCount3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDistance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLinePage3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTopM3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBottM3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRight3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLeftM3)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).EndInit();
            this.ResumeLayout(false);

        }//###########&&&&&&&&&&

}
}
