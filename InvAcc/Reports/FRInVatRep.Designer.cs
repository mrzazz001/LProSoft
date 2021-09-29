   

namespace InvAcc.Forms
{
partial class FRInVatRep
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
            this.PanelSpecialContainer = new System.Windows.Forms.Panel();
            this.ribbonBar1 = new DevComponents.DotNetBar.RibbonBar();
            this.ButOk = new C1.Win.C1Input.C1Button();
            this.ButExit = new C1.Win.C1Input.C1Button();
            this.txtPurchaesAccName = new System.Windows.Forms.TextBox();
            this.txtPurchaesAccNo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button_SrchPruchaTax = new DevComponents.DotNetBar.ButtonX();
            this.txtSalesAccName = new System.Windows.Forms.TextBox();
            this.txtSalesAccNo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button_SrchAccFrom = new DevComponents.DotNetBar.ButtonX();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtMToDate = new System.Windows.Forms.MaskedTextBox();
            this.txtMFromDate = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCostCName = new System.Windows.Forms.TextBox();
            this.txtCostCNo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.button_SrchCostNo = new DevComponents.DotNetBar.ButtonX();
            this.netResize1 = new Softgroup.NetResize.NetResize(this.components);
            this.PanelSpecialContainer.SuspendLayout();
            this.ribbonBar1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ButOk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButExit)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelSpecialContainer
            // 
            this.PanelSpecialContainer.Controls.Add(this.ribbonBar1);
            this.PanelSpecialContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelSpecialContainer.Location = new System.Drawing.Point(0, 0);
            this.PanelSpecialContainer.Name = "PanelSpecialContainer";
            this.PanelSpecialContainer.Size = new System.Drawing.Size(427, 260);
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
            this.ribbonBar1.Controls.Add(this.txtPurchaesAccName);
            this.ribbonBar1.Controls.Add(this.txtPurchaesAccNo);
            this.ribbonBar1.Controls.Add(this.label3);
            this.ribbonBar1.Controls.Add(this.button_SrchPruchaTax);
            this.ribbonBar1.Controls.Add(this.txtSalesAccName);
            this.ribbonBar1.Controls.Add(this.txtSalesAccNo);
            this.ribbonBar1.Controls.Add(this.label5);
            this.ribbonBar1.Controls.Add(this.button_SrchAccFrom);
            this.ribbonBar1.Controls.Add(this.groupBox4);
            this.ribbonBar1.Controls.Add(this.txtCostCName);
            this.ribbonBar1.Controls.Add(this.txtCostCNo);
            this.ribbonBar1.Controls.Add(this.label7);
            this.ribbonBar1.Controls.Add(this.button_SrchCostNo);
            this.ribbonBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonBar1.DragDropSupport = true;
            this.ribbonBar1.Location = new System.Drawing.Point(0, 0);
            this.ribbonBar1.Name = "ribbonBar1";
            this.ribbonBar1.Size = new System.Drawing.Size(427, 260);
            this.ribbonBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this.ribbonBar1.TabIndex = 1102;
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
            // 
            // ButOk
            // 
            this.ButOk.BackgroundImage = global::InvAcc.Properties.Resources.print;
            this.ButOk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ButOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButOk.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.ButOk.Location = new System.Drawing.Point(192, 201);
            this.ButOk.Name = "ButOk";
            this.ButOk.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ButOk.Size = new System.Drawing.Size(227, 35);
            this.ButOk.TabIndex = 6748;
            this.ButOk.Text = "طباعه | Print";
            this.ButOk.UseVisualStyleBackColor = true;
            this.ButOk.Click += new System.EventHandler(this.ButOk_Click);
            // 
            // ButExit
            // 
            this.ButExit.BackgroundImage = global::InvAcc.Properties.Resources.YALO2;
            this.ButExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ButExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButExit.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.ButExit.Location = new System.Drawing.Point(7, 201);
            this.ButExit.Name = "ButExit";
            this.ButExit.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ButExit.Size = new System.Drawing.Size(179, 35);
            this.ButExit.TabIndex = 6747;
            this.ButExit.Text = "خروج | ESC";
            this.ButExit.UseVisualStyleBackColor = true;
            this.ButExit.Click += new System.EventHandler(this.ButExit_Click);
            // 
            // txtPurchaesAccName
            // 
            this.txtPurchaesAccName.BackColor = System.Drawing.Color.Ivory;
            this.txtPurchaesAccName.ForeColor = System.Drawing.Color.White;
            this.txtPurchaesAccName.Location = new System.Drawing.Point(9, 97);
            this.txtPurchaesAccName.Name = "txtPurchaesAccName";
            this.txtPurchaesAccName.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtPurchaesAccName, false);
            this.txtPurchaesAccName.Size = new System.Drawing.Size(163, 20);
            this.txtPurchaesAccName.TabIndex = 1124;
            this.txtPurchaesAccName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPurchaesAccName.Visible = false;
            // 
            // txtPurchaesAccNo
            // 
            this.txtPurchaesAccNo.BackColor = System.Drawing.Color.White;
            this.txtPurchaesAccNo.Location = new System.Drawing.Point(203, 97);
            this.txtPurchaesAccNo.Name = "txtPurchaesAccNo";
            this.txtPurchaesAccNo.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtPurchaesAccNo, false);
            this.txtPurchaesAccNo.Size = new System.Drawing.Size(103, 20);
            this.txtPurchaesAccNo.TabIndex = 1122;
            this.txtPurchaesAccNo.Tag = " T_GDDET.AccNo ";
            this.txtPurchaesAccNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPurchaesAccNo.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(309, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 13);
            this.label3.TabIndex = 1125;
            this.label3.Text = "ح.ضريبة المبيعـــــات :";
            this.label3.Visible = false;
            // 
            // button_SrchPruchaTax
            // 
            this.button_SrchPruchaTax.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchPruchaTax.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchPruchaTax.Location = new System.Drawing.Point(174, 97);
            this.button_SrchPruchaTax.Name = "button_SrchPruchaTax";
            this.button_SrchPruchaTax.Size = new System.Drawing.Size(26, 20);
            this.button_SrchPruchaTax.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchPruchaTax.Symbol = "";
            this.button_SrchPruchaTax.SymbolSize = 12F;
            this.button_SrchPruchaTax.TabIndex = 1123;
            this.button_SrchPruchaTax.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchPruchaTax.Visible = false;
            this.button_SrchPruchaTax.Click += new System.EventHandler(this.button_SrchPruchaTax_Click);
            // 
            // txtSalesAccName
            // 
            this.txtSalesAccName.BackColor = System.Drawing.Color.Ivory;
            this.txtSalesAccName.ForeColor = System.Drawing.Color.White;
            this.txtSalesAccName.Location = new System.Drawing.Point(9, 73);
            this.txtSalesAccName.Name = "txtSalesAccName";
            this.txtSalesAccName.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtSalesAccName, false);
            this.txtSalesAccName.Size = new System.Drawing.Size(163, 20);
            this.txtSalesAccName.TabIndex = 7;
            this.txtSalesAccName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSalesAccName.Visible = false;
            // 
            // txtSalesAccNo
            // 
            this.txtSalesAccNo.BackColor = System.Drawing.Color.White;
            this.txtSalesAccNo.Location = new System.Drawing.Point(203, 73);
            this.txtSalesAccNo.Name = "txtSalesAccNo";
            this.txtSalesAccNo.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtSalesAccNo, false);
            this.txtSalesAccNo.Size = new System.Drawing.Size(103, 20);
            this.txtSalesAccNo.TabIndex = 5;
            this.txtSalesAccNo.Tag = " T_GDDET.AccNo ";
            this.txtSalesAccNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSalesAccNo.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(309, 101);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 13);
            this.label5.TabIndex = 1118;
            this.label5.Text = "ح.ضريبة المشتريات :";
            this.label5.Visible = false;
            // 
            // button_SrchAccFrom
            // 
            this.button_SrchAccFrom.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchAccFrom.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchAccFrom.Location = new System.Drawing.Point(174, 73);
            this.button_SrchAccFrom.Name = "button_SrchAccFrom";
            this.button_SrchAccFrom.Size = new System.Drawing.Size(26, 20);
            this.button_SrchAccFrom.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchAccFrom.Symbol = "";
            this.button_SrchAccFrom.SymbolSize = 12F;
            this.button_SrchAccFrom.TabIndex = 6;
            this.button_SrchAccFrom.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchAccFrom.Visible = false;
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
            // txtCostCName
            // 
            this.txtCostCName.BackColor = System.Drawing.Color.Ivory;
            this.txtCostCName.ForeColor = System.Drawing.Color.White;
            this.txtCostCName.Location = new System.Drawing.Point(9, 172);
            this.txtCostCName.Name = "txtCostCName";
            this.txtCostCName.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtCostCName, false);
            this.txtCostCName.Size = new System.Drawing.Size(163, 20);
            this.txtCostCName.TabIndex = 16;
            this.txtCostCName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCostCName.Visible = false;
            // 
            // txtCostCNo
            // 
            this.txtCostCNo.BackColor = System.Drawing.Color.White;
            this.txtCostCNo.Location = new System.Drawing.Point(203, 172);
            this.txtCostCNo.Name = "txtCostCNo";
            this.txtCostCNo.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtCostCNo, false);
            this.txtCostCNo.Size = new System.Drawing.Size(103, 20);
            this.txtCostCNo.TabIndex = 14;
            this.txtCostCNo.Tag = " T_GDHEAD.gdCstNo ";
            this.txtCostCNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCostCNo.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(309, 176);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(116, 13);
            this.label7.TabIndex = 1117;
            this.label7.Text = "مركــــــز التكلفـــــــة :";
            this.label7.Visible = false;
            // 
            // button_SrchCostNo
            // 
            this.button_SrchCostNo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchCostNo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchCostNo.Location = new System.Drawing.Point(174, 172);
            this.button_SrchCostNo.Name = "button_SrchCostNo";
            this.button_SrchCostNo.Size = new System.Drawing.Size(26, 20);
            this.button_SrchCostNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchCostNo.Symbol = "";
            this.button_SrchCostNo.SymbolSize = 12F;
            this.button_SrchCostNo.TabIndex = 15;
            this.button_SrchCostNo.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchCostNo.Visible = false;
            this.button_SrchCostNo.Click += new System.EventHandler(this.button_SrchCostNo_Click);
            // 
            // netResize1
            // 
            this.netResize1.AutoSaveLayout = true;
            this.netResize1.LabelsAutoEllipse = false;
            this.netResize1.ParentControl = this;
            this.netResize1.AfterControlResize += new Softgroup.NetResize.NetResize.AfterControlResizeEventHandler(this.netResize1_AfterControlResize);
            // 
            // FRInVatRep
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 260);
            this.Controls.Add(this.PanelSpecialContainer);
            this.Icon = global::InvAcc.Properties.Resources.favicon;
            this.KeyPreview = true;
            this.Name = "FRInVatRep";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "الاقرار الضريبي";
            this.Load += new System.EventHandler(this.FRAccountTax_Load);
            this.Shown += new System.EventHandler(this.FrmInvSale_Shown);
            this.SizeChanged += new System.EventHandler(this.FrmInvSale_SizeChanged);
            this.VisibleChanged += new System.EventHandler(this.FRInvoice_VisibleChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Frm_KeyPress);
            this.PanelSpecialContainer.ResumeLayout(false);
            this.ribbonBar1.ResumeLayout(false);
            this.ribbonBar1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ButOk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButExit)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).EndInit();
            this.ResumeLayout(false);

        }//###########&&&&&&&&&&

    }
}
