using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using InvAcc.GeneralM;
using InvAcc.Stock_Data;
using SSSDateTime.Date;
using SSSLanguage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Ports;
using System.Linq;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial  class FrmCustomerDisplay : Form
    { void avs(int arln)

{ 
 label2custDis.Text=   (arln == 0 ? "  طريقة العرض  " : "  show style") ; button_CheckConn.Text=   (arln == 0 ? "  إختبــــار  " : "  test") ; label14CustDis.Text=   (arln == 0 ? "  رسالة ترحيبية  " : "  welcome message") ; groupPanel3CustDis.Text=   (arln == 0 ? "  التمـــاثل  " : "  symmetry") ; chkSync5.Text=   (arln == 0 ? "  مسافة  " : "  distance") ; chkSync4.Text=   (arln == 0 ? "  علامة  " : "  sign") ; chkSync3.Text=   (arln == 0 ? "  بلا  " : "  without") ; chkSync2.Text=   (arln == 0 ? "  زوجي  " : "  my husband") ; chkSync1.Text=   (arln == 0 ? "  فردي  " : "  Individually") ; groupPanel2CustDis.Text=   (arln == 0 ? "  البيــانات  " : "  data") ; chkData5.Text=   (arln == 0 ? "  8  " : "  8") ; chkData4.Text=   (arln == 0 ? "  7  " : "  7") ; chkData3.Text=   (arln == 0 ? "  6  " : "  6") ; chkData2.Text=   (arln == 0 ? "  5  " : "  5") ; chkData1.Text=   (arln == 0 ? "  4  " : "  4") ; groupPanel1CustDis.Text=   (arln == 0 ? "  التــوقـف  " : "  stop") ; chkStop3.Text=   (arln == 0 ? "  2  " : "  2") ; chkStop2.Text=   (arln == 0 ? "  1.5  " : "  1.5") ; chkStop1.Text=   (arln == 0 ? "  1  " : "  1") ; label1CustDis.Text=   (arln == 0 ? "  الســرعة :  " : "  speed:") ; label8CustDis.Text=   (arln == 0 ? "  المنفـــذ :  " : "  Executor:") ; chkIsActive.Text=   (arln == 0 ? "  تفعيل شاشة الــزبــون  " : "  Activate the customer screen") ; ButWithoutSave.Text=   (arln == 0 ? "  خـــروج  " : "  Close") ; ButWithSave.Text=   (arln == 0 ? "  حفــــظ  " : "  save") ; Text = "شاشة الزبون";this.Text=   (arln == 0 ? "  شاشة الزبون  " : "  customer screen") ;}
        private void langloads(object sender, EventArgs e)
        {
             avs(GeneralM.VarGeneral.currentintlanguage);
        }
   
        public class ColumnDictinaryCusDis
        {
            public string AText = "";
            public string EText = "";
            public bool IfDefault = false;
            public string Format = "";
            public ColumnDictinaryCusDis(string aText, string eText, bool ifDefault, string format)
            {
                AText = aText;
                EText = eText;
                IfDefault = ifDefault;
                Format = format;
            }
        }
       // private IContainer components = null;
        private GroupPanel groupPanel_Main;
        private CheckBoxX chkIsActive;
        private Label label8CustDis;
        private ComboBoxEx cmbPort;
        private Label label1CustDis;
        private ComboBoxEx cmbFast;
        private GroupPanel groupPanel1CustDis;
        private CheckBoxX chkStop1;
        private GroupPanel groupPanel2CustDis;
        private CheckBoxX chkData3;
        private CheckBoxX chkData2;
        private CheckBoxX chkData1;
        private CheckBoxX chkStop3;
        private CheckBoxX chkStop2;
        private GroupPanel groupPanel3CustDis;
        private CheckBoxX chkSync5;
        private CheckBoxX chkSync4;
        private CheckBoxX chkSync3;
        private CheckBoxX chkSync2;
        private CheckBoxX chkSync1;
        private CheckBoxX chkData5;
        private CheckBoxX chkData4;
        private TextBox txtHello;
        private Label label14CustDis;
        private ButtonX button_CheckConn;
        private ButtonX ButWithoutSave;
        private ButtonX ButWithSave;
        private Label label2custDis;
        private ComboBoxEx cmbShowState;
        public Dictionary<string, ColumnDictinaryCusDis> columns_Names_visibleCustDis = new Dictionary<string, ColumnDictinaryCusDis>();
        private List<T_INVSETTING> listInvSettingCustDis = new List<T_INVSETTING>();
        private T_INVSETTING _InvSettingCustDis = new T_INVSETTING();
        private List<T_SYSSETTING> listSysSettingCustDis = new List<T_SYSSETTING>();
        private T_SYSSETTING _SysSettingCustDis = new T_SYSSETTING();
        private List<T_AccDef> listAccDefCustDis = new List<T_AccDef>();
        private T_AccDef _AccDefCustDis = new T_AccDef();
        private List<T_Company> listCompanyCustDis = new List<T_Company>();
        private T_Company _CompanyCustDis = new T_Company();
        private List<T_GdAuto> listGdAutoCustDis = new List<T_GdAuto>();
        private T_GdAuto _GdAutoCustDis = new T_GdAuto();
        private List<T_InfoTb> listInfotbCustDis = new List<T_InfoTb>();
        private T_InfoTb _InfotbCustDis = new T_InfoTb();
        private int LangArEn = 0;
        private Stock_DataDataContext dbInstance;
        protected bool ifOkDelete;
        public bool CanEdit = true;
        protected bool CanInsert = true;
        private FormState statex;
        public List<Control> controls;
        public Control codeControl = new Control();
        private bool canUpdate = true;
        private HijriGreg.HijriGregDates n = new HijriGreg.HijriGregDates();
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
        public bool SetReadOnly
        {
            set
            {
                if (value)
                {
                    State = FormState.Saved;
                }
                ButWithSave.Enabled = !value;
            }
        }
        private void Button_Edit_Click(object sender, EventArgs e)
        {
            if (CanEdit && State != FormState.Edit && State != FormState.New)
            {
                if (State != FormState.New)
                {
                    State = FormState.Edit;
                }
                SetReadOnly = false;
            }
        }
        public FrmCustomerDisplay()
        {
            InitializeComponent();this.Load += langloads;
            cmbPort.Click += Button_Edit_Click;
            cmbFast.Click += Button_Edit_Click;
            cmbShowState.Click += Button_Edit_Click;
            chkStop1.Click += Button_Edit_Click;
            chkStop2.Click += Button_Edit_Click;
            chkStop3.Click += Button_Edit_Click;
            chkData1.Click += Button_Edit_Click;
            chkData2.Click += Button_Edit_Click;
            chkData3.Click += Button_Edit_Click;
            chkData4.Click += Button_Edit_Click;
            chkData5.Click += Button_Edit_Click;
            chkSync1.Click += Button_Edit_Click;
            chkSync2.Click += Button_Edit_Click;
            chkSync3.Click += Button_Edit_Click;
            chkSync4.Click += Button_Edit_Click;
            chkSync5.Click += Button_Edit_Click;
            txtHello.Click += Button_Edit_Click;
            chkIsActive.Click += Button_Edit_Click;
        }
        private void RibunButtonsCustDis()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                ButWithSave.Text = "حفظ";
                ButWithSave.Tooltip = "F2";
                ButWithoutSave.Text = "خروج";
                ButWithoutSave.Tooltip = "Esc";
                chkIsActive.Text = "تفعيل شاشة الــزبــون";
                groupPanel1CustDis.Text = "التــوقـف";
                groupPanel2CustDis.Text = "البيــانات";
                groupPanel3CustDis.Text = "التمـــاثل";
                chkSync1.Text = "فردي";
                chkSync2.Text = "زوجي";
                chkSync3.Text = "بلا";
                chkSync4.Text = "علامة";
                chkSync5.Text = "مسافة";
                button_CheckConn.Text = "إختبــــار";
                Text = "شـاشـة الــزيــون";
            }
            else
            {
                ButWithSave.Text = "Save";
                ButWithoutSave.Text = "Exit";
                ButWithSave.Tooltip = "F2";
                ButWithoutSave.Tooltip = "Esc";
                chkIsActive.Text = "Custome Display Active";
                groupPanel1CustDis.Text = "Bit Stop";
                groupPanel2CustDis.Text = "Bit Data";
                groupPanel3CustDis.Text = "Parity";
                chkSync1.Text = "Single";
                chkSync2.Text = "Double";
                chkSync3.Text = "None";
                chkSync4.Text = "sign";
                chkSync5.Text = "Space";
                button_CheckConn.Text = "Check";
                Text = "Customer Display";
            }
        }
        private void FrmCustomerDisplay_Load(object sender, EventArgs e)
        {
            try
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmCustomerDisplay));
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                {
                    Language.ChangeLanguage("ar-SA", this, resources);
                    LangArEn = 0;
                }
                else
                {
                    Language.ChangeLanguage("en", this, resources);
                    LangArEn = 1;
                }
                RibunButtonsCustDis();
                listInvSettingCustDis = db.StockInvSettingList(VarGeneral.UserID);
                _InvSettingCustDis = listInvSettingCustDis[0];
                _SysSettingCustDis = db.SystemSettingStock();
                listCompanyCustDis = db.StockCompanyList();
                _CompanyCustDis = listCompanyCustDis[0];
                _GdAutoCustDis = db.GdAutoStock();
                listInfotbCustDis = db.StockInfoList();
                _InfotbCustDis = listInfotbCustDis[0];
                listAccDefCustDis = db.FillAccDef_2("").ToList();
                listAccDefCustDis = listAccDefCustDis.Where((T_AccDef q) => q.Trn == 3 && q.Lev == 4 && q.AccDef_No.StartsWith("1") && q.AccCat != 2 && q.AccCat != 3).ToList();
                try
                {
                    FillComboCustDis();
                }
                catch
                {
                }
                try
                {
                    BindDataCustDis();
                }
                catch
                {
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Load:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void FillComboCustDis()
        {
            cmbPort.Items.Clear();
            cmbPort.Items.Add("COM1");
            cmbPort.Items.Add("COM2");
            cmbPort.Items.Add("COM3");
            cmbPort.Items.Add("COM4");
            cmbPort.Items.Add("COM5");
            cmbPort.Items.Add("COM6");
            cmbPort.Items.Add("COM7");
            cmbPort.Items.Add("COM8");
            cmbPort.Items.Add("COM9");
            cmbPort.Items.Add("COM10");
            cmbPort.Items.Add("COM11");
            cmbPort.Items.Add("COM12");
            cmbPort.Items.Add("COM13");
            cmbPort.Items.Add("COM14");
            cmbPort.Items.Add("COM15");
            cmbPort.Items.Add("USB");
            cmbPort.Items.Add("USB1");
            cmbPort.Items.Add("USB2");
            cmbPort.Items.Add("USB3");
            cmbPort.Items.Add("USB4");
            cmbPort.Items.Add("USB5");
            cmbPort.Items.Add("USB6");
            cmbPort.SelectedIndex = 0;
            cmbFast.Items.Clear();
            cmbFast.Items.Add("110");
            cmbFast.Items.Add("300");
            cmbFast.Items.Add("600");
            cmbFast.Items.Add("1200");
            cmbFast.Items.Add("2400");
            cmbFast.Items.Add("9600");
            cmbFast.Items.Add("14400");
            cmbFast.Items.Add("19200");
            cmbFast.Items.Add("28800");
            cmbFast.Items.Add("38400");
            cmbFast.Items.Add("56000");
            cmbFast.Items.Add("128000");
            cmbFast.Items.Add("256000");
            cmbFast.SelectedIndex = 0;
            cmbShowState.Items.Clear();
            cmbShowState.Items.Add((LangArEn == 0) ? "الكـــــــل" : "ALL");
            cmbShowState.Items.Add((LangArEn == 0) ? "السعــر فقط" : "Only Price");
            cmbShowState.Items.Add((LangArEn == 0) ? "الإجمالي فقط" : "Only Total");
            cmbShowState.SelectedIndex = 0;
        }
        private void BindDataCustDis()
        {
            chkIsActive.CheckedChanged -= chkIsActive_CheckedChanged;
            try
            {
                State = FormState.Saved;
                ButWithSave.Enabled = false;
                chkIsActive.Checked = _SysSettingCustDis.IsCustomerDisplay.Value;
                cmbPort.Text = _SysSettingCustDis.Port;
                cmbFast.Text = _SysSettingCustDis.Fast.Value.ToString();
                cmbShowState.SelectedIndex = _SysSettingCustDis.DisplayTypeShow.Value;
                if (_SysSettingCustDis.BitStop.Value == 1)
                {
                    chkStop1.Checked = true;
                }
                else if (_SysSettingCustDis.BitStop.Value == 2)
                {
                    chkStop2.Checked = true;
                }
                else
                {
                    chkStop3.Checked = true;
                }
                if (_SysSettingCustDis.BitData.Value == 4)
                {
                    chkData1.Checked = true;
                }
                else if (_SysSettingCustDis.BitData.Value == 5)
                {
                    chkData2.Checked = true;
                }
                else if (_SysSettingCustDis.BitData.Value == 6)
                {
                    chkData3.Checked = true;
                }
                else if (_SysSettingCustDis.BitData.Value == 7)
                {
                    chkData4.Checked = true;
                }
                else
                {
                    chkData5.Checked = true;
                }
                if (_SysSettingCustDis.Parity.Value == 1)
                {
                    chkSync1.Checked = true;
                }
                else if (_SysSettingCustDis.Parity.Value == 2)
                {
                    chkSync2.Checked = true;
                }
                else if (_SysSettingCustDis.Parity.Value == 3)
                {
                    chkSync3.Checked = true;
                }
                else if (_SysSettingCustDis.Parity.Value == 4)
                {
                    chkSync4.Checked = true;
                }
                else
                {
                    chkSync5.Checked = true;
                }
                txtHello.Text = _SysSettingCustDis.CustomerHello;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            chkIsActive.CheckedChanged += chkIsActive_CheckedChanged;
            chkIsActive_CheckedChanged(null, null);
        }
        private void SaveDataCustDis()
        {
            try
            {
                db.ExecuteCommand("update T_SYSSETTING set IsCustomerDisplay = " + (chkIsActive.Checked ? 1 : 0));
                db.ExecuteCommand("update T_SYSSETTING set Port = '" + cmbPort.Text + "'");
                db.ExecuteCommand("update T_SYSSETTING set Fast = " + cmbFast.Text);
                db.ExecuteCommand("update T_SYSSETTING set DisplayTypeShow = " + cmbShowState.SelectedIndex);
                db.ExecuteCommand("update T_SYSSETTING set BitStop = " + (chkStop1.Checked ? 1 : (chkStop2.Checked ? 2 : 3)));
                db.ExecuteCommand("update T_SYSSETTING set BitData = " + (chkData1.Checked ? 4 : (chkData2.Checked ? 5 : (chkData3.Checked ? 6 : (chkData4.Checked ? 7 : 8)))));
                db.ExecuteCommand("update T_SYSSETTING set Parity = " + (chkSync1.Checked ? 1 : (chkSync2.Checked ? 2 : (chkSync3.Checked ? 3 : (chkSync4.Checked ? 4 : 5)))));
                db.ExecuteCommand("update T_SYSSETTING set CustomerHello = '" + txtHello.Text + "'");
                using (Stock_DataDataContext dbc = new Stock_DataDataContext(VarGeneral.BranchCS))
                {
                    VarGeneral.Settings_Sys = new T_SYSSETTING();
                    VarGeneral.Settings_Sys = dbc.SystemSettingStock();
                    VarGeneral._SysDirPath = VarGeneral.Settings_Sys.SysDir;
                    VarGeneral._BackPath = VarGeneral.Settings_Sys.BackPath;
                    try
                    {
                        VarGeneral._AutoSync = VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 41);
                    }
                    catch
                    {
                        VarGeneral._AutoSync = false;
                    }
                }
                MessageBox.Show((LangArEn == 0) ? "لقد تم اتمام العملية بنجاح .." : "This Opration Is Done", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                Close();
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Save:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void ButWithSave_Click(object sender, EventArgs e)
        {
            SaveDataCustDis();
            State = FormState.Saved;
            SetReadOnly = true;
        }
        private void ButWithoutSave_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void FrmCustomerDisplay_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2 && ButWithSave.Enabled && ButWithSave.Visible)
            {
                ButWithSave_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
        private void FrmCustomerDisplay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                SendKeys.Send("{Tab}");
            }
        }
        private void chkIsActive_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIsActive.Checked)
            {
                groupPanel_Main.Enabled = true;
            }
            else
            {
                groupPanel_Main.Enabled = false;
            }
        }
        private void txtHello_Click(object sender, EventArgs e)
        {
            txtHello.SelectAll();
        }
        private void button_CheckConn_Click(object sender, EventArgs e)
        {
            CustomerDisplayData(0.0, 0.0);
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
                sport.Write(txtHello.Text);
                sport.Write(new byte[2]
                {
                    10,
                    13
                }, 0, 2);
                if (cmbShowState.SelectedIndex == 0)
                {
                    sport.Write("Price:" + _price + " Total:" + _vTot);
                }
                else if (cmbShowState.SelectedIndex == 1)
                {
                    sport.Write("Price:" + _price);
                }
                else
                {
                    sport.Write(" Total:" + _vTot);
                }
                sport.Close();
            }
            catch (Exception error)
            {
                MessageBox.Show((LangArEn == 0) ? "توجد هناك مشكلة في الإتصال بالجهاز الآخر يرجى التأكد من الإعدادات .. ثم المحاولة مرة اخرى " : "There is a problem connecting to the other device Please make sure the settings .. then try again", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                VarGeneral.DebLog.writeLog("CustomerDisplayData :", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
    }
}
