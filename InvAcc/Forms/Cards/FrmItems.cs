using C1.Win.C1BarCode;
using C1.Win.C1FlexGrid;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.DotNetBar.Metro;
using DevComponents.DotNetBar.SuperGrid;
using DevComponents.DotNetBar.SuperGrid.Style;
using DevComponents.Editors;
using Framework.Data;
using ProShared.GeneralM;using ProShared;
using ProShared.Stock_Data;
using Library.RepShow;
using SSSDateTime.Date;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial  class FrmItems : Form
    { void avs(int arln)

{ 
 tabItem1.Text=   (arln == 0 ? "  البيانات الوظيفيـــة  " : "  Functional data") ; buttonItem6.Text=   (arln == 0 ? "  إغلاق  " : "  Close") ; buttonItem5.Text=   (arln == 0 ? "  بحـــث  " : "  Search") ; buttonItem2.Text=   (arln == 0 ? "  buttonItem2  " : "  buttonItem2") ; buttonItem4.Text=   (arln == 0 ? "  حذف  " : "  delete") ; buttonItem3.Text=   (arln == 0 ? "  حفظ  " : "  save") ; buttonItem1.Text=   (arln == 0 ? "  جديد  " : "  new") ; ToolStripMenuItem_Rep.Text=   (arln == 0 ? "  إظهار التقرير  " : "  Show report") ; c1BarCode1.Text=   (arln == 0 ? "  1225  " : "  1225") ; label42.Text=   (arln == 0 ? "  تاريخ الانتهاء:  " : "  Expiry date:") ; label41.Text=   (arln == 0 ? "  تاريخ الانتاج:  " : "  Production Date:") ; radioButton_Goods.Text=   (arln == 0 ? "  سلعة  " : "  commodity") ; radioButton_RawMaterial.Text=   (arln == 0 ? "  مواد خامة  " : "  raw materials") ; radioButton_Service.Text=   (arln == 0 ? "  خدمة  " : "  service") ; radioButton_Product.Text=   (arln == 0 ? "  مجمعّة  " : "  assembled") ; radiobutton_RButDef1.Text=   (arln == 0 ? "  الوحدة الإفتراضية  " : "  virtual unit") ; labelItem8.Text=   (arln == 0 ? "  رقم الباركود :  " : "  barcode number:") ; labelItem7.Text=   (arln == 0 ? "  التكلفة :  " : "  the cost :") ; labelItem6.Text=   (arln == 0 ? "  الكمية :  " : "  Quantity :") ; labelItem30.Text=   (arln == 0 ? "  سعر البيع:  " : "  selling price:") ; labelItem5.Text=   (arln == 0 ? "   التعبئة :  " : "   packing:") ; labelItem4.Text=   (arln == 0 ? "  الوحدة :  " : "  Unit :") ; sideBarPanelItem_Unit1.Text=   (arln == 0 ? "  الوحدة الاولى  " : "  the first unit") ; radiobutton_RButDef5.Text=   (arln == 0 ? "  الوحدة الإفتراضية  " : "  virtual unit") ; labelItem25.Text=   (arln == 0 ? "  رقم الباركود :  " : "  barcode number:") ; labelItem28.Text=   (arln == 0 ? "  التكلفة :  " : "  the cost :") ; labelItem27.Text=   (arln == 0 ? "  الكمية :  " : "  Quantity :") ; labelItem34.Text=   (arln == 0 ? "  سعر البيع:  " : "  selling price:") ; labelItem26.Text=   (arln == 0 ? "   التعبئة :  " : "   packing:") ; labelItem24.Text=   (arln == 0 ? "  الوحدة :  " : "  Unit :") ; sideBarPanelItem_Unit5.Text=   (arln == 0 ? "  الوحدة الخامسة  " : "  Fifth unit") ; radiobutton_RButDef2.Text=   (arln == 0 ? "  الوحدة الافتراضية  " : "  virtual unit") ; labelItem10.Text=   (arln == 0 ? "  رقم الباركود :  " : "  barcode number:") ; labelItem13.Text=   (arln == 0 ? "  التكلفة :  " : "  the cost :") ; labelItem12.Text=   (arln == 0 ? "  الكمية :  " : "  Quantity :") ; labelItem31.Text=   (arln == 0 ? "  سعر البيع:  " : "  selling price:") ; labelItem11.Text=   (arln == 0 ? "   التعبئة :  " : "   packing:") ; labelItem9.Text=   (arln == 0 ? "  الوحدة :  " : "  Unit :") ; sideBarPanelItem_Unit2.Text=   (arln == 0 ? "  الوحدة الثانية  " : "  second unit") ; radiobutton_RButDef4.Text=   (arln == 0 ? "  الوحدة الإفتراضية  " : "  virtual unit") ; labelItem20.Text=   (arln == 0 ? "  رقم الباركود :  " : "  barcode number:") ; labelItem23.Text=   (arln == 0 ? "  التكلفة :  " : "  the cost :") ; labelItem22.Text=   (arln == 0 ? "  الكمية :  " : "  Quantity :") ; labelItem33.Text=   (arln == 0 ? "  سعر البيع:  " : "  selling price:") ; labelItem21.Text=   (arln == 0 ? "   التعبئة :  " : "   packing:") ; labelItem19.Text=   (arln == 0 ? "  الوحدة :  " : "  Unit :") ; sideBarPanelItem_Unit4.Text=   (arln == 0 ? "  الوحدة الرابعة  " : "  Fourth unit") ; radiobutton_RButDef3.Text=   (arln == 0 ? "  الوحدة الافتراضية  " : "  virtual unit") ; labelItem15.Text=   (arln == 0 ? "  رقم الباركود :  " : "  barcode number:") ; labelItem18.Text=   (arln == 0 ? "  التكلفة :  " : "  the cost :") ; labelItem17.Text=   (arln == 0 ? "  الكمية :  " : "  Quantity :") ; labelItem32.Text=   (arln == 0 ? "  سعر البيع:  " : "  selling price:") ; labelItem16.Text=   (arln == 0 ? "   التعبئة :  " : "   packing:") ; labelItem14.Text=   (arln == 0 ? "  الوحدة :  " : "  Unit :") ; sideBarPanelItem_Unit3.Text=   (arln == 0 ? "  الوحدة الثالثة  " : "  third unit") ; label5.Text=   (arln == 0 ? "  خصــم الصنف :  " : "  Category discount:") ; label16.Text=   (arln == 0 ? "  %  " : "  %") ; label11.Text=   (arln == 0 ? "  حد إعادة الطلب  " : "  Re-order limit") ; label8.Text=   (arln == 0 ? "  عمولة الصنف :  " : "  Item commission:") ; label14.Text=   (arln == 0 ? "  %  " : "  %") ; label15.Text=   (arln == 0 ? "  ضريبة المشتريات  " : "  purchase tax") ; label9.Text=   (arln == 0 ? "  %  " : "  %") ; label13.Text=   (arln == 0 ? "  ضريبة المبيعـــات  " : "  sales tax") ; label10.Text=   (arln == 0 ? "  %  " : "  %") ; labelX1.Text=   (arln == 0 ? "  صورة الصنف  " : "  Item Picture") ; label23.Text=   (arln == 0 ? "  الحد الأعلى :  " : "  the highest rate :") ; label3.Text=   (arln == 0 ? "  حساب المورد :  " : "  Supplier account:") ; label12.Text=   (arln == 0 ? "  التصنيف :  " : "  Category :") ; label4.Text=   (arln == 0 ? "  رقم الصنف :  " : "  Item No :") ; label2.Text=   (arln == 0 ? "  الإسم الإنجليزي :  " : "  English name:") ; label6.Text=   (arln == 0 ? "  الإسم العربي :  " : "  Arabic name:") ; label7.Text=   (arln == 0 ? "  رقم السيريال :  " : "  Serial number:") ; superTabItem_Details.Text=   (arln == 0 ? "  المحتويات  " : "  Contents") ; label1.Text=   (arln == 0 ? "  التنبية بتاريخ إنتهاء الصلاحية قبل :  " : "  Alert the expiration date before:") ; checkBoxX_Points.Text=   (arln == 0 ? "  تفعيــل النقـــــاط  " : "  Activate points") ; checkBoxX_BarcodeBalance.Text=   (arln == 0 ? "  ربط بميزان الباركود  " : "  Connect to barcode scale") ; label18.Text=   (arln == 0 ? "  RE  " : "  RE") ; label17.Text=   (arln == 0 ? "  LE  " : "  LE") ; labelFiled6.Text=   (arln == 0 ? "  SPH  " : "  SP") ; labelFiled3.Text=   (arln == 0 ? "  SPH  " : "  SP") ; labelFiled1.Text=   (arln == 0 ? "  AYIS  " : "  AYIS") ; labelFiled2.Text=   (arln == 0 ? "  CYL  " : "  CYL") ; labelFiled5.Text=   (arln == 0 ? "  CYL  " : "  CYL") ; labelFiled4.Text=   (arln == 0 ? "  AYIS  " : "  AYIS") ; label28.Text=   (arln == 0 ? "  سعر الجملة  " : "  Wholesale price") ; label24.Text=   (arln == 0 ? "  سعر المندوب  " : "  delegate price") ; label27.Text=   (arln == 0 ? "  سعر الموزع  " : "  distributor price") ; label26.Text=   (arln == 0 ? "  سعر آخر  " : "  Another price") ; label25.Text=   (arln == 0 ? "  سعر التجزئة  " : "  retail price") ; button_DeleteFromSystem.Text=   (arln == 0 ? "  إزالة الصنف من النظام  " : "  Remove the item from the system") ; checkBoxX_InvOut.Text=   (arln == 0 ? "  إخراج بضاعة  " : "  take out merchandise") ; checkBoxX_InvEnter.Text=   (arln == 0 ? "  إدخال بضاعة  " : "  Goods entry") ; checkBoxX_InvPaymentReturn.Text=   (arln == 0 ? "  مرتجع المشتريات  " : "  Purchase Returns") ; checkBoxX_InvPayment.Text=   (arln == 0 ? "  المشتريات  " : "  Purchases") ; checkBoxX_ReturnInvSale.Text=   (arln == 0 ? "  مرتجع المبيعات  " : "  Sales Return") ; checkBoxX_InvSale.Text=   (arln == 0 ? "  المبيعات  " : "  the sales") ; ToolStripMenuItem_Det.Text=   (arln == 0 ? "  إظهار التفاصيل  " : "  Show details") ; panelEx3.Text=   (arln == 0 ? "  Fill Panel  " : "  Fill Panel") ; DGV_Main.Text=   (arln == 0 ? "    " : "    ") ; DGV_Main.Text=   (arln == 0 ? "  جميــع السجــــلات  " : "  All records") ; DGV_Main.Text=   (arln == 0 ? "    " : "    ") ; superTabControl_DGV.Text=   (arln == 0 ? "  superTabControl1  " : "  superTabControl1") ; textBox_search.Text=   (arln == 0 ? "  ...  " : "  ...") ; Button_ExportTable2.Text=   (arln == 0 ? "  تصدير  " : "  Export") ; /*Button_PrintTable.Text=   (arln == 0 ? "  طباعة  " : "  Print") ; */buttonItem7.Text=   (arln == 0 ? "  عودة  " : "  back") ; panelEx2.Text=   (arln == 0 ? "  Click to collapse  " : "  Click to collapse") ; label33.Text=   (arln == 0 ? "  RE  " : "  RE") ; label34.Text=   (arln == 0 ? "  LE  " : "  LE") ; label35.Text=   (arln == 0 ? "  SPH  " : "  SP") ; label36.Text=   (arln == 0 ? "  SPH  " : "  SP") ; label37.Text=   (arln == 0 ? "  AYIS  " : "  AYIS") ; label38.Text=   (arln == 0 ? "  CYL  " : "  CYL") ; label39.Text=   (arln == 0 ? "  CYL  " : "  CYL") ; label40.Text=   (arln == 0 ? "  AYIS  " : "  AYIS") ; label19.Text=   (arln == 0 ? "  RE  " : "  RE") ; label20.Text=   (arln == 0 ? "  LE  " : "  LE") ; label21.Text=   (arln == 0 ? "  SPH  " : "  SP") ; label22.Text=   (arln == 0 ? "  SPH  " : "  SP") ; label29.Text=   (arln == 0 ? "  AYIS  " : "  AYIS") ; label30.Text=   (arln == 0 ? "  CYL  " : "  CYL") ; label31.Text=   (arln == 0 ? "  CYL  " : "  CYL") ; label32.Text=   (arln == 0 ? "  AYIS  " : "  AYIS") ; superTabControl_Main1.Text=   (arln == 0 ? "  superTabControl3  " : "  superTabControl3") ; buttonItem_EditPriceAll.Text=   (arln == 0 ? "  تعديل أسعــار جميــع الأصنــاف  " : "  Adjusting the prices of all items") ; buttonItem_EditPrice.Text=   (arln == 0 ? "  تعديل سعر وتكاليف هذا الصنف  " : "  Modify the price and costs of this item") ; buttonItem_AddDisProcess.Text=   (arln == 0 ? "  عمليات الزيادة والنقصان  " : "  Increase and decrease operations") ; Button_Close.Text=   (arln == 0 ? "  إغلاق  " : "  Close") ; Button_Search.Text=   (arln == 0 ? "  بحث  " : "  Search") ; Button_Delete.Text=   (arln == 0 ? "  حذف  " : "  delete") ; Button_Save.Text=   (arln == 0 ? "  حفظ  " : "  save") ; Button_Add.Text=   (arln == 0 ? "  إضافة  " : "  addition") ; buttonItem_Serials.Text=   (arln == 0 ? "  السيريال  " : "  serial السي") ; buttonItem8.Text=   (arln == 0 ? "  تصدير  " : "  Export") ; superTabControl_Main2.Text=   (arln == 0 ? "  superTabControl1  " : "  superTabControl1") ; Button_First.Text=   (arln == 0 ? "  الأول  " : "  the first") ; Button_Prev.Text=   (arln == 0 ? "  السابق  " : "  the previous") ; lable_Records.Text=   (arln == 0 ? "  ---  " : "  ---") ; Button_Next.Text=   (arln == 0 ? "  التالي  " : "  next one") ; Button_Last.Text=   (arln == 0 ? "  الأخير  " : "  the last one") ; superTabItem1.Text=   (arln == 0 ? "  superTabItem1  " : "  superTabItem1") ; Text = "الأصناف";this.Text=   (arln == 0 ? "  الأصناف  " : "  Categories") ;}
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
        private T_Company _Company = new T_Company();
        private T_SYSSETTING _SysSetting = new T_SYSSETTING();
        private T_INVSETTING _InvSetting = new T_INVSETTING();
        private T_Curency _Curency = new T_Curency();
        private Stock_DataDataContext dbInstance;
        private HijriGreg.HijriGregDates n = new HijriGreg.HijriGregDates();
        private Dictionary<string, ColumnDictinary> columns_Names_visible = new Dictionary<string, ColumnDictinary>();
        private Dictionary<string, ColumnDictinary> Dir_ButSearch = new Dictionary<string, ColumnDictinary>();
        private int LangArEn = 0;
        protected bool ifOkDelete;
        public bool CanEdit = true;
        protected bool CanInsert = true;
        public ViewState ViewState = ViewState.Deiles;
        private FormState statex;
        public List<Control> controls;
        public Control codeControl = new Control();
        private bool canUpdate = true;
        private T_Item data_this;
        private List<string> pkeys = new List<string>();
        private Rate_DataDataContext dbInstanceRate;
        private T_User permission = new T_User();
        private List<T_ItemDet> LData_This;
        private PrintDialog pdi = new PrintDialog();
        private int CountPage = 0;
        public Dictionary<string, ColumnDictinary> columns_Names_visible2 = new Dictionary<string, ColumnDictinary>();
        private string oldUnit = string.Empty;
        private T_Unit _Unit = new T_Unit();
        private List<T_Unit> listUnit = new List<T_Unit>();
        private T_Item _Items = new T_Item();
        private List<T_Item> listItems = new List<T_Item>();
        private T_Store _Store = new T_Store();
        private List<T_Store> listStore = new List<T_Store>();
        private List<T_Curency> listCurency = new List<T_Curency>();
        private T_STKSQTY _StksQty = new T_STKSQTY();
        private List<T_STKSQTY> listStkQty = new List<T_STKSQTY>();
        private double RateValue = 1.0;
        private int DefPack = 0;
        private double Pack = 0.0;
        private double PriceLoc = 0.0;
        private int RowSel = 0;
       // private IContainer components = null;
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData.ToString().Contains("Control") && !keyData.ToString().ToLower().Contains("delete") && keyData.ToString().Contains("Alt"))
            {
                try
                {
                    VarGeneral.Print_set_Gen_Stat = true;
                    FrmReportsViewer.IsSettingOnly = true;
                    VarGeneral.IsGeneralUsed = true;
                    {
                        FrmReportsViewer frm = new FrmReportsViewer();
                        frm.Repvalue = "RepGeneral";
                        frm.Repvalue = "RepGeneral";
                        //ADDADD
                        frm.Tag = LangArEn;
                        frm.ShowDialog();
                        VarGeneral.IsGeneralUsed = false;
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
                //ribbonBar1.BackgroundStyle.BackColor = Color.Gainsboro;
                //ribbonBar1.BackgroundStyle.BackColor2 = Color.Gainsboro;
            }
            if (e.Control.GetType() == typeof(Label))
            {
                Label c = (e.Control as Label); 
                
                if ((c.BackColor != System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))))) && (c.BackColor != System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))))) && (c.BackColor != System.Drawing.Color.SteelBlue))
                    e.Control.BackColor = Color.Transparent; Size cc = e.Control.PreferredSize;

                e.Control.AutoSize = false;
                e.Control.Size = cc;
       
            //    e.Control.Font= new System.Drawing.Font("Tahoma",(float) (c-0.5));
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
        private TabItem tabItem1;
        private ButtonItem buttonItem2;
        protected ToolStripMenuItem ToolStripMenuItem_Rep;
        private RibbonBar ribbonBar_Units;
        private ImageList imageList1;
        protected ContextMenuStrip contextMenuStrip1;
        protected ContextMenuStrip contextMenuStrip2;
        protected ToolStripMenuItem ToolStripMenuItem_Det;
        private System.Windows.Forms.OpenFileDialog  openFileDialog1;
        private System.Windows.Forms. SaveFileDialog saveFileDialog1;
        private PanelEx panelEx3;
        private PanelEx panelEx2;
        private ExpandableSplitter expandableSplitter1;
        private Panel panel1;
        private SuperTabItem superTabItem1;
        private IntegerInput textbox_DateNo;
        private Label label1;
        private ExpandablePanel expandablePanel_AnotherPrice;
        private C1BarCode c1BarCode1;
        private TextBox txtCurr;
        private ComboBox combobox_Unit5;
        private ComboBox combobox_Unit4;
        private ComboBox combobox_Unit3;
        private ComboBox combobox_Unit2;
        private ComboBox combobox_Unit1;
        protected SuperGridControl DGV_Main;
        private RibbonBar ribbonBar_DGV;
        private SuperTabControl superTabControl_DGV;
        private RibbonBar ribbonBar_Tasks;
        private PrintDialog printDialog1;
        internal PrintPreviewDialog prnt_prev;
        private System.Windows.Forms.OpenFileDialog  openFileDialog2;
        internal PrintDocument prnt_doc;
        private FileSystemWatcher fileSystemWatcher1;
        private SuperTabControl superTabControl_Main1;
        private SuperTabControl superTabControl_Main2;
        private SuperTabControl superTabControl1;
        private SuperTabControlPanel superTabControlPanel1;
        private SuperTabItem superTabItem_General;
        private SuperTabControlPanel superTabControlPanel2;
        private SuperTabItem superTabItem_Details;
        private LabelX labelX1;
        private ButtonX button_SrchCustNo;
        private TextBox txtCustNo;
        private ReflectionImage pictureBox_PicItem;
        private ComboBoxEx combobox_ItmeGroup;
        private DoubleInput textbox_MaxQty;
        private Label label23;
        private DoubleInput textbox_Supreme;
        private Label label3;
        private ButtonX button_ClearPic;
        private ButtonX button_AddNewCat;
        private ButtonX button_SrchItemGroup;
        private TextBox textbox_Eng_Des;
        private Label label12;
        private Label label4;
        private Label label2;
        private TextBox textbox_Arb_Des;
        private Label label6;
        private TextBox textBox_ID;
        private ButtonX button_EnterImg;
        private CheckBoxX checkBoxX_InvPaymentReturn;
        private CheckBoxX checkBoxX_InvPayment;
        private CheckBoxX checkBoxX_ReturnInvSale;
        private CheckBoxX checkBoxX_InvSale;
        internal TextBox txtCustName;
        private C1FlexGrid FlxInv;
        private LabelItem lable_Records;
        private C1FlexGrid c1FlexGrid_Items;
        private TextBox textBox_SerialKey;
        private Label label7;
        private Label label10;
        private DoubleInput textBox_CommItm;
        private Label label14;
        private DoubleInput textBox_TaxPurchase;
        protected Label label15;
        private Label label9;
        private DoubleInput textBox_TaxSales;
        protected Label label13;
        protected Label label8;
        private CheckBoxX checkBoxX_InvOut;
        private CheckBoxX checkBoxX_InvEnter;
        protected Label label11;
        protected Label label5;
        private Label label16;
        private DoubleInput textBox_DisItem;
        private ButtonX button_DeleteFromSystem;
        private TextBox doubleInput_DefPack;
        private ComboBoxEx comboBox_DefPack;
        private ButtonItem buttonItem_EditPriceAll;
        private ButtonItem buttonItem_EditPrice;
        private CheckBoxX checkBoxX_BarcodeBalance;
        private CheckBoxX checkBoxX_Points;
        private ButtonItem buttonItem_AddDisProcess;
        private PanelEx panelEx_Size;
        private Label labelFiled6;
        private Label labelFiled3;
        private Label labelFiled1;
        private Label labelFiled2;
        private Label labelFiled5;
        private Label labelFiled4;
        private TextBox txtFiled1;
        private TextBox txtFiled2;
        private TextBox txtFiled3;
        private TextBox txtFiled6;
        private TextBox txtFiled5;
        private TextBox txtFiled4;
        private Label label17;
        private ButtonItem buttonItem7;
        private Panel panel2;
        private MetroStatusBar metroStatusBar_itemsType;
        private LabelItem labelItem29;
        private CheckBoxItem radioButton_Goods;
        private CheckBoxItem radioButton_RawMaterial;
        private CheckBoxItem radioButton_Service;
        private CheckBoxItem radioButton_Product;
        private SuperTabControl superTabControl_Info;
        private SuperTabControlPanel superTabControlPanel3;
        private TextBoxX txtBarCode1;
        private RadioButton radiobutton_RButDef1;
        private Label labelItem8;
        private TextBox textbox_Cost1;
        private Label labelItem7;
        private TextBox textbox_Qty1;
        private Label labelItem6;
        private TextBox textbox_SelPri1;
        private TextBox textbox_Pack1;
        private ComboBox comboboxItems_Unit1;
        private Label labelItem5;
        private Label labelItem4;
        private SuperTabItem sideBarPanelItem_Unit1;
        private SuperTabControlPanel superTabControlPanel7;
        private TextBoxX txtBarCode5;
        private Label labelItem25;
        private TextBox textbox_Cost5;
        private Label labelItem28;
        private TextBox textbox_Qty5;
        private Label labelItem27;
        private TextBox textbox_SelPri5;
        private Label labelItem34;
        private TextBox textbox_Pack5;
        private ComboBox comboboxItems_Unit5;
        private Label labelItem26;
        private Label labelItem24;
        private SuperTabItem sideBarPanelItem_Unit5;
        private SuperTabControlPanel superTabControlPanel6;
        private TextBoxX txtBarCode4;
        private Label labelItem20;
        private TextBox textbox_Cost4;
        private Label labelItem23;
        private TextBox textbox_Qty4;
        private Label labelItem22;
        private TextBox textbox_SelPri4;
        private Label labelItem33;
        private TextBox textbox_Pack4;
        private ComboBox comboboxItems_Unit4;
        private Label labelItem21;
        private Label labelItem19;
        private SuperTabItem sideBarPanelItem_Unit4;
        private SuperTabControlPanel superTabControlPanel5;
        private TextBoxX txtBarCode3;
        private Label labelItem15;
        private TextBox textbox_Cost3;
        private Label labelItem18;
        private TextBox textbox_Qty3;
        private Label labelItem17;
        private TextBox textbox_SelPri3;
        private Label labelItem32;
        private TextBox textbox_Pack3;
        private ComboBox comboboxItems_Unit3;
        private Label labelItem16;
        private Label labelItem14;
        private SuperTabItem sideBarPanelItem_Unit3;
        private SuperTabControlPanel superTabControlPanel4;
        private TextBoxX txtBarCode2;
        private Label labelItem10;
        private TextBox textbox_Cost2;
        private Label labelItem13;
        private TextBox textbox_Qty2;
        private Label labelItem12;
        private TextBox textbox_SelPri2;
        private Label labelItem31;
        private TextBox textbox_Pack2;
        private ComboBox comboboxItems_Unit2;
        private Label labelItem11;
        private Label labelItem9;
        private SuperTabItem sideBarPanelItem_Unit2;
        private SuperTabControlPanel superTabControlPanel12;
        private RadioButton radiobutton_RButDef5;
        private RadioButton radiobutton_RButDef4;
        private RadioButton radiobutton_RButDef3;
        private RadioButton radiobutton_RButDef2;
        private Panel panel3;
        private ExpandablePanel grouhpPanel_Inv;
        private PanelEx panelEx1;
        private Label label19;
        private Label label20;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private TextBox textBox5;
        private TextBox textBox6;
        private Label label21;
        private Label label22;
        private Label label29;
        private Label label30;
        private Label label31;
        private Label label32;
        private ExpandablePanel groupPanel_Inv;
        private PanelEx panelEx4;
        private Label label33;
        private Label label34;
        private TextBox textBox7;
        private TextBox textBox8;
        private TextBox textBox9;
        private TextBox textBox10;
        private TextBox textBox11;
        private TextBox textBox12;
        private Label label35;
        private Label label36;
        private Label label37;
        private Label label38;
        private Label label39;
        private Label label40;
        private TextBox Txt_ExpirationDate;
        private Label label42;
        private TextBox Txt_ProductionDate;
        private Label label41;
        private Panel PanelContainerSpatial;
        private Label label18;
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
        public T_Item DataThis
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
        public bool SetReadOnly
        {
            set
            {
                if (value)
                {
                    State = FormState.Saved;
                }
                Button_Save.Enabled = !value;
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
        public T_User Permmission
        {
            get
            {
                return permission;
            }
            set
            {
                if (value != null && value.UsrNo != string.Empty)
                {
                    permission = value;
                    if (!VarGeneral.TString.ChkStatShow(value.FilStr, 5))
                    {
                        IfAdd = false;
                    }
                    else
                    {
                        IfAdd = true;
                    }
                    if (!VarGeneral.TString.ChkStatShow(value.FilStr, 6))
                    {
                        CanEdit = false;
                    }
                    else
                    {
                        CanEdit = true;
                    }
                    if (!VarGeneral.TString.ChkStatShow(value.FilStr, 7))
                    {
                        IfDelete = false;
                    }
                    else
                    {
                        IfDelete = true;
                    }
                    if (!VarGeneral.TString.ChkStatShow(value.SetStr, 5))
                    {
                        buttonItem_EditPrice.Visible = false;
                    }
                    else
                    {
                        buttonItem_EditPrice.Visible = true;
                    }
                }
            }
        }
        public List<T_ItemDet> LDataThis
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
        public void RefreshPKeys()
        {
            PKeys.Clear();
            try
            {
                PKeys = db.ExecuteQuery<string>("select Itm_No from T_Items order by Itm_No ", new object[0]).ToList();
            }
            catch
            {
                PKeys.Clear();
            }
            int count = 0;
            count = PKeys.Count;
            try
            {
                PKeys = PKeys.OrderBy((string c) => int.Parse(c)).ToList();
            }
            catch
            {
            }
            Label_Count.Text = string.Concat(count);
            UpdateVcr();
        }
        private void Frm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                SendKeys.Send("{Tab}");
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
                return true;
            }
            return true;
        }
        public FrmItems()
        {
            InitializeComponent();this.Load += langloads;
   
            try
            {
                addevents();
                txtBarCode1.ButtonCustom.Visible = true;
                txtBarCode2.ButtonCustom.Visible = true;
                txtBarCode3.ButtonCustom.Visible = true;
                txtBarCode4.ButtonCustom.Visible = true;
                txtBarCode5.ButtonCustom.Visible = true;
            }
#pragma warning disable CS0168 // The variable 'EX' is declared but never used
            catch(Exception EX)
#pragma warning restore CS0168 // The variable 'EX' is declared but never used
            {
                txtBarCode1.ButtonCustom.Visible = false;
                txtBarCode2.ButtonCustom.Visible = false;
                txtBarCode3.ButtonCustom.Visible = false;
                txtBarCode4.ButtonCustom.Visible = false;
                txtBarCode5.ButtonCustom.Visible = false;
            }
            Txt_ExpirationDate.Click += Button_Edit_Click;
            Txt_ProductionDate.Click += Button_Edit_Click;
            textbox_Pack3.EnabledChanged += textbox_Pack2_EnabledChanged;
            textbox_Pack4.EnabledChanged += textbox_Pack2_EnabledChanged;
            textbox_Pack5.EnabledChanged += textbox_Pack2_EnabledChanged;
            checkBoxX_Points.Click += Button_Edit_Click;
            checkBoxX_BarcodeBalance.Click += Button_Edit_Click;
            checkBoxX_InvSale.Click += Button_Edit_Click;
            checkBoxX_InvPayment.Click += Button_Edit_Click;
            checkBoxX_ReturnInvSale.Click += Button_Edit_Click;
            checkBoxX_InvPaymentReturn.Click += Button_Edit_Click;
            checkBoxX_InvEnter.Click += Button_Edit_Click;
            checkBoxX_InvOut.Click += Button_Edit_Click;
            doubleInput_DefPack.Click += Button_Edit_Click;
            textbox_Arb_Des.Click += Button_Edit_Click;
            textBox_CommItm.Click += Button_Edit_Click;
            textBox_DisItem.Click += Button_Edit_Click;
            textBox_TaxSales.Click += Button_Edit_Click;
            textBox_TaxPurchase.Click += Button_Edit_Click;
            textBox_SerialKey.Click += Button_Edit_Click;
            textbox_Cost1.Click += Button_Edit_Click;
            textbox_Cost2.Click += Button_Edit_Click;
            textbox_Cost3.Click += Button_Edit_Click;
            textbox_Cost4.Click += Button_Edit_Click;
            textbox_Cost5.Click += Button_Edit_Click;
            textbox_DateNo.Click += Button_Edit_Click;
            textbox_Distributors.Click += Button_Edit_Click;
            textbox_Eng_Des.Click += Button_Edit_Click;
            button_AddNewCat.Click += Button_Edit_Click;
            textbox_Legates.Click += Button_Edit_Click;
            textbox_MaxQty.Click += Button_Edit_Click;
            textbox_Pack1.Click += Button_Edit_Click;
            textbox_Pack2.Click += Button_Edit_Click;
            textbox_Pack3.Click += Button_Edit_Click;
            textbox_Pack4.Click += Button_Edit_Click;
            textbox_Pack5.Click += Button_Edit_Click;
            textbox_Qty1.Click += Button_Edit_Click;
            textbox_Qty2.Click += Button_Edit_Click;
            textbox_Qty3.Click += Button_Edit_Click;
            textbox_Qty4.Click += Button_Edit_Click;
            textbox_Qty5.Click += Button_Edit_Click;
            textbox_Sectorial.Click += Button_Edit_Click;
            textbox_SelPri1.Click += Button_Edit_Click;
            textbox_SelPri2.Click += Button_Edit_Click;
            textbox_SelPri3.Click += Button_Edit_Click;
            textbox_SelPri4.Click += Button_Edit_Click;
            textbox_SelPri5.Click += Button_Edit_Click;
            textbox_Sentence.Click += Button_Edit_Click;
            textbox_Supreme.Click += Button_Edit_Click;
            textbox_VIP.Click += Button_Edit_Click;
            radiobutton_RButDef1.Click += Button_Edit_Click;
            radiobutton_RButDef2.Click += Button_Edit_Click;
            radiobutton_RButDef3.Click += Button_Edit_Click;
            radiobutton_RButDef4.Click += Button_Edit_Click;
            radiobutton_RButDef5.Click += Button_Edit_Click;
            button_EnterImg.Click += Button_Edit_Click;
            combobox_DateTyp.Click += Button_Edit_Click;
            radioButton_Goods.Click += Button_Edit_Click;
            radioButton_Product.Click += Button_Edit_Click;
            radioButton_RawMaterial.Click += Button_Edit_Click;
            radioButton_Service.Click += Button_Edit_Click;
            combobox_ItmeGroup.Click += Button_Edit_Click;
            comboBox_DefPack.Click += Button_Edit_Click;
            comboboxItems_Unit1.Click += Button_Edit_Click;
            comboboxItems_Unit2.Click += Button_Edit_Click;
            comboboxItems_Unit3.Click += Button_Edit_Click;
            comboboxItems_Unit4.Click += Button_Edit_Click;
            comboboxItems_Unit5.Click += Button_Edit_Click;
            txtBarCode1.Click += Button_Edit_Click;
            txtBarCode2.Click += Button_Edit_Click;
            txtBarCode3.Click += Button_Edit_Click;
            txtBarCode4.Click += Button_Edit_Click;
            txtBarCode5.Click += Button_Edit_Click;
            txtFiled1.Click += Button_Edit_Click;
            txtFiled2.Click += Button_Edit_Click;
            txtFiled3.Click += Button_Edit_Click;
            txtFiled4.Click += Button_Edit_Click;
            txtFiled5.Click += Button_Edit_Click;
            txtFiled6.Click += Button_Edit_Click;
            DGV_Main.PrimaryGrid.CheckBoxes = false;
            DGV_Main.PrimaryGrid.ShowCheckBox = false;
            DGV_Main.PrimaryGrid.ShowTreeButton = false;
            DGV_Main.PrimaryGrid.ShowTreeButtons = false;
            DGV_Main.PrimaryGrid.ShowTreeLines = false;
            DGV_Main.PrimaryGrid.RowHeaderWidth = 25;
            DGV_Main.DataBindingComplete += DGV_Main_DataBindingComplete;
            expandableSplitter1.Click += expandableSplitter1_Click;
            ToolStripMenuItem_Det.Click += ToolStripMenuItem_Det_Click;
            Button_ExportTable2.Click += Button_ExportTable2_Click;
            textBox_search.InputTextChanged += TextBox_Search_InputTextChanged;
            textBox_search.ButtonCustomClick += TextBox_Search_ButtonCustomClick;
            TextBox_Index.InputTextChanged += TextBox_Index_InputTextChanged;
            TextBox_Index.InputTextChanged += TextBox_Index_InputTextChanged;
            Button_First.Click += Button_First_Click;
            Button_Prev.Click += Button_Prev_Click;
            Button_Next.Click += Button_Next_Click;
            Button_Last.Click += Button_Last_Click;
            Button_Add.Click += Button_Add_Click;
 
            Button_Delete.Click += Button_Delete_Click;
            Button_Save.Click += Button_Save_Click;
            Button_Close.Click += Button_Close_Click;
            Button_PrintTable.Click += Button_Print_Click;
            DGV_Main.DataBindingComplete += DGV_Main_DataBindingComplete;
            DGV_Main.MouseDown += DGV_Main_MouseDown;
            DGV_Main.CellDoubleClick += DGV_Main_CellDoubleClick;
            DGV_Main.CellClick += DGV_Main_CellClick;
            txtCustName.Click += Button_Edit_Click;
            txtCustNo.Click += Button_Edit_Click;
            FlxInv.KeyDown += FlxInv_KeyDown;
            FlxInv.MouseDown += FlxInv_MouseDown;
            FlxInv.RowColChange += FlxInv_RowColChange;
            FlxInv.SelChange += FlxInv_SelChange;
            GetInvSetting();
            if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49))
            {
                c1FlexGrid_Items.Cols[1].Format = VarGeneral.DicimalNN;
                c1FlexGrid_Items.Cols[2].Format = VarGeneral.DicimalNN;
                c1FlexGrid_Items.Cols[3].Format = VarGeneral.DicimalNN;
                c1FlexGrid_Items.Cols[4].Format = VarGeneral.DicimalNN;
                FlxInv.Cols[8].Format = VarGeneral.DicimalNN;
                FlxInv.Cols[9].Format = VarGeneral.DicimalNN;
                FlxInv.Cols[10].Format = VarGeneral.DicimalNN;
                FlxInv.Cols[11].Format = VarGeneral.DicimalNN;
                FlxInv.Cols[12].Format = VarGeneral.DicimalNN;
                FlxInv.Cols[31].Format = VarGeneral.DicimalNN;
                textBox_TaxPurchase.DisplayFormat = VarGeneral.DicemalMask;
                textBox_TaxSales.DisplayFormat = VarGeneral.DicemalMask;
                textbox_Legates.DisplayFormat = VarGeneral.DicemalMask;
                textbox_Distributors.DisplayFormat = VarGeneral.DicemalMask;
                textbox_Sentence.DisplayFormat = VarGeneral.DicemalMask;
                textbox_Sectorial.DisplayFormat = VarGeneral.DicemalMask;
                textbox_VIP.DisplayFormat = VarGeneral.DicemalMask;
            }
            if (VarGeneral.SSSLev == "F")
            {
                checkBoxX_Points.Visible = false;
            }
        }
        private void GetInvSetting()
        {
            _InvSetting = db.StockInvSetting( 22);
            _SysSetting = db.SystemSettingStock();
            _Company = db.StockCompanyList().FirstOrDefault();
            _Curency = db.Fillcurency_2(string.Empty).FirstOrDefault();
            txtCurr.Text = _Curency.Symbol;
        }
        public void Button_Search_Click(object sender, EventArgs e)
        {
            Button_Search_Click_1(null, null);
        }
