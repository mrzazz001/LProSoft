   

namespace InvAcc.Forms
{
partial class FRItemsData
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRItemsData));
            this.PanelSpecialContainer = new System.Windows.Forms.Panel();
            this.ribbonBar1 = new DevComponents.DotNetBar.RibbonBar();
            this.ButOk = new C1.Win.C1Input.C1Button();
            this.ButExit = new C1.Win.C1Input.C1Button();
            this.checkBox_OtherPrices = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.combobox_CostTyp = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label10 = new System.Windows.Forms.Label();
            this.combobox_Unit = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtInItemName = new System.Windows.Forms.TextBox();
            this.txtClassName = new System.Windows.Forms.TextBox();
            this.txtFItemName = new System.Windows.Forms.TextBox();
            this.txtStoreName = new System.Windows.Forms.TextBox();
            this.txtSuppName = new System.Windows.Forms.TextBox();
            this.txtFItemNo = new System.Windows.Forms.TextBox();
            this.txtInItemNo = new System.Windows.Forms.TextBox();
            this.txtClassNo = new System.Windows.Forms.TextBox();
            this.txtStoreNo = new System.Windows.Forms.TextBox();
            this.txtSuppNo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button_SrchStoreNo = new DevComponents.DotNetBar.ButtonX();
            this.button_SrchSuppNo = new DevComponents.DotNetBar.ButtonX();
            this.button_SrchClassNo = new DevComponents.DotNetBar.ButtonX();
            this.button_SrchItemTo = new DevComponents.DotNetBar.ButtonX();
            this.button_SrchItemFrom = new DevComponents.DotNetBar.ButtonX();
            this.FlexField = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.groupBox_Date = new System.Windows.Forms.GroupBox();
            this.txtMToDate = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMFromDate = new System.Windows.Forms.MaskedTextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMIntoNo = new System.Windows.Forms.MaskedTextBox();
            this.txtMFromNo = new System.Windows.Forms.MaskedTextBox();
            this.netResize1 = new Softgroup.NetResize.NetResize(this.components);
            this.netResize1.AfterControlResize += new Softgroup.NetResize.NetResize.AfterControlResizeEventHandler(this.netResize1_AfterControlResize);
            this.VisibleChanged += new System.EventHandler(this.FRInvoice_VisibleChanged);
            this.PanelSpecialContainer.SuspendLayout();
            this.ribbonBar1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ButOk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FlexField)).BeginInit();
            this.groupBox_Date.SuspendLayout();
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
            this.PanelSpecialContainer.Size = new System.Drawing.Size(506, 283);
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
            this.ribbonBar1.Controls.Add(this.checkBox_OtherPrices);
            this.ribbonBar1.Controls.Add(this.label11);
            this.ribbonBar1.Controls.Add(this.combobox_CostTyp);
            this.ribbonBar1.Controls.Add(this.label10);
            this.ribbonBar1.Controls.Add(this.combobox_Unit);
            this.ribbonBar1.Controls.Add(this.label8);
            this.ribbonBar1.Controls.Add(this.label5);
            this.ribbonBar1.Controls.Add(this.label9);
            this.ribbonBar1.Controls.Add(this.txtInItemName);
            this.ribbonBar1.Controls.Add(this.txtClassName);
            this.ribbonBar1.Controls.Add(this.txtFItemName);
            this.ribbonBar1.Controls.Add(this.txtStoreName);
            this.ribbonBar1.Controls.Add(this.txtSuppName);
            this.ribbonBar1.Controls.Add(this.txtFItemNo);
            this.ribbonBar1.Controls.Add(this.txtInItemNo);
            this.ribbonBar1.Controls.Add(this.txtClassNo);
            this.ribbonBar1.Controls.Add(this.txtStoreNo);
            this.ribbonBar1.Controls.Add(this.txtSuppNo);
            this.ribbonBar1.Controls.Add(this.label7);
            this.ribbonBar1.Controls.Add(this.label6);
            this.ribbonBar1.Controls.Add(this.button_SrchStoreNo);
            this.ribbonBar1.Controls.Add(this.button_SrchSuppNo);
            this.ribbonBar1.Controls.Add(this.button_SrchClassNo);
            this.ribbonBar1.Controls.Add(this.button_SrchItemTo);
            this.ribbonBar1.Controls.Add(this.button_SrchItemFrom);
            this.ribbonBar1.Controls.Add(this.FlexField);
            this.ribbonBar1.Controls.Add(this.groupBox_Date);
            this.ribbonBar1.Controls.Add(this.groupBox3);
            this.ribbonBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonBar1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.ribbonBar1.Location = new System.Drawing.Point(0, 0);
            this.ribbonBar1.Name = "ribbonBar1";
            this.ribbonBar1.Size = new System.Drawing.Size(506, 283);
            this.ribbonBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this.ribbonBar1.TabIndex = 1101;
            // 
            // 
            // 
            this.ribbonBar1.TitleStyle.BackColor = System.Drawing.Color.Silver;
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
            this.ButOk.Location = new System.Drawing.Point(232, 228);
            this.ButOk.Name = "ButOk";
            this.ButOk.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ButOk.Size = new System.Drawing.Size(227, 35);
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
            this.ButExit.Location = new System.Drawing.Point(47, 228);
            this.ButExit.Name = "ButExit";
            this.ButExit.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ButExit.Size = new System.Drawing.Size(179, 35);
            this.ButExit.TabIndex = 6747;
            this.ButExit.Text = "خروج | ESC";
            this.ButExit.UseVisualStyleBackColor = true;
            this.ButExit.Click += new System.EventHandler(this.ButExit_Click);
            this.ButExit.MouseLeave += new System.EventHandler(this.ButExit_MouseLeave);
            this.ButExit.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ButExit_MouseMove);
            // 
            // checkBox_OtherPrices
            // 
            this.checkBox_OtherPrices.AutoSize = true;
            this.checkBox_OtherPrices.BackColor = System.Drawing.Color.Transparent;
            this.checkBox_OtherPrices.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox_OtherPrices.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.checkBox_OtherPrices.Location = new System.Drawing.Point(5, 204);
            this.checkBox_OtherPrices.Name = "checkBox_OtherPrices";
            this.checkBox_OtherPrices.Size = new System.Drawing.Size(120, 17);
            this.checkBox_OtherPrices.TabIndex = 6723;
            this.checkBox_OtherPrices.Text = "تقرير بالأسعار الأخرى";
            this.checkBox_OtherPrices.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBox_OtherPrices.UseVisualStyleBackColor = false;
            this.checkBox_OtherPrices.Visible = false;
            this.checkBox_OtherPrices.CheckedChanged += new System.EventHandler(this.checkBox_OtherPrices_CheckedChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label11.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label11.Location = new System.Drawing.Point(260, 206);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(45, 13);
            this.label11.TabIndex = 6722;
            this.label11.Text = "حسب :";
            // 
            // combobox_CostTyp
            // 
            this.combobox_CostTyp.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.combobox_CostTyp.DisplayMember = "Text";
            this.combobox_CostTyp.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.combobox_CostTyp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combobox_CostTyp.FormattingEnabled = true;
            this.combobox_CostTyp.ItemHeight = 14;
            this.combobox_CostTyp.Location = new System.Drawing.Point(131, 202);
            this.combobox_CostTyp.Name = "combobox_CostTyp";
            this.combobox_CostTyp.Size = new System.Drawing.Size(124, 20);
            this.combobox_CostTyp.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.combobox_CostTyp.TabIndex = 6721;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label10.Location = new System.Drawing.Point(436, 206);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 13);
            this.label10.TabIndex = 6720;
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
            this.combobox_Unit.Location = new System.Drawing.Point(307, 202);
            this.combobox_Unit.Name = "combobox_Unit";
            this.combobox_Unit.Size = new System.Drawing.Size(126, 20);
            this.combobox_Unit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.combobox_Unit.TabIndex = 6719;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(436, 155);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 13);
            this.label8.TabIndex = 1117;
            this.label8.Text = "المــــورد :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(436, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 1118;
            this.label5.Text = "من صنف :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label9.Location = new System.Drawing.Point(436, 180);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 13);
            this.label9.TabIndex = 1147;
            this.label9.Text = "المستودع :";
            // 
            // txtInItemName
            // 
            this.txtInItemName.BackColor = System.Drawing.Color.Ivory;
            this.txtInItemName.ForeColor = System.Drawing.Color.White;
            this.txtInItemName.Location = new System.Drawing.Point(5, 101);
            this.txtInItemName.Name = "txtInItemName";
            this.txtInItemName.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtInItemName, false);
            this.txtInItemName.Size = new System.Drawing.Size(300, 20);
            this.txtInItemName.TabIndex = 6;
            this.txtInItemName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtClassName
            // 
            this.txtClassName.BackColor = System.Drawing.Color.Ivory;
            this.txtClassName.ForeColor = System.Drawing.Color.White;
            this.txtClassName.Location = new System.Drawing.Point(5, 126);
            this.txtClassName.Name = "txtClassName";
            this.txtClassName.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtClassName, false);
            this.txtClassName.Size = new System.Drawing.Size(300, 20);
            this.txtClassName.TabIndex = 9;
            this.txtClassName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtFItemName
            // 
            this.txtFItemName.BackColor = System.Drawing.Color.Ivory;
            this.txtFItemName.ForeColor = System.Drawing.Color.White;
            this.txtFItemName.Location = new System.Drawing.Point(5, 76);
            this.txtFItemName.Name = "txtFItemName";
            this.txtFItemName.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtFItemName, false);
            this.txtFItemName.Size = new System.Drawing.Size(300, 20);
            this.txtFItemName.TabIndex = 3;
            this.txtFItemName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtStoreName
            // 
            this.txtStoreName.BackColor = System.Drawing.Color.Ivory;
            this.txtStoreName.ForeColor = System.Drawing.Color.White;
            this.txtStoreName.Location = new System.Drawing.Point(5, 176);
            this.txtStoreName.Name = "txtStoreName";
            this.txtStoreName.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtStoreName, false);
            this.txtStoreName.Size = new System.Drawing.Size(300, 20);
            this.txtStoreName.TabIndex = 15;
            this.txtStoreName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtSuppName
            // 
            this.txtSuppName.BackColor = System.Drawing.Color.Ivory;
            this.txtSuppName.ForeColor = System.Drawing.Color.White;
            this.txtSuppName.Location = new System.Drawing.Point(5, 151);
            this.txtSuppName.Name = "txtSuppName";
            this.txtSuppName.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtSuppName, false);
            this.txtSuppName.Size = new System.Drawing.Size(300, 20);
            this.txtSuppName.TabIndex = 12;
            this.txtSuppName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtFItemNo
            // 
            this.txtFItemNo.BackColor = System.Drawing.Color.White;
            this.txtFItemNo.Location = new System.Drawing.Point(335, 76);
            this.txtFItemNo.Name = "txtFItemNo";
            this.txtFItemNo.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtFItemNo, false);
            this.txtFItemNo.Size = new System.Drawing.Size(98, 20);
            this.txtFItemNo.TabIndex = 1;
            this.txtFItemNo.Tag = " T_Items.Itm_No ";
            this.txtFItemNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtInItemNo
            // 
            this.txtInItemNo.BackColor = System.Drawing.Color.White;
            this.txtInItemNo.Location = new System.Drawing.Point(335, 101);
            this.txtInItemNo.Name = "txtInItemNo";
            this.txtInItemNo.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtInItemNo, false);
            this.txtInItemNo.Size = new System.Drawing.Size(98, 20);
            this.txtInItemNo.TabIndex = 4;
            this.txtInItemNo.Tag = " T_Items.Itm_No ";
            this.txtInItemNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtClassNo
            // 
            this.txtClassNo.BackColor = System.Drawing.Color.White;
            this.txtClassNo.Location = new System.Drawing.Point(335, 126);
            this.txtClassNo.Name = "txtClassNo";
            this.txtClassNo.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtClassNo, false);
            this.txtClassNo.Size = new System.Drawing.Size(98, 20);
            this.txtClassNo.TabIndex = 7;
            this.txtClassNo.Tag = " T_CATEGORY.CAT_ID ";
            this.txtClassNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtStoreNo
            // 
            this.txtStoreNo.BackColor = System.Drawing.Color.White;
            this.txtStoreNo.Location = new System.Drawing.Point(335, 176);
            this.txtStoreNo.Name = "txtStoreNo";
            this.txtStoreNo.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtStoreNo, false);
            this.txtStoreNo.Size = new System.Drawing.Size(98, 20);
            this.txtStoreNo.TabIndex = 13;
            this.txtStoreNo.Tag = " T_STKSQTY.storeNo ";
            this.txtStoreNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtSuppNo
            // 
            this.txtSuppNo.BackColor = System.Drawing.Color.White;
            this.txtSuppNo.Location = new System.Drawing.Point(335, 151);
            this.txtSuppNo.Name = "txtSuppNo";
            this.txtSuppNo.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtSuppNo, false);
            this.txtSuppNo.Size = new System.Drawing.Size(98, 20);
            this.txtSuppNo.TabIndex = 10;
            this.txtSuppNo.Tag = " T_Items.DefultVendor ";
            this.txtSuppNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(436, 130);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 13);
            this.label7.TabIndex = 1120;
            this.label7.Text = "التصنيـــف :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(436, 105);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 1119;
            this.label6.Text = "إلى صنف :";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // button_SrchStoreNo
            // 
            this.button_SrchStoreNo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchStoreNo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchStoreNo.Location = new System.Drawing.Point(307, 176);
            this.button_SrchStoreNo.Name = "button_SrchStoreNo";
            this.button_SrchStoreNo.Size = new System.Drawing.Size(26, 20);
            this.button_SrchStoreNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchStoreNo.Symbol = "";
            this.button_SrchStoreNo.SymbolSize = 12F;
            this.button_SrchStoreNo.TabIndex = 14;
            this.button_SrchStoreNo.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchStoreNo.Click += new System.EventHandler(this.button_SrchStoreNo_Click);
            // 
            // button_SrchSuppNo
            // 
            this.button_SrchSuppNo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchSuppNo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchSuppNo.Location = new System.Drawing.Point(307, 151);
            this.button_SrchSuppNo.Name = "button_SrchSuppNo";
            this.button_SrchSuppNo.Size = new System.Drawing.Size(26, 20);
            this.button_SrchSuppNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchSuppNo.Symbol = "";
            this.button_SrchSuppNo.SymbolSize = 12F;
            this.button_SrchSuppNo.TabIndex = 11;
            this.button_SrchSuppNo.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchSuppNo.Click += new System.EventHandler(this.button_SrchSuppNo_Click);
            // 
            // button_SrchClassNo
            // 
            this.button_SrchClassNo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchClassNo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchClassNo.Location = new System.Drawing.Point(307, 126);
            this.button_SrchClassNo.Name = "button_SrchClassNo";
            this.button_SrchClassNo.Size = new System.Drawing.Size(26, 20);
            this.button_SrchClassNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchClassNo.Symbol = "";
            this.button_SrchClassNo.SymbolSize = 12F;
            this.button_SrchClassNo.TabIndex = 8;
            this.button_SrchClassNo.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchClassNo.Click += new System.EventHandler(this.button_SrchClassNo_Click);
            // 
            // button_SrchItemTo
            // 
            this.button_SrchItemTo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchItemTo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchItemTo.Location = new System.Drawing.Point(307, 101);
            this.button_SrchItemTo.Name = "button_SrchItemTo";
            this.button_SrchItemTo.Size = new System.Drawing.Size(26, 20);
            this.button_SrchItemTo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchItemTo.Symbol = "";
            this.button_SrchItemTo.SymbolSize = 12F;
            this.button_SrchItemTo.TabIndex = 5;
            this.button_SrchItemTo.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchItemTo.Click += new System.EventHandler(this.button_SrchItemTo_Click);
            // 
            // button_SrchItemFrom
            // 
            this.button_SrchItemFrom.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchItemFrom.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchItemFrom.Location = new System.Drawing.Point(307, 76);
            this.button_SrchItemFrom.Name = "button_SrchItemFrom";
            this.button_SrchItemFrom.Size = new System.Drawing.Size(26, 20);
            this.button_SrchItemFrom.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchItemFrom.Symbol = "";
            this.button_SrchItemFrom.SymbolSize = 12F;
            this.button_SrchItemFrom.TabIndex = 2;
            this.button_SrchItemFrom.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchItemFrom.Click += new System.EventHandler(this.button_SrchItemFrom_Click);
            // 
            // FlexField
            // 
            this.FlexField.BackColor = System.Drawing.Color.White;
            this.FlexField.ColumnInfo = resources.GetString("FlexField.ColumnInfo");
            this.FlexField.Font = new System.Drawing.Font("Tahoma", 8F);
            this.FlexField.Location = new System.Drawing.Point(6, 355);
            this.FlexField.Name = "FlexField";
            this.FlexField.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.FlexField.Rows.DefaultSize = 19;
            this.FlexField.Size = new System.Drawing.Size(224, 231);
            this.FlexField.StyleInfo = resources.GetString("FlexField.StyleInfo");
            this.FlexField.TabIndex = 1146;
            // 
            // groupBox_Date
            // 
            this.groupBox_Date.BackColor = System.Drawing.Color.Transparent;
            this.groupBox_Date.Controls.Add(this.txtMToDate);
            this.groupBox_Date.Controls.Add(this.label3);
            this.groupBox_Date.Controls.Add(this.label4);
            this.groupBox_Date.Controls.Add(this.txtMFromDate);
            this.groupBox_Date.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.groupBox_Date.Location = new System.Drawing.Point(5, 18);
            this.groupBox_Date.Name = "groupBox_Date";
            this.groupBox_Date.Size = new System.Drawing.Size(493, 48);
            this.groupBox_Date.TabIndex = 1109;
            this.groupBox_Date.TabStop = false;
            this.groupBox_Date.Text = "حسب تاريخ الركود";
            // 
            // txtMToDate
            // 
            this.txtMToDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtMToDate.Location = new System.Drawing.Point(25, 19);
            this.txtMToDate.Mask = "0000/00/00";
            this.txtMToDate.Name = "txtMToDate";
            this.txtMToDate.Size = new System.Drawing.Size(108, 21);
            this.txtMToDate.TabIndex = 19;
            this.txtMToDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMToDate.Click += new System.EventHandler(this.txtMToDate_Click);
            this.txtMToDate.Leave += new System.EventHandler(this.txtMToDate_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(401, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 860;
            this.label3.Text = "مـــــن :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(139, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 861;
            this.label4.Text = "إلـــــى :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMFromDate
            // 
            this.txtMFromDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtMFromDate.Location = new System.Drawing.Point(287, 19);
            this.txtMFromDate.Mask = "0000/00/00";
            this.txtMFromDate.Name = "txtMFromDate";
            this.txtMFromDate.Size = new System.Drawing.Size(108, 21);
            this.txtMFromDate.TabIndex = 18;
            this.txtMFromDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMFromDate.Click += new System.EventHandler(this.txtMFromDate_Click);
            this.txtMFromDate.Leave += new System.EventHandler(this.txtMFromDate_Leave);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.txtMIntoNo);
            this.groupBox3.Controls.Add(this.txtMFromNo);
            this.groupBox3.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.groupBox3.Location = new System.Drawing.Point(5, 18);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(493, 48);
            this.groupBox3.TabIndex = 1145;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "حسب الكمية";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(401, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 857;
            this.label1.Text = "مـــــن :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(137, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 859;
            this.label2.Text = "إلـــــى :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMIntoNo
            // 
            this.txtMIntoNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtMIntoNo.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtMIntoNo.Location = new System.Drawing.Point(23, 19);
            this.txtMIntoNo.Mask = "00000";
            this.txtMIntoNo.Name = "txtMIntoNo";
            this.txtMIntoNo.Size = new System.Drawing.Size(108, 22);
            this.txtMIntoNo.TabIndex = 21;
            this.txtMIntoNo.Tag = " T_STKSQTY.stkQty  ";
            this.txtMIntoNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMIntoNo.Click += new System.EventHandler(this.txtMIntoNo_Click);
            // 
            // txtMFromNo
            // 
            this.txtMFromNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtMFromNo.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtMFromNo.Location = new System.Drawing.Point(287, 19);
            this.txtMFromNo.Mask = "00000";
            this.txtMFromNo.Name = "txtMFromNo";
            this.txtMFromNo.Size = new System.Drawing.Size(108, 22);
            this.txtMFromNo.TabIndex = 20;
            this.txtMFromNo.Tag = " T_STKSQTY.stkQty ";
            this.txtMFromNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMFromNo.Click += new System.EventHandler(this.txtMFromNo_Click);
            // 
            // netResize1
            // 
            this.netResize1.AutoSaveLayout = true;
            this.netResize1.ParentControl = this;
            this.netResize1.ResizeMode = Softgroup.NetResize.NetResize.ResizeModeEnum.rmAdvanced;
            // 
            // FRItemsData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 283);
            this.Controls.Add(this.PanelSpecialContainer);
            this.Icon = global::InvAcc.Properties.Resources.favicon;
            this.KeyPreview = true;
            this.Name = "FRItemsData";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Load += new System.EventHandler(this.FRItemsData_Load);
            this.Shown += new System.EventHandler(this.FrmInvSale_Shown);
            this.SizeChanged += new System.EventHandler(this.FrmInvSale_SizeChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Frm_KeyPress);
            this.PanelSpecialContainer.ResumeLayout(false);
            this.ribbonBar1.ResumeLayout(false);
            this.ribbonBar1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ButOk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FlexField)).EndInit();
            this.groupBox_Date.ResumeLayout(false);
            this.groupBox_Date.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).EndInit();
            this.ResumeLayout(false);
        }//###########&&&&&&&&&&

}
}
