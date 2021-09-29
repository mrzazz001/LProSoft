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
    public partial class FrmSMS : Form
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
        private IContainer components = null;
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
        private OpenFileDialog openFileDialog1;
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
            InitializeComponent();
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
            this.components = new System.ComponentModel.Container();
            this.PanelSpecialContainer = new System.Windows.Forms.Panel();

            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSMS));
            this.ribbonBar1 = new DevComponents.DotNetBar.RibbonBar();
            this.superTabControl1 = new DevComponents.DotNetBar.SuperTabControl();
            this.superTabControlPanel5 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button_SrchMessage1 = new DevComponents.DotNetBar.ButtonX();
            this.button_SrchGuest = new DevComponents.DotNetBar.ButtonX();
            this.button_SrchEmps = new DevComponents.DotNetBar.ButtonX();
            this.button_SrchBanks = new DevComponents.DotNetBar.ButtonX();
            this.button_SrchSuppliers = new DevComponents.DotNetBar.ButtonX();
            this.smsTxtNo = new DevComponents.Editors.IntegerInput();
            this.label18 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtMessage = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.button_SrchMessage4 = new DevComponents.DotNetBar.ButtonX();
            this.button_SrchMessage3 = new DevComponents.DotNetBar.ButtonX();
            this.button_SrchMessage2 = new DevComponents.DotNetBar.ButtonX();
            this.txtSender = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtNumbers = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.button_SrchCust = new DevComponents.DotNetBar.ButtonX();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBoxX_Guest = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.checkBoxX_Banks = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.checkBoxX_Emp = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.checkBoxX_Supp = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.checkBoxX_Customer = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.txtAddNumber = new DevComponents.DotNetBar.Controls.MaskedTextBoxAdv();
            this.expandablePanel_SMS = new DevComponents.DotNetBar.ExpandablePanel();
            this.groupPanel5 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.label15 = new System.Windows.Forms.Label();
            this.smsTxtSender = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.smsTxtBalance = new System.Windows.Forms.TextBox();
            this.labelErorr = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.smsTxtPass = new System.Windows.Forms.TextBox();
            this.smsTxtUserName = new System.Windows.Forms.TextBox();
            this.groupPanel3 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.smsTxtNo4 = new DevComponents.Editors.IntegerInput();
            this.smsTxt4 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.smsTxtNo3 = new DevComponents.Editors.IntegerInput();
            this.smsTxt3 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.smsTxtNo2 = new DevComponents.Editors.IntegerInput();
            this.smsTxt2 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.smsTxtNo1 = new DevComponents.Editors.IntegerInput();
            this.smsTxt1 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label11 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.superTabItem_Sms = new DevComponents.DotNetBar.SuperTabItem();
            this.labelItem1 = new DevComponents.DotNetBar.LabelItem();
            this.labelItem2 = new DevComponents.DotNetBar.LabelItem();
            this.ButWithoutSave = new DevComponents.DotNetBar.ButtonItem();
            this.ButWithSave = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem2 = new DevComponents.DotNetBar.ButtonItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.netResize1 = new Softgroup.NetResize.NetResize(this.components);
            this.netResize1.AfterControlResize += new Softgroup.NetResize.NetResize.AfterControlResizeEventHandler(this.netResize1_AfterControlResize);
            this.Shown += new System.EventHandler(this.FrmInvSale_Shown);
            this.SizeChanged += new System.EventHandler(this.FrmInvSale_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).BeginInit();

            this.ribbonBar1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl1)).BeginInit();
            this.superTabControl1.SuspendLayout();
            this.superTabControlPanel5.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.smsTxtNo)).BeginInit();
            this.panel1.SuspendLayout();
            this.expandablePanel_SMS.SuspendLayout();
            this.groupPanel5.SuspendLayout();
            this.groupPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.smsTxtNo4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.smsTxtNo3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.smsTxtNo2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.smsTxtNo1)).BeginInit();

            this.PanelSpecialContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelSpecialContainer.Location = new System.Drawing.Point(0, 0);
            this.PanelSpecialContainer.Name = "PanelSpecialContainer";
            this.PanelSpecialContainer.Size = new System.Drawing.Size(1278, 514);
            this.PanelSpecialContainer.TabIndex = 1220;
            this.Controls.Add(this.PanelSpecialContainer);
            // 
            // ribbonBar1
            // 
            this.ribbonBar1.AutoOverflowEnabled = true;
            // 
            // 
            // 
            this.ribbonBar1.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar1.ContainerControlProcessDialogKey = true;
            this.ribbonBar1.Controls.Add(this.superTabControl1);
            this.ribbonBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonBar1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.ribbonBar1.Location = new System.Drawing.Point(0, 0);
            this.ribbonBar1.Name = "ribbonBar1";
            this.ribbonBar1.Size = new System.Drawing.Size(580, 440);
            this.ribbonBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonBar1.TabIndex = 868;
            // 
            // 
            // 
            this.ribbonBar1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar1.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // superTabControl1
            // 
            this.superTabControl1.BackColor = System.Drawing.Color.White;
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
            this.superTabControl1.ControlBox.Name = string.Empty;
            this.superTabControl1.ControlBox.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.superTabControl1.ControlBox.MenuBox,
            this.superTabControl1.ControlBox.CloseBox});
            this.superTabControl1.ControlBox.Tag = null;
            this.superTabControl1.ControlBox.Visible = false;
            this.superTabControl1.Controls.Add(this.superTabControlPanel5);
            this.superTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControl1.ForeColor = System.Drawing.Color.Black;
            this.superTabControl1.Location = new System.Drawing.Point(0, 0);
            this.superTabControl1.Name = "superTabControl1";
            this.superTabControl1.ReorderTabsEnabled = true;
            this.superTabControl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.superTabControl1.SelectedTabFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.superTabControl1.SelectedTabIndex = 0;
            this.superTabControl1.Size = new System.Drawing.Size(580, 425);
            this.superTabControl1.TabFont = new System.Drawing.Font("Tahoma", 8F);
            this.superTabControl1.TabHorizontalSpacing = 7;
            this.superTabControl1.TabIndex = 0;
            this.superTabControl1.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.superTabItem_Sms,
            this.labelItem1,
            this.labelItem2,
            this.ButWithoutSave,
            this.ButWithSave,
            this.buttonItem2});
            this.superTabControl1.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.WinMediaPlayer12;
            this.superTabControl1.TabVerticalSpacing = 8;
            this.superTabControl1.TextAlignment = DevComponents.DotNetBar.eItemAlignment.Center;
            // 
            // superTabControlPanel5
            // 
            this.superTabControlPanel5.Controls.Add(this.groupBox1);
            this.superTabControlPanel5.Controls.Add(this.expandablePanel_SMS);
            this.superTabControlPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel5.Location = new System.Drawing.Point(0, 31);
            this.superTabControlPanel5.Name = "superTabControlPanel5";
            this.superTabControlPanel5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.superTabControlPanel5.Size = new System.Drawing.Size(580, 394);
            this.superTabControlPanel5.TabIndex = 0;
            this.superTabControlPanel5.TabItem = this.superTabItem_Sms;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.button_SrchMessage1);
            this.groupBox1.Controls.Add(this.button_SrchGuest);
            this.groupBox1.Controls.Add(this.button_SrchEmps);
            this.groupBox1.Controls.Add(this.button_SrchBanks);
            this.groupBox1.Controls.Add(this.button_SrchSuppliers);
            this.groupBox1.Controls.Add(this.smsTxtNo);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.txtMessage);
            this.groupBox1.Controls.Add(this.button_SrchMessage4);
            this.groupBox1.Controls.Add(this.button_SrchMessage3);
            this.groupBox1.Controls.Add(this.button_SrchMessage2);
            this.groupBox1.Controls.Add(this.txtSender);
            this.groupBox1.Controls.Add(this.txtNumbers);
            this.groupBox1.Controls.Add(this.button_SrchCust);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.txtAddNumber);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(580, 3);
            this.groupBox1.TabIndex = 875;
            this.groupBox1.TabStop = false;
            // 
            // button_SrchMessage1
            // 
            this.button_SrchMessage1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchMessage1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchMessage1.Font = new System.Drawing.Font("Tahoma", 8F);
            this.button_SrchMessage1.Location = new System.Drawing.Point(14, 51);
            this.button_SrchMessage1.Name = "button_SrchMessage1";
            this.button_SrchMessage1.Size = new System.Drawing.Size(48, 115);
            this.button_SrchMessage1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchMessage1.SymbolSize = 12F;
            this.button_SrchMessage1.TabIndex = 10;
            this.button_SrchMessage1.Tag = string.Empty;
            this.button_SrchMessage1.Text = "ادراج نموذج";
            this.button_SrchMessage1.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchMessage1.Click += new System.EventHandler(this.button_SrchMessage_Click);
            // 
            // button_SrchGuest
            // 
            this.button_SrchGuest.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchGuest.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchGuest.Location = new System.Drawing.Point(175, 246);
            this.button_SrchGuest.Name = "button_SrchGuest";
            this.button_SrchGuest.Size = new System.Drawing.Size(129, 26);
            this.button_SrchGuest.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchGuest.Symbol = "";
            this.button_SrchGuest.SymbolSize = 12F;
            this.button_SrchGuest.TabIndex = 1011;
            this.button_SrchGuest.Text = "النزلاء";
            this.button_SrchGuest.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchGuest.Click += new System.EventHandler(this.button_SrchGuest_Click);
            // 
            // button_SrchEmps
            // 
            this.button_SrchEmps.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchEmps.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchEmps.Location = new System.Drawing.Point(307, 274);
            this.button_SrchEmps.Name = "button_SrchEmps";
            this.button_SrchEmps.Size = new System.Drawing.Size(129, 26);
            this.button_SrchEmps.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchEmps.Symbol = "";
            this.button_SrchEmps.SymbolSize = 12F;
            this.button_SrchEmps.TabIndex = 1010;
            this.button_SrchEmps.Text = "الموظفين";
            this.button_SrchEmps.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchEmps.Click += new System.EventHandler(this.button_SrchEmps_Click);
            // 
            // button_SrchBanks
            // 
            this.button_SrchBanks.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchBanks.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchBanks.Location = new System.Drawing.Point(307, 246);
            this.button_SrchBanks.Name = "button_SrchBanks";
            this.button_SrchBanks.Size = new System.Drawing.Size(129, 26);
            this.button_SrchBanks.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchBanks.Symbol = "";
            this.button_SrchBanks.SymbolSize = 12F;
            this.button_SrchBanks.TabIndex = 1009;
            this.button_SrchBanks.Text = "البنوك";
            this.button_SrchBanks.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchBanks.Click += new System.EventHandler(this.button_SrchBanks_Click);
            // 
            // button_SrchSuppliers
            // 
            this.button_SrchSuppliers.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchSuppliers.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchSuppliers.Location = new System.Drawing.Point(439, 274);
            this.button_SrchSuppliers.Name = "button_SrchSuppliers";
            this.button_SrchSuppliers.Size = new System.Drawing.Size(129, 26);
            this.button_SrchSuppliers.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchSuppliers.Symbol = "";
            this.button_SrchSuppliers.SymbolSize = 12F;
            this.button_SrchSuppliers.TabIndex = 1008;
            this.button_SrchSuppliers.Text = "الموردين";
            this.button_SrchSuppliers.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchSuppliers.Click += new System.EventHandler(this.button_SrchSuppliers_Click);
            // 
            // smsTxtNo
            // 
            this.smsTxtNo.AllowEmptyState = false;
            // 
            // 
            // 
            this.smsTxtNo.BackgroundStyle.BackColor = System.Drawing.Color.AliceBlue;
            this.smsTxtNo.BackgroundStyle.Class = "DateTimeInputBackground";
            this.smsTxtNo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.smsTxtNo.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.smsTxtNo.DisplayFormat = "0";
            this.smsTxtNo.Font = new System.Drawing.Font("Tahoma", 8F);
            this.smsTxtNo.ForeColor = System.Drawing.Color.Gray;
            this.smsTxtNo.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.smsTxtNo.IsInputReadOnly = true;
            this.smsTxtNo.Location = new System.Drawing.Point(66, 27);
            this.smsTxtNo.MinValue = 0;
            this.smsTxtNo.Name = "smsTxtNo";
            this.smsTxtNo.Size = new System.Drawing.Size(91, 20);
            this.smsTxtNo.TabIndex = 14;
            // 
            // label18
            // 
            this.label18.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label18.ForeColor = System.Drawing.Color.Navy;
            this.label18.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label18.Location = new System.Drawing.Point(14, 27);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(48, 20);
            this.label18.TabIndex = 1007;
            this.label18.Text = "حــرف";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label16.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label16.ForeColor = System.Drawing.Color.Gray;
            this.label16.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label16.Location = new System.Drawing.Point(438, 76);
            this.label16.Name = "label16";
            this.label16.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label16.Size = new System.Drawing.Size(129, 90);
            this.label16.TabIndex = 32;
            this.label16.Text = "160 حرف\r\nتعادل رسالة واحدة";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label14.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label14.Location = new System.Drawing.Point(439, 195);
            this.label14.Name = "label14";
            this.label14.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label14.Size = new System.Drawing.Size(129, 48);
            this.label14.TabIndex = 31;
            this.label14.Text = "إرســـال إلى :";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label14.Click += new System.EventHandler(this.label14_Click);
            // 
            // txtMessage
            // 
            // 
            // 
            // 
            this.txtMessage.Border.Class = "TextBoxBorder";
            this.txtMessage.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtMessage.ButtonCustom.Text = "x";
            this.txtMessage.ButtonCustom.Visible = true;
            this.txtMessage.Location = new System.Drawing.Point(66, 51);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtMessage.Size = new System.Drawing.Size(370, 115);
            this.txtMessage.TabIndex = 2;
            this.txtMessage.ButtonCustomClick += new System.EventHandler(this.txtMessage_ButtonCustomClick);
            this.txtMessage.TextChanged += new System.EventHandler(this.txtMessage_TextChanged);
            // 
            // button_SrchMessage4
            // 
            this.button_SrchMessage4.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchMessage4.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchMessage4.Font = new System.Drawing.Font("Tahoma", 8F);
            this.button_SrchMessage4.Location = new System.Drawing.Point(14, 138);
            this.button_SrchMessage4.Name = "button_SrchMessage4";
            this.button_SrchMessage4.Size = new System.Drawing.Size(48, 27);
            this.button_SrchMessage4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchMessage4.SymbolSize = 12F;
            this.button_SrchMessage4.TabIndex = 13;
            this.button_SrchMessage4.Text = "نص 4";
            this.button_SrchMessage4.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchMessage4.Click += new System.EventHandler(this.button_SrchMessage4_Click);
            // 
            // button_SrchMessage3
            // 
            this.button_SrchMessage3.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchMessage3.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchMessage3.Font = new System.Drawing.Font("Tahoma", 8F);
            this.button_SrchMessage3.Location = new System.Drawing.Point(14, 109);
            this.button_SrchMessage3.Name = "button_SrchMessage3";
            this.button_SrchMessage3.Size = new System.Drawing.Size(48, 27);
            this.button_SrchMessage3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchMessage3.SymbolSize = 12F;
            this.button_SrchMessage3.TabIndex = 12;
            this.button_SrchMessage3.Text = "نص 3";
            this.button_SrchMessage3.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchMessage3.Click += new System.EventHandler(this.button_SrchMessage3_Click);
            // 
            // button_SrchMessage2
            // 
            this.button_SrchMessage2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchMessage2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchMessage2.Font = new System.Drawing.Font("Tahoma", 8F);
            this.button_SrchMessage2.Location = new System.Drawing.Point(14, 80);
            this.button_SrchMessage2.Name = "button_SrchMessage2";
            this.button_SrchMessage2.Size = new System.Drawing.Size(48, 27);
            this.button_SrchMessage2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchMessage2.SymbolSize = 12F;
            this.button_SrchMessage2.TabIndex = 11;
            this.button_SrchMessage2.Text = "نص 2";
            this.button_SrchMessage2.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchMessage2.Click += new System.EventHandler(this.button_SrchMessage2_Click);
            // 
            // txtSender
            // 
            // 
            // 
            // 
            this.txtSender.Border.Class = "TextBoxBorder";
            this.txtSender.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtSender.ButtonCustom.Text = "x";
            this.txtSender.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.txtSender.Location = new System.Drawing.Point(235, 27);
            this.txtSender.Name = "txtSender";
            this.txtSender.ReadOnly = true;
            this.txtSender.Size = new System.Drawing.Size(201, 20);
            this.txtSender.TabIndex = 15;
            this.txtSender.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSender.ButtonCustomClick += new System.EventHandler(this.txtSender_ButtonCustomClick);
            // 
            // txtNumbers
            // 
            // 
            // 
            // 
            this.txtNumbers.Border.Class = "TextBoxBorder";
            this.txtNumbers.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtNumbers.ButtonCustom.Text = "x";
            this.txtNumbers.ButtonCustom.Visible = true;
            this.txtNumbers.Location = new System.Drawing.Point(14, 195);
            this.txtNumbers.Multiline = true;
            this.txtNumbers.Name = "txtNumbers";
            this.txtNumbers.ReadOnly = true;
            this.txtNumbers.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtNumbers.Size = new System.Drawing.Size(422, 48);
            this.txtNumbers.TabIndex = 4;
            this.txtNumbers.ButtonCustomClick += new System.EventHandler(this.txtNumbers_ButtonCustomClick);
            // 
            // button_SrchCust
            // 
            this.button_SrchCust.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchCust.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchCust.Location = new System.Drawing.Point(439, 246);
            this.button_SrchCust.Name = "button_SrchCust";
            this.button_SrchCust.Size = new System.Drawing.Size(129, 26);
            this.button_SrchCust.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchCust.Symbol = "";
            this.button_SrchCust.SymbolSize = 12F;
            this.button_SrchCust.TabIndex = 17;
            this.button_SrchCust.Text = "العمــلاء";
            this.button_SrchCust.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchCust.Click += new System.EventHandler(this.button_SrchCust_Click);
            // 
            // label12
            // 
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label12.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label12.Location = new System.Drawing.Point(438, 26);
            this.label12.Name = "label12";
            this.label12.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label12.Size = new System.Drawing.Size(129, 23);
            this.label12.TabIndex = 8;
            this.label12.Text = "إسم المرسل";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label13.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label13.Location = new System.Drawing.Point(438, 51);
            this.label13.Name = "label13";
            this.label13.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label13.Size = new System.Drawing.Size(129, 23);
            this.label13.TabIndex = 11;
            this.label13.Text = "نص الرسالة";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.checkBoxX_Guest);
            this.panel1.Controls.Add(this.checkBoxX_Banks);
            this.panel1.Controls.Add(this.checkBoxX_Emp);
            this.panel1.Controls.Add(this.checkBoxX_Supp);
            this.panel1.Controls.Add(this.checkBoxX_Customer);
            this.panel1.Location = new System.Drawing.Point(13, 306);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(554, 54);
            this.panel1.TabIndex = 21;
            // 
            // checkBoxX_Guest
            // 
            this.checkBoxX_Guest.AutoSize = true;
            this.checkBoxX_Guest.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.checkBoxX_Guest.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBoxX_Guest.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.checkBoxX_Guest.Location = new System.Drawing.Point(142, 6);
            this.checkBoxX_Guest.Name = "checkBoxX_Guest";
            this.checkBoxX_Guest.Size = new System.Drawing.Size(72, 15);
            this.checkBoxX_Guest.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBoxX_Guest.TabIndex = 9;
            this.checkBoxX_Guest.Text = "النـــــــزلاء";
            this.checkBoxX_Guest.TextColor = System.Drawing.Color.DimGray;
            // 
            // checkBoxX_Banks
            // 
            this.checkBoxX_Banks.AutoSize = true;
            this.checkBoxX_Banks.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.checkBoxX_Banks.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBoxX_Banks.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.checkBoxX_Banks.Location = new System.Drawing.Point(300, 6);
            this.checkBoxX_Banks.Name = "checkBoxX_Banks";
            this.checkBoxX_Banks.Size = new System.Drawing.Size(71, 15);
            this.checkBoxX_Banks.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBoxX_Banks.TabIndex = 7;
            this.checkBoxX_Banks.Text = "البنــــــوك";
            this.checkBoxX_Banks.TextColor = System.Drawing.Color.DimGray;
            // 
            // checkBoxX_Emp
            // 
            this.checkBoxX_Emp.AutoSize = true;
            this.checkBoxX_Emp.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.checkBoxX_Emp.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBoxX_Emp.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.checkBoxX_Emp.Location = new System.Drawing.Point(282, 29);
            this.checkBoxX_Emp.Name = "checkBoxX_Emp";
            this.checkBoxX_Emp.Size = new System.Drawing.Size(89, 15);
            this.checkBoxX_Emp.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBoxX_Emp.TabIndex = 8;
            this.checkBoxX_Emp.Text = "الموظفــــــين";
            this.checkBoxX_Emp.TextColor = System.Drawing.Color.DimGray;
            // 
            // checkBoxX_Supp
            // 
            this.checkBoxX_Supp.AutoSize = true;
            this.checkBoxX_Supp.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.checkBoxX_Supp.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBoxX_Supp.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.checkBoxX_Supp.Location = new System.Drawing.Point(454, 29);
            this.checkBoxX_Supp.Name = "checkBoxX_Supp";
            this.checkBoxX_Supp.Size = new System.Drawing.Size(81, 15);
            this.checkBoxX_Supp.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBoxX_Supp.TabIndex = 6;
            this.checkBoxX_Supp.Text = "المـــــوردين";
            this.checkBoxX_Supp.TextColor = System.Drawing.Color.DimGray;
            // 
            // checkBoxX_Customer
            // 
            this.checkBoxX_Customer.AutoSize = true;
            this.checkBoxX_Customer.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.checkBoxX_Customer.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBoxX_Customer.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.checkBoxX_Customer.Location = new System.Drawing.Point(458, 6);
            this.checkBoxX_Customer.Name = "checkBoxX_Customer";
            this.checkBoxX_Customer.Size = new System.Drawing.Size(76, 15);
            this.checkBoxX_Customer.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBoxX_Customer.TabIndex = 5;
            this.checkBoxX_Customer.Text = "العمـــــــلاء";
            this.checkBoxX_Customer.TextColor = System.Drawing.Color.DimGray;
            // 
            // txtAddNumber
            // 
            this.txtAddNumber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            // 
            // 
            // 
            this.txtAddNumber.BackgroundStyle.Class = "TextBoxBorder";
            this.txtAddNumber.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtAddNumber.ButtonCustom.Text = "+";
            this.txtAddNumber.ButtonCustom.Visible = true;
            this.txtAddNumber.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtAddNumber.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.txtAddNumber.ForeColor = System.Drawing.Color.Black;
            this.txtAddNumber.Location = new System.Drawing.Point(14, 169);
            this.txtAddNumber.Mask = "000-000-0000";
            this.txtAddNumber.Name = "txtAddNumber";
            this.txtAddNumber.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtAddNumber.Size = new System.Drawing.Size(554, 22);
            this.txtAddNumber.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.txtAddNumber.TabIndex = 3;
            this.txtAddNumber.Text = string.Empty;
            this.txtAddNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtAddNumber.ButtonCustomClick += new System.EventHandler(this.txtAddNumber_ButtonCustomClick);
            // 
            // expandablePanel_SMS
            // 
            this.expandablePanel_SMS.CanvasColor = System.Drawing.SystemColors.Control;
            this.expandablePanel_SMS.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.expandablePanel_SMS.Controls.Add(this.groupPanel5);
            this.expandablePanel_SMS.Controls.Add(this.groupPanel3);
            this.expandablePanel_SMS.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.expandablePanel_SMS.HideControlsWhenCollapsed = true;
            this.expandablePanel_SMS.Location = new System.Drawing.Point(0, 3);
            this.expandablePanel_SMS.Name = "expandablePanel_SMS";
            this.expandablePanel_SMS.Size = new System.Drawing.Size(580, 391);
            this.expandablePanel_SMS.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanel_SMS.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandablePanel_SMS.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.expandablePanel_SMS.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.expandablePanel_SMS.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.expandablePanel_SMS.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandablePanel_SMS.Style.GradientAngle = 90;
            this.expandablePanel_SMS.TabIndex = 873;
            this.expandablePanel_SMS.TitleStyle.Alignment = System.Drawing.StringAlignment.Far;
            this.expandablePanel_SMS.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandablePanel_SMS.TitleStyle.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.expandablePanel_SMS.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            this.expandablePanel_SMS.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandablePanel_SMS.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.expandablePanel_SMS.TitleStyle.GradientAngle = 90;
            this.expandablePanel_SMS.TitleText = "الإعدادات";
            this.expandablePanel_SMS.ExpandedChanged += new DevComponents.DotNetBar.ExpandChangeEventHandler(this.expandablePanel_SMS_ExpandedChanged);
            // 
            // groupPanel5
            // 
            this.groupPanel5.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel5.CanvasColor = System.Drawing.SystemColors.ButtonFace;
            this.groupPanel5.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel5.Controls.Add(this.label15);
            this.groupPanel5.Controls.Add(this.smsTxtSender);
            this.groupPanel5.Controls.Add(this.smsTxtBalance);
            this.groupPanel5.Controls.Add(this.labelErorr);
            this.groupPanel5.Controls.Add(this.label3);
            this.groupPanel5.Controls.Add(this.label2);
            this.groupPanel5.Controls.Add(this.label1);
            this.groupPanel5.Controls.Add(this.smsTxtPass);
            this.groupPanel5.Controls.Add(this.smsTxtUserName);
            this.groupPanel5.Location = new System.Drawing.Point(7, 288);
            this.groupPanel5.Name = "groupPanel5";
            this.groupPanel5.Size = new System.Drawing.Size(566, 98);
            // 
            // 
            // 
            this.groupPanel5.Style.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel5.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel5.Style.BackColorGradientAngle = 90;
            this.groupPanel5.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel5.Style.BorderBottomWidth = 1;
            this.groupPanel5.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel5.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel5.Style.BorderLeftWidth = 1;
            this.groupPanel5.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel5.Style.BorderRightWidth = 1;
            this.groupPanel5.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel5.Style.BorderTopWidth = 1;
            this.groupPanel5.Style.CornerDiameter = 4;
            this.groupPanel5.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel5.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Far;
            this.groupPanel5.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            // 
            // 
            // 
            this.groupPanel5.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel5.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel5.TabIndex = 978;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label15.ForeColor = System.Drawing.Color.Navy;
            this.label15.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label15.Location = new System.Drawing.Point(126, 25);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(51, 13);
            this.label15.TabIndex = 1008;
            this.label15.Text = "المرسل :";
            // 
            // smsTxtSender
            // 
            this.smsTxtSender.BackColor = System.Drawing.Color.Gainsboro;
            // 
            // 
            // 
            this.smsTxtSender.Border.Class = "TextBoxBorder";
            this.smsTxtSender.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.smsTxtSender.ButtonCustom.Text = "x";
            this.smsTxtSender.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.smsTxtSender.ForeColor = System.Drawing.SystemColors.WindowText;
            this.smsTxtSender.Location = new System.Drawing.Point(21, 21);
            this.smsTxtSender.MaxLength = 15;
            this.smsTxtSender.Name = "smsTxtSender";
            this.smsTxtSender.Size = new System.Drawing.Size(101, 20);
            this.smsTxtSender.TabIndex = 18;
            this.smsTxtSender.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // smsTxtBalance
            // 
            this.smsTxtBalance.BackColor = System.Drawing.Color.White;
            this.smsTxtBalance.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.smsTxtBalance.Location = new System.Drawing.Point(21, 57);
            this.smsTxtBalance.Name = "smsTxtBalance";
            this.smsTxtBalance.ReadOnly = true;
            this.smsTxtBalance.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.smsTxtBalance.Size = new System.Drawing.Size(101, 20);
            this.smsTxtBalance.TabIndex = 19;
            this.smsTxtBalance.Tag = string.Empty;
            this.smsTxtBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelErorr
            // 
            this.labelErorr.AutoSize = true;
            this.labelErorr.BackColor = System.Drawing.Color.Transparent;
            this.labelErorr.Font = new System.Drawing.Font("Tahoma", 8F, ((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline)));
            this.labelErorr.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelErorr.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelErorr.Location = new System.Drawing.Point(288, 63);
            this.labelErorr.Name = "labelErorr";
            this.labelErorr.Size = new System.Drawing.Size(218, 13);
            this.labelErorr.TabIndex = 1003;
            this.labelErorr.Text = "تأكد من صحة رقم الجوال أو الرقم السري";
            this.labelErorr.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Navy;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(126, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 1002;
            this.label3.Text = "رصيد الرسائل :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(291, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 998;
            this.label2.Text = "كلمة المرور :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(476, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 996;
            this.label1.Text = "المستخـــدم :";
            // 
            // smsTxtPass
            // 
            this.smsTxtPass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.smsTxtPass.Location = new System.Drawing.Point(191, 21);
            this.smsTxtPass.MaxLength = 12;
            this.smsTxtPass.Name = "smsTxtPass";
            this.smsTxtPass.PasswordChar = '*';
            this.smsTxtPass.Size = new System.Drawing.Size(98, 20);
            this.smsTxtPass.TabIndex = 17;
            this.smsTxtPass.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.smsTxtPass.Leave += new System.EventHandler(this.smsTxtPass_Leave);
            // 
            // smsTxtUserName
            // 
            this.smsTxtUserName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.smsTxtUserName.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.smsTxtUserName.ForeColor = System.Drawing.Color.White;
            this.smsTxtUserName.Location = new System.Drawing.Point(372, 21);
            this.smsTxtUserName.MaxLength = 20;
            this.smsTxtUserName.Name = "smsTxtUserName";
            this.smsTxtUserName.Size = new System.Drawing.Size(98, 20);
            this.smsTxtUserName.TabIndex = 16;
            this.smsTxtUserName.Tag = string.Empty;
            this.smsTxtUserName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.smsTxtUserName.Leave += new System.EventHandler(this.smsTxtUserName_Leave);
            // 
            // groupPanel3
            // 
            this.groupPanel3.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel3.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel3.Controls.Add(this.label10);
            this.groupPanel3.Controls.Add(this.label8);
            this.groupPanel3.Controls.Add(this.label6);
            this.groupPanel3.Controls.Add(this.label5);
            this.groupPanel3.Controls.Add(this.smsTxtNo4);
            this.groupPanel3.Controls.Add(this.smsTxt4);
            this.groupPanel3.Controls.Add(this.smsTxtNo3);
            this.groupPanel3.Controls.Add(this.smsTxt3);
            this.groupPanel3.Controls.Add(this.smsTxtNo2);
            this.groupPanel3.Controls.Add(this.smsTxt2);
            this.groupPanel3.Controls.Add(this.smsTxtNo1);
            this.groupPanel3.Controls.Add(this.smsTxt1);
            this.groupPanel3.Controls.Add(this.label11);
            this.groupPanel3.Controls.Add(this.label7);
            this.groupPanel3.Controls.Add(this.label9);
            this.groupPanel3.Controls.Add(this.label4);
            this.groupPanel3.Location = new System.Drawing.Point(7, 42);
            this.groupPanel3.Name = "groupPanel3";
            this.groupPanel3.Size = new System.Drawing.Size(566, 242);
            // 
            // 
            // 
            this.groupPanel3.Style.BackColor = System.Drawing.Color.AliceBlue;
            this.groupPanel3.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel3.Style.BackColorGradientAngle = 90;
            this.groupPanel3.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderBottomWidth = 1;
            this.groupPanel3.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel3.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderLeftWidth = 1;
            this.groupPanel3.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderRightWidth = 1;
            this.groupPanel3.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderTopWidth = 1;
            this.groupPanel3.Style.CornerDiameter = 4;
            this.groupPanel3.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel3.Style.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupPanel3.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel3.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel3.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel3.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel3.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel3.TabIndex = 979;
            this.groupPanel3.TabStop = true;
            this.groupPanel3.Text = "القـــوالــب النصيــــة الجاهـــزة";
            this.groupPanel3.Visible = false;
            // 
            // label10
            // 
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label10.Location = new System.Drawing.Point(119, 192);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(25, 22);
            this.label10.TabIndex = 1011;
            this.label10.Text = "=";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(398, 193);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(25, 22);
            this.label8.TabIndex = 1009;
            this.label8.Text = "=";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(119, 88);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(25, 22);
            this.label6.TabIndex = 1007;
            this.label6.Text = "=";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(398, 89);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(25, 22);
            this.label5.TabIndex = 1005;
            this.label5.Text = "=";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // smsTxtNo4
            // 
            this.smsTxtNo4.AllowEmptyState = false;
            // 
            // 
            // 
            this.smsTxtNo4.BackgroundStyle.BackColor = System.Drawing.Color.AliceBlue;
            this.smsTxtNo4.BackgroundStyle.Class = "DateTimeInputBackground";
            this.smsTxtNo4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.smsTxtNo4.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.smsTxtNo4.DisplayFormat = "0";
            this.smsTxtNo4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.smsTxtNo4.ForeColor = System.Drawing.Color.Gray;
            this.smsTxtNo4.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.smsTxtNo4.IsInputReadOnly = true;
            this.smsTxtNo4.Location = new System.Drawing.Point(3, 192);
            this.smsTxtNo4.MinValue = 0;
            this.smsTxtNo4.Name = "smsTxtNo4";
            this.smsTxtNo4.Size = new System.Drawing.Size(115, 22);
            this.smsTxtNo4.TabIndex = 1003;
            // 
            // smsTxt4
            // 
            // 
            // 
            // 
            this.smsTxt4.Border.Class = "TextBoxBorder";
            this.smsTxt4.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.smsTxt4.ButtonCustom.Visible = true;
            this.smsTxt4.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.smsTxt4.Location = new System.Drawing.Point(3, 113);
            this.smsTxt4.Multiline = true;
            this.smsTxt4.Name = "smsTxt4";
            this.smsTxt4.Size = new System.Drawing.Size(275, 76);
            this.smsTxt4.TabIndex = 23;
            this.smsTxt4.WatermarkText = "القالب الرابع";
            this.smsTxt4.TextChanged += new System.EventHandler(this.smsTxt4_TextChanged);
            // 
            // smsTxtNo3
            // 
            this.smsTxtNo3.AllowEmptyState = false;
            // 
            // 
            // 
            this.smsTxtNo3.BackgroundStyle.BackColor = System.Drawing.Color.AliceBlue;
            this.smsTxtNo3.BackgroundStyle.Class = "DateTimeInputBackground";
            this.smsTxtNo3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.smsTxtNo3.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.smsTxtNo3.DisplayFormat = "0";
            this.smsTxtNo3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.smsTxtNo3.ForeColor = System.Drawing.Color.Gray;
            this.smsTxtNo3.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.smsTxtNo3.IsInputReadOnly = true;
            this.smsTxtNo3.Location = new System.Drawing.Point(282, 193);
            this.smsTxtNo3.MinValue = 0;
            this.smsTxtNo3.Name = "smsTxtNo3";
            this.smsTxtNo3.Size = new System.Drawing.Size(115, 22);
            this.smsTxtNo3.TabIndex = 1001;
            // 
            // smsTxt3
            // 
            this.smsTxt3.BackColor = System.Drawing.SystemColors.InactiveCaption;
            // 
            // 
            // 
            this.smsTxt3.Border.Class = "TextBoxBorder";
            this.smsTxt3.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.smsTxt3.ButtonCustom.Visible = true;
            this.smsTxt3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.smsTxt3.ForeColor = System.Drawing.Color.White;
            this.smsTxt3.Location = new System.Drawing.Point(282, 114);
            this.smsTxt3.Multiline = true;
            this.smsTxt3.Name = "smsTxt3";
            this.smsTxt3.Size = new System.Drawing.Size(275, 76);
            this.smsTxt3.TabIndex = 22;
            this.smsTxt3.WatermarkColor = System.Drawing.Color.White;
            this.smsTxt3.WatermarkText = "القالب الثالث";
            this.smsTxt3.TextChanged += new System.EventHandler(this.smsTxt3_TextChanged);
            // 
            // smsTxtNo2
            // 
            this.smsTxtNo2.AllowEmptyState = false;
            // 
            // 
            // 
            this.smsTxtNo2.BackgroundStyle.BackColor = System.Drawing.Color.AliceBlue;
            this.smsTxtNo2.BackgroundStyle.Class = "DateTimeInputBackground";
            this.smsTxtNo2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.smsTxtNo2.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.smsTxtNo2.DisplayFormat = "0";
            this.smsTxtNo2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.smsTxtNo2.ForeColor = System.Drawing.Color.Gray;
            this.smsTxtNo2.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.smsTxtNo2.IsInputReadOnly = true;
            this.smsTxtNo2.Location = new System.Drawing.Point(3, 88);
            this.smsTxtNo2.MinValue = 0;
            this.smsTxtNo2.Name = "smsTxtNo2";
            this.smsTxtNo2.Size = new System.Drawing.Size(115, 22);
            this.smsTxtNo2.TabIndex = 999;
            // 
            // smsTxt2
            // 
            this.smsTxt2.BackColor = System.Drawing.SystemColors.InactiveCaption;
            // 
            // 
            // 
            this.smsTxt2.Border.Class = "TextBoxBorder";
            this.smsTxt2.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.smsTxt2.ButtonCustom.Visible = true;
            this.smsTxt2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.smsTxt2.ForeColor = System.Drawing.Color.White;
            this.smsTxt2.Location = new System.Drawing.Point(3, 9);
            this.smsTxt2.Multiline = true;
            this.smsTxt2.Name = "smsTxt2";
            this.smsTxt2.Size = new System.Drawing.Size(275, 76);
            this.smsTxt2.TabIndex = 21;
            this.smsTxt2.WatermarkColor = System.Drawing.Color.White;
            this.smsTxt2.WatermarkText = "القالب الثاني";
            this.smsTxt2.TextChanged += new System.EventHandler(this.smsTxt2_TextChanged);
            // 
            // smsTxtNo1
            // 
            this.smsTxtNo1.AllowEmptyState = false;
            // 
            // 
            // 
            this.smsTxtNo1.BackgroundStyle.BackColor = System.Drawing.Color.AliceBlue;
            this.smsTxtNo1.BackgroundStyle.Class = "DateTimeInputBackground";
            this.smsTxtNo1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.smsTxtNo1.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.smsTxtNo1.DisplayFormat = "0";
            this.smsTxtNo1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.smsTxtNo1.ForeColor = System.Drawing.Color.Gray;
            this.smsTxtNo1.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.smsTxtNo1.IsInputReadOnly = true;
            this.smsTxtNo1.Location = new System.Drawing.Point(282, 89);
            this.smsTxtNo1.MinValue = 0;
            this.smsTxtNo1.Name = "smsTxtNo1";
            this.smsTxtNo1.Size = new System.Drawing.Size(115, 22);
            this.smsTxtNo1.TabIndex = 997;
            // 
            // smsTxt1
            // 
            // 
            // 
            // 
            this.smsTxt1.Border.Class = "TextBoxBorder";
            this.smsTxt1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.smsTxt1.ButtonCustom.Visible = true;
            this.smsTxt1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.smsTxt1.Location = new System.Drawing.Point(282, 10);
            this.smsTxt1.Multiline = true;
            this.smsTxt1.Name = "smsTxt1";
            this.smsTxt1.Size = new System.Drawing.Size(275, 76);
            this.smsTxt1.TabIndex = 20;
            this.smsTxt1.WatermarkText = "القالب الأول";
            this.smsTxt1.TextChanged += new System.EventHandler(this.smsTxt1_TextChanged);
            // 
            // label11
            // 
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label11.ForeColor = System.Drawing.Color.Navy;
            this.label11.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label11.Location = new System.Drawing.Point(146, 192);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(115, 22);
            this.label11.TabIndex = 1010;
            this.label11.Text = "عدد الحــروف";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label7.ForeColor = System.Drawing.Color.Navy;
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(146, 88);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(115, 22);
            this.label7.TabIndex = 1006;
            this.label7.Text = "عدد الحــروف";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label9.ForeColor = System.Drawing.Color.Navy;
            this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label9.Location = new System.Drawing.Point(425, 193);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(115, 22);
            this.label9.TabIndex = 1008;
            this.label9.Text = "عدد الحــروف";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.ForeColor = System.Drawing.Color.Navy;
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(425, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 22);
            this.label4.TabIndex = 1004;
            this.label4.Text = "عدد الحــروف";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // superTabItem_Sms
            // 
            this.superTabItem_Sms.AttachedControl = this.superTabControlPanel5;
            this.superTabItem_Sms.GlobalItem = false;
            this.superTabItem_Sms.Name = "superTabItem_Sms";
            this.superTabItem_Sms.Text = "إرسال رسالة";
            // 
            // labelItem1
            // 
            this.labelItem1.Name = "labelItem1";
            // 
            // labelItem2
            // 
            this.labelItem2.Name = "labelItem2";
            this.labelItem2.Width = 8;
            // 
            // ButWithoutSave
            // 
            this.ButWithoutSave.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.ButWithoutSave.Checked = true;
            this.ButWithoutSave.FontBold = true;
            this.ButWithoutSave.Name = "ButWithoutSave";
            this.ButWithoutSave.Symbol = "";
            this.ButWithoutSave.SymbolSize = 8F;
            this.ButWithoutSave.Text = "خـروج";
            this.ButWithoutSave.Click += new System.EventHandler(this.ButWithoutSave_Click);
            // 
            // ButWithSave
            // 
            this.ButWithSave.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.ButWithSave.Checked = true;
            this.ButWithSave.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.ButWithSave.FontBold = true;
            this.ButWithSave.Name = "ButWithSave";
            this.ButWithSave.Symbol = "";
            this.ButWithSave.SymbolSize = 8F;
            this.ButWithSave.Text = "إرسال";
            this.ButWithSave.Click += new System.EventHandler(this.ButWithSave_Click);
            // 
            // buttonItem2
            // 
            this.buttonItem2.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonItem2.Checked = true;
            this.buttonItem2.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.buttonItem2.FontBold = true;
            this.buttonItem2.Name = "buttonItem2";
            this.buttonItem2.Symbol = "";
            this.buttonItem2.SymbolSize = 8F;
            this.buttonItem2.Text = "نماذج الرسائل";
            this.buttonItem2.Click += new System.EventHandler(this.buttonItem2_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "*.bmp|*.dip|*.gif|*.jpg|*.wmf|*.emf";
            this.openFileDialog1.SupportMultiDottedExtensions = true;
            // 
            // styleManager1
            // 
            this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2010Blue;
            this.styleManager1.MetroColorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.White, System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154))))));
            // 
            // FrmSMS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 440);
            this.PanelSpecialContainer.Controls.Add(this.ribbonBar1);
            this.ribbonBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = (InvAcc.Properties.Resources.favicon);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "FrmSMS";
            this.netResize1.AutoSaveLayout = true;
            this.netResize1.ParentControl = this;
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "الرســائل النصيـــة";
            this.Load += new System.EventHandler(this.FrmSMS_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Frm_KeyPress);
            this.ribbonBar1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl1)).EndInit();
            this.superTabControl1.ResumeLayout(false);
            this.superTabControlPanel5.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.smsTxtNo)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.expandablePanel_SMS.ResumeLayout(false);
            this.groupPanel5.ResumeLayout(false);
            this.groupPanel5.PerformLayout();
            this.groupPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.smsTxtNo4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.smsTxtNo3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.smsTxtNo2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.smsTxtNo1)).EndInit();
            this.Icon = (InvAcc.Properties.Resources.favicon);
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).EndInit();
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.ResumeLayout(false);

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