void ArbEng()
        {
            labelX1.Text = (LangArEn== 0 ? "صورة الصنف" : "Item Pic");
            this.label5.Text = (LangArEn== 0 ? "خصــم الصنف :" : "Item Discount:");
            this.label16.Text = (LangArEn== 0 ? "%" : "%");
            this.label11.Text = (LangArEn== 0 ? "حد إعادة الطلب" : "Item ReOrder Limit:");
            this.label8.Text = (LangArEn== 0 ? "عمولة الصنف :" : "Item Comm");
            this.label14.Text = (LangArEn== 0 ? "%" : "%");
            this.label15.Text = (LangArEn== 0 ? "ضريبة المشتريات" : "Purches Tax:");
            this.label9.Text = (LangArEn== 0 ? "%" : "%");
            this.label13.Text = (LangArEn== 0 ? "ضريبة المبيعـــات" : "Sales Tax:");
            this.label10.Text = (LangArEn== 0 ? "%" : "%");
            this.label23.Text = (LangArEn== 0 ? "الحد الأعلى :" : "Above Limit");
            this.label3.Text = (LangArEn== 0 ? "حساب المورد :" : "Supplier Acc:");
            this.label12.Text = (LangArEn== 0 ? "التصنيف :" : "Category:");
            this.label4.Text = (LangArEn== 0 ? "رقم الصنف :" : "Item Number:");
            this.label2.Text = (LangArEn== 0 ? "الإسم الإنجليزي :" : "English Name:");
            this.label6.Text = (LangArEn== 0 ? "الإسم العربي :" : "Arabic Name:");
            this.label7.Text = (LangArEn== 0 ? "رقم السيريال :" : "Serial Number :");
            this.label28.Text = (LangArEn== 0 ? "سعر الجملة" : "Wholesale price");
            this.label24.Text = (LangArEn== 0 ? "سعر المندوب" : "Delegate price");
            this.label27.Text = (LangArEn== 0 ? "سعر الموزع" : "Distributer price");
            this.label26.Text = (LangArEn== 0 ? "سعر آخر" : "Other Price");
            this.label25.Text = (LangArEn== 0 ? "سعر التجزئة" : "Retail price");
            checkBoxX_InvSale.Text = ((LangArEn== 0) ? "مبيعات" : "Sales");
            this.checkBoxX_Points.Text = (LangArEn == 0 ? "تفعيل النقاط" : "Activate Points");
            this.checkBoxX_BarcodeBalance.Text = (LangArEn== 0 ? "ربط بميزان الباركود" : "Activate Barcode Balancer:");
            this.checkBoxX_InvOut.Text = (LangArEn== 0 ? "إخراج بضاعة" : "Good Oout");
            this.checkBoxX_InvEnter.Text = (LangArEn== 0 ? "إدخال بضاعة" : "Good In");
            this.checkBoxX_InvPaymentReturn.Text = (LangArEn== 0 ? "مرتجع المشتريات" : "Purches Return:");
            this.checkBoxX_InvPayment.Text = (LangArEn== 0 ? "المشتريات" : "Purches");
            this.checkBoxX_ReturnInvSale.Text = (LangArEn== 0 ? "مرتجع المبيعات" : "Salse Return");
            grouhpPanel_Inv.TitleText = (LangArEn== 0 ? "اعدادات اخرى" : "Other Settings:");
            label41.Text = (LangArEn == 0 ? "تاريخ الانتاج" : "Production Date:");
            label42.Text = (LangArEn == 0 ? "تاريخ الانتهاء" : "Expiration Date:");
            expandablePanel_AnotherPrice.TitleText = (LangArEn == 0 ? "اسعار اضافية" : "Addational Prices");
        }
        protected override void OnParentRightToLeftChanged(EventArgs e)
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmItems));
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
            RibunButtons();
            //	FillCombo();
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
                groupPanel_Inv.TitleText = "منع الصنف في فاتورة";
                Button_PrintTable.Text = ((VarGeneral.GeneralPrinter.ISdirectPrinting) ? "طباعة" : "عــرض");
                Button_PrintTable.Tooltip = "F5";
                Button_ExportTable2.Text = "تصدير";
                Button_ExportTable2.Tooltip = "F10";
                DGV_Main.PrimaryGrid.GroupByRow.Text = "جميع السجلات";
                button_EnterImg.Tooltip = "إضافة صورة للصنف";
                button_ClearPic.Tooltip = "إزالة الصورة";
                radioButton_RawMaterial.Text = VarGeneral.Settings_Sys.ItemTyp2;
                radioButton_Product.Text = "مجمع\u0651ة";
                radioButton_Service.Text = "خدمة";
                radioButton_Goods.Text = VarGeneral.Settings_Sys.ItemTyp1;
                buttonItem_EditPrice.Text = "تعديل سعر وتكاليف هذا الصنف";
                buttonItem_EditPriceAll.Text = "تعديل أسعــار جميــع الأصنــاف";
                buttonItem_AddDisProcess.Text = "عمليات الزيادة والنقصان";
                sideBarPanelItem_Unit1.Text = "الوحدة الأولى";
                sideBarPanelItem_Unit2.Text = "الوحدة الثانية";
                sideBarPanelItem_Unit3.Text = "الوحدة الثالثة";
                sideBarPanelItem_Unit4.Text = "الوحدة الرابعة";
                sideBarPanelItem_Unit5.Text = "الوحدة الخامسة";
                labelItem4.Text = "الوحدة";
                labelItem5.Text = "التعبئة";
                labelItem30.Text = "سعر البيع";
                labelItem6.Text = "الكمية";
                labelItem7.Text = "التكلفة";
                labelItem8.Text = "رقم الباركود";
                radiobutton_RButDef1.Text = "الوحدة الإفتراضية";
                labelItem9.Text = "الوحدة";
                labelItem11.Text = "التعبئة";
                labelItem31.Text = "سعر البيع";
                labelItem12.Text = "الكمية";
                labelItem13.Text = "التكلفة";
                labelItem10.Text = "رقم الباركود";
                radiobutton_RButDef2.Text = "الوحدة الإفتراضية";
                labelItem14.Text = "الوحدة";
                labelItem16.Text = "التعبئة";
                labelItem32.Text = "سعر البيع";
                labelItem17.Text = "الكمية";
                labelItem18.Text = "التكلفة";
                labelItem15.Text = "رقم الباركود";
                radiobutton_RButDef3.Text = "الوحدة الإفتراضية";
                labelItem19.Text = "الوحدة";
                labelItem21.Text = "التعبئة";
                labelItem33.Text = "سعر البيع";
                labelItem22.Text = "الكمية";
                labelItem23.Text = "التكلفة";
                labelItem20.Text = "رقم الباركود";
                radiobutton_RButDef4.Text = "الوحدة الإفتراضية";
                labelItem24.Text = "الوحدة";
                labelItem26.Text = "التعبئة";
                labelItem34.Text = "سعر البيع";
                labelItem27.Text = "الكمية";
                labelItem28.Text = "التكلفة";
                labelItem25.Text = "رقم الباركود";
                radiobutton_RButDef2.Text = "الوحدة الإفتراضية";
                buttonItem_Serials.Text = "السيريال";
                c1FlexGrid_Items.Cols[0].Caption = "الكمية المتوفرة";
                c1FlexGrid_Items.Cols[1].Caption = "متوسط التكلفة";
                c1FlexGrid_Items.Cols[2].Caption = "آخر التكلفة";
                c1FlexGrid_Items.Cols[3].Caption = "تكلفة اول المدة";
                c1FlexGrid_Items.Cols[4].Caption = "أول تكلفة";
                c1FlexGrid_Items.Cols[5].Caption = "الرف";
                c1FlexGrid_Items.Cols[6].Caption = "تاريخ صلاحية";
                superTabItem_Details.Text = "المحتويــــات";
                Text = "الأصناف";
                labelX1.Text = "صورة الصنف";
                FlxInv.Cols[1].Caption = "رمز الصنف";
                FlxInv.Cols[2].Visible = true;
                FlxInv.Cols[3].Visible = true;
                FlxInv.Cols[4].Visible = false;
                FlxInv.Cols[5].Visible = false;
                FlxInv.Cols[6].Caption = "مستودع";
                FlxInv.Cols[7].Caption = "الكمية";
                FlxInv.Cols[8].Caption = "السعر";
                FlxInv.Cols[27].Caption = "الصلاحية";
                FlxInv.Cols[31].Caption = "الأجمالي";
                button_DeleteFromSystem.Text = "إزالة الصنف من النظام";
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
                groupPanel_Inv.TitleText = "Prevent product in the Invoice";
                Button_PrintTable.Text = ((VarGeneral.GeneralPrinter.ISdirectPrinting) ? "Print" : "Show");
                Button_PrintTable.Tooltip = "F5";
                Button_ExportTable2.Text = "Export";
                Button_ExportTable2.Tooltip = "F10";
                DGV_Main.PrimaryGrid.GroupByRow.Text = "All Records";
                button_EnterImg.Tooltip = "Add Image For Item";
                button_ClearPic.Tooltip = "Image Removed";
                radioButton_RawMaterial.Text = VarGeneral.Settings_Sys.ItemTyp2E;
                radioButton_Product.Text = "Gusset";
                radioButton_Service.Text = "Service";
                radioButton_Goods.Text = VarGeneral.Settings_Sys.ItemTyp1E;
                buttonItem_EditPrice.Text = "Price Edite This Item";
                buttonItem_EditPriceAll.Text = "Price Edite All Items";
                buttonItem_AddDisProcess.Text = "Increases and decreases";
                sideBarPanelItem_Unit1.Text = "First Unit";
                sideBarPanelItem_Unit2.Text = "Second Unit";
                sideBarPanelItem_Unit3.Text = "Third Unit";
                sideBarPanelItem_Unit4.Text = "Fourth Unit";
                sideBarPanelItem_Unit5.Text = "Fifth Unit";
                labelItem4.Text = "Unit";
                labelItem5.Text = "Fill";
                labelItem30.Text = "Sale Price";
                labelItem6.Text = "Quantity";
                labelItem7.Text = "Cost";
                labelItem8.Text = "Barcode No";
                radiobutton_RButDef1.Text = "Default Unit";
                labelItem9.Text = "Unit";
                labelItem11.Text = "Fill";
                labelItem31.Text = "Sale Price";
                labelItem12.Text = "Quantity";
                labelItem13.Text = "Cost";
                labelItem10.Text = "Barcode No";
                radiobutton_RButDef2.Text = "Default Unit";
                buttonItem_Serials.Text = "Serial";
                labelItem14.Text = "Unit";
                labelItem16.Text = "Fill";
                labelItem32.Text = "Sale Price";
                labelItem17.Text = "Quantity";
                labelItem18.Text = "Cost";
                labelItem15.Text = "Barcode No";
                radiobutton_RButDef3.Text = "Default Unit";
                labelItem19.Text = "Unit";
                labelItem21.Text = "Fill";
                labelItem33.Text = "Sale Price";
                labelItem22.Text = "Quantity";
                labelItem23.Text = "Cost";
                labelItem20.Text = "Barcode No";
                radiobutton_RButDef4.Text = "Default Unit";
                labelItem24.Text = "Unit";
                labelItem26.Text = "Fill";
                labelItem34.Text = "Sale Price";
                labelItem27.Text = "Quantity";
                labelItem28.Text = "Cost";
                labelItem25.Text = "Barcode No";
                radiobutton_RButDef2.Text = "Default Unit";
                c1FlexGrid_Items.Cols[0].Caption = "Quantity";
                c1FlexGrid_Items.Cols[1].Caption = "Avrg Cost";
                c1FlexGrid_Items.Cols[2].Caption = "Last Cost";
                c1FlexGrid_Items.Cols[3].Caption = "cost open";
                c1FlexGrid_Items.Cols[4].Caption = "First Cost";
                c1FlexGrid_Items.Cols[5].Caption = "Rack";
                c1FlexGrid_Items.Cols[6].Caption = "Expir date";
                superTabItem_Details.Text = "Containts";
                Text = "Items";
                labelX1.Text = "Item Image";
                FlxInv.Cols[1].Caption = "Item Code";
                FlxInv.Cols[2].Visible = false;
                FlxInv.Cols[3].Visible = false;
                FlxInv.Cols[4].Visible = true;
                FlxInv.Cols[5].Visible = true;
                FlxInv.Cols[6].Caption = "Store";
                FlxInv.Cols[7].Caption = "Quantity";
                FlxInv.Cols[8].Caption = "Price";
                FlxInv.Cols[27].Caption = "Validity";
                FlxInv.Cols[31].Caption = "Totel";
                button_DeleteFromSystem.Text = "Remove Item from System";
            }
        }
        void addevents()
        {
            radioButton_Goods.Click += Button_Edit_Click;
            radioButton_Product.Click += Button_Edit_Click;
            radioButton_RawMaterial.Click += Button_Edit_Click;
            radioButton_Service.Click += Button_Edit_Click;
            this.radioButton_Product.CheckedChanged += new DevComponents.DotNetBar.CheckBoxChangeEventHandler(this.radioButton_Product_CheckedChanged);
            //this.radiobutton_RButDef1.CheckedChanged += new DevComponents.DotNetBar.CheckBoxChangeEventHandler(this.radiobutton_RButDef1_CheckedChanged);
            //this.radiobutton_RButDef2.CheckedChanged += new DevComponents.DotNetBar.CheckBoxChangeEventHandler(this.radiobutton_RButDef2_CheckedChanged);
            //this.radiobutton_RButDef3.CheckedChanged += new DevComponents.DotNetBar.CheckBoxChangeEventHandler(this.radiobutton_RButDef3_CheckedChanged);
            //   this.radiobutton_RButDef4.CheckedChanged += new DevComponents.DotNetBar.CheckBoxChangeEventHandler(this.radiobutton_RButDef4_CheckedChanged);
            this.radiobutton_RButDef5.CheckedChanged += new System.EventHandler(this.radiobutton_RButDef5_CheckedChanged);
            this.radiobutton_RButDef4.CheckedChanged += new System.EventHandler(this.radiobutton_RButDef4_CheckedChanged);
            this.radiobutton_RButDef3.CheckedChanged += new System.EventHandler(this.radiobutton_RButDef3_CheckedChanged);
            this.radiobutton_RButDef2.CheckedChanged += new System.EventHandler(this.radiobutton_RButDef2_CheckedChanged);
            this.radiobutton_RButDef1.CheckedChanged += new System.EventHandler(this.radiobutton_RButDef1_CheckedChanged);
            // this.radiobutton_RButDef5.CheckedChanged += new DevComponents.DotNetBar.CheckBoxChangeEventHandler(this.radiobutton_RButDef5_CheckedChanged);
            this.comboboxItems_Unit1.SelectedIndexChanged += comboboxItems_Unit1_SelectedIndexChanged;
            this.comboboxItems_Unit1.Click += new System.EventHandler(this.Button_Edit_Click);
            this.doubleInput_DefPack.Click += new System.EventHandler(this.doubleInput_DefPack_Click);
            this.doubleInput_DefPack.Enter += new System.EventHandler(this.textbox_Eng_Des_Enter);
            this.doubleInput_DefPack.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.doubleInput_DefPack_KeyPress);
            this.doubleInput_DefPack.Leave += new System.EventHandler(this.textbox_Arb_Des_Enter);
            this.textbox_Pack1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textbox_Pack1_KeyPress);
            this.textbox_Pack1.Click += new System.EventHandler(this.Button_Edit_Click);
            this.textbox_SelPri1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textbox_Pack1_KeyPress);
            this.textbox_SelPri1.Click += new System.EventHandler(this.Button_Edit_Click);
            this.textbox_SelPri1.GotFocus += new System.EventHandler(this.txtBarCode1_GotFocus);
            this.textbox_Qty1.Click += new System.EventHandler(this.Button_Edit_Click);
            this.textbox_Cost1.Click += new System.EventHandler(this.Button_Edit_Click);
            //  this.txtBarCode1.ButtonCustomClick += new System.EventHandler(this.txtBarCode1_ButtonCustomClick);
            this.txtBarCode1.Click += new System.EventHandler(this.Button_Edit_Click);
            this.txtBarCode1.LostFocus += new System.EventHandler(this.txtBarCode1_Leave);
            this.txtBarCode1.GotFocus += new System.EventHandler(this.txtBarCode1_GotFocus);
            this.comboboxItems_Unit2.SelectedIndexChanged += new System.EventHandler(this.comboboxItems_Unit2_SelectedIndexChanged);
            this.comboboxItems_Unit2.Click += new System.EventHandler(this.Button_Edit_Click);
            this.textbox_Pack2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textbox_Pack2_KeyPress);
            this.textbox_Pack2.Click += new System.EventHandler(this.Button_Edit_Click);
            this.textbox_Pack2.GotFocus += new System.EventHandler(this.txtBarCode1_GotFocus);
            this.textbox_SelPri2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textbox_Pack2_KeyPress);
            this.textbox_SelPri2.Click += new System.EventHandler(this.Button_Edit_Click);
            this.textbox_SelPri2.GotFocus += new System.EventHandler(this.txtBarCode1_GotFocus);
            this.textbox_Qty2.Click += new System.EventHandler(this.Button_Edit_Click);
            this.textbox_Cost2.Click += new System.EventHandler(this.Button_Edit_Click);
            this.txtBarCode2.ButtonCustomClick += new System.EventHandler(this.txtBarCode2_ButtonCustomClick);
            this.txtBarCode2.Click += new System.EventHandler(this.Button_Edit_Click);
            this.txtBarCode2.LostFocus += new System.EventHandler(this.txtBarCode2_Leave);
            this.txtBarCode2.GotFocus += new System.EventHandler(this.txtBarCode1_GotFocus);
            this.comboboxItems_Unit3.SelectedIndexChanged += new System.EventHandler(this.comboboxItems_Unit3_SelectedIndexChanged);
            this.comboboxItems_Unit3.Click += new System.EventHandler(this.Button_Edit_Click);
            this.textbox_Pack3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textbox_Pack3_KeyPress);
            this.textbox_Pack3.Click += new System.EventHandler(this.Button_Edit_Click);
            this.textbox_Pack3.GotFocus += new System.EventHandler(this.txtBarCode1_GotFocus);
            this.textbox_SelPri3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textbox_Pack3_KeyPress);
            this.textbox_SelPri3.Click += new System.EventHandler(this.Button_Edit_Click);
            this.textbox_SelPri3.GotFocus += new System.EventHandler(this.txtBarCode1_GotFocus);
            this.textbox_Qty3.Click += new System.EventHandler(this.Button_Edit_Click);
            this.textbox_Cost3.Click += new System.EventHandler(this.Button_Edit_Click);
            this.txtBarCode3.ButtonCustomClick += new System.EventHandler(this.txtBarCode3_ButtonCustomClick);
            this.txtBarCode3.Click += new System.EventHandler(this.Button_Edit_Click);
            this.txtBarCode3.LostFocus += new System.EventHandler(this.txtBarCode3_Leave);
            this.txtBarCode3.GotFocus += new System.EventHandler(this.txtBarCode1_GotFocus);
            this.textbox_Pack4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textbox_Pack4_KeyPress);
            this.textbox_Pack4.Click += new System.EventHandler(this.Button_Edit_Click);
            this.textbox_Pack4.GotFocus += new System.EventHandler(this.txtBarCode1_GotFocus);
            this.textbox_SelPri4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textbox_Pack4_KeyPress);
            this.textbox_SelPri4.Click += new System.EventHandler(this.Button_Edit_Click);
            this.textbox_SelPri4.GotFocus += new System.EventHandler(this.txtBarCode1_GotFocus);
            this.textbox_Qty4.Click += new System.EventHandler(this.Button_Edit_Click);
            this.textbox_Cost4.Click += new System.EventHandler(this.Button_Edit_Click);
            this.txtBarCode4.ButtonCustomClick += new System.EventHandler(this.txtBarCode4_ButtonCustomClick);
            this.txtBarCode4.Click += new System.EventHandler(this.Button_Edit_Click);
            this.txtBarCode4.LostFocus += new System.EventHandler(this.txtBarCode4_Leave);
            this.txtBarCode4.GotFocus += new System.EventHandler(this.txtBarCode1_GotFocus);
            this.textbox_Pack5.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textbox_Pack5_KeyPress);
            this.textbox_Pack5.Click += new System.EventHandler(this.Button_Edit_Click);
            this.textbox_Pack5.GotFocus += new System.EventHandler(this.txtBarCode1_GotFocus);
            this.textbox_SelPri5.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textbox_Pack5_KeyPress);
            this.textbox_SelPri5.Click += new System.EventHandler(this.Button_Edit_Click);
            this.textbox_SelPri5.GotFocus += new System.EventHandler(this.txtBarCode1_GotFocus);
            this.textbox_Qty5.Click += new System.EventHandler(this.Button_Edit_Click);
            this.textbox_Cost5.Click += new System.EventHandler(this.Button_Edit_Click);
            this.txtBarCode5.ButtonCustomClick += new System.EventHandler(this.txtBarCode5_ButtonCustomClick);
            this.txtBarCode5.Click += new System.EventHandler(this.Button_Edit_Click);
            this.txtBarCode5.LostFocus += new System.EventHandler(this.txtBarCode5_Leave);
            this.txtBarCode5.GotFocus += new System.EventHandler(this.txtBarCode1_GotFocus);
        }
#pragma warning disable CS1998 // This async method lacks 'await' operators and will run synchronously. Consider using the 'await' operator to await non-blocking API calls, or 'await Task.Run(...)' to do CPU-bound work on a background thread.
        private async  void FrmItems_Load(object sender, EventArgs e)
