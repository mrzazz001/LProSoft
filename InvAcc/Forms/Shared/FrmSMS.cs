using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.Editors;
using ProShared.GeneralM;using ProShared;
using ProShared.Stock_Data;
using SSSDateTime.Date;
using SSSLanguage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial  class FrmSMS : Form
    { void avs(int arln)

{ 
 button_SrchMessage1.Text=   (arln == 0 ? "  ادراج نموذج  " : "  insert a form") ; button_SrchGuest.Text=   (arln == 0 ? "  النزلاء  " : "  Guests") ; button_SrchEmps.Text=   (arln == 0 ? "  الموظفين  " : "  employees") ; button_SrchBanks.Text=   (arln == 0 ? "  البنوك  " : "  Banks") ; button_SrchSuppliers.Text=   (arln == 0 ? "  الموردين  " : "  Suppliers") ; label18.Text=   (arln == 0 ? "  حــرف  " : "  letter") ; label16.Text=   (arln == 0 ? "  160 حرف\r\nتعادل رسالة واحدة  " : "  160 characters\r\nequal to one message") ; label14.Text=   (arln == 0 ? "  إرســـال إلى :  " : "  send to:") ; txtMessage.Text=   (arln == 0 ? "  x  " : "  x") ; button_SrchMessage4.Text=   (arln == 0 ? "  نص 4  " : "  text 4") ; button_SrchMessage3.Text=   (arln == 0 ? "  نص 3  " : "  3 . text") ; button_SrchMessage2.Text=   (arln == 0 ? "  نص 2  " : "  text 2") ; txtSender.Text=   (arln == 0 ? "  x  " : "  x") ; txtNumbers.Text=   (arln == 0 ? "  x  " : "  x") ; button_SrchCust.Text=   (arln == 0 ? "  العمــلاء  " : "  customers") ; label12.Text=   (arln == 0 ? "  إسم المرسل  " : "  The sender's name") ; label13.Text=   (arln == 0 ? "  نص الرسالة  " : "  Message text") ; checkBoxX_Guest.Text=   (arln == 0 ? "  النـــــــزلاء  " : "  Guests") ; checkBoxX_Banks.Text=   (arln == 0 ? "  البنــــــوك  " : "  banks") ; checkBoxX_Emp.Text=   (arln == 0 ? "  الموظفــــــين  " : "  staff") ; checkBoxX_Supp.Text=   (arln == 0 ? "  المـــــوردين  " : "  Suppliers") ; checkBoxX_Customer.Text=   (arln == 0 ? "  العمـــــــلاء  " : "  customer") ; txtAddNumber.Text=   (arln == 0 ? "  +  " : "  +") ; txtAddNumber.Text=   (arln == 0 ? " string.Empty " : " string.Empty") ; label15.Text=   (arln == 0 ? "  المرسل :  " : "  sender:") ; smsTxtSender.Text=   (arln == 0 ? "  x  " : "  x") ; labelErorr.Text=   (arln == 0 ? "  تأكد من صحة رقم الجوال أو الرقم السري  " : "  Make sure your mobile number or password is correct") ; label3.Text=   (arln == 0 ? "  رصيد الرسائل :  " : "  Message balance:") ; label2.Text=   (arln == 0 ? "  كلمة المرور :  " : "  password :") ; label1.Text=   (arln == 0 ? "  المستخـــدم :  " : "  User:") ; groupPanel3.Text=   (arln == 0 ? "  القـــوالــب النصيــــة الجاهـــزة  " : "  Ready-made text templates") ; label10.Text=   (arln == 0 ? "  " : "  ") ; label8.Text=   (arln == 0 ? "  " : "  ") ; label6.Text=   (arln == 0 ? "  " : "  ") ; label5.Text=   (arln == 0 ? "  " : "  ") ; label11.Text=   (arln == 0 ? "  عدد الحــروف  " : "  number of letters") ; label7.Text=   (arln == 0 ? "  عدد الحــروف  " : "  number of letters") ; label9.Text=   (arln == 0 ? "  عدد الحــروف  " : "  number of letters") ; label4.Text=   (arln == 0 ? "  عدد الحــروف  " : "  number of letters") ; superTabItem_Sms.Text=   (arln == 0 ? "  إرسال رسالة  " : "  Sending a Message") ; ButWithoutSave.Text=   (arln == 0 ? "  خـروج  " : "  exit") ; ButWithSave.Text=   (arln == 0 ? "  إرسال  " : "  send") ; buttonItem2.Text=   (arln == 0 ? "  نماذج الرسائل  " : "  Message Forms") ; Text = "الرســائل النصيـــة";this.Text=   (arln == 0 ? "  الرســائل النصيـــة  " : "  text messages") ;}
        private void langloads(object sender, EventArgs e)
        {
              avs(ProShared. GeneralM.VarGeneral.currentintlanguage);;
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
        private List<T_INVSETTING> listInvSetting = new List<T_INVSETTING>();
        private T_INVSETTING _InvSetting = new T_INVSETTING();
        private List<T_SYSSETTING> listSysSetting = new List<T_SYSSETTING>();
        private T_SYSSETTING _SysSetting = new T_SYSSETTING();
        private List<T_Company> listCompany = new List<T_Company>();
        private T_Company _Company = new T_Company();
        private List<T_GdAuto> listGdAuto = new List<T_GdAuto>();
        private T_GdAuto _GdAuto = new T_GdAuto();
        private List<T_InfoTb> listInfotb = new List<T_InfoTb>();
        private T_InfoTb _Infotb = new T_InfoTb();
        private int LangArEn = 0;
        private Stock_DataDataContext dbInstance;
        private string _vNum = string.Empty;
        private HijriGreg.HijriGregDates n = new HijriGreg.HijriGregDates();
        protected bool ifOkDelete;
        public bool CanEdit = true;
        protected bool CanInsert = true;
        private FormState statex;
        public List<Control> controls;
        public Control codeControl = new Control();
        private bool canUpdate = true;
        private Dictionary<string, ColumnDictinary> Dir_ButSearch = new Dictionary<string, ColumnDictinary>();
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
        private Panel PanelSpecialContainer;
        public Softgroup.NetResize.NetResize netResize1;
        private RibbonBar ribbonBar1;
        private SuperTabControl superTabControl1;
        private System.Windows.Forms.OpenFileDialog  openFileDialog1;
        private SuperTabControlPanel superTabControlPanel5;
        private SuperTabItem superTabItem_Sms;
        private LabelItem labelItem1;
        private StyleManager styleManager1;
        private ExpandablePanel expandablePanel_SMS;
        private GroupPanel groupPanel3;
        private IntegerInput smsTxtNo4;
        private TextBoxX smsTxt4;
        private IntegerInput smsTxtNo3;
        private TextBoxX smsTxt3;
        private IntegerInput smsTxtNo2;
        private TextBoxX smsTxt2;
        private IntegerInput smsTxtNo1;
        private TextBoxX smsTxt1;
        private GroupPanel groupPanel5;
        private Label label2;
        private TextBox smsTxtPass;
        private Label label1;
        private ButtonItem ButWithSave;
        private ButtonItem ButWithoutSave;
        private LabelItem labelItem2;
        private Label label3;
        private Label label8;
        private Label label9;
        private Label label6;
        private Label label7;
        private Label label5;
        private Label label4;
        private Label label10;
        private Label label11;
        private Label labelErorr;
        private TextBox smsTxtUserName;
        private TextBox smsTxtBalance;
        private GroupBox groupBox1;
        private ButtonX button_SrchCust;
        private Label label12;
        private Label label13;
        private Panel panel1;
        private CheckBoxX checkBoxX_Emp;
        private CheckBoxX checkBoxX_Supp;
        private CheckBoxX checkBoxX_Customer;
        private ButtonX button_SrchMessage1;
        private TextBoxX txtNumbers;
        private TextBoxX txtSender;
        private ButtonX button_SrchMessage4;
        private ButtonX button_SrchMessage3;
        private ButtonX button_SrchMessage2;
        private TextBoxX txtMessage;
        private Label label14;
        private TextBoxX smsTxtSender;
        private Label label15;
        private Label label16;
        private IntegerInput smsTxtNo;
        private Label label18;
        private ButtonX button_SrchSuppliers;
        private ButtonX button_SrchEmps;
        private ButtonX button_SrchBanks;
        private CheckBoxX checkBoxX_Banks;
        private ButtonX button_SrchGuest;
        private CheckBoxX checkBoxX_Guest;
        private ButtonItem buttonItem2;
        public MaskedTextBoxAdv txtAddNumber;
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
        public FrmSMS(string vNum_)
        {
            InitializeComponent();this.Load += langloads;
            _vNum = vNum_;
            smsTxt1.Click += Button_Edit_Click;
            smsTxt2.Click += Button_Edit_Click;
            smsTxt3.Click += Button_Edit_Click;
            smsTxt4.Click += Button_Edit_Click;
            smsTxtSender.Click += Button_Edit_Click;
            smsTxtPass.Click += Button_Edit_Click;
            smsTxtUserName.Click += Button_Edit_Click;
            smsTxt1.ButtonCustomClick += Button_Edit_Click;
            smsTxt2.ButtonCustomClick += Button_Edit_Click;
            smsTxt3.ButtonCustomClick += Button_Edit_Click;
            smsTxt4.ButtonCustomClick += Button_Edit_Click;
            if (VarGeneral.SSSLev == "X")
            {
                button_SrchEmps.Visible = false;
                checkBoxX_Emp.Visible = false;
            }
            if (VarGeneral.SSSLev != "H" && VarGeneral.SSSLev != "X")
            {
                button_SrchGuest.Visible = false;
                checkBoxX_Guest.Visible = false;
            }
        }
        private void Frm_KeyPress(object sender, KeyPressEventArgs e)
        {
        }
        private void Frm_KeyDown(object sender, KeyEventArgs e)
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
        protected override void OnParentRightToLeftChanged(EventArgs e)
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmSMS));
                if (base.Parent.RightToLeft == RightToLeft.Yes)
                {
                    Language.ChangeLanguage("ar-SA", this, resources);
                    LangArEn = 0;
                }
                else
                {
                    Language.ChangeLanguage("en", this, resources);
                    LangArEn = 1;
                }
            }
            BindData();
        }
        private void BindData()
        {
            try
            {
                State = FormState.Saved;
                ButWithSave.Enabled = false;
                smsTxt1.Text = _SysSetting.smsMessage1;
                smsTxt2.Text = _SysSetting.smsMessage2;
                smsTxt3.Text = _SysSetting.smsMessage3;
                smsTxt4.Text = _SysSetting.smsMessage4;
                smsTxtNo1.Value = _SysSetting.smsMessage1.Length;
                smsTxtNo2.Value = _SysSetting.smsMessage2.Length;
                smsTxtNo3.Value = _SysSetting.smsMessage3.Length;
                smsTxtNo4.Value = _SysSetting.smsMessage4.Length;
                smsTxtPass.Text = _SysSetting.smsPass;
                smsTxtUserName.Text = _SysSetting.smsUserName;
                smsTxtSender.Text = _SysSetting.smsSenderName.Trim();
                smsTxtPass_Leave(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void SaveData()
        {
            try
            {
                _SysSetting.smsMessage1 = smsTxt1.Text;
                _SysSetting.smsMessage2 = smsTxt2.Text;
                _SysSetting.smsMessage3 = smsTxt3.Text;
                _SysSetting.smsMessage4 = smsTxt4.Text;
                _SysSetting.smsPass = smsTxtPass.Text;
                _SysSetting.smsUserName = smsTxtUserName.Text;
                _SysSetting.smsSenderName = smsTxtSender.Text.Trim();
                db.Log = VarGeneral.DebugLog;
                db.SubmitChanges(ConflictMode.ContinueOnConflict);
                MessageBox.Show((LangArEn == 0) ? "لقد تم اتمام العملية بنجاح .." : "This Opration Is Done", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                try
                {
                    Stock_DataDataContext dbc = new Stock_DataDataContext(VarGeneral.BranchCS);
                    VarGeneral.Settings_Sys = new T_SYSSETTING();
                    VarGeneral.Settings_Sys = dbc.SystemSettingStock();
                    dbc.getdate = string.Empty;
                }
                catch
                {
                    Application.Exit();
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Save:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void RibunButtons()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
            {
                ButWithSave.Text = "إرسال";
                ButWithSave.Tooltip = "F2";
                ButWithoutSave.Text = "خروج";
                ButWithoutSave.Tooltip = "Esc";
                superTabItem_Sms.Text = ((LangArEn == 0) ? "إرسال رسالة" : "معلومات الحساب");
                labelErorr.Text = "تأكد من صحة رقم الجوال أو الرقم السري";
                Text = "الرســائل النصيـــة";
            }
            else
            {
                ButWithSave.Text = "Send";
                ButWithoutSave.Text = "Exit";
                ButWithSave.Tooltip = "F2";
                ButWithoutSave.Tooltip = "Esc";
                superTabItem_Sms.Text = ((LangArEn == 0) ? "Send Message" : "Account Information");
                labelErorr.Text = "Mobile No Or Password Is Rong";
                Text = "Messages";
            }
        }
        private void FrmSMS_Load(object sender, EventArgs e)
        {
            try
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmSMS));
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                {
                    Language.ChangeLanguage("ar-SA", this, resources);
                    LangArEn = 0;
                }
                else
                {
                    Language.ChangeLanguage("en", this, resources);
                    LangArEn = 1;
                }
                smsTxtPass.Text = VarGeneral.Settings_Sys.smsPass;
                smsTxtUserName.Text = VarGeneral.Settings_Sys.smsUserName;
                columns_Names_visible.Add("Mobile", new ColumnDictinary("الجوال", "Mobile", ifDefault: true, string.Empty));
                columns_Names_visible.Add("Arb_Des", new ColumnDictinary("الإسم عربي", "Arabic Name", ifDefault: true, string.Empty));
                columns_Names_visible.Add("Eng_Des", new ColumnDictinary("الإسم إنجليزي", "English Name", ifDefault: true, string.Empty));
                columns_Names_visible.Add("Telphone1", new ColumnDictinary("هاتف 1", "Phone 1", ifDefault: true, string.Empty));
                columns_Names_visible.Add("AccDef_No", new ColumnDictinary("رقم الحساب", "Account No", ifDefault: true, string.Empty));
                columns_Names_visible.Add("Telphone2", new ColumnDictinary("هاتف 2", "Phone 2", ifDefault: false, string.Empty));
                columns_Names_visible.Add("City", new ColumnDictinary("المدينة", "City", ifDefault: false, string.Empty));
                columns_Names_visible.Add("Adders", new ColumnDictinary("العنوان", "Address", ifDefault: true, string.Empty));
                ADD_Controls();
                RibunButtons();
                MainStep();
                if (!string.IsNullOrEmpty(_vNum))
                {
                    txtAddNumber.Text = _vNum;
                    txtAddNumber_ButtonCustomClick(sender, e);
                }
                if (!string.IsNullOrEmpty(VarGeneral.Settings_Sys.AccSup.Trim()) && VarGeneral.Settings_Sys.AccSup.Trim() != "966")
                {
                    txtAddNumber.Mask = string.Empty;
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Load:", error, enable: true);
                MessageBox.Show(error.Message);
            }
            if (File.Exists(Application.StartupPath + "\\Script\\SecriptTegnicalCollage.dll"))
            {
                TegnicalCollage();
            }
            if (File.Exists(Application.StartupPath + "\\Script\\SecriptWaterPackages.dll"))
            {
                checkBoxX_Customer.Text = ((LangArEn == 0) ? "الطـــلاب" : "Students");
                button_SrchCust.Text = ((LangArEn == 0) ? "الطـــلاب" : "Students");
            }
        }
        private void TegnicalCollage()
        {
            checkBoxX_Customer.Text = ((LangArEn == 0) ? "السائقين" : "Drivers");
            button_SrchCust.Text = ((LangArEn == 0) ? "السائقين" : "Drivers");
        }
        private void MainStep()
        {
            listInvSetting = db.StockInvSettingList(VarGeneral.UserID);
            _InvSetting = listInvSetting[0];
            _SysSetting = db.SystemSettingStock();
            listCompany = db.StockCompanyList();
            _Company = listCompany[0];
            _GdAuto = db.GdAutoStock();
            listInfotb = db.StockInfoList();
            _Infotb = listInfotb[0];
            if (expandablePanel_SMS.Expanded)
            {
                BindData();
                return;
            }
            Clear();
            ButWithSave.Enabled = true;
        }
        public void Clear()
        {
            if (State == FormState.New)
            {
                return;
            }
            State = FormState.New;
            State = FormState.New;
            for (int i = 0; i < controls.Count; i++)
            {
                if (controls[i].GetType() == typeof(DateTimePicker))
                {
                    int? calendr = VarGeneral.Settings_Sys.Calendr;
                    if (calendr.Value == 0 && calendr.HasValue)
                    {
                        (controls[i] as DateTimePicker).Value = Convert.ToDateTime(n.GDateNow());
                    }
                    else
                    {
                        (controls[i] as DateTimePicker).Text = n.HDateNow();
                    }
                }
                else if (controls[i].GetType() == typeof(CheckBox))
                {
                    (controls[i] as CheckBox).Checked = false;
                }
                else if (controls[i].GetType() == typeof(PictureBox))
                {
                    (controls[i] as PictureBox).Image = null;
                }
                else if (!(controls[i].Name == codeControl.Name))
                {
                    if (controls[i].GetType() == typeof(DoubleInput))
                    {
                        (controls[i] as DoubleInput).Value = 0.0;
                    }
                    else if (controls[i].GetType() == typeof(IntegerInput))
                    {
                        (controls[i] as IntegerInput).Value = 0;
                    }
                    else if (controls[i].GetType() == typeof(TextBox) || controls[i].GetType() == typeof(TextBoxX) || controls[i].GetType() == typeof(MaskedTextBox))
                    {
                        controls[i].Text = string.Empty;
                    }
                    else if (controls[i].GetType() == typeof(CheckBox))
                    {
                        (controls[i] as CheckBox).Checked = false;
                    }
                    else if (controls[i].GetType() == typeof(RadioButton))
                    {
                        (controls[i] as RadioButton).Checked = false;
                    }
                }
            }
            checkBoxX_Emp.Checked = false;
            checkBoxX_Customer.Checked = false;
            checkBoxX_Supp.Checked = false;
            checkBoxX_Banks.Checked = false;
            checkBoxX_Guest.Checked = false;
            txtSender.Text = VarGeneral.Settings_Sys.smsSenderName.Trim();
            SetReadOnly = false;
        }
        private void ADD_Controls()
        {
            try
            {
                controls = new List<Control>();
                controls.Add(txtMessage);
                controls.Add(txtNumbers);
                controls.Add(txtAddNumber);
                controls.Add(checkBoxX_Customer);
                controls.Add(checkBoxX_Emp);
                controls.Add(checkBoxX_Supp);
                controls.Add(checkBoxX_Banks);
                controls.Add(checkBoxX_Guest);
            }
            catch (SqlException)
            {
            }
        }
        private void ButWithSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (expandablePanel_SMS.Expanded)
                {
                    SaveData();
                    State = FormState.Saved;
                    SetReadOnly = true;
                    expandablePanel_SMS.Expanded = false;
                }
                else
                {
                    string t = SendMessage(VarGeneral.Settings_Sys.smsUserName, VarGeneral.Settings_Sys.smsPass, ConvertToUnicode(txtMessage.Text), txtSender.Text.Trim(), txtNumbers.Text);
                    ShowResult(t);
                    Clear();
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("ButWithSave_Click:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void ButWithoutSave_Click(object sender, EventArgs e)
        {
            Close();
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
        private void expandablePanel_SMS_ExpandedChanged(object sender, ExpandedChangeEventArgs e)
        {
            if (expandablePanel_SMS.Expanded)
            {
                ButWithSave.Text = ((LangArEn == 0) ? "حفــظ" : "Save");
                superTabItem_Sms.Text = ((LangArEn == 0) ? "بيانات الخدمة" : "Service Data");
                MainStep();
            }
            else
            {
                ButWithSave.Text = ((LangArEn == 0) ? "إرسال" : "Send");
                superTabItem_Sms.Text = ((LangArEn == 0) ? "إرسال رسالة" : "Send Message");
                MainStep();
            }
        }
        private void smsTxt1_TextChanged(object sender, EventArgs e)
        {
            if (State != 0)
            {
                smsTxtNo1.Value = smsTxt1.Text.Length;
            }
        }
        private void smsTxt3_TextChanged(object sender, EventArgs e)
        {
            if (State != 0)
            {
                smsTxtNo3.Value = smsTxt3.Text.Length;
            }
        }
        private void smsTxt2_TextChanged(object sender, EventArgs e)
        {
            if (State != 0)
            {
                smsTxtNo2.Value = smsTxt2.Text.Length;
            }
        }
        private void smsTxt4_TextChanged(object sender, EventArgs e)
        {
            if (State != 0)
            {
                smsTxtNo4.Value = smsTxt4.Text.Length;
            }
        }
        public string SendMessage(string username, string password, string msg, string sender, string numbers)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://www.oursms.net/api/sendsms.php");
            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded";
            string SenderList = string.Empty;
            if (checkBoxX_Customer.Checked)
            {
                List<T_AccDef> LAccDef = new List<T_AccDef>();
                LAccDef = (from t in db.T_AccDefs
                           orderby t.AccDef_No
                           where t.Lev == (int?)4 && t.AccCat == (int?)4
                           where t.Mobile != string.Empty
                           where !t.StopedState.Value
                           where (string.IsNullOrEmpty(VarGeneral.Settings_Sys.AccSup.Trim()) || VarGeneral.Settings_Sys.AccSup.Trim() == "966") ? (t.Mobile.Length >= 10) : (t.Mobile.Length >= 7)
                           select t).ToList();
                if (LAccDef.Count() > 0)
                {
                    for (int i = 0; i < LAccDef.Count; i++)
                    {
                        if (string.IsNullOrEmpty(VarGeneral.Settings_Sys.AccSup.Trim()) || VarGeneral.Settings_Sys.AccSup.Trim() == "966")
                        {
                            if (LAccDef[i].Mobile.StartsWith("05"))
                            {
                                LAccDef[i].Mobile = "966" + LAccDef[i].Mobile.Substring(1);
                            }
                            else if (LAccDef[i].Mobile.StartsWith("009665"))
                            {
                                LAccDef[i].Mobile = LAccDef[i].Mobile.Substring(2);
                            }
                            else if (LAccDef[i].Mobile.StartsWith("0096605"))
                            {
                                LAccDef[i].Mobile = LAccDef[i].Mobile.Substring(2, 3) + LAccDef[i].Mobile.Substring(6);
                            }
                            else if (LAccDef[i].Mobile.StartsWith("96605"))
                            {
                                LAccDef[i].Mobile = LAccDef[i].Mobile.Substring(0, 3) + LAccDef[i].Mobile.Substring(4);
                            }
                            else if (!LAccDef[i].Mobile.StartsWith("96"))
                            {
                                LAccDef.RemoveAt(i);
                                i = 0;
                                continue;
                            }
                            string phoneNum = LAccDef[i].Mobile;
                            Regex regex = new Regex("^\\d{12}$");
                            Match match = regex.Match(phoneNum);
                            if (!match.Success)
                            {
                                LAccDef.RemoveAt(i);
                                i = 0;
                                continue;
                            }
                        }
                        else
                        {
                            LAccDef[i].Mobile = VarGeneral.Settings_Sys.AccSup.Trim() + LAccDef[i].Mobile;
                        }
                        SenderList += (string.IsNullOrEmpty(SenderList) ? LAccDef[i].Mobile : ("," + LAccDef[i].Mobile));
                    }
                }
            }
            if (checkBoxX_Supp.Checked)
            {
                List<T_AccDef> LAccDef = new List<T_AccDef>();
                LAccDef = (from t in db.T_AccDefs
                           orderby t.AccDef_No
                           where t.Lev == (int?)4 && t.AccCat == (int?)5
                           where t.Mobile != string.Empty
                           where !t.StopedState.Value
                           where (string.IsNullOrEmpty(VarGeneral.Settings_Sys.AccSup.Trim()) || VarGeneral.Settings_Sys.AccSup.Trim() == "966") ? (t.Mobile.Length >= 10) : (t.Mobile.Length >= 7)
                           select t).ToList();
                if (LAccDef.Count() > 0)
                {
                    for (int i = 0; i < LAccDef.Count; i++)
                    {
                        if (string.IsNullOrEmpty(VarGeneral.Settings_Sys.AccSup.Trim()) || VarGeneral.Settings_Sys.AccSup.Trim() == "966")
                        {
                            if (LAccDef[i].Mobile.StartsWith("05"))
                            {
                                LAccDef[i].Mobile = "966" + LAccDef[i].Mobile.Substring(1);
                            }
                            else if (LAccDef[i].Mobile.StartsWith("009665"))
                            {
                                LAccDef[i].Mobile = LAccDef[i].Mobile.Substring(2);
                            }
                            else if (LAccDef[i].Mobile.StartsWith("0096605"))
                            {
                                LAccDef[i].Mobile = LAccDef[i].Mobile.Substring(2, 3) + LAccDef[i].Mobile.Substring(6);
                            }
                            else if (LAccDef[i].Mobile.StartsWith("96605"))
                            {
                                LAccDef[i].Mobile = LAccDef[i].Mobile.Substring(0, 3) + LAccDef[i].Mobile.Substring(4);
                            }
                            else if (!LAccDef[i].Mobile.StartsWith("96"))
                            {
                                LAccDef.RemoveAt(i);
                                i = 0;
                                continue;
                            }
                            string phoneNum = LAccDef[i].Mobile;
                            Regex regex = new Regex("^\\d{12}$");
                            Match match = regex.Match(phoneNum);
                            if (!match.Success)
                            {
                                LAccDef.RemoveAt(i);
                                i = 0;
                                continue;
                            }
                        }
                        else
                        {
                            LAccDef[i].Mobile = VarGeneral.Settings_Sys.AccSup.Trim() + LAccDef[i].Mobile;
                        }
                        SenderList += (string.IsNullOrEmpty(SenderList) ? LAccDef[i].Mobile : ("," + LAccDef[i].Mobile));
                    }
                }
            }
            if (checkBoxX_Banks.Checked)
            {
                List<T_AccDef> LAccDef = new List<T_AccDef>();
                LAccDef = (from t in db.T_AccDefs
                           orderby t.AccDef_No
                           where t.Lev == (int?)4 && t.AccCat == (int?)3
                           where t.Mobile != string.Empty
                           where !t.StopedState.Value
                           where (string.IsNullOrEmpty(VarGeneral.Settings_Sys.AccSup.Trim()) || VarGeneral.Settings_Sys.AccSup.Trim() == "966") ? (t.Mobile.Length >= 10) : (t.Mobile.Length >= 7)
                           select t).ToList();
                if (LAccDef.Count() > 0)
                {
                    for (int i = 0; i < LAccDef.Count; i++)
                    {
                        if (string.IsNullOrEmpty(VarGeneral.Settings_Sys.AccSup.Trim()) || VarGeneral.Settings_Sys.AccSup.Trim() == "966")
                        {
                            if (LAccDef[i].Mobile.StartsWith("05"))
                            {
                                LAccDef[i].Mobile = "966" + LAccDef[i].Mobile.Substring(1);
                            }
                            else if (LAccDef[i].Mobile.StartsWith("009665"))
                            {
                                LAccDef[i].Mobile = LAccDef[i].Mobile.Substring(2);
                            }
                            else if (LAccDef[i].Mobile.StartsWith("0096605"))
                            {
                                LAccDef[i].Mobile = LAccDef[i].Mobile.Substring(2, 3) + LAccDef[i].Mobile.Substring(6);
                            }
                            else if (LAccDef[i].Mobile.StartsWith("96605"))
                            {
                                LAccDef[i].Mobile = LAccDef[i].Mobile.Substring(0, 3) + LAccDef[i].Mobile.Substring(4);
                            }
                            else if (!LAccDef[i].Mobile.StartsWith("96"))
                            {
                                LAccDef.RemoveAt(i);
                                i = 0;
                                continue;
                            }
                            string phoneNum = LAccDef[i].Mobile;
                            Regex regex = new Regex("^\\d{12}$");
                            Match match = regex.Match(phoneNum);
                            if (!match.Success)
                            {
                                LAccDef.RemoveAt(i);
                                i = 0;
                                continue;
                            }
                        }
                        else
                        {
                            LAccDef[i].Mobile = VarGeneral.Settings_Sys.AccSup.Trim() + LAccDef[i].Mobile;
                        }
                        SenderList += (string.IsNullOrEmpty(SenderList) ? LAccDef[i].Mobile : ("," + LAccDef[i].Mobile));
                    }
                }
            }
            if (checkBoxX_Emp.Checked)
            {
                if (VarGeneral.SSSLev == "D" || VarGeneral.SSSLev == "E")
                {
                    List<T_Emp> LAccDef2 = new List<T_Emp>();
                    LAccDef2 = (from t in db.T_Emps
                                orderby t.Emp_No
                                where t.EmpState.Value
                                where t.Tel != string.Empty
                                where (string.IsNullOrEmpty(VarGeneral.Settings_Sys.AccSup.Trim()) || VarGeneral.Settings_Sys.AccSup.Trim() == "966") ? (t.Tel.Length >= 10) : (t.Tel.Length >= 7)
                                select t).ToList();
                    if (LAccDef2.Count() > 0)
                    {
                        for (int i = 0; i < LAccDef2.Count; i++)
                        {
                            if (string.IsNullOrEmpty(VarGeneral.Settings_Sys.AccSup.Trim()) || VarGeneral.Settings_Sys.AccSup.Trim() == "966")
                            {
                                if (LAccDef2[i].Tel.StartsWith("05"))
                                {
                                    LAccDef2[i].Tel = "966" + LAccDef2[i].Tel.Substring(1);
                                }
                                else if (LAccDef2[i].Tel.StartsWith("009665"))
                                {
                                    LAccDef2[i].Tel = LAccDef2[i].Tel.Substring(2);
                                }
                                else if (LAccDef2[i].Tel.StartsWith("0096605"))
                                {
                                    LAccDef2[i].Tel = LAccDef2[i].Tel.Substring(2, 3) + LAccDef2[i].Tel.Substring(6);
                                }
                                else if (LAccDef2[i].Tel.StartsWith("96605"))
                                {
                                    LAccDef2[i].Tel = LAccDef2[i].Tel.Substring(0, 3) + LAccDef2[i].Tel.Substring(4);
                                }
                                else if (!LAccDef2[i].Tel.StartsWith("96"))
                                {
                                    LAccDef2.RemoveAt(i);
                                    i = 0;
                                    continue;
                                }
                                string phoneNum = LAccDef2[i].Tel;
                                Regex regex = new Regex("^\\d{12}$");
                                Match match = regex.Match(phoneNum);
                                if (!match.Success)
                                {
                                    LAccDef2.RemoveAt(i);
                                    i = 0;
                                    continue;
                                }
                            }
                            else
                            {
                                LAccDef2[i].Tel = VarGeneral.Settings_Sys.AccSup.Trim() + LAccDef2[i].Tel;
                            }
                            SenderList += (string.IsNullOrEmpty(SenderList) ? LAccDef2[i].Tel : ("," + LAccDef2[i].Tel));
                        }
                    }
                }
                else
                {
                    List<T_AccDef> LAccDef = new List<T_AccDef>();
                    LAccDef = (from t in db.T_AccDefs
                               orderby t.AccDef_No
                               where t.Lev == (int?)4 && t.AccCat == (int?)6
                               where t.Mobile != string.Empty
                               where !t.StopedState.Value
                               where !t.StopedState.Value
                               where (string.IsNullOrEmpty(VarGeneral.Settings_Sys.AccSup.Trim()) || VarGeneral.Settings_Sys.AccSup.Trim() == "966") ? (t.Mobile.Length >= 10) : (t.Mobile.Length >= 7)
                               select t).ToList();
                    if (LAccDef.Count() > 0)
                    {
                        for (int i = 0; i < LAccDef.Count; i++)
                        {
                            if (string.IsNullOrEmpty(VarGeneral.Settings_Sys.AccSup.Trim()) || VarGeneral.Settings_Sys.AccSup.Trim() == "966")
                            {
                                if (LAccDef[i].Mobile.StartsWith("05"))
                                {
                                    LAccDef[i].Mobile = "966" + LAccDef[i].Mobile.Substring(1);
                                }
                                else if (LAccDef[i].Mobile.StartsWith("009665"))
                                {
                                    LAccDef[i].Mobile = LAccDef[i].Mobile.Substring(2);
                                }
                                else if (LAccDef[i].Mobile.StartsWith("0096605"))
                                {
                                    LAccDef[i].Mobile = LAccDef[i].Mobile.Substring(2, 3) + LAccDef[i].Mobile.Substring(6);
                                }
                                else if (LAccDef[i].Mobile.StartsWith("96605"))
                                {
                                    LAccDef[i].Mobile = LAccDef[i].Mobile.Substring(0, 3) + LAccDef[i].Mobile.Substring(4);
                                }
                                else if (!LAccDef[i].Mobile.StartsWith("96"))
                                {
                                    LAccDef.RemoveAt(i);
                                    i = 0;
                                    continue;
                                }
                                string phoneNum = LAccDef[i].Mobile;
                                Regex regex = new Regex("^\\d{12}$");
                                Match match = regex.Match(phoneNum);
                                if (!match.Success)
                                {
                                    LAccDef.RemoveAt(i);
                                    i = 0;
                                    continue;
                                }
                            }
                            else
                            {
                                LAccDef[i].Mobile = VarGeneral.Settings_Sys.AccSup.Trim() + LAccDef[i].Mobile;
                            }
                            SenderList += (string.IsNullOrEmpty(SenderList) ? LAccDef[i].Mobile : ("," + LAccDef[i].Mobile));
                        }
                    }
                }
            }
            if (checkBoxX_Guest.Checked)
            {
                List<T_AccDef> LAccDef = new List<T_AccDef>();
                LAccDef = (from t in db.T_AccDefs
                           orderby t.AccDef_No
                           where t.Lev == (int?)4 && t.AccCat == (int?)11
                           where t.Mobile != string.Empty
                           where !t.StopedState.Value
                           where (string.IsNullOrEmpty(VarGeneral.Settings_Sys.AccSup.Trim()) || VarGeneral.Settings_Sys.AccSup.Trim() == "966") ? (t.Mobile.Length >= 10) : (t.Mobile.Length >= 7)
                           select t).ToList();
                if (LAccDef.Count() > 0)
                {
                    for (int i = 0; i < LAccDef.Count; i++)
                    {
                        if (string.IsNullOrEmpty(VarGeneral.Settings_Sys.AccSup.Trim()) || VarGeneral.Settings_Sys.AccSup.Trim() == "966")
                        {
                            if (LAccDef[i].Mobile.StartsWith("05"))
                            {
                                LAccDef[i].Mobile = "966" + LAccDef[i].Mobile.Substring(1);
                            }
                            else if (LAccDef[i].Mobile.StartsWith("009665"))
                            {
                                LAccDef[i].Mobile = LAccDef[i].Mobile.Substring(2);
                            }
                            else if (LAccDef[i].Mobile.StartsWith("0096605"))
                            {
                                LAccDef[i].Mobile = LAccDef[i].Mobile.Substring(2, 3) + LAccDef[i].Mobile.Substring(6);
                            }
                            else if (LAccDef[i].Mobile.StartsWith("96605"))
                            {
                                LAccDef[i].Mobile = LAccDef[i].Mobile.Substring(0, 3) + LAccDef[i].Mobile.Substring(4);
                            }
                            else if (!LAccDef[i].Mobile.StartsWith("96"))
                            {
                                LAccDef.RemoveAt(i);
                                i = 0;
                                continue;
                            }
                            string phoneNum = LAccDef[i].Mobile;
                            Regex regex = new Regex("^\\d{12}$");
                            Match match = regex.Match(phoneNum);
                            if (!match.Success)
                            {
                                LAccDef.RemoveAt(i);
                                i = 0;
                                continue;
                            }
                        }
                        else
                        {
                            LAccDef[i].Mobile = VarGeneral.Settings_Sys.AccSup.Trim() + LAccDef[i].Mobile;
                        }
                        SenderList += (string.IsNullOrEmpty(SenderList) ? LAccDef[i].Mobile : ("," + LAccDef[i].Mobile));
                    }
                }
            }
            //SendSMS(username, password, sender, (string.IsNullOrEmpty(SenderList) ? numbers : (SenderList + "," + numbers)), msg, "U", "");
            //string postData = "username=@" + username + "&password=@" + password + "&message=@" + msg +"&numbers=" + (string.IsNullOrEmpty(SenderList) ? numbers : (SenderList + "," + numbers)) + "&sender=" + sender +  "&unicode=U&return=full";
            //req.ContentLength = postData.Length;
            //StreamWriter stOut = new StreamWriter(req.GetRequestStream(), Encoding.Unicode);
            //stOut.Write(postData);
            //stOut.Close();
            //StreamReader stIn = new StreamReader(req.GetResponse().GetResponseStream());
            //string strResponse = stIn.ReadToEnd();
            //stIn.Close();
            return SendSMS(username, password, sender, (string.IsNullOrEmpty(SenderList) ? numbers : (SenderList + "," + numbers)), msg, "U", string.Empty);
        }
        private void ShowResult(string res)
        {
            switch (res)
            {
                case "100":
                    MessageBox.Show("تم استلام الارقام بنجاح");
                    break;
                case "101":
                    MessageBox.Show("البيانات ناقصة");
                    break;
                case "102":
                    MessageBox.Show("اسم المستخدم غير صحيح");
                    break;
                case "103":
                    MessageBox.Show("كلمة المرور غير صحيحة");
                    break;
                case "104":
                    MessageBox.Show("لايوجد رصيد في الحساب");
                    break;
                case "105":
                    MessageBox.Show("الرصيد غير كافي");
                    break;
                case "106":
                    MessageBox.Show("اسم المرسل غير متاح");
                    break;
                case "107":
                    MessageBox.Show("اسم المرسل محجوب");
                    break;
                case "108":
                    MessageBox.Show("لايوجد ارقام صالحة للارسال");
                    break;
                case "109":
                    MessageBox.Show("لايمكن الارسال لاكثر من 5 مقاطع");
                    break;
                case "110":
                    MessageBox.Show("خطاء في الارسال الرجاء المحاولة مره اخرى");
                    break;
                case "111":
                    MessageBox.Show("الارسال مغلق");
                    break;
                case "112":
                    MessageBox.Show("الرسالة تحتوي على كلمة محضورة");
                    break;
                case "113":
                    MessageBox.Show("الحساب غير مفعل");
                    break;
                case "114":
                    MessageBox.Show("الحساب موقوف");
                    break;
                case "115":
                    MessageBox.Show("غير مفعل جوال");
                    break;
                case "116":
                    MessageBox.Show("غير مفعل بريد الكتروني ");
                    break;
                default:
                    MessageBox.Show(res.ToString());
                    break;
            }
        }
        public string SendSMS(string tmpUserName, string tmpPassword, string tmpSender, string tmpNubmers, string tmpMsg, string tmpUniCode, string tmpDateTime)
        {
            string str;
            try
            {
                string str5 = tmpMsg;
                if (tmpUniCode == "U")
                {
                    str5 = this.ConvertToUnicode(tmpMsg);
                }
                string s = "return=xml&username=" + tmpUserName + "&password=" + tmpPassword + "&unicode=" + tmpUniCode + "&message=" + str5 + "&sender=" + tmpSender + "&numbers=" + tmpNubmers + (tmpDateTime.Length != 0 ? "&datetime=" + tmpDateTime : string.Empty);
                string requestUriString = "http://www.oursms.net/api/sendsms.php";
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(requestUriString);
                request.Method = "POST";
                request.ContentLength = Encoding.UTF8.GetByteCount(s);
                request.ContentType = "application/x-www-form-urlencoded";
                StreamWriter writer = new StreamWriter(request.GetRequestStream());
                writer.Write(s);
                writer.Close();
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                StreamReader reader = null;
                reader = new StreamReader(response.GetResponseStream());
                DataSet set = new DataSet();
                set.ReadXml(reader);
                DataRow row = set.Tables[0].Rows[0];
                string str4 = row[0].ToString().Trim();
                str = row[1].ToString().Trim();
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                str = exception.Message + "\nلم يتم الاتصال بالانترنت ";
                return str;
            }
            return str;
        }
        private void GetBalance(string username, string password)
        {
            try
            {
                //  string requestUriString =
                labelErorr.Visible = false;
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://www.oursms.net/api/getbalance.php");
                req.Method = "POST";
                req.ContentType = "application/x-www-form-urlencoded";
                string postData = "?username= " + username + " & password = " + password;
                req.ContentLength = Encoding.UTF8.GetByteCount(postData);
                StreamWriter stOut = new StreamWriter(req.GetRequestStream(), Encoding.Unicode);
                stOut.Write(postData);
                stOut.Close();
                StreamReader stIn = new StreamReader(req.GetResponse().GetResponseStream());
                string strResponse = stIn.ReadToEnd();
                stIn.Close();
                switch (strResponse)
                {
                    case "101":
                        MessageBox.Show("البيانات ناقصة");
                        break;
                    case "102":
                        MessageBox.Show("اسم المستخدم غير صحيح");
                        break;
                    case "103":
                        MessageBox.Show("كلمة المرور غير صحيحة");
                        break;
                    case "104":
                        MessageBox.Show("لايوجد رصيد في الحساب");
                        break;
                    case "111":
                        MessageBox.Show("الارسال مغلق");
                        break;
                    case "112":
                        MessageBox.Show("الرسالة تحتوي على كلمة محضورة");
                        break;
                    case "113":
                        MessageBox.Show("الحساب غير مفعل");
                        break;
                    case "114":
                        MessageBox.Show("الحساب موقوف");
                        break;
                    case "115":
                        MessageBox.Show("غير مفعل جوال");
                        break;
                    case "116":
                        MessageBox.Show("غير مفعل بريد الكتروني ");
                        break;
                }
                if (strResponse != "1" && strResponse != "2" && strResponse != "2" && strResponse != "2")
                {
                    try
                    {
                        int q = 0;
                        for (int i = 0; i < strResponse.Length; i++)
                        {
                            if (strResponse.Substring(i, 1) == "/")
                            {
                                q = i;
                                break;
                            }
                        }
                        smsTxtBalance.Text = strResponse.Substring(q + 1);
                    }
                    catch
                    {
                        smsTxtBalance.Text = strResponse;
                    }
                }
                else
                {
                    smsTxtBalance.Text = "0";
                    labelErorr.Visible = true;
                }
            }
            catch
            {
                smsTxtBalance.Text = "0";
                labelErorr.Visible = true;
            }
        }
        private string ConvertToUnicode(string val)
        {
            string msg2 = string.Empty;
            for (int i = 0; i < val.Length; i++)
            {
                msg2 += convertToUnicode(Convert.ToChar(val.Substring(i, 1)));
            }
            return msg2;
        }
        private string convertToUnicode(char ch)
        {
            UnicodeEncoding class1 = new UnicodeEncoding();
            byte[] msg = class1.GetBytes(Convert.ToString(ch));
            return fourDigits(msg[1] + msg[0].ToString("X"));
        }
        private string fourDigits(string val)
        {
            string result = string.Empty;
            switch (val.Length)
            {
                case 1:
                    result = "000" + val;
                    break;
                case 2:
                    result = "00" + val;
                    break;
                case 3:
                    result = "0" + val;
                    break;
                case 4:
                    result = val;
                    break;
            }
            return result;
        }
        private void smsTxtUserName_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(smsTxtPass.Text) || string.IsNullOrEmpty(smsTxtUserName.Text))
            {
                smsTxtBalance.Text = "0";
                labelErorr.Visible = true;
            }
            else
            {
                GetBalance(smsTxtUserName.Text, smsTxtPass.Text);
            }
        }
        private void smsTxtPass_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(smsTxtPass.Text) || string.IsNullOrEmpty(smsTxtUserName.Text))
            {
                smsTxtBalance.Text = "0";
                labelErorr.Visible = true;
            }
            else
            {
                GetBalance(smsTxtUserName.Text, smsTxtPass.Text);
            }
        }
        private void button_SrchMessage_Click(object sender, EventArgs e)
        {
            columns_Names_visible.Add("ID", new ColumnDictinary("رقم النموذج", " No", ifDefault: true, string.Empty));
            columns_Names_visible.Add("Tamplate_Name", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, string.Empty));
            columns_Names_visible.Add("Message", new ColumnDictinary("الاسم الرسالة", "Message", ifDefault: true, string.Empty));
            FrmSearch frm = new FrmSearch();
            frm.smsf = 1;
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
            }
            VarGeneral.SFrmTyp = "T_MTemplate";
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != string.Empty)
            {
                txtMessage.Text = frm.SerachNo.ToString();
            }
        }
        private void txtAddNumber_ButtonCustomClick(object sender, EventArgs e)
        {
            if (!txtNumbers.Enabled)
            {
                return;
            }
            if (string.IsNullOrEmpty(VarGeneral.Settings_Sys.AccSup.Trim()) || VarGeneral.Settings_Sys.AccSup.Trim() == "966")
            {
                string phoneNum = txtAddNumber.Text.Replace("-", string.Empty);
                Regex regex = new Regex("^\\d{10}$");
                Match match = regex.Match(phoneNum);
                if (!match.Success)
                {
                    txtAddNumber.Text = string.Empty;
                    return;
                }
                if (!txtAddNumber.Text.StartsWith("05"))
                {
                    txtAddNumber.Text = string.Empty;
                    return;
                }
            }
            string M_Value = ((!string.IsNullOrEmpty(VarGeneral.Settings_Sys.AccSup.Trim()) && VarGeneral.Settings_Sys.AccSup.Trim() != "966") ? (VarGeneral.Settings_Sys.AccSup.Trim() + txtAddNumber.Text) : ("966" + txtAddNumber.Text.Substring(1)));
            try
            {
                string[] vArray = txtNumbers.Text.Split(',');
                string vitem = Array.Find(vArray, (string element) => element == M_Value.Replace("-", string.Empty));
                if (!string.IsNullOrEmpty(vitem))
                {
                    return;
                }
            }
            catch
            {
            }
            txtNumbers.Text += (string.IsNullOrEmpty(txtNumbers.Text) ? M_Value.Replace("-", string.Empty) : ("," + M_Value.Replace("-", string.Empty)));
            txtAddNumber.Text = string.Empty;
        }
        private void txtNumbers_ButtonCustomClick(object sender, EventArgs e)
        {
            txtNumbers.Text = string.Empty;
        }
        private void txtMessage_ButtonCustomClick(object sender, EventArgs e)
        {
            txtMessage.Text = string.Empty;
        }
        private void txtSender_ButtonCustomClick(object sender, EventArgs e)
        {
            txtSender.Text = string.Empty;
        }
        private void button_SrchMessage2_Click(object sender, EventArgs e)
        {
            txtMessage.Text = VarGeneral.Settings_Sys.smsMessage2;
        }
        private void button_SrchMessage3_Click(object sender, EventArgs e)
        {
            txtMessage.Text = VarGeneral.Settings_Sys.smsMessage3;
        }
        private void button_SrchMessage4_Click(object sender, EventArgs e)
        {
            txtMessage.Text = VarGeneral.Settings_Sys.smsMessage4;
        }
        private void txtMessage_TextChanged(object sender, EventArgs e)
        {
            smsTxtNo.Value = txtMessage.Text.Length;
        }
        private void button_SrchCust_Click(object sender, EventArgs e)
        {
            butSearch(4);
        }
        private void button_SrchSuppliers_Click(object sender, EventArgs e)
        {
            butSearch(5);
        }
        private void button_SrchBanks_Click(object sender, EventArgs e)
        {
            butSearch(3);
        }
        private void butSearch(int vTyp)
        {
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
            }
            VarGeneral.SFrmTyp = "T_SearchNumber";
            VarGeneral.AccTyp = vTyp;
            frm.TopMost = true;
            frm.ShowDialog();
            if (!(frm.SerachNo != string.Empty))
            {
                return;
            }
            try
            {
                string[] vArray = txtNumbers.Text.Split(',');
                string vitem = Array.Find(vArray, (string element) => element == frm.SerachNo);
                if (!string.IsNullOrEmpty(vitem))
                {
                    return;
                }
            }
            catch
            {
            }
            txtNumbers.Text += (string.IsNullOrEmpty(txtNumbers.Text) ? frm.SerachNo.ToString() : ("," + frm.SerachNo.ToString()));
        }
        private void button_SrchEmps_Click(object sender, EventArgs e)
        {
            try
            {
                ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection;
                if (VarGeneral.SSSLev == "D" || VarGeneral.SSSLev == "E")
                {
                    Dir_ButSearch.Add("Tel", new ColumnDictinary("الجــوال", "Mobile", ifDefault: false, string.Empty));
                    Dir_ButSearch.Add("NameA", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, string.Empty));
                    Dir_ButSearch.Add("NameE", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, string.Empty));
                    Dir_ButSearch.Add("Emp_No", new ColumnDictinary("رقم الموظف", "Employee No", ifDefault: true, string.Empty));
                    Dir_ButSearch.Add("DateAppointment", new ColumnDictinary("تاريخ التعيين", "Appointment Date", ifDefault: true, string.Empty));
                    Dir_ButSearch.Add("StartContr", new ColumnDictinary("بداية العقد", "Start Contract Date", ifDefault: false, string.Empty));
                    Dir_ButSearch.Add("EndContr", new ColumnDictinary("نهاية العقد", "End Contract Date", ifDefault: false, string.Empty));
                    Dir_ButSearch.Add("MainSal", new ColumnDictinary("الراتب", "Salary", ifDefault: true, string.Empty));
                    Dir_ButSearch.Add("AddressA", new ColumnDictinary("العنوان", "Address", ifDefault: false, string.Empty));
                    FrmSearch frm2 = new FrmSearch();
                    frm2.Tag = LangArEn;
                    frm2.Tag = LangArEn;
                    animalsAsCollection = Dir_ButSearch;
                    foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
                    {
                        frm2.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
                    }
                    VarGeneral.SFrmTyp = "T_SearchNumberEmp";
                    frm2.TopMost = true;
                    frm2.ShowDialog();
                    if (frm2.SerachNo != string.Empty)
                    {
                        try
                        {
                            string[] vArray = txtNumbers.Text.Split(',');
                            string vitem = Array.Find(vArray, (string element) => element == frm2.SerachNo);
                            if (!string.IsNullOrEmpty(vitem))
                            {
                                return;
                            }
                        }
                        catch
                        {
                        }
                        txtNumbers.Text += (string.IsNullOrEmpty(txtNumbers.Text) ? frm2.SerachNo.ToString() : ("," + frm2.SerachNo.ToString()));
                    }
                    Dir_ButSearch.Clear();
                    return;
                }
                Dir_ButSearch.Add("Mobile", new ColumnDictinary("الجوال", "Mobile", ifDefault: true, string.Empty));
                Dir_ButSearch.Add("Arb_Des", new ColumnDictinary("الإسم عربي", "Arabic Name", ifDefault: true, string.Empty));
                Dir_ButSearch.Add("Eng_Des", new ColumnDictinary("الإسم إنجليزي", "English Name", ifDefault: true, string.Empty));
                Dir_ButSearch.Add("AccDef_No", new ColumnDictinary("رقم الحساب", "Account No", ifDefault: true, string.Empty));
                Dir_ButSearch.Add("Telphone1", new ColumnDictinary("هاتف 1", "Phone 1", ifDefault: true, string.Empty));
                Dir_ButSearch.Add("Telphone2", new ColumnDictinary("هاتف 2", "Phone 2", ifDefault: false, string.Empty));
                Dir_ButSearch.Add("City", new ColumnDictinary("المدينة", "City", ifDefault: false, string.Empty));
                Dir_ButSearch.Add("Adders", new ColumnDictinary("العنوان", "Address", ifDefault: true, string.Empty));
                FrmSearch frm = new FrmSearch();
                frm.Tag = LangArEn;
                frm.Tag = LangArEn;
                animalsAsCollection = Dir_ButSearch;
                foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
                {
                    frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
                }
                VarGeneral.SFrmTyp = "T_SearchNumberEmp";
                frm.TopMost = true;
                frm.ShowDialog();
                if (frm.SerachNo != string.Empty)
                {
                    try
                    {
                        string[] vArray = txtNumbers.Text.Split(',');
                        string vitem = Array.Find(vArray, (string element) => element == frm.SerachNo);
                        if (!string.IsNullOrEmpty(vitem))
                        {
                            return;
                        }
                    }
                    catch
                    {
                    }
                    txtNumbers.Text += (string.IsNullOrEmpty(txtNumbers.Text) ? frm.SerachNo.ToString() : ("," + frm.SerachNo.ToString()));
                }
                Dir_ButSearch.Clear();
            }
            catch
            {
            }
        }
        private void button_SrchGuest_Click(object sender, EventArgs e)
        {
            butSearch(11);
        }
        private void label14_Click(object sender, EventArgs e)
        {
        }
        private void buttonItem2_Click(object sender, EventArgs e)
        {
            FrmMTemplates frm = new FrmMTemplates();
            frm.TopMost = true;
            frm.ShowDialog();
        }
    }
}
