namespace InvAcc.Forms.Eqr_Version.New
{
    partial class XFrmAinTyp
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
            this.t_AinTypsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForAinTyp_ID = new DevExpress.XtraLayout.LayoutControlItem();
            this.AinTyp_IDTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.ItemForAinTyp_No = new DevExpress.XtraLayout.LayoutControlItem();
            this.AinTyp_NoTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.ItemForNameA = new DevExpress.XtraLayout.LayoutControlItem();
            this.NameATextEdit = new DevExpress.XtraEditors.TextEdit();
            this.ItemForNameE = new DevExpress.XtraLayout.LayoutControlItem();
            this.NameETextEdit = new DevExpress.XtraEditors.TextEdit();
            this.ItemForNote = new DevExpress.XtraLayout.LayoutControlItem();
            this.NoteMemoEdit = new DevExpress.XtraEditors.MemoEdit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t_AinTypsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForAinTyp_ID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AinTyp_IDTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForAinTyp_No)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AinTyp_NoTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForNameA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NameATextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForNameE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NameETextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForNote)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NoteMemoEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // ubar1
            // 
            this.ubar1.BindingSource = this.t_AinTypsBindingSource;
            this.ubar1.Location = new System.Drawing.Point(0, 269);
            this.ubar1.Size = new System.Drawing.Size(445, 58);
            this.ubar1.Button_Add_Click += new InvAcc.Controls.Ubar.customMessageHandler(this.Button_Add_Click);
            this.ubar1.Button_Save_Click += new InvAcc.Controls.Ubar.customMessageHandler(this.Button_Save_Click);
            this.ubar1.Button_Search_Click += new InvAcc.Controls.Ubar.customMessageHandler(this.Button_Search_Click);
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.Controls.Add(this.AinTyp_IDTextEdit);
            this.dataLayoutControl1.Controls.Add(this.AinTyp_NoTextEdit);
            this.dataLayoutControl1.Controls.Add(this.NameATextEdit);
            this.dataLayoutControl1.Controls.Add(this.NameETextEdit);
            this.dataLayoutControl1.Controls.Add(this.NoteMemoEdit);
            this.dataLayoutControl1.DataSource = this.t_AinTypsBindingSource;
            this.dataLayoutControl1.OptionsView.RightToLeftMirroringApplied = true;
            this.dataLayoutControl1.Size = new System.Drawing.Size(445, 269);
            // 
            // Root
            // 
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup1});
            this.Root.Size = new System.Drawing.Size(445, 269);
            // 
            // t_AinTypsBindingSource
            // 
            this.t_AinTypsBindingSource.DataSource = typeof(ProShared.Stock_Data.T_AinTyp);
            this.t_AinTypsBindingSource.AddingNew += new System.ComponentModel.AddingNewEventHandler(this.t_AinTypsBindingSource_AddingNew);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.AllowDrawBackground = false;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForAinTyp_ID,
            this.ItemForAinTyp_No,
            this.ItemForNameA,
            this.ItemForNameE,
            this.ItemForNote});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "autoGeneratedGroup0";
            this.layoutControlGroup1.Size = new System.Drawing.Size(425, 249);
            this.layoutControlGroup1.TextChanged += new System.EventHandler(this.layoutControlGroup1_TextChanged);
            // 
            // ItemForAinTyp_ID
            // 
            this.ItemForAinTyp_ID.Control = this.AinTyp_IDTextEdit;
            this.ItemForAinTyp_ID.HighlightFocusedItem = DevExpress.Utils.DefaultBoolean.True;
            this.ItemForAinTyp_ID.Location = new System.Drawing.Point(0, 0);
            this.ItemForAinTyp_ID.Name = "ItemForAinTyp_ID";
            this.ItemForAinTyp_ID.Size = new System.Drawing.Size(425, 24);
            this.ItemForAinTyp_ID.Text = "الرقم المعرف";
            this.ItemForAinTyp_ID.TextSize = new System.Drawing.Size(75, 13);
            this.ItemForAinTyp_ID.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // AinTyp_IDTextEdit
            // 
            this.AinTyp_IDTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.t_AinTypsBindingSource, "AinTyp_ID", true));
            this.AinTyp_IDTextEdit.Location = new System.Drawing.Point(12, 12);
            this.AinTyp_IDTextEdit.Name = "AinTyp_IDTextEdit";
            this.AinTyp_IDTextEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.AinTyp_IDTextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.AinTyp_IDTextEdit.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.AinTyp_IDTextEdit.Properties.AppearanceFocused.Options.UseTextOptions = true;
            this.AinTyp_IDTextEdit.Properties.AppearanceFocused.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.AinTyp_IDTextEdit.Properties.AppearanceFocused.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.AinTyp_IDTextEdit.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.AinTyp_IDTextEdit.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.AinTyp_IDTextEdit.Properties.AppearanceReadOnly.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.AinTyp_IDTextEdit.Size = new System.Drawing.Size(342, 20);
            this.AinTyp_IDTextEdit.StyleController = this.dataLayoutControl1;
            this.AinTyp_IDTextEdit.TabIndex = 4;
            // 
            // ItemForAinTyp_No
            // 
            this.ItemForAinTyp_No.Control = this.AinTyp_NoTextEdit;
            this.ItemForAinTyp_No.HighlightFocusedItem = DevExpress.Utils.DefaultBoolean.True;
            this.ItemForAinTyp_No.Location = new System.Drawing.Point(0, 24);
            this.ItemForAinTyp_No.Name = "ItemForAinTyp_No";
            this.ItemForAinTyp_No.Size = new System.Drawing.Size(425, 24);
            this.ItemForAinTyp_No.Text = "رقم العين";
            this.ItemForAinTyp_No.TextSize = new System.Drawing.Size(75, 13);
            // 
            // AinTyp_NoTextEdit
            // 
            this.AinTyp_NoTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.t_AinTypsBindingSource, "AinTyp_No", true));
            this.AinTyp_NoTextEdit.Location = new System.Drawing.Point(12, 36);
            this.AinTyp_NoTextEdit.Name = "AinTyp_NoTextEdit";
            this.AinTyp_NoTextEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.AinTyp_NoTextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.AinTyp_NoTextEdit.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.AinTyp_NoTextEdit.Properties.AppearanceFocused.Options.UseTextOptions = true;
            this.AinTyp_NoTextEdit.Properties.AppearanceFocused.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.AinTyp_NoTextEdit.Properties.AppearanceFocused.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.AinTyp_NoTextEdit.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.AinTyp_NoTextEdit.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.AinTyp_NoTextEdit.Properties.AppearanceReadOnly.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.AinTyp_NoTextEdit.Properties.Mask.EditMask = "N0";
            this.AinTyp_NoTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.AinTyp_NoTextEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.AinTyp_NoTextEdit.Size = new System.Drawing.Size(342, 20);
            this.AinTyp_NoTextEdit.StyleController = this.dataLayoutControl1;
            this.AinTyp_NoTextEdit.TabIndex = 5;
            // 
            // ItemForNameA
            // 
            this.ItemForNameA.Control = this.NameATextEdit;
            this.ItemForNameA.HighlightFocusedItem = DevExpress.Utils.DefaultBoolean.True;
            this.ItemForNameA.Location = new System.Drawing.Point(0, 48);
            this.ItemForNameA.Name = "ItemForNameA";
            this.ItemForNameA.Size = new System.Drawing.Size(425, 24);
            this.ItemForNameA.Text = "الاسم العربي";
            this.ItemForNameA.TextSize = new System.Drawing.Size(75, 13);
            // 
            // NameATextEdit
            // 
            this.NameATextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.t_AinTypsBindingSource, "NameA", true));
            this.NameATextEdit.Location = new System.Drawing.Point(12, 60);
            this.NameATextEdit.Name = "NameATextEdit";
            this.NameATextEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.NameATextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.NameATextEdit.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.NameATextEdit.Properties.AppearanceFocused.Options.UseTextOptions = true;
            this.NameATextEdit.Properties.AppearanceFocused.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.NameATextEdit.Properties.AppearanceFocused.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.NameATextEdit.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.NameATextEdit.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.NameATextEdit.Properties.AppearanceReadOnly.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.NameATextEdit.Size = new System.Drawing.Size(342, 20);
            this.NameATextEdit.StyleController = this.dataLayoutControl1;
            this.NameATextEdit.TabIndex = 6;
            // 
            // ItemForNameE
            // 
            this.ItemForNameE.Control = this.NameETextEdit;
            this.ItemForNameE.HighlightFocusedItem = DevExpress.Utils.DefaultBoolean.True;
            this.ItemForNameE.Location = new System.Drawing.Point(0, 72);
            this.ItemForNameE.Name = "ItemForNameE";
            this.ItemForNameE.Size = new System.Drawing.Size(425, 24);
            this.ItemForNameE.Text = "الاسم الانجليزي";
            this.ItemForNameE.TextSize = new System.Drawing.Size(75, 13);
            // 
            // NameETextEdit
            // 
            this.NameETextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.t_AinTypsBindingSource, "NameE", true));
            this.NameETextEdit.Location = new System.Drawing.Point(12, 84);
            this.NameETextEdit.Name = "NameETextEdit";
            this.NameETextEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.NameETextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.NameETextEdit.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.NameETextEdit.Properties.AppearanceFocused.Options.UseTextOptions = true;
            this.NameETextEdit.Properties.AppearanceFocused.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.NameETextEdit.Properties.AppearanceFocused.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.NameETextEdit.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.NameETextEdit.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.NameETextEdit.Properties.AppearanceReadOnly.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.NameETextEdit.Size = new System.Drawing.Size(342, 20);
            this.NameETextEdit.StyleController = this.dataLayoutControl1;
            this.NameETextEdit.TabIndex = 7;
            // 
            // ItemForNote
            // 
            this.ItemForNote.Control = this.NoteMemoEdit;
            this.ItemForNote.HighlightFocusedItem = DevExpress.Utils.DefaultBoolean.True;
            this.ItemForNote.Location = new System.Drawing.Point(0, 96);
            this.ItemForNote.Name = "ItemForNote";
            this.ItemForNote.Size = new System.Drawing.Size(425, 153);
            this.ItemForNote.StartNewLine = true;
            this.ItemForNote.Text = "ملاحظات";
            this.ItemForNote.TextSize = new System.Drawing.Size(75, 13);
            // 
            // NoteMemoEdit
            // 
            this.NoteMemoEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.t_AinTypsBindingSource, "Note", true));
            this.NoteMemoEdit.Location = new System.Drawing.Point(12, 108);
            this.NoteMemoEdit.Name = "NoteMemoEdit";
            this.NoteMemoEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.NoteMemoEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.NoteMemoEdit.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.NoteMemoEdit.Properties.AppearanceDisabled.Options.UseTextOptions = true;
            this.NoteMemoEdit.Properties.AppearanceDisabled.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.NoteMemoEdit.Properties.AppearanceDisabled.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.NoteMemoEdit.Properties.AppearanceFocused.Options.UseTextOptions = true;
            this.NoteMemoEdit.Properties.AppearanceFocused.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.NoteMemoEdit.Properties.AppearanceFocused.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.NoteMemoEdit.Size = new System.Drawing.Size(342, 149);
            this.NoteMemoEdit.StyleController = this.dataLayoutControl1;
            this.NoteMemoEdit.TabIndex = 8;
            // 
            // XFrmAinTyp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 327);
            this.Name = "XFrmAinTyp";
            this.Text = "نوع العين";
            this.Load += new System.EventHandler(this.XtraForm1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t_AinTypsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForAinTyp_ID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AinTyp_IDTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForAinTyp_No)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AinTyp_NoTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForNameA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NameATextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForNameE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NameETextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForNote)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NoteMemoEdit.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource t_AinTypsBindingSource;
        private DevExpress.XtraEditors.TextEdit AinTyp_IDTextEdit;
        private DevExpress.XtraEditors.TextEdit AinTyp_NoTextEdit;
        private DevExpress.XtraEditors.TextEdit NameATextEdit;
        private DevExpress.XtraEditors.TextEdit NameETextEdit;
        private DevExpress.XtraEditors.MemoEdit NoteMemoEdit;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem ItemForAinTyp_ID;
        private DevExpress.XtraLayout.LayoutControlItem ItemForAinTyp_No;
        private DevExpress.XtraLayout.LayoutControlItem ItemForNameA;
        private DevExpress.XtraLayout.LayoutControlItem ItemForNameE;
        private DevExpress.XtraLayout.LayoutControlItem ItemForNote;
    }
}