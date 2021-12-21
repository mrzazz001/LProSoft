namespace InvAcc.Forms.Eqr_Version.New
{
    partial class XFrmAlarmTenant
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
            this.t_AlarmTenantsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForAlarmTenantID = new DevExpress.XtraLayout.LayoutControlItem();
            this.AlarmTenantIDTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.ItemForAlarmTenantNo = new DevExpress.XtraLayout.LayoutControlItem();
            this.AlarmTenantNoTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.ItemFortenant_ID = new DevExpress.XtraLayout.LayoutControlItem();
            this.tenant_IDTextEdit = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.t_TenantsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ItemForAlarmAdmin = new DevExpress.XtraLayout.LayoutControlItem();
            this.AlarmAdminTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.ItemForT_Tenant = new DevExpress.XtraLayout.LayoutControlItem();
            this.T_TenantTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.ItemForAlarmDateH = new DevExpress.XtraLayout.LayoutControlItem();
            this.AlarmDateHTextEdit = new DevExpress.XtraEditors.DateEdit();
            this.ItemForAlarmDateG = new DevExpress.XtraLayout.LayoutControlItem();
            this.AlarmDateGTextEdit = new DevExpress.XtraEditors.DateEdit();
            this.ItemForAlarmSubject = new DevExpress.XtraLayout.LayoutControlItem();
            this.AlarmSubjectTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.ItemForAlarmDetail = new DevExpress.XtraLayout.LayoutControlItem();
            this.AlarmDetailTextEdit = new DevExpress.XtraEditors.MemoEdit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t_AlarmTenantsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForAlarmTenantID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AlarmTenantIDTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForAlarmTenantNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AlarmTenantNoTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemFortenant_ID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tenant_IDTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t_TenantsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForAlarmAdmin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AlarmAdminTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForT_Tenant)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.T_TenantTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForAlarmDateH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AlarmDateHTextEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AlarmDateHTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForAlarmDateG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AlarmDateGTextEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AlarmDateGTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForAlarmSubject)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AlarmSubjectTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForAlarmDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AlarmDetailTextEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // ubar1
            // 
            this.ubar1.BindingSource = this.t_AlarmTenantsBindingSource;
            this.ubar1.Location = new System.Drawing.Point(0, 307);
            this.ubar1.Size = new System.Drawing.Size(642, 58);
            this.ubar1.Button_Save_Click += new InvAcc.Controls.Ubar.customMessageHandler(this.ubar1_Button_Save_Click);
            this.ubar1.Button_Delete_Click += new InvAcc.Controls.Ubar.customMessageHandler(this.ubar1_Button_Delete_Click);
            this.ubar1.Button_Close_Click += new InvAcc.Controls.Ubar.customMessageHandler(this.ubar1_Button_Close_Click);
            this.ubar1.Button_Search_Click += new InvAcc.Controls.Ubar.customMessageHandler(this.ubar1_Button_Search_Click);
            this.ubar1.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.ubar1_HelpRequested);
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.Controls.Add(this.AlarmTenantIDTextEdit);
            this.dataLayoutControl1.Controls.Add(this.AlarmTenantNoTextEdit);
            this.dataLayoutControl1.Controls.Add(this.AlarmSubjectTextEdit);
            this.dataLayoutControl1.Controls.Add(this.AlarmAdminTextEdit);
            this.dataLayoutControl1.Controls.Add(this.T_TenantTextEdit);
            this.dataLayoutControl1.Controls.Add(this.AlarmDetailTextEdit);
            this.dataLayoutControl1.Controls.Add(this.AlarmDateHTextEdit);
            this.dataLayoutControl1.Controls.Add(this.AlarmDateGTextEdit);
            this.dataLayoutControl1.Controls.Add(this.tenant_IDTextEdit);
            this.dataLayoutControl1.DataSource = this.t_AlarmTenantsBindingSource;
            this.dataLayoutControl1.OptionsView.HighlightFocusedItem = true;
            this.dataLayoutControl1.OptionsView.RightToLeftMirroringApplied = true;
            this.dataLayoutControl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dataLayoutControl1.Size = new System.Drawing.Size(642, 307);
            // 
            // Root
            // 
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup1});
            this.Root.Size = new System.Drawing.Size(642, 307);
            // 
            // t_AlarmTenantsBindingSource
            // 
            this.t_AlarmTenantsBindingSource.DataSource = typeof(ProShared.Stock_Data.T_AlarmTenant);
            this.t_AlarmTenantsBindingSource.AddingNew += new System.ComponentModel.AddingNewEventHandler(this.t_AlarmTenantsBindingSource_AddingNew);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.AllowDrawBackground = false;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForAlarmTenantID,
            this.ItemForAlarmTenantNo,
            this.ItemFortenant_ID,
            this.ItemForAlarmAdmin,
            this.ItemForT_Tenant,
            this.ItemForAlarmDateH,
            this.ItemForAlarmDateG,
            this.ItemForAlarmSubject,
            this.ItemForAlarmDetail});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "autoGeneratedGroup0";
            this.layoutControlGroup1.Size = new System.Drawing.Size(622, 287);
            // 
            // ItemForAlarmTenantID
            // 
            this.ItemForAlarmTenantID.Control = this.AlarmTenantIDTextEdit;
            this.ItemForAlarmTenantID.Location = new System.Drawing.Point(0, 0);
            this.ItemForAlarmTenantID.Name = "ItemForAlarmTenantID";
            this.ItemForAlarmTenantID.Size = new System.Drawing.Size(622, 24);
            this.ItemForAlarmTenantID.Text = "Alarm Tenant ID";
            this.ItemForAlarmTenantID.TextSize = new System.Drawing.Size(78, 13);
            this.ItemForAlarmTenantID.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // AlarmTenantIDTextEdit
            // 
            this.AlarmTenantIDTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.t_AlarmTenantsBindingSource, "AlarmTenantID", true));
            this.AlarmTenantIDTextEdit.Location = new System.Drawing.Point(12, 12);
            this.AlarmTenantIDTextEdit.Name = "AlarmTenantIDTextEdit";
            this.AlarmTenantIDTextEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.AlarmTenantIDTextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.AlarmTenantIDTextEdit.Properties.Mask.EditMask = "N0";
            this.AlarmTenantIDTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.AlarmTenantIDTextEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.AlarmTenantIDTextEdit.Size = new System.Drawing.Size(536, 20);
            this.AlarmTenantIDTextEdit.StyleController = this.dataLayoutControl1;
            this.AlarmTenantIDTextEdit.TabIndex = 4;
            // 
            // ItemForAlarmTenantNo
            // 
            this.ItemForAlarmTenantNo.Control = this.AlarmTenantNoTextEdit;
            this.ItemForAlarmTenantNo.Location = new System.Drawing.Point(352, 24);
            this.ItemForAlarmTenantNo.Name = "ItemForAlarmTenantNo";
            this.ItemForAlarmTenantNo.Size = new System.Drawing.Size(270, 24);
            this.ItemForAlarmTenantNo.Text = "رقم الاشعار";
            this.ItemForAlarmTenantNo.TextSize = new System.Drawing.Size(78, 13);
            // 
            // AlarmTenantNoTextEdit
            // 
            this.AlarmTenantNoTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.t_AlarmTenantsBindingSource, "AlarmTenantNo", true));
            this.AlarmTenantNoTextEdit.Location = new System.Drawing.Point(364, 36);
            this.AlarmTenantNoTextEdit.Name = "AlarmTenantNoTextEdit";
            this.AlarmTenantNoTextEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.AlarmTenantNoTextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.AlarmTenantNoTextEdit.Properties.AppearanceFocused.Options.UseTextOptions = true;
            this.AlarmTenantNoTextEdit.Properties.AppearanceFocused.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.AlarmTenantNoTextEdit.Properties.Mask.EditMask = "N0";
            this.AlarmTenantNoTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.AlarmTenantNoTextEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.AlarmTenantNoTextEdit.Size = new System.Drawing.Size(184, 20);
            this.AlarmTenantNoTextEdit.StyleController = this.dataLayoutControl1;
            this.AlarmTenantNoTextEdit.TabIndex = 5;
            // 
            // ItemFortenant_ID
            // 
            this.ItemFortenant_ID.Control = this.tenant_IDTextEdit;
            this.ItemFortenant_ID.Location = new System.Drawing.Point(0, 48);
            this.ItemFortenant_ID.Name = "ItemFortenant_ID";
            this.ItemFortenant_ID.Size = new System.Drawing.Size(622, 24);
            this.ItemFortenant_ID.Text = "المستاجر";
            this.ItemFortenant_ID.TextSize = new System.Drawing.Size(78, 13);
            // 
            // tenant_IDTextEdit
            // 
            this.tenant_IDTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.t_AlarmTenantsBindingSource, "tenant_ID", true));
            this.tenant_IDTextEdit.Location = new System.Drawing.Point(12, 60);
            this.tenant_IDTextEdit.Name = "tenant_IDTextEdit";
            this.tenant_IDTextEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.tenant_IDTextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.tenant_IDTextEdit.Properties.AppearanceFocused.Options.UseTextOptions = true;
            this.tenant_IDTextEdit.Properties.AppearanceFocused.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.tenant_IDTextEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tenant_IDTextEdit.Properties.DataSource = this.t_TenantsBindingSource;
            this.tenant_IDTextEdit.Properties.DisplayMember = "NameA";
            this.tenant_IDTextEdit.Properties.NullText = "";
            this.tenant_IDTextEdit.Properties.PopupView = this.searchLookUpEdit1View;
            this.tenant_IDTextEdit.Properties.ValueMember = "tenantID";
            this.tenant_IDTextEdit.Size = new System.Drawing.Size(536, 20);
            this.tenant_IDTextEdit.StyleController = this.dataLayoutControl1;
            this.tenant_IDTextEdit.TabIndex = 8;
            // 
            // t_TenantsBindingSource
            // 
            this.t_TenantsBindingSource.DataSource = typeof(ProShared.Stock_Data.T_Tenant);
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // ItemForAlarmAdmin
            // 
            this.ItemForAlarmAdmin.Control = this.AlarmAdminTextEdit;
            this.ItemForAlarmAdmin.Location = new System.Drawing.Point(0, 72);
            this.ItemForAlarmAdmin.Name = "ItemForAlarmAdmin";
            this.ItemForAlarmAdmin.Size = new System.Drawing.Size(622, 24);
            this.ItemForAlarmAdmin.Text = "المسؤول";
            this.ItemForAlarmAdmin.TextSize = new System.Drawing.Size(78, 13);
            // 
            // AlarmAdminTextEdit
            // 
            this.AlarmAdminTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.t_AlarmTenantsBindingSource, "AlarmAdmin", true));
            this.AlarmAdminTextEdit.Location = new System.Drawing.Point(12, 84);
            this.AlarmAdminTextEdit.Name = "AlarmAdminTextEdit";
            this.AlarmAdminTextEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.AlarmAdminTextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.AlarmAdminTextEdit.Properties.AppearanceFocused.Options.UseTextOptions = true;
            this.AlarmAdminTextEdit.Properties.AppearanceFocused.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.AlarmAdminTextEdit.Size = new System.Drawing.Size(536, 20);
            this.AlarmAdminTextEdit.StyleController = this.dataLayoutControl1;
            this.AlarmAdminTextEdit.TabIndex = 11;
            // 
            // ItemForT_Tenant
            // 
            this.ItemForT_Tenant.Control = this.T_TenantTextEdit;
            this.ItemForT_Tenant.Location = new System.Drawing.Point(0, 263);
            this.ItemForT_Tenant.Name = "ItemForT_Tenant";
            this.ItemForT_Tenant.Size = new System.Drawing.Size(622, 24);
            this.ItemForT_Tenant.Text = "T_Tenant";
            this.ItemForT_Tenant.TextSize = new System.Drawing.Size(78, 13);
            this.ItemForT_Tenant.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // T_TenantTextEdit
            // 
            this.T_TenantTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.t_AlarmTenantsBindingSource, "T_Tenant", true));
            this.T_TenantTextEdit.Location = new System.Drawing.Point(12, 275);
            this.T_TenantTextEdit.Name = "T_TenantTextEdit";
            this.T_TenantTextEdit.Size = new System.Drawing.Size(536, 20);
            this.T_TenantTextEdit.StyleController = this.dataLayoutControl1;
            this.T_TenantTextEdit.TabIndex = 12;
            // 
            // ItemForAlarmDateH
            // 
            this.ItemForAlarmDateH.Control = this.AlarmDateHTextEdit;
            this.ItemForAlarmDateH.Location = new System.Drawing.Point(155, 24);
            this.ItemForAlarmDateH.Name = "ItemForAlarmDateH";
            this.ItemForAlarmDateH.Size = new System.Drawing.Size(197, 24);
            this.ItemForAlarmDateH.Text = "التاريخ الهجري";
            this.ItemForAlarmDateH.TextSize = new System.Drawing.Size(78, 13);
            // 
            // AlarmDateHTextEdit
            // 
            this.AlarmDateHTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.t_AlarmTenantsBindingSource, "AlarmDateH", true));
            this.AlarmDateHTextEdit.EditValue = null;
            this.AlarmDateHTextEdit.Location = new System.Drawing.Point(167, 36);
            this.AlarmDateHTextEdit.Name = "AlarmDateHTextEdit";
            this.AlarmDateHTextEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.AlarmDateHTextEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.AlarmDateHTextEdit.Properties.CalendarTimeProperties.DisplayFormat.FormatString = "d";
            this.AlarmDateHTextEdit.Properties.CalendarTimeProperties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.AlarmDateHTextEdit.Properties.CalendarTimeProperties.EditFormat.FormatString = "d";
            this.AlarmDateHTextEdit.Properties.CalendarTimeProperties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.AlarmDateHTextEdit.Properties.CalendarTimeProperties.UseMaskAsDisplayFormat = true;
            this.AlarmDateHTextEdit.Properties.MaskSettings.Set("mask", "");
            this.AlarmDateHTextEdit.Properties.ReadOnly = true;
            this.AlarmDateHTextEdit.Properties.UseMaskAsDisplayFormat = true;
            this.AlarmDateHTextEdit.Properties.XlsxFormatString = "d";
            this.AlarmDateHTextEdit.Size = new System.Drawing.Size(111, 20);
            this.AlarmDateHTextEdit.StyleController = this.dataLayoutControl1;
            this.AlarmDateHTextEdit.TabIndex = 7;
            this.AlarmDateHTextEdit.EditValueChanged += new System.EventHandler(this.AlarmDateHTextEdit_EditValueChanged_1);
            // 
            // ItemForAlarmDateG
            // 
            this.ItemForAlarmDateG.Control = this.AlarmDateGTextEdit;
            this.ItemForAlarmDateG.Location = new System.Drawing.Point(0, 24);
            this.ItemForAlarmDateG.Name = "ItemForAlarmDateG";
            this.ItemForAlarmDateG.Size = new System.Drawing.Size(155, 24);
            this.ItemForAlarmDateG.Text = "التاريخ الميلادي";
            this.ItemForAlarmDateG.TextSize = new System.Drawing.Size(78, 13);
            // 
            // AlarmDateGTextEdit
            // 
            this.AlarmDateGTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.t_AlarmTenantsBindingSource, "AlarmDateG", true));
            this.AlarmDateGTextEdit.EditValue = null;
            this.AlarmDateGTextEdit.Location = new System.Drawing.Point(12, 36);
            this.AlarmDateGTextEdit.Name = "AlarmDateGTextEdit";
            this.AlarmDateGTextEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.AlarmDateGTextEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.AlarmDateGTextEdit.Properties.CalendarTimeProperties.DisplayFormat.FormatString = "d";
            this.AlarmDateGTextEdit.Properties.CalendarTimeProperties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.AlarmDateGTextEdit.Properties.CalendarTimeProperties.EditFormat.FormatString = "d";
            this.AlarmDateGTextEdit.Properties.CalendarTimeProperties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.AlarmDateGTextEdit.Properties.CalendarTimeProperties.UseMaskAsDisplayFormat = true;
            this.AlarmDateGTextEdit.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Fluent;
            this.AlarmDateGTextEdit.Properties.MaskSettings.Set("mask", "");
            this.AlarmDateGTextEdit.Properties.UseMaskAsDisplayFormat = true;
            this.AlarmDateGTextEdit.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.False;
            this.AlarmDateGTextEdit.Properties.XlsxFormatString = "d";
            this.AlarmDateGTextEdit.Size = new System.Drawing.Size(69, 20);
            this.AlarmDateGTextEdit.StyleController = this.dataLayoutControl1;
            this.AlarmDateGTextEdit.TabIndex = 6;
            this.AlarmDateGTextEdit.EditValueChanged += new System.EventHandler(this.AlarmDateHTextEdit_EditValueChanged_1);
            // 
            // ItemForAlarmSubject
            // 
            this.ItemForAlarmSubject.Control = this.AlarmSubjectTextEdit;
            this.ItemForAlarmSubject.Location = new System.Drawing.Point(0, 96);
            this.ItemForAlarmSubject.Name = "ItemForAlarmSubject";
            this.ItemForAlarmSubject.Size = new System.Drawing.Size(622, 24);
            this.ItemForAlarmSubject.Text = "الموضوع";
            this.ItemForAlarmSubject.TextSize = new System.Drawing.Size(78, 13);
            // 
            // AlarmSubjectTextEdit
            // 
            this.AlarmSubjectTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.t_AlarmTenantsBindingSource, "AlarmSubject", true));
            this.AlarmSubjectTextEdit.Location = new System.Drawing.Point(12, 108);
            this.AlarmSubjectTextEdit.Name = "AlarmSubjectTextEdit";
            this.AlarmSubjectTextEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.AlarmSubjectTextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.AlarmSubjectTextEdit.Properties.AppearanceFocused.Options.UseTextOptions = true;
            this.AlarmSubjectTextEdit.Properties.AppearanceFocused.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.AlarmSubjectTextEdit.Size = new System.Drawing.Size(536, 20);
            this.AlarmSubjectTextEdit.StyleController = this.dataLayoutControl1;
            this.AlarmSubjectTextEdit.TabIndex = 9;
            // 
            // ItemForAlarmDetail
            // 
            this.ItemForAlarmDetail.Control = this.AlarmDetailTextEdit;
            this.ItemForAlarmDetail.Location = new System.Drawing.Point(0, 120);
            this.ItemForAlarmDetail.Name = "ItemForAlarmDetail";
            this.ItemForAlarmDetail.Size = new System.Drawing.Size(622, 143);
            this.ItemForAlarmDetail.Text = "التفاصيل";
            this.ItemForAlarmDetail.TextSize = new System.Drawing.Size(78, 13);
            // 
            // AlarmDetailTextEdit
            // 
            this.AlarmDetailTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.t_AlarmTenantsBindingSource, "AlarmDetail", true));
            this.AlarmDetailTextEdit.Location = new System.Drawing.Point(12, 132);
            this.AlarmDetailTextEdit.Name = "AlarmDetailTextEdit";
            this.AlarmDetailTextEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.AlarmDetailTextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.AlarmDetailTextEdit.Properties.AppearanceFocused.Options.UseTextOptions = true;
            this.AlarmDetailTextEdit.Properties.AppearanceFocused.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.AlarmDetailTextEdit.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.AlarmDetailTextEdit.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.AlarmDetailTextEdit.Size = new System.Drawing.Size(536, 139);
            this.AlarmDetailTextEdit.StyleController = this.dataLayoutControl1;
            this.AlarmDetailTextEdit.TabIndex = 10;
            // 
            // XFrmAlarmTenant
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 365);
            this.Name = "XFrmAlarmTenant";
            this.Text = "تنبيهات المستاجر";
            this.Load += new System.EventHandler(this.XFrmAlarmTenant_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t_AlarmTenantsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForAlarmTenantID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AlarmTenantIDTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForAlarmTenantNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AlarmTenantNoTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemFortenant_ID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tenant_IDTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t_TenantsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForAlarmAdmin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AlarmAdminTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForT_Tenant)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.T_TenantTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForAlarmDateH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AlarmDateHTextEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AlarmDateHTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForAlarmDateG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AlarmDateGTextEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AlarmDateGTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForAlarmSubject)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AlarmSubjectTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForAlarmDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AlarmDetailTextEdit.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource t_AlarmTenantsBindingSource;
        private DevExpress.XtraEditors.TextEdit AlarmTenantIDTextEdit;
        private DevExpress.XtraEditors.TextEdit AlarmTenantNoTextEdit;
        private DevExpress.XtraEditors.TextEdit AlarmSubjectTextEdit;
        private DevExpress.XtraEditors.TextEdit AlarmAdminTextEdit;
        private DevExpress.XtraEditors.TextEdit T_TenantTextEdit;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem ItemForAlarmTenantID;
        private DevExpress.XtraLayout.LayoutControlItem ItemForAlarmTenantNo;
        private DevExpress.XtraLayout.LayoutControlItem ItemForAlarmDateG;
        private DevExpress.XtraLayout.LayoutControlItem ItemForAlarmDateH;
        private DevExpress.XtraLayout.LayoutControlItem ItemFortenant_ID;
        private DevExpress.XtraLayout.LayoutControlItem ItemForAlarmSubject;
        private DevExpress.XtraLayout.LayoutControlItem ItemForAlarmDetail;
        private DevExpress.XtraLayout.LayoutControlItem ItemForAlarmAdmin;
        private DevExpress.XtraLayout.LayoutControlItem ItemForT_Tenant;
        private System.Windows.Forms.BindingSource t_TenantsBindingSource;
        private DevExpress.XtraEditors.MemoEdit AlarmDetailTextEdit;
        private DevExpress.XtraEditors.DateEdit AlarmDateHTextEdit;
        private DevExpress.XtraEditors.DateEdit AlarmDateGTextEdit;
        private DevExpress.XtraEditors.SearchLookUpEdit tenant_IDTextEdit;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
    }
}