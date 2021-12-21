namespace InvAcc.Forms.Eqr_Version.New
{
    partial class XFrmNation
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
            this.t_NationalitiesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForNation_ID = new DevExpress.XtraLayout.LayoutControlItem();
            this.Nation_IDTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.ItemForNation_No = new DevExpress.XtraLayout.LayoutControlItem();
            this.Nation_NoTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.ItemForNameA = new DevExpress.XtraLayout.LayoutControlItem();
            this.NameATextEdit = new DevExpress.XtraEditors.TextEdit();
            this.ItemForNameE = new DevExpress.XtraLayout.LayoutControlItem();
            this.NameETextEdit = new DevExpress.XtraEditors.TextEdit();
            this.ItemForSalSubtract = new DevExpress.XtraLayout.LayoutControlItem();
            this.SalSubtractTextEdit = new DevExpress.XtraEditors.SpinEdit();
            this.ItemForNote = new DevExpress.XtraLayout.LayoutControlItem();
            this.NoteTextEdit = new DevExpress.XtraEditors.MemoEdit();
            this.ItemForCompPaying = new DevExpress.XtraLayout.LayoutControlItem();
            this.CompPayingTextEdit = new DevExpress.XtraEditors.SpinEdit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t_NationalitiesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForNation_ID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Nation_IDTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForNation_No)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Nation_NoTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForNameA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NameATextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForNameE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NameETextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForSalSubtract)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalSubtractTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForNote)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NoteTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForCompPaying)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CompPayingTextEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // ubar1
            // 
            this.ubar1.BindingSource = this.t_NationalitiesBindingSource;
            this.ubar1.Location = new System.Drawing.Point(0, 303);
            this.ubar1.Size = new System.Drawing.Size(416, 58);
            this.ubar1.Button_Search_Click += new InvAcc.Controls.Ubar.customMessageHandler(this.ubar1_Button_Search_Click);
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.Controls.Add(this.Nation_IDTextEdit);
            this.dataLayoutControl1.Controls.Add(this.Nation_NoTextEdit);
            this.dataLayoutControl1.Controls.Add(this.NameATextEdit);
            this.dataLayoutControl1.Controls.Add(this.NameETextEdit);
            this.dataLayoutControl1.Controls.Add(this.NoteTextEdit);
            this.dataLayoutControl1.Controls.Add(this.SalSubtractTextEdit);
            this.dataLayoutControl1.Controls.Add(this.CompPayingTextEdit);
            this.dataLayoutControl1.DataSource = this.t_NationalitiesBindingSource;
            this.dataLayoutControl1.OptionsView.HighlightFocusedItem = true;
            this.dataLayoutControl1.OptionsView.RightToLeftMirroringApplied = true;
            this.dataLayoutControl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dataLayoutControl1.Size = new System.Drawing.Size(416, 303);
            // 
            // Root
            // 
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup1});
            this.Root.Size = new System.Drawing.Size(416, 303);
            // 
            // t_NationalitiesBindingSource
            // 
            this.t_NationalitiesBindingSource.DataSource = typeof(ProShared.Stock_Data.T_Nationality);
            this.t_NationalitiesBindingSource.AddingNew += new System.ComponentModel.AddingNewEventHandler(this.t_NationalitiesBindingSource_AddingNew);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.AllowDrawBackground = false;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForNation_ID,
            this.ItemForNation_No,
            this.ItemForNameA,
            this.ItemForNameE,
            this.ItemForSalSubtract,
            this.ItemForNote,
            this.ItemForCompPaying});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "autoGeneratedGroup0";
            this.layoutControlGroup1.Size = new System.Drawing.Size(396, 283);
            // 
            // ItemForNation_ID
            // 
            this.ItemForNation_ID.Control = this.Nation_IDTextEdit;
            this.ItemForNation_ID.Location = new System.Drawing.Point(0, 0);
            this.ItemForNation_ID.Name = "ItemForNation_ID";
            this.ItemForNation_ID.Size = new System.Drawing.Size(396, 24);
            this.ItemForNation_ID.Text = "Nation_ID";
            this.ItemForNation_ID.TextSize = new System.Drawing.Size(93, 13);
            this.ItemForNation_ID.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // Nation_IDTextEdit
            // 
            this.Nation_IDTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.t_NationalitiesBindingSource, "Nation_ID", true));
            this.Nation_IDTextEdit.Location = new System.Drawing.Point(12, 12);
            this.Nation_IDTextEdit.Name = "Nation_IDTextEdit";
            this.Nation_IDTextEdit.Size = new System.Drawing.Size(295, 20);
            this.Nation_IDTextEdit.StyleController = this.dataLayoutControl1;
            this.Nation_IDTextEdit.TabIndex = 4;
            // 
            // ItemForNation_No
            // 
            this.ItemForNation_No.Control = this.Nation_NoTextEdit;
            this.ItemForNation_No.Location = new System.Drawing.Point(0, 24);
            this.ItemForNation_No.Name = "ItemForNation_No";
            this.ItemForNation_No.Size = new System.Drawing.Size(396, 24);
            this.ItemForNation_No.Text = "رقم الجنسية";
            this.ItemForNation_No.TextSize = new System.Drawing.Size(93, 13);
            // 
            // Nation_NoTextEdit
            // 
            this.Nation_NoTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.t_NationalitiesBindingSource, "Nation_No", true));
            this.Nation_NoTextEdit.Location = new System.Drawing.Point(12, 36);
            this.Nation_NoTextEdit.Name = "Nation_NoTextEdit";
            this.Nation_NoTextEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.Nation_NoTextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Nation_NoTextEdit.Properties.AppearanceFocused.Options.UseTextOptions = true;
            this.Nation_NoTextEdit.Properties.AppearanceFocused.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Nation_NoTextEdit.Properties.Mask.EditMask = "N0";
            this.Nation_NoTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.Nation_NoTextEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.Nation_NoTextEdit.Size = new System.Drawing.Size(295, 20);
            this.Nation_NoTextEdit.StyleController = this.dataLayoutControl1;
            this.Nation_NoTextEdit.TabIndex = 5;
            this.Nation_NoTextEdit.EditValueChanged += new System.EventHandler(this.Nation_NoTextEdit_EditValueChanged);
            // 
            // ItemForNameA
            // 
            this.ItemForNameA.Control = this.NameATextEdit;
            this.ItemForNameA.Location = new System.Drawing.Point(0, 48);
            this.ItemForNameA.Name = "ItemForNameA";
            this.ItemForNameA.Size = new System.Drawing.Size(396, 24);
            this.ItemForNameA.Text = "الاسم العربي";
            this.ItemForNameA.TextSize = new System.Drawing.Size(93, 13);
            // 
            // NameATextEdit
            // 
            this.NameATextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.t_NationalitiesBindingSource, "NameA", true));
            this.NameATextEdit.Location = new System.Drawing.Point(12, 60);
            this.NameATextEdit.Name = "NameATextEdit";
            this.NameATextEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.NameATextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.NameATextEdit.Properties.AppearanceFocused.Options.UseTextOptions = true;
            this.NameATextEdit.Properties.AppearanceFocused.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.NameATextEdit.Size = new System.Drawing.Size(295, 20);
            this.NameATextEdit.StyleController = this.dataLayoutControl1;
            this.NameATextEdit.TabIndex = 6;
            // 
            // ItemForNameE
            // 
            this.ItemForNameE.Control = this.NameETextEdit;
            this.ItemForNameE.Location = new System.Drawing.Point(0, 72);
            this.ItemForNameE.Name = "ItemForNameE";
            this.ItemForNameE.Size = new System.Drawing.Size(396, 24);
            this.ItemForNameE.Text = "الاسم الانجليزي";
            this.ItemForNameE.TextSize = new System.Drawing.Size(93, 13);
            // 
            // NameETextEdit
            // 
            this.NameETextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.t_NationalitiesBindingSource, "NameE", true));
            this.NameETextEdit.Location = new System.Drawing.Point(12, 84);
            this.NameETextEdit.Name = "NameETextEdit";
            this.NameETextEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.NameETextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.NameETextEdit.Properties.AppearanceFocused.Options.UseTextOptions = true;
            this.NameETextEdit.Properties.AppearanceFocused.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.NameETextEdit.Size = new System.Drawing.Size(295, 20);
            this.NameETextEdit.StyleController = this.dataLayoutControl1;
            this.NameETextEdit.TabIndex = 7;
            // 
            // ItemForSalSubtract
            // 
            this.ItemForSalSubtract.Control = this.SalSubtractTextEdit;
            this.ItemForSalSubtract.Location = new System.Drawing.Point(198, 96);
            this.ItemForSalSubtract.Name = "ItemForSalSubtract";
            this.ItemForSalSubtract.Size = new System.Drawing.Size(198, 24);
            this.ItemForSalSubtract.Text = "يخصم من الراتب";
            this.ItemForSalSubtract.TextSize = new System.Drawing.Size(93, 13);
            // 
            // SalSubtractTextEdit
            // 
            this.SalSubtractTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.t_NationalitiesBindingSource, "SalSubtract", true));
            this.SalSubtractTextEdit.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.SalSubtractTextEdit.Location = new System.Drawing.Point(210, 108);
            this.SalSubtractTextEdit.Name = "SalSubtractTextEdit";
            this.SalSubtractTextEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.SalSubtractTextEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.SalSubtractTextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.SalSubtractTextEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.SalSubtractTextEdit.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            this.SalSubtractTextEdit.Properties.Mask.EditMask = "F";
            this.SalSubtractTextEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.SalSubtractTextEdit.Size = new System.Drawing.Size(97, 20);
            this.SalSubtractTextEdit.StyleController = this.dataLayoutControl1;
            this.SalSubtractTextEdit.TabIndex = 9;
            // 
            // ItemForNote
            // 
            this.ItemForNote.Control = this.NoteTextEdit;
            this.ItemForNote.Location = new System.Drawing.Point(0, 120);
            this.ItemForNote.Name = "ItemForNote";
            this.ItemForNote.OptionsPrint.AppearanceItem.Options.UseTextOptions = true;
            this.ItemForNote.OptionsPrint.AppearanceItem.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.ItemForNote.Size = new System.Drawing.Size(396, 163);
            this.ItemForNote.Text = "ملاحظات";
            this.ItemForNote.TextSize = new System.Drawing.Size(93, 13);
            // 
            // NoteTextEdit
            // 
            this.NoteTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.t_NationalitiesBindingSource, "Note", true));
            this.NoteTextEdit.Location = new System.Drawing.Point(12, 132);
            this.NoteTextEdit.Name = "NoteTextEdit";
            this.NoteTextEdit.Size = new System.Drawing.Size(295, 159);
            this.NoteTextEdit.StyleController = this.dataLayoutControl1;
            this.NoteTextEdit.TabIndex = 8;
            // 
            // ItemForCompPaying
            // 
            this.ItemForCompPaying.Control = this.CompPayingTextEdit;
            this.ItemForCompPaying.Location = new System.Drawing.Point(0, 96);
            this.ItemForCompPaying.Name = "ItemForCompPaying";
            this.ItemForCompPaying.Size = new System.Drawing.Size(198, 24);
            this.ItemForCompPaying.Text = "مستحق من الشركه";
            this.ItemForCompPaying.TextSize = new System.Drawing.Size(93, 13);
            // 
            // CompPayingTextEdit
            // 
            this.CompPayingTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.t_NationalitiesBindingSource, "CompPaying", true));
            this.CompPayingTextEdit.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.CompPayingTextEdit.Location = new System.Drawing.Point(12, 108);
            this.CompPayingTextEdit.Name = "CompPayingTextEdit";
            this.CompPayingTextEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.CompPayingTextEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.CompPayingTextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.CompPayingTextEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.CompPayingTextEdit.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            this.CompPayingTextEdit.Properties.Mask.EditMask = "F";
            this.CompPayingTextEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.CompPayingTextEdit.Size = new System.Drawing.Size(97, 20);
            this.CompPayingTextEdit.StyleController = this.dataLayoutControl1;
            this.CompPayingTextEdit.TabIndex = 10;
            // 
            // XFrmNation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 361);
            this.Name = "XFrmNation";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "الجنسيات";
            this.Load += new System.EventHandler(this.XFrmNation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t_NationalitiesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForNation_ID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Nation_IDTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForNation_No)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Nation_NoTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForNameA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NameATextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForNameE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NameETextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForSalSubtract)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalSubtractTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForNote)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NoteTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForCompPaying)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CompPayingTextEdit.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource t_NationalitiesBindingSource;
        private DevExpress.XtraEditors.TextEdit Nation_IDTextEdit;
        private DevExpress.XtraEditors.TextEdit Nation_NoTextEdit;
        private DevExpress.XtraEditors.TextEdit NameATextEdit;
        private DevExpress.XtraEditors.TextEdit NameETextEdit;
        private DevExpress.XtraEditors.MemoEdit NoteTextEdit;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem ItemForNation_ID;
        private DevExpress.XtraLayout.LayoutControlItem ItemForNation_No;
        private DevExpress.XtraLayout.LayoutControlItem ItemForNameA;
        private DevExpress.XtraLayout.LayoutControlItem ItemForNameE;
        private DevExpress.XtraLayout.LayoutControlItem ItemForSalSubtract;
        private DevExpress.XtraLayout.LayoutControlItem ItemForNote;
        private DevExpress.XtraLayout.LayoutControlItem ItemForCompPaying;
        private DevExpress.XtraEditors.SpinEdit SalSubtractTextEdit;
        private DevExpress.XtraEditors.SpinEdit CompPayingTextEdit;
    }
}