using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using ProShared.GeneralM;using ProShared;
using ProShared.Stock_Data;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial  class FrmRunProgrammallyOrder : Form
    { void avs(int arln)

{ 
 Text = "إغلاق";this.Text=   (arln == 0 ? "  إغلاق  " : "  Close") ; Text = "موافــــق";this.Text=   (arln == 0 ? "  موافــــق  " : "  ok") ;}
        private void langloads(object sender, EventArgs e)
        {
              avs(ProShared. GeneralM.VarGeneral.currentintlanguage);;
        }
   
        private Stock_DataDataContext dbInstance;
        private Rate_DataDataContext dbInstanceRate;
       // private IContainer components = null;
        private void netResize1_AfterControlResize(object sender, Softgroup.NetResize.AfterControlResizeEventArgs e)
        {
            if (e.Control.GetType() == typeof(Label))
            {
                Label c = (e.Control as Label); if ((c.BackColor != System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))))) && (c.BackColor != System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))))) && (c.BackColor != System.Drawing.Color.SteelBlue))
                    c.BackColor = Color.Transparent; Size cc = c.PreferredSize;
                c.AutoSize = false;
                c.Size = cc;
                //  e.Control.Font= new System.Drawing.Font("Tahoma",(float) (c-0.5));
            }
        }
        private void FrmInvSale_Shown(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            this.WindowState = FormWindowState.Maximized;
        }
        private void FrmInvSale_SizeChanged(object sender, EventArgs e)
        {
            netResize1.Refresh();
        }
        public Softgroup.NetResize.NetResize netResize1;
        private TextBoxX txtOrder;
        private ButtonX buttonX_Close;
        private ButtonX buttonX_Ok;
        private Stock_DataDataContext db
        {
            get
            {
                if (dbInstance == null)
                {
                    dbInstance = new Stock_DataDataContext(VarGeneral.BranchCS);
                }
                return dbInstance;
            }
        }
        private Rate_DataDataContext dbc
        {
            get
            {
                if (dbInstanceRate == null)
                {
                    dbInstanceRate = new Rate_DataDataContext(VarGeneral.BranchRt);
                }
                return dbInstanceRate;
            }
        }
        public FrmRunProgrammallyOrder()
        {
            InitializeComponent();this.Load += langloads;
        }
        private void buttonX_Close_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void buttonX_Ok_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("هل أنت متاكد من اتمام هذه العملية ?", VarGeneral.ProdectNam, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes && !string.IsNullOrEmpty(txtOrder.Text))
                {
                    if (MessageBox.Show("هل تريد تنفيذ الأمر على بيانات العمل ?", VarGeneral.ProdectNam, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        string[] lins = txtOrder.Text.Split(Environment.NewLine.ToCharArray());
                        try
                        {
                            if (lins[0] == "CommandTimeout")
                            {
                                db.CommandTimeout = int.Parse(lins[1]);
                                string sa = "";
                                for (int i = 2; i < lins.Length; i++)
                                    sa += lins[i] + Environment.NewLine;
                                txtOrder.Text = sa;
                            }
                        }
                        catch { }
                        db.ExecuteCommand(txtOrder.Text);
                    }
                    else
                    {
                        string[] lins = txtOrder.Text.Split(Environment.NewLine.ToCharArray());
                        try
                        {
                            if (lins[0] == "CommandTimeout")
                            {
                                dbc.CommandTimeout = int.Parse(lins[1]);
                                string sa = "";
                                for (int i = 2; i < lins.Length; i++)
                                    sa += lins[i] + Environment.NewLine;
                                txtOrder.Text = sa;
                            }
                        }
                        catch { }
                        dbc.ExecuteCommand(txtOrder.Text);
                    }
                    MessageBox.Show("تمت العملية بنجاح");
                    Close();
                }
            }
            catch
            {
                MessageBox.Show("لم يتم العملية بنجاح");
                Close();
            }
        }
        private void FrmRunProgrammallyOrder_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
        private void txtOrder_ButtonCustomClick(object sender, EventArgs e)
        {
            txtOrder.Text = "";
        }
        private void FrmRunProgrammallyOrder_Load(object sender, EventArgs e)
        {
        }
    }
}
