using System;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial class Alert : Form
    {
        string message;
        public Alert(string s)
        {
            InitializeComponent();
            message = s;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Alert_Load(object sender, EventArgs e)
        {
            textBox1.Text = message;
        }
    }
}
