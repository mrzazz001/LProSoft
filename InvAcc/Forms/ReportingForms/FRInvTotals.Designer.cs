   

namespace InvAcc.Forms
{
partial class FRInvTotals
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRInvTotals));
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtMToDate = new System.Windows.Forms.MaskedTextBox();
            this.txtMFromDate = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.PanelSpecialContainer = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.FlexType = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.txtCustNo = new System.Windows.Forms.TextBox();
            this.CmbDeleted = new System.Windows.Forms.GroupBox();
            this.radioButton_Del1 = new System.Windows.Forms.RadioButton();
            this.radioButton_Del2 = new System.Windows.Forms.RadioButton();
            this.radioButton_Del0 = new System.Windows.Forms.RadioButton();
            this.CmbReturn = new System.Windows.Forms.GroupBox();
            this.radioButton_ِReturn1 = new System.Windows.Forms.RadioButton();
            this.radioButton_ِReturn2 = new System.Windows.Forms.RadioButton();
            this.radioButton_ِReturn0 = new System.Windows.Forms.RadioButton();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button_SrchUsrNo = new DevComponents.DotNetBar.ButtonX();
            this.button_SrchLegNo = new DevComponents.DotNetBar.ButtonX();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtUserNo = new System.Windows.Forms.TextBox();
            this.txtLegName = new System.Windows.Forms.TextBox();
            this.txtLegNo = new System.Windows.Forms.TextBox();
            this.txtSuppName = new System.Windows.Forms.TextBox();
            this.txtSuppNo = new System.Windows.Forms.TextBox();
            this.radioButton_Tax1 = new System.Windows.Forms.RadioButton();
            this.radioButton_Tax2 = new System.Windows.Forms.RadioButton();
            this.ButOk = new C1.Win.C1Input.C1Button();
            this.radioButton_Tax0 = new System.Windows.Forms.RadioButton();
            this.ButExit = new C1.Win.C1Input.C1Button();
            this.button_SrchCustNo = new DevComponents.DotNetBar.ButtonX();
            this.button_SrchSuppNo = new DevComponents.DotNetBar.ButtonX();
            this.netResize1 = new Softgroup.NetResize.NetResize(this.components);
            this.txtCustName = new System.Windows.Forms.TextBox();
            this.groupBox4.SuspendLayout();
            this.PanelSpecialContainer.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FlexType)).BeginInit();
            this.CmbDeleted.SuspendLayout();
            this.CmbReturn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ButOk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.Transparent;
            this.groupBox4.Controls.Add(this.txtMToDate);
            this.groupBox4.Controls.Add(this.txtMFromDate);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.groupBox4.Location = new System.Drawing.Point(50, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(412, 52);
            this.groupBox4.TabIndex = 1109;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "حسب التاريخ";
            // 
            // txtMToDate
            // 
            this.txtMToDate.Location = new System.Drawing.Point(23, 21);
            this.txtMToDate.Mask = "0000/00/00";
            this.txtMToDate.Name = "txtMToDate";
            this.txtMToDate.Size = new System.Drawing.Size(108, 21);
            this.txtMToDate.TabIndex = 2;
            this.txtMToDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMToDate.Click += new System.EventHandler(this.txtMToDate_Click);
            this.txtMToDate.Leave += new System.EventHandler(this.txtMToDate_Leave);
            // 
            // txtMFromDate
            // 
            this.txtMFromDate.Location = new System.Drawing.Point(220, 21);
            this.txtMFromDate.Mask = "0000/00/00";
            this.txtMFromDate.Name = "txtMFromDate";
            this.txtMFromDate.Size = new System.Drawing.Size(108, 21);
            this.txtMFromDate.TabIndex = 1;
            this.txtMFromDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMFromDate.Click += new System.EventHandler(this.txtMFromDate_Click);
            this.txtMFromDate.Leave += new System.EventHandler(this.txtMFromDate_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(335, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 860;
            this.label1.Text = "مـــــن :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(137, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 861;
            this.label2.Text = "إلـــــى :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PanelSpecialContainer
            // 
            this.PanelSpecialContainer.Controls.Add(this.groupBox1);
            this.PanelSpecialContainer.Controls.Add(this.label5);
            this.PanelSpecialContainer.Controls.Add(this.FlexType);
            this.PanelSpecialContainer.Controls.Add(this.txtCustNo);
            this.PanelSpecialContainer.Controls.Add(this.CmbDeleted);
            this.PanelSpecialContainer.Controls.Add(this.CmbReturn);
            this.PanelSpecialContainer.Controls.Add(this.label9);
            this.PanelSpecialContainer.Controls.Add(this.label7);
            this.PanelSpecialContainer.Controls.Add(this.label6);
            this.PanelSpecialContainer.Controls.Add(this.button_SrchUsrNo);
            this.PanelSpecialContainer.Controls.Add(this.button_SrchLegNo);
            this.PanelSpecialContainer.Controls.Add(this.txtUserName);
            this.PanelSpecialContainer.Controls.Add(this.txtUserNo);
            this.PanelSpecialContainer.Controls.Add(this.txtLegName);
            this.PanelSpecialContainer.Controls.Add(this.txtLegNo);
            this.PanelSpecialContainer.Controls.Add(this.txtSuppName);
            this.PanelSpecialContainer.Controls.Add(this.txtSuppNo);
            this.PanelSpecialContainer.Controls.Add(this.radioButton_Tax1);
            this.PanelSpecialContainer.Controls.Add(this.radioButton_Tax2);
            this.PanelSpecialContainer.Controls.Add(this.ButOk);
            this.PanelSpecialContainer.Controls.Add(this.radioButton_Tax0);
            this.PanelSpecialContainer.Controls.Add(this.ButExit);
            this.PanelSpecialContainer.Controls.Add(this.groupBox4);
            this.PanelSpecialContainer.Controls.Add(this.button_SrchCustNo);
            this.PanelSpecialContainer.Controls.Add(this.button_SrchSuppNo);
            this.PanelSpecialContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelSpecialContainer.Location = new System.Drawing.Point(0, 0);
            this.PanelSpecialContainer.Name = "PanelSpecialContainer";
            this.PanelSpecialContainer.Size = new System.Drawing.Size(532, 328);
            this.PanelSpecialContainer.TabIndex = 1220;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.radioButton4);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton3);
            this.groupBox1.Location = new System.Drawing.Point(244, 203);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(254, 40);
            this.groupBox1.TabIndex = 6766;
            this.groupBox1.TabStop = false;
            this.groupBox1.Tag = " T_INVHED.IfDel ";
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radioButton4.Location = new System.Drawing.Point(80, 15);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(108, 17);
            this.radioButton4.TabIndex = 29;
            this.radioButton4.Text = "مختصر 2 بالضربيبه";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radioButton1.Location = new System.Drawing.Point(-60, 23);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(54, 17);
            this.radioButton1.TabIndex = 28;
            this.radioButton1.Text = "الكـــل";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.Visible = false;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Checked = true;
            this.radioButton2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radioButton2.Location = new System.Drawing.Point(6, 15);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(57, 17);
            this.radioButton2.TabIndex = 27;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "عرضي";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radioButton3.Location = new System.Drawing.Point(192, 15);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(56, 17);
            this.radioButton3.TabIndex = 26;
            this.radioButton3.Text = "مختصر";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(448, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 1224;
            this.label5.Text = "العميـــــــــل :";
            this.label5.Visible = false;
            // 
            // FlexType
            // 
            this.FlexType.BackColor = System.Drawing.Color.White;
            this.FlexType.ColumnInfo = resources.GetString("FlexType.ColumnInfo");
            this.FlexType.Font = new System.Drawing.Font("Tahoma", 8F);
            this.FlexType.Location = new System.Drawing.Point(60, 201);
            this.FlexType.Name = "FlexType";
            this.FlexType.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.FlexType.Rows.Count = 3;
            this.FlexType.Rows.DefaultSize = 19;
            this.FlexType.Rows.Fixed = 0;
            this.FlexType.Size = new System.Drawing.Size(159, 73);
            this.FlexType.StyleInfo = resources.GetString("FlexType.StyleInfo");
            this.FlexType.TabIndex = 6765;
            this.FlexType.Tag = " T_INVHED.InvCashPay ";
            this.FlexType.Visible = false;
            this.FlexType.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.System;
            // 
            // txtCustNo
            // 
            this.txtCustNo.BackColor = System.Drawing.Color.White;
            this.txtCustNo.Location = new System.Drawing.Point(361, 101);
            this.txtCustNo.Name = "txtCustNo";
            this.txtCustNo.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtCustNo, false);
            this.txtCustNo.Size = new System.Drawing.Size(79, 20);
            this.txtCustNo.TabIndex = 1221;
            this.txtCustNo.Tag = " T_INVHED.CusVenNo ";
            this.txtCustNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCustNo.Visible = false;
            // 
            // CmbDeleted
            // 
            this.CmbDeleted.BackColor = System.Drawing.Color.Transparent;
            this.CmbDeleted.Controls.Add(this.radioButton_Del1);
            this.CmbDeleted.Controls.Add(this.radioButton_Del2);
            this.CmbDeleted.Controls.Add(this.radioButton_Del0);
            this.CmbDeleted.Location = new System.Drawing.Point(244, 202);
            this.CmbDeleted.Name = "CmbDeleted";
            this.CmbDeleted.Size = new System.Drawing.Size(254, 40);
            this.CmbDeleted.TabIndex = 6763;
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
            this.radioButton_Del2.Location = new System.Drawing.Point(67, 15);
            this.radioButton_Del2.Name = "radioButton_Del2";
            this.radioButton_Del2.Size = new System.Drawing.Size(89, 17);
            this.radioButton_Del2.TabIndex = 27;
            this.radioButton_Del2.Text = "المحذوفة فقط";
            this.radioButton_Del2.UseVisualStyleBackColor = true;
            // 
            // radioButton_Del0
            // 
            this.radioButton_Del0.AutoSize = true;
            this.radioButton_Del0.Checked = true;
            this.radioButton_Del0.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radioButton_Del0.Location = new System.Drawing.Point(163, 15);
            this.radioButton_Del0.Name = "radioButton_Del0";
            this.radioButton_Del0.Size = new System.Drawing.Size(84, 17);
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
            this.CmbReturn.Location = new System.Drawing.Point(244, 239);
            this.CmbReturn.Name = "CmbReturn";
            this.CmbReturn.Size = new System.Drawing.Size(254, 40);
            this.CmbReturn.TabIndex = 6764;
            this.CmbReturn.TabStop = false;
            this.CmbReturn.Tag = " T_INVHED.IfRet ";
            this.CmbReturn.Visible = false;
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
            this.radioButton_ِReturn2.Size = new System.Drawing.Size(87, 17);
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
            this.radioButton_ِReturn0.Size = new System.Drawing.Size(82, 17);
            this.radioButton_ِReturn0.TabIndex = 29;
            this.radioButton_ِReturn0.Text = "الغير مرتجعة";
            this.radioButton_ِReturn0.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label9.Location = new System.Drawing.Point(446, 180);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 13);
            this.label9.TabIndex = 6762;
            this.label9.Text = "المستخـــدم :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(446, 157);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 13);
            this.label7.TabIndex = 6761;
            this.label7.Text = "المنـــــــدوب :";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(446, 134);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 13);
            this.label6.TabIndex = 6760;
            this.label6.Text = "المــــــــــورد :";
            this.label6.Visible = false;
            // 
            // button_SrchUsrNo
            // 
            this.button_SrchUsrNo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchUsrNo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchUsrNo.Location = new System.Drawing.Point(333, 176);
            this.button_SrchUsrNo.Name = "button_SrchUsrNo";
            this.button_SrchUsrNo.Size = new System.Drawing.Size(26, 20);
            this.button_SrchUsrNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchUsrNo.Symbol = "";
            this.button_SrchUsrNo.SymbolSize = 12F;
            this.button_SrchUsrNo.TabIndex = 6758;
            this.button_SrchUsrNo.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchUsrNo.Click += new System.EventHandler(this.button_SrchUsrNo_Click);
            // 
            // button_SrchLegNo
            // 
            this.button_SrchLegNo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchLegNo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchLegNo.Location = new System.Drawing.Point(333, 153);
            this.button_SrchLegNo.Name = "button_SrchLegNo";
            this.button_SrchLegNo.Size = new System.Drawing.Size(26, 20);
            this.button_SrchLegNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchLegNo.Symbol = "";
            this.button_SrchLegNo.SymbolSize = 12F;
            this.button_SrchLegNo.TabIndex = 6755;
            this.button_SrchLegNo.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchLegNo.Click += new System.EventHandler(this.button_SrchLegNo_Click);
            // 
            // txtUserName
            // 
            this.txtUserName.BackColor = System.Drawing.Color.Ivory;
            this.txtUserName.ForeColor = System.Drawing.Color.White;
            this.txtUserName.Location = new System.Drawing.Point(13, 177);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtUserName, false);
            this.txtUserName.Size = new System.Drawing.Size(313, 20);
            this.txtUserName.TabIndex = 6759;
            this.txtUserName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtUserNo
            // 
            this.txtUserNo.BackColor = System.Drawing.Color.White;
            this.txtUserNo.Location = new System.Drawing.Point(361, 176);
            this.txtUserNo.Name = "txtUserNo";
            this.txtUserNo.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtUserNo, false);
            this.txtUserNo.Size = new System.Drawing.Size(79, 20);
            this.txtUserNo.TabIndex = 6757;
            this.txtUserNo.Tag = " T_INVHED.SalsManNo ";
            this.txtUserNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtLegName
            // 
            this.txtLegName.BackColor = System.Drawing.Color.Ivory;
            this.txtLegName.ForeColor = System.Drawing.Color.White;
            this.txtLegName.Location = new System.Drawing.Point(13, 154);
            this.txtLegName.Name = "txtLegName";
            this.txtLegName.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtLegName, false);
            this.txtLegName.Size = new System.Drawing.Size(313, 20);
            this.txtLegName.TabIndex = 6756;
            this.txtLegName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtLegNo
            // 
            this.txtLegNo.BackColor = System.Drawing.Color.White;
            this.txtLegNo.Location = new System.Drawing.Point(361, 153);
            this.txtLegNo.Name = "txtLegNo";
            this.txtLegNo.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtLegNo, false);
            this.txtLegNo.Size = new System.Drawing.Size(79, 20);
            this.txtLegNo.TabIndex = 6754;
            this.txtLegNo.Tag = "T_INVHED.MndNo ";
            this.txtLegNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtSuppName
            // 
            this.txtSuppName.BackColor = System.Drawing.Color.Ivory;
            this.txtSuppName.ForeColor = System.Drawing.Color.White;
            this.txtSuppName.Location = new System.Drawing.Point(13, 131);
            this.txtSuppName.Name = "txtSuppName";
            this.txtSuppName.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtSuppName, false);
            this.txtSuppName.Size = new System.Drawing.Size(313, 20);
            this.txtSuppName.TabIndex = 6753;
            this.txtSuppName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSuppName.Visible = false;
            // 
            // txtSuppNo
            // 
            this.txtSuppNo.BackColor = System.Drawing.Color.White;
            this.txtSuppNo.Location = new System.Drawing.Point(361, 130);
            this.txtSuppNo.Name = "txtSuppNo";
            this.txtSuppNo.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtSuppNo, false);
            this.txtSuppNo.Size = new System.Drawing.Size(79, 20);
            this.txtSuppNo.TabIndex = 6751;
            this.txtSuppNo.Tag = " T_INVHED.CusVenNo ";
            this.txtSuppNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSuppNo.Visible = false;
            // 
            // radioButton_Tax1
            // 
            this.radioButton_Tax1.AutoSize = true;
            this.radioButton_Tax1.Checked = true;
            this.radioButton_Tax1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radioButton_Tax1.Location = new System.Drawing.Point(184, 75);
            this.radioButton_Tax1.Name = "radioButton_Tax1";
            this.radioButton_Tax1.Size = new System.Drawing.Size(54, 17);
            this.radioButton_Tax1.TabIndex = 1223;
            this.radioButton_Tax1.TabStop = true;
            this.radioButton_Tax1.Text = "الكـــل";
            this.radioButton_Tax1.UseVisualStyleBackColor = true;
            // 
            // radioButton_Tax2
            // 
            this.radioButton_Tax2.AutoSize = true;
            this.radioButton_Tax2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radioButton_Tax2.Location = new System.Drawing.Point(252, 75);
            this.radioButton_Tax2.Name = "radioButton_Tax2";
            this.radioButton_Tax2.Size = new System.Drawing.Size(82, 17);
            this.radioButton_Tax2.TabIndex = 1222;
            this.radioButton_Tax2.Text = "بدون الضريبة";
            this.radioButton_Tax2.UseVisualStyleBackColor = true;
            // 
            // ButOk
            // 
            this.ButOk.BackgroundImage = global::InvAcc.Properties.Resources.print;
            this.ButOk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ButOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButOk.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.ButOk.Location = new System.Drawing.Point(244, 281);
            this.ButOk.Name = "ButOk";
            this.ButOk.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ButOk.Size = new System.Drawing.Size(227, 35);
            this.ButOk.TabIndex = 6750;
            this.ButOk.Text = "طباعه | Print";
            this.ButOk.UseVisualStyleBackColor = true;
            this.ButOk.Click += new System.EventHandler(this.ButOk_Click);
            // 
            // radioButton_Tax0
            // 
            this.radioButton_Tax0.AutoSize = true;
            this.radioButton_Tax0.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radioButton_Tax0.Location = new System.Drawing.Point(364, 75);
            this.radioButton_Tax0.Name = "radioButton_Tax0";
            this.radioButton_Tax0.Size = new System.Drawing.Size(61, 17);
            this.radioButton_Tax0.TabIndex = 1221;
            this.radioButton_Tax0.Text = "بالضريبة";
            this.radioButton_Tax0.UseVisualStyleBackColor = true;
            // 
            // ButExit
            // 
            this.ButExit.BackgroundImage = global::InvAcc.Properties.Resources.YALO2;
            this.ButExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ButExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButExit.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.ButExit.Location = new System.Drawing.Point(59, 281);
            this.ButExit.Name = "ButExit";
            this.ButExit.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ButExit.Size = new System.Drawing.Size(179, 35);
            this.ButExit.TabIndex = 6749;
            this.ButExit.Text = "خروج | ESC";
            this.ButExit.UseVisualStyleBackColor = true;
            this.ButExit.Click += new System.EventHandler(this.ButExit_Click);
            // 
            // button_SrchCustNo
            // 
            this.button_SrchCustNo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchCustNo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchCustNo.Location = new System.Drawing.Point(333, 101);
            this.button_SrchCustNo.Name = "button_SrchCustNo";
            this.button_SrchCustNo.Size = new System.Drawing.Size(26, 20);
            this.button_SrchCustNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchCustNo.Symbol = "";
            this.button_SrchCustNo.SymbolSize = 12F;
            this.button_SrchCustNo.TabIndex = 1222;
            this.button_SrchCustNo.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchCustNo.Visible = false;
            this.button_SrchCustNo.Click += new System.EventHandler(this.button_SrchCustNo_Click);
            // 
            // button_SrchSuppNo
            // 
            this.button_SrchSuppNo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchSuppNo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchSuppNo.Location = new System.Drawing.Point(333, 130);
            this.button_SrchSuppNo.Name = "button_SrchSuppNo";
            this.button_SrchSuppNo.Size = new System.Drawing.Size(26, 20);
            this.button_SrchSuppNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchSuppNo.Symbol = "";
            this.button_SrchSuppNo.SymbolSize = 12F;
            this.button_SrchSuppNo.TabIndex = 6752;
            this.button_SrchSuppNo.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchSuppNo.Visible = false;
            this.button_SrchSuppNo.Click += new System.EventHandler(this.button_SrchSuppNo_Click);
            // 
            // netResize1
            // 
            this.netResize1.AutoSaveLayout = true;
            this.netResize1.LabelsAutoEllipse = false;
            this.netResize1.ParentControl = this;
            this.netResize1.AfterControlResize += new Softgroup.NetResize.NetResize.AfterControlResizeEventHandler(this.netResize1_AfterControlResize);
            // 
            // txtCustName
            // 
            this.txtCustName.BackColor = System.Drawing.Color.Ivory;
            this.txtCustName.ForeColor = System.Drawing.Color.White;
            this.txtCustName.Location = new System.Drawing.Point(13, 101);
            this.txtCustName.Name = "txtCustName";
            this.txtCustName.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtCustName, false);
            this.txtCustName.Size = new System.Drawing.Size(313, 20);
            this.txtCustName.TabIndex = 1223;
            this.txtCustName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCustName.Visible = false;
            // 
            // FRInvTotals
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 328);
            this.Controls.Add(this.txtCustName);
            this.Controls.Add(this.PanelSpecialContainer);
            this.Icon = global::InvAcc.Properties.Resources.favicon;
            this.KeyPreview = true;
            this.Name = "FRInvTotals";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "إجماليات الفواتير";
            this.Load += new System.EventHandler(this.FRAccountTax_Load);
            this.Shown += new System.EventHandler(this.FrmInvSale_Shown);
            this.SizeChanged += new System.EventHandler(this.FrmInvSale_SizeChanged);
            this.VisibleChanged += new System.EventHandler(this.FRInvoice_VisibleChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Frm_KeyPress);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.PanelSpecialContainer.ResumeLayout(false);
            this.PanelSpecialContainer.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FlexType)).EndInit();
            this.CmbDeleted.ResumeLayout(false);
            this.CmbDeleted.PerformLayout();
            this.CmbReturn.ResumeLayout(false);
            this.CmbReturn.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ButOk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }//###########&&&&&&&&&&

        private System.Windows.Forms.GroupBox groupBox4;
        public System.Windows.Forms.MaskedTextBox txtMToDate;
        public System.Windows.Forms.MaskedTextBox txtMFromDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel PanelSpecialContainer;
        private C1.Win.C1Input.C1Button ButOk;
        private C1.Win.C1Input.C1Button ButExit;
        public Softgroup.NetResize.NetResize netResize1;
        private System.Windows.Forms.RadioButton radioButton_Tax1;
        private System.Windows.Forms.RadioButton radioButton_Tax2;
        private System.Windows.Forms.RadioButton radioButton_Tax0;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private DevComponents.DotNetBar.ButtonX button_SrchUsrNo;
        private DevComponents.DotNetBar.ButtonX button_SrchLegNo;
        private DevComponents.DotNetBar.ButtonX button_SrchSuppNo;
        public System.Windows.Forms.TextBox txtUserName;
        public System.Windows.Forms.TextBox txtUserNo;
        private System.Windows.Forms.TextBox txtLegName;
        private System.Windows.Forms.TextBox txtLegNo;
        private System.Windows.Forms.TextBox txtSuppName;
        private System.Windows.Forms.TextBox txtSuppNo;
        private System.Windows.Forms.GroupBox CmbDeleted;
        private System.Windows.Forms.RadioButton radioButton_Del1;
        private System.Windows.Forms.RadioButton radioButton_Del2;
        private System.Windows.Forms.RadioButton radioButton_Del0;
        private System.Windows.Forms.GroupBox CmbReturn;
        private System.Windows.Forms.RadioButton radioButton_ِReturn1;
        private System.Windows.Forms.RadioButton radioButton_ِReturn2;
        private System.Windows.Forms.RadioButton radioButton_ِReturn0;
        private C1.Win.C1FlexGrid.C1FlexGrid FlexType;
        private System.Windows.Forms.Label label5;
        private DevComponents.DotNetBar.ButtonX button_SrchCustNo;
        private System.Windows.Forms.TextBox txtCustNo;
        private System.Windows.Forms.TextBox txtCustName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton4;
    }
}
