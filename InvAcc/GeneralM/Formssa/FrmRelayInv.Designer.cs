   

namespace InvAcc.Forms
{
partial class FrmRelayInv
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InvAcc.Forms.FrmRelayInv));
            components = new System.ComponentModel.Container();

            groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            buttonX_Close = new DevComponents.DotNetBar.ButtonX();
            ButOk = new DevComponents.DotNetBar.ButtonX();
            CmbUser = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            label3 = new System.Windows.Forms.Label();
            groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            label_Balance = new System.Windows.Forms.Label();
            this.netResize1 = new Softgroup.NetResize.NetResize(this.components);
            this.netResize1.AfterControlResize += new Softgroup.NetResize.NetResize.AfterControlResizeEventHandler(this.netResize1_AfterControlResize);
            this.Shown += new System.EventHandler(this.FrmInvSale_Shown);
            this.SizeChanged += new System.EventHandler(this.FrmInvSale_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).BeginInit();

            groupPanel2.SuspendLayout();
            groupPanel1.SuspendLayout();
            SuspendLayout();
            groupPanel2.AccessibleDescription = null;
            groupPanel2.AccessibleName = null;
            resources.ApplyResources(groupPanel2, "groupPanel2");
            groupPanel2.BackColor = System.Drawing.Color.Transparent;
            groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            groupPanel2.Controls.Add(buttonX_Close);
            groupPanel2.Controls.Add(ButOk);
            groupPanel2.Controls.Add(CmbUser);
            groupPanel2.Controls.Add(label3);
            groupPanel2.Font = null;
            groupPanel2.Name = "groupPanel2";
            groupPanel2.Style.BackColor2 = System.Drawing.SystemColors.GradientInactiveCaption;
            groupPanel2.Style.BackColorGradientAngle = 90;
            groupPanel2.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            groupPanel2.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            groupPanel2.Style.BorderBottomWidth = 1;
            groupPanel2.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            groupPanel2.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            groupPanel2.Style.BorderLeftWidth = 1;
            groupPanel2.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            groupPanel2.Style.BorderRightWidth = 1;
            groupPanel2.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            groupPanel2.Style.BorderTopWidth = 1;
            groupPanel2.Style.CornerDiameter = 4;
            groupPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            groupPanel2.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            groupPanel2.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            groupPanel2.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            groupPanel2.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            groupPanel2.TitleImagePosition = DevComponents.DotNetBar.eTitleImagePosition.Center;
            buttonX_Close.AccessibleDescription = null;
            buttonX_Close.AccessibleName = null;
            buttonX_Close.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            resources.ApplyResources(buttonX_Close, "buttonX_Close");
            buttonX_Close.BackgroundImage = null;
            buttonX_Close.Checked = true;
            buttonX_Close.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            buttonX_Close.CommandParameter = null;
            buttonX_Close.Name = "buttonX_Close";
            buttonX_Close.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            buttonX_Close.Symbol = "\uf011";
            buttonX_Close.TextColor = System.Drawing.Color.SteelBlue;
            buttonX_Close.Click += new System.EventHandler(buttonX_Close_Click);
            ButOk.AccessibleDescription = null;
            ButOk.AccessibleName = null;
            ButOk.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            resources.ApplyResources(ButOk, "ButOk");
            ButOk.BackgroundImage = null;
            ButOk.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            ButOk.CommandParameter = null;
            ButOk.Name = "ButOk";
            ButOk.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            ButOk.Symbol = "\uf00c";
            ButOk.SymbolSize = 16f;
            ButOk.TextColor = System.Drawing.Color.White;
            ButOk.Click += new System.EventHandler(ButOk_Click);
            CmbUser.AccessibleDescription = null;
            CmbUser.AccessibleName = null;
            resources.ApplyResources(CmbUser, "CmbUser");
            CmbUser.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            CmbUser.BackgroundImage = null;
            CmbUser.CommandParameter = null;
            CmbUser.DisplayMember = "Text";
            CmbUser.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            CmbUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            CmbUser.Font = null;
            CmbUser.FormattingEnabled = true;
            CmbUser.Name = "CmbUser";
            CmbUser.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            CmbUser.SelectedIndexChanged += new System.EventHandler(CmbUser_SelectedIndexChanged);
            label3.AccessibleDescription = null;
            label3.AccessibleName = null;
            resources.ApplyResources(label3, "label3");
            label3.Font = null;
            label3.Name = "label3";
            groupPanel1.AccessibleDescription = null;
            groupPanel1.AccessibleName = null;
            resources.ApplyResources(groupPanel1, "groupPanel1");
            groupPanel1.BackColor = System.Drawing.Color.Transparent;
            groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            groupPanel1.Controls.Add(label_Balance);
            groupPanel1.Font = null;
            groupPanel1.Name = "groupPanel1";
            groupPanel1.Style.BackColor2 = System.Drawing.SystemColors.GradientInactiveCaption;
            groupPanel1.Style.BackColorGradientAngle = 90;
            groupPanel1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            groupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            groupPanel1.Style.BorderBottomWidth = 1;
            groupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            groupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            groupPanel1.Style.BorderLeftWidth = 1;
            groupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            groupPanel1.Style.BorderRightWidth = 1;
            groupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            groupPanel1.Style.BorderTopWidth = 1;
            groupPanel1.Style.CornerDiameter = 4;
            groupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            groupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            groupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            groupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            groupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            groupPanel1.TitleImagePosition = DevComponents.DotNetBar.eTitleImagePosition.Right;
            label_Balance.AccessibleDescription = null;
            label_Balance.AccessibleName = null;
            resources.ApplyResources(label_Balance, "label_Balance");
            label_Balance.BackColor = System.Drawing.Color.WhiteSmoke;
            label_Balance.ForeColor = System.Drawing.Color.Red;
            label_Balance.Name = "label_Balance";
            base.AccessibleDescription = null;
            base.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.SteelBlue;
            BackgroundImage = null;
            base.Controls.Add(groupPanel1);
            base.Controls.Add(groupPanel2);
            Font = null;
            base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            base.KeyPreview = true;
            base.MaximizeBox = false;
            base.Name = "FrmRelayInv";
            base.Load += new System.EventHandler(FrmRelayInv_Load);
            base.KeyDown += new System.Windows.Forms.KeyEventHandler(FrmRelayInv_KeyDown);
            groupPanel2.ResumeLayout(false);
            groupPanel2.PerformLayout();
            groupPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }//###########&&&&&&&&&&

}
}
