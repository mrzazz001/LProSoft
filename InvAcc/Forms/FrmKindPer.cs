using DevComponents.DotNetBar;
using DevComponents.Editors;
using Framework.Data;
using ProShared.GeneralM;using ProShared;
using ProShared.Stock_Data;
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
    public partial  class FrmKindPer : Form
    { void avs(int arln)

{ 
 panelEx2.Text=   (arln == 0 ? "  Click to collapse  " : "  Click to collapse") ; label2.Text=   (arln == 0 ? "  السعر :  " : "  price :") ; label5.Text=   (arln == 0 ? "  عدد الشهور المقفلة :  " : "  Number of months closed:") ; label1.Text=   (arln == 0 ? "  سعرهـــا :  " : "  Its price:") ; label36.Text=   (arln == 0 ? "  إسم النزيل :  " : "  Guest name:") ; label13z.Text=   (arln == 0 ? "  الغرفة الحالية :  " : "  current room:") ; label38.Text=   (arln == 0 ? "  رقم النزيل :  " : "  guest number:") ; superTabControl_Main1.Text=   (arln == 0 ? "  superTabControl3  " : "  superTabControl3") ; Button_Close.Text=   (arln == 0 ? "  إغلاق  " : "  Close") ; Button_Save.Text=   (arln == 0 ? "  حفظ  " : "  save") ; ToolStripMenuItem_Rep.Text=   (arln == 0 ? "  إظهار التقرير  " : "  Show report") ; ToolStripMenuItem_Det.Text=   (arln == 0 ? "  إظهار التفاصيل  " : "  Show details") ; Text = "تغيير نوع التسكين";this.Text=   (arln == 0 ? "  تغيير نوع التسكين  " : "  Change the type of housing") ;}
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
        private T_AccDef _AccDefBind = new T_AccDef();
        private int LangArEn = 0;
        protected bool ifOkDelete;
        public bool CanEdit = true;
        protected bool CanInsert = true;
#pragma warning disable CS0414 // The field 'FrmKindPer.FlagUpdate' is assigned but its value is never used
        private string FlagUpdate = "";
#pragma warning restore CS0414 // The field 'FrmKindPer.FlagUpdate' is assigned but its value is never used
        public ViewState ViewState = ViewState.Deiles;
        private FormState statex;
        public List<Control> controls;
        public Control codeControl = new Control();
        private bool canUpdate = true;
        private List<string> pkeys = new List<string>();
        private Stock_DataDataContext dbInstance;
        private int Days_ = 1;
        private double pric_ = 0.0;
        private Rate_DataDataContext dbInstanceRate;
        private string CuNo;
        private int St;
        private int Rs;
        private int RomDay;
#pragma warning disable CS0169 // The field 'FrmKindPer.a1' is never used
        private int a1;
#pragma warning restore CS0169 // The field 'FrmKindPer.a1' is never used
#pragma warning disable CS0169 // The field 'FrmKindPer.a3' is never used
        private int a3;
#pragma warning restore CS0169 // The field 'FrmKindPer.a3' is never used
#pragma warning disable CS0169 // The field 'FrmKindPer.a4' is never used
        private int a4;
#pragma warning restore CS0169 // The field 'FrmKindPer.a4' is never used
#pragma warning disable CS0169 // The field 'FrmKindPer.a5' is never used
        private int a5;
#pragma warning restore CS0169 // The field 'FrmKindPer.a5' is never used
#pragma warning disable CS0169 // The field 'FrmKindPer.a6' is never used
        private string a6;
#pragma warning restore CS0169 // The field 'FrmKindPer.a6' is never used
#pragma warning disable CS0169 // The field 'FrmKindPer.a7' is never used
        private string a7;
#pragma warning restore CS0169 // The field 'FrmKindPer.a7' is never used
#pragma warning disable CS0169 // The field 'FrmKindPer.a2' is never used
        private double a2;
#pragma warning restore CS0169 // The field 'FrmKindPer.a2' is never used
        private T_GDHEAD _GdHead = new T_GDHEAD();
        private ScriptNumber ScriptNumber1 = new ScriptNumber();
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
        internal Label label5;
        private Label label2;
        private DoubleInput textBox_RoomPrice2;
        private IntegerInput Text2;
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
        public FrmKindPer(int _Days, double _pric)
        {
            InitializeComponent();this.Load += langloads;
            Days_ = _Days;
            pric_ = _pric;
        }
        private void RibunButtons()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                Button_Close.Text = "اغلاق";
                Button_Save.Text = "حفظ";
                Button_Close.Tooltip = "Esc";
                Button_Save.Tooltip = "F2";
            }
            else
            {
                Button_Close.Text = "Close";
                Button_Save.Text = "Save";
                Button_Close.Tooltip = "Esc";
                Button_Save.Tooltip = "F2";
            }
        }
        private void FrmKindPer_Load(object sender, EventArgs e)
        {
            try
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmKindPer));
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
                VarGeneral.ChKindMove = 0;
                SetData();
                base.ActiveControl = Text2;
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Load:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        public void SetData()
        {
            try
            {
                T_per q = db.StockPer(VarGeneral._hotelper);
                int? kindPer = q.KindPer;
                if (kindPer.Value == 0 && kindPer.HasValue)
                {
                    Text = ((LangArEn == 0) ? "تغيير نوع السكن من يومي إلى شهري" : "Change the type of housing from daily to monthly");
                    label5.Text = ((LangArEn == 0) ? "عدد الأيام المقفلة :" : "Number of days closed :");
                }
                else
                {
                    Text = ((LangArEn == 0) ? "تغيير نوع السكن من شهري إلى يومي" : "Change the type of housing from monthly to daily");
                    label5.Text = ((LangArEn == 0) ? "عدد الشهور المقفلة :" : "Number of months closed :");
                }
                textBox_ID.Text = VarGeneral._hotelper.ToString();
                txtRoom.Text = VarGeneral._hotelrom.ToString();
                txtName.Text = q.nm;
                textBox_RoomPrice.Value = q.price.Value;
                RomDay = VarGeneral.Dy(q.dt2, q.tm1 + " " + q.vAmPm);
                St = q.KindPer.Value;
                CuNo = q.Cust_no;
                if (St == 1)
                {
                    Rs = VarGeneral.Ft - 1;
                    if (Rs == 0)
                    {
                        label5.Text = ((LangArEn == 0) ? "الايام المراد تحويله :" : "Days to be converted :");
                        Text2.Value = Days_;
                        Text2.Enabled = false;
                        return;
                    }
                    Text2.Value = Rs;
                    goto IL_01fc;
                }
                if (St == 0)
                {
                    Text2.Value = Days_;
                }
                goto IL_01fc;
            IL_01fc:
                if (q.KindPer.Value == 0)
                {
                    textBox_RoomPrice2.Value = ((dbc.Get_PermissionID(VarGeneral.UserID).RepAcc5 == "0") ? db.StockRoom(q.romno.Value).pri0.Value : db.StockRoom(q.romno.Value).pri1.Value);
                }
                else
                {
                    textBox_RoomPrice2.Value = ((dbc.Get_PermissionID(VarGeneral.UserID).RepAcc6 == "0") ? db.StockRoom(q.romno.Value).priM0.Value : db.StockRoom(q.romno.Value).priM1.Value);
                }
                if (db.StockRoom(q.romno.Value).typ.Value == 0)
                {
                    label13z.Text = ((LangArEn == 0) ? "الغرفة الحالية :" : "Room :");
                }
                else if (db.StockRoom(q.romno.Value).typ.Value == 1)
                {
                    label13z.Text = ((LangArEn == 0) ? "الجناح الحالي :" : "suite :");
                }
                else if (db.StockRoom(q.romno.Value).typ.Value == 2)
                {
                    label13z.Text = ((LangArEn == 0) ? "الفيلا الحالية :" : "villa :");
                }
                else if (db.StockRoom(q.romno.Value).typ.Value == 3)
                {
                    label13z.Text = ((LangArEn == 0) ? "الشقة الحالية :" : "apartment :");
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("SetData:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void Button_Save_Click(object sender, EventArgs e)
        {
            try
            {
                int Sr = 0;
                int Sr2 = 0;
                T_Rom QRoom = db.StockRoom(int.Parse(txtRoom.Text));
                T_per qPer = db.StockPer(int.Parse(textBox_ID.Text));
                if (string.IsNullOrEmpty(textBox_ID.Text) || string.IsNullOrEmpty(txtRoom.Text) || string.IsNullOrEmpty(txtRoom.Text))
                {
                    MessageBox.Show((LangArEn == 0) ? "هناك خطآ في بيانات الغرفة الحالية" : "There are errors in the current room data", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                int DayofMath;
                string Sr3;
                int? calendr;
                if (St == 1)
                {
                    if (Rs == 0)
                    {
                        QRoom.price = textBox_RoomPrice2.Value;
                        db.Log = VarGeneral.DebugLog;
                        db.SubmitChanges(ConflictMode.ContinueOnConflict);
                        qPer.ps1 = VarGeneral.UserNo;
                        qPer.price = textBox_RoomPrice2.Value;
                        qPer.KindPer = 0;
                        qPer.DayOfM = 0;
                        DayofMath = qPer.DayOfM.Value;
                        db.Log = VarGeneral.DebugLog;
                        db.SubmitChanges(ConflictMode.ContinueOnConflict);
                        MessageBox.Show((LangArEn == 0) ? "تمت عملية تغيير سعر الغرفة بنجاح" : "This Opration Is Done", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        VarGeneral.ChKindMove = 1;
                        Close();
                        return;
                    }
                    Sr = Text2.Value * VarGeneral.GDayM;
                    if (Sr >= Days_)
                    {
                        MessageBox.Show((LangArEn == 0) ? " لايمكن الحفظ .. الرجاء تعديل عدد الشهور " : "Can not save .. Please modify the number of months", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        Text2.Value = 1;
                        return;
                    }
                    Sr2 = Days_ - Sr;
                    calendr = VarGeneral.Settings_Sys.Calendr;
                    Sr3 = Convert.ToDateTime((calendr.Value == 0 && calendr.HasValue) ? n.FormatGreg(VarGeneral.Gdate, "yyyy/MM/dd") : n.FormatHijri(VarGeneral.Hdate, "yyyy/MM/dd")).Date.AddDays(-Sr2).ToString("yyyy/MM/dd");
                    QRoom.price = textBox_RoomPrice2.Value;
                    QRoom.dt = Convert.ToDateTime(Sr3).ToString("yyyy/MM/dd");
                    QRoom.tm = DateTime.Now.ToString("hh:mm:ss tt");
                    db.Log = VarGeneral.DebugLog;
                    db.SubmitChanges(ConflictMode.ContinueOnConflict);
                    qPer.ps1 = VarGeneral.UserNo;
                    qPer.price = textBox_RoomPrice2.Value;
                    qPer.tm1 = DateTime.Now.ToString("hh:mm:ss");
                    if (DateTime.Now.ToString("hh:mm:ss tt").ToString().ToUpper()
                        .Contains("AM"))
                    {
                        qPer.vAmPm = "AM";
                    }
                    else
                    {
                        qPer.vAmPm = "PM";
                    }
                    qPer.dt2 = Convert.ToDateTime(Sr3).ToString("yyyy/MM/dd");
                    qPer.KindPer = 0;
                    qPer.DayOfM = 0;
                    DayofMath = qPer.DayOfM.Value;
                    db.Log = VarGeneral.DebugLog;
                    db.SubmitChanges(ConflictMode.ContinueOnConflict);
                    goto IL_0635;
                }
                Sr = Text2.Value;
                if (Sr > Days_)
                {
                    MessageBox.Show((LangArEn == 0) ? " لايمكن الحفظ .. الرجاء تعديل عدد الأيام " : "Can not save .. Please modify the number of days", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    Text2.Value = 1;
                    return;
                }
                Sr2 = Days_ - Sr;
                calendr = VarGeneral.Settings_Sys.Calendr;
                Sr3 = Convert.ToDateTime((calendr.Value == 0 && calendr.HasValue) ? n.FormatGreg(VarGeneral.Gdate, "yyyy/MM/dd") : n.FormatHijri(VarGeneral.Hdate, "yyyy/MM/dd")).Date.AddDays(-Sr2).ToString("yyyy/MM/dd");
                QRoom.price = textBox_RoomPrice2.Value;
                QRoom.dt = Convert.ToDateTime(Sr3).ToString("yyyy/MM/dd");
                QRoom.tm = DateTime.Now.ToString("hh:mm:ss tt");
                db.Log = VarGeneral.DebugLog;
                db.SubmitChanges(ConflictMode.ContinueOnConflict);
                qPer.ps1 = VarGeneral.UserNo;
                qPer.price = textBox_RoomPrice2.Value;
                qPer.tm1 = DateTime.Now.ToString("hh:mm:ss");
                if (DateTime.Now.ToString("hh:mm:ss tt").ToString().ToUpper()
                    .Contains("AM"))
                {
                    qPer.vAmPm = "AM";
                }
                else
                {
                    qPer.vAmPm = "PM";
                }
                qPer.dt2 = Convert.ToDateTime(Sr3).ToString("yyyy/MM/dd");
                qPer.KindPer = 1;
                qPer.DayOfM = VarGeneral.Settings_Sys.DayOfM;
                qPer.DayImport = VarGeneral.Settings_Sys.DayOfM;
                DayofMath = qPer.DayOfM.Value;
                db.Log = VarGeneral.DebugLog;
                db.SubmitChanges(ConflictMode.ContinueOnConflict);
                goto IL_0635;
            IL_0635:
                T_tran data_this = new T_tran();
                data_this.perno = int.Parse(textBox_ID.Text);
                data_this.romno = int.Parse(txtRoom.Text);
                data_this.fat = db.MaxTranNo;
                data_this.price = (double)Text2.Value * pric_;
                data_this.typ = 1;
                data_this.detal = "أقامة " + ((St == 0) ? Text2.Value : (Text2.Value * DayofMath)) + " يوم/أيام في شقة رقم " + txtRoom.Text;
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
                db.T_trans.InsertOnSubmit(data_this);
                db.SubmitChanges();
                MessageBox.Show((LangArEn == 0) ? "تمت عملية تغيير سعر الغرفة بنجاح" : "This Opration Is Done", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                VarGeneral.ChKindMove = 1;
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
        private void textBox_RoomPrice2_Leave(object sender, EventArgs e)
        {
            double tmp = 0.0;
            T_per q = db.StockPer(int.Parse(textBox_ID.Text));
            tmp = ((q.KindPer.Value != 0) ? db.StockRoom(q.romno.Value).priM0.Value : db.StockRoom(q.romno.Value).pri0.Value);
            if (textBox_RoomPrice2.Value < tmp)
            {
                MessageBox.Show((LangArEn == 0) ? "لايمكن تعديل سعر الغرفة باقل من السعر الإفتراضي" : "Room rate can not be adjusted below the default price", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                if (q.KindPer.Value == 0)
                {
                    textBox_RoomPrice2.Value = ((dbc.Get_PermissionID(VarGeneral.UserID).RepAcc5 == "0") ? db.StockRoom(q.romno.Value).pri0.Value : db.StockRoom(q.romno.Value).pri1.Value);
                }
                else
                {
                    textBox_RoomPrice2.Value = ((dbc.Get_PermissionID(VarGeneral.UserID).RepAcc6 == "0") ? db.StockRoom(q.romno.Value).priM0.Value : db.StockRoom(q.romno.Value).priM1.Value);
                }
                textBox_RoomPrice2.Focus();
            }
        }
    }
}
