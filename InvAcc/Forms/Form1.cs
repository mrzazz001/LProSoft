using ProShared.GeneralM;using ProShared;
using System;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial  class Form1 : Form
    { void avs(int arln)

{ 
 Text = "Form1";this.Text=   (arln == 0 ? "  Form1  " : "  Form1") ;}
        private void langloads(object sender, EventArgs e)
        {
              avs(ProShared. GeneralM.VarGeneral.currentintlanguage);;
        }
   
        public Form1(string v)
        {
            InitializeComponent();this.Load += langloads;
        }
    }
}
