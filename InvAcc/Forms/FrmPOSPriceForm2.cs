using DevComponents.DotNetBar;
using DevComponents.Editors;
using ProShared.GeneralM;using ProShared;
using ProShared.Stock_Data;
using SSSDateTime.Date;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Ports;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial  class FrmPOSPriceForm2 : Form
    { void avs(int arln)

{ 
 buttonX5.Text=   (arln == 0 ? "  1000  " : "  1000") ; buttonX6.Text=   (arln == 0 ? "  500  " : "  500") ; buttonX7.Text=   (arln == 0 ? "  200  " : "  200") ; buttonX8.Text=   (arln == 0 ? "  100  " : "  100") ; buttonX3.Text=   (arln == 0 ? "  50  " : "  50") ; buttonX4.Text=   (arln == 0 ? "  10  " : "  10") ; buttonX2.Text=   (arln == 0 ? "  5  " : "  5") ; buttonX1.Text=   (arln == 0 ? "  1  " : "  1") ; button_Bac.Text=   (arln == 0 ? "  مسح  " : "  Survey") ; button_0.Text=   (arln == 0 ? "  0  " : "  0") ; button_2.Text=   (arln == 0 ? "  2  " : "  2") ; button_6.Text=   (arln == 0 ? "  6  " : "  6") ; button_5.Text=   (arln == 0 ? "  5  " : "  5") ; button_8.Text=   (arln == 0 ? "  8  " : "  8") ; button_7.Text=   (arln == 0 ? "  7  " : "  7") ; button_3.Text=   (arln == 0 ? "  3  " : "  3") ; button_4.Text=   (arln == 0 ? "  4  " : "  4") ; button_9.Text=   (arln == 0 ? "  9  " : "  9") ; button_1.Text=   (arln == 0 ? "  1  " : "  1") ; label17.Text=   (arln == 0 ? "  الإجمالي :  " : "  Total :") ; superTabItem_General.Text=   (arln == 0 ? "  صافــــي الفــاتـــــورة  " : "  net bill") ; labelD3.Text=   (arln == 0 ? "  المدين :  " : "  Debtor:") ; buttonX9.Text=   (arln == 0 ? "  تــــراجــــــع  " : "  backtrack") ; button_Close.Text=   (arln == 0 ? "  موافق  " : "  OK") ; Text = "-";this.Text=   (arln == 0 ? "  -  " : "  -") ;}
        private void langloads(object sender, EventArgs e)
        {
              avs(ProShared. GeneralM.VarGeneral.currentintlanguage);;
        }
   
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
#pragma warning disable CS0414 // The field 'FrmPOSPriceForm2.FlagUpdate' is assigned but its value is never used
        private string FlagUpdate = "";
#pragma warning restore CS0414 // The field 'FrmPOSPriceForm2.FlagUpdate' is assigned but its value is never used
        public ViewState ViewState = ViewState.Deiles;
        private FormState statex;
        public List<Control> controls;
        public Control codeControl = new Control();
        private bool canUpdate = true;
        private int ControlNo = 0;
        private List<string> pkeys = new List<string>();
        private Stock_DataDataContext dbInstance;
        private T_INVHED data_this;
#pragma warning disable CS0414 // The field 'FrmPOSPriceForm2.vNet' is assigned but its value is never used
        private double vNet = 0.0;
#pragma warning restore CS0414 // The field 'FrmPOSPriceForm2.vNet' is assigned but its value is never used
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
            InitializeComponent();this.Load += langloads;
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
