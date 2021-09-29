   

namespace InvAcc.Forms
{
partial class FrmRelaySalaries
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRelaySalaries));
            this.PanelSpecialContainer = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.Button_OK = new DevComponents.DotNetBar.ButtonX();
            this.ribbonBar1 = new DevComponents.DotNetBar.RibbonBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBox_AccID = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.label8 = new System.Windows.Forms.Label();
            this.CmbCurr = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.txtBXCostCenterName = new System.Windows.Forms.TextBox();
            this.button_SrchCostCenter = new DevComponents.DotNetBar.ButtonX();
            this.switchButton_AccType = new DevComponents.DotNetBar.Controls.SwitchButton();
            this.txtBXBankName = new System.Windows.Forms.TextBox();
            this.button_SrchBXBankNo = new DevComponents.DotNetBar.ButtonX();
            this.label6 = new System.Windows.Forms.Label();
            this.button_Close = new DevComponents.DotNetBar.ButtonX();
            this.button_SrchMonth = new DevComponents.DotNetBar.ButtonX();
            this.comboBox_Month = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.netResize1 = new Softgroup.NetResize.NetResize(this.components);  this.netResize1.LabelsAutoEllipse = false;
            this.txtBXBankNo = new System.Windows.Forms.TextBox();
            this.txtBXCostCenterNo = new System.Windows.Forms.TextBox();
            this.netResize1.AfterControlResize += new Softgroup.NetResize.NetResize.AfterControlResizeEventHandler(this.netResize1_AfterControlResize);
            this.ribbonBar1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelSpecialContainer
            // 
            this.PanelSpecialContainer.Location = new System.Drawing.Point(0, 0);
            this.PanelSpecialContainer.Name = "PanelSpecialContainer";
            this.PanelSpecialContainer.Size = new System.Drawing.Size(200, 100);
            this.PanelSpecialContainer.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(262, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 70;
            this.label1.Text = "الشهـــــر :";
            // 
            // Button_OK
            // 
            this.Button_OK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.Button_OK.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.Button_OK.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.Button_OK.Location = new System.Drawing.Point(206, 245);
            this.Button_OK.Name = "Button_OK";
            this.Button_OK.Size = new System.Drawing.Size(191, 39);
            this.Button_OK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.Button_OK.Symbol = "";
            this.Button_OK.SymbolSize = 16F;
            this.Button_OK.TabIndex = 18;
            this.Button_OK.Text = "ترحيـــــــل";
            this.Button_OK.TextColor = System.Drawing.Color.White;
            this.Button_OK.Click += new System.EventHandler(this.Button_OK_Click);
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
            this.ribbonBar1.BackgroundStyle.BackColor = System.Drawing.Color.AliceBlue;
            this.ribbonBar1.BackgroundStyle.BackColor2 = System.Drawing.SystemColors.GradientActiveCaption;
            this.ribbonBar1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar1.ContainerControlProcessDialogKey = true;
            this.ribbonBar1.Controls.Add(this.panel1);
            this.ribbonBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonBar1.Tag= "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.ribbonBar1.Location = new System.Drawing.Point(0, 0);
            this.ribbonBar1.Name = "ribbonBar1";
            this.ribbonBar1.Size = new System.Drawing.Size(433, 304);
            this.ribbonBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this.ribbonBar1.TabIndex = 1103;
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
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.txtBXCostCenterNo);
            this.panel1.Controls.Add(this.txtBXBankNo);
            this.panel1.Controls.Add(this.button_Close);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.checkBox_AccID);
            this.panel1.Controls.Add(this.Button_OK);
            this.panel1.Controls.Add(this.comboBox_Month);
            this.panel1.Controls.Add(this.CmbCurr);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtBXCostCenterName);
            this.panel1.Controls.Add(this.button_SrchMonth);
            this.panel1.Controls.Add(this.button_SrchCostCenter);
            this.panel1.Controls.Add(this.button_SrchBXBankNo);
            this.panel1.Controls.Add(this.txtBXBankName);
            this.panel1.Controls.Add(this.switchButton_AccType);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(433, 287);
            this.panel1.TabIndex = 1104;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // checkBox_AccID
            // 
            // 
            // 
            // 
            this.checkBox_AccID.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBox_AccID.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.checkBox_AccID.Location = new System.Drawing.Point(238, 80);
            this.checkBox_AccID.Name = "checkBox_AccID";
            this.checkBox_AccID.Size = new System.Drawing.Size(159, 23);
            this.checkBox_AccID.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBox_AccID.TabIndex = 8556;
            this.checkBox_AccID.Text = "إصدار قيد محاسبي تلقائي";
            this.checkBox_AccID.CheckedChanged += new System.EventHandler(this.checkBox_AccID_CheckedChanged);
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Enabled = false;
            this.label8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label8.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label8.ForeColor = System.Drawing.Color.Navy;
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(301, 181);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 13);
            this.label8.TabIndex = 1126;
            this.label8.Text = "العملــــــــة :";
            // 
            // CmbCurr
            // 
            this.CmbCurr.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbCurr.DisplayMember = "Text";
            this.CmbCurr.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.CmbCurr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbCurr.Enabled = false;
            this.CmbCurr.FormattingEnabled = true;
            this.CmbCurr.ItemHeight = 14;
            this.CmbCurr.Location = new System.Drawing.Point(61, 181);
            this.CmbCurr.Name = "CmbCurr";
            this.CmbCurr.Size = new System.Drawing.Size(234, 20);
            this.CmbCurr.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.CmbCurr.TabIndex = 1125;
            // 
            // txtBXCostCenterName
            // 
            this.txtBXCostCenterName.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtBXCostCenterName.BackColor = System.Drawing.Color.White;
            this.txtBXCostCenterName.Enabled = false;
            this.txtBXCostCenterName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtBXCostCenterName.Location = new System.Drawing.Point(61, 155);
            this.txtBXCostCenterName.Name = "txtBXCostCenterName";
            this.txtBXCostCenterName.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtBXCostCenterName, false);
            this.txtBXCostCenterName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtBXCostCenterName.Size = new System.Drawing.Size(234, 20);
            this.txtBXCostCenterName.TabIndex = 1063;
            this.txtBXCostCenterName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button_SrchCostCenter
            // 
            this.button_SrchCostCenter.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchCostCenter.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.button_SrchCostCenter.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchCostCenter.Enabled = false;
            this.button_SrchCostCenter.Location = new System.Drawing.Point(15, 155);
            this.button_SrchCostCenter.Name = "button_SrchCostCenter";
            this.button_SrchCostCenter.Size = new System.Drawing.Size(26, 21);
            this.button_SrchCostCenter.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchCostCenter.Symbol = "";
            this.button_SrchCostCenter.SymbolSize = 12F;
            this.button_SrchCostCenter.TabIndex = 1061;
            this.button_SrchCostCenter.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchCostCenter.Click += new System.EventHandler(this.button_SrchCostCenter_Click);
            // 
            // switchButton_AccType
            // 
            this.switchButton_AccType.Anchor = System.Windows.Forms.AnchorStyles.Right;
            // 
            // 
            // 
            this.switchButton_AccType.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.switchButton_AccType.Enabled = false;
            this.switchButton_AccType.Location = new System.Drawing.Point(298, 128);
            this.switchButton_AccType.Name = "switchButton_AccType";
            this.switchButton_AccType.OffText = "الصندوق";
            this.switchButton_AccType.OnText = "البنك";
            this.switchButton_AccType.Size = new System.Drawing.Size(107, 21);
            this.switchButton_AccType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.switchButton_AccType.TabIndex = 1056;
            this.switchButton_AccType.ValueChanged += new System.EventHandler(this.switchButton_AccType_ValueChanged);
            // 
            // txtBXBankName
            // 
            this.txtBXBankName.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtBXBankName.BackColor = System.Drawing.Color.White;
            this.txtBXBankName.Enabled = false;
            this.txtBXBankName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtBXBankName.Location = new System.Drawing.Point(61, 128);
            this.txtBXBankName.Name = "txtBXBankName";
            this.txtBXBankName.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtBXBankName, false);
            this.txtBXBankName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtBXBankName.Size = new System.Drawing.Size(234, 20);
            this.txtBXBankName.TabIndex = 1054;
            this.txtBXBankName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button_SrchBXBankNo
            // 
            this.button_SrchBXBankNo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchBXBankNo.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.button_SrchBXBankNo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchBXBankNo.Enabled = false;
            this.button_SrchBXBankNo.Location = new System.Drawing.Point(15, 128);
            this.button_SrchBXBankNo.Name = "button_SrchBXBankNo";
            this.button_SrchBXBankNo.Size = new System.Drawing.Size(26, 21);
            this.button_SrchBXBankNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchBXBankNo.Symbol = "";
            this.button_SrchBXBankNo.SymbolSize = 12F;
            this.button_SrchBXBankNo.TabIndex = 1050;
            this.button_SrchBXBankNo.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchBXBankNo.Click += new System.EventHandler(this.button_SrchBXBankNo_Click);
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Enabled = false;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label6.ForeColor = System.Drawing.Color.Navy;
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(296, 159);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 13);
            this.label6.TabIndex = 1062;
            this.label6.Text = "مركز التكلفة :";
            // 
            // button_Close
            // 
            this.button_Close.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_Close.Checked = true;
            this.button_Close.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_Close.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.button_Close.Location = new System.Drawing.Point(12, 245);
            this.button_Close.Name = "button_Close";
            this.button_Close.Size = new System.Drawing.Size(191, 38);
            this.button_Close.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_Close.Symbol = "";
            this.button_Close.SymbolSize = 16F;
            this.button_Close.TabIndex = 19;
            this.button_Close.Text = "خـــروج";
            this.button_Close.TextColor = System.Drawing.Color.Black;
            this.button_Close.Click += new System.EventHandler(this.button_Close_Click);
            // 
            // button_SrchMonth
            // 
            this.button_SrchMonth.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchMonth.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.button_SrchMonth.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchMonth.Location = new System.Drawing.Point(51, 26);
            this.button_SrchMonth.Name = "button_SrchMonth";
            this.button_SrchMonth.Size = new System.Drawing.Size(26, 24);
            this.button_SrchMonth.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchMonth.Symbol = "";
            this.button_SrchMonth.SymbolSize = 12F;
            this.button_SrchMonth.TabIndex = 1586;
            this.button_SrchMonth.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchMonth.Click += new System.EventHandler(this.button_SrchMonth_Click);
            // 
            // comboBox_Month
            // 
            this.comboBox_Month.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox_Month.DisplayMember = "Text";
            this.comboBox_Month.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBox_Month.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Month.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.comboBox_Month.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.comboBox_Month.FormattingEnabled = true;
            this.comboBox_Month.ItemHeight = 18;
            this.comboBox_Month.Location = new System.Drawing.Point(83, 27);
            this.comboBox_Month.Name = "comboBox_Month";
            this.comboBox_Month.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.comboBox_Month.Size = new System.Drawing.Size(173, 24);
            this.comboBox_Month.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBox_Month.TabIndex = 1585;
            this.comboBox_Month.WatermarkText = "لا يوجد رواتب غير مرّحلة";
            // 
            // netResize1
            // 
            this.netResize1.ParentControl = this;
            // 
            // txtBXBankNo
            // 
            this.txtBXBankNo.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtBXBankNo.BackColor = System.Drawing.Color.White;
            this.txtBXBankNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtBXBankNo.Location = new System.Drawing.Point(262, 311);
            this.txtBXBankNo.MaxLength = 30;
            this.txtBXBankNo.Name = "txtBXBankNo";
            this.txtBXBankNo.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtBXBankNo, false);
            this.txtBXBankNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtBXBankNo.Size = new System.Drawing.Size(108, 20);
            this.txtBXBankNo.TabIndex = 8557;
            this.txtBXBankNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtBXCostCenterNo
            // 
            this.txtBXCostCenterNo.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtBXCostCenterNo.BackColor = System.Drawing.Color.White;
            this.txtBXCostCenterNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtBXCostCenterNo.Location = new System.Drawing.Point(83, 311);
            this.txtBXCostCenterNo.Name = "txtBXCostCenterNo";
            this.txtBXCostCenterNo.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtBXCostCenterNo, false);
            this.txtBXCostCenterNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtBXCostCenterNo.Size = new System.Drawing.Size(169, 20);
            this.txtBXCostCenterNo.TabIndex = 8558;
            this.txtBXCostCenterNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // FrmRelaySalaries
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 304);
            this.Controls.Add(this.ribbonBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "FrmRelaySalaries";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ترحيل الرواتب";
            this.Load += new System.EventHandler(this.FrmRelaySalaries_Load);
            this.Shown += new System.EventHandler(this.FrmInvSale_Shown);
            this.SizeChanged += new System.EventHandler(this.FrmInvSale_SizeChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmRelaySalaries_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FrmRelaySalaries_KeyPress);
            this.ribbonBar1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).EndInit();
            this.ResumeLayout(false);

        }//###########&&&&&&&&&&

}
}
