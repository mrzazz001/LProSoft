using C1.Win.C1FlexGrid;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.DotNetBar.SuperGrid;
using DevComponents.DotNetBar.SuperGrid.Style;
using DevComponents.Editors;
using Framework.Data;
using InputKey;
using InvAcc.GeneralM;
using InvAcc.Stock_Data;
using Library.RepShow;
using Microsoft.Win32;
using SSSDateTime.Date;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using TFG;
namespace InvAcc.Forms
{
    public partial  class FrmInvSalesReturn : Form
    {
        bool keyisch = false;
        private void FlxInv_KeyPressEdit(object sender, KeyPressEditEventArgs e)
        {

            keyisch = true;


        }

        bool keychtax = false;
        bool keyishNo = false;
        private void FlxInv_ValidateEdit(object sender, ValidateEditEventArgs e)
        {

            if (e.Col == 8 && keyisch == true)
            {
                double ff = double.Parse(FlxInv.GetData(e.Row, e.Col).ToString());

                lastprice = 0;
               // without = double.Parse(FlxInv.GetData(e.Row, e.Col).ToString());
                pricel = double.Parse(FlxInv.GetData(e.Row, e.Col).ToString());
                //  FlxInv_AfterEdit(null, new RowColEventArgs(e.Row, 8));
            }
            if (e.Col == 38 && keyisch == true)
            {
                enteredtotal = 0;
                //  FlxInv_AfterEdit(null, new RowColEventArgs(e.Row, 8));
            }
            if (e.Col == 31 && keyisch == true)
            {
                keychtax = true;
                //  FlxInv_AfterEdit(null, new RowColEventArgs(e.Row, 8));
            }
            if (e.Col == 31 && keyisch == true)
            {
                keychtax = true;
                //  FlxInv_AfterEdit(null, new RowColEventArgs(e.Row, 8));
            }
            if (e.Col == 1 && keyisch == true)
                keyishNo = true;
            keyisch = false;
        }



        void avs(int arln)

{ 
 button_opendraft.Text=   (arln == 0 ? "  الفواتير المعلقة  " : "  Pending invoices") ; button_Draft.Text=   (arln == 0 ? "  تعليق الفاتورة  " : "  Invoice comment") ; button_SrchInvNoBarcod.Text=   (arln == 0 ? "  بحث  " : "  Search") ; label40.Text=   (arln == 0 ? "  خصم النقـاط  " : "  Points Discount") ; button_GoodsDisbursedInv.Text=   (arln == 0 ? "  فواتير صرف البضاعة  " : "  Goods exchange invoices") ; label32.Text=   (arln == 0 ? "  السيريال  " : "  serial السي") ; label25.Text=   (arln == 0 ? "  الوحدة  " : "  Unit") ; label22.Text=   (arln == 0 ? "  سعر اخر مرتجع بيع  " : "  Last sale return price") ; label23.Text=   (arln == 0 ? "  أخر تكلفة  " : "  latest cost") ; label24.Text=   (arln == 0 ? "  متوسط التكلفة  " : "  average cost") ; superTabItem_items.Text=   (arln == 0 ? "  م.الصنف  " : "  M. Category") ; superTabControl_CostSts.Text=   (arln == 0 ? "  superTabControl3  " : "  superTabControl3") ; labelC1.Text=   (arln == 0 ? "  الدائـــن :  " : "  creditor:") ; labelC2.Text=   (arln == 0 ? "  الدائـــن :  " : "  creditor:") ; labelD3.Text=   (arln == 0 ? "  المـــدين :  " : "  Debtor:") ; labelC3.Text=   (arln == 0 ? "  الدائـــن :  " : "  creditor:") ; labelD2.Text=   (arln == 0 ? "  المـــدين :  " : "  Debtor:") ; label6.Text=   (arln == 0 ? "  نقــداٌ :  " : "  cash:") ; labelD1.Text=   (arln == 0 ? "  المـــدين :  " : "  Debtor:") ; label11.Text=   (arln == 0 ? "  آجــل :  " : "  deferred:") ; label14.Text=   (arln == 0 ? "  شبكة :  " : "  Network :") ; superTabItem_Pay.Text=   (arln == 0 ? "  الدفع  " : "  paying off") ; label34.Text=   (arln == 0 ? "  الدائـــــن :  " : "  creditor:") ; label35.Text=   (arln == 0 ? "  المـــدين :  " : "  Debtor:") ; checkBox_CostGaidTax.Text=   (arln == 0 ? "  سند محاسبي  " : "  accounting document") ; label36.Text=   (arln == 0 ? "  بالريــــال  " : "  in riyals") ; superTabItem_Tax.Text=   (arln == 0 ? "  الضـــرائب  " : "  taxes") ; label20.Text=   (arln == 0 ? "  إجمالي القيمة  " : "  Total value") ; label37.Text=   (arln == 0 ? "  الدائـــــن :  " : "  creditor:") ; label38.Text=   (arln == 0 ? "  المـــدين :  " : "  Debtor:") ; label39.Text=   (arln == 0 ? "  بالريــــال  " : "  in riyals") ; checkBox_GaidDis.Text=   (arln == 0 ? "  سند محاسبي  " : "  accounting document") ; superTabItem_Dis.Text=   (arln == 0 ? "  الخصـــــم  " : "  discount ال") ; labelItem_TaxByNetPer.Text=   (arln == 0 ? "  %  " : "  %") ; superTabItem_Gaids.Text=   (arln == 0 ? "  القيود  " : "  limitations") ; label_LockeName.Text=   (arln == 0 ? "  --  " : "  --") ; label27.Text=   (arln == 0 ? "  المستخدم :  " : "  the user :") ; label30.Text=   (arln == 0 ? "  إجمالي الكمية :  " : "  Total Quantity:") ; superTabItem_Detiles.Text=   (arln == 0 ? "  تفاصيل  " : "  details") ; label16.Text=   (arln == 0 ? "  رقم الحاوية :  " : "  containers number :") ; superTabItem_Note.Text=   (arln == 0 ? "  ملاحظات  " : "  Notes") ; label21.Text=   (arln == 0 ? "  جوال:  " : "  mobile:") ; label12.Text=   (arln == 0 ? "  هاتف :  " : "  Telephone :") ; label10.Text=   (arln == 0 ? "  اسم العميـــــل :  " : "  Client name:") ; label4.Text=   (arln == 0 ? "  حساب العميــل :  " : "  Customer account:") ; label13.Text=   (arln == 0 ? "  عنوان العميل :  " : "  Customer address:") ; Label2.Text=   (arln == 0 ? "  التاريــــــــخ :  " : "  date:") ; Label1.Text=   (arln == 0 ? "  رقم الفاتورة :  " : "  invoice number :") ; label31.Text=   (arln == 0 ? "  المبلغ المتبقي :  " : "  Remaining amount :") ; label29.Text=   (arln == 0 ? "  أجمالي الفاتورة  " : "  total bill") ; label8.Text=   (arln == 0 ? "  نسبة الخصم  " : "  discount percentage") ; label33.Text=   (arln == 0 ? "  الضريبة VAT:  " : "  VAT:") ; Label26.Text=   (arln == 0 ? "  قيمة الخصم  " : "  discount value") ; label3.Text=   (arln == 0 ? "  بالريــال  " : "  in riyals") ; label9.Text=   (arln == 0 ? "  صافي الفاتورة :  " : "  net bill:") ; label17.Text=   (arln == 0 ? "  قيمة الفاتـــورة :  " : "  Invoice value:") ;  checkBox_NetWork.Text=   (arln == 0 ? "  شبكـــة  " : "Network") ; checkBox_Credit.Text=   (arln == 0 ? "  أجـــل  " : "Credit") ; checkBox_Chash.Text=   (arln == 0 ? "  نقـــدي  " : "Cach") ; labelHeader.Text=   (arln == 0 ? "  إصدار وصفة  " : "  Recipe version") ; label5.Text=   (arln == 0 ? "  السعر المعتمــد :  " : "  Approved price:") ; label15.Text=   (arln == 0 ? "  مركز التكلفـــــة :  " : "  cost center:") ; label19.Text=   (arln == 0 ? "  العملــــــــة :  " : "  work:") ; label18.Text=   (arln == 0 ? "  المنـــــدوب :  " : "  The delegate:") ; label7.Text=   (arln == 0 ? "  رقم المرجع :  " : "  reference number :") ; superTabControl_Main1.Text=   (arln == 0 ? "  superTabControl3  " : "  superTabControl3") ; button_Repetition.Text=   (arln == 0 ? "  تكرار  " : "  Repetition") ; ButReturn.Text=   (arln == 0 ? "  إرجاع فاتورة  " : "  return invoice") ; Button_Close.Text=   (arln == 0 ? "  إغلاق  " : "  Close") ; /*buttonItem_Print.Text=   (arln == 0 ? "  طباعة  " : "  Print") ;*/ printersettings.Text=   (arln == 0 ? "  اعدادات الطابعة  " : "  printer settings") ; Button_Search.Text=   (arln == 0 ? "  بحث  " : "  Search") ; Button_Delete.Text=   (arln == 0 ? "  حذف  " : "  delete") ; Button_Save.Text=   (arln == 0 ? "  حفظ  " : "  save") ; Button_Add.Text=   (arln == 0 ? "  إضافة  " : "  addition") ;  superTabControl_Main2.Text=   (arln == 0 ? "  superTabControl1  " : "  superTabControl1") ; Button_First.Text=   (arln == 0 ? "  الأول  " : "  the first") ; Button_Prev.Text=   (arln == 0 ? "  السابق  " : "  the previous") ; lable_Records.Text=   (arln == 0 ? "  ---  " : "  ---") ; Button_Next.Text=   (arln == 0 ? "  التالي  " : "  next one") ; Button_Last.Text=   (arln == 0 ? "  الأخير  " : "  the last one") ; ToolStripMenuItem_Det.Text=   (arln == 0 ? "  إظهار التفاصيل  " : "  Show details") ; ToolStripMenuItem_Rep.Text=   (arln == 0 ? "  إظهار التقرير  " : "  Show report") ; panelEx2.Text=   (arln == 0 ? "  Click to collapse  " : "  Click to collapse") ; panelEx3.Text=   (arln == 0 ? "  Fill Panel  " : "  Fill Panel") ; DGV_Main.Text=   (arln == 0 ? " string.Empty " : " string.Empty") ; DGV_Main.Text=   (arln == 0 ? "  جميــع السجــــلات  " : "  All records") ; DGV_Main.Text=   (arln == 0 ? " string.Empty " : " string.Empty") ; superTabControl_DGV.Text=   (arln == 0 ? "  superTabControl1  " : "  superTabControl1") ; textBox_search.Text=   (arln == 0 ? "  ...  " : "  ...") ; Button_ExportTable2.Text=   (arln == 0 ? "  تصدير  " : "  Export") ; /*Button_PrintTable.Text=   (arln == 0 ? "  طباعة  " : "  Print") ; */Button_PrintTableMulti.Text=   (arln == 0 ? "  طباعة الفواتير المحددة  " : "  Print selected invoices") ; Text = "فاتورة مرتجع مبيعات";this.Text=   (arln == 0 ? "  فاتورة مرتجع مبيعات  " : "  Sales Return Invoice") ;}
        private void langloads(object sender, EventArgs e)
        {
             avs(GeneralM.VarGeneral.currentintlanguage);
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
        private ScriptNumber ScriptNumber1 = new ScriptNumber();
        public Dictionary<string, string> columns_Nams_Sums = new Dictionary<string, string>();
        public Dictionary<string, ColumnDictinary> columns_Names_visible = new Dictionary<string, ColumnDictinary>();
        public Dictionary<string, ColumnDictinary> columns_Names_visible2 = new Dictionary<string, ColumnDictinary>();
        private HijriGreg.HijriGregDates n = new HijriGreg.HijriGregDates();
        private int RowSel = 0;
        private string oldUnit = string.Empty;
        private double RateValue = 0.0;
        private string UnitAOld = string.Empty;
        private string UnitEOld = string.Empty;
        private double PriceOld = 0.0;
        private int DefPack = 0;
        private double Pack = 0.0;
        private double PriceLoc = 0.0;
        public static int LangArEn = 0;
        public string DocType = string.Empty;
        private T_SYSSETTING _SysSetting = new T_SYSSETTING();
        private List<T_SYSSETTING> listSysSetting = new List<T_SYSSETTING>();
        private T_INVSETTING _InvSetting = new T_INVSETTING();
        private List<T_INVSETTING> listInvSetting = new List<T_INVSETTING>();
        private T_STKSQTY _StksQty = new T_STKSQTY();
        private List<T_STKSQTY> listStkQty = new List<T_STKSQTY>();
        private T_GDHEAD _GdHead = new T_GDHEAD();
        private List<T_GDHEAD> listGdHead = new List<T_GDHEAD>();
        private T_GDHEAD _GdHeadCostTax = new T_GDHEAD();
        private List<T_GDHEAD> listGdHeadCostTax = new List<T_GDHEAD>();
        private List<T_GDDET> listGdDetCostTax = new List<T_GDDET>();
        private T_GDHEAD _GdHeadCostDis = new T_GDHEAD();
        private List<T_GDHEAD> listGdHeadCostDis = new List<T_GDHEAD>();
        private List<T_GDDET> listGdDetCostDis = new List<T_GDDET>();
        private T_GDDET _GdDet = new T_GDDET();
        private List<T_GDDET> listGdDet = new List<T_GDDET>();
        private List<T_QTYEXP> listQtyExp = new List<T_QTYEXP>();
        private T_QTYEXP _QtyExp = new T_QTYEXP();
        private T_Unit _Unit = new T_Unit();
        private List<T_Unit> listUnit = new List<T_Unit>();
        private T_Item _Items = new T_Item();
        private List<T_Item> listItems = new List<T_Item>();
        private T_Store _Store = new T_Store();
        private List<T_Store> listStore = new List<T_Store>();
        private List<T_Curency> listCurency = new List<T_Curency>();
        private T_Curency _Curency = new T_Curency();
        private List<T_GdAuto> listGdAuto = new List<T_GdAuto>();
        private T_GdAuto _GdAuto = new T_GdAuto();
        private T_INVDET _InvDetRet = new T_INVDET();
        private T_INVDET _InvDet = new T_INVDET();
        private T_ItemSerial _SerialQty = new T_ItemSerial();
        private List<T_InvDetNote> listInvDetNote = new List<T_InvDetNote>();
        private List<T_ItemSerial> listSerialQty = new List<T_ItemSerial>();
        private T_INVHED data_this;
        private T_STKSQTY data_this_stkQ;
        private List<T_INVDET> LData_This;
        private T_INVHED data_thisRe;
        private List<T_INVDET> LData_ThisRe;
        public bool ifCheckData = false;
        public long TimeFinish = 0L;
        public long TimeStart = 0L;
        public TextBox textBox_Type = new TextBox();
        public List<string> pkeys = new List<string>();
        public bool canUpdate = true;
        protected bool CanInsert = true;
        public FormState statex;
        public ViewState ViewState = ViewState.Deiles;
        public string tableName = string.Empty;
        protected bool ifModify = true;
        public List<Control> controls;
        public Control codeControl = new Control();
        public bool CanEdit = true;
        protected bool ifOkDelete;
        private bool ifAutoOrderColumn = true;
        private Stock_DataDataContext dbInstance;
        private Rate_DataDataContext dbInstanceRate;
        private Stock_DataDataContext dbInstanceReturn;
        private T_User permission = new T_User();
        private List<string> _StorePr = new List<string>();
        private double Balance_Qty = -1.0;
        private double Balance_Price = -1.0;
        private int iiRntP = 0;
        private int _page = 1;
        private List<int> ItemDetRemoved = new List<int>();
        public Dictionary<int, List<T_SINVDET>> vSINVDIT = new Dictionary<int, List<T_SINVDET>>();
        private bool RepetitionSts = false;
        private bool ReverseSts = false;
        private bool _StopMove = true;
        private bool ifMultiPrint = false;
       // private IContainer components = null;
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData.ToString().Contains("Control") && !keyData.ToString().ToLower().Contains("delete") && keyData.ToString().Contains("Alt"))
            {
                try
                {
                    VarGeneral.Print_set_Gen_Stat = true;
                    FrmReportsViewer.IsSettingOnly = true;
                    if (textBox_ID.Text != string.Empty && State == FormState.Saved)
                    {
                        buttonItem_Print_Click(null, null);
                        VarGeneral.Print_set_Gen_Stat = false;
                    }
                    else
                    {
                        FrmReportsViewer frm = new FrmReportsViewer();
                        frm.Repvalue = "InvSalReturn";
                        frm.RepCashier = "InvoiceCachier";
                        frm.Repvalue = "InvSalReturn";
                        frm.RepCashier = "InvoiceCachier";
                        //ADDADD
                        frm.Tag = LangArEn;
                        frm.ShowDialog();
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
        private void netResize1_AfterControlResize(object sender, Softgroup.NetResize.AfterControlResizeEventArgs e)
        {
            if (e.Control.Name.Contains("ribbonBar_Tasks"))
            {
                ribbonBar_Tasks.Font = new Font("Tahoma", 8F);
                ribbonBar1.BackgroundStyle.BackColor = Color.Gainsboro;
                ribbonBar1.BackgroundStyle.BackColor2 = Color.Gainsboro;
            }
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
        private void superTabControl_Main1_RightToLeftChanged(object sender, EventArgs e)
        {
            superTabControl_Main1.RightToLeftChanged -= superTabControl_Main1_RightToLeftChanged;
            superTabControl_Main1.RightToLeft = RightToLeft.No;
            superTabControl_Main1.RightToLeftChanged -= superTabControl_Main1_RightToLeftChanged;
        }
        public Softgroup.NetResize.NetResize netResize1;
        internal PrintPreviewDialog prnt_prev;
        private PrintDocument prnt_doc;
        private DockSite barTopDockSite;
        private DockSite barBottomDockSite;
        private DockSite barLeftDockSite;
        private DockSite barRightDockSite;
        private ImageList imageList1;
        private DockSite dockSite3;
        private DockSite dockSite4;
        private DockSite dockSite1;
        public DotNetBarManager dotNetBarManager1;
        private DockSite dockSite2;
        protected ContextMenuStrip contextMenuStrip1;
        protected ContextMenuStrip contextMenuStrip2;
        protected ToolStripMenuItem ToolStripMenuItem_Det;
        protected ToolStripMenuItem ToolStripMenuItem_Rep;
        private DoubleInput txtInvCost;
        private ExpandableSplitter expandableSplitter1;
        private PanelEx panelEx2;
        private RibbonBar ribbonBar1;
        private DoubleInput txtCustNet;
        private DoubleInput txtCustRep;
        private DoubleInput textBox2;
        private DoubleInput textBox1;
        private C1FlexGrid FlxInv;
        private GroupBox groupBox3;
        private TextBox txtChange;
        private Label label38;
        private TextBox txtDueAmCa;
        private Label label29;
        private TextBox txtPayCa;
        private Panel panel1;
        private PanelEx panelEx3;
        private System.Windows.Forms.OpenFileDialog  openFileDialog1;
        private System.Windows.Forms. SaveFileDialog saveFileDialog1;
        private Timer timerInfoBallon;
        private Timer timer1;
        private RibbonBar ribbonBar_Tasks;
        private SuperTabControl superTabControl_Main1;
        protected ButtonItem Button_Close;
        protected ButtonItem buttonItem_Print;
        protected ButtonItem Button_Search;
        protected ButtonItem Button_Delete;
        protected ButtonItem Button_Save;
        protected ButtonItem Button_Add;
        private SuperTabControl superTabControl_Main2;
        protected LabelItem labelItem1;
        protected ButtonItem Button_First;
        protected ButtonItem Button_Prev;
        protected TextBoxItem TextBox_Index;
        protected LabelItem Label_Count;
        protected ButtonItem Button_Next;
        protected ButtonItem Button_Last;
        protected SuperGridControl DGV_Main;
        private RibbonBar ribbonBar_DGV;
        private SuperTabControl superTabControl_DGV;
        protected TextBoxItem textBox_search;
        protected ButtonItem Button_ExportTable2;
        protected ButtonItem Button_PrintTable;
        protected LabelItem labelItem3;
        protected ButtonItem ButReturn;
        private TextBox txtItemName;
        private DoubleInput doubleInput_Rate;
        private ButtonX button_SrchCustNo;
        private TextBox txtCustNo;
        internal Label label12;
        private TextBox txtAddress;
        private TextBox txtTele;
        private ComboBoxEx CmbInvPrice;
        private ComboBoxEx CmbCostC;
        private ComboBoxEx CmbCurr;
        private ComboBoxEx CmbLegate;
        internal TextBox txtCustName;
        internal TextBox txtRef;
        internal GroupBox groupBox5;
        private CheckBoxX checkBox_NetWork;
        private CheckBoxX checkBox_Credit;
        private CheckBoxX checkBox_Chash;
        internal Label label5;
        internal Label label15;
        internal Label label10;
        internal Label label4;
        internal Label label13;
        internal Label label19;
        internal Label label18;
        internal Label label7;
        internal Label Label2;
        internal Label Label1;
        private PictureBox pictureBox_Credit;
        private PictureBox pictureBox_Cash;
        private PictureBox pictureBox_NetWord;
        private SuperTabControl superTabControl_Info;
        private SuperTabControlPanel superTabControlPanel3;
        private TextBox txtUnit;
        private TextBox txtLPrice;
        internal Label label25;
        internal Label label22;
        internal Label label23;
        internal Label label24;
        private TextBox txtLCost;
        private TextBox txtVCost;
        private C1FlexGrid dataGridView_ItemDet;
        private SuperTabItem superTabItem_items;
        private ButtonX button_CustC1;
        private ButtonX button_CustC3;
        private ButtonX button_CustC2;
        private ButtonX button_CustD1;
        private ButtonX button_CustD3;
        private ButtonX button_CustD2;
        private TextBoxX txtDebit3;
        private TextBoxX txtDebit2;
        private TextBoxX txtDebit1;
        internal Label labelC3;
        internal Label labelD3;
        internal Label labelC2;
        internal Label labelD2;
        internal Label labelC1;
        internal Label labelD1;
        internal Label label14;
        internal Label label11;
        internal Label label6;
        private DoubleInput doubleInput_CreditLoc;
        private DoubleInput doubleInput_NetWorkLoc;
        private DoubleInput txtPaymentLoc;
        private TextBoxX txtCredit3;
        private TextBoxX txtCredit2;
        private TextBoxX txtCredit1;
        private SuperTabControlPanel superTabControlPanel4;
        private TextBoxX txtRemark;
        private SuperTabItem superTabItem_Note;
        private SuperTabControlPanel superTabControlPanel2;
        internal Label label27;
        private DoubleInput txtTotalQ;
        internal Label label30;
        private TextBox textBox_Usr;
        private SuperTabItem superTabItem_Detiles;
        private LabelItem lable_Records;
        private GroupBox groupBox1;
        internal Label label8;
        internal Label Label26;
        private DoubleInput txtDueAmount;
        private DoubleInput txtTotalAm;
        private DoubleInput txtDiscountVal;
        private DoubleInput txtDiscountP;
        internal Label label3;
        private DoubleInput txtDiscountValLoc;
        private DoubleInput txtTotalAmLoc;
        private DoubleInput txtDueAmountLoc;
        internal Label label9;
        internal Label label17;
        private C1FlexGrid FlxDat;
        internal Label label32;
        private TextBox txtVSerial;
        private MaskedTextBox txtTime;
        private MaskedTextBox txtGDate;
        private MaskedTextBox txtHDate;
        private C1FlexGrid FlxStkQty;
        private SwitchButton switchButton_Lock;
        internal Label label_LockeName;
        internal Label labelHeader;
        protected ButtonItem button_Repetition;
        private TextBoxX textBox_ID;
        private C1FlexGrid FlxSerial;
        private TextBox txtDescription;
        internal Label label16;
        private SuperTabControlPanel superTabControlPanel5;
        private SuperTabControl superTabControl_CostSts;
        private SuperTabControlPanel superTabControlPanel6;
        private SwitchButton switchButton_Tax;
        internal Label label33;
        internal Label label34;
        internal Label label35;
        private ButtonX button_CustC5;
        private TextBoxX txtCredit5;
        private ButtonX button_CustD5;
        private TextBoxX txtDebit5;
        private CheckBoxX checkBox_CostGaidTax;
        internal Label label36;
        private DoubleInput txtTotTax;
        private DoubleInput txtTotTaxLoc;
        private SuperTabItem superTabItem_Tax;
        private SuperTabControlPanel superTabControlPanel7;
        private SuperTabItem superTabItem_Dis;
        private SuperTabItem superTabItem_Gaids;
        internal Label label20;
        internal Label label37;
        internal Label label31;
        private TextBoxX txtCredit6;
        private TextBoxX txtDebit6;
        internal Label label39;
        private DoubleInput txtTotDis;
        private DoubleInput txtTotDisLoc;
        private CheckBoxX checkBox_GaidDis;
        private SwitchButton switchButton_Dis;
        private ComboBoxEx CmbInvSide;
        private ButtonX button_GoodsDisbursedInv;
        private SwitchButtonItem switchButton_TaxLines;
        private SwitchButtonItem switchButton_TaxByTotal;
        private SwitchButtonItem switchButton_TaxByNet;
        private TextBoxItem textBoxItem_TaxByNetValue;
        private LabelItem labelItem_TaxByNetPer;
        private CheckBoxItem ChkA4Cahir;
        private C1FlexGrid FlxInvToCopy;
        private SwitchButton switchButton_PointActiv;
        private ButtonX button_SrchCustPoints;
        private DoubleInput txtDiscoundPointsLoc;
        private DoubleInput txtDiscoundPoints;
        internal Label label40;
        private DoubleInput txtPointCount;
        protected ButtonItem Button_PrintTableMulti;
        private SuperTabControlPanel superTabControlPanel8;
        private SuperTabItem superTabItem_Pay;
        private TextBox text_Mobile;
        internal Label label21;
        private ButtonItem printersettings;
        private SwitchButtonItem ChkPriceIncludeTax;
        private ButtonX button_opendraft;
        private ButtonX button_Draft;
        private ButtonX button_SrchInvNoBarcod;
        public T_INVHED DataThis
        {
            get
            {
                return data_this;
            }
            set
            {
                data_this = value;
                SetData(data_this);
            }
        }
        public T_STKSQTY DataThis_stkQ
        {
            get
            {
                return data_this_stkQ;
            }
            set
            {
                data_this_stkQ = value;
            }
        }
        public List<T_INVDET> LDataThis
        {
            get
            {
                return LData_This;
            }
            set
            {
                LData_This = value;
            }
        }
        public T_INVHED DataThisRe
        {
            get
            {
                return data_thisRe;
            }
            set
            {
                data_thisRe = value;
                SetDataRt(data_thisRe);
            }
        }
        public List<T_INVDET> LDataThisRe
        {
            get
            {
                return LData_ThisRe;
            }
            set
            {
                LData_ThisRe = value;
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
        public string TableName
        {
            get
            {
                return tableName;
            }
            set
            {
                tableName = value;
            }
        }
        public bool IfAdd
        {
            set
            {
                Button_Add.Visible = value;
                button_Repetition.Visible = value;
            }
        }
        public bool IfDelete
        {
            set
            {
                Button_Delete.Visible = value;
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
        public bool IfClose
        {
            set
            {
                Button_Close.Visible = value;
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
                Button_Save.Enabled = !value;
                if (State == FormState.New)
                {
                    ButReturn.Enabled = true;
                    switchButton_Lock.Visible = false;
                }
                else
                {
                    ButReturn.Enabled = false;
                    switchButton_Lock.Visible = true;
                }
                if (CmbInvSide.SelectedIndex > 0)
                {
                    ButReturn.Enabled = false;
                }
                if (State == FormState.Saved)
                {
                    textBox_ID.ButtonCustom.Visible = true;
                    Button_PrintTableMulti.Enabled = true;
                }
                else
                {
                    textBox_ID.ButtonCustom.Visible = false;
                    Button_PrintTableMulti.Enabled = false;
                }
                if (State == FormState.Saved && CmbInvSide.SelectedIndex <= 0)
                {
                    button_Repetition.Enabled = true;
                }
                else
                {
                    button_Repetition.Enabled = false;
                }
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
        private Stock_DataDataContext dbReturn
        {
            get
            {
                if (dbInstanceReturn == null)
                {
                    dbInstanceReturn = new Stock_DataDataContext(VarGeneral.BranchCS);
                }
                return dbInstanceReturn;
            }
        }
        public T_User Permmission
        {
            get
            {
                return permission;
            }
            set
            {
                if (value == null || !(value.UsrNo != string.Empty))
                {
                    return;
                }
                permission = value;
                if (!VarGeneral.TString.ChkStatShow(value.InvStr, 5))
                {
                    IfAdd = false;
                }
                else
                {
                    IfAdd = true;
                }
                if (!VarGeneral.TString.ChkStatShow(value.InvStr, 6) || switchButton_Lock.Value)
                {
                    CanEdit = false;
                }
                else
                {
                    CanEdit = true;
                }
                if (!VarGeneral.TString.ChkStatShow(value.InvStr, 7) || switchButton_Lock.Value)
                {
                    IfDelete = false;
                }
                else
                {
                    IfDelete = true;
                }
                if (!VarGeneral.TString.ChkStatShow(value.InvStr, 57) || switchButton_Lock.Value)
                {
                    button_Repetition.Visible = false;
                }
                else
                {
                    button_Repetition.Visible = true;
                }
                if (!VarGeneral.TString.ChkStatShow(Permmission.RepInv1, 0))
                {
                    switchButton_Lock.IsReadOnly = true;
                }
                else
                {
                    try
                    {
                        if (data_this == null || string.IsNullOrEmpty(data_this.InvNo))
                        {
                            switchButton_Lock.IsReadOnly = false;
                        }
                        else if (!string.IsNullOrEmpty(data_this.SalsManNam))
                        {
                            if (VarGeneral.UserNumber.Trim() != data_this.SalsManNam.Trim() && switchButton_Lock.Value && State != FormState.Edit)
                            {
                                switchButton_Lock.IsReadOnly = true;
                            }
                            else
                            {
                                switchButton_Lock.IsReadOnly = false;
                            }
                        }
                        else
                        {
                            switchButton_Lock.IsReadOnly = false;
                        }
                    }
                    catch
                    {
                        switchButton_Lock.IsReadOnly = false;
                    }
                }
                if (State != FormState.New)
                {
                    switchButton_Lock.Visible = true;
                }
                if (VarGeneral.vDemo)
                {
                    IfDelete = false;
                }
            }
        }
        protected bool Check()
        {
            if (!ifCheckData)
            {
                return true;
            }
            return true;
        }
        public void FillHDGV(IEnumerable<T_INVHED> new_data_enum)
        {
            bool contextMenuSet = false;
            if (contextMenuStrip1.Items.Count > 0)
            {
                contextMenuSet = true;
            }
            for (int i = 0; i < DGV_Main.PrimaryGrid.Columns.Count; i++)
            {
                if (columns_Names_visible.ContainsKey(DGV_Main.PrimaryGrid.Columns[i].Name))
                {
                    DGV_Main.PrimaryGrid.Columns[i].AutoSizeMode = ColumnAutoSizeMode.None;
                    DGV_Main.PrimaryGrid.Columns[i].MinimumWidth = 90;
                    DGV_Main.PrimaryGrid.Columns[i].Visible = columns_Names_visible[DGV_Main.PrimaryGrid.Columns[i].Name].IfDefault;
                    DGV_Main.PrimaryGrid.Columns[i].HeaderText = ((LangArEn == 0) ? columns_Names_visible[DGV_Main.PrimaryGrid.Columns[i].Name].AText : columns_Names_visible[DGV_Main.PrimaryGrid.Columns[i].Name].EText);
                    if (!contextMenuSet)
                    {
                        ToolStripMenuItem item = new ToolStripMenuItem();
                        item.Checked = columns_Names_visible[DGV_Main.PrimaryGrid.Columns[i].Name].IfDefault;
                        item.CheckOnClick = true;
                        item.Name = DGV_Main.PrimaryGrid.Columns[i].Name;
                        item.Text = DGV_Main.PrimaryGrid.Columns[i].HeaderText;
                        item.CheckedChanged += item_Click;
                        contextMenuStrip1.Items.Add(item);
                    }
                    else
                    {
                        DGV_Main.PrimaryGrid.Columns[i].Visible = (contextMenuStrip1.Items[DGV_Main.PrimaryGrid.Columns[i].Name] as ToolStripMenuItem).Checked;
                    }
                }
                else
                {
                    DGV_Main.PrimaryGrid.Columns[i].Visible = false;
                }
            }
            DGV_Main.PrimaryGrid.DataSource = new_data_enum.ToList();
            DGV_Main.PrimaryGrid.DataMember = "T_INVHED";
        }
        public void FillHDGVQ(IQueryable new_data_enum)
        {
            SetReadOnly = true;
            DGV_Main.PrimaryGrid.DataSource = new_data_enum;
            DGV_Main.PrimaryGrid.DataMember = "T_INVHED";
        }
        private void item_Click(object sender, EventArgs e)
        {
            string name = (sender as ToolStripMenuItem).Name;
            try
            {
                string NameExsist = DGV_Main.PrimaryGrid.Columns[name].Name;
            }
            catch
            {
                DGV_Main.PrimaryGrid.Columns.Add(new GridColumn(name));
                DGV_Main.PrimaryGrid.Columns[name].AutoSizeMode = ColumnAutoSizeMode.None;
                DGV_Main.PrimaryGrid.Columns[name].MinimumWidth = 100;
                DGV_Main.PrimaryGrid.Columns[name].HeaderText = ((LangArEn == 0) ? columns_Names_visible[name].AText : columns_Names_visible[name].EText);
            }
            DGV_Main.PrimaryGrid.Columns[name].Visible = (sender as ToolStripMenuItem).Checked;
        }
        protected bool ContinueIfEditOrNew()
        {
            if (State == FormState.Edit || State == FormState.New)
            {
                if (MessageBox.Show((LangArEn == 0) ? "تم تعديل السجل الحالي دون حفظ التغييرات .. هل تريد المتابعة؟" : "Not saved the changes, do you really want to continue?", VarGeneral.ProdectNam, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
                {
                    return false;
                }
                return true;
            }
            return true;
        }
        public void Button_First_Click(object sender, EventArgs e)
        {
            if (ContinueIfEditOrNew())
            {
                TextBox_Index.TextBox.Text = string.Concat(1);
                UpdateVcr();
            }
        }
        public void Button_Prevouse_Click(object sender, EventArgs e)
        {
            if (ContinueIfEditOrNew())
            {
                int index = 0;
                try
                {
                    index = Convert.ToInt32(TextBox_Index.TextBox.Text);
                }
                catch
                {
                }
                if (index > 1)
                {
                    TextBox_Index.TextBox.Text = string.Concat(index - 1);
                }
                UpdateVcr();
            }
        }
        public void Button_Next_Click(object sender, EventArgs e)
        {
            if (ContinueIfEditOrNew())
            {
                int index = 0;
                int count = 0;
                try
                {
                    index = Convert.ToInt32(TextBox_Index.TextBox.Text);
                }
                catch
                {
                }
                try
                {
                    count = Convert.ToInt32(Label_Count.Text);
                }
                catch
                {
                }
                if (index < count)
                {
                    TextBox_Index.TextBox.Text = string.Concat(index + 1);
                }
                UpdateVcr();
            }
        }
        public void Button_Last_Click(object sender, EventArgs e)
        {
            if (ContinueIfEditOrNew())
            {
                TextBox_Index.TextBox.Text = Label_Count.Text;
                UpdateVcr();
            }
        }
        private void UpdateVcr()
        {
            int vCount = 0;
            int vPosition = 0;
            try
            {
                vCount = int.Parse(Label_Count.Text);
            }
            catch
            {
                vCount = 0;
            }
            try
            {
                vPosition = int.Parse(TextBox_Index.Text);
            }
            catch
            {
                vPosition = 0;
            }
            if (vCount <= 1)
            {
                Button_First.Enabled = false;
                Button_Prev.Enabled = false;
                Button_Next.Enabled = false;
                Button_Last.Enabled = false;
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                {
                    lable_Records.Text = ((vCount == 0) ? "لايوجد سجلات" : "سجل واحد فقط");
                }
                else
                {
                    lable_Records.Text = ((vCount == 0) ? "No records" : "Only Record");
                }
                return;
            }
            if (vPosition == 1)
            {
                ButtonItem button_First = Button_First;
                bool enabled = (Button_Prev.Enabled = false);
                button_First.Enabled = enabled;
                ButtonItem button_Last = Button_Last;
                enabled = (Button_Next.Enabled = vCount > 1);
                button_Last.Enabled = enabled;
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                {
                    lable_Records.Text = "الأول من " + vCount + " سجلات";
                }
                else
                {
                    lable_Records.Text = "First of " + vCount + " records";
                }
                return;
            }
            if (vPosition == vCount)
            {
                Button_Last.Enabled = false;
                Button_Next.Enabled = false;
                ButtonItem button_First2 = Button_First;
                bool enabled = (Button_Prev.Enabled = vCount > 1);
                button_First2.Enabled = enabled;
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                {
                    lable_Records.Text = "الأخير من " + vCount + " سجلات";
                }
                else
                {
                    lable_Records.Text = "Last of " + vCount + " records";
                }
                return;
            }
            Button_First.Enabled = true;
            Button_Prev.Enabled = true;
            Button_Next.Enabled = true;
            Button_Last.Enabled = true;
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
            {
                lable_Records.Text = "السجل " + vPosition + " من " + vCount;
            }
            else
            {
                lable_Records.Text = "Record " + vPosition + " of " + vCount;
            }
        }
        public bool CheckNotificationMassage()
        {
            return false;
        }
        public void ViewDetails_Click(object sender, EventArgs e)
        {
            try
            {
                if (int.Parse(Label_Count.Text ?? string.Empty) <= 0 || (Label_Count.Text ?? string.Empty) == string.Empty)
                {
                    expandableSplitter1.Expandable = false;
                    return;
                }
                expandableSplitter1.Expandable = true;
                DGV_Main.PrimaryGrid.DataSource = null;
                DGV_Main.PrimaryGrid.VirtualMode = false;
                ViewState = ViewState.Deiles;
            }
            catch
            {
            }
        }
        public void ViewTable_Click(object sender, EventArgs e)
        {
            try
            {
                if (int.Parse(Label_Count.Text ?? string.Empty) <= 0 || (Label_Count.Text ?? string.Empty) == string.Empty)
                {
                    expandableSplitter1.Expandable = false;
                    return;
                }
                expandableSplitter1.Expandable = true;
                ViewState = ViewState.Table;
            }
            catch
            {
            }
            Fill_DGV_Main();
            int index = -1;
            try
            {
                index = Convert.ToInt32(TextBox_Index.TextBox.Text);
            }
            catch
            {
                index = -1;
            }
            index--;
            if (index < DGV_Main.PrimaryGrid.Rows.Count && index >= 0)
            {
                DGV_Main.PrimaryGrid.Rows[index].EnsureVisible();
            }
        }
        public void expandableSplitter1_Click(object sender, EventArgs e)
        {
            if (expandableSplitter1.Expanded)
            {
                ViewTable_Click(sender, e);
            }
            else
            {
                ViewDetails_Click(sender, e);
            }
        }
        private void Button_Edit_Click(object sender, EventArgs e)
        {
            if (CanEdit && State != FormState.Edit && State != FormState.New && !string.IsNullOrEmpty(textBox_ID.Text))
            {
                if (State != FormState.New)
                {
                    State = FormState.Edit;
                }
                FlxInv.Rows.Count = FlxInv.Rows.Count + VarGeneral.Settings_Sys.LineOfInvoices.Value;
                ButReturn.Tag = 0;
                SetReadOnly = false;
            }
        }
        public void Button_Print_Click(object sender, EventArgs e)
        {
            if (ViewState == ViewState.Table)
            {
                VarGeneral.InvType = 3;
                FRInvoice form1 = new FRInvoice(VarGeneral.InvTyp, LangArEn);
                form1.Tag = LangArEn.ToString();
                form1.StartPosition = FormStartPosition.CenterScreen;
                form1.TopMost = true;
                form1.ShowDialog();
            }
        }
        private void textBox_ID_Click(object sender, EventArgs e)
        {
            textBox_ID.SelectAll();
        }
        private void Button_Close_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void textBox_ID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (e.KeyChar != '\b'))
            {
                e.Handled = true;
            }
        }
        private void FrmInvices_CheckFouce(object sender, EventArgs e)
        {
            VarGeneral.InvTyp = 3;
        }
        public FrmInvSalesReturn()
        {
            InitializeComponent();this.Load += langloads;
            base.Activated += FrmInvices_CheckFouce;
            textBox_ID.KeyPress += textBox_ID_KeyPress;
            switchButton_PointActiv.Click += Button_Edit_Click;
            CmbInvSide.Click += Button_Edit_Click;
            textBox1.Click += Button_Edit_Click;
            textBox2.Click += Button_Edit_Click;
            textBox_Type.Click += Button_Edit_Click;
            txtAddress.Click += Button_Edit_Click;
            txtCustName.Click += Button_Edit_Click;
            txtCustNet.Click += Button_Edit_Click;
            txtCustNo.Click += Button_Edit_Click;
            txtCustRep.Click += Button_Edit_Click;
            txtDiscountP.Click += Button_Edit_Click;
            txtDiscountVal.Click += Button_Edit_Click;
            txtDiscountValLoc.Click += Button_Edit_Click;
            txtDiscoundPoints.Click += Button_Edit_Click;
            txtDiscoundPointsLoc.Click += Button_Edit_Click;
            txtDueAmount.Click += Button_Edit_Click;
            txtDueAmountLoc.Click += Button_Edit_Click;
            txtGDate.Click += Button_Edit_Click;
            txtHDate.Click += Button_Edit_Click;
            txtInvCost.Click += Button_Edit_Click;
            txtItemName.Click += Button_Edit_Click;
            txtRef.Click += Button_Edit_Click;
            txtDescription.Click += Button_Edit_Click;
            txtRemark.Click += Button_Edit_Click;
            txtTele.Click += Button_Edit_Click;
            txtTime.Click += Button_Edit_Click;
            txtTotalAm.Click += Button_Edit_Click;
            txtTotalAmLoc.Click += Button_Edit_Click;
            txtTotalQ.Click += Button_Edit_Click;
            CmbCostC.Click += Button_Edit_Click;
            CmbCurr.Click += Button_Edit_Click;
            checkBox_Chash.Click += Button_Edit_Click;
            checkBox_Credit.Click += Button_Edit_Click;
            checkBox_NetWork.Click += Button_Edit_Click;
            CmbInvPrice.Click += Button_Edit_Click;
            CmbLegate.Click += Button_Edit_Click;
            txtPaymentLoc.Click += Button_Edit_Click;
            doubleInput_CreditLoc.Click += Button_Edit_Click;
            doubleInput_NetWorkLoc.Click += Button_Edit_Click;
            switchButton_Tax.Click += Button_Edit_Click;
            checkBox_CostGaidTax.Click += Button_Edit_Click;
            switchButton_TaxLines.Click += Button_Edit_Click;
            switchButton_TaxLines.ValueChanged += switchButton_TaxLines_ValueChanged;
            switchButton_TaxByTotal.Click += Button_Edit_Click;
            switchButton_TaxByTotal.ValueChanged += switchButton_TaxLines_ValueChanged;
            switchButton_TaxByNet.Click += Button_Edit_Click;
            switchButton_TaxByNet.ValueChanged += switchButton_TaxLines_ValueChanged;
            switchButton_TaxByNet.ValueChanged += switchButton_TaxByNet_ValueChanged;
            textBoxItem_TaxByNetValue.KeyPress += textBoxItem_TaxByNetValue_KeyPress;
            textBoxItem_TaxByNetValue.LostFocus += textBoxItem_TaxByNetValue_LostFocus;
            textBoxItem_TaxByNetValue.GotFocus += Button_Edit_Click;
            switchButton_Dis.Click += Button_Edit_Click;
            checkBox_GaidDis.Click += Button_Edit_Click;
            txtDebit6.ButtonCustomClick += txtDebit6_ButtonCustomClick;
            txtCredit6.ButtonCustomClick += txtCredit6_ButtonCustomClick;
            checkBox_GaidDis.CheckedChanged += checkBox_GaidDis_CheckedChanged;
            switchButton_Dis.ValueChanged += switchButton_Dis_ValueChanged;
            expandableSplitter1.Click += expandableSplitter1_Click;
            ToolStripMenuItem_Det.Click += ToolStripMenuItem_Det_Click;
            Button_ExportTable2.Click += Button_ExportTable2_Click;
            textBox_search.InputTextChanged += TextBox_Search_InputTextChanged;
            textBox_search.ButtonCustomClick += TextBox_Search_ButtonCustomClick;
            TextBox_Index.InputTextChanged += TextBox_Index_InputTextChanged;
            Button_Close.Click += Button_Close_Click;
            Button_First.Click += Button_First_Click;
            Button_Prev.Click += Button_Prevouse_Click;
            Button_Next.Click += Button_Next_Click;
            Button_Last.Click += Button_Last_Click;
            Button_Add.Click += Button_Add_Click;
            Button_Search.Click += Button_Search_Click;
            Button_Delete.Click += Button_Delete_Click;
            Button_Save.Click += Button_Save_Click;
            TextBox_Index.InputTextChanged += TextBox_Index_InputTextChanged;
            expandableSplitter1.Click += expandableSplitter1_Click;
            DGV_Main.PrimaryGrid.CheckBoxes = true;
            DGV_Main.PrimaryGrid.ShowCheckBox = true;
            DGV_Main.PrimaryGrid.ShowTreeButton = true;
            DGV_Main.PrimaryGrid.ShowTreeButtons = true;
            DGV_Main.PrimaryGrid.ShowTreeLines = true;
            DGV_Main.PrimaryGrid.ShowRowGridIndex = true;
            DGV_Main.PrimaryGrid.RowHeaderWidth = 25;
            DGV_Main.DataBindingComplete += DGV_Main_DataBindingComplete;
            DGV_Main.CellClick += DGV_Main_CellClick;
            DGV_Main.CellDoubleClick += DGV_Main_CellDoubleClick;
            DGV_Main.GetCellStyle += DGV_MainGetCellStyle;
            DGV_Main.MouseDown += DGV_Main_MouseDown;
            DGV_Main.AfterCheck += DGV_Main_AfterCheck;
            textBox_ID.TextChanged += textBox_ID_TextChanged;
            textBox_ID.Click += textBox_ID_Click;
            txtHDate.Click += txtHDate_Click;
            txtHDate.Leave += txtHDate_Leave;
            txtGDate.Click += txtGDate_Click;
            txtGDate.Leave += txtGDate_Leave;
            txtTime.Click += txtTime_Click;
            txtTime.Leave += txtTime_Leave;
            button_SrchCustNo.Click += button_SrchCustNo_Click;
            CmbCurr.SelectedIndexChanged += CmbCurr_SelectedIndexChanged;
            checkBox_Chash.CheckedChanged += checkBox_Chash_CheckedChanged;
            checkBox_Credit.CheckedChanged += checkBox_Credit_CheckedChanged;
            checkBox_NetWork.CheckedChanged += checkBox_NetWork_CheckedChanged;
            FlxInv.Click += FlxInv_Click;
            FlxInv.AfterEdit += FlxInv_AfterEdit;
            FlxInv.BeforeEdit += FlxInv_BeforeEdit;
            //FlxInv.KeyDown += FlxInv_KeyDown;
            FlxInv.MouseDown += FlxInv_MouseDown;
            FlxInv.RowColChange += FlxInv_RowColChange;
            FlxInv.SelChange += FlxInv_SelChange;
            FlxDat.DoubleClick += FlxDat_DoubleClick;
            FlxDat.KeyDown += FlxDat_KeyDown;
            FlxDat.Leave += FlxDat_Leave;
            txtDiscountP.Leave += txtDiscountP_Leave;
            txtDiscountVal.Leave += txtDiscountVal_Leave;
            buttonItem_Print.Click += buttonItem_Print_Click;
            Button_PrintTable.Click += Button_Print_Click;
            txtDueAmountLoc.ValueChanged += txtDueAmountLoc_ValueChanged;
            txtRemark.ButtonCustomClick += txtRemark_ButtonCustomClick;
            txtDebit1.ButtonCustomClick += txtDebit1_ButtonCustomClick;
            txtDebit2.ButtonCustomClick += txtDebit2_ButtonCustomClick;
            txtDebit3.ButtonCustomClick += txtDebit3_ButtonCustomClick;
            txtDebit5.ButtonCustomClick += txtDebit5_ButtonCustomClick;
            txtCredit1.ButtonCustomClick += txtCredit1_ButtonCustomClick;
            txtCredit2.ButtonCustomClick += txtCredit2_ButtonCustomClick;
            txtCredit3.ButtonCustomClick += txtCredit3_ButtonCustomClick;
            txtCredit5.ButtonCustomClick += txtCredit5_ButtonCustomClick;
            button_CustD1.Click += button_CustD1_Click;
            button_CustD2.Click += button_CustD2_Click;
            button_CustD3.Click += button_CustD3_Click;
            button_CustD5.Click += button_CustD5_Click;
            button_CustC1.Click += button_CustC1_Click;
            button_CustC2.Click += button_CustC2_Click;
            button_CustC3.Click += button_CustC3_Click;
            button_CustC5.Click += button_CustC5_Click;
            txtCustNo.TextChanged += txtCustNo_TextChanged;
            txtPaymentLoc.Leave += txtPaymentLoc_Leave;
            doubleInput_CreditLoc.Leave += doubleInput_CreditLoc_Leave;
            doubleInput_NetWorkLoc.Leave += doubleInput_NetWorkLoc_Leave;
            FlxSerial.DoubleClick += FlxSerial_DoubleClick;
            FlxSerial.KeyDown += FlxSerial_KeyDown;
            FlxSerial.Leave += FlxSerial_Leave;
            if (VarGeneral.SSSLev == "B" || VarGeneral.SSSLev == "F" || VarGeneral.SSSLev == "S" || VarGeneral.SSSLev == "C")
            {
                CmbCostC.Visible = false;
                label15.Visible = false;
                if (VarGeneral.SSSLev == "F")
                {
                    CmbInvSide.Visible = false;
                    switchButton_PointActiv.Visible = false;
                    button_SrchCustPoints.Visible = false;
                    txtDiscoundPointsLoc.Visible = false;
                    txtDiscoundPoints.Visible = false;
                    label40.Visible = false;
                }
            }
            else
            {
                CmbCostC.Visible = true;
                label15.Visible = true;
            }
            try
            {
                if (VarGeneral.SSSLev == "B" || VarGeneral.SSSLev == "F")
                {
                    RegistryKey hKey = Registry.CurrentUser.OpenSubKey("Software\\PRS AND PR Settings\\WinSystemOperation", writable: true);
                    try
                    {
                        object q = hKey.GetValue("vCoCe");
                        if (string.IsNullOrEmpty(q.ToString()))
                        {
                            hKey.CreateSubKey("vCoCe");
                            hKey.SetValue("vCoCe", "0");
                        }
                    }
                    catch
                    {
                        hKey.CreateSubKey("vCoCe");
                        hKey.SetValue("vCoCe", "0");
                    }
                    long regval = long.Parse(hKey.GetValue("vCoCe").ToString());
                    if (regval == 1)
                    {
                        CmbCostC.Visible = true;
                        label15.Visible = true;
                    }
                    else
                    {
                        CmbCostC.Visible = false;
                        label15.Visible = false;
                    }
                }
            }
            catch
            {
            }
            if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49))
            {
                doubleInput_Rate.DisplayFormat = VarGeneral.DicemalMask;
                txtDiscountVal.DisplayFormat = VarGeneral.DicemalMask;
                txtDiscountP.DisplayFormat = VarGeneral.DicemalMask;
                txtTotalAmLoc.DisplayFormat = VarGeneral.DicemalMask;
                txtDueAmountLoc.DisplayFormat = VarGeneral.DicemalMask;
                txtDiscountValLoc.DisplayFormat = VarGeneral.DicemalMask;
                txtDiscoundPoints.DisplayFormat = VarGeneral.DicemalMask;
                txtDiscoundPointsLoc.DisplayFormat = VarGeneral.DicemalMask;
                txtPointCount.DisplayFormat = VarGeneral.DicemalMask;
                txtTotalAm.DisplayFormat = VarGeneral.DicemalMask;
                txtDueAmount.DisplayFormat = VarGeneral.DicemalMask;
                txtTotalQ.DisplayFormat = VarGeneral.DicemalMask;
                txtPaymentLoc.DisplayFormat = VarGeneral.DicemalMask;
                doubleInput_CreditLoc.DisplayFormat = VarGeneral.DicemalMask;
                doubleInput_NetWorkLoc.DisplayFormat = VarGeneral.DicemalMask;
                txtTotTax.DisplayFormat = VarGeneral.DicemalMask;
                txtTotTaxLoc.DisplayFormat = VarGeneral.DicemalMask;
                txtTotDis.DisplayFormat = VarGeneral.DicemalMask;
                txtTotDisLoc.DisplayFormat = VarGeneral.DicemalMask;
              }
            try
            {
                if (File.Exists(Application.StartupPath + "\\Script\\SecriptColDisSalesReturn.dll") || (VarGeneral.gUserName == "runsetting" && File.Exists(Application.StartupPath + "\\Script\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\SecriptColDisSalesReturn.dll")))
                {
                    FlxInv.Cols[36].DataType = typeof(double);
                    if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49))
                    {
                        FlxInv.Cols[36].Format = VarGeneral.DicimalNN;
                    }
                    else
                    {
                        FlxInv.Cols[36].Format = "N2";
                    }
                    FlxInv.Cols[36].Style.TextAlign = TextAlignEnum.CenterCenter;
                    FlxInv.Cols[36].StyleFixed.TextAlign = TextAlignEnum.CenterCenter;
                }
            }
            catch
            {
            }
            try
            {
                if (File.Exists(Application.StartupPath + "\\Script\\SecriptColDisSalesReturnValue.dll") || (VarGeneral.gUserName == "runsetting" && File.Exists(Application.StartupPath + "\\Script\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\SecriptColDisSalesReturnValue.dll")))
                {
                    FlxInv.Cols[36].DataType = typeof(double);
                    if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49))
                    {
                        FlxInv.Cols[36].Format = VarGeneral.DicimalNN;
                    }
                    else
                    {
                        FlxInv.Cols[36].Format = "N2";
                    }
                    FlxInv.Cols[36].Style.TextAlign = TextAlignEnum.CenterCenter;
                    FlxInv.Cols[36].StyleFixed.TextAlign = TextAlignEnum.CenterCenter;
                }
            }
            catch
            {
            }
        }
        private void txtDebit5_ButtonCustomClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_ID.Text))
            {
                return;
            }
            Button_Edit_Click(sender, e);
            columns_Names_visible2.Clear();
            columns_Names_visible2.Clear();
            columns_Names_visible2.Add("AccDef_No", new ColumnDictinary("الرقم ", " No", ifDefault: true, string.Empty));
            columns_Names_visible2.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, string.Empty));
            columns_Names_visible2.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, string.Empty));
            columns_Names_visible2.Add("AccDef_ID", new ColumnDictinary(" ", " ", ifDefault: false, string.Empty));
            columns_Names_visible2.Add("Mobile", new ColumnDictinary("الجوال", "Mobile", ifDefault: false, string.Empty));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible2;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
            }
            if (VarGeneral.SSSTyp == 0)
            {
                VarGeneral.SFrmTyp = "T_AccDef";
                VarGeneral.AccTyp = 5;
            }
            else
            {
                VarGeneral.SFrmTyp = "AccDefID_Setting";
            }
            frm.TopMost = true;
            frm.ShowDialog();
            try
            {
                if (frm.SerachNo != string.Empty)
                {
                    T_AccDef _AccDef = db.StockAccDefs(int.Parse(frm.Serach_No));
                    txtDebit5.Tag = _AccDef.AccDef_No;
                    if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                    {
                        txtDebit5.Text = _AccDef.Arb_Des;
                    }
                    else
                    {
                        txtDebit5.Text = _AccDef.Eng_Des;
                    }
                }
                else
                {
                    txtDebit5.Text = string.Empty;
                    txtDebit5.Tag = string.Empty;
                }
            }
            catch
            {
                txtDebit5.Text = string.Empty;
                txtDebit5.Tag = string.Empty;
            }
        }
        private void txtDebit6_ButtonCustomClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_ID.Text))
            {
                return;
            }
            Button_Edit_Click(sender, e);
            columns_Names_visible2.Clear();
            columns_Names_visible2.Clear();
            columns_Names_visible2.Add("AccDef_No", new ColumnDictinary("الرقم ", " No", ifDefault: true, string.Empty));
            columns_Names_visible2.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, string.Empty));
            columns_Names_visible2.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, string.Empty));
            columns_Names_visible2.Add("AccDef_ID", new ColumnDictinary(" ", " ", ifDefault: false, string.Empty));
            columns_Names_visible2.Add("Mobile", new ColumnDictinary("الجوال", "Mobile", ifDefault: false, string.Empty));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible2;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
            }
            if (VarGeneral.SSSTyp == 0)
            {
                VarGeneral.SFrmTyp = "T_AccDef";
                VarGeneral.AccTyp = 5;
            }
            else
            {
                VarGeneral.SFrmTyp = "AccDefID_Setting";
            }
            frm.TopMost = true;
            frm.ShowDialog();
            try
            {
                if (frm.SerachNo != string.Empty)
                {
                    T_AccDef _AccDef = db.StockAccDefs(int.Parse(frm.Serach_No));
                    txtDebit6.Tag = _AccDef.AccDef_No;
                    if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                    {
                        txtDebit6.Text = _AccDef.Arb_Des;
                    }
                    else
                    {
                        txtDebit6.Text = _AccDef.Eng_Des;
                    }
                }
                else
                {
                    txtDebit6.Text = string.Empty;
                    txtDebit6.Tag = string.Empty;
                }
            }
            catch
            {
                txtDebit6.Text = string.Empty;
                txtDebit6.Tag = string.Empty;
            }
        }
        private void txtCredit6_ButtonCustomClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_ID.Text))
            {
                return;
            }
            Button_Edit_Click(sender, e);
            columns_Names_visible2.Clear();
            columns_Names_visible2.Clear();
            columns_Names_visible2.Add("AccDef_No", new ColumnDictinary("الرقم ", " No", ifDefault: true, string.Empty));
            columns_Names_visible2.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, string.Empty));
            columns_Names_visible2.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, string.Empty));
            columns_Names_visible2.Add("AccDef_ID", new ColumnDictinary(" ", " ", ifDefault: false, string.Empty));
            columns_Names_visible2.Add("Mobile", new ColumnDictinary("الجوال", "Mobile", ifDefault: false, string.Empty));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible2;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
            }
            if (VarGeneral.SSSTyp == 0)
            {
                VarGeneral.SFrmTyp = "T_AccDef";
                VarGeneral.AccTyp = 5;
            }
            else
            {
                VarGeneral.SFrmTyp = "AccDefID_Setting";
            }
            frm.TopMost = true;
            frm.ShowDialog();
            try
            {
                if (frm.SerachNo != string.Empty)
                {
                    T_AccDef _AccDef = db.StockAccDefs(int.Parse(frm.Serach_No));
                    txtCredit6.Tag = _AccDef.AccDef_No;
                    if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                    {
                        txtCredit6.Text = _AccDef.Arb_Des;
                    }
                    else
                    {
                        txtCredit6.Text = _AccDef.Eng_Des;
                    }
                }
                else
                {
                    txtCredit6.Text = string.Empty;
                    txtCredit6.Tag = string.Empty;
                }
            }
            catch
            {
                txtCredit6.Text = string.Empty;
                txtCredit6.Tag = string.Empty;
            }
        }
        private void txtCredit5_ButtonCustomClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_ID.Text))
            {
                return;
            }
            Button_Edit_Click(sender, e);
            columns_Names_visible2.Clear();
            columns_Names_visible2.Clear();
            columns_Names_visible2.Add("AccDef_No", new ColumnDictinary("الرقم ", " No", ifDefault: true, string.Empty));
            columns_Names_visible2.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, string.Empty));
            columns_Names_visible2.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, string.Empty));
            columns_Names_visible2.Add("AccDef_ID", new ColumnDictinary(" ", " ", ifDefault: false, string.Empty));
            columns_Names_visible2.Add("Mobile", new ColumnDictinary("الجوال", "Mobile", ifDefault: false, string.Empty));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible2;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
            }
            if (VarGeneral.SSSTyp == 0)
            {
                VarGeneral.SFrmTyp = "T_AccDef";
                VarGeneral.AccTyp = 5;
            }
            else
            {
                VarGeneral.SFrmTyp = "AccDefID_Setting";
            }
            frm.TopMost = true;
            frm.ShowDialog();
            try
            {
                if (frm.SerachNo != string.Empty)
                {
                    T_AccDef _AccDef = db.StockAccDefs(int.Parse(frm.Serach_No));
                    txtCredit5.Tag = _AccDef.AccDef_No;
                    if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                    {
                        txtCredit5.Text = _AccDef.Arb_Des;
                    }
                    else
                    {
                        txtCredit5.Text = _AccDef.Eng_Des;
                    }
                }
                else
                {
                    txtCredit5.Text = string.Empty;
                    txtCredit5.Tag = string.Empty;
                }
            }
            catch
            {
                txtCredit5.Text = string.Empty;
                txtCredit5.Tag = string.Empty;
            }
        }
        private void button_CustC5_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCustNo.Text))
            {
                Button_Edit_Click(sender, e);
                txtCredit5.Tag = txtCustNo.Text;
                txtCredit5.Text = ((LangArEn == 0) ? db.SelectAccRootByCode(txtCustNo.Text).Arb_Des : db.SelectAccRootByCode(txtCustNo.Text).Eng_Des);
            }
        }
        private void button_CustD5_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCustNo.Text))
            {
                Button_Edit_Click(sender, e);
                txtDebit5.Tag = txtCustNo.Text;
                txtDebit5.Text = ((LangArEn == 0) ? db.SelectAccRootByCode(txtCustNo.Text).Arb_Des : db.SelectAccRootByCode(txtCustNo.Text).Eng_Des);
            }
        }
        private int vStr(int vTy)
        {
            if (VarGeneral.InvTyp == 1)
            {
                if (VarGeneral._IsPOS)
                {
                    return 27;
                }
                return 1;
            }
            if (VarGeneral.InvTyp == 1)
            {
                return 1;
            }
            if (VarGeneral.InvTyp == 2)
            {
                return 5;
            }
            if (VarGeneral.InvTyp == 3)
            {
                return 3;
            }
            if (VarGeneral.InvTyp == 4)
            {
                return 7;
            }
            if (VarGeneral.InvTyp == 7)
            {
                return 9;
            }
            if (VarGeneral.InvTyp == 8)
            {
                return 11;
            }
            if (VarGeneral.InvTyp == 9)
            {
                return 13;
            }
            if (VarGeneral.InvTyp == 14)
            {
                return 15;
            }
            if (VarGeneral.InvTyp == 5)
            {
                return 17;
            }
            if (VarGeneral.InvTyp == 6)
            {
                return 19;
            }
            if (VarGeneral.InvTyp == 17)
            {
                return 21;
            }
            if (VarGeneral.InvTyp == 20)
            {
                return 23;
            }
            return 25;
        }
        public void buttonItem_Print_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox_ID.Text != string.Empty && State == FormState.Saved)
                {
                    VarGeneral.Print_set_Gen_Stat = false;
                if ((_InvSetting.InvpRINTERInfo.nTyp.Substring(1, 1) != "2"))
                    {
                        RepShow _RepShow = new RepShow();
                        _RepShow.Tables = "T_INVDET LEFT OUTER JOIN T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID LEFT OUTER JOIN T_INVSETTING ON T_INVHED.InvTyp = T_INVSETTING.InvID  LEFT OUTER JOIN T_Curency ON T_INVHED.CurTyp = T_Curency.Curency_ID LEFT OUTER JOIN T_CstTbl ON T_INVHED.InvCstNo = T_CstTbl.Cst_ID LEFT OUTER JOIN T_Mndob ON T_INVHED.MndNo = T_Mndob.Mnd_ID LEFT OUTER JOIN T_Items ON T_INVDET.ItmNo = T_Items.Itm_No LEFT OUTER JOIN T_CATEGORY ON T_Items.ItmCat = T_CATEGORY.CAT_ID LEFT OUTER JOIN T_SYSSETTING ON T_INVHED.CompanyID = T_SYSSETTING.SYSSETTING_ID ";
                        string vInvH = " T_INVHED.InvHed_ID, T_INVHED.InvId as vID, T_INVHED.InvNo, T_INVHED.InvTyp, T_INVHED.InvCashPay, T_INVHED.CusVenNo,case when T_INVHED.CusVenNo = '' THEN T_INVHED.CusVenNm ELSE (select T_AccDef.Arb_Des from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as CusVenNm,case when T_INVHED.CusVenNo = '' THEN T_INVHED.CusVenNm ELSE (select T_AccDef.Eng_Des from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as CusVenNmE, T_INVHED.CusVenAdd, T_INVHED.CusVenTel, T_INVHED.Remark, T_INVHED.HDat, T_INVHED.GDat, T_INVHED.MndNo, T_INVHED.SalsManNo, T_INVHED.SalsManNam, T_INVHED.InvTot, T_INVHED.InvDisPrs, ((case when IsDisUse1 = 1 then T_INVHED.InvValGaidDis else T_INVHED.InvDisVal end) + T_INVHED.DesPointsValue) as InvDisVal,T_INVHED.InvDisVal as InvDisValOnly,T_INVHED.DesPointsValue,T_INVHED.DesPointsValueLocCur,T_INVHED.PointsCount,T_INVHED.IsPoints, T_INVHED.InvNet, T_INVHED.InvNetLocCur, T_INVHED.CashPayLocCur, T_INVHED.IfRet, T_INVHED.CashPay, T_INVHED.InvTotLocCur, T_INVHED.InvDisValLocCur, T_INVHED.GadeNo, T_INVHED.GadeId, T_INVHED.RetNo, T_INVHED.RetId, T_INVHED.InvCashPayNm, T_INVHED.InvCost, T_INVHED.CustPri, T_INVHED.ArbTaf, T_INVHED.ToStore, T_INVHED.InvCash, T_INVHED.CurTyp, T_INVHED.EstDat,case when DATEDIFF(day, GETDATE(), EstDat) > 0 Then DATEDIFF(day, GETDATE(), EstDat) WHEN DATEDIFF(day, GETDATE(), InvCashPayNm) > 0 THEN DATEDIFF(day, GETDATE(), InvCashPayNm) Else '0' END as EstDatNote, T_INVHED.InvCstNo, T_INVHED.IfDel, T_INVHED.RefNo, T_INVHED.ToStoreNm, T_INVHED.EngTaf, T_INVHED.IfTrans, T_INVHED.InvQty, T_INVHED.CustNet, T_INVHED.CustRep, T_INVHED.InvWight_T, T_INVHED.IfPrint, T_INVHED.LTim, T_INVHED.DATE_CREATED, T_INVHED.MODIFIED_BY, T_INVHED.CreditPay, T_INVHED.DATE_MODIFIED, T_INVHED.CREATED_BY, T_INVHED.CreditPayLocCur, T_INVHED.NetworkPay, T_INVHED.NetworkPayLocCur, T_INVHED.MndExtrnal, T_INVHED.CompanyID, T_INVHED.InvAddCost, T_INVHED.InvAddCostExtrnal, T_INVHED.InvAddCostExtrnalLoc, T_INVHED.IsExtrnalGaid, T_INVHED.ExtrnalCostGaidID, T_INVHED.InvAddCostLoc, T_INVHED.CommMnd_Inv, T_INVHED.Puyaid, T_INVHED.Remming,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select T_AccDef.PersonalNm from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as PersonalNm,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select T_AccDef.City from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as City,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select T_AccDef.Email from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as Email,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select T_AccDef.Mobile from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as Mobile,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select T_AccDef.Telphone1 from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as Telphone1,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select vColStr1 from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as CustAge,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select T_AccDef.Telphone2 from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as Telphone2,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select T_AccDef.Fax from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as Fax,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select T_AccDef.zipCod from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as zipCod,T_SYSSETTING.LineGiftlNameA,T_SYSSETTING.LineGiftlNameE,T_Curency.Arb_Des as CurrnceyNm,T_Curency.Eng_Des as CurrnceyNmE,(select max(gdDes)from T_GDDET where gdID = T_INVHED.GadeId )as gdDes, (T_INVDET.Amount - (case when T_INVHED.IsTaxLines = 1 then (case when T_INVHED.IsTaxByTotal = 1 then (case when (Abs(T_INVDET.Qty) *  T_INVDET.Price * T_INVDET.ItmTax / 100) > 0 then ((Abs(T_INVDET.Qty) *  T_INVDET.Price) - case when (Abs(T_INVDET.Qty) * T_INVDET.Price * T_INVDET.ItmDis / 100) > 0 then (Abs(T_INVDET.Qty) * T_INVDET.Price * T_INVDET.ItmDis / 100) else 0 end )* T_INVDET.ItmTax / 100   else 0 end) else (Abs(T_INVDET.Qty) *  T_INVDET.Price * T_INVDET.ItmTax / 100) end) else 0 end )) as TotBeforeTax,(select invGdADesc from T_INVSETTING where T_INVHED.InvTyp = T_INVSETTING.InvID ) as invGdADesc,(select invGdEDesc from T_INVSETTING where T_INVHED.InvTyp = T_INVSETTING.InvID ) as invGdEDesc,(select T_CATEGORY.CAT_No from T_CATEGORY where T_CATEGORY.CAT_ID = T_Items.ItmCat) as CAT_No,(select T_CATEGORY.Arb_Des from T_CATEGORY where T_CATEGORY.CAT_ID = T_Items.ItmCat) as CatNmA,(select T_CATEGORY.Eng_Des from T_CATEGORY where T_CATEGORY.CAT_ID = T_Items.ItmCat) as CatNmE,(case when (select t.BarCod1 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit1 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt )) != '' then (select t.BarCod1 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit1 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt ))  when (select t.BarCod2 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit2 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt )) != '' then (select t.BarCod2 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit2 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt )) when (select t.BarCod3 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit3 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt )) != '' then (select t.BarCod3 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit3 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt )) when (select t.BarCod4 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit4 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt )) != '' then (select t.BarCod4 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit4 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt )) when (select t.BarCod5 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit5 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt )) != '' then (select t.BarCod5 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit5 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt )) else T_Items.Itm_No  end) as ItmBarcod";
                        string Fields = " Abs(T_INVDET.Qty) as QtyAbs , T_INVDET.InvDet_ID,T_INVHED.tailor1,T_INVHED.tailor2,T_INVHED.tailor3,T_INVHED.tailor4,T_INVHED.tailor5,T_INVHED.tailor6,T_INVHED.tailor7,T_INVHED.tailor8,T_INVHED.tailor9,T_INVHED.tailor10,T_INVHED.tailor11,T_INVHED.tailor12,T_INVHED.tailor13,T_INVHED.tailor14,T_INVHED.tailor15,T_INVHED.tailor16,T_INVHED.tailor17,T_INVHED.tailor18,T_INVHED.tailor19,T_INVHED.tailor20,T_INVHED.InvImg, T_INVDET.InvNo, T_INVDET.InvId, T_INVDET.InvSer, T_INVDET.ItmNo, T_INVDET.Cost, T_INVDET.Qty, T_INVDET.ItmUnt, T_INVDET.ItmDes,T_INVDET.ItmDesE , T_INVDET.ItmUntE, T_INVDET.ItmUntPak, T_INVDET.StoreNo, T_INVDET.Price, T_INVDET.Amount, T_INVDET.RealQty, T_INVDET.ItmTyp,T_INVDET.ItmDis, (Abs(T_INVDET.Qty) *  T_INVDET.Price) * (T_INVDET.ItmDis / 100) as ItmDisVal, T_INVDET.DatExper, T_INVDET.itmInvDsc,ItmIndex," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.LineGiftSts, vStr(VarGeneral.InvTyp)) ? " T_INVDET.ItmWight " : " 0 as ItmWight") + ", T_INVDET.ItmWight_T, T_INVDET.ItmAddCost, T_INVDET.RunCod, T_INVDET.LineDetails ,T_INVDET.Serial_Key, " + vInvH + ", T_Items.* , T_CstTbl.Arb_Des as CstTbl_Arb_Des , T_CstTbl.Eng_Des as CstTbl_Eng_Des , T_Mndob.Arb_Des as Mndob_Arb_Des , T_Mndob.Eng_Des as Mndob_Eng_Des,T_SYSSETTING.LogImg,(select max(T_AccDef.TaxNo) from T_AccDef where T_AccDef.AccDef_No = T_SYSSETTING.TaxAcc) as TaxAcc,T_SYSSETTING.TaxNoteInv,case when T_INVHED.IsTaxLines = 1 then (case when T_INVHED.IsTaxByTotal = 1 then (case when (Abs(T_INVDET.Qty) *  T_INVDET.Price * T_INVDET.ItmTax / 100) > 0 then ((Abs(T_INVDET.Qty) *  T_INVDET.Price) - case when (Abs(T_INVDET.Qty) * T_INVDET.Price * T_INVDET.ItmDis / 100) > 0 then (Abs(T_INVDET.Qty) * T_INVDET.Price * T_INVDET.ItmDis / 100) else 0 end )* T_INVDET.ItmTax / 100   else 0 end) else (Abs(T_INVDET.Qty) *  T_INVDET.Price * T_INVDET.ItmTax / 100) end) else 0 end as TaxValue ,(select InvNamA from T_INVSETTING where T_INVHED.InvTyp = T_INVSETTING.InvID ) as InvNamA,(select InvNamE from T_INVSETTING where T_INVHED.InvTyp = T_INVSETTING.InvID ) as InvNamE,(select T_Store.Arb_Des from T_Store where T_Store.Stor_ID = T_INVDET.StoreNo) as StoreNmA,(select T_Store.Eng_Des from T_Store where T_Store.Stor_ID = T_INVDET.StoreNo) as StoreNmE,(select defPrn from T_INVSETTING where CatID = (select ItmCat from T_Items where Itm_No = T_INVDET.ItmNo) ) as defPrn,case when T_INVHED.CusVenNo = '' THEN '0' ELSE (SELECT Sum(T_GDDET.gdValue) FROM T_GDHEAD INNER JOIN  T_GDDET ON T_GDHEAD.gdhead_ID = T_GDDET.gdID where T_GDDET.AccNo = T_INVHED.CusVenNo and T_GDHEAD.gdLok = 0 and (select T_AccDef.AccCat from T_AccDef where T_AccDef.AccDef_No = T_INVHED.CusVenNo) = '4') END as Balanc,T_INVDET.ItmTax,T_INVHED.InvAddTax,T_INVHED.InvAddTaxlLoc,T_INVHED.TaxGaidID,T_INVHED.IsTaxUse,T_INVHED.IsTaxLines,IsTaxByTotal,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select T_AccDef.TaxNo from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as TaxCustNo,T_INVHED.OrderTyp," + ((data_this.IsTaxLines.Value && !VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 65)) ? " T_INVHED.InvTotLocCur - T_INVHED.InvAddTax as TotWithTaxPoint " : " T_INVHED.InvTotLocCur as TotWithTaxPoint") + " ,T_INVHED.InvTotLocCur - T_INVHED.InvDisVal as TotBeforeDisVal,T_INVHED.IsTaxByNet,T_INVHED.TaxByNetValue," + (data_this.IsTaxUse.Value ? " T_INVHED.InvNetLocCur - T_INVHED.InvAddTax as NetWithoutTax " : " T_INVHED.InvNetLocCur as NetWithoutTax");
                        VarGeneral.HeaderRep[0] = Text;
                        VarGeneral.HeaderRep[1] = string.Empty;
                        VarGeneral.HeaderRep[2] = string.Empty;
                        _RepShow.Rule = " where T_INVHED.InvHed_ID = " + data_this.InvHed_ID;
                        if (File.Exists(Application.StartupPath + "\\Script\\SecriptMaintenanceCars.dll"))
                        {
                            Fields += ",case when (select SUM(Amount) from T_INVDET where T_INVDET.InvId = T_INVHED.InvHed_ID and T_INVDET.ItmNo = T_Items.Itm_No and ItmUnt = 'ميكانيكا / كهرباء') != '' then (select SUM(Amount) from T_INVDET where T_INVDET.InvId = T_INVHED.InvHed_ID and T_INVDET.ItmNo = T_Items.Itm_No and ItmUnt = 'ميكانيكا / كهرباء')  else 0 end as Unt1,case when (select SUM(Amount) from T_INVDET where T_INVDET.InvId = T_INVHED.InvHed_ID and T_INVDET.ItmNo = T_Items.Itm_No and ItmUnt = 'سمكرة') != '' then (select SUM(Amount) from T_INVDET where T_INVDET.InvId = T_INVHED.InvHed_ID and T_INVDET.ItmNo = T_Items.Itm_No and ItmUnt = 'سمكرة') else 0 end as Unt2,case when (select SUM(Amount) from T_INVDET where T_INVDET.InvId = T_INVHED.InvHed_ID and T_INVDET.ItmNo = T_Items.Itm_No and ItmUnt = 'دهان') != '' then (select SUM(Amount) from T_INVDET where T_INVDET.InvId = T_INVHED.InvHed_ID and T_INVDET.ItmNo = T_Items.Itm_No and ItmUnt = 'دهان') else 0 end as Unt3,case when (select SUM(Amount) from T_INVDET where T_INVDET.InvId = T_INVHED.InvHed_ID and T_INVDET.ItmNo = T_Items.Itm_No and ItmUnt = 'قطع غيار') != '' then (select SUM(Amount) from T_INVDET where T_INVDET.InvId = T_INVHED.InvHed_ID and T_INVDET.ItmNo = T_Items.Itm_No and ItmUnt = 'قطع غيار') else 0 end as Unt4,case when (select SUM(Amount) from T_INVDET where T_INVDET.InvId = T_INVHED.InvHed_ID and T_INVDET.ItmNo = T_Items.Itm_No and ItmUnt = 'أجور يد') != '' then (select SUM(Amount) from T_INVDET where T_INVDET.InvId = T_INVHED.InvHed_ID and T_INVDET.ItmNo = T_Items.Itm_No and ItmUnt = 'أجور يد') else 0 end as Unt5";
                        }
                        if (!string.IsNullOrEmpty(Fields))
                        {
                            _RepShow.Fields = Fields;
                            try
                            {
                                _RepShow = _RepShow.Save();
                                VarGeneral.RepData = _RepShow.RepData;
                                _RepShow = new RepShow();
                                _RepShow.Rule = " WHERE T_Users.UsrNo = '" + data_this.SalsManNo + "'";
                                _RepShow.Tables = " T_Branch INNER JOIN T_Users ON T_Branch.Branch_no = T_Users.Brn ";
                                _RepShow.Fields = " T_Users.UsrNamA ,T_Branch.Branch_Name ,T_Users.UsrNamE ,T_Branch.Branch_NameE ,T_Users.UsrImg ";
                                try
                                {
                                    VarGeneral.RepShowStock_Rat = "Rate";
                                    _RepShow = _RepShow.Save();
                                    VarGeneral.RepShowStock_Rat = string.Empty;
                                }
                                catch (Exception ex2)
                                {
                                    VarGeneral.RepShowStock_Rat = string.Empty;
                                    MessageBox.Show(ex2.Message);
                                }
                                _RepShow.RepData.Tables[0].Merge(VarGeneral.RepData.Tables[0]);
                                VarGeneral.RepData = _RepShow.RepData;
                                try
                                {
                                    for (int i = 0; i < VarGeneral.RepData.Tables[0].Rows.Count; i++)
                                    {
                                        if (string.IsNullOrEmpty(VarGeneral.RepData.Tables[0].Rows[i]["LogImg"].ToString()))
                                        {
                                            VarGeneral.RepData.Tables[0].Rows[i]["LogImg"] = VarGeneral.RepData.Tables[0].Rows[VarGeneral.RepData.Tables[0].Rows.Count - 1]["LogImg"];
                                            VarGeneral.RepData.Tables[0].Rows[i]["LTim"] = VarGeneral.RepData.Tables[0].Rows[VarGeneral.RepData.Tables[0].Rows.Count - 1]["LTim"];
                                        }
                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    for (int i = 0; i < VarGeneral.RepData.Tables[0].Rows.Count; i++)
                                    {
                                        if (string.IsNullOrEmpty(VarGeneral.RepData.Tables[0].Rows[i]["UsrImg"].ToString()))
                                        {
                                            try
                                            {
                                                VarGeneral.RepData.Tables[0].Rows[i]["UsrImg"] = VarGeneral.RepData.Tables[0].Rows[0]["UsrImg"];
                                            }
                                            catch
                                            {
                                            }
                                        }
                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    if (VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 15))
                                    {
                                        _RepShow = new RepShow();
                                        _RepShow.Rule = string.Empty;
                                        _RepShow.Tables = "T_SINVDET LEFT OUTER JOIN T_INVHED ON T_SINVDET.SInvIdHEAD = T_INVHED.InvHed_ID LEFT OUTER JOIN T_INVSETTING ON T_INVHED.InvTyp = T_INVSETTING.InvID  LEFT OUTER JOIN T_Curency ON T_INVHED.CurTyp = T_Curency.Curency_ID LEFT OUTER JOIN T_CstTbl ON T_INVHED.InvCstNo = T_CstTbl.Cst_ID LEFT OUTER JOIN T_Mndob ON T_INVHED.MndNo = T_Mndob.Mnd_ID LEFT OUTER JOIN T_Items ON T_SINVDET.SItmNo = T_Items.Itm_No LEFT OUTER JOIN T_CATEGORY ON T_Items.ItmCat = T_CATEGORY.CAT_ID LEFT OUTER JOIN T_SYSSETTING ON T_INVHED.CompanyID = T_SYSSETTING.SYSSETTING_ID ";
                                        _RepShow.Fields = " Abs(T_SINVDET.SQty) as QtyAbs , SInvDet_ID as InvId, SInvNo as InvNo, SInvId as InvDet_ID, SInvSer as InvSer,SItmNo as ItmNo, SCost as Cost, SQty as Qty, SItmDes as ItmDes, SItmUnt as ItmUnt, SItmDesE as ItmDesE, SItmUntE as ItmUntE, SItmUntPak as ItmUntPak, SStoreNo as StoreNo, (SPrice * 0) as Price, (SAmount * 0) as Amount, SRealQty as RealQty, SitmInvDsc as itmInvDsc, SDatExper as DatExper, SItmDis as ItmDis, SItmTyp as ItmTyp,SItmIndex as ItmIndex, SItmWight_T as ItmWight_T, SItmWight as ItmWight , T_INVHED.* , T_Items.* , T_CstTbl.Arb_Des as CstTbl_Arb_Des , T_CstTbl.Eng_Des as CstTbl_Eng_Des , T_Mndob.Arb_Des as Mndob_Arb_Des , T_Mndob.Eng_Des as Mndob_Eng_Des,T_SYSSETTING.LogImg,(select max(T_AccDef.TaxNo) from T_AccDef where T_AccDef.AccDef_No = T_SYSSETTING.TaxAcc) as TaxAcc,T_SYSSETTING.TaxNoteInv";
                                        _RepShow.Rule = " where T_INVHED.InvHed_ID = " + data_this.InvHed_ID;
                                        _RepShow = _RepShow.Save();
                                        VarGeneral.RepData.Tables[0].Merge(_RepShow.RepData.Tables[0]);
                                    }
                                }
                                catch
                                {
                                }
                            }
                            catch (Exception ex2)
                            {
                                MessageBox.Show(ex2.Message);
                            }
                            if (VarGeneral.RepData.Tables[0].Rows.Count != 0)
                            {
                                try
                                {
                                    FrmReportsViewer frm = new FrmReportsViewer();
                                    FrmReportsViewer.QRCodeData = Utilites.GetWQRCodeData(DataThis);
                                    frm.Repvalue = "InvSalReturn";
                                    frm.RepCashier = "InvoiceCachier";
                                    frm.Tag = LangArEn;
                                    if (ifMultiPrint)
                                    {
                                        frm.BarcodSts = true;
                                    }
                                    else
                                    {
                                        frm.BarcodSts = false;
                                    }
                                    if (_InvSetting.InvpRINTERInfo.nTyp.Substring(1, 1) == "1")
                                    {
                                        frm.Repvalue = "InvSalReturn";
                                    }
                                    else
                                    {
                                        frm.RepCashier = "InvoiceCachier";
                                    }
                                    if (ChkA4Cahir.Checked)
                                    {
                                        if (frm.Repvalue == "InvSalReturn")
                                        {
                                            frm.RepCashier = "InvoiceCachier";
                                        }
                                        else
                                        {
                                            frm.Repvalue = "InvSalReturn";
                                        }
                                        VarGeneral.PrintingSettingGen = new PrintDialog();
                                        VarGeneral.prnt_doc_Gen = new PrintDocument(); VarGeneral.PrintingSettingGen.UseEXDialog = true;
                                        if (VarGeneral.PrintingSettingGen.ShowDialog() != DialogResult.OK)
                                        {
                                            return;
                                        }
                                        VarGeneral.prnt_doc_Gen.PrinterSettings = VarGeneral.PrintingSettingGen.PrinterSettings;
                                        VarGeneral.Print_set_Gen_Stat = true;
                                    }
                                    VarGeneral.CostCenterlbl = label15.Text.Replace(" :", string.Empty);
                                    VarGeneral.Mndoblbl = label18.Text.Replace(" :", string.Empty);
                                    VarGeneral.vTitle = Text;
                                    if (_InvSetting.InvpRINTERInfo.nTyp.Substring(2, 1) == "1" || ifMultiPrint)
                                    {
                                        frm._Proceess();
                                    }
                                    else
                                    {
                                        frm.TopMost = true;
                                        frm.ShowDialog();
                                    }
                                }
                                catch (Exception error)
                                {
                                    VarGeneral.DebLog.writeLog("buttonItem_Print_Click:", error, enable: true);
                                    MessageBox.Show(error.Message);
                                }
                            }
                        }
                    }
                    else
                    {
                        PrintSet();
                        prnt_doc.Print();
                    }
                }
            }
            catch
            {
                MessageBox.Show((LangArEn == 0) ? "لا توجد حقول للطباعة تأكد من إعدادات الطباعة" : "No printing fields make sure the print settings", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            VarGeneral.Print_set_Gen_Stat = false;
        }
        private void PrintSet()
        {
            string _PrinterName = prnt_doc.PrinterSettings.PrinterName;
            prnt_doc.PrinterSettings.PrinterName = _InvSetting.InvpRINTERInfo.defPrn;
            if (!prnt_doc.PrinterSettings.IsValid)
            {
                prnt_doc.PrinterSettings.PrinterName = _PrinterName;
            }
            if (_InvSetting.Orientation == 1)
            {
                prnt_doc.PrinterSettings.DefaultPageSettings.Landscape = false;
            }
            else
            {
                prnt_doc.PrinterSettings.DefaultPageSettings.Landscape = true;
            }
        }
        public void Button_Search_Click(object sender, EventArgs e)
        {
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
            }
            VarGeneral.SFrmTyp = "T_Inv";
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != string.Empty)
            {
                textBox_ID.Text = frm.SerachNo.ToString();
            }
        }
        public void ReorderColumns()
        {
            if (!ifAutoOrderColumn)
            {
                return;
            }
            int i = 0;
            foreach (string item in columns_Names_visible.Keys)
            {
                try
                {
                    DGV_Main.PrimaryGrid.Columns[item].DisplayIndex = i;
                }
                catch
                {
                }
                i++;
            }
        }
        public void DGV_Main_ColumnResized(object sender, GridColumnEventArgs e)
        {
            if (ViewState == ViewState.Deiles)
            {
                return;
            }
            foreach (KeyValuePair<string, string> item in columns_Nams_Sums)
            {
                TextBox textBox = new TextBox();
                textBox.Visible = DGV_Main.PrimaryGrid.Columns[item.Key].IsOnScreen;
                textBox.Text = item.Value;
                textBox.Location = new Point(DGV_Main.PrimaryGrid.Columns[item.Key].Bounds.X, 3);
                textBox.Size = new Size(DGV_Main.PrimaryGrid.Columns[item.Key].Width, 20);
            }
        }
        private void DGV_Main_DataBindingComplete(object sender, GridDataBindingCompleteEventArgs e)
        {
            ReorderColumns();
            DGV_Main_ColumnResized(new object(), new GridColumnEventArgs(new GridPanel(), new GridColumn()));
            GridPanel panel = e.GridPanel;
            switch (panel.DataMember)
            {
                case "T_INVHED":
                    PropHIOfferPanel(panel);
                    break;
                case "Line":
                    PropLOfferPanel(panel);
                    break;
            }
        }
        public void Clear()
        {
            if (State == FormState.New)
            {
                return;
            }
            State = FormState.New;
            data_this = new T_INVHED();
            data_thisRe = new T_INVHED();
            _GdHead = new T_GDHEAD();
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
                else
                {
                    if (controls[i].Name == codeControl.Name)
                    {
                        continue;
                    }
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
                    else if (controls[i].GetType() == typeof(ComboBox))
                    {
                        (controls[i] as ComboBox).SelectedIndex = 0;
                    }
                    else if (controls[i].GetType() == typeof(ComboBoxEx))
                    {
                        try
                        {
                            (controls[i] as ComboBoxEx).SelectedIndex = 0;
                        }
                        catch
                        {
                        }
                    }
                }
            }
            if (FlxInv.Rows.Count <= 1)
            {
                FlxInv.Rows.Count = VarGeneral.Settings_Sys.LineOfInvoices.Value;
            }
            else
            {
                int _rowsCnt = FlxInv.Rows.Count;
                FlxInv.Rows.Count = 1;
                FlxInv.Rows.Count = _rowsCnt;
                FlxInv.Clear(ClearFlags.Content, 1, 1, FlxInv.Rows.Count - 1, 39);
            }
            FlxStkQty.Clear(ClearFlags.Content, 1, 1, 1, 1);
            ItemDetRemoved = new List<int>();
            try
            {
                dataGridView_ItemDet.Clear(ClearFlags.Content, 1, 1, dataGridView_ItemDet.Rows.Count - 1, 34);
            }
            catch
            {
            }
            dataGridView_ItemDet.Rows.Count = 1;
            try
            {
                int? calendr = _SysSetting.InvMod;
                if (calendr.Value == 0 && calendr.HasValue)
                {
                    checkBox_Chash.Checked = true;
                }
                else
                {
                    checkBox_Credit.Checked = true;
                }
            }
            catch
            {
                checkBox_Chash.Checked = true;
            }
            superTabControl_Info.SelectedTabIndex = 0;
            try
            {
                CmbCurr.SelectedValue = int.Parse(VarGeneral.Settings_Sys.ImportIp.ToString());
            }
            catch
            {
            }
            CmbCurr_SelectedIndexChanged(null, null);
            textBox_Usr.Text = ((LangArEn == 0) ? VarGeneral.UserNameA : VarGeneral.UserNameE);
            ButReturn.Tag = 0;
            switchButton_Lock.Value = false;
            label_LockeName.Text = ((LangArEn == 0) ? "غير مقف\u0651ــلة" : "Unlocked");
            textBox_ID.ButtonCustom.Visible = false;
            CmbInvSide.SelectedIndex = 0;
            _GdHeadCostTax = new T_GDHEAD();
            try
            {
                switchButton_Tax.Value = VarGeneral.TString.ChkStatShow(_InvSetting.TaxOptions, 4);
            }
            catch
            {
                switchButton_Tax.Value = true;
            }
            try
            {
                switchButton_TaxLines.Value = VarGeneral.TString.ChkStatShow(_InvSetting.TaxOptions, 5);
            }
            catch
            {
                switchButton_TaxLines.Value = true;
            }
            try
            {
                switchButton_TaxByTotal.Value = VarGeneral.TString.ChkStatShow(_InvSetting.TaxOptions, 6);
            }
            catch
            {
                switchButton_TaxByTotal.Value = false;
            }
            try
            {
                switchButton_TaxByNet.Value = VarGeneral.TString.ChkStatShow(_InvSetting.TaxOptions, 7);
            }
            catch
            {
                switchButton_TaxByNet.Value = false;
            }
            try
            {
                textBoxItem_TaxByNetValue.Text = (VarGeneral.TString.ChkStatShow(_InvSetting.TaxOptions, 2) ? VarGeneral.Settings_Sys.DefPurchaesTax.Value : VarGeneral.Settings_Sys.DefSalesTax.Value).ToString();
            }
            catch
            {
                textBoxItem_TaxByNetValue.Text = "0";
            }
            checkBox_CostGaidTax.Checked = false;
            txtDebit5.Tag = string.Empty;
            txtCredit5.Tag = string.Empty;
            _GdHeadCostDis = new T_GDHEAD();
            if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 57))
            {
                switchButton_Dis.Value = true;
            }
            else
            {
                switchButton_Dis.Value = false;
            }
            checkBox_GaidDis.Checked = false;
            txtDebit6.Tag = string.Empty;
            txtCredit6.Tag = string.Empty;
            txtPointCount.Value = 0.0;
            switchButton_PointActiv.Value = false;
            SetReadOnly = false;
        }
        private void InvModeChanged()
        {
            setdefaultaccounts();
            if (checkBox_Credit.Checked)
            {
                pictureBox_Cash.Visible = false;
                pictureBox_NetWord.Visible = false;
                pictureBox_Credit.Visible = true;
                doubleInput_CreditLoc.IsInputReadOnly = false;
                label6.Text = ((LangArEn == 0) ? "مدفوع :" : "Cash :");
            }
            else if (checkBox_NetWork.Checked)
            {
                pictureBox_Cash.Visible = false;
                pictureBox_NetWord.Visible = true;
                pictureBox_Credit.Visible = false;
                doubleInput_CreditLoc.IsInputReadOnly = true;
                label6.Text = ((LangArEn == 0) ? "نقــدا\u064c :" : "Cash :");
            }
            else
            {
                pictureBox_Cash.Visible = true;
                pictureBox_NetWord.Visible = false;
                pictureBox_Credit.Visible = false;
                doubleInput_CreditLoc.IsInputReadOnly = true;
                label6.Text = ((LangArEn == 0) ? "نقــدا\u064c :" : "Paid :");
            }
            txtDueAmountLoc_ValueChanged(null, null);
            checkBox_CostGaidTax_CheckedChanged(null, null);
        }
        void setdefaultaccounts()
        {
            GetInvSetting();
            AutoGaidAcc();
            if (checkBox_Credit.Checked == true && txtCustNo.Text != string.Empty)
            {
                txtDebit2.Text = txtCustName.Text;
                txtDebit2.Tag = txtCustNo.Text;
            }
        }
        private void checkBox_Chash_CheckedChanged(object sender, EventArgs e)
        {
            InvModeChanged();
        }
        private void checkBox_Credit_CheckedChanged(object sender, EventArgs e)
        {
            InvModeChanged();
        }
        private void checkBox_NetWork_CheckedChanged(object sender, EventArgs e)
        {
            InvModeChanged();
            doubleInput_NetWorkLoc_Leave(null, null);
        }
        private void button_SrchCustNo_Click(object sender, EventArgs e)
        {
            Button_Edit_Click(sender, e);
            if (State == FormState.Saved)
            {
                return;
            }
            columns_Names_visible2.Clear();
            columns_Names_visible2.Add("AccDef_No", new ColumnDictinary("الرقم ", " No", ifDefault: true, string.Empty));
            columns_Names_visible2.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, string.Empty));
            columns_Names_visible2.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, string.Empty));
            columns_Names_visible2.Add("AccDef_ID", new ColumnDictinary(" ", " ", ifDefault: false, string.Empty));
            columns_Names_visible2.Add("Mobile", new ColumnDictinary("الجوال", "Mobile", ifDefault: false, string.Empty));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible2;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
            }
            if (CmbInvSide.SelectedIndex <= 1)
            {
                VarGeneral.SFrmTyp = "T_AccDef";
                VarGeneral.AccTyp = 4;
            }
            else if (CmbInvSide.SelectedIndex == 2)
            {
                VarGeneral.SFrmTyp = "T_AccDef2";
                VarGeneral.AccTyp = 4;
            }
            else
            {
                VarGeneral.SFrmTyp = "T_AccDef_Suppliers";
                VarGeneral.AccTyp = 5;
            }
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != string.Empty)
            {
                T_AccDef h = db.StockAccDefs(int.Parse(frm.Serach_No));
                txtCustNo.Text = h.AccDef_No;
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                {
                    txtCustName.Text = h.Arb_Des;
                }
                else
                {
                    txtCustName.Text = h.Eng_Des;
                }
                txtAddress.Text = h.Adders ?? string.Empty;
                txtTele.Text = h.Telphone1 ?? string.Empty;
                try
                {
                    if (h.MaxDisCust.Value > 0.0 && h.vColNum1.Value == 1.0)
                    {
                        txtDiscountP.Value = h.MaxDisCust.Value;
                        txtDiscountP_Leave(sender, e);
                    }
                }
                catch
                {
                }
                if (CmbInvSide.SelectedIndex == 0)
                {
                    try
                    {
                        if (db.StockAccDefs(int.Parse(frm.Serach_No)).Mnd.HasValue)
                        {
                            int? mnd_Typ = db.StockAccDefs(int.Parse(frm.Serach_No)).T_Mndob.Mnd_Typ;
                            if (mnd_Typ.Value == 0 && mnd_Typ.HasValue)
                            {
                                CmbInvSide.SelectedIndex = 0;
                                CmbLegate.SelectedValue = db.StockAccDefs(int.Parse(frm.Serach_No)).Mnd;
                            }
                            else
                            {
                                CmbInvSide.SelectedIndex = 1;
                                CmbLegate.SelectedValue = db.StockAccDefs(int.Parse(frm.Serach_No)).Mnd;
                            }
                        }
                    }
                    catch
                    {
                        CmbLegate.SelectedIndex = 0;
                    }
                }
                try
                {
                    txtCustRep.Value = db.StockAccDefs(int.Parse(frm.Serach_No)).Balance.Value;
                }
                catch
                {
                    txtCustRep.Value = 0.0;
                }
                txtCredit2.Tag = txtCustNo.Text;
                txtCredit2.Text = txtCustName.Text;
                try
                {
                    if (VarGeneral.SSSTyp != 0)
                    {
                        if (_InvSetting.AccCredit2.Trim().Trim() == "***")
                        {
                            txtCredit3.Tag = txtCustNo.Text;
                            txtCredit3.Text = txtCustName.Text;
                        }
                        if (_InvSetting.AccDebit2.Trim().Trim() == "***")
                        {
                            txtDebit3.Tag = txtCustNo.Text;
                            txtDebit3.Text = txtCustName.Text;
                        }
                    }
                }
                catch
                {
                    txtDebit3.Text = string.Empty;
                    txtDebit3.Tag = string.Empty;
                    txtCredit3.Tag = string.Empty;
                    txtCredit3.Text = string.Empty;
                }
                if (checkBox_CostGaidTax.Checked && VarGeneral.SSSTyp != 0)
                {
                    if (checkBox_Chash.Checked)
                    {
                        if (_InvSetting.TaxCredit.Trim() == "***")
                        {
                            txtCredit5.Tag = txtCustNo.Text;
                            txtCredit5.Text = txtCustName.Text;
                        }
                        if (_InvSetting.TaxDebit.Trim() == "***")
                        {
                            txtDebit5.Tag = txtCustNo.Text;
                            txtDebit5.Text = txtCustName.Text;
                        }
                    }
                    else
                    {
                        if (_InvSetting.TaxCreditCredit.Trim() == "***")
                        {
                            txtCredit5.Tag = txtCustNo.Text;
                            txtCredit5.Text = txtCustName.Text;
                        }
                        if (_InvSetting.TaxDebitCredit.Trim() == "***")
                        {
                            txtDebit5.Tag = txtCustNo.Text;
                            txtDebit5.Text = txtCustName.Text;
                        }
                    }
                }
                if (!string.IsNullOrEmpty(txtCustNo.Text))
                {
                    switchButton_PointActiv.Value = VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 69);
                }
            }
            else
            {
                txtCustNo.Text = string.Empty;
                txtCustName.Text = string.Empty;
                txtAddress.Text = string.Empty;
                txtCustRep.Value = 0.0;
                txtDebit2.Text = string.Empty;
                txtDebit2.Tag = string.Empty;
                switchButton_PointActiv.Value = false;
            }
        }
        private void ArbEng()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
            {
                LangArEn = 0;
                FlxInv.Cols[1].Caption = "رمز الصنف";
                FlxInv.Cols[2].Visible = true;
                FlxInv.Cols[3].Visible = true;
                FlxInv.Cols[4].Visible = false;
                FlxInv.Cols[5].Visible = false;
                FlxInv.Cols[6].Caption = "مستودع";
                FlxInv.Cols[7].Caption = "الكمية";
                FlxInv.Cols[8].Caption = "السعر";
                FlxInv.Cols[9].Caption = "خصم نسبة";
                FlxInv.Cols[9].Visible = VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 8);
                FlxInv.Cols[27].Caption = "تاريخ الصلاحية";
                FlxInv.Cols[38].Caption = "الأجمالي";
                FlxInv.Cols[35].Caption = "رقم التصنيع";
                FlxInv.Cols[36].Caption = VarGeneral.Settings_Sys.LineDetailNameA;
                FlxInv.Cols[36].Visible = VarGeneral.TString.ChkStatShow(_SysSetting.LineDetailSts, 2);
                FlxInv.Cols[37].Caption = "السيريال";
                FlxInv.Cols[37].Visible = VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 20);
                FlxInv.Cols[31].Caption = "ضريبة %";
                FlxInv.Cols[33].Caption = VarGeneral.Settings_Sys.LineGiftlNameA;
                FlxInv.Cols[33].Visible = VarGeneral.TString.ChkStatShow(_SysSetting.LineGiftSts, 2);
                FlxStkQty.Cols[0].Caption = "المستودع";
                FlxStkQty.Cols[1].Caption = "الكمية المتاحة";
                FlxStkQty.Cols[2].Caption = "المستودع";
                FlxDat.Cols[0].Caption = "تاريخ الصلاحية";
                FlxDat.Cols[1].Caption = "الكمية";
                FlxDat.Cols[2].Caption = "رقم التصنيع";
                FlxSerial.Cols[0].Caption = "رقم السيريال";
                FlxSerial.Cols[1].Caption = "رقم الصنف";
                FlxSerial.Cols[2].Caption = "رقم التعريف";
                dataGridView_ItemDet.Cols[1].Caption = "رمز الصنف";
                dataGridView_ItemDet.Cols[2].Visible = true;
                dataGridView_ItemDet.Cols[3].Visible = true;
                dataGridView_ItemDet.Cols[4].Visible = false;
                dataGridView_ItemDet.Cols[5].Visible = false;
                dataGridView_ItemDet.Cols[6].Caption = "مستودع";
                dataGridView_ItemDet.Cols[7].Caption = "الكمية";
                dataGridView_ItemDet.Cols[8].Caption = "السعر";
            }
            else
            {
                LangArEn = 1;
                FlxInv.Cols[1].Caption = "Item Code";
                FlxInv.Cols[2].Visible = false;
                FlxInv.Cols[3].Visible = false;
                FlxInv.Cols[4].Visible = true;
                FlxInv.Cols[5].Visible = true;
                FlxInv.Cols[6].Caption = "Store";
                FlxInv.Cols[7].Caption = "Quantity";
                FlxInv.Cols[8].Caption = "Price";
                FlxInv.Cols[9].Caption = "Dis %";
                FlxInv.Cols[9].Visible = VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 8);
                FlxInv.Cols[27].Caption = "Validity Date";
                FlxInv.Cols[38].Caption = "Totel";
                FlxInv.Cols[35].Caption = "Make No";
                FlxInv.Cols[36].Caption = VarGeneral.Settings_Sys.LineDetailNameE;
                FlxInv.Cols[36].Visible = VarGeneral.TString.ChkStatShow(_SysSetting.LineDetailSts, 2);
                FlxInv.Cols[37].Caption = "Serial";
                FlxInv.Cols[37].Visible = VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 20);
                FlxInv.Cols[31].Caption = "Tax %";
                FlxInv.Cols[33].Caption = VarGeneral.Settings_Sys.LineGiftlNameE;
                FlxInv.Cols[33].Visible = VarGeneral.TString.ChkStatShow(_SysSetting.LineGiftSts, 2);
                FlxStkQty.Cols[0].Caption = "Store";
                FlxStkQty.Cols[1].Caption = "Quantity";
                FlxStkQty.Cols[2].Caption = "Store";
                FlxDat.Cols[0].Caption = "Expir Date";
                FlxDat.Cols[1].Caption = "Quantity";
                FlxDat.Cols[2].Caption = "Make No";
                FlxSerial.Cols[0].Caption = "Serial No";
                FlxSerial.Cols[1].Caption = "Item No";
                FlxSerial.Cols[2].Caption = "ID No";
                dataGridView_ItemDet.Cols[1].Caption = "Item Code";
                dataGridView_ItemDet.Cols[2].Visible = false;
                dataGridView_ItemDet.Cols[3].Visible = false;
                dataGridView_ItemDet.Cols[4].Visible = true;
                dataGridView_ItemDet.Cols[5].Visible = true;
                dataGridView_ItemDet.Cols[6].Caption = "Store";
                dataGridView_ItemDet.Cols[7].Caption = "Quantity";
                dataGridView_ItemDet.Cols[8].Caption = "Price";
            }
            try
            {
                if (FlxInv.Cols[9].Visible)
                {
                    FlxInv.Cols[9].Visible = !VarGeneral.TString.ChkStatShow(VarGeneral.UserPassQty, 15);
                }
            }
            catch
            {
            }
            try
            {
                txtDiscountVal.IsInputReadOnly = VarGeneral.TString.ChkStatShow(VarGeneral.UserPassQty, 16);
                txtDiscountP.IsInputReadOnly = VarGeneral.TString.ChkStatShow(VarGeneral.UserPassQty, 16);
            }
            catch
            {
            }
            FlxInv.Cols[27].AllowEditing = false;
            FlxInv.Cols[35].AllowEditing = false;
            if (!VarGeneral.TString.ChkStatShow(_InvSetting.TaxOptions, 0))
            {
                FlxInv.Cols[31].Visible = false;
            }
            RibunButtons();
        }
        private void DGV_MainGetCellStyle(object sender, GridGetCellStyleEventArgs e)
        {
            GridPanel panel = e.GridPanel;
            if (panel.DataMember.Equals("HISale") && e.GridCell.GridColumn.Name.Equals("Date"))
            {
                DateTime dt = default(DateTime);
                dt = Convert.ToDateTime(e.GridCell.Value);
            }
        }
        private void ADD_Controls()
        {
            try
            {
                controls = new List<Control>();
                controls.Add(textBox_ID);
                codeControl = textBox_ID;
                controls.Add(textBox_Type);
                controls.Add(textBox1);
                controls.Add(textBox2);
                controls.Add(txtAddress);
                controls.Add(txtCustName);
                controls.Add(txtCustNet);
                controls.Add(txtCustNo);
                controls.Add(CmbInvSide);
                controls.Add(txtCustRep);
                controls.Add(txtDiscountP);
                controls.Add(txtDiscountVal);
                controls.Add(txtDiscountValLoc);
                controls.Add(txtDiscoundPoints);
                controls.Add(txtDiscoundPointsLoc);
                controls.Add(txtPointCount);
                controls.Add(txtDueAmount);
                controls.Add(txtDueAmountLoc);
                controls.Add(txtGDate);
                controls.Add(txtHDate);
                controls.Add(txtInvCost);
                controls.Add(txtItemName);
                controls.Add(txtLCost);
                controls.Add(txtLPrice);
                controls.Add(txtRef);
                controls.Add(txtDescription);
                controls.Add(txtRemark);
                controls.Add(txtTele);
                controls.Add(txtTime);
                controls.Add(txtTotalAm);
                controls.Add(txtTotalAmLoc);
                controls.Add(txtTotalQ);
                controls.Add(txtUnit);
                controls.Add(txtVCost);
                controls.Add(txtVSerial);
                controls.Add(txtUnit);
                controls.Add(txtLPrice);
                controls.Add(CmbCostC);
                controls.Add(CmbCurr);
                controls.Add(checkBox_Chash);
                controls.Add(checkBox_Credit);
                controls.Add(checkBox_NetWork);
                controls.Add(CmbInvPrice);
                controls.Add(CmbLegate);
                controls.Add(textBox_Usr);
                controls.Add(doubleInput_Rate);
                controls.Add(txtPaymentLoc);
                controls.Add(doubleInput_NetWorkLoc);
                controls.Add(doubleInput_CreditLoc);
                controls.Add(txtDebit1);
                controls.Add(txtDebit2);
                controls.Add(txtDebit3);
                controls.Add(txtCredit1);
                controls.Add(txtCredit2);
                controls.Add(txtCredit3);
                controls.Add(txtDebit1);
                controls.Add(txtDebit2);
                controls.Add(txtDebit3);
                controls.Add(txtCredit1);
                controls.Add(txtCredit2);
                controls.Add(txtCredit3);
                controls.Add(txtTotTax);
                controls.Add(txtTotTaxLoc);
                controls.Add(txtDebit5);
                controls.Add(txtCredit5);
                controls.Add(switchButton_Tax);
                controls.Add(checkBox_CostGaidTax);
                controls.Add(txtTotDis);
                controls.Add(txtTotDisLoc);
                controls.Add(txtDebit6);
                controls.Add(txtCredit6);
                controls.Add(switchButton_Dis);
                controls.Add(checkBox_GaidDis);
                controls.Add(switchButton_PointActiv);
            }
            catch (SqlException)
            {
            }
        }
        private void Button_Delete_Click(object sender, EventArgs e)
        {
            if (!Button_Delete.Enabled || !Button_Delete.Visible || State != 0)
            {
                ifOkDelete = false;
                return;
            }
            string Code = "???";
            if (codeControl != null)
            {
                Code = codeControl.Text;
            }
            if (Code == string.Empty)
            {
                ifOkDelete = false;
                return;
            }
            if (MessageBox.Show("هل أنت متاكد من حذف السجل [" + Code + "]؟ \n Are you sure that you want to delete the record [" + Code + "]?", VarGeneral.ProdectNam, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ifOkDelete = true;
            }
            else
            {
                ifOkDelete = false;
            }
            if (data_this == null || data_this.InvNo == 0.ToString() || !ifOkDelete)
            {
                return;
            }
            if (data_this.IfRet == 1)
            {
                MessageBox.Show((LangArEn == 0) ? "لايمكن حذف الفاتورة .. لانه مرتجع" : "You can not delete your invoice .. because it discards", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                ifOkDelete = false;
                return;
            }
            data_this = db.StockInvHead(VarGeneral.InvTyp, DataThis.InvNo);
            IDatabase db_ = Database.GetDatabase(VarGeneral.BranchCS);
            try
            {
                db_ = Database.GetDatabase(VarGeneral.BranchCS);
                try
                {
                    db.ExecuteCommand("update T_INVHED set DeleteDate = '" + n.FormatGreg(VarGeneral.Gdate, "yyyy/MM/dd") + "',DeleteTime = '" + DateTime.Now.ToString("HH:mm") + "' where InvHed_ID=" + data_this.InvHed_ID);
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("update T_INVHED set DeleteTime = '',IfRet = 0 where IfRet = 1 and InvTyp = 1 and DeleteTime='" + data_this.InvHed_ID + "'");
                }
                catch
                {
                }
                db_.ClearParameters();
                db_.AddParameter("InvHed_ID", DbType.Int32, data_this.InvHed_ID);
                if (CmbInvSide.SelectedIndex > 0)
                {
                    if (CmbInvSide.SelectedIndex == 1)
                    {
                        for (int i = 0; i < data_this.T_INVDETs.Count; i++)
                        {
                            db.ExecuteCommand("  UPDATE T_StoreMnd SET T_StoreMnd.stkQty = T_StoreMnd.stkQty - " + data_this.T_INVDETs[i].RealQty.Value + "\r\n\t\t                                          FROM T_Items INNER JOIN T_StoreMnd ON T_Items.Itm_No = T_StoreMnd.itmNo INNER JOIN T_INVDET ON T_Items.Itm_No = T_INVDET.ItmNo\r\n\t\t                                          where InvDet_ID = " + data_this.T_INVDETs[i].InvDet_ID + " and T_INVDET.ItmTyp <> 3 and T_StoreMnd.storeNo = " + data_this.T_INVDETs[i].StoreNo.Value + " and T_StoreMnd.MndNo = " + data_this.MndNo.Value + " ;");
                        }
                    }
                    else
                    {
                        for (int i = 0; i < data_this.T_INVDETs.Count; i++)
                        {
                            db.ExecuteCommand("  UPDATE T_StoreMnd SET T_StoreMnd.stkQty = T_StoreMnd.stkQty - " + data_this.T_INVDETs[i].RealQty.Value + "\r\n\t\t                                          FROM T_Items INNER JOIN T_StoreMnd ON T_Items.Itm_No = T_StoreMnd.itmNo INNER JOIN T_INVDET ON T_Items.Itm_No = T_INVDET.ItmNo\r\n\t\t                                          where InvDet_ID = " + data_this.T_INVDETs[i].InvDet_ID + " and T_INVDET.ItmTyp <> 3 and T_StoreMnd.storeNo = " + data_this.T_INVDETs[i].StoreNo.Value + " and T_StoreMnd.CusVenNo = '" + data_this.CusVenNo + "' ;");
                        }
                    }
                }
                else
                {
                    try
                    {
                        for (int i = 0; i < data_this.T_INVDETs.Count; i++)
                        {
                            if (data_this.T_INVDETs[i].ItmTyp.Value == 2)
                            {
                                for (int iicnt = 0; iicnt < data_this.T_INVDETs[i].T_SINVDETs.Count; iicnt++)
                                {
                                    db.ExecuteCommand(" UPDATE T_Items SET T_Items.OpenQty = T_Items.OpenQty + " + data_this.T_INVDETs[i].T_SINVDETs[iicnt].SRealQty + " From T_SINVDET Left Join T_QTYEXP ON (T_SINVDET.SItmNo = T_QTYEXP.itmNo) Left Join T_STKSQTY ON (T_SINVDET.SItmNo = T_STKSQTY.itmNo) Left Join T_Items ON (T_SINVDET.SItmNo = T_Items.Itm_No) Left Join T_INVDET ON (T_SINVDET.SInvId = T_INVDET.InvDet_ID) Left Join T_INVHED ON (T_INVDET.InvId = T_INVHED.InvHed_ID) where (InvHed_ID = " + data_this.InvHed_ID + ") and (SInvDet_ID = " + data_this.T_INVDETs[i].T_SINVDETs[iicnt].SInvDet_ID + ")");
                                    db.ExecuteCommand(" UPDATE T_STKSQTY SET T_STKSQTY.stkQty = T_STKSQTY.stkQty + " + data_this.T_INVDETs[i].T_SINVDETs[iicnt].SRealQty + " From T_SINVDET Left Join T_QTYEXP ON (T_SINVDET.SItmNo = T_QTYEXP.itmNo) Left Join T_STKSQTY ON (T_SINVDET.SItmNo = T_STKSQTY.itmNo) Left Join T_Items ON (T_SINVDET.SItmNo = T_Items.Itm_No) Left Join T_INVDET ON (T_SINVDET.SInvId = T_INVDET.InvDet_ID) Left Join T_INVHED ON (T_INVDET.InvId = T_INVHED.InvHed_ID) where (InvHed_ID = " + data_this.InvHed_ID + ") and (SInvDet_ID = " + data_this.T_INVDETs[i].T_SINVDETs[iicnt].SInvDet_ID + ")");
                                    db.ExecuteCommand(" UPDATE T_QTYEXP SET T_QTYEXP.stkQty = T_QTYEXP.stkQty + " + data_this.T_INVDETs[i].T_SINVDETs[iicnt].SRealQty + " From T_SINVDET Left Join T_QTYEXP ON (T_SINVDET.SItmNo = T_QTYEXP.itmNo) Left Join T_STKSQTY ON (T_SINVDET.SItmNo = T_STKSQTY.itmNo) Left Join T_Items ON (T_SINVDET.SItmNo = T_Items.Itm_No) Left Join T_INVDET ON (T_SINVDET.SInvId = T_INVDET.InvDet_ID) Left Join T_INVHED ON (T_INVDET.InvId = T_INVHED.InvHed_ID) where (InvHed_ID = " + data_this.InvHed_ID + ") and (SInvDet_ID = " + data_this.T_INVDETs[i].T_SINVDETs[iicnt].SInvDet_ID + ")");
                                }
                            }
                        }
                    }
                    catch (Exception error)
                    {
                        VarGeneral.DebLog.writeLog("Button_Delete_Click:", error, enable: true);
                        MessageBox.Show(error.Message);
                        return;
                    }
                }
                db_.ExecuteNonQuery(storedProcedure: true, "S_T_INVHED_DELETE");
                db_.StartTransaction();
                db_.ClearParameters();
                db_.AddParameter("gdhead_ID", DbType.Int32, _GdHead.gdhead_ID);
                db_.ExecuteNonQueryWithoutCommit(storedProcedure: true, "S_T_GDHEAD_DELETE");
                db_.EndTransaction();
                db_.StartTransaction();
                db_.ClearParameters();
                db_.AddParameter("gdhead_ID", DbType.Int32, _GdHeadCostTax.gdhead_ID);
                db_.ExecuteNonQueryWithoutCommit(storedProcedure: true, "S_T_GDHEAD_DELETE");
                db_.EndTransaction();
                db_.StartTransaction();
                db_.ClearParameters();
                db_.AddParameter("gdhead_ID", DbType.Int32, _GdHeadCostDis.gdhead_ID);
                db_.ExecuteNonQueryWithoutCommit(storedProcedure: true, "S_T_GDHEAD_DELETE");
                db_.EndTransaction();
            }
            catch (SqlException)
            {
                data_this = db.StockInvHead(VarGeneral.InvTyp, DataThis.InvNo);
                return;
            }
            catch (Exception)
            {
                data_this = db.StockInvHead(VarGeneral.InvTyp, DataThis.InvNo);
                return;
            }
            Clear();
            RefreshPKeys();
            textBox_ID.Text = PKeys.LastOrDefault();
        }
        private void Button_Add_Click(object sender, EventArgs e)
        {
            // ChkPriceIncludeTax.Enabled = true;
            if (!Button_Add.Visible || !Button_Add.Enabled)
            {
                MessageBox.Show((LangArEn == 0) ? "لا يمكن اتمام هذه العملية .. الرجاء مراجعة صلاحيات المستخدمين !" : "Can not complete this process .. please see the powers of the users!", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                if (State == FormState.Edit && MessageBox.Show((LangArEn == 0) ? "تم تعديل السجل الحالي دون حفظ التغييرات .. هل تريد المتابعة؟" : "Not saved the changes, do you really want to continue?", VarGeneral.ProdectNam, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
                {
                    return;
                }
                button_Draft.Enabled = true;
                ChkPriceIncludeTax.Value = VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 83);
                Clear();
                ChkPriceIncludeTax_ValueChanged(null, null);
                GetInvSetting();
                textBox_ID.Text = db.MaxInvheadNo.ToString();
                FlxInv.Rows.Count = VarGeneral.Settings_Sys.LineOfInvoices.Value;
                State = FormState.New;
                if (VarGeneral._IsPOS)
                {
                    AutoGaidAcc_POS();
                }
                else
                {
                    AutoGaidAcc();
                }
                try
                {
                    base.ActiveControl = FlxInv;
                    FlxInv.Row = 1;
                    FlxInv.Col = 1;
                }
                catch
                {
                }
                txtGDate.Text = n.FormatGreg(VarGeneral.Gdate, "yyyy/MM/dd");
                txtHDate.Text = n.FormatHijri(VarGeneral.Hdate, "yyyy/MM/dd");
                txtTime.Text = DateTime.Now.ToString("HH:mm");
                if (VarGeneral.SSSTyp != 0)
                {
                    if (_InvSetting.autoTaxGaid.Value)
                    {
                        checkBox_CostGaidTax.Checked = true;
                    }
                    if (_InvSetting.autoDisGaid.Value)
                    {
                        checkBox_GaidDis.Checked = true;
                    }
                }
            }
            superTabControl_Info.SelectedTabIndex = 3;
            FlxInv.Focus();
        }
        private void AutoGaidAcc()
        {
            if (_InvSetting.InvSetting.Substring(1, 1) == "1" && VarGeneral.SSSTyp != 0)
            {
                txtCredit2.Tag = ((_InvSetting.AccCredit1.Trim() != "***") ? _InvSetting.AccCredit1.Trim() : string.Empty);
                if (!string.IsNullOrEmpty(txtCredit2.Tag.ToString()))
                {
                    if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                    {
                        txtCredit2.Text = db.SelectAccRootByCode(txtCredit2.Tag.ToString()).Arb_Des;
                    }
                    else
                    {
                        txtCredit2.Text = db.SelectAccRootByCode(txtCredit2.Tag.ToString()).Eng_Des;
                    }
                }
                else
                {
                    txtCredit2.Text = string.Empty;
                }
                txtDebit2.Tag = ((_InvSetting.AccDebit1.Trim() != "***") ? _InvSetting.AccDebit1.Trim() : string.Empty);
                if (!string.IsNullOrEmpty(txtDebit2.Tag.ToString()))
                {
                    if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                    {
                        txtDebit2.Text = db.SelectAccRootByCode(txtDebit2.Tag.ToString()).Arb_Des;
                    }
                    else
                    {
                        txtDebit2.Text = db.SelectAccRootByCode(txtDebit2.Tag.ToString()).Eng_Des;
                    }
                }
                else
                {
                    txtDebit2.Text = string.Empty;
                }
                txtCredit3.Tag = ((_InvSetting.AccCredit2.Trim() != "***") ? _InvSetting.AccCredit2.Trim() : string.Empty);
                if (!string.IsNullOrEmpty(txtCredit3.Tag.ToString()))
                {
                    if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                    {
                        txtCredit3.Text = db.SelectAccRootByCode(txtCredit3.Tag.ToString()).Arb_Des;
                    }
                    else
                    {
                        txtCredit3.Text = db.SelectAccRootByCode(txtCredit3.Tag.ToString()).Eng_Des;
                    }
                }
                else
                {
                    txtCredit3.Text = string.Empty;
                }
                txtDebit3.Tag = ((_InvSetting.AccDebit2.Trim() != "***") ? _InvSetting.AccDebit2.Trim() : string.Empty);
                if (!string.IsNullOrEmpty(txtDebit3.Tag.ToString()))
                {
                    if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                    {
                        txtDebit3.Text = db.SelectAccRootByCode(txtDebit3.Tag.ToString()).Arb_Des;
                    }
                    else
                    {
                        txtDebit3.Text = db.SelectAccRootByCode(txtDebit3.Tag.ToString()).Eng_Des;
                    }
                }
                else
                {
                    txtDebit3.Text = string.Empty;
                }
                txtCredit1.Tag = ((_InvSetting.AccCredit0.Trim() != "***") ? _InvSetting.AccCredit0.Trim() : string.Empty);
                if (!string.IsNullOrEmpty(txtCredit1.Tag.ToString()))
                {
                    if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                    {
                        txtCredit1.Text = db.SelectAccRootByCode(txtCredit1.Tag.ToString()).Arb_Des;
                    }
                    else
                    {
                        txtCredit1.Text = db.SelectAccRootByCode(txtCredit1.Tag.ToString()).Eng_Des;
                    }
                }
                else
                {
                    txtCredit1.Text = string.Empty;
                }
                txtDebit1.Tag = ((_InvSetting.AccDebit0.Trim() != "***") ? _InvSetting.AccDebit0.Trim() : string.Empty);
                if (!string.IsNullOrEmpty(txtDebit1.Tag.ToString()))
                {
                    if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                    {
                        txtDebit1.Text = db.SelectAccRootByCode(txtDebit1.Tag.ToString()).Arb_Des;
                    }
                    else
                    {
                        txtDebit1.Text = db.SelectAccRootByCode(txtDebit1.Tag.ToString()).Eng_Des;
                    }
                }
                else
                {
                    txtDebit1.Text = string.Empty;
                }
            }
            else
            {
                if (VarGeneral.SSSTyp != 0)
                {
                    return;
                }
                txtCredit2.Tag = ((_InvSetting.AccCredit4.Trim() != "***") ? _InvSetting.AccCredit4.Trim() : string.Empty);
                if (!string.IsNullOrEmpty(txtCredit2.Tag.ToString()))
                {
                    if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                    {
                        txtCredit2.Text = db.SelectAccRootByCode(txtCredit2.Tag.ToString()).Arb_Des;
                    }
                    else
                    {
                        txtCredit2.Text = db.SelectAccRootByCode(txtCredit2.Tag.ToString()).Eng_Des;
                    }
                }
                else
                {
                    txtCredit2.Text = string.Empty;
                }
                txtDebit2.Tag = ((_InvSetting.AccDebit4.Trim() != "***") ? _InvSetting.AccDebit4.Trim() : string.Empty);
                if (!string.IsNullOrEmpty(txtDebit2.Tag.ToString()))
                {
                    if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                    {
                        txtDebit2.Text = db.SelectAccRootByCode(txtDebit2.Tag.ToString()).Arb_Des;
                    }
                    else
                    {
                        txtDebit2.Text = db.SelectAccRootByCode(txtDebit2.Tag.ToString()).Eng_Des;
                    }
                }
                else
                {
                    txtDebit2.Text = string.Empty;
                }
                txtCredit3.Tag = ((_InvSetting.AccCredit4.Trim() != "***") ? _InvSetting.AccCredit4.Trim() : string.Empty);
                if (!string.IsNullOrEmpty(txtCredit3.Tag.ToString()))
                {
                    if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                    {
                        txtCredit3.Text = db.SelectAccRootByCode(txtCredit3.Tag.ToString()).Arb_Des;
                    }
                    else
                    {
                        txtCredit3.Text = db.SelectAccRootByCode(txtCredit3.Tag.ToString()).Eng_Des;
                    }
                }
                else
                {
                    txtCredit3.Text = string.Empty;
                }
                txtDebit3.Tag = ((_InvSetting.AccDebit4.Trim() != "***") ? _InvSetting.AccDebit4.Trim() : string.Empty);
                if (!string.IsNullOrEmpty(txtDebit3.Tag.ToString()))
                {
                    if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                    {
                        txtDebit3.Text = db.SelectAccRootByCode(txtDebit3.Tag.ToString()).Arb_Des;
                    }
                    else
                    {
                        txtDebit3.Text = db.SelectAccRootByCode(txtDebit3.Tag.ToString()).Eng_Des;
                    }
                }
                else
                {
                    txtDebit3.Text = string.Empty;
                }
                txtCredit1.Tag = ((_InvSetting.AccCredit3.Trim() != "***") ? _InvSetting.AccCredit3.Trim() : string.Empty);
                if (!string.IsNullOrEmpty(txtCredit1.Tag.ToString()))
                {
                    if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                    {
                        txtCredit1.Text = db.SelectAccRootByCode(txtCredit1.Tag.ToString()).Arb_Des;
                    }
                    else
                    {
                        txtCredit1.Text = db.SelectAccRootByCode(txtCredit1.Tag.ToString()).Eng_Des;
                    }
                }
                else
                {
                    txtCredit1.Text = string.Empty;
                }
                txtDebit1.Tag = ((_InvSetting.AccDebit3.Trim() != "***") ? _InvSetting.AccDebit3.Trim() : string.Empty);
                if (!string.IsNullOrEmpty(txtDebit1.Tag.ToString()))
                {
                    if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                    {
                        txtDebit1.Text = db.SelectAccRootByCode(txtDebit1.Tag.ToString()).Arb_Des;
                    }
                    else
                    {
                        txtDebit1.Text = db.SelectAccRootByCode(txtDebit1.Tag.ToString()).Eng_Des;
                    }
                }
                else
                {
                    txtDebit1.Text = string.Empty;
                }
            }
        }
        private void AutoGaidAcc_POS()
        {
            if (dbc.Get_PermissionID(VarGeneral.UserID).CreateGaid == 1 && VarGeneral.SSSTyp != 0)
            {
                T_User vUsr = dbc.Get_PermissionID(VarGeneral.UserID);
                if (string.IsNullOrEmpty(txtCredit2.Text))
                {
                    txtCredit2.Tag = ((vUsr.CreaditAccNo_C_R.Trim() != "***") ? vUsr.CreaditAccNo_C_R.Trim() : string.Empty);
                    if (!string.IsNullOrEmpty(txtCredit2.Tag.ToString()))
                    {
                        if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                        {
                            txtCredit2.Text = db.SelectAccRootByCode(txtCredit2.Tag.ToString()).Arb_Des;
                        }
                        else
                        {
                            txtCredit2.Text = db.SelectAccRootByCode(txtCredit2.Tag.ToString()).Eng_Des;
                        }
                    }
                    else
                    {
                        txtCredit2.Text = string.Empty;
                    }
                }
                if (string.IsNullOrEmpty(txtDebit2.Text))
                {
                    txtDebit2.Tag = ((vUsr.CreaditAccNo_D_R.Trim() != "***") ? vUsr.CreaditAccNo_D_R.Trim() : string.Empty);
                    if (!string.IsNullOrEmpty(txtDebit2.Tag.ToString()))
                    {
                        if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                        {
                            txtDebit2.Text = db.SelectAccRootByCode(txtDebit2.Tag.ToString()).Arb_Des;
                        }
                        else
                        {
                            txtDebit2.Text = db.SelectAccRootByCode(txtDebit2.Tag.ToString()).Eng_Des;
                        }
                    }
                    else
                    {
                        txtDebit2.Text = string.Empty;
                    }
                }
                if (string.IsNullOrEmpty(txtCredit3.Text))
                {
                    txtCredit3.Tag = ((vUsr.NetworkAccNo_C_R.Trim() != "***") ? vUsr.NetworkAccNo_C_R.Trim() : string.Empty);
                    if (!string.IsNullOrEmpty(txtCredit3.Tag.ToString()))
                    {
                        if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                        {
                            txtCredit3.Text = db.SelectAccRootByCode(txtCredit3.Tag.ToString()).Arb_Des;
                        }
                        else
                        {
                            txtCredit3.Text = db.SelectAccRootByCode(txtCredit3.Tag.ToString()).Eng_Des;
                        }
                    }
                    else
                    {
                        txtCredit3.Text = string.Empty;
                    }
                }
                if (string.IsNullOrEmpty(txtDebit3.Text))
                {
                    txtDebit3.Tag = ((vUsr.NetworkAccNo_D_R.Trim() != "***") ? vUsr.NetworkAccNo_D_R.Trim() : string.Empty);
                    if (!string.IsNullOrEmpty(txtDebit3.Tag.ToString()))
                    {
                        if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                        {
                            txtDebit3.Text = db.SelectAccRootByCode(txtDebit3.Tag.ToString()).Arb_Des;
                        }
                        else
                        {
                            txtDebit3.Text = db.SelectAccRootByCode(txtDebit3.Tag.ToString()).Eng_Des;
                        }
                    }
                    else
                    {
                        txtDebit3.Text = string.Empty;
                    }
                }
                if (string.IsNullOrEmpty(txtCredit1.Text))
                {
                    txtCredit1.Tag = ((vUsr.CashAccNo_C_R.Trim() != "***") ? vUsr.CashAccNo_C_R.Trim() : string.Empty);
                    if (!string.IsNullOrEmpty(txtCredit1.Tag.ToString()))
                    {
                        if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                        {
                            txtCredit1.Text = db.SelectAccRootByCode(txtCredit1.Tag.ToString()).Arb_Des;
                        }
                        else
                        {
                            txtCredit1.Text = db.SelectAccRootByCode(txtCredit1.Tag.ToString()).Eng_Des;
                        }
                    }
                    else
                    {
                        txtCredit1.Text = string.Empty;
                    }
                }
                if (!string.IsNullOrEmpty(txtDebit1.Text))
                {
                    return;
                }
                txtDebit1.Tag = ((vUsr.CashAccNo_D_R.Trim() != "***") ? vUsr.CashAccNo_D_R.Trim() : string.Empty);
                if (!string.IsNullOrEmpty(txtDebit1.Tag.ToString()))
                {
                    if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                    {
                        txtDebit1.Text = db.SelectAccRootByCode(txtDebit1.Tag.ToString()).Arb_Des;
                    }
                    else
                    {
                        txtDebit1.Text = db.SelectAccRootByCode(txtDebit1.Tag.ToString()).Eng_Des;
                    }
                }
                else
                {
                    txtDebit1.Text = string.Empty;
                }
            }
            else
            {
                if (VarGeneral.SSSTyp != 0)
                {
                    return;
                }
                if (string.IsNullOrEmpty(txtCredit2.Text))
                {
                    txtCredit2.Tag = ((_InvSetting.AccCredit4.Trim() != "***") ? _InvSetting.AccCredit4.Trim() : string.Empty);
                    if (!string.IsNullOrEmpty(txtCredit2.Tag.ToString()))
                    {
                        if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                        {
                            txtCredit2.Text = db.SelectAccRootByCode(txtCredit2.Tag.ToString()).Arb_Des;
                        }
                        else
                        {
                            txtCredit2.Text = db.SelectAccRootByCode(txtCredit2.Tag.ToString()).Eng_Des;
                        }
                    }
                    else
                    {
                        txtCredit2.Text = string.Empty;
                    }
                }
                if (string.IsNullOrEmpty(txtDebit2.Text))
                {
                    txtDebit2.Tag = ((_InvSetting.AccDebit4.Trim() != "***") ? _InvSetting.AccDebit4.Trim() : string.Empty);
                    if (!string.IsNullOrEmpty(txtDebit2.Tag.ToString()))
                    {
                        if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                        {
                            txtDebit2.Text = db.SelectAccRootByCode(txtDebit2.Tag.ToString()).Arb_Des;
                        }
                        else
                        {
                            txtDebit2.Text = db.SelectAccRootByCode(txtDebit2.Tag.ToString()).Eng_Des;
                        }
                    }
                    else
                    {
                        txtDebit2.Text = string.Empty;
                    }
                }
                if (string.IsNullOrEmpty(txtCredit3.Text))
                {
                    txtCredit3.Tag = ((_InvSetting.AccCredit4.Trim() != "***") ? _InvSetting.AccCredit4.Trim() : string.Empty);
                    if (!string.IsNullOrEmpty(txtCredit3.Tag.ToString()))
                    {
                        if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                        {
                            txtCredit3.Text = db.SelectAccRootByCode(txtCredit3.Tag.ToString()).Arb_Des;
                        }
                        else
                        {
                            txtCredit3.Text = db.SelectAccRootByCode(txtCredit3.Tag.ToString()).Eng_Des;
                        }
                    }
                    else
                    {
                        txtCredit3.Text = string.Empty;
                    }
                }
                if (string.IsNullOrEmpty(txtDebit3.Text))
                {
                    txtDebit3.Tag = ((_InvSetting.AccDebit4.Trim() != "***") ? _InvSetting.AccDebit4.Trim() : string.Empty);
                    if (!string.IsNullOrEmpty(txtDebit3.Tag.ToString()))
                    {
                        if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                        {
                            txtDebit3.Text = db.SelectAccRootByCode(txtDebit3.Tag.ToString()).Arb_Des;
                        }
                        else
                        {
                            txtDebit3.Text = db.SelectAccRootByCode(txtDebit3.Tag.ToString()).Eng_Des;
                        }
                    }
                    else
                    {
                        txtDebit3.Text = string.Empty;
                    }
                }
                if (string.IsNullOrEmpty(txtCredit1.Text))
                {
                    txtCredit1.Tag = ((_InvSetting.AccCredit3.Trim() != "***") ? _InvSetting.AccCredit3.Trim() : string.Empty);
                    if (!string.IsNullOrEmpty(txtCredit1.Tag.ToString()))
                    {
                        if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                        {
                            txtCredit1.Text = db.SelectAccRootByCode(txtCredit1.Tag.ToString()).Arb_Des;
                        }
                        else
                        {
                            txtCredit1.Text = db.SelectAccRootByCode(txtCredit1.Tag.ToString()).Eng_Des;
                        }
                    }
                    else
                    {
                        txtCredit1.Text = string.Empty;
                    }
                }
                if (!string.IsNullOrEmpty(txtDebit1.Text))
                {
                    return;
                }
                txtDebit1.Tag = ((_InvSetting.AccDebit3.Trim() != "***") ? _InvSetting.AccDebit3.Trim() : string.Empty);
                if (!string.IsNullOrEmpty(txtDebit1.Tag.ToString()))
                {
                    if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                    {
                        txtDebit1.Text = db.SelectAccRootByCode(txtDebit1.Tag.ToString()).Arb_Des;
                    }
                    else
                    {
                        txtDebit1.Text = db.SelectAccRootByCode(txtDebit1.Tag.ToString()).Eng_Des;
                    }
                }
                else
                {
                    txtDebit1.Text = string.Empty;
                }
            }
        }
        public void RefreshPKeys()
        {
            PKeys.Clear();
            try
            {
                PKeys = db.ExecuteQuery<string>("select InvNo from T_INVHED where InvTyp =" + VarGeneral.InvTyp + " and IfDel = 0 ", new object[0]).ToList();
            }
            catch
            {
                PKeys.Clear();
            }
            int count = 0;
            count = PKeys.Count;
            Label_Count.Text = string.Concat(count);
            UpdateVcr();
        }
        public void Fill_DGV_Main()
        {
            DGV_Main.PrimaryGrid.VirtualMode = true;
            Stock_DataDataContext db = new Stock_DataDataContext(VarGeneral.BranchCS);
            List<T_INVHED> list = db.FillInvHead_2(VarGeneral.InvTyp, textBox_search.TextBox.Text).ToList();
            DGV_Main.PrimaryGrid.VirtualRowCount = list.Count;
            if (DGV_Main.PrimaryGrid.Columns.Count == 0)
            {
                foreach (KeyValuePair<string, ColumnDictinary> item in columns_Names_visible)
                {
                    DGV_Main.PrimaryGrid.Columns.Add(new GridColumn(item.Key));
                }
            }
            FillHDGV(list);
        }
        protected override void OnParentRightToLeftChanged(EventArgs e)
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmInvSalesReturn));
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
            ArbEng();
            FillCombo();
            try
            {
                if (data_this != null)
                {
                    SetData(data_this);
                }
            }
            catch
            {
            }
        }
        private void RibunButtons()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
            {
                Button_First.Text = "الأول";
                Button_Last.Text = "الأخير";
                Button_Next.Text = "التالي";
                Button_Prev.Text = "السابق";
                Button_Add.Text = "جديد";
                Button_Close.Text = "اغلاق";
                Button_Delete.Text = "حذف";
                Button_Save.Text = "حفظ";
                Button_Search.Text = "بحث";
                Button_First.Tooltip = "السجل الاول";
                Button_Last.Tooltip = "السجل الاخير";
                Button_Next.Tooltip = "السجل التالي";
                Button_Prev.Tooltip = "السجل السابق";
                Button_Add.Tooltip = "F1";
                Button_Close.Tooltip = "Esc";
                Button_Delete.Tooltip = "F3";
                Button_Save.Tooltip = "F2";
                Button_Search.Tooltip = "F4";
                Button_PrintTable.Text = "عــرض";
                Button_PrintTable.Tooltip = "F5";
                Button_PrintTableMulti.Text = "طباعة الفواتير المحددة";
                buttonItem_Print.Text = ((_InvSetting.InvpRINTERInfo.nTyp.Substring(2, 1) == "1") ? "طباعة" : "عــرض");
                buttonItem_Print.Tooltip = "F5";
                Button_ExportTable2.Text = "تصدير";
                Button_ExportTable2.Tooltip = "F10";
                DGV_Main.PrimaryGrid.GroupByRow.Text = "جميع السجلات";
                Label1.Text = "رقم الفاتورة :";
                Label2.Text = "التاريــــــــخ :";
                label7.Text = "رقم المرجع :";
                label19.Text = "العملــــــــة :";
                label18.Text = "المنـــــدوب :";
                label4.Text = "حساب العميــل :";
                label10.Text = "اسم العميـــــل :";
                label13.Text = "عنوان العميل :";
                label15.Text = "مركز التكلفـــــة :";
                label5.Text = "السعر المعتمــد :";
                label12.Text = "هاتف :";
                label24.Text = "متوسط التكلفة";
                label32.Text = "السيريال";
                label23.Text = "آخر تكلفة";
                label25.Text = "الوحدة";
                label8.Text = "نسبة الخصم";
                Label26.Text = "قيمة الخصم";
                label17.Text = "قيمة الفاتـــورة :";
                label9.Text = "صافي الفاتورة :";
                label27.Text = "سعر الصرف";
                superTabItem_items.Text = "م.الصنف";
                superTabItem_Pay.Text = "الدفع";
                superTabItem_Note.Text = "ملاحظات";
                superTabItem_Detiles.Text = "تفاصيل";
                txtRemark.WatermarkText = "ملاحظات الفاتورة";
                label6.Text = "نقــدا\u064c :";
                label11.Text = "آجــل :";
                label14.Text = "شبكة :";
                label30.Text = "إجمالي الكمية :";
                label27.Text = "المستخدم :";
                ButReturn.Text = "إرجاع فاتورة";
                ButReturn.Tooltip = "إرجاع فاتورة مبيعات كاملة";
                button_GoodsDisbursedInv.Text = "فواتير صرف مبيعات";
                checkBox_Chash.Text = "نقـــدي";
                checkBox_Credit.Text = "أجـــل";
                labelD1.Text = "المـــدين :";
                labelD2.Text = "المـــدين :";
                labelD3.Text = "المـــدين :";
                labelC1.Text = "الدائـــن :";
                labelC2.Text = "الدائـــن :";
                labelC3.Text = "الدائـــن :";
                button_CustD1.Tooltip = "حساب العميل";
                button_CustD2.Tooltip = "حساب العميل";
                button_CustD3.Tooltip = "حساب العميل";
                button_CustC1.Tooltip = "حساب العميل";
                button_CustC2.Tooltip = "حساب العميل";
                button_CustC3.Tooltip = "حساب العميل";
                switchButton_Lock.OffText = "لم يتم الموافقة";
                switchButton_Lock.OnText = "تمت الموافقة";
                switchButton_PointActiv.OffText = "النقاط";
                switchButton_PointActiv.OnText = "النقاط";
                button_Repetition.Text = "تكرار";
                switchButton_Tax.OffText = "غير معتمد";
                switchButton_Tax.OnText = "معتمد";
                superTabItem_Tax.Text = "ضرائب";
                superTabItem_Dis.Text = "الخصـــــم";
                superTabItem_Gaids.Text = "سندات";
                switchButton_Dis.OffText = "+ السطــور";
                switchButton_Dis.OnText = "+ السطــور";
                switchButton_TaxLines.OnText = "سطور الضريبة";
                switchButton_TaxLines.OffText = "سطور الضريبة";
                switchButton_TaxByTotal.OnText = "إجمالي السطر";
                switchButton_TaxByTotal.OffText = "إجمالي السطر";
                switchButton_TaxByNet.OffText = "الصـافي";
                switchButton_TaxByNet.OffText = "الصـافي";
                button_SrchInvNoBarcod.Text = "بحث";
            }
            else
            {
                Button_First.Text = "First";
                Button_Last.Text = "Last";
                Button_Next.Text = "Next";
                Button_Prev.Text = "Previous";
                Button_Add.Text = "New";
                Button_Close.Text = "Close";
                Button_Delete.Text = "Del";
                Button_Save.Text = "Save";
                Button_Search.Text = "Srch";
                Button_First.Tooltip = "First Record";
                Button_Last.Tooltip = "Last Record";
                Button_Next.Tooltip = "Next Record";
                Button_Prev.Tooltip = "Previous Record";
                Button_Add.Tooltip = "F1";
                Button_Close.Tooltip = "Esc";
                Button_Delete.Tooltip = "F3";
                Button_Save.Tooltip = "F2";
                Button_Search.Tooltip = "F4";
                Button_PrintTable.Text = "Show";
                Button_PrintTable.Tooltip = "F5";
                Button_PrintTableMulti.Text = "Print of the invoices selected";
                buttonItem_Print.Text = ((_InvSetting.InvpRINTERInfo.nTyp.Substring(2, 1) == "1") ? "Print" : "Show");
                buttonItem_Print.Tooltip = "F5";
                Button_ExportTable2.Text = "Export";
                Button_ExportTable2.Tooltip = "F10";
                DGV_Main.PrimaryGrid.GroupByRow.Text = "All Records";
                Label1.Text = "Invoice No :";
                Label2.Text = "Date :";
                label7.Text = "Reference No :";
                label19.Text = "Currncy :";
                label18.Text = "Delegate :";
                label4.Text = "Customer Account :";
                label10.Text = "Customer Name :";
                label13.Text = "Customer Address :";
                label15.Text = "Cost Center :";
                label5.Text = "Price Now : ";
                label12.Text = "Tel :";
                label24.Text = "Average Cost";
                label32.Text = "Serial No";
                label23.Text = "Last Cost :";
                label25.Text = "Unit";
                label8.Text = "Discount %";
                Label26.Text = "Dis value";
                label17.Text = "Invoice value :";
                label9.Text = "Invoice Net :";
                label27.Text = "Exchange";
                superTabItem_items.Text = "Item Info";
                superTabItem_Pay.Text = "Paid";
                superTabItem_Note.Text = "Notes";
                superTabItem_Detiles.Text = "Details";
                txtRemark.WatermarkText = "Notes";
                label6.Text = "Cash :";
                label11.Text = "Credit :";
                label14.Text = "NetWork :";
                label30.Text = "Total Quantity :";
                label27.Text = "User :";
                ButReturn.Text = "Re Inv";
                ButReturn.Tooltip = "Returns Sales Invoice";
                button_GoodsDisbursedInv.Text = "Sales exchange invoices";
                checkBox_Chash.Text = "Cach";
                checkBox_Credit.Text = "Credit";
                labelD1.Text = "Debtor :";
                labelD2.Text = "Debtor :";
                labelD3.Text = "Debtor :";
                labelC1.Text = "Creditor :";
                labelC2.Text = "Creditor :";
                labelC3.Text = "Creditor :";
                button_CustD1.Tooltip = "Customer Accounting";
                button_CustD2.Tooltip = "Customer Accounting";
                button_CustD3.Tooltip = "Customer Accounting";
                button_CustC1.Tooltip = "Customer Accounting";
                button_CustC2.Tooltip = "Customer Accounting";
                button_CustC3.Tooltip = "Customer Accounting";
                switchButton_Lock.OffText = "not approved";
                switchButton_Lock.OnText = "Been approved";
                switchButton_PointActiv.OffText = "Points";
                switchButton_PointActiv.OnText = "Points";
                button_Repetition.Text = "Repetition";
                switchButton_Tax.OffText = "certified";
                switchButton_Tax.OnText = "un certified";
                switchButton_Dis.OffText = "+ Lines";
                switchButton_Dis.OnText = "+ Lines";
                superTabItem_Tax.Text = "Taxes";
                superTabItem_Dis.Text = "Discount";
                superTabItem_Gaids.Text = "Bonds";
                switchButton_TaxLines.OnText = "Tax Lines";
                switchButton_TaxLines.OffText = "Tax Lines";
                switchButton_TaxByTotal.OnText = "Total Line";
                switchButton_TaxByTotal.OffText = "Total Line";
                switchButton_TaxByNet.OffText = "Inv Net";
                switchButton_TaxByNet.OffText = "Inv Net";
                button_SrchInvNoBarcod.Text = "Find";
            }
        }
        private void Script_School()
        {
            label4.Text = ((LangArEn == 0) ? "حساب الطالب :" : "Student Account :");
            label10.Text = ((LangArEn == 0) ? "إسم الطالب :" : "Student Name :");
            label13.Text = ((LangArEn == 0) ? "عنوان الطالب :" : "Student Adress :");
        }
        private async void FrmInvSales_Load(object sender, EventArgs e)
        {
            try
            {
                Location = Frm_Main.loc;
                if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 85))
            {
                switchButton_Lock.Visible = false;
            }
                button_Draft.Enabled = false;
                ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmInvSalesReturn));
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
                ADD_Controls();
                checkoversaved();
                if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 85))
            {
                switchButton_Lock.Visible = false;
            }
                Permmission = dbc.Get_PermissionID(VarGeneral.UserID);
                _StorePr = permission.StorePrmission.Split(',').ToList();
                if (columns_Names_visible.Count == 0)
                {
                    columns_Names_visible.Add("InvNo", new ColumnDictinary("رقم الفاتورة", "Invoice No", ifDefault: true, string.Empty));
                    columns_Names_visible.Add("CusVenNm", new ColumnDictinary("إسم العميل", "Customer Name", ifDefault: true, string.Empty));
                    columns_Names_visible.Add("SalsManNo", new ColumnDictinary("رقم البائع", "SalsMan No", ifDefault: false, string.Empty));
                    columns_Names_visible.Add("HDat", new ColumnDictinary("التاريخ الهجري", "Date Hijri", ifDefault: true, string.Empty));
                    columns_Names_visible.Add("GDat", new ColumnDictinary("التاريخ الميلادي", "Date Gregorian", ifDefault: true, string.Empty));
                    columns_Names_visible.Add("InvTotLocCur", new ColumnDictinary("إجمالي الفاتورة", "Invoice Total", ifDefault: false, string.Empty));
                    columns_Names_visible.Add("InvNetLocCur", new ColumnDictinary("صافي الفاتورة", "Invoice Net", ifDefault: true, string.Empty));
                    columns_Names_visible.Add("InvQty", new ColumnDictinary("إجمالي الكمية", "Quantity Total", ifDefault: true, string.Empty));
                    columns_Names_visible.Add("RefNo", new ColumnDictinary("رقم المرجع", "Refrence No", ifDefault: false, string.Empty));
                    columns_Names_visible.Add("InvDisValLocCur", new ColumnDictinary("الخصم قيمة", "Discount value", ifDefault: true, string.Empty));
                    columns_Names_visible.Add("GadeNo", new ColumnDictinary("رقم القيد المحاسبي", "Gaid No", ifDefault: false, string.Empty));
                    columns_Names_visible.Add("CusVenMob", new ColumnDictinary("الجوال", "Mobile", ifDefault: true, string.Empty));
                }
                else
                {
                    Clear();
                    textBox_ID.Text = string.Empty;
                    TextBox_Index.TextBox.Text = string.Empty;
                }
                FillCombo();
                GetInvSetting();
                ArbEng();
                RefreshPKeys();
                textBox_ID.Text = PKeys.FirstOrDefault();
                listUnit = new List<T_Unit>();
                listStore = new List<T_Store>();
                listUnit = db.FillUnit_2(string.Empty).ToList();
                listStore = db.FillStore_2(string.Empty).ToList();
                FlxStkQty.Rows.Count = listStore.Count + 1;
                string Co = string.Empty;
                for (int iiCnt = 0; iiCnt < listStore.Count; iiCnt++)
                {
                    _Store = listStore[iiCnt];
                    FlxStkQty.SetData(iiCnt + 1, 0, _Store.Stor_ID.ToString());
                    FlxStkQty.SetData(iiCnt + 1, 2, ((LangArEn == 0) ? _Store.Arb_Des : _Store.Eng_Des).ToString());
                    Co = ((!(Co != string.Empty)) ? _Store.Stor_ID.ToString() : (Co + "|" + _Store.Stor_ID));
                }
                FlxInv.Cols[6].ComboList = Co;
                int? calendr = _SysSetting.Calendr;
                if (calendr.Value == 0 && calendr.HasValue)
                {
                    txtGDate.BringToFront();
                }
                else
                {
                    txtHDate.BringToFront();
                }
                if (VarGeneral.vDemo && VarGeneral.UserID != 1)
                {
                    IfDelete = false;
                }
                if (_InvSetting.InvSetting.Substring(1, 1) == "0")
                {
                    txtDebit1.ButtonCustom.Enabled = false;
                    txtDebit2.ButtonCustom.Enabled = false;
                    txtDebit3.ButtonCustom.Enabled = false;
                    txtCredit1.ButtonCustom.Enabled = false;
                    txtCredit2.ButtonCustom.Enabled = false;
                    txtCredit3.ButtonCustom.Enabled = false;
                    button_CustD1.Enabled = false;
                    button_CustD2.Enabled = false;
                    button_CustD3.Enabled = false;
                    button_CustC1.Enabled = false;
                    button_CustC2.Enabled = false;
                    button_CustC3.Enabled = false;
                }
                if (VarGeneral.SSSTyp == 0)
                {
                    if (VarGeneral.SSSLev == "M")
                    {
                        label4.Visible = false;
                        txtCustNo.Visible = false;
                        button_SrchCustNo.Visible = false;
                        txtDebit1.Visible = false;
                        txtDebit2.Visible = false;
                        txtDebit3.Visible = false;
                        txtCredit1.Visible = false;
                        txtCredit2.Visible = false;
                        txtCredit3.Visible = false;
                        button_CustD1.Visible = false;
                        button_CustD2.Visible = false;
                        button_CustD3.Visible = false;
                        button_CustC1.Visible = false;
                        button_CustC2.Visible = false;
                        button_CustC3.Visible = false;
                        labelD1.Visible = false;
                        labelD2.Visible = false;
                        labelD3.Visible = false;
                        labelC1.Visible = false;
                        labelC2.Visible = false;
                        labelC3.Visible = false;
                    }
                    txtDebit1.Enabled = false;
                    txtDebit2.Enabled = false;
                    txtDebit3.Enabled = false;
                    txtCredit1.Enabled = false;
                    txtCredit2.Enabled = false;
                    txtCredit3.Enabled = false;
                    button_CustD1.Enabled = false;
                    button_CustD2.Enabled = false;
                    button_CustD3.Enabled = false;
                    button_CustC1.Enabled = false;
                    button_CustC2.Enabled = false;
                    button_CustC3.Enabled = false;
                    txtDebit5.Visible = false;
                    button_CustD5.Visible = false;
                    txtCredit5.Visible = false;
                    button_CustC5.Visible = false;
                    checkBox_CostGaidTax.Visible = false;
                    label35.Visible = false;
                    label34.Visible = false;
                    txtDebit6.Visible = false;
                    label31.Visible = false;
                    txtCredit6.Visible = false;
                    label37.Visible = false;
                    checkBox_GaidDis.Visible = false;
                    label35.Visible = false;
                    label34.Visible = false;
                }
                label24.Visible = false;
                label23.Visible = false;
                label22.Visible = false;
                label25.Visible = false;
                label32.Visible = false;
                txtVCost.Visible = false;
                txtUnit.Visible = false;
                txtLCost.Visible = false;
                txtLPrice.Visible = false;
                txtVSerial.Visible = false;
                if (!VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 67))
                {
                    txtRemark.ButtonCustom2.Visible = false;
                }
                try
                {
                    textBox_ID.ReadOnly = true;
                    if (!VarGeneral.TString.ChkStatShow(permission.SetStr, 43))
                    {
                        textBox_ID.Enabled = false;
                    }
                }
                catch
                {
                }
                UpdateVcr();
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Load:", error, enable: true);
                MessageBox.Show(error.Message);
            }
            try
            {
                txtDebit1.ButtonCustom.Visible = VarGeneral.TString.ChkStatShow(permission.SetStr, 49);
                txtDebit2.ButtonCustom.Visible = VarGeneral.TString.ChkStatShow(permission.SetStr, 49);
                txtDebit3.ButtonCustom.Visible = VarGeneral.TString.ChkStatShow(permission.SetStr, 49);
                txtCredit1.ButtonCustom.Visible = VarGeneral.TString.ChkStatShow(permission.SetStr, 49);
                txtCredit2.ButtonCustom.Visible = VarGeneral.TString.ChkStatShow(permission.SetStr, 49);
                txtCredit3.ButtonCustom.Visible = VarGeneral.TString.ChkStatShow(permission.SetStr, 49);
                button_CustD1.Visible = VarGeneral.TString.ChkStatShow(permission.SetStr, 49);
                button_CustD2.Visible = VarGeneral.TString.ChkStatShow(permission.SetStr, 49);
                button_CustD3.Visible = VarGeneral.TString.ChkStatShow(permission.SetStr, 49);
                button_CustC1.Visible = VarGeneral.TString.ChkStatShow(permission.SetStr, 49);
                button_CustC2.Visible = VarGeneral.TString.ChkStatShow(permission.SetStr, 49);
                button_CustC3.Visible = VarGeneral.TString.ChkStatShow(permission.SetStr, 49);
            }
            catch
            {
            }
            try
            {
                FlxInv.Cols[8].Format = VarGeneral.DicimalNN;
                FlxInv.Cols[9].Format = VarGeneral.DicimalNN;
                FlxInv.Cols[10].Format = VarGeneral.DicimalNN;
                FlxInv.Cols[11].Format = VarGeneral.DicimalNN;
                FlxInv.Cols[12].Format = VarGeneral.DicimalNN;
                FlxInv.Cols[38].Format = VarGeneral.DicimalNN;
                FlxInv.Cols[31].Format = VarGeneral.DicimalNN;
                FlxInvToCopy.Cols[8].Format = VarGeneral.DicimalNN;
                FlxInvToCopy.Cols[9].Format = VarGeneral.DicimalNN;
                FlxInvToCopy.Cols[10].Format = VarGeneral.DicimalNN;
                FlxInvToCopy.Cols[11].Format = VarGeneral.DicimalNN;
                FlxInvToCopy.Cols[12].Format = VarGeneral.DicimalNN;
                FlxInvToCopy.Cols[38].Format = VarGeneral.DicimalNN;
                FlxInvToCopy.Cols[31].Format = VarGeneral.DicimalNN;
                dataGridView_ItemDet.Cols[8].Format = VarGeneral.DicimalNN;
                dataGridView_ItemDet.Cols[9].Format = VarGeneral.DicimalNN;
                dataGridView_ItemDet.Cols[10].Format = VarGeneral.DicimalNN;
                dataGridView_ItemDet.Cols[11].Format = VarGeneral.DicimalNN;
                dataGridView_ItemDet.Cols[12].Format = VarGeneral.DicimalNN;
                dataGridView_ItemDet.Cols[38].Format = VarGeneral.DicimalNN;
            }
            catch
            {
            }

            try
            {
                if (_InvSetting.InvpRINTERInfo.nTyp.Substring(1, 1) == "1")
                {
                    ChkA4Cahir.Text = "Csh";
                }
                else
                {
                    ChkA4Cahir.Text = "A4";
                }
                if (VarGeneral.TString.ChkStatShow(Permmission.PeaperTyp, 1))
                {
                    ChkA4Cahir.Checked = true;
                }
            }
            catch
            {
            }
            if (File.Exists(Application.StartupPath + "\\Script\\SecriptCustBarcode.dll"))
            {
                txtCustNo.ReadOnly = false;
            }
            else
            {
                txtCustNo.ReadOnly = true;
            }
            FlxInv.DrawMode = DrawModeEnum.OwnerDraw;
            FlxInv.OwnerDrawCell += _ownerDraw;
            if (File.Exists(Application.StartupPath + "\\Script\\SecriptSchool.dll"))
            {
                Script_School();
            }
            if (File.Exists(Application.StartupPath + "\\Script\\SecriptMaintenanceCars.dll"))
            {
                MaintenanceCars();
            }
            if (File.Exists(Application.StartupPath + "\\Script\\SecriptBus.dll"))
            {
                label15.Text = ((LangArEn == 0) ? "الباص : " : "Bus :");
                label18.Text = ((LangArEn == 0) ? "السائق :" : "Driver :");
            }
            if (File.Exists(Application.StartupPath + "\\Script\\SecriptWaterPackages.dll"))
            {
                label4.Text = ((LangArEn == 0) ? "حساب الســائق :" : "Driver Acc :");
                label10.Text = ((LangArEn == 0) ? "اسم الســــائق :" : "Driver Name :");
                label13.Text = ((LangArEn == 0) ? "عنوان السائق :" : "Driver Add :");
                label15.Text = ((LangArEn == 0) ? "السيارة : " : "Car :");
                label18.Text = ((LangArEn == 0) ? "العميــــل :" : "Customer :");
                CmbInvSide.Visible = false;
                switchButton_PointActiv.Visible = false;
                button_SrchCustPoints.Visible = false;
                txtDiscoundPointsLoc.Visible = false;
                txtDiscoundPoints.Visible = false;
                label40.Visible = false;
            }
            if (File.Exists(Application.StartupPath + "\\Script\\Secriptjustlight.dll") || (VarGeneral.gUserName == "runsetting" && File.Exists(Application.StartupPath + "\\Script\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\Secriptjustlight.dll")))
            {
                CmbInvSide.Visible = false;
            }
        }
        private void MaintenanceCars()
        {
            label4.Text = ((LangArEn == 0) ? "حساب السيارة :" : "Car Account :");
            label10.Text = ((LangArEn == 0) ? "إسم السيارة :" : "Car Name :");
            label13.Text = ((LangArEn == 0) ? "رقم الشاص :" : "Chase No :");
            label18.Text = ((LangArEn == 0) ? "نوع السيارة :" : "Car Type :");
            label12.Visible = false;
            txtTele.Visible = false;
            CmbInvSide.Visible = false;
            FlxInv.Cols[7].Visible = false;
        }
        private void _ownerDraw(object sender, OwnerDrawCellEventArgs e)
        {
            if (e.Col == 0 && e.Row > 0)
            {
                e.Text = e.Row.ToString();
            }
        }
        private void Button_ExportTable2_Click(object sender, EventArgs e)
        {
            try
            {
                ExportExcel.ExportToExcel(DGV_Main, "تقرير فواتير مرتجع مبيعات");
            }
            catch
            {
            }
        }
        private void TextBox_Search_ButtonCustomClick(object sender, EventArgs e)
        {
            textBox_search.Text = string.Empty;
        }
        private void DGV_Main_AfterCheck(object sender, GridAfterCheckEventArgs e)
        {
            DGV_Main.PrimaryGrid.VirtualMode = false;
            GridRow crow = e.Item as GridRow;
            if (crow != null && crow.Checked)
            {
                GridPanel panel = new GridPanel();
                var q = db.StockInvHead(VarGeneral.InvTyp, crow.Cells["InvNo"].Value.ToString()).T_INVDETs.Select((T_INVDET item) => new
                {
                    item.ItmNo,
                    item.ItmDes,
                    item.ItmDesE,
                    item.ItmUnt,
                    item.ItmUntE,
                    item.StoreNo,
                    item.Cost,
                    item.Qty,
                    item.Price,
                    item.ItmDis,
                    item.Amount
                });
                panel.DataSource = q.ToList();
                panel.DataMember = "Line";
                crow.Rows.Add(panel);
                crow.SuperGrid.DataBindingComplete += DGV_Main_DataBindingComplete;
                panel.EnsureVisible(center: true);
            }
            else
            {
                crow?.Rows.Clear();
            }
        }
        private void PropHIOfferPanel(GridPanel panel)
        {
            DGV_Main.PrimaryGrid.UseAlternateRowStyle = true;
            DGV_Main.PrimaryGrid.DefaultVisualStyles.AlternateRowCellStyles.Default.Background.Color1 = Color.SkyBlue;
            panel.FrozenColumnCount = 1;
            panel.Columns[0].GroupBoxEffects = GroupBoxEffects.None;
            foreach (GridColumn column in panel.Columns)
            {
                column.ColumnSortMode = ColumnSortMode.Multiple;
            }
            panel.ColumnHeader.RowHeight = 30;
            for (int i = 0; i < panel.Columns.Count; i++)
            {
                DGV_Main.PrimaryGrid.Columns[i].CellStyles.Default.Alignment = Alignment.MiddleCenter;
                DGV_Main.PrimaryGrid.Columns[i].Visible = false;
            }
            panel.Columns["InvNo"].Width = 150;
            panel.Columns["InvNo"].Visible = columns_Names_visible["InvNo"].IfDefault;
            panel.Columns["CusVenNm"].Width = 250;
            panel.Columns["CusVenNm"].Visible = columns_Names_visible["CusVenNm"].IfDefault;
            panel.Columns["SalsManNo"].Width = 100;
            panel.Columns["SalsManNo"].Visible = columns_Names_visible["SalsManNo"].IfDefault;
            panel.Columns["HDat"].Width = 100;
            panel.Columns["HDat"].Visible = columns_Names_visible["HDat"].IfDefault;
            panel.Columns["GDat"].Width = 100;
            panel.Columns["GDat"].Visible = columns_Names_visible["GDat"].IfDefault;
            panel.Columns["InvTotLocCur"].Width = 150;
            panel.Columns["InvTotLocCur"].Visible = columns_Names_visible["InvTotLocCur"].IfDefault;
            panel.Columns["InvNetLocCur"].Width = 150;
            panel.Columns["InvNetLocCur"].Visible = columns_Names_visible["InvNetLocCur"].IfDefault;
            panel.Columns["InvQty"].Width = 150;
            panel.Columns["InvQty"].Visible = columns_Names_visible["InvQty"].IfDefault;
            panel.Columns["RefNo"].Width = 100;
            panel.Columns["RefNo"].Visible = columns_Names_visible["RefNo"].IfDefault;
            panel.Columns["InvDisValLocCur"].Width = 100;
            panel.Columns["InvDisValLocCur"].Visible = columns_Names_visible["InvDisValLocCur"].IfDefault;
            panel.Columns["GadeNo"].Width = 130;
            panel.Columns["GadeNo"].Visible = columns_Names_visible["GadeNo"].IfDefault;
            panel.Columns["CusVenAdd"].Width = 400;
            panel.Columns["CusVenAdd"].Visible = columns_Names_visible["CusVenAdd"].IfDefault;
        }
        private void PropLOfferPanel(GridPanel panel)
        {
            panel.ColumnAutoSizeMode = ColumnAutoSizeMode.DisplayedCells;
            panel.Columns["ItmNo"].HeaderText = ((LangArEn == 0) ? "رقم الصنف" : "Item No");
            panel.Columns["ItmDes"].HeaderText = ((LangArEn == 0) ? "الوصف " : "Description");
            panel.Columns["ItmDesE"].HeaderText = ((LangArEn == 0) ? "الوصف" : "Description");
            panel.Columns["ItmUnt"].HeaderText = ((LangArEn == 0) ? "الوحدة" : "Unit");
            panel.Columns["ItmUntE"].HeaderText = ((LangArEn == 0) ? "الوحدة" : "Unit");
            panel.Columns["StoreNo"].HeaderText = ((LangArEn == 0) ? "المستودع" : "Store");
            panel.Columns["Qty"].HeaderText = ((LangArEn == 0) ? "الكمية" : "Qrt.");
            panel.Columns["Cost"].HeaderText = ((LangArEn == 0) ? "التكلفة" : "Cost");
            panel.Columns["Price"].HeaderText = ((LangArEn == 0) ? "السعر" : "Price");
            panel.Columns["ItmDis"].HeaderText = ((LangArEn == 0) ? "الخصم" : "Discount");
            panel.Columns["Amount"].HeaderText = ((LangArEn == 0) ? "الاجمالي" : "Total");
            panel.Footer.Text = ((LangArEn == 0) ? "عدد الأسطر: " : "Lines Count: ") + panel.Rows.Count;
            panel.ReadOnly = true;
            panel.ShowRowDirtyMarker = true;
            panel.ColumnHeader.RowHeight = 30;
            for (int i = 0; i < panel.Columns.Count; i++)
            {
                panel.Columns[i].AutoSizeMode = ColumnAutoSizeMode.AllCells;
            }
            panel.Columns[1].Width = 160;
            panel.Columns[2].Width = 300;
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
            {
                panel.Columns["ItmDesE"].Visible = false;
                panel.Columns["ItmUntE"].Visible = false;
                panel.Columns["ItmDes"].Visible = true;
                panel.Columns["ItmUnt"].Visible = true;
            }
            else
            {
                panel.Columns["ItmDes"].Visible = false;
                panel.Columns["ItmUnt"].Visible = false;
                panel.Columns["ItmDesE"].Visible = true;
                panel.Columns["ItmUntE"].Visible = true;
            }
            panel.DefaultVisualStyles.CaptionStyles.Default.Alignment = Alignment.MiddleCenter;
            panel.DefaultVisualStyles.CellStyles.Default.Alignment = Alignment.MiddleCenter;
            panel.GroupByRow.Visible = false;
            panel.AllowEdit = false;
            panel.CheckBoxes = false;
            panel.ShowCheckBox = false;
            panel.ShowRowGridIndex = true;
        }
        private void DateTimePicker_Search_From_ValueChanged(object sender, EventArgs e)
        {
            Fill_DGV_Main();
        }
        private void TextBox_Search_InputTextChanged(object sender)
        {
            Fill_DGV_Main();
        }
        private void Button_Save_Click(object sender, EventArgs e)
        {
            try
            {
                textBox_ID.Focus();
                if (SaveData())
                {
                    State = FormState.Saved;
                    RefreshPKeys();
                    TextBox_Index.TextBox.Text = string.Concat(PKeys.IndexOf(data_this.InvNo ?? string.Empty) + 1);
                    dbInstance = null;
                    textBox_ID_TextChanged(sender, e);
                    SetReadOnly = true;
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Button_Save_Click:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        public void TextBox_Index_InputTextChanged(object sender)
        {
            int index = 0;
            try
            {
                index = Convert.ToInt32(TextBox_Index.TextBox.Text);
            }
            catch
            {
            }
            if (index <= PKeys.Count && index > 0)
            {
                textBox_ID.Text = PKeys[index - 1];
            }
        }
        private void GetInvSetting()
        {
            _InvSetting = new T_INVSETTING();
            _SysSetting = new T_SYSSETTING();
            _GdAuto = new T_GdAuto();
            _InvSetting = db.StockInvSetting(VarGeneral.UserID, VarGeneral.InvTyp);
            _SysSetting = db.SystemSettingStock();
            _GdAuto = db.GdAutoStock();
        }
        private void textBox_ID_TextChanged(object sender, EventArgs e)
        {
            string no = string.Empty;
            try
            {
                no = textBox_ID.Text;
            }
            catch
            {
            }
            try
            {
                if (!_StopMove)
                {
                    return;
                }
                T_INVHED newData = db.StockInvHead(VarGeneral.InvTyp, no);
                FlxInv.Rows.Count = 1;
                if (newData == null || string.IsNullOrEmpty(newData.InvNo))
                {
                    if (!Button_Add.Visible || !Button_Add.Enabled)
                    {
                        MessageBox.Show((LangArEn == 0) ? "لا يمكن اتمام هذه العملية .. الرجاء مراجعة صلاحيات المستخدمين !" : "Can not complete this process .. please see the powers of the users!", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        textBox_ID.TextChanged -= textBox_ID_TextChanged;
                        try
                        {
                            textBox_ID.Text = data_this.InvNo;
                        }
                        catch
                        {
                        }
                        textBox_ID.TextChanged += textBox_ID_TextChanged;
                        return;
                    }
                    Clear();
                    txtGDate.Text = n.FormatGreg(VarGeneral.Gdate, "yyyy/MM/dd");
                    txtHDate.Text = n.FormatHijri(VarGeneral.Hdate, "yyyy/MM/dd");
                    txtTime.Text = DateTime.Now.ToString("HH:mm");
                    FlxInv.Rows.Count = VarGeneral.Settings_Sys.LineOfInvoices.Value;
                    State = FormState.New;
                    if (VarGeneral._IsPOS)
                    {
                        AutoGaidAcc_POS();
                    }
                    else
                    {
                        AutoGaidAcc();
                    }
                    TextBox_Index.InputTextChanged -= TextBox_Index_InputTextChanged;
                    TextBox_Index.TextBox.Text = string.Concat(PKeys.Count + 1);
                    TextBox_Index.InputTextChanged += TextBox_Index_InputTextChanged;
                }
                else
                {
                    DataThis = newData;
                    int indexA = PKeys.IndexOf(newData.InvNo ?? string.Empty);
                    indexA++;
                    TextBox_Index.InputTextChanged -= TextBox_Index_InputTextChanged;
                    TextBox_Index.TextBox.Text = string.Concat(indexA);
                    TextBox_Index.InputTextChanged += TextBox_Index_InputTextChanged;
                }
                Permmission = dbc.Get_PermissionID(VarGeneral.UserID);
            }
            catch
            {
            }
            FlxDat.Visible = false;
            FlxSerial.Visible = false;
            UpdateVcr();
            if (State == FormState.Saved && CmbInvSide.SelectedIndex <= 0)
            {
                button_Repetition.Enabled = true;
            }
            else
            {
                button_Repetition.Enabled = false;
            }
            if (State == FormState.Saved)
            {
                Button_PrintTableMulti.Enabled = true;
            }
            else
            {
                Button_PrintTableMulti.Enabled = false;
            }
        }
        private void Button_Filter_Click(object sender, EventArgs e)
        {
            Fill_DGV_Main();
        }
        private void DGV_Main_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                GridElement item = DGV_Main.GetElementAt(e.Location);
                if (item is GridColumnHeader)
                {
                    GridColumnHeader gch = (GridColumnHeader)item;
                    GridColumn column = null;
                    HeaderArea area = gch.GetHitArea(e.Location, ref column);
                    contextMenuStrip1.Show(Control.MousePosition);
                }
                else
                {
                    contextMenuStrip2.Show(Control.MousePosition);
                }
            }
        }
        private void ToolStripMenuItem_Det_Click(object sender, EventArgs e)
        {
            int rowIndex = Convert.ToInt32(DGV_Main.PrimaryGrid.Tag);
            TextBox_Index.TextBox.Text = string.Concat(rowIndex + 1);
            expandableSplitter1.Expanded = true;
            ViewDetails_Click(sender, e);
        }
        private void DGV_Main_CellMouseDown(object sender, GridCellMouseEventArgs e)
        {
            DGV_Main.PrimaryGrid.Tag = e.GridCell.RowIndex;
        }
        private void DGV_Main_CellDoubleClick(object sender, GridCellDoubleClickEventArgs e)
        {
            ToolStripMenuItem_Det_Click(sender, e);
        }
        private void DGV_Main_CellClick(object sender, GridCellClickEventArgs e)
        {
            DGV_Main.PrimaryGrid.Tag = e.GridCell.RowIndex;
        }
        private void txtHDate_Leave(object sender, EventArgs e)
        {
            try
            {
                if (VarGeneral.CheckDate(txtHDate.Text))
                {
                    txtHDate.Text = Convert.ToDateTime(txtHDate.Text).ToString("yyyy/MM/dd");
                    txtHDate.Text = n.FormatHijri(txtHDate.Text, "yyyy/MM/dd");
                    if (!VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 77))
                    {
                        txtGDate.Text = n.HijriToGreg(txtHDate.Text, "yyyy/MM/dd");
                    }
                }
                else
                {
                    txtHDate.Text = n.FormatHijri(VarGeneral.Hdate, "yyyy/MM/dd");
                }
            }
            catch
            {
                txtHDate.Text = string.Empty;
            }
        }
        private void txtGDate_Leave(object sender, EventArgs e)
        {
            try
            {
                if (VarGeneral.CheckDate(txtGDate.Text))
                {
                    txtGDate.Text = Convert.ToDateTime(txtGDate.Text).ToString("yyyy/MM/dd");
                    txtGDate.Text = n.FormatGreg(txtGDate.Text, "yyyy/MM/dd");
                    if (!VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 77))
                    {
                        txtHDate.Text = n.GregToHijri(txtGDate.Text, "yyyy/MM/dd");
                    }
                }
                else
                {
                    txtGDate.Text = n.FormatGreg(VarGeneral.Gdate, "yyyy/MM/dd");
                }
            }
            catch
            {
                txtGDate.Text = string.Empty;
            }
        }
        private void txtTime_Click(object sender, EventArgs e)
        {
            txtTime.SelectAll();
        }
        private void txtGDate_Click(object sender, EventArgs e)
        {
            txtGDate.SelectAll();
        }
        private void GetInvTot()
        {
            double InvTot = 0.0;
            double InvCost = 0.0;
            double InvQty = 0.0;
            double InvDis = 0.0;
            double InvTax = 0.0;
            double ItmDisCount = 0.0;
            if (State == FormState.Saved)
            {
                return;
            }
            InvDis = double.Parse(VarGeneral.TString.TEmpty(txtDiscountVal.Text));
            try
            {
                InvDis += txtDiscoundPoints.Value;
            }
            catch
            {
            }
            for (int iiCnt = 1; iiCnt < FlxInv.Rows.Count; iiCnt++)
            {
                try
                {
                    InvTot += double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 38))));
                    InvCost += double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 10)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 12))));
                    InvQty += double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 7))));
                    if (switchButton_TaxByTotal.Value)
                    {
                        double DisVal = 0.0;
                        try
                        {
                            DisVal = double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 8)))) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 9)))) / 100.0);
                        }
                        catch
                        {
                        }
                        InvTax += (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 8)))) - DisVal) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 31)))) / 100.0);
                    }
                    else
                    {
                        InvTax += double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 8)))) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 31)))) / 100.0);
                    }
                    ItmDisCount += double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 8)))) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 9)))) / 100.0);
                    try
                    {
                        if ((File.Exists(Application.StartupPath + "\\Script\\SecriptColDisSalesReturn.dll") || (VarGeneral.gUserName == "runsetting" && File.Exists(Application.StartupPath + "\\Script\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\SecriptColDisSalesReturn.dll"))) && double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 36)))) > 0.0)
                        {
                            ItmDisCount += double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 8)))) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 36)))) / 100.0);
                        }
                    }
                    catch
                    {
                    }
                    try
                    {
                        if (File.Exists(Application.StartupPath + "\\Script\\SecriptColDisSalesReturnValue.dll") || (VarGeneral.gUserName == "runsetting" && File.Exists(Application.StartupPath + "\\Script\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\SecriptColDisSalesReturnValue.dll")))
                        {
                            ItmDisCount += double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 36))));
                        }
                    }
                    catch
                    {
                    }
                }
                catch
                {
                }
            }
            txtTotalAm.Text = VarGeneral.TString.TEmpty(Math.Round(InvTot * RateValue, VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? 3 : 2).ToString());
            txtDueAmount.Text = VarGeneral.TString.TEmpty(Math.Round((InvTot - InvDis) * RateValue, VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? 3 : 2).ToString());
            txtTotalQ.Text = VarGeneral.TString.TEmpty(InvQty.ToString());
            txtInvCost.Text = VarGeneral.TString.TEmpty(Math.Round(InvCost, VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? 3 : 2).ToString());
            txtCustNet.Text = VarGeneral.TString.TEmpty(Math.Round(double.Parse(VarGeneral.TString.TEmpty(string.Concat(txtCustRep.Value))) + double.Parse(txtDueAmountLoc.Text), VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? 3 : 2).ToString());
            txtTotalAmLoc.Text = VarGeneral.TString.TEmpty(Math.Round(InvTot, VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? 3 : 2).ToString());
            txtDueAmountLoc.Text = VarGeneral.TString.TEmpty(Math.Round(InvTot - InvDis, VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? 3 : 2).ToString());
            double Tax_Per = 0.0;
            try
            {
                Tax_Per = double.Parse(textBoxItem_TaxByNetValue.Text);
            }
            catch
            {
                Tax_Per = 0.0;
            }
            if (switchButton_TaxByNet.Value)
            {
                InvTax = ((!(Tax_Per <= 0.0) && !(txtDueAmountLoc.Value <= 0.0)) ? Math.Round(txtDueAmountLoc.Value * Tax_Per / 100.0, VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? 3 : 2) : 0.0);
            }
            txtTotTax.Text = VarGeneral.TString.TEmpty(Math.Round(InvTax, VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? 3 : 2).ToString());
            txtTotTaxLoc.Text = VarGeneral.TString.TEmpty(Math.Round(InvTax * RateValue, VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? 3 : 2).ToString());
            if (switchButton_TaxLines.Value)
            {
                if (!switchButton_Tax.Value)
                {
                    txtDueAmount.Text = VarGeneral.TString.TEmpty(Math.Round((InvTot - InvTax - InvDis) * RateValue, VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? 3 : 2).ToString());
                }
                if (!switchButton_Tax.Value)
                {
                    txtDueAmountLoc.Text = VarGeneral.TString.TEmpty(Math.Round(InvTot - InvTax - InvDis, VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? 3 : 2).ToString());
                }
                if (switchButton_TaxByNet.Value && InvTax > 0.0)
                {
                    if (switchButton_Tax.Value)
                    {
                        txtDueAmount.Text = VarGeneral.TString.TEmpty(Math.Round((InvTot + InvTax - InvDis) * RateValue, VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? 3 : 2).ToString());
                    }
                    if (switchButton_Tax.Value)
                    {
                        txtDueAmountLoc.Text = VarGeneral.TString.TEmpty(Math.Round(InvTot + InvTax - InvDis, VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? 3 : 2).ToString());
                    }
                }
            }
            else
            {
                if (switchButton_Tax.Value)
                {
                    txtDueAmount.Text = VarGeneral.TString.TEmpty(Math.Round((InvTot + InvTax - InvDis) * RateValue, VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? 3 : 2).ToString());
                }
                if (switchButton_Tax.Value)
                {
                    txtDueAmountLoc.Text = VarGeneral.TString.TEmpty(Math.Round(InvTot + InvTax - InvDis, VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? 3 : 2).ToString());
                }
            }
            txtTotDis.Value = (switchButton_Dis.Value ? (txtDiscountVal.Value + ItmDisCount) : txtDiscountVal.Value);
            txtTotDisLoc.Value = (switchButton_Dis.Value ? (txtDiscountValLoc.Value + ItmDisCount) : txtDiscountValLoc.Value);
            txtTotDis.Value += txtDiscoundPoints.Value;
            txtTotDisLoc.Value += txtDiscoundPointsLoc.Value;
            try
            {
                if (switchButton_Dis.Value && ItmDisCount > 0.0)
                {
                    txtTotalAm.Value += Math.Round(ItmDisCount * RateValue, VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? 3 : 2);
                    txtTotalAmLoc.Value += Math.Round(ItmDisCount, VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? 3 : 2);
                }
            }
            catch
            {
            }
            if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 56))
            {
                txtTotalAm.Value = Math.Round(txtTotalAm.Value, 0);
                txtDueAmount.Value = Math.Round(txtDueAmount.Value, 0);
                txtTotalAmLoc.Value = Math.Round(txtTotalAmLoc.Value, 0);
                txtDueAmountLoc.Value = Math.Round(txtDueAmountLoc.Value, 0);
            }
            try
            {
                if (checkBox_CostGaidTax.Checked && txtPaymentLoc.Value + doubleInput_NetWorkLoc.Value + doubleInput_CreditLoc.Value != txtDueAmountLoc.Value - txtTotTax.Value)
                {
                    txtDueAmountLoc_ValueChanged(null, null);
                }
            }
            catch
            {
            }
        }
        private void CmbCurr_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (CmbCurr.SelectedIndex == -1)
                {
                    return;
                }
                _Curency = db.StockCurencyID(int.Parse(CmbCurr.SelectedValue.ToString()));
                try
                {
                    if (CmbCurr.SelectedValue.ToString() == VarGeneral.Settings_Sys.ImportIp.ToString())
                    {
                        RateValue = 1.0;
                        doubleInput_Rate.Value = 1.0;
                    }
                    else
                    {
                        RateValue = _Curency.Rate.Value;
                        try
                        {
                            doubleInput_Rate.Value = _Curency.Rate.Value;
                        }
                        catch
                        {
                        }
                    }
                }
                catch
                {
                    RateValue = _Curency.Rate.Value;
                    try
                    {
                        doubleInput_Rate.Value = _Curency.Rate.Value;
                    }
                    catch
                    {
                    }
                }
                try
                {
                    GetInvTot();
                    txtDiscountVal_Leave(sender, e);
                }
                catch
                {
                }
            }
            catch
            {
            }
        }
        private void txtDiscountP_Leave(object sender, EventArgs e)
        {
            if (State != 0)
            {
                txtDiscountVal.Value = txtTotalAmLoc.Value * (txtDiscountP.Value / 100.0);
                txtDiscountValLoc.Value = txtDiscountVal.Value * RateValue;
                GetInvTot();
            }
        }
        private void txtDiscountVal_Leave(object sender, EventArgs e)
        {
            if (State == FormState.Saved)
            {
                return;
            }
            try
            {
                if (txtTotalAm.Value > 0.0)
                {
                    txtDiscountP.Value = Math.Round(txtDiscountVal.Value / txtTotalAmLoc.Value * 100.0, VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2);
                }
            }
            catch
            {
            }
            txtDiscountValLoc.Value = txtDiscountVal.Value * RateValue;
            GetInvTot();
        }
        private void Frm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                SendKeys.Send("{Tab}");
            }
        }
        int kk = 0;
        private void Frm_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter && FlxInv.ColSel == 1) || (e.KeyCode == Keys.Enter && kk == 1))
            {
                {
                    SendKeys.Send("{Tab}");
                }
            }
            if (e.KeyCode == Keys.F1 && Button_Add.Enabled && Button_Add.Visible)
            {
                Button_Add_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F2 && Button_Save.Enabled && Button_Save.Visible && State != 0)
            {
                Button_Save_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F3 && Button_Delete.Enabled && Button_Delete.Visible && State == FormState.Saved)
            {
                Button_Delete_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F4 && Button_Search.Enabled && Button_Search.Visible)
            {
                Button_Search_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F10 && Button_ExportTable2.Enabled && Button_ExportTable2.Visible && !expandableSplitter1.Expanded)
            {
                Button_ExportTable2_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F5)
            {
                if (expandableSplitter1.Expanded && buttonItem_Print.Enabled && buttonItem_Print.Visible && State == FormState.Saved)
                {
                    buttonItem_Print_Click(sender, e);
                }
                else if (Button_PrintTable.Enabled && Button_PrintTable.Visible && !expandableSplitter1.Expanded)
                {
                    Button_Print_Click(sender, e);
                }
            }
            else if (e.KeyCode == Keys.F9)
            {
                try
                {
                    PrintDocument prnt_doc = new PrintDocument();
                    T_INVSETTING _InvSetting = new T_INVSETTING();
                    _InvSetting = db.StockInvSetting(VarGeneral.UserID, VarGeneral.InvTyp);
                    string _PrinterName = prnt_doc.PrinterSettings.PrinterName;
                    try
                    {
                        prnt_doc.PrinterSettings.PrinterName = _InvSetting.InvpRINTERInfo.defPrn;
                        if (prnt_doc.PrinterSettings.IsValid)
                        {
                            _PrinterName = _InvSetting.defPrn;
                        }
                    }
                    catch
                    {
                    }
                    CashDrawer.OpenDrawer(_PrinterName);
                }
                catch (Exception error)
                {
                    try
                    {
                        VarGeneral.DebLog.writeLog("button_openCasheir_Click:", error, enable: true);
                    }
                    catch
                    {
                    }
                }
            }
            else if (e.KeyCode == Keys.Escape)
            {
                if (State == FormState.Saved)
                {
                    Close();
                    return;
                }
                if (State != FormState.New)
                {
                    textBox_ID_TextChanged(sender, e);
                    return;
                }
                try
                {
                    if (int.Parse(Label_Count.Text) > 0)
                    {
                        Button_Last_Click(sender, e);
                    }
                    else
                    {
                        Close();
                    }
                }
                catch
                {
                    Close();
                }
            }
            else if (VarGeneral.TString.ChkStatShow(VarGeneral.UserPassQty, 6))
            {
                if (e.KeyCode == Keys.ControlKey)
                {
                    label24.Visible = true;
                    label23.Visible = true;
                    label22.Visible = true;
                    label25.Visible = true;
                    txtVCost.Visible = true;
                    txtUnit.Visible = true;
                    txtLCost.Visible = true;
                    txtLPrice.Visible = true;
                    dataGridView_ItemDet.Visible = false;
                }
                else if (e.KeyCode == Keys.Alt)
                {
                    label24.Visible = true;
                    label23.Visible = true;
                    label22.Visible = true;
                    label25.Visible = true;
                    txtVCost.Visible = true;
                    txtUnit.Visible = true;
                    txtLCost.Visible = true;
                    txtLPrice.Visible = true;
                    dataGridView_ItemDet.Visible = false;
                }
            }
        }
        private bool ChkBarCod(string BarCod)
        {
            DefPack = 0;
            T_Item _ItmBarCod = new T_Item();
            listItems = db.FillItemBarCode_2(BarCod).ToList();
            for (int iiCnt = 0; iiCnt < listItems.Count; iiCnt++)
            {
                _ItmBarCod = listItems[iiCnt];
                try
                {
                    if (_ItmBarCod.InvSaleReturnStoped.Value)
                    {
                        return false;
                    }
                }
                catch
                {
                }
                if (BarCod == _ItmBarCod.BarCod1)
                {
                    _Items = _ItmBarCod;
                    DefPack = 1;
                    return true;
                }
                if (BarCod == _ItmBarCod.BarCod2)
                {
                    _Items = _ItmBarCod;
                    DefPack = 2;
                    return true;
                }
                if (BarCod == _ItmBarCod.BarCod3)
                {
                    _Items = _ItmBarCod;
                    DefPack = 3;
                    return true;
                }
                if (BarCod == _ItmBarCod.BarCod4)
                {
                    _Items = _ItmBarCod;
                    DefPack = 4;
                    return true;
                }
                if (BarCod == _ItmBarCod.BarCod5)
                {
                    _Items = _ItmBarCod;
                    DefPack = 5;
                    return true;
                }
            }
            try
            {
                if (VarGeneral.Settings_Sys.IsActiveBalance.Value && !string.IsNullOrEmpty(BarCod))
                {
                    _ItmBarCod = new T_Item();
                    listItems = db.FillItemBarCode_2(BarCod.Substring(VarGeneral.Settings_Sys.BarcodFrom.Value - 1, VarGeneral.Settings_Sys.BarcodTo.Value)).ToList();
                    if (listItems.Count > 0 && listItems[0].IsBalance.Value)
                    {
                        try
                        {
                            if (VarGeneral.Settings_Sys.BalanceType.Value == 0 || VarGeneral.Settings_Sys.BalanceType.Value == 2)
                            {
                                string QtyStr = string.Empty;
                                int _Loop = 0;
                                for (int i = VarGeneral.Settings_Sys.WightFrom.Value - 1; i < BarCod.Length; i++)
                                {
                                    _Loop++;
                                    try
                                    {
                                        QtyStr += BarCod.Substring(i, 1);
                                        if (_Loop >= VarGeneral.Settings_Sys.WightTo.Value)
                                        {
                                            break;
                                        }
                                    }
                                    catch
                                    {
                                    }
                                }
                                try
                                {
                                    if (double.Parse(QtyStr) > 0.0 && VarGeneral.Settings_Sys.WightQ.Value.ToString().Length <= QtyStr.Length)
                                    {
                                        QtyStr = QtyStr.Substring(0, VarGeneral.Settings_Sys.WightQ.Value) + "." + QtyStr.Substring(VarGeneral.Settings_Sys.WightQ.Value);
                                    }
                                }
                                catch
                                {
                                }
                                if (!string.IsNullOrEmpty(QtyStr))
                                {
                                    Balance_Qty = double.Parse(Math.Round(double.Parse(QtyStr), VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2).ToString());
                                }
                            }
                        }
                        catch
                        {
                            Balance_Qty = -1.0;
                        }
                        try
                        {
                            if (VarGeneral.Settings_Sys.BalanceType.Value == 1 || VarGeneral.Settings_Sys.BalanceType.Value == 2)
                            {
                                string PriceStr = string.Empty;
                                int _Loop = 0;
                                for (int i = VarGeneral.Settings_Sys.PriceFrom.Value - 1; i < BarCod.Length; i++)
                                {
                                    _Loop++;
                                    try
                                    {
                                        PriceStr += BarCod.Substring(i, 1);
                                        if (_Loop >= VarGeneral.Settings_Sys.PriceTo.Value)
                                        {
                                            break;
                                        }
                                    }
                                    catch
                                    {
                                    }
                                }
                                try
                                {
                                    if (double.Parse(PriceStr) > 0.0 && VarGeneral.Settings_Sys.PriceQ.Value.ToString().Length <= PriceStr.Length)
                                    {
                                        PriceStr = PriceStr.Substring(0, VarGeneral.Settings_Sys.PriceQ.Value) + "." + PriceStr.Substring(VarGeneral.Settings_Sys.PriceQ.Value);
                                    }
                                }
                                catch
                                {
                                }
                                if (!string.IsNullOrEmpty(PriceStr))
                                {
                                    Balance_Price = double.Parse(Math.Round(double.Parse(PriceStr), VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2).ToString());
                                }
                            }
                        }
                        catch
                        {
                            Balance_Price = -1.0;
                        }
                        for (int iiCnt = 0; iiCnt < listItems.Count; iiCnt++)
                        {
                            _ItmBarCod = listItems[iiCnt];
                            if (BarCod.Substring(VarGeneral.Settings_Sys.BarcodFrom.Value - 1, VarGeneral.Settings_Sys.BarcodTo.Value) == _ItmBarCod.BarCod1)
                            {
                                _Items = _ItmBarCod;
                                DefPack = 1;
                                return true;
                            }
                            if (BarCod.Substring(VarGeneral.Settings_Sys.BarcodFrom.Value - 1, VarGeneral.Settings_Sys.BarcodTo.Value) == _ItmBarCod.BarCod2)
                            {
                                _Items = _ItmBarCod;
                                DefPack = 2;
                                return true;
                            }
                            if (BarCod.Substring(VarGeneral.Settings_Sys.BarcodFrom.Value - 1, VarGeneral.Settings_Sys.BarcodTo.Value) == _ItmBarCod.BarCod3)
                            {
                                _Items = _ItmBarCod;
                                DefPack = 3;
                                return true;
                            }
                            if (BarCod.Substring(VarGeneral.Settings_Sys.BarcodFrom.Value - 1, VarGeneral.Settings_Sys.BarcodTo.Value) == _ItmBarCod.BarCod4)
                            {
                                _Items = _ItmBarCod;
                                DefPack = 4;
                                return true;
                            }
                            if (BarCod.Substring(VarGeneral.Settings_Sys.BarcodFrom.Value - 1, VarGeneral.Settings_Sys.BarcodTo.Value) == _ItmBarCod.BarCod5)
                            {
                                _Items = _ItmBarCod;
                                DefPack = 5;
                                return true;
                            }
                        }
                    }
                }
            }
            catch
            {
            }
            Balance_Qty = -1.0;
            Balance_Price = -1.0;
            return false;
        }
        private void txtTime_Leave(object sender, EventArgs e)
        {
            try
            {
                if (VarGeneral.CheckTime(txtTime.Text))
                {
                    txtTime.Text = TimeSpan.Parse(txtTime.Text).ToString();
                }
                else
                {
                    txtTime.Text = DateTime.Now.ToString("HH:mm");
                }
            }
            catch
            {
                txtTime.Text = DateTime.Now.ToString("HH:mm");
            }
        }
        private void txtHDate_Click(object sender, EventArgs e)
        {
            txtHDate.SelectAll();
        }
        private void FrmInvSalesReturn_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
            {
                label24.Visible = false;
                label23.Visible = false;
                label22.Visible = false;
                label25.Visible = false;
                label32.Visible = false;
                txtVCost.Visible = false;
                txtUnit.Visible = false;
                txtLCost.Visible = false;
                txtLPrice.Visible = false;
                txtVSerial.Visible = false;
            }
            else if (e.KeyCode == Keys.Alt)
            {
                label24.Visible = false;
                label23.Visible = false;
                label22.Visible = false;
                label25.Visible = false;
                label32.Visible = false;
                txtVCost.Visible = false;
                txtUnit.Visible = false;
                txtLCost.Visible = false;
                txtLPrice.Visible = false;
                txtVSerial.Visible = false;
            }
        }
        private void FlxInv_Click(object sender, EventArgs e)
        {
            // ChkPriceIncludeTax.Enabled = false;
            Button_Edit_Click(sender, e);
            if (File.Exists(Application.StartupPath + "\\Script\\SecriptColDisSalesReturn.dll") || (VarGeneral.gUserName == "runsetting" && File.Exists(Application.StartupPath + "\\Script\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\SecriptColDisSalesReturn.dll")) || File.Exists(Application.StartupPath + "\\Script\\SecriptColDisSalesReturnValue.dll") || (VarGeneral.gUserName == "runsetting" && File.Exists(Application.StartupPath + "\\Script\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\SecriptColDisSalesReturnValue.dll")))
            {
                return;
            }
            try
            {
                if (FlxInv.Row > 0 && FlxInv.Col == 36 && VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 66))
                {
                    FlxInv.BeforeEdit -= FlxInv_BeforeEdit;
                    int vRowIndex = FlxInv.Row;
                    FrmInvDetNoteSrch frm = new FrmInvDetNoteSrch();
                    frm.Tag = LangArEn;
                    try
                    {
                        frm.textbox_Detailes.Text = FlxInv.GetData(vRowIndex, 36).ToString() ?? string.Empty;
                    }
                    catch
                    {
                        frm.textbox_Detailes.Text = string.Empty;
                    }
                    frm.TopMost = true;
                    frm.ShowDialog();
                    if (frm.SerachNo != string.Empty)
                    {
                        FlxInv.SetData(vRowIndex, 36, string.Empty);
                        FlxInv.SetData(vRowIndex, 36, FlxInv.GetData(vRowIndex, 36).ToString() + frm.SerachNo);
                    }
                    SendKeys.SendWait("{ENTER}");
                    FlxInv.BeforeEdit += FlxInv_BeforeEdit;
                }
            }
            catch
            {
                FlxInv.BeforeEdit += FlxInv_BeforeEdit;
            }
        }
        private void FillComboMnd()
        {
            try
            {
                CmbLegate.DataSource = null;
            }
            catch
            {
            }
            try
            {
                CmbLegate.Items.Clear();
            }
            catch
            {
            }
            int _CmbIndex = CmbLegate.SelectedIndex;
            if (CmbInvSide.SelectedIndex <= 0)
            {
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                {
                    List<T_Mndob> listMnd = new List<T_Mndob>(db.T_Mndobs.Where((T_Mndob item) => item.Mnd_Typ == (int?)0).ToList());
                    listMnd.Insert(0, new T_Mndob());
                    CmbLegate.DataSource = listMnd;
                    CmbLegate.DisplayMember = "Arb_Des";
                    CmbLegate.ValueMember = "Mnd_ID";
                }
                else
                {
                    List<T_Mndob> listMnd = new List<T_Mndob>(db.T_Mndobs.Where((T_Mndob item) => item.Mnd_Typ == (int?)0).ToList());
                    listMnd.Insert(0, new T_Mndob());
                    CmbLegate.DataSource = listMnd;
                    CmbLegate.DisplayMember = "Eng_Des";
                    CmbLegate.ValueMember = "Mnd_ID";
                }
            }
            else
            {
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                {
                    List<T_Mndob> listMnd = new List<T_Mndob>(db.T_Mndobs.Where((T_Mndob item) => item.Mnd_Typ == (int?)((CmbInvSide.SelectedIndex == 1) ? 1 : 0)).ToList());
                    listMnd.Insert(0, new T_Mndob());
                    CmbLegate.DataSource = listMnd;
                    CmbLegate.DisplayMember = "Arb_Des";
                    CmbLegate.ValueMember = "Mnd_ID";
                }
                else
                {
                    List<T_Mndob> listMnd = new List<T_Mndob>(db.T_Mndobs.Where((T_Mndob item) => item.Mnd_Typ == (int?)((CmbInvSide.SelectedIndex == 1) ? 1 : 0)).ToList());
                    listMnd.Insert(0, new T_Mndob());
                    CmbLegate.DataSource = listMnd;
                    CmbLegate.DisplayMember = "Eng_Des";
                    CmbLegate.ValueMember = "Mnd_ID";
                }
                if (FlxInv.Rows.Count <= 1)
                {
                    FlxInv.Rows.Count = VarGeneral.Settings_Sys.LineOfInvoices.Value;
                }
                else
                {
                    int _rowsCnt = FlxInv.Rows.Count;
                    FlxInv.Rows.Count = 1;
                    FlxInv.Rows.Count = _rowsCnt;
                    FlxInv.Clear(ClearFlags.Content, 1, 1, FlxInv.Rows.Count - 1, 39);
                }
                FlxStkQty.Clear(ClearFlags.Content, 1, 1, 1, 1);
                GetInvTot();
                if (State == FormState.New)
                {
                    button_GoodsDisbursedInv.Visible = true;
                }
                else
                {
                    button_GoodsDisbursedInv.Visible = false;
                }
            }
            CmbLegate.SelectedIndex = _CmbIndex;
            if (CmbInvSide.SelectedIndex == 2)
            {
                label4.Text = ((LangArEn == 0) ? "حساب العميــل :" : "Customer Account :");
            }
            else if (CmbInvSide.SelectedIndex == 3)
            {
                label4.Text = ((LangArEn == 0) ? "حساب المــورد :" : "Supplier Account :");
            }
            else
            {
                label4.Text = ((LangArEn == 0) ? "حساب العميــل :" : "Customer Account :");
            }
        }
        private void FillCombo()
        {
            int _CmbIndex = CmbInvPrice.SelectedIndex;
            CmbInvPrice.Items.Clear();
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
            {
                CmbInvPrice.Items.Add("الأفتراضي");
                CmbInvPrice.Items.Add("سعر الجملة");
                CmbInvPrice.Items.Add("سعر الموزع");
                CmbInvPrice.Items.Add("سعر المندوب");
                CmbInvPrice.Items.Add("سعر التجزئة");
                CmbInvPrice.Items.Add("سعر آخر");
            }
            else
            {
                CmbInvPrice.Items.Add("Default");
                CmbInvPrice.Items.Add("Wholesale price");
                CmbInvPrice.Items.Add("Distributor price");
                CmbInvPrice.Items.Add("Legates Price");
                CmbInvPrice.Items.Add("Retail price");
                CmbInvPrice.Items.Add("Other price");
            }
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
            {
                List<T_Mndob> listMnd = new List<T_Mndob>(db.T_Mndobs.Where((T_Mndob item) => item.Mnd_Typ.Value == 0).ToList());
                listMnd.Insert(0, new T_Mndob());
                CmbLegate.DataSource = listMnd;
                CmbLegate.DisplayMember = "Arb_Des";
                CmbLegate.ValueMember = "Mnd_ID";
            }
            else
            {
                List<T_Mndob> listMnd = new List<T_Mndob>(db.T_Mndobs.Where((T_Mndob item) => item.Mnd_Typ.Value == 0).ToList());
                listMnd.Insert(0, new T_Mndob());
                CmbLegate.DataSource = listMnd;
                CmbLegate.DisplayMember = "Eng_Des";
                CmbLegate.ValueMember = "Mnd_ID";
            }
            CmbLegate.SelectedIndex = _CmbIndex;
            CmbInvPrice.SelectedIndex = _CmbIndex;
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
            {
                CmbInvSide.Items.Add("خيارات صرف البضاعة");
                CmbInvSide.Items.Add("مندوب خارجي");
                CmbInvSide.Items.Add("عميل");
                CmbInvSide.Items.Add("مورد");
            }
            else
            {
                CmbInvSide.Items.Add("Goods Disbursed");
                CmbInvSide.Items.Add("External delegates");
                CmbInvSide.Items.Add("Customer");
                CmbInvSide.Items.Add("Supplier");
            }
            CmbInvSide.SelectedIndex = 0;
            _CmbIndex = CmbCurr.SelectedIndex;
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
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
            CmbCurr.SelectedIndex = _CmbIndex;
            _CmbIndex = CmbCostC.SelectedIndex;
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
            {
                List<T_CstTbl> listCs = new List<T_CstTbl>(db.T_CstTbls.Select((T_CstTbl item) => item).ToList());
                CmbCostC.DataSource = listCs;
                CmbCostC.DisplayMember = "Arb_Des";
                CmbCostC.ValueMember = "Cst_ID";
            }
            else
            {
                List<T_CstTbl> listCs = new List<T_CstTbl>(db.T_CstTbls.Select((T_CstTbl item) => item).ToList());
                CmbCostC.DataSource = listCs;
                CmbCostC.DisplayMember = "Eng_Des";
                CmbCostC.ValueMember = "Cst_ID";
            }
            CmbCostC.SelectedIndex = _CmbIndex;
            FillComboMnd();
        }
        public void SetData(T_INVHED value)
        {
            ChkPriceIncludeTax.Value = (value.PriceIncludTax == true ? true : false);
            //   ChkPriceIncludeTax_ValueChanged(null, null);
            //  ChkPriceIncludeTax.Enabled = false;
            switchButton_Lock.ValueChanged -= switchButton_Lock_ValueChanged;
            try
            {
                if (!RepetitionSts && !ReverseSts)
                {
                    State = FormState.Saved;
                    Button_Save.Enabled = false;
                    textBox_ID.ButtonCustom.Visible = true;
                    textBox_ID.Tag = value.InvHed_ID;
                    try
                    {
                        if (VarGeneral.CheckDate(value.GDat))
                        {
                            txtGDate.Text = Convert.ToDateTime(value.GDat).ToString("yyyy/MM/dd");
                        }
                        else
                        {
                            txtGDate.Text = n.FormatGreg(value.GDat, "yyyy/MM/dd");
                        }
                    }
                    catch
                    {
                        txtGDate.Text = value.GDat;
                    }
                    try
                    {
                        if (VarGeneral.CheckDate(value.HDat))
                        {
                            txtHDate.Text = Convert.ToDateTime(value.HDat).ToString("yyyy/MM/dd");
                        }
                        else
                        {
                            txtHDate.Text = n.FormatHijri(value.HDat, "yyyy/MM/dd");
                        }
                    }
                    catch
                    {
                        txtHDate.Text = value.HDat;
                    }
                    if (VarGeneral.CheckTime(value.LTim))
                    {
                        txtTime.Text = value.LTim;
                    }
                }
                txtCustNo.Text = value.CusVenNo.ToString();
               if(value.CusVenMob!=null)
               text_Mobile.Text = value.CusVenMob.ToString();
                try
                {
                    if (!string.IsNullOrEmpty(value.CusVenNo))
                    {
                        txtCustName.Text = ((LangArEn == 0) ? db.StockAccDefWithOutBalance(value.CusVenNo).Arb_Des : db.StockAccDefWithOutBalance(value.CusVenNo).Eng_Des);
                    }
                    else
                    {
                        txtCustName.Text = value.CusVenNm.ToString();
                    }
                }
                catch
                {
                    txtCustName.Text = value.CusVenNm.ToString();
                }
                if (VarGeneral.SSSLev == "M")
                {
                    txtCustNo.Text = string.Empty;
                }
                txtAddress.Text = value.CusVenAdd;
                txtTele.Text = value.CusVenTel;
                txtRemark.Text = value.Remark;
                txtDiscountP.Value = value.InvDisPrs.GetValueOrDefault();
                txtDiscountVal.Value = value.InvDisVal.GetValueOrDefault();
                txtDiscountValLoc.Value = (value.InvDisValLocCur.HasValue ? value.InvDisValLocCur.Value : 0); ;
                txtDiscoundPoints.Value = (value.DesPointsValue.HasValue ? value.DesPointsValue.Value : 0);
                txtDiscoundPointsLoc.Value = (value.DesPointsValueLocCur.HasValue ? value.DesPointsValueLocCur.Value : 0);
                txtPointCount.Value = (value.PointsCount.HasValue ? value.PointsCount.Value : 0);
                try
                {
                    switchButton_PointActiv.Value = value.IsPoints.GetValueOrDefault();
                }
                catch
                {
                    switchButton_PointActiv.Value = false;
                }
                txtDueAmount.Value = value.InvNet.GetValueOrDefault();
                txtDueAmountLoc.Value = value.InvNetLocCur.GetValueOrDefault();
                txtRef.Text = value.RefNo;
                try
                {
                    txtDescription.Text = value.MODIFIED_BY;
                }
                catch
                {
                    txtDescription.Text = string.Empty;
                }
                txtTotalAm.Value = value.InvTot.GetValueOrDefault();
                txtTotalAmLoc.Value = value.InvTotLocCur.GetValueOrDefault();
                txtTotalQ.Value = value.InvQty.GetValueOrDefault();
                txtCustNet.Value = value.CustNet.GetValueOrDefault();
                txtCustRep.Value = value.CustRep.GetValueOrDefault();
                for (int iiCnt = 0; iiCnt < CmbCostC.Items.Count; iiCnt++)
                {
                    CmbCostC.SelectedIndex = iiCnt;
                    if (CmbCostC.SelectedValue != null && CmbCostC.SelectedValue.ToString() == value.InvCstNo.Value.ToString())
                    {
                        break;
                    }
                }
                for (int iiCnt = 0; iiCnt < CmbCurr.Items.Count; iiCnt++)
                {
                    CmbCurr.SelectedIndex = iiCnt;
                    if (CmbCurr.SelectedValue != null && CmbCurr.SelectedValue.ToString() == value.CurTyp.Value.ToString())
                    {
                        break;
                    }
                }
                if (CmbCurr.SelectedIndex != -1)
                {
                    RateValue = db.StockCurencyID(int.Parse(CmbCurr.SelectedValue.ToString())).Rate.GetValueOrDefault();
                }
                if (value.CustPri.HasValue)
                {
                    CmbInvPrice.SelectedIndex = value.CustPri.GetValueOrDefault();
                }
                if (value.InvCashPay.HasValue)
                {
                    int? invCashPay = value.InvCashPay;
                    if (invCashPay.Value == 0 && invCashPay.HasValue)
                    {
                        if (value.InvCash.Contains("شب")) checkBox_NetWork.Checked = true; else checkBox_Chash.Checked = true;
                    }
                    else if (value.InvCashPay == 1)
                    {
                        checkBox_Credit.Checked = true;
                    }
                    else
                    {
                        checkBox_NetWork.Checked = true;
                    }
                }
                if (!RepetitionSts && !ReverseSts)
                {
                    switchButton_Lock.Value = value.AdminLock.GetValueOrDefault();
                    try
                    {
                        if (data_this.AdminLock.HasValue)
                        {
                            if (!data_this.AdminLock.Value)
                            {
                                label_LockeName.Text = ((LangArEn == 0) ? "غير مقف\u0651ــلة" : "Unlocked");
                            }
                            else
                            {
                                label_LockeName.Text = ((LangArEn == 0) ? ("أقفلها المسؤول : \n" + dbc.RateUsr(data_this.SalsManNam).UsrNamA) : ("Closed By :\n" + dbc.RateUsr(data_this.SalsManNam).UsrNamE));
                            }
                        }
                        else
                        {
                            label_LockeName.Text = ((LangArEn == 0) ? "غير مقف\u0651ــلة" : "Unlocked");
                        }
                    }
                    catch
                    {
                        label_LockeName.Text = ((LangArEn == 0) ? "غير مقف\u0651ــلة" : "Unlocked");
                    }
                    textBox_Usr.Text = ((LangArEn == 0) ? dbc.RateUsr(value.SalsManNo).UsrNamA : dbc.RateUsr(value.SalsManNo).UsrNamE);
                }
                CmbInvSide.SelectedIndex = value.PaymentOrderTyp.GetValueOrDefault();
                FillComboMnd();
                if (value.MndNo.HasValue)
                {
                    CmbLegate.SelectedValue = value.MndNo;
                }
                else
                {
                    CmbLegate.SelectedIndex = 0;
                }
                txtPaymentLoc.Value = value.CashPayLocCur.GetValueOrDefault();
                doubleInput_NetWorkLoc.Value = value.NetworkPayLocCur.GetValueOrDefault();
                doubleInput_CreditLoc.Value = value.CreditPayLocCur.GetValueOrDefault();
                LDataThis = new BindingList<T_INVDET>(value.T_INVDETs).ToList();
                txtDebit1.Text = string.Empty;
                txtDebit2.Text = string.Empty;
                txtDebit3.Text = string.Empty;
                txtCredit1.Text = string.Empty;
                txtCredit2.Text = string.Empty;
                txtCredit3.Text = string.Empty;
                if (value.GadeId.HasValue)
                {
                    listGdHead = db.StockGdHeadid((int)value.GadeId.Value);
                    if (listGdHead.Count != 0)
                    {
                        _GdHead = listGdHead[0];
                        listGdDet = _GdHead.T_GDDETs.ToList();
                        for (int i = 0; i < listGdDet.Count; i++)
                        {
                            if (listGdDet[i].Lin == 1)
                            {
                                if (listGdDet[i].gdValue > 0.0)
                                {
                                    txtDebit1.Tag = listGdDet[i].AccNo;
                                    txtDebit1.Text = ((LangArEn == 0) ? db.SelectAccRootByCode(listGdDet[i].AccNo).Arb_Des : db.SelectAccRootByCode(listGdDet[i].AccNo).Eng_Des);
                                }
                                else
                                {
                                    txtCredit1.Tag = listGdDet[i].AccNo;
                                    txtCredit1.Text = ((LangArEn == 0) ? db.SelectAccRootByCode(listGdDet[i].AccNo).Arb_Des : db.SelectAccRootByCode(listGdDet[i].AccNo).Eng_Des);
                                }
                            }
                            else if (listGdDet[i].Lin == 2)
                            {
                                if (listGdDet[i].gdValue > 0.0)
                                {
                                    txtDebit2.Tag = listGdDet[i].AccNo;
                                    txtDebit2.Text = ((LangArEn == 0) ? db.SelectAccRootByCode(listGdDet[i].AccNo).Arb_Des : db.SelectAccRootByCode(listGdDet[i].AccNo).Eng_Des);
                                }
                                else
                                {
                                    txtCredit2.Tag = listGdDet[i].AccNo;
                                    txtCredit2.Text = ((LangArEn == 0) ? db.SelectAccRootByCode(listGdDet[i].AccNo).Arb_Des : db.SelectAccRootByCode(listGdDet[i].AccNo).Eng_Des);
                                }
                            }
                            else if (listGdDet[i].gdValue > 0.0)
                            {
                                txtDebit3.Tag = listGdDet[i].AccNo;
                                txtDebit3.Text = ((LangArEn == 0) ? db.SelectAccRootByCode(listGdDet[i].AccNo).Arb_Des : db.SelectAccRootByCode(listGdDet[i].AccNo).Eng_Des);
                            }
                            else
                            {
                                txtCredit3.Tag = listGdDet[i].AccNo;
                                txtCredit3.Text = ((LangArEn == 0) ? db.SelectAccRootByCode(listGdDet[i].AccNo).Arb_Des : db.SelectAccRootByCode(listGdDet[i].AccNo).Eng_Des);
                            }
                        }
                    }
                    else
                    {
                        _GdHead = new T_GDHEAD();
                    }
                }
                txtDebit5.Text = string.Empty;
                txtCredit5.Text = string.Empty;
                txtTotTax.Value = value.InvAddTax.GetValueOrDefault();
                txtTotTaxLoc.Value = value.InvAddTaxlLoc.GetValueOrDefault();
                switchButton_Tax.ValueChanged -= switchButton_Tax_ValueChanged;
                if (value.IsTaxUse.Value)
                {
                    switchButton_Tax.Value = true;
                }
                else
                {
                    switchButton_Tax.Value = false;
                }
                switchButton_Tax.ValueChanged += switchButton_Tax_ValueChanged;
                switchButton_TaxLines.ValueChanged -= switchButton_TaxLines_ValueChanged;
                if (value.IsTaxLines.HasValue)
                    if (value.IsTaxLines.Value)
                    {
                        switchButton_TaxLines.Value = true;
                    }
                    else
                    {
                        switchButton_TaxLines.Value = false;
                    }
                if (value.IsTaxByTotal.HasValue)
                    if (value.IsTaxByTotal.Value)
                    {
                        switchButton_TaxByTotal.Value = true;
                    }
                    else
                    {
                        switchButton_TaxByTotal.Value = false;
                    }
                if (value.IsTaxByNet.HasValue)
                    if (value.IsTaxByNet.Value)
                    {
                        switchButton_TaxByNet.Value = true;
                    }
                    else
                    {
                        switchButton_TaxByNet.Value = false;
                    }
                textBoxItem_TaxByNetValue.Text = (value.TaxByNetValue.HasValue ? value.TaxByNetValue.Value.ToString() : string.Empty);
                switchButton_TaxLines.ValueChanged += switchButton_TaxLines_ValueChanged;
                if (value.IsTaxGaid.HasValue)
                {
                    checkBox_CostGaidTax.Checked = value.IsTaxGaid.GetValueOrDefault();
                }
                else
                {
                    checkBox_CostGaidTax_CheckedChanged(null, null);
                }
                if (value.TaxGaidID.HasValue)
                {
                    listGdHeadCostTax = db.StockGdHeadid((int)value.TaxGaidID.Value);
                    if (listGdHeadCostTax.Count != 0)
                    {
                        _GdHeadCostTax = listGdHeadCostTax[0];
                        listGdDetCostTax = _GdHeadCostTax.T_GDDETs.ToList();
                        for (int i = 0; i < listGdDetCostTax.Count; i++)
                        {
                            if (listGdDetCostTax[i].gdValue > 0.0)
                            {
                                txtDebit5.Tag = listGdDetCostTax[i].AccNo;
                                txtDebit5.Text = ((LangArEn == 0) ? db.SelectAccRootByCode(listGdDetCostTax[i].AccNo).Arb_Des : db.SelectAccRootByCode(listGdDetCostTax[i].AccNo).Eng_Des);
                            }
                            else
                            {
                                txtCredit5.Tag = listGdDetCostTax[i].AccNo;
                                txtCredit5.Text = ((LangArEn == 0) ? db.SelectAccRootByCode(listGdDetCostTax[i].AccNo).Arb_Des : db.SelectAccRootByCode(listGdDetCostTax[i].AccNo).Eng_Des);
                            }
                        }
                    }
                    else
                    {
                        _GdHeadCostTax = new T_GDHEAD();
                    }
                }
                txtDebit6.Text = string.Empty;
                txtCredit6.Text = string.Empty;
                txtTotDis.Value = (value.InvValGaidDis.HasValue ? value.InvValGaidDis.Value : 0);
                txtTotDisLoc.Value = (value.InvValGaidDislLoc.HasValue ? value.InvValGaidDislLoc.Value : 0);
                switchButton_Dis.ValueChanged -= switchButton_Dis_ValueChanged;
                if (value.IsDisUse1.Value)
                {
                    switchButton_Dis.Value = true;
                }
                else
                {
                    switchButton_Dis.Value = false;
                }
                switchButton_Dis.ValueChanged += switchButton_Dis_ValueChanged;
                if (value.IsDisGaid.HasValue)
                {
                    checkBox_GaidDis.Checked = value.IsDisGaid.GetValueOrDefault();
                }
                else
                {
                    checkBox_GaidDis_CheckedChanged(null, null);
                }
                if (value.DisGaidID1.HasValue)
                {
                    listGdHeadCostDis = db.StockGdHeadid((int)value.DisGaidID1.Value);
                    if (listGdHeadCostDis.Count != 0)
                    {
                        _GdHeadCostDis = listGdHeadCostDis[0];
                        listGdDetCostDis = _GdHeadCostDis.T_GDDETs.ToList();
                        for (int i = 0; i < listGdDetCostDis.Count; i++)
                        {
                            if (listGdDetCostDis[i].gdValue > 0.0)
                            {
                                txtDebit6.Tag = listGdDetCostDis[i].AccNo;
                                txtDebit6.Text = ((LangArEn == 0) ? db.SelectAccRootByCode(listGdDetCostDis[i].AccNo).Arb_Des : db.SelectAccRootByCode(listGdDetCostDis[i].AccNo).Eng_Des);
                            }
                            else
                            {
                                txtCredit6.Tag = listGdDetCostDis[i].AccNo;
                                txtCredit6.Text = ((LangArEn == 0) ? db.SelectAccRootByCode(listGdDetCostDis[i].AccNo).Arb_Des : db.SelectAccRootByCode(listGdDetCostDis[i].AccNo).Eng_Des);
                            }
                        }
                    }
                    else
                    {
                        _GdHeadCostDis = new T_GDHEAD();
                    }
                }
                SetLines(LDataThis);
                CmbInvSide_SelectedIndexChanged(null, null);
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("SetData:", error, enable: true);
                MessageBox.Show(error.Message);
            }
            switchButton_Lock.ValueChanged += switchButton_Lock_ValueChanged;
        }
        public void SetLines(List<T_INVDET> listDet)
        {
            try
            {
                if (!RepetitionSts && !ReverseSts)
                {
                    FlxInv.Rows.Count = listDet.Count + 1;
                }
                FlxInv.Cols[27].Visible = false;
                FlxInv.Cols[35].Visible = false;
                for (int iiCnt = 1; iiCnt <= listDet.Count; iiCnt++)
                {
                    _InvDet = listDet[iiCnt - 1];
                    int Ser = _InvDet.InvSer.GetValueOrDefault();
                    FlxInv.SetData(iiCnt, 0, Ser.ToString());
                    FlxInv.SetData(iiCnt, 1, _InvDet.ItmNo.Trim());
                    FlxInv.SetData(iiCnt, 2, _InvDet.ItmDes.ToString());
                    FlxInv.SetData(iiCnt, 3, _InvDet.ItmUnt.ToString());
                    FlxInv.SetData(iiCnt, 4, _InvDet.ItmDesE.ToString());
                    FlxInv.SetData(iiCnt, 5, _InvDet.ItmUntE.ToString());
                    FlxInv.SetData(iiCnt, 6, _InvDet.StoreNo.Value);
                    FlxInv.SetData(iiCnt, 7, Math.Abs((decimal)_InvDet.Qty.Value));
                    FlxInv.SetData(iiCnt, 8, _InvDet.Price.Value);
                    FlxInv.SetData(iiCnt, 9, _InvDet.ItmDis);
                    FlxInv.SetData(iiCnt, 10, _InvDet.Cost.Value);
                    FlxInv.SetData(iiCnt, 11, _InvDet.ItmUntPak.Value);
                    FlxInv.SetData(iiCnt, 12, Math.Abs((decimal)_InvDet.RealQty.Value));
                    FlxInv.SetData(iiCnt, 13, _InvDet.itmInvDsc.Value);
                    FlxInv.SetData(iiCnt, 14, _InvDet.Cost.Value);
                    FlxInv.SetData(iiCnt, 15, _InvDet.ItmDes.ToString());
                    FlxInv.SetData(iiCnt, 16, _InvDet.Cost.Value);
                    FlxInv.SetData(iiCnt, 18, _InvDet.T_Item.DefultUnit.Value);
                    FlxInv.SetData(iiCnt, 19, _InvDet.T_Item.Price1.Value);
                    FlxInv.SetData(iiCnt, 20, _InvDet.T_Item.Price2.Value);
                    FlxInv.SetData(iiCnt, 21, _InvDet.T_Item.Price3.Value);
                    FlxInv.SetData(iiCnt, 22, _InvDet.T_Item.Price4.Value);
                    FlxInv.SetData(iiCnt, 23, _InvDet.T_Item.Price5.Value);
                    FlxInv.SetData(iiCnt, 25, _InvDet.InvDet_ID);
                    FlxInv.SetData(iiCnt, 27, _InvDet.DatExper ?? string.Empty);
                    if ((_InvDet.DatExper ?? string.Empty) != string.Empty || (_InvDet.RunCod ?? string.Empty) != string.Empty)
                    {
                        FlxInv.Cols[27].Visible = true;
                        FlxInv.Cols[35].Visible = true;
                        FlxInv.SetData(iiCnt, 28, 1);
                    }
                    try
                    {
                        FlxInv.SetData(iiCnt, 33, (_InvDet.ItmWight.Value != 0.0) ? true : false);
                    }
                    catch
                    {
                        FlxInv.SetData(iiCnt, 33, false);
                    }
                    FlxInv.SetData(iiCnt, 32, _InvDet.ItmTyp.Value);
                    FlxInv.SetData(iiCnt, 38, _InvDet.Amount.Value);
                    FlxInv.SetData(iiCnt, 35, _InvDet.RunCod.Trim());
                    FlxInv.SetData(iiCnt, 36, _InvDet.LineDetails.Trim());
                    FlxInv.SetData(iiCnt, 37, _InvDet.Serial_Key.Trim());
                    FlxInv.SetData(iiCnt, 31, _InvDet.ItmTax.Value);
                    try
                    {
                        FlxInv.SetData(iiCnt, 39, _InvDet.OfferTyp);
                        try
                        {
                            if (int.Parse(FlxInv.GetData(iiCnt, 39).ToString()) == 1)
                            {
                                FlxInv.Rows[iiCnt].StyleNew.BackColor = Color.Gainsboro;
                                FlxInv.Rows[iiCnt].AllowEditing = false;
                            }
                        }
                        catch
                        {
                        }
                    }
                    catch
                    {
                    }
                    listStkQty = (from t in db.T_STKSQTies
                                  where t.storeNo == (int?)_InvDet.StoreNo.Value
                                  where t.itmNo == _InvDet.ItmNo.Trim()
                                  select t).ToList();
                    if (listStkQty.Count != 0)
                    {
                        _StksQty = listStkQty[0];
                        FlxInv.SetData(iiCnt, 24, _InvDet.RealQty.Value + _StksQty.stkQty.Value);
                    }
                }
                if (draft == 1) FlxInv.Rows.Count += VarGeneral.Settings_Sys.LineOfInvoices.Value;
            }
            catch
            {
                MessageBox.Show((LangArEn == 0) ? "حدث خطأ أثناء تعبئة الأسطر .." : "An error occurred while filling lines ..", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
        int draft = 0;
        public void SetDataRt(T_INVHED value)
        {
            switchButton_Lock.ValueChanged -= switchButton_Lock_ValueChanged;
            try
            {
                dataGridView_ItemDet.Clear(ClearFlags.Content, 1, 1, dataGridView_ItemDet.Rows.Count - 1, 34);
            }
            catch
            {
            }
            dataGridView_ItemDet.Rows.Count = 1;
            dataGridView_ItemDet.Visible = false;
            ButReturn.Tag = value.InvHed_ID.ToString();
            txtCustNo.Text = value.CusVenNo.ToString();
            try
            {
                if (!string.IsNullOrEmpty(value.CusVenNo))
                {
                    txtCustName.Text = ((LangArEn == 0) ? db.StockAccDefWithOutBalance(value.CusVenNo).Arb_Des : db.StockAccDefWithOutBalance(value.CusVenNo).Eng_Des);
                }
                else
                {
                    txtCustName.Text = value.CusVenNm.ToString();
                }
            }
            catch
            {
                txtCustName.Text = value.CusVenNm.ToString();
            }
            if (VarGeneral.SSSLev == "M")
            {
                txtCustNo.Text = string.Empty;
            }
            txtAddress.Text = value.CusVenAdd;
            txtTele.Text = value.CusVenTel;
            txtRemark.Text = value.Remark;
            txtDiscountP.Value = value.InvDisPrs.Value;
            txtDiscountVal.Value = value.InvDisVal.Value;
            txtDiscountValLoc.Value = value.InvDisValLocCur.Value;
            txtDiscoundPoints.Value = value.DesPointsValue.Value;
            txtDiscoundPointsLoc.Value = value.DesPointsValueLocCur.Value;
            txtPointCount.Value = value.PointsCount.Value;
            try
            {
                switchButton_PointActiv.Value = value.IsPoints.Value;
            }
            catch
            {
                switchButton_PointActiv.Value = false;
            }
            txtDueAmount.Value = value.InvNet.Value;
            txtDueAmountLoc.Value = value.InvNetLocCur.Value;
            switchButton_Lock.Value = value.AdminLock.Value;
            try
            {
                if (data_this.AdminLock.HasValue)
                {
                    if (!data_this.AdminLock.Value)
                    {
                        label_LockeName.Text = ((LangArEn == 0) ? "غير مقف\u0651ــلة" : "Unlocked");
                    }
                    else
                    {
                        label_LockeName.Text = ((LangArEn == 0) ? ("أقفلها المسؤول : \n" + dbc.RateUsr(data_this.SalsManNam).UsrNamA) : ("Closed By :\n" + dbc.RateUsr(data_this.SalsManNam).UsrNamE));
                    }
                }
                else
                {
                    label_LockeName.Text = ((LangArEn == 0) ? "غير مقف\u0651ــلة" : "Unlocked");
                }
            }
            catch
            {
                label_LockeName.Text = ((LangArEn == 0) ? "غير مقف\u0651ــلة" : "Unlocked");
            }
            try
            {
                if (value.InvTyp == 17)
                {
                    CmbInvSide.SelectedIndex = value.PaymentOrderTyp.GetValueOrDefault() + 1;
                }
                else
                {
                    CmbInvSide.SelectedIndex = value.PaymentOrderTyp.GetValueOrDefault();
                }
            }
            catch
            {
            }
            try
            {
                if (VarGeneral.CheckDate(value.GDat))
                {
                    txtGDate.Text = Convert.ToDateTime(value.GDat).ToString("yyyy/MM/dd");
                }
                else
                {
                    txtGDate.Text = n.FormatGreg(value.GDat, "yyyy/MM/dd");
                }
            }
            catch
            {
                txtGDate.Text = value.GDat;
            }
            try
            {
                if (VarGeneral.CheckDate(value.HDat))
                {
                    txtHDate.Text = Convert.ToDateTime(value.HDat).ToString("yyyy/MM/dd");
                }
                else
                {
                    txtHDate.Text = n.FormatHijri(value.HDat, "yyyy/MM/dd");
                }
            }
            catch
            {
                txtHDate.Text = value.HDat;
            }
            txtRef.Text = value.RefNo;
            try
            {
                txtDescription.Text = value.MODIFIED_BY;
            }
            catch
            {
                txtDescription.Text = string.Empty;
            }
            if (VarGeneral.CheckTime(value.LTim))
            {
                txtTime.Text = value.LTim;
            }
            txtTotalAm.Value = value.InvTot.Value;
            txtTotalAmLoc.Value = value.InvTotLocCur.Value;
            txtTotalQ.Value = value.InvQty.Value;
            txtCustNet.Value = value.CustNet.Value;
            txtCustRep.Value = value.CustRep.Value;
            for (int iiCnt = 0; iiCnt < CmbCostC.Items.Count; iiCnt++)
            {
                CmbCostC.SelectedIndex = iiCnt;
                if (CmbCostC.SelectedValue != null && CmbCostC.SelectedValue.ToString() == value.InvCstNo.Value.ToString())
                {
                    break;
                }
            }
            for (int iiCnt = 0; iiCnt < CmbCurr.Items.Count; iiCnt++)
            {
                CmbCurr.SelectedIndex = iiCnt;
                if (CmbCurr.SelectedValue != null && CmbCurr.SelectedValue.ToString() == value.CurTyp.Value.ToString())
                {
                    break;
                }
            }
            if (CmbCurr.SelectedIndex != -1)
            {
                RateValue = db.StockCurencyID(int.Parse(CmbCurr.SelectedValue.ToString())).Rate.Value;
            }
            if (value.MndNo.HasValue)
            {
                CmbLegate.SelectedValue = value.MndNo;
            }
            else
            {
                CmbLegate.SelectedIndex = 0;
            }
            if (value.CustPri.HasValue)
            {
                CmbInvPrice.SelectedIndex = value.CustPri.Value;
            }
            if (value.InvCashPay.HasValue)
            {
                int? invCashPay = value.InvCashPay;
                if (invCashPay.Value == 0 && invCashPay.HasValue)
                {
                    if (value.InvCash == "الشبكة") checkBox_NetWork.Checked = true; else checkBox_Chash.Checked = true;
                }
                else if (value.InvCashPay == 1)
                {
                    checkBox_Credit.Checked = true;
                }
                else
                {
                    checkBox_NetWork.Checked = true;
                }
            }
            textBox_Usr.Text = ((LangArEn == 0) ? dbc.RateUsr(value.SalsManNo).UsrNamA : dbc.RateUsr(value.SalsManNo).UsrNamE);
            txtPaymentLoc.Value = value.CashPayLocCur.Value;
            doubleInput_NetWorkLoc.Value = value.NetworkPayLocCur.Value;
            doubleInput_CreditLoc.Value = value.CreditPayLocCur.Value;
            txtDebit5.Text = string.Empty;
            txtCredit5.Text = string.Empty;
            txtTotTax.Value = value.InvAddTax.Value;
            txtTotTaxLoc.Value = value.InvAddTaxlLoc.Value;
            switchButton_Tax.ValueChanged -= switchButton_Tax_ValueChanged;
            if (value.IsTaxUse.Value)
            {
                switchButton_Tax.Value = true;
            }
            else
            {
                switchButton_Tax.Value = false;
            }
            switchButton_Tax.ValueChanged += switchButton_Tax_ValueChanged;
            switchButton_TaxLines.ValueChanged -= switchButton_TaxLines_ValueChanged;
            if (value.IsTaxLines.Value)
            {
                switchButton_TaxLines.Value = true;
            }
            else
            {
                switchButton_TaxLines.Value = false;
            }
            if (value.IsTaxByTotal.Value)
            {
                switchButton_TaxByTotal.Value = true;
            }
            else
            {
                switchButton_TaxByTotal.Value = false;
            }
            if (value.IsTaxByNet.Value)
            {
                switchButton_TaxByNet.Value = true;
            }
            else
            {
                switchButton_TaxByNet.Value = false;
            }
            textBoxItem_TaxByNetValue.Text = value.TaxByNetValue.Value.ToString();
            switchButton_TaxLines.ValueChanged += switchButton_TaxLines_ValueChanged;
            if (value.IsTaxGaid.HasValue)
            {
                checkBox_CostGaidTax.Checked = value.IsTaxGaid.Value;
            }
            else
            {
                checkBox_CostGaidTax_CheckedChanged(null, null);
            }
            if (value.TaxGaidID.HasValue)
            {
                listGdHeadCostTax = db.StockGdHeadid((int)value.TaxGaidID.Value);
                if (listGdHeadCostTax.Count != 0)
                {
                    _GdHeadCostTax = listGdHeadCostTax[0];
                    listGdDetCostTax = _GdHeadCostTax.T_GDDETs.ToList();
                    for (int i = 0; i < listGdDetCostTax.Count; i++)
                    {
                        if (listGdDetCostTax[i].gdValue > 0.0)
                        {
                            txtDebit5.Tag = listGdDetCostTax[i].AccNo;
                            txtDebit5.Text = ((LangArEn == 0) ? db.SelectAccRootByCode(listGdDetCostTax[i].AccNo).Arb_Des : db.SelectAccRootByCode(listGdDetCostTax[i].AccNo).Eng_Des);
                        }
                        else
                        {
                            txtCredit5.Tag = listGdDetCostTax[i].AccNo;
                            txtCredit5.Text = ((LangArEn == 0) ? db.SelectAccRootByCode(listGdDetCostTax[i].AccNo).Arb_Des : db.SelectAccRootByCode(listGdDetCostTax[i].AccNo).Eng_Des);
                        }
                    }
                }
                else
                {
                    _GdHeadCostTax = new T_GDHEAD();
                }
            }
            txtDebit6.Text = string.Empty;
            txtCredit6.Text = string.Empty;
            txtTotDis.Value = value.InvValGaidDis.Value;
            txtTotDisLoc.Value = value.InvValGaidDislLoc.Value;
            switchButton_Dis.ValueChanged -= switchButton_Dis_ValueChanged;
            if (value.IsDisUse1.Value)
            {
                switchButton_Dis.Value = true;
            }
            else
            {
                switchButton_Dis.Value = false;
            }
            switchButton_Dis.ValueChanged += switchButton_Dis_ValueChanged;
            if (value.IsDisGaid.HasValue)
            {
                checkBox_GaidDis.Checked = value.IsDisGaid.Value;
            }
            else
            {
                checkBox_GaidDis_CheckedChanged(null, null);
            }
            if (value.DisGaidID1.HasValue)
            {
                listGdHeadCostDis = db.StockGdHeadid((int)value.DisGaidID1.Value);
                if (listGdHeadCostDis.Count != 0)
                {
                    _GdHeadCostDis = listGdHeadCostDis[0];
                    listGdDetCostDis = _GdHeadCostDis.T_GDDETs.ToList();
                    for (int i = 0; i < listGdDetCostDis.Count; i++)
                    {
                        if (listGdDetCostDis[i].gdValue > 0.0)
                        {
                            txtDebit6.Tag = listGdDetCostDis[i].AccNo;
                            txtDebit6.Text = ((LangArEn == 0) ? db.SelectAccRootByCode(listGdDetCostDis[i].AccNo).Arb_Des : db.SelectAccRootByCode(listGdDetCostDis[i].AccNo).Eng_Des);
                        }
                        else
                        {
                            txtCredit6.Tag = listGdDetCostDis[i].AccNo;
                            txtCredit6.Text = ((LangArEn == 0) ? db.SelectAccRootByCode(listGdDetCostDis[i].AccNo).Arb_Des : db.SelectAccRootByCode(listGdDetCostDis[i].AccNo).Eng_Des);
                        }
                    }
                }
                else
                {
                    _GdHeadCostDis = new T_GDHEAD();
                }
            }
            LDataThisRe = new BindingList<T_INVDET>(value.T_INVDETs).ToList();
            SetLinesRt(LDataThisRe);
            switchButton_Lock.ValueChanged += switchButton_Lock_ValueChanged;
        }
        public void SetLinesRt(List<T_INVDET> listDet)
        {
            try
            {
                FlxInv.Cols[27].Visible = false;
                FlxInv.Cols[35].Visible = false;
                for (int iiCnt = 1; iiCnt <= listDet.Count; iiCnt++)
                {
                    _InvDet = listDet[iiCnt - 1];
                    int Ser = _InvDet.InvSer.GetValueOrDefault();
                    FlxInv.SetData(iiCnt, 0, Ser.ToString());
                    FlxInv.SetData(iiCnt, 1, _InvDet.ItmNo.Trim());
                    FlxInv.SetData(iiCnt, 2, _InvDet.ItmDes.ToString());
                    FlxInv.SetData(iiCnt, 3, _InvDet.ItmUnt.ToString());
                    FlxInv.SetData(iiCnt, 4, _InvDet.ItmDesE.ToString());
                    FlxInv.SetData(iiCnt, 5, _InvDet.ItmUntE.ToString());
                    FlxInv.SetData(iiCnt, 6, _InvDet.StoreNo.Value);
                    FlxInv.SetData(iiCnt, 7, Math.Abs((decimal)_InvDet.Qty.Value));
                    FlxInv.SetData(iiCnt, 8, _InvDet.Price.Value);
                    FlxInv.SetData(iiCnt, 9, _InvDet.ItmDis);
                    FlxInv.SetData(iiCnt, 10, _InvDet.Cost.Value);
                    FlxInv.SetData(iiCnt, 11, _InvDet.ItmUntPak.Value);
                    FlxInv.SetData(iiCnt, 12, Math.Abs((decimal)_InvDet.RealQty.Value));
                    FlxInv.SetData(iiCnt, 13, _InvDet.itmInvDsc.Value);
                    FlxInv.SetData(iiCnt, 14, _InvDet.Cost.Value);
                    FlxInv.SetData(iiCnt, 15, _InvDet.ItmDes.ToString());
                    FlxInv.SetData(iiCnt, 16, _InvDet.Cost.Value);
                    FlxInv.SetData(iiCnt, 18, _InvDet.T_Item.DefultUnit.Value);
                    FlxInv.SetData(iiCnt, 19, _InvDet.T_Item.Price1.Value);
                    FlxInv.SetData(iiCnt, 20, _InvDet.T_Item.Price2.Value);
                    FlxInv.SetData(iiCnt, 21, _InvDet.T_Item.Price3.Value);
                    FlxInv.SetData(iiCnt, 22, _InvDet.T_Item.Price4.Value);
                    FlxInv.SetData(iiCnt, 23, _InvDet.T_Item.Price5.Value);
                    FlxInv.SetData(iiCnt, 25, _InvDet.InvDet_ID);
                    FlxInv.SetData(iiCnt, 27, _InvDet.DatExper ?? string.Empty);
                    if ((_InvDet.DatExper ?? string.Empty) != string.Empty || (_InvDet.RunCod ?? string.Empty) != string.Empty)
                    {
                        FlxInv.Cols[27].Visible = true;
                        FlxInv.Cols[35].Visible = true;
                        FlxInv.SetData(iiCnt, 28, 1);
                    }
                    try
                    {
                        FlxInv.SetData(iiCnt, 33, (_InvDet.ItmWight.Value != 0.0) ? true : false);
                    }
                    catch
                    {
                        FlxInv.SetData(iiCnt, 33, false);
                    }
                    FlxInv.SetData(iiCnt, 32, _InvDet.ItmTyp.Value);
                    FlxInv.SetData(iiCnt, 38, _InvDet.Amount.Value);
                    FlxInv.SetData(iiCnt, 35, _InvDet.RunCod.Trim());
                    FlxInv.SetData(iiCnt, 36, _InvDet.LineDetails.Trim());
                    FlxInv.SetData(iiCnt, 37, _InvDet.Serial_Key.Trim());
                    FlxInv.SetData(iiCnt, 31, _InvDet.ItmTax.Value);
                    try
                    {
                        FlxInv.SetData(iiCnt, 39, _InvDet.OfferTyp);
                        try
                        {
                            if (int.Parse(FlxInv.GetData(iiCnt, 39).ToString()) == 1)
                            {
                                FlxInv.Rows[iiCnt].StyleNew.BackColor = Color.Gainsboro;
                                FlxInv.Rows[iiCnt].AllowEditing = false;
                            }
                        }
                        catch
                        {
                        }
                    }
                    catch
                    {
                    }
                    listStkQty = (from t in db.T_STKSQTies
                                  where t.storeNo == (int?)_InvDet.StoreNo.Value
                                  where t.itmNo == _InvDet.ItmNo.Trim()
                                  select t).ToList();
                    if (listStkQty.Count != 0)
                    {
                        _StksQty = listStkQty[0];
                        FlxInv.SetData(iiCnt, 24, _InvDet.RealQty.Value + _StksQty.stkQty.Value);
                    }
                }
            }
            catch
            {
                MessageBox.Show((LangArEn == 0) ? "حدث خطأ أثناء تعبئة الأسطر .." : "An error occurred while filling lines ..", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
        private bool ValidData()
        {
            if (textBox_ID.Text == "0" || textBox_ID.Text == string.Empty)
            {
                MessageBox.Show((LangArEn == 0) ? "لا يمكن الحفظ بدون رقم الفاتورة - السند" : "Can not save without the invoice number", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                textBox_ID.Focus();
                return false;
            }
            if (checkBox_Credit.Checked && txtCustNo.Text == string.Empty && VarGeneral.SSSLev != "M")
            {
                MessageBox.Show((LangArEn == 0) ? "لا يمكن حفظ فاتورة آجلة بدون رقم حساب العميل" : "Can not save without the customer's account number.", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                txtCustNo.Focus();
                return false;
            }
            if (CmbLegate.SelectedIndex <= 0 && CmbInvSide.SelectedIndex == 1)
            {
                MessageBox.Show((LangArEn == 0) ? "يجب تحديد المندوب الخارجي لهذه البضاعة قبل إتمام عملية الحفظ" : "You must specify the external representative of these goods ", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                CmbLegate.Focus();
                return false;
            }
            if (CmbInvSide.SelectedIndex > 1 && txtCustNo.Text == string.Empty && VarGeneral.SSSLev != "M")
            {
                MessageBox.Show((LangArEn == 0) ? "يجب تحديد العميل / المورد لهذه البضاعة قبل إتمام عملية الحفظ" : "You must specify the Customer/Supplier of these goods ", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                CmbLegate.Focus();
                return false;
            }
            if (!VarGeneral.TString.ChkStatShow(VarGeneral.UserPassQty, 9) && (txtDueAmountLoc.Value == 0.0 || txtDueAmountLoc.Value == 0.0))
            {
                MessageBox.Show((LangArEn == 0) ? "لا يمكن الحفظ والصافي يساوي صفر" : "Can not save, and the total is equal to zero", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }
            if (txtTotalQ.Value <= 0.0)
            {
                MessageBox.Show((LangArEn == 0) ? "يجب ان لا يكون الكمية فارغة .. يرجى التأكد من وجود الأصناف في الفاتورة" : "We must not be empty value .. Please make sure there are items in the bill.", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }
            if (txtPaymentLoc.Value + doubleInput_NetWorkLoc.Value + doubleInput_CreditLoc.Value != (checkBox_CostGaidTax.Checked ? (txtDueAmountLoc.Value - txtTotTax.Value) : txtDueAmountLoc.Value))
            {
                MessageBox.Show((LangArEn == 0) ? "يجب ان يكون مجموع المدفوعات النقدية والآجلة مساوية لصافي الفاتورة .. يرجى التاكد من المدفوعات!" : "You must be the total cash payments and futures is equal to the net invoice .. Please confirm the payments!", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                superTabControl_Info.SelectedTabIndex = 1;
                txtPaymentLoc.Focus();
                return false;
            }
            if (!VarGeneral.TString.ChkStatShow(VarGeneral.UserPassQty, 9) && checkBox_Chash.Checked && txtPaymentLoc.Value <= 0.0 && doubleInput_NetWorkLoc.Value <= 0.0)
            {
                MessageBox.Show((LangArEn == 0) ? "لايمكن الحفظ كفاتورة نقدية واجمالي المدفوعات النقدية أصغر من او يساوي الصفر " : "You can not save a bill in cash and total cash payments smaller than or equal to zero", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                superTabControl_Info.SelectedTabIndex = 1;
                txtPaymentLoc.Focus();
                return false;
            }
            if (checkBox_Credit.Checked && doubleInput_CreditLoc.Value <= 0.0 && doubleInput_NetWorkLoc.Value <= 0.0)
            {
                MessageBox.Show((LangArEn == 0) ? "لايمكن الحفظ كفاتورة آجلة واجمالي المدفوعات الآجلة أصغر من او يساوي الصفر " : "You can not save a bill futures and futures total payments smaller than or equal to zero", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                superTabControl_Info.SelectedTabIndex = 1;
                doubleInput_CreditLoc.Focus();
                return false;
            }
            if (State == FormState.Edit)
            {
                T_INVHED newData = db.StockInvHead(VarGeneral.InvTyp, textBox_ID.Text);
                if ((!string.IsNullOrEmpty(newData.InvNo) || newData.InvHed_ID > 0) && newData.InvHed_ID != data_this.InvHed_ID)
                {
                    MessageBox.Show((LangArEn == 0) ? " رقم الفاتورة مكرر يرجى تغييره" : "Employee No It's a existing", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    textBox_ID.Focus();
                    return false;
                }
                if (data_this.PaymentOrderTyp.GetValueOrDefault() > 0 && CmbInvSide.SelectedIndex <= 0)
                {
                    MessageBox.Show((LangArEn == 0) ? "هذه فاتورة مبيعات صرف بضاعة ولايمكن تغييرها الى مبيعات \n دون تحديد جهة الصرف - مندوب - عميل - مورد" : "This is a commodity exchange sales invoice can not be changed to sales", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return false;
                }
                if (data_this.PaymentOrderTyp.GetValueOrDefault() <= 0 && CmbInvSide.SelectedIndex > 0)
                {
                    MessageBox.Show((LangArEn == 0) ? "هذه فاتورة مبيعات ولايمكن تغييرها الى مبيعات صرف بضاعة" : "These sales invoice can not be changed to a commodity exchange sales", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return false;
                }
            }
            try
            {
                if (permission.MaxDiscountSals.Value > 0.0 && txtDiscountP.Value > permission.MaxDiscountSals.Value)
                {
                    MessageBox.Show((LangArEn == 0) ? "لقد تجاوزت نسبة الخصم المسموحة لك .. يرجى تعديل نسبة الخصم والمحاولة مرة اخرى " : "Error in Discount % .. check it and try again", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    txtDiscountP.Focus();
                    return false;
                }
            }
            catch
            {
            }
            List<string> _ItemSpictal = new List<string>();
            for (int iiCnt = 1; iiCnt < FlxInv.Rows.Count; iiCnt++)
            {
                if (!(string.Concat(FlxInv.GetData(iiCnt, 1)) != string.Empty))
                {
                    continue;
                }
                for (int i = 1; i < 7; i++)
                {
                    if (string.Concat(FlxInv.GetData(iiCnt, i)) == string.Empty)
                    {
                        MessageBox.Show((LangArEn == 0) ? "لا يمكن إتمام العملية .. تأكد من تعبئة جميع البيانات المطلوبة" : "We must not be empty value .. Please make sure there are items in the bill.", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        FlxInv.Row = iiCnt;
                        FlxInv.Col = i;
                        FlxInv.Focus();
                        return false;
                    }
                }
                if (VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 7))) == "0")
                {
                    MessageBox.Show((LangArEn == 0) ? "يجب ان لا يكون الكمية فارغة .. يرجى التأكد من وجود الأصناف في الفاتورة" : "We must not be empty value .. Please make sure there are items in the bill.", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    FlxInv.Row = iiCnt;
                    FlxInv.Col = 7;
                    FlxInv.Focus();
                    return false;
                }
                if (_StorePr.Contains(VarGeneral.TString.TEmpty(FlxInv.GetData(iiCnt, 6).ToString() ?? string.Empty)) && State == FormState.New)
                {
                    MessageBox.Show((LangArEn == 0) ? ("تم حظر استخدام المستودع رقم  [ " + VarGeneral.TString.TEmpty(FlxInv.GetData(iiCnt, 6).ToString() ?? string.Empty) + " ] عن هذا المستخدم .. يرجى مراجعة الصلاحيات  ") : (" The use of the repository has been blocked [" + VarGeneral.TString.TEmpty(FlxInv.GetData(iiCnt, 6).ToString() ?? string.Empty) + "] .. please see User Permissions"), VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    FlxInv.Row = iiCnt;
                    FlxInv.Col = 6;
                    FlxInv.Focus();
                    return false;
                }
                if(VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 86)&& ButReturn.Tag.ToString() == "0")

                {
                    MessageBox.Show(" لا يمكن ارجاع البضاعه بدون تحديد فاتورة المبيعات التي تم بيعها فيها ");
                    FlxInv.Row = iiCnt;
                    FlxInv.Col = 1;
                    FlxInv.Focus();
                    return false;

                }
                if (FlxInv.Cols[27].Visible)
                {
                    if (!VarGeneral.TString.ChkStatShow(VarGeneral.UserPassQty, 7) && VarGeneral.CheckDate(string.Concat(FlxInv.GetData(iiCnt, 27))) && string.Concat(FlxInv.GetData(iiCnt, 35)) == string.Empty)
                    {
                        MessageBox.Show((LangArEn == 0) ? "لا يمكن حفظ تاريخ الصلاحية بدون رقم التصنيع .. الرجاء مراجعة صلاحيات المستخدم" : "Can not save the expiration date without Make No .. please see User Permissions", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        FlxInv.Row = iiCnt;
                        FlxInv.Col = 35;
                        FlxInv.Focus();
                        return false;
                    }
                    if (!VarGeneral.TString.ChkStatShow(VarGeneral.UserPassQty, 8) && !VarGeneral.CheckDate(string.Concat(FlxInv.GetData(iiCnt, 27))) && string.Concat(FlxInv.GetData(iiCnt, 35)) != string.Empty)
                    {
                        MessageBox.Show((LangArEn == 0) ? "لا يمكن حفظ رقم التصنيع بدون تاريخ الصلاحية .. الرجاء مراجعة صلاحيات المستخدم" : "Can not save the Make No without expiration date .. please see User Permissions", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        FlxInv.Row = iiCnt;
                        FlxInv.Col = 27;
                        FlxInv.Focus();
                        return false;
                    }
                }
                try
                {
                    if (!VarGeneral.TString.ChkStatShow(VarGeneral.UserPassQty, 11) && !db.CheckIsSalesIvoice(FlxInv.GetData(iiCnt, 1).ToString()))
                    {
                        MessageBox.Show((LangArEn == 0) ? ("لا يمكن ارجاع الصنف الذي في السطر [ " + iiCnt + " ] لانه لم يتم لها اصدار فاتورة مبيعات .. راجع الصلاحيات ") : ("We can not return the product which is in line [" + iiCnt + "] because he is not to issue sales invoice"), VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        FlxInv.Row = iiCnt;
                        FlxInv.Col = 1;
                        FlxInv.Focus();
                        return false;
                    }
                }
                catch
                {
                    MessageBox.Show((LangArEn == 0) ? ("لا يمكن ارجاع الصنف الذي في السطر [ " + iiCnt + " ] لانه لم يتم لها اصدار فاتورة مبيعات .. راجع الصلاحيات ") : ("We can not return the product which is in line [" + iiCnt + "] because he is not to issue sales invoice"), VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    FlxInv.Row = iiCnt;
                    FlxInv.Col = 1;
                    FlxInv.Focus();
                    return false;
                }
                if (CmbInvSide.SelectedIndex <= 0)
                {
                    continue;
                }
                double vC;
                double vk;
                double vt;
                if (State == FormState.Edit)
                {
                    if (CmbInvSide.SelectedIndex == 1)
                    {
                        vC = 0.0;
                        vk = 0.0;
                        vt = 0.0;
                        try
                        {
                            vC = Math.Abs(db.ExecuteQuery<double>(string.Concat("select sum(T_INVDET.RealQty) as x FROM T_INVHED Right JOIN T_INVDET ON T_INVHED.InvHed_ID = T_INVDET.InvId where T_INVHED.InvTyp = 1 and T_INVHED.IfDel = 0 and T_INVDET.ItmNo = '", FlxInv.GetData(iiCnt, 1), "' and T_INVDET.StoreNo = ", int.Parse(VarGeneral.TString.TEmpty(FlxInv.GetData(iiCnt, 6).ToString() ?? string.Empty)), " and T_INVHED.MndNo = ", int.Parse(CmbLegate.SelectedValue.ToString()), " ;"), new object[0]).First() + 0.0);
                        }
                        catch
                        {
                            vC = 0.0;
                        }
                        try
                        {
                            vk = Math.Abs(db.ExecuteQuery<double>(string.Concat("select sum(T_INVDET.RealQty) as x FROM T_INVHED Right JOIN T_INVDET ON T_INVHED.InvHed_ID = T_INVDET.InvId where T_INVHED.InvTyp = 3 and T_INVHED.IfDel = 0 and T_INVHED.InvHed_ID != '", data_this.InvHed_ID, "' and T_INVDET.ItmNo = '", FlxInv.GetData(iiCnt, 1), "' and T_INVDET.StoreNo = ", int.Parse(VarGeneral.TString.TEmpty(FlxInv.GetData(iiCnt, 6).ToString() ?? string.Empty)), " and T_INVHED.MndNo = ", int.Parse(CmbLegate.SelectedValue.ToString()), " ;"), new object[0]).First() + 0.0);
                        }
                        catch
                        {
                            vk = 0.0;
                        }
                        try
                        {
                            for (int c = 1; c < FlxInv.Rows.Count; c++)
                            {
                                if (string.Concat(FlxInv.GetData(c, 1)) != string.Empty && FlxInv.GetData(c, 1).ToString() == FlxInv.GetData(iiCnt, 1).ToString() && FlxInv.GetData(c, 6).ToString() == FlxInv.GetData(iiCnt, 6).ToString())
                                {
                                    vt += double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(c, 12))));
                                }
                            }
                        }
                        catch
                        {
                            vt = 0.0;
                        }
                        vt += vk;
                        if (vC < vt)
                        {
                            MessageBox.Show((LangArEn == 0) ? ("كمية الصنف المدخلة في السطر [ " + iiCnt + " ] أكبر من الكمية الفعلية التي تم بيعها  ") : ("Amount of product was introduced in the line [" + iiCnt + "] is greater than the actual amount, which is owned by the delegate"), VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            FlxInv.Row = iiCnt;
                            FlxInv.Col = 1;
                            FlxInv.Focus();
                            return false;
                        }
                        continue;
                    }
                    vC = 0.0;
                    vk = 0.0;
                    vt = 0.0;
                    try
                    {
                        vC = Math.Abs(db.ExecuteQuery<double>(string.Concat("select sum(T_INVDET.RealQty) as x FROM T_INVHED Right JOIN T_INVDET ON T_INVHED.InvHed_ID = T_INVDET.InvId where T_INVHED.InvTyp = 1 and T_INVHED.IfDel = 0 and T_INVDET.ItmNo = '", FlxInv.GetData(iiCnt, 1), "' and T_INVDET.StoreNo = ", int.Parse(VarGeneral.TString.TEmpty(FlxInv.GetData(iiCnt, 6).ToString() ?? string.Empty)), " and T_INVHED.CusVenNo = '", txtCustNo.Text, "' ;"), new object[0]).First() + 0.0);
                    }
                    catch
                    {
                        vC = 0.0;
                    }
                    try
                    {
                        vk = Math.Abs(db.ExecuteQuery<double>(string.Concat("select sum(T_INVDET.RealQty) as x FROM T_INVHED Right JOIN T_INVDET ON T_INVHED.InvHed_ID = T_INVDET.InvId where T_INVHED.InvTyp = 3 and T_INVHED.IfDel = 0 and T_INVHED.InvHed_ID != '", data_this.InvHed_ID, "' and T_INVDET.ItmNo = '", FlxInv.GetData(iiCnt, 1), "' and T_INVDET.StoreNo = ", int.Parse(VarGeneral.TString.TEmpty(FlxInv.GetData(iiCnt, 6).ToString() ?? string.Empty)), " and T_INVHED.CusVenNo = '", txtCustNo.Text, "' ;"), new object[0]).First() + 0.0);
                    }
                    catch
                    {
                        vk = 0.0;
                    }
                    try
                    {
                        for (int c = 1; c < FlxInv.Rows.Count; c++)
                        {
                            if (string.Concat(FlxInv.GetData(c, 1)) != string.Empty && FlxInv.GetData(c, 1).ToString() == FlxInv.GetData(iiCnt, 1).ToString() && FlxInv.GetData(c, 6).ToString() == FlxInv.GetData(iiCnt, 6).ToString())
                            {
                                vt += double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(c, 12))));
                            }
                        }
                    }
                    catch
                    {
                        vt = 0.0;
                    }
                    vt += vk;
                    if (vC < vt)
                    {
                        MessageBox.Show((LangArEn == 0) ? ("كمية الصنف المدخلة في السطر [ " + iiCnt + " ] أكبر من الكمية الفعلية التي تم بيعها  ") : ("Amount of product was introduced in the line [" + iiCnt + "] is greater than the actual amount, which is owned by the delegate"), VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        FlxInv.Row = iiCnt;
                        FlxInv.Col = 1;
                        FlxInv.Focus();
                        return false;
                    }
                    continue;
                }
                if (CmbInvSide.SelectedIndex == 1)
                {
                    vC = 0.0;
                    vk = 0.0;
                    vt = 0.0;
                    try
                    {
                        vC = Math.Abs(db.ExecuteQuery<double>(string.Concat("select sum(T_INVDET.RealQty) as x FROM T_INVHED Right JOIN T_INVDET ON T_INVHED.InvHed_ID = T_INVDET.InvId where T_INVHED.InvTyp = 1 and T_INVHED.IfDel = 0 and T_INVDET.ItmNo = '", FlxInv.GetData(iiCnt, 1), "' and T_INVDET.StoreNo = ", int.Parse(VarGeneral.TString.TEmpty(FlxInv.GetData(iiCnt, 6).ToString() ?? string.Empty)), " and T_INVHED.MndNo = ", int.Parse(CmbLegate.SelectedValue.ToString()), " ;"), new object[0]).First() + 0.0);
                    }
                    catch
                    {
                        vC = 0.0;
                    }
                    try
                    {
                        vk = Math.Abs(db.ExecuteQuery<double>(string.Concat("select sum(T_INVDET.RealQty) as x FROM T_INVHED Right JOIN T_INVDET ON T_INVHED.InvHed_ID = T_INVDET.InvId where T_INVHED.InvTyp = 3 and T_INVHED.IfDel = 0 and T_INVDET.ItmNo = '", FlxInv.GetData(iiCnt, 1), "' and T_INVDET.StoreNo = ", int.Parse(VarGeneral.TString.TEmpty(FlxInv.GetData(iiCnt, 6).ToString() ?? string.Empty)), " and T_INVHED.MndNo = ", int.Parse(CmbLegate.SelectedValue.ToString()), " ;"), new object[0]).First() + 0.0);
                    }
                    catch
                    {
                        vk = 0.0;
                    }
                    try
                    {
                        for (int c = 1; c < FlxInv.Rows.Count; c++)
                        {
                            if (string.Concat(FlxInv.GetData(c, 1)) != string.Empty && FlxInv.GetData(c, 1).ToString() == FlxInv.GetData(iiCnt, 1).ToString() && FlxInv.GetData(c, 6).ToString() == FlxInv.GetData(iiCnt, 6).ToString())
                            {
                                vt += double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(c, 12))));
                            }
                        }
                    }
                    catch
                    {
                        vt = 0.0;
                    }
                    vt += vk;
                    if (vC < vt)
                    {
                        MessageBox.Show((LangArEn == 0) ? ("كمية الصنف المدخلة في السطر [ " + iiCnt + " ] أكبر من الكمية الفعلية التي تم بيعها  ") : ("Amount of product was introduced in the line [" + iiCnt + "] is greater than the actual amount, which is owned by the delegate"), VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        FlxInv.Row = iiCnt;
                        FlxInv.Col = 1;
                        FlxInv.Focus();
                        return false;
                    }
                    continue;
                }
                vC = 0.0;
                vk = 0.0;
                vt = 0.0;
                try
                {
                    vC = Math.Abs(db.ExecuteQuery<double>(string.Concat("select sum(T_INVDET.RealQty) as x FROM T_INVHED Right JOIN T_INVDET ON T_INVHED.InvHed_ID = T_INVDET.InvId where T_INVHED.InvTyp = 1 and T_INVHED.IfDel = 0 and T_INVDET.ItmNo = '", FlxInv.GetData(iiCnt, 1), "' and T_INVDET.StoreNo = ", int.Parse(VarGeneral.TString.TEmpty(FlxInv.GetData(iiCnt, 6).ToString() ?? string.Empty)), " and T_INVHED.CusVenNo = '", txtCustNo.Text, "' ;"), new object[0]).First() + 0.0);
                }
                catch
                {
                    vC = 0.0;
                }
                try
                {
                    vk = Math.Abs(db.ExecuteQuery<double>(string.Concat("select sum(T_INVDET.RealQty) as x FROM T_INVHED Right JOIN T_INVDET ON T_INVHED.InvHed_ID = T_INVDET.InvId where T_INVHED.InvTyp = 3 and T_INVHED.IfDel = 0 and T_INVDET.ItmNo = '", FlxInv.GetData(iiCnt, 1), "' and T_INVDET.StoreNo = ", int.Parse(VarGeneral.TString.TEmpty(FlxInv.GetData(iiCnt, 6).ToString() ?? string.Empty)), " and T_INVHED.CusVenNo = '", txtCustNo.Text, "' ;"), new object[0]).First() + 0.0);
                }
                catch
                {
                    vk = 0.0;
                }
                try
                {
                    for (int c = 1; c < FlxInv.Rows.Count; c++)
                    {
                        if (string.Concat(FlxInv.GetData(c, 1)) != string.Empty && FlxInv.GetData(c, 1).ToString() == FlxInv.GetData(iiCnt, 1).ToString() && FlxInv.GetData(c, 6).ToString() == FlxInv.GetData(iiCnt, 6).ToString())
                        {
                            vt += double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(c, 12))));
                        }
                    }
                }
                catch
                {
                    vt = 0.0;
                }
                vt += vk;
                if (vC < vt)
                {
                    MessageBox.Show((LangArEn == 0) ? ("كمية الصنف المدخلة في السطر [ " + iiCnt + " ] أكبر من الكمية الفعلية التي تم بيعها  ") : ("Amount of product was introduced in the line [" + iiCnt + "] is greater than the actual amount, which is owned by the delegate"), VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    FlxInv.Row = iiCnt;
                    FlxInv.Col = 1;
                    FlxInv.Focus();
                    return false;
                }
            }
            if (checkBox_Credit.Checked && VarGeneral.SSSLev != "M")
            {
                List<T_AccDef> listAccDef = (from er in db.T_AccDefs
                                             where er.Lev == (int?)4
                                             where er.Sts == (int?)0
                                             where er.AccDef_No == txtCustNo.Text
                                             orderby er.AccDef_No
                                             select er).ToList();
                if (listAccDef.Count() <= 0)
                {
                    MessageBox.Show((LangArEn == 0) ? "لا يمكن إتمام العملية .. وذلك لأن حساب المدين لا يعمل - موقوف " : "You can not complete the operation .. This is because the debtor's account does not work - Suspended", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return false;
                }
                try
                {
                    listAccDef.First().Debit = db.ExecuteQuery<double>(" select sum(T_GDDET.gdValue) from T_GDDET INNER JOIN  T_GDHEAD ON T_GDDET.gdID = T_GDHEAD.gdhead_ID where T_GDHEAD.gdLok = 0 and T_GDDET.gdValue > 0 and T_GDDET.AccNo ='" + listAccDef.First().AccDef_No + "'", new object[0]).FirstOrDefault();
                }
                catch
                {
                    listAccDef.First().Debit = 0.0;
                }
                try
                {
                    listAccDef.First().Credit = Math.Abs(db.ExecuteQuery<double>(" select sum(T_GDDET.gdValue) from T_GDDET INNER JOIN  T_GDHEAD ON T_GDDET.gdID = T_GDHEAD.gdhead_ID where T_GDHEAD.gdLok = 0 and T_GDDET.gdValue < 0 and T_GDDET.AccNo ='" + listAccDef.First().AccDef_No + "'", new object[0]).FirstOrDefault());
                }
                catch
                {
                    listAccDef.First().Credit = 0.0;
                }
                try
                {
                    listAccDef.First().Balance = db.ExecuteQuery<double>(" select sum(T_GDDET.gdValue) from T_GDDET INNER JOIN  T_GDHEAD ON T_GDDET.gdID = T_GDHEAD.gdhead_ID where T_GDHEAD.gdLok = 0 and T_GDDET.AccNo ='" + listAccDef.First().AccDef_No + "'", new object[0]).FirstOrDefault();
                }
                catch
                {
                    listAccDef.First().Balance = 0.0;
                }
                T_AccDef _AccDef = listAccDef[0];
                if (_AccDef.Balance.Value + doubleInput_CreditLoc.Value >= _AccDef.MaxLemt.Value && (_AccDef.MaxLemt.Value != 0.0 || _AccDef.MaxLemt.Value != 0.0 || _AccDef.MaxLemt.Value != 0.0))
                {
                    MessageBox.Show((LangArEn == 0) ? "لا يمكن إتمام العملية .. وذلك لأن حساب العميل / المورد تخطى الحد الأعلى " : "You can not complete the operation .. This is because the upper limit of the customer's / Supplier's account", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return false;
                }
            }
            if (_InvSetting.InvSetting.Substring(1, 1) == "1" && VarGeneral.SSSTyp != 0)
            {
                if (txtPaymentLoc.Value > 0.0 && string.IsNullOrEmpty(txtCredit1.Text))
                {
                    MessageBox.Show((LangArEn == 0) ? "لا يمكن إتمام العملية .. تأكد من صحة الطرف الدائن للقيد النقدي .. راجع تهيئة النظام " : "You can not complete the operation .. Make sure the creditor under the party .. see the system configuration", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    superTabControl_Info.SelectedTabIndex = 1;
                    return false;
                }
                if (txtPaymentLoc.Value > 0.0 && string.IsNullOrEmpty(txtDebit1.Text))
                {
                    MessageBox.Show((LangArEn == 0) ? "لا يمكن إتمام العملية .. تأكد من صحة الطرف المدين للقيد النقدي .. راجع تهيئة النظام " : "You can not complete the operation .. Make sure the debtor under the party .. see the system configuration", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    superTabControl_Info.SelectedTabIndex = 1;
                    return false;
                }
                if (doubleInput_CreditLoc.Value > 0.0 && string.IsNullOrEmpty(txtCredit2.Text))
                {
                    MessageBox.Show((LangArEn == 0) ? "لا يمكن إتمام العملية .. تأكد من صحة الطرف الدائن للقيد الآجل .. راجع تهيئة النظام " : "You can not complete the operation .. Make sure the creditor under the party .. see the system configuration", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    superTabControl_Info.SelectedTabIndex = 1;
                    return false;
                }
                if (doubleInput_CreditLoc.Value > 0.0 && string.IsNullOrEmpty(txtDebit2.Text))
                {
                    MessageBox.Show((LangArEn == 0) ? "لا يمكن إتمام العملية .. تأكد من صحة الطرف المدين للقيد الآجل .. راجع تهيئة النظام " : "You can not complete the operation .. Make sure the debtor under the party .. see the system configuration", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    superTabControl_Info.SelectedTabIndex = 1;
                    return false;
                }
                if (doubleInput_NetWorkLoc.Value > 0.0 && string.IsNullOrEmpty(txtCredit3.Text))
                {
                    MessageBox.Show((LangArEn == 0) ? "لا يمكن إتمام العملية .. تأكد من صحة الطرف الدائن للقيد الشبكة .. راجع تهيئة النظام " : "You can not complete the operation .. Make sure the creditor under the party .. see the system configuration", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    superTabControl_Info.SelectedTabIndex = 1;
                    return false;
                }
                if (doubleInput_NetWorkLoc.Value > 0.0 && string.IsNullOrEmpty(txtDebit3.Text))
                {
                    MessageBox.Show((LangArEn == 0) ? "لا يمكن إتمام العملية .. تأكد من صحة الطرف المدين للقيد الشبكة .. راجع تهيئة النظام " : "You can not complete the operation .. Make sure the debtor under the party .. see the system configuration", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    superTabControl_Info.SelectedTabIndex = 1;
                    return false;
                }
                try
                {
                    if (txtPaymentLoc.Value > 0.0)
                    {
                        List<T_AccDef> listAccDef = (from er in db.T_AccDefs
                                                     where er.Lev == (int?)4
                                                     where er.Sts == (int?)0
                                                     where er.AccDef_No == txtDebit1.Tag.ToString()
                                                     orderby er.AccDef_No
                                                     select er).ToList();
                        if (listAccDef.Count() <= 0)
                        {
                            MessageBox.Show((LangArEn == 0) ? "لا يمكن إتمام العملية .. وذلك لأن حساب المدين لا يعمل - موقوف " : "You can not complete the operation .. This is because the debtor's account does not work - Suspended", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            return false;
                        }
                        try
                        {
                            listAccDef.First().Debit = db.ExecuteQuery<double>(" select sum(T_GDDET.gdValue) from T_GDDET INNER JOIN  T_GDHEAD ON T_GDDET.gdID = T_GDHEAD.gdhead_ID where T_GDHEAD.gdLok = 0 and T_GDDET.gdValue > 0 and T_GDDET.AccNo ='" + listAccDef.First().AccDef_No + "'", new object[0]).FirstOrDefault();
                        }
                        catch
                        {
                            listAccDef.First().Debit = 0.0;
                        }
                        try
                        {
                            listAccDef.First().Credit = Math.Abs(db.ExecuteQuery<double>(" select sum(T_GDDET.gdValue) from T_GDDET INNER JOIN  T_GDHEAD ON T_GDDET.gdID = T_GDHEAD.gdhead_ID where T_GDHEAD.gdLok = 0 and T_GDDET.gdValue < 0 and T_GDDET.AccNo ='" + listAccDef.First().AccDef_No + "'", new object[0]).FirstOrDefault());
                        }
                        catch
                        {
                            listAccDef.First().Credit = 0.0;
                        }
                        try
                        {
                            listAccDef.First().Balance = db.ExecuteQuery<double>(" select sum(T_GDDET.gdValue) from T_GDDET INNER JOIN  T_GDHEAD ON T_GDDET.gdID = T_GDHEAD.gdhead_ID where T_GDHEAD.gdLok = 0 and T_GDDET.AccNo ='" + listAccDef.First().AccDef_No + "'", new object[0]).FirstOrDefault();
                        }
                        catch
                        {
                            listAccDef.First().Balance = 0.0;
                        }
                        T_AccDef _AccDef = listAccDef[0];
                        if (_AccDef.Balance.Value + txtPaymentLoc.Value >= _AccDef.MaxLemt.Value && (_AccDef.MaxLemt.Value != 0.0 || _AccDef.MaxLemt.Value != 0.0 || _AccDef.MaxLemt.Value != 0.0))
                        {
                            MessageBox.Show((LangArEn == 0) ? "لا يمكن إتمام العملية .. وذلك لأن حساب العميل / المورد تخطى الحد الأعلى " : "You can not complete the operation .. This is because the upper limit of the customer's / Supplier's account", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            return false;
                        }
                    }
                }
                catch
                {
                }
                try
                {
                    if (doubleInput_CreditLoc.Value > 0.0)
                    {
                        List<T_AccDef> listAccDef = (from er in db.T_AccDefs
                                                     where er.Lev == (int?)4
                                                     where er.Sts == (int?)0
                                                     where er.AccDef_No == txtDebit2.Tag.ToString()
                                                     orderby er.AccDef_No
                                                     select er).ToList();
                        if (listAccDef.Count() <= 0)
                        {
                            MessageBox.Show((LangArEn == 0) ? "لا يمكن إتمام العملية .. وذلك لأن حساب المدين لا يعمل - موقوف " : "You can not complete the operation .. This is because the debtor's account does not work - Suspended", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            return false;
                        }
                        try
                        {
                            listAccDef.First().Debit = db.ExecuteQuery<double>(" select sum(T_GDDET.gdValue) from T_GDDET INNER JOIN  T_GDHEAD ON T_GDDET.gdID = T_GDHEAD.gdhead_ID where T_GDHEAD.gdLok = 0 and T_GDDET.gdValue > 0 and T_GDDET.AccNo ='" + listAccDef.First().AccDef_No + "'", new object[0]).FirstOrDefault();
                        }
                        catch
                        {
                            listAccDef.First().Debit = 0.0;
                        }
                        try
                        {
                            listAccDef.First().Credit = Math.Abs(db.ExecuteQuery<double>(" select sum(T_GDDET.gdValue) from T_GDDET INNER JOIN  T_GDHEAD ON T_GDDET.gdID = T_GDHEAD.gdhead_ID where T_GDHEAD.gdLok = 0 and T_GDDET.gdValue < 0 and T_GDDET.AccNo ='" + listAccDef.First().AccDef_No + "'", new object[0]).FirstOrDefault());
                        }
                        catch
                        {
                            listAccDef.First().Credit = 0.0;
                        }
                        try
                        {
                            listAccDef.First().Balance = db.ExecuteQuery<double>(" select sum(T_GDDET.gdValue) from T_GDDET INNER JOIN  T_GDHEAD ON T_GDDET.gdID = T_GDHEAD.gdhead_ID where T_GDHEAD.gdLok = 0 and T_GDDET.AccNo ='" + listAccDef.First().AccDef_No + "'", new object[0]).FirstOrDefault();
                        }
                        catch
                        {
                            listAccDef.First().Balance = 0.0;
                        }
                        T_AccDef _AccDef = listAccDef[0];
                        if (_AccDef.Balance.Value + doubleInput_CreditLoc.Value >= _AccDef.MaxLemt.Value && (_AccDef.MaxLemt.Value != 0.0 || _AccDef.MaxLemt.Value != 0.0 || _AccDef.MaxLemt.Value != 0.0))
                        {
                            MessageBox.Show((LangArEn == 0) ? "لا يمكن إتمام العملية .. وذلك لأن حساب العميل / المورد تخطى الحد الأعلى " : "You can not complete the operation .. This is because the upper limit of the customer's / Supplier's account", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            return false;
                        }
                    }
                }
                catch
                {
                }
                try
                {
                    if (doubleInput_NetWorkLoc.Value > 0.0)
                    {
                        List<T_AccDef> listAccDef = (from er in db.T_AccDefs
                                                     where er.Lev == (int?)4
                                                     where er.Sts == (int?)0
                                                     where er.AccDef_No == txtDebit3.Tag.ToString()
                                                     orderby er.AccDef_No
                                                     select er).ToList();
                        if (listAccDef.Count() <= 0)
                        {
                            MessageBox.Show((LangArEn == 0) ? "لا يمكن إتمام العملية .. وذلك لأن حساب المدين لا يعمل - موقوف " : "You can not complete the operation .. This is because the debtor's account does not work - Suspended", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            return false;
                        }
                        try
                        {
                            listAccDef.First().Debit = db.ExecuteQuery<double>(" select sum(T_GDDET.gdValue) from T_GDDET INNER JOIN  T_GDHEAD ON T_GDDET.gdID = T_GDHEAD.gdhead_ID where T_GDHEAD.gdLok = 0 and T_GDDET.gdValue > 0 and T_GDDET.AccNo ='" + listAccDef.First().AccDef_No + "'", new object[0]).FirstOrDefault();
                        }
                        catch
                        {
                            listAccDef.First().Debit = 0.0;
                        }
                        try
                        {
                            listAccDef.First().Credit = Math.Abs(db.ExecuteQuery<double>(" select sum(T_GDDET.gdValue) from T_GDDET INNER JOIN  T_GDHEAD ON T_GDDET.gdID = T_GDHEAD.gdhead_ID where T_GDHEAD.gdLok = 0 and T_GDDET.gdValue < 0 and T_GDDET.AccNo ='" + listAccDef.First().AccDef_No + "'", new object[0]).FirstOrDefault());
                        }
                        catch
                        {
                            listAccDef.First().Credit = 0.0;
                        }
                        try
                        {
                            listAccDef.First().Balance = db.ExecuteQuery<double>(" select sum(T_GDDET.gdValue) from T_GDDET INNER JOIN  T_GDHEAD ON T_GDDET.gdID = T_GDHEAD.gdhead_ID where T_GDHEAD.gdLok = 0 and T_GDDET.AccNo ='" + listAccDef.First().AccDef_No + "'", new object[0]).FirstOrDefault();
                        }
                        catch
                        {
                            listAccDef.First().Balance = 0.0;
                        }
                        T_AccDef _AccDef = listAccDef[0];
                        if (_AccDef.Balance.Value + doubleInput_NetWorkLoc.Value >= _AccDef.MaxLemt.Value && (_AccDef.MaxLemt.Value != 0.0 || _AccDef.MaxLemt.Value != 0.0 || _AccDef.MaxLemt.Value != 0.0))
                        {
                            MessageBox.Show((LangArEn == 0) ? "لا يمكن إتمام العملية .. وذلك لأن حساب العميل / المورد تخطى الحد الأعلى " : "You can not complete the operation .. This is because the upper limit of the customer's / Supplier's account", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            return false;
                        }
                    }
                }
                catch
                {
                }
            }
            if (checkBox_CostGaidTax.Checked && txtTotTax.Value <= 0.0)
            {
                MessageBox.Show((LangArEn == 0) ? "لايمكن انشاء سند محاسبي بقيمة الضريبة واجمالي الضريبة يساوي صفر" : "You can not set up an accounting support tax and the total tax is equal to zero.", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                superTabControl_Info.SelectedTabIndex = 5;
                return false;
            }
            if (checkBox_GaidDis.Checked && txtTotDis.Value <= 0.0)
            {
                MessageBox.Show((LangArEn == 0) ? "لايمكن انشاء سند محاسبي بقيمة الخصم واجمالي الخصم يساوي صفر" : "You can not set up an accounting support Discount and the total Discount is equal to zero.", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                superTabControl_Info.SelectedTabIndex = 5;
                return false;
            }
            if (!VarGeneral.CheckDate(txtGDate.Text))
            {
                txtGDate.Text = n.FormatGreg(VarGeneral.Gdate, "yyyy/MM/dd");
            }
            if (!VarGeneral.CheckDate(txtHDate.Text))
            {
                txtHDate.Text = n.FormatHijri(VarGeneral.Hdate, "yyyy/MM/dd");
            }
            if (VarGeneral.SSSLev != "M" && State == FormState.New)
            {
                T_AccDef q = db.StockAccDefWithOutBalance(txtCustNo.Text);
                if (q.StopInvTyp == 1)
                {
                    if (checkBox_Chash.Checked)
                    {
                        MessageBox.Show((LangArEn == 0) ? "لا يمكن إتمام العملية .. وذلك لأن حساب العميل غير مصرح له البيع بالنقدي " : "Can not complete the operation .. This is because the customer's account is not authorized to Cash Sales", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        return false;
                    }
                }
                else if (q.StopInvTyp == 2 && checkBox_Credit.Checked)
                {
                    MessageBox.Show((LangArEn == 0) ? "لا يمكن إتمام العملية .. وذلك لأن حساب العميل غير مصرح له البيع بالآجل " : "Can not complete the operation .. This is because the customer's account is not authorized to Future Sales", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return false;
                }
            }
            try
            {
                if (VarGeneral.CheckDate(VarGeneral.Settings_Sys.AccCusDes.Trim()) && VarGeneral.CheckDate(VarGeneral.Settings_Sys.AccSupDes.Trim()))
                {
                    if (Convert.ToDateTime(n.FormatGreg(txtGDate.Text, "yyyy/MM/dd")) <= Convert.ToDateTime(VarGeneral.Settings_Sys.AccCusDes) && Convert.ToDateTime(n.FormatGreg(txtGDate.Text, "yyyy/MM/dd")) >= Convert.ToDateTime(VarGeneral.Settings_Sys.AccSupDes))
                    {
                        return true;
                    }
                    MessageBox.Show((LangArEn == 0) ? "لا يمكن إتمام العملية .. لقد تخطيت السنة المالية المحدد للنظام \n يرجى التواصل مع الإدارة لإتمام عملية الإقفال السنوية " : "We can not complete the operation .. have you skip the fiscal year specified for the system", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return false;
                }
            }
            catch
            {
                MessageBox.Show((LangArEn == 0) ? "لا يمكن إتمام العملية .. لقد تخطيت السنة المالية المحدد للنظام \n يرجى التواصل مع الإدارة لإتمام عملية الإقفال السنوية " : "We can not complete the operation .. have you skip the fiscal year specified for the system", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }
            if (false)
            {
                Environment.Exit(0);
                return false;
            }
            return true;
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
                            try
                            {
                                if (Convert.ToDateTime(n.GregToHijri(hKeyNew.GetValue("vBackup_New").ToString(), "yyyy/MM/dd")) < Convert.ToDateTime(n.FormatHijri(txtHDate.Text, "yyyy/MM/dd")))
                                {
                                    MessageBox.Show((LangArEn == 0) ? "لا يمكن إتمام العملية .. لقد تخطيت السنة المالية المحدد للنظام \n يرجى التواصل مع الإدارة لللإشتراك في خدمات النسخة " : "We can not complete the operation .. have you skip the fiscal year specified for the system", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                    return false;
                                }
                            }
                            catch
                            {
                                if (Convert.ToDateTime(n.FormatGreg(hKeyNew.GetValue("vBackup_New").ToString(), "yyyy/MM/dd")) < Convert.ToDateTime(n.FormatGreg(txtGDate.Text, "yyyy/MM/dd")))
                                {
                                    MessageBox.Show((LangArEn == 0) ? "لا يمكن إتمام العملية .. لقد تخطيت السنة المالية المحدد للنظام \n يرجى التواصل مع الإدارة لللإشتراك في خدمات النسخة " : "We can not complete the operation .. have you skip the fiscal year specified for the system", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                    return false;
                                }
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
        private bool SaveData()
        {
            if (State == FormState.New)
            {
                dbInstance = null;
            }
            if (!ValidData())
            {
                return false;
            }
            string Acc0 = _GdAuto.Acc0.ToString();
            string AccCrdt = string.Empty;
            string AccDbt = string.Empty;
            string AccCrdt_Credit = string.Empty;
            string AccDbt_Credit = string.Empty;
            string AccCrdt_NewtWork = string.Empty;
            string AccDbt_NetWork = string.Empty;
            string AccCrdt_Cost_Tax = string.Empty;
            string AccDbt_Cost_Tax = string.Empty;
            try
            {
                AccCrdt_Cost_Tax = txtCredit5.Tag.ToString();
            }
            catch
            {
                AccCrdt_Cost_Tax = string.Empty;
            }
            try
            {
                AccDbt_Cost_Tax = txtDebit5.Tag.ToString();
            }
            catch
            {
                AccDbt_Cost_Tax = string.Empty;
            }
            if (checkBox_CostGaidTax.Checked && (string.IsNullOrEmpty(AccDbt_Cost_Tax) || string.IsNullOrEmpty(AccCrdt_Cost_Tax) || string.IsNullOrEmpty(txtDebit5.Text) || string.IsNullOrEmpty(txtCredit5.Text)))
            {
                MessageBox.Show((LangArEn == 0) ? "لا يمكن إتمام العملية .. تأكد من صحة حسابات الدائن والمدين الخاص بقيمة الضريبة " : "You can not complete the operation ..verify the accounts of the private creditor and the debtor for Tax Value", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                superTabControl_Info.SelectedTabIndex = 5;
                return false;
            }
            string AccCrdt_Cost_Dis = string.Empty;
            string AccDbt_Cost_Dis = string.Empty;
            try
            {
                AccCrdt_Cost_Dis = txtCredit6.Tag.ToString();
            }
            catch
            {
                AccCrdt_Cost_Dis = string.Empty;
            }
            try
            {
                AccDbt_Cost_Dis = txtDebit6.Tag.ToString();
            }
            catch
            {
                AccDbt_Cost_Dis = string.Empty;
            }
            if (checkBox_GaidDis.Checked && (string.IsNullOrEmpty(AccDbt_Cost_Dis) || string.IsNullOrEmpty(AccCrdt_Cost_Dis) || string.IsNullOrEmpty(txtDebit6.Text) || string.IsNullOrEmpty(txtCredit6.Text)))
            {
                MessageBox.Show((LangArEn == 0) ? "لا يمكن إتمام العملية .. تأكد من صحة حسابات الدائن والمدين الخاص بقيمة الخصم " : "You can not complete the operation ..verify the accounts of the private creditor and the debtor for Discount Value", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                superTabControl_Info.SelectedTabIndex = 5;
                return false;
            }
            if ((_InvSetting.InvSetting.Substring(1, 1) == "1" || VarGeneral.SSSTyp == 0) && VarGeneral.SSSLev != "M")
            {
                if (doubleInput_CreditLoc.Value > 0.0)
                {
                    AccCrdt_Credit = txtCredit2.Tag.ToString();
                    AccDbt_Credit = txtDebit2.Tag.ToString();
                }
                if (doubleInput_NetWorkLoc.Value > 0.0)
                {
                    AccCrdt_NewtWork = txtCredit3.Tag.ToString();
                    AccDbt_NetWork = txtDebit3.Tag.ToString();
                }
                if (txtPaymentLoc.Value > 0.0)
                {
                    AccCrdt = txtCredit1.Tag.ToString();
                    AccDbt = txtDebit1.Tag.ToString();
                }
                if (AccCrdt == string.Empty && txtPaymentLoc.Value > 0.0)
                {
                    MessageBox.Show((LangArEn == 0) ? "لا يمكن إتمام العملية .. تأكد من صحة الطرف الدائن للقيد النقدي .. راجع تهيئة النظام " : "You can not complete the operation .. Make sure the creditor under the party .. see the system configuration", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    superTabControl_Info.SelectedTabIndex = 1;
                    return false;
                }
                if (AccDbt == string.Empty && txtPaymentLoc.Value > 0.0)
                {
                    MessageBox.Show((LangArEn == 0) ? "لا يمكن إتمام العملية .. تأكد من صحة الطرف المدين للقيد النقدي .. راجع تهيئة النظام " : "You can not complete the operation .. Make sure the debtor under the party .. see the system configuration", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    superTabControl_Info.SelectedTabIndex = 1;
                    return false;
                }
                if (AccCrdt_Credit == string.Empty && doubleInput_CreditLoc.Value > 0.0)
                {
                    MessageBox.Show((LangArEn == 0) ? "لا يمكن إتمام العملية .. تأكد من صحة الطرف الدائن للقيد الآجل .. راجع تهيئة النظام " : "You can not complete the operation .. Make sure the creditor under the party .. see the system configuration", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    superTabControl_Info.SelectedTabIndex = 1;
                    return false;
                }
                if (AccDbt_Credit == string.Empty && doubleInput_CreditLoc.Value > 0.0)
                {
                    MessageBox.Show((LangArEn == 0) ? "لا يمكن إتمام العملية .. تأكد من صحة الطرف المدين للقيد الآجل .. راجع تهيئة النظام " : "You can not complete the operation .. Make sure the debtor under the party .. see the system configuration", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    superTabControl_Info.SelectedTabIndex = 1;
                    return false;
                }
                if (AccCrdt_NewtWork == string.Empty && doubleInput_NetWorkLoc.Value > 0.0)
                {
                    MessageBox.Show((LangArEn == 0) ? "لا يمكن إتمام العملية .. تأكد من صحة الطرف الدائن للقيد (شيك - شبكة).. راجع تهيئة النظام " : "You can not complete the operation .. Make sure the creditor under the party .. see the system configuration", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    superTabControl_Info.SelectedTabIndex = 1;
                    return false;
                }
                if (AccDbt_NetWork == string.Empty && doubleInput_NetWorkLoc.Value > 0.0)
                {
                    MessageBox.Show((LangArEn == 0) ? "لا يمكن إتمام العملية .. تأكد من صحة الطرف المدين للقيد (شيك - شبكة).. راجع تهيئة النظام " : "You can not complete the operation .. Make sure the debtor under the party .. see the system configuration", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    superTabControl_Info.SelectedTabIndex = 1;
                    return false;
                }
            }
            IDatabase db_ = Database.GetDatabase(VarGeneral.BranchCS);
            if (data_this.TaxGaidID.HasValue && !checkBox_CostGaidTax.Checked)
            {
                db_.StartTransaction();
                db_.ClearParameters();
                db_.AddParameter("gdhead_ID", DbType.Int32, _GdHeadCostTax.gdhead_ID);
                db_.ExecuteNonQueryWithoutCommit(storedProcedure: true, "S_T_GDHEAD_DELETE");
                db_.EndTransaction();
                data_this.TaxGaidID = null;
            }
            if (data_this.DisGaidID1.HasValue && !checkBox_GaidDis.Checked)
            {
                db_.StartTransaction();
                db_.ClearParameters();
                db_.AddParameter("gdhead_ID", DbType.Int32, _GdHeadCostDis.gdhead_ID);
                db_.ExecuteNonQueryWithoutCommit(storedProcedure: true, "S_T_GDHEAD_DELETE");
                db_.EndTransaction();
                data_this.DisGaidID1 = null;
            }
            try
            {
                bool mndExtrnal = false;
                int mndNo = 0;
                try
                {
                    mndExtrnal = ((CmbInvSide.SelectedIndex > 0) ? true : false);
                }
                catch
                {
                    mndExtrnal = false;
                }
                try
                {
                    mndNo = ((CmbInvSide.SelectedIndex == 1) ? data_this.MndNo.Value : ((CmbInvSide.SelectedIndex > 1) ? int.Parse(txtCustNo.Text) : 0));
                }
                catch
                {
                    mndNo = 0;
                }
                using (Stock_DataDataContext stock_DataDataContext = new Stock_DataDataContext(VarGeneral.BranchCS))
                {
                    IDatabase dbX = Database.GetDatabase(VarGeneral.BranchCS);
                    int i;
                    for (i = 0; i < ItemDetRemoved.Count; i++)
                    {
                        try
                        {
                            List<T_SINVDET> q2 = stock_DataDataContext.T_SINVDETs.Where((T_SINVDET t) => t.SInvId == (int?)ItemDetRemoved[i]).ToList();
                            for (int iicnt = 0; iicnt < q2.Count; iicnt++)
                            {
                                dbX.ClearParameters();
                                dbX.AddParameter("SInvDet_ID", DbType.Int32, q2[iicnt].SInvDet_ID);
                                try
                                {
                                    if (mndExtrnal && mndNo > 0 && !string.IsNullOrEmpty(mndNo.ToString()))
                                    {
                                        if (CmbInvSide.SelectedIndex == 1)
                                        {
                                            stock_DataDataContext.ExecuteCommand("  UPDATE T_StoreMnd SET T_StoreMnd.stkQty = T_StoreMnd.stkQty - abs(" + q2[iicnt].SRealQty.Value + ")\r\n\t\t                                          FROM T_Items INNER JOIN T_StoreMnd ON T_Items.Itm_No = T_StoreMnd.itmNo INNER JOIN T_SINVDET ON T_Items.Itm_No = T_SINVDET.SItmNo\r\n\t\t                                          where SInvDet_ID = " + q2[iicnt].SInvDet_ID + " and T_SINVDET.SItmTyp <> 3 and T_StoreMnd.storeNo = " + q2[iicnt].SStoreNo.Value + " and T_StoreMnd.MndNo = " + mndNo + " ;");
                                        }
                                        else
                                        {
                                            stock_DataDataContext.ExecuteCommand("  UPDATE T_StoreMnd SET T_StoreMnd.stkQty = T_StoreMnd.stkQty - abs(" + q2[iicnt].SRealQty.Value + ")\r\n\t\t                                          FROM T_Items INNER JOIN T_StoreMnd ON T_Items.Itm_No = T_StoreMnd.itmNo INNER JOIN T_SINVDET ON T_Items.Itm_No = T_SINVDET.SItmNo\r\n\t\t                                          where SInvDet_ID = " + q2[iicnt].SInvDet_ID + " and T_SINVDET.SItmTyp <> 3 and T_StoreMnd.storeNo = " + q2[iicnt].SStoreNo.Value + " and T_StoreMnd.CusVenNo = '" + mndNo + "' ;");
                                        }
                                    }
                                }
                                catch
                                {
                                }
                                dbX.ExecuteNonQuery(storedProcedure: true, "S_T_SINVDET_DELETE");
                            }
                        }
                        catch (Exception ex8)
                        {
                            VarGeneral.DebLog.writeLog("dbX:", ex8, enable: true);
                            return false;
                        }
                    }
                }
                GetData();
                if (State == FormState.New)
                {
                    try
                    {
                        GetInvSetting();
                        textBox_ID.TextChanged -= textBox_ID_TextChanged;
                        T_INVHED newData = db.StockInvHead(VarGeneral.InvTyp, data_this.InvNo);
                        if (!string.IsNullOrEmpty(newData.InvNo) || newData.InvHed_ID > 0)
                        {
                            string max = string.Empty;
                            dbInstance = null;
                            max = db.MaxInvheadNo.ToString();
                            MessageBox.Show("الرمز مستخدم من قبل.\n سيتم الحفظ برقم جديد [" + max + "]", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            textBox_ID.Text = max ?? string.Empty;
                            data_this.InvNo = max ?? string.Empty;
                        }
                        textBox_ID.TextChanged += textBox_ID_TextChanged;
                        data_this.IfRet = 0;
                        data_this.DATE_CREATED = DateTime.Now;
                        data_this.SalsManNo = VarGeneral.UserNumber;
                        data_this.UserNew = VarGeneral.UserNumber;
                        data_this.SalsManNam = string.Empty;
                        IDatabase dbHead = Database.GetDatabase(VarGeneral.BranchCS);
                        dbHead.ClearParameters();
                        dbHead.AddOutParameter("InvHed_ID", DbType.Int32);
                        dbHead.AddParameter("InvId", DbType.Double, data_this.InvId);
                        dbHead.AddParameter("InvNo", DbType.String, data_this.InvNo);
                        dbHead.AddParameter("InvTyp", DbType.Int32, data_this.InvTyp);
                        dbHead.AddParameter("InvCashPay", DbType.Int32, data_this.InvCashPay);
                        dbHead.AddParameter("CusVenNo", DbType.String, data_this.CusVenNo);
                        dbHead.AddParameter("CusVenNm", DbType.String, data_this.CusVenNm);
                        dbHead.AddParameter("CusVenAdd", DbType.String, data_this.CusVenAdd);
                        dbHead.AddParameter("CusVenTel", DbType.String, data_this.CusVenTel);
                        dbHead.AddParameter("Remark", DbType.String, data_this.Remark);
                        dbHead.AddParameter("HDat", DbType.String, data_this.HDat);
                        dbHead.AddParameter("GDat", DbType.String, data_this.GDat);
                        dbHead.AddParameter("MndNo", DbType.Int32, data_this.MndNo);
                        dbHead.AddParameter("SalsManNo", DbType.String, data_this.SalsManNo);
                        dbHead.AddParameter("SalsManNam", DbType.String, data_this.SalsManNam);
                        dbHead.AddParameter("InvTot", DbType.Double, data_this.InvTot);
                        dbHead.AddParameter("InvTotLocCur", DbType.Double, data_this.InvTotLocCur);
                        dbHead.AddParameter("InvDisPrs", DbType.Double, data_this.InvDisPrs);
                        dbHead.AddParameter("InvDisVal", DbType.Double, data_this.InvDisVal);
                        dbHead.AddParameter("InvDisValLocCur", DbType.Double, data_this.InvDisValLocCur);
                        dbHead.AddParameter("InvNet", DbType.Double, data_this.InvNet);
                        dbHead.AddParameter("InvNetLocCur", DbType.Double, data_this.InvNetLocCur);
                        dbHead.AddParameter("CashPay", DbType.Double, data_this.CashPay);
                        dbHead.AddParameter("CashPayLocCur", DbType.Double, data_this.CashPayLocCur);
                        dbHead.AddParameter("IfRet", DbType.Int32, data_this.IfRet);
                        dbHead.AddParameter("GadeNo", DbType.Double, data_this.GadeNo);
                        dbHead.AddParameter("GadeId", DbType.Double, data_this.GadeId);
                        dbHead.AddParameter("IfDel", DbType.Int32, data_this.IfDel);
                        dbHead.AddParameter("RetNo", DbType.String, data_this.RetNo);
                        dbHead.AddParameter("RetId", DbType.Double, data_this.RetId);
                        dbHead.AddParameter("InvCstNo", DbType.Int32, data_this.InvCstNo);
                        dbHead.AddParameter("InvCashPayNm", DbType.String, data_this.InvCashPayNm);
                        dbHead.AddParameter("RefNo", DbType.String, data_this.RefNo);
                        dbHead.AddParameter("InvCost", DbType.Int32, data_this.InvCost);
                        dbHead.AddParameter("EstDat", DbType.String, data_this.EstDat);
                        dbHead.AddParameter("CustPri", DbType.Int32, data_this.CustPri);
                        dbHead.AddParameter("ArbTaf", DbType.String, data_this.ArbTaf);
                        dbHead.AddParameter("CurTyp", DbType.Int32, data_this.CurTyp);
                        dbHead.AddParameter("InvCash", DbType.String, data_this.InvCash);
                        dbHead.AddParameter("ToStore", DbType.String, data_this.ToStore);
                        dbHead.AddParameter("ToStoreNm", DbType.String, data_this.ToStoreNm);
                        dbHead.AddParameter("InvQty", DbType.Double, data_this.InvQty);
                        dbHead.AddParameter("EngTaf", DbType.String, data_this.EngTaf);
                        dbHead.AddParameter("IfTrans", DbType.Int32, data_this.IfTrans);
                        dbHead.AddParameter("CustRep", DbType.Double, data_this.CustRep);
                        dbHead.AddParameter("CustNet", DbType.Double, data_this.CustNet);
                        dbHead.AddParameter("InvWight_T", DbType.Double, data_this.InvWight_T);
                        dbHead.AddParameter("IfPrint", DbType.Int32, data_this.IfPrint);
                        dbHead.AddParameter("LTim", DbType.String, data_this.LTim);
                        dbHead.AddParameter("CREATED_BY", DbType.String, data_this.CREATED_BY);
                        dbHead.AddParameter("DATE_CREATED", DbType.DateTime, data_this.DATE_CREATED);
                        dbHead.AddParameter("MODIFIED_BY", DbType.String, data_this.MODIFIED_BY);
                        dbHead.AddParameter("DATE_MODIFIED", DbType.DateTime, data_this.DATE_MODIFIED);
                        dbHead.AddParameter("CreditPay", DbType.Double, data_this.CreditPay);
                        dbHead.AddParameter("CreditPayLocCur", DbType.Double, data_this.CreditPayLocCur);
                        dbHead.AddParameter("NetworkPay", DbType.Double, data_this.NetworkPay);
                        dbHead.AddParameter("NetworkPayLocCur", DbType.Double, data_this.NetworkPayLocCur);
                        dbHead.AddParameter("CommMnd_Inv", DbType.Double, data_this.CommMnd_Inv);
                        dbHead.AddParameter("MndExtrnal", DbType.Boolean, data_this.MndExtrnal);
                        dbHead.AddParameter("CompanyID", DbType.Int32, data_this.CompanyID);
                        dbHead.AddParameter("InvAddCost", DbType.Double, data_this.InvAddCost);
                        dbHead.AddParameter("InvAddCostLoc", DbType.Double, data_this.InvAddCostLoc);
                        dbHead.AddParameter("InvAddCostExtrnal", DbType.Double, data_this.InvAddCostExtrnal);
                        dbHead.AddParameter("InvAddCostExtrnalLoc", DbType.Double, data_this.InvAddCostExtrnalLoc);
                        dbHead.AddParameter("IsExtrnalGaid", DbType.Boolean, data_this.IsExtrnalGaid);
                        dbHead.AddParameter("ExtrnalCostGaidID", DbType.Double, data_this.ExtrnalCostGaidID);
                        dbHead.AddParameter("Puyaid", DbType.Double, data_this.Puyaid);
                        dbHead.AddParameter("Remming", DbType.Double, data_this.Remming);
                        dbHead.AddParameter("RoomNo", DbType.Int32, data_this.RoomNo);
                        dbHead.AddParameter("OrderTyp", DbType.Int32, data_this.OrderTyp);
                        dbHead.AddParameter("RoomSts", DbType.Boolean, data_this.RoomSts);
                        dbHead.AddParameter("chauffeurNo", DbType.Int32, data_this.chauffeurNo);
                        dbHead.AddParameter("RoomPerson", DbType.Int32, data_this.RoomPerson);
                        dbHead.AddParameter("ServiceValue", DbType.Double, data_this.ServiceValue);
                        dbHead.AddParameter("Sts", DbType.Boolean, data_this.Sts);
                        dbHead.AddParameter("PaymentOrderTyp", DbType.Int32, data_this.PaymentOrderTyp);
                        dbHead.AddParameter("AdminLock", DbType.Boolean, data_this.AdminLock);
                        dbHead.AddParameter("DeleteDate", DbType.String, data_this.DeleteDate);
                        dbHead.AddParameter("DeleteTime", DbType.String, data_this.DeleteTime);
                        dbHead.AddParameter("UserNew", DbType.String, data_this.UserNew);
                        dbHead.AddParameter("IfEnter", DbType.Int32, data_this.IfEnter);
                        dbHead.AddParameter("InvAddTax", DbType.Double, data_this.InvAddTax);
                        dbHead.AddParameter("InvAddTaxlLoc", DbType.Double, data_this.InvAddTaxlLoc);
                        dbHead.AddParameter("IsTaxGaid", DbType.Boolean, data_this.IsTaxGaid);
                        dbHead.AddParameter("TaxGaidID", DbType.Double, data_this.TaxGaidID);
                        dbHead.AddParameter("IsTaxUse", DbType.Boolean, data_this.IsTaxUse);
                        dbHead.AddParameter("InvValGaidDis", DbType.Double, data_this.InvValGaidDis);
                        dbHead.AddParameter("InvValGaidDislLoc", DbType.Double, data_this.InvValGaidDislLoc);
                        dbHead.AddParameter("IsDisGaid", DbType.Boolean, data_this.IsDisGaid);
                        dbHead.AddParameter("DisGaidID1", DbType.Double, data_this.DisGaidID1);
                        dbHead.AddParameter("IsDisUse1", DbType.Boolean, data_this.IsDisUse1);
                        dbHead.AddParameter("InvComm", DbType.Double, data_this.InvComm);
                        dbHead.AddParameter("InvCommLoc", DbType.Double, data_this.InvCommLoc);
                        dbHead.AddParameter("IsCommGaid", DbType.Boolean, data_this.IsCommGaid);
                        dbHead.AddParameter("CommGaidID", DbType.Double, data_this.CommGaidID);
                        dbHead.AddParameter("IsCommUse", DbType.Boolean, data_this.IsCommUse);
                        dbHead.AddParameter("IsTaxLines", DbType.Boolean, data_this.IsTaxLines);
                        dbHead.AddParameter("IsTaxByTotal", DbType.Boolean, data_this.IsTaxByTotal);
                        dbHead.AddParameter("IsTaxByNet", DbType.Boolean, data_this.IsTaxByNet);
                        dbHead.AddParameter("TaxByNetValue", DbType.Double, data_this.TaxByNetValue);
                        dbHead.AddParameter("DesPointsValue", DbType.Double, data_this.DesPointsValue);
                        dbHead.AddParameter("DesPointsValueLocCur", DbType.Double, data_this.DesPointsValueLocCur);
                        dbHead.AddParameter("PointsCount", DbType.Double, data_this.PointsCount);
                        dbHead.AddParameter("IsPoints", DbType.Boolean, data_this.IsPoints);
                        dbHead.AddParameter("tailor20", DbType.String, data_this.tailor20);
                        dbHead.AddParameter("CusVenMob", DbType.String, data_this.CusVenMob);
                        dbHead.AddParameter("PriceIncludeTax", DbType.Boolean, data_this.PriceIncludTax);
                        dbHead.ExecuteNonQuery(storedProcedure: true, "S_T_INVHED_INSERT");
                        data_this.InvHed_ID = int.Parse(dbHead.GetParameterValue("InvHed_ID").ToString());
                    }
                    catch (SqlException ex7)
                    {
                        try
                        {
                            VarGeneral.DebLog.writeLog("SaveData:", ex7, enable: true);
                        }
                        catch
                        {
                        }
                        string max = string.Empty;
                        dbInstance = null;
                        max = db.MaxInvheadNo.ToString();
                        if (ex7.Number == 2627)
                        {
                            MessageBox.Show("الرمز مستخدم من قبل.\n سيتم الحفظ برقم جديد [" + max + "]", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            textBox_ID.Text = max ?? string.Empty;
                            data_this.InvNo = max ?? string.Empty;
                            Button_Save_Click(null, null);
                        }
                    }
                    catch (Exception ex8)
                    {
                        try
                        {
                            VarGeneral.DebLog.writeLog("SaveData2:", ex8, enable: true);
                        }
                        catch
                        {
                        }
                        return false;
                    }
                }
                else
                {
                    try
                    {
                        if (!db.DatabaseExists())
                        {
                            MessageBox.Show("لم يتم التعديل بنجاح .. وذلك لان هناك مشكلة في الاتصال .. يرجى المحاولة مرة اخرى");
                            Close();
                            return false;
                        }
                    }
                    catch (SqlException ex7)
                    {
                        VarGeneral.DebLog.writeLog("CheckDB_INVoice:", ex7, enable: true);
                        MessageBox.Show(ex7.Message);
                        MessageBox.Show("لم يتم التعديل بنجاح .. وذلك لان هناك مشكلة في الاتصال .. يرجى المحاولة مرة اخرى");
                        Close();
                        return false;
                    }
                    vSINVDIT.Clear();
                    for (int j = 0; j < data_this.T_INVDETs.Count; j++)
                    {
                        if (data_this.T_INVDETs[j].ItmTyp.Value == 2)
                        {
                            vSINVDIT.Add(data_this.T_INVDETs[j].InvDet_ID, data_this.T_INVDETs[j].T_SINVDETs.ToList());
                        }
                    }
                    using (Stock_DataDataContext stock_DataDataContext = new Stock_DataDataContext(VarGeneral.BranchCS))
                    {
                        try
                        {
                            IDatabase dbR = Database.GetDatabase(VarGeneral.BranchCS);
                            for (int j = 0; j < data_this.T_INVDETs.Count; j++)
                            {
                                if (data_this.T_INVDETs[j].ItmTyp.Value == 2)
                                {
                                    for (int iicnt = 0; iicnt < data_this.T_INVDETs[j].T_SINVDETs.Count; iicnt++)
                                    {
                                        dbR.ClearParameters();
                                        dbR.AddParameter("SInvDet_ID", DbType.Int32, data_this.T_INVDETs[j].T_SINVDETs[iicnt].SInvDet_ID);
                                        if (mndExtrnal && mndNo > 0 && !string.IsNullOrEmpty(mndNo.ToString()))
                                        {
                                            if (CmbInvSide.SelectedIndex == 1)
                                            {
                                                stock_DataDataContext.ExecuteCommand("  UPDATE T_StoreMnd SET T_StoreMnd.stkQty = T_StoreMnd.stkQty - abs(" + data_this.T_INVDETs[j].T_SINVDETs[iicnt].SRealQty.Value + ")\r\n\t\t                                          FROM T_Items INNER JOIN T_StoreMnd ON T_Items.Itm_No = T_StoreMnd.itmNo INNER JOIN T_SINVDET ON T_Items.Itm_No = T_SINVDET.SItmNo\r\n\t\t                                          where SInvDet_ID = " + data_this.T_INVDETs[j].T_SINVDETs[iicnt].SInvDet_ID + " and T_SINVDET.SItmTyp <> 3 and T_StoreMnd.storeNo = " + data_this.T_INVDETs[j].T_SINVDETs[iicnt].SStoreNo.Value + " and T_StoreMnd.MndNo = " + mndNo + " ;");
                                            }
                                            else
                                            {
                                                stock_DataDataContext.ExecuteCommand("  UPDATE T_StoreMnd SET T_StoreMnd.stkQty = T_StoreMnd.stkQty - abs(" + data_this.T_INVDETs[j].T_SINVDETs[iicnt].SRealQty.Value + ")\r\n\t\t                                          FROM T_Items INNER JOIN T_StoreMnd ON T_Items.Itm_No = T_StoreMnd.itmNo INNER JOIN T_SINVDET ON T_Items.Itm_No = T_SINVDET.SItmNo\r\n\t\t                                          where SInvDet_ID = " + data_this.T_INVDETs[j].T_SINVDETs[iicnt].SInvDet_ID + " and T_SINVDET.SItmTyp <> 3 and T_StoreMnd.storeNo = " + data_this.T_INVDETs[j].T_SINVDETs[iicnt].SStoreNo.Value + " and T_StoreMnd.CusVenNo = '" + mndNo + "' ;");
                                            }
                                        }
                                        dbR.ExecuteNonQuery(storedProcedure: true, "S_T_SINVDET_DELETE");
                                    }
                                }
                                dbR.ClearParameters();
                                dbR.AddParameter("InvDet_ID", DbType.Int32, data_this.T_INVDETs[j].InvDet_ID);
                                if (mndExtrnal && mndNo > 0 && !string.IsNullOrEmpty(mndNo.ToString()))
                                {
                                    if (CmbInvSide.SelectedIndex == 1)
                                    {
                                        stock_DataDataContext.ExecuteCommand("  UPDATE T_StoreMnd SET T_StoreMnd.stkQty = T_StoreMnd.stkQty - abs(" + data_this.T_INVDETs[j].RealQty.Value + ")\r\n\t\t                                          FROM T_Items INNER JOIN T_StoreMnd ON T_Items.Itm_No = T_StoreMnd.itmNo INNER JOIN T_INVDET ON T_Items.Itm_No = T_INVDET.ItmNo\r\n\t\t                                          where InvDet_ID = " + data_this.T_INVDETs[j].InvDet_ID + " and T_INVDET.ItmTyp <> 3 and T_StoreMnd.storeNo = " + data_this.T_INVDETs[j].StoreNo.Value + " and T_StoreMnd.MndNo = " + mndNo + " ;");
                                    }
                                    else
                                    {
                                        stock_DataDataContext.ExecuteCommand("  UPDATE T_StoreMnd SET T_StoreMnd.stkQty = T_StoreMnd.stkQty - abs(" + data_this.T_INVDETs[j].RealQty.Value + ")\r\n\t\t                                          FROM T_Items INNER JOIN T_StoreMnd ON T_Items.Itm_No = T_StoreMnd.itmNo INNER JOIN T_INVDET ON T_Items.Itm_No = T_INVDET.ItmNo\r\n\t\t                                          where InvDet_ID = " + data_this.T_INVDETs[j].InvDet_ID + " and T_INVDET.ItmTyp <> 3 and T_StoreMnd.storeNo = " + data_this.T_INVDETs[j].StoreNo.Value + " and T_StoreMnd.CusVenNo = '" + mndNo + "' ;");
                                    }
                                }
                                dbR.ExecuteNonQuery(storedProcedure: true, "S_T_INVDET_DELETE");
                            }
                        }
                        catch (SqlException ex7)
                        {
                            VarGeneral.DebLog.writeLog("ExchangItemToMnd:", ex7, enable: true);
                            MessageBox.Show(ex7.Message);
                            return false;
                        }
                    }
                    data_this.SalsManNam = VarGeneral.UserNumber;
                    try
                    {
                        IDatabase dbHead = Database.GetDatabase(VarGeneral.BranchCS);
                        dbHead.ClearParameters();
                        dbHead.AddParameter("InvHed_ID", DbType.Int32, data_this.InvHed_ID);
                        dbHead.AddParameter("InvId", DbType.Double, data_this.InvId);
                        dbHead.AddParameter("InvNo", DbType.String, data_this.InvNo);
                        dbHead.AddParameter("InvTyp", DbType.Int32, data_this.InvTyp);
                        dbHead.AddParameter("InvCashPay", DbType.Int32, data_this.InvCashPay);
                        dbHead.AddParameter("CusVenNo", DbType.String, data_this.CusVenNo);
                        dbHead.AddParameter("CusVenNm", DbType.String, data_this.CusVenNm);
                        dbHead.AddParameter("CusVenAdd", DbType.String, data_this.CusVenAdd);
                        dbHead.AddParameter("CusVenTel", DbType.String, data_this.CusVenTel);
                        dbHead.AddParameter("Remark", DbType.String, data_this.Remark);
                        dbHead.AddParameter("HDat", DbType.String, data_this.HDat);
                        dbHead.AddParameter("GDat", DbType.String, data_this.GDat);
                        dbHead.AddParameter("MndNo", DbType.Int32, data_this.MndNo);
                        dbHead.AddParameter("SalsManNo", DbType.String, data_this.SalsManNo);
                        dbHead.AddParameter("SalsManNam", DbType.String, data_this.SalsManNam);
                        dbHead.AddParameter("InvTot", DbType.Double, data_this.InvTot);
                        dbHead.AddParameter("InvTotLocCur", DbType.Double, data_this.InvTotLocCur);
                        dbHead.AddParameter("InvDisPrs", DbType.Double, data_this.InvDisPrs);
                        dbHead.AddParameter("InvDisVal", DbType.Double, data_this.InvDisVal);
                        dbHead.AddParameter("InvDisValLocCur", DbType.Double, data_this.InvDisValLocCur);
                        dbHead.AddParameter("InvNet", DbType.Double, data_this.InvNet);
                        dbHead.AddParameter("InvNetLocCur", DbType.Double, data_this.InvNetLocCur);
                        dbHead.AddParameter("CashPay", DbType.Double, data_this.CashPay);
                        dbHead.AddParameter("CashPayLocCur", DbType.Double, data_this.CashPayLocCur);
                        dbHead.AddParameter("IfRet", DbType.Int32, data_this.IfRet);
                        dbHead.AddParameter("GadeNo", DbType.Double, data_this.GadeNo);
                        dbHead.AddParameter("GadeId", DbType.Double, data_this.GadeId);
                        dbHead.AddParameter("IfDel", DbType.Int32, data_this.IfDel);
                        dbHead.AddParameter("RetNo", DbType.String, data_this.RetNo);
                        dbHead.AddParameter("RetId", DbType.Double, data_this.RetId);
                        dbHead.AddParameter("InvCstNo", DbType.Int32, data_this.InvCstNo);
                        dbHead.AddParameter("InvCashPayNm", DbType.String, data_this.InvCashPayNm);
                        dbHead.AddParameter("RefNo", DbType.String, data_this.RefNo);
                        dbHead.AddParameter("InvCost", DbType.Int32, data_this.InvCost);
                        dbHead.AddParameter("EstDat", DbType.String, data_this.EstDat);
                        dbHead.AddParameter("CustPri", DbType.Int32, data_this.CustPri);
                        dbHead.AddParameter("ArbTaf", DbType.String, data_this.ArbTaf);
                        dbHead.AddParameter("CurTyp", DbType.Int32, data_this.CurTyp);
                        dbHead.AddParameter("InvCash", DbType.String, data_this.InvCash);
                        dbHead.AddParameter("ToStore", DbType.String, data_this.ToStore);
                        dbHead.AddParameter("ToStoreNm", DbType.String, data_this.ToStoreNm);
                        dbHead.AddParameter("InvQty", DbType.Double, data_this.InvQty);
                        dbHead.AddParameter("EngTaf", DbType.String, data_this.EngTaf);
                        dbHead.AddParameter("IfTrans", DbType.Int32, data_this.IfTrans);
                        dbHead.AddParameter("CustRep", DbType.Double, data_this.CustRep);
                        dbHead.AddParameter("CustNet", DbType.Double, data_this.CustNet);
                        dbHead.AddParameter("InvWight_T", DbType.Double, data_this.InvWight_T);
                        dbHead.AddParameter("IfPrint", DbType.Int32, data_this.IfPrint);
                        dbHead.AddParameter("LTim", DbType.String, data_this.LTim);
                        dbHead.AddParameter("CREATED_BY", DbType.String, data_this.CREATED_BY);
                        dbHead.AddParameter("DATE_CREATED", DbType.DateTime, data_this.DATE_CREATED);
                        dbHead.AddParameter("MODIFIED_BY", DbType.String, data_this.MODIFIED_BY);
                        dbHead.AddParameter("DATE_MODIFIED", DbType.DateTime, data_this.DATE_MODIFIED);
                        dbHead.AddParameter("CreditPay", DbType.Double, data_this.CreditPay);
                        dbHead.AddParameter("CreditPayLocCur", DbType.Double, data_this.CreditPayLocCur);
                        dbHead.AddParameter("NetworkPay", DbType.Double, data_this.NetworkPay);
                        dbHead.AddParameter("NetworkPayLocCur", DbType.Double, data_this.NetworkPayLocCur);
                        dbHead.AddParameter("CommMnd_Inv", DbType.Double, data_this.CommMnd_Inv);
                        dbHead.AddParameter("MndExtrnal", DbType.Boolean, data_this.MndExtrnal);
                        dbHead.AddParameter("CompanyID", DbType.Int32, data_this.CompanyID);
                        dbHead.AddParameter("InvAddCost", DbType.Double, data_this.InvAddCost);
                        dbHead.AddParameter("InvAddCostLoc", DbType.Double, data_this.InvAddCostLoc);
                        dbHead.AddParameter("InvAddCostExtrnal", DbType.Double, data_this.InvAddCostExtrnal);
                        dbHead.AddParameter("InvAddCostExtrnalLoc", DbType.Double, data_this.InvAddCostExtrnalLoc);
                        dbHead.AddParameter("IsExtrnalGaid", DbType.Boolean, data_this.IsExtrnalGaid);
                        dbHead.AddParameter("ExtrnalCostGaidID", DbType.Double, data_this.ExtrnalCostGaidID);
                        dbHead.AddParameter("Puyaid", DbType.Double, data_this.Puyaid);
                        dbHead.AddParameter("Remming", DbType.Double, data_this.Remming);
                        dbHead.AddParameter("RoomNo", DbType.Int32, data_this.RoomNo);
                        dbHead.AddParameter("OrderTyp", DbType.Int32, data_this.OrderTyp);
                        dbHead.AddParameter("RoomSts", DbType.Boolean, data_this.RoomSts);
                        dbHead.AddParameter("chauffeurNo", DbType.Int32, data_this.chauffeurNo);
                        dbHead.AddParameter("RoomPerson", DbType.Int32, data_this.RoomPerson);
                        dbHead.AddParameter("ServiceValue", DbType.Double, data_this.ServiceValue);
                        dbHead.AddParameter("Sts", DbType.Boolean, data_this.Sts);
                        dbHead.AddParameter("PaymentOrderTyp", DbType.Int32, data_this.PaymentOrderTyp);
                        dbHead.AddParameter("AdminLock", DbType.Boolean, data_this.AdminLock);
                        dbHead.AddParameter("DeleteDate", DbType.String, data_this.DeleteDate);
                        dbHead.AddParameter("DeleteTime", DbType.String, data_this.DeleteTime);
                        dbHead.AddParameter("UserNew", DbType.String, data_this.UserNew);
                        dbHead.AddParameter("IfEnter", DbType.Int32, data_this.IfEnter);
                        dbHead.AddParameter("InvAddTax", DbType.Double, data_this.InvAddTax);
                        dbHead.AddParameter("InvAddTaxlLoc", DbType.Double, data_this.InvAddTaxlLoc);
                        dbHead.AddParameter("IsTaxGaid", DbType.Boolean, data_this.IsTaxGaid);
                        dbHead.AddParameter("TaxGaidID", DbType.Double, data_this.TaxGaidID);
                        dbHead.AddParameter("IsTaxUse", DbType.Boolean, data_this.IsTaxUse);
                        dbHead.AddParameter("InvValGaidDis", DbType.Double, data_this.InvValGaidDis);
                        dbHead.AddParameter("InvValGaidDislLoc", DbType.Double, data_this.InvValGaidDislLoc);
                        dbHead.AddParameter("IsDisGaid", DbType.Boolean, data_this.IsDisGaid);
                        dbHead.AddParameter("DisGaidID1", DbType.Double, data_this.DisGaidID1);
                        dbHead.AddParameter("IsDisUse1", DbType.Boolean, data_this.IsDisUse1);
                        dbHead.AddParameter("InvComm", DbType.Double, data_this.InvComm);
                        dbHead.AddParameter("InvCommLoc", DbType.Double, data_this.InvCommLoc);
                        dbHead.AddParameter("IsCommGaid", DbType.Boolean, data_this.IsCommGaid);
                        dbHead.AddParameter("CommGaidID", DbType.Double, data_this.CommGaidID);
                        dbHead.AddParameter("IsCommUse", DbType.Boolean, data_this.IsCommUse);
                        dbHead.AddParameter("IsTaxLines", DbType.Boolean, data_this.IsTaxLines);
                        dbHead.AddParameter("IsTaxByTotal", DbType.Boolean, data_this.IsTaxByTotal);
                        dbHead.AddParameter("IsTaxByNet", DbType.Boolean, data_this.IsTaxByNet);
                        dbHead.AddParameter("TaxByNetValue", DbType.Double, data_this.TaxByNetValue);
                        dbHead.AddParameter("DesPointsValue", DbType.Double, data_this.DesPointsValue);
                        dbHead.AddParameter("DesPointsValueLocCur", DbType.Double, data_this.DesPointsValueLocCur);
                        dbHead.AddParameter("PointsCount", DbType.Double, data_this.PointsCount);
                        dbHead.AddParameter("IsPoints", DbType.Boolean, data_this.IsPoints);
                        dbHead.AddParameter("tailor20", DbType.String, data_this.tailor20);
                        dbHead.AddParameter("CusVenMob", DbType.String, data_this.CusVenMob);
                        dbHead.AddParameter("PriceIncludeTax", DbType.Boolean, data_this.PriceIncludTax);
                        dbHead.ExecuteNonQuery(storedProcedure: true, "S_T_INVHED_UPDATE");
                    }
                    catch (SqlException ex7)
                    {
                        VarGeneral.DebLog.writeLog("SaveEditMovement:", ex7, enable: true);
                        MessageBox.Show(ex7.Message);
                        return false;
                    }
                }
                int iiCnt = 0;
                try
                {
                    IDatabase dbLines = Database.GetDatabase(VarGeneral.BranchCS);
                    for (iiCnt = 1; iiCnt < FlxInv.Rows.Count; iiCnt++)
                    {
                        if (FlxInv.GetData(iiCnt, 1) == null)
                        {
                            continue;
                        }
                        dbLines.ClearParameters();
                        dbLines.AddParameter("InvDet_ID", DbType.Int32, 0);
                        dbLines.AddParameter("InvNo", DbType.String, textBox_ID.Text.Trim());
                        dbLines.AddParameter("InvId", DbType.Int32, data_this.InvHed_ID);
                        dbLines.AddParameter("InvSer", DbType.Int32, iiCnt);
                        dbLines.AddParameter("ItmNo", DbType.String, string.Concat(FlxInv.GetData(iiCnt, 1)));
                        dbLines.AddParameter("Cost", DbType.Double, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 10)))));
                        dbLines.AddParameter("Qty", DbType.Double, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 7)))));
                        dbLines.AddParameter("ItmDes", DbType.String, string.Concat(FlxInv.GetData(iiCnt, 2)));
                        dbLines.AddParameter("ItmUnt", DbType.String, string.Concat(FlxInv.GetData(iiCnt, 3)));
                        dbLines.AddParameter("ItmDesE", DbType.String, string.Concat(FlxInv.GetData(iiCnt, 4)));
                        dbLines.AddParameter("ItmUntE", DbType.String, string.Concat(FlxInv.GetData(iiCnt, 5)));
                        dbLines.AddParameter("ItmUntPak", DbType.Double, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 11)))));
                        dbLines.AddParameter("StoreNo", DbType.Int32, int.Parse(VarGeneral.TString.TEmpty(FlxInv.GetData(iiCnt, 6).ToString() ?? string.Empty)));
                        dbLines.AddParameter("Price", DbType.Double, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 8)))));
                        dbLines.AddParameter("Amount", DbType.Double, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 38)))));
                        dbLines.AddParameter("RealQty", DbType.Double, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 12)))));
                        dbLines.AddParameter("itmInvDsc", DbType.Double, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 13)))));
                        if (VarGeneral.CheckDate(string.Concat(FlxInv.GetData(iiCnt, 27))))
                        {
                            dbLines.AddParameter("DatExper", DbType.String, string.Concat(FlxInv.GetData(iiCnt, 27)));
                        }
                        else
                        {
                            dbLines.AddParameter("DatExper", DbType.String, string.Empty);
                        }
                        dbLines.AddParameter("ItmDis", DbType.Double, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 9)))));
                        dbLines.AddParameter("ItmTyp", DbType.Int32, int.Parse("0" + FlxInv.GetData(iiCnt, 32)));
                        dbLines.AddParameter("ItmIndex", DbType.Int32, 0);
                        try
                        {
                            dbLines.AddParameter("ItmWight", DbType.Double, ((bool)FlxInv.GetData(iiCnt, 33)) ? 1 : 0);
                        }
                        catch
                        {
                            dbLines.AddParameter("ItmWight", DbType.Double, 0);
                        }
                        dbLines.AddParameter("ItmWight_T", DbType.Double, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 34)))));
                        if (!string.IsNullOrEmpty(string.Concat(FlxInv.GetData(iiCnt, 35))))
                        {
                            dbLines.AddParameter("RunCod", DbType.String, string.Concat(FlxInv.GetData(iiCnt, 35)));
                        }
                        else
                        {
                            dbLines.AddParameter("RunCod", DbType.String, string.Empty);
                        }
                        dbLines.AddParameter("LineDetails", DbType.String, string.Concat(FlxInv.GetData(iiCnt, 36)));
                        dbLines.AddParameter("Serial_Key", DbType.String, string.Concat(FlxInv.GetData(iiCnt, 37)));
                        dbLines.AddParameter("ItmTax", DbType.Double, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 31)))));
                        try
                        {
                            if (!string.IsNullOrEmpty(FlxInv.GetData(iiCnt, 39).ToString()))
                            {
                                dbLines.AddParameter("OfferTyp", DbType.Int32, int.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 39)))));
                            }
                        }
                        catch
                        {
                        }
                        dbLines.ExecuteNonQuery(storedProcedure: true, "S_T_INVDET_INSERT");
                        if (CmbInvSide.SelectedIndex > 0)
                        {
                            Stock_DataDataContext stock_DataDataContext = new Stock_DataDataContext(VarGeneral.BranchCS);
                            stock_DataDataContext.ExecuteCommand(string.Concat("Update T_Items SET OpenQty = OpenQty - ", double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 12)))), " WHERE Itm_No = '", FlxInv.GetData(iiCnt, 1), "';"));
                            stock_DataDataContext.ExecuteCommand(string.Concat("Update T_STKSQTY SET stkQty = stkQty - ", double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 12)))), " WHERE itmNo = '", FlxInv.GetData(iiCnt, 1), "' and storeNo = ", int.Parse(VarGeneral.TString.TEmpty(FlxInv.GetData(iiCnt, 6).ToString() ?? string.Empty)), ";"));
                            int q = stock_DataDataContext.ExecuteCommand(string.Concat("select Count(*) from T_STKSQTY where itmNo = '", FlxInv.GetData(iiCnt, 1), "' and storeNo = ", int.Parse(VarGeneral.TString.TEmpty(FlxInv.GetData(iiCnt, 6).ToString() ?? string.Empty)), ";"));
                            if (q > 0 && VarGeneral.CheckDate(string.Concat(FlxInv.GetData(iiCnt, 27))))
                            {
                                stock_DataDataContext.ExecuteCommand(string.Concat("Update T_QTYEXP SET stkQty = stkQty - ", double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 12)))), " WHERE itmNo = ", FlxInv.GetData(iiCnt, 1), " and storeNo = ", int.Parse(VarGeneral.TString.TEmpty(FlxInv.GetData(iiCnt, 6).ToString() ?? string.Empty)), " and DatExper = '", FlxInv.GetData(iiCnt, 27), "';"));
                            }
                            if (CmbInvSide.SelectedIndex == 1)
                            {
                                stock_DataDataContext.ExecuteCommand(string.Concat("Update T_StoreMnd SET stkQty = stkQty + ", double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 12)))), " WHERE itmNo = '", FlxInv.GetData(iiCnt, 1), "' and storeNo = ", int.Parse(VarGeneral.TString.TEmpty(FlxInv.GetData(iiCnt, 6).ToString() ?? string.Empty)), " and MndNo = ", int.Parse(CmbLegate.SelectedValue.ToString()), ";"));
                            }
                            else
                            {
                                stock_DataDataContext.ExecuteCommand(string.Concat("Update T_StoreMnd SET stkQty = stkQty + ", double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 12)))), " WHERE itmNo = '", FlxInv.GetData(iiCnt, 1), "' and storeNo = ", int.Parse(VarGeneral.TString.TEmpty(FlxInv.GetData(iiCnt, 6).ToString() ?? string.Empty)), " and CusVenNo = '", txtCustNo.Text, "';"));
                            }
                        }
                        if (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 32)))) != 2.0)
                        {
                            continue;
                        }
                        dataGridView_ItemDet.Visible = false;
                        FlxInv.RowSel = iiCnt;
                        if (State == FormState.New && (int.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 25)))) <= 0 || string.IsNullOrEmpty(FlxInv.GetData(iiCnt, 25).ToString())))
                        {
                            GridDetUpdate(FlxInv.RowSel);
                        }
                        else
                        {
                            for (int j = 0; j < vSINVDIT.Count; j++)
                            {
                                if ((double)vSINVDIT.ToList()[j].Key == double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 25)))))
                                {
                                    SetLinesDET(vSINVDIT.ToList()[j].Value, iiCnt);
                                }
                            }
                        }
                        int SInvHed = 0;
                        try
                        {
                            Stock_DataDataContext stock_DataDataContext2 = new Stock_DataDataContext(VarGeneral.BranchCS);
                            SInvHed = (from t in stock_DataDataContext2.T_INVDETs
                                       where t.InvId == (int?)data_this.InvHed_ID
                                       where t.InvNo == textBox_ID.Text
                                       where t.ItmTyp == (int?)2
                                       where t.InvSer == (int?)iiCnt
                                       select t).ToList().First().InvDet_ID;
                        }
                        catch
                        {
                            SInvHed = 0;
                        }
                        if (SInvHed == 0)
                        {
                            continue;
                        }
                        for (int j = 1; j < dataGridView_ItemDet.Rows.Count; j++)
                        {
                            if (dataGridView_ItemDet.GetData(j, 1) == null)
                            {
                                continue;
                            }
                            dbLines.ClearParameters();
                            dbLines.AddParameter("SInvDet_ID", DbType.Int32, 0);
                            dbLines.AddParameter("SInvNo", DbType.String, textBox_ID.Text.Trim());
                            dbLines.AddParameter("SInvId", DbType.Int32, SInvHed);
                            dbLines.AddParameter("SInvSer", DbType.Int32, j);
                            dbLines.AddParameter("SItmNo", DbType.String, string.Concat(dataGridView_ItemDet.GetData(j, 1)));
                            dbLines.AddParameter("SCost", DbType.Double, double.Parse(VarGeneral.TString.TEmpty(string.Concat(dataGridView_ItemDet.GetData(j, 10)))));
                            dbLines.AddParameter("SQty", DbType.Double, double.Parse(VarGeneral.TString.TEmpty(string.Concat(dataGridView_ItemDet.GetData(j, 7)))));
                            dbLines.AddParameter("SItmDes", DbType.String, string.Concat(dataGridView_ItemDet.GetData(j, 2)));
                            dbLines.AddParameter("SItmUnt", DbType.String, string.Concat(dataGridView_ItemDet.GetData(j, 3)));
                            dbLines.AddParameter("SItmDesE", DbType.String, string.Concat(dataGridView_ItemDet.GetData(j, 4)));
                            dbLines.AddParameter("SItmUntE", DbType.String, string.Concat(dataGridView_ItemDet.GetData(j, 5)));
                            dbLines.AddParameter("SItmUntPak", DbType.Double, double.Parse(VarGeneral.TString.TEmpty(string.Concat(dataGridView_ItemDet.GetData(j, 11)))));
                            dbLines.AddParameter("SStoreNo", DbType.Int32, int.Parse(VarGeneral.TString.TEmpty(dataGridView_ItemDet.GetData(j, 6).ToString() ?? string.Empty)));
                            dbLines.AddParameter("SPrice", DbType.Double, double.Parse(VarGeneral.TString.TEmpty(string.Concat(dataGridView_ItemDet.GetData(j, 8)))));
                            dbLines.AddParameter("SAmount", DbType.Double, double.Parse(VarGeneral.TString.TEmpty(string.Concat(dataGridView_ItemDet.GetData(j, 38)))));
                            dbLines.AddParameter("SRealQty", DbType.Double, double.Parse(VarGeneral.TString.TEmpty(string.Concat(dataGridView_ItemDet.GetData(j, 12)))));
                            dbLines.AddParameter("SitmInvDsc", DbType.Double, double.Parse(VarGeneral.TString.TEmpty(string.Concat(dataGridView_ItemDet.GetData(j, 13)))));
                            if (VarGeneral.CheckDate(string.Concat(dataGridView_ItemDet.GetData(j, 27))))
                            {
                                dbLines.AddParameter("SDatExper", DbType.String, string.Concat(dataGridView_ItemDet.GetData(j, 27)));
                            }
                            else
                            {
                                dbLines.AddParameter("SDatExper", DbType.String, string.Empty);
                            }
                            dbLines.AddParameter("SItmDis", DbType.Double, double.Parse(VarGeneral.TString.TEmpty(string.Concat(dataGridView_ItemDet.GetData(j, 9)))));
                            dbLines.AddParameter("SItmTyp", DbType.Int32, int.Parse("0" + dataGridView_ItemDet.GetData(j, 32)));
                            dbLines.AddParameter("SItmIndex", DbType.Int32, 0);
                            dbLines.AddParameter("SItmWight", DbType.Double, double.Parse(VarGeneral.TString.TEmpty(string.Concat(dataGridView_ItemDet.GetData(j, 33)))));
                            dbLines.AddParameter("SItmWight_T", DbType.Double, double.Parse(VarGeneral.TString.TEmpty(string.Concat(dataGridView_ItemDet.GetData(j, 34)))));
                            dbLines.AddParameter("SQtyDef", DbType.Double, double.Parse(VarGeneral.TString.TEmpty(string.Concat(dataGridView_ItemDet.GetData(j, 29)))));
                            dbLines.AddParameter("SPriceDef", DbType.Double, double.Parse(VarGeneral.TString.TEmpty(string.Concat(dataGridView_ItemDet.GetData(j, 17)))));
                            dbLines.AddParameter("SInvIdHEAD", DbType.Int32, data_this.InvHed_ID);
                            dbLines.AddParameter("SItmTax", DbType.Double, 0);
                            dbLines.ExecuteNonQuery(storedProcedure: true, "S_T_SINVDET_INSERT");
                            if (CmbInvSide.SelectedIndex <= 0)
                            {
                                continue;
                            }
                            Stock_DataDataContext stock_DataDataContext = new Stock_DataDataContext(VarGeneral.BranchCS);
                            stock_DataDataContext.ExecuteCommand(string.Concat("Update T_Items SET OpenQty = OpenQty - ", double.Parse(VarGeneral.TString.TEmpty(string.Concat(dataGridView_ItemDet.GetData(j, 12)))), " WHERE Itm_No = '", dataGridView_ItemDet.GetData(j, 1), "';"));
                            stock_DataDataContext.ExecuteCommand(string.Concat("Update T_STKSQTY SET stkQty = stkQty - ", double.Parse(VarGeneral.TString.TEmpty(string.Concat(dataGridView_ItemDet.GetData(j, 12)))), " WHERE itmNo = '", dataGridView_ItemDet.GetData(j, 1), "' and storeNo = ", int.Parse(VarGeneral.TString.TEmpty(dataGridView_ItemDet.GetData(j, 6).ToString() ?? string.Empty)), ";"));
                            int q = stock_DataDataContext.ExecuteCommand(string.Concat("select Count(*) from T_STKSQTY where itmNo = '", dataGridView_ItemDet.GetData(j, 1), "' and storeNo = ", int.Parse(VarGeneral.TString.TEmpty(dataGridView_ItemDet.GetData(j, 6).ToString() ?? string.Empty)), ";"));
                            if (q > 0 && VarGeneral.CheckDate(string.Concat(dataGridView_ItemDet.GetData(j, 27))))
                            {
                                stock_DataDataContext.ExecuteCommand(string.Concat("Update T_QTYEXP SET stkQty = stkQty - ", double.Parse(VarGeneral.TString.TEmpty(string.Concat(dataGridView_ItemDet.GetData(j, 12)))), " WHERE itmNo = ", dataGridView_ItemDet.GetData(j, 1), " and storeNo = ", int.Parse(VarGeneral.TString.TEmpty(dataGridView_ItemDet.GetData(j, 6).ToString() ?? string.Empty)), " and DatExper = '", dataGridView_ItemDet.GetData(j, 27), "';"));
                            }
                            if (CmbInvSide.SelectedIndex == 1)
                            {
                                stock_DataDataContext.ExecuteCommand(string.Concat("Update T_StoreMnd SET stkQty = stkQty + ", double.Parse(VarGeneral.TString.TEmpty(string.Concat(dataGridView_ItemDet.GetData(j, 12)))), " WHERE itmNo = '", dataGridView_ItemDet.GetData(j, 1), "' and storeNo = ", int.Parse(VarGeneral.TString.TEmpty(dataGridView_ItemDet.GetData(j, 6).ToString() ?? string.Empty)), " and MndNo = ", int.Parse(CmbLegate.SelectedValue.ToString()), ";"));
                            }
                            else
                            {
                                stock_DataDataContext.ExecuteCommand(string.Concat("Update T_StoreMnd SET stkQty = stkQty + ", double.Parse(VarGeneral.TString.TEmpty(string.Concat(dataGridView_ItemDet.GetData(j, 12)))), " WHERE itmNo = '", dataGridView_ItemDet.GetData(j, 1), "' and storeNo = ", int.Parse(VarGeneral.TString.TEmpty(dataGridView_ItemDet.GetData(j, 6).ToString() ?? string.Empty)), " and CusVenNo = '", txtCustNo.Text, "';"));
                            }
                        }
                    }
                }
                catch (Exception ex8)
                {
                    VarGeneral.DebLog.writeLog("LinesInv_Save_InvSaleReturn:", ex8, enable: true);
                    MessageBox.Show(ex8.Message);
                    return false;
                }
                if ((txtPaymentLoc.Value > 0.0 && !string.IsNullOrEmpty(AccCrdt) && !string.IsNullOrEmpty(AccDbt)) || (doubleInput_NetWorkLoc.Value > 0.0 && !string.IsNullOrEmpty(AccCrdt_NewtWork) && !string.IsNullOrEmpty(AccDbt_NetWork)) || (doubleInput_CreditLoc.Value > 0.0 && !string.IsNullOrEmpty(AccCrdt_Credit) && !string.IsNullOrEmpty(AccDbt_Credit)))
                {
                    Stock_DataDataContext stock_DataDataContext2 = new Stock_DataDataContext(VarGeneral.BranchCS);
                    if (State == FormState.New || _GdHead.gdhead_ID == 0)
                    {
                        GetDataGd();
                        _GdHead.DATE_CREATED = DateTime.Now;
                        stock_DataDataContext2.T_GDHEADs.InsertOnSubmit(_GdHead);
                        stock_DataDataContext2.SubmitChanges();
                    }
                    else
                    {
                        dbInstance = null;
                        if (!data_this.GadeId.HasValue)
                        {
                            _GdHead = new T_GDHEAD();
                        }
                        textBox_ID_TextChanged(null, null);
                        GetDataGd();
                        if (!data_this.GadeId.HasValue)
                        {
                            stock_DataDataContext2.T_GDHEADs.InsertOnSubmit(_GdHead);
                            stock_DataDataContext2.SubmitChanges();
                        }
                        else
                        {
                            db.Log = VarGeneral.DebugLog;
                            db.SubmitChanges(ConflictMode.ContinueOnConflict);
                        }
                        for (int j = 0; j < _GdHead.T_GDDETs.Count; j++)
                        {
                            db_.StartTransaction();
                            db_.ClearParameters();
                            db_.AddParameter("GDDET_ID", DbType.Int32, _GdHead.T_GDDETs[j].GDDET_ID);
                            db_.ExecuteNonQueryWithoutCommit(storedProcedure: true, "S_T_GDDET_DELETE");
                            db_.EndTransaction();
                        }
                    }
                    iiCnt = 0;
                    if (txtPaymentLoc.Value > 0.0 && !string.IsNullOrEmpty(AccCrdt) && !string.IsNullOrEmpty(AccDbt))
                    {
                        db_.StartTransaction();
                        db_.ClearParameters();
                        db_.AddParameter("GDDET_ID", DbType.Int32, 0);
                        db_.AddParameter("gdID", DbType.Int32, _GdHead.gdhead_ID);
                        db_.AddParameter("gdNo", DbType.String, textBox_ID.Text);
                        db_.AddParameter("gdDes", DbType.String, "قيد تلقائي لفاتورة مرتجع مبيعات رقم : " + textBox_ID.Text);
                        db_.AddParameter("gdDesE", DbType.String, "Auto Bound To Sales Return Invoice No : " + textBox_ID.Text);
                        db_.AddParameter("recptTyp", DbType.String, "3");
                        db_.AddParameter("AccNo", DbType.String, AccCrdt);
                        db_.AddParameter("AccName", DbType.String, string.Empty);
                        db_.AddParameter("gdValue", DbType.Double, 0.0 - double.Parse(txtPaymentLoc.Text));
                        db_.AddParameter("recptNo", DbType.String, textBox_ID.Text);
                        db_.AddParameter("Lin", DbType.Int32, 1);
                        db_.AddParameter("AccNoDestruction", DbType.String, null);
                        db_.ExecuteNonQueryWithoutCommit(storedProcedure: true, "S_T_GDDET_INSERT");
                        db_.EndTransaction();
                        db_.StartTransaction();
                        db_.ClearParameters();
                        db_.AddParameter("GDDET_ID", DbType.Int32, 0);
                        db_.AddParameter("gdID", DbType.Int32, _GdHead.gdhead_ID);
                        db_.AddParameter("gdNo", DbType.String, textBox_ID.Text);
                        db_.AddParameter("gdDes", DbType.String, "قيد تلقائي لفاتورة مرتجع مبيعات رقم : " + textBox_ID.Text);
                        db_.AddParameter("gdDesE", DbType.String, "Auto Bound To Sales Return Invoice No : " + textBox_ID.Text);
                        db_.AddParameter("recptTyp", DbType.String, "3");
                        db_.AddParameter("AccNo", DbType.String, AccDbt);
                        db_.AddParameter("AccName", DbType.String, string.Empty);
                        db_.AddParameter("gdValue", DbType.Double, double.Parse(txtPaymentLoc.Text));
                        db_.AddParameter("recptNo", DbType.String, textBox_ID.Text);
                        db_.AddParameter("Lin", DbType.Int32, 1);
                        db_.AddParameter("AccNoDestruction", DbType.String, null);
                        db_.ExecuteNonQueryWithoutCommit(storedProcedure: true, "S_T_GDDET_INSERT");
                        db_.EndTransaction();
                    }
                    if (doubleInput_NetWorkLoc.Value > 0.0 && !string.IsNullOrEmpty(AccCrdt_NewtWork) && !string.IsNullOrEmpty(AccDbt_NetWork))
                    {
                        db_.StartTransaction();
                        db_.ClearParameters();
                        db_.AddParameter("GDDET_ID", DbType.Int32, 0);
                        db_.AddParameter("gdID", DbType.Int32, _GdHead.gdhead_ID);
                        db_.AddParameter("gdNo", DbType.String, textBox_ID.Text);
                        db_.AddParameter("gdDes", DbType.String, "قيد تلقائي لفاتورة مرتجع مبيعات رقم : " + textBox_ID.Text);
                        db_.AddParameter("gdDesE", DbType.String, "Auto Bound To Sales Return Invoice No : " + textBox_ID.Text);
                        db_.AddParameter("recptTyp", DbType.String, "3");
                        db_.AddParameter("AccNo", DbType.String, AccCrdt_NewtWork);
                        db_.AddParameter("AccName", DbType.String, string.Empty);
                        db_.AddParameter("gdValue", DbType.Double, 0.0 - double.Parse(doubleInput_NetWorkLoc.Text));
                        db_.AddParameter("recptNo", DbType.String, textBox_ID.Text);
                        db_.AddParameter("Lin", DbType.Int32, 3);
                        db_.AddParameter("AccNoDestruction", DbType.String, null);
                        db_.ExecuteNonQueryWithoutCommit(storedProcedure: true, "S_T_GDDET_INSERT");
                        db_.EndTransaction();
                        db_.StartTransaction();
                        db_.ClearParameters();
                        db_.AddParameter("GDDET_ID", DbType.Int32, 0);
                        db_.AddParameter("gdID", DbType.Int32, _GdHead.gdhead_ID);
                        db_.AddParameter("gdNo", DbType.String, textBox_ID.Text);
                        db_.AddParameter("gdDes", DbType.String, "قيد تلقائي لفاتورة مرتجع مبيعات رقم : " + textBox_ID.Text);
                        db_.AddParameter("gdDesE", DbType.String, "Auto Bound To Sales Return Invoice No : " + textBox_ID.Text);
                        db_.AddParameter("recptTyp", DbType.String, "3");
                        db_.AddParameter("AccNo", DbType.String, AccDbt_NetWork);
                        db_.AddParameter("AccName", DbType.String, string.Empty);
                        db_.AddParameter("gdValue", DbType.Double, double.Parse(doubleInput_NetWorkLoc.Text));
                        db_.AddParameter("recptNo", DbType.String, textBox_ID.Text);
                        db_.AddParameter("Lin", DbType.Int32, 3);
                        db_.AddParameter("AccNoDestruction", DbType.String, null);
                        db_.ExecuteNonQueryWithoutCommit(storedProcedure: true, "S_T_GDDET_INSERT");
                        db_.EndTransaction();
                    }
                    if (doubleInput_CreditLoc.Value > 0.0 && !string.IsNullOrEmpty(AccCrdt_Credit) && !string.IsNullOrEmpty(AccDbt_Credit))
                    {
                        db_.StartTransaction();
                        db_.ClearParameters();
                        db_.AddParameter("GDDET_ID", DbType.Int32, 0);
                        db_.AddParameter("gdID", DbType.Int32, _GdHead.gdhead_ID);
                        db_.AddParameter("gdNo", DbType.String, textBox_ID.Text);
                        db_.AddParameter("gdDes", DbType.String, "قيد تلقائي لفاتورة مرتجع مبيعات رقم : " + textBox_ID.Text);
                        db_.AddParameter("gdDesE", DbType.String, "Auto Bound To Sales Return Invoice No : " + textBox_ID.Text);
                        db_.AddParameter("recptTyp", DbType.String, "3");
                        db_.AddParameter("AccNo", DbType.String, AccCrdt_Credit);
                        db_.AddParameter("AccName", DbType.String, string.Empty);
                        db_.AddParameter("gdValue", DbType.Double, 0.0 - double.Parse(doubleInput_CreditLoc.Text));
                        db_.AddParameter("recptNo", DbType.String, textBox_ID.Text);
                        db_.AddParameter("Lin", DbType.Int32, 2);
                        db_.AddParameter("AccNoDestruction", DbType.String, null);
                        db_.ExecuteNonQueryWithoutCommit(storedProcedure: true, "S_T_GDDET_INSERT");
                        db_.EndTransaction();
                        db_.StartTransaction();
                        db_.ClearParameters();
                        db_.AddParameter("GDDET_ID", DbType.Int32, 0);
                        db_.AddParameter("gdID", DbType.Int32, _GdHead.gdhead_ID);
                        db_.AddParameter("gdNo", DbType.String, textBox_ID.Text);
                        db_.AddParameter("gdDes", DbType.String, "قيد تلقائي لفاتورة مرتجع مبيعات رقم : " + textBox_ID.Text);
                        db_.AddParameter("gdDesE", DbType.String, "Auto Bound To Sales Return Invoice No : " + textBox_ID.Text);
                        db_.AddParameter("recptTyp", DbType.String, "3");
                        db_.AddParameter("AccNo", DbType.String, AccDbt_Credit);
                        db_.AddParameter("AccName", DbType.String, string.Empty);
                        db_.AddParameter("gdValue", DbType.Double, double.Parse(doubleInput_CreditLoc.Text));
                        db_.AddParameter("recptNo", DbType.String, textBox_ID.Text);
                        db_.AddParameter("Lin", DbType.Int32, 2);
                        db_.AddParameter("AccNoDestruction", DbType.String, null);
                        db_.ExecuteNonQueryWithoutCommit(storedProcedure: true, "S_T_GDDET_INSERT");
                        db_.EndTransaction();
                    }
                }
                else if (State == FormState.Edit && data_this.GadeId.HasValue)
                {
                    db.ExecuteCommand("UPDATE T_GDHEAD SET T_GDHEAD.gdLok = 1  where gdhead_ID = " + data_this.GadeId);
                }
                dbInstance = null;
                textBox_ID_TextChanged(null, null);
                if ((txtPaymentLoc.Value > 0.0 && !string.IsNullOrEmpty(AccCrdt) && !string.IsNullOrEmpty(AccDbt)) || (doubleInput_NetWorkLoc.Value > 0.0 && !string.IsNullOrEmpty(AccCrdt_NewtWork) && !string.IsNullOrEmpty(AccDbt_NetWork)) || (doubleInput_CreditLoc.Value > 0.0 && !string.IsNullOrEmpty(AccCrdt_Credit) && !string.IsNullOrEmpty(AccDbt_Credit)))
                {
                    data_this.GadeId = _GdHead.gdhead_ID;
                    data_this.GadeNo = int.Parse(textBox_ID.Text);
                }
                else
                {
                    data_this.GadeId = null;
                    data_this.GadeNo = null;
                }
                db.Log = VarGeneral.DebugLog;
                db.SubmitChanges(ConflictMode.ContinueOnConflict);
                MessageBox.Show((LangArEn == 0) ? "لقد تم اتمام العملية بنجاح .." : "This Opration Is Done", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                if (ButReturn.Tag.ToString() != "0")
                {
                    try
                    {
                        if (data_this.PaymentOrderTyp.GetValueOrDefault() > 0)
                        {
                            db.ExecuteCommand("UPDATE [T_INVHED] SET [IfRet] = 1,[DeleteTime] = '" + data_this.InvHed_ID + "' where InvTyp = " + data_thisRe.InvTyp.Value + " and InvHed_ID = " + data_thisRe.InvHed_ID);
                        }
                        else
                        {
                            data_thisRe.IfRet = 1;
                            data_thisRe.DeleteTime = data_this.InvHed_ID.ToString();
                            dbReturn.Log = VarGeneral.DebugLog;
                            dbReturn.SubmitChanges(ConflictMode.ContinueOnConflict);
                        }
                    }
                    catch
                    {
                        data_thisRe.IfRet = 1;
                        data_thisRe.DeleteTime = data_this.InvHed_ID.ToString();
                        dbReturn.Log = VarGeneral.DebugLog;
                        dbReturn.SubmitChanges(ConflictMode.ContinueOnConflict);
                    }
                }
                superTabControl_Info.SelectedTabIndex = 0;
                if (checkBox_CostGaidTax.Checked && !string.IsNullOrEmpty(txtDebit5.Tag.ToString()) && !string.IsNullOrEmpty(txtCredit5.Tag.ToString()) && txtTotTax.Value > 0.0)
                {
                    CreateCostGaidTax(AccCrdt_Cost_Tax, AccDbt_Cost_Tax);
                }
                if (checkBox_GaidDis.Checked && !string.IsNullOrEmpty(txtDebit6.Tag.ToString()) && !string.IsNullOrEmpty(txtCredit6.Tag.ToString()) && txtTotDis.Value > 0.0)
                {
                    CreateCostGaidDis(AccCrdt_Cost_Dis, AccDbt_Cost_Dis);
                }
            }
            catch (Exception ex8)
            {
                VarGeneral.DebLog.writeLog("MainSaveData:", ex8, enable: true);
                MessageBox.Show(ex8.Message);
                return false;
            }
            return true;
        }
        private void CreateCostGaidDis(string AccCrdt_Cost, string AccDbt_Cost)
        {
            IDatabase db_ = Database.GetDatabase(VarGeneral.BranchCS);
            using (Stock_DataDataContext dbc = new Stock_DataDataContext(VarGeneral.BranchCS))
            {
                _GdHeadCostDis = new T_GDHEAD();
                if (!data_this.DisGaidID1.HasValue)
                {
                    GetDataGdCostDis();
                    _GdHeadCostDis.DATE_CREATED = DateTime.Now;
                    dbc.T_GDHEADs.InsertOnSubmit(_GdHeadCostDis);
                    dbc.SubmitChanges();
                }
                else
                {
                    _GdHeadCostDis = dbc.StockGdHeadid((int)data_this.DisGaidID1.Value).First();
                    GetDataGdCostDis();
                    dbc.Log = VarGeneral.DebugLog;
                    dbc.SubmitChanges(ConflictMode.ContinueOnConflict);
                    for (int i = 0; i < _GdHeadCostDis.T_GDDETs.Count; i++)
                    {
                        db_.StartTransaction();
                        db_.ClearParameters();
                        db_.AddParameter("GDDET_ID", DbType.Int32, _GdHeadCostDis.T_GDDETs[i].GDDET_ID);
                        db_.ExecuteNonQueryWithoutCommit(storedProcedure: true, "S_T_GDDET_DELETE");
                        db_.EndTransaction();
                    }
                }
                db_.StartTransaction();
                db_.ClearParameters();
                db_.AddParameter("GDDET_ID", DbType.Int32, 0);
                db_.AddParameter("gdID", DbType.Int32, _GdHeadCostDis.gdhead_ID);
                db_.AddParameter("gdNo", DbType.String, textBox_ID.Text);
                db_.AddParameter("gdDes", DbType.String, "سند بقيمة الخصم لفاتورة مرتجع مبيعات رقم : " + textBox_ID.Text);
                db_.AddParameter("gdDesE", DbType.String, "Discount Value To Sales Return Invoice No : " + textBox_ID.Text);
                db_.AddParameter("recptTyp", DbType.String, "1");
                db_.AddParameter("AccNo", DbType.String, AccCrdt_Cost);
                db_.AddParameter("AccName", DbType.String, string.Empty);
                db_.AddParameter("gdValue", DbType.Double, 0.0 - txtTotDis.Value);
                db_.AddParameter("recptNo", DbType.String, textBox_ID.Text);
                db_.AddParameter("Lin", DbType.Int32, 1);
                db_.AddParameter("AccNoDestruction", DbType.String, null);
                db_.ExecuteNonQueryWithoutCommit(storedProcedure: true, "S_T_GDDET_INSERT");
                db_.EndTransaction();
                db_.StartTransaction();
                db_.ClearParameters();
                db_.AddParameter("GDDET_ID", DbType.Int32, 0);
                db_.AddParameter("gdID", DbType.Int32, _GdHeadCostDis.gdhead_ID);
                db_.AddParameter("gdNo", DbType.String, textBox_ID.Text);
                db_.AddParameter("gdDes", DbType.String, "سند بقيمة الخصم لفاتورة مرتجع مبيعات رقم : " + textBox_ID.Text);
                db_.AddParameter("gdDesE", DbType.String, "Discount Value To Sales Return Invoice No : " + textBox_ID.Text);
                db_.AddParameter("recptTyp", DbType.String, "1");
                db_.AddParameter("AccNo", DbType.String, AccDbt_Cost);
                db_.AddParameter("AccName", DbType.String, string.Empty);
                db_.AddParameter("gdValue", DbType.Double, txtTotDis.Value);
                db_.AddParameter("recptNo", DbType.String, textBox_ID.Text);
                db_.AddParameter("Lin", DbType.Int32, 2);
                db_.AddParameter("AccNoDestruction", DbType.String, null);
                db_.ExecuteNonQueryWithoutCommit(storedProcedure: true, "S_T_GDDET_INSERT");
                db_.EndTransaction();
            }
            dbInstance = null;
            textBox_ID_TextChanged(null, null);
            data_this.DisGaidID1 = _GdHeadCostDis.gdhead_ID;
            db.Log = VarGeneral.DebugLog;
            db.SubmitChanges(ConflictMode.ContinueOnConflict);
        }
        private void CreateCostGaidTax(string AccCrdt_Cost, string AccDbt_Cost)
        {
            IDatabase db_ = Database.GetDatabase(VarGeneral.BranchCS);
            using (Stock_DataDataContext dbc = new Stock_DataDataContext(VarGeneral.BranchCS))
            {
                _GdHeadCostTax = new T_GDHEAD();
                if (!data_this.TaxGaidID.HasValue)
                {
                    GetDataGdCostTax();
                    _GdHeadCostTax.DATE_CREATED = DateTime.Now;
                    dbc.T_GDHEADs.InsertOnSubmit(_GdHeadCostTax);
                    dbc.SubmitChanges();
                }
                else
                {
                    _GdHeadCostTax = dbc.StockGdHeadid((int)data_this.TaxGaidID.Value).First();
                    GetDataGdCostTax();
                    dbc.Log = VarGeneral.DebugLog;
                    dbc.SubmitChanges(ConflictMode.ContinueOnConflict);
                    for (int i = 0; i < _GdHeadCostTax.T_GDDETs.Count; i++)
                    {
                        db_.StartTransaction();
                        db_.ClearParameters();
                        db_.AddParameter("GDDET_ID", DbType.Int32, _GdHeadCostTax.T_GDDETs[i].GDDET_ID);
                        db_.ExecuteNonQueryWithoutCommit(storedProcedure: true, "S_T_GDDET_DELETE");
                        db_.EndTransaction();
                    }
                }
                db_.StartTransaction();
                db_.ClearParameters();
                db_.AddParameter("GDDET_ID", DbType.Int32, 0);
                db_.AddParameter("gdID", DbType.Int32, _GdHeadCostTax.gdhead_ID);
                db_.AddParameter("gdNo", DbType.String, textBox_ID.Text);
                db_.AddParameter("gdDes", DbType.String, "سند بقيمة الخصم لفاتورة مرتجع مبيعات رقم : " + textBox_ID.Text);
                db_.AddParameter("gdDesE", DbType.String, "Discount Value To Sales Return Invoice No : " + textBox_ID.Text);
                db_.AddParameter("recptTyp", DbType.String, "1");
                db_.AddParameter("AccNo", DbType.String, AccCrdt_Cost);
                db_.AddParameter("AccName", DbType.String, string.Empty);
                db_.AddParameter("gdValue", DbType.Double, 0.0 - txtTotTax.Value);
                db_.AddParameter("recptNo", DbType.String, textBox_ID.Text);
                db_.AddParameter("Lin", DbType.Int32, 1);
                db_.AddParameter("AccNoDestruction", DbType.String, null);
                db_.ExecuteNonQueryWithoutCommit(storedProcedure: true, "S_T_GDDET_INSERT");
                db_.EndTransaction();
                db_.StartTransaction();
                db_.ClearParameters();
                db_.AddParameter("GDDET_ID", DbType.Int32, 0);
                db_.AddParameter("gdID", DbType.Int32, _GdHeadCostTax.gdhead_ID);
                db_.AddParameter("gdNo", DbType.String, textBox_ID.Text);
                db_.AddParameter("gdDes", DbType.String, "سند بقيمة الخصم لفاتورة مرتجع مبيعات رقم : " + textBox_ID.Text);
                db_.AddParameter("gdDesE", DbType.String, "Discount Value To Sales Return Invoice No : " + textBox_ID.Text);
                db_.AddParameter("recptTyp", DbType.String, "1");
                db_.AddParameter("AccNo", DbType.String, AccDbt_Cost);
                db_.AddParameter("AccName", DbType.String, string.Empty);
                db_.AddParameter("gdValue", DbType.Double, txtTotTax.Value);
                db_.AddParameter("recptNo", DbType.String, textBox_ID.Text);
                db_.AddParameter("Lin", DbType.Int32, 2);
                db_.AddParameter("AccNoDestruction", DbType.String, null);
                db_.ExecuteNonQueryWithoutCommit(storedProcedure: true, "S_T_GDDET_INSERT");
                db_.EndTransaction();
            }
            dbInstance = null;
            textBox_ID_TextChanged(null, null);
            data_this.TaxGaidID = _GdHeadCostTax.gdhead_ID;
            db.Log = VarGeneral.DebugLog;
            db.SubmitChanges(ConflictMode.ContinueOnConflict);
        }
        private T_INVHED GetData()
        {
            txtDueAmountLoc.ValueChanged -= txtDueAmountLoc_ValueChanged;
            try
            {
                GetInvTot();
            }
            catch
            {
            }
            txtDueAmountLoc.ValueChanged += txtDueAmountLoc_ValueChanged;
            try
            {
                if (CmbInvPrice.SelectedIndex >= 0)
                {
                    data_this.CustPri = CmbInvPrice.SelectedIndex;
                }
                else
                {
                    data_this.CustPri = 0;
                }
            }
            catch
            {
                data_this.CustPri = 0;
            }
            data_this.IfEnter = 0;
            data_this.PaymentOrderTyp = CmbInvSide.SelectedIndex;
            data_this.EstDat = string.Empty;
            data_this.InvCashPayNm = string.Empty;
            data_this.DeleteDate = string.Empty;
            data_this.DeleteTime = string.Empty;
            try
            {
                if (CmbLegate.SelectedIndex != -1)
                {
                    T_Mndob q = db.StockMndobID(int.Parse(CmbLegate.SelectedValue.ToString()));
                    if (q.Comm_Inv.Value > 0.0 && txtDueAmountLoc.Value > 0.0)
                    {
                        data_this.CommMnd_Inv = txtDueAmountLoc.Value * (q.Comm_Inv.Value / 100.0);
                    }
                    else
                    {
                        data_this.CommMnd_Inv = 0.0;
                    }
                }
                else
                {
                    data_this.CommMnd_Inv = 0.0;
                }
            }
            catch
            {
                data_this.CommMnd_Inv = 0.0;
            }
            data_this.CusVenNm = txtCustName.Text;
            data_this.CusVenNo = txtCustNo.Text;
            data_this.CusVenAdd = txtAddress.Text;
            data_this.CusVenTel = txtTele.Text;
            data_this.Remark = txtRemark.Text;
            data_this.InvNo = textBox_ID.Text;
            data_this.CusVenMob = text_Mobile.Text;
            data_this.PriceIncludTax = ChkPriceIncludeTax.Value;
            data_this.CashPay = txtPaymentLoc.Value;
            data_this.PriceIncludTax = (ChkPriceIncludeTax.Value);
            try
            {
                data_this.CurTyp = int.Parse(CmbCurr.SelectedValue.ToString());
            }
            catch
            {
                data_this.CurTyp = null;
            }
            data_this.CustNet = txtCustNet.Value;
            data_this.CustRep = txtCustRep.Value;
            data_this.CusVenNm = txtCustName.Text;
            data_this.CusVenNo = txtCustNo.Text;
            data_this.HDat = txtHDate.Text;
            data_this.GDat = txtGDate.Text;
            if (State == FormState.New && VarGeneral.TString.ChkStatShow(VarGeneral.UserPassQty, 10))
            {
                data_this.AdminLock = true;
            }
            else
            {
                data_this.AdminLock = switchButton_Lock.Value;
            }
            try
            {
                if (checkBox_Chash.Checked || checkBox_NetWork.Checked)
                {
                    data_this.InvCashPay = 0;
                }
                else if (checkBox_Credit.Checked)
                {
                    data_this.InvCashPay = 1;
                }
                else
                {
                    data_this.InvCashPay = 2;
                }
            }
            catch
            {
                data_this.InvCashPay = 0;
            }
            try
            {
                if (checkBox_Chash.Checked)
                {
                    data_this.InvCash = checkBox_Chash.Text;
                }
                else if (checkBox_Credit.Checked)
                {
                    data_this.InvCash = checkBox_Credit.Text;
                }
                else
                {
                    data_this.InvCash = checkBox_NetWork.Text;
                }
            }
            catch
            {
                data_this.InvCash = "نقدي";
            }
            data_this.InvCost = txtInvCost.Value;
            try
            {
                data_this.InvCstNo = int.Parse(CmbCostC.SelectedValue.ToString());
            }
            catch
            {
                data_this.InvCstNo = null;
            }
            data_this.InvDisPrs = txtDiscountP.Value;
            data_this.InvDisVal = txtDiscountVal.Value;
            data_this.InvDisValLocCur = txtDiscountValLoc.Value;
            data_this.DesPointsValue = txtDiscoundPoints.Value;
            data_this.DesPointsValueLocCur = txtDiscoundPointsLoc.Value;
            data_this.PointsCount = txtPointCount.Value;
            data_this.IsPoints = switchButton_PointActiv.Value;
            data_this.InvNet = txtDueAmount.Value;
            data_this.InvNetLocCur = txtDueAmountLoc.Value;
            data_this.InvQty = txtTotalQ.Value;
            data_this.InvTot = txtTotalAm.Value;
            data_this.InvTotLocCur = txtTotalAmLoc.Value;
            data_this.InvTyp = VarGeneral.InvTyp;
            data_this.IfDel = 0;
            data_this.LTim = txtTime.Text;
            if (CmbLegate.SelectedIndex > 0)
            {
                data_this.MndNo = int.Parse(CmbLegate.SelectedValue.ToString());
            }
            else
            {
                data_this.MndNo = null;
            }
            data_this.MndExtrnal = false;
            data_this.RefNo = txtRef.Text;
            try
            {
                data_this.MODIFIED_BY = txtDescription.Text;
            }
            catch
            {
            }
            listCurency = db.Fillcurency_2(string.Empty).ToList();
            if (listCurency.Count > 0)
            {
                _Curency = listCurency[0];
            }
            data_this.ArbTaf = ScriptNumber1.ScriptNum(decimal.Parse(VarGeneral.TString.TEmpty(txtDueAmountLoc.Text ?? string.Empty))) + " " + _Curency.Arb_Des + " " + "فقط لاغير ";
            data_this.EngTaf = ScriptNumber1.TafEng(decimal.Parse(VarGeneral.TString.TEmpty(txtDueAmountLoc.Text ?? string.Empty))) + " " + _Curency.Eng_Des;
            data_this.DATE_MODIFIED = DateTime.Now;
            data_this.CreditPay = doubleInput_CreditLoc.Value;
            data_this.NetworkPay = doubleInput_NetWorkLoc.Value;
            data_this.CashPayLocCur = txtPaymentLoc.Value;
            data_this.CreditPayLocCur = doubleInput_CreditLoc.Value;
            data_this.NetworkPayLocCur = doubleInput_NetWorkLoc.Value;
            data_this.Puyaid = 0.0;
            data_this.Remming = 0.0;
            data_this.CompanyID = 1;
            data_this.tailor20 = "0";
            data_this.RoomNo = 1;
            data_this.OrderTyp = 1;
            data_this.RoomSts = false;
            data_this.RoomPerson = 1;
            data_this.ServiceValue = 0.0;
            data_this.Sts = false;
            data_this.chauffeurNo = null;
            data_this.InvAddTax = txtTotTax.Value;
            data_this.InvAddTaxlLoc = txtTotTaxLoc.Value;
            if (switchButton_Tax.Value)
            {
                data_this.IsTaxUse = true;
            }
            else
            {
                data_this.IsTaxUse = false;
            }
            if (switchButton_TaxLines.Value)
            {
                data_this.IsTaxLines = true;
            }
            else
            {
                data_this.IsTaxLines = false;
            }
            if (switchButton_TaxByTotal.Value)
            {
                data_this.IsTaxByTotal = true;
            }
            else
            {
                data_this.IsTaxByTotal = false;
            }
            if (switchButton_TaxByNet.Value)
            {
                data_this.IsTaxByNet = true;
            }
            else
            {
                data_this.IsTaxByNet = false;
            }
            try
            {
                data_this.TaxByNetValue = double.Parse(textBoxItem_TaxByNetValue.Text);
            }
            catch
            {
                data_this.TaxByNetValue = 0.0;
            }
            data_this.IsTaxGaid = checkBox_CostGaidTax.Checked;
            data_this.InvValGaidDis = txtTotDis.Value;
            data_this.InvValGaidDislLoc = txtTotDisLoc.Value;
            if (switchButton_Dis.Value)
            {
                data_this.IsDisUse1 = true;
            }
            else
            {
                data_this.IsDisUse1 = false;
            }
            data_this.IsDisGaid = checkBox_GaidDis.Checked;
            data_this.InvComm = 0.0;
            data_this.InvCommLoc = 0.0;
            data_this.IsCommUse = false;
            data_this.IsCommGaid = false;
            return data_this;
        }
        private T_GDHEAD GetDataGdCostDis()
        {
            _GdHeadCostDis.gdHDate = txtHDate.Text;
            _GdHeadCostDis.gdGDate = txtGDate.Text;
            _GdHeadCostDis.gdNo = textBox_ID.Text;
            _GdHeadCostDis.ArbTaf = ScriptNumber1.ScriptNum(decimal.Parse("0" + txtTotDis.Text));
            _GdHeadCostDis.BName = _GdHeadCostDis.BName;
            _GdHeadCostDis.ChekNo = _GdHeadCostDis.ChekNo;
            _GdHeadCostDis.CurTyp = int.Parse(CmbCurr.SelectedValue.ToString());
            _GdHeadCostDis.EngTaf = ScriptNumber1.TafEng(decimal.Parse("0" + txtTotDis.Text));
            _GdHeadCostDis.gdCstNo = int.Parse(CmbCostC.SelectedValue.ToString());
            _GdHeadCostDis.gdID = 0;
            _GdHeadCostDis.gdLok = false;
            _GdHeadCostDis.AdminLock = switchButton_Lock.Value;
            _GdHeadCostDis.gdMem = "سند بقيمة الخصم|Discount Value";
            if (CmbLegate.SelectedIndex > 0)
            {
                _GdHeadCostDis.gdMnd = int.Parse(CmbLegate.SelectedValue.ToString());
            }
            else
            {
                _GdHeadCostDis.gdMnd = null;
            }
            _GdHeadCostDis.gdRcptID = (_GdHeadCostDis.gdRcptID.HasValue ? _GdHeadCostDis.gdRcptID.Value : 0.0);
            _GdHeadCostDis.gdTot = txtTotDis.Value;
            _GdHeadCostDis.gdTp = (_GdHeadCostDis.gdTp.HasValue ? _GdHeadCostDis.gdTp.Value : 0);
            _GdHeadCostDis.gdTyp = VarGeneral.InvTyp;
            _GdHeadCostDis.RefNo = txtRef.Text;
            _GdHeadCostDis.DATE_MODIFIED = DateTime.Now;
            _GdHeadCostDis.salMonth = string.Empty;
            _GdHeadCostDis.gdUser = VarGeneral.UserNumber;
            _GdHeadCostDis.gdUserNam = VarGeneral.UserNameA;
            _GdHeadCostDis.CompanyID = 1;
            return _GdHeadCostDis;
        }
        private T_GDHEAD GetDataGdCostTax()
        {
            _GdHeadCostTax.gdHDate = txtHDate.Text;
            _GdHeadCostTax.gdGDate = txtGDate.Text;
            _GdHeadCostTax.gdNo = textBox_ID.Text;
            _GdHeadCostTax.ArbTaf = ScriptNumber1.ScriptNum(decimal.Parse("0" + txtTotTax.Text));
            _GdHeadCostTax.BName = _GdHeadCostTax.BName;
            _GdHeadCostTax.ChekNo = _GdHeadCostTax.ChekNo;
            _GdHeadCostTax.CurTyp = int.Parse(CmbCurr.SelectedValue.ToString());
            _GdHeadCostTax.EngTaf = ScriptNumber1.TafEng(decimal.Parse("0" + txtTotTax.Text));
            _GdHeadCostTax.gdCstNo = int.Parse(CmbCostC.SelectedValue.ToString());
            _GdHeadCostTax.gdID = 0;
            _GdHeadCostTax.gdLok = false;
            _GdHeadCostTax.AdminLock = switchButton_Lock.Value;
            _GdHeadCostTax.gdMem = "سند بقيمة الضريبة|Tax Value";
            if (CmbLegate.SelectedIndex > 0)
            {
                _GdHeadCostTax.gdMnd = int.Parse(CmbLegate.SelectedValue.ToString());
            }
            else
            {
                _GdHeadCostTax.gdMnd = null;
            }
            _GdHeadCostTax.gdRcptID = (_GdHeadCostTax.gdRcptID.HasValue ? _GdHeadCostTax.gdRcptID.Value : 0.0);
            _GdHeadCostTax.gdTot = txtTotTax.Value;
            _GdHeadCostTax.gdTp = (_GdHeadCostTax.gdTp.HasValue ? _GdHeadCostTax.gdTp.Value : 0);
            _GdHeadCostTax.gdTyp = VarGeneral.InvTyp;
            _GdHeadCostTax.RefNo = txtRef.Text;
            _GdHeadCostTax.DATE_MODIFIED = DateTime.Now;
            _GdHeadCostTax.salMonth = string.Empty;
            _GdHeadCostTax.gdUser = VarGeneral.UserNumber;
            _GdHeadCostTax.gdUserNam = VarGeneral.UserNameA;
            _GdHeadCostTax.CompanyID = 1;
            return _GdHeadCostTax;
        }
        private T_GDHEAD GetDataGd()
        {
            _GdHead.gdHDate = txtHDate.Text;
            _GdHead.gdGDate = txtGDate.Text;
            _GdHead.gdNo = textBox_ID.Text;
            _GdHead.ArbTaf = ScriptNumber1.ScriptNum(decimal.Parse("0" + txtDueAmountLoc.Text));
            _GdHead.BName = _GdHead.BName;
            _GdHead.ChekNo = _GdHead.ChekNo;
            _GdHead.CurTyp = int.Parse(CmbCurr.SelectedValue.ToString());
            _GdHead.EngTaf = ScriptNumber1.TafEng(decimal.Parse("0" + txtDueAmountLoc.Text));
            _GdHead.gdCstNo = int.Parse(CmbCostC.SelectedValue.ToString());
            _GdHead.gdID = 0;
            _GdHead.gdLok = false;
            _GdHead.gdMem = txtRemark.Text;
            if (CmbLegate.SelectedIndex > 0)
            {
                _GdHead.gdMnd = int.Parse(CmbLegate.SelectedValue.ToString());
            }
            else
            {
                _GdHead.gdMnd = null;
            }
            _GdHead.gdRcptID = (_GdHead.gdRcptID.HasValue ? _GdHead.gdRcptID.Value : 0.0);
            _GdHead.gdTot = txtDueAmountLoc.Value;
            _GdHead.gdTp = (_GdHead.gdTp.HasValue ? _GdHead.gdTp.Value : 0);
            _GdHead.gdTyp = VarGeneral.InvTyp;
            _GdHead.AdminLock = switchButton_Lock.Value;
            _GdHead.RefNo = txtRef.Text;
            _GdHead.DATE_MODIFIED = DateTime.Now;
            _GdHead.salMonth = string.Empty;
            _GdHead.gdUser = VarGeneral.UserNumber;
            _GdHead.gdUserNam = VarGeneral.UserNameA;
            _GdHead.CompanyID = 1;
            return _GdHead;
        }
        object getdata(
       int r, int c, int f)
        {
            if (r <= 0 || FlxInv.GetData(r, 8) == null) return null;
            double p = 0;
            p = double.Parse(FlxInv.GetData(r, 8).ToString());
            //if(f==1)
            //{
            //    double t = 0;
            //    double.Parse(FlxInv.GetData(r, 31).ToString(), out t);
            //    t = (t / 100) + 1;
            //  if(ChkPriceIncludeTax.Value)  p = p * t;
            //}
            return p;
        }
        private void FlxInv_AfterEdit(object sender, RowColEventArgs e)
        {
            try
            {
                if (permission.MaxDiscountSals.Value > 0.0 && double.Parse(FlxInv.GetData(e.Row, 9).ToString()) > permission.MaxDiscountSals.Value)
                {
                    FlxInv.SetData(e.Row, 9, 0);
                }
            }
            catch
            {
            }
            double ItmDis = 0.0;
            double ItmAddTax = 0.0;
            ItmAddTax = Math.Round(double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 8)))) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 31)))) / 100.0), VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2);
            if (!switchButton_TaxLines.Value || switchButton_TaxByTotal.Value)
            {
                ItmAddTax = 0.0;
            }
            ItmDis = double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 8)))) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 9)))) / 100.0);
            try
            {
                if ((File.Exists(Application.StartupPath + "\\Script\\SecriptColDisSalesReturn.dll") || (VarGeneral.gUserName == "runsetting" && File.Exists(Application.StartupPath + "\\Script\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\SecriptColDisSalesReturn.dll"))) && double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 36)))) > 0.0)
                {
                    ItmDis += double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 8)))) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 36)))) / 100.0);
                }
            }
            catch
            {
            }
            try
            {
                if (File.Exists(Application.StartupPath + "\\Script\\SecriptColDisSalesReturnValue.dll") || (VarGeneral.gUserName == "runsetting" && File.Exists(Application.StartupPath + "\\Script\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\SecriptColDisSalesReturnValue.dll")))
                {
                    ItmDis += double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 36))));
                }
            }
            catch
            {
            }
            if (e.Col == 1)
            {
                BindDataOfItem();
                if (FlxInv.GetData(e.Row, 1) != null)
                    FlxInv_AfterEdit(null, new RowColEventArgs(e.Row, 8));
            }
            else if (((e.Col == 2 || e.Col == 4) && (string)FlxInv.GetData(e.Row, 1) == string.Empty) || FlxInv.GetData(e.Row, 1) == null)
            {
                BindDataOfItem(); if (FlxInv.GetData(e.Row, 1) != null) FlxInv_AfterEdit(null, new RowColEventArgs(e.Row, 8));
            }
            else if ((e.Col == 3 || e.Col == 5) && FlxInv.GetData(e.Row, e.Col).ToString() != oldUnit)
            {
                int ItemIndex = -1;
                if (e.Col == 3)
                {
                    string[] Items = FlxInv.Cols[e.Col].ComboList.Split('|');
                    for (int i = 0; i < Items.Length; i++)
                    {
                        if (Items[i] == FlxInv.GetData(e.Row, e.Col).ToString())
                        {
                            ItemIndex = i + 1;
                        }
                    }
                    string[] Items2 = FlxInv.Cols[5].ComboList.Split('|');
                    if (Items2.Length > 1 && ItemIndex > -1)
                    {
                        FlxInv.SetData(e.Row, 5, Items2[ItemIndex - 1]);
                    }
                }
                else if (e.Col == 5)
                {
                    string[] Items = FlxInv.Cols[e.Col].ComboList.Split('|');
                    for (int i = 0; i < Items.Length; i++)
                    {
                        if (Items[i] == FlxInv.GetData(e.Row, e.Col).ToString())
                        {
                            ItemIndex = i + 1;
                        }
                    }
                    string[] Items2 = FlxInv.Cols[3].ComboList.Split('|');
                    if (Items2.Length > 1 && ItemIndex > -1)
                    {
                        FlxInv.SetData(e.Row, 3, Items2[ItemIndex - 1]);
                    }
                }
                switch (ItemIndex)
                {
                    case 1:
                        FlxInv.SetData(FlxInv.Row, 8, _Items.UntPri1.Value / RateValue);
                        FlxInv.SetData(FlxInv.Row, 11, _Items.Pack1.Value);
                        break;
                    case 2:
                        FlxInv.SetData(FlxInv.Row, 8, _Items.UntPri2.Value / RateValue);
                        FlxInv.SetData(FlxInv.Row, 11, _Items.Pack2.Value);
                        break;
                    case 3:
                        FlxInv.SetData(FlxInv.Row, 8, _Items.UntPri3.Value / RateValue);
                        FlxInv.SetData(FlxInv.Row, 11, _Items.Pack3.Value);
                        break;
                    case 4:
                        FlxInv.SetData(FlxInv.Row, 8, _Items.UntPri4.Value / RateValue);
                        FlxInv.SetData(FlxInv.Row, 11, _Items.Pack4.Value);
                        break;
                    case 5:
                        FlxInv.SetData(FlxInv.Row, 8, _Items.UntPri5.Value / RateValue);
                        FlxInv.SetData(FlxInv.Row, 11, _Items.Pack5.Value);
                        break;
                }
                Pack = ItemIndex;
                BindDataofItemPrice();
                if (ChkPriceIncludeTax.Value)
                {
                    if (!newprice)
                    {
                        PriceLoc = without; pricel = without; without = pricel;
                    }
                }
                else
                { PriceLoc = double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 8)))); pricel = PriceLoc; without = pricel; }
                FlxInv_AfterEdit(null, new RowColEventArgs(e.Row, 8));//p
                FlxInv.SetData(e.Row, 12, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 11)))));
                FlxInv.SetData(e.Row, 38, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 8)))) - ItmDis + ItmAddTax);
                if (switchButton_TaxByTotal.Value && switchButton_TaxLines.Value && double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 38)))) > 0.0)
                {
                    ItmAddTax = Math.Round((double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 8)))) - ItmDis) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 31)))) / 100.0), VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2);
                    FlxInv.SetData(e.Row, 38, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 38)))) + ItmAddTax);
                }
                PriceLoc = double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 8)))); pricel = PriceLoc;
                BindDataOfStkQty(FlxInv.GetData(e.Row, 1).ToString()); FlxInv_AfterEdit(null, new RowColEventArgs(e.Row, 8));
                if (CmbCurr.SelectedIndex != -1)
                {
                    List<T_Curency> listSer = db.StockCurrList(int.Parse(CmbCurr.SelectedValue.ToString()));
                    T_Curency _Curency = listSer[0];
                    double CurRate = _Curency.Rate.Value;
                }
                FlxInv.SetData(e.Row, 26, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 8)))) / 1.0);
                try
                {
                    ItmDis = double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 8)))) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 9)))) / 100.0);
                    try
                    {
                        if ((File.Exists(Application.StartupPath + "\\Script\\SecriptColDisSalesReturn.dll") || (VarGeneral.gUserName == "runsetting" && File.Exists(Application.StartupPath + "\\Script\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\SecriptColDisSalesReturn.dll"))) && double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 36)))) > 0.0)
                        {
                            ItmDis += double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 8)))) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 36)))) / 100.0);
                        }
                    }
                    catch
                    {
                    }
                    try
                    {
                        if (File.Exists(Application.StartupPath + "\\Script\\SecriptColDisSalesReturnValue.dll") || (VarGeneral.gUserName == "runsetting" && File.Exists(Application.StartupPath + "\\Script\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\SecriptColDisSalesReturnValue.dll")))
                        {
                            ItmDis += double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 36))));
                        }
                    }
                    catch
                    {
                    }
                    ItmAddTax = Math.Round(double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 8)))) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 31)))) / 100.0), VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2);
                    if (!switchButton_TaxLines.Value || switchButton_TaxByTotal.Value)
                    {
                        ItmAddTax = 0.0;
                    }
                    FlxInv.SetData(e.Row, 38, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 8)))) - ItmDis + ItmAddTax);
                    if (switchButton_TaxByTotal.Value && switchButton_TaxLines.Value && double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 38)))) > 0.0)
                    {
                        ItmAddTax = Math.Round((double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 8)))) - ItmDis) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 31)))) / 100.0), VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2);
                        FlxInv.SetData(e.Row, 38, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 38)))) + ItmAddTax);
                    }
                }
                catch
                {
                }
                double qty = 0.0;
                string unt = string.Empty;
                string itm_nm = string.Empty;
                try
                {
                    itm_nm = string.Concat(FlxInv.GetData(e.Row, 1));
                }
                catch
                {
                    itm_nm = string.Empty;
                }
                try
                {
                    unt = string.Concat(FlxInv.GetData(e.Row, 3));
                }
                catch
                {
                    unt = string.Empty;
                }
                try
                {
                    qty = double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.Row, 7))));
                }
                catch
                {
                    qty = 0.0;
                }
                if (CmbInvSide.SelectedIndex <= 0)
                {
                    RemoveOFFerLines(FlxInv.Row + 1);
                    CheckOffers(itm_nm, unt, qty, FlxInv.Row, FlxInv.Row);
                }
            }
            else if (e.Col == 6)
            {
                listStkQty = (from t in db.T_STKSQTies
                              where t.itmNo == FlxInv.GetData(e.Row, 1).ToString()
                              where t.storeNo == (int?)int.Parse(FlxInv.GetData(e.Row, 6).ToString())
                              select t).ToList();
                if (listStkQty.Count != 0)
                {
                    _StksQty = listStkQty[0];
                    FlxInv.SetData(e.Row, 24, _StksQty.stkQty.ToString());
                }
                else
                {
                    FlxInv.SetData(e.Row, 24, 0);
                }
                if (string.Concat(FlxInv.GetData(e.Row, 28)) == "1")
                {
                    FlxDat.Clear(ClearFlags.Content, 1, 0, FlxDat.Rows.Count - 1, 1);
                    listQtyExp = (from t in db.T_QTYEXPs
                                  where t.itmNo == FlxInv.GetData(e.Row, 1).ToString()
                                  where t.storeNo == (int?)int.Parse(FlxInv.GetData(e.Row, 6).ToString())
                                  select t).ToList();
                    if (listQtyExp.Count != 0)
                    {
                        for (int iiCnt = 0; iiCnt < listQtyExp.Count; iiCnt++)
                        {
                            _QtyExp = listQtyExp[iiCnt];
                            FlxDat.Rows.Count = iiCnt + 2;
                            FlxDat.SetData(iiCnt + 1, 0, _QtyExp.DatExper.ToString());
                            FlxDat.SetData(iiCnt + 1, 1, _QtyExp.stkQty.Value.ToString());
                            FlxDat.SetData(iiCnt + 1, 2, _QtyExp.RunCod.ToString());
                        }
                        FlxDat.Visible = true;
                        FlxDat.Focus();
                    }
                    else
                    {
                        FlxDat.Visible = false;
                    }
                }
            }
            else if (e.Col == 7 || e.Col == 8)
            {
                double RealQ = 0.0;
                RealQ = double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 11))));
                if (e.Col == 7 && double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 32)))) != 3.0)
                {
                }
                if (File.Exists(Application.StartupPath + "\\Script\\SecriptCeramicQty.dll") && e.Col == 7)
                {
                    try
                    {
                        if (!string.IsNullOrEmpty(string.Concat(FlxInv.GetData(e.Row, e.Col))) && !string.IsNullOrEmpty(_Items.SecriptCeramic) && !string.IsNullOrEmpty(_Items.SecriptCeramicCombo))
                        {
                            int z = -1;
                            for (int i = 0; i < _Items.SecriptCeramic.Length; i++)
                            {
                                if (_Items.SecriptCeramic.Substring(i, 1) == ".")
                                {
                                    z = i;
                                    break;
                                }
                            }
                            if (z >= 0)
                            {
                                string cc = _Items.SecriptCeramic.Substring(z + 1);
                                if (!string.IsNullOrEmpty(cc))
                                {
                                    string Zer_ = string.Empty;
                                    for (int i = 0; i < cc.Length; i++)
                                    {
                                        Zer_ += "0";
                                    }
                                    int val_ = int.Parse("1" + Zer_);
                                    FlxInv.SetData(e.Row, 36, Math.Round(double.Parse(FlxInv.GetData(e.Row, e.Col).ToString()) / (((_Items.SecriptCeramicCombo == "0") ? _Items.Pack1.Value : ((_Items.SecriptCeramicCombo == "1") ? _Items.Pack2.Value : ((_Items.SecriptCeramicCombo == "2") ? _Items.Pack3.Value : ((_Items.SecriptCeramicCombo == "3") ? _Items.Pack4.Value : _Items.Pack5.Value)))) / (double)val_), VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2));
                                }
                            }
                        }
                    }
                    catch
                    {
                    }
                }
                if (e.Col == 8)
                {

                      if (pricel != lastprice)
                    {
                        if (ChkPriceIncludeTax.Value == true)
                        {
                            double p = getround(caltax(without, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 31))))));
                            {
                                FlxInv.SetData(e.Row, 8, p); ; lastprice = double.Parse(FlxInv.GetData(e.Row, e.Col).ToString()); lastprice = getround(lastprice);
                            }
                        }
                        else
                            FlxInv.SetData(e.Row, 8, without); ; lastprice = double.Parse(FlxInv.GetData(e.Row, e.Col).ToString()); lastprice = getround(lastprice);
                    }

      }
                FlxInv.SetData(e.Row, 12, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 11)))));
                FlxInv.SetData(e.Row, 38, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 8)))) - ItmDis + ItmAddTax);
                if (switchButton_TaxByTotal.Value && switchButton_TaxLines.Value && double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 38)))) > 0.0)
                {
                    ItmAddTax = Math.Round((double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 8)))) - ItmDis) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 31)))) / 100.0), VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2);
                    FlxInv.SetData(e.Row, 38, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 38)))) + ItmAddTax);
                }
                chekReptItem(Col_1: false);
                double qty = 0.0;
                string unt = string.Empty;
                string itm_nm = string.Empty;
                try
                {
                    bool ChekOfferStat = false;
                    try
                    {
                        if (FlxInv.GetData(e.Row, 39).ToString() == "1")
                        {
                            ChekOfferStat = true;
                        }
                    }
                    catch
                    {
                    }
                    if (!string.IsNullOrEmpty(FlxInv.GetData(e.Row, 1).ToString()) && !ChekOfferStat)
                    {
                        try
                        {
                            itm_nm = string.Concat(FlxInv.GetData(e.Row, 1));
                        }
                        catch
                        {
                            itm_nm = string.Empty;
                        }
                        try
                        {
                            unt = string.Concat(FlxInv.GetData(e.Row, 3));
                        }
                        catch
                        {
                            unt = string.Empty;
                        }
                        try
                        {
                            qty = double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.Row, 7))));
                        }
                        catch
                        {
                            qty = 0.0;
                        }
                        if (CmbInvSide.SelectedIndex <= 0)
                        {
                            RemoveOFFerLines(e.Row + 1);
                            CheckOffers(itm_nm, unt, qty, e.Row, e.Row);
                        }
                    }
                }
                catch
                {
                }
            }
            else if (e.Col == 9)
            {
                FlxInv.SetData(e.Row, 38, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 8)))) - ItmDis + ItmAddTax);
                if (switchButton_TaxByTotal.Value && switchButton_TaxLines.Value && double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 38)))) > 0.0)
                {
                    ItmAddTax = Math.Round((double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 8)))) - ItmDis) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 31)))) / 100.0), VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2);
                    FlxInv.SetData(e.Row, 38, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 38)))) + ItmAddTax);
                }
            }
            else if (e.Col == 38)
            {
                if (switchButton_TaxByTotal.Value && switchButton_TaxLines.Value && double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 38)))) > 0.0)
                {
                    ItmAddTax = Math.Round((double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 8)))) - ItmDis) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 31)))) / 100.0), VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2);
                }
                if (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 38)))) != Math.Round(double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 8)))) - ItmDis + ItmAddTax, VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2))
                {
                    if (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7)))) == 0.0)
                    {
                        MessageBox.Show((LangArEn == 0) ? "يجب تحديد الكمية" : "Must Enter The Quantity", VarGeneral.ProdectNam);
                        FlxInv.SetData(e.Row, 38, 0);
                        FlxInv.Col = 7;
                        FlxInv.Row = e.Row;
                        FlxInv.Focus();
                    }
                    else
                    {
                        if (enteredtotal != 0)
                        {
                            double fs = 0;
                            fs = double.Parse((double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 38)))) / double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7))))).ToString()); without = fs;
                            newprice = true;
                            if (ChkPriceIncludeTax.Value == false)
                                FlxInv.SetData(e.Row, 8, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 38)))) / double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7)))));
                            else
                            {
                                without = fs;
                                newprice = true;
                                double p = getround(caltax(without, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 31))))));
                                FlxInv.SetData(e.Row, 8, p);
                            }
                            FlxInv_AfterEdit(null, new RowColEventArgs(e.Row, 8));
                        }
                        else
                        {
                            FlxInv.SetData(e.Row, 8, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 38)))) / double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7)))));
                        }
                        FlxInv.SetData(e.Row, 9, 0);
                    }
                }
            }
            else if (e.Col == 36)
            {
                if (File.Exists(Application.StartupPath + "\\Script\\SecriptCeramic.dll"))
                {
                    try
                    {
                        if (!string.IsNullOrEmpty(string.Concat(FlxInv.GetData(e.Row, e.Col))) && !string.IsNullOrEmpty(_Items.SecriptCeramic) && !string.IsNullOrEmpty(_Items.SecriptCeramicCombo))
                        {
                            int z = -1;
                            for (int i = 0; i < _Items.SecriptCeramic.Length; i++)
                            {
                                if (_Items.SecriptCeramic.Substring(i, 1) == ".")
                                {
                                    z = i;
                                    break;
                                }
                            }
                            if (z >= 0)
                            {
                                string cc = _Items.SecriptCeramic.Substring(z + 1);
                                if (!string.IsNullOrEmpty(cc))
                                {
                                    string Zer_ = string.Empty;
                                    for (int i = 0; i < cc.Length; i++)
                                    {
                                        Zer_ += "0";
                                    }
                                    int val_ = int.Parse("1" + Zer_);
                                    FlxInv.SetData(e.Row, 7, Math.Round(double.Parse(FlxInv.GetData(e.Row, e.Col).ToString()) * (((_Items.SecriptCeramicCombo == "0") ? _Items.Pack1.Value : ((_Items.SecriptCeramicCombo == "1") ? _Items.Pack2.Value : ((_Items.SecriptCeramicCombo == "2") ? _Items.Pack3.Value : ((_Items.SecriptCeramicCombo == "3") ? _Items.Pack4.Value : _Items.Pack5.Value)))) / (double)val_), VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2));
                                    FlxInv_AfterEdit(null, new RowColEventArgs(FlxInv.Row, 7));
                                }
                            }
                        }
                    }
                    catch
                    {
                    }
                }
                try
                {
                    if (File.Exists(Application.StartupPath + "\\Script\\SecriptColDisSalesReturn.dll") || (VarGeneral.gUserName == "runsetting" && File.Exists(Application.StartupPath + "\\Script\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\SecriptColDisSalesReturn.dll")))
                    {
                        FlxInv_AfterEdit(null, new RowColEventArgs(FlxInv.Row, 9));
                    }
                }
                catch
                {
                }
                try
                {
                    if (File.Exists(Application.StartupPath + "\\Script\\SecriptColDisSalesReturnValue.dll") || (VarGeneral.gUserName == "runsetting" && File.Exists(Application.StartupPath + "\\Script\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\SecriptColDisSalesReturnValue.dll")))
                    {
                        FlxInv_AfterEdit(null, new RowColEventArgs(FlxInv.Row, 9));
                    }
                }
                catch
                {
                }
            }
            else if (e.Col == 37)
            {
                try
                {
                    if (!string.IsNullOrEmpty(string.Concat(FlxInv.GetData(e.Row, e.Col))))
                    {
                        List<T_ItemSerial> q = (from t in db.T_ItemSerials
                                                where t.ItmNo == FlxInv.GetData(e.Row, 1).ToString()
                                                where t.SerialKey == FlxInv.GetData(e.Row, 37).ToString()
                                                select t).ToList();
                        if (q.Count > 0)
                        {
                            if (q == null || string.IsNullOrEmpty(q.FirstOrDefault().SerialKey))
                            {
                                FlxInv.SetData(e.Row, e.Col, string.Empty);
                            }
                        }
                        else
                        {
                            FlxInv.SetData(e.Row, e.Col, string.Empty);
                        }
                    }
                }
                catch
                {
                    FlxInv.SetData(e.Row, e.Col, string.Empty);
                }
                chekReptItem(Col_1: false);
            }
            else if (e.Col == 31)
            {
                if (ChkPriceIncludeTax.Value)
                {
                    pricel = without; lastprice = 0;
                    edit = false;
                    if (without >= 1000)
                    { }
                    FlxInv_AfterEdit(null, new RowColEventArgs(e.Row, 8));
                }
                FlxInv.SetData(e.Row, 38, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 8)))) - ItmDis + ItmAddTax);
                if (switchButton_TaxByTotal.Value && switchButton_TaxLines.Value && double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 38)))) > 0.0)
                {
                    ItmAddTax = Math.Round((double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 8)))) - ItmDis) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 31)))) / 100.0), VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2);
                    FlxInv.SetData(e.Row, 38, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 38)))) + ItmAddTax);
                }
            }
            else if (e.Col == 33 && Convert.ToBoolean(FlxInv.GetData(e.Row, 33)))
            {
                ItmAddTax = 0.0;
                ItmDis = 0.0;
                FlxInv.SetData(e.Row, 8, 0);
                FlxInv.SetData(e.Row, 9, 0);
                FlxInv.SetData(e.Row, 31, 0);
                FlxInv.SetData(e.Row, 38, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 8)))) - ItmDis + ItmAddTax);
            }
            VarGeneral.Flush();
            GetInvTot();
            try
            {
                double OldValueDis = txtDiscountVal.Value;
                txtDiscountVal.Value = txtTotalAmLoc.Value * (txtDiscountP.Value / 100.0);
                txtDiscountValLoc.Value = txtDiscountVal.Value * RateValue;
                if (OldValueDis != txtDiscountVal.Value)
                {
                    GetInvTot();
                }
            }
            catch
            {
            }
        }
        private void FlxInv_BeforeEdit(object sender, RowColEventArgs e)
        {
            try
            {
                if ((e.Col == 3 || e.Col == 5) && FlxInv.GetData(e.Row, e.Col) != null)
                {
                    oldUnit = FlxInv.GetData(e.Row, 3).ToString() ?? string.Empty;
                }
            }
            catch
            {
            }
            try
            {
                if (!File.Exists(Application.StartupPath + "\\Script\\SecriptColDisSalesReturn.dll") && (!(VarGeneral.gUserName == "runsetting") || !File.Exists(Application.StartupPath + "\\Script\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\SecriptColDisSalesReturn.dll")) && !File.Exists(Application.StartupPath + "\\Script\\SecriptColDisSalesReturnValue.dll") && (!(VarGeneral.gUserName == "runsetting") || !File.Exists(Application.StartupPath + "\\Script\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\SecriptColDisSalesReturnValue.dll")) && FlxInv.Col == 36 && VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 66))
                {
                    FlxInv.BeforeEdit -= FlxInv_BeforeEdit;
                    int vRowIndex = FlxInv.Row;
                    FrmInvDetNoteSrch frm = new FrmInvDetNoteSrch();
                    frm.Tag = LangArEn;
                    try
                    {
                        frm.textbox_Detailes.Text = FlxInv.GetData(vRowIndex, 36).ToString() ?? string.Empty;
                    }
                    catch
                    {
                        frm.textbox_Detailes.Text = string.Empty;
                    }
                    frm.TopMost = true;
                    frm.ShowDialog();
                    if (frm.SerachNo != string.Empty)
                    {
                        FlxInv.SetData(vRowIndex, 36, string.Empty);
                        FlxInv.SetData(vRowIndex, 36, FlxInv.GetData(vRowIndex, 36).ToString() + frm.SerachNo);
                    }
                    SendKeys.SendWait("{ENTER}");
                    FlxInv.BeforeEdit += FlxInv_BeforeEdit;
                }
            }
            catch
            {
                FlxInv.BeforeEdit += FlxInv_BeforeEdit;
            }
            try
            {
                if (e.Col == 37)
                {
                    FlxSerial.Clear(ClearFlags.Content, 1, 0, FlxSerial.Rows.Count - 1, 1);
                    listSerialQty = (from t in db.T_ItemSerials
                                     orderby t.id
                                     where t.ItmNo == FlxInv.GetData(e.Row, 1).ToString()
                                     select t).ToList();
                    if (listSerialQty.Count != 0)
                    {
                        T_ItemSerial vEmpty = new T_ItemSerial();
                        vEmpty.id = 0;
                        vEmpty.ItmNo = string.Empty;
                        vEmpty.SerialKey = string.Empty;
                        vEmpty.SerialStatus = false;
                        listSerialQty.Add(vEmpty);
                        for (int iiCnt = 0; iiCnt < listSerialQty.Count; iiCnt++)
                        {
                            _SerialQty = listSerialQty[iiCnt];
                            FlxSerial.Rows.Count = iiCnt + 2;
                            FlxSerial.SetData(iiCnt + 1, 0, _SerialQty.SerialKey.ToString());
                            FlxSerial.SetData(iiCnt + 1, 1, _SerialQty.ItmNo);
                            FlxSerial.SetData(iiCnt + 1, 2, string.IsNullOrEmpty(_SerialQty.SerialKey) ? string.Empty : (_SerialQty.SerialStatus.Value ? ((LangArEn == 0) ? "مستخدم" : "Used") : ((LangArEn == 0) ? "غير مستخدم" : "Un Used")));
                        }
                        FlxSerial.Visible = true;
                        FlxSerial.Focus();
                    }
                    else
                    {
                        FlxSerial.Visible = false;
                    }
                }
            }
            catch
            {
                FlxInv.SetData(FlxInv.Row, 37, string.Empty);
            }
            GridDetUpdate(FlxInv.RowSel);
        }
        bool enterflag = false, edit = false, modefiy = false; double pt = 0, tt = 0;
        private void FlxInv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                try
                {
                    if (FlxInv.GetData(RowSel, 1).ToString() != null)
                    {
                        if (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 32)))) == 2.0)
                        {
                            ItemDetRemoved.Add(int.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 25)))));
                        }
                        if ((FlxInv.GetData(FlxInv.RowSel, 39).ToString() ?? string.Empty) != string.Empty && CmbInvSide.SelectedIndex <= 0)
                        {
                            if (FlxInv.GetData(FlxInv.RowSel, 39).ToString() == "1")
                            {
                                return;
                            }
                            if (FlxInv.GetData(FlxInv.RowSel, 39).ToString() == "0")
                            {
                                FlxInv.RemoveItem(FlxInv.Row);
                                GetInvTot();
                                RemoveOFFerLines(FlxInv.RowSel);
                            }
                        }
                        else
                        {
                            FlxInv.RemoveItem(FlxInv.Row);
                            GetInvTot();
                        }
                    }
                }
                catch
                {
                    FlxInv.RemoveItem(FlxInv.Row);
                    GetInvTot();
                }
            }
            try
            {
            }
            catch
            {
            }
            if (
                              char.IsLetterOrDigit((char)e.KeyValue))
            {
                edit = true;
            }
            else
                edit = false;
        }
        private void RemoveOFFerLines(int RowLines)
        {
            try
            {
                int i = RowLines;
                while (i < VarGeneral.Settings_Sys.LineOfInvoices.Value + 1000 && FlxInv.GetData(i, 39).ToString() == "1")
                {
                    FlxInv.RemoveItem(i);
                    GetInvTot();
                    i--;
                    i++;
                }
            }
            catch
            {
            }
        }
        private void FlxInv_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                try
                {
                    if (string.Concat(FlxInv.GetData(FlxInv.RowSel, 1)) != string.Empty && State != 0)
                    {
                        _Items = db.StockItem(string.Concat(FlxInv.GetData(FlxInv.RowSel, 1)));
                        txtVCost.Text = string.Concat(Math.Round(_Items.AvrageCost.Value * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 11)))) / RateValue, VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2));
                        txtLCost.Text = string.Concat(Math.Round(_Items.LastCost.Value * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 11)))) / RateValue, VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2));
                        LastPrice(_Items);
                    }
                }
                catch
                {
                }
                if (!(string.Concat(FlxInv.GetData(FlxInv.RowSel, 1)) != string.Empty))
                {
                    return;
                }
                _Items = db.StockItem(string.Concat(FlxInv.GetData(FlxInv.RowSel, 1)));
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                {
                    txtItemName.Text = _Items.Arb_Des.Trim();
                }
                else
                {
                    txtItemName.Text = _Items.Eng_Des.Trim();
                }
                string CoA = string.Empty;
                string CoE = string.Empty;
                for (int iiCnt = 0; iiCnt < listUnit.Count; iiCnt++)
                {
                    _Unit = listUnit[iiCnt];
                    if (_Items.Unit1 == _Unit.Unit_ID)
                    {
                        if (CoA != string.Empty)
                        {
                            CoA += "|";
                            CoE += "|";
                        }
                        CoA += _Unit.Arb_Des;
                        CoE += _Unit.Eng_Des;
                        break;
                    }
                }
                for (int iiCnt = 0; iiCnt < listUnit.Count; iiCnt++)
                {
                    _Unit = listUnit[iiCnt];
                    if (_Items.Unit2 == _Unit.Unit_ID)
                    {
                        if (CoA != string.Empty)
                        {
                            CoA += "|";
                            CoE += "|";
                        }
                        CoA += _Unit.Arb_Des;
                        CoE += _Unit.Eng_Des;
                        break;
                    }
                }
                for (int iiCnt = 0; iiCnt < listUnit.Count; iiCnt++)
                {
                    _Unit = listUnit[iiCnt];
                    if (_Items.Unit3 == _Unit.Unit_ID)
                    {
                        if (CoA != string.Empty)
                        {
                            CoA += "|";
                            CoE += "|";
                        }
                        CoA += _Unit.Arb_Des;
                        CoE += _Unit.Eng_Des;
                        break;
                    }
                }
                for (int iiCnt = 0; iiCnt < listUnit.Count; iiCnt++)
                {
                    _Unit = listUnit[iiCnt];
                    if (_Items.Unit4 == _Unit.Unit_ID)
                    {
                        if (CoA != string.Empty)
                        {
                            CoA += "|";
                            CoE += "|";
                        }
                        CoA += _Unit.Arb_Des;
                        CoE += _Unit.Eng_Des;
                        break;
                    }
                }
                for (int iiCnt = 0; iiCnt < listUnit.Count; iiCnt++)
                {
                    _Unit = listUnit[iiCnt];
                    if (_Items.Unit5 == _Unit.Unit_ID)
                    {
                        if (CoA != string.Empty)
                        {
                            CoA += "|";
                            CoE += "|";
                        }
                        CoA += _Unit.Arb_Des;
                        CoE += _Unit.Eng_Des;
                        break;
                    }
                }
                FlxInv.Cols[3].ComboList = CoA;
                FlxInv.Cols[5].ComboList = CoE;
                txtVCost.Text = string.Concat(Math.Round(_Items.AvrageCost.Value * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 11)))) / RateValue, VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2));
                txtLCost.Text = string.Concat(Math.Round(_Items.LastCost.Value * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 11)))) / RateValue, VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2));
                LastPrice(_Items);
                txtVSerial.Text = _Items.SerialKey ?? string.Empty;
                BindDataOfStkQty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 1)));
            }
            catch
            {
            }
        }
        private void FlxInv_RowColChange(object sender, EventArgs e)
        {
            if (FlxInv.Col == 1)
            {
                Framework.Keyboard.Language.Switch("English");
            }
            if (FlxInv.Col == 2)
            {
                Framework.Keyboard.Language.Switch("Arabic");
            }
            if (FlxInv.Col == 4)
            {
                Framework.Keyboard.Language.Switch("English");
            }
        }
        private void FlxInv_SelChange(object sender, EventArgs e)
        {
            try
            {
                if (RowSel == 0 || RowSel == FlxInv.Row || !(string.Concat(FlxInv.GetData(FlxInv.Row, 1)) != string.Empty))
                {
                    return;
                }
                List<T_Item> listSer = new List<T_Item>();
                listSer = db.StockItemList(string.Concat(FlxInv.GetData(FlxInv.RowSel, 1)));
                if (listSer.Count == 0)
                {
                    return;
                }
                _Items = listSer[0];
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                {
                    txtItemName.Text = _Items.Arb_Des.Trim();
                }
                else
                {
                    txtItemName.Text = _Items.Eng_Des.Trim();
                }
                string CoA = string.Empty;
                string CoE = string.Empty;
                for (int iiCnt = 0; iiCnt < listUnit.Count; iiCnt++)
                {
                    _Unit = listUnit[iiCnt];
                    if (_Items.Unit1 == _Unit.Unit_ID)
                    {
                        if (CoA != string.Empty)
                        {
                            CoA += "|";
                            CoE += "|";
                        }
                        CoA += _Unit.Arb_Des;
                        CoE += _Unit.Eng_Des;
                        break;
                    }
                }
                for (int iiCnt = 0; iiCnt < listUnit.Count; iiCnt++)
                {
                    _Unit = listUnit[iiCnt];
                    if (_Items.Unit2 == _Unit.Unit_ID)
                    {
                        if (CoA != string.Empty)
                        {
                            CoA += "|";
                            CoE += "|";
                        }
                        CoA += _Unit.Arb_Des;
                        CoE += _Unit.Eng_Des;
                        break;
                    }
                }
                for (int iiCnt = 0; iiCnt < listUnit.Count; iiCnt++)
                {
                    _Unit = listUnit[iiCnt];
                    if (_Items.Unit3 == _Unit.Unit_ID)
                    {
                        if (CoA != string.Empty)
                        {
                            CoA += "|";
                            CoE += "|";
                        }
                        CoA += _Unit.Arb_Des;
                        CoE += _Unit.Eng_Des;
                        break;
                    }
                }
                for (int iiCnt = 0; iiCnt < listUnit.Count; iiCnt++)
                {
                    _Unit = listUnit[iiCnt];
                    if (_Items.Unit4 == _Unit.Unit_ID)
                    {
                        if (CoA != string.Empty)
                        {
                            CoA += "|";
                            CoE += "|";
                        }
                        CoA += _Unit.Arb_Des;
                        CoE += _Unit.Eng_Des;
                        break;
                    }
                }
                for (int iiCnt = 0; iiCnt < listUnit.Count; iiCnt++)
                {
                    _Unit = listUnit[iiCnt];
                    if (_Items.Unit5 == _Unit.Unit_ID)
                    {
                        if (CoA != string.Empty)
                        {
                            CoA += "|";
                            CoE += "|";
                        }
                        CoA += _Unit.Arb_Des;
                        CoE += _Unit.Eng_Des;
                        break;
                    }
                }
                FlxInv.Cols[3].ComboList = CoA;
                FlxInv.Cols[5].ComboList = CoE;
                txtVCost.Text = string.Concat(Math.Round(_Items.AvrageCost.Value * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 11)))) / RateValue, VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2));
                txtLCost.Text = string.Concat(Math.Round(_Items.LastCost.Value * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 11)))) / RateValue, VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2));
                LastPrice(_Items);
                txtVSerial.Text = _Items.SerialKey ?? string.Empty;
                BindDataOfStkQty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 1)));
            }
            catch
            {
            }
        }
        private void FlxDat_DoubleClick(object sender, EventArgs e)
        {
            if (FlxDat.MouseRow > 0)
            {
                //              fs=  double.Parse(FlxPrice.GetData(FlxPrice.Row, 1).ToString()); without = fs;
                FlxInv.SetData(FlxInv.Row, 27, FlxDat.GetData(FlxDat.Row, 0));
                FlxInv.SetData(FlxInv.Row, 24, FlxDat.GetData(FlxDat.Row, 1));
                FlxInv.SetData(FlxInv.Row, 35, FlxDat.GetData(FlxDat.Row, 2));
                FlxDat.Visible = false;
                FlxInv.Col = 6;
                FlxInv.Focus();
            }
        }
        private void FlxDat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return && FlxDat.Row > 0)
            {
                FlxInv.SetData(FlxInv.Row, 27, FlxDat.GetData(FlxDat.Row, 0));
                FlxInv.SetData(FlxInv.Row, 24, FlxDat.GetData(FlxDat.Row, 1));
                FlxInv.SetData(FlxInv.Row, 35, FlxDat.GetData(FlxDat.Row, 2));
                FlxDat.Visible = false;
                FlxInv.Col = 6;
                FlxInv.Focus();
            }
        }
        private void FlxDat_Leave(object sender, EventArgs e)
        {
            if (FlxDat.Visible && State == FormState.New)
            {
                FlxDat.Focus();
            }
            else
            {
                FlxDat.Visible = false;
            }
        }
        private void FlxSerial_DoubleClick(object sender, EventArgs e)
        {
            if (FlxSerial.MouseRow > 0)
            {
                FlxInv.SetData(FlxInv.Row, 37, FlxSerial.GetData(FlxSerial.Row, 0));
                FlxSerial.Visible = false;
                FlxInv.Col = 37;
                FlxInv.Focus();
            }
        }
        private void FlxSerial_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return && FlxSerial.Row > 0)
            {
                FlxInv.SetData(FlxInv.Row, 37, FlxSerial.GetData(FlxSerial.Row, 0));
                FlxSerial.Visible = false;
                FlxInv.Col = 37;
                FlxInv.Focus();
            }
        }
        private void FlxSerial_Leave(object sender, EventArgs e)
        {
            if (FlxSerial.Visible && State == FormState.New)
            {
                FlxSerial.Focus();
            }
            else
            {
                FlxSerial.Visible = false;
            }
        }
        double caltax(double amount, double taxpercent)
        {
            without = amount;
            if (switchButton_TaxByNet.Value)
                if (textBoxItem_TaxByNetValue.Text.ToString() != string.Empty) taxpercent = double.Parse(textBoxItem_TaxByNetValue.Text);
                else
            if (switchButton_TaxByTotal.Value == false && switchButton_TaxLines.Value == false) taxpercent = 0;
            if (taxpercent != 0)
            {
                taxpercent = taxpercent / 100;
                taxpercent++;
                return getround(amount / taxpercent);
            }
            else return getround(amount);
        }
        double Rcaltax(double amount, double taxpercent)
        {
            if (switchButton_TaxByNet.Value)
                if (textBoxItem_TaxByNetValue.Text.ToString() != string.Empty) taxpercent = double.Parse(textBoxItem_TaxByNetValue.Text);
                else
            if (switchButton_TaxByTotal.Value == false && switchButton_TaxLines.Value == false) taxpercent = 0;
            if (taxpercent != 0)
            {
                taxpercent = taxpercent / 100;
                taxpercent++;
                without = getround(amount * taxpercent);
                return getround(amount * taxpercent);
            }
            else return getround(amount);
        }
        double ta = 0.0, tl = 0.0;
        private void BindDataOfItem()
        {
            Balance_Qty = -1.0;
            Balance_Price = -1.0;
            if (CmbLegate.SelectedIndex <= 0 && CmbInvSide.SelectedIndex == 1)
            {
                MessageBox.Show((LangArEn == 0) ? "يجب تحديد المندوب الخارجي لهذه البضاعة قبل عرض الأصناف" : "You must specify the external representative of these goods ", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                CmbLegate.Focus();
                return;
            }
            if (CmbInvSide.SelectedIndex > 1 && txtCustNo.Text == string.Empty && VarGeneral.SSSLev != "M")
            {
                MessageBox.Show((LangArEn == 0) ? "يجب تحديد العميل / المورد لهذه البضاعة قبل عرض الأصناف" : "You must specify the Customer/Supplier of these goods ", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                CmbLegate.Focus();
                return;
            }
            RemoveOFFerLines(FlxInv.Row + 1);
            columns_Names_visible2.Clear();
            columns_Names_visible2.Add("Itm_No", new ColumnDictinary("رقم الصنف", "Item No", ifDefault: true, string.Empty));
            columns_Names_visible2.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, string.Empty));
            columns_Names_visible2.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: false, string.Empty));
            columns_Names_visible2.Add("StartCost", new ColumnDictinary("التكلفةالافتتاحية", "Start Cost", ifDefault: false, string.Empty));
            columns_Names_visible2.Add("AvrageCost", new ColumnDictinary("متوسط التكلفة", "Average Cost", ifDefault: false, string.Empty));
            columns_Names_visible2.Add("LastCost", new ColumnDictinary("آخر تكلفة", "Last Cost", ifDefault: false, string.Empty));
            if (CmbInvSide.SelectedIndex <= 0)
            {
                columns_Names_visible2.Add("Arb_Des_Cat", new ColumnDictinary("الاسم العربي لمجموعة الصنف", "CATEGORY Arabic Name", ifDefault: false, string.Empty));
                columns_Names_visible2.Add("Eng_Des_Cat", new ColumnDictinary("الاسم الانجليزي لمجموعة الصنف", "CATEGORY English Name", ifDefault: false, string.Empty));
            }
            List<T_Item> listSer = new List<T_Item>();
            bool Barcod = false;
            if ((string)FlxInv.GetData(FlxInv.Row, 1) != string.Empty && FlxInv.GetData(FlxInv.Row, 1) != null)
            {
                Barcod = ChkBarCod((string)FlxInv.GetData(FlxInv.Row, 1));
                if (!Barcod || (VarGeneral.SSSLev != "D" && VarGeneral.SSSLev != "G" && VarGeneral.SSSLev != "S" && VarGeneral.SSSLev != "B" && VarGeneral.SSSLev != "F" && VarGeneral.SSSLev != "C" && VarGeneral.SSSLev != "R" && VarGeneral.SSSLev != "H" && VarGeneral.SSSLev != "M"))
                {
                    listSer = db.StockItemList(FlxInv.GetData(FlxInv.Row, 1).ToString());
                    if (listSer.Count != 0)
                    {
                        if (listSer[0].InvSaleReturnStoped.Value)
                        {
                            listSer = new List<T_Item>();
                        }
                        else
                        {
                            _Items = listSer[0];
                        }
                    }
                }
            }
            else if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 30) && CmbInvSide.SelectedIndex <= 0)
            {
                string _SearchNo = string.Empty;
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_Items ";
                string Fields = string.Empty;
                Fields = ((LangArEn != 0) ? " T_Items.Itm_No as [ID Number], T_Items.Itm_No as [Item No] , T_Items.Arb_Des as [Arabic Description], T_Items.Eng_Des as [English Description] , T_Items.OpenQty as [Quantity]  " : " T_Items.Itm_No as [رقم التعريف], T_Items.Itm_No as [رقــم الصنــــف] , T_Items.Arb_Des as [الوصــف العربـــي], T_Items.Eng_Des as [الوصــف إنجلـــيزي] , T_Items.OpenQty as [الكمية] ");
                _RepShow.Rule = " Where 1 = 1 and T_Items.ItmTyp != 1 and InvSaleReturnStoped = 0 ";
                try
                {
                    db.ExecuteCommand("select " + Fields + " From " + _RepShow.Tables + _RepShow.Rule + " order by  CONVERT(INT, LEFT(T_Items.Itm_No, PATINDEX('%[^0-9]%', T_Items.Itm_No + 'z')-1)) ");
                    _RepShow.Rule += " order by  CONVERT(INT, LEFT(T_Items.Itm_No, PATINDEX('%[^0-9]%', T_Items.Itm_No + 'z')-1)) ";
                }
                catch
                {
                    _RepShow.Rule += " order by T_Items.Itm_No ";
                }
                if (!string.IsNullOrEmpty(Fields))
                {
                    _RepShow.Fields = Fields;
                    _RepShow = _RepShow.Save();
                    VarGeneral.RepData = _RepShow.RepData;
                    if (VarGeneral.RepData.Tables[0].Rows.Count == 0)
                    {
                        return;
                    }
                    string ItmDes = string.Empty;
                    int ItmDesIndex = 1;
                    if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                    {
                        if ((string)FlxInv.GetData(FlxInv.Row, 2) != string.Empty && FlxInv.GetData(FlxInv.Row, 2) != null)
                        {
                            ItmDes = (string)FlxInv.GetData(FlxInv.Row, 2);
                            ItmDesIndex = 2;
                        }
                    }
                    else if ((string)FlxInv.GetData(FlxInv.Row, 4) != string.Empty && FlxInv.GetData(FlxInv.Row, 4) != null)
                    {
                        ItmDes = (string)FlxInv.GetData(FlxInv.Row, 4);
                        ItmDesIndex = 3;
                    }
                    FMFind FmQuikSerch = new FMFind(ItmDes, ItmDesIndex);
                    FmQuikSerch.Tag = LangArEn;
                    FmQuikSerch.TopMost = true;
                    FmQuikSerch.ShowDialog();
                    _SearchNo = FmQuikSerch.SerachNo;
                }
                if (!(_SearchNo != string.Empty))
                {
                    try
                    {
                        FlxInv.RemoveItem(FlxInv.Row);
                        try
                        {
                            FlxInv.Rows.Add();
                        }
                        catch
                        {
                        }
                        FlxInv.Row = FlxInv.RowSel;
                        FlxInv.Col = 1;
                    }
                    catch
                    {
                    }
                    return;
                }
                listSer = db.StockItemList(_SearchNo);
                _Items = listSer[0];
            }
            else
            {
                List<T_Item> q = (from t in db.T_Items
                                  where t.ItmTyp != (int?)1 && !t.InvSaleReturnStoped.Value
                                  orderby t.Itm_No
                                  select t).ToList();
                if (q.Count == 0)
                {
                    return;
                }
                string ItmDes = string.Empty;
                int ItmDesIndex = 1;
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                {
                    if ((string)FlxInv.GetData(FlxInv.Row, 2) != string.Empty && FlxInv.GetData(FlxInv.Row, 2) != null)
                    {
                        ItmDes = (string)FlxInv.GetData(FlxInv.Row, 2);
                        ItmDesIndex = 2;
                    }
                }
                else if ((string)FlxInv.GetData(FlxInv.Row, 4) != string.Empty && FlxInv.GetData(FlxInv.Row, 4) != null)
                {
                    ItmDes = (string)FlxInv.GetData(FlxInv.Row, 4);
                    ItmDesIndex = 3;
                }
                FrmSearch FmSerch = new FrmSearch();
                if (CmbInvSide.SelectedIndex > 0)
                {
                    VarGeneral.SFrmTyp = "T_InvGridExtrnalReturnSal";
                    VarGeneral.vItmTyp = 1;
                    VarGeneral.vMnd = ((CmbInvSide.SelectedIndex == 1) ? int.Parse(CmbLegate.SelectedValue.ToString()) : int.Parse(txtCustNo.Text));
                }
                else
                {
                    VarGeneral.SFrmTyp = "T_InvGrid";
                    VarGeneral.vItmTyp = 1;
                }
                FmSerch.Tag = LangArEn;
                VarGeneral.itmDes = ItmDes;
                VarGeneral.itmDesIndex = ItmDesIndex;
                ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible2;
                foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
                {
                    FmSerch.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
                }
                FmSerch.TopMost = true;
                FmSerch.ShowDialog();
                VarGeneral.itmDesIndex = 0;
                VarGeneral.itmDes = string.Empty;
                if (!(FmSerch.SerachNo != string.Empty))
                {
                    try
                    {
                        FlxInv.RemoveItem(FlxInv.Row);
                        try
                        {
                            FlxInv.Rows.Add();
                        }
                        catch
                        {
                        }
                        FlxInv.Row = FlxInv.RowSel;
                        FlxInv.Col = 1;
                    }
                    catch
                    {
                    }
                    return;
                }
                listSer = db.StockItemList(FmSerch.SerachNo);
                _Items = listSer[0];
            }
            if ((!Barcod || (VarGeneral.SSSLev != "D" && VarGeneral.SSSLev != "G" && VarGeneral.SSSLev != "S" && VarGeneral.SSSLev != "B" && VarGeneral.SSSLev != "F" && VarGeneral.SSSLev != "C" && VarGeneral.SSSLev != "R" && VarGeneral.SSSLev != "H" && VarGeneral.SSSLev != "M")) && listSer.Count == 0)
            {
                if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 30) && CmbInvSide.SelectedIndex <= 0)
                {
                    string _SearchNo = string.Empty;
                    RepShow _RepShow = new RepShow();
                    _RepShow.Tables = " T_Items ";
                    string Fields = string.Empty;
                    Fields = ((LangArEn != 0) ? " T_Items.Itm_No as [ID Number], T_Items.Itm_No as [Item No] , T_Items.Arb_Des as [Arabic Description], T_Items.Eng_Des as [English Description] , T_Items.OpenQty as [Quantity]  " : " T_Items.Itm_No as [رقم التعريف], T_Items.Itm_No as [رقــم الصنــــف] , T_Items.Arb_Des as [الوصــف العربـــي], T_Items.Eng_Des as [الوصــف إنجلـــيزي] , T_Items.OpenQty as [الكمية] ");
                    _RepShow.Rule = " Where 1 = 1 and T_Items.ItmTyp != 1 and InvSaleReturnStoped = 0";
                    try
                    {
                        db.ExecuteCommand("select " + Fields + " From " + _RepShow.Tables + _RepShow.Rule + " order by  CONVERT(INT, LEFT(T_Items.Itm_No, PATINDEX('%[^0-9]%', T_Items.Itm_No + 'z')-1)) ");
                        _RepShow.Rule += " order by  CONVERT(INT, LEFT(T_Items.Itm_No, PATINDEX('%[^0-9]%', T_Items.Itm_No + 'z')-1)) ";
                    }
                    catch
                    {
                        _RepShow.Rule += " order by T_Items.Itm_No ";
                    }
                    if (!string.IsNullOrEmpty(Fields))
                    {
                        _RepShow.Fields = Fields;
                        _RepShow = _RepShow.Save();
                        VarGeneral.RepData = _RepShow.RepData;
                        if (VarGeneral.RepData.Tables[0].Rows.Count == 0)
                        {
                            return;
                        }
                        FMFind FmQuikSerch = new FMFind((string)FlxInv.GetData(FlxInv.Row, 1), 1);
                        FmQuikSerch.Tag = LangArEn;
                        FmQuikSerch.TopMost = true;
                        FmQuikSerch.ShowDialog();
                        _SearchNo = FmQuikSerch.SerachNo;
                    }
                    if (!(_SearchNo != string.Empty))
                    {
                        try
                        {
                            FlxInv.RemoveItem(FlxInv.Row);
                            try
                            {
                                FlxInv.Rows.Add();
                            }
                            catch
                            {
                            }
                            FlxInv.Row = FlxInv.RowSel;
                            FlxInv.Col = 1;
                        }
                        catch
                        {
                        }
                        return;
                    }
                    listSer = db.StockItemList(_SearchNo);
                    _Items = listSer[0];
                }
                else
                {
                    List<T_Item> q = (from t in db.T_Items
                                      where t.ItmTyp != (int?)1 && !t.InvSaleReturnStoped.Value
                                      orderby t.Itm_No
                                      select t).ToList();
                    if (q.Count == 0)
                    {
                        return;
                    }
                    FrmSearch FmSerch = new FrmSearch();
                    if (CmbInvSide.SelectedIndex > 0)
                    {
                        VarGeneral.SFrmTyp = "T_InvGridExtrnalReturnSal";
                        VarGeneral.vItmTyp = 1;
                        VarGeneral.vMnd = ((CmbInvSide.SelectedIndex == 0) ? int.Parse(CmbLegate.SelectedValue.ToString()) : int.Parse(txtCustNo.Text));
                    }
                    else
                    {
                        VarGeneral.SFrmTyp = "T_InvGrid";
                        VarGeneral.vItmTyp = 1;
                    }
                    FmSerch.Tag = LangArEn;
                    VarGeneral.itmDes = (string)FlxInv.GetData(FlxInv.Row, 1);
                    VarGeneral.itmDesIndex = 1;
                    ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible2;
                    foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
                    {
                        FmSerch.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
                    }
                    FmSerch.TopMost = true;
                    FmSerch.ShowDialog();
                    VarGeneral.itmDesIndex = 0;
                    VarGeneral.itmDes = string.Empty;
                    if (!(FmSerch.SerachNo != string.Empty))
                    {
                        try
                        {
                            FlxInv.RemoveItem(FlxInv.Row);
                            try
                            {
                                FlxInv.Rows.Add();
                            }
                            catch
                            {
                            }
                            FlxInv.Row = FlxInv.RowSel;
                            FlxInv.Col = 1;
                        }
                        catch
                        {
                        }
                        return;
                    }
                    listSer = db.StockItemList(FmSerch.SerachNo);
                    _Items = listSer[0];
                }
            }
            FlxInv.SetData(FlxInv.Row, 1, _Items.Itm_No.Trim());
            FlxInv.SetData(FlxInv.Row, 2, _Items.Arb_Des.Trim());
            FlxInv.SetData(FlxInv.Row, 4, _Items.Eng_Des.Trim());
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
            {
                txtItemName.Text = _Items.Arb_Des.Trim();
            }
            else
            {
                txtItemName.Text = _Items.Eng_Des.Trim();
            }
            FlxInv.SetData(FlxInv.Row, 6, 1);
            try
            {
                if (permission.DefStores.HasValue && permission.DefStores.Value > 0)
                {
                    FlxInv.SetData(FlxInv.Row, 6, permission.DefStores.Value);
                }
            }
            catch
            {
                FlxInv.SetData(FlxInv.Row, 6, 1);
            }
            string CoA = string.Empty;
            string CoE = string.Empty;
            string DefUnitA = string.Empty;
            string DefUnitE = string.Empty;
            for (int iiCnt = 0; iiCnt < listUnit.Count; iiCnt++)
            {
                _Unit = listUnit[iiCnt];
                if (_Items.Unit1 == _Unit.Unit_ID)
                {
                    if (CoA != string.Empty)
                    {
                        CoA += "|";
                        CoE += "|";
                    }
                    CoA += _Unit.Arb_Des;
                    CoE += _Unit.Eng_Des;
                    if (_Items.DefultUnit == 1 && DefPack == 0)
                    {
                        Pack = _Items.Pack1.Value;
                        DefUnitA = _Unit.Arb_Des;
                        DefUnitE = _Unit.Eng_Des;
                        FlxInv.SetData(FlxInv.Row, 8, _Items.UntPri1.Value);
                        FlxInv.SetData(FlxInv.Row, 11, _Items.Pack1.Value);
                    }
                    else if (DefPack == 1)
                    {
                        Pack = _Items.Pack1.Value;
                        DefUnitA = _Unit.Arb_Des;
                        DefUnitE = _Unit.Eng_Des;
                        FlxInv.SetData(FlxInv.Row, 8, _Items.UntPri1.Value);
                        FlxInv.SetData(FlxInv.Row, 11, _Items.Pack1.Value);
                    }
                    break;
                }
            }
            for (int iiCnt = 0; iiCnt < listUnit.Count; iiCnt++)
            {
                _Unit = listUnit[iiCnt];
                if (_Items.Unit2 == _Unit.Unit_ID)
                {
                    if (CoA != string.Empty)
                    {
                        CoA += "|";
                        CoE += "|";
                    }
                    CoA += _Unit.Arb_Des;
                    CoE += _Unit.Arb_Des;
                    if (_Items.DefultUnit == 2 && DefPack == 0)
                    {
                        Pack = _Items.Pack2.Value;
                        DefUnitA = _Unit.Arb_Des;
                        DefUnitE = _Unit.Eng_Des;
                        FlxInv.SetData(FlxInv.Row, 8, _Items.UntPri2.Value);
                        FlxInv.SetData(FlxInv.Row, 11, _Items.Pack2.Value);
                    }
                    else if (DefPack == 2)
                    {
                        Pack = _Items.Pack2.Value;
                        DefUnitA = _Unit.Arb_Des;
                        DefUnitE = _Unit.Eng_Des;
                        FlxInv.SetData(FlxInv.Row, 8, _Items.UntPri2.Value);
                        FlxInv.SetData(FlxInv.Row, 11, _Items.Pack2.Value);
                    }
                    break;
                }
            }
            for (int iiCnt = 0; iiCnt < listUnit.Count; iiCnt++)
            {
                _Unit = listUnit[iiCnt];
                if (_Items.Unit3 == _Unit.Unit_ID)
                {
                    if (CoA != string.Empty)
                    {
                        CoA += "|";
                        CoE += "|";
                    }
                    CoA += _Unit.Arb_Des;
                    CoE += _Unit.Eng_Des;
                    if (_Items.DefultUnit == 3 && DefPack == 0)
                    {
                        Pack = _Items.Pack3.Value;
                        DefUnitA = _Unit.Arb_Des;
                        DefUnitE = _Unit.Eng_Des;
                        FlxInv.SetData(FlxInv.Row, 8, _Items.UntPri3.Value);
                        FlxInv.SetData(FlxInv.Row, 11, _Items.Pack3.Value);
                    }
                    else if (DefPack == 3)
                    {
                        Pack = _Items.Pack3.Value;
                        DefUnitA = _Unit.Arb_Des;
                        DefUnitE = _Unit.Eng_Des;
                        FlxInv.SetData(FlxInv.Row, 8, _Items.UntPri3.Value);
                        FlxInv.SetData(FlxInv.Row, 11, _Items.Pack3.Value);
                    }
                    break;
                }
            }
            for (int iiCnt = 0; iiCnt < listUnit.Count; iiCnt++)
            {
                _Unit = listUnit[iiCnt];
                if (_Items.Unit4 == _Unit.Unit_ID)
                {
                    if (CoA != string.Empty)
                    {
                        CoA += "|";
                        CoE += "|";
                    }
                    CoA += _Unit.Arb_Des;
                    CoE += _Unit.Eng_Des;
                    if (_Items.DefultUnit == 4 && DefPack == 0)
                    {
                        Pack = _Items.Pack4.Value;
                        DefUnitA = _Unit.Arb_Des;
                        DefUnitE = _Unit.Eng_Des;
                        FlxInv.SetData(FlxInv.Row, 8, _Items.UntPri4.Value);
                        FlxInv.SetData(FlxInv.Row, 11, _Items.Pack4.Value);
                    }
                    else if (DefPack == 4)
                    {
                        Pack = _Items.Pack4.Value;
                        DefUnitA = _Unit.Arb_Des;
                        DefUnitE = _Unit.Eng_Des;
                        FlxInv.SetData(FlxInv.Row, 8, _Items.UntPri4.Value);
                        FlxInv.SetData(FlxInv.Row, 11, _Items.Pack4.Value);
                    }
                    break;
                }
            }
            for (int iiCnt = 0; iiCnt < listUnit.Count; iiCnt++)
            {
                _Unit = listUnit[iiCnt];
                if (_Items.Unit5 == _Unit.Unit_ID)
                {
                    if (CoA != string.Empty)
                    {
                        CoA += "|";
                        CoE += "|";
                    }
                    CoA += _Unit.Arb_Des;
                    CoE += _Unit.Eng_Des;
                    if (_Items.DefultUnit == 5 && DefPack == 0)
                    {
                        Pack = _Items.Pack5.Value;
                        DefUnitA = _Unit.Arb_Des;
                        DefUnitE = _Unit.Eng_Des;
                        FlxInv.SetData(FlxInv.Row, 8, _Items.UntPri5.Value);
                        FlxInv.SetData(FlxInv.Row, 11, _Items.Pack5.Value);
                    }
                    else if (DefPack == 5)
                    {
                        Pack = _Items.Pack5.Value;
                        DefUnitA = _Unit.Arb_Des;
                        DefUnitE = _Unit.Eng_Des;
                        FlxInv.SetData(FlxInv.Row, 8, _Items.UntPri5.Value);
                        FlxInv.SetData(FlxInv.Row, 11, _Items.Pack5.Value);
                    }
                    break;
                }
            }
            FlxInv.Cols[3].ComboList = CoA;
            FlxInv.Cols[5].ComboList = CoE;
            double ItmPri = 0.0;
            FlxInv.SetData(FlxInv.Row, 3, DefUnitA);
            FlxInv.SetData(FlxInv.Row, 5, DefUnitE);
            BindDataofItemPrice();
            FlxInv.SetData(FlxInv.Row, 10, _Items.AvrageCost / RateValue);
            txtVCost.Text = string.Concat(Math.Round((_Items.AvrageCost * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.Row, 11))))).Value / RateValue, VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2));
            FlxInv.SetData(FlxInv.Row, 30, _Items.LastCost * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.Row, 11)))) / RateValue);
            txtLCost.Text = string.Concat(Math.Round((_Items.LastCost * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.Row, 11))))).Value / RateValue, VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2));
            txtVSerial.Text = _Items.SerialKey ?? string.Empty;
            FlxInv.SetData(FlxInv.Row, 28, _Items.Lot);
            if (_Items.Lot == 1)
            {
                FlxInv.Cols[27].Visible = true;
                FlxInv.Cols[35].Visible = true;
            }
            FlxInv.SetData(FlxInv.Row, 32, _Items.ItmTyp);
            FlxInv.SetData(FlxInv.Row, 33, _Items.ItmLoc);
            FlxInv.SetData(FlxInv.Row, 18, _Items.DefPack);
            FlxInv.SetData(FlxInv.Row, 19, _Items.Price1);
            FlxInv.SetData(FlxInv.Row, 20, _Items.Price2);
            FlxInv.SetData(FlxInv.Row, 21, _Items.Price3);
            FlxInv.SetData(FlxInv.Row, 22, _Items.Price4);
            FlxInv.SetData(FlxInv.Row, 23, _Items.Price5);
            if (Balance_Price >= 0.0)
            {
                FlxInv.SetData(FlxInv.Row, 8, Balance_Price);
            }
            else
            {
                FlxInv.SetData(FlxInv.Row, 8, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.Row, 8)))) / RateValue);
            }
            if (FlxInv.Cols[9].Visible)
            {
                FlxInv.SetData(FlxInv.Row, 9, _Items.ItemDis.Value);
            }
            else
            {
                FlxInv.SetData(FlxInv.Row, 9, 0);
            }
            try
            {
                if (txtCustNo.Text != string.Empty && FlxInv.Cols[9].Visible)
                {
                    T_AccDef h = db.StockAccDef(txtCustNo.Text);
                    if (h.MaxDisCust.Value > 0.0)
                    {
                        if (h.vColNum1.Value == 0.0)
                        {
                            FlxInv.SetData(FlxInv.Row, 9, h.MaxDisCust.Value);
                        }
                        else
                        {
                            FlxInv.SetData(FlxInv.Row, 9, 0);
                        }
                    }
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("MaxDisCust :", error, enable: true);
            }
            try
            {
                if (permission.MaxDiscountSals.Value > 0.0 && double.Parse(FlxInv.GetData(FlxInv.Row, 9).ToString()) > permission.MaxDiscountSals.Value)
                {
                    FlxInv.SetData(FlxInv.Row, 9, 0);
                }
            }
            catch
            {
            }
            if (FlxInv.Cols[31].Visible)
            {
                FlxInv.SetData(FlxInv.Row, 31, VarGeneral.TString.ChkStatShow(_InvSetting.TaxOptions, 2) ? _Items.TaxPurchas : _Items.TaxSales);
            }
            else
            {
                FlxInv.SetData(FlxInv.Row, 31, 0);
            }
            try
            {
                if (File.Exists(Application.StartupPath + "\\Script\\SecriptColDisSalesReturn.dll") || (VarGeneral.gUserName == "runsetting" && File.Exists(Application.StartupPath + "\\Script\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\SecriptColDisSalesReturn.dll")))
                {
                    FlxInv.SetData(FlxInv.Row, 36, 0);
                }
            }
            catch
            {
            }
            try
            {
                if (File.Exists(Application.StartupPath + "\\Script\\SecriptColDisSalesReturnValue.dll") || (VarGeneral.gUserName == "runsetting" && File.Exists(Application.StartupPath + "\\Script\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\SecriptColDisSalesReturnValue.dll")))
                {
                    FlxInv.SetData(FlxInv.Row, 36, 0);
                }
            }
            catch
            {
            }
            PriceLoc = (double)FlxInv.GetData(FlxInv.Row, 8);
            //pricel = PriceLoc;without = pricel;lastprice = 0;
            BindDataOfStkQty(_Items.Itm_No.Trim());
            PriceLoc = (double)FlxInv.GetData(FlxInv.Row, 8); without = PriceLoc; pricel = PriceLoc; lastprice = 0; ta = (double)FlxInv.GetData(FlxInv.Row, 31);
            if (Barcod || File.Exists(Application.StartupPath + "\\Script\\SecriptMaintenanceCars.dll"))
            {
                if (Balance_Qty >= 0.0)
                {
                    FlxInv.SetData(FlxInv.Row, 7, Balance_Qty);
                }
                else
                {
                    FlxInv.SetData(FlxInv.Row, 7, 1);
                }
                FlxInv.SetData(FlxInv.Row, 12, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.Row, 11)))));
                double ItmDis = 0.0;
                double ItmAddTax = 0.0;
                try
                {
                    ItmDis = double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.Row, 8)))) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.Row, 9)))) / 100.0);
                }
                catch
                {
                    ItmDis = 0.0;
                }
                try
                {
                    ItmAddTax = Math.Round(double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.Row, 8)))) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.Row, 31)))) / 100.0), VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2);
                }
                catch
                {
                    ItmAddTax = 0.0;
                }
                if (!switchButton_TaxLines.Value || switchButton_TaxByTotal.Value)
                {
                    ItmAddTax = 0.0;
                }
                FlxInv.SetData(FlxInv.Row, 38, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.Row, 8)))) - ItmDis + ItmAddTax);
                if (switchButton_TaxByTotal.Value && switchButton_TaxLines.Value && double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.Row, 38)))) > 0.0)
                {
                    ItmAddTax = Math.Round((double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.Row, 8)))) - ItmDis) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.Row, 31)))) / 100.0), VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2);
                    FlxInv.SetData(FlxInv.Row, 38, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.Row, 38)))) + ItmAddTax);
                }
                if (!chekReptItem(Col_1: true))
                {
                    FlxInv.Col = 0;
                    FlxInv.Row += 1;
                }
                else
                {
                    FlxInv.Col = 0;
                }
                GetInvTot();
            }
            else
            {
                chekRept();
            }
            try
            {
                PriceLoc = (double)FlxInv.GetData(FlxInv.Row, 8); without = PriceLoc; pricel = PriceLoc; lastprice = 0; ta = (double)FlxInv.GetData(FlxInv.Row, 31);
                if (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.Row, 7)))) > 0.0 && !Barcod)
                {
                    FlxInv_AfterEdit(null, new RowColEventArgs(FlxInv.Row, 7));
                }
            }
            catch
            {
            }
            double qty = 0.0;
            string unt = string.Empty;
            string itm_nm = string.Empty;
            try
            {
                itm_nm = _Items.Itm_No.Trim();
            }
            catch
            {
                itm_nm = string.Empty;
            }
            try
            {
                unt = DefUnitA;
            }
            catch
            {
                unt = string.Empty;
            }
            try
            {
                qty = double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData((!Barcod) ? FlxInv.Row : (FlxInv.Row - 1), 7))));
            }
            catch
            {
                qty = 0.0;
            }
            if (CmbInvSide.SelectedIndex <= 0)
            {
                RemoveOFFerLines(FlxInv.Row + 1);
                CheckOffers(itm_nm, unt, qty, (!Barcod) ? FlxInv.Row : (FlxInv.Row - 1), FlxInv.Row);
            }
            VarGeneral.Flush();
        }
        private void CheckOffers(string itmNo, string untNm, double vQty, int RowNow, int Ro)
        {
            try
            {
                if (!VarGeneral.CheckDate(txtGDate.Text) || !VarGeneral.CheckDate(txtHDate.Text) || string.IsNullOrEmpty(itmNo) || string.IsNullOrEmpty(untNm))
                {
                    return;
                }
                List<T_OfferDet> q = db.ExecuteQuery<T_OfferDet>("select T_OfferDet.* from  T_OfferDet INNER JOIN T_Offer ON T_OfferDet.OfferID = T_Offer.OfferHeadID where T_OfferDet.ItmNo ='" + itmNo + "' and T_OfferDet.ItmUnt =" + db.T_Units.Where((T_Unit c) => c.Arb_Des == untNm).ToList().FirstOrDefault()
                    .Unit_ID + " and ( '" + txtGDate.Text + "' BETWEEN  T_Offer.StartDat and T_Offer.EndDat or '" + txtHDate.Text + "' BETWEEN  T_Offer.StartDat and T_Offer.EndDat) order by  CONVERT(INT, LEFT(T_Offer.OfferHeadNo, PATINDEX('%[^0-9]%', T_Offer.OfferHeadNo + 'z')-1))", new object[0]).ToList();
                if (q.Count <= 0)
                {
                    return;
                }
                if (q.Where((T_OfferDet g) => g.T_Offer.OfferHeadTyp.Value == 1 && g.Qty.Value <= vQty).ToList().Count() > 0)
                {
                    if (!string.IsNullOrEmpty(txtCustNo.Text) && q.Where((T_OfferDet g) => g.T_Offer.CusVenNo == txtCustNo.Text && g.T_Offer.OfferHeadTyp.Value == 1 && g.Qty.Value <= vQty).ToList().Count > 0)
                    {
                        try
                        {
                            FlxInv.SetData(Ro, 8, q.Where((T_OfferDet g) => g.T_Offer.CusVenNo == txtCustNo.Text && g.T_Offer.OfferHeadTyp.Value == 1 && g.Qty.Value <= vQty).ToList().LastOrDefault()
                                .UnitPriVal.Value);
                            FlxInv_AfterEdit(null, new RowColEventArgs(Ro, 9));
                        }
                        catch
                        {
                        }
                        double QtyX = 1.0;
                        try
                        {
                            double vtot = vQty / q.Where((T_OfferDet g) => g.T_Offer.CusVenNo == txtCustNo.Text && g.T_Offer.OfferHeadTyp.Value == 1 && g.Qty.Value <= vQty).ToList().LastOrDefault()
                                .Qty.Value;
                            int i = 0;
                            for (i = 0; i < vtot.ToString().Length && !(vtot.ToString().Substring(i, 1) == "."); i++)
                            {
                            }
                            QtyX = double.Parse(vtot.ToString().Substring(0, i));
                        }
                        catch
                        {
                        }
                        List<T_OfferQFree> offerQFree = q.Where((T_OfferDet g) => g.T_Offer.CusVenNo == txtCustNo.Text && g.T_Offer.OfferHeadTyp.Value == 1 && g.Qty.Value <= vQty).ToList().LastOrDefault()
                            .T_OfferQFrees.ToList();
                        FillQFree(offerQFree, RowNow + 1, QtyX);
                    }
                    else
                    {
                        if (q.Where((T_OfferDet g) => string.IsNullOrEmpty(g.T_Offer.CusVenNo) && g.T_Offer.OfferHeadTyp.Value == 1 && g.Qty.Value <= vQty).ToList().Count <= 0)
                        {
                            return;
                        }
                        try
                        {
                            FlxInv.SetData(Ro, 8, q.Where((T_OfferDet g) => string.IsNullOrEmpty(g.T_Offer.CusVenNo) && g.T_Offer.OfferHeadTyp.Value == 1 && g.Qty.Value <= vQty).ToList().LastOrDefault()
                                .UnitPriVal.Value);
                            FlxInv_AfterEdit(null, new RowColEventArgs(Ro, 9));
                        }
                        catch
                        {
                        }
                        double QtyX = 1.0;
                        try
                        {
                            double vtot = vQty / q.Where((T_OfferDet g) => string.IsNullOrEmpty(g.T_Offer.CusVenNo) && g.T_Offer.OfferHeadTyp.Value == 1 && g.Qty.Value <= vQty).ToList().LastOrDefault()
                                .Qty.Value;
                            int i = 0;
                            for (i = 0; i < vtot.ToString().Length && !(vtot.ToString().Substring(i, 1) == "."); i++)
                            {
                            }
                            QtyX = double.Parse(vtot.ToString().Substring(0, i));
                        }
                        catch
                        {
                        }
                        List<T_OfferQFree> offerQFree = q.Where((T_OfferDet g) => string.IsNullOrEmpty(g.T_Offer.CusVenNo) && g.T_Offer.OfferHeadTyp.Value == 1 && g.Qty.Value <= vQty).ToList().LastOrDefault()
                            .T_OfferQFrees.ToList();
                        FillQFree(offerQFree, RowNow + 1, QtyX);
                        return;
                    }
                }
                else
                {
                    if (q.Where((T_OfferDet g) => g.T_Offer.OfferHeadTyp.Value == 0).ToList().Count() <= 0)
                    {
                        return;
                    }
                    if (!string.IsNullOrEmpty(txtCustNo.Text) && q.Where((T_OfferDet g) => g.T_Offer.CusVenNo == txtCustNo.Text && g.T_Offer.OfferHeadTyp.Value == 0).ToList().Count > 0)
                    {
                        FlxInv.SetData(RowNow, 8, q.Where((T_OfferDet g) => g.T_Offer.CusVenNo == txtCustNo.Text && g.T_Offer.OfferHeadTyp.Value == 0).ToList().LastOrDefault()
                            .UnitPriVal.Value);
                        FlxInv_AfterEdit(null, new RowColEventArgs(RowNow, 9));
                    }
                    else if (q.Where((T_OfferDet g) => string.IsNullOrEmpty(g.T_Offer.CusVenNo) && g.T_Offer.OfferHeadTyp.Value == 0).ToList().Count > 0)
                    {
                        FlxInv.SetData(RowNow, 8, q.Where((T_OfferDet g) => string.IsNullOrEmpty(g.T_Offer.CusVenNo) && g.T_Offer.OfferHeadTyp.Value == 0).ToList().LastOrDefault()
                            .UnitPriVal.Value);
                        FlxInv_AfterEdit(null, new RowColEventArgs(RowNow, 9));
                    }
                    return;
                }
            }
            catch
            {
            }
        }
        private void FillQFree(List<T_OfferQFree> offerQFree, int oldRow, double QtyX)
        {
            FlxInv.SetData(oldRow - 1, 39, "0");
            double Pack_OfferQFree = 0.0;
            T_Item _ItemsOfferQFree = new T_Item();
            int t = 0;
            int vRowToCopy = oldRow;
            for (int i = oldRow; i < FlxInv.Rows.Count + 1; i++)
            {
                try
                {
                    if (string.Concat(FlxInv.GetData(i, 1)) != string.Empty)
                    {
                        t++;
                    }
                }
                catch
                {
                    break;
                }
            }
            if (t > 0)
            {
                try
                {
                    FlxInvToCopy.Rows.Count += t;
                    for (int i = 1; i <= FlxInvToCopy.Rows.Count; i++)
                    {
                        for (int iicnt = 0; iicnt < FlxInvToCopy.Cols.Count; iicnt++)
                        {
                            FlxInvToCopy.SetData(i, iicnt, FlxInv.GetData(vRowToCopy, iicnt));
                        }
                        vRowToCopy++;
                    }
                }
                catch
                {
                }
            }
            int _CRow = FlxInv.Rows.Count;
            FlxInv.Rows.Count = oldRow;
            FlxInv.Rows.Count += _CRow;
            for (int i = 0; i < offerQFree.Count; i++)
            {
                _ItemsOfferQFree = db.StockItem(offerQFree[i].OfferQFreeItmNo);
                FlxInv.SetData(oldRow, 1, _ItemsOfferQFree.Itm_No.Trim());
                FlxInv.SetData(oldRow, 2, _ItemsOfferQFree.Arb_Des.Trim() + " * عرض");
                FlxInv.SetData(oldRow, 4, _ItemsOfferQFree.Eng_Des.Trim() + " * Offer");
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                {
                    txtItemName.Text = _ItemsOfferQFree.Arb_Des.Trim();
                }
                else
                {
                    txtItemName.Text = _ItemsOfferQFree.Eng_Des.Trim();
                }
                FlxInv.SetData(oldRow, 6, offerQFree[i].OfferQFreeStoreNo.Value);
                string CoA = string.Empty;
                string CoE = string.Empty;
                string DefUnitA = string.Empty;
                string DefUnitE = string.Empty;
                for (int iiCnt = 0; iiCnt < listUnit.Count; iiCnt++)
                {
                    _Unit = listUnit[iiCnt];
                    if (_ItemsOfferQFree.Unit1 == _Unit.Unit_ID)
                    {
                        if (CoA != string.Empty)
                        {
                            CoA += "|";
                            CoE += "|";
                        }
                        CoA += _Unit.Arb_Des;
                        CoE += _Unit.Eng_Des;
                        if (offerQFree[i].T_Unit.Arb_Des == _Unit.Arb_Des)
                        {
                            Pack_OfferQFree = _ItemsOfferQFree.Pack1.Value;
                            DefUnitA = _Unit.Arb_Des;
                            DefUnitE = _Unit.Eng_Des;
                            FlxInv.SetData(oldRow, 8, offerQFree[i].OfferQFreeUnitPriVal.Value);
                            FlxInv.SetData(oldRow, 11, _ItemsOfferQFree.Pack1.Value);
                        }
                        break;
                    }
                }
                for (int iiCnt = 0; iiCnt < listUnit.Count; iiCnt++)
                {
                    _Unit = listUnit[iiCnt];
                    if (_ItemsOfferQFree.Unit2 == _Unit.Unit_ID)
                    {
                        if (CoA != string.Empty)
                        {
                            CoA += "|";
                            CoE += "|";
                        }
                        CoA += _Unit.Arb_Des;
                        CoE += _Unit.Arb_Des;
                        if (offerQFree[i].T_Unit.Arb_Des == _Unit.Arb_Des)
                        {
                            Pack_OfferQFree = _ItemsOfferQFree.Pack2.Value;
                            DefUnitA = _Unit.Arb_Des;
                            DefUnitE = _Unit.Eng_Des;
                            FlxInv.SetData(oldRow, 8, offerQFree[i].OfferQFreeUnitPriVal.Value);
                            FlxInv.SetData(oldRow, 11, _ItemsOfferQFree.Pack2.Value);
                        }
                        break;
                    }
                }
                for (int iiCnt = 0; iiCnt < listUnit.Count; iiCnt++)
                {
                    _Unit = listUnit[iiCnt];
                    if (_ItemsOfferQFree.Unit3 == _Unit.Unit_ID)
                    {
                        if (CoA != string.Empty)
                        {
                            CoA += "|";
                            CoE += "|";
                        }
                        CoA += _Unit.Arb_Des;
                        CoE += _Unit.Eng_Des;
                        if (offerQFree[i].T_Unit.Arb_Des == _Unit.Arb_Des)
                        {
                            Pack_OfferQFree = _ItemsOfferQFree.Pack3.Value;
                            DefUnitA = _Unit.Arb_Des;
                            DefUnitE = _Unit.Eng_Des;
                            FlxInv.SetData(oldRow, 8, offerQFree[i].OfferQFreeUnitPriVal.Value);
                            FlxInv.SetData(oldRow, 11, _ItemsOfferQFree.Pack3.Value);
                        }
                        break;
                    }
                }
                for (int iiCnt = 0; iiCnt < listUnit.Count; iiCnt++)
                {
                    _Unit = listUnit[iiCnt];
                    if (_ItemsOfferQFree.Unit4 == _Unit.Unit_ID)
                    {
                        if (CoA != string.Empty)
                        {
                            CoA += "|";
                            CoE += "|";
                        }
                        CoA += _Unit.Arb_Des;
                        CoE += _Unit.Eng_Des;
                        if (offerQFree[i].T_Unit.Arb_Des == _Unit.Arb_Des)
                        {
                            Pack_OfferQFree = _ItemsOfferQFree.Pack4.Value;
                            DefUnitA = _Unit.Arb_Des;
                            DefUnitE = _Unit.Eng_Des;
                            FlxInv.SetData(oldRow, 8, offerQFree[i].OfferQFreeUnitPriVal.Value);
                            FlxInv.SetData(oldRow, 11, _ItemsOfferQFree.Pack4.Value);
                        }
                        break;
                    }
                }
                for (int iiCnt = 0; iiCnt < listUnit.Count; iiCnt++)
                {
                    _Unit = listUnit[iiCnt];
                    if (_ItemsOfferQFree.Unit5 == _Unit.Unit_ID)
                    {
                        if (CoA != string.Empty)
                        {
                            CoA += "|";
                            CoE += "|";
                        }
                        CoA += _Unit.Arb_Des;
                        CoE += _Unit.Eng_Des;
                        if (offerQFree[i].T_Unit.Arb_Des == _Unit.Arb_Des)
                        {
                            Pack_OfferQFree = _ItemsOfferQFree.Pack5.Value;
                            DefUnitA = _Unit.Arb_Des;
                            DefUnitE = _Unit.Eng_Des;
                            FlxInv.SetData(oldRow, 8, offerQFree[i].OfferQFreeUnitPriVal.Value);
                            FlxInv.SetData(oldRow, 11, _ItemsOfferQFree.Pack5.Value);
                        }
                        break;
                    }
                }
                FlxInv.Cols[3].ComboList = CoA;
                FlxInv.Cols[5].ComboList = CoE;
                FlxInv.SetData(oldRow, 3, DefUnitA);
                FlxInv.SetData(oldRow, 5, DefUnitE);
                FlxInv.SetData(oldRow, 10, _ItemsOfferQFree.AvrageCost / RateValue);
                txtVCost.Text = string.Concat(Math.Round((_ItemsOfferQFree.AvrageCost * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(oldRow, 11))))).Value / RateValue, VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2));
                FlxInv.SetData(oldRow, 30, _ItemsOfferQFree.LastCost * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(oldRow, 11)))) / RateValue);
                txtLCost.Text = string.Concat(Math.Round((_ItemsOfferQFree.LastCost * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(oldRow, 11))))).Value / RateValue, VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2));
                txtVSerial.Text = _ItemsOfferQFree.SerialKey ?? string.Empty;
                FlxInv.SetData(oldRow, 28, _ItemsOfferQFree.Lot);
                if (_ItemsOfferQFree.Lot == 1)
                {
                    FlxInv.Cols[27].Visible = true;
                    FlxInv.Cols[35].Visible = true;
                }
                FlxInv.SetData(oldRow, 27, offerQFree[i].OfferQFreeDatExper);
                FlxInv.SetData(oldRow, 35, offerQFree[i].OfferQFreeRunCod);
                FlxInv.SetData(oldRow, 32, _ItemsOfferQFree.ItmTyp);
                FlxInv.SetData(oldRow, 33, _ItemsOfferQFree.ItmLoc);
                FlxInv.SetData(oldRow, 18, _ItemsOfferQFree.DefPack);
                FlxInv.SetData(oldRow, 19, _ItemsOfferQFree.Price1);
                FlxInv.SetData(oldRow, 20, _ItemsOfferQFree.Price2);
                FlxInv.SetData(oldRow, 21, _ItemsOfferQFree.Price3);
                FlxInv.SetData(oldRow, 22, _ItemsOfferQFree.Price4);
                FlxInv.SetData(oldRow, 23, _ItemsOfferQFree.Price5);
                FlxInv.SetData(oldRow, 39, "1");
                FlxInv.SetData(oldRow, 8, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(oldRow, 8)))) / RateValue);
                if (FlxInv.Cols[9].Visible)
                {
                    FlxInv.SetData(oldRow, 9, _ItemsOfferQFree.ItemDis.Value);
                }
                else
                {
                    FlxInv.SetData(oldRow, 9, 0);
                }
                if (FlxInv.Cols[31].Visible)
                {
                    FlxInv.SetData(oldRow, 31, offerQFree[i].OfferQFreeItmTax.Value);
                }
                else
                {
                    FlxInv.SetData(oldRow, 31, 0);
                }
                FlxInv.SetData(oldRow, 7, offerQFree[i].OfferQFreeQty.Value * QtyX);
                FlxInv.SetData(oldRow, 12, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(oldRow, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(oldRow, 11)))));
                double ItmDis = 0.0;
                double ItmAddTax = 0.0;
                try
                {
                    ItmDis = double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(oldRow, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(oldRow, 8)))) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(oldRow, 9)))) / 100.0);
                }
                catch
                {
                    ItmDis = 0.0;
                }
                try
                {
                    if ((File.Exists(Application.StartupPath + "\\Script\\SecriptColDisSalesReturn.dll") || (VarGeneral.gUserName == "runsetting" && File.Exists(Application.StartupPath + "\\Script\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\SecriptColDisSalesReturn.dll"))) && double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(oldRow, 36)))) > 0.0)
                    {
                        ItmDis += double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(oldRow, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(oldRow, 8)))) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(oldRow, 36)))) / 100.0);
                    }
                }
                catch
                {
                }
                try
                {
                    if (File.Exists(Application.StartupPath + "\\Script\\SecriptColDisSalesReturnValue.dll") || (VarGeneral.gUserName == "runsetting" && File.Exists(Application.StartupPath + "\\Script\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\SecriptColDisSalesReturnValue.dll")))
                    {
                        ItmDis += double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(oldRow, 36))));
                    }
                }
                catch
                {
                }
                try
                {
                    ItmAddTax = Math.Round(double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(oldRow, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(oldRow, 8)))) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(oldRow, 31)))) / 100.0), VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2);
                }
                catch
                {
                    ItmAddTax = 0.0;
                }
                if (!switchButton_TaxLines.Value || switchButton_TaxByTotal.Value)
                {
                    ItmAddTax = 0.0;
                }
                FlxInv.SetData(oldRow, 38, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(oldRow, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(oldRow, 8)))) - ItmDis + ItmAddTax);
                if (switchButton_TaxByTotal.Value && switchButton_TaxLines.Value && double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(oldRow, 38)))) > 0.0)
                {
                    ItmAddTax = Math.Round((double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(oldRow, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(oldRow, 8)))) - ItmDis) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(oldRow, 31)))) / 100.0), VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2);
                    FlxInv.SetData(oldRow, 38, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(oldRow, 38)))) + ItmAddTax);
                }
                GetInvTot();
                try
                {
                    FlxInv_AfterEdit(null, new RowColEventArgs(oldRow, 9));
                }
                catch
                {
                }
                FlxInv.Rows[oldRow].StyleNew.BackColor = Color.Gainsboro;
                FlxInv.Rows[oldRow].AllowEditing = false;
                oldRow++;
            }
            if (FlxInvToCopy.Rows.Count <= 0)
            {
                return;
            }
            for (int i = 1; i < FlxInvToCopy.Rows.Count; i++)
            {
                for (int iicnt = 1; iicnt < FlxInvToCopy.Cols.Count; iicnt++)
                {
                    FlxInv.SetData(oldRow, iicnt, FlxInvToCopy.GetData(i, iicnt));
                }
                try
                {
                    if (int.Parse(FlxInv.GetData(oldRow, 39).ToString()) == 1)
                    {
                        FlxInv.Rows[oldRow].StyleNew.BackColor = Color.Gainsboro;
                        FlxInv.Rows[oldRow].AllowEditing = false;
                    }
                }
                catch
                {
                }
                oldRow++;
            }
        }
        private void
            BindDataOfStkQty(string ItmNo)
        {
            FlxStkQty.Clear(ClearFlags.Content, 1, 1, 1, 1);
            using (Stock_DataDataContext dbC = new Stock_DataDataContext(VarGeneral.BranchCS))
            {
                listStkQty = dbC.T_STKSQTies.Where((T_STKSQTY t) => t.itmNo == ItmNo).ToList();
            }
            FlxInv.SetData(FlxInv.Row, 24, 0);
            for (int iiCnt = 0; iiCnt < listStkQty.Count; iiCnt++)
            {
                _StksQty = listStkQty[iiCnt];
                for (int I = 1; I < FlxStkQty.Rows.Count; I++)
                {
                    if (_StksQty.storeNo.Value.ToString().Trim() == FlxStkQty.GetData(I, 0).ToString())
                    {
                        FlxStkQty.SetData(I, 1, _StksQty.stkQty / double.Parse(VarGeneral.TString.TEmpty(FlxInv.GetData(FlxInv.Row, 11).ToString())));
                        if (_StksQty.storeNo.Value.ToString().Trim() == FlxInv.GetData(FlxInv.RowSel, 6).ToString())
                        {
                            FlxInv.SetData(FlxInv.Row, 24, _StksQty.stkQty);
                        }
                    }
                }
            }
        }
        private void chekRept()
        {
            if (State == FormState.Saved || FlxInv.ColSel != 1)
            {
                return;
            }
            for (int iiCnt = 1; iiCnt < FlxInv.Rows.Count; iiCnt++)
            {
                if (string.IsNullOrEmpty(string.Concat(FlxInv.GetData(iiCnt, 1))) || iiCnt == FlxInv.RowSel)
                {
                    continue;
                }
                bool ChekOfferStat = false;
                try
                {
                    if (FlxInv.GetData(iiCnt, 39).ToString() == "1")
                    {
                        ChekOfferStat = true;
                    }
                }
                catch
                {
                }
                try
                {
                    if (FlxInv.GetData(iiCnt, 1).ToString() == FlxInv.GetData(FlxInv.RowSel, 1).ToString() && !ChekOfferStat)
                    {
                        MessageBox.Show((LangArEn == 0) ? "تنبيه .. لقد قمت بأدخال هذا الصنف مسبقا\u064b في هذه الفاتورة" : "Alert .. You have entered already this product in this bill", VarGeneral.ProdectNam);
                        return;
                    }
                }
                catch
                {
                }
            }
        }
        private bool chekReptItem(bool Col_1)
        {
            if ((this.FlxInv.ColSel == 38 || this.FlxInv.ColSel == 7 || this.FlxInv.ColSel == 8 || Col_1 ? VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 17) : false))
            {
                double vQty = 0.0;
                try
                {
                    vQty = double.Parse(VarGeneral.TString.TEmpty(FlxInv.GetData(FlxInv.RowSel, 7).ToString()));
                }
                catch
                {
                    vQty = 0.0;
                }
                for (int iiCnt = 1; iiCnt < FlxInv.Rows.Count; iiCnt++)
                {
                    if (string.IsNullOrEmpty(string.Concat(FlxInv.GetData(iiCnt, 1))) || iiCnt == FlxInv.RowSel || !(FlxInv.GetData(iiCnt, 1).ToString() == FlxInv.GetData(FlxInv.RowSel, 1).ToString()) || !(FlxInv.GetData(iiCnt, 11).ToString() == FlxInv.GetData(FlxInv.RowSel, 11).ToString()) || !(FlxInv.GetData(iiCnt, 6).ToString() == FlxInv.GetData(FlxInv.RowSel, 6).ToString()))
                    {
                        continue;
                    }
                    double ItmDis = 0.0;
                    double ItmAddTax = 0.0;
                    try
                    {
                        FlxInv.SetData(iiCnt, 7, double.Parse(VarGeneral.TString.TEmpty(FlxInv.GetData(iiCnt, 7).ToString() ?? string.Empty)) + vQty);
                    }
                    catch
                    {
                        FlxInv.SetData(iiCnt, 7, vQty);
                    }
                    ItmDis = double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 8)))) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 9)))) / 100.0);
                    try
                    {
                        if ((File.Exists(Application.StartupPath + "\\Script\\SecriptColDisSalesReturn.dll") || (VarGeneral.gUserName == "runsetting" && File.Exists(Application.StartupPath + "\\Script\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\SecriptColDisSalesReturn.dll"))) && double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 36)))) > 0.0)
                        {
                            ItmDis += double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 8)))) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 36)))) / 100.0);
                        }
                    }
                    catch
                    {
                    }
                    try
                    {
                        if (File.Exists(Application.StartupPath + "\\Script\\SecriptColDisSalesReturnValue.dll") || (VarGeneral.gUserName == "runsetting" && File.Exists(Application.StartupPath + "\\Script\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\SecriptColDisSalesReturnValue.dll")))
                        {
                            ItmDis += double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 36))));
                        }
                    }
                    catch
                    {
                    }
                    ItmAddTax = Math.Round(double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 8)))) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 31)))) / 100.0), VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2);
                    if (!switchButton_TaxLines.Value || switchButton_TaxByTotal.Value)
                    {
                        ItmAddTax = 0.0;
                    }
                    if (FlxInv.RowSel > 0)
                    {
                        FlxInv.RemoveItem(FlxInv.Row);
                        double RealQ = 0.0;
                        RealQ = double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 11))));
                        FlxInv.SetData(iiCnt, 12, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 11)))));
                        FlxInv.SetData(iiCnt, 38, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 8)))) - ItmDis + ItmAddTax);
                        if (switchButton_TaxByTotal.Value && switchButton_TaxLines.Value && double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 38)))) > 0.0)
                        {
                            ItmAddTax = Math.Round((double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 8)))) - ItmDis) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 31)))) / 100.0), VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2);
                            FlxInv.SetData(iiCnt, 38, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 38)))) + ItmAddTax);
                        }
                        GetInvTot();
                        FlxInv.Row = FlxInv.RowSel;
                        FlxInv.Col = 0;
                    }
                    double qty = 0.0;
                    string unt = string.Empty;
                    string itm_nm = string.Empty;
                    try
                    {
                        itm_nm = string.Concat(FlxInv.GetData(iiCnt, 1));
                    }
                    catch
                    {
                        itm_nm = string.Empty;
                    }
                    try
                    {
                        unt = string.Concat(FlxInv.GetData(iiCnt, 3));
                    }
                    catch
                    {
                        unt = string.Empty;
                    }
                    try
                    {
                        qty = double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 7))));
                    }
                    catch
                    {
                        qty = 0.0;
                    }
                    if (CmbInvSide.SelectedIndex <= 0)
                    {
                        RemoveOFFerLines(iiCnt + 1);
                        CheckOffers(itm_nm, unt, qty, iiCnt, iiCnt);
                    }
                    return true;
                }
            }
            return false;
        }
        private void BindDataofItemPrice()
        {
            if (CmbInvPrice.SelectedIndex == 1 && _Items.Price1.HasValue)
            {
                FlxInv.SetData(FlxInv.Row, 8, _Items.Price1.Value / _Items.DefPack.Value * Pack / RateValue);
            }
            else if (CmbInvPrice.SelectedIndex == 2 && _Items.Price2.HasValue)
            {
                FlxInv.SetData(FlxInv.Row, 8, _Items.Price2.Value / _Items.DefPack.Value * Pack / RateValue);
            }
            else if (CmbInvPrice.SelectedIndex == 3 && _Items.Price3.HasValue)
            {
                FlxInv.SetData(FlxInv.Row, 8, _Items.Price3.Value / _Items.DefPack.Value * Pack / RateValue);
            }
            else if (CmbInvPrice.SelectedIndex == 4 && _Items.Price4.HasValue)
            {
                FlxInv.SetData(FlxInv.Row, 8, _Items.Price4.Value / _Items.DefPack.Value * Pack / RateValue);
            }
            else if (CmbInvPrice.SelectedIndex == 5 && _Items.Price5.HasValue)
            {
                FlxInv.SetData(FlxInv.Row, 8, _Items.Price5.Value / _Items.DefPack.Value * Pack / RateValue);
            }
            try
            {
                if (string.IsNullOrEmpty(txtCustNo.Text))
                {
                    return;
                }
                T_AccDef q = db.StockAccDefWithOutBalance(txtCustNo.Text);
                if (q != null && !string.IsNullOrEmpty(q.AccDef_No) && q.Price > 0)
                {
                    if (q.Price == 1 && _Items.Price1.HasValue)
                    {
                        FlxInv.SetData(FlxInv.Row, 8, _Items.Price1.Value / _Items.DefPack.Value * Pack / RateValue);
                    }
                    else if (q.Price == 2 && _Items.Price2.HasValue)
                    {
                        FlxInv.SetData(FlxInv.Row, 8, _Items.Price2.Value / _Items.DefPack.Value * Pack / RateValue);
                    }
                    else if (q.Price == 3 && _Items.Price3.HasValue)
                    {
                        FlxInv.SetData(FlxInv.Row, 8, _Items.Price3.Value / _Items.DefPack.Value * Pack / RateValue);
                    }
                    else if (q.Price == 4 && _Items.Price4.HasValue)
                    {
                        FlxInv.SetData(FlxInv.Row, 8, _Items.Price4.Value / _Items.DefPack.Value * Pack / RateValue);
                    }
                    else if (q.Price == 5 && _Items.Price5.HasValue)
                    {
                        FlxInv.SetData(FlxInv.Row, 8, _Items.Price5.Value / _Items.DefPack.Value * Pack / RateValue);
                    }
                }
            }
            catch
            {
            }
        }
        private void ButReturn_Click(object sender, EventArgs e)
        {
            if (CmbInvSide.SelectedIndex > 0 || State != FormState.New)
            {
                return;
            }
            columns_Names_visible2.Clear();
            columns_Names_visible2.Add("InvNo", new ColumnDictinary("رقم الفاتورة", "Invoice No", ifDefault: true, string.Empty));
            columns_Names_visible2.Add("CusVenNm", new ColumnDictinary("إسم العميل", "Customer Name", ifDefault: true, string.Empty));
            columns_Names_visible2.Add("SalsManNo", new ColumnDictinary("رقم البائع", "SalsMan No", ifDefault: false, string.Empty));
            columns_Names_visible2.Add("HDat", new ColumnDictinary("التاريخ الهجري", "Date Hijri", ifDefault: true, string.Empty));
            columns_Names_visible2.Add("GDat", new ColumnDictinary("التاريخ الميلادي", "Date Gregorian", ifDefault: true, string.Empty));
            columns_Names_visible2.Add("InvTot", new ColumnDictinary("إجمالي الفاتورة", "Invoice Total", ifDefault: false, string.Empty));
            columns_Names_visible2.Add("InvNet", new ColumnDictinary("صافي الفاتورة", "Invoice Net", ifDefault: true, string.Empty));
            columns_Names_visible2.Add("InvQty", new ColumnDictinary("إجمالي الكمية", "Quantity Total", ifDefault: true, string.Empty));
            columns_Names_visible2.Add("InvDisPrs", new ColumnDictinary("الخصم نسبة", "Discount Percentage", ifDefault: false, string.Empty));
            columns_Names_visible2.Add("InvDisVal", new ColumnDictinary("الخصم قيمة", "Discount value", ifDefault: true, string.Empty));
            columns_Names_visible2.Add("Remark", new ColumnDictinary("الملاحظات", "Note", ifDefault: true, string.Empty));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible2;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
            }
            VarGeneral.SFrmTyp = "T_InvSalReturnMain";
            VarGeneral.InvTypRt = 1;
            frm.TopMost = true;
            frm.ShowDialog();
            if (!(frm.SerachNo != string.Empty))
            {
                return;
            }
            T_INVHED newData = dbReturn.StockInvHead(1, frm.Serach_No);
            if (newData != null || !string.IsNullOrEmpty(newData.InvNo))
            {
                CmbInvSide.SelectedIndexChanged -= CmbInvSide_SelectedIndexChanged;
                State = FormState.Saved;
                Clear();
                DataThisRe = newData;
                ChkPriceIncludeTax.Value = (bool)newData.PriceIncludTax;
                ChkPriceIncludeTax.Enabled = false;
                CmbInvSide.SelectedIndexChanged += CmbInvSide_SelectedIndexChanged;
                if (VarGeneral._IsPOS)
                {
                    AutoGaidAcc_POS();
                }
                else
                {
                    AutoGaidAcc();
                }
                txtDebit5.Text = string.Empty;
                txtDebit5.Tag = string.Empty;
                txtCredit5.Text = string.Empty;
                txtCredit5.Tag = string.Empty;
                checkBox_CostGaidTax_CheckedChanged(sender, e);
                txtDebit6.Text = string.Empty;
                txtDebit6.Tag = string.Empty;
                txtCredit6.Text = string.Empty;
                txtCredit6.Tag = string.Empty;
                checkBox_GaidDis_CheckedChanged(sender, e);
                GetInvTot();
            }
        }
        private void CmbInvSide_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (State != 0)
            {
                FillComboMnd();
                txtCustNo.Text = string.Empty;
                txtCustName.Text = string.Empty;
                txtAddress.Text = string.Empty;
                txtCustRep.Value = 0.0;
                txtDiscountVal.Value = 0.0;
                txtDiscountP.Value = 0.0;
                txtDiscountVal_Leave(sender, e);
                switchButton_PointActiv.ValueChanged -= switchButton_PointActiv_ValueChanged;
                switchButton_PointActiv.Value = false;
                switchButton_PointActiv_ValueChanged(sender, e);
                switchButton_PointActiv.ValueChanged += switchButton_PointActiv_ValueChanged;
            }
            if (CmbInvSide.SelectedIndex <= 0)
            {
                button_GoodsDisbursedInv.Visible = false;
                if (State == FormState.New)
                {
                    ButReturn.Enabled = true;
                }
            }
            else
            {
                ButReturn.Enabled = false;
            }
        }
        private void txtDueAmountLoc_ValueChanged(object sender, EventArgs e)
        {
            if (State != 0)
            {
                if (checkBox_Chash.Checked)
                {
                    txtPaymentLoc.Value = (checkBox_CostGaidTax.Checked ? (txtDueAmountLoc.Value - txtTotTax.Value) : txtDueAmountLoc.Value);
                    doubleInput_CreditLoc.Value = 0.0;
                    doubleInput_NetWorkLoc.Value = 0.0;
                }
                else if (checkBox_NetWork.Checked)
                {
                    doubleInput_NetWorkLoc.Value = (checkBox_CostGaidTax.Checked ? (txtDueAmountLoc.Value - txtTotTax.Value) : txtDueAmountLoc.Value);
                    txtPaymentLoc.Value = 0.0;
                    doubleInput_CreditLoc.Value = 0.0;
                }
                else
                {
                    doubleInput_CreditLoc.Value = (checkBox_CostGaidTax.Checked ? (txtDueAmountLoc.Value - txtTotTax.Value) : txtDueAmountLoc.Value);
                    txtPaymentLoc.Value = 0.0;
                    doubleInput_NetWorkLoc.Value = 0.0;
                }
            }
        }
        private void txtRemark_ButtonCustomClick(object sender, EventArgs e)
        {
            txtRemark.Text = string.Empty;
        }
        private void prnt_doc_PrintPage(object sender, PrintPageEventArgs e)
        {
            if (VarGeneral.RepData.Tables[0].Rows.Count == 0)
            {
                return;
            }
            try
            {
                foreach (DataRow r in VarGeneral.RepData.Tables[0].Rows)
                {
                    for (int i = 0; i < r.ItemArray.Count(); i++)
                    {
                        if (r[i].GetType() == typeof(double))
                        {
                            r[i] = Math.Round(double.Parse(r[i].ToString()), VarGeneral.DecimalNo);

                        }

                    }

                }
            }
            catch { }
            List<T_mInvPrint> listmInvPrint = new List<T_mInvPrint>();
            T_mInvPrint _mInvPrint = new T_mInvPrint();
            listmInvPrint = (from item in db.T_mInvPrints
                             where item.repTyp == (int?)3
                             where item.repNum == (int?)3
                             where item.IsPrint == (int?)1
                             select item).ToList();
            if (listmInvPrint.Count == 0)
            {
                return;
            }
            e.PageSettings.Margins.Bottom = Convert.ToInt32(_InvSetting.InvpRINTERInfo.hAs);
            e.PageSettings.Margins.Top = Convert.ToInt32(_InvSetting.InvpRINTERInfo.hAl);
            e.PageSettings.Margins.Left = Convert.ToInt32(_InvSetting.InvpRINTERInfo.hYs);
            e.PageSettings.Margins.Right = Convert.ToInt32(_InvSetting.InvpRINTERInfo.hYm);
            e.PageSettings.PrinterSettings.Copies = short.Parse(_InvSetting.InvpRINTERInfo.DefLines.Value.ToString());
            double _isRows = 0.0;
            float _Row = 0f;
            double _PageLine = _InvSetting.InvpRINTERInfo.lnPg.Value;
            double _LineSp = _InvSetting.InvpRINTERInfo.lnSpc.Value;
            int _PageCount = Convert.ToInt32((double)VarGeneral.RepData.Tables[0].Rows.Count / _PageLine);
            double _VPage = (double)VarGeneral.RepData.Tables[0].Rows.Count / _PageLine;
            StringFormat strformat = new StringFormat((StringFormatFlags)0, 1);
            if (_VPage - (double)_PageCount != 0.0)
            {
                _PageCount++;
            }
            for (int iiRnt = iiRntP; iiRnt < VarGeneral.RepData.Tables[0].Rows.Count; iiRnt++)
            {
                for (int iiCnt = 0; iiCnt < listmInvPrint.Count; iiCnt++)
                {
                    _mInvPrint = listmInvPrint[iiCnt];
                    if (_mInvPrint.pField == "Table.LogImg")
                    {
                        try
                        {
                            FrmReportsViewer.QRCodeData = Utilites.GetWQRCodeData(DataThis);
                            //  if (VarGeneral.RepData.Tables[0].Rows[iiRnt][_mInvPrint.pField] != null)
                            {
                                e.Graphics.DrawImage(byteArrayToImage(Utilites.qrcodeimage()), (int)_mInvPrint.vRow, (int)_mInvPrint.vCol, 50f, 50f);

                            }
                        }
                        catch (Exception error4)
                        {
                            VarGeneral.DebLog.writeLog("Print QRCODE:", error4, enable: true);
                        }
                        continue;

                    }


                    if (!(_mInvPrint.vFont != "0") || _mInvPrint.vSize.Value == 0)
                    {
                        continue;
                    }
                    strformat.FormatFlags = StringFormatFlags.DirectionRightToLeft;
                    if (_mInvPrint.vEt.Value == 0)
                    {
                        strformat.Alignment = StringAlignment.Near;
                    }
                    else if (_mInvPrint.vEt.Value == 1)
                    {
                        strformat.Alignment = StringAlignment.Far;
                    }
                    else if (_mInvPrint.vEt.Value == 2)
                    {
                        strformat.Alignment = StringAlignment.Center;
                    }
                    if (_mInvPrint.uChr == "mm")
                    {
                        e.Graphics.PageUnit = GraphicsUnit.Millimeter;
                    }
                    else if (_mInvPrint.uChr == "doc")
                    {
                        e.Graphics.PageUnit = GraphicsUnit.Document;
                    }
                    else if (_mInvPrint.uChr == "in")
                    {
                        e.Graphics.PageUnit = GraphicsUnit.Inch;
                    }
                    else if (_mInvPrint.uChr == "point")
                    {
                        e.Graphics.PageUnit = GraphicsUnit.Point;
                    }
                    else if (_mInvPrint.uChr == "pixel")
                    {
                        e.Graphics.PageUnit = GraphicsUnit.Pixel;
                    }
                    Font _font = new Font(_mInvPrint.vFont, _mInvPrint.vSize.Value, e.Graphics.PageUnit);
                    if (_mInvPrint.vBold.Value == 1)
                    {
                        _font = new Font(_mInvPrint.vFont, _mInvPrint.vSize.Value, FontStyle.Bold, e.Graphics.PageUnit);
                    }
                    _Row = ((_mInvPrint.IsPrntHd.Value != 1) ? ((float)_mInvPrint.vRow.Value) : ((float)_mInvPrint.vRow.Value + (float)_isRows));
                    string strfiled = string.Empty;
                     if(_mInvPrint.pField.Contains("PageTotel"))
                    _mInvPrint.pField = (_mInvPrint.pField.Contains("PageTotelE") ? "StoreNmE" : "StoreNmA");
                  strfiled = ((!(_mInvPrint.pField == "PageNo")) ? VarGeneral.TString.TEmpty_Stock(string.Concat(VarGeneral.RepData.Tables[0].Rows[iiRnt][_mInvPrint.pField])) : (_page + " / " + _PageCount));
                    Point loc = new Point(50, 50);
                    if (_mInvPrint.pField == "InvImg")
                    {
                        try
                        {
                            if (File.Exists(Application.StartupPath + "\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "Loc.txt"))
                            {
                                FileInfo file = new FileInfo(Application.StartupPath + "\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "Loc.txt");
                                FileStream fsToRead = file.Open(FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
                                StreamReader sr = new StreamReader(fsToRead);
                                string[] script = sr.ReadToEnd().Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                                sr.Close();
                                loc = new Point(int.Parse(script[0]), int.Parse(script[1]));
                            }
                        }
                        catch
                        {
                            new Point(50, 50);
                        }
                    }
                    if (_mInvPrint.IsPrntHd == 1)
                    {
                        if (_mInvPrint.pField == "ItmNo")
                        {
                            StringFormat stringFormat = new StringFormat();
                            stringFormat.Alignment = StringAlignment.Far;
                            StringFormat format = stringFormat;
                            e.Graphics.DrawString(strfiled, _font, Brushes.Black, _mInvPrint.vCol.Value, _Row, format);
                        }
                        else if (_mInvPrint.pField == "InvImg")
                        {
                            try
                            {
                                if (VarGeneral.RepData.Tables[0].Rows[iiRnt][_mInvPrint.pField] != null)
                                {
                                    e.Graphics.DrawImage(byteArrayToImage(data_this.InvImg.ToArray()), _mInvPrint.vCol.Value, _Row, loc.X, loc.Y);
                                }
                            }
                            catch (Exception error4)
                            {
                                VarGeneral.DebLog.writeLog("Print ImageInv:", error4, enable: true);
                            }
                        }
                        else
                        {
                            e.Graphics.DrawString(strfiled, _font, Brushes.Black, _mInvPrint.vCol.Value, _Row, strformat);
                        }
                        continue;
                    }
                    int? nTyp = _mInvPrint.nTyp;
                    if (nTyp.Value == 0 && nTyp.HasValue && _isRows == 0.0)
                    {
                        if (_mInvPrint.pField == "InvImg")
                        {
                            try
                            {
                                if (VarGeneral.RepData.Tables[0].Rows[iiRnt][_mInvPrint.pField] != null)
                                {
                                    e.Graphics.DrawImage(byteArrayToImage(data_this.InvImg.ToArray()), _mInvPrint.vCol.Value, _Row, loc.X, loc.Y);
                                }
                            }
                            catch (Exception error4)
                            {
                                VarGeneral.DebLog.writeLog("Print ImageInv:", error4, enable: true);
                            }
                        }
                        else
                        {
                            e.Graphics.DrawString(strfiled, _font, Brushes.Black, _mInvPrint.vCol.Value, _Row, strformat);
                        }
                    }
                    else if (_mInvPrint.nTyp == 1 && _page == 1)
                    {
                        if (_mInvPrint.pField == "InvImg")
                        {
                            try
                            {
                                if (VarGeneral.RepData.Tables[0].Rows[iiRnt][_mInvPrint.pField] != null)
                                {
                                    e.Graphics.DrawImage(byteArrayToImage(data_this.InvImg.ToArray()), _mInvPrint.vCol.Value, _Row, loc.X, loc.Y);
                                }
                            }
                            catch (Exception error4)
                            {
                                VarGeneral.DebLog.writeLog("Print ImageInv:", error4, enable: true);
                            }
                        }
                        else
                        {
                            e.Graphics.DrawString(strfiled, _font, Brushes.Black, _mInvPrint.vCol.Value, _Row, strformat);
                        }
                    }
                    else
                    {
                        if (_mInvPrint.nTyp != 2 || _page != _PageCount)
                        {
                            continue;
                        }
                        if (_mInvPrint.pField == "InvImg")
                        {
                            try
                            {
                                if (VarGeneral.RepData.Tables[0].Rows[iiRnt][_mInvPrint.pField] != null)
                                {
                                    e.Graphics.DrawImage(byteArrayToImage(data_this.InvImg.ToArray()), _mInvPrint.vCol.Value, _Row, loc.X, loc.Y);
                                }
                            }
                            catch (Exception error4)
                            {
                                VarGeneral.DebLog.writeLog("Print ImageInv:", error4, enable: true);
                            }
                        }
                        else
                        {
                            e.Graphics.DrawString(strfiled, _font, Brushes.Black, _mInvPrint.vCol.Value, _Row, strformat);
                        }
                    }
                }
                _isRows += _InvSetting.InvpRINTERInfo.lnSpc.Value;
                if ((double)(iiRnt + 1) >= (double)_page * _PageLine)
                {
                    _page++;
                    _isRows = 0.0;
                    iiRntP = iiRnt + 1;
                    if (_page <= _PageCount)
                    {
                        e.HasMorePages = true;
                        return;
                    }
                }
            }
            e.HasMorePages = false;
        }
        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            try
            {
                MemoryStream ms = new MemoryStream(byteArrayIn);
                return Image.FromStream(ms);
            }
            catch
            {
                return null;
            }
        }
        private void prnt_doc_BeginPrint(object sender, PrintEventArgs e)
        {
            if (!(textBox_ID.Text != string.Empty))
            {
                return;
            }
            RepShow _RepShow = new RepShow();
            _RepShow.Tables = "T_INVDET LEFT OUTER JOIN T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID LEFT OUTER JOIN T_INVSETTING ON T_INVHED.InvTyp = T_INVSETTING.InvID  LEFT OUTER JOIN T_Curency ON T_INVHED.CurTyp = T_Curency.Curency_ID LEFT OUTER JOIN T_CstTbl ON T_INVHED.InvCstNo = T_CstTbl.Cst_ID LEFT OUTER JOIN T_Mndob ON T_INVHED.MndNo = T_Mndob.Mnd_ID LEFT OUTER JOIN T_Items ON T_INVDET.ItmNo = T_Items.Itm_No LEFT OUTER JOIN T_CATEGORY ON T_Items.ItmCat = T_CATEGORY.CAT_ID LEFT OUTER JOIN T_SYSSETTING ON T_INVHED.CompanyID = T_SYSSETTING.SYSSETTING_ID ";
            string vInvH = " T_INVHED.InvHed_ID, T_INVHED.InvId as vID, T_INVHED.InvNo, T_INVHED.InvTyp, T_INVHED.InvCashPay, T_INVHED.CusVenNo,T_INVHED.CusVenMob as Mobile1,case when T_INVHED.CusVenNo = '' THEN T_INVHED.CusVenNm ELSE (select T_AccDef.Arb_Des from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as CusVenNm,case when T_INVHED.CusVenNo = '' THEN T_INVHED.CusVenNm ELSE (select T_AccDef.Eng_Des from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as CusVenNmE, T_INVHED.CusVenAdd, T_INVHED.CusVenTel, T_INVHED.Remark, T_INVHED.HDat, T_INVHED.GDat, T_INVHED.MndNo, T_INVHED.SalsManNo, T_INVHED.SalsManNam, T_INVHED.InvTot, T_INVHED.InvDisPrs, ((case when IsDisUse1 = 1 then T_INVHED.InvValGaidDis else T_INVHED.InvDisVal end) + T_INVHED.DesPointsValue) as InvDisVal,T_INVHED.InvDisVal as InvDisValOnly,T_INVHED.DesPointsValue,T_INVHED.DesPointsValueLocCur,T_INVHED.PointsCount,T_INVHED.IsPoints, T_INVHED.InvNet, T_INVHED.InvNetLocCur, T_INVHED.CashPayLocCur, T_INVHED.IfRet, T_INVHED.CashPay, T_INVHED.InvTotLocCur, T_INVHED.InvDisValLocCur, T_INVHED.GadeNo, T_INVHED.GadeId, T_INVHED.RetNo, T_INVHED.RetId, T_INVHED.InvCashPayNm, T_INVHED.InvCost, T_INVHED.CustPri, T_INVHED.ArbTaf, T_INVHED.ToStore, T_INVHED.InvCash, T_INVHED.CurTyp, T_INVHED.EstDat,case when DATEDIFF(day, GETDATE(), EstDat) > 0 Then DATEDIFF(day, GETDATE(), EstDat) WHEN DATEDIFF(day, GETDATE(), InvCashPayNm) > 0 THEN DATEDIFF(day, GETDATE(), InvCashPayNm) Else '0' END as EstDatNote, T_INVHED.InvCstNo, T_INVHED.IfDel, T_INVHED.RefNo, T_INVHED.ToStoreNm, T_INVHED.EngTaf, T_INVHED.IfTrans, T_INVHED.InvQty, T_INVHED.CustNet, T_INVHED.CustRep, T_INVHED.InvWight_T, T_INVHED.IfPrint, T_INVHED.LTim, T_INVHED.DATE_CREATED, T_INVHED.MODIFIED_BY, T_INVHED.CreditPay, T_INVHED.DATE_MODIFIED, T_INVHED.CREATED_BY, T_INVHED.CreditPayLocCur, T_INVHED.NetworkPay, T_INVHED.NetworkPayLocCur, T_INVHED.MndExtrnal, T_INVHED.CompanyID, T_INVHED.InvAddCost, T_INVHED.InvAddCostExtrnal, T_INVHED.InvAddCostExtrnalLoc, T_INVHED.IsExtrnalGaid, T_INVHED.ExtrnalCostGaidID, T_INVHED.InvAddCostLoc, T_INVHED.CommMnd_Inv, T_INVHED.Puyaid, T_INVHED.Remming,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select T_AccDef.PersonalNm from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as PersonalNm,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select T_AccDef.City from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as City,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select T_AccDef.Email from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as Email,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select T_AccDef.Mobile from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as Mobile,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select T_AccDef.Telphone1 from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as Telphone1,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select vColStr1 from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as CustAge,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select T_AccDef.Telphone2 from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as Telphone2,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select T_AccDef.Fax from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as Fax,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select T_AccDef.zipCod from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as zipCod,T_SYSSETTING.LineGiftlNameA,T_SYSSETTING.LineGiftlNameE,T_Curency.Arb_Des as CurrnceyNm,T_Curency.Eng_Des as CurrnceyNmE,(select max(gdDes)from T_GDDET where gdID = T_INVHED.GadeId )as gdDes, (T_INVDET.Amount - (case when T_INVHED.IsTaxLines = 1 then (case when T_INVHED.IsTaxByTotal = 1 then (case when (Abs(T_INVDET.Qty) *  T_INVDET.Price * T_INVDET.ItmTax / 100) > 0 then ((Abs(T_INVDET.Qty) *  T_INVDET.Price) - case when (Abs(T_INVDET.Qty) * T_INVDET.Price * T_INVDET.ItmDis / 100) > 0 then (Abs(T_INVDET.Qty) * T_INVDET.Price * T_INVDET.ItmDis / 100) else 0 end )* T_INVDET.ItmTax / 100   else 0 end) else (Abs(T_INVDET.Qty) *  T_INVDET.Price * T_INVDET.ItmTax / 100) end) else 0 end )) as TotBeforeTax,(select invGdADesc from T_INVSETTING where T_INVHED.InvTyp = T_INVSETTING.InvID ) as invGdADesc,(select invGdEDesc from T_INVSETTING where T_INVHED.InvTyp = T_INVSETTING.InvID ) as invGdEDesc,(select T_CATEGORY.CAT_No from T_CATEGORY where T_CATEGORY.CAT_ID = T_Items.ItmCat) as CAT_No,(select T_CATEGORY.Arb_Des from T_CATEGORY where T_CATEGORY.CAT_ID = T_Items.ItmCat) as CatNmA,(select T_CATEGORY.Eng_Des from T_CATEGORY where T_CATEGORY.CAT_ID = T_Items.ItmCat) as CatNmE,(case when (select t.BarCod1 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit1 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt )) != '' then (select t.BarCod1 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit1 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt ))  when (select t.BarCod2 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit2 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt )) != '' then (select t.BarCod2 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit2 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt )) when (select t.BarCod3 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit3 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt )) != '' then (select t.BarCod3 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit3 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt )) when (select t.BarCod4 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit4 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt )) != '' then (select t.BarCod4 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit4 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt )) when (select t.BarCod5 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit5 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt )) != '' then (select t.BarCod5 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit5 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt )) else T_Items.Itm_No  end) as ItmBarcod";
            string Fields = " Abs(T_INVDET.Qty) as QtyAbs , T_INVDET.InvDet_ID,T_INVHED.tailor1,T_INVHED.tailor2,T_INVHED.tailor3,T_INVHED.tailor4,T_INVHED.tailor5,T_INVHED.tailor6,T_INVHED.tailor7,T_INVHED.tailor8,T_INVHED.tailor9,T_INVHED.tailor10,T_INVHED.tailor11,T_INVHED.tailor12,T_INVHED.tailor13,T_INVHED.tailor14,T_INVHED.tailor15,T_INVHED.tailor16,T_INVHED.tailor17,T_INVHED.tailor18,T_INVHED.tailor19,T_INVHED.tailor20,T_INVHED.InvImg, T_INVDET.InvNo, T_INVDET.InvId, T_INVDET.InvSer, T_INVDET.ItmNo, T_INVDET.Cost, T_INVDET.Qty, T_INVDET.ItmUnt, T_INVDET.ItmDes,T_INVDET.ItmDesE , T_INVDET.ItmUntE, T_INVDET.ItmUntPak, T_INVDET.StoreNo, T_INVDET.Price, T_INVDET.Amount, T_INVDET.RealQty, T_INVDET.ItmTyp,T_INVDET.ItmDis, (Abs(T_INVDET.Qty) *  T_INVDET.Price) * (T_INVDET.ItmDis / 100) as ItmDisVal, T_INVDET.DatExper, T_INVDET.itmInvDsc,ItmIndex," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.LineGiftSts, vStr(VarGeneral.InvTyp)) ? " T_INVDET.ItmWight " : " 0 as ItmWight") + ", T_INVDET.ItmWight_T, T_INVDET.ItmAddCost, T_INVDET.RunCod, T_INVDET.LineDetails ,T_INVDET.Serial_Key, " + vInvH + ", T_Items.* , T_CstTbl.Arb_Des as CstTbl_Arb_Des , T_CstTbl.Eng_Des as CstTbl_Eng_Des , T_Mndob.Arb_Des as Mndob_Arb_Des , T_Mndob.Eng_Des as Mndob_Eng_Des,T_SYSSETTING.LogImg,(select max(T_AccDef.TaxNo) from T_AccDef where T_AccDef.AccDef_No = T_SYSSETTING.TaxAcc) as TaxAcc,T_SYSSETTING.TaxNoteInv,case when T_INVHED.IsTaxLines = 1 then (case when T_INVHED.IsTaxByTotal = 1 then (case when (Abs(T_INVDET.Qty) *  T_INVDET.Price * T_INVDET.ItmTax / 100) > 0 then ((Abs(T_INVDET.Qty) *  T_INVDET.Price) - case when (Abs(T_INVDET.Qty) * T_INVDET.Price * T_INVDET.ItmDis / 100) > 0 then (Abs(T_INVDET.Qty) * T_INVDET.Price * T_INVDET.ItmDis / 100) else 0 end )* T_INVDET.ItmTax / 100   else 0 end) else (Abs(T_INVDET.Qty) *  T_INVDET.Price * T_INVDET.ItmTax / 100) end) else 0 end as TaxValue ,(select InvNamA from T_INVSETTING where T_INVHED.InvTyp = T_INVSETTING.InvID ) as InvNamA,(select InvNamE from T_INVSETTING where T_INVHED.InvTyp = T_INVSETTING.InvID ) as InvNamE,(select T_Store.Arb_Des from T_Store where T_Store.Stor_ID = T_INVDET.StoreNo) as StoreNmA,(select T_Store.Eng_Des from T_Store where T_Store.Stor_ID = T_INVDET.StoreNo) as StoreNmE,(select defPrn from T_INVSETTING where CatID = (select ItmCat from T_Items where Itm_No = T_INVDET.ItmNo) ) as defPrn,case when T_INVHED.CusVenNo = '' THEN '0' ELSE (SELECT Sum(T_GDDET.gdValue) FROM T_GDHEAD INNER JOIN  T_GDDET ON T_GDHEAD.gdhead_ID = T_GDDET.gdID where T_GDDET.AccNo = T_INVHED.CusVenNo and T_GDHEAD.gdLok = 0 and (select T_AccDef.AccCat from T_AccDef where T_AccDef.AccDef_No = T_INVHED.CusVenNo) = '4') END as Balanc,T_INVDET.ItmTax,T_INVHED.InvAddTax,T_INVHED.InvAddTaxlLoc,T_INVHED.TaxGaidID,T_INVHED.IsTaxUse,T_INVHED.IsTaxLines,IsTaxByTotal,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select T_AccDef.TaxNo from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as TaxCustNo,T_INVHED.OrderTyp," + ((data_this.IsTaxLines.Value && !VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 65)) ? " T_INVHED.InvTotLocCur - T_INVHED.InvAddTax as TotWithTaxPoint " : " T_INVHED.InvTotLocCur as TotWithTaxPoint") + " ,T_INVHED.InvTotLocCur - T_INVHED.InvDisVal as TotBeforeDisVal,T_INVHED.IsTaxByNet,T_INVHED.TaxByNetValue," + (data_this.IsTaxUse.Value ? " T_INVHED.InvNetLocCur - T_INVHED.InvAddTax as NetWithoutTax " : " T_INVHED.InvNetLocCur as NetWithoutTax");
            VarGeneral.HeaderRep[0] = Text;
            VarGeneral.HeaderRep[1] = string.Empty;
            VarGeneral.HeaderRep[2] = string.Empty;
            _RepShow.Rule = " where T_INVHED.InvHed_ID = " + data_this.InvHed_ID;
            if (string.IsNullOrEmpty(Fields))
            {
                return;
            }
            _RepShow.Fields = Fields;
            try
            {
                _RepShow = _RepShow.Save();
                VarGeneral.RepData = _RepShow.RepData;
                _RepShow = new RepShow();
                _RepShow.Rule = " WHERE T_Users.UsrNo = '" + data_this.SalsManNo + "'";
                _RepShow.Tables = " T_Branch INNER JOIN T_Users ON T_Branch.Branch_no = T_Users.Brn ";
                _RepShow.Fields = " T_Users.UsrNamA ,T_Branch.Branch_Name ,T_Users.UsrNamE ,T_Branch.Branch_NameE ,T_Users.UsrImg ";
                try
                {
                    VarGeneral.RepShowStock_Rat = "Rate";
                    _RepShow = _RepShow.Save();
                    VarGeneral.RepShowStock_Rat = string.Empty;
                }
                catch (Exception ex2)
                {
                    VarGeneral.RepShowStock_Rat = string.Empty;
                    MessageBox.Show(ex2.Message);
                }
                try
                {
                    for (int i = 0; i < VarGeneral.RepData.Tables[0].Rows.Count; i++)
                    {
                        if (string.IsNullOrEmpty(VarGeneral.RepData.Tables[0].Rows[i]["LogImg"].ToString()))
                        {
                            VarGeneral.RepData.Tables[0].Rows[i]["LogImg"] = VarGeneral.RepData.Tables[0].Rows[VarGeneral.RepData.Tables[0].Rows.Count - 1]["LogImg"];
                            VarGeneral.RepData.Tables[0].Rows[i]["LTim"] = VarGeneral.RepData.Tables[0].Rows[VarGeneral.RepData.Tables[0].Rows.Count - 1]["LTim"];
                        }
                    }
                }
                catch
                {
                }
                try
                {
                    for (int i = 0; i < VarGeneral.RepData.Tables[0].Rows.Count; i++)
                    {
                        try
                        {
                            VarGeneral.RepData.Tables[0].Rows[i]["SalsManNam"] = _RepShow.RepData.Tables[0].Rows[0][(LangArEn == 0) ? "UsrNamA" : "UsrNamE"];
                        }
                        catch
                        {
                        }
                        try
                        {
                            VarGeneral.RepData.Tables[0].Rows[i]["Mobile"] = (VarGeneral.RepData.Tables[0].Rows[i]["Mobile"].ToString() == "" ? VarGeneral.RepData.Tables[0].Rows[i]["Mobile1"] : VarGeneral.RepData.Tables[0].Rows[i]["Mobile"]);
                        }
                        catch
                        {
                        }

                    }

                }
                catch
                {
                }
                try
                {
                    if (VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 15))
                    {
                        _RepShow = new RepShow();
                        _RepShow.Rule = string.Empty;
                        _RepShow.Tables = "T_SINVDET LEFT OUTER JOIN T_INVHED ON T_SINVDET.SInvIdHEAD = T_INVHED.InvHed_ID LEFT OUTER JOIN T_INVSETTING ON T_INVHED.InvTyp = T_INVSETTING.InvID  LEFT OUTER JOIN T_Curency ON T_INVHED.CurTyp = T_Curency.Curency_ID LEFT OUTER JOIN T_CstTbl ON T_INVHED.InvCstNo = T_CstTbl.Cst_ID LEFT OUTER JOIN T_Mndob ON T_INVHED.MndNo = T_Mndob.Mnd_ID LEFT OUTER JOIN T_Items ON T_SINVDET.SItmNo = T_Items.Itm_No LEFT OUTER JOIN T_CATEGORY ON T_Items.ItmCat = T_CATEGORY.CAT_ID LEFT OUTER JOIN T_SYSSETTING ON T_INVHED.CompanyID = T_SYSSETTING.SYSSETTING_ID ";
                        _RepShow.Fields = " Abs(T_SINVDET.SQty) as QtyAbs , SInvDet_ID as InvId, SInvNo as InvNo, SInvId as InvDet_ID, SInvSer as InvSer,SItmNo as ItmNo, SCost as Cost, SQty as Qty, SItmDes as ItmDes, SItmUnt as ItmUnt, SItmDesE as ItmDesE, SItmUntE as ItmUntE, SItmUntPak as ItmUntPak, SStoreNo as StoreNo, (SPrice * 0) as Price, (SAmount * 0) as Amount, SRealQty as RealQty, SitmInvDsc as itmInvDsc, SDatExper as DatExper, SItmDis as ItmDis, SItmTyp as ItmTyp,SItmIndex as ItmIndex, SItmWight_T as ItmWight_T, SItmWight as ItmWight , T_INVHED.* , T_Items.* , T_CstTbl.Arb_Des as CstTbl_Arb_Des , T_CstTbl.Eng_Des as CstTbl_Eng_Des , T_Mndob.Arb_Des as Mndob_Arb_Des , T_Mndob.Eng_Des as Mndob_Eng_Des,T_SYSSETTING.LogImg,(select max(T_AccDef.TaxNo) from T_AccDef where T_AccDef.AccDef_No = T_SYSSETTING.TaxAcc) as TaxAcc,T_SYSSETTING.TaxNoteInv";
                        _RepShow.Rule = " where T_INVHED.InvHed_ID = " + data_this.InvHed_ID;
                        _RepShow = _RepShow.Save();
                        VarGeneral.RepData.Tables[0].Merge(_RepShow.RepData.Tables[0]);
                    }
                }
                catch
                {
                }
                iiRntP = 0;
                _page = 1;
            }
            catch (Exception ex2)
            {
                MessageBox.Show(ex2.Message);
            }
        }
        public void SetLinesDET(List<T_SINVDET> listDet, int vRow)
        {
            try
            {
                dataGridView_ItemDet.Rows.Count = listDet.Count + 1;
                dataGridView_ItemDet.Cols[27].Visible = false;
                for (int iiCnt = 1; iiCnt <= listDet.Count; iiCnt++)
                {
                    T_SINVDET _SInvDet = listDet[iiCnt - 1];
                    int Ser = _SInvDet.SInvSer.GetValueOrDefault();
                    dataGridView_ItemDet.SetData(iiCnt, 0, Ser.ToString());
                    dataGridView_ItemDet.SetData(iiCnt, 1, _SInvDet.SItmNo.Trim());
                    dataGridView_ItemDet.SetData(iiCnt, 2, _SInvDet.SItmDes.ToString());
                    dataGridView_ItemDet.SetData(iiCnt, 3, _SInvDet.SItmUnt.ToString());
                    dataGridView_ItemDet.SetData(iiCnt, 4, _SInvDet.SItmDesE.ToString());
                    dataGridView_ItemDet.SetData(iiCnt, 5, _SInvDet.SItmUntE.ToString());
                    dataGridView_ItemDet.SetData(iiCnt, 6, _SInvDet.SStoreNo.Value);
                    dataGridView_ItemDet.SetData(iiCnt, 7, Math.Abs((decimal)_SInvDet.SQty.Value));
                    dataGridView_ItemDet.SetData(iiCnt, 8, _SInvDet.SPrice.Value);
                    dataGridView_ItemDet.SetData(iiCnt, 9, _SInvDet.SItmDis);
                    dataGridView_ItemDet.SetData(iiCnt, 10, _SInvDet.SCost.Value);
                    dataGridView_ItemDet.SetData(iiCnt, 11, _SInvDet.SItmUntPak.Value);
                    dataGridView_ItemDet.SetData(iiCnt, 12, Math.Abs((decimal)_SInvDet.SRealQty.Value));
                    dataGridView_ItemDet.SetData(iiCnt, 13, _SInvDet.SitmInvDsc.Value);
                    dataGridView_ItemDet.SetData(iiCnt, 14, _SInvDet.SCost.Value);
                    dataGridView_ItemDet.SetData(iiCnt, 15, _SInvDet.SItmDes.ToString());
                    dataGridView_ItemDet.SetData(iiCnt, 16, _SInvDet.SCost.Value);
                    dataGridView_ItemDet.SetData(iiCnt, 18, _SInvDet.T_Item.DefultUnit.Value);
                    dataGridView_ItemDet.SetData(iiCnt, 19, _SInvDet.T_Item.Price1.Value);
                    dataGridView_ItemDet.SetData(iiCnt, 20, _SInvDet.T_Item.Price2.Value);
                    dataGridView_ItemDet.SetData(iiCnt, 21, _SInvDet.T_Item.Price3.Value);
                    dataGridView_ItemDet.SetData(iiCnt, 22, _SInvDet.T_Item.Price4.Value);
                    dataGridView_ItemDet.SetData(iiCnt, 23, _SInvDet.T_Item.Price5.Value);
                    dataGridView_ItemDet.SetData(iiCnt, 25, _SInvDet.SInvDet_ID);
                    dataGridView_ItemDet.SetData(iiCnt, 27, _SInvDet.SDatExper ?? string.Empty);
                    dataGridView_ItemDet.SetData(iiCnt, 32, _SInvDet.SItmTyp.Value);
                    dataGridView_ItemDet.SetData(iiCnt, 38, _SInvDet.SAmount.Value);
                    dataGridView_ItemDet.SetData(iiCnt, 29, _SInvDet.SQtyDef.Value);
                    dataGridView_ItemDet.SetData(iiCnt, 17, _SInvDet.SPriceDef.Value);
                    listStkQty = (from t in db.T_STKSQTies
                                  where t.storeNo == (int?)_SInvDet.SStoreNo.Value
                                  where t.itmNo == _SInvDet.SItmNo.Trim()
                                  select t).ToList();
                    if (listStkQty.Count != 0)
                    {
                        _StksQty = listStkQty[0];
                        dataGridView_ItemDet.SetData(iiCnt, 24, _SInvDet.SRealQty.Value + _StksQty.stkQty.Value);
                    }
                }
                if (State == FormState.Saved)
                {
                    return;
                }
                double InvCost = 0.0;
                for (int i = 1; i < dataGridView_ItemDet.Rows.Count; i++)
                {
                    try
                    {
                        dataGridView_ItemDet.SetData(i, 7, double.Parse(VarGeneral.TString.TEmpty(string.Concat(dataGridView_ItemDet.GetData(i, 29)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(vRow, 7)))));
                        dataGridView_ItemDet.SetData(i, 8, double.Parse(VarGeneral.TString.TEmpty(string.Concat(dataGridView_ItemDet.GetData(i, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(dataGridView_ItemDet.GetData(i, 17)))));
                        dataGridView_ItemDet.SetData(i, 12, double.Parse(VarGeneral.TString.TEmpty(string.Concat(dataGridView_ItemDet.GetData(i, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(dataGridView_ItemDet.GetData(i, 11)))));
                        InvCost += double.Parse(VarGeneral.TString.TEmpty(string.Concat(dataGridView_ItemDet.GetData(i, 10)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(dataGridView_ItemDet.GetData(i, 12))));
                    }
                    catch
                    {
                    }
                }
                FlxInv.SetData(vRow, 10, InvCost);
            }
            catch
            {
                MessageBox.Show((LangArEn == 0) ? "حدث خطأ أثناء تعبئة الأسطر الفرعية .." : "An error occurred while filling lines ..", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
        public void SetLinesDet(List<T_ItemDet> listDet)
        {
            try
            {
                dataGridView_ItemDet.Rows.Count = listDet.Count + 1;
                for (int iiCnt = 1; iiCnt <= listDet.Count; iiCnt++)
                {
                    T_ItemDet _ItemsDet = listDet[iiCnt - 1];
                    FillItemDet(db.StockItem(_ItemsDet.GItmNo), Barcod: false, iiCnt, _ItemsDet.Unit_.Value, _ItemsDet.StoreNo.Value, Math.Abs(_ItemsDet.Qty.Value), _ItemsDet.Price.Value);
                }
                if (State == FormState.Saved)
                {
                    return;
                }
                double InvCost = 0.0;
                for (int i = 1; i < dataGridView_ItemDet.Rows.Count; i++)
                {
                    try
                    {
                        dataGridView_ItemDet.SetData(i, 7, double.Parse(VarGeneral.TString.TEmpty(string.Concat(dataGridView_ItemDet.GetData(i, 7)))) * ((double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 7)))) > 0.0) ? double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 7)))) : 1.0));
                        dataGridView_ItemDet.SetData(i, 8, double.Parse(VarGeneral.TString.TEmpty(string.Concat(dataGridView_ItemDet.GetData(i, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(dataGridView_ItemDet.GetData(i, 17)))));
                        dataGridView_ItemDet.SetData(i, 12, double.Parse(VarGeneral.TString.TEmpty(string.Concat(dataGridView_ItemDet.GetData(i, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(dataGridView_ItemDet.GetData(i, 11)))));
                        InvCost += double.Parse(VarGeneral.TString.TEmpty(string.Concat(dataGridView_ItemDet.GetData(i, 10)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(dataGridView_ItemDet.GetData(i, 12))));
                    }
                    catch
                    {
                    }
                }
                FlxInv.SetData(FlxInv.RowSel, 10, InvCost);
            }
            catch
            {
                MessageBox.Show((LangArEn == 0) ? "حدث خطأ أثناء تعبئة بيانات الصنف المجمع .." : "An error occurred while filling lines ..", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
        private void GridDetUpdate(int vRow)
        {
            if (State == FormState.Saved)
            {
                return;
            }
            try
            {
                try
                {
                    dataGridView_ItemDet.Clear(ClearFlags.Content, 1, 1, dataGridView_ItemDet.Rows.Count - 1, 34);
                }
                catch
                {
                }
                dataGridView_ItemDet.Rows.Count = 1;
                if (!string.IsNullOrEmpty(FlxInv.GetData(vRow, 1).ToString()) && double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(vRow, 32)))) == 2.0)
                {
                    FlxStkQty.Clear(ClearFlags.Content, 1, 1, 1, 1);
                    _Items = db.StockItemList(FlxInv.GetData(vRow, 1).ToString()).First();
                    dataGridView_ItemDet.Visible = true;
                    Stock_DataDataContext dbc = new Stock_DataDataContext(VarGeneral.BranchCS);
                    if (State == FormState.New && (int.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(vRow, 25)))) <= 0 || string.IsNullOrEmpty(FlxInv.GetData(vRow, 25).ToString())))
                    {
                        List<T_ItemDet> ItmDet = db.T_ItemDets.Where((T_ItemDet t) => t.ItmNo == _Items.Itm_No).ToList();
                        SetLinesDet(ItmDet);
                        return;
                    }
                    List<T_SINVDET> ItmDEt = dbc.T_SINVDETs.Where((T_SINVDET t) => t.SInvId == (int?)int.Parse(VarGeneral.TString.TEmpty(string.Empty + FlxInv.GetData(vRow, 25)))).ToList();
                    if (ItmDEt.Count <= 0)
                    {
                        List<T_ItemDet> ItmDet = db.T_ItemDets.Where((T_ItemDet t) => t.ItmNo == _Items.Itm_No).ToList();
                        SetLinesDet(ItmDet);
                    }
                    else
                    {
                        SetLinesDET(ItmDEt, vRow);
                    }
                }
                else
                {
                    dataGridView_ItemDet.Visible = false;
                }
            }
            catch
            {
                dataGridView_ItemDet.Visible = false;
            }
        }
        private void dataGridView_ItemDet_MouseDown(object sender, MouseEventArgs e)
        {
            if (!(string.Concat(dataGridView_ItemDet.GetData(dataGridView_ItemDet.RowSel, 1)) != string.Empty))
            {
                return;
            }
            _Items = db.StockItem(string.Concat(dataGridView_ItemDet.GetData(dataGridView_ItemDet.RowSel, 1)));
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
            {
                txtItemName.Text = _Items.Arb_Des.Trim();
            }
            else
            {
                txtItemName.Text = _Items.Eng_Des.Trim();
            }
            string CoA = string.Empty;
            string CoE = string.Empty;
            for (int iiCnt = 0; iiCnt < listUnit.Count; iiCnt++)
            {
                _Unit = listUnit[iiCnt];
                if (_Items.Unit1 == _Unit.Unit_ID)
                {
                    if (CoA != string.Empty)
                    {
                        CoA += "|";
                        CoE += "|";
                    }
                    CoA += _Unit.Arb_Des;
                    CoE += _Unit.Eng_Des;
                    break;
                }
            }
            for (int iiCnt = 0; iiCnt < listUnit.Count; iiCnt++)
            {
                _Unit = listUnit[iiCnt];
                if (_Items.Unit2 == _Unit.Unit_ID)
                {
                    if (CoA != string.Empty)
                    {
                        CoA += "|";
                        CoE += "|";
                    }
                    CoA += _Unit.Arb_Des;
                    CoE += _Unit.Eng_Des;
                    break;
                }
            }
            for (int iiCnt = 0; iiCnt < listUnit.Count; iiCnt++)
            {
                _Unit = listUnit[iiCnt];
                if (_Items.Unit3 == _Unit.Unit_ID)
                {
                    if (CoA != string.Empty)
                    {
                        CoA += "|";
                        CoE += "|";
                    }
                    CoA += _Unit.Arb_Des;
                    CoE += _Unit.Eng_Des;
                    break;
                }
            }
            for (int iiCnt = 0; iiCnt < listUnit.Count; iiCnt++)
            {
                _Unit = listUnit[iiCnt];
                if (_Items.Unit4 == _Unit.Unit_ID)
                {
                    if (CoA != string.Empty)
                    {
                        CoA += "|";
                        CoE += "|";
                    }
                    CoA += _Unit.Arb_Des;
                    CoE += _Unit.Eng_Des;
                    break;
                }
            }
            for (int iiCnt = 0; iiCnt < listUnit.Count; iiCnt++)
            {
                _Unit = listUnit[iiCnt];
                if (_Items.Unit5 == _Unit.Unit_ID)
                {
                    if (CoA != string.Empty)
                    {
                        CoA += "|";
                        CoE += "|";
                    }
                    CoA += _Unit.Arb_Des;
                    CoE += _Unit.Eng_Des;
                    break;
                }
            }
            dataGridView_ItemDet.Cols[3].ComboList = CoA;
            dataGridView_ItemDet.Cols[5].ComboList = CoE;
            txtVCost.Text = string.Concat(Math.Round(_Items.AvrageCost.Value * double.Parse(VarGeneral.TString.TEmpty(string.Concat(dataGridView_ItemDet.GetData(dataGridView_ItemDet.RowSel, 11)))) / RateValue, VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2));
            txtLCost.Text = string.Concat(Math.Round(_Items.LastCost.Value * double.Parse(VarGeneral.TString.TEmpty(string.Concat(dataGridView_ItemDet.GetData(dataGridView_ItemDet.RowSel, 11)))) / RateValue, VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2));
            txtVSerial.Text = _Items.SerialKey ?? string.Empty;
            BindDataOfStkQtyDEt(string.Concat(dataGridView_ItemDet.GetData(dataGridView_ItemDet.RowSel, 1)));
        }
        private void BindDataOfStkQtyDEt(string ItmNo)
        {
            try
            {
                FlxStkQty.Clear(ClearFlags.Content, 1, 1, 1, 1);
                listStkQty = db.T_STKSQTies.Where((T_STKSQTY t) => t.itmNo == ItmNo).ToList();
                dataGridView_ItemDet.SetData(dataGridView_ItemDet.Row, 24, 0);
                for (int iiCnt = 0; iiCnt < listStkQty.Count; iiCnt++)
                {
                    _StksQty = listStkQty[iiCnt];
                    for (int I = 1; I < FlxStkQty.Rows.Count; I++)
                    {
                        if (_StksQty.storeNo.Value.ToString().Trim() == FlxStkQty.GetData(I, 0).ToString())
                        {
                            FlxStkQty.SetData(I, 1, _StksQty.stkQty / double.Parse(VarGeneral.TString.TEmpty(dataGridView_ItemDet.GetData(dataGridView_ItemDet.Row, 11).ToString())));
                            if (_StksQty.storeNo.Value.ToString().Trim() == dataGridView_ItemDet.GetData(dataGridView_ItemDet.RowSel, 6).ToString())
                            {
                                dataGridView_ItemDet.SetData(dataGridView_ItemDet.Row, 24, _StksQty.stkQty);
                            }
                        }
                    }
                }
            }
            catch
            {
            }
        }
        private void FillItemDet(T_Item _Itm, bool Barcod, int vRow, int vUntID, int vStoreNo, double vQty, double vPrice)
        {
            dataGridView_ItemDet.SetData(vRow, 1, _Itm.Itm_No.Trim());
            dataGridView_ItemDet.SetData(vRow, 2, _Itm.Arb_Des.Trim());
            dataGridView_ItemDet.SetData(vRow, 4, _Itm.Eng_Des.Trim());
            dataGridView_ItemDet.SetData(vRow, 6, (vUntID == 0) ? 1 : vStoreNo);
            string CoA = string.Empty;
            string CoE = string.Empty;
            string DefUnitA = string.Empty;
            string DefUnitE = string.Empty;
            for (int iiCnt = 0; iiCnt < listUnit.Count; iiCnt++)
            {
                _Unit = listUnit[iiCnt];
                if (!((vUntID != 0) ? (vUntID == 1) : (_Itm.Unit1 == _Unit.Unit_ID)))
                {
                    continue;
                }
                if (CoA != string.Empty)
                {
                    CoA += "|";
                    CoE += "|";
                }
                CoA += _Unit.Arb_Des;
                CoE += _Unit.Eng_Des;
                if (_Itm.DefultUnit == 1 && DefPack == 0)
                {
                    Pack = _Itm.Pack1.Value;
                    if (vUntID == 0)
                    {
                        DefUnitA = _Unit.Arb_Des;
                        DefUnitE = _Unit.Eng_Des;
                    }
                    else
                    {
                        DefUnitA = _Itm.T_Unit.Arb_Des;
                        DefUnitE = _Itm.T_Unit.Eng_Des;
                    }
                    dataGridView_ItemDet.SetData(vRow, 8, (vUntID == 0) ? _Itm.UntPri1.Value : vPrice);
                    dataGridView_ItemDet.SetData(vRow, 11, _Itm.Pack1.Value);
                }
                else if (vUntID != 0 || DefPack == 1)
                {
                    Pack = _Itm.Pack1.Value;
                    if (vUntID == 0)
                    {
                        DefUnitA = _Unit.Arb_Des;
                        DefUnitE = _Unit.Eng_Des;
                    }
                    else
                    {
                        DefUnitA = _Itm.T_Unit.Arb_Des;
                        DefUnitE = _Itm.T_Unit.Eng_Des;
                    }
                    dataGridView_ItemDet.SetData(vRow, 8, (vUntID == 0) ? _Itm.UntPri1.Value : vPrice);
                    dataGridView_ItemDet.SetData(vRow, 11, _Itm.Pack1);
                }
                if (vUntID == 0)
                {
                }
                break;
            }
            for (int iiCnt = 0; iiCnt < listUnit.Count; iiCnt++)
            {
                _Unit = listUnit[iiCnt];
                if (!((vUntID != 0) ? (vUntID == 2) : (_Itm.Unit2 == _Unit.Unit_ID)))
                {
                    continue;
                }
                if (CoA != string.Empty)
                {
                    CoA += "|";
                    CoE += "|";
                }
                CoA += _Unit.Arb_Des;
                CoE += _Unit.Arb_Des;
                if (_Itm.DefultUnit == 2 && DefPack == 0)
                {
                    Pack = _Itm.Pack2.Value;
                    if (vUntID == 0)
                    {
                        DefUnitA = _Unit.Arb_Des;
                        DefUnitE = _Unit.Eng_Des;
                    }
                    else
                    {
                        DefUnitA = _Itm.T_Unit1.Arb_Des;
                        DefUnitE = _Itm.T_Unit1.Eng_Des;
                    }
                    dataGridView_ItemDet.SetData(vRow, 8, (vUntID == 0) ? _Itm.UntPri2.Value : vPrice);
                    dataGridView_ItemDet.SetData(vRow, 11, _Itm.Pack2);
                }
                else if (vUntID != 0 || DefPack == 2)
                {
                    Pack = _Itm.Pack2.Value;
                    if (vUntID == 0)
                    {
                        DefUnitA = _Unit.Arb_Des;
                        DefUnitE = _Unit.Eng_Des;
                    }
                    else
                    {
                        DefUnitA = _Itm.T_Unit1.Arb_Des;
                        DefUnitE = _Itm.T_Unit1.Eng_Des;
                    }
                    dataGridView_ItemDet.SetData(vRow, 8, (vUntID == 0) ? _Itm.UntPri2.Value : vPrice);
                    dataGridView_ItemDet.SetData(vRow, 11, _Itm.Pack2);
                }
                if (vUntID == 0)
                {
                }
                break;
            }
            for (int iiCnt = 0; iiCnt < listUnit.Count; iiCnt++)
            {
                _Unit = listUnit[iiCnt];
                if (!((vUntID != 0) ? (vUntID == 3) : (_Itm.Unit3 == _Unit.Unit_ID)))
                {
                    continue;
                }
                if (CoA != string.Empty)
                {
                    CoA += "|";
                    CoE += "|";
                }
                CoA += _Unit.Arb_Des;
                CoE += _Unit.Eng_Des;
                if (_Itm.DefultUnit == 3 && DefPack == 0)
                {
                    Pack = _Itm.Pack3.Value;
                    if (vUntID == 0)
                    {
                        DefUnitA = _Unit.Arb_Des;
                        DefUnitE = _Unit.Eng_Des;
                    }
                    else
                    {
                        DefUnitA = _Itm.T_Unit2.Arb_Des;
                        DefUnitE = _Itm.T_Unit2.Eng_Des;
                    }
                    dataGridView_ItemDet.SetData(vRow, 8, (vUntID == 0) ? _Itm.UntPri3.Value : vPrice);
                    dataGridView_ItemDet.SetData(vRow, 11, _Itm.Pack3);
                }
                else if (vUntID != 0 || DefPack == 3)
                {
                    Pack = _Itm.Pack3.Value;
                    if (vUntID == 0)
                    {
                        DefUnitA = _Unit.Arb_Des;
                        DefUnitE = _Unit.Eng_Des;
                    }
                    else
                    {
                        DefUnitA = _Itm.T_Unit2.Arb_Des;
                        DefUnitE = _Itm.T_Unit2.Eng_Des;
                    }
                    dataGridView_ItemDet.SetData(vRow, 8, (vUntID == 0) ? _Itm.UntPri3.Value : vPrice);
                    dataGridView_ItemDet.SetData(vRow, 11, _Itm.Pack3);
                }
                if (vUntID == 0)
                {
                }
                break;
            }
            for (int iiCnt = 0; iiCnt < listUnit.Count; iiCnt++)
            {
                _Unit = listUnit[iiCnt];
                if (!((vUntID != 0) ? (vUntID == 4) : (_Itm.Unit4 == _Unit.Unit_ID)))
                {
                    continue;
                }
                if (CoA != string.Empty)
                {
                    CoA += "|";
                    CoE += "|";
                }
                CoA += _Unit.Arb_Des;
                CoE += _Unit.Eng_Des;
                if (_Itm.DefultUnit == 4 && DefPack == 0)
                {
                    Pack = _Itm.Pack4.Value;
                    if (vUntID == 0)
                    {
                        DefUnitA = _Unit.Arb_Des;
                        DefUnitE = _Unit.Eng_Des;
                    }
                    else
                    {
                        DefUnitA = _Itm.T_Unit3.Arb_Des;
                        DefUnitE = _Itm.T_Unit3.Eng_Des;
                    }
                    dataGridView_ItemDet.SetData(vRow, 8, (vUntID == 0) ? _Itm.UntPri4.Value : vPrice);
                    dataGridView_ItemDet.SetData(vRow, 11, _Itm.Pack4);
                }
                else if (vUntID != 0 || DefPack == 4)
                {
                    Pack = _Itm.Pack4.Value;
                    if (vUntID == 0)
                    {
                        DefUnitA = _Unit.Arb_Des;
                        DefUnitE = _Unit.Eng_Des;
                    }
                    else
                    {
                        DefUnitA = _Itm.T_Unit3.Arb_Des;
                        DefUnitE = _Itm.T_Unit3.Eng_Des;
                    }
                    dataGridView_ItemDet.SetData(vRow, 8, (vUntID == 0) ? _Itm.UntPri4.Value : vPrice);
                    dataGridView_ItemDet.SetData(vRow, 11, _Itm.Pack4);
                }
                if (vUntID == 0)
                {
                }
                break;
            }
            for (int iiCnt = 0; iiCnt < listUnit.Count; iiCnt++)
            {
                _Unit = listUnit[iiCnt];
                if (!((vUntID != 0) ? (vUntID == 5) : (_Itm.Unit5 == _Unit.Unit_ID)))
                {
                    continue;
                }
                if (CoA != string.Empty)
                {
                    CoA += "|";
                    CoE += "|";
                }
                CoA += _Unit.Arb_Des;
                CoE += _Unit.Eng_Des;
                if (_Itm.DefultUnit == 5 && DefPack == 0)
                {
                    Pack = _Itm.Pack5.Value;
                    if (vUntID == 0)
                    {
                        DefUnitA = _Unit.Arb_Des;
                        DefUnitE = _Unit.Eng_Des;
                    }
                    else
                    {
                        DefUnitA = _Itm.T_Unit4.Arb_Des;
                        DefUnitE = _Itm.T_Unit4.Eng_Des;
                    }
                    dataGridView_ItemDet.SetData(vRow, 8, (vUntID == 0) ? _Itm.UntPri5.Value : vPrice);
                    dataGridView_ItemDet.SetData(vRow, 11, _Itm.Pack5);
                }
                else if (vUntID != 0 || DefPack == 5)
                {
                    Pack = _Itm.Pack5.Value;
                    if (vUntID == 0)
                    {
                        DefUnitA = _Unit.Arb_Des;
                        DefUnitE = _Unit.Eng_Des;
                    }
                    else
                    {
                        DefUnitA = _Itm.T_Unit4.Arb_Des;
                        DefUnitE = _Itm.T_Unit4.Eng_Des;
                    }
                    dataGridView_ItemDet.SetData(vRow, 8, (vUntID == 0) ? _Itm.UntPri5.Value : vPrice);
                    dataGridView_ItemDet.SetData(vRow, 11, _Itm.Pack5);
                }
                if (vUntID == 0)
                {
                }
                break;
            }
            dataGridView_ItemDet.Cols[3].ComboList = CoA;
            dataGridView_ItemDet.Cols[5].ComboList = CoE;
            dataGridView_ItemDet.SetData(vRow, 3, DefUnitA);
            dataGridView_ItemDet.SetData(vRow, 5, DefUnitE);
            dataGridView_ItemDet.SetData(vRow, 10, _Itm.AvrageCost * double.Parse(VarGeneral.TString.TEmpty(string.Concat(dataGridView_ItemDet.GetData(vRow, 11)))) / RateValue);
            dataGridView_ItemDet.SetData(vRow, 30, _Itm.LastCost * double.Parse(VarGeneral.TString.TEmpty(string.Concat(dataGridView_ItemDet.GetData(vRow, 11)))) / RateValue);
            dataGridView_ItemDet.SetData(vRow, 28, _Itm.Lot);
            dataGridView_ItemDet.SetData(vRow, 32, _Itm.ItmTyp);
            dataGridView_ItemDet.SetData(vRow, 33, _Itm.ItmLoc);
            dataGridView_ItemDet.SetData(vRow, 18, _Itm.DefPack);
            dataGridView_ItemDet.SetData(vRow, 19, _Itm.Price1);
            dataGridView_ItemDet.SetData(vRow, 20, _Itm.Price2);
            dataGridView_ItemDet.SetData(vRow, 21, _Itm.Price3);
            dataGridView_ItemDet.SetData(vRow, 22, _Itm.Price4);
            dataGridView_ItemDet.SetData(vRow, 23, _Itm.Price5);
            dataGridView_ItemDet.SetData(vRow, 17, vPrice);
            dataGridView_ItemDet.SetData(vRow, 8, double.Parse(VarGeneral.TString.TEmpty(string.Concat(dataGridView_ItemDet.GetData(vRow, 17)))) / RateValue);
            dataGridView_ItemDet.SetData(vRow, 7, (vUntID == 0) ? 0.0 : vQty);
            dataGridView_ItemDet.SetData(vRow, 29, vQty);
            dataGridView_ItemDet.SetData(vRow, 12, double.Parse(VarGeneral.TString.TEmpty(string.Concat(dataGridView_ItemDet.GetData(vRow, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(dataGridView_ItemDet.GetData(vRow, 11)))));
            dataGridView_ItemDet.SetData(vRow, 31, double.Parse(VarGeneral.TString.TEmpty(string.Concat(dataGridView_ItemDet.GetData(vRow, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(dataGridView_ItemDet.GetData(vRow, 8)))));
            VarGeneral.Flush();
        }
        private void txtDebit1_ButtonCustomClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_ID.Text))
            {
                return;
            }
            Button_Edit_Click(sender, e);
            columns_Names_visible2.Clear();
            columns_Names_visible2.Clear();
            columns_Names_visible2.Add("AccDef_No", new ColumnDictinary("الرقم ", " No", ifDefault: true, string.Empty));
            columns_Names_visible2.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, string.Empty));
            columns_Names_visible2.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, string.Empty));
            columns_Names_visible2.Add("AccDef_ID", new ColumnDictinary(" ", " ", ifDefault: false, string.Empty));
            columns_Names_visible2.Add("Mobile", new ColumnDictinary("الجوال", "Mobile", ifDefault: false, string.Empty));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible2;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
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
                if (frm.SerachNo != string.Empty)
                {
                    T_AccDef _AccDef = db.StockAccDefs(int.Parse(frm.Serach_No));
                    txtDebit1.Tag = _AccDef.AccDef_No;
                    if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
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
                    txtDebit1.Text = string.Empty;
                    txtDebit1.Tag = string.Empty;
                }
            }
            catch
            {
                txtDebit1.Text = string.Empty;
                txtDebit1.Tag = string.Empty;
            }
        }
        private void txtDebit2_ButtonCustomClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_ID.Text))
            {
                return;
            }
            Button_Edit_Click(sender, e);
            columns_Names_visible2.Clear();
            columns_Names_visible2.Clear();
            columns_Names_visible2.Add("AccDef_No", new ColumnDictinary("الرقم ", " No", ifDefault: true, string.Empty));
            columns_Names_visible2.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, string.Empty));
            columns_Names_visible2.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, string.Empty));
            columns_Names_visible2.Add("AccDef_ID", new ColumnDictinary(" ", " ", ifDefault: false, string.Empty));
            columns_Names_visible2.Add("Mobile", new ColumnDictinary("الجوال", "Mobile", ifDefault: false, string.Empty));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible2;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
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
                if (frm.SerachNo != string.Empty)
                {
                    T_AccDef _AccDef = db.StockAccDefs(int.Parse(frm.Serach_No));
                    txtDebit2.Tag = _AccDef.AccDef_No;
                    if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                    {
                        txtDebit2.Text = _AccDef.Arb_Des;
                    }
                    else
                    {
                        txtDebit2.Text = _AccDef.Eng_Des;
                    }
                }
                else
                {
                    txtDebit2.Text = string.Empty;
                    txtDebit2.Tag = string.Empty;
                }
            }
            catch
            {
                txtDebit2.Text = string.Empty;
                txtDebit2.Tag = string.Empty;
            }
        }
        private void txtDebit3_ButtonCustomClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_ID.Text))
            {
                return;
            }
            Button_Edit_Click(sender, e);
            columns_Names_visible2.Clear();
            columns_Names_visible2.Clear();
            columns_Names_visible2.Add("AccDef_No", new ColumnDictinary("الرقم ", " No", ifDefault: true, string.Empty));
            columns_Names_visible2.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, string.Empty));
            columns_Names_visible2.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, string.Empty));
            columns_Names_visible2.Add("AccDef_ID", new ColumnDictinary(" ", " ", ifDefault: false, string.Empty));
            columns_Names_visible2.Add("Mobile", new ColumnDictinary("الجوال", "Mobile", ifDefault: false, string.Empty));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible2;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
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
                if (frm.SerachNo != string.Empty)
                {
                    T_AccDef _AccDef = db.StockAccDefs(int.Parse(frm.Serach_No));
                    txtDebit3.Tag = _AccDef.AccDef_No;
                    if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                    {
                        txtDebit3.Text = _AccDef.Arb_Des;
                    }
                    else
                    {
                        txtDebit3.Text = _AccDef.Eng_Des;
                    }
                }
                else
                {
                    txtDebit3.Text = string.Empty;
                    txtDebit3.Tag = string.Empty;
                }
            }
            catch
            {
                txtDebit3.Text = string.Empty;
                txtDebit3.Tag = string.Empty;
            }
        }
        private void txtCredit1_ButtonCustomClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_ID.Text))
            {
                return;
            }
            Button_Edit_Click(sender, e);
            columns_Names_visible2.Clear();
            columns_Names_visible2.Clear();
            columns_Names_visible2.Add("AccDef_No", new ColumnDictinary("الرقم ", " No", ifDefault: true, string.Empty));
            columns_Names_visible2.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, string.Empty));
            columns_Names_visible2.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, string.Empty));
            columns_Names_visible2.Add("AccDef_ID", new ColumnDictinary(" ", " ", ifDefault: false, string.Empty));
            columns_Names_visible2.Add("Mobile", new ColumnDictinary("الجوال", "Mobile", ifDefault: false, string.Empty));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible2;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
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
                if (frm.SerachNo != string.Empty)
                {
                    T_AccDef _AccDef = db.StockAccDefs(int.Parse(frm.Serach_No));
                    txtCredit1.Tag = _AccDef.AccDef_No;
                    if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
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
                    txtCredit1.Text = string.Empty;
                    txtCredit1.Tag = string.Empty;
                }
            }
            catch
            {
                txtCredit1.Text = string.Empty;
                txtCredit1.Tag = string.Empty;
            }
        }
        private void txtCredit2_ButtonCustomClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_ID.Text))
            {
                return;
            }
            Button_Edit_Click(sender, e);
            columns_Names_visible2.Clear();
            columns_Names_visible2.Clear();
            columns_Names_visible2.Add("AccDef_No", new ColumnDictinary("الرقم ", " No", ifDefault: true, string.Empty));
            columns_Names_visible2.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, string.Empty));
            columns_Names_visible2.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, string.Empty));
            columns_Names_visible2.Add("AccDef_ID", new ColumnDictinary(" ", " ", ifDefault: false, string.Empty));
            columns_Names_visible2.Add("Mobile", new ColumnDictinary("الجوال", "Mobile", ifDefault: false, string.Empty));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible2;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
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
                if (frm.SerachNo != string.Empty)
                {
                    T_AccDef _AccDef = db.StockAccDefs(int.Parse(frm.Serach_No));
                    txtCredit2.Tag = _AccDef.AccDef_No;
                    if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                    {
                        txtCredit2.Text = _AccDef.Arb_Des;
                    }
                    else
                    {
                        txtCredit2.Text = _AccDef.Eng_Des;
                    }
                }
                else
                {
                    txtCredit2.Text = string.Empty;
                    txtCredit2.Tag = string.Empty;
                }
            }
            catch
            {
                txtCredit2.Text = string.Empty;
                txtCredit2.Tag = string.Empty;
            }
        }
        private void txtCredit3_ButtonCustomClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_ID.Text))
            {
                return;
            }
            Button_Edit_Click(sender, e);
            columns_Names_visible2.Clear();
            columns_Names_visible2.Clear();
            columns_Names_visible2.Add("AccDef_No", new ColumnDictinary("الرقم ", " No", ifDefault: true, string.Empty));
            columns_Names_visible2.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, string.Empty));
            columns_Names_visible2.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, string.Empty));
            columns_Names_visible2.Add("AccDef_ID", new ColumnDictinary(" ", " ", ifDefault: false, string.Empty));
            columns_Names_visible2.Add("Mobile", new ColumnDictinary("الجوال", "Mobile", ifDefault: false, string.Empty));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible2;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
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
                if (frm.SerachNo != string.Empty)
                {
                    T_AccDef _AccDef = db.StockAccDefs(int.Parse(frm.Serach_No));
                    txtCredit3.Tag = _AccDef.AccDef_No;
                    if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                    {
                        txtCredit3.Text = _AccDef.Arb_Des;
                    }
                    else
                    {
                        txtCredit3.Text = _AccDef.Eng_Des;
                    }
                }
                else
                {
                    txtCredit3.Text = string.Empty;
                    txtCredit3.Tag = string.Empty;
                }
            }
            catch
            {
                txtCredit3.Text = string.Empty;
                txtCredit3.Tag = string.Empty;
            }
        }
        private void txtCustNo_TextChanged(object sender, EventArgs e)
        {
            if (txtCustNo.Text != string.Empty)
            {
                txtCustName.ReadOnly = true;
                txtTele.ReadOnly = true;
                txtAddress.ReadOnly = true;
                text_Mobile.ReadOnly = true;
                try
                {
                    T_AccDef h = db.StockAccDefsByAcNO(txtCustNo.Text);
                    text_Mobile.Text = h.Mobile;
                }
                catch { }
            }
            else
            {
                txtCustName.ReadOnly = false;
                txtTele.ReadOnly = false;
                text_Mobile.Text = string.Empty;
                text_Mobile.ReadOnly = false;
                txtAddress.ReadOnly = false;
            }
        }
        private void button_CustD1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCustNo.Text))
            {
                Button_Edit_Click(sender, e);
                txtDebit1.Tag = txtCustNo.Text;
                txtDebit1.Text = ((LangArEn == 0) ? db.SelectAccRootByCode(txtCustNo.Text).Arb_Des : db.SelectAccRootByCode(txtCustNo.Text).Eng_Des);
            }
        }
        private void button_CustD2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCustNo.Text))
            {
                Button_Edit_Click(sender, e);
                txtDebit2.Tag = txtCustNo.Text;
                txtDebit2.Text = ((LangArEn == 0) ? db.SelectAccRootByCode(txtCustNo.Text).Arb_Des : db.SelectAccRootByCode(txtCustNo.Text).Eng_Des);
            }
        }
        private void button_CustD3_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCustNo.Text))
            {
                Button_Edit_Click(sender, e);
                txtDebit3.Tag = txtCustNo.Text;
                txtDebit3.Text = ((LangArEn == 0) ? db.SelectAccRootByCode(txtCustNo.Text).Arb_Des : db.SelectAccRootByCode(txtCustNo.Text).Eng_Des);
            }
        }
        private void button_CustC1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCustNo.Text))
            {
                Button_Edit_Click(sender, e);
                txtCredit1.Tag = txtCustNo.Text;
                txtCredit1.Text = ((LangArEn == 0) ? db.SelectAccRootByCode(txtCustNo.Text).Arb_Des : db.SelectAccRootByCode(txtCustNo.Text).Eng_Des);
            }
        }
        private void button_CustC2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCustNo.Text))
            {
                Button_Edit_Click(sender, e);
                txtCredit2.Tag = txtCustNo.Text;
                txtCredit2.Text = ((LangArEn == 0) ? db.SelectAccRootByCode(txtCustNo.Text).Arb_Des : db.SelectAccRootByCode(txtCustNo.Text).Eng_Des);
            }
        }
        private void button_CustC3_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCustNo.Text))
            {
                Button_Edit_Click(sender, e);
                txtCredit3.Tag = txtCustNo.Text;
                txtCredit3.Text = ((LangArEn == 0) ? db.SelectAccRootByCode(txtCustNo.Text).Arb_Des : db.SelectAccRootByCode(txtCustNo.Text).Eng_Des);
            }
        }
        private void LastPrice(T_Item vItm)
        {
            try
            {
                var q = (from t in db.T_INVDETs
                         where t.T_INVHED.InvTyp == (int?)VarGeneral.InvTyp
                         where t.ItmNo == vItm.Itm_No
                         orderby t.T_INVHED.InvHed_ID descending
                         select new
                         {
                             t.InvNo,
                             t.Price,
                             t.ItmUnt,
                             t.ItmUntE,
                             t.InvSer
                         }).ToList();
                if (q.Count > 0)
                {
                    T_INVHED vInvH = db.StockInvHead(VarGeneral.InvTyp, q.First().InvNo);
                    txtLPrice.Text = string.Concat(Math.Round(vInvH.T_INVDETs.Where((T_INVDET g) => g.ItmNo == vItm.Itm_No).Last().Price.Value / RateValue, VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2));
                    txtUnit.Text = ((LangArEn == 0) ? vInvH.T_INVDETs.Last().ItmUnt : vInvH.T_INVDETs.Last().ItmUntE);
                }
                else
                {
                    txtLPrice.Text = "0";
                    txtUnit.Text = string.Empty;
                }
            }
            catch
            {
                txtLPrice.Text = "0";
                txtUnit.Text = string.Empty;
            }
        }
        private void doubleInput_NetWorkLoc_Leave(object sender, EventArgs e)
        {
            try
            {
                if (!(doubleInput_NetWorkLoc.Value > 0.0))
                {
                    return;
                }
                if (txtPaymentLoc.Value > 0.0 || doubleInput_CreditLoc.Value > 0.0)
                {
                    if (!(txtPaymentLoc.Value > 0.0) || !(doubleInput_CreditLoc.Value > 0.0))
                    {
                        if (txtPaymentLoc.Value > 0.0)
                        {
                            txtPaymentLoc.Value = (checkBox_CostGaidTax.Checked ? (txtDueAmountLoc.Value - txtTotTax.Value) : txtDueAmountLoc.Value) - doubleInput_NetWorkLoc.Value;
                        }
                        else
                        {
                            doubleInput_CreditLoc.Value = (checkBox_CostGaidTax.Checked ? (txtDueAmountLoc.Value - txtTotTax.Value) : txtDueAmountLoc.Value) - doubleInput_NetWorkLoc.Value;
                        }
                    }
                }
                else
                {
                    txtPaymentLoc.Value = (checkBox_CostGaidTax.Checked ? (txtDueAmountLoc.Value - txtTotTax.Value) : txtDueAmountLoc.Value) - doubleInput_NetWorkLoc.Value;
                }
            }
            catch
            {
                doubleInput_NetWorkLoc.Value = 0.0;
                doubleInput_NetWorkLoc.Leave -= doubleInput_NetWorkLoc_Leave;
            }
        }
        private void txtPaymentLoc_Leave(object sender, EventArgs e)
        {
            try
            {
                if (!(txtPaymentLoc.Value > 0.0))
                {
                    return;
                }
                if (doubleInput_CreditLoc.Value > 0.0 || doubleInput_NetWorkLoc.Value > 0.0)
                {
                    if (!(doubleInput_CreditLoc.Value > 0.0) || !(doubleInput_NetWorkLoc.Value > 0.0))
                    {
                        if (doubleInput_CreditLoc.Value > 0.0)
                        {
                            doubleInput_CreditLoc.Value = (checkBox_CostGaidTax.Checked ? (txtDueAmountLoc.Value - txtTotTax.Value) : txtDueAmountLoc.Value) - txtPaymentLoc.Value;
                        }
                        else
                        {
                            doubleInput_NetWorkLoc.Value = (checkBox_CostGaidTax.Checked ? (txtDueAmountLoc.Value - txtTotTax.Value) : txtDueAmountLoc.Value) - txtPaymentLoc.Value;
                        }
                    }
                }
                else
                {
                    doubleInput_NetWorkLoc.Value = (checkBox_CostGaidTax.Checked ? (txtDueAmountLoc.Value - txtTotTax.Value) : txtDueAmountLoc.Value) - txtPaymentLoc.Value;
                }
            }
            catch
            {
                txtPaymentLoc.Value = 0.0;
                txtPaymentLoc.Leave -= txtPaymentLoc_Leave;
            }
        }
        private void doubleInput_CreditLoc_Leave(object sender, EventArgs e)
        {
            try
            {
                if (!(doubleInput_CreditLoc.Value > 0.0))
                {
                    return;
                }
                if (txtPaymentLoc.Value > 0.0 || doubleInput_NetWorkLoc.Value > 0.0)
                {
                    if (!(txtPaymentLoc.Value > 0.0) || !(doubleInput_NetWorkLoc.Value > 0.0))
                    {
                        if (txtPaymentLoc.Value > 0.0)
                        {
                            txtPaymentLoc.Value = (checkBox_CostGaidTax.Checked ? (txtDueAmountLoc.Value - txtTotTax.Value) : txtDueAmountLoc.Value) - doubleInput_CreditLoc.Value;
                        }
                        else
                        {
                            doubleInput_NetWorkLoc.Value = (checkBox_CostGaidTax.Checked ? (txtDueAmountLoc.Value - txtTotTax.Value) : txtDueAmountLoc.Value) - doubleInput_CreditLoc.Value;
                        }
                    }
                }
                else
                {
                    txtPaymentLoc.Value = (checkBox_CostGaidTax.Checked ? (txtDueAmountLoc.Value - txtTotTax.Value) : txtDueAmountLoc.Value) - doubleInput_CreditLoc.Value;
                }
            }
            catch
            {
                doubleInput_CreditLoc.Value = 0.0;
                doubleInput_CreditLoc.Leave -= doubleInput_CreditLoc_Leave;
            }
        }
        private void switchButton_Lock_Click(object sender, EventArgs e)
        {
            if (!switchButton_Lock.IsReadOnly)
            {
                try
                {
                    if (data_this.AdminLock.Value && switchButton_Lock.Value && !CanEdit)
                    {
                        CanEdit = true;
                    }
                    Button_Edit_Click(sender, e);
                }
                catch { switchButton_Lock.Value = false; }
            }
        }
        private void switchButton_Lock_ValueChanged(object sender, EventArgs e)
        {
            Permmission = dbc.Get_PermissionID(VarGeneral.UserID);
        }
        private void button_Repetition_Click(object sender, EventArgs e)
        {
            try
            {
                string c = textBox_ID.Text;
                if (!string.IsNullOrEmpty(c))
                {
                    Button_Add_Click(sender, e);
                    RepetitionSts = true;
                    SetData(db.StockInvHead(VarGeneral.InvTyp, c));
                    _GdHead = new T_GDHEAD();
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("button_Repetition_Click:", error, enable: true);
                MessageBox.Show(error.Message);
            }
            RepetitionSts = false;
            ReverseSts = false;
        }
        private void textBox_ID_ButtonCustomClick(object sender, EventArgs e)
        {
            if (State != 0 || string.IsNullOrEmpty(textBox_ID.Text) || !CanEdit || switchButton_Lock.Value)
            {
                return;
            }
            string vNewNo = InputDialog.mostrar((LangArEn == 0) ? "أدخل رقم الفاتورة الجديد : " : "Insert New Invoice No : ", (LangArEn == 0) ? "تعديل رقم فاتورة" : "Invoice No Edite");
            if (string.IsNullOrEmpty(vNewNo))
            {
                return;
            }
            int ChkNo = 0;
            try
            {
                ChkNo = int.Parse(vNewNo);
            }
            catch
            {
                ChkNo = 0;
            }
            if (ChkNo <= 0)
            {
                MessageBox.Show((LangArEn == 0) ? " يجب استخدام الأرقام فقط لتعيين رقم الفاتورة" : "Numbers must be used only to set the invoice number", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                textBox_ID.Focus();
                return;
            }
            try
            {
                List<T_INVHED> q = (from t in db.T_INVHEDs
                                    where t.InvNo == vNewNo
                                    where t.InvTyp == (int?)VarGeneral.InvTyp
                                    where t.IfDel == (int?)0
                                    select t).ToList();
                if (q.Count > 0)
                {
                    MessageBox.Show((LangArEn == 0) ? " رقم الفاتورة مكرر يرجى تغييره" : "Employee No It's a existing", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    textBox_ID.Focus();
                    return;
                }
                textBox_ID.TextChanged -= textBox_ID_TextChanged;
                _StopMove = false;
                textBox_ID.Text = vNewNo;
                State = FormState.Edit;
                ButReturn.Tag = 0;
                Button_Save.Enabled = true;
                Button_Save_Click(sender, e);
                textBox_ID.TextChanged += textBox_ID_TextChanged;
            }
            catch (Exception error)
            {
                textBox_ID.TextChanged += textBox_ID_TextChanged;
                VarGeneral.DebLog.writeLog("textBox_ID_ButtonCustomClick:", error, enable: true);
                MessageBox.Show((LangArEn == 0) ? "حصل خطأ ما .. لم يتم عملية التعديل بنجاح" : "Error .. Editing is not Done", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                MessageBox.Show(error.Message);
            }
            _StopMove = true;
        }
        private void txtCustNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }
        private void txtCustNo_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtCustNo.ReadOnly)
                {
                    return;
                }
                List<T_AccDef> LAccDef = new List<T_AccDef>();
                LAccDef = (from t in db.T_AccDefs
                           where t.Lev == (int?)4 && t.AccCat == (int?)4 && t.Sts == (int?)0
                           where !t.StopedState.Value
                           where t.AccDef_No == txtCustNo.Text
                           orderby t.AccDef_No
                           select t).ToList();
                if (LAccDef.Count > 0)
                {
                    txtCustNo.Text = db.StockAccDefWithOutBalance(txtCustNo.Text).AccDef_No;
                    if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                    {
                        txtCustName.Text = db.StockAccDefWithOutBalance(txtCustNo.Text).Arb_Des;
                    }
                    else
                    {
                        txtCustName.Text = db.StockAccDefWithOutBalance(txtCustNo.Text).Eng_Des;
                    }
                    txtAddress.Text = db.StockAccDefWithOutBalance(txtCustNo.Text).Adders ?? string.Empty;
                    txtTele.Text = db.StockAccDefWithOutBalance(txtCustNo.Text).Telphone1 ?? string.Empty;
                    try
                    {
                        if (db.StockAccDefWithOutBalance(txtCustNo.Text).Mnd.HasValue)
                        {
                            int? mnd_Typ = db.StockAccDefWithOutBalance(txtCustNo.Text).T_Mndob.Mnd_Typ;
                            if (mnd_Typ.Value == 0 && mnd_Typ.HasValue)
                            {
                                CmbInvSide.SelectedIndex = 0;
                                CmbLegate.SelectedValue = db.StockAccDefWithOutBalance(txtCustNo.Text).Mnd;
                            }
                            else
                            {
                                CmbInvSide.SelectedIndex = 1;
                                CmbLegate.SelectedValue = db.StockAccDefWithOutBalance(txtCustNo.Text).Mnd;
                            }
                        }
                    }
                    catch
                    {
                        CmbLegate.SelectedIndex = 0;
                    }
                    try
                    {
                        txtCustRep.Value = db.StockAccDef(txtCustNo.Text).Balance.Value;
                    }
                    catch
                    {
                        txtCustRep.Value = 0.0;
                    }
                    txtDebit2.Text = txtCustName.Text;
                    txtDebit2.Tag = txtCustNo.Text;
                }
                else
                {
                    txtCustNo.Text = string.Empty;
                    txtCustRep.Value = 0.0;
                    txtDebit2.Text = string.Empty;
                    txtDebit2.Tag = string.Empty;
                }
                txtCustNo_TextChanged(sender, e);
            }
            catch
            {
                txtCustNo.Text = string.Empty;
                txtCustRep.Value = 0.0;
                txtDebit2.Text = string.Empty;
                txtDebit2.Tag = string.Empty;
                txtCustNo_TextChanged(sender, e);
            }
        }
        private void switchButton_Tax_ValueChanged(object sender, EventArgs e)
        {
            GetInvTot();
        }
        private void checkBox_CostGaidTax_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_CostGaidTax.Checked)
            {
                txtDebit5.Enabled = true;
                txtCredit5.Enabled = true;
                button_CustD5.Enabled = true;
                button_CustC5.Enabled = true;
                if (VarGeneral.SSSTyp != 0)
                {
                    if (checkBox_Chash.Checked)
                    {
                        txtCredit5.Tag = ((_InvSetting.TaxCredit.Trim() != "***") ? _InvSetting.TaxCredit.Trim() : string.Empty);
                        if (!string.IsNullOrEmpty(txtCredit5.Tag.ToString()))
                        {
                            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                            {
                                txtCredit5.Text = db.SelectAccRootByCode(txtCredit5.Tag.ToString()).Arb_Des;
                            }
                            else
                            {
                                txtCredit5.Text = db.SelectAccRootByCode(txtCredit5.Tag.ToString()).Eng_Des;
                            }
                        }
                        else
                        {
                            txtCredit5.Text = string.Empty;
                        }
                        txtDebit5.Tag = ((_InvSetting.TaxDebit.Trim() != "***") ? _InvSetting.TaxDebit.Trim() : string.Empty);
                        if (!string.IsNullOrEmpty(txtDebit5.Tag.ToString()))
                        {
                            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                            {
                                txtDebit5.Text = db.SelectAccRootByCode(txtDebit5.Tag.ToString()).Arb_Des;
                            }
                            else
                            {
                                txtDebit5.Text = db.SelectAccRootByCode(txtDebit5.Tag.ToString()).Eng_Des;
                            }
                        }
                        else
                        {
                            txtDebit5.Text = string.Empty;
                        }
                        if (!string.IsNullOrEmpty(txtCustNo.Text))
                        {
                            if (_InvSetting.TaxCredit.Trim() == "***")
                            {
                                txtCredit5.Tag = txtCustNo.Text;
                                txtCredit5.Text = txtCustName.Text;
                            }
                            if (_InvSetting.TaxDebit.Trim() == "***")
                            {
                                txtDebit5.Tag = txtCustNo.Text;
                                txtDebit5.Text = txtCustName.Text;
                            }
                        }
                    }
                    else
                    {
                        txtCredit5.Tag = ((_InvSetting.TaxCreditCredit.Trim() != "***") ? _InvSetting.TaxCreditCredit.Trim() : string.Empty);
                        if (!string.IsNullOrEmpty(txtCredit5.Tag.ToString()))
                        {
                            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                            {
                                txtCredit5.Text = db.SelectAccRootByCode(txtCredit5.Tag.ToString()).Arb_Des;
                            }
                            else
                            {
                                txtCredit5.Text = db.SelectAccRootByCode(txtCredit5.Tag.ToString()).Eng_Des;
                            }
                        }
                        else
                        {
                            txtCredit5.Text = string.Empty;
                        }
                        txtDebit5.Tag = ((_InvSetting.TaxDebitCredit.Trim() != "***") ? _InvSetting.TaxDebitCredit.Trim() : string.Empty);
                        if (!string.IsNullOrEmpty(txtDebit5.Tag.ToString()))
                        {
                            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                            {
                                txtDebit5.Text = db.SelectAccRootByCode(txtDebit5.Tag.ToString()).Arb_Des;
                            }
                            else
                            {
                                txtDebit5.Text = db.SelectAccRootByCode(txtDebit5.Tag.ToString()).Eng_Des;
                            }
                        }
                        else
                        {
                            txtDebit5.Text = string.Empty;
                        }
                        if (!string.IsNullOrEmpty(txtCustNo.Text))
                        {
                            if (_InvSetting.TaxCreditCredit.Trim() == "***")
                            {
                                txtCredit5.Tag = txtCustNo.Text;
                                txtCredit5.Text = txtCustName.Text;
                            }
                            if (_InvSetting.TaxDebitCredit.Trim() == "***")
                            {
                                txtDebit5.Tag = txtCustNo.Text;
                                txtDebit5.Text = txtCustName.Text;
                            }
                        }
                    }
                }
            }
            else
            {
                txtDebit5.Enabled = false;
                txtCredit5.Enabled = false;
                button_CustD5.Enabled = false;
                button_CustC5.Enabled = false;
            }
            txtDueAmountLoc_ValueChanged(sender, e);
        }
        private void checkBox_GaidDis_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_GaidDis.Checked)
            {
                txtDebit6.Enabled = true;
                txtCredit6.Enabled = true;
                if (VarGeneral.SSSTyp == 0)
                {
                    return;
                }
                if (string.IsNullOrEmpty(txtCredit6.Text))
                {
                    txtCredit6.Tag = ((_InvSetting.DisCredit.Trim() != "***") ? _InvSetting.DisCredit.Trim() : string.Empty);
                    if (!string.IsNullOrEmpty(txtCredit6.Tag.ToString()))
                    {
                        if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                        {
                            txtCredit6.Text = db.SelectAccRootByCode(txtCredit6.Tag.ToString()).Arb_Des;
                        }
                        else
                        {
                            txtCredit6.Text = db.SelectAccRootByCode(txtCredit6.Tag.ToString()).Eng_Des;
                        }
                    }
                    else
                    {
                        txtCredit6.Text = string.Empty;
                    }
                }
                if (!string.IsNullOrEmpty(txtDebit6.Text))
                {
                    return;
                }
                txtDebit6.Tag = ((_InvSetting.DisDebit.Trim() != "***") ? _InvSetting.DisDebit.Trim() : string.Empty);
                if (!string.IsNullOrEmpty(txtDebit6.Tag.ToString()))
                {
                    if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                    {
                        txtDebit6.Text = db.SelectAccRootByCode(txtDebit6.Tag.ToString()).Arb_Des;
                    }
                    else
                    {
                        txtDebit6.Text = db.SelectAccRootByCode(txtDebit6.Tag.ToString()).Eng_Des;
                    }
                }
                else
                {
                    txtDebit6.Text = string.Empty;
                }
            }
            else
            {
                txtDebit6.Enabled = false;
                txtCredit6.Enabled = false;
            }
        }
        private void switchButton_Dis_ValueChanged(object sender, EventArgs e)
        {
            GetInvTot();
        }
        private void switchButton_TaxLines_ValueChanged(object sender, EventArgs e)
        {
            if (State == FormState.Saved)
            {
                return;
            }
            for (int iiCnt = 1; iiCnt < FlxInv.Rows.Count; iiCnt++)
            {
                if (!(string.Concat(FlxInv.GetData(iiCnt, 1)) != string.Empty))
                {
                    continue;
                }
                double ItmDis = 0.0;
                double ItmAddTax = 0.0;
                ItmDis = double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 8)))) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 9)))) / 100.0);
                try
                {
                    if ((File.Exists(Application.StartupPath + "\\Script\\SecriptColDisSalesReturn.dll") || (VarGeneral.gUserName == "runsetting" && File.Exists(Application.StartupPath + "\\Script\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\SecriptColDisSalesReturn.dll"))) && double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 36)))) > 0.0)
                    {
                        ItmDis += double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 8)))) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 36)))) / 100.0);
                    }
                }
                catch
                {
                }
                try
                {
                    if (File.Exists(Application.StartupPath + "\\Script\\SecriptColDisSalesReturnValue.dll") || (VarGeneral.gUserName == "runsetting" && File.Exists(Application.StartupPath + "\\Script\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\SecriptColDisSalesReturnValue.dll")))
                    {
                        ItmDis += double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 36))));
                    }
                }
                catch
                {
                }
                ItmAddTax = Math.Round(double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 8)))) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 31)))) / 100.0), VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2);
                if (!switchButton_TaxLines.Value || switchButton_TaxByTotal.Value)
                {
                    ItmAddTax = 0.0;
                }
                FlxInv.SetData(iiCnt, 38, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 8)))) - ItmDis + ItmAddTax);
                if (switchButton_TaxByTotal.Value && switchButton_TaxLines.Value && double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 38)))) > 0.0)
                {
                    ItmAddTax = Math.Round((double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 8)))) - ItmDis) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 31)))) / 100.0), VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2);
                    FlxInv.SetData(iiCnt, 38, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 38)))) + ItmAddTax);
                }
            }
            GetInvTot();
            txtDueAmountLoc_ValueChanged(sender, e);
        }
        private void button_GoodsDisbursedInv_Click(object sender, EventArgs e)
        {
            if (CmbLegate.SelectedIndex <= 0 && CmbInvSide.SelectedIndex == 1)
            {
                MessageBox.Show((LangArEn == 0) ? "يجب تحديد المندوب الخارجي لهذه البضاعة قبل عرض الأصناف" : "You must specify the external representative of these goods ", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                CmbLegate.Focus();
            }
            else if (CmbInvSide.SelectedIndex > 1 && txtCustNo.Text == string.Empty && VarGeneral.SSSLev != "M")
            {
                MessageBox.Show((LangArEn == 0) ? "يجب تحديد العميل / المورد لهذه البضاعة قبل عرض الأصناف" : "You must specify the Customer/Supplier of these goods ", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                CmbLegate.Focus();
            }
            else
            {
                if (CmbInvSide.SelectedIndex <= 0 || State != FormState.New)
                {
                    return;
                }
                columns_Names_visible2.Clear();
                columns_Names_visible2.Add("InvNo", new ColumnDictinary("رقم الفاتورة", "Invoice No", ifDefault: true, string.Empty));
                columns_Names_visible2.Add("CusVenNm", new ColumnDictinary("إسم العميل", "Customer Name", ifDefault: true, string.Empty));
                columns_Names_visible2.Add("SalsManNo", new ColumnDictinary("رقم البائع", "SalsMan No", ifDefault: false, string.Empty));
                columns_Names_visible2.Add("HDat", new ColumnDictinary("التاريخ الهجري", "Date Hijri", ifDefault: true, string.Empty));
                columns_Names_visible2.Add("GDat", new ColumnDictinary("التاريخ الميلادي", "Date Gregorian", ifDefault: true, string.Empty));
                columns_Names_visible2.Add("InvTot", new ColumnDictinary("إجمالي الفاتورة", "Invoice Total", ifDefault: false, string.Empty));
                columns_Names_visible2.Add("InvNet", new ColumnDictinary("صافي الفاتورة", "Invoice Net", ifDefault: true, string.Empty));
                columns_Names_visible2.Add("InvQty", new ColumnDictinary("إجمالي الكمية", "Quantity Total", ifDefault: true, string.Empty));
                columns_Names_visible2.Add("InvDisPrs", new ColumnDictinary("الخصم نسبة", "Discount Percentage", ifDefault: false, string.Empty));
                columns_Names_visible2.Add("InvDisVal", new ColumnDictinary("الخصم قيمة", "Discount value", ifDefault: true, string.Empty));
                columns_Names_visible2.Add("Remark", new ColumnDictinary("الملاحظات", "Note", ifDefault: true, string.Empty));
                FrmSearch frm = new FrmSearch();
                frm.Tag = LangArEn;
                ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible2;
                foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
                {
                    frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
                }
                VarGeneral.SFrmTyp = "T_InvSalReturnExchag";
                VarGeneral.InvTypRt = 1;
                VarGeneral.itmDes = ((CmbInvSide.SelectedIndex == 1) ? (" and MndNo = " + CmbLegate.SelectedValue.ToString()) : (" and CusVenNo = '" + txtCustNo.Text + "' "));
                frm.TopMost = true;
                frm.ShowDialog();
                if (!(frm.SerachNo != string.Empty))
                {
                    return;
                }
                T_INVHED newData = dbReturn.StockInvHead(1, frm.Serach_No);
                if (newData != null || !string.IsNullOrEmpty(newData.InvNo))
                {
                    CmbInvSide.SelectedIndexChanged -= CmbInvSide_SelectedIndexChanged;
                    State = FormState.Saved;
                    Clear();
                    DataThisRe = newData;
                    CmbInvSide.SelectedIndexChanged += CmbInvSide_SelectedIndexChanged;
                    if (VarGeneral._IsPOS)
                    {
                        AutoGaidAcc_POS();
                    }
                    else
                    {
                        AutoGaidAcc();
                    }
                    txtDebit5.Text = string.Empty;
                    txtDebit5.Tag = string.Empty;
                    txtCredit5.Text = string.Empty;
                    txtCredit5.Tag = string.Empty;
                    checkBox_CostGaidTax_CheckedChanged(sender, e);
                    txtDebit6.Text = string.Empty;
                    txtDebit6.Tag = string.Empty;
                    txtCredit6.Text = string.Empty;
                    txtCredit6.Tag = string.Empty;
                    checkBox_GaidDis_CheckedChanged(sender, e);
                }
                dbInstanceReturn = null;
            }
        }
        private void switchButton_TaxByNet_ValueChanged(object sender, EventArgs e)
        {
            if (switchButton_TaxByNet.Value)
            {
                textBoxItem_TaxByNetValue.Visible = true;
                labelItem_TaxByNetPer.Visible = true;
                switchButton_TaxByTotal.Visible = false;
            }
            else
            {
                textBoxItem_TaxByNetValue.Visible = false;
                labelItem_TaxByNetPer.Visible = false;
                switchButton_TaxByTotal.Visible = true;
            }
            txtDueAmountLoc_ValueChanged(sender, e);
        }
        private void textBoxItem_TaxByNetValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if ((!char.IsNumber(e.KeyChar) & (e.KeyChar != '\b')) && e.KeyChar != '.')
                {
                    e.Handled = true;
                }
            }
            catch
            {
                e.Handled = true;
            }
        }
        private void textBoxItem_TaxByNetValue_LostFocus(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(textBoxItem_TaxByNetValue.Text))
                {
                    textBoxItem_TaxByNetValue.Text = "0";
                }
            }
            catch
            {
                textBoxItem_TaxByNetValue.Text = "0";
            }
            GetInvTot();
        }
        private void txtRemark_ButtonCustom2Click(object sender, EventArgs e)
        {
            try
            {
                FrmInvDetNoteSrch frm = new FrmInvDetNoteSrch();
                frm.Tag = LangArEn;
                try
                {
                    frm.textbox_Detailes.Text = txtRemark.Text;
                }
                catch
                {
                    frm.textbox_Detailes.Text = string.Empty;
                }
                frm.TopMost = true;
                frm.ShowDialog();
                if (frm.SerachNo != string.Empty)
                {
                    txtRemark.Text = frm.SerachNo;
                }
                else
                {
                    txtRemark.Text = string.Empty;
                }
            }
            catch
            {
            }
        }
        private void switchButton_PointActiv_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (State == FormState.Saved)
                {
                    return;
                }
                if (string.IsNullOrEmpty(txtCustNo.Text))
                {
                    switchButton_PointActiv.Value = false;
                }
            }
            catch
            {
                switchButton_PointActiv.Value = false;
                switchButton_PointActiv.Refresh();
            }
            if (!switchButton_PointActiv.Value)
            {
                txtDiscoundPoints.Value = 0.0;
                txtDiscoundPoints_ButtonClearClick(null, null);
            }
        }
        private void button_SrchCustPoints_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtCustNo.Text) && switchButton_PointActiv.Value)
                {
                    Button_Edit_Click(sender, e);
                    FrmCustomerPointData frm = new FrmCustomerPointData(Rep: false, (State == FormState.Edit) ? true : false, (State == FormState.Edit) ? data_this.InvHed_ID : 0, txtDiscoundPoints.Value);
                    frm.Tag = LangArEn;
                    frm.txtCustNo.Text = txtCustNo.Text;
                    frm.txtCustName.Text = txtCustName.Text;
                    frm.txtDueAmountLoc.Value = txtDueAmountLoc.Value + txtDiscoundPoints.Value;
                    frm.txtDiscoundPointsValue.Value = txtDiscoundPoints.Value;
                    frm.TopMost = true;
                    frm.ShowDialog();
                    if (frm.IsDone)
                    {
                        txtDiscoundPoints.Value = frm.txtDiscoundPointsValue.Value;
                        txtPointCount.Value = frm.txtDiscoundPoints.Value;
                    }
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("button_SrchCustPoints_Click:", error, enable: true);
                txtDiscoundPoints.Value = 0.0;
                txtPointCount.Value = 0.0;
                MessageBox.Show(error.Message);
            }
        }
        private void txtDiscoundPoints_ButtonClearClick(object sender, CancelEventArgs e)
        {
            try
            {
                Button_Edit_Click(sender, e);
                txtDiscoundPoints_ValueChanged(sender, e);
                txtPointCount.Value = 0.0;
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("txtDiscoundPoints_ButtonClearClick:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void txtDiscoundPoints_ValueChanged(object sender, EventArgs e)
        {
            if (State != 0)
            {
                txtDiscoundPointsLoc.Value = txtDiscoundPoints.Value * RateValue;
                GetInvTot();
            }
        }
        private void Button_PrintTableMulti_Click(object sender, EventArgs e)
        {
            if (State != 0 || string.IsNullOrEmpty(textBox_ID.Text))
            {
                return;
            }
            try
            {
                for (int i = 0; i < pkeys.Count; i++)
                {
                    try
                    {
                        GridRow crow = DGV_Main.PrimaryGrid.Rows[i] as GridRow;
                        if (crow.Checked)
                        {
                            ifMultiPrint = true;
                            data_this = new T_INVHED();
                            data_this = db.StockInvHead(VarGeneral.InvTyp, DGV_Main.PrimaryGrid.GetCell(crow.Index, 0).Value.ToString());
                            buttonItem_Print_Click(sender, e);
                            ifMultiPrint = false;
                        }
                    }
                    catch
                    {
                    }
                }
            }
            catch
            {
                ifMultiPrint = false;
            }
            textBox_ID_TextChanged(sender, e);
        }
        private void button_SrchInvNoBarcod_Click(object sender, EventArgs e)
        {
            string vNewNo = InputDialog.mostrar((LangArEn == 0) ? "أدخل رقم الفاتورة او قم بقرائته هنا : " : "Insert Invoice No : ", (LangArEn == 0) ? "قراءة رقم الفاتورة" : "Invoice No Reading");
            if (string.IsNullOrEmpty(vNewNo))
            {
                return;
            }
            int ChkNo = 0;
            try
            {
                ChkNo = int.Parse(vNewNo);
            }
            catch
            {
                ChkNo = 0;
            }
            if (ChkNo <= 0)
            {
                MessageBox.Show((LangArEn == 0) ? " يجب ان يكون رقم الفاتورة رقمي فقط" : "Numbers must be used only to Reading the Invoice number", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                textBox_ID.Focus();
                return;
            }
            try
            {
                List<T_INVHED> q = (from t in db.T_INVHEDs
                                    where t.InvNo == vNewNo
                                    where t.InvTyp == (int?)VarGeneral.InvTyp
                                    where t.IfDel == (int?)0
                                    select t).ToList();
                if (q.Count <= 0)
                {
                    MessageBox.Show((LangArEn == 0) ? " رقم الفاتورة غير موجود في النظام" : "Invoice No It's a existing", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    textBox_ID.Focus();
                }
                else
                {
                    textBox_ID.Text = vNewNo;
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("button_SrchInvNoBarcod_Click:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void switchButton_Lock_VisibleChanged(object sender, EventArgs e)
        {
            button_SrchInvNoBarcod.Visible = switchButton_Lock.Visible;
        }
        private void label4_Click(object sender, EventArgs e)
        {
        }
        private void label10_Click(object sender, EventArgs e)
        {
        }
        private void label13_Click(object sender, EventArgs e)
        {
        }
        private void label15_Click(object sender, EventArgs e)
        {
        }
        private void CmbCostC_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        private void txtAddress_TextChanged(object sender, EventArgs e)
        {
        }
        private void text_Mobile_TextChanged(object sender, EventArgs e)
        {
        }
        private void ribbonBar1_ItemClick(object sender, EventArgs e)
        {
        }
        private void printersettings_Click(object sender, EventArgs e)
        {
            DroBoxSync.Frm_PrinterShow f = new DroBoxSync.Frm_PrinterShow(VarGeneral.InvTyp);
            f.TopMost = true;
            f.ShowDialog();
            _InvSetting.InvpRINTERInfo.nTyp = DroBoxSync.Frm_PrinterShow.PLSetting;
        }
        private void FlxInv_AfterDeleteRow(object sender, RowColEventArgs e)
        {
        }
        private void FlxInv_CellChecked(object sender, RowColEventArgs e)
        {
        }
        private void FlxInv_CellChanged(object sender, RowColEventArgs e)
        {
            try
            {
                if (e.Col == 8)
                {
                    pricel = double.Parse(FlxInv.GetData(e.Row, e.Col).ToString()); ;
                }
                if (e.Col == 31)
                    ta = double.Parse(FlxInv.GetData(e.Row, e.Col).ToString()); ;
                if (edit)
                {
                    if (e.Col == 8)
                    {
                        pricel = double.Parse(FlxInv.GetData(e.Row, e.Col).ToString()); without = pricel; edit = false; newprice = true;
                    }
                    if (e.Col == 31)
                    {
                        ta = double.Parse(FlxInv.GetData(e.Row, e.Col).ToString()); t1 = ta;
                    }
                    else
                        t1 = 0;
                    if (e.Col == 38)
                    {
                        tot = double.Parse(FlxInv.GetData(e.Row, e.Col).ToString());
                    }
                    else
                        tot = 0;
                }
                try
                {
                    if (e.Row > 0 && (e.Col == 38 || e.Col == 8 || e.Col == 7 || e.Col == 31))
                        FlxInv.SetData(e.Row, e.Col, Math.Round(double.Parse(FlxInv.GetData(e.Row, e.Col).ToString()), VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2));
                }
                catch
                {
                }
            }
            catch { }
        }
        public double fs = 0;
        private void FlxInv_LeaveEdit(object sender, RowColEventArgs e)
        {
            kk = 0;
            if (edit)
            {
                if (e.Col == 8 || e.Col == 38)
                {
                    if (beforeeditprice == 1)
                    {
                        fs = double.Parse(FlxInv.GetData(e.Row, 8).ToString()); without = fs;
                        beforeeditprice = 0;
                    }
                    else
                        if (beforeeditprice == 2)
                    {
                        enteredtotal = double.Parse(FlxInv.GetData(e.Row, 38).ToString());
                        beforeeditprice = 0;
                    }
                }
            }
        }
        private void saveDraft()
        {
            GetData();
            data_this.CInvType = VarGeneral.InvTyp;
            data_this.InvTyp = VarGeneral.DraftBillId;
            if (State == FormState.New)
            {
                try
                {
                    GetInvSetting();
                    textBox_ID.TextChanged -= textBox_ID_TextChanged;
                    T_INVHED newData = db.StockInvHead(VarGeneral.InvTyp, data_this.InvNo);
                    if (!string.IsNullOrEmpty(newData.InvNo) || newData.InvHed_ID > 0)
                    {
                        string max = string.Empty;
                        dbInstance = null;
                        max = db.MaxInvheadNo.ToString();
                        MessageBox.Show("الرمز مستخدم من قبل.\n سيتم الحفظ برقم جديد [" + max + "]", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        textBox_ID.Text = max ?? string.Empty;
                        data_this.InvNo = max ?? string.Empty;
                    }
                    textBox_ID.TextChanged += textBox_ID_TextChanged;
                    data_this.IfRet = 0;
                    data_this.DATE_CREATED = DateTime.Now;
                    data_this.SalsManNo = VarGeneral.UserNumber;
                    data_this.SalsManNam = string.Empty;
                    data_this.DeleteTime = string.Empty;
                    IDatabase dbHead = Database.GetDatabase(VarGeneral.BranchCS);
                    dbHead.ClearParameters();
                    dbHead.AddOutParameter("InvHed_ID", DbType.Int32);
                    dbHead.AddParameter("InvId", DbType.Double, data_this.InvId);
                    dbHead.AddParameter("InvNo", DbType.String, data_this.InvNo);
                    dbHead.AddParameter("InvTyp", DbType.Int32, data_this.InvTyp);
                    dbHead.AddParameter("InvCashPay", DbType.Int32, data_this.InvCashPay);
                    dbHead.AddParameter("CusVenNo", DbType.String, data_this.CusVenNo);
                    dbHead.AddParameter("CusVenNm", DbType.String, data_this.CusVenNm);
                    dbHead.AddParameter("CusVenAdd", DbType.String, data_this.CusVenAdd);
                    dbHead.AddParameter("CusVenTel", DbType.String, data_this.CusVenTel);
                    dbHead.AddParameter("Remark", DbType.String, data_this.Remark);
                    dbHead.AddParameter("HDat", DbType.String, data_this.HDat);
                    dbHead.AddParameter("GDat", DbType.String, data_this.GDat);
                    dbHead.AddParameter("MndNo", DbType.Int32, data_this.MndNo);
                    dbHead.AddParameter("SalsManNo", DbType.String, data_this.SalsManNo);
                    dbHead.AddParameter("SalsManNam", DbType.String, data_this.SalsManNam);
                    dbHead.AddParameter("InvTot", DbType.Double, data_this.InvTot);
                    dbHead.AddParameter("InvTotLocCur", DbType.Double, data_this.InvTotLocCur);
                    dbHead.AddParameter("InvDisPrs", DbType.Double, data_this.InvDisPrs);
                    dbHead.AddParameter("InvDisVal", DbType.Double, data_this.InvDisVal);
                    dbHead.AddParameter("CusVenMob", DbType.String, data_this.CusVenMob);
                    dbHead.AddParameter("PriceIncludeTax", DbType.Boolean, data_this.PriceIncludTax);
                    dbHead.AddParameter("InvDisValLocCur", DbType.Double, data_this.InvDisValLocCur);
                    dbHead.AddParameter("InvNet", DbType.Double, data_this.InvNet);
                    dbHead.AddParameter("InvNetLocCur", DbType.Double, data_this.InvNetLocCur);
                    dbHead.AddParameter("CashPay", DbType.Double, data_this.CashPay);
                    dbHead.AddParameter("CashPayLocCur", DbType.Double, data_this.CashPayLocCur);
                    dbHead.AddParameter("IfRet", DbType.Int32, data_this.IfRet);
                    dbHead.AddParameter("GadeNo", DbType.Double, data_this.GadeNo);
                    dbHead.AddParameter("GadeId", DbType.Double, data_this.GadeId);
                    dbHead.AddParameter("IfDel", DbType.Int32, data_this.IfDel);
                    dbHead.AddParameter("RetNo", DbType.String, data_this.RetNo);
                    dbHead.AddParameter("RetId", DbType.Double, data_this.RetId);
                    dbHead.AddParameter("InvCstNo", DbType.Int32, data_this.InvCstNo);
                    dbHead.AddParameter("InvCashPayNm", DbType.String, data_this.InvCashPayNm);
                    dbHead.AddParameter("RefNo", DbType.String, data_this.RefNo);
                    dbHead.AddParameter("InvCost", DbType.Int32, data_this.InvCost);
                    dbHead.AddParameter("EstDat", DbType.String, data_this.EstDat);
                    dbHead.AddParameter("CustPri", DbType.Int32, data_this.CustPri);
                    dbHead.AddParameter("ArbTaf", DbType.String, data_this.ArbTaf);
                    dbHead.AddParameter("CurTyp", DbType.Int32, data_this.CurTyp);
                    dbHead.AddParameter("InvCash", DbType.String, data_this.InvCash);
                    dbHead.AddParameter("ToStore", DbType.String, data_this.ToStore);
                    dbHead.AddParameter("ToStoreNm", DbType.String, data_this.ToStoreNm);
                    dbHead.AddParameter("InvQty", DbType.Double, data_this.InvQty);
                    dbHead.AddParameter("EngTaf", DbType.String, data_this.EngTaf);
                    dbHead.AddParameter("IfTrans", DbType.Int32, data_this.IfTrans);
                    dbHead.AddParameter("CustRep", DbType.Double, data_this.CustRep);
                    dbHead.AddParameter("CustNet", DbType.Double, data_this.CustNet);
                    dbHead.AddParameter("InvWight_T", DbType.Double, data_this.InvWight_T);
                    dbHead.AddParameter("IfPrint", DbType.Int32, data_this.IfPrint);
                    dbHead.AddParameter("LTim", DbType.String, data_this.LTim);
                    dbHead.AddParameter("CREATED_BY", DbType.String, data_this.CREATED_BY);
                    dbHead.AddParameter("DATE_CREATED", DbType.DateTime, data_this.DATE_CREATED);
                    dbHead.AddParameter("MODIFIED_BY", DbType.String, data_this.MODIFIED_BY);
                    dbHead.AddParameter("DATE_MODIFIED", DbType.DateTime, data_this.DATE_MODIFIED);
                    dbHead.AddParameter("CreditPay", DbType.Double, data_this.CreditPay);
                    dbHead.AddParameter("CreditPayLocCur", DbType.Double, data_this.CreditPayLocCur);
                    dbHead.AddParameter("NetworkPay", DbType.Double, data_this.NetworkPay);
                    dbHead.AddParameter("NetworkPayLocCur", DbType.Double, data_this.NetworkPayLocCur);
                    dbHead.AddParameter("CommMnd_Inv", DbType.Double, data_this.CommMnd_Inv);
                    dbHead.AddParameter("MndExtrnal", DbType.Boolean, data_this.MndExtrnal);
                    dbHead.AddParameter("CompanyID", DbType.Int32, data_this.CompanyID);
                    dbHead.AddParameter("InvAddCost", DbType.Double, data_this.InvAddCost);
                    dbHead.AddParameter("InvAddCostLoc", DbType.Double, data_this.InvAddCostLoc);
                    dbHead.AddParameter("InvAddCostExtrnal", DbType.Double, data_this.InvAddCostExtrnal);
                    dbHead.AddParameter("InvAddCostExtrnalLoc", DbType.Double, data_this.InvAddCostExtrnalLoc);
                    dbHead.AddParameter("IsExtrnalGaid", DbType.Boolean, data_this.IsExtrnalGaid);
                    dbHead.AddParameter("ExtrnalCostGaidID", DbType.Double, data_this.ExtrnalCostGaidID);
                    dbHead.AddParameter("Puyaid", DbType.Double, data_this.Puyaid);
                    dbHead.AddParameter("Remming", DbType.Double, data_this.Remming);
                    dbHead.AddParameter("RoomNo", DbType.Int32, data_this.RoomNo);
                    dbHead.AddParameter("OrderTyp", DbType.Int32, data_this.OrderTyp);
                    dbHead.AddParameter("RoomSts", DbType.Boolean, data_this.RoomSts);
                    dbHead.AddParameter("chauffeurNo", DbType.Int32, data_this.chauffeurNo);
                    dbHead.AddParameter("RoomPerson", DbType.Int32, data_this.RoomPerson);
                    dbHead.AddParameter("ServiceValue", DbType.Double, data_this.ServiceValue);
                    dbHead.AddParameter("Sts", DbType.Boolean, data_this.Sts);
                    dbHead.AddParameter("PaymentOrderTyp", DbType.Int32, data_this.PaymentOrderTyp);
                    dbHead.AddParameter("AdminLock", DbType.Boolean, data_this.AdminLock);
                    dbHead.AddParameter("DeleteDate", DbType.String, data_this.DeleteDate);
                    dbHead.AddParameter("DeleteTime", DbType.String, data_this.DeleteTime);
                    dbHead.AddParameter("UserNew", DbType.String, data_this.UserNew);
                    dbHead.AddParameter("IfEnter", DbType.Int32, data_this.IfEnter);
                    dbHead.AddParameter("InvAddTax", DbType.Double, data_this.InvAddTax);
                    dbHead.AddParameter("InvAddTaxlLoc", DbType.Double, data_this.InvAddTaxlLoc);
                    dbHead.AddParameter("IsTaxGaid", DbType.Boolean, data_this.IsTaxGaid);
                    dbHead.AddParameter("TaxGaidID", DbType.Double, data_this.TaxGaidID);
                    dbHead.AddParameter("IsTaxUse", DbType.Boolean, data_this.IsTaxUse);
                    dbHead.AddParameter("InvValGaidDis", DbType.Double, data_this.InvValGaidDis);
                    dbHead.AddParameter("InvValGaidDislLoc", DbType.Double, data_this.InvValGaidDislLoc);
                    dbHead.AddParameter("IsDisGaid", DbType.Boolean, data_this.IsDisGaid);
                    dbHead.AddParameter("DisGaidID1", DbType.Double, data_this.DisGaidID1);
                    dbHead.AddParameter("IsDisUse1", DbType.Boolean, data_this.IsDisUse1);
                    dbHead.AddParameter("InvComm", DbType.Double, data_this.InvComm);
                    dbHead.AddParameter("InvCommLoc", DbType.Double, data_this.InvCommLoc);
                    dbHead.AddParameter("IsCommGaid", DbType.Boolean, data_this.IsCommGaid);
                    dbHead.AddParameter("CommGaidID", DbType.Double, data_this.CommGaidID);
                    dbHead.AddParameter("IsCommUse", DbType.Boolean, data_this.IsCommUse);
                    dbHead.AddParameter("IsTaxLines", DbType.Boolean, data_this.IsTaxLines);
                    dbHead.AddParameter("IsTaxByTotal", DbType.Boolean, data_this.IsTaxByTotal);
                    dbHead.AddParameter("IsTaxByNet", DbType.Boolean, data_this.IsTaxByNet);
                    dbHead.AddParameter("TaxByNetValue", DbType.Double, data_this.TaxByNetValue);
                    dbHead.AddParameter("DesPointsValue", DbType.Double, data_this.DesPointsValue);
                    dbHead.AddParameter("DesPointsValueLocCur", DbType.Double, data_this.DesPointsValueLocCur);
                    dbHead.AddParameter("PointsCount", DbType.Double, data_this.PointsCount);
                    dbHead.AddParameter("IsPoints", DbType.Boolean, data_this.IsPoints);
                    dbHead.AddParameter("tailor20", DbType.String, data_this.tailor20);
                    dbHead.AddParameter("CINVType", DbType.Int32, data_this.CInvType);
                    dbHead.ExecuteNonQuery(storedProcedure: true, "S_T_INVHED_INSERT");
                    data_this.InvHed_ID = int.Parse(dbHead.GetParameterValue("InvHed_ID").ToString());
                }
                catch (SqlException ex7)
                {
                }
            }
            IDatabase dbLines = Database.GetDatabase(VarGeneral.BranchCS);
            for (int iiCnt = 1; iiCnt < FlxInv.Rows.Count; iiCnt++)
            {
                if (FlxInv.GetData(iiCnt, 1) == null)
                {
                    continue;
                }
                dbLines.ClearParameters();
                dbLines.AddParameter("InvDet_ID", DbType.Int32, 0);
                dbLines.AddParameter("InvNo", DbType.String, textBox_ID.Text.Trim());
                dbLines.AddParameter("InvId", DbType.Int32, data_this.InvHed_ID);
                dbLines.AddParameter("InvSer", DbType.Int32, iiCnt);
                dbLines.AddParameter("ItmNo", DbType.String, string.Concat(FlxInv.GetData(iiCnt, 1)));
                dbLines.AddParameter("Cost", DbType.Double, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 10)))));
                dbLines.AddParameter("Qty", DbType.Double, 0.0 - double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 7)))));
                dbLines.AddParameter("ItmDes", DbType.String, string.Concat(FlxInv.GetData(iiCnt, 2)));
                dbLines.AddParameter("ItmUnt", DbType.String, string.Concat(FlxInv.GetData(iiCnt, 3)));
                dbLines.AddParameter("ItmDesE", DbType.String, string.Concat(FlxInv.GetData(iiCnt, 4)));
                dbLines.AddParameter("ItmUntE", DbType.String, string.Concat(FlxInv.GetData(iiCnt, 5)));
                dbLines.AddParameter("ItmUntPak", DbType.Double, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 11)))));
                dbLines.AddParameter("StoreNo", DbType.Int32, int.Parse(VarGeneral.TString.TEmpty(FlxInv.GetData(iiCnt, 6).ToString() ?? string.Empty)));
                dbLines.AddParameter("Price", DbType.Double, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 8)))));
                dbLines.AddParameter("Amount", DbType.Double, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 38)))));
                dbLines.AddParameter("RealQty", DbType.Double, 0.0 - double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 12)))));
                dbLines.AddParameter("itmInvDsc", DbType.Double, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 13)))));
                if (VarGeneral.CheckDate(string.Concat(FlxInv.GetData(iiCnt, 27))))
                {
                    dbLines.AddParameter("DatExper", DbType.String, string.Concat(FlxInv.GetData(iiCnt, 27)));
                }
                else
                {
                    dbLines.AddParameter("DatExper", DbType.String, string.Empty);
                }
                dbLines.AddParameter("CInvType", DbType.Int32, VarGeneral.DraftBillId);
                dbLines.AddParameter("ItmDis", DbType.Double, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 9)))));
                dbLines.AddParameter("ItmTyp", DbType.Int32, int.Parse("0" + FlxInv.GetData(iiCnt, 32)));
                dbLines.AddParameter("ItmIndex", DbType.Int32, 0);
                try
                {
                    dbLines.AddParameter("ItmWight", DbType.Double, ((bool)FlxInv.GetData(iiCnt, 33)) ? 1 : 0);
                }
                catch
                {
                    dbLines.AddParameter("ItmWight", DbType.Double, 0);
                }
                dbLines.AddParameter("ItmWight_T", DbType.Double, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 34)))));
                if (!string.IsNullOrEmpty(string.Concat(FlxInv.GetData(iiCnt, 35))))
                {
                    dbLines.AddParameter("RunCod", DbType.String, string.Concat(FlxInv.GetData(iiCnt, 35)));
                }
                else
                {
                    dbLines.AddParameter("RunCod", DbType.String, string.Empty);
                }
                dbLines.AddParameter("LineDetails", DbType.String, string.Concat(FlxInv.GetData(iiCnt, 36)));
                dbLines.AddParameter("Serial_Key", DbType.String, string.Concat(FlxInv.GetData(iiCnt, 37)));
                dbLines.AddParameter("ItmTax", DbType.Double, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 31)))));
                try
                {
                    if (!string.IsNullOrEmpty(FlxInv.GetData(iiCnt, 39).ToString()))
                    {
                        dbLines.AddParameter("OfferTyp", DbType.Int32, int.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 39)))));
                    }
                }
                catch
                {
                }
                dbLines.ExecuteNonQuery(storedProcedure: true, "S_T_INVDET_INSERT");
            }
        }
        private void button_Draft_Click(object sender, EventArgs e)
        {
            if (State != FormState.New)
            {
                button_Draft.Enabled = false;
            }
            string sa; try { sa = FlxInv.GetData(1, 1).ToString(); } catch { sa = string.Empty; }
            if (sa != string.Empty && State == FormState.New)
            {
                T_INVSETTING ts = null;
                try
                {
                    ts = db.StockInvSetting(VarGeneral.UserID, VarGeneral.DraftBillId);
                }
                catch { }
                if (ts.InvSet_ID == 0)
                {
                    DBUdate.DbUpdates.adddraft();
                }
                //  draft = 1;
                saveDraft();
                Clear();
                State = FormState.Saved;
                RefreshPKeys();
                TextBox_Index.TextBox.Text = string.Concat(PKeys.IndexOf(data_this.InvNo ?? string.Empty) + 1);
                SetReadOnly = true;
                Button_Add_Click(null, null);
                button_opendraft.Enabled = true;
                //  draft = 0;
                return;
            }
        }
        private void button_opendraft_Click(object sender, EventArgs e)
        {
            if (State != FormState.New)
            {
                Button_Add_Click(null, null);
                if (State != FormState.New)
                    return;
            }
            int oldTyp = VarGeneral.InvTyp;
            try
            {
                columns_Names_visible2.Clear();
                columns_Names_visible2.Add("InvNo", new ColumnDictinary("رقم الفاتورة", "Invoice No", ifDefault: true, string.Empty));
                columns_Names_visible2.Add("HDat", new ColumnDictinary("التاريخ الهجري", "Date Hijri", ifDefault: true, string.Empty));
                columns_Names_visible2.Add("GDat", new ColumnDictinary("التاريخ الميلادي", "Date Gregorian", ifDefault: true, string.Empty));
                columns_Names_visible2.Add("InvTotLocCur", new ColumnDictinary("إجمالي الفاتورة", "Invoice Total", ifDefault: false, string.Empty));
                columns_Names_visible2.Add("InvNetLocCur", new ColumnDictinary("صافي الفاتورة", "Invoice Net", ifDefault: true, string.Empty));
                columns_Names_visible2.Add("InvQty", new ColumnDictinary("إجمالي الكمية", "Quantity Total", ifDefault: true, string.Empty));
                columns_Names_visible2.Add("RefNo", new ColumnDictinary("رقم المرجع", "Refrence No", ifDefault: false, string.Empty));
                columns_Names_visible2.Add("InvDisValLocCur", new ColumnDictinary("الخصم قيمة", "Discount value", ifDefault: true, string.Empty));
                columns_Names_visible2.Add("GadeNo", new ColumnDictinary("رقم القيد المحاسبي", "Gaid No", ifDefault: false, string.Empty));
                columns_Names_visible2.Add("CusVenAdd", new ColumnDictinary("الجوال", "Mobile", ifDefault: true, string.Empty));
                columns_Names_visible2.Add("InvHed_ID", new ColumnDictinary("تسلسل الفاتورة", " ID", ifDefault: true, string.Empty));
                columns_Names_visible2.Add("CusVenNm", new ColumnDictinary("اسم العميل ", " ID", ifDefault: true, string.Empty));
                FrmSearch frm = new FrmSearch();
                frm.Tag = LangArEn;
                ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible2;
                foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
                {
                    frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
                }
                VarGeneral.SFrmTyp = "T_Draft";
                //  VarGeneral.InvTyp = 101;
                frm.TopMost = true;
                frm.ShowDialog();
                if (frm.SerachNo != string.Empty)
                {
                    T_INVHED newData = db.StockInvHeadID2(VarGeneral.DraftBillId, int.Parse(frm.SerachNo), VarGeneral.UserNo);
                    newData.InvNo = textBox_ID.Text.ToString();
                    newData.InvTyp = oldTyp;
                    SetData(newData);
                    State = FormState.New;
                    Button_Save.Enabled = true;
                    GetInvSetting();
                    AutoGaidAcc();
                    if (_InvSetting.autoTaxGaid.Value)
                    {
                        checkBox_CostGaidTax.Checked = true;
                        checkBox_CostGaidTax_CheckedChanged(null, null);
                    }
                    if (_InvSetting.autoDisGaid.Value)
                    {
                        checkBox_GaidDis.Checked = true;
                        checkBox_GaidDis_CheckedChanged(null, null);
                    }
                    string dl = "DELETE FROM T_INVDET WHERE InvId=" + frm.SerachNo + " AND CInvType=" + VarGeneral.DraftBillId.ToString();
                    DBUdate.DbUpdates.executes(dl, VarGeneral.BranchCS);
                    dl = "Delete From T_INVHED where InvTyp=" + VarGeneral.DraftBillId.ToString() + " AND InvHed_ID=" + frm.SerachNo.ToString() + " and SalsManNo = " + VarGeneral.UserNo;
                    DBUdate.DbUpdates.executes(dl, VarGeneral.BranchCS);
                    FlxInv.Rows.Count += VarGeneral.Settings_Sys.LineOfInvoices.Value;
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("opendraft:", error, enable: true);
            }
            VarGeneral.InvTyp = oldTyp;
            checkoversaved();
            if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 85))
            {
                switchButton_Lock.Visible = false;
            }
        }
        void checkoversaved()
        {
            int i = db.StockInvHeadSaveover(VarGeneral.InvTyp, VarGeneral.UserNo);
            if (i > 0)
                button_opendraft.Enabled = true;
            else
                button_opendraft.Enabled = false;
        }
        private void superTabControl_CostSts_SelectedTabChanged(object sender, SuperTabStripSelectedTabChangedEventArgs e)
        {
        }
        private void FlxInv_KeyDown_1(object sender, KeyEventArgs e)
        {
        }
        private void FlxInv_StartEdit(object sender, RowColEventArgs e)
        {
            kk = 1;
            if (e.Col == 8)
            {
                beforeeditprice = 1;
                //     double.Parse(FlxInv.GetData(e.Row, 8).ToString(), out beforeeditprice);
            }
            if (e.Col == 38)
            {
                if (edit) beforeeditprice = 2; else enteredtotal = 0;
            }
            else
            { enteredtotal = 0; }
        }
        double getround(double value)
        {
            return Math.Round(value, VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2);
        }
        double _without = 0;
        public double without
        {
            set
            {
                if (value < 1000)
                { }
                _without = value;
            }
            get
            {
                return _without;
            }
        }
        int convertflag = 0;
        private void ChkPriceIncludeTax_ValueChanged(object sender, EventArgs e)
        {
            if (State != FormState.New)
                Button_Edit_Click(null, null);
            convertflag = 1;
            if (ChkPriceIncludeTax.Value)
            {
                switchButton_TaxByNet.Value = false;
                switchButton_TaxByTotal.Value = true;
                switchButton_TaxLines.Value = true;
                switchButton_TaxByNet.Enabled = false;
                switchButton_TaxByTotal.Enabled = false;
                switchButton_TaxLines.Enabled = false;
                switchButton_TaxLines_ValueChanged(null, null);
            }
            else
            {
                switchButton_TaxByNet.Enabled = true;
                switchButton_TaxByTotal.Enabled = true;
                switchButton_TaxLines.Enabled = true;
            }
            pricel = 0.0; lastprice = 0.0;
            if (ChkPriceIncludeTax.Value)
            {
                for (int iiCnt = 1; iiCnt < FlxInv.Rows.Count; iiCnt++)
                {
                    if (FlxInv.GetData(iiCnt, 1) == null)
                    {
                        continue;
                    }
                    else
                    {
                        pricel = double.Parse(FlxInv.GetData(iiCnt, 8).ToString());
                        without = getround(pricel);
                        double t = 0;
                        t = double.Parse(FlxInv.GetData(iiCnt, 31).ToString());
                        pricel = getround(caltax(pricel, t));
                        FlxInv.SetData(iiCnt, 8, pricel);
                        FlxInv_AfterEdit(null, new RowColEventArgs(iiCnt, 8));//p
                                                                              //   FlxInv_AfterEdit(null, new RowColEventArgs(iiCnt, 7));
                    }
                    GetInvTot();
                }
            }
            else
            {
                for (int iiCnt = 1; iiCnt < FlxInv.Rows.Count; iiCnt++)
                {
                    if (FlxInv.GetData(iiCnt, 1) == null)
                    {
                        continue;
                    }
                    else
                    {
                        double reprice = 0;
                        reprice = double.Parse(FlxInv.GetData(iiCnt, 8).ToString());
                        double taxx = 0.0;
                        taxx = double.Parse(FlxInv.GetData(iiCnt, 31).ToString());
                        reprice = Rcaltax(reprice, taxx); without = reprice;
                        lastprice = 0; pricel = reprice;
                        reprice = getround(reprice);
                        FlxInv.SetData(iiCnt, 8, reprice);
                        FlxInv_AfterEdit(null, new RowColEventArgs(iiCnt, 8));//p
                                                                              //   FlxInv_AfterEdit(null, new RowColEventArgs(iiCnt, 7));
                        GetInvTot();
                    }
                }
                GetInvTot();
            }
            convertflag = 0;
        }
        bool newprice = false, fa = false;
        public double pricel = 0.0, lastprice = 0.0;

        private void buttonItem_Print_Click_1(object sender, EventArgs e)
        {

        }

        private void txtTotalAmLoc_ValueChanged(object sender, EventArgs e)
        {
        }
        double beforeeditprice = 0, enteredtotal = 0;
        public double pricets = 0.0, t1 = 0, tot = 0;
        private void Button_Add_Click_1(object sender, EventArgs e)
        {
        }
        private void superTabControl_Main1_SelectedTabChanged(object sender, SuperTabStripSelectedTabChangedEventArgs e)
        {
        }
        private void button_SrchCustNo_Click_1(object sender, EventArgs e)
        {
        }
    }
}
