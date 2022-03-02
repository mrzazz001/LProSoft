using DevComponents.DotNetBar;
using ProShared.GeneralM;using ProShared;
using ProShared.Stock_Data;
using System;
using System.Windows.Forms;
using InvAcc.Forms.Shared;

namespace InvAcc.Forms
{
    public partial class FrmPOSREP : DevExpress.XtraEditors.XtraForm
    {
        void avs(int arln)

{ 
 buttonItem_MoveTables.Text=   (arln == 0 ? "  تحويل الطلبات بين الطاولات  " : "  Transfer orders between tables") ; buttonItem_TableInfo.Text=   (arln == 0 ? "  حول الطاولات  " : "  around the tables") ; buttonX2.Text=   (arln == 0 ? "  خروج  " : "  Exit") ; buttonItem_AlarmLocalOrder.Text=   (arln == 0 ? "  الطلبات المحلية  " : "  local orders") ; label5.Text=   (arln == 0 ? "  إقفال الصندوق  " : "  close the box") ; Lmovment.Text=   (arln == 0 ? "  حركة صنف  " : "  class movement") ; LSRPL.Text=   (arln == 0 ? "  تقرير فواتير البائع  " : "  Vendor billing report") ; LRenum.Text=   (arln == 0 ? "  اعادة تسلسل فواتير الصندوق  " : "  Re-sequencing the fund's bills") ; label9.Text=   (arln == 0 ? "  حول الطاولات  " : "  around the tables") ; cButton1.Text=   (arln == 0 ? "    " : "    ") ; buttonItem_RepItemMovement.Text=   (arln == 0 ? "    " : "    ") ; buttonItem_RepInvoices.Text=   (arln == 0 ? "    " : "    ") ; bubbleButton_RelayInvPoint.Text=   (arln == 0 ? "    " : "    ") ; buttonItem_RelayBox.Text=   (arln == 0 ? "    " : "    ") ;  LCLOSE.Text=   (arln == 0 ? "  اقفال الصندوق  " : "  close the fund") ; Text = "FrmPOSREP";this.Text=   (arln == 0 ? "  FrmPOSREP  " : "  FrmPOSREP") ;}
        private void langloads(object sender, EventArgs e)
        {
           //  avs(ProShared. GeneralM.VarGeneral.currentintlanguage);;
        }
   
