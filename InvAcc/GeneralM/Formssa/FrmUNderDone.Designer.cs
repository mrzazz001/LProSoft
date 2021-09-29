namespace InvAcc.Forms
{
    partial class FrmUNderDone
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
            DevComponents.DotNetBar.Rendering.SuperTabColorTable superTabColorTable1 = new DevComponents.DotNetBar.Rendering.SuperTabColorTable();
            DevComponents.DotNetBar.Rendering.SuperTabLinearGradientColorTable superTabLinearGradientColorTable1 = new DevComponents.DotNetBar.Rendering.SuperTabLinearGradientColorTable();
            this.switchButtonItem_Exit = new DevComponents.DotNetBar.SwitchButtonItem();
            this.switchButtonItem1 = new DevComponents.DotNetBar.SwitchButtonItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.InvDetails = new DevComponents.DotNetBar.SuperTabControl();
            this.switchButtonItem2 = new DevComponents.DotNetBar.SwitchButtonItem();
            this.exPanel1 = new InvAcc.Controls.EXPanel();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.InvDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // switchButtonItem_Exit
            // 
            this.switchButtonItem_Exit.BeginGroup = true;
            this.switchButtonItem_Exit.ButtonWidth = 220;
            this.switchButtonItem_Exit.Name = "switchButtonItem_Exit";
            this.switchButtonItem_Exit.OffBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(80)))), ((int)(((byte)(77)))));
            this.switchButtonItem_Exit.OffText = "إيقاف";
            this.switchButtonItem_Exit.OnText = "إيقاف النظام";
            this.switchButtonItem_Exit.SwitchWidth = 50;
            this.switchButtonItem_Exit.Value = true;
            // 
            // switchButtonItem1
            // 
            this.switchButtonItem1.BeginGroup = true;
            this.switchButtonItem1.ButtonWidth = 220;
            this.switchButtonItem1.Name = "switchButtonItem1";
            this.switchButtonItem1.OffBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(80)))), ((int)(((byte)(77)))));
            this.switchButtonItem1.OffText = "إيقاف";
            this.switchButtonItem1.OnText = "إيقاف النظام";
            this.switchButtonItem1.SwitchWidth = 50;
            this.switchButtonItem1.Value = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.InvDetails);
            this.splitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.splitContainer1.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel1_Paint);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.exPanel1);
            this.splitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.splitContainer1.Size = new System.Drawing.Size(800, 450);
            this.splitContainer1.SplitterDistance = 25;
            this.splitContainer1.TabIndex = 0;
            // 
            // InvDetails
            // 
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
            this.InvDetails.Size = new System.Drawing.Size(800, 25);
            this.InvDetails.TabFont = new System.Drawing.Font("Tahoma", 8F);
            this.InvDetails.TabIndex = 1026;
            this.InvDetails.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.switchButtonItem2});
            superTabLinearGradientColorTable1.Colors = new System.Drawing.Color[] {
        System.Drawing.Color.Gainsboro};
            superTabColorTable1.Background = superTabLinearGradientColorTable1;
            this.InvDetails.TabStripColor = superTabColorTable1;
            this.InvDetails.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.WinMediaPlayer12;
            this.InvDetails.Text = "superTabControl3";
            // 
            // switchButtonItem2
            // 
            this.switchButtonItem2.BeginGroup = true;
            this.switchButtonItem2.ButtonWidth = 220;
            this.switchButtonItem2.Name = "switchButtonItem2";
            this.switchButtonItem2.OffBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(80)))), ((int)(((byte)(77)))));
            this.switchButtonItem2.OffText = "إيقاف";
            this.switchButtonItem2.OnText = "إيقاف النظام";
            this.switchButtonItem2.SwitchWidth = 50;
            this.switchButtonItem2.Value = true;
            this.switchButtonItem2.ValueChanged += new System.EventHandler(this.switchButtonItem2_ValueChanged);
            // 
            // exPanel1
            // 
            this.exPanel1.AutoScroll = true;
            this.exPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.exPanel1.Location = new System.Drawing.Point(0, 0);
            this.exPanel1.Name = "exPanel1";
            this.exPanel1.Size = new System.Drawing.Size(800, 421);
            this.exPanel1.TabIndex = 0;
            this.exPanel1.Load += new System.EventHandler(this.exPanel1_Load_1);
            // 
            // FrmUNderDone
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "FrmUNderDone";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "شاشة التنفيذ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmUNderDone_Load);
            this.SizeChanged += new System.EventHandler(this.FrmUNderDone_SizeChanged);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.InvDetails)).EndInit();
            this.Icon = ((System.Drawing.Icon)(InvAcc.Properties.Resources.favicon));
this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.SwitchButtonItem switchButtonItem_Exit;
        private DevComponents.DotNetBar.SwitchButtonItem switchButtonItem1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private DevComponents.DotNetBar.SuperTabControl InvDetails;
        private DevComponents.DotNetBar.SwitchButtonItem switchButtonItem2;
        private Controls.EXPanel exPanel1;
    }
}