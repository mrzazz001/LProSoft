using System;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial  class ContactUsForm : Form
    { void avs(int arln)

{ 
 Text = "ContactUsForm";this.Text=   (arln == 0 ? "  ContactUsForm  " : "  ContactUsForm") ;}
        private void langloads(object sender, EventArgs e)
        {
              avs(ProShared. GeneralM.VarGeneral.currentintlanguage);;
        }
   
        public ContactUsForm()
        {
            InitializeComponent();this.Load += langloads;
        }
        private void c1Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void ContactUsForm_Load(object sender, EventArgs e)
        {
        }
    }
}
