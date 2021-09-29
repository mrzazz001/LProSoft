using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.Editors;
using InvAcc.GeneralM;
using InvAcc.Stock_Data;
using SSSDateTime.Date;
using SSSLanguage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Ports;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial  class FrmPayid : Form
    { void avs(int arln)

{ 
 label3.Text=   (arln == 0 ? "  إجمالي الضريبة  " : "  total tax") ; groupPanel2.Text=   (arln == 0 ? "  العميــــل  " : "  customer") ; label2.Text=   (arln == 0 ? "  المتبقي  " : "  Residual") ; label1.Text=   (arln == 0 ? "   المدفوع  " : "   paid up") ; groupPanel1.Text=   (arln == 0 ? "  البـــائـــــع  " : "  the seller") ; label20.Text=   (arln == 0 ? "  آجــــل  " : "  deferred") ; label18.Text=   (arln == 0 ? "  نقـــداُ  " : "  cash") ; buttonX_NetworkBank.Text=   (arln == 0 ? "  شبكـــة  " : "  network") ; labelD3.Text=   (arln == 0 ? "  المدين :  " : "  Debtor:") ; label19.Text=   (arln == 0 ? "  شبكـــة  " : "  network") ; buttonX5.Text=   (arln == 0 ? "  1000  " : "  1000") ; buttonX6.Text=   (arln == 0 ? "  500  " : "  500") ; buttonX7.Text=   (arln == 0 ? "  200  " : "  200") ; buttonX8.Text=   (arln == 0 ? "  100  " : "  100") ; buttonX3.Text=   (arln == 0 ? "  50  " : "  50") ; buttonX4.Text=   (arln == 0 ? "  10  " : "  10") ; buttonX2.Text=   (arln == 0 ? "  5  " : "  5") ; buttonX1.Text=   (arln == 0 ? "  1  " : "  1") ; button_Bac.Text=   (arln == 0 ? "  مسح  " : "  Survey") ; button_0.Text=   (arln == 0 ? "  0  " : "  0") ; button_2.Text=   (arln == 0 ? "  2  " : "  2") ; button_6.Text=   (arln == 0 ? "  6  " : "  6") ; button_5.Text=   (arln == 0 ? "  5  " : "  5") ; button_8.Text=   (arln == 0 ? "  8  " : "  8") ; button_7.Text=   (arln == 0 ? "  7  " : "  7") ; button_3.Text=   (arln == 0 ? "  3  " : "  3") ; button_4.Text=   (arln == 0 ? "  4  " : "  4") ; button_9.Text=   (arln == 0 ? "  9  " : "  9") ; button_1.Text=   (arln == 0 ? "  1  " : "  1") ; label17.Text=   (arln == 0 ? "  الإجمالي :  " : "  Total :") ; button_SavePrint.Text=   (arln == 0 ? "  موافــق + طبـاعة  F5  " : "  OK + print F5") ; button_Save.Text=   (arln == 0 ? "  موافـــق   F2  " : "  OK F2") ; button_Close.Text=   (arln == 0 ? "  خــــروج  " : "  exit") ; superTabItem_General.Text=   (arln == 0 ? "  صافــــي الفــاتـــــورة  " : "  net bill") ; Text = "-";this.Text=   (arln == 0 ? "  -  " : "  -") ;}
        private void langloads(object sender, EventArgs e)
        {
             avs(GeneralM.VarGeneral.currentintlanguage);
        }
   
        public class ColumnDictinary
        {
            public string AText = string.Empty;
            public string EText = string.Empty;
            public bool IfDefault = false;
            public string Format = string.Empty;
            public ColumnDictinary(string aText, string eText, bool ifDefault, string format)
            {
                AText = aText;
                EText = eText;
                IfDefault = ifDefault;
                Format = format;
            }
        }
        public Dictionary<string, ColumnDictinary> columns_Names_visible = new Dictionary<string, ColumnDictinary>();
        private HijriGreg.HijriGregDates n = new HijriGreg.HijriGregDates();
        private int LangArEn = 0;
        protected bool ifOkDelete;
        public bool CanEdit = true;
        protected bool CanInsert = true;
        private string FlagUpdate = string.Empty;
        public ViewState ViewState = ViewState.Deiles;
        private FormState statex;
        public List<Control> controls;
        public Control codeControl = new Control();
        private bool canUpdate = true;
        private int ControlNo = 0;
        private List<string> pkeys = new List<string>();
        private Stock_DataDataContext dbInstance;
        private T_INVHED data_this;
        private double vNet = 0.0;
        public double Payment_Loc = 0.0;
        public double NetWork_Loc = 0.0;
        public double Visa_Loc = 0.0;
        public bool vSts_Op = false;
        public double Paid_Loc = 0.0;
        public double Rimming_Loc = 0.0;
        public bool IS_Print = false;
       // private IContainer components = null;
        private SuperTabControl superTabControl1;
        private SuperTabControlPanel superTabControlPanel1;
        private SuperTabItem superTabItem_General;
        internal Label label2;
        private DoubleInput txtSteel;
        private DoubleInput txtPayment;
        internal Label label17;
        private DoubleInput txtPaymentLoc;
        private DoubleInput doubleInput_NetWorkLoc;
        private GroupBox groupBox1;
        private DoubleInput txtDueAmount;
        internal Label label18;
        internal Label label19;
        private GroupBox groupPanel_BoardNo;
        private ButtonX button_Bac;
        private ButtonX button_0;
        private ButtonX button_2;
        private ButtonX button_6;
        private ButtonX button_5;
        private ButtonX button_8;
        private ButtonX button_7;
        private ButtonX button_3;
        private ButtonX button_4;
        private ButtonX button_9;
        private ButtonX button_1;
        internal Label label1;
        private ButtonX button_Save;
        private ButtonX button_Close;
        private ButtonX buttonX3;
        private ButtonX buttonX4;
        private ButtonX buttonX2;
        private ButtonX buttonX1;
        private ButtonX buttonX5;
        private ButtonX buttonX6;
        private ButtonX buttonX7;
        private ButtonX buttonX8;
        private GroupPanel groupPanel2;
        private GroupPanel groupPanel1;
        private ButtonX button_X3;
        private ButtonX button_X1;
        private ButtonX button_X2;
        private ButtonX button_X4;
        private ButtonX button_SavePrint;
        private ButtonX button_X9;
        internal Label label20;
        private DoubleInput doubleInput_VisaLoc;
        internal Label label3;
        public DoubleInput txtTax;
        private ButtonX buttonX_NetworkBank;
        private ItemContainer itemContainer7;
        private LabelItem labelD3;
        private ItemContainer itemContainer_SerchBank;
        private ButtonItem buttonItem_SrchBanks;
        public TextBoxItem txtDebit3;
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
        protected bool CanUpdate
        {
            get
            {
                return canUpdate;
            }
            set
            {
                canUpdate = value;
            }
        }
        public List<string> PKeys
        {
            get
            {
                return pkeys;
            }
            set
            {
                pkeys = value;
            }
        }
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
        public T_INVHED DataThis
        {
            get
            {
                return data_this;
            }
            set
            {
                data_this = value;
            }
        }
        public double PaymentLoc
        {
            get
            {
                return Payment_Loc;
            }
            set
            {
                Payment_Loc = value;
            }
        }
        public double NetWorkLoc
        {
            get
            {
                return NetWork_Loc;
            }
            set
            {
                NetWork_Loc = value;
            }
        }
        public double VisaLoc
        {
            get
            {
                return Visa_Loc;
            }
            set
            {
                Visa_Loc = value;
            }
        }
        public bool vStsOp
        {
            get
            {
                return vSts_Op;
            }
            set
            {
                vSts_Op = value;
            }
        }
        public double PaidLoc
        {
            get
            {
                return Paid_Loc;
            }
            set
            {
                Paid_Loc = value;
            }
        }
        public double RimmingLoc
        {
            get
            {
                return Rimming_Loc;
            }
            set
            {
                Rimming_Loc = value;
            }
        }
        public bool IsPrint
        {
            get
            {
                return IS_Print;
            }
            set
            {
                IS_Print = value;
            }
        }
        public FrmPayid(double vTotal)
        {
            InitializeComponent();this.Load += langloads;
            vNet = vTotal;
            if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49))
            {
                txtDueAmount.DisplayFormat = VarGeneral.DicemalMask;
                txtPaymentLoc.DisplayFormat = VarGeneral.DicemalMask;
                doubleInput_NetWorkLoc.DisplayFormat = VarGeneral.DicemalMask;
                doubleInput_VisaLoc.DisplayFormat = VarGeneral.DicemalMask;
                txtPayment.DisplayFormat = VarGeneral.DicemalMask;
                txtSteel.DisplayFormat = VarGeneral.DicemalMask;
                txtTax.DisplayFormat = VarGeneral.DicemalMask;
            }
        }
        private void RibunButtons()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
            {
                button_Save.Text = "موافـــق   F2";
                button_Close.Text = "تـراجـع";
            }
            else
            {
                button_Save.Text = "Save  F2";
                button_Close.Text = "Back";
            }
        }
        private void FrmPayid_Load(object sender, EventArgs e)
        {
            try
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmPayid));
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                {
                    Language.ChangeLanguage("ar-SA", this, resources);
                    LangArEn = 0;
                }
                else
                {
                    Language.ChangeLanguage("en", this, resources);
                    LangArEn = 1;
                    superTabItem_General.Text = "Invoice Net";
                    groupPanel1.Text = "Salesman";
                    groupPanel2.Text = "Customer";
                    button_Save.Text = "OK  F2";
                    button_SavePrint.Text = "OK + Print  F5";
                    button_Close.Text = "Close";
                    button_Bac.Text = "Clear";
                    labelD3.Text = "Debit";
                }
                if (VarGeneral._IsWaiter)
                {
                    buttonX_NetworkBank.Visible = false;
                    label19.Visible = true;
                }
                RibunButtons();
                if (vNet <= 0.0)
                {
                    vStsOp = true;
                    PaymentLoc = txtPaymentLoc.Value;
                    NetWorkLoc = doubleInput_NetWorkLoc.Value;
                    VisaLoc = doubleInput_VisaLoc.Value;
                    PaidLoc = txtPayment.Value;
                    RimmingLoc = txtSteel.Value;
                }
                txtDueAmount.Value = vNet;
                if (Payment_Loc + NetWork_Loc + Visa_Loc == 0.0)
                {
                    txtPaymentLoc.Value = vNet;
                }
                else
                {
                    txtPaymentLoc.Value = Payment_Loc;
                    doubleInput_NetWorkLoc.Value = NetWork_Loc;
                    doubleInput_VisaLoc.Value = Visa_Loc;
                }
                try
                {
                    if (!Program.sIsNumeric(txtTax.Tag.ToString()))
                    {
                        txtTax.Tag = "0";
                    }
                }
                catch
                {
                }
                txtPayment.Value = PaidLoc;
                txtSteel.Value = RimmingLoc;
                try
                {
                    txtPayment_Leave(sender, e);
                }
                catch
                {
                }
                if (!VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 25) && VarGeneral._IsPOS)
                {
                    doubleInput_VisaLoc.Enabled = false;
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Load:", error, enable: true);
                MessageBox.Show(error.Message);
            }
            if (VarGeneral.Settings_Sys.IsCustomerDisplay.Value)
            {
                CustomerDisplayData(txtDueAmount.Value, 0.0);
            }
            base.ActiveControl = txtPayment;
        }
        private void CustomerDisplayData(double _vTot, double _price)
        {
            try
            {
                SerialPort sport = new SerialPort(VarGeneral.Settings_Sys.Port, VarGeneral.Settings_Sys.Fast.Value, (VarGeneral.Settings_Sys.Parity.Value == 1) ? Parity.Even : ((VarGeneral.Settings_Sys.Parity.Value == 2) ? Parity.Mark : ((VarGeneral.Settings_Sys.Parity.Value != 3) ? ((VarGeneral.Settings_Sys.Parity.Value == 4) ? Parity.Odd : Parity.Space) : Parity.None)), VarGeneral.Settings_Sys.BitData.Value, (VarGeneral.Settings_Sys.BitStop.Value == 1) ? StopBits.One : ((VarGeneral.Settings_Sys.BitStop.Value == 2) ? StopBits.OnePointFive : StopBits.Two));
                sport.Open();
                sport.Write(new byte[1]
                {
                    12
                }, 0, 1);
                sport.Write(VarGeneral.Settings_Sys.CustomerHello);
                sport.Write(new byte[2]
                {
                    10,
                    13
                }, 0, 2);
                sport.Write(" Total:" + _vTot);
                sport.Close();
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("CustomerDisplayData :", error, enable: true);
            }
        }
        private void button_Close_Click(object sender, EventArgs e)
        {
            vStsOp = false;
            Close();
        }
        private void doubleInput_NetWorkLoc_Leave(object sender, EventArgs e)
        {
            try
            {
                if (!(doubleInput_NetWorkLoc.Value > 0.0))
                {
                    return;
                }
                if (txtPaymentLoc.Value > 0.0 || doubleInput_VisaLoc.Value > 0.0)
                {
                    if (!(txtPaymentLoc.Value > 0.0) || !(doubleInput_VisaLoc.Value > 0.0))
                    {
                        if (txtPaymentLoc.Value > 0.0)
                        {
                            txtPaymentLoc.Value = txtDueAmount.Value - double.Parse(txtTax.Tag.ToString()) - doubleInput_NetWorkLoc.Value;
                        }
                        else
                        {
                            doubleInput_VisaLoc.Value = txtDueAmount.Value - double.Parse(txtTax.Tag.ToString()) - doubleInput_NetWorkLoc.Value;
                        }
                    }
                }
                else
                {
                    txtPaymentLoc.Value = txtDueAmount.Value - double.Parse(txtTax.Tag.ToString()) - doubleInput_NetWorkLoc.Value;
                }
            }
            catch
            {
                doubleInput_NetWorkLoc.Value = 0.0;
                doubleInput_NetWorkLoc.Leave -= doubleInput_NetWorkLoc_Leave;
            }
        }
        private void txtPaymentLoc_Leave(object sender, EventArgs e)
        {
            try
            {
                if (!(txtPaymentLoc.Value > 0.0))
                {
                    return;
                }
                if (doubleInput_VisaLoc.Value > 0.0 || doubleInput_NetWorkLoc.Value > 0.0)
                {
                    if (!(doubleInput_VisaLoc.Value > 0.0) || !(doubleInput_NetWorkLoc.Value > 0.0))
                    {
                        if (doubleInput_VisaLoc.Value > 0.0)
                        {
                            doubleInput_VisaLoc.Value = txtDueAmount.Value - double.Parse(txtTax.Tag.ToString()) - txtPaymentLoc.Value;
                        }
                        else
                        {
                            doubleInput_NetWorkLoc.Value = txtDueAmount.Value - double.Parse(txtTax.Tag.ToString()) - txtPaymentLoc.Value;
                        }
                    }
                }
                else
                {
                    doubleInput_NetWorkLoc.Value = txtDueAmount.Value - double.Parse(txtTax.Tag.ToString()) - txtPaymentLoc.Value;
                }
            }
            catch
            {
                txtPaymentLoc.Value = 0.0;
                txtPaymentLoc.Leave -= txtPaymentLoc_Leave;
            }
        }
        private void doubleInput_VisaLoc_Leave(object sender, EventArgs e)
        {
            try
            {
                if (!(doubleInput_VisaLoc.Value > 0.0))
                {
                    return;
                }
                if (txtPaymentLoc.Value > 0.0 || doubleInput_NetWorkLoc.Value > 0.0)
                {
                    if (!(txtPaymentLoc.Value > 0.0) || !(doubleInput_NetWorkLoc.Value > 0.0))
                    {
                        if (txtPaymentLoc.Value > 0.0)
                        {
                            txtPaymentLoc.Value = txtDueAmount.Value - double.Parse(txtTax.Tag.ToString()) - doubleInput_VisaLoc.Value;
                        }
                        else
                        {
                            doubleInput_NetWorkLoc.Value = txtDueAmount.Value - double.Parse(txtTax.Tag.ToString()) - doubleInput_VisaLoc.Value;
                        }
                    }
                }
                else
                {
                    txtPaymentLoc.Value = txtDueAmount.Value - double.Parse(txtTax.Tag.ToString()) - doubleInput_VisaLoc.Value;
                }
            }
            catch
            {
                doubleInput_VisaLoc.Value = 0.0;
                doubleInput_VisaLoc.Leave -= doubleInput_VisaLoc_Leave;
            }
        }
        private void button_Save_Click(object sender, EventArgs e)
        {
            IsPrint = false;
            SaveData();
        }
        private void SaveData()
        {
            if (txtPaymentLoc.Value + doubleInput_NetWorkLoc.Value + doubleInput_VisaLoc.Value < txtDueAmount.Value - double.Parse(txtTax.Tag.ToString()))
            {
                MessageBox.Show((LangArEn == 0) ? "المبلغ المدفوع أصغر من قيمة الفاتورة" : "Can not save without the invoice number", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            double tx = txtDueAmount.Value - double.Parse(txtTax.Tag.ToString());
            if (txtPaymentLoc.Value + doubleInput_NetWorkLoc.Value + doubleInput_VisaLoc.Value > tx)
            {
                MessageBox.Show((LangArEn == 0) ? "المبلغ المدفوع أكبر من قيمة الفاتورة" : "Can not save without the invoice number", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 68) && txtPayment.Value < txtPaymentLoc.Value)
            {
                MessageBox.Show((LangArEn == 0) ? "يجب ان يكون المدفوع >= خانة الدفع نقدا\u064e .. يرجى التاكد من صحة المدفوع والمحاولة مجددا\u064e" : "The payee must be more than or equal to the payment box in cash .. Please check the validity of the payee and try again", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            vStsOp = true;
            PaymentLoc = txtPaymentLoc.Value;
            NetWorkLoc = doubleInput_NetWorkLoc.Value;
            VisaLoc = doubleInput_VisaLoc.Value;
            PaidLoc = txtPayment.Value;
            RimmingLoc = txtSteel.Value;
            Close();
        }
        private void FrmPayid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                button_Save_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F5)
            {
                button_SavePrint_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                button_Close_Click(sender, e);
            }
        }
        private void FrmPayid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                SendKeys.Send("{Tab}");
            }
        }
        private void txtSteel_ValueChanged(object sender, EventArgs e)
        {
            if (txtSteel.Value > 0.0)
            {
                label2.Text = ((LangArEn == 0) ? "متبقي له" : "Remming");
            }
            else if (txtSteel.Value < 0.0)
            {
                label2.Text = ((LangArEn == 0) ? "متبقي عليه" : "Remming");
            }
            else
            {
                label2.Text = ((LangArEn == 0) ? "المتبقي" : "Remming");
            }
        }
        private void txtPayment_Leave(object sender, EventArgs e)
        {
            if (txtPayment.Value > 0.0)
            {
                txtSteel.Value = txtPayment.Value - txtDueAmount.Value;
            }
            else
            {
                txtSteel.Value = 0.0;
            }
        }
        private void button_1_Click(object sender, EventArgs e)
        {
            try
            {
                if (ControlNo == 1)
                {
                    txtPaymentLoc.Text = txtPaymentLoc.Text.Substring(0, txtPaymentLoc.Text.Length - 3) + "1";
                    txtPaymentLoc_Leave(sender, e);
                }
                else if (ControlNo == 2)
                {
                    doubleInput_NetWorkLoc.Text = doubleInput_NetWorkLoc.Text.Substring(0, doubleInput_NetWorkLoc.Text.Length - 3) + "1";
                    doubleInput_NetWorkLoc_Leave(sender, e);
                }
                else if (ControlNo == 3)
                {
                    txtPayment.Text = txtPayment.Text.Substring(0, txtPayment.Text.Length - 3) + "1";
                    txtPayment_Leave(sender, e);
                }
                else if (ControlNo == 5)
                {
                    doubleInput_VisaLoc.Text = doubleInput_VisaLoc.Text.Substring(0, txtPayment.Text.Length - 3) + "1";
                    doubleInput_VisaLoc_Leave(sender, e);
                }
            }
            catch
            {
            }
        }
        private void button_2_Click(object sender, EventArgs e)
        {
            try
            {
                if (ControlNo == 1)
                {
                    txtPaymentLoc.Text = txtPaymentLoc.Text.Substring(0, txtPaymentLoc.Text.Length - 3) + "2";
                    txtPaymentLoc_Leave(sender, e);
                }
                else if (ControlNo == 2)
                {
                    doubleInput_NetWorkLoc.Text = doubleInput_NetWorkLoc.Text.Substring(0, doubleInput_NetWorkLoc.Text.Length - 3) + "2";
                    doubleInput_NetWorkLoc_Leave(sender, e);
                }
                else if (ControlNo == 3)
                {
                    txtPayment.Text = txtPayment.Text.Substring(0, txtPayment.Text.Length - 3) + "2";
                    txtPayment_Leave(sender, e);
                }
                else if (ControlNo == 5)
                {
                    doubleInput_VisaLoc.Text = doubleInput_VisaLoc.Text.Substring(0, txtPayment.Text.Length - 3) + "1";
                    doubleInput_VisaLoc_Leave(sender, e);
                }
            }
            catch
            {
            }
        }
        private void button_3_Click(object sender, EventArgs e)
        {
            try
            {
                if (ControlNo == 1)
                {
                    txtPaymentLoc.Text = txtPaymentLoc.Text.Substring(0, txtPaymentLoc.Text.Length - 3) + "3";
                    txtPaymentLoc_Leave(sender, e);
                }
                else if (ControlNo == 2)
                {
                    doubleInput_NetWorkLoc.Text = doubleInput_NetWorkLoc.Text.Substring(0, doubleInput_NetWorkLoc.Text.Length - 3) + "3";
                    doubleInput_NetWorkLoc_Leave(sender, e);
                }
                else if (ControlNo == 3)
                {
                    txtPayment.Text = txtPayment.Text.Substring(0, txtPayment.Text.Length - 3) + "3";
                    txtPayment_Leave(sender, e);
                }
                else if (ControlNo == 5)
                {
                    doubleInput_VisaLoc.Text = doubleInput_VisaLoc.Text.Substring(0, txtPayment.Text.Length - 3) + "1";
                    doubleInput_VisaLoc_Leave(sender, e);
                }
            }
            catch
            {
            }
        }
        private void button_4_Click(object sender, EventArgs e)
        {
            try
            {
                if (ControlNo == 1)
                {
                    txtPaymentLoc.Text = txtPaymentLoc.Text.Substring(0, txtPaymentLoc.Text.Length - 3) + "4";
                    txtPaymentLoc_Leave(sender, e);
                    doubleInput_NetWorkLoc_Leave(sender, e);
                }
                else if (ControlNo == 2)
                {
                    doubleInput_NetWorkLoc.Text = doubleInput_NetWorkLoc.Text.Substring(0, doubleInput_NetWorkLoc.Text.Length - 3) + "4";
                    doubleInput_NetWorkLoc_Leave(sender, e);
                }
                else if (ControlNo == 3)
                {
                    txtPayment.Text = txtPayment.Text.Substring(0, txtPayment.Text.Length - 3) + "4";
                    txtPayment_Leave(sender, e);
                }
                else if (ControlNo == 5)
                {
                    doubleInput_VisaLoc.Text = doubleInput_VisaLoc.Text.Substring(0, txtPayment.Text.Length - 3) + "1";
                    doubleInput_VisaLoc_Leave(sender, e);
                }
            }
            catch
            {
            }
        }
        private void button_5_Click(object sender, EventArgs e)
        {
            try
            {
                if (ControlNo == 1)
                {
                    txtPaymentLoc.Text = txtPaymentLoc.Text.Substring(0, txtPaymentLoc.Text.Length - 3) + "5";
                    txtPaymentLoc_Leave(sender, e);
                }
                else if (ControlNo == 2)
                {
                    doubleInput_NetWorkLoc.Text = doubleInput_NetWorkLoc.Text.Substring(0, doubleInput_NetWorkLoc.Text.Length - 3) + "5";
                    doubleInput_NetWorkLoc_Leave(sender, e);
                }
                else if (ControlNo == 3)
                {
                    txtPayment.Text = txtPayment.Text.Substring(0, txtPayment.Text.Length - 3) + "5";
                    txtPayment_Leave(sender, e);
                }
                else if (ControlNo == 5)
                {
                    doubleInput_VisaLoc.Text = doubleInput_VisaLoc.Text.Substring(0, txtPayment.Text.Length - 3) + "1";
                    doubleInput_VisaLoc_Leave(sender, e);
                }
            }
            catch
            {
            }
        }
        private void button_6_Click(object sender, EventArgs e)
        {
            try
            {
                if (ControlNo == 1)
                {
                    txtPaymentLoc.Text = txtPaymentLoc.Text.Substring(0, txtPaymentLoc.Text.Length - 3) + "6";
                    txtPaymentLoc_Leave(sender, e);
                }
                else if (ControlNo == 2)
                {
                    doubleInput_NetWorkLoc.Text = doubleInput_NetWorkLoc.Text.Substring(0, doubleInput_NetWorkLoc.Text.Length - 3) + "6";
                    doubleInput_NetWorkLoc_Leave(sender, e);
                }
                else if (ControlNo == 3)
                {
                    txtPayment.Text = txtPayment.Text.Substring(0, txtPayment.Text.Length - 3) + "6";
                    txtPayment_Leave(sender, e);
                }
                else if (ControlNo == 5)
                {
                    doubleInput_VisaLoc.Text = doubleInput_VisaLoc.Text.Substring(0, txtPayment.Text.Length - 3) + "1";
                    doubleInput_VisaLoc_Leave(sender, e);
                }
            }
            catch
            {
            }
        }
        private void button_9_Click(object sender, EventArgs e)
        {
            try
            {
                if (ControlNo == 1)
                {
                    txtPaymentLoc.Text = txtPaymentLoc.Text.Substring(0, txtPaymentLoc.Text.Length - 3) + "9";
                    txtPaymentLoc_Leave(sender, e);
                }
                else if (ControlNo == 2)
                {
                    doubleInput_NetWorkLoc.Text = doubleInput_NetWorkLoc.Text.Substring(0, doubleInput_NetWorkLoc.Text.Length - 3) + "9";
                    doubleInput_NetWorkLoc_Leave(sender, e);
                }
                else if (ControlNo == 3)
                {
                    txtPayment.Text = txtPayment.Text.Substring(0, txtPayment.Text.Length - 3) + "9";
                    txtPayment_Leave(sender, e);
                }
                else if (ControlNo == 5)
                {
                    doubleInput_VisaLoc.Text = doubleInput_VisaLoc.Text.Substring(0, txtPayment.Text.Length - 3) + "1";
                    doubleInput_VisaLoc_Leave(sender, e);
                }
            }
            catch
            {
            }
        }
        private void button_8_Click(object sender, EventArgs e)
        {
            try
            {
                if (ControlNo == 1)
                {
                    txtPaymentLoc.Text = txtPaymentLoc.Text.Substring(0, txtPaymentLoc.Text.Length - 3) + "8";
                    txtPaymentLoc_Leave(sender, e);
                }
                else if (ControlNo == 2)
                {
                    doubleInput_NetWorkLoc.Text = doubleInput_NetWorkLoc.Text.Substring(0, doubleInput_NetWorkLoc.Text.Length - 3) + "8";
                    doubleInput_NetWorkLoc_Leave(sender, e);
                }
                else if (ControlNo == 3)
                {
                    txtPayment.Text = txtPayment.Text.Substring(0, txtPayment.Text.Length - 3) + "8";
                    txtPayment_Leave(sender, e);
                }
                else if (ControlNo == 5)
                {
                    doubleInput_VisaLoc.Text = doubleInput_VisaLoc.Text.Substring(0, txtPayment.Text.Length - 3) + "1";
                    doubleInput_VisaLoc_Leave(sender, e);
                }
            }
            catch
            {
            }
        }
        private void button_7_Click(object sender, EventArgs e)
        {
            try
            {
                if (ControlNo == 1)
                {
                    txtPaymentLoc.Text = txtPaymentLoc.Text.Substring(0, txtPaymentLoc.Text.Length - 3) + "7";
                    txtPaymentLoc_Leave(sender, e);
                }
                else if (ControlNo == 2)
                {
                    doubleInput_NetWorkLoc.Text = doubleInput_NetWorkLoc.Text.Substring(0, doubleInput_NetWorkLoc.Text.Length - 3) + "7";
                    doubleInput_NetWorkLoc_Leave(sender, e);
                }
                else if (ControlNo == 3)
                {
                    txtPayment.Text = txtPayment.Text.Substring(0, txtPayment.Text.Length - 3) + "7";
                    txtPayment_Leave(sender, e);
                }
                else if (ControlNo == 5)
                {
                    doubleInput_VisaLoc.Text = doubleInput_VisaLoc.Text.Substring(0, txtPayment.Text.Length - 3) + "1";
                    doubleInput_VisaLoc_Leave(sender, e);
                }
            }
            catch
            {
            }
        }
        private void button_Bac_Click(object sender, EventArgs e)
        {
            try
            {
                if (ControlNo == 1)
                {
                    txtPaymentLoc.Text = "0";
                    txtPaymentLoc_Leave(sender, e);
                }
                else if (ControlNo == 2)
                {
                    doubleInput_NetWorkLoc.Text = "0";
                    doubleInput_NetWorkLoc_Leave(sender, e);
                }
                else if (ControlNo == 3)
                {
                    txtPayment.Text = "0";
                    txtPayment_Leave(sender, e);
                }
                else if (ControlNo == 5)
                {
                    doubleInput_VisaLoc.Text = doubleInput_VisaLoc.Text.Substring(0, txtPayment.Text.Length - 3) + "1";
                    doubleInput_VisaLoc_Leave(sender, e);
                }
            }
            catch
            {
            }
        }
        private void button_0_Click(object sender, EventArgs e)
        {
            try
            {
                if (ControlNo == 1)
                {
                    txtPaymentLoc.Text = txtPaymentLoc.Text.Substring(0, txtPaymentLoc.Text.Length - 3) + "0";
                    txtPaymentLoc_Leave(sender, e);
                }
                else if (ControlNo == 2)
                {
                    doubleInput_NetWorkLoc.Text = doubleInput_NetWorkLoc.Text.Substring(0, doubleInput_NetWorkLoc.Text.Length - 3) + "0";
                    doubleInput_NetWorkLoc_Leave(sender, e);
                }
                else if (ControlNo == 3)
                {
                    txtPayment.Text = txtPayment.Text.Substring(0, txtPayment.Text.Length - 3) + "0";
                    txtPayment_Leave(sender, e);
                }
                else if (ControlNo == 5)
                {
                    doubleInput_VisaLoc.Text = doubleInput_VisaLoc.Text.Substring(0, txtPayment.Text.Length - 3) + "1";
                    doubleInput_VisaLoc_Leave(sender, e);
                }
            }
            catch
            {
            }
        }
        private void txtPayment_Enter(object sender, EventArgs e)
        {
            ControlNo = 3;
            CheckSts(ControlNo);
        }
        private void txtSteel_Enter(object sender, EventArgs e)
        {
            ControlNo = 4;
            CheckSts(ControlNo);
        }
        private void txtPaymentLoc_Enter(object sender, EventArgs e)
        {
            ControlNo = 1;
            CheckSts(ControlNo);
        }
        private void doubleInput_NetWorkLoc_Enter(object sender, EventArgs e)
        {
            ControlNo = 2;
            CheckSts(ControlNo);
        }
        private void buttonX1_Click(object sender, EventArgs e)
        {
            try
            {
                if (ControlNo == 1)
                {
                    txtPaymentLoc.Value = 1.0;
                    txtPaymentLoc_Leave(sender, e);
                }
                else if (ControlNo == 2)
                {
                    doubleInput_NetWorkLoc.Value = 1.0;
                    doubleInput_NetWorkLoc_Leave(sender, e);
                }
                else if (ControlNo == 3)
                {
                    txtPayment.Value = 1.0;
                    txtPayment_Leave(sender, e);
                }
                else if (ControlNo == 5)
                {
                    doubleInput_VisaLoc.Value = 1.0;
                    doubleInput_VisaLoc_Leave(sender, e);
                }
            }
            catch
            {
            }
        }
        private void buttonX2_Click(object sender, EventArgs e)
        {
            try
            {
                if (ControlNo == 1)
                {
                    txtPaymentLoc.Value = 5.0;
                    txtPaymentLoc_Leave(sender, e);
                }
                else if (ControlNo == 2)
                {
                    doubleInput_NetWorkLoc.Value = 5.0;
                    doubleInput_NetWorkLoc_Leave(sender, e);
                }
                else if (ControlNo == 3)
                {
                    txtPayment.Value = 5.0;
                    txtPayment_Leave(sender, e);
                }
                else if (ControlNo == 5)
                {
                    doubleInput_VisaLoc.Value = 5.0;
                    doubleInput_VisaLoc_Leave(sender, e);
                }
            }
            catch
            {
            }
        }
        private void buttonX4_Click(object sender, EventArgs e)
        {
            try
            {
                if (ControlNo == 1)
                {
                    txtPaymentLoc.Value = 10.0;
                    txtPaymentLoc_Leave(sender, e);
                }
                else if (ControlNo == 2)
                {
                    doubleInput_NetWorkLoc.Value = 10.0;
                    doubleInput_NetWorkLoc_Leave(sender, e);
                }
                else if (ControlNo == 3)
                {
                    txtPayment.Value = 10.0;
                    txtPayment_Leave(sender, e);
                }
                else if (ControlNo == 5)
                {
                    doubleInput_VisaLoc.Value = 10.0;
                    doubleInput_VisaLoc_Leave(sender, e);
                }
            }
            catch
            {
            }
        }
        private void buttonX3_Click(object sender, EventArgs e)
        {
            try
            {
                if (ControlNo == 1)
                {
                    txtPaymentLoc.Value = 50.0;
                    txtPaymentLoc_Leave(sender, e);
                }
                else if (ControlNo == 2)
                {
                    doubleInput_NetWorkLoc.Value = 50.0;
                    doubleInput_NetWorkLoc_Leave(sender, e);
                }
                else if (ControlNo == 3)
                {
                    txtPayment.Value = 50.0;
                    txtPayment_Leave(sender, e);
                }
                else if (ControlNo == 5)
                {
                    doubleInput_VisaLoc.Value = 50.0;
                    doubleInput_VisaLoc_Leave(sender, e);
                }
            }
            catch
            {
            }
        }
        private void buttonX8_Click(object sender, EventArgs e)
        {
            try
            {
                if (ControlNo == 1)
                {
                    txtPaymentLoc.Value = 100.0;
                    txtPaymentLoc_Leave(sender, e);
                }
                else if (ControlNo == 2)
                {
                    doubleInput_NetWorkLoc.Value = 100.0;
                    doubleInput_NetWorkLoc_Leave(sender, e);
                }
                else if (ControlNo == 3)
                {
                    txtPayment.Value = 100.0;
                    txtPayment_Leave(sender, e);
                }
                else if (ControlNo == 5)
                {
                    doubleInput_VisaLoc.Value = 100.0;
                    doubleInput_VisaLoc_Leave(sender, e);
                }
            }
            catch
            {
            }
        }
        private void buttonX7_Click(object sender, EventArgs e)
        {
            try
            {
                if (ControlNo == 1)
                {
                    txtPaymentLoc.Value = 200.0;
                    txtPaymentLoc_Leave(sender, e);
                }
                else if (ControlNo == 2)
                {
                    doubleInput_NetWorkLoc.Value = 200.0;
                    doubleInput_NetWorkLoc_Leave(sender, e);
                }
                else if (ControlNo == 3)
                {
                    txtPayment.Value = 200.0;
                    txtPayment_Leave(sender, e);
                }
                else if (ControlNo == 5)
                {
                    doubleInput_VisaLoc.Value = 200.0;
                    doubleInput_VisaLoc_Leave(sender, e);
                }
            }
            catch
            {
            }
        }
        private void buttonX6_Click(object sender, EventArgs e)
        {
            try
            {
                if (ControlNo == 1)
                {
                    txtPaymentLoc.Value = 500.0;
                    txtPaymentLoc_Leave(sender, e);
                }
                else if (ControlNo == 2)
                {
                    doubleInput_NetWorkLoc.Value = 500.0;
                    doubleInput_NetWorkLoc_Leave(sender, e);
                }
                else if (ControlNo == 3)
                {
                    txtPayment.Value = 500.0;
                    txtPayment_Leave(sender, e);
                }
                else if (ControlNo == 5)
                {
                    doubleInput_VisaLoc.Value = 500.0;
                    doubleInput_VisaLoc_Leave(sender, e);
                }
            }
            catch
            {
            }
        }
        private void buttonX5_Click(object sender, EventArgs e)
        {
            try
            {
                if (ControlNo == 1)
                {
                    txtPaymentLoc.Value = 1000.0;
                    txtPaymentLoc_Leave(sender, e);
                }
                else if (ControlNo == 2)
                {
                    doubleInput_NetWorkLoc.Value = 1000.0;
                    doubleInput_NetWorkLoc_Leave(sender, e);
                }
                else if (ControlNo == 3)
                {
                    txtPayment.Value = 1000.0;
                    txtPayment_Leave(sender, e);
                }
                else if (ControlNo == 5)
                {
                    doubleInput_VisaLoc.Value = 1000.0;
                    doubleInput_VisaLoc_Leave(sender, e);
                }
            }
            catch
            {
            }
        }
        private void button_X1_Click(object sender, EventArgs e)
        {
            ControlNo = 1;
            CheckSts(ControlNo);
        }
        private void button_X2_Click(object sender, EventArgs e)
        {
            ControlNo = 2;
            CheckSts(ControlNo);
        }
        private void button_X3_Click(object sender, EventArgs e)
        {
            ControlNo = 3;
            CheckSts(ControlNo);
        }
        private void button_X4_Click(object sender, EventArgs e)
        {
            ControlNo = 4;
            CheckSts(ControlNo);
        }
        private void doubleInput_VisaLoc_Enter(object sender, EventArgs e)
        {
            ControlNo = 5;
            CheckSts(ControlNo);
        }
        private void CheckSts(int Sts)
        {
            try
            {
                if (ControlNo == 1)
                {
                    button_X1.Checked = true;
                    button_X2.Checked = false;
                    button_X3.Checked = false;
                    button_X4.Checked = false;
                    button_X9.Checked = false;
                }
                else if (ControlNo == 2)
                {
                    button_X1.Checked = false;
                    button_X2.Checked = true;
                    button_X3.Checked = false;
                    button_X4.Checked = false;
                    button_X9.Checked = false;
                }
                else if (ControlNo == 3)
                {
                    button_X1.Checked = false;
                    button_X2.Checked = false;
                    button_X3.Checked = true;
                    button_X4.Checked = false;
                    button_X9.Checked = false;
                }
                else if (ControlNo == 4)
                {
                    button_X1.Checked = false;
                    button_X2.Checked = false;
                    button_X3.Checked = false;
                    button_X4.Checked = true;
                    button_X9.Checked = false;
                }
                else if (ControlNo == 5)
                {
                    button_X1.Checked = false;
                    button_X2.Checked = false;
                    button_X3.Checked = false;
                    button_X4.Checked = true;
                    button_X9.Checked = true;
                }
            }
            catch
            {
            }
        }
        private void button_SavePrint_Click(object sender, EventArgs e)
        {
            IsPrint = true;
            SaveData();
        }
        private void buttonItem_SrchBanks_Click(object sender, EventArgs e)
        {
            columns_Names_visible.Clear();
            columns_Names_visible.Clear();
            columns_Names_visible.Add("AccDef_No", new ColumnDictinary("الرقم ", " No", ifDefault: true, string.Empty));
            columns_Names_visible.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, string.Empty));
            columns_Names_visible.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, string.Empty));
            columns_Names_visible.Add("AccDef_ID", new ColumnDictinary(" ", " ", ifDefault: false, string.Empty));
            columns_Names_visible.Add("Mobile", new ColumnDictinary("الجوال", "Mobile", ifDefault: false, string.Empty));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
            }
            if (VarGeneral.SSSTyp == 0)
            {
                VarGeneral.SFrmTyp = "T_AccDef";
                VarGeneral.AccTyp = 4;
            }
            else
            {
                VarGeneral.SFrmTyp = "T_AccDef3";
            }
            frm.TopMost = true;
            frm.ShowDialog();
            try
            {
                if (frm.SerachNo != string.Empty)
                {
                    T_AccDef _AccDef = db.StockAccDefs(int.Parse(frm.Serach_No));
                    txtDebit3.Tag = _AccDef.AccDef_No;
                    if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                    {
                        txtDebit3.Text = _AccDef.Arb_Des;
                    }
                    else
                    {
                        txtDebit3.Text = _AccDef.Eng_Des;
                    }
                }
            }
            catch
            {
            }
        }
    }
}
