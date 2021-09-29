
namespace InvAcc.Controls.POS
{
    partial class POS_ItemsPanel
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

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.HeaderPanel = new System.Windows.Forms.Panel();
            this.CategoryGride = new InvAcc.Controls.POS.POS_ItemsGride();
//this.TexBoxFilter = new SearchTextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.ItemsGride = new InvAcc.Controls.POS.POS_ItemsGride();
            this.orientedButton1 = new InvAcc.Controls.POS.OrientedButton();
            this.HeaderPanel.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // HeaderPanel
            // 
            this.HeaderPanel.Controls.Add(this.CategoryGride);
            this.HeaderPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.HeaderPanel.Location = new System.Drawing.Point(0, 0);
            this.HeaderPanel.Name = "HeaderPanel";
            this.HeaderPanel.Size = new System.Drawing.Size(671, 120);
            this.HeaderPanel.TabIndex = 0;
            this.HeaderPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.HeaderPanel_Paint);
            // 
            // CategoryGride
            // 
            this.CategoryGride.AutoScroll = true;
            this.CategoryGride.BackColor = System.Drawing.Color.Black;
            this.CategoryGride.CAT_ID = 0;
            this.CategoryGride.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CategoryGride.EnableFilterSearch = true;
            this.CategoryGride.HorizantalBarVisable = false;
            this.CategoryGride.Location = new System.Drawing.Point(0, 0);
            this.CategoryGride.Margin = new System.Windows.Forms.Padding(0);
            this.CategoryGride.Name = "CategoryGride";
            this.CategoryGride.Padding = new System.Windows.Forms.Padding(1);
            this.CategoryGride.PagesEnable = false;
            this.CategoryGride.selectStatement = "SELECT       [CAT_ID],[CAT_No]      ,[Arb_Des] ,[Eng_Des],[CompanyID],[TotalPurch" +
    "aes],[TotalPoint],[CAT_Symbol],[CatImage]        FROM[dbo].[T_CATEGORY]";
            this.CategoryGride.Size = new System.Drawing.Size(671, 120);
            this.CategoryGride.TabIndex = 0;
            this.CategoryGride.Load += new System.EventHandler(this.poS_ItemsGride2_Load_1);
       
            this.panel2.BackColor = System.Drawing.Color.LightGreen;
            this.panel2.Controls.Add(this.button1);
           // this.panel2.Controls.Add(this.TexBoxFilter);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 120);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(671, 27);
            this.panel2.TabIndex = 3;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::InvAcc.Properties.Resources.currancy;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Location = new System.Drawing.Point(168, 1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(49, 26);
            this.button1.TabIndex = 6;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // ItemsGride
            // 
            this.ItemsGride.AutoScroll = true;
            this.ItemsGride.BackColor = System.Drawing.Color.Black;
            this.ItemsGride.CAT_ID = 0;
            this.ItemsGride.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ItemsGride.EnableFilterSearch = true;
            this.ItemsGride.HorizantalBarVisable = false;
            this.ItemsGride.Location = new System.Drawing.Point(0, 147);
            this.ItemsGride.Margin = new System.Windows.Forms.Padding(0);
            this.ItemsGride.Name = "ItemsGride";
            this.ItemsGride.Padding = new System.Windows.Forms.Padding(0);
            this.ItemsGride.PagesEnable = false;
            this.ItemsGride.selectStatement = "";
            this.ItemsGride.Size = new System.Drawing.Size(671, 241);
            this.ItemsGride.TabIndex = 1;
            this.ItemsGride.Load += new System.EventHandler(this.ItemsGride_Load);
            this.ItemsGride.Click += new System.EventHandler(this.ItemsGride_Click);
            // 
            // orientedButton1
            // 
            this.orientedButton1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.orientedButton1.Location = new System.Drawing.Point(0, 78);
            this.orientedButton1.Name = "orientedButton1";
            this.orientedButton1.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.orientedButton1.Size = new System.Drawing.Size(63, 124);
            this.orientedButton1.TabIndex = 0;
            this.orientedButton1.Text = "التصنيفات";
            this.orientedButton1.UseCompatibleTextRendering = true;
            this.orientedButton1.UseVisualStyleBackColor = false;
            this.orientedButton1.Click += new System.EventHandler(this.orientedButton1_Click);
            // 
            // POS_ItemsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.ItemsGride);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.HeaderPanel);
            this.Name = "POS_ItemsPanel";
            this.Size = new System.Drawing.Size(671, 388);
            this.Load += new System.EventHandler(this.POS_ItemsPanel_Load);
            this.HeaderPanel.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

      private OrientedButton orientedButton1;
        private System.Windows.Forms.Panel HeaderPanel;
        private POS_ItemsGride CategoryGride;
        private POS_ItemsGride ItemsGride;
        
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button1;
    }
}
