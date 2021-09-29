   

namespace InvAcc.Forms
{
partial class FrmBalance
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBalance));
            this.labelHeader = new DevComponents.DotNetBar.LabelX();
            this.checkBox_BalanceActivated = new System.Windows.Forms.CheckBox();
            this.groupPanel_Main = new System.Windows.Forms.GroupBox();
            this.txtPriceQ = new DevComponents.Editors.IntegerInput();
            this.label8 = new System.Windows.Forms.Label();
            this.txtWieghtQ = new DevComponents.Editors.IntegerInput();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPriceTo = new DevComponents.Editors.IntegerInput();
            this.txtPriceFrom = new DevComponents.Editors.IntegerInput();
            this.txtWightTo = new DevComponents.Editors.IntegerInput();
            this.txtWightFrom = new DevComponents.Editors.IntegerInput();
            this.txtBarcodTo = new DevComponents.Editors.IntegerInput();
            this.txtBarcodFrom = new DevComponents.Editors.IntegerInput();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox_PrintType = new System.Windows.Forms.GroupBox();
            this.RedButWightPrice = new System.Windows.Forms.RadioButton();
            this.RedButPrice = new System.Windows.Forms.RadioButton();
            this.RedButWight = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ButWithoutSave = new C1.Win.C1Input.C1Button();
            this.ButWithSave = new C1.Win.C1Input.C1Button();
            this.groupPanel_Main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPriceQ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWieghtQ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPriceTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPriceFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWightTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWightFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBarcodTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBarcodFrom)).BeginInit();
            this.groupBox_PrintType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ButWithoutSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButWithSave)).BeginInit();
            this.SuspendLayout();
            // 
            // labelHeader
            // 
            this.labelHeader.BackColor = System.Drawing.Color.DimGray;
            // 
            // 
            // 
            this.labelHeader.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelHeader.Font = new System.Drawing.Font("Tahoma", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.labelHeader.ForeColor = System.Drawing.Color.White;
            this.labelHeader.Location = new System.Drawing.Point(0, 0);
            this.labelHeader.Name = "labelHeader";
            this.labelHeader.Size = new System.Drawing.Size(442, 26);
            this.labelHeader.TabIndex = 89;
            this.labelHeader.Text = "إعدادات الميزان الباركود";
            this.labelHeader.TextAlignment = System.Drawing.StringAlignment.Center;
            this.labelHeader.Click += new System.EventHandler(this.labelHeader_Click);
            // 
            // checkBox_BalanceActivated
            // 
            this.checkBox_BalanceActivated.AutoSize = true;
            this.checkBox_BalanceActivated.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.checkBox_BalanceActivated.ForeColor = System.Drawing.Color.Blue;
            this.checkBox_BalanceActivated.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.checkBox_BalanceActivated.Location = new System.Drawing.Point(256, 6);
            this.checkBox_BalanceActivated.Name = "checkBox_BalanceActivated";
            this.checkBox_BalanceActivated.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBox_BalanceActivated.Size = new System.Drawing.Size(174, 17);
            this.checkBox_BalanceActivated.TabIndex = 1021;
            this.checkBox_BalanceActivated.Text = "تفعيل خاصية الميزان مع الأصناف";
            this.checkBox_BalanceActivated.UseVisualStyleBackColor = true;
            this.checkBox_BalanceActivated.CheckedChanged += new System.EventHandler(this.checkBox_BalanceActivated_CheckedChanged);
            // 
            // groupPanel_Main
            // 
            this.groupPanel_Main.BackColor = System.Drawing.Color.Gainsboro;
            this.groupPanel_Main.Controls.Add(this.txtPriceQ);
            this.groupPanel_Main.Controls.Add(this.label8);
            this.groupPanel_Main.Controls.Add(this.checkBox_BalanceActivated);
            this.groupPanel_Main.Controls.Add(this.txtWieghtQ);
            this.groupPanel_Main.Controls.Add(this.label7);
            this.groupPanel_Main.Controls.Add(this.txtPriceTo);
            this.groupPanel_Main.Controls.Add(this.txtPriceFrom);
            this.groupPanel_Main.Controls.Add(this.txtWightTo);
            this.groupPanel_Main.Controls.Add(this.txtWightFrom);
            this.groupPanel_Main.Controls.Add(this.txtBarcodTo);
            this.groupPanel_Main.Controls.Add(this.txtBarcodFrom);
            this.groupPanel_Main.Controls.Add(this.label3);
            this.groupPanel_Main.Controls.Add(this.label1);
            this.groupPanel_Main.Controls.Add(this.groupBox_PrintType);
            this.groupPanel_Main.Controls.Add(this.label5);
            this.groupPanel_Main.Controls.Add(this.label6);
            this.groupPanel_Main.Controls.Add(this.label4);
            this.groupPanel_Main.Controls.Add(this.label2);
            this.groupPanel_Main.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupPanel_Main.Enabled = false;
            this.groupPanel_Main.Location = new System.Drawing.Point(0, 26);
            this.groupPanel_Main.Name = "groupPanel_Main";
            this.groupPanel_Main.Size = new System.Drawing.Size(442, 191);
            this.groupPanel_Main.TabIndex = 1020;
            this.groupPanel_Main.TabStop = false;
            // 
            // txtPriceQ
            // 
            this.txtPriceQ.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtPriceQ.BackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.DockSiteBackColor2;
            this.txtPriceQ.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtPriceQ.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtPriceQ.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtPriceQ.DisplayFormat = "0";
            this.txtPriceQ.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtPriceQ.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtPriceQ.Location = new System.Drawing.Point(12, 118);
            this.txtPriceQ.MinValue = 0;
            this.txtPriceQ.Name = "txtPriceQ";
            this.txtPriceQ.ShowUpDown = true;
            this.txtPriceQ.Size = new System.Drawing.Size(68, 21);
            this.txtPriceQ.TabIndex = 1013;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(83, 122);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(156, 13);
            this.label8.TabIndex = 1012;
            this.label8.Text = "بداية فاصلة السعر العشرية بعد :";
            // 
            // txtWieghtQ
            // 
            this.txtWieghtQ.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtWieghtQ.BackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.DockSiteBackColor2;
            this.txtWieghtQ.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtWieghtQ.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtWieghtQ.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtWieghtQ.DisplayFormat = "0";
            this.txtWieghtQ.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtWieghtQ.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtWieghtQ.Location = new System.Drawing.Point(13, 94);
            this.txtWieghtQ.MinValue = 0;
            this.txtWieghtQ.Name = "txtWieghtQ";
            this.txtWieghtQ.ShowUpDown = true;
            this.txtWieghtQ.Size = new System.Drawing.Size(68, 21);
            this.txtWieghtQ.TabIndex = 1011;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(84, 98);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(155, 13);
            this.label7.TabIndex = 1010;
            this.label7.Text = "بداية فاصلة الــوزن العشرية بعد :";
            // 
            // txtPriceTo
            // 
            this.txtPriceTo.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtPriceTo.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(198)))));
            this.txtPriceTo.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtPriceTo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtPriceTo.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtPriceTo.DisplayFormat = "0";
            this.txtPriceTo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtPriceTo.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtPriceTo.Location = new System.Drawing.Point(257, 166);
            this.txtPriceTo.MinValue = 1;
            this.txtPriceTo.Name = "txtPriceTo";
            this.txtPriceTo.ShowUpDown = true;
            this.txtPriceTo.Size = new System.Drawing.Size(68, 21);
            this.txtPriceTo.TabIndex = 1009;
            this.txtPriceTo.Value = 1;
            // 
            // txtPriceFrom
            // 
            this.txtPriceFrom.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtPriceFrom.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(198)))));
            this.txtPriceFrom.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtPriceFrom.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtPriceFrom.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtPriceFrom.DisplayFormat = "0";
            this.txtPriceFrom.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtPriceFrom.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtPriceFrom.Location = new System.Drawing.Point(257, 142);
            this.txtPriceFrom.MinValue = 1;
            this.txtPriceFrom.Name = "txtPriceFrom";
            this.txtPriceFrom.ShowUpDown = true;
            this.txtPriceFrom.Size = new System.Drawing.Size(68, 21);
            this.txtPriceFrom.TabIndex = 1008;
            this.txtPriceFrom.Value = 1;
            // 
            // txtWightTo
            // 
            this.txtWightTo.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtWightTo.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(198)))));
            this.txtWightTo.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtWightTo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtWightTo.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtWightTo.DisplayFormat = "0";
            this.txtWightTo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtWightTo.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtWightTo.Location = new System.Drawing.Point(257, 118);
            this.txtWightTo.MinValue = 1;
            this.txtWightTo.Name = "txtWightTo";
            this.txtWightTo.ShowUpDown = true;
            this.txtWightTo.Size = new System.Drawing.Size(68, 21);
            this.txtWightTo.TabIndex = 1005;
            this.txtWightTo.Value = 1;
            // 
            // txtWightFrom
            // 
            this.txtWightFrom.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtWightFrom.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(198)))));
            this.txtWightFrom.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtWightFrom.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtWightFrom.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtWightFrom.DisplayFormat = "0";
            this.txtWightFrom.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtWightFrom.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtWightFrom.Location = new System.Drawing.Point(257, 94);
            this.txtWightFrom.MinValue = 1;
            this.txtWightFrom.Name = "txtWightFrom";
            this.txtWightFrom.ShowUpDown = true;
            this.txtWightFrom.Size = new System.Drawing.Size(68, 21);
            this.txtWightFrom.TabIndex = 1004;
            this.txtWightFrom.Value = 1;
            // 
            // txtBarcodTo
            // 
            this.txtBarcodTo.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtBarcodTo.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(198)))));
            this.txtBarcodTo.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtBarcodTo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtBarcodTo.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtBarcodTo.DisplayFormat = "0";
            this.txtBarcodTo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtBarcodTo.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtBarcodTo.Location = new System.Drawing.Point(13, 166);
            this.txtBarcodTo.MinValue = 1;
            this.txtBarcodTo.Name = "txtBarcodTo";
            this.txtBarcodTo.ShowUpDown = true;
            this.txtBarcodTo.Size = new System.Drawing.Size(68, 21);
            this.txtBarcodTo.TabIndex = 1003;
            this.txtBarcodTo.Value = 1;
            // 
            // txtBarcodFrom
            // 
            this.txtBarcodFrom.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtBarcodFrom.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(198)))));
            this.txtBarcodFrom.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtBarcodFrom.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtBarcodFrom.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtBarcodFrom.DisplayFormat = "0";
            this.txtBarcodFrom.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtBarcodFrom.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtBarcodFrom.Location = new System.Drawing.Point(13, 142);
            this.txtBarcodFrom.MinValue = 1;
            this.txtBarcodFrom.Name = "txtBarcodFrom";
            this.txtBarcodFrom.ShowUpDown = true;
            this.txtBarcodFrom.Size = new System.Drawing.Size(68, 21);
            this.txtBarcodFrom.TabIndex = 1002;
            this.txtBarcodFrom.Value = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(84, 170);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 13);
            this.label3.TabIndex = 93;
            this.label3.Text = "إجمالي خانات الباركود :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(84, 146);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 91;
            this.label1.Text = "رقم بداية الباركود :";
            // 
            // groupBox_PrintType
            // 
            this.groupBox_PrintType.Controls.Add(this.RedButWightPrice);
            this.groupBox_PrintType.Controls.Add(this.RedButPrice);
            this.groupBox_PrintType.Controls.Add(this.RedButWight);
            this.groupBox_PrintType.Location = new System.Drawing.Point(13, 28);
            this.groupBox_PrintType.Name = "groupBox_PrintType";
            this.groupBox_PrintType.Size = new System.Drawing.Size(418, 54);
            this.groupBox_PrintType.TabIndex = 90;
            this.groupBox_PrintType.TabStop = false;
            this.groupBox_PrintType.Text = "نوع الميزان";
            // 
            // RedButWightPrice
            // 
            this.RedButWightPrice.AutoSize = true;
            this.RedButWightPrice.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.RedButWightPrice.Location = new System.Drawing.Point(19, 24);
            this.RedButWightPrice.Name = "RedButWightPrice";
            this.RedButWightPrice.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RedButWightPrice.Size = new System.Drawing.Size(131, 17);
            this.RedButWightPrice.TabIndex = 15;
            this.RedButWightPrice.Text = "إستخدام بالوزن والسعر";
            this.RedButWightPrice.UseVisualStyleBackColor = true;
            // 
            // RedButPrice
            // 
            this.RedButPrice.AutoSize = true;
            this.RedButPrice.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.RedButPrice.Location = new System.Drawing.Point(172, 24);
            this.RedButPrice.Name = "RedButPrice";
            this.RedButPrice.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RedButPrice.Size = new System.Drawing.Size(101, 17);
            this.RedButPrice.TabIndex = 14;
            this.RedButPrice.Text = "إستخدام بالسعر";
            this.RedButPrice.UseVisualStyleBackColor = true;
            // 
            // RedButWight
            // 
            this.RedButWight.AutoSize = true;
            this.RedButWight.Checked = true;
            this.RedButWight.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.RedButWight.Location = new System.Drawing.Point(295, 24);
            this.RedButWight.Name = "RedButWight";
            this.RedButWight.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RedButWight.Size = new System.Drawing.Size(94, 17);
            this.RedButWight.TabIndex = 13;
            this.RedButWight.TabStop = true;
            this.RedButWight.Text = "إستخدام بالوزن";
            this.RedButWight.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(328, 146);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 13);
            this.label5.TabIndex = 1007;
            this.label5.Text = "عدد بداية السعر :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(328, 170);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 13);
            this.label6.TabIndex = 1006;
            this.label6.Text = "إجمالي خانات السعر :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(328, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 13);
            this.label4.TabIndex = 96;
            this.label4.Text = "عدد بداية الوزن :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(328, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 13);
            this.label2.TabIndex = 92;
            this.label2.Text = "إجمالي خانات الوزن :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ButWithoutSave
            // 
            this.ButWithoutSave.BackgroundImage = global::InvAcc.Properties.Resources.YALO2;
            this.ButWithoutSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ButWithoutSave.Dock = System.Windows.Forms.DockStyle.Right;
            this.ButWithoutSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButWithoutSave.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.ButWithoutSave.Location = new System.Drawing.Point(330, 217);
            this.ButWithoutSave.Name = "ButWithoutSave";
            this.ButWithoutSave.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ButWithoutSave.Size = new System.Drawing.Size(112, 50);
            this.ButWithoutSave.TabIndex = 1190;
            this.ButWithoutSave.Text = "خروج | ESC";
            this.ButWithoutSave.UseVisualStyleBackColor = true;
            this.ButWithoutSave.Click += new System.EventHandler(this.ButWithoutSave_Click);
            // 
            // ButWithSave
            // 
            this.ButWithSave.BackgroundImage = global::InvAcc.Properties.Resources.GREEN;
            this.ButWithSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ButWithSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButWithSave.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.ButWithSave.Location = new System.Drawing.Point(0, 217);
            this.ButWithSave.Name = "ButWithSave";
            this.ButWithSave.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ButWithSave.Size = new System.Drawing.Size(333, 50);
            this.ButWithSave.TabIndex = 1191;
            this.ButWithSave.Text = "حفظ | Save";
            this.ButWithSave.UseVisualStyleBackColor = true;
            this.ButWithSave.Click += new System.EventHandler(this.ButWithSave_Click);
            // 
            // FrmBalance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(442, 267);
            this.ControlBox = false;
            this.Controls.Add(this.ButWithSave);
            this.Controls.Add(this.ButWithoutSave);
            this.Controls.Add(this.groupPanel_Main);
            this.Controls.Add(this.labelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(InvAcc.Properties.Resources.favicon));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "FrmBalance";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmBalance_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmBalance_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FrmBalance_KeyPress);
            this.groupPanel_Main.ResumeLayout(false);
            this.groupPanel_Main.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPriceQ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWieghtQ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPriceTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPriceFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWightTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWightFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBarcodTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBarcodFrom)).EndInit();
            this.groupBox_PrintType.ResumeLayout(false);
            this.groupBox_PrintType.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ButWithoutSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButWithSave)).EndInit();
            this.Icon = ((System.Drawing.Icon)(InvAcc.Properties.Resources.favicon));
            this.ResumeLayout(false);
        }//###########&&&&&&&&&&

}
}
