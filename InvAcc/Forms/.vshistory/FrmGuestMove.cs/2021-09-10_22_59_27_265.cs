using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.Editors;
using Framework.Data;
using InvAcc.GeneralM;
using InvAcc.Stock_Data;
using SSSDateTime.Date;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Linq;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial  class FrmGuestMove : Form
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
        private DoubleInput textBox_RoomPrice2;
        private Label label1;
        private DoubleInput textBox_RoomPrice;
        private Label label8;
        private ComboBoxEx comboBox_Rooms;
        internal Label label5;
        public Dictionary<string, ColumnDictinary> columns_Names_visible = new Dictionary<string, ColumnDictinary>();
        private HijriGreg.HijriGregDates n = new HijriGreg.HijriGregDates();
        private T_AccDef _AccDefBind = new T_AccDef();
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
        private List<string> pkeys = new List<string>();
        private Stock_DataDataContext dbInstance;
        private int Days_ = 1;
        private double tot = 0.0;
        private Rate_DataDataContext dbInstanceRate;
        private string CuNo;
        private int RomDay;
        private string CDat;
        private int CDat2;
        private int a1;
        private int a3;
        private int a4;
        private int a5;
        private string a6;
        private string a7;
        private double a2;
        private T_per c = new T_per();
        private T_GDHEAD _GdHead = new T_GDHEAD();
        private ScriptNumber ScriptNumber1 = new ScriptNumber();
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
        public FrmGuestMove(double _tot, int _Days)
        {
            InitializeComponent();this.Load += langloads;
            tot = _tot;
            Days_ = _Days;
        }
        private void RibunButtons()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                Button_Close.Text = "اغلاق";
                Button_Save.Text = "حفظ";
                Button_Close.Tooltip = "Esc";
                Button_Save.Tooltip = "F2";
                Text = "نقل نزيل";
            }
            else
            {
                Button_Close.Text = "Close";
                Button_Save.Text = "Save";
                Button_Close.Tooltip = "Esc";
                Button_Save.Tooltip = "F2";
                Text = "Guest Move";
            }
        }
        private void FrmGuestMove_Load(object sender, EventArgs e)
        {
            try
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmGuestMove));
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
                VarGeneral.ChkMove = 0;
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
                textBox_RoomPrice.Value = q.price.Value;
                CuNo = q.Cust_no;
                RomDay = VarGeneral.Dy(q.dt2, q.tm1 + " " + q.vAmPm);
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
            CDat2 = c.DayImport.Value;
            CDat = Convert.ToDateTime(db.StockRoom(c.romno.Value).dt).AddDays(CDat2).ToString("yyyy/MM/dd");
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
                c = new T_per();
                c = db.StockPer(VarGeneral._hotelper);
                CDatt();
                List<T_Reserv> _ReservChk = db.ExecuteQuery<T_Reserv>("SELECT T_Reserv.ResrvNo, T_Reserv.Dat, T_Reserv.Rom, T_Reserv.Sts, T_Reserv.PerNm, T_Reserv.IdNo, T_Reserv.Nat , T_Reserv.Dat2 FROM T_Reserv where T_Reserv.Rom = " + int.Parse(comboBox_Rooms.SelectedValue.ToString()) + " and T_Reserv.sts=0 and ((T_Reserv.Dat < '" + db.StockRoom(c.romno.Value).dt + "' and T_Reserv.Dat >= '" + CDat + "') or (T_Reserv.Dat2 > '" + db.StockRoom(c.romno.Value).dt + "' and T_Reserv.Dat2 < '" + CDat + "') or (  '" + CDat + "' <= T_Reserv.Dat2 and '" + db.StockRoom(c.romno.Value).dt + "' >= T_Reserv.Dat)) or ((T_Reserv.Dat < '" + CDat + "' and T_Reserv.Dat > '" + db.StockRoom(c.romno.Value).dt + "' ) and T_Reserv.Rom = " + int.Parse(comboBox_Rooms.SelectedValue.ToString()) + " )", new object[0]).ToList();
                if (_ReservChk.Count > 0)
                {
                    MessageBox.Show(" لايمكن اتمام العملية  لان الغرفة محجوزة في هذه الفترة ", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                T_Rom _rom;
                int? calendr;
                if (textBox_RoomPrice.Value == textBox_RoomPrice2.Value || Days_ == 1)
                {
                    _rom = db.StockRoom(VarGeneral._hotelrom);
                    a1 = _rom.hed.Value;
                    a2 = textBox_RoomPrice2.Value;
                    a3 = _rom.tax.Value;
                    a4 = _rom.ser.Value;
                    a5 = _rom.gropno.Value;
                    a6 = _rom.dt;
                    a7 = _rom.tm;
                    _rom.state = 1;
                    _rom.perno = null;
                    _rom.hed = 0;
                    _rom.price = 0.0;
                    _rom.tax = 0;
                    _rom.ser = 0;
                    _rom.gropno = 0;
                    _rom.dt = "";
                    _rom.tm = "";
                    db.Log = VarGeneral.DebugLog;
                    db.SubmitChanges(ConflictMode.ContinueOnConflict);
                    _rom = new T_Rom();
                    _rom = db.StockRoom(int.Parse(comboBox_Rooms.SelectedValue.ToString()));
                    _rom.state = 3;
                    _rom.perno = int.Parse(textBox_ID.Text);
                    _rom.hed = a1;
                    if (textBox_RoomPrice.Value > textBox_RoomPrice2.Value)
                    {
                        _rom.price = textBox_RoomPrice.Value;
                    }
                    else
                    {
                        _rom.price = a2;
                    }
                    _rom.tax = a3;
                    _rom.ser = a4;
                    _rom.gropno = a5;
                    _rom.dt = a6;
                    _rom.tm = a7;
                    db.Log = VarGeneral.DebugLog;
                    db.SubmitChanges(ConflictMode.ContinueOnConflict);
                    using (Stock_DataDataContext _Db = new Stock_DataDataContext(VarGeneral.BranchCS))
                    {
                        T_per _per = _Db.StockPer(VarGeneral._hotelper);
                        _per.romno = int.Parse(comboBox_Rooms.SelectedValue.ToString());
                        if (textBox_RoomPrice.Value > textBox_RoomPrice2.Value)
                        {
                            _per.price = textBox_RoomPrice.Value;
                        }
                        else
                        {
                            _per.price = textBox_RoomPrice2.Value;
                        }
                        _Db.Log = VarGeneral.DebugLog;
                        _Db.SubmitChanges(ConflictMode.ContinueOnConflict);
                        T_romtrn dataThis_RomTrn = new T_romtrn();
                        dataThis_RomTrn.ID = db.MaxRomTrnNo;
                        dataThis_RomTrn.romno1 = int.Parse(txtRoom.Text);
                        dataThis_RomTrn.romno2 = int.Parse(comboBox_Rooms.SelectedValue.ToString());
                        dataThis_RomTrn.perno = VarGeneral._hotelper;
                        T_romtrn t_romtrn = dataThis_RomTrn;
                        calendr = VarGeneral.Settings_Sys.Calendr;
                        t_romtrn.dt = ((calendr.Value == 0 && calendr.HasValue) ? VarGeneral.Gdate : VarGeneral.Hdate);
                        dataThis_RomTrn.tm = DateTime.Now.ToString("hh:mm:ss tt");
                        dataThis_RomTrn.Usr = VarGeneral.UserNumber;
                        dataThis_RomTrn.typ = 6;
                        dataThis_RomTrn.UsrNam = ((LangArEn == 0) ? VarGeneral.UserNameA : VarGeneral.UserNameE);
                        _Db.T_romtrns.InsertOnSubmit(dataThis_RomTrn);
                        _Db.SubmitChanges();
                    }
                    MessageBox.Show((LangArEn == 0) ? "لقد تم اتمام عملية النقل بنجاح .." : "This Opration Is Done", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    VarGeneral.ChkMove = 1;
                    Close();
                    return;
                }
                _rom = db.StockRoom(VarGeneral._hotelrom);
                a1 = _rom.hed.Value;
                a2 = textBox_RoomPrice2.Value;
                a3 = _rom.tax.Value;
                a4 = _rom.ser.Value;
                a5 = _rom.gropno.Value;
                calendr = VarGeneral.Settings_Sys.Calendr;
                a6 = ((calendr.Value == 0 && calendr.HasValue) ? n.FormatGreg(VarGeneral.Gdate, "yyyy/MM/dd") : n.FormatHijri(VarGeneral.Hdate, "yyyy/MM/dd"));
                a7 = DateTime.Now.ToString("hh:mm:ss tt");
                _rom.state = 1;
                _rom.perno = null;
                _rom.hed = 0;
                _rom.price = 0.0;
                _rom.tax = 0;
                _rom.ser = 0;
                _rom.gropno = 0;
                _rom.dt = "";
                _rom.tm = "";
                db.Log = VarGeneral.DebugLog;
                db.SubmitChanges(ConflictMode.ContinueOnConflict);
                _rom = new T_Rom();
                _rom = db.StockRoom(int.Parse(comboBox_Rooms.SelectedValue.ToString()));
                _rom.state = 3;
                _rom.perno = int.Parse(textBox_ID.Text);
                _rom.hed = a1;
                _rom.price = a2;
                _rom.tax = a3;
                _rom.ser = a4;
                _rom.gropno = a5;
                _rom.dt = a6;
                _rom.tm = a7;
                db.Log = VarGeneral.DebugLog;
                db.SubmitChanges(ConflictMode.ContinueOnConflict);
                _rom = new T_Rom();
                _rom = db.StockRoom(int.Parse(comboBox_Rooms.SelectedValue.ToString()));
                _rom.state = 3;
                _rom.perno = int.Parse(textBox_ID.Text);
                _rom.hed = a1;
                if (textBox_RoomPrice.Value > textBox_RoomPrice2.Value)
                {
                    _rom.price = textBox_RoomPrice.Value;
                }
                else
                {
                    _rom.price = a2;
                }
                _rom.tax = a3;
                _rom.ser = a4;
                _rom.gropno = a5;
                _rom.dt = a6;
                _rom.tm = a7;
                db.Log = VarGeneral.DebugLog;
                db.SubmitChanges(ConflictMode.ContinueOnConflict);
                using (Stock_DataDataContext _Db = new Stock_DataDataContext(VarGeneral.BranchCS))
                {
                    T_per _per = _Db.StockPer(VarGeneral._hotelper);
                    _per.ps1 = VarGeneral.UserNo;
                    _per.price = a2;
                    _per.romno = int.Parse(comboBox_Rooms.SelectedValue.ToString());
                    _per.tm1 = a7.Replace(" AM", "").Replace(" PM", "");
                    if (Convert.ToDateTime(a7).ToString("hh:mm:ss tt").ToString()
                        .ToUpper()
                        .Contains("AM"))
                    {
                        _per.vAmPm = "AM";
                    }
                    else
                    {
                        _per.vAmPm = "PM";
                    }
                    _per.dt2 = a6;
                    _Db.Log = VarGeneral.DebugLog;
                    _Db.SubmitChanges(ConflictMode.ContinueOnConflict);
                    T_romtrn dataThis_RomTrn = new T_romtrn();
                    dataThis_RomTrn.ID = db.MaxRomTrnNo;
                    dataThis_RomTrn.romno1 = int.Parse(txtRoom.Text);
                    dataThis_RomTrn.romno2 = int.Parse(comboBox_Rooms.SelectedValue.ToString());
                    dataThis_RomTrn.perno = VarGeneral._hotelper;
                    T_romtrn t_romtrn2 = dataThis_RomTrn;
                    calendr = VarGeneral.Settings_Sys.Calendr;
                    t_romtrn2.dt = ((calendr.Value == 0 && calendr.HasValue) ? VarGeneral.Gdate : VarGeneral.Hdate);
                    dataThis_RomTrn.tm = DateTime.Now.ToString("hh:mm:ss tt");
                    dataThis_RomTrn.Usr = VarGeneral.UserNumber;
                    dataThis_RomTrn.typ = 6;
                    dataThis_RomTrn.UsrNam = ((LangArEn == 0) ? VarGeneral.UserNameA : VarGeneral.UserNameE);
                    _Db.T_romtrns.InsertOnSubmit(dataThis_RomTrn);
                    _Db.SubmitChanges();
                    T_tran data_this = new T_tran();
                    data_this.perno = int.Parse(textBox_ID.Text);
                    data_this.romno = int.Parse(comboBox_Rooms.SelectedValue.ToString());
                    data_this.fat = db.MaxTranNo;
                    data_this.price = tot;
                    data_this.typ = 1;
                    data_this.detal = "أقامة " + Days_ + " يوم/أيام في غرفة رقم " + txtRoom.Text;
                    calendr = VarGeneral.Settings_Sys.Calendr;
                    data_this.dt = ((calendr.Value == 0 && calendr.HasValue) ? n.FormatGreg(VarGeneral.Gdate, "yyyy/MM/dd") : n.FormatHijri(VarGeneral.Hdate, "yyyy/MM/dd"));
                    data_this.tm = DateTime.Now.ToString("hh:mm:ss tt");
                    data_this.Usr = VarGeneral.UserNo;
                    int maxGd = 1;
                    if (!VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 46) && data_this.price.Value > 0.0)
                    {
                        try
                        {
                            string AccCrdt = "";
                            string AccDbt = "";
                            if (data_this.price.Value > 0.0)
                            {
                                try
                                {
                                    AccCrdt = db.StockServTypeID(1).accno;
                                }
                                catch
                                {
                                    AccCrdt = "";
                                }
                                try
                                {
                                    AccDbt = db.StockPer(int.Parse(textBox_ID.Text)).Cust_no;
                                }
                                catch
                                {
                                    AccDbt = "";
                                }
                            }
                            if (AccCrdt == "" && data_this.price.Value > 0.0)
                            {
                                MessageBox.Show((LangArEn == 0) ? "لا يمكن إتمام العملية .. تأكد من صحة الطرف الدائن للقيد .. " : "You can not complete the operation .. Make sure the creditor under the party ..", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                return;
                            }
                            if (AccDbt == "" && data_this.price.Value > 0.0)
                            {
                                MessageBox.Show((LangArEn == 0) ? "لا يمكن إتمام العملية .. تأكد من صحة الطرف المدين للقيد .. " : "You can not complete the operation .. Make sure the debtor under the party ..", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                return;
                            }
                            if (data_this.price.Value > 0.0 && !string.IsNullOrEmpty(AccCrdt) && !string.IsNullOrEmpty(AccDbt))
                            {
                                int num = 1;
                                try
                                {
                                    num = db.T_GDHEADs.Where((T_GDHEAD q) => q.gdTyp == (int?)15).Max((T_GDHEAD lgl) => Convert.ToInt32(lgl.gdNo)) + 1;
                                }
                                catch
                                {
                                }
                                maxGd = num;
                                IDatabase db_ = Database.GetDatabase(VarGeneral.BranchCS);
                                Stock_DataDataContext dbc = new Stock_DataDataContext(VarGeneral.BranchCS);
                                GetDataGd(data_this.price.Value, maxGd);
                                _GdHead.DATE_CREATED = DateTime.Now;
                                dbc.T_GDHEADs.InsertOnSubmit(_GdHead);
                                dbc.SubmitChanges();
                                if (data_this.price.Value > 0.0 && !string.IsNullOrEmpty(AccCrdt) && !string.IsNullOrEmpty(AccDbt))
                                {
                                    db_.StartTransaction();
                                    db_.ClearParameters();
                                    db_.AddParameter("GDDET_ID", DbType.Int32, 0);
                                    db_.AddParameter("gdID", DbType.Int32, _GdHead.gdhead_ID);
                                    db_.AddParameter("gdNo", DbType.String, maxGd);
                                    db_.AddParameter("gdDes", DbType.String, "قيد تلقائي || أقامة " + Days_ + " يوم/أيام في شقة رقم " + txtRoom.Text);
                                    db_.AddParameter("gdDesE", DbType.String, "Auto Bound || Stay " + Days_ + " Day/Days on flat No " + txtRoom.Text);
                                    db_.AddParameter("recptTyp", DbType.String, "1");
                                    db_.AddParameter("AccNo", DbType.String, AccCrdt);
                                    db_.AddParameter("AccName", DbType.String, "");
                                    db_.AddParameter("gdValue", DbType.Double, 0.0 - data_this.price.Value);
                                    db_.AddParameter("recptNo", DbType.String, maxGd);
                                    db_.AddParameter("Lin", DbType.Int32, 1);
                                    db_.AddParameter("AccNoDestruction", DbType.String, null);
                                    db_.ExecuteNonQueryWithoutCommit(storedProcedure: true, "S_T_GDDET_INSERT");
                                    db_.EndTransaction();
                                    db_.StartTransaction();
                                    db_.ClearParameters();
                                    db_.AddParameter("GDDET_ID", DbType.Int32, 0);
                                    db_.AddParameter("gdID", DbType.Int32, _GdHead.gdhead_ID);
                                    db_.AddParameter("gdNo", DbType.String, maxGd);
                                    db_.AddParameter("gdDes", DbType.String, "قيد تلقائي || أقامة " + Days_ + " يوم/أيام في شقة رقم " + txtRoom.Text);
                                    db_.AddParameter("gdDesE", DbType.String, "Auto Bound || Stay " + Days_ + " Day/Days on flat No " + txtRoom.Text);
                                    db_.AddParameter("recptTyp", DbType.String, "1");
                                    db_.AddParameter("AccNo", DbType.String, AccDbt);
                                    db_.AddParameter("AccName", DbType.String, "");
                                    db_.AddParameter("gdValue", DbType.Double, data_this.price.Value);
                                    db_.AddParameter("recptNo", DbType.String, maxGd);
                                    db_.AddParameter("Lin", DbType.Int32, 1);
                                    db_.AddParameter("AccNoDestruction", DbType.String, null);
                                    db_.ExecuteNonQueryWithoutCommit(storedProcedure: true, "S_T_GDDET_INSERT");
                                    db_.EndTransaction();
                                }
                            }
                        }
                        catch (Exception error2)
                        {
                            VarGeneral.DebLog.writeLog("CreateGaid:", error2, enable: true);
                            MessageBox.Show(error2.Message);
                        }
                    }
                    try
                    {
                        if (_GdHead.gdhead_ID > 0)
                        {
                            data_this.IsGaid = true;
                            data_this.GadeId = _GdHead.gdhead_ID;
                            data_this.GadeNo = maxGd;
                        }
                    }
                    catch
                    {
                        data_this.IsGaid = false;
                    }
                    _Db.T_trans.InsertOnSubmit(data_this);
                    _Db.SubmitChanges();
                }
                MessageBox.Show((LangArEn == 0) ? "لقد تم اتمام عملية النقل بنجاح .." : "This Opration Is Done", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                VarGeneral.ChkMove = 1;
                Close();
            }
            catch (Exception error2)
            {
                VarGeneral.DebLog.writeLog("Save:", error2, enable: true);
                MessageBox.Show(error2.Message);
            }
        }
        private T_GDHEAD GetDataGd(double _val, int maxGd)
        {
            _GdHead.gdHDate = VarGeneral.Hdate;
            _GdHead.gdGDate = VarGeneral.Gdate;
            _GdHead.gdNo = maxGd.ToString();
            _GdHead.ArbTaf = ScriptNumber1.ScriptNum(decimal.Parse("0" + _val));
            _GdHead.BName = _GdHead.BName;
            _GdHead.ChekNo = _GdHead.ChekNo;
            _GdHead.CurTyp = 1;
            _GdHead.EngTaf = ScriptNumber1.TafEng(decimal.Parse("0" + _val));
            _GdHead.gdCstNo = 1;
            _GdHead.gdID = 0;
            _GdHead.gdLok = false;
            _GdHead.gdMem = "قيد تلقائي لعملية اضافة خدمة نزيل  | Auto Bound to add guest service ";
            _GdHead.gdMnd = null;
            _GdHead.gdRcptID = (_GdHead.gdRcptID.HasValue ? _GdHead.gdRcptID.Value : 0.0);
            _GdHead.gdTot = _val;
            _GdHead.gdTp = (_GdHead.gdTp.HasValue ? _GdHead.gdTp.Value : 0);
            _GdHead.gdTyp = 15;
            _GdHead.RefNo = "";
            _GdHead.AdminLock = false;
            _GdHead.DATE_MODIFIED = DateTime.Now;
            _GdHead.salMonth = "";
            _GdHead.gdUser = VarGeneral.UserNumber;
            _GdHead.gdUserNam = VarGeneral.UserNameA;
            _GdHead.CompanyID = 1;
            return _GdHead;
        }
        private void comboBox_Rooms_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                T_Rom Q = db.StockRoom(int.Parse(comboBox_Rooms.SelectedValue.ToString()));
                textBox_RoomPrice2.Value = ((db.StockPer(VarGeneral._hotelper).KindPer.Value != 0) ? ((dbc.Get_PermissionID(VarGeneral.UserID).RepAcc6 == "0") ? Q.priM0.Value : Q.priM1.Value) : ((dbc.Get_PermissionID(VarGeneral.UserID).RepAcc5 == "0") ? Q.pri0.Value : Q.pri1.Value));
            }
            catch
            {
            }
        }
    }
}
