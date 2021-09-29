namespace InvAcc.Forms
{
    partial class ContactUsForm
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
            this.c1Button1 = new C1.Win.C1Input.C1Button();
            ((System.ComponentModel.ISupportInitialize)(this.c1Button1)).BeginInit();
            this.SuspendLayout();
            // 
            // c1Button1
            // 
            this.c1Button1.BackColor = System.Drawing.Color.Transparent;
            this.c1Button1.BackgroundImage = global::InvAcc.Properties.Resources.close;
            this.c1Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.c1Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.c1Button1.Location = new System.Drawing.Point(390, 4);
            this.c1Button1.Name = "c1Button1";
            this.c1Button1.Size = new System.Drawing.Size(19, 18);
            this.c1Button1.TabIndex = 2;
            this.c1Button1.UseVisualStyleBackColor = false;
            this.c1Button1.Click += new System.EventHandler(this.c1Button1_Click);
            // 
            // ContactUsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::InvAcc.Properties.Resources.contact;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(412, 189);
            this.Controls.Add(this.c1Button1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ContactUsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "ContactUsForm";
            this.Load += new System.EventHandler(this.ContactUsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.c1Button1)).EndInit();
            this.Icon = ((System.Drawing.Icon)(InvAcc.Properties.Resources.favicon));
this.ResumeLayout(false);
        }
        #endregion
        private C1.Win.C1Input.C1Button c1Button1;
    }
}
