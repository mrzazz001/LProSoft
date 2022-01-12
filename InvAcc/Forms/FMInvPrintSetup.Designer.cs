   

namespace InvAcc.Forms
{
partial class FMInvPrintSetup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FMInvPrintSetup));
            this.PanelSpecialContainer = new System.Windows.Forms.Panel();
            this.ribbonBar1 = new DevComponents.DotNetBar.RibbonBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBox_WaiterAll = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chk_Stoped = new DevComponents.DotNetBar.Controls.SwitchButton();
            this.groupBox_PrintType = new System.Windows.Forms.GroupBox();
            this.RedButCasher = new System.Windows.Forms.RadioButton();
            this.RedButPaperA4 = new System.Windows.Forms.RadioButton();
            this.checkBox_previewPrint = new System.Windows.Forms.CheckBox();
            this.CmbInvType = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox_CachierTxtA = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBox_CachierTxtE = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.RButLandscape = new System.Windows.Forms.RadioButton();
            this.RButPortrait = new System.Windows.Forms.RadioButton();
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
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.label8 = new System.Windows.Forms.Label();
            this.ChkPTable = new System.Windows.Forms.CheckBox();
            this.picture_SSS = new System.Windows.Forms.PictureBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ButWithoutSave = new DevComponents.DotNetBar.ButtonX();
            this.ButWithSave = new DevComponents.DotNetBar.ButtonX();
            this.netResize1 = new Softgroup.NetResize.NetResize(this.components);
            this.PanelSpecialContainer.SuspendLayout();
            this.ribbonBar1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox_PrintType.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtpageCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDistance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLinePage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTopM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBottM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLeftM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_SSS)).BeginInit();
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
            this.PanelSpecialContainer.Size = new System.Drawing.Size(466, 407);
            this.PanelSpecialContainer.TabIndex = 1220;
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
            this.ribbonBar1.Controls.Add(this.panel1);
            this.ribbonBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonBar1.DragDropSupport = true;
            this.ribbonBar1.Location = new System.Drawing.Point(0, 0);
            this.ribbonBar1.Name = "ribbonBar1";
            this.ribbonBar1.Size = new System.Drawing.Size(466, 407);
            this.ribbonBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this.ribbonBar1.TabIndex = 870;
            this.ribbonBar1.Tag = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.ribbonBar1.ThemeAware = true;
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
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.checkBox_WaiterAll);
            this.panel1.Controls.Add(this.chk_Stoped);
            this.panel1.Controls.Add(this.groupBox_PrintType);
            this.panel1.Controls.Add(this.checkBox_previewPrint);
            this.panel1.Controls.Add(this.CmbInvType);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.labelX1);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.ChkPTable);
            this.panel1.Controls.Add(this.picture_SSS);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(466, 390);
            this.panel1.TabIndex = 858;
            // 
            // checkBox_WaiterAll
            // 
            this.checkBox_WaiterAll.BackColor = System.Drawing.Color.WhiteSmoke;
            // 
            // 
            // 
            this.checkBox_WaiterAll.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.checkBox_WaiterAll.BackgroundStyle.BorderBottomWidth = 1;
            this.checkBox_WaiterAll.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarCaptionInactiveText;
            this.checkBox_WaiterAll.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.checkBox_WaiterAll.BackgroundStyle.BorderLeftWidth = 1;
            this.checkBox_WaiterAll.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.checkBox_WaiterAll.BackgroundStyle.BorderRightWidth = 1;
            this.checkBox_WaiterAll.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.checkBox_WaiterAll.BackgroundStyle.BorderTopWidth = 1;
            this.checkBox_WaiterAll.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBox_WaiterAll.CheckBoxPosition = DevComponents.DotNetBar.eCheckBoxPosition.Top;
            this.checkBox_WaiterAll.Location = new System.Drawing.Point(224, 60);
            this.checkBox_WaiterAll.Name = "checkBox_WaiterAll";
            this.checkBox_WaiterAll.Size = new System.Drawing.Size(26, 53);
            this.checkBox_WaiterAll.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBox_WaiterAll.TabIndex = 1022;
            this.checkBox_WaiterAll.Text = "الكل";
            this.checkBox_WaiterAll.Visible = false;
            this.checkBox_WaiterAll.CheckedChanged += new System.EventHandler(this.checkBox_WaiterAll_CheckedChanged);
            // 
            // chk_Stoped
            // 
            // 
            // 
            // 
            this.chk_Stoped.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chk_Stoped.Location = new System.Drawing.Point(252, 87);
            this.chk_Stoped.Name = "chk_Stoped";
            this.chk_Stoped.OffBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(80)))), ((int)(((byte)(77)))));
            this.chk_Stoped.OffText = "إيقاف الطباعة";
            this.chk_Stoped.OffTextColor = System.Drawing.Color.White;
            this.chk_Stoped.OnText = "إيقاف الطباعة";
            this.chk_Stoped.Size = new System.Drawing.Size(198, 26);
            this.chk_Stoped.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chk_Stoped.SwitchWidth = 40;
            this.chk_Stoped.TabIndex = 1021;
            this.chk_Stoped.Visible = false;
            // 
            // groupBox_PrintType
            // 
            this.groupBox_PrintType.Controls.Add(this.RedButCasher);
            this.groupBox_PrintType.Controls.Add(this.RedButPaperA4);
            this.groupBox_PrintType.Location = new System.Drawing.Point(14, 39);
            this.groupBox_PrintType.Name = "groupBox_PrintType";
            this.groupBox_PrintType.Size = new System.Drawing.Size(208, 88);
            this.groupBox_PrintType.TabIndex = 89;
            this.groupBox_PrintType.TabStop = false;
            this.groupBox_PrintType.Text = "طريقة الطباعة";
            // 
            // RedButCasher
            // 
            this.RedButCasher.AutoSize = true;
            this.RedButCasher.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.RedButCasher.Location = new System.Drawing.Point(34, 56);
            this.RedButCasher.Name = "RedButCasher";
            this.RedButCasher.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RedButCasher.Size = new System.Drawing.Size(137, 17);
            this.RedButCasher.TabIndex = 14;
            this.RedButCasher.Text = "طباعة على ورق الكاشير";
            this.RedButCasher.UseVisualStyleBackColor = true;
            this.RedButCasher.CheckedChanged += new System.EventHandler(this.RedButCasher_CheckedChanged);
            this.RedButCasher.Click += new System.EventHandler(this.RedButCasher_Click);
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
            this.RedButPaperA4.TabIndex = 13;
            this.RedButPaperA4.TabStop = true;
            this.RedButPaperA4.Text = "طباعة على ورق A4";
            this.RedButPaperA4.UseVisualStyleBackColor = true;
            this.RedButPaperA4.CheckedChanged += new System.EventHandler(this.RedButPaperA4_CheckedChanged);
            this.RedButPaperA4.Click += new System.EventHandler(this.RedButPaperA4_Click);
            // 
            // checkBox_previewPrint
            // 
            this.checkBox_previewPrint.AutoSize = true;
            this.checkBox_previewPrint.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.checkBox_previewPrint.ForeColor = System.Drawing.Color.Blue;
            this.checkBox_previewPrint.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.checkBox_previewPrint.Location = new System.Drawing.Point(259, 120);
            this.checkBox_previewPrint.Name = "checkBox_previewPrint";
            this.checkBox_previewPrint.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBox_previewPrint.Size = new System.Drawing.Size(177, 17);
            this.checkBox_previewPrint.TabIndex = 1019;
            this.checkBox_previewPrint.Text = "تعيين إعدادات الطابعة الإفتراضية ";
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
            this.CmbInvType.ItemHeight = 15;
            this.CmbInvType.Location = new System.Drawing.Point(252, 60);
            this.CmbInvType.Name = "CmbInvType";
            this.CmbInvType.Size = new System.Drawing.Size(198, 21);
            this.CmbInvType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.CmbInvType.TabIndex = 1;
            this.CmbInvType.SelectedIndexChanged += new System.EventHandler(this.CmbInvType_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.textBox_CachierTxtA);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.textBox_CachierTxtE);
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
            this.groupBox1.Location = new System.Drawing.Point(15, 131);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(435, 255);
            this.groupBox1.TabIndex = 90;
            this.groupBox1.TabStop = false;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(140, 1);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(95, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "تحميل الاعدادات";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // textBox_CachierTxtA
            // 
            this.textBox_CachierTxtA.AutoSelectAll = true;
            this.textBox_CachierTxtA.BackColor = System.Drawing.Color.AliceBlue;
            // 
            // 
            // 
            this.textBox_CachierTxtA.Border.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.textBox_CachierTxtA.Border.BorderBottomWidth = 1;
            this.textBox_CachierTxtA.Border.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.textBox_CachierTxtA.Border.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.textBox_CachierTxtA.Border.BorderLeftWidth = 1;
            this.textBox_CachierTxtA.Border.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.textBox_CachierTxtA.Border.BorderRightWidth = 1;
            this.textBox_CachierTxtA.Border.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.textBox_CachierTxtA.Border.BorderTopWidth = 1;
            this.textBox_CachierTxtA.Border.Class = "TextBoxBorder";
            this.textBox_CachierTxtA.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBox_CachierTxtA.ButtonCustom.Checked = true;
            this.textBox_CachierTxtA.ButtonCustom.Visible = true;
            this.textBox_CachierTxtA.Location = new System.Drawing.Point(173, 176);
            this.textBox_CachierTxtA.Multiline = true;
            this.textBox_CachierTxtA.Name = "textBox_CachierTxtA";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_CachierTxtA, false);
            this.textBox_CachierTxtA.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_CachierTxtA.Size = new System.Drawing.Size(249, 36);
            this.textBox_CachierTxtA.TabIndex = 1021;
            this.textBox_CachierTxtA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_CachierTxtA.WatermarkImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.textBox_CachierTxtA.WatermarkText = "ذيل فاتورة الكاشيير";
            this.textBox_CachierTxtA.ButtonCustomClick += new System.EventHandler(this.textBox_CachierTxtA_ButtonCustomClick);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(0, 3);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(134, 21);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // textBox_CachierTxtE
            // 
            this.textBox_CachierTxtE.AutoSelectAll = true;
            // 
            // 
            // 
            this.textBox_CachierTxtE.Border.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.textBox_CachierTxtE.Border.BorderBottomWidth = 1;
            this.textBox_CachierTxtE.Border.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.textBox_CachierTxtE.Border.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.textBox_CachierTxtE.Border.BorderLeftWidth = 1;
            this.textBox_CachierTxtE.Border.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.textBox_CachierTxtE.Border.BorderRightWidth = 1;
            this.textBox_CachierTxtE.Border.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.textBox_CachierTxtE.Border.BorderTopWidth = 1;
            this.textBox_CachierTxtE.Border.Class = "TextBoxBorder";
            this.textBox_CachierTxtE.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBox_CachierTxtE.ButtonCustom.Checked = true;
            this.textBox_CachierTxtE.ButtonCustom.Visible = true;
            this.textBox_CachierTxtE.Location = new System.Drawing.Point(173, 214);
            this.textBox_CachierTxtE.Multiline = true;
            this.textBox_CachierTxtE.Name = "textBox_CachierTxtE";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_CachierTxtE, false);
            this.textBox_CachierTxtE.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_CachierTxtE.Size = new System.Drawing.Size(249, 36);
            this.textBox_CachierTxtE.TabIndex = 1020;
            this.textBox_CachierTxtE.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_CachierTxtE.WatermarkImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.textBox_CachierTxtE.WatermarkText = "Tail cashier bill";
            this.textBox_CachierTxtE.ButtonCustomClick += new System.EventHandler(this.textBox_CachierTxtE_ButtonCustomClick);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.RButLandscape);
            this.groupBox4.Controls.Add(this.RButPortrait);
            this.groupBox4.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.groupBox4.Location = new System.Drawing.Point(21, 124);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(144, 125);
            this.groupBox4.TabIndex = 1013;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "الإتجـــــاه";
            // 
            // RButLandscape
            // 
            this.RButLandscape.AutoSize = true;
            this.RButLandscape.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.RButLandscape.ForeColor = System.Drawing.Color.SteelBlue;
            this.RButLandscape.Image = ((System.Drawing.Image)(resources.GetObject("RButLandscape.Image")));
            this.RButLandscape.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.RButLandscape.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.RButLandscape.Location = new System.Drawing.Point(11, 76);
            this.RButLandscape.Name = "RButLandscape";
            this.RButLandscape.Size = new System.Drawing.Size(118, 40);
            this.RButLandscape.TabIndex = 1008;
            this.RButLandscape.Text = "عرضي                   ";
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
            this.RButPortrait.Location = new System.Drawing.Point(12, 29);
            this.RButPortrait.Name = "RButPortrait";
            this.RButPortrait.Size = new System.Drawing.Size(117, 40);
            this.RButPortrait.TabIndex = 1007;
            this.RButPortrait.TabStop = true;
            this.RButPortrait.Text = "طولي                    ";
            this.RButPortrait.UseVisualStyleBackColor = true;
            // 
            // CmbPaperSize
            // 
            this.CmbPaperSize.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbPaperSize.DisplayMember = "Text";
            this.CmbPaperSize.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.CmbPaperSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbPaperSize.FormattingEnabled = true;
            this.CmbPaperSize.ItemHeight = 15;
            this.CmbPaperSize.Location = new System.Drawing.Point(173, 152);
            this.CmbPaperSize.Name = "CmbPaperSize";
            this.CmbPaperSize.Size = new System.Drawing.Size(152, 21);
            this.CmbPaperSize.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.CmbPaperSize.TabIndex = 1011;
            this.CmbPaperSize.MouseClick += new System.Windows.Forms.MouseEventHandler(this.CmbPaperSize_MouseClick);
            // 
            // label9
            // 
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label9.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label9.Location = new System.Drawing.Point(329, 152);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(92, 21);
            this.label9.TabIndex = 1012;
            this.label9.Text = "حجم الورقة :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.txtpageCount.Location = new System.Drawing.Point(237, 128);
            this.txtpageCount.MinValue = 1;
            this.txtpageCount.Name = "txtpageCount";
            this.txtpageCount.ShowUpDown = true;
            this.txtpageCount.Size = new System.Drawing.Size(68, 21);
            this.txtpageCount.TabIndex = 1001;
            this.txtpageCount.Value = 1;
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label33.ForeColor = System.Drawing.Color.Blue;
            this.label33.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label33.Location = new System.Drawing.Point(308, 132);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(69, 13);
            this.label33.TabIndex = 1000;
            this.label33.Text = "عدد النسخ :";
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
            this.txtDistance.Location = new System.Drawing.Point(21, 104);
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
            this.txtLinePage.Location = new System.Drawing.Point(236, 104);
            this.txtLinePage.LockUpdateChecked = false;
            this.txtLinePage.MinValue = 0;
            this.txtLinePage.Name = "txtLinePage";
            this.txtLinePage.ShowCheckBox = true;
            this.txtLinePage.ShowUpDown = true;
            this.txtLinePage.Size = new System.Drawing.Size(68, 21);
            this.txtLinePage.TabIndex = 9;
            this.txtLinePage.ValueChanged += new System.EventHandler(this.txtLinePage_ValueChanged);
            this.txtLinePage.LockUpdateChanged += new System.EventHandler(this.txtLinePage_LockUpdateChanged);
            // 
            // CmbPrinter
            // 
            this.CmbPrinter.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbPrinter.DisplayMember = "Text";
            this.CmbPrinter.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.CmbPrinter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbPrinter.FormattingEnabled = true;
            this.CmbPrinter.ItemHeight = 15;
            this.CmbPrinter.Location = new System.Drawing.Point(21, 26);
            this.CmbPrinter.Name = "CmbPrinter";
            this.CmbPrinter.Size = new System.Drawing.Size(283, 21);
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
            this.txtTopM.Location = new System.Drawing.Point(236, 58);
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
            this.txtBottM.Location = new System.Drawing.Point(236, 81);
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
            this.txtRight.Location = new System.Drawing.Point(21, 81);
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
            this.txtLeftM.Location = new System.Drawing.Point(21, 58);
            this.txtLeftM.Name = "txtLeftM";
            this.txtLeftM.ShowUpDown = true;
            this.txtLeftM.Size = new System.Drawing.Size(68, 20);
            this.txtLeftM.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(95, 108);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "المسافة بين السطور :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(95, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "الهامش الأيسر :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(308, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "الهامش الأسفل :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(95, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "الهامش الأيمن :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(308, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "الهامش الأعلى :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(308, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "السطور في الصفحة :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(308, 30);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 13);
            this.label7.TabIndex = 48;
            this.label7.Text = "الطابعة الإفتراضية :";
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
            this.labelX1.Size = new System.Drawing.Size(464, 26);
            this.labelX1.TabIndex = 88;
            this.labelX1.Text = "اعدادات طباعة الفواتير";
            this.labelX1.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(389, 40);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 13);
            this.label8.TabIndex = 41;
            this.label8.Text = " نوع الفاتورة:";
            // 
            // ChkPTable
            // 
            this.ChkPTable.AutoSize = true;
            this.ChkPTable.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.ChkPTable.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ChkPTable.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ChkPTable.Location = new System.Drawing.Point(249, 95);
            this.ChkPTable.Name = "ChkPTable";
            this.ChkPTable.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ChkPTable.Size = new System.Drawing.Size(201, 17);
            this.ChkPTable.TabIndex = 2;
            this.ChkPTable.Text = "طباعة الفاتورة بالشكل الإفتراضي";
            this.ChkPTable.UseVisualStyleBackColor = true;
            this.ChkPTable.CheckedChanged += new System.EventHandler(this.ChkPTable_CheckedChanged);
            // 
            // picture_SSS
            // 
            this.picture_SSS.BackColor = System.Drawing.Color.Transparent;
            this.picture_SSS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picture_SSS.Image = global::InvAcc.Properties.Resources.Untitled_2_copy;
            this.picture_SSS.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.picture_SSS.Location = new System.Drawing.Point(14, 43);
            this.picture_SSS.Name = "picture_SSS";
            this.picture_SSS.Size = new System.Drawing.Size(208, 84);
            this.picture_SSS.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picture_SSS.TabIndex = 1020;
            this.picture_SSS.TabStop = false;
            this.picture_SSS.Visible = false;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Gainsboro;
            this.groupBox3.Controls.Add(this.ButWithoutSave);
            this.groupBox3.Controls.Add(this.ButWithSave);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox3.Location = new System.Drawing.Point(0, 407);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(466, 54);
            this.groupBox3.TabIndex = 984;
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
            this.netResize1.LabelsAutoEllipse = false;
            this.netResize1.ParentControl = this;
            this.netResize1.AfterControlResize += new Softgroup.NetResize.NetResize.AfterControlResizeEventHandler(this.netResize1_AfterControlResize);
            // 
            // FMInvPrintSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 461);
            this.Controls.Add(this.PanelSpecialContainer);
            this.Controls.Add(this.groupBox3);
            this.Icon = global::InvAcc.Properties.Resources.favicon;
            this.KeyPreview = true;
            this.MinimizeBox = false;
            this.Name = "FMInvPrintSetup";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FMInvPrintSetup_FormClosing);
            this.Load += new System.EventHandler(this.FMInvPrintSetup_Load);
            this.Shown += new System.EventHandler(this.FrmInvSale_Shown);
            this.SizeChanged += new System.EventHandler(this.FrmInvSale_SizeChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Frm_KeyPress);
            this.PanelSpecialContainer.ResumeLayout(false);
            this.ribbonBar1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox_PrintType.ResumeLayout(false);
            this.groupBox_PrintType.PerformLayout();
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
            ((System.ComponentModel.ISupportInitialize)(this.picture_SSS)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).EndInit();
            this.ResumeLayout(false);

        }//###########&&&&&&&&&&

        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}