#pragma warning restore CS1998 // This async method lacks 'await' operators and will run synchronously. Consider using the 'await' operator to await non-blocking API calls, or 'await Task.Run(...)' to do CPU-bound work on a background thread.
        {
            try
            {
                this.Location = Frm_Main.loc;
                buttonItem7.ButtonStyle = eButtonStyle.ImageAndText;
                   
                ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmItems));
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
                if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 75))
                {
                    checkBoxX_Points.Visible = false;
                }
                if (columns_Names_visible.Count == 0)
                {
                    columns_Names_visible.Add("Itm_No", new ColumnDictinary("رقم الصنف", "Item No", ifDefault: true, string.Empty));
                    columns_Names_visible.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, string.Empty));
                    columns_Names_visible.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, string.Empty));
                    if (!File.Exists(Application.StartupPath + "\\Script\\SecriptInvitationCards.dll"))
                    {
                        columns_Names_visible.Add("Itm_ID", new ColumnDictinary("الرقم التسلسلي", "Seq No", ifDefault: false, string.Empty));
                        columns_Names_visible.Add("AvrageCost", new ColumnDictinary("متوسط التكلفة", "Average Cost", ifDefault: true, string.Empty));
                        columns_Names_visible.Add("UntPri1", new ColumnDictinary("سعر البيع 1", "Sale Price 1", ifDefault: true, string.Empty));
                        columns_Names_visible.Add("Arb_Des_Cat", new ColumnDictinary("الاسم العربي لمجموعة الصنف", "CATEGORY Arabic Name", ifDefault: false, string.Empty));
                        columns_Names_visible.Add("Eng_Des_Cat", new ColumnDictinary("الاسم الانجليزي لمجموعة الصنف", "CATEGORY English Name", ifDefault: false, string.Empty));
                    }
                    columns_Names_visible.Add("BarCod1", new ColumnDictinary("رقم الباركود 1", "Barcode No 1", ifDefault: false, string.Empty));
                    columns_Names_visible.Add("BarCod2", new ColumnDictinary("رقم الباركود 2", "Barcode No 2", ifDefault: false, string.Empty));
                    columns_Names_visible.Add("BarCod3", new ColumnDictinary("رقم الباركود 3", "Barcode No 3", ifDefault: false, string.Empty));
                    columns_Names_visible.Add("BarCod4", new ColumnDictinary("رقم الباركود 4", "Barcode No 4", ifDefault: false, string.Empty));
                }
                else
                {
                    Clear();
                    textBox_ID.Text = string.Empty;
                    TextBox_Index.TextBox.Text = string.Empty;
                }
                FillCombo();
                RibunButtons();
                ArbEng();
                RefreshPKeys();
                c1FlexGrid_Items.SetData(1, 0, 0);
                c1FlexGrid_Items.SetData(1, 1, 0);
                c1FlexGrid_Items.SetData(1, 2, 0);
                c1FlexGrid_Items.SetData(1, 3, 0);
                c1FlexGrid_Items.SetData(1, 4, 0);
                c1FlexGrid_Items.SetData(1, 5, string.Empty);
                c1FlexGrid_Items.SetData(1, 6, false);
                textBox_ID.Text = PKeys.FirstOrDefault();
                UnitTabs();
                radioButton_Product_CheckedChanged(null, null);
                if (!string.IsNullOrEmpty(VarGeneral.itmDes))
                {
                    Button_Add_Click(sender, e);
                    if (VarGeneral.itmDesIndex == 1)
                    {
                        textBox_ID.Text = VarGeneral.ItmDes;
                    }
                    else if (VarGeneral.itmDesIndex == 2)
                    {
                        textbox_Arb_Des.Text = VarGeneral.ItmDes;
                    }
                    else
                    {
                        textbox_Eng_Des.Text = VarGeneral.ItmDes;
                    }
                }
                listUnit = new List<T_Unit>();
                listStore = new List<T_Store>();
                listUnit = db.FillUnit_2(string.Empty).ToList();
                listStore = db.FillStore_2(string.Empty).ToList();
                string Co = string.Empty;
                for (int iiCnt = 0; iiCnt < listStore.Count; iiCnt++)
                {
                    _Store = listStore[iiCnt];
                    Co = ((!(Co != string.Empty)) ? _Store.Stor_ID.ToString() : (Co + "|" + _Store.Stor_ID));
                }
                FlxInv.Cols[6].ComboList = Co;
                UpdateVcr();
                int Comm_ = 0;
                try
                {
                    Comm_ = int.Parse(VarGeneral.Settings_Sys.Seting.Substring(50, 1));
                }
                catch
                {
                }
                if (Comm_ == 0)
                {
                    label10.Visible = true;
                }
                else
                {
                    label10.Visible = false;
                }
                if (File.Exists(Application.StartupPath + "\\Script\\SecriptInvitationCards.dll"))
                {
                    Script_InvitationCards();
                }
                if (File.Exists(Application.StartupPath + "\\Script\\SecriptSchool.dll"))
                {
                    Script_School();
                }
                if (File.Exists(Application.StartupPath + "\\Script\\SecriptCeramic.dll"))
                {
                    textBox_DisItem.Visible = false;
                    label16.Visible = false;
                    textBox_CommItm.Visible = false;
                    label10.Visible = false;
                    doubleInput_DefPack.Visible = true;
                    label5.Text = ((LangArEn == 0) ? "تعبئة الكراتين :" : "Carton Pack :");
                    comboBox_DefPack.Visible = true;
                    label8.Text = ((LangArEn == 0) ? "وحدة الكراتين :" : "Carton Unit :");
                }
                if (File.Exists(Application.StartupPath + "\\Script\\SecriptMaintenanceCars.dll"))
                {
                    labelItem5.Visible = false;
                    labelItem11.Visible = false;
                    labelItem16.Visible = false;
                    labelItem21.Visible = false;
                    labelItem26.Visible = false;
                    textbox_Pack1.Visible = false;
                    textbox_Pack2.Visible = false;
                    textbox_Pack3.Visible = false;
                    textbox_Pack4.Visible = false;
                    textbox_Pack5.Visible = false;
                }
                if (File.Exists(Application.StartupPath + "\\Script\\SecriptTegnicalCollage.dll"))
                {
                    TegnicalCollage();
                }
                if (File.Exists(Application.StartupPath + "\\Script\\SecriptWaterPackages.dll"))
                {
                    checkBoxX_Points.Visible = false;
                    buttonItem_Serials.Visible = false;
                }
                if (VarGeneral.gUserName == "runsetting" && File.Exists(Application.StartupPath + "\\Script\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\khalijwatania.dll") && VarGeneral.InvType == 1)
                {
                    checkBoxX_InvSale.Text = ((LangArEn == 0) ? "خــدمـــة" : "Service");
                }
                if (File.Exists(Application.StartupPath + "\\Script\\SecriptGlasses.dll") || (VarGeneral.gUserName == "runsetting" && File.Exists(Application.StartupPath + "\\Script\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\SecriptGlasses.dll")))
                {
                    panelEx_Size.Visible = true;
                    panelEx_Size.Location = new Point(5, panelEx_Size.Location.Y);
                    expandablePanel_AnotherPrice.TitleText = ((LangArEn == 0) ? "المقـــاسات" : "Sizes");
                }
                if (File.Exists(Application.StartupPath + "\\Script\\Secriptjustlight.dll") || (VarGeneral.gUserName == "runsetting" && File.Exists(Application.StartupPath + "\\Script\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\Secriptjustlight.dll")))
                {
                    labelItem30.Text = ((LangArEn == 0) ? "سعر الإيجار" : "rent price");
                    labelItem31.Text = ((LangArEn == 0) ? "سعر الإيجار" : "rent price");
                    labelItem32.Text = ((LangArEn == 0) ? "سعر الإيجار" : "rent price");
                    labelItem33.Text = ((LangArEn == 0) ? "سعر الإيجار" : "rent price");
                    labelItem34.Text = ((LangArEn == 0) ? "سعر الإيجار" : "rent price");
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Load:", error, enable: true);
                MessageBox.Show(error.Message);
            }
            if (Program.iscarversion())
            {
                setdefaultpack();
            }
        }
        private void TegnicalCollage()
        {
            checkBoxX_BarcodeBalance.Visible = false;
            checkBoxX_Points.Visible = false;
            label11.Visible = false;
            textbox_Supreme.Visible = false;
            label13.Visible = false;
            textBox_TaxSales.Visible = false;
            label14.Visible = false;
            label8.Visible = false;
            textBox_CommItm.Visible = false;
            label10.Visible = false;
            c1FlexGrid_Items.Cols[6].Visible = false;
            radioButton_Product.Visible = false;
            radioButton_Service.Visible = false;
            buttonItem_Serials.Visible = false;
            buttonItem_EditPriceAll.Visible = false;
            buttonItem_AddDisProcess.Visible = false;
            buttonItem_Serials.Visible = false;
            labelItem30.Visible = false;
            labelItem31.Visible = false;
            labelItem32.Visible = false;
            labelItem33.Visible = false;
            labelItem34.Visible = false;
            checkBoxX_InvEnter.Text = ((LangArEn == 0) ? "إصدار عهـدة" : "Issuance Custody");
            expandablePanel_AnotherPrice.TitleText = string.Empty;
            expandablePanel_AnotherPrice.ExpandButtonVisible = false;
            expandablePanel_AnotherPrice.Enabled = false;
            label15.Location = label13.Location;
            textBox_TaxPurchase.Location = textBox_TaxSales.Location;
            checkBoxX_InvEnter.Location = checkBoxX_ReturnInvSale.Location;
            checkBoxX_InvOut.Visible = false;
            checkBoxX_InvSale.Visible = false;
            checkBoxX_ReturnInvSale.Visible = false;
            textbox_SelPri1.Visible = false;
            textbox_SelPri2.Visible = false;
            textbox_SelPri3.Visible = false;
            textbox_SelPri4.Visible = false;
            textbox_SelPri5.Visible = false;
        }
        private void Script_InvitationCards()
        {
            c1FlexGrid_Items.Visible = false;
            label11.Visible = false;
            textbox_Supreme.Visible = false;
            groupPanel_Inv.Visible = false;
            superTabItem_Details.Visible = false;
            sideBarPanelItem_Unit2.Visible = false;
            sideBarPanelItem_Unit3.Visible = false;
            sideBarPanelItem_Unit4.Visible = false;
            sideBarPanelItem_Unit5.Visible = false;
            buttonItem_Serials.Visible = false;
            metroStatusBar_itemsType.Visible = false;
            expandablePanel_AnotherPrice.ExpandButtonVisible = false;
            label13.Visible = false;
            textBox_TaxSales.Visible = false;
            label9.Visible = false;
            label15.Visible = false;
            textBox_TaxPurchase.Visible = false;
            label14.Visible = false;
            label8.Visible = false;
            textBox_CommItm.Visible = false;
            textBox_DisItem.Visible = false;
            label16.Visible = false;
            label5.Visible = false;
            label10.Visible = false;
            if (VarGeneral.UserID != 1)
            {
                buttonItem_EditPrice.Visible = false;
            }
            labelItem6.Visible = false;
            textbox_Qty1.Visible = false;
            labelItem6.Visible = false;
            textbox_Cost1.Visible = false;
            label3.Location = new Point(label3.Location.X, label3.Location.Y - 50);
            txtCustName.Location = new Point(txtCustName.Location.X, txtCustName.Location.Y - 50);
            button_SrchCustNo.Location = new Point(button_SrchCustNo.Location.X, button_SrchCustNo.Location.Y - 50);
            pictureBox_PicItem.Location = new Point(pictureBox_PicItem.Location.X, pictureBox_PicItem.Location.Y - 50);
            button_ClearPic.Location = new Point(button_ClearPic.Location.X, button_ClearPic.Location.Y - 50);
            button_EnterImg.Location = new Point(button_EnterImg.Location.X, button_EnterImg.Location.Y - 50);
            labelX1.Location = new Point(labelX1.Location.X, labelX1.Location.Y - 50);
            panelEx2.MinimumSize = new Size(0, 0);
            panelEx2.Height = 360;
            base.Height = 401;
            label3.Text = ((LangArEn == 0) ? "حساب العميل :" : "Customer Account :");
            expandablePanel_AnotherPrice.TitleText = string.Empty;
        }
        private void Script_School()
        {
            label11.Visible = false;
            textbox_Supreme.Visible = false;
            checkBoxX_InvEnter.Visible = false;
            checkBoxX_InvOut.Visible = false;
            superTabItem_Details.Visible = false;
            buttonItem_Serials.Visible = false;
            radioButton_RawMaterial.Visible = false;
            radioButton_Product.Visible = false;
            label13.Visible = false;
            textBox_TaxSales.Visible = false;
            label9.Visible = false;
            label15.Visible = false;
            textBox_TaxPurchase.Visible = false;
            label14.Visible = false;
            label8.Visible = false;
            textBox_CommItm.Visible = false;
            textBox_DisItem.Visible = false;
            label16.Visible = false;
            label5.Visible = false;
            label10.Visible = false;
            if (VarGeneral.UserID != 1)
            {
                buttonItem_EditPrice.Visible = false;
            }
        }
        private void textBox_ID_TextChanged(object sender, EventArgs e)
        {
            button_DeleteFromSystem.Visible = false;
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
                T_Item newData = db.StockItem(no);
                if (newData == null || string.IsNullOrEmpty(newData.Itm_No))
                {
                    if (!Button_Add.Visible || !Button_Add.Enabled)
                    {
                        MessageBox.Show((LangArEn == 0) ? "لا يمكن اتمام هذه العملية .. الرجاء مراجعة صلاحيات المستخدمين !" : "Can not complete this process .. please see the powers of the users!", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        textBox_ID.TextChanged -= textBox_ID_TextChanged;
                        try
                        {
                            textBox_ID.Text = data_this.Itm_No;
                        }
                        catch
                        {
                        }
                        textBox_ID.TextChanged += textBox_ID_TextChanged;
                        return;
                    }
                    Clear();
                    try
                    {
                        if (comboboxItems_Unit1.Items.Count > 0)
                        {
                            comboboxItems_Unit1.SelectedIndex = 1;
                        }
                    }
                    catch
                    {
                        comboboxItems_Unit1.SelectedIndex = 0;
                    }
                    TextBox_Index.InputTextChanged -= TextBox_Index_InputTextChanged;
                    TextBox_Index.TextBox.Text = string.Concat(PKeys.Count + 1);
                    TextBox_Index.InputTextChanged += TextBox_Index_InputTextChanged;
                }
                else
                {
                    DataThis = newData;
                    int indexA = PKeys.IndexOf(newData.Itm_No ?? string.Empty);
                    indexA++;
                    TextBox_Index.InputTextChanged -= TextBox_Index_InputTextChanged;
                    TextBox_Index.TextBox.Text = string.Concat(indexA);
                    TextBox_Index.InputTextChanged += TextBox_Index_InputTextChanged;
                }
            }
            catch
            {
            }
            UpdateVcr();
            if (File.Exists(Application.StartupPath + "\\Script\\SecriptMaintenanceCars.dll"))
            {
                comboboxItems_Unit1.Enabled = false;
                comboboxItems_Unit2.Enabled = false;
                comboboxItems_Unit3.Enabled = false;
                comboboxItems_Unit4.Enabled = false;
                comboboxItems_Unit5.Enabled = false;
            }
        }
        private void FillCombo5()
        {
            int _CmbIndex = combobox_DateTyp.SelectedIndex;
            combobox_DateTyp.Items.Clear();
            comboboxItems_Unit3.Items.Clear();
            comboboxItems_Unit1.Items.Clear();
            comboboxItems_Unit2.Items.Clear();
            comboboxItems_Unit4.Items.Clear();
            comboboxItems_Unit5.Items.Clear();
            combobox_Unit1.DataSource = null;
            combobox_Unit2.DataSource = null;
            combobox_Unit4.DataSource = null;
            combobox_Unit5.DataSource = null;
            if (LangArEn == 0)
            {
                combobox_DateTyp.Items.Clear();
                combobox_DateTyp.Items.Add("يوم");
                combobox_DateTyp.Items.Add("شهر");
                combobox_DateTyp.Items.Add("سنة");
                comboBox_DefPack.Items.Clear();
                comboBox_DefPack.Items.Add("الوحدة الأولى");
                comboBox_DefPack.Items.Add("الوحدة الثانية");
                comboBox_DefPack.Items.Add("الوحدة الثالثة");
                comboBox_DefPack.Items.Add("الوحدة الرابعة");
                comboBox_DefPack.Items.Add("الوحدة الخامسة");
                comboBox_DefPack.SelectedIndex = 0;
                _CmbIndex = combobox_ItmeGroup.SelectedIndex;
                List<T_CATEGORY> listAccCat = new List<T_CATEGORY>(db.T_CATEGORies.Select((T_CATEGORY item) => item).ToList());
                combobox_ItmeGroup.DataSource = listAccCat;
                combobox_ItmeGroup.DisplayMember = "Arb_Des";
                combobox_ItmeGroup.ValueMember = "CAT_ID";
                combobox_ItmeGroup.SelectedIndex = 0;
                _CmbIndex = combobox_Unit1.SelectedIndex;
                combobox_Unit1.DataSource = null;
                List<T_Unit> listUnit1 = new List<T_Unit>(db.T_Units.Select((T_Unit item) => item).ToList());
                listUnit1.Insert(0, new T_Unit());
                combobox_Unit1.DataSource = listUnit1;
                combobox_Unit1.DisplayMember = "Arb_Des";
                combobox_Unit1.ValueMember = "Unit_ID";
                comboboxItems_Unit1.Items.Add(" ");
                for (int i = 1; i < combobox_Unit1.Items.Count; i++)
                {
                    combobox_Unit1.SelectedIndex = i;
                    comboboxItems_Unit1.Items.Add(combobox_Unit1.Text);
                }
                comboboxItems_Unit1.SelectedIndex = _CmbIndex;
                combobox_Unit1.SelectedIndex = _CmbIndex;
                _CmbIndex = combobox_Unit2.SelectedIndex;
                combobox_Unit2.DataSource = null;
                List<T_Unit> listUnit2 = new List<T_Unit>(db.T_Units.Select((T_Unit item) => item).ToList());
                listUnit2.Insert(0, new T_Unit());
                combobox_Unit2.DataSource = listUnit2;
                combobox_Unit2.DisplayMember = "Arb_Des";
                combobox_Unit2.ValueMember = "Unit_ID";
                combobox_Unit2.SelectedIndex = _CmbIndex;
                comboboxItems_Unit2.Items.Add(" ");
                for (int i = 1; i < combobox_Unit2.Items.Count; i++)
                {
                    combobox_Unit2.SelectedIndex = i;
                    comboboxItems_Unit2.Items.Add(combobox_Unit2.Text);
                }
                comboboxItems_Unit2.SelectedIndex = _CmbIndex;
                combobox_Unit2.SelectedIndex = _CmbIndex;
                _CmbIndex = combobox_Unit3.SelectedIndex;
                combobox_Unit3.DataSource = null;
                List<T_Unit> listUnit3 = new List<T_Unit>(db.T_Units.Select((T_Unit item) => item).ToList());
                listUnit3.Insert(0, new T_Unit());
                combobox_Unit3.DataSource = listUnit3;
                combobox_Unit3.DisplayMember = "Arb_Des";
                combobox_Unit3.ValueMember = "Unit_ID";
                combobox_Unit3.SelectedIndex = _CmbIndex;
                comboboxItems_Unit3.Items.Add(" ");
                for (int i = 1; i < combobox_Unit3.Items.Count; i++)
                {
                    combobox_Unit3.SelectedIndex = i;
                    comboboxItems_Unit3.Items.Add(combobox_Unit3.Text);
                }
                comboboxItems_Unit3.SelectedIndex = _CmbIndex;
                combobox_Unit3.SelectedIndex = _CmbIndex;
                _CmbIndex = combobox_Unit4.SelectedIndex;
                combobox_Unit4.DataSource = null;
                List<T_Unit> listUnit4 = new List<T_Unit>(db.T_Units.Select((T_Unit item) => item).ToList());
                listUnit4.Insert(0, new T_Unit());
                combobox_Unit4.DataSource = listUnit4;
                combobox_Unit4.DisplayMember = "Arb_Des";
                combobox_Unit4.ValueMember = "Unit_ID";
                combobox_Unit4.SelectedIndex = _CmbIndex;
                comboboxItems_Unit4.Items.Add(" ");
                for (int i = 1; i < combobox_Unit4.Items.Count; i++)
                {
                    combobox_Unit4.SelectedIndex = i;
                    comboboxItems_Unit4.Items.Add(combobox_Unit4.Text);
                }
                comboboxItems_Unit4.SelectedIndex = _CmbIndex;
                combobox_Unit4.SelectedIndex = _CmbIndex;
                _CmbIndex = combobox_Unit5.SelectedIndex;
                combobox_Unit5.DataSource = null;
                List<T_Unit> listUnit5 = new List<T_Unit>(db.T_Units.Select((T_Unit item) => item).ToList());
                listUnit5.Insert(0, new T_Unit());
                combobox_Unit5.DataSource = listUnit5;
                combobox_Unit5.DisplayMember = "Arb_Des";
                combobox_Unit5.ValueMember = "Unit_ID";
                combobox_Unit5.SelectedIndex = _CmbIndex;
                comboboxItems_Unit5.Items.Add(" ");
                for (int i = 1; i < combobox_Unit5.Items.Count; i++)
                {
                    combobox_Unit5.SelectedIndex = i;
                    comboboxItems_Unit5.Items.Add(combobox_Unit5.Text);
                }
                comboboxItems_Unit5.SelectedIndex = _CmbIndex;
                combobox_Unit5.SelectedIndex = _CmbIndex;
            }
            else
            {
                combobox_DateTyp.Items.Add("Day");
                combobox_DateTyp.Items.Add("Month");
                combobox_DateTyp.Items.Add("Year");
                comboBox_DefPack.Items.Clear();
                comboBox_DefPack.Items.Add("Unit 1");
                comboBox_DefPack.Items.Add("Unit 2");
                comboBox_DefPack.Items.Add("Unit 3");
                comboBox_DefPack.Items.Add("Unit 4");
                comboBox_DefPack.Items.Add("Unit 5");
                comboBox_DefPack.SelectedIndex = 0;
                List<T_CATEGORY> listAccCat = new List<T_CATEGORY>(db.T_CATEGORies.Select((T_CATEGORY item) => item).ToList());
                combobox_ItmeGroup.DataSource = listAccCat;
                combobox_ItmeGroup.DisplayMember = "Eng_Des";
                combobox_ItmeGroup.ValueMember = "CAT_ID";
                combobox_ItmeGroup.SelectedIndex = 0;
                combobox_Unit1.DataSource = null;
                List<T_Unit> listUnit1 = new List<T_Unit>(db.T_Units.Select((T_Unit item) => item).ToList());
                listUnit1.Insert(0, new T_Unit());
                combobox_Unit1.DataSource = listUnit1;
                combobox_Unit1.DisplayMember = "Eng_Des";
                combobox_Unit1.ValueMember = "Unit_ID";
                comboboxItems_Unit1.Items.Add(" ");
                for (int i = 1; i < combobox_Unit1.Items.Count; i++)
                {
                    combobox_Unit1.SelectedIndex = i;
                    comboboxItems_Unit1.Items.Add(combobox_Unit1.Text);
                }
                comboboxItems_Unit1.SelectedIndex = _CmbIndex;
                combobox_Unit1.SelectedIndex = _CmbIndex;
                combobox_Unit2.DataSource = null;
                List<T_Unit> listUnit2 = new List<T_Unit>(db.T_Units.Select((T_Unit item) => item).ToList());
                listUnit2.Insert(0, new T_Unit());
                combobox_Unit2.DataSource = listUnit2;
                combobox_Unit2.DisplayMember = "Eng_Des";
                combobox_Unit2.ValueMember = "Unit_ID";
                comboboxItems_Unit2.Items.Add(" ");
                for (int i = 1; i < combobox_Unit2.Items.Count; i++)
                {
                    combobox_Unit2.SelectedIndex = i;
                    comboboxItems_Unit2.Items.Add(combobox_Unit2.Text);
                }
                comboboxItems_Unit2.SelectedIndex = _CmbIndex;
                combobox_Unit2.SelectedIndex = _CmbIndex;
                combobox_Unit3.DataSource = null;
                List<T_Unit> listUnit3 = new List<T_Unit>(db.T_Units.Select((T_Unit item) => item).ToList());
                listUnit3.Insert(0, new T_Unit());
                combobox_Unit3.DataSource = listUnit3;
                combobox_Unit3.DisplayMember = "Eng_Des";
                combobox_Unit3.ValueMember = "Unit_ID";
                comboboxItems_Unit3.Items.Add(" ");
                for (int i = 1; i < combobox_Unit3.Items.Count; i++)
                {
                    combobox_Unit3.SelectedIndex = i;
                    comboboxItems_Unit3.Items.Add(combobox_Unit3.Text);
                }
                comboboxItems_Unit3.SelectedIndex = _CmbIndex;
                combobox_Unit3.SelectedIndex = _CmbIndex;
                combobox_Unit4.DataSource = null;
                List<T_Unit> listUnit4 = new List<T_Unit>(db.T_Units.Select((T_Unit item) => item).ToList());
                listUnit4.Insert(0, new T_Unit());
                combobox_Unit4.DataSource = listUnit4;
                combobox_Unit4.DisplayMember = "Eng_Des";
                combobox_Unit4.ValueMember = "Unit_ID";
                comboboxItems_Unit4.Items.Add(" ");
                for (int i = 1; i < combobox_Unit4.Items.Count; i++)
                {
                    combobox_Unit4.SelectedIndex = i;
                    comboboxItems_Unit4.Items.Add(combobox_Unit4.Text);
                }
                comboboxItems_Unit4.SelectedIndex = _CmbIndex;
                combobox_Unit4.SelectedIndex = _CmbIndex;
                combobox_Unit5.DataSource = null;
                List<T_Unit> listUnit5 = new List<T_Unit>(db.T_Units.Select((T_Unit item) => item).ToList());
                listUnit5.Insert(0, new T_Unit());
                combobox_Unit5.DataSource = listUnit5;
                combobox_Unit5.DisplayMember = "Eng_Des";
                combobox_Unit5.ValueMember = "Unit_ID";
                comboboxItems_Unit5.Items.Add(" ");
                for (int i = 1; i < combobox_Unit5.Items.Count; i++)
                {
                    combobox_Unit5.SelectedIndex = i;
                    comboboxItems_Unit5.Items.Add(combobox_Unit5.Text);
                }
                comboboxItems_Unit5.SelectedIndex = _CmbIndex;
                combobox_Unit5.SelectedIndex = _CmbIndex;
            }
        }
        private void FillCombo()
        {
            int _CmbIndex = combobox_DateTyp.SelectedIndex;
            combobox_DateTyp.Items.Clear();
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
            {
                combobox_DateTyp.Items.Clear();
                combobox_DateTyp.Items.Add("يوم");
                combobox_DateTyp.Items.Add("شهر");
                combobox_DateTyp.Items.Add("سنة");
                comboBox_DefPack.Items.Clear();
                comboBox_DefPack.Items.Add("الوحدة الأولى");
                comboBox_DefPack.Items.Add("الوحدة الثانية");
                comboBox_DefPack.Items.Add("الوحدة الثالثة");
                comboBox_DefPack.Items.Add("الوحدة الرابعة");
                comboBox_DefPack.Items.Add("الوحدة الخامسة");
                comboBox_DefPack.SelectedIndex = 0;
                _CmbIndex = combobox_ItmeGroup.SelectedIndex;
                List<T_CATEGORY> listAccCat = new List<T_CATEGORY>(db.T_CATEGORies.Select((T_CATEGORY item) => item).ToList());
                combobox_ItmeGroup.DataSource = listAccCat;
                combobox_ItmeGroup.DisplayMember = "Arb_Des";
                combobox_ItmeGroup.ValueMember = "CAT_ID";
                combobox_ItmeGroup.SelectedIndex = 0;
                _CmbIndex = combobox_Unit1.SelectedIndex;
                combobox_Unit1.DataSource = null;
                List<T_Unit> listUnit1 = new List<T_Unit>(db.T_Units.Select((T_Unit item) => item).ToList());
                listUnit1.Insert(0, new T_Unit());
                combobox_Unit1.DataSource = listUnit1;
                combobox_Unit1.DisplayMember = "Arb_Des";
                combobox_Unit1.ValueMember = "Unit_ID";
                comboboxItems_Unit1.Items.Add(" ");
                for (int i = 1; i < combobox_Unit1.Items.Count; i++)
                {
                    combobox_Unit1.SelectedIndex = i;
                    comboboxItems_Unit1.Items.Add(combobox_Unit1.Text);
                }
                comboboxItems_Unit1.SelectedIndex = _CmbIndex;
                combobox_Unit1.SelectedIndex = _CmbIndex;
                _CmbIndex = combobox_Unit2.SelectedIndex;
                combobox_Unit2.DataSource = null;
                List<T_Unit> listUnit2 = new List<T_Unit>(db.T_Units.Select((T_Unit item) => item).ToList());
                listUnit2.Insert(0, new T_Unit());
                combobox_Unit2.DataSource = listUnit2;
                combobox_Unit2.DisplayMember = "Arb_Des";
                combobox_Unit2.ValueMember = "Unit_ID";
                combobox_Unit2.SelectedIndex = _CmbIndex;
                comboboxItems_Unit2.Items.Add(" ");
                for (int i = 1; i < combobox_Unit2.Items.Count; i++)
                {
                    combobox_Unit2.SelectedIndex = i;
                    comboboxItems_Unit2.Items.Add(combobox_Unit2.Text);
                }
                comboboxItems_Unit2.SelectedIndex = _CmbIndex;
                combobox_Unit2.SelectedIndex = _CmbIndex;
                _CmbIndex = combobox_Unit3.SelectedIndex;
                combobox_Unit3.DataSource = null;
                List<T_Unit> listUnit3 = new List<T_Unit>(db.T_Units.Select((T_Unit item) => item).ToList());
                listUnit3.Insert(0, new T_Unit());
                combobox_Unit3.DataSource = listUnit3;
                combobox_Unit3.DisplayMember = "Arb_Des";
                combobox_Unit3.ValueMember = "Unit_ID";
                combobox_Unit3.SelectedIndex = _CmbIndex;
                comboboxItems_Unit3.Items.Add(" ");
                for (int i = 1; i < combobox_Unit3.Items.Count; i++)
                {
                    combobox_Unit3.SelectedIndex = i;
                    comboboxItems_Unit3.Items.Add(combobox_Unit3.Text);
                }
                comboboxItems_Unit3.SelectedIndex = _CmbIndex;
                combobox_Unit3.SelectedIndex = _CmbIndex;
                _CmbIndex = combobox_Unit4.SelectedIndex;
                combobox_Unit4.DataSource = null;
                List<T_Unit> listUnit4 = new List<T_Unit>(db.T_Units.Select((T_Unit item) => item).ToList());
                listUnit4.Insert(0, new T_Unit());
                combobox_Unit4.DataSource = listUnit4;
                combobox_Unit4.DisplayMember = "Arb_Des";
                combobox_Unit4.ValueMember = "Unit_ID";
                combobox_Unit4.SelectedIndex = _CmbIndex;
                comboboxItems_Unit4.Items.Add(" ");
                for (int i = 1; i < combobox_Unit4.Items.Count; i++)
                {
                    combobox_Unit4.SelectedIndex = i;
                    comboboxItems_Unit4.Items.Add(combobox_Unit4.Text);
                }
                comboboxItems_Unit4.SelectedIndex = _CmbIndex;
                combobox_Unit4.SelectedIndex = _CmbIndex;
                _CmbIndex = combobox_Unit5.SelectedIndex;
                combobox_Unit5.DataSource = null;
                List<T_Unit> listUnit5 = new List<T_Unit>(db.T_Units.Select((T_Unit item) => item).ToList());
                listUnit5.Insert(0, new T_Unit());
                combobox_Unit5.DataSource = listUnit5;
                combobox_Unit5.DisplayMember = "Arb_Des";
                combobox_Unit5.ValueMember = "Unit_ID";
                combobox_Unit5.SelectedIndex = _CmbIndex;
                comboboxItems_Unit5.Items.Add(" ");
                for (int i = 1; i < combobox_Unit5.Items.Count; i++)
                {
                    combobox_Unit5.SelectedIndex = i;
                    comboboxItems_Unit5.Items.Add(combobox_Unit5.Text);
                }
                comboboxItems_Unit5.SelectedIndex = _CmbIndex;
                combobox_Unit5.SelectedIndex = _CmbIndex;
            }
            else
            {
                combobox_DateTyp.Items.Add("Day");
                combobox_DateTyp.Items.Add("Month");
                combobox_DateTyp.Items.Add("Year");
                comboBox_DefPack.Items.Clear();
                comboBox_DefPack.Items.Add("Unit 1");
                comboBox_DefPack.Items.Add("Unit 2");
                comboBox_DefPack.Items.Add("Unit 3");
                comboBox_DefPack.Items.Add("Unit 4");
                comboBox_DefPack.Items.Add("Unit 5");
                comboBox_DefPack.SelectedIndex = 0;
                List<T_CATEGORY> listAccCat = new List<T_CATEGORY>(db.T_CATEGORies.Select((T_CATEGORY item) => item).ToList());
                combobox_ItmeGroup.DataSource = listAccCat;
                combobox_ItmeGroup.DisplayMember = "Eng_Des";
                combobox_ItmeGroup.ValueMember = "CAT_ID";
                combobox_ItmeGroup.SelectedIndex = 0;
                combobox_Unit1.DataSource = null;
                List<T_Unit> listUnit1 = new List<T_Unit>(db.T_Units.Select((T_Unit item) => item).ToList());
                listUnit1.Insert(0, new T_Unit());
                combobox_Unit1.DataSource = listUnit1;
                combobox_Unit1.DisplayMember = "Eng_Des";
                combobox_Unit1.ValueMember = "Unit_ID";
                comboboxItems_Unit1.Items.Add(" ");
                for (int i = 1; i < combobox_Unit1.Items.Count; i++)
                {
                    combobox_Unit1.SelectedIndex = i;
                    comboboxItems_Unit1.Items.Add(combobox_Unit1.Text);
                }
                comboboxItems_Unit1.SelectedIndex = _CmbIndex;
                combobox_Unit1.SelectedIndex = _CmbIndex;
                combobox_Unit2.DataSource = null;
                List<T_Unit> listUnit2 = new List<T_Unit>(db.T_Units.Select((T_Unit item) => item).ToList());
                listUnit2.Insert(0, new T_Unit());
                combobox_Unit2.DataSource = listUnit2;
                combobox_Unit2.DisplayMember = "Eng_Des";
                combobox_Unit2.ValueMember = "Unit_ID";
                comboboxItems_Unit2.Items.Add(" ");
                for (int i = 1; i < combobox_Unit2.Items.Count; i++)
                {
                    combobox_Unit2.SelectedIndex = i;
                    comboboxItems_Unit2.Items.Add(combobox_Unit2.Text);
                }
                comboboxItems_Unit2.SelectedIndex = _CmbIndex;
                combobox_Unit2.SelectedIndex = _CmbIndex;
                combobox_Unit3.DataSource = null;
                List<T_Unit> listUnit3 = new List<T_Unit>(db.T_Units.Select((T_Unit item) => item).ToList());
                listUnit3.Insert(0, new T_Unit());
                combobox_Unit3.DataSource = listUnit3;
                combobox_Unit3.DisplayMember = "Eng_Des";
                combobox_Unit3.ValueMember = "Unit_ID";
                comboboxItems_Unit3.Items.Add(" ");
                for (int i = 1; i < combobox_Unit3.Items.Count; i++)
                {
                    combobox_Unit3.SelectedIndex = i;
                    comboboxItems_Unit3.Items.Add(combobox_Unit3.Text);
                }
                comboboxItems_Unit3.SelectedIndex = _CmbIndex;
                combobox_Unit3.SelectedIndex = _CmbIndex;
                combobox_Unit4.DataSource = null;
                List<T_Unit> listUnit4 = new List<T_Unit>(db.T_Units.Select((T_Unit item) => item).ToList());
                listUnit4.Insert(0, new T_Unit());
                combobox_Unit4.DataSource = listUnit4;
                combobox_Unit4.DisplayMember = "Eng_Des";
                combobox_Unit4.ValueMember = "Unit_ID";
                comboboxItems_Unit4.Items.Add(" ");
                for (int i = 1; i < combobox_Unit4.Items.Count; i++)
                {
                    combobox_Unit4.SelectedIndex = i;
                    comboboxItems_Unit4.Items.Add(combobox_Unit4.Text);
                }
                comboboxItems_Unit4.SelectedIndex = _CmbIndex;
                combobox_Unit4.SelectedIndex = _CmbIndex;
                combobox_Unit5.DataSource = null;
                List<T_Unit> listUnit5 = new List<T_Unit>(db.T_Units.Select((T_Unit item) => item).ToList());
                listUnit5.Insert(0, new T_Unit());
                combobox_Unit5.DataSource = listUnit5;
                combobox_Unit5.DisplayMember = "Eng_Des";
                combobox_Unit5.ValueMember = "Unit_ID";
                comboboxItems_Unit5.Items.Add(" ");
                for (int i = 1; i < combobox_Unit5.Items.Count; i++)
                {
                    combobox_Unit5.SelectedIndex = i;
                    comboboxItems_Unit5.Items.Add(combobox_Unit5.Text);
                }
                comboboxItems_Unit5.SelectedIndex = _CmbIndex;
                combobox_Unit5.SelectedIndex = _CmbIndex;
            }
        }
        public void Clear()
        {
            if (State == FormState.New)
            {
                return;
            }
            State = FormState.New;
            data_this = new T_Item();
            State = FormState.New;
            //    if (!System.Environment.MachineName.Contains("DESKTOP-320H5U2"))
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
                else if (!(controls[i].Name == codeControl.Name))
                {
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
                }
            }
            //    if (!System.Environment.MachineName.Contains("DESKTOP-320H5U2"))
            {
                try
                {
                    comboboxItems_Unit1.SelectedIndex = 0;
                    comboboxItems_Unit2.SelectedIndex = 0;
                    comboboxItems_Unit3.SelectedIndex = 0;
                    comboboxItems_Unit4.SelectedIndex = 0;
                    comboboxItems_Unit5.SelectedIndex = 0;
                }
                catch
                {
                }
                try
                {
                    doubleInput_DefPack.Text = string.Empty;
                }
                catch
                {
                }
                try
                {
                    comboBox_DefPack.SelectedIndex = 0;
                }
                catch
                {
                }
            }
            //     if (!System.Environment.MachineName.Contains("DESKTOP-320H5U2"))
            {
                c1FlexGrid_Items.SetData(1, 0, 0);
                c1FlexGrid_Items.SetData(1, 1, 0);
                c1FlexGrid_Items.SetData(1, 2, 0);
                c1FlexGrid_Items.SetData(1, 3, 0);
                c1FlexGrid_Items.SetData(1, 4, 0);
                c1FlexGrid_Items.SetData(1, 5, string.Empty);
                c1FlexGrid_Items.SetData(1, 6, false);
                textbox_Cost1.Text = string.Empty;
                textbox_Cost2.Text = string.Empty;
                Txt_ProductionDate.Text = string.Empty;
                Txt_ExpirationDate.Text = string.Empty;
                textbox_Cost3.Text = string.Empty;
                textbox_Cost4.Text = string.Empty;
                textbox_Cost5.Text = string.Empty;
                textbox_Pack1.Text = "1";
                textbox_Pack2.Text = string.Empty;
                textbox_Pack3.Text = string.Empty;
                textbox_Pack4.Text = string.Empty;
                textbox_Pack5.Text = string.Empty;
                textbox_Qty1.Text = string.Empty;
                textbox_Qty2.Text = string.Empty;
                textbox_Qty3.Text = string.Empty;
                textbox_Qty4.Text = string.Empty;
                textbox_Qty5.Text = string.Empty;
                textbox_SelPri1.Text = string.Empty;
                textbox_SelPri2.Text = string.Empty;
                textbox_SelPri3.Text = string.Empty;
                textbox_SelPri4.Text = string.Empty;
                textbox_SelPri5.Text = string.Empty;
                txtBarCode1.Text = string.Empty;
                txtBarCode2.Text = string.Empty;
                txtBarCode3.Text = string.Empty;
                txtBarCode4.Text = string.Empty;
                txtBarCode5.Text = string.Empty;
                radiobutton_RButDef1.Checked = true;
                radiobutton_RButDef2.Checked = false;
                radiobutton_RButDef3.Checked = false;
                radiobutton_RButDef4.Checked = false;
                radiobutton_RButDef5.Checked = false;
                radioButton_Goods.Checked = true;
                radioButton_Product.Checked = false;
                radioButton_RawMaterial.Checked = false;
                radioButton_Service.Checked = false;
                checkBoxX_BarcodeBalance.Checked = false;
                checkBoxX_Points.Checked = true;
                checkBoxX_ReturnInvSale.Checked = false;
                checkBoxX_InvSale.Checked = false;
                checkBoxX_InvPaymentReturn.Checked = false;
                checkBoxX_InvPayment.Checked = false;
                checkBoxX_InvEnter.Checked = false;
                checkBoxX_InvOut.Checked = false;
                comboboxItems_Unit1.Enabled = true;
                textbox_SelPri1.Enabled = true;
                textbox_Pack1.Enabled = true;
                comboboxItems_Unit2.Enabled = true;
                textbox_SelPri2.Enabled = true;
                textbox_Pack2.Enabled = true;
                comboboxItems_Unit3.Enabled = true;
                textbox_SelPri3.Enabled = true;
                textbox_Pack3.Enabled = true;
                comboboxItems_Unit4.Enabled = true;
                textbox_SelPri4.Enabled = true;
                textbox_Pack4.Enabled = true;
                comboboxItems_Unit5.Enabled = true;
                textbox_SelPri5.Enabled = true;
                textbox_Pack5.Enabled = true;
                textbox_Legates.IsInputReadOnly = false;
                textbox_Distributors.IsInputReadOnly = false;
                textbox_Sentence.IsInputReadOnly = false;
                textbox_Sectorial.IsInputReadOnly = false;
                textbox_VIP.IsInputReadOnly = false;
                metroStatusBar_itemsType.Enabled = true;
            }
            if (FlxInv.Rows.Count <= 1)
            {
                FlxInv.Rows.Count = 100;
            }
            else
            {
                FlxInv.Clear(ClearFlags.Content, 1, 1, FlxInv.Rows.Count - 1, 34);
            }
            pictureBox_PicItem.Image = null;
            button_DeleteFromSystem.Visible = false;
            textBox_TaxSales.Value = VarGeneral.Settings_Sys.DefSalesTax.Value;
            textBox_TaxPurchase.Value = VarGeneral.Settings_Sys.DefPurchaesTax.Value;
            if (File.Exists(Application.StartupPath + "\\Script\\SecriptInvitationCards.dll"))
            {
                radioButton_Service.Checked = true;
            }
            SetReadOnly = false;
        }
        public void SetData(T_Item value)
        {
            State = FormState.Saved;
            Button_Save.Enabled = false;
            txtBarCode1.GotFocus -= txtBarCode1_GotFocus;
            try
            {
                if (FlxInv.Rows.Count <= 1)
                {
                    FlxInv.Rows.Count = 100;
                }
                else
                {
                    FlxInv.Clear(ClearFlags.Content, 1, 1, FlxInv.Rows.Count - 1, 34);
                }
            }
            catch
            {
            }
            bool returned = db.StockCheckInvDet(DataThis.Itm_No);
            try
            {
                if (returned)
                {
                    buttonItem_EditPrice.Enabled = true;
                }
                else
                {
                    buttonItem_EditPrice.Enabled = false;
                }
            }
            catch
            {
                buttonItem_EditPrice.Enabled = false;
            }
            if (!returned)
            {
                returned = db.StockCheckInvOffer(DataThis.Itm_No);
            }
            try
            {
                textBox_ID.Tag = value.Itm_ID;
                for (int iiCnt = 0; iiCnt < combobox_ItmeGroup.Items.Count; iiCnt++)
                {
                    if (!value.ItmCat.HasValue)
                    {
                        break;
                    }
                    combobox_ItmeGroup.SelectedIndex = iiCnt;
                    if (combobox_ItmeGroup.SelectedValue.ToString() == value.ItmCat.ToString())
                    {
                        break;
                    }
                }
                try
                {
                    doubleInput_DefPack.Text = value.SecriptCeramic;
                }
                catch
                {
                    doubleInput_DefPack.Text = string.Empty;
                }
                try
                {
                    comboBox_DefPack.SelectedIndex = int.Parse(value.SecriptCeramicCombo);
                }
                catch
                {
                    comboBox_DefPack.SelectedIndex = 0;
                }
                textbox_Arb_Des.Text = value.Arb_Des;
                textbox_Eng_Des.Text = value.Eng_Des;
                textBox_SerialKey.Text = value.SerialKey;
                textBox_CommItm.Value = value.ItemComm.Value;
                textBox_DisItem.Value = value.ItemDis.Value;
                textBox_TaxSales.Value = value.TaxSales.Value;
                Txt_ProductionDate.Text = value.ProductionDate;
                Txt_ExpirationDate.Text = value.ExpirationDate;
                textBox_TaxPurchase.Value = value.TaxPurchas.Value;
                if (value.DefultVendor.HasValue)
                {
                    if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                    {
                        txtCustNo.Text = value.DefultVendor.ToString();
                        txtCustName.Text = db.StockAccDefWithOutBalance(value.DefultVendor.Value.ToString()).Arb_Des;
                    }
                    else
                    {
                        txtCustNo.Text = value.DefultVendor.ToString();
                        txtCustName.Text = db.StockAccDefWithOutBalance(value.DefultVendor.Value.ToString()).Eng_Des;
                    }
                }
                else
                {
                    txtCustNo.Text = string.Empty;
                    txtCustName.Text = string.Empty;
                }
                c1FlexGrid_Items.SetData(1, 0, value.OpenQty.Value);
                c1FlexGrid_Items.SetData(1, 1, value.AvrageCost.Value);
                c1FlexGrid_Items.SetData(1, 2, value.LastCost.Value);
                c1FlexGrid_Items.SetData(1, 3, value.StartCost.Value);
                c1FlexGrid_Items.SetData(1, 4, value.FirstCost.Value);
                c1FlexGrid_Items.SetData(1, 5, value.ItmLoc);
                int? lot = value.Lot;
                if (lot.Value == 0 && lot.HasValue)
                {
                    c1FlexGrid_Items.SetData(1, 6, false);
                }
                else
                {
                    c1FlexGrid_Items.SetData(1, 6, true);
                    textbox_DateNo.Value = value.DMY.Value;
                    combobox_DateTyp.SelectedIndex = value.LrnExp.Value;
                }
                if (value.ItmTyp.HasValue)
                {
                    lot = value.ItmTyp;
                    if (lot.Value == 0 && lot.HasValue)
                    {
                        radioButton_Goods.Checked = true;
                    }
                    else if (value.ItmTyp == 1)
                    {
                        radioButton_RawMaterial.Checked = true;
                    }
                    else if (value.ItmTyp == 2)
                    {
                        radioButton_Product.Checked = true;
                    }
                    else
                    {
                        radioButton_Service.Checked = true;
                    }
                }
                textbox_MaxQty.Value = value.QtyMax.Value;
                textbox_Supreme.Value = value.QtyLvl.Value;
                try
                {
                    if (value.Unit1.HasValue)
                    {
                        for (int iiCnt = 0; iiCnt < combobox_Unit1.Items.Count; iiCnt++)
                        {
                            combobox_Unit1.SelectedIndex = iiCnt;
                            if (combobox_Unit1.SelectedValue != null && combobox_Unit1.SelectedValue.ToString() == value.Unit1.ToString())
                            {
                                comboboxItems_Unit1.SelectedIndex = combobox_Unit1.SelectedIndex;
                                break;
                            }
                            if (combobox_Unit1.SelectedIndex == iiCnt)
                            {
                                combobox_Unit1.SelectedIndex = 0;
                            }
                        }
                        if (returned)
                        {
                            comboboxItems_Unit1.Enabled = false;
                            textbox_SelPri1.Enabled = false;
                            textbox_Pack1.Enabled = false;
                        }
                        else
                        {
                            comboboxItems_Unit1.Enabled = true;
                            textbox_SelPri1.Enabled = true;
                            textbox_Pack1.Enabled = true;
                        }
                    }
                    else
                    {
                        combobox_Unit1.SelectedIndex = -1;
                        comboboxItems_Unit1.SelectedIndex = -1;
                        comboboxItems_Unit1.Enabled = true;
                        textbox_SelPri1.Enabled = true;
                        textbox_Pack1.Enabled = true;
                    }
                }
                catch
                {
                    combobox_Unit1.SelectedIndex = -1;
                    comboboxItems_Unit1.SelectedIndex = -1;
                }
                textbox_SelPri1.Text = value.UntPri1.Value.ToString();
                textbox_Pack1.Text = value.Pack1.Value.ToString();
                try
                {
                    if (value.Unit2.HasValue)
                    {
                        for (int iiCnt = 0; iiCnt < combobox_Unit2.Items.Count; iiCnt++)
                        {
                            combobox_Unit2.SelectedIndex = iiCnt;
                            if (combobox_Unit2.SelectedValue != null && combobox_Unit2.SelectedValue.ToString() == value.Unit2.ToString())
                            {
                                comboboxItems_Unit2.SelectedIndex = combobox_Unit2.SelectedIndex;
                                break;
                            }
                            if (combobox_Unit2.SelectedIndex == iiCnt)
                            {
                                combobox_Unit2.SelectedIndex = 0;
                            }
                        }
                        if (returned)
                        {
                            comboboxItems_Unit2.Enabled = false;
                            textbox_SelPri2.Enabled = false;
                            textbox_Pack2.Enabled = false;
                        }
                        else
                        {
                            comboboxItems_Unit2.Enabled = true;
                            textbox_SelPri2.Enabled = true;
                            textbox_Pack2.Enabled = true;
                        }
                    }
                    else
                    {
                        combobox_Unit2.SelectedIndex = -1;
                        comboboxItems_Unit2.SelectedIndex = -1;
                        comboboxItems_Unit2.Enabled = true;
                        textbox_SelPri2.Enabled = true;
                        textbox_Pack2.Enabled = true;
                    }
                }
                catch
                {
                    combobox_Unit2.SelectedIndex = -1;
                    comboboxItems_Unit2.SelectedIndex = -1;
                }
                textbox_SelPri2.Text = value.UntPri2.Value.ToString();
                textbox_Pack2.Text = value.Pack2.Value.ToString();
                try
                {
                    if (value.Unit3.HasValue)
                    {
                        for (int iiCnt = 0; iiCnt < combobox_Unit3.Items.Count; iiCnt++)
                        {
                            combobox_Unit3.SelectedIndex = iiCnt;
                            if (combobox_Unit3.SelectedValue != null && combobox_Unit3.SelectedValue.ToString() == value.Unit3.ToString())
                            {
                                comboboxItems_Unit3.SelectedIndex = combobox_Unit3.SelectedIndex;
                                break;
                            }
                            if (combobox_Unit3.SelectedIndex == iiCnt)
                            {
                                combobox_Unit3.SelectedIndex = 0;
                            }
                        }
                        if (returned)
                        {
                            comboboxItems_Unit3.Enabled = false;
                            textbox_SelPri3.Enabled = false;
                            textbox_Pack3.Enabled = false;
                        }
                        else
                        {
                            comboboxItems_Unit3.Enabled = true;
                            textbox_SelPri3.Enabled = true;
                            textbox_Pack3.Enabled = true;
                        }
                    }
                    else
                    {
                        combobox_Unit3.SelectedIndex = -1;
                        comboboxItems_Unit3.SelectedIndex = -1;
                        comboboxItems_Unit3.Enabled = true;
                        textbox_SelPri3.Enabled = true;
                        textbox_Pack3.Enabled = true;
                    }
                }
                catch
                {
                    combobox_Unit3.SelectedIndex = -1;
                    comboboxItems_Unit3.SelectedIndex = -1;
                }
                textbox_SelPri3.Text = value.UntPri3.Value.ToString();
                textbox_Pack3.Text = value.Pack3.Value.ToString();
                try
                {
                    if (value.Unit4.HasValue)
                    {
                        for (int iiCnt = 0; iiCnt < combobox_Unit4.Items.Count; iiCnt++)
                        {
                            combobox_Unit4.SelectedIndex = iiCnt;
                            if (combobox_Unit4.SelectedValue != null && combobox_Unit4.SelectedValue.ToString() == value.Unit4.ToString())
                            {
                                comboboxItems_Unit4.SelectedIndex = combobox_Unit4.SelectedIndex;
                                break;
                            }
                            if (combobox_Unit4.SelectedIndex == iiCnt)
                            {
                                combobox_Unit4.SelectedIndex = 0;
                            }
                        }
                        if (returned)
                        {
                            comboboxItems_Unit4.Enabled = false;
                            textbox_SelPri4.Enabled = false;
                            textbox_Pack4.Enabled = false;
                        }
                        else
                        {
                            comboboxItems_Unit4.Enabled = true;
                            textbox_SelPri4.Enabled = true;
                            textbox_Pack4.Enabled = true;
                        }
                    }
                    else
                    {
                        combobox_Unit4.SelectedIndex = -1;
                        comboboxItems_Unit4.SelectedIndex = -1;
                        comboboxItems_Unit4.Enabled = true;
                        textbox_SelPri4.Enabled = true;
                        textbox_Pack4.Enabled = true;
                    }
                }
                catch
                {
                    combobox_Unit4.SelectedIndex = -1;
                    comboboxItems_Unit4.SelectedIndex = -1;
                }
                textbox_SelPri4.Text = value.UntPri4.Value.ToString();
                textbox_Pack4.Text = value.Pack4.Value.ToString();
                try
                {
                    if (value.Unit5.HasValue)
                    {
                        for (int iiCnt = 0; iiCnt < combobox_Unit5.Items.Count; iiCnt++)
                        {
                            combobox_Unit5.SelectedIndex = iiCnt;
                            if (combobox_Unit5.SelectedValue != null && combobox_Unit5.SelectedValue.ToString() == value.Unit5.ToString())
                            {
                                comboboxItems_Unit5.SelectedIndex = combobox_Unit5.SelectedIndex;
                                break;
                            }
                            if (combobox_Unit5.SelectedIndex == iiCnt)
                            {
                                combobox_Unit5.SelectedIndex = 0;
                            }
                        }
                        if (returned)
                        {
                            comboboxItems_Unit5.Enabled = false;
                            textbox_SelPri5.Enabled = false;
                            textbox_Pack5.Enabled = false;
                        }
                        else
                        {
                            comboboxItems_Unit5.Enabled = true;
                            textbox_SelPri5.Enabled = true;
                            textbox_Pack5.Enabled = true;
                        }
                    }
                    else
                    {
                        combobox_Unit5.SelectedIndex = -1;
                        comboboxItems_Unit5.SelectedIndex = -1;
                        comboboxItems_Unit5.Enabled = true;
                        textbox_SelPri5.Enabled = true;
                        textbox_Pack5.Enabled = true;
                    }
                }
                catch
                {
                    combobox_Unit5.SelectedIndex = -1;
                    comboboxItems_Unit5.SelectedIndex = -1;
                }
                textbox_SelPri5.Text = value.UntPri5.Value.ToString();
                textbox_Pack5.Text = value.Pack5.Value.ToString();
                if (value.DefultUnit == 1)
                {
                    radiobutton_RButDef1.Checked = true;
                }
                else if (value.DefultUnit == 2)
                {
                    radiobutton_RButDef2.Checked = true;
                }
                else if (value.DefultUnit == 3)
                {
                    radiobutton_RButDef3.Checked = true;
                }
                else if (value.DefultUnit == 4)
                {
                    radiobutton_RButDef4.Checked = true;
                }
                else if (value.DefultUnit == 5)
                {
                    radiobutton_RButDef5.Checked = true;
                }
                if (double.Parse(textbox_Pack1.Text) != 0.0)
                {
                    try
                    {
                        textbox_Cost1.Text = Math.Round(double.Parse(string.Concat(c1FlexGrid_Items.GetData(1, 1))) * double.Parse(textbox_Pack1.Text ?? string.Empty), VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2).ToString();
                    }
                    catch
                    {
                        textbox_Cost1.Text = "0";
                    }
                    try
                    {
                        textbox_Qty1.Text = Math.Round(double.Parse(VarGeneral.TString.TEmpty(string.Concat(c1FlexGrid_Items.GetData(1, 0)))) / double.Parse(VarGeneral.TString.TEmpty(textbox_Pack1.Text)), VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2).ToString();
                    }
                    catch
                    {
                        textbox_Qty1.Text = "0";
                    }
                }
                if (double.Parse(textbox_Pack2.Text) != 0.0)
                {
                    try
                    {
                        textbox_Cost2.Text = Math.Round(double.Parse(string.Concat(c1FlexGrid_Items.GetData(1, 1))) * double.Parse(textbox_Pack2.Text), VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2).ToString();
                    }
                    catch
                    {
                        textbox_Cost2.Text = "0";
                    }
                    try
                    {
                        textbox_Qty2.Text = Math.Round(double.Parse(VarGeneral.TString.TEmpty(string.Concat(c1FlexGrid_Items.GetData(1, 0)))) / double.Parse(VarGeneral.TString.TEmpty(textbox_Pack2.Text)), VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2).ToString();
                    }
                    catch
                    {
                        textbox_Qty2.Text = "0";
                    }
                }
                if (double.Parse(textbox_Pack3.Text) != 0.0)
                {
                    try
                    {
                        textbox_Cost3.Text = Math.Round(double.Parse(string.Concat(c1FlexGrid_Items.GetData(1, 1))) * double.Parse(textbox_Pack3.Text), VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2).ToString();
                    }
                    catch
                    {
                        textbox_Cost3.Text = "0";
                    }
                    try
                    {
                        textbox_Qty3.Text = Math.Round(double.Parse(VarGeneral.TString.TEmpty(string.Concat(c1FlexGrid_Items.GetData(1, 0)))) / double.Parse(VarGeneral.TString.TEmpty(textbox_Pack3.Text)), VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2).ToString();
                    }
                    catch
                    {
                        textbox_Qty3.Text = "0";
                    }
                }
                if (double.Parse(textbox_Pack4.Text) != 0.0)
                {
                    try
                    {
                        textbox_Cost4.Text = Math.Round(double.Parse(string.Concat(c1FlexGrid_Items.GetData(1, 1))) * double.Parse(textbox_Pack4.Text), VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2).ToString();
                    }
                    catch
                    {
                        textbox_Cost4.Text = "0";
                    }
                    try
                    {
                        textbox_Qty4.Text = Math.Round(double.Parse(VarGeneral.TString.TEmpty(string.Concat(c1FlexGrid_Items.GetData(1, 0)))) / double.Parse(VarGeneral.TString.TEmpty(textbox_Pack4.Text)), VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2).ToString();
                    }
                    catch
                    {
                        textbox_Qty4.Text = "0";
                    }
                }
                if (double.Parse(textbox_Pack5.Text) != 0.0)
                {
                    try
                    {
                        textbox_Cost5.Text = Math.Round(double.Parse(string.Concat(c1FlexGrid_Items.GetData(1, 1))) * double.Parse(textbox_Pack5.Text), VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2).ToString();
                    }
                    catch
                    {
                        textbox_Cost5.Text = "0";
                    }
                    try
                    {
                        textbox_Qty5.Text = Math.Round(double.Parse(VarGeneral.TString.TEmpty(string.Concat(c1FlexGrid_Items.GetData(1, 0)))) / double.Parse(VarGeneral.TString.TEmpty(textbox_Pack5.Text)), VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2).ToString();
                    }
                    catch
                    {
                        textbox_Qty5.Text = "0";
                    }
                }
                txtBarCode1.Text = value.BarCod1;
                txtBarCode2.Text = value.BarCod2;
                txtBarCode3.Text = value.BarCod3;
                txtBarCode4.Text = value.BarCod4;
                txtBarCode5.Text = value.BarCod5;
                textbox_Sentence.Value = data_this.Price1.Value;
                try
                {
                    textbox_Distributors.Value = data_this.Price2.Value;
                }
                catch { }
                try { textbox_Legates.Value = data_this.Price3.Value; }
                catch { }
                try { textbox_Sectorial.Value = data_this.Price4.Value; } catch { }
                try { textbox_VIP.Value = data_this.Price5.Value; } catch { }
                if (value.IsBalance.HasValue)
                {
                    if (value.IsBalance.Value)
                    {
                        checkBoxX_BarcodeBalance.Checked = true;
                    }
                    else
                    {
                        checkBoxX_BarcodeBalance.Checked = false;
                    }
                }
                else
                {
                    checkBoxX_BarcodeBalance.Checked = false;
                }
                if (value.IsPoints.HasValue)
                {
                    checkBoxX_Points.Checked = value.IsPoints.Value;
                }
                else
                {
                    checkBoxX_Points.Checked = false;
                }
                if (value.InvSaleStoped.HasValue)
                {
                    if (value.InvSaleStoped.Value)
                    {
                        checkBoxX_InvSale.Checked = true;
                    }
                    else
                    {
                        checkBoxX_InvSale.Checked = false;
                    }
                }
                else
                {
                    checkBoxX_InvSale.Checked = false;
                }
                if (value.InvSaleReturnStoped.HasValue)
                {
                    if (value.InvSaleReturnStoped.Value)
                    {
                        checkBoxX_ReturnInvSale.Checked = true;
                    }
                    else
                    {
                        checkBoxX_ReturnInvSale.Checked = false;
                    }
                }
                else
                {
                    checkBoxX_ReturnInvSale.Checked = false;
                }
                if (value.InvPaymentStoped.HasValue)
                {
                    if (value.InvPaymentStoped.Value)
                    {
                        checkBoxX_InvPayment.Checked = true;
                    }
                    else
                    {
                        checkBoxX_InvPayment.Checked = false;
                    }
                }
                else
                {
                    checkBoxX_InvPayment.Checked = false;
                }
                if (value.InvPaymentReturnStoped.HasValue)
                {
                    if (value.InvPaymentReturnStoped.Value)
                    {
                        checkBoxX_InvPaymentReturn.Checked = true;
                    }
                    else
                    {
                        checkBoxX_InvPaymentReturn.Checked = false;
                    }
                }
                else
                {
                    checkBoxX_InvPaymentReturn.Checked = false;
                }
                if (value.InvEnterStoped.HasValue)
                {
                    if (value.InvEnterStoped.Value)
                    {
                        checkBoxX_InvEnter.Checked = true;
                    }
                    else
                    {
                        checkBoxX_InvEnter.Checked = false;
                    }
                }
                else
                {
                    checkBoxX_InvEnter.Checked = false;
                }
                if (value.InvOutStoped.HasValue)
                {
                    if (value.InvOutStoped.Value)
                    {
                        checkBoxX_InvOut.Checked = true;
                    }
                    else
                    {
                        checkBoxX_InvOut.Checked = false;
                    }
                }
                else
                {
                    checkBoxX_InvOut.Checked = false;
                }
                if (value.ItmImg != null)
                {
                    byte[] arr = value.ItmImg.ToArray();
                    MemoryStream stream = new MemoryStream(arr);
                    pictureBox_PicItem.Image = Image.FromStream(stream);
                }
                else
                {
                    pictureBox_PicItem.Image = null;
                }
                try
                {
                    txtFiled1.Text = value.vSize1;
                    txtFiled2.Text = value.vSize2;
                    txtFiled3.Text = value.vSize3;
                    txtFiled4.Text = value.vSize4;
                    txtFiled5.Text = value.vSize5;
                    txtFiled6.Text = value.vSize6;
                }
                catch
                {
                }
                IDatabase Accdb = Database.GetDatabase(VarGeneral.BranchCS);
                SetReadOnly = true;
                try
                {
                    if (value.ItmTyp == 2)
                    {
                        using (new Stock_DataDataContext(VarGeneral.BranchCS))
                        {
                            LData_This = db.T_ItemDets.Where((T_ItemDet t) => t.ItmNo == value.Itm_No).ToList();
                            SetLines(LDataThis);
                        }
                    }
                }
                catch
                {
                }
                try
                {
                    if (returned)
                    {
                        textbox_Legates.IsInputReadOnly = true;
                        textbox_Distributors.IsInputReadOnly = true;
                        textbox_Sentence.IsInputReadOnly = true;
                        textbox_Sectorial.IsInputReadOnly = true;
                        textbox_VIP.IsInputReadOnly = true;
                        metroStatusBar_itemsType.Enabled = false;
                        List<T_INVDET> Quary = (from er in db.T_INVDETs
                                                where er.ItmNo == data_this.Itm_No
                                                where er.T_INVHED.IfDel == (int?)0
                                                select er).ToList();
                        List<T_ItemDet> Quary2 = db.T_ItemDets.Where((T_ItemDet er) => er.GItmNo == data_this.Itm_No).ToList();
                        if (Quary.Count <= 0 && Quary2.Count <= 0)
                        {
                            button_DeleteFromSystem.Visible = true;
                        }
                    }
                    else
                    {
                        textbox_Legates.IsInputReadOnly = false;
                        textbox_Distributors.IsInputReadOnly = false;
                        textbox_Sentence.IsInputReadOnly = false;
                        textbox_Sectorial.IsInputReadOnly = false;
                        textbox_VIP.IsInputReadOnly = false;
                        metroStatusBar_itemsType.Enabled = true;
                        List<T_INVDET> Quary = (from er in db.T_INVDETs
                                                where er.ItmNo == data_this.Itm_No
                                                where er.T_INVHED.IfDel == (int?)0
                                                select er).ToList();
                        List<T_ItemDet> Quary2 = db.T_ItemDets.Where((T_ItemDet er) => er.GItmNo == data_this.Itm_No).ToList();
                        if (Quary.Count() <= 0 && Quary2.Count <= 0)
                        {
                            button_DeleteFromSystem.Visible = true;
                        }
                    }
                }
                catch
                {
                    textbox_Legates.IsInputReadOnly = true;
                    textbox_Distributors.IsInputReadOnly = true;
                    textbox_Sentence.IsInputReadOnly = true;
                    textbox_Sectorial.IsInputReadOnly = true;
                    textbox_VIP.IsInputReadOnly = true;
                    metroStatusBar_itemsType.Enabled = false;
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("SetData:", error, enable: true);
                MessageBox.Show(error.Message);
            }
            txtBarCode1.GotFocus += txtBarCode1_GotFocus;
        }
        public void SetLines(List<T_ItemDet> listDet)
        {
            try
            {
                FlxInv.Rows.Count = listDet.Count + 1;
                FlxInv.Cols[27].Visible = false;
                for (int iiCnt = 1; iiCnt <= listDet.Count; iiCnt++)
                {
                    T_ItemDet _ItemsDet = listDet[iiCnt - 1];
                    _Items = db.StockItem(_ItemsDet.GItmNo);
                    FillItemDet(_Items, Barcod: false, iiCnt, _ItemsDet.Unit_.Value, _ItemsDet.StoreNo.Value, Math.Abs(_ItemsDet.Qty.Value), _ItemsDet.Price.Value);
                }
                GetInvTot();
            }
            catch
            {
                MessageBox.Show((LangArEn == 0) ? "حدث خطأ أثناء تعبئة الأسطر .." : "An error occurred while filling lines ..", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
        private void TextBox_Index_InputTextChanged(object sender)
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
        private T_Item GetData()
        {
            textBox_ID.Focus();
            try
            {
                data_this.Itm_No = textBox_ID.Text.Trim();
                data_this.ItmCat = int.Parse(combobox_ItmeGroup.SelectedValue.ToString());
                try
                {
                    data_this.SecriptCeramic = doubleInput_DefPack.Text;
                }
                catch
                {
                    data_this.SecriptCeramic = string.Empty;
                }
                try
                {
                    data_this.SecriptCeramicCombo = comboBox_DefPack.SelectedIndex.ToString();
                }
                catch
                {
                    data_this.SecriptCeramicCombo = "0";
                }
                data_this.Arb_Des = textbox_Arb_Des.Text;
                data_this.Eng_Des = textbox_Eng_Des.Text;
                data_this.SerialKey = textBox_SerialKey.Text;
                data_this.ProductionDate = Txt_ProductionDate.Text;
                data_this.ExpirationDate = Txt_ExpirationDate.Text;
                data_this.ItemComm = textBox_CommItm.Value;
                data_this.ItemDis = textBox_DisItem.Value;
                data_this.TaxSales = textBox_TaxSales.Value;
                data_this.TaxPurchas = textBox_TaxPurchase.Value;
                try
                {
                    if (!string.IsNullOrEmpty(txtCustNo.Text))
                    {
                        data_this.DefultVendor = int.Parse(txtCustNo.Text);
                    }
                    else
                    {
                        data_this.DefultVendor = null;
                    }
                }
                catch
                {
                    data_this.DefultVendor = null;
                }
                if (double.TryParse(c1FlexGrid_Items.GetData(1, 4).ToString(), out var value))
                {
                    data_this.FirstCost = value;
                }
                else
                {
                    data_this.FirstCost = 0.0;
                }
                if (double.TryParse(c1FlexGrid_Items.GetData(1, 3).ToString(), out value))
                {
                    data_this.StartCost = value;
                }
                else
                {
                    data_this.StartCost = 0.0;
                }
                if (double.TryParse(c1FlexGrid_Items.GetData(1, 1).ToString(), out value))
                {
                    data_this.AvrageCost = value;
                }
                else
                {
                    data_this.AvrageCost = 0.0;
                }
                if (double.TryParse(c1FlexGrid_Items.GetData(1, 2).ToString(), out value))
                {
                    data_this.LastCost = value;
                }
                else
                {
                    data_this.LastCost = 0.0;
                }
                if (double.TryParse(c1FlexGrid_Items.GetData(1, 0).ToString(), out value))
                {
                    data_this.OpenQty = value;
                }
                else
                {
                    data_this.OpenQty = 0.0;
                }
                data_this.ItmLoc = string.Concat(c1FlexGrid_Items.GetData(1, 5));
                if (radioButton_Goods.Checked)
                {
                    data_this.ItmTyp = 0;
                }
                else if (radioButton_RawMaterial.Checked)
                {
                    data_this.ItmTyp = 1;
                }
                else if (radioButton_Product.Checked)
                {
                    data_this.ItmTyp = 2;
                }
                else
                {
                    data_this.ItmTyp = 3;
                }
                data_this.QtyMax = textbox_MaxQty.Value;
                if (data_this.ItmTyp == 2)
                {
                    data_this.QtyLvl = 0.0;
                }
                else
                {
                    data_this.QtyLvl = textbox_Supreme.Value;
                }
                if ((bool)c1FlexGrid_Items.GetData(1, 6))
                {
                    data_this.Lot = 1;
                }
                else
                {
                    data_this.Lot = 0;
                }
                data_this.DMY = textbox_DateNo.Value;
                if (combobox_DateTyp.Enabled)
                {
                    data_this.LrnExp = combobox_DateTyp.SelectedIndex;
                }
                else
                {
                    data_this.LrnExp = 0;
                }
                try
                {
                    if (combobox_Unit1.SelectedValue != null && combobox_Unit1.SelectedValue.ToString() != "0")
                    {
                        data_this.Unit1 = int.Parse(combobox_Unit1.SelectedValue.ToString());
                    }
                    else
                    {
                        data_this.Unit1 = null;
                    }
                }
                catch
                {
                    data_this.Unit1 = null;
                }
                if (double.TryParse(textbox_SelPri1.Text, out value))
                {
                    data_this.UntPri1 = value;
                }
                else
                {
                    data_this.UntPri1 = 0.0;
                }
                data_this.Pack1 = 1.0;
                try
                {
                    if (combobox_Unit2.SelectedValue != null && combobox_Unit2.SelectedValue.ToString() != "0" && sideBarPanelItem_Unit2.Visible)
                    {
                        data_this.Unit2 = int.Parse(combobox_Unit2.SelectedValue.ToString());
                        if (double.TryParse(textbox_SelPri2.Text, out value))
                        {
                            data_this.UntPri2 = value;
                        }
                        else
                        {
                            data_this.UntPri2 = 0.0;
                        }
                        if (double.TryParse(textbox_Pack2.Text, out value))
                        {
                            data_this.Pack2 = value;
                        }
                        else
                        {
                            data_this.Pack2 = 0.0;
                        }
                    }
                    else
                    {
                        data_this.Unit2 = null;
                        data_this.UntPri2 = 0.0;
                        data_this.Pack2 = 0.0;
                    }
                }
                catch
                {
                    data_this.Unit2 = null;
                    data_this.UntPri2 = 0.0;
                    data_this.Pack2 = 0.0;
                }
                try
                {
                    if (combobox_Unit3.SelectedValue != null && combobox_Unit3.SelectedValue.ToString() != "0" && sideBarPanelItem_Unit3.Visible)
                    {
                        data_this.Unit3 = int.Parse(combobox_Unit3.SelectedValue.ToString());
                        if (double.TryParse(textbox_SelPri3.Text, out value))
                        {
                            data_this.UntPri3 = value;
                        }
                        else
                        {
                            data_this.UntPri3 = 0.0;
                        }
                        if (double.TryParse(textbox_Pack3.Text, out value))
                        {
                            data_this.Pack3 = value;
                        }
                        else
                        {
                            data_this.Pack3 = 0.0;
                        }
                    }
                    else
                    {
                        data_this.Unit3 = null;
                        data_this.UntPri3 = 0.0;
                        data_this.Pack3 = 0.0;
                    }
                }
                catch
                {
                    data_this.Unit3 = null;
                    data_this.UntPri3 = 0.0;
                    data_this.Pack3 = 0.0;
                }
                try
                {
                    if (combobox_Unit4.SelectedValue != null && combobox_Unit4.SelectedValue.ToString() != "0" && sideBarPanelItem_Unit4.Visible)
                    {
                        data_this.Unit4 = int.Parse(combobox_Unit4.SelectedValue.ToString());
                        if (double.TryParse(textbox_SelPri4.Text, out value))
                        {
                            data_this.UntPri4 = value;
                        }
                        else
                        {
                            data_this.UntPri4 = 0.0;
                        }
                        if (double.TryParse(textbox_Pack4.Text, out value))
                        {
                            data_this.Pack4 = value;
                        }
                        else
                        {
                            data_this.Pack4 = 0.0;
                        }
                    }
                    else
                    {
                        data_this.Unit4 = null;
                        data_this.UntPri4 = 0.0;
                        data_this.Pack4 = 0.0;
                    }
                }
                catch
                {
                    data_this.Unit4 = null;
                    data_this.UntPri4 = 0.0;
                    data_this.Pack4 = 0.0;
                }
                try
                {
                    if (combobox_Unit5.SelectedValue != null && combobox_Unit5.SelectedValue.ToString() != "0" && sideBarPanelItem_Unit5.Visible)
                    {
                        data_this.Unit5 = int.Parse(combobox_Unit5.SelectedValue.ToString());
                        if (double.TryParse(textbox_SelPri5.Text, out value))
                        {
                            data_this.UntPri5 = value;
                        }
                        else
                        {
                            data_this.UntPri5 = 0.0;
                        }
                        if (double.TryParse(textbox_Pack5.Text, out value))
                        {
                            data_this.Pack5 = value;
                        }
                        else
                        {
                            data_this.Pack5 = 0.0;
                        }
                    }
                    else
                    {
                        data_this.Unit5 = null;
                        data_this.UntPri5 = 0.0;
                        data_this.Pack5 = 0.0;
                    }
                }
                catch
                {
                    data_this.Unit5 = null;
                    data_this.UntPri5 = 0.0;
                    data_this.Pack5 = 0.0;
                }
                if (radiobutton_RButDef1.Checked)
                {
                    data_this.DefultUnit = 1;
                    if (double.TryParse(textbox_Pack1.Text, out value))
                    {
                        data_this.DefPack = value;
                    }
                    else
                    {
                        data_this.DefPack = 0.0;
                    }
                }
                else if (radiobutton_RButDef2.Checked)
                {
                    data_this.DefultUnit = 2;
                    if (double.TryParse(textbox_Pack2.Text, out value))
                    {
                        data_this.DefPack = value;
                    }
                    else
                    {
                        data_this.DefPack = 0.0;
                    }
                }
                else if (radiobutton_RButDef3.Checked)
                {
                    data_this.DefultUnit = 3;
                    if (double.TryParse(textbox_Pack3.Text, out value))
                    {
                        data_this.DefPack = value;
                    }
                    else
                    {
                        data_this.DefPack = 0.0;
                    }
                }
                else if (radiobutton_RButDef4.Checked)
                {
                    data_this.DefultUnit = 4;
                    if (double.TryParse(textbox_Pack4.Text, out value))
                    {
                        data_this.DefPack = value;
                    }
                    else
                    {
                        data_this.DefPack = 0.0;
                    }
                }
                else if (radiobutton_RButDef5.Checked)
                {
                    data_this.DefultUnit = 5;
                    if (double.TryParse(textbox_Pack5.Text, out value))
                    {
                        data_this.DefPack = value;
                    }
                    else
                    {
                        data_this.DefPack = 0.0;
                    }
                }
                data_this.Price1 = textbox_Sentence.Value;
                data_this.Price2 = textbox_Distributors.Value;
                data_this.Price3 = textbox_Legates.Value;
                data_this.Price4 = textbox_Sectorial.Value;
                data_this.Price5 = textbox_VIP.Value;
                data_this.BarCod1 = txtBarCode1.Text ?? string.Empty;
                data_this.BarCod2 = txtBarCode2.Text ?? string.Empty;
                data_this.BarCod3 = txtBarCode3.Text ?? string.Empty;
                data_this.BarCod4 = txtBarCode4.Text ?? string.Empty;
                data_this.BarCod5 = txtBarCode5.Text ?? string.Empty;
                data_this.IsBalance = checkBoxX_BarcodeBalance.Checked;
                data_this.IsPoints = checkBoxX_Points.Checked;
                data_this.InvSaleStoped = checkBoxX_InvSale.Checked;
                data_this.InvSaleReturnStoped = checkBoxX_ReturnInvSale.Checked;
                data_this.InvPaymentStoped = checkBoxX_InvPayment.Checked;
                data_this.InvPaymentReturnStoped = checkBoxX_InvPaymentReturn.Checked;
                data_this.InvEnterStoped = checkBoxX_InvEnter.Checked;
                data_this.InvOutStoped = checkBoxX_InvOut.Checked;
                data_this.CompanyID = 1;
                if (pictureBox_PicItem.Image != null)
                {
                    MemoryStream stream = new MemoryStream();
                    pictureBox_PicItem.Image.Save(stream, ImageFormat.Jpeg);
                    byte[] arr = stream.GetBuffer();
                    data_this.ItmImg = arr;
                }
                else
                {
                    data_this.ItmImg = null;
                }
                if (File.Exists(Application.StartupPath + "\\Script\\SecriptInvitationCards.dll") && VarGeneral.UserID != 1)
                {
                    data_this.BarCod1 = textBox_ID.Text;
                }
                try
                {
                    data_this.vSize1 = txtFiled1.Text;
                    data_this.vSize2 = txtFiled2.Text;
                    data_this.vSize3 = txtFiled3.Text;
                    data_this.vSize4 = txtFiled4.Text;
                    data_this.vSize5 = txtFiled5.Text;
                    data_this.vSize6 = txtFiled6.Text;
                }
                catch
                {
                    data_this.vSize1 = string.Empty;
                    data_this.vSize2 = string.Empty;
                    data_this.vSize3 = string.Empty;
                    data_this.vSize4 = string.Empty;
                    data_this.vSize5 = string.Empty;
                    data_this.vSize6 = string.Empty;
                }
                return data_this;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return data_this;
        }
        private void Button_Edit_Click(object sender, EventArgs e)
        {
            if (CanEdit && State != FormState.Edit && State != FormState.New && !string.IsNullOrEmpty(textBox_ID.Text))
            {
                if (State != FormState.New)
                {
                    State = FormState.Edit;
                }
                FlxInv.Rows.Count = FlxInv.Rows.Count + 100;
                SetReadOnly = false;
            }
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
                if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 0))
                {
                    T_Item itemSer = new T_Item();
                    double itemNo = 0.0;
                    string _symbol = string.Empty;
                    try
                    {
                        _symbol = db.StockCatID(int.Parse(combobox_ItmeGroup.SelectedValue.ToString())).CAT_Symbol.Trim();
                    }
                    catch
                    {
                        _symbol = string.Empty;
                    }
                    if (pkeys.Count == 0)
                    {
                        if (_symbol == string.Empty)
                        {
                            textBox_ID.Text = VarGeneral.Settings_Sys.AutoItm.ToString();
                        }
                        else
                        {
                            textBox_ID.Text = _symbol + VarGeneral.Settings_Sys.AutoItm;
                        }
                    }
                    else if (_symbol == string.Empty)
                    {
                        for (int i = 0; i < pkeys.Count; i++)
                        {
                            itemSer.Itm_No = PKeys[i];
                            if (Program.sIsNumeric(itemSer.Itm_No) && double.Parse(itemSer.Itm_No) > itemNo)
                            {
                                itemNo = double.Parse(itemSer.Itm_No);
                            }
                        }
                        textBox_ID.Text = (itemNo + 1.0).ToString();
                    }
                    else
                    {
                        List<string> newPkeys = pkeys.Where((string g) => g.StartsWith(_symbol)).ToList();
                        if (newPkeys.Count == 0)
                        {
                            textBox_ID.Text = _symbol + VarGeneral.Settings_Sys.AutoItm;
                        }
                        else
                        {
                            for (int i = 0; i < newPkeys.Count; i++)
                            {
                                itemSer.Itm_No = newPkeys[i].Replace(_symbol, string.Empty).Trim();
                                if (Program.sIsNumeric(itemSer.Itm_No) && double.Parse(itemSer.Itm_No) > itemNo)
                                {
                                    itemNo = double.Parse(itemSer.Itm_No);
                                }
                            }
                            textBox_ID.Text = _symbol + (itemNo + 1.0);
                        }
                    }
                    combobox_ItmeGroup.Focus();
                }
                else
                {
                    textBox_ID.Focus();
                }
                FlxInv.Rows.Count = 100;
                try
                {
                    if (comboboxItems_Unit1.Items.Count > 0)
                    {
                        comboboxItems_Unit1.SelectedIndex = 1;
                    }
                }
                catch
                {
                    comboboxItems_Unit1.SelectedIndex = 0;
                }
                State = FormState.New;
                if (File.Exists(Application.StartupPath + "\\Script\\SecriptMaintenanceCars.dll") || File.Exists(Application.StartupPath + "\\Script\\SecriptTegnicalCollage.dll"))
                {
                    MaintenanceCarsAdd();
                }
            }
        }
        private void MaintenanceCarsAdd()
        {
            if (!File.Exists(Application.StartupPath + "\\Script\\SecriptTegnicalCollage.dll"))
            {
                comboboxItems_Unit1.SelectedIndex = 1;
                comboboxItems_Unit2.SelectedIndex = 2;
                comboboxItems_Unit3.SelectedIndex = 3;
                comboboxItems_Unit4.SelectedIndex = 4;
                comboboxItems_Unit5.SelectedIndex = 5;
                textbox_Pack2.Text = "1";
                textbox_Pack3.Text = "1";
                textbox_Pack4.Text = "1";
                textbox_Pack5.Text = "1";
                radioButton_Service.Checked = true;
            }
            textbox_SelPri1.Text = "1";
            textbox_SelPri2.Text = "1";
            textbox_SelPri3.Text = "1";
            textbox_SelPri4.Text = "1";
            textbox_SelPri5.Text = "1";
        }
        private bool ValidData2()
        {
            if (!Button_Save.Enabled)
            {
                return false;
            }
            if (State == FormState.Edit && !CanEdit)
            {
                MessageBox.Show((LangArEn == 0) ? "لا يمكن اتمام هذه العملية .. الرجاء مراجعة صلاحيات المستخدمين !" : "Can not complete this process .. please see the powers of the users!", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }
            if (State == FormState.New && !Button_Add.Enabled)
            {
                MessageBox.Show((LangArEn == 0) ? "لا يمكن اتمام هذه العملية .. الرجاء مراجعة صلاحيات المستخدمين !" : "Can not complete this process .. please see the powers of the users!", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }
            if (textBox_ID.Text == string.Empty || textbox_Arb_Des.Text == string.Empty || textbox_Eng_Des.Text == string.Empty)
            {
                MessageBox.Show((LangArEn == 0) ? "لايمكن ان يكون الرمز او الإسم فارغا\u0651" : "Can not be a number or name is empty", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }
            try
            {
                if (!string.IsNullOrEmpty(c1FlexGrid_Items.GetData(1, 5).ToString()) && c1FlexGrid_Items.GetData(1, 5).ToString().Length > 40)
                {
                    MessageBox.Show((LangArEn == 0) ? "يجب ان يكون عدد حروف بيانات الرف لا يتجاوز 40 حرف" : "The number of site characters must not exceed 40 characters", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return false;
                }
            }
            catch
            {
            }
            try
            {
                if (combobox_ItmeGroup.SelectedIndex == -1)
                {
                    MessageBox.Show((LangArEn == 0) ? "يجب تحديد التصنيف" : "You must select Category", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return false;
                }
            }
            catch
            {
                MessageBox.Show((LangArEn == 0) ? "يجب تحديد التصنيف" : "You must select Category", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }
            if (radioButton_Product.Checked)
            {
                if (FlxInv.Rows.Count > 0)
                {
                    for (int iiCnt = 1; iiCnt <= FlxInv.Rows.Count; iiCnt++)
                    {
                        if (string.Concat(FlxInv.GetData(iiCnt, 1)) != string.Empty)
                        {
                            goto IL_02b8;
                        }
                    }
                }
                MessageBox.Show((LangArEn == 0) ? "يجب ادراج صنف واحد على الأقل لهذا الصنف التجميعي" : "Can not be a number or name is empty", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }
            goto IL_02b8;
            IL_02b8:
            try
            {
                if (combobox_Unit1.SelectedIndex <= 0 || combobox_Unit1.SelectedValue.ToString() == null)
                {
                    MessageBox.Show((LangArEn == 0) ? "يجب تحديد أصغر وحدة" : "You must select the smallest unit", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return false;
                }
            }
            catch
            {
                MessageBox.Show((LangArEn == 0) ? "يجب تحديد أصغر وحدة" : "You must select the smallest unit", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }
            if (double.Parse(VarGeneral.TString.TEmpty(textbox_Pack1.Text ?? string.Empty)) <= 0.0)
            {
                MessageBox.Show((LangArEn == 0) ? "يجب تحديد تعبئة الوحدة" : "You must select the mobilization of the unit", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                textbox_Pack1.Focus();
                return false;
            }
            if (double.Parse(VarGeneral.TString.TEmpty(textbox_SelPri1.Text ?? string.Empty)) <= 0.0 && !radioButton_Service.Checked)
            {
                MessageBox.Show((LangArEn == 0) ? "يجب تحديد سعر التعبئة" : "You must specify the price of packing", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                textbox_SelPri1.Focus();
                return false;
            }
            try
            {
                if (combobox_Unit2.SelectedIndex > 0)
                {
                    if (double.Parse(VarGeneral.TString.TEmpty(textbox_Pack2.Text ?? string.Empty)) <= 0.0)
                    {
                        MessageBox.Show((LangArEn == 0) ? "يجب تحديد تعبئة الوحدة" : "You must select the mobilization of the unit", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        textbox_Pack2.Focus();
                        return false;
                    }
                    if (double.Parse(VarGeneral.TString.TEmpty(textbox_SelPri2.Text ?? string.Empty)) <= 0.0 && !radioButton_Service.Checked)
                    {
                        MessageBox.Show((LangArEn == 0) ? "يجب تحديد سعر التعبئة" : "You must specify the price of packing", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        textbox_SelPri2.Focus();
                        return false;
                    }
                    if (combobox_Unit2.SelectedIndex == combobox_Unit1.SelectedIndex)
                    {
                        MessageBox.Show((LangArEn == 0) ? "يجب عدم تكرار إسم الوحدة بين الوحدات الخمسة .. تاكد من إسم الوحدة الثانية" : "We should not repeat the unity among the five units name ..", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        combobox_Unit2.Focus();
                        return false;
                    }
                }
                else
                {
                    textbox_Pack2.Text = string.Empty;
                    textbox_SelPri2.Text = string.Empty;
                }
            }
            catch
            {
            }
            try
            {
                if (combobox_Unit3.SelectedIndex > 0)
                {
                    if (double.Parse(VarGeneral.TString.TEmpty(textbox_Pack3.Text ?? string.Empty)) <= 0.0)
                    {
                        MessageBox.Show((LangArEn == 0) ? "يجب تحديد تعبئة الوحدة" : "You must select the mobilization of the unit", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        textbox_Pack3.Focus();
                        return false;
                    }
                    if (double.Parse(VarGeneral.TString.TEmpty(textbox_SelPri3.Text ?? string.Empty)) <= 0.0 && !radioButton_Service.Checked)
                    {
                        MessageBox.Show((LangArEn == 0) ? "يجب تحديد سعر التعبئة" : "You must specify the price of packing", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        textbox_SelPri3.Focus();
                        return false;
                    }
                    if (combobox_Unit3.SelectedIndex == combobox_Unit1.SelectedIndex || combobox_Unit3.SelectedIndex == combobox_Unit2.SelectedIndex)
                    {
                        MessageBox.Show((LangArEn == 0) ? "يجب عدم تكرار إسم الوحدة بين الوحدات الخمسة .. تاكد من إسم الوحدة الثالثة" : "We should not repeat the unity among the five units name ..", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        combobox_Unit3.Focus();
                        return false;
                    }
                }
                else
                {
                    textbox_Pack3.Text = string.Empty;
                    textbox_SelPri3.Text = string.Empty;
                }
            }
            catch
            {
            }
            try
            {
                if (combobox_Unit4.SelectedIndex > 0)
                {
                    if (double.Parse(VarGeneral.TString.TEmpty(textbox_Pack4.Text ?? string.Empty)) <= 0.0)
                    {
                        MessageBox.Show((LangArEn == 0) ? "يجب تحديد تعبئة الوحدة" : "You must select the mobilization of the unit", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        textbox_Pack4.Focus();
                        return false;
                    }
                    if (double.Parse(VarGeneral.TString.TEmpty(textbox_SelPri4.Text ?? string.Empty)) <= 0.0 && !radioButton_Service.Checked)
                    {
                        MessageBox.Show((LangArEn == 0) ? "يجب تحديد سعر التعبئة" : "You must specify the price of packing", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        textbox_SelPri4.Focus();
                        return false;
                    }
                    if (combobox_Unit4.SelectedIndex == combobox_Unit1.SelectedIndex || combobox_Unit4.SelectedIndex == combobox_Unit2.SelectedIndex || combobox_Unit4.SelectedIndex == combobox_Unit3.SelectedIndex)
                    {
                        MessageBox.Show((LangArEn == 0) ? "يجب عدم تكرار إسم الوحدة بين الوحدات الخمسة .. تاكد من إسم الوحدة الرابعة" : "We should not repeat the unity among the five units name ..", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        combobox_Unit4.Focus();
                        return false;
                    }
                }
                else
                {
                    textbox_Pack4.Text = string.Empty;
                    textbox_SelPri4.Text = string.Empty;
                }
            }
            catch
            {
            }
            try
            {
                if (combobox_Unit5.SelectedIndex > 0)
                {
                    if (double.Parse(VarGeneral.TString.TEmpty(textbox_Pack5.Text ?? string.Empty)) <= 0.0)
                    {
                        MessageBox.Show((LangArEn == 0) ? "يجب تحديد تعبئة الوحدة" : "You must select the mobilization of the unit", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        textbox_Pack5.Focus();
                        return false;
                    }
                    if (double.Parse(VarGeneral.TString.TEmpty(textbox_SelPri5.Text ?? string.Empty)) <= 0.0 && !radioButton_Service.Checked)
                    {
                        MessageBox.Show((LangArEn == 0) ? "يجب تحديد سعر التعبئة" : "You must specify the price of packing", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        textbox_SelPri5.Focus();
                        return false;
                    }
                    if (combobox_Unit5.SelectedIndex == combobox_Unit1.SelectedIndex || combobox_Unit5.SelectedIndex == combobox_Unit2.SelectedIndex || combobox_Unit5.SelectedIndex == combobox_Unit3.SelectedIndex || combobox_Unit5.SelectedIndex == combobox_Unit4.SelectedIndex)
                    {
                        MessageBox.Show((LangArEn == 0) ? "يجب عدم تكرار إسم الوحدة بين الوحدات الخمسة .. تاكد من إسم الوحدة الخامسة" : "We should not repeat the unity among the five units name ..", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        combobox_Unit5.Focus();
                        return false;
                    }
                }
                else
                {
                    textbox_Pack5.Text = string.Empty;
                    textbox_SelPri5.Text = string.Empty;
                }
            }
            catch
            {
            }
            if (File.Exists(Application.StartupPath + "\\Script\\SecriptCeramic.dll"))
            {
                if (!string.IsNullOrEmpty(doubleInput_DefPack.Text))
                {
                    try
                    {
                        double c = double.Parse(doubleInput_DefPack.Text);
                    }
                    catch
                    {
                        MessageBox.Show((LangArEn == 0) ? "يرجى التأكد من تعبئة الكراتين" : "Please be sure to fill the balls", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        return false;
                    }
                    if (!doubleInput_DefPack.Text.Contains("."))
                    {
                        MessageBox.Show((LangArEn == 0) ? "يرجى التأكد من تعبئة الكراتين" : "Please be sure to fill the balls", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        return false;
                    }
                    int z = -1;
                    for (int i = 0; i < doubleInput_DefPack.Text.Length; i++)
                    {
                        if (doubleInput_DefPack.Text.Substring(i, 1) == ".")
                        {
                            z = i;
                            break;
                        }
                    }
                    if (z < 0)
                    {
                        MessageBox.Show((LangArEn == 0) ? "يرجى التأكد من تعبئة الكراتين" : "Please be sure to fill the balls", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        return false;
                    }
                    try
                    {
                        string cc = doubleInput_DefPack.Text.Substring(z + 1, 1);
                    }
                    catch
                    {
                        MessageBox.Show((LangArEn == 0) ? "يرجى التأكد من تعبئة الكراتين" : "Please be sure to fill the balls", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        return false;
                    }
                }
                if (comboBox_DefPack.SelectedIndex == 1 && string.IsNullOrEmpty(textbox_Pack2.Text))
                {
                    MessageBox.Show((LangArEn == 0) ? "يرجى التأكد من تعبئة الكراتين" : "Please be sure to fill the balls", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return false;
                }
                if (comboBox_DefPack.SelectedIndex == 2 && string.IsNullOrEmpty(textbox_Pack3.Text))
                {
                    MessageBox.Show((LangArEn == 0) ? "يرجى التأكد من تعبئة الكراتين" : "Please be sure to fill the balls", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return false;
                }
                if (comboBox_DefPack.SelectedIndex == 3 && string.IsNullOrEmpty(textbox_Pack4.Text))
                {
                    MessageBox.Show((LangArEn == 0) ? "يرجى التأكد من تعبئة الكراتين" : "Please be sure to fill the balls", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return false;
                }
                if (comboBox_DefPack.SelectedIndex == 4 && string.IsNullOrEmpty(textbox_Pack5.Text))
                {
                    MessageBox.Show((LangArEn == 0) ? "يرجى التأكد من تعبئة الكراتين" : "Please be sure to fill the balls", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return false;
                }
            }
            if (txtBarCode1.Text != string.Empty)
            {
                List<T_Item> returned = db.SelectBarcodNoByReturnNoList(txtBarCode1.Text);
                try
                {
                    if (returned.Count > 1)
                    {
                        MessageBox.Show((LangArEn == 0) ? "الرقم الذي قمت بإدخاله موجود من قبل - مكرر .. يرجى المحاولة مرة اخرى" : "The number you have entered already exists - bis .. Please try again.", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        txtBarCode1.Text = string.Empty;
                        txtBarCode1.Focus();
                        return false;
                    }
                }
                catch
                {
                }
            }
            if (txtBarCode2.Text != string.Empty)
            {
                List<T_Item> returned = db.SelectBarcodNoByReturnNoList(txtBarCode2.Text);
                try
                {
                    if (returned.Count > 1)
                    {
                        MessageBox.Show((LangArEn == 0) ? "الرقم الذي قمت بإدخاله موجود من قبل - مكرر .. يرجى المحاولة مرة اخرى" : "The number you have entered already exists - bis .. Please try again.", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        txtBarCode2.Text = string.Empty;
                        txtBarCode2.Focus();
                        return false;
                    }
                }
                catch
                {
                }
            }
            if (txtBarCode3.Text != string.Empty)
            {
                List<T_Item> returned = db.SelectBarcodNoByReturnNoList(txtBarCode3.Text);
                try
                {
                    if (returned.Count > 1)
                    {
                        MessageBox.Show((LangArEn == 0) ? "الرقم الذي قمت بإدخاله موجود من قبل - مكرر .. يرجى المحاولة مرة اخرى" : "The number you have entered already exists - bis .. Please try again.", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        txtBarCode3.Text = string.Empty;
                        txtBarCode3.Focus();
                        return false;
                    }
                }
                catch
                {
                }
            }
            if (txtBarCode4.Text != string.Empty)
            {
                List<T_Item> returned = db.SelectBarcodNoByReturnNoList(txtBarCode4.Text);
                try
                {
                    if (returned.Count > 1)
                    {
                        MessageBox.Show((LangArEn == 0) ? "الرقم الذي قمت بإدخاله موجود من قبل - مكرر .. يرجى المحاولة مرة اخرى" : "The number you have entered already exists - bis .. Please try again.", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        txtBarCode4.Text = string.Empty;
                        txtBarCode4.Focus();
                        return false;
                    }
                }
                catch
                {
                }
            }
            if (txtBarCode5.Text != string.Empty)
            {
                List<T_Item> returned = db.SelectBarcodNoByReturnNoList(txtBarCode5.Text);
                try
                {
                    if (returned.Count > 1)
                    {
                        MessageBox.Show((LangArEn == 0) ? "الرقم الذي قمت بإدخاله موجود من قبل - مكرر .. يرجى المحاولة مرة اخرى" : "The number you have entered already exists - bis .. Please try again.", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        txtBarCode5.Text = string.Empty;
                        txtBarCode5.Focus();
                        return false;
                    }
                }
                catch
                {
                }
            }
            return true;
        }
        private bool ValidData()
        {
            if (!Button_Save.Enabled)
            {
                return false;
            }
            if (State == FormState.Edit && !CanEdit)
            {
                MessageBox.Show((LangArEn == 0) ? "لا يمكن اتمام هذه العملية .. الرجاء مراجعة صلاحيات المستخدمين !" : "Can not complete this process .. please see the powers of the users!", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }
            if (State == FormState.New && !Button_Add.Enabled)
            {
                MessageBox.Show((LangArEn == 0) ? "لا يمكن اتمام هذه العملية .. الرجاء مراجعة صلاحيات المستخدمين !" : "Can not complete this process .. please see the powers of the users!", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }
            if (textBox_ID.Text == string.Empty || textbox_Arb_Des.Text == string.Empty || textbox_Eng_Des.Text == string.Empty)
            {
                MessageBox.Show((LangArEn == 0) ? "لايمكن ان يكون الرمز او الإسم فارغا\u0651" : "Can not be a number or name is empty", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }
            try
            {
                if (!string.IsNullOrEmpty(c1FlexGrid_Items.GetData(1, 5).ToString()) && c1FlexGrid_Items.GetData(1, 5).ToString().Length > 40)
                {
                    MessageBox.Show((LangArEn == 0) ? "يجب ان يكون عدد حروف بيانات الرف لا يتجاوز 40 حرف" : "The number of site characters must not exceed 40 characters", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return false;
                }
            }
            catch
            {
            }
            try
            {
                if (combobox_ItmeGroup.SelectedIndex == -1)
                {
                    MessageBox.Show((LangArEn == 0) ? "يجب تحديد التصنيف" : "You must select Category", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return false;
                }
            }
            catch
            {
                MessageBox.Show((LangArEn == 0) ? "يجب تحديد التصنيف" : "You must select Category", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }
            if (radioButton_Product.Checked)
            {
                if (FlxInv.Rows.Count > 0)
                {
                    for (int iiCnt = 1; iiCnt <= FlxInv.Rows.Count; iiCnt++)
                    {
                        if (string.Concat(FlxInv.GetData(iiCnt, 1)) != string.Empty)
                        {
                            goto IL_02b8;
                        }
                    }
                }
                MessageBox.Show((LangArEn == 0) ? "يجب ادراج صنف واحد على الأقل لهذا الصنف التجميعي" : "Can not be a number or name is empty", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }
            goto IL_02b8;
            IL_02b8:
            try
            {
                if (combobox_Unit1.SelectedIndex <= 0 || combobox_Unit1.SelectedValue.ToString() == null)
                {
                    MessageBox.Show((LangArEn == 0) ? "يجب تحديد أصغر وحدة" : "You must select the smallest unit", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return false;
                }
            }
            catch
            {
                MessageBox.Show((LangArEn == 0) ? "يجب تحديد أصغر وحدة" : "You must select the smallest unit", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }
            if (double.Parse(VarGeneral.TString.TEmpty(textbox_Pack1.Text ?? string.Empty)) <= 0.0)
            {
                MessageBox.Show((LangArEn == 0) ? "يجب تحديد تعبئة الوحدة" : "You must select the mobilization of the unit", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                textbox_Pack1.Focus();
                return false;
            }
            if (double.Parse(VarGeneral.TString.TEmpty(textbox_SelPri1.Text ?? string.Empty)) <= 0.0 && !radioButton_Service.Checked)
            {
                MessageBox.Show((LangArEn == 0) ? "يجب تحديد سعر التعبئة" : "You must specify the price of packing", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                textbox_SelPri1.Focus();
                return false;
            }
            try
            {
                if (combobox_Unit2.SelectedIndex > 0)
                {
                    if (double.Parse(VarGeneral.TString.TEmpty(textbox_Pack2.Text ?? string.Empty)) <= 0.0)
                    {
                        MessageBox.Show((LangArEn == 0) ? "يجب تحديد تعبئة الوحدة" : "You must select the mobilization of the unit", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        textbox_Pack2.Focus();
                        return false;
                    }
                    if (double.Parse(VarGeneral.TString.TEmpty(textbox_SelPri2.Text ?? string.Empty)) <= 0.0 && !radioButton_Service.Checked)
                    {
                        MessageBox.Show((LangArEn == 0) ? "يجب تحديد سعر التعبئة" : "You must specify the price of packing", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        textbox_SelPri2.Focus();
                        return false;
                    }
                    if (combobox_Unit2.SelectedIndex == combobox_Unit1.SelectedIndex)
                    {
                        MessageBox.Show((LangArEn == 0) ? "يجب عدم تكرار إسم الوحدة بين الوحدات الخمسة .. تاكد من إسم الوحدة الثانية" : "We should not repeat the unity among the five units name ..", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        combobox_Unit2.Focus();
                        return false;
                    }
                }
                else
                {
                    textbox_Pack2.Text = string.Empty;
                    textbox_SelPri2.Text = string.Empty;
                }
            }
            catch
            {
            }
            try
            {
                if (combobox_Unit3.SelectedIndex > 0)
                {
                    if (double.Parse(VarGeneral.TString.TEmpty(textbox_Pack3.Text ?? string.Empty)) <= 0.0)
                    {
                        MessageBox.Show((LangArEn == 0) ? "يجب تحديد تعبئة الوحدة" : "You must select the mobilization of the unit", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        textbox_Pack3.Focus();
                        return false;
                    }
                    if (double.Parse(VarGeneral.TString.TEmpty(textbox_SelPri3.Text ?? string.Empty)) <= 0.0 && !radioButton_Service.Checked)
                    {
                        MessageBox.Show((LangArEn == 0) ? "يجب تحديد سعر التعبئة" : "You must specify the price of packing", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        textbox_SelPri3.Focus();
                        return false;
                    }
                    if (combobox_Unit3.SelectedIndex == combobox_Unit1.SelectedIndex || combobox_Unit3.SelectedIndex == combobox_Unit2.SelectedIndex)
                    {
                        MessageBox.Show((LangArEn == 0) ? "يجب عدم تكرار إسم الوحدة بين الوحدات الخمسة .. تاكد من إسم الوحدة الثالثة" : "We should not repeat the unity among the five units name ..", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        combobox_Unit3.Focus();
                        return false;
                    }
                }
                else
                {
                    textbox_Pack3.Text = string.Empty;
                    textbox_SelPri3.Text = string.Empty;
                }
            }
            catch
            {
            }
            try
            {
                if (combobox_Unit4.SelectedIndex > 0)
                {
                    if (double.Parse(VarGeneral.TString.TEmpty(textbox_Pack4.Text ?? string.Empty)) <= 0.0)
                    {
                        MessageBox.Show((LangArEn == 0) ? "يجب تحديد تعبئة الوحدة" : "You must select the mobilization of the unit", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        textbox_Pack4.Focus();
                        return false;
                    }
                    if (double.Parse(VarGeneral.TString.TEmpty(textbox_SelPri4.Text ?? string.Empty)) <= 0.0 && !radioButton_Service.Checked)
                    {
                        MessageBox.Show((LangArEn == 0) ? "يجب تحديد سعر التعبئة" : "You must specify the price of packing", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        textbox_SelPri4.Focus();
                        return false;
                    }
                    if (combobox_Unit4.SelectedIndex == combobox_Unit1.SelectedIndex || combobox_Unit4.SelectedIndex == combobox_Unit2.SelectedIndex || combobox_Unit4.SelectedIndex == combobox_Unit3.SelectedIndex)
                    {
                        MessageBox.Show((LangArEn == 0) ? "يجب عدم تكرار إسم الوحدة بين الوحدات الخمسة .. تاكد من إسم الوحدة الرابعة" : "We should not repeat the unity among the five units name ..", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        combobox_Unit4.Focus();
                        return false;
                    }
                }
                else
                {
                    textbox_Pack4.Text = string.Empty;
                    textbox_SelPri4.Text = string.Empty;
                }
            }
            catch
            {
            }
            try
            {
                if (combobox_Unit5.SelectedIndex > 0)
                {
                    if (double.Parse(VarGeneral.TString.TEmpty(textbox_Pack5.Text ?? string.Empty)) <= 0.0)
                    {
                        MessageBox.Show((LangArEn == 0) ? "يجب تحديد تعبئة الوحدة" : "You must select the mobilization of the unit", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        textbox_Pack5.Focus();
                        return false;
                    }
                    if (double.Parse(VarGeneral.TString.TEmpty(textbox_SelPri5.Text ?? string.Empty)) <= 0.0 && !radioButton_Service.Checked)
                    {
                        MessageBox.Show((LangArEn == 0) ? "يجب تحديد سعر التعبئة" : "You must specify the price of packing", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        textbox_SelPri5.Focus();
                        return false;
                    }
                    if (combobox_Unit5.SelectedIndex == combobox_Unit1.SelectedIndex || combobox_Unit5.SelectedIndex == combobox_Unit2.SelectedIndex || combobox_Unit5.SelectedIndex == combobox_Unit3.SelectedIndex || combobox_Unit5.SelectedIndex == combobox_Unit4.SelectedIndex)
                    {
                        MessageBox.Show((LangArEn == 0) ? "يجب عدم تكرار إسم الوحدة بين الوحدات الخمسة .. تاكد من إسم الوحدة الخامسة" : "We should not repeat the unity among the five units name ..", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        combobox_Unit5.Focus();
                        return false;
                    }
                }
                else
                {
                    textbox_Pack5.Text = string.Empty;
                    textbox_SelPri5.Text = string.Empty;
                }
            }
            catch
            {
            }
            if (File.Exists(Application.StartupPath + "\\Script\\SecriptCeramic.dll"))
            {
                if (!string.IsNullOrEmpty(doubleInput_DefPack.Text))
                {
                    try
                    {
                        double c = double.Parse(doubleInput_DefPack.Text);
                    }
                    catch
                    {
                        MessageBox.Show((LangArEn == 0) ? "يرجى التأكد من تعبئة الكراتين" : "Please be sure to fill the balls", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        return false;
                    }
                    if (!doubleInput_DefPack.Text.Contains("."))
                    {
                        MessageBox.Show((LangArEn == 0) ? "يرجى التأكد من تعبئة الكراتين" : "Please be sure to fill the balls", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        return false;
                    }
                    int z = -1;
                    for (int i = 0; i < doubleInput_DefPack.Text.Length; i++)
                    {
                        if (doubleInput_DefPack.Text.Substring(i, 1) == ".")
                        {
                            z = i;
                            break;
                        }
                    }
                    if (z < 0)
                    {
                        MessageBox.Show((LangArEn == 0) ? "يرجى التأكد من تعبئة الكراتين" : "Please be sure to fill the balls", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        return false;
                    }
                    try
                    {
                        string cc = doubleInput_DefPack.Text.Substring(z + 1, 1);
                    }
                    catch
                    {
                        MessageBox.Show((LangArEn == 0) ? "يرجى التأكد من تعبئة الكراتين" : "Please be sure to fill the balls", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        return false;
                    }
                }
                if (comboBox_DefPack.SelectedIndex == 1 && string.IsNullOrEmpty(textbox_Pack2.Text))
                {
                    MessageBox.Show((LangArEn == 0) ? "يرجى التأكد من تعبئة الكراتين" : "Please be sure to fill the balls", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return false;
                }
                if (comboBox_DefPack.SelectedIndex == 2 && string.IsNullOrEmpty(textbox_Pack3.Text))
                {
                    MessageBox.Show((LangArEn == 0) ? "يرجى التأكد من تعبئة الكراتين" : "Please be sure to fill the balls", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return false;
                }
                if (comboBox_DefPack.SelectedIndex == 3 && string.IsNullOrEmpty(textbox_Pack4.Text))
                {
                    MessageBox.Show((LangArEn == 0) ? "يرجى التأكد من تعبئة الكراتين" : "Please be sure to fill the balls", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return false;
                }
                if (comboBox_DefPack.SelectedIndex == 4 && string.IsNullOrEmpty(textbox_Pack5.Text))
                {
                    MessageBox.Show((LangArEn == 0) ? "يرجى التأكد من تعبئة الكراتين" : "Please be sure to fill the balls", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return false;
                }
            }
            if (txtBarCode1.Text != string.Empty)
            {
                List<T_Item> returned = db.SelectBarcodNoByReturnNoList(txtBarCode1.Text);
                try
                {
                    if (returned.Count > 1)
                    {
                        MessageBox.Show((LangArEn == 0) ? "الرقم الذي قمت بإدخاله موجود من قبل - مكرر .. يرجى المحاولة مرة اخرى" : "The number you have entered already exists - bis .. Please try again.", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        txtBarCode1.Text = string.Empty;
                        txtBarCode1.Focus();
                        return false;
                    }
                }
                catch
                {
                }
            }
            if (txtBarCode2.Text != string.Empty)
            {
                List<T_Item> returned = db.SelectBarcodNoByReturnNoList(txtBarCode2.Text);
                try
                {
                    if (returned.Count > 1)
                    {
                        MessageBox.Show((LangArEn == 0) ? "الرقم الذي قمت بإدخاله موجود من قبل - مكرر .. يرجى المحاولة مرة اخرى" : "The number you have entered already exists - bis .. Please try again.", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        txtBarCode2.Text = string.Empty;
                        txtBarCode2.Focus();
                        return false;
                    }
                }
                catch
                {
                }
            }
            if (txtBarCode3.Text != string.Empty)
            {
                List<T_Item> returned = db.SelectBarcodNoByReturnNoList(txtBarCode3.Text);
                try
                {
                    if (returned.Count > 1)
                    {
                        MessageBox.Show((LangArEn == 0) ? "الرقم الذي قمت بإدخاله موجود من قبل - مكرر .. يرجى المحاولة مرة اخرى" : "The number you have entered already exists - bis .. Please try again.", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        txtBarCode3.Text = string.Empty;
                        txtBarCode3.Focus();
                        return false;
                    }
                }
                catch
                {
                }
            }
            if (txtBarCode4.Text != string.Empty)
            {
                List<T_Item> returned = db.SelectBarcodNoByReturnNoList(txtBarCode4.Text);
                try
                {
                    if (returned.Count > 1)
                    {
                        MessageBox.Show((LangArEn == 0) ? "الرقم الذي قمت بإدخاله موجود من قبل - مكرر .. يرجى المحاولة مرة اخرى" : "The number you have entered already exists - bis .. Please try again.", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        txtBarCode4.Text = string.Empty;
                        txtBarCode4.Focus();
                        return false;
                    }
                }
                catch
                {
                }
            }
            if (txtBarCode5.Text != string.Empty)
            {
                List<T_Item> returned = db.SelectBarcodNoByReturnNoList(txtBarCode5.Text);
                try
                {
                    if (returned.Count > 1)
                    {
                        MessageBox.Show((LangArEn == 0) ? "الرقم الذي قمت بإدخاله موجود من قبل - مكرر .. يرجى المحاولة مرة اخرى" : "The number you have entered already exists - bis .. Please try again.", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        txtBarCode5.Text = string.Empty;
                        txtBarCode5.Focus();
                        return false;
                    }
                }
                catch
                {
                }
            }
            return true;
        }
        private void Button_Save_Click(object sender, EventArgs e)
        {
            try
            {
                textBox_ID.Focus();
                if (!Button_Save.Enabled || !ValidData())
                {
                    return;
                }
                try
                {
                    if (DataThis.T_ItemDets.Count > 0)
                    {
                        for (int i = 0; i < LData_This.Count; i++)
                        {
                            db.T_ItemDets.DeleteOnSubmit(LData_This[i]);
                            db.SubmitChanges();
                        }
                    }
                }
                catch
                {
                }
                if (State == FormState.New)
                {
                    textBox_ID.TextChanged -= textBox_ID_TextChanged;
                    if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 0))
                    {
                        T_Item itemSer = new T_Item();
                        double itemNo = 0.0;
                        string _symbol = string.Empty;
                        try
                        {
                            _symbol = db.StockCatID(int.Parse(combobox_ItmeGroup.SelectedValue.ToString())).CAT_Symbol.Trim();
                        }
                        catch
                        {
                            _symbol = string.Empty;
                        }
                        if (pkeys.Count == 0)
                        {
                            if (_symbol == string.Empty)
                            {
                                textBox_ID.Text = VarGeneral.Settings_Sys.AutoItm.ToString();
                            }
                            else
                            {
                                textBox_ID.Text = _symbol + VarGeneral.Settings_Sys.AutoItm;
                            }
                        }
                        else if (_symbol == string.Empty)
                        {
                            for (int i = 0; i < pkeys.Count; i++)
                            {
                                itemSer.Itm_No = PKeys[i];
                                if (Program.sIsNumeric(itemSer.Itm_No) && double.Parse(itemSer.Itm_No) > itemNo)
                                {
                                    itemNo = double.Parse(itemSer.Itm_No);
                                }
                            }
                            textBox_ID.Text = (itemNo + 1.0).ToString();
                        }
                        else
                        {
                            List<string> newPkeys = pkeys.Where((string g) => g.StartsWith(_symbol)).ToList();
                            if (newPkeys.Count == 0)
                            {
                                textBox_ID.Text = _symbol + VarGeneral.Settings_Sys.AutoItm;
                            }
                            else
                            {
                                for (int i = 0; i < newPkeys.Count; i++)
                                {
                                    itemSer.Itm_No = newPkeys[i].Replace(_symbol, string.Empty).Trim();
                                    if (Program.sIsNumeric(itemSer.Itm_No) && double.Parse(itemSer.Itm_No) > itemNo)
                                    {
                                        itemNo = double.Parse(itemSer.Itm_No);
                                    }
                                }
                                textBox_ID.Text = _symbol + (itemNo + 1.0);
                            }
                        }
                        combobox_ItmeGroup.Focus();
                    }
                    else
                    {
                        textBox_ID.Focus();
                    }
                    textBox_ID.TextChanged += textBox_ID_TextChanged;
                    GetData();
                    try
                    {
                        db.T_Items.InsertOnSubmit(data_this);
                        db.SubmitChanges();
                    }
                    catch (SqlException ex)
                    {
                        int max = 0;
                        max = db.MaxItemNo;
                        if (ex.Number == 2627)
                        {
                            MessageBox.Show("رقم الصنف مستخدم من قبل.\n سيتم الحفظ برقم جديد [" + max + "]", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            textBox_ID.Text = string.Concat(max);
                            data_this.Itm_No = max.ToString();
                            Button_Save_Click(sender, e);
                        }
                    }
                }
                else if (State == FormState.Edit)
                {
                    GetData();
                    db.Log = VarGeneral.DebugLog;
                    db.SubmitChanges(ConflictMode.ContinueOnConflict);
                }
                if (data_this.ItmTyp == 2)
                {
                    saveDet();
                }
                State = FormState.Saved;
                RefreshPKeys();
                TextBox_Index.TextBox.Text = string.Concat(PKeys.IndexOf(data_this.Itm_No ?? string.Empty) + 1);
                SetReadOnly = true;
                dbInstance = null;
                textBox_ID_TextChanged(sender, e);
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Save:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void saveDet()
        {
            if (string.IsNullOrEmpty(data_this.Itm_No))
            {
                return;
            }
            string[] Items;
            int ii;
            for (int i = 1; i < FlxInv.Rows.Count; i++)
            {
                FlxInv.Row = i;
                try
                {
                    if (string.IsNullOrEmpty(FlxInv.GetData(i, 1).ToString() ?? string.Empty))
                    {
                        continue;
                    }
                    T_ItemDet newData = new T_ItemDet();
                    newData.ItmNo = data_this.Itm_No;
                    newData.GItmNo = FlxInv.GetData(i, 1).ToString();
                    newData.Qty = double.Parse(FlxInv.GetData(i, 7).ToString());
                    newData.Price = double.Parse(FlxInv.GetData(i, 8).ToString());
                    newData.StoreNo = int.Parse(FlxInv.GetData(i, 6).ToString());
                    Items = FlxInv.Cols[3].ComboList.Split('|');
                    ii = 0;
                    while (true)
                    {
                        if (ii >= Items.Length)
                        {
                            break;
                        }
                        if (Items[ii] == FlxInv.GetData(i, 3).ToString())
                        {
                            List<T_Unit> vUnt = db.T_Units.Where((T_Unit t) => t.Arb_Des == Items[ii]).ToList();
                            if (vUnt.Count > 0)
                            {
                                newData.Unit_ = vUnt.First().Unit_ID;
                                T_Item q = db.StockItem(newData.GItmNo);
                                if (q.Unit2 == vUnt.First().Unit_ID)
                                {
                                    newData.Unit_ = 2;
                                }
                                else if (q.Unit3 == vUnt.First().Unit_ID)
                                {
                                    newData.Unit_ = 3;
                                }
                                else if (q.Unit4 == vUnt.First().Unit_ID)
                                {
                                    newData.Unit_ = 4;
                                }
                                else if (q.Unit5 == vUnt.First().Unit_ID)
                                {
                                    newData.Unit_ = 5;
                                }
                                else
                                {
                                    newData.Unit_ = 1;
                                }
                            }
                            else
                            {
                                newData.Unit_ = 1;
                            }
                        }
                        ii++;
                    }
                    db.T_ItemDets.InsertOnSubmit(newData);
                    db.SubmitChanges();
                }
                catch
                {
                }
            }
        }
        private void Button_Delete_Click(object sender, EventArgs e)
        {
            if ((!Button_Delete.Enabled || !Button_Delete.Visible || State != 0) && !button_DeleteFromSystem.Visible)
            {
                ifOkDelete = false;
                return;
            }
            string Code = string.Empty;
            Code = textBox_ID.Text;
            if (Code == string.Empty)
            {
                ifOkDelete = false;
                return;
            }
            if (button_DeleteFromSystem.Visible)
            {
                if (MessageBox.Show("هل أنت متاكد من حذف السجل [" + Code + "]؟ \n Are you sure that you want to delete the record [" + Code + "]?", VarGeneral.ProdectNam, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ifOkDelete = true;
                }
                else
                {
                    ifOkDelete = false;
                }
            }
            if (data_this == null || string.IsNullOrEmpty(data_this.Itm_No) || !ifOkDelete)
            {
                return;
            }
            bool returned = db.StockCheckInvDet(DataThis.Itm_No);
            if (!returned)
            {
                returned = db.StockCheckInvOffer(DataThis.Itm_No);
            }
            if (returned)
            {
                MessageBox.Show((LangArEn == 0) ? "لايمكن حذف الصنف .. لانه مرتبط باحد الفواتير" : "You can not delete Item .. because it is tied to a Bills", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            List<T_StoreMnd> vStorMnd = db.T_StoreMnds.Where((T_StoreMnd t) => t.itmNo == data_this.Itm_No).ToList();
            if (vStorMnd.Count > 0)
            {
                MessageBox.Show((LangArEn == 0) ? "لايمكن حذف المستودع .. لانه مرتبط باحد فواتير صرف البضاعة" : "You can not delete the warehouse .. because it is tied to Item", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            data_this = db.StockItem(DataThis.Itm_No);
            if (data_this.ItmTyp == 2)
            {
                Stock_DataDataContext dbc = new Stock_DataDataContext(VarGeneral.BranchCS);
                LData_This = dbc.T_ItemDets.Where((T_ItemDet t) => t.ItmNo == data_this.Itm_No).ToList();
                for (int i = 0; i < LData_This.Count; i++)
                {
                    if (dbc.StockCheckInvDet(LData_This[i].GItmNo))
                    {
                        MessageBox.Show((LangArEn == 0) ? "لايمكن حذف الصنف .. لانه يحوي\u064b صنف عليه حركة" : "You can not delete Item .. because it Contains item is tied to a Bills", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        return;
                    }
                    dbc.T_ItemDets.DeleteOnSubmit(LData_This[i]);
                    dbc.SubmitChanges();
                }
            }
            else if (db.StockItemDet(DataThis.Itm_No))
            {
                MessageBox.Show((LangArEn == 0) ? "لايمكن حذف الصنف .. لانه مرتبط بصنف تجميعي " : "You can not delete Item .. because it is tied to a Bills", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            try
            {
                try
                {
                    db.T_EditItemPrices.DeleteAllOnSubmit(data_this.T_EditItemPrices);
                    db.SubmitChanges();
                }
                catch
                {
                }
                try
                {
                    db.T_ItemSerials.DeleteAllOnSubmit(data_this.T_ItemSerials);
                    db.SubmitChanges();
                }
                catch
                {
                }
                List<T_STKSQTY> StkQty_ = (from t in db.T_STKSQTies
                                           where t.itmNo == data_this.Itm_No
                                           where Math.Abs(t.stkQty.Value) > 0.0
                                           select t).ToList();
                if (StkQty_.Count > 0)
                {
                    return;
                }
                db.ExecuteCommand("DELETE FROM [dbo].[T_STKSQTY] WHERE itmNo = '" + data_this.Itm_No + "' and stkQty = 0");
                List<T_QTYEXP> QtyExp = (from t in db.T_QTYEXPs
                                         where t.itmNo == data_this.Itm_No
                                         where Math.Abs(t.stkQty.Value) > 0.0
                                         select t).ToList();
                if (QtyExp.Count > 0)
                {
                    return;
                }
                db.ExecuteCommand("DELETE FROM [dbo].[T_QTYEXP] WHERE itmNo = '" + data_this.Itm_No + "' and stkQty = 0");
                List<T_StoreMnd> StorMnd_ = (from t in db.T_StoreMnds
                                             where t.itmNo == data_this.Itm_No
                                             where Math.Abs(t.stkQty.Value) > 0.0
                                             select t).ToList();
                if (StorMnd_.Count > 0)
                {
                    return;
                }
                db.ExecuteCommand("DELETE FROM [dbo].[T_StoreMnd] WHERE itmNo = '" + data_this.Itm_No + "' and stkQty = 0");
                db.T_Items.DeleteOnSubmit(DataThis);
                db.SubmitChanges();
            }
            catch (SqlException)
            {
                data_this = db.StockItem(DataThis.Itm_No);
                return;
            }
            catch (Exception)
            {
                data_this = db.StockItem(DataThis.Itm_No);
                return;
            }
            Clear();
            RefreshPKeys();
            textBox_ID.Text = PKeys.LastOrDefault();
        }
        private void Button_Close_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void ADD_Controls()
        {
            try
            {
                controls = new List<Control>();
                controls.Add(textbox_Arb_Des);
                codeControl = textBox_ID;
                controls.Add(doubleInput_DefPack);
                controls.Add(txtCustName);
                controls.Add(txtCustNo);
                controls.Add(textBox_SerialKey);
                controls.Add(button_AddNewCat);
                controls.Add(c1FlexGrid_Items);
                controls.Add(textbox_DateNo);
                controls.Add(textbox_Eng_Des);
                controls.Add(textBox_ID);
                controls.Add(textbox_Supreme);
                controls.Add(combobox_DateTyp);
                controls.Add(combobox_ItmeGroup);
                controls.Add(comboBox_DefPack);
                controls.Add(combobox_Unit1);
                controls.Add(combobox_Unit2);
                controls.Add(combobox_Unit3);
                controls.Add(combobox_Unit4);
                controls.Add(combobox_Unit5);
                controls.Add(pictureBox_PicItem);
                controls.Add(button_EnterImg);
                controls.Add(textbox_Legates);
                controls.Add(textbox_VIP);
                controls.Add(textbox_Sentence);
                controls.Add(textbox_Sectorial);
                controls.Add(textbox_Distributors);
                controls.Add(textbox_MaxQty);
                controls.Add(checkBoxX_BarcodeBalance);
                controls.Add(checkBoxX_Points);
                controls.Add(checkBoxX_InvPayment);
                controls.Add(checkBoxX_InvPaymentReturn);
                controls.Add(checkBoxX_InvSale);
                controls.Add(checkBoxX_ReturnInvSale);
                controls.Add(textBox_CommItm);
                controls.Add(textBox_DisItem);
                controls.Add(textBox_TaxSales);
                controls.Add(textBox_TaxPurchase);
                controls.Add(checkBoxX_InvEnter);
                controls.Add(checkBoxX_InvOut);
                controls.Add(txtFiled1);
                controls.Add(txtFiled2);
                controls.Add(txtFiled3);
                controls.Add(txtFiled4);
                controls.Add(txtFiled5);
                controls.Add(txtFiled6);
            }
            catch (SqlException)
            {
            }
        }
        private void textBox_ID_No_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (e.KeyChar != '\b'))
            {
                e.Handled = true;
            }
        }
        private void textBox_ID_KeyPress(object sender, KeyPressEventArgs e)
        {
        }
        public void Button_First_Click(object sender, EventArgs e)
        {
            if (ContinueIfEditOrNew())
            {
                TextBox_Index.TextBox.Text = string.Concat(1);
                UpdateVcr();
                UpdateVcr();
                textBox_ID.Focus();
            }
        }
        public void Button_Prev_Click(object sender, EventArgs e)
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
                textBox_ID.Focus();
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
                textBox_ID.Focus();
            }
        }
        public void Button_Last_Click(object sender, EventArgs e)
        {
            if (ContinueIfEditOrNew())
            {
                TextBox_Index.TextBox.Text = Label_Count.Text;
                UpdateVcr();
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
        private void textbox_Pack1_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (int.Parse(combobox_Unit1.SelectedValue.ToString()) < 1)
                {
                    e.Handled = true;
                }
                else if ((!char.IsNumber(e.KeyChar) & (e.KeyChar != '\b')) && e.KeyChar != '.')
                {
                    e.Handled = true;
                }
            }
            catch
            {
                e.Handled = true;
            }
        }
        private void textbox_Pack2_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (int.Parse(combobox_Unit2.SelectedValue.ToString()) < 1)
                {
                    e.Handled = true;
                }
                else if ((!char.IsNumber(e.KeyChar) & (e.KeyChar != '\b')) && e.KeyChar != '.')
                {
                    e.Handled = true;
                }
            }
            catch
            {
                e.Handled = true;
            }
        }
        private void textbox_Pack3_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (int.Parse(combobox_Unit3.SelectedValue.ToString()) < 1)
                {
                    e.Handled = true;
                }
                else if ((!char.IsNumber(e.KeyChar) & (e.KeyChar != '\b')) && e.KeyChar != '.')
                {
                    e.Handled = true;
                }
            }
            catch
            {
                e.Handled = true;
            }
        }
        private void textbox_Pack4_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (int.Parse(combobox_Unit4.SelectedValue.ToString()) < 1)
                {
                    e.Handled = true;
                }
                else if ((!char.IsNumber(e.KeyChar) & (e.KeyChar != '\b')) && e.KeyChar != '.')
                {
                    e.Handled = true;
                }
            }
            catch
            {
                e.Handled = true;
            }
        }
        private void textbox_Pack5_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (int.Parse(combobox_Unit5.SelectedValue.ToString()) < 1)
                {
                    e.Handled = true;
                }
                else if ((!char.IsNumber(e.KeyChar) & (e.KeyChar != '\b')) && e.KeyChar != '.')
                {
                    e.Handled = true;
                }
            }
            catch
            {
                e.Handled = true;
            }
        }
        private void button_EnterImg_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif|TIFF Files (*.tiff)|*.tiff|BMP Files (*.bmp)|*.bmp";
                try
                {
                    if (VarGeneral.gUserName == "runsetting")
                    {
                        openFileDialog1.InitialDirectory = "::{20D04FE0-3AEA-1069-A2D8-08002B30309D}";
                    }
                }
                catch
                {
                }
                openFileDialog1.ShowDialog();
                string mypic_path = openFileDialog1.FileName;
                if (File.Exists(mypic_path))
                {
                    pictureBox_PicItem.Image = Image.FromFile(mypic_path);
                    Bitmap OriginalBM = new Bitmap(newSize: new Size(pictureBox_PicItem.Size.Width, pictureBox_PicItem.Size.Height), original: pictureBox_PicItem.Image);
                    pictureBox_PicItem.Image = OriginalBM;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void txtBarCode2_Leave(object sender, EventArgs e)
        {
            if (txtBarCode2.Text != string.Empty && State != 0)
            {
                T_Item returned = db.SelectBarcodNoByReturnNo(txtBarCode2.Text);
                if (returned != null && returned.Itm_ID != 0 && returned.Itm_No != textBox_ID.Text)
                {
                    MessageBox.Show((LangArEn == 0) ? "الرقم الذي قمت بإدخاله موجود من قبل - مكرر .. يرجى المحاولة مرة اخرى" : "The number you have entered already exists - bis .. Please try again.", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    txtBarCode2.Text = string.Empty;
                    txtBarCode2.Focus();
                }
            }
        }
        private void txtBarCode3_Leave(object sender, EventArgs e)
        {
            if (txtBarCode3.Text != string.Empty && State != 0)
            {
                T_Item returned = db.SelectBarcodNoByReturnNo(txtBarCode3.Text);
                if (returned != null && returned.Itm_ID != 0 && returned.Itm_No != textBox_ID.Text)
                {
                    MessageBox.Show((LangArEn == 0) ? "الرقم الذي قمت بإدخاله موجود من قبل - مكرر .. يرجى المحاولة مرة اخرى" : "The number you have entered already exists - bis .. Please try again.", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    txtBarCode3.Text = string.Empty;
                    txtBarCode3.Focus();
                }
            }
        }
        private void txtBarCode4_Leave(object sender, EventArgs e)
        {
            if (txtBarCode4.Text != string.Empty && State != 0)
            {
                T_Item returned = db.SelectBarcodNoByReturnNo(txtBarCode4.Text);
                if (returned != null && returned.Itm_ID != 0 && returned.Itm_No != textBox_ID.Text)
                {
                    MessageBox.Show((LangArEn == 0) ? "الرقم الذي قمت بإدخاله موجود من قبل - مكرر .. يرجى المحاولة مرة اخرى" : "The number you have entered already exists - bis .. Please try again.", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    txtBarCode4.Text = string.Empty;
                    txtBarCode4.Focus();
                }
            }
        }
        private void txtBarCode5_Leave(object sender, EventArgs e)
        {
            if (txtBarCode5.Text != string.Empty && State != 0)
            {
                T_Item returned = db.SelectBarcodNoByReturnNo(txtBarCode5.Text);
                if (returned != null && returned.Itm_ID != 0 && returned.Itm_No != textBox_ID.Text)
                {
                    MessageBox.Show((LangArEn == 0) ? "الرقم الذي قمت بإدخاله موجود من قبل - مكرر .. يرجى المحاولة مرة اخرى" : "The number you have entered already exists - bis .. Please try again.", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    txtBarCode5.Text = string.Empty;
                    txtBarCode5.Focus();
                }
            }
        }
        private void textbox_Arb_Des_Enter(object sender, EventArgs e)
        {
            SSSLanguage.Language.Switch("AR");
        }
        private void textbox_Eng_Des_Enter(object sender, EventArgs e)
        {
            SSSLanguage.Language.Switch("EN");
        }
        private void button_AddNewCat_Click(object sender, EventArgs e)
        {
            FrmItmGroup frm = new FrmItmGroup();
            frm.Tag = LangArEn;
            string vList = string.Empty;
            if (combobox_ItmeGroup.SelectedIndex != -1)
            {
                vList = combobox_ItmeGroup.SelectedValue.ToString();
            }
            frm.TopMost = true;
            frm.ShowDialog();
            using (new Stock_DataDataContext(VarGeneral.BranchCS))
            {
                List<T_CATEGORY> listAccCat = new List<T_CATEGORY>(db.T_CATEGORies.Select((T_CATEGORY item) => item).ToList());
                combobox_ItmeGroup.DataSource = null;
                combobox_ItmeGroup.DataSource = listAccCat;
                combobox_ItmeGroup.DisplayMember = ((LangArEn == 0) ? "Arb_Des" : "Eng_Des");
                combobox_ItmeGroup.ValueMember = "CAT_No";
                if (vList != string.Empty)
                {
                    for (int i = 0; i < combobox_ItmeGroup.Items.Count; i++)
                    {
                        combobox_ItmeGroup.SelectedIndex = i;
                        if (combobox_ItmeGroup.SelectedValue.ToString() == vList)
                        {
                            break;
                        }
                    }
                }
                else
                {
                    combobox_ItmeGroup.SelectedIndex = -1;
                }
            }
        }
        private void FrmItems_KeyDown(object sender, KeyEventArgs e)
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
            else if (e.KeyCode == Keys.F5 && Button_PrintTable.Enabled && Button_PrintTable.Visible && !expandableSplitter1.Expanded)
            {
                Button_Print_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F10 && Button_ExportTable2.Enabled && Button_ExportTable2.Visible && !expandableSplitter1.Expanded)
            {
                Button_ExportTable2_Click(sender, e);
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
        }
        private void FrmItems_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                SendKeys.Send("{Tab}");
            }
        }
        private void comboboxItems_Unit1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                combobox_Unit1.SelectedIndex = comboboxItems_Unit1.SelectedIndex;
                UnitTabs();
            }
            catch
            {
            }
            try
            {
                labelItem11.Text = ((LangArEn == 0) ? "التعبئة بـ = " : "Fill = ") + combobox_Unit1.Text;
                labelItem16.Text = ((LangArEn == 0) ? "التعبئة بـ = " : "Fill = ") + combobox_Unit1.Text;
                labelItem21.Text = ((LangArEn == 0) ? "التعبئة بـ = " : "Fill = ") + combobox_Unit1.Text;
                labelItem26.Text = ((LangArEn == 0) ? "التعبئة بـ = " : "Fill = ") + combobox_Unit1.Text;
            }
            catch
            {
                labelItem11.Text = ((LangArEn == 0) ? "التعبئة" : "Fill");
                labelItem16.Text = ((LangArEn == 0) ? "التعبئة" : "Fill");
                labelItem21.Text = ((LangArEn == 0) ? "التعبئة" : "Fill");
                labelItem26.Text = ((LangArEn == 0) ? "التعبئة" : "Fill");
            }
        }
        private void comboboxItems_Unit2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                combobox_Unit2.SelectedIndex = comboboxItems_Unit2.SelectedIndex;
                UnitTabs();
            }
            catch
            {
            }
        }
        private void comboboxItems_Unit3_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                combobox_Unit3.SelectedIndex = comboboxItems_Unit3.SelectedIndex;
                UnitTabs();
            }
            catch
            {
            }
        }
        private void comboboxItems_Unit4_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                combobox_Unit4.SelectedIndex = comboboxItems_Unit4.SelectedIndex;
                UnitTabs();
            }
            catch
            {
            }
        }
        private void comboboxItems_Unit5_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                combobox_Unit5.SelectedIndex = comboboxItems_Unit5.SelectedIndex;
                UnitTabs();
            }
            catch
            {
            }
        }
        private void c1FlexGrid_Items_AfterEdit(object sender, RowColEventArgs e)
        {
            try
            {
                Button_Edit_Click(sender, e);
                if (e.Col == 6)
                {
                    if ((bool)c1FlexGrid_Items.GetData(e.Row, e.Col))
                    {
                        combobox_DateTyp.Items.Clear();
                        textbox_DateNo.Enabled = true;
                        combobox_DateTyp.Enabled = true;
                        combobox_DateTyp.Items.Add("يوم");
                        combobox_DateTyp.Items.Add("شهر");
                        combobox_DateTyp.Items.Add("سنة");
                        combobox_DateTyp.SelectedIndex = 0;
                    }
                    else
                    {
                        textbox_DateNo.Enabled = false;
                        textbox_DateNo.Value = 0;
                        combobox_DateTyp.Enabled = false;
                        combobox_DateTyp.SelectedIndex = -1;
                    }
                }
            }
            catch
            {
                textbox_DateNo.Enabled = false;
                textbox_DateNo.Value = 0;
                combobox_DateTyp.Enabled = false;
                combobox_DateTyp.SelectedIndex = -1;
            }
        }
        private void button_SrchItemGroup_Click(object sender, EventArgs e)
        {
            try
            {
                Dir_ButSearch.Add("CAT_No", new ColumnDictinary("الرمـــز", "CATEGORY No", ifDefault: true, string.Empty));
                Dir_ButSearch.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, string.Empty));
                Dir_ButSearch.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, string.Empty));
                FrmSearch frm = new FrmSearch();
                frm.Tag = LangArEn;
                frm.Tag = LangArEn;
                ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = Dir_ButSearch;
                foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
                {
                    frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
                }
                VarGeneral.SFrmTyp = "T_CATEGORY";
                frm.TopMost = true;
                frm.ShowDialog();
                if (frm.SerachNo != string.Empty)
                {
                    combobox_ItmeGroup.SelectedValue = db.StockCat(frm.SerachNo.ToString()).CAT_ID;
                    Button_Edit_Click(sender, e);
                }
                Dir_ButSearch.Clear();
            }
            catch
            {
            }
        }
        private void CheckedCahngState()
        {
            if (radiobutton_RButDef1.Checked)
            {
                radiobutton_RButDef1.Checked = true;
                radiobutton_RButDef2.Checked = false;
                radiobutton_RButDef3.Checked = false;
                radiobutton_RButDef4.Checked = false;
                radiobutton_RButDef5.Checked = false;
            }
            else if (radiobutton_RButDef2.Checked)
            {
                radiobutton_RButDef1.Checked = false;
                radiobutton_RButDef2.Checked = true;
                radiobutton_RButDef3.Checked = false;
                radiobutton_RButDef4.Checked = false;
                radiobutton_RButDef5.Checked = false;
            }
            else if (radiobutton_RButDef3.Checked)
            {
                radiobutton_RButDef1.Checked = false;
                radiobutton_RButDef2.Checked = false;
                radiobutton_RButDef3.Checked = true;
                radiobutton_RButDef4.Checked = false;
                radiobutton_RButDef5.Checked = false;
            }
            else if (radiobutton_RButDef4.Checked)
            {
                radiobutton_RButDef1.Checked = false;
                radiobutton_RButDef2.Checked = false;
                radiobutton_RButDef3.Checked = false;
                radiobutton_RButDef4.Checked = true;
                radiobutton_RButDef5.Checked = false;
            }
            else if (radiobutton_RButDef5.Checked)
            {
                radiobutton_RButDef1.Checked = false;
                radiobutton_RButDef2.Checked = false;
                radiobutton_RButDef3.Checked = false;
                radiobutton_RButDef4.Checked = false;
                radiobutton_RButDef5.Checked = true;
            }
        }
        private void button_ClearPic_Click(object sender, EventArgs e)
        {
            try
            {
                Button_Edit_Click(sender, e);
                pictureBox_PicItem.Image = null;
            }
            catch
            {
            }
        }
        private void radiobutton_RButDef1_CheckedChanged(object sender, CheckBoxChangeEventArgs e)
        {
            if (e.NewChecked.Checked)
            {
                radiobutton_RButDef1.Checked = true;
                radiobutton_RButDef2.Checked = false;
                radiobutton_RButDef3.Checked = false;
                radiobutton_RButDef4.Checked = false;
                radiobutton_RButDef5.Checked = false;
            }
        }
        private void radiobutton_RButDef2_CheckedChanged(object sender, CheckBoxChangeEventArgs e)
        {
            if (e.NewChecked.Checked)
            {
                radiobutton_RButDef1.Checked = false;
                radiobutton_RButDef2.Checked = true;
                radiobutton_RButDef3.Checked = false;
                radiobutton_RButDef4.Checked = false;
                radiobutton_RButDef5.Checked = false;
            }
        }
        private void radiobutton_RButDef3_CheckedChanged(object sender, CheckBoxChangeEventArgs e)
        {
            if (e.NewChecked.Checked)
            {
                radiobutton_RButDef1.Checked = false;
                radiobutton_RButDef2.Checked = false;
                radiobutton_RButDef3.Checked = true;
                radiobutton_RButDef4.Checked = false;
                radiobutton_RButDef5.Checked = false;
            }
        }
        private void radiobutton_RButDef4_CheckedChanged(object sender, CheckBoxChangeEventArgs e)
        {
            if (e.NewChecked.Checked)
            {
                radiobutton_RButDef1.Checked = false;
                radiobutton_RButDef2.Checked = false;
                radiobutton_RButDef3.Checked = false;
                radiobutton_RButDef4.Checked = true;
                radiobutton_RButDef5.Checked = false;
            }
        }
        private void radiobutton_RButDef5_CheckedChanged(object sender, CheckBoxChangeEventArgs e)
        {
            if (e.NewChecked.Checked)
            {
                radiobutton_RButDef1.Checked = false;
                radiobutton_RButDef2.Checked = false;
                radiobutton_RButDef3.Checked = false;
                radiobutton_RButDef4.Checked = false;
                radiobutton_RButDef5.Checked = true;
            }
        }
        private void UnitTabs()
        {
            if (comboboxItems_Unit1.SelectedIndex > 0)
            {
                if (State == FormState.New && !textbox_SelPri1.Visible)
                {
                    textbox_SelPri1.Text = "1";
                }
                comboboxItems_Unit2.Enabled = true;
                radiobutton_RButDef2.Enabled = true;
            }
            else
            {
                if (State == FormState.New)
                {
                    textbox_SelPri1.Text = string.Empty;
                }
                comboboxItems_Unit2.Enabled = false;
                comboboxItems_Unit2.SelectedIndex = -1;
                textbox_Cost2.Text = string.Empty;
                textbox_Pack2.Text = string.Empty;
                textbox_Qty2.Text = string.Empty;
                textbox_SelPri2.Text = string.Empty;
                txtBarCode2.Text = string.Empty;
                radiobutton_RButDef2.Enabled = false;
            }
            if (comboboxItems_Unit2.SelectedIndex > 0)
            {
                if (State == FormState.New && !textbox_SelPri2.Visible)
                {
                    textbox_SelPri2.Text = "1";
                }
                comboboxItems_Unit3.Enabled = true;
                radiobutton_RButDef3.Enabled = true;
            }
            else
            {
                if (State == FormState.New)
                {
                    textbox_SelPri2.Text = string.Empty;
                }
                comboboxItems_Unit3.Enabled = false;
                comboboxItems_Unit3.SelectedIndex = -1;
                textbox_Cost3.Text = string.Empty;
                textbox_Pack3.Text = string.Empty;
                textbox_Qty3.Text = string.Empty;
                textbox_SelPri3.Text = string.Empty;
                txtBarCode3.Text = string.Empty;
                radiobutton_RButDef3.Enabled = false;
            }
            if (comboboxItems_Unit3.SelectedIndex > 0)
            {
                if (State == FormState.New && !textbox_SelPri3.Visible)
                {
                    textbox_SelPri3.Text = "1";
                }
                comboboxItems_Unit4.Enabled = true;
                radiobutton_RButDef4.Enabled = true;
            }
            else
            {
                if (State == FormState.New)
                {
                    textbox_SelPri3.Text = string.Empty;
                }
                comboboxItems_Unit4.Enabled = false;
                comboboxItems_Unit4.SelectedIndex = -1;
                textbox_Cost4.Text = string.Empty;
                textbox_Pack4.Text = string.Empty;
                textbox_Qty4.Text = string.Empty;
                textbox_SelPri4.Text = string.Empty;
                txtBarCode4.Text = string.Empty;
                radiobutton_RButDef4.Enabled = false;
            }
            if (comboboxItems_Unit4.SelectedIndex > 0)
            {
                if (State == FormState.New && !textbox_SelPri4.Visible)
                {
                    textbox_SelPri4.Text = "1";
                }
                comboboxItems_Unit5.Enabled = true;
                radiobutton_RButDef5.Enabled = true;
            }
            else
            {
                if (State == FormState.New)
                {
                    textbox_SelPri4.Text = string.Empty;
                }
                comboboxItems_Unit5.Enabled = false;
                comboboxItems_Unit5.SelectedIndex = -1;
                textbox_Cost5.Text = string.Empty;
                textbox_Pack5.Text = string.Empty;
                textbox_Qty5.Text = string.Empty;
                textbox_SelPri5.Text = string.Empty;
                txtBarCode5.Text = string.Empty;
                radiobutton_RButDef5.Enabled = false;
                if (Program.iscarversion()) setdefaultpack();
            }
            if (comboboxItems_Unit5.SelectedIndex > 0)
            {
                if (State == FormState.New && !textbox_SelPri5.Visible)
                {
                    textbox_SelPri5.Text = "1";
                }
            }
            else if (State == FormState.New)
            {
                textbox_SelPri5.Text = string.Empty;
            }
            if (File.Exists(Application.StartupPath + "\\Script\\SecriptMaintenanceCars.dll"))
            {
                comboboxItems_Unit1.Enabled = false;
                comboboxItems_Unit2.Enabled = false;
                comboboxItems_Unit3.Enabled = false;
                comboboxItems_Unit4.Enabled = false;
                comboboxItems_Unit5.Enabled = false;
            }
        }
        private void expandableSplitter1_Click(object sender, EventArgs e)
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
        private void TextBox_Search_InputTextChanged(object sender)
        {
            Fill_DGV_Main();
        }
        private void TextBox_Search_ButtonCustomClick(object sender, EventArgs e)
        {
            textBox_search.Text = string.Empty;
        }
        private void ToolStripMenuItem_Det_Click(object sender, EventArgs e)
        {
            int rowIndex = Convert.ToInt32(DGV_Main.PrimaryGrid.Tag);
            TextBox_Index.TextBox.Text = string.Concat(rowIndex + 1);
            expandableSplitter1.Expanded = true;
            ViewDetails_Click(sender, e);
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
                    //return;
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
        public void Fill_DGV_Main()
        {
            DGV_Main.PrimaryGrid.VirtualMode = false;
            List<T_Item> list = db.FillItem_2(textBox_search.TextBox.Text).ToList();
            try
            {
                list = list.OrderBy((T_Item c) => int.Parse(c.Itm_No)).ToList();
            }
            catch
            {
            }
            if (DGV_Main.PrimaryGrid.Columns.Count == 0)
            {
                foreach (KeyValuePair<string, ColumnDictinary> item in columns_Names_visible)
                {
                    if (item.Key != "Arb_Des_Cat" && item.Key != "Eng_Des_Cat")
                    {
                        DGV_Main.PrimaryGrid.Columns.Add(new GridColumn(item.Key));
                    }
                }
            }
            FillHDGV(list);
        }
        public void FillHDGV(IEnumerable<T_Item> new_data_enum)
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
                    DGV_Main.PrimaryGrid.Columns[i].MinimumWidth = 50;
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
            DGV_Main.PrimaryGrid.DataMember = "T_Item";
            DGV_Main.PrimaryGrid.DefaultVisualStyles.AlternateRowCellStyles.Default.Background.Color2 = Color.LightBlue;
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
                DGV_Main.PrimaryGrid.Columns[name].MinimumWidth = 90;
                DGV_Main.PrimaryGrid.Columns[name].HeaderText = columns_Names_visible[name].AText;
            }
            DGV_Main.PrimaryGrid.Columns[name].Visible = (sender as ToolStripMenuItem).Checked;
        }
        private void DGV_Main_DataBindingComplete(object sender, GridDataBindingCompleteEventArgs e)
        {
            GridPanel panel = e.GridPanel;
            string dataMember = panel.DataMember;
            if (dataMember != null && dataMember == "T_Item")
            {
                PropBranchPanel(panel);
            }
        }
        private void PropBranchPanel(GridPanel panel)
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
            panel.Columns["Itm_No"].Width = 120;
            panel.Columns["Itm_No"].Visible = columns_Names_visible["Itm_No"].IfDefault;
            panel.Columns["Arb_Des"].Width = 180;
            panel.Columns["Arb_Des"].Visible = columns_Names_visible["Arb_Des"].IfDefault;
            panel.Columns["Eng_Des"].Width = 180;
            panel.Columns["Eng_Des"].Visible = columns_Names_visible["Eng_Des"].IfDefault;
            if (!File.Exists(Application.StartupPath + "\\Script\\SecriptInvitationCards.dll"))
            {
                panel.Columns["Itm_ID"].Width = 120;
                panel.Columns["Itm_ID"].Visible = columns_Names_visible["Itm_ID"].IfDefault;
                panel.Columns["AvrageCost"].Width = 120;
                panel.Columns["AvrageCost"].Visible = columns_Names_visible["AvrageCost"].IfDefault;
                panel.Columns["UntPri1"].Width = 120;
                panel.Columns["UntPri1"].Visible = columns_Names_visible["UntPri1"].IfDefault;
            }
            panel.Columns["BarCod1"].Width = 150;
            panel.Columns["BarCod1"].Visible = columns_Names_visible["BarCod1"].IfDefault;
            panel.Columns["BarCod2"].Width = 150;
            panel.Columns["BarCod2"].Visible = columns_Names_visible["BarCod2"].IfDefault;
            panel.Columns["BarCod3"].Width = 150;
            panel.Columns["BarCod3"].Visible = columns_Names_visible["BarCod3"].IfDefault;
            panel.Columns["BarCod4"].Width = 150;
            panel.Columns["BarCod4"].Visible = columns_Names_visible["BarCod4"].IfDefault;
        }
        private void DGV_Main_CellClick(object sender, GridCellClickEventArgs e)
        {
            DGV_Main.PrimaryGrid.Tag = e.GridCell.RowIndex;
        }
        private void DGV_Main_CellDoubleClick(object sender, GridCellDoubleClickEventArgs e)
        {
            ToolStripMenuItem_Det_Click(sender, e);
        }
        private void Button_ExportTable2_Click(object sender, EventArgs e)
        {
            try
            {
                ExportExcel.ExportToExcel(DGV_Main, "تقرير الأصناف");
            }
            catch
            {
            }
        }
        public void Button_Print_Click(object sender, EventArgs e)
        {
            if (ViewState != 0)
            {
                return;
            }
            try
            {
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_CATEGORY Inner Join T_Items on T_CATEGORY.CAT_ID = T_Items.ItmCat left join T_SYSSETTING on T_SYSSETTING.SYSSETTING_ID = T_Items.CompanyID ";
                string Fields = string.Empty;
                Fields = " T_Items.Itm_No as No, T_Items.Arb_Des as NmA, T_Items.Eng_Des as NmE,T_SYSSETTING.LogImg";
                _RepShow.Rule = string.Empty;
                if (!string.IsNullOrEmpty(Fields))
                {
                    _RepShow.Fields = Fields;
                    try
                    {
                        _RepShow = _RepShow.Save();
                        VarGeneral.RepData = _RepShow.RepData;
                    }
                    catch (Exception ex2)
                    {
                        MessageBox.Show(ex2.Message);
                    }
                    if (VarGeneral.RepData.Tables[0].Rows.Count == 0)
                    {
                        MessageBox.Show((LangArEn == 0) ? "عفوا .. لا يوجد بيانات لعرضها في التقرير " : "Sorry .. there is no data to display in the report ", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                    try
                    {
                        VarGeneral.IsGeneralUsed = true;
                        FrmReportsViewer frm = new FrmReportsViewer();
                        frm.Repvalue = "RepGeneral";
                        frm.Tag = LangArEn;
                        frm.Repvalue = "RepGeneral";
                        VarGeneral.vTitle = Text;
                        frm.TopMost = true;
                        frm.ShowDialog();
                        VarGeneral.IsGeneralUsed = false;
                    }
                    catch (Exception error)
                    {
                        VarGeneral.DebLog.writeLog("button_ShowRep_Click:", error, enable: true);
                        MessageBox.Show(error.Message);
                    }
                }
                else
                {
                    MessageBox.Show((LangArEn == 0) ? " يجب تحديد حقل واحد على الأقل للطباعة" : "You must select one field or more", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
            catch (Exception ex2)
            {
                MessageBox.Show(ex2.Message);
            }
        }
        private void txtBarCode1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (e.KeyChar != '\b'))
            {
                e.Handled = true;
            }
        }
        private void txtBarCode2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (e.KeyChar != '\b'))
            {
                e.Handled = true;
            }
        }
        private void txtBarCode3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (e.KeyChar != '\b'))
            {
                e.Handled = true;
            }
        }
        private void txtBarCode4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (e.KeyChar != '\b'))
            {
                e.Handled = true;
            }
        }
        private void txtBarCode5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (e.KeyChar != '\b'))
            {
                e.Handled = true;
            }
        }
        private void PrintSet()
        {
            string _PrinterName = prnt_doc.PrinterSettings.PrinterName;
            prnt_doc.PrinterSettings.PrinterName = _InvSetting.defPrn;
            if (!prnt_doc.PrinterSettings.IsValid)
            {
                prnt_doc.PrinterSettings.PrinterName = _PrinterName;
            }
        }
        private void PrintForm_Click(object sender, EventArgs e)
        {
            PrintDialog PrintDialog1 = new PrintDialog();
            printDialog1.Document = prnt_doc;
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                prnt_doc.Print();
            }
        }
        private void txtBarCode1_ButtonCustomClick(object sender, EventArgs e)
        {
            if (!(txtBarCode1.Text != string.Empty))
            {
                return;
            }
            VarGeneral.BarcodCopies = 0;
            c1BarCode1.Text = txtBarCode1.Text;
            c1BarCode1.Tag = textbox_SelPri1.Text + " " + txtCurr.Text;
            try
            {
                if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 60) && textBox_TaxSales.Value > 0.0 && !string.IsNullOrEmpty(textbox_SelPri1.Text))
                {
                    c1BarCode1.Tag = Math.Round(double.Parse(VarGeneral.TString.TEmpty(textbox_SelPri1.Text)) + double.Parse(textbox_SelPri1.Text) * (textBox_TaxSales.Value / 100.0), VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2);
                    if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 78))
                    {
                        c1BarCode1.Tag = Math.Round(double.Parse(c1BarCode1.Tag.ToString()), 0).ToString();
                    }
                    C1BarCode c1BarCode = c1BarCode1;
                    c1BarCode.Tag = string.Concat(c1BarCode.Tag, " ", txtCurr.Text);
                }
            }
            catch
            {
                c1BarCode1.Tag = textbox_SelPri1.Text + " " + txtCurr.Text;
            }
            PrintSet();
            prnt_prev = new PrintPreviewDialog();
            ToolStrip toollstr = (ToolStrip)prnt_prev.Controls["toolStrip1"];
            toollstr.Items.RemoveAt(0);
            toollstr.Items.Add("Print", null, PrintForm_Click);
            prnt_prev.Controls.Add(toollstr);
            prnt_prev.Document = prnt_doc;
            prnt_prev.ShowIcon = false;
            prnt_prev.AllowTransparency = true;
            prnt_prev.MdiParent = base.MdiParent;
            PrintDialog PrintDialog1 = new PrintDialog();
            printDialog1.Document = prnt_doc;
            T_Printer _InvSetting = new T_Printer();
            _InvSetting = db.StockPrinterSetting(VarGeneral.UserID, 22);
            try
            {
                if (_InvSetting.DefLines.Value > 0)
                {
                    if (_InvSetting.InvTypA4 == "1")
                    {
                        prnt_doc.PrinterSettings.Collate = true;
                    }
                    else
                    {
                        prnt_doc.PrinterSettings.Collate = false;
                    }
                }
                else
                {
                    prnt_doc.PrinterSettings.Collate = false;
                }
            }
            catch
            {
                prnt_doc.PrinterSettings.Collate = false;
            }
            try
            {
                if (_InvSetting.ISdirectPrinting)
                {
                    if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 55))
                    {
                        pdi.Document = new PrintDocument();
                        if (pdi.ShowDialog() == DialogResult.OK)
                        {
                            prnt_doc.PrinterSettings = pdi.PrinterSettings;
                            prnt_doc.Print();
                        }
                    }
                    else
                    {
                        prnt_doc.Print();
                    }
                }
                else
                {
                    prnt_prev.TopMost = true;
                    prnt_prev.ShowDialog();
                }
            }
            catch
            {
            }
        }
        private void prnt_prev_FormClosed(object sender, FormClosedEventArgs e)
        {
        }
        private void prnt_doc_BeginPrint(object sender, PrintEventArgs e)
        {
            CountPage = 0;
        }
        private void prnt_doc_PrintPage(object sender, PrintPageEventArgs e)
        {
            try
            {
                e.PageSettings.Margins.Bottom = 0;
                e.PageSettings.Margins.Top = Convert.ToInt32(_InvSetting.hAl);
                e.PageSettings.Margins.Left = Convert.ToInt32(_InvSetting.hYs);
                e.PageSettings.Margins.Right = 0;
                try
                {
                    if (!VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 55))
                    {
                        e.PageSettings.PrinterSettings.Copies = short.Parse(_InvSetting.DefLines.Value.ToString());
                    }
                }
                catch
                {
                    e.PageSettings.PrinterSettings.Copies = 1;
                }
                List<T_mInvPrint> listmInvPrint = new List<T_mInvPrint>();
                T_mInvPrint _mInvPrint = new T_mInvPrint();
                listmInvPrint = (from item in db.T_mInvPrints
                                 where item.repTyp == (int?)22
                                 where item.repNum == (int?)4
                                 where item.IsPrint == (int?)1
                                 where item.BarcodeTyp == (int?)0
                                 select item).ToList();
                if (listmInvPrint.Count == 0)
                {
                    return;
                }
                double _isRows = 0.0;
                double _isCols = 0.0;
                float _Row = 0f;
                float _Col = 0f;
                double _PageLine = 1;
                double _LineSp = _InvSetting.lnSpc.Value;
                StringFormat strformat = new StringFormat((StringFormatFlags)0, 1);
                for (int iiRnt = 0; (double)iiRnt < _PageLine; iiRnt++)
                {
                    _isCols = 0.0;
                    for (int iiCol = 0; (double)iiCol < _LineSp; iiCol++)
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
                            Font _font = new Font(_mInvPrint.vFont, float.Parse(_mInvPrint.vSize.Value.ToString()), e.Graphics.PageUnit);
                            if (_mInvPrint.vBold.Value == 1)
                            {
                                _font = new Font(_mInvPrint.vFont, float.Parse(_mInvPrint.vSize.Value.ToString()), FontStyle.Bold, e.Graphics.PageUnit);
                            }
                            _Row = (float)_mInvPrint.vRow.Value + (float)_isRows;
                            _Col = (float)_mInvPrint.vCol.Value + (float)_isCols;
                            if (_mInvPrint.pField == "BarCode")
                            {
                                e.Graphics.DrawImage(c1BarCode1.Image, _Col, _Row, float.Parse(_mInvPrint.MaxW.Value.ToString()), float.Parse(_mInvPrint.vSize.Value.ToString()));
                            }
                            else if (_mInvPrint.pField == "ItemNumber")
                            {
                                e.Graphics.DrawString(textBox_ID.Text, _font, Brushes.Black, _Col, _Row, strformat);
                            }
                            else if (_mInvPrint.pField == "ItemName")
                            {
                                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                                {
                                    e.Graphics.DrawString(textbox_Arb_Des.Text, _font, Brushes.Black, _Col, _Row, strformat);
                                }
                                else
                                {
                                    e.Graphics.DrawString(textbox_Eng_Des.Text, _font, Brushes.Black, _Col, _Row, strformat);
                                }
                            }
                            else if (_mInvPrint.pField == "Price")
                            {
                                e.Graphics.DrawString(c1BarCode1.Tag.ToString(), _font, Brushes.Black, _Col, _Row, strformat);
                            }
                            else if (_mInvPrint.pField == "CompanyName")
                            {
                                e.Graphics.DrawString(_Company.CopNam, _font, Brushes.Black, _Col, _Row, strformat);
                            }
                            else if (_mInvPrint.pField == "TaxNoteInv")
                            {
                                try
                                {
                                    e.Graphics.DrawString(VarGeneral.Settings_Sys.TaxNoteInv, _font, Brushes.Black, _Col, _Row, strformat);
                                }
                                catch
                                {
                                }
                            }
                            else
                            if (_mInvPrint.pField == "ProductionDate")
                            {
                                try
                                {
                                    e.Graphics.DrawString(Txt_ProductionDate.Text, _font, Brushes.Black, _Col, _Row, strformat);
                                }
                                catch
                                {
                                }
                            }
                            else
                            if (_mInvPrint.pField == "ExpirationDate")
                            {
                                try
                                {
                                    e.Graphics.DrawString(Txt_ExpirationDate.Text, _font, Brushes.Black, _Col, _Row, strformat);
                                }
                                catch
                                {
                                }
                            }
                        }
                        _isCols = _isCols + (double)_InvSetting.InvNum1.Value + _InvSetting.hYm.Value;
                    }
                    _isRows = _isRows + (double)_InvSetting.InvNum.Value + _InvSetting.hAs.Value;
                }
                CountPage++;
                if (CountPage == e.PageSettings.PrinterSettings.Copies)
                {
                    e.HasMorePages = false;
                }
                else
                {
                    e.HasMorePages = true;
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
                MessageBox.Show("عفوا\u064b ... لا توجد حقول للطباعة راجع إعدادات الطباعة  \n Sorry , Not Found Fields for Printing", Application.ProductName);
            }
        }
        private void prnt_doc_QueryPageSettings(object sender, QueryPageSettingsEventArgs e)
        {
        }
        private void txtBarCode1_Leave(object sender, EventArgs e)
        {
            if (txtBarCode1.Text != string.Empty && State != 0)
            {
                T_Item returned = db.SelectBarcodNoByReturnNo(txtBarCode1.Text);
                if (returned != null && returned.Itm_ID != 0 && returned.Itm_No != textBox_ID.Text)
                {
                    MessageBox.Show((LangArEn == 0) ? "الرقم الذي قمت بإدخاله موجود من قبل - مكرر .. يرجى المحاولة مرة اخرى" : "The number you have entered already exists - bis .. Please try again.", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    txtBarCode1.Text = string.Empty;
                    txtBarCode1.Focus();
                }
            }
        }
        private void txtBarCode2_ButtonCustomClick(object sender, EventArgs e)
        {
            if (!(txtBarCode2.Text != string.Empty))
            {
                return;
            }
            VarGeneral.BarcodCopies = 0;
            c1BarCode1.Text = txtBarCode2.Text;
            c1BarCode1.Tag = textbox_SelPri2.Text + " " + txtCurr.Text;
            try
            {
                if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 60) && textBox_TaxSales.Value > 0.0 && !string.IsNullOrEmpty(textbox_SelPri2.Text))
                {
                    c1BarCode1.Tag = Math.Round(double.Parse(VarGeneral.TString.TEmpty(textbox_SelPri2.Text)) + double.Parse(textbox_SelPri2.Text) * (textBox_TaxSales.Value / 100.0), VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2);
                    if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 78))
                    {
                        c1BarCode1.Tag = Math.Round(double.Parse(c1BarCode1.Tag.ToString()), 0).ToString();
                    }
                    C1BarCode c1BarCode = c1BarCode1;
                    c1BarCode.Tag = string.Concat(c1BarCode.Tag, " ", txtCurr.Text);
                }
            }
            catch
            {
                c1BarCode1.Tag = textbox_SelPri2.Text + " " + txtCurr.Text;
            }
            PrintSet();
            prnt_prev = new PrintPreviewDialog();
            ToolStrip toollstr = (ToolStrip)prnt_prev.Controls["toolStrip1"];
            toollstr.Items.RemoveAt(0);
            toollstr.Items.Add("Print", null, PrintForm_Click);
            prnt_prev.Controls.Add(toollstr);
            prnt_prev.Document = prnt_doc;
            prnt_prev.AllowTransparency = true;
            prnt_prev.ShowIcon = false;
            prnt_prev.MdiParent = base.MdiParent;
            PrintDialog PrintDialog1 = new PrintDialog();
            printDialog1.Document = prnt_doc;
            T_Printer _InvSetting = new T_Printer();
            _InvSetting = db.StockPrinterSetting(VarGeneral.UserID, 22);
            try
            {
                if (_InvSetting.DefLines.Value > 0)
                {
                    if (_InvSetting.InvTypA4 == "1")
                    {
                        prnt_doc.PrinterSettings.Collate = true;
                    }
                    else
                    {
                        prnt_doc.PrinterSettings.Collate = false;
                    }
                }
                else
                {
                    prnt_doc.PrinterSettings.Collate = false;
                }
            }
            catch
            {
                prnt_doc.PrinterSettings.Collate = false;
            }
            try
            {
                if (_InvSetting.ISdirectPrinting)
                {
                    if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 55))
                    {
                        pdi.Document = new PrintDocument();
                        if (pdi.ShowDialog() == DialogResult.OK)
                        {
                            prnt_doc.PrinterSettings = pdi.PrinterSettings;
                            prnt_doc.Print();
                        }
                    }
                    else
                    {
                        prnt_doc.Print();
                    }
                }
                else
                {
                    prnt_prev.TopMost = true;
                    prnt_prev.ShowDialog();
                }
            }
            catch
            {
            }
        }
        private void txtBarCode3_ButtonCustomClick(object sender, EventArgs e)
        {
            if (!(txtBarCode3.Text != string.Empty))
            {
                return;
            }
            VarGeneral.BarcodCopies = 0;
            c1BarCode1.Text = txtBarCode3.Text;
            c1BarCode1.Tag = textbox_SelPri3.Text + " " + txtCurr.Text;
            try
            {
                if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 60) && textBox_TaxSales.Value > 0.0 && !string.IsNullOrEmpty(textbox_SelPri3.Text))
                {
                    c1BarCode1.Tag = Math.Round(double.Parse(VarGeneral.TString.TEmpty(textbox_SelPri3.Text)) + double.Parse(textbox_SelPri3.Text) * (textBox_TaxSales.Value / 100.0), VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2);
                    if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 78))
                    {
                        c1BarCode1.Tag = Math.Round(double.Parse(c1BarCode1.Tag.ToString()), 0).ToString();
                    }
                    C1BarCode c1BarCode = c1BarCode1;
                    c1BarCode.Tag = string.Concat(c1BarCode.Tag, " ", txtCurr.Text);
                }
            }
            catch
            {
                c1BarCode1.Tag = textbox_SelPri3.Text + " " + txtCurr.Text;
            }
            PrintSet();
            prnt_prev = new PrintPreviewDialog();
            ToolStrip toollstr = (ToolStrip)prnt_prev.Controls["toolStrip1"];
            toollstr.Items.RemoveAt(0);
            toollstr.Items.Add("Print", null, PrintForm_Click);
            prnt_prev.Controls.Add(toollstr);
            prnt_prev.Document = prnt_doc;
            prnt_prev.AllowTransparency = true;
            prnt_prev.ShowIcon = false;
            prnt_prev.MdiParent = base.MdiParent;
            PrintDialog PrintDialog1 = new PrintDialog();
            printDialog1.Document = prnt_doc;
            T_INVSETTING _InvSetting = new T_INVSETTING();
            _InvSetting = db.StockInvSetting( 22);
            try
            {
                if (_InvSetting.DefLines.Value > 0)
                {
                    if (_InvSetting.InvTypA4 == "1")
                    {
                        prnt_doc.PrinterSettings.Collate = true;
                    }
                    else
                    {
                        prnt_doc.PrinterSettings.Collate = false;
                    }
                }
                else
                {
                    prnt_doc.PrinterSettings.Collate = false;
                }
            }
            catch
            {
                prnt_doc.PrinterSettings.Collate = false;
            }
            try
            {
                if (_InvSetting.ISdirectPrinting)
                {
                    if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 55))
                    {
                        pdi.Document = new PrintDocument();
                        if (pdi.ShowDialog() == DialogResult.OK)
                        {
                            prnt_doc.PrinterSettings = pdi.PrinterSettings;
                            prnt_doc.Print();
                        }
                    }
                    else
                    {
                        prnt_doc.Print();
                    }
                }
                else
                {
                    prnt_prev.TopMost = true;
                    prnt_prev.ShowDialog();
                }
            }
            catch
            {
            }
        }
        private void txtBarCode4_ButtonCustomClick(object sender, EventArgs e)
        {
            if (!(txtBarCode4.Text != string.Empty))
            {
                return;
            }
            VarGeneral.BarcodCopies = 0;
            c1BarCode1.Text = txtBarCode4.Text;
            c1BarCode1.Tag = textbox_SelPri4.Text + " " + txtCurr.Text;
            try
            {
                if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 60) && textBox_TaxSales.Value > 0.0 && !string.IsNullOrEmpty(textbox_SelPri4.Text))
                {
                    c1BarCode1.Tag = Math.Round(double.Parse(VarGeneral.TString.TEmpty(textbox_SelPri4.Text)) + double.Parse(textbox_SelPri4.Text) * (textBox_TaxSales.Value / 100.0), VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2);
                    if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 78))
                    {
                        c1BarCode1.Tag = Math.Round(double.Parse(c1BarCode1.Tag.ToString()), 0).ToString();
                    }
                    C1BarCode c1BarCode = c1BarCode1;
                    c1BarCode.Tag = string.Concat(c1BarCode.Tag, " ", txtCurr.Text);
                }
            }
            catch
            {
                c1BarCode1.Tag = textbox_SelPri4.Text + " " + txtCurr.Text;
            }
            PrintSet();
            prnt_prev = new PrintPreviewDialog();
            ToolStrip toollstr = (ToolStrip)prnt_prev.Controls["toolStrip1"];
            toollstr.Items.RemoveAt(0);
            toollstr.Items.Add("Print", null, PrintForm_Click);
            prnt_prev.Controls.Add(toollstr);
            prnt_prev.Document = prnt_doc;
            prnt_prev.AllowTransparency = true;
            prnt_prev.ShowIcon = false;
            prnt_prev.MdiParent = base.MdiParent;
            PrintDialog PrintDialog1 = new PrintDialog();
            printDialog1.Document = prnt_doc;
            T_INVSETTING _InvSetting = new T_INVSETTING();
            _InvSetting = db.StockInvSetting( 22);
            try
            {
                if (_InvSetting.DefLines.Value > 0)
                {
                    if (_InvSetting.InvTypA4 == "1")
                    {
                        prnt_doc.PrinterSettings.Collate = true;
                    }
                    else
                    {
                        prnt_doc.PrinterSettings.Collate = false;
                    }
                }
                else
                {
                    prnt_doc.PrinterSettings.Collate = false;
                }
            }
            catch
            {
                prnt_doc.PrinterSettings.Collate = false;
            }
            try
            {
                if (_InvSetting.ISdirectPrinting)
                {
                    if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 55))
                    {
                        pdi.Document = new PrintDocument();
                        if (pdi.ShowDialog() == DialogResult.OK)
                        {
                            prnt_doc.PrinterSettings = pdi.PrinterSettings;
                            prnt_doc.Print();
                        }
                    }
                    else
                    {
                        prnt_doc.Print();
                    }
                }
                else
                {
                    prnt_prev.TopMost = true;
                    prnt_prev.ShowDialog();
                }
            }
            catch
            {
            }
        }
        private void txtBarCode5_ButtonCustomClick(object sender, EventArgs e)
        {
            if (!(txtBarCode5.Text != string.Empty))
            {
                return;
            }
            VarGeneral.BarcodCopies = 0;
            c1BarCode1.Text = txtBarCode5.Text;
            c1BarCode1.Tag = textbox_SelPri5.Text + " " + txtCurr.Text;
            try
            {
                if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 60) && textBox_TaxSales.Value > 0.0 && !string.IsNullOrEmpty(textbox_SelPri5.Text))
                {
                    c1BarCode1.Tag = Math.Round(double.Parse(VarGeneral.TString.TEmpty(textbox_SelPri5.Text)) + double.Parse(textbox_SelPri5.Text) * (textBox_TaxSales.Value / 100.0), VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2);
                    if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 78))
                    {
                        c1BarCode1.Tag = Math.Round(double.Parse(c1BarCode1.Tag.ToString()), 0).ToString();
                    }
                    C1BarCode c1BarCode = c1BarCode1;
                    c1BarCode.Tag = string.Concat(c1BarCode.Tag, " ", txtCurr.Text);
                }
            }
            catch
            {
                c1BarCode1.Tag = textbox_SelPri5.Text + " " + txtCurr.Text;
            }
            PrintSet();
            prnt_prev = new PrintPreviewDialog();
            ToolStrip toollstr = (ToolStrip)prnt_prev.Controls["toolStrip1"];
            toollstr.Items.RemoveAt(0);
            toollstr.Items.Add("Print", null, PrintForm_Click);
            prnt_prev.Controls.Add(toollstr);
            prnt_prev.Document = prnt_doc;
            prnt_prev.AllowTransparency = true;
            prnt_prev.ShowIcon = false;
            prnt_prev.MdiParent = base.MdiParent;
            PrintDialog PrintDialog1 = new PrintDialog();
            printDialog1.Document = prnt_doc;
            T_INVSETTING _InvSetting = new T_INVSETTING();
            _InvSetting = db.StockInvSetting( 22);
            try
            {
                if (_InvSetting.DefLines.Value > 0)
                {
                    if (_InvSetting.InvTypA4 == "1")
                    {
                        prnt_doc.PrinterSettings.Collate = true;
                    }
                    else
                    {
                        prnt_doc.PrinterSettings.Collate = false;
                    }
                }
                else
                {
                    prnt_doc.PrinterSettings.Collate = false;
                }
            }
            catch
            {
                prnt_doc.PrinterSettings.Collate = false;
            }
            try
            {
                if (_InvSetting.ISdirectPrinting)
                {
                    if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 55))
                    {
                        pdi.Document = new PrintDocument();
                        if (pdi.ShowDialog() == DialogResult.OK)
                        {
                            prnt_doc.PrinterSettings = pdi.PrinterSettings;
                            prnt_doc.Print();
                        }
                    }
                    else
                    {
                        prnt_doc.Print();
                    }
                }
                else
                {
                    prnt_prev.TopMost = true;
                    prnt_prev.ShowDialog();
                }
            }
            catch
            {
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
            VarGeneral.SFrmTyp = "T_AccDef_Suppliers";
            VarGeneral.AccTyp = 5;
            if (File.Exists(Application.StartupPath + "\\Script\\SecriptInvitationCards.dll"))
            {
                VarGeneral.AccTyp = 4;
            }
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
            }
            else
            {
                txtCustNo.Text = string.Empty;
                txtCustName.Text = string.Empty;
            }
        }
        private void buttonItem_EditPrice_Click(object sender, EventArgs e)
        {
            try
            {
                if (!VarGeneral.TString.ChkStatShow(permission.SetStr, 5))
                {
                    MessageBox.Show((LangArEn == 0) ? "لا يمكن اتمام هذه العملية .. الرجاء مراجعة صلاحيات المستخدمين !" : "Can not complete this process .. please see the powers of the users!", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                else
                {
                    if (State != 0)
                    {
                        return;
                    }
                    try
                    {
                        if (string.IsNullOrEmpty(textBox_ID.Text))
                        {
                            return;
                        }
                    }
                    catch
                    {
                        return;
                    }
                    try
                    {
                        if (db.StockCheckInvDet(DataThis.Itm_No))
                        {
                            buttonItem_EditPrice.Enabled = true;
                        }
                        else
                        {
                            buttonItem_EditPrice.Enabled = false;
                        }
                    }
                    catch
                    {
                        return;
                    }
                    FrmEditItemsPrices form1 = new FrmEditItemsPrices(textBox_ID.Text);
                    form1.Tag = LangArEn.ToString();
                    form1.StartPosition = FormStartPosition.CenterScreen;
                    try
                    {
                        if ((data_this.AvrageCost.Value == 0.0 || data_this.AvrageCost.Value == 0.0) && (data_this.FirstCost.Value == 0.0 || data_this.FirstCost.Value == 0.0) && VarGeneral.UserID != 1)
                        {
                            form1.doubleInput_SelCostNew.Visible = false;
                            form1.doubleInput_SelCostNow.Visible = false;
                            form1.label4.Visible = false;
                        }
                    }
                    catch
                    {
                        return;
                    }
                    form1.TopMost = true;
                    form1.ShowDialog();
                    dbInstance = null;
                    textBox_ID_TextChanged(sender, e);
                    return;
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("buttonItem_EditPrice_Click:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void radioButton_Product_CheckedChanged(object sender, CheckBoxChangeEventArgs e)
        {
            if (radioButton_Product.Checked)
            {
                superTabItem_Details.Enabled = true;
                sideBarPanelItem_Unit2.Visible = false;
                sideBarPanelItem_Unit3.Visible = false;
                sideBarPanelItem_Unit4.Visible = false;
                sideBarPanelItem_Unit5.Visible = false;
                label11.Visible = false;
                textbox_Supreme.Visible = false;
            }
            else
            {
                superTabItem_Details.Enabled = false;
                sideBarPanelItem_Unit2.Visible = true;
                sideBarPanelItem_Unit3.Visible = true;
                sideBarPanelItem_Unit4.Visible = true;
                sideBarPanelItem_Unit5.Visible = true;
                label11.Visible = true;
                textbox_Supreme.Visible = true;
            }
            Refresh();
        }
        private void FlxInv_AfterEdit(object sender, RowColEventArgs e)
        {
            try
            {
                double ItmDis = 0.0;
                ItmDis = double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 8)))) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 9)))) / 100.0);
                if (e.Col == 1)
                {
                    BindDataOfItem();
                }
                else if (((e.Col == 2 || e.Col == 4) && (string)FlxInv.GetData(e.Row, 1) == string.Empty) || FlxInv.GetData(e.Row, 1) == null)
                {
                    BindDataOfItem();
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
                    FlxInv.SetData(e.Row, 12, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 11)))));
                    FlxInv.SetData(e.Row, 31, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 8)))) - ItmDis);
                    PriceLoc = double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 8))));
                    FlxInv.SetData(e.Row, 26, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 8)))) / 1.0);
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
                }
                else if (e.Col == 7 || e.Col == 8)
                {
                    double RealQ = 0.0;
                    RealQ = double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 11))));
                    if (e.Col == 8 && double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 10)))) != 0.0 && double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 10)))) > double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 8)))) && !VarGeneral.TString.ChkStatShow(VarGeneral.UserPassQty, 2))
                    {
                        MessageBox.Show((LangArEn == 0) ? "لا يمكن البيع بأقل من سعر التكلفة .. راجع صلاحيات المستخدمين" : "Can't Sale Less Then Cost Price ... Check the Users Authorizations", VarGeneral.ProdectNam);
                        FlxInv.SetData(e.Row, 8, PriceLoc);
                    }
                    FlxInv.SetData(e.Row, 12, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 11)))));
                    FlxInv.SetData(e.Row, 31, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 8)))) - ItmDis);
                    chekReptItem(Col_1: false);
                }
                else if (e.Col == 9)
                {
                    FlxInv.SetData(e.Row, 31, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 8)))) - ItmDis);
                }
                else if (e.Col == 31)
                {
                    if (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 31)))) != double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 8)))) - ItmDis)
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
                    if (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 10)))) != 0.0 && double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 10)))) > double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 8)))) && !VarGeneral.TString.ChkStatShow(VarGeneral.UserPassQty, 2))
                    {
                        MessageBox.Show((LangArEn == 0) ? "لا يمكن البيع بأقل من سعر التكلفة .. راجع صلاحيات المستخدمين" : "Can't Sale Less Then Cost Price ... Check the Users Authorizations", VarGeneral.ProdectNam);
                        FlxInv.SetData(e.Row, 8, PriceLoc);
                    }
                    chekReptItem(Col_1: false);
                }
                VarGeneral.Flush();
                GetInvTot();
            }
            catch
            {
            }
        }
        private void GetInvTot()
        {
            try
            {
                double InvTot = 0.0;
                double InvCost = 0.0;
                double InvQty = 0.0;
                List<double> vQty = new List<double>();
                for (int iiCnt = 1; iiCnt < FlxInv.Rows.Count; iiCnt++)
                {
                    try
                    {
                        InvTot += double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 31))));
                        InvCost += double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 10)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 12))));
                        InvQty += double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 7))));
                        vQty.Add(db.StockItem(FlxInv.GetData(iiCnt, 1).ToString()).OpenQty.Value / double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 12)))));
                    }
                    catch
                    {
                    }
                }
                textbox_Cost1.Text = VarGeneral.TString.TEmpty(Math.Round(InvCost, VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2).ToString());
                c1FlexGrid_Items.SetData(1, 1, VarGeneral.TString.TEmpty(Math.Round(InvCost, VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2).ToString()));
                if (vQty.Count > 0)
                {
                    c1FlexGrid_Items.SetData(1, 0, (vQty.Min() < 0.0) ? 0.0 : vQty.Min());
                }
                else
                {
                    c1FlexGrid_Items.SetData(1, 0, 0);
                }
            }
            catch
            {
            }
        }
        private void FlxInv_BeforeEdit(object sender, RowColEventArgs e)
        {
            if ((e.Col == 3 || e.Col == 5) && FlxInv.GetData(e.Row, e.Col) != null)
            {
                oldUnit = FlxInv.GetData(e.Row, 3).ToString() ?? string.Empty;
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
            if (RowSel == FlxInv.Row || FlxInv.Row <= 0 || !(string.Concat(FlxInv.GetData(FlxInv.Row, 1)) != string.Empty))
            {
                return;
            }
            List<T_Item> listSer = new List<T_Item>();
            listSer = db.StockItemList(string.Concat(FlxInv.GetData(FlxInv.RowSel, 1)));
            if (listSer.Count != 0)
            {
                _Items = listSer[0];
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
            }
            else
            {
                FlxInv.SetData(FlxInv.Row, 1, string.Empty);
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
            List<T_Item> q;
            FrmSearch FmSerch;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection;
            if ((string)FlxInv.GetData(FlxInv.Row, 1) != string.Empty && FlxInv.GetData(FlxInv.Row, 1) != null)
            {
                Barcod = ChkBarCod((string)FlxInv.GetData(FlxInv.Row, 1));
                if (!Barcod || (VarGeneral.SSSLev != "D" && VarGeneral.SSSLev != "G" && VarGeneral.SSSLev != "S" && VarGeneral.SSSLev != "B" && VarGeneral.SSSLev != "F" && VarGeneral.SSSLev != "C" && VarGeneral.SSSLev != "R" && VarGeneral.SSSLev != "H" && VarGeneral.SSSLev != "M"))
                {
                    listSer = db.StockItemList(FlxInv.GetData(FlxInv.Row, 1).ToString());
                    if (listSer.Count != 0)
                    {
                        FillItemDet(_Items = listSer[0], Barcod, FlxInv.Row, 0, 0, 0.0, 0.0);
                    }
                }
            }
            else
            {
                q = (from t in db.T_Items
                     where ((!string.IsNullOrEmpty(data_this.Itm_No)) ? (t.Itm_No != data_this.Itm_No) : true) && !t.InvSaleStoped.Value
                     orderby t.Itm_No
                     select t).ToList();
                if (q.Count == 0)
                {
                    return;
                }
                FmSerch = new FrmSearch();
                VarGeneral.SFrmTyp = "T_Items_Sum";
                FmSerch.Tag = LangArEn;
                VarGeneral.itmDes = data_this.Itm_No;
                animalsAsCollection = columns_Names_visible2;
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
                FillItemDet(_Items = listSer[0], Barcod, FlxInv.Row, 0, 0, 0.0, 0.0);
            }
            if ((Barcod && (!(VarGeneral.SSSLev != "D") || !(VarGeneral.SSSLev != "G") || !(VarGeneral.SSSLev != "S") || !(VarGeneral.SSSLev != "B") || !(VarGeneral.SSSLev != "F") || !(VarGeneral.SSSLev != "C") || !(VarGeneral.SSSLev != "R") || !(VarGeneral.SSSLev != "H") || !(VarGeneral.SSSLev != "M"))) || listSer.Count != 0)
            {
                return;
            }
            q = (from t in db.T_Items
                 where t.ItmTyp == (int?)0 && ((!string.IsNullOrEmpty(data_this.Itm_No)) ? (t.Itm_No != data_this.Itm_No) : true) && !t.InvSaleStoped.Value
                 orderby t.Itm_No
                 select t).ToList();
            if (q.Count == 0)
            {
                return;
            }
            FmSerch = new FrmSearch();
            VarGeneral.SFrmTyp = "T_Items_Sum";
            FmSerch.Tag = LangArEn;
            VarGeneral.itmDes = data_this.Itm_No;
            animalsAsCollection = columns_Names_visible2;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                FmSerch.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
            }
            FmSerch.TopMost = true;
            FmSerch.ShowDialog();
            VarGeneral.itmDesIndex = 0;
            VarGeneral.itmDes = string.Empty;
            if (FmSerch.SerachNo != string.Empty)
            {
                listSer = db.StockItemList(FmSerch.SerachNo);
                FillItemDet(_Items = listSer[0], Barcod, FlxInv.Row, 0, 0, 0.0, 0.0);
                return;
            }
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
        }
        private void FillItemDet(T_Item _Itm, bool Barcod, int vRow, int vUntID, int vStoreNo, double vQty, double vPrice)
        {
            FlxInv.SetData(vRow, 1, _Itm.Itm_No.Trim());
            FlxInv.SetData(vRow, 2, _Itm.Arb_Des.Trim());
            FlxInv.SetData(vRow, 4, _Itm.Eng_Des.Trim());
            FlxInv.SetData(vRow, 6, (vUntID == 0) ? 1 : vStoreNo);
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
                    FlxInv.SetData(vRow, 8, (vUntID == 0) ? _Itm.UntPri1.Value : vPrice);
                    FlxInv.SetData(vRow, 11, _Itm.Pack1.Value);
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
                    FlxInv.SetData(vRow, 8, (vUntID == 0) ? _Itm.UntPri1.Value : vPrice);
                    FlxInv.SetData(vRow, 11, _Itm.Pack1);
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
                    FlxInv.SetData(vRow, 8, (vUntID == 0) ? _Itm.UntPri2.Value : vPrice);
                    FlxInv.SetData(vRow, 11, _Itm.Pack2);
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
                    FlxInv.SetData(vRow, 8, (vUntID == 0) ? _Itm.UntPri2.Value : vPrice);
                    FlxInv.SetData(vRow, 11, _Itm.Pack2);
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
                    FlxInv.SetData(vRow, 8, (vUntID == 0) ? _Itm.UntPri3.Value : vPrice);
                    FlxInv.SetData(vRow, 11, _Itm.Pack3);
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
                    FlxInv.SetData(vRow, 8, (vUntID == 0) ? _Itm.UntPri3.Value : vPrice);
                    FlxInv.SetData(vRow, 11, _Itm.Pack3);
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
                    FlxInv.SetData(vRow, 8, (vUntID == 0) ? _Itm.UntPri4.Value : vPrice);
                    FlxInv.SetData(vRow, 11, _Itm.Pack4);
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
                    FlxInv.SetData(vRow, 8, (vUntID == 0) ? _Itm.UntPri4.Value : vPrice);
                    FlxInv.SetData(vRow, 11, _Itm.Pack4);
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
                    FlxInv.SetData(vRow, 8, (vUntID == 0) ? _Itm.UntPri5.Value : vPrice);
                    FlxInv.SetData(vRow, 11, _Itm.Pack5);
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
                    FlxInv.SetData(vRow, 8, (vUntID == 0) ? _Itm.UntPri5.Value : vPrice);
                    FlxInv.SetData(vRow, 11, _Itm.Pack5);
                }
                if (vUntID == 0)
                {
                }
                break;
            }
            FlxInv.Cols[3].ComboList = CoA;
            FlxInv.Cols[5].ComboList = CoE;
