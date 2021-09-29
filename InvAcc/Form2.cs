using System;
using System.Windows.Forms;

namespace InvAcc
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();//this.Load += langloads;
        }

        private void txtCustNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void exPanel1_Load(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            exPanel1.init();
        }
    }
}
