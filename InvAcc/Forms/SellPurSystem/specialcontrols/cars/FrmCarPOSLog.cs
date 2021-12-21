using ProShared.GeneralM;using ProShared;
using System;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial  class FrmCarPOSLog : Form
    { void avs(int arln)

{ 
 label1.Text=   (arln == 0 ? "  اضافة عميل  " : "  Add Customer") ; label2.Text=   (arln == 0 ? "  عمل طلب  " : "  Make Order") ; label4.Text=   (arln == 0 ? "  خروج  " : "  Exit") ; Text = "FrmCarPOSLog";this.Text=   (arln == 0 ? "  دخول الى نقطة البيع  " : "  FrmCarPOSLog") ;}
        private void langloads(object sender, EventArgs e)
        {
          //  Program.min();
              avs(ProShared. GeneralM.VarGeneral.currentintlanguage);;
        }
   
        public FrmCarPOSLog()
        {
            InitializeComponent();this.Load += langloads;
            if (!Frm_Main.activflag)
            {
                this.Enabled = false;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            VarGeneral.InvTyp = 7;
            
            VarGeneral._IsPOS = true;
            FrmCarFixingPOSOrders frm3 = new FrmCarFixingPOSOrders();
            frm3.Tag = VarGeneral.CurrentLang;
            frm3.TopMost = true;
            frm3.frmpos = this;
            frm3.WindowState = FormWindowState.Maximized;
            frm3.ShowDialog();
            VarGeneral._IsPOS = false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            FrmCustomer frm = new FrmCustomer();
            frm.TopMost = true;
            frm.ShowDialog();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void tableLayoutPanel2_SizeChanged(object sender, EventArgs e)
        {
            tableLayoutPanel3.ColumnStyles[1] = new ColumnStyle(SizeType.Absolute, 200);
            tableLayoutPanel4.ColumnStyles[1] = new ColumnStyle(SizeType.Absolute, 200);
        }
        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {
        }
        private void FrmCarPOSLog_Load(object sender, EventArgs e)
        {
            int ln = VarGeneral.UserLang;
            label1.Text = (ln == 0 ? "اضافة عميل" : "Add Customer");
            label2.Text = (ln == 0 ? "اضافة طلب" : "Add Order");
            label4.Text = (ln == 0 ? "خروج" : " Exit ");
            TopMost = false;
        }
        private void label4_Click(object sender, EventArgs e)
        {
        }
    }
}
