using DevComponents.DotNetBar;
using InvAcc.GeneralM;
using InvAcc.Stock_Data;
using System;
using System.Windows.Forms;

namespace InvAcc.Forms
{
    public partial class FrmPOSREP : Form
    {
        public FrmPOSREP()
        {
            InitializeComponent();

            if (!Frm_Main.activflag)
            {
                this.Enabled = false;
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
            label1.Text = (ln == 0 ? "الدخول الى نقطة البيع " : "Enter POS");

            VarGeneral.InvTyp = 1;
            VarGeneral._IsPOS = true;
            FrmPos = new FrmInvSalePoint();
            FrmPos.Tag = LangArEn;
            FrmPos.TopMost = true;
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
                form1.StartPosition = FormStartPosition.CenterScreen;
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
        private Stock_DataDataContext dbInstance;
        private Rate_DataDataContext dbInstanceRate;
        private Stock_DataDataContext dbInstanceReturn;
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
            Hide();
            VarGeneral._IsPOS = true;
            // FrmInvSalePoint frm2 = new FrmInvSalePoint();
            FrmPos.Tag = LangArEn;
            FrmPos.switchButtonItem_IsReturn.IsReadOnly = (retrun == 0 ? false : true);
            FrmPos.DateSync = true;
            FrmPos.TopMost = true;
            FrmPos.ShowDialog();

            Show();

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
    }
}
