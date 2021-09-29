namespace InvAcc.Controls
{
    partial class CarInvData
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
            DevComponents.DotNetBar.Rendering.SuperTabColorTable superTabColorTable1 = new DevComponents.DotNetBar.Rendering.SuperTabColorTable();
            DevComponents.DotNetBar.Rendering.SuperTabLinearGradientColorTable superTabLinearGradientColorTable1 = new DevComponents.DotNetBar.Rendering.SuperTabLinearGradientColorTable();
            this.superTabItem_Gaids = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabItem_items = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabItem_Note = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabItem_Detiles = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabItem_Pay = new DevComponents.DotNetBar.SuperTabItem();
            this.InvDetails = new DevComponents.DotNetBar.SuperTabControl();
            this.OrderUnderExectuion = new DevComponents.DotNetBar.CheckBoxItem();
            this.OrderExectuionDone = new DevComponents.DotNetBar.CheckBoxItem();
            ((System.ComponentModel.ISupportInitialize)(this.InvDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // superTabItem_Gaids
            // 
            this.superTabItem_Gaids.GlobalItem = false;
            this.superTabItem_Gaids.Name = "superTabItem_Gaids";
            this.superTabItem_Gaids.Text = "القيود";
            // 
            // superTabItem_items
            // 
            this.superTabItem_items.GlobalItem = false;
            this.superTabItem_items.Name = "superTabItem_items";
            this.superTabItem_items.Text = "م.الصنف";
            // 
            // superTabItem_Note
            // 
            this.superTabItem_Note.GlobalItem = false;
            this.superTabItem_Note.Name = "superTabItem_Note";
            this.superTabItem_Note.Text = "ملاحظات";
            // 
            // superTabItem_Detiles
            // 
            this.superTabItem_Detiles.GlobalItem = false;
            this.superTabItem_Detiles.Name = "superTabItem_Detiles";
            this.superTabItem_Detiles.Text = "تفاصيل";
            // 
            // superTabItem_Pay
            // 
            this.superTabItem_Pay.GlobalItem = false;
            this.superTabItem_Pay.Name = "superTabItem_Pay";
            this.superTabItem_Pay.Text = "السند المحاسبي";
            // 
            // InvDetails
            // 
            this.InvDetails.BackColor = System.Drawing.SystemColors.ControlLight;
            // 
            // 
            // 
            // 
            // 
            // 
            this.InvDetails.ControlBox.CloseBox.Name = "";
            // 
            // 
            // 
            this.InvDetails.ControlBox.MenuBox.Name = "";
            this.InvDetails.ControlBox.Name = "";
            this.InvDetails.ControlBox.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.InvDetails.ControlBox.MenuBox,
            this.InvDetails.ControlBox.CloseBox});
            this.InvDetails.ControlBox.Visible = false;
            this.InvDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InvDetails.Location = new System.Drawing.Point(0, 0);
            this.InvDetails.Name = "InvDetails";
            this.InvDetails.ReorderTabsEnabled = true;
            this.InvDetails.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.InvDetails.SelectedTabFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.InvDetails.SelectedTabIndex = 0;
            this.InvDetails.Size = new System.Drawing.Size(670, 312);
            this.InvDetails.TabFont = new System.Drawing.Font("Tahoma", 8F);
            this.InvDetails.TabIndex = 1025;
            superTabLinearGradientColorTable1.Colors = new System.Drawing.Color[] {
        System.Drawing.Color.White};
            superTabColorTable1.Background = superTabLinearGradientColorTable1;
            this.InvDetails.TabStripColor = superTabColorTable1;
            this.InvDetails.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.WinMediaPlayer12;
            this.InvDetails.Text = "superTabControl3";
            this.InvDetails.SelectedTabChanged += new System.EventHandler<DevComponents.DotNetBar.SuperTabStripSelectedTabChangedEventArgs>(this.InvDetails_SelectedTabChanged);
            // 
            // OrderUnderExectuion
            // 
            this.OrderUnderExectuion.Name = "OrderUnderExectuion";
            this.OrderUnderExectuion.Text = "تحت التنفيذ";
            // 
            // OrderExectuionDone
            // 
            this.OrderExectuionDone.Name = "OrderExectuionDone";
            this.OrderExectuionDone.Text = "تم التنفيذ";
            // 
            // CarInvData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.InvDetails);
            this.Name = "CarInvData";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(670, 312);
            this.Load += new System.EventHandler(this.CarInvData_Load);
            ((System.ComponentModel.ISupportInitialize)(this.InvDetails)).EndInit();
          //  this.Icon = ((System.Drawing.Icon)(InvAcc.Properties.Resources.favicon));
this.ResumeLayout(false);

        }

        #endregion
        private DevComponents.DotNetBar.SuperTabItem superTabItem_Gaids;
        private DevComponents.DotNetBar.SuperTabItem superTabItem_items;
        private DevComponents.DotNetBar.SuperTabItem superTabItem_Note;
        private DevComponents.DotNetBar.SuperTabItem superTabItem_Detiles;
        private DevComponents.DotNetBar.SuperTabItem superTabItem_Pay;
        private DevComponents.DotNetBar.SuperTabControl InvDetails;
        private DevComponents.DotNetBar.SwitchButtonItem OrderStatusSwitch;
    }
}
