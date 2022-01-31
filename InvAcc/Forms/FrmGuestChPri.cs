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
    public partial  class FrmGuestChPri : Form
    { void avs(int arln)

{ 
}
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
        private HijriGreg.HijriGregDates n = new HijriGreg.HijriGregDates();
        private T_AccDef _AccDefBind = new T_AccDef();
        private int LangArEn = 0;
        protected bool ifOkDelete;
        public bool CanEdit = true;
        protected bool CanInsert = true;
        private string FlagUpdate = string.Empty;
        public ViewState ViewState = ViewState.Deiles;
        private FormState statex;
        public List<Control> controls;
        public Control codeControl = new Control();
        private bool canUpdate = true;
        private List<string> pkeys = new List<string>();
        private Stock_DataDataContext dbInstance;
        private int Days_ = 1;
        private double pric_ = 0.0;
        private double tot = 0.0;
        private Rate_DataDataContext dbInstanceRate;
        private string CuNo;
        private int RomDay;
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
        private Label label1;
        internal Label label5;
        private DoubleInput Text1;
        private DoubleInput Text2;
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
        public FrmGuestChPri(int _Days, double _pric, double _tot)
        {
            InitializeComponent();this.Load += langloads;
            Days_ = _Days;
            pric_ = _pric;
            tot = _tot;
        }
        private void RibunButtons()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
            {
                Button_Close.Text = "اغلاق";
                Button_Save.Text = "حفظ";
                Button_Close.Tooltip = "Esc";
                Button_Save.Tooltip = "F2";
                Text = "تغـــيير السعـــــر";
            }
            else
            {
                Button_Close.Text = "Close";
                Button_Save.Text = "Save";
                Button_Close.Tooltip = "Esc";
                Button_Save.Tooltip = "F2";
                Text = "Change Price";
            }
        }
        private void FrmGuestChPri_Load(object sender, EventArgs e)
        {
            try
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmGuestChPri));
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
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
                textBox_ID.Text = VarGeneral._hotelper.ToString();
                txtRoom.Text = VarGeneral._hotelrom.ToString();
                txtName.Text = q.nm;
                Text1.Value = q.price.Value;
                RomDay = VarGeneral.Dy(q.dt2, q.tm1 + " " + q.vAmPm);
                CuNo = q.Cust_no;
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
                T_Rom QRoom = db.StockRoom(int.Parse(txtRoom.Text));
                T_per qPer = db.StockPer(int.Parse(textBox_ID.Text));
                if (string.IsNullOrEmpty(textBox_ID.Text) || string.IsNullOrEmpty(txtRoom.Text))
                {
                    MessageBox.Show((LangArEn == 0) ? "هناك خطآ في بيانات الغرفة الحالية" : "There are errors in the current room data", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                if (Days_ == 1)
                {
                    QRoom.price = Text2.Value;
                    db.Log = VarGeneral.DebugLog;
                    db.SubmitChanges(ConflictMode.ContinueOnConflict);
                    qPer.price = Text2.Value;
                    db.Log = VarGeneral.DebugLog;
                    db.SubmitChanges(ConflictMode.ContinueOnConflict);
                    MessageBox.Show((LangArEn == 0) ? "تمت عملية تغيير سعر الغرفة بنجاح" : "This Opration Is Done", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    VarGeneral.ChkMove = 1;
                    Close();
                    return;
                }
                QRoom.price = Text2.Value;
                int? calendr = VarGeneral.Settings_Sys.Calendr;
                QRoom.dt = ((calendr.Value == 0 && calendr.HasValue) ? n.FormatGreg(VarGeneral.Gdate, "yyyy/MM/dd") : n.FormatHijri(VarGeneral.Hdate, "yyyy/MM/dd"));
                QRoom.tm = DateTime.Now.ToString("hh:mm:ss tt");
                db.Log = VarGeneral.DebugLog;
                db.SubmitChanges(ConflictMode.ContinueOnConflict);
                int St = qPer.KindPer.Value;
                qPer.ps1 = VarGeneral.UserNo;
                qPer.price = Text2.Value;
                calendr = VarGeneral.Settings_Sys.Calendr;
                qPer.dt2 = ((calendr.Value == 0 && calendr.HasValue) ? n.FormatGreg(VarGeneral.Gdate, "yyyy/MM/dd") : n.FormatHijri(VarGeneral.Hdate, "yyyy/MM/dd"));
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
                db.Log = VarGeneral.DebugLog;
                db.SubmitChanges(ConflictMode.ContinueOnConflict);
                T_tran data_this = new T_tran();
                data_this.perno = int.Parse(textBox_ID.Text);
                data_this.romno = int.Parse(txtRoom.Text);
                data_this.fat = db.MaxTranNo;
                switch (St)
                {
                    case 0:
                        data_this.price = tot;
                        break;
                    case 1:
                        data_this.price = (double)VarGeneral.Ft * tot;
                        break;
                }
                data_this.typ = 1;
                data_this.detal = "أقامة " + Days_ + " يوم/أيام في شقة رقم " + txtRoom.Text;
                calendr = VarGeneral.Settings_Sys.Calendr;
                data_this.dt = ((calendr.Value == 0 && calendr.HasValue) ? n.FormatGreg(VarGeneral.Gdate, "yyyy/MM/dd") : n.FormatHijri(VarGeneral.Hdate, "yyyy/MM/dd"));
                data_this.tm = DateTime.Now.ToString("hh:mm:ss tt");
                data_this.Usr = VarGeneral.UserNo;
                int maxGd = 1;
                if (!VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 46) && data_this.price.Value > 0.0)
                {
                    try
                    {
                        string AccCrdt = string.Empty;
                        string AccDbt = string.Empty;
                        if (data_this.price.Value > 0.0)
                        {
                            try
                            {
                                AccCrdt = db.StockServTypeID(1).accno;
                            }
                            catch
                            {
                                AccCrdt = string.Empty;
                            }
                            try
                            {
                                AccDbt = db.StockPer(int.Parse(textBox_ID.Text)).Cust_no;
                            }
                            catch
                            {
                                AccDbt = string.Empty;
                            }
                        }
                        if (AccCrdt == string.Empty && data_this.price.Value > 0.0)
                        {
                            MessageBox.Show((LangArEn == 0) ? "لا يمكن إتمام العملية .. تأكد من صحة الطرف الدائن للقيد .. " : "You can not complete the operation .. Make sure the creditor under the party ..", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            return;
                        }
                        if (AccDbt == string.Empty && data_this.price.Value > 0.0)
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
                                db_.AddParameter("AccName", DbType.String, string.Empty);
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
                                db_.AddParameter("AccName", DbType.String, string.Empty);
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
            _GdHead.gdTp = (_GdHead.gdTp!=0? _GdHead.gdTp : 0);
            _GdHead.gdTyp = 15;
            _GdHead.RefNo = string.Empty;
            _GdHead.AdminLock = false;
            _GdHead.DATE_MODIFIED = DateTime.Now;
            _GdHead.salMonth = string.Empty;
            _GdHead.gdUser = VarGeneral.UserNumber;
            _GdHead.gdUserNam = VarGeneral.UserNameA;
            _GdHead.CompanyID = 1;
            return _GdHead;
        }
        private void Text2_Leave(object sender, EventArgs e)
        {
            double tmp = 0.0;
            T_per q = db.StockPer(int.Parse(textBox_ID.Text));
            tmp = ((q.KindPer.Value != 0) ? ((dbc.Get_PermissionID(VarGeneral.UserID).RepAcc6 == "0") ? db.StockRoom(q.romno.Value).priM0.Value : db.StockRoom(q.romno.Value).priM1.Value) : ((dbc.Get_PermissionID(VarGeneral.UserID).RepAcc5 == "0") ? db.StockRoom(q.romno.Value).pri0.Value : db.StockRoom(q.romno.Value).pri1.Value));
            if (Text2.Value < tmp)
            {
                MessageBox.Show((LangArEn == 0) ? "لايمكن تعديل سعر الغرفة باقل من السعر الإفتراضي" : "Room rate can not be adjusted below the default price", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                if (q.KindPer.Value == 0)
                {
                    Text2.Value = ((dbc.Get_PermissionID(VarGeneral.UserID).RepAcc5 == "0") ? db.StockRoom(q.romno.Value).pri0.Value : db.StockRoom(q.romno.Value).pri1.Value);
                }
                else
                {
                    Text2.Value = ((dbc.Get_PermissionID(VarGeneral.UserID).RepAcc6 == "0") ? db.StockRoom(q.romno.Value).priM0.Value : db.StockRoom(q.romno.Value).priM1.Value);
                }
                Text2.Focus();
            }
        }
    }
}
