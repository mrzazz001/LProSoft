

using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.Editors;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace InvAcc.Forms
{
partial class FrmRelayBoxes
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
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmRelayBoxes));
            this.groupPanel2 = new GroupPanel();
            this.CmbCurr = new ComboBoxEx();
            this.checBox_Acc2 = new CheckBoxX();
            this.checBox_Acc1 = new CheckBoxX();
            this.groupBox2 = new GroupBox();
            this.RButDet = new RadioButton();
            this.RButShort = new RadioButton();
            this.button_RepAccTo = new ButtonX();
            this.button_RepAccFrom = new ButtonX();
            this.txtTime = new MaskedTextBox();
            this.label4 = new Label();
            this.txtGDate = new MaskedTextBox();
            this.txtHDate = new MaskedTextBox();
            this.buttonX_Close = new ButtonX();
            this.ButOk = new ButtonX();
            this.txtAmount = new DoubleInput();
            this.label8 = new Label();
            this.label2 = new Label();
            this.label1 = new Label();
            this.CmbUser = new ComboBoxEx();
            this.label3 = new Label();
            this.CmbFromBox = new ComboBoxEx();
            this.CmbToBox = new ComboBoxEx();
            this.groupPanel_Balance = new GroupPanel();
            this.label_Balance = new Label();
            this.groupPanel_SendOption = new GroupPanel();
            this.chk2 = new CheckBoxX();
            this.chk1 = new CheckBoxX();
            this.groupPanel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((ISupportInitialize)this.txtAmount).BeginInit();
            this.groupPanel_Balance.SuspendLayout();
            this.groupPanel_SendOption.SuspendLayout();
            base.SuspendLayout();
            this.groupPanel2.AccessibleDescription = null;
            this.groupPanel2.AccessibleName = null;
            resources.ApplyResources(this.groupPanel2, "groupPanel2");
            this.groupPanel2.BackColor = Color.Transparent;
            this.groupPanel2.CanvasColor = SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.CmbCurr);
            this.groupPanel2.Controls.Add(this.checBox_Acc2);
            this.groupPanel2.Controls.Add(this.checBox_Acc1);
            this.groupPanel2.Controls.Add(this.groupBox2);
            this.groupPanel2.Controls.Add(this.button_RepAccTo);
            this.groupPanel2.Controls.Add(this.button_RepAccFrom);
            this.groupPanel2.Controls.Add(this.txtTime);
            this.groupPanel2.Controls.Add(this.label4);
            this.groupPanel2.Controls.Add(this.txtGDate);
            this.groupPanel2.Controls.Add(this.txtHDate);
            this.groupPanel2.Controls.Add(this.buttonX_Close);
            this.groupPanel2.Controls.Add(this.ButOk);
            this.groupPanel2.Controls.Add(this.txtAmount);
            this.groupPanel2.Controls.Add(this.label8);
            this.groupPanel2.Controls.Add(this.label2);
            this.groupPanel2.Controls.Add(this.label1);
            this.groupPanel2.Controls.Add(this.CmbUser);
            this.groupPanel2.Controls.Add(this.label3);
            this.groupPanel2.Controls.Add(this.CmbFromBox);
            this.groupPanel2.Controls.Add(this.CmbToBox);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Style.BackColor2 = SystemColors.GradientInactiveCaption;
            this.groupPanel2.Style.BackColorGradientAngle = 90;
            this.groupPanel2.Style.BackColorSchemePart = eColorSchemePart.PanelBackground;
            this.groupPanel2.Style.BorderBottom = eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderBottomWidth = 1;
            this.groupPanel2.Style.BorderColorSchemePart = eColorSchemePart.PanelBorder;
            this.groupPanel2.Style.BorderLeft = eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderLeftWidth = 1;
            this.groupPanel2.Style.BorderRight = eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderRightWidth = 1;
            this.groupPanel2.Style.BorderTop = eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderTopWidth = 1;
            this.groupPanel2.Style.CornerDiameter = 4;
            this.groupPanel2.Style.CornerType = eCornerType.Rounded;
            this.groupPanel2.Style.TextAlignment = eStyleTextAlignment.Center;
            this.groupPanel2.Style.TextColorSchemePart = eColorSchemePart.PanelText;
            this.groupPanel2.StyleMouseDown.CornerType = eCornerType.Square;
            this.groupPanel2.StyleMouseOver.CornerType = eCornerType.Square;
            this.groupPanel2.TitleImagePosition = eTitleImagePosition.Center;
            this.CmbCurr.AccessibleDescription = null;
            this.CmbCurr.AccessibleName = null;
            resources.ApplyResources(this.CmbCurr, "CmbCurr");
            this.CmbCurr.AutoCompleteSource = AutoCompleteSource.ListItems;
            this.CmbCurr.BackgroundImage = null;
            this.CmbCurr.CommandParameter = null;
            this.CmbCurr.DisplayMember = "Text";
            this.CmbCurr.DrawMode = DrawMode.OwnerDrawFixed;
            this.CmbCurr.DropDownStyle = ComboBoxStyle.DropDownList;
            this.CmbCurr.Font = null;
            this.CmbCurr.FormattingEnabled = true;
            this.CmbCurr.Name = "CmbCurr";
            this.CmbCurr.Style = eDotNetBarStyle.StyleManagerControlled;
            this.checBox_Acc2.AccessibleDescription = null;
            this.checBox_Acc2.AccessibleName = null;
            resources.ApplyResources(this.checBox_Acc2, "checBox_Acc2");
            this.checBox_Acc2.BackColor = Color.Transparent;
            this.checBox_Acc2.BackgroundImage = null;
            this.checBox_Acc2.BackgroundStyle.CornerType = eCornerType.Square;
            this.checBox_Acc2.CommandParameter = null;
            this.checBox_Acc2.Name = "checBox_Acc2";
            this.checBox_Acc2.Style = eDotNetBarStyle.StyleManagerControlled;
            this.checBox_Acc2.TextColor = Color.Maroon;
            this.checBox_Acc1.AccessibleDescription = null;
            this.checBox_Acc1.AccessibleName = null;
            resources.ApplyResources(this.checBox_Acc1, "checBox_Acc1");
            this.checBox_Acc1.BackColor = Color.Transparent;
            this.checBox_Acc1.BackgroundImage = null;
            this.checBox_Acc1.BackgroundStyle.CornerType = eCornerType.Square;
            this.checBox_Acc1.CommandParameter = null;
            this.checBox_Acc1.Name = "checBox_Acc1";
            this.checBox_Acc1.Style = eDotNetBarStyle.StyleManagerControlled;
            this.checBox_Acc1.TextColor = Color.Maroon;
            this.groupBox2.AccessibleDescription = null;
            this.groupBox2.AccessibleName = null;
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.BackColor = Color.Transparent;
            this.groupBox2.BackgroundImage = null;
            this.groupBox2.Controls.Add(this.RButDet);
            this.groupBox2.Controls.Add(this.RButShort);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            this.RButDet.AccessibleDescription = null;
            this.RButDet.AccessibleName = null;
            resources.ApplyResources(this.RButDet, "RButDet");
            this.RButDet.BackgroundImage = null;
            this.RButDet.ForeColor = Color.SteelBlue;
            this.RButDet.Name = "RButDet";
            this.RButDet.UseVisualStyleBackColor = true;
            this.RButShort.AccessibleDescription = null;
            this.RButShort.AccessibleName = null;
            resources.ApplyResources(this.RButShort, "RButShort");
            this.RButShort.BackgroundImage = null;
            this.RButShort.Checked = true;
            this.RButShort.ForeColor = Color.SteelBlue;
            this.RButShort.Name = "RButShort";
            this.RButShort.TabStop = true;
            this.RButShort.UseVisualStyleBackColor = true;
            this.button_RepAccTo.AccessibleDescription = null;
            this.button_RepAccTo.AccessibleName = null;
            this.button_RepAccTo.AccessibleRole = AccessibleRole.PushButton;
            resources.ApplyResources(this.button_RepAccTo, "button_RepAccTo");
            this.button_RepAccTo.BackgroundImage = null;
            this.button_RepAccTo.Checked = true;
            this.button_RepAccTo.ColorTable = eButtonColor.Flat;
            this.button_RepAccTo.CommandParameter = null;
            this.button_RepAccTo.Name = "button_RepAccTo";
            this.button_RepAccTo.Style = eDotNetBarStyle.StyleManagerControlled;
            this.button_RepAccTo.Symbol = "";
            this.button_RepAccTo.SymbolSize = 12f;
            this.button_RepAccTo.TextColor = Color.Black;
            this.button_RepAccTo.Click += new EventHandler(this.button_RepAccTo_Click);
            this.button_RepAccFrom.AccessibleDescription = null;
            this.button_RepAccFrom.AccessibleName = null;
            this.button_RepAccFrom.AccessibleRole = AccessibleRole.PushButton;
            resources.ApplyResources(this.button_RepAccFrom, "button_RepAccFrom");
            this.button_RepAccFrom.BackgroundImage = null;
            this.button_RepAccFrom.Checked = true;
            this.button_RepAccFrom.ColorTable = eButtonColor.Flat;
            this.button_RepAccFrom.CommandParameter = null;
            this.button_RepAccFrom.Name = "button_RepAccFrom";
            this.button_RepAccFrom.Style = eDotNetBarStyle.StyleManagerControlled;
            this.button_RepAccFrom.Symbol = "";
            this.button_RepAccFrom.SymbolSize = 12f;
            this.button_RepAccFrom.TextColor = Color.Black;
            this.button_RepAccFrom.Click += new EventHandler(this.button_RepAccFrom_Click);
            this.txtTime.AccessibleDescription = null;
            this.txtTime.AccessibleName = null;
            resources.ApplyResources(this.txtTime, "txtTime");
            this.txtTime.BackColor = Color.White;
            this.txtTime.BackgroundImage = null;
            this.txtTime.Name = "txtTime";
            this.txtTime.Click += new EventHandler(this.txtTime_Click);
            this.label4.AccessibleDescription = null;
            this.label4.AccessibleName = null;
            resources.ApplyResources(this.label4, "label4");
            this.label4.BackColor = Color.Transparent;
            this.label4.FlatStyle = FlatStyle.Flat;
            this.label4.Name = "label4";
            this.txtGDate.AccessibleDescription = null;
            this.txtGDate.AccessibleName = null;
            resources.ApplyResources(this.txtGDate, "txtGDate");
            this.txtGDate.BackColor = Color.WhiteSmoke;
            this.txtGDate.BackgroundImage = null;
            this.txtGDate.Name = "txtGDate";
            this.txtGDate.Leave += new EventHandler(this.txtGDate_Leave);
            this.txtGDate.Click += new EventHandler(this.txtGDate_Click);
            this.txtHDate.AccessibleDescription = null;
            this.txtHDate.AccessibleName = null;
            resources.ApplyResources(this.txtHDate, "txtHDate");
            this.txtHDate.BackColor = Color.WhiteSmoke;
            this.txtHDate.BackgroundImage = null;
            this.txtHDate.Name = "txtHDate";
            this.txtHDate.Leave += new EventHandler(this.txtHDate_Leave);
            this.txtHDate.Click += new EventHandler(this.txtHDate_Click);
            this.buttonX_Close.AccessibleDescription = null;
            this.buttonX_Close.AccessibleName = null;
            this.buttonX_Close.AccessibleRole = AccessibleRole.PushButton;
            resources.ApplyResources(this.buttonX_Close, "buttonX_Close");
            this.buttonX_Close.BackgroundImage = null;
            this.buttonX_Close.Checked = true;
            this.buttonX_Close.ColorTable = eButtonColor.OrangeWithBackground;
            this.buttonX_Close.CommandParameter = null;
            this.buttonX_Close.Name = "buttonX_Close";
            this.buttonX_Close.Style = eDotNetBarStyle.StyleManagerControlled;
            this.buttonX_Close.Symbol = "";
            this.buttonX_Close.TextColor = Color.SteelBlue;
            this.buttonX_Close.Click += new EventHandler(this.buttonX_Close_Click);
            this.ButOk.AccessibleDescription = null;
            this.ButOk.AccessibleName = null;
            this.ButOk.AccessibleRole = AccessibleRole.PushButton;
            resources.ApplyResources(this.ButOk, "ButOk");
            this.ButOk.BackgroundImage = null;
            this.ButOk.ColorTable = eButtonColor.BlueOrb;
            this.ButOk.CommandParameter = null;
            this.ButOk.Name = "ButOk";
            this.ButOk.Style = eDotNetBarStyle.StyleManagerControlled;
            this.ButOk.Symbol = "";
            this.ButOk.SymbolSize = 16f;
            this.ButOk.TextColor = Color.White;
            this.ButOk.Click += new EventHandler(this.ButOk_Click);
            this.txtAmount.AccessibleDescription = null;
            this.txtAmount.AccessibleName = null;
            this.txtAmount.AllowEmptyState = false;
            resources.ApplyResources(this.txtAmount, "txtAmount");
            this.txtAmount.BackgroundImage = null;
            this.txtAmount.BackgroundStyle.BackColor = Color.FromArgb(255, 255, 0);
            this.txtAmount.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtAmount.BackgroundStyle.CornerType = eCornerType.Square;
            this.txtAmount.ButtonCalculator.DisplayPosition = (int)resources.GetObject("txtAmount.ButtonCalculator.DisplayPosition");
            this.txtAmount.ButtonCalculator.Image = null;
            this.txtAmount.ButtonCalculator.Text = resources.GetString("txtAmount.ButtonCalculator.Text");
            this.txtAmount.ButtonClear.DisplayPosition = (int)resources.GetObject("txtAmount.ButtonClear.DisplayPosition");
            this.txtAmount.ButtonClear.Image = null;
            this.txtAmount.ButtonClear.Text = resources.GetString("txtAmount.ButtonClear.Text");
            this.txtAmount.ButtonCustom.DisplayPosition = (int)resources.GetObject("txtAmount.ButtonCustom.DisplayPosition");
            this.txtAmount.ButtonCustom.Image = null;
            this.txtAmount.ButtonCustom.Text = resources.GetString("txtAmount.ButtonCustom.Text");
            this.txtAmount.ButtonCustom2.DisplayPosition = (int)resources.GetObject("txtAmount.ButtonCustom2.DisplayPosition");
            this.txtAmount.ButtonCustom2.Image = null;
            this.txtAmount.ButtonCustom2.Text = resources.GetString("txtAmount.ButtonCustom2.Text");
            this.txtAmount.ButtonDropDown.DisplayPosition = (int)resources.GetObject("txtAmount.ButtonDropDown.DisplayPosition");
            this.txtAmount.ButtonDropDown.Image = null;
            this.txtAmount.ButtonDropDown.Text = resources.GetString("txtAmount.ButtonDropDown.Text");
            this.txtAmount.ButtonFreeText.DisplayPosition = (int)resources.GetObject("txtAmount.ButtonFreeText.DisplayPosition");
            this.txtAmount.ButtonFreeText.Image = null;
            this.txtAmount.ButtonFreeText.Shortcut = eShortcut.F2;
            this.txtAmount.ButtonFreeText.Text = resources.GetString("txtAmount.ButtonFreeText.Text");
            this.txtAmount.CommandParameter = null;
            this.txtAmount.DisplayFormat = "0.00";
            this.txtAmount.Increment = 1;
            this.txtAmount.InputHorizontalAlignment = eHorizontalAlignment.Center;
            this.txtAmount.MinValue = 0;
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.ShowUpDown = true;
            this.label8.AccessibleDescription = null;
            this.label8.AccessibleName = null;
            resources.ApplyResources(this.label8, "label8");
            this.label8.BackColor = Color.SteelBlue;
            this.label8.BorderStyle = BorderStyle.FixedSingle;
            this.label8.ForeColor = Color.White;
            this.label8.Name = "label8";
            this.label2.AccessibleDescription = null;
            this.label2.AccessibleName = null;
            resources.ApplyResources(this.label2, "label2");
            this.label2.BackColor = Color.Transparent;
            this.label2.FlatStyle = FlatStyle.Flat;
            this.label2.Name = "label2";
            this.label1.AccessibleDescription = null;
            this.label1.AccessibleName = null;
            resources.ApplyResources(this.label1, "label1");
            this.label1.Font = null;
            this.label1.Name = "label1";
            this.CmbUser.AccessibleDescription = null;
            this.CmbUser.AccessibleName = null;
            resources.ApplyResources(this.CmbUser, "CmbUser");
            this.CmbUser.AutoCompleteSource = AutoCompleteSource.ListItems;
            this.CmbUser.BackgroundImage = null;
            this.CmbUser.CommandParameter = null;
            this.CmbUser.DisplayMember = "Text";
            this.CmbUser.DrawMode = DrawMode.OwnerDrawFixed;
            this.CmbUser.DropDownStyle = ComboBoxStyle.DropDownList;
            this.CmbUser.Font = null;
            this.CmbUser.FormattingEnabled = true;
            this.CmbUser.Name = "CmbUser";
            this.CmbUser.Style = eDotNetBarStyle.StyleManagerControlled;
            this.label3.AccessibleDescription = null;
            this.label3.AccessibleName = null;
            resources.ApplyResources(this.label3, "label3");
            this.label3.Font = null;
            this.label3.Name = "label3";
            this.CmbFromBox.AccessibleDescription = null;
            this.CmbFromBox.AccessibleName = null;
            resources.ApplyResources(this.CmbFromBox, "CmbFromBox");
            this.CmbFromBox.AutoCompleteSource = AutoCompleteSource.ListItems;
            this.CmbFromBox.BackgroundImage = null;
            this.CmbFromBox.CommandParameter = null;
            this.CmbFromBox.DisplayMember = "Text";
            this.CmbFromBox.DrawMode = DrawMode.OwnerDrawFixed;
            this.CmbFromBox.DropDownStyle = ComboBoxStyle.DropDownList;
            this.CmbFromBox.Font = null;
            this.CmbFromBox.FormattingEnabled = true;
            this.CmbFromBox.Name = "CmbFromBox";
            this.CmbFromBox.Style = eDotNetBarStyle.StyleManagerControlled;
            this.CmbFromBox.Tag = "T_GDDET.AccNo ";
            this.CmbFromBox.SelectedIndexChanged += new EventHandler(this.CmbFromBox_SelectedIndexChanged);
            this.CmbToBox.AccessibleDescription = null;
            this.CmbToBox.AccessibleName = null;
            resources.ApplyResources(this.CmbToBox, "CmbToBox");
            this.CmbToBox.AutoCompleteSource = AutoCompleteSource.ListItems;
            this.CmbToBox.BackgroundImage = null;
            this.CmbToBox.CommandParameter = null;
            this.CmbToBox.DisplayMember = "Text";
            this.CmbToBox.DrawMode = DrawMode.OwnerDrawFixed;
            this.CmbToBox.DropDownStyle = ComboBoxStyle.DropDownList;
            this.CmbToBox.Font = null;
            this.CmbToBox.FormattingEnabled = true;
            this.CmbToBox.Name = "CmbToBox";
            this.CmbToBox.Style = eDotNetBarStyle.StyleManagerControlled;
            this.CmbToBox.Tag = "T_GDDET.AccNo ";
            this.groupPanel_Balance.AccessibleDescription = null;
            this.groupPanel_Balance.AccessibleName = null;
            resources.ApplyResources(this.groupPanel_Balance, "groupPanel_Balance");
            this.groupPanel_Balance.BackColor = Color.Transparent;
            this.groupPanel_Balance.CanvasColor = SystemColors.Control;
            this.groupPanel_Balance.ColorSchemeStyle = eDotNetBarStyle.Office2007;
            this.groupPanel_Balance.Controls.Add(this.label_Balance);
            this.groupPanel_Balance.Name = "groupPanel_Balance";
            this.groupPanel_Balance.Style.BackColor2 = SystemColors.GradientInactiveCaption;
            this.groupPanel_Balance.Style.BackColorGradientAngle = 90;
            this.groupPanel_Balance.Style.BackColorSchemePart = eColorSchemePart.PanelBackground;
            this.groupPanel_Balance.Style.BorderBottom = eStyleBorderType.Solid;
            this.groupPanel_Balance.Style.BorderBottomWidth = 1;
            this.groupPanel_Balance.Style.BorderColorSchemePart = eColorSchemePart.PanelBorder;
            this.groupPanel_Balance.Style.BorderLeft = eStyleBorderType.Solid;
            this.groupPanel_Balance.Style.BorderLeftWidth = 1;
            this.groupPanel_Balance.Style.BorderRight = eStyleBorderType.Solid;
            this.groupPanel_Balance.Style.BorderRightWidth = 1;
            this.groupPanel_Balance.Style.BorderTop = eStyleBorderType.Solid;
            this.groupPanel_Balance.Style.BorderTopWidth = 1;
            this.groupPanel_Balance.Style.CornerDiameter = 4;
            this.groupPanel_Balance.Style.CornerType = eCornerType.Rounded;
            this.groupPanel_Balance.Style.TextAlignment = eStyleTextAlignment.Center;
            this.groupPanel_Balance.Style.TextColorSchemePart = eColorSchemePart.PanelText;
            this.groupPanel_Balance.StyleMouseDown.CornerType = eCornerType.Square;
            this.groupPanel_Balance.StyleMouseOver.CornerType = eCornerType.Square;
            this.groupPanel_Balance.TitleImagePosition = eTitleImagePosition.Right;
            this.label_Balance.AccessibleDescription = null;
            this.label_Balance.AccessibleName = null;
            resources.ApplyResources(this.label_Balance, "label_Balance");
            this.label_Balance.BackColor = Color.WhiteSmoke;
            this.label_Balance.ForeColor = Color.Red;
            this.label_Balance.Name = "label_Balance";
            this.groupPanel_SendOption.AccessibleDescription = null;
            this.groupPanel_SendOption.AccessibleName = null;
            resources.ApplyResources(this.groupPanel_SendOption, "groupPanel_SendOption");
            this.groupPanel_SendOption.BackColor = Color.Transparent;
            this.groupPanel_SendOption.CanvasColor = SystemColors.Control;
            this.groupPanel_SendOption.ColorSchemeStyle = eDotNetBarStyle.Office2007;
            this.groupPanel_SendOption.Controls.Add(this.chk2);
            this.groupPanel_SendOption.Controls.Add(this.chk1);
            this.groupPanel_SendOption.Name = "groupPanel_SendOption";
            this.groupPanel_SendOption.Style.BackColor2 = SystemColors.GradientInactiveCaption;
            this.groupPanel_SendOption.Style.BackColorGradientAngle = 90;
            this.groupPanel_SendOption.Style.BackColorSchemePart = eColorSchemePart.PanelBackground;
            this.groupPanel_SendOption.Style.BorderBottom = eStyleBorderType.Solid;
            this.groupPanel_SendOption.Style.BorderBottomWidth = 1;
            this.groupPanel_SendOption.Style.BorderColorSchemePart = eColorSchemePart.PanelBorder;
            this.groupPanel_SendOption.Style.BorderLeft = eStyleBorderType.Solid;
            this.groupPanel_SendOption.Style.BorderLeftWidth = 1;
            this.groupPanel_SendOption.Style.BorderRight = eStyleBorderType.Solid;
            this.groupPanel_SendOption.Style.BorderRightWidth = 1;
            this.groupPanel_SendOption.Style.BorderTop = eStyleBorderType.Solid;
            this.groupPanel_SendOption.Style.BorderTopWidth = 1;
            this.groupPanel_SendOption.Style.CornerDiameter = 4;
            this.groupPanel_SendOption.Style.CornerType = eCornerType.Rounded;
            this.groupPanel_SendOption.Style.TextAlignment = eStyleTextAlignment.Center;
            this.groupPanel_SendOption.Style.TextColorSchemePart = eColorSchemePart.PanelText;
            this.groupPanel_SendOption.StyleMouseDown.CornerType = eCornerType.Square;
            this.groupPanel_SendOption.StyleMouseOver.CornerType = eCornerType.Square;
            this.groupPanel_SendOption.TitleImagePosition = eTitleImagePosition.Right;
            this.chk2.AccessibleDescription = null;
            this.chk2.AccessibleName = null;
            resources.ApplyResources(this.chk2, "chk2");
            this.chk2.BackColor = Color.Transparent;
            this.chk2.BackgroundImage = null;
            this.chk2.BackgroundStyle.CornerType = eCornerType.Square;
            this.chk2.CommandParameter = null;
            this.chk2.Name = "chk2";
            this.chk2.Style = eDotNetBarStyle.StyleManagerControlled;
            this.chk1.AccessibleDescription = null;
            this.chk1.AccessibleName = null;
            resources.ApplyResources(this.chk1, "chk1");
            this.chk1.BackColor = Color.Transparent;
            this.chk1.BackgroundImage = null;
            this.chk1.BackgroundStyle.CornerType = eCornerType.Square;
            this.chk1.CommandParameter = null;
            this.chk1.Name = "chk1";
            this.chk1.Style = eDotNetBarStyle.StyleManagerControlled;
            this.chk1.CheckedChanged += new EventHandler(this.chk1_CheckedChanged);
            base.AccessibleDescription = null;
            base.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            base.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.SteelBlue;
            this.BackgroundImage = null;
            base.Controls.Add(this.groupPanel_SendOption);
            base.Controls.Add(this.groupPanel_Balance);
            base.Controls.Add(this.groupPanel2);
            this.Font = null;
            base.FormBorderStyle = FormBorderStyle.Fixed3D;
            base.KeyPreview = true;
            base.MaximizeBox = false;
            base.Name = "FrmRelayBoxes";
            base.Load += new EventHandler(this.FrmRelayBoxes_Load);
            base.FormClosed += new FormClosedEventHandler(this.FrmRelayBoxes_FormClosed);
            base.KeyDown += new KeyEventHandler(this.FrmRelayBoxes_KeyDown);
            this.groupPanel2.ResumeLayout(false);
            this.groupPanel2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((ISupportInitialize)this.txtAmount).EndInit();
            this.groupPanel_Balance.ResumeLayout(false);
            this.groupPanel_SendOption.ResumeLayout(false);
            this.groupPanel_SendOption.PerformLayout();
            base.ResumeLayout(false);
        }//###########&&&&&&&&&&

}
}
