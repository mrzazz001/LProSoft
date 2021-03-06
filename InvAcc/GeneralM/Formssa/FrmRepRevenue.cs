//
using CrystalDecisions.CrystalReports.Engine;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using Framework.Date;
using InvAcc.GeneralM;
using InvAcc.Stock_Data;
using Library.RepShow;
using Microsoft.VisualBasic;
using SSSDateTime.Date;
using SSSLanguage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial class FrmRepRevenue : Form
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
        private T_Branch vBr = new T_Branch();
        private int LangArEn = 0;
        public Dictionary<string, ColumnDictinary> columns_Names_visible = new Dictionary<string, ColumnDictinary>();
        private HijriGreg.HijriGregDates n = new HijriGreg.HijriGregDates();
        private RepShow _RepShow = new RepShow();
        private ReportDocument MainCryRep = new ReportDocument();
        public List<Control> controls;
        private Stock_DataDataContext dbInstance;
        private Rate_DataDataContext dbInstanceRate;
        public int tp = 0;
        public int SerTypeCount = 10;
        private string[,] vData = new string[101, 8];
        private double dis;
        private double aa;
        private double[] Ttot = new double[9];
        private double Tot3;
        private double Tot4;
        private double Tot10;
        private double Tot8;
        private double Tot5;
        private double Tot1;
        private double Tot2;
        private double Tot6;
        private double Tot7;
        private double tot50;
        private double tot60;
        private double tt1;
        private double Tot;
        private double TotResturant;
        private Dictionary<string, ColumnDictinary> Dir_ButSearch = new Dictionary<string, ColumnDictinary>();
        private IContainer components = null;
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (!keyData.ToString().Contains("Control") && !keyData.ToString().ToLower().Contains("delete") && keyData.ToString().Contains("Alt"))
            {
                try
                {
                    VarGeneral.Print_set_Gen_Stat = true;
                    FrmReportsViewer.IsSettingOnly = true;
                    VarGeneral.IsGeneralUsed = true;

                    {

                        FrmReportsViewer frm = new FrmReportsViewer();
                        frm.Repvalue = "RepRevenue_" + tp;
                        frm.Repvalue = "RepRoomDesc";
                        frm.Repvalue = "RepRoomMovement";
                        frm.Repvalue = "RepRoomReapir";
                        frm.Repvalue = "RepRoomGroup";
                        frm.Repvalue = "RepReserv";
                        frm.Repvalue = "RepPers_" + tp;
                        frm.Repvalue = "RepGuestOrders";
                        frm.Repvalue = "RepGuestCalls";
                        frm.Repvalue = "RepGuestAcc";
                        frm.Repvalue = "RepGuestData";


                        frm.Repvalue = "RepRevenue_" + tp;
                        frm.Repvalue = "RepRoomDesc";
                        frm.Repvalue = "RepRoomMovement";
                        frm.Repvalue = "RepRoomReapir";
                        frm.Repvalue = "RepRoomGroup";
                        frm.Repvalue = "RepReserv";
                        frm.Repvalue = "RepPers_" + tp;
                        frm.Repvalue = "RepGuestOrders";
                        frm.Repvalue = "RepGuestCalls";
                        frm.Repvalue = "RepGuestAcc";
                        frm.Repvalue = "RepGuestData";
                        //ADDADD















                        frm.Tag = LangArEn;
                        frm.ShowDialog();
                        VarGeneral.IsGeneralUsed = false;
                    }
                    FrmReportsViewer.IsSettingOnly = false;
                }
                catch
                {
                    VarGeneral.Print_set_Gen_Stat = false;
                }


            }
            return base.ProcessCmdKey(ref msg, keyData);
        }


        private RibbonBar ribbonBar1;
        private Panel panel1;
        private MaskedTextBox dateTimeInput_StartAdvancTo;
        private MaskedTextBox dateTimeInput_StartAdvancFrom;
        private Label label3;
        private Label label4;
        private GroupBox groupBox1;
        private Label label1;
        private Label label5;
        private MaskedTextBox textBox_Time;
        internal GroupBox groupBox_AmPm;
        private CheckBoxX RadioBox_AllowPM;
        private CheckBoxX checkBoxX1;
        private CheckBoxX RadioBox_AllowAM;
        private MaskedTextBox textBox_Time2;
        internal GroupBox groupBox2;
        private CheckBoxX RadioBox_AllowPM2;
        private CheckBoxX checkBoxX3;
        private CheckBoxX RadioBox_AllowAM2;
        public ButtonX ButExit;
        public ButtonX ButOk;
        public ComboBoxEx comboBox_AdvancStatus;
        public Label label2;
        public GroupBox groupBox_Date;
        public TextBox txtUserName;
        public TextBox txtUserNo;
        public Label label9;
        public ButtonX button_SrchUsrNo;
        internal GroupBox groupBox_9_10;
        private CheckBoxX checkBox_Leave;
        private CheckBoxX checkBox_Stay;
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
        public FrmRepRevenue(int _tp)
        {
            InitializeComponent();
            tp = _tp;
        }
        private void RibunButtons()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                ButOk.Text = ((VarGeneral.GeneralPrinter.nTyp_Setting.Substring(2, 1) == "0") ? "???????????????? F5" : "?????????????? F5");
                ButExit.Text = "?????????????? Esc";
            }
            else
            {
                ButOk.Text = ((VarGeneral.GeneralPrinter.nTyp_Setting.Substring(2, 1) == "0") ? "Print F5" : "Show F5");
                ButExit.Text = "Close Esc";
            }
        }
        private void FrmRepRevenue_Load(object sender, EventArgs e)
        {
            try
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmRepRevenue));
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
                RibunButtons();
                FillCombo();
                SerTypeCount += db.FillServTyp_2("").ToList().Count;
                MaskedTextBox maskedTextBox = dateTimeInput_StartAdvancFrom;
                int? calendr = VarGeneral.Settings_Sys.Calendr;
                maskedTextBox.Text = ((calendr.Value == 0 && calendr.HasValue) ? n.FormatGreg(VarGeneral.Gdate, "yyyy/MM/dd") : n.FormatHijri(VarGeneral.Hdate, "yyyy/MM/dd"));
                MaskedTextBox maskedTextBox2 = dateTimeInput_StartAdvancTo;
                calendr = VarGeneral.Settings_Sys.Calendr;
                maskedTextBox2.Text = ((calendr.Value == 0 && calendr.HasValue) ? n.FormatGreg(VarGeneral.Gdate, "yyyy/MM/dd") : n.FormatHijri(VarGeneral.Hdate, "yyyy/MM/dd"));
                textBox_Time2.Text = DateTime.Now.ToString("hh:mm:ss");
                if (DateTime.Now.ToString("hh:mm:ss tt").ToString().ToUpper()
                    .Contains("AM"))
                {
                    RadioBox_AllowAM2.Checked = true;
                }
                else
                {
                    RadioBox_AllowPM2.Checked = true;
                }
                if (tp == 1)
                {
                    label9.Text = ((LangArEn == 0) ? "?????? ???????????? :" : "Room No :");
                    dateTimeInput_StartAdvancFrom.Text = "";
                    dateTimeInput_StartAdvancTo.Text = "";
                    txtUserName.Visible = false;
                }
                else if (tp == 2)
                {
                    label9.Text = ((LangArEn == 0) ? "?????? ???????????? :" : "Room No :");
                    label2.Text = ((LangArEn == 0) ? "???????????????? :" : "Status :");
                    dateTimeInput_StartAdvancFrom.Text = "";
                    dateTimeInput_StartAdvancTo.Text = "";
                    groupBox_Date.Visible = false;
                    ButOk.Location = new Point(ButOk.Location.X, ButOk.Location.Y - 100);
                    ButExit.Location = new Point(ButExit.Location.X, ButExit.Location.Y - 100);
                    base.Height = 185;
                }
                else if (tp == 3)
                {
                    label9.Text = ((LangArEn == 0) ? "?????? ???????????? :" : "Room No :");
                    label2.Visible = false;
                    comboBox_AdvancStatus.Visible = false;
                    dateTimeInput_StartAdvancFrom.Text = "";
                    dateTimeInput_StartAdvancTo.Text = "";
                    label2.Visible = false;
                    comboBox_AdvancStatus.Visible = false;
                    label9.Location = new Point(label9.Location.X, label9.Location.Y - 15);
                    txtUserNo.Location = new Point(txtUserNo.Location.X, txtUserNo.Location.Y - 15);
                    button_SrchUsrNo.Location = new Point(button_SrchUsrNo.Location.X, button_SrchUsrNo.Location.Y - 15);
                    txtUserName.Location = new Point(txtUserName.Location.X, txtUserName.Location.Y - 15);
                    groupBox_Date.Location = new Point(groupBox_Date.Location.X, groupBox_Date.Location.Y - 7);
                }
                else if (tp == 4 || tp == 5 || tp == 7)
                {
                    label9.Visible = false;
                    txtUserNo.Visible = false;
                    button_SrchUsrNo.Visible = false;
                    txtUserName.Visible = false;
                    label2.Visible = false;
                    comboBox_AdvancStatus.Visible = false;
                    dateTimeInput_StartAdvancFrom.Text = "";
                    dateTimeInput_StartAdvancTo.Text = "";
                    groupBox_Date.Location = new Point(groupBox_Date.Location.X, groupBox_Date.Location.Y - 55);
                    if (tp == 7)
                    {
                        groupBox_Date.Text = ((LangArEn == 0) ? "?????? ?????????? ??????????" : "By Date");
                    }
                }
                else if (tp == 12)
                {
                    label9.Visible = false;
                    txtUserNo.Visible = false;
                    button_SrchUsrNo.Visible = false;
                    txtUserName.Visible = false;
                    dateTimeInput_StartAdvancFrom.Text = "";
                    dateTimeInput_StartAdvancTo.Text = "";
                    groupBox_Date.Location = new Point(groupBox_Date.Location.X, groupBox_Date.Location.Y - 15);
                    groupBox_Date.Text = ((LangArEn == 0) ? "?????? ?????????? ??????????" : "By Date");
                    MaskedTextBox maskedTextBox3 = dateTimeInput_StartAdvancTo;
                    calendr = VarGeneral.Settings_Sys.Calendr;
                    maskedTextBox3.Text = ((calendr.Value == 0 && calendr.HasValue) ? n.FormatGreg(VarGeneral.Gdate, "yyyy/MM/dd") : n.FormatHijri(VarGeneral.Hdate, "yyyy/MM/dd"));
                }
                else if (tp == 6 || tp == 13)
                {
                    if (tp == 13)
                    {
                        label9.Text = ((LangArEn == 0) ? "?????? ???????????? :" : "Guest No :");
                        label2.Text = ((LangArEn == 0) ? "?????? ???????????? :" : "Guest Type :");
                    }
                    else
                    {
                        label9.Text = ((LangArEn == 0) ? "?????? ????????????" : "Acc No :");
                        label2.Visible = false;
                        comboBox_AdvancStatus.Visible = false;
                    }
                    dateTimeInput_StartAdvancFrom.Text = "";
                    dateTimeInput_StartAdvancTo.Text = "";
                    groupBox_Date.Visible = false;
                    ButOk.Location = new Point(ButOk.Location.X, ButOk.Location.Y - 100);
                    ButExit.Location = new Point(ButExit.Location.X, ButExit.Location.Y - 100);
                    base.Height = 185;
                }
                else if (tp == 9 || tp == 10)
                {
                    groupBox_9_10.Visible = true;
                    label9.Text = ((LangArEn == 0) ? "?????? ???????????? :" : "Guest No :");
                    if (tp == 9)
                    {
                        label2.Text = ((LangArEn == 0) ? "?????????????? :" : "Services :");
                    }
                    else
                    {
                        label2.Visible = false;
                        comboBox_AdvancStatus.Visible = false;
                        label9.Location = new Point(label9.Location.X, label9.Location.Y - 25);
                        txtUserNo.Location = new Point(txtUserNo.Location.X, txtUserNo.Location.Y - 25);
                        button_SrchUsrNo.Location = new Point(button_SrchUsrNo.Location.X, button_SrchUsrNo.Location.Y - 25);
                        txtUserName.Location = new Point(txtUserName.Location.X, txtUserName.Location.Y - 25);
                        groupBox_Date.Location = new Point(groupBox_Date.Location.X, groupBox_Date.Location.Y - 25);
                        ButOk.Location = new Point(ButOk.Location.X, ButOk.Location.Y - 25);
                        ButExit.Location = new Point(ButExit.Location.X, ButExit.Location.Y - 25);
                        base.Height -= 25;
                    }
                    dateTimeInput_StartAdvancFrom.Text = "";
                    dateTimeInput_StartAdvancTo.Text = "";
                }
                else if (tp == 14)
                {
                    label9.Visible = false;
                    txtUserNo.Visible = false;
                    button_SrchUsrNo.Visible = false;
                    txtUserName.Visible = false;
                    dateTimeInput_StartAdvancFrom.Text = "";
                    dateTimeInput_StartAdvancTo.Text = "";
                    groupBox_Date.Visible = false;
                    label2.Text = ((LangArEn == 0) ? "?????? ?????????????? :" : "Guests Type :");
                    label2.Location = new Point(label2.Location.X, label2.Location.Y + 25);
                    comboBox_AdvancStatus.Location = new Point(comboBox_AdvancStatus.Location.X, comboBox_AdvancStatus.Location.Y + 25);
                    ButOk.Location = new Point(ButOk.Location.X, ButOk.Location.Y - 100);
                    ButExit.Location = new Point(ButExit.Location.X, ButExit.Location.Y - 100);
                    base.Height = 185;
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Load:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        public void FillCombo()
        {
            if (tp == 2)
            {
                comboBox_AdvancStatus.Items.Clear();
                comboBox_AdvancStatus.Items.Add((LangArEn == 0) ? "????????" : "All");
                comboBox_AdvancStatus.Items.Add((LangArEn == 0) ? "??????????" : "maintenance");
                comboBox_AdvancStatus.Items.Add((LangArEn == 0) ? "??????????" : "Empty");
                comboBox_AdvancStatus.Items.Add((LangArEn == 0) ? "??????????" : "cleanliness");
                comboBox_AdvancStatus.Items.Add((LangArEn == 0) ? "????????????" : "Busy");
                comboBox_AdvancStatus.SelectedIndex = 0;
            }
            else if (tp == 9)
            {
                comboBox_AdvancStatus.Items.Clear();
                List<T_sertyp> listSertyp = new List<T_sertyp>(db.T_sertyps.Select((T_sertyp item) => item).ToList());
                listSertyp.Insert(0, new T_sertyp());
                comboBox_AdvancStatus.DataSource = listSertyp;
                comboBox_AdvancStatus.DisplayMember = ((LangArEn == 0) ? "Arb_Des" : "Eng_Des");
                comboBox_AdvancStatus.ValueMember = "Serv_No";
                comboBox_AdvancStatus.SelectedIndex = 0;
            }
            else if (tp == 13)
            {
                comboBox_AdvancStatus.Items.Clear();
                comboBox_AdvancStatus.Items.Add((LangArEn == 0) ? "?????????????? ????????????????" : "Existing Guests");
                comboBox_AdvancStatus.Items.Add((LangArEn == 0) ? "?????????????? ??????????????????" : "Leaving Guests");
                comboBox_AdvancStatus.SelectedIndex = 0;
            }
            else if (tp == 8 || tp == 11 || tp == 12 || tp == 14)
            {
                comboBox_AdvancStatus.Items.Clear();
                comboBox_AdvancStatus.Items.Add((LangArEn == 0) ? "????????????????" : "ALL");
                comboBox_AdvancStatus.Items.Add((LangArEn == 0) ? "?????????????? ????????????????" : "Existing Guests");
                comboBox_AdvancStatus.Items.Add((LangArEn == 0) ? "?????????????? ??????????????????" : "Leaving Guests");
                comboBox_AdvancStatus.SelectedIndex = 0;
            }
            else
            {
                comboBox_AdvancStatus.Items.Clear();
                comboBox_AdvancStatus.Items.Add((LangArEn == 0) ? "????????" : "All");
                comboBox_AdvancStatus.Items.Add((LangArEn == 0) ? "?????? ?????? ????????" : "Under arrest");
                comboBox_AdvancStatus.Items.Add((LangArEn == 0) ? "?????? ?????? ????????" : "Under Exchange");
                comboBox_AdvancStatus.SelectedIndex = 0;
            }
        }
        private void FrmRepRevenue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                SendKeys.Send("{Tab}");
            }
        }
        private void FrmRepRevenue_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5 && ButOk.Enabled && ButOk.Visible)
            {
                ButOk_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
        private string BuildRuleList()
        {
            HijriGregDates dateFormatter = new HijriGregDates();
            string Rule = "Where 1 = 1 ";
            if (tp == 4)
            {
                Rule += " and (typ=7 or typ=8) ";
            }
            else if (tp == 5)
            {
                Rule += " and ( typ=6 ) ";
            }
            else if (tp == 6)
            {
                Rule += " and T_per.gropno != '' ";
            }
            else if (tp == 8)
            {
                Rule += " and T_per.ch = 2 ";
            }
            else if (tp == 11)
            {
                Rule += " and T_per.ch = 3 ";
            }
            if (!string.IsNullOrEmpty(txtUserNo.Text) && tp == 0)
            {
                Rule = Rule + " and T_Snd.Usr = '" + txtUserNo.Text.Trim() + "'";
            }
            else if (!string.IsNullOrEmpty(txtUserNo.Text) && tp == 1)
            {
                Rule = Rule + " and T_per.romno = " + txtUserNo.Text.Trim();
            }
            else if (!string.IsNullOrEmpty(txtUserNo.Text) && tp == 2)
            {
                Rule = Rule + " and T_Rom.romno = " + txtUserNo.Text.Trim();
            }
            else if (!string.IsNullOrEmpty(txtUserNo.Text) && tp == 3)
            {
                Rule = Rule + " and T_romtrn.romno1 = " + txtUserNo.Text.Trim();
            }
            else if (!string.IsNullOrEmpty(txtUserNo.Text) && tp == 6)
            {
                Rule = Rule + " and T_per.Cust_no = " + txtUserNo.Text.Trim();
            }
            else if (!string.IsNullOrEmpty(txtUserNo.Text) && (tp == 9 || tp == 10 || tp == 13))
            {
                Rule = Rule + " and T_per.perno = " + txtUserNo.Text.Trim();
            }
            if (tp == 5 || tp == 4 || tp == 3)
            {
                if (VarGeneral.CheckDate(dateTimeInput_StartAdvancFrom.Text) && dateTimeInput_StartAdvancFrom.Text.Length == 10)
                {
                    Rule = ((int.Parse(dateTimeInput_StartAdvancFrom.Text.Substring(0, 4)) >= 1800) ? (Rule + " and  T_romtrn.dt  >= '" + dateFormatter.FormatGreg(dateTimeInput_StartAdvancFrom.Text, "yyyy/MM/dd") + "'") : (Rule + " and  T_romtrn.dt  >= '" + dateFormatter.FormatHijri(dateTimeInput_StartAdvancFrom.Text, "yyyy/MM/dd") + "'"));
                }
                if (VarGeneral.CheckDate(dateTimeInput_StartAdvancTo.Text) && dateTimeInput_StartAdvancTo.Text.Length == 10)
                {
                    Rule = ((int.Parse(dateTimeInput_StartAdvancTo.Text.Substring(0, 4)) >= 1800) ? (Rule + " and  T_romtrn.dt  <= '" + dateFormatter.FormatGreg(dateTimeInput_StartAdvancTo.Text, "yyyy/MM/dd") + "'") : (Rule + " and  T_romtrn.dt  <= '" + dateFormatter.FormatHijri(dateTimeInput_StartAdvancTo.Text, "yyyy/MM/dd") + "'"));
                }
            }
            else if (tp == 0 || tp == 1)
            {
                if (VarGeneral.CheckDate(dateTimeInput_StartAdvancFrom.Text) && dateTimeInput_StartAdvancFrom.Text.Length == 10)
                {
                    Rule = ((int.Parse(dateTimeInput_StartAdvancFrom.Text.Substring(0, 4)) >= 1800) ? (Rule + " and  T_Snd.dt  >= '" + dateFormatter.FormatGreg(dateTimeInput_StartAdvancFrom.Text, "yyyy/MM/dd") + "'") : (Rule + " and  T_Snd.dt  >= '" + dateFormatter.FormatHijri(dateTimeInput_StartAdvancFrom.Text, "yyyy/MM/dd") + "'"));
                }
                if (VarGeneral.CheckDate(dateTimeInput_StartAdvancTo.Text) && dateTimeInput_StartAdvancTo.Text.Length == 10)
                {
                    Rule = ((int.Parse(dateTimeInput_StartAdvancTo.Text.Substring(0, 4)) >= 1800) ? (Rule + " and  T_Snd.dt  <= '" + dateFormatter.FormatGreg(dateTimeInput_StartAdvancTo.Text, "yyyy/MM/dd") + "'") : (Rule + " and  T_Snd.dt  <= '" + dateFormatter.FormatHijri(dateTimeInput_StartAdvancTo.Text, "yyyy/MM/dd") + "'"));
                }
            }
            else if (tp == 7)
            {
                if (VarGeneral.CheckDate(dateTimeInput_StartAdvancFrom.Text) && dateTimeInput_StartAdvancFrom.Text.Length == 10)
                {
                    Rule = ((int.Parse(dateTimeInput_StartAdvancFrom.Text.Substring(0, 4)) >= 1800) ? (Rule + " and  T_Reserv.Dat  >= '" + dateFormatter.FormatGreg(dateTimeInput_StartAdvancFrom.Text, "yyyy/MM/dd") + "'") : (Rule + " and  T_Reserv.Dat  >= '" + dateFormatter.FormatHijri(dateTimeInput_StartAdvancFrom.Text, "yyyy/MM/dd") + "'"));
                }
                if (VarGeneral.CheckDate(dateTimeInput_StartAdvancTo.Text) && dateTimeInput_StartAdvancTo.Text.Length == 10)
                {
                    Rule = ((int.Parse(dateTimeInput_StartAdvancTo.Text.Substring(0, 4)) >= 1800) ? (Rule + " and  T_Reserv.Dat  <= '" + dateFormatter.FormatGreg(dateTimeInput_StartAdvancTo.Text, "yyyy/MM/dd") + "'") : (Rule + " and  T_Reserv.Dat  <= '" + dateFormatter.FormatHijri(dateTimeInput_StartAdvancTo.Text, "yyyy/MM/dd") + "'"));
                }
            }
            else if (tp == 8 || tp == 12)
            {
                if (VarGeneral.CheckDate(dateTimeInput_StartAdvancFrom.Text) && dateTimeInput_StartAdvancFrom.Text.Length == 10)
                {
                    Rule = ((int.Parse(dateTimeInput_StartAdvancFrom.Text.Substring(0, 4)) >= 1800) ? (Rule + " and  T_per.dt2  >= '" + dateFormatter.FormatGreg(dateTimeInput_StartAdvancFrom.Text, "yyyy/MM/dd") + "'") : (Rule + " and  T_per.dt2  >= '" + dateFormatter.FormatHijri(dateTimeInput_StartAdvancFrom.Text, "yyyy/MM/dd") + "'"));
                }
                if (VarGeneral.CheckDate(dateTimeInput_StartAdvancTo.Text) && dateTimeInput_StartAdvancTo.Text.Length == 10)
                {
                    Rule = ((int.Parse(dateTimeInput_StartAdvancTo.Text.Substring(0, 4)) >= 1800) ? (Rule + " and  T_per.dt2  <= '" + dateFormatter.FormatGreg(dateTimeInput_StartAdvancTo.Text, "yyyy/MM/dd") + "'") : (Rule + " and  T_per.dt2  <= '" + dateFormatter.FormatHijri(dateTimeInput_StartAdvancTo.Text, "yyyy/MM/dd") + "'"));
                }
            }
            else if (tp == 11)
            {
                if (VarGeneral.CheckDate(dateTimeInput_StartAdvancFrom.Text) && dateTimeInput_StartAdvancFrom.Text.Length == 10)
                {
                    Rule = ((int.Parse(dateTimeInput_StartAdvancFrom.Text.Substring(0, 4)) >= 1800) ? (Rule + " and  T_per.dt3  >= '" + dateFormatter.FormatGreg(dateTimeInput_StartAdvancFrom.Text, "yyyy/MM/dd") + "'") : (Rule + " and  T_per.dt3  >= '" + dateFormatter.FormatHijri(dateTimeInput_StartAdvancFrom.Text, "yyyy/MM/dd") + "'"));
                }
                if (VarGeneral.CheckDate(dateTimeInput_StartAdvancTo.Text) && dateTimeInput_StartAdvancTo.Text.Length == 10)
                {
                    Rule = ((int.Parse(dateTimeInput_StartAdvancTo.Text.Substring(0, 4)) >= 1800) ? (Rule + " and  T_per.dt3  <= '" + dateFormatter.FormatGreg(dateTimeInput_StartAdvancTo.Text, "yyyy/MM/dd") + "'") : (Rule + " and  T_per.dt3  <= '" + dateFormatter.FormatHijri(dateTimeInput_StartAdvancTo.Text, "yyyy/MM/dd") + "'"));
                }
            }
            else if (tp == 9 || tp == 10)
            {
                Rule = ((!checkBox_Stay.Checked) ? (Rule + " and T_per.ch = 3 ") : (Rule + " and T_per.ch = 2 "));
                if (VarGeneral.CheckDate(dateTimeInput_StartAdvancFrom.Text) && dateTimeInput_StartAdvancFrom.Text.Length == 10)
                {
                    Rule = ((int.Parse(dateTimeInput_StartAdvancFrom.Text.Substring(0, 4)) >= 1800) ? (Rule + " and  dt  >= '" + dateFormatter.FormatGreg(dateTimeInput_StartAdvancFrom.Text, "yyyy/MM/dd") + "'") : (Rule + " and  dt  >= '" + dateFormatter.FormatHijri(dateTimeInput_StartAdvancFrom.Text, "yyyy/MM/dd") + "'"));
                }
                if (VarGeneral.CheckDate(dateTimeInput_StartAdvancTo.Text) && dateTimeInput_StartAdvancTo.Text.Length == 10)
                {
                    Rule = ((int.Parse(dateTimeInput_StartAdvancTo.Text.Substring(0, 4)) >= 1800) ? (Rule + " and  dt  <= '" + dateFormatter.FormatGreg(dateTimeInput_StartAdvancTo.Text, "yyyy/MM/dd") + "'") : (Rule + " and  dt  <= '" + dateFormatter.FormatHijri(dateTimeInput_StartAdvancTo.Text, "yyyy/MM/dd") + "'"));
                }
            }
            if (tp == 0 || tp == 1)
            {
                if (comboBox_AdvancStatus.SelectedIndex > 0)
                {
                    object obj = Rule;
                    Rule = string.Concat(obj, " and (T_Snd.ch = 1 and T_Snd.typ = ", comboBox_AdvancStatus.SelectedIndex, ") ");
                }
            }
            else if (tp == 2)
            {
                if (comboBox_AdvancStatus.SelectedIndex > 0)
                {
                    Rule = Rule + " and state = " + (int.Parse(comboBox_AdvancStatus.SelectedIndex.ToString()) - 1);
                }
            }
            else if (tp == 9 && comboBox_AdvancStatus.SelectedIndex > 0)
            {
                Rule = Rule + " and T_tran.typ = " + comboBox_AdvancStatus.SelectedValue;
            }
            return Rule;
        }
        public void ButOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (tp == 0 || tp == 1)
                {
                    if (tp == 1 && txtUserNo.Text == "")
                    {
                        MessageBox.Show((LangArEn == 0) ? "?????? ?????????? ?????? ???????????? " : "must specify the Room number ", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        txtUserNo.Focus();
                        return;
                    }
                    RepShow _RepShow = new RepShow();
                    _RepShow.Tables = " T_Snd left JOIN T_per ON T_Snd.perno = T_per.perno left JOIN T_AccDef ON T_per.Cust_no = T_AccDef.AccDef_No left JOIN T_SYSSETTING ON T_AccDef.CompanyID = T_SYSSETTING.SYSSETTING_ID ";
                    string Fields = " T_Snd.SndName, T_Snd.fNo, T_Snd.gd_ID, T_Snd.romno, T_Snd.price as tax, T_Snd.det, T_Snd.Usr, T_Snd.gdUser, T_Snd.gdUserNam, T_Snd.perno, T_Snd.curr, T_Snd.tm, \r\n                                         T_Snd.ch, T_Snd.curcost, T_Snd.sala, T_Snd.dt, T_Snd.typN, T_Snd.ShekNo, T_Snd.ShekDate, T_Snd.ShekBank, T_Snd.IfTrans, T_Snd.RStat, T_Snd.GadeId, \r\n                                         T_Snd.GadeNo,T_Snd.typ ,case when T_Snd.typ = 1 then T_Snd.price else 0 end as Credit,case when T_Snd.typ = 2 then T_Snd.price else 0 end as Debit,case when T_Snd.typ = 1 then '?????? ?????? ????????' else '?????? ?????? ????????' end as InvNm,case when T_Snd.typ = 1 then 'Catch Receipt' else 'receipt' end as InvNmE,T_AccDef.Arb_Des as AccDefNm, T_AccDef.Eng_Des as AccDefNmE,T_SYSSETTING.LogImg";
                    _RepShow.Rule = BuildRuleList();
                    _RepShow.Fields = Fields;
                    try
                    {
                        _RepShow = _RepShow.Save();
                        VarGeneral.RepData = _RepShow.RepData;
                    }
                    catch (Exception ex3)
                    {
                        MessageBox.Show(ex3.Message);
                    }
                    if (VarGeneral.RepData.Tables[0].Rows.Count == 0)
                    {
                        MessageBox.Show((LangArEn == 0) ? "???????? .. ???? ???????? ???????????? ???????????? ???? ?????????????? " : "Sorry .. there is no data to display in the report ", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                    try
                    {
                        VarGeneral.IsGeneralUsed = true;
                        FrmReportsViewer frm = new FrmReportsViewer();
                        frm.Repvalue = "RepRevenue_" + tp;
                        frm.Repvalue = "RepRoomDesc";
                        frm.Repvalue = "RepRoomMovement";
                        frm.Repvalue = "RepRoomReapir";
                        frm.Repvalue = "RepRoomGroup";
                        frm.Repvalue = "RepReserv";
                        frm.Repvalue = "RepPers_" + tp;
                        frm.Repvalue = "RepGuestOrders";
                        frm.Repvalue = "RepGuestCalls";
                        frm.Repvalue = "RepGuestAcc";
                        frm.Repvalue = "RepGuestData";



                        frm.Tag = LangArEn;
                        frm.Repvalue = "RepRevenue_" + tp;
                        VarGeneral.vTitle = Text;
                        frm.TopMost = true;
                        frm.ShowDialog();
                        VarGeneral.IsGeneralUsed = false;

                    }
                    catch (Exception error3)
                    {
                        VarGeneral.DebLog.writeLog("button_ShowRep_Click:", error3, enable: true);
                        MessageBox.Show(error3.Message);
                    }
                }
                else if (tp == 2)
                {
                    RepShow _RepShow = new RepShow();
                    _RepShow.Tables = "  T_Rom LEFT JOIN\r\n                                          T_Loc ON T_Rom.aline = T_Loc.Loc_ID LEFT JOIN\r\n                                          T_per ON T_Rom.perno = T_per.perno AND T_Rom.romno = T_per.romno LEFT JOIN\r\n                                          T_per1 ON T_Rom.romno = T_per1.romno AND T_per.perno = T_per1.perno";
                    string Fields = "T_Rom.romno, T_Rom.flore,(select T_RomChart.FName from T_RomChart where T_RomChart.ID = T_Rom.flore) as FName,(select T_RomChart.FNameE from T_RomChart where T_RomChart.ID = T_Rom.flore) as FNameE, T_Rom.ch, T_Rom.state, T_Rom.row, T_Rom.col, case when T_Rom.wc = 0 then '?????? ??????????' else (case when T_Rom.wc = 1 then '?????????? ??????????' else (case when T_Rom.wc = 2 then '?????????? ??????????' else '??????????' end) end) end as wc, wcno, T_Rom.perno, T_Rom.bedno, case when T_Rom.bed = 0 then '?????? ??????????' else (case when T_Rom.bed = 1 then '??????????' else '????????' end) end as bed,case when T_Rom.tv = 0 then '??????????' else '?????? ??????????' end as tv ,case when T_Rom.bl = 0 then '??????????' else '?????? ??????????' end as bl," + ((LangArEn == 0) ? " T_Loc.Arb_Des " : " T_Loc.Eng_Des ") + " as aline, case when T_Rom.typ = 0 then '????????' else (case when T_Rom.typ = 1 then '????????' else (case when T_Rom.typ = 2 then '????????' else '??????' end) end) end as typ, T_Rom.gropno, T_Rom.price, T_Rom.tax, T_Rom.hed, T_Rom.ser, T_Rom.dt, T_Rom.pri0, T_Rom.tm, T_Rom.pri1, T_Rom.pri2, T_Rom.pri3, T_Rom.priM0, T_Rom.ShortDsc, T_Rom.priM1,T_Rom.Numcounter, T_Rom.CompanyID, T_Rom.perno_Old,T_per.*,(case when T_Rom.perno != '' then (select T_AccDef.Arb_Des from T_AccDef where T_AccDef.AccDef_No = T_per.Cust_no) else '???? ????????' end)  as AccDefNm,(case when T_Rom.perno != '' then (select T_AccDef.Eng_Des  from T_AccDef where T_AccDef.AccDef_No = T_per.Cust_no) else 'There is No' end)  as AccDefNmE ,(select LogImg from T_SYSSETTING where T_SYSSETTING.SYSSETTING_ID = T_Rom.CompanyID) as LogImg,T_Rom.AreaDetail,T_Rom.RoomCount,T_Rom.loungesCount,T_Rom.kitchensCount,case when T_Rom.Furnished = 0 then '?????? ????????????????' else '????????????????' end as Furnished";
                    _RepShow.Rule = BuildRuleList();
                    _RepShow.Fields = Fields;
                    try
                    {
                        _RepShow = _RepShow.Save();
                        VarGeneral.RepData = _RepShow.RepData;
                    }
                    catch (Exception ex3)
                    {
                        MessageBox.Show(ex3.Message);
                    }
                    if (VarGeneral.RepData.Tables[0].Rows.Count == 0)
                    {
                        MessageBox.Show((LangArEn == 0) ? "???????? .. ???? ???????? ???????????? ???????????? ???? ?????????????? " : "Sorry .. there is no data to display in the report ", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                    try
                    {
                        VarGeneral.IsGeneralUsed = true;
                        FrmReportsViewer frm = new FrmReportsViewer();
                        frm.Repvalue = "RepRevenue_" + tp;
                        frm.Repvalue = "RepRoomDesc";
                        frm.Repvalue = "RepRoomMovement";
                        frm.Repvalue = "RepRoomReapir";
                        frm.Repvalue = "RepRoomGroup";
                        frm.Repvalue = "RepReserv";
                        frm.Repvalue = "RepPers_" + tp;
                        frm.Repvalue = "RepGuestOrders";
                        frm.Repvalue = "RepGuestCalls";
                        frm.Repvalue = "RepGuestAcc";
                        frm.Repvalue = "RepGuestData";



                        frm.Tag = LangArEn;
                        frm.Repvalue = "RepRoomDesc";
                        VarGeneral.vTitle = Text;
                        frm.TopMost = true;
                        frm.ShowDialog();
                        VarGeneral.IsGeneralUsed = false;

                    }
                    catch (Exception error3)
                    {
                        VarGeneral.DebLog.writeLog("button_ShowRep_Click:", error3, enable: true);
                        MessageBox.Show(error3.Message);
                    }
                }
                else if (tp == 3 || tp == 5)
                {
                    RepShow _RepShow = new RepShow();
                    _RepShow.Tables = " T_romtrn ";
                    string Fields = " T_romtrn.ID, T_romtrn.romno1, T_romtrn.romno2, T_romtrn.perno, T_romtrn.dt, T_romtrn.tm, T_romtrn.Usr, T_romtrn.UsrNam, case when T_romtrn.typ = 1 then '??????' else (case when T_romtrn.typ = 2 then '??????????' else (case when T_romtrn.typ = 3 then '????????????' else (case when T_romtrn.typ = 4 then '?????????? ??????????' else (case when T_romtrn.typ = 5 then '?????????? ??????????' else (case when T_romtrn.typ = 6 then '?????? ????????' else (case when T_romtrn.typ = 7 then '??????????' else (case when T_romtrn.typ = 8 then '?????? ??????????????' else (case when T_romtrn.typ = 9 then '??????????' else '?????? ??????????????' end) end) end) end) end) end) end) end) end as typ,(case when T_romtrn.perno != '' then (select T_AccDef.Arb_Des  from T_AccDef where T_AccDef.AccDef_No = (select Cust_no from T_per where T_per.perno = T_romtrn.perno )) else '???? ????????' end)  as AccDefNm,(case when T_romtrn.perno != '' then (select T_AccDef.Eng_Des  from T_AccDef where T_AccDef.AccDef_No = (select Cust_no from T_per where T_per.perno = T_romtrn.perno )) else 'There is No' end) as AccDefNmE,(select LogImg from T_SYSSETTING where T_SYSSETTING.SYSSETTING_ID = 1) as LogImg";
                    _RepShow.Rule = BuildRuleList();
                    _RepShow.Fields = Fields;
                    try
                    {
                        _RepShow = _RepShow.Save();
                        VarGeneral.RepData = _RepShow.RepData;
                    }
                    catch (Exception ex3)
                    {
                        MessageBox.Show(ex3.Message);
                    }
                    if (VarGeneral.RepData.Tables[0].Rows.Count == 0)
                    {
                        MessageBox.Show((LangArEn == 0) ? "???????? .. ???? ???????? ???????????? ???????????? ???? ?????????????? " : "Sorry .. there is no data to display in the report ", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                    try
                    {
                        VarGeneral.IsGeneralUsed = true;
                        FrmReportsViewer frm = new FrmReportsViewer();
                        frm.Repvalue = "RepRevenue_" + tp;
                        frm.Repvalue = "RepRoomDesc";
                        frm.Repvalue = "RepRoomMovement";
                        frm.Repvalue = "RepRoomReapir";
                        frm.Repvalue = "RepRoomGroup";
                        frm.Repvalue = "RepReserv";
                        frm.Repvalue = "RepPers_" + tp;
                        frm.Repvalue = "RepGuestOrders";
                        frm.Repvalue = "RepGuestCalls";
                        frm.Repvalue = "RepGuestAcc";
                        frm.Repvalue = "RepGuestData";



                        frm.Tag = LangArEn;
                        frm.Repvalue = "RepRoomMovement";
                        VarGeneral.vTitle = Text;
                        frm.TopMost = true;
                        frm.ShowDialog();
                        VarGeneral.IsGeneralUsed = false;

                    }
                    catch (Exception error3)
                    {
                        VarGeneral.DebLog.writeLog("button_ShowRep_Click:", error3, enable: true);
                        MessageBox.Show(error3.Message);
                    }
                }
                else if (tp == 4)
                {
                    RepShow _RepShow = new RepShow();
                    _RepShow.Tables = " T_romtrn ";
                    string Fields = " T_romtrn.ID, T_romtrn.romno1, T_romtrn.romno2, T_romtrn.perno, T_romtrn.dt, T_romtrn.tm, T_romtrn.Usr, T_romtrn.UsrNam, case when T_romtrn.typ = 1 then '??????' else (case when T_romtrn.typ = 2 then '??????????' else (case when T_romtrn.typ = 3 then '????????????' else (case when T_romtrn.typ = 4 then '?????????? ??????????' else (case when T_romtrn.typ = 5 then '?????????? ??????????' else (case when T_romtrn.typ = 6 then '?????? ????????' else (case when T_romtrn.typ = 7 then '??????????' else (case when T_romtrn.typ = 8 then '?????? ??????????????' else (case when T_romtrn.typ = 9 then '??????????' else '?????? ??????????????' end) end) end) end) end) end) end) end) end as typ,(case when T_romtrn.perno != '' then (select T_AccDef.Arb_Des  from T_AccDef where T_AccDef.AccDef_No = (select Cust_no from T_per where T_per.perno = T_romtrn.perno )) else '???? ????????' end)  as AccDefNm,(case when T_romtrn.perno != '' then (select T_AccDef.Eng_Des  from T_AccDef where T_AccDef.AccDef_No = (select Cust_no from T_per where T_per.perno = T_romtrn.perno )) else 'There is No' end) as AccDefNmE,(select LogImg from T_SYSSETTING where T_SYSSETTING.SYSSETTING_ID = 1) as LogImg";
                    _RepShow.Rule = BuildRuleList();
                    _RepShow.Fields = Fields;
                    try
                    {
                        _RepShow = _RepShow.Save();
                        VarGeneral.RepData = _RepShow.RepData;
                    }
                    catch (Exception ex3)
                    {
                        MessageBox.Show(ex3.Message);
                    }
                    if (VarGeneral.RepData.Tables[0].Rows.Count == 0)
                    {
                        MessageBox.Show((LangArEn == 0) ? "???????? .. ???? ???????? ???????????? ???????????? ???? ?????????????? " : "Sorry .. there is no data to display in the report ", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                    try
                    {
                        VarGeneral.IsGeneralUsed = true;
                        FrmReportsViewer frm = new FrmReportsViewer();
                        frm.Repvalue = "RepRevenue_" + tp;
                        frm.Repvalue = "RepRoomDesc";
                        frm.Repvalue = "RepRoomMovement";
                        frm.Repvalue = "RepRoomReapir";
                        frm.Repvalue = "RepRoomGroup";
                        frm.Repvalue = "RepReserv";
                        frm.Repvalue = "RepPers_" + tp;
                        frm.Repvalue = "RepGuestOrders";
                        frm.Repvalue = "RepGuestCalls";
                        frm.Repvalue = "RepGuestAcc";
                        frm.Repvalue = "RepGuestData";



                        frm.Tag = LangArEn;
                        frm.Repvalue = "RepRoomReapir";
                        VarGeneral.vTitle = Text;
                        frm.TopMost = true;
                        frm.ShowDialog();
                        VarGeneral.IsGeneralUsed = false;

                    }
                    catch (Exception error3)
                    {
                        VarGeneral.DebLog.writeLog("button_ShowRep_Click:", error3, enable: true);
                        MessageBox.Show(error3.Message);
                    }
                }
                else if (tp == 6)
                {
                    RepShow _RepShow = new RepShow();
                    _RepShow.Tables = " T_per ";
                    string Fields = "  perno, romno, nm, nath, day, dt1, price, pasno, dt2, dt3, case when ch = 1 then '????????' else (case when ch = 2 then '????????' else '????????' end) end as ch, actyp, dis, ps1, ps2, cc, pastyp, tm1, tm2, tax, DOL, ser, job, vip, curr, distyp, cust, disknd, jobpls, bdt,bpls, passt, paspls, pasend, enddt, pict, fat, gropno, Cust_no, Totel, DayEdit, DayImport, dt4, KindPer, DayOfM, vAmPm,(select Sum(price) as SumPri from [T_tran] where T_tran.perno=T_per.perno) as Debit,(select LogImg from T_SYSSETTING where T_SYSSETTING.SYSSETTING_ID = 1) as LogImg,(select T_AccDef.Arb_Des from T_AccDef where T_AccDef.AccDef_No = T_per.Cust_no ) as AccDefNm,(select T_AccDef.Eng_Des from T_AccDef where T_AccDef.AccDef_No = T_per.Cust_no ) as AccDefNmE";
                    _RepShow.Rule = BuildRuleList();
                    _RepShow.Fields = Fields;
                    try
                    {
                        _RepShow = _RepShow.Save();
                        VarGeneral.RepData = _RepShow.RepData;
                    }
                    catch (Exception ex3)
                    {
                        MessageBox.Show(ex3.Message);
                    }
                    if (VarGeneral.RepData.Tables[0].Rows.Count == 0)
                    {
                        MessageBox.Show((LangArEn == 0) ? "???????? .. ???? ???????? ???????????? ???????????? ???? ?????????????? " : "Sorry .. there is no data to display in the report ", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                    try
                    {
                        VarGeneral.IsGeneralUsed = true;
                        FrmReportsViewer frm = new FrmReportsViewer();
                        frm.Repvalue = "RepRevenue_" + tp;
                        frm.Repvalue = "RepRoomDesc";
                        frm.Repvalue = "RepRoomMovement";
                        frm.Repvalue = "RepRoomReapir";
                        frm.Repvalue = "RepRoomGroup";
                        frm.Repvalue = "RepReserv";
                        frm.Repvalue = "RepPers_" + tp;
                        frm.Repvalue = "RepGuestOrders";
                        frm.Repvalue = "RepGuestCalls";
                        frm.Repvalue = "RepGuestAcc";
                        frm.Repvalue = "RepGuestData";



                        frm.Tag = LangArEn;
                        frm.Repvalue = "RepRoomGroup";
                        VarGeneral.vTitle = Text;
                        frm.TopMost = true;
                        frm.ShowDialog();
                        VarGeneral.IsGeneralUsed = false;

                    }
                    catch (Exception error3)
                    {
                        VarGeneral.DebLog.writeLog("button_ShowRep_Click:", error3, enable: true);
                        MessageBox.Show(error3.Message);
                    }
                }
                else if (tp == 7)
                {
                    RepShow _RepShow = new RepShow();
                    _RepShow.Tables = " T_Reserv ";
                    string Fields = " T_Reserv.ID, T_Reserv.ResrvNo, T_Reserv.Dat, T_Reserv.Rom, T_Reserv.PerNm, Dt, T_Reserv.Tm, T_Reserv.vAmPm, T_Reserv.IdNo, T_Reserv.Remark, T_Reserv.Nat, T_Reserv.Sts, T_Reserv.Usr, T_Reserv.DayImport, T_Reserv.Dat2, case when T_Reserv.Sts = 0 then '????????' else (case when T_Reserv.Sts = 1 then '????????' else '???????? ??????????' end) end as AccDefNm,(select LogImg from T_SYSSETTING where T_SYSSETTING.SYSSETTING_ID = 1) as LogImg";
                    _RepShow.Rule = BuildRuleList();
                    _RepShow.Fields = Fields;
                    try
                    {
                        _RepShow = _RepShow.Save();
                        VarGeneral.RepData = _RepShow.RepData;
                    }
                    catch (Exception ex3)
                    {
                        MessageBox.Show(ex3.Message);
                    }
                    if (VarGeneral.RepData.Tables[0].Rows.Count == 0)
                    {
                        MessageBox.Show((LangArEn == 0) ? "???????? .. ???? ???????? ???????????? ???????????? ???? ?????????????? " : "Sorry .. there is no data to display in the report ", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                    try
                    {
                        VarGeneral.IsGeneralUsed = true;
                        FrmReportsViewer frm = new FrmReportsViewer();
                        frm.Repvalue = "RepRevenue_" + tp;
                        frm.Repvalue = "RepRoomDesc";
                        frm.Repvalue = "RepRoomMovement";
                        frm.Repvalue = "RepRoomReapir";
                        frm.Repvalue = "RepRoomGroup";
                        frm.Repvalue = "RepReserv";
                        frm.Repvalue = "RepPers_" + tp;
                        frm.Repvalue = "RepGuestOrders";
                        frm.Repvalue = "RepGuestCalls";
                        frm.Repvalue = "RepGuestAcc";
                        frm.Repvalue = "RepGuestData";



                        frm.Tag = LangArEn;
                        frm.Repvalue = "RepReserv";
                        VarGeneral.vTitle = Text;
                        frm.TopMost = true;
                        frm.ShowDialog();
                        VarGeneral.IsGeneralUsed = false;

                    }
                    catch (Exception error3)
                    {
                        VarGeneral.DebLog.writeLog("button_ShowRep_Click:", error3, enable: true);
                        MessageBox.Show(error3.Message);
                    }
                }
                else if (tp == 8 || tp == 11 || tp == 12)
                {
                    RepShow _RepShow = new RepShow();
                    _RepShow.Tables = " T_per ";
                    string Fields = " T_per.*,(select LogImg from T_SYSSETTING where T_SYSSETTING.SYSSETTING_ID = 1) as LogImg,(select T_AccDef.Arb_Des from T_AccDef where T_AccDef.AccDef_No = T_per.Cust_no) as AccDefNm,(select T_AccDef.Eng_Des from T_AccDef where T_AccDef.AccDef_No = T_per.Cust_no) as AccDefNmE";
                    _RepShow.Rule = BuildRuleList();
                    _RepShow.Fields = Fields;
                    try
                    {
                        _RepShow = _RepShow.Save();
                        VarGeneral.RepData = _RepShow.RepData;
                    }
                    catch (Exception ex3)
                    {
                        MessageBox.Show(ex3.Message);
                    }
                    if (VarGeneral.RepData.Tables[0].Rows.Count == 0)
                    {
                        MessageBox.Show((LangArEn == 0) ? "???????? .. ???? ???????? ???????????? ???????????? ???? ?????????????? " : "Sorry .. there is no data to display in the report ", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                    try
                    {
                        for (int i = 0; i < VarGeneral.RepData.Tables[0].Rows.Count; i++)
                        {
                            Total(db.StockPer(int.Parse(VarGeneral.RepData.Tables[0].Rows[i]["perno"].ToString())));
                            VarGeneral.RepData.Tables[0].Rows[i]["day"] = Ttot[0].ToString();
                            VarGeneral.RepData.Tables[0].Rows[i]["DayImport"] = int.Parse(Ttot[1].ToString());
                            VarGeneral.RepData.Tables[0].Rows[i]["Totel"] = int.Parse(Ttot[2].ToString());
                            VarGeneral.RepData.Tables[0].Rows[i]["tax"] = Ttot[3];
                            VarGeneral.RepData.Tables[0].Rows[i]["ser"] = Ttot[4];
                            VarGeneral.RepData.Tables[0].Rows[i]["ps1"] = Ttot[5].ToString();
                            VarGeneral.RepData.Tables[0].Rows[i]["ps2"] = Ttot[6].ToString();
                            VarGeneral.RepData.Tables[0].Rows[i]["price"] = Ttot[7];
                            VarGeneral.RepData.Tables[0].Rows[i]["fat"] = TotResturant;
                            VarGeneral.RepData.Tables[0].Rows[i]["DOL"] = Tot8;
                            VarGeneral.RepData.Tables[0].Rows[i]["nm"] = ((LangArEn == 0) ? db.StockPer(int.Parse(VarGeneral.RepData.Tables[0].Rows[i]["perno"].ToString())).T_AccDef.Arb_Des : db.StockPer(int.Parse(VarGeneral.RepData.Tables[0].Rows[i]["perno"].ToString())).T_AccDef.Eng_Des);
                            if (tp == 11)
                            {
                                VarGeneral.RepData.Tables[0].Rows[i]["dt2"] = VarGeneral.RepData.Tables[0].Rows[i]["dt3"];
                                VarGeneral.RepData.Tables[0].Rows[i]["tm1"] = VarGeneral.RepData.Tables[0].Rows[i]["tm2"];
                            }
                            else
                            {
                                VarGeneral.RepData.Tables[0].Rows[i]["tm1"] = string.Concat(VarGeneral.RepData.Tables[0].Rows[i]["tm1"], " ", VarGeneral.RepData.Tables[0].Rows[i]["vAmPm"]);
                            }
                        }
                        VarGeneral.IsGeneralUsed = true;
                        FrmReportsViewer frm = new FrmReportsViewer();
                        frm.Repvalue = "RepRevenue_" + tp;
                        frm.Repvalue = "RepRoomDesc";
                        frm.Repvalue = "RepRoomMovement";
                        frm.Repvalue = "RepRoomReapir";
                        frm.Repvalue = "RepRoomGroup";
                        frm.Repvalue = "RepReserv";
                        frm.Repvalue = "RepPers_" + tp;
                        frm.Repvalue = "RepGuestOrders";
                        frm.Repvalue = "RepGuestCalls";
                        frm.Repvalue = "RepGuestAcc";
                        frm.Repvalue = "RepGuestData";



                        frm.Tag = LangArEn;
                        frm.Repvalue = "RepPers_" + tp;
                        VarGeneral.vTitle = Text;
                        frm.TopMost = true;
                        frm.ShowDialog();
                        VarGeneral.IsGeneralUsed = false;

                    }
                    catch (Exception error3)
                    {
                        VarGeneral.DebLog.writeLog("button_ShowRep_Click:", error3, enable: true);
                        MessageBox.Show(error3.Message);
                    }
                }
                else if (tp == 9)
                {
                    RepShow _RepShow = new RepShow();
                    _RepShow.Tables = "  T_per INNER JOIN  T_tran ON T_per.perno = T_tran.perno ";
                    string Fields = "  T_per.perno, T_per.romno, T_per.nm, T_per.nath, T_per.day, T_per.dt1, T_per.pasno, T_per.dt2, T_per.dt3, T_per.ch, T_per.dis, T_per.actyp, T_per.ps1, \r\n                                          T_per.ps2, T_per.cc, T_per.pastyp, T_per.tm1, T_per.tm2, T_per.tax, T_per.ser, T_per.vip, T_per.DOL, T_per.job, T_per.curr, T_per.distyp, T_per.cust, T_per.disknd, \r\n                                          T_per.jobpls, T_per.bdt, T_per.bpls, T_per.paspls, T_per.passt, T_per.pasend, T_per.enddt, T_per.pict, T_per.gropno, T_per.Cust_no, T_per.Totel, \r\n                                          T_per.DayEdit, T_per.DayImport, T_per.dt4, T_per.KindPer, T_per.DayOfM, T_per.vAmPm, T_tran.ID, T_tran.dt, T_tran.price, T_tran.fat, T_tran.detal, \r\n                                          T_tran.Usr, T_tran.UsrNam, T_tran.tm, T_tran.typ, T_tran.GadeNo, T_tran.GadeId, T_tran.IsGaid,(select Sum(price) as SumPri from [T_tran] where T_tran.perno=T_per.perno) as Debit,(select LogImg from T_SYSSETTING where T_SYSSETTING.SYSSETTING_ID = 1) as LogImg,(select T_AccDef.Arb_Des from T_AccDef where T_AccDef.AccDef_No = T_per.Cust_no ) as AccDefNm,(select T_AccDef.Eng_Des from T_AccDef where T_AccDef.AccDef_No = T_per.Cust_no ) as AccDefNmE,(select T_sertyp.Arb_Des from T_sertyp where T_sertyp.Serv_ID = T_tran.typ ) as nathA,(select T_sertyp.Eng_Des from T_sertyp where T_sertyp.Serv_ID = T_tran.typ ) as nathE";
                    _RepShow.Rule = BuildRuleList();
                    _RepShow.Fields = Fields;
                    try
                    {
                        _RepShow = _RepShow.Save();
                        VarGeneral.RepData = _RepShow.RepData;
                    }
                    catch (Exception ex3)
                    {
                        MessageBox.Show(ex3.Message);
                    }
                    if (VarGeneral.RepData.Tables[0].Rows.Count == 0)
                    {
                        MessageBox.Show((LangArEn == 0) ? "???????? .. ???? ???????? ???????????? ???????????? ???? ?????????????? " : "Sorry .. there is no data to display in the report ", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                    try
                    {
                        VarGeneral.IsGeneralUsed = true;
                        FrmReportsViewer frm = new FrmReportsViewer();
                        frm.Repvalue = "RepRevenue_" + tp;
                        frm.Repvalue = "RepRoomDesc";
                        frm.Repvalue = "RepRoomMovement";
                        frm.Repvalue = "RepRoomReapir";
                        frm.Repvalue = "RepRoomGroup";
                        frm.Repvalue = "RepReserv";
                        frm.Repvalue = "RepPers_" + tp;
                        frm.Repvalue = "RepGuestOrders";
                        frm.Repvalue = "RepGuestCalls";
                        frm.Repvalue = "RepGuestAcc";
                        frm.Repvalue = "RepGuestData";



                        frm.Tag = LangArEn;
                        frm.Repvalue = "RepGuestOrders";
                        VarGeneral.vTitle = Text;
                        frm.TopMost = true;
                        frm.ShowDialog();
                        VarGeneral.IsGeneralUsed = false;

                    }
                    catch (Exception error3)
                    {
                        VarGeneral.DebLog.writeLog("button_ShowRep_Click:", error3, enable: true);
                        MessageBox.Show(error3.Message);
                    }
                }
                else if (tp == 10)
                {
                    RepShow _RepShow = new RepShow();
                    _RepShow.Tables = "  T_per INNER JOIN  T_tel ON T_per.perno = T_tel.perno ";
                    string Fields = "    T_per.nm, T_per.nath, T_per.day, T_per.dt1, T_per.pasno, T_per.dt2, T_per.dt3, T_per.ch, T_per.dis, T_per.actyp, T_per.ps1, \r\n                                          T_per.ps2, T_per.cc, T_per.pastyp, T_per.tm1, T_per.tm2, T_per.tax, T_per.ser, T_per.vip, T_per.DOL, T_per.job, T_per.curr, T_per.distyp, T_per.cust, T_per.disknd, \r\n                                          T_per.jobpls, T_per.bdt, T_per.bpls, T_per.paspls, T_per.passt, T_per.pasend, T_per.enddt, T_per.pict, T_per.gropno, T_per.Cust_no, T_per.Totel, \r\n                                          T_per.DayEdit, T_per.DayImport, T_per.dt4, T_per.KindPer, T_per.DayOfM, T_per.vAmPm, T_tel.ID, T_tel.perno, T_tel.ino, T_tel.romno, T_tel.tel, T_tel.s, T_tel.m, T_tel.op, T_tel.price, T_tel.h, T_tel.tm, T_tel.dt, T_tel.UsrNam, T_tel.Usr,(select LogImg from T_SYSSETTING where T_SYSSETTING.SYSSETTING_ID = 1) as LogImg,(select T_AccDef.Arb_Des from T_AccDef where T_AccDef.AccDef_No = T_per.Cust_no ) as AccDefNm,(select T_AccDef.Eng_Des from T_AccDef where T_AccDef.AccDef_No = T_per.Cust_no ) as AccDefNmE";
                    _RepShow.Rule = BuildRuleList();
                    _RepShow.Fields = Fields;
                    try
                    {
                        _RepShow = _RepShow.Save();
                        VarGeneral.RepData = _RepShow.RepData;
                    }
                    catch (Exception ex3)
                    {
                        MessageBox.Show(ex3.Message);
                    }
                    if (VarGeneral.RepData.Tables[0].Rows.Count == 0)
                    {
                        MessageBox.Show((LangArEn == 0) ? "???????? .. ???? ???????? ???????????? ???????????? ???? ?????????????? " : "Sorry .. there is no data to display in the report ", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                    try
                    {
                        VarGeneral.IsGeneralUsed = true;
                        FrmReportsViewer frm = new FrmReportsViewer();
                        frm.Repvalue = "RepRevenue_" + tp;
                        frm.Repvalue = "RepRoomDesc";
                        frm.Repvalue = "RepRoomMovement";
                        frm.Repvalue = "RepRoomReapir";
                        frm.Repvalue = "RepRoomGroup";
                        frm.Repvalue = "RepReserv";
                        frm.Repvalue = "RepPers_" + tp;
                        frm.Repvalue = "RepGuestOrders";
                        frm.Repvalue = "RepGuestCalls";
                        frm.Repvalue = "RepGuestAcc";
                        frm.Repvalue = "RepGuestData";



                        frm.Tag = LangArEn;
                        frm.Repvalue = "RepGuestCalls";
                        VarGeneral.vTitle = Text;
                        frm.TopMost = true;
                        frm.ShowDialog();
                        VarGeneral.IsGeneralUsed = false;

                    }
                    catch (Exception error3)
                    {
                        VarGeneral.DebLog.writeLog("button_ShowRep_Click:", error3, enable: true);
                        MessageBox.Show(error3.Message);
                    }
                }
                else if (tp == 13)
                {
                    if (txtUserNo.Text == "")
                    {
                        MessageBox.Show((LangArEn == 0) ? "?????? ?????????? ?????? ???????????? " : "must specify the Guest number ", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        txtUserNo.Focus();
                        return;
                    }
                    RepShow _RepShow = new RepShow();
                    _RepShow.Tables = " T_per ";
                    string Fields = " T_per.*,(select LogImg from T_SYSSETTING where T_SYSSETTING.SYSSETTING_ID = 1) as LogImg,(select T_AccDef.Arb_Des from T_AccDef where T_AccDef.AccDef_No = T_per.Cust_no) as AccDefNm,(select T_AccDef.Eng_Des from T_AccDef where T_AccDef.AccDef_No = T_per.Cust_no) as AccDefNmE";
                    _RepShow.Rule = BuildRuleList();
                    _RepShow.Fields = Fields;
                    try
                    {
                        _RepShow = _RepShow.Save();
                        VarGeneral.RepData = _RepShow.RepData;
                    }
                    catch (Exception ex3)
                    {
                        MessageBox.Show(ex3.Message);
                    }
                    if (VarGeneral.RepData.Tables[0].Rows.Count == 0)
                    {
                        MessageBox.Show((LangArEn == 0) ? "???????? .. ???? ???????? ???????????? ???????????? ???? ?????????????? " : "Sorry .. there is no data to display in the report ", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                    int i = 6;
                    vData = new string[SerTypeCount + 1, 8];
                    vData[0, 0] = ((LangArEn == 0) ? "?????? ???????? ??????????" : "Number of days of residence");
                    vData[1, 0] = ((LangArEn == 0) ? "???????????? ???????? ???????? ??????????????" : "Total Length of Stay");
                    vData[2, 0] = ((LangArEn == 0) ? "??????????????????" : "Price");
                    vData[3, 0] = ((LangArEn == 0) ? "???????????? ???????? ?????????????? ????????????????" : "Total of additional services");
                    vData[4, 0] = ((LangArEn == 0) ? "???????????? ???????? ??????????" : "Total Discount Value");
                    vData[5, 0] = ((LangArEn == 0) ? "???????????? ?????????????? ???? ?????????? ?????????????? ????????" : "Total required from other accounting movements");
                    List<T_sertyp> q = db.T_sertyps.Select((T_sertyp t) => t).ToList();
                    for (i = 6; i < q.Count + 6; i++)
                    {
                        vData[i, 0] = ((LangArEn == 0) ? q[i - 6].Arb_Des : q[i - 6].Eng_Des);
                        vData[i, 2] = q[i - 6].Serv_No;
                    }
                    for (int j = 6; j < i; j++)
                    {
                        try
                        {
                            List<double> sqlst = db.ExecuteQuery<double>("select sum(price) as SumPrice from [T_tran] where perno=" + txtUserNo.Text + " and typ = " + vData[j, 2], new object[0]).ToList();
                            if (sqlst.Count > 0)
                            {
                                double tot11 = ((!string.IsNullOrEmpty(sqlst.FirstOrDefault().ToString())) ? sqlst.FirstOrDefault() : 0.0);
                                Tot1 += tot11;
                                vData[j, 1] = Tot1.ToString();
                            }
                        }
                        catch
                        {
                            Tot1 += 0.0;
                            vData[j, 1] = "0";
                        }
                    }
                    try
                    {
                        List<double> sqlst = db.ExecuteQuery<double>("select sum(price) as SumPrice from [T_tel] where perno=" + txtUserNo.Text, new object[0]).ToList();
                        if (sqlst.Count > 0)
                        {
                            Tot2 = ((!string.IsNullOrEmpty(sqlst.FirstOrDefault().ToString())) ? sqlst.FirstOrDefault() : 0.0);
                        }
                    }
                    catch
                    {
                        Tot2 = 0.0;
                    }
                    i++;
                    vData[i, 0] = ((LangArEn == 0) ? "?????????????????? ????????????????" : "Phone calls");
                    vData[i, 1] = Tot2.ToString();
                    try
                    {
                        Stock_DataDataContext _DB2 = new Stock_DataDataContext(VarGeneral.BranchCS);
                        try
                        {
                            List<T_AccDef> sqlst3 = (from er in _DB2.T_AccDefs
                                                     where er.AccDef_No == _DB2.StockPer(int.Parse(txtUserNo.Text)).Cust_no
                                                     orderby er.AccDef_No
                                                     select er).ToList();
                            if (sqlst3.Count() > 0)
                            {
                                sqlst3.First().Debit = sqlst3.First().T_GDDETs.Where((T_GDDET g) => !g.T_GDHEAD.gdLok && g.T_AccDef.Lev == 4 && g.gdValue > 0.0 && g.T_GDHEAD.gdTyp != 15 && g.T_GDHEAD.gdTyp != 27 && g.T_GDHEAD.gdTyp != 28).Sum((T_GDDET g) => g.gdValue.Value);
                                sqlst3.First().Credit = Math.Abs(sqlst3.First().T_GDDETs.Where((T_GDDET g) => !g.T_GDHEAD.gdLok && g.T_AccDef.Lev == 4 && g.gdValue < 0.0 && g.T_GDHEAD.gdTyp != 15 && g.T_GDHEAD.gdTyp != 27 && g.T_GDHEAD.gdTyp != 28).Sum((T_GDDET g) => g.gdValue.Value));
                                sqlst3.First().Balance = sqlst3.First().T_GDDETs.Where((T_GDDET g) => !g.T_GDHEAD.gdLok && g.T_AccDef.Lev == 4 && g.T_GDHEAD.gdTyp != 15 && g.T_GDHEAD.gdTyp != 27 && g.T_GDHEAD.gdTyp != 28).Sum((T_GDDET g) => g.gdValue.Value);
                            }
                            if (sqlst3.Count > 0)
                            {
                                if (sqlst3.FirstOrDefault().Balance.Value < 0.0)
                                {
                                    Tot3 = Math.Abs(sqlst3.FirstOrDefault().Balance.Value);
                                }
                                else
                                {
                                    Tot3 = 0.0 - sqlst3.FirstOrDefault().Balance.Value;
                                }
                            }
                        }
                        finally
                        {
                            if (_DB2 != null)
                            {
                                ((IDisposable)_DB2).Dispose();
                            }
                        }
                    }
                    catch
                    {
                        Tot3 = 0.0;
                    }
                    try
                    {
                        if (Tot3 < 0.0)
                        {
                            Tot3 = 0.0;
                        }
                        if (Tot3 > 0.0)
                        {
                            Stock_DataDataContext _DB = new Stock_DataDataContext(VarGeneral.BranchCS);
                            try
                            {
                                List<T_per> sqlst2 = _DB.T_pers.Where((T_per er) => er.Cust_no == _DB.StockPer(int.Parse(txtUserNo.Text)).Cust_no).ToList();
                                if (sqlst2.Count > 0)
                                {
                                    double cc = sqlst2.Sum((T_per g) => g.fat.Value);
                                    if (cc > 0.0 && cc <= Tot3)
                                    {
                                        Tot3 -= cc;
                                    }
                                }
                            }
                            finally
                            {
                                if (_DB != null)
                                {
                                    ((IDisposable)_DB).Dispose();
                                }
                            }
                        }
                    }
                    catch
                    {
                    }
                    i++;
                    Total(db.StockPer(int.Parse(txtUserNo.Text)));
                    vData[i, 0] = ((LangArEn == 0) ? "???????????? ??????????????" : "Total Paid");
                    vData[i, 1] = Tot3.ToString();
                    vData[0, 1] = Ttot[0].ToString();
                    vData[1, 1] = Ttot[1].ToString();
                    vData[2, 1] = Ttot[2].ToString();
                    vData[3, 1] = Ttot[3].ToString();
                    if (db.StockPer(int.Parse(txtUserNo.Text)).disknd.Value == 1)
                    {
                        if (db.StockPer(int.Parse(txtUserNo.Text)).distyp.Value == 0)
                        {
                            vData[4, 1] = Tot7.ToString();
                        }
                        else if (db.StockPer(int.Parse(txtUserNo.Text)).distyp.Value == 1)
                        {
                            vData[4, 1] = Tot8.ToString();
                        }
                    }
                    else if (db.StockPer(int.Parse(txtUserNo.Text)).disknd.Value == 2)
                    {
                        if (db.StockPer(int.Parse(txtUserNo.Text)).distyp.Value == 0)
                        {
                            vData[4, 1] = Tot7.ToString();
                        }
                        else if (db.StockPer(int.Parse(txtUserNo.Text)).distyp.Value == 1)
                        {
                            vData[4, 1] = Tot8.ToString();
                        }
                    }
                    vData[5, 1] = TotResturant.ToString();
                    try
                    {
                        for (i = 0; i <= SerTypeCount; i++)
                        {
                            VarGeneral.RepData.Tables[0].Rows.Add();
                        }
                        VarGeneral.RepData.Tables[0].Rows[0].Delete();
                        T_per Query = db.StockPer(int.Parse(txtUserNo.Text));
                        for (i = 0; i <= SerTypeCount; i++)
                        {
                            VarGeneral.RepData.Tables[0].Rows[i + 1]["romno"] = Query.romno;
                            VarGeneral.RepData.Tables[0].Rows[i + 1]["dt2"] = Query.dt2;
                            VarGeneral.RepData.Tables[0].Rows[i + 1]["perno"] = Query.perno;
                            VarGeneral.RepData.Tables[0].Rows[i + 1]["AccDefNm"] = Query.T_AccDef.Arb_Des;
                            VarGeneral.RepData.Tables[0].Rows[i + 1]["AccDefNmE"] = Query.T_AccDef.Eng_Des;
                            VarGeneral.RepData.Tables[0].Rows[i + 1]["nm"] = vData[i, 0];
                            VarGeneral.RepData.Tables[0].Rows[i + 1]["price"] = VarGeneral.TString.TEmpty(vData[i, 1]);
                            VarGeneral.RepData.Tables[0].Rows[i + 1]["Totel"] = VarGeneral.TString.TEmpty(Ttot[7].ToString());
                            if (Query.T_Roms.Count > 0)
                            {
                                DataRow dataRow = VarGeneral.RepData.Tables[0].Rows[i + 1];
                                int? typ = Query.T_Roms.FirstOrDefault().typ;
                                dataRow["pasno"] = ((typ.Value == 0 && typ.HasValue) ? "?????? ???????????? " : ((Query.T_Roms.FirstOrDefault().typ == 1) ? "?????? ???????????? " : ((Query.T_Roms.FirstOrDefault().typ == 2) ? "?????? ???????????? " : "?????? ?????????? ")));
                            }
                            else
                            {
                                VarGeneral.RepData.Tables[0].Rows[i + 1]["pasno"] = "?????? ???????????? ";
                            }
                        }
                        VarGeneral.IsGeneralUsed = true;
                        FrmReportsViewer frm = new FrmReportsViewer();
                        frm.Repvalue = "RepRevenue_" + tp;
                        frm.Repvalue = "RepRoomDesc";
                        frm.Repvalue = "RepRoomMovement";
                        frm.Repvalue = "RepRoomReapir";
                        frm.Repvalue = "RepRoomGroup";
                        frm.Repvalue = "RepReserv";
                        frm.Repvalue = "RepPers_" + tp;
                        frm.Repvalue = "RepGuestOrders";
                        frm.Repvalue = "RepGuestCalls";
                        frm.Repvalue = "RepGuestAcc";
                        frm.Repvalue = "RepGuestData";



                        frm.Tag = LangArEn;
                        frm.Repvalue = "RepGuestAcc";
                        VarGeneral.vTitle = Text;
                        frm.TopMost = true;
                        frm.ShowDialog();
                        VarGeneral.IsGeneralUsed = false;

                    }
                    catch (Exception error3)
                    {
                        VarGeneral.DebLog.writeLog("button_ShowRep_Click:", error3, enable: true);
                        MessageBox.Show(error3.Message);
                    }
                }
                else
                {
                    if (tp != 14)
                    {
                        return;
                    }
                    RepShow _RepShow = new RepShow();
                    _RepShow.Tables = "  T_per left JOIN\r\n                                  T_IDType ON T_per.pastyp = T_IDType.IDType_ID left JOIN\r\n                                  T_Job ON T_per.job = T_Job.Job_No left JOIN\r\n                                  T_Nationalities ON T_per.nath = T_Nationalities.Nation_No left JOIN\r\n                                  T_BirthPlace ON T_per.bpls = T_BirthPlace.BirthPlaceNo left JOIN\r\n                                  T_AccDef ON T_per.Cust_no = T_AccDef.AccDef_No left JOIN\r\n                                  T_City ON T_per.paspls = T_City.City_No ";
                    string Fields = "  T_per.perno, T_per.romno, T_per.nm,T_Nationalities.NameA as nathA,T_Nationalities.NameE as nathE, T_per.day, T_per.dt1, T_per.price, T_per.pasno, T_per.dt2, T_per.dt3, T_per.ch, T_per.dis, T_per.actyp, T_per.ps1, T_per.ps2, T_per.cc, T_IDType.Arb_Des as pastypA, T_IDType.Eng_Des as pastypE, T_per.tm1, T_per.tm2, T_per.tax, T_per.ser, T_per.DOL, T_per.vip,T_Job.NameA as jobA,T_Job.NameE as jobE, T_per.curr, T_per.distyp, T_per.cust, T_per.disknd, T_per.jobpls, T_per.bdt,\r\n                                        T_BirthPlace.NameA as bplsA,T_BirthPlace.NameE as bplsE,T_City.NameA as pasplsA,T_City.NameE as pasplsE, T_per.passt, T_per.pasend, T_per.enddt, T_per.pict, T_per.fat, T_per.gropno, T_per.Cust_no, T_per.Totel, T_per.DayEdit, T_per.DayImport, T_per.dt4, T_per.KindPer, T_per.DayOfM, T_per.vAmPm,T_AccDef.AccDef_No , T_AccDef.Arb_Des as AccDefNm, T_AccDef.Eng_Des as AccDefNmE ,(select LogImg from T_SYSSETTING where T_SYSSETTING.SYSSETTING_ID = 1) as LogImg";
                    _RepShow.Rule = "  Where " + ((comboBox_AdvancStatus.SelectedIndex == 1) ? " T_per.ch=2 " : ((comboBox_AdvancStatus.SelectedIndex == 2) ? " T_per.ch=3 " : "  1 = 1")) + " order by T_per.perno";
                    _RepShow.Fields = Fields;
                    try
                    {
                        _RepShow = _RepShow.Save();
                        VarGeneral.RepData = _RepShow.RepData;
                    }
                    catch (Exception ex3)
                    {
                        MessageBox.Show(ex3.Message);
                    }
                    if (VarGeneral.RepData.Tables[0].Rows.Count == 0)
                    {
                        MessageBox.Show((LangArEn == 0) ? "???????? .. ???? ???????? ???????????? ???????????? ???? ?????????????? " : "Sorry .. there is no data to display in the report ", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                    try
                    {
                        VarGeneral.IsGeneralUsed = true;
                        FrmReportsViewer frm = new FrmReportsViewer();
                        frm.Repvalue = "RepRevenue_" + tp;
                        frm.Repvalue = "RepRoomDesc";
                        frm.Repvalue = "RepRoomMovement";
                        frm.Repvalue = "RepRoomReapir";
                        frm.Repvalue = "RepRoomGroup";
                        frm.Repvalue = "RepReserv";
                        frm.Repvalue = "RepPers_" + tp;
                        frm.Repvalue = "RepGuestOrders";
                        frm.Repvalue = "RepGuestCalls";
                        frm.Repvalue = "RepGuestAcc";
                        frm.Repvalue = "RepGuestData";



                        frm.Tag = LangArEn;
                        frm.Repvalue = "RepGuestData";
                        VarGeneral.vTitle = Text;
                        frm.TopMost = true;
                        frm.ShowDialog();
                        VarGeneral.IsGeneralUsed = false;

                    }
                    catch (Exception error3)
                    {
                        VarGeneral.DebLog.writeLog("buttonItem_RepGuestsData_Click:", error3, enable: true);
                        MessageBox.Show(error3.Message);
                    }
                    return;
                }
            }
            catch (Exception ex3)
            {
                MessageBox.Show(ex3.Message);
            }
        }
        public DataTable ConvertToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
            {
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            }
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                {
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                }
                table.Rows.Add(row);
            }
            return table;
        }
        private void Total(T_per _per)
        {
            Ttot = new double[9];
            double Pri = 0.0;
            double vTax = 0.0;
            double vSer = 0.0;
            double vDay = 0.0;
            Tot1 = 0.0;
            Tot2 = 0.0;
            Tot3 = 0.0;
            Tot4 = 0.0;
            Tot5 = 0.0;
            Tot6 = 0.0;
            Tot7 = 0.0;
            Tot8 = 0.0;
            Tot10 = 0.0;
            tot50 = 0.0;
            tot60 = 0.0;
            tt1 = 0.0;
            Tot = 0.0;
            TotResturant = 0.0;
            dis = 0.0;
            double[,] RomAr = new double[SerTypeCount + 1, 8];
            string[,] RomDt = new string[SerTypeCount + 1, 5];
            for (int q2 = 0; q2 <= SerTypeCount; q2++)
            {
                for (int q3 = 0; q3 <= 7; q3++)
                {
                    RomAr[q2, q3] = 0.0;
                }
                for (int q4 = 0; q4 <= 1; q4++)
                {
                    RomDt[q2, q4] = "";
                }
            }
            dis = _per.dis.Value;
            RomAr[0, 0] = _per.romno.Value;
            RomAr[0, 1] = _per.price.Value;
            if (_per.tax.HasValue)
            {
                RomAr[0, 2] = _per.tax.Value;
            }
            else
            {
                RomAr[0, 2] = 0.0;
            }
            if (_per.ser.HasValue)
            {
                RomAr[0, 3] = _per.ser.Value;
            }
            else
            {
                RomAr[0, 3] = 0.0;
            }
            if (_per.gropno.HasValue)
            {
                RomAr[0, 7] = _per.gropno.Value;
            }
            else
            {
                RomAr[0, 7] = 0.0;
            }
            RomDt[0, 0] = _per.dt2;
            RomDt[0, 1] = _per.tm1;
            RomDt[0, 2] = _per.dt3;
            RomDt[0, 3] = _per.tm2;
            try
            {
                VarGeneral.DayEdit = _per.DayEdit.Value;
            }
            catch
            {
                VarGeneral.DayEdit = 0;
            }
            if (_per.KindPer.Value == 1)
            {
                if (_per.DayOfM.HasValue)
                {
                    VarGeneral.GDayM = _per.DayOfM.Value;
                }
                else
                {
                    VarGeneral.GDayM = 0;
                }
                try
                {
                    if (VarGeneral.GDayM == 0)
                    {
                        VarGeneral.GDayM = VarGeneral.Settings_Sys.DayOfM.Value;
                    }
                }
                catch
                {
                }
            }
            for (int q = 0; q <= SerTypeCount; q++)
            {
                if (RomAr[q, 0] == 0.0)
                {
                    continue;
                }
                if (string.IsNullOrEmpty(_per.dt3))
                {
                    if (_per.KindPer.Value == 0)
                    {
                        aa = VarGeneral.Dy(RomDt[q, 0], RomDt[q, 1] + " " + _per.vAmPm) + VarGeneral.DayEdit;
                    }
                    else
                    {
                        aa = VarGeneral.Dy(RomDt[q, 0], RomDt[q, 1] + " " + _per.vAmPm) + VarGeneral.DayEdit;
                        VarGeneral.Dy2(RomDt[q, 0], RomDt[q, 1] + " " + _per.vAmPm);
                    }
                }
                else if (_per.KindPer.Value == 0)
                {
                    aa = VarGeneral.Dy1(RomDt[q, 0], RomDt[q, 1] + " " + _per.vAmPm, RomDt[q, 2], RomDt[q, 3]) + VarGeneral.DayEdit;
                }
                else
                {
                    aa = VarGeneral.Dy1(RomDt[q, 0], RomDt[q, 1] + " " + _per.vAmPm, RomDt[q, 2], RomDt[q, 3]) + VarGeneral.DayEdit;
                    VarGeneral.Dy2(RomDt[q, 0], RomDt[q, 1] + " " + _per.vAmPm);
                }
                if (_per.KindPer.Value == 0)
                {
                    RomAr[q, 6] = Conversion.Val(Strings.Format(Conversion.Val(RomAr[q, 1]) * Conversion.Val(aa), "#.00"));
                }
                else
                {
                    RomAr[q, 6] = Conversion.Val(Strings.Format(Conversion.Val(RomAr[q, 1]) * (double)VarGeneral.CS, "#.00"));
                }
                RomAr[q, 4] = Conversion.Val(RomAr[q, 2]) * Conversion.Val(RomAr[q, 6]) / 100.0;
                RomAr[q, 5] = Conversion.Val(RomAr[q, 3]) * Conversion.Val(RomAr[q, 6]) / 100.0;
                Pri += RomAr[q, 6];
                vTax += RomAr[q, 4];
                vSer += RomAr[q, 5];
                vDay += aa;
            }
            Tot1 = 0.0;
            Tot2 = 0.0;
            Tot3 = 0.0;
            Tot4 = 0.0;
            Tot5 = 0.0;
            Tot6 = 0.0;
            tot50 = 0.0;
            tot60 = 0.0;
            Tot7 = 0.0;
            Tot8 = 0.0;
            Tot10 = 0.0;
            try
            {
                List<double> sqlst2 = db.ExecuteQuery<double>("select sum(price) as SumPrice from [T_tran] where perno=" + _per.perno, new object[0]).ToList();
                if (sqlst2.Count > 0)
                {
                    Tot1 = ((!string.IsNullOrEmpty(sqlst2.FirstOrDefault().ToString())) ? sqlst2.FirstOrDefault() : 0.0);
                }
            }
            catch
            {
                Tot1 = 0.0;
            }
            try
            {
                List<double> sqlst2 = db.ExecuteQuery<double>("select sum(price) as SumPrice from [T_tel] where perno=" + _per.perno, new object[0]).ToList();
                if (sqlst2.Count > 0)
                {
                    Tot2 = ((!string.IsNullOrEmpty(sqlst2.FirstOrDefault().ToString())) ? sqlst2.FirstOrDefault() : 0.0);
                }
            }
            catch
            {
                Tot2 = 0.0;
            }
            try
            {
                List<double> sqlst2 = db.ExecuteQuery<double>("SELECT Sum(case when [T_Snd].[typ]=1 then [T_Snd].[price]*[T_Snd].[curcost] else -[T_Snd].[price]*[T_Snd].[curcost] end) AS SumPrice FROM [T_Snd] where perno=" + _per.perno + " and ch<>3", new object[0]).ToList();
                if (sqlst2.Count > 0)
                {
                    Tot3 = ((!string.IsNullOrEmpty(sqlst2.FirstOrDefault().ToString())) ? sqlst2.FirstOrDefault() : 0.0);
                }
            }
            catch
            {
                Tot3 = 0.0;
            }
            try
            {
                List<T_AccDef> sqlst = (from er in db.T_AccDefs
                                        where er.AccDef_No == _per.Cust_no
                                        orderby er.AccDef_No
                                        select er).ToList();
                if (sqlst.Count() > 0)
                {
                    sqlst.First().Debit = sqlst.First().T_GDDETs.Where((T_GDDET g) => !g.T_GDHEAD.gdLok && g.T_AccDef.Lev == 4 && g.gdValue > 0.0 && g.T_GDHEAD.gdTyp != 15 && g.T_GDHEAD.gdTyp != 27 && g.T_GDHEAD.gdTyp != 28).Sum((T_GDDET g) => g.gdValue.Value);
                    sqlst.First().Credit = Math.Abs(sqlst.First().T_GDDETs.Where((T_GDDET g) => !g.T_GDHEAD.gdLok && g.T_AccDef.Lev == 4 && g.gdValue < 0.0 && g.T_GDHEAD.gdTyp != 15 && g.T_GDHEAD.gdTyp != 27 && g.T_GDHEAD.gdTyp != 28).Sum((T_GDDET g) => g.gdValue.Value));
                    sqlst.First().Balance = sqlst.First().T_GDDETs.Where((T_GDDET g) => !g.T_GDHEAD.gdLok && g.T_AccDef.Lev == 4 && g.T_GDHEAD.gdTyp != 15 && g.T_GDHEAD.gdTyp != 27 && g.T_GDHEAD.gdTyp != 28).Sum((T_GDDET g) => g.gdValue.Value);
                }
                if (sqlst.Count > 0)
                {
                    TotResturant = sqlst.FirstOrDefault().Balance.Value;
                }
            }
            catch
            {
                TotResturant = 0.0;
            }
            try
            {
                if (TotResturant < 0.0)
                {
                    TotResturant = 0.0;
                }
            }
            catch
            {
            }
            Tot4 = Pri;
            Tot10 = Tot1 + Tot2 + Tot4;
            double vTx = 0.0;
            double vSr = 0.0;
            try
            {
                vTx = db.StockRoom(_per.romno.Value).tax.Value;
            }
            catch
            {
                vTx = 0.0;
            }
            try
            {
                vSr = db.StockRoom(_per.romno.Value).ser.Value;
            }
            catch
            {
                vSr = 0.0;
            }
            Tot5 = Tot4 * vTx / 100.0;
            Tot6 = Tot4 * vSer / 100.0;
            Tot10 = Tot1 + Tot2 + Tot4 + Tot5 + Tot6;
            if (_per.disknd.Value == 1)
            {
                if (_per.distyp.Value == 0)
                {
                    for (int i = 0; i <= SerTypeCount; i++)
                    {
                        if (RomAr[i, 0] != 0.0)
                        {
                            tt1 = RomAr[i, 6];
                            Tot7 = Conversion.Val(tt1) * Conversion.Val(dis) / 100.0;
                            tt1 = Conversion.Val(tt1) - Conversion.Val(Tot7);
                            Tot4 -= Tot7;
                            tot50 += Conversion.Val(tt1) * Conversion.Val(RomAr[i, 2]) / 100.0;
                            tot60 += Conversion.Val(tt1) * Conversion.Val(RomAr[i, 3]) / 100.0;
                        }
                    }
                    Tot5 = tot50;
                    Tot6 = tot60;
                }
                else if (_per.distyp.Value == 1)
                {
                    Tot8 = Tot10 * dis / 100.0;
                }
            }
            if (_per.disknd.Value == 2)
            {
                if (_per.distyp.Value == 0)
                {
                    Tot7 = Conversion.Val(dis * vDay);
                    for (int i = 0; i <= SerTypeCount; i++)
                    {
                        if (RomAr[i, 0] != 0.0)
                        {
                            tt1 = RomAr[i, 6];
                            tt1 = Conversion.Val(tt1) - Conversion.Val(Tot7);
                            Tot4 -= Tot7;
                            tot50 += Conversion.Val(tt1) * Conversion.Val(RomAr[i, 2]) / 100.0;
                            tot60 += Conversion.Val(tt1) * Conversion.Val(RomAr[i, 3]) / 100.0;
                        }
                    }
                    Tot5 = tot50;
                    Tot6 = tot60;
                }
                else if (_per.distyp.Value == 1)
                {
                    Tot8 = dis;
                }
            }
            if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 48))
            {
                Tot10 = Tot1 + Tot2 + Tot4 + Tot5 + Tot6 + TotResturant - Tot8;
            }
            else
            {
                Tot10 = Tot1 + Tot2 + Tot4 + Tot5 + Tot6 - Tot8;
            }
            Tot = Tot10 - Tot3;
            double Snd = 0.0;
            double Ser = 0.0;
            double Tel = 0.0;
            Pri = Tot4;
            vTax = Tot5;
            vSer = Tot6;
            Snd = Tot3;
            Ser = Tot1;
            Tel = Tot2;
            Ttot[0] = vDay;
            Ttot[1] = Pri;
            if (vDay != 0.0)
            {
                if (_per.KindPer.Value == 0)
                {
                    Ttot[2] = Pri / vDay;
                }
                else if (_per.KindPer.Value == 1)
                {
                    Ttot[2] = Pri / (double)VarGeneral.CS;
                }
            }
            Ttot[3] = vSer;
            Ttot[4] = Ser;
            Ttot[5] = Tel;
            Ttot[6] = Snd;
            Ttot[7] = Tot;
            Ttot[8] = Tot8;
        }
        private string GetSqlWhere()
        {
            string QStr = "";
            string tmpStr = "";
            if (dateTimeInput_StartAdvancFrom.Text != "    /  /" && dateTimeInput_StartAdvancFrom.Text.Length == 10)
            {
                QStr = QStr + " AND ( T_Advances.ResolutionDate >= '" + Convert.ToDateTime(dateTimeInput_StartAdvancFrom.Text).ToString("yyyy/MM/dd") + "' ) ";
            }
            if (dateTimeInput_StartAdvancTo.Text != "    /  /" && dateTimeInput_StartAdvancTo.Text.Length == 10)
            {
                QStr = QStr + " AND ( T_Advances.ResolutionDate <= '" + Convert.ToDateTime(dateTimeInput_StartAdvancTo.Text).ToString("yyyy/MM/dd") + "' ) ";
            }
            if (comboBox_AdvancStatus.SelectedIndex == 1)
            {
                QStr += " AND T_Premiums.IFState = 1 ";
            }
            else if (comboBox_AdvancStatus.SelectedIndex == 2)
            {
                QStr += " AND T_Premiums.IFState = 0 ";
            }
            return QStr;
        }
        private void dateTimeInput_StartAdvancFrom_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_StartAdvancFrom.Text = Convert.ToDateTime(dateTimeInput_StartAdvancFrom.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_StartAdvancFrom.Text = "";
            }
        }
        private void dateTimeInput_StartAdvancTo_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_StartAdvancTo.Text = Convert.ToDateTime(dateTimeInput_StartAdvancTo.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_StartAdvancTo.Text = "";
            }
        }
        private void ButExit_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void dateTimeInput_StartAdvancFrom_Click(object sender, EventArgs e)
        {
            dateTimeInput_StartAdvancFrom.SelectAll();
        }
        private void dateTimeInput_StartAdvancTo_Click(object sender, EventArgs e)
        {
            dateTimeInput_StartAdvancTo.SelectAll();
        }
        private void textBox_Time_Click(object sender, EventArgs e)
        {
            textBox_Time.SelectAll();
        }
        private void textBox_Time2_Click(object sender, EventArgs e)
        {
            textBox_Time2.SelectAll();
        }
        private void textBox_Time_Leave(object sender, EventArgs e)
        {
            try
            {
                if (VarGeneral.CheckTime(textBox_Time.Text))
                {
                    textBox_Time.Text = TimeSpan.Parse(textBox_Time.Text).ToString();
                }
                else
                {
                    textBox_Time.Text = DateTime.Now.ToString("hh:mm:ss");
                }
            }
            catch
            {
                textBox_Time.Text = DateTime.Now.ToString("hh:mm:ss");
            }
            try
            {
                if (int.Parse(textBox_Time.Text.Substring(0, 2)) > 12 || textBox_Time.Text.Substring(0, 2) == "00")
                {
                    if (textBox_Time.Text.Substring(0, 2) == "13")
                    {
                        textBox_Time.Text = "01" + textBox_Time.Text.Remove(0, 2);
                    }
                    else if (textBox_Time.Text.Substring(0, 2) == "14")
                    {
                        textBox_Time.Text = "02" + textBox_Time.Text.Remove(0, 2);
                    }
                    else if (textBox_Time.Text.Substring(0, 2) == "15")
                    {
                        textBox_Time.Text = "03" + textBox_Time.Text.Remove(0, 2);
                    }
                    else if (textBox_Time.Text.Substring(0, 2) == "16")
                    {
                        textBox_Time.Text = "04" + textBox_Time.Text.Remove(0, 2);
                    }
                    else if (textBox_Time.Text.Substring(0, 2) == "17")
                    {
                        textBox_Time.Text = "05" + textBox_Time.Text.Remove(0, 2);
                    }
                    else if (textBox_Time.Text.Substring(0, 2) == "18")
                    {
                        textBox_Time.Text = "06" + textBox_Time.Text.Remove(0, 2);
                    }
                    else if (textBox_Time.Text.Substring(0, 2) == "19")
                    {
                        textBox_Time.Text = "07" + textBox_Time.Text.Remove(0, 2);
                    }
                    else if (textBox_Time.Text.Substring(0, 2) == "20")
                    {
                        textBox_Time.Text = "08" + textBox_Time.Text.Remove(0, 2);
                    }
                    else if (textBox_Time.Text.Substring(0, 2) == "21")
                    {
                        textBox_Time.Text = "09" + textBox_Time.Text.Remove(0, 2);
                    }
                    else if (textBox_Time.Text.Substring(0, 2) == "22")
                    {
                        textBox_Time.Text = "10" + textBox_Time.Text.Remove(0, 2);
                    }
                    else if (textBox_Time.Text.Substring(0, 2) == "23")
                    {
                        textBox_Time.Text = "11" + textBox_Time.Text.Remove(0, 2);
                    }
                    else if (textBox_Time.Text.Substring(0, 2) == "00")
                    {
                        textBox_Time.Text = "12" + textBox_Time.Text.Remove(0, 2);
                    }
                }
            }
            catch
            {
            }
        }
        private void textBox_Time2_Leave(object sender, EventArgs e)
        {
            try
            {
                if (VarGeneral.CheckTime(textBox_Time2.Text))
                {
                    textBox_Time2.Text = TimeSpan.Parse(textBox_Time2.Text).ToString();
                }
                else
                {
                    textBox_Time2.Text = DateTime.Now.ToString("hh:mm:ss");
                }
            }
            catch
            {
                textBox_Time2.Text = DateTime.Now.ToString("hh:mm:ss");
            }
            try
            {
                if (int.Parse(textBox_Time2.Text.Substring(0, 2)) > 12 || textBox_Time2.Text.Substring(0, 2) == "00")
                {
                    if (textBox_Time2.Text.Substring(0, 2) == "13")
                    {
                        textBox_Time2.Text = "01" + textBox_Time2.Text.Remove(0, 2);
                    }
                    else if (textBox_Time2.Text.Substring(0, 2) == "14")
                    {
                        textBox_Time2.Text = "02" + textBox_Time2.Text.Remove(0, 2);
                    }
                    else if (textBox_Time2.Text.Substring(0, 2) == "15")
                    {
                        textBox_Time2.Text = "03" + textBox_Time2.Text.Remove(0, 2);
                    }
                    else if (textBox_Time2.Text.Substring(0, 2) == "16")
                    {
                        textBox_Time2.Text = "04" + textBox_Time2.Text.Remove(0, 2);
                    }
                    else if (textBox_Time2.Text.Substring(0, 2) == "17")
                    {
                        textBox_Time2.Text = "05" + textBox_Time2.Text.Remove(0, 2);
                    }
                    else if (textBox_Time2.Text.Substring(0, 2) == "18")
                    {
                        textBox_Time2.Text = "06" + textBox_Time2.Text.Remove(0, 2);
                    }
                    else if (textBox_Time2.Text.Substring(0, 2) == "19")
                    {
                        textBox_Time2.Text = "07" + textBox_Time2.Text.Remove(0, 2);
                    }
                    else if (textBox_Time2.Text.Substring(0, 2) == "20")
                    {
                        textBox_Time2.Text = "08" + textBox_Time2.Text.Remove(0, 2);
                    }
                    else if (textBox_Time2.Text.Substring(0, 2) == "21")
                    {
                        textBox_Time2.Text = "09" + textBox_Time2.Text.Remove(0, 2);
                    }
                    else if (textBox_Time2.Text.Substring(0, 2) == "22")
                    {
                        textBox_Time2.Text = "10" + textBox_Time2.Text.Remove(0, 2);
                    }
                    else if (textBox_Time2.Text.Substring(0, 2) == "23")
                    {
                        textBox_Time2.Text = "11" + textBox_Time2.Text.Remove(0, 2);
                    }
                    else if (textBox_Time2.Text.Substring(0, 2) == "00")
                    {
                        textBox_Time2.Text = "12" + textBox_Time2.Text.Remove(0, 2);
                    }
                }
            }
            catch
            {
            }
        }
        private void button_SrchUsrNo_Click(object sender, EventArgs e)
        {
            FrmSearch frm;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection;
            if (tp == 0)
            {
                columns_Names_visible.Clear();
                columns_Names_visible.Add("UsrNo", new ColumnDictinary("?????? ????????????????", "User No", ifDefault: true, ""));
                columns_Names_visible.Add("UsrNamA", new ColumnDictinary("?????????? ????????", "Arabic Name", ifDefault: true, ""));
                columns_Names_visible.Add("UsrNamE", new ColumnDictinary("?????????? ??????????????????", "English Name", ifDefault: true, ""));
                frm = new FrmSearch();
                frm.Tag = LangArEn;
                animalsAsCollection = columns_Names_visible;
                foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
                {
                    frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, ""));
                }
                VarGeneral.SFrmTyp = "T_User";
                frm.TopMost = true;
                frm.ShowDialog();
                if (frm.SerachNo != "")
                {
                    txtUserNo.Text = dbc.StockUser(frm.Serach_No).UsrNo;
                    if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                    {
                        txtUserName.Text = dbc.StockUser(frm.Serach_No).UsrNamA.ToString();
                    }
                    else
                    {
                        txtUserName.Text = dbc.StockUser(frm.Serach_No).UsrNamE.ToString();
                    }
                }
                else
                {
                    txtUserNo.Text = "";
                    txtUserName.Text = "";
                }
                return;
            }
            if (tp == 6 || tp == 9 || tp == 10 || tp == 13)
            {
                columns_Names_visible.Clear();
                columns_Names_visible.Add("perno", new ColumnDictinary("?????? ????????????", "Ghoust No", ifDefault: true, ""));
                columns_Names_visible.Add("nmA", new ColumnDictinary("?????????? ????????????", "Arabic Name", ifDefault: true, ""));
                columns_Names_visible.Add("nmE", new ColumnDictinary("?????????? ??????????????????", "English Name", ifDefault: true, ""));
                columns_Names_visible.Add("price", new ColumnDictinary("?????? ????????????", "Price", ifDefault: true, ""));
                columns_Names_visible.Add("day", new ColumnDictinary("???????????? ????????????????", "Days", ifDefault: true, ""));
                columns_Names_visible.Add("pasno", new ColumnDictinary("?????? ????????????", "ID No", ifDefault: true, ""));
                frm = new FrmSearch();
                frm.Tag = LangArEn;
                animalsAsCollection = columns_Names_visible;
                foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
                {
                    frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, ""));
                }
                if (tp == 9 || tp == 10)
                {
                    if (checkBox_Stay.Checked)
                    {
                        VarGeneral.SFrmTyp = "T_per";
                    }
                    else
                    {
                        VarGeneral.SFrmTyp = "T_per2";
                    }
                }
                else if (tp == 13 && comboBox_AdvancStatus.SelectedIndex == 1)
                {
                    VarGeneral.SFrmTyp = "T_per2";
                }
                else
                {
                    VarGeneral.SFrmTyp = "T_per";
                }
                frm.TopMost = true;
                frm.ShowDialog();
                if (frm.SerachNo != "")
                {
                    if (tp == 6)
                    {
                        txtUserNo.Text = db.StockPer(int.Parse(frm.Serach_No)).Cust_no;
                    }
                    else
                    {
                        txtUserNo.Text = frm.Serach_No;
                    }
                    if (string.IsNullOrEmpty(txtUserNo.Text))
                    {
                        txtUserNo.Text = "";
                        txtUserName.Text = "";
                    }
                    else if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                    {
                        txtUserName.Text = db.StockPer(int.Parse(frm.Serach_No)).nm;
                    }
                    else
                    {
                        txtUserName.Text = db.StockPer(int.Parse(frm.Serach_No)).nm;
                    }
                }
                else
                {
                    txtUserNo.Text = "";
                    txtUserName.Text = "";
                }
                return;
            }
            columns_Names_visible.Clear();
            columns_Names_visible.Add("romno", new ColumnDictinary("?????? ????????????", "Room No", ifDefault: true, ""));
            columns_Names_visible.Add("flore", new ColumnDictinary("????????????", "Floor", ifDefault: true, ""));
            columns_Names_visible.Add("state", new ColumnDictinary("???????? ????????????", "Room State", ifDefault: true, ""));
            columns_Names_visible.Add("nmA", new ColumnDictinary("?????????? ????????????", "Arabic Name", ifDefault: true, ""));
            columns_Names_visible.Add("nmE", new ColumnDictinary("?????????? ??????????????????", "English Name", ifDefault: false, ""));
            columns_Names_visible.Add("pri0", new ColumnDictinary("?????????? 1 - ????????", "Price 1 - Daily", ifDefault: true, ""));
            columns_Names_visible.Add("pri1", new ColumnDictinary("?????????? 2 - ????????", "Price 2 - Daily", ifDefault: false, ""));
            columns_Names_visible.Add("priM0", new ColumnDictinary("?????????? 1 - ????????", "Price 1 - Monthly", ifDefault: true, ""));
            columns_Names_visible.Add("priM1", new ColumnDictinary("?????????? 2 - ????????", "Price 2 - Monthly", ifDefault: false, ""));
            columns_Names_visible.Add("bedno", new ColumnDictinary("?????? ??????????????", "Beds Count", ifDefault: true, ""));
            columns_Names_visible.Add("wcno", new ColumnDictinary("?????? ????????????????", "TW Count", ifDefault: true, ""));
            columns_Names_visible.Add("ShortDsc", new ColumnDictinary("?????????? ??????????????", "Short Description", ifDefault: true, ""));
            frm = new FrmSearch();
            frm.Tag = LangArEn;
            animalsAsCollection = columns_Names_visible;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, ""));
            }
            VarGeneral.SFrmTyp = "T_Rom";
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != "")
            {
                txtUserNo.Text = frm.Serach_No.ToString();
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                {
                    txtUserName.Text = frm.Serach_No.ToString();
                }
                else
                {
                    txtUserName.Text = frm.Serach_No.ToString();
                }
            }
            else
            {
                txtUserNo.Text = "";
                txtUserName.Text = "";
            }
        }
        private void comboBox_AdvancStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (tp != 0 && tp != 1)
                {
                    txtUserNo.Text = "";
                    txtUserName.Text = "";
                }
                if (tp == 8 || tp == 12 || tp == 11)
                {
                    if (comboBox_AdvancStatus.SelectedIndex == 0)
                    {
                        tp = 12;
                    }
                    else if (comboBox_AdvancStatus.SelectedIndex == 1)
                    {
                        tp = 8;
                    }
                    else
                    {
                        tp = 11;
                    }
                    if (tp == 8 || tp == 12)
                    {
                        groupBox_Date.Text = ((LangArEn == 0) ? "?????? ?????????? ??????????" : "By Date");
                    }
                    else if (tp == 11)
                    {
                        groupBox_Date.Text = ((LangArEn == 0) ? "?????? ?????????? ????????????????" : "By Date");
                    }
                }
            }
            catch
            {
            }
        }
        private void checkBox_Stay_CheckedChanged(object sender, EventArgs e)
        {
            txtUserNo.Text = "";
            txtUserName.Text = "";
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InvAcc.Forms.FrmRepRevenue));
            ribbonBar1 = new DevComponents.DotNetBar.RibbonBar();
            panel1 = new System.Windows.Forms.Panel();
            txtUserName = new System.Windows.Forms.TextBox();
            txtUserNo = new System.Windows.Forms.TextBox();
            label9 = new System.Windows.Forms.Label();
            button_SrchUsrNo = new DevComponents.DotNetBar.ButtonX();
            comboBox_AdvancStatus = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            label2 = new System.Windows.Forms.Label();
            groupBox1 = new System.Windows.Forms.GroupBox();
            textBox_Time2 = new System.Windows.Forms.MaskedTextBox();
            textBox_Time = new System.Windows.Forms.MaskedTextBox();
            groupBox_AmPm = new System.Windows.Forms.GroupBox();
            RadioBox_AllowPM = new DevComponents.DotNetBar.Controls.CheckBoxX();
            checkBoxX1 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            RadioBox_AllowAM = new DevComponents.DotNetBar.Controls.CheckBoxX();
            label1 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            groupBox2 = new System.Windows.Forms.GroupBox();
            RadioBox_AllowPM2 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            checkBoxX3 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            RadioBox_AllowAM2 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            ButExit = new DevComponents.DotNetBar.ButtonX();
            ButOk = new DevComponents.DotNetBar.ButtonX();
            groupBox_Date = new System.Windows.Forms.GroupBox();
            dateTimeInput_StartAdvancTo = new System.Windows.Forms.MaskedTextBox();
            dateTimeInput_StartAdvancFrom = new System.Windows.Forms.MaskedTextBox();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            groupBox_9_10 = new System.Windows.Forms.GroupBox();
            checkBox_Leave = new DevComponents.DotNetBar.Controls.CheckBoxX();
            checkBox_Stay = new DevComponents.DotNetBar.Controls.CheckBoxX();
            ribbonBar1.SuspendLayout();
            panel1.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox_AmPm.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox_Date.SuspendLayout();
            groupBox_9_10.SuspendLayout();
            SuspendLayout();
            ribbonBar1.AccessibleDescription = null;
            ribbonBar1.AccessibleName = null;
            resources.ApplyResources(ribbonBar1, "ribbonBar1");
            ribbonBar1.AutoOverflowEnabled = true;
            ribbonBar1.BackgroundImage = null;
            ribbonBar1.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            ribbonBar1.BackgroundStyle.BackColor = System.Drawing.Color.AliceBlue;
            ribbonBar1.BackgroundStyle.BackColor2 = System.Drawing.SystemColors.GradientActiveCaption;
            ribbonBar1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            ribbonBar1.ContainerControlProcessDialogKey = true;
            ribbonBar1.Controls.Add(panel1);
            ribbonBar1.Font = null;
            ribbonBar1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            ribbonBar1.Name = "ribbonBar1";
            ribbonBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            ribbonBar1.TitleStyle.BackColor = System.Drawing.Color.FromArgb(227, 239, 255);
            ribbonBar1.TitleStyle.BackColor2 = System.Drawing.Color.FromArgb(101, 147, 207);
            ribbonBar1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            ribbonBar1.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            panel1.AccessibleDescription = null;
            panel1.AccessibleName = null;
            resources.ApplyResources(panel1, "panel1");
            panel1.BackColor = System.Drawing.Color.Transparent;
            panel1.BackgroundImage = null;
            panel1.Controls.Add(txtUserName);
            panel1.Controls.Add(txtUserNo);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(button_SrchUsrNo);
            panel1.Controls.Add(comboBox_AdvancStatus);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(groupBox1);
            panel1.Controls.Add(ButExit);
            panel1.Controls.Add(ButOk);
            panel1.Controls.Add(groupBox_Date);
            panel1.Controls.Add(groupBox_9_10);
            panel1.Font = null;
            panel1.Name = "panel1";
            txtUserName.AccessibleDescription = null;
            txtUserName.AccessibleName = null;
            resources.ApplyResources(txtUserName, "txtUserName");
            txtUserName.BackColor = System.Drawing.Color.DarkSeaGreen;
            txtUserName.BackgroundImage = null;
            txtUserName.Font = null;
            txtUserName.ForeColor = System.Drawing.Color.White;
            txtUserName.Name = "txtUserName";
            txtUserName.ReadOnly = true;
            txtUserNo.AccessibleDescription = null;
            txtUserNo.AccessibleName = null;
            resources.ApplyResources(txtUserNo, "txtUserNo");
            txtUserNo.BackColor = System.Drawing.Color.White;
            txtUserNo.BackgroundImage = null;
            txtUserNo.Font = null;
            txtUserNo.Name = "txtUserNo";
            txtUserNo.ReadOnly = true;
            txtUserNo.Tag = " T_GDHEAD.gdUser";
            label9.AccessibleDescription = null;
            label9.AccessibleName = null;
            resources.ApplyResources(label9, "label9");
            label9.BackColor = System.Drawing.Color.Transparent;
            label9.Name = "label9";
            button_SrchUsrNo.AccessibleDescription = null;
            button_SrchUsrNo.AccessibleName = null;
            button_SrchUsrNo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            resources.ApplyResources(button_SrchUsrNo, "button_SrchUsrNo");
            button_SrchUsrNo.BackgroundImage = null;
            button_SrchUsrNo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            button_SrchUsrNo.CommandParameter = null;
            button_SrchUsrNo.Font = null;
            button_SrchUsrNo.Name = "button_SrchUsrNo";
            button_SrchUsrNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            button_SrchUsrNo.Symbol = "\uf002";
            button_SrchUsrNo.SymbolSize = 12f;
            button_SrchUsrNo.TextColor = System.Drawing.Color.SteelBlue;
            button_SrchUsrNo.Click += new System.EventHandler(button_SrchUsrNo_Click);
            comboBox_AdvancStatus.AccessibleDescription = null;
            comboBox_AdvancStatus.AccessibleName = null;
            resources.ApplyResources(comboBox_AdvancStatus, "comboBox_AdvancStatus");
            comboBox_AdvancStatus.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            comboBox_AdvancStatus.BackgroundImage = null;
            comboBox_AdvancStatus.CommandParameter = null;
            comboBox_AdvancStatus.DisplayMember = "Text";
            comboBox_AdvancStatus.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            comboBox_AdvancStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox_AdvancStatus.Font = null;
            comboBox_AdvancStatus.FormattingEnabled = true;
            comboBox_AdvancStatus.Name = "comboBox_AdvancStatus";
            comboBox_AdvancStatus.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            comboBox_AdvancStatus.SelectedIndexChanged += new System.EventHandler(comboBox_AdvancStatus_SelectedIndexChanged);
            label2.AccessibleDescription = null;
            label2.AccessibleName = null;
            resources.ApplyResources(label2, "label2");
            label2.BackColor = System.Drawing.Color.Transparent;
            label2.Name = "label2";
            groupBox1.AccessibleDescription = null;
            groupBox1.AccessibleName = null;
            resources.ApplyResources(groupBox1, "groupBox1");
            groupBox1.BackColor = System.Drawing.Color.Transparent;
            groupBox1.BackgroundImage = null;
            groupBox1.Controls.Add(textBox_Time2);
            groupBox1.Controls.Add(textBox_Time);
            groupBox1.Controls.Add(groupBox_AmPm);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(groupBox2);
            groupBox1.Name = "groupBox1";
            groupBox1.TabStop = false;
            textBox_Time2.AccessibleDescription = null;
            textBox_Time2.AccessibleName = null;
            resources.ApplyResources(textBox_Time2, "textBox_Time2");
            textBox_Time2.BackColor = System.Drawing.Color.Maroon;
            textBox_Time2.BackgroundImage = null;
            textBox_Time2.ForeColor = System.Drawing.Color.White;
            textBox_Time2.Name = "textBox_Time2";
            textBox_Time2.Leave += new System.EventHandler(textBox_Time2_Leave);
            textBox_Time2.Click += new System.EventHandler(textBox_Time2_Click);
            textBox_Time.AccessibleDescription = null;
            textBox_Time.AccessibleName = null;
            resources.ApplyResources(textBox_Time, "textBox_Time");
            textBox_Time.BackColor = System.Drawing.Color.Maroon;
            textBox_Time.BackgroundImage = null;
            textBox_Time.ForeColor = System.Drawing.Color.White;
            textBox_Time.Name = "textBox_Time";
            textBox_Time.Leave += new System.EventHandler(textBox_Time_Leave);
            textBox_Time.Click += new System.EventHandler(textBox_Time_Click);
            groupBox_AmPm.AccessibleDescription = null;
            groupBox_AmPm.AccessibleName = null;
            resources.ApplyResources(groupBox_AmPm, "groupBox_AmPm");
            groupBox_AmPm.BackColor = System.Drawing.Color.Transparent;
            groupBox_AmPm.BackgroundImage = null;
            groupBox_AmPm.Controls.Add(RadioBox_AllowPM);
            groupBox_AmPm.Controls.Add(checkBoxX1);
            groupBox_AmPm.Controls.Add(RadioBox_AllowAM);
            groupBox_AmPm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            groupBox_AmPm.ForeColor = System.Drawing.Color.FromArgb(128, 64, 64);
            groupBox_AmPm.Name = "groupBox_AmPm";
            groupBox_AmPm.TabStop = false;
            RadioBox_AllowPM.AccessibleDescription = null;
            RadioBox_AllowPM.AccessibleName = null;
            resources.ApplyResources(RadioBox_AllowPM, "RadioBox_AllowPM");
            RadioBox_AllowPM.BackColor = System.Drawing.Color.Transparent;
            RadioBox_AllowPM.BackgroundImage = null;
            RadioBox_AllowPM.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            RadioBox_AllowPM.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            RadioBox_AllowPM.CheckSignSize = new System.Drawing.Size(14, 14);
            RadioBox_AllowPM.CommandParameter = null;
            RadioBox_AllowPM.Name = "RadioBox_AllowPM";
            RadioBox_AllowPM.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            checkBoxX1.AccessibleDescription = null;
            checkBoxX1.AccessibleName = null;
            resources.ApplyResources(checkBoxX1, "checkBoxX1");
            checkBoxX1.BackColor = System.Drawing.Color.Transparent;
            checkBoxX1.BackgroundImage = null;
            checkBoxX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            checkBoxX1.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            checkBoxX1.CheckSignSize = new System.Drawing.Size(14, 14);
            checkBoxX1.CommandParameter = null;
            checkBoxX1.Name = "checkBoxX1";
            checkBoxX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            RadioBox_AllowAM.AccessibleDescription = null;
            RadioBox_AllowAM.AccessibleName = null;
            resources.ApplyResources(RadioBox_AllowAM, "RadioBox_AllowAM");
            RadioBox_AllowAM.BackColor = System.Drawing.Color.Transparent;
            RadioBox_AllowAM.BackgroundImage = null;
            RadioBox_AllowAM.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            RadioBox_AllowAM.BackgroundStyle.TextShadowColor = System.Drawing.SystemColors.ControlLight;
            RadioBox_AllowAM.BackgroundStyle.TextShadowOffset = new System.Drawing.Point(3, 3);
            RadioBox_AllowAM.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            RadioBox_AllowAM.Checked = true;
            RadioBox_AllowAM.CheckSignSize = new System.Drawing.Size(14, 14);
            RadioBox_AllowAM.CheckState = System.Windows.Forms.CheckState.Checked;
            RadioBox_AllowAM.CheckValue = "Y";
            RadioBox_AllowAM.CommandParameter = null;
            RadioBox_AllowAM.Name = "RadioBox_AllowAM";
            RadioBox_AllowAM.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            label1.AccessibleDescription = null;
            label1.AccessibleName = null;
            resources.ApplyResources(label1, "label1");
            label1.BackColor = System.Drawing.Color.Transparent;
            label1.Name = "label1";
            label5.AccessibleDescription = null;
            label5.AccessibleName = null;
            resources.ApplyResources(label5, "label5");
            label5.BackColor = System.Drawing.Color.Transparent;
            label5.Name = "label5";
            groupBox2.AccessibleDescription = null;
            groupBox2.AccessibleName = null;
            resources.ApplyResources(groupBox2, "groupBox2");
            groupBox2.BackColor = System.Drawing.Color.Transparent;
            groupBox2.BackgroundImage = null;
            groupBox2.Controls.Add(RadioBox_AllowPM2);
            groupBox2.Controls.Add(checkBoxX3);
            groupBox2.Controls.Add(RadioBox_AllowAM2);
            groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            groupBox2.ForeColor = System.Drawing.Color.FromArgb(128, 64, 64);
            groupBox2.Name = "groupBox2";
            groupBox2.TabStop = false;
            RadioBox_AllowPM2.AccessibleDescription = null;
            RadioBox_AllowPM2.AccessibleName = null;
            resources.ApplyResources(RadioBox_AllowPM2, "RadioBox_AllowPM2");
            RadioBox_AllowPM2.BackColor = System.Drawing.Color.Transparent;
            RadioBox_AllowPM2.BackgroundImage = null;
            RadioBox_AllowPM2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            RadioBox_AllowPM2.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            RadioBox_AllowPM2.Checked = true;
            RadioBox_AllowPM2.CheckSignSize = new System.Drawing.Size(14, 14);
            RadioBox_AllowPM2.CheckState = System.Windows.Forms.CheckState.Checked;
            RadioBox_AllowPM2.CheckValue = "Y";
            RadioBox_AllowPM2.CommandParameter = null;
            RadioBox_AllowPM2.Name = "RadioBox_AllowPM2";
            RadioBox_AllowPM2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            checkBoxX3.AccessibleDescription = null;
            checkBoxX3.AccessibleName = null;
            resources.ApplyResources(checkBoxX3, "checkBoxX3");
            checkBoxX3.BackColor = System.Drawing.Color.Transparent;
            checkBoxX3.BackgroundImage = null;
            checkBoxX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            checkBoxX3.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            checkBoxX3.CheckSignSize = new System.Drawing.Size(14, 14);
            checkBoxX3.CommandParameter = null;
            checkBoxX3.Name = "checkBoxX3";
            checkBoxX3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            RadioBox_AllowAM2.AccessibleDescription = null;
            RadioBox_AllowAM2.AccessibleName = null;
            resources.ApplyResources(RadioBox_AllowAM2, "RadioBox_AllowAM2");
            RadioBox_AllowAM2.BackColor = System.Drawing.Color.Transparent;
            RadioBox_AllowAM2.BackgroundImage = null;
            RadioBox_AllowAM2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            RadioBox_AllowAM2.BackgroundStyle.TextShadowColor = System.Drawing.SystemColors.ControlLight;
            RadioBox_AllowAM2.BackgroundStyle.TextShadowOffset = new System.Drawing.Point(3, 3);
            RadioBox_AllowAM2.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            RadioBox_AllowAM2.CheckSignSize = new System.Drawing.Size(14, 14);
            RadioBox_AllowAM2.CommandParameter = null;
            RadioBox_AllowAM2.Name = "RadioBox_AllowAM2";
            RadioBox_AllowAM2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            ButExit.AccessibleDescription = null;
            ButExit.AccessibleName = null;
            ButExit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            resources.ApplyResources(ButExit, "ButExit");
            ButExit.BackgroundImage = null;
            ButExit.Checked = true;
            ButExit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            ButExit.CommandParameter = null;
            ButExit.Name = "ButExit";
            ButExit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            ButExit.Symbol = "\uf011";
            ButExit.SymbolSize = 16f;
            ButExit.TextColor = System.Drawing.Color.Black;
            ButExit.Click += new System.EventHandler(ButExit_Click);
            ButOk.AccessibleDescription = null;
            ButOk.AccessibleName = null;
            ButOk.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            resources.ApplyResources(ButOk, "ButOk");
            ButOk.BackgroundImage = null;
            ButOk.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            ButOk.CommandParameter = null;
            ButOk.Name = "ButOk";
            ButOk.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            ButOk.Symbol = "\uf0c5";
            ButOk.SymbolSize = 16f;
            ButOk.TextColor = System.Drawing.Color.White;
            ButOk.Click += new System.EventHandler(ButOk_Click);
            groupBox_Date.AccessibleDescription = null;
            groupBox_Date.AccessibleName = null;
            resources.ApplyResources(groupBox_Date, "groupBox_Date");
            groupBox_Date.BackColor = System.Drawing.Color.Transparent;
            groupBox_Date.BackgroundImage = null;
            groupBox_Date.Controls.Add(dateTimeInput_StartAdvancTo);
            groupBox_Date.Controls.Add(dateTimeInput_StartAdvancFrom);
            groupBox_Date.Controls.Add(label3);
            groupBox_Date.Controls.Add(label4);
            groupBox_Date.Name = "groupBox_Date";
            groupBox_Date.TabStop = false;
            dateTimeInput_StartAdvancTo.AccessibleDescription = null;
            dateTimeInput_StartAdvancTo.AccessibleName = null;
            resources.ApplyResources(dateTimeInput_StartAdvancTo, "dateTimeInput_StartAdvancTo");
            dateTimeInput_StartAdvancTo.BackgroundImage = null;
            dateTimeInput_StartAdvancTo.Font = null;
            dateTimeInput_StartAdvancTo.Name = "dateTimeInput_StartAdvancTo";
            dateTimeInput_StartAdvancTo.Leave += new System.EventHandler(dateTimeInput_StartAdvancTo_Leave);
            dateTimeInput_StartAdvancTo.Click += new System.EventHandler(dateTimeInput_StartAdvancTo_Click);
            dateTimeInput_StartAdvancFrom.AccessibleDescription = null;
            dateTimeInput_StartAdvancFrom.AccessibleName = null;
            resources.ApplyResources(dateTimeInput_StartAdvancFrom, "dateTimeInput_StartAdvancFrom");
            dateTimeInput_StartAdvancFrom.BackgroundImage = null;
            dateTimeInput_StartAdvancFrom.Font = null;
            dateTimeInput_StartAdvancFrom.Name = "dateTimeInput_StartAdvancFrom";
            dateTimeInput_StartAdvancFrom.Leave += new System.EventHandler(dateTimeInput_StartAdvancFrom_Leave);
            dateTimeInput_StartAdvancFrom.Click += new System.EventHandler(dateTimeInput_StartAdvancFrom_Click);
            label3.AccessibleDescription = null;
            label3.AccessibleName = null;
            resources.ApplyResources(label3, "label3");
            label3.BackColor = System.Drawing.Color.Transparent;
            label3.Name = "label3";
            label4.AccessibleDescription = null;
            label4.AccessibleName = null;
            resources.ApplyResources(label4, "label4");
            label4.BackColor = System.Drawing.Color.Transparent;
            label4.Name = "label4";
            groupBox_9_10.AccessibleDescription = null;
            groupBox_9_10.AccessibleName = null;
            resources.ApplyResources(groupBox_9_10, "groupBox_9_10");
            groupBox_9_10.BackColor = System.Drawing.Color.Transparent;
            groupBox_9_10.BackgroundImage = null;
            groupBox_9_10.Controls.Add(checkBox_Leave);
            groupBox_9_10.Controls.Add(checkBox_Stay);
            groupBox_9_10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            groupBox_9_10.ForeColor = System.Drawing.Color.FromArgb(128, 64, 64);
            groupBox_9_10.Name = "groupBox_9_10";
            groupBox_9_10.TabStop = false;
            checkBox_Leave.AccessibleDescription = null;
            checkBox_Leave.AccessibleName = null;
            resources.ApplyResources(checkBox_Leave, "checkBox_Leave");
            checkBox_Leave.BackColor = System.Drawing.Color.Transparent;
            checkBox_Leave.BackgroundImage = null;
            checkBox_Leave.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            checkBox_Leave.CheckBoxPosition = DevComponents.DotNetBar.eCheckBoxPosition.Top;
            checkBox_Leave.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            checkBox_Leave.CheckSignSize = new System.Drawing.Size(14, 14);
            checkBox_Leave.CommandParameter = null;
            checkBox_Leave.Name = "checkBox_Leave";
            checkBox_Leave.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            checkBox_Leave.TextColor = System.Drawing.Color.FromArgb(192, 0, 0);
            checkBox_Leave.CheckedChanged += new System.EventHandler(checkBox_Stay_CheckedChanged);
            checkBox_Stay.AccessibleDescription = null;
            checkBox_Stay.AccessibleName = null;
            resources.ApplyResources(checkBox_Stay, "checkBox_Stay");
            checkBox_Stay.BackColor = System.Drawing.Color.Transparent;
            checkBox_Stay.BackgroundImage = null;
            checkBox_Stay.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            checkBox_Stay.BackgroundStyle.TextShadowColor = System.Drawing.SystemColors.ControlLight;
            checkBox_Stay.BackgroundStyle.TextShadowOffset = new System.Drawing.Point(3, 3);
            checkBox_Stay.CheckBoxPosition = DevComponents.DotNetBar.eCheckBoxPosition.Top;
            checkBox_Stay.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            checkBox_Stay.Checked = true;
            checkBox_Stay.CheckSignSize = new System.Drawing.Size(14, 14);
            checkBox_Stay.CheckState = System.Windows.Forms.CheckState.Checked;
            checkBox_Stay.CheckValue = "Y";
            checkBox_Stay.CommandParameter = null;
            checkBox_Stay.Name = "checkBox_Stay";
            checkBox_Stay.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            checkBox_Stay.TextColor = System.Drawing.Color.FromArgb(192, 0, 0);
            checkBox_Stay.CheckedChanged += new System.EventHandler(checkBox_Stay_CheckedChanged);
            base.AccessibleDescription = null;
            base.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackgroundImage = null;
            base.Controls.Add(ribbonBar1);
            Font = null;
            base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            base.KeyPreview = true;
            base.MaximizeBox = false;
            base.Name = "FrmRepRevenue";
            base.Load += new System.EventHandler(FrmRepRevenue_Load);
            base.KeyPress += new System.Windows.Forms.KeyPressEventHandler(FrmRepRevenue_KeyPress);
            base.KeyDown += new System.Windows.Forms.KeyEventHandler(FrmRepRevenue_KeyDown);
            ribbonBar1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox_AmPm.ResumeLayout(false);
            groupBox_AmPm.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox_Date.ResumeLayout(false);
            groupBox_Date.PerformLayout();
            groupBox_9_10.ResumeLayout(false);
            groupBox_9_10.PerformLayout();
            ResumeLayout(false);
        }
    }
}
