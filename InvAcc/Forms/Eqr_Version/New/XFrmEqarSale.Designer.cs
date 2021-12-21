namespace InvAcc.Forms.Eqr_Version.New
{
    partial class XFrmEqarSale
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
            this.t_EqarSalesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForEqarSaleID = new DevExpress.XtraLayout.LayoutControlItem();
            this.EqarSaleIDTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.ItemForEqarSaleNo = new DevExpress.XtraLayout.LayoutControlItem();
            this.EqarSaleNoTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.ItemForEqarID = new DevExpress.XtraLayout.LayoutControlItem();
            this.EqarIDTextEdit = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.t_EqarsDatasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ItemForAinID = new DevExpress.XtraLayout.LayoutControlItem();
            this.AinIDTextEdit = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.t_AinTypsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ItemForGDate = new DevExpress.XtraLayout.LayoutControlItem();
            this.GDateTextEdit = new DevExpress.XtraEditors.DateEdit();
            this.ItemForSaleValue = new DevExpress.XtraLayout.LayoutControlItem();
            this.SaleValueTextEdit = new DevExpress.XtraEditors.SpinEdit();
            this.ItemForNote = new DevExpress.XtraLayout.LayoutControlItem();
            this.NoteTextEdit = new DevExpress.XtraEditors.MemoEdit();
            this.ItemForT_AinsData = new DevExpress.XtraLayout.LayoutControlItem();
            this.T_AinsDataTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.ItemForT_EqarsData = new DevExpress.XtraLayout.LayoutControlItem();
            this.T_EqarsDataTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.ItemForHDate = new DevExpress.XtraLayout.LayoutControlItem();
            this.HDateTextEdit = new DevExpress.XtraEditors.DateEdit();
            this.simpleLabelItem1 = new DevExpress.XtraLayout.SimpleLabelItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t_EqarSalesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForEqarSaleID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EqarSaleIDTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForEqarSaleNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EqarSaleNoTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForEqarID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EqarIDTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t_EqarsDatasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForAinID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AinIDTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t_AinTypsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForGDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GDateTextEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GDateTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForSaleValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SaleValueTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForNote)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NoteTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForT_AinsData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.T_AinsDataTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForT_EqarsData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.T_EqarsDataTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForHDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HDateTextEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HDateTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleLabelItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // ubar1
            // 
            this.ubar1.BindingSource = this.t_EqarSalesBindingSource;
            this.ubar1.Location = new System.Drawing.Point(0, 281);
            this.ubar1.Size = new System.Drawing.Size(582, 58);
            this.ubar1.Button_Search_Click += new InvAcc.Controls.Ubar.customMessageHandler(this.ubar1_Button_Search_Click);
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.Controls.Add(this.EqarSaleIDTextEdit);
            this.dataLayoutControl1.Controls.Add(this.EqarSaleNoTextEdit);
            this.dataLayoutControl1.Controls.Add(this.T_AinsDataTextEdit);
            this.dataLayoutControl1.Controls.Add(this.T_EqarsDataTextEdit);
            this.dataLayoutControl1.Controls.Add(this.HDateTextEdit);
            this.dataLayoutControl1.Controls.Add(this.GDateTextEdit);
            this.dataLayoutControl1.Controls.Add(this.EqarIDTextEdit);
            this.dataLayoutControl1.Controls.Add(this.AinIDTextEdit);
            this.dataLayoutControl1.Controls.Add(this.NoteTextEdit);
            this.dataLayoutControl1.Controls.Add(this.SaleValueTextEdit);
            this.dataLayoutControl1.DataSource = this.t_EqarSalesBindingSource;
            this.dataLayoutControl1.OptionsView.HighlightFocusedItem = true;
            this.dataLayoutControl1.OptionsView.RightToLeftMirroringApplied = true;
            this.dataLayoutControl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dataLayoutControl1.Size = new System.Drawing.Size(582, 281);
            // 
            // Root
            // 
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup1});
            this.Root.Size = new System.Drawing.Size(582, 281);
            // 
            // t_EqarSalesBindingSource
            // 
            this.t_EqarSalesBindingSource.DataSource = typeof(ProShared.Stock_Data.T_EqarSale);
            this.t_EqarSalesBindingSource.AddingNew += new System.ComponentModel.AddingNewEventHandler(this.t_EqarSalesBindingSource_AddingNew);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.AllowDrawBackground = false;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForEqarSaleID,
            this.ItemForEqarSaleNo,
            this.ItemForEqarID,
            this.ItemForAinID,
            this.ItemForGDate,
            this.ItemForSaleValue,
            this.ItemForNote,
            this.ItemForT_AinsData,
            this.ItemForT_EqarsData,
            this.ItemForHDate,
            this.simpleLabelItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "autoGeneratedGroup0";
            this.layoutControlGroup1.Size = new System.Drawing.Size(562, 261);
            // 
            // ItemForEqarSaleID
            // 
            this.ItemForEqarSaleID.Control = this.EqarSaleIDTextEdit;
            this.ItemForEqarSaleID.Location = new System.Drawing.Point(0, 0);
            this.ItemForEqarSaleID.Name = "ItemForEqarSaleID";
            this.ItemForEqarSaleID.Size = new System.Drawing.Size(562, 24);
            this.ItemForEqarSaleID.Text = "Eqar Sale ID";
            this.ItemForEqarSaleID.TextSize = new System.Drawing.Size(65, 13);
            this.ItemForEqarSaleID.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // EqarSaleIDTextEdit
            // 
            this.EqarSaleIDTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.t_EqarSalesBindingSource, "EqarSaleID", true));
            this.EqarSaleIDTextEdit.Location = new System.Drawing.Point(12, 12);
            this.EqarSaleIDTextEdit.Name = "EqarSaleIDTextEdit";
            this.EqarSaleIDTextEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.EqarSaleIDTextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.EqarSaleIDTextEdit.Properties.Mask.EditMask = "N0";
            this.EqarSaleIDTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.EqarSaleIDTextEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.EqarSaleIDTextEdit.Size = new System.Drawing.Size(489, 20);
            this.EqarSaleIDTextEdit.StyleController = this.dataLayoutControl1;
            this.EqarSaleIDTextEdit.TabIndex = 4;
            // 
            // ItemForEqarSaleNo
            // 
            this.ItemForEqarSaleNo.Control = this.EqarSaleNoTextEdit;
            this.ItemForEqarSaleNo.Location = new System.Drawing.Point(0, 24);
            this.ItemForEqarSaleNo.Name = "ItemForEqarSaleNo";
            this.ItemForEqarSaleNo.Size = new System.Drawing.Size(562, 24);
            this.ItemForEqarSaleNo.Text = "رقم البيع:";
            this.ItemForEqarSaleNo.TextSize = new System.Drawing.Size(65, 13);
            // 
            // EqarSaleNoTextEdit
            // 
            this.EqarSaleNoTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.t_EqarSalesBindingSource, "EqarSaleNo", true));
            this.EqarSaleNoTextEdit.Location = new System.Drawing.Point(12, 36);
            this.EqarSaleNoTextEdit.Name = "EqarSaleNoTextEdit";
            this.EqarSaleNoTextEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.EqarSaleNoTextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.EqarSaleNoTextEdit.Properties.AppearanceFocused.Options.UseTextOptions = true;
            this.EqarSaleNoTextEdit.Properties.AppearanceFocused.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.EqarSaleNoTextEdit.Size = new System.Drawing.Size(489, 20);
            this.EqarSaleNoTextEdit.StyleController = this.dataLayoutControl1;
            this.EqarSaleNoTextEdit.TabIndex = 5;
            // 
            // ItemForEqarID
            // 
            this.ItemForEqarID.Control = this.EqarIDTextEdit;
            this.ItemForEqarID.Location = new System.Drawing.Point(0, 48);
            this.ItemForEqarID.Name = "ItemForEqarID";
            this.ItemForEqarID.Size = new System.Drawing.Size(562, 24);
            this.ItemForEqarID.Text = "العقار";
            this.ItemForEqarID.TextSize = new System.Drawing.Size(65, 13);
            // 
            // EqarIDTextEdit
            // 
            this.EqarIDTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.t_EqarSalesBindingSource, "EqarID", true));
            this.EqarIDTextEdit.Location = new System.Drawing.Point(12, 60);
            this.EqarIDTextEdit.Name = "EqarIDTextEdit";
            this.EqarIDTextEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.EqarIDTextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.EqarIDTextEdit.Properties.AppearanceFocused.Options.UseTextOptions = true;
            this.EqarIDTextEdit.Properties.AppearanceFocused.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.EqarIDTextEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.EqarIDTextEdit.Properties.DataSource = this.t_EqarsDatasBindingSource;
            this.EqarIDTextEdit.Properties.DisplayMember = "NameA";
            this.EqarIDTextEdit.Properties.NullText = "";
            this.EqarIDTextEdit.Properties.PopupView = this.gridView1;
            this.EqarIDTextEdit.Properties.ValueMember = "EqarID";
            this.EqarIDTextEdit.Size = new System.Drawing.Size(489, 20);
            this.EqarIDTextEdit.StyleController = this.dataLayoutControl1;
            this.EqarIDTextEdit.TabIndex = 6;
            // 
            // t_EqarsDatasBindingSource
            // 
            this.t_EqarsDatasBindingSource.DataSource = typeof(ProShared.Stock_Data.T_EqarsData);
            // 
            // gridView1
            // 
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // ItemForAinID
            // 
            this.ItemForAinID.Control = this.AinIDTextEdit;
            this.ItemForAinID.Location = new System.Drawing.Point(0, 72);
            this.ItemForAinID.Name = "ItemForAinID";
            this.ItemForAinID.Size = new System.Drawing.Size(562, 24);
            this.ItemForAinID.Text = "العين";
            this.ItemForAinID.TextSize = new System.Drawing.Size(65, 13);
            // 
            // AinIDTextEdit
            // 
            this.AinIDTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.t_EqarSalesBindingSource, "AinID", true));
            this.AinIDTextEdit.Location = new System.Drawing.Point(12, 84);
            this.AinIDTextEdit.Name = "AinIDTextEdit";
            this.AinIDTextEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.AinIDTextEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.AinIDTextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.AinIDTextEdit.Properties.AppearanceFocused.Options.UseTextOptions = true;
            this.AinIDTextEdit.Properties.AppearanceFocused.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.AinIDTextEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.AinIDTextEdit.Properties.DataSource = this.t_AinTypsBindingSource;
            this.AinIDTextEdit.Properties.DisplayMember = "NameA";
            this.AinIDTextEdit.Properties.NullText = "";
            this.AinIDTextEdit.Properties.PopupView = this.gridView2;
            this.AinIDTextEdit.Properties.ValueMember = "AinTyp_No";
            this.AinIDTextEdit.Size = new System.Drawing.Size(489, 20);
            this.AinIDTextEdit.StyleController = this.dataLayoutControl1;
            this.AinIDTextEdit.TabIndex = 7;
            // 
            // t_AinTypsBindingSource
            // 
            this.t_AinTypsBindingSource.DataSource = typeof(ProShared.Stock_Data.T_AinTyp);
            // 
            // gridView2
            // 
            this.gridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // ItemForGDate
            // 
            this.ItemForGDate.Control = this.GDateTextEdit;
            this.ItemForGDate.Location = new System.Drawing.Point(281, 96);
            this.ItemForGDate.Name = "ItemForGDate";
            this.ItemForGDate.Size = new System.Drawing.Size(165, 24);
            this.ItemForGDate.Text = "الميلادي:";
            this.ItemForGDate.TextSize = new System.Drawing.Size(65, 13);
            // 
            // GDateTextEdit
            // 
            this.GDateTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.t_EqarSalesBindingSource, "GDate", true));
            this.GDateTextEdit.EditValue = null;
            this.GDateTextEdit.Location = new System.Drawing.Point(293, 108);
            this.GDateTextEdit.Name = "GDateTextEdit";
            this.GDateTextEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.GDateTextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.GDateTextEdit.Properties.AppearanceFocused.Options.UseTextOptions = true;
            this.GDateTextEdit.Properties.AppearanceFocused.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.GDateTextEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.GDateTextEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.GDateTextEdit.Properties.CalendarTimeProperties.DisplayFormat.FormatString = "d";
            this.GDateTextEdit.Properties.CalendarTimeProperties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.GDateTextEdit.Properties.CalendarTimeProperties.EditFormat.FormatString = "d";
            this.GDateTextEdit.Properties.CalendarTimeProperties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.GDateTextEdit.Properties.CalendarTimeProperties.UseMaskAsDisplayFormat = true;
            this.GDateTextEdit.Properties.CalendarTimeProperties.XlsxFormatString = "d";
            this.GDateTextEdit.Properties.MaskSettings.Set("mask", "");
            this.GDateTextEdit.Properties.UseMaskAsDisplayFormat = true;
            this.GDateTextEdit.Properties.XlsxFormatString = "d";
            this.GDateTextEdit.Size = new System.Drawing.Size(92, 20);
            this.GDateTextEdit.StyleController = this.dataLayoutControl1;
            this.GDateTextEdit.TabIndex = 8;
            this.GDateTextEdit.EditValueChanged += new System.EventHandler(this.GDateTextEdit_EditValueChanged);
            // 
            // ItemForSaleValue
            // 
            this.ItemForSaleValue.Control = this.SaleValueTextEdit;
            this.ItemForSaleValue.Location = new System.Drawing.Point(0, 120);
            this.ItemForSaleValue.Name = "ItemForSaleValue";
            this.ItemForSaleValue.Size = new System.Drawing.Size(562, 24);
            this.ItemForSaleValue.Text = "القيمة";
            this.ItemForSaleValue.TextSize = new System.Drawing.Size(65, 13);
            // 
            // SaleValueTextEdit
            // 
            this.SaleValueTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.t_EqarSalesBindingSource, "SaleValue", true));
            this.SaleValueTextEdit.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.SaleValueTextEdit.Location = new System.Drawing.Point(12, 132);
            this.SaleValueTextEdit.Name = "SaleValueTextEdit";
            this.SaleValueTextEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.SaleValueTextEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.SaleValueTextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.SaleValueTextEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.SaleValueTextEdit.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            this.SaleValueTextEdit.Properties.Mask.EditMask = "F";
            this.SaleValueTextEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.SaleValueTextEdit.Size = new System.Drawing.Size(489, 20);
            this.SaleValueTextEdit.StyleController = this.dataLayoutControl1;
            this.SaleValueTextEdit.TabIndex = 10;
            // 
            // ItemForNote
            // 
            this.ItemForNote.Control = this.NoteTextEdit;
            this.ItemForNote.Location = new System.Drawing.Point(0, 144);
            this.ItemForNote.Name = "ItemForNote";
            this.ItemForNote.Size = new System.Drawing.Size(562, 69);
            this.ItemForNote.Text = "ملاحظات";
            this.ItemForNote.TextSize = new System.Drawing.Size(65, 13);
            // 
            // NoteTextEdit
            // 
            this.NoteTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.t_EqarSalesBindingSource, "Note", true));
            this.NoteTextEdit.Location = new System.Drawing.Point(12, 156);
            this.NoteTextEdit.Name = "NoteTextEdit";
            this.NoteTextEdit.Size = new System.Drawing.Size(489, 65);
            this.NoteTextEdit.StyleController = this.dataLayoutControl1;
            this.NoteTextEdit.TabIndex = 11;
            // 
            // ItemForT_AinsData
            // 
            this.ItemForT_AinsData.Control = this.T_AinsDataTextEdit;
            this.ItemForT_AinsData.Location = new System.Drawing.Point(0, 213);
            this.ItemForT_AinsData.Name = "ItemForT_AinsData";
            this.ItemForT_AinsData.Size = new System.Drawing.Size(562, 24);
            this.ItemForT_AinsData.Text = "T_Ains Data";
            this.ItemForT_AinsData.TextSize = new System.Drawing.Size(65, 13);
            this.ItemForT_AinsData.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // T_AinsDataTextEdit
            // 
            this.T_AinsDataTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.t_EqarSalesBindingSource, "T_AinsData", true));
            this.T_AinsDataTextEdit.Location = new System.Drawing.Point(12, 225);
            this.T_AinsDataTextEdit.Name = "T_AinsDataTextEdit";
            this.T_AinsDataTextEdit.Size = new System.Drawing.Size(489, 20);
            this.T_AinsDataTextEdit.StyleController = this.dataLayoutControl1;
            this.T_AinsDataTextEdit.TabIndex = 12;
            // 
            // ItemForT_EqarsData
            // 
            this.ItemForT_EqarsData.Control = this.T_EqarsDataTextEdit;
            this.ItemForT_EqarsData.Location = new System.Drawing.Point(0, 237);
            this.ItemForT_EqarsData.Name = "ItemForT_EqarsData";
            this.ItemForT_EqarsData.Size = new System.Drawing.Size(562, 24);
            this.ItemForT_EqarsData.Text = "T_Eqars Data";
            this.ItemForT_EqarsData.TextSize = new System.Drawing.Size(65, 13);
            this.ItemForT_EqarsData.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // T_EqarsDataTextEdit
            // 
            this.T_EqarsDataTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.t_EqarSalesBindingSource, "T_EqarsData", true));
            this.T_EqarsDataTextEdit.Location = new System.Drawing.Point(12, 249);
            this.T_EqarsDataTextEdit.Name = "T_EqarsDataTextEdit";
            this.T_EqarsDataTextEdit.Size = new System.Drawing.Size(489, 20);
            this.T_EqarsDataTextEdit.StyleController = this.dataLayoutControl1;
            this.T_EqarsDataTextEdit.TabIndex = 13;
            // 
            // ItemForHDate
            // 
            this.ItemForHDate.Control = this.HDateTextEdit;
            this.ItemForHDate.Location = new System.Drawing.Point(0, 96);
            this.ItemForHDate.Name = "ItemForHDate";
            this.ItemForHDate.Size = new System.Drawing.Size(281, 24);
            this.ItemForHDate.Text = "الهجري";
            this.ItemForHDate.TextSize = new System.Drawing.Size(65, 13);
            // 
            // HDateTextEdit
            // 
            this.HDateTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.t_EqarSalesBindingSource, "HDate", true));
            this.HDateTextEdit.EditValue = null;
            this.HDateTextEdit.Location = new System.Drawing.Point(12, 108);
            this.HDateTextEdit.Name = "HDateTextEdit";
            this.HDateTextEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.HDateTextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.HDateTextEdit.Properties.AppearanceFocused.Options.UseTextOptions = true;
            this.HDateTextEdit.Properties.AppearanceFocused.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.HDateTextEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.HDateTextEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.HDateTextEdit.Properties.CalendarTimeProperties.DisplayFormat.FormatString = "d";
            this.HDateTextEdit.Properties.CalendarTimeProperties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.HDateTextEdit.Properties.CalendarTimeProperties.EditFormat.FormatString = "d";
            this.HDateTextEdit.Properties.CalendarTimeProperties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.HDateTextEdit.Properties.CalendarTimeProperties.UseMaskAsDisplayFormat = true;
            this.HDateTextEdit.Properties.CalendarTimeProperties.XlsxFormatString = "d";
            this.HDateTextEdit.Properties.MaskSettings.Set("mask", "");
            this.HDateTextEdit.Properties.UseMaskAsDisplayFormat = true;
            this.HDateTextEdit.Properties.XlsxFormatString = "d";
            this.HDateTextEdit.Size = new System.Drawing.Size(208, 20);
            this.HDateTextEdit.StyleController = this.dataLayoutControl1;
            this.HDateTextEdit.TabIndex = 9;
            this.HDateTextEdit.EditValueChanged += new System.EventHandler(this.HDateTextEdit_EditValueChanged);
            // 
            // simpleLabelItem1
            // 
            this.simpleLabelItem1.AllowHotTrack = false;
            this.simpleLabelItem1.Location = new System.Drawing.Point(446, 96);
            this.simpleLabelItem1.Name = "simpleLabelItem1";
            this.simpleLabelItem1.Size = new System.Drawing.Size(116, 24);
            this.simpleLabelItem1.Text = "تاريخ البيع:";
            this.simpleLabelItem1.TextSize = new System.Drawing.Size(65, 13);
            // 
            // XFrmEqarSale
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 339);
            this.Name = "XFrmEqarSale";
            this.Text = "بيع عقار";
            this.Load += new System.EventHandler(this.XFrmEqarSale_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t_EqarSalesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForEqarSaleID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EqarSaleIDTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForEqarSaleNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EqarSaleNoTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForEqarID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EqarIDTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t_EqarsDatasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForAinID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AinIDTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t_AinTypsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForGDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GDateTextEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GDateTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForSaleValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SaleValueTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForNote)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NoteTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForT_AinsData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.T_AinsDataTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForT_EqarsData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.T_EqarsDataTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForHDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HDateTextEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HDateTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleLabelItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource t_EqarSalesBindingSource;
        private DevExpress.XtraEditors.TextEdit EqarSaleIDTextEdit;
        private DevExpress.XtraEditors.TextEdit EqarSaleNoTextEdit;
        private DevExpress.XtraEditors.TextEdit T_AinsDataTextEdit;
        private DevExpress.XtraEditors.TextEdit T_EqarsDataTextEdit;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem ItemForEqarSaleID;
        private DevExpress.XtraLayout.LayoutControlItem ItemForEqarSaleNo;
        private DevExpress.XtraLayout.LayoutControlItem ItemForEqarID;
        private DevExpress.XtraLayout.LayoutControlItem ItemForAinID;
        private DevExpress.XtraLayout.LayoutControlItem ItemForGDate;
        private DevExpress.XtraLayout.LayoutControlItem ItemForHDate;
        private DevExpress.XtraLayout.LayoutControlItem ItemForSaleValue;
        private DevExpress.XtraLayout.LayoutControlItem ItemForNote;
        private DevExpress.XtraLayout.LayoutControlItem ItemForT_AinsData;
        private DevExpress.XtraLayout.LayoutControlItem ItemForT_EqarsData;
        private System.Windows.Forms.BindingSource t_EqarsDatasBindingSource;
        private System.Windows.Forms.BindingSource t_AinTypsBindingSource;
        private DevExpress.XtraEditors.DateEdit HDateTextEdit;
        private DevExpress.XtraEditors.DateEdit GDateTextEdit;
        private DevExpress.XtraLayout.SimpleLabelItem simpleLabelItem1;
        private DevExpress.XtraEditors.SearchLookUpEdit EqarIDTextEdit;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.SearchLookUpEdit AinIDTextEdit;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraEditors.MemoEdit NoteTextEdit;
        private DevExpress.XtraEditors.SpinEdit SaleValueTextEdit;
    }
}