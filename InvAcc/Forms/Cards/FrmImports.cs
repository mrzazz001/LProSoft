using DevComponents.DotNetBar.Controls;
using System;
using System.ComponentModel;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial  class FrmImports : Form
    { void avs(int arln)

{ 
 Text = "progressBarX1";this.Text=   (arln == 0 ? "  progressBarX1  " : "  progressBarX1") ;}
        private void langloads(object sender, EventArgs e)
        {
              avs(ProShared. GeneralM.VarGeneral.currentintlanguage);;
        }
   
       // private IContainer components = null;
        private ProgressBarX progressBarX_import;
        private Timer timer1;
        public FrmImports()
        {
            InitializeComponent();this.Load += langloads;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBarX_import.Increment(1);
            if (progressBarX_import.Value == 100)
            {
                timer1.Stop();
            }
        }
    }
}
