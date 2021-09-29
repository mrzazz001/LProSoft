using System;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial class BackupAlarm : Form
    {
        FrmMn caller;
        public BackupAlarm(FrmMn f)
        {
            caller = f;
            InitializeComponent();
        }
        public BackupAlarm(Frm_Main f)
        {
            //    caller = f;
            InitializeComponent();
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
