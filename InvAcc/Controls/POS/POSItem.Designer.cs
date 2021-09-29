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
            this.Item_name = new TransparentLabel();
            this.Item_Price = new TransparentLabel();
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
            this.Item_Image.Size = new System.Drawing.Size(148, 115);
            this.Item_Image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Item_Image.TabIndex = 2;
            this.Item_Image.TabStop = false;
            this.Item_Image.Click += new System.EventHandler(this.Item_Image_Click);
            // 
            // Item_name
            // 
            this.Item_name.AutoEllipsis = true;
            this.Item_name.BackColor = System.Drawing.Color.Transparent;
            this.Item_name.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Item_name.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.Item_name.Location = new System.Drawing.Point(0, 81);
            this.Item_name.Name = "Item_name";
            this.Item_name.Opacity = 70;
            this.Item_name.Size = new System.Drawing.Size(148, 34);
            this.Item_name.TabIndex = 5;
            this.Item_name.Text = " fsga dsf saf asd f ads f ads f";
            this.Item_name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Item_name.TransparentBackColor = System.Drawing.Color.Blue;
            this.Item_name.Click += new System.EventHandler(this.Item_name_Click_2);
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
            // POSItem
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.Item_name);
            this.Controls.Add(this.Item_Price);
            this.Controls.Add(this.Item_Image);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximumSize = new System.Drawing.Size(300, 270);
            this.MinimumSize = new System.Drawing.Size(148, 115);
            this.Name = "POSItem";
            this.Size = new System.Drawing.Size(148, 115);
            ((System.ComponentModel.ISupportInitialize)(this.Item_Image)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.PictureBox Item_Image;
        public TransparentLabel Item_name;
        public TransparentLabel Item_Price;
        private DevComponents.DotNetBar.Metro.MetroTileFrame metroTileFrame1;
    }
}
