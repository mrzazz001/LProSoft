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
    public partial class FrmPayid : Form
    {
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
        private IContainer components = null;
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
            InitializeComponent();
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
                button_Save.Text = "????????????????   F2";
                button_Close.Text = "??????????????";
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
                MessageBox.Show((LangArEn == 0) ? "???????????? ?????????????? ???????? ???? ???????? ????????????????" : "Can not save without the invoice number", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            double tx = txtDueAmount.Value - double.Parse(txtTax.Tag.ToString());

            if (txtPaymentLoc.Value + doubleInput_NetWorkLoc.Value + doubleInput_VisaLoc.Value > tx)
            {
                MessageBox.Show((LangArEn == 0) ? "???????????? ?????????????? ???????? ???? ???????? ????????????????" : "Can not save without the invoice number", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 68) && txtPayment.Value < txtPaymentLoc.Value)
            {
                MessageBox.Show((LangArEn == 0) ? "?????? ???? ???????? ?????????????? >= ???????? ?????????? ????????\u064e .. ???????? ???????????? ???? ?????? ?????????????? ?????????????????? ??????????\u064e" : "The payee must be more than or equal to the payment box in cash .. Please check the validity of the payee and try again", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
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
                label2.Text = ((LangArEn == 0) ? "?????????? ????" : "Remming");
            }
            else if (txtSteel.Value < 0.0)
            {
                label2.Text = ((LangArEn == 0) ? "?????????? ????????" : "Remming");
            }
            else
            {
                label2.Text = ((LangArEn == 0) ? "??????????????" : "Remming");
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
            columns_Names_visible.Add("AccDef_No", new ColumnDictinary("?????????? ", " No", ifDefault: true, string.Empty));
            columns_Names_visible.Add("Arb_Des", new ColumnDictinary("?????????? ????????", "Arabic Name", ifDefault: true, string.Empty));
            columns_Names_visible.Add("Eng_Des", new ColumnDictinary("?????????? ??????????????????", "English Name", ifDefault: true, string.Empty));
            columns_Names_visible.Add("AccDef_ID", new ColumnDictinary(" ", " ", ifDefault: false, string.Empty));
            columns_Names_visible.Add("Mobile", new ColumnDictinary("????????????", "Mobile", ifDefault: false, string.Empty));
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
        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPayid));
            this.superTabControl1 = new DevComponents.DotNetBar.SuperTabControl();
            this.superTabControlPanel1 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTax = new DevComponents.Editors.DoubleInput();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.button_X4 = new DevComponents.DotNetBar.ButtonX();
            this.button_X3 = new DevComponents.DotNetBar.ButtonX();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSteel = new DevComponents.Editors.DoubleInput();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPayment = new DevComponents.Editors.DoubleInput();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.button_X9 = new DevComponents.DotNetBar.ButtonX();
            this.label20 = new System.Windows.Forms.Label();
            this.doubleInput_VisaLoc = new DevComponents.Editors.DoubleInput();
            this.button_X2 = new DevComponents.DotNetBar.ButtonX();
            this.button_X1 = new DevComponents.DotNetBar.ButtonX();
            this.label18 = new System.Windows.Forms.Label();
            this.txtPaymentLoc = new DevComponents.Editors.DoubleInput();
            this.doubleInput_NetWorkLoc = new DevComponents.Editors.DoubleInput();
            this.buttonX_NetworkBank = new DevComponents.DotNetBar.ButtonX();
            this.itemContainer7 = new DevComponents.DotNetBar.ItemContainer();
            this.labelD3 = new DevComponents.DotNetBar.LabelItem();
            this.txtDebit3 = new DevComponents.DotNetBar.TextBoxItem();
            this.itemContainer_SerchBank = new DevComponents.DotNetBar.ItemContainer();
            this.buttonItem_SrchBanks = new DevComponents.DotNetBar.ButtonItem();
            this.label19 = new System.Windows.Forms.Label();
            this.buttonX5 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX6 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX7 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX8 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX3 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX4 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX2 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.groupPanel_BoardNo = new System.Windows.Forms.GroupBox();
            this.button_Bac = new DevComponents.DotNetBar.ButtonX();
            this.button_0 = new DevComponents.DotNetBar.ButtonX();
            this.button_2 = new DevComponents.DotNetBar.ButtonX();
            this.button_6 = new DevComponents.DotNetBar.ButtonX();
            this.button_5 = new DevComponents.DotNetBar.ButtonX();
            this.button_8 = new DevComponents.DotNetBar.ButtonX();
            this.button_7 = new DevComponents.DotNetBar.ButtonX();
            this.button_3 = new DevComponents.DotNetBar.ButtonX();
            this.button_4 = new DevComponents.DotNetBar.ButtonX();
            this.button_9 = new DevComponents.DotNetBar.ButtonX();
            this.button_1 = new DevComponents.DotNetBar.ButtonX();
            this.txtDueAmount = new DevComponents.Editors.DoubleInput();
            this.label17 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button_SavePrint = new DevComponents.DotNetBar.ButtonX();
            this.button_Save = new DevComponents.DotNetBar.ButtonX();
            this.button_Close = new DevComponents.DotNetBar.ButtonX();
            this.superTabItem_General = new DevComponents.DotNetBar.SuperTabItem();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl1)).BeginInit();
            this.superTabControl1.SuspendLayout();
            this.superTabControlPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTax)).BeginInit();
            this.groupPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSteel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPayment)).BeginInit();
            this.groupPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.doubleInput_VisaLoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPaymentLoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.doubleInput_NetWorkLoc)).BeginInit();
            this.groupPanel_BoardNo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDueAmount)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // superTabControl1
            // 
            // 
            // 
            // 
            this.superTabControl1.ControlBox.Category = null;
            // 
            // 
            // 
            this.superTabControl1.ControlBox.CloseBox.Category = null;
            this.superTabControl1.ControlBox.CloseBox.Description = null;
            this.superTabControl1.ControlBox.CloseBox.Name = string.Empty;
            this.superTabControl1.ControlBox.CloseBox.Tag = null;
            this.superTabControl1.ControlBox.Description = null;
            // 
            // 
            // 
            this.superTabControl1.ControlBox.MenuBox.Category = null;
            this.superTabControl1.ControlBox.MenuBox.Description = null;
            this.superTabControl1.ControlBox.MenuBox.Name = string.Empty;
            this.superTabControl1.ControlBox.MenuBox.Tag = null;
            this.superTabControl1.ControlBox.MenuBox.Visible = false;
            this.superTabControl1.ControlBox.Name = string.Empty;
            this.superTabControl1.ControlBox.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.superTabControl1.ControlBox.MenuBox,
            this.superTabControl1.ControlBox.CloseBox});
            this.superTabControl1.ControlBox.Tag = null;
            this.superTabControl1.Controls.Add(this.superTabControlPanel1);
            this.superTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControl1.Location = new System.Drawing.Point(0, 0);
            this.superTabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.superTabControl1.Name = "superTabControl1";
            this.superTabControl1.ReorderTabsEnabled = true;
            this.superTabControl1.SelectedTabFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.superTabControl1.SelectedTabIndex = 0;
            this.superTabControl1.Size = new System.Drawing.Size(556, 473);
            this.superTabControl1.TabFont = new System.Drawing.Font("Tahoma", 8F);
            this.superTabControl1.TabIndex = 1121;
            this.superTabControl1.TabLayoutType = DevComponents.DotNetBar.eSuperTabLayoutType.MultiLineFit;
            this.superTabControl1.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.superTabItem_General});
            this.superTabControl1.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.WinMediaPlayer12;
            // 
            // superTabControlPanel1
            // 
            this.superTabControlPanel1.Controls.Add(this.label3);
            this.superTabControlPanel1.Controls.Add(this.txtTax);
            this.superTabControlPanel1.Controls.Add(this.groupPanel2);
            this.superTabControlPanel1.Controls.Add(this.groupPanel1);
            this.superTabControlPanel1.Controls.Add(this.buttonX5);
            this.superTabControlPanel1.Controls.Add(this.buttonX6);
            this.superTabControlPanel1.Controls.Add(this.buttonX7);
            this.superTabControlPanel1.Controls.Add(this.buttonX8);
            this.superTabControlPanel1.Controls.Add(this.buttonX3);
            this.superTabControlPanel1.Controls.Add(this.buttonX4);
            this.superTabControlPanel1.Controls.Add(this.buttonX2);
            this.superTabControlPanel1.Controls.Add(this.buttonX1);
            this.superTabControlPanel1.Controls.Add(this.groupPanel_BoardNo);
            this.superTabControlPanel1.Controls.Add(this.txtDueAmount);
            this.superTabControlPanel1.Controls.Add(this.label17);
            this.superTabControlPanel1.Controls.Add(this.groupBox1);
            this.superTabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel1.Location = new System.Drawing.Point(0, 23);
            this.superTabControlPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.superTabControlPanel1.Name = "superTabControlPanel1";
            this.superTabControlPanel1.Size = new System.Drawing.Size(556, 450);
            this.superTabControlPanel1.TabIndex = 1;
            this.superTabControlPanel1.TabItem = this.superTabItem_General;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left));
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(65)))), ((int)(((byte)(66)))));
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(149, 255);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 26);
            this.label3.TabIndex = 1140;
            this.label3.Text = "???????????? ??????????????";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtTax
            // 
            this.txtTax.AllowEmptyState = false;
            this.txtTax.Anchor = ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left));
            // 
            // 
            // 
            this.txtTax.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtTax.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtTax.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtTax.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtTax.DisplayFormat = "0.00";
            this.txtTax.Font = new System.Drawing.Font("Tahoma", 11.5F);
            this.txtTax.ForeColor = System.Drawing.Color.Navy;
            this.txtTax.Increment = 0D;
            this.txtTax.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtTax.IsInputReadOnly = true;
            this.txtTax.Location = new System.Drawing.Point(11, 255);
            this.txtTax.Margin = new System.Windows.Forms.Padding(4);
            this.txtTax.MinValue = 0D;
            this.txtTax.Name = "txtTax";
            this.txtTax.Size = new System.Drawing.Size(136, 26);
            this.txtTax.TabIndex = 1139;
            // 
            // groupPanel2
            // 
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.button_X4);
            this.groupPanel2.Controls.Add(this.button_X3);
            this.groupPanel2.Controls.Add(this.label2);
            this.groupPanel2.Controls.Add(this.txtSteel);
            this.groupPanel2.Controls.Add(this.label1);
            this.groupPanel2.Controls.Add(this.txtPayment);
            this.groupPanel2.Location = new System.Drawing.Point(12, 283);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(262, 90);
            // 
            // 
            // 
            this.groupPanel2.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel2.Style.BackColorGradientAngle = 90;
            this.groupPanel2.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel2.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderBottomWidth = 1;
            this.groupPanel2.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel2.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderLeftWidth = 1;
            this.groupPanel2.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderRightWidth = 1;
            this.groupPanel2.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderTopWidth = 1;
            this.groupPanel2.Style.CornerDiameter = 4;
            this.groupPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel2.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel2.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            // 
            // 
            // 
            this.groupPanel2.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel2.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel2.TabIndex = 1138;
            this.groupPanel2.Text = "????????????????????";
            this.groupPanel2.TitleImagePosition = DevComponents.DotNetBar.eTitleImagePosition.Center;
            // 
            // button_X4
            // 
            this.button_X4.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_X4.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_X4.Location = new System.Drawing.Point(9, 35);
            this.button_X4.Name = "button_X4";
            this.button_X4.Size = new System.Drawing.Size(15, 28);
            this.button_X4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_X4.Symbol = "???";
            this.button_X4.SymbolSize = 7F;
            this.button_X4.TabIndex = 1122;
            this.button_X4.TextColor = System.Drawing.Color.SteelBlue;
            this.button_X4.Click += new System.EventHandler(this.button_X4_Click);
            // 
            // button_X3
            // 
            this.button_X3.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_X3.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_X3.Location = new System.Drawing.Point(9, 6);
            this.button_X3.Name = "button_X3";
            this.button_X3.Size = new System.Drawing.Size(15, 28);
            this.button_X3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_X3.Symbol = "???";
            this.button_X3.SymbolSize = 7F;
            this.button_X3.TabIndex = 1121;
            this.button_X3.TextColor = System.Drawing.Color.SteelBlue;
            this.button_X3.Click += new System.EventHandler(this.button_X3_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(134, 36);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 26);
            this.label2.TabIndex = 1108;
            this.label2.Text = "??????????????";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtSteel
            // 
            this.txtSteel.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtSteel.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtSteel.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtSteel.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtSteel.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtSteel.DisplayFormat = "0.00";
            this.txtSteel.Font = new System.Drawing.Font("Tahoma", 12.5F);
            this.txtSteel.ForeColor = System.Drawing.Color.White;
            this.txtSteel.Increment = 0D;
            this.txtSteel.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtSteel.IsInputReadOnly = true;
            this.txtSteel.Location = new System.Drawing.Point(25, 35);
            this.txtSteel.Margin = new System.Windows.Forms.Padding(4);
            this.txtSteel.Name = "txtSteel";
            this.txtSteel.Size = new System.Drawing.Size(108, 28);
            this.txtSteel.TabIndex = 1107;
            this.txtSteel.ValueChanged += new System.EventHandler(this.txtSteel_ValueChanged);
            this.txtSteel.Enter += new System.EventHandler(this.txtSteel_Enter);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(134, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 26);
            this.label1.TabIndex = 1106;
            this.label1.Text = " ??????????????";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtPayment
            // 
            this.txtPayment.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtPayment.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtPayment.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtPayment.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtPayment.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtPayment.DisplayFormat = "0.00";
            this.txtPayment.Font = new System.Drawing.Font("Tahoma", 12.5F);
            this.txtPayment.ForeColor = System.Drawing.Color.White;
            this.txtPayment.Increment = 0D;
            this.txtPayment.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtPayment.Location = new System.Drawing.Point(25, 6);
            this.txtPayment.Margin = new System.Windows.Forms.Padding(4);
            this.txtPayment.MinValue = 0D;
            this.txtPayment.Name = "txtPayment";
            this.txtPayment.Size = new System.Drawing.Size(108, 28);
            this.txtPayment.TabIndex = 1105;
            this.txtPayment.Enter += new System.EventHandler(this.txtPayment_Enter);
            this.txtPayment.Leave += new System.EventHandler(this.txtPayment_Leave);
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.button_X9);
            this.groupPanel1.Controls.Add(this.label20);
            this.groupPanel1.Controls.Add(this.doubleInput_VisaLoc);
            this.groupPanel1.Controls.Add(this.button_X2);
            this.groupPanel1.Controls.Add(this.button_X1);
            this.groupPanel1.Controls.Add(this.label18);
            this.groupPanel1.Controls.Add(this.txtPaymentLoc);
            this.groupPanel1.Controls.Add(this.doubleInput_NetWorkLoc);
            this.groupPanel1.Controls.Add(this.buttonX_NetworkBank);
            this.groupPanel1.Controls.Add(this.label19);
            this.groupPanel1.Location = new System.Drawing.Point(279, 242);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(262, 131);
            // 
            // 
            // 
            this.groupPanel1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel1.Style.BackColorGradientAngle = 90;
            this.groupPanel1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderBottomWidth = 1;
            this.groupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderLeftWidth = 1;
            this.groupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderRightWidth = 1;
            this.groupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderTopWidth = 1;
            this.groupPanel1.Style.CornerDiameter = 4;
            this.groupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel1.TabIndex = 1137;
            this.groupPanel1.Text = "????????????????????????????";
            // 
            // button_X9
            // 
            this.button_X9.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_X9.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_X9.Location = new System.Drawing.Point(10, 71);
            this.button_X9.Name = "button_X9";
            this.button_X9.Size = new System.Drawing.Size(15, 26);
            this.button_X9.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_X9.Symbol = "???";
            this.button_X9.SymbolSize = 7F;
            this.button_X9.TabIndex = 1130;
            this.button_X9.TextColor = System.Drawing.Color.SteelBlue;
            // 
            // label20
            // 
            this.label20.Anchor = ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left));
            this.label20.BackColor = System.Drawing.Color.Transparent;
            this.label20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label20.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label20.ForeColor = System.Drawing.Color.Navy;
            this.label20.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label20.Location = new System.Drawing.Point(137, 71);
            this.label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(109, 26);
            this.label20.TabIndex = 1129;
            this.label20.Text = "??????????????";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // doubleInput_VisaLoc
            // 
            this.doubleInput_VisaLoc.AllowEmptyState = false;
            this.doubleInput_VisaLoc.Anchor = ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left));
            // 
            // 
            // 
            this.doubleInput_VisaLoc.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.doubleInput_VisaLoc.BackgroundStyle.Class = "DateTimeInputBackground";
            this.doubleInput_VisaLoc.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.doubleInput_VisaLoc.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.doubleInput_VisaLoc.DisplayFormat = "0.00";
            this.doubleInput_VisaLoc.Font = new System.Drawing.Font("Tahoma", 11.5F);
            this.doubleInput_VisaLoc.ForeColor = System.Drawing.Color.Navy;
            this.doubleInput_VisaLoc.Increment = 0D;
            this.doubleInput_VisaLoc.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.doubleInput_VisaLoc.Location = new System.Drawing.Point(27, 71);
            this.doubleInput_VisaLoc.Margin = new System.Windows.Forms.Padding(4);
            this.doubleInput_VisaLoc.MinValue = 0D;
            this.doubleInput_VisaLoc.Name = "doubleInput_VisaLoc";
            this.doubleInput_VisaLoc.Size = new System.Drawing.Size(108, 26);
            this.doubleInput_VisaLoc.TabIndex = 1128;
            this.doubleInput_VisaLoc.Enter += new System.EventHandler(this.doubleInput_VisaLoc_Enter);
            this.doubleInput_VisaLoc.Leave += new System.EventHandler(this.doubleInput_VisaLoc_Leave);
            // 
            // button_X2
            // 
            this.button_X2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_X2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_X2.Location = new System.Drawing.Point(9, 43);
            this.button_X2.Name = "button_X2";
            this.button_X2.Size = new System.Drawing.Size(15, 26);
            this.button_X2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_X2.Symbol = "???";
            this.button_X2.SymbolSize = 7F;
            this.button_X2.TabIndex = 1127;
            this.button_X2.TextColor = System.Drawing.Color.SteelBlue;
            this.button_X2.Click += new System.EventHandler(this.button_X2_Click);
            // 
            // button_X1
            // 
            this.button_X1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_X1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_X1.Location = new System.Drawing.Point(9, 14);
            this.button_X1.Name = "button_X1";
            this.button_X1.Size = new System.Drawing.Size(15, 26);
            this.button_X1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_X1.Symbol = "???";
            this.button_X1.SymbolSize = 7F;
            this.button_X1.TabIndex = 1126;
            this.button_X1.TextColor = System.Drawing.Color.SteelBlue;
            this.button_X1.Click += new System.EventHandler(this.button_X1_Click);
            // 
            // label18
            // 
            this.label18.Anchor = ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left));
            this.label18.BackColor = System.Drawing.Color.Transparent;
            this.label18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label18.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label18.ForeColor = System.Drawing.Color.Navy;
            this.label18.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label18.Location = new System.Drawing.Point(136, 14);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(109, 26);
            this.label18.TabIndex = 1124;
            this.label18.Text = "????????????????";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtPaymentLoc
            // 
            this.txtPaymentLoc.AllowEmptyState = false;
            this.txtPaymentLoc.Anchor = ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left));
            // 
            // 
            // 
            this.txtPaymentLoc.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtPaymentLoc.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtPaymentLoc.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtPaymentLoc.DisplayFormat = "0.00";
            this.txtPaymentLoc.Font = new System.Drawing.Font("Tahoma", 11.5F);
            this.txtPaymentLoc.Increment = 0D;
            this.txtPaymentLoc.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtPaymentLoc.Location = new System.Drawing.Point(26, 14);
            this.txtPaymentLoc.Margin = new System.Windows.Forms.Padding(4);
            this.txtPaymentLoc.MinValue = 0D;
            this.txtPaymentLoc.Name = "txtPaymentLoc";
            this.txtPaymentLoc.Size = new System.Drawing.Size(108, 26);
            this.txtPaymentLoc.TabIndex = 1116;
            this.txtPaymentLoc.Enter += new System.EventHandler(this.txtPaymentLoc_Enter);
            this.txtPaymentLoc.Leave += new System.EventHandler(this.txtPaymentLoc_Leave);
            // 
            // doubleInput_NetWorkLoc
            // 
            this.doubleInput_NetWorkLoc.AllowEmptyState = false;
            this.doubleInput_NetWorkLoc.Anchor = ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left));
            // 
            // 
            // 
            this.doubleInput_NetWorkLoc.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.doubleInput_NetWorkLoc.BackgroundStyle.Class = "DateTimeInputBackground";
            this.doubleInput_NetWorkLoc.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.doubleInput_NetWorkLoc.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.doubleInput_NetWorkLoc.DisplayFormat = "0.00";
            this.doubleInput_NetWorkLoc.Font = new System.Drawing.Font("Tahoma", 11.5F);
            this.doubleInput_NetWorkLoc.ForeColor = System.Drawing.Color.Navy;
            this.doubleInput_NetWorkLoc.Increment = 0D;
            this.doubleInput_NetWorkLoc.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.doubleInput_NetWorkLoc.Location = new System.Drawing.Point(26, 43);
            this.doubleInput_NetWorkLoc.Margin = new System.Windows.Forms.Padding(4);
            this.doubleInput_NetWorkLoc.MinValue = 0D;
            this.doubleInput_NetWorkLoc.Name = "doubleInput_NetWorkLoc";
            this.doubleInput_NetWorkLoc.Size = new System.Drawing.Size(108, 26);
            this.doubleInput_NetWorkLoc.TabIndex = 1117;
            this.doubleInput_NetWorkLoc.Enter += new System.EventHandler(this.doubleInput_NetWorkLoc_Enter);
            this.doubleInput_NetWorkLoc.Leave += new System.EventHandler(this.doubleInput_NetWorkLoc_Leave);
            // 
            // buttonX_NetworkBank
            // 
            this.buttonX_NetworkBank.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX_NetworkBank.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
            this.buttonX_NetworkBank.AutoExpandOnClick = true;
            this.buttonX_NetworkBank.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.buttonX_NetworkBank.Location = new System.Drawing.Point(137, 44);
            this.buttonX_NetworkBank.Name = "buttonX_NetworkBank";
            this.buttonX_NetworkBank.ShowSubItems = false;
            this.buttonX_NetworkBank.Size = new System.Drawing.Size(107, 22);
            this.buttonX_NetworkBank.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX_NetworkBank.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.itemContainer7,
            this.itemContainer_SerchBank});
            this.buttonX_NetworkBank.Symbol = "???";
            this.buttonX_NetworkBank.SymbolSize = 12F;
            this.buttonX_NetworkBank.TabIndex = 1131;
            this.buttonX_NetworkBank.Text = "??????????????";
            // 
            // itemContainer7
            // 
            // 
            // 
            // 
            this.itemContainer7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.itemContainer7.BeginGroup = true;
            this.itemContainer7.Name = "itemContainer7";
            this.itemContainer7.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.labelD3,
            this.txtDebit3});
            // 
            // 
            // 
            this.itemContainer7.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // labelD3
            // 
            this.labelD3.BeginGroup = true;
            this.labelD3.Name = "labelD3";
            this.labelD3.Text = "???????????? :";
            this.labelD3.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // txtDebit3
            // 
            this.txtDebit3.CanCustomize = false;
            this.txtDebit3.Enabled = false;
            this.txtDebit3.FocusHighlightEnabled = true;
            this.txtDebit3.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Center;
            this.txtDebit3.Name = "txtDebit3";
            this.txtDebit3.TextBoxWidth = 120;
            this.txtDebit3.WatermarkColor = System.Drawing.SystemColors.GrayText;
            // 
            // itemContainer_SerchBank
            // 
            // 
            // 
            // 
            this.itemContainer_SerchBank.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.itemContainer_SerchBank.BeginGroup = true;
            this.itemContainer_SerchBank.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center;
            this.itemContainer_SerchBank.Name = "itemContainer_SerchBank";
            this.itemContainer_SerchBank.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.buttonItem_SrchBanks});
            // 
            // 
            // 
            this.itemContainer_SerchBank.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // buttonItem_SrchBanks
            // 
            this.buttonItem_SrchBanks.Name = "buttonItem_SrchBanks";
            this.buttonItem_SrchBanks.Stretch = true;
            this.buttonItem_SrchBanks.Symbol = "???";
            this.buttonItem_SrchBanks.SymbolSize = 25F;
            this.buttonItem_SrchBanks.Click += new System.EventHandler(this.buttonItem_SrchBanks_Click);
            // 
            // label19
            // 
            this.label19.Anchor = ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left));
            this.label19.BackColor = System.Drawing.Color.Transparent;
            this.label19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label19.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label19.ForeColor = System.Drawing.Color.Navy;
            this.label19.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label19.Location = new System.Drawing.Point(136, 43);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(109, 26);
            this.label19.TabIndex = 1125;
            this.label19.Text = "??????????????";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label19.Visible = false;
            // 
            // buttonX5
            // 
            this.buttonX5.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.buttonX5.Checked = true;
            this.buttonX5.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.buttonX5.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.buttonX5.Location = new System.Drawing.Point(426, 184);
            this.buttonX5.Margin = new System.Windows.Forms.Padding(4);
            this.buttonX5.Name = "buttonX5";
            this.buttonX5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.buttonX5.Size = new System.Drawing.Size(122, 46);
            this.buttonX5.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX5.SymbolSize = 12F;
            this.buttonX5.TabIndex = 1136;
            this.buttonX5.Tag = string.Empty;
            this.buttonX5.Text = "1000";
            this.buttonX5.TextColor = System.Drawing.Color.Navy;
            this.buttonX5.Click += new System.EventHandler(this.buttonX5_Click);
            // 
            // buttonX6
            // 
            this.buttonX6.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.buttonX6.Checked = true;
            this.buttonX6.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.buttonX6.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.buttonX6.Location = new System.Drawing.Point(426, 137);
            this.buttonX6.Margin = new System.Windows.Forms.Padding(4);
            this.buttonX6.Name = "buttonX6";
            this.buttonX6.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.buttonX6.Size = new System.Drawing.Size(122, 46);
            this.buttonX6.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX6.SymbolSize = 12F;
            this.buttonX6.TabIndex = 1135;
            this.buttonX6.Text = "500";
            this.buttonX6.TextColor = System.Drawing.Color.Navy;
            this.buttonX6.Click += new System.EventHandler(this.buttonX6_Click);
            // 
            // buttonX7
            // 
            this.buttonX7.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.buttonX7.Checked = true;
            this.buttonX7.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.buttonX7.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.buttonX7.Location = new System.Drawing.Point(426, 90);
            this.buttonX7.Margin = new System.Windows.Forms.Padding(4);
            this.buttonX7.Name = "buttonX7";
            this.buttonX7.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.buttonX7.Size = new System.Drawing.Size(122, 46);
            this.buttonX7.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX7.SymbolSize = 12F;
            this.buttonX7.TabIndex = 1134;
            this.buttonX7.Text = "200";
            this.buttonX7.TextColor = System.Drawing.Color.Navy;
            this.buttonX7.Click += new System.EventHandler(this.buttonX7_Click);
            // 
            // buttonX8
            // 
            this.buttonX8.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.buttonX8.Checked = true;
            this.buttonX8.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.buttonX8.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.buttonX8.Location = new System.Drawing.Point(426, 43);
            this.buttonX8.Margin = new System.Windows.Forms.Padding(4);
            this.buttonX8.Name = "buttonX8";
            this.buttonX8.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.buttonX8.Size = new System.Drawing.Size(122, 46);
            this.buttonX8.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX8.SymbolSize = 12F;
            this.buttonX8.TabIndex = 1133;
            this.buttonX8.Text = "100";
            this.buttonX8.TextColor = System.Drawing.Color.Navy;
            this.buttonX8.Click += new System.EventHandler(this.buttonX8_Click);
            // 
            // buttonX3
            // 
            this.buttonX3.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.buttonX3.Checked = true;
            this.buttonX3.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.buttonX3.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.buttonX3.Location = new System.Drawing.Point(302, 184);
            this.buttonX3.Margin = new System.Windows.Forms.Padding(4);
            this.buttonX3.Name = "buttonX3";
            this.buttonX3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.buttonX3.Size = new System.Drawing.Size(122, 46);
            this.buttonX3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX3.SymbolSize = 12F;
            this.buttonX3.TabIndex = 1132;
            this.buttonX3.Text = "50";
            this.buttonX3.TextColor = System.Drawing.Color.Navy;
            this.buttonX3.Click += new System.EventHandler(this.buttonX3_Click);
            // 
            // buttonX4
            // 
            this.buttonX4.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.buttonX4.Checked = true;
            this.buttonX4.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.buttonX4.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.buttonX4.Location = new System.Drawing.Point(302, 137);
            this.buttonX4.Margin = new System.Windows.Forms.Padding(4);
            this.buttonX4.Name = "buttonX4";
            this.buttonX4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.buttonX4.Size = new System.Drawing.Size(122, 46);
            this.buttonX4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX4.SymbolSize = 12F;
            this.buttonX4.TabIndex = 1131;
            this.buttonX4.Text = "10";
            this.buttonX4.TextColor = System.Drawing.Color.Navy;
            this.buttonX4.Click += new System.EventHandler(this.buttonX4_Click);
            // 
            // buttonX2
            // 
            this.buttonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.buttonX2.Checked = true;
            this.buttonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.buttonX2.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.buttonX2.Location = new System.Drawing.Point(302, 90);
            this.buttonX2.Margin = new System.Windows.Forms.Padding(4);
            this.buttonX2.Name = "buttonX2";
            this.buttonX2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.buttonX2.Size = new System.Drawing.Size(122, 46);
            this.buttonX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX2.SymbolSize = 12F;
            this.buttonX2.TabIndex = 1130;
            this.buttonX2.Text = "5";
            this.buttonX2.TextColor = System.Drawing.Color.Navy;
            this.buttonX2.Click += new System.EventHandler(this.buttonX2_Click);
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.buttonX1.Checked = true;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.buttonX1.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.buttonX1.Location = new System.Drawing.Point(302, 43);
            this.buttonX1.Margin = new System.Windows.Forms.Padding(4);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.buttonX1.Size = new System.Drawing.Size(122, 46);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX1.SymbolSize = 12F;
            this.buttonX1.TabIndex = 1129;
            this.buttonX1.Text = "1";
            this.buttonX1.TextColor = System.Drawing.Color.Navy;
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // groupPanel_BoardNo
            // 
            this.groupPanel_BoardNo.BackColor = System.Drawing.Color.Gainsboro;
            this.groupPanel_BoardNo.Controls.Add(this.button_Bac);
            this.groupPanel_BoardNo.Controls.Add(this.button_0);
            this.groupPanel_BoardNo.Controls.Add(this.button_2);
            this.groupPanel_BoardNo.Controls.Add(this.button_6);
            this.groupPanel_BoardNo.Controls.Add(this.button_5);
            this.groupPanel_BoardNo.Controls.Add(this.button_8);
            this.groupPanel_BoardNo.Controls.Add(this.button_7);
            this.groupPanel_BoardNo.Controls.Add(this.button_3);
            this.groupPanel_BoardNo.Controls.Add(this.button_4);
            this.groupPanel_BoardNo.Controls.Add(this.button_9);
            this.groupPanel_BoardNo.Controls.Add(this.button_1);
            this.groupPanel_BoardNo.Location = new System.Drawing.Point(4, 37);
            this.groupPanel_BoardNo.Margin = new System.Windows.Forms.Padding(4);
            this.groupPanel_BoardNo.Name = "groupPanel_BoardNo";
            this.groupPanel_BoardNo.Padding = new System.Windows.Forms.Padding(4);
            this.groupPanel_BoardNo.Size = new System.Drawing.Size(296, 196);
            this.groupPanel_BoardNo.TabIndex = 1128;
            this.groupPanel_BoardNo.TabStop = false;
            // 
            // button_Bac
            // 
            this.button_Bac.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_Bac.Checked = true;
            this.button_Bac.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_Bac.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.button_Bac.Location = new System.Drawing.Point(102, 145);
            this.button_Bac.Margin = new System.Windows.Forms.Padding(4);
            this.button_Bac.Name = "button_Bac";
            this.button_Bac.Size = new System.Drawing.Size(186, 45);
            this.button_Bac.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2000;
            this.button_Bac.TabIndex = 1166;
            this.button_Bac.Text = "??????";
            this.button_Bac.Tooltip = "??????";
            this.button_Bac.Click += new System.EventHandler(this.button_Bac_Click);
            // 
            // button_0
            // 
            this.button_0.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_0.Checked = true;
            this.button_0.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_0.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.button_0.Location = new System.Drawing.Point(7, 145);
            this.button_0.Margin = new System.Windows.Forms.Padding(4);
            this.button_0.Name = "button_0";
            this.button_0.Size = new System.Drawing.Size(92, 45);
            this.button_0.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2000;
            this.button_0.TabIndex = 1165;
            this.button_0.Text = "0";
            this.button_0.Click += new System.EventHandler(this.button_0_Click);
            // 
            // button_2
            // 
            this.button_2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_2.Checked = true;
            this.button_2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.button_2.Location = new System.Drawing.Point(102, 6);
            this.button_2.Margin = new System.Windows.Forms.Padding(4);
            this.button_2.Name = "button_2";
            this.button_2.Size = new System.Drawing.Size(92, 45);
            this.button_2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2000;
            this.button_2.TabIndex = 1163;
            this.button_2.Text = "2";
            this.button_2.Click += new System.EventHandler(this.button_2_Click);
            // 
            // button_6
            // 
            this.button_6.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_6.Checked = true;
            this.button_6.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_6.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.button_6.Location = new System.Drawing.Point(196, 52);
            this.button_6.Margin = new System.Windows.Forms.Padding(4);
            this.button_6.Name = "button_6";
            this.button_6.Size = new System.Drawing.Size(92, 45);
            this.button_6.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2000;
            this.button_6.TabIndex = 1161;
            this.button_6.Text = "6";
            this.button_6.Click += new System.EventHandler(this.button_6_Click);
            // 
            // button_5
            // 
            this.button_5.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_5.Checked = true;
            this.button_5.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_5.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.button_5.Location = new System.Drawing.Point(102, 52);
            this.button_5.Margin = new System.Windows.Forms.Padding(4);
            this.button_5.Name = "button_5";
            this.button_5.Size = new System.Drawing.Size(92, 45);
            this.button_5.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2000;
            this.button_5.TabIndex = 1160;
            this.button_5.Text = "5";
            this.button_5.Click += new System.EventHandler(this.button_5_Click);
            // 
            // button_8
            // 
            this.button_8.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_8.Checked = true;
            this.button_8.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_8.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.button_8.Location = new System.Drawing.Point(102, 99);
            this.button_8.Margin = new System.Windows.Forms.Padding(4);
            this.button_8.Name = "button_8";
            this.button_8.Size = new System.Drawing.Size(92, 45);
            this.button_8.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2000;
            this.button_8.TabIndex = 1157;
            this.button_8.Text = "8";
            this.button_8.Click += new System.EventHandler(this.button_8_Click);
            // 
            // button_7
            // 
            this.button_7.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_7.Checked = true;
            this.button_7.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_7.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.button_7.Location = new System.Drawing.Point(7, 99);
            this.button_7.Margin = new System.Windows.Forms.Padding(4);
            this.button_7.Name = "button_7";
            this.button_7.Size = new System.Drawing.Size(92, 45);
            this.button_7.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2000;
            this.button_7.TabIndex = 1156;
            this.button_7.Text = "7";
            this.button_7.Click += new System.EventHandler(this.button_7_Click);
            // 
            // button_3
            // 
            this.button_3.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_3.Checked = true;
            this.button_3.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_3.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.button_3.Location = new System.Drawing.Point(196, 6);
            this.button_3.Margin = new System.Windows.Forms.Padding(4);
            this.button_3.Name = "button_3";
            this.button_3.Size = new System.Drawing.Size(92, 45);
            this.button_3.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2000;
            this.button_3.TabIndex = 1164;
            this.button_3.Text = "3";
            this.button_3.Click += new System.EventHandler(this.button_3_Click);
            // 
            // button_4
            // 
            this.button_4.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_4.Checked = true;
            this.button_4.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_4.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.button_4.Location = new System.Drawing.Point(7, 52);
            this.button_4.Margin = new System.Windows.Forms.Padding(4);
            this.button_4.Name = "button_4";
            this.button_4.Size = new System.Drawing.Size(92, 45);
            this.button_4.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2000;
            this.button_4.TabIndex = 1159;
            this.button_4.Text = "4";
            this.button_4.Click += new System.EventHandler(this.button_4_Click);
            // 
            // button_9
            // 
            this.button_9.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_9.Checked = true;
            this.button_9.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_9.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.button_9.Location = new System.Drawing.Point(196, 99);
            this.button_9.Margin = new System.Windows.Forms.Padding(4);
            this.button_9.Name = "button_9";
            this.button_9.Size = new System.Drawing.Size(92, 45);
            this.button_9.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2000;
            this.button_9.TabIndex = 1158;
            this.button_9.Text = "9";
            this.button_9.Click += new System.EventHandler(this.button_9_Click);
            // 
            // button_1
            // 
            this.button_1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_1.Checked = true;
            this.button_1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.button_1.Location = new System.Drawing.Point(7, 6);
            this.button_1.Margin = new System.Windows.Forms.Padding(4);
            this.button_1.Name = "button_1";
            this.button_1.Size = new System.Drawing.Size(92, 45);
            this.button_1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2000;
            this.button_1.TabIndex = 1162;
            this.button_1.Text = "1";
            this.button_1.Click += new System.EventHandler(this.button_1_Click);
            // 
            // txtDueAmount
            // 
            this.txtDueAmount.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtDueAmount.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(65)))), ((int)(((byte)(66)))));
            this.txtDueAmount.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtDueAmount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDueAmount.BackgroundStyle.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(195)))), ((int)(((byte)(0)))));
            this.txtDueAmount.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtDueAmount.DisplayFormat = "0.00";
            this.txtDueAmount.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtDueAmount.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold);
            this.txtDueAmount.ForeColor = System.Drawing.Color.Lime;
            this.txtDueAmount.Increment = 0D;
            this.txtDueAmount.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtDueAmount.IsInputReadOnly = true;
            this.txtDueAmount.Location = new System.Drawing.Point(0, 0);
            this.txtDueAmount.Margin = new System.Windows.Forms.Padding(4);
            this.txtDueAmount.Name = "txtDueAmount";
            this.txtDueAmount.Size = new System.Drawing.Size(556, 33);
            this.txtDueAmount.TabIndex = 1122;
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left));
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label17.ForeColor = System.Drawing.Color.Navy;
            this.label17.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label17.Location = new System.Drawing.Point(-581, 413);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(61, 13);
            this.label17.TabIndex = 1104;
            this.label17.Text = "???????????????? :";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.button_SavePrint);
            this.groupBox1.Controls.Add(this.button_Save);
            this.groupBox1.Controls.Add(this.button_Close);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.groupBox1.ForeColor = System.Drawing.Color.Navy;
            this.groupBox1.Location = new System.Drawing.Point(0, 374);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(556, 76);
            this.groupBox1.TabIndex = 1115;
            this.groupBox1.TabStop = false;
            // 
            // button_SavePrint
            // 
            this.button_SavePrint.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SavePrint.Checked = true;
            this.button_SavePrint.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SavePrint.Dock = System.Windows.Forms.DockStyle.Right;
            this.button_SavePrint.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.button_SavePrint.Location = new System.Drawing.Point(188, 22);
            this.button_SavePrint.Margin = new System.Windows.Forms.Padding(4);
            this.button_SavePrint.Name = "button_SavePrint";
            this.button_SavePrint.Size = new System.Drawing.Size(182, 50);
            this.button_SavePrint.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SavePrint.SymbolSize = 12F;
            this.button_SavePrint.TabIndex = 1113;
            this.button_SavePrint.Text = "?????????????? + ????????????  F5";
            this.button_SavePrint.TextColor = System.Drawing.Color.Navy;
            this.button_SavePrint.Click += new System.EventHandler(this.button_SavePrint_Click);
            // 
            // button_Save
            // 
            this.button_Save.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_Save.Checked = true;
            this.button_Save.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_Save.Dock = System.Windows.Forms.DockStyle.Right;
            this.button_Save.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.button_Save.Location = new System.Drawing.Point(370, 22);
            this.button_Save.Margin = new System.Windows.Forms.Padding(4);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(182, 50);
            this.button_Save.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_Save.SymbolSize = 12F;
            this.button_Save.TabIndex = 1111;
            this.button_Save.Text = "????????????????   F2";
            this.button_Save.TextColor = System.Drawing.Color.Navy;
            this.button_Save.Click += new System.EventHandler(this.button_Save_Click);
            // 
            // button_Close
            // 
            this.button_Close.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_Close.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.button_Close.Dock = System.Windows.Forms.DockStyle.Left;
            this.button_Close.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.button_Close.Location = new System.Drawing.Point(4, 22);
            this.button_Close.Margin = new System.Windows.Forms.Padding(4);
            this.button_Close.Name = "button_Close";
            this.button_Close.Size = new System.Drawing.Size(184, 50);
            this.button_Close.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_Close.SymbolSize = 12F;
            this.button_Close.TabIndex = 1112;
            this.button_Close.Text = "????????????????";
            this.button_Close.TextColor = System.Drawing.Color.White;
            this.button_Close.Click += new System.EventHandler(this.button_Close_Click);
            // 
            // superTabItem_General
            // 
            this.superTabItem_General.AttachedControl = this.superTabControlPanel1;
            this.superTabItem_General.GlobalItem = false;
            this.superTabItem_General.Name = "superTabItem_General";
            this.superTabItem_General.TabFont = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.superTabItem_General.Text = "???????????????? ??????????????????????????????";
            this.superTabItem_General.TextAlignment = DevComponents.DotNetBar.eItemAlignment.Center;
            // 
            // FrmPayid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 473);
            this.ControlBox = false;
            this.Controls.Add(this.superTabControl1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = (InvAcc.Properties.Resources.favicon);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPayid";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "-";
            this.Load += new System.EventHandler(this.FrmPayid_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmPayid_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FrmPayid_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl1)).EndInit();
            this.superTabControl1.ResumeLayout(false);
            this.superTabControlPanel1.ResumeLayout(false);
            this.superTabControlPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTax)).EndInit();
            this.groupPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtSteel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPayment)).EndInit();
            this.groupPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.doubleInput_VisaLoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPaymentLoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.doubleInput_NetWorkLoc)).EndInit();
            this.groupPanel_BoardNo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtDueAmount)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.Icon = (InvAcc.Properties.Resources.favicon);
            this.ResumeLayout(false);

        }
    }
}
