
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.ItemsGride = new InvAcc.Controls.POS.POS_ItemsGride();
            this.HeaderPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // HeaderPanel
            // 
            this.HeaderPanel.Controls.Add(this.CategoryGride);
            this.HeaderPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.HeaderPanel.Location = new System.Drawing.Point(0, 0);
            this.HeaderPanel.Name = "HeaderPanel";
            this.HeaderPanel.Size = new System.Drawing.Size(576, 115);
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
            this.CategoryGride.Size = new System.Drawing.Size(576, 115);
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
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.IndianRed;
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 229);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(576, 31);
            this.panel1.TabIndex = 2;
            this.panel1.Visible = false;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.simpleButton2);
            this.panel3.Controls.Add(this.simpleButton1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(108, 31);
            this.panel3.TabIndex = 6;
            // 
            // simpleButton2
            // 
            this.simpleButton2.Appearance.Options.UseImage = true;
            this.simpleButton2.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButton2.ImageOptions.Image = global::InvAcc.Properties.Resources.next_32x32;
            this.simpleButton2.Location = new System.Drawing.Point(61, 0);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(47, 31);
            this.simpleButton2.TabIndex = 1;
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Dock = System.Windows.Forms.DockStyle.Left;
            this.simpleButton1.ImageOptions.Image = global::InvAcc.Properties.Resources.prev_32x32;
            this.simpleButton1.Location = new System.Drawing.Point(0, 0);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(49, 31);
            this.simpleButton1.TabIndex = 0;
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
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
            this.ItemsGride.Size = new System.Drawing.Size(576, 114);
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
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.HeaderPanel);
            this.Name = "POS_ItemsPanel";
            this.Size = new System.Drawing.Size(576, 260);
            this.Load += new System.EventHandler(this.POS_ItemsPanel_Load);
            this.SizeChanged += new System.EventHandler(this.POS_ItemsPanel_SizeChanged);
            this.HeaderPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

    
        private System.Windows.Forms.Panel HeaderPanel;
        private POS_ItemsGride CategoryGride;
        private POS_ItemsGride ItemsGride;
        
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
    }
}
