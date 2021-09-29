namespace InvAcc.Controls
{
    partial class itemControl
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
            this.CheckValue = new System.Windows.Forms.CheckBox();
            this.TxtPrice = new DevComponents.Editors.DoubleInput();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TxtPrice)).BeginInit();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55.03685F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 44.96315F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.CheckValue, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.TxtPrice, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(407, 31);
            this.tableLayoutPanel1.TabIndex = 2;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // CheckValue
            // 
            this.CheckValue.AutoSize = true;
            this.CheckValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CheckValue.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.CheckValue.Location = new System.Drawing.Point(187, 3);
            this.CheckValue.Name = "CheckValue";
            this.CheckValue.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.CheckValue.Size = new System.Drawing.Size(217, 25);
            this.CheckValue.TabIndex = 4;
            this.CheckValue.UseVisualStyleBackColor = true;
            this.CheckValue.CheckedChanged += new System.EventHandler(this.CheckValue_CheckedChanged);
            this.CheckValue.CheckStateChanged += new System.EventHandler(this.CheckValue_CheckStateChanged);
            this.CheckValue.Click += new System.EventHandler(this.CheckValue_Click);
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
            this.TxtPrice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtPrice.Enabled = false;
            this.TxtPrice.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.TxtPrice.Increment = 0D;
            this.TxtPrice.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.TxtPrice.Location = new System.Drawing.Point(3, 3);
            this.TxtPrice.MinValue = 0D;
            this.TxtPrice.Name = "TxtPrice";
            this.TxtPrice.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TxtPrice.Size = new System.Drawing.Size(178, 21);
            this.TxtPrice.TabIndex = 1142;
            this.TxtPrice.ValueChanged += new System.EventHandler(this.TxtPrice_ValueChanged);
            this.TxtPrice.Click += new System.EventHandler(this.TxtPrice_Click);
            this.TxtPrice.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtPrice_KeyDown);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(0, 20);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.splitContainer1.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel1_Paint);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.splitContainer1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.splitContainer1.Size = new System.Drawing.Size(323, 54);
            this.splitContainer1.SplitterDistance = 25;
            this.splitContainer1.TabIndex = 3;
            // 
            // itemControl
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.RowHeader;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.splitContainer1);
            this.Name = "itemControl";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(407, 31);
            this.Load += new System.EventHandler(this.itemControl_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TxtPrice)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.CheckBox CheckValue;
        private DevComponents.Editors.DoubleInput TxtPrice;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}
