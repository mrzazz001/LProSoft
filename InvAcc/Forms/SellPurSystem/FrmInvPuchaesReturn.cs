using C1.Win.C1FlexGrid;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.DotNetBar.SuperGrid;
using DevComponents.DotNetBar.SuperGrid.Style;
using DevComponents.Editors;
using Framework.Data;
using InputKey;
using ProShared.GeneralM;using ProShared;
using ProShared.Stock_Data;
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
using ScriptNumber = ProShared.ScriptNumber;
using InvAcc.Forms.SellPurSystem.specialcontrols;

namespace InvAcc.Forms
{
    public partial  class FrmInvPuchaesReturn : Form
    { void avs(int arln)

{ 
 button_opendraft.Text=   (arln == 0 ? "  الفواتير المعلقة  " : "  Pending invoices") ; button_Draft.Text=   (arln == 0 ? "  تعليق الفاتورة  " : "  Invoice comment") ; label41.Text=   (arln == 0 ? "  جوال :  " : "  mobile:") ; label32.Text=   (arln == 0 ? "  السيريال  " : "  serial السي") ; label25.Text=   (arln == 0 ? "  الوحدة  " : "  Unit") ; label22.Text=   (arln == 0 ? "  سعر اخر  مرتجع شراء  " : "  Last purchase return price") ; label23.Text=   (arln == 0 ? "  أخر تكلفة  " : "  latest cost") ; label24.Text=   (arln == 0 ? "  متوسط التكلفة  " : "  average cost") ; superTabItem_items.Text=   (arln == 0 ? "  م.الصنف  " : "  M. Category") ; superTabControl3.Text=   (arln == 0 ? "  superTabControl3  " : "  superTabControl3") ; labelC1.Text=   (arln == 0 ? "  الدائـــن :  " : "  creditor:") ; label14.Text=   (arln == 0 ? "  شبكة :  " : "  Network :") ; labelC2.Text=   (arln == 0 ? "  الدائـــن :  " : "  creditor:") ; label11.Text=   (arln == 0 ? "  آجــل :  " : "  deferred:") ; labelC3.Text=   (arln == 0 ? "  الدائـــن :  " : "  creditor:") ; label6.Text=   (arln == 0 ? "  نقــداٌ :  " : "  cash:") ; labelD1.Text=   (arln == 0 ? "  المـــدين :  " : "  Debtor:") ; labelD3.Text=   (arln == 0 ? "  المـــدين :  " : "  Debtor:") ; labelD2.Text=   (arln == 0 ? "  المـــدين :  " : "  Debtor:") ; superTabItem_Pay.Text=   (arln == 0 ? "  الدفع  " : "  paying off") ; label37.Text=   (arln == 0 ? "  إجمالي القيمة  " : "  Total value") ; label38.Text=   (arln == 0 ? "  الدائـــــن :  " : "  creditor:") ; label39.Text=   (arln == 0 ? "  المـــدين :  " : "  Debtor:") ; label40.Text=   (arln == 0 ? "  بالريــــال  " : "  in riyals") ; checkBox_GaidDis.Text=   (arln == 0 ? "  سند محاسبي  " : "  accounting document") ; superTabItem_Dis.Text=   (arln == 0 ? "  الخصـــــم  " : "  discount ال") ; label34.Text=   (arln == 0 ? "  الدائـــــن :  " : "  creditor:") ; label35.Text=   (arln == 0 ? "  المـــدين :  " : "  Debtor:") ; checkBox_CostGaidTax.Text=   (arln == 0 ? "  سند محاسبي  " : "  accounting document") ; label36.Text=   (arln == 0 ? "  بالريــــال  " : "  in riyals") ; superTabItem_Tax.Text=   (arln == 0 ? "  الضـــرائب  " : "  taxes") ; labelItem_TaxByNetPer.Text=   (arln == 0 ? "  %  " : "  %") ; superTabItem_Gaids.Text=   (arln == 0 ? "  القيود  " : "  limitations") ; label_LockeName.Text=   (arln == 0 ? "  --  " : "  --") ; label27.Text=   (arln == 0 ? "  المستخدم :  " : "  the user :") ; label30.Text=   (arln == 0 ? "  إجمالي الكمية :  " : "  Total Quantity:") ; superTabItem_Detiles.Text=   (arln == 0 ? "  تفاصيل  " : "  details") ; superTabControl_CostSts.Text=   (arln == 0 ? "  superTabControl3  " : "  superTabControl3") ; checkBox_CostLocal.Text=   (arln == 0 ? "  يضاف الى صافي الفاتورة  " : "  Added to the net bill") ; label29.Text=   (arln == 0 ? "  إجمالي التكلفة المحلية  " : "  Total Domestic Cost") ; label20.Text=   (arln == 0 ? "  بالريــــال  " : "  in riyals") ; superTabItem_LocalCosts.Text=   (arln == 0 ? "  تكاليف محلية  " : "  local costs") ; button_AutoCost.Text=   (arln == 0 ? "  تقسيم تلقائي  " : "  Auto split") ; label31.Text=   (arln == 0 ? "  التكلفة الخارجية  " : "  External cost") ; label21.Text=   (arln == 0 ? "  الدائـــن :  " : "  creditor:") ; label16.Text=   (arln == 0 ? "  المـــدين :  " : "  Debtor:") ; checkBox_CostGaid.Text=   (arln == 0 ? "  سند محاسبي  " : "  accounting document") ; label28.Text=   (arln == 0 ? "  بالريــــال  " : "  in riyals") ; superTabItem_ExtrnalCosts.Text=   (arln == 0 ? "  تكاليف خارجية  " : "  External costs") ; superTabItem_Costs.Text=   (arln == 0 ? "  التكاليف  " : "  costs") ; superTabItem_Note.Text=   (arln == 0 ? "  ملاحظات  " : "  Notes") ; label12.Text=   (arln == 0 ? "  هاتف :  " : "  Telephone :") ;  checkBox_NetWork.Text=   (arln == 0 ? "  شبكـــة  " : "Network") ; checkBox_Credit.Text=   (arln == 0 ? "  أجـــل  " : "Credit") ; checkBox_Chash.Text=   (arln == 0 ? "  نقـــدي  " : "Cach") ; label10.Text=   (arln == 0 ? "  اسم المــــــورد :  " : "  Supplier name:") ; label4.Text=   (arln == 0 ? "  حساب  المـــورد :  " : "  Supplier account:") ; label13.Text=   (arln == 0 ? "  عنوان المـــورد :  " : "  Supplier address:") ; Label2.Text=   (arln == 0 ? "  التاريــــــــخ :  " : "  date:") ; Label1.Text=   (arln == 0 ? "  رقم الفاتورة :  " : "  invoice number :") ; label8.Text=   (arln == 0 ? "  نسبة الخصم  " : "  discount percentage") ; label33.Text=   (arln == 0 ? "  الضريبة VAT:  " : "  VAT:") ; Label26.Text=   (arln == 0 ? "  قيمة الخصم  " : "  discount value") ; label3.Text=   (arln == 0 ? "  بالريــال  " : "  in riyals") ; label9.Text=   (arln == 0 ? "  صافي الفاتورة :  " : "  net bill:") ; label17.Text=   (arln == 0 ? "  قيمة الفاتـــورة :  " : "  Invoice value:") ; label5.Text=   (arln == 0 ? "  السعر المعتمــد :  " : "  Approved price:") ; label15.Text=   (arln == 0 ? "  مركز التكلفـــــة :  " : "  cost center:") ; label19.Text=   (arln == 0 ? "  العملــــــــة :  " : "  work:") ; label18.Text=   (arln == 0 ? "  المنـــــدوب :  " : "  The delegate:") ; label7.Text=   (arln == 0 ? "  رقم المرجع :  " : "  reference number :") ; superTabControl1.Text=   (arln == 0 ? "  superTabControl3  " : "  superTabControl3") ; button_Repetition.Text=   (arln == 0 ? "  تكرار  " : "  Repetition") ; ButReturn.Text=   (arln == 0 ? "  إرجاع فاتورة  " : "  return invoice") ; Button_Close.Text=   (arln == 0 ? "  إغلاق  " : "  Close") ; /*buttonItem_Print.Text=   (arln == 0 ? "  طباعة  " : "  Print") ;*/ printersettings.Text=   (arln == 0 ? "  إعدادات الطابعة   " : "  Printer Settings") ; Button_Search.Text=   (arln == 0 ? "  بحث  " : "  Search") ; Button_Delete.Text=   (arln == 0 ? "  حذف  " : "  delete") ; Button_Save.Text=   (arln == 0 ? "  حفظ  " : "  save") ; Button_Add.Text=   (arln == 0 ? "  إضافة  " : "  addition") ;  superTabControl2.Text=   (arln == 0 ? "  superTabControl1  " : "  superTabControl1") ; Button_First.Text=   (arln == 0 ? "  الأول  " : "  the first") ; Button_Prev.Text=   (arln == 0 ? "  السابق  " : "  the previous") ; lable_Records.Text=   (arln == 0 ? "  ---  " : "  ---") ; Button_Next.Text=   (arln == 0 ? "  التالي  " : "  next one") ; Button_Last.Text=   (arln == 0 ? "  الأخير  " : "  the last one") ; ToolStripMenuItem_Rep.Text=   (arln == 0 ? "  إظهار التقرير  " : "  Show report") ; ToolStripMenuItem_Det.Text=   (arln == 0 ? "  إظهار التفاصيل  " : "  Show details") ; panelEx3.Text=   (arln == 0 ? "  Fill Panel  " : "  Fill Panel") ; DGV_Main.Text=   (arln == 0 ? " string.Empty " : " string.Empty") ; DGV_Main.Text=   (arln == 0 ? "  جميــع السجــــلات  " : "  All records") ; DGV_Main.Text=   (arln == 0 ? " string.Empty " : " string.Empty") ; superTabControl_DGV.Text=   (arln == 0 ? "  superTabControl1  " : "  superTabControl1") ; textBox_search.Text=   (arln == 0 ? "  ...  " : "  ...") ; Button_ExportTable2.Text=   (arln == 0 ? "  تصدير  " : "  Export") ; /*Button_PrintTable.Text=   (arln == 0 ? "  طباعة  " : "  Print") ; */Button_PrintTableMulti.Text=   (arln == 0 ? "  طباعة الفواتير المحددة  " : "  Print selected invoices") ; panelEx2.Text=   (arln == 0 ? "  Click to collapse  " : "  Click to collapse") ; superTabControl_Main1.Text=   (arln == 0 ? "  superTabControl3  " : "  superTabControl3") ; superTabControl_Main2.Text=   (arln == 0 ? "  superTabControl1  " : "  superTabControl1") ; Text = "فاتورة مرتجع مشتريات";this.Text=   (arln == 0 ? "  فاتورة مرتجع مشتريات  " : "  Purchase return invoice") ;}
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
#pragma warning disable CS0414 // The field 'FrmInvPuchaesReturn.PriceOld' is assigned but its value is never used
        private double PriceOld = 0.0;
#pragma warning restore CS0414 // The field 'FrmInvPuchaesReturn.PriceOld' is assigned but its value is never used
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
        private T_GDHEAD _GdHeadCost = new T_GDHEAD();
        private T_GDHEAD _GdHeadCostTax = new T_GDHEAD();
        private List<T_GDHEAD> listGdHead = new List<T_GDHEAD>();
        private List<T_GDHEAD> listGdHeadCost = new List<T_GDHEAD>();
        private List<T_GDHEAD> listGdHeadCostTax = new List<T_GDHEAD>();
        private T_GDDET _GdDet = new T_GDDET();
        private List<T_GDDET> listGdDet = new List<T_GDDET>();
        private List<T_GDDET> listGdDetCost = new List<T_GDDET>();
        private List<T_GDDET> listGdDetCostTax = new List<T_GDDET>();
        private List<T_QTYEXP> listQtyExp = new List<T_QTYEXP>();
        private T_GDHEAD _GdHeadCostDis = new T_GDHEAD();
        private List<T_GDHEAD> listGdHeadCostDis = new List<T_GDHEAD>();
        private List<T_GDDET> listGdDetCostDis = new List<T_GDDET>();
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
        private int iiRntP = 0;
        private int _page = 1;
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
                        frm.Repvalue = "PurchaseReturn";
                        frm.RepCashier = "InvoiceCachier";
                        frm.Repvalue = "PurchaseReturn";
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
            superTabControl_Main1.RightToLeftChanged += superTabControl_Main1_RightToLeftChanged;
        }
        public Softgroup.NetResize.NetResize netResize1;
        protected ToolStripMenuItem ToolStripMenuItem_Rep;
        private DoubleInput txtCustNet;
        private DoubleInput txtCustRep;
        private DoubleInput textBox2;
        private DoubleInput textBox1;
        private DockSite barBottomDockSite;
        private ImageList imageList1;
        private DockSite barLeftDockSite;
        private DockSite barRightDockSite;
        private DockSite dockSite4;
        private DockSite dockSite1;
        private DockSite dockSite2;
        private DockSite dockSite3;
        private DockSite barTopDockSite;
        protected ContextMenuStrip contextMenuStrip1;
        private Timer timerInfoBallon;
        protected ContextMenuStrip contextMenuStrip2;
        protected ToolStripMenuItem ToolStripMenuItem_Det;
        private System.Windows.Forms. SaveFileDialog saveFileDialog1;
        private Timer timer1;
        private PrintDocument prnt_doc;
        internal PrintPreviewDialog prnt_prev;
        private DoubleInput txtInvCost;
        private RibbonBar ribbonBar1;
        private Panel panel1;
        private PanelEx panelEx3;
        private ExpandableSplitter expandableSplitter1;
        private PanelEx panelEx2;
        private System.Windows.Forms.OpenFileDialog  openFileDialog1;
        private Bar barTaskList;
        private PanelDockContainer panelDockContainer1;
        private SuperTabControl superTabControl_Main1;
        private SuperTabControl superTabControl_Main2;
        private DockContainerItem Panel_Navigate;
        protected SuperGridControl DGV_Main;
        private RibbonBar ribbonBar_DGV;
        private SuperTabControl superTabControl_DGV;
        private RibbonBar ribbonBar_Tasks;
        private SuperTabControl superTabControl1;
        private SuperTabControl superTabControl2;
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
        private SuperTabItem superTabItem_items;
        private SuperTabControlPanel superTabControlPanel2;
        internal Label label27;
        private DoubleInput txtTotalQ;
        internal Label label30;
        private TextBox textBox_Usr;
        private SuperTabItem superTabItem_Detiles;
        private TextBoxX txtCredit3;
        private TextBoxX txtCredit2;
        private TextBoxX txtCredit1;
        private ButtonX button_CustC1;
        private ButtonX button_CustC3;
        private ButtonX button_CustC2;
        private ButtonX button_CustD1;
        private ButtonX button_CustD3;
        private ButtonX button_CustD2;
        private TextBoxX txtDebit3;
        private TextBoxX txtDebit2;
        private TextBoxX txtDebit1;
        internal Label labelD3;
        internal Label labelD2;
        internal Label labelD1;
        internal Label label14;
        internal Label label11;
        internal Label label6;
        private DoubleInput doubleInput_CreditLoc;
        private DoubleInput doubleInput_NetWorkLoc;
        private DoubleInput txtPaymentLoc;
        internal Label labelC3;
        internal Label labelC2;
        internal Label labelC1;
        private SuperTabControlPanel superTabControlPanel4;
        private TextBoxX txtRemark;
        private SuperTabItem superTabItem_Note;
        private LabelItem lable_Records;
        private SuperTabControlPanel superTabControlPanel5;
        private SuperTabItem superTabItem_Costs;
        private C1FlexGrid FlxInv;
        private SuperTabControl superTabControl_CostSts;
        private SuperTabControlPanel superTabControlPanel6;
        internal Label label29;
        internal Label label20;
        private DoubleInput txtTotCost;
        private DoubleInput txtTotCostLoc;
        private SuperTabItem superTabItem_LocalCosts;
        private SuperTabControlPanel superTabControlPanel7;
        internal Label label31;
        internal Label label21;
        internal Label label16;
        private ButtonX button_CustC4;
        private TextBoxX txtCredit4;
        private ButtonX button_CustD4;
        private TextBoxX txtDebit4;
        private CheckBoxX checkBox_CostGaid;
        internal Label label28;
        private DoubleInput txtTotCostExtrnal;
        private DoubleInput txtTotCostLocExtrnal;
        private SuperTabItem superTabItem_ExtrnalCosts;
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
        private ButtonX button_AutoCost;
        private C1FlexGrid FlxDat;
        private SwitchButtonItem switch_Cost;
        internal Label label32;
        private TextBox txtVSerial;
        private CheckBoxX checkBox_CostLocal;
        private MaskedTextBox txtTime;
        private MaskedTextBox txtGDate;
        private MaskedTextBox txtHDate;
        private C1FlexGrid FlxStkQty;
        private SwitchButton switchButton_Lock;
        internal Label label_LockeName;
        private TextBoxX textBox_ID;
        private SuperTabControlPanel superTabControlPanel8;
        private SuperTabControl superTabControl3;
        private SuperTabControlPanel superTabControlPanel9;
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
        private SuperTabControlPanel superTabControlPanel10;
        private SuperTabItem superTabItem_Dis;
        private SuperTabItem superTabItem_Gaids;
        internal Label label37;
        internal Label label38;
        internal Label label39;
        private TextBoxX txtCredit6;
        private TextBoxX txtDebit6;
        internal Label label40;
        private DoubleInput txtTotDis;
        private DoubleInput txtTotDisLoc;
        private CheckBoxX checkBox_GaidDis;
        private SwitchButton switchButton_Dis;
        private SwitchButtonItem switchButton_TaxLines;
        private SwitchButtonItem switchButton_TaxByTotal;
        private SwitchButtonItem switchButton_TaxByNet;
        private TextBoxItem textBoxItem_TaxByNetValue;
        private LabelItem labelItem_TaxByNetPer;
        private CheckBoxItem ChkA4Cahir;
        internal Label label41;
        private TextBox text_Mobile;
        private SuperTabControlPanel superTabControlPanel1;
        private SuperTabItem superTabItem_Pay;
        private ButtonItem printersettings;
        private ButtonX button_opendraft;
        private ButtonX button_Draft;
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
                if (VarGeneral.DeleteOption == 1) Button_Delete.Visible = false;
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
                if (State == FormState.Saved)
                {
                    button_Repetition.Enabled = true;
                    textBox_ID.ButtonCustom.Visible = true;
                    Button_PrintTableMulti.Enabled = true;
                }
                else
                {
                    button_Repetition.Enabled = false;
                    textBox_ID.ButtonCustom.Visible = false;
                    Button_PrintTableMulti.Enabled = false;
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
                if (!VarGeneral.TString.ChkStatShow(value.InvStr, 13))
                {
                    IfAdd = false;
                }
                else
                {
                    IfAdd = true;
                }
                if (!VarGeneral.TString.ChkStatShow(value.InvStr, 14) || switchButton_Lock.Value)
                {
                    CanEdit = false;
                }
                else
                {
                    CanEdit = true;
                }
                if (!VarGeneral.TString.ChkStatShow(value.InvStr, 15) || switchButton_Lock.Value)
                {
                    IfDelete = false;
                }
                else
                {
                    IfDelete = true;
                }
                if (!VarGeneral.TString.ChkStatShow(value.InvStr, 59) || switchButton_Lock.Value)
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
            if (VarGeneral.DeleteOption == 1)
                return;
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
                VarGeneral.InvType = 4;
                FRInvoice form1 = new FRInvoice(VarGeneral.InvTyp, LangArEn);
                form1.Tag = LangArEn.ToString();
                form1.StartPosition = FormStartPosition.CenterScreen;
                form1.TopMost = true;
                form1.ShowDialog();
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
        private void txtTime_Click(object sender, EventArgs e)
        {
            txtTime.SelectAll();
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
            VarGeneral.InvTyp = 4;
        }
        public FrmInvPuchaesReturn()
        {
            InitializeComponent();this.Load += langloads;
            base.Activated += FrmInvices_CheckFouce;
            textBox_ID.KeyPress += textBox_ID_KeyPress;
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
            switch_Cost.Click += Button_Edit_Click;
            txtDiscountValLoc.Click += Button_Edit_Click;
            txtDueAmount.Click += Button_Edit_Click;
            txtDueAmountLoc.Click += Button_Edit_Click;
            txtGDate.Click += Button_Edit_Click;
            txtHDate.Click += Button_Edit_Click;
            txtInvCost.Click += Button_Edit_Click;
            txtItemName.Click += Button_Edit_Click;
            checkBox_CostLocal.Click += Button_Edit_Click;
            txtRef.Click += Button_Edit_Click;
            txtRemark.Click += Button_Edit_Click;
            txtTele.Click += Button_Edit_Click;
            txtTime.Click += Button_Edit_Click;
            txtTotalAm.Click += Button_Edit_Click;
            txtTotalAmLoc.Click += Button_Edit_Click;
            txtTotalQ.Click += Button_Edit_Click;
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
            CmbCostC.Click += Button_Edit_Click;
            CmbCurr.Click += Button_Edit_Click;
            checkBox_Chash.Click += Button_Edit_Click;
            checkBox_Credit.Click += Button_Edit_Click;
            checkBox_NetWork.Click += Button_Edit_Click;
            CmbInvPrice.Click += Button_Edit_Click;
            CmbLegate.Click += Button_Edit_Click;
            txtTotCost.Click += Button_Edit_Click;
            txtTotCostLoc.Click += Button_Edit_Click;
            checkBox_CostGaid.Click += Button_Edit_Click;
            txtTotCostExtrnal.Click += Button_Edit_Click;
            txtTotCostLocExtrnal.Click += Button_Edit_Click;
            txtPaymentLoc.Click += Button_Edit_Click;
            doubleInput_CreditLoc.Click += Button_Edit_Click;
            doubleInput_NetWorkLoc.Click += Button_Edit_Click;
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
            FlxInv.KeyDown += FlxInv_KeyDown;
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
            txtRemark.ButtonCustomClick += txtRemark_ButtonCustomClick;
            txtDebit1.ButtonCustomClick += txtDebit1_ButtonCustomClick;
            txtDebit2.ButtonCustomClick += txtDebit2_ButtonCustomClick;
            txtDebit3.ButtonCustomClick += txtDebit3_ButtonCustomClick;
            txtCredit1.ButtonCustomClick += txtCredit1_ButtonCustomClick;
            txtCredit2.ButtonCustomClick += txtCredit2_ButtonCustomClick;
            txtCredit3.ButtonCustomClick += txtCredit3_ButtonCustomClick;
            button_CustD1.Click += button_CustD1_Click;
            button_CustD2.Click += button_CustD2_Click;
            button_CustD3.Click += button_CustD3_Click;
            button_CustC1.Click += button_CustC1_Click;
            button_CustC2.Click += button_CustC2_Click;
            button_CustC3.Click += button_CustC3_Click;
            txtDebit4.ButtonCustomClick += txtDebit4_ButtonCustomClick;
            txtDebit5.ButtonCustomClick += txtDebit5_ButtonCustomClick;
            txtCredit4.ButtonCustomClick += txtCredit4_ButtonCustomClick;
            txtCredit5.ButtonCustomClick += txtCredit5_ButtonCustomClick;
            button_CustD4.Click += button_CustD4_Click;
            button_CustD5.Click += button_CustD5_Click;
            button_CustC4.Click += button_CustC4_Click;
            button_CustC5.Click += button_CustC5_Click;
            txtCustNo.TextChanged += txtCustNo_TextChanged;
            txtPaymentLoc.Leave += txtPaymentLoc_Leave;
            doubleInput_CreditLoc.Leave += doubleInput_CreditLoc_Leave;
            doubleInput_NetWorkLoc.Leave += doubleInput_NetWorkLoc_Leave;
            if (VarGeneral.SSSLev == "B" || VarGeneral.SSSLev == "F" || VarGeneral.SSSLev == "S" || VarGeneral.SSSLev == "C")
            {
                CmbCostC.Visible = false;
                label15.Visible = false;
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
            try
            {
                if (File.Exists(Application.StartupPath + "\\Script\\SecriptColDisPurchaesReturn.dll") || (VarGeneral.gUserName == "runsetting" && File.Exists(Application.StartupPath + "\\Script\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\SecriptColDisPurchaesReturn.dll")))
                {
                    FlxInv.Cols[37].DataType = typeof(double);
                    if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49))
                    {
                        FlxInv.Cols[37].Format = VarGeneral.DicimalNN;
                    }
                    else
                    {
                        FlxInv.Cols[37].Format = "N2";
                    }
                    FlxInv.Cols[37].Style.TextAlign = TextAlignEnum.CenterCenter;
                    FlxInv.Cols[37].StyleFixed.TextAlign = TextAlignEnum.CenterCenter;
                }
            }
            catch
            {
            }
            try
            {
                if (File.Exists(Application.StartupPath + "\\Script\\SecriptColDisPurchaesReturnValue.dll") || (VarGeneral.gUserName == "runsetting" && File.Exists(Application.StartupPath + "\\Script\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\SecriptColDisPurchaesReturnValue.dll")))
                {
                    FlxInv.Cols[37].DataType = typeof(double);
                    if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49))
                    {
                        FlxInv.Cols[37].Format = VarGeneral.DicimalNN;
                    }
                    else
                    {
                        FlxInv.Cols[37].Format = "N2";
                    }
                    FlxInv.Cols[37].Style.TextAlign = TextAlignEnum.CenterCenter;
                    FlxInv.Cols[37].StyleFixed.TextAlign = TextAlignEnum.CenterCenter;
                }
            }
            catch
            {
            }
            if (File.Exists(Application.StartupPath + "\\Script\\GLassSR.dll"))
            {
                this.Load += GlassSR_Load;
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
        private void txtDebit4_ButtonCustomClick(object sender, EventArgs e)
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
                    txtDebit4.Tag = _AccDef.AccDef_No;
                    if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                    {
                        txtDebit4.Text = _AccDef.Arb_Des;
                    }
                    else
                    {
                        txtDebit4.Text = _AccDef.Eng_Des;
                    }
                }
                else
                {
                    txtDebit4.Text = string.Empty;
                    txtDebit4.Tag = string.Empty;
                }
            }
            catch
            {
                txtDebit4.Text = string.Empty;
                txtDebit4.Tag = string.Empty;
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
        private void txtCredit4_ButtonCustomClick(object sender, EventArgs e)
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
                    txtCredit4.Tag = _AccDef.AccDef_No;
                    if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                    {
                        txtCredit4.Text = _AccDef.Arb_Des;
                    }
                    else
                    {
                        txtCredit4.Text = _AccDef.Eng_Des;
                    }
                }
                else
                {
                    txtCredit4.Text = string.Empty;
                    txtCredit4.Tag = string.Empty;
                }
            }
            catch
            {
                txtCredit4.Text = string.Empty;
                txtCredit4.Tag = string.Empty;
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
        private void button_CustD4_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCustNo.Text))
            {
                Button_Edit_Click(sender, e);
                txtDebit4.Tag = txtCustNo.Text;
                txtDebit4.Text = ((LangArEn == 0) ? db.SelectAccRootByCode(txtCustNo.Text).Arb_Des : db.SelectAccRootByCode(txtCustNo.Text).Eng_Des);
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
        private void button_CustC4_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCustNo.Text))
            {
                Button_Edit_Click(sender, e);
                txtCredit4.Tag = txtCustNo.Text;
                txtCredit4.Text = ((LangArEn == 0) ? db.SelectAccRootByCode(txtCustNo.Text).Arb_Des : db.SelectAccRootByCode(txtCustNo.Text).Eng_Des);
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
                if ((_InvSetting.InvpRINTERInfo.ISPOINTERType!=true))
                    {
                        RepShow _RepShow = new RepShow();
                        _RepShow.Tables = "T_INVDET LEFT OUTER JOIN T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID LEFT OUTER JOIN T_INVSETTING ON T_INVHED.InvTyp = T_INVSETTING.InvID  LEFT OUTER JOIN T_Curency ON T_INVHED.CurTyp = T_Curency.Curency_ID LEFT OUTER JOIN T_CstTbl ON T_INVHED.InvCstNo = T_CstTbl.Cst_ID LEFT OUTER JOIN T_Mndob ON T_INVHED.MndNo = T_Mndob.Mnd_ID LEFT OUTER JOIN T_Items ON T_INVDET.ItmNo = T_Items.Itm_No LEFT OUTER JOIN T_CATEGORY ON T_Items.ItmCat = T_CATEGORY.CAT_ID LEFT OUTER JOIN T_SYSSETTING ON T_INVHED.CompanyID = T_SYSSETTING.SYSSETTING_ID ";
                        string vInvH = " T_INVHED.InvHed_ID, T_INVHED.InvId as vID, T_INVHED.InvNo, T_INVHED.InvTyp, T_INVHED.InvCashPay, T_INVHED.CusVenNo,case when T_INVHED.CusVenNo = '' THEN T_INVHED.CusVenNm ELSE (select T_AccDef.Arb_Des from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as CusVenNm,case when T_INVHED.CusVenNo = '' THEN T_INVHED.CusVenNm ELSE (select T_AccDef.Eng_Des from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as CusVenNmE, T_INVHED.CusVenAdd, T_INVHED.CusVenTel, T_INVHED.Remark, T_INVHED.HDat, T_INVHED.GDat, T_INVHED.MndNo, T_INVHED.SalsManNo, T_INVHED.SalsManNam, T_INVHED.InvTot, T_INVHED.InvDisPrs, ((case when IsDisUse1 = 1 then T_INVHED.InvValGaidDis else T_INVHED.InvDisVal end) + T_INVHED.DesPointsValue) as InvDisVal,T_INVHED.InvDisVal as InvDisValOnly,T_INVHED.DesPointsValue,T_INVHED.DesPointsValueLocCur,T_INVHED.PointsCount,T_INVHED.IsPoints, T_INVHED.InvNet, T_INVHED.InvNetLocCur, T_INVHED.CashPayLocCur, T_INVHED.IfRet, T_INVHED.CashPay, T_INVHED.InvTotLocCur, T_INVHED.InvDisValLocCur, T_INVHED.GadeNo, T_INVHED.GadeId, T_INVHED.RetNo, T_INVHED.RetId, T_INVHED.InvCashPayNm, T_INVHED.InvCost, T_INVHED.CustPri, T_INVHED.ArbTaf, T_INVHED.ToStore, T_INVHED.InvCash, T_INVHED.CurTyp, T_INVHED.EstDat,case when DATEDIFF(day, GETDATE(), EstDat) > 0 Then DATEDIFF(day, GETDATE(), EstDat) WHEN DATEDIFF(day, GETDATE(), InvCashPayNm) > 0 THEN DATEDIFF(day, GETDATE(), InvCashPayNm) Else '0' END as EstDatNote, T_INVHED.InvCstNo, T_INVHED.IfDel, T_INVHED.RefNo, T_INVHED.ToStoreNm, T_INVHED.EngTaf, T_INVHED.IfTrans, T_INVHED.InvQty, T_INVHED.CustNet, T_INVHED.CustRep, T_INVHED.InvWight_T, T_INVHED.IfPrint, T_INVHED.LTim, T_INVHED.DATE_CREATED, T_INVHED.MODIFIED_BY, T_INVHED.CreditPay, T_INVHED.DATE_MODIFIED, T_INVHED.CREATED_BY, T_INVHED.CreditPayLocCur, T_INVHED.NetworkPay, T_INVHED.NetworkPayLocCur, T_INVHED.MndExtrnal, T_INVHED.CompanyID, T_INVHED.InvAddCost, T_INVHED.InvAddCostExtrnal, T_INVHED.InvAddCostExtrnalLoc, T_INVHED.IsExtrnalGaid, T_INVHED.ExtrnalCostGaidID, T_INVHED.InvAddCostLoc, T_INVHED.CommMnd_Inv, T_INVHED.Puyaid, T_INVHED.Remming,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select T_AccDef.PersonalNm from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as PersonalNm,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select T_AccDef.City from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as City,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select T_AccDef.Email from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as Email,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select T_AccDef.Mobile from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as Mobile,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select T_AccDef.Telphone1 from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as Telphone1,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select vColStr1 from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as CustAge,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select T_AccDef.Telphone2 from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as Telphone2,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select T_AccDef.Fax from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as Fax,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select T_AccDef.zipCod from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as zipCod,T_SYSSETTING.LineGiftlNameA,T_SYSSETTING.LineGiftlNameE,T_Curency.Arb_Des as CurrnceyNm,T_Curency.Eng_Des as CurrnceyNmE,(select max(gdDes)from T_GDDET where gdID = T_INVHED.GadeId )as gdDes, (T_INVDET.Amount - (case when T_INVHED.IsTaxLines = 1 then (case when T_INVHED.IsTaxByTotal = 1 then (case when (Abs(T_INVDET.Qty) *  T_INVDET.Price * T_INVDET.ItmTax / 100) > 0 then ((Abs(T_INVDET.Qty) *  T_INVDET.Price) - case when (Abs(T_INVDET.Qty) * T_INVDET.Price * T_INVDET.ItmDis / 100) > 0 then (Abs(T_INVDET.Qty) * T_INVDET.Price * T_INVDET.ItmDis / 100) else 0 end )* T_INVDET.ItmTax / 100   else 0 end) else (Abs(T_INVDET.Qty) *  T_INVDET.Price * T_INVDET.ItmTax / 100) end) else 0 end )) as TotBeforeTax,(select invGdADesc from T_INVSETTING where T_INVHED.InvTyp = T_INVSETTING.InvID ) as invGdADesc,(select invGdEDesc from T_INVSETTING where T_INVHED.InvTyp = T_INVSETTING.InvID ) as invGdEDesc,(select T_CATEGORY.CAT_No from T_CATEGORY where T_CATEGORY.CAT_ID = T_Items.ItmCat) as CAT_No,(select T_CATEGORY.Arb_Des from T_CATEGORY where T_CATEGORY.CAT_ID = T_Items.ItmCat) as CatNmA,(select T_CATEGORY.Eng_Des from T_CATEGORY where T_CATEGORY.CAT_ID = T_Items.ItmCat) as CatNmE,(case when (select t.BarCod1 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit1 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt )) != '' then (select t.BarCod1 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit1 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt ))  when (select t.BarCod2 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit2 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt )) != '' then (select t.BarCod2 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit2 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt )) when (select t.BarCod3 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit3 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt )) != '' then (select t.BarCod3 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit3 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt )) when (select t.BarCod4 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit4 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt )) != '' then (select t.BarCod4 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit4 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt )) when (select t.BarCod5 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit5 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt )) != '' then (select t.BarCod5 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit5 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt )) else T_Items.Itm_No  end) as ItmBarcod";
                        string Fields = " Abs(T_INVDET.Qty) as QtyAbs,T_INVHED.CusVenTaxNo , T_INVDET.InvDet_ID,T_INVHED.tailor1,T_INVHED.tailor2,T_INVHED.tailor3,T_INVHED.tailor4,T_INVHED.tailor5,T_INVHED.tailor6,T_INVHED.tailor7,T_INVHED.tailor8,T_INVHED.tailor9,T_INVHED.tailor10,T_INVHED.tailor11,T_INVHED.tailor12,T_INVHED.tailor13,T_INVHED.tailor14,T_INVHED.tailor15,T_INVHED.tailor16,T_INVHED.tailor17,T_INVHED.tailor18,T_INVHED.tailor19,T_INVHED.tailor20,T_INVHED.InvImg, T_INVDET.InvNo, T_INVDET.InvId, T_INVDET.InvSer, T_INVDET.ItmNo, T_INVDET.Cost, T_INVDET.Qty, T_INVDET.ItmUnt, T_INVDET.ItmDes,T_INVDET.ItmDesE , T_INVDET.ItmUntE, T_INVDET.ItmUntPak, T_INVDET.StoreNo, T_INVDET.Price, T_INVDET.Amount, T_INVDET.RealQty, T_INVDET.ItmTyp,T_INVDET.ItmDis, (Abs(T_INVDET.Qty) *  T_INVDET.Price) * (T_INVDET.ItmDis / 100) as ItmDisVal, T_INVDET.DatExper, T_INVDET.itmInvDsc,ItmIndex," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.LineGiftSts, vStr(VarGeneral.InvTyp)) ? " T_INVDET.ItmWight " : " 0 as ItmWight") + ", T_INVDET.ItmWight_T, T_INVDET.ItmAddCost, T_INVDET.RunCod, T_INVDET.LineDetails ,T_INVDET.Serial_Key, " + vInvH + ", T_Items.* , T_CstTbl.Arb_Des as CstTbl_Arb_Des , T_CstTbl.Eng_Des as CstTbl_Eng_Des , T_Mndob.Arb_Des as Mndob_Arb_Des , T_Mndob.Eng_Des as Mndob_Eng_Des,T_SYSSETTING.LogImg,(select max(T_AccDef.TaxNo) from T_AccDef where T_AccDef.AccDef_No = T_SYSSETTING.TaxAcc) as TaxAcc,T_SYSSETTING.TaxNoteInv,case when T_INVHED.IsTaxLines = 1 then (case when T_INVHED.IsTaxByTotal = 1 then (case when (Abs(T_INVDET.Qty) *  T_INVDET.Price * T_INVDET.ItmTax / 100) > 0 then ((Abs(T_INVDET.Qty) *  T_INVDET.Price) - case when (Abs(T_INVDET.Qty) * T_INVDET.Price * T_INVDET.ItmDis / 100) > 0 then (Abs(T_INVDET.Qty) * T_INVDET.Price * T_INVDET.ItmDis / 100) else 0 end )* T_INVDET.ItmTax / 100   else 0 end) else (Abs(T_INVDET.Qty) *  T_INVDET.Price * T_INVDET.ItmTax / 100) end) else 0 end as TaxValue ,(select InvNamA from T_INVSETTING where T_INVHED.InvTyp = T_INVSETTING.InvID ) as InvNamA,(select InvNamE from T_INVSETTING where T_INVHED.InvTyp = T_INVSETTING.InvID ) as InvNamE,(select T_Store.Arb_Des from T_Store where T_Store.Stor_ID = T_INVDET.StoreNo) as StoreNmA,(select T_Store.Eng_Des from T_Store where T_Store.Stor_ID = T_INVDET.StoreNo) as StoreNmE,(select defPrn from T_INVSETTING where CatID = (select ItmCat from T_Items where Itm_No = T_INVDET.ItmNo) ) as defPrn,case when T_INVHED.CusVenNo = '' THEN '0' ELSE (SELECT Sum(T_GDDET.gdValue) FROM T_GDHEAD INNER JOIN  T_GDDET ON T_GDHEAD.gdhead_ID = T_GDDET.gdID where T_GDDET.AccNo = T_INVHED.CusVenNo and T_GDHEAD.gdLok = 0 and (select T_AccDef.AccCat from T_AccDef where T_AccDef.AccDef_No = T_INVHED.CusVenNo) = '4') END as Balanc,T_INVDET.ItmTax,T_INVHED.InvAddTax,T_INVHED.InvAddTaxlLoc,T_INVHED.TaxGaidID,T_INVHED.IsTaxUse,T_INVHED.IsTaxLines,IsTaxByTotal,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select T_AccDef.TaxNo from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as TaxCustNo,T_INVHED.OrderTyp," + ((data_this.IsTaxLines.Value && !VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 65)) ? " T_INVHED.InvTotLocCur - T_INVHED.InvAddTax as TotWithTaxPoint " : " T_INVHED.InvTotLocCur as TotWithTaxPoint") + " ,T_INVHED.InvTotLocCur - T_INVHED.InvDisVal as TotBeforeDisVal,T_INVHED.IsTaxByNet,T_INVHED.TaxByNetValue," + (data_this.IsTaxUse.Value ? " T_INVHED.InvNetLocCur - T_INVHED.InvAddTax as NetWithoutTax " : " T_INVHED.InvNetLocCur as NetWithoutTax");
                        VarGeneral.HeaderRep[0] = Text;
                        VarGeneral.HeaderRep[1] = string.Empty;
                        VarGeneral.HeaderRep[2] = string.Empty;
                        _RepShow.Rule = " where T_INVHED.InvHed_ID = " + data_this.InvHed_ID;
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
                                    foreach (DataRow r in VarGeneral.RepData.Tables[0].Rows)
                                    {
                                        try
                                        {
                                            if (r["CusVenNo"].ToString() == "")
                                            {
                                                r["TaxCustNo"] = r["CusVenTaxNo"];

                                            }

                                        }
                                        catch
                                        {

                                        }
                                    }
                                    FrmReportsViewer frm = new FrmReportsViewer();
                                    FrmReportsViewer.QRCodeData = Utilites.GetWQRCodeData(DataThis);

                                    frm.Repvalue = "PurchaseReturn";
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
                                    if (_InvSetting.InvpRINTERInfo.ISA4PaperType)
                                    {
                                        frm.Repvalue = "PurchaseReturn";
                                    }
                                    else
                                    {
                                        frm.RepCashier = "InvoiceCachier";
                                    }
                                    if (ChkA4Cahir.Checked)
                                    {
                                        if (frm.Repvalue == "PurchaseReturn")
                                        {
                                            frm.RepCashier = "InvoiceCachier";
                                        }
                                        else
                                        {
                                            frm.Repvalue = "PurchaseReturn";
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
                                    if (_InvSetting.ISdirectPrinting || ifMultiPrint)
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
            txtCrn_No.Text = "";
            text_CusTaxNo.Text = "";
            State = FormState.New;
            data_this = new T_INVHED();
            data_thisRe = new T_INVHED();
            _GdHead = new T_GDHEAD();
            _GdHeadCost = new T_GDHEAD();
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
                FlxInv.Clear(ClearFlags.Content, 1, 1, FlxInv.Rows.Count - 1, 38);
            }
            FlxStkQty.Clear(ClearFlags.Content, 1, 1, 1, 1);
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
            try
            {
                CmbInvPrice.SelectedIndex = int.Parse(_SysSetting.Seting.Substring(13)) + 1;
            }
            catch
            {
                CmbInvPrice.SelectedIndex = 0;
            }
            checkBox_CostGaid.Checked = false;
            checkBox_CostGaid_CheckedChanged(null, null);
            switch_Cost.Value = true;
            checkBox_CostLocal.Checked = false;
            switchButton_Lock.Value = false;
            label_LockeName.Text = ((LangArEn == 0) ? "غير مقف\u0651ــلة" : "Unlocked");
            textBox_ID.ButtonCustom.Visible = false;
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
            SetReadOnly = false;
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
        private void InvModeChanged()
        {   if (checkBox_Credit.Checked)
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
        private void checkBox_Chash_CheckedChanged(object sender, EventArgs e)
        {
            superTabControl_Info.SelectedTabIndex = 4;
            InvModeChanged();
            if (Utilites.isnollorempty(txtCredit1.Tag))

                txtCredit1.Tag = ((_InvSetting.AccCredit0.Trim() != "***") ? _InvSetting.AccCredit0.Trim() : "");
            string ar = "";
            try
            {
                ar = db.SelectAccRootByCode(txtCredit1.Tag.ToString()).Arb_Des;
            }
            catch { }
            {
                if (!string.IsNullOrEmpty(txtCredit1.Tag.ToString()))// && string.IsNullOrEmpty(txtCredit1.Text.ToString()) || (ar.Trim() != txtCredit1.Text.Trim()))
                {
                    if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
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
                    txtCredit1.Text = "";
                }
            }
            if (Utilites.isnollorempty(txtDebit1.Tag))
                txtDebit1.Tag = ((_InvSetting.AccDebit0.Trim() != "***") ? _InvSetting.AccDebit0.Trim() : "");
            try
            {
                ar = db.SelectAccRootByCode(txtDebit1.Tag.ToString()).Arb_Des;
            }
            catch { }

            {
                if (!string.IsNullOrEmpty(txtDebit1.Tag.ToString()))// && string.IsNullOrEmpty(txtDebit1.Text.ToString()) || (ar.Trim() != txtDebit1.Text.Trim()))
                {
                    if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
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
                    txtDebit1.Text = "";
                }
            }
        }
        private void checkBox_Credit_CheckedChanged(object sender, EventArgs e)
        {
            superTabControl_Info.SelectedTabIndex = 4;
            InvModeChanged();
            if (Utilites.isnollorempty(txtCredit2.Tag))
                txtCredit2.Tag = ((_InvSetting.AccCredit1.Trim() != "***") ? _InvSetting.AccCredit1.Trim() : "");
            string ar = "";
            try
            {
                ar = db.SelectAccRootByCode(txtCredit2.Tag.ToString()).Arb_Des;
            }
            catch { }
            {
                if (!string.IsNullOrEmpty(txtCredit2.Tag.ToString()))// && string.IsNullOrEmpty(txtCredit2.Text.ToString()) || (ar.Trim() != txtCredit2.Text.Trim()))
                {
                    if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
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
                    if (txtCustNo.Text != "")
                    {
                        txtCredit2.Text = txtCustName.Text;
                        txtCredit2.Tag = txtCustNo.Text;



                    }
                    else
                        txtCredit2.Text = "";
                }
            }
            if (Utilites.isnollorempty(txtDebit2.Tag))
                txtDebit2.Tag = ((_InvSetting.AccDebit1.Trim() != "***") ? _InvSetting.AccDebit1.Trim() : "");

          
            if (!string.IsNullOrEmpty(txtCustNo.Text))
            {
                txtDebit2.Tag = txtCustNo.Text;
                
            }
            try
            {
                ar = db.SelectAccRootByCode(txtDebit1.Tag.ToString()).Arb_Des;
            }
            catch { }
            {
                if (!string.IsNullOrEmpty(txtDebit2.Tag.ToString()))// && string.IsNullOrEmpty(txtDebit2.Text.ToString()) || (ar.Trim() != txtDebit2.Text.Trim()))
                {
                    if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
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
                    txtDebit2.Text = "";
                }
            }
          
            //if(string.IsNullOrEmpty( txtCredit2.Text))

            //    if (checkBox_Credit.Checked == true && txtCustNo.Text != "")
            //{


            //    txtCredit2.Text = txtCustName.Text;
            //    txtCredit2.Tag = txtCustNo.Text;
            //}
        }

        private void checkBox_NetWork_CheckedChanged(object sender, EventArgs e)
        {
            superTabControl_Info.SelectedTabIndex = 4;
            InvModeChanged();
            doubleInput_NetWorkLoc_Leave(null, null);
            if (Utilites.isnollorempty(txtCredit3.Tag))
                txtCredit3.Tag = ((_InvSetting.AccCredit2.Trim() != "***") ? _InvSetting.AccCredit2.Trim() : "");
            string ar = "";
            try
            {
                ar = db.SelectAccRootByCode(txtCredit3.Tag.ToString()).Arb_Des;
            }
            catch { }
            {
                if (!string.IsNullOrEmpty(txtCredit3.Tag.ToString()))// && string.IsNullOrEmpty(txtCredit3.Text.ToString()) || (ar.Trim() != txtCredit3.Text.Trim()))
                {
                    if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
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
                    if (txtCustNo.Text != "")
                    {
                        txtCredit3.Text = txtCustName.Text;
                        txtCredit3.Tag = txtCustNo.Text;



                    }
                    else
                        txtCredit3.Text = "";
                }
            }

            if (Utilites.isnollorempty(txtDebit3.Tag))

                txtDebit3.Tag = ((_InvSetting.AccDebit2.Trim() != "***") ? _InvSetting.AccDebit2.Trim() : "");
            try
            {
                ar = db.SelectAccRootByCode(txtDebit1.Tag.ToString()).Arb_Des;
            }
            catch { }

            {
                if (!string.IsNullOrEmpty(txtDebit3.Tag.ToString()))// && string.IsNullOrEmpty(txtDebit3.Text.ToString()) || (ar.Trim() != txtDebit3.Text.Trim()))
                {
                    if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
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
                    txtDebit3.Text = "";
                }
            }
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
            VarGeneral.SFrmTyp = "T_AccDef";
            VarGeneral.AccTyp = 5;
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != string.Empty)
            {
                txtCustNo.Text = db.StockAccDefs(int.Parse(frm.Serach_No)).AccDef_No;
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                {
                    txtCustName.Text = db.StockAccDefs(int.Parse(frm.Serach_No)).Arb_Des;
                }
                else
                {
                    txtCustName.Text = db.StockAccDefs(int.Parse(frm.Serach_No)).Eng_Des;
                }
                txtAddress.Text = db.StockAccDefs(int.Parse(frm.Serach_No)).Adders ?? string.Empty;
                txtTele.Text = db.StockAccDefs(int.Parse(frm.Serach_No)).Telphone1 ?? string.Empty;
                try
                {
                    if (db.StockAccDefs(int.Parse(frm.Serach_No)).Mnd.HasValue)
                    {
                        CmbLegate.SelectedValue = db.StockAccDefs(int.Parse(frm.Serach_No)).Mnd;
                    }
                }
                catch
                {
                    CmbLegate.SelectedIndex = 0;
                }
                try
                {
                    txtCustRep.Value = db.StockAccDefs(int.Parse(frm.Serach_No)).Balance.Value;
                }
                catch
                {
                    txtCustRep.Value = 0.0;
                }
                txtDebit2.Text = txtCustName.Text;
                txtDebit2.Tag = txtCustNo.Text;
                
                if (!checkBox_CostGaidTax.Checked || VarGeneral.SSSTyp == 0)
                {
                    return;
                }
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
            else
            {
                txtCustNo.Text = string.Empty;
                txtCustName.Text = string.Empty;
                txtAddress.Text = string.Empty;
                txtCustRep.Value = 0.0;
                txtDebit2.Text = string.Empty;
                txtDebit2.Tag = string.Empty;
                txtDebit3.Text = string.Empty;
                txtDebit3.Tag = string.Empty;
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
                FlxInv.Cols[31].Caption = "تكلفة إضافية";
                FlxInv.Cols[31].Visible = VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 18);
                FlxInv.Cols[38].Caption = "الأجمالي";
                FlxInv.Cols[36].Caption = "رقم التصنيع";
                FlxInv.Cols[37].Caption = VarGeneral.Settings_Sys.LineDetailNameA;
                FlxInv.Cols[37].Visible = VarGeneral.TString.ChkStatShow(_SysSetting.LineDetailSts, 6);
                FlxInv.Cols[35].Caption = "ضريبة %";
                FlxInv.Cols[33].Caption = VarGeneral.Settings_Sys.LineGiftlNameA;
                FlxInv.Cols[33].Visible = VarGeneral.TString.ChkStatShow(_SysSetting.LineGiftSts, 6);
                FlxStkQty.Cols[0].Caption = "المستودع";
                FlxStkQty.Cols[1].Caption = "الكمية المتاحة";
                FlxStkQty.Cols[2].Caption = "المستودع";
                FlxDat.Cols[0].Caption = "تاريخ الصلاحية";
                FlxDat.Cols[1].Caption = "الكمية";
                FlxDat.Cols[2].Caption = "رقم التصنيع";
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
                FlxInv.Cols[31].Caption = "Other Cost";
                FlxInv.Cols[31].Visible = VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 18);
                FlxInv.Cols[38].Caption = "Totel";
                FlxInv.Cols[36].Caption = "Make No";
                FlxInv.Cols[37].Caption = VarGeneral.Settings_Sys.LineDetailNameE;
                FlxInv.Cols[37].Visible = VarGeneral.TString.ChkStatShow(_SysSetting.LineDetailSts, 6);
                FlxInv.Cols[35].Caption = "Tax %";
                FlxInv.Cols[33].Caption = VarGeneral.Settings_Sys.LineGiftlNameE;
                FlxInv.Cols[33].Visible = VarGeneral.TString.ChkStatShow(_SysSetting.LineGiftSts, 6);
                FlxStkQty.Cols[0].Caption = "Store";
                FlxStkQty.Cols[1].Caption = "Quantity";
                FlxStkQty.Cols[2].Caption = "Store";
                FlxDat.Cols[0].Caption = "Expir Date";
                FlxDat.Cols[1].Caption = "Quantity";
                FlxDat.Cols[2].Caption = "Make No";
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
            if (!VarGeneral.TString.ChkStatShow(_InvSetting.TaxOptions, 0))
            {
                FlxInv.Cols[35].Visible = false;
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
                controls.Add(txtCustRep);
                controls.Add(txtDiscountP);
                controls.Add(txtDiscountVal);
                controls.Add(txtDiscountValLoc);
                controls.Add(txtDueAmount);
                controls.Add(txtDueAmountLoc);
                controls.Add(txtGDate);
                controls.Add(txtHDate);
                controls.Add(txtInvCost);
                controls.Add(txtItemName);
                controls.Add(txtLCost);
                controls.Add(txtLPrice);
                controls.Add(txtRef);
                controls.Add(txtRemark);
                controls.Add(txtTele);
                controls.Add(txtTime);
                controls.Add(txtTotalAm);
                controls.Add(txtTotalAmLoc);
                controls.Add(txtTotalQ);
                controls.Add(txtUnit);
                controls.Add(txtVCost);
                controls.Add(txtUnit);
                controls.Add(txtLPrice);
                controls.Add(CmbCostC);
                controls.Add(CmbCurr);
                controls.Add(txtVSerial);
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
                controls.Add(txtTotCost);
                controls.Add(txtTotCostLoc);
                controls.Add(checkBox_CostGaid);
                controls.Add(txtTotCostExtrnal);
                controls.Add(txtTotCostLocExtrnal);
                controls.Add(txtDebit4);
                controls.Add(txtCredit4);
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
                    db.ExecuteCommand("update T_INVHED set DeleteTime = '',IfRet = 0 where IfRet = 1 and InvTyp = 2 and DeleteTime='" + data_this.InvHed_ID + "'");
                }
                catch
                {
                }
                db_.ClearParameters();
                db_.AddParameter("InvHed_ID", DbType.Int32, data_this.InvHed_ID);
                db_.ExecuteNonQuery(storedProcedure: true, "S_T_INVHED_DELETE");
                db_.StartTransaction();
                db_.ClearParameters();
                db_.AddParameter("gdhead_ID", DbType.Int32, _GdHead.gdhead_ID);
                db_.ExecuteNonQueryWithoutCommit(storedProcedure: true, "S_T_GDHEAD_DELETE");
                db_.EndTransaction();
                db_.StartTransaction();
                db_.ClearParameters();
                db_.AddParameter("gdhead_ID", DbType.Int32, _GdHeadCost.gdhead_ID);
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
                Clear();
                GetInvSetting(); button_Draft.Enabled = true;
                textBox_ID.Text = db.MaxInvheadNo.ToString();
                FlxInv.Rows.Count = VarGeneral.Settings_Sys.LineOfInvoices.Value;
                State = FormState.New;
                AutoGaidAcc();
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
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmInvPuchaesReturn));
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
                buttonItem_Print.Text = ((_InvSetting.ISdirectPrinting) ? "طباعة" : "عــرض");
                buttonItem_Print.Tooltip = "F5";
                Button_ExportTable2.Text = "تصدير";
                Button_ExportTable2.Tooltip = "F10";
                DGV_Main.PrimaryGrid.GroupByRow.Text = "جميع السجلات";
                Label1.Text = "رقم الفاتورة :";
                Label2.Text = "التاريــــــــخ :";
                label7.Text = "رقم المرجع :";
                label19.Text = "العملــــــــة :";
                label18.Text = "المنـــــدوب :";
                label4.Text = "حساب  المـــورد :";
                label10.Text = "اسم المــــــورد :";
                label13.Text = "عنوان المـــورد :";
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
                label3.Text = "بالريــال";
                superTabItem_items.Text = "م.الصنف";
                superTabItem_Pay.Text = "الدفع";
                superTabItem_Note.Text = "ملاحظات";
                superTabItem_Detiles.Text = "تفاصيل";
                txtRemark.WatermarkText = "ملاحظات الفاتورة";
                superTabItem_Costs.Text = "التكاليف";
                label27.Text = "نقــدا\u064c :";
                label11.Text = "آجــل :";
                label14.Text = "شبكة :";
                label30.Text = "إجمالي الكمية :";
                label27.Text = "المستخدم :";
                ButReturn.Text = "إرجاع فاتورة";
                ButReturn.Tooltip = "إرجاع فاتورة مشتريات كاملة";
                checkBox_Chash.Text = "نقـــدي";
                checkBox_Credit.Text = "أجـــل";
                labelD1.Text = "المـــدين :";
                labelD2.Text = "المـــدين :";
                labelD3.Text = "المـــدين :";
                labelC1.Text = "الدائـــن :";
                labelC2.Text = "الدائـــن :";
                labelC3.Text = "الدائـــن :";
                button_CustD1.Tooltip = "حساب المورد";
                button_CustD2.Tooltip = "حساب المورد";
                button_CustD3.Tooltip = "حساب المورد";
                button_CustD4.Tooltip = "حساب المورد";
                button_CustC1.Tooltip = "حساب المورد";
                button_CustC2.Tooltip = "حساب المورد";
                button_CustC3.Tooltip = "حساب المورد";
                button_CustC4.Tooltip = "حساب المورد";
                superTabItem_LocalCosts.Text = "تكاليف محلية";
                superTabItem_ExtrnalCosts.Text = "تكاليف خارجية";
                button_AutoCost.Text = "تقسيم تلقائي";
                button_AutoCost.Tooltip = "توزيع التكلفة بالتساوي على جميع الأسطر";
                switch_Cost.OnText = "ايقاف إعتماد التكلفة الإضافية";
                switch_Cost.OffText = "إعتماد التكلفة الإضافية";
                switchButton_Lock.OffText = "لم يتم الموافقة";
                switchButton_Lock.OnText = "تمت الموافقة";
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
                buttonItem_Print.Text = ((_InvSetting.ISdirectPrinting) ? "Print" : "Show");
                buttonItem_Print.Tooltip = "F5";
                Button_ExportTable2.Text = "Export";
                Button_ExportTable2.Tooltip = "F10";
                DGV_Main.PrimaryGrid.GroupByRow.Text = "All Records";
                Label1.Text = "Invoice No :";
                Label2.Text = "Date :";
                label7.Text = "Reference No :";
                label19.Text = "Currncy :";
                label18.Text = "Delegate :";
                label4.Text = "Supplier Account :";
                label10.Text = "Supplier Name :";
                label13.Text = "Supplier Address :";
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
                label3.Text = "Riyal";
                superTabItem_items.Text = "Item Info";
                superTabItem_Pay.Text = "Paid";
                superTabItem_Note.Text = "Notes";
                superTabItem_Detiles.Text = "Details";
                txtRemark.WatermarkText = "Notes";
                superTabItem_Costs.Text = "Costs";
                label27.Text = "Cash :";
                label11.Text = "Credit :";
                label14.Text = "NetWork :";
                label30.Text = "Total Quantity :";
                label27.Text = "User :";
                ButReturn.Text = "Returns Invoice";
                ButReturn.Tooltip = "Returns Invoice Purchases ";
                checkBox_Chash.Text = "Cach";
                checkBox_Credit.Text = "Credit";
                labelD1.Text = "Debtor :";
                labelD2.Text = "Debtor :";
                labelD3.Text = "Debtor :";
                labelC1.Text = "Creditor :";
                labelC2.Text = "Creditor :";
                labelC3.Text = "Creditor :";
                button_CustD1.Tooltip = "Supplier Accounting";
                button_CustD2.Tooltip = "Supplier Accounting";
                button_CustD3.Tooltip = "Supplier Accounting";
                button_CustD4.Tooltip = "Supplier Accounting";
                button_CustC1.Tooltip = "Supplier Accounting";
                button_CustC2.Tooltip = "Supplier Accounting";
                button_CustC3.Tooltip = "Supplier Accounting";
                button_CustC4.Tooltip = "Supplier Accounting";
                superTabItem_LocalCosts.Text = "Local Cost";
                superTabItem_ExtrnalCosts.Text = "External Cost";
                button_AutoCost.Text = "Auto distribution";
                button_AutoCost.Tooltip = "Cost equally to all distribution lines";
                switch_Cost.OnText = "Stop rely the additional cost";
                switch_Cost.OffText = "Rely the additional cost";
                switchButton_Lock.OffText = "not approved";
                switchButton_Lock.OnText = "Been approved";
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
            }
        }
