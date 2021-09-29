   

namespace InvAcc.Forms
{
partial class FrmGeneralTax
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InvAcc.Forms.FrmGeneralTax));
            label1 = new System.Windows.Forms.Label();
            label30 = new System.Windows.Forms.Label();
            txtSalesTax = new DevComponents.Editors.DoubleInput();
            ButWithoutSave = new DevComponents.DotNetBar.ButtonX();
            ButWithSave = new DevComponents.DotNetBar.ButtonX();
            txtClassName = new System.Windows.Forms.TextBox();
            txtClassNo = new System.Windows.Forms.TextBox();
            label7 = new System.Windows.Forms.Label();
            button_SrchClassNo = new DevComponents.DotNetBar.ButtonX();
            ((System.ComponentModel.ISupportInitialize)txtSalesTax).BeginInit();
            SuspendLayout();
            label1.BackColor = System.Drawing.SystemColors.ButtonFace;
            label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            label30.BackColor = System.Drawing.SystemColors.ButtonFace;
            label30.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            resources.ApplyResources(label30, "label30");
            label30.Name = "label30";
            txtSalesTax.AllowEmptyState = false;
            txtSalesTax.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(255, 255, 198);
            txtSalesTax.BackgroundStyle.Class = "DateTimeInputBackground";
            txtSalesTax.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            txtSalesTax.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            resources.ApplyResources(txtSalesTax, "txtSalesTax");
            txtSalesTax.Increment = 1.0;
            txtSalesTax.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            txtSalesTax.MinValue = 0.0;
            txtSalesTax.Name = "txtSalesTax";
            ButWithoutSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            ButWithoutSave.Checked = true;
            ButWithoutSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            resources.ApplyResources(ButWithoutSave, "ButWithoutSave");
            ButWithoutSave.Name = "ButWithoutSave";
            ButWithoutSave.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            ButWithoutSave.Symbol = "\uf011";
            ButWithoutSave.SymbolSize = 16f;
            ButWithoutSave.TextColor = System.Drawing.Color.Black;
            ButWithoutSave.Click += new System.EventHandler(ButWithoutSave_Click);
            ButWithSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            ButWithSave.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            resources.ApplyResources(ButWithSave, "ButWithSave");
            ButWithSave.Name = "ButWithSave";
            ButWithSave.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            ButWithSave.Symbol = "\uf00c";
            ButWithSave.SymbolSize = 16f;
            ButWithSave.TextColor = System.Drawing.Color.White;
            ButWithSave.Click += new System.EventHandler(ButWithSave_Click);
            txtClassName.BackColor = System.Drawing.Color.DarkSeaGreen;
            txtClassName.ForeColor = System.Drawing.Color.White;
            resources.ApplyResources(txtClassName, "txtClassName");
            txtClassName.Name = "txtClassName";
            txtClassName.ReadOnly = true;
            txtClassNo.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(txtClassNo, "txtClassNo");
            txtClassNo.Name = "txtClassNo";
            txtClassNo.ReadOnly = true;
            txtClassNo.Tag = " T_CATEGORY.CAT_ID ";
            label7.BackColor = System.Drawing.Color.Transparent;
            label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            resources.ApplyResources(label7, "label7");
            label7.Name = "label7";
            button_SrchClassNo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            button_SrchClassNo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            resources.ApplyResources(button_SrchClassNo, "button_SrchClassNo");
            button_SrchClassNo.Name = "button_SrchClassNo";
            button_SrchClassNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            button_SrchClassNo.Symbol = "\uf002";
            button_SrchClassNo.SymbolSize = 12f;
            button_SrchClassNo.TextColor = System.Drawing.Color.SteelBlue;
            button_SrchClassNo.Click += new System.EventHandler(button_SrchClassNo_Click);
            resources.ApplyResources(this, "$this");
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            base.ControlBox = false;
            base.Controls.Add(txtClassName);
            base.Controls.Add(txtClassNo);
            base.Controls.Add(label7);
            base.Controls.Add(button_SrchClassNo);
            base.Controls.Add(ButWithoutSave);
            base.Controls.Add(ButWithSave);
            base.Controls.Add(label1);
            base.Controls.Add(label30);
            base.Controls.Add(txtSalesTax);
            base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            base.KeyPreview = true;
            base.Name = "FrmGeneralTax";
            base.Load += new System.EventHandler(FrmGeneralTax_Load);
            base.KeyPress += new System.Windows.Forms.KeyPressEventHandler(FrmGeneralTax_KeyPress);
            base.KeyDown += new System.Windows.Forms.KeyEventHandler(FrmGeneralTax_KeyDown);
            ((System.ComponentModel.ISupportInitialize)txtSalesTax).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }//###########&&&&&&&&&&

}
}
