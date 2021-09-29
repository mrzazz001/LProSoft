using InvAcc.GeneralM;
using System;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial  class Alert : Form
    { void avs(int arln)

{ 
 Text = "Alert";this.Text=   (arln == 0 ? "  Alert  " : "  Alert") ;}
        private void langloads(object sender, EventArgs e)
        {
             avs(GeneralM.VarGeneral.currentintlanguage);
        }
   
        string message;
        public Alert(string s)
        {
            InitializeComponent();this.Load += langloads;
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
