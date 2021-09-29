namespace InvAcc.Forms
{
    partial class BackupAlarm
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
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.c1Button1 = new C1.Win.C1Input.C1Button();
         
            ((System.ComponentModel.ISupportInitialize)(this.c1Button1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 127);
            this.splitter1.TabIndex = 0;
            this.splitter1.TabStop = false;
            // 
            // c1Button1
            // 
            this.c1Button1.BackColor = System.Drawing.Color.Transparent;
            this.c1Button1.BackgroundImage = global::InvAcc.Properties.Resources.close;
            this.c1Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.c1Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.c1Button1.Location = new System.Drawing.Point(319, 4);
            this.c1Button1.Name = "c1Button1";
            this.c1Button1.Size = new System.Drawing.Size(29, 26);
            this.c1Button1.TabIndex = 1;
            this.c1Button1.UseVisualStyleBackColor = false;
            this.c1Button1.Click += new System.EventHandler(this.c1Button1_Click);
            // 
            // colorButton1
            // 
            // 
            // BackupAlarm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::InvAcc.Properties.Resources.backupalert;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(358, 127);
         //   this.Controls.Add(this.colorButton1);
            this.Controls.Add(this.c1Button1);
            this.Controls.Add(this.splitter1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BackupAlarm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "BackupAlarm";
            this.Load += new System.EventHandler(this.BackupAlarm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.c1Button1)).EndInit();
            this.Icon = ((System.Drawing.Icon)(InvAcc.Properties.Resources.favicon));
this.ResumeLayout(false);

        }
        #endregion
        private System.Windows.Forms.Splitter splitter1;
        private C1.Win.C1Input.C1Button c1Button1;
      
    }
}
