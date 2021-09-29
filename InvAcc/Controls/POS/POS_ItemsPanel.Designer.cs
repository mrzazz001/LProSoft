
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.ItemsGride = new InvAcc.Controls.POS.POS_ItemsGride();
            this.HeaderPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // HeaderPanel
            // 
            this.HeaderPanel.Controls.Add(this.CategoryGride);
            this.HeaderPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.HeaderPanel.Location = new System.Drawing.Point(0, 0);
            this.HeaderPanel.Name = "HeaderPanel";
            this.HeaderPanel.Size = new System.Drawing.Size(671, 115);
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
            this.CategoryGride.Size = new System.Drawing.Size(671, 115);
            this.CategoryGride.TabIndex = 0;
            this.CategoryGride.Load += new System.EventHandler(this.poS_ItemsGride2_Load_1);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightGreen;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 120);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(671, 4);
            this.panel2.TabIndex = 3;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // ItemsGride
            // 
            this.ItemsGride.AutoScroll = true;
            this.ItemsGride.BackColor = System.Drawing.Color.White;
            this.ItemsGride.CAT_ID = 0;
            this.ItemsGride.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ItemsGride.EnableFilterSearch = true;
            this.ItemsGride.HorizantalBarVisable = false;
            this.ItemsGride.Location = new System.Drawing.Point(0, 115);
            this.ItemsGride.Margin = new System.Windows.Forms.Padding(0);
            this.ItemsGride.Name = "ItemsGride";
            this.ItemsGride.PagesEnable = false;
            this.ItemsGride.selectStatement = "";
            this.ItemsGride.Size = new System.Drawing.Size(671, 115);
            this.ItemsGride.TabIndex = 1;
            this.ItemsGride.Load += new System.EventHandler(this.ItemsGride_Load);
            this.ItemsGride.Click += new System.EventHandler(this.ItemsGride_Click);
            // 
            // POS_ItemsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.ItemsGride);
            this.Controls.Add(this.HeaderPanel);
            this.Name = "POS_ItemsPanel";
            this.Size = new System.Drawing.Size(671, 230);
            this.Load += new System.EventHandler(this.POS_ItemsPanel_Load);
            this.HeaderPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

    
        private System.Windows.Forms.Panel HeaderPanel;
        private POS_ItemsGride CategoryGride;
        private POS_ItemsGride ItemsGride;
        
        private System.Windows.Forms.Panel panel2;
 
    }
}
