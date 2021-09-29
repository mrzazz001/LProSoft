   

namespace InvAcc.Forms
{
partial class FrmUpdateDocAllownc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InvAcc.Forms.FrmUpdateDocAllownc));
            ribbonBar1 = new DevComponents.DotNetBar.RibbonBar();
            panel1 = new System.Windows.Forms.Panel();
            groupPanel_Now = new DevComponents.DotNetBar.Controls.GroupPanel();
            comboBox_InsuranceType = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            label2 = new System.Windows.Forms.Label();
            textBox_Insurance_Class = new System.Windows.Forms.TextBox();
            label3 = new System.Windows.Forms.Label();
            groupPanel_After = new DevComponents.DotNetBar.Controls.GroupPanel();
            comboBox_InsuranceTypeAfter = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            label1 = new System.Windows.Forms.Label();
            textBox_Insurance_ClassAfter = new System.Windows.Forms.TextBox();
            label146 = new System.Windows.Forms.Label();
            textBox_Note = new DevComponents.DotNetBar.Controls.TextBoxX();
            ButExit = new DevComponents.DotNetBar.ButtonX();
            ButOk = new DevComponents.DotNetBar.ButtonX();
            comboBox_EmpNo = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            button_SrchEmp = new DevComponents.DotNetBar.ButtonX();
            label12 = new System.Windows.Forms.Label();
            dateTimeInput_warnDate = new System.Windows.Forms.MaskedTextBox();
            label54 = new System.Windows.Forms.Label();
            textBox_EmpNo = new System.Windows.Forms.TextBox();
            label38 = new System.Windows.Forms.Label();
            ribbonBar1.SuspendLayout();
            panel1.SuspendLayout();
            groupPanel_Now.SuspendLayout();
            groupPanel_After.SuspendLayout();
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
            panel1.Controls.Add(groupPanel_Now);
            panel1.Controls.Add(groupPanel_After);
            panel1.Controls.Add(textBox_Note);
            panel1.Controls.Add(ButExit);
            panel1.Controls.Add(ButOk);
            panel1.Controls.Add(comboBox_EmpNo);
            panel1.Controls.Add(button_SrchEmp);
            panel1.Controls.Add(label12);
            panel1.Controls.Add(dateTimeInput_warnDate);
            panel1.Controls.Add(label54);
            panel1.Controls.Add(textBox_EmpNo);
            panel1.Controls.Add(label38);
            resources.ApplyResources(panel1, "panel1");
            panel1.Name = "panel1";
            groupPanel_Now.CanvasColor = System.Drawing.SystemColors.Control;
            groupPanel_Now.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            groupPanel_Now.Controls.Add(comboBox_InsuranceType);
            groupPanel_Now.Controls.Add(label2);
            groupPanel_Now.Controls.Add(textBox_Insurance_Class);
            groupPanel_Now.Controls.Add(label3);
            resources.ApplyResources(groupPanel_Now, "groupPanel_Now");
            groupPanel_Now.Name = "groupPanel_Now";
            groupPanel_Now.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            groupPanel_Now.Style.BackColorGradientAngle = 90;
            groupPanel_Now.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            groupPanel_Now.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            groupPanel_Now.Style.BorderBottomWidth = 1;
            groupPanel_Now.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            groupPanel_Now.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            groupPanel_Now.Style.BorderLeftWidth = 1;
            groupPanel_Now.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            groupPanel_Now.Style.BorderRightWidth = 1;
            groupPanel_Now.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            groupPanel_Now.Style.BorderTopWidth = 1;
            groupPanel_Now.Style.CornerDiameter = 4;
            groupPanel_Now.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            groupPanel_Now.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            groupPanel_Now.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            groupPanel_Now.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            groupPanel_Now.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            groupPanel_Now.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            comboBox_InsuranceType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            comboBox_InsuranceType.DisplayMember = "Text";
            comboBox_InsuranceType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            comboBox_InsuranceType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(comboBox_InsuranceType, "comboBox_InsuranceType");
            comboBox_InsuranceType.FormattingEnabled = true;
            comboBox_InsuranceType.Name = "comboBox_InsuranceType";
            comboBox_InsuranceType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            resources.ApplyResources(label2, "label2");
            label2.Name = "label2";
            textBox_Insurance_Class.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(textBox_Insurance_Class, "textBox_Insurance_Class");
            textBox_Insurance_Class.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
            textBox_Insurance_Class.Name = "textBox_Insurance_Class";
            resources.ApplyResources(label3, "label3");
            label3.BackColor = System.Drawing.Color.Transparent;
            label3.Name = "label3";
            groupPanel_After.CanvasColor = System.Drawing.SystemColors.Control;
            groupPanel_After.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            groupPanel_After.Controls.Add(comboBox_InsuranceTypeAfter);
            groupPanel_After.Controls.Add(label1);
            groupPanel_After.Controls.Add(textBox_Insurance_ClassAfter);
            groupPanel_After.Controls.Add(label146);
            resources.ApplyResources(groupPanel_After, "groupPanel_After");
            groupPanel_After.Name = "groupPanel_After";
            groupPanel_After.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            groupPanel_After.Style.BackColorGradientAngle = 90;
            groupPanel_After.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            groupPanel_After.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            groupPanel_After.Style.BorderBottomWidth = 1;
            groupPanel_After.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            groupPanel_After.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            groupPanel_After.Style.BorderLeftWidth = 1;
            groupPanel_After.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            groupPanel_After.Style.BorderRightWidth = 1;
            groupPanel_After.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            groupPanel_After.Style.BorderTopWidth = 1;
            groupPanel_After.Style.CornerDiameter = 4;
            groupPanel_After.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            groupPanel_After.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            groupPanel_After.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            groupPanel_After.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            groupPanel_After.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            groupPanel_After.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            comboBox_InsuranceTypeAfter.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            comboBox_InsuranceTypeAfter.DisplayMember = "Text";
            comboBox_InsuranceTypeAfter.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            comboBox_InsuranceTypeAfter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox_InsuranceTypeAfter.FormattingEnabled = true;
            resources.ApplyResources(comboBox_InsuranceTypeAfter, "comboBox_InsuranceTypeAfter");
            comboBox_InsuranceTypeAfter.Name = "comboBox_InsuranceTypeAfter";
            comboBox_InsuranceTypeAfter.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            comboBox_InsuranceTypeAfter.SelectedIndexChanged += new System.EventHandler(comboBox_InsuranceTypeAfter_SelectedIndexChanged);
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            textBox_Insurance_ClassAfter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(textBox_Insurance_ClassAfter, "textBox_Insurance_ClassAfter");
            textBox_Insurance_ClassAfter.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
            textBox_Insurance_ClassAfter.Name = "textBox_Insurance_ClassAfter";
            resources.ApplyResources(label146, "label146");
            label146.BackColor = System.Drawing.Color.Transparent;
            label146.Name = "label146";
            textBox_Note.BackColor = System.Drawing.Color.AliceBlue;
            textBox_Note.Border.Class = "TextBoxBorder";
            textBox_Note.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            textBox_Note.ButtonCustom.Visible = true;
            textBox_Note.ForeColor = System.Drawing.Color.Black;
            resources.ApplyResources(textBox_Note, "textBox_Note");
            textBox_Note.Name = "textBox_Note";
            textBox_Note.WatermarkColor = System.Drawing.Color.RosyBrown;
            textBox_Note.WatermarkFont = new System.Drawing.Font("Tahoma", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            textBox_Note.WatermarkImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
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
            comboBox_EmpNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            comboBox_EmpNo.DisplayMember = "Text";
            comboBox_EmpNo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            comboBox_EmpNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox_EmpNo.FormattingEnabled = true;
            resources.ApplyResources(comboBox_EmpNo, "comboBox_EmpNo");
            comboBox_EmpNo.Name = "comboBox_EmpNo";
            comboBox_EmpNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            comboBox_EmpNo.SelectedValueChanged += new System.EventHandler(comboBox_EmpNo_SelectedValueChanged);
            button_SrchEmp.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            button_SrchEmp.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            resources.ApplyResources(button_SrchEmp, "button_SrchEmp");
            button_SrchEmp.Name = "button_SrchEmp";
            button_SrchEmp.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            button_SrchEmp.Symbol = "\uf002";
            button_SrchEmp.SymbolSize = 12f;
            button_SrchEmp.TextColor = System.Drawing.Color.SteelBlue;
            button_SrchEmp.Click += new System.EventHandler(button_SrchEmp_Click);
            resources.ApplyResources(label12, "label12");
            label12.Name = "label12";
            resources.ApplyResources(dateTimeInput_warnDate, "dateTimeInput_warnDate");
            dateTimeInput_warnDate.Name = "dateTimeInput_warnDate";
            dateTimeInput_warnDate.Leave += new System.EventHandler(dateTimeInput_warnDate_Leave);
            dateTimeInput_warnDate.Click += new System.EventHandler(dateTimeInput_warnDate_Click);
            resources.ApplyResources(label54, "label54");
            label54.BackColor = System.Drawing.Color.Transparent;
            label54.Name = "label54";
            textBox_EmpNo.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
            textBox_EmpNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(textBox_EmpNo, "textBox_EmpNo");
            textBox_EmpNo.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
            textBox_EmpNo.Name = "textBox_EmpNo";
            textBox_EmpNo.ReadOnly = true;
            resources.ApplyResources(label38, "label38");
            label38.BackColor = System.Drawing.Color.Transparent;
            label38.Name = "label38";
            resources.ApplyResources(this, "$this");
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            base.Controls.Add(ribbonBar1);
            base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            base.KeyPreview = true;
            base.MaximizeBox = false;
            base.Name = "FrmUpdateDocAllownc";
            base.Load += new System.EventHandler(FrmUpdateDocAllownc_Load);
            base.KeyPress += new System.Windows.Forms.KeyPressEventHandler(FrmAdd_KeyPress);
            base.KeyDown += new System.Windows.Forms.KeyEventHandler(FrmAdd_KeyDown);
            ribbonBar1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            groupPanel_Now.ResumeLayout(false);
            groupPanel_Now.PerformLayout();
            groupPanel_After.ResumeLayout(false);
            groupPanel_After.PerformLayout();
            ResumeLayout(false);
        }//###########&&&&&&&&&&

}
}
