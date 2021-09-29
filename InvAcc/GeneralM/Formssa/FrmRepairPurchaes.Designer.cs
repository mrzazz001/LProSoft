   

namespace InvAcc.Forms
{
partial class FrmRepairPurchaes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRepairPurchaes));
            this.FlxInv = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.label5 = new System.Windows.Forms.Label();
            this.txtFItemName = new System.Windows.Forms.TextBox();
            this.txtFItemNo = new System.Windows.Forms.TextBox();
            this.button_SrchItemFrom = new DevComponents.DotNetBar.ButtonX();
            this.txtInItemName = new System.Windows.Forms.TextBox();
            this.txtInItemNo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button_SrchItemTo = new DevComponents.DotNetBar.ButtonX();
            this.ButOk = new DevComponents.DotNetBar.ButtonX();
            this.ButExit = new DevComponents.DotNetBar.ButtonX();
            this.Butupdate = new DevComponents.DotNetBar.ButtonX();
            this.button_DetData = new DevComponents.DotNetBar.ButtonX();
            this.groupBox_No = new System.Windows.Forms.GroupBox();
            this.txtMIntoNo = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMFromNo = new System.Windows.Forms.MaskedTextBox();
            this.netResize1 = new Softgroup.NetResize.NetResize(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.netResize1.AfterControlResize += new Softgroup.NetResize.NetResize.AfterControlResizeEventHandler(this.netResize1_AfterControlResize);
            ((System.ComponentModel.ISupportInitialize)(this.FlxInv)).BeginInit();
            this.groupBox_No.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // FlxInv
            // 
            this.FlxInv.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None;
            this.FlxInv.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
            this.FlxInv.ColumnInfo = resources.GetString("FlxInv.ColumnInfo");
            this.FlxInv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FlxInv.ExtendLastCol = true;
            this.FlxInv.Font = new System.Drawing.Font("Tahoma", 8F);
            this.FlxInv.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.FlxInv.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross;
            this.FlxInv.Location = new System.Drawing.Point(0, 0);
            this.FlxInv.Name = "FlxInv";
            this.FlxInv.Rows.Count = 1;
            this.FlxInv.Rows.DefaultSize = 19;
            this.FlxInv.ShowSortPosition = C1.Win.C1FlexGrid.ShowSortPositionEnum.None;
            this.FlxInv.Size = new System.Drawing.Size(1055, 503);
            this.FlxInv.StyleInfo = resources.GetString("FlxInv.StyleInfo");
            this.FlxInv.TabIndex = 18;
            this.FlxInv.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.System;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(981, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 13);
            this.label5.TabIndex = 1122;
            this.label5.Text = "مـن الصنف :";
            // 
            // txtFItemName
            // 
            this.txtFItemName.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.txtFItemName.ForeColor = System.Drawing.Color.White;
            this.txtFItemName.Location = new System.Drawing.Point(708, 19);
            this.txtFItemName.Name = "txtFItemName";
            this.txtFItemName.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtFItemName, false);
            this.txtFItemName.Size = new System.Drawing.Size(164, 20);
            this.txtFItemName.TabIndex = 1121;
            this.txtFItemName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtFItemNo
            // 
            this.txtFItemNo.BackColor = System.Drawing.Color.White;
            this.txtFItemNo.Location = new System.Drawing.Point(902, 19);
            this.txtFItemNo.Name = "txtFItemNo";
            this.txtFItemNo.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtFItemNo, false);
            this.txtFItemNo.Size = new System.Drawing.Size(79, 20);
            this.txtFItemNo.TabIndex = 1119;
            this.txtFItemNo.Tag = "T_INVDET_Repair.ItmNo_Repair ";
            this.txtFItemNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtFItemNo.TextChanged += new System.EventHandler(this.txtFItemNo_TextChanged);
            // 
            // button_SrchItemFrom
            // 
            this.button_SrchItemFrom.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchItemFrom.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchItemFrom.Location = new System.Drawing.Point(874, 19);
            this.button_SrchItemFrom.Name = "button_SrchItemFrom";
            this.button_SrchItemFrom.Size = new System.Drawing.Size(26, 20);
            this.button_SrchItemFrom.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchItemFrom.Symbol = "";
            this.button_SrchItemFrom.SymbolSize = 12F;
            this.button_SrchItemFrom.TabIndex = 1120;
            this.button_SrchItemFrom.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchItemFrom.Click += new System.EventHandler(this.button_SrchItemFrom_Click);
            // 
            // txtInItemName
            // 
            this.txtInItemName.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.txtInItemName.ForeColor = System.Drawing.Color.White;
            this.txtInItemName.Location = new System.Drawing.Point(708, 41);
            this.txtInItemName.Name = "txtInItemName";
            this.txtInItemName.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtInItemName, false);
            this.txtInItemName.Size = new System.Drawing.Size(164, 20);
            this.txtInItemName.TabIndex = 1125;
            this.txtInItemName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtInItemNo
            // 
            this.txtInItemNo.BackColor = System.Drawing.Color.White;
            this.txtInItemNo.Location = new System.Drawing.Point(902, 41);
            this.txtInItemNo.Name = "txtInItemNo";
            this.txtInItemNo.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtInItemNo, false);
            this.txtInItemNo.Size = new System.Drawing.Size(79, 20);
            this.txtInItemNo.TabIndex = 1123;
            this.txtInItemNo.Tag = "T_INVDET_Repair.ItmNo_Repair ";
            this.txtInItemNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtInItemNo.TextChanged += new System.EventHandler(this.txtInItemNo_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(981, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 13);
            this.label6.TabIndex = 1126;
            this.label6.Text = "إلـــى صنف :";
            // 
            // button_SrchItemTo
            // 
            this.button_SrchItemTo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchItemTo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchItemTo.Location = new System.Drawing.Point(874, 41);
            this.button_SrchItemTo.Name = "button_SrchItemTo";
            this.button_SrchItemTo.Size = new System.Drawing.Size(26, 20);
            this.button_SrchItemTo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchItemTo.Symbol = "";
            this.button_SrchItemTo.SymbolSize = 12F;
            this.button_SrchItemTo.TabIndex = 1124;
            this.button_SrchItemTo.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchItemTo.Click += new System.EventHandler(this.button_SrchItemTo_Click);
            // 
            // ButOk
            // 
            this.ButOk.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.ButOk.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.ButOk.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.ButOk.Location = new System.Drawing.Point(208, 17);
            this.ButOk.Name = "ButOk";
            this.ButOk.Size = new System.Drawing.Size(96, 43);
            this.ButOk.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ButOk.SymbolSize = 16F;
            this.ButOk.TabIndex = 1127;
            this.ButOk.Text = "عــرض";
            this.ButOk.TextColor = System.Drawing.Color.White;
            this.ButOk.Click += new System.EventHandler(this.ButOk_Click);
            // 
            // ButExit
            // 
            this.ButExit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.ButExit.Checked = true;
            this.ButExit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.ButExit.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.ButExit.Location = new System.Drawing.Point(11, 17);
            this.ButExit.Name = "ButExit";
            this.ButExit.Size = new System.Drawing.Size(96, 43);
            this.ButExit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ButExit.Symbol = "";
            this.ButExit.SymbolSize = 16F;
            this.ButExit.TabIndex = 1128;
            this.ButExit.Text = "خـــروج";
            this.ButExit.TextColor = System.Drawing.Color.Black;
            this.ButExit.Click += new System.EventHandler(this.ButExit_Click);
            // 
            // Butupdate
            // 
            this.Butupdate.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.Butupdate.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.Butupdate.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.Butupdate.Location = new System.Drawing.Point(110, 17);
            this.Butupdate.Name = "Butupdate";
            this.Butupdate.Size = new System.Drawing.Size(96, 43);
            this.Butupdate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.Butupdate.SymbolSize = 16F;
            this.Butupdate.TabIndex = 1129;
            this.Butupdate.Text = "تحديث الأسعار";
            this.Butupdate.TextColor = System.Drawing.Color.White;
            this.Butupdate.Click += new System.EventHandler(this.Butupdate_Click);
            // 
            // button_DetData
            // 
            this.button_DetData.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_DetData.Checked = true;
            this.button_DetData.ColorTable = DevComponents.DotNetBar.eButtonColor.Magenta;
            this.button_DetData.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.button_DetData.Location = new System.Drawing.Point(307, 17);
            this.button_DetData.Name = "button_DetData";
            this.button_DetData.Size = new System.Drawing.Size(74, 43);
            this.button_DetData.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_DetData.Symbol = "";
            this.button_DetData.SymbolSize = 16F;
            this.button_DetData.TabIndex = 1130;
            this.button_DetData.Text = "مسح كامل ";
            this.button_DetData.TextColor = System.Drawing.Color.Maroon;
            this.button_DetData.Visible = false;
            this.button_DetData.Click += new System.EventHandler(this.button_DetData_Click);
            // 
            // groupBox_No
            // 
            this.groupBox_No.BackColor = System.Drawing.Color.Transparent;
            this.groupBox_No.Controls.Add(this.txtMIntoNo);
            this.groupBox_No.Controls.Add(this.label1);
            this.groupBox_No.Controls.Add(this.label2);
            this.groupBox_No.Controls.Add(this.txtMFromNo);
            this.groupBox_No.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.groupBox_No.Location = new System.Drawing.Point(387, 11);
            this.groupBox_No.Name = "groupBox_No";
            this.groupBox_No.Size = new System.Drawing.Size(315, 48);
            this.groupBox_No.TabIndex = 6725;
            this.groupBox_No.TabStop = false;
            this.groupBox_No.Text = "حسب رقم الفاتورة";
            // 
            // txtMIntoNo
            // 
            this.txtMIntoNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtMIntoNo.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtMIntoNo.Location = new System.Drawing.Point(10, 19);
            this.txtMIntoNo.Name = "txtMIntoNo";
            this.txtMIntoNo.Size = new System.Drawing.Size(112, 22);
            this.txtMIntoNo.TabIndex = 2;
            this.txtMIntoNo.Tag = "T_INVDET_Repair.InvNo_Repair";
            this.txtMIntoNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMIntoNo.Click += new System.EventHandler(this.txtMIntoNo_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(280, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 857;
            this.label1.Text = "من :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(125, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 859;
            this.label2.Text = "إلى :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMFromNo
            // 
            this.txtMFromNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtMFromNo.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtMFromNo.Location = new System.Drawing.Point(166, 19);
            this.txtMFromNo.Name = "txtMFromNo";
            this.txtMFromNo.Size = new System.Drawing.Size(112, 22);
            this.txtMFromNo.TabIndex = 1;
            this.txtMFromNo.Tag = "T_INVDET_Repair.InvNo_Repair ";
            this.txtMFromNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMFromNo.Click += new System.EventHandler(this.txtMFromNo_Click);
            // 
            // netResize1
            // 
            this.netResize1.ParentControl = this;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.ButOk);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox_No);
            this.splitContainer1.Panel1.Controls.Add(this.button_SrchItemFrom);
            this.splitContainer1.Panel1.Controls.Add(this.Butupdate);
            this.splitContainer1.Panel1.Controls.Add(this.txtFItemNo);
            this.splitContainer1.Panel1.Controls.Add(this.ButExit);
            this.splitContainer1.Panel1.Controls.Add(this.txtFItemName);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.button_DetData);
            this.splitContainer1.Panel1.Controls.Add(this.button_SrchItemTo);
            this.splitContainer1.Panel1.Controls.Add(this.txtInItemName);
            this.splitContainer1.Panel1.Controls.Add(this.label6);
            this.splitContainer1.Panel1.Controls.Add(this.txtInItemNo);
            this.splitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.FlxInv);
            this.splitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.splitContainer1.Size = new System.Drawing.Size(1055, 581);
            this.splitContainer1.SplitterDistance = 74;
            this.splitContainer1.TabIndex = 6726;
            // 
            // FrmRepairPurchaes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1055, 581);
            this.ControlBox = false;
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "FrmRepairPurchaes";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "معالج تحديث أسعــار التكلفــــة";
            this.Load += new System.EventHandler(this.FrmRepairPurchaes_Load);
            this.Shown += new System.EventHandler(this.FrmInvSale_Shown);
            this.SizeChanged += new System.EventHandler(this.FrmInvSale_SizeChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmRepairPurchaes_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.FlxInv)).EndInit();
            this.groupBox_No.ResumeLayout(false);
            this.groupBox_No.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }//###########&&&&&&&&&&

}
}