#pragma warning disable CS1998 // This async method lacks 'await' operators and will run synchronously. Consider using the 'await' operator to await non-blocking API calls, or 'await Task.Run(...)' to do CPU-bound work on a background thread.
        private async void FrmInvPuchaesReturn_Load(object sender, EventArgs e)
#pragma warning restore CS1998 // This async method lacks 'await' operators and will run synchronously. Consider using the 'await' operator to await non-blocking API calls, or 'await Task.Run(...)' to do CPU-bound work on a background thread.
        {
            try
            {
                button_Draft.Enabled = false; Location = Frm_Main.loc;
                if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 85))
            {
                switchButton_Lock.Visible = false;
            }
                ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmInvPuchaesReturn));
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
                Permmission = dbc.Get_PermissionID(VarGeneral.UserID);
                _StorePr = permission.StorePrmission.Split(',').ToList();
                if (columns_Names_visible.Count == 0)
                {
                    columns_Names_visible.Add("InvNo", new ColumnDictinary("رقم الفاتورة", "Invoice No", ifDefault: true, string.Empty));
                    columns_Names_visible.Add("CusVenNm", new ColumnDictinary("إسم المورد - عربي", "Customer Arabic Name", ifDefault: true, string.Empty));
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
                    txtDebit4.Visible = false;
                    button_CustD4.Visible = false;
                    txtCredit4.Visible = false;
                    button_CustC4.Visible = false;
                    label16.Visible = false;
                    label21.Visible = false;
                    checkBox_CostGaid.Visible = false;
                    txtDebit5.Visible = false;
                    button_CustD5.Visible = false;
                    txtCredit5.Visible = false;
                    button_CustC5.Visible = false;
                    checkBox_CostGaidTax.Visible = false;
                    label38.Visible = false;
                    label34.Visible = false;
                    txtDebit6.Visible = false;
                    label35.Visible = false;
                    txtCredit6.Visible = false;
                    label39.Visible = false;
                    checkBox_GaidDis.Visible = false;
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
            if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49))
            {
                doubleInput_Rate.DisplayFormat = VarGeneral.DicemalMask;
                txtDiscountVal.DisplayFormat = VarGeneral.DicemalMask;
                txtDiscountP.DisplayFormat = VarGeneral.DicemalMask;
                txtTotalAmLoc.DisplayFormat = VarGeneral.DicemalMask;
                txtDueAmountLoc.DisplayFormat = VarGeneral.DicemalMask;
                txtDiscountValLoc.DisplayFormat = VarGeneral.DicemalMask;
                txtTotalAm.DisplayFormat = VarGeneral.DicemalMask;
                txtDueAmount.DisplayFormat = VarGeneral.DicemalMask;
                txtTotalQ.DisplayFormat = VarGeneral.DicemalMask;
                txtPaymentLoc.DisplayFormat = VarGeneral.DicemalMask;
                doubleInput_CreditLoc.DisplayFormat = VarGeneral.DicemalMask;
                doubleInput_NetWorkLoc.DisplayFormat = VarGeneral.DicemalMask;
                txtTotCost.DisplayFormat = VarGeneral.DicemalMask;
                txtTotCostLoc.DisplayFormat = VarGeneral.DicemalMask;
                txtTotCostExtrnal.DisplayFormat = VarGeneral.DicemalMask;
                txtTotCostLocExtrnal.DisplayFormat = VarGeneral.DicemalMask;
                txtTotTax.DisplayFormat = VarGeneral.DicemalMask;
                txtTotTaxLoc.DisplayFormat = VarGeneral.DicemalMask;
                txtTotDis.DisplayFormat = VarGeneral.DicemalMask;
                txtTotDisLoc.DisplayFormat = VarGeneral.DicemalMask;
                try
                {
                    FlxInv.Cols[8].Format = VarGeneral.DicimalNN;
                    FlxInv.Cols[9].Format = VarGeneral.DicimalNN;
                    FlxInv.Cols[10].Format = VarGeneral.DicimalNN;
                    FlxInv.Cols[11].Format = VarGeneral.DicimalNN;
                    FlxInv.Cols[12].Format = VarGeneral.DicimalNN;
                    FlxInv.Cols[31].Format = VarGeneral.DicimalNN;
                    FlxInv.Cols[38].Format = VarGeneral.DicimalNN;
                    FlxInv.Cols[35].Format = VarGeneral.DicimalNN;
                }
                catch
                {
                }
            }

            try
            {
                if (_InvSetting.InvpRINTERInfo.ISA4PaperType)
                {
                    ChkA4Cahir.Text = "Csh";
                }
                else
                {
                    ChkA4Cahir.Text = "A4";
                }
                if (VarGeneral.TString.ChkStatShow(Permmission.PeaperTyp, 3))
                {
                    ChkA4Cahir.Checked = true;
                }
            }
            catch
            {
            }
            FlxInv.DrawMode = DrawModeEnum.OwnerDraw;
            FlxInv.OwnerDrawCell += _ownerDraw;
            if (File.Exists(Application.StartupPath + "\\Script\\SecriptMaintenanceCars.dll"))
            {
                label18.Visible = false;
                CmbLegate.Visible = false;
            }
            if (File.Exists(Application.StartupPath + "\\Script\\SecriptBus.dll"))
            {
                label15.Text = ((LangArEn == 0) ? "الباص : " : "Bus :");
                label18.Text = ((LangArEn == 0) ? "السائق :" : "Driver :");
            }
            if (File.Exists(Application.StartupPath + "\\Script\\SecriptTegnicalCollage.dll"))
            {
                TegnicalCollage();
            }
            if (File.Exists(Application.StartupPath + "\\Script\\SecriptWaterPackages.dll"))
            {
                label15.Text = ((LangArEn == 0) ? "السيارة : " : "Car :");
                label18.Text = ((LangArEn == 0) ? "العميــــل :" : "Customer :");
            }
            checkoversaved();
            if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 85))
            {
                switchButton_Lock.Visible = false;
            }
        }
        private void TegnicalCollage()
        {
            label18.Visible = false;
            CmbLegate.Visible = false;
            labelD1.Visible = false;
            labelD2.Visible = false;
            labelD3.Visible = false;
            labelC1.Visible = false;
            labelC2.Visible = false;
            labelC3.Visible = false;
            button_CustD1.Visible = false;
            button_CustD2.Visible = false;
            button_CustD3.Visible = false;
            button_CustC1.Visible = false;
            button_CustC2.Visible = false;
            button_CustC3.Visible = false;
            txtDebit1.Visible = false;
            txtDebit2.Visible = false;
            txtDebit3.Visible = false;
            txtCredit1.Visible = false;
            txtCredit2.Visible = false;
            txtCredit3.Visible = false;
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
                ExportExcel.ExportToExcel(DGV_Main, "تقرير فواتير مرتجع مشتريات");
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
                    item.ItmAddCost,
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
            panel.Columns["ItmAddCost"].HeaderText = ((LangArEn == 0) ? "تكلفة إضافية" : "Other Cost");
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
            _InvSetting = db.StockInvSetting( VarGeneral.InvTyp);
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
                    GetInvSetting();
                    FlxInv.Rows.Count = VarGeneral.Settings_Sys.LineOfInvoices.Value;
                    State = FormState.New;
                    AutoGaidAcc();
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
            UpdateVcr();
            if (State == FormState.Saved)
            {
                button_Repetition.Enabled = true;
                Button_PrintTableMulti.Enabled = true;
            }
            else
            {
                button_Repetition.Enabled = false;
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
        private void txtGDate_Click(object sender, EventArgs e)
        {
            txtGDate.SelectAll();
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
                    _InvSetting = db.StockInvSetting( VarGeneral.InvTyp);
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
                    label28.Visible = true;
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
                    label28.Visible = true;
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
                    if (_ItmBarCod.InvPaymentReturnStoped.Value)
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
        private void FrmInvPuchaesReturn_KeyUp(object sender, KeyEventArgs e)
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
                label28.Visible = false;
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
                label28.Visible = false;
            }
        }
        private void FlxInv_Click(object sender, EventArgs e)
        {
            Button_Edit_Click(sender, e);
            if (File.Exists(Application.StartupPath + "\\Script\\SecriptColDisPurchaesReturn.dll") || (VarGeneral.gUserName == "runsetting" && File.Exists(Application.StartupPath + "\\Script\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\SecriptColDisPurchaesReturn.dll")) || File.Exists(Application.StartupPath + "\\Script\\SecriptColDisPurchaesReturnValue.dll") || (VarGeneral.gUserName == "runsetting" && File.Exists(Application.StartupPath + "\\Script\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\SecriptColDisPurchaesReturnValue.dll")))
            {
                return;
            }
            try
            {
                if (FlxInv.Row > 0 && FlxInv.Col == 37 && VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 66))
                {
                    FlxInv.BeforeEdit -= FlxInv_BeforeEdit;
                    int vRowIndex = FlxInv.Row;
                    FrmInvDetNoteSrch frm = new FrmInvDetNoteSrch();
                    frm.Tag = LangArEn;
                    try
                    {
                        frm.textbox_Detailes.Text = FlxInv.GetData(vRowIndex, 37).ToString() ?? string.Empty;
                    }
                    catch
                    {
                        frm.textbox_Detailes.Text = string.Empty;
                    }
                    frm.TopMost = true;
                    frm.ShowDialog();
                    if (frm.SerachNo != string.Empty)
                    {
                        FlxInv.SetData(vRowIndex, 37, string.Empty);
                        FlxInv.SetData(vRowIndex, 37, FlxInv.GetData(vRowIndex, 37).ToString() + frm.SerachNo);
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
        private void FillCombo()
        {
            int _CmbIndex = CmbInvPrice.SelectedIndex;
            CmbInvPrice.Items.Clear();
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
            {
                CmbInvPrice.Items.Add(string.Empty);
                CmbInvPrice.Items.Add("آخر تكلفة");
                CmbInvPrice.Items.Add("متوسط التكلفة");
                CmbInvPrice.Items.Add("التكلفة الأفتتاحية");
                CmbInvPrice.Items.Add("أول تكلفة");
            }
            else
            {
                CmbInvPrice.Items.Add(string.Empty);
                CmbInvPrice.Items.Add("Last Cost");
                CmbInvPrice.Items.Add("Average Cost");
                CmbInvPrice.Items.Add("Open Cost");
                CmbInvPrice.Items.Add("First Cost");
            }
            CmbInvPrice.SelectedIndex = _CmbIndex;
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
            _CmbIndex = CmbLegate.SelectedIndex;
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
        }
        public void SetData(T_INVHED value)
        {
            try
            {
                text_CusTaxNo.Text = value.CusVenTaxNo;
                txtCrn_No.Text = value.CusVenCRN;
                switchButton_Lock.ValueChanged -= switchButton_Lock_ValueChanged;
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
                if (!RepetitionSts && !ReverseSts)
                {
                    switchButton_Lock.Value = value.AdminLock.GetValueOrDefault();
                    try
                    {
                        if (data_this.AdminLock.HasValue)
                        {
                            if (!data_this.AdminLock.GetValueOrDefault())
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
                if (VarGeneral.SSSLev == "M")
                {
                    txtCustNo.Text = string.Empty;
                }
                txtAddress.Text = value.CusVenAdd;
                txtTele.Text = value.CusVenTel;
                txtRemark.Text = value.Remark;
                txtDiscountP.Value = value.InvDisPrs.GetValueOrDefault();
                txtDiscountVal.Value = value.InvDisVal.GetValueOrDefault();
                txtDiscountValLoc.Value = value.InvDisValLocCur.GetValueOrDefault();
                txtTotCost.Value = value.InvAddCost.GetValueOrDefault();
                txtTotCostLoc.Value = value.InvAddCostLoc.GetValueOrDefault();
                txtTotCostExtrnal.Value = value.InvAddCostExtrnal.GetValueOrDefault();
                txtTotCostLocExtrnal.Value = value.InvAddCostExtrnalLoc.GetValueOrDefault();
                txtDebit4.Text = string.Empty;
                txtCredit4.Text = string.Empty;
                if (value.IsExtrnalGaid.HasValue)
                {
                    checkBox_CostGaid.Checked = value.IsExtrnalGaid.GetValueOrDefault();
                }
                else
                {
                    checkBox_CostGaid_CheckedChanged(null, null);
                }
                if (value.ExtrnalCostGaidID.HasValue)
                {
                    listGdHeadCost = db.StockGdHeadid((int)value.ExtrnalCostGaidID.GetValueOrDefault());
                    if (listGdHeadCost.Count != 0)
                    {
                        _GdHeadCost = listGdHeadCost[0];
                        listGdDetCost = _GdHeadCost.T_GDDETs.ToList();
                        for (int i = 0; i < listGdDetCost.Count; i++)
                        {
                            if (listGdDetCost[i].gdValue > 0.0)
                            {
                                txtDebit4.Tag = listGdDetCost[i].AccNo;
                                txtDebit4.Text = ((LangArEn == 0) ? db.SelectAccRootByCode(listGdDetCost[i].AccNo).Arb_Des : db.SelectAccRootByCode(listGdDetCost[i].AccNo).Eng_Des);
                            }
                            else
                            {
                                txtCredit4.Tag = listGdDetCost[i].AccNo;
                                txtCredit4.Text = ((LangArEn == 0) ? db.SelectAccRootByCode(listGdDetCost[i].AccNo).Arb_Des : db.SelectAccRootByCode(listGdDetCost[i].AccNo).Eng_Des);
                            }
                        }
                    }
                    else
                    {
                        _GdHeadCost = new T_GDHEAD();
                    }
                }
                txtDueAmount.Value = value.InvNet.GetValueOrDefault();
                txtDueAmountLoc.Value = value.InvNetLocCur.GetValueOrDefault();
                txtRef.Text = value.RefNo;
                if (value.IfPrint.Value == 1)
                {
                    switch_Cost.Value = true;
                }
                else
                {
                    switch_Cost.Value = false;
                }
                if (value.IfTrans.Value == 1)
                {
                    checkBox_CostLocal.Checked = true;
                }
                else
                {
                    checkBox_CostLocal.Checked = false;
                }
                txtTotalAm.Value = value.InvTot.GetValueOrDefault();
                txtTotalAmLoc.Value = value.InvTotLocCur.GetValueOrDefault();
                txtTotalQ.Value = value.InvQty.GetValueOrDefault();
                txtCustNet.Value = value.CustNet.GetValueOrDefault();
                txtCustRep.Value = value.CustRep.GetValueOrDefault();
                for (int iiCnt = 0; iiCnt < CmbCostC.Items.Count; iiCnt++)
                {
                    CmbCostC.SelectedIndex = iiCnt;
                    if (CmbCostC.SelectedValue != null && CmbCostC.SelectedValue.ToString() == value.InvCstNo.GetValueOrDefault().ToString())
                    {
                        break;
                    }
                }
                for (int iiCnt = 0; iiCnt < CmbCurr.Items.Count; iiCnt++)
                {
                    CmbCurr.SelectedIndex = iiCnt;
                    if (CmbCurr.SelectedValue != null && CmbCurr.SelectedValue.ToString() == value.CurTyp.GetValueOrDefault().ToString())
                    {
                        break;
                    }
                }
                if (CmbCurr.SelectedIndex != -1)
                {
                    RateValue = db.StockCurencyID(int.Parse(CmbCurr.SelectedValue.ToString())).Rate.GetValueOrDefault();
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
                    listGdHead = db.StockGdHeadid((int)value.GadeId.GetValueOrDefault());
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
                if (value.IsTaxUse.GetValueOrDefault())
                {
                    switchButton_Tax.Value = true;
                }
                else
                {
                    switchButton_Tax.Value = false;
                }
                switchButton_Tax.ValueChanged += switchButton_Tax_ValueChanged;
                switchButton_TaxLines.ValueChanged -= switchButton_TaxLines_ValueChanged;
                if (value.IsTaxLines.GetValueOrDefault())
                {
                    switchButton_TaxLines.Value = true;
                }
                else
                {
                    switchButton_TaxLines.Value = false;
                }
                if (value.IsTaxByTotal.GetValueOrDefault())
                {
                    switchButton_TaxByTotal.Value = true;
                }
                else
                {
                    switchButton_TaxByTotal.Value = false;
                }
                if (value.IsTaxByNet.GetValueOrDefault())
                {
                    switchButton_TaxByNet.Value = true;
                }
                else
                {
                    switchButton_TaxByNet.Value = false;
                }
                textBoxItem_TaxByNetValue.Text = value.TaxByNetValue.GetValueOrDefault().ToString();
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
                    listGdHeadCostTax = db.StockGdHeadid((int)value.TaxGaidID.GetValueOrDefault());
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
                txtTotDis.Value = value.InvValGaidDis.GetValueOrDefault();
                txtTotDisLoc.Value = value.InvValGaidDislLoc.GetValueOrDefault();
                switchButton_Dis.ValueChanged -= switchButton_Dis_ValueChanged;
                if (value.IsDisUse1.GetValueOrDefault())
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
                    listGdHeadCostDis = db.StockGdHeadid((int)value.DisGaidID1.GetValueOrDefault());
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
                FlxInv.Cols[36].Visible = false;
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
                        FlxInv.Cols[36].Visible = true;
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
                    try
                    {
                        FlxInv.SetData(iiCnt, "RSPH", _InvDet.RSph.GetValueOrDefault());

                        FlxInv.SetData(iiCnt, "RCYL", _InvDet.RCyl.GetValueOrDefault());

                        FlxInv.SetData(iiCnt, "RAXIS", _InvDet.RAxis.GetValueOrDefault());
                        FlxInv.SetData(iiCnt, "RADD", _InvDet.RAdd_.GetValueOrDefault());
                        FlxInv.SetData(iiCnt, "RIPD", _InvDet.RIPD.GetValueOrDefault());

                        FlxInv.SetData(iiCnt, "LSPH", _InvDet.LSph.GetValueOrDefault());

                        FlxInv.SetData(iiCnt, "LCYL", _InvDet.LCyl.GetValueOrDefault()); ;
                        FlxInv.SetData(iiCnt, "LAXIS", _InvDet.LAxis.GetValueOrDefault());
                        FlxInv.SetData(iiCnt, "LADD", _InvDet.LAdd_.GetValueOrDefault());
                        FlxInv.SetData(iiCnt, "LIPD", _InvDet.LIPD.GetValueOrDefault()); ;
                    }
                    catch
                    {

                    }
                    FlxInv.SetData(iiCnt, 32, _InvDet.ItmTyp.Value);
                    FlxInv.SetData(iiCnt, 31, _InvDet.ItmAddCost);
                    FlxInv.SetData(iiCnt, 38, _InvDet.Amount.Value);
                    FlxInv.SetData(iiCnt, 36, _InvDet.RunCod.Trim());
                    FlxInv.SetData(iiCnt, 37, _InvDet.LineDetails.Trim());
                    FlxInv.SetData(iiCnt, 35, _InvDet.ItmTax.Value);
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
        public void SetDataRt(T_INVHED value)
        {
            switchButton_Lock.ValueChanged -= switchButton_Lock_ValueChanged;
            ButReturn.Tag = value.InvHed_ID.ToString();
            txtCustNo.Text = value.CusVenNo.ToString();
            try
            {
                text_CusTaxNo.Text = value.CusVenTaxNo;
                txtCrn_No.Text = value.CusVenCRN;
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
            txtAddress.Text = value.CusVenAdd;
            txtTele.Text = value.CusVenTel;
            txtRemark.Text = value.Remark;
            txtDiscountP.Value = value.InvDisPrs.Value;
            txtDiscountVal.Value = value.InvDisVal.Value;
            txtDiscountValLoc.Value = value.InvDisValLocCur.Value;
            txtTotCost.Value = value.InvAddCost.Value;
            txtTotCostLoc.Value = value.InvAddCostLoc.Value;
            txtTotCostExtrnal.Value = value.InvAddCostExtrnal.Value;
            txtTotCostLocExtrnal.Value = value.InvAddCostExtrnalLoc.Value;
            if (value.IsExtrnalGaid.HasValue)
            {
                checkBox_CostGaid.Checked = value.IsExtrnalGaid.Value;
            }
            else
            {
                checkBox_CostGaid_CheckedChanged(null, null);
            }
            if (value.ExtrnalCostGaidID.HasValue)
            {
                listGdHeadCost = db.StockGdHeadid((int)value.ExtrnalCostGaidID.Value);
                if (listGdHeadCost.Count != 0)
                {
                    _GdHeadCost = listGdHeadCost[0];
                    listGdDetCost = _GdHeadCost.T_GDDETs.ToList();
                    for (int i = 0; i < listGdDetCost.Count; i++)
                    {
                        if (listGdDetCost[i].gdValue < 0.0)
                        {
                            txtDebit4.Tag = listGdDetCost[i].AccNo;
                            txtDebit4.Text = ((LangArEn == 0) ? db.SelectAccRootByCode(listGdDetCost[i].AccNo).Arb_Des : db.SelectAccRootByCode(listGdDetCost[i].AccNo).Eng_Des);
                        }
                        else
                        {
                            txtCredit4.Tag = listGdDetCost[i].AccNo;
                            txtCredit4.Text = ((LangArEn == 0) ? db.SelectAccRootByCode(listGdDetCost[i].AccNo).Arb_Des : db.SelectAccRootByCode(listGdDetCost[i].AccNo).Eng_Des);
                        }
                    }
                }
                else
                {
                    _GdHeadCost = new T_GDHEAD();
                }
            }
            txtDueAmount.Value = value.InvNet.Value;
            txtDueAmountLoc.Value = value.InvNetLocCur.Value;
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
            if (value.IfPrint.Value == 1)
            {
                switch_Cost.Value = true;
            }
            else
            {
                switch_Cost.Value = false;
            }
            if (value.IfTrans.Value == 1)
            {
                checkBox_CostLocal.Checked = true;
            }
            else
            {
                checkBox_CostLocal.Checked = false;
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
                    if (value.InvCash == "الشبكة" || value.InvCash == "شبكـــة") checkBox_NetWork.Checked = true; else checkBox_Chash.Checked = true;
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
                FlxInv.Cols[36].Visible = false;
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
                        FlxInv.Cols[36].Visible = true;
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
                    FlxInv.SetData(iiCnt, 31, _InvDet.ItmAddCost);
                    FlxInv.SetData(iiCnt, 38, _InvDet.Amount.Value);
                    FlxInv.SetData(iiCnt, 36, _InvDet.RunCod.Trim());
                    FlxInv.SetData(iiCnt, 37, _InvDet.LineDetails.Trim());
                    FlxInv.SetData(iiCnt, 35, _InvDet.ItmTax.Value);
                    try
                    {
                        FlxInv.SetData(iiCnt, "RSPH", _InvDet.RSph.GetValueOrDefault());

                        FlxInv.SetData(iiCnt, "RCYL", _InvDet.RCyl.GetValueOrDefault());

                        FlxInv.SetData(iiCnt, "RAXIS", _InvDet.RAxis.GetValueOrDefault());
                        FlxInv.SetData(iiCnt, "RADD", _InvDet.RAdd_.GetValueOrDefault());
                        FlxInv.SetData(iiCnt, "RIPD", _InvDet.RIPD.GetValueOrDefault());

                        FlxInv.SetData(iiCnt, "LSPH", _InvDet.LSph.GetValueOrDefault());

                        FlxInv.SetData(iiCnt, "LCYL", _InvDet.LCyl.GetValueOrDefault()); ;
                        FlxInv.SetData(iiCnt, "LAXIS", _InvDet.LAxis.GetValueOrDefault());
                        FlxInv.SetData(iiCnt, "LADD", _InvDet.LAdd_.GetValueOrDefault());
                        FlxInv.SetData(iiCnt, "LIPD", _InvDet.LIPD.GetValueOrDefault()); ;
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
                MessageBox.Show((LangArEn == 0) ? "لا يمكن حفظ فاتورة آجلة بدون رقم حساب المورد" : "Can not save without the Supplier's account number.", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                txtCustNo.Focus();
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
            }
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
                if (FlxInv.Cols[27].Visible)
                {
                    if (!VarGeneral.TString.ChkStatShow(VarGeneral.UserPassQty, 7) && VarGeneral.CheckDate(string.Concat(FlxInv.GetData(iiCnt, 27))) && string.Concat(FlxInv.GetData(iiCnt, 36)) == string.Empty)
                    {
                        MessageBox.Show((LangArEn == 0) ? "لا يمكن حفظ تاريخ الصلاحية بدون رقم التصنيع .. الرجاء مراجعة صلاحيات المستخدم" : "Can not save the expiration date without Make No .. please see User Permissions", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        FlxInv.Row = iiCnt;
                        FlxInv.Col = 36;
                        FlxInv.Focus();
                        return false;
                    }
                    if (!VarGeneral.TString.ChkStatShow(VarGeneral.UserPassQty, 8) && !VarGeneral.CheckDate(string.Concat(FlxInv.GetData(iiCnt, 27))) && string.Concat(FlxInv.GetData(iiCnt, 36)) != string.Empty)
                    {
                        MessageBox.Show((LangArEn == 0) ? "لا يمكن حفظ رقم التصنيع بدون تاريخ الصلاحية .. الرجاء مراجعة صلاحيات المستخدم" : "Can not save the Make No without expiration date .. please see User Permissions", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        FlxInv.Row = iiCnt;
                        FlxInv.Col = 27;
                        FlxInv.Focus();
                        return false;
                    }
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
            if (checkBox_CostGaid.Checked && txtTotCostLocExtrnal.Value <= 0.0)
            {
                MessageBox.Show((LangArEn == 0) ? "لايمكن انشاء سند محاسبي للتكلفة الخارجية واجمالي التكلفة يساوي صفر" : "You can not set up an accounting support external cost and the total cost is equal to zero.", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                superTabControl_Info.SelectedTabIndex = 4;
                return false;
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
                        MessageBox.Show((LangArEn == 0) ? "لا يمكن إتمام العملية .. وذلك لأن حساب المورد غير مصرح له الشراء بالنقدي " : "Can not complete the operation .. This is because the Supplier's account is not authorized to Cash purchase", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        return false;
                    }
                }
                else if (q.StopInvTyp == 2 && checkBox_Credit.Checked)
                {
                    MessageBox.Show((LangArEn == 0) ? "لا يمكن إتمام العملية .. وذلك لأن حساب المورد غير مصرح له الشراء بالآجل " : "Can not complete the operation .. This is because the Supplier's account is not authorized to Future purchase", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
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
#pragma warning disable CS0162 // Unreachable code detected
                Environment.Exit(0);
#pragma warning restore CS0162 // Unreachable code detected
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
#pragma warning disable CS0162 // Unreachable code detected
                return false; if (SystemInformation.TerminalServerSession)
#pragma warning restore CS0162 // Unreachable code detected
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
            string AccCrdt_Cost = string.Empty;
            string AccDbt_Cost = string.Empty;
            string AccCrdt_Cost_Tax = string.Empty;
            string AccDbt_Cost_Tax = string.Empty;
            try
            {
                AccCrdt_Cost = txtCredit4.Tag.ToString();
            }
            catch
            {
                AccCrdt_Cost = string.Empty;
            }
            try
            {
                AccDbt_Cost = txtDebit4.Tag.ToString();
            }
            catch
            {
                AccDbt_Cost = string.Empty;
            }
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
            if (checkBox_CostGaid.Checked && (string.IsNullOrEmpty(AccDbt_Cost) || string.IsNullOrEmpty(AccCrdt_Cost)))
            {
                MessageBox.Show((LangArEn == 0) ? "لا يمكن إتمام العملية .. تأكد من صحة حسابات الدائن والمدين الخاص بالتكلفة الخارجية " : "You can not complete the operation ..verify the accounts of the private creditor and the debtor Foreign cost", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                superTabControl_Info.SelectedTabIndex = 4;
                return false;
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
            if (data_this.ExtrnalCostGaidID.HasValue && !checkBox_CostGaid.Checked)
            {
                db_.StartTransaction();
                db_.ClearParameters();
                db_.AddParameter("gdhead_ID", DbType.Int32, _GdHeadCost.gdhead_ID);
                db_.ExecuteNonQueryWithoutCommit(storedProcedure: true, "S_T_GDHEAD_DELETE");
                db_.EndTransaction();
                data_this.ExtrnalCostGaidID = null;
            }
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

                        data_this.InvHed_ID = InvHelper.INVHED_INSERT(data_this);
                        savingoccure = 1;
                    }
                    catch (SqlException ex4)
                    {
                        try
                        {
                            VarGeneral.DebLog.writeLog("SaveData:", ex4, enable: true);
                        }
                        catch
                        {
                        }
                        string max = string.Empty;
                        dbInstance = null;
                        max = db.MaxInvheadNo.ToString();
                        if (ex4.Number == 2627)
                        {
                            MessageBox.Show("الرمز مستخدم من قبل.\n سيتم الحفظ برقم جديد [" + max + "]", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            textBox_ID.Text = max ?? string.Empty;
                            data_this.InvNo = max ?? string.Empty;
                            Button_Save_Click(null, null);
                        }
                    }
                    catch (Exception ex3)
                    {
                        try
                        {
                            VarGeneral.DebLog.writeLog("SaveData2:", ex3, enable: true);
                        }
                        catch
                        {
                        }
                        return false;
                    }
                }
                else
                {
                    data_this.SalsManNam = VarGeneral.UserNumber;

                    InvHelper.INVHED_Update(data_this);
                                     for (int i = 0; i < data_this.T_INVDETs.Count; i++)
                    {
                        db_.ClearParameters();
                        db_.AddParameter("InvDet_ID", DbType.Int32, data_this.T_INVDETs[i].InvDet_ID);
                        db_.ExecuteNonQuery(storedProcedure: true, "S_T_INVDET_DELETE");
                    }
                }
                int iiCnt = 0;
                try
                {
                    for (iiCnt = 1; iiCnt < FlxInv.Rows.Count; iiCnt++)
                    {
                        if (FlxInv.GetData(iiCnt, 1) != null)
                        {
                            db_.ClearParameters();
                        T_INVDET    dp=new T_INVDET();
                            InvHelper.ConvertsetDbParameter(dp,"InvDet_ID", DbType.Int32, 0);
                            InvHelper.ConvertsetDbParameter(dp,"InvNo", DbType.String, textBox_ID.Text.Trim());
                            InvHelper.ConvertsetDbParameter(dp,"InvId", DbType.Int32, data_this.InvHed_ID);
                            InvHelper.ConvertsetDbParameter(dp,"InvSer", DbType.Int32, iiCnt);
                            InvHelper.ConvertsetDbParameter(dp,"ItmNo", DbType.String, string.Concat(FlxInv.GetData(iiCnt, 1)));
                            InvHelper.ConvertsetDbParameter(dp,"Cost", DbType.Double, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 10)))));
                            InvHelper.ConvertsetDbParameter(dp,"Qty", DbType.Double, 0.0 - double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 7)))));
                            InvHelper.ConvertsetDbParameter(dp,"ItmDes", DbType.String, string.Concat(FlxInv.GetData(iiCnt, 2)));
                            InvHelper.ConvertsetDbParameter(dp,"ItmUnt", DbType.String, string.Concat(FlxInv.GetData(iiCnt, 3)));
                            InvHelper.ConvertsetDbParameter(dp,"ItmDesE", DbType.String, string.Concat(FlxInv.GetData(iiCnt, 4)));
                            InvHelper.ConvertsetDbParameter(dp,"ItmUntE", DbType.String, string.Concat(FlxInv.GetData(iiCnt, 5)));
                            InvHelper.ConvertsetDbParameter(dp,"ItmUntPak", DbType.Double, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 11)))));
                            InvHelper.ConvertsetDbParameter(dp,"StoreNo", DbType.Int32, int.Parse(VarGeneral.TString.TEmpty(FlxInv.GetData(iiCnt, 6).ToString() ?? string.Empty)));
                            InvHelper.ConvertsetDbParameter(dp,"Price", DbType.Double, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 8)))));
                            InvHelper.ConvertsetDbParameter(dp,"Amount", DbType.Double, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 38)))));
                            InvHelper.ConvertsetDbParameter(dp,"RealQty", DbType.Double, 0.0 - double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 12)))));
                            InvHelper.ConvertsetDbParameter(dp,"itmInvDsc", DbType.Double, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 13)))));
                            if (VarGeneral.CheckDate(string.Concat(FlxInv.GetData(iiCnt, 27))))
                            {
                                InvHelper.ConvertsetDbParameter(dp,"DatExper", DbType.String, string.Concat(FlxInv.GetData(iiCnt, 27)));
                            }
                            else
                            {
                                InvHelper.ConvertsetDbParameter(dp,"DatExper", DbType.String, string.Empty);
                            }
                            InvHelper.ConvertsetDbParameter(dp,"ItmDis", DbType.Double, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 9)))));
                            InvHelper.ConvertsetDbParameter(dp,"ItmAddCost", DbType.Double, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 31)))));
                            InvHelper.ConvertsetDbParameter(dp,"ItmTyp", DbType.Int32, int.Parse("0" + FlxInv.GetData(iiCnt, 32)));
                            InvHelper.ConvertsetDbParameter(dp,"ItmIndex", DbType.Int32, 0);
                            try
                            {
                                InvHelper.ConvertsetDbParameter(dp,"ItmWight", DbType.Double, ((bool)FlxInv.GetData(iiCnt, 33)) ? 1 : 0);
                            }
                            catch
                            {
                                InvHelper.ConvertsetDbParameter(dp,"ItmWight", DbType.Double,(double) 0);
                            }
                            InvHelper.ConvertsetDbParameter(dp,"ItmWight_T", DbType.Double, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 34)))));
                            if (!string.IsNullOrEmpty(string.Concat(FlxInv.GetData(iiCnt, 36))))
                            {
                                InvHelper.ConvertsetDbParameter(dp,"RunCod", DbType.String, string.Concat(FlxInv.GetData(iiCnt, 36)));
                            }
                            else
                            {
                                InvHelper.ConvertsetDbParameter(dp,"RunCod", DbType.String, string.Empty);
                            }
                            InvHelper.ConvertsetDbParameter(dp,"LineDetails", DbType.String, string.Concat(FlxInv.GetData(iiCnt, 37)));
                              InvHelper.ConvertsetDbParameter(dp,"ItmTax", DbType.Double,double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 35)))));
                            InvHelper.INVDET_INSERT(dp);
                        }
                    }
                }
                catch (Exception ex3)
                {
                    VarGeneral.DebLog.writeLog("LinesInv_Save_InvPuchaesReturn:", ex3, enable: true);
                    MessageBox.Show(ex3.Message);
                    return false;
                }
                if ((txtPaymentLoc.Value > 0.0 && !string.IsNullOrEmpty(AccCrdt) && !string.IsNullOrEmpty(AccDbt)) || (doubleInput_NetWorkLoc.Value > 0.0 && !string.IsNullOrEmpty(AccCrdt_NewtWork) && !string.IsNullOrEmpty(AccDbt_NetWork)) || (doubleInput_CreditLoc.Value > 0.0 && !string.IsNullOrEmpty(AccCrdt_Credit) && !string.IsNullOrEmpty(AccDbt_Credit)))
                {
                    Stock_DataDataContext dbc = new Stock_DataDataContext(VarGeneral.BranchCS);
                    if (State == FormState.New || _GdHead.gdhead_ID == 0)
                    {
                        GetDataGd();
                        _GdHead.DATE_CREATED = DateTime.Now;
                        dbc.T_GDHEADs.InsertOnSubmit(_GdHead);
                        dbc.SubmitChanges();
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
                            dbc.T_GDHEADs.InsertOnSubmit(_GdHead);
                            dbc.SubmitChanges();
                        }
                        else
                        {
                            db.Log = VarGeneral.DebugLog;
                            db.SubmitChanges(ConflictMode.ContinueOnConflict);
                        }
                        for (int i = 0; i < _GdHead.T_GDDETs.Count; i++)
                        {
                            db_.StartTransaction();
                            db_.ClearParameters();
                            db_.AddParameter("GDDET_ID", DbType.Int32, _GdHead.T_GDDETs[i].GDDET_ID);
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
                        db_.AddParameter("gdDes", DbType.String, "قيد تلقائي لفاتورة مرتجع مشتريات رقم : " + textBox_ID.Text);
                        db_.AddParameter("gdDesE", DbType.String, "Auto Bound To Puchase Return Invoice No : " + textBox_ID.Text);
                        db_.AddParameter("recptTyp", DbType.String, "4");
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
                        db_.AddParameter("gdDes", DbType.String, "قيد تلقائي لفاتورة مرتجع مشتريات رقم : " + textBox_ID.Text);
                        db_.AddParameter("gdDesE", DbType.String, "Auto Bound To Puchase Return Invoice No : " + textBox_ID.Text);
                        db_.AddParameter("recptTyp", DbType.String, "4");
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
                        db_.AddParameter("gdDes", DbType.String, "قيد تلقائي لفاتورة مرتجع مشتريات رقم : " + textBox_ID.Text);
                        db_.AddParameter("gdDesE", DbType.String, "Auto Bound To Puchase Return Invoice No : " + textBox_ID.Text);
                        db_.AddParameter("recptTyp", DbType.String, "4");
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
                        db_.AddParameter("gdDes", DbType.String, "قيد تلقائي لفاتورة مرتجع مشتريات رقم : " + textBox_ID.Text);
                        db_.AddParameter("gdDesE", DbType.String, "Auto Bound To Puchase Return Invoice No : " + textBox_ID.Text);
                        db_.AddParameter("recptTyp", DbType.String, "4");
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
                        db_.AddParameter("gdDes", DbType.String, "قيد تلقائي لفاتورة مرتجع مشتريات رقم : " + textBox_ID.Text);
                        db_.AddParameter("gdDesE", DbType.String, "Auto Bound To Puchase Return Invoice No : " + textBox_ID.Text);
                        db_.AddParameter("recptTyp", DbType.String, "4");
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
                        db_.AddParameter("gdDes", DbType.String, "قيد تلقائي لفاتورة مرتجع مشتريات رقم : " + textBox_ID.Text);
                        db_.AddParameter("gdDesE", DbType.String, "Auto Bound To Puchase Return Invoice No : " + textBox_ID.Text);
                        db_.AddParameter("recptTyp", DbType.String, "4");
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
                    data_thisRe.IfRet = 1;
                    data_thisRe.DeleteTime = data_this.InvHed_ID.ToString();
                    dbReturn.Log = VarGeneral.DebugLog;
                    dbReturn.SubmitChanges(ConflictMode.ContinueOnConflict);
                }
                superTabControl_Info.SelectedTabIndex = 0;
                if (checkBox_CostGaid.Checked && !string.IsNullOrEmpty(txtDebit4.Tag.ToString()) && !string.IsNullOrEmpty(txtCredit4.Tag.ToString()) && txtTotCostLocExtrnal.Value > 0.0)
                {
                    CreateCostGaid(AccCrdt_Cost, AccDbt_Cost);
                }
                if (checkBox_CostGaidTax.Checked && !string.IsNullOrEmpty(txtDebit5.Tag.ToString()) && !string.IsNullOrEmpty(txtCredit5.Tag.ToString()) && txtTotTax.Value > 0.0)
                {
                    CreateCostGaidTax(AccCrdt_Cost_Tax, AccDbt_Cost_Tax);
                }
                if (checkBox_GaidDis.Checked && !string.IsNullOrEmpty(txtDebit6.Tag.ToString()) && !string.IsNullOrEmpty(txtCredit6.Tag.ToString()) && txtTotDis.Value > 0.0)
                {
                    CreateCostGaidDis(AccCrdt_Cost_Dis, AccDbt_Cost_Dis);
                }
            }
            catch (Exception ex3)
            {
                MessageBox.Show(ex3.Message);
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
                db_.AddParameter("gdDes", DbType.String, "سند بقيمة الخصم لفاتورة مرتجع مشتريات رقم : " + textBox_ID.Text);
                db_.AddParameter("gdDesE", DbType.String, "Discount Value To Puchase Return Invoice No : " + textBox_ID.Text);
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
                db_.AddParameter("gdDes", DbType.String, "سند بقيمة الخصم لفاتورة مرتجع مشتريات رقم : " + textBox_ID.Text);
                db_.AddParameter("gdDesE", DbType.String, "Discount Value To Puchase Return Invoice No : " + textBox_ID.Text);
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
                db_.AddParameter("gdDes", DbType.String, "سند بقيمة الضريبة لفاتورة مرتجع مشتريات رقم : " + textBox_ID.Text);
                db_.AddParameter("gdDesE", DbType.String, "Tax Value To Puchase Return Invoice No : " + textBox_ID.Text);
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
                db_.AddParameter("gdDes", DbType.String, "سند بقيمة الضريبة لفاتورة مرتجع مشتريات رقم : " + textBox_ID.Text);
                db_.AddParameter("gdDesE", DbType.String, "Tax Value To Puchase Return Invoice No : " + textBox_ID.Text);
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
        private void CreateCostGaid(string AccCrdt_Cost, string AccDbt_Cost)
        {
            IDatabase db_ = Database.GetDatabase(VarGeneral.BranchCS);
            using (Stock_DataDataContext dbc = new Stock_DataDataContext(VarGeneral.BranchCS))
            {
                _GdHeadCost = new T_GDHEAD();
                if (!data_this.ExtrnalCostGaidID.HasValue)
                {
                    GetDataGdCost();
                    _GdHeadCost.DATE_CREATED = DateTime.Now;
                    dbc.T_GDHEADs.InsertOnSubmit(_GdHeadCost);
                    dbc.SubmitChanges();
                }
                else
                {
                    _GdHeadCost = dbc.StockGdHeadid((int)data_this.ExtrnalCostGaidID.Value).First();
                    GetDataGdCost();
                    dbc.Log = VarGeneral.DebugLog;
                    dbc.SubmitChanges(ConflictMode.ContinueOnConflict);
                    for (int i = 0; i < _GdHeadCost.T_GDDETs.Count; i++)
                    {
                        db_.StartTransaction();
                        db_.ClearParameters();
                        db_.AddParameter("GDDET_ID", DbType.Int32, _GdHeadCost.T_GDDETs[i].GDDET_ID);
                        db_.ExecuteNonQueryWithoutCommit(storedProcedure: true, "S_T_GDDET_DELETE");
                        db_.EndTransaction();
                    }
                }
                db_.StartTransaction();
                db_.ClearParameters();
                db_.AddParameter("GDDET_ID", DbType.Int32, 0);
                db_.AddParameter("gdID", DbType.Int32, _GdHeadCost.gdhead_ID);
                db_.AddParameter("gdNo", DbType.String, textBox_ID.Text);
                db_.AddParameter("gdDes", DbType.String, "سند تكلفة خارجية لفاتورة مرتجع مشتريات رقم : " + textBox_ID.Text);
                db_.AddParameter("gdDesE", DbType.String, "External Cost To Puchase Return Invoice No : " + textBox_ID.Text);
                db_.AddParameter("recptTyp", DbType.String, "1");
                db_.AddParameter("AccNo", DbType.String, AccCrdt_Cost);
                db_.AddParameter("AccName", DbType.String, string.Empty);
                db_.AddParameter("gdValue", DbType.Double, 0.0 - txtTotCostLocExtrnal.Value);
                db_.AddParameter("recptNo", DbType.String, textBox_ID.Text);
                db_.AddParameter("Lin", DbType.Int32, 1);
                db_.AddParameter("AccNoDestruction", DbType.String, null);
                db_.ExecuteNonQueryWithoutCommit(storedProcedure: true, "S_T_GDDET_INSERT");
                db_.EndTransaction();
                db_.StartTransaction();
                db_.ClearParameters();
                db_.AddParameter("GDDET_ID", DbType.Int32, 0);
                db_.AddParameter("gdID", DbType.Int32, _GdHeadCost.gdhead_ID);
                db_.AddParameter("gdNo", DbType.String, textBox_ID.Text);
                db_.AddParameter("gdDes", DbType.String, "سند تكلفة خارجية لفاتورة مرتجع مشتريات رقم : " + textBox_ID.Text);
                db_.AddParameter("gdDesE", DbType.String, "External Cost To Puchase Return Invoice No : " + textBox_ID.Text);
                db_.AddParameter("recptTyp", DbType.String, "1");
                db_.AddParameter("AccNo", DbType.String, AccDbt_Cost);
                db_.AddParameter("AccName", DbType.String, string.Empty);
                db_.AddParameter("gdValue", DbType.Double, txtTotCostLocExtrnal.Value);
                db_.AddParameter("recptNo", DbType.String, textBox_ID.Text);
                db_.AddParameter("Lin", DbType.Int32, 2);
                db_.AddParameter("AccNoDestruction", DbType.String, null);
                db_.ExecuteNonQueryWithoutCommit(storedProcedure: true, "S_T_GDDET_INSERT");
                db_.EndTransaction();
            }
            dbInstance = null;
            textBox_ID_TextChanged(null, null);
            data_this.ExtrnalCostGaidID = _GdHeadCost.gdhead_ID;
            db.Log = VarGeneral.DebugLog;
            db.SubmitChanges(ConflictMode.ContinueOnConflict);
        }
        private T_INVHED GetData()
        {
            data_this.CusVenTaxNo = text_CusTaxNo.Text;
            data_this.CusVenCRN = txtCrn_No.Text;
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
            if (State == FormState.New && VarGeneral.TString.ChkStatShow(VarGeneral.UserPassQty, 10))
            {
                data_this.AdminLock = true;
            }
            else
            {
                data_this.AdminLock = switchButton_Lock.Value;
            }
            data_this.IfEnter = 0;
            data_this.PaymentOrderTyp = 0;
            data_this.EstDat = string.Empty;
            data_this.InvCashPayNm = string.Empty;
            data_this.DeleteDate = string.Empty;
            data_this.DeleteTime = string.Empty;
            data_this.CommMnd_Inv = 0.0;
            data_this.MndExtrnal = false;
            data_this.CusVenNm = txtCustName.Text;
            data_this.CusVenNo = txtCustNo.Text;
            data_this.CusVenAdd = txtAddress.Text;
            data_this.CusVenTel = txtTele.Text;
            data_this.Remark = txtRemark.Text;
            data_this.InvNo = textBox_ID.Text;
            data_this.CashPay = txtPaymentLoc.Value;
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
            data_this.InvAddCost = txtTotCost.Value;
            data_this.InvAddCostLoc = txtTotCostLoc.Value;
            data_this.InvAddCostExtrnal = txtTotCostExtrnal.Value;
            data_this.InvAddCostExtrnalLoc = txtTotCostLocExtrnal.Value;
            data_this.IsExtrnalGaid = checkBox_CostGaid.Checked;
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
            data_this.RefNo = txtRef.Text;
            if (switch_Cost.Value)
            {
                data_this.IfPrint = 1;
            }
            else
            {
                data_this.IfPrint = 0;
            }
            if (checkBox_CostLocal.Checked)
            {
                data_this.IfTrans = 1;
            }
            else
            {
                data_this.IfTrans = 0;
            }
            if (switch_Cost.Value)
            {
                data_this.IfPrint = 1;
            }
            else
            {
                data_this.IfPrint = 0;
            }
            listCurency = db.Fillcurency_2(string.Empty).ToList();
            if (listCurency.Count > 0)
            {
                _Curency = listCurency[0];
            }
            data_this.ArbTaf = ScriptNumber1.ScriptNum(decimal.Parse(VarGeneral.TString.TEmpty(txtDueAmountLoc.Text ?? string.Empty))) + " " +_Curency.Arb_Des;;
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
            data_this.RoomNo = 1;
            data_this.OrderTyp = 1;
            data_this.RoomSts = false;
            data_this.RoomPerson = 1;
            data_this.ServiceValue = 0.0;
            data_this.Sts = false;
            data_this.chauffeurNo = null;
            data_this.tailor20 = "0";
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
            data_this.DesPointsValue = 0.0;
            data_this.DesPointsValueLocCur = 0.0;
            data_this.PointsCount = 0.0;
            data_this.IsPoints = false;
            return data_this;
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
            _GdHead.AdminLock = switchButton_Lock.Value;
            _GdHead.gdRcptID = (_GdHead.gdRcptID.HasValue ? _GdHead.gdRcptID.Value : 0.0);
            _GdHead.gdTot = txtDueAmountLoc.Value;
            _GdHead.gdTp = (_GdHead.gdTp!=0? _GdHead.gdTp : 0);
            _GdHead.gdTyp = VarGeneral.InvTyp;
            _GdHead.RefNo = txtRef.Text;
            _GdHead.DATE_MODIFIED = DateTime.Now;
            _GdHead.salMonth = string.Empty;
            _GdHead.gdUser = VarGeneral.UserNumber;
            _GdHead.gdUserNam = VarGeneral.UserNameA;
            _GdHead.CompanyID = 1;
            return _GdHead;
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
            _GdHeadCostDis.gdTp = (_GdHeadCostDis.gdTp!=0? _GdHeadCostDis.gdTp : 0);
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
            _GdHeadCostTax.gdTp = (_GdHeadCostTax.gdTp!=0? _GdHeadCostTax.gdTp : 0);
            _GdHeadCostTax.gdTyp = VarGeneral.InvTyp;
            _GdHeadCostTax.RefNo = txtRef.Text;
            _GdHeadCostTax.DATE_MODIFIED = DateTime.Now;
            _GdHeadCostTax.salMonth = string.Empty;
            _GdHeadCostTax.gdUser = VarGeneral.UserNumber;
            _GdHeadCostTax.gdUserNam = VarGeneral.UserNameA;
            _GdHeadCostTax.CompanyID = 1;
            return _GdHeadCostTax;
        }
        private T_GDHEAD GetDataGdCost()
        {
            _GdHeadCost.gdHDate = txtHDate.Text;
            _GdHeadCost.gdGDate = txtGDate.Text;
            _GdHeadCost.gdNo = textBox_ID.Text;
            _GdHeadCost.ArbTaf = ScriptNumber1.ScriptNum(decimal.Parse("0" + txtTotCostLocExtrnal.Text));
            _GdHeadCost.BName = _GdHeadCost.BName;
            _GdHeadCost.ChekNo = _GdHeadCost.ChekNo;
            _GdHeadCost.CurTyp = int.Parse(CmbCurr.SelectedValue.ToString());
            _GdHeadCost.EngTaf = ScriptNumber1.TafEng(decimal.Parse("0" + txtTotCostLocExtrnal.Text));
            _GdHeadCost.gdCstNo = int.Parse(CmbCostC.SelectedValue.ToString());
            _GdHeadCost.gdID = 0;
            _GdHeadCost.gdLok = false;
            _GdHeadCost.AdminLock = switchButton_Lock.Value;
            _GdHeadCost.gdMem = "سند تكلفة خارجي|External Cost";
            if (CmbLegate.SelectedIndex > 0)
            {
                _GdHeadCost.gdMnd = int.Parse(CmbLegate.SelectedValue.ToString());
            }
            else
            {
                _GdHeadCost.gdMnd = null;
            }
            _GdHeadCost.gdRcptID = (_GdHeadCost.gdRcptID.HasValue ? _GdHeadCost.gdRcptID.Value : 0.0);
            _GdHeadCost.gdTot = txtTotCostLocExtrnal.Value;
            _GdHeadCost.gdTp = (_GdHeadCost.gdTp!=0? _GdHeadCost.gdTp : 0);
            _GdHeadCost.gdTyp = VarGeneral.InvTyp;
            _GdHeadCost.RefNo = txtRef.Text;
            _GdHeadCost.DATE_MODIFIED = DateTime.Now;
            _GdHeadCost.salMonth = string.Empty;
            _GdHeadCost.gdUser = VarGeneral.UserNumber;
            _GdHeadCost.gdUserNam = VarGeneral.UserNameA;
            _GdHeadCost.CompanyID = 1;
            return _GdHeadCost;
        }
        private void FlxInv_BeforeEdit(object sender, RowColEventArgs e)
        {
            if ((e.Col == 3 || e.Col == 5) && FlxInv.GetData(e.Row, e.Col) != null)
            {
                oldUnit = FlxInv.GetData(e.Row, e.Col).ToString() ?? string.Empty;
            }
            try
            {
                if (!File.Exists(Application.StartupPath + "\\Script\\SecriptColDisPurchaesReturn.dll") && (!(VarGeneral.gUserName == "runsetting") || !File.Exists(Application.StartupPath + "\\Script\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\SecriptColDisPurchaesReturn.dll")) && !File.Exists(Application.StartupPath + "\\Script\\SecriptColDisPurchaesReturnValue.dll") && (!(VarGeneral.gUserName == "runsetting") || !File.Exists(Application.StartupPath + "\\Script\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\SecriptColDisPurchaesReturnValue.dll")) && FlxInv.Col == 37 && VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 66))
                {
                    FlxInv.BeforeEdit -= FlxInv_BeforeEdit;
                    int vRowIndex = FlxInv.Row;
                    FrmInvDetNoteSrch frm = new FrmInvDetNoteSrch();
                    frm.Tag = LangArEn;
                    try
                    {
                        frm.textbox_Detailes.Text = FlxInv.GetData(vRowIndex, 37).ToString() ?? string.Empty;
                    }
                    catch
                    {
                        frm.textbox_Detailes.Text = string.Empty;
                    }
                    frm.TopMost = true;
                    frm.ShowDialog();
                    if (frm.SerachNo != string.Empty)
                    {
                        FlxInv.SetData(vRowIndex, 37, string.Empty);
                        FlxInv.SetData(vRowIndex, 37, FlxInv.GetData(vRowIndex, 37).ToString() + frm.SerachNo);
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
        private void FlxInv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                FlxInv.RemoveItem(FlxInv.Row);
                GetInvTot();
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
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                {
                    txtItemName.Text = _Items.Arb_Des.Trim();
                }
                else
                {
                    txtItemName.Text = _Items.Eng_Des.Trim();
                }
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
                if (RowSel == 0 || RowSel == FlxInv.Row || FlxInv.Row <= 0 || !(string.Concat(FlxInv.GetData(FlxInv.Row, 1)) != string.Empty))
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
                txtVCost.Text = string.Concat(Math.Round((_Items.AvrageCost * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 11))))).Value / RateValue, VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2));
                txtLCost.Text = string.Concat(Math.Round((_Items.LastCost * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 11))))).Value / RateValue, VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2));
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
                FlxInv.SetData(FlxInv.Row, 27, FlxDat.GetData(FlxDat.Row, 0));
                FlxInv.SetData(FlxInv.Row, 24, FlxDat.GetData(FlxDat.Row, 1));
                FlxInv.SetData(FlxInv.Row, 36, FlxDat.GetData(FlxDat.Row, 2));
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
                FlxInv.SetData(FlxInv.Row, 36, FlxDat.GetData(FlxDat.Row, 2));
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
        private void BindDataOfItem()
        {
            columns_Names_visible2.Clear();
            columns_Names_visible2.Add("Itm_No", new ColumnDictinary("رقم الصنف", "Item No", ifDefault: true, string.Empty));
            columns_Names_visible2.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, string.Empty));
            columns_Names_visible2.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: false, string.Empty));
            columns_Names_visible2.Add("StartCost", new ColumnDictinary("التكلفةالافتتاحية", "Start Cost", ifDefault: false, string.Empty));
            columns_Names_visible2.Add("AvrageCost", new ColumnDictinary("متوسط التكلفة", "Average Cost", ifDefault: false, string.Empty));
            columns_Names_visible2.Add("LastCost", new ColumnDictinary("آخر تكلفة", "Last Cost", ifDefault: false, string.Empty));
            columns_Names_visible2.Add("Arb_Des_Cat", new ColumnDictinary("الاسم العربي لمجموعة الصنف", "CATEGORY Arabic Name", ifDefault: false, string.Empty));
            columns_Names_visible2.Add("Eng_Des_Cat", new ColumnDictinary("الاسم الانجليزي لمجموعة الصنف", "CATEGORY English Name", ifDefault: false, string.Empty));
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
                        if (listSer[0].InvPaymentReturnStoped.Value)
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
            else if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 30))
            {
                string _SearchNo = string.Empty;
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_Items ";
                string Fields = string.Empty;
                Fields = ((LangArEn != 0) ? " T_Items.Itm_No as [ID Number], T_Items.Itm_No as [Item No] , T_Items.Arb_Des as [Arabic Description], T_Items.Eng_Des as [English Description] , T_Items.OpenQty as [Quantity]  " : " T_Items.Itm_No as [رقم التعريف], T_Items.Itm_No as [رقــم الصنــــف] , T_Items.Arb_Des as [الوصــف العربـــي], T_Items.Eng_Des as [الوصــف إنجلـــيزي] , T_Items.OpenQty as [الكمية] ");
                _RepShow.Rule = " Where 1 = 1 and T_Items.ItmTyp != 2 and T_Items.ItmTyp != 3 and InvPaymentReturnStoped = 0 ";
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
                                  where t.ItmTyp != (int?)3 && t.ItmTyp != (int?)2 && !t.InvPaymentReturnStoped.Value
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
                VarGeneral.SFrmTyp = "T_InvGrid";
                VarGeneral.vItmTyp = 3;
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
                if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 30))
                {
                    string _SearchNo = string.Empty;
                    RepShow _RepShow = new RepShow();
                    _RepShow.Tables = " T_Items ";
                    string Fields = string.Empty;
                    Fields = ((LangArEn != 0) ? " T_Items.Itm_No as [ID Number], T_Items.Itm_No as [Item No] , T_Items.Arb_Des as [Arabic Description], T_Items.Eng_Des as [English Description] , T_Items.OpenQty as [Quantity]  " : " T_Items.Itm_No as [رقم التعريف], T_Items.Itm_No as [رقــم الصنــــف] , T_Items.Arb_Des as [الوصــف العربـــي], T_Items.Eng_Des as [الوصــف إنجلـــيزي] , T_Items.OpenQty as [الكمية] ");
                    _RepShow.Rule = " Where 1 = 1 and T_Items.ItmTyp != 2 and T_Items.ItmTyp != 3 and InvPaymentReturnStoped = 0";
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
                                      where t.ItmTyp != (int?)3 && t.ItmTyp != (int?)2 && !t.InvPaymentReturnStoped.Value
                                      orderby t.Itm_No
                                      select t).ToList();
                    if (q.Count == 0)
                    {
                        return;
                    }
                    FrmSearch FmSerch = new FrmSearch();
                    VarGeneral.SFrmTyp = "T_InvGrid";
                    VarGeneral.vItmTyp = 3;
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
                        FlxInv.SetData(FlxInv.Row, 8, _Items.LastCost * _Items.Pack1);
                        FlxInv.SetData(FlxInv.Row, 11, _Items.Pack1);
                    }
                    else if (DefPack == 1)
                    {
                        Pack = _Items.Pack1.Value;
                        DefUnitA = _Unit.Arb_Des;
                        DefUnitE = _Unit.Eng_Des;
                        FlxInv.SetData(FlxInv.Row, 8, _Items.LastCost * _Items.Pack1);
                        FlxInv.SetData(FlxInv.Row, 11, _Items.Pack1);
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
                        FlxInv.SetData(FlxInv.Row, 8, _Items.LastCost * _Items.Pack2);
                        FlxInv.SetData(FlxInv.Row, 11, _Items.Pack2);
                    }
                    else if (DefPack == 2)
                    {
                        Pack = _Items.Pack2.Value;
                        DefUnitA = _Unit.Arb_Des;
                        DefUnitE = _Unit.Eng_Des;
                        FlxInv.SetData(FlxInv.Row, 8, _Items.LastCost * _Items.Pack2);
                        FlxInv.SetData(FlxInv.Row, 11, _Items.Pack2);
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
                        FlxInv.SetData(FlxInv.Row, 8, _Items.LastCost * _Items.Pack3);
                        FlxInv.SetData(FlxInv.Row, 11, _Items.Pack3);
                    }
                    else if (DefPack == 3)
                    {
                        Pack = _Items.Pack3.Value;
                        DefUnitA = _Unit.Arb_Des;
                        DefUnitE = _Unit.Eng_Des;
                        FlxInv.SetData(FlxInv.Row, 8, _Items.LastCost * _Items.Pack3);
                        FlxInv.SetData(FlxInv.Row, 11, _Items.Pack3);
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
                        FlxInv.SetData(FlxInv.Row, 8, _Items.LastCost * _Items.Pack4);
                        FlxInv.SetData(FlxInv.Row, 11, _Items.Pack4);
                    }
                    else if (DefPack == 4)
                    {
                        Pack = _Items.Pack4.Value;
                        DefUnitA = _Unit.Arb_Des;
                        DefUnitE = _Unit.Eng_Des;
                        FlxInv.SetData(FlxInv.Row, 8, _Items.LastCost * _Items.Pack4);
                        FlxInv.SetData(FlxInv.Row, 11, _Items.Pack4);
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
                        FlxInv.SetData(FlxInv.Row, 8, _Items.LastCost * _Items.Pack5);
                        FlxInv.SetData(FlxInv.Row, 11, _Items.Pack5);
                    }
                    else if (DefPack == 5)
                    {
                        Pack = _Items.Pack5.Value;
                        DefUnitA = _Unit.Arb_Des;
                        DefUnitE = _Unit.Eng_Des;
                        FlxInv.SetData(FlxInv.Row, 8, _Items.LastCost * _Items.Pack5);
                        FlxInv.SetData(FlxInv.Row, 11, _Items.Pack5);
                    }
                    break;
                }
            }
            FlxInv.Cols[3].ComboList = CoA;
            FlxInv.Cols[5].ComboList = CoE;
