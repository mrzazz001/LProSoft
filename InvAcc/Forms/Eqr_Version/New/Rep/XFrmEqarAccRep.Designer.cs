namespace InvAcc.Forms.Eqr_Version.New.Rep
{
    partial class XFrmEqarAccRep
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txtMBalanceB = new DevComponents.Editors.DoubleInput();
            this.txtMBalanceS = new DevComponents.Editors.DoubleInput();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtEqarNo = new DevExpress.XtraEditors.LookUpEdit();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtEqarName = new System.Windows.Forms.TextBox();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.t_EqarsDatasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMBalanceB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMBalanceS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEqarNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t_EqarsDatasBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // txtMToDate
            // 
            this.txtMToDate.Location = new System.Drawing.Point(261, 43);
            this.txtMToDate.Size = new System.Drawing.Size(193, 20);
            // 
            // txtMFromDate
            // 
            this.txtMFromDate.Size = new System.Drawing.Size(185, 20);
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.Controls.Add(this.txtEqarName);
            this.dataLayoutControl1.Controls.Add(this.txtEqarNo);
            this.dataLayoutControl1.Controls.Add(this.txtMBalanceS);
            this.dataLayoutControl1.Controls.Add(this.txtMBalanceB);
            this.dataLayoutControl1.OptionsView.RightToLeftMirroringApplied = true;
            this.dataLayoutControl1.Size = new System.Drawing.Size(526, 179);
            this.dataLayoutControl1.Controls.SetChildIndex(this.txtMToDate, 0);
            this.dataLayoutControl1.Controls.SetChildIndex(this.txtMFromDate, 0);
            this.dataLayoutControl1.Controls.SetChildIndex(this.txtMBalanceB, 0);
            this.dataLayoutControl1.Controls.SetChildIndex(this.txtMBalanceS, 0);
            this.dataLayoutControl1.Controls.SetChildIndex(this.txtEqarNo, 0);
            this.dataLayoutControl1.Controls.SetChildIndex(this.txtEqarName, 0);
            // 
            // Root
            // 
            this.Root.Size = new System.Drawing.Size(526, 179);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.Size = new System.Drawing.Size(506, 67);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Location = new System.Drawing.Point(237, 0);
            this.layoutControlItem1.Size = new System.Drawing.Size(245, 24);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(44, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Size = new System.Drawing.Size(237, 24);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(44, 13);
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem6});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 67);
            this.layoutControlGroup2.Size = new System.Drawing.Size(506, 92);
            this.layoutControlGroup2.Text = "النطاقات";
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
            this.txtMBalanceB.Location = new System.Drawing.Point(232, 110);
            this.txtMBalanceB.LockUpdateChecked = false;
            this.txtMBalanceB.Name = "txtMBalanceB";
            this.txtMBalanceB.ShowCheckBox = true;
            this.txtMBalanceB.ShowUpDown = true;
            this.txtMBalanceB.Size = new System.Drawing.Size(222, 20);
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
            this.txtMBalanceS.Location = new System.Drawing.Point(24, 110);
            this.txtMBalanceS.LockUpdateChecked = false;
            this.txtMBalanceS.Name = "txtMBalanceS";
            this.txtMBalanceS.ShowCheckBox = true;
            this.txtMBalanceS.ShowUpDown = true;
            this.txtMBalanceS.Size = new System.Drawing.Size(156, 20);
            this.txtMBalanceS.TabIndex = 1158;
            this.txtMBalanceS.Tag = "T_GDDET.gdValue";
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txtMBalanceB;
            this.layoutControlItem3.Location = new System.Drawing.Point(208, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(274, 25);
            this.layoutControlItem3.Text = "من:";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(44, 13);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.txtMBalanceS;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(208, 25);
            this.layoutControlItem4.Text = "اصغر من:";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(44, 13);
            // 
            // txtEqarNo
            // 
            this.txtEqarNo.Location = new System.Drawing.Point(232, 135);
            this.txtEqarNo.MenuManager = this.barManager1;
            this.txtEqarNo.Name = "txtEqarNo";
            this.txtEqarNo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtEqarNo.Properties.DataSource = this.t_EqarsDatasBindingSource;
            this.txtEqarNo.Properties.DisplayMember = "EqarNo";
            this.txtEqarNo.Properties.ValueMember = "NameA";
            this.txtEqarNo.Size = new System.Drawing.Size(222, 20);
            this.txtEqarNo.StyleController = this.dataLayoutControl1;
            this.txtEqarNo.TabIndex = 1160;
            this.txtEqarNo.EditValueChanged += new System.EventHandler(this.lookUpEdit1_EditValueChanged);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.txtEqarNo;
            this.layoutControlItem5.Location = new System.Drawing.Point(208, 25);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(274, 24);
            this.layoutControlItem5.Text = "العقار:";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(44, 13);
            // 
            // txtEqarName
            // 
            this.txtEqarName.Location = new System.Drawing.Point(24, 135);
            this.txtEqarName.Name = "txtEqarName";
            this.txtEqarName.ReadOnly = true;
            this.txtEqarName.Size = new System.Drawing.Size(196, 20);
            this.txtEqarName.TabIndex = 1161;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.txtEqarName;
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 25);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(208, 24);
            this.layoutControlItem6.Text = " ";
            this.layoutControlItem6.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem6.TextSize = new System.Drawing.Size(3, 13);
            this.layoutControlItem6.TextToControlDistance = 5;
            // 
            // t_EqarsDatasBindingSource
            // 
            this.t_EqarsDatasBindingSource.DataSource = typeof(ProShared.Stock_Data.T_EqarsData);
            // 
            // XFrmEqarAccRep
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 238);
            this.Name = "XFrmEqarAccRep";
            this.Text = "XFrmEqarAccRep";
            this.Load += new System.EventHandler(this.XFrmEqarAccRep_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMBalanceB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMBalanceS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEqarNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t_EqarsDatasBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.Editors.DoubleInput txtMBalanceS;
        private DevComponents.Editors.DoubleInput txtMBalanceB;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private System.Windows.Forms.TextBox txtEqarName;
        private DevExpress.XtraEditors.LookUpEdit txtEqarNo;
        private System.Windows.Forms.BindingSource t_EqarsDatasBindingSource;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
    }
}