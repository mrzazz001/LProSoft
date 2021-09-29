using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.Editors;
using InvAcc.GeneralM;
using InvAcc.Stock_Data;
using SSSDateTime.Date;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Linq;
using System.Linq;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial  class FrmGuestAddRoom : Form
    { void avs(int arln)

{ 
}
        private void langloads(object sender, EventArgs e)
        {
             avs(GeneralM.VarGeneral.currentintlanguage);
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
        private T_AccDef _AccDefBind = new T_AccDef();
        private int LangArEn = 0;
        protected bool ifOkDelete;
        public bool CanEdit = true;
        protected bool CanInsert = true;
#pragma warning disable CS0414 // The field 'FrmGuestAddRoom.FlagUpdate' is assigned but its value is never used
        private string FlagUpdate = "";
#pragma warning restore CS0414 // The field 'FrmGuestAddRoom.FlagUpdate' is assigned but its value is never used
        public ViewState ViewState = ViewState.Deiles;
        private FormState statex;
        public List<Control> controls;
        public Control codeControl = new Control();
        private bool canUpdate = true;
        private List<string> pkeys = new List<string>();
        private Stock_DataDataContext dbInstance;
#pragma warning disable CS0414 // The field 'FrmGuestAddRoom.Days_' is assigned but its value is never used
        private int Days_ = 1;
#pragma warning restore CS0414 // The field 'FrmGuestAddRoom.Days_' is assigned but its value is never used
        private Rate_DataDataContext dbInstanceRate;
        private string CuNo;
        private string CDat;
        private int CDat2;
        private int a1;
        private int a3;
        private int a4;
        private int a5;
#pragma warning disable CS0169 // The field 'FrmGuestAddRoom.a6' is never used
        private string a6;
#pragma warning restore CS0169 // The field 'FrmGuestAddRoom.a6' is never used
#pragma warning disable CS0169 // The field 'FrmGuestAddRoom.a7' is never used
        private string a7;
#pragma warning restore CS0169 // The field 'FrmGuestAddRoom.a7' is never used
        private double a2;
       // private IContainer components = null;
        private Timer timer1;
        private PanelEx panelEx2;
        private RibbonBar ribbonBar1;
        private System.Windows.Forms. SaveFileDialog saveFileDialog1;
        private Timer timerInfoBallon;
        private System.Windows.Forms.OpenFileDialog  openFileDialog1;
        private Panel panel1;
        private DockSite barTopDockSite;
        private DockSite barBottomDockSite;
        public DotNetBarManager dotNetBarManager1;
        private ImageList imageList1;
        private DockSite barLeftDockSite;
        private DockSite barRightDockSite;
        private DockSite dockSite4;
        private DockSite dockSite1;
        private DockSite dockSite2;
        private DockSite dockSite3;
        protected ContextMenuStrip contextMenuStrip1;
        protected ToolStripMenuItem ToolStripMenuItem_Rep;
        protected ToolStripMenuItem ToolStripMenuItem_Det;
        protected ContextMenuStrip contextMenuStrip2;
        private RibbonBar ribbonBar_Tasks;
        private SuperTabControl superTabControl_Main1;
        protected ButtonItem Button_Close;
        protected ButtonItem Button_Save;
        private Panel panel2;
        internal Label label13z;
        private TextBox txtRoom;
        protected TextBox textBox_ID;
        protected Label label38;
        protected Label label36;
        protected TextBox txtName;
        private DoubleInput textBox_RoomPrice;
        private Label label1;
        private Label label8;
        private ComboBoxEx comboBox_Rooms;
        internal Label label5;
        private ComboBoxEx comboBox_RoomTyp;
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
        public bool IfSave
        {
            set
            {
                Button_Save.Visible = value;
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
        private void Button_Close_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void textBox_ID_Click(object sender, EventArgs e)
        {
            textBox_ID.SelectAll();
        }
        private void textBox_NameA_Enter(object sender, EventArgs e)
        {
            Framework.Keyboard.Language.Switch("Arabic");
        }
        private void textBox_NameE_Enter(object sender, EventArgs e)
        {
            Framework.Keyboard.Language.Switch("English");
        }
        private void Frm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                SendKeys.Send("{Tab}");
            }
        }
        private void Frm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2 && Button_Save.Enabled && Button_Save.Visible && State != 0)
            {
                Button_Save_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
        public FrmGuestAddRoom()
        {
            InitializeComponent();this.Load += langloads;
        }
        private void RibunButtons()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                Button_Close.Text = "اغلاق";
                Button_Save.Text = "حفظ";
                Button_Close.Tooltip = "Esc";
                Button_Save.Tooltip = "F2";
                Text = "إضافة ملحق";
            }
            else
            {
                Button_Close.Text = "Close";
                Button_Save.Text = "Save";
                Button_Close.Tooltip = "Esc";
                Button_Save.Tooltip = "F2";
                Text = "Add extension";
            }
        }
        private void FrmGuestAddRoom_Load(object sender, EventArgs e)
        {
            try
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmGuestAddRoom));
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                {
                    SSSLanguage.Language.ChangeLanguage("ar-SA", this, resources);
                    LangArEn = 0;
                }
                else
                {
                    SSSLanguage.Language.ChangeLanguage("en", this, resources);
                    LangArEn = 1;
                }
                RibunButtons();
                VarGeneral.ChkAddRoom = 0;
                SetData();
                base.ActiveControl = comboBox_Rooms;
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Load:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void FreeRom()
        {
            List<T_Rom> listRoms = new List<T_Rom>(db.T_Roms.Where((T_Rom item) => item.state == (int?)1).ToList());
            comboBox_Rooms.DataSource = listRoms;
            comboBox_Rooms.DisplayMember = "romno";
            comboBox_Rooms.ValueMember = "romno";
            comboBox_Rooms.SelectedIndex = 0;
            comboBox_RoomTyp.Items.Clear();
            comboBox_RoomTyp.Items.Add((LangArEn == 0) ? "يومي" : "Daily");
            comboBox_RoomTyp.Items.Add((LangArEn == 0) ? "شهري" : "Monthly");
            comboBox_RoomTyp.SelectedIndex = 0;
        }
        public void SetData()
        {
            try
            {
                FreeRom();
                T_per q = db.StockPer(VarGeneral._hotelper);
                textBox_ID.Text = VarGeneral._hotelper.ToString();
                txtRoom.Text = VarGeneral._hotelrom.ToString();
                txtName.Text = q.nm;
                CuNo = q.Cust_no;
                if (db.StockRoom(q.romno.Value).typ.Value == 0)
                {
                    label13z.Text = ((LangArEn == 0) ? "الغرفة الحالية :" : "Room :");
                    label5.Text = ((LangArEn == 0) ? "الغرفة المضافة :" : "Room New :");
                }
                else if (db.StockRoom(q.romno.Value).typ.Value == 1)
                {
                    label13z.Text = ((LangArEn == 0) ? "الجناح الحالي :" : "suite :");
                    label5.Text = ((LangArEn == 0) ? "الجنـاح المضاف :" : "suite New :");
                }
                else if (db.StockRoom(q.romno.Value).typ.Value == 2)
                {
                    label13z.Text = ((LangArEn == 0) ? "الفيلا الحالية :" : "villa :");
                    label5.Text = ((LangArEn == 0) ? "الفيلا المضافة :" : "villa New :");
                }
                else if (db.StockRoom(q.romno.Value).typ.Value == 3)
                {
                    label13z.Text = ((LangArEn == 0) ? "الشقة الحالية :" : "apartment :");
                    label5.Text = ((LangArEn == 0) ? "الشقة المضافة :" : "apartment New :");
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("SetData:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void CDatt()
        {
            CDat2 = 1;
            int? calendr = VarGeneral.Settings_Sys.Calendr;
            CDat = Convert.ToDateTime((calendr.Value == 0 && calendr.HasValue) ? n.FormatGreg(VarGeneral.Gdate, "yyyy/MM/dd") : n.FormatHijri(VarGeneral.Hdate, "yyyy/MM/dd")).AddDays(CDat2).ToString("yyyy/MM/dd");
        }
        private void Button_Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(textBox_ID.Text) || string.IsNullOrEmpty(txtRoom.Text) || string.IsNullOrEmpty(comboBox_Rooms.Text))
                {
                    MessageBox.Show((LangArEn == 0) ? "هناك خطآ في بيانات الغرفة الحالية" : "There are errors in the current room data", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                CDatt();
                Stock_DataDataContext db = this.db;
                object[] array = new object[21]
                {
                    "SELECT T_Reserv.ResrvNo, T_Reserv.Dat, T_Reserv.Rom, T_Reserv.Sts, T_Reserv.PerNm, T_Reserv.IdNo, T_Reserv.Nat , T_Reserv.Dat2 FROM T_Reserv where T_Reserv.Rom = ",
                    int.Parse(comboBox_Rooms.SelectedValue.ToString()),
                    " and T_Reserv.sts=0 and ((T_Reserv.Dat < '",
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null
                };
                object[] array2 = array;
                int? calendr = VarGeneral.Settings_Sys.Calendr;
                array2[3] = ((calendr.Value == 0 && calendr.HasValue) ? n.FormatGreg(VarGeneral.Gdate, "yyyy/MM/dd") : n.FormatHijri(VarGeneral.Hdate, "yyyy/MM/dd"));
                array[4] = "' and T_Reserv.Dat >= '";
                array[5] = CDat;
                array[6] = "') or (T_Reserv.Dat2 > '";
                object[] array3 = array;
                calendr = VarGeneral.Settings_Sys.Calendr;
                array3[7] = ((calendr.Value == 0 && calendr.HasValue) ? n.FormatGreg(VarGeneral.Gdate, "yyyy/MM/dd") : n.FormatHijri(VarGeneral.Hdate, "yyyy/MM/dd"));
                array[8] = "' and T_Reserv.Dat2 < '";
                array[9] = CDat;
                array[10] = "') or (  '";
                array[11] = CDat;
                array[12] = "' <= T_Reserv.Dat2 and '";
                object[] array4 = array;
                calendr = VarGeneral.Settings_Sys.Calendr;
                array4[13] = ((calendr.Value == 0 && calendr.HasValue) ? n.FormatGreg(VarGeneral.Gdate, "yyyy/MM/dd") : n.FormatHijri(VarGeneral.Hdate, "yyyy/MM/dd"));
                array[14] = "' >= T_Reserv.Dat)) or ((T_Reserv.Dat < '";
                array[15] = CDat;
                array[16] = "' and T_Reserv.Dat > '";
                object[] array5 = array;
                calendr = VarGeneral.Settings_Sys.Calendr;
                array5[17] = ((calendr.Value == 0 && calendr.HasValue) ? n.FormatGreg(VarGeneral.Gdate, "yyyy/MM/dd") : n.FormatHijri(VarGeneral.Hdate, "yyyy/MM/dd"));
                array[18] = "' ) and T_Reserv.Rom = ";
                array[19] = int.Parse(comboBox_Rooms.SelectedValue.ToString());
                array[20] = " )";
                List<T_Reserv> _ReservChk = db.ExecuteQuery<T_Reserv>(string.Concat(array), new object[0]).ToList();
                if (_ReservChk.Count > 0)
                {
                    MessageBox.Show(" لايمكن اتمام العملية  لان الغرفة محجوزة في هذه الفترة ", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                int max = this.db.MaxPerNo;
                T_Rom _rom = this.db.StockRoom(VarGeneral._hotelrom);
                a1 = _rom.hed.Value;
                a2 = textBox_RoomPrice.Value;
                a3 = _rom.tax.Value;
                a4 = _rom.ser.Value;
                a5 = _rom.gropno.Value;
                _rom.gropno = VarGeneral._hotelper;
                this.db.Log = VarGeneral.DebugLog;
                this.db.SubmitChanges(ConflictMode.ContinueOnConflict);
                T_Rom _rom2 = this.db.StockRoom(int.Parse(comboBox_Rooms.SelectedValue.ToString()));
                _rom2.state = 3;
                _rom2.hed = 0;
                _rom2.gropno = VarGeneral._hotelper;
                _rom2.price = textBox_RoomPrice.Value;
                _rom2.tax = a3;
                _rom2.ser = a4;
                calendr = VarGeneral.Settings_Sys.Calendr;
                _rom2.dt = ((calendr.Value == 0 && calendr.HasValue) ? n.FormatGreg(VarGeneral.Gdate, "yyyy/MM/dd") : n.FormatHijri(VarGeneral.Hdate, "yyyy/MM/dd"));
                _rom2.tm = DateTime.Now.ToString("hh:mm:ss tt");
                this.db.Log = VarGeneral.DebugLog;
                this.db.SubmitChanges(ConflictMode.ContinueOnConflict);
                T_per _per_data = this.db.StockPer(VarGeneral._hotelper);
                _per_data.gropno = VarGeneral._hotelper;
                this.db.Log = VarGeneral.DebugLog;
                this.db.SubmitChanges(ConflictMode.ContinueOnConflict);
                using (Stock_DataDataContext _Db = new Stock_DataDataContext(VarGeneral.BranchCS))
                {
                    T_per data_this = new T_per();
                    data_this.romno = int.Parse(comboBox_Rooms.SelectedValue.ToString());
                    data_this.perno = max;
                    data_this.day = "1";
                    data_this.nm = txtName.Text;
                    data_this.bdt = _per_data.bdt;
                    data_this.bpls = _per_data.bpls;
                    data_this.pasno = _per_data.pasno;
                    data_this.paspls = _per_data.paspls;
                    data_this.passt = _per_data.passt;
                    data_this.pasend = _per_data.pasend;
                    data_this.enddt = _per_data.enddt;
                    data_this.jobpls = _per_data.jobpls;
                    if (_per_data.vip.HasValue)
                    {
                        data_this.vip = _per_data.vip;
                    }
                    else
                    {
                        data_this.vip = null;
                    }
                    data_this.ser = _per_data.ser.Value;
                    data_this.tax = _per_data.tax.Value;
                    data_this.DayImport = _per_data.DayImport.Value;
                    data_this.price = textBox_RoomPrice.Value;
                    data_this.ch = 2;
                    data_this.Cust_no = _per_data.Cust_no;
                    data_this.nath = _per_data.nath;
                    if (_per_data.pastyp.HasValue)
                    {
                        data_this.pastyp = _per_data.pastyp;
                    }
                    else
                    {
                        data_this.pastyp = null;
                    }
                    if (_per_data.job.HasValue)
                    {
                        data_this.job = _per_data.job;
                    }
                    else
                    {
                        data_this.job = null;
                    }
                    data_this.curr = _per_data.curr;
                    data_this.disknd = _per_data.disknd.Value;
                    data_this.distyp = _per_data.distyp.Value;
                    data_this.cc = _per_data.cc.Value;
                    calendr = VarGeneral.Settings_Sys.Calendr;
                    data_this.dt2 = ((calendr.Value == 0 && calendr.HasValue) ? n.FormatGreg(VarGeneral.Gdate, "yyyy/MM/dd") : n.FormatHijri(VarGeneral.Hdate, "yyyy/MM/dd"));
                    data_this.tm1 = DateTime.Now.ToString("hh:mm:ss");
                    if (DateTime.Now.ToString("hh:mm:ss tt").ToString().ToUpper()
                        .Contains("AM"))
                    {
                        data_this.vAmPm = "AM";
                    }
                    else
                    {
                        data_this.vAmPm = "PM";
                    }
                    data_this.gropno = VarGeneral._hotelper;
                    data_this.DayImport = ((comboBox_RoomTyp.SelectedIndex == 0) ? 1 : VarGeneral.Settings_Sys.DayOfM.Value);
                    calendr = VarGeneral.Settings_Sys.Calendr;
                    data_this.dt4 = ((calendr.Value == 0 && calendr.HasValue) ? Convert.ToDateTime(VarGeneral.Gdate).AddDays(data_this.DayImport.Value).ToString("yyyy/MM/dd") : Convert.ToDateTime(VarGeneral.Hdate).AddDays(data_this.DayImport.Value).ToString("yyyy/MM/dd"));
                    data_this.KindPer = comboBox_RoomTyp.SelectedIndex;
                    data_this.dis = 0.0;
                    data_this.ps1 = VarGeneral.UserNo;
                    _Db.T_pers.InsertOnSubmit(data_this);
                    _Db.SubmitChanges();
                    _Db.ExecuteCommand("UPDATE [dbo].[T_Rom] SET [perno] = " + max + " WHERE [romno] =" + int.Parse(comboBox_Rooms.SelectedValue.ToString()));
                    T_romtrn dataThis_RomTrn = new T_romtrn();
                    dataThis_RomTrn.ID = this.db.MaxRomTrnNo;
                    dataThis_RomTrn.romno1 = int.Parse(comboBox_Rooms.SelectedValue.ToString());
                    dataThis_RomTrn.romno2 = null;
                    dataThis_RomTrn.perno = max;
                    calendr = VarGeneral.Settings_Sys.Calendr;
                    dataThis_RomTrn.dt = ((calendr.Value == 0 && calendr.HasValue) ? VarGeneral.Gdate : VarGeneral.Hdate);
                    dataThis_RomTrn.tm = DateTime.Now.ToString("hh:mm:ss tt");
                    dataThis_RomTrn.Usr = VarGeneral.UserNumber;
                    dataThis_RomTrn.typ = 2;
                    dataThis_RomTrn.UsrNam = ((LangArEn == 0) ? VarGeneral.UserNameA : VarGeneral.UserNameE);
                    _Db.T_romtrns.InsertOnSubmit(dataThis_RomTrn);
                    _Db.SubmitChanges();
                }
                MessageBox.Show((LangArEn == 0) ? "لقد تم اتمام عمليةإضافة الملحق بنجاح .." : "This Opration Is Done", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                VarGeneral.ChkAddRoom = 1;
                Close();
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Save:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void comboBox_Rooms_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                T_Rom Q = db.StockRoom(int.Parse(comboBox_Rooms.SelectedValue.ToString()));
                textBox_RoomPrice.Value = ((comboBox_RoomTyp.SelectedIndex != 0) ? ((dbc.Get_PermissionID(VarGeneral.UserID).RepAcc6 == "0") ? Q.priM0.Value : Q.priM1.Value) : ((dbc.Get_PermissionID(VarGeneral.UserID).RepAcc5 == "0") ? Q.pri0.Value : Q.pri1.Value));
            }
            catch
            {
            }
        }
        private void comboBox_RoomTyp_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox_Rooms_SelectedValueChanged(sender, e);
        }
    }
}
