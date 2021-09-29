
using InvAcc.GeneralM;
using System;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial  class BackupAlarm : Form
    { void avs(int arln)

{ 
 Text = "BackupAlarm";this.Text=   (arln == 0 ? "  BackupAlarm  " : "  BackupAlarm") ;}
        private void langloads(object sender, EventArgs e)
        {
             avs(GeneralM.VarGeneral.currentintlanguage);
        }
   
        FrmMn caller;
        public BackupAlarm(FrmMn f)
        {
            caller = f;
            InitializeComponent();this.Load += langloads;
        }
        public BackupAlarm(Frm_Main f)
        {
            //    caller = f;
            InitializeComponent();this.Load += langloads;
        }
        private void BackupAlarm_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            //caller.Focus();
        }
        private void c1Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void colorButton1_Click(object sender, EventArgs e)
        {
        }
    }
}
