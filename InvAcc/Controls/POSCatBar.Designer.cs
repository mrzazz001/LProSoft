namespace InvAcc.Controls
{
    partial class POSCatBar
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
            this.metroTilePanel_Cat = new DevComponents.DotNetBar.Metro.MetroTilePanel();
            this.DisplayedITemSet = new DevComponents.DotNetBar.ItemContainer();
            this.Button_Previous = new DevComponents.DotNetBar.ButtonX();
            this.Button_Next = new DevComponents.DotNetBar.ButtonX();
            this.SuspendLayout();
            // 
            // metroTilePanel_Cat
            // 
            this.metroTilePanel_Cat.AlwaysDisplayKeyAccelerators = true;
            this.metroTilePanel_Cat.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.metroTilePanel_Cat.BackgroundStyle.Class = "RibbonFileMenuTwoColumnContainer";
            this.metroTilePanel_Cat.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.metroTilePanel_Cat.ContainerControlProcessDialogKey = true;
            this.metroTilePanel_Cat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroTilePanel_Cat.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center;
            this.metroTilePanel_Cat.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.DisplayedITemSet});
            this.metroTilePanel_Cat.Tag= "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.metroTilePanel_Cat.Location = new System.Drawing.Point(102, 0);
            this.metroTilePanel_Cat.Name = "metroTilePanel_Cat";
            this.metroTilePanel_Cat.ShowShortcutKeysInToolTips = true;
            this.metroTilePanel_Cat.Size = new System.Drawing.Size(662, 88);
            this.metroTilePanel_Cat.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.metroTilePanel_Cat.TabIndex = 1150;
            // 
            // DisplayedITemSet
            // 
            this.DisplayedITemSet.AccessibleRole = System.Windows.Forms.AccessibleRole.ListItem;
            // 
            // 
            // 
            this.DisplayedITemSet.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.DisplayedITemSet.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center;
            this.DisplayedITemSet.Name = "DisplayedITemSet";
            // 
            // 
            // 
            this.DisplayedITemSet.TitleStyle.BorderBottomWidth = 1;
            this.DisplayedITemSet.TitleStyle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.DisplayedITemSet.TitleStyle.BorderLeftWidth = 1;
            this.DisplayedITemSet.TitleStyle.BorderRightWidth = 1;
            this.DisplayedITemSet.TitleStyle.BorderTopWidth = 1;
            this.DisplayedITemSet.TitleStyle.Class = "MetroTileGroupTitle";
            this.DisplayedITemSet.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.DisplayedITemSet.TitleStyle.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.DisplayedITemSet.TitleStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.DisplayedITemSet.TitleStyle.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.DisplayedITemSet.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle;
            // 
            // Button_Previous
            // 
            this.Button_Previous.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.Button_Previous.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.Button_Previous.Dock = System.Windows.Forms.DockStyle.Right;
            this.Button_Previous.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.Button_Previous.Location = new System.Drawing.Point(764, 0);
            this.Button_Previous.Name = "Button_Previous";
            this.Button_Previous.Size = new System.Drawing.Size(102, 88);
            this.Button_Previous.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.Button_Previous.Symbol = "";
            this.Button_Previous.SymbolSize = 12F;
            this.Button_Previous.TabIndex = 1199;
            this.Button_Previous.TextColor = System.Drawing.Color.SteelBlue;
            // 
            // Button_Next
            // 
            this.Button_Next.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.Button_Next.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.Button_Next.Dock = System.Windows.Forms.DockStyle.Left;
            this.Button_Next.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.Button_Next.Location = new System.Drawing.Point(0, 0);
            this.Button_Next.Name = "Button_Next";
            this.Button_Next.Size = new System.Drawing.Size(102, 88);
            this.Button_Next.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.Button_Next.Symbol = "";
            this.Button_Next.SymbolSize = 12F;
            this.Button_Next.TabIndex = 1200;
            this.Button_Next.TextColor = System.Drawing.Color.SteelBlue;
            this.Button_Next.Click += new System.EventHandler(this.Button_Next_Click);
            // 
            // POSCatBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.metroTilePanel_Cat);
            this.Controls.Add(this.Button_Next);
            this.Controls.Add(this.Button_Previous);
            this.Name = "POSCatBar";
            this.Size = new System.Drawing.Size(866, 88);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Metro.MetroTilePanel metroTilePanel_Cat;
        private DevComponents.DotNetBar.ItemContainer DisplayedITemSet;
        private DevComponents.DotNetBar.ButtonX Button_Previous;
        private DevComponents.DotNetBar.ButtonX Button_Next;
    }
}
