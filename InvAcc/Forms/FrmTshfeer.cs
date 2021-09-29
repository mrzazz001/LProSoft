using DevComponents.DotNetBar.Controls;
using InvAcc.GeneralM;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial  class FrmTshfeer : Form
    { void avs(int arln)

{ 
 Text = "تشفير";this.Text=   (arln == 0 ? "  تشفير  " : "  cipher") ; Text = "فك التشفير";this.Text=   (arln == 0 ? "  فك التشفير  " : "  decoding") ; Text = "slidePanel1";this.Text=   (arln == 0 ? "  slidePanel1  " : "  slidePanel1") ; Text = "line1";this.Text=   (arln == 0 ? "  line1  " : "  line1") ; Text = "خـــــــــروج";this.Text=   (arln == 0 ? "  خـــــــــروج  " : "  exit") ;}
        private void langloads(object sender, EventArgs e)
        {
             avs(GeneralM.VarGeneral.currentintlanguage);
        }
   
       // private IContainer components = null;
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
        public FrmTshfeer()
        {
            InitializeComponent();this.Load += langloads;
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
