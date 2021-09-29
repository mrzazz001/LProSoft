   

namespace InvAcc.Forms
{
partial class FrmShowPriceOption
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
            this.ribbonBar1 = new DevComponents.DotNetBar.RibbonBar();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.button_Unit2 = new DevComponents.DotNetBar.ButtonX();
            this.button_Close = new DevComponents.DotNetBar.ButtonX();
            this.button_Unit1 = new DevComponents.DotNetBar.ButtonX();
            this.ribbonBar1.SuspendLayout();
            this.groupPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ribbonBar1
            // 
            this.ribbonBar1.AutoOverflowEnabled = true;
            // 
            // 
            // 
            this.ribbonBar1.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar1.BackgroundStyle.BackColor = System.Drawing.Color.Gainsboro;
            this.ribbonBar1.BackgroundStyle.BackColor2 = System.Drawing.Color.Gainsboro;
            this.ribbonBar1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar1.ContainerControlProcessDialogKey = true;
            this.ribbonBar1.Controls.Add(this.groupPanel1);
            this.ribbonBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonBar1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.ribbonBar1.Location = new System.Drawing.Point(0, 0);
            this.ribbonBar1.Name = "ribbonBar1";
            this.ribbonBar1.Size = new System.Drawing.Size(291, 173);
            this.ribbonBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this.ribbonBar1.TabIndex = 1143;
            // 
            // 
            // 
            this.ribbonBar1.TitleStyle.BackColor = System.Drawing.Color.Black;
            this.ribbonBar1.TitleStyle.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.ribbonBar1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar1.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // groupPanel1
            // 
            this.groupPanel1.BackColor = System.Drawing.Color.AliceBlue;
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.button_Unit2);
            this.groupPanel1.Controls.Add(this.button_Close);
            this.groupPanel1.Controls.Add(this.button_Unit1);
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.groupPanel1.Location = new System.Drawing.Point(0, 0);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(291, 156);
            // 
            // 
            // 
            this.groupPanel1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
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
            this.groupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel1.TabIndex = 0;
            this.groupPanel1.Text = "Options   -   خيارات";
            // 
            // button_Unit2
            // 
            this.button_Unit2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_Unit2.Checked = true;
            this.button_Unit2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_Unit2.Location = new System.Drawing.Point(4, 23);
            this.button_Unit2.Name = "button_Unit2";
            this.button_Unit2.Size = new System.Drawing.Size(142, 59);
            this.button_Unit2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_Unit2.TabIndex = 1174;
            this.button_Unit2.Text = "موردين | <font color=\"#BA1419\">Suppliers</font>";
            this.button_Unit2.Click += new System.EventHandler(this.button_Unit2_Click);
            // 
            // button_Close
            // 
            this.button_Close.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_Close.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.button_Close.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button_Close.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.button_Close.Location = new System.Drawing.Point(0, 88);
            this.button_Close.Name = "button_Close";
            this.button_Close.Size = new System.Drawing.Size(285, 45);
            this.button_Close.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_Close.Symbol = "";
            this.button_Close.SymbolSize = 18F;
            this.button_Close.TabIndex = 1162;
            this.button_Close.Text = "تـراجـع - Back";
            this.button_Close.TextColor = System.Drawing.Color.White;
            this.button_Close.Click += new System.EventHandler(this.button_Close_Click);
            // 
            // button_Unit1
            // 
            this.button_Unit1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_Unit1.Checked = true;
            this.button_Unit1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_Unit1.Location = new System.Drawing.Point(147, 23);
            this.button_Unit1.Name = "button_Unit1";
            this.button_Unit1.Size = new System.Drawing.Size(142, 59);
            this.button_Unit1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_Unit1.TabIndex = 1170;
            this.button_Unit1.Text = "عملاء | <font color=\"#BA1419\">Customers</font>";
            this.button_Unit1.Click += new System.EventHandler(this.button_Unit1_Click);
            // 
            // FrmShowPriceOption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(291, 173);
            this.ControlBox = false;
            this.Controls.Add(this.ribbonBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmShowPriceOption";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmShowPriceOption_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmShowPriceOption_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FrmShowPriceOption_KeyPress);
            this.ribbonBar1.ResumeLayout(false);
            this.groupPanel1.ResumeLayout(false);
            this.Icon = ((System.Drawing.Icon)(InvAcc.Properties.Resources.favicon));
            this.ResumeLayout(false);
        }//###########&&&&&&&&&&

}
}
