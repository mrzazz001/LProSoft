   

namespace InvAcc.Forms
{
partial class SSSFMSndPrintSetup
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
    
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InvAcc.Forms.SSSFMSndPrintSetup));
            FlxFiles = new C1.Win.C1FlexGrid.C1FlexGrid();
            RedButPaperA4 = new System.Windows.Forms.RadioButton();
            CmbInvType = new System.Windows.Forms.ComboBox();
            ChkPTable = new System.Windows.Forms.CheckBox();
            CmbPrinter = new System.Windows.Forms.ComboBox();
            RedButCasher = new System.Windows.Forms.RadioButton();
            CmbPrintP = new System.Windows.Forms.ComboBox();
            txtDistance = new System.Windows.Forms.TextBox();
            label6 = new System.Windows.Forms.Label();
            CmbDir = new System.Windows.Forms.ComboBox();
            txtLinePage = new System.Windows.Forms.TextBox();
            CmbUnit = new System.Windows.Forms.ComboBox();
            ButWithoutSave = new System.Windows.Forms.Button();
            txtLeftM = new System.Windows.Forms.TextBox();
            label3 = new System.Windows.Forms.Label();
            ButWithSave = new System.Windows.Forms.Button();
            label8 = new System.Windows.Forms.Label();
            groupBox1 = new System.Windows.Forms.GroupBox();
            label7 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            txtBottM = new System.Windows.Forms.TextBox();
            txtRight = new System.Windows.Forms.TextBox();
            label2 = new System.Windows.Forms.Label();
            txtTopM = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            CmbPrintP2 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)FlxFiles).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            FlxFiles.AccessibleDescription = null;
            FlxFiles.AccessibleName = null;
            resources.ApplyResources(FlxFiles, "FlxFiles");
            FlxFiles.BackgroundImage = null;
            FlxFiles.Font = null;
            FlxFiles.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross;
            FlxFiles.Name = "FlxFiles";
            FlxFiles.Rows.Count = 14;
            FlxFiles.Rows.DefaultSize = 19;
            FlxFiles.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.System;
            FlxFiles.AfterEdit += new C1.Win.C1FlexGrid.RowColEventHandler(FlxFiles_AfterEdit);
            RedButPaperA4.AccessibleDescription = null;
            RedButPaperA4.AccessibleName = null;
            resources.ApplyResources(RedButPaperA4, "RedButPaperA4");
            RedButPaperA4.BackgroundImage = null;
            RedButPaperA4.Checked = true;
            RedButPaperA4.Font = null;
            RedButPaperA4.Name = "RedButPaperA4";
            RedButPaperA4.TabStop = true;
            RedButPaperA4.UseVisualStyleBackColor = true;
            CmbInvType.AccessibleDescription = null;
            CmbInvType.AccessibleName = null;
            resources.ApplyResources(CmbInvType, "CmbInvType");
            CmbInvType.BackgroundImage = null;
            CmbInvType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            CmbInvType.Font = null;
            CmbInvType.FormattingEnabled = true;
            CmbInvType.Name = "CmbInvType";
            CmbInvType.SelectedIndexChanged += new System.EventHandler(CmbInvType_SelectedIndexChanged);
            ChkPTable.AccessibleDescription = null;
            ChkPTable.AccessibleName = null;
            resources.ApplyResources(ChkPTable, "ChkPTable");
            ChkPTable.BackgroundImage = null;
            ChkPTable.Font = null;
            ChkPTable.Name = "ChkPTable";
            ChkPTable.UseVisualStyleBackColor = true;
            CmbPrinter.AccessibleDescription = null;
            CmbPrinter.AccessibleName = null;
            resources.ApplyResources(CmbPrinter, "CmbPrinter");
            CmbPrinter.BackgroundImage = null;
            CmbPrinter.Font = null;
            CmbPrinter.FormattingEnabled = true;
            CmbPrinter.Name = "CmbPrinter";
            RedButCasher.AccessibleDescription = null;
            RedButCasher.AccessibleName = null;
            resources.ApplyResources(RedButCasher, "RedButCasher");
            RedButCasher.BackgroundImage = null;
            RedButCasher.Font = null;
            RedButCasher.Name = "RedButCasher";
            RedButCasher.UseVisualStyleBackColor = true;
            CmbPrintP.AccessibleDescription = null;
            CmbPrintP.AccessibleName = null;
            resources.ApplyResources(CmbPrintP, "CmbPrintP");
            CmbPrintP.BackgroundImage = null;
            CmbPrintP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            CmbPrintP.Font = null;
            CmbPrintP.FormattingEnabled = true;
            CmbPrintP.Name = "CmbPrintP";
            txtDistance.AccessibleDescription = null;
            txtDistance.AccessibleName = null;
            resources.ApplyResources(txtDistance, "txtDistance");
            txtDistance.BackgroundImage = null;
            txtDistance.Font = null;
            txtDistance.Name = "txtDistance";
            label6.AccessibleDescription = null;
            label6.AccessibleName = null;
            resources.ApplyResources(label6, "label6");
            label6.Font = null;
            label6.Name = "label6";
            CmbDir.AccessibleDescription = null;
            CmbDir.AccessibleName = null;
            resources.ApplyResources(CmbDir, "CmbDir");
            CmbDir.BackgroundImage = null;
            CmbDir.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            CmbDir.Font = null;
            CmbDir.FormattingEnabled = true;
            CmbDir.Name = "CmbDir";
            txtLinePage.AccessibleDescription = null;
            txtLinePage.AccessibleName = null;
            resources.ApplyResources(txtLinePage, "txtLinePage");
            txtLinePage.BackgroundImage = null;
            txtLinePage.Font = null;
            txtLinePage.Name = "txtLinePage";
            CmbUnit.AccessibleDescription = null;
            CmbUnit.AccessibleName = null;
            resources.ApplyResources(CmbUnit, "CmbUnit");
            CmbUnit.BackgroundImage = null;
            CmbUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            CmbUnit.Font = null;
            CmbUnit.FormattingEnabled = true;
            CmbUnit.Items.AddRange(new object[5]
            {
                resources.GetString("CmbUnit.Items"),
                resources.GetString("CmbUnit.Items1"),
                resources.GetString("CmbUnit.Items2"),
                resources.GetString("CmbUnit.Items3"),
                resources.GetString("CmbUnit.Items4")
            });
            CmbUnit.Name = "CmbUnit";
            ButWithoutSave.AccessibleDescription = null;
            ButWithoutSave.AccessibleName = null;
            resources.ApplyResources(ButWithoutSave, "ButWithoutSave");
            ButWithoutSave.BackgroundImage = null;
            ButWithoutSave.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            ButWithoutSave.Name = "ButWithoutSave";
            ButWithoutSave.UseVisualStyleBackColor = true;
            ButWithoutSave.Click += new System.EventHandler(ButWithoutSave_Click);
            txtLeftM.AccessibleDescription = null;
            txtLeftM.AccessibleName = null;
            resources.ApplyResources(txtLeftM, "txtLeftM");
            txtLeftM.BackgroundImage = null;
            txtLeftM.Font = null;
            txtLeftM.Name = "txtLeftM";
            label3.AccessibleDescription = null;
            label3.AccessibleName = null;
            resources.ApplyResources(label3, "label3");
            label3.Font = null;
            label3.Name = "label3";
            ButWithSave.AccessibleDescription = null;
            ButWithSave.AccessibleName = null;
            resources.ApplyResources(ButWithSave, "ButWithSave");
            ButWithSave.BackgroundImage = null;
            ButWithSave.Name = "ButWithSave";
            ButWithSave.UseVisualStyleBackColor = true;
            ButWithSave.Click += new System.EventHandler(ButWithSave_Click);
            label8.AccessibleDescription = null;
            label8.AccessibleName = null;
            resources.ApplyResources(label8, "label8");
            label8.Font = null;
            label8.Name = "label8";
            groupBox1.AccessibleDescription = null;
            groupBox1.AccessibleName = null;
            resources.ApplyResources(groupBox1, "groupBox1");
            groupBox1.BackColor = System.Drawing.SystemColors.Control;
            groupBox1.BackgroundImage = null;
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(CmbPrinter);
            groupBox1.Controls.Add(txtDistance);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(txtLinePage);
            groupBox1.Controls.Add(txtLeftM);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(txtBottM);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(txtRight);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtTopM);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(label5);
            groupBox1.Font = null;
            groupBox1.Name = "groupBox1";
            groupBox1.TabStop = false;
            label7.AccessibleDescription = null;
            label7.AccessibleName = null;
            resources.ApplyResources(label7, "label7");
            label7.Font = null;
            label7.Name = "label7";
            label4.AccessibleDescription = null;
            label4.AccessibleName = null;
            resources.ApplyResources(label4, "label4");
            label4.Font = null;
            label4.Name = "label4";
            txtBottM.AccessibleDescription = null;
            txtBottM.AccessibleName = null;
            resources.ApplyResources(txtBottM, "txtBottM");
            txtBottM.BackgroundImage = null;
            txtBottM.Font = null;
            txtBottM.Name = "txtBottM";
            txtRight.AccessibleDescription = null;
            txtRight.AccessibleName = null;
            resources.ApplyResources(txtRight, "txtRight");
            txtRight.BackgroundImage = null;
            txtRight.Font = null;
            txtRight.Name = "txtRight";
            label2.AccessibleDescription = null;
            label2.AccessibleName = null;
            resources.ApplyResources(label2, "label2");
            label2.Font = null;
            label2.Name = "label2";
            txtTopM.AccessibleDescription = null;
            txtTopM.AccessibleName = null;
            resources.ApplyResources(txtTopM, "txtTopM");
            txtTopM.BackgroundImage = null;
            txtTopM.Font = null;
            txtTopM.Name = "txtTopM";
            label1.AccessibleDescription = null;
            label1.AccessibleName = null;
            resources.ApplyResources(label1, "label1");
            label1.Font = null;
            label1.Name = "label1";
            label5.AccessibleDescription = null;
            label5.AccessibleName = null;
            resources.ApplyResources(label5, "label5");
            label5.Font = null;
            label5.Name = "label5";
            CmbPrintP2.AccessibleDescription = null;
            CmbPrintP2.AccessibleName = null;
            resources.ApplyResources(CmbPrintP2, "CmbPrintP2");
            CmbPrintP2.BackgroundImage = null;
            CmbPrintP2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            CmbPrintP2.Font = null;
            CmbPrintP2.FormattingEnabled = true;
            CmbPrintP2.Name = "CmbPrintP2";
            base.AccessibleDescription = null;
            base.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.AliceBlue;
            BackgroundImage = null;
            base.Controls.Add(FlxFiles);
            base.Controls.Add(RedButPaperA4);
            base.Controls.Add(CmbInvType);
            base.Controls.Add(ChkPTable);
            base.Controls.Add(RedButCasher);
            base.Controls.Add(CmbPrintP);
            base.Controls.Add(CmbDir);
            base.Controls.Add(CmbUnit);
            base.Controls.Add(ButWithoutSave);
            base.Controls.Add(ButWithSave);
            base.Controls.Add(label8);
            base.Controls.Add(groupBox1);
            base.Controls.Add(CmbPrintP2);
            Font = null;
            base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            base.KeyPreview = true;
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "SSSFMSndPrintSetup";
            base.Load += new System.EventHandler(SSSFMSndPrintSetup_Load);
            ((System.ComponentModel.ISupportInitialize)FlxFiles).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }//###########&&&&&&&&&&

}
}
