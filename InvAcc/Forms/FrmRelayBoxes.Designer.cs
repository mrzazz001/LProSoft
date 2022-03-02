

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRelayBoxes));
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.CmbCurr = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.checBox_Acc2 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.checBox_Acc1 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.RButDet = new System.Windows.Forms.RadioButton();
            this.RButShort = new System.Windows.Forms.RadioButton();
            this.button_RepAccTo = new DevComponents.DotNetBar.ButtonX();
            this.button_RepAccFrom = new DevComponents.DotNetBar.ButtonX();
            this.txtTime = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtGDate = new System.Windows.Forms.MaskedTextBox();
            this.txtHDate = new System.Windows.Forms.MaskedTextBox();
            this.buttonX_Close = new DevComponents.DotNetBar.ButtonX();
            this.ButOk = new DevComponents.DotNetBar.ButtonX();
            this.txtAmount = new DevComponents.Editors.DoubleInput();
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.CmbUser = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label3 = new System.Windows.Forms.Label();
            this.CmbFromBox = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.CmbToBox = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.groupPanel_Balance = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.label_Balance = new System.Windows.Forms.Label();
            this.groupPanel_SendOption = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.chk2 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chk1 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.groupPanel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAmount)).BeginInit();
            this.groupPanel_Balance.SuspendLayout();
            this.groupPanel_SendOption.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupPanel2
            // 
            this.groupPanel2.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
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
            this.groupPanel2.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupPanel2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.groupPanel2.Location = new System.Drawing.Point(99, 0);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupPanel2.Size = new System.Drawing.Size(397, 275);
            // 
            // 
            // 
            this.groupPanel2.Style.BackColor2 = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupPanel2.Style.BackColorGradientAngle = 90;
            this.groupPanel2.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel2.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderBottomWidth = 1;
            this.groupPanel2.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel2.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderLeftWidth = 1;
            this.groupPanel2.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderRightWidth = 1;
            this.groupPanel2.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderTopWidth = 1;
            this.groupPanel2.Style.CornerDiameter = 4;
            this.groupPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel2.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel2.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            // 
            // 
            // 
            this.groupPanel2.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel2.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel2.TabIndex = 970;
            this.groupPanel2.Text = "حسابات الصناديق";
            this.groupPanel2.TitleImagePosition = DevComponents.DotNetBar.eTitleImagePosition.Center;
            // 
            // CmbCurr
            // 
            this.CmbCurr.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbCurr.DisplayMember = "Text";
            this.CmbCurr.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.CmbCurr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbCurr.Enabled = false;
            this.CmbCurr.FormattingEnabled = true;
            this.CmbCurr.ItemHeight = 15;
            this.CmbCurr.Location = new System.Drawing.Point(4, 17);
            this.CmbCurr.Name = "CmbCurr";
            this.CmbCurr.Size = new System.Drawing.Size(123, 21);
            this.CmbCurr.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.CmbCurr.TabIndex = 6734;
            // 
            // checBox_Acc2
            // 
            this.checBox_Acc2.AutoSize = true;
            this.checBox_Acc2.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.checBox_Acc2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checBox_Acc2.Font = new System.Drawing.Font("Tahoma", 8F);
            this.checBox_Acc2.Location = new System.Drawing.Point(185, 127);
            this.checBox_Acc2.Name = "checBox_Acc2";
            this.checBox_Acc2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checBox_Acc2.Size = new System.Drawing.Size(109, 15);
            this.checBox_Acc2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checBox_Acc2.TabIndex = 6733;
            this.checBox_Acc2.Text = "إرفاق كشف حساب";
            this.checBox_Acc2.TextColor = System.Drawing.Color.Maroon;
            // 
            // checBox_Acc1
            // 
            this.checBox_Acc1.AutoSize = true;
            this.checBox_Acc1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.checBox_Acc1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checBox_Acc1.Font = new System.Drawing.Font("Tahoma", 8F);
            this.checBox_Acc1.Location = new System.Drawing.Point(185, 81);
            this.checBox_Acc1.Name = "checBox_Acc1";
            this.checBox_Acc1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checBox_Acc1.Size = new System.Drawing.Size(109, 15);
            this.checBox_Acc1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checBox_Acc1.TabIndex = 6732;
            this.checBox_Acc1.Text = "إرفاق كشف حساب";
            this.checBox_Acc1.TextColor = System.Drawing.Color.Maroon;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.RButDet);
            this.groupBox2.Controls.Add(this.RButShort);
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.groupBox2.Location = new System.Drawing.Point(5, 42);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(74, 103);
            this.groupBox2.TabIndex = 6731;
            this.groupBox2.TabStop = false;
            // 
            // RButDet
            // 
            this.RButDet.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.RButDet.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.RButDet.ForeColor = System.Drawing.Color.SteelBlue;
            this.RButDet.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.RButDet.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.RButDet.Location = new System.Drawing.Point(4, 16);
            this.RButDet.Name = "RButDet";
            this.RButDet.Size = new System.Drawing.Size(64, 30);
            this.RButDet.TabIndex = 1007;
            this.RButDet.Text = "تفصيلي";
            this.RButDet.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.RButDet.UseVisualStyleBackColor = true;
            this.RButDet.CheckedChanged += new System.EventHandler(this.RButDet_CheckedChanged);
            // 
            // RButShort
            // 
            this.RButShort.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.RButShort.Checked = true;
            this.RButShort.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.RButShort.ForeColor = System.Drawing.Color.SteelBlue;
            this.RButShort.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.RButShort.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.RButShort.Location = new System.Drawing.Point(4, 61);
            this.RButShort.Name = "RButShort";
            this.RButShort.Size = new System.Drawing.Size(65, 30);
            this.RButShort.TabIndex = 1008;
            this.RButShort.TabStop = true;
            this.RButShort.Text = "مختصر";
            this.RButShort.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.RButShort.UseVisualStyleBackColor = true;
            this.RButShort.CheckedChanged += new System.EventHandler(this.RButShort_CheckedChanged);
            // 
            // button_RepAccTo
            // 
            this.button_RepAccTo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_RepAccTo.Checked = true;
            this.button_RepAccTo.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.button_RepAccTo.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.button_RepAccTo.Location = new System.Drawing.Point(85, 103);
            this.button_RepAccTo.Name = "button_RepAccTo";
            this.button_RepAccTo.Size = new System.Drawing.Size(78, 20);
            this.button_RepAccTo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_RepAccTo.Symbol = "";
            this.button_RepAccTo.SymbolSize = 12F;
            this.button_RepAccTo.TabIndex = 1180;
            this.button_RepAccTo.Text = "كشف";
            this.button_RepAccTo.TextColor = System.Drawing.Color.Black;
            this.button_RepAccTo.Click += new System.EventHandler(this.button_RepAccTo_Click);
            // 
            // button_RepAccFrom
            // 
            this.button_RepAccFrom.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_RepAccFrom.Checked = true;
            this.button_RepAccFrom.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.button_RepAccFrom.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.button_RepAccFrom.Location = new System.Drawing.Point(85, 57);
            this.button_RepAccFrom.Name = "button_RepAccFrom";
            this.button_RepAccFrom.Size = new System.Drawing.Size(78, 20);
            this.button_RepAccFrom.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_RepAccFrom.Symbol = "";
            this.button_RepAccFrom.SymbolSize = 12F;
            this.button_RepAccFrom.TabIndex = 1179;
            this.button_RepAccFrom.Text = "كشف";
            this.button_RepAccFrom.TextColor = System.Drawing.Color.Black;
            this.button_RepAccFrom.Click += new System.EventHandler(this.button_RepAccFrom_Click);
            // 
            // txtTime
            // 
            this.txtTime.BackColor = System.Drawing.Color.White;
            this.txtTime.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.txtTime.Location = new System.Drawing.Point(8, 149);
            this.txtTime.Mask = "##:##";
            this.txtTime.Name = "txtTime";
            this.txtTime.Size = new System.Drawing.Size(76, 21);
            this.txtTime.TabIndex = 1177;
            this.txtTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTime.Click += new System.EventHandler(this.txtTime_Click);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(303, 153);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 1178;
            this.label4.Text = "التاريــــــــخ :";
            // 
            // txtGDate
            // 
            this.txtGDate.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtGDate.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.txtGDate.Location = new System.Drawing.Point(194, 149);
            this.txtGDate.Mask = "0000/00/00";
            this.txtGDate.Name = "txtGDate";
            this.txtGDate.Size = new System.Drawing.Size(106, 21);
            this.txtGDate.TabIndex = 1175;
            this.txtGDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtGDate.Click += new System.EventHandler(this.txtGDate_Click);
            this.txtGDate.Leave += new System.EventHandler(this.txtGDate_Leave);
            // 
            // txtHDate
            // 
            this.txtHDate.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtHDate.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.txtHDate.Location = new System.Drawing.Point(86, 149);
            this.txtHDate.Mask = "0000/00/00";
            this.txtHDate.Name = "txtHDate";
            this.txtHDate.Size = new System.Drawing.Size(106, 21);
            this.txtHDate.TabIndex = 1176;
            this.txtHDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtHDate.Click += new System.EventHandler(this.txtHDate_Click);
            this.txtHDate.Leave += new System.EventHandler(this.txtHDate_Leave);
            // 
            // buttonX_Close
            // 
            this.buttonX_Close.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX_Close.Checked = true;
            this.buttonX_Close.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX_Close.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.buttonX_Close.Location = new System.Drawing.Point(2, 213);
            this.buttonX_Close.Name = "buttonX_Close";
            this.buttonX_Close.Size = new System.Drawing.Size(193, 40);
            this.buttonX_Close.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX_Close.Symbol = "";
            this.buttonX_Close.TabIndex = 1174;
            this.buttonX_Close.Text = "إغلاق";
            this.buttonX_Close.TextColor = System.Drawing.Color.SteelBlue;
            this.buttonX_Close.Click += new System.EventHandler(this.buttonX_Close_Click);
            // 
            // ButOk
            // 
            this.ButOk.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.ButOk.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.ButOk.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.ButOk.Location = new System.Drawing.Point(197, 213);
            this.ButOk.Name = "ButOk";
            this.ButOk.Size = new System.Drawing.Size(193, 40);
            this.ButOk.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ButOk.Symbol = "";
            this.ButOk.SymbolSize = 16F;
            this.ButOk.TabIndex = 1173;
            this.ButOk.Text = "ترحيل المبلغ F2";
            this.ButOk.TextColor = System.Drawing.Color.White;
            this.ButOk.Click += new System.EventHandler(this.ButOk_Click);
            // 
            // txtAmount
            // 
            this.txtAmount.AllowEmptyState = false;
            this.txtAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtAmount.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
            this.txtAmount.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtAmount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtAmount.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtAmount.DisplayFormat = "0.00";
            this.txtAmount.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtAmount.Increment = 1D;
            this.txtAmount.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtAmount.Location = new System.Drawing.Point(8, 181);
            this.txtAmount.MinValue = 0D;
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.ShowUpDown = true;
            this.txtAmount.Size = new System.Drawing.Size(184, 21);
            this.txtAmount.TabIndex = 1172;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.BackColor = System.Drawing.Color.SteelBlue;
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(194, 181);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(106, 21);
            this.label8.TabIndex = 1171;
            this.label8.Text = "المبلـــغ :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(303, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 1168;
            this.label2.Text = "إلى الصندوق :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(303, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 1167;
            this.label1.Text = "من الصندوق :";
            // 
            // CmbUser
            // 
            this.CmbUser.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbUser.DisplayMember = "Text";
            this.CmbUser.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.CmbUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbUser.Enabled = false;
            this.CmbUser.FormattingEnabled = true;
            this.CmbUser.ItemHeight = 15;
            this.CmbUser.Location = new System.Drawing.Point(129, 17);
            this.CmbUser.Name = "CmbUser";
            this.CmbUser.Size = new System.Drawing.Size(171, 21);
            this.CmbUser.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.CmbUser.TabIndex = 1165;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(303, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 1166;
            this.label3.Text = "المستخدم :";
            // 
            // CmbFromBox
            // 
            this.CmbFromBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbFromBox.DisplayMember = "Text";
            this.CmbFromBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.CmbFromBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbFromBox.FormattingEnabled = true;
            this.CmbFromBox.ItemHeight = 15;
            this.CmbFromBox.Location = new System.Drawing.Point(167, 57);
            this.CmbFromBox.Name = "CmbFromBox";
            this.CmbFromBox.Size = new System.Drawing.Size(133, 21);
            this.CmbFromBox.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.CmbFromBox.TabIndex = 1169;
            this.CmbFromBox.Tag = "T_GDDET.AccNo ";
            this.CmbFromBox.SelectedIndexChanged += new System.EventHandler(this.CmbFromBox_SelectedIndexChanged);
            // 
            // CmbToBox
            // 
            this.CmbToBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbToBox.DisplayMember = "Text";
            this.CmbToBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.CmbToBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbToBox.FormattingEnabled = true;
            this.CmbToBox.ItemHeight = 15;
            this.CmbToBox.Location = new System.Drawing.Point(167, 103);
            this.CmbToBox.Name = "CmbToBox";
            this.CmbToBox.Size = new System.Drawing.Size(133, 21);
            this.CmbToBox.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.CmbToBox.TabIndex = 1170;
            this.CmbToBox.Tag = "T_GDDET.AccNo ";
            // 
            // groupPanel_Balance
            // 
            this.groupPanel_Balance.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel_Balance.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel_Balance.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel_Balance.Controls.Add(this.label_Balance);
            this.groupPanel_Balance.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel_Balance.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupPanel_Balance.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.groupPanel_Balance.Location = new System.Drawing.Point(0, 0);
            this.groupPanel_Balance.Name = "groupPanel_Balance";
            this.groupPanel_Balance.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupPanel_Balance.Size = new System.Drawing.Size(99, 140);
            // 
            // 
            // 
            this.groupPanel_Balance.Style.BackColor2 = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupPanel_Balance.Style.BackColorGradientAngle = 90;
            this.groupPanel_Balance.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel_Balance.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel_Balance.Style.BorderBottomWidth = 1;
            this.groupPanel_Balance.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel_Balance.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel_Balance.Style.BorderLeftWidth = 1;
            this.groupPanel_Balance.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel_Balance.Style.BorderRightWidth = 1;
            this.groupPanel_Balance.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel_Balance.Style.BorderTopWidth = 1;
            this.groupPanel_Balance.Style.CornerDiameter = 4;
            this.groupPanel_Balance.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel_Balance.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel_Balance.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            // 
            // 
            // 
            this.groupPanel_Balance.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel_Balance.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel_Balance.TabIndex = 971;
            this.groupPanel_Balance.Text = "الرصيد الحالي";
            this.groupPanel_Balance.TitleImagePosition = DevComponents.DotNetBar.eTitleImagePosition.Right;
            // 
            // label_Balance
            // 
            this.label_Balance.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label_Balance.Dock = System.Windows.Forms.DockStyle.Top;
            this.label_Balance.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.label_Balance.ForeColor = System.Drawing.Color.Red;
            this.label_Balance.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_Balance.Location = new System.Drawing.Point(0, 0);
            this.label_Balance.Name = "label_Balance";
            this.label_Balance.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label_Balance.Size = new System.Drawing.Size(93, 115);
            this.label_Balance.TabIndex = 0;
            this.label_Balance.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupPanel_SendOption
            // 
            this.groupPanel_SendOption.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel_SendOption.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel_SendOption.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel_SendOption.Controls.Add(this.chk2);
            this.groupPanel_SendOption.Controls.Add(this.chk1);
            this.groupPanel_SendOption.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel_SendOption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel_SendOption.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.groupPanel_SendOption.Location = new System.Drawing.Point(0, 140);
            this.groupPanel_SendOption.Name = "groupPanel_SendOption";
            this.groupPanel_SendOption.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupPanel_SendOption.Size = new System.Drawing.Size(99, 135);
            // 
            // 
            // 
            this.groupPanel_SendOption.Style.BackColor2 = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupPanel_SendOption.Style.BackColorGradientAngle = 90;
            this.groupPanel_SendOption.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel_SendOption.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel_SendOption.Style.BorderBottomWidth = 1;
            this.groupPanel_SendOption.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel_SendOption.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel_SendOption.Style.BorderLeftWidth = 1;
            this.groupPanel_SendOption.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel_SendOption.Style.BorderRightWidth = 1;
            this.groupPanel_SendOption.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel_SendOption.Style.BorderTopWidth = 1;
            this.groupPanel_SendOption.Style.CornerDiameter = 4;
            this.groupPanel_SendOption.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel_SendOption.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel_SendOption.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            // 
            // 
            // 
            this.groupPanel_SendOption.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel_SendOption.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel_SendOption.TabIndex = 972;
            this.groupPanel_SendOption.Text = "خيارات الإرسال";
            this.groupPanel_SendOption.TitleImagePosition = DevComponents.DotNetBar.eTitleImagePosition.Right;
            // 
            // chk2
            // 
            this.chk2.AutoSize = true;
            this.chk2.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chk2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chk2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.chk2.Location = new System.Drawing.Point(14, 71);
            this.chk2.Name = "chk2";
            this.chk2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chk2.Size = new System.Drawing.Size(57, 15);
            this.chk2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chk2.TabIndex = 1178;
            this.chk2.Text = "جـــوال";
            // 
            // chk1
            // 
            this.chk1.AutoSize = true;
            this.chk1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chk1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chk1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.chk1.Location = new System.Drawing.Point(10, 30);
            this.chk1.Name = "chk1";
            this.chk1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chk1.Size = new System.Drawing.Size(61, 15);
            this.chk1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chk1.TabIndex = 1177;
            this.chk1.Text = "إيميــــل";
            this.chk1.CheckedChanged += new System.EventHandler(this.chk1_CheckedChanged);
            // 
            // FrmRelayBoxes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(496, 275);
            this.Controls.Add(this.groupPanel_SendOption);
            this.Controls.Add(this.groupPanel_Balance);
            this.Controls.Add(this.groupPanel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "FrmRelayBoxes";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ترحيل حسابات الصناديق - الخزينة";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmRelayBoxes_FormClosed);
            this.Load += new System.EventHandler(this.FrmRelayBoxes_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmRelayBoxes_KeyDown);
            this.groupPanel2.ResumeLayout(false);
            this.groupPanel2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtAmount)).EndInit();
            this.groupPanel_Balance.ResumeLayout(false);
            this.groupPanel_SendOption.ResumeLayout(false);
            this.groupPanel_SendOption.PerformLayout();
            this.ResumeLayout(false);

        }//###########&&&&&&&&&&

}
}
