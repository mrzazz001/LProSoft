using DevComponents.DotNetBar.Controls;
using InvAcc.GeneralM;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial class FrmTshfeer : Form
    {
        private IContainer components = null;
        private void netResize1_AfterControlResize(object sender, Softgroup.NetResize.AfterControlResizeEventArgs e)
        {
            if (e.Control.GetType() == typeof(Label))
            {
                Label c = (e.Control as Label); if ((c.BackColor != System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))))) && (c.BackColor != System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))))) && (c.BackColor != System.Drawing.Color.SteelBlue))
                    c.BackColor = Color.Transparent; Size cc = c.PreferredSize;
                c.AutoSize = false;
                c.Size = cc;

                //  e.Control.Font= new System.Drawing.Font("Tahoma",(float) (c-0.5));

            }
        }


        private void FrmInvSale_Shown(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            this.WindowState = FormWindowState.Maximized;
        }

        private void FrmInvSale_SizeChanged(object sender, EventArgs e)
        {
            netResize1.Refresh();
        }

        public Softgroup.NetResize.NetResize netResize1;

        private TextBox textBox1;
        private Button button1;
        private Button button2;
        private TextBox textBox3;
        private SlidePanel slidePanel1;
        private Line line1;
        private Button button3;
        private TextBox textBox4;
        private TextBox textBox2;
        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        private void InitializeComponent()
        {
            textBox1 = new System.Windows.Forms.TextBox();
            components = new System.ComponentModel.Container();

            button1 = new System.Windows.Forms.Button();
            button2 = new System.Windows.Forms.Button();
            textBox3 = new System.Windows.Forms.TextBox();
            slidePanel1 = new DevComponents.DotNetBar.Controls.SlidePanel();
            textBox4 = new System.Windows.Forms.TextBox();
            textBox2 = new System.Windows.Forms.TextBox();
            line1 = new DevComponents.DotNetBar.Controls.Line();
            button3 = new System.Windows.Forms.Button();
            this.netResize1 = new Softgroup.NetResize.NetResize(this.components);
            this.netResize1.AfterControlResize += new Softgroup.NetResize.NetResize.AfterControlResizeEventHandler(this.netResize1_AfterControlResize);
            this.Shown += new System.EventHandler(this.FrmInvSale_Shown);
            this.SizeChanged += new System.EventHandler(this.FrmInvSale_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).BeginInit();

            slidePanel1.SuspendLayout();
            SuspendLayout();
            textBox1.Font = new System.Drawing.Font("Tahoma", 8f, System.Drawing.FontStyle.Bold);
            textBox1.Location = new System.Drawing.Point(12, 13);
            textBox1.Name = "textBox1";
            textBox1.Size = new System.Drawing.Size(484, 20);
            textBox1.TabIndex = 0;
            textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            textBox1.Click += new System.EventHandler(textBox1_Click);
            button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            button1.Location = new System.Drawing.Point(18, 77);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(478, 41);
            button1.TabIndex = 1;
            button1.Text = "تشفير";
            button1.UseVisualStyleBackColor = true;
            button1.Click += new System.EventHandler(button1_Click);
            button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            button2.Location = new System.Drawing.Point(12, 205);
            button2.Name = "button2";
            button2.Size = new System.Drawing.Size(484, 41);
            button2.TabIndex = 3;
            button2.Text = "فك التشفير";
            button2.UseVisualStyleBackColor = true;
            button2.Click += new System.EventHandler(button2_Click);
            textBox3.Font = new System.Drawing.Font("Tahoma", 8f, System.Drawing.FontStyle.Bold);
            textBox3.Location = new System.Drawing.Point(12, 146);
            textBox3.Name = "textBox3";
            textBox3.Size = new System.Drawing.Size(484, 20);
            textBox3.TabIndex = 2;
            textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            textBox3.Click += new System.EventHandler(textBox3_Click);
            slidePanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            slidePanel1.Controls.Add(textBox4);
            slidePanel1.Controls.Add(textBox2);
            slidePanel1.Controls.Add(line1);
            slidePanel1.Controls.Add(button2);
            slidePanel1.Controls.Add(textBox3);
            slidePanel1.Controls.Add(button1);
            slidePanel1.Controls.Add(textBox1);
            slidePanel1.Location = new System.Drawing.Point(10, 11);
            slidePanel1.Name = "slidePanel1";
            slidePanel1.Size = new System.Drawing.Size(511, 253);
            slidePanel1.TabIndex = 4;
            slidePanel1.Text = "slidePanel1";
            slidePanel1.UsesBlockingAnimation = false;
            textBox4.Font = new System.Drawing.Font("Tahoma", 8f, System.Drawing.FontStyle.Bold);
            textBox4.Location = new System.Drawing.Point(12, 177);
            textBox4.Name = "textBox4";
            textBox4.Size = new System.Drawing.Size(484, 20);
            textBox4.TabIndex = 6;
            textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            textBox4.Click += new System.EventHandler(textBox4_Click);
            textBox2.Font = new System.Drawing.Font("Tahoma", 8f, System.Drawing.FontStyle.Bold);
            textBox2.Location = new System.Drawing.Point(12, 47);
            textBox2.Name = "textBox2";
            textBox2.Size = new System.Drawing.Size(484, 20);
            textBox2.TabIndex = 5;
            textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            textBox2.Click += new System.EventHandler(textBox2_Click);
            line1.Location = new System.Drawing.Point(-1, 127);
            line1.Name = "line1";
            line1.Size = new System.Drawing.Size(511, 9);
            line1.TabIndex = 4;
            line1.Text = "line1";
            line1.Thickness = 3;
            button3.Location = new System.Drawing.Point(10, 271);
            button3.Name = "button3";
            button3.Size = new System.Drawing.Size(512, 41);
            button3.TabIndex = 5;
            button3.Text = "خـــــــــروج";
            button3.UseVisualStyleBackColor = true;
            button3.Click += new System.EventHandler(button3_Click);
            base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            base.ClientSize = new System.Drawing.Size(529, 316);
            base.ControlBox = false;
            base.Controls.Add(button3);
            base.Controls.Add(slidePanel1);
            base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            base.MaximizeBox = false;
            base.Name = "FrmTshfeer";
            RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            RightToLeftLayout = true;
            base.ShowIcon = false;
            base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            slidePanel1.ResumeLayout(false);
            slidePanel1.PerformLayout();
            ResumeLayout(false);
        }
        public FrmTshfeer()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                textBox2.Text = VarGeneral.Encrypt(textBox1.Text);
            }
            catch
            {
                textBox1.Text = "";
                textBox2.Text = "";
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                textBox4.Text = VarGeneral.Decrypt(textBox3.Text);
            }
            catch
            {
                textBox3.Text = "";
                textBox4.Text = "";
            }
        }
        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.SelectAll();
        }
        private void textBox2_Click(object sender, EventArgs e)
        {
            textBox2.SelectAll();
        }
        private void textBox3_Click(object sender, EventArgs e)
        {
            textBox3.SelectAll();
        }
        private void textBox4_Click(object sender, EventArgs e)
        {
            textBox4.SelectAll();
        }
    }
}
