using C1.Win.C1FlexGrid;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.DotNetBar.SuperGrid;
using DevComponents.DotNetBar.SuperGrid.Style;
using DevComponents.Editors;
using InvAcc.GeneralM;
using InvAcc.Stock_Data;
using Library.RepShow;
using SSSDateTime.Date;
using SSSLanguage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial  class FrmUsr : Form
    { void avs(int arln)

{ 
 label19.Text=   (arln == 0 ? "  إحتساب العمولة حسب  " : "  Calculate commission by") ; groupBox_Comm.Text=   (arln == 0 ? "  نسبة عمولة المستخدم  " : "  User commission rate") ; label9.Text=   (arln == 0 ? "  %  " : "  %") ; label10.Text=   (arln == 0 ? "  %  " : "  %") ; label11.Text=   (arln == 0 ? "  الإيرادات  " : "  Revenues") ; label12.Text=   (arln == 0 ? "  المبيعات  " : "  the sales") ; groupPanel_Banner.Text=   (arln == 0 ? "  صورة المستخدم  " : "  user picture") ; label21.Text=   (arln == 0 ? "  الإرتفــــاع  " : "  height") ; label34.Text=   (arln == 0 ? "  العـــرض  " : "  the width") ; chk23.Text=   (arln == 0 ? "  إظهار لوحة المعلومات السريعة  " : "  Show quick dashboard") ; groupBox1.Text=   (arln == 0 ? "  الحد الأقصى لنسبة الخصم  " : "  Maximum discount rate") ; label23.Text=   (arln == 0 ? "  %  " : "  %") ; label25.Text=   (arln == 0 ? "  المبيعات ومرتجع المبيعات  " : "  Sales and sales returns") ; chk21.Text=   (arln == 0 ? "  عدم السماح بتكرار أرقام الجوالات للعملاء  " : "  Do not allow duplicate mobile numbers for customers") ; chk20.Text=   (arln == 0 ? "  انهاء الفواتير المعلقة قبل اغلاق النافذة  " : "  End pending invoices before closing the window") ; chk19.Text=   (arln == 0 ? "  إيقــــاف خصــــــم الفـــاتــورة  " : "  Stop deducting the bill") ; chk18.Text=   (arln == 0 ? "  إيقاف خصـــم سطـــور الأصنــاف للفواتــير  " : "  Stop deducting items lines for invoices") ; chk17.Text=   (arln == 0 ? "  إرسال رسالة تاكيد للعميل الجديد قبل الحفظ  " : "  Send a confirmation message to the new customer before saving") ; chk15.Text=   (arln == 0 ? "  السماح بادخال واخراج البضاعة بدون كميات  " : "  Allow the entry and exit of goods without quantities") ; chk14.Text=   (arln == 0 ? "  عدم السماح بالبيع في حال صافي الفاتورة اقل من إجمالي التكلفة  " : "  Selling is not allowed if the net invoice is less than the total cost") ; chk12.Text=   (arln == 0 ? "  السماح بإرجاع صنف بدون اصدار فاتورة مبيعات لها  " : "  Allow returning an item without issuing a sales invoice for it") ; label15.Text=   (arln == 0 ? "  عدم السماح بالبيــع بسعـر يتجـــاوز  " : "  Not allowed to sell at a price that exceeds") ; label14.Text=   (arln == 0 ? "  خيارات الرسائل عند ترحيل الصندوق  " : "  Message options when migrating the box") ; label13.Text=   (arln == 0 ? "  البيع حسب سعر البيع الإفتراضي و   " : "  Selling at Virtual Selling Price and") ; chk10.Text=   (arln == 0 ? "  السماح بحفظ الفاتورة التي اجمالي قيمتها صفر  " : "  Allow to save the invoice that has a total value of zero") ; chk9.Text=   (arln == 0 ? "  السماح بحفظ رقم التصنيع في الفاتورة دون تاريخ الصلاحية  " : "  Allow to save the manufacturing number in the invoice without the validity date") ; chk8.Text=   (arln == 0 ? "  السماح بحفظ تاريخ الصلاحية في الفاتورة دون رقم التصنيع  " : "  Allow to save the validity date in the invoice without the manufacturing number") ; chk6.Text=   (arln == 0 ? "  السماح بالبيع بأقل من سعر الوحدة  " : "  Allow selling at less than unit price") ; chk5.Text=   (arln == 0 ? "  ظهور التنبيه التلقائي الخاص بالموظفين  " : "  Automatic employee alert appears") ; chk1.Text=   (arln == 0 ? "  السماح بتعديل سعر التكلفة  " : "  Allow cost price adjustment") ; chk2.Text=   (arln == 0 ? "  السماح بالبيع حتى لو ان الكمية اصغر من او يساوي الصفر  " : "  Allow selling even if the quantity is less than or equal to zero") ; chk3.Text=   (arln == 0 ? "  السماح بالبيع بسعر اقل من سعر تكلفة الصنف  " : "  Allow selling at a price lower than the cost price of the item") ; chk7.Text=   (arln == 0 ? "  ظهور سعر التكلفة في الفواتير  " : "  The cost price is shown in invoices") ; chk4.Text=   (arln == 0 ? "  السماح بالتجاوز عن الحد المديونية للعملاء والموردين  " : "  Allowing customers and suppliers to exceed the indebtedness limit") ; navigationPane_Eqar.Text=   (arln == 0 ? "  المستأجـــرين  " : "  Tenants") ; navigationPanePanel11.Text=   (arln == 0 ? "  Drop your controls here and erase Text property  " : "  Drop your controls here and erase Text property") ; EqarFiles.Text=   (arln == 0 ? "  الملفــــات  " : "  files") ; navigationPanePanel12.Text=   (arln == 0 ? "  Drop your controls here and erase Text property  " : "  Drop your controls here and erase Text property") ; EqarTenant.Text=   (arln == 0 ? "  المستأجـــرين  " : "  Tenants") ; navigationPanePanel10.Text=   (arln == 0 ? "  Drop your controls here and erase Text property  " : "  Drop your controls here and erase Text property") ; EqarsRep.Text=   (arln == 0 ? "  التقـــارير  " : "  reports") ; navigationPane_Hotel.Text=   (arln == 0 ? "  الملفـــات  " : "  files") ; navigationPanePanel6.Text=   (arln == 0 ? "  Drop your controls here and erase Text property  " : "  Drop your controls here and erase Text property") ; HotelMenuPer.Text=   (arln == 0 ? "  الملفـــات  " : "  files") ; chk13.Text=   (arln == 0 ? "  السماح بحذف سندات النزلاء المغادرين  " : "  Allow deletion of departing guest bonds") ; label18.Text=   (arln == 0 ? "  أسعار الغرف المعتمدة  " : "  Approved room rates") ; label17.Text=   (arln == 0 ? "  السعر اليومـــي :  " : "  daily price:") ; label16.Text=   (arln == 0 ? "  السعر الشهري :  " : "  Monthly price:") ; HotelGenralPre.Text=   (arln == 0 ? "  عـــــــام  " : "  general") ; navigationPanePanel8.Text=   (arln == 0 ? "  Drop your controls here and erase Text property  " : "  Drop your controls here and erase Text property") ; HotelRepPre.Text=   (arln == 0 ? "  التقـــارير  " : "  reports") ; navigationPanePanel7.Text=   (arln == 0 ? "  Drop your controls here and erase Text property  " : "  Drop your controls here and erase Text property") ; HotelMovePre.Text=   (arln == 0 ? "  الحركـــات  " : "  movements") ; navigationPane_Emps.Text=   (arln == 0 ? "  الكـــروت  " : "  the cards") ; navigationPanePanel5.Text=   (arln == 0 ? "  Drop your controls here and erase Text property  " : "  Drop your controls here and erase Text property") ; MenuPer.Text=   (arln == 0 ? "  الكـــروت  " : "  the cards") ; navigationPanePanel3.Text=   (arln == 0 ? "  Drop your controls here and erase Text property  " : "  Drop your controls here and erase Text property") ; SalPer.Text=   (arln == 0 ? "  عمليـــات الـــرواتب  " : "  Payroll Operations") ; navigationPanePanel2.Text=   (arln == 0 ? "  Drop your controls here and erase Text property  " : "  Drop your controls here and erase Text property") ; RepPre.Text=   (arln == 0 ? "  التقـــارير  " : "  reports") ; navigationPanePanel4.Text=   (arln == 0 ? "  Drop your controls here and erase Text property  " : "  Drop your controls here and erase Text property") ; MovePre.Text=   (arln == 0 ? "  الحركـــات  " : "  movements") ; GenralPre.Text=   (arln == 0 ? "  عـــــــام  " : "  general") ; groupPanel_Stores.Text=   (arln == 0 ? "  ايقاف المستودع  " : "  stop warehouse") ; label20.Text=   (arln == 0 ? "  المستودع الإفتراضي  " : "  virtual repository") ; chk22.Text=   (arln == 0 ? "  عكس الطباعة الإفتراضية  " : "  Reverse default printing") ; groupPanel_InvoiceType.Text=   (arln == 0 ? "  تغيير ورقة الطباعة حسب  " : "  Change the print paper according to") ; chk16.Text=   (arln == 0 ? "  ايقاف ترويسة التقارير  " : "  Turn off the report header") ; ribbonTabItem_General.Text=   (arln == 0 ? "  عـــام  " : "  general") ; ribbonTabItem_Files.Text=   (arln == 0 ? "  الكروت  " : "  cards") ; ribbonTabItem_ACC.Text=   (arln == 0 ? "  الحسابات  " : "  Accounts") ; ribbonTabItem_Inv.Text=   (arln == 0 ? "  الفواتير  " : "  Invoices") ; ribbonTabItem_RepStocks.Text=   (arln == 0 ? "  تقارير المخزون  " : "  Inventory Reports") ; ribbonTabItem_RepAcc.Text=   (arln == 0 ? "  تقارير الحسابات  " : "  accounts reports") ; ribbonTabItem_Emps.Text=   (arln == 0 ? "  شؤون الموظفين  " : "  Personnel Affairs") ; ribbonTabItem_Hotels.Text=   (arln == 0 ? "  إدارة الفندق  " : "  hotel management") ; ribbonTabItem_Eqar.Text=   (arln == 0 ? "  العقار  " : "  real estate") ; ribbonTabItem_Other.Text=   (arln == 0 ? "  أخرى  " : "  Other") ; buttonItem_SelectAll.Text=   (arln == 0 ? "  الكل  " : "  All") ; buttonItem_UnSelectAll.Text=   (arln == 0 ? "  إلغاء  " : "  Cancellation") ; label5.Text=   (arln == 0 ? "  الإسم الانجليزي :  " : "  English name:") ; label6.Text=   (arln == 0 ? "  الفرع الإفتراضي :  " : "  default branch:") ; label4.Text=   (arln == 0 ? "  الإسم العربي :  " : "  Arabic name:") ; label1.Text=   (arln == 0 ? "  رقم المستخدم :  " : "  user number :") ; label8.Text=   (arln == 0 ? "  اللغة الافتراضية :  " : "  default language:") ; label3.Text=   (arln == 0 ? "  تأكيد كلمة المرور :  " : "  confirm password :") ; label7.Text=   (arln == 0 ? "  حالة المستخدم :  " : "  User status:") ; label2.Text=   (arln == 0 ? "  كلمة المرور :  " : "  password :") ; superTabControl_Main1.Text=   (arln == 0 ? "  superTabControl3  " : "  superTabControl3") ; Button_Close.Text=   (arln == 0 ? "  إغلاق  " : "  Close") ; Button_Search.Text=   (arln == 0 ? "  بحث  " : "  Search") ; Button_Delete.Text=   (arln == 0 ? "  حذف  " : "  delete") ; Button_Save.Text=   (arln == 0 ? "  حفظ  " : "  save") ; Button_Add.Text=   (arln == 0 ? "  إضافة  " : "  addition") ; chk11.Text=   (arln == 0 ? "  موافقة تلقائية  " : "  automatic approval") ; superTabControl_Main2.Text=   (arln == 0 ? "  superTabControl1  " : "  superTabControl1") ; Button_First.Text=   (arln == 0 ? "  الأول  " : "  the first") ; Button_Prev.Text=   (arln == 0 ? "  السابق  " : "  the previous") ; lable_Records.Text=   (arln == 0 ? "  ---  " : "  ---") ; Button_Next.Text=   (arln == 0 ? "  التالي  " : "  next one") ; Button_Last.Text=   (arln == 0 ? "  الأخير  " : "  the last one") ; ToolStripMenuItem_Rep.Text=   (arln == 0 ? "  إظهار التقرير  " : "  Show report") ; ToolStripMenuItem_Det.Text=   (arln == 0 ? "  إظهار التفاصيل  " : "  Show details") ; panelEx3.Text=   (arln == 0 ? "  Fill Panel  " : "  Fill Panel") ; DGV_Main.Text=   (arln == 0 ? "    " : "    ") ; DGV_Main.Text=   (arln == 0 ? "  جميــع السجــــلات  " : "  All records") ; DGV_Main.Text=   (arln == 0 ? "    " : "    ") ; superTabControl_DGV.Text=   (arln == 0 ? "  superTabControl1  " : "  superTabControl1") ; textBox_search.Text=   (arln == 0 ? "  ...  " : "  ...") ; Button_ExportTable2.Text=   (arln == 0 ? "  تصدير  " : "  Export") ; /*Button_PrintTable.Text=   (arln == 0 ? "  طباعة  " : "  Print") ; */panelEx2.Text=   (arln == 0 ? "  Click to collapse  " : "  Click to collapse") ; Text = "صلاحيات المستخدمين ";this.Text=   (arln == 0 ? "  صلاحيات المستخدمين   " : "  User Permissions") ;}
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
        public Dictionary<string, ColumnDictinary> columns_Names_visible = new Dictionary<string, ColumnDictinary>();
        private HijriGreg.HijriGregDates n = new HijriGreg.HijriGregDates();
        private int LangArEn = 0;
        protected bool ifOkDelete;
        public bool CanEdit = true;
        protected bool CanInsert = true;
#pragma warning disable CS0414 // The field 'FrmUsr.FlagUpdate' is assigned but its value is never used
        private string FlagUpdate = "";
#pragma warning restore CS0414 // The field 'FrmUsr.FlagUpdate' is assigned but its value is never used
        public ViewState ViewState = ViewState.Deiles;
        private FormState statex;
        public List<Control> controls;
        public Control codeControl = new Control();
        private T_Store _Store = new T_Store();
        private List<T_Store> listStore = new List<T_Store>();
        private bool canUpdate = true;
        private T_User data_this;
        private List<string> pkeys = new List<string>();
        private Stock_DataDataContext dbInstanceStock;
        private Rate_DataDataContext dbInstance;
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
            //this.WindowState = FormWindowState.Minimized;
            //this.WindowState = FormWindowState.Maximized;
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
        protected ToolStripMenuItem ToolStripMenuItem_Rep;
        private RibbonBar ribbonBar1;
        private ImageList imageList1;
        protected ContextMenuStrip contextMenuStrip1;
        protected ContextMenuStrip contextMenuStrip2;
        protected ToolStripMenuItem ToolStripMenuItem_Det;
        protected IntegerInput Rep_RecCount;
        private System.Windows.Forms.OpenFileDialog  openFileDialog1;
        private Timer timerInfoBallon;
        private System.Windows.Forms. SaveFileDialog saveFileDialog1;
        private PanelEx panelEx3;
        private Timer timer1;
        private PanelEx panelEx2;
        private ExpandableSplitter expandableSplitter1;
        private Panel panel1;
        private Label label5;
        private TextBox txtUserNameE;
        private TextBox txtPassConf;
        private TextBox txtPass;
        private TextBox textBox_ID;
        private Label label8;
        private Label label6;
        private Label label7;
        private Label label4;
        private Label label3;
        private Label label2;
        private TextBox txtUserName;
        private Label label1;
        private ComboBoxEx CmbStatus;
        private ComboBoxEx CmbLanguge;
        private ComboBoxEx CmbBranch;
        private RibbonControl ribbonControl_Setting;
        private ButtonItem buttonItem1;
        private RibbonPanel ribbonPanel1;
        private RibbonTabItem ribbonTabItem_Files;
        private RibbonPanel ribbonPanel2;
        private C1FlexGrid FlxFiles;
        private RibbonPanel ribbonPanel3;
        private RibbonPanel ribbonPanel4;
        private RibbonPanel ribbonPanel5;
        private RibbonPanel ribbonPanel6;
        private RibbonTabItem ribbonTabItem_Inv;
        private RibbonTabItem ribbonTabItem_ACC;
        private RibbonTabItem ribbonTabItem_RepStocks;
        private RibbonTabItem ribbonTabItem_RepAcc;
        private RibbonTabItem ribbonTabItem_General;
        private C1FlexGrid FlxInvoices;
        private C1FlexGrid FlxAccounting;
        private C1FlexGrid FlxSRep;
        private RibbonPanel ribbonPanel7;
        private RibbonTabItem ribbonTabItem_Other;
        private QatCustomizeItem qatCustomizeItem1;
        private ButtonItem buttonItem_SelectAll;
        private ButtonItem buttonItem_UnSelectAll;
        private C1FlexGrid FlxAccRep;
        private CheckBoxX chk1;
        private CheckBoxX chk2;
        private CheckBoxX chk3;
        private CheckBoxX chk7;
        private CheckBoxX chk4;
        private CheckBoxX chk5;
        private CheckBoxX chk6;
        private RibbonBar ribbonBar_Tasks;
        private SuperTabControl superTabControl_Main1;
        protected ButtonItem Button_Close;
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
        private C1FlexGrid FlxSetups;
        private RibbonPanel ribbonPanel8;
        private RibbonTabItem ribbonTabItem_Emps;
        private NavigationPane navigationPane_Emps;
        private NavigationPanePanel navigationPanePanel5;
        private C1FlexGrid dataGridViewX_MenuPer;
        private ButtonItem MenuPer;
        private NavigationPanePanel navigationPanePanel4;
        private C1FlexGrid dataGridViewX_MovePre;
        private ButtonItem MovePre;
        private NavigationPanePanel navigationPanePanel3;
        private C1FlexGrid dataGridViewX_SalPer;
        private ButtonItem SalPer;
        private NavigationPanePanel navigationPanePanel2;
        private C1FlexGrid dataGridViewX_RepPre;
        private ButtonItem RepPre;
        private NavigationPanePanel navigationPanePanel1;
        private C1FlexGrid dataGridViewX_GenralPre;
        private ButtonItem GenralPre;
        private LabelItem lable_Records;
        private CheckBoxX chk8;
        private CheckBoxX chk9;
        private GroupBox groupBox_Comm;
        private Label label9;
        private Label label10;
        protected Label label11;
        private DoubleInput textBox_CommGaid;
        protected Label label12;
        private DoubleInput textBox_CommInv;
        private CheckBoxX chk10;
        private SwitchButton switchButton_AdminOp;
        private ComboBoxEx CmbInvPrice;
        private Label label13;
        private ComboBoxEx CmbSendOption;
        private Label label14;
        private ComboBoxEx CmbInvPriceStop;
        private Label label15;
        private CheckBoxX chk12;
        private RibbonPanel ribbonTabItem_Hotel;
        private RibbonTabItem ribbonTabItem_Hotels;
        private NavigationPane navigationPane_Hotel;
        private NavigationPanePanel navigationPanePanel6;
        private C1FlexGrid dataGridViewX_HotelMenuPer;
        private ButtonItem HotelMenuPer;
        private NavigationPanePanel navigationPanePanel7;
        private C1FlexGrid dataGridViewX_HotelMovePre;
        private ButtonItem HotelMovePre;
        private NavigationPanePanel navigationPanePanel8;
        private C1FlexGrid dataGridViewX_HotelRepPre;
        private ButtonItem HotelRepPre;
        private NavigationPanePanel navigationPanePanel9;
        private C1FlexGrid dataGridViewX_HotelGenralPre;
        private ButtonItem HotelGenralPre;
        private ComboBoxEx CmbCommTyp;
        private Label label19;
        private Panel panel_Prices;
        private CheckBoxX chk13;
        private Label label18;
        private ComboBoxEx Combo1;
        private Label label17;
        private ComboBoxEx Combo3;
        private Label label16;
        private CheckBoxX chk14;
        private GroupPanel groupPanel_InvoiceType;
        private C1FlexGrid FlexType;
        private CheckBoxX chk15;
        private GroupPanel groupPanel_Stores;
        private C1FlexGrid FlxStkQty;
        private ComboBoxEx CmbStores;
        private Label label20;
        private CheckBoxX chk16;
        private SwitchButton switchButton_ControlHeadOFRep;
        private CheckBoxX chk17;
        private CheckBoxX chk18;
        private CheckBoxX chk19;
        private CheckBoxX chk20;
        private CheckBoxX chk21;
        private GroupPanel groupPanel_Banner;
        private PictureBox PicItemImg;
        private ButtonX button_ClearPic;
        private ButtonX button_EnterImg;
        private Label label21;
        private IntegerInput txtHeight;
        private Label label34;
        private IntegerInput txtWidth;
        private CheckBoxX chk22;
        private GroupBox groupBox1;
        private Label label23;
        protected Label label25;
        private DoubleInput textBox_MaxDis;
        private CheckBoxX chk23;
        private RibbonPanel ribbonPanel9;
        private RibbonTabItem ribbonTabItem_Eqar;
        private NavigationPane navigationPane_Eqar;
        private NavigationPanePanel navigationPanePanel12;
        private C1FlexGrid dataGridViewX_Tenants;
        private ButtonItem EqarTenant;
        private NavigationPanePanel navigationPanePanel13;
        private C1FlexGrid dataGridViewX_GenralEqar;
        private ButtonItem EqarGenarl;
        private NavigationPanePanel navigationPanePanel10;
        private C1FlexGrid dataGridViewX_RepEqar;
        private ButtonItem EqarsRep;
        private NavigationPanePanel navigationPanePanel11;
        private C1FlexGrid dataGridViewX_EqarFiles;
        private CheckBoxItem chk11;
        private ButtonItem EqarFiles;
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
        public T_User DataThis
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
        private Stock_DataDataContext db
        {
            get
            {
                if (dbInstanceStock == null)
                {
                    dbInstanceStock = new Stock_DataDataContext(VarGeneral.BranchCS);
                }
                return dbInstanceStock;
            }
        }
        private Rate_DataDataContext dbc
        {
            get
            {
                if (dbInstance == null)
                {
                    dbInstance = new Rate_DataDataContext(VarGeneral.BranchRt);
                }
                return dbInstance;
            }
        }
        public void RefreshPKeys()
        {
            PKeys.Clear();
            var qkeys = from item in dbc.T_Users
                        orderby item.UsrNo
                        where item.Usr_ID != 1
                        select new
                        {
                            Code = item.UsrNo + ""
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
        public FrmUsr()
        {
            InitializeComponent();this.Load += langloads;
            textBox_ID.Click += Button_Edit_Click;
            txtWidth.Click += Button_Edit_Click;
            txtHeight.Click += Button_Edit_Click;
            txtPass.Click += Button_Edit_Click;
            txtPassConf.Click += Button_Edit_Click;
            txtUserName.Click += Button_Edit_Click;
            txtUserNameE.Click += Button_Edit_Click;
            CmbBranch.Click += Button_Edit_Click;
            CmbLanguge.Click += Button_Edit_Click;
            CmbStatus.Click += Button_Edit_Click;
            CmbStores.Click += Button_Edit_Click;
            CmbInvPrice.Click += Button_Edit_Click;
            CmbInvPriceStop.Click += Button_Edit_Click;
            CmbSendOption.Click += Button_Edit_Click;
            FlxAccounting.Click += Button_Edit_Click;
            FlxAccRep.Click += Button_Edit_Click;
            FlxFiles.Click += Button_Edit_Click;
            FlexType.Click += Button_Edit_Click;
            FlxStkQty.Click += Button_Edit_Click;
            textBox_CommInv.Click += Button_Edit_Click;
            textBox_CommGaid.Click += Button_Edit_Click;
            switchButton_AdminOp.Click += Button_Edit_Click;
            textBox_MaxDis.Click += Button_Edit_Click;
            chk1.Click += Button_Edit_Click;
            chk2.Click += Button_Edit_Click;
            chk3.Click += Button_Edit_Click;
            chk4.Click += Button_Edit_Click;
            chk5.Click += Button_Edit_Click;
            chk6.Click += Button_Edit_Click;
            chk7.Click += Button_Edit_Click;
            chk8.Click += Button_Edit_Click;
            chk9.Click += Button_Edit_Click;
            chk10.Click += Button_Edit_Click;
            chk11.Click += Button_Edit_Click;
            chk12.Click += Button_Edit_Click;
            chk13.Click += Button_Edit_Click;
            chk14.Click += Button_Edit_Click;
            chk15.Click += Button_Edit_Click;
            chk16.Click += Button_Edit_Click;
            chk17.Click += Button_Edit_Click;
            chk18.Click += Button_Edit_Click;
            chk19.Click += Button_Edit_Click;
            chk20.Click += Button_Edit_Click;
            chk21.Click += Button_Edit_Click;
            chk22.Click += Button_Edit_Click;
            chk23.Click += Button_Edit_Click;
            switchButton_ControlHeadOFRep.Click += Button_Edit_Click;
            FlxInvoices.Click += Button_Edit_Click;
            FlxSetups.Click += Button_Edit_Click;
            FlxSRep.Click += Button_Edit_Click;
            dataGridViewX_GenralPre.Click += Button_Edit_Click;
            dataGridViewX_MenuPer.Click += Button_Edit_Click;
            dataGridViewX_MovePre.Click += Button_Edit_Click;
            dataGridViewX_RepPre.Click += Button_Edit_Click;
            dataGridViewX_SalPer.Click += Button_Edit_Click;
            dataGridViewX_HotelMenuPer.Click += Button_Edit_Click;
            dataGridViewX_HotelMovePre.Click += Button_Edit_Click;
            dataGridViewX_HotelRepPre.Click += Button_Edit_Click;
            dataGridViewX_HotelGenralPre.Click += Button_Edit_Click;
            dataGridViewX_EqarFiles.Click += Button_Edit_Click;
            dataGridViewX_GenralEqar.Click += Button_Edit_Click;
            dataGridViewX_RepEqar.Click += Button_Edit_Click;
            dataGridViewX_Tenants.Click += Button_Edit_Click;
            Combo1.Click += Button_Edit_Click;
            Combo3.Click += Button_Edit_Click;
            CmbCommTyp.Click += Button_Edit_Click;
            DGV_Main.PrimaryGrid.CheckBoxes = false;
            DGV_Main.PrimaryGrid.ShowCheckBox = false;
            DGV_Main.PrimaryGrid.ShowTreeButton = false;
            DGV_Main.PrimaryGrid.ShowTreeButtons = false;
            DGV_Main.PrimaryGrid.ShowTreeLines = false;
            DGV_Main.PrimaryGrid.RowHeaderWidth = 25;
            DGV_Main.MouseDown += DGV_Main_MouseDown;
            DGV_Main.CellDoubleClick += DGV_Main_CellDoubleClick;
            DGV_Main.CellClick += DGV_Main_CellClick;
            DGV_Main.GetCellStyle += DGV_MainGetCellStyle;
            DGV_Main.CellDoubleClick += DGV_Main_CellDoubleClick;
            DGV_Main.DataBindingComplete += DGV_Main_DataBindingComplete;
            expandableSplitter1.Click += expandableSplitter1_Click;
            ToolStripMenuItem_Det.Click += ToolStripMenuItem_Det_Click;
            Button_ExportTable2.Click += Button_ExportTable2_Click;
            DGV_Main.GetCellStyle += DGV_MainGetCellStyle;
            textBox_search.InputTextChanged += TextBox_Search_InputTextChanged;
            textBox_search.ButtonCustomClick += TextBox_Search_ButtonCustomClick;
            TextBox_Index.InputTextChanged += TextBox_Index_InputTextChanged;
            Button_Close.Click += Button_Close_Click;
            Button_First.Click += Button_First_Click;
            Button_Prev.Click += Button_Prev_Click;
            Button_Next.Click += Button_Next_Click;
            Button_Last.Click += Button_Last_Click;
            Button_Add.Click += Button_Add_Click;
            Button_Search.Click += Button_Search_Click;
            Button_Delete.Click += Button_Delete_Click;
            Button_Save.Click += Button_Save_Click;
            TextBox_Index.InputTextChanged += TextBox_Index_InputTextChanged;
            Button_PrintTable.Click += Button_Print_Click;
            if (VarGeneral.SSSLev != "D" && VarGeneral.SSSLev != "E")
            {
                ribbonTabItem_Emps.Visible = false;
            }
            if (VarGeneral.SSSTyp == 0)
            {
                label14.Visible = false;
                CmbSendOption.Visible = false;
                if (VarGeneral.SSSLev == "M")
                {
                    chk4.Visible = false;
                    ribbonTabItem_ACC.Visible = false;
                }
                ribbonTabItem_RepAcc.Visible = false;
            }
            else if (VarGeneral.SSSTyp == 1)
            {
                ribbonTabItem_Inv.Visible = false;
                ribbonTabItem_Other.Visible = false;
            }
            if (VarGeneral.SSSLev != "H" && VarGeneral.SSSLev != "X")
            {
                ribbonTabItem_Hotels.Visible = false;
            }
            if (VarGeneral.SSSLev != "Q")
            {
                ribbonTabItem_Eqar.Visible = false;
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
        public void Button_Search_Click(object sender, EventArgs e)
        {
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, ""));
            }
            VarGeneral.SFrmTyp = "T_User";
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != "")
            {
                textBox_ID.Text = frm.SerachNo.ToString();
            }
        }
        public void Button_First_Click(object sender, EventArgs e)
        {
            if (ContinueIfEditOrNew())
            {
                TextBox_Index.TextBox.Text = string.Concat(1);
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
        private void TextBox_Search_InputTextChanged(object sender)
        {
            Fill_DGV_Main();
        }
        private void TextBox_Search_ButtonCustomClick(object sender, EventArgs e)
        {
            textBox_search.Text = "";
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
            List<T_User> list = dbc.FillUsr_2(textBox_search.TextBox.Text).ToList();
            if (DGV_Main.PrimaryGrid.Columns.Count == 0)
            {
                foreach (KeyValuePair<string, ColumnDictinary> item in columns_Names_visible)
                {
                    DGV_Main.PrimaryGrid.Columns.Add(new GridColumn(item.Key));
                }
            }
            FillHDGV(list);
        }
        public void FillHDGV(IEnumerable<T_User> new_data_enum)
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
            DGV_Main.PrimaryGrid.DataMember = "T_User";
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
        protected override void OnParentRightToLeftChanged(EventArgs e)
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmUsr));
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
                Button_PrintTable.Text = ((VarGeneral.GeneralPrinter.nTyp_Setting.Substring(2, 1) == "0") ? "طباعة" : "عــرض");
                Button_PrintTable.Tooltip = "F5";
                Button_ExportTable2.Text = "تصدير";
                Button_ExportTable2.Tooltip = "F10";
                DGV_Main.PrimaryGrid.GroupByRow.Text = "جميع السجلات";
                label1.Text = "رقم المستخدم :";
                label2.Text = "كلمة المرور :";
                label3.Text = "تأكيد كلمة المرور :";
                label4.Text = "الإسم العربي :";
                label5.Text = "الإسم الانجليزي :";
                label6.Text = "الفرع الإفتراضي :";
                label7.Text = "حالة المستخدم :";
                label8.Text = "اللغة الافتراضية :";
                ribbonTabItem_General.Text = "عـــام";
                ribbonTabItem_ACC.Text = "الحسابات";
                ribbonTabItem_Files.Text = "الكروت";
                ribbonTabItem_Inv.Text = "الفواتير";
                ribbonTabItem_Other.Text = "أخرى";
                ribbonTabItem_RepAcc.Text = "تقارير الحسابات";
                ribbonTabItem_RepStocks.Text = "تقارير المخزون";
                ribbonTabItem_Emps.Text = "شؤون الموظفين";
                ribbonTabItem_Hotel.Text = "إدارة الفندق";
                MenuPer.Text = "الكـــروت";
                MenuPer.Tooltip = "إضغط هنا لعرض صلاحيات الكــروت";
                MovePre.Text = "الحركـــات";
                MovePre.Tooltip = "إضغط هنا لعرض صلاحيات الحــركــة";
                SalPer.Text = "عمليـــات الـــرواتب";
                SalPer.Tooltip = "إضغط هنا لعرض صلاحيات الــرواتــب";
                RepPre.Text = "التقـــارير";
                RepPre.Tooltip = "إضغط هنا لعرض صلاحيات التقـــارير";
                GenralPre.Text = "عـــــــام";
                GenralPre.Tooltip = "إضغط هنا لعرض الصلاحيــات العـامة";
                HotelMenuPer.Text = "الملفــــات";
                HotelMenuPer.Tooltip = "إضغط هنا لعرض صلاحيات الملفــــات";
                HotelMovePre.Text = "الحركـــات";
                HotelMovePre.Tooltip = "إضغط هنا لعرض صلاحيات الحــركــة";
                HotelRepPre.Text = "التقـــارير";
                HotelRepPre.Tooltip = "إضغط هنا لعرض صلاحيات التقـــارير";
                HotelGenralPre.Text = "عـــــــام";
                HotelGenralPre.Tooltip = "إضغط هنا لعرض الصلاحيــات العـامة";
                Text = "صلاحيات المستخدمين";
                buttonItem_SelectAll.Text = "تحديد الكل";
                buttonItem_UnSelectAll.Text = "إلغاء التحديد";
                switchButton_AdminOp.OffText = "مسؤول الموافقات";
                switchButton_AdminOp.OnText = "مسؤول الموافقات";
                chk11.Text = "موافقة تلقائية";
                groupPanel_InvoiceType.Text = "تغيير ورقة الطباعة حسب";
                groupPanel_Stores.Text = "ايقاف المستودع";
                switchButton_ControlHeadOFRep.OffText = "التحكم في الترويسة";
                switchButton_ControlHeadOFRep.OnText = "التحكم في الترويسة";
                if (VarGeneral.SSSTyp == 0)
                {
                    groupBox_Comm.Text = "نسبة عمولة المستخدم في المبيعات";
                }
                else if (VarGeneral.SSSTyp == 1)
                {
                    groupBox_Comm.Text = "نسبة عمولة المستخدم في الإيرادات";
                }
                else
                {
                    groupBox_Comm.Text = "نسبة عمولة المستخـــدم في";
                }
                groupPanel_Banner.Text = "صورة المستخدم";
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
                Button_PrintTable.Text = ((VarGeneral.GeneralPrinter.nTyp_Setting.Substring(2, 1) == "0") ? "Print" : "Show");
                Button_PrintTable.Tooltip = "F5";
                Button_ExportTable2.Text = "Export";
                Button_ExportTable2.Tooltip = "F10";
                DGV_Main.PrimaryGrid.GroupByRow.Text = "All Records";
                label1.Text = "User No :";
                label2.Text = "Password :";
                label3.Text = "Password Confirm :";
                label4.Text = "Name - Arabic :";
                label5.Text = "Name - English :";
                label6.Text = "Branch :";
                label7.Text = "User State :";
                label8.Text = "Language :";
                ribbonTabItem_General.Text = "General";
                ribbonTabItem_ACC.Text = "Accounts";
                ribbonTabItem_Files.Text = "Cards";
                ribbonTabItem_Inv.Text = "Invoices";
                ribbonTabItem_Other.Text = "Other";
                ribbonTabItem_RepAcc.Text = "Accounting Reports";
                ribbonTabItem_RepStocks.Text = "Inventory Reports";
                ribbonTabItem_Emps.Text = "Emp";
                ribbonTabItem_Hotel.Text = "Hotel";
                Text = "Users Permissions";
                buttonItem_SelectAll.Text = "Select All";
                buttonItem_UnSelectAll.Text = "UnSelect";
                switchButton_AdminOp.OffText = "Official approvals";
                switchButton_AdminOp.OnText = "Official approvals";
                switchButton_ControlHeadOFRep.OffText = "Control of Header";
                switchButton_ControlHeadOFRep.OnText = "Control of Header";
                if (VarGeneral.SSSTyp == 0)
                {
                    groupBox_Comm.Text = "Percentage commission user in Sales";
                }
                else if (VarGeneral.SSSTyp == 1)
                {
                    groupBox_Comm.Text = "Percentage commission user in Bounds";
                }
                else
                {
                    groupBox_Comm.Text = "Percentage commission user in";
                }
                chk11.Text = "Auto approval";
                groupPanel_InvoiceType.Text = "Change printing sheet by";
                groupPanel_Stores.Text = "Store Stop";
                groupPanel_Banner.Text = "User Pic";
            }
        }
        private void FrmUsr_Load(object sender, EventArgs e)
        {
            try
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmUsr));
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                {
                    Language.ChangeLanguage("ar-SA", this, resources);
                    ribbonControl_Setting.RightToLeft = RightToLeft.Yes;
                    LangArEn = 0;
                }
                else
                {
                    Language.ChangeLanguage("en", this, resources);
                    ribbonControl_Setting.RightToLeft = RightToLeft.No;
                    LangArEn = 1;
                }
                ADD_Controls();
                if (VarGeneral.SSSTyp == 0)
                {
                    label2.Visible = false;
                    label10.Visible = false;
                    label3.Visible = false;
                    if (LangArEn == 1)
                    {
                        label9.Visible = false;
                    }
                    label11.Visible = false;
                    label12.Visible = false;
                    textBox_CommGaid.Visible = false;
                    textBox_CommInv.Width = 177;
                    textBox_CommInv.Location = new Point(30, 37);
                    Refresh();
                }
                else if (VarGeneral.SSSTyp == 1)
                {
                    label12.Visible = false;
                    label11.Visible = false;
                    label2.Visible = false;
                    label10.Visible = false;
                    label3.Visible = false;
                    if (LangArEn == 1)
                    {
                        label9.Visible = false;
                    }
                    textBox_CommInv.Visible = false;
                    textBox_CommGaid.Width = 177;
                    textBox_CommGaid.Location = new Point(30, 37);
                    groupBox1.Visible = false;
                    Refresh();
                }
                if (columns_Names_visible.Count == 0)
                {
                    columns_Names_visible.Add("UsrNo", new ColumnDictinary("الرقم ", " No", ifDefault: true, ""));
                    columns_Names_visible.Add("UsrNamA", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, ""));
                    columns_Names_visible.Add("UsrNamE", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, ""));
                }
                else
                {
                    Clear();
                    textBox_ID.Text = "";
                    TextBox_Index.TextBox.Text = "";
                }
                listStore = db.FillStore_2("").ToList();
                FlxStkQty.Rows.Count = listStore.Count;
                for (int iiCnt = 0; iiCnt < listStore.Count; iiCnt++)
                {
                    _Store = listStore[iiCnt];
                    FlxStkQty.SetData(iiCnt, 0, _Store.Stor_ID.ToString());
                    FlxStkQty.SetData(iiCnt, 1, false);
                    FlxStkQty.SetData(iiCnt, 2, ((LangArEn == 0) ? _Store.Arb_Des : _Store.Eng_Des).ToString());
                }
                RefreshPKeys();
                FillFlex();
                FillCombo();
                textBox_ID.Text = PKeys.FirstOrDefault();
                ViewDetails_Click(sender, e);
                UpdateVcr();
                if (VarGeneral.vDemo && VarGeneral.UserID != 1)
                {
                    panel_Prices.Visible = false;
                }
                if (File.Exists(Application.StartupPath + "\\Script\\SecriptTegnicalCollage.dll"))
                {
                    TegnicalCollage();
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Load:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void TegnicalCollage()
        {
            groupBox_Comm.Visible = false;
            label19.Visible = false;
            CmbCommTyp.Visible = false;
        }
        private void FillCombo()
        {
            int _CmbIndex = 0;
            RibunButtons();
            CmbInvPrice.Items.Clear();
            CmbInvPriceStop.Items.Clear();
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                CmbInvPrice.Items.Add("   ");
                CmbInvPrice.Items.Add("الإفتراضي فقط");
                CmbInvPrice.Items.Add("سعر الجملة");
                CmbInvPrice.Items.Add("سعر الموزع");
                CmbInvPrice.Items.Add("سعر المندوب");
                CmbInvPrice.Items.Add("سعر التجزئة");
                CmbInvPrice.Items.Add("سعر آخر");
                CmbInvPriceStop.Items.Add("   ");
                CmbInvPriceStop.Items.Add("الإفتراضي فقط");
                CmbInvPriceStop.Items.Add("سعر الجملة");
                CmbInvPriceStop.Items.Add("سعر الموزع");
                CmbInvPriceStop.Items.Add("سعر المندوب");
                CmbInvPriceStop.Items.Add("سعر التجزئة");
                CmbInvPriceStop.Items.Add("سعر آخر");
                Combo1.Items.Clear();
                Combo1.Items.Add("السعر الأول");
                Combo1.Items.Add("السعر الثاني");
                Combo1.SelectedIndex = 0;
                Combo3.Items.Clear();
                Combo3.Items.Add("السعر الأول");
                Combo3.Items.Add("السعر الثاني");
                Combo3.SelectedIndex = 0;
                CmbCommTyp.Items.Clear();
                CmbCommTyp.Items.Add("نسبة مئوية");
                CmbCommTyp.Items.Add("مبلغ ثابت");
                CmbCommTyp.SelectedIndex = 0;
            }
            else
            {
                CmbInvPrice.Items.Add("   ");
                CmbInvPrice.Items.Add("Only Default");
                CmbInvPrice.Items.Add("Wholesale price");
                CmbInvPrice.Items.Add("Distributor price");
                CmbInvPrice.Items.Add("Legates Price");
                CmbInvPrice.Items.Add("Retail price");
                CmbInvPrice.Items.Add("Other price");
                CmbInvPriceStop.Items.Add("   ");
                CmbInvPriceStop.Items.Add("Only Default");
                CmbInvPriceStop.Items.Add("Wholesale price");
                CmbInvPriceStop.Items.Add("Distributor price");
                CmbInvPriceStop.Items.Add("Legates Price");
                CmbInvPriceStop.Items.Add("Retail price");
                CmbInvPriceStop.Items.Add("Other price");
                Combo1.Items.Clear();
                Combo1.Items.Add("First Price");
                Combo1.Items.Add("Second Price");
                Combo1.SelectedIndex = 0;
                Combo3.Items.Clear();
                Combo3.Items.Add("First Price");
                Combo3.Items.Add("Second Price");
                Combo3.SelectedIndex = 0;
                CmbCommTyp.Items.Clear();
                CmbCommTyp.Items.Add("percent %");
                CmbCommTyp.Items.Add("fixed amount");
                CmbCommTyp.SelectedIndex = 0;
            }
            CmbInvPrice.SelectedIndex = _CmbIndex;
            CmbInvPriceStop.SelectedIndex = _CmbIndex;
            CmbSendOption.Items.Clear();
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                CmbSendOption.Items.Add("تحكم ذاتي");
                CmbSendOption.Items.Add("إرسال إيميل");
                CmbSendOption.Items.Add("إرسال رسالة نصية");
                CmbSendOption.Items.Add("الكل");
            }
            else
            {
                CmbSendOption.Items.Add("Self-control");
                CmbSendOption.Items.Add("Send Email");
                CmbSendOption.Items.Add("Send SMS");
                CmbSendOption.Items.Add("ALL");
            }
            CmbSendOption.SelectedIndex = 0;
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                _CmbIndex = CmbStatus.SelectedIndex;
                CmbStatus.Items.Clear();
                CmbStatus.Items.Add("يعمل");
                CmbStatus.Items.Add("إيقاف");
                CmbStatus.SelectedIndex = 0;
                _CmbIndex = CmbLanguge.SelectedIndex;
                CmbLanguge.Items.Clear();
                CmbLanguge.Items.Add("عربي");
                CmbLanguge.Items.Add("أنجليزي");
                CmbLanguge.SelectedIndex = 0;
                _CmbIndex = CmbBranch.SelectedIndex;
                List<T_Branch> listBranch = new List<T_Branch>(dbc.T_Branches.Select((T_Branch item) => item).ToList());
                CmbBranch.DataSource = listBranch;
                CmbBranch.DisplayMember = "Branch_Name";
                CmbBranch.ValueMember = "Branch_no";
                CmbBranch.SelectedIndex = _CmbIndex;
                _CmbIndex = CmbStores.SelectedIndex;
                List<T_Store> _StoresLst = new List<T_Store>(db.T_Stores.OrderBy((T_Store item) => item.Stor_ID).ToList());
                _StoresLst.Insert(0, new T_Store());
                CmbStores.DataSource = _StoresLst;
                CmbStores.DisplayMember = "Arb_Des";
                CmbStores.ValueMember = "Stor_ID";
                CmbStores.SelectedIndex = _CmbIndex;
                FlxFiles.SetData(0, 0, "*");
                FlxFiles.SetData(0, 1, "تفعيل");
                FlxFiles.SetData(0, 2, "إضافة");
                FlxFiles.SetData(0, 3, "تعديل");
                FlxFiles.SetData(0, 4, "حذف");
                FlxFiles.SetData(1, 0, "التصنيف");
                FlxFiles.SetData(2, 0, "تعريف صنف");
                FlxFiles.SetData(3, 0, "الوحدات");
                FlxFiles.SetData(4, 0, "العملات");
                FlxFiles.SetData(5, 0, "مركز التكلفة");
                FlxFiles.SetData(6, 0, "بيانات الفروع");
                FlxFiles.SetData(7, 0, "المندوبين");
                FlxFiles.SetData(8, 0, "المستودعات");
                FlxFiles.SetData(9, 0, "بيانات العملاء");
                FlxFiles.SetData(10, 0, "بيانات الموردين");
                FlxFiles.SetData(11, 0, "بيانات الموظفين");
                FlxFiles.SetData(12, 0, "نادل المطعم");
                FlxFiles.SetData(13, 0, "سائقين المطعم");
                FlxFiles.SetData(14, 0, "الإضافات الخاصة");
                FlxFiles.SetData(15, 0, "شاشة التنفيذ   ");
                if (VarGeneral.SSSTyp == 0)
                {
                    if (VarGeneral.SSSLev == "M")
                    {
                        FlxFiles.Rows[9].Visible = false;
                        FlxFiles.Rows[10].Visible = false;
                    }
                    FlxFiles.Rows[5].Visible = false;
                    FlxFiles.Rows[11].Visible = false;
                }
                else if (VarGeneral.SSSTyp == 1)
                {
                    FlxFiles.Rows[1].Visible = false;
                    FlxFiles.Rows[2].Visible = false;
                    FlxFiles.Rows[3].Visible = false;
                    FlxFiles.Rows[8].Visible = false;
                    FlxFiles.Rows[11].Visible = false;
                }
                if (VarGeneral.SSSLev == "D" || VarGeneral.SSSLev == "E")
                {
                    FlxFiles.Rows[11].Visible = false;
                }
                if (VarGeneral.SSSLev == "S")
                {
                    FlxFiles.Rows[5].Visible = false;
                }
                if (Program.iscarversion())
                {
                    FlxFiles.Rows[15].Visible = true;
                }
                else
                    FlxFiles.Rows[15].Visible = false;
                if (VarGeneral.SSSLev != "R" || VarGeneral.SSSLev == "C" || VarGeneral.SSSLev != "H")
                {
                    FlxFiles.Rows[12].Visible = false;
                    FlxFiles.Rows[13].Visible = false;
                    FlxFiles.Rows[14].Visible = false;
                }
                FlxInvoices.SetData(0, 0, "*");
                FlxInvoices.SetData(0, 1, "تفعيل");
                FlxInvoices.SetData(0, 2, "إضافة");
                FlxInvoices.SetData(0, 3, "تعديل");
                FlxInvoices.SetData(0, 4, "حذف");
                FlxInvoices.SetData(1, 0, "المبيعات");
                FlxInvoices.SetData(2, 0, "مرتجع المبيعات");
                FlxInvoices.SetData(3, 0, "المشتريات");
                FlxInvoices.SetData(4, 0, "مرتجع المشتريات");
                FlxInvoices.SetData(5, 0, "عرض سعر للعملاء");
                FlxInvoices.SetData(6, 0, "عرض سعر للموردين");
                FlxInvoices.SetData(7, 0, "طلب شراء");
                FlxInvoices.SetData(8, 0, "بضاعة اول المدة");
                FlxInvoices.SetData(9, 0, "إدخال بضاعة");
                FlxInvoices.SetData(10, 0, "إخراج بضاعة");
                FlxInvoices.SetData(11, 0, "صرف بضاعة");
                FlxInvoices.SetData(12, 0, "مرتجع صرف بضاعة");
                FlxInvoices.SetData(13, 0, "فاتورة تسوية البضاعة");
                FlxInvoices.SetData(14, 0, "العـــروض الخــاصــة");
                FlxAccounting.SetData(0, 0, "*");
                FlxAccounting.SetData(0, 1, "تفعيل");
                FlxAccounting.SetData(0, 2, "إضافة");
                FlxAccounting.SetData(0, 3, "تعديل");
                FlxAccounting.SetData(0, 4, "حذف");
                FlxAccounting.SetData(1, 0, "تصنيف الحسابات");
                FlxAccounting.SetData(2, 0, "كرت الحسابات");
                FlxAccounting.SetData(3, 0, "القيود اليومية");
                FlxAccounting.SetData(4, 0, "سند قبض");
                FlxAccounting.SetData(5, 0, "سند صرف");
                FlxAccounting.SetData(6, 0, "البنــوك");
                FlxAccounting.SetData(7, 0, "فــروع البنــوك");
                FlxAccounting.SetData(8, 0, "أوراق القبض والدفع");
                FlxAccounting.SetData(9, 0, "عمليات السحب والإيداع");
                FlxAccounting.SetData(10, 0, "إدارة الصناديق - الخزينة");
                if (VarGeneral.SSSTyp == 0)
                {
                    if (VarGeneral.SSSLev == "M")
                    {
                        FlxAccounting.Visible = false;
                    }
                    FlxAccounting.Rows[1].Visible = false;
                    FlxAccounting.Rows[2].Visible = false;
                    FlxAccounting.Rows[3].Visible = false;
                    FlxAccounting.Rows[6].Visible = false;
                    FlxAccounting.Rows[7].Visible = false;
                    FlxAccounting.Rows[8].Visible = false;
                    FlxAccounting.Rows[9].Visible = false;
                    FlxAccounting.Rows[10].Visible = false;
                }
                FlxAccounting.Rows[7].Visible = false;
                FlxSRep.SetData(0, 0, "*");
                FlxSRep.SetData(0, 1, "*");
                FlxSRep.SetData(0, 2, "تفعيل");
                FlxSRep.SetData(1, 1, "بيانات الأصناف");
                FlxSRep.SetData(2, 1, "بيانات الأصناف وكمياتها");
                FlxSRep.SetData(3, 1, "بيانات الأصناف وتكلفتها");
                FlxSRep.SetData(4, 1, "حركة صنف");
                FlxSRep.SetData(5, 1, "الأصناف بتاريخ الصلاحية وحركاتها");
                FlxSRep.SetData(6, 1, "الأصناف الواجب توفرها");
                FlxSRep.SetData(7, 1, "الأصناف الراكدة");
                FlxSRep.SetData(8, 1, "طباعة حركة صنف");
                FlxSRep.SetData(9, 1, "تقرير حركة صنف في فواتير المبيعات");
                FlxSRep.SetData(10, 1, "تقرير حركة صنف في فواتير مرتجع المبيعات");
                FlxSRep.SetData(11, 1, "تقرير حركة صنف في فواتير المشتريات");
                FlxSRep.SetData(12, 1, "تقرير حركة صنف في فواتير مرتجع المشتريات");
                FlxSRep.SetData(13, 1, "تقرير حركة صنف في فواتير عرض سعر العملاء");
                FlxSRep.SetData(14, 1, "تقرير حركة صنف في فواتير عرض سعر الموردين");
                FlxSRep.SetData(15, 1, "تقرير حركة صنف في فواتير امر الشراء");
                FlxSRep.SetData(16, 1, "تقرير حركة صنف في فواتير بضاعة اول المدة");
                FlxSRep.SetData(17, 1, "تقرير حركة صنف في فواتير إدخال بضاعة");
                FlxSRep.SetData(18, 1, "تقرير حركة صنف في فواتير إخراج بضاعة");
                FlxSRep.SetData(19, 1, "تقرير حركة صنف في فواتير صرف بضاعة");
                FlxSRep.SetData(20, 1, "تقرير حركة صنف في فواتير مرتجع صرف بضاعة");
                FlxSRep.SetData(21, 1, "تقرير حركة صنف في فواتير تسوية البضاعة");
                FlxSRep.SetData(22, 1, "أرصدة العملاء");
                FlxSRep.SetData(23, 1, "العملاء الراكدون");
                FlxSRep.SetData(24, 1, "ذمم العملاء");
                FlxSRep.SetData(25, 1, "أرصدة الموردين");
                FlxSRep.SetData(26, 1, "الموردين الراكدون");
                FlxSRep.SetData(27, 1, "ذمم الموردين");
                FlxSRep.SetData(28, 1, "البضاعة المصروفة - عميل");
                FlxSRep.SetData(29, 1, "البضاعة المصروفة - مـورد");
                FlxSRep.SetData(30, 1, "تقــريـر الفواتـــير");
                if (VarGeneral.SSSTyp == 1)
                {
                    ribbonTabItem_RepStocks.Text = "حركات العملاء والموردين";
                    FlxSRep.Rows[0].Visible = false;
                    FlxSRep.Rows[1].Visible = false;
                    FlxSRep.Rows[2].Visible = false;
                    FlxSRep.Rows[3].Visible = false;
                    FlxSRep.Rows[4].Visible = false;
                    FlxSRep.Rows[5].Visible = false;
                    FlxSRep.Rows[6].Visible = false;
                    FlxSRep.Rows[7].Visible = false;
                    FlxSRep.Rows[8].Visible = false;
                    FlxSRep.Rows[9].Visible = false;
                    FlxSRep.Rows[10].Visible = false;
                    FlxSRep.Rows[11].Visible = false;
                    FlxSRep.Rows[12].Visible = false;
                    FlxSRep.Rows[13].Visible = false;
                    FlxSRep.Rows[14].Visible = false;
                    FlxSRep.Rows[15].Visible = false;
                    FlxSRep.Rows[16].Visible = false;
                    FlxSRep.Rows[17].Visible = false;
                    FlxSRep.Rows[18].Visible = false;
                    FlxSRep.Rows[19].Visible = false;
                    FlxSRep.Rows[20].Visible = false;
                    FlxSRep.Rows[21].Visible = false;
                    FlxSRep.Rows[28].Visible = false;
                    FlxSRep.Rows[29].Visible = false;
                    FlxSRep.Rows[30].Visible = false;
                }
                FlxAccRep.SetData(0, 0, "*");
                FlxAccRep.SetData(0, 1, "تفعيل");
                FlxAccRep.SetData(1, 0, "كشف حساب تفصيلي");
                FlxAccRep.SetData(2, 0, "كشف بأكثر من حساب");
                FlxAccRep.SetData(3, 0, "كرت الحسابات");
                FlxAccRep.SetData(4, 0, "الأستاذ العام");
                FlxAccRep.SetData(5, 0, "اليومية العامة");
                FlxAccRep.SetData(6, 0, "ميزان مراجعة بالحركة");
                FlxAccRep.SetData(7, 0, "ميزان مراجعة بالأرصدة");
                FlxAccRep.SetData(8, 0, "ميزان مراجعة بالمجاميع");
                FlxAccRep.SetData(9, 0, "ميزان مراجعة بالأرصدة والمجاميع");
                FlxAccRep.SetData(10, 0, "حساب المتاجرة");
                FlxAccRep.SetData(11, 0, "حساب الأرباح والخسائر");
                FlxAccRep.SetData(12, 0, "الميزانية العمومية");
                FlxAccRep.SetData(13, 0, "تقريـر السندات المـاليـة");
                FlxAccRep.SetData(14, 0, "إحتساب الضريبة المستحقة");
                FlxSetups.SetData(0, 0, "*");
                FlxSetups.SetData(0, 1, "تفعيل");
                FlxSetups.SetData(1, 0, "تهيئة النظام");
                FlxSetups.SetData(2, 0, "الصلاحيات");
                FlxSetups.SetData(3, 0, "تغيير الفروع");
                FlxSetups.SetData(4, 0, "النسخ الأحتياطي للبيانات");
                FlxSetups.SetData(5, 0, "استرجاع قاعدة بيانات");
                FlxSetups.SetData(6, 0, "تعديل أسعار الصنف");
                FlxSetups.SetData(7, 0, "تنبيه حد الطلب");
                FlxSetups.SetData(8, 0, "تنبيه تاريخ انتهاء صلاحية الأصناف");
                FlxSetups.SetData(9, 0, "أقفال السنة");
                FlxSetups.SetData(10, 0, "تفعيل المنتج");
                FlxSetups.SetData(11, 0, "إعدادات طباعة الباركود");
                FlxSetups.SetData(12, 0, "إعدادات طباعة الفواتير");
                FlxSetups.SetData(13, 0, "إعدادات طباعة السندات");
                FlxSetups.SetData(14, 0, "إضافة قاعدة بيانات");
                FlxSetups.SetData(15, 0, "تغيير قاعدة البيانات");
                FlxSetups.SetData(16, 0, "قراءة بيانات مقفلة");
                FlxSetups.SetData(17, 0, "نقل البيانات بين الفروع");
                FlxSetups.SetData(18, 0, "تحصيل اوراق القبض والدفع");
                FlxSetups.SetData(19, 0, "رفض اوراق القبض والدفع");
                FlxSetups.SetData(20, 0, "التراجع عن سداد الورقة");
                FlxSetups.SetData(21, 0, "التراجع عن رفض الورقة");
                FlxSetups.SetData(22, 0, "ترحيل عملية السحب والإيداع");
                FlxSetups.SetData(23, 0, "التراجع عن ترحيل عملية السحب والإيداع");
                FlxSetups.SetData(24, 0, "ترحيل حسابات الصناديق - الخزينة");
                FlxSetups.SetData(25, 0, "السماح بترحيل حسابات الصناديق الفارغة");
                FlxSetups.SetData(26, 0, "انشاء الأرصدة الإفتتاحية");
                FlxSetups.SetData(27, 0, "الرسائل النصــية");
                FlxSetups.SetData(28, 0, "إصدار الرواتب");
                FlxSetups.SetData(29, 0, "ترحيل الرواتب");
                FlxSetups.SetData(30, 0, "التراجع عن ترحيل الرواتب");
                FlxSetups.SetData(31, 0, "طباعة مسي\u0651ر الرواتب");
                FlxSetups.SetData(32, 0, "تعيين مستخدمين نقاط البيع");
                FlxSetups.SetData(33, 0, "إزالة مستخدمين نقاط البيع");
                FlxSetups.SetData(34, 0, "إعادة ترقيم صناديق الكاشيير");
                FlxSetups.SetData(35, 0, "حذف قاعدة بيانات");
                FlxSetups.SetData(36, 0, "تقرير نسبة الشركاء من المبيعات");
                FlxSetups.SetData(37, 0, "تعيين السنة المالية");
                FlxSetups.SetData(38, 0, "تحديث اسعار تكلفة المشتريات");
                FlxSetups.SetData(39, 0, "تحديث اسعار تكلفة المبيعات");
                FlxSetups.SetData(40, 0, "التحكم في سيريالات الصنف");
                FlxSetups.SetData(41, 0, "التحكم في اعتمادات الطلبات المحلية");
                FlxSetups.SetData(42, 0, "إزالة الطلبات المحلية");
                FlxSetups.SetData(43, 0, "تحويل الطلبات بين الطاولات");
                FlxSetups.SetData(44, 0, "التحكم برقم الفاتورة يدويا\u0651");
                FlxSetups.SetData(45, 0, "تقارير بيانات نقاط العملاء");
                FlxSetups.SetData(46, 0, "إخفاء عمود السعر لفاتورة طلب شراء");
                FlxSetups.SetData(47, 0, "السماح بتعديل التكلفة يدويا\u064e في شاشة صيانة المشتريات");
                FlxSetups.SetData(48, 0, "استخدام عمليات الزيادة والنقصان في كرت الصنف");
                FlxSetups.SetData(49, 0, "تفعيل اجباري لخيار الباركود في المبيعات");
                FlxSetups.SetData(50, 0, "التحكم في حسابات الدفع في فواتير البيع والشراء");
                FlxSetups.SetData(51, 0, "تفعيل زر فتح الدرج لنقاط البيع");
                FlxSetups.SetData(52, 0, "السماح بعرض تقرير بالفواتير المحذوفة");
                FlxSetups.SetData(53, 0, "تعين المستخدم كمستخدم تابلت");
                if (VarGeneral.SSSTyp == 0)
                {
                    if (VarGeneral.SSSLev == "M")
                    {
                        FlxSetups.Rows[32].Visible = false;
                        FlxSetups.Rows[33].Visible = false;
                        FlxSetups.Rows[34].Visible = false;
                    }
                    FlxSetups.Rows[13].Visible = false;
                    FlxSetups.Rows[18].Visible = false;
                    FlxSetups.Rows[19].Visible = false;
                    FlxSetups.Rows[20].Visible = false;
                    FlxSetups.Rows[21].Visible = false;
                    FlxSetups.Rows[22].Visible = false;
                    FlxSetups.Rows[23].Visible = false;
                    FlxSetups.Rows[24].Visible = false;
                    FlxSetups.Rows[25].Visible = false;
                    FlxSetups.Rows[26].Visible = false;
                    FlxSetups.Rows[28].Visible = false;
                    FlxSetups.Rows[29].Visible = false;
                    FlxSetups.Rows[30].Visible = false;
                    FlxSetups.Rows[31].Visible = false;
                    FlxSetups.Rows[36].Visible = false;
                }
                else if (VarGeneral.SSSTyp == 1)
                {
                    FlxSetups.Rows[6].Visible = false;
                    FlxSetups.Rows[7].Visible = false;
                    FlxSetups.Rows[8].Visible = false;
                    FlxSetups.Rows[11].Visible = false;
                    FlxSetups.Rows[12].Visible = false;
                    FlxSetups.Rows[28].Visible = false;
                    FlxSetups.Rows[29].Visible = false;
                    FlxSetups.Rows[30].Visible = false;
                    FlxSetups.Rows[31].Visible = false;
                    FlxSetups.Rows[32].Visible = false;
                    FlxSetups.Rows[33].Visible = false;
                    FlxSetups.Rows[34].Visible = false;
                    FlxSetups.Rows[38].Visible = false;
                    FlxSetups.Rows[39].Visible = false;
                    FlxSetups.Rows[46].Visible = false;
                    FlxSetups.Rows[47].Visible = false;
                    FlxSetups.Rows[48].Visible = false;
                    FlxSetups.Rows[49].Visible = false;
                    FlxSetups.Rows[50].Visible = false;
                    FlxSetups.Rows[51].Visible = false;
                }
                if (VarGeneral.SSSLev == "D" || VarGeneral.SSSLev == "E")
                {
                    FlxSetups.Rows[28].Visible = false;
                    FlxSetups.Rows[29].Visible = false;
                    FlxSetups.Rows[30].Visible = false;
                    FlxSetups.Rows[31].Visible = false;
                }
                if (VarGeneral.SSSLev == "R" || VarGeneral.SSSLev == "C" || VarGeneral.SSSLev == "H")
                {
                    FlxSetups.Rows[41].Visible = true;
                    FlxSetups.Rows[42].Visible = true;
                    FlxSetups.Rows[43].Visible = true;
                }
                else
                {
                    FlxSetups.Rows[41].Visible = false;
                    FlxSetups.Rows[42].Visible = false;
                    FlxSetups.Rows[43].Visible = false;
                }
                if (Program.iscarversion())
                    FlxSetups.Rows[53].Visible = false;
                dataGridViewX_MenuPer.SetData(0, 0, "*");
                dataGridViewX_MenuPer.SetData(0, 1, "تفعيل");
                dataGridViewX_MenuPer.SetData(0, 2, "إضافة");
                dataGridViewX_MenuPer.SetData(0, 3, "تعديل");
                dataGridViewX_MenuPer.SetData(0, 4, "حذف");
                dataGridViewX_MenuPer.SetData(1, 0, "الموظفين");
                dataGridViewX_MenuPer.SetData(2, 0, "الإدارات");
                dataGridViewX_MenuPer.SetData(3, 0, "الأقســام");
                dataGridViewX_MenuPer.SetData(4, 0, "الوظــائف");
                dataGridViewX_MenuPer.SetData(5, 0, "الكفـــلاء");
                dataGridViewX_MenuPer.SetData(6, 0, "المشــاريع");
                dataGridViewX_MenuPer.SetData(7, 0, "الجنسيــات");
                dataGridViewX_MenuPer.SetData(8, 0, "أنواع العقــود");
                dataGridViewX_MenuPer.SetData(9, 0, "أنواع الإجـازات");
                dataGridViewX_MenuPer.SetData(10, 0, "المــدن");
                dataGridViewX_MenuPer.SetData(11, 0, "الــديـانـات");
                dataGridViewX_MenuPer.SetData(12, 0, "السيــارات");
                dataGridViewX_MenuPer.SetData(13, 0, "المعــامـلات");
                dataGridViewX_MovePre.SetData(0, 0, "*");
                dataGridViewX_MovePre.SetData(0, 1, "تفعيل");
                dataGridViewX_MovePre.SetData(0, 2, "إضافة");
                dataGridViewX_MovePre.SetData(0, 3, "تعديل");
                dataGridViewX_MovePre.SetData(0, 4, "حذف");
                dataGridViewX_MovePre.SetData(1, 0, "الإضافــي");
                dataGridViewX_MovePre.SetData(2, 0, "الخصـــــم");
                dataGridViewX_MovePre.SetData(3, 0, "الإجـــازات");
                dataGridViewX_MovePre.SetData(4, 0, "التذاكــــر");
                dataGridViewX_MovePre.SetData(5, 0, "السلفيـــات");
                dataGridViewX_MovePre.SetData(6, 0, "المكالمــــات");
                dataGridViewX_MovePre.SetData(7, 0, "الحوافز والمكافآت");
                dataGridViewX_MovePre.SetData(8, 0, "الإستئـــذان");
                dataGridViewX_MovePre.SetData(9, 0, "العهــــد");
                dataGridViewX_MovePre.SetData(10, 0, "تأشيرة الخروج والعودة");
                dataGridViewX_MovePre.SetData(11, 0, "نهاية الخدمة");
                dataGridViewX_MovePre.SetData(12, 0, "التعقــيب");
                dataGridViewX_SalPer.SetData(0, 0, "*");
                dataGridViewX_SalPer.SetData(0, 1, "تفعيل");
                dataGridViewX_SalPer.SetData(1, 0, "إصدار الرواتب");
                dataGridViewX_SalPer.SetData(2, 0, "ترحيل الرواتب");
                dataGridViewX_SalPer.SetData(3, 0, "إلغاء ترحيـــل الرواتب");
                dataGridViewX_SalPer.SetData(4, 0, "طباعة مسي\u0651ر الرواتب");
                dataGridViewX_SalPer.SetData(5, 0, "العمليات على الرواتب");
                dataGridViewX_SalPer.SetData(6, 0, "تقرير الزيادة والنقصان");
                dataGridViewX_SalPer.SetData(7, 0, "تقرير راتــــب الموظف");
                dataGridViewX_SalPer.SetData(8, 0, "تقرير تأمينات الموظف");
                dataGridViewX_SalPer.SetData(9, 0, "تعميـــــم الحســــابات");
                dataGridViewX_SalPer.SetData(10, 0, "انشاء قيد عند ترحيل الراتب");
                dataGridViewX_RepPre.SetData(0, 0, "*");
                dataGridViewX_RepPre.SetData(0, 1, "تفعيل");
                dataGridViewX_RepPre.SetData(1, 0, "تقرير الموظفين");
                dataGridViewX_RepPre.SetData(2, 0, "هويات الموظفين");
                dataGridViewX_RepPre.SetData(3, 0, "جوازات الموظفين");
                dataGridViewX_RepPre.SetData(4, 0, "إستمارات الموظفين");
                dataGridViewX_RepPre.SetData(5, 0, "رخــص الموظفين");
                dataGridViewX_RepPre.SetData(6, 0, "التأمين الصحي");
                dataGridViewX_RepPre.SetData(7, 0, "تجديـــد الوثائــق");
                dataGridViewX_RepPre.SetData(8, 0, "تجديد شركات التأمـين");
                dataGridViewX_RepPre.SetData(9, 0, "تقرير الإجازات");
                dataGridViewX_RepPre.SetData(10, 0, "تقرير التذاكر");
                dataGridViewX_RepPre.SetData(11, 0, "تقرير الإستئذان");
                dataGridViewX_RepPre.SetData(12, 0, "تقرير العهــــد");
                dataGridViewX_RepPre.SetData(13, 0, "تقرير تأشيرة الخروج والعودة");
                dataGridViewX_RepPre.SetData(14, 0, "تقرير نهاية الخدمة");
                dataGridViewX_RepPre.SetData(15, 0, "تقرير الإضافي");
                dataGridViewX_RepPre.SetData(16, 0, "تقرير الحوافز والمكافآت");
                dataGridViewX_RepPre.SetData(17, 0, "تقرير السلف");
                dataGridViewX_RepPre.SetData(18, 0, "تقرير المكالمــــات");
                dataGridViewX_RepPre.SetData(19, 0, "تقرير الخصم");
                dataGridViewX_RepPre.SetData(20, 0, "تقرير عمليات التعقيب");
                dataGridViewX_RepPre.SetData(21, 0, "تقرير السيارات");
                dataGridViewX_RepPre.SetData(22, 0, "تقرير الحضور والإنصراف");
                dataGridViewX_RepPre.SetData(23, 0, "فرز الموظف حسب المشروع");
                dataGridViewX_GenralPre.SetData(0, 0, "*");
                dataGridViewX_GenralPre.SetData(0, 1, "تفعيل");
                dataGridViewX_GenralPre.SetData(1, 0, "نظــام الـــدوام");
                dataGridViewX_GenralPre.SetData(2, 0, "تسجيل الحضور والإنصراف");
                dataGridViewX_GenralPre.SetData(3, 0, "الحضور والإنصراف اليدوي");
                dataGridViewX_GenralPre.SetData(4, 0, "استيراد بيانات الــدوام");
                dataGridViewX_GenralPre.SetData(5, 0, "تعميم أوقات الدوام");
                dataGridViewX_GenralPre.SetData(6, 0, "التعديل على الدوام");
                dataGridViewX_GenralPre.SetData(7, 0, "معالجة بيانات الدوام");
                dataGridViewX_GenralPre.SetData(8, 0, "ترحيل الإجازات");
                dataGridViewX_GenralPre.SetData(9, 0, "ترحيل التذاكر");
                dataGridViewX_GenralPre.SetData(10, 0, "ترحيل العهــــد");
                dataGridViewX_GenralPre.SetData(11, 0, "إستمارة الجوازات");
                dataGridViewX_GenralPre.SetData(12, 0, "تجديد وثائق الموظف");
                dataGridViewX_GenralPre.SetData(13, 0, "التحكم بموافقات الإجازات");
                dataGridViewX_HotelMenuPer.SetData(0, 0, "*");
                dataGridViewX_HotelMenuPer.SetData(0, 1, "تفعيل");
                dataGridViewX_HotelMenuPer.SetData(0, 2, "إضافة");
                dataGridViewX_HotelMenuPer.SetData(0, 3, "تعديل");
                dataGridViewX_HotelMenuPer.SetData(0, 4, "حذف");
                dataGridViewX_HotelMenuPer.SetData(1, 0, "أنواع الهويات");
                dataGridViewX_HotelMenuPer.SetData(2, 0, "الوظــائف");
                dataGridViewX_HotelMenuPer.SetData(3, 0, "أنواع الخدمات ");
                dataGridViewX_HotelMenuPer.SetData(4, 0, "الجنسيــات");
                dataGridViewX_HotelMovePre.SetData(0, 0, "*");
                dataGridViewX_HotelMovePre.SetData(0, 1, "تفعيل");
                dataGridViewX_HotelMovePre.SetData(0, 2, "إضافة");
                dataGridViewX_HotelMovePre.SetData(0, 3, "تعديل");
                dataGridViewX_HotelMovePre.SetData(0, 4, "حذف");
                dataGridViewX_HotelMovePre.SetData(1, 0, "تقديم خدمة للنزلاء");
                dataGridViewX_HotelMovePre.SetData(2, 0, "المكالمات الهاتفية");
                dataGridViewX_HotelMovePre.SetData(3, 0, "النزلاء المحظورين");
                dataGridViewX_HotelMovePre.SetData(4, 0, "بيانات غرف النزلاء");
                dataGridViewX_HotelMovePre.SetData(5, 0, "بيانات الحجوزات");
                dataGridViewX_HotelMovePre.SetData(6, 0, "سندات قبض النزلاء");
                dataGridViewX_HotelMovePre.SetData(7, 0, "سندات صرف النزلاء");
                dataGridViewX_HotelRepPre.SetData(0, 0, "*");
                dataGridViewX_HotelRepPre.SetData(0, 1, "تفعيل");
                dataGridViewX_HotelRepPre.SetData(1, 0, "كشف بإيراد اليوم - الإستقبال");
                dataGridViewX_HotelRepPre.SetData(2, 0, "تقرير ببيانات جميع النزلاء");
                dataGridViewX_HotelRepPre.SetData(3, 0, "كشف حساب النزلاء الحاجزين");
                dataGridViewX_HotelRepPre.SetData(4, 0, "كشف حساب النزلاء");
                dataGridViewX_HotelRepPre.SetData(5, 0, "كشف حساب نزيل");
                dataGridViewX_HotelRepPre.SetData(6, 0, "الخدمات المقدمة للنزلاء");
                dataGridViewX_HotelRepPre.SetData(7, 0, "حركة مكالمات النزلاء");
                dataGridViewX_HotelRepPre.SetData(8, 0, "كشف حساب غرفة خلال فترة");
                dataGridViewX_HotelRepPre.SetData(9, 0, "مواصفات الغرفة");
                dataGridViewX_HotelRepPre.SetData(10, 0, "حركة الغرف خلال فترة");
                dataGridViewX_HotelRepPre.SetData(11, 0, "صيانة الغرفة خلال فترة");
                dataGridViewX_HotelRepPre.SetData(12, 0, "نقل السكان خلال فترة");
                dataGridViewX_HotelGenralPre.SetData(0, 0, "*");
                dataGridViewX_HotelGenralPre.SetData(0, 1, "تفعيل");
                dataGridViewX_HotelGenralPre.SetData(1, 0, "نقل ساكن");
                dataGridViewX_HotelGenralPre.SetData(2, 0, "إضافة ملحق");
                dataGridViewX_HotelGenralPre.SetData(3, 0, "تغيير سعر الغرفة");
                dataGridViewX_HotelGenralPre.SetData(4, 0, "تغيير نوع السكن");
                dataGridViewX_HotelGenralPre.SetData(5, 0, "تغيير عدد الأيام المطلوبة");
                dataGridViewX_HotelGenralPre.SetData(6, 0, "مغادرة الغرفة");
                dataGridViewX_HotelGenralPre.SetData(7, 0, "تصليح الغرفة");
                dataGridViewX_HotelGenralPre.SetData(8, 0, "إنهاء التصليحات");
                dataGridViewX_HotelGenralPre.SetData(9, 0, "تنظيف الغرفة");
                dataGridViewX_HotelGenralPre.SetData(10, 0, "إنهاء التنظيفات");
                dataGridViewX_HotelGenralPre.SetData(11, 0, "بيانات الغرف");
                dataGridViewX_HotelGenralPre.SetData(12, 0, "أسعار المكالمات");
                dataGridViewX_HotelGenralPre.SetData(13, 0, "تعديل خدمات النزلاء المغادرين");
                dataGridViewX_HotelGenralPre.SetData(14, 0, "تعديل مكالمات النزلاء المغادرين");
                dataGridViewX_HotelGenralPre.SetData(15, 0, "القيود التلقائية بقيمة فترة الإقامة");
                if (VarGeneral.vDemo && VarGeneral.UserID != 1)
                {
                    dataGridViewX_HotelGenralPre.Rows[12].Visible = false;
                }
                dataGridViewX_EqarFiles.SetData(0, 0, "*");
                dataGridViewX_EqarFiles.SetData(0, 1, "تفعيل");
                dataGridViewX_EqarFiles.SetData(0, 2, "إضافة");
                dataGridViewX_EqarFiles.SetData(0, 3, "تعديل");
                dataGridViewX_EqarFiles.SetData(0, 4, "حذف");
                dataGridViewX_EqarFiles.SetData(1, 0, "المـــدن");
                dataGridViewX_EqarFiles.SetData(2, 0, "الجنسيـــات");
                dataGridViewX_EqarFiles.SetData(3, 0, "أنواع العقار");
                dataGridViewX_EqarFiles.SetData(4, 0, "طبيعة العقار");
                dataGridViewX_EqarFiles.SetData(5, 0, "العقــــــارات");
                dataGridViewX_EqarFiles.SetData(6, 0, "بيع عقـــار");
                dataGridViewX_EqarFiles.SetData(7, 0, "المـــــــــلاك");
                dataGridViewX_Tenants.SetData(0, 0, "*");
                dataGridViewX_Tenants.SetData(0, 1, "تفعيل");
                dataGridViewX_Tenants.SetData(0, 2, "إضافة");
                dataGridViewX_Tenants.SetData(0, 3, "تعديل");
                dataGridViewX_Tenants.SetData(0, 4, "حذف");
                dataGridViewX_Tenants.SetData(1, 0, "بيانات المستأجرين");
                dataGridViewX_Tenants.SetData(2, 0, "سند قبض مستأجر");
                dataGridViewX_Tenants.SetData(3, 0, "سند صرف مستأجر");
                dataGridViewX_Tenants.SetData(4, 0, "إشعارات المستأجرين");
                dataGridViewX_RepEqar.SetData(0, 0, "*");
                dataGridViewX_RepEqar.SetData(0, 1, "تفعيل");
                dataGridViewX_RepEqar.SetData(1, 0, "الإستعلامــــــات");
                dataGridViewX_RepEqar.SetData(2, 0, "كشف حساب المستأجرين");
                dataGridViewX_RepEqar.SetData(3, 0, "كشف حساب عقــــار");
                dataGridViewX_RepEqar.SetData(4, 0, "كشف حساب المـــلاك");
                dataGridViewX_RepEqar.SetData(5, 0, "كشف الحســـــاب");
                dataGridViewX_RepEqar.SetData(6, 0, "تقرير تحصيل الإيجار");
                dataGridViewX_RepEqar.Rows[4].Visible = false;
                dataGridViewX_RepEqar.Rows[5].Visible = false;
                dataGridViewX_GenralEqar.SetData(0, 0, "*");
                dataGridViewX_GenralEqar.SetData(0, 1, "تفعيل");
                dataGridViewX_GenralEqar.SetData(1, 0, "تصميم العقود");
            }
            else
            {
                _CmbIndex = CmbStatus.SelectedIndex;
                CmbStatus.Items.Clear();
                CmbStatus.Items.Add("ON");
                CmbStatus.Items.Add("Off");
                CmbStatus.SelectedIndex = 0;
                _CmbIndex = CmbLanguge.SelectedIndex;
                CmbLanguge.Items.Clear();
                CmbLanguge.Items.Add("Arabic");
                CmbLanguge.Items.Add("English");
                CmbLanguge.SelectedIndex = 0;
                _CmbIndex = CmbBranch.SelectedIndex;
                List<T_Branch> listBranch = new List<T_Branch>(dbc.T_Branches.Select((T_Branch item) => item).ToList());
                CmbBranch.DataSource = listBranch;
                CmbBranch.DisplayMember = "Branch_NameE";
                CmbBranch.ValueMember = "Branch_no";
                CmbBranch.SelectedIndex = _CmbIndex;
                _CmbIndex = CmbStores.SelectedIndex;
                List<T_Store> _StoresLst = new List<T_Store>(db.T_Stores.OrderBy((T_Store item) => item.Stor_ID).ToList());
                _StoresLst.Insert(0, new T_Store());
                CmbStores.DataSource = _StoresLst;
                CmbStores.DisplayMember = "Eng_Des";
                CmbStores.ValueMember = "Stor_ID";
                CmbStores.SelectedIndex = _CmbIndex;
                FlxFiles.SetData(0, 0, "*");
                FlxFiles.SetData(0, 1, "Activation");
                FlxFiles.SetData(0, 2, "Add");
                FlxFiles.SetData(0, 3, "Edit");
                FlxFiles.SetData(0, 4, "Delete");
                FlxFiles.SetData(1, 0, "Category");
                FlxFiles.SetData(2, 0, "Define Item");
                FlxFiles.SetData(3, 0, "Unit");
                FlxFiles.SetData(4, 0, "Currency");
                FlxFiles.SetData(5, 0, "Cost Center");
                FlxFiles.SetData(6, 0, "Branch");
                FlxFiles.SetData(7, 0, "Delegates");
                FlxFiles.SetData(8, 0, "Stores");
                FlxFiles.SetData(9, 0, "Customers");
                FlxFiles.SetData(10, 0, "Suppliers");
                FlxFiles.SetData(11, 0, "Employees");
                FlxFiles.SetData(12, 0, "Waiters");
                FlxFiles.SetData(13, 0, "Drivers");
                FlxFiles.SetData(14, 0, "Special Additions");
                FlxFiles.SetData(15, 0, "Execution Screen");
                if (VarGeneral.SSSTyp == 0)
                {
                    if (VarGeneral.SSSLev == "M")
                    {
                        FlxFiles.Rows[9].Visible = false;
                        FlxFiles.Rows[10].Visible = false;
                    }
                    FlxFiles.Rows[5].Visible = false;
                    FlxFiles.Rows[11].Visible = false;
                }
                else if (VarGeneral.SSSTyp == 1)
                {
                    FlxFiles.Rows[1].Visible = false;
                    FlxFiles.Rows[2].Visible = false;
                    FlxFiles.Rows[3].Visible = false;
                    FlxFiles.Rows[8].Visible = false;
                    FlxFiles.Rows[11].Visible = false;
                }
                if (VarGeneral.SSSLev == "D" || VarGeneral.SSSLev == "E")
                {
                    FlxFiles.Rows[11].Visible = false;
                }
                if (VarGeneral.SSSLev == "S")
                {
                    FlxFiles.Rows[5].Visible = false;
                }
                if (VarGeneral.SSSLev != "R" || VarGeneral.SSSLev == "C" || VarGeneral.SSSLev != "H")
                {
                    FlxFiles.Rows[12].Visible = false;
                    FlxFiles.Rows[13].Visible = false;
                    FlxFiles.Rows[14].Visible = false;
                }
                FlxInvoices.SetData(0, 0, "*");
                FlxInvoices.SetData(0, 1, "Activation");
                FlxInvoices.SetData(0, 2, "Add");
                FlxInvoices.SetData(0, 3, "Edit");
                FlxInvoices.SetData(0, 4, "Delete");
                FlxInvoices.SetData(1, 0, "Sales Invoice");
                FlxInvoices.SetData(2, 0, "Returns Sales Invoice");
                FlxInvoices.SetData(3, 0, "Purchase Invoice");
                FlxInvoices.SetData(4, 0, "Returns Purchase Invoice");
                FlxInvoices.SetData(5, 0, "Customer Qutation");
                FlxInvoices.SetData(6, 0, "Supplier Qutation");
                FlxInvoices.SetData(7, 0, "Purchase Order");
                FlxInvoices.SetData(8, 0, "Open Quantities");
                FlxInvoices.SetData(9, 0, "The introduction of goods");
                FlxInvoices.SetData(10, 0, "The Exiting of goods");
                FlxInvoices.SetData(11, 0, "Payment Order");
                FlxInvoices.SetData(12, 0, "Returns Payment Order");
                FlxInvoices.SetData(13, 0, "Settlement goods");
                FlxInvoices.SetData(14, 0, "Spicial Offers");
                FlxAccounting.SetData(0, 0, "*");
                FlxAccounting.SetData(0, 1, "Activation");
                FlxAccounting.SetData(0, 2, "Add");
                FlxAccounting.SetData(0, 3, "Edit");
                FlxAccounting.SetData(0, 4, "Delete");
                FlxAccounting.SetData(1, 0, "Classification of accounts");
                FlxAccounting.SetData(2, 0, "Accounting Card");
                FlxAccounting.SetData(3, 0, "Daily restrictions");
                FlxAccounting.SetData(4, 0, "Catch Bill");
                FlxAccounting.SetData(5, 0, "Exchange Bill");
                FlxAccounting.SetData(6, 0, "Banks");
                FlxAccounting.SetData(7, 0, "Branches of Banks");
                FlxAccounting.SetData(8, 0, "Peapers Catch and payment");
                FlxAccounting.SetData(9, 0, "Withdraw and deposit Opearations");
                FlxAccounting.SetData(10, 0, "Monetary fund");
                if (VarGeneral.SSSTyp == 0)
                {
                    if (VarGeneral.SSSLev == "M")
                    {
                        FlxAccounting.Visible = false;
                    }
                    FlxAccounting.Rows[1].Visible = false;
                    FlxAccounting.Rows[2].Visible = false;
                    FlxAccounting.Rows[3].Visible = false;
                    FlxAccounting.Rows[6].Visible = false;
                    FlxAccounting.Rows[7].Visible = false;
                    FlxAccounting.Rows[8].Visible = false;
                    FlxAccounting.Rows[9].Visible = false;
                    FlxAccounting.Rows[10].Visible = false;
                }
                FlxAccounting.Rows[7].Visible = false;
                FlxSRep.SetData(0, 0, "*");
                FlxSRep.SetData(0, 1, "*");
                FlxSRep.SetData(0, 2, "Activation");
                FlxSRep.SetData(1, 1, "Items Data");
                FlxSRep.SetData(2, 1, "Items Data And Quantity");
                FlxSRep.SetData(3, 1, "Item Data And Cost");
                FlxSRep.SetData(4, 1, "Item Movement");
                FlxSRep.SetData(5, 1, "Items With Date Expiration and Movements");
                FlxSRep.SetData(6, 1, "Items must be met");
                FlxSRep.SetData(7, 1, "Inactive Items");
                FlxSRep.SetData(8, 1, "Item Movement Printing");
                FlxSRep.SetData(9, 1, "Item Movement Report in Sales Invoice");
                FlxSRep.SetData(10, 1, "Item Movement Report in Returns Sales Invoice");
                FlxSRep.SetData(11, 1, "Item Movement Report in Purchase Invoice");
                FlxSRep.SetData(12, 1, "Item Movement Report in Returns Purchase Invoice");
                FlxSRep.SetData(13, 1, "Item Movement Report in Customer Qutation Invoice");
                FlxSRep.SetData(14, 1, "Item Movement Report in Supplier Qutation Invoice");
                FlxSRep.SetData(15, 1, "Item Movement Report in Purchase Order Invoice");
                FlxSRep.SetData(16, 1, "Item Movement Report in Open Quantities Invoice");
                FlxSRep.SetData(17, 1, "Item Movement Report in The introduction of goods");
                FlxSRep.SetData(18, 1, "Item Movement Report in The Exiting of goods");
                FlxSRep.SetData(19, 1, "Item Movement Report in Payment Order");
                FlxSRep.SetData(20, 1, "Item Movement Report in Returns Payment Order");
                FlxSRep.SetData(21, 1, "Item Movement Report in Settlement goods");
                FlxSRep.SetData(22, 1, "The customer balances");
                FlxSRep.SetData(23, 1, "Customers inactive");
                FlxSRep.SetData(24, 1, "Customers Acconuts");
                FlxSRep.SetData(25, 1, "The suppliers balances");
                FlxSRep.SetData(26, 1, "suppliers inactive");
                FlxSRep.SetData(27, 1, "suppliers Acconuts");
                FlxSRep.SetData(28, 1, "Goods Disbursed To Cust");
                FlxSRep.SetData(29, 1, "Goods Disbursed To Supp");
                FlxSRep.SetData(30, 1, "Invoices Report");
                if (VarGeneral.SSSTyp == 1)
                {
                    ribbonTabItem_RepStocks.Text = "Customers and Suppliers";
                    FlxSRep.Rows[0].Visible = false;
                    FlxSRep.Rows[1].Visible = false;
                    FlxSRep.Rows[2].Visible = false;
                    FlxSRep.Rows[3].Visible = false;
                    FlxSRep.Rows[4].Visible = false;
                    FlxSRep.Rows[5].Visible = false;
                    FlxSRep.Rows[6].Visible = false;
                    FlxSRep.Rows[7].Visible = false;
                    FlxSRep.Rows[8].Visible = false;
                    FlxSRep.Rows[9].Visible = false;
                    FlxSRep.Rows[10].Visible = false;
                    FlxSRep.Rows[11].Visible = false;
                    FlxSRep.Rows[12].Visible = false;
                    FlxSRep.Rows[13].Visible = false;
                    FlxSRep.Rows[14].Visible = false;
                    FlxSRep.Rows[15].Visible = false;
                    FlxSRep.Rows[16].Visible = false;
                    FlxSRep.Rows[17].Visible = false;
                    FlxSRep.Rows[18].Visible = false;
                    FlxSRep.Rows[19].Visible = false;
                    FlxSRep.Rows[20].Visible = false;
                    FlxSRep.Rows[21].Visible = false;
                    FlxSRep.Rows[28].Visible = false;
                    FlxSRep.Rows[29].Visible = false;
                    FlxSRep.Rows[30].Visible = false;
                }
                FlxAccRep.SetData(0, 0, "*");
                FlxAccRep.SetData(0, 1, "Activation");
                FlxAccRep.SetData(1, 0, "detailed account report");
                FlxAccRep.SetData(2, 0, "Report to more than one account");
                FlxAccRep.SetData(3, 0, "Card Accounts");
                FlxAccRep.SetData(4, 0, "General Ledger");
                FlxAccRep.SetData(5, 0, "General Daily");
                FlxAccRep.SetData(6, 0, "Balance of movement");
                FlxAccRep.SetData(7, 0, "Balance Trail Balance");
                FlxAccRep.SetData(8, 0, "Balance of aggregates");
                FlxAccRep.SetData(9, 0, "Balance of stocks and aggregates");
                FlxAccRep.SetData(10, 0, "Trading account");
                FlxAccRep.SetData(11, 0, "Profit and loss account");
                FlxAccRep.SetData(12, 0, "Balance Sheet");
                FlxAccRep.SetData(13, 0, "Bounds Report");
                FlxAccRep.SetData(14, 0, "Calculation of due tax");
                FlxSetups.SetData(0, 0, "*");
                FlxSetups.SetData(0, 1, "Activation");
                FlxSetups.SetData(1, 0, "System Setting");
                FlxSetups.SetData(2, 0, "Users");
                FlxSetups.SetData(3, 0, "Changing Branche");
                FlxSetups.SetData(4, 0, "Backup Data Base");
                FlxSetups.SetData(5, 0, "Restore Data Base");
                FlxSetups.SetData(6, 0, "Edite Items Prices");
                FlxSetups.SetData(7, 0, "Alert demand an end");
                FlxSetups.SetData(8, 0, "Alert expiration date Items");
                FlxSetups.SetData(9, 0, "End Years");
                FlxSetups.SetData(10, 0, "Activation Version");
                FlxSetups.SetData(11, 0, "Barcode Setting");
                FlxSetups.SetData(12, 0, "Invoice Setting");
                FlxSetups.SetData(13, 0, "Gaid Setting");
                FlxSetups.SetData(14, 0, "ADD New Data Base");
                FlxSetups.SetData(15, 0, "Change Data Base");
                FlxSetups.SetData(16, 0, "Read Data Closed");
                FlxSetups.SetData(17, 0, "Transfer Data Between Branches");
                FlxSetups.SetData(18, 0, "The collection of Peapers receivable and payment");
                FlxSetups.SetData(19, 0, "Rejection of Peapers receivable and payment");
                FlxSetups.SetData(20, 0, "Undo repayment paper");
                FlxSetups.SetData(21, 0, "Undo rejected paper");
                FlxSetups.SetData(22, 0, "Withdrawals and deposits deportation");
                FlxSetups.SetData(23, 0, "Withdrawals and deposits deportation Back");
                FlxSetups.SetData(24, 0, "Deportation fund accounts - Treasury");
                FlxSetups.SetData(25, 0, "Allowing the deportation of empty fund accounts");
                FlxSetups.SetData(26, 0, "Create Opened Balances");
                FlxSetups.SetData(27, 0, "Messages SMS");
                FlxSetups.SetData(28, 0, "Calculating salaries");
                FlxSetups.SetData(29, 0, "Relay salaries");
                FlxSetups.SetData(30, 0, "Undo Relay salaries");
                FlxSetups.SetData(31, 0, "Salaries Printing");
                FlxSetups.SetData(32, 0, "Set POS Users");
                FlxSetups.SetData(33, 0, "Delete POS Users");
                FlxSetups.SetData(34, 0, "Re numbering cashier boxes");
                FlxSetups.SetData(35, 0, "Data Base Delete");
                FlxSetups.SetData(36, 0, "Sales Partner Ratio Report");
                FlxSetups.SetData(37, 0, "The appointment of the fiscal year");
                FlxSetups.SetData(38, 0, "Update Cost Price of Purchaes");
                FlxSetups.SetData(39, 0, "Update Cost Price of Sales");
                FlxSetups.SetData(40, 0, "Control of Items Serials");
                FlxSetups.SetData(41, 0, "Control of Local Orders approval");
                FlxSetups.SetData(42, 0, "Remove Local Orders");
                FlxSetups.SetData(43, 0, "Transfer Orders Between Tables");
                FlxSetups.SetData(44, 0, "Manually control invoice number");
                FlxSetups.SetData(45, 0, "Points of Customers Reports");
                FlxSetups.SetData(46, 0, "Hide price column for purchase order invoice");
                FlxSetups.SetData(47, 0, "Allow manual cost on the Procurement Maintenance");
                FlxSetups.SetData(48, 0, "Use increases and decreases to items");
                FlxSetups.SetData(49, 0, "Activate the compulsory barcode option in sales");
                FlxSetups.SetData(50, 0, "Controlling Accounts Payable in Bills of Sale and Purchase");
                FlxSetups.SetData(51, 0, "Activate the button to open the POS box");
                FlxSetups.SetData(52, 0, "Allow to show deleted invoices");
                if (VarGeneral.SSSTyp == 0)
                {
                    if (VarGeneral.SSSLev == "M")
                    {
                        FlxSetups.Rows[32].Visible = false;
                        FlxSetups.Rows[33].Visible = false;
                        FlxSetups.Rows[34].Visible = false;
                    }
                    FlxSetups.Rows[13].Visible = false;
                    FlxSetups.Rows[18].Visible = false;
                    FlxSetups.Rows[19].Visible = false;
                    FlxSetups.Rows[20].Visible = false;
                    FlxSetups.Rows[21].Visible = false;
                    FlxSetups.Rows[22].Visible = false;
                    FlxSetups.Rows[23].Visible = false;
                    FlxSetups.Rows[24].Visible = false;
                    FlxSetups.Rows[25].Visible = false;
                    FlxSetups.Rows[26].Visible = false;
                    FlxSetups.Rows[28].Visible = false;
                    FlxSetups.Rows[29].Visible = false;
                    FlxSetups.Rows[30].Visible = false;
                    FlxSetups.Rows[31].Visible = false;
                    FlxSetups.Rows[36].Visible = false;
                }
                else if (VarGeneral.SSSTyp == 1)
                {
                    FlxSetups.Rows[6].Visible = false;
                    FlxSetups.Rows[7].Visible = false;
                    FlxSetups.Rows[8].Visible = false;
                    FlxSetups.Rows[11].Visible = false;
                    FlxSetups.Rows[12].Visible = false;
                    FlxSetups.Rows[28].Visible = false;
                    FlxSetups.Rows[29].Visible = false;
                    FlxSetups.Rows[30].Visible = false;
                    FlxSetups.Rows[31].Visible = false;
                    FlxSetups.Rows[32].Visible = false;
                    FlxSetups.Rows[33].Visible = false;
                    FlxSetups.Rows[34].Visible = false;
                    FlxSetups.Rows[38].Visible = false;
                    FlxSetups.Rows[39].Visible = false;
                    FlxSetups.Rows[46].Visible = false;
                    FlxSetups.Rows[47].Visible = false;
                    FlxSetups.Rows[48].Visible = false;
                    FlxSetups.Rows[49].Visible = false;
                    FlxSetups.Rows[50].Visible = false;
                    FlxSetups.Rows[51].Visible = false;
                }
                if (VarGeneral.SSSLev == "D" || VarGeneral.SSSLev == "E")
                {
                    FlxSetups.Rows[28].Visible = false;
                    FlxSetups.Rows[29].Visible = false;
                    FlxSetups.Rows[30].Visible = false;
                    FlxSetups.Rows[31].Visible = false;
                }
                if (VarGeneral.SSSLev == "R" || VarGeneral.SSSLev == "C" || VarGeneral.SSSLev == "H")
                {
                    FlxSetups.Rows[41].Visible = true;
                    FlxSetups.Rows[42].Visible = true;
                    FlxSetups.Rows[43].Visible = true;
                }
                else
                {
                    FlxSetups.Rows[41].Visible = false;
                    FlxSetups.Rows[42].Visible = false;
                    FlxSetups.Rows[43].Visible = false;
                }
                dataGridViewX_MenuPer.SetData(0, 0, "*");
                dataGridViewX_MenuPer.SetData(0, 1, "Activation");
                dataGridViewX_MenuPer.SetData(0, 2, "Add");
                dataGridViewX_MenuPer.SetData(0, 3, "Edit");
                dataGridViewX_MenuPer.SetData(0, 4, "Delete");
                dataGridViewX_MenuPer.SetData(1, 0, "Employee");
                dataGridViewX_MenuPer.SetData(2, 0, "Departments");
                dataGridViewX_MenuPer.SetData(3, 0, "Sections");
                dataGridViewX_MenuPer.SetData(4, 0, "Jobs");
                dataGridViewX_MenuPer.SetData(5, 0, "Sponsors");
                dataGridViewX_MenuPer.SetData(6, 0, "Projects");
                dataGridViewX_MenuPer.SetData(7, 0, "Nationalities");
                dataGridViewX_MenuPer.SetData(8, 0, "Contracts");
                dataGridViewX_MenuPer.SetData(9, 0, "Vacations Type");
                dataGridViewX_MenuPer.SetData(10, 0, "Cities");
                dataGridViewX_MenuPer.SetData(11, 0, "Religions");
                dataGridViewX_MenuPer.SetData(12, 0, "Cars");
                dataGridViewX_MenuPer.SetData(13, 0, "Treatments");
                dataGridViewX_MovePre.SetData(0, 0, "*");
                dataGridViewX_MovePre.SetData(0, 1, "Activation");
                dataGridViewX_MovePre.SetData(0, 2, "Add");
                dataGridViewX_MovePre.SetData(0, 3, "Edit");
                dataGridViewX_MovePre.SetData(0, 4, "Delete");
                dataGridViewX_MovePre.SetData(1, 0, "ADD");
                dataGridViewX_MovePre.SetData(2, 0, "Discount");
                dataGridViewX_MovePre.SetData(3, 0, "Vacations");
                dataGridViewX_MovePre.SetData(4, 0, "Tickets");
                dataGridViewX_MovePre.SetData(5, 0, "Advances");
                dataGridViewX_MovePre.SetData(6, 0, "Call");
                dataGridViewX_MovePre.SetData(7, 0, "Rewards");
                dataGridViewX_MovePre.SetData(8, 0, "Authorization");
                dataGridViewX_MovePre.SetData(9, 0, "Secretariats");
                dataGridViewX_MovePre.SetData(10, 0, "Visa Go And Back");
                dataGridViewX_MovePre.SetData(11, 0, "End Services");
                dataGridViewX_MovePre.SetData(12, 0, "Commentary");
                dataGridViewX_SalPer.SetData(0, 0, "*");
                dataGridViewX_SalPer.SetData(0, 1, "Activation");
                dataGridViewX_SalPer.SetData(1, 0, "Salaries Issuing");
                dataGridViewX_SalPer.SetData(2, 0, "Salaries Relay");
                dataGridViewX_SalPer.SetData(3, 0, "Cancel Salaries Relay");
                dataGridViewX_SalPer.SetData(4, 0, "Print Messier salaries");
                dataGridViewX_SalPer.SetData(5, 0, "Operation of Salaries");
                dataGridViewX_SalPer.SetData(6, 0, "increases and decreases Report");
                dataGridViewX_SalPer.SetData(7, 0, "Salary of Employee Report");
                dataGridViewX_SalPer.SetData(8, 0, "Allownce Employee");
                dataGridViewX_SalPer.SetData(9, 0, "Acconuns Generalization");
                dataGridViewX_SalPer.SetData(10, 0, "Create Gaid with Relay Salary");
                dataGridViewX_RepPre.SetData(0, 0, "*");
                dataGridViewX_RepPre.SetData(0, 1, "Activation");
                dataGridViewX_RepPre.SetData(1, 0, "Employee Report");
                dataGridViewX_RepPre.SetData(2, 0, "Employee ID");
                dataGridViewX_RepPre.SetData(3, 0, "Employee Passport");
                dataGridViewX_RepPre.SetData(4, 0, "Employee Forms");
                dataGridViewX_RepPre.SetData(5, 0, "Employee Licenses");
                dataGridViewX_RepPre.SetData(6, 0, "Employee Medical Allownce");
                dataGridViewX_RepPre.SetData(7, 0, "Update Documents");
                dataGridViewX_RepPre.SetData(8, 0, "Update Allownce Company");
                dataGridViewX_RepPre.SetData(9, 0, "Vacations Report");
                dataGridViewX_RepPre.SetData(10, 0, "Tickets Report");
                dataGridViewX_RepPre.SetData(11, 0, "Authorization Report");
                dataGridViewX_RepPre.SetData(12, 0, "Secretariats Report");
                dataGridViewX_RepPre.SetData(13, 0, "Visa Go And Back Report");
                dataGridViewX_RepPre.SetData(14, 0, "End Services Report");
                dataGridViewX_RepPre.SetData(15, 0, "Add Report");
                dataGridViewX_RepPre.SetData(16, 0, "Rewards Report");
                dataGridViewX_RepPre.SetData(17, 0, "Advances Report");
                dataGridViewX_RepPre.SetData(18, 0, "Call Report");
                dataGridViewX_RepPre.SetData(19, 0, "Discount Report");
                dataGridViewX_RepPre.SetData(20, 0, "Commentary Report");
                dataGridViewX_RepPre.SetData(21, 0, "Cars Report");
                dataGridViewX_RepPre.SetData(22, 0, "attend and leave Report");
                dataGridViewX_RepPre.SetData(23, 0, "Employee depend on Project");
                dataGridViewX_GenralPre.SetData(0, 0, "*");
                dataGridViewX_GenralPre.SetData(0, 1, "Activation");
                dataGridViewX_GenralPre.SetData(1, 0, "attend and Leave System");
                dataGridViewX_GenralPre.SetData(2, 0, "attend and Leave");
                dataGridViewX_GenralPre.SetData(3, 0, "attend and Leave Menual");
                dataGridViewX_GenralPre.SetData(4, 0, "Import attend and Leave Data");
                dataGridViewX_GenralPre.SetData(5, 0, "Generalization Attend and Leave");
                dataGridViewX_GenralPre.SetData(6, 0, "Edite Attend and Leave");
                dataGridViewX_GenralPre.SetData(7, 0, "Processing Attend and Leave");
                dataGridViewX_GenralPre.SetData(8, 0, "Relay Vacations");
                dataGridViewX_GenralPre.SetData(9, 0, "Relay Tickets");
                dataGridViewX_GenralPre.SetData(10, 0, "Relay Secretariats");
                dataGridViewX_GenralPre.SetData(11, 0, "Passport Forms");
                dataGridViewX_GenralPre.SetData(12, 0, "Update Documents");
                dataGridViewX_GenralPre.SetData(13, 0, "Approval of leave");
                dataGridViewX_HotelMenuPer.SetData(0, 0, "*");
                dataGridViewX_HotelMenuPer.SetData(0, 1, "Activation");
                dataGridViewX_HotelMenuPer.SetData(0, 2, "Add");
                dataGridViewX_HotelMenuPer.SetData(0, 3, "Edit");
                dataGridViewX_HotelMenuPer.SetData(0, 4, "Delete");
                dataGridViewX_HotelMenuPer.SetData(1, 0, "ID Types");
                dataGridViewX_HotelMenuPer.SetData(2, 0, "Jobs");
                dataGridViewX_HotelMenuPer.SetData(3, 0, "Services Types");
                dataGridViewX_HotelMenuPer.SetData(4, 0, "Nationalities");
                dataGridViewX_HotelMovePre.SetData(0, 0, "*");
                dataGridViewX_HotelMovePre.SetData(0, 1, "Activation");
                dataGridViewX_HotelMovePre.SetData(0, 2, "Add");
                dataGridViewX_HotelMovePre.SetData(0, 3, "Edit");
                dataGridViewX_HotelMovePre.SetData(0, 4, "Delete");
                dataGridViewX_HotelMovePre.SetData(1, 0, "Provide service");
                dataGridViewX_HotelMovePre.SetData(2, 0, "Phone calls");
                dataGridViewX_HotelMovePre.SetData(3, 0, "Black List");
                dataGridViewX_HotelMovePre.SetData(4, 0, "Guestroom data");
                dataGridViewX_HotelMovePre.SetData(5, 0, "Reservation data");
                dataGridViewX_HotelMovePre.SetData(6, 0, "Catch Bill For Guests");
                dataGridViewX_HotelMovePre.SetData(7, 0, "Exchange Bill For Guests");
                dataGridViewX_HotelRepPre.SetData(0, 0, "*");
                dataGridViewX_HotelRepPre.SetData(0, 1, "Activation");
                dataGridViewX_HotelRepPre.SetData(1, 0, "Daily Revenue");
                dataGridViewX_HotelRepPre.SetData(2, 0, "Guests Data");
                dataGridViewX_HotelRepPre.SetData(3, 0, "Report of inmates booking");
                dataGridViewX_HotelRepPre.SetData(4, 0, "Guest account report");
                dataGridViewX_HotelRepPre.SetData(5, 0, "Total guest account");
                dataGridViewX_HotelRepPre.SetData(6, 0, "Traffic service");
                dataGridViewX_HotelRepPre.SetData(7, 0, "Traffic Calls");
                dataGridViewX_HotelRepPre.SetData(8, 0, "Report room account");
                dataGridViewX_HotelRepPre.SetData(9, 0, "Room specifications");
                dataGridViewX_HotelRepPre.SetData(10, 0, "Movement of rooms");
                dataGridViewX_HotelRepPre.SetData(11, 0, "Maintenance of the room");
                dataGridViewX_HotelRepPre.SetData(12, 0, "Population transfer");
                dataGridViewX_HotelGenralPre.SetData(0, 0, "*");
                dataGridViewX_HotelGenralPre.SetData(0, 1, "Activation");
                dataGridViewX_HotelGenralPre.SetData(1, 0, "Transfer a guest");
                dataGridViewX_HotelGenralPre.SetData(2, 0, "Add Room");
                dataGridViewX_HotelGenralPre.SetData(3, 0, "Change Room Price");
                dataGridViewX_HotelGenralPre.SetData(4, 0, "Change Room Type");
                dataGridViewX_HotelGenralPre.SetData(5, 0, "Change Days Count");
                dataGridViewX_HotelGenralPre.SetData(6, 0, "Leave Room");
                dataGridViewX_HotelGenralPre.SetData(7, 0, "Room Maintenance");
                dataGridViewX_HotelGenralPre.SetData(8, 0, "End Of Room Maintenance");
                dataGridViewX_HotelGenralPre.SetData(9, 0, "Clear Room");
                dataGridViewX_HotelGenralPre.SetData(10, 0, "End of Clearing Room");
                dataGridViewX_HotelGenralPre.SetData(11, 0, "Room Data");
                dataGridViewX_HotelGenralPre.SetData(12, 0, "Call Rates");
                dataGridViewX_HotelGenralPre.SetData(13, 0, "Amendment of Departing Services");
                dataGridViewX_HotelGenralPre.SetData(14, 0, "Modify outgoing guest calls");
                dataGridViewX_HotelGenralPre.SetData(15, 0, "Auto Bound for stay Value");
                if (VarGeneral.vDemo && VarGeneral.UserID != 1)
                {
                    dataGridViewX_HotelGenralPre.Rows[12].Visible = false;
                }
                dataGridViewX_EqarFiles.SetData(0, 0, "*");
                dataGridViewX_EqarFiles.SetData(0, 1, "Activation");
                dataGridViewX_EqarFiles.SetData(0, 2, "Add");
                dataGridViewX_EqarFiles.SetData(0, 3, "Edit");
                dataGridViewX_EqarFiles.SetData(0, 4, "Delete");
                dataGridViewX_EqarFiles.SetData(1, 0, "Cities");
                dataGridViewX_EqarFiles.SetData(2, 0, "Nationalities");
                dataGridViewX_EqarFiles.SetData(3, 0, "Real estate Type");
                dataGridViewX_EqarFiles.SetData(4, 0, "Real estate Nature");
                dataGridViewX_EqarFiles.SetData(5, 0, "Real estate");
                dataGridViewX_EqarFiles.SetData(6, 0, "Real estate Sale");
                dataGridViewX_EqarFiles.SetData(7, 0, "Owners");
                dataGridViewX_Tenants.SetData(0, 0, "*");
                dataGridViewX_Tenants.SetData(0, 1, "Activation");
                dataGridViewX_Tenants.SetData(0, 2, "Add");
                dataGridViewX_Tenants.SetData(0, 3, "Edit");
                dataGridViewX_Tenants.SetData(0, 4, "Delete");
                dataGridViewX_Tenants.SetData(1, 0, "Tenant Data");
                dataGridViewX_Tenants.SetData(2, 0, "Tenant receipt voucher");
                dataGridViewX_Tenants.SetData(3, 0, "Tenant exchange voucher");
                dataGridViewX_Tenants.SetData(4, 0, "Tenant notices");
                dataGridViewX_RepEqar.SetData(0, 0, "*");
                dataGridViewX_RepEqar.SetData(0, 1, "Activation");
                dataGridViewX_RepEqar.SetData(1, 0, "Inquiries");
                dataGridViewX_RepEqar.SetData(2, 0, "Tenants' statement of account");
                dataGridViewX_RepEqar.SetData(3, 0, "Real estate account statement");
                dataGridViewX_RepEqar.SetData(4, 0, "Account statement of owners");
                dataGridViewX_RepEqar.SetData(5, 0, "Account detection");
                dataGridViewX_RepEqar.SetData(6, 0, "Rent collection report");
                dataGridViewX_RepEqar.Rows[4].Visible = false;
                dataGridViewX_RepEqar.Rows[5].Visible = false;
                dataGridViewX_GenralEqar.SetData(0, 0, "*");
                dataGridViewX_GenralEqar.SetData(0, 1, "Activation");
                dataGridViewX_GenralEqar.SetData(1, 0, "Contract design");
            }
            if (File.Exists(Application.StartupPath + "\\Script\\SecriptTegnicalCollage.dll"))
            {
                FlxFiles.SetData(7, 0, "الأســـاتذة");
                FlxFiles.SetData(9, 0, "الطــلاب");
                FlxInvoices.SetData(11, 0, "فاتورة اصدار عهدة");
                FlxInvoices.SetData(12, 0, "فاتورة إرجاع عهدة");
                FlxSRep.SetData(19, 1, "تقرير حركة صنف في فواتير اصدار عهدة");
                FlxSRep.SetData(20, 1, "تقرير حركة صنف في فواتير إرجاع عهدة");
                FlxSRep.SetData(28, 1, "البضاعة المصروفة - طالب");
                FlxFiles.Rows[12].Visible = false;
                FlxFiles.Rows[13].Visible = false;
                FlxFiles.Rows[14].Visible = false;
                FlxInvoices.Rows[1].Visible = false;
                FlxInvoices.Rows[2].Visible = false;
                FlxInvoices.Rows[5].Visible = false;
                FlxInvoices.Rows[6].Visible = false;
                FlxInvoices.Rows[9].Visible = false;
                FlxInvoices.Rows[10].Visible = false;
                FlxInvoices.Rows[14].Visible = false;
                FlxSRep.Rows[5].Visible = false;
                FlxSRep.Rows[6].Visible = false;
                FlxSRep.Rows[7].Visible = false;
                FlxSRep.Rows[9].Visible = false;
                FlxSRep.Rows[10].Visible = false;
                FlxSRep.Rows[11].Visible = false;
                FlxSRep.Rows[13].Visible = false;
                FlxSRep.Rows[14].Visible = false;
                FlxSRep.Rows[17].Visible = false;
                FlxSRep.Rows[18].Visible = false;
                FlxSRep.Rows[22].Visible = false;
                FlxSRep.Rows[23].Visible = false;
                FlxSRep.Rows[24].Visible = false;
                FlxSRep.Rows[25].Visible = false;
                FlxSRep.Rows[26].Visible = false;
                FlxSRep.Rows[27].Visible = false;
                FlxSetups.Rows[7].Visible = false;
                FlxSetups.Rows[8].Visible = false;
                FlxSetups.Rows[17].Visible = false;
                FlxSetups.Rows[32].Visible = false;
                FlxSetups.Rows[33].Visible = false;
                FlxSetups.Rows[34].Visible = false;
                FlxSetups.Rows[39].Visible = false;
                FlxSetups.Rows[40].Visible = false;
                FlxSetups.Rows[41].Visible = false;
                FlxSetups.Rows[42].Visible = false;
                FlxSetups.Rows[43].Visible = false;
                FlxSetups.Rows[45].Visible = false;
                FlxSetups.Rows[46].Visible = false;
                FlxSetups.Rows[47].Visible = false;
                ribbonTabItem_ACC.Visible = false;
                FlexType.Rows[0].Visible = false;
                FlexType.Rows[1].Visible = false;
                FlexType.Rows[4].Visible = false;
                FlexType.Rows[5].Visible = false;
                FlexType.Rows[8].Visible = false;
                FlexType.Rows[9].Visible = false;
                FlexType.SetData(10, 1, "فاتورة إصدار عهدة");
                FlexType.SetData(11, 1, "فاتورة إرجاع عهدة");
                if (VarGeneral.UserID != 1)
                {
                    ribbonTabItem_Other.Visible = false;
                }
            }
            if (File.Exists(Application.StartupPath + "\\Script\\SecriptWaterPackages.dll"))
            {
                FlxInvoices.Rows[11].Visible = false;
                FlxInvoices.Rows[12].Visible = false;
                FlxInvoices.Rows[14].Visible = false;
                FlxSRep.Rows[19].Visible = false;
                FlxSRep.Rows[20].Visible = false;
                FlexType.Rows[10].Visible = false;
                FlexType.Rows[11].Visible = false;
            }
        }
        private void textBox_ID_TextChanged(object sender, EventArgs e)
        {
            int no = 0;
            try
            {
                no = int.Parse(textBox_ID.Text);
            }
            catch
            {
            }
            try
            {
                T_User newData = dbc.RateUsr(no.ToString());
                if (newData == null || newData.Usr_ID == 0)
                {
                    if (!Button_Add.Visible || !Button_Add.Enabled)
                    {
                        MessageBox.Show((LangArEn == 0) ? "لا يمكن اتمام هذه العملية .. الرجاء مراجعة صلاحيات المستخدمين !" : "Can not complete this process .. please see the powers of the users!", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
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
                    int indexA = PKeys.IndexOf(newData.UsrNo ?? "");
                    indexA++;
                    TextBox_Index.InputTextChanged -= TextBox_Index_InputTextChanged;
                    TextBox_Index.TextBox.Text = string.Concat(indexA);
                    TextBox_Index.InputTextChanged += TextBox_Index_InputTextChanged;
                }
                try
                {
                    if (textBox_ID.Text == "1" || data_this.Usr_ID == 1)
                    {
                        IfDelete = false;
                        ribbonBar1.Enabled = false;
                    }
                    else
                    {
                        ribbonBar1.Enabled = true;
                        IfDelete = true;
                    }
                }
                catch
                {
                    IfDelete = false;
                    ribbonBar1.Enabled = false;
                }
                try
                {
                    if (textBox_ID.Text == "2" || data_this.Usr_ID == 2)
                    {
                        ifOkDelete = false;
                        return;
                    }
                }
                catch
                {
                    ifOkDelete = false;
                }
            }
            catch
            {
            }
            UpdateVcr();
        }
        public void Clear()
        {
            if (State == FormState.New)
            {
                return;
            }
            State = FormState.New;
            data_this = new T_User();
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
                else if (controls[i].GetType() == typeof(CheckBox) || controls.GetType() == typeof(CheckBoxX))
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
                        (controls[i] as ComboBox).SelectedIndex = -1;
                    }
                }
            }
            PicItemImg.Image = null;
            switchButton_ControlHeadOFRep.Value = false;
            chk11.Checked = false;
            switchButton_AdminOp.Value = false;
            CmbLanguge.SelectedIndex = 0;
            CmbStatus.SelectedIndex = 0;
            CmbBranch.SelectedIndex = 0;
            CmbInvPrice.SelectedIndex = 0;
            CmbInvPriceStop.SelectedIndex = 0;
            CmbSendOption.SelectedIndex = 0;
            CmbCommTyp.SelectedIndex = 0;
            CmbStores.SelectedIndex = 0;
            textBox_ID.Focus();
            for (int i = 0; i < FlexType.Rows.Count; i++)
            {
                try
                {
                    FlexType.SetData(i, 0, false);
                }
                catch
                {
                }
            }
            for (int iiCnt = 0; iiCnt < listStore.Count; iiCnt++)
            {
                try
                {
                    FlxStkQty.SetData(iiCnt, 1, false);
                }
                catch
                {
                }
            }
            SetReadOnly = false;
        }
        public void SetData(T_User value)
        {
            try
            {
                State = FormState.Saved;
                Button_Save.Enabled = false;
                int iiCnt = 0;
                textBox_ID.Tag = value.Usr_ID.ToString();
                txtUserName.Text = value.UsrNamA;
                txtUserNameE.Text = value.UsrNamE;
                txtPass.Text = VarGeneral.Decrypt(value.Pass);
                txtPassConf.Text = VarGeneral.Decrypt(value.Pass);
                switchButton_AdminOp.Value = VarGeneral.TString.ChkStatShow(value.RepInv1, 0);
                textBox_CommInv.Value = value.Comm_Inv.Value;
                textBox_CommGaid.Value = value.Comm_Gaid.Value;
                textBox_MaxDis.Value = value.MaxDiscountSals.Value;
                for (iiCnt = 0; iiCnt < CmbBranch.Items.Count; iiCnt++)
                {
                    CmbBranch.SelectedIndex = iiCnt;
                    if (CmbBranch.SelectedValue != null && CmbBranch.SelectedValue.ToString() == value.Brn)
                    {
                        break;
                    }
                }
                CmbLanguge.SelectedIndex = value.ProLng.Value;
                CmbStatus.SelectedIndex = value.Sts.Value;
                try
                {
                    if (value.DefStores.HasValue)
                    {
                        if (value.DefStores.Value > 0)
                        {
                            CmbStores.SelectedValue = value.DefStores.Value;
                        }
                        else
                        {
                            CmbStores.SelectedIndex = 0;
                        }
                    }
                }
                catch
                {
                    CmbStores.SelectedIndex = 0;
                }
                try
                {
                    CmbCommTyp.SelectedIndex = int.Parse(value.RepInv6);
                }
                catch
                {
                    CmbCommTyp.SelectedIndex = 0;
                }
                try
                {
                    CmbInvPrice.SelectedIndex = int.Parse(value.RepInv2.Trim());
                }
                catch
                {
                    CmbInvPrice.SelectedIndex = 0;
                }
                try
                {
                    CmbSendOption.SelectedIndex = int.Parse(value.RepInv3.Trim());
                }
                catch
                {
                    CmbSendOption.SelectedIndex = 0;
                }
                try
                {
                    CmbInvPriceStop.SelectedIndex = int.Parse(value.RepInv4.Trim());
                }
                catch
                {
                    CmbInvPriceStop.SelectedIndex = 0;
                }
                if (value.UsrImg != null)
                {
                    byte[] arr = value.UsrImg.ToArray();
                    MemoryStream stream = new MemoryStream(arr);
                    PicItemImg.Image = Image.FromStream(stream);
                }
                else
                {
                    PicItemImg.Image = null;
                }
                int Rat = 0;
                for (iiCnt = 1; iiCnt < FlxFiles.Rows.Count; iiCnt++)
                {
                    for (int I = 1; I < 5; I++)
                    {
                        if (FlxFiles.GetData(iiCnt, 0).ToString().Contains("تنفيذ"))
                        {
                        }
                        FlxFiles.SetData(iiCnt, I, VarGeneral.TString.ChkStatShow(value.FilStr, Rat));
                        Rat++;
                    }
                }
                Rat = 0;
                for (iiCnt = 1; iiCnt < FlxAccounting.Rows.Count; iiCnt++)
                {
                    for (int I = 1; I < 5; I++)
                    {
                        FlxAccounting.SetData(iiCnt, I, VarGeneral.TString.ChkStatShow(value.SndStr, Rat));
                        Rat++;
                    }
                }
                Rat = 0;
                for (iiCnt = 1; iiCnt < FlxInvoices.Rows.Count; iiCnt++)
                {
                    for (int I = 1; I < 5; I++)
                    {
                        FlxInvoices.SetData(iiCnt, I, VarGeneral.TString.ChkStatShow(value.InvStr, Rat));
                        Rat++;
                    }
                }
                for (iiCnt = 1; iiCnt < FlxInvoices.Rows.Count; iiCnt++)
                {
                    for (int I = 5; I < 6; I++)
                    {
                        FlxInvoices.SetData(iiCnt, I, VarGeneral.TString.ChkStatShow(value.InvStr, Rat));
                        Rat++;
                    }
                }
                Rat = 0;
                for (iiCnt = 1; iiCnt < FlxSRep.Rows.Count; iiCnt++)
                {
                    FlxSRep.SetData(iiCnt, 2, VarGeneral.TString.ChkStatShow(value.StkRep, Rat));
                    Rat++;
                }
                Rat = 0;
                for (iiCnt = 1; iiCnt < FlxAccRep.Rows.Count; iiCnt++)
                {
                    FlxAccRep.SetData(iiCnt, 1, VarGeneral.TString.ChkStatShow(value.AccRep, Rat));
                    Rat++;
                }
                Rat = 0;
                for (iiCnt = 1; iiCnt < FlxSetups.Rows.Count; iiCnt++)
                {
                    FlxSetups.SetData(iiCnt, 1, VarGeneral.TString.ChkStatShow(value.SetStr, Rat));
                    Rat++;
                }
                chk1.Checked = VarGeneral.TString.ChkStatShow(value.PassQty, 0);
                chk2.Checked = VarGeneral.TString.ChkStatShow(value.PassQty, 1);
                chk3.Checked = VarGeneral.TString.ChkStatShow(value.PassQty, 2);
                chk4.Checked = VarGeneral.TString.ChkStatShow(value.PassQty, 3);
                chk5.Checked = VarGeneral.TString.ChkStatShow(value.PassQty, 4);
                chk6.Checked = VarGeneral.TString.ChkStatShow(value.PassQty, 5);
                chk7.Checked = VarGeneral.TString.ChkStatShow(value.PassQty, 6);
                chk8.Checked = VarGeneral.TString.ChkStatShow(value.PassQty, 7);
                chk9.Checked = VarGeneral.TString.ChkStatShow(value.PassQty, 8);
                chk10.Checked = VarGeneral.TString.ChkStatShow(value.PassQty, 9);
                chk11.Checked = VarGeneral.TString.ChkStatShow(value.PassQty, 10);
                chk12.Checked = VarGeneral.TString.ChkStatShow(value.PassQty, 11);
                chk14.Checked = VarGeneral.TString.ChkStatShow(value.PassQty, 12);
                chk15.Checked = VarGeneral.TString.ChkStatShow(value.PassQty, 13);
                chk17.Checked = VarGeneral.TString.ChkStatShow(value.PassQty, 14);
                chk18.Checked = VarGeneral.TString.ChkStatShow(value.PassQty, 15);
                chk19.Checked = VarGeneral.TString.ChkStatShow(value.PassQty, 16);
                chk20.Checked = VarGeneral.TString.ChkStatShow(value.PassQty, 17);
                chk21.Checked = VarGeneral.TString.ChkStatShow(value.PassQty, 18);
                chk23.Checked = VarGeneral.TString.ChkStatShow(value.PassQty, 19);
                Rat = 0;
                for (iiCnt = 1; iiCnt < dataGridViewX_MenuPer.Rows.Count; iiCnt++)
                {
                    for (int I = 1; I < 5; I++)
                    {
                        dataGridViewX_MenuPer.SetData(iiCnt, I, VarGeneral.TString.ChkStatShow(value.Emp_FilStr, Rat));
                        Rat++;
                    }
                }
                Rat = 0;
                for (iiCnt = 1; iiCnt < dataGridViewX_MovePre.Rows.Count; iiCnt++)
                {
                    for (int I = 1; I < 5; I++)
                    {
                        dataGridViewX_MovePre.SetData(iiCnt, I, VarGeneral.TString.ChkStatShow(value.Emp_MovStr, Rat));
                        Rat++;
                    }
                }
                Rat = 0;
                for (iiCnt = 1; iiCnt < dataGridViewX_SalPer.Rows.Count; iiCnt++)
                {
                    dataGridViewX_SalPer.SetData(iiCnt, 1, VarGeneral.TString.ChkStatShow(value.Emp_SalStr, Rat));
                    Rat++;
                }
                Rat = 0;
                for (iiCnt = 1; iiCnt < dataGridViewX_RepPre.Rows.Count; iiCnt++)
                {
                    dataGridViewX_RepPre.SetData(iiCnt, 1, VarGeneral.TString.ChkStatShow(value.Emp_RepStr, Rat));
                    Rat++;
                }
                Rat = 0;
                for (iiCnt = 1; iiCnt < dataGridViewX_GenralPre.Rows.Count; iiCnt++)
                {
                    dataGridViewX_GenralPre.SetData(iiCnt, 1, VarGeneral.TString.ChkStatShow(value.Emp_GenStr, Rat));
                    Rat++;
                }
                Rat = 0;
                for (iiCnt = 1; iiCnt < dataGridViewX_HotelMenuPer.Rows.Count; iiCnt++)
                {
                    for (int I = 1; I < 5; I++)
                    {
                        dataGridViewX_HotelMenuPer.SetData(iiCnt, I, VarGeneral.TString.ChkStatShow(value.RepAcc1, Rat));
                        Rat++;
                    }
                }
                Rat = 0;
                for (iiCnt = 1; iiCnt < dataGridViewX_HotelMovePre.Rows.Count; iiCnt++)
                {
                    for (int I = 1; I < 5; I++)
                    {
                        dataGridViewX_HotelMovePre.SetData(iiCnt, I, VarGeneral.TString.ChkStatShow(value.RepAcc2, Rat));
                        Rat++;
                    }
                }
                Rat = 0;
                for (iiCnt = 1; iiCnt < dataGridViewX_HotelRepPre.Rows.Count; iiCnt++)
                {
                    dataGridViewX_HotelRepPre.SetData(iiCnt, 1, VarGeneral.TString.ChkStatShow(value.RepAcc3, Rat));
                    Rat++;
                }
                Rat = 0;
                for (iiCnt = 1; iiCnt < dataGridViewX_HotelGenralPre.Rows.Count; iiCnt++)
                {
                    dataGridViewX_HotelGenralPre.SetData(iiCnt, 1, VarGeneral.TString.ChkStatShow(value.RepAcc4, Rat));
                    Rat++;
                }
                Combo1.SelectedIndex = int.Parse(value.RepAcc5);
                Combo3.SelectedIndex = int.Parse(value.RepAcc6);
                try
                {
                    if (value.RepInv5 == "1")
                    {
                        chk13.Checked = true;
                    }
                    else
                    {
                        chk13.Checked = false;
                    }
                }
                catch
                {
                    chk13.Checked = false;
                }
                for (int i = 0; i < FlexType.Rows.Count; i++)
                {
                    try
                    {
                        FlexType.SetData(i, 0, VarGeneral.TString.ChkStatShow(value.PeaperTyp, i));
                    }
                    catch
                    {
                        FlexType.SetData(i, 0, false);
                    }
                }
                switchButton_ControlHeadOFRep.Value = VarGeneral.TString.ChkStatShow(value.StopBanner, 0);
                chk16.Checked = VarGeneral.TString.ChkStatShow(value.StopBanner, 1);
                chk22.Checked = VarGeneral.TString.ChkStatShow(value.StopBanner, 2);
                for (int j = 0; j < listStore.Count; j++)
                {
                    try
                    {
                        FlxStkQty.SetData(j, 1, false);
                    }
                    catch
                    {
                    }
                }
                List<string> _StorePr = value.StorePrmission.Split(',').ToList();
                for (int c = 0; c < _StorePr.Count; c++)
                {
                    if (string.IsNullOrEmpty(_StorePr[c]))
                    {
                        continue;
                    }
                    for (int i = 0; i < FlxStkQty.Rows.Count; i++)
                    {
                        try
                        {
                            if (FlxStkQty.Rows[i][0].ToString() == _StorePr[c])
                            {
                                FlxStkQty.SetData(i, 1, true);
                            }
                        }
                        catch
                        {
                        }
                    }
                }
                Rat = 0;
                for (iiCnt = 1; iiCnt < dataGridViewX_EqarFiles.Rows.Count; iiCnt++)
                {
                    for (int I = 1; I < 5; I++)
                    {
                        dataGridViewX_EqarFiles.SetData(iiCnt, I, VarGeneral.TString.ChkStatShow(value.Eqar_FilStr, Rat));
                        Rat++;
                    }
                }
                Rat = 0;
                for (iiCnt = 1; iiCnt < dataGridViewX_Tenants.Rows.Count; iiCnt++)
                {
                    for (int I = 1; I < 5; I++)
                    {
                        dataGridViewX_Tenants.SetData(iiCnt, I, VarGeneral.TString.ChkStatShow(value.Eqar_TenantStr, Rat));
                        Rat++;
                    }
                }
                Rat = 0;
                for (iiCnt = 1; iiCnt < dataGridViewX_RepEqar.Rows.Count; iiCnt++)
                {
                    dataGridViewX_RepEqar.SetData(iiCnt, 1, VarGeneral.TString.ChkStatShow(value.Eqar_RepStr, Rat));
                    Rat++;
                }
                Rat = 0;
                for (iiCnt = 1; iiCnt < dataGridViewX_GenralEqar.Rows.Count; iiCnt++)
                {
                    dataGridViewX_GenralEqar.SetData(iiCnt, 1, VarGeneral.TString.ChkStatShow(value.Eqar_GenStr, Rat));
                    Rat++;
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("SetData:", error, enable: true);
                MessageBox.Show(error.Message);
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
                    if (txtWidth.LockUpdateChecked && txtHeight.LockUpdateChecked)
                    {
                        PicItemImg.Image = resizeImage(Image.FromFile(mypic_path), new Size(txtWidth.Value, txtHeight.Value));
                    }
                    else
                    {
                        PicItemImg.Image = Image.FromFile(mypic_path);
                    }
                    Bitmap OriginalBM = new Bitmap(PicItemImg.Image);
                    PicItemImg.Image = OriginalBM;
                }
                Button_Edit_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void button_ClearPic_Click(object sender, EventArgs e)
        {
            Button_Edit_Click(sender, e);
            PicItemImg.Image = null;
        }
        private T_User GetData()
        {
            textBox_ID.Focus();
            data_this.UsrNo = textBox_ID.Text;
            data_this.UsrNamA = txtUserName.Text;
            data_this.UsrNamE = txtUserNameE.Text;
            data_this.Pass = VarGeneral.Encrypt(txtPass.Text);
            data_this.Brn = CmbBranch.SelectedValue.ToString();
            data_this.ProLng = CmbLanguge.SelectedIndex;
            if (CmbStores.SelectedIndex > 0)
            {
                data_this.DefStores = int.Parse(CmbStores.SelectedValue.ToString());
            }
            else
            {
                data_this.DefStores = 0;
            }
            data_this.RepInv6 = CmbCommTyp.SelectedIndex.ToString();
            data_this.Sts = CmbStatus.SelectedIndex;
            data_this.RepInv2 = CmbInvPrice.SelectedIndex.ToString().Trim();
            data_this.RepInv3 = CmbSendOption.SelectedIndex.ToString().Trim();
            data_this.RepInv4 = CmbInvPriceStop.SelectedIndex.ToString().Trim();
            data_this.Comm_Inv = textBox_CommInv.Value;
            data_this.Comm_Gaid = textBox_CommGaid.Value;
            data_this.MaxDiscountSals = textBox_MaxDis.Value;
            data_this.MaxDiscountPurchaes = textBox_MaxDis.Value;
            data_this.vColumnStr1 = "";
            data_this.vColumnStr2 = "";
            data_this.vColumnStr3 = "";
            data_this.vColumnStr4 = "";
            data_this.vColumnNum1 = 0.0;
            data_this.vColumnNum2 = 0;
            if (textBox_ID.Text != "1" && textBox_ID.Text != "2")
            {
                try
                {
                    if (switchButton_AdminOp.Value)
                    {
                        data_this.RepInv1 = "1";
                    }
                    else
                    {
                        data_this.RepInv1 = "0";
                    }
                }
                catch
                {
                    data_this.RepInv1 = "0";
                }
            }
            if (PicItemImg.Image != null)
            {
                MemoryStream stream = new MemoryStream();
                PicItemImg.Image.Save(stream, ImageFormat.Jpeg);
                byte[] arr = stream.GetBuffer();
                data_this.UsrImg = arr;
            }
            else
            {
                data_this.UsrImg = null;
            }
            string StrPR = "";
            for (int iiCnt = 1; iiCnt < FlxFiles.Rows.Count; iiCnt++)
            {
                for (int I = 1; I < 5; I++)
                {
                    StrPR += VarGeneral.TString.ChkStatSave(VarGeneral.TString.TEmptyBool(FlxFiles.GetData(iiCnt, I)));
                }
            }
            if (textBox_ID.Text != "1" && textBox_ID.Text != "2")
            {
                data_this.FilStr = StrPR;
            }
            StrPR = "";
            for (int iiCnt = 1; iiCnt < FlxAccounting.Rows.Count; iiCnt++)
            {
                for (int I = 1; I < 5; I++)
                {
                    StrPR += VarGeneral.TString.ChkStatSave(VarGeneral.TString.TEmptyBool(FlxAccounting.GetData(iiCnt, I)));
                }
            }
            if (textBox_ID.Text != "1" && textBox_ID.Text != "2")
            {
                data_this.SndStr = StrPR;
            }
            StrPR = "";
            for (int iiCnt = 1; iiCnt < FlxInvoices.Rows.Count; iiCnt++)
            {
                for (int I = 1; I < 5; I++)
                {
                    StrPR += VarGeneral.TString.ChkStatSave(VarGeneral.TString.TEmptyBool(FlxInvoices.GetData(iiCnt, I)));
                }
            }
            for (int iiCnt = 1; iiCnt < FlxInvoices.Rows.Count; iiCnt++)
            {
                for (int I = 5; I < 6; I++)
                {
                    StrPR += VarGeneral.TString.ChkStatSave(VarGeneral.TString.TEmptyBool(FlxInvoices.GetData(iiCnt, I)));
                }
            }
            if (textBox_ID.Text != "1" && textBox_ID.Text != "2")
            {
                data_this.InvStr = StrPR;
            }
            StrPR = "";
            for (int iiCnt = 1; iiCnt < FlxSRep.Rows.Count; iiCnt++)
            {
                StrPR += VarGeneral.TString.ChkStatSave(VarGeneral.TString.TEmptyBool(FlxSRep.GetData(iiCnt, 2)));
            }
            if (textBox_ID.Text != "1" && textBox_ID.Text != "2")
            {
                data_this.StkRep = StrPR;
            }
            StrPR = "";
            for (int iiCnt = 1; iiCnt < FlxAccRep.Rows.Count; iiCnt++)
            {
                StrPR += VarGeneral.TString.ChkStatSave(VarGeneral.TString.TEmptyBool(FlxAccRep.GetData(iiCnt, 1)));
            }
            if (textBox_ID.Text != "1" && textBox_ID.Text != "2")
            {
                data_this.AccRep = StrPR;
            }
            StrPR = "";
            for (int iiCnt = 1; iiCnt < FlxSetups.Rows.Count; iiCnt++)
            {
                StrPR += VarGeneral.TString.ChkStatSave(VarGeneral.TString.TEmptyBool(FlxSetups.GetData(iiCnt, 1)));
            }
            if (textBox_ID.Text != "1" && textBox_ID.Text != "2")
            {
                data_this.SetStr = StrPR + "00";
            }
            StrPR = "";
            StrPR += VarGeneral.TString.ChkStatSave(chk1.Checked);
            StrPR += VarGeneral.TString.ChkStatSave(chk2.Checked);
            StrPR += VarGeneral.TString.ChkStatSave(chk3.Checked);
            StrPR += VarGeneral.TString.ChkStatSave(chk4.Checked);
            StrPR += VarGeneral.TString.ChkStatSave(chk5.Checked);
            StrPR += VarGeneral.TString.ChkStatSave(chk6.Checked);
            StrPR += VarGeneral.TString.ChkStatSave(chk7.Checked);
            StrPR += VarGeneral.TString.ChkStatSave(chk8.Checked);
            StrPR += VarGeneral.TString.ChkStatSave(chk9.Checked);
            StrPR += VarGeneral.TString.ChkStatSave(chk10.Checked);
            StrPR += VarGeneral.TString.ChkStatSave(chk11.Checked);
            StrPR += VarGeneral.TString.ChkStatSave(chk12.Checked);
            StrPR += VarGeneral.TString.ChkStatSave(chk14.Checked);
            StrPR += VarGeneral.TString.ChkStatSave(chk15.Checked);
            StrPR += VarGeneral.TString.ChkStatSave(chk17.Checked);
            StrPR += VarGeneral.TString.ChkStatSave(chk18.Checked);
            StrPR += VarGeneral.TString.ChkStatSave(chk19.Checked);
            StrPR += VarGeneral.TString.ChkStatSave(chk20.Checked);
            StrPR += VarGeneral.TString.ChkStatSave(chk21.Checked);
            StrPR += VarGeneral.TString.ChkStatSave(chk23.Checked);
            data_this.PassQty = StrPR.Trim();
            StrPR = "";
            for (int iiCnt = 1; iiCnt < dataGridViewX_MenuPer.Rows.Count; iiCnt++)
            {
                for (int I = 1; I < 5; I++)
                {
                    StrPR += VarGeneral.TString.ChkStatSave(VarGeneral.TString.TEmptyBool(dataGridViewX_MenuPer.GetData(iiCnt, I)));
                }
            }
            if (textBox_ID.Text != "1" && textBox_ID.Text != "2")
            {
                data_this.Emp_FilStr = StrPR;
            }
            StrPR = "";
            for (int iiCnt = 1; iiCnt < dataGridViewX_MovePre.Rows.Count; iiCnt++)
            {
                for (int I = 1; I < 5; I++)
                {
                    StrPR += VarGeneral.TString.ChkStatSave(VarGeneral.TString.TEmptyBool(dataGridViewX_MovePre.GetData(iiCnt, I)));
                }
            }
            if (textBox_ID.Text != "1" && textBox_ID.Text != "2")
            {
                data_this.Emp_MovStr = StrPR;
            }
            StrPR = "";
            for (int iiCnt = 1; iiCnt < dataGridViewX_SalPer.Rows.Count; iiCnt++)
            {
                StrPR += VarGeneral.TString.ChkStatSave(VarGeneral.TString.TEmptyBool(dataGridViewX_SalPer.GetData(iiCnt, 1)));
            }
            if (textBox_ID.Text != "1" && textBox_ID.Text != "2")
            {
                data_this.Emp_SalStr = StrPR;
            }
            StrPR = "";
            for (int iiCnt = 1; iiCnt < dataGridViewX_RepPre.Rows.Count; iiCnt++)
            {
                StrPR += VarGeneral.TString.ChkStatSave(VarGeneral.TString.TEmptyBool(dataGridViewX_RepPre.GetData(iiCnt, 1)));
            }
            if (textBox_ID.Text != "1" && textBox_ID.Text != "2")
            {
                data_this.Emp_RepStr = StrPR;
            }
            StrPR = "";
            for (int iiCnt = 1; iiCnt < dataGridViewX_GenralPre.Rows.Count; iiCnt++)
            {
                StrPR += VarGeneral.TString.ChkStatSave(VarGeneral.TString.TEmptyBool(dataGridViewX_GenralPre.GetData(iiCnt, 1)));
            }
            if (textBox_ID.Text != "1" && textBox_ID.Text != "2")
            {
                data_this.Emp_GenStr = StrPR;
            }
            StrPR = "";
            for (int iiCnt = 1; iiCnt < dataGridViewX_HotelMenuPer.Rows.Count; iiCnt++)
            {
                for (int I = 1; I < 5; I++)
                {
                    StrPR += VarGeneral.TString.ChkStatSave(VarGeneral.TString.TEmptyBool(dataGridViewX_HotelMenuPer.GetData(iiCnt, I)));
                }
            }
            if (textBox_ID.Text != "1" && textBox_ID.Text != "2")
            {
                data_this.RepAcc1 = StrPR;
            }
            StrPR = "";
            for (int iiCnt = 1; iiCnt < dataGridViewX_HotelMovePre.Rows.Count; iiCnt++)
            {
                for (int I = 1; I < 5; I++)
                {
                    StrPR += VarGeneral.TString.ChkStatSave(VarGeneral.TString.TEmptyBool(dataGridViewX_HotelMovePre.GetData(iiCnt, I)));
                }
            }
            if (textBox_ID.Text != "1" && textBox_ID.Text != "2")
            {
                data_this.RepAcc2 = StrPR;
            }
            StrPR = "";
            for (int iiCnt = 1; iiCnt < dataGridViewX_HotelRepPre.Rows.Count; iiCnt++)
            {
                StrPR += VarGeneral.TString.ChkStatSave(VarGeneral.TString.TEmptyBool(dataGridViewX_HotelRepPre.GetData(iiCnt, 1)));
            }
            if (textBox_ID.Text != "1" && textBox_ID.Text != "2")
            {
                data_this.RepAcc3 = StrPR;
            }
            StrPR = "";
            for (int iiCnt = 1; iiCnt < dataGridViewX_HotelGenralPre.Rows.Count; iiCnt++)
            {
                StrPR += VarGeneral.TString.ChkStatSave(VarGeneral.TString.TEmptyBool(dataGridViewX_HotelGenralPre.GetData(iiCnt, 1)));
            }
            if (textBox_ID.Text != "1" && textBox_ID.Text != "2")
            {
                data_this.RepAcc4 = StrPR;
            }
            data_this.RepAcc5 = Combo1.SelectedIndex.ToString();
            data_this.RepAcc6 = Combo3.SelectedIndex.ToString();
            data_this.RepInv5 = (chk13.Checked ? "1" : "0");
            string _peaperTp = "";
            for (int i = 0; i < FlexType.Rows.Count; i++)
            {
                try
                {
                    _peaperTp = (Convert.ToBoolean(FlexType.Rows[i][0].ToString()) ? (_peaperTp + "1") : (_peaperTp + "0"));
                }
                catch
                {
                    _peaperTp += "0";
                }
            }
            data_this.PeaperTyp = _peaperTp;
            data_this.StopBanner = VarGeneral.TString.ChkStatSave(VarGeneral.TString.TEmptyBool(switchButton_ControlHeadOFRep.Value)) + VarGeneral.TString.ChkStatSave(VarGeneral.TString.TEmptyBool(chk16.Checked)) + VarGeneral.TString.ChkStatSave(VarGeneral.TString.TEmptyBool(chk22.Checked));
            string _StorePr = "";
            for (int i = 0; i < FlxStkQty.Rows.Count; i++)
            {
                try
                {
                    if (Convert.ToBoolean(FlxStkQty.Rows[i][1].ToString()))
                    {
                        _StorePr = _StorePr + "," + FlxStkQty.Rows[i][0].ToString();
                    }
                }
                catch
                {
                }
            }
            data_this.StorePrmission = _StorePr;
            StrPR = "";
            for (int iiCnt = 1; iiCnt < dataGridViewX_EqarFiles.Rows.Count; iiCnt++)
            {
                for (int I = 1; I < 5; I++)
                {
                    StrPR += VarGeneral.TString.ChkStatSave(VarGeneral.TString.TEmptyBool(dataGridViewX_EqarFiles.GetData(iiCnt, I)));
                }
            }
            if (textBox_ID.Text != "1" && textBox_ID.Text != "2")
            {
                data_this.Eqar_FilStr = StrPR;
            }
            StrPR = "";
            for (int iiCnt = 1; iiCnt < dataGridViewX_Tenants.Rows.Count; iiCnt++)
            {
                for (int I = 1; I < 5; I++)
                {
                    StrPR += VarGeneral.TString.ChkStatSave(VarGeneral.TString.TEmptyBool(dataGridViewX_Tenants.GetData(iiCnt, I)));
                }
            }
            if (textBox_ID.Text != "1" && textBox_ID.Text != "2")
            {
                data_this.Eqar_TenantStr = StrPR;
            }
            StrPR = "";
            for (int iiCnt = 1; iiCnt < dataGridViewX_RepEqar.Rows.Count; iiCnt++)
            {
                StrPR += VarGeneral.TString.ChkStatSave(VarGeneral.TString.TEmptyBool(dataGridViewX_RepEqar.GetData(iiCnt, 1)));
            }
            if (textBox_ID.Text != "1" && textBox_ID.Text != "2")
            {
                data_this.Eqar_RepStr = StrPR;
            }
            StrPR = "";
            for (int iiCnt = 1; iiCnt < dataGridViewX_GenralEqar.Rows.Count; iiCnt++)
            {
                StrPR += VarGeneral.TString.ChkStatSave(VarGeneral.TString.TEmptyBool(dataGridViewX_GenralEqar.GetData(iiCnt, 1)));
            }
            if (textBox_ID.Text != "1" && textBox_ID.Text != "2")
            {
                data_this.Eqar_GenStr = StrPR;
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
                SetReadOnly = false;
            }
        }
        public static Image resizeImage(Image imgToResize, Size size)
        {
            return new Bitmap(imgToResize, size);
        }
        private void Button_Add_Click(object sender, EventArgs e)
        {
            if (!Button_Add.Visible || !Button_Add.Enabled)
            {
                MessageBox.Show((LangArEn == 0) ? "لا يمكن اتمام هذه العملية .. الرجاء مراجعة صلاحيات المستخدمين !" : "Can not complete this process .. please see the powers of the users!", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else if (State != FormState.Edit || MessageBox.Show((LangArEn == 0) ? "تم تعديل السجل الحالي دون حفظ التغييرات .. هل تريد المتابعة؟" : "Not saved the changes, do you really want to continue?", VarGeneral.ProdectNam, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                int max = 0;
                max = dbc.MaxUsrNo;
                Clear();
                textBox_ID.Text = max.ToString();
                State = FormState.New;
            }
        }
        private void Button_Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Button_Save.Enabled)
                {
                    return;
                }
                if (State == FormState.Edit && !CanEdit)
                {
                    MessageBox.Show((LangArEn == 0) ? "لا يمكن اتمام هذه العملية .. الرجاء مراجعة صلاحيات المستخدمين !" : "Can not complete this process .. please see the powers of the users!", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                if (State == FormState.New && !Button_Add.Enabled)
                {
                    MessageBox.Show((LangArEn == 0) ? "لا يمكن اتمام هذه العملية .. الرجاء مراجعة صلاحيات المستخدمين !" : "Can not complete this process .. please see the powers of the users!", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                textBox_ID.Focus();
                if (textBox_ID.Text == "")
                {
                    MessageBox.Show((LangArEn == 0) ? "لايمكن ان يكون الرقم فارغا\u0651 " : "Can't No empty", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    textBox_ID.Focus();
                    return;
                }
                if (txtUserName.Text == "")
                {
                    MessageBox.Show((LangArEn == 0) ? "لايمكن ان يكون الاسم العربي فارغا\u0651 " : "Can't Arabic name empty", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    txtUserName.Focus();
                    return;
                }
                if (txtUserNameE.Text == "")
                {
                    MessageBox.Show((LangArEn == 0) ? "لايمكن ان يكون الاسم الانجليزي فارغا\u0651 " : "Can't English Name empty", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    txtUserNameE.Focus();
                    return;
                }
                if (txtPass.Text == "")
                {
                    MessageBox.Show((LangArEn == 0) ? "لايمكن ان يكون الرقم السري فارغا\u0651 " : "Can't password empty", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    txtPass.Focus();
                    return;
                }
                if (txtPass.Text.Trim() != txtPassConf.Text.Trim())
                {
                    MessageBox.Show((LangArEn == 0) ? "كلمة المرور غير متطابقة حاول مرة اخرى " : "Password is UnCorrecte", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    txtPass.Focus();
                    return;
                }
                if (State == FormState.New)
                {
                    GetData();
                    try
                    {
                        data_this.CreateGaid = 0;
                        data_this.UserPointTyp = 0;
                        data_this.CashAccNo_C = "";
                        data_this.CashAccNo_D = "";
                        data_this.NetworkAccNo_C = "";
                        data_this.NetworkAccNo_D = "";
                        data_this.CreaditAccNo_C = "";
                        data_this.CreaditAccNo_D = "";
                        data_this.CashAccNo_C_R = "";
                        data_this.CashAccNo_D_R = "";
                        data_this.NetworkAccNo_C_R = "";
                        data_this.NetworkAccNo_D_R = "";
                        data_this.CreaditAccNo_C_R = "";
                        data_this.CreaditAccNo_D_R = "";
                        dbc.T_Users.InsertOnSubmit(data_this);
                        dbc.SubmitChanges();
                        //	db.ExecuteCommand(DBUdate.DbUpdates.CopySttingString.Replace("usIds", data_this.Usr_ID.ToString()));
                    }
                    catch (SqlException ex3)
                    {
                        int max = 0;
                        max = dbc.MaxUsrNo;
                        if (ex3.Number != 2627)
                        {
                            return;
                        }
                        MessageBox.Show("الرمز مستخدم من قبل.\n سيتم الحفظ برقم جديد [" + max + "]", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        textBox_ID.Text = string.Concat(max);
                        data_this.UsrNo = string.Concat(max);
                        Button_Save_Click(sender, e);
                    }
                    catch (Exception)
                    {
                        return;
                    }
                }
                else if (State == FormState.Edit)
                {
                    GetData();
                    try
                    {
                        dbc.Log = VarGeneral.DebugLog;
                        dbc.SubmitChanges(ConflictMode.ContinueOnConflict);
                    }
                    catch (SqlException)
                    {
                        return;
                    }
                    catch (Exception)
                    {
                        return;
                    }
                }
                State = FormState.Saved;
                RefreshPKeys();
                TextBox_Index.TextBox.Text = string.Concat(PKeys.IndexOf(data_this.UsrNo ?? "") + 1);
                SetReadOnly = true;
                DBUdate.DbUpdates.updateusersettings();
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Save:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void Button_Delete_Click(object sender, EventArgs e)
        {
            if (!Button_Delete.Enabled || !Button_Delete.Visible || State != 0)
            {
                ifOkDelete = false;
                return;
            }
            string Code = "";
            if (codeControl != null)
            {
                Code = codeControl.Text;
            }
            if (Code == "")
            {
                ifOkDelete = false;
                return;
            }
            try
            {
                if (textBox_ID.Text == "1" || data_this.Usr_ID == 1)
                {
                    ifOkDelete = false;
                    return;
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
                return;
            }
            try
            {
                if (textBox_ID.Text == "2" || data_this.Usr_ID == 2)
                {
                    ifOkDelete = false;
                    return;
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
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
            if (data_this == null || data_this.Usr_ID == 0 || !ifOkDelete)
            {
                return;
            }
            T_GDHEAD returned = db.SelectUsrNoByReturnNo(DataThis.UsrNo);
            if (returned != null && !string.IsNullOrEmpty(returned.gdUser))
            {
                MessageBox.Show((LangArEn == 0) ? "لايمكن حذف المستخدم .. لانه مرتبط باحد القيود" : "You can not delete User .. because it is tied to a Gaid", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            data_this = dbc.RateUsr(DataThis.UsrNo.ToString());
            try
            {
                dbc.T_Users.DeleteOnSubmit(DataThis);
                dbc.SubmitChanges();
            }
            catch (SqlException)
            {
                data_this = dbc.RateUsr(DataThis.UsrNo.ToString());
                return;
            }
            catch (Exception)
            {
                data_this = dbc.RateUsr(DataThis.UsrNo.ToString());
                return;
            }
            Clear();
            RefreshPKeys();
            textBox_ID.Text = PKeys.LastOrDefault();
        }
        private void DGV_Main_DataBindingComplete(object sender, GridDataBindingCompleteEventArgs e)
        {
            GridPanel panel = e.GridPanel;
            string dataMember = panel.DataMember;
            if (dataMember != null && dataMember == "T_User")
            {
                PropUsrPanel(panel);
            }
        }
        private void PropUsrPanel(GridPanel panel)
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
            panel.Columns["UsrNo"].Width = 165;
            panel.Columns["UsrNo"].Visible = columns_Names_visible["UsrNo"].IfDefault;
            panel.Columns["UsrNamA"].Width = 280;
            panel.Columns["UsrNamA"].Visible = columns_Names_visible["UsrNamA"].IfDefault;
            panel.Columns["UsrNamE"].Width = 280;
            panel.Columns["UsrNamE"].Visible = columns_Names_visible["UsrNamE"].IfDefault;
            panel.ReadOnly = true;
        }
        private void DGV_MainGetCellStyle(object sender, GridGetCellStyleEventArgs e)
        {
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
                ExportExcel.ExportToExcel(DGV_Main, "تقرير المستخدمين");
            }
            catch
            {
            }
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
                controls.Add(txtPass);
                codeControl = textBox_ID;
                controls.Add(textBox_CommInv);
                controls.Add(textBox_CommGaid);
                controls.Add(textBox_MaxDis);
                controls.Add(txtPassConf);
                controls.Add(txtUserName);
                controls.Add(txtUserNameE);
                controls.Add(CmbBranch);
                controls.Add(CmbLanguge);
                controls.Add(CmbStores);
                controls.Add(CmbStatus);
                controls.Add(CmbInvPrice);
                controls.Add(CmbInvPriceStop);
                controls.Add(CmbSendOption);
                controls.Add(FlxAccounting);
                controls.Add(textBox_ID);
                controls.Add(FlxAccRep);
                controls.Add(FlxFiles);
                controls.Add(PicItemImg);
                controls.Add(chk1);
                controls.Add(chk2);
                controls.Add(chk3);
                controls.Add(chk4);
                controls.Add(chk5);
                controls.Add(chk6);
                controls.Add(chk7);
                controls.Add(chk8);
                controls.Add(chk9);
                controls.Add(chk10);
                controls.Add(chk12);
                controls.Add(chk13);
                controls.Add(chk14);
                controls.Add(chk15);
                controls.Add(chk16);
                controls.Add(chk17);
                controls.Add(chk18);
                controls.Add(chk19);
                controls.Add(chk20);
                controls.Add(chk21);
                controls.Add(chk22);
                controls.Add(chk23);
                controls.Add(switchButton_ControlHeadOFRep);
                controls.Add(FlxInvoices);
                controls.Add(FlxSetups);
                controls.Add(dataGridViewX_GenralPre);
                controls.Add(dataGridViewX_MenuPer);
                controls.Add(dataGridViewX_MovePre);
                controls.Add(dataGridViewX_RepPre);
                controls.Add(dataGridViewX_SalPer);
                controls.Add(FlxSRep);
                controls.Add(Combo1);
                controls.Add(dataGridViewX_HotelGenralPre);
                controls.Add(dataGridViewX_HotelMenuPer);
                controls.Add(dataGridViewX_HotelMovePre);
                controls.Add(dataGridViewX_HotelRepPre);
                controls.Add(Combo3);
                controls.Add(CmbCommTyp);
                controls.Add(dataGridViewX_EqarFiles);
                controls.Add(dataGridViewX_Tenants);
                controls.Add(dataGridViewX_RepEqar);
                controls.Add(dataGridViewX_GenralEqar);
            }
            catch (SqlException)
            {
            }
        }
        private void FrmUsr_KeyDown(object sender, KeyEventArgs e)
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
        private void txtUserName_Enter(object sender, EventArgs e)
        {
            Language.Switch("AR");
        }
        private void txtUserNameE_Enter(object sender, EventArgs e)
        {
            Language.Switch("EN");
        }
        private void textBox_ID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (e.KeyChar != '\b'))
            {
                e.Handled = true;
            }
        }
        private void buttonItem_SelectAll_Click(object sender, EventArgs e)
        {
            Button_Edit_Click(sender, e);
            if (ribbonControl_Setting.SelectedRibbonTabItem.Name == "ribbonTabItem_General")
            {
                for (int i = 1; i < FlxSetups.Rows.Count; i++)
                {
                    FlxSetups.SetData(i, 1, true);
                }
            }
            else if (ribbonControl_Setting.SelectedRibbonTabItem.Name == "ribbonTabItem_Files")
            {
                for (int i = 1; i < FlxFiles.Rows.Count; i++)
                {
                    FlxFiles.SetData(i, 1, true);
                    FlxFiles.SetData(i, 2, true);
                    FlxFiles.SetData(i, 3, true);
                    FlxFiles.SetData(i, 4, true);
                }
            }
            else if (ribbonControl_Setting.SelectedRibbonTabItem.Name == "ribbonTabItem_ACC")
            {
                for (int i = 1; i < FlxAccounting.Rows.Count; i++)
                {
                    FlxAccounting.SetData(i, 1, true);
                    FlxAccounting.SetData(i, 2, true);
                    FlxAccounting.SetData(i, 3, true);
                    FlxAccounting.SetData(i, 4, true);
                }
            }
            else if (ribbonControl_Setting.SelectedRibbonTabItem.Name == "ribbonTabItem_Inv")
            {
                for (int i = 1; i < FlxInvoices.Rows.Count; i++)
                {
                    FlxInvoices.SetData(i, 1, true);
                    FlxInvoices.SetData(i, 2, true);
                    FlxInvoices.SetData(i, 3, true);
                    FlxInvoices.SetData(i, 4, true);
                    FlxInvoices.SetData(i, 5, true);
                }
            }
            else if (ribbonControl_Setting.SelectedRibbonTabItem.Name == "ribbonTabItem_RepStocks")
            {
                for (int i = 1; i < FlxSRep.Rows.Count; i++)
                {
                    FlxSRep.SetData(i, 2, true);
                }
            }
            else if (ribbonControl_Setting.SelectedRibbonTabItem.Name == "ribbonTabItem_RepAcc")
            {
                for (int i = 1; i < FlxAccRep.Rows.Count; i++)
                {
                    FlxAccRep.SetData(i, 1, true);
                }
            }
            else if (ribbonControl_Setting.SelectedRibbonTabItem.Name == "ribbonTabItem_Emps")
            {
                if (MenuPer.Checked)
                {
                    for (int i = 1; i < dataGridViewX_MenuPer.Rows.Count; i++)
                    {
                        dataGridViewX_MenuPer.SetData(i, 1, true);
                        dataGridViewX_MenuPer.SetData(i, 2, true);
                        dataGridViewX_MenuPer.SetData(i, 3, true);
                        dataGridViewX_MenuPer.SetData(i, 4, true);
                    }
                }
                else if (MovePre.Checked)
                {
                    for (int i = 1; i < dataGridViewX_MovePre.Rows.Count; i++)
                    {
                        dataGridViewX_MovePre.SetData(i, 1, true);
                        dataGridViewX_MovePre.SetData(i, 2, true);
                        dataGridViewX_MovePre.SetData(i, 3, true);
                        dataGridViewX_MovePre.SetData(i, 4, true);
                    }
                }
                else if (SalPer.Checked)
                {
                    for (int i = 1; i < dataGridViewX_SalPer.Rows.Count; i++)
                    {
                        dataGridViewX_SalPer.SetData(i, 1, true);
                    }
                }
                else if (RepPre.Checked)
                {
                    for (int i = 1; i < dataGridViewX_RepPre.Rows.Count; i++)
                    {
                        dataGridViewX_RepPre.SetData(i, 1, true);
                    }
                }
                else if (GenralPre.Checked)
                {
                    for (int i = 1; i < dataGridViewX_GenralPre.Rows.Count; i++)
                    {
                        dataGridViewX_GenralPre.SetData(i, 1, true);
                    }
                }
            }
            else if (ribbonControl_Setting.SelectedRibbonTabItem.Name == "ribbonTabItem_Hotels")
            {
                if (HotelMenuPer.Checked)
                {
                    for (int i = 1; i < dataGridViewX_HotelMenuPer.Rows.Count; i++)
                    {
                        dataGridViewX_HotelMenuPer.SetData(i, 1, true);
                        dataGridViewX_HotelMenuPer.SetData(i, 2, true);
                        dataGridViewX_HotelMenuPer.SetData(i, 3, true);
                        dataGridViewX_HotelMenuPer.SetData(i, 4, true);
                    }
                }
                else if (HotelMovePre.Checked)
                {
                    for (int i = 1; i < dataGridViewX_HotelMovePre.Rows.Count; i++)
                    {
                        dataGridViewX_HotelMovePre.SetData(i, 1, true);
                        dataGridViewX_HotelMovePre.SetData(i, 2, true);
                        dataGridViewX_HotelMovePre.SetData(i, 3, true);
                        dataGridViewX_HotelMovePre.SetData(i, 4, true);
                    }
                }
                else if (HotelRepPre.Checked)
                {
                    for (int i = 1; i < dataGridViewX_HotelRepPre.Rows.Count; i++)
                    {
                        dataGridViewX_HotelRepPre.SetData(i, 1, true);
                    }
                }
                else if (HotelGenralPre.Checked)
                {
                    for (int i = 1; i < dataGridViewX_HotelGenralPre.Rows.Count; i++)
                    {
                        dataGridViewX_HotelGenralPre.SetData(i, 1, true);
                    }
                }
            }
            else
            {
                if (!(ribbonControl_Setting.SelectedRibbonTabItem.Name == "ribbonTabItem_Eqar"))
                {
                    return;
                }
                if (EqarFiles.Checked)
                {
                    for (int i = 1; i < dataGridViewX_EqarFiles.Rows.Count; i++)
                    {
                        dataGridViewX_EqarFiles.SetData(i, 1, true);
                        dataGridViewX_EqarFiles.SetData(i, 2, true);
                        dataGridViewX_EqarFiles.SetData(i, 3, true);
                        dataGridViewX_EqarFiles.SetData(i, 4, true);
                    }
                }
                else if (EqarTenant.Checked)
                {
                    for (int i = 1; i < dataGridViewX_Tenants.Rows.Count; i++)
                    {
                        dataGridViewX_Tenants.SetData(i, 1, true);
                        dataGridViewX_Tenants.SetData(i, 2, true);
                        dataGridViewX_Tenants.SetData(i, 3, true);
                        dataGridViewX_Tenants.SetData(i, 4, true);
                    }
                }
                else if (EqarsRep.Checked)
                {
                    for (int i = 1; i < dataGridViewX_RepEqar.Rows.Count; i++)
                    {
                        dataGridViewX_RepEqar.SetData(i, 1, true);
                    }
                }
                else if (EqarGenarl.Checked)
                {
                    for (int i = 1; i < dataGridViewX_GenralEqar.Rows.Count; i++)
                    {
                        dataGridViewX_GenralEqar.SetData(i, 1, true);
                    }
                }
            }
        }
        private void buttonItem_UnSelectAll_Click(object sender, EventArgs e)
        {
            Button_Edit_Click(sender, e);
            if (ribbonControl_Setting.SelectedRibbonTabItem.Name == "ribbonTabItem_General")
            {
                for (int i = 1; i < FlxSetups.Rows.Count; i++)
                {
                    FlxSetups.SetData(i, 1, false);
                }
            }
            else if (ribbonControl_Setting.SelectedRibbonTabItem.Name == "ribbonTabItem_Files")
            {
                for (int i = 1; i < FlxFiles.Rows.Count; i++)
                {
                    FlxFiles.SetData(i, 1, false);
                    FlxFiles.SetData(i, 2, false);
                    FlxFiles.SetData(i, 3, false);
                    FlxFiles.SetData(i, 4, false);
                }
            }
            else if (ribbonControl_Setting.SelectedRibbonTabItem.Name == "ribbonTabItem_ACC")
            {
                for (int i = 1; i < FlxAccounting.Rows.Count; i++)
                {
                    FlxAccounting.SetData(i, 1, false);
                    FlxAccounting.SetData(i, 2, false);
                    FlxAccounting.SetData(i, 3, false);
                    FlxAccounting.SetData(i, 4, false);
                }
            }
            else if (ribbonControl_Setting.SelectedRibbonTabItem.Name == "ribbonTabItem_Inv")
            {
                for (int i = 1; i < FlxInvoices.Rows.Count; i++)
                {
                    FlxInvoices.SetData(i, 1, false);
                    FlxInvoices.SetData(i, 2, false);
                    FlxInvoices.SetData(i, 3, false);
                    FlxInvoices.SetData(i, 4, false);
                    FlxInvoices.SetData(i, 5, false);
                }
            }
            else if (ribbonControl_Setting.SelectedRibbonTabItem.Name == "ribbonTabItem_RepStocks")
            {
                for (int i = 1; i < FlxSRep.Rows.Count; i++)
                {
                    FlxSRep.SetData(i, 2, false);
                }
            }
            else if (ribbonControl_Setting.SelectedRibbonTabItem.Name == "ribbonTabItem_RepAcc")
            {
                for (int i = 1; i < FlxAccRep.Rows.Count; i++)
                {
                    FlxAccRep.SetData(i, 1, false);
                }
            }
            else if (ribbonControl_Setting.SelectedRibbonTabItem.Name == "ribbonTabItem_Emps")
            {
                if (MenuPer.Checked)
                {
                    for (int i = 1; i < dataGridViewX_MenuPer.Rows.Count; i++)
                    {
                        dataGridViewX_MenuPer.SetData(i, 1, false);
                        dataGridViewX_MenuPer.SetData(i, 2, false);
                        dataGridViewX_MenuPer.SetData(i, 3, false);
                        dataGridViewX_MenuPer.SetData(i, 4, false);
                    }
                }
                else if (MovePre.Checked)
                {
                    for (int i = 1; i < dataGridViewX_MovePre.Rows.Count; i++)
                    {
                        dataGridViewX_MovePre.SetData(i, 1, false);
                        dataGridViewX_MovePre.SetData(i, 2, false);
                        dataGridViewX_MovePre.SetData(i, 3, false);
                        dataGridViewX_MovePre.SetData(i, 4, false);
                    }
                }
                else if (SalPer.Checked)
                {
                    for (int i = 1; i < dataGridViewX_SalPer.Rows.Count; i++)
                    {
                        dataGridViewX_SalPer.SetData(i, 1, false);
                    }
                }
                else if (RepPre.Checked)
                {
                    for (int i = 1; i < dataGridViewX_RepPre.Rows.Count; i++)
                    {
                        dataGridViewX_RepPre.SetData(i, 1, false);
                    }
                }
                else if (GenralPre.Checked)
                {
                    for (int i = 1; i < dataGridViewX_GenralPre.Rows.Count; i++)
                    {
                        dataGridViewX_GenralPre.SetData(i, 1, false);
                    }
                }
            }
            else if (ribbonControl_Setting.SelectedRibbonTabItem.Name == "ribbonTabItem_Hotels")
            {
                if (HotelMenuPer.Checked)
                {
                    for (int i = 1; i < dataGridViewX_HotelMenuPer.Rows.Count; i++)
                    {
                        dataGridViewX_HotelMenuPer.SetData(i, 1, false);
                        dataGridViewX_HotelMenuPer.SetData(i, 2, false);
                        dataGridViewX_HotelMenuPer.SetData(i, 3, false);
                        dataGridViewX_HotelMenuPer.SetData(i, 4, false);
                    }
                }
                else if (HotelMovePre.Checked)
                {
                    for (int i = 1; i < dataGridViewX_HotelMovePre.Rows.Count; i++)
                    {
                        dataGridViewX_HotelMovePre.SetData(i, 1, false);
                        dataGridViewX_HotelMovePre.SetData(i, 2, false);
                        dataGridViewX_HotelMovePre.SetData(i, 3, false);
                        dataGridViewX_HotelMovePre.SetData(i, 4, false);
                    }
                }
                else if (HotelRepPre.Checked)
                {
                    for (int i = 1; i < dataGridViewX_HotelRepPre.Rows.Count; i++)
                    {
                        dataGridViewX_HotelRepPre.SetData(i, 1, false);
                    }
                }
                else if (HotelGenralPre.Checked)
                {
                    for (int i = 1; i < dataGridViewX_HotelGenralPre.Rows.Count; i++)
                    {
                        dataGridViewX_HotelGenralPre.SetData(i, 1, false);
                    }
                }
            }
            else
            {
                if (!(ribbonControl_Setting.SelectedRibbonTabItem.Name == "ribbonTabItem_Eqar"))
                {
                    return;
                }
                if (EqarFiles.Checked)
                {
                    for (int i = 1; i < dataGridViewX_EqarFiles.Rows.Count; i++)
                    {
                        dataGridViewX_EqarFiles.SetData(i, 1, false);
                        dataGridViewX_EqarFiles.SetData(i, 2, false);
                        dataGridViewX_EqarFiles.SetData(i, 3, false);
                        dataGridViewX_EqarFiles.SetData(i, 4, false);
                    }
                }
                else if (EqarTenant.Checked)
                {
                    for (int i = 1; i < dataGridViewX_Tenants.Rows.Count; i++)
                    {
                        dataGridViewX_Tenants.SetData(i, 1, false);
                        dataGridViewX_Tenants.SetData(i, 2, false);
                        dataGridViewX_Tenants.SetData(i, 3, false);
                        dataGridViewX_Tenants.SetData(i, 4, false);
                    }
                }
                else if (EqarsRep.Checked)
                {
                    for (int i = 1; i < dataGridViewX_RepEqar.Rows.Count; i++)
                    {
                        dataGridViewX_RepEqar.SetData(i, 1, false);
                    }
                }
                else if (EqarGenarl.Checked)
                {
                    for (int i = 1; i < dataGridViewX_GenralEqar.Rows.Count; i++)
                    {
                        dataGridViewX_GenralEqar.SetData(i, 1, false);
                    }
                }
            }
        }
        private void txtPass_Click(object sender, EventArgs e)
        {
            txtPass.SelectAll();
        }
        private void txtPassConf_Click(object sender, EventArgs e)
        {
            txtPassConf.SelectAll();
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
                _RepShow.Tables = " T_Users ";
                string Fields = "";
                Fields = " T_Users.UsrNo as No , T_Users.UsrNamA as NmA, T_Users.UsrNamE as NmE ";
                _RepShow.Rule = "";
                if (!string.IsNullOrEmpty(Fields))
                {
                    _RepShow.Fields = Fields;
                    try
                    {
                        VarGeneral.RepShowStock_Rat = "Rate";
                        _RepShow = _RepShow.Save();
                        VarGeneral.RepShowStock_Rat = "";
                        VarGeneral.RepData = _RepShow.RepData;
                    }
                    catch (Exception ex2)
                    {
                        VarGeneral.RepShowStock_Rat = "";
                        MessageBox.Show(ex2.Message);
                    }
                    _RepShow = new RepShow();
                    _RepShow.Rule = "";
                    _RepShow.Tables = " T_SYSSETTING ";
                    _RepShow.Fields = " T_SYSSETTING.LogImg ";
                    _RepShow = _RepShow.Save();
                    _RepShow.RepData.Tables[0].Merge(VarGeneral.RepData.Tables[0]);
                    VarGeneral.RepData = _RepShow.RepData;
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
            catch (Exception)
            {
                VarGeneral.RepShowStock_Rat = "";
            }
        }
        private void switchButton_AdminOp_ValueChanged(object sender, EventArgs e)
        {
            if (switchButton_AdminOp.Value)
            {
                chk11.Visible = true;
            }
            else
            {
                chk11.Visible = false;
            }
            superTabControl_Main1.Refresh();
        }
        private void FillFlex()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                FlexType.Rows.Count = 13;
                FlexType.SetData(0, 0, false);
                FlexType.SetData(0, 1, "مبيعات");
                FlexType.SetData(0, 2, "1");
                FlexType.SetData(1, 0, false);
                FlexType.SetData(1, 1, "مرتجع مبيعات");
                FlexType.SetData(1, 2, "3");
                FlexType.SetData(2, 0, false);
                FlexType.SetData(2, 1, "مشتريات");
                FlexType.SetData(2, 2, "2");
                FlexType.SetData(3, 0, false);
                FlexType.SetData(3, 1, "مرتجع مشتريات");
                FlexType.SetData(3, 2, "4");
                FlexType.SetData(4, 0, false);
                FlexType.SetData(4, 1, "عرض سعر عملاء");
                FlexType.SetData(4, 2, "7");
                FlexType.SetData(5, 0, false);
                FlexType.SetData(5, 1, "عرض سعر مورد");
                FlexType.SetData(5, 2, "8");
                FlexType.SetData(6, 0, false);
                FlexType.SetData(6, 1, "طلب شراء");
                FlexType.SetData(6, 2, "9");
                FlexType.SetData(7, 0, false);
                FlexType.SetData(7, 1, "بضاعة أول المدة");
                FlexType.SetData(7, 2, "14");
                FlexType.SetData(8, 0, false);
                FlexType.SetData(8, 1, "إدخال بضاعة");
                FlexType.SetData(8, 2, "5");
                FlexType.SetData(9, 0, false);
                FlexType.SetData(9, 1, "إخراج بضاعة");
                FlexType.SetData(9, 2, "6");
                FlexType.SetData(10, 0, false);
                FlexType.SetData(10, 1, "صرف بضاعة");
                FlexType.SetData(10, 2, "17");
                FlexType.SetData(11, 0, false);
                FlexType.SetData(11, 1, "مرتجع صرف بضاعة");
                FlexType.SetData(11, 2, "20");
                FlexType.SetData(12, 0, false);
                FlexType.SetData(12, 1, "تسوية البضاعة");
                FlexType.SetData(12, 2, "10");
            }
            else
            {
                FlexType.Rows.Count = 13;
                FlexType.SetData(0, 0, false);
                FlexType.SetData(0, 1, "Sales");
                FlexType.SetData(0, 2, "1");
                FlexType.SetData(1, 0, false);
                FlexType.SetData(1, 1, "Returned sales");
                FlexType.SetData(1, 2, "3");
                FlexType.SetData(2, 0, false);
                FlexType.SetData(2, 1, "Purchases");
                FlexType.SetData(2, 2, "2");
                FlexType.SetData(3, 0, false);
                FlexType.SetData(3, 1, "Returned Purchases");
                FlexType.SetData(3, 2, "4");
                FlexType.SetData(4, 0, false);
                FlexType.SetData(4, 1, "Quote Cust");
                FlexType.SetData(4, 2, "7");
                FlexType.SetData(5, 0, false);
                FlexType.SetData(5, 1, "Quote Supp");
                FlexType.SetData(5, 2, "8");
                FlexType.SetData(6, 0, false);
                FlexType.SetData(6, 1, "Purchase Order");
                FlexType.SetData(6, 2, "9");
                FlexType.SetData(7, 0, false);
                FlexType.SetData(7, 1, "Quantitative opening");
                FlexType.SetData(7, 2, "14");
                FlexType.SetData(8, 0, false);
                FlexType.SetData(8, 1, "introduction goods");
                FlexType.SetData(8, 2, "5");
                FlexType.SetData(9, 0, false);
                FlexType.SetData(9, 1, "Directed goods");
                FlexType.SetData(9, 2, "6");
                FlexType.SetData(10, 0, false);
                FlexType.SetData(10, 1, "Exchange goods");
                FlexType.SetData(10, 2, "17");
                FlexType.SetData(11, 0, false);
                FlexType.SetData(11, 1, "Return Exchange goods");
                FlexType.SetData(11, 2, "20");
                FlexType.SetData(12, 0, false);
                FlexType.SetData(12, 1, "Settlement goods");
                FlexType.SetData(12, 2, "10");
            }
        }
        private void switchButton_ControlHeadOFRep_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (switchButton_ControlHeadOFRep.Value)
                {
                    chk16.Enabled = true;
                }
                else
                {
                    chk16.Enabled = false;
                }
                chk16.Checked = false;
            }
            catch
            {
                chk16.Enabled = false;
            }
        }
        private void txtWidth_LockUpdateChanged(object sender, EventArgs e)
        {
            Button_Edit_Click(sender, e);
            txtWidth.LockUpdateChanged -= txtWidth_LockUpdateChanged;
            txtHeight.LockUpdateChanged -= txtHeight_LockUpdateChanged;
            try
            {
                if (txtWidth.LockUpdateChecked)
                {
                    txtWidth.LockUpdateChecked = true;
                    txtHeight.LockUpdateChecked = true;
                }
                else
                {
                    txtWidth.LockUpdateChecked = false;
                    txtHeight.LockUpdateChecked = false;
                }
            }
            catch
            {
            }
            txtWidth.LockUpdateChanged += txtWidth_LockUpdateChanged;
            txtHeight.LockUpdateChanged += txtHeight_LockUpdateChanged;
        }
        private void txtHeight_LockUpdateChanged(object sender, EventArgs e)
        {
            Button_Edit_Click(sender, e);
            txtWidth.LockUpdateChanged -= txtWidth_LockUpdateChanged;
            txtHeight.LockUpdateChanged -= txtHeight_LockUpdateChanged;
            try
            {
                if (txtHeight.LockUpdateChecked)
                {
                    txtWidth.LockUpdateChecked = true;
                    txtHeight.LockUpdateChecked = true;
                }
                else
                {
                    txtWidth.LockUpdateChecked = false;
                    txtHeight.LockUpdateChecked = false;
                }
            }
            catch
            {
            }
            txtWidth.LockUpdateChanged += txtWidth_LockUpdateChanged;
            txtHeight.LockUpdateChanged += txtHeight_LockUpdateChanged;
        }
        private void ribbonTabItem_Emps_Click(object sender, EventArgs e)
        {
        }
        private void Button_Add_Click_1(object sender, EventArgs e)
        {
        }
    }
}
