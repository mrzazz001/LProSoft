namespace InvAcc.Forms.Eqr_Version.New
{
    partial class XFrmAinNatural
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
            this.t_AinNaturalsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForAinNatural_ID = new DevExpress.XtraLayout.LayoutControlItem();
            this.AinNatural_IDTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.ItemForAinNatural_No = new DevExpress.XtraLayout.LayoutControlItem();
            this.AinNatural_NoTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.ItemForNameA = new DevExpress.XtraLayout.LayoutControlItem();
            this.NameATextEdit = new DevExpress.XtraEditors.TextEdit();
            this.ItemForNameE = new DevExpress.XtraLayout.LayoutControlItem();
            this.NameETextEdit = new DevExpress.XtraEditors.TextEdit();
            this.ItemForNote = new DevExpress.XtraLayout.LayoutControlItem();
            this.NoteLookUpEdit = new DevExpress.XtraEditors.MemoEdit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t_AinNaturalsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForAinNatural_ID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AinNatural_IDTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForAinNatural_No)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AinNatural_NoTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForNameA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NameATextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForNameE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NameETextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForNote)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NoteLookUpEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // ubar1
            // 
            this.ubar1.BindingSource = this.t_AinNaturalsBindingSource;
            this.ubar1.Location = new System.Drawing.Point(0, 298);
            this.ubar1.Size = new System.Drawing.Size(485, 58);
            this.ubar1.Button_Save_Click += new InvAcc.Controls.Ubar.customMessageHandler(this.ubar1_Button_Save_Click);
            this.ubar1.Button_Delete_Click += new InvAcc.Controls.Ubar.customMessageHandler(this.ubar1_Button_Delete_Click);
            this.ubar1.Button_Close_Click += new InvAcc.Controls.Ubar.customMessageHandler(this.ubar1_Button_Close_Click);
            this.ubar1.Button_Search_Click += new InvAcc.Controls.Ubar.customMessageHandler(this.ubar1_Button_Search_Click);
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.Controls.Add(this.AinNatural_IDTextEdit);
            this.dataLayoutControl1.Controls.Add(this.AinNatural_NoTextEdit);
            this.dataLayoutControl1.Controls.Add(this.NameATextEdit);
            this.dataLayoutControl1.Controls.Add(this.NameETextEdit);
            this.dataLayoutControl1.Controls.Add(this.NoteLookUpEdit);
            this.dataLayoutControl1.DataSource = this.t_AinNaturalsBindingSource;
            this.dataLayoutControl1.OptionsView.RightToLeftMirroringApplied = true;
            this.dataLayoutControl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dataLayoutControl1.Size = new System.Drawing.Size(485, 298);
            // 
            // Root
            // 
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup1});
            this.Root.Size = new System.Drawing.Size(485, 298);
            // 
            // t_AinNaturalsBindingSource
            // 
            this.t_AinNaturalsBindingSource.DataSource = typeof(ProShared.Stock_Data.T_AinNatural);
            this.t_AinNaturalsBindingSource.AddingNew += new System.ComponentModel.AddingNewEventHandler(this.t_AinNaturalsBindingSource_AddingNew);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.AllowDrawBackground = false;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForAinNatural_ID,
            this.ItemForAinNatural_No,
            this.ItemForNameA,
            this.ItemForNameE,
            this.ItemForNote});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "autoGeneratedGroup0";
            this.layoutControlGroup1.Size = new System.Drawing.Size(465, 278);
            // 
            // ItemForAinNatural_ID
            // 
            this.ItemForAinNatural_ID.Control = this.AinNatural_IDTextEdit;
            this.ItemForAinNatural_ID.Location = new System.Drawing.Point(0, 0);
            this.ItemForAinNatural_ID.Name = "ItemForAinNatural_ID";
            this.ItemForAinNatural_ID.Size = new System.Drawing.Size(465, 24);
            this.ItemForAinNatural_ID.Text = "Ain Natural_ID";
            this.ItemForAinNatural_ID.TextSize = new System.Drawing.Size(75, 13);
            this.ItemForAinNatural_ID.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // AinNatural_IDTextEdit
            // 
            this.AinNatural_IDTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.t_AinNaturalsBindingSource, "AinNatural_ID", true));
            this.AinNatural_IDTextEdit.Location = new System.Drawing.Point(12, 12);
            this.AinNatural_IDTextEdit.Name = "AinNatural_IDTextEdit";
            this.AinNatural_IDTextEdit.Size = new System.Drawing.Size(382, 20);
            this.AinNatural_IDTextEdit.StyleController = this.dataLayoutControl1;
            this.AinNatural_IDTextEdit.TabIndex = 4;
            // 
            // ItemForAinNatural_No
            // 
            this.ItemForAinNatural_No.Control = this.AinNatural_NoTextEdit;
            this.ItemForAinNatural_No.HighlightFocusedItem = DevExpress.Utils.DefaultBoolean.True;
            this.ItemForAinNatural_No.Location = new System.Drawing.Point(0, 24);
            this.ItemForAinNatural_No.Name = "ItemForAinNatural_No";
            this.ItemForAinNatural_No.Size = new System.Drawing.Size(465, 24);
            this.ItemForAinNatural_No.Text = "الرقم";
            this.ItemForAinNatural_No.TextSize = new System.Drawing.Size(75, 13);
            // 
            // AinNatural_NoTextEdit
            // 
            this.AinNatural_NoTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.t_AinNaturalsBindingSource, "AinNatural_No", true));
            this.AinNatural_NoTextEdit.Location = new System.Drawing.Point(12, 36);
            this.AinNatural_NoTextEdit.Name = "AinNatural_NoTextEdit";
            this.AinNatural_NoTextEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.AinNatural_NoTextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.AinNatural_NoTextEdit.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.AinNatural_NoTextEdit.Properties.AppearanceFocused.Options.UseTextOptions = true;
            this.AinNatural_NoTextEdit.Properties.AppearanceFocused.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.AinNatural_NoTextEdit.Properties.AppearanceFocused.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.AinNatural_NoTextEdit.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.AinNatural_NoTextEdit.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.AinNatural_NoTextEdit.Properties.AppearanceReadOnly.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.AinNatural_NoTextEdit.Properties.Mask.EditMask = "N0";
            this.AinNatural_NoTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.AinNatural_NoTextEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.AinNatural_NoTextEdit.Size = new System.Drawing.Size(382, 20);
            this.AinNatural_NoTextEdit.StyleController = this.dataLayoutControl1;
            this.AinNatural_NoTextEdit.TabIndex = 5;
            // 
            // ItemForNameA
            // 
            this.ItemForNameA.Control = this.NameATextEdit;
            this.ItemForNameA.HighlightFocusedItem = DevExpress.Utils.DefaultBoolean.True;
            this.ItemForNameA.Location = new System.Drawing.Point(0, 48);
            this.ItemForNameA.Name = "ItemForNameA";
            this.ItemForNameA.Size = new System.Drawing.Size(465, 24);
            this.ItemForNameA.Text = "الاسم العربي";
            this.ItemForNameA.TextSize = new System.Drawing.Size(75, 13);
            // 
            // NameATextEdit
            // 
            this.NameATextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.t_AinNaturalsBindingSource, "NameA", true));
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
            this.NameATextEdit.Size = new System.Drawing.Size(382, 20);
            this.NameATextEdit.StyleController = this.dataLayoutControl1;
            this.NameATextEdit.TabIndex = 6;
            // 
            // ItemForNameE
            // 
            this.ItemForNameE.Control = this.NameETextEdit;
            this.ItemForNameE.HighlightFocusedItem = DevExpress.Utils.DefaultBoolean.True;
            this.ItemForNameE.Location = new System.Drawing.Point(0, 72);
            this.ItemForNameE.Name = "ItemForNameE";
            this.ItemForNameE.Size = new System.Drawing.Size(465, 24);
            this.ItemForNameE.Text = "الاسم الانجليزي";
            this.ItemForNameE.TextSize = new System.Drawing.Size(75, 13);
            // 
            // NameETextEdit
            // 
            this.NameETextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.t_AinNaturalsBindingSource, "NameE", true));
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
            this.NameETextEdit.Size = new System.Drawing.Size(382, 20);
            this.NameETextEdit.StyleController = this.dataLayoutControl1;
            this.NameETextEdit.TabIndex = 7;
            // 
            // ItemForNote
            // 
            this.ItemForNote.Control = this.NoteLookUpEdit;
            this.ItemForNote.HighlightFocusedItem = DevExpress.Utils.DefaultBoolean.True;
            this.ItemForNote.Location = new System.Drawing.Point(0, 96);
            this.ItemForNote.Name = "ItemForNote";
            this.ItemForNote.Size = new System.Drawing.Size(465, 182);
            this.ItemForNote.Text = "الملاحظات";
            this.ItemForNote.TextSize = new System.Drawing.Size(75, 13);
            // 
            // NoteLookUpEdit
            // 
            this.NoteLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.t_AinNaturalsBindingSource, "Note", true));
            this.NoteLookUpEdit.Location = new System.Drawing.Point(12, 108);
            this.NoteLookUpEdit.Name = "NoteLookUpEdit";
            this.NoteLookUpEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.NoteLookUpEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.NoteLookUpEdit.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.NoteLookUpEdit.Size = new System.Drawing.Size(382, 178);
            this.NoteLookUpEdit.StyleController = this.dataLayoutControl1;
            this.NoteLookUpEdit.TabIndex = 8;
            this.NoteLookUpEdit.EditValueChanged += new System.EventHandler(this.NoteLookUpEdit_EditValueChanged);
            // 
            // XFrmAinNatural
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 356);
            this.Name = "XFrmAinNatural";
            this.Text = "طبيعة العين";
            this.Load += new System.EventHandler(this.XFrmAinNatural_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t_AinNaturalsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForAinNatural_ID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AinNatural_IDTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForAinNatural_No)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AinNatural_NoTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForNameA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NameATextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForNameE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NameETextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForNote)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NoteLookUpEdit.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource t_AinNaturalsBindingSource;
        private DevExpress.XtraEditors.TextEdit AinNatural_IDTextEdit;
        private DevExpress.XtraEditors.TextEdit AinNatural_NoTextEdit;
        private DevExpress.XtraEditors.TextEdit NameATextEdit;
        private DevExpress.XtraEditors.TextEdit NameETextEdit;
        private DevExpress.XtraEditors.MemoEdit NoteLookUpEdit;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem ItemForAinNatural_ID;
        private DevExpress.XtraLayout.LayoutControlItem ItemForAinNatural_No;
        private DevExpress.XtraLayout.LayoutControlItem ItemForNameA;
        private DevExpress.XtraLayout.LayoutControlItem ItemForNameE;
        private DevExpress.XtraLayout.LayoutControlItem ItemForNote;
    }
}