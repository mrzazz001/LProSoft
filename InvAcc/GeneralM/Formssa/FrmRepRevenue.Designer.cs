   

namespace InvAcc.Forms
{
partial class FrmRepRevenue
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InvAcc.Forms.FrmRepRevenue));
            ribbonBar1 = new DevComponents.DotNetBar.RibbonBar();
            panel1 = new System.Windows.Forms.Panel();
            txtUserName = new System.Windows.Forms.TextBox();
            txtUserNo = new System.Windows.Forms.TextBox();
            label9 = new System.Windows.Forms.Label();
            button_SrchUsrNo = new DevComponents.DotNetBar.ButtonX();
            comboBox_AdvancStatus = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            label2 = new System.Windows.Forms.Label();
            groupBox1 = new System.Windows.Forms.GroupBox();
            textBox_Time2 = new System.Windows.Forms.MaskedTextBox();
            textBox_Time = new System.Windows.Forms.MaskedTextBox();
            groupBox_AmPm = new System.Windows.Forms.GroupBox();
            RadioBox_AllowPM = new DevComponents.DotNetBar.Controls.CheckBoxX();
            checkBoxX1 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            RadioBox_AllowAM = new DevComponents.DotNetBar.Controls.CheckBoxX();
            label1 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            groupBox2 = new System.Windows.Forms.GroupBox();
            RadioBox_AllowPM2 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            checkBoxX3 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            RadioBox_AllowAM2 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            ButExit = new DevComponents.DotNetBar.ButtonX();
            ButOk = new DevComponents.DotNetBar.ButtonX();
            groupBox_Date = new System.Windows.Forms.GroupBox();
            dateTimeInput_StartAdvancTo = new System.Windows.Forms.MaskedTextBox();
            dateTimeInput_StartAdvancFrom = new System.Windows.Forms.MaskedTextBox();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            groupBox_9_10 = new System.Windows.Forms.GroupBox();
            checkBox_Leave = new DevComponents.DotNetBar.Controls.CheckBoxX();
            checkBox_Stay = new DevComponents.DotNetBar.Controls.CheckBoxX();
            ribbonBar1.SuspendLayout();
            panel1.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox_AmPm.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox_Date.SuspendLayout();
            groupBox_9_10.SuspendLayout();
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
            panel1.Controls.Add(txtUserName);
            panel1.Controls.Add(txtUserNo);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(button_SrchUsrNo);
            panel1.Controls.Add(comboBox_AdvancStatus);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(groupBox1);
            panel1.Controls.Add(ButExit);
            panel1.Controls.Add(ButOk);
            panel1.Controls.Add(groupBox_Date);
            panel1.Controls.Add(groupBox_9_10);
            panel1.Font = null;
            panel1.Name = "panel1";
            txtUserName.AccessibleDescription = null;
            txtUserName.AccessibleName = null;
            resources.ApplyResources(txtUserName, "txtUserName");
            txtUserName.BackColor = System.Drawing.Color.DarkSeaGreen;
            txtUserName.BackgroundImage = null;
            txtUserName.Font = null;
            txtUserName.ForeColor = System.Drawing.Color.White;
            txtUserName.Name = "txtUserName";
            txtUserName.ReadOnly = true;
            txtUserNo.AccessibleDescription = null;
            txtUserNo.AccessibleName = null;
            resources.ApplyResources(txtUserNo, "txtUserNo");
            txtUserNo.BackColor = System.Drawing.Color.White;
            txtUserNo.BackgroundImage = null;
            txtUserNo.Font = null;
            txtUserNo.Name = "txtUserNo";
            txtUserNo.ReadOnly = true;
            txtUserNo.Tag = " T_GDHEAD.gdUser";
            label9.AccessibleDescription = null;
            label9.AccessibleName = null;
            resources.ApplyResources(label9, "label9");
            label9.BackColor = System.Drawing.Color.Transparent;
            label9.Name = "label9";
            button_SrchUsrNo.AccessibleDescription = null;
            button_SrchUsrNo.AccessibleName = null;
            button_SrchUsrNo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            resources.ApplyResources(button_SrchUsrNo, "button_SrchUsrNo");
            button_SrchUsrNo.BackgroundImage = null;
            button_SrchUsrNo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            button_SrchUsrNo.CommandParameter = null;
            button_SrchUsrNo.Font = null;
            button_SrchUsrNo.Name = "button_SrchUsrNo";
            button_SrchUsrNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            button_SrchUsrNo.Symbol = "\uf002";
            button_SrchUsrNo.SymbolSize = 12f;
            button_SrchUsrNo.TextColor = System.Drawing.Color.SteelBlue;
            button_SrchUsrNo.Click += new System.EventHandler(button_SrchUsrNo_Click);
            comboBox_AdvancStatus.AccessibleDescription = null;
            comboBox_AdvancStatus.AccessibleName = null;
            resources.ApplyResources(comboBox_AdvancStatus, "comboBox_AdvancStatus");
            comboBox_AdvancStatus.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            comboBox_AdvancStatus.BackgroundImage = null;
            comboBox_AdvancStatus.CommandParameter = null;
            comboBox_AdvancStatus.DisplayMember = "Text";
            comboBox_AdvancStatus.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            comboBox_AdvancStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox_AdvancStatus.Font = null;
            comboBox_AdvancStatus.FormattingEnabled = true;
            comboBox_AdvancStatus.Name = "comboBox_AdvancStatus";
            comboBox_AdvancStatus.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            comboBox_AdvancStatus.SelectedIndexChanged += new System.EventHandler(comboBox_AdvancStatus_SelectedIndexChanged);
            label2.AccessibleDescription = null;
            label2.AccessibleName = null;
            resources.ApplyResources(label2, "label2");
            label2.BackColor = System.Drawing.Color.Transparent;
            label2.Name = "label2";
            groupBox1.AccessibleDescription = null;
            groupBox1.AccessibleName = null;
            resources.ApplyResources(groupBox1, "groupBox1");
            groupBox1.BackColor = System.Drawing.Color.Transparent;
            groupBox1.BackgroundImage = null;
            groupBox1.Controls.Add(textBox_Time2);
            groupBox1.Controls.Add(textBox_Time);
            groupBox1.Controls.Add(groupBox_AmPm);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(groupBox2);
            groupBox1.Name = "groupBox1";
            groupBox1.TabStop = false;
            textBox_Time2.AccessibleDescription = null;
            textBox_Time2.AccessibleName = null;
            resources.ApplyResources(textBox_Time2, "textBox_Time2");
            textBox_Time2.BackColor = System.Drawing.Color.Maroon;
            textBox_Time2.BackgroundImage = null;
            textBox_Time2.ForeColor = System.Drawing.Color.White;
            textBox_Time2.Name = "textBox_Time2";
            textBox_Time2.Leave += new System.EventHandler(textBox_Time2_Leave);
            textBox_Time2.Click += new System.EventHandler(textBox_Time2_Click);
            textBox_Time.AccessibleDescription = null;
            textBox_Time.AccessibleName = null;
            resources.ApplyResources(textBox_Time, "textBox_Time");
            textBox_Time.BackColor = System.Drawing.Color.Maroon;
            textBox_Time.BackgroundImage = null;
            textBox_Time.ForeColor = System.Drawing.Color.White;
            textBox_Time.Name = "textBox_Time";
            textBox_Time.Leave += new System.EventHandler(textBox_Time_Leave);
            textBox_Time.Click += new System.EventHandler(textBox_Time_Click);
            groupBox_AmPm.AccessibleDescription = null;
            groupBox_AmPm.AccessibleName = null;
            resources.ApplyResources(groupBox_AmPm, "groupBox_AmPm");
            groupBox_AmPm.BackColor = System.Drawing.Color.Transparent;
            groupBox_AmPm.BackgroundImage = null;
            groupBox_AmPm.Controls.Add(RadioBox_AllowPM);
            groupBox_AmPm.Controls.Add(checkBoxX1);
            groupBox_AmPm.Controls.Add(RadioBox_AllowAM);
            groupBox_AmPm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            groupBox_AmPm.ForeColor = System.Drawing.Color.FromArgb(128, 64, 64);
            groupBox_AmPm.Name = "groupBox_AmPm";
            groupBox_AmPm.TabStop = false;
            RadioBox_AllowPM.AccessibleDescription = null;
            RadioBox_AllowPM.AccessibleName = null;
            resources.ApplyResources(RadioBox_AllowPM, "RadioBox_AllowPM");
            RadioBox_AllowPM.BackColor = System.Drawing.Color.Transparent;
            RadioBox_AllowPM.BackgroundImage = null;
            RadioBox_AllowPM.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            RadioBox_AllowPM.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            RadioBox_AllowPM.CheckSignSize = new System.Drawing.Size(14, 14);
            RadioBox_AllowPM.CommandParameter = null;
            RadioBox_AllowPM.Name = "RadioBox_AllowPM";
            RadioBox_AllowPM.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            checkBoxX1.AccessibleDescription = null;
            checkBoxX1.AccessibleName = null;
            resources.ApplyResources(checkBoxX1, "checkBoxX1");
            checkBoxX1.BackColor = System.Drawing.Color.Transparent;
            checkBoxX1.BackgroundImage = null;
            checkBoxX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            checkBoxX1.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            checkBoxX1.CheckSignSize = new System.Drawing.Size(14, 14);
            checkBoxX1.CommandParameter = null;
            checkBoxX1.Name = "checkBoxX1";
            checkBoxX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            RadioBox_AllowAM.AccessibleDescription = null;
            RadioBox_AllowAM.AccessibleName = null;
            resources.ApplyResources(RadioBox_AllowAM, "RadioBox_AllowAM");
            RadioBox_AllowAM.BackColor = System.Drawing.Color.Transparent;
            RadioBox_AllowAM.BackgroundImage = null;
            RadioBox_AllowAM.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            RadioBox_AllowAM.BackgroundStyle.TextShadowColor = System.Drawing.SystemColors.ControlLight;
            RadioBox_AllowAM.BackgroundStyle.TextShadowOffset = new System.Drawing.Point(3, 3);
            RadioBox_AllowAM.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            RadioBox_AllowAM.Checked = true;
            RadioBox_AllowAM.CheckSignSize = new System.Drawing.Size(14, 14);
            RadioBox_AllowAM.CheckState = System.Windows.Forms.CheckState.Checked;
            RadioBox_AllowAM.CheckValue = "Y";
            RadioBox_AllowAM.CommandParameter = null;
            RadioBox_AllowAM.Name = "RadioBox_AllowAM";
            RadioBox_AllowAM.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            label1.AccessibleDescription = null;
            label1.AccessibleName = null;
            resources.ApplyResources(label1, "label1");
            label1.BackColor = System.Drawing.Color.Transparent;
            label1.Name = "label1";
            label5.AccessibleDescription = null;
            label5.AccessibleName = null;
            resources.ApplyResources(label5, "label5");
            label5.BackColor = System.Drawing.Color.Transparent;
            label5.Name = "label5";
            groupBox2.AccessibleDescription = null;
            groupBox2.AccessibleName = null;
            resources.ApplyResources(groupBox2, "groupBox2");
            groupBox2.BackColor = System.Drawing.Color.Transparent;
            groupBox2.BackgroundImage = null;
            groupBox2.Controls.Add(RadioBox_AllowPM2);
            groupBox2.Controls.Add(checkBoxX3);
            groupBox2.Controls.Add(RadioBox_AllowAM2);
            groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            groupBox2.ForeColor = System.Drawing.Color.FromArgb(128, 64, 64);
            groupBox2.Name = "groupBox2";
            groupBox2.TabStop = false;
            RadioBox_AllowPM2.AccessibleDescription = null;
            RadioBox_AllowPM2.AccessibleName = null;
            resources.ApplyResources(RadioBox_AllowPM2, "RadioBox_AllowPM2");
            RadioBox_AllowPM2.BackColor = System.Drawing.Color.Transparent;
            RadioBox_AllowPM2.BackgroundImage = null;
            RadioBox_AllowPM2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            RadioBox_AllowPM2.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            RadioBox_AllowPM2.Checked = true;
            RadioBox_AllowPM2.CheckSignSize = new System.Drawing.Size(14, 14);
            RadioBox_AllowPM2.CheckState = System.Windows.Forms.CheckState.Checked;
            RadioBox_AllowPM2.CheckValue = "Y";
            RadioBox_AllowPM2.CommandParameter = null;
            RadioBox_AllowPM2.Name = "RadioBox_AllowPM2";
            RadioBox_AllowPM2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            checkBoxX3.AccessibleDescription = null;
            checkBoxX3.AccessibleName = null;
            resources.ApplyResources(checkBoxX3, "checkBoxX3");
            checkBoxX3.BackColor = System.Drawing.Color.Transparent;
            checkBoxX3.BackgroundImage = null;
            checkBoxX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            checkBoxX3.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            checkBoxX3.CheckSignSize = new System.Drawing.Size(14, 14);
            checkBoxX3.CommandParameter = null;
            checkBoxX3.Name = "checkBoxX3";
            checkBoxX3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            RadioBox_AllowAM2.AccessibleDescription = null;
            RadioBox_AllowAM2.AccessibleName = null;
            resources.ApplyResources(RadioBox_AllowAM2, "RadioBox_AllowAM2");
            RadioBox_AllowAM2.BackColor = System.Drawing.Color.Transparent;
            RadioBox_AllowAM2.BackgroundImage = null;
            RadioBox_AllowAM2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            RadioBox_AllowAM2.BackgroundStyle.TextShadowColor = System.Drawing.SystemColors.ControlLight;
            RadioBox_AllowAM2.BackgroundStyle.TextShadowOffset = new System.Drawing.Point(3, 3);
            RadioBox_AllowAM2.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            RadioBox_AllowAM2.CheckSignSize = new System.Drawing.Size(14, 14);
            RadioBox_AllowAM2.CommandParameter = null;
            RadioBox_AllowAM2.Name = "RadioBox_AllowAM2";
            RadioBox_AllowAM2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            ButExit.AccessibleDescription = null;
            ButExit.AccessibleName = null;
            ButExit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            resources.ApplyResources(ButExit, "ButExit");
            ButExit.BackgroundImage = null;
            ButExit.Checked = true;
            ButExit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            ButExit.CommandParameter = null;
            ButExit.Name = "ButExit";
            ButExit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            ButExit.Symbol = "\uf011";
            ButExit.SymbolSize = 16f;
            ButExit.TextColor = System.Drawing.Color.Black;
            ButExit.Click += new System.EventHandler(ButExit_Click);
            ButOk.AccessibleDescription = null;
            ButOk.AccessibleName = null;
            ButOk.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            resources.ApplyResources(ButOk, "ButOk");
            ButOk.BackgroundImage = null;
            ButOk.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            ButOk.CommandParameter = null;
            ButOk.Name = "ButOk";
            ButOk.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            ButOk.Symbol = "\uf0c5";
            ButOk.SymbolSize = 16f;
            ButOk.TextColor = System.Drawing.Color.White;
            ButOk.Click += new System.EventHandler(ButOk_Click);
            groupBox_Date.AccessibleDescription = null;
            groupBox_Date.AccessibleName = null;
            resources.ApplyResources(groupBox_Date, "groupBox_Date");
            groupBox_Date.BackColor = System.Drawing.Color.Transparent;
            groupBox_Date.BackgroundImage = null;
            groupBox_Date.Controls.Add(dateTimeInput_StartAdvancTo);
            groupBox_Date.Controls.Add(dateTimeInput_StartAdvancFrom);
            groupBox_Date.Controls.Add(label3);
            groupBox_Date.Controls.Add(label4);
            groupBox_Date.Name = "groupBox_Date";
            groupBox_Date.TabStop = false;
            dateTimeInput_StartAdvancTo.AccessibleDescription = null;
            dateTimeInput_StartAdvancTo.AccessibleName = null;
            resources.ApplyResources(dateTimeInput_StartAdvancTo, "dateTimeInput_StartAdvancTo");
            dateTimeInput_StartAdvancTo.BackgroundImage = null;
            dateTimeInput_StartAdvancTo.Font = null;
            dateTimeInput_StartAdvancTo.Name = "dateTimeInput_StartAdvancTo";
            dateTimeInput_StartAdvancTo.Leave += new System.EventHandler(dateTimeInput_StartAdvancTo_Leave);
            dateTimeInput_StartAdvancTo.Click += new System.EventHandler(dateTimeInput_StartAdvancTo_Click);
            dateTimeInput_StartAdvancFrom.AccessibleDescription = null;
            dateTimeInput_StartAdvancFrom.AccessibleName = null;
            resources.ApplyResources(dateTimeInput_StartAdvancFrom, "dateTimeInput_StartAdvancFrom");
            dateTimeInput_StartAdvancFrom.BackgroundImage = null;
            dateTimeInput_StartAdvancFrom.Font = null;
            dateTimeInput_StartAdvancFrom.Name = "dateTimeInput_StartAdvancFrom";
            dateTimeInput_StartAdvancFrom.Leave += new System.EventHandler(dateTimeInput_StartAdvancFrom_Leave);
            dateTimeInput_StartAdvancFrom.Click += new System.EventHandler(dateTimeInput_StartAdvancFrom_Click);
            label3.AccessibleDescription = null;
            label3.AccessibleName = null;
            resources.ApplyResources(label3, "label3");
            label3.BackColor = System.Drawing.Color.Transparent;
            label3.Name = "label3";
            label4.AccessibleDescription = null;
            label4.AccessibleName = null;
            resources.ApplyResources(label4, "label4");
            label4.BackColor = System.Drawing.Color.Transparent;
            label4.Name = "label4";
            groupBox_9_10.AccessibleDescription = null;
            groupBox_9_10.AccessibleName = null;
            resources.ApplyResources(groupBox_9_10, "groupBox_9_10");
            groupBox_9_10.BackColor = System.Drawing.Color.Transparent;
            groupBox_9_10.BackgroundImage = null;
            groupBox_9_10.Controls.Add(checkBox_Leave);
            groupBox_9_10.Controls.Add(checkBox_Stay);
            groupBox_9_10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            groupBox_9_10.ForeColor = System.Drawing.Color.FromArgb(128, 64, 64);
            groupBox_9_10.Name = "groupBox_9_10";
            groupBox_9_10.TabStop = false;
            checkBox_Leave.AccessibleDescription = null;
            checkBox_Leave.AccessibleName = null;
            resources.ApplyResources(checkBox_Leave, "checkBox_Leave");
            checkBox_Leave.BackColor = System.Drawing.Color.Transparent;
            checkBox_Leave.BackgroundImage = null;
            checkBox_Leave.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            checkBox_Leave.CheckBoxPosition = DevComponents.DotNetBar.eCheckBoxPosition.Top;
            checkBox_Leave.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            checkBox_Leave.CheckSignSize = new System.Drawing.Size(14, 14);
            checkBox_Leave.CommandParameter = null;
            checkBox_Leave.Name = "checkBox_Leave";
            checkBox_Leave.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            checkBox_Leave.TextColor = System.Drawing.Color.FromArgb(192, 0, 0);
            checkBox_Leave.CheckedChanged += new System.EventHandler(checkBox_Stay_CheckedChanged);
            checkBox_Stay.AccessibleDescription = null;
            checkBox_Stay.AccessibleName = null;
            resources.ApplyResources(checkBox_Stay, "checkBox_Stay");
            checkBox_Stay.BackColor = System.Drawing.Color.Transparent;
            checkBox_Stay.BackgroundImage = null;
            checkBox_Stay.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            checkBox_Stay.BackgroundStyle.TextShadowColor = System.Drawing.SystemColors.ControlLight;
            checkBox_Stay.BackgroundStyle.TextShadowOffset = new System.Drawing.Point(3, 3);
            checkBox_Stay.CheckBoxPosition = DevComponents.DotNetBar.eCheckBoxPosition.Top;
            checkBox_Stay.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            checkBox_Stay.Checked = true;
            checkBox_Stay.CheckSignSize = new System.Drawing.Size(14, 14);
            checkBox_Stay.CheckState = System.Windows.Forms.CheckState.Checked;
            checkBox_Stay.CheckValue = "Y";
            checkBox_Stay.CommandParameter = null;
            checkBox_Stay.Name = "checkBox_Stay";
            checkBox_Stay.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            checkBox_Stay.TextColor = System.Drawing.Color.FromArgb(192, 0, 0);
            checkBox_Stay.CheckedChanged += new System.EventHandler(checkBox_Stay_CheckedChanged);
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
            base.Name = "FrmRepRevenue";
            base.Load += new System.EventHandler(FrmRepRevenue_Load);
            base.KeyPress += new System.Windows.Forms.KeyPressEventHandler(FrmRepRevenue_KeyPress);
            base.KeyDown += new System.Windows.Forms.KeyEventHandler(FrmRepRevenue_KeyDown);
            ribbonBar1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox_AmPm.ResumeLayout(false);
            groupBox_AmPm.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox_Date.ResumeLayout(false);
            groupBox_Date.PerformLayout();
            groupBox_9_10.ResumeLayout(false);
            groupBox_9_10.PerformLayout();
            ResumeLayout(false);
        }//###########&&&&&&&&&&

}
}