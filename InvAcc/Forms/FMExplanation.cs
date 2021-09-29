using InvAcc.GeneralM;
using System;
using System.ComponentModel;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial  class FMExplanation : Form
    { void avs(int arln)

{ 
}
        private void langloads(object sender, EventArgs e)
        {
             avs(GeneralM.VarGeneral.currentintlanguage);
        }
   
       // private IContainer components = null;
        private Button button1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
        public FMExplanation(int Lang)
        {
            InitializeComponent();this.Load += langloads;
            if (Lang == 0)
            {
                pictureBox2.Visible = true;
            }
            else
            {
                pictureBox1.Visible = true;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }
    }
}
