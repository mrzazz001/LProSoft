using C1.Win.C1FlexGrid;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.DotNetBar.Metro;
using DevComponents.DotNetBar.Ribbon;
using DevComponents.DotNetBar.SuperGrid;
using DevComponents.DotNetBar.SuperGrid.Style;
using DevComponents.Editors;
using Framework.Data;
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
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial  class FrmWaiterMenue : Form
    { void avs(int arln)

{ 
 checkBox_NetWork.Text=   (arln == 0 ? "  شبكـــة  " : "  network") ; checkBox_Chash.Text=   (arln == 0 ? "  نقـــدي  " : "  cash") ; Label26.Text=   (arln == 0 ? "  قيمة الخصم  " : "  discount value") ; label8.Text=   (arln == 0 ? "  نسبة الخصم  " : "  discount percentage") ;   label9.Text=   (arln == 0 ? "  صافي الفاتورة :  " : "  net bill:") ; label17.Text=   (arln == 0 ? "  قيمة الفاتــورة :  " : "  Invoice value:") ; label3.Text=   (arln == 0 ? "  بالريــال  " : "  in riyals") ; superTabControl_Main1.Text=   (arln == 0 ? "  superTabControl3  " : "  superTabControl3") ; Button_Close.Text=   (arln == 0 ? "  إغلاق  " : "  Close") ; /*buttonItem_Print.Text=   (arln == 0 ? "  طباعة  " : "  Print") ;*/ Button_Search.Text=   (arln == 0 ? "  بحث  " : "  Search") ; Button_Delete.Text=   (arln == 0 ? "  حذف  " : "  delete") ; Button_Save.Text=   (arln == 0 ? "  حفظ  " : "  save") ; Button_Add.Text=   (arln == 0 ? "  إضافة  " : "  addition") ; buttonItem6.Text=   (arln == 0 ? "  العمــــــلاء  " : "  customers") ; lable_Records.Text=   (arln == 0 ? "  ---  " : "  ---") ; superTabControl_Main2.Text=   (arln == 0 ? "  superTabControl1  " : "  superTabControl1") ; Button_First.Text=   (arln == 0 ? "  الأول  " : "  the first") ; Button_Prev.Text=   (arln == 0 ? "  السابق  " : "  the previous") ; Button_Next.Text=   (arln == 0 ? "  التالي  " : "  next one") ; Button_Last.Text=   (arln == 0 ? "  الأخير  " : "  the last one") ; button_0.Text=   (arln == 0 ? "  0  " : "  0") ; button_2.Text=   (arln == 0 ? "  2  " : "  2") ; button_1.Text=   (arln == 0 ? "  1  " : "  1") ; button_6.Text=   (arln == 0 ? "  6  " : "  6") ; button_5.Text=   (arln == 0 ? "  5  " : "  5") ; button_8.Text=   (arln == 0 ? "  8  " : "  8") ; button_7.Text=   (arln == 0 ? "  7  " : "  7") ; button_Bac.Text=   (arln == 0 ? "  مسج  " : "  message") ; button_3.Text=   (arln == 0 ? "  3  " : "  3") ; button_4.Text=   (arln == 0 ? "  4  " : "  4") ; superGridControl1.Text=   (arln == 0 ? "  superGridControl1  " : "  superGridControl1") ; superTabControl_ItemsGrids.Text=   (arln == 0 ? "  superTabControl1  " : "  superTabControl1") ; btnPrevPage.Text=   (arln == 0 ? "  السابق  " : "  the previous") ; btnNxtPage.Text=   (arln == 0 ? "  التالي  " : "  next one") ; button_DeleteLine.Text=   (arln == 0 ? "  حذف السطر  " : "  delete line") ; button_Space.Text=   (arln == 0 ? "  Space  " : "  Space") ; button_9.Text=   (arln == 0 ? "  9  " : "  9") ; label10.Text=   (arln == 0 ? "  اسم العميـــــل :  " : "  Client name:") ; label4.Text=   (arln == 0 ? "  حساب العميــل :  " : "  Customer account:") ; label_Waiter.Text=   (arln == 0 ? "  إســــم النــــادل  " : "  Waiter's name") ; label12.Text=   (arln == 0 ? "  هاتف :  " : "  Telephone :") ; label5.Text=   (arln == 0 ? "  السعر المعتمــد :  " : "  Approved price:") ; label19.Text=   (arln == 0 ? "  العملــــــــة :  " : "  work:") ; label18.Text=   (arln == 0 ? "  المنـــــدوب :  " : "  The delegate:") ; label7.Text=   (arln == 0 ? "  رقم المرجع :  " : "  reference number :") ; Label2.Text=   (arln == 0 ? "  التاريــــــــخ :  " : "  date:") ; Label1.Text=   (arln == 0 ? "  رقم الطلب :  " : "  Order number :") ; superTabItem_Note.Text=   (arln == 0 ? "  ملاحظة  " : "  Notice") ; superTabControl_CostSts.Text=   (arln == 0 ? "  superTabControl3  " : "  superTabControl3") ; checkBox_CostGaidTax.Text=   (arln == 0 ? "  سند محاسبي  " : "  accounting document") ; label34.Text=   (arln == 0 ? "  الإجمالي  " : "  Total") ; label37.Text=   (arln == 0 ? "  بالريــــال  " : "  in riyals") ; superTabItem_Tax.Text=   (arln == 0 ? "  ضريبة  " : "  tax") ; label42.Text=   (arln == 0 ? "  الدائن :  " : "  creditor:") ; checkBox_GaidBankComm.Text=   (arln == 0 ? "  سند محاسبي  " : "  accounting document") ; label48.Text=   (arln == 0 ? "  إجمالي القيمة  " : "  Total value") ; label49.Text=   (arln == 0 ? "  بالريــــال  " : "  in riyals") ; label39.Text=   (arln == 0 ? "  الدائـــــن :  " : "  creditor:") ; label40.Text=   (arln == 0 ? "  المـــدين :  " : "  Debtor:") ; checkBox_GaidDis.Text=   (arln == 0 ? "  سند محاسبي  " : "  accounting document") ; label38.Text=   (arln == 0 ? "  إجمالي القيمة  " : "  Total value") ; label41.Text=   (arln == 0 ? "  بالريــــال  " : "  in riyals") ; labelItem_TaxByNetPer.Text=   (arln == 0 ? "  %  " : "  %") ; superTabItem_Gaids.Text=   (arln == 0 ? "  سندات  " : "  bonds") ; label11.Text=   (arln == 0 ? "  آجــــل :  " : "  deferred:") ; label6.Text=   (arln == 0 ? "  نقــــداّ :  " : "  cash:") ; label14.Text=   (arln == 0 ? "  شبكـة :  " : "  network:") ; superTabItem_Pay.Text=   (arln == 0 ? "  الدفع  " : "  paying off") ; checkBoxItem_BarCode.Text=   (arln == 0 ? "  إضافة تلقائية  " : "  auto add") ; txtTele.Text=   (arln == 0 ? "  .  " : "  .") ; txtRef.Text=   (arln == 0 ? "  .  " : "  .") ; label15.Text=   (arln == 0 ? "  مركز التكلفـــــة :  " : "  cost center:") ; label13.Text=   (arln == 0 ? "  عنوان العميـــل :  " : "  Customer address:") ; DGV_Main.Text=   (arln == 0 ? "    " : "    ") ; DGV_Main.Text=   (arln == 0 ? "  جميــع السجــــلات  " : "  All records") ; DGV_Main.Text=   (arln == 0 ? "    " : "    ") ; panelEx3.Text=   (arln == 0 ? "  Fill Panel  " : "  Fill Panel") ; superTabControl_DGV.Text=   (arln == 0 ? "  superTabControl1  " : "  superTabControl1") ; textBox_search.Text=   (arln == 0 ? "  ...  " : "  ...") ; Button_ExportTable2.Text=   (arln == 0 ? "  تصدير  " : "  Export") ; /*Button_PrintTable.Text=   (arln == 0 ? "  طباعة  " : "  Print") ; */panelEx2.Text=   (arln == 0 ? "  Click to collapse  " : "  Click to collapse") ; superTabStripORDER.Text=   (arln == 0 ? "  superTabStrip1  " : "  superTabStrip1") ; label31.Text=   (arln == 0 ? "  الكراسي  " : "  chairs") ; button_SrchTable.Text=   (arln == 0 ? "  الطاولات  " : "  the tables") ; button_AddToTable.Text=   (arln == 0 ? "  توجيه إلى  " : "  directing to") ; ToolStripMenuItem_Det.Text=   (arln == 0 ? "  إظهار التفاصيل  " : "  Show details") ; ToolStripMenuItem_Rep.Text=   (arln == 0 ? "  إظهار التقرير  " : "  Show report") ; Text = "الطلبات المحلية";this.Text=   (arln == 0 ? "  الطلبات المحلية  " : "  local orders") ;}
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
       // private IContainer components = null;
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData.ToString().Contains("Control") && !keyData.ToString().ToLower().Contains("delete") && keyData.ToString().Contains("Alt"))
            {
                try
                {
                    VarGeneral.Print_set_Gen_Stat = true;
                    FrmReportsViewer.IsSettingOnly = true;
                    if (textBox_ID.Text != "" && State == FormState.Saved)
                    {
                        buttonItem_Print_Click(null, null);
                        VarGeneral.Print_set_Gen_Stat = false;
                    }
                    else
                    {
                        FrmReportsViewer frm = new FrmReportsViewer();
                        frm.Repvalue = "InvSalWtr";
                        frm.RepCashier = "InvoiceCachierWaiter";
                        frm.Repvalue = "InvSalWtr";
                        frm.RepCashier = "InvoiceCachierWaiter";
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
        private CheckBoxX checkBox_NetWork;
        internal GroupBox groupBox1;
        private CheckBoxX checkBox_Chash;
        internal Label Label26;
        private DoubleInput txtDueAmount;
        private GroupBox groupBox2;
        internal Label label8;
        private DoubleInput txtTotalAm;
        private DoubleInput txtDiscountVal;
        private DoubleInput txtDiscountP;
        internal Label label3;
        private DoubleInput txtDiscountValLoc;
        private DoubleInput txtTotalAmLoc;
        private DoubleInput txtDueAmountLoc;
        internal Label label9;
        internal Label label17;
        protected ButtonItem Button_Add;
        protected ButtonItem buttonItem_Print;
        protected ButtonItem Button_Save;
        protected ButtonItem Button_Search;
        protected ButtonItem Button_Delete;
        protected ButtonItem Button_Close;
        private ButtonItem buttonItem11;
        private SuperTabControl superTabControl_Main1;
        private ButtonItem buttonItem6;
        private DoubleInput txtTotalQ;
        private MetroTileItem metroTileItem1;
        private ItemContainer itemContainer_Cat;
        private PictureBox pictureBox_Cash;
        private MetroTilePanel metroTilePanel_Cat;
        private PictureBox pictureBox_NetWord;
        protected LabelItem labelItem6;
        private PictureBox pictureBox_Credit;
        private LabelItem lable_Records;
        private RibbonBar ribbonBar_Tasks;
        private SuperTabControl superTabControl_Main2;
        protected LabelItem labelItem4;
        protected ButtonItem Button_First;
        protected ButtonItem Button_Prev;
        protected TextBoxItem TextBox_Index;
        protected LabelItem labelItem5;
        protected ButtonItem Button_Next;
        protected ButtonItem Button_Last;
        private ButtonX button_0;
        private ButtonX button_2;
        private ButtonX button_1;
        private ButtonX button_6;
        private ButtonX button_5;
        private ButtonX button_8;
        private ButtonX button_7;
        private ButtonX button_Bac;
        private ButtonX button_3;
        private ButtonX button_4;
        private MetroTilePanel metroTilePanel_Items;
        private RibbonBar ribbonBar_Items;
        private SuperTabControl superTabControl_ItemsGrids;
        protected LabelItem labelItem2;
        protected ButtonItem btnPrevPage;
        protected ButtonItem btnNxtPage;
        protected LabelItem Label_Count;
        private GroupPanel groupPanel_BoardNo;
        private ButtonX button_9;
        private TextBox txtCustNo;
        private ButtonX button_SrchCustNo;
        internal TextBox txtCustName;
        internal Label label10;
        internal Label label4;
        private DoubleInput doubleInput_Rate;
        private DoubleInput txtInvCost;
        private GroupBox groupBox5;
        internal Label label12;
        private TextBox txtAddress;
        private C1FlexGrid FlxInv;
        private ComboBoxEx CmbInvPrice;
        private ComboBoxEx CmbCostC;
        private ComboBoxEx CmbCurr;
        private ComboBoxEx CmbLegate;
        internal TextBox textBox_ID;
        internal Label label5;
        internal Label label15;
        internal Label label13;
        internal Label label19;
        internal Label label18;
        internal Label label7;
        internal Label Label2;
        internal Label Label1;
        protected SuperGridControl DGV_Main;
        private PanelEx panelEx3;
        private RibbonBar ribbonBar_DGV;
        private SuperTabControl superTabControl_DGV;
        protected TextBoxItem textBox_search;
        protected ButtonItem Button_ExportTable2;
        protected ButtonItem Button_PrintTable;
        protected LabelItem labelItem3;
        private Panel panel1;
        private ExpandableSplitter expandableSplitter1;
        private PanelEx panelEx2;
        private RibbonBar ribbonBar1;
        private RibbonClientPanel ribbonClientPanel1;
        private SuperTabControl superTabControl_Info;
        private SuperTabControlPanel superTabControlPanel1;
        private DoubleInput doubleInput_NetWorkLoc;
        private DoubleInput txtPaymentLoc;
        internal Label label14;
        internal Label label6;
        private SuperTabItem superTabItem_Pay;
        private SuperTabControlPanel superTabControlPanel4;
        private TextBoxX txtRemark;
        private SuperTabItem superTabItem_Note;
        private System.Windows.Forms. SaveFileDialog saveFileDialog1;
        private ImageList imageList1;
        internal PrintPreviewDialog prnt_prev;
        private PrintDocument prnt_doc;
        private System.Windows.Forms.OpenFileDialog  openFileDialog1;
        protected ContextMenuStrip contextMenuStrip1;
        protected ContextMenuStrip contextMenuStrip2;
        protected ToolStripMenuItem ToolStripMenuItem_Det;
        protected ToolStripMenuItem ToolStripMenuItem_Rep;
        private Timer timerInfoBallon;
        private DoubleInput textBox1;
        private DoubleInput textBox2;
        private C1FlexGrid FlxDat;
        private DoubleInput txtCustRep;
        private TextBox txtItemName;
        private DoubleInput txtCustNet;
        private TextBoxX txtTele;
        private TextBoxX txtRef;
        private MaskedTextBox txtTime;
        private MaskedTextBox txtGDate;
        private MaskedTextBox txtHDate;
        private ButtonX button_Space;
        private SuperTabStrip superTabStripORDER;
        private SuperTabItem superTabItem_OrderType;
        private Panel panel_Table;
        private IntegerInput txtTable;
        private Label label31;
        private IntegerInput txtPersons;
        private ButtonX button_SrchTable;
        private ButtonX button_DeleteLine;
        internal Label label11;
        private DoubleInput doubleInput_CreditLoc;
        private CheckBoxItem checkBoxItem_BarCode;
        private GalleryContainer galleryContainer1;
        private SuperGridControl superGridControl1;
        protected ButtonItem buttonItem_BestSeller;
        private ButtonX button_SrchCenterCost;
        private ButtonX button_SrchMnd;
        private ButtonX button_SrchCurr;
        private ButtonX button_SrchPriceDefault;
        private ButtonX button_SrchCustADD;
        private C1FlexGrid dataGridView_ItemDet;
        private C1FlexGrid FlxStkQty;
        private LabelItem labelTableTyp;
        private LabelItem labelItem_Space;
        private Label label_Waiter;
        private TextBox textBox_WaiterName;
        private SwitchButton switchButton_Lock;
        private ButtonX button_AddToTable;
        private SuperTabControlPanel superTabControlPanel5;
        private SuperTabControl superTabControl_CostSts;
        private SuperTabControlPanel superTabControlPanel6;
        private SwitchButton switchButton_Tax;
        internal Label label34;
        internal Label label37;
        private DoubleInput txtTotTax;
        private DoubleInput txtTotTaxLoc;
        private SuperTabItem superTabItem_Tax;
        private SuperTabControlPanel superTabControlPanel8;
        internal Label label42;
        private TextBoxX txtCredit7;
        private CheckBoxX checkBox_GaidBankComm;
        private SwitchButton switchButton_BankComm;
        internal Label label48;
        internal Label label49;
        private DoubleInput txtTotBankComm;
        private DoubleInput txtTotBankCommLoc;
        private SuperTabControlPanel superTabControlPanel7;
        internal Label label39;
        internal Label label40;
        private TextBoxX txtCredit6;
        private TextBoxX txtDebit6;
        private CheckBoxX checkBox_GaidDis;
        internal Label label38;
        internal Label label41;
        private DoubleInput txtTotDis;
        private DoubleInput txtTotDisLoc;
        private SwitchButtonItem switchButton_TaxLines;
        private SwitchButtonItem switchButton_TaxByTotal;
        private SwitchButtonItem switchButton_TaxByNet;
        private TextBoxItem textBoxItem_TaxByNetValue;
        private LabelItem labelItem_TaxByNetPer;
        private SuperTabItem superTabItem_Gaids;
        private CheckBoxX checkBox_CostGaidTax;
        private bool vQtyGraid = false;
        private bool vPriceGraid = false;
        private bool vDisGraid = false;
        private bool vTotGraid = false;
#pragma warning disable CS0414 // The field 'FrmWaiterMenue.vTax' is assigned but its value is never used
        private bool vTax = false;
#pragma warning restore CS0414 // The field 'FrmWaiterMenue.vTax' is assigned but its value is never used
#pragma warning disable CS0169 // The field 'FrmWaiterMenue._Bm' is never used
        private BindingManagerBase _Bm;
#pragma warning restore CS0169 // The field 'FrmWaiterMenue._Bm' is never used
#pragma warning disable CS0414 // The field 'FrmWaiterMenue.vChk' is assigned but its value is never used
        private bool vChk = false;
#pragma warning restore CS0414 // The field 'FrmWaiterMenue.vChk' is assigned but its value is never used
#pragma warning disable CS0414 // The field 'FrmWaiterMenue.orderNo_activate' is assigned but its value is never used
        private int orderNo_activate = 0;
#pragma warning restore CS0414 // The field 'FrmWaiterMenue.orderNo_activate' is assigned but its value is never used
        private int ControlNo = 0;
        private int PageSize = 10;
#pragma warning disable CS0414 // The field 'FrmWaiterMenue.PageSizeDet' is assigned but its value is never used
        private int PageSizeDet = 10;
#pragma warning restore CS0414 // The field 'FrmWaiterMenue.PageSizeDet' is assigned but its value is never used
        private int CurrentPageIndex = 1;
#pragma warning disable CS0414 // The field 'FrmWaiterMenue.CurrentPageIndexItmDet' is assigned but its value is never used
        private int CurrentPageIndexItmDet = 1;
#pragma warning restore CS0414 // The field 'FrmWaiterMenue.CurrentPageIndexItmDet' is assigned but its value is never used
        private int TotalPage = 0;
#pragma warning disable CS0414 // The field 'FrmWaiterMenue.TotalPageDet' is assigned but its value is never used
        private int TotalPageDet = 0;
#pragma warning restore CS0414 // The field 'FrmWaiterMenue.TotalPageDet' is assigned but its value is never used
        private int col = 0;
        private int colW = 0;
        private int row = 0;
        private int rowH = 0;
        private DataTable vUnitA = new DataTable();
        private DataTable vUnitE = new DataTable();
        private int RowSel = 0;
        private string oldUnit = "";
        private string oldItemName = "";
        private double RateValue = 1.0;
        private int DefPack = 0;
        private double Pack = 0.0;
        private double PriceLoc = 0.0;
        private ScriptNumber ScriptNumber1 = new ScriptNumber();
        private List<int> ItemDetRemoved = new List<int>();
        public Dictionary<string, string> columns_Nams_Sums = new Dictionary<string, string>();
        public Dictionary<string, ColumnDictinary> columns_Names_visible = new Dictionary<string, ColumnDictinary>();
        public Dictionary<string, ColumnDictinary> columns_Names_visible2 = new Dictionary<string, ColumnDictinary>();
        private HijriGreg.HijriGregDates n = new HijriGreg.HijriGregDates();
#pragma warning disable CS0414 // The field 'FrmWaiterMenue.UnitAOld' is assigned but its value is never used
        private string UnitAOld = "";
#pragma warning restore CS0414 // The field 'FrmWaiterMenue.UnitAOld' is assigned but its value is never used
#pragma warning disable CS0414 // The field 'FrmWaiterMenue.UnitEOld' is assigned but its value is never used
        private string UnitEOld = "";
#pragma warning restore CS0414 // The field 'FrmWaiterMenue.UnitEOld' is assigned but its value is never used
#pragma warning disable CS0414 // The field 'FrmWaiterMenue.PriceOld' is assigned but its value is never used
        private double PriceOld = 0.0;
#pragma warning restore CS0414 // The field 'FrmWaiterMenue.PriceOld' is assigned but its value is never used
        public static int LangArEn = 0;
        public string DocType = "";
        private T_SYSSETTING _SysSetting = new T_SYSSETTING();
        private List<T_SYSSETTING> listSysSetting = new List<T_SYSSETTING>();
        private T_INVSETTING _InvSetting = new T_INVSETTING();
        private List<T_INVSETTING> listInvSetting = new List<T_INVSETTING>();
        private T_STKSQTY _StksQty = new T_STKSQTY();
        private List<T_STKSQTY> listStkQty = new List<T_STKSQTY>();
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
        private T_INVDET _InvDetRet = new T_INVDET();
        private T_INVDET _InvDet = new T_INVDET();
        private T_INVHED data_this;
        private T_STKSQTY data_this_stkQ;
        private List<T_INVDET> LData_This;
        public bool ifCheckData = false;
        public long TimeFinish = 0L;
        public long TimeStart = 0L;
        public TextBox textBox_Type = new TextBox();
        public List<string> pkeys = new List<string>();
        public bool canUpdate = true;
        protected bool CanInsert = true;
        public FormState statex;
        public ViewState ViewState = ViewState.Deiles;
        public string tableName = "";
        protected bool ifModify = true;
        public List<Control> controls;
        public Control codeControl = new Control();
        public bool CanEdit = true;
        protected bool ifOkDelete;
        private int iiRntP = 0;
        private int _page = 1;
        private bool ifAutoOrderColumn = true;
        private Stock_DataDataContext dbInstance;
        private Rate_DataDataContext dbInstanceRate;
        private Stock_DataDataContext dbInstanceReturn;
        private T_User permission = new T_User();
        private bool isPrintSts = false;
        public Dictionary<int, List<T_SINVDET>> vSINVDIT = new Dictionary<int, List<T_SINVDET>>();
        public string ItmMainParameter = "";
        private int _RowIndex = 0;
        private Dictionary<string, ColumnDictinary> Dir_ButSearch = new Dictionary<string, ColumnDictinary>();
        private int _stsClick = 0;
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
                if (value != 0)
                {
                    switchButton_Lock.IsReadOnly = true;
                }
                else
                {
                    switchButton_Lock.IsReadOnly = false;
                }
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
                    switchButton_Lock.Visible = false;
                    button_AddToTable.Visible = !value;
                }
                else
                {
                    switchButton_Lock.Visible = true;
                    button_AddToTable.Visible = value;
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
                if (value != null && value.UsrNo != "")
                {
                    permission = value;
                    if (!VarGeneral.TString.ChkStatShow(value.InvStr, 1))
                    {
                        IfAdd = false;
                    }
                    else
                    {
                        IfAdd = true;
                    }
                    if (!VarGeneral.TString.ChkStatShow(value.InvStr, 2))
                    {
                        CanEdit = false;
                    }
                    else
                    {
                        CanEdit = true;
                    }
                    if (!VarGeneral.TString.ChkStatShow(value.InvStr, 3))
                    {
                        IfDelete = false;
                    }
                    else
                    {
                        IfDelete = true;
                    }
                    if (State != FormState.New)
                    {
                        switchButton_Lock.Visible = true;
                    }
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
            for (int i = 0; i < DGV_Main.PrimaryGrid.Rows.Count; i++)
            {
                DGV_Main.PrimaryGrid.Rows[i].GridPanel.CheckBoxes = true;
            }
            try
            {
                DGV_Main.PrimaryGrid.SetSelectedCells(1, 0, 1, 1, selected: true);
            }
            catch
            {
            }
        }
        protected bool ContinueIfEditOrNew()
        {
            if (State == FormState.Edit || State == FormState.New)
            {
                if (MessageBox.Show((LangArEn == 0) ? "تم تعديل السجل الحالي دون حفظ التغييرات .. هل تريد المتابعة؟" : "Not saved the changes, do you really want to continue?", VarGeneral.ProdectNam, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
                {
                    return false;
                }
                if (!switchButton_Lock.Visible)
                {
                    switchButton_Lock.Visible = true;
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
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
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
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
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
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
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
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
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
                if (int.Parse(Label_Count.Text ?? "") <= 0 || (Label_Count.Text ?? "") == "")
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
                if (int.Parse(Label_Count.Text ?? "") <= 0 || (Label_Count.Text ?? "") == "")
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
                SetReadOnly = false;
            }
        }
        public void buttonItem_Print_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox_ID.Text != "" && State == FormState.Saved && switchButton_Lock.Value)
                {
                    _PrintInv(data_this.InvHed_ID, data_this.SalsManNo);
                }
            }
            catch
            {
                MessageBox.Show((LangArEn == 0) ? "لا توجد حقول للطباعة تأكد من إعدادات الطباعة" : "No printing fields make sure the print settings", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
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
        private void _PrintInv(int _invHd, string _UserNo)
        {
            RepShow _RepShow = new RepShow();
            _RepShow.Tables = "T_INVDET LEFT OUTER JOIN T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID LEFT OUTER JOIN T_INVSETTING ON T_INVHED.InvTyp = T_INVSETTING.InvID  LEFT OUTER JOIN T_Curency ON T_INVHED.CurTyp = T_Curency.Curency_ID LEFT OUTER JOIN T_CstTbl ON T_INVHED.InvCstNo = T_CstTbl.Cst_ID LEFT OUTER JOIN T_Mndob ON T_INVHED.MndNo = T_Mndob.Mnd_ID LEFT OUTER JOIN T_Items ON T_INVDET.ItmNo = T_Items.Itm_No LEFT OUTER JOIN T_CATEGORY ON T_Items.ItmCat = T_CATEGORY.CAT_ID LEFT OUTER JOIN T_SYSSETTING ON T_INVHED.CompanyID = T_SYSSETTING.SYSSETTING_ID ";
            string vInvH = " T_INVHED.InvHed_ID, T_INVHED.InvId as vID, T_INVHED.InvNo, T_INVHED.InvTyp, T_INVHED.InvCashPay, T_INVHED.CusVenNo,case when T_INVHED.CusVenNo = '' THEN T_INVHED.CusVenNm ELSE (select T_AccDef.Arb_Des from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as CusVenNm,case when T_INVHED.CusVenNo = '' THEN T_INVHED.CusVenNm ELSE (select T_AccDef.Eng_Des from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as CusVenNmE, T_INVHED.CusVenAdd, T_INVHED.CusVenTel, T_INVHED.Remark, T_INVHED.HDat, T_INVHED.GDat, T_INVHED.MndNo, T_INVHED.SalsManNo, T_INVHED.SalsManNam, T_INVHED.InvTot, T_INVHED.InvDisPrs, ((case when IsDisUse1 = 1 then T_INVHED.InvValGaidDis else T_INVHED.InvDisVal end) + T_INVHED.DesPointsValue) as InvDisVal,T_INVHED.InvDisVal as InvDisValOnly,T_INVHED.DesPointsValue,T_INVHED.DesPointsValueLocCur,T_INVHED.PointsCount,T_INVHED.IsPoints, T_INVHED.InvNet, T_INVHED.InvNetLocCur, T_INVHED.CashPayLocCur, T_INVHED.IfRet, T_INVHED.CashPay, T_INVHED.InvTotLocCur, T_INVHED.InvDisValLocCur, T_INVHED.GadeNo, T_INVHED.GadeId, T_INVHED.RetNo, T_INVHED.RetId, T_INVHED.InvCashPayNm, T_INVHED.InvCost, T_INVHED.CustPri, T_INVHED.ArbTaf, T_INVHED.ToStore, T_INVHED.InvCash, T_INVHED.CurTyp, T_INVHED.EstDat,case when DATEDIFF(day, GETDATE(), EstDat) > 0 Then DATEDIFF(day, GETDATE(), EstDat) WHEN DATEDIFF(day, GETDATE(), InvCashPayNm) > 0 THEN DATEDIFF(day, GETDATE(), InvCashPayNm) Else '0' END as EstDatNote, T_INVHED.InvCstNo, T_INVHED.IfDel, T_INVHED.RefNo, T_INVHED.ToStoreNm, T_INVHED.EngTaf, T_INVHED.IfTrans, T_INVHED.InvQty, T_INVHED.CustNet, T_INVHED.CustRep, T_INVHED.InvWight_T, T_INVHED.IfPrint, T_INVHED.LTim, T_INVHED.DATE_CREATED, T_INVHED.MODIFIED_BY, T_INVHED.CreditPay, T_INVHED.DATE_MODIFIED, T_INVHED.CREATED_BY, T_INVHED.CreditPayLocCur, T_INVHED.NetworkPay, T_INVHED.NetworkPayLocCur, T_INVHED.MndExtrnal, T_INVHED.CompanyID, T_INVHED.InvAddCost, T_INVHED.InvAddCostExtrnal, T_INVHED.InvAddCostExtrnalLoc, T_INVHED.IsExtrnalGaid, T_INVHED.ExtrnalCostGaidID, T_INVHED.InvAddCostLoc, T_INVHED.CommMnd_Inv, T_INVHED.Puyaid, T_INVHED.Remming,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select T_AccDef.PersonalNm from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as PersonalNm,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select T_AccDef.City from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as City,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select T_AccDef.Email from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as Email,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select T_AccDef.Mobile from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as Mobile,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select T_AccDef.Telphone1 from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as Telphone1,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select vColStr1 from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as CustAge,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select T_AccDef.Telphone2 from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as Telphone2,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select T_AccDef.Fax from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as Fax,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select T_AccDef.zipCod from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as zipCod,T_SYSSETTING.LineGiftlNameA,T_SYSSETTING.LineGiftlNameE,T_Curency.Arb_Des as CurrnceyNm,T_Curency.Eng_Des as CurrnceyNmE,(select max(gdDes)from T_GDDET where gdID = T_INVHED.GadeId )as gdDes, (T_INVDET.Amount - (case when T_INVHED.IsTaxLines = 1 then (case when T_INVHED.IsTaxByTotal = 1 then (case when (Abs(T_INVDET.Qty) *  T_INVDET.Price * T_INVDET.ItmTax / 100) > 0 then ((Abs(T_INVDET.Qty) *  T_INVDET.Price) - case when (Abs(T_INVDET.Qty) * T_INVDET.Price * T_INVDET.ItmDis / 100) > 0 then (Abs(T_INVDET.Qty) * T_INVDET.Price * T_INVDET.ItmDis / 100) else 0 end )* T_INVDET.ItmTax / 100   else 0 end) else (Abs(T_INVDET.Qty) *  T_INVDET.Price * T_INVDET.ItmTax / 100) end) else 0 end )) as TotBeforeTax,(select invGdADesc from T_INVSETTING where T_INVHED.InvTyp = T_INVSETTING.InvID ) as invGdADesc,(select invGdEDesc from T_INVSETTING where T_INVHED.InvTyp = T_INVSETTING.InvID ) as invGdEDesc,(select T_CATEGORY.CAT_No from T_CATEGORY where T_CATEGORY.CAT_ID = T_Items.ItmCat) as CAT_No,(select T_CATEGORY.Arb_Des from T_CATEGORY where T_CATEGORY.CAT_ID = T_Items.ItmCat) as CatNmA,(select T_CATEGORY.Eng_Des from T_CATEGORY where T_CATEGORY.CAT_ID = T_Items.ItmCat) as CatNmE,(case when (select t.BarCod1 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit1 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt )) != '' then (select t.BarCod1 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit1 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt ))  when (select t.BarCod2 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit2 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt )) != '' then (select t.BarCod2 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit2 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt )) when (select t.BarCod3 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit3 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt )) != '' then (select t.BarCod3 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit3 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt )) when (select t.BarCod4 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit4 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt )) != '' then (select t.BarCod4 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit4 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt )) when (select t.BarCod5 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit5 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt )) != '' then (select t.BarCod5 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit5 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt )) else T_Items.Itm_No  end) as ItmBarcod";
            string Fields = " Abs(T_INVDET.Qty) as QtyAbs , T_INVDET.InvDet_ID,T_INVHED.tailor1,T_INVHED.tailor2,T_INVHED.tailor3,T_INVHED.tailor4,T_INVHED.tailor5,T_INVHED.tailor6,T_INVHED.tailor7,T_INVHED.tailor8,T_INVHED.tailor9,T_INVHED.tailor10,T_INVHED.tailor11,T_INVHED.tailor12,T_INVHED.tailor13,T_INVHED.tailor14,T_INVHED.tailor15,T_INVHED.tailor16,T_INVHED.tailor17,T_INVHED.tailor18,T_INVHED.tailor19,T_INVHED.tailor20,T_INVHED.InvImg, T_INVDET.InvNo, T_INVDET.InvId, T_INVDET.InvSer, T_INVDET.ItmNo, T_INVDET.Cost, T_INVDET.Qty, T_INVDET.ItmUnt, T_INVDET.ItmDes,T_INVDET.ItmDesE , T_INVDET.ItmUntE, T_INVDET.ItmUntPak, T_INVDET.StoreNo, T_INVDET.Price, T_INVDET.Amount, T_INVDET.RealQty, T_INVDET.ItmTyp,T_INVDET.ItmDis, (Abs(T_INVDET.Qty) *  T_INVDET.Price) * (T_INVDET.ItmDis / 100) as ItmDisVal, T_INVDET.DatExper, T_INVDET.itmInvDsc,ItmIndex," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.LineGiftSts, vStr(VarGeneral.InvTyp)) ? " T_INVDET.ItmWight " : " 0 as ItmWight") + ", T_INVDET.ItmWight_T, T_INVDET.ItmAddCost, T_INVDET.RunCod, T_INVDET.LineDetails ,T_INVDET.Serial_Key, " + vInvH + ", T_Items.* , T_CstTbl.Arb_Des as CstTbl_Arb_Des , T_CstTbl.Eng_Des as CstTbl_Eng_Des , T_Mndob.Arb_Des as Mndob_Arb_Des , T_Mndob.Eng_Des as Mndob_Eng_Des,T_SYSSETTING.LogImg,(select max(T_AccDef.TaxNo) from T_AccDef where T_AccDef.AccDef_No = T_SYSSETTING.TaxAcc) as TaxAcc,T_SYSSETTING.TaxNoteInv,case when T_INVHED.IsTaxLines = 1 then (case when T_INVHED.IsTaxByTotal = 1 then (case when (Abs(T_INVDET.Qty) *  T_INVDET.Price * T_INVDET.ItmTax / 100) > 0 then ((Abs(T_INVDET.Qty) *  T_INVDET.Price) - case when (Abs(T_INVDET.Qty) * T_INVDET.Price * T_INVDET.ItmDis / 100) > 0 then (Abs(T_INVDET.Qty) * T_INVDET.Price * T_INVDET.ItmDis / 100) else 0 end )* T_INVDET.ItmTax / 100   else 0 end) else (Abs(T_INVDET.Qty) *  T_INVDET.Price * T_INVDET.ItmTax / 100) end) else 0 end as TaxValue ,(select InvNamA from T_INVSETTING where T_INVHED.InvTyp = T_INVSETTING.InvID ) as InvNamA,(select InvNamE from T_INVSETTING where T_INVHED.InvTyp = T_INVSETTING.InvID ) as InvNamE,(select T_Store.Arb_Des from T_Store where T_Store.Stor_ID = T_INVDET.StoreNo) as StoreNmA,(select T_Store.Eng_Des from T_Store where T_Store.Stor_ID = T_INVDET.StoreNo) as StoreNmE,(select defPrn from T_INVSETTING where CatID = (select ItmCat from T_Items where Itm_No = T_INVDET.ItmNo) ) as defPrn,case when T_INVHED.CusVenNo = '' THEN '0' ELSE (SELECT Sum(T_GDDET.gdValue) FROM T_GDHEAD INNER JOIN  T_GDDET ON T_GDHEAD.gdhead_ID = T_GDDET.gdID where T_GDDET.AccNo = T_INVHED.CusVenNo and T_GDHEAD.gdLok = 0 and (select T_AccDef.AccCat from T_AccDef where T_AccDef.AccDef_No = T_INVHED.CusVenNo) = '4') END as Balanc,T_INVDET.ItmTax,T_INVHED.InvAddTax,T_INVHED.InvAddTaxlLoc,T_INVHED.TaxGaidID,T_INVHED.IsTaxUse,T_INVHED.IsTaxLines,IsTaxByTotal,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select T_AccDef.TaxNo from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as TaxCustNo,T_INVHED.OrderTyp," + ((data_this.IsTaxLines.Value && !VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 65)) ? " T_INVHED.InvTotLocCur - T_INVHED.InvAddTax as TotWithTaxPoint " : " T_INVHED.InvTotLocCur as TotWithTaxPoint") + " ,T_INVHED.InvTotLocCur - T_INVHED.InvDisVal as TotBeforeDisVal,T_INVHED.IsTaxByNet,T_INVHED.TaxByNetValue," + (data_this.IsTaxUse.Value ? " T_INVHED.InvNetLocCur - T_INVHED.InvAddTax as NetWithoutTax " : " T_INVHED.InvNetLocCur as NetWithoutTax");
            VarGeneral.HeaderRep[0] = Text;
            VarGeneral.HeaderRep[1] = "";
            VarGeneral.HeaderRep[2] = "";
            _RepShow.Rule = " where T_INVHED.InvHed_ID = " + _invHd;
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
                _RepShow.Rule = " WHERE T_Users.UsrNo = '" + _UserNo + "'";
                _RepShow.Tables = " T_Branch INNER JOIN T_Users ON T_Branch.Branch_no = T_Users.Brn ";
                _RepShow.Fields = " T_Users.UsrNamA ,T_Branch.Branch_Name ,T_Users.UsrNamE ,T_Branch.Branch_NameE ,T_Users.UsrImg ";
                try
                {
                    VarGeneral.RepShowStock_Rat = "Rate";
                    _RepShow = _RepShow.Save();
                    VarGeneral.RepShowStock_Rat = "";
                }
                catch (Exception ex2)
                {
                    VarGeneral.RepShowStock_Rat = "";
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
                        _RepShow.Tables = "T_SINVDET LEFT OUTER JOIN T_INVHED ON T_SINVDET.SInvIdHEAD = T_INVHED.InvHed_ID LEFT OUTER JOIN T_INVSETTING ON T_INVHED.InvTyp = T_INVSETTING.InvID  LEFT OUTER JOIN T_Curency ON T_INVHED.CurTyp = T_Curency.Curency_ID LEFT OUTER JOIN T_CstTbl ON T_INVHED.InvCstNo = T_CstTbl.Cst_ID LEFT OUTER JOIN T_Mndob ON T_INVHED.MndNo = T_Mndob.Mnd_ID LEFT OUTER JOIN T_Items ON T_SINVDET.SItmNo = T_Items.Itm_No LEFT OUTER JOIN T_CATEGORY ON T_Items.ItmCat = T_CATEGORY.CAT_ID LEFT OUTER JOIN T_SYSSETTING ON T_INVHED.CompanyID = T_SYSSETTING.SYSSETTING_ID ";
                        string vInvH2 = " T_INVHED.InvHed_ID, T_INVHED.InvId as vID, T_INVHED.InvNo, T_INVHED.InvTyp, T_INVHED.InvCashPay, T_INVHED.CusVenNo,case when T_INVHED.CusVenNo = '' THEN T_INVHED.CusVenNm ELSE (select T_AccDef.Arb_Des from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as CusVenNm,case when T_INVHED.CusVenNo = '' THEN T_INVHED.CusVenNm ELSE (select T_AccDef.Eng_Des from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as CusVenNmE, T_INVHED.CusVenAdd, T_INVHED.CusVenTel, T_INVHED.Remark, T_INVHED.HDat, T_INVHED.GDat, T_INVHED.MndNo, T_INVHED.SalsManNo, T_INVHED.SalsManNam, T_INVHED.InvTot, T_INVHED.InvDisPrs, (T_INVHED.InvDisVal + T_INVHED.DesPointsValue) as InvDisVal,T_INVHED.InvDisVal as InvDisValOnly,T_INVHED.DesPointsValue,T_INVHED.DesPointsValueLocCur,T_INVHED.PointsCount,T_INVHED.IsPoints, T_INVHED.InvNet, T_INVHED.InvNetLocCur, T_INVHED.CashPayLocCur, T_INVHED.IfRet, T_INVHED.CashPay, T_INVHED.InvTotLocCur, T_INVHED.InvDisValLocCur, T_INVHED.GadeNo, T_INVHED.GadeId, T_INVHED.RetNo, T_INVHED.RetId, T_INVHED.InvCashPayNm, T_INVHED.InvCost, T_INVHED.CustPri, T_INVHED.ArbTaf, T_INVHED.ToStore, T_INVHED.InvCash, T_INVHED.CurTyp, T_INVHED.EstDat,case when DATEDIFF(day, GETDATE(), EstDat) > 0 Then DATEDIFF(day, GETDATE(), EstDat) WHEN DATEDIFF(day, GETDATE(), InvCashPayNm) > 0 THEN DATEDIFF(day, GETDATE(), InvCashPayNm) Else '0' END as EstDatNote, T_INVHED.InvCstNo, T_INVHED.IfDel, T_INVHED.RefNo, T_INVHED.ToStoreNm, T_INVHED.EngTaf, T_INVHED.IfTrans, T_INVHED.InvQty, T_INVHED.CustNet, T_INVHED.CustRep, T_INVHED.InvWight_T, T_INVHED.IfPrint, T_INVHED.LTim, T_INVHED.DATE_CREATED, T_INVHED.MODIFIED_BY, T_INVHED.CreditPay, T_INVHED.DATE_MODIFIED, T_INVHED.CREATED_BY, T_INVHED.CreditPayLocCur, T_INVHED.NetworkPay, T_INVHED.NetworkPayLocCur, T_INVHED.MndExtrnal, T_INVHED.CompanyID, T_INVHED.InvAddCost, T_INVHED.InvAddCostExtrnal, T_INVHED.InvAddCostExtrnalLoc, T_INVHED.IsExtrnalGaid, T_INVHED.ExtrnalCostGaidID, T_INVHED.InvAddCostLoc, T_INVHED.CommMnd_Inv, T_INVHED.Puyaid, T_INVHED.Remming,T_SYSSETTING.LineGiftlNameA,T_SYSSETTING.LineGiftlNameE,T_Curency.Arb_Des as CurrnceyNm,T_Curency.Eng_Des as CurrnceyNmE,(select max(gdDes)from T_GDDET where gdID = T_INVHED.GadeId )as gdDes, (T_INVDET.Amount - (case when T_INVHED.IsTaxLines = 1 then (case when T_INVHED.IsTaxByTotal = 1 then (case when (Abs(T_INVDET.Qty) *  T_INVDET.Price * T_INVDET.ItmTax / 100) > 0 then ((Abs(T_INVDET.Qty) *  T_INVDET.Price) - case when (Abs(T_INVDET.Qty) * T_INVDET.Price * T_INVDET.ItmDis / 100) > 0 then (Abs(T_INVDET.Qty) * T_INVDET.Price * T_INVDET.ItmDis / 100) else 0 end )* T_INVDET.ItmTax / 100   else 0 end) else (Abs(T_INVDET.Qty) *  T_INVDET.Price * T_INVDET.ItmTax / 100) end) else 0 end )) as TotBeforeTax,(select invGdADesc from T_INVSETTING where T_INVHED.InvTyp = T_INVSETTING.InvID ) as invGdADesc,(select invGdEDesc from T_INVSETTING where T_INVHED.InvTyp = T_INVSETTING.InvID ) as invGdEDesc,(select T_CATEGORY.CAT_No from T_CATEGORY where T_CATEGORY.CAT_ID = T_Items.ItmCat) as CAT_No,(select T_CATEGORY.Arb_Des from T_CATEGORY where T_CATEGORY.CAT_ID = T_Items.ItmCat) as CatNmA,(select T_CATEGORY.Eng_Des from T_CATEGORY where T_CATEGORY.CAT_ID = T_Items.ItmCat) as CatNmE,(case when (select t.BarCod1 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit1 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt )) != '' then (select t.BarCod1 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit1 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt ))  when (select t.BarCod2 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit2 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt )) != '' then (select t.BarCod2 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit2 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt )) when (select t.BarCod3 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit3 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt )) != '' then (select t.BarCod3 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit3 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt )) when (select t.BarCod4 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit4 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt )) != '' then (select t.BarCod4 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit4 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt )) when (select t.BarCod5 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit5 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt )) != '' then (select t.BarCod5 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit5 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt )) else T_Items.Itm_No  end) as ItmBarcod";
                        _RepShow.Fields = " Abs(T_SINVDET.SQty) as QtyAbs , SInvDet_ID as InvId , SInvNo as InvNo, SInvId as InvDet_ID, SInvSer as InvSer,SItmNo as ItmNo, SCost as Cost, SQty as Qty, SItmDes as ItmDes, SItmUnt as ItmUnt, SItmDesE as ItmDesE, SItmUntE as ItmUntE, SItmUntPak as ItmUntPak, SStoreNo as StoreNo, (SPrice * 0) as Price, (SAmount * 0) as Amount, SRealQty as RealQty, SitmInvDsc as itmInvDsc, SDatExper as DatExper, SItmDis as ItmDis, SItmTyp as ItmTyp,SItmIndex as ItmIndex, SItmWight_T as ItmWight_T, SItmWight as ItmWight , " + vInvH2 + " , T_Items.* , T_CstTbl.Arb_Des as CstTbl_Arb_Des , T_CstTbl.Eng_Des as CstTbl_Eng_Des , T_Mndob.Arb_Des as Mndob_Arb_Des , T_Mndob.Eng_Des as Mndob_Eng_Des,T_SYSSETTING.LogImg,(select max(T_AccDef.TaxNo) from T_AccDef where T_AccDef.AccDef_No = T_SYSSETTING.TaxAcc) as TaxAcc,T_SYSSETTING.TaxNoteInv,case when T_INVHED.IsTaxLines = 1 then (case when T_INVHED.IsTaxByTotal = 1 then (case when (Abs(T_INVDET.Qty) *  T_INVDET.Price * T_INVDET.ItmTax / 100) > 0 then ((Abs(T_INVDET.Qty) *  T_INVDET.Price) - case when (Abs(T_INVDET.Qty) * T_INVDET.Price * T_INVDET.ItmDis / 100) > 0 then (Abs(T_INVDET.Qty) * T_INVDET.Price * T_INVDET.ItmDis / 100) else 0 end )* T_INVDET.ItmTax / 100   else 0 end) else (Abs(T_INVDET.Qty) *  T_INVDET.Price * T_INVDET.ItmTax / 100) end) else 0 end as TaxValue,T_INVHED.IsTaxUse,T_INVHED.IsTaxLines,IsTaxByTotal,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select T_AccDef.TaxNo from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as TaxCustNo," + ((data_this.IsTaxLines.Value && !VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 65)) ? " T_INVHED.InvTotLocCur - T_INVHED.InvAddTax as TotWithTaxPoint " : " T_INVHED.InvTotLocCur as TotWithTaxPoint");
                        _RepShow.Rule = " where T_INVHED.InvHed_ID = " + _invHd;
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
            if (VarGeneral.RepData.Tables[0].Rows.Count == 0)
            {
                return;
            }
            try
            {
                FrmReportsViewer frm = new FrmReportsViewer();
                frm.Repvalue = "InvSalWtr";
                frm.RepCashier = "InvoiceCachierWaiter";
                frm.Tag = LangArEn;
                if (checkBoxItem_BarCode.Checked)
                {
                    frm.BarcodSts = true;
                }
                else
                {
                    frm.BarcodSts = false;
                }
                if (_InvSetting.InvpRINTERInfo.nTyp.Substring(1, 1) == "1")
                {
                    frm.Repvalue = "InvSalWtr";
                }
                else
                {
                    frm.RepCashier = "InvoiceCachierWaiter";
                }
                VarGeneral.CostCenterlbl = label15.Text.Replace(" :", "");
                VarGeneral.Mndoblbl = label18.Text.Replace(" :", "");
                VarGeneral.vTitle = Text;
                VarGeneral.IsCashCredit = false;
                if (_InvSetting.InvpRINTERInfo.nTyp.Substring(2, 1) == "1" || checkBoxItem_BarCode.Checked)
                {
                    frm._Proceess();
                    return;
                }
                frm.TopMost = true;
                frm.ShowDialog();
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("buttonItem_Print_Click:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void prnt_doc_PrintPage(object sender, PrintPageEventArgs e)
        {
            if (VarGeneral.RepData.Tables[0].Rows.Count == 0)
            {
                return;
            }
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
                    string strfiled = "";
                     if(_mInvPrint.pField.Contains("PageTotel"))
                    _mInvPrint.pField = (_mInvPrint.pField.Contains("PageTotelE") ? "StoreNmE" : "StoreNmA");
                  strfiled = ((!(_mInvPrint.pField == "PageNo")) ? VarGeneral.TString.TEmpty_Stock(string.Concat(VarGeneral.RepData.Tables[0].Rows[iiRnt][_mInvPrint.pField])) : (_page + " / " + _PageCount));
                    if (_mInvPrint.IsPrntHd == 1)
                    {
                        if (_mInvPrint.pField == "ItmNo")
                        {
                            StringFormat stringFormat = new StringFormat();
                            stringFormat.Alignment = StringAlignment.Far;
                            StringFormat format = stringFormat;
                            e.Graphics.DrawString(strfiled, _font, Brushes.Black, _mInvPrint.vCol.Value, _Row, format);
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
                        e.Graphics.DrawString(strfiled, _font, Brushes.Black, _mInvPrint.vCol.Value, _Row, strformat);
                    }
                    else if (_mInvPrint.nTyp == 1 && _page == 1)
                    {
                        e.Graphics.DrawString(strfiled, _font, Brushes.Black, _mInvPrint.vCol.Value, _Row, strformat);
                    }
                    else if (_mInvPrint.nTyp == 2 && _page == _PageCount)
                    {
                        e.Graphics.DrawString(strfiled, _font, Brushes.Black, _mInvPrint.vCol.Value, _Row, strformat);
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
        private void prnt_doc_BeginPrint(object sender, PrintEventArgs e)
        {
            if (!(textBox_ID.Text != ""))
            {
                return;
            }
            RepShow _RepShow = new RepShow();
            _RepShow.Tables = "T_INVDET LEFT OUTER JOIN T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID LEFT OUTER JOIN T_INVSETTING ON T_INVHED.InvTyp = T_INVSETTING.InvID  LEFT OUTER JOIN T_Curency ON T_INVHED.CurTyp = T_Curency.Curency_ID LEFT OUTER JOIN T_CstTbl ON T_INVHED.InvCstNo = T_CstTbl.Cst_ID LEFT OUTER JOIN T_Mndob ON T_INVHED.MndNo = T_Mndob.Mnd_ID LEFT OUTER JOIN T_Items ON T_INVDET.ItmNo = T_Items.Itm_No LEFT OUTER JOIN T_CATEGORY ON T_Items.ItmCat = T_CATEGORY.CAT_ID LEFT OUTER JOIN T_SYSSETTING ON T_INVHED.CompanyID = T_SYSSETTING.SYSSETTING_ID ";
            string vInvH = " T_INVHED.InvHed_ID, T_INVHED.InvId as vID, T_INVHED.InvNo, T_INVHED.InvTyp, T_INVHED.InvCashPay, T_INVHED.CusVenNo,case when T_INVHED.CusVenNo = '' THEN T_INVHED.CusVenNm ELSE (select T_AccDef.Arb_Des from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as CusVenNm,case when T_INVHED.CusVenNo = '' THEN T_INVHED.CusVenNm ELSE (select T_AccDef.Eng_Des from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as CusVenNmE, T_INVHED.CusVenAdd, T_INVHED.CusVenTel, T_INVHED.Remark, T_INVHED.HDat, T_INVHED.GDat, T_INVHED.MndNo, T_INVHED.SalsManNo, T_INVHED.SalsManNam, T_INVHED.InvTot, T_INVHED.InvDisPrs, ((case when IsDisUse1 = 1 then T_INVHED.InvValGaidDis else T_INVHED.InvDisVal end) + T_INVHED.DesPointsValue) as InvDisVal,T_INVHED.InvDisVal as InvDisValOnly,T_INVHED.DesPointsValue,T_INVHED.DesPointsValueLocCur,T_INVHED.PointsCount,T_INVHED.IsPoints, T_INVHED.InvNet, T_INVHED.InvNetLocCur, T_INVHED.CashPayLocCur, T_INVHED.IfRet, T_INVHED.CashPay, T_INVHED.InvTotLocCur, T_INVHED.InvDisValLocCur, T_INVHED.GadeNo, T_INVHED.GadeId, T_INVHED.RetNo, T_INVHED.RetId, T_INVHED.InvCashPayNm, T_INVHED.InvCost, T_INVHED.CustPri, T_INVHED.ArbTaf, T_INVHED.ToStore, T_INVHED.InvCash, T_INVHED.CurTyp, T_INVHED.EstDat,case when DATEDIFF(day, GETDATE(), EstDat) > 0 Then DATEDIFF(day, GETDATE(), EstDat) WHEN DATEDIFF(day, GETDATE(), InvCashPayNm) > 0 THEN DATEDIFF(day, GETDATE(), InvCashPayNm) Else '0' END as EstDatNote, T_INVHED.InvCstNo, T_INVHED.IfDel, T_INVHED.RefNo, T_INVHED.ToStoreNm, T_INVHED.EngTaf, T_INVHED.IfTrans, T_INVHED.InvQty, T_INVHED.CustNet, T_INVHED.CustRep, T_INVHED.InvWight_T, T_INVHED.IfPrint, T_INVHED.LTim, T_INVHED.DATE_CREATED, T_INVHED.MODIFIED_BY, T_INVHED.CreditPay, T_INVHED.DATE_MODIFIED, T_INVHED.CREATED_BY, T_INVHED.CreditPayLocCur, T_INVHED.NetworkPay, T_INVHED.NetworkPayLocCur, T_INVHED.MndExtrnal, T_INVHED.CompanyID, T_INVHED.InvAddCost, T_INVHED.InvAddCostExtrnal, T_INVHED.InvAddCostExtrnalLoc, T_INVHED.IsExtrnalGaid, T_INVHED.ExtrnalCostGaidID, T_INVHED.InvAddCostLoc, T_INVHED.CommMnd_Inv, T_INVHED.Puyaid, T_INVHED.Remming,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select T_AccDef.PersonalNm from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as PersonalNm,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select T_AccDef.City from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as City,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select T_AccDef.Email from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as Email,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select T_AccDef.Mobile from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as Mobile,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select T_AccDef.Telphone1 from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as Telphone1,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select vColStr1 from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as CustAge,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select T_AccDef.Telphone2 from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as Telphone2,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select T_AccDef.Fax from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as Fax,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select T_AccDef.zipCod from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as zipCod,T_SYSSETTING.LineGiftlNameA,T_SYSSETTING.LineGiftlNameE,T_Curency.Arb_Des as CurrnceyNm,T_Curency.Eng_Des as CurrnceyNmE,(select max(gdDes)from T_GDDET where gdID = T_INVHED.GadeId )as gdDes, (T_INVDET.Amount - (case when T_INVHED.IsTaxLines = 1 then (case when T_INVHED.IsTaxByTotal = 1 then (case when (Abs(T_INVDET.Qty) *  T_INVDET.Price * T_INVDET.ItmTax / 100) > 0 then ((Abs(T_INVDET.Qty) *  T_INVDET.Price) - case when (Abs(T_INVDET.Qty) * T_INVDET.Price * T_INVDET.ItmDis / 100) > 0 then (Abs(T_INVDET.Qty) * T_INVDET.Price * T_INVDET.ItmDis / 100) else 0 end )* T_INVDET.ItmTax / 100   else 0 end) else (Abs(T_INVDET.Qty) *  T_INVDET.Price * T_INVDET.ItmTax / 100) end) else 0 end )) as TotBeforeTax,(select invGdADesc from T_INVSETTING where T_INVHED.InvTyp = T_INVSETTING.InvID ) as invGdADesc,(select invGdEDesc from T_INVSETTING where T_INVHED.InvTyp = T_INVSETTING.InvID ) as invGdEDesc,(select T_CATEGORY.CAT_No from T_CATEGORY where T_CATEGORY.CAT_ID = T_Items.ItmCat) as CAT_No,(select T_CATEGORY.Arb_Des from T_CATEGORY where T_CATEGORY.CAT_ID = T_Items.ItmCat) as CatNmA,(select T_CATEGORY.Eng_Des from T_CATEGORY where T_CATEGORY.CAT_ID = T_Items.ItmCat) as CatNmE,(case when (select t.BarCod1 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit1 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt )) != '' then (select t.BarCod1 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit1 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt ))  when (select t.BarCod2 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit2 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt )) != '' then (select t.BarCod2 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit2 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt )) when (select t.BarCod3 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit3 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt )) != '' then (select t.BarCod3 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit3 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt )) when (select t.BarCod4 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit4 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt )) != '' then (select t.BarCod4 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit4 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt )) when (select t.BarCod5 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit5 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt )) != '' then (select t.BarCod5 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit5 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt )) else T_Items.Itm_No  end) as ItmBarcod";
            string Fields = " Abs(T_INVDET.Qty) as QtyAbs , T_INVDET.InvDet_ID,T_INVHED.tailor1,T_INVHED.tailor2,T_INVHED.tailor3,T_INVHED.tailor4,T_INVHED.tailor5,T_INVHED.tailor6,T_INVHED.tailor7,T_INVHED.tailor8,T_INVHED.tailor9,T_INVHED.tailor10,T_INVHED.tailor11,T_INVHED.tailor12,T_INVHED.tailor13,T_INVHED.tailor14,T_INVHED.tailor15,T_INVHED.tailor16,T_INVHED.tailor17,T_INVHED.tailor18,T_INVHED.tailor19,T_INVHED.tailor20,T_INVHED.InvImg, T_INVDET.InvNo, T_INVDET.InvId, T_INVDET.InvSer, T_INVDET.ItmNo, T_INVDET.Cost, T_INVDET.Qty, T_INVDET.ItmUnt, T_INVDET.ItmDes,T_INVDET.ItmDesE , T_INVDET.ItmUntE, T_INVDET.ItmUntPak, T_INVDET.StoreNo, T_INVDET.Price, T_INVDET.Amount, T_INVDET.RealQty, T_INVDET.ItmTyp,T_INVDET.ItmDis, (Abs(T_INVDET.Qty) *  T_INVDET.Price) * (T_INVDET.ItmDis / 100) as ItmDisVal, T_INVDET.DatExper, T_INVDET.itmInvDsc,ItmIndex," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.LineGiftSts, vStr(VarGeneral.InvTyp)) ? " T_INVDET.ItmWight " : " 0 as ItmWight") + ", T_INVDET.ItmWight_T, T_INVDET.ItmAddCost, T_INVDET.RunCod, T_INVDET.LineDetails ,T_INVDET.Serial_Key, " + vInvH + ", T_Items.* , T_CstTbl.Arb_Des as CstTbl_Arb_Des , T_CstTbl.Eng_Des as CstTbl_Eng_Des , T_Mndob.Arb_Des as Mndob_Arb_Des , T_Mndob.Eng_Des as Mndob_Eng_Des,T_SYSSETTING.LogImg,(select max(T_AccDef.TaxNo) from T_AccDef where T_AccDef.AccDef_No = T_SYSSETTING.TaxAcc) as TaxAcc,T_SYSSETTING.TaxNoteInv,case when T_INVHED.IsTaxLines = 1 then (case when T_INVHED.IsTaxByTotal = 1 then (case when (Abs(T_INVDET.Qty) *  T_INVDET.Price * T_INVDET.ItmTax / 100) > 0 then ((Abs(T_INVDET.Qty) *  T_INVDET.Price) - case when (Abs(T_INVDET.Qty) * T_INVDET.Price * T_INVDET.ItmDis / 100) > 0 then (Abs(T_INVDET.Qty) * T_INVDET.Price * T_INVDET.ItmDis / 100) else 0 end )* T_INVDET.ItmTax / 100   else 0 end) else (Abs(T_INVDET.Qty) *  T_INVDET.Price * T_INVDET.ItmTax / 100) end) else 0 end as TaxValue ,(select InvNamA from T_INVSETTING where T_INVHED.InvTyp = T_INVSETTING.InvID ) as InvNamA,(select InvNamE from T_INVSETTING where T_INVHED.InvTyp = T_INVSETTING.InvID ) as InvNamE,(select T_Store.Arb_Des from T_Store where T_Store.Stor_ID = T_INVDET.StoreNo) as StoreNmA,(select T_Store.Eng_Des from T_Store where T_Store.Stor_ID = T_INVDET.StoreNo) as StoreNmE,(select defPrn from T_INVSETTING where CatID = (select ItmCat from T_Items where Itm_No = T_INVDET.ItmNo) ) as defPrn,case when T_INVHED.CusVenNo = '' THEN '0' ELSE (SELECT Sum(T_GDDET.gdValue) FROM T_GDHEAD INNER JOIN  T_GDDET ON T_GDHEAD.gdhead_ID = T_GDDET.gdID where T_GDDET.AccNo = T_INVHED.CusVenNo and T_GDHEAD.gdLok = 0 and (select T_AccDef.AccCat from T_AccDef where T_AccDef.AccDef_No = T_INVHED.CusVenNo) = '4') END as Balanc,T_INVDET.ItmTax,T_INVHED.InvAddTax,T_INVHED.InvAddTaxlLoc,T_INVHED.TaxGaidID,T_INVHED.IsTaxUse,T_INVHED.IsTaxLines,IsTaxByTotal,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select T_AccDef.TaxNo from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as TaxCustNo,T_INVHED.OrderTyp," + ((data_this.IsTaxLines.Value && !VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 65)) ? " T_INVHED.InvTotLocCur - T_INVHED.InvAddTax as TotWithTaxPoint " : " T_INVHED.InvTotLocCur as TotWithTaxPoint") + " ,T_INVHED.InvTotLocCur - T_INVHED.InvDisVal as TotBeforeDisVal,T_INVHED.IsTaxByNet,T_INVHED.TaxByNetValue," + (data_this.IsTaxUse.Value ? " T_INVHED.InvNetLocCur - T_INVHED.InvAddTax as NetWithoutTax " : " T_INVHED.InvNetLocCur as NetWithoutTax");
            VarGeneral.HeaderRep[0] = Text;
            VarGeneral.HeaderRep[1] = "";
            VarGeneral.HeaderRep[2] = "";
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
                    VarGeneral.RepShowStock_Rat = "";
                }
                catch (Exception ex2)
                {
                    VarGeneral.RepShowStock_Rat = "";
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
                        _RepShow.Rule = "";
                        _RepShow.Tables = "T_SINVDET LEFT OUTER JOIN T_INVHED ON T_SINVDET.SInvIdHEAD = T_INVHED.InvHed_ID LEFT OUTER JOIN T_INVSETTING ON T_INVHED.InvTyp = T_INVSETTING.InvID  LEFT OUTER JOIN T_Curency ON T_INVHED.CurTyp = T_Curency.Curency_ID LEFT OUTER JOIN T_CstTbl ON T_INVHED.InvCstNo = T_CstTbl.Cst_ID LEFT OUTER JOIN T_Mndob ON T_INVHED.MndNo = T_Mndob.Mnd_ID LEFT OUTER JOIN T_Items ON T_SINVDET.SItmNo = T_Items.Itm_No LEFT OUTER JOIN T_CATEGORY ON T_Items.ItmCat = T_CATEGORY.CAT_ID LEFT OUTER JOIN T_SYSSETTING ON T_INVHED.CompanyID = T_SYSSETTING.SYSSETTING_ID ";
                        string vInvH2 = " T_INVHED.InvHed_ID, T_INVHED.InvId, T_INVHED.InvNo, T_INVHED.InvTyp, T_INVHED.InvCashPay, T_INVHED.CusVenNo,case when T_INVHED.CusVenNo = '' THEN T_INVHED.CusVenNm ELSE " + ((LangArEn == 0) ? "(select T_AccDef.Arb_Des from T_AccDef where AccDef_No = T_INVHED.CusVenNo)" : "(select T_AccDef.Eng_Des from T_AccDef where AccDef_No = T_INVHED.CusVenNo)") + " END as CusVenNm, T_INVHED.CusVenAdd, T_INVHED.CusVenTel, T_INVHED.Remark, T_INVHED.HDat, T_INVHED.GDat, T_INVHED.MndNo, T_INVHED.SalsManNo, T_INVHED.SalsManNam, T_INVHED.InvTot, T_INVHED.InvDisPrs, (T_INVHED.InvDisVal + T_INVHED.DesPointsValue) as InvDisVal,T_INVHED.InvDisVal as InvDisValOnly,T_INVHED.DesPointsValue,T_INVHED.DesPointsValueLocCur,T_INVHED.PointsCount,T_INVHED.IsPoints, T_INVHED.InvNet, T_INVHED.InvNetLocCur, T_INVHED.CashPayLocCur, T_INVHED.IfRet, T_INVHED.CashPay, T_INVHED.InvTotLocCur, T_INVHED.InvDisValLocCur, T_INVHED.GadeNo, T_INVHED.GadeId, T_INVHED.RetNo, T_INVHED.RetId, T_INVHED.InvCashPayNm, T_INVHED.InvCost, T_INVHED.CustPri, T_INVHED.ArbTaf, T_INVHED.ToStore, T_INVHED.InvCash, T_INVHED.CurTyp, T_INVHED.EstDat, T_INVHED.InvCstNo, T_INVHED.IfDel, T_INVHED.RefNo, T_INVHED.ToStoreNm, T_INVHED.EngTaf, T_INVHED.IfTrans, T_INVHED.InvQty, T_INVHED.CustNet, T_INVHED.CustRep, T_INVHED.InvWight_T, T_INVHED.IfPrint, T_INVHED.LTim, T_INVHED.DATE_CREATED, T_INVHED.MODIFIED_BY, T_INVHED.CreditPay, T_INVHED.DATE_MODIFIED, T_INVHED.CREATED_BY, T_INVHED.CreditPayLocCur, T_INVHED.NetworkPay, T_INVHED.NetworkPayLocCur, T_INVHED.MndExtrnal, T_INVHED.CompanyID, T_INVHED.InvAddCost, T_INVHED.InvAddCostExtrnal, T_INVHED.InvAddCostExtrnalLoc, T_INVHED.IsExtrnalGaid, T_INVHED.ExtrnalCostGaidID, T_INVHED.InvAddCostLoc, T_INVHED.CommMnd_Inv, T_INVHED.Puyaid, T_INVHED.Remming,(select InvNamA from T_INVSETTING where T_INVHED.InvTyp = T_INVSETTING.InvID ) as InvNamA,(select InvNamE from T_INVSETTING where T_INVHED.InvTyp = T_INVSETTING.InvID ) as InvNamE,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select T_AccDef.Mobile from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as Mobile ";
                        _RepShow.Fields = " Abs(T_SINVDET.SQty) as QtyAbs , SInvDet_ID as InvId, SInvNo as InvNo, SInvId as InvDet_ID, SInvSer as InvSer,SItmNo as ItmNo, SCost as Cost, SQty as Qty, SItmDes as ItmDes, SItmUnt as ItmUnt, SItmDesE as ItmDesE, SItmUntE as ItmUntE, SItmUntPak as ItmUntPak, SStoreNo as StoreNo, (SPrice * 0) as Price, (SAmount * 0) as Amount, SRealQty as RealQty, SitmInvDsc as itmInvDsc, SDatExper as DatExper, SItmDis as ItmDis, SItmTyp as ItmTyp,SItmIndex as ItmIndex, SItmWight_T as ItmWight_T, SItmWight as ItmWight , " + vInvH2 + " , T_Items.* , T_CstTbl.Arb_Des as CstTbl_Arb_Des , T_CstTbl.Eng_Des as CstTbl_Eng_Des , T_Mndob.Arb_Des as Mndob_Arb_Des , T_Mndob.Eng_Des as Mndob_Eng_Des,T_SYSSETTING.LogImg,(select max(T_AccDef.TaxNo) from T_AccDef where T_AccDef.AccDef_No = T_SYSSETTING.TaxAcc) as TaxAcc";
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
        private void Button_Close_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void textBox_ID_Click(object sender, EventArgs e)
        {
            textBox_ID.SelectAll();
        }
        private void textBox_ID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (e.KeyChar != '\b'))
            {
                e.Handled = true;
            }
        }
        private void switchButton_TaxLines_ValueChanged(object sender, EventArgs e)
        {
            if (State == FormState.Saved)
            {
                return;
            }
            for (int iiCnt = 1; iiCnt < FlxInv.Rows.Count; iiCnt++)
            {
                if (!(string.Concat(FlxInv.GetData(iiCnt, 1)) != ""))
                {
                    continue;
                }
                double ItmDis = 0.0;
                double ItmAddTax = 0.0;
                ItmDis = double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 8)))) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 9)))) / 100.0);
                try
                {
                    if ((File.Exists(Application.StartupPath + "\\Script\\SecriptColDisSalesPoint.dll") || (VarGeneral.gUserName == "runsetting" && File.Exists(Application.StartupPath + "\\Script\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", "").Trim() + "\\SecriptColDisSalesPoint.dll"))) && double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 36)))) > 0.0)
                    {
                        ItmDis += double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 8)))) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 36)))) / 100.0);
                    }
                }
                catch
                {
                }
                ItmAddTax = Math.Round(double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 8)))) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 38)))) / 100.0), VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2);
                if (!switchButton_TaxLines.Value || switchButton_TaxByTotal.Value)
                {
                    ItmAddTax = 0.0;
                }
                FlxInv.SetData(iiCnt, 31, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 8)))) - ItmDis + ItmAddTax);
                if (switchButton_TaxByTotal.Value && switchButton_TaxLines.Value && double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 31)))) > 0.0)
                {
                    ItmAddTax = Math.Round((double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 8)))) - ItmDis) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 38)))) / 100.0), VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2);
                    FlxInv.SetData(iiCnt, 31, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 31)))) + ItmAddTax);
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
        public FrmWaiterMenue()
        {
            InitializeComponent();this.Load += langloads;
            textBox_ID.KeyPress += textBox_ID_KeyPress;
            textBox_ID.Click += Button_Edit_Click;
            textBox1.Click += Button_Edit_Click;
            textBox2.Click += Button_Edit_Click;
            textBox_Type.Click += Button_Edit_Click;
            txtAddress.Click += Button_Edit_Click;
            txtCustName.Click += Button_Edit_Click;
            txtCustNet.Click += Button_Edit_Click;
            txtCustNo.Click += Button_Edit_Click;
            textBox_WaiterName.Click += Button_Edit_Click;
            txtCustRep.Click += Button_Edit_Click;
            txtDiscountP.Click += Button_Edit_Click;
            txtDiscountVal.Click += Button_Edit_Click;
            txtDiscountValLoc.Click += Button_Edit_Click;
            txtDueAmount.Click += Button_Edit_Click;
            txtDueAmountLoc.Click += Button_Edit_Click;
            txtGDate.Click += Button_Edit_Click;
            txtHDate.Click += Button_Edit_Click;
            txtInvCost.Click += Button_Edit_Click;
            txtItemName.Click += Button_Edit_Click;
            txtRef.Click += Button_Edit_Click;
            txtRemark.Click += Button_Edit_Click;
            txtTele.Click += Button_Edit_Click;
            txtTime.Click += Button_Edit_Click;
            txtTotalAm.Click += Button_Edit_Click;
            txtTotalAmLoc.Click += Button_Edit_Click;
            txtTotalQ.Click += Button_Edit_Click;
            CmbCostC.Click += Button_Edit_Click;
            CmbCurr.Click += Button_Edit_Click;
            checkBox_Chash.Click += Button_Edit_Click;
            checkBox_NetWork.Click += Button_Edit_Click;
            CmbInvPrice.Click += Button_Edit_Click;
            CmbLegate.Click += Button_Edit_Click;
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
            txtHDate.Leave += txtHDate_Leave;
            txtGDate.Leave += txtGDate_Leave;
            txtTime.Leave += txtTime_Leave;
            button_SrchCustNo.Click += button_SrchCustNo_Click;
            CmbCurr.SelectedIndexChanged += CmbCurr_SelectedIndexChanged;
            checkBox_Chash.CheckedChanged += checkBox_Chash_CheckedChanged;
            FlxInv.Click += FlxInv_Click;
            FlxInv.AfterEdit += FlxInv_AfterEdit;
            FlxInv.BeforeEdit += FlxInv_BeforeEdit;
            FlxInv.KeyDown += FlxInv_KeyDown;
            FlxInv.MouseDown += FlxInv_MouseDown;
            FlxInv.RowColChange += FlxInv_RowColChange;
            FlxInv.SelChange += FlxInv_SelChange;
            switchButton_TaxLines.ButtonWidth = 100;
            checkBox_CostGaidTax.Click += Button_Edit_Click;
            switchButton_Tax.Click += Button_Edit_Click;
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
            FlxDat.DoubleClick += FlxDat_DoubleClick;
            FlxDat.KeyDown += FlxDat_KeyDown;
            FlxDat.Leave += FlxDat_Leave;
            txtDiscountP.Leave += txtDiscountP_Leave;
            txtDiscountVal.Leave += txtDiscountVal_Leave;
            buttonItem_Print.Click += buttonItem_Print_Click;
            Button_PrintTable.Click += Button_Print_Click;
            txtDueAmountLoc.ValueChanged += txtDueAmountLoc_ValueChanged;
            txtRemark.ButtonCustomClick += txtRemark_ButtonCustomClick;
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
                try
                {
                    FlxInv.Cols[8].Format = VarGeneral.DicimalNN;
                    FlxInv.Cols[9].Format = VarGeneral.DicimalNN;
                    FlxInv.Cols[10].Format = VarGeneral.DicimalNN;
                    FlxInv.Cols[11].Format = VarGeneral.DicimalNN;
                    FlxInv.Cols[12].Format = VarGeneral.DicimalNN;
                    FlxInv.Cols[31].Format = VarGeneral.DicimalNN;
                    FlxInv.Cols[38].Format = VarGeneral.DicimalNN;
                    dataGridView_ItemDet.Cols[8].Format = VarGeneral.DicimalNN;
                    dataGridView_ItemDet.Cols[9].Format = VarGeneral.DicimalNN;
                    dataGridView_ItemDet.Cols[10].Format = VarGeneral.DicimalNN;
                    dataGridView_ItemDet.Cols[11].Format = VarGeneral.DicimalNN;
                    dataGridView_ItemDet.Cols[12].Format = VarGeneral.DicimalNN;
                    dataGridView_ItemDet.Cols[31].Format = VarGeneral.DicimalNN;
                }
                catch
                {
                }
            }
        }
        public void Button_Search_Click(object sender, EventArgs e)
        {
            try
            {
                FrmCustSearch frm = new FrmCustSearch();
                frm.vTy_ = 7;
                frm.Tag = LangArEn;
                frm.TopMost = true;
                frm.ShowDialog();
                if (frm.SerachNo != "")
                {
                    textBox_ID.Text = frm.SerachNo.ToString();
                }
            }
            catch
            {
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
                        controls[i].Text = "";
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
            checkBox_Chash.Checked = true;
            FlxInv.Rows.Count = 1;
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
            dataGridView_ItemDet.Visible = false;
            try
            {
                CmbCurr.SelectedValue = int.Parse(VarGeneral.Settings_Sys.ImportIp.ToString());
            }
            catch
            {
            }
            CmbCurr_SelectedIndexChanged(null, null);
            textBox_WaiterName.Tag = VarGeneral._WaiterID.ToString();
            textBox_WaiterName.Text = ((LangArEn == 0) ? db.StockWaiterID(VarGeneral._WaiterID).Arb_Des : db.StockWaiterID(VarGeneral._WaiterID).Eng_Des);
            switchButton_Lock.ValueChanged -= switchButton_Lock_ValueChanged;
            switchButton_Lock.Value = true;
            switchButton_Lock.ValueChanged += switchButton_Lock_ValueChanged;
            txtTable.Tag = "";
            TableTyp();
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
            SetReadOnly = false;
        }
        private void InvModeChanged()
        {
            pictureBox_Cash.Visible = true;
            pictureBox_NetWord.Visible = false;
            pictureBox_Credit.Visible = false;
            doubleInput_CreditLoc.IsInputReadOnly = true;
            label6.Text = ((LangArEn == 0) ? "نقــدا\u064c :" : "Paid :");
            txtDueAmountLoc_ValueChanged(null, null);
        }
        private void checkBox_Chash_CheckedChanged(object sender, EventArgs e)
        {
            InvModeChanged();
        }
        private void button_SrchCustNo_Click(object sender, EventArgs e)
        {
            Button_Edit_Click(sender, e);
            if (State == FormState.Saved)
            {
                return;
            }
            FrmCustSearch frm = new FrmCustSearch();
            frm.vTy_ = 0;
            frm.Tag = LangArEn;
            VarGeneral.SFrmTyp = "T_AccDef";
            VarGeneral.AccTyp = 4;
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != "")
            {
                txtCustNo.Text = frm.Serach_No;
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                {
                    txtCustName.Text = db.StockAccDefWithOutBalance(frm.Serach_No).Arb_Des;
                }
                else
                {
                    txtCustName.Text = db.StockAccDefWithOutBalance(frm.Serach_No).Eng_Des;
                }
                txtAddress.Text = db.StockAccDefWithOutBalance(frm.Serach_No).Adders ?? "";
                txtTele.Text = db.StockAccDefWithOutBalance(frm.Serach_No).Telphone1 ?? "";
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
            }
            else
            {
                txtCustNo.Text = "";
                txtCustName.Text = "";
                txtAddress.Text = "";
                txtCustRep.Value = 0.0;
            }
        }
        private void ArbEng()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
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
                FlxInv.Cols[31].Caption = "الأجمالي";
                FlxInv.Cols[35].Caption = "رقم التصنيع";
                FlxInv.Cols[36].Caption = VarGeneral.Settings_Sys.LineDetailNameA;
                FlxInv.Cols[38].Caption = "ضريبة %";
                FlxStkQty.Cols[0].Caption = "المستودع";
                FlxStkQty.Cols[1].Caption = "الكمية المتاحة";
                FlxStkQty.Cols[2].Caption = "المستودع";
                FlxDat.Cols[0].Caption = "تاريخ الصلاحية";
                FlxDat.Cols[1].Caption = "الكمية";
                FlxDat.Cols[2].Caption = "رقم التصنيع";
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
                FlxInv.Cols[31].Caption = "Totel";
                FlxInv.Cols[35].Caption = "Make No";
                FlxInv.Cols[36].Caption = VarGeneral.Settings_Sys.LineDetailNameE;
                FlxInv.Cols[38].Caption = "Tax %";
                FlxStkQty.Cols[0].Caption = "Store";
                FlxStkQty.Cols[1].Caption = "Quantity";
                FlxStkQty.Cols[2].Caption = "Store";
                FlxDat.Cols[0].Caption = "Expir Date";
                FlxDat.Cols[1].Caption = "Quantity";
                FlxDat.Cols[2].Caption = "Make No";
                dataGridView_ItemDet.Cols[1].Caption = "Item Code";
                dataGridView_ItemDet.Cols[2].Visible = false;
                dataGridView_ItemDet.Cols[3].Visible = false;
                dataGridView_ItemDet.Cols[4].Visible = true;
                dataGridView_ItemDet.Cols[5].Visible = true;
                dataGridView_ItemDet.Cols[6].Caption = "Store";
                dataGridView_ItemDet.Cols[7].Caption = "Quantity";
                dataGridView_ItemDet.Cols[8].Caption = "Price";
            }
            if (!VarGeneral.TString.ChkStatShow(_InvSetting.TaxOptions, 0))
            {
                FlxInv.Cols[38].Visible = false;
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
                controls.Add(textBox_WaiterName);
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
                controls.Add(txtRef);
                controls.Add(txtRemark);
                controls.Add(txtTele);
                controls.Add(txtTime);
                controls.Add(txtTotalAm);
                controls.Add(txtTotalAmLoc);
                controls.Add(txtTotalQ);
                controls.Add(CmbCostC);
                controls.Add(CmbCurr);
                controls.Add(checkBox_Chash);
                controls.Add(checkBox_NetWork);
                controls.Add(CmbInvPrice);
                controls.Add(CmbLegate);
                controls.Add(doubleInput_Rate);
                controls.Add(txtPaymentLoc);
                controls.Add(doubleInput_NetWorkLoc);
                controls.Add(doubleInput_CreditLoc);
                controls.Add(txtPersons);
                controls.Add(txtTable);
                controls.Add(txtTotTax);
                controls.Add(txtTotTaxLoc);
                controls.Add(switchButton_Tax);
                controls.Add(checkBox_CostGaidTax);
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
            }
            else
            {
                if (!data_this.RoomSts.Value)
                {
                    return;
                }
                string Code = "???";
                if (codeControl != null)
                {
                    Code = codeControl.Text;
                }
                if (Code == "")
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
                data_this = db.StockInvHead(VarGeneral.InvTyp, DataThis.InvNo);
                IDatabase db_ = Database.GetDatabase(VarGeneral.BranchCS);
                try
                {
                    db.ExecuteCommand("UPDATE [T_Rooms] SET [RomeStatus] = 0, [waiterNo] = NULL Where [RomeStatus] = 1 and ID =" + data_this.RoomNo.Value);
                    for (int i = 0; i < data_this.T_INVDETs.Count; i++)
                    {
                        if (data_this.T_INVDETs[i].ItmTyp.Value == 2)
                        {
                            for (int iicnt = 0; iicnt < data_this.T_INVDETs[i].T_SINVDETs.Count; iicnt++)
                            {
                                db_.ClearParameters();
                                db_.AddParameter("SInvDet_ID", DbType.Int32, data_this.T_INVDETs[i].T_SINVDETs[iicnt].SInvDet_ID);
                                db_.ExecuteNonQuery(storedProcedure: true, "S_T_SINVDET_DELETE");
                            }
                        }
                        db_.ClearParameters();
                        db_.AddParameter("InvDet_ID", DbType.Int32, data_this.T_INVDETs[i].InvDet_ID);
                        db_.ExecuteNonQuery(storedProcedure: true, "S_T_INVDET_DELETE");
                    }
                    try
                    {
                        db.ExecuteCommand("DELETE FROM [T_INVHED] WHERE InvHed_ID=" + data_this.InvHed_ID);
                    }
                    catch
                    {
                    }
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
        }
        private void Button_Add_Click(object sender, EventArgs e)
        {
            if (Button_Add.Visible && Button_Add.Enabled && (State != FormState.Edit || MessageBox.Show((LangArEn == 0) ? "تم تعديل السجل الحالي دون حفظ التغييرات .. هل تريد المتابعة؟" : "Not saved the changes, do you really want to continue?", VarGeneral.ProdectNam, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes))
            {
                Clear();
                txtGDate.Text = n.FormatGreg(VarGeneral.Gdate, "yyyy/MM/dd");
                txtHDate.Text = n.FormatHijri(VarGeneral.Hdate, "yyyy/MM/dd");
                txtTime.Text = DateTime.Now.ToString("HH:mm");
                GetInvSetting();
                textBox_ID.Text = db.MaxInvheadNo.ToString();
                State = FormState.New;
                if (VarGeneral.SSSTyp != 0 && _InvSetting.autoTaxGaid.Value)
                {
                    checkBox_CostGaidTax.Checked = true;
                }
            }
        }
        public void RefreshPKeys()
        {
            PKeys.Clear();
            var qkeys = from item in db.T_INVHEDs
                        where item.InvTyp == (int?)VarGeneral.InvTyp
                        where item.IfDel == (int?)0
                        where item.SalsManNo == VarGeneral.UserNo
                        where item.RoomNo.HasValue
                        where item.T_Room.T_Waiter.waiter_ID == VarGeneral._WaiterID
                        where item.PaymentOrderTyp == (int?)0
                        select new
                        {
                            Code = item.InvNo + ""
                        };
            int count = 0;
            foreach (var item2 in qkeys)
            {
                count++;
                PKeys.Add(item2.Code);
            }
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
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmWaiterMenue));
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
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
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
                label8.Text = "نسبة الخصم";
                Label26.Text = "قيمة الخصم";
                label17.Text = "قيمة الفاتـــورة :";
                label9.Text = "صافي الفاتورة :";
                label3.Text = "بالريــال";
                superTabItem_Pay.Text = "الدفع";
                superTabItem_Note.Text = "ملاحظة";
                txtRemark.WatermarkText = "ملاحظات الفاتورة";
                label6.Text = "نقــدا\u064c :";
                label11.Text = "آجــل :";
                label14.Text = "شبكة :";
                checkBox_Chash.Text = "نقـــدي";
                button_Bac.Text = "مسج";
                button_Space.Text = "Space";
                button_DeleteLine.Text = "حذف السطر";
                btnPrevPage.Text = "سابق";
                btnNxtPage.Text = "تالي";
                buttonItem_BestSeller.Text = "أكثر مبيعا\u064c";
                checkBoxItem_BarCode.Text = "إضافة تلقائية";
                switchButton_Tax.OffText = "غير معتمد";
                switchButton_Tax.OnText = "معتمد";
                superTabItem_Tax.Text = "ضريبة";
                superTabItem_Gaids.Text = "سندات";
                switchButton_BankComm.OffText = "عدم احتساب";
                switchButton_BankComm.OnText = "احتســـاب";
                switchButton_TaxLines.OnText = "سطور الضريبة";
                switchButton_TaxLines.OffText = "سطور الضريبة";
                switchButton_TaxByTotal.OnText = "إجمالي سطر";
                switchButton_TaxByTotal.OffText = "إجمالي سطر";
                switchButton_TaxByNet.OffText = "صافي";
                switchButton_TaxByNet.OffText = "صافي";
                button_SrchCustADD.Tooltip = "إضافة عميل";
                switchButton_Lock.OffText = "لم يتم إعتماد الطلب";
                switchButton_Lock.OnText = "تم إعتماد الطلب";
                button_AddToTable.Text = "توجيه إلى";
                Text = "الطلبات المحلية";
            }
            else
            {
                Button_First.Text = "First";
                Button_Last.Text = "Last";
                Button_Next.Text = "Next";
                Button_Prev.Text = "Previous";
                Button_Add.Text = "New";
                Button_Close.Text = "Close";
                Button_Delete.Text = "Delete";
                Button_Save.Text = "Save";
                Button_Search.Text = "Search";
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
                buttonItem_Print.Text = ((_InvSetting.InvpRINTERInfo.nTyp.Substring(2, 1) == "1") ? "Print" : "Show");
                buttonItem_Print.Tooltip = "F5";
                Button_ExportTable2.Text = "Export";
                Button_ExportTable2.Tooltip = "F10";
                DGV_Main.PrimaryGrid.GroupByRow.Text = "All Records";
                Label1.Text = "Invoice No :";
                Label2.Text = "Date :";
                label7.Text = "Ref No :";
                label19.Text = "Currncy :";
                label18.Text = "Delegate :";
                label4.Text = "Cust Acc :";
                label10.Text = "Cust Name :";
                label13.Text = "Cust Address :";
                label15.Text = "Cost Center :";
                label5.Text = "Price Now : ";
                label12.Text = "Tel :";
                label8.Text = "Discount %";
                Label26.Text = "Dis value";
                label17.Text = "Invoice value :";
                label9.Text = "Invoice Net :";
                label3.Text = "Riyal";
                superTabItem_Pay.Text = "Paid";
                superTabItem_Note.Text = "Note";
                txtRemark.WatermarkText = "Notes";
                label6.Text = "Cash :";
                label11.Text = "Credit :";
                label14.Text = "NetWork :";
                checkBox_Chash.Text = "Cach";
                button_Bac.Text = "Clear";
                button_Space.Text = "Space";
                button_DeleteLine.Text = "DELETE LINE";
                btnPrevPage.Text = "Prev";
                btnNxtPage.Text = "Next";
                buttonItem_BestSeller.Text = "Best Seller";
                superTabItem_OrderType.Text = "Order Type";
                checkBoxItem_BarCode.Text = "Auto ADD";
                switchButton_Tax.OffText = "certified";
                switchButton_Tax.OnText = "un certified";
                superTabItem_Tax.Text = "Tax";
                superTabItem_Gaids.Text = "Bonds";
                switchButton_BankComm.OffText = "Not issuing";
                switchButton_BankComm.OnText = "issuing";
                switchButton_TaxLines.OnText = "Tax Lines";
                switchButton_TaxLines.OffText = "Tax Lines";
                switchButton_TaxByTotal.OnText = "Line Tot";
                switchButton_TaxByTotal.OffText = "Line Tot";
                switchButton_TaxByNet.OffText = "Net";
                switchButton_TaxByNet.OffText = "Net";
                button_SrchCustADD.Tooltip = "Add Customer";
                switchButton_Lock.OffText = "Order not approved";
                switchButton_Lock.OnText = "Order approved";
                button_AddToTable.Text = "Forward to";
                Text = "Local Orders";
            }
            TableTyp();
        }
        private void FrmWaiterMenue_Load(object sender, EventArgs e)
        {
            try
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmWaiterMenue));
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
                ADD_Controls();
                Permmission = dbc.Get_PermissionID(VarGeneral.UserID);
                if (columns_Names_visible.Count == 0)
                {
                    columns_Names_visible.Add("InvNo", new ColumnDictinary("رقم الفاتورة", "Invoice No", ifDefault: true, ""));
                    columns_Names_visible.Add("CusVenNm", new ColumnDictinary("إسم العميل", "Customer Name", ifDefault: true, ""));
                    columns_Names_visible.Add("SalsManNo", new ColumnDictinary("رقم البائع", "SalsMan No", ifDefault: false, ""));
                    columns_Names_visible.Add("HDat", new ColumnDictinary("التاريخ الهجري", "Date Hijri", ifDefault: true, ""));
                    columns_Names_visible.Add("GDat", new ColumnDictinary("التاريخ الميلادي", "Date Gregorian", ifDefault: true, ""));
                    columns_Names_visible.Add("InvTotLocCur", new ColumnDictinary("إجمالي الفاتورة", "Invoice Total", ifDefault: false, ""));
                    columns_Names_visible.Add("InvNetLocCur", new ColumnDictinary("صافي الفاتورة", "Invoice Net", ifDefault: true, ""));
                    columns_Names_visible.Add("InvQty", new ColumnDictinary("إجمالي الكمية", "Quantity Total", ifDefault: true, ""));
                    columns_Names_visible.Add("InvDisPrs", new ColumnDictinary("الخصم نسبة", "Discount Percentage", ifDefault: false, ""));
                    columns_Names_visible.Add("InvDisValLocCur", new ColumnDictinary("الخصم قيمة", "Discount value", ifDefault: true, ""));
                    columns_Names_visible.Add("GadeNo", new ColumnDictinary("رقم القيد المحاسبي", "Gaid No", ifDefault: false, ""));
                    columns_Names_visible.Add("CusVenMob", new ColumnDictinary("الجوال", "Mobile", ifDefault: true, ""));
                }
                else
                {
                    Clear();
                    textBox_ID.Text = "";
                    TextBox_Index.TextBox.Text = "";
                }
                FillCat();
                FillCombo();
                GetInvSetting();
                ArbEng();
                RefreshPKeys();
                textBox_ID.Text = PKeys.FirstOrDefault();
                listUnit = new List<T_Unit>();
                listStore = new List<T_Store>();
                listUnit = db.FillUnit_2("").ToList();
                listStore = db.FillStore_2("").ToList();
                FlxStkQty.Rows.Count = listStore.Count + 1;
                string Co = "";
                for (int iiCnt = 0; iiCnt < listStore.Count; iiCnt++)
                {
                    _Store = listStore[iiCnt];
                    FlxStkQty.SetData(iiCnt + 1, 0, _Store.Stor_ID.ToString());
                    FlxStkQty.SetData(iiCnt + 1, 2, ((LangArEn == 0) ? _Store.Arb_Des : _Store.Eng_Des).ToString());
                    Co = ((!(Co != "")) ? _Store.Stor_ID.ToString() : (Co + "|" + _Store.Stor_ID));
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
                if (VarGeneral.vDemo)
                {
                    IfDelete = false;
                }
                checkBoxItem_BarCode_CheckedChanged(null, null);
                if (VarGeneral.SSSTyp == 0)
                {
                    if (VarGeneral.SSSLev == "M")
                    {
                        label4.Visible = false;
                        txtCustNo.Visible = false;
                        button_SrchCustNo.Visible = false;
                    }
                    checkBox_CostGaidTax.Visible = false;
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
                if (VarGeneral.SSSLev == "R" || VarGeneral.SSSLev == "C" || VarGeneral.SSSLev == "H")
                {
                    superTabStripORDER.Visible = true;
                    labelTableTyp.Visible = true;
                    TableTyp();
                }
                ChangeWindowSize();
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Load:", error, enable: true);
                MessageBox.Show(error.Message);
            }
            if (File.Exists(Application.StartupPath + "\\Script\\SecriptCustBarcode.dll"))
            {
                txtCustNo.ReadOnly = false;
            }
            else
            {
                txtCustNo.ReadOnly = true;
            }
        }
        private void ChangeWindowSize()
        {
            if (!VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 27))
            {
                base.MaximizeBox = true;
                base.WindowState = FormWindowState.Maximized;
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                {
                    btnPrevPage.Text = "سابق";
                    btnNxtPage.Text = "تالي";
                    buttonItem_BestSeller.Text = "أكثر مبيعا\u064c";
                }
                else
                {
                    btnPrevPage.Text = "Prev";
                    btnNxtPage.Text = "Next";
                    buttonItem_BestSeller.Text = "Best Seller";
                }
            }
            else
            {
                base.WindowState = FormWindowState.Normal;
                btnPrevPage.Text = "";
                btnNxtPage.Text = "";
                buttonItem_BestSeller.Text = "";
            }
        }
        private void FillCat()
        {
            try
            {
                Stock_DataDataContext dbc = new Stock_DataDataContext(VarGeneral.BranchCS);
                FillCombo();
                try
                {
                    itemContainer_Cat.SubItems.Clear();
                    List<T_CATEGORY> q = dbc.FillCat_2("").ToList();
                    try
                    {
                        q = q.OrderBy((T_CATEGORY c) => int.Parse(c.CAT_No)).ToList();
                    }
                    catch
                    {
                    }
                    if (q.Count > 0)
                    {
                        q.Insert(0, new T_CATEGORY());
                    }
                    for (int i = 0; i < q.Count; i++)
                    {
                        MetroTileItem vCat = new MetroTileItem();
                        try
                        {
                            if (q[i] == null || q[i].CAT_ID == 0)
                            {
                                vCat.SymbolColor = Color.Empty;
                                vCat.TileColor = eMetroTileColor.Orange;
                                vCat.TileSize = new Size(125, 45);
                                vCat.TileStyle.CornerType = eCornerType.Rounded;
                                vCat.TitleText = ((LangArEn == 0) ? "الكــل" : "ALL");
                                vCat.Tag = 0;
                                vCat.TitleTextAlignment = ContentAlignment.MiddleCenter;
                                vCat.TitleTextColor = Color.White;
                                vCat.TitleTextFont = new Font("Tahoma", 6f, FontStyle.Bold, GraphicsUnit.Point, 0);
                                itemContainer_Cat.SubItems.AddRange(new BaseItem[1]
                                {
                                    vCat
                                });
                            }
                            else
                            {
                                vCat.SymbolColor = Color.Empty;
                                vCat.TileColor = eMetroTileColor.Blueish;
                                vCat.TileSize = new Size(125, 45);
                                vCat.TileStyle.CornerType = eCornerType.Rounded;
                                vCat.TitleText = ((LangArEn == 0) ? q[i].Arb_Des : q[i].Eng_Des);
                                vCat.Tag = q[i].CAT_ID;
                                vCat.TitleTextAlignment = ContentAlignment.MiddleCenter;
                                vCat.TitleTextColor = Color.White;
                                vCat.TitleTextFont = new Font("Tahoma", 6f, FontStyle.Bold, GraphicsUnit.Point, 0);
                                itemContainer_Cat.SubItems.AddRange(new BaseItem[1]
                                {
                                    vCat
                                });
                            }
                        }
                        catch
                        {
                        }
                    }
                    Refresh();
                    ItemsMainSetting();
                }
                catch (Exception error)
                {
                    VarGeneral.DebLog.writeLog("FillCat:", error, enable: true);
                    ItemsMainSetting();
                    Refresh();
                }
            }
            catch
            {
            }
        }
        private void ItemsMainSetting()
        {
            try
            {
                superGridControl1.PrimaryGrid.Columns.Clear();
                superGridControl1.PrimaryGrid.Rows.Clear();
                col = superGridControl1.Width / 130;
                colW = superGridControl1.Width / col;
                row = superGridControl1.Height / 130;
                rowH = superGridControl1.Height / row;
                if (base.WindowState == FormWindowState.Normal)
                {
                    col = 2;
                    colW = superGridControl1.Width / col;
                    row = superGridControl1.Height / 130;
                    rowH = superGridControl1.Height / row;
                }
                PageSize = Math.Abs(col * row);
                for (int i = 0; i < col; i++)
                {
                    GridColumn q = new GridColumn();
                    q.Width = colW;
                    superGridControl1.PrimaryGrid.Columns.Add(q);
                }
                for (int i = 0; i < row; i++)
                {
                    GridRow c = new GridRow();
                    c.RowHeight = rowH / 2 + rowH * 25 / 100;
                    c.RowStyles.Default.Background.Color1 = Color.AliceBlue;
                    for (int j = 0; j < col; j++)
                    {
                        c.Cells.Add(new GridCell(""));
                    }
                    superGridControl1.PrimaryGrid.Rows.Add(c);
                    GridRow cc = new GridRow();
                    cc.RowHeight = rowH / 4;
                    cc.RowStyles.Default.Background.Color1 = Color.AliceBlue;
                    for (int j = 0; j < col; j++)
                    {
                        cc.Cells.Add(new GridCell(""));
                        cc.Cells.LastOrDefault().EditorType = typeof(GridButtonXEditControl);
                        if (base.WindowState == FormWindowState.Normal)
                        {
                            cc.CellStyles.Default.Font = new Font("Tahoma", 6f, FontStyle.Bold);
                        }
                    }
                    superGridControl1.PrimaryGrid.Rows.Add(cc);
                }
            }
            catch
            {
            }
            ItmMainParameter = "";
            FillItmesMain(null, vBestSaller: false);
        }
        private void Button_ExportTable2_Click(object sender, EventArgs e)
        {
            try
            {
                ExportExcel.ExportToExcel(DGV_Main, "تقرير فواتير المبيعات");
            }
            catch
            {
            }
        }
        private void TextBox_Search_ButtonCustomClick(object sender, EventArgs e)
        {
            textBox_search.Text = "";
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
            panel.Columns["InvDisPrs"].Width = 100;
            panel.Columns["InvDisPrs"].Visible = columns_Names_visible["InvDisPrs"].IfDefault;
            panel.Columns["InvDisValLocCur"].Width = 100;
            panel.Columns["InvDisValLocCur"].Visible = columns_Names_visible["InvDisValLocCur"].IfDefault;
            panel.Columns["CusVenAdd"].Width = 400;
            panel.Columns["CusVenAdd"].Visible = columns_Names_visible["CusVenAdd"].IfDefault;
            panel.Columns["GadeNo"].Width = 130;
            panel.Columns["GadeNo"].Visible = columns_Names_visible["GadeNo"].IfDefault;
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
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
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
                    string txtId = textBox_ID.Text;
                    if (isPrintSts)
                    {
                        _PrintInv(data_this.InvHed_ID, data_this.SalsManNo);
                    }
                    State = FormState.Saved;
                    RefreshPKeys();
                    TextBox_Index.TextBox.Text = string.Concat(PKeys.IndexOf(data_this.InvNo ?? "") + 1);
                    SetReadOnly = true;
                    checkBoxItem_BarCode_CheckedChanged(null, null);
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
            _InvSetting = db.StockInvSetting( VarGeneral.InvTyp);
            _SysSetting = db.SystemSettingStock();
        }
        private void textBox_ID_TextChanged(object sender, EventArgs e)
        {
            string no = "";
            try
            {
                no = textBox_ID.Text;
            }
            catch
            {
            }
            try
            {
                T_INVHED newData = db.StockInvHead(VarGeneral.InvTyp, no);
                if (newData == null || string.IsNullOrEmpty(newData.InvNo))
                {
                    if (!Button_Add.Visible || !Button_Add.Enabled)
                    {
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
                    TextBox_Index.InputTextChanged -= TextBox_Index_InputTextChanged;
                    TextBox_Index.TextBox.Text = string.Concat(PKeys.Count + 1);
                    TextBox_Index.InputTextChanged += TextBox_Index_InputTextChanged;
                }
                else
                {
                    DataThis = newData;
                    int indexA = PKeys.IndexOf(newData.InvNo ?? "");
                    indexA++;
                    TextBox_Index.InputTextChanged -= TextBox_Index_InputTextChanged;
                    TextBox_Index.TextBox.Text = string.Concat(indexA);
                    TextBox_Index.InputTextChanged += TextBox_Index_InputTextChanged;
                }
            }
            catch
            {
            }
            FlxDat.Visible = false;
            UpdateVcr();
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
                txtHDate.Text = "";
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
                txtGDate.Text = "";
            }
        }
        private void Frm_KeyPress(object sender, KeyPressEventArgs e)
        {
        }
        private void Frm_KeyDown(object sender, KeyEventArgs e)
        {
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
            else
            {
                if (e.KeyCode != Keys.Escape)
                {
                    return;
                }
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
                    if (int.Parse(Label_Count.Text) > 0 && !checkBoxItem_BarCode.Checked)
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
        private void FlxInv_Click(object sender, EventArgs e)
        {
            Button_Edit_Click(sender, e);
            ControlNo = 0;
            CheckSts(ControlNo);
            try
            {
                if (FlxInv.Row <= 0 || !VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 66))
                {
                    return;
                }
                int vRowIndex = FlxInv.Row;
                if (FlxInv.Rows[vRowIndex].Height != 33)
                {
                    return;
                }
                FrmInvDetNoteSrch frm = new FrmInvDetNoteSrch();
                frm.Tag = LangArEn;
                try
                {
                    frm.textbox_Detailes.Text = FlxInv.GetData(vRowIndex, 2).ToString() ?? "";
                }
                catch
                {
                    frm.textbox_Detailes.Text = "";
                }
                frm.TopMost = true;
                frm.ShowDialog();
                if (!(frm.SerachNo != ""))
                {
                    return;
                }
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                {
                    FlxInv.Row = vRowIndex;
                    FlxInv.RowSel = vRowIndex;
                    FlxInv.Col = 2;
                    FlxInv.ColSel = 2;
                    FlxInv.SetData(vRowIndex, 2, "");
                    FlxInv.SetData(vRowIndex, 2, FlxInv.GetData(vRowIndex, 2).ToString() + frm.SerachNo);
                    try
                    {
                        FlxInv.SetData(vRowIndex - 1, 36, FlxInv.GetData(vRowIndex, 2).ToString());
                    }
                    catch
                    {
                    }
                }
                else
                {
                    FlxInv.Row = vRowIndex;
                    FlxInv.RowSel = vRowIndex;
                    FlxInv.Col = 4;
                    FlxInv.ColSel = 4;
                    FlxInv.SetData(vRowIndex, 4, "");
                    FlxInv.SetData(vRowIndex, 4, FlxInv.GetData(vRowIndex, 4).ToString() + frm.SerachNo);
                    try
                    {
                        FlxInv.SetData(vRowIndex - 1, 36, FlxInv.GetData(vRowIndex, 4).ToString());
                    }
                    catch
                    {
                    }
                }
            }
            catch
            {
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
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
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
            CmbLegate.SelectedIndex = _CmbIndex;
        }
        private void FillCombo()
        {
            int _CmbIndex = CmbInvPrice.SelectedIndex;
            CmbInvPrice.Items.Clear();
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
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
            CmbInvPrice.SelectedIndex = _CmbIndex;
            _CmbIndex = CmbCurr.SelectedIndex;
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
            CmbCurr.SelectedIndex = _CmbIndex;
            _CmbIndex = CmbCostC.SelectedIndex;
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
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
            switchButton_Lock.ValueChanged -= switchButton_Lock_ValueChanged;
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
                dataGridView_ItemDet.Visible = false;
                State = FormState.Saved;
                Button_Save.Enabled = false;
                textBox_ID.Tag = value.InvHed_ID;
                txtCustNo.Text = value.CusVenNo.ToString();
                button_AddToTable.Visible = false;
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
                try
                {
                    if (value.RoomNo > 1 && value.RoomSts.Value)
                    {
                        if (value.T_Room.waiterNo.HasValue)
                        {
                            textBox_WaiterName.Text = ((LangArEn == 0) ? db.StockWaiterID(value.T_Room.waiterNo.Value).Arb_Des : db.StockWaiterID(value.T_Room.waiterNo.Value).Eng_Des);
                            textBox_WaiterName.Tag = value.T_Room.waiterNo.Value.ToString();
                        }
                        else
                        {
                            textBox_WaiterName.Tag = "";
                            textBox_WaiterName.Text = "";
                        }
                    }
                    else
                    {
                        textBox_WaiterName.Tag = "";
                        textBox_WaiterName.Text = "";
                    }
                }
                catch
                {
                    textBox_WaiterName.Tag = "";
                    textBox_WaiterName.Text = "";
                }
                if (VarGeneral.SSSLev == "M")
                {
                    txtCustNo.Text = "";
                }
                txtAddress.Text = value.CusVenAdd;
                txtTele.Text = value.CusVenTel;
                txtRemark.Text = value.Remark;
                txtDiscountP.Value = value.InvDisPrs.Value;
                txtDiscountVal.Value = value.InvDisVal.Value;
                txtDiscountValLoc.Value = value.InvDisValLocCur.Value;
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
                switchButton_Lock.Value = value.AdminLock.Value;
                FillComboMnd();
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
                checkBox_Chash.Checked = true;
                txtPaymentLoc.Value = value.CashPayLocCur.Value;
                doubleInput_NetWorkLoc.Value = value.NetworkPayLocCur.Value;
                doubleInput_CreditLoc.Value = value.CreditPayLocCur.Value;
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
                if (value.IsTaxGaid.HasValue)
                {
                    checkBox_CostGaidTax.Checked = value.IsTaxGaid.Value;
                }
                else
                {
                    checkBox_CostGaidTax_CheckedChanged(null, null);
                }
                textBoxItem_TaxByNetValue.Text = value.TaxByNetValue.Value.ToString();
                switchButton_TaxLines.ValueChanged += switchButton_TaxLines_ValueChanged;
                LDataThis = new BindingList<T_INVDET>(value.T_INVDETs).ToList();
                if (value.RoomNo.HasValue)
                {
                    txtTable.Tag = value.RoomNo.Value;
                    txtTable.Value = int.Parse(db.StockRommID(value.RoomNo.Value).RomeNo.ToString());
                }
                else
                {
                    txtTable.Tag = "1";
                    txtTable.Value = 0;
                }
                txtPersons.Value = value.RoomPerson.Value;
                SetLines(LDataThis);
                TableTyp();
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
                FlxInv.Rows.Count = 1;
                FlxInv.Rows.Count = listDet.Count * 2 + 1;
                FlxInv.Cols[27].Visible = false;
                FlxInv.Cols[35].Visible = false;
                int i = 0;
                for (int iiCnt = 1; iiCnt <= FlxInv.Rows.Count; iiCnt += 2)
                {
                    if (i >= listDet.Count)
                    {
                        break;
                    }
                    _InvDet = listDet[i];
                    FlxInv.Rows[iiCnt].Height = 35;
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
                    FlxInv.SetData(iiCnt, 27, _InvDet.DatExper ?? "");
                    if ((_InvDet.DatExper ?? "") != "" || (_InvDet.RunCod ?? "") != "")
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
                    FlxInv.SetData(iiCnt, 31, _InvDet.Amount.Value);
                    FlxInv.SetData(iiCnt, 35, _InvDet.RunCod.Trim());
                    FlxInv.SetData(iiCnt, 36, _InvDet.LineDetails.Trim());
                    FlxInv.SetData(iiCnt, 38, _InvDet.ItmTax.Value);
                    listStkQty = (from t in db.T_STKSQTies
                                  where t.storeNo == (int?)_InvDet.StoreNo.Value
                                  where t.itmNo == _InvDet.ItmNo.Trim()
                                  select t).ToList();
                    if (listStkQty.Count != 0)
                    {
                        _StksQty = listStkQty[0];
                        FlxInv.SetData(iiCnt, 24, _InvDet.RealQty.Value + _StksQty.stkQty.Value);
                    }
                    if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                    {
                        FlxInv.MergedRanges.Add(FlxInv.GetCellRange(iiCnt + 1, 37, iiCnt + 1, 2));
                    }
                    else
                    {
                        FlxInv.MergedRanges.Add(FlxInv.GetCellRange(iiCnt + 1, 37, iiCnt + 1, 4));
                    }
                    FlxInv.Rows[iiCnt + 1].Height = 33;
                    if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                    {
                        FlxInv.SetData(iiCnt + 1, 2, _InvDet.LineDetails);
                    }
                    else
                    {
                        FlxInv.SetData(iiCnt + 1, 4, _InvDet.LineDetails);
                    }
                    if (!VarGeneral.TString.ChkStatShow(_SysSetting.LineDetailSts, 26))
                    {
                        FlxInv.Rows[iiCnt + 1].Visible = false;
                    }
                    i++;
                }
            }
            catch
            {
                MessageBox.Show((LangArEn == 0) ? "حدث خطأ أثناء تعبئة الأسطر .." : "An error occurred while filling lines ..", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
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
                    dataGridView_ItemDet.SetData(iiCnt, 27, _SInvDet.SDatExper ?? "");
                    dataGridView_ItemDet.SetData(iiCnt, 32, _SInvDet.SItmTyp.Value);
                    dataGridView_ItemDet.SetData(iiCnt, 31, _SInvDet.SAmount.Value);
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
        private bool ValidData()
        {
            if (textBox_ID.Text == "0" || textBox_ID.Text == "")
            {
                MessageBox.Show((LangArEn == 0) ? "لا يمكن الحفظ بدون رقم الفاتورة - السند" : "Can not save without the invoice number", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                textBox_ID.Focus();
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
                txtPaymentLoc.Focus();
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
            if (checkBox_CostGaidTax.Checked && txtTotTax.Value <= 0.0)
            {
                MessageBox.Show((LangArEn == 0) ? "لايمكن انشاء سند محاسبي بقيمة الضريبة واجمالي الضريبة يساوي صفر" : "You can not set up an accounting support tax and the total tax is equal to zero.", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                superTabControl_Info.SelectedTabIndex = 3;
                return false;
            }
            for (int iiCnt = 1; iiCnt < FlxInv.Rows.Count; iiCnt++)
            {
                if (!(string.Concat(FlxInv.GetData(iiCnt, 1)) != ""))
                {
                    continue;
                }
                for (int i = 1; i < 7; i++)
                {
                    if (string.Concat(FlxInv.GetData(iiCnt, i)) == "")
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
                if (FlxInv.Cols[27].Visible)
                {
                    if (!VarGeneral.TString.ChkStatShow(VarGeneral.UserPassQty, 7) && VarGeneral.CheckDate(string.Concat(FlxInv.GetData(iiCnt, 27))) && string.Concat(FlxInv.GetData(iiCnt, 35)) == "")
                    {
                        MessageBox.Show((LangArEn == 0) ? "لا يمكن حفظ تاريخ الصلاحية بدون رقم التصنيع .. الرجاء مراجعة صلاحيات المستخدم" : "Can not save the expiration date without Make No .. please see User Permissions", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        FlxInv.Row = iiCnt;
                        FlxInv.Col = 35;
                        FlxInv.Focus();
                        return false;
                    }
                    if (!VarGeneral.TString.ChkStatShow(VarGeneral.UserPassQty, 8) && !VarGeneral.CheckDate(string.Concat(FlxInv.GetData(iiCnt, 27))) && string.Concat(FlxInv.GetData(iiCnt, 35)) != "")
                    {
                        MessageBox.Show((LangArEn == 0) ? "لا يمكن حفظ رقم التصنيع بدون تاريخ الصلاحية .. الرجاء مراجعة صلاحيات المستخدم" : "Can not save the Make No without expiration date .. please see User Permissions", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        FlxInv.Row = iiCnt;
                        FlxInv.Col = 27;
                        FlxInv.Focus();
                        return false;
                    }
                }
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
                if (q.StopInvTyp == 1 && checkBox_Chash.Checked)
                {
                    MessageBox.Show((LangArEn == 0) ? "لا يمكن إتمام العملية .. وذلك لأن حساب العميل غير مصرح له البيع بالنقدي " : "Can not complete the operation .. This is because the customer's account is not authorized to Cash Sales", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return false;
                }
            }
            if ((VarGeneral.SSSLev == "R" || VarGeneral.SSSLev == "C" || VarGeneral.SSSLev == "H") && txtTable.Value == 0 && State == FormState.New)
            {
                MessageBox.Show((LangArEn == 0) ? "لا يمكن الحفظ بدون تحديد رقم الطاولة" : "Can not save without Table No", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                txtTable.Focus();
                return false;
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
            return true;
        }
        private bool UpdateTableNo()
        {
            if (data_this.RoomNo.HasValue && data_this.RoomSts.Value && data_this.RoomNo.Value == 1 && data_this.OrderTyp.Value != 0)
            {
                if (txtTable.Value == 0)
                {
                    MessageBox.Show((LangArEn == 0) ? "يرجى تحديد الطاولة قبل عملية الحفظ" : "Please Selected Table", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    txtTable.Focus();
                    return false;
                }
                List<T_Room> newData = (from t in db.T_Rooms
                                        where t.ID == int.Parse(txtTable.Tag.ToString())
                                        where !t.RomeStatus.Value
                                        select t).ToList();
                if (newData.Count > 0)
                {
                    newData.First().RomeStatus = true;
                    if (!string.IsNullOrEmpty(textBox_WaiterName.Text))
                    {
                        newData.First().waiterNo = int.Parse(textBox_WaiterName.Tag.ToString());
                    }
                    else
                    {
                        newData.First().waiterNo = null;
                    }
                    db.Log = VarGeneral.DebugLog;
                    db.SubmitChanges(ConflictMode.ContinueOnConflict);
                }
            }
            return true;
        }
        private bool SaveData()
        {
            isPrintSts = false;
            if (State == FormState.New)
            {
                dbInstance = null;
            }
            if (!ValidData())
            {
                return false;
            }
            try
            {
                IDatabase db_ = Database.GetDatabase(VarGeneral.BranchCS);
#pragma warning disable CS0219 // The variable 'mndExtrnal' is assigned but its value is never used
                bool mndExtrnal = false;
#pragma warning restore CS0219 // The variable 'mndExtrnal' is assigned but its value is never used
#pragma warning disable CS0219 // The variable 'mndNo' is assigned but its value is never used
                int mndNo = 0;
#pragma warning restore CS0219 // The variable 'mndNo' is assigned but its value is never used
                mndExtrnal = false;
                mndNo = 0;
                int i;
                for (i = 0; i < ItemDetRemoved.Count; i++)
                {
                    try
                    {
                        List<T_SINVDET> q = db.T_SINVDETs.Where((T_SINVDET t) => t.SInvId == (int?)ItemDetRemoved[i]).ToList();
                        for (int iicnt = 0; iicnt < q.Count; iicnt++)
                        {
                            db_.ClearParameters();
                            db_.AddParameter("SInvDet_ID", DbType.Int32, q[iicnt].SInvDet_ID);
                            db_.ExecuteNonQuery(storedProcedure: true, "S_T_SINVDET_DELETE");
                        }
                    }
                    catch
                    {
                        return false;
                    }
                }
                if (State == FormState.New)
                {
                    GetData();
                    try
                    {
                        if (txtTable.Value == 0)
                        {
                            data_this.RoomNo = 1;
                            data_this.RoomSts = false;
                        }
                        else
                        {
                            data_this.RoomNo = int.Parse(txtTable.Tag.ToString());
                            data_this.RoomSts = true;
                        }
                        GetInvSetting();
                        textBox_ID.TextChanged -= textBox_ID_TextChanged;
                        T_INVHED newData = db.StockInvHead(VarGeneral.InvTyp, data_this.InvNo);
                        if (!string.IsNullOrEmpty(newData.InvNo) || newData.InvHed_ID > 0)
                        {
                            string max = "";
                            dbInstance = null;
                            max = db.MaxInvheadNo.ToString();
                            MessageBox.Show("الرمز مستخدم من قبل.\n سيتم الحفظ برقم جديد [" + max + "]", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            textBox_ID.Text = max ?? "";
                            data_this.InvNo = max ?? "";
                        }
                        textBox_ID.TextChanged += textBox_ID_TextChanged;
                        data_this.IfRet = 0;
                        data_this.DATE_CREATED = DateTime.Now;
                        data_this.SalsManNo = VarGeneral.UserNumber;
                        data_this.UserNew = VarGeneral.UserNumber;
                        data_this.SalsManNam = "";
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
                           dbHead.AddParameter("CusVenTaxNo", DbType.String, data_this.CusVenTaxNo);
                     dbHead.AddParameter("IS_ServiceBill", DbType.Boolean, data_this.IS_ServiceBill);
  dbHead.ExecuteNonQuery(storedProcedure: true, "S_T_INVHED_INSERT");
                        data_this.InvHed_ID = int.Parse(dbHead.GetParameterValue("InvHed_ID").ToString());
                    }
                    catch (SqlException ex3)
                    {
                        string max = "";
                        dbInstance = null;
                        max = db.MaxInvheadNo.ToString();
                        int maxSeq = 1;
                        maxSeq = db.MaxInvheadNoSequence;
                        if (ex3.Number == 2627)
                        {
                            MessageBox.Show("الرمز مستخدم من قبل.\n سيتم الحفظ برقم جديد [" + max + "]", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            textBox_ID.Text = max ?? "";
                            data_this.InvNo = max ?? "";
                            Button_Save_Click(null, null);
                        }
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                    if (data_this.RoomNo.Value > 1 && !string.IsNullOrEmpty(txtTable.Tag.ToString()))
                    {
                        List<T_Room> q2 = db.T_Rooms.Where((T_Room t) => t.ID == int.Parse(txtTable.Tag.ToString())).ToList();
                        if (q2.Count > 0)
                        {
                            T_Room vData = new T_Room();
                            vData = q2.First();
                            vData.RomeStatus = true;
                            if (!string.IsNullOrEmpty(textBox_WaiterName.Text))
                            {
                                vData.waiterNo = int.Parse(textBox_WaiterName.Tag.ToString());
                            }
                            else
                            {
                                vData.waiterNo = null;
                            }
                            db.Log = VarGeneral.DebugLog;
                            db.SubmitChanges(ConflictMode.ContinueOnConflict);
                        }
                    }
                }
                else
                {
                    if (!UpdateTableNo())
                    {
                        return false;
                    }
                    GetData();
                    if (data_this.RoomNo.Value > 1 && !string.IsNullOrEmpty(txtTable.Tag.ToString()))
                    {
                        List<T_Room> q2 = db.T_Rooms.Where((T_Room t) => t.ID == int.Parse(txtTable.Tag.ToString())).ToList();
                        if (q2.Count > 0)
                        {
                            T_Room vData = new T_Room();
                            vData = q2.First();
                            if (!string.IsNullOrEmpty(textBox_WaiterName.Text))
                            {
                                vData.waiterNo = int.Parse(textBox_WaiterName.Tag.ToString());
                            }
                            else
                            {
                                vData.waiterNo = null;
                            }
                            db.Log = VarGeneral.DebugLog;
                            db.SubmitChanges(ConflictMode.ContinueOnConflict);
                        }
                    }
                    vSINVDIT.Clear();
                    for (int j = 0; j < data_this.T_INVDETs.Count; j++)
                    {
                        if (data_this.T_INVDETs[j].ItmTyp.Value == 2)
                        {
                            vSINVDIT.Add(data_this.T_INVDETs[j].InvDet_ID, data_this.T_INVDETs[j].T_SINVDETs.ToList());
                        }
                    }
                    for (int j = 0; j < data_this.T_INVDETs.Count; j++)
                    {
                        if (data_this.T_INVDETs[j].ItmTyp.Value == 2)
                        {
                            for (int iicnt = 0; iicnt < data_this.T_INVDETs[j].T_SINVDETs.Count; iicnt++)
                            {
                                db_.ClearParameters();
                                db_.AddParameter("SInvDet_ID", DbType.Int32, data_this.T_INVDETs[j].T_SINVDETs[iicnt].SInvDet_ID);
                                db_.ExecuteNonQuery(storedProcedure: true, "S_T_SINVDET_DELETE");
                            }
                        }
                        db_.ClearParameters();
                        db_.AddParameter("InvDet_ID", DbType.Int32, data_this.T_INVDETs[j].InvDet_ID);
                        db_.ExecuteNonQuery(storedProcedure: true, "S_T_INVDET_DELETE");
                    }
                    data_this.SalsManNam = VarGeneral.UserNumber;
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
                     dbHead.AddParameter("CusVenTaxNo", DbType.String, data_this.CusVenTaxNo);
                        dbHead.AddParameter("IS_ServiceBill", DbType.Boolean, data_this.IS_ServiceBill);
 dbHead.ExecuteNonQuery(storedProcedure: true, "S_T_INVHED_UPDATE");
                                 }
                int iiCnt = 0;
                try
                {
                    for (iiCnt = 1; iiCnt < FlxInv.Rows.Count; iiCnt++)
                    {
                        if (FlxInv.GetData(iiCnt, 1) == null)
                        {
                            continue;
                        }
                        db_.ClearParameters();
                        db_.AddParameter("InvDet_ID", DbType.Int32, 0);
                        db_.AddParameter("InvNo", DbType.String, textBox_ID.Text.Trim());
                        db_.AddParameter("InvId", DbType.Int32, data_this.InvHed_ID);
                        db_.AddParameter("InvSer", DbType.Int32, iiCnt);
                        db_.AddParameter("ItmNo", DbType.String, string.Concat(FlxInv.GetData(iiCnt, 1)));
                        db_.AddParameter("Cost", DbType.Double, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 10)))));
                        db_.AddParameter("Qty", DbType.Double, 0.0 - double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 7)))));
                        db_.AddParameter("ItmDes", DbType.String, string.Concat(FlxInv.GetData(iiCnt, 2)));
                        db_.AddParameter("ItmUnt", DbType.String, string.Concat(FlxInv.GetData(iiCnt, 3)));
                        db_.AddParameter("ItmDesE", DbType.String, string.Concat(FlxInv.GetData(iiCnt, 4)));
                        db_.AddParameter("ItmUntE", DbType.String, string.Concat(FlxInv.GetData(iiCnt, 5)));
                        db_.AddParameter("ItmUntPak", DbType.Double, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 11)))));
                        db_.AddParameter("StoreNo", DbType.Int32, int.Parse(VarGeneral.TString.TEmpty(FlxInv.GetData(iiCnt, 6).ToString() ?? "")));
                        db_.AddParameter("Price", DbType.Double, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 8)))));
                        db_.AddParameter("Amount", DbType.Double, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 31)))));
                        db_.AddParameter("RealQty", DbType.Double, 0.0 - double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 12)))));
                        db_.AddParameter("itmInvDsc", DbType.Double, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 13)))));
                        if (VarGeneral.CheckDate(string.Concat(FlxInv.GetData(iiCnt, 27))))
                        {
                            db_.AddParameter("DatExper", DbType.String, string.Concat(FlxInv.GetData(iiCnt, 27)));
                        }
                        else
                        {
                            db_.AddParameter("DatExper", DbType.String, "");
                        }
                        db_.AddParameter("ItmDis", DbType.Double, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 9)))));
                        db_.AddParameter("ItmTyp", DbType.Int32, int.Parse("0" + FlxInv.GetData(iiCnt, 32)));
                        db_.AddParameter("ItmIndex", DbType.Int32, 0);
                        db_.AddParameter("ItmWight", DbType.Double,(double) 0);
                        db_.AddParameter("ItmWight_T", DbType.Double, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 34)))));
                        if (!string.IsNullOrEmpty(string.Concat(FlxInv.GetData(iiCnt, 35))))
                        {
                            db_.AddParameter("RunCod", DbType.String, string.Concat(FlxInv.GetData(iiCnt, 35)));
                        }
                        else
                        {
                            db_.AddParameter("RunCod", DbType.String, "");
                        }
                        if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                        {
                            db_.AddParameter("LineDetails", DbType.String, string.Concat(FlxInv.GetData(iiCnt + 1, 2)));
                        }
                        else
                        {
                            db_.AddParameter("LineDetails", DbType.String, string.Concat(FlxInv.GetData(iiCnt + 1, 4)));
                        }
                        db_.AddParameter("Serial_Key", DbType.String, "");
                          db_.AddParameter("ItmTax", DbType.Double,double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 38)))));
                        db_.ExecuteNonQuery(storedProcedure: true, "S_T_INVDET_INSERT");
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
                            Stock_DataDataContext dbc_ = new Stock_DataDataContext(VarGeneral.BranchCS);
                            SInvHed = (from t in dbc_.T_INVDETs
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
                            if (dataGridView_ItemDet.GetData(j, 1) != null)
                            {
                                db_.ClearParameters();
                                db_.AddParameter("SInvDet_ID", DbType.Int32, 0);
                                db_.AddParameter("SInvNo", DbType.String, textBox_ID.Text.Trim());
                                db_.AddParameter("SInvId", DbType.Int32, SInvHed);
                                db_.AddParameter("SInvSer", DbType.Int32, j);
                                db_.AddParameter("SItmNo", DbType.String, string.Concat(dataGridView_ItemDet.GetData(j, 1)));
                                db_.AddParameter("SCost", DbType.Double, double.Parse(VarGeneral.TString.TEmpty(string.Concat(dataGridView_ItemDet.GetData(j, 10)))));
                                db_.AddParameter("SQty", DbType.Double, 0.0 - double.Parse(VarGeneral.TString.TEmpty(string.Concat(dataGridView_ItemDet.GetData(j, 7)))));
                                db_.AddParameter("SItmDes", DbType.String, string.Concat(dataGridView_ItemDet.GetData(j, 2)));
                                db_.AddParameter("SItmUnt", DbType.String, string.Concat(dataGridView_ItemDet.GetData(j, 3)));
                                db_.AddParameter("SItmDesE", DbType.String, string.Concat(dataGridView_ItemDet.GetData(j, 4)));
                                db_.AddParameter("SItmUntE", DbType.String, string.Concat(dataGridView_ItemDet.GetData(j, 5)));
                                db_.AddParameter("SItmUntPak", DbType.Double, double.Parse(VarGeneral.TString.TEmpty(string.Concat(dataGridView_ItemDet.GetData(j, 11)))));
                                db_.AddParameter("SStoreNo", DbType.Int32, int.Parse(VarGeneral.TString.TEmpty(dataGridView_ItemDet.GetData(j, 6).ToString() ?? "")));
                                db_.AddParameter("SPrice", DbType.Double, double.Parse(VarGeneral.TString.TEmpty(string.Concat(dataGridView_ItemDet.GetData(j, 8)))));
                                db_.AddParameter("SAmount", DbType.Double, double.Parse(VarGeneral.TString.TEmpty(string.Concat(dataGridView_ItemDet.GetData(j, 31)))));
                                db_.AddParameter("SRealQty", DbType.Double, 0.0 - double.Parse(VarGeneral.TString.TEmpty(string.Concat(dataGridView_ItemDet.GetData(j, 12)))));
                                db_.AddParameter("SitmInvDsc", DbType.Double, double.Parse(VarGeneral.TString.TEmpty(string.Concat(dataGridView_ItemDet.GetData(j, 13)))));
                                if (VarGeneral.CheckDate(string.Concat(dataGridView_ItemDet.GetData(j, 27))))
                                {
                                    db_.AddParameter("SDatExper", DbType.String, string.Concat(dataGridView_ItemDet.GetData(j, 27)));
                                }
                                else
                                {
                                    db_.AddParameter("SDatExper", DbType.String, "");
                                }
                                db_.AddParameter("SItmDis", DbType.Double, double.Parse(VarGeneral.TString.TEmpty(string.Concat(dataGridView_ItemDet.GetData(j, 9)))));
                                db_.AddParameter("SItmTyp", DbType.Int32, int.Parse("0" + dataGridView_ItemDet.GetData(j, 32)));
                                db_.AddParameter("SItmIndex", DbType.Int32, 0);
                                db_.AddParameter("SItmWight", DbType.Double, double.Parse(VarGeneral.TString.TEmpty(string.Concat(dataGridView_ItemDet.GetData(j, 33)))));
                                db_.AddParameter("SItmWight_T", DbType.Double, double.Parse(VarGeneral.TString.TEmpty(string.Concat(dataGridView_ItemDet.GetData(j, 34)))));
                                db_.AddParameter("SQtyDef", DbType.Double, double.Parse(VarGeneral.TString.TEmpty(string.Concat(dataGridView_ItemDet.GetData(j, 29)))));
                                db_.AddParameter("SPriceDef", DbType.Double, double.Parse(VarGeneral.TString.TEmpty(string.Concat(dataGridView_ItemDet.GetData(j, 17)))));
                                db_.AddParameter("SInvIdHEAD", DbType.Int32, data_this.InvHed_ID);
                                db_.AddParameter("SItmTax", DbType.Double,(double) 0);
                                db_.ExecuteNonQuery(storedProcedure: true, "S_T_SINVDET_INSERT");
                            }
                        }
                    }
                }
                catch (Exception ex4)
                {
                    VarGeneral.DebLog.writeLog("LinesInv_Save_WaiterMenue:", ex4, enable: true);
                    MessageBox.Show(ex4.Message);
                    return false;
                }
                dbInstance = null;
                try
                {
                    db.ExecuteCommand("update T_INVHED set RoomNo = 1 where RoomSts = 0");
                }
                catch
                {
                }
            }
            catch (Exception ex4)
            {
                MessageBox.Show(ex4.Message);
                return false;
            }
            return true;
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
            data_this.PaymentOrderTyp = 0;
            data_this.InvCashPayNm = "";
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
            if (State == FormState.New)
            {
                data_this.AdminLock = true;
            }
            else
            {
                data_this.AdminLock = switchButton_Lock.Value;
            }
            data_this.InvCashPay = 0;
            data_this.InvCash = checkBox_Chash.Text;
            data_this.InvCost = txtInvCost.Value;
            try
            {
                data_this.InvCstNo = int.Parse(CmbCostC.SelectedValue.ToString());
            }
            catch
            {
                data_this.InvCstNo = null;
            }
            data_this.IfEnter = 0;
            data_this.EstDat = "";
            data_this.DeleteDate = "";
            data_this.DeleteTime = "";
            data_this.InvDisPrs = txtDiscountP.Value;
            data_this.InvDisVal = txtDiscountVal.Value;
            data_this.InvDisValLocCur = txtDiscountValLoc.Value;
            data_this.InvNet = txtDueAmount.Value;
            data_this.InvNetLocCur = txtDueAmountLoc.Value;
            data_this.InvQty = txtTotalQ.Value;
            data_this.InvTot = txtTotalAm.Value;
            data_this.InvTotLocCur = txtTotalAmLoc.Value;
            data_this.InvTyp = VarGeneral.InvTyp;
            data_this.IfDel = 0;
            if (State == FormState.New)
            {
                data_this.LTim = DateTime.Now.ToString("HH:mm");
            }
            else
            {
                data_this.LTim = txtTime.Text;
            }
            if (CmbLegate.SelectedIndex > 0)
            {
                data_this.MndNo = int.Parse(CmbLegate.SelectedValue.ToString());
            }
            else
            {
                data_this.MndNo = null;
            }
            data_this.RefNo = txtRef.Text;
            data_this.MndExtrnal = false;
            listCurency = db.Fillcurency_2("").ToList();
            if (listCurency.Count > 0)
            {
                _Curency = listCurency[0];
            }
            data_this.ArbTaf = ScriptNumber1.ScriptNum(decimal.Parse(VarGeneral.TString.TEmpty(txtDueAmountLoc.Text ?? "")));;
            data_this.EngTaf = ScriptNumber1.TafEng(decimal.Parse(VarGeneral.TString.TEmpty(txtDueAmountLoc.Text ?? "")));
            data_this.DATE_MODIFIED = DateTime.Now;
            data_this.CreditPay = doubleInput_CreditLoc.Value;
            data_this.NetworkPay = doubleInput_NetWorkLoc.Value;
            data_this.CashPayLocCur = txtPaymentLoc.Value;
            data_this.CreditPayLocCur = doubleInput_CreditLoc.Value;
            data_this.NetworkPayLocCur = doubleInput_NetWorkLoc.Value;
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
            data_this.Puyaid = 0.0;
            data_this.Remming = 0.0;
            data_this.CompanyID = 1;
            data_this.tailor20 = "0";
            try
            {
                if (!string.IsNullOrEmpty(txtTable.Tag.ToString()) && txtTable.Value > 0)
                {
                    data_this.RoomNo = int.Parse(txtTable.Tag.ToString());
                }
                else
                {
                    data_this.RoomNo = 1;
                }
            }
            catch
            {
            }
            data_this.OrderTyp = 0;
            data_this.RoomPerson = txtPersons.Value;
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
            data_this.InvValGaidDis = 0.0;
            data_this.InvValGaidDislLoc = 0.0;
            data_this.IsDisGaid = false;
            data_this.IsDisUse1 = false;
            data_this.InvComm = 0.0;
            data_this.InvCommLoc = 0.0;
            data_this.IsCommUse = false;
            data_this.IsCommGaid = false;
            data_this.DesPointsValue = 0.0;
            data_this.DesPointsValueLocCur = 0.0;
            data_this.PointsCount = 0.0;
            data_this.IsPoints = false;
            try
            {
                if (State == FormState.New && data_this.RoomNo > 1)
                {
                    T_INVHED c = db.StockInvHead(VarGeneral.InvTyp, data_this.InvNo);
                    List<T_INVHED> q2 = (from t in db.T_INVHEDs
                                         where t.IfDel == (int?)0
                                         where t.InvTyp == (int?)VarGeneral.InvTyp
                                         where t.RoomNo == data_this.RoomNo
                                         orderby t.InvNo
                                         select t).ToList();
                    if (q2.Count > 0)
                    {
                        data_this.AdminLock = q2[0].AdminLock.Value;
                    }
                }
            }
            catch
            {
            }
            return data_this;
        }
        private void FlxInv_AfterEdit(object sender, RowColEventArgs e)
        {
            double ItmDis = 0.0;
            double ItmAddTax = 0.0;
            ItmDis = double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 8)))) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 9)))) / 100.0);
            ItmAddTax = Math.Round(double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 8)))) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 38)))) / 100.0), VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2);
            if (!switchButton_TaxLines.Value || switchButton_TaxByTotal.Value)
            {
                ItmAddTax = 0.0;
            }
            if (e.Col == 1)
            {
                BindDataOfItem();
            }
            else if ((e.Col == 2 || e.Col == 4) && ((string)FlxInv.GetData(e.Row, 1) == "" || FlxInv.GetData(e.Row, 1) == null))
            {
                if (FlxInv.Rows[e.Row].Height != 33)
                {
                    FlxInv.SetData(e.Row, e.Col, oldItemName);
                }
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
                        FlxInv.SetData(FlxInv.Row, 8, _Items.UntPri1 / RateValue);
                        FlxInv.SetData(FlxInv.Row, 11, _Items.Pack1);
                        break;
                    case 2:
                        FlxInv.SetData(FlxInv.Row, 8, _Items.UntPri2 / RateValue);
                        FlxInv.SetData(FlxInv.Row, 11, _Items.Pack2);
                        break;
                    case 3:
                        FlxInv.SetData(FlxInv.Row, 8, _Items.UntPri3 / RateValue);
                        FlxInv.SetData(FlxInv.Row, 11, _Items.Pack3);
                        break;
                    case 4:
                        FlxInv.SetData(FlxInv.Row, 8, _Items.UntPri4 / RateValue);
                        FlxInv.SetData(FlxInv.Row, 11, _Items.Pack4);
                        break;
                    case 5:
                        FlxInv.SetData(FlxInv.Row, 8, _Items.UntPri5 / RateValue);
                        FlxInv.SetData(FlxInv.Row, 11, _Items.Pack5);
                        break;
                }
                Pack = ItemIndex;
                BindDataofItemPrice();
                FlxInv.SetData(e.Row, 12, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 11)))));
                FlxInv.SetData(e.Row, 31, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 8)))) - ItmDis + ItmAddTax);
                if (switchButton_TaxByTotal.Value && switchButton_TaxLines.Value && double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 31)))) > 0.0)
                {
                    ItmAddTax = Math.Round((double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 8)))) - ItmDis) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 38)))) / 100.0), VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2);
                    FlxInv.SetData(e.Row, 31, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 31)))) + ItmAddTax);
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
                    ItmAddTax = Math.Round(double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 8)))) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 38)))) / 100.0), VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2);
                    if (!switchButton_TaxLines.Value || switchButton_TaxByTotal.Value)
                    {
                        ItmAddTax = 0.0;
                    }
                    FlxInv.SetData(e.Row, 31, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 8)))) - ItmDis + ItmAddTax);
                    if (switchButton_TaxByTotal.Value && switchButton_TaxLines.Value && double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 31)))) > 0.0)
                    {
                        ItmAddTax = Math.Round((double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 8)))) - ItmDis) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 38)))) / 100.0), VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2);
                        FlxInv.SetData(e.Row, 31, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 31)))) + ItmAddTax);
                    }
                }
                catch
                {
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
                    if (double.Parse(FlxInv.GetData(e.Row, 24).ToString()) <= 0.0)
                    {
                        if (!VarGeneral.TString.ChkStatShow(VarGeneral.UserPassQty, 1))
                        {
                            MessageBox.Show((LangArEn == 0) ? ("لا يمكن البيع والكمية  " + double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 24)))) + "تأكد من صلاحيات المستخدمين") : ("Can't Sale and the Quantity " + double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 24)))) + " Check the Users Authorizations"), VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            FlxInv.SetData(e.Row, 7, 0);
                        }
                    }
                    else if (double.Parse(FlxInv.GetData(e.Row, 24).ToString()) < RealQ && !VarGeneral.TString.ChkStatShow(VarGeneral.UserPassQty, 1))
                    {
                        MessageBox.Show((LangArEn == 0) ? ("لا يمكن البيع بأكثر من الكمية  " + double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 24)))) + "راجع صلاحيات المستخدمين") : ("Can't Sale More Than available Quantity " + double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 24)))) + " Check the Users Authorizations"), VarGeneral.ProdectNam);
                        FlxInv.SetData(e.Row, 7, 0);
                    }
                }
                if (e.Col == 8 && double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 10)))) != 0.0)
                {
                    if (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 10)))) > double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 8)))))
                    {
                        if (!VarGeneral.TString.ChkStatShow(VarGeneral.UserPassQty, 2))
                        {
                            MessageBox.Show((LangArEn == 0) ? "لا يمكن البيع بأقل من سعر التكلفة .. راجع صلاحيات المستخدمين" : "Can't Sale Less Then Cost Price ... Check the Users Authorizations", VarGeneral.ProdectNam);
                            FlxInv.SetData(e.Row, 8, PriceLoc);
                        }
                    }
                    else
                    {
                        PermissionPrice(e.Row, 8, _Sts: true);
                    }
                }
                FlxInv.SetData(e.Row, 12, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 11)))));
                FlxInv.SetData(e.Row, 31, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 8)))) - ItmDis + ItmAddTax);
                if (switchButton_TaxByTotal.Value && switchButton_TaxLines.Value && double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 31)))) > 0.0)
                {
                    ItmAddTax = Math.Round((double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 8)))) - ItmDis) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 38)))) / 100.0), VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2);
                    FlxInv.SetData(e.Row, 31, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 31)))) + ItmAddTax);
                }
                chekReptItem(Col_1: false);
            }
            else if (e.Col == 9)
            {
                FlxInv.SetData(e.Row, 31, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 8)))) - ItmDis + ItmAddTax);
                if (switchButton_TaxByTotal.Value && switchButton_TaxLines.Value && double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 31)))) > 0.0)
                {
                    ItmAddTax = Math.Round((double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 8)))) - ItmDis) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 38)))) / 100.0), VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2);
                    FlxInv.SetData(e.Row, 31, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 31)))) + ItmAddTax);
                }
            }
            else if (e.Col == 31)
            {
                if (switchButton_TaxByTotal.Value && switchButton_TaxLines.Value && double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 31)))) > 0.0)
                {
                    ItmAddTax = Math.Round((double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 8)))) - ItmDis) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 38)))) / 100.0), VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2);
                }
                if (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 31)))) != Math.Round(double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 8)))) - ItmDis + ItmAddTax, VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2))
                {
                    if (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7)))) == 0.0)
                    {
                        MessageBox.Show((LangArEn == 0) ? "يجب تحديد الكمية" : "Must Enter The Quantity", VarGeneral.ProdectNam);
                        FlxInv.SetData(e.Row, 31, 0);
                        FlxInv.Col = 7;
                        FlxInv.Row = e.Row;
                        FlxInv.Focus();
                    }
                    else
                    {
                        FlxInv.SetData(e.Row, 8, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 31)))) / double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7)))));
                        FlxInv.SetData(e.Row, 9, 0);
                    }
                }
                try
                {
                    if (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 10)))) > double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 8)))) && !VarGeneral.TString.ChkStatShow(VarGeneral.UserPassQty, 2))
                    {
                        MessageBox.Show((LangArEn == 0) ? "لا يمكن البيع بأقل من سعر التكلفة .. راجع صلاحيات المستخدمين" : "Can't Sale Less Then Cost Price ... Check the Users Authorizations", VarGeneral.ProdectNam);
                        FlxInv.SetData(e.Row, 8, PriceLoc);
                    }
                }
                catch
                {
                }
                chekReptItem(Col_1: false);
            }
            else if (e.Col == 37)
            {
                if (Convert.ToBoolean(FlxInv.GetData(e.Row, e.Col)))
                {
                    if (FlxInv.Rows[e.Row].Height > 33)
                    {
                        FlxInv.SetCellStyle(e.Row, 2, "SubTotal0");
                        FlxInv.SetCellStyle(e.Row, 4, "SubTotal0");
                    }
                    else
                    {
                        FlxInv.SetCellStyle(e.Row - 1, 2, "SubTotal0");
                        FlxInv.SetCellStyle(e.Row - 1, 4, "SubTotal0");
                    }
                }
                else
                {
                    FlxInv.SetCellStyle(e.Row, 2, "SelectedRowHeader");
                    FlxInv.SetCellStyle(e.Row, 4, "SelectedRowHeader");
                }
            }
            else if (e.Col == 33)
            {
                if (Convert.ToBoolean(FlxInv.GetData(e.Row, 33)))
                {
                    ItmDis = 0.0;
                    FlxInv.SetData(e.Row, 8, 0);
                    FlxInv.SetData(e.Row, 9, 0);
                    FlxInv.SetData(e.Row, 38, 0);
                    FlxInv.SetData(e.Row, 31, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 8)))) - ItmDis + ItmAddTax);
                }
            }
            else if (e.Col == 38)
            {
                FlxInv.SetData(e.Row, 31, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 8)))) - ItmDis + ItmAddTax);
                if (switchButton_TaxByTotal.Value && switchButton_TaxLines.Value && double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 31)))) > 0.0)
                {
                    ItmAddTax = Math.Round((double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 8)))) - ItmDis) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 38)))) / 100.0), VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2);
                    FlxInv.SetData(e.Row, 31, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 31)))) + ItmAddTax);
                }
            }
            try
            {
                if (VarGeneral.SSSLev != "R" && VarGeneral.SSSLev != "C" && VarGeneral.SSSLev != "H" && FlxInv.Rows[e.Row].Height == 33)
                {
                    FlxInv.SetData(e.Row - 1, 36, FlxInv.GetData(e.Row, (LangArEn == 0) ? 2 : 4));
                }
            }
            catch
            {
            }
            VarGeneral.Flush();
            GetInvTot();
        }
        private void PermissionPrice(int _row, int _col, bool _Sts)
        {
            try
            {
                double vPri;
                List<T_Item> q;
                if (int.Parse(permission.RepInv2.Trim()) > 0 && int.Parse(permission.RepInv4.Trim()) == 0)
                {
                    vPri = 0.0;
                    q = db.T_Items.Where((T_Item t) => t.Itm_No == FlxInv.GetData(_row, 1).ToString()).ToList();
                    if (q.Count <= 0)
                    {
                        return;
                    }
                    if (int.Parse(permission.RepInv2.Trim()) == 1)
                    {
                        if (q.FirstOrDefault().Unit1.HasValue && q.FirstOrDefault().T_Unit.Arb_Des == FlxInv.GetData(_row, 3).ToString())
                        {
                            vPri = q.FirstOrDefault().UntPri1.Value;
                        }
                        if (q.FirstOrDefault().Unit2.HasValue && q.FirstOrDefault().T_Unit1.Arb_Des == FlxInv.GetData(_row, 3).ToString())
                        {
                            vPri = q.FirstOrDefault().UntPri2.Value;
                        }
                        if (q.FirstOrDefault().Unit3.HasValue && q.FirstOrDefault().T_Unit2.Arb_Des == FlxInv.GetData(_row, 3).ToString())
                        {
                            vPri = q.FirstOrDefault().UntPri3.Value;
                        }
                        if (q.FirstOrDefault().Unit4.HasValue && q.FirstOrDefault().T_Unit3.Arb_Des == FlxInv.GetData(_row, 3).ToString())
                        {
                            vPri = q.FirstOrDefault().UntPri4.Value;
                        }
                        if (q.FirstOrDefault().Unit5.HasValue && q.FirstOrDefault().T_Unit4.Arb_Des == FlxInv.GetData(_row, 3).ToString())
                        {
                            vPri = q.FirstOrDefault().UntPri5.Value;
                        }
                        if (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(_row, 8)))) != vPri && vPri > 0.0)
                        {
                            if (_Sts)
                            {
                                MessageBox.Show((LangArEn == 0) ? "يجب البيع بسعر البيع الإفتراضي .. راجع صلاحيات المستخدمين" : "You must sell at default selling .. Check the Users Authorizations", VarGeneral.ProdectNam);
                            }
                            FlxInv.SetData(_row, 8, PriceLoc);
                        }
                        return;
                    }
                    if (int.Parse(permission.RepInv2.Trim()) == 2)
                    {
                        vPri = q.FirstOrDefault().Price1.Value;
                        if (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(_row, 8)))) != vPri && vPri > 0.0)
                        {
                            if (_Sts)
                            {
                                MessageBox.Show((LangArEn == 0) ? "يجب البيع بسعر الجملة .. راجع صلاحيات المستخدمين" : "You must sell at wholesale selling ... Check the Users Authorizations", VarGeneral.ProdectNam);
                            }
                            FlxInv.SetData(_row, 8, vPri);
                        }
                        return;
                    }
                    if (int.Parse(permission.RepInv2.Trim()) == 3)
                    {
                        vPri = q.FirstOrDefault().Price2.Value;
                        if (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(_row, 8)))) != vPri && vPri > 0.0)
                        {
                            if (_Sts)
                            {
                                MessageBox.Show((LangArEn == 0) ? "يجب البيع بسعر الموزع .. راجع صلاحيات المستخدمين" : "You must sell at the distributor selling ... Check the Users Authorizations", VarGeneral.ProdectNam);
                            }
                            FlxInv.SetData(_row, 8, vPri);
                        }
                        return;
                    }
                    if (int.Parse(permission.RepInv2.Trim()) == 4)
                    {
                        vPri = q.FirstOrDefault().Price3.Value;
                        if (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(_row, 8)))) != vPri && vPri > 0.0)
                        {
                            if (_Sts)
                            {
                                MessageBox.Show((LangArEn == 0) ? "يجب البيع بسعر المندوب .. راجع صلاحيات المستخدمين" : "You must sell at delegate selling ... Check the Users Authorizations", VarGeneral.ProdectNam);
                            }
                            FlxInv.SetData(_row, 8, vPri);
                        }
                        return;
                    }
                    if (int.Parse(permission.RepInv2.Trim()) == 5)
                    {
                        vPri = q.FirstOrDefault().Price4.Value;
                        if (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(_row, 8)))) != vPri && vPri > 0.0)
                        {
                            if (_Sts)
                            {
                                MessageBox.Show((LangArEn == 0) ? "يجب البيع بسعر التجزئة .. راجع صلاحيات المستخدمين" : "You must sell at retail selling ... Check the Users Authorizations", VarGeneral.ProdectNam);
                            }
                            FlxInv.SetData(_row, 8, vPri);
                        }
                        return;
                    }
                    vPri = q.FirstOrDefault().Price5.Value;
                    if (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(_row, 8)))) != vPri && vPri > 0.0)
                    {
                        if (_Sts)
                        {
                            MessageBox.Show((LangArEn == 0) ? "يجب البيع بسعر آخر .. راجع صلاحيات المستخدمين" : "You must sell at other selling ... Check the Users Authorizations", VarGeneral.ProdectNam);
                        }
                        FlxInv.SetData(_row, 8, vPri);
                    }
                    return;
                }
                if (int.Parse(permission.RepInv2.Trim()) == 0 && int.Parse(permission.RepInv4.Trim()) > 0)
                {
                    vPri = 0.0;
                    q = db.T_Items.Where((T_Item t) => t.Itm_No == FlxInv.GetData(_row, 1).ToString()).ToList();
                    if (q.Count <= 0)
                    {
                        return;
                    }
                    if (int.Parse(permission.RepInv4.Trim()) == 1)
                    {
                        if (q.FirstOrDefault().Unit1.HasValue && q.FirstOrDefault().T_Unit.Arb_Des == FlxInv.GetData(_row, 3).ToString())
                        {
                            vPri = q.FirstOrDefault().UntPri1.Value;
                        }
                        if (q.FirstOrDefault().Unit2.HasValue && q.FirstOrDefault().T_Unit1.Arb_Des == FlxInv.GetData(_row, 3).ToString())
                        {
                            vPri = q.FirstOrDefault().UntPri2.Value;
                        }
                        if (q.FirstOrDefault().Unit3.HasValue && q.FirstOrDefault().T_Unit2.Arb_Des == FlxInv.GetData(_row, 3).ToString())
                        {
                            vPri = q.FirstOrDefault().UntPri3.Value;
                        }
                        if (q.FirstOrDefault().Unit4.HasValue && q.FirstOrDefault().T_Unit3.Arb_Des == FlxInv.GetData(_row, 3).ToString())
                        {
                            vPri = q.FirstOrDefault().UntPri4.Value;
                        }
                        if (q.FirstOrDefault().Unit5.HasValue && q.FirstOrDefault().T_Unit4.Arb_Des == FlxInv.GetData(_row, 3).ToString())
                        {
                            vPri = q.FirstOrDefault().UntPri5.Value;
                        }
                        if (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(_row, 8)))) > vPri && vPri > 0.0)
                        {
                            if (_Sts)
                            {
                                MessageBox.Show((LangArEn == 0) ? "يجب البيع بسعر لا يتجاوز سعر البيع الإفتراضي .. راجع صلاحيات المستخدمين" : "You must sell at default selling .. Check the Users Authorizations", VarGeneral.ProdectNam);
                            }
                            FlxInv.SetData(_row, 8, PriceLoc);
                        }
                        return;
                    }
                    if (int.Parse(permission.RepInv4.Trim()) == 2)
                    {
                        vPri = q.FirstOrDefault().Price1.Value;
                        if (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(_row, 8)))) > vPri && vPri > 0.0)
                        {
                            if (_Sts)
                            {
                                MessageBox.Show((LangArEn == 0) ? "يجب البيع بسعر لا يتجاوز سعر الجملة .. راجع صلاحيات المستخدمين" : "You must sell at wholesale selling ... Check the Users Authorizations", VarGeneral.ProdectNam);
                            }
                            FlxInv.SetData(_row, 8, vPri);
                        }
                        return;
                    }
                    if (int.Parse(permission.RepInv4.Trim()) == 3)
                    {
                        vPri = q.FirstOrDefault().Price2.Value;
                        if (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(_row, 8)))) > vPri && vPri > 0.0)
                        {
                            if (_Sts)
                            {
                                MessageBox.Show((LangArEn == 0) ? "يجب البيع بسعر لا يتجاوز سعر الموزع .. راجع صلاحيات المستخدمين" : "You must sell at the distributor selling ... Check the Users Authorizations", VarGeneral.ProdectNam);
                            }
                            FlxInv.SetData(_row, 8, vPri);
                        }
                        return;
                    }
                    if (int.Parse(permission.RepInv4.Trim()) == 4)
                    {
                        vPri = q.FirstOrDefault().Price3.Value;
                        if (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(_row, 8)))) > vPri && vPri > 0.0)
                        {
                            if (_Sts)
                            {
                                MessageBox.Show((LangArEn == 0) ? "يجب البيع بسعر لا يتجاوز سعر المندوب .. راجع صلاحيات المستخدمين" : "You must sell at delegate selling ... Check the Users Authorizations", VarGeneral.ProdectNam);
                            }
                            FlxInv.SetData(_row, 8, vPri);
                        }
                        return;
                    }
                    if (int.Parse(permission.RepInv4.Trim()) == 5)
                    {
                        vPri = q.FirstOrDefault().Price4.Value;
                        if (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(_row, 8)))) > vPri && vPri > 0.0)
                        {
                            if (_Sts)
                            {
                                MessageBox.Show((LangArEn == 0) ? "يجب البيع بسعر لا يتجاوز سعر التجزئة .. راجع صلاحيات المستخدمين" : "You must sell at retail selling ... Check the Users Authorizations", VarGeneral.ProdectNam);
                            }
                            FlxInv.SetData(_row, 8, vPri);
                        }
                        return;
                    }
                    vPri = q.FirstOrDefault().Price5.Value;
                    if (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(_row, 8)))) > vPri && vPri > 0.0)
                    {
                        if (_Sts)
                        {
                            MessageBox.Show((LangArEn == 0) ? "يجب البيع بسعر لا يتجاوز سعر آخر .. راجع صلاحيات المستخدمين" : "You must sell at other selling ... Check the Users Authorizations", VarGeneral.ProdectNam);
                        }
                        FlxInv.SetData(_row, 8, vPri);
                    }
                    return;
                }
                if (int.Parse(permission.RepInv2.Trim()) <= 0 || int.Parse(permission.RepInv4.Trim()) <= 0)
                {
                    return;
                }
                vPri = 0.0;
                double vPri2 = 0.0;
                q = db.T_Items.Where((T_Item t) => t.Itm_No == FlxInv.GetData(_row, 1).ToString()).ToList();
                if (q.Count <= 0)
                {
                    return;
                }
                if (int.Parse(permission.RepInv2.Trim()) != 1)
                {
                    vPri = ((int.Parse(permission.RepInv2.Trim()) == 2) ? q.FirstOrDefault().Price1.Value : ((int.Parse(permission.RepInv2.Trim()) == 3) ? q.FirstOrDefault().Price2.Value : ((int.Parse(permission.RepInv2.Trim()) == 4) ? q.FirstOrDefault().Price3.Value : ((int.Parse(permission.RepInv2.Trim()) != 5) ? q.FirstOrDefault().Price5.Value : q.FirstOrDefault().Price4.Value))));
                }
                else
                {
                    if (q.FirstOrDefault().Unit1.HasValue && q.FirstOrDefault().T_Unit.Arb_Des == FlxInv.GetData(_row, 3).ToString())
                    {
                        vPri = q.FirstOrDefault().UntPri1.Value;
                    }
                    if (q.FirstOrDefault().Unit2.HasValue && q.FirstOrDefault().T_Unit1.Arb_Des == FlxInv.GetData(_row, 3).ToString())
                    {
                        vPri = q.FirstOrDefault().UntPri2.Value;
                    }
                    if (q.FirstOrDefault().Unit3.HasValue && q.FirstOrDefault().T_Unit2.Arb_Des == FlxInv.GetData(_row, 3).ToString())
                    {
                        vPri = q.FirstOrDefault().UntPri3.Value;
                    }
                    if (q.FirstOrDefault().Unit4.HasValue && q.FirstOrDefault().T_Unit3.Arb_Des == FlxInv.GetData(_row, 3).ToString())
                    {
                        vPri = q.FirstOrDefault().UntPri4.Value;
                    }
                    if (q.FirstOrDefault().Unit5.HasValue && q.FirstOrDefault().T_Unit4.Arb_Des == FlxInv.GetData(_row, 3).ToString())
                    {
                        vPri = q.FirstOrDefault().UntPri5.Value;
                    }
                }
                if (int.Parse(permission.RepInv4.Trim()) != 1)
                {
                    vPri2 = ((int.Parse(permission.RepInv4.Trim()) == 2) ? q.FirstOrDefault().Price1.Value : ((int.Parse(permission.RepInv4.Trim()) == 3) ? q.FirstOrDefault().Price2.Value : ((int.Parse(permission.RepInv4.Trim()) == 4) ? q.FirstOrDefault().Price3.Value : ((int.Parse(permission.RepInv4.Trim()) != 5) ? q.FirstOrDefault().Price5.Value : q.FirstOrDefault().Price4.Value))));
                }
                else
                {
                    if (q.FirstOrDefault().Unit1.HasValue && q.FirstOrDefault().T_Unit.Arb_Des == FlxInv.GetData(_row, 3).ToString())
                    {
                        vPri2 = q.FirstOrDefault().UntPri1.Value;
                    }
                    if (q.FirstOrDefault().Unit2.HasValue && q.FirstOrDefault().T_Unit1.Arb_Des == FlxInv.GetData(_row, 3).ToString())
                    {
                        vPri2 = q.FirstOrDefault().UntPri2.Value;
                    }
                    if (q.FirstOrDefault().Unit3.HasValue && q.FirstOrDefault().T_Unit2.Arb_Des == FlxInv.GetData(_row, 3).ToString())
                    {
                        vPri2 = q.FirstOrDefault().UntPri3.Value;
                    }
                    if (q.FirstOrDefault().Unit4.HasValue && q.FirstOrDefault().T_Unit3.Arb_Des == FlxInv.GetData(_row, 3).ToString())
                    {
                        vPri2 = q.FirstOrDefault().UntPri4.Value;
                    }
                    if (q.FirstOrDefault().Unit5.HasValue && q.FirstOrDefault().T_Unit4.Arb_Des == FlxInv.GetData(_row, 3).ToString())
                    {
                        vPri2 = q.FirstOrDefault().UntPri5.Value;
                    }
                }
                if (vPri > 0.0 && vPri2 > 0.0)
                {
                    if (vPri < vPri2)
                    {
                        if (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(_row, 8)))) < vPri || double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(_row, 8)))) > vPri2)
                        {
                            if (_Sts)
                            {
                                MessageBox.Show((LangArEn == 0) ? ("يجب البيع بسعر " + vPri + " وعدم تجاوز السعر " + vPri2 + " .. راجع صلاحيات المستخدمين") : "You must sell at other selling ... Check the Users Authorizations", VarGeneral.ProdectNam);
                            }
                            FlxInv.SetData(_row, 8, vPri);
                        }
                    }
                    else if (vPri > vPri2)
                    {
                        if (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(_row, 8)))) > vPri || double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(_row, 8)))) < vPri2)
                        {
                            if (_Sts)
                            {
                                MessageBox.Show((LangArEn == 0) ? ("يجب البيع بسعر " + vPri2 + " وعدم تجاوز السعر " + vPri + " .. راجع صلاحيات المستخدمين") : "You must sell at other selling ... Check the Users Authorizations", VarGeneral.ProdectNam);
                            }
                            FlxInv.SetData(_row, 8, vPri);
                        }
                    }
                    else if (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(_row, 8)))) != vPri)
                    {
                        if (_Sts)
                        {
                            MessageBox.Show((LangArEn == 0) ? ("يجب البيع بسعر " + vPri + " .. راجع صلاحيات المستخدمين") : "You must sell at other selling ... Check the Users Authorizations", VarGeneral.ProdectNam);
                        }
                        FlxInv.SetData(_row, 8, vPri);
                    }
                }
                else if (vPri > 0.0 && vPri2 <= 0.0)
                {
                    if (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(_row, 8)))) != vPri)
                    {
                        if (_Sts)
                        {
                            MessageBox.Show((LangArEn == 0) ? ("يجب البيع بسعر " + vPri + " .. راجع صلاحيات المستخدمين") : "You must sell at other selling ... Check the Users Authorizations", VarGeneral.ProdectNam);
                        }
                        FlxInv.SetData(_row, 8, vPri);
                    }
                }
                else if (vPri <= 0.0 && vPri2 > 0.0)
                {
                    if (_Sts)
                    {
                        MessageBox.Show((LangArEn == 0) ? (" يجب عدم تجاوز السعر " + vPri2 + " .. راجع صلاحيات المستخدمين") : "You must sell at other selling ... Check the Users Authorizations", VarGeneral.ProdectNam);
                    }
                    FlxInv.SetData(_row, 8, vPri2);
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
                    oldUnit = FlxInv.GetData(e.Row, 3).ToString() ?? "";
                }
            }
            catch
            {
            }
            try
            {
                if (e.Col == 2 || e.Col == 4)
                {
                    oldItemName = FlxInv.GetData(e.Row, e.Col).ToString() ?? "";
                }
            }
            catch
            {
                oldItemName = "";
            }
            try
            {
                _RowIndex = e.Row;
            }
            catch
            {
            }
            GridDetUpdate(FlxInv.RowSel);
        }
        private void FlxInv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Delete)
            {
                return;
            }
            try
            {
                if (FlxInv.GetData(RowSel, 1).ToString() == null)
                {
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
                if (string.Concat(FlxInv.GetData(FlxInv.RowSel, 1)) != "")
                {
                    _Items = db.StockItem(string.Concat(FlxInv.GetData(FlxInv.RowSel, 1)));
                    if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                    {
                        txtItemName.Text = _Items.Arb_Des.Trim();
                    }
                    else
                    {
                        txtItemName.Text = _Items.Eng_Des.Trim();
                    }
                    string CoA = "";
                    string CoE = "";
                    for (int iiCnt = 0; iiCnt < listUnit.Count; iiCnt++)
                    {
                        _Unit = listUnit[iiCnt];
                        if (_Items.Unit1 == _Unit.Unit_ID)
                        {
                            if (CoA != "")
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
                            if (CoA != "")
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
                            if (CoA != "")
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
                            if (CoA != "")
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
                            if (CoA != "")
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
                    BindDataOfStkQty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 1)));
                }
                int vRowIndex = FlxInv.RowSel;
                try
                {
                    if (FlxInv.ColSel == 7 || FlxInv.ColSel == 8 || FlxInv.ColSel == 9 || FlxInv.ColSel == 31)
                    {
                        PanaHide(Sts: true);
                        if (FlxInv.ColSel == 7)
                        {
                            vQtyGraid = true;
                        }
                        else if (FlxInv.ColSel == 8)
                        {
                            vPriceGraid = true;
                        }
                        else if (FlxInv.ColSel == 9)
                        {
                            vDisGraid = true;
                        }
                        else if (FlxInv.ColSel == 31)
                        {
                            vTotGraid = true;
                        }
                        else if (FlxInv.ColSel == 38)
                        {
                            vTax = true;
                        }
                    }
                }
                catch
                {
                    groupPanel_BoardNo.Enabled = false;
                    vQtyGraid = false;
                    vPriceGraid = false;
                    vDisGraid = false;
                    vTotGraid = false;
                    vTax = false;
                }
            }
            catch
            {
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
                    _Items = db.StockItemList(FlxInv.GetData(vRow, 1).ToString()).First();
                    dataGridView_ItemDet.Visible = false;
                    Stock_DataDataContext dbc = new Stock_DataDataContext(VarGeneral.BranchCS);
                    if (State == FormState.New && (int.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(vRow, 25)))) <= 0 || string.IsNullOrEmpty(FlxInv.GetData(vRow, 25).ToString())))
                    {
                        List<T_ItemDet> ItmDet = db.T_ItemDets.Where((T_ItemDet t) => t.ItmNo == _Items.Itm_No).ToList();
                        SetLinesDet(ItmDet);
                        return;
                    }
                    List<T_SINVDET> ItmDEt = dbc.T_SINVDETs.Where((T_SINVDET t) => t.SInvId == (int?)int.Parse(VarGeneral.TString.TEmpty("" + FlxInv.GetData(vRow, 25)))).ToList();
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
            if (!(string.Concat(dataGridView_ItemDet.GetData(dataGridView_ItemDet.RowSel, 1)) != ""))
            {
                return;
            }
            _Items = db.StockItem(string.Concat(dataGridView_ItemDet.GetData(dataGridView_ItemDet.RowSel, 1)));
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                txtItemName.Text = _Items.Arb_Des.Trim();
            }
            else
            {
                txtItemName.Text = _Items.Eng_Des.Trim();
            }
            string CoA = "";
            string CoE = "";
            for (int iiCnt = 0; iiCnt < listUnit.Count; iiCnt++)
            {
                _Unit = listUnit[iiCnt];
                if (_Items.Unit1 == _Unit.Unit_ID)
                {
                    if (CoA != "")
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
                    if (CoA != "")
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
                    if (CoA != "")
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
                    if (CoA != "")
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
                    if (CoA != "")
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
            string CoA = "";
            string CoE = "";
            string DefUnitA = "";
            string DefUnitE = "";
            for (int iiCnt = 0; iiCnt < listUnit.Count; iiCnt++)
            {
                _Unit = listUnit[iiCnt];
                if (!((vUntID != 0) ? (vUntID == 1) : (_Itm.Unit1 == _Unit.Unit_ID)))
                {
                    continue;
                }
                if (CoA != "")
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
                if (CoA != "")
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
                if (CoA != "")
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
                if (CoA != "")
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
                if (CoA != "")
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
            dataGridView_ItemDet.SetData(vRow, 10, _Itm.AvrageCost / RateValue);
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
                if (RowSel == 0 || RowSel == FlxInv.Row || FlxInv.Row <= 0 || !(string.Concat(FlxInv.GetData(FlxInv.Row, 1)) != ""))
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
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                {
                    txtItemName.Text = _Items.Arb_Des.Trim();
                }
                else
                {
                    txtItemName.Text = _Items.Eng_Des.Trim();
                }
                string CoA = "";
                string CoE = "";
                for (int iiCnt = 0; iiCnt < listUnit.Count; iiCnt++)
                {
                    _Unit = listUnit[iiCnt];
                    if (_Items.Unit1 == _Unit.Unit_ID)
                    {
                        if (CoA != "")
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
                        if (CoA != "")
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
                        if (CoA != "")
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
                        if (CoA != "")
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
                        if (CoA != "")
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
            }
            catch
            {
            }
        }
        private void BindDataOfItem()
        {
            List<T_Item> listSer = new List<T_Item>();
            if ((string)FlxInv.GetData(FlxInv.Row, 1) != "" && FlxInv.GetData(FlxInv.Row, 1) != null)
            {
                listSer = db.StockItemList(FlxInv.GetData(FlxInv.Row, 1).ToString());
                if (listSer.Count != 0)
                {
                    _Items = listSer[0];
                }
            }
            FlxInv.SetData(FlxInv.Row, 1, _Items.Itm_No.Trim());
            FlxInv.SetData(FlxInv.Row, 2, _Items.Arb_Des.Trim());
            FlxInv.SetData(FlxInv.Row, 4, _Items.Eng_Des.Trim());
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
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
            string CoA = "";
            string CoE = "";
            string DefUnitA = "";
            string DefUnitE = "";
            for (int iiCnt = 0; iiCnt < listUnit.Count; iiCnt++)
            {
                _Unit = listUnit[iiCnt];
                if (_Items.Unit1 == _Unit.Unit_ID)
                {
                    if (CoA != "")
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
                    if (CoA != "")
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
                    if (CoA != "")
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
                    if (CoA != "")
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
                    if (CoA != "")
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
            try
            {
                if (_Items.Unit2.HasValue && _stsClick == 0)
                {
                    FrmItemSize frm = new FrmItemSize(_Items.Itm_No);
                    frm.Tag = LangArEn;
                    frm.TopMost = true;
                    frm.ShowDialog();
                    if (frm.vSts_Op)
                    {
                        if (frm.vSize_ == 0)
                        {
                            for (int iiCnt = 0; iiCnt < listUnit.Count; iiCnt++)
                            {
                                _Unit = listUnit[iiCnt];
                                if (_Items.Unit1 == _Unit.Unit_ID)
                                {
                                    Pack = _Items.Pack1.Value;
                                    DefUnitA = _Unit.Arb_Des;
                                    DefUnitE = _Unit.Eng_Des;
                                    FlxInv.SetData(FlxInv.Row, 8, _Items.UntPri1.Value);
                                    FlxInv.SetData(FlxInv.Row, 11, _Items.Pack1.Value);
                                    break;
                                }
                            }
                        }
                        else if (frm.vSize_ == 1)
                        {
                            for (int iiCnt = 0; iiCnt < listUnit.Count; iiCnt++)
                            {
                                _Unit = listUnit[iiCnt];
                                if (_Items.Unit2 == _Unit.Unit_ID)
                                {
                                    Pack = _Items.Pack2.Value;
                                    DefUnitA = _Unit.Arb_Des;
                                    DefUnitE = _Unit.Eng_Des;
                                    FlxInv.SetData(FlxInv.Row, 8, _Items.UntPri2.Value);
                                    FlxInv.SetData(FlxInv.Row, 11, _Items.Pack2.Value);
                                    break;
                                }
                            }
                        }
                        else if (frm.vSize_ == 2)
                        {
                            for (int iiCnt = 0; iiCnt < listUnit.Count; iiCnt++)
                            {
                                _Unit = listUnit[iiCnt];
                                if (_Items.Unit3 == _Unit.Unit_ID)
                                {
                                    Pack = _Items.Pack3.Value;
                                    DefUnitA = _Unit.Arb_Des;
                                    DefUnitE = _Unit.Eng_Des;
                                    FlxInv.SetData(FlxInv.Row, 8, _Items.UntPri3.Value);
                                    FlxInv.SetData(FlxInv.Row, 11, _Items.Pack3.Value);
                                    break;
                                }
                            }
                        }
                        else if (frm.vSize_ == 3)
                        {
                            for (int iiCnt = 0; iiCnt < listUnit.Count; iiCnt++)
                            {
                                _Unit = listUnit[iiCnt];
                                if (_Items.Unit4 == _Unit.Unit_ID)
                                {
                                    Pack = _Items.Pack4.Value;
                                    DefUnitA = _Unit.Arb_Des;
                                    DefUnitE = _Unit.Eng_Des;
                                    FlxInv.SetData(FlxInv.Row, 8, _Items.UntPri4.Value);
                                    FlxInv.SetData(FlxInv.Row, 11, _Items.Pack4.Value);
                                    break;
                                }
                            }
                        }
                        else
                        {
                            for (int iiCnt = 0; iiCnt < listUnit.Count; iiCnt++)
                            {
                                _Unit = listUnit[iiCnt];
                                if (_Items.Unit5 == _Unit.Unit_ID)
                                {
                                    Pack = _Items.Pack5.Value;
                                    DefUnitA = _Unit.Arb_Des;
                                    DefUnitE = _Unit.Eng_Des;
                                    FlxInv.SetData(FlxInv.Row, 8, _Items.UntPri5.Value);
                                    FlxInv.SetData(FlxInv.Row, 11, _Items.Pack5.Value);
                                    break;
                                }
                            }
                        }
                    }
                    else
                    {
                        FlxInv.SetData(FlxInv.Row, 8, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.Row, 8)))) / RateValue);
                        try
                        {
                            if (FlxInv.RowSel > 0)
                            {
                                if (FlxInv.Rows[FlxInv.Row].Height > 33)
                                {
                                    FlxInv.RemoveItem(FlxInv.Row);
                                    FlxInv.RemoveItem(FlxInv.Row);
                                }
                                else
                                {
                                    FlxInv.RemoveItem(FlxInv.Row - 1);
                                    FlxInv.RemoveItem(FlxInv.Row);
                                }
                                GetInvTot();
                            }
                        }
                        catch
                        {
                            FlxInv.SetData(FlxInv.Row, 8, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.Row, 8)))) / RateValue);
                        }
                    }
                }
                else
                {
                    FlxInv.SetData(FlxInv.Row, 8, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.Row, 8)))) / RateValue);
                }
            }
            catch
            {
                FlxInv.SetData(FlxInv.Row, 8, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.Row, 8)))) / RateValue);
            }
            FlxInv.Cols[3].ComboList = CoA;
            FlxInv.Cols[5].ComboList = CoE;
            FlxInv.SetData(FlxInv.Row, 3, DefUnitA);
            FlxInv.SetData(FlxInv.Row, 5, DefUnitE);
            BindDataofItemPrice();
            PermissionPrice(FlxInv.Row, 8, _Sts: false);
            FlxInv.SetData(FlxInv.Row, 10, _Items.AvrageCost / RateValue);
            FlxInv.SetData(FlxInv.Row, 30, _Items.LastCost * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.Row, 11)))) / RateValue);
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
            FlxInv.SetData(FlxInv.Row, 8, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.Row, 8)))) / RateValue);
            if (FlxInv.Cols[9].Visible)
            {
                FlxInv.SetData(FlxInv.Row, 9, _Items.ItemDis.Value);
            }
            else
            {
                FlxInv.SetData(FlxInv.Row, 9, 0);
            }
            if (FlxInv.Cols[38].Visible)
            {
                FlxInv.SetData(FlxInv.Row, 38, VarGeneral.TString.ChkStatShow(_InvSetting.TaxOptions, 2) ? _Items.TaxPurchas : _Items.TaxSales);
            }
            else
            {
                FlxInv.SetData(FlxInv.Row, 38, 0);
            }
            PriceLoc = (double)FlxInv.GetData(FlxInv.Row, 8);
            BindDataOfStkQty(_Items.Itm_No.Trim());
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
                ItmAddTax = Math.Round(double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.Row, 8)))) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.Row, 38)))) / 100.0), VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2);
            }
            catch
            {
                ItmAddTax = 0.0;
            }
            if (!switchButton_TaxLines.Value || switchButton_TaxByTotal.Value)
            {
                ItmAddTax = 0.0;
            }
            FlxInv.SetData(FlxInv.Row, 31, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.Row, 8)))) - ItmDis + ItmAddTax);
            if (switchButton_TaxByTotal.Value && switchButton_TaxLines.Value && double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.Row, 31)))) > 0.0)
            {
                ItmAddTax = Math.Round((double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.Row, 8)))) - ItmDis) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.Row, 38)))) / 100.0), VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2);
                FlxInv.SetData(FlxInv.Row, 31, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.Row, 31)))) + ItmAddTax);
            }
            if (!chekReptItem(Col_1: true))
            {
                FlxInv.Col = 0;
            }
            else
            {
                FlxInv.Col = 0;
            }
            GetInvTot();
            base.ActiveControl = FlxInv;
            FlxInv.Row = FlxInv.Row;
            FlxInv.RowSel = FlxInv.Row;
            FlxInv.Col = 7;
            FlxInv.ColSel = 7;
            if (FlxInv.ColSel == 7 || FlxInv.ColSel == 8 || FlxInv.ColSel == 9 || FlxInv.ColSel == 31)
            {
                PanaHide(Sts: true);
            }
            vQtyGraid = true;
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
                if (!string.IsNullOrEmpty(string.Concat(FlxInv.GetData(iiCnt, 1))) && iiCnt != FlxInv.RowSel && FlxInv.GetData(iiCnt, 1).ToString() == FlxInv.GetData(FlxInv.RowSel, 1).ToString())
                {
                    MessageBox.Show((LangArEn == 0) ? "تنبيه .. لقد قمت بأدخال هذا الصنف مسبقا\u064b في هذه الفاتورة" : "Alert .. You have entered already this product in this bill", VarGeneral.ProdectNam);
                    break;
                }
            }
        }
        private bool chekReptItem(bool Col_1)
        {
            if (State != 0 && (FlxInv.ColSel == 31 || FlxInv.ColSel == 7 || FlxInv.ColSel == 8 || Col_1) && VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 17))
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
                        FlxInv.SetData(FlxInv.RowSel, 7, double.Parse(VarGeneral.TString.TEmpty(FlxInv.GetData(iiCnt, 7).ToString() ?? "")) + vQty);
                        double RealQ = 0.0;
                        RealQ = double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 11))));
                        if (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 32)))) == 3.0)
                        {
                            goto IL_0b94;
                        }
                        if (double.Parse(FlxInv.GetData(FlxInv.RowSel, 24).ToString()) <= 0.0)
                        {
                            if (VarGeneral.TString.ChkStatShow(VarGeneral.UserPassQty, 1))
                            {
                                goto IL_0b94;
                            }
                            MessageBox.Show((LangArEn == 0) ? ("لا يمكن البيع والكمية  " + double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 24)))) + "تأكد من صلاحيات المستخدمين") : ("Can't Sale and the Quantity " + double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 24)))) + " Check the Users Authorizations"), VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            FlxInv.SetData(FlxInv.RowSel, 7, 0);
                            ItmDis = double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 8)))) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 9)))) / 100.0);
                            ItmAddTax = Math.Round(double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 8)))) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 38)))) / 100.0), VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2);
                            if (!switchButton_TaxLines.Value || switchButton_TaxByTotal.Value)
                            {
                                ItmAddTax = 0.0;
                            }
                            FlxInv.SetData(FlxInv.RowSel, 12, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 11)))));
                            FlxInv.SetData(FlxInv.RowSel, 31, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 8)))) - ItmDis + ItmAddTax);
                            if (switchButton_TaxByTotal.Value && switchButton_TaxLines.Value && double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 31)))) > 0.0)
                            {
                                ItmAddTax = Math.Round((double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 8)))) - ItmDis) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 38)))) / 100.0), VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2);
                                FlxInv.SetData(FlxInv.RowSel, 31, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 31)))) + ItmAddTax);
                            }
                            FlxInv.Row = FlxInv.RowSel;
                            FlxInv.Col = 31;
                        }
                        else
                        {
                            if (!(double.Parse(FlxInv.GetData(FlxInv.RowSel, 24).ToString()) < RealQ) || VarGeneral.TString.ChkStatShow(VarGeneral.UserPassQty, 1))
                            {
                                goto IL_0b94;
                            }
                            MessageBox.Show((LangArEn == 0) ? ("لا يمكن البيع بأكثر من الكمية  " + double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 24)))) + "راجع صلاحيات المستخدمين") : ("Can't Sale More Than available Quantity " + double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 24)))) + " Check the Users Authorizations"), VarGeneral.ProdectNam);
                            FlxInv.SetData(FlxInv.RowSel, 7, 0);
                            ItmDis = double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 8)))) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 9)))) / 100.0);
                            ItmAddTax = Math.Round(double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 8)))) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 38)))) / 100.0), VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2);
                            if (!switchButton_TaxLines.Value || switchButton_TaxByTotal.Value)
                            {
                                ItmAddTax = 0.0;
                            }
                            FlxInv.SetData(FlxInv.RowSel, 12, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 11)))));
                            FlxInv.SetData(FlxInv.RowSel, 31, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 8)))) - ItmDis + ItmAddTax);
                            if (switchButton_TaxByTotal.Value && switchButton_TaxLines.Value && double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 31)))) > 0.0)
                            {
                                ItmAddTax = Math.Round((double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 8)))) - ItmDis) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 38)))) / 100.0), VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2);
                                FlxInv.SetData(FlxInv.RowSel, 31, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 31)))) + ItmAddTax);
                            }
                            FlxInv.Row = FlxInv.RowSel;
                            FlxInv.Col = 31;
                        }
                        goto end_IL_01a7;
                    IL_0b94:
                        if (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 10)))) > double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 8)))) && !VarGeneral.TString.ChkStatShow(VarGeneral.UserPassQty, 2))
                        {
                            MessageBox.Show((LangArEn == 0) ? "لا يمكن البيع بأقل من سعر التكلفة .. راجع صلاحيات المستخدمين" : "Can't Sale Less Then Cost Price ... Check the Users Authorizations", VarGeneral.ProdectNam);
                            FlxInv.SetData(FlxInv.RowSel, 8, PriceLoc);
                            ItmDis = double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 8)))) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 9)))) / 100.0);
                            ItmAddTax = Math.Round(double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 8)))) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 38)))) / 100.0), VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2);
                            if (!switchButton_TaxLines.Value || switchButton_TaxByTotal.Value)
                            {
                                ItmAddTax = 0.0;
                            }
                            FlxInv.SetData(FlxInv.RowSel, 12, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 11)))));
                            FlxInv.SetData(FlxInv.RowSel, 31, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 8)))) - ItmDis + ItmAddTax);
                            if (switchButton_TaxByTotal.Value && switchButton_TaxLines.Value && double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 31)))) > 0.0)
                            {
                                ItmAddTax = Math.Round((double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 8)))) - ItmDis) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 38)))) / 100.0), VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2);
                                FlxInv.SetData(FlxInv.RowSel, 31, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 31)))) + ItmAddTax);
                            }
                            FlxInv.Row = FlxInv.RowSel;
                            FlxInv.Col = 31;
                            break;
                        }
                        goto IL_136a;
                    end_IL_01a7:;
                    }
                    catch
                    {
                        FlxInv.SetData(FlxInv.RowSel, 7, 0);
                        ItmDis = double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 8)))) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 9)))) / 100.0);
                        ItmAddTax = Math.Round(double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 8)))) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 38)))) / 100.0), VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2);
                        if (!switchButton_TaxLines.Value || switchButton_TaxByTotal.Value)
                        {
                            ItmAddTax = 0.0;
                        }
                        FlxInv.SetData(FlxInv.RowSel, 12, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 11)))));
                        FlxInv.SetData(FlxInv.RowSel, 31, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 8)))) - ItmDis + ItmAddTax);
                        if (switchButton_TaxByTotal.Value && switchButton_TaxLines.Value && double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 31)))) > 0.0)
                        {
                            ItmAddTax = Math.Round((double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 8)))) - ItmDis) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 38)))) / 100.0), VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2);
                            FlxInv.SetData(FlxInv.RowSel, 31, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 31)))) + ItmAddTax);
                        }
                    }
                    break;
                IL_136a:
                    FlxInv.SetData(iiCnt, 7, double.Parse(VarGeneral.TString.TEmpty(FlxInv.GetData(iiCnt, 7).ToString() ?? "")) + vQty);
                    ItmDis = double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 8)))) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 9)))) / 100.0);
                    ItmAddTax = Math.Round(double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 8)))) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 38)))) / 100.0), VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2);
                    if (!switchButton_TaxLines.Value || switchButton_TaxByTotal.Value)
                    {
                        ItmAddTax = 0.0;
                    }
                    if (FlxInv.RowSel > 0)
                    {
                        if (FlxInv.Rows[FlxInv.Row].Height > 33)
                        {
                            FlxInv.RemoveItem(FlxInv.Row);
                            FlxInv.RemoveItem(FlxInv.Row);
                        }
                        else
                        {
                            FlxInv.RemoveItem(FlxInv.Row - 1);
                            FlxInv.RemoveItem(FlxInv.Row);
                        }
                        FlxInv.SetData(iiCnt, 12, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 11)))));
                        FlxInv.SetData(iiCnt, 31, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 8)))) - ItmDis + ItmAddTax);
                        if (switchButton_TaxByTotal.Value && switchButton_TaxLines.Value && double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 31)))) > 0.0)
                        {
                            ItmAddTax = Math.Round((double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 8)))) - ItmDis) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 38)))) / 100.0), VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2);
                            FlxInv.SetData(iiCnt, 31, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 31)))) + ItmAddTax);
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
        private void FlxDat_DoubleClick(object sender, EventArgs e)
        {
            if (FlxDat.MouseRow > 0)
            {
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
        public void Button_Print_Click(object sender, EventArgs e)
        {
            if (ViewState == ViewState.Table)
            {
                VarGeneral.InvType = 21;
                FRInvoice form1 = new FRInvoice(VarGeneral.InvTyp, LangArEn);
                form1.Tag = LangArEn.ToString();
                form1.StartPosition = FormStartPosition.CenterScreen;
                form1.TopMost = true;
                form1.ShowDialog();
            }
        }
        private void GetInvTot()
        {
            double InvTot = 0.0;
            double InvCost = 0.0;
            double InvQty = 0.0;
            double InvDis = 0.0;
            double InvTax = 0.0;
            double ItmDisCount = 0.0;
            if (State != 0)
            {
                InvDis = double.Parse(VarGeneral.TString.TEmpty(txtDiscountVal.Text));
                for (int iiCnt = 1; iiCnt < FlxInv.Rows.Count; iiCnt++)
                {
                    try
                    {
                        if (FlxInv.Rows[iiCnt].Height <= 33)
                        {
                            continue;
                        }
                        InvTot += double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 31))));
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
                            InvTax += (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 8)))) - DisVal) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 38)))) / 100.0);
                        }
                        else
                        {
                            InvTax += double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 8)))) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 38)))) / 100.0);
                        }
                        ItmDisCount += double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 8)))) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 9)))) / 100.0);
                    }
                    catch
                    {
                    }
                }
                txtTotalAm.Text = VarGeneral.TString.TEmpty(Math.Round(InvTot * RateValue, VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2).ToString());
                txtDueAmount.Text = VarGeneral.TString.TEmpty(Math.Round((InvTot - InvDis) * RateValue, VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2).ToString());
                txtTotalQ.Text = VarGeneral.TString.TEmpty(InvQty.ToString());
                txtInvCost.Text = VarGeneral.TString.TEmpty(Math.Round(InvCost, VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2).ToString());
                txtCustNet.Text = VarGeneral.TString.TEmpty(Math.Round(double.Parse(VarGeneral.TString.TEmpty(string.Concat(txtCustRep.Value))) + double.Parse(txtDueAmountLoc.Text), VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2).ToString());
                txtTotalAmLoc.Text = VarGeneral.TString.TEmpty(Math.Round(InvTot, VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2).ToString());
                txtDueAmountLoc.Text = VarGeneral.TString.TEmpty(Math.Round(InvTot - InvDis, VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2).ToString());
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
            if (FlxInv.Rows.Count <= 1)
            {
                button_DeleteLine.Visible = false;
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
            ControlNo = 3;
            CheckSts(ControlNo);
        }
        private void checkBoxItem_BarCode_CheckedChanged(object sender, CheckBoxChangeEventArgs e)
        {
            try
            {
                if (checkBoxItem_BarCode.Checked)
                {
                    superTabControl_Main2.Enabled = false;
                    Button_Search.Enabled = false;
                    Button_Delete.Enabled = false;
                    buttonItem_Print.Enabled = false;
                    expandableSplitter1.Expandable = false;
                    Button_Add_Click(sender, e);
                    return;
                }
                superTabControl_Main2.Enabled = true;
                Button_Search.Enabled = true;
                Button_Add.Enabled = true;
                Button_Delete.Enabled = true;
                buttonItem_Print.Enabled = true;
                expandableSplitter1.Expandable = true;
                State = FormState.Saved;
                dbInstance = null;
                if (pkeys.Count == 1)
                {
                    Button_First_Click(sender, e);
                }
                else
                {
                    textBox_ID_TextChanged(sender, e);
                }
                SetReadOnly = true;
                if (State != FormState.New)
                {
                    button_AddToTable.Visible = false;
                }
            }
            catch
            {
            }
        }
        private void txtCustNo_TextChanged(object sender, EventArgs e)
        {
            if (txtCustNo.Text != "")
            {
                txtCustName.ReadOnly = true;
                txtTele.ReadOnly = true;
                txtAddress.ReadOnly = true;
            }
            else
            {
                txtCustName.ReadOnly = false;
                txtTele.ReadOnly = false;
                txtAddress.ReadOnly = false;
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
        private void FrmWaiterMenue_SizeChanged(object sender, EventArgs e)
        {
            FillCat();
            if (base.WindowState == FormWindowState.Normal)
            {
                btnPrevPage.Text = "";
                btnNxtPage.Text = "";
                buttonItem_BestSeller.Text = "";
            }
            else if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                btnPrevPage.Text = "سابق";
                btnNxtPage.Text = "تالي";
                buttonItem_BestSeller.Text = "أكثر مبيعا\u064c";
            }
            else
            {
                btnPrevPage.Text = "Prev";
                btnNxtPage.Text = "Next";
                buttonItem_BestSeller.Text = "Best Seller";
            }
        }
        private void metroTilePanel_Cat_ItemClick(object sender, EventArgs e)
        {
            try
            {
                MetroTileItem q = sender as MetroTileItem;
                if (string.IsNullOrEmpty(q.Tag.ToString()))
                {
                    ItmMainParameter = "";
                    return;
                }
                ItmMainParameter = q.Tag.ToString();
                FillItmesMain(q, vBestSaller: false);
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("metroTilePanel_Cat_ItemClick:", error, enable: true);
                Refresh();
            }
        }
        private void FillItmesMain(MetroTileItem vSender, bool vBestSaller)
        {
            List<T_Item> vItemsMain = new List<T_Item>();
            Stock_DataDataContext dbc = new Stock_DataDataContext(VarGeneral.BranchCS);
            vItemsMain = (from t in dbc.T_Items
                          where t.ItmTyp != (int?)1 && !t.InvSaleStoped.Value
                          orderby t.Itm_ID
                          select t).ToList();
            if (vSender != null)
            {
                vSender.Checked = true;
                if (int.Parse(vSender.Tag.ToString()) != 0)
                {
                    vItemsMain = (from t in dbc.T_Items
                                  where t.ItmCat == (int?)int.Parse(vSender.Tag.ToString())
                                  where t.ItmTyp != (int?)1 && !t.InvSaleStoped.Value
                                  orderby t.Itm_ID
                                  select t).ToList();
                }
            }
            if (vBestSaller)
            {
                vItemsMain = db.ExecuteQuery<T_Item>("SELECT        T_Items.Itm_ID, T_Items.Itm_No, T_Items.ItmCat, T_Items.Arb_Des, T_Items.Eng_Des, T_Items.StartCost, T_Items.AvrageCost, T_Items.LastCost, T_Items.Price1, \r\n                                                                                  T_Items.Price3, T_Items.Price2, T_Items.Price5, T_Items.Price4, T_Items.Price6, T_Items.Unit1, T_Items.Pack1, T_Items.Unit2, T_Items.UntPri2, T_Items.UntPri1, \r\n                                                                                  T_Items.Pack2, T_Items.Unit3, T_Items.Pack3, T_Items.Unit4, T_Items.UntPri3, T_Items.UntPri4, T_Items.Pack4, T_Items.Unit5, T_Items.UntPri5, T_Items.Pack5, \r\n                                                                                  T_Items.DefultUnit, T_Items.DefultVendor, T_Items.OpenQty, T_Items.QtyLvl, T_Items.ItmLoc, T_Items.BarCod1, T_Items.BarCod2, T_Items.BarCod3, \r\n                                                                                  T_Items.BarCod4, T_Items.BarCod5, T_Items.Lot, T_Items.LrnExp, T_Items.DMY, T_Items.ItmTyp, T_Items.DefPack, T_Items.ItmImg, \r\n                                                                                  T_Items.InvSaleStoped, T_Items.InvPaymentStoped, T_Items.InvPaymentReturnStoped, T_Items.FirstCost, T_Items.CompanyID, T_Items.InvSaleReturnStoped, \r\n                                                                                  T_Items.SerialKey,sum(RealQty) as QtyMax\r\n                                                            FROM         T_Items INNER JOIN\r\n                                                                                  T_INVDET ON T_Items.Itm_No = T_INVDET.ItmNo INNER JOIN\r\n                                                                                  T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID  \r\n                                                            WHERE T_INVHED.InvTyp = 21  and T_Items.ItmTyp != 1 and T_Items.InvSaleStoped = 0\r\n                                                            Group By T_Items.Itm_ID, T_Items.Itm_No, T_Items.ItmCat, T_Items.Arb_Des, T_Items.Eng_Des, T_Items.StartCost, T_Items.AvrageCost, T_Items.LastCost, T_Items.Price1, \r\n                                                                                  T_Items.Price3, T_Items.Price2, T_Items.Price5, T_Items.Price4, T_Items.Price6, T_Items.Unit1, T_Items.Pack1, T_Items.Unit2, T_Items.UntPri2, T_Items.UntPri1, \r\n                                                                                  T_Items.Pack2, T_Items.Unit3, T_Items.Pack3, T_Items.Unit4, T_Items.UntPri3, T_Items.UntPri4, T_Items.Pack4, T_Items.Unit5, T_Items.UntPri5, T_Items.Pack5, \r\n                                                                                  T_Items.DefultUnit, T_Items.DefultVendor, T_Items.OpenQty, T_Items.QtyLvl, T_Items.ItmLoc, T_Items.BarCod1, T_Items.BarCod2, T_Items.BarCod3, \r\n                                                                                  T_Items.BarCod4, T_Items.BarCod5, T_Items.Lot, T_Items.QtyMax, T_Items.LrnExp, T_Items.DMY, T_Items.ItmTyp, T_Items.DefPack, T_Items.ItmImg, \r\n                                                                                  T_Items.InvSaleStoped, T_Items.InvPaymentStoped, T_Items.InvPaymentReturnStoped, T_Items.FirstCost, T_Items.CompanyID, T_Items.InvSaleReturnStoped, \r\n                                                                                  T_Items.SerialKey\r\n                                                                                  order by QtyMax desc", new object[0]).ToList();
            }
            if (vItemsMain.Count <= 0)
            {
                ClearItemsMain();
                return;
            }
            CurrentPageIndex = 1;
            CurrentPageIndexItmDet = 1;
            CalculateTotalPages(vItemsMain);
            GetCurrentRecords(1, vBestSaller);
        }
        private void CalculateTotalPages(List<T_Item> vItemsMain)
        {
            try
            {
                int rowCount = vItemsMain.ToList().Count;
                TotalPage = rowCount / PageSize;
                if (rowCount % PageSize > 0)
                {
                    TotalPage++;
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("CalculateTotalPages:", error, enable: true);
                if (TotalPage <= 0)
                {
                    TotalPage = 1;
                }
            }
        }
        private void GetCurrentRecords(int page, bool vBestSaller)
        {
            try
            {
                List<T_Item> dt = new List<T_Item>();
                if (!vBestSaller)
                {
                    if (page == 1)
                    {
                        dt = db.ExecuteQuery<T_Item>("Select TOP " + PageSize + " * from T_Items " + ((!string.IsNullOrEmpty(ItmMainParameter) && ItmMainParameter != "0") ? (" where ItmCat = " + ItmMainParameter + " and ") : " where ") + " T_Items.ItmTyp != 1 and T_Items.InvSaleStoped = 0 ORDER BY Itm_ID", new object[0]).ToList();
                    }
                    else
                    {
                        int PreviouspageLimit = (page - 1) * PageSize;
                        dt = db.ExecuteQuery<T_Item>("Select TOP " + PageSize + " * from T_Items WHERE " + ((!string.IsNullOrEmpty(ItmMainParameter) && ItmMainParameter != "0") ? (" ItmCat = " + ItmMainParameter + " AND ") : " ") + " Itm_ID NOT IN (Select TOP " + PreviouspageLimit + " Itm_ID from T_Items WHERE " + ((!string.IsNullOrEmpty(ItmMainParameter) && ItmMainParameter != "0") ? (" ItmCat = " + ItmMainParameter) : " 1 = 1 ") + "ORDER BY Itm_ID) and T_Items.ItmTyp != 1 and T_Items.InvSaleStoped = 0 ORDER BY Itm_ID", new object[0]).ToList();
                    }
                }
                else if (page == 1)
                {
                    dt = db.ExecuteQuery<T_Item>("SELECT   TOP " + PageSize + "  T_Items.Itm_ID, T_Items.Itm_No, T_Items.ItmCat, T_Items.Arb_Des, T_Items.Eng_Des, T_Items.StartCost, T_Items.AvrageCost, T_Items.LastCost, T_Items.Price1, \r\n                                                                                  T_Items.Price3, T_Items.Price2, T_Items.Price5, T_Items.Price4, T_Items.Price6, T_Items.Unit1, T_Items.Pack1, T_Items.Unit2, T_Items.UntPri2, T_Items.UntPri1, \r\n                                                                                  T_Items.Pack2, T_Items.Unit3, T_Items.Pack3, T_Items.Unit4, T_Items.UntPri3, T_Items.UntPri4, T_Items.Pack4, T_Items.Unit5, T_Items.UntPri5, T_Items.Pack5, \r\n                                                                                  T_Items.DefultUnit, T_Items.DefultVendor, T_Items.OpenQty, T_Items.QtyLvl, T_Items.ItmLoc, T_Items.BarCod1, T_Items.BarCod2, T_Items.BarCod3, \r\n                                                                                  T_Items.BarCod4, T_Items.BarCod5, T_Items.Lot, T_Items.LrnExp, T_Items.DMY, T_Items.ItmTyp, T_Items.DefPack, T_Items.ItmImg, \r\n                                                                                  T_Items.InvSaleStoped, T_Items.InvPaymentStoped, T_Items.InvPaymentReturnStoped, T_Items.FirstCost, T_Items.CompanyID, T_Items.InvSaleReturnStoped, \r\n                                                                                  T_Items.SerialKey,sum(RealQty) as QtyMax\r\n                                                            FROM         T_Items INNER JOIN\r\n                                                                                  T_INVDET ON T_Items.Itm_No = T_INVDET.ItmNo INNER JOIN\r\n                                                                                  T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID\r\n                                                            WHERE T_INVHED.InvTyp = 21 and T_Items.ItmTyp != 1 and T_Items.InvSaleStoped = 0\r\n                                                            Group By T_Items.Itm_ID, T_Items.Itm_No, T_Items.ItmCat, T_Items.Arb_Des, T_Items.Eng_Des, T_Items.StartCost, T_Items.AvrageCost, T_Items.LastCost, T_Items.Price1, \r\n                                                                                  T_Items.Price3, T_Items.Price2, T_Items.Price5, T_Items.Price4, T_Items.Price6, T_Items.Unit1, T_Items.Pack1, T_Items.Unit2, T_Items.UntPri2, T_Items.UntPri1, \r\n                                                                                  T_Items.Pack2, T_Items.Unit3, T_Items.Pack3, T_Items.Unit4, T_Items.UntPri3, T_Items.UntPri4, T_Items.Pack4, T_Items.Unit5, T_Items.UntPri5, T_Items.Pack5, \r\n                                                                                  T_Items.DefultUnit, T_Items.DefultVendor, T_Items.OpenQty, T_Items.QtyLvl, T_Items.ItmLoc, T_Items.BarCod1, T_Items.BarCod2, T_Items.BarCod3, \r\n                                                                                  T_Items.BarCod4, T_Items.BarCod5, T_Items.Lot, T_Items.QtyMax, T_Items.LrnExp, T_Items.DMY, T_Items.ItmTyp, T_Items.DefPack, T_Items.ItmImg, \r\n                                                                                  T_Items.InvSaleStoped, T_Items.InvPaymentStoped, T_Items.InvPaymentReturnStoped, T_Items.FirstCost, T_Items.CompanyID, T_Items.InvSaleReturnStoped, \r\n                                                                                  T_Items.SerialKey\r\n                                                                                  order by QtyMax desc", new object[0]).ToList();
                }
                else
                {
                    int PreviouspageLimit = (page - 1) * PageSize;
                    dt = db.ExecuteQuery<T_Item>("SELECT   TOP " + PageSize + "  T_Items.Itm_ID, T_Items.Itm_No, T_Items.ItmCat, T_Items.Arb_Des, T_Items.Eng_Des, T_Items.StartCost, T_Items.AvrageCost, T_Items.LastCost, T_Items.Price1, \r\n                                                                                  T_Items.Price3, T_Items.Price2, T_Items.Price5, T_Items.Price4, T_Items.Price6, T_Items.Unit1, T_Items.Pack1, T_Items.Unit2, T_Items.UntPri2, T_Items.UntPri1, \r\n                                                                                  T_Items.Pack2, T_Items.Unit3, T_Items.Pack3, T_Items.Unit4, T_Items.UntPri3, T_Items.UntPri4, T_Items.Pack4, T_Items.Unit5, T_Items.UntPri5, T_Items.Pack5, \r\n                                                                                  T_Items.DefultUnit, T_Items.DefultVendor, T_Items.OpenQty, T_Items.QtyLvl, T_Items.ItmLoc, T_Items.BarCod1, T_Items.BarCod2, T_Items.BarCod3, \r\n                                                                                  T_Items.BarCod4, T_Items.BarCod5, T_Items.Lot, T_Items.LrnExp, T_Items.DMY, T_Items.ItmTyp, T_Items.DefPack, T_Items.ItmImg, \r\n                                                                                  T_Items.InvSaleStoped, T_Items.InvPaymentStoped, T_Items.InvPaymentReturnStoped, T_Items.FirstCost, T_Items.CompanyID, T_Items.InvSaleReturnStoped, \r\n                                                                                  T_Items.SerialKey,sum(RealQty) as QtyMax\r\n                                                            FROM         T_Items INNER JOIN\r\n                                                                                  T_INVDET ON T_Items.Itm_No = T_INVDET.ItmNo INNER JOIN\r\n                                                                                  T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID\r\n                                                            WHERE T_INVHED.InvTyp = 21 and T_Items.ItmTyp != 1 and T_Items.InvSaleStoped = 0 AND  Itm_No NOT IN (Select TOP " + PreviouspageLimit + " Itm_ID from T_Items ORDER BY Itm_ID)\r\n                                                            Group By T_Items.Itm_ID, T_Items.Itm_No, T_Items.ItmCat, T_Items.Arb_Des, T_Items.Eng_Des, T_Items.StartCost, T_Items.AvrageCost, T_Items.LastCost, T_Items.Price1, \r\n                                                                                  T_Items.Price3, T_Items.Price2, T_Items.Price5, T_Items.Price4, T_Items.Price6, T_Items.Unit1, T_Items.Pack1, T_Items.Unit2, T_Items.UntPri2, T_Items.UntPri1, \r\n                                                                                  T_Items.Pack2, T_Items.Unit3, T_Items.Pack3, T_Items.Unit4, T_Items.UntPri3, T_Items.UntPri4, T_Items.Pack4, T_Items.Unit5, T_Items.UntPri5, T_Items.Pack5, \r\n                                                                                  T_Items.DefultUnit, T_Items.DefultVendor, T_Items.OpenQty, T_Items.QtyLvl, T_Items.ItmLoc, T_Items.BarCod1, T_Items.BarCod2, T_Items.BarCod3, \r\n                                                                                  T_Items.BarCod4, T_Items.BarCod5, T_Items.Lot, T_Items.QtyMax, T_Items.LrnExp, T_Items.DMY, T_Items.ItmTyp, T_Items.DefPack, T_Items.ItmImg, \r\n                                                                                  T_Items.InvSaleStoped, T_Items.InvPaymentStoped, T_Items.InvPaymentReturnStoped, T_Items.FirstCost, T_Items.CompanyID, T_Items.InvSaleReturnStoped, \r\n                                                                                  T_Items.SerialKey\r\n                                                                                  order by QtyMax desc", new object[0]).ToList();
                }
                int iicnt = 0;
                Size newSize = default(Size);
                try
                {
                    newSize = new Size(colW, rowH / 2 + rowH * 25 / 100);
                }
                catch
                {
                    newSize = new Size(130, 110);
                }
                foreach (GridRow rowCell in superGridControl1.PrimaryGrid.Rows)
                {
                    foreach (GridCell cell in rowCell.Cells)
                    {
                        if (iicnt < dt.Count)
                        {
                            try
                            {
                                if (rowCell.RowHeight <= rowH / 4)
                                {
                                    cell.CellStyles.Default.AllowWrap = Tbool.True;
                                    cell.Value = ((LangArEn == 0) ? dt[iicnt].Arb_Des : dt[iicnt].Eng_Des);
                                    cell.Tag = dt[iicnt].Itm_No;
                                    iicnt++;
                                }
                            }
                            catch
                            {
                                iicnt++;
                            }
                        }
                        else
                        {
                            cell.Value = "";
                        }
                    }
                }
                if (VarGeneral.Settings_Sys.Path_Kind < 2)
                {
                    iicnt = 0;
                    foreach (GridRow rowCell in superGridControl1.PrimaryGrid.Rows)
                    {
                        foreach (GridCell cell in rowCell.Cells)
                        {
                            if (iicnt >= dt.Count)
                            {
                                continue;
                            }
                            try
                            {
                                if (rowCell.RowHeight <= rowH / 4)
                                {
                                    continue;
                                }
                                cell.Tag = dt[iicnt].Itm_No;
                                if (VarGeneral.Settings_Sys.Path_Kind == 1)
                                {
                                    if (dt[iicnt].ItmImg != null)
                                    {
                                        byte[] arr = dt[iicnt].ItmImg.ToArray();
                                        MemoryStream stream = new MemoryStream(arr);
                                        cell.CellStyles.Default.Image = new Bitmap(Image.FromStream(stream), newSize);
                                    }
                                    else
                                    {
                                        cell.CellStyles.Default.Image = null;
                                    }
                                    try
                                    {
                                        cell.Tag = dt[iicnt].Itm_No;
                                        cell.Value = ".";
                                    }
                                    catch
                                    {
                                    }
                                }
                                else
                                {
                                    string[] filters = new string[7]
                                    {
                                        "jpg",
                                        "jpeg",
                                        "png",
                                        "gif",
                                        "tiff",
                                        "bmp",
                                        "gif"
                                    };
                                    string[] filePaths = GetFilesFrom(Application.StartupPath + "\\POS_IMG", filters, isRecursive: false);
                                    if (filePaths.Count() > 0)
                                    {
                                        Random rnd = new Random();
                                        string mypic_path = filePaths[rnd.Next(0, filePaths.Count() - 1)];
                                        if (File.Exists(mypic_path))
                                        {
                                            Image original = Image.FromFile(mypic_path);
                                            Image resized = ResizeImage(original, new Size(80, 80), preserveAspectRatio: false);
                                            cell.CellStyles.Default.Image = resized;
                                        }
                                    }
                                    try
                                    {
                                        cell.Tag = dt[iicnt].Itm_No;
                                        cell.Value = ".";
                                    }
                                    catch
                                    {
                                    }
                                }
                                cell.CellStyles.Default.ImageAlignment = Alignment.MiddleCenter;
                                iicnt++;
                            }
                            catch
                            {
                                iicnt++;
                            }
                        }
                    }
                }
            }
            catch
            {
            }
            superGridControl1.Refresh();
            Refresh();
        }
        public static Image ResizeImage(Image image, Size size, bool preserveAspectRatio)
        {
            int newWidth;
            int newHeight;
            if (preserveAspectRatio)
            {
                int originalWidth = image.Width;
                int originalHeight = image.Height;
                float percentWidth = (float)size.Width / (float)originalWidth;
                float percentHeight = (float)size.Height / (float)originalHeight;
                float percent = ((percentHeight < percentWidth) ? percentHeight : percentWidth);
                newWidth = (int)((float)originalWidth * percent);
                newHeight = (int)((float)originalHeight * percent);
            }
            else
            {
                newWidth = size.Width;
                newHeight = size.Height;
            }
            Image newImage = new Bitmap(newWidth, newHeight);
            using (Graphics graphicsHandle = Graphics.FromImage(newImage))
            {
                graphicsHandle.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphicsHandle.DrawImage(image, 0, 0, newWidth, newHeight);
            }
            return newImage;
        }
        public static string[] GetFilesFrom(string searchFolder, string[] filters, bool isRecursive)
        {
            List<string> filesFound = new List<string>();
            SearchOption searchOption = (isRecursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);
            foreach (string filter in filters)
            {
                filesFound.AddRange(Directory.GetFiles(searchFolder, $"*.{filter}", searchOption));
            }
            return filesFound.ToArray();
        }
        private void btnFirstPAge_Click(object sender, EventArgs e)
        {
            CurrentPageIndex = 1;
            GetCurrentRecords(CurrentPageIndex, vBestSaller: false);
        }
        private void btnNxtPage_Click(object sender, EventArgs e)
        {
            if (CurrentPageIndex < TotalPage)
            {
                CurrentPageIndex++;
                GetCurrentRecords(CurrentPageIndex, vBestSaller: false);
            }
        }
        private void btnPrevPage_Click(object sender, EventArgs e)
        {
            if (CurrentPageIndex > 1)
            {
                CurrentPageIndex--;
                GetCurrentRecords(CurrentPageIndex, vBestSaller: false);
            }
        }
        private void btnLastPage_Click(object sender, EventArgs e)
        {
            CurrentPageIndex = TotalPage;
            GetCurrentRecords(CurrentPageIndex, vBestSaller: false);
        }
        private void ClearItemsMain()
        {
            foreach (GridRow rowCell in superGridControl1.PrimaryGrid.Rows)
            {
                foreach (GridCell cell in rowCell.Cells)
                {
                    cell.Value = "";
                    cell.Tag = "";
                    cell.CellStyles.Default.Background.Color1 = Color.AliceBlue;
                }
            }
        }
        private void button_1_Click(object sender, EventArgs e)
        {
            try
            {
                if (ControlNo == 0)
                {
                    int vRowIndex = FlxInv.RowSel;
                    if (FlxInv.ColSel == 7 && vQtyGraid)
                    {
                        button_Bac_Click(sender, e);
                    }
                    else if (FlxInv.ColSel == 8 && vPriceGraid)
                    {
                        button_Bac_Click(sender, e);
                    }
                    else if (FlxInv.ColSel == 9 && vDisGraid)
                    {
                        button_Bac_Click(sender, e);
                    }
                    else if (FlxInv.ColSel == 31 && vTotGraid)
                    {
                        button_Bac_Click(sender, e);
                    }
                    else if (FlxInv.ColSel == 38 && vTotGraid)
                    {
                        button_Bac_Click(sender, e);
                    }
                    FlxInv.SetData(FlxInv.RowSel, FlxInv.ColSel, FlxInv.GetData(FlxInv.RowSel, FlxInv.ColSel).ToString() + "1");
                    FlxInv_AfterEdit(sender, new RowColEventArgs(FlxInv.RowSel, FlxInv.ColSel));
                    vQtyGraid = false;
                    vPriceGraid = false;
                    vTotGraid = false;
                    vDisGraid = false;
                    vTax = false;
                }
                else
                {
                    if (ControlNo == 1 || ControlNo == 2)
                    {
                        return;
                    }
                    if (ControlNo == 3)
                    {
                        txtRemark.Text += "1";
                    }
                    else if (ControlNo == 4)
                    {
                        txtRef.Text += "1";
                    }
                    else if (ControlNo == 5)
                    {
                        if (txtTele.Enabled)
                        {
                            txtTele.Text += "1";
                        }
                    }
                    else if (ControlNo == 6)
                    {
                        txtDiscountVal.Text = txtDiscountVal.Text.Substring(0, txtDiscountVal.Text.Length - 3) + "1";
                        txtDiscountVal_Leave(sender, e);
                    }
                    else if (ControlNo == 7)
                    {
                        txtDiscountP.Text = txtDiscountP.Text.Substring(0, txtDiscountP.Text.Length - 3) + "1";
                        txtDiscountP_Leave(sender, e);
                    }
                    return;
                }
            }
            catch
            {
            }
        }
        private void button_2_Click(object sender, EventArgs e)
        {
            try
            {
                if (ControlNo == 0)
                {
                    int vRowIndex = FlxInv.RowSel;
                    if (FlxInv.ColSel == 7 && vQtyGraid)
                    {
                        button_Bac_Click(sender, e);
                    }
                    else if (FlxInv.ColSel == 8 && vPriceGraid)
                    {
                        button_Bac_Click(sender, e);
                    }
                    else if (FlxInv.ColSel == 9 && vDisGraid)
                    {
                        button_Bac_Click(sender, e);
                    }
                    else if (FlxInv.ColSel == 31 && vTotGraid)
                    {
                        button_Bac_Click(sender, e);
                    }
                    else if (FlxInv.ColSel == 38 && vTotGraid)
                    {
                        button_Bac_Click(sender, e);
                    }
                    FlxInv.SetData(FlxInv.RowSel, FlxInv.ColSel, FlxInv.GetData(FlxInv.RowSel, FlxInv.ColSel).ToString() + "2");
                    FlxInv_AfterEdit(sender, new RowColEventArgs(FlxInv.RowSel, FlxInv.ColSel));
                    vQtyGraid = false;
                    vPriceGraid = false;
                    vTotGraid = false;
                    vDisGraid = false;
                    vTax = false;
                }
                else
                {
                    if (ControlNo == 1 || ControlNo == 2)
                    {
                        return;
                    }
                    if (ControlNo == 3)
                    {
                        txtRemark.Text += "2";
                    }
                    else if (ControlNo == 4)
                    {
                        txtRef.Text += "2";
                    }
                    else if (ControlNo == 5)
                    {
                        if (!txtTele.ReadOnly)
                        {
                            txtTele.Text += "2";
                        }
                    }
                    else if (ControlNo == 6)
                    {
                        txtDiscountVal.Text = txtDiscountVal.Text.Substring(0, txtDiscountVal.Text.Length - 3) + "2";
                        txtDiscountVal_Leave(sender, e);
                    }
                    else if (ControlNo == 7)
                    {
                        txtDiscountP.Text = txtDiscountP.Text.Substring(0, txtDiscountP.Text.Length - 3) + "2";
                        txtDiscountP_Leave(sender, e);
                    }
                    return;
                }
            }
            catch
            {
            }
        }
        private void button_3_Click(object sender, EventArgs e)
        {
            try
            {
                if (ControlNo == 0)
                {
                    int vRowIndex = FlxInv.RowSel;
                    if (FlxInv.ColSel == 7 && vQtyGraid)
                    {
                        button_Bac_Click(sender, e);
                    }
                    else if (FlxInv.ColSel == 8 && vPriceGraid)
                    {
                        button_Bac_Click(sender, e);
                    }
                    else if (FlxInv.ColSel == 9 && vDisGraid)
                    {
                        button_Bac_Click(sender, e);
                    }
                    else if (FlxInv.ColSel == 31 && vTotGraid)
                    {
                        button_Bac_Click(sender, e);
                    }
                    else if (FlxInv.ColSel == 38 && vTotGraid)
                    {
                        button_Bac_Click(sender, e);
                    }
                    FlxInv.SetData(FlxInv.RowSel, FlxInv.ColSel, FlxInv.GetData(FlxInv.RowSel, FlxInv.ColSel).ToString() + "3");
                    FlxInv_AfterEdit(sender, new RowColEventArgs(FlxInv.RowSel, FlxInv.ColSel));
                    vQtyGraid = false;
                    vPriceGraid = false;
                    vTotGraid = false;
                    vDisGraid = false;
                    vTax = false;
                }
                else
                {
                    if (ControlNo == 1 || ControlNo == 2)
                    {
                        return;
                    }
                    if (ControlNo == 3)
                    {
                        txtRemark.Text += "3";
                    }
                    else if (ControlNo == 4)
                    {
                        txtRef.Text += "3";
                    }
                    else if (ControlNo == 5)
                    {
                        if (!txtTele.ReadOnly)
                        {
                            txtTele.Text += "3";
                        }
                    }
                    else if (ControlNo == 6)
                    {
                        txtDiscountVal.Text = txtDiscountVal.Text.Substring(0, txtDiscountVal.Text.Length - 3) + "3";
                        txtDiscountVal_Leave(sender, e);
                    }
                    else if (ControlNo == 7)
                    {
                        txtDiscountP.Text = txtDiscountP.Text.Substring(0, txtDiscountP.Text.Length - 3) + "3";
                        txtDiscountP_Leave(sender, e);
                    }
                    return;
                }
            }
            catch
            {
            }
        }
        private void button_4_Click(object sender, EventArgs e)
        {
            try
            {
                if (ControlNo == 0)
                {
                    int vRowIndex = FlxInv.RowSel;
                    if (FlxInv.ColSel == 7 && vQtyGraid)
                    {
                        button_Bac_Click(sender, e);
                    }
                    else if (FlxInv.ColSel == 8 && vPriceGraid)
                    {
                        button_Bac_Click(sender, e);
                    }
                    else if (FlxInv.ColSel == 9 && vDisGraid)
                    {
                        button_Bac_Click(sender, e);
                    }
                    else if (FlxInv.ColSel == 31 && vTotGraid)
                    {
                        button_Bac_Click(sender, e);
                    }
                    else if (FlxInv.ColSel == 38 && vTotGraid)
                    {
                        button_Bac_Click(sender, e);
                    }
                    FlxInv.SetData(FlxInv.RowSel, FlxInv.ColSel, FlxInv.GetData(FlxInv.RowSel, FlxInv.ColSel).ToString() + "4");
                    FlxInv_AfterEdit(sender, new RowColEventArgs(FlxInv.RowSel, FlxInv.ColSel));
                    vQtyGraid = false;
                    vPriceGraid = false;
                    vTotGraid = false;
                    vDisGraid = false;
                    vTax = false;
                }
                else
                {
                    if (ControlNo == 1 || ControlNo == 2)
                    {
                        return;
                    }
                    if (ControlNo == 3)
                    {
                        txtRemark.Text += "4";
                    }
                    else if (ControlNo == 4)
                    {
                        txtRef.Text += "4";
                    }
                    else if (ControlNo == 5)
                    {
                        if (!txtTele.ReadOnly)
                        {
                            txtTele.Text += "4";
                        }
                    }
                    else if (ControlNo == 6)
                    {
                        txtDiscountVal.Text = txtDiscountVal.Text.Substring(0, txtDiscountVal.Text.Length - 3) + "4";
                        txtDiscountVal_Leave(sender, e);
                    }
                    else if (ControlNo == 7)
                    {
                        txtDiscountP.Text = txtDiscountP.Text.Substring(0, txtDiscountP.Text.Length - 3) + "4";
                        txtDiscountP_Leave(sender, e);
                    }
                    return;
                }
            }
            catch
            {
            }
        }
        private void button_5_Click(object sender, EventArgs e)
        {
            try
            {
                if (ControlNo == 0)
                {
                    int vRowIndex = FlxInv.RowSel;
                    if (FlxInv.ColSel == 7 && vQtyGraid)
                    {
                        button_Bac_Click(sender, e);
                    }
                    else if (FlxInv.ColSel == 8 && vPriceGraid)
                    {
                        button_Bac_Click(sender, e);
                    }
                    else if (FlxInv.ColSel == 9 && vDisGraid)
                    {
                        button_Bac_Click(sender, e);
                    }
                    else if (FlxInv.ColSel == 31 && vTotGraid)
                    {
                        button_Bac_Click(sender, e);
                    }
                    else if (FlxInv.ColSel == 38 && vTotGraid)
                    {
                        button_Bac_Click(sender, e);
                    }
                    FlxInv.SetData(FlxInv.RowSel, FlxInv.ColSel, FlxInv.GetData(FlxInv.RowSel, FlxInv.ColSel).ToString() + "5");
                    FlxInv_AfterEdit(sender, new RowColEventArgs(FlxInv.RowSel, FlxInv.ColSel));
                    vQtyGraid = false;
                    vPriceGraid = false;
                    vTotGraid = false;
                    vDisGraid = false;
                    vTax = false;
                }
                else
                {
                    if (ControlNo == 1 || ControlNo == 2)
                    {
                        return;
                    }
                    if (ControlNo == 3)
                    {
                        txtRemark.Text += "5";
                    }
                    else if (ControlNo == 4)
                    {
                        txtRef.Text += "5";
                    }
                    else if (ControlNo == 5)
                    {
                        if (!txtTele.ReadOnly)
                        {
                            txtTele.Text += "5";
                        }
                    }
                    else if (ControlNo == 6)
                    {
                        txtDiscountVal.Text = txtDiscountVal.Text.Substring(0, txtDiscountVal.Text.Length - 3) + "5";
                        txtDiscountVal_Leave(sender, e);
                    }
                    else if (ControlNo == 7)
                    {
                        txtDiscountP.Text = txtDiscountP.Text.Substring(0, txtDiscountP.Text.Length - 3) + "5";
                        txtDiscountP_Leave(sender, e);
                    }
                    return;
                }
            }
            catch
            {
            }
        }
        private void button_6_Click(object sender, EventArgs e)
        {
            try
            {
                int vRowIndex = FlxInv.RowSel;
                if (ControlNo == 0)
                {
                    if (FlxInv.ColSel == 7 && vQtyGraid)
                    {
                        button_Bac_Click(sender, e);
                    }
                    else if (FlxInv.ColSel == 8 && vPriceGraid)
                    {
                        button_Bac_Click(sender, e);
                    }
                    else if (FlxInv.ColSel == 9 && vDisGraid)
                    {
                        button_Bac_Click(sender, e);
                    }
                    else if (FlxInv.ColSel == 31 && vTotGraid)
                    {
                        button_Bac_Click(sender, e);
                    }
                    else if (FlxInv.ColSel == 38 && vTotGraid)
                    {
                        button_Bac_Click(sender, e);
                    }
                    FlxInv.SetData(FlxInv.RowSel, FlxInv.ColSel, FlxInv.GetData(FlxInv.RowSel, FlxInv.ColSel).ToString() + "6");
                    FlxInv_AfterEdit(sender, new RowColEventArgs(FlxInv.RowSel, FlxInv.ColSel));
                    vQtyGraid = false;
                    vPriceGraid = false;
                    vTotGraid = false;
                    vDisGraid = false;
                    vTax = false;
                }
                else
                {
                    if (ControlNo == 1 || ControlNo == 2)
                    {
                        return;
                    }
                    if (ControlNo == 3)
                    {
                        txtRemark.Text += "6";
                    }
                    else if (ControlNo == 4)
                    {
                        txtRef.Text += "6";
                    }
                    else if (ControlNo == 5)
                    {
                        if (!txtTele.ReadOnly)
                        {
                            txtTele.Text += "6";
                        }
                    }
                    else if (ControlNo == 6)
                    {
                        txtDiscountVal.Text = txtDiscountVal.Text.Substring(0, txtDiscountVal.Text.Length - 3) + "6";
                        txtDiscountVal_Leave(sender, e);
                    }
                    else if (ControlNo == 7)
                    {
                        txtDiscountP.Text = txtDiscountP.Text.Substring(0, txtDiscountP.Text.Length - 3) + "6";
                        txtDiscountP_Leave(sender, e);
                    }
                    return;
                }
            }
            catch
            {
            }
        }
        private void button_9_Click(object sender, EventArgs e)
        {
            try
            {
                if (ControlNo == 0)
                {
                    int vRowIndex = FlxInv.RowSel;
                    if (FlxInv.ColSel == 7 && vQtyGraid)
                    {
                        button_Bac_Click(sender, e);
                    }
                    else if (FlxInv.ColSel == 8 && vPriceGraid)
                    {
                        button_Bac_Click(sender, e);
                    }
                    else if (FlxInv.ColSel == 9 && vDisGraid)
                    {
                        button_Bac_Click(sender, e);
                    }
                    else if (FlxInv.ColSel == 31 && vTotGraid)
                    {
                        button_Bac_Click(sender, e);
                    }
                    else if (FlxInv.ColSel == 38 && vTotGraid)
                    {
                        button_Bac_Click(sender, e);
                    }
                    FlxInv.SetData(FlxInv.RowSel, FlxInv.ColSel, FlxInv.GetData(FlxInv.RowSel, FlxInv.ColSel).ToString() + "9");
                    FlxInv_AfterEdit(sender, new RowColEventArgs(FlxInv.RowSel, FlxInv.ColSel));
                    vQtyGraid = false;
                    vPriceGraid = false;
                    vTotGraid = false;
                    vDisGraid = false;
                    vTax = false;
                }
                else
                {
                    if (ControlNo == 1 || ControlNo == 2)
                    {
                        return;
                    }
                    if (ControlNo == 3)
                    {
                        txtRemark.Text += "9";
                    }
                    else if (ControlNo == 4)
                    {
                        txtRef.Text += "9";
                    }
                    else if (ControlNo == 5)
                    {
                        if (!txtTele.ReadOnly)
                        {
                            txtTele.Text += "9";
                        }
                    }
                    else if (ControlNo == 6)
                    {
                        txtDiscountVal.Text = txtDiscountVal.Text.Substring(0, txtDiscountVal.Text.Length - 3) + "9";
                        txtDiscountVal_Leave(sender, e);
                    }
                    else if (ControlNo == 7)
                    {
                        txtDiscountP.Text = txtDiscountP.Text.Substring(0, txtDiscountP.Text.Length - 3) + "9";
                        txtDiscountP_Leave(sender, e);
                    }
                    return;
                }
            }
            catch
            {
            }
        }
        private void button_8_Click(object sender, EventArgs e)
        {
            try
            {
                if (ControlNo == 0)
                {
                    int vRowIndex = FlxInv.RowSel;
                    if (FlxInv.ColSel == 7 && vQtyGraid)
                    {
                        button_Bac_Click(sender, e);
                    }
                    else if (FlxInv.ColSel == 8 && vPriceGraid)
                    {
                        button_Bac_Click(sender, e);
                    }
                    else if (FlxInv.ColSel == 9 && vDisGraid)
                    {
                        button_Bac_Click(sender, e);
                    }
                    else if (FlxInv.ColSel == 31 && vTotGraid)
                    {
                        button_Bac_Click(sender, e);
                    }
                    else if (FlxInv.ColSel == 38 && vTotGraid)
                    {
                        button_Bac_Click(sender, e);
                    }
                    FlxInv.SetData(FlxInv.RowSel, FlxInv.ColSel, FlxInv.GetData(FlxInv.RowSel, FlxInv.ColSel).ToString() + "8");
                    FlxInv_AfterEdit(sender, new RowColEventArgs(FlxInv.RowSel, FlxInv.ColSel));
                    vQtyGraid = false;
                    vPriceGraid = false;
                    vTotGraid = false;
                    vDisGraid = false;
                    vTax = false;
                }
                else
                {
                    if (ControlNo == 1 || ControlNo == 2)
                    {
                        return;
                    }
                    if (ControlNo == 3)
                    {
                        txtRemark.Text += "8";
                    }
                    else if (ControlNo == 4)
                    {
                        txtRef.Text += "8";
                    }
                    else if (ControlNo == 5)
                    {
                        if (!txtTele.ReadOnly)
                        {
                            txtTele.Text += "8";
                        }
                    }
                    else if (ControlNo == 6)
                    {
                        txtDiscountVal.Text = txtDiscountVal.Text.Substring(0, txtDiscountVal.Text.Length - 3) + "8";
                        txtDiscountVal_Leave(sender, e);
                    }
                    else if (ControlNo == 7)
                    {
                        txtDiscountP.Text = txtDiscountP.Text.Substring(0, txtDiscountP.Text.Length - 3) + "8";
                        txtDiscountP_Leave(sender, e);
                    }
                    return;
                }
            }
            catch
            {
            }
        }
        private void button_7_Click(object sender, EventArgs e)
        {
            try
            {
                if (ControlNo == 0)
                {
                    int vRowIndex = FlxInv.RowSel;
                    if (FlxInv.ColSel == 7 && vQtyGraid)
                    {
                        button_Bac_Click(sender, e);
                    }
                    else if (FlxInv.ColSel == 8 && vPriceGraid)
                    {
                        button_Bac_Click(sender, e);
                    }
                    else if (FlxInv.ColSel == 9 && vDisGraid)
                    {
                        button_Bac_Click(sender, e);
                    }
                    else if (FlxInv.ColSel == 31 && vTotGraid)
                    {
                        button_Bac_Click(sender, e);
                    }
                    else if (FlxInv.ColSel == 38 && vTotGraid)
                    {
                        button_Bac_Click(sender, e);
                    }
                    FlxInv.SetData(FlxInv.RowSel, FlxInv.ColSel, FlxInv.GetData(FlxInv.RowSel, FlxInv.ColSel).ToString() + "7");
                    FlxInv_AfterEdit(sender, new RowColEventArgs(FlxInv.RowSel, FlxInv.ColSel));
                    vQtyGraid = false;
                    vPriceGraid = false;
                    vTotGraid = false;
                    vDisGraid = false;
                    vTax = false;
                }
                else
                {
                    if (ControlNo == 1 || ControlNo == 2)
                    {
                        return;
                    }
                    if (ControlNo == 3)
                    {
                        txtRemark.Text += "7";
                    }
                    else if (ControlNo == 4)
                    {
                        txtRef.Text += "7";
                    }
                    else if (ControlNo == 5)
                    {
                        if (!txtTele.ReadOnly)
                        {
                            txtTele.Text += "7";
                        }
                    }
                    else if (ControlNo == 6)
                    {
                        txtDiscountVal.Text = txtDiscountVal.Text.Substring(0, txtDiscountVal.Text.Length - 3) + "7";
                        txtDiscountVal_Leave(sender, e);
                    }
                    else if (ControlNo == 7)
                    {
                        txtDiscountP.Text = txtDiscountP.Text.Substring(0, txtDiscountP.Text.Length - 3) + "7";
                        txtDiscountP_Leave(sender, e);
                    }
                    return;
                }
            }
            catch
            {
            }
        }
        private void button_Bac_Click(object sender, EventArgs e)
        {
            try
            {
                if (ControlNo == 0)
                {
                    int vRowIndex = FlxInv.RowSel;
                    FlxInv.SetData(FlxInv.RowSel, FlxInv.ColSel, "0");
                    FlxInv_AfterEdit(sender, new RowColEventArgs(FlxInv.RowSel, FlxInv.ColSel));
                    vQtyGraid = false;
                    vPriceGraid = false;
                    vTotGraid = false;
                    vDisGraid = false;
                    vTax = false;
                }
                else
                {
                    if (ControlNo == 1 || ControlNo == 2)
                    {
                        return;
                    }
                    if (ControlNo == 3)
                    {
                        txtRemark.Text = "";
                    }
                    else if (ControlNo == 4)
                    {
                        txtRef.Text = "";
                    }
                    else if (ControlNo == 5)
                    {
                        if (!txtTele.ReadOnly)
                        {
                            txtTele.Text = "";
                        }
                    }
                    else if (ControlNo == 6)
                    {
                        txtDiscountVal.Text = "0";
                        txtDiscountVal_Leave(sender, e);
                    }
                    else if (ControlNo == 7)
                    {
                        txtDiscountP.Text = "0";
                        txtDiscountP_Leave(sender, e);
                    }
                    return;
                }
            }
            catch
            {
            }
        }
        private void button_0_Click(object sender, EventArgs e)
        {
            try
            {
                if (ControlNo == 0)
                {
                    int vRowIndex = FlxInv.RowSel;
                    if (FlxInv.ColSel == 7 && vQtyGraid)
                    {
                        button_Bac_Click(sender, e);
                    }
                    else if (FlxInv.ColSel == 8 && vPriceGraid)
                    {
                        button_Bac_Click(sender, e);
                    }
                    else if (FlxInv.ColSel == 9 && vDisGraid)
                    {
                        button_Bac_Click(sender, e);
                    }
                    else if (FlxInv.ColSel == 31 && vTotGraid)
                    {
                        button_Bac_Click(sender, e);
                    }
                    else if (FlxInv.ColSel == 38 && vTotGraid)
                    {
                        button_Bac_Click(sender, e);
                    }
                    FlxInv.SetData(FlxInv.RowSel, FlxInv.ColSel, FlxInv.GetData(FlxInv.RowSel, FlxInv.ColSel).ToString() + "0");
                    FlxInv_AfterEdit(sender, new RowColEventArgs(FlxInv.RowSel, FlxInv.ColSel));
                    vQtyGraid = false;
                    vPriceGraid = false;
                    vTotGraid = false;
                    vDisGraid = false;
                    vTax = false;
                }
                else
                {
                    if (ControlNo == 1 || ControlNo == 2)
                    {
                        return;
                    }
                    if (ControlNo == 3)
                    {
                        txtRemark.Text += "0";
                    }
                    else if (ControlNo == 4)
                    {
                        txtRef.Text += "0";
                    }
                    else if (ControlNo == 5)
                    {
                        if (!txtTele.ReadOnly)
                        {
                            txtTele.Text += "0";
                        }
                    }
                    else if (ControlNo == 6)
                    {
                        txtDiscountVal.Text = txtDiscountVal.Text.Substring(0, txtDiscountVal.Text.Length - 3) + "0";
                        txtDiscountVal_Leave(sender, e);
                    }
                    else if (ControlNo == 7)
                    {
                        txtDiscountP.Text = txtDiscountP.Text.Substring(0, txtDiscountP.Text.Length - 3) + "0";
                        txtDiscountP_Leave(sender, e);
                    }
                    return;
                }
            }
            catch
            {
            }
        }
        private void PanaHide(bool Sts)
        {
        }
        private void FlxInv_LeaveCell(object sender, EventArgs e)
        {
            PanaHide(Sts: false);
        }
        private void FlxInv_Leave(object sender, EventArgs e)
        {
            try
            {
                if (VarGeneral.SSSLev != "R" && VarGeneral.SSSLev != "C" && VarGeneral.SSSLev != "H" && FlxInv.Rows[_RowIndex].Height == 33)
                {
                    FlxInv.SetData(_RowIndex - 1, 36, FlxInv.GetData(_RowIndex, (LangArEn == 0) ? 2 : 4));
                }
            }
            catch
            {
            }
        }
        private void FlxInv_AfterSelChange(object sender, RangeEventArgs e)
        {
            try
            {
                int vRowIndex = FlxInv.RowSel;
                for (int i = 1; i < FlxInv.Rows.Count; i++)
                {
                    if (i == vRowIndex)
                    {
                        FlxInv.SetData(i, 37, true);
                        button_DeleteLine.Visible = true;
                    }
                    else
                    {
                        FlxInv.SetData(i, 37, false);
                    }
                    FlxInv_AfterEdit(sender, new RowColEventArgs(i, 37));
                }
            }
            catch
            {
            }
        }
        private void txtGDate_Enter(object sender, EventArgs e)
        {
            ControlNo = 1;
            CheckSts(ControlNo);
        }
        private void txtHDate_Enter(object sender, EventArgs e)
        {
            ControlNo = 2;
            CheckSts(ControlNo);
        }
        private void txtTime_Enter(object sender, EventArgs e)
        {
            ControlNo = 3;
            CheckSts(ControlNo);
        }
        private void txtRef_Enter(object sender, EventArgs e)
        {
            ControlNo = 4;
            CheckSts(ControlNo);
        }
        private void txtTele_Enter(object sender, EventArgs e)
        {
            ControlNo = 5;
            CheckSts(ControlNo);
        }
        private void txtDiscountVal_Enter(object sender, EventArgs e)
        {
            ControlNo = 6;
            CheckSts(ControlNo);
        }
        private void txtDiscountP_Enter(object sender, EventArgs e)
        {
            ControlNo = 7;
            CheckSts(ControlNo);
        }
        private void CheckSts(int Sts)
        {
            try
            {
                if (ControlNo == 0)
                {
                    txtRef.ButtonCustom.Checked = false;
                    txtTele.ButtonCustom.Checked = false;
                    txtDiscountVal.ButtonCustom.Checked = false;
                    txtDiscountP.ButtonCustom.Checked = false;
                }
                else if (ControlNo == 1)
                {
                    txtRef.ButtonCustom.Checked = false;
                    txtTele.ButtonCustom.Checked = false;
                    txtDiscountVal.ButtonCustom.Checked = false;
                    txtDiscountP.ButtonCustom.Checked = false;
                }
                else if (ControlNo == 2)
                {
                    txtRef.ButtonCustom.Checked = false;
                    txtTele.ButtonCustom.Checked = false;
                    txtDiscountVal.ButtonCustom.Checked = false;
                    txtDiscountP.ButtonCustom.Checked = false;
                }
                else if (ControlNo == 3)
                {
                    txtRef.ButtonCustom.Checked = false;
                    txtTele.ButtonCustom.Checked = false;
                    txtDiscountVal.ButtonCustom.Checked = false;
                    txtDiscountP.ButtonCustom.Checked = false;
                }
                else if (ControlNo == 4)
                {
                    txtRef.ButtonCustom.Checked = true;
                    txtTele.ButtonCustom.Checked = false;
                    txtDiscountVal.ButtonCustom.Checked = false;
                    txtDiscountP.ButtonCustom.Checked = false;
                }
                else if (ControlNo == 5)
                {
                    txtRef.ButtonCustom.Checked = false;
                    txtTele.ButtonCustom.Checked = true;
                    txtDiscountVal.ButtonCustom.Checked = false;
                    txtDiscountP.ButtonCustom.Checked = false;
                }
                else if (ControlNo == 6)
                {
                    txtRef.ButtonCustom.Checked = false;
                    txtTele.ButtonCustom.Checked = false;
                    txtDiscountVal.ButtonCustom.Checked = true;
                    txtDiscountP.ButtonCustom.Checked = false;
                }
                else if (ControlNo == 7)
                {
                    txtRef.ButtonCustom.Checked = false;
                    txtTele.ButtonCustom.Checked = false;
                    txtDiscountVal.ButtonCustom.Checked = false;
                    txtDiscountP.ButtonCustom.Checked = true;
                }
            }
            catch
            {
            }
        }
        private void txtGDate_ButtonCustomClick(object sender, EventArgs e)
        {
            ControlNo = 1;
            CheckSts(ControlNo);
        }
        private void txtHDate_ButtonCustomClick(object sender, EventArgs e)
        {
            ControlNo = 2;
            CheckSts(ControlNo);
        }
        private void txtTime_ButtonCustomClick(object sender, EventArgs e)
        {
            ControlNo = 3;
            CheckSts(ControlNo);
        }
        private void txtRef_ButtonCustomClick(object sender, EventArgs e)
        {
            ControlNo = 4;
            CheckSts(ControlNo);
        }
        private void txtTele_ButtonCustomClick(object sender, EventArgs e)
        {
            ControlNo = 5;
            CheckSts(ControlNo);
        }
        private void txtDiscountVal_ButtonCustomClick(object sender, EventArgs e)
        {
            ControlNo = 6;
            CheckSts(ControlNo);
        }
        private void txtDiscountP_ButtonCustomClick(object sender, EventArgs e)
        {
            ControlNo = 7;
            CheckSts(ControlNo);
        }
        private void txtGDate_Click(object sender, EventArgs e)
        {
            txtGDate.SelectAll();
        }
        private void txtHDate_Click(object sender, EventArgs e)
        {
            txtHDate.SelectAll();
        }
        private void txtTime_Click(object sender, EventArgs e)
        {
            txtTime.SelectAll();
        }
        private void txtRemark_Enter(object sender, EventArgs e)
        {
            ControlNo = 3;
            CheckSts(ControlNo);
        }
        private void button_Space_Click(object sender, EventArgs e)
        {
            try
            {
                if (ControlNo == 0 || ControlNo == 1 || ControlNo == 2)
                {
                    return;
                }
                if (ControlNo == 3)
                {
                    txtRemark.Text += " ";
                }
                else if (ControlNo == 4)
                {
                    txtRef.Text += " ";
                }
                else if (ControlNo == 5)
                {
                    if (!txtTele.ReadOnly)
                    {
                        txtTele.Text += " ";
                    }
                }
                else if (ControlNo != 6 && ControlNo != 7)
                {
                }
            }
            catch
            {
            }
        }
        private void buttonItem_OrderOptions_Click(object sender, EventArgs e)
        {
        }
        private void button_SrchTable_Click(object sender, EventArgs e)
        {
            if (State == FormState.Edit || string.IsNullOrEmpty(textBox_ID.Text))
            {
                return;
            }
            if (State == FormState.Saved)
            {
                Button_Edit_Click(sender, e);
            }
            if ((data_this.RoomSts.HasValue && !data_this.RoomSts.Value) || string.IsNullOrEmpty(textBox_ID.Text))
            {
                return;
            }
            FrmTables frm2 = new FrmTables(textBox_ID.Text, 0, frmSts: false);
            frm2.Tag = LangArEn;
            VarGeneral.SFrmTyp = "";
            if (State == FormState.New)
            {
                frm2.sts_ = "new";
            }
            else
            {
                if (State != FormState.Edit)
                {
                    return;
                }
                try
                {
                    if (data_this.RoomNo.Value == 0)
                    {
                        frm2.sts_ = "new";
                    }
                    else
                    {
                        frm2.sts_ = "update";
                    }
                }
                catch
                {
                    return;
                }
            }
            frm2.TopMost = true;
            frm2.ShowDialog();
            if (frm2.sts_ == "new")
            {
                txtTable.Value = db.StockRommID(frm2.Serach_No).RomeNo;
                txtTable.Tag = frm2.Serach_No;
            }
            else
            {
                textBox_ID_TextChanged(sender, e);
            }
            TableTyp();
        }
        private void TableTyp()
        {
            try
            {
                if (txtTable.Value < 1 || string.IsNullOrEmpty(txtTable.Tag.ToString()) || State == FormState.New)
                {
                    labelTableTyp.Text = ((LangArEn == 0) ? "بدون طاولة" : "WithOut Table");
                    return;
                }
                T_Room q = db.StockRommID(int.Parse(txtTable.Tag.ToString()));
                if (q == null || string.IsNullOrEmpty(q.RomeNo.ToString()))
                {
                    labelTableTyp.Text = ((LangArEn == 0) ? "بدون طاولة" : "WithOut Table");
                }
                else if (q.Type == 1)
                {
                    labelTableTyp.Text = ((LangArEn == 0) ? "طاولات العوائل" : "Families Tables");
                }
                else if (q.Type == 2)
                {
                    labelTableTyp.Text = ((LangArEn == 0) ? "طاولات الشباب" : "Boys Tables");
                }
                else if (q.Type == 3)
                {
                    labelTableTyp.Text = ((LangArEn == 0) ? "طاولات خارجية" : "Extrnal Tables");
                }
                else if (q.Type == 4)
                {
                    labelTableTyp.Text = ((LangArEn == 0) ? "طاولات أخرى" : "Other Tables");
                }
                else
                {
                    labelTableTyp.Text = ((LangArEn == 0) ? "بدون طاولة" : "WithOut Table");
                }
            }
            catch
            {
                labelTableTyp.Text = ((LangArEn == 0) ? "بدون طاولة" : "WithOut Table");
            }
        }
        private void button_DeleteLine_Click(object sender, EventArgs e)
        {
            try
            {
                if (FlxInv.GetData(RowSel, 1).ToString() != null)
                {
                    if (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 32)))) == 2.0)
                    {
                        ItemDetRemoved.Add(int.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 25)))));
                    }
                    if (FlxInv.Rows[FlxInv.Row].Height > 33)
                    {
                        FlxInv.RemoveItem(FlxInv.Row);
                        FlxInv.RemoveItem(FlxInv.Row);
                    }
                    else
                    {
                        FlxInv.RemoveItem(FlxInv.Row - 1);
                        FlxInv.RemoveItem(FlxInv.Row);
                    }
                    GetInvTot();
                    try
                    {
                        FlxInv.SetData(FlxInv.RowSel, 37, true);
                    }
                    catch
                    {
                    }
                    FlxInv_AfterEdit(sender, new RowColEventArgs(FlxInv.RowSel, 37));
                }
            }
            catch
            {
                GetInvTot();
            }
        }
        private void superGridControl1_CellClick(object sender, GridCellClickEventArgs e)
        {
            try
            {
                int eRow = e.GridCell.RowIndex;
                int eCol = e.GridCell.ColumnIndex;
                if (!string.IsNullOrEmpty(textBox_ID.Text))
                {
                    if (State == FormState.Saved)
                    {
                        Button_Edit_Click(sender, e);
                    }
                    object q = superGridControl1.PrimaryGrid.GetCell(eRow, eCol).Tag;
                    if (!string.IsNullOrEmpty(q.ToString()) && !string.IsNullOrEmpty(superGridControl1.PrimaryGrid.GetCell(eRow, eCol).Value.ToString()))
                    {
                        _stsClick = 0;
                        _ItemProcess(q.ToString());
                    }
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("dataGridView_ItemMains_CellClick:", error, enable: true);
            }
        }
        private void RowNotes()
        {
            FlxInv.Rows.Add();
            FlxInv.Rows[FlxInv.Rows.Count - 1].Height = 33;
            if (!VarGeneral.TString.ChkStatShow(_SysSetting.LineDetailSts, 26))
            {
                FlxInv.Rows[FlxInv.Rows.Count - 1].Visible = false;
            }
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                FlxInv.MergedRanges.Add(FlxInv.GetCellRange(FlxInv.Rows.Count - 1, 37, FlxInv.Rows.Count - 1, 2));
            }
            else
            {
                FlxInv.MergedRanges.Add(FlxInv.GetCellRange(FlxInv.Rows.Count - 1, 37, FlxInv.Rows.Count - 1, 4));
            }
            FlxInv.Row = FlxInv.Rows.Count - 2;
            FlxInv.RowSel = FlxInv.Rows.Count - 2;
            FlxInv.Col = 1;
            FlxInv.Refresh();
        }
        private void _ItemProcess(string q)
        {
            List<T_Item> listSer = new List<T_Item>();
            listSer = db.StockItemList(q.ToString());
            _Items = listSer[0];
            FlxInv.Rows.Add();
            FlxInv.Rows[FlxInv.Rows.Count - 1].Height = 35;
            FlxInv.SetData(FlxInv.Rows.Count - 1, 1, _Items.Itm_No);
            FlxInv.Row = FlxInv.Rows.Count - 1;
            FlxInv.RowSel = FlxInv.Rows.Count - 1;
            FlxInv.Col = 1;
            RowNotes();
            BindDataOfItem();
            BindDataOfStkQty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 1)));
            Refresh();
        }
        private void buttonItem_BestSeller_Click(object sender, EventArgs e)
        {
            try
            {
                ItmMainParameter = "";
                FillItmesMain(null, vBestSaller: true);
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("metroTilePanel_Cat_ItemClick:", error, enable: true);
                Refresh();
            }
        }
        private void FrmWaiterMenue_FormClosed(object sender, FormClosedEventArgs e)
        {
            VarGeneral._IsPOS = false;
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
                    if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                    {
                        txtCustName.Text = db.StockAccDefWithOutBalance(txtCustNo.Text).Arb_Des;
                    }
                    else
                    {
                        txtCustName.Text = db.StockAccDefWithOutBalance(txtCustNo.Text).Eng_Des;
                    }
                    txtAddress.Text = db.StockAccDefWithOutBalance(txtCustNo.Text).Adders ?? "";
                    txtTele.Text = db.StockAccDefWithOutBalance(txtCustNo.Text).Telphone1 ?? "";
                    try
                    {
                        if (db.StockAccDefWithOutBalance(txtCustNo.Text).Mnd.HasValue)
                        {
                            int? mnd_Typ = db.StockAccDefWithOutBalance(txtCustNo.Text).T_Mndob.Mnd_Typ;
                            if (mnd_Typ.Value == 0 && mnd_Typ.HasValue)
                            {
                                CmbLegate.SelectedValue = db.StockAccDefWithOutBalance(txtCustNo.Text).Mnd;
                            }
                            else
                            {
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
                }
                else
                {
                    txtCustNo.Text = "";
                    txtCustRep.Value = 0.0;
                }
                txtCustNo_TextChanged(sender, e);
            }
            catch
            {
                txtCustNo.Text = "";
                txtCustRep.Value = 0.0;
                txtCustNo_TextChanged(sender, e);
            }
        }
        private void button_SrchCenterCost_Click(object sender, EventArgs e)
        {
            Button_Edit_Click(sender, e);
            if (State == FormState.Saved)
            {
                return;
            }
            try
            {
                FrmCustSearch frm = new FrmCustSearch();
                frm.vTy_ = 2;
                frm.Tag = LangArEn;
                frm.TopMost = true;
                frm.ShowDialog();
                if (frm.SerachNo != "")
                {
                    CmbCostC.SelectedValue = db.StockCst(frm.Serach_No).Cst_ID;
                }
                else
                {
                    CmbCostC.SelectedIndex = 0;
                }
            }
            catch
            {
                CmbCostC.SelectedIndex = 0;
            }
        }
        private void button_SrchMnd_Click(object sender, EventArgs e)
        {
            Button_Edit_Click(sender, e);
            if (State == FormState.Saved)
            {
                return;
            }
            try
            {
                FrmCustSearch frm = new FrmCustSearch();
                frm.vTy_ = 4;
                frm.Tag = LangArEn;
                frm.TopMost = true;
                frm.ShowDialog();
                if (frm.SerachNo != "")
                {
                    CmbLegate.SelectedValue = db.StockMndob(frm.Serach_No).Mnd_ID;
                }
                else
                {
                    CmbLegate.SelectedIndex = 0;
                }
            }
            catch
            {
                CmbLegate.SelectedIndex = 0;
            }
        }
        private void button_SrchCurr_Click(object sender, EventArgs e)
        {
            Button_Edit_Click(sender, e);
            if (State == FormState.Saved)
            {
                return;
            }
            try
            {
                FrmCustSearch frm = new FrmCustSearch();
                frm.vTy_ = 5;
                frm.Tag = LangArEn;
                frm.TopMost = true;
                frm.ShowDialog();
                if (frm.SerachNo != "")
                {
                    CmbCurr.SelectedValue = db.StockCurency(frm.Serach_No).Curency_ID;
                }
                else
                {
                    CmbCurr.SelectedIndex = 0;
                }
            }
            catch
            {
                CmbCurr.SelectedIndex = 0;
            }
        }
        private void button_SrchPriceDefault_Click(object sender, EventArgs e)
        {
            Button_Edit_Click(sender, e);
            if (State == FormState.Saved)
            {
                return;
            }
            try
            {
                FrmCustSearch frm = new FrmCustSearch();
                frm.vTy_ = 6;
                frm.Tag = LangArEn;
                frm.TopMost = true;
                frm.ShowDialog();
                if (frm.SerachNo != "")
                {
                    CmbInvPrice.SelectedIndex = int.Parse(frm.Serach_No);
                }
                else
                {
                    CmbInvPrice.SelectedIndex = 0;
                }
            }
            catch
            {
                CmbInvPrice.SelectedIndex = 0;
            }
        }
        private void button_SrchCustADD_Click(object sender, EventArgs e)
        {
            if (!VarGeneral.TString.ChkStatShow(permission.FilStr, 33))
            {
                MessageBox.Show((LangArEn == 0) ? "لايمكنك إضافة عميل جديد .. راجع صلاحيات المستخدمين" : "You can not add a new customer ... Check the Users Authorizations", VarGeneral.ProdectNam);
                return;
            }
            FrmCustomer frm = new FrmCustomer();
            frm.Tag = LangArEn;
            frm.TopMost = true;
            frm.ShowDialog();
        }
        private void FrmInvSalePoint_SizeChanged(object sender, EventArgs e)
        {
            FillCat();
            if (base.WindowState == FormWindowState.Normal)
            {
                btnPrevPage.Text = "";
                btnNxtPage.Text = "";
                buttonItem_BestSeller.Text = "";
            }
            else if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                btnPrevPage.Text = "سابق";
                btnNxtPage.Text = "تالي";
                buttonItem_BestSeller.Text = "أكثر مبيعا\u064c";
            }
            else
            {
                btnPrevPage.Text = "Prev";
                btnNxtPage.Text = "Next";
                buttonItem_BestSeller.Text = "Best Seller";
            }
        }
        private void switchButton_Lock_ValueChanged(object sender, EventArgs e)
        {
            if (!(textBox_ID.Text != "") || State != 0)
            {
                return;
            }
            Stock_DataDataContext _DB = new Stock_DataDataContext(VarGeneral.BranchCS);
            T_INVHED c = _DB.StockInvHead(VarGeneral.InvTyp, data_this.InvNo);
            List<T_INVHED> q = (from t in _DB.T_INVHEDs
                                where t.IfDel == (int?)0
                                where t.InvTyp == (int?)VarGeneral.InvTyp
                                where t.RoomNo == (int?)c.RoomNo.Value
                                orderby t.InvNo
                                select t).ToList();
            for (int i = 0; i < q.Count; i++)
            {
                T_INVHED WiterOrder = q[i];
                _DB.ExecuteCommand("UPDATE [T_INVHED] SET [AdminLock] =" + (switchButton_Lock.Value ? "1" : "0") + " where InvHed_ID= " + WiterOrder.InvHed_ID);
            }
            dbInstance = null;
            RefreshPKeys();
        }
        private void switchButton_Lock_Click(object sender, EventArgs e)
        {
        }
        private void button_AddToTable_Click(object sender, EventArgs e)
        {
            VarGeneral.Tb_Return = false;
            if (State == FormState.Edit || string.IsNullOrEmpty(textBox_ID.Text))
            {
                return;
            }
            if (State == FormState.Saved)
            {
                Button_Edit_Click(sender, e);
            }
            if ((data_this.RoomSts.HasValue && !data_this.RoomSts.Value) || string.IsNullOrEmpty(textBox_ID.Text))
            {
                return;
            }
            FrmTables frm2 = new FrmTables(textBox_ID.Text, 0, frmSts: false);
            frm2.Tag = LangArEn;
            VarGeneral.SFrmTyp = "AddToTable";
            if (State == FormState.New)
            {
                frm2.sts_ = "new";
            }
            else
            {
                if (State != FormState.Edit)
                {
                    return;
                }
                if (data_this.RoomNo.Value == 0)
                {
                    frm2.sts_ = "new";
                }
                else
                {
                    frm2.sts_ = "update";
                }
            }
            frm2.TopMost = true;
            frm2.ShowDialog();
            if (VarGeneral.Tb_Return)
            {
                button_SrchTable_Click(sender, e);
            }
            else if (frm2.sts_ == "new")
            {
                txtTable.Value = db.StockRommID(frm2.Serach_No).RomeNo;
                txtTable.Tag = frm2.Serach_No;
            }
            else
            {
                textBox_ID_TextChanged(sender, e);
            }
            VarGeneral.SFrmTyp = "";
            TableTyp();
        }
        private void switchButton_Tax_ValueChanged(object sender, EventArgs e)
        {
            GetInvTot();
        }
        private void checkBox_CostGaidTax_CheckedChanged(object sender, EventArgs e)
        {
            txtDueAmountLoc_ValueChanged(sender, e);
        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void labelTableTyp_Click(object sender, EventArgs e)
        {

        }
    }
}
