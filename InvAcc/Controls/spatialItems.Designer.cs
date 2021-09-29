namespace InvAcc.Controls
{
    partial class spatialItems
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.TxtPrice = new DevComponents.Editors.DoubleInput();
            this.Txt_Note = new System.Windows.Forms.TextBox();
            this.CheckValue = new System.Windows.Forms.CheckBox();
            this.Txt_Unit = new System.Windows.Forms.TextBox();
            this.button_SrchItemGroup = new DevComponents.DotNetBar.ButtonX();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.PHeader = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.Column2 = new System.Windows.Forms.Label();
            this.Column1 = new System.Windows.Forms.Label();
            this.column3 = new System.Windows.Forms.Label();
            this.Column4 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TxtPrice)).BeginInit();
            this.PHeader.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.27273F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.18182F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.915254F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.66102F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 205F));
            this.tableLayoutPanel1.Controls.Add(this.TxtPrice, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.Txt_Note, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.CheckValue, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.Txt_Unit, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.button_SrchItemGroup, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBox2, 3, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(721, 25);
            this.tableLayoutPanel1.TabIndex = 0;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // TxtPrice
            // 
            this.TxtPrice.AllowEmptyState = false;
            // 
            // 
            // 
            this.TxtPrice.BackgroundStyle.Class = "DateTimeInputBackground";
            this.TxtPrice.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.TxtPrice.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.TxtPrice.DisplayFormat = "0.00";
            this.TxtPrice.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.TxtPrice.Increment = 0D;
            this.TxtPrice.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.TxtPrice.Location = new System.Drawing.Point(518, 3);
            this.TxtPrice.MinValue = 0D;
            this.TxtPrice.Name = "TxtPrice";
            this.TxtPrice.Size = new System.Drawing.Size(133, 21);
            this.TxtPrice.TabIndex = 1143;
            this.TxtPrice.ValueChanged += new System.EventHandler(this.TxtPrice_ValueChanged);
            this.TxtPrice.Click += new System.EventHandler(this.TxtPrice_Click);
            this.TxtPrice.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtPrice_KeyDown);
            this.TxtPrice.Validated += new System.EventHandler(this.TxtPrice_Validated);
            // 
            // Txt_Note
            // 
            this.Txt_Note.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Txt_Note.Enabled = false;
            this.Txt_Note.Location = new System.Drawing.Point(272, 3);
            this.Txt_Note.Name = "Txt_Note";
            this.Txt_Note.Size = new System.Drawing.Size(240, 20);
            this.Txt_Note.TabIndex = 1580;
            this.Txt_Note.Click += new System.EventHandler(this.TxtPrice_Click);
            this.Txt_Note.TextChanged += new System.EventHandler(this.Txt_Note_TextChanged);
            // 
            // CheckValue
            // 
            this.CheckValue.AutoSize = true;
            this.CheckValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CheckValue.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.CheckValue.Location = new System.Drawing.Point(3, 3);
            this.CheckValue.Name = "CheckValue";
            this.CheckValue.Size = new System.Drawing.Size(129, 19);
            this.CheckValue.TabIndex = 5;
            this.CheckValue.UseCompatibleTextRendering = true;
            this.CheckValue.UseVisualStyleBackColor = true;
            this.CheckValue.CheckedChanged += new System.EventHandler(this.CheckValue_CheckedChanged_1);
            this.CheckValue.CheckStateChanged += new System.EventHandler(this.CheckValue_CheckStateChanged);
            this.CheckValue.Click += new System.EventHandler(this.TxtPrice_Click);
            this.CheckValue.Paint += new System.Windows.Forms.PaintEventHandler(this.CheckValue_Paint);
            // 
            // Txt_Unit
            // 
            this.Txt_Unit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Txt_Unit.Enabled = false;
            this.Txt_Unit.Location = new System.Drawing.Point(138, 3);
            this.Txt_Unit.Name = "Txt_Unit";
            this.Txt_Unit.Size = new System.Drawing.Size(84, 20);
            this.Txt_Unit.TabIndex = 6;
            this.Txt_Unit.Click += new System.EventHandler(this.TxtPrice_Click);
            this.Txt_Unit.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // button_SrchItemGroup
            // 
            this.button_SrchItemGroup.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchItemGroup.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchItemGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_SrchItemGroup.Enabled = false;
            this.button_SrchItemGroup.Location = new System.Drawing.Point(228, 3);
            this.button_SrchItemGroup.Name = "button_SrchItemGroup";
            this.button_SrchItemGroup.Size = new System.Drawing.Size(14, 19);
            this.button_SrchItemGroup.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchItemGroup.Symbol = "";
            this.button_SrchItemGroup.SymbolSize = 12F;
            this.button_SrchItemGroup.TabIndex = 1578;
            this.button_SrchItemGroup.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchItemGroup.Click += new System.EventHandler(this.TxtPrice_Click);
            // 
            // textBox2
            // 
            this.textBox2.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.textBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox2.Location = new System.Drawing.Point(248, 3);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(18, 20);
            this.textBox2.TabIndex = 1579;
            this.textBox2.Click += new System.EventHandler(this.textBox2_Click);
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // PHeader
            // 
            this.PHeader.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.PHeader.Controls.Add(this.tableLayoutPanel2);
            this.PHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PHeader.Location = new System.Drawing.Point(0, 0);
            this.PHeader.Name = "PHeader";
            this.PHeader.Size = new System.Drawing.Size(721, 25);
            this.PHeader.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 6;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.27273F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.18182F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.915254F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.66102F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 205F));
            this.tableLayoutPanel2.Controls.Add(this.Column2, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.Column1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.column3, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.Column4, 5, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(721, 25);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // Column2
            // 
            this.Column2.AutoSize = true;
            this.Column2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Column2.Location = new System.Drawing.Point(138, 0);
            this.Column2.Name = "Column2";
            this.Column2.Size = new System.Drawing.Size(84, 25);
            this.Column2.TabIndex = 1;
            this.Column2.Text = "label1";
            // 
            // Column1
            // 
            this.Column1.AutoSize = true;
            this.Column1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Column1.Location = new System.Drawing.Point(3, 0);
            this.Column1.Name = "Column1";
            this.Column1.Size = new System.Drawing.Size(129, 25);
            this.Column1.TabIndex = 0;
            this.Column1.Text = "label1";
            // 
            // column3
            // 
            this.column3.AutoSize = true;
            this.column3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.column3.Location = new System.Drawing.Point(272, 0);
            this.column3.Name = "column3";
            this.column3.Size = new System.Drawing.Size(240, 25);
            this.column3.TabIndex = 3;
            this.column3.Text = "label1";
            // 
            // Column4
            // 
            this.Column4.AutoSize = true;
            this.Column4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Column4.Location = new System.Drawing.Point(518, 0);
            this.Column4.Name = "Column4";
            this.Column4.Size = new System.Drawing.Size(200, 25);
            this.Column4.TabIndex = 3;
            this.Column4.Text = "label1";
            // 
            // spatialItems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.PHeader);
            this.Name = "spatialItems";
            this.Size = new System.Drawing.Size(721, 25);
            this.Load += new System.EventHandler(this.spatialItems_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TxtPrice)).EndInit();
            this.PHeader.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.CheckBox CheckValue;
        private System.Windows.Forms.TextBox Txt_Unit;
        private DevComponents.DotNetBar.ButtonX button_SrchItemGroup;
        private System.Windows.Forms.TextBox Txt_Note;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Panel PHeader;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label Column2;
        private System.Windows.Forms.Label Column1;
        private System.Windows.Forms.Label column3;
        private System.Windows.Forms.Label Column4;
        private DevComponents.Editors.DoubleInput TxtPrice;
    }
}