#pragma warning disable CS0219 // The variable 'ItmPri' is assigned but its value is never used
            double ItmPri = 0.0;
#pragma warning restore CS0219 // The variable 'ItmPri' is assigned but its value is never used
            FlxInv.SetData(vRow, 3, DefUnitA);
            FlxInv.SetData(vRow, 5, DefUnitE);
            FlxInv.SetData(vRow, 10, _Itm.AvrageCost * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(vRow, 11)))) / RateValue);
            FlxInv.SetData(vRow, 30, _Itm.LastCost * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(vRow, 11)))) / RateValue);
            FlxInv.SetData(vRow, 28, _Itm.Lot);
            FlxInv.SetData(vRow, 32, _Itm.ItmTyp);
            FlxInv.SetData(vRow, 33, _Itm.ItmLoc);
            FlxInv.SetData(vRow, 18, _Itm.DefPack);
            FlxInv.SetData(vRow, 19, _Itm.Price1);
            FlxInv.SetData(vRow, 20, _Itm.Price2);
            FlxInv.SetData(vRow, 21, _Itm.Price3);
            FlxInv.SetData(vRow, 22, _Itm.Price4);
            FlxInv.SetData(vRow, 23, _Itm.Price5);
            FlxInv.SetData(vRow, 8, 1);
            PriceLoc = 1.0;
            FlxInv.SetData(vRow, 7, (vUntID == 0) ? 0.0 : vQty);
            FlxInv.SetData(vRow, 12, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(vRow, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(vRow, 11)))));
            FlxInv.SetData(vRow, 31, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(vRow, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(vRow, 8)))));
            GetInvTot();
            chekRept();
            VarGeneral.Flush();
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
                    if (!string.IsNullOrEmpty(string.Concat(FlxInv.GetData(iiCnt, 1))) && iiCnt != FlxInv.RowSel && FlxInv.GetData(iiCnt, 1).ToString() == FlxInv.GetData(FlxInv.RowSel, 1).ToString() && FlxInv.GetData(iiCnt, 11).ToString() == FlxInv.GetData(FlxInv.RowSel, 11).ToString() && FlxInv.GetData(iiCnt, 6).ToString() == FlxInv.GetData(FlxInv.RowSel, 6).ToString())
                    {
                        try
                        {
                            FlxInv.SetData(FlxInv.RowSel, 7, double.Parse(VarGeneral.TString.TEmpty(FlxInv.GetData(iiCnt, 7).ToString() ?? string.Empty)) + vQty);
                        }
                        catch
                        {
                            FlxInv.SetData(FlxInv.RowSel, 7, 0);
                            FlxInv.SetData(FlxInv.RowSel, 12, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 11)))));
                            FlxInv.SetData(FlxInv.RowSel, 31, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 8)))));
                            goto IL_042b;
                        }
                        FlxInv.SetData(iiCnt, 7, double.Parse(VarGeneral.TString.TEmpty(FlxInv.GetData(iiCnt, 7).ToString() ?? string.Empty)) + vQty);
                        if (FlxInv.RowSel > 0)
                        {
                            FlxInv.RemoveItem(FlxInv.Row);
                            FlxInv.SetData(iiCnt, 12, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 11)))));
                            FlxInv.SetData(iiCnt, 31, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 8)))));
                            GetInvTot();
                            FlxInv.Row = FlxInv.RowSel;
                            FlxInv.Col = 0;
                        }
                        return true;
                    }
                }
            }
            goto IL_042b;
            IL_042b:
            return false;
        }
        private void c1FlexGrid_Items_Click(object sender, EventArgs e)
        {
            Button_Edit_Click(sender, e);
        }
        private void txtBarCode1_GotFocus(object sender, EventArgs e)
        {
            Button_Edit_Click(sender, e);
        }
        private void buttonItem_Serials_Click(object sender, EventArgs e)
        {
            if (State != 0)
            {
                return;
            }
            try
            {
                if (string.IsNullOrEmpty(textBox_ID.Text))
                {
                    return;
                }
            }
            catch
            {
                return;
            }
            if (!VarGeneral.TString.ChkStatShow(permission.SetStr, 39))
            {
                MessageBox.Show((LangArEn == 0) ? "لا يمكن اتمام هذه العملية .. الرجاء مراجعة صلاحيات المستخدمين !" : "Can not complete this process .. please see the powers of the users!", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            FrmSerials form1 = new FrmSerials();
            form1.vitemNo = textBox_ID.Text;
            form1.Tag = LangArEn.ToString();
            form1.TopMost = true;
            form1.ShowDialog();
        }
        private void button_DeleteFromSystem_Click(object sender, EventArgs e)
        {
            if (VarGeneral.UserID != 1)
            {
                MessageBox.Show((LangArEn == 0) ? "لا يمكن اتمام هذه العملية .. الرجاء مراجعة صلاحيات المستخدمين !" : "Can not complete this process .. please see the powers of the users!", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                if (State != 0)
                {
                    return;
                }
                try
                {
                    if (string.IsNullOrEmpty(textBox_ID.Text))
                    {
                        return;
                    }
                }
                catch
                {
                    return;
                }
                if (MessageBox.Show("سيتم إزالة هذا الصنف بشكل نهائي من النظام .. هل تريد المتابعة؟ \n This Item will be permanently removed from the system .. Continue ?", VarGeneral.ProdectNam, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    return;
                }
                var Query = (from p in db.T_INVHEDs
                             join c in db.T_INVDETs on p.InvHed_ID equals c.InvId into j1
                             from j2 in j1.DefaultIfEmpty()
                             where p.IfDel.Value == 1 && j2.ItmNo == data_this.Itm_No
                             group new
                             {
                                 j2,
                                 j1
                             } by new
                             {
                                 p.InvHed_ID,
                                 p.InvNo,
                                 p.InvTyp,
                                 j2.ItmNo,
                                 j2.InvDet_ID,
                                 j2.InvId,
                                 p.GadeId
                             } into grouped
                             orderby grouped.Key.InvHed_ID
                             select new
                             {
                                 grouped.Key.InvHed_ID,
                                 grouped.Key.GadeId
                             }).Distinct().ToList();
                if (Query.Count > 0)
                {
                    for (int i = 0; i < Query.Count; i++)
                    {
                        db.ExecuteCommand("DELETE FROM [dbo].[T_SINVDET] WHERE SInvIdHEAD = " + Query[i].InvHed_ID);
                        db.ExecuteCommand("DELETE FROM [dbo].[T_INVDET] WHERE InvId = " + Query[i].InvHed_ID);
                        db.ExecuteCommand("DELETE FROM [dbo].[T_INVHED] WHERE InvHed_ID = " + Query[i].InvHed_ID);
                        try
                        {
                            if (Query[i].GadeId.HasValue)
                            {
                                db.ExecuteCommand("DELETE FROM [dbo].[T_GDDET] WHERE gdID = " + Query[i].GadeId.Value);
                                db.ExecuteCommand("DELETE FROM [dbo].[T_GDHEAD] WHERE gdhead_ID = " + Query[i].GadeId.Value);
                            }
                        }
                        catch
                        {
                        }
                    }
                    db.ExecuteCommand("DELETE FROM [dbo].[T_STKSQTY] WHERE itmNo = '" + data_this.Itm_No + "'");
                    db.ExecuteCommand("DELETE FROM [dbo].[T_QTYEXP] WHERE itmNo = '" + data_this.Itm_No + "'");
                    db.ExecuteCommand("DELETE FROM [dbo].[T_StoreMnd] WHERE itmNo = '" + data_this.Itm_No + "'");
                    ifOkDelete = true;
                    Button_Delete_Click(sender, e);
                }
                else
                {
                    button_DeleteFromSystem.Visible = false;
                    Button_Delete_Click(sender, e);
                    button_DeleteFromSystem.Visible = true;
                }
            }
        }
        private void button_DeleteFromSystem_VisibleChanged(object sender, EventArgs e)
        {
            if (button_DeleteFromSystem.Visible)
            {
                Button_Delete.Visible = false;
            }
            superTabControl_Main1.Refresh();
        }
        private void doubleInput_DefPack_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }
        private void doubleInput_DefPack_Click(object sender, EventArgs e)
        {
            doubleInput_DefPack.SelectAll();
        }
        private void buttonItem_EditPriceAll_Click(object sender, EventArgs e)
        {
            try
            {
                if (!VarGeneral.TString.ChkStatShow(permission.SetStr, 5))
                {
                    MessageBox.Show((LangArEn == 0) ? "لا يمكن اتمام هذه العملية .. الرجاء مراجعة صلاحيات المستخدمين !" : "Can not complete this process .. please see the powers of the users!", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                else if (State == FormState.Saved)
                {
                    FrmEditItemsPricesAll form1 = new FrmEditItemsPricesAll();
                    form1.Tag = LangArEn.ToString();
                    form1.TopMost = true;
                    form1.ShowDialog();
                    dbInstance = null;
                    textBox_ID_TextChanged(sender, e);
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("buttonItem_EditPriceAll_Click:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void buttonItem_AddDisProcess_Click(object sender, EventArgs e)
        {
            try
            {
                if (!VarGeneral.TString.ChkStatShow(permission.SetStr, 47))
                {
                    MessageBox.Show((LangArEn == 0) ? "لا يمكن اتمام هذه العملية .. الرجاء مراجعة صلاحيات المستخدمين !" : "Can not complete this process .. please see the powers of the users!", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                else
                {
                    if (State != 0)
                    {
                        return;
                    }
                    try
                    {
                        if (string.IsNullOrEmpty(textBox_ID.Text))
                        {
                            return;
                        }
                    }
                    catch
                    {
                        return;
                    }
                    FrmGeneralPriceAddation form1 = new FrmGeneralPriceAddation();
                    form1.Tag = LangArEn.ToString();
                    form1.StartPosition = FormStartPosition.CenterScreen;
                    form1.TopMost = true;
                    form1.ShowDialog();
                    dbInstance = null;
                    textBox_ID_TextChanged(sender, e);
                    return;
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("buttonItem_EditPrice_Click:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void txtFiled1_Click(object sender, EventArgs e)
        {
            txtFiled1.SelectAll();
        }
        private void txtFiled2_Click(object sender, EventArgs e)
        {
            txtFiled2.SelectAll();
        }
        private void txtFiled3_Click(object sender, EventArgs e)
        {
            txtFiled3.SelectAll();
        }
        private void txtFiled4_Click(object sender, EventArgs e)
        {
            txtFiled4.SelectAll();
        }
        private void txtFiled5_Click(object sender, EventArgs e)
        {
            txtFiled5.SelectAll();
        }
        private void txtFiled6_Click(object sender, EventArgs e)
        {
            txtFiled6.SelectAll();
        }
#pragma warning disable CS0414 // The field 'FrmItems.flagsho' is assigned but its value is never used
        int flagsho = 0;
#pragma warning restore CS0414 // The field 'FrmItems.flagsho' is assigned but its value is never used
        void setdefaultpack()
        {
            textbox_Pack1.Text = "1";
            textbox_Pack1.Enabled = false;
            textbox_Pack2.Text = "1";
            textbox_Pack2.Enabled = false;
            textbox_Pack3.Text = "1";
            textbox_Pack3.Enabled = false;
            textbox_Pack4.Text = "1";
            textbox_Pack4.Enabled = false;
            textbox_Pack5.Text = "1";
            textbox_Pack5.Enabled = false;
        }
        private void c1Button1_Click(object sender, EventArgs e)
        {
        }
        private void button1_Click(object sender, EventArgs e)
        {
        }
        private void c1Button2_Click(object sender, EventArgs e)
        {
        }
        private void buttonItem7_Click(object sender, EventArgs e)
        {
            ViewDetails_Click(sender, e);
            panelEx3.Visible = false;
        }
        private void c1Button2_Click_1(object sender, EventArgs e)
        {
            ViewTable_Click(sender, e);
            panelEx3.Visible = true;
            this.Controls.Add(panelEx3);
            panelEx3.Dock = DockStyle.Fill;
            panelEx3.BringToFront();
        }
        private void buttonItem8_Click(object sender, EventArgs e)
        {
            ViewTable_Click(sender, e);
            panelEx3.Visible = true;
            this.Controls.Add(panelEx3);
            panelEx3.Dock = DockStyle.Fill;
            panelEx3.BringToFront();
        }
        private void labelItem6_Click(object sender, EventArgs e)
        {
        }
        private void superTabControlPanel1_Click(object sender, EventArgs e)
        {
        }
        private void FrmItems_Move(object sender, EventArgs e)
        {
            //   this.Text = this.Location.X + "          y=" + this.Location.Y;
        }
        private void textbox_Legates_ValueChanged(object sender, EventArgs e)
        {
        }
        private void labelItem15_Click(object sender, EventArgs e)
        {
        }
        private void radiobutton_RButDef5_CheckedChanged(object sender, EventArgs e)
        {
            if (radiobutton_RButDef5.Checked)
            {
                radiobutton_RButDef1.Checked = false;
                radiobutton_RButDef2.Checked = false;
                radiobutton_RButDef3.Checked = false;
                radiobutton_RButDef4.Checked = false;
                radiobutton_RButDef5.Checked = true;
            }
        }
        private void radiobutton_RButDef4_CheckedChanged(object sender, EventArgs e)
        {
            if (radiobutton_RButDef4.Checked)
            {
                radiobutton_RButDef1.Checked = false;
                radiobutton_RButDef2.Checked = false;
                radiobutton_RButDef3.Checked = false;
                radiobutton_RButDef4.Checked = true;
                radiobutton_RButDef5.Checked = false;
            }
        }
        private void radiobutton_RButDef3_CheckedChanged(object sender, EventArgs e)
        {
            if (radiobutton_RButDef3.Checked)
            {
                radiobutton_RButDef1.Checked = false;
                radiobutton_RButDef2.Checked = false;
                radiobutton_RButDef3.Checked = true;
                radiobutton_RButDef4.Checked = false;
                radiobutton_RButDef5.Checked = false;
            }
        }
        private void radiobutton_RButDef2_CheckedChanged(object sender, EventArgs e)
        {
            if (radiobutton_RButDef2.Checked)
            {
                radiobutton_RButDef1.Checked = false;
                radiobutton_RButDef2.Checked = true;
                radiobutton_RButDef3.Checked = false;
                radiobutton_RButDef4.Checked = false;
                radiobutton_RButDef5.Checked = false;
            }
        }
        private void radiobutton_RButDef1_CheckedChanged(object sender, EventArgs e)
        {
            if (radiobutton_RButDef1.Checked)
            {
                radiobutton_RButDef1.Checked = true;
                radiobutton_RButDef2.Checked = false;
                radiobutton_RButDef3.Checked = false;
                radiobutton_RButDef4.Checked = false;
                radiobutton_RButDef5.Checked = false;
            }
        }
        private void grouhpPanel_Inv_Click(object sender, EventArgs e)
        {
        }
        private void Button_Search_Click_1(object sender, EventArgs e)
        {
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
            }
            VarGeneral.SFrmTyp = "T_Items";
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != string.Empty)
            {
                textBox_ID.Text = frm.SerachNo.ToString();
            }
        }
        private void txtBarCode1_TextChanged(object sender, EventArgs e)
        {
        }
        private void textbox_Pack4_KeyDown(object sender, KeyEventArgs e)
        {
        }
        private void Button_Save_Click_1(object sender, EventArgs e)
        {
        }
        private void superTabControl_Main1_SelectedTabChanged(object sender, SuperTabStripSelectedTabChangedEventArgs e)
        {
        }
        private void textbox_Pack2_EnabledChanged(object sender, EventArgs e)
        {
            if (Program.iscarversion())
            {
                setdefaultpack();
            }
        }
        private void ribbonBar_Units_ItemClick(object sender, EventArgs e)
        {
        }
        private void superTabControl_Main1_RightToLeftChanged(object sender, EventArgs e)
        {
            superTabControl_Main1.RightToLeftChanged -= superTabControl_Main1_RightToLeftChanged;
            superTabControl_Main1.RightToLeft = RightToLeft.No;
            superTabControl_Main1.RightToLeftChanged += superTabControl_Main1_RightToLeftChanged;
            superTabControl_Main1.Refresh();
        }
        private void pictureBox_PicItem_Click(object sender, EventArgs e)
        {
        }
        private void Button_Next_Click_1(object sender, EventArgs e)
        {
        }
        private void textbox_Pack5_TextChanged(object sender, EventArgs e)
        {
            if (textbox_Pack5.Text == "0")
            { textbox_Pack5.Text = "1"; }
        }
        private void FrmItems_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
        }
            private void label4_TextChanged(object sender, EventArgs e)
        {
             }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PanelContainerSpatial_Paint(object sender, PaintEventArgs e)
        {

        }

        private void metroStatusBar_itemsType_ItemClick(object sender, EventArgs e)
        {

        }
    }
}
