namespace InvAcc.Controls.POS
{
    partial class Pos_ItemPanel
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
            this.ItemsGride = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.arrowButton2 = new ArrowButton.ArrowButton();
            this.arrowButton1 = new ArrowButton.ArrowButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ItemsGride
            // 
            this.ItemsGride.ColumnCount = 2;
            this.ItemsGride.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.ItemsGride.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.ItemsGride.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ItemsGride.Location = new System.Drawing.Point(0, 0);
            this.ItemsGride.Name = "ItemsGride";
            this.ItemsGride.RowCount = 2;
            this.ItemsGride.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.ItemsGride.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.ItemsGride.Size = new System.Drawing.Size(658, 352);
            this.ItemsGride.TabIndex = 0;
            this.ItemsGride.Paint += new System.Windows.Forms.PaintEventHandler(this.ItemsGride_Paint);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.arrowButton2);
            this.panel1.Controls.Add(this.arrowButton1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 312);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(658, 40);
            this.panel1.TabIndex = 1;
            // 
            // arrowButton2
            // 
            this.arrowButton2.ArrowEnabled = true;
            this.arrowButton2.HoverEndColor = System.Drawing.Color.DarkRed;
            this.arrowButton2.HoverStartColor = System.Drawing.Color.WhiteSmoke;
            this.arrowButton2.Location = new System.Drawing.Point(575, 3);
            this.arrowButton2.Name = "arrowButton2";
            this.arrowButton2.NormalEndColor = System.Drawing.Color.Maroon;
            this.arrowButton2.NormalStartColor = System.Drawing.Color.WhiteSmoke;
            this.arrowButton2.Rotation = 270;
            this.arrowButton2.Size = new System.Drawing.Size(37, 37);
            this.arrowButton2.TabIndex = 3;
            this.arrowButton2.Text = "التالي";
            this.arrowButton2.Click += new System.EventHandler(this.arrowButton2_Click);
            // 
            // arrowButton1
            // 
            this.arrowButton1.ArrowEnabled = true;
            this.arrowButton1.HoverEndColor = System.Drawing.Color.DarkRed;
            this.arrowButton1.HoverStartColor = System.Drawing.Color.WhiteSmoke;
            this.arrowButton1.Location = new System.Drawing.Point(618, 3);
            this.arrowButton1.Name = "arrowButton1";
            this.arrowButton1.NormalEndColor = System.Drawing.Color.Maroon;
            this.arrowButton1.NormalStartColor = System.Drawing.Color.WhiteSmoke;
            this.arrowButton1.Rotation = 90;
            this.arrowButton1.Size = new System.Drawing.Size(37, 37);
            this.arrowButton1.TabIndex = 2;
            this.arrowButton1.Text = "السابق ";
            this.arrowButton1.Click += new System.EventHandler(this.arrowButton1_Click);
            // 
            // Pos_ItemPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ItemsGride);
            this.Name = "Pos_ItemPanel";
            this.Size = new System.Drawing.Size(658, 352);
            this.Load += new System.EventHandler(this.Pos_ItemPanel_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel ItemsGride;
        private System.Windows.Forms.Panel panel1;
        private ArrowButton.ArrowButton arrowButton2;
        private ArrowButton.ArrowButton arrowButton1;
    }
}
