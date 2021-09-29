   

namespace InvAcc.Forms
{
partial class FrmEndYearsFiles
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
            this.components = new System.ComponentModel.Container();
            this.listBox_Paths = new System.Windows.Forms.ListBox();
            this.label29 = new System.Windows.Forms.Label();
            this.textBox_EndsPath = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonX_Ok = new DevComponents.DotNetBar.ButtonX();
            this.buttonX_Close = new DevComponents.DotNetBar.ButtonX();
            this.listBox_Paths2 = new System.Windows.Forms.ListBox();
            this.netResize1 = new Softgroup.NetResize.NetResize(this.components);
            this.netResize1.AfterControlResize += new Softgroup.NetResize.NetResize.AfterControlResizeEventHandler(this.netResize1_AfterControlResize);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).BeginInit();
            this.SuspendLayout();
            // 
            // listBox_Paths
            // 
            this.listBox_Paths.BackColor = System.Drawing.Color.WhiteSmoke;
            this.listBox_Paths.Dock = System.Windows.Forms.DockStyle.Top;
            this.listBox_Paths.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox_Paths.ForeColor = System.Drawing.Color.SteelBlue;
            this.listBox_Paths.FormattingEnabled = true;
            this.listBox_Paths.ItemHeight = 14;
            this.listBox_Paths.Location = new System.Drawing.Point(0, 33);
            this.listBox_Paths.Name = "listBox_Paths";
            this.listBox_Paths.ScrollAlwaysVisible = true;
            this.listBox_Paths.Size = new System.Drawing.Size(551, 158);
            this.listBox_Paths.TabIndex = 1;
            this.listBox_Paths.SelectedIndexChanged += new System.EventHandler(this.listBox_Paths_SelectedIndexChanged);
            this.listBox_Paths.DoubleClick += new System.EventHandler(this.listBox_Paths_DoubleClick);
            // 
            // label29
            // 
            this.label29.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label29.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label29.Dock = System.Windows.Forms.DockStyle.Top;
            this.label29.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label29.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label29.ForeColor = System.Drawing.Color.SteelBlue;
            this.label29.Location = new System.Drawing.Point(0, 0);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(551, 33);
            this.label29.TabIndex = 10;
            this.label29.Text = "البيانات المقفلة                             The Data Locked";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox_EndsPath
            // 
            this.textBox_EndsPath.BackColor = System.Drawing.SystemColors.ActiveCaption;
            // 
            // 
            // 
            this.textBox_EndsPath.Border.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.textBox_EndsPath.Border.BorderBottomWidth = 1;
            this.textBox_EndsPath.Border.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.textBox_EndsPath.Border.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.textBox_EndsPath.Border.BorderLeftWidth = 1;
            this.textBox_EndsPath.Border.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.textBox_EndsPath.Border.BorderRightWidth = 1;
            this.textBox_EndsPath.Border.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.textBox_EndsPath.Border.BorderTopWidth = 1;
            this.textBox_EndsPath.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBox_EndsPath.ButtonCustom.Text = "....";
            this.textBox_EndsPath.ButtonCustom.Visible = true;
            this.textBox_EndsPath.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox_EndsPath.Font = new System.Drawing.Font("Tahoma", 6.75F);
            this.textBox_EndsPath.ForeColor = System.Drawing.Color.Black;
            this.textBox_EndsPath.Location = new System.Drawing.Point(0, 191);
            this.textBox_EndsPath.Multiline = true;
            this.textBox_EndsPath.Name = "textBox_EndsPath";
            this.textBox_EndsPath.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_EndsPath, false);
            this.textBox_EndsPath.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBox_EndsPath.Size = new System.Drawing.Size(551, 24);
            this.textBox_EndsPath.TabIndex = 933;
            this.textBox_EndsPath.WatermarkColor = System.Drawing.Color.Black;
            this.textBox_EndsPath.WatermarkImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.textBox_EndsPath.ButtonCustomClick += new System.EventHandler(this.textBox_EndsPath_ButtonCustomClick);
            this.textBox_EndsPath.TextChanged += new System.EventHandler(this.textBox_EndsPath_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.buttonX_Ok);
            this.groupBox1.Controls.Add(this.buttonX_Close);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 214);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(551, 77);
            this.groupBox1.TabIndex = 934;
            this.groupBox1.TabStop = false;
            // 
            // buttonX_Ok
            // 
            this.buttonX_Ok.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX_Ok.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.buttonX_Ok.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.buttonX_Ok.ImagePosition = DevComponents.DotNetBar.eImagePosition.Right;
            this.buttonX_Ok.Location = new System.Drawing.Point(202, 11);
            this.buttonX_Ok.Name = "buttonX_Ok";
            this.buttonX_Ok.Size = new System.Drawing.Size(343, 47);
            this.buttonX_Ok.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX_Ok.Symbol = "";
            this.buttonX_Ok.TabIndex = 13;
            this.buttonX_Ok.Text = "OK  موافـق";
            this.buttonX_Ok.TextColor = System.Drawing.Color.White;
            this.buttonX_Ok.Click += new System.EventHandler(this.buttonX_Ok_Click);
            // 
            // buttonX_Close
            // 
            this.buttonX_Close.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX_Close.Checked = true;
            this.buttonX_Close.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX_Close.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.buttonX_Close.ImagePosition = DevComponents.DotNetBar.eImagePosition.Right;
            this.buttonX_Close.Location = new System.Drawing.Point(5, 11);
            this.buttonX_Close.Name = "buttonX_Close";
            this.buttonX_Close.Size = new System.Drawing.Size(194, 47);
            this.buttonX_Close.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX_Close.Symbol = "";
            this.buttonX_Close.TabIndex = 14;
            this.buttonX_Close.Text = "Close  إغلاق";
            this.buttonX_Close.TextColor = System.Drawing.Color.Black;
            this.buttonX_Close.Click += new System.EventHandler(this.buttonX_Close_Click);
            // 
            // listBox_Paths2
            // 
            this.listBox_Paths2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.listBox_Paths2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox_Paths2.ForeColor = System.Drawing.Color.SteelBlue;
            this.listBox_Paths2.FormattingEnabled = true;
            this.listBox_Paths2.ItemHeight = 14;
            this.listBox_Paths2.Location = new System.Drawing.Point(4, 117);
            this.listBox_Paths2.Name = "listBox_Paths2";
            this.listBox_Paths2.ScrollAlwaysVisible = true;
            this.listBox_Paths2.Size = new System.Drawing.Size(525, 74);
            this.listBox_Paths2.TabIndex = 935;
            this.listBox_Paths2.Visible = false;
            // 
            // netResize1
            // 
            this.netResize1.ParentControl = this;
            // 
            // FrmEndYearsFiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(551, 291);
            this.ControlBox = false;
            this.Controls.Add(this.textBox_EndsPath);
            this.Controls.Add(this.listBox_Paths);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.listBox_Paths2);
            this.Name = "FrmEndYearsFiles";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmEndYearsFiles_Load);
            this.Shown += new System.EventHandler(this.FrmInvSale_Shown);
            this.SizeChanged += new System.EventHandler(this.FrmInvSale_SizeChanged);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }//###########&&&&&&&&&&

}
}
