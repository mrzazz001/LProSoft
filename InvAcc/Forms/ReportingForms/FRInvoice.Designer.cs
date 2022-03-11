   

namespace InvAcc.Forms
{
partial class FRInvoice
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRInvoice));
            this.PanelSpecialContainer = new System.Windows.Forms.Panel();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.ribbonBar1 = new DevComponents.DotNetBar.RibbonBar();
            this.ButOk = new C1.Win.C1Input.C1Button();
            this.ButExit = new C1.Win.C1Input.C1Button();
            this.checkBox_CustomerNam = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.combobox_RepType = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.switchButton_OrderTyp = new DevComponents.DotNetBar.Controls.SwitchButton();
            this.label10 = new System.Windows.Forms.Label();
            this.combobox_SortTyp = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.switchButton_CalclatTax = new DevComponents.DotNetBar.Controls.SwitchButton();
            this.RButShort2 = new DevComponents.DotNetBar.Controls.SwitchButton();
            this.checkBox_Defalut = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.checkBox_ItemComm = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.checkBox_Note = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.RButShort = new DevComponents.DotNetBar.Controls.SwitchButton();
            this.CmbInvType = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button_SrchUsrNo = new DevComponents.DotNetBar.ButtonX();
            this.button_SrchLegNo = new DevComponents.DotNetBar.ButtonX();
            this.button_SrchSuppNo = new DevComponents.DotNetBar.ButtonX();
            this.button_SrchCustNo = new DevComponents.DotNetBar.ButtonX();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtUserNo = new System.Windows.Forms.TextBox();
            this.txtLegName = new System.Windows.Forms.TextBox();
            this.txtLegNo = new System.Windows.Forms.TextBox();
            this.txtSuppName = new System.Windows.Forms.TextBox();
            this.txtSuppNo = new System.Windows.Forms.TextBox();
            this.txtCustName = new System.Windows.Forms.TextBox();
            this.txtCustNo = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtMIntoNo = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMFromNo = new System.Windows.Forms.MaskedTextBox();
            this.groupBox_Date = new System.Windows.Forms.GroupBox();
            this.txtMToDate = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMFromDate = new System.Windows.Forms.MaskedTextBox();
            this.FlexType = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.txtCostNo = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.button_SrchCostNo = new DevComponents.DotNetBar.ButtonX();
            this.txtCostName = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.RButLandscape = new System.Windows.Forms.RadioButton();
            this.RButPortrait = new System.Windows.Forms.RadioButton();
            this.groupBox_OrderTyp = new System.Windows.Forms.GroupBox();
            this.radioButton_Delivery = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.radioButton_Out = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.radioButton_In = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.labelFooter = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton_Tax1 = new System.Windows.Forms.RadioButton();
            this.radioButton_Tax2 = new System.Windows.Forms.RadioButton();
            this.radioButton_Tax0 = new System.Windows.Forms.RadioButton();
            this.CmbDeleted = new System.Windows.Forms.GroupBox();
            this.radioButton_Del1 = new System.Windows.Forms.RadioButton();
            this.radioButton_Del2 = new System.Windows.Forms.RadioButton();
            this.radioButton_Del0 = new System.Windows.Forms.RadioButton();
            this.CmbReturn = new System.Windows.Forms.GroupBox();
            this.radioButton_ِReturn1 = new System.Windows.Forms.RadioButton();
            this.radioButton_ِReturn2 = new System.Windows.Forms.RadioButton();
            this.radioButton_ِReturn0 = new System.Windows.Forms.RadioButton();
            this.checkBox_DatePay = new System.Windows.Forms.CheckBox();
            this.netResize1 = new Softgroup.NetResize.NetResize(this.components);
            this.PanelSpecialContainer.SuspendLayout();
            this.ribbonBar1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ButOk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButExit)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox_Date.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FlexType)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox_OrderTyp.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.CmbDeleted.SuspendLayout();
            this.CmbReturn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelSpecialContainer
            // 
            this.PanelSpecialContainer.Controls.Add(this.checkBox2);
            this.PanelSpecialContainer.Controls.Add(this.checkBox1);
            this.PanelSpecialContainer.Controls.Add(this.ribbonBar1);
            this.PanelSpecialContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelSpecialContainer.Location = new System.Drawing.Point(0, 0);
            this.PanelSpecialContainer.Name = "PanelSpecialContainer";
            this.PanelSpecialContainer.Size = new System.Drawing.Size(582, 479);
            this.PanelSpecialContainer.TabIndex = 1220;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(431, 315);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(122, 17);
            this.checkBox2.TabIndex = 1101;
            this.checkBox2.Text = "اظهار السجل التجاري";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(304, 310);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(106, 17);
            this.checkBox1.TabIndex = 1100;
            this.checkBox1.Text = "فواتير المصروفات";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.Visible = false;
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
            this.ribbonBar1.Controls.Add(this.checkBox_CustomerNam);
            this.ribbonBar1.Controls.Add(this.combobox_RepType);
            this.ribbonBar1.Controls.Add(this.switchButton_OrderTyp);
            this.ribbonBar1.Controls.Add(this.label10);
            this.ribbonBar1.Controls.Add(this.combobox_SortTyp);
            this.ribbonBar1.Controls.Add(this.switchButton_CalclatTax);
            this.ribbonBar1.Controls.Add(this.RButShort2);
            this.ribbonBar1.Controls.Add(this.checkBox_Defalut);
            this.ribbonBar1.Controls.Add(this.checkBox_ItemComm);
            this.ribbonBar1.Controls.Add(this.checkBox_Note);
            this.ribbonBar1.Controls.Add(this.RButShort);
            this.ribbonBar1.Controls.Add(this.CmbInvType);
            this.ribbonBar1.Controls.Add(this.label9);
            this.ribbonBar1.Controls.Add(this.label7);
            this.ribbonBar1.Controls.Add(this.label6);
            this.ribbonBar1.Controls.Add(this.label5);
            this.ribbonBar1.Controls.Add(this.button_SrchUsrNo);
            this.ribbonBar1.Controls.Add(this.button_SrchLegNo);
            this.ribbonBar1.Controls.Add(this.button_SrchSuppNo);
            this.ribbonBar1.Controls.Add(this.button_SrchCustNo);
            this.ribbonBar1.Controls.Add(this.txtUserName);
            this.ribbonBar1.Controls.Add(this.txtUserNo);
            this.ribbonBar1.Controls.Add(this.txtLegName);
            this.ribbonBar1.Controls.Add(this.txtLegNo);
            this.ribbonBar1.Controls.Add(this.txtSuppName);
            this.ribbonBar1.Controls.Add(this.txtSuppNo);
            this.ribbonBar1.Controls.Add(this.txtCustName);
            this.ribbonBar1.Controls.Add(this.txtCustNo);
            this.ribbonBar1.Controls.Add(this.groupBox3);
            this.ribbonBar1.Controls.Add(this.groupBox_Date);
            this.ribbonBar1.Controls.Add(this.FlexType);
            this.ribbonBar1.Controls.Add(this.txtCostNo);
            this.ribbonBar1.Controls.Add(this.label8);
            this.ribbonBar1.Controls.Add(this.button_SrchCostNo);
            this.ribbonBar1.Controls.Add(this.txtCostName);
            this.ribbonBar1.Controls.Add(this.groupBox2);
            this.ribbonBar1.Controls.Add(this.groupBox_OrderTyp);
            this.ribbonBar1.Controls.Add(this.labelFooter);
            this.ribbonBar1.Controls.Add(this.groupBox1);
            this.ribbonBar1.Controls.Add(this.CmbDeleted);
            this.ribbonBar1.Controls.Add(this.CmbReturn);
            this.ribbonBar1.Controls.Add(this.checkBox_DatePay);
            this.ribbonBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonBar1.DragDropSupport = true;
            this.ribbonBar1.Location = new System.Drawing.Point(0, 0);
            this.ribbonBar1.Name = "ribbonBar1";
            this.ribbonBar1.Size = new System.Drawing.Size(582, 479);
            this.ribbonBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this.ribbonBar1.TabIndex = 1099;
            this.ribbonBar1.Tag = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
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
            this.ButOk.Location = new System.Drawing.Point(260, 432);
            this.ButOk.Name = "ButOk";
            this.ButOk.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ButOk.Size = new System.Drawing.Size(227, 27);
            this.ButOk.TabIndex = 6754;
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
            this.ButExit.Location = new System.Drawing.Point(75, 432);
            this.ButExit.Name = "ButExit";
            this.ButExit.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ButExit.Size = new System.Drawing.Size(179, 27);
            this.ButExit.TabIndex = 6753;
            this.ButExit.Text = "خروج | ESC";
            this.ButExit.UseVisualStyleBackColor = true;
            this.ButExit.Click += new System.EventHandler(this.ButExit_Click);
            this.ButExit.MouseLeave += new System.EventHandler(this.ButExit_MouseLeave);
            this.ButExit.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ButExit_MouseMove);
            // 
            // checkBox_CustomerNam
            // 
            // 
            // 
            // 
            this.checkBox_CustomerNam.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBox_CustomerNam.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.checkBox_CustomerNam.Location = new System.Drawing.Point(169, 333);
            this.checkBox_CustomerNam.Name = "checkBox_CustomerNam";
            this.checkBox_CustomerNam.Size = new System.Drawing.Size(129, 20);
            this.checkBox_CustomerNam.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBox_CustomerNam.TabIndex = 6752;
            this.checkBox_CustomerNam.Text = "إظهار العميل / المورد";
            this.checkBox_CustomerNam.CheckedChanged += new System.EventHandler(this.checkBox_CustomerNam_CheckedChanged);
            // 
            // combobox_RepType
            // 
            this.combobox_RepType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.combobox_RepType.DisplayMember = "Text";
            this.combobox_RepType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.combobox_RepType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combobox_RepType.Font = new System.Drawing.Font("Tahoma", 8F);
            this.combobox_RepType.FormattingEnabled = true;
            this.combobox_RepType.ItemHeight = 15;
            this.combobox_RepType.Location = new System.Drawing.Point(6, 226);
            this.combobox_RepType.Name = "combobox_RepType";
            this.combobox_RepType.Size = new System.Drawing.Size(292, 21);
            this.combobox_RepType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.combobox_RepType.TabIndex = 6751;
            this.combobox_RepType.SelectedIndexChanged += new System.EventHandler(this.combobox_RepType_SelectedIndexChanged);
            // 
            // switchButton_OrderTyp
            // 
            // 
            // 
            // 
            this.switchButton_OrderTyp.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.switchButton_OrderTyp.Location = new System.Drawing.Point(6, 399);
            this.switchButton_OrderTyp.Name = "switchButton_OrderTyp";
            this.switchButton_OrderTyp.OffBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(80)))), ((int)(((byte)(77)))));
            this.switchButton_OrderTyp.OffText = "خيارات نوع الطلب";
            this.switchButton_OrderTyp.OffTextColor = System.Drawing.Color.White;
            this.switchButton_OrderTyp.OnText = "خيارات نوع الطلب";
            this.switchButton_OrderTyp.Size = new System.Drawing.Size(159, 30);
            this.switchButton_OrderTyp.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.switchButton_OrderTyp.SwitchWidth = 25;
            this.switchButton_OrderTyp.TabIndex = 6748;
            this.switchButton_OrderTyp.ValueChanged += new System.EventHandler(this.switchButton_OrderTyp_ValueChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label10.Location = new System.Drawing.Point(486, 230);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(71, 13);
            this.label10.TabIndex = 6745;
            this.label10.Text = "ترتيب حسب :";
            // 
            // combobox_SortTyp
            // 
            this.combobox_SortTyp.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.combobox_SortTyp.DisplayMember = "Text";
            this.combobox_SortTyp.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.combobox_SortTyp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combobox_SortTyp.Font = new System.Drawing.Font("Tahoma", 8F);
            this.combobox_SortTyp.FormattingEnabled = true;
            this.combobox_SortTyp.ItemHeight = 15;
            this.combobox_SortTyp.Location = new System.Drawing.Point(304, 226);
            this.combobox_SortTyp.Name = "combobox_SortTyp";
            this.combobox_SortTyp.Size = new System.Drawing.Size(176, 21);
            this.combobox_SortTyp.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.combobox_SortTyp.TabIndex = 6744;
            // 
            // switchButton_CalclatTax
            // 
            // 
            // 
            // 
            this.switchButton_CalclatTax.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.switchButton_CalclatTax.Location = new System.Drawing.Point(304, 362);
            this.switchButton_CalclatTax.Name = "switchButton_CalclatTax";
            this.switchButton_CalclatTax.OffBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(80)))), ((int)(((byte)(77)))));
            this.switchButton_CalclatTax.OffText = "حساب الربح مع الضريبة";
            this.switchButton_CalclatTax.OffTextColor = System.Drawing.Color.White;
            this.switchButton_CalclatTax.OnText = "حساب الربح مع الضريبة";
            this.switchButton_CalclatTax.Size = new System.Drawing.Size(255, 35);
            this.switchButton_CalclatTax.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.switchButton_CalclatTax.SwitchWidth = 25;
            this.switchButton_CalclatTax.TabIndex = 6742;
            // 
            // RButShort2
            // 
            // 
            // 
            // 
            this.RButShort2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.RButShort2.Location = new System.Drawing.Point(6, 374);
            this.RButShort2.Name = "RButShort2";
            this.RButShort2.OffBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(80)))), ((int)(((byte)(77)))));
            this.RButShort2.OffText = "مختصـــر";
            this.RButShort2.OffTextColor = System.Drawing.Color.White;
            this.RButShort2.OnText = "مختصـــر";
            this.RButShort2.Size = new System.Drawing.Size(159, 24);
            this.RButShort2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.RButShort2.SwitchWidth = 25;
            this.RButShort2.TabIndex = 6740;
            this.RButShort2.ValueChanging += new System.EventHandler(this.RButShort2_ValueChanging);
            this.RButShort2.ValueChanged += new System.EventHandler(this.RButShort2_ValueChanged);
            // 
            // checkBox_Defalut
            // 
            // 
            // 
            // 
            this.checkBox_Defalut.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBox_Defalut.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.checkBox_Defalut.Checked = true;
            this.checkBox_Defalut.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_Defalut.CheckValue = "Y";
            this.checkBox_Defalut.Location = new System.Drawing.Point(169, 354);
            this.checkBox_Defalut.Name = "checkBox_Defalut";
            this.checkBox_Defalut.Size = new System.Drawing.Size(129, 20);
            this.checkBox_Defalut.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBox_Defalut.TabIndex = 6739;
            this.checkBox_Defalut.Text = "الإفتــــراضي";
            // 
            // checkBox_ItemComm
            // 
            // 
            // 
            // 
            this.checkBox_ItemComm.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBox_ItemComm.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.checkBox_ItemComm.Location = new System.Drawing.Point(169, 312);
            this.checkBox_ItemComm.Name = "checkBox_ItemComm";
            this.checkBox_ItemComm.Size = new System.Drawing.Size(129, 20);
            this.checkBox_ItemComm.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBox_ItemComm.TabIndex = 6738;
            this.checkBox_ItemComm.Text = "إظهار عمـــولات الصنف";
            this.checkBox_ItemComm.CheckedChanged += new System.EventHandler(this.checkBox_Note_CheckedChanged);
            // 
            // checkBox_Note
            // 
            // 
            // 
            // 
            this.checkBox_Note.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBox_Note.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.checkBox_Note.Location = new System.Drawing.Point(169, 291);
            this.checkBox_Note.Name = "checkBox_Note";
            this.checkBox_Note.Size = new System.Drawing.Size(129, 20);
            this.checkBox_Note.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBox_Note.TabIndex = 6737;
            this.checkBox_Note.Text = "إظهار عمود الملاحظات";
            this.checkBox_Note.CheckedChanged += new System.EventHandler(this.checkBox_Note_CheckedChanged);
            // 
            // RButShort
            // 
            // 
            // 
            // 
            this.RButShort.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.RButShort.Location = new System.Drawing.Point(6, 348);
            this.RButShort.Name = "RButShort";
            this.RButShort.OffBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(80)))), ((int)(((byte)(77)))));
            this.RButShort.OffText = "حسب التاريخ";
            this.RButShort.OffTextColor = System.Drawing.Color.White;
            this.RButShort.OnText = "حسب التاريخ";
            this.RButShort.Size = new System.Drawing.Size(159, 24);
            this.RButShort.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.RButShort.SwitchWidth = 25;
            this.RButShort.TabIndex = 6733;
            this.RButShort.ValueChanging += new System.EventHandler(this.RButShort_ValueChanging);
            this.RButShort.ValueChanged += new System.EventHandler(this.RButShort_ValueChanged);
            // 
            // CmbInvType
            // 
            this.CmbInvType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbInvType.DisplayMember = "Text";
            this.CmbInvType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.CmbInvType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbInvType.FormattingEnabled = true;
            this.CmbInvType.ItemHeight = 15;
            this.CmbInvType.Location = new System.Drawing.Point(5, 327);
            this.CmbInvType.Name = "CmbInvType";
            this.CmbInvType.Size = new System.Drawing.Size(159, 21);
            this.CmbInvType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.CmbInvType.TabIndex = 1175;
            this.CmbInvType.SelectedIndexChanged += new System.EventHandler(this.CmbInvType_SelectedIndexChanged);
            this.CmbInvType.SelectedValueChanged += new System.EventHandler(this.CmbInvType_SelectedValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label9.Location = new System.Drawing.Point(486, 182);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 13);
            this.label9.TabIndex = 1174;
            this.label9.Text = "المستخـــدم :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(486, 159);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 13);
            this.label7.TabIndex = 1173;
            this.label7.Text = "المنـــــــدوب :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(486, 136);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 13);
            this.label6.TabIndex = 1172;
            this.label6.Text = "المــــــــــورد :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(486, 113);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 1171;
            this.label5.Text = "العميـــــــــل :";
            // 
            // button_SrchUsrNo
            // 
            this.button_SrchUsrNo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchUsrNo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchUsrNo.Location = new System.Drawing.Point(373, 178);
            this.button_SrchUsrNo.Name = "button_SrchUsrNo";
            this.button_SrchUsrNo.Size = new System.Drawing.Size(26, 20);
            this.button_SrchUsrNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchUsrNo.Symbol = "";
            this.button_SrchUsrNo.SymbolSize = 12F;
            this.button_SrchUsrNo.TabIndex = 15;
            this.button_SrchUsrNo.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchUsrNo.Click += new System.EventHandler(this.button_SrchUsrNo_Click);
            // 
            // button_SrchLegNo
            // 
            this.button_SrchLegNo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchLegNo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchLegNo.Location = new System.Drawing.Point(373, 155);
            this.button_SrchLegNo.Name = "button_SrchLegNo";
            this.button_SrchLegNo.Size = new System.Drawing.Size(26, 20);
            this.button_SrchLegNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchLegNo.Symbol = "";
            this.button_SrchLegNo.SymbolSize = 12F;
            this.button_SrchLegNo.TabIndex = 12;
            this.button_SrchLegNo.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchLegNo.Click += new System.EventHandler(this.button_SrchLegNo_Click);
            // 
            // button_SrchSuppNo
            // 
            this.button_SrchSuppNo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchSuppNo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchSuppNo.Location = new System.Drawing.Point(373, 132);
            this.button_SrchSuppNo.Name = "button_SrchSuppNo";
            this.button_SrchSuppNo.Size = new System.Drawing.Size(26, 20);
            this.button_SrchSuppNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchSuppNo.Symbol = "";
            this.button_SrchSuppNo.SymbolSize = 12F;
            this.button_SrchSuppNo.TabIndex = 9;
            this.button_SrchSuppNo.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchSuppNo.Click += new System.EventHandler(this.button_SrchSuppNo_Click);
            // 
            // button_SrchCustNo
            // 
            this.button_SrchCustNo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchCustNo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchCustNo.Location = new System.Drawing.Point(373, 109);
            this.button_SrchCustNo.Name = "button_SrchCustNo";
            this.button_SrchCustNo.Size = new System.Drawing.Size(26, 20);
            this.button_SrchCustNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchCustNo.Symbol = "";
            this.button_SrchCustNo.SymbolSize = 12F;
            this.button_SrchCustNo.TabIndex = 6;
            this.button_SrchCustNo.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchCustNo.Click += new System.EventHandler(this.button_SrchCustNo_Click);
            // 
            // txtUserName
            // 
            this.txtUserName.BackColor = System.Drawing.Color.Ivory;
            this.txtUserName.ForeColor = System.Drawing.Color.White;
            this.txtUserName.Location = new System.Drawing.Point(6, 178);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtUserName, false);
            this.txtUserName.Size = new System.Drawing.Size(364, 20);
            this.txtUserName.TabIndex = 16;
            this.txtUserName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtUserNo
            // 
            this.txtUserNo.BackColor = System.Drawing.Color.White;
            this.txtUserNo.Location = new System.Drawing.Point(401, 178);
            this.txtUserNo.Name = "txtUserNo";
            this.txtUserNo.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtUserNo, false);
            this.txtUserNo.Size = new System.Drawing.Size(79, 20);
            this.txtUserNo.TabIndex = 14;
            this.txtUserNo.Tag = " T_INVHED.SalsManNo ";
            this.txtUserNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtLegName
            // 
            this.txtLegName.BackColor = System.Drawing.Color.Ivory;
            this.txtLegName.ForeColor = System.Drawing.Color.White;
            this.txtLegName.Location = new System.Drawing.Point(6, 155);
            this.txtLegName.Name = "txtLegName";
            this.txtLegName.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtLegName, false);
            this.txtLegName.Size = new System.Drawing.Size(364, 20);
            this.txtLegName.TabIndex = 13;
            this.txtLegName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtLegNo
            // 
            this.txtLegNo.BackColor = System.Drawing.Color.White;
            this.txtLegNo.Location = new System.Drawing.Point(401, 155);
            this.txtLegNo.Name = "txtLegNo";
            this.txtLegNo.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtLegNo, false);
            this.txtLegNo.Size = new System.Drawing.Size(79, 20);
            this.txtLegNo.TabIndex = 11;
            this.txtLegNo.Tag = "T_INVHED.MndNo ";
            this.txtLegNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtSuppName
            // 
            this.txtSuppName.BackColor = System.Drawing.Color.Ivory;
            this.txtSuppName.ForeColor = System.Drawing.Color.White;
            this.txtSuppName.Location = new System.Drawing.Point(6, 132);
            this.txtSuppName.Name = "txtSuppName";
            this.txtSuppName.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtSuppName, false);
            this.txtSuppName.Size = new System.Drawing.Size(364, 20);
            this.txtSuppName.TabIndex = 10;
            this.txtSuppName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtSuppNo
            // 
            this.txtSuppNo.BackColor = System.Drawing.Color.White;
            this.txtSuppNo.Location = new System.Drawing.Point(401, 132);
            this.txtSuppNo.Name = "txtSuppNo";
            this.txtSuppNo.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtSuppNo, false);
            this.txtSuppNo.Size = new System.Drawing.Size(79, 20);
            this.txtSuppNo.TabIndex = 8;
            this.txtSuppNo.Tag = " T_INVHED.CusVenNo ";
            this.txtSuppNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtCustName
            // 
            this.txtCustName.BackColor = System.Drawing.Color.Ivory;
            this.txtCustName.ForeColor = System.Drawing.Color.White;
            this.txtCustName.Location = new System.Drawing.Point(6, 109);
            this.txtCustName.Name = "txtCustName";
            this.txtCustName.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtCustName, false);
            this.txtCustName.Size = new System.Drawing.Size(364, 20);
            this.txtCustName.TabIndex = 7;
            this.txtCustName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCustName.TextChanged += new System.EventHandler(this.txtCustName_TextChanged);
            // 
            // txtCustNo
            // 
            this.txtCustNo.BackColor = System.Drawing.Color.White;
            this.txtCustNo.Location = new System.Drawing.Point(401, 109);
            this.txtCustNo.Name = "txtCustNo";
            this.txtCustNo.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtCustNo, false);
            this.txtCustNo.Size = new System.Drawing.Size(79, 20);
            this.txtCustNo.TabIndex = 5;
            this.txtCustNo.Tag = " T_INVHED.CusVenNo ";
            this.txtCustNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.txtMIntoNo);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.txtMFromNo);
            this.groupBox3.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.groupBox3.Location = new System.Drawing.Point(3, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(554, 48);
            this.groupBox3.TabIndex = 1162;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "حسب رقم الفاتورة";
            // 
            // txtMIntoNo
            // 
            this.txtMIntoNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtMIntoNo.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtMIntoNo.Location = new System.Drawing.Point(55, 19);
            this.txtMIntoNo.Name = "txtMIntoNo";
            this.txtMIntoNo.Size = new System.Drawing.Size(122, 22);
            this.txtMIntoNo.TabIndex = 2;
            this.txtMIntoNo.Tag = " T_INVHED.InvNo ";
            this.txtMIntoNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMIntoNo.Click += new System.EventHandler(this.txtMIntoNo_Click);
            this.txtMIntoNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMIntoNo_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(447, 24);
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
            this.label2.Location = new System.Drawing.Point(183, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 859;
            this.label2.Text = "إلـــــى :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMFromNo
            // 
            this.txtMFromNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtMFromNo.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtMFromNo.Location = new System.Drawing.Point(319, 19);
            this.txtMFromNo.Name = "txtMFromNo";
            this.txtMFromNo.Size = new System.Drawing.Size(122, 22);
            this.txtMFromNo.TabIndex = 1;
            this.txtMFromNo.Tag = " T_INVHED.InvNo ";
            this.txtMFromNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMFromNo.Click += new System.EventHandler(this.txtMFromNo_Click);
            this.txtMFromNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMFromNo_KeyPress);
            // 
            // groupBox_Date
            // 
            this.groupBox_Date.BackColor = System.Drawing.Color.Transparent;
            this.groupBox_Date.Controls.Add(this.txtMToDate);
            this.groupBox_Date.Controls.Add(this.label3);
            this.groupBox_Date.Controls.Add(this.label4);
            this.groupBox_Date.Controls.Add(this.txtMFromDate);
            this.groupBox_Date.Location = new System.Drawing.Point(6, 56);
            this.groupBox_Date.Name = "groupBox_Date";
            this.groupBox_Date.Size = new System.Drawing.Size(554, 48);
            this.groupBox_Date.TabIndex = 1161;
            this.groupBox_Date.TabStop = false;
            this.groupBox_Date.Text = "حسب تاريخ الفاتورة";
            this.groupBox_Date.Enter += new System.EventHandler(this.groupBox_Date_Enter);
            // 
            // txtMToDate
            // 
            this.txtMToDate.Location = new System.Drawing.Point(55, 19);
            this.txtMToDate.Mask = "0000/00/00";
            this.txtMToDate.Name = "txtMToDate";
            this.txtMToDate.Size = new System.Drawing.Size(122, 20);
            this.txtMToDate.TabIndex = 4;
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
            this.label3.Location = new System.Drawing.Point(447, 23);
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
            this.label4.Location = new System.Drawing.Point(183, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 861;
            this.label4.Text = "إلـــــى :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMFromDate
            // 
            this.txtMFromDate.Location = new System.Drawing.Point(319, 19);
            this.txtMFromDate.Mask = "0000/00/00";
            this.txtMFromDate.Name = "txtMFromDate";
            this.txtMFromDate.Size = new System.Drawing.Size(122, 20);
            this.txtMFromDate.TabIndex = 3;
            this.txtMFromDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMFromDate.Click += new System.EventHandler(this.txtMFromDate_Click);
            this.txtMFromDate.Leave += new System.EventHandler(this.txtMFromDate_Leave);
            // 
            // FlexType
            // 
            this.FlexType.BackColor = System.Drawing.Color.White;
            this.FlexType.ColumnInfo = resources.GetString("FlexType.ColumnInfo");
            this.FlexType.Font = new System.Drawing.Font("Tahoma", 8F);
            this.FlexType.Location = new System.Drawing.Point(5, 252);
            this.FlexType.Name = "FlexType";
            this.FlexType.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.FlexType.Rows.Count = 3;
            this.FlexType.Rows.DefaultSize = 19;
            this.FlexType.Rows.Fixed = 0;
            this.FlexType.Size = new System.Drawing.Size(159, 73);
            this.FlexType.StyleInfo = resources.GetString("FlexType.StyleInfo");
            this.FlexType.TabIndex = 28;
            this.FlexType.Tag = " T_INVHED.InvCashPay ";
            this.FlexType.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.System;
            // 
            // txtCostNo
            // 
            this.txtCostNo.BackColor = System.Drawing.Color.White;
            this.txtCostNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtCostNo.Location = new System.Drawing.Point(401, 201);
            this.txtCostNo.MaxLength = 30;
            this.txtCostNo.Name = "txtCostNo";
            this.txtCostNo.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtCostNo, false);
            this.txtCostNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtCostNo.Size = new System.Drawing.Size(79, 20);
            this.txtCostNo.TabIndex = 17;
            this.txtCostNo.Tag = "  T_INVHED.InvCstNo ";
            this.txtCostNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(486, 205);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 13);
            this.label8.TabIndex = 1170;
            this.label8.Text = "مركز التكلفة :";
            // 
            // button_SrchCostNo
            // 
            this.button_SrchCostNo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchCostNo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchCostNo.Location = new System.Drawing.Point(373, 201);
            this.button_SrchCostNo.Name = "button_SrchCostNo";
            this.button_SrchCostNo.Size = new System.Drawing.Size(26, 20);
            this.button_SrchCostNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchCostNo.Symbol = "";
            this.button_SrchCostNo.SymbolSize = 12F;
            this.button_SrchCostNo.TabIndex = 18;
            this.button_SrchCostNo.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchCostNo.Click += new System.EventHandler(this.button_SrchCostNo_Click);
            // 
            // txtCostName
            // 
            this.txtCostName.BackColor = System.Drawing.Color.Ivory;
            this.txtCostName.ForeColor = System.Drawing.Color.White;
            this.txtCostName.Location = new System.Drawing.Point(6, 201);
            this.txtCostName.Name = "txtCostName";
            this.txtCostName.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtCostName, false);
            this.txtCostName.Size = new System.Drawing.Size(364, 20);
            this.txtCostName.TabIndex = 19;
            this.txtCostName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.RButLandscape);
            this.groupBox2.Controls.Add(this.RButPortrait);
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.groupBox2.Location = new System.Drawing.Point(169, 246);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(131, 40);
            this.groupBox2.TabIndex = 6732;
            this.groupBox2.TabStop = false;
            // 
            // RButLandscape
            // 
            this.RButLandscape.AutoSize = true;
            this.RButLandscape.Checked = true;
            this.RButLandscape.Font = new System.Drawing.Font("Tahoma", 8F);
            this.RButLandscape.ForeColor = System.Drawing.Color.SteelBlue;
            this.RButLandscape.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.RButLandscape.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.RButLandscape.Location = new System.Drawing.Point(4, 16);
            this.RButLandscape.Name = "RButLandscape";
            this.RButLandscape.Size = new System.Drawing.Size(57, 17);
            this.RButLandscape.TabIndex = 1008;
            this.RButLandscape.TabStop = true;
            this.RButLandscape.Text = "عرضي";
            this.RButLandscape.UseVisualStyleBackColor = true;
            this.RButLandscape.CheckedChanged += new System.EventHandler(this.RButPortrait_CheckedChanged);
            // 
            // RButPortrait
            // 
            this.RButPortrait.AutoSize = true;
            this.RButPortrait.Font = new System.Drawing.Font("Tahoma", 8F);
            this.RButPortrait.ForeColor = System.Drawing.Color.SteelBlue;
            this.RButPortrait.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.RButPortrait.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.RButPortrait.Location = new System.Drawing.Point(72, 16);
            this.RButPortrait.Name = "RButPortrait";
            this.RButPortrait.Size = new System.Drawing.Size(51, 17);
            this.RButPortrait.TabIndex = 1007;
            this.RButPortrait.Text = "طولي";
            this.RButPortrait.UseVisualStyleBackColor = true;
            this.RButPortrait.CheckedChanged += new System.EventHandler(this.RButPortrait_CheckedChanged);
            // 
            // groupBox_OrderTyp
            // 
            this.groupBox_OrderTyp.BackColor = System.Drawing.Color.Transparent;
            this.groupBox_OrderTyp.Controls.Add(this.radioButton_Delivery);
            this.groupBox_OrderTyp.Controls.Add(this.radioButton_Out);
            this.groupBox_OrderTyp.Controls.Add(this.radioButton_In);
            this.groupBox_OrderTyp.Enabled = false;
            this.groupBox_OrderTyp.Location = new System.Drawing.Point(169, 392);
            this.groupBox_OrderTyp.Name = "groupBox_OrderTyp";
            this.groupBox_OrderTyp.Size = new System.Drawing.Size(390, 37);
            this.groupBox_OrderTyp.TabIndex = 6746;
            this.groupBox_OrderTyp.TabStop = false;
            this.groupBox_OrderTyp.Tag = " T_INVHED.IfRet ";
            // 
            // radioButton_Delivery
            // 
            // 
            // 
            // 
            this.radioButton_Delivery.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.radioButton_Delivery.Location = new System.Drawing.Point(22, 14);
            this.radioButton_Delivery.Name = "radioButton_Delivery";
            this.radioButton_Delivery.Size = new System.Drawing.Size(78, 17);
            this.radioButton_Delivery.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.radioButton_Delivery.TabIndex = 6740;
            this.radioButton_Delivery.Text = "طلب توصيل";
            this.radioButton_Delivery.TextColor = System.Drawing.Color.Black;
            // 
            // radioButton_Out
            // 
            // 
            // 
            // 
            this.radioButton_Out.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.radioButton_Out.Location = new System.Drawing.Point(162, 14);
            this.radioButton_Out.Name = "radioButton_Out";
            this.radioButton_Out.Size = new System.Drawing.Size(72, 17);
            this.radioButton_Out.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.radioButton_Out.TabIndex = 6739;
            this.radioButton_Out.Text = "سفـــــري";
            this.radioButton_Out.TextColor = System.Drawing.Color.Black;
            // 
            // radioButton_In
            // 
            // 
            // 
            // 
            this.radioButton_In.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.radioButton_In.Checked = true;
            this.radioButton_In.CheckState = System.Windows.Forms.CheckState.Checked;
            this.radioButton_In.CheckValue = "Y";
            this.radioButton_In.Location = new System.Drawing.Point(296, 14);
            this.radioButton_In.Name = "radioButton_In";
            this.radioButton_In.Size = new System.Drawing.Size(62, 17);
            this.radioButton_In.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.radioButton_In.TabIndex = 6738;
            this.radioButton_In.Text = "محلـــيً";
            this.radioButton_In.TextColor = System.Drawing.Color.Black;
            // 
            // labelFooter
            // 
            this.labelFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.labelFooter.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.labelFooter.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelFooter.Location = new System.Drawing.Point(6, 403);
            this.labelFooter.Name = "labelFooter";
            this.labelFooter.Size = new System.Drawing.Size(554, 23);
            this.labelFooter.TabIndex = 6747;
            this.labelFooter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.radioButton_Tax1);
            this.groupBox1.Controls.Add(this.radioButton_Tax2);
            this.groupBox1.Controls.Add(this.radioButton_Tax0);
            this.groupBox1.Location = new System.Drawing.Point(304, 245);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(254, 40);
            this.groupBox1.TabIndex = 6749;
            this.groupBox1.TabStop = false;
            this.groupBox1.Tag = " T_INVHED.IfRet ";
            // 
            // radioButton_Tax1
            // 
            this.radioButton_Tax1.AutoSize = true;
            this.radioButton_Tax1.Checked = true;
            this.radioButton_Tax1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radioButton_Tax1.Location = new System.Drawing.Point(6, 14);
            this.radioButton_Tax1.Name = "radioButton_Tax1";
            this.radioButton_Tax1.Size = new System.Drawing.Size(54, 17);
            this.radioButton_Tax1.TabIndex = 31;
            this.radioButton_Tax1.TabStop = true;
            this.radioButton_Tax1.Text = "الكـــل";
            this.radioButton_Tax1.UseVisualStyleBackColor = true;
            // 
            // radioButton_Tax2
            // 
            this.radioButton_Tax2.AutoSize = true;
            this.radioButton_Tax2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radioButton_Tax2.Location = new System.Drawing.Point(74, 14);
            this.radioButton_Tax2.Name = "radioButton_Tax2";
            this.radioButton_Tax2.Size = new System.Drawing.Size(83, 17);
            this.radioButton_Tax2.TabIndex = 30;
            this.radioButton_Tax2.Text = "بدون الضريبة";
            this.radioButton_Tax2.UseVisualStyleBackColor = true;
            // 
            // radioButton_Tax0
            // 
            this.radioButton_Tax0.AutoSize = true;
            this.radioButton_Tax0.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radioButton_Tax0.Location = new System.Drawing.Point(186, 14);
            this.radioButton_Tax0.Name = "radioButton_Tax0";
            this.radioButton_Tax0.Size = new System.Drawing.Size(63, 17);
            this.radioButton_Tax0.TabIndex = 29;
            this.radioButton_Tax0.Text = "بالضريبة";
            this.radioButton_Tax0.UseVisualStyleBackColor = true;
            // 
            // CmbDeleted
            // 
            this.CmbDeleted.BackColor = System.Drawing.Color.Transparent;
            this.CmbDeleted.Controls.Add(this.radioButton_Del1);
            this.CmbDeleted.Controls.Add(this.radioButton_Del2);
            this.CmbDeleted.Controls.Add(this.radioButton_Del0);
            this.CmbDeleted.Location = new System.Drawing.Point(280, 282);
            this.CmbDeleted.Name = "CmbDeleted";
            this.CmbDeleted.Size = new System.Drawing.Size(296, 40);
            this.CmbDeleted.TabIndex = 6730;
            this.CmbDeleted.TabStop = false;
            this.CmbDeleted.Tag = " T_INVHED.IfDel ";
            // 
            // radioButton_Del1
            // 
            this.radioButton_Del1.AutoSize = true;
            this.radioButton_Del1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radioButton_Del1.Location = new System.Drawing.Point(-60, 23);
            this.radioButton_Del1.Name = "radioButton_Del1";
            this.radioButton_Del1.Size = new System.Drawing.Size(54, 17);
            this.radioButton_Del1.TabIndex = 28;
            this.radioButton_Del1.Text = "الكـــل";
            this.radioButton_Del1.UseVisualStyleBackColor = true;
            this.radioButton_Del1.Visible = false;
            // 
            // radioButton_Del2
            // 
            this.radioButton_Del2.AutoSize = true;
            this.radioButton_Del2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radioButton_Del2.Location = new System.Drawing.Point(98, 15);
            this.radioButton_Del2.Name = "radioButton_Del2";
            this.radioButton_Del2.Size = new System.Drawing.Size(86, 17);
            this.radioButton_Del2.TabIndex = 27;
            this.radioButton_Del2.Text = "المحذوفة فقط";
            this.radioButton_Del2.UseVisualStyleBackColor = true;
            // 
            // radioButton_Del0
            // 
            this.radioButton_Del0.AutoSize = true;
            this.radioButton_Del0.Checked = true;
            this.radioButton_Del0.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radioButton_Del0.Location = new System.Drawing.Point(194, 15);
            this.radioButton_Del0.Name = "radioButton_Del0";
            this.radioButton_Del0.Size = new System.Drawing.Size(83, 17);
            this.radioButton_Del0.TabIndex = 26;
            this.radioButton_Del0.TabStop = true;
            this.radioButton_Del0.Text = "الغير محذوفة";
            this.radioButton_Del0.UseVisualStyleBackColor = true;
            // 
            // CmbReturn
            // 
            this.CmbReturn.BackColor = System.Drawing.Color.Transparent;
            this.CmbReturn.Controls.Add(this.radioButton_ِReturn1);
            this.CmbReturn.Controls.Add(this.radioButton_ِReturn2);
            this.CmbReturn.Controls.Add(this.radioButton_ِReturn0);
            this.CmbReturn.Location = new System.Drawing.Point(304, 319);
            this.CmbReturn.Name = "CmbReturn";
            this.CmbReturn.Size = new System.Drawing.Size(254, 40);
            this.CmbReturn.TabIndex = 6731;
            this.CmbReturn.TabStop = false;
            this.CmbReturn.Tag = " T_INVHED.IfRet ";
            // 
            // radioButton_ِReturn1
            // 
            this.radioButton_ِReturn1.AutoSize = true;
            this.radioButton_ِReturn1.Checked = true;
            this.radioButton_ِReturn1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radioButton_ِReturn1.Location = new System.Drawing.Point(6, 14);
            this.radioButton_ِReturn1.Name = "radioButton_ِReturn1";
            this.radioButton_ِReturn1.Size = new System.Drawing.Size(54, 17);
            this.radioButton_ِReturn1.TabIndex = 31;
            this.radioButton_ِReturn1.TabStop = true;
            this.radioButton_ِReturn1.Text = "الكـــل";
            this.radioButton_ِReturn1.UseVisualStyleBackColor = true;
            // 
            // radioButton_ِReturn2
            // 
            this.radioButton_ِReturn2.AutoSize = true;
            this.radioButton_ِReturn2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radioButton_ِReturn2.Location = new System.Drawing.Point(69, 14);
            this.radioButton_ِReturn2.Name = "radioButton_ِReturn2";
            this.radioButton_ِReturn2.Size = new System.Drawing.Size(84, 17);
            this.radioButton_ِReturn2.TabIndex = 30;
            this.radioButton_ِReturn2.Text = "المرتجعة فقط";
            this.radioButton_ِReturn2.UseVisualStyleBackColor = true;
            // 
            // radioButton_ِReturn0
            // 
            this.radioButton_ِReturn0.AutoSize = true;
            this.radioButton_ِReturn0.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radioButton_ِReturn0.Location = new System.Drawing.Point(165, 14);
            this.radioButton_ِReturn0.Name = "radioButton_ِReturn0";
            this.radioButton_ِReturn0.Size = new System.Drawing.Size(81, 17);
            this.radioButton_ِReturn0.TabIndex = 29;
            this.radioButton_ِReturn0.Text = "الغير مرتجعة";
            this.radioButton_ِReturn0.UseVisualStyleBackColor = true;
            // 
            // checkBox_DatePay
            // 
            this.checkBox_DatePay.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.checkBox_DatePay.Location = new System.Drawing.Point(169, 375);
            this.checkBox_DatePay.Name = "checkBox_DatePay";
            this.checkBox_DatePay.Size = new System.Drawing.Size(129, 20);
            this.checkBox_DatePay.TabIndex = 6743;
            this.checkBox_DatePay.Text = "بتاريخ الاستحقاق";
            this.checkBox_DatePay.UseVisualStyleBackColor = true;
            this.checkBox_DatePay.CheckedChanged += new System.EventHandler(this.checkBox_DatePay_CheckedChanged);
            // 
            // netResize1
            // 
            this.netResize1.LabelsAutoEllipse = false;
            this.netResize1.ParentControl = this;
            this.netResize1.AfterControlResize += new Softgroup.NetResize.NetResize.AfterControlResizeEventHandler(this.netResize1_AfterControlResize);
            // 
            // FRInvoice
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(582, 479);
            this.Controls.Add(this.PanelSpecialContainer);
            this.Icon = global::InvAcc.Properties.Resources.favicon;
            this.KeyPreview = true;
            this.Name = "FRInvoice";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Activated += new System.EventHandler(this.FRInvoice_Activated);
            this.Load += new System.EventHandler(this.FRInvoice_Load);
            this.Shown += new System.EventHandler(this.FRInvoice_Shown);
            this.SizeChanged += new System.EventHandler(this.FrmInvSale_SizeChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Frm_KeyPress);
            this.PanelSpecialContainer.ResumeLayout(false);
            this.PanelSpecialContainer.PerformLayout();
            this.ribbonBar1.ResumeLayout(false);
            this.ribbonBar1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ButOk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButExit)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox_Date.ResumeLayout(false);
            this.groupBox_Date.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FlexType)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox_OrderTyp.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.CmbDeleted.ResumeLayout(false);
            this.CmbDeleted.PerformLayout();
            this.CmbReturn.ResumeLayout(false);
            this.CmbReturn.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).EndInit();
            this.ResumeLayout(false);

        }//###########&&&&&&&&&&

        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
    }
}
