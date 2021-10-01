   

namespace InvAcc.Forms
{
partial class FRAccount
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRAccount));
            this.PanelSpecialContainer = new System.Windows.Forms.Panel();
            this.ribbonBar1 = new DevComponents.DotNetBar.RibbonBar();
            this.ButOk = new C1.Win.C1Input.C1Button();
            this.ButExit = new C1.Win.C1Input.C1Button();
            this.checkBox_OldBCalcaluat = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.txtRemark = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label11 = new System.Windows.Forms.Label();
            this.checkBox_BalanceMove = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.checkBox_OldBlance = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.label9 = new System.Windows.Forms.Label();
            this.CmbCurr = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label10 = new System.Windows.Forms.Label();
            this.combobox_SortTyp = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.txtLegateName = new System.Windows.Forms.TextBox();
            this.txtMainAccName = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtMainAccNo = new System.Windows.Forms.TextBox();
            this.txtLegateNo = new System.Windows.Forms.TextBox();
            this.txtUserNo = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button_SrchUsrNo = new DevComponents.DotNetBar.ButtonX();
            this.button_SrchLegNo = new DevComponents.DotNetBar.ButtonX();
            this.button_SrchAccFrom = new DevComponents.DotNetBar.ButtonX();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtMToDate = new System.Windows.Forms.MaskedTextBox();
            this.txtMFromDate = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtMBalanceB = new DevComponents.Editors.DoubleInput();
            this.txtMBalanceS = new DevComponents.Editors.DoubleInput();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCostCName = new System.Windows.Forms.TextBox();
            this.txtCostCNo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.button_SrchCostNo = new DevComponents.DotNetBar.ButtonX();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.RButShort = new System.Windows.Forms.RadioButton();
            this.RButDet = new System.Windows.Forms.RadioButton();
            this.controlContainerItem1 = new DevComponents.DotNetBar.ControlContainerItem();
            this.netResize1 = new Softgroup.NetResize.NetResize(this.components);  this.netResize1.LabelsAutoEllipse = false;
            this.netResize1.AfterControlResize += new Softgroup.NetResize.NetResize.AfterControlResizeEventHandler(this.netResize1_AfterControlResize);
            this.PanelSpecialContainer.SuspendLayout();
            this.ribbonBar1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ButOk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButExit)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMBalanceB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMBalanceS)).BeginInit();
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
            this.PanelSpecialContainer.Size = new System.Drawing.Size(427, 401);
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
            this.ribbonBar1.Controls.Add(this.checkBox_OldBCalcaluat);
            this.ribbonBar1.Controls.Add(this.txtRemark);
            this.ribbonBar1.Controls.Add(this.label11);
            this.ribbonBar1.Controls.Add(this.checkBox_BalanceMove);
            this.ribbonBar1.Controls.Add(this.checkBox_OldBlance);
            this.ribbonBar1.Controls.Add(this.label9);
            this.ribbonBar1.Controls.Add(this.CmbCurr);
            this.ribbonBar1.Controls.Add(this.label10);
            this.ribbonBar1.Controls.Add(this.combobox_SortTyp);
            this.ribbonBar1.Controls.Add(this.txtLegateName);
            this.ribbonBar1.Controls.Add(this.txtMainAccName);
            this.ribbonBar1.Controls.Add(this.txtUserName);
            this.ribbonBar1.Controls.Add(this.txtMainAccNo);
            this.ribbonBar1.Controls.Add(this.txtLegateNo);
            this.ribbonBar1.Controls.Add(this.txtUserNo);
            this.ribbonBar1.Controls.Add(this.label8);
            this.ribbonBar1.Controls.Add(this.label6);
            this.ribbonBar1.Controls.Add(this.label5);
            this.ribbonBar1.Controls.Add(this.button_SrchUsrNo);
            this.ribbonBar1.Controls.Add(this.button_SrchLegNo);
            this.ribbonBar1.Controls.Add(this.button_SrchAccFrom);
            this.ribbonBar1.Controls.Add(this.groupBox4);
            this.ribbonBar1.Controls.Add(this.groupBox3);
            this.ribbonBar1.Controls.Add(this.txtCostCName);
            this.ribbonBar1.Controls.Add(this.txtCostCNo);
            this.ribbonBar1.Controls.Add(this.label7);
            this.ribbonBar1.Controls.Add(this.button_SrchCostNo);
            this.ribbonBar1.Controls.Add(this.groupBox2);
            this.ribbonBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonBar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.controlContainerItem1});
            this.ribbonBar1.Tag= "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.ribbonBar1.Location = new System.Drawing.Point(0, 0);
            this.ribbonBar1.Name = "ribbonBar1";
            this.ribbonBar1.Size = new System.Drawing.Size(427, 401);
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
            this.ButOk.Location = new System.Drawing.Point(195, 346);
            this.ButOk.Name = "ButOk";
            this.ButOk.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ButOk.Size = new System.Drawing.Size(227, 35);
            this.ButOk.TabIndex = 6746;
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
            this.ButExit.Location = new System.Drawing.Point(10, 346);
            this.ButExit.Name = "ButExit";
            this.ButExit.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ButExit.Size = new System.Drawing.Size(179, 35);
            this.ButExit.TabIndex = 6745;
            this.ButExit.Text = "خروج | ESC";
            this.ButExit.UseVisualStyleBackColor = true;
            this.ButExit.Click += new System.EventHandler(this.ButExit_Click);
            this.ButExit.MouseLeave += new System.EventHandler(this.ButExit_MouseLeave);
            this.ButExit.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ButExit_MouseMove);
            // 
            // checkBox_OldBCalcaluat
            // 
            this.checkBox_OldBCalcaluat.BackColor = System.Drawing.Color.LightGray;
            // 
            // 
            // 
            this.checkBox_OldBCalcaluat.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Dash;
            this.checkBox_OldBCalcaluat.BackgroundStyle.BorderBottomColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.checkBox_OldBCalcaluat.BackgroundStyle.BorderBottomWidth = 1;
            this.checkBox_OldBCalcaluat.BackgroundStyle.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.checkBox_OldBCalcaluat.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Dash;
            this.checkBox_OldBCalcaluat.BackgroundStyle.BorderLeftWidth = 1;
            this.checkBox_OldBCalcaluat.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Dash;
            this.checkBox_OldBCalcaluat.BackgroundStyle.BorderRightWidth = 1;
            this.checkBox_OldBCalcaluat.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Dash;
            this.checkBox_OldBCalcaluat.BackgroundStyle.BorderTopWidth = 1;
            this.checkBox_OldBCalcaluat.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBox_OldBCalcaluat.CheckBoxPosition = DevComponents.DotNetBar.eCheckBoxPosition.Top;
            this.checkBox_OldBCalcaluat.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Bold);
            this.checkBox_OldBCalcaluat.Location = new System.Drawing.Point(9, 310);
            this.checkBox_OldBCalcaluat.Name = "checkBox_OldBCalcaluat";
            this.checkBox_OldBCalcaluat.Size = new System.Drawing.Size(134, 33);
            this.checkBox_OldBCalcaluat.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBox_OldBCalcaluat.TabIndex = 6744;
            this.checkBox_OldBCalcaluat.Text = "إحتساب الرصيد السابق";
            this.checkBox_OldBCalcaluat.Visible = false;
            this.checkBox_OldBCalcaluat.CheckedChanged += new System.EventHandler(this.checkBox_OldBCalcaluat_CheckedChanged);
            // 
            // txtRemark
            // 
            this.txtRemark.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtRemark.Border.Class = "TextBoxBorder";
            this.txtRemark.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtRemark.ButtonCustom.Image = ((System.Drawing.Image)(resources.GetObject("txtRemark.ButtonCustom.Image")));
            this.txtRemark.ButtonCustom.Visible = true;
            this.txtRemark.ForeColor = System.Drawing.Color.Black;
            this.txtRemark.Location = new System.Drawing.Point(9, 234);
            this.txtRemark.Name = "txtRemark";
            this.netResize1.SetResizeTextBoxMultiline(this.txtRemark, false);
            this.txtRemark.Size = new System.Drawing.Size(335, 22);
            this.txtRemark.TabIndex = 6743;
            this.txtRemark.Tag = "T_GDDET.gdDes";
            this.txtRemark.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtRemark.ButtonCustomClick += new System.EventHandler(this.txtRemark_ButtonCustomClick);
            this.txtRemark.Click += new System.EventHandler(this.txtRemark_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label11.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label11.Location = new System.Drawing.Point(347, 239);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 13);
            this.label11.TabIndex = 6742;
            this.label11.Text = "حسب البيان :";
            // 
            // checkBox_BalanceMove
            // 
            // 
            // 
            // 
            this.checkBox_BalanceMove.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Dash;
            this.checkBox_BalanceMove.BackgroundStyle.BorderBottomColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.checkBox_BalanceMove.BackgroundStyle.BorderBottomWidth = 1;
            this.checkBox_BalanceMove.BackgroundStyle.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.checkBox_BalanceMove.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Dash;
            this.checkBox_BalanceMove.BackgroundStyle.BorderLeftWidth = 1;
            this.checkBox_BalanceMove.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Dash;
            this.checkBox_BalanceMove.BackgroundStyle.BorderRightWidth = 1;
            this.checkBox_BalanceMove.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Dash;
            this.checkBox_BalanceMove.BackgroundStyle.BorderTopWidth = 1;
            this.checkBox_BalanceMove.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBox_BalanceMove.CheckBoxPosition = DevComponents.DotNetBar.eCheckBoxPosition.Top;
            this.checkBox_BalanceMove.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Bold);
            this.checkBox_BalanceMove.Location = new System.Drawing.Point(290, 310);
            this.checkBox_BalanceMove.Name = "checkBox_BalanceMove";
            this.checkBox_BalanceMove.Size = new System.Drawing.Size(134, 33);
            this.checkBox_BalanceMove.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBox_BalanceMove.TabIndex = 6741;
            this.checkBox_BalanceMove.Text = "تحريك الرصيد";
            this.checkBox_BalanceMove.CheckedChanged += new System.EventHandler(this.checkBox_BalanceMove_CheckedChanged);
            // 
            // checkBox_OldBlance
            // 
            // 
            // 
            // 
            this.checkBox_OldBlance.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Dash;
            this.checkBox_OldBlance.BackgroundStyle.BorderBottomColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.checkBox_OldBlance.BackgroundStyle.BorderBottomWidth = 1;
            this.checkBox_OldBlance.BackgroundStyle.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.checkBox_OldBlance.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Dash;
            this.checkBox_OldBlance.BackgroundStyle.BorderLeftWidth = 1;
            this.checkBox_OldBlance.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Dash;
            this.checkBox_OldBlance.BackgroundStyle.BorderRightWidth = 1;
            this.checkBox_OldBlance.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Dash;
            this.checkBox_OldBlance.BackgroundStyle.BorderTopWidth = 1;
            this.checkBox_OldBlance.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBox_OldBlance.CheckBoxPosition = DevComponents.DotNetBar.eCheckBoxPosition.Top;
            this.checkBox_OldBlance.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Bold);
            this.checkBox_OldBlance.Location = new System.Drawing.Point(146, 310);
            this.checkBox_OldBlance.Name = "checkBox_OldBlance";
            this.checkBox_OldBlance.Size = new System.Drawing.Size(140, 33);
            this.checkBox_OldBlance.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBox_OldBlance.TabIndex = 6740;
            this.checkBox_OldBlance.Text = "إظهار الرصيد السابق";
            this.checkBox_OldBlance.CheckedChanged += new System.EventHandler(this.checkBox_OldBlance_CheckedChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label9.Location = new System.Drawing.Point(345, 288);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(78, 13);
            this.label9.TabIndex = 6732;
            this.label9.Text = "العملـــــــــــة :";
            // 
            // CmbCurr
            // 
            this.CmbCurr.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbCurr.DisplayMember = "Text";
            this.CmbCurr.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.CmbCurr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbCurr.Font = new System.Drawing.Font("Tahoma", 8F);
            this.CmbCurr.FormattingEnabled = true;
            this.CmbCurr.ItemHeight = 14;
            this.CmbCurr.Location = new System.Drawing.Point(146, 284);
            this.CmbCurr.Name = "CmbCurr";
            this.CmbCurr.Size = new System.Drawing.Size(198, 20);
            this.CmbCurr.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.CmbCurr.TabIndex = 6731;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label10.Location = new System.Drawing.Point(347, 264);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 13);
            this.label10.TabIndex = 6722;
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
            this.combobox_SortTyp.ItemHeight = 14;
            this.combobox_SortTyp.Location = new System.Drawing.Point(146, 260);
            this.combobox_SortTyp.Name = "combobox_SortTyp";
            this.combobox_SortTyp.Size = new System.Drawing.Size(198, 20);
            this.combobox_SortTyp.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.combobox_SortTyp.TabIndex = 6721;
            // 
            // txtLegateName
            // 
            this.txtLegateName.BackColor = System.Drawing.Color.Ivory;
            this.txtLegateName.ForeColor = System.Drawing.Color.White;
            this.txtLegateName.Location = new System.Drawing.Point(9, 160);
            this.txtLegateName.Name = "txtLegateName";
            this.txtLegateName.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtLegateName, false);
            this.txtLegateName.Size = new System.Drawing.Size(201, 20);
            this.txtLegateName.TabIndex = 10;
            this.txtLegateName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtMainAccName
            // 
            this.txtMainAccName.BackColor = System.Drawing.Color.Ivory;
            this.txtMainAccName.ForeColor = System.Drawing.Color.White;
            this.txtMainAccName.Location = new System.Drawing.Point(9, 135);
            this.txtMainAccName.Name = "txtMainAccName";
            this.txtMainAccName.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtMainAccName, false);
            this.txtMainAccName.Size = new System.Drawing.Size(201, 20);
            this.txtMainAccName.TabIndex = 7;
            this.txtMainAccName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtUserName
            // 
            this.txtUserName.BackColor = System.Drawing.Color.Ivory;
            this.txtUserName.ForeColor = System.Drawing.Color.White;
            this.txtUserName.Location = new System.Drawing.Point(9, 185);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtUserName, false);
            this.txtUserName.Size = new System.Drawing.Size(201, 20);
            this.txtUserName.TabIndex = 13;
            this.txtUserName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtMainAccNo
            // 
            this.txtMainAccNo.BackColor = System.Drawing.Color.White;
            this.txtMainAccNo.Location = new System.Drawing.Point(241, 135);
            this.txtMainAccNo.Name = "txtMainAccNo";
            this.txtMainAccNo.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtMainAccNo, false);
            this.txtMainAccNo.Size = new System.Drawing.Size(103, 20);
            this.txtMainAccNo.TabIndex = 5;
            this.txtMainAccNo.Tag = " T_GDDET.AccNo ";
            this.txtMainAccNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtLegateNo
            // 
            this.txtLegateNo.BackColor = System.Drawing.Color.White;
            this.txtLegateNo.Location = new System.Drawing.Point(241, 160);
            this.txtLegateNo.Name = "txtLegateNo";
            this.txtLegateNo.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtLegateNo, false);
            this.txtLegateNo.Size = new System.Drawing.Size(103, 20);
            this.txtLegateNo.TabIndex = 8;
            this.txtLegateNo.Tag = " T_GDHEAD.gdMnd ";
            this.txtLegateNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtUserNo
            // 
            this.txtUserNo.BackColor = System.Drawing.Color.White;
            this.txtUserNo.Location = new System.Drawing.Point(241, 185);
            this.txtUserNo.Name = "txtUserNo";
            this.txtUserNo.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtUserNo, false);
            this.txtUserNo.Size = new System.Drawing.Size(103, 20);
            this.txtUserNo.TabIndex = 11;
            this.txtUserNo.Tag = " T_GDHEAD.gdUser ";
            this.txtUserNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(347, 189);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 13);
            this.label8.TabIndex = 1121;
            this.label8.Text = "المستخـــدم :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(347, 164);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 13);
            this.label6.TabIndex = 1120;
            this.label6.Text = "المنـــــدوب :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(347, 139);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 1118;
            this.label5.Text = "الحســـاب :";
            // 
            // button_SrchUsrNo
            // 
            this.button_SrchUsrNo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchUsrNo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchUsrNo.Location = new System.Drawing.Point(212, 185);
            this.button_SrchUsrNo.Name = "button_SrchUsrNo";
            this.button_SrchUsrNo.Size = new System.Drawing.Size(26, 20);
            this.button_SrchUsrNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchUsrNo.Symbol = "";
            this.button_SrchUsrNo.SymbolSize = 12F;
            this.button_SrchUsrNo.TabIndex = 12;
            this.button_SrchUsrNo.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchUsrNo.Click += new System.EventHandler(this.button_SrchUsrNo_Click);
            // 
            // button_SrchLegNo
            // 
            this.button_SrchLegNo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchLegNo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchLegNo.Location = new System.Drawing.Point(212, 160);
            this.button_SrchLegNo.Name = "button_SrchLegNo";
            this.button_SrchLegNo.Size = new System.Drawing.Size(26, 20);
            this.button_SrchLegNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchLegNo.Symbol = "";
            this.button_SrchLegNo.SymbolSize = 12F;
            this.button_SrchLegNo.TabIndex = 9;
            this.button_SrchLegNo.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchLegNo.Click += new System.EventHandler(this.button_SrchLegNo_Click);
            // 
            // button_SrchAccFrom
            // 
            this.button_SrchAccFrom.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchAccFrom.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchAccFrom.Location = new System.Drawing.Point(212, 135);
            this.button_SrchAccFrom.Name = "button_SrchAccFrom";
            this.button_SrchAccFrom.Size = new System.Drawing.Size(26, 20);
            this.button_SrchAccFrom.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchAccFrom.Symbol = "";
            this.button_SrchAccFrom.SymbolSize = 12F;
            this.button_SrchAccFrom.TabIndex = 6;
            this.button_SrchAccFrom.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchAccFrom.Click += new System.EventHandler(this.button_SrchAccFrom_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.Transparent;
            this.groupBox4.Controls.Add(this.txtMToDate);
            this.groupBox4.Controls.Add(this.txtMFromDate);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.groupBox4.Location = new System.Drawing.Point(9, 17);
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
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.txtMBalanceB);
            this.groupBox3.Controls.Add(this.txtMBalanceS);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.groupBox3.Location = new System.Drawing.Point(9, 79);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(412, 52);
            this.groupBox3.TabIndex = 1145;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "الرصيــــد";
            // 
            // txtMBalanceB
            // 
            this.txtMBalanceB.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtMBalanceB.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtMBalanceB.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtMBalanceB.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtMBalanceB.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtMBalanceB.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.txtMBalanceB.Increment = 1D;
            this.txtMBalanceB.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtMBalanceB.Location = new System.Drawing.Point(221, 22);
            this.txtMBalanceB.LockUpdateChecked = false;
            this.txtMBalanceB.Name = "txtMBalanceB";
            this.txtMBalanceB.ShowCheckBox = true;
            this.txtMBalanceB.ShowUpDown = true;
            this.txtMBalanceB.Size = new System.Drawing.Size(108, 20);
            this.txtMBalanceB.TabIndex = 1159;
            this.txtMBalanceB.Tag = "T_GDDET.gdValue";
            // 
            // txtMBalanceS
            // 
            this.txtMBalanceS.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtMBalanceS.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtMBalanceS.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtMBalanceS.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtMBalanceS.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtMBalanceS.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.txtMBalanceS.Increment = 1D;
            this.txtMBalanceS.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtMBalanceS.Location = new System.Drawing.Point(36, 22);
            this.txtMBalanceS.LockUpdateChecked = false;
            this.txtMBalanceS.Name = "txtMBalanceS";
            this.txtMBalanceS.ShowCheckBox = true;
            this.txtMBalanceS.ShowUpDown = true;
            this.txtMBalanceS.Size = new System.Drawing.Size(108, 20);
            this.txtMBalanceS.TabIndex = 1158;
            this.txtMBalanceS.Tag = "T_GDDET.gdValue";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(333, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 1157;
            this.label3.Text = "مـــــن :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(150, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 1156;
            this.label4.Text = "أصغر من = :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCostCName
            // 
            this.txtCostCName.BackColor = System.Drawing.Color.Ivory;
            this.txtCostCName.ForeColor = System.Drawing.Color.White;
            this.txtCostCName.Location = new System.Drawing.Point(9, 210);
            this.txtCostCName.Name = "txtCostCName";
            this.txtCostCName.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtCostCName, false);
            this.txtCostCName.Size = new System.Drawing.Size(201, 20);
            this.txtCostCName.TabIndex = 16;
            this.txtCostCName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtCostCNo
            // 
            this.txtCostCNo.BackColor = System.Drawing.Color.White;
            this.txtCostCNo.Location = new System.Drawing.Point(241, 210);
            this.txtCostCNo.Name = "txtCostCNo";
            this.txtCostCNo.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtCostCNo, false);
            this.txtCostCNo.Size = new System.Drawing.Size(103, 20);
            this.txtCostCNo.TabIndex = 14;
            this.txtCostCNo.Tag = " T_GDHEAD.gdCstNo ";
            this.txtCostCNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(347, 214);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 13);
            this.label7.TabIndex = 1117;
            this.label7.Text = "مركز التكلفة :";
            // 
            // button_SrchCostNo
            // 
            this.button_SrchCostNo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchCostNo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchCostNo.Location = new System.Drawing.Point(212, 210);
            this.button_SrchCostNo.Name = "button_SrchCostNo";
            this.button_SrchCostNo.Size = new System.Drawing.Size(26, 20);
            this.button_SrchCostNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchCostNo.Symbol = "";
            this.button_SrchCostNo.SymbolSize = 12F;
            this.button_SrchCostNo.TabIndex = 15;
            this.button_SrchCostNo.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchCostNo.Click += new System.EventHandler(this.button_SrchCostNo_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.RButShort);
            this.groupBox2.Controls.Add(this.RButDet);
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.groupBox2.Location = new System.Drawing.Point(9, 252);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(134, 54);
            this.groupBox2.TabIndex = 6730;
            this.groupBox2.TabStop = false;
            // 
            // RButShort
            // 
            this.RButShort.AutoSize = true;
            this.RButShort.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.RButShort.ForeColor = System.Drawing.Color.SteelBlue;
            this.RButShort.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.RButShort.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.RButShort.Location = new System.Drawing.Point(37, 32);
            this.RButShort.Name = "RButShort";
            this.RButShort.Size = new System.Drawing.Size(61, 17);
            this.RButShort.TabIndex = 1008;
            this.RButShort.Text = "مختصر";
            this.RButShort.UseVisualStyleBackColor = true;
            this.RButShort.CheckedChanged += new System.EventHandler(this.RButDet_CheckedChanged);
            // 
            // RButDet
            // 
            this.RButDet.AutoSize = true;
            this.RButDet.Checked = true;
            this.RButDet.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.RButDet.ForeColor = System.Drawing.Color.SteelBlue;
            this.RButDet.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.RButDet.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.RButDet.Location = new System.Drawing.Point(31, 12);
            this.RButDet.Name = "RButDet";
            this.RButDet.Size = new System.Drawing.Size(67, 17);
            this.RButDet.TabIndex = 1007;
            this.RButDet.TabStop = true;
            this.RButDet.Text = "تفصيلي";
            this.RButDet.UseVisualStyleBackColor = true;
            this.RButDet.CheckedChanged += new System.EventHandler(this.RButDet_CheckedChanged);
            // 
            // controlContainerItem1
            // 
            this.controlContainerItem1.AllowItemResize = false;
            this.controlContainerItem1.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways;
            this.controlContainerItem1.Name = "controlContainerItem1";
            // 
            // netResize1
            // 
            this.netResize1.AutoSaveLayout = true;
            this.netResize1.ParentControl = this;
            // 
            // FRAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 401);
            this.Controls.Add(this.PanelSpecialContainer);
            this.Icon = global::InvAcc.Properties.Resources.favicon;
            this.KeyPreview = true;
            this.Name = "FRAccount";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "كشف حساب";
            this.Load += new System.EventHandler(this.FRAccount_Load);
            this.Shown += new System.EventHandler(this.FRAccount_Shown);
            this.SizeChanged += new System.EventHandler(this.FrmInvSale_SizeChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Frm_KeyPress);
            this.PanelSpecialContainer.ResumeLayout(false);
            this.ribbonBar1.ResumeLayout(false);
            this.ribbonBar1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ButOk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButExit)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMBalanceB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMBalanceS)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).EndInit();
            this.ResumeLayout(false);
        }//###########&&&&&&&&&&

}
}
