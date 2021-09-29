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
    public partial class FrmGuestAddRoom : Form
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
        private Rate_DataDataContext dbInstanceRate;
        private string CuNo;
        private string CDat;
        private int CDat2;
        private int a1;
        private int a3;
        private int a4;
        private int a5;
        private string a6;
        private string a7;
        private double a2;
        private IContainer components = null;
        private Timer timer1;
        private PanelEx panelEx2;
        private RibbonBar ribbonBar1;
        private SaveFileDialog saveFileDialog1;
        private Timer timerInfoBallon;
        private OpenFileDialog openFileDialog1;
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
            InitializeComponent();
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InvAcc.Forms.FrmGuestAddRoom));
            timer1 = new System.Windows.Forms.Timer(components);
            panelEx2 = new DevComponents.DotNetBar.PanelEx();
            ribbonBar1 = new DevComponents.DotNetBar.RibbonBar();
            panel2 = new System.Windows.Forms.Panel();
            comboBox_RoomTyp = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            comboBox_Rooms = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            label5 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            label36 = new System.Windows.Forms.Label();
            label13z = new System.Windows.Forms.Label();
            txtRoom = new System.Windows.Forms.TextBox();
            textBox_ID = new System.Windows.Forms.TextBox();
            label38 = new System.Windows.Forms.Label();
            textBox_RoomPrice = new DevComponents.Editors.DoubleInput();
            txtName = new System.Windows.Forms.TextBox();
            ribbonBar_Tasks = new DevComponents.DotNetBar.RibbonBar();
            superTabControl_Main1 = new DevComponents.DotNetBar.SuperTabControl();
            Button_Close = new DevComponents.DotNetBar.ButtonItem();
            Button_Save = new DevComponents.DotNetBar.ButtonItem();
            saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            timerInfoBallon = new System.Windows.Forms.Timer(components);
            openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            panel1 = new System.Windows.Forms.Panel();
            barTopDockSite = new DevComponents.DotNetBar.DockSite();
            barBottomDockSite = new DevComponents.DotNetBar.DockSite();
            dotNetBarManager1 = new DevComponents.DotNetBar.DotNetBarManager(components);
            imageList1 = new System.Windows.Forms.ImageList(components);
            barLeftDockSite = new DevComponents.DotNetBar.DockSite();
            barRightDockSite = new DevComponents.DotNetBar.DockSite();
            dockSite4 = new DevComponents.DotNetBar.DockSite();
            dockSite1 = new DevComponents.DotNetBar.DockSite();
            dockSite2 = new DevComponents.DotNetBar.DockSite();
            dockSite3 = new DevComponents.DotNetBar.DockSite();
            contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(components);
            ToolStripMenuItem_Rep = new System.Windows.Forms.ToolStripMenuItem();
            ToolStripMenuItem_Det = new System.Windows.Forms.ToolStripMenuItem();
            contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(components);
            panelEx2.SuspendLayout();
            ribbonBar1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)textBox_RoomPrice).BeginInit();
            ribbonBar_Tasks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)superTabControl_Main1).BeginInit();
            panel1.SuspendLayout();
            contextMenuStrip2.SuspendLayout();
            SuspendLayout();
            timer1.Interval = 1000;
            panelEx2.Controls.Add(ribbonBar1);
            panelEx2.Controls.Add(ribbonBar_Tasks);
            resources.ApplyResources(panelEx2, "panelEx2");
            panelEx2.MinimumSize = new System.Drawing.Size(659, 228);
            panelEx2.Name = "panelEx2";
            panelEx2.Style.Alignment = System.Drawing.StringAlignment.Center;
            panelEx2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            panelEx2.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            panelEx2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            panelEx2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            panelEx2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            panelEx2.Style.GradientAngle = 90;
            ribbonBar1.AutoOverflowEnabled = true;
            ribbonBar1.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            ribbonBar1.BackgroundStyle.BackColor = System.Drawing.Color.AliceBlue;
            ribbonBar1.BackgroundStyle.BackColor2 = System.Drawing.SystemColors.GradientActiveCaption;
            ribbonBar1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            ribbonBar1.ContainerControlProcessDialogKey = true;
            ribbonBar1.Controls.Add(panel2);
            resources.ApplyResources(ribbonBar1, "ribbonBar1");
            ribbonBar1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            ribbonBar1.Name = "ribbonBar1";
            ribbonBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            ribbonBar1.TitleStyle.BackColor = System.Drawing.Color.FromArgb(227, 239, 255);
            ribbonBar1.TitleStyle.BackColor2 = System.Drawing.Color.FromArgb(101, 147, 207);
            ribbonBar1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            ribbonBar1.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            panel2.Controls.Add(comboBox_RoomTyp);
            panel2.Controls.Add(comboBox_Rooms);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(label36);
            panel2.Controls.Add(label13z);
            panel2.Controls.Add(txtRoom);
            panel2.Controls.Add(textBox_ID);
            panel2.Controls.Add(label38);
            panel2.Controls.Add(textBox_RoomPrice);
            panel2.Controls.Add(txtName);
            resources.ApplyResources(panel2, "panel2");
            panel2.Name = "panel2";
            comboBox_RoomTyp.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            comboBox_RoomTyp.DisplayMember = "Text";
            comboBox_RoomTyp.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            comboBox_RoomTyp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox_RoomTyp.FormattingEnabled = true;
            resources.ApplyResources(comboBox_RoomTyp, "comboBox_RoomTyp");
            comboBox_RoomTyp.Name = "comboBox_RoomTyp";
            comboBox_RoomTyp.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            comboBox_RoomTyp.SelectedIndexChanged += new System.EventHandler(comboBox_RoomTyp_SelectedIndexChanged);
            comboBox_Rooms.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            comboBox_Rooms.DisplayMember = "Text";
            comboBox_Rooms.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            comboBox_Rooms.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox_Rooms.FormattingEnabled = true;
            resources.ApplyResources(comboBox_Rooms, "comboBox_Rooms");
            comboBox_Rooms.Name = "comboBox_Rooms";
            comboBox_Rooms.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            comboBox_Rooms.SelectedValueChanged += new System.EventHandler(comboBox_Rooms_SelectedValueChanged);
            resources.ApplyResources(label5, "label5");
            label5.BackColor = System.Drawing.Color.Transparent;
            label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            label5.Name = "label5";
            resources.ApplyResources(label1, "label1");
            label1.BackColor = System.Drawing.Color.Transparent;
            label1.Name = "label1";
            resources.ApplyResources(label8, "label8");
            label8.BackColor = System.Drawing.Color.Transparent;
            label8.Name = "label8";
            resources.ApplyResources(label36, "label36");
            label36.BackColor = System.Drawing.Color.Transparent;
            label36.Name = "label36";
            resources.ApplyResources(label13z, "label13z");
            label13z.BackColor = System.Drawing.Color.Transparent;
            label13z.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            label13z.Name = "label13z";
            txtRoom.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(txtRoom, "txtRoom");
            txtRoom.Name = "txtRoom";
            txtRoom.ReadOnly = true;
            textBox_ID.BackColor = System.Drawing.Color.FromArgb(255, 224, 192);
            textBox_ID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(textBox_ID, "textBox_ID");
            textBox_ID.Name = "textBox_ID";
            textBox_ID.ReadOnly = true;
            resources.ApplyResources(label38, "label38");
            label38.BackColor = System.Drawing.Color.Transparent;
            label38.Name = "label38";
            textBox_RoomPrice.AllowEmptyState = false;
            resources.ApplyResources(textBox_RoomPrice, "textBox_RoomPrice");
            textBox_RoomPrice.BackgroundStyle.Class = "DateTimeInputBackground";
            textBox_RoomPrice.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            textBox_RoomPrice.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            textBox_RoomPrice.DisplayFormat = "0.00";
            textBox_RoomPrice.Increment = 0.0;
            textBox_RoomPrice.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            textBox_RoomPrice.Name = "textBox_RoomPrice";
            txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(txtName, "txtName");
            txtName.ForeColor = System.Drawing.Color.Maroon;
            txtName.Name = "txtName";
            txtName.ReadOnly = true;
            ribbonBar_Tasks.AutoOverflowEnabled = true;
            ribbonBar_Tasks.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            ribbonBar_Tasks.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            ribbonBar_Tasks.ContainerControlProcessDialogKey = true;
            ribbonBar_Tasks.Controls.Add(superTabControl_Main1);
            resources.ApplyResources(ribbonBar_Tasks, "ribbonBar_Tasks");
            ribbonBar_Tasks.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            ribbonBar_Tasks.Name = "ribbonBar_Tasks";
            ribbonBar_Tasks.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            ribbonBar_Tasks.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            ribbonBar_Tasks.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            ribbonBar_Tasks.TitleVisible = false;
            superTabControl_Main1.BackColor = System.Drawing.Color.White;
            superTabControl_Main1.CausesValidation = false;
            superTabControl_Main1.ControlBox.CloseBox.Name = "";
            superTabControl_Main1.ControlBox.MenuBox.Name = "";
            superTabControl_Main1.ControlBox.Name = "";
            superTabControl_Main1.ControlBox.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[2]
            {
                superTabControl_Main1.ControlBox.MenuBox,
                superTabControl_Main1.ControlBox.CloseBox
            });
            superTabControl_Main1.ControlBox.Visible = false;
            resources.ApplyResources(superTabControl_Main1, "superTabControl_Main1");
            superTabControl_Main1.ForeColor = System.Drawing.Color.Black;
            superTabControl_Main1.ItemPadding.Bottom = 4;
            superTabControl_Main1.ItemPadding.Left = 2;
            superTabControl_Main1.ItemPadding.Top = 4;
            superTabControl_Main1.Name = "superTabControl_Main1";
            superTabControl_Main1.ReorderTabsEnabled = true;
            superTabControl_Main1.SelectedTabIndex = -1;
            superTabControl_Main1.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[2]
            {
                Button_Close,
                Button_Save
            });
            superTabControl_Main1.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.WinMediaPlayer12;
            superTabControl_Main1.TextAlignment = DevComponents.DotNetBar.eItemAlignment.Center;
            Button_Close.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            Button_Close.Checked = true;
            Button_Close.FontBold = true;
            Button_Close.FontItalic = true;
            Button_Close.ForeColor = System.Drawing.Color.Black;
            Button_Close.Image = (System.Drawing.Image)resources.GetObject("Button_Close.Image");
            Button_Close.ImageFixedSize = new System.Drawing.Size(28, 28);
            Button_Close.ImagePaddingHorizontal = 15;
            Button_Close.ImagePaddingVertical = 11;
            Button_Close.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            Button_Close.Name = "Button_Close";
            Button_Close.Stretch = true;
            Button_Close.SubItemsExpandWidth = 14;
            Button_Close.Symbol = "\uf057";
            Button_Close.SymbolSize = 15f;
            resources.ApplyResources(Button_Close, "Button_Close");
            Button_Close.Click += new System.EventHandler(Button_Close_Click);
            Button_Save.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            Button_Save.FontBold = true;
            Button_Save.FontItalic = true;
            Button_Save.ForeColor = System.Drawing.Color.FromArgb(192, 64, 0);
            Button_Save.Image = (System.Drawing.Image)resources.GetObject("Button_Save.Image");
            Button_Save.ImageFixedSize = new System.Drawing.Size(28, 28);
            Button_Save.ImagePaddingHorizontal = 15;
            Button_Save.ImagePaddingVertical = 11;
            Button_Save.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            Button_Save.Name = "Button_Save";
            Button_Save.Stretch = true;
            Button_Save.SubItemsExpandWidth = 14;
            Button_Save.Symbol = "\uf0c7";
            Button_Save.SymbolSize = 15f;
            resources.ApplyResources(Button_Save, "Button_Save");
            Button_Save.Click += new System.EventHandler(Button_Save_Click);
            saveFileDialog1.DefaultExt = "*.rtf";
            saveFileDialog1.FileName = "doc1";
            resources.ApplyResources(saveFileDialog1, "saveFileDialog1");
            saveFileDialog1.FilterIndex = 2;
            timerInfoBallon.Interval = 3000;
            openFileDialog1.DefaultExt = "*.rtf";
            resources.ApplyResources(openFileDialog1, "openFileDialog1");
            openFileDialog1.FilterIndex = 2;
            panel1.Controls.Add(panelEx2);
            resources.ApplyResources(panel1, "panel1");
            panel1.Name = "panel1";
            barTopDockSite.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            resources.ApplyResources(barTopDockSite, "barTopDockSite");
            barTopDockSite.DocumentDockContainer = new DevComponents.DotNetBar.DocumentDockContainer();
            barTopDockSite.Name = "barTopDockSite";
            barTopDockSite.TabStop = false;
            barBottomDockSite.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            resources.ApplyResources(barBottomDockSite, "barBottomDockSite");
            barBottomDockSite.DocumentDockContainer = new DevComponents.DotNetBar.DocumentDockContainer();
            barBottomDockSite.Name = "barBottomDockSite";
            barBottomDockSite.TabStop = false;
            dotNetBarManager1.BottomDockSite = barBottomDockSite;
            dotNetBarManager1.Images = imageList1;
            dotNetBarManager1.LeftDockSite = barLeftDockSite;
            dotNetBarManager1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            dotNetBarManager1.MdiSystemItemVisible = false;
            dotNetBarManager1.ParentForm = null;
            dotNetBarManager1.RightDockSite = barRightDockSite;
            dotNetBarManager1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2000;
            dotNetBarManager1.ToolbarBottomDockSite = dockSite4;
            dotNetBarManager1.ToolbarLeftDockSite = dockSite1;
            dotNetBarManager1.ToolbarRightDockSite = dockSite2;
            dotNetBarManager1.ToolbarTopDockSite = dockSite3;
            dotNetBarManager1.TopDockSite = barTopDockSite;
            imageList1.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = System.Drawing.Color.Magenta;
            imageList1.Images.SetKeyName(0, "");
            imageList1.Images.SetKeyName(1, "");
            imageList1.Images.SetKeyName(2, "");
            imageList1.Images.SetKeyName(3, "");
            imageList1.Images.SetKeyName(4, "");
            imageList1.Images.SetKeyName(5, "");
            imageList1.Images.SetKeyName(6, "");
            imageList1.Images.SetKeyName(7, "");
            imageList1.Images.SetKeyName(8, "");
            imageList1.Images.SetKeyName(9, "");
            imageList1.Images.SetKeyName(10, "");
            imageList1.Images.SetKeyName(11, "");
            imageList1.Images.SetKeyName(12, "");
            imageList1.Images.SetKeyName(13, "");
            imageList1.Images.SetKeyName(14, "");
            imageList1.Images.SetKeyName(15, "");
            imageList1.Images.SetKeyName(16, "");
            imageList1.Images.SetKeyName(17, "");
            imageList1.Images.SetKeyName(18, "");
            imageList1.Images.SetKeyName(19, "");
            imageList1.Images.SetKeyName(20, "");
            imageList1.Images.SetKeyName(21, "");
            imageList1.Images.SetKeyName(22, "");
            imageList1.Images.SetKeyName(23, "");
            barLeftDockSite.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            resources.ApplyResources(barLeftDockSite, "barLeftDockSite");
            barLeftDockSite.DocumentDockContainer = new DevComponents.DotNetBar.DocumentDockContainer();
            barLeftDockSite.Name = "barLeftDockSite";
            barLeftDockSite.TabStop = false;
            barRightDockSite.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            resources.ApplyResources(barRightDockSite, "barRightDockSite");
            barRightDockSite.DocumentDockContainer = new DevComponents.DotNetBar.DocumentDockContainer();
            barRightDockSite.Name = "barRightDockSite";
            barRightDockSite.TabStop = false;
            dockSite4.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            resources.ApplyResources(dockSite4, "dockSite4");
            dockSite4.Name = "dockSite4";
            dockSite4.TabStop = false;
            dockSite1.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            resources.ApplyResources(dockSite1, "dockSite1");
            dockSite1.Name = "dockSite1";
            dockSite1.TabStop = false;
            dockSite2.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            resources.ApplyResources(dockSite2, "dockSite2");
            dockSite2.Name = "dockSite2";
            dockSite2.TabStop = false;
            dockSite3.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            resources.ApplyResources(dockSite3, "dockSite3");
            dockSite3.Name = "dockSite3";
            dockSite3.TabStop = false;
            contextMenuStrip1.Name = "contextMenuStrip1";
            resources.ApplyResources(contextMenuStrip1, "contextMenuStrip1");
            ToolStripMenuItem_Rep.Checked = true;
            ToolStripMenuItem_Rep.CheckState = System.Windows.Forms.CheckState.Checked;
            ToolStripMenuItem_Rep.Name = "ToolStripMenuItem_Rep";
            resources.ApplyResources(ToolStripMenuItem_Rep, "ToolStripMenuItem_Rep");
            ToolStripMenuItem_Det.Name = "ToolStripMenuItem_Det";
            resources.ApplyResources(ToolStripMenuItem_Det, "ToolStripMenuItem_Det");
            contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[2]
            {
                ToolStripMenuItem_Det,
                ToolStripMenuItem_Rep
            });
            contextMenuStrip2.Name = "contextMenuStrip2";
            resources.ApplyResources(contextMenuStrip2, "contextMenuStrip2");
            resources.ApplyResources(this, "$this");
            base.Controls.Add(panel1);
            base.Controls.Add(barTopDockSite);
            base.Controls.Add(barBottomDockSite);
            base.Controls.Add(barLeftDockSite);
            base.Controls.Add(barRightDockSite);
            base.Controls.Add(dockSite4);
            base.Controls.Add(dockSite1);
            base.Controls.Add(dockSite2);
            base.Controls.Add(dockSite3);
            base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            base.KeyPreview = true;
            base.MaximizeBox = false;
            base.Name = "FrmGuestAddRoom";
            base.Load += new System.EventHandler(FrmGuestAddRoom_Load);
            base.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Frm_KeyPress);
            base.KeyDown += new System.Windows.Forms.KeyEventHandler(Frm_KeyDown);
            panelEx2.ResumeLayout(false);
            ribbonBar1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)textBox_RoomPrice).EndInit();
            ribbonBar_Tasks.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)superTabControl_Main1).EndInit();
            panel1.ResumeLayout(false);
            contextMenuStrip2.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}
