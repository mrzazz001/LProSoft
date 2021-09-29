namespace InvAcc.Forms.Eqr_Version.New
{
    partial class XtraForm2
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
        ///
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.AinTyp_NoTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.t_AinTypsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.NameATextEdit = new DevExpress.XtraEditors.TextEdit();
            this.NameETextEdit = new DevExpress.XtraEditors.TextEdit();
            this.NoteTextEdit = new DevExpress.XtraEditors.MemoEdit();
            this.AinTyp_IDTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForAinTyp_No = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForNameA = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForNameE = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForNote = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForAinTyp_ID = new DevExpress.XtraLayout.LayoutControlItem();
            this.labelControl = new DevExpress.XtraEditors.LabelControl();
            this.ubar1 = new InvAcc.Controls.Ubar();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AinTyp_NoTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t_AinTypsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NameATextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NameETextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NoteTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AinTyp_IDTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForAinTyp_No)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForNameA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForNameE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForNote)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForAinTyp_ID)).BeginInit();
            this.SuspendLayout();
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.AllowCustomization = false;
            this.dataLayoutControl1.Controls.Add(this.AinTyp_NoTextEdit);
            this.dataLayoutControl1.Controls.Add(this.NameATextEdit);
            this.dataLayoutControl1.Controls.Add(this.NameETextEdit);
            this.dataLayoutControl1.Controls.Add(this.NoteTextEdit);
            this.dataLayoutControl1.Controls.Add(this.AinTyp_IDTextEdit);
            this.dataLayoutControl1.DataSource = this.t_AinTypsBindingSource;
            this.dataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLayoutControl1.Location = new System.Drawing.Point(0, 30);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(716, 239, 650, 400);
            this.dataLayoutControl1.OptionsView.RightToLeftMirroringApplied = true;
            this.dataLayoutControl1.Root = this.layoutControlGroup1;
            this.dataLayoutControl1.Size = new System.Drawing.Size(784, 309);
            this.dataLayoutControl1.TabIndex = 0;
            // 
            // AinTyp_NoTextEdit
            // 
            this.AinTyp_NoTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.t_AinTypsBindingSource, "AinTyp_No", true));
            this.AinTyp_NoTextEdit.Location = new System.Drawing.Point(12, 84);
            this.AinTyp_NoTextEdit.Name = "AinTyp_NoTextEdit";
            this.AinTyp_NoTextEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.AinTyp_NoTextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.AinTyp_NoTextEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.AinTyp_NoTextEdit.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            this.AinTyp_NoTextEdit.Properties.MaskSettings.Set("mask", "N0");
            this.AinTyp_NoTextEdit.Properties.ReadOnly = true;
            this.AinTyp_NoTextEdit.Size = new System.Drawing.Size(681, 20);
            this.AinTyp_NoTextEdit.StyleController = this.dataLayoutControl1;
            this.AinTyp_NoTextEdit.TabIndex = 5;
            // 
            // t_AinTypsBindingSource
            // 
            this.t_AinTypsBindingSource.DataSource = typeof(InvAcc.Stock_Data.T_AinTyp);
            this.t_AinTypsBindingSource.AddingNew += new System.ComponentModel.AddingNewEventHandler(this.t_AinTypsBindingSource_AddingNew);
            this.t_AinTypsBindingSource.BindingComplete += new System.Windows.Forms.BindingCompleteEventHandler(this.t_AinTypsBindingSource_BindingComplete);
            this.t_AinTypsBindingSource.CurrentChanged += new System.EventHandler(this.t_AinTypsBindingSource_CurrentChanged);
            // 
            // NameATextEdit
            // 
            this.NameATextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.t_AinTypsBindingSource, "NameA", true));
            this.NameATextEdit.Location = new System.Drawing.Point(12, 108);
            this.NameATextEdit.Name = "NameATextEdit";
            this.NameATextEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.NameATextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.NameATextEdit.Size = new System.Drawing.Size(681, 20);
            this.NameATextEdit.StyleController = this.dataLayoutControl1;
            this.NameATextEdit.TabIndex = 6;
            // 
            // NameETextEdit
            // 
            this.NameETextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.t_AinTypsBindingSource, "NameE", true));
            this.NameETextEdit.Location = new System.Drawing.Point(12, 132);
            this.NameETextEdit.Name = "NameETextEdit";
            this.NameETextEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.NameETextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.NameETextEdit.Size = new System.Drawing.Size(681, 20);
            this.NameETextEdit.StyleController = this.dataLayoutControl1;
            this.NameETextEdit.TabIndex = 7;
            // 
            // NoteTextEdit
            // 
            this.NoteTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.t_AinTypsBindingSource, "Note", true));
            this.NoteTextEdit.Location = new System.Drawing.Point(12, 156);
            this.NoteTextEdit.Name = "NoteTextEdit";
            this.NoteTextEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.NoteTextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.NoteTextEdit.Size = new System.Drawing.Size(681, 141);
            this.NoteTextEdit.StyleController = this.dataLayoutControl1;
            this.NoteTextEdit.TabIndex = 8;
            this.NoteTextEdit.EditValueChanged += new System.EventHandler(this.NoteTextEdit_EditValueChanged);
            // 
            // AinTyp_IDTextEdit
            // 
            this.AinTyp_IDTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.t_AinTypsBindingSource, "AinTyp_ID", true));
            this.AinTyp_IDTextEdit.Location = new System.Drawing.Point(12, 60);
            this.AinTyp_IDTextEdit.Name = "AinTyp_IDTextEdit";
            this.AinTyp_IDTextEdit.Size = new System.Drawing.Size(681, 20);
            this.AinTyp_IDTextEdit.StyleController = this.dataLayoutControl1;
            this.AinTyp_IDTextEdit.TabIndex = 9;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup2,
            this.ItemForAinTyp_ID,
            this.ItemForAinTyp_No,
            this.ItemForNameA,
            this.ItemForNameE,
            this.ItemForNote});
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(784, 309);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.AllowDrawBackground = false;
            this.layoutControlGroup2.GroupBordersVisible = false;
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "autoGeneratedGroup0";
            this.layoutControlGroup2.Size = new System.Drawing.Size(764, 48);
            // 
            // ItemForAinTyp_No
            // 
            this.ItemForAinTyp_No.Control = this.AinTyp_NoTextEdit;
            this.ItemForAinTyp_No.Location = new System.Drawing.Point(0, 72);
            this.ItemForAinTyp_No.Name = "ItemForAinTyp_No";
            this.ItemForAinTyp_No.Size = new System.Drawing.Size(764, 24);
            this.ItemForAinTyp_No.Text = "رقم العين";
            this.ItemForAinTyp_No.TextSize = new System.Drawing.Size(75, 13);
            // 
            // ItemForNameA
            // 
            this.ItemForNameA.Control = this.NameATextEdit;
            this.ItemForNameA.Location = new System.Drawing.Point(0, 96);
            this.ItemForNameA.Name = "ItemForNameA";
            this.ItemForNameA.Size = new System.Drawing.Size(764, 24);
            this.ItemForNameA.Text = "الاسم العربي";
            this.ItemForNameA.TextSize = new System.Drawing.Size(75, 13);
            // 
            // ItemForNameE
            // 
            this.ItemForNameE.Control = this.NameETextEdit;
            this.ItemForNameE.Location = new System.Drawing.Point(0, 120);
            this.ItemForNameE.Name = "ItemForNameE";
            this.ItemForNameE.Size = new System.Drawing.Size(764, 24);
            this.ItemForNameE.Text = "الاسم الانجليزي";
            this.ItemForNameE.TextSize = new System.Drawing.Size(75, 13);
            // 
            // ItemForNote
            // 
            this.ItemForNote.Control = this.NoteTextEdit;
            this.ItemForNote.Location = new System.Drawing.Point(0, 144);
            this.ItemForNote.Name = "ItemForNote";
            this.ItemForNote.Size = new System.Drawing.Size(764, 145);
            this.ItemForNote.Text = "ملاحظات";
            this.ItemForNote.TextSize = new System.Drawing.Size(75, 13);
            // 
            // ItemForAinTyp_ID
            // 
            this.ItemForAinTyp_ID.Control = this.AinTyp_IDTextEdit;
            this.ItemForAinTyp_ID.Location = new System.Drawing.Point(0, 48);
            this.ItemForAinTyp_ID.Name = "ItemForAinTyp_ID";
            this.ItemForAinTyp_ID.Size = new System.Drawing.Size(764, 24);
            this.ItemForAinTyp_ID.Text = "Ain Typ_ID";
            this.ItemForAinTyp_ID.TextSize = new System.Drawing.Size(75, 13);
            // 
            // labelControl
            // 
            this.labelControl.AllowHtmlString = true;
            this.labelControl.Appearance.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelControl.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.labelControl.Appearance.Options.UseFont = true;
            this.labelControl.Appearance.Options.UseForeColor = true;
            this.labelControl.Appearance.Options.UseTextOptions = true;
            this.labelControl.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelControl.Location = new System.Drawing.Point(0, 0);
            this.labelControl.Name = "labelControl";
            this.labelControl.Padding = new System.Windows.Forms.Padding(10, 5, 0, 0);
            this.labelControl.Size = new System.Drawing.Size(784, 30);
            this.labelControl.TabIndex = 1;
            this.labelControl.Text = "نوع العين";
            // 
            // ubar1
            // 
            this.ubar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ubar1.Location = new System.Drawing.Point(0, 339);
            this.ubar1.Name = "ubar1";
            this.ubar1.Size = new System.Drawing.Size(784, 61);
            this.ubar1.State = InvAcc.GeneralM.FormState.Saved;
            this.ubar1.TabIndex = 9;
            this.ubar1.Button_Add_Click += new InvAcc.Controls.Ubar.customMessageHandler(this.ubar1_Button_Add_Click);
            this.ubar1.Button_Save_Click += new InvAcc.Controls.Ubar.customMessageHandler(this.ubar1_Button_Save_Click);
            this.ubar1.Button_Close_Click += new InvAcc.Controls.Ubar.customMessageHandler(this.ubar1_Button_Close_Click);
            this.ubar1.Button_Search_Click += new InvAcc.Controls.Ubar.customMessageHandler(this.ubar1_Button_Search_Click);
            this.ubar1.Load += new System.EventHandler(this.ubar1_Load);
            // 
            // XtraForm2
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(784, 400);
            this.Controls.Add(this.dataLayoutControl1);
            this.Controls.Add(this.labelControl);
            this.Controls.Add(this.ubar1);
            this.Name = "XtraForm2";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.XtraForm2_FormClosing);
            this.Load += new System.EventHandler(this.XtraForm2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AinTyp_NoTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t_AinTypsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NameATextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NameETextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NoteTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AinTyp_IDTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForAinTyp_No)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForNameA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForNameE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForNote)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForAinTyp_ID)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.LabelControl labelControl;
        private System.Windows.Forms.BindingSource t_AinTypsBindingSource;
        private DevExpress.XtraEditors.TextEdit AinTyp_NoTextEdit;
        private DevExpress.XtraEditors.TextEdit NameATextEdit;
        private DevExpress.XtraEditors.TextEdit NameETextEdit;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem ItemForAinTyp_No;
        private DevExpress.XtraLayout.LayoutControlItem ItemForNameA;
        private DevExpress.XtraLayout.LayoutControlItem ItemForNameE;
        private DevExpress.XtraLayout.LayoutControlItem ItemForNote;
        private Controls.Ubar ubar1;
        private DevExpress.XtraEditors.MemoEdit NoteTextEdit;
        private DevExpress.XtraEditors.TextEdit AinTyp_IDTextEdit;
        private DevExpress.XtraLayout.LayoutControlItem ItemForAinTyp_ID;
    }

}