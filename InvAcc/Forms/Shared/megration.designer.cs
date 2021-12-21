namespace InvAcc
{
    partial class megration
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.label_Balance = new System.Windows.Forms.Label();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.ButOk = new DevComponents.DotNetBar.ButtonX();
            this.buttonX_Close = new DevComponents.DotNetBar.ButtonX();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.label2 = new System.Windows.Forms.Label();
            this.t1 = new DevComponents.Editors.DoubleInput();
            this.t2 = new DevComponents.Editors.DoubleInput();
            this.label3 = new System.Windows.Forms.Label();
            this.t3 = new DevComponents.Editors.DoubleInput();
            this.label4 = new System.Windows.Forms.Label();
            this.groupPanel1.SuspendLayout();
            this.groupPanel2.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.t1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t3)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(201, 42);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(205, 21);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(225, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "القواعد  المتوفره في الابسوفت سرفر";
            // 
            // groupPanel1
            // 
            this.groupPanel1.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.label_Balance);
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel1.Location = new System.Drawing.Point(0, 0);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupPanel1.Size = new System.Drawing.Size(189, 184);
            // 
            // 
            // 
            this.groupPanel1.Style.BackColor2 = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupPanel1.Style.BackColorGradientAngle = 90;
            this.groupPanel1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderBottomWidth = 1;
            this.groupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderLeftWidth = 1;
            this.groupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderRightWidth = 1;
            this.groupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderTopWidth = 1;
            this.groupPanel1.Style.CornerDiameter = 4;
            this.groupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel1.TabIndex = 973;
            this.groupPanel1.Text = "عدد قواعد البيانات المنسوخه";
            this.groupPanel1.TitleImagePosition = DevComponents.DotNetBar.eTitleImagePosition.Right;
            // 
            // label_Balance
            // 
            this.label_Balance.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label_Balance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Balance.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.label_Balance.ForeColor = System.Drawing.Color.Red;
            this.label_Balance.Location = new System.Drawing.Point(0, 0);
            this.label_Balance.Name = "label_Balance";
            this.label_Balance.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label_Balance.Size = new System.Drawing.Size(183, 163);
            this.label_Balance.TabIndex = 0;
            this.label_Balance.Text = "0";
            this.label_Balance.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupPanel2
            // 
            this.groupPanel2.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.t3);
            this.groupPanel2.Controls.Add(this.label4);
            this.groupPanel2.Controls.Add(this.t2);
            this.groupPanel2.Controls.Add(this.label3);
            this.groupPanel2.Controls.Add(this.t1);
            this.groupPanel2.Controls.Add(this.label2);
            this.groupPanel2.Controls.Add(this.checkBox1);
            this.groupPanel2.Controls.Add(this.buttonX1);
            this.groupPanel2.Controls.Add(this.ButOk);
            this.groupPanel2.Controls.Add(this.label1);
            this.groupPanel2.Controls.Add(this.comboBox1);
            this.groupPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel2.Location = new System.Drawing.Point(0, 0);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupPanel2.Size = new System.Drawing.Size(428, 184);
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
            this.groupPanel2.TabIndex = 972;
            this.groupPanel2.Text = "نقل البيانات من الاب سوفت";
            this.groupPanel2.TitleImagePosition = DevComponents.DotNetBar.eTitleImagePosition.Center;
            this.groupPanel2.Click += new System.EventHandler(this.groupPanel2_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(201, 72);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(205, 17);
            this.checkBox1.TabIndex = 1174;
            this.checkBox1.Text = "نسخ جميع قواعد البيانات بشكل تلقائي";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.buttonX1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.buttonX1.Location = new System.Drawing.Point(3, 118);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(160, 38);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX1.Symbol = "";
            this.buttonX1.SymbolSize = 16F;
            this.buttonX1.TabIndex = 1173;
            this.buttonX1.Text = "نقل التفعيل";
            this.buttonX1.TextColor = System.Drawing.Color.White;
            this.buttonX1.Click += new System.EventHandler(this.reg_copy);
            // 
            // ButOk
            // 
            this.ButOk.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.ButOk.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.ButOk.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.ButOk.Location = new System.Drawing.Point(169, 118);
            this.ButOk.Name = "ButOk";
            this.ButOk.Size = new System.Drawing.Size(253, 38);
            this.ButOk.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ButOk.Symbol = "";
            this.ButOk.SymbolSize = 16F;
            this.ButOk.TabIndex = 1173;
            this.ButOk.Text = "نقل البيانات الى البروسوفت";
            this.ButOk.TextColor = System.Drawing.Color.White;
            this.ButOk.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonX_Close
            // 
            this.buttonX_Close.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX_Close.Checked = true;
            this.buttonX_Close.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX_Close.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonX_Close.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.buttonX_Close.Location = new System.Drawing.Point(0, 1);
            this.buttonX_Close.Name = "buttonX_Close";
            this.buttonX_Close.Size = new System.Drawing.Size(621, 38);
            this.buttonX_Close.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX_Close.Symbol = "";
            this.buttonX_Close.TabIndex = 1174;
            this.buttonX_Close.Text = "اعادة تشغيل البرنامج";
            this.buttonX_Close.TextColor = System.Drawing.Color.SteelBlue;
            this.buttonX_Close.Click += new System.EventHandler(this.buttonX_Close_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupPanel2);
            this.splitContainer1.Size = new System.Drawing.Size(621, 184);
            this.splitContainer1.SplitterDistance = 189;
            this.splitContainer1.TabIndex = 974;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.buttonX_Close);
            this.splitContainer2.Size = new System.Drawing.Size(621, 227);
            this.splitContainer2.SplitterDistance = 184;
            this.splitContainer2.TabIndex = 1175;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 1176;
            this.label2.Text = "CommandTimeout";
            // 
            // t1
            // 
            this.t1.AllowEmptyState = false;
            // 
            // 
            // 
            this.t1.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(198)))));
            this.t1.BackgroundStyle.Class = "DateTimeInputBackground";
            this.t1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.t1.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.t1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.t1.Increment = 1D;
            this.t1.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.t1.Location = new System.Drawing.Point(23, 16);
            this.t1.MinValue = 40D;
            this.t1.Name = "t1";
            this.t1.ShowUpDown = true;
            this.t1.Size = new System.Drawing.Size(126, 20);
            this.t1.TabIndex = 1177;
            this.t1.Value = 150D;
            // 
            // t2
            // 
            this.t2.AllowEmptyState = false;
            // 
            // 
            // 
            this.t2.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(198)))));
            this.t2.BackgroundStyle.Class = "DateTimeInputBackground";
            this.t2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.t2.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.t2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.t2.Increment = 1D;
            this.t2.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.t2.Location = new System.Drawing.Point(23, 56);
            this.t2.MinValue = 5000D;
            this.t2.Name = "t2";
            this.t2.ShowUpDown = true;
            this.t2.Size = new System.Drawing.Size(126, 20);
            this.t2.TabIndex = 1179;
            this.t2.Value = 5000D;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(60, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 1178;
            this.label3.Text = "Sleep1";
            // 
            // t3
            // 
            this.t3.AllowEmptyState = false;
            // 
            // 
            // 
            this.t3.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(198)))));
            this.t3.BackgroundStyle.Class = "DateTimeInputBackground";
            this.t3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.t3.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.t3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.t3.Increment = 1D;
            this.t3.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.t3.Location = new System.Drawing.Point(23, 94);
            this.t3.MinValue = 1000D;
            this.t3.Name = "t3";
            this.t3.ShowUpDown = true;
            this.t3.Size = new System.Drawing.Size(126, 20);
            this.t3.TabIndex = 1181;
            this.t3.Value = 1000D;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(60, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 1180;
            this.label4.Text = "Sleep2";
            // 
            // megration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 227);
            this.Controls.Add(this.splitContainer2);
            this.Name = "megration";
            this.Text = "megration";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.megration_FormClosing);
            this.Load += new System.EventHandler(this.megration_Load);
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel2.ResumeLayout(false);
            this.groupPanel2.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.t1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t3)).EndInit();
            this.Icon = ((System.Drawing.Icon)(InvAcc.Properties.Resources.favicon));
this.ResumeLayout(false);

        }
        #endregion
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private System.Windows.Forms.Label label_Balance;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private DevComponents.DotNetBar.ButtonX buttonX_Close;
        private DevComponents.DotNetBar.ButtonX ButOk;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private System.Windows.Forms.Label label2;
        private DevComponents.Editors.DoubleInput t3;
        private System.Windows.Forms.Label label4;
        private DevComponents.Editors.DoubleInput t2;
        private System.Windows.Forms.Label label3;
        private DevComponents.Editors.DoubleInput t1;
    }
}
