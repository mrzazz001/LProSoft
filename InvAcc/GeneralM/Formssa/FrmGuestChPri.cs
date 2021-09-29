using DevComponents.DotNetBar;
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
    public partial class FrmGuestChPri : Form
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
            InitializeComponent();
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
            _GdHead.gdTp = (_GdHead.gdTp.HasValue ? _GdHead.gdTp.Value : 0);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InvAcc.Forms.FrmGuestChPri));
            timer1 = new System.Windows.Forms.Timer(components);
            panelEx2 = new DevComponents.DotNetBar.PanelEx();
            ribbonBar1 = new DevComponents.DotNetBar.RibbonBar();
            panel2 = new System.Windows.Forms.Panel();
            Text2 = new DevComponents.Editors.DoubleInput();
            Text1 = new DevComponents.Editors.DoubleInput();
            label5 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label36 = new System.Windows.Forms.Label();
            label13z = new System.Windows.Forms.Label();
            txtRoom = new System.Windows.Forms.TextBox();
            textBox_ID = new System.Windows.Forms.TextBox();
            label38 = new System.Windows.Forms.Label();
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
            ((System.ComponentModel.ISupportInitialize)Text2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Text1).BeginInit();
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
            panel2.Controls.Add(Text2);
            panel2.Controls.Add(Text1);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(label36);
            panel2.Controls.Add(label13z);
            panel2.Controls.Add(txtRoom);
            panel2.Controls.Add(textBox_ID);
            panel2.Controls.Add(label38);
            panel2.Controls.Add(txtName);
            resources.ApplyResources(panel2, "panel2");
            panel2.Name = "panel2";
            Text2.AllowEmptyState = false;
            resources.ApplyResources(Text2, "Text2");
            Text2.BackgroundStyle.Class = "DateTimeInputBackground";
            Text2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            Text2.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            Text2.DisplayFormat = "0.00";
            Text2.Increment = 0.0;
            Text2.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            Text2.Name = "Text2";
            Text2.Leave += new System.EventHandler(Text2_Leave);
            Text1.AllowEmptyState = false;
            resources.ApplyResources(Text1, "Text1");
            Text1.BackgroundStyle.Class = "DateTimeInputBackground";
            Text1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            Text1.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            Text1.DisplayFormat = "0.00";
            Text1.Increment = 0.0;
            Text1.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            Text1.Name = "Text1";
            label5.BackColor = System.Drawing.Color.Transparent;
            label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            resources.ApplyResources(label5, "label5");
            label5.Name = "label5";
            resources.ApplyResources(label1, "label1");
            label1.BackColor = System.Drawing.Color.Transparent;
            label1.Name = "label1";
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
            superTabControl_Main1.ControlBox.CloseBox.Name = string.Empty;
            superTabControl_Main1.ControlBox.MenuBox.Name = string.Empty;
            superTabControl_Main1.ControlBox.Name = string.Empty;
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
            imageList1.Images.SetKeyName(0, string.Empty);
            imageList1.Images.SetKeyName(1, string.Empty);
            imageList1.Images.SetKeyName(2, string.Empty);
            imageList1.Images.SetKeyName(3, string.Empty);
            imageList1.Images.SetKeyName(4, string.Empty);
            imageList1.Images.SetKeyName(5, string.Empty);
            imageList1.Images.SetKeyName(6, string.Empty);
            imageList1.Images.SetKeyName(7, string.Empty);
            imageList1.Images.SetKeyName(8, string.Empty);
            imageList1.Images.SetKeyName(9, string.Empty);
            imageList1.Images.SetKeyName(10, string.Empty);
            imageList1.Images.SetKeyName(11, string.Empty);
            imageList1.Images.SetKeyName(12, string.Empty);
            imageList1.Images.SetKeyName(13, string.Empty);
            imageList1.Images.SetKeyName(14, string.Empty);
            imageList1.Images.SetKeyName(15, string.Empty);
            imageList1.Images.SetKeyName(16, string.Empty);
            imageList1.Images.SetKeyName(17, string.Empty);
            imageList1.Images.SetKeyName(18, string.Empty);
            imageList1.Images.SetKeyName(19, string.Empty);
            imageList1.Images.SetKeyName(20, string.Empty);
            imageList1.Images.SetKeyName(21, string.Empty);
            imageList1.Images.SetKeyName(22, string.Empty);
            imageList1.Images.SetKeyName(23, string.Empty);
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
            base.Name = "FrmGuestChPri";
            base.Load += new System.EventHandler(FrmGuestChPri_Load);
            base.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Frm_KeyPress);
            base.KeyDown += new System.Windows.Forms.KeyEventHandler(Frm_KeyDown);
            panelEx2.ResumeLayout(false);
            ribbonBar1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)Text2).EndInit();
            ((System.ComponentModel.ISupportInitialize)Text1).EndInit();
            ribbonBar_Tasks.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)superTabControl_Main1).EndInit();
            panel1.ResumeLayout(false);
            contextMenuStrip2.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}
