   

namespace InvAcc.Forms
{
partial class FrmUserPoint
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUserPoint));
            this.PanelSpecialContainer = new System.Windows.Forms.Panel();

            components = new System.ComponentModel.Container();

            this.label3 = new DevComponents.DotNetBar.LabelX();
            this.buttonX_Close = new DevComponents.DotNetBar.ButtonX();
            this.ribbonBar1 = new DevComponents.DotNetBar.RibbonBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.groupPanel4 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.txtDebit3_R = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtCredit3_R = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupPanel5 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.txtDebit1_R = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtCredit1_R = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupPanel6 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.txtDebit2_R = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtCredit2_R = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.groupPanel3 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.txtDebit3 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtCredit3 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.ChkGaid = new System.Windows.Forms.CheckBox();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.txtDebit1 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtCredit1 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelD1 = new System.Windows.Forms.Label();
            this.labelC1 = new System.Windows.Forms.Label();
            this.CmbUsers = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonX_OK = new DevComponents.DotNetBar.ButtonX();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.txtDebit2 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtCredit2 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.netResize1 = new Softgroup.NetResize.NetResize(this.components);
            this.netResize1.AfterControlResize += new Softgroup.NetResize.NetResize.AfterControlResizeEventHandler(this.netResize1_AfterControlResize);
            this.Shown += new System.EventHandler(this.FrmInvSale_Shown);
            this.SizeChanged += new System.EventHandler(this.FrmInvSale_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).BeginInit();

            this.ribbonBar1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupPanel4.SuspendLayout();
            this.groupPanel5.SuspendLayout();
            this.groupPanel6.SuspendLayout();
            this.groupPanel3.SuspendLayout();
            this.groupPanel1.SuspendLayout();
            this.groupPanel2.SuspendLayout();

            this.PanelSpecialContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelSpecialContainer.Location = new System.Drawing.Point(0, 0);
            this.PanelSpecialContainer.Name = "PanelSpecialContainer";
            this.PanelSpecialContainer.Size = new System.Drawing.Size(1278, 514);
            this.PanelSpecialContainer.TabIndex = 1220;
            this.Controls.Add(this.PanelSpecialContainer);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.DimGray;
            // 
            // 
            // 
            this.label3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8F, ((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(602, 28);
            this.label3.TabIndex = 88;
            this.label3.Text = "تعيين مستخدمين نقاط البيع";
            this.label3.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // buttonX_Close
            // 
            this.buttonX_Close.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX_Close.Checked = true;
            this.buttonX_Close.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX_Close.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.buttonX_Close.Location = new System.Drawing.Point(5, 373);
            this.buttonX_Close.Name = "buttonX_Close";
            this.buttonX_Close.Size = new System.Drawing.Size(176, 42);
            this.buttonX_Close.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX_Close.Symbol = "";
            this.buttonX_Close.TabIndex = 2;
            this.buttonX_Close.Text = "إغلاق";
            this.buttonX_Close.TextColor = System.Drawing.Color.SteelBlue;
            this.buttonX_Close.Click += new System.EventHandler(this.buttonX_Close_Click);
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
            this.ribbonBar1.Size = new System.Drawing.Size(609, 437);
            this.ribbonBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this.ribbonBar1.TabIndex = 869;
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
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.groupPanel4);
            this.panel1.Controls.Add(this.groupPanel5);
            this.panel1.Controls.Add(this.groupPanel6);
            this.panel1.Controls.Add(this.groupPanel3);
            this.panel1.Controls.Add(this.ChkGaid);
            this.panel1.Controls.Add(this.groupPanel1);
            this.panel1.Controls.Add(this.CmbUsers);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.buttonX_Close);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.buttonX_OK);
            this.panel1.Controls.Add(this.groupPanel2);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Location = new System.Drawing.Point(3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(604, 417);
            this.panel1.TabIndex = 857;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label13.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label13.ForeColor = System.Drawing.Color.SteelBlue;
            this.label13.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label13.Location = new System.Drawing.Point(304, 97);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(295, 21);
            this.label13.TabIndex = 97;
            this.label13.Text = "حسابات فاتورة المبيعات";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupPanel4
            // 
            this.groupPanel4.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel4.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel4.Controls.Add(this.txtDebit3_R);
            this.groupPanel4.Controls.Add(this.txtCredit3_R);
            this.groupPanel4.Controls.Add(this.label7);
            this.groupPanel4.Controls.Add(this.label8);
            this.groupPanel4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.groupPanel4.Location = new System.Drawing.Point(4, 290);
            this.groupPanel4.Name = "groupPanel4";
            this.groupPanel4.Size = new System.Drawing.Size(295, 78);
            // 
            // 
            // 
            this.groupPanel4.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel4.Style.BackColorGradientAngle = 90;
            this.groupPanel4.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel4.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel4.Style.BorderBottomWidth = 1;
            this.groupPanel4.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel4.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel4.Style.BorderLeftWidth = 1;
            this.groupPanel4.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel4.Style.BorderRightWidth = 1;
            this.groupPanel4.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel4.Style.BorderTopWidth = 1;
            this.groupPanel4.Style.CornerDiameter = 4;
            this.groupPanel4.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel4.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Far;
            this.groupPanel4.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel4.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel4.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel4.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel4.TabIndex = 96;
            this.groupPanel4.Text = "حسابات القيد الآجــل";
            // 
            // txtDebit3_R
            // 
            this.txtDebit3_R.BackColor = System.Drawing.SystemColors.Control;
            // 
            // 
            // 
            this.txtDebit3_R.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDebit3_R.ButtonCustom.Visible = true;
            this.txtDebit3_R.Font = new System.Drawing.Font("Tahoma", 8F);
            this.txtDebit3_R.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtDebit3_R.Location = new System.Drawing.Point(4, 10);
            this.txtDebit3_R.Name = "txtDebit3_R";
            this.txtDebit3_R.ReadOnly = true;
            this.txtDebit3_R.Size = new System.Drawing.Size(194, 14);
            this.txtDebit3_R.TabIndex = 1118;
            this.txtDebit3_R.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDebit3_R.ButtonCustomClick += new System.EventHandler(this.txtDebit3_R_ButtonCustomClick);
            // 
            // txtCredit3_R
            // 
            this.txtCredit3_R.BackColor = System.Drawing.SystemColors.Control;
            // 
            // 
            // 
            this.txtCredit3_R.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtCredit3_R.ButtonCustom.Visible = true;
            this.txtCredit3_R.Font = new System.Drawing.Font("Tahoma", 8F);
            this.txtCredit3_R.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtCredit3_R.Location = new System.Drawing.Point(5, 31);
            this.txtCredit3_R.Name = "txtCredit3_R";
            this.txtCredit3_R.ReadOnly = true;
            this.txtCredit3_R.Size = new System.Drawing.Size(194, 14);
            this.txtCredit3_R.TabIndex = 1119;
            this.txtCredit3_R.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCredit3_R.ButtonCustomClick += new System.EventHandler(this.txtCredit3_R_ButtonCustomClick);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label7.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(199, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 13);
            this.label7.TabIndex = 1116;
            this.label7.Text = "الحساب المديـن :";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label8.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(199, 31);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 13);
            this.label8.TabIndex = 1117;
            this.label8.Text = "الحساب الدائـــن :";
            // 
            // groupPanel5
            // 
            this.groupPanel5.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel5.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel5.Controls.Add(this.txtDebit1_R);
            this.groupPanel5.Controls.Add(this.txtCredit1_R);
            this.groupPanel5.Controls.Add(this.label9);
            this.groupPanel5.Controls.Add(this.label10);
            this.groupPanel5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.groupPanel5.Location = new System.Drawing.Point(6, 124);
            this.groupPanel5.Name = "groupPanel5";
            this.groupPanel5.Size = new System.Drawing.Size(295, 78);
            // 
            // 
            // 
            this.groupPanel5.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel5.Style.BackColorGradientAngle = 90;
            this.groupPanel5.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel5.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel5.Style.BorderBottomWidth = 1;
            this.groupPanel5.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel5.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel5.Style.BorderLeftWidth = 1;
            this.groupPanel5.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel5.Style.BorderRightWidth = 1;
            this.groupPanel5.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel5.Style.BorderTopWidth = 1;
            this.groupPanel5.Style.CornerDiameter = 4;
            this.groupPanel5.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel5.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Far;
            this.groupPanel5.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel5.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel5.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel5.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel5.TabIndex = 94;
            this.groupPanel5.Text = "حسابات القيد النقــدي";
            // 
            // txtDebit1_R
            // 
            this.txtDebit1_R.BackColor = System.Drawing.SystemColors.Control;
            // 
            // 
            // 
            this.txtDebit1_R.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDebit1_R.ButtonCustom.Visible = true;
            this.txtDebit1_R.Font = new System.Drawing.Font("Tahoma", 8F);
            this.txtDebit1_R.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtDebit1_R.Location = new System.Drawing.Point(3, 10);
            this.txtDebit1_R.Name = "txtDebit1_R";
            this.txtDebit1_R.ReadOnly = true;
            this.txtDebit1_R.Size = new System.Drawing.Size(194, 14);
            this.txtDebit1_R.TabIndex = 1118;
            this.txtDebit1_R.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDebit1_R.ButtonCustomClick += new System.EventHandler(this.txtDebit1_R_ButtonCustomClick);
            // 
            // txtCredit1_R
            // 
            this.txtCredit1_R.BackColor = System.Drawing.SystemColors.Control;
            // 
            // 
            // 
            this.txtCredit1_R.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtCredit1_R.ButtonCustom.Visible = true;
            this.txtCredit1_R.Font = new System.Drawing.Font("Tahoma", 8F);
            this.txtCredit1_R.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtCredit1_R.Location = new System.Drawing.Point(4, 31);
            this.txtCredit1_R.Name = "txtCredit1_R";
            this.txtCredit1_R.ReadOnly = true;
            this.txtCredit1_R.Size = new System.Drawing.Size(194, 14);
            this.txtCredit1_R.TabIndex = 1119;
            this.txtCredit1_R.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCredit1_R.ButtonCustomClick += new System.EventHandler(this.txtCredit1_R_ButtonCustomClick);
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label9.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label9.Location = new System.Drawing.Point(199, 10);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(87, 13);
            this.label9.TabIndex = 1116;
            this.label9.Text = "الحساب المديـن :";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label10.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label10.Location = new System.Drawing.Point(199, 31);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(86, 13);
            this.label10.TabIndex = 1117;
            this.label10.Text = "الحسـاب الدائـن :";
            // 
            // groupPanel6
            // 
            this.groupPanel6.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel6.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel6.Controls.Add(this.txtDebit2_R);
            this.groupPanel6.Controls.Add(this.txtCredit2_R);
            this.groupPanel6.Controls.Add(this.label11);
            this.groupPanel6.Controls.Add(this.label12);
            this.groupPanel6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.groupPanel6.Location = new System.Drawing.Point(4, 207);
            this.groupPanel6.Name = "groupPanel6";
            this.groupPanel6.Size = new System.Drawing.Size(295, 78);
            // 
            // 
            // 
            this.groupPanel6.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel6.Style.BackColorGradientAngle = 90;
            this.groupPanel6.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel6.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel6.Style.BorderBottomWidth = 1;
            this.groupPanel6.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel6.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel6.Style.BorderLeftWidth = 1;
            this.groupPanel6.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel6.Style.BorderRightWidth = 1;
            this.groupPanel6.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel6.Style.BorderTopWidth = 1;
            this.groupPanel6.Style.CornerDiameter = 4;
            this.groupPanel6.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel6.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Far;
            this.groupPanel6.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel6.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel6.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel6.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel6.TabIndex = 95;
            this.groupPanel6.Text = "حسابات قيد الشــبكة";
            // 
            // txtDebit2_R
            // 
            this.txtDebit2_R.BackColor = System.Drawing.SystemColors.Control;
            // 
            // 
            // 
            this.txtDebit2_R.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDebit2_R.ButtonCustom.Visible = true;
            this.txtDebit2_R.Font = new System.Drawing.Font("Tahoma", 8F);
            this.txtDebit2_R.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtDebit2_R.Location = new System.Drawing.Point(4, 10);
            this.txtDebit2_R.Name = "txtDebit2_R";
            this.txtDebit2_R.ReadOnly = true;
            this.txtDebit2_R.Size = new System.Drawing.Size(194, 14);
            this.txtDebit2_R.TabIndex = 1118;
            this.txtDebit2_R.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDebit2_R.ButtonCustomClick += new System.EventHandler(this.txtDebit2_R_ButtonCustomClick);
            // 
            // txtCredit2_R
            // 
            this.txtCredit2_R.BackColor = System.Drawing.SystemColors.Control;
            // 
            // 
            // 
            this.txtCredit2_R.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtCredit2_R.ButtonCustom.Visible = true;
            this.txtCredit2_R.Font = new System.Drawing.Font("Tahoma", 8F);
            this.txtCredit2_R.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtCredit2_R.Location = new System.Drawing.Point(5, 31);
            this.txtCredit2_R.Name = "txtCredit2_R";
            this.txtCredit2_R.ReadOnly = true;
            this.txtCredit2_R.Size = new System.Drawing.Size(194, 14);
            this.txtCredit2_R.TabIndex = 1119;
            this.txtCredit2_R.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCredit2_R.ButtonCustomClick += new System.EventHandler(this.txtCredit2_R_ButtonCustomClick);
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label11.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label11.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label11.Location = new System.Drawing.Point(199, 10);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(87, 13);
            this.label11.TabIndex = 1116;
            this.label11.Text = "الحساب المديـن :";
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label12.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label12.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label12.Location = new System.Drawing.Point(199, 31);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(89, 13);
            this.label12.TabIndex = 1117;
            this.label12.Text = "الحساب الدائـــن :";
            // 
            // groupPanel3
            // 
            this.groupPanel3.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel3.Controls.Add(this.txtDebit3);
            this.groupPanel3.Controls.Add(this.txtCredit3);
            this.groupPanel3.Controls.Add(this.label5);
            this.groupPanel3.Controls.Add(this.label6);
            this.groupPanel3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.groupPanel3.Location = new System.Drawing.Point(302, 290);
            this.groupPanel3.Name = "groupPanel3";
            this.groupPanel3.Size = new System.Drawing.Size(295, 78);
            // 
            // 
            // 
            this.groupPanel3.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel3.Style.BackColorGradientAngle = 90;
            this.groupPanel3.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel3.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderBottomWidth = 1;
            this.groupPanel3.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel3.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderLeftWidth = 1;
            this.groupPanel3.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderRightWidth = 1;
            this.groupPanel3.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderTopWidth = 1;
            this.groupPanel3.Style.CornerDiameter = 4;
            this.groupPanel3.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel3.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Far;
            this.groupPanel3.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel3.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel3.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel3.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel3.TabIndex = 93;
            this.groupPanel3.Text = "حسابات القيد الآجــل";
            // 
            // txtDebit3
            // 
            this.txtDebit3.BackColor = System.Drawing.SystemColors.Control;
            // 
            // 
            // 
            this.txtDebit3.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDebit3.ButtonCustom.Visible = true;
            this.txtDebit3.Font = new System.Drawing.Font("Tahoma", 8F);
            this.txtDebit3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtDebit3.Location = new System.Drawing.Point(4, 10);
            this.txtDebit3.Name = "txtDebit3";
            this.txtDebit3.ReadOnly = true;
            this.txtDebit3.Size = new System.Drawing.Size(194, 14);
            this.txtDebit3.TabIndex = 1118;
            this.txtDebit3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDebit3.ButtonCustomClick += new System.EventHandler(this.txtDebit3_ButtonCustomClick);
            // 
            // txtCredit3
            // 
            this.txtCredit3.BackColor = System.Drawing.SystemColors.Control;
            // 
            // 
            // 
            this.txtCredit3.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtCredit3.ButtonCustom.Visible = true;
            this.txtCredit3.Font = new System.Drawing.Font("Tahoma", 8F);
            this.txtCredit3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtCredit3.Location = new System.Drawing.Point(5, 31);
            this.txtCredit3.Name = "txtCredit3";
            this.txtCredit3.ReadOnly = true;
            this.txtCredit3.Size = new System.Drawing.Size(194, 14);
            this.txtCredit3.TabIndex = 1119;
            this.txtCredit3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCredit3.ButtonCustomClick += new System.EventHandler(this.txtCredit3_ButtonCustomClick);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(202, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 13);
            this.label5.TabIndex = 1116;
            this.label5.Text = "الحساب المديـن :";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(202, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 13);
            this.label6.TabIndex = 1117;
            this.label6.Text = "الحساب الدائـــن :";
            // 
            // ChkGaid
            // 
            this.ChkGaid.AutoSize = true;
            this.ChkGaid.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.ChkGaid.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ChkGaid.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ChkGaid.Location = new System.Drawing.Point(89, 55);
            this.ChkGaid.Name = "ChkGaid";
            this.ChkGaid.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ChkGaid.Size = new System.Drawing.Size(113, 17);
            this.ChkGaid.TabIndex = 92;
            this.ChkGaid.Text = "انشاء قيد تلقائي";
            this.ChkGaid.UseVisualStyleBackColor = true;
            this.ChkGaid.CheckedChanged += new System.EventHandler(this.ChkGaid_CheckedChanged);
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.txtDebit1);
            this.groupPanel1.Controls.Add(this.txtCredit1);
            this.groupPanel1.Controls.Add(this.labelD1);
            this.groupPanel1.Controls.Add(this.labelC1);
            this.groupPanel1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.groupPanel1.Location = new System.Drawing.Point(304, 124);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(295, 78);
            // 
            // 
            // 
            this.groupPanel1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel1.Style.BackColorGradientAngle = 90;
            this.groupPanel1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderBottomWidth = 1;
            this.groupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderLeftWidth = 1;
            this.groupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderRightWidth = 1;
            this.groupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderTopWidth = 1;
            this.groupPanel1.Style.CornerDiameter = 4;
            this.groupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Far;
            this.groupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel1.TabIndex = 90;
            this.groupPanel1.Text = "حسابات القيد النقــدي";
            // 
            // txtDebit1
            // 
            this.txtDebit1.BackColor = System.Drawing.SystemColors.Control;
            // 
            // 
            // 
            this.txtDebit1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDebit1.ButtonCustom.Visible = true;
            this.txtDebit1.Font = new System.Drawing.Font("Tahoma", 8F);
            this.txtDebit1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtDebit1.Location = new System.Drawing.Point(4, 10);
            this.txtDebit1.Name = "txtDebit1";
            this.txtDebit1.ReadOnly = true;
            this.txtDebit1.Size = new System.Drawing.Size(194, 14);
            this.txtDebit1.TabIndex = 1118;
            this.txtDebit1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDebit1.ButtonCustomClick += new System.EventHandler(this.txtDebit1_ButtonCustomClick);
            // 
            // txtCredit1
            // 
            this.txtCredit1.BackColor = System.Drawing.SystemColors.Control;
            // 
            // 
            // 
            this.txtCredit1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtCredit1.ButtonCustom.Visible = true;
            this.txtCredit1.Font = new System.Drawing.Font("Tahoma", 8F);
            this.txtCredit1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtCredit1.Location = new System.Drawing.Point(5, 31);
            this.txtCredit1.Name = "txtCredit1";
            this.txtCredit1.ReadOnly = true;
            this.txtCredit1.Size = new System.Drawing.Size(194, 14);
            this.txtCredit1.TabIndex = 1119;
            this.txtCredit1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCredit1.ButtonCustomClick += new System.EventHandler(this.txtCredit1_ButtonCustomClick);
            // 
            // labelD1
            // 
            this.labelD1.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
            this.labelD1.AutoSize = true;
            this.labelD1.BackColor = System.Drawing.Color.Transparent;
            this.labelD1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelD1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.labelD1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelD1.Location = new System.Drawing.Point(202, 10);
            this.labelD1.Name = "labelD1";
            this.labelD1.Size = new System.Drawing.Size(87, 13);
            this.labelD1.TabIndex = 1116;
            this.labelD1.Text = "الحساب المديـن :";
            // 
            // labelC1
            // 
            this.labelC1.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
            this.labelC1.AutoSize = true;
            this.labelC1.BackColor = System.Drawing.Color.Transparent;
            this.labelC1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelC1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.labelC1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelC1.Location = new System.Drawing.Point(202, 31);
            this.labelC1.Name = "labelC1";
            this.labelC1.Size = new System.Drawing.Size(86, 13);
            this.labelC1.TabIndex = 1117;
            this.labelC1.Text = "الحسـاب الدائـن :";
            // 
            // CmbUsers
            // 
            this.CmbUsers.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbUsers.DisplayMember = "Text";
            this.CmbUsers.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.CmbUsers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbUsers.FormattingEnabled = true;
            this.CmbUsers.ItemHeight = 14;
            this.CmbUsers.Location = new System.Drawing.Point(210, 53);
            this.CmbUsers.Name = "CmbUsers";
            this.CmbUsers.Size = new System.Drawing.Size(259, 20);
            this.CmbUsers.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.CmbUsers.TabIndex = 89;
            this.CmbUsers.SelectedIndexChanged += new System.EventHandler(this.CmbUsers_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.SteelBlue;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(475, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 86;
            this.label1.Text = "إسم المستخدم :";
            // 
            // buttonX_OK
            // 
            this.buttonX_OK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX_OK.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.buttonX_OK.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.buttonX_OK.Location = new System.Drawing.Point(184, 373);
            this.buttonX_OK.Name = "buttonX_OK";
            this.buttonX_OK.Size = new System.Drawing.Size(413, 42);
            this.buttonX_OK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX_OK.Symbol = "";
            this.buttonX_OK.TabIndex = 1;
            this.buttonX_OK.Text = "إضافة";
            this.buttonX_OK.TextColor = System.Drawing.Color.White;
            this.buttonX_OK.Click += new System.EventHandler(this.buttonX_OK_Click);
            // 
            // groupPanel2
            // 
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.txtDebit2);
            this.groupPanel2.Controls.Add(this.txtCredit2);
            this.groupPanel2.Controls.Add(this.label2);
            this.groupPanel2.Controls.Add(this.label4);
            this.groupPanel2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.groupPanel2.Location = new System.Drawing.Point(302, 207);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(295, 78);
            // 
            // 
            // 
            this.groupPanel2.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
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
            this.groupPanel2.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Far;
            this.groupPanel2.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel2.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel2.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel2.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel2.TabIndex = 91;
            this.groupPanel2.Text = "حسابات قيد الشــبكة";
            // 
            // txtDebit2
            // 
            this.txtDebit2.BackColor = System.Drawing.SystemColors.Control;
            // 
            // 
            // 
            this.txtDebit2.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDebit2.ButtonCustom.Visible = true;
            this.txtDebit2.Font = new System.Drawing.Font("Tahoma", 8F);
            this.txtDebit2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtDebit2.Location = new System.Drawing.Point(4, 10);
            this.txtDebit2.Name = "txtDebit2";
            this.txtDebit2.ReadOnly = true;
            this.txtDebit2.Size = new System.Drawing.Size(194, 14);
            this.txtDebit2.TabIndex = 1118;
            this.txtDebit2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDebit2.ButtonCustomClick += new System.EventHandler(this.txtDebit2_ButtonCustomClick);
            // 
            // txtCredit2
            // 
            this.txtCredit2.BackColor = System.Drawing.SystemColors.Control;
            // 
            // 
            // 
            this.txtCredit2.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtCredit2.ButtonCustom.Visible = true;
            this.txtCredit2.Font = new System.Drawing.Font("Tahoma", 8F);
            this.txtCredit2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtCredit2.Location = new System.Drawing.Point(5, 31);
            this.txtCredit2.Name = "txtCredit2";
            this.txtCredit2.ReadOnly = true;
            this.txtCredit2.Size = new System.Drawing.Size(194, 14);
            this.txtCredit2.TabIndex = 1119;
            this.txtCredit2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCredit2.ButtonCustomClick += new System.EventHandler(this.txtCredit2_ButtonCustomClick);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(202, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 1116;
            this.label2.Text = "الحساب المديـن :";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(202, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 13);
            this.label4.TabIndex = 1117;
            this.label4.Text = "الحساب الدائـــن :";
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label14.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label14.ForeColor = System.Drawing.Color.SteelBlue;
            this.label14.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label14.Location = new System.Drawing.Point(6, 97);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(295, 21);
            this.label14.TabIndex = 98;
            this.label14.Text = "حسابات فاتورة مرتجع المبيعات";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrmUserPoint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(609, 437);
            this.ControlBox = false;
            this.PanelSpecialContainer.Controls.Add(this.ribbonBar1);
            this.ribbonBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = (InvAcc.Properties.Resources.favicon);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "FrmUserPoint";
            this.netResize1.AutoSaveLayout = true;
            this.netResize1.ParentControl = this;
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmUserPoint_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmUserPoint_KeyDown);
            this.ribbonBar1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupPanel4.ResumeLayout(false);
            this.groupPanel4.PerformLayout();
            this.groupPanel5.ResumeLayout(false);
            this.groupPanel5.PerformLayout();
            this.groupPanel6.ResumeLayout(false);
            this.groupPanel6.PerformLayout();
            this.groupPanel3.ResumeLayout(false);
            this.groupPanel3.PerformLayout();
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            this.groupPanel2.ResumeLayout(false);
            this.groupPanel2.PerformLayout();
            this.Icon = (InvAcc.Properties.Resources.favicon);
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).EndInit();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.ResumeLayout(false);
        }//###########&&&&&&&&&&

}
}
