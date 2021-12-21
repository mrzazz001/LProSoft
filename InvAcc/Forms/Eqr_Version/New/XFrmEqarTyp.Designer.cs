using InvAcc.Controls;
using System;

namespace InvAcc.Forms.Eqr_Version.New
{
    partial class XFrmEqarTyp
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
            this.t_EqarTypsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForEqarTyp_ID = new DevExpress.XtraLayout.LayoutControlItem();
            this.EqarTyp_IDTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.ItemForEqarTyp_No = new DevExpress.XtraLayout.LayoutControlItem();
            this.EqarTyp_NoTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.ItemForNameA = new DevExpress.XtraLayout.LayoutControlItem();
            this.NameATextEdit = new DevExpress.XtraEditors.TextEdit();
            this.ItemForNameE = new DevExpress.XtraLayout.LayoutControlItem();
            this.NameETextEdit = new DevExpress.XtraEditors.TextEdit();
            this.ItemForNote = new DevExpress.XtraLayout.LayoutControlItem();
            this.NoteTextEdit = new DevExpress.XtraEditors.MemoEdit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t_EqarTypsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForEqarTyp_ID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EqarTyp_IDTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForEqarTyp_No)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EqarTyp_NoTextEdit.Properties)).BeginInit();
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
            this.ubar1.BindingSource = this.t_EqarTypsBindingSource;
            this.ubar1.Location = new System.Drawing.Point(0, 283);
            this.ubar1.Size = new System.Drawing.Size(577, 58);
            this.ubar1.Button_Search_Click += new InvAcc.Controls.Ubar.customMessageHandler(this.ubar1_Button_Search_Click);
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.Controls.Add(this.EqarTyp_IDTextEdit);
            this.dataLayoutControl1.Controls.Add(this.EqarTyp_NoTextEdit);
            this.dataLayoutControl1.Controls.Add(this.NameATextEdit);
            this.dataLayoutControl1.Controls.Add(this.NameETextEdit);
            this.dataLayoutControl1.Controls.Add(this.NoteTextEdit);
            this.dataLayoutControl1.DataSource = this.t_EqarTypsBindingSource;
            this.dataLayoutControl1.OptionsView.HighlightFocusedItem = true;
            this.dataLayoutControl1.OptionsView.RightToLeftMirroringApplied = true;
            this.dataLayoutControl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dataLayoutControl1.Size = new System.Drawing.Size(577, 283);
            // 
            // Root
            // 
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup1});
            this.Root.Size = new System.Drawing.Size(577, 283);
            // 
            // t_EqarTypsBindingSource
            // 
            this.t_EqarTypsBindingSource.DataSource = typeof(ProShared.Stock_Data.T_EqarTyp);
            this.t_EqarTypsBindingSource.AddingNew += new System.ComponentModel.AddingNewEventHandler(this.t_EqarTypsBindingSource_AddingNew);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.AllowDrawBackground = false;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForEqarTyp_ID,
            this.ItemForEqarTyp_No,
            this.ItemForNameA,
            this.ItemForNameE,
            this.ItemForNote});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "autoGeneratedGroup0";
            this.layoutControlGroup1.Size = new System.Drawing.Size(557, 263);
            // 
            // ItemForEqarTyp_ID
            // 
            this.ItemForEqarTyp_ID.Control = this.EqarTyp_IDTextEdit;
            this.ItemForEqarTyp_ID.Location = new System.Drawing.Point(0, 0);
            this.ItemForEqarTyp_ID.Name = "ItemForEqarTyp_ID";
            this.ItemForEqarTyp_ID.Size = new System.Drawing.Size(557, 24);
            this.ItemForEqarTyp_ID.Text = "Eqar Typ_ID";
            this.ItemForEqarTyp_ID.TextSize = new System.Drawing.Size(82, 13);
            this.ItemForEqarTyp_ID.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // EqarTyp_IDTextEdit
            // 
            this.EqarTyp_IDTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.t_EqarTypsBindingSource, "EqarTyp_ID", true));
            this.EqarTyp_IDTextEdit.Location = new System.Drawing.Point(12, 12);
            this.EqarTyp_IDTextEdit.Name = "EqarTyp_IDTextEdit";
            this.EqarTyp_IDTextEdit.Size = new System.Drawing.Size(467, 20);
            this.EqarTyp_IDTextEdit.StyleController = this.dataLayoutControl1;
            this.EqarTyp_IDTextEdit.TabIndex = 4;
            // 
            // ItemForEqarTyp_No
            // 
            this.ItemForEqarTyp_No.Control = this.EqarTyp_NoTextEdit;
            this.ItemForEqarTyp_No.Location = new System.Drawing.Point(0, 24);
            this.ItemForEqarTyp_No.Name = "ItemForEqarTyp_No";
            this.ItemForEqarTyp_No.Size = new System.Drawing.Size(557, 24);
            this.ItemForEqarTyp_No.Text = "رقم نوع العقار";
            this.ItemForEqarTyp_No.TextSize = new System.Drawing.Size(82, 13);
            // 
            // EqarTyp_NoTextEdit
            // 
            this.EqarTyp_NoTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.t_EqarTypsBindingSource, "EqarTyp_No", true));
            this.EqarTyp_NoTextEdit.Location = new System.Drawing.Point(12, 36);
            this.EqarTyp_NoTextEdit.Name = "EqarTyp_NoTextEdit";
            this.EqarTyp_NoTextEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.EqarTyp_NoTextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.EqarTyp_NoTextEdit.Properties.AppearanceFocused.Options.UseTextOptions = true;
            this.EqarTyp_NoTextEdit.Properties.AppearanceFocused.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.EqarTyp_NoTextEdit.Properties.Mask.EditMask = "N0";
            this.EqarTyp_NoTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.EqarTyp_NoTextEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.EqarTyp_NoTextEdit.Size = new System.Drawing.Size(467, 20);
            this.EqarTyp_NoTextEdit.StyleController = this.dataLayoutControl1;
            this.EqarTyp_NoTextEdit.TabIndex = 5;
            // 
            // ItemForNameA
            // 
            this.ItemForNameA.Control = this.NameATextEdit;
            this.ItemForNameA.Location = new System.Drawing.Point(0, 48);
            this.ItemForNameA.Name = "ItemForNameA";
            this.ItemForNameA.Size = new System.Drawing.Size(557, 24);
            this.ItemForNameA.Text = "الاسم العربي";
            this.ItemForNameA.TextSize = new System.Drawing.Size(82, 13);
            // 
            // NameATextEdit
            // 
            this.NameATextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.t_EqarTypsBindingSource, "NameA", true));
            this.NameATextEdit.Location = new System.Drawing.Point(12, 60);
            this.NameATextEdit.Name = "NameATextEdit";
            this.NameATextEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.NameATextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.NameATextEdit.Properties.AppearanceFocused.Options.UseTextOptions = true;
            this.NameATextEdit.Properties.AppearanceFocused.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.NameATextEdit.Size = new System.Drawing.Size(467, 20);
            this.NameATextEdit.StyleController = this.dataLayoutControl1;
            this.NameATextEdit.TabIndex = 6;
            // 
            // ItemForNameE
            // 
            this.ItemForNameE.Control = this.NameETextEdit;
            this.ItemForNameE.Location = new System.Drawing.Point(0, 72);
            this.ItemForNameE.Name = "ItemForNameE";
            this.ItemForNameE.Size = new System.Drawing.Size(557, 24);
            this.ItemForNameE.Text = "الاسم الانجليزي :";
            this.ItemForNameE.TextSize = new System.Drawing.Size(82, 13);
            // 
            // NameETextEdit
            // 
            this.NameETextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.t_EqarTypsBindingSource, "NameE", true));
            this.NameETextEdit.Location = new System.Drawing.Point(12, 84);
            this.NameETextEdit.Name = "NameETextEdit";
            this.NameETextEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.NameETextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.NameETextEdit.Properties.AppearanceFocused.Options.UseTextOptions = true;
            this.NameETextEdit.Properties.AppearanceFocused.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.NameETextEdit.Size = new System.Drawing.Size(467, 20);
            this.NameETextEdit.StyleController = this.dataLayoutControl1;
            this.NameETextEdit.TabIndex = 7;
            // 
            // ItemForNote
            // 
            this.ItemForNote.Control = this.NoteTextEdit;
            this.ItemForNote.Location = new System.Drawing.Point(0, 96);
            this.ItemForNote.Name = "ItemForNote";
            this.ItemForNote.Size = new System.Drawing.Size(557, 167);
            this.ItemForNote.Text = "الملاحظات";
            this.ItemForNote.TextSize = new System.Drawing.Size(82, 13);
            // 
            // NoteTextEdit
            // 
            this.NoteTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.t_EqarTypsBindingSource, "Note", true));
            this.NoteTextEdit.Location = new System.Drawing.Point(12, 108);
            this.NoteTextEdit.Name = "NoteTextEdit";
            this.NoteTextEdit.Size = new System.Drawing.Size(467, 163);
            this.NoteTextEdit.StyleController = this.dataLayoutControl1;
            this.NoteTextEdit.TabIndex = 8;
            // 
            // XFrmEqarTyp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 341);
            this.Name = "XFrmEqarTyp";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.RightToLeftLayout = false;
            this.Text = "انواع العقارات";
            this.Load += new System.EventHandler(this.XFrmEqarTyp_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t_EqarTypsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForEqarTyp_ID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EqarTyp_IDTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForEqarTyp_No)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EqarTyp_NoTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForNameA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NameATextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForNameE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NameETextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForNote)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NoteTextEdit.Properties)).EndInit();
            this.ResumeLayout(false);

        }

    
        #endregion

        private System.Windows.Forms.BindingSource t_EqarTypsBindingSource;
        private DevExpress.XtraEditors.TextEdit EqarTyp_IDTextEdit;
        private DevExpress.XtraEditors.TextEdit EqarTyp_NoTextEdit;
        private DevExpress.XtraEditors.TextEdit NameATextEdit;
        private DevExpress.XtraEditors.TextEdit NameETextEdit;
        private DevExpress.XtraEditors.MemoEdit NoteTextEdit;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem ItemForEqarTyp_ID;
        private DevExpress.XtraLayout.LayoutControlItem ItemForEqarTyp_No;
        private DevExpress.XtraLayout.LayoutControlItem ItemForNameA;
        private DevExpress.XtraLayout.LayoutControlItem ItemForNameE;
        private DevExpress.XtraLayout.LayoutControlItem ItemForNote;
    }
}