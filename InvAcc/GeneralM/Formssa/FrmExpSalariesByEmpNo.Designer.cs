   

namespace InvAcc.Forms
{
partial class FrmExpSalariesByEmpNo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InvAcc.Forms.FrmExpSalariesByEmpNo));
            ribbonBar1 = new DevComponents.DotNetBar.RibbonBar();
            panel1 = new System.Windows.Forms.Panel();
            button_Close = new DevComponents.DotNetBar.ButtonX();
            Button_OK = new DevComponents.DotNetBar.ButtonX();
            groupBox1 = new System.Windows.Forms.GroupBox();
            button_SrchEmp = new DevComponents.DotNetBar.ButtonX();
            label12 = new System.Windows.Forms.Label();
            comboBox_EmpNo = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            label1 = new System.Windows.Forms.Label();
            textBox_DayOfMonth = new DevComponents.Editors.IntegerInput();
            textBox_Date = new System.Windows.Forms.MaskedTextBox();
            label3 = new System.Windows.Forms.Label();
            ribbonBar1.SuspendLayout();
            panel1.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)textBox_DayOfMonth).BeginInit();
            SuspendLayout();
            ribbonBar1.AccessibleDescription = null;
            ribbonBar1.AccessibleName = null;
            resources.ApplyResources(ribbonBar1, "ribbonBar1");
            ribbonBar1.AutoOverflowEnabled = true;
            ribbonBar1.BackgroundImage = null;
            ribbonBar1.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            ribbonBar1.BackgroundStyle.BackColor = System.Drawing.Color.AliceBlue;
            ribbonBar1.BackgroundStyle.BackColor2 = System.Drawing.SystemColors.GradientActiveCaption;
            ribbonBar1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            ribbonBar1.ContainerControlProcessDialogKey = true;
            ribbonBar1.Controls.Add(panel1);
            ribbonBar1.Font = null;
            ribbonBar1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            ribbonBar1.Name = "ribbonBar1";
            ribbonBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            ribbonBar1.TitleStyle.BackColor = System.Drawing.Color.FromArgb(227, 239, 255);
            ribbonBar1.TitleStyle.BackColor2 = System.Drawing.Color.FromArgb(101, 147, 207);
            ribbonBar1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            ribbonBar1.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            panel1.AccessibleDescription = null;
            panel1.AccessibleName = null;
            resources.ApplyResources(panel1, "panel1");
            panel1.BackColor = System.Drawing.Color.Transparent;
            panel1.BackgroundImage = null;
            panel1.Controls.Add(button_Close);
            panel1.Controls.Add(Button_OK);
            panel1.Controls.Add(groupBox1);
            panel1.Font = null;
            panel1.Name = "panel1";
            button_Close.AccessibleDescription = null;
            button_Close.AccessibleName = null;
            button_Close.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            resources.ApplyResources(button_Close, "button_Close");
            button_Close.BackgroundImage = null;
            button_Close.Checked = true;
            button_Close.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            button_Close.CommandParameter = null;
            button_Close.Name = "button_Close";
            button_Close.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            button_Close.Symbol = "\uf011";
            button_Close.SymbolSize = 16f;
            button_Close.TextColor = System.Drawing.Color.Black;
            button_Close.Click += new System.EventHandler(button_Close_Click);
            Button_OK.AccessibleDescription = null;
            Button_OK.AccessibleName = null;
            Button_OK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            resources.ApplyResources(Button_OK, "Button_OK");
            Button_OK.BackgroundImage = null;
            Button_OK.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            Button_OK.CommandParameter = null;
            Button_OK.Name = "Button_OK";
            Button_OK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            Button_OK.Symbol = "\uf00c";
            Button_OK.SymbolSize = 16f;
            Button_OK.TextColor = System.Drawing.Color.White;
            Button_OK.Click += new System.EventHandler(Button_OK_Click);
            groupBox1.AccessibleDescription = null;
            groupBox1.AccessibleName = null;
            resources.ApplyResources(groupBox1, "groupBox1");
            groupBox1.BackgroundImage = null;
            groupBox1.Controls.Add(button_SrchEmp);
            groupBox1.Controls.Add(label12);
            groupBox1.Controls.Add(comboBox_EmpNo);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(textBox_DayOfMonth);
            groupBox1.Controls.Add(textBox_Date);
            groupBox1.Controls.Add(label3);
            groupBox1.Name = "groupBox1";
            groupBox1.TabStop = false;
            button_SrchEmp.AccessibleDescription = null;
            button_SrchEmp.AccessibleName = null;
            button_SrchEmp.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            resources.ApplyResources(button_SrchEmp, "button_SrchEmp");
            button_SrchEmp.BackgroundImage = null;
            button_SrchEmp.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            button_SrchEmp.CommandParameter = null;
            button_SrchEmp.Font = null;
            button_SrchEmp.Name = "button_SrchEmp";
            button_SrchEmp.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            button_SrchEmp.Symbol = "\uf002";
            button_SrchEmp.SymbolSize = 12f;
            button_SrchEmp.TextColor = System.Drawing.Color.SteelBlue;
            button_SrchEmp.Click += new System.EventHandler(button_SrchEmp_Click);
            label12.AccessibleDescription = null;
            label12.AccessibleName = null;
            resources.ApplyResources(label12, "label12");
            label12.Name = "label12";
            comboBox_EmpNo.AccessibleDescription = null;
            comboBox_EmpNo.AccessibleName = null;
            resources.ApplyResources(comboBox_EmpNo, "comboBox_EmpNo");
            comboBox_EmpNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            comboBox_EmpNo.BackgroundImage = null;
            comboBox_EmpNo.CommandParameter = null;
            comboBox_EmpNo.DisplayMember = "Text";
            comboBox_EmpNo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            comboBox_EmpNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox_EmpNo.Font = null;
            comboBox_EmpNo.FormattingEnabled = true;
            comboBox_EmpNo.Name = "comboBox_EmpNo";
            comboBox_EmpNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            label1.AccessibleDescription = null;
            label1.AccessibleName = null;
            resources.ApplyResources(label1, "label1");
            label1.BackColor = System.Drawing.Color.Transparent;
            label1.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            label1.Name = "label1";
            textBox_DayOfMonth.AccessibleDescription = null;
            textBox_DayOfMonth.AccessibleName = null;
            textBox_DayOfMonth.AllowEmptyState = false;
            resources.ApplyResources(textBox_DayOfMonth, "textBox_DayOfMonth");
            textBox_DayOfMonth.BackgroundImage = null;
            textBox_DayOfMonth.BackgroundStyle.Class = "DateTimeInputBackground";
            textBox_DayOfMonth.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            textBox_DayOfMonth.ButtonCalculator.DisplayPosition = (int)resources.GetObject("textBox_DayOfMonth.ButtonCalculator.DisplayPosition");
            textBox_DayOfMonth.ButtonCalculator.Image = null;
            textBox_DayOfMonth.ButtonCalculator.Text = resources.GetString("textBox_DayOfMonth.ButtonCalculator.Text");
            textBox_DayOfMonth.ButtonClear.DisplayPosition = (int)resources.GetObject("textBox_DayOfMonth.ButtonClear.DisplayPosition");
            textBox_DayOfMonth.ButtonClear.Image = null;
            textBox_DayOfMonth.ButtonClear.Text = resources.GetString("textBox_DayOfMonth.ButtonClear.Text");
            textBox_DayOfMonth.ButtonCustom.DisplayPosition = (int)resources.GetObject("textBox_DayOfMonth.ButtonCustom.DisplayPosition");
            textBox_DayOfMonth.ButtonCustom.Image = null;
            textBox_DayOfMonth.ButtonCustom.Text = resources.GetString("textBox_DayOfMonth.ButtonCustom.Text");
            textBox_DayOfMonth.ButtonCustom2.DisplayPosition = (int)resources.GetObject("textBox_DayOfMonth.ButtonCustom2.DisplayPosition");
            textBox_DayOfMonth.ButtonCustom2.Image = null;
            textBox_DayOfMonth.ButtonCustom2.Text = resources.GetString("textBox_DayOfMonth.ButtonCustom2.Text");
            textBox_DayOfMonth.ButtonDropDown.DisplayPosition = (int)resources.GetObject("textBox_DayOfMonth.ButtonDropDown.DisplayPosition");
            textBox_DayOfMonth.ButtonDropDown.Image = null;
            textBox_DayOfMonth.ButtonDropDown.Text = resources.GetString("textBox_DayOfMonth.ButtonDropDown.Text");
            textBox_DayOfMonth.ButtonFreeText.DisplayPosition = (int)resources.GetObject("textBox_DayOfMonth.ButtonFreeText.DisplayPosition");
            textBox_DayOfMonth.ButtonFreeText.Image = null;
            textBox_DayOfMonth.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            textBox_DayOfMonth.ButtonFreeText.Text = resources.GetString("textBox_DayOfMonth.ButtonFreeText.Text");
            textBox_DayOfMonth.CommandParameter = null;
            textBox_DayOfMonth.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            textBox_DayOfMonth.MaxValue = 31;
            textBox_DayOfMonth.MinValue = 1;
            textBox_DayOfMonth.Name = "textBox_DayOfMonth";
            textBox_DayOfMonth.Value = 1;
            textBox_Date.AccessibleDescription = null;
            textBox_Date.AccessibleName = null;
            resources.ApplyResources(textBox_Date, "textBox_Date");
            textBox_Date.BackColor = System.Drawing.Color.Red;
            textBox_Date.BackgroundImage = null;
            textBox_Date.ForeColor = System.Drawing.Color.White;
            textBox_Date.Name = "textBox_Date";
            textBox_Date.Leave += new System.EventHandler(textBox_Date_Leave);
            textBox_Date.TextChanged += new System.EventHandler(textBox_Date_TextChanged);
            textBox_Date.Click += new System.EventHandler(textBox_Date_Click);
            label3.AccessibleDescription = null;
            label3.AccessibleName = null;
            resources.ApplyResources(label3, "label3");
            label3.BackColor = System.Drawing.Color.Transparent;
            label3.Name = "label3";
            base.AccessibleDescription = null;
            base.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackgroundImage = null;
            base.Controls.Add(ribbonBar1);
            Font = null;
            base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            base.KeyPreview = true;
            base.MaximizeBox = false;
            base.Name = "FrmExpSalariesByEmpNo";
            base.Load += new System.EventHandler(FrmExpSalariesByEmpNo_Load);
            base.KeyPress += new System.Windows.Forms.KeyPressEventHandler(FrmExpSalariesByEmpNo_KeyPress);
            base.KeyDown += new System.Windows.Forms.KeyEventHandler(FrmExpSalariesByEmpNo_KeyDown);
            ribbonBar1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)textBox_DayOfMonth).EndInit();
            ResumeLayout(false);
        }//###########&&&&&&&&&&

}
}
