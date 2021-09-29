using C1.Win.C1FlexGrid;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.Editors;
using Framework.Data;
using InvAcc.GeneralM;
using InvAcc.Stock_Data;
using Microsoft.Win32;
using SSSDateTime.Date;
using SSSLanguage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial  class FrmChickout : Form
    { void avs(int arln)

{ 
 panelEx2.Text=   (arln == 0 ? "  Click to collapse  " : "  Click to collapse") ; label4.Text=   (arln == 0 ? "  العملـــــــــة :  " : "  work:") ; labelPercentage.Text=   (arln == 0 ? "  %  " : "  %") ; label12z.Text=   (arln == 0 ? "  خصم على :  " : "  discount on:") ; label10z.Text=   (arln == 0 ? "  الإجمالــــي :  " : "  Total:") ; label14z.Text=   (arln == 0 ? "  الصــــافي :  " : "  net:") ; label3.Text=   (arln == 0 ? "  المدفوعات :  " : "  Payments:") ; label9z.Text=   (arln == 0 ? "  الخصــــــم :  " : "  Discount:") ; label21.Text=   (arln == 0 ? "  إجمالي فترة الإقامة  " : "  Total length of stay") ; label20.Text=   (arln == 0 ? "  أيام السكن  " : "  Residence days") ; label18.Text=   (arln == 0 ? "  سعر الغرفة  " : "  room price") ; labelD1.Text=   (arln == 0 ? "  المدين :  " : "  Debtor:") ; labelC1.Text=   (arln == 0 ? "  الدائن :  " : "  creditor:") ; label7z.Text=   (arln == 0 ? "  الخصم :  " : "  Discount :") ; label6z.Text=   (arln == 0 ? "  تاريخ السكن :  " : "  Residence date:") ; label5z.Text=   (arln == 0 ? "  حساب النزيل :  " : "  Guest account:") ; label13z.Text=   (arln == 0 ? "  رقم الغرفة :  " : "  room number :") ; label1.Text=   (arln == 0 ? "  نوع التسكين :  " : "  Soothing type:") ; label2.Text=   (arln == 0 ? "  طريقة الدفع :  " : "  Payment method :") ; label36.Text=   (arln == 0 ? "  إسم النزيل :  " : "  Guest name:") ; label22.Text=   (arln == 0 ? "  تفـــاصيـــــل حســــاب النزيـــــل  " : "  Guest account details") ; superTabControl_Main1.Text=   (arln == 0 ? "  superTabControl3  " : "  superTabControl3") ; Button_Close.Text=   (arln == 0 ? "  إغلاق  " : "  Close") ; Button_GaidSerf.Text=   (arln == 0 ? "  سند صرف نزيل  " : "  Guest voucher") ; Button_GaidGabth.Text=   (arln == 0 ? "  سند قبض نزيل  " : "  guest receipt voucher") ; Button_Save.Text=   (arln == 0 ? "  مغادرة  " : "  Leaving") ; buttonItem_EditDays.Text=   (arln == 0 ? "  تعديل عدد أيام الإقامة  " : "  Modify the number of days of stay") ; Button_GaidGabthAcc.Text=   (arln == 0 ? "  قبض محاسبي  " : "  Accounting Receipt") ; ToolStripMenuItem_Rep.Text=   (arln == 0 ? "  إظهار التقرير  " : "  Show report") ; ToolStripMenuItem_Det.Text=   (arln == 0 ? "  إظهار التفاصيل  " : "  Show details") ; Text = "مغادرة النزلاء";this.Text=   (arln == 0 ? "  مغادرة النزلاء  " : "  Guests leaving") ;}
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
        private PanelEx panelEx2;
        private RibbonBar ribbonBar1;
        private RibbonBar ribbonBar_Tasks;
        private SuperTabControl superTabControl_Main1;
        protected ButtonItem Button_Close;
        protected ButtonItem Button_GaidSerf;
        protected ButtonItem Button_GaidGabth;
        protected ButtonItem Button_Save;
        private Panel panel2;
        internal Label label6z;
        private MaskedTextBox txtDate;
        private TextBox txtGuestAcc;
        internal Label label5z;
        private TextBox txtRoom;
        internal Label label13z;
        private Label label1;
        private Label label2;
        private ComboBoxEx comboBox_RoomTyp;
        private ComboBoxEx Cmb_PayMethod;
        protected TextBox txtName;
        protected Label label36;
        private C1FlexGrid VS1;
        private C1FlexGrid VS;
        private Label label14z;
        private DoubleInput Label17;
        private Label label3;
        private DoubleInput Label15;
        private ComboBoxEx comboBox_DisTo;
        internal Label label12z;
        private ComboBoxEx comboBox_DisType;
        private Label label10z;
        private DoubleInput Label14;
        private Label label9z;
        private DoubleInput Text1;
        private Label label7z;
        private DoubleInput Label6;
        private DoubleInput Label12;
        private DoubleInput Label10;
        private DoubleInput Label19;
        private DoubleInput Label5;
        private DoubleInput Label8;
        private DoubleInput Label9;
        private DoubleInput Label11;
        private DoubleInput Label13;
        private DoubleInput Label16;
        private DoubleInput Label7;
        protected ButtonItem buttonItem_EditDays;
        private Label labelPercentage;
        private SwitchButton switchButton_Lock;
        private Panel panel_Gaid;
        private TextBoxX txtDebit1;
        private TextBoxX txtCredit1;
        internal Label labelD1;
        internal Label labelC1;
        private Label label4;
        private ComboBoxEx CmbCurr;
        private DoubleInput txtroomTot;
        protected Label label21;
        private DoubleInput txtroomDays;
        protected Label label20;
        private DoubleInput txtroomPrice;
        protected Label label18;
        private Panel panel3;
        internal Label label22;
        protected ButtonItem Button_GaidGabthAcc;
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
        private T_GDHEAD data_this;
        private T_Snd data_this_Snd;
        private List<string> pkeys = new List<string>();
        private Stock_DataDataContext dbInstance;
        private Rate_DataDataContext dbInstanceRate;
        private int R1;
        private int R2;
        private int R3;
        private int R4;
        private int Fin;
        private int M;
        private int Mm;
        private T_Rom RoomOp = new T_Rom();
        private T_per PerOp = new T_per();
        private double Tot = 0.0;
        private double TotResturant = 0.0;
        private T_GDHEAD _GdHead2 = new T_GDHEAD();
        private T_GDHEAD _GdHead = new T_GDHEAD();
        private List<T_GDHEAD> listGdHead = new List<T_GDHEAD>();
        private T_GDDET _GdDet = new T_GDDET();
        private List<T_GDDET> listGdDet = new List<T_GDDET>();
        private ScriptNumber ScriptNumber1 = new ScriptNumber();
        public Dictionary<string, ColumnDictinary> columns_Names_visible2 = new Dictionary<string, ColumnDictinary>();
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
        public bool IfAdd
        {
            set
            {
            }
        }
        public bool IfDelete
        {
            set
            {
                Button_GaidGabth.Visible = value;
                superTabControl_Main1.Refresh();
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
        private void Frm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                SendKeys.Send("{Tab}");
            }
        }
        private void Frm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.F1)
            {
                if (e.KeyCode == Keys.F2 && Button_Save.Enabled && Button_Save.Visible && State != 0)
                {
                    Button_Save_Click(sender, e);
                }
                else if (e.KeyCode != Keys.F5 && e.KeyCode == Keys.Escape)
                {
                    Close();
                }
            }
        }
        public FrmChickout()
        {
            InitializeComponent();this.Load += langloads;
        }
        private void RibunButtons()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                Button_Close.Text = "اغلاق";
                Button_GaidGabth.Text = "سند قبض نزيل";
                Button_Save.Text = "مغادرة";
                Button_GaidSerf.Text = "سند صرف نزيل";
                Button_Close.Tooltip = "Esc";
                Button_GaidGabth.Tooltip = "F3";
                Button_Save.Tooltip = "F2";
                Button_GaidSerf.Tooltip = "F4";
                switchButton_Lock.OffText = "إنشاء قيد محاسبي";
                switchButton_Lock.OnText = "إنشاء قيد محاسبي";
                Button_GaidGabthAcc.Text = "قبض محاسبي";
                Text = "مغادرة النزلاء";
            }
            else
            {
                Button_Close.Text = "Close";
                Button_GaidGabth.Text = "arrest Guest";
                Button_Save.Text = "Leave";
                Button_GaidSerf.Text = "Exchange Guest";
                Button_Close.Tooltip = "Esc";
                Button_GaidGabth.Tooltip = "F3";
                Button_Save.Tooltip = "F2";
                Button_GaidSerf.Tooltip = "F4";
                VS1.Cols[0].Caption = "Room No";
                VS1.Cols[1].Caption = "Rent";
                VS1.Cols[2].Caption = "Days";
                VS1.Cols[3].Caption = "Tax";
                VS1.Cols[4].Caption = "Service Ratio";
                VS1.Cols[5].Caption = "Total";
                buttonItem_EditDays.Text = "Modify days";
                switchButton_Lock.OffText = "Create an accounting record";
                switchButton_Lock.OnText = "Create an accounting record";
                Button_GaidGabthAcc.Text = "catch Acc";
                VS.Cols[0].Caption = "Service Name";
                VS.Cols[1].Caption = "Total services";
                Text = "Guests Leaving";
            }
        }
        private void FrmChickout_Load(object sender, EventArgs e)
        {
            try
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmChickout));
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
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                {
                    List<T_Curency> listAccCat = new List<T_Curency>(db.T_Curencies.Select((T_Curency item) => item).ToList());
                    CmbCurr.DataSource = listAccCat;
                    CmbCurr.DisplayMember = "Arb_Des";
                    CmbCurr.ValueMember = "Curency_ID";
                }
                else
                {
                    List<T_Curency> listCurr = new List<T_Curency>(db.T_Curencies.Select((T_Curency item) => item).ToList());
                    CmbCurr.DataSource = listCurr;
                    CmbCurr.DisplayMember = "Eng_Des";
                    CmbCurr.ValueMember = "Curency_ID";
                }
                CmbCurr.SelectedIndex = 0;
                if (VarGeneral.vDemo && VarGeneral.UserID != 1)
                {
                    buttonItem_EditDays.Visible = false;
                }
                VarGeneral.Day1 = 0;
                VarGeneral.DayEdit = 0;
                R1 = VarGeneral.Trn;
                R2 = VarGeneral._hotelrom;
                R3 = VarGeneral._hotelper;
                SetData();
                VS.RowSel = 3;
                VS.Row = 3;
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
                PerOp = new T_per();
                RoomOp = new T_Rom();
                double aa = 0.0;
                M = 1;
                FillCombo();
                txtRoom.Text = VarGeneral._hotelrom.ToString();
                RoomOp = db.StockRoom(VarGeneral._hotelrom);
                PerOp = db.StockPer(VarGeneral._hotelper);
                comboBox_DisType.SelectedIndex = PerOp.disknd.Value;
                comboBox_DisTo.SelectedIndex = PerOp.distyp.Value;
                comboBox_RoomTyp.SelectedIndex = PerOp.KindPer.Value;
                if (PerOp.DayOfM.HasValue)
                {
                    VarGeneral.GDayM = PerOp.DayOfM.Value;
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
                if (!string.IsNullOrEmpty(PerOp.Cust_no))
                {
                    txtGuestAcc.Text = PerOp.Cust_no.ToString();
                }
                else
                {
                    txtGuestAcc.Text = "";
                }
                txtName.Text = PerOp.nm;
                Cmb_PayMethod.SelectedIndex = PerOp.cc.Value;
                Label6.Value = PerOp.price.Value;
                Label10.Value = PerOp.ser.Value;
                Label12.Value = PerOp.tax.Value;
                txtDate.Text = PerOp.dt2;
                List<T_sertyp> q = db.T_sertyps.Select((T_sertyp t) => t).ToList();
                VS.Rows.Count = q.Count + 6;
                VS.SetData(1, 0, (LangArEn == 0) ? "إجمالي قيمة فترة الإقامة" : "Residence");
                VS.SetData(2, 0, (LangArEn == 0) ? "إجمالي قيمة الضريبة" : "Tax");
                VS.SetData(3, 0, (LangArEn == 0) ? "إجمالي قيمة الخدمات الإضافية" : "service");
                VS.SetData(4, 0, (LangArEn == 0) ? "المكالمات الهاتفية" : "Phones");
                VS.SetData(5, 0, (LangArEn == 0) ? "المطلوب من حركات محاسبية أخرى" : "Required from other accounting movements");
                VS.SetCellStyle(5, 1, "SubTotal0");
                VS.SetData(1, 2, "401001");
                VS.SetData(2, 2, "401002");
                VS.SetData(3, 2, "401003");
                VS.SetData(4, 2, "401004");
                VS.SetData(5, 2, "401005");
                VS.Rows[0].Visible = false;
                VS.Rows[2].Visible = false;
                VS.Rows[3].Visible = false;
                aa = q.Count;
                for (int i = 6; i < VS.Rows.Count; i++)
                {
                    VS.SetData(i, 0, (LangArEn == 0) ? q[i - 6].Arb_Des : q[i - 6].Eng_Des);
                    VS.SetData(i, 1, 0);
                    VS.SetData(i, 2, q[i - 6].Serv_No);
                }
                if (VarGeneral.Day1 == 0)
                {
                    if (comboBox_RoomTyp.SelectedIndex == 0)
                    {
                        aa = VarGeneral.Dy(PerOp.dt2, PerOp.tm1 + " " + PerOp.vAmPm);
                    }
                    else
                    {
                        VarGeneral.Dy(PerOp.dt2, PerOp.tm1 + " " + PerOp.vAmPm);
                        VarGeneral.Dy2(PerOp.dt2, PerOp.tm1 + " " + PerOp.vAmPm);
                    }
                    Label19.Value = aa;
                }
                else if (comboBox_RoomTyp.SelectedIndex == 0)
                {
                    aa = Label19.Value;
                }
                else
                {
                    aa = Label19.Value;
                    VarGeneral.Dy3();
                }
                double TotP1 = ((comboBox_RoomTyp.SelectedIndex != 0) ? (PerOp.price.Value * (double)VarGeneral.CS) : (PerOp.price.Value * aa));
                Label5.Value = aa;
                Text1.Value = PerOp.dis.Value;
                if (VS1.Rows.Count < 2)
                {
                    VS1.Rows.Add();
                }
                VS1.SetData(1, 0, PerOp.romno);
                VS1.SetData(1, 1, PerOp.price);
                txtroomPrice.Value = PerOp.price.Value;
                VS1.SetData(1, 2, aa);
                txtroomDays.Value = aa;
                VS1.SetData(1, 3, PerOp.tax);
                VS1.SetData(1, 4, PerOp.ser);
                VS1.SetData(1, 5, TotP1);
                txtroomTot.Value = TotP1;
                Total();
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("SetData:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void Total()
        {
            double tot11 = 0.0;
            double tot12 = 0.0;
            double tot13 = 0.0;
            double Tot1 = 0.0;
            double Tot3 = 0.0;
            double Tot4 = 0.0;
            double Tot5 = 0.0;
            double Tot6 = 0.0;
            double Tot7 = 0.0;
            double Tot8 = 0.0;
            double Tot9 = 0.0;
            double Tot2 = 0.0;
            TotResturant = 0.0;
            for (int i = 5; i < VS.Rows.Count; i++)
            {
                try
                {
                    List<double> sqlst = db.ExecuteQuery<double>("select sum(price) as SumPrice from [T_tran] where perno=" + VarGeneral._hotelper + " and typ = " + VS.GetData(i, 2), new object[0]).ToList();
                    if (sqlst.Count > 0)
                    {
                        tot11 = ((!string.IsNullOrEmpty(sqlst.FirstOrDefault().ToString())) ? sqlst.FirstOrDefault() : 0.0);
                        Tot1 += tot11;
                        VS.SetData(i, 1, tot11);
                    }
                }
                catch
                {
                }
            }
            try
            {
                List<double> sqlst = db.ExecuteQuery<double>("select sum(price) as SumPrice from [T_tel] where perno=" + VarGeneral._hotelper, new object[0]).ToList();
                if (sqlst.Count > 0)
                {
                    Tot3 = ((!string.IsNullOrEmpty(sqlst.FirstOrDefault().ToString())) ? sqlst.FirstOrDefault() : 0.0);
                }
                VS.SetData(4, 1, Tot3);
            }
            catch
            {
                Tot3 = 0.0;
                VS.SetData(4, 1, Tot3);
            }
            try
            {
                List<double> sqlst = db.ExecuteQuery<double>("SELECT Sum(case when [T_Snd].[typ]=1 then [T_Snd].[price]*[T_Snd].[curcost] else -[T_Snd].[price]*[T_Snd].[curcost] end) AS SumPrice FROM [T_Snd] where perno=" + VarGeneral._hotelper + " and ch<>3", new object[0]).ToList();
                if (sqlst.Count > 0)
                {
                    Tot4 = ((!string.IsNullOrEmpty(sqlst.FirstOrDefault().ToString())) ? sqlst.FirstOrDefault() : 0.0);
                }
            }
            catch
            {
                Tot4 = 0.0;
            }
            try
            {
                Stock_DataDataContext _DB = new Stock_DataDataContext(VarGeneral.BranchCS);
                List<T_AccDef> sqlst2 = (from er in _DB.T_AccDefs
                                         where er.AccDef_No == txtGuestAcc.Text
                                         orderby er.AccDef_No
                                         select er).ToList();
                if (sqlst2.Count() > 0)
                {
                    sqlst2.First().Debit = sqlst2.First().T_GDDETs.Where((T_GDDET g) => !g.T_GDHEAD.gdLok && g.T_AccDef.Lev == 4 && g.gdValue > 0.0 && g.T_GDHEAD.gdTyp != 15 && g.T_GDHEAD.gdTyp != 27 && g.T_GDHEAD.gdTyp != 28).Sum((T_GDDET g) => g.gdValue.Value);
                    sqlst2.First().Credit = Math.Abs(sqlst2.First().T_GDDETs.Where((T_GDDET g) => !g.T_GDHEAD.gdLok && g.T_AccDef.Lev == 4 && g.gdValue < 0.0 && g.T_GDHEAD.gdTyp != 15 && g.T_GDHEAD.gdTyp != 27 && g.T_GDHEAD.gdTyp != 28).Sum((T_GDDET g) => g.gdValue.Value));
                    sqlst2.First().Balance = sqlst2.First().T_GDDETs.Where((T_GDDET g) => !g.T_GDHEAD.gdLok && g.T_AccDef.Lev == 4 && g.T_GDHEAD.gdTyp != 15 && g.T_GDHEAD.gdTyp != 27 && g.T_GDHEAD.gdTyp != 28).Sum((T_GDDET g) => g.gdValue.Value);
                }
                if (sqlst2.Count > 0)
                {
                    TotResturant = sqlst2.FirstOrDefault().Balance.Value;
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
            Label8.Value = Tot1;
            Label9.Value = Tot3;
            Label15.Value = Tot4;
            for (int i = 1; i < VS1.Rows.Count; i++)
            {
                Tot5 += double.Parse(VS1.GetData(i, 5).ToString());
                tot12 += Tot5 * double.Parse(VS1.GetData(i, 3).ToString()) / 100.0;
                tot13 += Tot5 * double.Parse(VS1.GetData(i, 4).ToString()) / 100.0;
            }
            Tot6 = tot12;
            Tot7 = tot13;
            tot12 = 0.0;
            tot13 = 0.0;
            Tot2 = Tot1 + Tot3 + Tot5 + Tot6 + Tot7;
            if (comboBox_DisType.SelectedIndex == 1)
            {
                if (comboBox_DisTo.SelectedIndex == 0)
                {
                    Tot8 = Tot5 * Text1.Value / 100.0;
                    Tot5 -= Tot8;
                    Tot6 = Tot5 * (double)RoomOp.tax.Value / 100.0;
                    Tot7 = Tot5 * (double)RoomOp.ser.Value / 100.0;
                }
                else if (comboBox_DisTo.SelectedIndex == 1)
                {
                    Tot9 = Tot2 * Text1.Value / 100.0;
                }
            }
            else if (comboBox_DisType.SelectedIndex == 2)
            {
                if (comboBox_DisTo.SelectedIndex == 0)
                {
                    Tot8 = Text1.Value * Label5.Value;
                    Tot5 -= Tot8;
                    Tot6 = Tot5 * (double)RoomOp.tax.Value / 100.0;
                    Tot7 = Tot5 * (double)RoomOp.ser.Value / 100.0;
                }
                else if (comboBox_DisTo.SelectedIndex == 1)
                {
                    Tot9 = Text1.Value;
                }
            }
            if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 48))
            {
                Label14.Value = Tot1 + Tot3 + Tot5 + Tot6 + Tot7 + TotResturant;
                Tot2 = Tot1 + Tot3 + Tot5 + Tot6 + Tot7 + TotResturant - Tot9;
            }
            else
            {
                Label14.Value = Tot1 + Tot3 + Tot5 + Tot6 + Tot7;
                Tot2 = Tot1 + Tot3 + Tot5 + Tot6 + Tot7 - Tot9;
            }
            Label11.Value = Tot6;
            Label13.Value = Tot7;
            Label16.Value = Tot8 + Tot9;
            Tot = Tot2 - Tot4;
            Tot2 = ((!VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 48)) ? (Tot1 + Tot3 + Tot5 + Tot6 + Tot7 - Tot9) : (Tot1 + Tot3 + Tot5 + Tot6 + Tot7 + TotResturant - Tot9));
            Label11.Value = Tot6;
            Label13.Value = Tot7;
            Label16.Value = Tot8 + Tot9;
            Label7.Value = Tot5;
            Tot = Tot2 - Tot4;
            VS.SetData(1, 1, Label7.Value);
            VS.SetData(2, 1, Label11.Value);
            VS.SetData(3, 1, Label13.Value);
            VS.SetData(4, 1, Label9.Value);
            VS.SetData(5, 1, TotResturant);
            if (TotResturant > 0.0)
            {
                Button_GaidGabthAcc.Visible = true;
            }
            else
            {
                Button_GaidGabthAcc.Visible = false;
            }
            Label15.Value = Tot4;
            Label17.Value = Tot;
            if (Label17.Value < 0.0)
            {
                Label17.ForeColor = Color.Red;
            }
            else
            {
                Label17.ForeColor = Color.Blue;
            }
            if (Label17.Value <= 0.0 || Cmb_PayMethod.SelectedIndex > 0)
            {
                Button_Save.Enabled = true;
                Button_Save.Focus();
            }
            else
            {
                Button_Save.Enabled = false;
            }
        }
        public void FillCombo()
        {
            Cmb_PayMethod.Items.Clear();
            Cmb_PayMethod.Items.Add((LangArEn == 0) ? "نقــدي" : "Cash");
            Cmb_PayMethod.Items.Add((LangArEn == 0) ? "آجــــل" : "Credit");
            Cmb_PayMethod.SelectedIndex = 0;
            comboBox_DisType.Items.Clear();
            comboBox_DisType.Items.Add((LangArEn == 0) ? "بدون خصم" : "Without Discount");
            comboBox_DisType.Items.Add((LangArEn == 0) ? "خصم نسبة" : "Discount %");
            comboBox_DisType.Items.Add((LangArEn == 0) ? "خصم قيمة" : "Discount Value");
            comboBox_DisType.SelectedIndex = 0;
            comboBox_DisTo.Items.Clear();
            comboBox_DisTo.Items.Add((LangArEn == 0) ? "قيمة الإقامة" : "Residence Value");
            comboBox_DisTo.Items.Add((LangArEn == 0) ? "الإجمالي" : "Total");
            comboBox_DisTo.SelectedIndex = 0;
            comboBox_RoomTyp.Items.Clear();
            comboBox_RoomTyp.Items.Add((LangArEn == 0) ? "يومي" : "Daily");
            comboBox_RoomTyp.Items.Add((LangArEn == 0) ? "شهري" : "Monthly");
            comboBox_RoomTyp.SelectedIndex = -1;
        }
        private T_Snd GetData()
        {
            data_this_Snd = new T_Snd();
            data_this_Snd.fNo = db.MaxSndNo;
            try
            {
                data_this_Snd.curr = int.Parse(CmbCurr.SelectedValue.ToString());
            }
            catch
            {
                data_this_Snd.curr = null;
            }
            data_this_Snd.perno = VarGeneral._hotelper;
            data_this_Snd.SndName = txtName.Text;
            data_this_Snd.romno = int.Parse(txtRoom.Text);
            data_this_Snd.price = Label17.Value;
            data_this_Snd.typ = VarGeneral.SndTyp;
            data_this_Snd.typN = 0;
            data_this_Snd.det = "مغادرة نزيل آجل || Departure of a guest";
            data_this_Snd.ShekDate = "";
            data_this_Snd.ShekNo = "";
            if (switchButton_Lock.Value)
            {
                data_this_Snd.ShekBank = "1";
            }
            else
            {
                data_this_Snd.ShekBank = "0";
            }
            data_this_Snd.curcost = 1.0;
            data_this_Snd.ch = 1;
            T_Snd t_Snd = data_this_Snd;
            int? calendr = VarGeneral.Settings_Sys.Calendr;
            t_Snd.dt = ((calendr.Value == 0 && calendr.HasValue) ? n.FormatGreg(VarGeneral.Gdate, "yyyy/MM/dd") : n.FormatHijri(VarGeneral.Hdate, "yyyy/MM/dd"));
            data_this_Snd.tm = DateTime.Now.ToString("HH:mm");
            data_this_Snd.Usr = VarGeneral.UserNo;
            data_this_Snd.IfTrans = 0;
            return data_this_Snd;
        }
        private T_GDHEAD GetDataGd(double _val, int maxGd)
        {
            _GdHead2.gdHDate = VarGeneral.Hdate;
            _GdHead2.gdGDate = VarGeneral.Gdate;
            _GdHead2.gdNo = maxGd.ToString();
            _GdHead2.ArbTaf = ScriptNumber1.ScriptNum(decimal.Parse("0" + _val));
            _GdHead2.BName = _GdHead2.BName;
            _GdHead2.ChekNo = "GuestLeave";
            _GdHead2.CurTyp = 1;
            _GdHead2.EngTaf = ScriptNumber1.TafEng(decimal.Parse("0" + _val));
            _GdHead2.gdCstNo = 1;
            _GdHead2.gdID = 0;
            _GdHead2.gdLok = false;
            _GdHead2.gdMem = "قيد تلقائي لعملية مغادرة نزيل بقيمة إجمالي فترة الإقامة  | Auto Bound to check-out of the total stay ";
            _GdHead2.gdMnd = null;
            _GdHead2.gdRcptID = (_GdHead2.gdRcptID.HasValue ? _GdHead2.gdRcptID.Value : 0.0);
            _GdHead2.gdTot = _val;
            _GdHead2.gdTp = (_GdHead2.gdTp.HasValue ? _GdHead2.gdTp.Value : 0);
            _GdHead2.gdTyp = 15;
            _GdHead2.RefNo = "";
            _GdHead2.AdminLock = true;
            _GdHead2.DATE_MODIFIED = DateTime.Now;
            _GdHead2.salMonth = "";
            _GdHead2.gdUser = VarGeneral.UserNumber;
            _GdHead2.gdUserNam = VarGeneral.UserNameA;
            _GdHead2.CompanyID = 1;
            return _GdHead2;
        }
        private bool CheckRemotDate()
        {
            try
            {
                if (VarGeneral.gUserName != "runsetting")
                {
                    bool User_Remotly = CheckUserIFRemote();
                    RegistryKey hKeyNew = Registry.CurrentUser.OpenSubKey("Software\\MrdHrdw\\ItIntel", writable: true);
                    RegistryKey hKey = Registry.CurrentUser.OpenSubKey("Software\\PRS AND PR Settings\\WinSystemOperation", writable: true);
                    long regval = 0L;
                    long regvalNew = 0L;
                    if (hKey != null)
                    {
                        try
                        {
                            object q = hKey.GetValue("vRemotly");
                            if (string.IsNullOrEmpty(q.ToString()))
                            {
                                hKey.CreateSubKey("vRemotly");
                                hKey.SetValue("vRemotly", "0");
                            }
                        }
                        catch
                        {
                            hKey.CreateSubKey("vRemotly");
                            hKey.SetValue("vRemotly", "0");
                        }
                        try
                        {
                            object t = hKeyNew.GetValue("vRemotly_New");
                            if (string.IsNullOrEmpty(t.ToString()))
                            {
                                hKeyNew.CreateSubKey("vRemotly_New");
                                hKeyNew.SetValue("vRemotly_New", "0");
                            }
                        }
                        catch
                        {
                            hKeyNew.CreateSubKey("vRemotly_New");
                            hKeyNew.SetValue("vRemotly_New", "0");
                        }
                        regval = long.Parse(hKey.GetValue("vRemotly").ToString());
                        regvalNew = long.Parse(hKeyNew.GetValue("vRemotly_New").ToString());
                    }
                    if (User_Remotly || regval == 1 || regvalNew == 1)
                    {
                        try
                        {
                            if (VarGeneral.vDemo)
                            {
                                return false;
                            }
                            string dtAction = n.HDateNow("yyyy/MM/dd");
                            if (Convert.ToDateTime(n.GregToHijri(hKeyNew.GetValue("vBackup_New").ToString(), "yyyy/MM/dd")) < Convert.ToDateTime(n.FormatHijri(dtAction, "yyyy/MM/dd")))
                            {
                                MessageBox.Show((LangArEn == 0) ? "لا يمكن إتمام العملية .. لقد تخطيت السنة المالية المحدد للنظام \n يرجى التواصل مع الإدارة لللإشتراك في خدمات النسخة " : "We can not complete the operation .. have you skip the fiscal year specified for the system", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                return false;
                            }
                        }
                        catch
                        {
                            MessageBox.Show((LangArEn == 0) ? "لا يمكن إتمام العملية .. لقد تخطيت السنة المالية المحدد للنظام \n يرجى التواصل مع الإدارة لللإشتراك في خدمات النسخة " : "We can not complete the operation .. have you skip the fiscal year specified for the system", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            return false;
                        }
                    }
                }
            }
            catch
            {
                return false;
            }
            return true;
        }
        private bool CheckUserIFRemote()
        {
            try
            {
               return false; if (SystemInformation.TerminalServerSession)
                {
                    return true;
                }
                return false;
            }
            catch
            {
                return true;
            }
        }
        private void Button_Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (false)
                {
                    Environment.Exit(0);
                    return;
                }
                int maxGd = 1;
                if (!VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 70) && txtroomTot.Value > 0.0)
                {
                    try
                    {
                        string AccCrdt = "";
                        string AccDbt = "";
                        if (txtroomTot.Value > 0.0)
                        {
                            try
                            {
                                AccCrdt = VarGeneral.Settings_Sys.GuestBoxAcc;
                            }
                            catch
                            {
                                AccCrdt = "";
                            }
                            try
                            {
                                AccDbt = db.StockPer(PerOp.perno).Cust_no;
                            }
                            catch
                            {
                                AccDbt = "";
                            }
                        }
                        if (AccCrdt == "" && txtroomTot.Value > 0.0)
                        {
                            MessageBox.Show((LangArEn == 0) ? "لا يمكن إتمام العملية .. تأكد من صحة الطرف الدائن للقيد .. " : "You can not complete the operation .. Make sure the creditor under the party ..", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            return;
                        }
                        if (AccDbt == "" && txtroomTot.Value > 0.0)
                        {
                            MessageBox.Show((LangArEn == 0) ? "لا يمكن إتمام العملية .. تأكد من صحة الطرف المدين للقيد .. " : "You can not complete the operation .. Make sure the debtor under the party ..", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            return;
                        }
                        if (txtroomTot.Value > 0.0 && !string.IsNullOrEmpty(AccCrdt) && !string.IsNullOrEmpty(AccDbt))
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
                            GetDataGd(txtroomTot.Value, maxGd);
                            _GdHead2.DATE_CREATED = DateTime.Now;
                            dbc.T_GDHEADs.InsertOnSubmit(_GdHead2);
                            dbc.SubmitChanges();
                            if (txtroomTot.Value > 0.0 && !string.IsNullOrEmpty(AccCrdt) && !string.IsNullOrEmpty(AccDbt))
                            {
                                db_.StartTransaction();
                                db_.ClearParameters();
                                db_.AddParameter("GDDET_ID", DbType.Int32, 0);
                                db_.AddParameter("gdID", DbType.Int32, _GdHead2.gdhead_ID);
                                db_.AddParameter("gdNo", DbType.String, maxGd);
                                db_.AddParameter("gdDes", DbType.String, "قيد تلقائي (مغادرة نزيل) بقيمة إجمالي فترة الإقامة غرفة/شقة  " + txtRoom.Text);
                                db_.AddParameter("gdDesE", DbType.String, "Automatic entry with total value of room / apartment stay period" + txtRoom.Text);
                                db_.AddParameter("recptTyp", DbType.String, "1");
                                db_.AddParameter("AccNo", DbType.String, AccCrdt);
                                db_.AddParameter("AccName", DbType.String, "");
                                db_.AddParameter("gdValue", DbType.Double, 0.0 - txtroomTot.Value);
                                db_.AddParameter("recptNo", DbType.String, maxGd);
                                db_.AddParameter("Lin", DbType.Int32, 1);
                                db_.AddParameter("AccNoDestruction", DbType.String, null);
                                db_.ExecuteNonQueryWithoutCommit(storedProcedure: true, "S_T_GDDET_INSERT");
                                db_.EndTransaction();
                                db_.StartTransaction();
                                db_.ClearParameters();
                                db_.AddParameter("GDDET_ID", DbType.Int32, 0);
                                db_.AddParameter("gdID", DbType.Int32, _GdHead2.gdhead_ID);
                                db_.AddParameter("gdNo", DbType.String, maxGd);
                                db_.AddParameter("gdDes", DbType.String, "قيد تلقائي (مغادرة نزيل) بقيمة إجمالي فترة الإقامة غرفة/شقة  " + txtRoom.Text);
                                db_.AddParameter("gdDesE", DbType.String, "Automatic entry with total value of room / apartment stay period" + txtRoom.Text);
                                db_.AddParameter("recptTyp", DbType.String, "1");
                                db_.AddParameter("AccNo", DbType.String, AccDbt);
                                db_.AddParameter("AccName", DbType.String, "");
                                db_.AddParameter("gdValue", DbType.Double, txtroomTot.Value);
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
                PerOp.ch = 3;
                PerOp.ps2 = VarGeneral.UserNo;
                PerOp.tm2 = DateTime.Now.ToString("hh:mm:ss tt");
                T_per perOp = PerOp;
                int? calendr = VarGeneral.Settings_Sys.Calendr;
                perOp.dt3 = ((calendr.Value == 0 && calendr.HasValue) ? n.FormatGreg(VarGeneral.Gdate, "yyyy/MM/dd") : n.FormatHijri(VarGeneral.Hdate, "yyyy/MM/dd"));
                PerOp.dis = Text1.Value;
                PerOp.disknd = comboBox_DisType.SelectedIndex;
                PerOp.distyp = comboBox_DisTo.SelectedIndex;
                PerOp.DayEdit = VarGeneral.DayEdit;
                if (Cmb_PayMethod.SelectedIndex > 0)
                {
                    PerOp.cc = 2;
                    PerOp.fat = 0.0;
                }
                else
                {
                    PerOp.fat = Label15.Value;
                }
                if (comboBox_RoomTyp.SelectedIndex == 0)
                {
                    PerOp.DayOfM = null;
                }
                PerOp.Totel = int.Parse((Label17.Value - TotResturant).ToString());
                PerOp.price = Label6.Value;
                PerOp.KindPer = comboBox_RoomTyp.SelectedIndex;
                if (!PerOp.DayOfM.HasValue && comboBox_RoomTyp.SelectedIndex == 1)
                {
                    PerOp.DayOfM = VarGeneral.GDayM;
                }
                if (comboBox_RoomTyp.SelectedIndex == 0)
                {
                    PerOp.DayOfM = null;
                }
                RoomOp.price = Label6.Value;
                db.Log = VarGeneral.DebugLog;
                db.SubmitChanges(ConflictMode.ContinueOnConflict);
                for (int i = 1; i < VS1.Rows.Count; i++)
                {
                    T_romtrn dataThis_RomTrn = new T_romtrn();
                    db.EmptyRom(int.Parse(VS1.GetData(i, 0).ToString()));
                    dataThis_RomTrn.ID = db.MaxRomTrnNo;
                    dataThis_RomTrn.romno1 = int.Parse(VS1.GetData(i, 0).ToString());
                    dataThis_RomTrn.romno2 = null;
                    dataThis_RomTrn.perno = PerOp.perno;
                    calendr = VarGeneral.Settings_Sys.Calendr;
                    dataThis_RomTrn.dt = ((calendr.Value == 0 && calendr.HasValue) ? VarGeneral.Gdate : VarGeneral.Hdate);
                    dataThis_RomTrn.tm = DateTime.Now.ToString("hh:mm:ss tt");
                    dataThis_RomTrn.Usr = VarGeneral.UserNumber;
                    dataThis_RomTrn.typ = 3;
                    dataThis_RomTrn.UsrNam = ((LangArEn == 0) ? VarGeneral.UserNameA : VarGeneral.UserNameE);
                    db.T_romtrns.InsertOnSubmit(dataThis_RomTrn);
                    db.SubmitChanges();
                }
                if (Cmb_PayMethod.SelectedIndex > 0 && Label17.Value - TotResturant > 0.0)
                {
                }
                if (MessageBox.Show((LangArEn == 0) ? "سيتم طباعة كشف حساب نزيل .. هل تريد المتابعة ؟" : "A guest account statement will be printed .. Do you want to continue? ", VarGeneral.ProdectNam, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    FrmRepRevenue frm = new FrmRepRevenue(13);
                    frm.Tag = LangArEn;
                    frm.Text = ((LangArEn == 0) ? "كشف حساب نزيل" : "Guest account statement");
                    frm.tp = 13;
                    frm.FillCombo();
                    frm.comboBox_AdvancStatus.SelectedIndex = 1;
                    frm.txtUserNo.Text = R3.ToString();
                    frm.SerTypeCount += db.FillServTyp_2("").ToList().Count;
                    frm.ButOk_Click(sender, e);
                }
                Close();
            }
            catch (Exception error2)
            {
                VarGeneral.DebLog.writeLog("Save:", error2, enable: true);
                MessageBox.Show(error2.Message);
            }
        }
        private T_GDHEAD GetDataGd()
        {
            _GdHead = new T_GDHEAD();
            _GdHead.gdHDate = VarGeneral.Hdate;
            _GdHead.gdGDate = VarGeneral.Gdate;
            _GdHead.gdNo = data_this_Snd.fNo.ToString();
            _GdHead.ArbTaf = ScriptNumber1.ScriptNum(decimal.Parse("0" + Label17.Value));
            _GdHead.BName = _GdHead.BName;
            _GdHead.ChekNo = _GdHead.ChekNo;
            _GdHead.CurTyp = int.Parse(CmbCurr.SelectedValue.ToString());
            _GdHead.EngTaf = ScriptNumber1.TafEng(decimal.Parse("0" + Label17.Value));
            _GdHead.gdCstNo = 1;
            _GdHead.gdID = 0;
            _GdHead.gdLok = false;
            _GdHead.gdMem = "مغادرة نزيل آجل || Departure of a guest";
            _GdHead.gdMnd = null;
            _GdHead.gdRcptID = (_GdHead.gdRcptID.HasValue ? _GdHead.gdRcptID.Value : 0.0);
            _GdHead.gdTot = Label17.Value;
            _GdHead.gdTp = (_GdHead.gdTp.HasValue ? _GdHead.gdTp.Value : 0);
            _GdHead.gdTyp = VarGeneral.InvTyp;
            _GdHead.RefNo = "";
            _GdHead.AdminLock = false;
            _GdHead.DATE_MODIFIED = DateTime.Now;
            _GdHead.salMonth = "";
            _GdHead.gdUser = VarGeneral.UserNumber;
            _GdHead.gdUserNam = VarGeneral.UserNameA;
            _GdHead.CompanyID = 1;
            return _GdHead;
        }
        private void textBox_ID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (e.KeyChar != '\b'))
            {
                e.Handled = true;
            }
        }
        private void Cmb_PayMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            Total();
        }
        private void Button_GaidGabth_Click(object sender, EventArgs e)
        {
            try
            {
                VarGeneral.vGaidHotel = true;
                VarGeneral.InvTyp = 27;
                FrmSnd frm = new FrmSnd();
                frm.Tag = LangArEn;
                VarGeneral.SndTyp = 1;
                VarGeneral.tot_Guest_val = Label17.Value;
                frm.TopMost = true;
                frm.ShowDialog();
            }
            catch
            {
                VarGeneral.StockOnly = false;
            }
            VarGeneral.vGaidHotel = false;
            SetData();
        }
        private void Button_GaidSerf_Click(object sender, EventArgs e)
        {
            try
            {
                VarGeneral.vGaidHotel = true;
                VarGeneral.InvTyp = 28;
                FrmSnd frm = new FrmSnd();
                frm.Tag = LangArEn;
                VarGeneral.SndTyp = 2;
                frm.TopMost = true;
                frm.ShowDialog();
            }
            catch
            {
                VarGeneral.StockOnly = false;
            }
            VarGeneral.vGaidHotel = false;
            SetData();
        }
        private void buttonItem_EditDays_Click(object sender, EventArgs e)
        {
            FrmEditDay frm = new FrmEditDay(int.Parse(Label19.Value.ToString()));
            frm.Tag = LangArEn;
            frm.TopMost = true;
            frm.ShowDialog();
            Label19.Value = VarGeneral.Cc2;
            SetData();
        }
        private void comboBox_DisType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_DisType.SelectedIndex == 1)
            {
                labelPercentage.Visible = true;
                label12z.Visible = true;
                comboBox_DisTo.Visible = true;
                return;
            }
            labelPercentage.Visible = false;
            if (comboBox_DisType.SelectedIndex == 0)
            {
                label12z.Visible = false;
                comboBox_DisTo.Visible = false;
            }
            else
            {
                label12z.Visible = true;
                comboBox_DisTo.Visible = true;
            }
        }
        private void Label17_ValueChanged(object sender, EventArgs e)
        {
            if (Label17.Value <= 0.0)
            {
                Cmb_PayMethod.SelectedIndex = 0;
                Cmb_PayMethod.DropDownStyle = ComboBoxStyle.Simple;
                Cmb_PayMethod.Enabled = false;
            }
            else
            {
                Cmb_PayMethod.DropDownStyle = ComboBoxStyle.DropDownList;
                Cmb_PayMethod.Enabled = true;
            }
        }
        private void switchButton_Lock_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (switchButton_Lock.Value)
                {
                    panel_Gaid.Enabled = true;
                    if (!switchButton_Lock.Value)
                    {
                        return;
                    }
                    if (string.IsNullOrEmpty(txtDebit1.Text))
                    {
                        try
                        {
                            T_per q = db.StockPer(VarGeneral._hotelper);
                            txtDebit1.Tag = q.Cust_no;
                            txtDebit1.Text = ((LangArEn == 0) ? db.StockAccDefWithOutBalance(q.Cust_no).Arb_Des : db.StockAccDefWithOutBalance(q.Cust_no).Eng_Des);
                        }
                        catch
                        {
                            txtDebit1.Text = "";
                            txtDebit1.Tag = "";
                        }
                    }
                    if (!string.IsNullOrEmpty(txtCredit1.Text))
                    {
                        return;
                    }
                    try
                    {
                        if (!string.IsNullOrEmpty(VarGeneral.Settings_Sys.GuestBoxAcc))
                        {
                            txtCredit1.Tag = VarGeneral.Settings_Sys.GuestBoxAcc;
                            txtCredit1.Text = ((LangArEn == 0) ? db.StockAccDefWithOutBalance(VarGeneral.Settings_Sys.GuestBoxAcc).Arb_Des : db.StockAccDefWithOutBalance(VarGeneral.Settings_Sys.GuestBoxAcc).Eng_Des);
                        }
                        else
                        {
                            txtCredit1.Text = "";
                            txtCredit1.Tag = "";
                        }
                    }
                    catch
                    {
                        txtCredit1.Text = "";
                        txtCredit1.Tag = "";
                    }
                    return;
                }
                panel_Gaid.Enabled = false;
                txtDebit1.Text = "";
                txtDebit1.Tag = "";
                txtCredit1.Text = "";
                txtCredit1.Tag = "";
            }
            catch
            {
            }
        }
        private void txtCredit1_ButtonCustomClick(object sender, EventArgs e)
        {
            columns_Names_visible2.Clear();
            columns_Names_visible2.Clear();
            columns_Names_visible2.Add("AccDef_No", new ColumnDictinary("الرقم ", " No", ifDefault: true, ""));
            columns_Names_visible2.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, ""));
            columns_Names_visible2.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, ""));
            columns_Names_visible2.Add("AccDef_ID", new ColumnDictinary(" ", " ", ifDefault: false, ""));
            columns_Names_visible2.Add("Mobile", new ColumnDictinary("الجوال", "Mobile", ifDefault: false, ""));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible2;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, ""));
            }
            if (VarGeneral.SSSTyp == 0)
            {
                VarGeneral.SFrmTyp = "T_AccDef";
                VarGeneral.AccTyp = 4;
            }
            else
            {
                VarGeneral.SFrmTyp = "AccDefID_Setting";
            }
            frm.TopMost = true;
            frm.ShowDialog();
            try
            {
                if (frm.SerachNo != "")
                {
                    T_AccDef _AccDef = db.StockAccDefs(int.Parse(frm.Serach_No));
                    txtCredit1.Tag = _AccDef.AccDef_No;
                    if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                    {
                        txtCredit1.Text = _AccDef.Arb_Des;
                    }
                    else
                    {
                        txtCredit1.Text = _AccDef.Eng_Des;
                    }
                }
                else
                {
                    txtCredit1.Text = "";
                    txtCredit1.Tag = "";
                }
            }
            catch
            {
                txtCredit1.Text = "";
                txtCredit1.Tag = "";
            }
        }
        private void txtDebit1_ButtonCustomClick(object sender, EventArgs e)
        {
            columns_Names_visible2.Clear();
            columns_Names_visible2.Clear();
            columns_Names_visible2.Add("AccDef_No", new ColumnDictinary("الرقم ", " No", ifDefault: true, ""));
            columns_Names_visible2.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, ""));
            columns_Names_visible2.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, ""));
            columns_Names_visible2.Add("AccDef_ID", new ColumnDictinary(" ", " ", ifDefault: false, ""));
            columns_Names_visible2.Add("Mobile", new ColumnDictinary("الجوال", "Mobile", ifDefault: false, ""));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible2;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, ""));
            }
            if (VarGeneral.SSSTyp == 0)
            {
                VarGeneral.SFrmTyp = "T_AccDef";
                VarGeneral.AccTyp = 4;
            }
            else
            {
                VarGeneral.SFrmTyp = "AccDefID_Setting";
            }
            frm.TopMost = true;
            frm.ShowDialog();
            try
            {
                if (frm.SerachNo != "")
                {
                    T_AccDef _AccDef = db.StockAccDefs(int.Parse(frm.Serach_No));
                    txtDebit1.Tag = _AccDef.AccDef_No;
                    if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                    {
                        txtDebit1.Text = _AccDef.Arb_Des;
                    }
                    else
                    {
                        txtDebit1.Text = _AccDef.Eng_Des;
                    }
                }
                else
                {
                    txtDebit1.Text = "";
                    txtDebit1.Tag = "";
                }
            }
            catch
            {
                txtDebit1.Text = "";
                txtDebit1.Tag = "";
            }
        }
        private void Button_GaidGabthAcc_Click(object sender, EventArgs e)
        {
            try
            {
                VarGeneral.vGaidHotel = true;
                VarGeneral.InvTyp = 12;
                FMReceiptVoucher frm = new FMReceiptVoucher();
                frm.Tag = LangArEn;
                frm.TopMost = true;
                frm.ShowDialog();
            }
            catch
            {
                VarGeneral.vGaidHotel = false;
            }
            VarGeneral.vGaidHotel = false;
            SetData();
        }
    }
}