        public FrmPOSREP()
        {
            InitializeComponent();this.Load += langloads;
            if (!Frm_Main.activflag)
            {
                this.Enabled = false;
            }
             if (VarGeneral.currentintlanguage == 1)
            {
                buttonItem_TableInfo.Text = "About Tables";
                buttonItem_AlarmLocalOrder.Text = "local Orders";
                buttonItem_MoveTables.Text = "Transfer Orders Between Tables";

                LCLOSE.Text = "Close Boxes";
                LRenum.Text = "Reset Boxes Series";
                LSRPL.Text = "Saler Invoices";
                Lmovment.Text = "Item Movement Report";
                label1.Text = "Item Addation";
                label4.Text = "Printer Settings";
                label3.Text = "POS";
                label2.Text = "Invoice Totals Report";
                buttonX2.Text = "Exit";
            }
        }
        int retrun = 0;
        public void setreturn()
        {
            retrun = 1;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            VarGeneral.InvTyp = 7;
            VarGeneral._IsPOS = true;
            FrmCarFixingPOSOrders frm3 = new FrmCarFixingPOSOrders();
            frm3.Tag = VarGeneral.CurrentLang;
            frm3.TopMost = true;
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
        }
        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {
        }
        private void FrmPOSREP_Load(object sender, EventArgs e)
        {
            int ln = VarGeneral.UserLang;
          
            VarGeneral.InvTyp = 1;
            VarGeneral._IsPOS = true;
            FrmPos = new FrmInvSalePoint();
            FrmPos.Tag = LangArEn;
          //  FrmPos.TopMost = true;
            FrmPos.frmRepOps = this;
            if (retrun == 1) FrmPos.switchButtonItem_IsReturn.IsReadOnly = true;
            if (VarGeneral.SSSLev == "R" || VarGeneral.SSSLev == "C" || VarGeneral.SSSLev == "H")
            {
                buttonItem_TableInfo.Visible = true;
                buttonItem_MoveTables.Visible = true;
                buttonItem_AlarmLocalOrder.Visible = true;
            }
            else
            {
                buttonItem_TableInfo.Visible = false;
                buttonItem_MoveTables.Visible = false;
                buttonItem_AlarmLocalOrder.Visible = false;
            }

            FrmPos.loadsss();
        }
        public SwitchButtonItem switchButtonItem_IsReturn;
        public T_User permission = new T_User();
        public int LangArEn = 0;
        private void buttonItem_RepItemMovement_Click(object sender, EventArgs e)
        {
            try
            {
                FrmPos.loads();
                if (switchButtonItem_IsReturn.Value)
                {
                    if (!VarGeneral.TString.ChkStatShow(permission.StkRep, 9))
                    {
                        MessageBox.Show((LangArEn == 0) ? "لا يمكن اتمام هذه العملية .. الرجاء مراجعة صلاحيات المستخدمين !" : "Can not complete this process .. please see the powers of the users!", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        return;
                    }
                    VarGeneral.InvType = 3;
                }
                else
                {
                    if (!VarGeneral.TString.ChkStatShow(permission.StkRep, 8))
                    {
                        MessageBox.Show((LangArEn == 0) ? "لا يمكن اتمام هذه العملية .. الرجاء مراجعة صلاحيات المستخدمين !" : "Can not complete this process .. please see the powers of the users!", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        return;
                    }
                    VarGeneral.InvType = 1;
                }
                FRItemsTransf form1 = new FRItemsTransf();
                form1.Tag = LangArEn;
                TopMost = false;

                form1.ShowInTaskbar = true;
                form1.TopMost = true;
                form1.ShowDialog();

            }
            catch { }
        }
        private void buttonItem_RepInvoices_Click(object sender, EventArgs e)
        {
            try
            {
                FrmPos.loads();
                if (!VarGeneral.TString.ChkStatShow(permission.StkRep, 29))
                {
                    MessageBox.Show((LangArEn == 0) ? "لا يمكن اتمام هذه العملية .. الرجاء مراجعة صلاحيات المستخدمين !" : "Can not complete this process .. please see the powers of the users!", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                VarGeneral.RepSalesPOS = false;
                try
                {
                    VarGeneral.InvType = 1;
                    FRInvoice form1 = new FRInvoice(0, LangArEn);
                    form1.Tag = LangArEn.ToString();
                    if (!switchButtonItem_IsReturn.Value)
                    {
                        VarGeneral.RepSalesPOS = true;
                    }
                    form1.TopMost = true;
                    form1.ShowInTaskbar = true;
                    form1.ShowDialog();
                }
                catch
                {
                    VarGeneral.RepSalesPOS = false;
                }
                VarGeneral.RepSalesPOS = false;
            }
            catch { }
        }
#pragma warning disable CS0169 // The field 'FrmPOSREP.dbInstance' is never used
        private Stock_DataDataContext dbInstance;
#pragma warning restore CS0169 // The field 'FrmPOSREP.dbInstance' is never used
        private Rate_DataDataContext dbInstanceRate;
#pragma warning disable CS0169 // The field 'FrmPOSREP.dbInstanceReturn' is never used
        private Stock_DataDataContext dbInstanceReturn;
#pragma warning restore CS0169 // The field 'FrmPOSREP.dbInstanceReturn' is never used
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
        private void buttonItem_RelayBox_Click(object sender, EventArgs e)
        {
            try
            {
                FrmPos.loads();
                if (!VarGeneral.TString.ChkStatShow(permission.SetStr, 23))
                {
                    MessageBox.Show((LangArEn == 0) ? "لا يمكن اتمام هذه العملية .. الرجاء مراجعة صلاحيات المستخدمين !" : "Can not complete this process .. please see the powers of the users!", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                else if (dbc.Get_PermissionID(VarGeneral.UserID).CreateGaid == 1 && VarGeneral.SSSTyp != 0)
                {
                    int invTy_ = VarGeneral.InvTyp;
                    VarGeneral.InvTyp = 11;
                    FrmRelayBoxes frm = new FrmRelayBoxes();
                    frm.Tag = LangArEn;
                    frm.TopMost = true;
                    frm.ShowInTaskbar = true;
                    frm.ShowDialog();
                    VarGeneral.InvTyp = invTy_;
                    //  Button_Add_Click(sender, e);
                }
            }
            catch { }
        }
        private void bubbleButton_RelayInvPoint_Click(object sender, EventArgs e)
        {
            try
            {
                FrmPos.loads();
                if (!VarGeneral.TString.ChkStatShow(permission.SetStr, 33))
                {
                    MessageBox.Show((LangArEn == 0) ? "لا يمكن اتمام هذه العملية .. الرجاء مراجعة صلاحيات المستخدمين !" : "Can not complete this process .. please see the powers of the users!", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                FrmRelayInv frm = new FrmRelayInv();
                frm.Tag = LangArEn;
                TopMost = false;
                frm.TopMost = true;
                frm.ShowDialog();
  
            }
            catch { }
        }
        public FormState State
        {
            get
            {
                return statex;
            }
            set
            {
                statex = value;
            }
        }
        FormState statex;
        public FrmInvSalePoint FrmPos;
        private void buttonItem_MoveTables_Click(object sender, EventArgs e)
        {
            FrmPos.loads();
            if (State == FormState.Edit)
            {
                MessageBox.Show((LangArEn == 0) ? "يرجى حفظ السجل قبل القيام بهذه العملية .." : "Please save the record before doing this operation ..", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            if (!VarGeneral.TString.ChkStatShow(permission.SetStr, 42))
            {
                MessageBox.Show((LangArEn == 0) ? "لا يمكن اتمام هذه العملية .. الرجاء مراجعة صلاحيات المستخدمين !" : "Can not complete this process .. please see the powers of the users!", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            VarGeneral.IsTablesTrans = false;
            FrmTransTable frm = new FrmTransTable();
            frm.Tag = LangArEn;
            frm.TopMost = true;
            frm.ShowDialog();
            if (VarGeneral.IsTablesTrans && State == FormState.New)
            {
                //txtTable.Value = 0;
                //txtTable.Tag = 0;
            }
            else if (State == FormState.Saved)
            {
                //dbInstance = null;
                //textBox_ID_TextChanged(sender, e);
            }
        }
        private void buttonItem_TableInfo_Click(object sender, EventArgs e)
        {
            FrmPos.loads();
            FrmTables frm = new FrmTables("", 0, frmSts: true);
            frm.Tag = LangArEn;
            frm.TopMost = true;
            frm.ShowDialog();
        }
        private void buttonX1_Click(object sender, EventArgs e)
        {
        }
        private void buttonX2_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void FrmPOSREP_FormClosed(object sender, FormClosedEventArgs e)
        {
        }
        private void buttonItem_AlarmLocalOrder_Click(object sender, EventArgs e)
        {
            FrmPos.loads();
        }
        private void buttonItem_TableInfo_VisibleChanged(object sender, EventArgs e)
        {
            label9.Visible = buttonItem_TableInfo.Visible;
        }
        private void buttonItem_MoveTables_VisibleChanged(object sender, EventArgs e)
        {
        }
        private void FrmPOSREP_SizeChanged(object sender, EventArgs e)
        {
        }
        private void cButton1_ClickButtonArea(object Sender, MouseEventArgs e)
        {

        }
        private void tableLayoutPanel3_Paint_1(object sender, PaintEventArgs e)
        {
        }
        private void bubbleButton_RelayInvPoint_ClickButtonArea(object Sender, MouseEventArgs e)
        {
        }
        private void buttonItem_RepItemMovement_ClickButtonArea(object Sender, MouseEventArgs e)
        {
        }
        private void buttonItem_RepInvoices_ClickButtonArea(object Sender, MouseEventArgs e)
        {
        }
        private void LCLOSE_Click(object sender, EventArgs e)
        {
        }
        private void buttonItem_RelayBox_ClickButtonArea(object Sender, MouseEventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {
            FRInvTotals frm = new FRInvTotals();
            frm.TopMost = true;
            frm.ShowDialog();
        }

        private void cButton2_ClickButtonArea(object Sender, MouseEventArgs e)
        {
            FRInvTotals frm = new FRInvTotals();
            frm.TopMost = true;
            frm.ShowDialog();

        }

        private void cButton1_Click(object sender, EventArgs e)
        {
            this.TopMost = false;
            XFrmItems frm = new XFrmItems();
            frm.BringToFront();

            frm.ShowDialog();
        }

        private void cButton1_Click(object Sender, MouseEventArgs e)
        {
       //     cButton1_Click(null, null);
        }

        private void cButton3_ClickButtonArea(object Sender, MouseEventArgs e)
        {
            //Hide();
            //VarGeneral._IsPOS = true;

           
            //FrmPos.Tag = LangArEn;
            //FrmPos.switchButtonItem_IsReturn.IsReadOnly = (retrun == 0 ? false : true);
            //FrmPos.DateSync = true;
            //FrmPos.TopMost = true;
            //FrmPos.ShowDialog();
        
            //Show();
            //FrmPos.Dispose();
            //FrmPos = new FrmInvSalePoint();
            //FrmPos.Tag = LangArEn;
            //FrmPos.TopMost = true;
            //FrmPos.frmRepOps = this;
            //if (retrun == 1) FrmPos.switchButtonItem_IsReturn.IsReadOnly = true;
            //FrmPos.loadsss();

        }

        private void cButton3_Click(object sender, EventArgs e)
        {
            Hide();
            VarGeneral._IsPOS = true;
 
                ///Program.min();
            FrmPos.Tag = LangArEn;
            FrmPos.switchButtonItem_IsReturn.IsReadOnly = (retrun == 0 ? false : true);
            FrmPos.DateSync = true;
            FrmPos.TopMost = true;
            FrmPos.ShowDialog();
            Show();
            FrmPos.Dispose();
            FrmPos = new FrmInvSalePoint();
            FrmPos.Tag = LangArEn;
            FrmPos.TopMost = true;
            FrmPos.frmRepOps = this;
            if (retrun == 1) FrmPos.switchButtonItem_IsReturn.IsReadOnly = true;
            FrmPos.loadsss();
             

        }

        private void cButton4_Click(object sender, EventArgs e)
        {
            FrmPrinters frm = new
               FrmPrinters();
            TopMost = false;

            frm.ShowDialog();
            TopMost = true;

        }
    }
}
