   

namespace InvAcc.Forms
{
partial class FrmUpdateDoc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InvAcc.Forms.FrmUpdateDoc));
            this.PanelSpecialContainer = new System.Windows.Forms.Panel();

            components = new System.ComponentModel.Container();

            ribbonBar1 = new DevComponents.DotNetBar.RibbonBar();
            panel1 = new System.Windows.Forms.Panel();
            ButCompany = new DevComponents.DotNetBar.ButtonX();
            textBox_Note = new DevComponents.DotNetBar.Controls.TextBoxX();
            ButExit = new DevComponents.DotNetBar.ButtonX();
            ButOk = new DevComponents.DotNetBar.ButtonX();
            dateTimeInput_ID_DateEndAfter = new System.Windows.Forms.MaskedTextBox();
            label3 = new System.Windows.Forms.Label();
            dateTimeInput_ID_DateEnd = new System.Windows.Forms.MaskedTextBox();
            label2 = new System.Windows.Forms.Label();
            comboBox_DocType = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            label1 = new System.Windows.Forms.Label();
            comboBox_EmpNo = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            button_SrchEmp = new DevComponents.DotNetBar.ButtonX();
            label12 = new System.Windows.Forms.Label();
            dateTimeInput_warnDate = new System.Windows.Forms.MaskedTextBox();
            label54 = new System.Windows.Forms.Label();
            textBox_EmpNo = new System.Windows.Forms.TextBox();
            label38 = new System.Windows.Forms.Label();
            this.netResize1 = new Softgroup.NetResize.NetResize(this.components);  this.netResize1.LabelsAutoEllipse = false;
            this.netResize1.AfterControlResize += new Softgroup.NetResize.NetResize.AfterControlResizeEventHandler(this.netResize1_AfterControlResize);
            this.Shown += new System.EventHandler(this.FrmInvSale_Shown);
            this.SizeChanged += new System.EventHandler(this.FrmInvSale_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).BeginInit();

            ribbonBar1.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            ribbonBar1.AutoOverflowEnabled = true;
            ribbonBar1.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            ribbonBar1.BackgroundStyle.BackColor = System.Drawing.Color.AliceBlue;
            ribbonBar1.BackgroundStyle.BackColor2 = System.Drawing.SystemColors.GradientActiveCaption;
            ribbonBar1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            ribbonBar1.ContainerControlProcessDialogKey = true;
            ribbonBar1.Controls.Add(panel1);
            resources.ApplyResources(ribbonBar1, "ribbonBar1");
          // ribbonBar1.Tag= "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            ribbonBar1.Name = "ribbonBar1";
            ribbonBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            ribbonBar1.TitleStyle.BackColor = System.Drawing.Color.FromArgb(227, 239, 255);
            ribbonBar1.TitleStyle.BackColor2 = System.Drawing.Color.FromArgb(101, 147, 207);
            ribbonBar1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            ribbonBar1.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            panel1.BackColor = System.Drawing.Color.Transparent;
            panel1.Controls.Add(ButCompany);
            panel1.Controls.Add(textBox_Note);
            panel1.Controls.Add(ButExit);
            panel1.Controls.Add(ButOk);
            panel1.Controls.Add(dateTimeInput_ID_DateEndAfter);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(dateTimeInput_ID_DateEnd);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(comboBox_DocType);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(comboBox_EmpNo);
            panel1.Controls.Add(button_SrchEmp);
            panel1.Controls.Add(label12);
            panel1.Controls.Add(dateTimeInput_warnDate);
            panel1.Controls.Add(label54);
            panel1.Controls.Add(textBox_EmpNo);
            panel1.Controls.Add(label38);
            resources.ApplyResources(panel1, "panel1");
            panel1.Name = "panel1";
            ButCompany.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            ButCompany.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            resources.ApplyResources(ButCompany, "ButCompany");
            ButCompany.Name = "ButCompany";
            ButCompany.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            ButCompany.Symbol = "\uf002";
            ButCompany.SymbolSize = 9f;
            ButCompany.TextColor = System.Drawing.Color.SteelBlue;
            ButCompany.Click += new System.EventHandler(ButCompany_Click);
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
            resources.ApplyResources(dateTimeInput_ID_DateEndAfter, "dateTimeInput_ID_DateEndAfter");
            dateTimeInput_ID_DateEndAfter.Name = "dateTimeInput_ID_DateEndAfter";
            dateTimeInput_ID_DateEndAfter.Leave += new System.EventHandler(dateTimeInput_ID_DateEndAfter_Leave);
            dateTimeInput_ID_DateEndAfter.Click += new System.EventHandler(dateTimeInput_ID_DateEndAfter_Click);
            resources.ApplyResources(label3, "label3");
            label3.BackColor = System.Drawing.Color.Transparent;
            label3.Name = "label3";
            resources.ApplyResources(dateTimeInput_ID_DateEnd, "dateTimeInput_ID_DateEnd");
            dateTimeInput_ID_DateEnd.Name = "dateTimeInput_ID_DateEnd";
            dateTimeInput_ID_DateEnd.ReadOnly = true;
            dateTimeInput_ID_DateEnd.Click += new System.EventHandler(dateTimeInput_ID_DateEnd_Click);
            resources.ApplyResources(label2, "label2");
            label2.BackColor = System.Drawing.Color.Transparent;
            label2.Name = "label2";
            comboBox_DocType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            comboBox_DocType.DisplayMember = "Text";
            comboBox_DocType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            comboBox_DocType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox_DocType.FormattingEnabled = true;
            resources.ApplyResources(comboBox_DocType, "comboBox_DocType");
            comboBox_DocType.Name = "comboBox_DocType";
            comboBox_DocType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            comboBox_DocType.SelectedIndexChanged += new System.EventHandler(comboBox_DocType_SelectedIndexChanged);
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
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
            base.Name = "FrmUpdateDoc";
            base.Load += new System.EventHandler(FrmUpdateDoc_Load);
            base.KeyPress += new System.Windows.Forms.KeyPressEventHandler(FrmAdd_KeyPress);
            base.KeyDown += new System.Windows.Forms.KeyEventHandler(FrmAdd_KeyDown);
            ribbonBar1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }//###########&&&&&&&&&&

}
}
