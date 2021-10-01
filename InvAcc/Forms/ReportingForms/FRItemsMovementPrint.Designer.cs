   

namespace InvAcc.Forms
{
partial class FRItemsMovementPrint
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRItemsMovementPrint));
            this.PanelSpecialContainer = new System.Windows.Forms.Panel();
            this.ribbonBar1 = new DevComponents.DotNetBar.RibbonBar();
            this.ButOk = new C1.Win.C1Input.C1Button();
            this.ButExit = new C1.Win.C1Input.C1Button();
            this.label7 = new System.Windows.Forms.Label();
            this.button_SrchLegNo = new DevComponents.DotNetBar.ButtonX();
            this.txtLegNo = new System.Windows.Forms.TextBox();
            this.txtLegName = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.combobox_Unit = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label22 = new System.Windows.Forms.Label();
            this.FlexType = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button_SrchSuppNo = new DevComponents.DotNetBar.ButtonX();
            this.button_SrchCustNo = new DevComponents.DotNetBar.ButtonX();
            this.txtSuppNo = new System.Windows.Forms.TextBox();
            this.txtCustNo = new System.Windows.Forms.TextBox();
            this.txtFromItemNo = new System.Windows.Forms.TextBox();
            this.txtIntoItemNo = new System.Windows.Forms.TextBox();
            this.txtGroupItemNo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label55 = new System.Windows.Forms.Label();
            this.button_SrchCatNo = new DevComponents.DotNetBar.ButtonX();
            this.button_SrchItemTo = new DevComponents.DotNetBar.ButtonX();
            this.button_SrchItemFrom = new DevComponents.DotNetBar.ButtonX();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtMToDate = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMFromDate = new System.Windows.Forms.MaskedTextBox();
            this.txtIntoItemName = new System.Windows.Forms.TextBox();
            this.txtFromItemName = new System.Windows.Forms.TextBox();
            this.txtGroupItemName = new System.Windows.Forms.TextBox();
            this.txtSuppName = new System.Windows.Forms.TextBox();
            this.txtCustName = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.RButShort = new System.Windows.Forms.RadioButton();
            this.RButDetails = new System.Windows.Forms.RadioButton();
            this.netResize1 = new Softgroup.NetResize.NetResize(this.components);  this.netResize1.LabelsAutoEllipse = false;
            this.PanelSpecialContainer.SuspendLayout();
            this.ribbonBar1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ButOk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FlexType)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelSpecialContainer
            // 
            this.PanelSpecialContainer.Controls.Add(this.ribbonBar1);
            this.PanelSpecialContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelSpecialContainer.Location = new System.Drawing.Point(0, 0);
            this.PanelSpecialContainer.Name = "PanelSpecialContainer";
            this.PanelSpecialContainer.Size = new System.Drawing.Size(539, 325);
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
            this.ribbonBar1.Controls.Add(this.ButOk);
            this.ribbonBar1.Controls.Add(this.ButExit);
            this.ribbonBar1.Controls.Add(this.label7);
            this.ribbonBar1.Controls.Add(this.button_SrchLegNo);
            this.ribbonBar1.Controls.Add(this.txtLegNo);
            this.ribbonBar1.Controls.Add(this.txtLegName);
            this.ribbonBar1.Controls.Add(this.label10);
            this.ribbonBar1.Controls.Add(this.combobox_Unit);
            this.ribbonBar1.Controls.Add(this.label22);
            this.ribbonBar1.Controls.Add(this.FlexType);
            this.ribbonBar1.Controls.Add(this.label6);
            this.ribbonBar1.Controls.Add(this.label5);
            this.ribbonBar1.Controls.Add(this.button_SrchSuppNo);
            this.ribbonBar1.Controls.Add(this.button_SrchCustNo);
            this.ribbonBar1.Controls.Add(this.txtSuppNo);
            this.ribbonBar1.Controls.Add(this.txtCustNo);
            this.ribbonBar1.Controls.Add(this.txtFromItemNo);
            this.ribbonBar1.Controls.Add(this.txtIntoItemNo);
            this.ribbonBar1.Controls.Add(this.txtGroupItemNo);
            this.ribbonBar1.Controls.Add(this.label4);
            this.ribbonBar1.Controls.Add(this.label3);
            this.ribbonBar1.Controls.Add(this.label55);
            this.ribbonBar1.Controls.Add(this.button_SrchCatNo);
            this.ribbonBar1.Controls.Add(this.button_SrchItemTo);
            this.ribbonBar1.Controls.Add(this.button_SrchItemFrom);
            this.ribbonBar1.Controls.Add(this.groupBox4);
            this.ribbonBar1.Controls.Add(this.txtIntoItemName);
            this.ribbonBar1.Controls.Add(this.txtFromItemName);
            this.ribbonBar1.Controls.Add(this.txtGroupItemName);
            this.ribbonBar1.Controls.Add(this.txtSuppName);
            this.ribbonBar1.Controls.Add(this.txtCustName);
            this.ribbonBar1.Controls.Add(this.groupBox2);
            this.ribbonBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonBar1.Tag= "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.ribbonBar1.Location = new System.Drawing.Point(0, 0);
            this.ribbonBar1.Name = "ribbonBar1";
            this.ribbonBar1.Size = new System.Drawing.Size(539, 325);
            this.ribbonBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this.ribbonBar1.TabIndex = 1102;
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
            // ButOk
            // 
            this.ButOk.BackgroundImage = global::InvAcc.Properties.Resources.print;
            this.ButOk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ButOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButOk.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.ButOk.Location = new System.Drawing.Point(313, 262);
            this.ButOk.Name = "ButOk";
            this.ButOk.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ButOk.Size = new System.Drawing.Size(206, 35);
            this.ButOk.TabIndex = 6748;
            this.ButOk.Text = "طباعه | Print";
            this.ButOk.UseVisualStyleBackColor = true;
            this.ButOk.Click += new System.EventHandler(this.ButOk_Click);
            this.ButOk.MouseLeave += new System.EventHandler(this.ButOk_MouseLeave);
            this.ButOk.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ButOk_MouseMove);
            // 
            // ButExit
            // 
            this.ButExit.BackgroundImage = global::InvAcc.Properties.Resources.YALO2;
            this.ButExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ButExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButExit.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.ButExit.Location = new System.Drawing.Point(146, 262);
            this.ButExit.Name = "ButExit";
            this.ButExit.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ButExit.Size = new System.Drawing.Size(161, 35);
            this.ButExit.TabIndex = 6747;
            this.ButExit.Text = "خروج | ESC";
            this.ButExit.UseVisualStyleBackColor = true;
            this.ButExit.Click += new System.EventHandler(this.ButExit_Click);
            this.ButExit.MouseLeave += new System.EventHandler(this.ButExit_MouseLeave);
            this.ButExit.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ButExit_MouseMove);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(460, 183);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 13);
            this.label7.TabIndex = 6746;
            this.label7.Text = "المنـــــــدوب :";
            // 
            // button_SrchLegNo
            // 
            this.button_SrchLegNo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchLegNo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchLegNo.Location = new System.Drawing.Point(347, 179);
            this.button_SrchLegNo.Name = "button_SrchLegNo";
            this.button_SrchLegNo.Size = new System.Drawing.Size(26, 20);
            this.button_SrchLegNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchLegNo.Symbol = "";
            this.button_SrchLegNo.SymbolSize = 12F;
            this.button_SrchLegNo.TabIndex = 6744;
            this.button_SrchLegNo.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchLegNo.Click += new System.EventHandler(this.button_SrchLegNo_Click);
            // 
            // txtLegNo
            // 
            this.txtLegNo.BackColor = System.Drawing.Color.White;
            this.txtLegNo.Location = new System.Drawing.Point(376, 179);
            this.txtLegNo.Name = "txtLegNo";
            this.txtLegNo.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtLegNo, false);
            this.txtLegNo.Size = new System.Drawing.Size(79, 20);
            this.txtLegNo.TabIndex = 6743;
            this.txtLegNo.Tag = "T_INVHED.MndNo ";
            this.txtLegNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtLegName
            // 
            this.txtLegName.BackColor = System.Drawing.Color.Ivory;
            this.txtLegName.ForeColor = System.Drawing.Color.White;
            this.txtLegName.Location = new System.Drawing.Point(144, 179);
            this.txtLegName.Name = "txtLegName";
            this.txtLegName.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtLegName, false);
            this.txtLegName.Size = new System.Drawing.Size(201, 20);
            this.txtLegName.TabIndex = 6745;
            this.txtLegName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label10.Location = new System.Drawing.Point(460, 208);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 13);
            this.label10.TabIndex = 6742;
            this.label10.Text = "الوحــــــدة :";
            // 
            // combobox_Unit
            // 
            this.combobox_Unit.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.combobox_Unit.DisplayMember = "Text";
            this.combobox_Unit.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.combobox_Unit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combobox_Unit.FormattingEnabled = true;
            this.combobox_Unit.ItemHeight = 14;
            this.combobox_Unit.Location = new System.Drawing.Point(144, 204);
            this.combobox_Unit.Name = "combobox_Unit";
            this.combobox_Unit.Size = new System.Drawing.Size(311, 20);
            this.combobox_Unit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.combobox_Unit.TabIndex = 6741;
            // 
            // label22
            // 
            this.label22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(217)))), ((int)(((byte)(243)))));
            this.label22.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label22.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label22.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label22.Location = new System.Drawing.Point(1, 9);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(139, 42);
            this.label22.TabIndex = 6740;
            this.label22.Text = "الفواتــــير";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FlexType
            // 
            this.FlexType.BackColor = System.Drawing.Color.White;
            this.FlexType.ColumnInfo = resources.GetString("FlexType.ColumnInfo");
            this.FlexType.Font = new System.Drawing.Font("Tahoma", 8F);
            this.FlexType.Location = new System.Drawing.Point(1, 53);
            this.FlexType.Name = "FlexType";
            this.FlexType.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.FlexType.Rows.Count = 13;
            this.FlexType.Rows.DefaultSize = 19;
            this.FlexType.Rows.Fixed = 0;
            this.FlexType.Size = new System.Drawing.Size(139, 251);
            this.FlexType.StyleInfo = resources.GetString("FlexType.StyleInfo");
            this.FlexType.TabIndex = 6739;
            this.FlexType.Tag = " T_INVHED.InvCashPay ";
            this.FlexType.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.System;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(460, 159);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 13);
            this.label6.TabIndex = 6738;
            this.label6.Text = "المـــــــورد :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(460, 134);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 6737;
            this.label5.Text = "العميــــــل :";
            // 
            // button_SrchSuppNo
            // 
            this.button_SrchSuppNo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchSuppNo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchSuppNo.Location = new System.Drawing.Point(347, 155);
            this.button_SrchSuppNo.Name = "button_SrchSuppNo";
            this.button_SrchSuppNo.Size = new System.Drawing.Size(26, 20);
            this.button_SrchSuppNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchSuppNo.Symbol = "";
            this.button_SrchSuppNo.SymbolSize = 12F;
            this.button_SrchSuppNo.TabIndex = 6735;
            this.button_SrchSuppNo.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchSuppNo.Click += new System.EventHandler(this.button_SrchSuppNo_Click);
            // 
            // button_SrchCustNo
            // 
            this.button_SrchCustNo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchCustNo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchCustNo.Location = new System.Drawing.Point(347, 130);
            this.button_SrchCustNo.Name = "button_SrchCustNo";
            this.button_SrchCustNo.Size = new System.Drawing.Size(26, 20);
            this.button_SrchCustNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchCustNo.Symbol = "";
            this.button_SrchCustNo.SymbolSize = 12F;
            this.button_SrchCustNo.TabIndex = 6732;
            this.button_SrchCustNo.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchCustNo.Click += new System.EventHandler(this.button_SrchCustNo_Click);
            // 
            // txtSuppNo
            // 
            this.txtSuppNo.BackColor = System.Drawing.Color.White;
            this.txtSuppNo.Location = new System.Drawing.Point(376, 155);
            this.txtSuppNo.Name = "txtSuppNo";
            this.txtSuppNo.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtSuppNo, false);
            this.txtSuppNo.Size = new System.Drawing.Size(79, 20);
            this.txtSuppNo.TabIndex = 6734;
            this.txtSuppNo.Tag = " T_INVHED.CusVenNo ";
            this.txtSuppNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtCustNo
            // 
            this.txtCustNo.BackColor = System.Drawing.Color.White;
            this.txtCustNo.Location = new System.Drawing.Point(376, 130);
            this.txtCustNo.Name = "txtCustNo";
            this.txtCustNo.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtCustNo, false);
            this.txtCustNo.Size = new System.Drawing.Size(79, 20);
            this.txtCustNo.TabIndex = 6731;
            this.txtCustNo.Tag = " T_INVHED.CusVenNo ";
            this.txtCustNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtFromItemNo
            // 
            this.txtFromItemNo.BackColor = System.Drawing.Color.White;
            this.txtFromItemNo.Location = new System.Drawing.Point(376, 54);
            this.txtFromItemNo.Name = "txtFromItemNo";
            this.txtFromItemNo.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtFromItemNo, false);
            this.txtFromItemNo.Size = new System.Drawing.Size(79, 20);
            this.txtFromItemNo.TabIndex = 3;
            this.txtFromItemNo.Tag = " T_Items.Itm_No ";
            this.txtFromItemNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtFromItemNo.Click += new System.EventHandler(this.txtFromItemNo_Click);
            // 
            // txtIntoItemNo
            // 
            this.txtIntoItemNo.BackColor = System.Drawing.Color.White;
            this.txtIntoItemNo.Location = new System.Drawing.Point(376, 79);
            this.txtIntoItemNo.Name = "txtIntoItemNo";
            this.txtIntoItemNo.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtIntoItemNo, false);
            this.txtIntoItemNo.Size = new System.Drawing.Size(79, 20);
            this.txtIntoItemNo.TabIndex = 6;
            this.txtIntoItemNo.Tag = " T_Items.Itm_No ";
            this.txtIntoItemNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtIntoItemNo.Click += new System.EventHandler(this.txtIntoItemNo_Click);
            // 
            // txtGroupItemNo
            // 
            this.txtGroupItemNo.BackColor = System.Drawing.Color.White;
            this.txtGroupItemNo.Location = new System.Drawing.Point(376, 105);
            this.txtGroupItemNo.Name = "txtGroupItemNo";
            this.txtGroupItemNo.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtGroupItemNo, false);
            this.txtGroupItemNo.Size = new System.Drawing.Size(79, 20);
            this.txtGroupItemNo.TabIndex = 9;
            this.txtGroupItemNo.Tag = "  T_CATEGORY.CAT_ID ";
            this.txtGroupItemNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtGroupItemNo.Click += new System.EventHandler(this.txtGroupItemNo_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(460, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 1119;
            this.label4.Text = "إلى صنف :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(460, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 1118;
            this.label3.Text = "من صنف :";
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.BackColor = System.Drawing.Color.Transparent;
            this.label55.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label55.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label55.Location = new System.Drawing.Point(460, 109);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(56, 13);
            this.label55.TabIndex = 1117;
            this.label55.Text = "التصنيف :";
            // 
            // button_SrchCatNo
            // 
            this.button_SrchCatNo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchCatNo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchCatNo.Location = new System.Drawing.Point(347, 105);
            this.button_SrchCatNo.Name = "button_SrchCatNo";
            this.button_SrchCatNo.Size = new System.Drawing.Size(26, 20);
            this.button_SrchCatNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchCatNo.Symbol = "";
            this.button_SrchCatNo.SymbolSize = 12F;
            this.button_SrchCatNo.TabIndex = 10;
            this.button_SrchCatNo.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchCatNo.Click += new System.EventHandler(this.button_SrchCatNo_Click);
            // 
            // button_SrchItemTo
            // 
            this.button_SrchItemTo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchItemTo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchItemTo.Location = new System.Drawing.Point(347, 79);
            this.button_SrchItemTo.Name = "button_SrchItemTo";
            this.button_SrchItemTo.Size = new System.Drawing.Size(26, 20);
            this.button_SrchItemTo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchItemTo.Symbol = "";
            this.button_SrchItemTo.SymbolSize = 12F;
            this.button_SrchItemTo.TabIndex = 7;
            this.button_SrchItemTo.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchItemTo.Click += new System.EventHandler(this.button_SrchItemTo_Click);
            // 
            // button_SrchItemFrom
            // 
            this.button_SrchItemFrom.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchItemFrom.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchItemFrom.Location = new System.Drawing.Point(347, 54);
            this.button_SrchItemFrom.Name = "button_SrchItemFrom";
            this.button_SrchItemFrom.Size = new System.Drawing.Size(26, 20);
            this.button_SrchItemFrom.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchItemFrom.Symbol = "";
            this.button_SrchItemFrom.SymbolSize = 12F;
            this.button_SrchItemFrom.TabIndex = 4;
            this.button_SrchItemFrom.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchItemFrom.Click += new System.EventHandler(this.button_SrchItemFrom_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.Transparent;
            this.groupBox4.Controls.Add(this.txtMToDate);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.txtMFromDate);
            this.groupBox4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.groupBox4.Location = new System.Drawing.Point(144, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(391, 48);
            this.groupBox4.TabIndex = 1109;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "حسب التاريخ";
            // 
            // txtMToDate
            // 
            this.txtMToDate.Location = new System.Drawing.Point(23, 19);
            this.txtMToDate.Mask = "0000/00/00";
            this.txtMToDate.Name = "txtMToDate";
            this.txtMToDate.Size = new System.Drawing.Size(108, 21);
            this.txtMToDate.TabIndex = 2;
            this.txtMToDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMToDate.Click += new System.EventHandler(this.txtMToDate_Click);
            this.txtMToDate.Leave += new System.EventHandler(this.txtMToDate_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(322, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 860;
            this.label1.Text = "مـــــن :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(137, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 861;
            this.label2.Text = "إلـــــى :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMFromDate
            // 
            this.txtMFromDate.Location = new System.Drawing.Point(208, 19);
            this.txtMFromDate.Mask = "0000/00/00";
            this.txtMFromDate.Name = "txtMFromDate";
            this.txtMFromDate.Size = new System.Drawing.Size(108, 21);
            this.txtMFromDate.TabIndex = 1;
            this.txtMFromDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMFromDate.Click += new System.EventHandler(this.txtMFromDate_Click);
            this.txtMFromDate.Leave += new System.EventHandler(this.txtMFromDate_Leave);
            // 
            // txtIntoItemName
            // 
            this.txtIntoItemName.BackColor = System.Drawing.Color.Ivory;
            this.txtIntoItemName.ForeColor = System.Drawing.Color.White;
            this.txtIntoItemName.Location = new System.Drawing.Point(144, 79);
            this.txtIntoItemName.Name = "txtIntoItemName";
            this.txtIntoItemName.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtIntoItemName, false);
            this.txtIntoItemName.Size = new System.Drawing.Size(201, 20);
            this.txtIntoItemName.TabIndex = 8;
            this.txtIntoItemName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtIntoItemName.Click += new System.EventHandler(this.txtIntoItemName_Click);
            // 
            // txtFromItemName
            // 
            this.txtFromItemName.BackColor = System.Drawing.Color.Ivory;
            this.txtFromItemName.ForeColor = System.Drawing.Color.White;
            this.txtFromItemName.Location = new System.Drawing.Point(144, 54);
            this.txtFromItemName.Name = "txtFromItemName";
            this.txtFromItemName.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtFromItemName, false);
            this.txtFromItemName.Size = new System.Drawing.Size(201, 20);
            this.txtFromItemName.TabIndex = 5;
            this.txtFromItemName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtFromItemName.Click += new System.EventHandler(this.txtFromItemName_Click);
            // 
            // txtGroupItemName
            // 
            this.txtGroupItemName.BackColor = System.Drawing.Color.Ivory;
            this.txtGroupItemName.ForeColor = System.Drawing.Color.White;
            this.txtGroupItemName.Location = new System.Drawing.Point(144, 105);
            this.txtGroupItemName.Name = "txtGroupItemName";
            this.txtGroupItemName.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtGroupItemName, false);
            this.txtGroupItemName.Size = new System.Drawing.Size(201, 20);
            this.txtGroupItemName.TabIndex = 11;
            this.txtGroupItemName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtGroupItemName.Click += new System.EventHandler(this.txtGroupItemName_Click);
            this.txtGroupItemName.TextChanged += new System.EventHandler(this.txtGroupItemName_TextChanged);
            // 
            // txtSuppName
            // 
            this.txtSuppName.BackColor = System.Drawing.Color.Ivory;
            this.txtSuppName.ForeColor = System.Drawing.Color.White;
            this.txtSuppName.Location = new System.Drawing.Point(144, 155);
            this.txtSuppName.Name = "txtSuppName";
            this.txtSuppName.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtSuppName, false);
            this.txtSuppName.Size = new System.Drawing.Size(201, 20);
            this.txtSuppName.TabIndex = 6736;
            this.txtSuppName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtCustName
            // 
            this.txtCustName.BackColor = System.Drawing.Color.Ivory;
            this.txtCustName.ForeColor = System.Drawing.Color.White;
            this.txtCustName.Location = new System.Drawing.Point(144, 130);
            this.txtCustName.Name = "txtCustName";
            this.txtCustName.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtCustName, false);
            this.txtCustName.Size = new System.Drawing.Size(201, 20);
            this.txtCustName.TabIndex = 6733;
            this.txtCustName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.RButShort);
            this.groupBox2.Controls.Add(this.RButDetails);
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.groupBox2.Location = new System.Drawing.Point(144, 220);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(311, 41);
            this.groupBox2.TabIndex = 6730;
            this.groupBox2.TabStop = false;
            // 
            // RButShort
            // 
            this.RButShort.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.RButShort.ForeColor = System.Drawing.Color.SteelBlue;
            this.RButShort.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.RButShort.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.RButShort.Location = new System.Drawing.Point(45, 15);
            this.RButShort.Name = "RButShort";
            this.RButShort.Size = new System.Drawing.Size(75, 20);
            this.RButShort.TabIndex = 1008;
            this.RButShort.Text = "مختصر";
            this.RButShort.UseVisualStyleBackColor = true;
            this.RButShort.CheckedChanged += new System.EventHandler(this.RButShort_CheckedChanged);
            // 
            // RButDetails
            // 
            this.RButDetails.Checked = true;
            this.RButDetails.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.RButDetails.ForeColor = System.Drawing.Color.SteelBlue;
            this.RButDetails.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.RButDetails.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.RButDetails.Location = new System.Drawing.Point(185, 15);
            this.RButDetails.Name = "RButDetails";
            this.RButDetails.Size = new System.Drawing.Size(75, 20);
            this.RButDetails.TabIndex = 1007;
            this.RButDetails.TabStop = true;
            this.RButDetails.Text = "تفصيلي";
            this.RButDetails.UseVisualStyleBackColor = true;
            // 
            // netResize1
            // 
            this.netResize1.AutoSaveLayout = true;
            this.netResize1.ParentControl = this;
            // 
            // FRItemsMovementPrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 325);
            this.Controls.Add(this.PanelSpecialContainer);
            this.Icon = global::InvAcc.Properties.Resources.favicon;
            this.KeyPreview = true;
            this.Name = "FRItemsMovementPrint";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FRItemsMovementPrint_Load);
            this.Shown += new System.EventHandler(this.FrmInvSale_Shown);
            this.SizeChanged += new System.EventHandler(this.FrmInvSale_SizeChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Frm_KeyPress);
            this.PanelSpecialContainer.ResumeLayout(false);
            this.ribbonBar1.ResumeLayout(false);
            this.ribbonBar1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ButOk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FlexType)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).EndInit();
            this.ResumeLayout(false);

        }//###########&&&&&&&&&&

}
}
