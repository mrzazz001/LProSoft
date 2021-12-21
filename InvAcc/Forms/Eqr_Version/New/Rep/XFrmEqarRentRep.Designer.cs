namespace InvAcc.Forms.Eqr_Version.New.Rep
{
    partial class XFrmEqarRentRep
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
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.lookUpEdit11 = new DevExpress.XtraEditors.LookUpEdit();
            this.txtTenantNo = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtTenantName = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit11.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenantNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenantName)).BeginInit();
            this.SuspendLayout();
            // 
            // txtMToDate
            // 
            this.txtMToDate.Location = new System.Drawing.Point(204, 43);
            this.txtMToDate.Size = new System.Drawing.Size(135, 28);
            // 
            // txtMFromDate
            // 
            this.txtMFromDate.Size = new System.Drawing.Size(128, 28);
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.Controls.Add(this.lookUpEdit11);
            this.dataLayoutControl1.Controls.Add(this.textBox11);
            this.dataLayoutControl1.OptionsView.RightToLeftMirroringApplied = true;
            this.dataLayoutControl1.Size = new System.Drawing.Size(411, 162);
            this.dataLayoutControl1.Controls.SetChildIndex(this.textBox11, 0);
            this.dataLayoutControl1.Controls.SetChildIndex(this.lookUpEdit11, 0);
            this.dataLayoutControl1.Controls.SetChildIndex(this.txtMToDate, 0);
            this.dataLayoutControl1.Controls.SetChildIndex(this.txtMFromDate, 0);
            // 
            // Root
            // 
            this.Root.Size = new System.Drawing.Size(411, 162);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.Size = new System.Drawing.Size(391, 75);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Location = new System.Drawing.Point(180, 0);
            this.layoutControlItem1.Size = new System.Drawing.Size(187, 32);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(44, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Size = new System.Drawing.Size(180, 32);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(44, 13);
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.txtTenantNo,
            this.txtTenantName});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 75);
            this.layoutControlGroup2.Size = new System.Drawing.Size(391, 67);
            // 
            // textBox11
            // 
            this.textBox11.Location = new System.Drawing.Point(24, 118);
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(171, 20);
            this.textBox11.TabIndex = 5;
            // 
            // lookUpEdit11
            // 
            this.lookUpEdit11.Location = new System.Drawing.Point(207, 118);
            this.lookUpEdit11.Name = "lookUpEdit11";
            this.lookUpEdit11.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit11.Properties.DisplayMember = "tenantNo";
            this.lookUpEdit11.Properties.ValueMember = "NameA";
            this.lookUpEdit11.Size = new System.Drawing.Size(132, 20);
            this.lookUpEdit11.StyleController = this.dataLayoutControl1;
            this.lookUpEdit11.TabIndex = 4;
            // 
            // txtTenantNo
            // 
            this.txtTenantNo.Control = this.lookUpEdit11;
            this.txtTenantNo.ControlAlignment = System.Drawing.ContentAlignment.TopRight;
            this.txtTenantNo.CustomizationFormText = "المستاجر";
            this.txtTenantNo.Location = new System.Drawing.Point(183, 0);
            this.txtTenantNo.Name = "txtTenantNo";
            this.txtTenantNo.Size = new System.Drawing.Size(184, 24);
            this.txtTenantNo.Text = "المستاجر";
            this.txtTenantNo.TextSize = new System.Drawing.Size(44, 13);
            // 
            // txtTenantName
            // 
            this.txtTenantName.Control = this.textBox11;
            this.txtTenantName.ControlAlignment = System.Drawing.ContentAlignment.TopRight;
            this.txtTenantName.CustomizationFormText = " ";
            this.txtTenantName.Location = new System.Drawing.Point(0, 0);
            this.txtTenantName.Name = "txtTenantName";
            this.txtTenantName.Size = new System.Drawing.Size(183, 24);
            this.txtTenantName.Text = " ";
            this.txtTenantName.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.txtTenantName.TextSize = new System.Drawing.Size(3, 13);
            this.txtTenantName.TextToControlDistance = 5;
            // 
            // XFrmEqarRentRep
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 221);
            this.Name = "XFrmEqarRentRep";
            this.Text = "XFrmEqarRentRep";
            this.Load += new System.EventHandler(this.XFrmEqarRentRep_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit11.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenantNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenantName)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LookUpEdit lookUpEdit11;
        private System.Windows.Forms.TextBox textBox11;
        private DevExpress.XtraLayout.LayoutControlItem txtTenantNo;
        private DevExpress.XtraLayout.LayoutControlItem txtTenantName;
    }
}