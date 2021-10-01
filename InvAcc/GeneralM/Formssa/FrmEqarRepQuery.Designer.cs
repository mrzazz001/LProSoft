   

namespace InvAcc.Forms
{
partial class FrmEqarRepQuery
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InvAcc.Forms.FrmEqarRepQuery));
            ribbonBar1 = new DevComponents.DotNetBar.RibbonBar();
            panel1 = new System.Windows.Forms.Panel();
            FlexFooter = new C1.Win.C1FlexGrid.C1FlexGrid();
            label8 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            CmbEyeNature = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            CmbEyeTyp = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            label7 = new System.Windows.Forms.Label();
            CmbEyeStatus = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            label3 = new System.Windows.Forms.Label();
            CmbCity = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            label2 = new System.Windows.Forms.Label();
            CmbEqarNature = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            label1 = new System.Windows.Forms.Label();
            CmbEqarTyp = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            label10 = new System.Windows.Forms.Label();
            CmbEqarStat = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            label5 = new System.Windows.Forms.Label();
            txtEqarName = new System.Windows.Forms.TextBox();
            txtEqarNo = new System.Windows.Forms.TextBox();
            txtOwnerNo = new System.Windows.Forms.TextBox();
            label6 = new System.Windows.Forms.Label();
            button_SrchOwner = new DevComponents.DotNetBar.ButtonX();
            button_SrchEqarNo = new DevComponents.DotNetBar.ButtonX();
            FlexHead = new C1.Win.C1FlexGrid.C1FlexGrid();
            ButQuery = new DevComponents.DotNetBar.ButtonX();
            ButExit = new DevComponents.DotNetBar.ButtonX();
            ButOk = new DevComponents.DotNetBar.ButtonX();
            txtOwnerName = new System.Windows.Forms.TextBox();
            ribbonBar1.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)FlexFooter).BeginInit();
            ((System.ComponentModel.ISupportInitialize)FlexHead).BeginInit();
            SuspendLayout();
            ribbonBar1.AutoOverflowEnabled = true;
            ribbonBar1.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            ribbonBar1.BackgroundStyle.BackColor = System.Drawing.Color.AliceBlue;
            ribbonBar1.BackgroundStyle.BackColor2 = System.Drawing.SystemColors.GradientActiveCaption;
            ribbonBar1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            ribbonBar1.ContainerControlProcessDialogKey = true;
            ribbonBar1.Controls.Add(panel1);
            resources.ApplyResources(ribbonBar1, "ribbonBar1");
            ribbonBar1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            ribbonBar1.Name = "ribbonBar1";
            ribbonBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            ribbonBar1.TitleStyle.BackColor = System.Drawing.Color.FromArgb(227, 239, 255);
            ribbonBar1.TitleStyle.BackColor2 = System.Drawing.Color.FromArgb(101, 147, 207);
            ribbonBar1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            ribbonBar1.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            panel1.BackColor = System.Drawing.Color.Transparent;
            panel1.Controls.Add(FlexFooter);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(CmbEyeNature);
            panel1.Controls.Add(CmbEyeTyp);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(CmbEyeStatus);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(CmbCity);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(CmbEqarNature);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(CmbEqarTyp);
            panel1.Controls.Add(label10);
            panel1.Controls.Add(CmbEqarStat);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(txtEqarName);
            panel1.Controls.Add(txtEqarNo);
            panel1.Controls.Add(txtOwnerNo);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(button_SrchOwner);
            panel1.Controls.Add(button_SrchEqarNo);
            panel1.Controls.Add(FlexHead);
            panel1.Controls.Add(ButQuery);
            panel1.Controls.Add(ButExit);
            panel1.Controls.Add(ButOk);
            panel1.Controls.Add(txtOwnerName);
            resources.ApplyResources(panel1, "panel1");
            panel1.Name = "panel1";
            FlexFooter.AllowEditing = false;
            FlexFooter.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(FlexFooter, "FlexFooter");
            FlexFooter.Name = "FlexFooter";
            FlexFooter.Rows.Count = 1;
            FlexFooter.Rows.DefaultSize = 19;
            FlexFooter.StyleInfo = resources.GetString("FlexFooter.StyleInfo");
            FlexFooter.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Black;
            resources.ApplyResources(label8, "label8");
            label8.BackColor = System.Drawing.Color.Transparent;
            label8.Name = "label8";
            resources.ApplyResources(label4, "label4");
            label4.BackColor = System.Drawing.Color.Transparent;
            label4.Name = "label4";
            CmbEyeNature.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            CmbEyeNature.DisplayMember = "Text";
            CmbEyeNature.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            CmbEyeNature.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            CmbEyeNature.FormattingEnabled = true;
            resources.ApplyResources(CmbEyeNature, "CmbEyeNature");
            CmbEyeNature.Name = "CmbEyeNature";
            CmbEyeNature.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            CmbEyeNature.Tag = "T_AinsData.AinNature";
            CmbEyeTyp.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            CmbEyeTyp.DisplayMember = "Text";
            CmbEyeTyp.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            CmbEyeTyp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            CmbEyeTyp.FormattingEnabled = true;
            resources.ApplyResources(CmbEyeTyp, "CmbEyeTyp");
            CmbEyeTyp.Name = "CmbEyeTyp";
            CmbEyeTyp.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            CmbEyeTyp.Tag = "T_AinsData.AinTyp";
            resources.ApplyResources(label7, "label7");
            label7.BackColor = System.Drawing.Color.Transparent;
            label7.Name = "label7";
            CmbEyeStatus.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            CmbEyeStatus.DisplayMember = "Text";
            CmbEyeStatus.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            CmbEyeStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            CmbEyeStatus.FormattingEnabled = true;
            resources.ApplyResources(CmbEyeStatus, "CmbEyeStatus");
            CmbEyeStatus.Name = "CmbEyeStatus";
            CmbEyeStatus.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            CmbEyeStatus.Tag = "T_AinsData.AinStatus";
            resources.ApplyResources(label3, "label3");
            label3.BackColor = System.Drawing.Color.Transparent;
            label3.Name = "label3";
            CmbCity.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            CmbCity.DisplayMember = "Text";
            CmbCity.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            CmbCity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            CmbCity.FormattingEnabled = true;
            resources.ApplyResources(CmbCity, "CmbCity");
            CmbCity.Name = "CmbCity";
            CmbCity.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            CmbCity.Tag = "T_EqarsData.CityNo";
            resources.ApplyResources(label2, "label2");
            label2.BackColor = System.Drawing.Color.Transparent;
            label2.Name = "label2";
            CmbEqarNature.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            CmbEqarNature.DisplayMember = "Text";
            CmbEqarNature.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            CmbEqarNature.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            CmbEqarNature.FormattingEnabled = true;
            resources.ApplyResources(CmbEqarNature, "CmbEqarNature");
            CmbEqarNature.Name = "CmbEqarNature";
            CmbEqarNature.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            CmbEqarNature.Tag = "T_EqarsData.EqarNatureNo";
            resources.ApplyResources(label1, "label1");
            label1.BackColor = System.Drawing.Color.Transparent;
            label1.Name = "label1";
            CmbEqarTyp.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            CmbEqarTyp.DisplayMember = "Text";
            CmbEqarTyp.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            CmbEqarTyp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            CmbEqarTyp.FormattingEnabled = true;
            resources.ApplyResources(CmbEqarTyp, "CmbEqarTyp");
            CmbEqarTyp.Name = "CmbEqarTyp";
            CmbEqarTyp.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            CmbEqarTyp.Tag = "T_EqarsData.EqarTypNo";
            resources.ApplyResources(label10, "label10");
            label10.BackColor = System.Drawing.Color.Transparent;
            label10.Name = "label10";
            CmbEqarStat.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            CmbEqarStat.DisplayMember = "Text";
            CmbEqarStat.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            CmbEqarStat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            CmbEqarStat.FormattingEnabled = true;
            resources.ApplyResources(CmbEqarStat, "CmbEqarStat");
            CmbEqarStat.Name = "CmbEqarStat";
            CmbEqarStat.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            CmbEqarStat.Tag = "T_EqarsData.EqarStatus";
            resources.ApplyResources(label5, "label5");
            label5.BackColor = System.Drawing.Color.Transparent;
            label5.Name = "label5";
            txtEqarName.BackColor = System.Drawing.Color.DarkSeaGreen;
            txtEqarName.ForeColor = System.Drawing.Color.White;
            resources.ApplyResources(txtEqarName, "txtEqarName");
            txtEqarName.Name = "txtEqarName";
            txtEqarName.ReadOnly = true;
            txtEqarNo.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(txtEqarNo, "txtEqarNo");
            txtEqarNo.Name = "txtEqarNo";
            txtEqarNo.ReadOnly = true;
            txtEqarNo.Tag = "T_EqarsData.EqarID";
            txtOwnerNo.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(txtOwnerNo, "txtOwnerNo");
            txtOwnerNo.Name = "txtOwnerNo";
            txtOwnerNo.ReadOnly = true;
            txtOwnerNo.Tag = "T_EqarsData.OwnerNo";
            resources.ApplyResources(label6, "label6");
            label6.BackColor = System.Drawing.Color.Transparent;
            label6.Name = "label6";
            button_SrchOwner.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            button_SrchOwner.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            resources.ApplyResources(button_SrchOwner, "button_SrchOwner");
            button_SrchOwner.Name = "button_SrchOwner";
            button_SrchOwner.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            button_SrchOwner.Symbol = "\uf002";
            button_SrchOwner.SymbolSize = 12f;
            button_SrchOwner.TextColor = System.Drawing.Color.SteelBlue;
            button_SrchOwner.Click += new System.EventHandler(button_SrchOwner_Click);
            button_SrchEqarNo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            button_SrchEqarNo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            resources.ApplyResources(button_SrchEqarNo, "button_SrchEqarNo");
            button_SrchEqarNo.Name = "button_SrchEqarNo";
            button_SrchEqarNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            button_SrchEqarNo.Symbol = "\uf002";
            button_SrchEqarNo.SymbolSize = 12f;
            button_SrchEqarNo.TextColor = System.Drawing.Color.SteelBlue;
            button_SrchEqarNo.Click += new System.EventHandler(button_SrchEqarNo_Click);
            FlexHead.AllowEditing = false;
            FlexHead.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(FlexHead, "FlexHead");
            FlexHead.Name = "FlexHead";
            FlexHead.Rows.Count = 1;
            FlexHead.Rows.DefaultSize = 19;
            FlexHead.StyleInfo = resources.GetString("FlexHead.StyleInfo");
            FlexHead.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Blue;
            ButQuery.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            ButQuery.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            resources.ApplyResources(ButQuery, "ButQuery");
            ButQuery.Name = "ButQuery";
            ButQuery.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            ButQuery.Symbol = "\uf002";
            ButQuery.SymbolSize = 16f;
            ButQuery.TextColor = System.Drawing.Color.White;
            ButQuery.Click += new System.EventHandler(ButQuery_Click);
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
            txtOwnerName.BackColor = System.Drawing.Color.DarkSeaGreen;
            txtOwnerName.ForeColor = System.Drawing.Color.White;
            resources.ApplyResources(txtOwnerName, "txtOwnerName");
            txtOwnerName.Name = "txtOwnerName";
            txtOwnerName.ReadOnly = true;
            resources.ApplyResources(this, "$this");
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            base.Controls.Add(ribbonBar1);
            base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            base.KeyPreview = true;
            base.MaximizeBox = false;
            base.Name = "FrmEqarRepQuery";
            base.Load += new System.EventHandler(FrmEqarRepQuery_Load);
            base.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Frm_KeyPress);
            base.KeyDown += new System.Windows.Forms.KeyEventHandler(Frm_KeyDown);
            ribbonBar1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)FlexFooter).EndInit();
            ((System.ComponentModel.ISupportInitialize)FlexHead).EndInit();
            ResumeLayout(false);
        }//###########&&&&&&&&&&

}
}