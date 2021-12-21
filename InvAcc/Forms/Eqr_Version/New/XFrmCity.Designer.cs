namespace InvAcc.Forms.Eqr_Version.New
{
    partial class XFrmCity
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
            this.t_CitiesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForCity_ID = new DevExpress.XtraLayout.LayoutControlItem();
            this.City_IDTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.ItemForCity_No = new DevExpress.XtraLayout.LayoutControlItem();
            this.City_NoTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.ItemForNameA = new DevExpress.XtraLayout.LayoutControlItem();
            this.NameATextEdit = new DevExpress.XtraEditors.TextEdit();
            this.ItemForNameE = new DevExpress.XtraLayout.LayoutControlItem();
            this.NameETextEdit = new DevExpress.XtraEditors.TextEdit();
            this.ItemForNote = new DevExpress.XtraLayout.LayoutControlItem();
            this.NoteTextEdit = new DevExpress.XtraEditors.MemoEdit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t_CitiesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForCity_ID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.City_IDTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForCity_No)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.City_NoTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForNameA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NameATextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForNameE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NameETextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForNote)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NoteTextEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // ubar1
            // 
            this.ubar1.BindingSource = this.t_CitiesBindingSource;
            this.ubar1.Location = new System.Drawing.Point(0, 340);
            this.ubar1.Size = new System.Drawing.Size(520, 58);
            this.ubar1.Button_Search_Click += new InvAcc.Controls.Ubar.customMessageHandler(this.ubar1_Button_Search_Click);
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.Controls.Add(this.City_IDTextEdit);
            this.dataLayoutControl1.Controls.Add(this.City_NoTextEdit);
            this.dataLayoutControl1.Controls.Add(this.NameATextEdit);
            this.dataLayoutControl1.Controls.Add(this.NameETextEdit);
            this.dataLayoutControl1.Controls.Add(this.NoteTextEdit);
            this.dataLayoutControl1.DataSource = this.t_CitiesBindingSource;
            this.dataLayoutControl1.OptionsView.HighlightFocusedItem = true;
            this.dataLayoutControl1.OptionsView.RightToLeftMirroringApplied = true;
            this.dataLayoutControl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dataLayoutControl1.Size = new System.Drawing.Size(520, 340);
            // 
            // Root
            // 
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup1});
            this.Root.Size = new System.Drawing.Size(520, 340);
            // 
            // t_CitiesBindingSource
            // 
            this.t_CitiesBindingSource.DataSource = typeof(ProShared.Stock_Data.T_City);
            this.t_CitiesBindingSource.AddingNew += new System.ComponentModel.AddingNewEventHandler(this.t_CitiesBindingSource_AddingNew);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.AllowDrawBackground = false;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForCity_ID,
            this.ItemForCity_No,
            this.ItemForNameA,
            this.ItemForNameE,
            this.ItemForNote});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "autoGeneratedGroup0";
            this.layoutControlGroup1.Size = new System.Drawing.Size(500, 320);
            // 
            // ItemForCity_ID
            // 
            this.ItemForCity_ID.Control = this.City_IDTextEdit;
            this.ItemForCity_ID.Location = new System.Drawing.Point(0, 0);
            this.ItemForCity_ID.Name = "ItemForCity_ID";
            this.ItemForCity_ID.Size = new System.Drawing.Size(500, 24);
            this.ItemForCity_ID.Text = "City_ID";
            this.ItemForCity_ID.TextSize = new System.Drawing.Size(105, 13);
            this.ItemForCity_ID.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // City_IDTextEdit
            // 
            this.City_IDTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.t_CitiesBindingSource, "City_ID", true));
            this.City_IDTextEdit.Location = new System.Drawing.Point(12, 12);
            this.City_IDTextEdit.Name = "City_IDTextEdit";
            this.City_IDTextEdit.Size = new System.Drawing.Size(387, 20);
            this.City_IDTextEdit.StyleController = this.dataLayoutControl1;
            this.City_IDTextEdit.TabIndex = 4;
            // 
            // ItemForCity_No
            // 
            this.ItemForCity_No.Control = this.City_NoTextEdit;
            this.ItemForCity_No.Location = new System.Drawing.Point(0, 24);
            this.ItemForCity_No.Name = "ItemForCity_No";
            this.ItemForCity_No.Size = new System.Drawing.Size(500, 24);
            this.ItemForCity_No.Text = "رقم المدينه";
            this.ItemForCity_No.TextSize = new System.Drawing.Size(105, 13);
            // 
            // City_NoTextEdit
            // 
            this.City_NoTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.t_CitiesBindingSource, "City_No", true));
            this.City_NoTextEdit.Location = new System.Drawing.Point(12, 36);
            this.City_NoTextEdit.Name = "City_NoTextEdit";
            this.City_NoTextEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.City_NoTextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.City_NoTextEdit.Properties.AppearanceFocused.Options.UseTextOptions = true;
            this.City_NoTextEdit.Properties.AppearanceFocused.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.City_NoTextEdit.Properties.Mask.EditMask = "N0";
            this.City_NoTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.City_NoTextEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.City_NoTextEdit.Size = new System.Drawing.Size(387, 20);
            this.City_NoTextEdit.StyleController = this.dataLayoutControl1;
            this.City_NoTextEdit.TabIndex = 5;
            // 
            // ItemForNameA
            // 
            this.ItemForNameA.Control = this.NameATextEdit;
            this.ItemForNameA.Location = new System.Drawing.Point(0, 48);
            this.ItemForNameA.Name = "ItemForNameA";
            this.ItemForNameA.Size = new System.Drawing.Size(500, 24);
            this.ItemForNameA.Text = "اسم المدينه بالعربي";
            this.ItemForNameA.TextSize = new System.Drawing.Size(105, 13);
            // 
            // NameATextEdit
            // 
            this.NameATextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.t_CitiesBindingSource, "NameA", true));
            this.NameATextEdit.Location = new System.Drawing.Point(12, 60);
            this.NameATextEdit.Name = "NameATextEdit";
            this.NameATextEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.NameATextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.NameATextEdit.Properties.AppearanceFocused.Options.UseTextOptions = true;
            this.NameATextEdit.Properties.AppearanceFocused.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.NameATextEdit.Size = new System.Drawing.Size(387, 20);
            this.NameATextEdit.StyleController = this.dataLayoutControl1;
            this.NameATextEdit.TabIndex = 6;
            // 
            // ItemForNameE
            // 
            this.ItemForNameE.Control = this.NameETextEdit;
            this.ItemForNameE.Location = new System.Drawing.Point(0, 72);
            this.ItemForNameE.Name = "ItemForNameE";
            this.ItemForNameE.Size = new System.Drawing.Size(500, 24);
            this.ItemForNameE.Text = "اسم المدينه بالانجليزية";
            this.ItemForNameE.TextSize = new System.Drawing.Size(105, 13);
            // 
            // NameETextEdit
            // 
            this.NameETextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.t_CitiesBindingSource, "NameE", true));
            this.NameETextEdit.Location = new System.Drawing.Point(12, 84);
            this.NameETextEdit.Name = "NameETextEdit";
            this.NameETextEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.NameETextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.NameETextEdit.Properties.AppearanceFocused.Options.UseTextOptions = true;
            this.NameETextEdit.Properties.AppearanceFocused.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.NameETextEdit.Size = new System.Drawing.Size(387, 20);
            this.NameETextEdit.StyleController = this.dataLayoutControl1;
            this.NameETextEdit.TabIndex = 7;
            // 
            // ItemForNote
            // 
            this.ItemForNote.Control = this.NoteTextEdit;
            this.ItemForNote.Location = new System.Drawing.Point(0, 96);
            this.ItemForNote.Name = "ItemForNote";
            this.ItemForNote.Size = new System.Drawing.Size(500, 224);
            this.ItemForNote.Text = "ملاحظات";
            this.ItemForNote.TextSize = new System.Drawing.Size(105, 13);
            // 
            // NoteTextEdit
            // 
            this.NoteTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.t_CitiesBindingSource, "Note", true));
            this.NoteTextEdit.Location = new System.Drawing.Point(12, 108);
            this.NoteTextEdit.Name = "NoteTextEdit";
            this.NoteTextEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.NoteTextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.NoteTextEdit.Properties.AppearanceFocused.Options.UseTextOptions = true;
            this.NoteTextEdit.Properties.AppearanceFocused.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.NoteTextEdit.Size = new System.Drawing.Size(387, 220);
            this.NoteTextEdit.StyleController = this.dataLayoutControl1;
            this.NoteTextEdit.TabIndex = 8;
            // 
            // XFrmCity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 398);
            this.Name = "XFrmCity";
            this.Text = "المدن";
            this.Load += new System.EventHandler(this.XFrmCity_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t_CitiesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForCity_ID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.City_IDTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForCity_No)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.City_NoTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForNameA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NameATextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForNameE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NameETextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForNote)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NoteTextEdit.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource t_CitiesBindingSource;
        private DevExpress.XtraEditors.TextEdit City_IDTextEdit;
        private DevExpress.XtraEditors.TextEdit City_NoTextEdit;
        private DevExpress.XtraEditors.TextEdit NameATextEdit;
        private DevExpress.XtraEditors.TextEdit NameETextEdit;
        private DevExpress.XtraEditors.MemoEdit NoteTextEdit;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem ItemForCity_ID;
        private DevExpress.XtraLayout.LayoutControlItem ItemForCity_No;
        private DevExpress.XtraLayout.LayoutControlItem ItemForNameA;
        private DevExpress.XtraLayout.LayoutControlItem ItemForNameE;
        private DevExpress.XtraLayout.LayoutControlItem ItemForNote;
    }
}