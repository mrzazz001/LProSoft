using DevComponents.DotNetBar;
using DevComponents.Editors;
using InvAcc.GeneralM;
using InvAcc.Stock_Data;
using SSSDateTime.Date;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Ports;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial class FrmPOSPriceForm2 : Form
    {
        public class ColumnDictinary
        {
            public string AText = "";
            public string EText = "";
            public bool IfDefault = false;
            public string Format = "";
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
        private string FlagUpdate = "";
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
        internal Label label17;
        private DoubleInput txtPayment;
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
        private ButtonX buttonX3;
        private ButtonX buttonX4;
        private ButtonX buttonX2;
        private ButtonX buttonX1;
        private ButtonX buttonX5;
        private ButtonX buttonX6;
        private ButtonX buttonX7;
        private ButtonX buttonX8;
        private LabelItem labelD3;
        private ButtonItem buttonItem_SrchBanks;
        private ButtonX buttonX9;
        private ButtonX button_Close;
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
        public FrmPOSPriceForm2()
        {
            InitializeComponent();
            if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49))
            {
                txtPayment.DisplayFormat = VarGeneral.DicemalMask;
                txtPayment.DisplayFormat = VarGeneral.DicemalMask;

                // txtSteel.Value == VarGeneral.DicemalMask;
            }
            ControlNo = 3;
        }
        private void RibunButtons()
        {

        }
        private void FrmPOSPriceForm2_Load(object sender, EventArgs e)
        {
            try
            {
                txtPayment.Value = price;
                this.StartPosition = FormStartPosition.CenterScreen;
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Load:", error, enable: true);
                MessageBox.Show(error.Message);
            }
            if (VarGeneral.Settings_Sys.IsCustomerDisplay.Value)
            {
                CustomerDisplayData(txtPayment.Value, 0.0);
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

        }
        private void txtPaymentLoc_Leave(object sender, EventArgs e)
        {
        }
        private void doubleInput_VisaLoc_Leave(object sender, EventArgs e)
        {
        }
        private void button_Save_Click(object sender, EventArgs e)
        {
            IsPrint = false;
            SaveData();
        }
        private void SaveData()
        {
        }
        private void FrmPOSPriceForm2_KeyDown(object sender, KeyEventArgs e)
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
        private void FrmPOSPriceForm2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                SendKeys.Send("{Tab}");
            }
        }
        private void txtSteel_ValueChanged(object sender, EventArgs e)
        {

        }
        private void txtPayment_Leave(object sender, EventArgs e)
        {
        }
        private void button_1_Click(object sender, EventArgs e)
        {
            try
            {
                if (ControlNo == 1)
                {
                    //doubleInput_VisaLoc txtPaymentLoc.Text.Substring(0, txtPaymentLoc.Text.Length - 3) + "1";
                    txtPaymentLoc_Leave(sender, e);
                }
                else if (ControlNo == 2)
                {
                    //doubleInput_VisaLoc doubleInput_NetWorkLoc.Text.Substring(0, doubleInput_NetWorkLoc.Text.Length - 3) + "1";
                    doubleInput_NetWorkLoc_Leave(sender, e);
                }
                else if (ControlNo == 3)
                {
                    txtPayment.Text = txtPayment.Text.Substring(0, txtPayment.Text.Length - 3) + "1";
                    txtPayment_Leave(sender, e);
                }
                else if (ControlNo == 5)
                {
                    //doubleInput_VisaLoc doubleInput_VisaLoc.Text.Substring(0, txtPayment.Text.Length - 3) + "1";
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
                    //doubleInput_VisaLoc txtPaymentLoc.Text.Substring(0, txtPaymentLoc.Text.Length - 3) + "2";
                    txtPaymentLoc_Leave(sender, e);
                }
                else if (ControlNo == 2)
                {
                    //doubleInput_VisaLoc doubleInput_NetWorkLoc.Text.Substring(0, doubleInput_NetWorkLoc.Text.Length - 3) + "2";
                    doubleInput_NetWorkLoc_Leave(sender, e);
                }
                else if (ControlNo == 3)
                {
                    txtPayment.Text = txtPayment.Text.Substring(0, txtPayment.Text.Length - 3) + "2";
                    txtPayment_Leave(sender, e);
                }
                else if (ControlNo == 5)
                {
                    //doubleInput_VisaLoc doubleInput_VisaLoc.Text.Substring(0, txtPayment.Text.Length - 3) + "1";
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
                    //doubleInput_VisaLoc txtPaymentLoc.Text.Substring(0, txtPaymentLoc.Text.Length - 3) + "3";
                    txtPaymentLoc_Leave(sender, e);
                }
                else if (ControlNo == 2)
                {
                    //doubleInput_VisaLoc doubleInput_NetWorkLoc.Text.Substring(0, doubleInput_NetWorkLoc.Text.Length - 3) + "3";
                    doubleInput_NetWorkLoc_Leave(sender, e);
                }
                else if (ControlNo == 3)
                {
                    txtPayment.Text = txtPayment.Text.Substring(0, txtPayment.Text.Length - 3) + "3";
                    txtPayment_Leave(sender, e);
                }
                else if (ControlNo == 5)
                {
                    //doubleInput_VisaLoc doubleInput_VisaLoc.Text.Substring(0, txtPayment.Text.Length - 3) + "1";
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
                    //doubleInput_VisaLoc txtPaymentLoc.Text.Substring(0, txtPaymentLoc.Text.Length - 3) + "4";
                    txtPaymentLoc_Leave(sender, e);
                    doubleInput_NetWorkLoc_Leave(sender, e);
                }
                else if (ControlNo == 2)
                {
                    //doubleInput_VisaLoc doubleInput_NetWorkLoc.Text.Substring(0, doubleInput_NetWorkLoc.Text.Length - 3) + "4";
                    doubleInput_NetWorkLoc_Leave(sender, e);
                }
                else if (ControlNo == 3)
                {
                    txtPayment.Text = txtPayment.Text.Substring(0, txtPayment.Text.Length - 3) + "4";
                    txtPayment_Leave(sender, e);
                }
                else if (ControlNo == 5)
                {
                    //doubleInput_VisaLoc doubleInput_VisaLoc.Text.Substring(0, txtPayment.Text.Length - 3) + "1";
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
                    //doubleInput_VisaLoc txtPaymentLoc.Text.Substring(0, txtPaymentLoc.Text.Length - 3) + "5";
                    txtPaymentLoc_Leave(sender, e);
                }
                else if (ControlNo == 2)
                {
                    //doubleInput_VisaLoc doubleInput_NetWorkLoc.Text.Substring(0, doubleInput_NetWorkLoc.Text.Length - 3) + "5";
                    doubleInput_NetWorkLoc_Leave(sender, e);
                }
                else if (ControlNo == 3)
                {
                    txtPayment.Text = txtPayment.Text.Substring(0, txtPayment.Text.Length - 3) + "5";
                    txtPayment_Leave(sender, e);
                }
                else if (ControlNo == 5)
                {
                    //doubleInput_VisaLoc doubleInput_VisaLoc.Text.Substring(0, txtPayment.Text.Length - 3) + "1";
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
                    //doubleInput_VisaLoc txtPaymentLoc.Text.Substring(0, txtPaymentLoc.Text.Length - 3) + "6";
                    txtPaymentLoc_Leave(sender, e);
                }
                else if (ControlNo == 2)
                {
                    //doubleInput_VisaLoc doubleInput_NetWorkLoc.Text.Substring(0, doubleInput_NetWorkLoc.Text.Length - 3) + "6";
                    doubleInput_NetWorkLoc_Leave(sender, e);
                }
                else if (ControlNo == 3)
                {
                    txtPayment.Text = txtPayment.Text.Substring(0, txtPayment.Text.Length - 3) + "6";
                    txtPayment_Leave(sender, e);
                }
                else if (ControlNo == 5)
                {
                    //doubleInput_VisaLoc doubleInput_VisaLoc.Text.Substring(0, txtPayment.Text.Length - 3) + "1";
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

                if (ControlNo == 3)
                {
                    txtPayment.Text = txtPayment.Text.Substring(0, txtPayment.Text.Length - 3) + "9";
                    txtPayment_Leave(sender, e);
                }
                else if (ControlNo == 5)
                {
                    //doubleInput_VisaLoc doubleInput_VisaLoc.Text.Substring(0, txtPayment.Text.Length - 3) + "1";
                    doubleInput_VisaLoc_Leave(sender, e);
                }
            }
            catch
            {
            }
        }
        private void button_8_Click(object sender, EventArgs e)
        {

            if (ControlNo == 3)
            {
                txtPayment.Text = txtPayment.Text.Substring(0, txtPayment.Text.Length - 3) + "8";
                txtPayment_Leave(sender, e);
            }


        }
        private void button_7_Click(object sender, EventArgs e)
        {
            try
            {
                if (ControlNo == 3)
                {
                    txtPayment.Text = txtPayment.Text.Substring(0, txtPayment.Text.Length - 3) + "7";
                    txtPayment_Leave(sender, e);
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
                if (ControlNo == 3)
                {
                    txtPayment.Text = "0";
                    txtPayment_Leave(sender, e);
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
                if (ControlNo == 3)
                {
                    txtPayment.Text = txtPayment.Text.Substring(0, txtPayment.Text.Length - 3) + "0";
                    txtPayment_Leave(sender, e);
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
                if (ControlNo == 3)
                {
                    txtPayment.Value = 1.0;
                    txtPayment_Leave(sender, e);
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
                if (ControlNo == 3)
                {
                    txtPayment.Value = 5.0;
                    txtPayment_Leave(sender, e);
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
                if (ControlNo == 3)
                {
                    txtPayment.Value = 10.0;
                    txtPayment_Leave(sender, e);
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
                if (ControlNo == 3)
                {
                    txtPayment.Value = 50.0;
                    txtPayment_Leave(sender, e);
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
                if (ControlNo == 3)
                {
                    txtPayment.Value = 100.0;
                    txtPayment_Leave(sender, e);
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

                if (ControlNo == 3)
                {
                    txtPayment.Value = 200.0;
                    txtPayment_Leave(sender, e);
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
                if (ControlNo == 3)
                {
                    txtPayment.Value = 500.0;
                    txtPayment_Leave(sender, e);
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

                }
                else if (ControlNo == 2)
                {

                }
                else if (ControlNo == 3)
                {
                    txtPayment.Value = 1000.0;
                    txtPayment_Leave(sender, e);
                }
                else if (ControlNo == 5)
                {
                    //doubleInput_VisaLoc.Value = 1000.0;
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

        }
        private void button_SavePrint_Click(object sender, EventArgs e)
        {
            IsPrint = true;
            //	SaveData();
        }
        private void buttonItem_SrchBanks_Click(object sender, EventArgs e)
        {
            columns_Names_visible.Clear();
            columns_Names_visible.Clear();
            columns_Names_visible.Add("AccDef_No", new ColumnDictinary("الرقم ", " No", ifDefault: true, ""));
            columns_Names_visible.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, ""));
            columns_Names_visible.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, ""));
            columns_Names_visible.Add("AccDef_ID", new ColumnDictinary(" ", " ", ifDefault: false, ""));
            columns_Names_visible.Add("Mobile", new ColumnDictinary("الجوال", "Mobile", ifDefault: false, ""));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, ""));
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
                if (frm.SerachNo != "")
                {
                    T_AccDef _AccDef = db.StockAccDefs(int.Parse(frm.Serach_No));
                    txtDebit3.Tag = _AccDef.AccDef_No;
                    if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPOSPriceForm2));
            this.superTabControl1 = new DevComponents.DotNetBar.SuperTabControl();
            this.superTabControlPanel1 = new DevComponents.DotNetBar.SuperTabControlPanel();
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
            this.txtPayment = new DevComponents.Editors.DoubleInput();
            this.label17 = new System.Windows.Forms.Label();
            this.superTabItem_General = new DevComponents.DotNetBar.SuperTabItem();
            this.labelD3 = new DevComponents.DotNetBar.LabelItem();
            this.txtDebit3 = new DevComponents.DotNetBar.TextBoxItem();
            this.buttonItem_SrchBanks = new DevComponents.DotNetBar.ButtonItem();
            this.buttonX9 = new DevComponents.DotNetBar.ButtonX();
            this.button_Close = new DevComponents.DotNetBar.ButtonX();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl1)).BeginInit();
            this.superTabControl1.SuspendLayout();
            this.superTabControlPanel1.SuspendLayout();
            this.groupPanel_BoardNo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPayment)).BeginInit();
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
            this.superTabControl1.ControlBox.CloseBox.Name = "";
            this.superTabControl1.ControlBox.CloseBox.Tag = null;
            this.superTabControl1.ControlBox.Description = null;
            // 
            // 
            // 
            this.superTabControl1.ControlBox.MenuBox.Category = null;
            this.superTabControl1.ControlBox.MenuBox.Description = null;
            this.superTabControl1.ControlBox.MenuBox.Name = "";
            this.superTabControl1.ControlBox.MenuBox.Tag = null;
            this.superTabControl1.ControlBox.MenuBox.Visible = false;
            this.superTabControl1.ControlBox.Name = "";
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
            this.superTabControl1.Size = new System.Drawing.Size(556, 318);
            this.superTabControl1.TabFont = new System.Drawing.Font("Tahoma", 8F);
            this.superTabControl1.TabIndex = 1121;
            this.superTabControl1.TabLayoutType = DevComponents.DotNetBar.eSuperTabLayoutType.MultiLineFit;
            this.superTabControl1.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.superTabItem_General});
            this.superTabControl1.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.WinMediaPlayer12;
            // 
            // superTabControlPanel1
            // 
            this.superTabControlPanel1.Controls.Add(this.buttonX9);
            this.superTabControlPanel1.Controls.Add(this.button_Close);
            this.superTabControlPanel1.Controls.Add(this.buttonX5);
            this.superTabControlPanel1.Controls.Add(this.buttonX6);
            this.superTabControlPanel1.Controls.Add(this.buttonX7);
            this.superTabControlPanel1.Controls.Add(this.buttonX8);
            this.superTabControlPanel1.Controls.Add(this.buttonX3);
            this.superTabControlPanel1.Controls.Add(this.buttonX4);
            this.superTabControlPanel1.Controls.Add(this.buttonX2);
            this.superTabControlPanel1.Controls.Add(this.buttonX1);
            this.superTabControlPanel1.Controls.Add(this.groupPanel_BoardNo);
            this.superTabControlPanel1.Controls.Add(this.txtPayment);
            this.superTabControlPanel1.Controls.Add(this.label17);
            this.superTabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel1.Location = new System.Drawing.Point(0, 23);
            this.superTabControlPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.superTabControlPanel1.Name = "superTabControlPanel1";
            this.superTabControlPanel1.Size = new System.Drawing.Size(556, 295);
            this.superTabControlPanel1.TabIndex = 1;
            this.superTabControlPanel1.TabItem = this.superTabItem_General;
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
            this.buttonX5.Tag = "";
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
            this.button_Bac.Text = "مسح";
            this.button_Bac.Tooltip = "مسح";
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
            // txtPayment
            // 
            this.txtPayment.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtPayment.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(65)))), ((int)(((byte)(66)))));
            this.txtPayment.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtPayment.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtPayment.BackgroundStyle.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(195)))), ((int)(((byte)(0)))));
            this.txtPayment.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtPayment.DisplayFormat = "0.00";
            this.txtPayment.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtPayment.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold);
            this.txtPayment.ForeColor = System.Drawing.Color.Lime;
            this.txtPayment.Increment = 0D;
            this.txtPayment.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtPayment.Location = new System.Drawing.Point(0, 0);
            this.txtPayment.Margin = new System.Windows.Forms.Padding(4);
            this.txtPayment.Name = "txtPayment";
            this.txtPayment.Size = new System.Drawing.Size(556, 33);
            this.txtPayment.TabIndex = 1122;
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label17.ForeColor = System.Drawing.Color.Navy;
            this.label17.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label17.Location = new System.Drawing.Point(-581, 258);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(61, 13);
            this.label17.TabIndex = 1104;
            this.label17.Text = "الإجمالي :";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // superTabItem_General
            // 
            this.superTabItem_General.AttachedControl = this.superTabControlPanel1;
            this.superTabItem_General.GlobalItem = false;
            this.superTabItem_General.Name = "superTabItem_General";
            this.superTabItem_General.TabFont = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.superTabItem_General.Text = "صافــــي الفــاتـــــورة";
            this.superTabItem_General.TextAlignment = DevComponents.DotNetBar.eItemAlignment.Center;
            // 
            // labelD3
            // 
            this.labelD3.BeginGroup = true;
            this.labelD3.Name = "labelD3";
            this.labelD3.Text = "المدين :";
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
            // buttonItem_SrchBanks
            // 
            this.buttonItem_SrchBanks.Name = "buttonItem_SrchBanks";
            this.buttonItem_SrchBanks.Stretch = true;
            this.buttonItem_SrchBanks.Symbol = "";
            this.buttonItem_SrchBanks.SymbolSize = 25F;
            this.buttonItem_SrchBanks.Click += new System.EventHandler(this.buttonItem_SrchBanks_Click);
            // 
            // buttonX9
            // 
            this.buttonX9.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX9.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.buttonX9.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.buttonX9.Location = new System.Drawing.Point(82, 250);
            this.buttonX9.Name = "buttonX9";
            this.buttonX9.Size = new System.Drawing.Size(186, 45);
            this.buttonX9.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX9.Symbol = "";
            this.buttonX9.SymbolSize = 18F;
            this.buttonX9.TabIndex = 1163;
            this.buttonX9.Text = "تــــراجــــــع";
            this.buttonX9.TextColor = System.Drawing.Color.White;
            this.buttonX9.Click += new System.EventHandler(this.buttonX9_Click);
            // 
            // button_Close
            // 
            this.button_Close.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_Close.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.button_Close.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.button_Close.Location = new System.Drawing.Point(274, 250);
            this.button_Close.Name = "button_Close";
            this.button_Close.Size = new System.Drawing.Size(201, 45);
            this.button_Close.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_Close.Symbol = "";
            this.button_Close.SymbolSize = 18F;
            this.button_Close.TabIndex = 1164;
            this.button_Close.Text = "موافق";
            this.button_Close.TextColor = System.Drawing.Color.White;
            this.button_Close.Click += new System.EventHandler(this.button_Close_Click_1);
            // 
            // FrmPOSPriceForm2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 318);
            this.ControlBox = false;
            this.Controls.Add(this.superTabControl1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(InvAcc.Properties.Resources.favicon));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPOSPriceForm2";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "-";
            this.Load += new System.EventHandler(this.FrmPOSPriceForm2_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmPOSPriceForm2_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FrmPOSPriceForm2_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl1)).EndInit();
            this.superTabControl1.ResumeLayout(false);
            this.superTabControlPanel1.ResumeLayout(false);
            this.superTabControlPanel1.PerformLayout();
            this.groupPanel_BoardNo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtPayment)).EndInit();
            this.Icon = ((System.Drawing.Icon)(InvAcc.Properties.Resources.favicon));
            this.ResumeLayout(false);

        }
        public double price = 0;
        private void button_Close_Click_1(object sender, EventArgs e)
        {
            price = txtPayment.Value;
            Close();
        }
        public T_Item ITemData;
        public T_Unit ItemUnit;
        public string Item_no;
        private void buttonX9_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
