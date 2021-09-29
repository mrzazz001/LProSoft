using System;
using System.Windows.Forms;

namespace InvAcc
{

    public partial class FrmReport : Form
    {
        public FrmReport()
        {
            InitializeComponent();//this.Load += langloads;
        }

        private void FrmReport_Load(object sender, EventArgs e)
        {


        }

        private void FrmReport_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {

                Close();



            }
        }

        private void FrmReport_ControlAdded(object sender, ControlEventArgs e)
        {
            try
            {
                (e.Control as Form).WindowState = FormWindowState.Maximized;
            }
            catch { }
        }
        Form fs;
        private void FrmReport_MdiChildActivate(object sender, EventArgs e)
        {
            try
            {
                fs = (sender as Form);
                fs.Shown += ksjfal;
            }
            catch { }
        }

        private void ksjfal(object sender, EventArgs e)
        {

            fs.ActiveMdiChild.WindowState = FormWindowState.Maximized;
        }
    }
}
