using ProShared.GeneralM;using ProShared;
using System;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial  class FrmUNderDone : Form
    { void avs(int arln)

{ 
 InvDetails.Text=   (arln == 0 ? "  superTabControl3  " : "  superTabControl3") ; Text = "شاشة التنفيذ";this.Text=   (arln == 0 ? "  شاشة التنفيذ  " : "  Execution screen") ;}
        private void langloads(object sender, EventArgs e)
        {
              avs(ProShared. GeneralM.VarGeneral.currentintlanguage);;
        }
   
        public FrmUNderDone()
        {
            InitializeComponent();this.Load += langloads;
        }
        private void InvDetails_SelectedTabChanged(object sender, DevComponents.DotNetBar.SuperTabStripSelectedTabChangedEventArgs e)
        {
        }
        private void switchButtonItem_Exit_ValueChanged(object sender, EventArgs e)
        {
            if (switchButtonItem_Exit.Value)
            {
                return;
            }
            try
            {
                if (MessageBox.Show((ProShared.GeneralM.VarGeneral.UserLang == 0) ? "هل انت متأكد من الخروج من النظام حقا ؟ " : "Do you want to exit the program already?", VarGeneral.ProdectNam, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly) == DialogResult.No)
                {
                    switchButtonItem_Exit.Value = true;
                }
                else
                {
                    Close();
                }
            }
            catch
            {
                Application.ExitThread();
            }
        }
        private void FrmUNderDone_Load(object sender, EventArgs e)
        {
            exPanel1.init();
        }
        private void exPanel1_Load(object sender, EventArgs e)
        {
        }
        private void FrmUNderDone_SizeChanged(object sender, EventArgs e)
        {
            splitContainer1.SplitterDistance = 25;
        }
        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {
        }
        private void switchButtonItem2_ValueChanged(object sender, EventArgs e)
        {
            if (switchButtonItem2.Value)
            {
                return;
            }
            try
            {
                if (MessageBox.Show((ProShared.GeneralM.VarGeneral.UserLang == 0) ? "هل انت متأكد من الخروج من النظام حقا ؟ " : "Do you want to exit the program already?", VarGeneral.ProdectNam, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly) == DialogResult.No)
                {
                    switchButtonItem2.Value = true;
                }
                else
                {
                    Close();
                }
            }
            catch
            {
                Application.ExitThread();
            }
        }
        private void exPanel1_Load_1(object sender, EventArgs e)
        {
        }
    }
}
