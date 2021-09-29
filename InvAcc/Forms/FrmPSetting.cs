using System;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial  class FrmPSetting : Form
    { void avs(int arln)

{ 
 tabPage1.Text=   (arln == 0 ? "  tabPage1  " : "  tabPage1") ; tabPage2.Text=   (arln == 0 ? "  tabPage2  " : "  tabPage2") ; tabPage3.Text=   (arln == 0 ? "  tabPage3  " : "  tabPage3") ; Text = "FrmPSetting";this.Text=   (arln == 0 ? "  FrmPSetting  " : "  FrmPSetting") ;}
        private void langloads(object sender, EventArgs e)
        {
             avs(GeneralM.VarGeneral.currentintlanguage);
        }
   
        public FrmPSetting()
        {
            InitializeComponent();this.Load += langloads;
        }
        private void tabPage1_Click(object sender, EventArgs e)
        {
        }
    }
}
