namespace InvAcc.DroBoxSync
{
    partial class Frm_PrinterShow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_PrinterShow));
            this.groupPanel15 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.button2 = new System.Windows.Forms.Button();
            this.pintes = new System.Windows.Forms.RadioButton();
            this.A4 = new System.Windows.Forms.RadioButton();
            this.casher = new System.Windows.Forms.RadioButton();
            this.comboBoxEx1 = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.groupPanel15.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupPanel15
            // 
            this.groupPanel15.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel15.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel15.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel15.Controls.Add(this.comboBoxEx1);
            this.groupPanel15.Controls.Add(this.button2);
            this.groupPanel15.Controls.Add(this.pintes);
            this.groupPanel15.Controls.Add(this.A4);
            this.groupPanel15.Controls.Add(this.casher);
            resources.ApplyResources(this.groupPanel15, "groupPanel15");
            this.groupPanel15.Name = "groupPanel15";
            // 
            // 
            // 
            this.groupPanel15.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel15.Style.BackColorGradientAngle = 90;
            this.groupPanel15.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel15.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel15.Style.BorderBottomWidth = 1;
            this.groupPanel15.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel15.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel15.Style.BorderLeftWidth = 1;
            this.groupPanel15.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel15.Style.BorderRightWidth = 1;
            this.groupPanel15.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel15.Style.BorderTopWidth = 1;
            this.groupPanel15.Style.CornerDiameter = 4;
            this.groupPanel15.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel15.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel15.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel15.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel15.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel15.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel15.Click += new System.EventHandler(this.groupPanel15_Click);
            // 
            // button2
            // 
            resources.ApplyResources(this.button2, "button2");
            this.button2.Name = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // pintes
            // 
            resources.ApplyResources(this.pintes, "pintes");
            this.pintes.Name = "pintes";
            this.pintes.TabStop = true;
            this.pintes.UseVisualStyleBackColor = true;
            // 
            // A4
            // 
            resources.ApplyResources(this.A4, "A4");
            this.A4.Name = "A4";
            this.A4.TabStop = true;
            this.A4.UseVisualStyleBackColor = true;
            // 
            // casher
            // 
            resources.ApplyResources(this.casher, "casher");
            this.casher.Name = "casher";
            this.casher.TabStop = true;
            this.casher.UseVisualStyleBackColor = true;
            // 
            // comboBoxEx1
            // 
            this.comboBoxEx1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxEx1.DisplayMember = "Text";
            this.comboBoxEx1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxEx1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEx1.FormattingEnabled = true;
            resources.ApplyResources(this.comboBoxEx1, "comboBoxEx1");
            this.comboBoxEx1.Name = "comboBoxEx1";
            this.comboBoxEx1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            // 
            // Frm_PrinterShow
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupPanel15);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frm_PrinterShow";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Frm_PrinterShow_Load);
            this.groupPanel15.ResumeLayout(false);
            this.groupPanel15.PerformLayout();
            this.Icon = ((System.Drawing.Icon)(InvAcc.Properties.Resources.favicon));
this.ResumeLayout(false);

        }
        #endregion
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel15;
        private System.Windows.Forms.RadioButton pintes;
        private System.Windows.Forms.RadioButton A4;
        private System.Windows.Forms.RadioButton casher;
        private System.Windows.Forms.Button button2;
        private DevComponents.DotNetBar.Controls.ComboBoxEx comboBoxEx1;
    }
}