#pragma warning disable CS0219 // The variable 'ItmPri' is assigned but its value is never used
            double ItmPri = 0.0;
#pragma warning restore CS0219 // The variable 'ItmPri' is assigned but its value is never used
            FlxInv.SetData(FlxInv.Row, 3, DefUnitA);
            FlxInv.SetData(FlxInv.Row, 5, DefUnitE);
            BindDataofItemPrice();
            FlxInv.SetData(FlxInv.Row, 10, _Items.AvrageCost / RateValue);
            txtVCost.Text = string.Concat(Math.Round((_Items.AvrageCost * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.Row, 11))))).Value / RateValue, VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2));
            txtVSerial.Text = _Items.SerialKey ?? string.Empty;
            FlxInv.SetData(FlxInv.Row, 30, _Items.LastCost * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.Row, 11)))) / RateValue);
            txtLCost.Text = string.Concat(Math.Round((_Items.LastCost * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.Row, 11))))).Value / RateValue, VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2));
            FlxInv.SetData(FlxInv.Row, 28, _Items.Lot);
            if (_Items.Lot == 1)
            {
                FlxInv.Cols[27].Visible = true;
                FlxInv.Cols[36].Visible = true;
            }
            FlxInv.SetData(FlxInv.Row, 32, _Items.ItmTyp);
            FlxInv.SetData(FlxInv.Row, 33, _Items.ItmLoc);
            FlxInv.SetData(FlxInv.Row, 18, _Items.DefPack);
            FlxInv.SetData(FlxInv.Row, 19, _Items.Price1);
            FlxInv.SetData(FlxInv.Row, 20, _Items.Price2);
            FlxInv.SetData(FlxInv.Row, 21, _Items.Price3);
            FlxInv.SetData(FlxInv.Row, 22, _Items.Price4);
            FlxInv.SetData(FlxInv.Row, 23, _Items.Price5);
            FlxInv.SetData(FlxInv.Row, 8, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.Row, 8)))) / RateValue);
            if (FlxInv.Cols[9].Visible)
            {
                FlxInv.SetData(FlxInv.Row, 9, _Items.ItemDis.Value);
            }
            else
            {
                FlxInv.SetData(FlxInv.Row, 9, 0);
            }
            FlxInv.SetData(FlxInv.Row, 31, 0);
            if (FlxInv.Cols[35].Visible)
            {
                FlxInv.SetData(FlxInv.Row, 35, VarGeneral.TString.ChkStatShow(_InvSetting.TaxOptions, 2) ? _Items.TaxPurchas : _Items.TaxSales);
            }
            else
            {
                FlxInv.SetData(FlxInv.Row, 35, 0);
            }
            try
            {
                if (File.Exists(Application.StartupPath + "\\Script\\SecriptColDisPurchaesReturn.dll") || (VarGeneral.gUserName == "runsetting" && File.Exists(Application.StartupPath + "\\Script\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\SecriptColDisPurchaesReturn.dll")))
                {
                    FlxInv.SetData(FlxInv.Row, 37, 0);
                }
            }
            catch
            {
            }
            try
            {
                if (File.Exists(Application.StartupPath + "\\Script\\SecriptColDisPurchaesReturnValue.dll") || (VarGeneral.gUserName == "runsetting" && File.Exists(Application.StartupPath + "\\Script\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\SecriptColDisPurchaesReturnValue.dll")))
                {
                    FlxInv.SetData(FlxInv.Row, 37, 0);
                }
            }
            catch
            {
            }
            PriceLoc = (double)FlxInv.GetData(FlxInv.Row, 8);
            BindDataOfStkQty(_Items.Itm_No.Trim());
            if (Barcod)
            {
                FlxInv.SetData(FlxInv.Row, 7, 1);
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
                    ItmAddTax = Math.Round(double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.Row, 8)))) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.Row, 35)))) / 100.0), VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2);
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
                    ItmAddTax = Math.Round((double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.Row, 8)))) - ItmDis) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.Row, 35)))) / 100.0), VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2);
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
            VarGeneral.Flush();
        }
        private void BindDataOfStkQty(string ItmNo)
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
                try
                {
                    if (FlxInv.GetData(iiCnt, 1).ToString() == FlxInv.GetData(FlxInv.RowSel, 1).ToString())
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
                    double ItmAdd = 0.0;
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
                        if ((File.Exists(Application.StartupPath + "\\Script\\SecriptColDisPurchaesReturn.dll") || (VarGeneral.gUserName == "runsetting" && File.Exists(Application.StartupPath + "\\Script\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\SecriptColDisPurchaesReturn.dll"))) && double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 37)))) > 0.0)
                        {
                            ItmDis += double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 8)))) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 37)))) / 100.0);
                        }
                    }
                    catch
                    {
                    }
                    try
                    {
                        if (File.Exists(Application.StartupPath + "\\Script\\SecriptColDisPurchaesReturnValue.dll") || (VarGeneral.gUserName == "runsetting" && File.Exists(Application.StartupPath + "\\Script\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\SecriptColDisPurchaesReturnValue.dll")))
                        {
                            ItmDis += double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 37))));
                        }
                    }
                    catch
                    {
                    }
                    ItmAdd = double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 31))));
                    ItmAddTax = Math.Round(double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 8)))) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 35)))) / 100.0), VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2);
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
                        FlxInv.SetData(iiCnt, 38, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 8)))) - ItmDis + ItmAdd + ItmAddTax);
                        if (switchButton_TaxByTotal.Value && switchButton_TaxLines.Value && double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 38)))) > 0.0)
                        {
                            ItmAddTax = Math.Round((double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 8)))) - ItmDis) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 35)))) / 100.0), VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2);
                            FlxInv.SetData(FlxInv.RowSel, 38, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 38)))) + ItmAddTax);
                        }
                        GetInvTot();
                        FlxInv.Row = FlxInv.RowSel;
                        FlxInv.Col = 0;
                    }
                    return true;
                }
            }
            return false;
        }
        private void BindDataofItemPrice()
        {
            if (CmbInvPrice.SelectedIndex == 1 && (int)_Items.LastCost.Value != 0)
            {
                FlxInv.SetData(FlxInv.Row, 8, _Items.LastCost.Value * Pack / RateValue);
            }
            else if (CmbInvPrice.SelectedIndex == 2 && (int)_Items.AvrageCost.Value != 0)
            {
                FlxInv.SetData(FlxInv.Row, 8, _Items.AvrageCost.Value * Pack / RateValue);
            }
            else if (CmbInvPrice.SelectedIndex == 3 && (int)_Items.StartCost.Value != 0)
            {
                FlxInv.SetData(FlxInv.Row, 8, _Items.StartCost.Value * Pack / RateValue);
            }
            else if (CmbInvPrice.SelectedIndex == 4 && (int)_Items.FirstCost.Value != 0)
            {
                FlxInv.SetData(FlxInv.Row, 8, _Items.FirstCost.Value * Pack / RateValue);
            }
        }
        private void FlxInv_AfterEdit(object sender, RowColEventArgs e)
        {
            double ItmDis = 0.0;
            double ItmAdd = 0.0;
            double ItmAddTax = 0.0;
            ItmDis = double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 8)))) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 9)))) / 100.0);
            try
            {
                if ((File.Exists(Application.StartupPath + "\\Script\\SecriptColDisPurchaesReturn.dll") || (VarGeneral.gUserName == "runsetting" && File.Exists(Application.StartupPath + "\\Script\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\SecriptColDisPurchaesReturn.dll"))) && double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 37)))) > 0.0)
                {
                    ItmDis += double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 8)))) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 37)))) / 100.0);
                }
            }
            catch
            {
            }
            try
            {
                if (File.Exists(Application.StartupPath + "\\Script\\SecriptColDisPurchaesReturnValue.dll") || (VarGeneral.gUserName == "runsetting" && File.Exists(Application.StartupPath + "\\Script\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\SecriptColDisPurchaesReturnValue.dll")))
                {
                    ItmDis += double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 37))));
                }
            }
            catch
            {
            }
            ItmAdd = double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 31))));
            ItmAddTax = Math.Round(double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 8)))) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 35)))) / 100.0), VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2);
            if (!switchButton_TaxLines.Value || switchButton_TaxByTotal.Value)
            {
                ItmAddTax = 0.0;
            }
            if (e.Col == 1)
            {
                BindDataOfItem();
            }
            else if (((e.Col == 2 || e.Col == 4) && (string)FlxInv.GetData(e.Row, 1) == string.Empty) || FlxInv.GetData(e.Row, 1) == null)
            {
                BindDataOfItem();
            }
            else if ((e.Col == 3 || e.Col == 5) && FlxInv.GetData(e.Row, e.Col).ToString() != oldUnit && FlxInv.GetData(e.Row, e.Col).ToString() != string.Empty)
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
                        FlxInv.SetData(FlxInv.Row, 8, _Items.LastCost * _Items.Pack1 / RateValue);
                        FlxInv.SetData(FlxInv.Row, 11, _Items.Pack1);
                        break;
                    case 2:
                        FlxInv.SetData(FlxInv.Row, 8, _Items.LastCost * _Items.Pack2 / RateValue);
                        FlxInv.SetData(FlxInv.Row, 11, _Items.Pack2);
                        break;
                    case 3:
                        FlxInv.SetData(FlxInv.Row, 8, _Items.LastCost * _Items.Pack3 / RateValue);
                        FlxInv.SetData(FlxInv.Row, 11, _Items.Pack3);
                        break;
                    case 4:
                        FlxInv.SetData(FlxInv.Row, 8, _Items.LastCost * _Items.Pack4 / RateValue);
                        FlxInv.SetData(FlxInv.Row, 11, _Items.Pack4);
                        break;
                    case 5:
                        FlxInv.SetData(FlxInv.Row, 8, _Items.LastCost * _Items.Pack5 / RateValue);
                        FlxInv.SetData(FlxInv.Row, 11, _Items.Pack5);
                        break;
                }
                Pack = ItemIndex;
                BindDataofItemPrice();
                FlxInv.SetData(e.Row, 12, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 11)))));
                FlxInv.SetData(e.Row, 38, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 8)))) - ItmDis + ItmAdd + ItmAddTax);
                if (switchButton_TaxByTotal.Value && switchButton_TaxLines.Value && double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 38)))) > 0.0)
                {
                    ItmAddTax = Math.Round((double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 8)))) - ItmDis) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 35)))) / 100.0), VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2);
                    FlxInv.SetData(e.Row, 38, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 38)))) + ItmAddTax);
                }
                PriceLoc = double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 8))));
                BindDataOfStkQty(FlxInv.GetData(e.Row, 1).ToString());
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
                        if ((File.Exists(Application.StartupPath + "\\Script\\SecriptColDisPurchaesReturn.dll") || (VarGeneral.gUserName == "runsetting" && File.Exists(Application.StartupPath + "\\Script\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\SecriptColDisPurchaesReturn.dll"))) && double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 37)))) > 0.0)
                        {
                            ItmDis += double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 8)))) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 37)))) / 100.0);
                        }
                    }
                    catch
                    {
                    }
                    try
                    {
                        if (File.Exists(Application.StartupPath + "\\Script\\SecriptColDisPurchaesReturnValue.dll") || (VarGeneral.gUserName == "runsetting" && File.Exists(Application.StartupPath + "\\Script\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\SecriptColDisPurchaesReturnValue.dll")))
                        {
                            ItmDis += double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 37))));
                        }
                    }
                    catch
                    {
                    }
                    ItmAdd = double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 31))));
                    ItmAddTax = Math.Round(double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 8)))) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 35)))) / 100.0), VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2);
                    if (!switchButton_TaxLines.Value || switchButton_TaxByTotal.Value)
                    {
                        ItmAddTax = 0.0;
                    }
                    FlxInv.SetData(e.Row, 38, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 8)))) - ItmDis + ItmAdd + ItmAddTax);
                    if (switchButton_TaxByTotal.Value && switchButton_TaxLines.Value && double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 38)))) > 0.0)
                    {
                        ItmAddTax = Math.Round((double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 8)))) - ItmDis) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 35)))) / 100.0), VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2);
                        FlxInv.SetData(e.Row, 38, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 38)))) + ItmAddTax);
                    }
                }
                catch
                {
                }
            }
            else if (e.Col == 6 && string.Concat(FlxInv.GetData(e.Row, 1)) != string.Empty)
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
            }
            else if (e.Col == 7 || e.Col == 8)
            {
                double RealQ = 0.0;
                RealQ = double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 11))));
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
                                    FlxInv.SetData(e.Row, 37, Math.Round(double.Parse(FlxInv.GetData(e.Row, e.Col).ToString()) / (((_Items.SecriptCeramicCombo == "0") ? _Items.Pack1.Value : ((_Items.SecriptCeramicCombo == "1") ? _Items.Pack2.Value : ((_Items.SecriptCeramicCombo == "2") ? _Items.Pack3.Value : ((_Items.SecriptCeramicCombo == "3") ? _Items.Pack4.Value : _Items.Pack5.Value)))) / (double)val_), VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2));
                                }
                            }
                        }
                    }
                    catch
                    {
                    }
                }
                FlxInv.SetData(e.Row, 12, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 11)))));
                FlxInv.SetData(e.Row, 38, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 8)))) - ItmDis + ItmAdd + ItmAddTax);
                if (switchButton_TaxByTotal.Value && switchButton_TaxLines.Value && double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 38)))) > 0.0)
                {
                    ItmAddTax = Math.Round((double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 8)))) - ItmDis) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 35)))) / 100.0), VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2);
                    FlxInv.SetData(e.Row, 38, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 38)))) + ItmAddTax);
                }
                chekReptItem(Col_1: false);
            }
            else if (e.Col == 9)
            {
                FlxInv.SetData(e.Row, 38, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 8)))) - ItmDis + ItmAdd + ItmAddTax);
                if (switchButton_TaxByTotal.Value && switchButton_TaxLines.Value && double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 38)))) > 0.0)
                {
                    ItmAddTax = Math.Round((double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 8)))) - ItmDis) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 35)))) / 100.0), VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2);
                    FlxInv.SetData(e.Row, 38, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 38)))) + ItmAddTax);
                }
            }
            else if (e.Col == 31)
            {
                FlxInv.SetData(e.Row, 38, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 8)))) - ItmDis + ItmAdd + ItmAddTax);
                if (switchButton_TaxByTotal.Value && switchButton_TaxLines.Value && double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 38)))) > 0.0)
                {
                    ItmAddTax = Math.Round((double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 8)))) - ItmDis) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 35)))) / 100.0), VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2);
                    FlxInv.SetData(e.Row, 38, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 38)))) + ItmAddTax);
                }
            }
            else if (e.Col == 38)
            {
                if (switchButton_TaxByTotal.Value && switchButton_TaxLines.Value && double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 38)))) > 0.0)
                {
                    ItmAddTax = Math.Round((double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 8)))) - ItmDis) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 35)))) / 100.0), VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2);
                }
                if (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 38)))) != double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 8)))) - ItmDis + ItmAddTax)
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
                        FlxInv.SetData(e.Row, 8, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 38)))) / double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7)))));
                        FlxInv.SetData(e.Row, 9, 0);
                        FlxInv.SetData(e.Row, 31, 0);
                    }
                }
                chekReptItem(Col_1: false);
            }
            else if (e.Col == 37)
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
                    if (File.Exists(Application.StartupPath + "\\Script\\SecriptColDisPurchaesReturn.dll") || (VarGeneral.gUserName == "runsetting" && File.Exists(Application.StartupPath + "\\Script\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\SecriptColDisPurchaesReturn.dll")))
                    {
                        FlxInv_AfterEdit(null, new RowColEventArgs(FlxInv.Row, 9));
                    }
                }
                catch
                {
                }
                try
                {
                    if (File.Exists(Application.StartupPath + "\\Script\\SecriptColDisPurchaesReturnValue.dll") || (VarGeneral.gUserName == "runsetting" && File.Exists(Application.StartupPath + "\\Script\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\SecriptColDisPurchaesReturnValue.dll")))
                    {
                        FlxInv_AfterEdit(null, new RowColEventArgs(FlxInv.Row, 9));
                    }
                }
                catch
                {
                }
            }
            else if (e.Col == 35)
            {
                FlxInv.SetData(e.Row, 38, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 8)))) - ItmDis + ItmAdd + ItmAddTax);
                if (switchButton_TaxByTotal.Value && switchButton_TaxLines.Value && double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 38)))) > 0.0)
                {
                    ItmAddTax = Math.Round((double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 8)))) - ItmDis) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 35)))) / 100.0), VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2);
                    FlxInv.SetData(e.Row, 38, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 38)))) + ItmAddTax);
                }
            }
            else if (e.Col == 33 && Convert.ToBoolean(FlxInv.GetData(e.Row, 33)))
            {
                ItmAddTax = 0.0;
                ItmDis = 0.0;
                ItmAdd = 0.0;
                FlxInv.SetData(e.Row, 8, 0);
                FlxInv.SetData(e.Row, 9, 0);
                FlxInv.SetData(e.Row, 35, 0);
                FlxInv.SetData(e.Row, 31, 0);
                FlxInv.SetData(e.Row, 38, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 8)))) - ItmDis + ItmAdd + ItmAddTax);
            }
            VarGeneral.Flush();
            GetInvTot();
        }
        private void ButReturn_Click(object sender, EventArgs e)
        {
            if (State != FormState.New)
            {
                return;
            }
            columns_Names_visible2.Clear();
            columns_Names_visible2.Add("InvNo", new ColumnDictinary("رقم الفاتورة", "Invoice No", ifDefault: true, string.Empty));
            columns_Names_visible2.Add("CusVenNm", new ColumnDictinary("إسم المورد", "Supplier Name", ifDefault: true, string.Empty));
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
            VarGeneral.SFrmTyp = "T_InvSalReturn";
            VarGeneral.InvTypRt = 2;
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != string.Empty)
            {
                T_INVHED newData = dbReturn.StockInvHead(2, frm.Serach_No);
                if (newData != null || !string.IsNullOrEmpty(newData.InvNo))
                {
                    State = FormState.Saved;
                    Clear();
                    DataThisRe = newData;
                    AutoGaidAcc();
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
                    checkBox_Credit_CheckedChanged(null, null);
                }
            }
        }
        double getround3(double m1, int p)
        {
            return Math.Round(m1, p);

        }
        private void GetInvTot()
        {
            double InvTot = 0.0;
            double InvCost = 0.0;
            double InvQty = 0.0;
            double InvDis = 0.0;
            double InvAdd = 0.0;
            double InvTax = 0.0;
            double ItmDisCount = 0.0;
            if (State == FormState.Saved)
            {
                return;
            }
            InvDis = double.Parse(VarGeneral.TString.TEmpty(txtDiscountVal.Text));
            for (int iiCnt = 1; iiCnt < FlxInv.Rows.Count; iiCnt++)
            {
                try
                {
                    InvTot += double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 38))));
                    InvAdd += double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 31))));
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
                        InvTax += (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 8)))) - DisVal) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 35)))) / 100.0);
                    }
                    else
                    {
                        InvTax += double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 8)))) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 35)))) / 100.0);
                    }
                    ItmDisCount += double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 8)))) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 9)))) / 100.0);
                    try
                    {
                        if ((File.Exists(Application.StartupPath + "\\Script\\SecriptColDisPurchaesReturn.dll") || (VarGeneral.gUserName == "runsetting" && File.Exists(Application.StartupPath + "\\Script\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\SecriptColDisPurchaesReturn.dll"))) && double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 37)))) > 0.0)
                        {
                            ItmDisCount += double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 8)))) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 37)))) / 100.0);
                        }
                    }
                    catch
                    {
                    }
                    try
                    {
                        if (File.Exists(Application.StartupPath + "\\Script\\SecriptColDisPurchaesReturnValue.dll") || (VarGeneral.gUserName == "runsetting" && File.Exists(Application.StartupPath + "\\Script\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\SecriptColDisPurchaesReturnValue.dll")))
                        {
                            ItmDisCount += double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 37))));
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
            txtTotalQ.Text = VarGeneral.TString.TEmpty(InvQty.ToString());
            txtInvCost.Text = VarGeneral.TString.TEmpty(Math.Round(InvCost, VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2).ToString());
            txtCustNet.Text = VarGeneral.TString.TEmpty(Math.Round(double.Parse(VarGeneral.TString.TEmpty(string.Concat(txtCustRep.Value))) + double.Parse(txtDueAmountLoc.Text), VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2).ToString());
            txtTotalAm.Text = VarGeneral.TString.TEmpty(Math.Round(InvTot * RateValue, VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2).ToString());
            txtTotalAmLoc.Text = VarGeneral.TString.TEmpty(Math.Round(InvTot, VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2).ToString());
            if (switch_Cost.Value)
            {
                txtDueAmount.Text = VarGeneral.TString.TEmpty(Math.Round((InvTot - InvDis) * RateValue, VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2).ToString());
            }
            else
            {
                txtDueAmount.Text = VarGeneral.TString.TEmpty(Math.Round((InvTot - InvAdd - InvDis) * RateValue, VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2).ToString());
            }
            if (switch_Cost.Value)
            {
                txtDueAmountLoc.Text = VarGeneral.TString.TEmpty(Math.Round(InvTot - InvDis, VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2).ToString());
            }
            else
            {
                txtDueAmountLoc.Text = VarGeneral.TString.TEmpty(Math.Round(InvTot - InvAdd - InvDis, VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2).ToString());
            }
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
                InvTax = ((!(Tax_Per <= 0.0) && !(txtDueAmountLoc.Value <= 0.0)) ? Math.Round(txtDueAmountLoc.Value * Tax_Per / 100.0, VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) : 0.0);
            }
            txtTotTax.Text = VarGeneral.TString.TEmpty(Math.Round(InvTax, VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2).ToString());
            txtTotTaxLoc.Text = VarGeneral.TString.TEmpty(Math.Round(InvTax * RateValue, VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2).ToString());
            if (switchButton_TaxLines.Value)
            {
                if (!switchButton_Tax.Value)
                {
                    txtDueAmount.Text = VarGeneral.TString.TEmpty(Math.Round((InvTot - InvTax - InvDis) * RateValue, VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2).ToString());
                }
                if (!switchButton_Tax.Value)
                {
                    txtDueAmountLoc.Text = VarGeneral.TString.TEmpty(Math.Round(InvTot - InvTax - InvDis, VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2).ToString());
                }
                if (switchButton_TaxByNet.Value && InvTax > 0.0)
                {
                    if (switchButton_Tax.Value)
                    {
                        txtDueAmount.Text = VarGeneral.TString.TEmpty(Math.Round((InvTot + InvTax - InvDis) * RateValue, VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2).ToString());
                    }
                    if (switchButton_Tax.Value)
                    {
                        txtDueAmountLoc.Text = VarGeneral.TString.TEmpty(Math.Round(InvTot + InvTax - InvDis, VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2).ToString());
                    }
                }
            }
            else
            {
                if (switchButton_Tax.Value)
                {
                    txtDueAmount.Text = VarGeneral.TString.TEmpty(Math.Round((InvTot + InvTax - InvDis) * RateValue, VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2).ToString());
                }
                if (switchButton_Tax.Value)
                {
                    txtDueAmountLoc.Text = VarGeneral.TString.TEmpty(Math.Round(InvTot + InvTax - InvDis, VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2).ToString());
                }
            }
            txtTotalAm.Value += txtTotCostLoc.Value;
            txtTotalAmLoc.Value += txtTotCost.Value;
            if (checkBox_CostLocal.Checked)
            {
                txtDueAmount.Value += txtTotCostLoc.Value;
                txtDueAmountLoc.Value += txtTotCost.Value;
            }
            txtTotDis.Value = (switchButton_Dis.Value ? (txtDiscountVal.Value + ItmDisCount) : txtDiscountVal.Value);
            txtTotDisLoc.Value = (switchButton_Dis.Value ? (txtDiscountValLoc.Value + ItmDisCount) : txtDiscountValLoc.Value);
            try
            {
                if (switchButton_Dis.Value && ItmDisCount > 0.0)
                {
                    txtTotalAm.Value += Math.Round(ItmDisCount * RateValue, VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2);
                    txtTotalAmLoc.Value += Math.Round(ItmDisCount, VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2);
                }
            }
            catch
            {
            }
            if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 56))
            {
                txtTotalAm.Value = getround3(txtTotalAm.Value, 0);
                txtDueAmount.Value = getround3(txtDueAmount.Value, 0);
                txtTotalAmLoc.Value = getround3(txtTotalAmLoc.Value, 0);
                txtDueAmountLoc.Value = getround3(txtDueAmountLoc.Value, 0);
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
                    txtTotCost_Leave(sender, e);
                    txtTotCostExtrnal_Leave(sender, e);
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
                             where item.repTyp == (int?)4
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
                                int xv = 50, y = 50;
                                try
                                {
                                    e.Graphics.PageUnit = GraphicsUnit.Millimeter;
                                    xv = (int)_mInvPrint.vSize.Value;
                                    y = xv / 2;
                                    xv = xv / 2;
                                }
                                catch
                                {

                                }

                                e.Graphics.DrawImage(byteArrayToImage(Utilites.qrcodeimage()), (int)_mInvPrint.vRow, (int)_mInvPrint.vCol, xv, y);


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
            string vInvH = " T_INVHED.InvHed_ID,T_INVHED.CusVenTaxNo ,T_INVHED.InvId as vID, T_INVHED.InvNo, T_INVHED.InvTyp, T_INVHED.InvCashPay, T_INVHED.CusVenNo,T_INVHED.CusVenMob as Mobile1,case when T_INVHED.CusVenNo = '' THEN T_INVHED.CusVenNm ELSE (select T_AccDef.Arb_Des from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as CusVenNm,case when T_INVHED.CusVenNo = '' THEN T_INVHED.CusVenNm ELSE (select T_AccDef.Eng_Des from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as CusVenNmE, T_INVHED.CusVenAdd, T_INVHED.CusVenTel, T_INVHED.Remark, T_INVHED.HDat, T_INVHED.GDat, T_INVHED.MndNo, T_INVHED.SalsManNo, T_INVHED.SalsManNam, T_INVHED.InvTot, T_INVHED.InvDisPrs, ((case when IsDisUse1 = 1 then T_INVHED.InvValGaidDis else T_INVHED.InvDisVal end) + T_INVHED.DesPointsValue) as InvDisVal,T_INVHED.InvDisVal as InvDisValOnly,T_INVHED.DesPointsValue,T_INVHED.DesPointsValueLocCur,T_INVHED.PointsCount,T_INVHED.IsPoints, T_INVHED.InvNet, T_INVHED.InvNetLocCur, T_INVHED.CashPayLocCur, T_INVHED.IfRet, T_INVHED.CashPay, T_INVHED.InvTotLocCur, T_INVHED.InvDisValLocCur, T_INVHED.GadeNo, T_INVHED.GadeId, T_INVHED.RetNo, T_INVHED.RetId, T_INVHED.InvCashPayNm, T_INVHED.InvCost, T_INVHED.CustPri, T_INVHED.ArbTaf, T_INVHED.ToStore, T_INVHED.InvCash, T_INVHED.CurTyp, T_INVHED.EstDat,case when DATEDIFF(day, GETDATE(), EstDat) > 0 Then DATEDIFF(day, GETDATE(), EstDat) WHEN DATEDIFF(day, GETDATE(), InvCashPayNm) > 0 THEN DATEDIFF(day, GETDATE(), InvCashPayNm) Else '0' END as EstDatNote, T_INVHED.InvCstNo, T_INVHED.IfDel, T_INVHED.RefNo, T_INVHED.ToStoreNm, T_INVHED.EngTaf, T_INVHED.IfTrans, T_INVHED.InvQty, T_INVHED.CustNet, T_INVHED.CustRep, T_INVHED.InvWight_T, T_INVHED.IfPrint, T_INVHED.LTim, T_INVHED.DATE_CREATED, T_INVHED.MODIFIED_BY, T_INVHED.CreditPay, T_INVHED.DATE_MODIFIED, T_INVHED.CREATED_BY, T_INVHED.CreditPayLocCur, T_INVHED.NetworkPay, T_INVHED.NetworkPayLocCur, T_INVHED.MndExtrnal, T_INVHED.CompanyID, T_INVHED.InvAddCost, T_INVHED.InvAddCostExtrnal, T_INVHED.InvAddCostExtrnalLoc, T_INVHED.IsExtrnalGaid, T_INVHED.ExtrnalCostGaidID, T_INVHED.InvAddCostLoc, T_INVHED.CommMnd_Inv, T_INVHED.Puyaid, T_INVHED.Remming,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select T_AccDef.PersonalNm from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as PersonalNm,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select T_AccDef.City from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as City,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select T_AccDef.Email from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as Email,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select T_AccDef.Mobile from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as Mobile,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select T_AccDef.Telphone1 from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as Telphone1,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select vColStr1 from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as CustAge,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select T_AccDef.Telphone2 from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as Telphone2,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select T_AccDef.Fax from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as Fax,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select T_AccDef.zipCod from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as zipCod,T_SYSSETTING.LineGiftlNameA,T_SYSSETTING.LineGiftlNameE,T_Curency.Arb_Des as CurrnceyNm,T_Curency.Eng_Des as CurrnceyNmE,(select max(gdDes)from T_GDDET where gdID = T_INVHED.GadeId )as gdDes, (T_INVDET.Amount - (case when T_INVHED.IsTaxLines = 1 then (case when T_INVHED.IsTaxByTotal = 1 then (case when (Abs(T_INVDET.Qty) *  T_INVDET.Price * T_INVDET.ItmTax / 100) > 0 then ((Abs(T_INVDET.Qty) *  T_INVDET.Price) - case when (Abs(T_INVDET.Qty) * T_INVDET.Price * T_INVDET.ItmDis / 100) > 0 then (Abs(T_INVDET.Qty) * T_INVDET.Price * T_INVDET.ItmDis / 100) else 0 end )* T_INVDET.ItmTax / 100   else 0 end) else (Abs(T_INVDET.Qty) *  T_INVDET.Price * T_INVDET.ItmTax / 100) end) else 0 end )) as TotBeforeTax,(select invGdADesc from T_INVSETTING where T_INVHED.InvTyp = T_INVSETTING.InvID ) as invGdADesc,(select invGdEDesc from T_INVSETTING where T_INVHED.InvTyp = T_INVSETTING.InvID ) as invGdEDesc,(select T_CATEGORY.CAT_No from T_CATEGORY where T_CATEGORY.CAT_ID = T_Items.ItmCat) as CAT_No,(select T_CATEGORY.Arb_Des from T_CATEGORY where T_CATEGORY.CAT_ID = T_Items.ItmCat) as CatNmA,(select T_CATEGORY.Eng_Des from T_CATEGORY where T_CATEGORY.CAT_ID = T_Items.ItmCat) as CatNmE,(case when (select t.BarCod1 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit1 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt )) != '' then (select t.BarCod1 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit1 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt ))  when (select t.BarCod2 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit2 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt )) != '' then (select t.BarCod2 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit2 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt )) when (select t.BarCod3 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit3 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt )) != '' then (select t.BarCod3 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit3 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt )) when (select t.BarCod4 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit4 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt )) != '' then (select t.BarCod4 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit4 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt )) when (select t.BarCod5 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit5 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt )) != '' then (select t.BarCod5 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit5 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt )) else T_Items.Itm_No  end) as ItmBarcod";
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
                            if (VarGeneral.RepData.Tables[0].Rows[i]["CusVenNo"].ToString() == "")
                            {
                                VarGeneral.RepData.Tables[0].Rows[i]["TaxCustNo"] = VarGeneral.RepData.Tables[0].Rows[i]["CusVenTaxNo"];

                            }

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

                T_AccDef h = db.StockAccDefsByAcNO(txtCustNo.Text);
                try
                {
                    text_Mobile.Text = h.Mobile;
                }
                catch { }
                try
                {

                    text_CusTaxNo.Text = h.TaxNo;
                }
                catch { }
            }
            else
            {
                txtCustName.ReadOnly = false;
                txtTele.ReadOnly = false;
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
        private void checkBox_CostGaid_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_CostGaid.Checked)
            {
                txtDebit4.Enabled = true;
                txtCredit4.Enabled = true;
                button_CustD4.Enabled = true;
                button_CustC4.Enabled = true;
            }
            else
            {
                txtDebit4.Enabled = false;
                txtCredit4.Enabled = false;
                button_CustD4.Enabled = false;
                button_CustC4.Enabled = false;
            }
        }
        private void txtTotCost_Leave(object sender, EventArgs e)
        {
            if (State != 0)
            {
                txtTotCostLoc.Value = txtTotCost.Value * RateValue;
                GetInvTot();
            }
        }
        private void txtTotCostExtrnal_Leave(object sender, EventArgs e)
        {
            if (State != 0)
            {
                txtTotCostLocExtrnal.Value = txtTotCostExtrnal.Value * RateValue;
                GetInvTot();
            }
        }
        private void button_AutoCost_Click(object sender, EventArgs e)
        {
            try
            {
                int vLine = 0;
                double vCost = 0.0;
                for (int iiCnt = 1; iiCnt < FlxInv.Rows.Count; iiCnt++)
                {
                    try
                    {
                        if (string.Concat(FlxInv.GetData(iiCnt, 1)) != string.Empty)
                        {
                            vLine++;
                        }
                    }
                    catch
                    {
                    }
                }
                if (vLine <= 0)
                {
                    return;
                }
                Button_Edit_Click(sender, e);
                vCost = ((!(txtTotCostExtrnal.Value > 0.0)) ? 0.0 : (txtTotCostExtrnal.Value / (double)vLine));
                for (int iiCnt = 1; iiCnt < FlxInv.Rows.Count; iiCnt++)
                {
                    try
                    {
                        if (string.Concat(FlxInv.GetData(iiCnt, 1)) != string.Empty)
                        {
                            FlxInv.SetData(iiCnt, 31, vCost);
                            FlxInv_AfterEdit(null, new RowColEventArgs(iiCnt, 31));
                        }
                    }
                    catch
                    {
                    }
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Load:", error, enable: true);
            }
        }
        private void txtTotCostExtrnal_ValueChanged(object sender, EventArgs e)
        {
            if (VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 18))
            {
                button_AutoCost.Visible = true;
            }
            else
            {
                button_AutoCost.Visible = false;
            }
        }
        private void switch_Cost_ValueChanged(object sender, EventArgs e)
        {
            GetInvTot();
        }
        private void checkBox_CostLocal_CheckedChanged(object sender, EventArgs e)
        {
            GetInvTot();
        }
        private void switchButton_Lock_Click(object sender, EventArgs e)
        {
            if (!switchButton_Lock.IsReadOnly)
            {
                if (data_this.AdminLock.Value && switchButton_Lock.Value && !CanEdit)
                {
                    CanEdit = true;
                }
                Button_Edit_Click(sender, e);
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
                double ItmAdd = 0.0;
                double ItmAddTax = 0.0;
                ItmDis = double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 8)))) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 9)))) / 100.0);
                try
                {
                    if ((File.Exists(Application.StartupPath + "\\Script\\SecriptColDisPurchaesReturn.dll") || (VarGeneral.gUserName == "runsetting" && File.Exists(Application.StartupPath + "\\Script\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\SecriptColDisPurchaesReturn.dll"))) && double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 37)))) > 0.0)
                    {
                        ItmDis += double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 8)))) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 37)))) / 100.0);
                    }
                }
                catch
                {
                }
                try
                {
                    if (File.Exists(Application.StartupPath + "\\Script\\SecriptColDisPurchaesReturnValue.dll") || (VarGeneral.gUserName == "runsetting" && File.Exists(Application.StartupPath + "\\Script\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\SecriptColDisPurchaesReturnValue.dll")))
                    {
                        ItmDis += double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 37))));
                    }
                }
                catch
                {
                }
                ItmAdd = double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 31))));
                ItmAddTax = Math.Round(double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 8)))) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 35)))) / 100.0), VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2);
                if (!switchButton_TaxLines.Value || switchButton_TaxByTotal.Value)
                {
                    ItmAddTax = 0.0;
                }
                FlxInv.SetData(iiCnt, 38, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 8)))) - ItmDis + ItmAdd + ItmAddTax);
                if (switchButton_TaxByTotal.Value && switchButton_TaxLines.Value && double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 38)))) > 0.0)
                {
                    ItmAddTax = Math.Round((double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 8)))) - ItmDis) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 35)))) / 100.0), VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2);
                    FlxInv.SetData(iiCnt, 38, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 38)))) + ItmAddTax);
                }
            }
            GetInvTot();
            txtDueAmountLoc_ValueChanged(sender, e);
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
                    ts = db.StockInvSetting( VarGeneral.DraftBillId);
                }
                catch { }
                if (ts.InvSet_ID == 0)
                {
                   ProShared. DBUdate.DbUpdates.adddraft();
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
        void checkoversaved()
        {
            int i = db.StockInvHeadSaveover(VarGeneral.InvTyp, VarGeneral.UserNo);
            if (i > 0)
                button_opendraft.Enabled = true;
            else
                button_opendraft.Enabled = false;
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
                   ProShared. DBUdate.DbUpdates.executes(dl, VarGeneral.BranchCS);
                    dl = "Delete From T_INVHED where InvTyp=" + VarGeneral.DraftBillId.ToString() + " AND InvHed_ID=" + frm.SerachNo.ToString() + " and SalsManNo = " + VarGeneral.UserNo;
                   ProShared. DBUdate.DbUpdates.executes(dl, VarGeneral.BranchCS);
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

                    data_this.InvHed_ID = InvHelper.INVHED_INSERT(data_this);
                }
#pragma warning disable CS0168 // The variable 'ex7' is declared but never used
                catch (SqlException ex7)
#pragma warning restore CS0168 // The variable 'ex7' is declared but never used
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
                T_INVDET dp = new T_INVDET(); InvHelper.ConvertsetDbParameter(dp, "InvDet_ID", DbType.Int32, 0);
                InvHelper.ConvertsetDbParameter(dp, "InvNo", DbType.String, textBox_ID.Text.Trim());
                InvHelper.ConvertsetDbParameter(dp, "InvId", DbType.Int32, data_this.InvHed_ID);
                InvHelper.ConvertsetDbParameter(dp, "InvSer", DbType.Int32, iiCnt);
                InvHelper.ConvertsetDbParameter(dp, "ItmNo", DbType.String, string.Concat(FlxInv.GetData(iiCnt, 1)));
                InvHelper.ConvertsetDbParameter(dp, "Cost", DbType.Double, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 10)))));
                InvHelper.ConvertsetDbParameter(dp, "Qty", DbType.Double, 0.0 - double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 7)))));
                InvHelper.ConvertsetDbParameter(dp, "ItmDes", DbType.String, string.Concat(FlxInv.GetData(iiCnt, 2)));
                InvHelper.ConvertsetDbParameter(dp, "ItmUnt", DbType.String, string.Concat(FlxInv.GetData(iiCnt, 3)));
                InvHelper.ConvertsetDbParameter(dp, "ItmDesE", DbType.String, string.Concat(FlxInv.GetData(iiCnt, 4)));
                InvHelper.ConvertsetDbParameter(dp, "ItmUntE", DbType.String, string.Concat(FlxInv.GetData(iiCnt, 5)));
                InvHelper.ConvertsetDbParameter(dp, "ItmUntPak", DbType.Double, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 11)))));
                InvHelper.ConvertsetDbParameter(dp, "StoreNo", DbType.Int32, int.Parse(VarGeneral.TString.TEmpty(FlxInv.GetData(iiCnt, 6).ToString() ?? string.Empty)));
                InvHelper.ConvertsetDbParameter(dp, "Price", DbType.Double, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 8)))));
                InvHelper.ConvertsetDbParameter(dp, "Amount", DbType.Double, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 38)))));
                InvHelper.ConvertsetDbParameter(dp, "RealQty", DbType.Double, 0.0 - double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 12)))));
                InvHelper.ConvertsetDbParameter(dp, "itmInvDsc", DbType.Double, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 13)))));
                if (VarGeneral.CheckDate(string.Concat(FlxInv.GetData(iiCnt, 27))))
                {
                    InvHelper.ConvertsetDbParameter(dp, "DatExper", DbType.String, string.Concat(FlxInv.GetData(iiCnt, 27)));
                }
                else
                {
                    InvHelper.ConvertsetDbParameter(dp, "DatExper", DbType.String, string.Empty);
                }
                InvHelper.ConvertsetDbParameter(dp, "ItmDis", DbType.Double, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 9)))));
                InvHelper.ConvertsetDbParameter(dp, "ItmAddCost", DbType.Double, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 31)))));
                InvHelper.ConvertsetDbParameter(dp, "ItmTyp", DbType.Int32, int.Parse("0" + FlxInv.GetData(iiCnt, 32)));
                InvHelper.ConvertsetDbParameter(dp, "ItmIndex", DbType.Int32, 0);
                try
                {
                    InvHelper.ConvertsetDbParameter(dp, "ItmWight", DbType.Double, ((bool)FlxInv.GetData(iiCnt, 33)) ? 1 : 0);
                }
                catch
                {
                    InvHelper.ConvertsetDbParameter(dp, "ItmWight", DbType.Double, (double)0);
                }
                InvHelper.ConvertsetDbParameter(dp, "ItmWight_T", DbType.Double, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 34)))));
                if (!string.IsNullOrEmpty(string.Concat(FlxInv.GetData(iiCnt, 36))))
                {
                    InvHelper.ConvertsetDbParameter(dp, "RunCod", DbType.String, string.Concat(FlxInv.GetData(iiCnt, 36)));
                }
                else
                {
                    InvHelper.ConvertsetDbParameter(dp, "RunCod", DbType.String, string.Empty);
                }
                InvHelper.ConvertsetDbParameter(dp, "LineDetails", DbType.String, string.Concat(FlxInv.GetData(iiCnt, 37)));
                InvHelper.ConvertsetDbParameter(dp, "ItmTax", DbType.Double, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 35)))));
                InvHelper.INVDET_INSERT(dp);
            }
        }
        private void ribbonBar1_ItemClick(object sender, EventArgs e)
        {
        }
        private void button_SrchCustNo_Click_1(object sender, EventArgs e)
        {
        }
        private void txtTele_TextChanged(object sender, EventArgs e)
        {
        }
        private void txtAddress_TextChanged(object sender, EventArgs e)
        {
        }
        private void CmbCostC_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        private void printersettings_Click(object sender, EventArgs e)
        {
             ProShared. DroBoxSync.Frm_PrinterShow f = new  ProShared. DroBoxSync.Frm_PrinterShow(VarGeneral.InvTyp);
            f.TopMost = true;
            f.ShowDialog();
                dbInstance = null;
            _InvSetting = db.StockPrinterSetting(VarGeneral.UserID, VarGeneral.InvTyp).InvInfo;
            buttonItem_Print.Text = (_InvSetting.ISdirectPrinting ? (LangArEn == 0 ? "طباعة" : "Print") : (LangArEn == 0 ? "عرض" : "Preview"));}
        private void superTabControlPanel3_Click(object sender, EventArgs e)
        {
        }
        private void txtDueAmountLoc_ValueChanged_1(object sender, EventArgs e)
        {
        }
        private void superTabControl1_RightToLeftChanged(object sender, EventArgs e)
        {
            superTabControl1.RightToLeftChanged -= superTabControl_Main1_RightToLeftChanged;
            superTabControl1.RightToLeft = RightToLeft.No;
            superTabControl1.RightToLeftChanged += superTabControl_Main1_RightToLeftChanged;
        }
        int kk = 0;
        private int savingoccure = 0;

        private void FlxInv_StartEdit(object sender, RowColEventArgs e)
        {
            kk = 1;
        }
        private void FlxInv_LeaveEdit(object sender, RowColEventArgs e)
        {
            kk = 0;
        }
    }
}
