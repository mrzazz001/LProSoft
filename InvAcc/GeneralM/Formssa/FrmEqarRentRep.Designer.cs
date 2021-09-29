   

namespace InvAcc.Forms
{
partial class FrmEqarRentRep
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InvAcc.Forms.FrmEqarRentRep));
            txtFromAccNo = new System.Windows.Forms.TextBox();
            ribbonBar1 = new DevComponents.DotNetBar.RibbonBar();
            label10 = new System.Windows.Forms.Label();
            CmbStatus = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            groupBox4 = new System.Windows.Forms.GroupBox();
            txtMToDate = new System.Windows.Forms.MaskedTextBox();
            txtMFromDate = new System.Windows.Forms.MaskedTextBox();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            txtIntoAccName = new System.Windows.Forms.TextBox();
            txtFromAccName = new System.Windows.Forms.TextBox();
            txtIntoAccNo = new System.Windows.Forms.TextBox();
            txtEqarNo = new System.Windows.Forms.TextBox();
            ButExit = new DevComponents.DotNetBar.ButtonX();
            ButOk = new DevComponents.DotNetBar.ButtonX();
            label7 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            button_SrchEqarNo = new DevComponents.DotNetBar.ButtonX();
            button_SrchAccTo = new DevComponents.DotNetBar.ButtonX();
            button_SrchAccFrom = new DevComponents.DotNetBar.ButtonX();
            txtEqarName = new System.Windows.Forms.TextBox();
            ribbonBar1.SuspendLayout();
            groupBox4.SuspendLayout();
            SuspendLayout();
            txtFromAccNo.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(txtFromAccNo, "txtFromAccNo");
            txtFromAccNo.Name = "txtFromAccNo";
            txtFromAccNo.ReadOnly = true;
            txtFromAccNo.Tag = " T_GDDET.AccNo ";
            ribbonBar1.AutoOverflowEnabled = true;
            ribbonBar1.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            ribbonBar1.BackgroundStyle.BackColor = System.Drawing.Color.AliceBlue;
            ribbonBar1.BackgroundStyle.BackColor2 = System.Drawing.SystemColors.GradientActiveCaption;
            ribbonBar1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            ribbonBar1.ContainerControlProcessDialogKey = true;
            ribbonBar1.Controls.Add(label10);
            ribbonBar1.Controls.Add(CmbStatus);
            ribbonBar1.Controls.Add(groupBox4);
            ribbonBar1.Controls.Add(txtIntoAccName);
            ribbonBar1.Controls.Add(txtFromAccName);
            ribbonBar1.Controls.Add(txtFromAccNo);
            ribbonBar1.Controls.Add(txtIntoAccNo);
            ribbonBar1.Controls.Add(txtEqarNo);
            ribbonBar1.Controls.Add(ButExit);
            ribbonBar1.Controls.Add(ButOk);
            ribbonBar1.Controls.Add(label7);
            ribbonBar1.Controls.Add(label6);
            ribbonBar1.Controls.Add(label5);
            ribbonBar1.Controls.Add(button_SrchEqarNo);
            ribbonBar1.Controls.Add(button_SrchAccTo);
            ribbonBar1.Controls.Add(button_SrchAccFrom);
            ribbonBar1.Controls.Add(txtEqarName);
            resources.ApplyResources(ribbonBar1, "ribbonBar1");
            ribbonBar1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            ribbonBar1.Name = "ribbonBar1";
            ribbonBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            ribbonBar1.TitleStyle.BackColor = System.Drawing.Color.FromArgb(227, 239, 255);
            ribbonBar1.TitleStyle.BackColor2 = System.Drawing.Color.FromArgb(101, 147, 207);
            ribbonBar1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            ribbonBar1.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            resources.ApplyResources(label10, "label10");
            label10.BackColor = System.Drawing.Color.Transparent;
            label10.Name = "label10";
            CmbStatus.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            CmbStatus.DisplayMember = "Text";
            CmbStatus.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            CmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(CmbStatus, "CmbStatus");
            CmbStatus.FormattingEnabled = true;
            CmbStatus.Name = "CmbStatus";
            CmbStatus.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            groupBox4.BackColor = System.Drawing.Color.Transparent;
            groupBox4.Controls.Add(txtMToDate);
            groupBox4.Controls.Add(txtMFromDate);
            groupBox4.Controls.Add(label1);
            groupBox4.Controls.Add(label2);
            resources.ApplyResources(groupBox4, "groupBox4");
            groupBox4.Name = "groupBox4";
            groupBox4.TabStop = false;
            resources.ApplyResources(txtMToDate, "txtMToDate");
            txtMToDate.Name = "txtMToDate";
            txtMToDate.Leave += new System.EventHandler(txtMToDate_Leave);
            txtMToDate.Click += new System.EventHandler(txtMToDate_Click);
            resources.ApplyResources(txtMFromDate, "txtMFromDate");
            txtMFromDate.Name = "txtMFromDate";
            txtMFromDate.Leave += new System.EventHandler(txtMFromDate_Leave);
            txtMFromDate.Click += new System.EventHandler(txtMFromDate_Click);
            resources.ApplyResources(label1, "label1");
            label1.BackColor = System.Drawing.Color.Transparent;
            label1.Name = "label1";
            resources.ApplyResources(label2, "label2");
            label2.BackColor = System.Drawing.Color.Transparent;
            label2.Name = "label2";
            txtIntoAccName.BackColor = System.Drawing.Color.DarkSeaGreen;
            txtIntoAccName.ForeColor = System.Drawing.Color.White;
            resources.ApplyResources(txtIntoAccName, "txtIntoAccName");
            txtIntoAccName.Name = "txtIntoAccName";
            txtIntoAccName.ReadOnly = true;
            txtFromAccName.BackColor = System.Drawing.Color.DarkSeaGreen;
            txtFromAccName.ForeColor = System.Drawing.Color.White;
            resources.ApplyResources(txtFromAccName, "txtFromAccName");
            txtFromAccName.Name = "txtFromAccName";
            txtFromAccName.ReadOnly = true;
            txtIntoAccNo.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(txtIntoAccNo, "txtIntoAccNo");
            txtIntoAccNo.Name = "txtIntoAccNo";
            txtIntoAccNo.ReadOnly = true;
            txtIntoAccNo.Tag = " T_GDDET.AccNo ";
            txtEqarNo.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(txtEqarNo, "txtEqarNo");
            txtEqarNo.Name = "txtEqarNo";
            txtEqarNo.ReadOnly = true;
            txtEqarNo.Tag = "";
            ButExit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            ButExit.Checked = true;
            ButExit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            resources.ApplyResources(ButExit, "ButExit");
            ButExit.Name = "ButExit";
            ButExit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            ButExit.Symbol = "\uf011";
            ButExit.SymbolSize = 16f;
            ButExit.TextColor = System.Drawing.Color.Black;
            ButExit.Click += new System.EventHandler(ButExit_Click);
            ButOk.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            ButOk.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            resources.ApplyResources(ButOk, "ButOk");
            ButOk.Name = "ButOk";
            ButOk.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            ButOk.Symbol = "\uf0c5";
            ButOk.SymbolSize = 16f;
            ButOk.TextColor = System.Drawing.Color.White;
            ButOk.Click += new System.EventHandler(ButOk_Click);
            resources.ApplyResources(label7, "label7");
            label7.BackColor = System.Drawing.Color.Transparent;
            label7.Name = "label7";
            resources.ApplyResources(label6, "label6");
            label6.BackColor = System.Drawing.Color.Transparent;
            label6.Name = "label6";
            resources.ApplyResources(label5, "label5");
            label5.BackColor = System.Drawing.Color.Transparent;
            label5.Name = "label5";
            button_SrchEqarNo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            button_SrchEqarNo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            resources.ApplyResources(button_SrchEqarNo, "button_SrchEqarNo");
            button_SrchEqarNo.Name = "button_SrchEqarNo";
            button_SrchEqarNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            button_SrchEqarNo.Symbol = "\uf002";
            button_SrchEqarNo.SymbolSize = 12f;
            button_SrchEqarNo.TextColor = System.Drawing.Color.SteelBlue;
            button_SrchEqarNo.Click += new System.EventHandler(button_SrchTenantNo_Click);
            button_SrchAccTo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            button_SrchAccTo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            resources.ApplyResources(button_SrchAccTo, "button_SrchAccTo");
            button_SrchAccTo.Name = "button_SrchAccTo";
            button_SrchAccTo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            button_SrchAccTo.Symbol = "\uf002";
            button_SrchAccTo.SymbolSize = 12f;
            button_SrchAccTo.TextColor = System.Drawing.Color.SteelBlue;
            button_SrchAccTo.Click += new System.EventHandler(button_SrchAccTo_Click);
            button_SrchAccFrom.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            button_SrchAccFrom.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            resources.ApplyResources(button_SrchAccFrom, "button_SrchAccFrom");
            button_SrchAccFrom.Name = "button_SrchAccFrom";
            button_SrchAccFrom.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            button_SrchAccFrom.Symbol = "\uf002";
            button_SrchAccFrom.SymbolSize = 12f;
            button_SrchAccFrom.TextColor = System.Drawing.Color.SteelBlue;
            button_SrchAccFrom.Click += new System.EventHandler(button_SrchAccFrom_Click);
            txtEqarName.BackColor = System.Drawing.Color.DarkSeaGreen;
            txtEqarName.ForeColor = System.Drawing.Color.White;
            resources.ApplyResources(txtEqarName, "txtEqarName");
            txtEqarName.Name = "txtEqarName";
            txtEqarName.ReadOnly = true;
            txtEqarName.Tag = "T_AccDef.AccDef_No";
            resources.ApplyResources(this, "$this");
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            base.Controls.Add(ribbonBar1);
            base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            base.KeyPreview = true;
            base.MaximizeBox = false;
            base.Name = "FrmEqarRentRep";
            base.Load += new System.EventHandler(FrmEqarRentRep_Load);
            base.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Frm_KeyPress);
            base.KeyDown += new System.Windows.Forms.KeyEventHandler(Frm_KeyDown);
            ribbonBar1.ResumeLayout(false);
            ribbonBar1.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ResumeLayout(false);
        }//###########&&&&&&&&&&

}
}
