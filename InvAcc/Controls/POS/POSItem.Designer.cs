namespace InvAcc.Controls
{
    partial class POSItem
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
            this.metroTileFrame1 = new DevComponents.DotNetBar.Metro.MetroTileFrame();
            this.Item_Image = new System.Windows.Forms.PictureBox();
            this.Item_Price = new TransparentLabel();
            this.Item_name = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.Item_Image)).BeginInit();
            this.SuspendLayout();
            // 
            // metroTileFrame1
            // 
            this.metroTileFrame1.Text = "dfjdsahflk skdfj sd filsd jflkjds lkf dsf ds fsdlk fldsfsd f sad fasdlkfjsdl f";
            this.metroTileFrame1.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Default;
            // 
            // 
            // 
            this.metroTileFrame1.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // Item_Image
            // 
            this.Item_Image.BackColor = System.Drawing.Color.White;
            this.Item_Image.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Item_Image.Image = global::InvAcc.Properties.Resources.NOIMAGE;
            this.Item_Image.Location = new System.Drawing.Point(0, 0);
            this.Item_Image.Name = "Item_Image";
            this.Item_Image.Size = new System.Drawing.Size(144, 78);
            this.Item_Image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Item_Image.TabIndex = 2;
            this.Item_Image.TabStop = false;
            this.Item_Image.Click += new System.EventHandler(this.Item_Image_Click);
            // 
            // Item_Price
            // 
            this.Item_Price.AutoEllipsis = true;
            this.Item_Price.AutoSize = true;
            this.Item_Price.BackColor = System.Drawing.Color.Transparent;
            this.Item_Price.Location = new System.Drawing.Point(57, 17);
            this.Item_Price.Name = "Item_Price";
            this.Item_Price.Opacity = 70;
            this.Item_Price.Size = new System.Drawing.Size(31, 13);
            this.Item_Price.TabIndex = 6;
            this.Item_Price.Text = "0000";
            this.Item_Price.TransparentBackColor = System.Drawing.Color.Blue;
            this.Item_Price.Click += new System.EventHandler(this.Item_Price_Click);
            // 
            // Item_name
            // 
            this.Item_name.Appearance.BorderColor = System.Drawing.Color.Black;
            this.Item_name.Appearance.Options.UseBorderColor = true;
            this.Item_name.Appearance.Options.UseTextOptions = true;
            this.Item_name.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Item_name.Appearance.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.Item_name.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.Item_name.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.Item_name.AppearanceHovered.BorderColor = System.Drawing.Color.Black;
            this.Item_name.AppearanceHovered.Options.UseBorderColor = true;
            this.Item_name.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.Item_name.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.Item_name.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Item_name.Location = new System.Drawing.Point(0, 78);
            this.Item_name.Name = "Item_name";
            this.Item_name.Size = new System.Drawing.Size(144, 33);
            this.Item_name.TabIndex = 7;
            // 
            // POSItem
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.Item_Image);
            this.Controls.Add(this.Item_name);
            this.Controls.Add(this.Item_Price);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximumSize = new System.Drawing.Size(300, 270);
            this.MinimumSize = new System.Drawing.Size(148, 115);
            this.Name = "POSItem";
            this.Size = new System.Drawing.Size(144, 111);
            ((System.ComponentModel.ISupportInitialize)(this.Item_Image)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.PictureBox Item_Image;
        public TransparentLabel Item_Price;
        public DevComponents.DotNetBar.Metro.MetroTileFrame metroTileFrame1;
        public DevExpress.XtraEditors.LabelControl Item_name;
    }
}
