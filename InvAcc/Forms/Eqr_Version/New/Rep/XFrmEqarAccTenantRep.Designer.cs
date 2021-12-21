namespace InvAcc.Forms.Eqr_Version.New.Rep
{
    partial class XFrmEqarAccTenantRep
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
            this.lookUpEdit1 = new DevExpress.XtraEditors.LookUpEdit();
            this.t_TenantsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.txtTenantNo = new DevExpress.XtraLayout.LayoutControlItem();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtTenantName = new DevExpress.XtraLayout.LayoutControlItem();
            this.CmbStatus = new DevExpress.XtraEditors.ComboBoxEdit();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t_TenantsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenantNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenantName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CmbStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            this.SuspendLayout();
            // 
            // txtMToDate
            // 
            this.txtMToDate.Location = new System.Drawing.Point(219, 43);
            this.txtMToDate.Size = new System.Drawing.Size(138, 21);
            // 
            // txtMFromDate
            // 
            this.txtMFromDate.Size = new System.Drawing.Size(133, 21);
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.Controls.Add(this.CmbStatus);
            this.dataLayoutControl1.Controls.Add(this.textBox1);
            this.dataLayoutControl1.Controls.Add(this.lookUpEdit1);
            this.dataLayoutControl1.OptionsView.RightToLeftMirroringApplied = true;
            this.dataLayoutControl1.Size = new System.Drawing.Size(439, 179);
            this.dataLayoutControl1.Controls.SetChildIndex(this.txtMToDate, 0);
            this.dataLayoutControl1.Controls.SetChildIndex(this.txtMFromDate, 0);
            this.dataLayoutControl1.Controls.SetChildIndex(this.lookUpEdit1, 0);
            this.dataLayoutControl1.Controls.SetChildIndex(this.textBox1, 0);
            this.dataLayoutControl1.Controls.SetChildIndex(this.CmbStatus, 0);
            // 
            // Root
            // 
            this.Root.Size = new System.Drawing.Size(439, 179);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.Size = new System.Drawing.Size(419, 68);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Location = new System.Drawing.Point(195, 0);
            this.layoutControlItem1.Size = new System.Drawing.Size(200, 25);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(54, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Size = new System.Drawing.Size(195, 25);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(54, 13);
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.txtTenantNo,
            this.txtTenantName,
            this.layoutControlItem3});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 68);
            this.layoutControlGroup2.Size = new System.Drawing.Size(419, 91);
            this.layoutControlGroup2.Text = "النطاقات";
            // 
            // lookUpEdit1
            // 
            this.lookUpEdit1.Location = new System.Drawing.Point(242, 111);
            this.lookUpEdit1.MenuManager = this.barManager1;
            this.lookUpEdit1.Name = "lookUpEdit1";
            this.lookUpEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit1.Properties.DataSource = this.t_TenantsBindingSource;
            this.lookUpEdit1.Properties.DisplayMember = "tenantNo";
            this.lookUpEdit1.Properties.ValueMember = "NameA";
            this.lookUpEdit1.Size = new System.Drawing.Size(115, 20);
            this.lookUpEdit1.StyleController = this.dataLayoutControl1;
            this.lookUpEdit1.TabIndex = 4;
            // 
            // t_TenantsBindingSource
            // 
            this.t_TenantsBindingSource.DataSource = typeof(ProShared.Stock_Data.T_Tenant);
            // 
            // txtTenantNo
            // 
            this.txtTenantNo.Control = this.lookUpEdit1;
            this.txtTenantNo.Location = new System.Drawing.Point(218, 0);
            this.txtTenantNo.Name = "txtTenantNo";
            this.txtTenantNo.Size = new System.Drawing.Size(177, 24);
            this.txtTenantNo.Text = "المستاجر";
            this.txtTenantNo.TextSize = new System.Drawing.Size(54, 13);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(24, 111);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(206, 20);
            this.textBox1.TabIndex = 5;
            // 
            // txtTenantName
            // 
            this.txtTenantName.Control = this.textBox1;
            this.txtTenantName.Location = new System.Drawing.Point(0, 0);
            this.txtTenantName.Name = "txtTenantName";
            this.txtTenantName.Size = new System.Drawing.Size(218, 24);
            this.txtTenantName.Text = " ";
            this.txtTenantName.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.txtTenantName.TextSize = new System.Drawing.Size(3, 13);
            this.txtTenantName.TextToControlDistance = 5;
            // 
            // CmbStatus
            // 
            this.CmbStatus.Location = new System.Drawing.Point(24, 135);
            this.CmbStatus.MenuManager = this.barManager1;
            this.CmbStatus.Name = "CmbStatus";
            this.CmbStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.CmbStatus.Size = new System.Drawing.Size(333, 20);
            this.CmbStatus.StyleController = this.dataLayoutControl1;
            this.CmbStatus.TabIndex = 6;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.AllowHtmlStringInCaption = true;
            this.layoutControlItem3.Control = this.CmbStatus;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(395, 24);
            this.layoutControlItem3.Text = "حالة السداد";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(54, 13);
            // 
            // XFrmEqarAccTenantRep
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 238);
            this.Name = "XFrmEqarAccTenantRep";
            this.Text = "FrmEqarAccTenantRep";
            this.Load += new System.EventHandler(this.XFrmEqarAccTenantRep_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t_TenantsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenantNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenantName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CmbStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LookUpEdit lookUpEdit1;
        private DevExpress.XtraLayout.LayoutControlItem txtTenantNo;
        private System.Windows.Forms.TextBox textBox1;
        private DevExpress.XtraLayout.LayoutControlItem txtTenantName;
        private System.Windows.Forms.BindingSource t_TenantsBindingSource;
        private DevExpress.XtraEditors.ComboBoxEdit CmbStatus;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
    }
}