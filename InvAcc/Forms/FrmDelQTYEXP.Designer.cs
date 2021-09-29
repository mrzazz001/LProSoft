   

namespace InvAcc.Forms
{
partial class FrmDelQTYEXP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDelQTYEXP));
            components = new System.ComponentModel.Container();

            this.label5 = new System.Windows.Forms.Label();
            this.txtFItemName = new System.Windows.Forms.TextBox();
            this.txtFItemNo = new System.Windows.Forms.TextBox();
            this.button_SrchItemFrom = new DevComponents.DotNetBar.ButtonX();
            this.ButExit = new DevComponents.DotNetBar.ButtonX();
            this.ButOk = new DevComponents.DotNetBar.ButtonX();
            this.label9 = new System.Windows.Forms.Label();
            this.txtStoreName = new System.Windows.Forms.TextBox();
            this.txtStoreNo = new System.Windows.Forms.TextBox();
            this.button_SrchStoreNo = new DevComponents.DotNetBar.ButtonX();
            this.netResize1 = new Softgroup.NetResize.NetResize(this.components);  this.netResize1.LabelsAutoEllipse = false;
            this.netResize1.AfterControlResize += new Softgroup.NetResize.NetResize.AfterControlResizeEventHandler(this.netResize1_AfterControlResize);
            this.Shown += new System.EventHandler(this.FrmInvSale_Shown);
            this.SizeChanged += new System.EventHandler(this.FrmInvSale_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).BeginInit();

            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(13, 27);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label5.Size = new System.Drawing.Size(70, 13);
            this.label5.TabIndex = 1122;
            this.label5.Text = "رقم الصنف :";
            // 
            // txtFItemName
            // 
            this.txtFItemName.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.txtFItemName.ForeColor = System.Drawing.Color.White;
            this.txtFItemName.Location = new System.Drawing.Point(201, 23);
            this.txtFItemName.Name = "txtFItemName";
            this.netResize1.SetResizeTextBoxMultiline(this.txtFItemName, false);
            this.txtFItemName.ReadOnly = true;
            this.txtFItemName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtFItemName.Size = new System.Drawing.Size(218, 20);
            this.txtFItemName.TabIndex = 1121;
            this.txtFItemName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtFItemNo
            // 
            this.txtFItemNo.BackColor = System.Drawing.Color.White;
            this.txtFItemNo.Location = new System.Drawing.Point(89, 23);
            this.txtFItemNo.Name = "txtFItemNo";
            this.netResize1.SetResizeTextBoxMultiline(this.txtFItemNo, false);
            this.txtFItemNo.ReadOnly = true;
            this.txtFItemNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtFItemNo.Size = new System.Drawing.Size(79, 20);
            this.txtFItemNo.TabIndex = 1119;
            this.txtFItemNo.Tag = " T_Items.Itm_No ";
            this.txtFItemNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button_SrchItemFrom
            // 
            this.button_SrchItemFrom.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchItemFrom.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchItemFrom.Location = new System.Drawing.Point(172, 23);
            this.button_SrchItemFrom.Name = "button_SrchItemFrom";
            this.button_SrchItemFrom.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.button_SrchItemFrom.Size = new System.Drawing.Size(26, 20);
            this.button_SrchItemFrom.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchItemFrom.Symbol = "";
            this.button_SrchItemFrom.SymbolSize = 12F;
            this.button_SrchItemFrom.TabIndex = 1120;
            this.button_SrchItemFrom.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchItemFrom.Click += new System.EventHandler(this.button_SrchItemFrom_Click);
            // 
            // ButExit
            // 
            this.ButExit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.ButExit.Checked = true;
            this.ButExit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.ButExit.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.ButExit.Location = new System.Drawing.Point(217, 80);
            this.ButExit.Name = "ButExit";
            this.ButExit.Size = new System.Drawing.Size(196, 33);
            this.ButExit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ButExit.Symbol = "";
            this.ButExit.SymbolSize = 16F;
            this.ButExit.TabIndex = 1124;
            this.ButExit.Text = "خـــروج";
            this.ButExit.TextColor = System.Drawing.Color.Black;
            this.ButExit.Click += new System.EventHandler(this.ButExit_Click);
            // 
            // ButOk
            // 
            this.ButOk.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.ButOk.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.ButOk.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.ButOk.Location = new System.Drawing.Point(16, 80);
            this.ButOk.Name = "ButOk";
            this.ButOk.Size = new System.Drawing.Size(196, 33);
            this.ButOk.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ButOk.Symbol = "";
            this.ButOk.SymbolSize = 16F;
            this.ButOk.TabIndex = 1123;
            this.ButOk.Text = "حـذف البيانات";
            this.ButOk.TextColor = System.Drawing.Color.White;
            this.ButOk.Click += new System.EventHandler(this.ButOk_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label9.Location = new System.Drawing.Point(18, 51);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 13);
            this.label9.TabIndex = 1151;
            this.label9.Text = "المستودع :";
            // 
            // txtStoreName
            // 
            this.txtStoreName.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.txtStoreName.ForeColor = System.Drawing.Color.White;
            this.txtStoreName.Location = new System.Drawing.Point(201, 47);
            this.txtStoreName.Name = "txtStoreName";
            this.netResize1.SetResizeTextBoxMultiline(this.txtStoreName, false);
            this.txtStoreName.ReadOnly = true;
            this.txtStoreName.Size = new System.Drawing.Size(218, 20);
            this.txtStoreName.TabIndex = 1150;
            this.txtStoreName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtStoreNo
            // 
            this.txtStoreNo.BackColor = System.Drawing.Color.White;
            this.txtStoreNo.Location = new System.Drawing.Point(89, 47);
            this.txtStoreNo.Name = "txtStoreNo";
            this.netResize1.SetResizeTextBoxMultiline(this.txtStoreNo, false);
            this.txtStoreNo.ReadOnly = true;
            this.txtStoreNo.Size = new System.Drawing.Size(79, 20);
            this.txtStoreNo.TabIndex = 1148;
            this.txtStoreNo.Tag = " T_STKSQTY.storeNo ";
            this.txtStoreNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button_SrchStoreNo
            // 
            this.button_SrchStoreNo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchStoreNo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchStoreNo.Location = new System.Drawing.Point(172, 47);
            this.button_SrchStoreNo.Name = "button_SrchStoreNo";
            this.button_SrchStoreNo.Size = new System.Drawing.Size(26, 20);
            this.button_SrchStoreNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchStoreNo.Symbol = "";
            this.button_SrchStoreNo.SymbolSize = 12F;
            this.button_SrchStoreNo.TabIndex = 1149;
            this.button_SrchStoreNo.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchStoreNo.Click += new System.EventHandler(this.button_SrchStoreNo_Click);
            // 
            // FrmDelQTYEXP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(430, 134);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtStoreName);
            this.Controls.Add(this.txtStoreNo);
            this.Controls.Add(this.button_SrchStoreNo);
            this.Controls.Add(this.ButExit);
            this.Controls.Add(this.ButOk);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtFItemName);
            this.Controls.Add(this.txtFItemNo);
            this.Controls.Add(this.button_SrchItemFrom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(InvAcc.Properties.Resources.favicon));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "FrmDelQTYEXP";
            this.netResize1.AutoSaveLayout = true;
            this.netResize1.ParentControl = this;
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "حذف بيانات جدول تاريخ الصلاحية";
            this.Load += new System.EventHandler(this.FrmDelQTYEXP_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmDelQTYEXP_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FrmDelQTYEXP_KeyPress);
            this.Icon = ((System.Drawing.Icon)(InvAcc.Properties.Resources.favicon));
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).EndInit();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.ResumeLayout(false);
            this.PerformLayout();
        }//###########&&&&&&&&&&

}
}
