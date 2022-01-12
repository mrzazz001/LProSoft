using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.DotNetBar.SuperGrid;
using DevComponents.DotNetBar.SuperGrid.Style;
using DevComponents.Editors;
using InputKey;
using ProShared.GeneralM;using ProShared;
using ProShared.Stock_Data;
using Library.RepShow;
using Microsoft.VisualBasic;
using Microsoft.Win32;
using SSSDateTime.Date;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial  class FrmGuests : Form
    { void avs(int arln)

{ 
 panelEx2.Text=   (arln == 0 ? "  Click to collapse  " : "  Click to collapse") ; label24.Text=   (arln == 0 ? "  الإسم - إنجليزي :  " : "  Name - English:") ; label22.Text=   (arln == 0 ? "  الحــــالة :  " : "  Status:") ; label21.Text=   (arln == 0 ? "  تاريخ المغادرة :  " : "  Departure Date :") ; label18.Text=   (arln == 0 ? "  الضريبة :  " : "  Tax :") ; label20.Text=   (arln == 0 ? "  الخدمة :  " : "  the service :") ; label15.Text=   (arln == 0 ? "  الـوقــــت :  " : "  time:") ; label19.Text=   (arln == 0 ? "  العملــــة :  " : "  currency:") ; label7.Text=   (arln == 0 ? "  الأيام المطلوبة :  " : "  Required days:") ; RadioBox_AllowPM.Text=   (arln == 0 ? "  م  " : "  M") ; checkBoxX1.Text=   (arln == 0 ? "  شبكـــة  " : "  network") ; RadioBox_AllowAM.Text=   (arln == 0 ? "  ص  " : "  s") ; label11.Text=   (arln == 0 ? "  تاريخ السكن :  " : "  Residence date:") ; label8.Text=   (arln == 0 ? "  سعر الغرفة :  " : "  room price :") ; label6.Text=   (arln == 0 ? "  عـدد الأيــام :  " : "  number of days:") ; label14.Text=   (arln == 0 ? "  المتبقي :  " : "  Residual :") ; label13.Text=   (arln == 0 ? "  المدفوعات :  " : "  Payments:") ; label12.Text=   (arln == 0 ? "  خصم على :  " : "  discount on:") ; label10.Text=   (arln == 0 ? "  الإجمالي :  " : "  Total :") ; label9.Text=   (arln == 0 ? "  الخصـــم :  " : "  Discount:") ; label17.Text=   (arln == 0 ? "  تاريـخ الميــــلاد :  " : "  Birth date:") ; label16.Text=   (arln == 0 ? "  مكــان الميـــــلاد :  " : "  Birthplace:") ; label97.Text=   (arln == 0 ? "  رقـــم الهـــــــوية :  " : "  ID number:") ; label3.Text=   (arln == 0 ? "   الوظيفــــــــــــة :  " : "   Job:") ; label124.Text=   (arln == 0 ? "  الجــــــــــــــوال :  " : "  Mobile:") ; label88.Text=   (arln == 0 ? "  تاريخ إصدارهـــا :  " : "  Release date:") ; label92.Text=   (arln == 0 ? "  تاريخ إنتهائهـــــــا :  " : "  Expiry date:") ; label95.Text=   (arln == 0 ? "  المصـدر :  " : "  Source:") ; label2.Text=   (arln == 0 ? "  نـــوع الهـــــوية :  " : "  Identity type:") ; label113.Text=   (arln == 0 ? "  الـــديانة :  " : "  Religion:") ; label115.Text=   (arln == 0 ? "  الجنسية :  " : "  Nationality:") ; label1.Text=   (arln == 0 ? "  نوع السكن :  " : "  Accommodation type :") ; groupBox_PaidTyp.Text=   (arln == 0 ? "  طريقة الدفع  " : "  Payment method") ;  checkBox_NetWork.Text=   (arln == 0 ? "  شبكـــة  " : "Network") ; checkBox_Credit.Text=   (arln == 0 ? "  أجـــل  " : "Credit") ; checkBox_Chash.Text=   (arln == 0 ? "  نقـــدي  " : "Cach") ; label4.Text=   (arln == 0 ? "  حساب النزيل :  " : "  Guest account:") ; label5.Text=   (arln == 0 ? "  رقم الغرفة :  " : "  room number :") ; label36.Text=   (arln == 0 ? "  الإسم - عـــربي :  " : "  Name - Arabic:") ; label38.Text=   (arln == 0 ? "  رقــم النــــــزيــل :  " : "  Guest number:") ; tabItem_GuestsData.Text=   (arln == 0 ? "  بيانات النزيل  " : "  guest data") ; label23.Text=   (arln == 0 ? "  تاريخ الإصدار  " : "  Release Date") ; label122.Text=   (arln == 0 ? "  تاريخ الإنتهاء  " : "  Expiry date") ; label123.Text=   (arln == 0 ? "  رقم الهوية  " : "  ID Number") ; label129.Text=   (arln == 0 ? "  تاريخ الميلاد  " : "  Date of Birth") ; label132.Text=   (arln == 0 ? "  إسم المـــــرافق  " : "  escort name") ; tabItem_FamilyData.Text=   (arln == 0 ? "  بيانات المرافقين  " : "  Accompanying data") ; superTabControl_Main1.Text=   (arln == 0 ? "  superTabControl3  " : "  superTabControl3") ; Button_Close.Text=   (arln == 0 ? "  إغلاق  " : "  Close") ; /*buttonItem_Print.Text=   (arln == 0 ? "  طباعة  " : "  Print") ;*/ Button_Search.Text=   (arln == 0 ? "  بحث  " : "  Search") ; Button_Save.Text=   (arln == 0 ? "  حفظ  " : "  save") ; Button_Add.Text=   (arln == 0 ? "  إضافة  " : "  addition") ; buttonItem_Menue.Text=   (arln == 0 ? "  ...  " : "  ...") ; buttonItem_GuestMove.Text=   (arln == 0 ? "  نقل الساكن  " : "  static transfer") ; buttonItem_AddRoom.Text=   (arln == 0 ? "  إضافة ملحق  " : "  add attachment") ; buttonItem_ChangeRoomPrice.Text=   (arln == 0 ? "  تغيير سعر الغرفة  " : "  Room rate change") ; buttonItem_ChangeRoomType.Text=   (arln == 0 ? "  تغيير نوع السـكن  " : "  Change the type of residence") ; buttonItem_EditDays.Text=   (arln == 0 ? "  تعديل الشهور المطلوبة  " : "  Edit the required months") ; buttonItem_RepAcc.Text=   (arln == 0 ? "  كشف حساب النزيل  " : "  Guest account statement") ; buttonItem_SendSms.Text=   (arln == 0 ? "  إرسال رسالة نصية  " : "  Send a text message") ; superTabControl_Main2.Text=   (arln == 0 ? "  superTabControl1  " : "  superTabControl1") ; Button_First.Text=   (arln == 0 ? "  الأول  " : "  the first") ; Button_Prev.Text=   (arln == 0 ? "  السابق  " : "  the previous") ; lable_Records.Text=   (arln == 0 ? "  ---  " : "  ---") ; Button_Next.Text=   (arln == 0 ? "  التالي  " : "  next one") ; Button_Last.Text=   (arln == 0 ? "  الأخير  " : "  the last one") ; DGV_Main.Text=   (arln == 0 ? "    " : "    ") ; DGV_Main.Text=   (arln == 0 ? "  جميــع السجــــلات  " : "  All records") ; DGV_Main.Text=   (arln == 0 ? "    " : "    ") ; panelEx3.Text=   (arln == 0 ? "  Fill Panel  " : "  Fill Panel") ; superTabControl_DGV.Text=   (arln == 0 ? "  superTabControl1  " : "  superTabControl1") ; textBox_search.Text=   (arln == 0 ? "  ...  " : "  ...") ; Button_ExportTable2.Text=   (arln == 0 ? "  تصدير  " : "  Export") ; /*Button_PrintTable.Text=   (arln == 0 ? "  طباعة  " : "  Print") ; */ToolStripMenuItem_Rep.Text=   (arln == 0 ? "  إظهار التقرير  " : "  Show report") ; ToolStripMenuItem_Det.Text=   (arln == 0 ? "  إظهار التفاصيل  " : "  Show details") ;}
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
#pragma warning disable CS0414 // The field 'FrmGuests.FlagUpdate' is assigned but its value is never used
        private string FlagUpdate = "";
#pragma warning restore CS0414 // The field 'FrmGuests.FlagUpdate' is assigned but its value is never used
        public ViewState ViewState = ViewState.Deiles;
        private FormState statex;
        public List<Control> controls;
        public Control codeControl = new Control();
        private bool canUpdate = true;
        private T_per1 DataThis_Family;
        private List<string> pkeys = new List<string>();
        private Stock_DataDataContext dbInstance;
        private T_per data_this;
        private Rate_DataDataContext dbInstanceRate;
        private T_User permission = new T_User();
        private int R1;
        private int R2;
        private int R3;
#pragma warning disable CS0169 // The field 'FrmGuests.R4' is never used
        private int R4;
#pragma warning restore CS0169 // The field 'FrmGuests.R4' is never used
#pragma warning disable CS0169 // The field 'FrmGuests.Fin' is never used
        private int Fin;
#pragma warning restore CS0169 // The field 'FrmGuests.Fin' is never used
        private int M;
#pragma warning disable CS0414 // The field 'FrmGuests.Mm' is assigned but its value is never used
        private int Mm;
#pragma warning restore CS0414 // The field 'FrmGuests.Mm' is assigned but its value is never used
        private string aa;
#pragma warning disable CS0414 // The field 'FrmGuests.SS' is assigned but its value is never used
        private int SS;
#pragma warning restore CS0414 // The field 'FrmGuests.SS' is assigned but its value is never used
        private double Tot = 0.0;
        private string CDat;
        private int CDat2;
        private int bb = 0;
        private T_SYSSETTING _SysSetting = new T_SYSSETTING();
        private List<T_SYSSETTING> listSysSetting = new List<T_SYSSETTING>();
        private T_INVSETTING _InvSetting = new T_INVSETTING();
        private List<T_INVSETTING> listInvSetting = new List<T_INVSETTING>();
        private T_Company _Company = new T_Company();
        public Dictionary<string, ColumnDictinary> columns_Names_visible2 = new Dictionary<string, ColumnDictinary>();
        private double tmp = 0.0;
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
                        frm.Repvalue = "RepGeneral";
                        frm.Repvalue = "RepGuestDataPer_1";
                        frm.Repvalue = "RepGeneral";
                        frm.Repvalue = "RepGuestDataPer_1";
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
        private Timer timer1;
        private ExpandableSplitter expandableSplitter1;
        private PanelEx panelEx2;
        private RibbonBar ribbonBar1;
        private System.Windows.Forms. SaveFileDialog saveFileDialog1;
        protected SuperGridControl DGV_Main;
        private PanelEx panelEx3;
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
        private SuperTabControl superTabControl_Main2;
        protected LabelItem labelItem1;
        protected ButtonItem Button_First;
        protected ButtonItem Button_Prev;
        protected TextBoxItem TextBox_Index;
        protected LabelItem Label_Count;
        protected ButtonItem Button_Next;
        protected ButtonItem Button_Last;
        private SuperTabControl superTabControl_Main1;
        protected ButtonItem Button_Close;
        protected ButtonItem Button_Search;
        protected ButtonItem Button_Save;
        protected ButtonItem Button_Add;
        private RibbonBar ribbonBar_DGV;
        private SuperTabControl superTabControl_DGV;
        protected TextBoxItem textBox_search;
        protected ButtonItem Button_ExportTable2;
        protected ButtonItem Button_PrintTable;
        protected LabelItem labelItem3;
        private LabelItem lable_Records;
        private Panel panel2;
        private DevComponents.DotNetBar.TabControl tabControl1;
        private TabControlPanel tabControlPanel1;
        private TabItem tabItem_GuestsData;
        private TabControlPanel tabControlPanel2;
        private TabItem tabItem_FamilyData;
        private ComboBoxEx comboBox_Rooms;
        internal Label label5;
        protected TextBox textBox_NameA;
        protected Label label36;
        protected TextBox textBox_ID;
        protected Label label38;
        internal GroupBox groupBox_PaidTyp;
        private CheckBoxX checkBox_NetWork;
        private CheckBoxX checkBox_Credit;
        private CheckBoxX checkBox_Chash;
        private TextBox txtCustNo;
        internal Label label4;
        private ComboBoxEx comboBox_RoomTyp;
        internal Label label1;
        private Panel panel_GustData;
        private ComboBoxEx comboBox_Nationality;
        private ComboBoxEx comboBox_BirthPlace;
        private ComboBoxEx comboBox_Religion;
        private MaskedTextBox dateTimeInput_BirthDate;
        private Label label115;
        private Label label113;
        private ComboBoxEx CmbIDTyp;
        private Label label2;
        private TextBox textBox_ID_No;
        private Label label97;
        private ComboBoxEx comboBox_ID_From;
        private Label label95;
        private MaskedTextBox dateTimeInput_ID_Date;
        private MaskedTextBox dateTimeInput_ID_DateEnd;
        private Label label88;
        private Label label92;
        private TextBox textBox_Mobile;
        private Label label124;
        private ComboBoxEx comboBox_Job;
        private Label label3;
        private TextBoxX textBox_Note;
        private Panel panel_GuestDaysData;
        private Label label6;
        private IntegerInput textBox_DayCount;
        private Label label8;
        private Label label7;
        private IntegerInput textBox_DayRequest;
        private DoubleInput textBox_RoomPrice;
        private ComboBoxEx comboBox_Curr;
        internal Label label19;
        private Label label10;
        private DoubleInput TextBox_TotalAm;
        private Label label9;
        private DoubleInput Textbox_DiscountVal;
        private ComboBoxEx comboBox_DisTo;
        internal Label label12;
        private ComboBoxEx comboBox_DisType;
        private Label label14;
        private DoubleInput TextBox_Remming;
        private Label label13;
        private DoubleInput TextBox_Paid;
        internal Label label11;
        private MaskedTextBox textBox_Date;
        internal Label label15;
        private MaskedTextBox textBox_Time;
        internal GroupBox groupBox_AmPm;
        private CheckBoxX checkBoxX1;
        private CheckBoxX RadioBox_AllowPM;
        private CheckBoxX RadioBox_AllowAM;
        private PictureBox PicItemImg;
        private ButtonX button_ClearPic;
        private ButtonX button_EnterImg;
        private Label label17;
        private Label label16;
        protected ButtonItem buttonItem_Menue;
        private ButtonItem buttonItem_GuestMove;
        private ButtonItem buttonItem_AddRoom;
        private ButtonItem buttonItem_ChangeRoomPrice;
        private ButtonItem buttonItem_ChangeRoomType;
        private TextBox textBox_RoomStat;
        protected Label label18;
        protected Label label20;
        protected Label label21;
        private TextBox Text_19;
        private TextBox Text_1;
        private DoubleInput Text_11;
        private DoubleInput Text_12;
        internal Label label22;
        private MaskedTextBox dateTimeInput_PassportDateEnd10;
        private MaskedTextBox dateTimeInput_PassportDateEnd9;
        private MaskedTextBox dateTimeInput_PassportDateEnd8;
        private MaskedTextBox dateTimeInput_PassportDateEnd7;
        private MaskedTextBox dateTimeInput_PassportDateEnd6;
        private MaskedTextBox dateTimeInput_PassportDateEnd5;
        private MaskedTextBox dateTimeInput_PassportDateEnd4;
        private MaskedTextBox dateTimeInput_PassportDateEnd3;
        private MaskedTextBox dateTimeInput_PassportDateEnd2;
        private MaskedTextBox dateTimeInput_PassportDateEnd1;
        private MaskedTextBox dateTimeInput_BirthDate10;
        private MaskedTextBox dateTimeInput_BirthDate9;
        private MaskedTextBox dateTimeInput_BirthDate8;
        private MaskedTextBox dateTimeInput_BirthDate7;
        private MaskedTextBox dateTimeInput_BirthDate6;
        private MaskedTextBox dateTimeInput_BirthDate5;
        private MaskedTextBox dateTimeInput_BirthDate4;
        private MaskedTextBox dateTimeInput_BirthDate3;
        private MaskedTextBox dateTimeInput_BirthDate2;
        private MaskedTextBox dateTimeInput_BirthDate1;
        private Label label122;
        private Label label123;
        private Label label129;
        private TextBox textBox_PassporntNo10;
        private TextBox textBox_Name10;
        private TextBox textBox_PassporntNo9;
        private TextBox textBox_Name9;
        private TextBox textBox_PassporntNo8;
        private TextBox textBox_Name8;
        private TextBox textBox_PassporntNo7;
        private TextBox textBox_Name7;
        private TextBox textBox_PassporntNo6;
        private TextBox textBox_Name6;
        private TextBox textBox_PassporntNo5;
        private TextBox textBox_Name5;
        private TextBox textBox_PassporntNo4;
        private TextBox textBox_Name4;
        private TextBox textBox_PassporntNo3;
        private TextBox textBox_Name3;
        private TextBox textBox_PassporntNo2;
        private TextBox textBox_Name2;
        private TextBox textBox_PassporntNo1;
        private TextBox textBox_Name1;
        private Label label132;
        private MaskedTextBox dateTimeInput_PassportDateStart10;
        private MaskedTextBox dateTimeInput_PassportDateStart9;
        private MaskedTextBox dateTimeInput_PassportDateStart8;
        private MaskedTextBox dateTimeInput_PassportDateStart7;
        private MaskedTextBox dateTimeInput_PassportDateStart6;
        private MaskedTextBox dateTimeInput_PassportDateStart5;
        private MaskedTextBox dateTimeInput_PassportDateStart4;
        private MaskedTextBox dateTimeInput_PassportDateStart3;
        private MaskedTextBox dateTimeInput_PassportDateStart2;
        private MaskedTextBox dateTimeInput_PassportDateStart1;
        private Label label23;
        private ButtonItem buttonItem_EditDays;
        protected ButtonItem buttonItem_Print;
        private ButtonX button_SrchCustNo;
        private ButtonItem buttonItem_SendSms;
        protected TextBox textBox_NameE;
        protected Label label24;
        private ButtonItem buttonItem_RepAcc;
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
        public T_per1 DataThisFamily
        {
            get
            {
                return DataThis_Family;
            }
            set
            {
                DataThis_Family = value;
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
                if (dbInstance == null)
                {
                    dbInstance = new Stock_DataDataContext(VarGeneral.BranchCS);
                }
                return dbInstance;
            }
        }
        public T_per DataThis
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
                if (value != null && value.UsrNo != "")
                {
                    permission = value;
                    if (!VarGeneral.TString.ChkStatShow(value.RepAcc2, 13))
                    {
                        IfAdd = false;
                    }
                    else
                    {
                        IfAdd = true;
                    }
                    if (!VarGeneral.TString.ChkStatShow(value.RepAcc2, 14))
                    {
                        CanEdit = false;
                    }
                    else
                    {
                        CanEdit = true;
                    }
                    if (!VarGeneral.TString.ChkStatShow(value.RepAcc4, 0))
                    {
                        buttonItem_GuestMove.Enabled = false;
                    }
                    else
                    {
                        buttonItem_GuestMove.Enabled = true;
                    }
                    if (!VarGeneral.TString.ChkStatShow(value.RepAcc4, 1))
                    {
                        buttonItem_AddRoom.Enabled = false;
                    }
                    else
                    {
                        buttonItem_AddRoom.Enabled = true;
                    }
                    if (!VarGeneral.TString.ChkStatShow(value.RepAcc4, 2))
                    {
                        buttonItem_ChangeRoomPrice.Enabled = false;
                    }
                    else
                    {
                        buttonItem_ChangeRoomPrice.Enabled = true;
                    }
                    if (!VarGeneral.TString.ChkStatShow(value.RepAcc4, 3))
                    {
                        buttonItem_ChangeRoomType.Enabled = false;
                    }
                    else
                    {
                        buttonItem_ChangeRoomType.Enabled = true;
                    }
                    if (!VarGeneral.TString.ChkStatShow(value.RepAcc4, 4))
                    {
                        buttonItem_EditDays.Enabled = false;
                    }
                    else
                    {
                        buttonItem_EditDays.Enabled = true;
                    }
                    if (!VarGeneral.TString.ChkStatShow(value.RepAcc3, 4))
                    {
                        buttonItem_RepAcc.Enabled = false;
                    }
                    else
                    {
                        buttonItem_RepAcc.Enabled = true;
                    }
                }
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
        public void Button_Search_Click(object sender, EventArgs e)
        {
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, ""));
            }
            VarGeneral.SFrmTyp = "T_per";
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != "")
            {
                textBox_ID.Text = frm.SerachNo.ToString();
            }
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
            List<T_per> list = db.FillPer_2(textBox_search.TextBox.Text).ToList();
            if (DGV_Main.PrimaryGrid.Columns.Count == 0)
            {
                foreach (KeyValuePair<string, ColumnDictinary> item in columns_Names_visible)
                {
                    DGV_Main.PrimaryGrid.Columns.Add(new GridColumn(item.Key));
                }
            }
            FillHDGV(list);
        }
        public void FillHDGV(IEnumerable<T_per> new_data_enum)
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
            DGV_Main.PrimaryGrid.DataMember = "T_per";
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
        private void TextBox_Search_InputTextChanged(object sender)
        {
            Fill_DGV_Main();
        }
        public void Clear()
        {
            if (State == FormState.New)
            {
                return;
            }
            State = FormState.New;
            data_this = new T_per();
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
            textBox_NameA.Focus();
            checkBox_Chash.Checked = true;
            RadioBox_AllowAM.Checked = true;
            try
            {
                comboBox_Curr.SelectedValue = int.Parse(VarGeneral.Settings_Sys.ImportIp.ToString());
            }
            catch
            {
            }
            if (R3 == 0)
            {
                comboBox_Rooms.Enabled = false;
                superTabControl_Main2.Enabled = false;
                Button_Add.Enabled = false;
                Button_Search.Enabled = false;
                buttonItem_Menue.Enabled = false;
                expandableSplitter1.Expandable = false;
                expandableSplitter1.Enabled = false;
            }
            else
            {
                comboBox_Rooms.Enabled = true;
                superTabControl_Main2.Enabled = true;
                Button_Add.Enabled = true;
                Button_Search.Enabled = true;
                buttonItem_Menue.Enabled = true;
                expandableSplitter1.Expandable = true;
            }
            M = 0;
            Mm = 0;
            VarGeneral.ChkMove = 0;
            VarGeneral.ChkAddRoom = 0;
            SetReadOnly = false;
        }
        private void Button_Close_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void DGV_Main_CellClick(object sender, GridCellClickEventArgs e)
        {
            DGV_Main.PrimaryGrid.Tag = e.GridCell.RowIndex;
        }
        private void DGV_Main_CellDoubleClick(object sender, GridCellDoubleClickEventArgs e)
        {
            ToolStripMenuItem_Det_Click(sender, e);
        }
        private void textBox_ID_Click(object sender, EventArgs e)
        {
            textBox_ID.SelectAll();
        }
        private void textBox_NameA_Enter(object sender, EventArgs e)
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                Framework.Keyboard.Language.Switch("Arabic");
            }
            else
            {
                Framework.Keyboard.Language.Switch("English");
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
        private void Frm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                SendKeys.Send("{Tab}");
            }
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
            else if (e.KeyCode == Keys.Escape)
            {
                if (State == FormState.Saved)
                {
                    Close();
                }
                else if (State != FormState.New)
                {
                    textBox_ID_TextChanged(sender, e);
                }
                else
                {
                    Close();
                }
            }
        }
        public void RefreshPKeys()
        {
            PKeys.Clear();
            var qkeys = from item in db.T_pers
                        where item.ch == (int?)2
                        select new
                        {
                            Code = item.perno + ""
                        };
            int count = 0;
            foreach (var item2 in qkeys)
            {
                count++;
                PKeys.Add(item2.Code);
            }
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
        private void ADD_Controls()
        {
            try
            {
                controls = new List<Control>();
                controls.Add(textBox_ID);
                codeControl = textBox_ID;
                controls.Add(textBox_Date);
                controls.Add(textBox_DayCount);
                controls.Add(textBox_DayRequest);
                controls.Add(textBox_ID_No);
                controls.Add(textBox_Mobile);
                controls.Add(textBox_NameA);
                controls.Add(textBox_Note);
                controls.Add(TextBox_Paid);
                controls.Add(TextBox_Remming);
                controls.Add(textBox_RoomPrice);
                controls.Add(textBox_Time);
                controls.Add(TextBox_TotalAm);
                controls.Add(RadioBox_AllowAM);
                controls.Add(RadioBox_AllowPM);
                controls.Add(comboBox_BirthPlace);
                controls.Add(comboBox_Nationality);
                controls.Add(comboBox_Curr);
                controls.Add(comboBox_DisTo);
                controls.Add(comboBox_DisType);
                controls.Add(comboBox_ID_From);
                controls.Add(comboBox_Job);
                controls.Add(comboBox_Rooms);
                controls.Add(comboBox_RoomTyp);
                controls.Add(Textbox_DiscountVal);
                controls.Add(textBox_NameE);
                controls.Add(txtCustNo);
                controls.Add(dateTimeInput_BirthDate);
                controls.Add(dateTimeInput_ID_Date);
                controls.Add(dateTimeInput_ID_DateEnd);
                controls.Add(textBox_RoomStat);
                controls.Add(Text_11);
                controls.Add(Text_12);
                controls.Add(Text_19);
                controls.Add(Text_1);
                controls.Add(textBox_Name1);
                controls.Add(textBox_Name2);
                controls.Add(textBox_Name3);
                controls.Add(textBox_Name4);
                controls.Add(textBox_Name5);
                controls.Add(textBox_Name6);
                controls.Add(textBox_Name7);
                controls.Add(textBox_Name8);
                controls.Add(textBox_Name9);
                controls.Add(textBox_Name10);
                controls.Add(dateTimeInput_BirthDate1);
                controls.Add(dateTimeInput_BirthDate2);
                controls.Add(dateTimeInput_BirthDate3);
                controls.Add(dateTimeInput_BirthDate4);
                controls.Add(dateTimeInput_BirthDate5);
                controls.Add(dateTimeInput_BirthDate6);
                controls.Add(dateTimeInput_BirthDate7);
                controls.Add(dateTimeInput_BirthDate8);
                controls.Add(dateTimeInput_BirthDate9);
                controls.Add(dateTimeInput_BirthDate10);
                controls.Add(textBox_PassporntNo1);
                controls.Add(textBox_PassporntNo2);
                controls.Add(textBox_PassporntNo3);
                controls.Add(textBox_PassporntNo4);
                controls.Add(textBox_PassporntNo5);
                controls.Add(textBox_PassporntNo6);
                controls.Add(textBox_PassporntNo7);
                controls.Add(textBox_PassporntNo8);
                controls.Add(textBox_PassporntNo9);
                controls.Add(textBox_PassporntNo10);
                controls.Add(dateTimeInput_PassportDateStart1);
                controls.Add(dateTimeInput_PassportDateStart2);
                controls.Add(dateTimeInput_PassportDateStart3);
                controls.Add(dateTimeInput_PassportDateStart4);
                controls.Add(dateTimeInput_PassportDateStart5);
                controls.Add(dateTimeInput_PassportDateStart6);
                controls.Add(dateTimeInput_PassportDateStart7);
                controls.Add(dateTimeInput_PassportDateStart8);
                controls.Add(dateTimeInput_PassportDateStart9);
                controls.Add(dateTimeInput_PassportDateStart10);
                controls.Add(dateTimeInput_PassportDateEnd1);
                controls.Add(dateTimeInput_PassportDateEnd2);
                controls.Add(dateTimeInput_PassportDateEnd3);
                controls.Add(dateTimeInput_PassportDateEnd4);
                controls.Add(dateTimeInput_PassportDateEnd5);
                controls.Add(dateTimeInput_PassportDateEnd6);
                controls.Add(dateTimeInput_PassportDateEnd7);
                controls.Add(dateTimeInput_PassportDateEnd8);
                controls.Add(dateTimeInput_PassportDateEnd9);
                controls.Add(dateTimeInput_PassportDateEnd10);
            }
            catch (SqlException)
            {
            }
        }
        public FrmGuests()
        {
            InitializeComponent();this.Load += langloads;
            Button_Close.Click += Button_Close_Click;
            textBox_Date.Click += Button_Edit_Click;
            textBox_DayRequest.Click += Button_Edit_Click;
            Textbox_DiscountVal.Click += Button_Edit_Click;
            textBox_Mobile.Click += Button_Edit_Click;
            textBox_NameA.Click += Button_Edit_Click;
            textBox_NameE.Click += Button_Edit_Click;
            textBox_Note.Click += Button_Edit_Click;
            textBox_RoomPrice.Click += Button_Edit_Click;
            textBox_Time.Click += Button_Edit_Click;
            dateTimeInput_BirthDate.Click += Button_Edit_Click;
            dateTimeInput_ID_Date.Click += Button_Edit_Click;
            dateTimeInput_ID_DateEnd.Click += Button_Edit_Click;
            CmbIDTyp.Click += Button_Edit_Click;
            comboBox_BirthPlace.Click += Button_Edit_Click;
            comboBox_Curr.Click += Button_Edit_Click;
            comboBox_DisTo.Click += Button_Edit_Click;
            comboBox_DisType.Click += Button_Edit_Click;
            comboBox_ID_From.Click += Button_Edit_Click;
            comboBox_Job.Click += Button_Edit_Click;
            comboBox_Nationality.Click += Button_Edit_Click;
            comboBox_Religion.Click += Button_Edit_Click;
            RadioBox_AllowPM.Click += Button_Edit_Click;
            RadioBox_AllowAM.Click += Button_Edit_Click;
            checkBox_Chash.Click += Button_Edit_Click;
            checkBox_Credit.Click += Button_Edit_Click;
            textBox_ID_No.Click += Button_Edit_Click;
            comboBox_RoomTyp.Click += Button_Edit_Click;
            textBox_Name1.Click += Button_Edit_Click;
            textBox_Name2.Click += Button_Edit_Click;
            textBox_Name3.Click += Button_Edit_Click;
            textBox_Name4.Click += Button_Edit_Click;
            textBox_Name5.Click += Button_Edit_Click;
            textBox_Name6.Click += Button_Edit_Click;
            textBox_Name7.Click += Button_Edit_Click;
            textBox_Name8.Click += Button_Edit_Click;
            textBox_Name9.Click += Button_Edit_Click;
            textBox_Name10.Click += Button_Edit_Click;
            dateTimeInput_BirthDate1.Click += Button_Edit_Click;
            dateTimeInput_BirthDate2.Click += Button_Edit_Click;
            dateTimeInput_BirthDate3.Click += Button_Edit_Click;
            dateTimeInput_BirthDate4.Click += Button_Edit_Click;
            dateTimeInput_BirthDate5.Click += Button_Edit_Click;
            dateTimeInput_BirthDate6.Click += Button_Edit_Click;
            dateTimeInput_BirthDate7.Click += Button_Edit_Click;
            dateTimeInput_BirthDate8.Click += Button_Edit_Click;
            dateTimeInput_BirthDate9.Click += Button_Edit_Click;
            dateTimeInput_BirthDate10.Click += Button_Edit_Click;
            textBox_PassporntNo1.Click += Button_Edit_Click;
            textBox_PassporntNo2.Click += Button_Edit_Click;
            textBox_PassporntNo3.Click += Button_Edit_Click;
            textBox_PassporntNo4.Click += Button_Edit_Click;
            textBox_PassporntNo5.Click += Button_Edit_Click;
            textBox_PassporntNo6.Click += Button_Edit_Click;
            textBox_PassporntNo7.Click += Button_Edit_Click;
            textBox_PassporntNo8.Click += Button_Edit_Click;
            textBox_PassporntNo9.Click += Button_Edit_Click;
            textBox_PassporntNo10.Click += Button_Edit_Click;
            dateTimeInput_PassportDateStart1.Click += Button_Edit_Click;
            dateTimeInput_PassportDateStart2.Click += Button_Edit_Click;
            dateTimeInput_PassportDateStart3.Click += Button_Edit_Click;
            dateTimeInput_PassportDateStart4.Click += Button_Edit_Click;
            dateTimeInput_PassportDateStart5.Click += Button_Edit_Click;
            dateTimeInput_PassportDateStart6.Click += Button_Edit_Click;
            dateTimeInput_PassportDateStart7.Click += Button_Edit_Click;
            dateTimeInput_PassportDateStart8.Click += Button_Edit_Click;
            dateTimeInput_PassportDateStart9.Click += Button_Edit_Click;
            dateTimeInput_PassportDateStart10.Click += Button_Edit_Click;
            dateTimeInput_PassportDateEnd1.Click += Button_Edit_Click;
            dateTimeInput_PassportDateEnd2.Click += Button_Edit_Click;
            dateTimeInput_PassportDateEnd3.Click += Button_Edit_Click;
            dateTimeInput_PassportDateEnd4.Click += Button_Edit_Click;
            dateTimeInput_PassportDateEnd5.Click += Button_Edit_Click;
            dateTimeInput_PassportDateEnd6.Click += Button_Edit_Click;
            dateTimeInput_PassportDateEnd7.Click += Button_Edit_Click;
            dateTimeInput_PassportDateEnd8.Click += Button_Edit_Click;
            dateTimeInput_PassportDateEnd9.Click += Button_Edit_Click;
            dateTimeInput_PassportDateEnd10.Click += Button_Edit_Click;
            expandableSplitter1.Click += expandableSplitter1_Click;
            ToolStripMenuItem_Det.Click += ToolStripMenuItem_Det_Click;
            Button_ExportTable2.Click += Button_ExportTable2_Click;
            Button_First.Click += Button_First_Click;
            Button_Prev.Click += Button_Prev_Click;
            Button_Next.Click += Button_Next_Click;
            Button_Last.Click += Button_Last_Click;
            Button_Add.Click += Button_Add_Click;
            Button_Search.Click += Button_Search_Click;
            Button_Save.Click += Button_Save_Click;
            textBox_search.InputTextChanged += TextBox_Search_InputTextChanged;
            textBox_search.ButtonCustomClick += TextBox_Search_ButtonCustomClick;
            TextBox_Index.InputTextChanged += TextBox_Index_InputTextChanged;
            DGV_Main.MouseDown += DGV_Main_MouseDown;
            DGV_Main.CellDoubleClick += DGV_Main_CellDoubleClick;
            DGV_Main.CellClick += DGV_Main_CellClick;
            DGV_Main.GetCellStyle += DGV_MainGetCellStyle;
            DGV_Main.CellDoubleClick += DGV_Main_CellDoubleClick;
            DGV_Main.DataBindingComplete += DGV_Main_DataBindingComplete;
            Button_PrintTable.Click += Button_Print_Click;
        }
        protected override void OnParentRightToLeftChanged(EventArgs e)
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmGuests));
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
                Button_Save.Text = "حفظ";
                Button_Search.Text = "بحث";
                Button_First.Tooltip = "السجل الاول";
                Button_Last.Tooltip = "السجل الاخير";
                Button_Next.Tooltip = "السجل التالي";
                Button_Prev.Tooltip = "السجل السابق";
                buttonItem_Print.Text = ((_InvSetting.ISdirectPrinting) ? "طباعة" : "عــرض");
                buttonItem_Print.Tooltip = "F5";
                Button_Add.Tooltip = "F1";
                Button_Close.Tooltip = "Esc";
                Button_Save.Tooltip = "F2";
                Button_Search.Tooltip = "F4";
                Button_PrintTable.Text = ((VarGeneral.GeneralPrinter.ISdirectPrinting) ? "طباعة" : "عــرض");
                Button_PrintTable.Tooltip = "F5";
                Button_ExportTable2.Text = "تصدير";
                Button_ExportTable2.Tooltip = "F10";
                DGV_Main.PrimaryGrid.GroupByRow.Text = "جميع السجلات";
                buttonItem_EditDays.Text = "تعديل الشهور المطلوبة";
                buttonItem_SendSms.Text = "إرسال رسالة نصية";
                buttonItem_GuestMove.Text = "نقل الساكن";
                buttonItem_AddRoom.Text = " إضافة ملحق";
                buttonItem_ChangeRoomPrice.Text = "تغيير السعــر";
                buttonItem_ChangeRoomType.Text = "تغيير نوع السـكن";
                buttonItem_RepAcc.Text = "كشف حساب النزيل";
                Text = "كرت بيانات النزلاء";
            }
            else
            {
                Button_First.Text = "First";
                Button_Last.Text = "Last";
                Button_Next.Text = "Next";
                Button_Prev.Text = "Previous";
                Button_Add.Text = "New";
                Button_Close.Text = "Close";
                Button_Save.Text = "Save";
                Button_Search.Text = "Search";
                Button_First.Tooltip = "First Record";
                Button_Last.Tooltip = "Last Record";
                Button_Next.Tooltip = "Next Record";
                Button_Prev.Tooltip = "Previous Record";
                buttonItem_Print.Text = ((_InvSetting.ISdirectPrinting) ? "Print" : "Show");
                buttonItem_Print.Tooltip = "F5";
                Button_Add.Tooltip = "F1";
                Button_Close.Tooltip = "Esc";
                Button_Save.Tooltip = "F2";
                Button_Search.Tooltip = "F4";
                Button_PrintTable.Text = ((VarGeneral.GeneralPrinter.ISdirectPrinting) ? "Print" : "Show");
                Button_PrintTable.Tooltip = "F5";
                Button_ExportTable2.Text = "Export";
                Button_ExportTable2.Tooltip = "F10";
                DGV_Main.PrimaryGrid.GroupByRow.Text = "All Records";
                textBox_Note.WatermarkText = "Note";
                tabItem_GuestsData.Text = "Guest Data";
                tabItem_FamilyData.Text = "Family Data";
                buttonItem_EditDays.Text = "Modification of required months";
                buttonItem_SendSms.Text = "Send SMS";
                buttonItem_GuestMove.Text = "Guest Move";
                buttonItem_AddRoom.Text = "Add Room";
                buttonItem_ChangeRoomPrice.Text = "Price Change";
                buttonItem_ChangeRoomType.Text = "Accommodation Type Change";
                buttonItem_RepAcc.Text = "Guest account statement";
                Text = "Guests Data Card";
            }
        }
        private void FrmGuests_Load(object sender, EventArgs e)
        {
            try
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmGuests));
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
                    columns_Names_visible.Add("perno", new ColumnDictinary("رقم النزيل", "Ghoust No", ifDefault: true, ""));
                    columns_Names_visible.Add("nmA", new ColumnDictinary("الإسم العربي", "Arabic Name", ifDefault: true, ""));
                    columns_Names_visible.Add("nmE", new ColumnDictinary("الإسم الانجليزي", "English Name", ifDefault: false, ""));
                    columns_Names_visible.Add("price", new ColumnDictinary("سعر الغرفة", "Price", ifDefault: true, ""));
                    columns_Names_visible.Add("day", new ColumnDictinary("الأيام المطلوبة", "Days", ifDefault: true, ""));
                    columns_Names_visible.Add("pasno", new ColumnDictinary("رقم الهوية", "ID No", ifDefault: true, ""));
                }
                else
                {
                    Clear();
                    textBox_ID.Text = "";
                    TextBox_Index.TextBox.Text = "";
                }
                GetInvSetting();
                RibunButtons();
                RefreshPKeys();
                R1 = VarGeneral.Trn;
                if (R1 == 4)
                {
                    R2 = VarGeneral.Tmp4;
                    R3 = VarGeneral._hotelper;
                    VarGeneral.Trn = 0;
                }
                else
                {
                    R2 = VarGeneral._hotelrom;
                    R3 = VarGeneral._hotelper;
                }
                FillCombo();
                GetInvSetting();
                ViewDetails_Click(sender, e);
                UpdateVcr();
                if (R3 == 0)
                {
                    if (VarGeneral.vGuestData == 0)
                    {
                        Button_Add.Visible = false;
                        textBox_ID.TextChanged += textBox_ID_TextChanged;
                        textBox_ID.Text = PKeys.FirstOrDefault();
                    }
                    else
                    {
                        buttonItem_Print.Visible = false;
                        Button_Add_Click(sender, e);
                        superTabControl_Main2.Visible = false;
                        Button_Search.Visible = false;
                        expandableSplitter1.Expandable = false;
                        expandableSplitter1.Enabled = false;
                        comboBox_RoomTyp_Leave(sender, e);
                    }
                }
                else if (R3 > 0 && R2 > 0 && db.StockRoom(R2).state.Value == 3)
                {
                    Button_Add.Visible = false;
                    textBox_ID.TextChanged += textBox_ID_TextChanged;
                    comboBox_Rooms.Enabled = false;
                    textBox_ID.Text = R3.ToString();
                    superTabControl_Main2.Visible = false;
                    Button_Search.Visible = false;
                    expandableSplitter1.Expandable = false;
                    expandableSplitter1.Enabled = false;
                }
                base.ActiveControl = textBox_NameA;
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Load:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        public void FillCombo()
        {
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
            List<T_IDType> listIDType = new List<T_IDType>(db.T_IDTypes.Select((T_IDType item) => item).ToList());
            CmbIDTyp.DataSource = null;
            CmbIDTyp.DataSource = listIDType;
            CmbIDTyp.DisplayMember = ((LangArEn == 0) ? "Arb_Des" : "Eng_Des");
            CmbIDTyp.ValueMember = "IDType_ID";
            List<T_Job> listJob = new List<T_Job>(db.T_Jobs.Select((T_Job item) => item).ToList());
            listJob.Insert(0, new T_Job());
            comboBox_Job.DataSource = null;
            comboBox_Job.DataSource = listJob;
            comboBox_Job.DisplayMember = ((LangArEn == 0) ? "NameA" : "NameE");
            comboBox_Job.ValueMember = "Job_No";
            List<T_Religion> listReligion = new List<T_Religion>(db.T_Religions.Select((T_Religion item) => item).ToList());
            listReligion.Insert(0, new T_Religion());
            comboBox_Religion.DataSource = null;
            comboBox_Religion.DataSource = listReligion;
            comboBox_Religion.DisplayMember = ((LangArEn == 0) ? "NameA" : "NameE");
            comboBox_Religion.ValueMember = "Religion_No";
            List<T_BirthPlace> listBirthPlace = new List<T_BirthPlace>(db.T_BirthPlaces.Select((T_BirthPlace item) => item).ToList());
            listBirthPlace.Insert(0, new T_BirthPlace());
            comboBox_BirthPlace.DataSource = null;
            comboBox_BirthPlace.DataSource = listBirthPlace;
            comboBox_BirthPlace.DisplayMember = ((LangArEn == 0) ? "NameA" : "NameE");
            comboBox_BirthPlace.ValueMember = "BirthPlaceNo";
            List<T_City> listIDFrom = new List<T_City>(db.T_Cities.Select((T_City item) => item).ToList());
            listIDFrom.Insert(0, new T_City());
            comboBox_ID_From.DataSource = null;
            comboBox_ID_From.DataSource = listIDFrom;
            comboBox_ID_From.DisplayMember = ((LangArEn == 0) ? "NameA" : "NameE");
            comboBox_ID_From.ValueMember = "City_No";
            List<T_Nationality> listNation = new List<T_Nationality>(db.T_Nationalities.Select((T_Nationality item) => item).ToList());
            listNation.Insert(0, new T_Nationality());
            comboBox_Nationality.DataSource = null;
            comboBox_Nationality.DataSource = listNation;
            comboBox_Nationality.DisplayMember = ((LangArEn == 0) ? "NameA" : "NameE");
            comboBox_Nationality.ValueMember = "Nation_No";
            List<T_Curency> listCurr = new List<T_Curency>(db.T_Curencies.Select((T_Curency item) => item).ToList());
            comboBox_Curr.DataSource = listCurr;
            comboBox_Curr.DisplayMember = ((LangArEn == 0) ? "Arb_Des" : "Eng_Des");
            comboBox_Curr.ValueMember = "Curency_ID";
            comboBox_Curr.SelectedIndex = 0;
            List<T_Rom> listRoms = new List<T_Rom>(db.T_Roms.Select((T_Rom item) => item).ToList());
            comboBox_Rooms.DataSource = listRoms;
            comboBox_Rooms.DisplayMember = "romno";
            comboBox_Rooms.ValueMember = "romno";
            comboBox_Rooms.SelectedIndex = -1;
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
                T_per newData = db.StockPer(no);
                if (newData == null || newData.perno == 0)
                {
                    if (!Button_Add.Visible)
                    {
                        MessageBox.Show((LangArEn == 0) ? "لا يمكن اتمام هذه العملية .. الرجاء مراجعة صلاحيات المستخدمين !" : "Can not complete this process .. please see the powers of the users!", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        textBox_ID.TextChanged -= textBox_ID_TextChanged;
                        try
                        {
                            textBox_ID.Text = data_this.perno.ToString();
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
                    int indexA = PKeys.IndexOf(string.Concat(newData.perno));
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
        }
        private void RomFill()
        {
            SS = 0;
            aa = "";
            T_Rom q = db.StockRoom(R2);
            if (q.typ.Value == 0)
            {
                label5.Text = ((LangArEn == 0) ? "رقم الغرفة" : "Room No :");
                label8.Text = ((LangArEn == 0) ? "سعر الغرفة" : "Price :");
            }
            else if (q.typ.Value == 1)
            {
                label5.Text = ((LangArEn == 0) ? "رقم الجناح" : "suite No :");
                label8.Text = ((LangArEn == 0) ? "سعر الجناح" : "Price :");
            }
            else if (q.typ.Value == 2)
            {
                label5.Text = ((LangArEn == 0) ? "رقم الفيلا" : "villa No :");
                label8.Text = ((LangArEn == 0) ? "سعر الفيلا" : "Price :");
            }
            else if (q.typ.Value == 3)
            {
                label5.Text = ((LangArEn == 0) ? "رقم الشقة" : "apartment :");
                label8.Text = ((LangArEn == 0) ? "سعر الشقة" : "Price :");
            }
            if (R1 == 0)
            {
                if (q.state.Value == 2)
                {
                    label11.Text = ((LangArEn == 0) ? "تاريخ الحجز :" : "booking date");
                }
                else if (q.state.Value == 3)
                {
                    label11.Text = ((LangArEn == 0) ? "تاريخ السكن :" : "Date :");
                }
            }
            else if (R1 == 1)
            {
                label11.Text = ((LangArEn == 0) ? "تاريخ الحجز :" : "booking date");
            }
            else if (R1 == 2 || R1 == 4)
            {
                label11.Text = ((LangArEn == 0) ? "تاريخ السكن :" : "Date :");
            }
            List<T_Rom> listRoms = new List<T_Rom>(db.T_Roms.Select((T_Rom item) => item).ToList());
            List<T_Rom> _list = new List<T_Rom>();
            if (R1 == 0)
            {
                for (int i = 0; i < listRoms.Count; i++)
                {
                    if (listRoms[i].state.Value == 3)
                    {
                        aa = "1";
                        _list.Add(listRoms[i]);
                    }
                }
                comboBox_Rooms.DataSource = _list;
                comboBox_Rooms.DisplayMember = "romno";
                comboBox_Rooms.ValueMember = "perno";
            }
            else if (R1 == 4)
            {
                for (int i = 0; i < listRoms.Count; i++)
                {
                    if (listRoms[i].state.Value == 1)
                    {
                        aa = "1";
                        _list.Add(listRoms[i]);
                    }
                }
                comboBox_Rooms.DataSource = _list;
                comboBox_Rooms.DisplayMember = "romno";
                comboBox_Rooms.ValueMember = "perno";
            }
            else if (R1 == 1 || R1 == 2)
            {
                for (int i = 0; i < listRoms.Count; i++)
                {
                    if (listRoms[i].state.Value == 1)
                    {
                        aa = "1";
                        _list.Add(listRoms[i]);
                    }
                }
                comboBox_Rooms.DataSource = _list;
                comboBox_Rooms.DisplayMember = "romno";
                comboBox_Rooms.ValueMember = "perno";
            }
            comboBox_Rooms.SelectedIndex = 0;
            M = 0;
            Mm = 0;
            comboBox_Rooms.SelectedValue = R2;
        }
        public void SetData(T_per value)
        {
            try
            {
                State = FormState.Saved;
                Button_Save.Enabled = false;
                ButtonItem buttonItem = buttonItem_AddRoom;
                int? hed = db.StockRoom(value.romno.Value).hed;
                buttonItem.Enabled = ((hed.GetValueOrDefault() != 0 || !hed.HasValue) ? true : false);
                if (db.StockRoom(value.romno.Value).typ.Value == 0)
                {
                    label5.Text = ((LangArEn == 0) ? "رقم الغرفة :" : "Room No :");
                    if (LangArEn == 1)
                    {
                        label5.Left += 10;
                    }
                    label8.Text = ((LangArEn == 0) ? "سعر الغرفة :" : "Price :");
                }
                else if (db.StockRoom(value.romno.Value).typ.Value == 1)
                {
                    label5.Text = ((LangArEn == 0) ? "رقم الجنـاح :" : "suite No :");
                    if (LangArEn == 1)
                    {
                        label5.Left += 10;
                    }
                    label8.Text = ((LangArEn == 0) ? "سعر الجنـاح :" : "Price :");
                }
                else if (db.StockRoom(value.romno.Value).typ.Value == 2)
                {
                    label5.Text = ((LangArEn == 0) ? "رقم الفيلا :" : "villa No :");
                    if (LangArEn == 1)
                    {
                        label5.Left += 10;
                    }
                    label8.Text = ((LangArEn == 0) ? "سعر الفيلا :" : "Price :");
                }
                else if (db.StockRoom(value.romno.Value).typ.Value == 3)
                {
                    label5.Text = ((LangArEn == 0) ? "رقم الشقـة :" : "apartment :");
                    label8.Text = ((LangArEn == 0) ? "سعر الشقـة :" : "Price :");
                }
                if (R1 == 0)
                {
                    if (db.StockRoom(value.romno.Value).state.Value == 2)
                    {
                        label11.Text = ((LangArEn == 0) ? "تاريخ الحجز :" : "booking date");
                    }
                    else if (db.StockRoom(value.romno.Value).state.Value == 3)
                    {
                        label11.Text = ((LangArEn == 0) ? "تاريخ السكن :" : "Date :");
                        if (LangArEn == 1)
                        {
                            label11.Left = label6.Left + 18;
                        }
                    }
                }
                else if (R1 == 1)
                {
                    label11.Text = ((LangArEn == 0) ? "تاريخ الحجز :" : "booking date");
                }
                else if (R1 == 2 || R1 == 4)
                {
                    label11.Text = ((LangArEn == 0) ? "تاريخ السكن :" : "Date :");
                    if (LangArEn == 1)
                    {
                        label11.Left = label6.Left + 18;
                    }
                }
                if (db.StockRoom(value.romno.Value).state == 1)
                {
                    textBox_RoomStat.Text = ((LangArEn == 0) ? "فارغة" : "Empty");
                }
                else if (db.StockRoom(value.romno.Value).state == 2)
                {
                    textBox_RoomStat.Text = ((LangArEn == 0) ? "محجوزة" : "Reserved");
                }
                else if (db.StockRoom(value.romno.Value).state == 3)
                {
                    textBox_RoomStat.Text = ((LangArEn == 0) ? "مشغولة" : "Busy");
                }
                comboBox_DisType.SelectedIndex = value.disknd.Value;
                comboBox_DisTo.SelectedIndex = value.distyp.Value;
                comboBox_RoomTyp.SelectedIndex = value.KindPer.Value;
                try
                {
                    if (!string.IsNullOrEmpty(value.Cust_no))
                    {
                        txtCustNo.Text = value.Cust_no.ToString();
                        textBox_NameA.Text = db.StockAccDefWithOutBalance(value.Cust_no).Arb_Des;
                        textBox_NameE.Text = db.StockAccDefWithOutBalance(value.Cust_no).Eng_Des;
                    }
                    else
                    {
                        txtCustNo.Text = "";
                    }
                }
                catch
                {
                    txtCustNo.Text = "";
                }
                if (value.nath.HasValue)
                {
                    comboBox_Nationality.SelectedValue = value.nath;
                }
                else
                {
                    comboBox_Nationality.SelectedIndex = 0;
                }
                if (value.pastyp.HasValue)
                {
                    CmbIDTyp.SelectedValue = value.pastyp;
                }
                else
                {
                    CmbIDTyp.SelectedIndex = 0;
                }
                if (value.job.HasValue)
                {
                    comboBox_Job.SelectedValue = value.job;
                }
                else
                {
                    comboBox_Job.SelectedIndex = 0;
                }
                if (value.curr.HasValue)
                {
                    comboBox_Curr.SelectedValue = value.curr;
                }
                else
                {
                    comboBox_Curr.SelectedIndex = 0;
                }
                if (value.romno.HasValue)
                {
                    comboBox_Rooms.SelectedValue = value.romno.Value;
                }
                if (!string.IsNullOrEmpty(value.bpls))
                {
                    comboBox_BirthPlace.SelectedValue = int.Parse(value.bpls);
                }
                else
                {
                    comboBox_BirthPlace.SelectedIndex = 0;
                }
                if (value.vip.HasValue)
                {
                    comboBox_Religion.SelectedValue = value.vip;
                }
                else
                {
                    comboBox_Religion.SelectedIndex = 0;
                }
                if (!string.IsNullOrEmpty(value.paspls))
                {
                    comboBox_ID_From.SelectedValue = int.Parse(value.paspls);
                }
                else
                {
                    comboBox_ID_From.SelectedIndex = 0;
                }
                if (value.cc.HasValue)
                {
                    hed = value.cc;
                    if (hed.Value == 0 && hed.HasValue)
                    {
                        checkBox_Chash.Checked = true;
                    }
                    else if (value.cc == 1)
                    {
                        checkBox_Credit.Checked = true;
                    }
                }
                if (value.pict != null)
                {
                    byte[] arr = value.pict.ToArray();
                    MemoryStream stream = new MemoryStream(arr);
                    PicItemImg.Image = Image.FromStream(stream);
                }
                else
                {
                    PicItemImg.Image = null;
                }
                textBox_ID.Tag = value.perno;
                textBox_DayCount.Text = value.day;
                dateTimeInput_BirthDate.Text = value.bdt;
                textBox_ID_No.Text = value.pasno;
                dateTimeInput_ID_Date.Text = value.passt;
                dateTimeInput_ID_DateEnd.Text = value.pasend;
                textBox_Mobile.Text = value.enddt;
                textBox_Note.Text = value.jobpls;
                try
                {
                    Text_11.Value = value.ser.Value;
                }
                catch
                {
                    Text_11.Value = 0.0;
                }
                try
                {
                    Text_12.Value = value.tax.Value;
                }
                catch
                {
                    Text_12.Value = 0.0;
                }
                textBox_RoomPrice.Value = value.price.Value;
                Textbox_DiscountVal.Value = value.dis.Value;
                textBox_DayRequest.Value = value.DayImport.Value;
                if (value.DayOfM.HasValue)
                {
                    VarGeneral.GDayM = value.DayOfM.Value;
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
                BindingList<T_per1> Family_line = new BindingList<T_per1>(value.T_per1s);
                FillFamilyBox(Family_line);
                if (R1 != 0)
                {
                    return;
                }
                if (db.StockRoom(value.romno.Value).state.Value == 2)
                {
                    label11.Text = ((LangArEn == 0) ? "تاريخ الحجز :" : "booking date");
                    textBox_Time.Text = value.tm1;
                    textBox_Date.Text = db.StockRoom(value.romno.Value).dt;
                    if (value.vAmPm == "AM")
                    {
                        RadioBox_AllowAM.Checked = true;
                    }
                    else
                    {
                        RadioBox_AllowPM.Checked = true;
                    }
                }
                else if (db.StockRoom(value.romno.Value).state.Value == 3)
                {
                    label11.Text = ((LangArEn == 0) ? "تاريخ السكن :" : "Date :");
                    if (LangArEn == 1)
                    {
                        label11.Left = label6.Left + 18;
                    }
                    if (comboBox_RoomTyp.SelectedIndex == 0)
                    {
                        textBox_DayCount.Value = VarGeneral.Dy(db.StockRoom(value.romno.Value).dt, db.StockRoom(value.romno.Value).tm);
                    }
                    else
                    {
                        textBox_DayCount.Value = VarGeneral.Dy(db.StockRoom(value.romno.Value).dt, db.StockRoom(value.romno.Value).tm);
                        VarGeneral.Dy2(db.StockRoom(value.romno.Value).dt, db.StockRoom(value.romno.Value).tm);
                        textBox_DayRequest.Enabled = false;
                    }
                    Total();
                    textBox_Time.Text = value.tm1;
                    textBox_Date.Text = db.StockRoom(value.romno.Value).dt;
                    if (value.vAmPm == "AM")
                    {
                        RadioBox_AllowAM.Checked = true;
                    }
                    else
                    {
                        RadioBox_AllowPM.Checked = true;
                    }
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("SetData:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void FillFamilyBox(BindingList<T_per1> linesList)
        {
            if (linesList.Count <= 0)
            {
                return;
            }
            linesList.OrderBy((T_per1 g) => g.ID);
            for (int i = 0; i < linesList.Count; i++)
            {
                if (i == 0)
                {
                    textBox_Name1.Text = linesList[i].nm;
                    try
                    {
                        dateTimeInput_BirthDate1.Text = Convert.ToDateTime(linesList[i].bpls).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_BirthDate1.Text = "";
                    }
                    try
                    {
                        dateTimeInput_PassportDateEnd1.Text = Convert.ToDateTime(linesList[i].pasend).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_PassportDateEnd1.Text = "";
                    }
                    try
                    {
                        dateTimeInput_PassportDateStart1.Text = Convert.ToDateTime(linesList[i].passt).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_PassportDateStart1.Text = "";
                    }
                    textBox_PassporntNo1.Text = linesList[i].pasno;
                }
                if (i == 1)
                {
                    textBox_Name2.Text = linesList[i].nm;
                    try
                    {
                        dateTimeInput_BirthDate2.Text = Convert.ToDateTime(linesList[i].bpls).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_BirthDate2.Text = "";
                    }
                    try
                    {
                        dateTimeInput_PassportDateEnd2.Text = Convert.ToDateTime(linesList[i].pasend).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_PassportDateEnd2.Text = "";
                    }
                    try
                    {
                        dateTimeInput_PassportDateStart2.Text = Convert.ToDateTime(linesList[i].passt).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_PassportDateStart2.Text = "";
                    }
                    textBox_PassporntNo2.Text = linesList[i].pasno;
                }
                if (i == 2)
                {
                    textBox_Name3.Text = linesList[i].nm;
                    try
                    {
                        dateTimeInput_BirthDate3.Text = Convert.ToDateTime(linesList[i].bpls).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_BirthDate3.Text = "";
                    }
                    try
                    {
                        dateTimeInput_PassportDateEnd3.Text = Convert.ToDateTime(linesList[i].pasend).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_PassportDateEnd3.Text = "";
                    }
                    try
                    {
                        dateTimeInput_PassportDateStart3.Text = Convert.ToDateTime(linesList[i].passt).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_PassportDateStart3.Text = "";
                    }
                    textBox_PassporntNo3.Text = linesList[i].pasno;
                }
                if (i == 3)
                {
                    textBox_Name4.Text = linesList[i].nm;
                    try
                    {
                        dateTimeInput_BirthDate4.Text = Convert.ToDateTime(linesList[i].bpls).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_BirthDate4.Text = "";
                    }
                    try
                    {
                        dateTimeInput_PassportDateEnd4.Text = Convert.ToDateTime(linesList[i].pasend).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_PassportDateEnd4.Text = "";
                    }
                    try
                    {
                        dateTimeInput_PassportDateStart4.Text = Convert.ToDateTime(linesList[i].passt).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_PassportDateStart4.Text = "";
                    }
                    textBox_PassporntNo4.Text = linesList[i].pasno;
                }
                if (i == 4)
                {
                    textBox_Name5.Text = linesList[i].nm;
                    try
                    {
                        dateTimeInput_BirthDate5.Text = Convert.ToDateTime(linesList[i].bpls).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_BirthDate5.Text = "";
                    }
                    try
                    {
                        dateTimeInput_PassportDateEnd5.Text = Convert.ToDateTime(linesList[i].pasend).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_PassportDateEnd5.Text = "";
                    }
                    try
                    {
                        dateTimeInput_PassportDateStart5.Text = Convert.ToDateTime(linesList[i].passt).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_PassportDateStart5.Text = "";
                    }
                    textBox_PassporntNo5.Text = linesList[i].pasno;
                }
                if (i == 5)
                {
                    textBox_Name6.Text = linesList[i].nm;
                    try
                    {
                        dateTimeInput_BirthDate6.Text = Convert.ToDateTime(linesList[i].bpls).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_BirthDate6.Text = "";
                    }
                    try
                    {
                        dateTimeInput_PassportDateEnd6.Text = Convert.ToDateTime(linesList[i].pasend).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_PassportDateEnd6.Text = "";
                    }
                    try
                    {
                        dateTimeInput_PassportDateStart6.Text = Convert.ToDateTime(linesList[i].passt).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_PassportDateStart6.Text = "";
                    }
                    textBox_PassporntNo6.Text = linesList[i].pasno;
                }
                if (i == 6)
                {
                    textBox_Name7.Text = linesList[i].nm;
                    try
                    {
                        dateTimeInput_BirthDate7.Text = Convert.ToDateTime(linesList[i].bpls).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_BirthDate7.Text = "";
                    }
                    try
                    {
                        dateTimeInput_PassportDateEnd6.Text = Convert.ToDateTime(linesList[i].pasend).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_PassportDateEnd6.Text = "";
                    }
                    try
                    {
                        dateTimeInput_PassportDateStart7.Text = Convert.ToDateTime(linesList[i].passt).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_PassportDateStart7.Text = "";
                    }
                    textBox_PassporntNo7.Text = linesList[i].pasno;
                }
                if (i == 7)
                {
                    textBox_Name8.Text = linesList[i].nm;
                    try
                    {
                        dateTimeInput_BirthDate8.Text = Convert.ToDateTime(linesList[i].bpls).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_BirthDate8.Text = "";
                    }
                    try
                    {
                        dateTimeInput_PassportDateEnd6.Text = Convert.ToDateTime(linesList[i].pasend).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_PassportDateEnd6.Text = "";
                    }
                    try
                    {
                        dateTimeInput_PassportDateStart8.Text = Convert.ToDateTime(linesList[i].passt).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_PassportDateStart8.Text = "";
                    }
                    textBox_PassporntNo8.Text = linesList[i].pasno;
                }
                if (i == 8)
                {
                    textBox_Name9.Text = linesList[i].nm;
                    try
                    {
                        dateTimeInput_BirthDate9.Text = Convert.ToDateTime(linesList[i].bpls).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_BirthDate9.Text = "";
                    }
                    try
                    {
                        dateTimeInput_PassportDateEnd9.Text = Convert.ToDateTime(linesList[i].pasend).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_PassportDateEnd9.Text = "";
                    }
                    try
                    {
                        dateTimeInput_PassportDateStart9.Text = Convert.ToDateTime(linesList[i].passt).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_PassportDateStart9.Text = "";
                    }
                    textBox_PassporntNo9.Text = linesList[i].pasno;
                }
                if (i == 9)
                {
                    textBox_Name10.Text = linesList[i].nm;
                    try
                    {
                        dateTimeInput_BirthDate10.Text = Convert.ToDateTime(linesList[i].bpls).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_BirthDate10.Text = "";
                    }
                    try
                    {
                        dateTimeInput_PassportDateEnd10.Text = Convert.ToDateTime(linesList[i].pasend).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_PassportDateEnd10.Text = "";
                    }
                    try
                    {
                        dateTimeInput_PassportDateStart10.Text = Convert.ToDateTime(linesList[i].passt).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_PassportDateStart10.Text = "";
                    }
                    textBox_PassporntNo10.Text = linesList[i].pasno;
                }
            }
        }
        private void Total()
        {
            try
            {
                double Tot1 = 0.0;
                double Tot3 = 0.0;
                double Tot4 = 0.0;
                double Tot5 = 0.0;
                double Tot6 = 0.0;
                double Tot7 = 0.0;
                double Tot8 = 0.0;
                double Tot9 = 0.0;
                double Tot2 = 0.0;
                if (db.StockRoom(data_this.romno.Value).hed.Value == 1 || db.StockRoom(data_this.romno.Value).hed.Value == 0)
                {
                    try
                    {
                        List<double> sqlst = db.ExecuteQuery<double>("select sum(price) as SumPrice from [T_tran] where perno=" + textBox_ID.Text, new object[0]).ToList();
                        if (sqlst.Count > 0)
                        {
                            Tot1 = ((!string.IsNullOrEmpty(sqlst.FirstOrDefault().ToString())) ? sqlst.FirstOrDefault() : 0.0);
                        }
                    }
                    catch
                    {
                        Tot1 = 0.0;
                    }
                    try
                    {
                        List<double> sqlst = db.ExecuteQuery<double>("select sum(price) as SumPrice from [T_tel] where perno=" + textBox_ID.Text, new object[0]).ToList();
                        if (sqlst.Count > 0)
                        {
                            Tot3 = ((!string.IsNullOrEmpty(sqlst.FirstOrDefault().ToString())) ? sqlst.FirstOrDefault() : 0.0);
                        }
                    }
                    catch
                    {
                        Tot3 = 0.0;
                    }
                    try
                    {
                        List<double> sqlst = db.ExecuteQuery<double>("SELECT Sum(case when [T_Snd].[typ]=1 then [T_Snd].[price]*[T_Snd].[curcost] else -[T_Snd].[price]*[T_Snd].[curcost] end) AS SumPrice FROM [T_Snd] where perno=" + textBox_ID.Text + " and ch<>3", new object[0]).ToList();
                        if (sqlst.Count > 0)
                        {
                            Tot4 = ((!string.IsNullOrEmpty(sqlst.FirstOrDefault().ToString())) ? sqlst.FirstOrDefault() : 0.0);
                        }
                    }
                    catch
                    {
                        Tot4 = 0.0;
                    }
                }
                if (data_this.DayOfM.HasValue)
                {
                    VarGeneral.GDayM = data_this.DayOfM.Value;
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
                Tot5 = ((comboBox_RoomTyp.SelectedIndex != 1) ? (textBox_RoomPrice.Value * double.Parse(textBox_DayCount.Text)) : (textBox_RoomPrice.Value * (double)VarGeneral.CS));
                Text_1.Text = Tot5.ToString();
                Tot2 = Tot1 + Tot3 + Tot5;
                Tot6 = Tot5 * data_this.tax.Value / 100.0;
                Tot7 = Tot5 * data_this.ser.Value / 100.0;
                Tot2 = Tot1 + Tot3 + Tot5 + Tot6 + Tot7;
                if (comboBox_DisType.SelectedIndex == 1)
                {
                    if (comboBox_DisTo.SelectedIndex == 0)
                    {
                        Tot8 = Tot5 * Textbox_DiscountVal.Value / 100.0;
                        Tot5 -= Tot8;
                        Tot6 = Tot5 * data_this.tax.Value / 100.0;
                        Tot7 = Tot5 * data_this.ser.Value / 100.0;
                    }
                    else if (comboBox_DisTo.SelectedIndex == 1)
                    {
                        Tot9 = Tot2 * Textbox_DiscountVal.Value / 100.0;
                    }
                }
                else if (comboBox_DisType.SelectedIndex == 2)
                {
                    if (comboBox_DisTo.SelectedIndex == 0)
                    {
                        Tot8 = Textbox_DiscountVal.Value * (double)textBox_DayCount.Value;
                        Tot5 -= Tot8;
                        Tot6 = Tot5 * data_this.tax.Value / 100.0;
                        Tot7 = Tot5 * data_this.ser.Value / 100.0;
                    }
                    else if (comboBox_DisTo.SelectedIndex == 1)
                    {
                        Tot9 = Textbox_DiscountVal.Value;
                    }
                }
                Tot2 = Tot1 + Tot3 + Tot5 + Tot6 + Tot7 - Tot9;
                Tot = Tot2 - Tot4;
                TextBox_TotalAm.Value = Tot2;
                TextBox_Paid.Value = Tot4;
                TextBox_Remming.Value = Tot;
                if (TextBox_Remming.Value < 0.0)
                {
                    TextBox_Remming.ForeColor = Color.Red;
                }
                else
                {
                    TextBox_Remming.ForeColor = Color.Blue;
                }
                VarGeneral.CS = 1;
            }
            catch
            {
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
        private void CDatt()
        {
            CDat2 = textBox_DayRequest.Value;
            CDat = Convert.ToDateTime(textBox_Date.Text).AddDays(CDat2).ToString("yyyy/MM/dd");
        }
        private void SvFamily()
        {
            for (int i = 1; i <= 10; i++)
            {
                DataThisFamily = new T_per1();
                if (i == 1 && !string.IsNullOrEmpty(textBox_Name1.Text))
                {
                    DataThisFamily.perno = int.Parse(textBox_ID.Text);
                    try
                    {
                        DataThisFamily.nm = textBox_Name1.Text;
                    }
                    catch
                    {
                    }
                    try
                    {
                        DataThisFamily.pasno = textBox_PassporntNo1.Text;
                    }
                    catch
                    {
                    }
                    try
                    {
                        DataThisFamily.pasend = Convert.ToDateTime(dateTimeInput_PassportDateEnd1.Text).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_PassportDateEnd1.Text = "";
                        DataThisFamily.pasend = "";
                    }
                    try
                    {
                        DataThisFamily.passt = Convert.ToDateTime(dateTimeInput_PassportDateStart1.Text).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_PassportDateStart1.Text = "";
                        DataThisFamily.passt = "";
                    }
                    try
                    {
                        DataThisFamily.bpls = Convert.ToDateTime(dateTimeInput_BirthDate1.Text).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_BirthDate1.Text = "";
                        DataThisFamily.bpls = "";
                    }
                    db.T_per1s.InsertOnSubmit(DataThisFamily);
                    db.SubmitChanges();
                }
                if (i == 2 && !string.IsNullOrEmpty(textBox_Name2.Text) && !string.IsNullOrEmpty(textBox_Name1.Text))
                {
                    DataThisFamily.perno = int.Parse(textBox_ID.Text);
                    try
                    {
                        DataThisFamily.nm = textBox_Name2.Text;
                    }
                    catch
                    {
                    }
                    try
                    {
                        DataThisFamily.pasno = textBox_PassporntNo2.Text;
                    }
                    catch
                    {
                    }
                    try
                    {
                        DataThisFamily.pasend = Convert.ToDateTime(dateTimeInput_PassportDateEnd2.Text).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_PassportDateEnd2.Text = "";
                        DataThisFamily.pasend = "";
                    }
                    try
                    {
                        DataThisFamily.bpls = Convert.ToDateTime(dateTimeInput_BirthDate2.Text).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_BirthDate2.Text = "";
                        DataThisFamily.bpls = "";
                    }
                    try
                    {
                        DataThisFamily.passt = Convert.ToDateTime(dateTimeInput_PassportDateStart2.Text).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_PassportDateStart2.Text = "";
                        DataThisFamily.passt = "";
                    }
                    db.T_per1s.InsertOnSubmit(DataThisFamily);
                    db.SubmitChanges();
                }
                if (i == 3 && !string.IsNullOrEmpty(textBox_Name3.Text) && !string.IsNullOrEmpty(textBox_Name2.Text))
                {
                    DataThisFamily.perno = int.Parse(textBox_ID.Text);
                    try
                    {
                        DataThisFamily.nm = textBox_Name3.Text;
                    }
                    catch
                    {
                    }
                    try
                    {
                        DataThisFamily.pasno = textBox_PassporntNo3.Text;
                    }
                    catch
                    {
                    }
                    try
                    {
                        DataThisFamily.pasend = Convert.ToDateTime(dateTimeInput_PassportDateEnd3.Text).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_PassportDateEnd3.Text = "";
                        DataThisFamily.pasend = "";
                    }
                    try
                    {
                        DataThisFamily.bpls = Convert.ToDateTime(dateTimeInput_BirthDate3.Text).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_BirthDate3.Text = "";
                        DataThisFamily.bpls = "";
                    }
                    try
                    {
                        DataThisFamily.passt = Convert.ToDateTime(dateTimeInput_PassportDateStart3.Text).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_PassportDateStart3.Text = "";
                        DataThisFamily.passt = "";
                    }
                    db.T_per1s.InsertOnSubmit(DataThisFamily);
                    db.SubmitChanges();
                }
                if (i == 4 && !string.IsNullOrEmpty(textBox_Name4.Text) && !string.IsNullOrEmpty(textBox_Name3.Text))
                {
                    DataThisFamily.perno = int.Parse(textBox_ID.Text);
                    try
                    {
                        DataThisFamily.nm = textBox_Name4.Text;
                    }
                    catch
                    {
                    }
                    try
                    {
                        DataThisFamily.pasno = textBox_PassporntNo4.Text;
                    }
                    catch
                    {
                    }
                    try
                    {
                        DataThisFamily.pasend = Convert.ToDateTime(dateTimeInput_PassportDateEnd4.Text).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_PassportDateEnd4.Text = "";
                        DataThisFamily.pasend = "";
                    }
                    try
                    {
                        DataThisFamily.bpls = Convert.ToDateTime(dateTimeInput_BirthDate4.Text).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_BirthDate4.Text = "";
                        DataThisFamily.bpls = "";
                    }
                    try
                    {
                        DataThisFamily.passt = Convert.ToDateTime(dateTimeInput_PassportDateStart4.Text).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_PassportDateStart4.Text = "";
                        DataThisFamily.passt = "";
                    }
                    db.T_per1s.InsertOnSubmit(DataThisFamily);
                    db.SubmitChanges();
                }
                if (i == 5 && !string.IsNullOrEmpty(textBox_Name5.Text) && !string.IsNullOrEmpty(textBox_Name4.Text))
                {
                    DataThisFamily.perno = int.Parse(textBox_ID.Text);
                    try
                    {
                        DataThisFamily.nm = textBox_Name5.Text;
                    }
                    catch
                    {
                    }
                    try
                    {
                        DataThisFamily.pasno = textBox_PassporntNo5.Text;
                    }
                    catch
                    {
                    }
                    try
                    {
                        DataThisFamily.pasend = Convert.ToDateTime(dateTimeInput_PassportDateEnd5.Text).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_PassportDateEnd5.Text = "";
                        DataThisFamily.pasend = "";
                    }
                    try
                    {
                        DataThisFamily.bpls = Convert.ToDateTime(dateTimeInput_BirthDate5.Text).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_BirthDate5.Text = "";
                        DataThisFamily.bpls = "";
                    }
                    try
                    {
                        DataThisFamily.passt = Convert.ToDateTime(dateTimeInput_PassportDateStart5.Text).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_PassportDateStart5.Text = "";
                        DataThisFamily.passt = "";
                    }
                    db.T_per1s.InsertOnSubmit(DataThisFamily);
                    db.SubmitChanges();
                }
                if (i == 6 && !string.IsNullOrEmpty(textBox_Name6.Text) && !string.IsNullOrEmpty(textBox_Name5.Text))
                {
                    DataThisFamily.perno = int.Parse(textBox_ID.Text);
                    try
                    {
                        DataThisFamily.nm = textBox_Name6.Text;
                    }
                    catch
                    {
                    }
                    try
                    {
                        DataThisFamily.pasno = textBox_PassporntNo6.Text;
                    }
                    catch
                    {
                    }
                    try
                    {
                        DataThisFamily.pasend = Convert.ToDateTime(dateTimeInput_PassportDateEnd6.Text).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_PassportDateEnd6.Text = "";
                        DataThisFamily.pasend = "";
                    }
                    try
                    {
                        DataThisFamily.bpls = Convert.ToDateTime(dateTimeInput_BirthDate6.Text).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_BirthDate6.Text = "";
                        DataThisFamily.bpls = "";
                    }
                    try
                    {
                        DataThisFamily.passt = Convert.ToDateTime(dateTimeInput_PassportDateStart6.Text).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_PassportDateStart6.Text = "";
                        DataThisFamily.passt = "";
                    }
                    db.T_per1s.InsertOnSubmit(DataThisFamily);
                    db.SubmitChanges();
                }
                if (i == 7 && !string.IsNullOrEmpty(textBox_Name7.Text) && !string.IsNullOrEmpty(textBox_Name6.Text))
                {
                    DataThisFamily.perno = int.Parse(textBox_ID.Text);
                    try
                    {
                        DataThisFamily.nm = textBox_Name7.Text;
                    }
                    catch
                    {
                    }
                    try
                    {
                        DataThisFamily.pasno = textBox_PassporntNo7.Text;
                    }
                    catch
                    {
                    }
                    try
                    {
                        DataThisFamily.pasend = Convert.ToDateTime(dateTimeInput_PassportDateEnd6.Text).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_PassportDateEnd6.Text = "";
                        DataThisFamily.pasend = "";
                    }
                    try
                    {
                        DataThisFamily.bpls = Convert.ToDateTime(dateTimeInput_BirthDate7.Text).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_BirthDate7.Text = "";
                        DataThisFamily.bpls = "";
                    }
                    try
                    {
                        DataThisFamily.passt = Convert.ToDateTime(dateTimeInput_PassportDateStart7.Text).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_PassportDateStart7.Text = "";
                        DataThisFamily.passt = "";
                    }
                    db.T_per1s.InsertOnSubmit(DataThisFamily);
                    db.SubmitChanges();
                }
                if (i == 8 && !string.IsNullOrEmpty(textBox_Name8.Text) && !string.IsNullOrEmpty(textBox_Name7.Text))
                {
                    DataThisFamily.perno = int.Parse(textBox_ID.Text);
                    try
                    {
                        DataThisFamily.nm = textBox_Name8.Text;
                    }
                    catch
                    {
                    }
                    try
                    {
                        DataThisFamily.pasno = textBox_PassporntNo8.Text;
                    }
                    catch
                    {
                    }
                    try
                    {
                        DataThisFamily.pasend = Convert.ToDateTime(dateTimeInput_PassportDateEnd6.Text).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_PassportDateEnd6.Text = "";
                        DataThisFamily.pasend = "";
                    }
                    try
                    {
                        DataThisFamily.bpls = Convert.ToDateTime(dateTimeInput_BirthDate8.Text).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_BirthDate8.Text = "";
                        DataThisFamily.bpls = "";
                    }
                    try
                    {
                        DataThisFamily.passt = Convert.ToDateTime(dateTimeInput_PassportDateStart8.Text).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_PassportDateStart8.Text = "";
                        DataThisFamily.passt = "";
                    }
                    db.T_per1s.InsertOnSubmit(DataThisFamily);
                    db.SubmitChanges();
                }
                if (i == 9 && !string.IsNullOrEmpty(textBox_Name9.Text) && !string.IsNullOrEmpty(textBox_Name8.Text))
                {
                    DataThisFamily.perno = int.Parse(textBox_ID.Text);
                    try
                    {
                        DataThisFamily.nm = textBox_Name9.Text;
                    }
                    catch
                    {
                    }
                    try
                    {
                        DataThisFamily.pasno = textBox_PassporntNo9.Text;
                    }
                    catch
                    {
                    }
                    try
                    {
                        DataThisFamily.pasend = Convert.ToDateTime(dateTimeInput_PassportDateEnd9.Text).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_PassportDateEnd9.Text = "";
                        DataThisFamily.pasend = "";
                    }
                    try
                    {
                        DataThisFamily.bpls = Convert.ToDateTime(dateTimeInput_BirthDate9.Text).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_BirthDate9.Text = "";
                        DataThisFamily.bpls = "";
                    }
                    try
                    {
                        DataThisFamily.passt = Convert.ToDateTime(dateTimeInput_PassportDateStart9.Text).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_PassportDateStart9.Text = "";
                        DataThisFamily.passt = "";
                    }
                    db.T_per1s.InsertOnSubmit(DataThisFamily);
                    db.SubmitChanges();
                }
                if (i == 10 && !string.IsNullOrEmpty(textBox_Name10.Text) && !string.IsNullOrEmpty(textBox_Name9.Text))
                {
                    DataThisFamily.perno = int.Parse(textBox_ID.Text);
                    try
                    {
                        DataThisFamily.nm = textBox_Name10.Text;
                    }
                    catch
                    {
                    }
                    try
                    {
                        DataThisFamily.pasno = textBox_PassporntNo10.Text;
                    }
                    catch
                    {
                    }
                    try
                    {
                        DataThisFamily.pasend = Convert.ToDateTime(dateTimeInput_PassportDateEnd10.Text).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_PassportDateEnd10.Text = "";
                        DataThisFamily.pasend = "";
                    }
                    try
                    {
                        DataThisFamily.bpls = Convert.ToDateTime(dateTimeInput_BirthDate10.Text).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_BirthDate10.Text = "";
                        DataThisFamily.bpls = "";
                    }
                    try
                    {
                        DataThisFamily.passt = Convert.ToDateTime(dateTimeInput_PassportDateStart10.Text).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_PassportDateStart10.Text = "";
                        DataThisFamily.passt = "";
                    }
                    db.T_per1s.InsertOnSubmit(DataThisFamily);
                    db.SubmitChanges();
                }
            }
        }
        private void ExtThisFrm(List<T_Reserv> _ReservChk)
        {
            FrmShowReserv frm = new FrmShowReserv();
            frm.Tag = LangArEn;
            frm.VS.Cols[7].Visible = true;
            frm.VS.Rows.Count = _ReservChk.Count + 1;
            for (int i = 1; i <= _ReservChk.Count; i++)
            {
                frm.VS.SetData(i, 0, i);
                frm.VS.SetData(i, 1, _ReservChk[i - 1].ResrvNo);
                frm.VS.SetData(i, 2, _ReservChk[i - 1].Dat);
                frm.VS.SetData(i, 3, _ReservChk[i - 1].PerNm);
                if (_ReservChk[i - 1].Nat.HasValue)
                {
                    frm.VS.SetData(i, 4, (LangArEn == 0) ? db.NationEmp(_ReservChk[i - 1].Nat.Value).NameA : db.NationEmp(_ReservChk[i - 1].Nat.Value).NameE);
                }
                else
                {
                    frm.VS.SetData(i, 4, (LangArEn == 0) ? "لا يوجد" : "non");
                }
                frm.VS.SetData(i, 5, _ReservChk[i - 1].IdNo);
                frm.VS.SetData(i, 6, _ReservChk[i - 1].Rom);
                frm.VS.SetData(i, 7, "ساري الحجز");
                frm.VS.SetData(i, 8, _ReservChk[i - 1].Sts);
                frm.VS.SetData(i, 9, _ReservChk[i - 1].Dat2);
            }
            Hide();
            frm.TopMost = true;
            frm.ShowDialog();
            Close();
        }
        private T_per GetData()
        {
            bb = 0;
            textBox_NameA.Focus();
            CDatt();
            List<T_Reserv> _ReservChk = db.ExecuteQuery<T_Reserv>("SELECT T_Reserv.ResrvNo, T_Reserv.Dat, T_Reserv.Rom, T_Reserv.Sts, T_Reserv.PerNm, T_Reserv.IdNo, T_Reserv.Nat , T_Reserv.Dat2 FROM T_Reserv where T_Reserv.Rom = " + R2 + " and T_Reserv.sts=0 and ((T_Reserv.Dat < '" + textBox_Date.Text + "' and T_Reserv.Dat >= '" + CDat + "') or (T_Reserv.Dat2 > '" + textBox_Date.Text + "' and T_Reserv.Dat2 < '" + CDat + "') or (  '" + CDat + "' <= T_Reserv.Dat2 and '" + textBox_Date.Text + "' >= T_Reserv.Dat)) or ((T_Reserv.Dat < '" + CDat + "' and T_Reserv.Dat > '" + textBox_Date.Text + "' ) and T_Reserv.Rom = " + R2 + " )", new object[0]).ToList();
            if (_ReservChk.Count > 0 && !(_ReservChk[0].ResrvNo.ToString() == VarGeneral.Tmp6))
            {
                MessageBox.Show(" لايمكن اتمام العملية  لان الغرفة محجوزة في هذه الفترة ", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                ExtThisFrm(_ReservChk);
                bb = 1;
                return data_this;
            }
            if (R1 == 4 && M != 2)
            {
                T_Reserv rsTmp = db.StockReserv(int.Parse(VarGeneral.Tmp6));
                if (rsTmp != null)
                {
                    db.ExecuteCommand(" UPDATE [T_Reserv] Set [Sts] = 1 where ResrvNo = " + VarGeneral.Tmp6);
                    R1 = 2;
                }
            }
            if ((R1 == 1 || R1 == 2 || R1 == 4) && M != 2)
            {
                data_this.ps1 = VarGeneral.UserNo;
                data_this.perno = int.Parse(textBox_ID.Text);
                data_this.romno = int.Parse(comboBox_Rooms.SelectedValue.ToString());
                data_this.tm1 = textBox_Time.Text;
                if (RadioBox_AllowAM.Checked)
                {
                    data_this.vAmPm = "AM";
                }
                else
                {
                    data_this.vAmPm = "PM";
                }
                data_this.day = textBox_DayCount.Text;
                data_this.nm = textBox_NameA.Text;
                if (VarGeneral.CheckDate(dateTimeInput_BirthDate.Text))
                {
                    data_this.bdt = dateTimeInput_BirthDate.Text;
                }
                else
                {
                    data_this.bdt = "";
                }
                if (comboBox_BirthPlace.SelectedIndex > 0)
                {
                    data_this.bpls = comboBox_BirthPlace.SelectedValue.ToString();
                }
                else
                {
                    data_this.bpls = null;
                }
                data_this.pasno = textBox_ID_No.Text;
                if (comboBox_ID_From.SelectedIndex > 0)
                {
                    data_this.paspls = comboBox_ID_From.SelectedValue.ToString();
                }
                else
                {
                    data_this.paspls = null;
                }
                if (VarGeneral.CheckDate(dateTimeInput_ID_Date.Text))
                {
                    data_this.passt = dateTimeInput_ID_Date.Text;
                }
                else
                {
                    data_this.passt = "";
                }
                if (VarGeneral.CheckDate(dateTimeInput_ID_DateEnd.Text))
                {
                    data_this.pasend = dateTimeInput_ID_DateEnd.Text;
                }
                else
                {
                    data_this.pasend = "";
                }
                data_this.enddt = textBox_Mobile.Text;
                data_this.jobpls = textBox_Note.Text;
                if (comboBox_Religion.SelectedIndex > 0)
                {
                    data_this.vip = int.Parse(comboBox_Religion.SelectedValue.ToString());
                }
                else
                {
                    data_this.vip = null;
                }
                data_this.ser = Text_11.Value;
                data_this.tax = Text_12.Value;
                data_this.price = textBox_RoomPrice.Value;
                data_this.DayImport = textBox_DayRequest.Value;
                data_this.dt4 = CDat;
                data_this.KindPer = comboBox_RoomTyp.SelectedIndex;
                if (!data_this.DayOfM.HasValue && comboBox_RoomTyp.SelectedIndex == 1)
                {
                    data_this.DayOfM = VarGeneral.GDayM;
                }
                if (comboBox_DisType.SelectedIndex > 0)
                {
                    data_this.dis = Textbox_DiscountVal.Value;
                }
                else
                {
                    data_this.dis = 0.0;
                }
                if (R1 == 1)
                {
                    data_this.dt1 = textBox_Date.Text;
                }
                else if (R1 == 2 || R1 == 4)
                {
                    data_this.dt2 = textBox_Date.Text;
                }
                data_this.ch = R1;
                if (!string.IsNullOrEmpty(txtCustNo.Text))
                {
                    data_this.Cust_no = txtCustNo.Text;
                }
                else
                {
                    data_this.Cust_no = null;
                }
                if (comboBox_Nationality.SelectedIndex > 0)
                {
                    data_this.nath = int.Parse(comboBox_Nationality.SelectedValue.ToString());
                }
                else
                {
                    data_this.nath = null;
                }
                if (CmbIDTyp.SelectedIndex >= 0)
                {
                    data_this.pastyp = int.Parse(CmbIDTyp.SelectedValue.ToString());
                }
                else
                {
                    data_this.pastyp = null;
                }
                if (comboBox_Job.SelectedIndex > 0)
                {
                    data_this.job = int.Parse(comboBox_Job.SelectedValue.ToString());
                }
                else
                {
                    data_this.job = null;
                }
                try
                {
                    data_this.curr = int.Parse(comboBox_Curr.SelectedValue.ToString());
                }
                catch
                {
                    data_this.curr = null;
                }
                data_this.disknd = comboBox_DisType.SelectedIndex;
                data_this.distyp = comboBox_DisTo.SelectedIndex;
                try
                {
                    if (checkBox_Credit.Checked)
                    {
                        data_this.cc = 1;
                    }
                    else
                    {
                        data_this.cc = 0;
                    }
                }
                catch
                {
                    data_this.cc = 0;
                }
                data_this.fat = 0.0;
                SvFamily();
            }
            else if (M == 2)
            {
                db.ExecuteCommand("DELETE FROM [T_per1] WHERE perno=" + textBox_ID.Text);
                SvFamily();
                data_this.fat = 0.0;
                data_this.day = textBox_DayCount.Text;
                data_this.nm = textBox_NameA.Text;
                if (VarGeneral.CheckDate(dateTimeInput_BirthDate.Text))
                {
                    data_this.bdt = dateTimeInput_BirthDate.Text;
                }
                else
                {
                    data_this.bdt = "";
                }
                if (comboBox_BirthPlace.SelectedIndex > 0)
                {
                    data_this.bpls = comboBox_BirthPlace.SelectedValue.ToString();
                }
                else
                {
                    data_this.bpls = "0";
                }
                data_this.pasno = textBox_ID_No.Text;
                if (comboBox_ID_From.SelectedIndex > 0)
                {
                    data_this.paspls = comboBox_ID_From.SelectedValue.ToString();
                }
                else
                {
                    data_this.paspls = "0";
                }
                data_this.passt = dateTimeInput_ID_Date.Text;
                data_this.pasend = dateTimeInput_ID_DateEnd.Text;
                data_this.enddt = textBox_Mobile.Text;
                data_this.jobpls = textBox_Note.Text;
                if (comboBox_Religion.SelectedIndex > 0)
                {
                    data_this.vip = int.Parse(comboBox_Religion.SelectedValue.ToString());
                }
                else
                {
                    data_this.vip = null;
                }
                data_this.ser = Text_11.Value;
                data_this.tax = Text_12.Value;
                data_this.price = textBox_RoomPrice.Value;
                data_this.DayImport = textBox_DayRequest.Value;
                data_this.dt4 = CDat;
                data_this.KindPer = comboBox_RoomTyp.SelectedIndex;
                if (!data_this.DayOfM.HasValue && comboBox_RoomTyp.SelectedIndex == 1)
                {
                    data_this.DayOfM = VarGeneral.GDayM;
                }
                if (comboBox_RoomTyp.SelectedIndex == 0)
                {
                    data_this.DayOfM = null;
                }
                if (comboBox_DisType.SelectedIndex > 0)
                {
                    data_this.dis = Textbox_DiscountVal.Value;
                }
                else
                {
                    data_this.dis = 0.0;
                }
                aa = textBox_Date.Text;
                if (db.StockRoom(data_this.romno.Value).state == 2)
                {
                    data_this.dt1 = textBox_Date.Text;
                }
                else if (db.StockRoom(data_this.romno.Value).state == 3)
                {
                    data_this.dt2 = textBox_Date.Text;
                }
                data_this.ch = R1;
                if (!string.IsNullOrEmpty(txtCustNo.Text))
                {
                    data_this.Cust_no = txtCustNo.Text;
                }
                else
                {
                    data_this.Cust_no = null;
                }
                if (comboBox_Nationality.SelectedIndex > 0)
                {
                    data_this.nath = int.Parse(comboBox_Nationality.SelectedValue.ToString());
                }
                else
                {
                    data_this.nath = null;
                }
                if (CmbIDTyp.SelectedIndex >= 0)
                {
                    data_this.pastyp = int.Parse(CmbIDTyp.SelectedValue.ToString());
                }
                else
                {
                    data_this.pastyp = null;
                }
                if (comboBox_Job.SelectedIndex > 0)
                {
                    data_this.job = int.Parse(comboBox_Job.SelectedValue.ToString());
                }
                else
                {
                    data_this.job = null;
                }
                if (comboBox_Curr.SelectedIndex > 0)
                {
                    data_this.curr = int.Parse(comboBox_Curr.SelectedValue.ToString());
                }
                else
                {
                    data_this.curr = null;
                }
                data_this.disknd = comboBox_DisType.SelectedIndex;
                data_this.distyp = comboBox_DisTo.SelectedIndex;
                try
                {
                    if (checkBox_Credit.Checked)
                    {
                        data_this.cc = 1;
                    }
                    else
                    {
                        data_this.cc = 0;
                    }
                }
                catch
                {
                    data_this.cc = 0;
                }
                data_this.tm1 = textBox_Time.Text;
                if (RadioBox_AllowAM.Checked)
                {
                    data_this.vAmPm = "AM";
                }
                else
                {
                    data_this.vAmPm = "PM";
                }
            }
            return data_this;
        }
        private void Sv()
        {
            if (R1 == 1)
            {
                db.ExecuteCommand("UPDATE [dbo].[T_Rom] SET [state] = 2,[perno] = " + textBox_ID.Text + ",[price] = " + textBox_RoomPrice.Value + ",[hed] = 1,[tax] = " + Text_12.Value + ",[ser] = " + Text_11.Value + ",[dt] = '" + textBox_Date.Text + "',[tm] = '" + textBox_Time.Text + (RadioBox_AllowAM.Checked ? " AM" : " PM") + "'  WHERE [romno] =" + comboBox_Rooms.SelectedValue.ToString());
            }
            else if ((R1 == 2 || R1 == 4) && M == 0)
            {
                db.ExecuteCommand("UPDATE [dbo].[T_Rom] SET [state] = 3,[perno] = " + textBox_ID.Text + ",[price] = " + textBox_RoomPrice.Value + ",[hed] = 1,[tax] = " + Text_12.Value + ",[ser] = " + Text_11.Value + ",[dt] = '" + textBox_Date.Text + "',[tm] = '" + textBox_Time.Text + (RadioBox_AllowAM.Checked ? " AM" : " PM") + "'  WHERE [romno] =" + comboBox_Rooms.SelectedValue.ToString());
            }
            else if ((R1 == 2 || R1 == 4) && M == 2)
            {
                db.ExecuteCommand("UPDATE [dbo].[T_Rom] SET [state] = 3,[perno] = " + textBox_ID.Text + ",[price] = " + textBox_RoomPrice.Value + ",[tax] = " + Text_12.Value + ",[ser] = " + Text_11.Value + ",[dt] = '" + textBox_Date.Text + "',[tm] = '" + textBox_Time.Text + (RadioBox_AllowAM.Checked ? " AM" : " PM") + "'  WHERE [romno] =" + comboBox_Rooms.SelectedValue.ToString());
            }
            else if (R1 == 0 && M == 2)
            {
                db.ExecuteCommand("UPDATE [dbo].[T_Rom] SET [dt] = '" + textBox_Date.Text + "'  WHERE [romno] =" + comboBox_Rooms.SelectedValue.ToString());
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
                M = 2;
                if (textBox_RoomStat.Text == "مشغولة" || textBox_RoomStat.Text == "Busy")
                {
                    R1 = 2;
                }
                else if (textBox_RoomStat.Text == "محجوزة" || textBox_RoomStat.Text == "Reserved")
                {
                    R1 = 1;
                }
                SetReadOnly = false;
            }
        }
        private void Button_Add_Click(object sender, EventArgs e)
        {
            if (!Button_Add.Visible)
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
                MaskedTextBox maskedTextBox = textBox_Date;
                int? calendr = VarGeneral.Settings_Sys.Calendr;
                maskedTextBox.Text = ((calendr.Value == 0 && calendr.HasValue) ? n.FormatGreg(VarGeneral.Gdate, "yyyy/MM/dd") : n.FormatHijri(VarGeneral.Hdate, "yyyy/MM/dd"));
                textBox_Time.Text = DateTime.Now.ToString("hh:mm:ss");
                if (DateTime.Now.ToString("hh:mm:ss tt").ToString().ToUpper()
                    .Contains("AM"))
                {
                    RadioBox_AllowAM.Checked = true;
                }
                else
                {
                    RadioBox_AllowPM.Checked = true;
                }
                GetInvSetting();
                textBox_ID.Text = db.MaxPerNo.ToString();
                if (VarGeneral._hotelper == 0)
                {
                    comboBox_Rooms.SelectedValue = R2;
                    comboBox_RoomTyp.SelectedIndex = 0;
                    if (!string.IsNullOrEmpty(VarGeneral.Settings_Sys.GuestAcc))
                    {
                        int Value = 0;
                        List<T_AccDef> q = (from t in db.T_AccDefs
                                            where t.ParAcc == VarGeneral.Settings_Sys.GuestAcc
                                            orderby t.AccDef_ID
                                            select t).ToList();
                        if (q.Count == 0)
                        {
                            txtCustNo.Text = VarGeneral.Settings_Sys.GuestAcc + "001";
                        }
                        else
                        {
                            _AccDefBind = q[q.Count - 1];
                            string _Zero = "";
                            for (int iiCnt = 0; iiCnt < _AccDefBind.AccDef_No.Substring(_AccDefBind.ParAcc.Length).Length && _AccDefBind.AccDef_No.Substring(_AccDefBind.ParAcc.Length).Substring(iiCnt, 1) == "0"; iiCnt++)
                            {
                                _Zero += _AccDefBind.AccDef_No.Substring(_AccDefBind.ParAcc.Length).Substring(iiCnt, 1);
                            }
                            Value = int.Parse(_AccDefBind.AccDef_No.Substring(_AccDefBind.ParAcc.Length)) + 1;
                            if (!string.IsNullOrEmpty(_Zero))
                            {
                                txtCustNo.Text = _AccDefBind.ParAcc + _Zero + Value;
                            }
                            else
                            {
                                txtCustNo.Text = _AccDefBind.ParAcc + Value;
                            }
                        }
                    }
                    if (R1 == 4)
                    {
                        textBox_RoomPrice.Value = ((permission.RepAcc5 == "0") ? db.StockRoom(VarGeneral._hotelrom).pri0.Value : db.StockRoom(VarGeneral._hotelrom).pri1.Value);
                        textBox_NameA.Text = VarGeneral.Tmp2;
                        textBox_NameE.Text = VarGeneral.Tmp2;
                        textBox_ID_No.Text = VarGeneral.Tmp3;
                        textBox_DayRequest.Text = VarGeneral.Tmp7;
                        label11.Text = ((LangArEn == 0) ? "تاريخ الحجز :" : "booking date");
                        Mm = 1;
                    }
                }
                State = FormState.New;
                textBox_NameA.Focus();
            }
        }
        private void GetInvSetting()
        {
            _InvSetting = new T_INVSETTING();
            _SysSetting = new T_SYSSETTING();
            _InvSetting = db.StockInvSetting( VarGeneral.InvTyp);
            _SysSetting = db.SystemSettingStock();
            _Company = db.StockCompanyList().FirstOrDefault();
        }
        private bool ValidData()
        {
            if (!Button_Save.Visible)
            {
                return false;
            }
            if (State == FormState.Edit && !CanEdit)
            {
                MessageBox.Show((LangArEn == 0) ? "لا يمكن اتمام هذه العملية .. الرجاء مراجعة صلاحيات المستخدمين !" : "Can not complete this process .. please see the powers of the users!", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }
            if (State == FormState.New && !Button_Add.Visible)
            {
                MessageBox.Show((LangArEn == 0) ? "لا يمكن اتمام هذه العملية .. الرجاء مراجعة صلاحيات المستخدمين !" : "Can not complete this process .. please see the powers of the users!", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }
            if (textBox_ID.Text == "0" || textBox_ID.Text == "")
            {
                MessageBox.Show((LangArEn == 0) ? "لا يمكن الحفظ بدون رقم النزيل" : "Can not save without Ghoust No", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                textBox_ID.Focus();
                return false;
            }
            if (textBox_NameA.Text == "")
            {
                MessageBox.Show((LangArEn == 0) ? "لايمكن ان يكون الإسم فارغا\u0651" : "Can not be name is empty", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                textBox_NameA.Focus();
                return false;
            }
            if (textBox_NameE.Text == "")
            {
                MessageBox.Show((LangArEn == 0) ? "لايمكن ان يكون الإسم فارغا\u0651" : "Can not be name is empty", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                textBox_NameE.Focus();
                return false;
            }
            if (textBox_ID_No.Text == "")
            {
                MessageBox.Show((LangArEn == 0) ? "لايمكن ان يكون رقم الهوية فارغا\u0651" : "Can not be ID No is empty", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                textBox_ID_No.Focus();
                return false;
            }
            List<T_BlackList> q = db.T_BlackLists.Where((T_BlackList t) => t.IdNo == textBox_ID_No.Text).ToList();
            if (q.Count > 0)
            {
                MessageBox.Show((LangArEn == 0) ? "لا يمكن الحفظ .. هذا النزيل ضمن قائمة النزلاء المحظورين" : "Can not save .. This download is blacklisted", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                textBox_ID_No.Focus();
                return false;
            }
            if (comboBox_Rooms.Text == "")
            {
                MessageBox.Show((LangArEn == 0) ? "لايمكن ان يكون رقم الغرفة فارغا\u0651" : "Can not be Room No is empty", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                comboBox_Rooms.Focus();
                return false;
            }
            if (!VarGeneral.CheckTime(textBox_Time.Text))
            {
                MessageBox.Show((LangArEn == 0) ? "تأكد من صحة الوقت" : "Make sure the time is correct", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                textBox_Time.Focus();
                return false;
            }
            if (txtCustNo.Text == "")
            {
                MessageBox.Show((LangArEn == 0) ? "لا يمكن الحفظ بدون رقم حساب النزيل" : "Can not save without the customer's account number.", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                txtCustNo.Focus();
                return false;
            }
            if (!VarGeneral.CheckDate(textBox_Date.Text))
            {
                MaskedTextBox maskedTextBox = textBox_Date;
                int? calendr = VarGeneral.Settings_Sys.Calendr;
                maskedTextBox.Text = ((calendr.Value == 0 && calendr.HasValue) ? n.FormatGreg(VarGeneral.Gdate, "yyyy/MM/dd") : n.FormatHijri(VarGeneral.Hdate, "yyyy/MM/dd"));
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
                            string dtAction = (n.IsHijri(textBox_Date.Text) ? textBox_Date.Text : n.GregToHijri(textBox_Date.Text, "yyyy/MM/dd"));
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
        private void Button_Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidData())
                {
                    return;
                }
                textBox_NameA.Focus();
                if (State == FormState.New)
                {
                    GetData();
                    if (bb != 1)
                    {
                        if (!string.IsNullOrEmpty(txtCustNo.Text))
                        {
                            T_AccDef c = db.StockAccDefWithOutBalance(txtCustNo.Text);
                            if (c == null || c.AccDef_ID == 0)
                            {
                                if (!string.IsNullOrEmpty(VarGeneral.Settings_Sys.GuestAcc))
                                {
                                    int Value = 0;
                                    List<T_AccDef> q = (from t in db.T_AccDefs
                                                        where t.ParAcc == VarGeneral.Settings_Sys.GuestAcc
                                                        orderby t.AccDef_ID
                                                        select t).ToList();
                                    if (q.Count == 0)
                                    {
                                        txtCustNo.Text = VarGeneral.Settings_Sys.GuestAcc + "001";
                                    }
                                    else
                                    {
                                        _AccDefBind = q[q.Count - 1];
                                        string _Zero = "";
                                        for (int iiCnt = 0; iiCnt < _AccDefBind.AccDef_No.Substring(_AccDefBind.ParAcc.Length).Length && _AccDefBind.AccDef_No.Substring(_AccDefBind.ParAcc.Length).Substring(iiCnt, 1) == "0"; iiCnt++)
                                        {
                                            _Zero += _AccDefBind.AccDef_No.Substring(_AccDefBind.ParAcc.Length).Substring(iiCnt, 1);
                                        }
                                        Value = int.Parse(_AccDefBind.AccDef_No.Substring(_AccDefBind.ParAcc.Length)) + 1;
                                        if (!string.IsNullOrEmpty(_Zero))
                                        {
                                            txtCustNo.Text = _AccDefBind.ParAcc + _Zero + Value;
                                        }
                                        else
                                        {
                                            txtCustNo.Text = _AccDefBind.ParAcc + Value;
                                        }
                                    }
                                }
                                if (string.IsNullOrEmpty(txtCustNo.Text))
                                {
                                    MessageBox.Show((LangArEn == 0) ? "لا يمكن الحفظ بدون رقم حساب النزيل" : "Can not save without the customer's account number.", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                    txtCustNo.Focus();
                                    return;
                                }
                                data_this.Cust_no = txtCustNo.Text;
                                db.ExecuteCommand("INSERT [dbo].[T_AccDef] ([AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [DepreciationPercent], [ProofAcc], [RelayAcc],[MaxDisCust],[vColNum1],[vColNum2],[vColStr1],[vColStr2],[vColStr3]) VALUES (N'" + txtCustNo.Text + "', N'" + textBox_NameA.Text + "', N'" + textBox_NameE.Text + "', N'" + VarGeneral.Settings_Sys.GuestAcc + "', 4, NULL, 11, 0, 0, 0, 0, 0, 3, NULL, NULL, NULL, NULL, NULL, '" + textBox_Mobile.Text + "', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL,0,0,0,'','','')");
                            }
                            else
                            {
                                data_this.Cust_no = txtCustNo.Text;
                            }
                        }
                        try
                        {
                            db.T_pers.InsertOnSubmit(data_this);
                            db.SubmitChanges();
                        }
                        catch (SqlException ex4)
                        {
                            int max = 0;
                            max = db.MaxPerNo;
                            if (ex4.Number != 2627)
                            {
                                return;
                            }
                            MessageBox.Show("رقم الوحدة مستخدم من قبل.\n سيتم الحفظ برقم جديد [" + max + "]", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Question);
                            textBox_ID.Text = string.Concat(max);
                            data_this.perno = max;
                            Button_Save_Click(sender, e);
                        }
                        catch (Exception)
                        {
                            return;
                        }
                        if ((R1 == 1 || R1 == 2 || R1 == 4) && M != 2)
                        {
                            Sv();
                            T_romtrn dataThis_RomTrn = new T_romtrn();
                            dataThis_RomTrn.ID = db.MaxRomTrnNo;
                            dataThis_RomTrn.romno1 = data_this.romno.Value;
                            dataThis_RomTrn.romno2 = null;
                            dataThis_RomTrn.perno = data_this.perno;
                            int? calendr = VarGeneral.Settings_Sys.Calendr;
                            dataThis_RomTrn.dt = ((calendr.Value == 0 && calendr.HasValue) ? VarGeneral.Gdate : VarGeneral.Hdate);
                            dataThis_RomTrn.tm = DateTime.Now.ToString("hh:mm:ss tt");
                            dataThis_RomTrn.Usr = VarGeneral.UserNumber;
                            dataThis_RomTrn.typ = R1;
                            dataThis_RomTrn.UsrNam = ((LangArEn == 0) ? VarGeneral.UserNameA : VarGeneral.UserNameE);
                            db.T_romtrns.InsertOnSubmit(dataThis_RomTrn);
                            db.SubmitChanges();
                        }
                        goto IL_0750;
                    }
                }
                else
                {
                    if (State != FormState.Edit)
                    {
                        goto IL_0750;
                    }
                    GetData();
                    if (bb != 1)
                    {
                        try
                        {
                            db.ExecuteCommand("update [dbo].[T_AccDef] Set [Mobile] = '" + textBox_Mobile.Text + "' , [Arb_Des] = '" + textBox_NameA.Text + "' , [Eng_Des] = '" + textBox_NameE.Text + "' where AccDef_No = '" + txtCustNo.Text + "'");
                            db.Log = VarGeneral.DebugLog;
                            db.SubmitChanges(ConflictMode.ContinueOnConflict);
                        }
                        catch (SqlException)
                        {
                            return;
                        }
                        catch (Exception)
                        {
                            return;
                        }
                        if (M == 2)
                        {
                            Sv();
                        }
                        goto IL_0750;
                    }
                }
                goto end_IL_0001;
            IL_0750:
                if (VarGeneral.vGuestData == 1)
                {
                    if (State == FormState.New && !string.IsNullOrEmpty(textBox_Mobile.Text) && MessageBox.Show((LangArEn == 0) ? "هل تريد ارسال رسالة نصية .. للعميل ؟" : "Do you want to send a text message to the customer?", VarGeneral.ProdectNam, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        buttonItem_SendSms_Click(sender, e);
                    }
                    Close();
                }
                else
                {
                    State = FormState.Saved;
                    RefreshPKeys();
                    TextBox_Index.TextBox.Text = string.Concat(PKeys.IndexOf(string.Concat(data_this.perno)) + 1);
                    SetReadOnly = true;
                }
            end_IL_0001:;
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Save:", error, enable: true);
                MessageBox.Show(error.Message);
            }
            Button_Close_Click(sender, e);
        }
        private void DGV_Main_DataBindingComplete(object sender, GridDataBindingCompleteEventArgs e)
        {
            GridPanel panel = e.GridPanel;
            string dataMember = panel.DataMember;
            if (dataMember != null && dataMember == "T_per")
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
            panel.Columns["perno"].Width = 200;
            panel.Columns["perno"].Visible = columns_Names_visible["perno"].IfDefault;
            panel.Columns["nmA"].Width = 250;
            panel.Columns["nmA"].Visible = columns_Names_visible["nmA"].IfDefault;
            panel.Columns["nmE"].Width = 250;
            panel.Columns["nmE"].Visible = columns_Names_visible["nmE"].IfDefault;
            panel.Columns["price"].Width = 200;
            panel.Columns["price"].Visible = columns_Names_visible["price"].IfDefault;
            panel.Columns["day"].Width = 200;
            panel.Columns["day"].Visible = columns_Names_visible["day"].IfDefault;
            panel.ReadOnly = true;
        }
        private void DGV_MainGetCellStyle(object sender, GridGetCellStyleEventArgs e)
        {
        }
        private void Button_ExportTable2_Click(object sender, EventArgs e)
        {
            try
            {
                ExportExcel.ExportToExcel(DGV_Main, "تقرير بيانات النزلاء");
            }
            catch
            {
            }
        }
        private void textBox_ID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (e.KeyChar != '\b'))
            {
                e.Handled = true;
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
                _RepShow.Tables = " T_per left join T_SYSSETTING on T_SYSSETTING.SYSSETTING_ID = T_per.CompanyID ";
                string Fields = "";
                Fields = " T_per.perno as No, T_per.nm as NmA, T_per.Eng_Des as NmE,T_SYSSETTING.LogImg ";
                _RepShow.Rule = "";
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
                    frm.Repvalue = "RepGuestDataPer_1";
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
            catch (Exception ex2)
            {
                MessageBox.Show(ex2.Message);
            }
        }
        private void textBox_Date_Leave(object sender, EventArgs e)
        {
            try
            {
                if (VarGeneral.CheckDate(textBox_Date.Text))
                {
                    textBox_Date.Text = Convert.ToDateTime(textBox_Date.Text).ToString("yyyy/MM/dd");
                    return;
                }
                MaskedTextBox maskedTextBox = textBox_Date;
                int? calendr = VarGeneral.Settings_Sys.Calendr;
                maskedTextBox.Text = ((calendr.Value == 0 && calendr.HasValue) ? n.FormatGreg(VarGeneral.Gdate, "yyyy/MM/dd") : n.FormatHijri(VarGeneral.Hdate, "yyyy/MM/dd"));
            }
            catch
            {
                MaskedTextBox maskedTextBox2 = textBox_Date;
                int? calendr = VarGeneral.Settings_Sys.Calendr;
                maskedTextBox2.Text = ((calendr.Value == 0 && calendr.HasValue) ? n.FormatGreg(VarGeneral.Gdate, "yyyy/MM/dd") : n.FormatHijri(VarGeneral.Hdate, "yyyy/MM/dd"));
            }
        }
        private void textBox_Date_Click(object sender, EventArgs e)
        {
            textBox_Date.SelectAll();
        }
        private void textBox_Time_Click(object sender, EventArgs e)
        {
            textBox_Time.SelectAll();
        }
        private void textBox_Time_Leave(object sender, EventArgs e)
        {
            try
            {
                if (VarGeneral.CheckTime(textBox_Time.Text))
                {
                    textBox_Time.Text = TimeSpan.Parse(textBox_Time.Text).ToString();
                }
                else
                {
                    textBox_Time.Text = DateTime.Now.ToString("hh:mm:ss");
                }
            }
            catch
            {
                textBox_Time.Text = DateTime.Now.ToString("hh:mm:ss");
            }
            try
            {
                if (int.Parse(textBox_Time.Text.Substring(0, 2)) > 12 || textBox_Time.Text.Substring(0, 2) == "00")
                {
                    if (textBox_Time.Text.Substring(0, 2) == "13")
                    {
                        textBox_Time.Text = "01" + textBox_Time.Text.Remove(0, 2);
                    }
                    else if (textBox_Time.Text.Substring(0, 2) == "14")
                    {
                        textBox_Time.Text = "02" + textBox_Time.Text.Remove(0, 2);
                    }
                    else if (textBox_Time.Text.Substring(0, 2) == "15")
                    {
                        textBox_Time.Text = "03" + textBox_Time.Text.Remove(0, 2);
                    }
                    else if (textBox_Time.Text.Substring(0, 2) == "16")
                    {
                        textBox_Time.Text = "04" + textBox_Time.Text.Remove(0, 2);
                    }
                    else if (textBox_Time.Text.Substring(0, 2) == "17")
                    {
                        textBox_Time.Text = "05" + textBox_Time.Text.Remove(0, 2);
                    }
                    else if (textBox_Time.Text.Substring(0, 2) == "18")
                    {
                        textBox_Time.Text = "06" + textBox_Time.Text.Remove(0, 2);
                    }
                    else if (textBox_Time.Text.Substring(0, 2) == "19")
                    {
                        textBox_Time.Text = "07" + textBox_Time.Text.Remove(0, 2);
                    }
                    else if (textBox_Time.Text.Substring(0, 2) == "20")
                    {
                        textBox_Time.Text = "08" + textBox_Time.Text.Remove(0, 2);
                    }
                    else if (textBox_Time.Text.Substring(0, 2) == "21")
                    {
                        textBox_Time.Text = "09" + textBox_Time.Text.Remove(0, 2);
                    }
                    else if (textBox_Time.Text.Substring(0, 2) == "22")
                    {
                        textBox_Time.Text = "10" + textBox_Time.Text.Remove(0, 2);
                    }
                    else if (textBox_Time.Text.Substring(0, 2) == "23")
                    {
                        textBox_Time.Text = "11" + textBox_Time.Text.Remove(0, 2);
                    }
                    else if (textBox_Time.Text.Substring(0, 2) == "00")
                    {
                        textBox_Time.Text = "12" + textBox_Time.Text.Remove(0, 2);
                    }
                }
            }
            catch
            {
            }
        }
        private void comboBox_DisType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_DisType.SelectedIndex <= 0)
            {
                Textbox_DiscountVal.Enabled = false;
                Textbox_DiscountVal.Value = 0.0;
            }
            else
            {
                Textbox_DiscountVal.Enabled = true;
            }
        }
        private void dateTimeInput_BirthDate_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_BirthDate.Text = Convert.ToDateTime(dateTimeInput_BirthDate.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_BirthDate.Text = "";
            }
        }
        private void dateTimeInput_BirthDate_Click(object sender, EventArgs e)
        {
            dateTimeInput_BirthDate.SelectAll();
        }
        private void dateTimeInput_ID_Date_Click(object sender, EventArgs e)
        {
            dateTimeInput_ID_Date.SelectAll();
        }
        private void dateTimeInput_ID_Date_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_ID_Date.Text = Convert.ToDateTime(dateTimeInput_ID_Date.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_ID_Date.Text = "";
            }
        }
        private void dateTimeInput_ID_DateEnd_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_ID_DateEnd.Text = Convert.ToDateTime(dateTimeInput_ID_DateEnd.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_ID_DateEnd.Text = "";
            }
        }
        private void dateTimeInput_ID_DateEnd_Click(object sender, EventArgs e)
        {
            dateTimeInput_ID_DateEnd.SelectAll();
        }
        private void comboBox_Rooms_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (State == FormState.Saved)
                {
                    return;
                }
                T_Rom Q = db.StockRoom(int.Parse(comboBox_Rooms.SelectedValue.ToString()));
                if (Q != null && Q.romno != 0)
                {
                    if (Q.state.Value == 0)
                    {
                        textBox_RoomStat.Text = ((LangArEn == 0) ? "صيانة" : "Repair");
                    }
                    if (Q.state.Value == 1)
                    {
                        textBox_RoomStat.Text = ((LangArEn == 0) ? "فارغة" : "Empty");
                    }
                    if (Q.state.Value == 2)
                    {
                        textBox_RoomStat.Text = ((LangArEn == 0) ? "نظافة" : "Cleaning");
                    }
                    if (Q.state.Value == 3)
                    {
                        textBox_RoomStat.Text = ((LangArEn == 0) ? "مشغولة" : "Busy");
                    }
                }
            }
            catch
            {
            }
        }
        private void comboBox_RoomTyp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_RoomTyp.SelectedIndex == 0)
            {
                buttonItem_EditDays.Visible = false;
            }
            else
            {
                buttonItem_EditDays.Visible = true;
            }
        }
        private void button_ClearPic_Click(object sender, EventArgs e)
        {
            try
            {
                if (State != FormState.New)
                {
                    Button_Edit_Click(null, null);
                }
                PicItemImg.Image = null;
            }
            catch
            {
            }
        }
        private void button_EnterImg_Click(object sender, EventArgs e)
        {
            try
            {
                if (State != FormState.New)
                {
                    Button_Edit_Click(null, null);
                }
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
                    PicItemImg.Image = Image.FromFile(mypic_path);
                    Bitmap OriginalBM = new Bitmap(newSize: new Size(88, 100), original: PicItemImg.Image);
                    PicItemImg.Image = OriginalBM;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void dateTimeInput_BirthDate1_Click(object sender, EventArgs e)
        {
            dateTimeInput_BirthDate1.SelectAll();
        }
        private void dateTimeInput_BirthDate2_Click(object sender, EventArgs e)
        {
            dateTimeInput_BirthDate2.SelectAll();
        }
        private void dateTimeInput_BirthDate3_Click(object sender, EventArgs e)
        {
            dateTimeInput_BirthDate3.SelectAll();
        }
        private void dateTimeInput_BirthDate4_Click(object sender, EventArgs e)
        {
            dateTimeInput_BirthDate4.SelectAll();
        }
        private void dateTimeInput_BirthDate5_Click(object sender, EventArgs e)
        {
            dateTimeInput_BirthDate5.SelectAll();
        }
        private void dateTimeInput_BirthDate6_Click(object sender, EventArgs e)
        {
            dateTimeInput_BirthDate6.SelectAll();
        }
        private void dateTimeInput_BirthDate7_Click(object sender, EventArgs e)
        {
            dateTimeInput_BirthDate7.SelectAll();
        }
        private void dateTimeInput_BirthDate8_Click(object sender, EventArgs e)
        {
            dateTimeInput_BirthDate8.SelectAll();
        }
        private void dateTimeInput_BirthDate9_Click(object sender, EventArgs e)
        {
            dateTimeInput_BirthDate9.SelectAll();
        }
        private void dateTimeInput_BirthDate10_Click(object sender, EventArgs e)
        {
            dateTimeInput_BirthDate10.SelectAll();
        }
        private void dateTimeInput_BirthDate1_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_BirthDate1.Text = Convert.ToDateTime(dateTimeInput_BirthDate1.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_BirthDate1.Text = "";
            }
        }
        private void dateTimeInput_BirthDate2_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_BirthDate2.Text = Convert.ToDateTime(dateTimeInput_BirthDate2.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_BirthDate2.Text = "";
            }
        }
        private void dateTimeInput_BirthDate3_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_BirthDate3.Text = Convert.ToDateTime(dateTimeInput_BirthDate3.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_BirthDate3.Text = "";
            }
        }
        private void dateTimeInput_BirthDate4_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_BirthDate4.Text = Convert.ToDateTime(dateTimeInput_BirthDate4.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_BirthDate4.Text = "";
            }
        }
        private void dateTimeInput_BirthDate5_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_BirthDate5.Text = Convert.ToDateTime(dateTimeInput_BirthDate5.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_BirthDate5.Text = "";
            }
        }
        private void dateTimeInput_BirthDate6_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_BirthDate6.Text = Convert.ToDateTime(dateTimeInput_BirthDate6.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_BirthDate6.Text = "";
            }
        }
        private void dateTimeInput_BirthDate7_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_BirthDate7.Text = Convert.ToDateTime(dateTimeInput_BirthDate7.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_BirthDate7.Text = "";
            }
        }
        private void dateTimeInput_BirthDate8_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_BirthDate8.Text = Convert.ToDateTime(dateTimeInput_BirthDate8.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_BirthDate8.Text = "";
            }
        }
        private void dateTimeInput_BirthDate9_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_BirthDate9.Text = Convert.ToDateTime(dateTimeInput_BirthDate9.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_BirthDate9.Text = "";
            }
        }
        private void dateTimeInput_BirthDate10_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_BirthDate10.Text = Convert.ToDateTime(dateTimeInput_BirthDate10.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_BirthDate10.Text = "";
            }
        }
        private void dateTimeInput_PassportDateStart1_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_PassportDateStart1.Text = Convert.ToDateTime(dateTimeInput_PassportDateStart1.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_PassportDateStart1.Text = "";
            }
        }
        private void dateTimeInput_PassportDateStart2_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_PassportDateStart2.Text = Convert.ToDateTime(dateTimeInput_PassportDateStart2.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_PassportDateStart2.Text = "";
            }
        }
        private void dateTimeInput_PassportDateStart3_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_PassportDateStart3.Text = Convert.ToDateTime(dateTimeInput_PassportDateStart3.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_PassportDateStart3.Text = "";
            }
        }
        private void dateTimeInput_PassportDateStart4_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_PassportDateStart4.Text = Convert.ToDateTime(dateTimeInput_PassportDateStart4.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_PassportDateStart4.Text = "";
            }
        }
        private void dateTimeInput_PassportDateStart5_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_PassportDateStart5.Text = Convert.ToDateTime(dateTimeInput_PassportDateStart5.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_PassportDateStart5.Text = "";
            }
        }
        private void dateTimeInput_PassportDateStart6_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_PassportDateStart6.Text = Convert.ToDateTime(dateTimeInput_PassportDateStart6.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_PassportDateStart6.Text = "";
            }
        }
        private void dateTimeInput_PassportDateStart7_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_PassportDateStart7.Text = Convert.ToDateTime(dateTimeInput_PassportDateStart7.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_PassportDateStart7.Text = "";
            }
        }
        private void dateTimeInput_PassportDateStart8_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_PassportDateStart8.Text = Convert.ToDateTime(dateTimeInput_PassportDateStart8.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_PassportDateStart8.Text = "";
            }
        }
        private void dateTimeInput_PassportDateStart9_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_PassportDateStart9.Text = Convert.ToDateTime(dateTimeInput_PassportDateStart9.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_PassportDateStart9.Text = "";
            }
        }
        private void dateTimeInput_PassportDateStart10_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_PassportDateStart10.Text = Convert.ToDateTime(dateTimeInput_PassportDateStart10.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_PassportDateStart10.Text = "";
            }
        }
        private void dateTimeInput_PassportDateStart1_Click(object sender, EventArgs e)
        {
            dateTimeInput_PassportDateStart1.SelectAll();
        }
        private void dateTimeInput_PassportDateStart2_Click(object sender, EventArgs e)
        {
            dateTimeInput_PassportDateStart2.SelectAll();
        }
        private void dateTimeInput_PassportDateStart3_Click(object sender, EventArgs e)
        {
            dateTimeInput_PassportDateStart3.SelectAll();
        }
        private void dateTimeInput_PassportDateStart4_Click(object sender, EventArgs e)
        {
            dateTimeInput_PassportDateStart4.SelectAll();
        }
        private void dateTimeInput_PassportDateStart5_Click(object sender, EventArgs e)
        {
            dateTimeInput_PassportDateStart5.SelectAll();
        }
        private void dateTimeInput_PassportDateStart6_Click(object sender, EventArgs e)
        {
            dateTimeInput_PassportDateStart6.SelectAll();
        }
        private void dateTimeInput_PassportDateStart7_Click(object sender, EventArgs e)
        {
            dateTimeInput_PassportDateStart7.SelectAll();
        }
        private void dateTimeInput_PassportDateStart8_Click(object sender, EventArgs e)
        {
            dateTimeInput_PassportDateStart8.SelectAll();
        }
        private void dateTimeInput_PassportDateStart9_Click(object sender, EventArgs e)
        {
            dateTimeInput_PassportDateStart9.SelectAll();
        }
        private void dateTimeInput_PassportDateStart10_Click(object sender, EventArgs e)
        {
            dateTimeInput_PassportDateStart10.SelectAll();
        }
        private void dateTimeInput_PassportDateEnd1_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_PassportDateEnd1.Text = Convert.ToDateTime(dateTimeInput_PassportDateEnd1.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_PassportDateEnd1.Text = "";
            }
        }
        private void dateTimeInput_PassportDateEnd2_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_PassportDateEnd2.Text = Convert.ToDateTime(dateTimeInput_PassportDateEnd2.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_PassportDateEnd2.Text = "";
            }
        }
        private void dateTimeInput_PassportDateEnd3_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_PassportDateEnd3.Text = Convert.ToDateTime(dateTimeInput_PassportDateEnd3.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_PassportDateEnd3.Text = "";
            }
        }
        private void dateTimeInput_PassportDateEnd4_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_PassportDateEnd4.Text = Convert.ToDateTime(dateTimeInput_PassportDateEnd4.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_PassportDateEnd4.Text = "";
            }
        }
        private void dateTimeInput_PassportDateEnd5_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_PassportDateEnd5.Text = Convert.ToDateTime(dateTimeInput_PassportDateEnd5.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_PassportDateEnd5.Text = "";
            }
        }
        private void dateTimeInput_PassportDateEnd6_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_PassportDateEnd6.Text = Convert.ToDateTime(dateTimeInput_PassportDateEnd6.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_PassportDateEnd6.Text = "";
            }
        }
        private void dateTimeInput_PassportDateEnd7_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_PassportDateEnd7.Text = Convert.ToDateTime(dateTimeInput_PassportDateEnd7.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_PassportDateEnd7.Text = "";
            }
        }
        private void dateTimeInput_PassportDateEnd8_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_PassportDateEnd8.Text = Convert.ToDateTime(dateTimeInput_PassportDateEnd8.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_PassportDateEnd8.Text = "";
            }
        }
        private void dateTimeInput_PassportDateEnd9_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_PassportDateEnd9.Text = Convert.ToDateTime(dateTimeInput_PassportDateEnd9.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_PassportDateEnd9.Text = "";
            }
        }
        private void dateTimeInput_PassportDateEnd10_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_PassportDateEnd10.Text = Convert.ToDateTime(dateTimeInput_PassportDateEnd10.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_PassportDateEnd10.Text = "";
            }
        }
        private void dateTimeInput_PassportDateEnd1_Click(object sender, EventArgs e)
        {
            dateTimeInput_PassportDateEnd1.SelectAll();
        }
        private void dateTimeInput_PassportDateEnd2_Click(object sender, EventArgs e)
        {
            dateTimeInput_PassportDateEnd2.SelectAll();
        }
        private void dateTimeInput_PassportDateEnd3_Click(object sender, EventArgs e)
        {
            dateTimeInput_PassportDateEnd3.SelectAll();
        }
        private void dateTimeInput_PassportDateEnd4_Click(object sender, EventArgs e)
        {
            dateTimeInput_PassportDateEnd4.SelectAll();
        }
        private void dateTimeInput_PassportDateEnd5_Click(object sender, EventArgs e)
        {
            dateTimeInput_PassportDateEnd5.SelectAll();
        }
        private void dateTimeInput_PassportDateEnd6_Click(object sender, EventArgs e)
        {
            dateTimeInput_PassportDateEnd6.SelectAll();
        }
        private void dateTimeInput_PassportDateEnd7_Click(object sender, EventArgs e)
        {
            dateTimeInput_PassportDateEnd7.SelectAll();
        }
        private void dateTimeInput_PassportDateEnd8_Click(object sender, EventArgs e)
        {
            dateTimeInput_PassportDateEnd8.SelectAll();
        }
        private void dateTimeInput_PassportDateEnd9_Click(object sender, EventArgs e)
        {
            dateTimeInput_PassportDateEnd9.SelectAll();
        }
        private void dateTimeInput_PassportDateEnd10_Click(object sender, EventArgs e)
        {
            dateTimeInput_PassportDateEnd10.SelectAll();
        }
        private void textBox_Name1_Click(object sender, EventArgs e)
        {
            textBox_Name1.SelectAll();
        }
        private void textBox_Name2_Click(object sender, EventArgs e)
        {
            textBox_Name2.SelectAll();
        }
        private void textBox_Name3_Click(object sender, EventArgs e)
        {
            textBox_Name3.SelectAll();
        }
        private void textBox_Name4_Click(object sender, EventArgs e)
        {
            textBox_Name4.SelectAll();
        }
        private void textBox_Name5_Click(object sender, EventArgs e)
        {
            textBox_Name5.SelectAll();
        }
        private void textBox_Name6_Click(object sender, EventArgs e)
        {
            textBox_Name6.SelectAll();
        }
        private void textBox_Name7_Click(object sender, EventArgs e)
        {
            textBox_Name7.SelectAll();
        }
        private void textBox_Name8_Click(object sender, EventArgs e)
        {
            textBox_Name8.SelectAll();
        }
        private void textBox_Name9_Click(object sender, EventArgs e)
        {
            textBox_Name9.SelectAll();
        }
        private void textBox_Name10_Click(object sender, EventArgs e)
        {
            textBox_Name10.SelectAll();
        }
        private void textBox_PassporntNo1_Click(object sender, EventArgs e)
        {
            textBox_PassporntNo1.SelectAll();
        }
        private void textBox_PassporntNo2_Click(object sender, EventArgs e)
        {
            textBox_PassporntNo2.SelectAll();
        }
        private void textBox_PassporntNo3_Click(object sender, EventArgs e)
        {
            textBox_PassporntNo3.SelectAll();
        }
        private void textBox_PassporntNo4_Click(object sender, EventArgs e)
        {
            textBox_PassporntNo4.SelectAll();
        }
        private void textBox_PassporntNo5_Click(object sender, EventArgs e)
        {
            textBox_PassporntNo5.SelectAll();
        }
        private void textBox_PassporntNo6_Click(object sender, EventArgs e)
        {
            textBox_PassporntNo6.SelectAll();
        }
        private void textBox_PassporntNo7_Click(object sender, EventArgs e)
        {
            textBox_PassporntNo7.SelectAll();
        }
        private void textBox_PassporntNo8_Click(object sender, EventArgs e)
        {
            textBox_PassporntNo8.SelectAll();
        }
        private void textBox_PassporntNo9_Click(object sender, EventArgs e)
        {
            textBox_PassporntNo9.SelectAll();
        }
        private void textBox_PassporntNo10_Click(object sender, EventArgs e)
        {
            textBox_PassporntNo10.SelectAll();
        }
        private void buttonItem_GuestMove_Click(object sender, EventArgs e)
        {
            if (State != 0 || string.IsNullOrEmpty(textBox_ID.Text))
            {
                return;
            }
            string MyTime = VarGeneral.Settings_Sys.vStart + " " + VarGeneral.Settings_Sys.vStartTyp;
            string MyTime2 = VarGeneral.Settings_Sys.vEnd + " " + VarGeneral.Settings_Sys.vEndTyp;
            if (Convert.ToDateTime(DateTime.Now.ToString("HH:mm:ss tt")).TimeOfDay >= Convert.ToDateTime(Convert.ToDateTime(MyTime).ToString("HH:mm:ss tt")).TimeOfDay && Convert.ToDateTime(DateTime.Now.ToString("HH:mm:ss tt")).TimeOfDay <= Convert.ToDateTime(Convert.ToDateTime(MyTime2).ToString("HH:mm:ss tt")).TimeOfDay)
            {
                VarGeneral.RomNum = int.Parse(comboBox_Rooms.SelectedValue.ToString());
                VarGeneral.TotPer = TextBox_Remming.Value;
                FrmGuestMove frm = new FrmGuestMove(TextBox_TotalAm.Value, textBox_DayCount.Value);
                frm.Tag = LangArEn;
                frm.TopMost = true;
                frm.ShowDialog();
                if (VarGeneral.ChkMove == 1)
                {
                    Close();
                }
            }
            else
            {
                MessageBox.Show((LangArEn == 0) ? " يجب ان يتم عملية نقل الساكن بين فترة السماح و المغادرة" : "The transfer of residence must take place between the grace period and the departure", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
        private void buttonItem_ChangeRoomPrice_Click(object sender, EventArgs e)
        {
            if (State != 0 || string.IsNullOrEmpty(textBox_ID.Text))
            {
                return;
            }
            string MyTime = VarGeneral.Settings_Sys.vStart + " " + VarGeneral.Settings_Sys.vStartTyp;
            string MyTime2 = VarGeneral.Settings_Sys.vEnd + " " + VarGeneral.Settings_Sys.vEndTyp;
            if (Convert.ToDateTime(DateTime.Now.ToString("HH:mm:ss tt")).TimeOfDay >= Convert.ToDateTime(Convert.ToDateTime(MyTime).ToString("HH:mm:ss tt")).TimeOfDay && Convert.ToDateTime(DateTime.Now.ToString("HH:mm:ss tt")).TimeOfDay <= Convert.ToDateTime(Convert.ToDateTime(MyTime2).ToString("HH:mm:ss tt")).TimeOfDay)
            {
                VarGeneral.RomNum = int.Parse(comboBox_Rooms.SelectedValue.ToString());
                VarGeneral.TotPer = TextBox_Remming.Value;
                if (data_this.DayOfM.HasValue)
                {
                    VarGeneral.GDayM = data_this.DayOfM.Value;
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
                VarGeneral.Dy2(db.StockRoom(data_this.romno.Value).dt, db.StockRoom(data_this.romno.Value).tm);
                VarGeneral.Ft = VarGeneral.CS;
                FrmGuestChPri frm = new FrmGuestChPri(textBox_DayCount.Value, textBox_RoomPrice.Value, TextBox_TotalAm.Value);
                frm.Tag = LangArEn;
                frm.TopMost = true;
                frm.ShowDialog();
                if (VarGeneral.ChkMove == 1)
                {
                    Close();
                }
            }
            else
            {
                MessageBox.Show((LangArEn == 0) ? " يجب ان يتم عملية نقل الساكن بين فترة السماح و المغادرة" : "The transfer of residence must take place between the grace period and the departure", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
        private void buttonItem_AddRoom_Click(object sender, EventArgs e)
        {
            if (State == FormState.Saved && !string.IsNullOrEmpty(textBox_ID.Text))
            {
                FrmGuestAddRoom frm = new FrmGuestAddRoom();
                frm.Tag = LangArEn;
                frm.TopMost = true;
                frm.ShowDialog();
                if (VarGeneral.ChkAddRoom == 1)
                {
                    Close();
                }
            }
        }
        private void buttonItem_ChangeRoomType_Click(object sender, EventArgs e)
        {
            if (State != 0 || string.IsNullOrEmpty(textBox_ID.Text))
            {
                return;
            }
            T_Rom Q = db.StockRoom(int.Parse(comboBox_Rooms.SelectedValue.ToString()));
            if (Q == null || Q.romno == 0)
            {
                return;
            }
            VarGeneral.RomNum = int.Parse(comboBox_Rooms.SelectedValue.ToString());
            VarGeneral.TotPer = TextBox_Remming.Value;
            try
            {
                if (data_this.DayOfM.HasValue)
                {
                    VarGeneral.GDayM = data_this.DayOfM.Value;
                }
                else
                {
                    VarGeneral.GDayM = 0;
                }
            }
            catch
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
            VarGeneral.Dy2(Q.dt, Q.tm);
            VarGeneral.Ft = VarGeneral.CS;
            FrmKindPer frm = new FrmKindPer(textBox_DayCount.Value, textBox_RoomPrice.Value);
            frm.Tag = LangArEn;
            frm.TopMost = true;
            frm.ShowDialog();
            if (VarGeneral.ChKindMove == 1)
            {
                Close();
            }
        }
        private void up()
        {
            try
            {
                T_Rom Q = db.StockRoom(int.Parse(comboBox_Rooms.SelectedValue.ToString()));
                if (Q == null || Q.romno == 0)
                {
                    return;
                }
                if (comboBox_RoomTyp.SelectedIndex == 0)
                {
                    tmp = ((permission.RepAcc5 == "0") ? Q.pri0.Value : Q.pri1.Value);
                    textBox_DayRequest.Enabled = true;
                    textBox_DayRequest.Value = 1;
                    textBox_RoomPrice.Value = tmp;
                    if (R1 == 2 && M != 2)
                    {
                        textBox_DayCount.Value = 1;
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(Q.dt))
                        {
                            int? calendr = VarGeneral.Settings_Sys.Calendr;
                            Q.dt = ((calendr.Value == 0 && calendr.HasValue) ? n.FormatGreg(VarGeneral.Gdate, "yyyy/MM/dd") : n.FormatHijri(VarGeneral.Hdate, "yyyy/MM/dd"));
                        }
                        if (!VarGeneral.CheckTime(Q.tm))
                        {
                            Q.tm = DateTime.Now.ToString("hh:mm:ss");
                        }
                        textBox_DayCount.Value = VarGeneral.Dy(Q.dt, Q.tm);
                    }
                    Total();
                    return;
                }
                tmp = ((permission.RepAcc6 == "0") ? Q.priM0.Value : Q.priM1.Value);
                textBox_RoomPrice.Value = tmp;
                try
                {
                    if (data_this.DayOfM.HasValue)
                    {
                        VarGeneral.GDayM = data_this.DayOfM.Value;
                    }
                    else
                    {
                        VarGeneral.GDayM = 0;
                    }
                }
                catch
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
                if (R1 == 2 && M != 2)
                {
                    textBox_DayCount.Value = 1;
                    VarGeneral.CS = 1;
                }
                else
                {
                    if (string.IsNullOrEmpty(Q.dt))
                    {
                        int? calendr = VarGeneral.Settings_Sys.Calendr;
                        Q.dt = ((calendr.Value == 0 && calendr.HasValue) ? n.FormatGreg(VarGeneral.Gdate, "yyyy/MM/dd") : n.FormatHijri(VarGeneral.Hdate, "yyyy/MM/dd"));
                    }
                    if (!VarGeneral.CheckTime(Q.tm))
                    {
                        Q.tm = DateTime.Now.ToString("hh:mm:ss");
                    }
                    textBox_DayCount.Value = VarGeneral.Dy(Q.dt, Q.tm);
                    VarGeneral.Dy2(Q.dt, Q.tm);
                }
                textBox_DayRequest.Enabled = false;
                textBox_DayRequest.Value = VarGeneral.GDayM * VarGeneral.CS;
                Total();
            }
            catch
            {
            }
        }
        private void comboBox_RoomTyp_Leave(object sender, EventArgs e)
        {
            if (State != 0)
            {
                up();
            }
        }
        private void buttonItem_EditDays_Click(object sender, EventArgs e)
        {
            if (State == FormState.Saved && !string.IsNullOrEmpty(textBox_ID.Text))
            {
                string vNewNo = InputDialog.mostrar((LangArEn == 0) ? "أدخل عدد الشهور المراد إضافته : " : "Enter the number of months to add : ", (LangArEn == 0) ? "تعديل عدد الشهور" : "Modify the number of months");
                if (!string.IsNullOrEmpty(vNewNo) && Information.IsNumeric(vNewNo))
                {
                    Button_Edit_Click(sender, e);
                    textBox_DayRequest.Value += VarGeneral.Settings_Sys.DayOfM.Value * int.Parse(vNewNo);
                    Button_Save_Click(sender, e);
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
            VarGeneral.SFrmTyp = "T_AccDef_Suppliers";
            VarGeneral.AccTyp = 11;
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != "")
            {
                txtCustNo.Text = db.StockAccDefs(int.Parse(frm.Serach_No)).AccDef_No;
                textBox_NameA.Text = db.StockAccDefs(int.Parse(frm.Serach_No)).Arb_Des;
                textBox_NameE.Text = db.StockAccDefs(int.Parse(frm.Serach_No)).Eng_Des;
                textBox_Mobile.Text = db.StockAccDefs(int.Parse(frm.Serach_No)).Mobile;
            }
            else
            {
                txtCustNo.Text = "";
            }
        }
        private void textBox_Mobile_Click(object sender, EventArgs e)
        {
            textBox_Mobile.SelectAll();
        }
        private void buttonItem_SendSms_Click(object sender, EventArgs e)
        {
            if (State == FormState.Saved && !string.IsNullOrEmpty(textBox_ID.Text))
            {
                FrmSMS frm = new FrmSMS(textBox_Mobile.Text);
                frm.Tag = LangArEn;
                frm.TopMost = true;
                frm.ShowDialog();
            }
        }
        private void textBox_NameE_Enter(object sender, EventArgs e)
        {
            Framework.Keyboard.Language.Switch("English");
        }
        private void buttonItem_Print_Click(object sender, EventArgs e)
        {
            if (!(textBox_ID.Text != "") || State != 0)
            {
                return;
            }
            RepShow _RepShow = new RepShow();
            _RepShow.Tables = "  T_per left JOIN\r\n                                  T_per1 ON T_per.perno = T_per1.perno left JOIN\r\n                                  T_IDType ON T_per.pastyp = T_IDType.IDType_ID left JOIN\r\n                                  T_Job ON T_per.job = T_Job.Job_No left JOIN\r\n                                  T_Nationalities ON T_per.nath = T_Nationalities.Nation_No left JOIN\r\n                                  T_BirthPlace ON T_per.bpls = T_BirthPlace.BirthPlaceNo left JOIN\r\n                                  T_AccDef ON T_per.Cust_no = T_AccDef.AccDef_No left JOIN\r\n                                  T_Religion ON T_per.vip = T_Religion.Religion_No left JOIN\r\n                                  T_City ON T_per.paspls = T_City.City_No ";
            string Fields = "  T_per.perno, T_per.romno, T_per.nm,T_Nationalities.NameA as nathA,T_Nationalities.NameE as nathE, T_per.day, T_per.dt1, T_per.price, T_per.pasno, T_per.dt2, T_per.dt3, T_per.ch, T_per.dis, T_per.actyp, T_per.ps1, T_per.ps2, T_per.cc, T_IDType.Arb_Des as pastypA, T_IDType.Eng_Des as pastypE, T_per.tm1, T_per.tm2, T_per.tax, T_per.ser, T_per.DOL, T_per.vip,T_Job.NameA as jobA,T_Job.NameE as jobE, T_per.curr, T_per.distyp, T_per.cust, T_per.disknd, T_per.jobpls, T_per.bdt,\r\n                                T_BirthPlace.NameA as bplsA,T_Religion.NameA as vip,T_BirthPlace.NameE as bplsE,T_City.NameA as pasplsA,T_City.NameE as pasplsE, T_per.passt, T_per.pasend, T_per.enddt, T_per.pict, T_per.fat, T_per.gropno, T_per.Cust_no, T_per.Totel, T_per.DayEdit, T_per.DayImport, T_per.dt4, T_per.KindPer, T_per.DayOfM, T_per.vAmPm,T_AccDef.AccDef_No , T_AccDef.Arb_Des as AccDefNm, T_AccDef.Eng_Des as AccDefNmE ,(select LogImg from T_SYSSETTING where T_SYSSETTING.SYSSETTING_ID = 1) as LogImg,T_per1.nm as a,T_per1.bpls as b,T_per1.pasno as c,T_per1.passt as d,T_per1.pasend as e";
            _RepShow.Rule = "  Where T_per.ch=2 and T_per.perno = " + data_this.perno + " order by T_per.perno";
            _RepShow.Fields = Fields;
            try
            {
                _RepShow = _RepShow.Save();
                VarGeneral.RepData = _RepShow.RepData;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                frm.Repvalue = "RepGuestDataPer_1";
                frm.Tag = LangArEn;
                frm.Repvalue = "RepGuestDataPer_1";
                VarGeneral.vTitle = Text;
                frm.TopMost = true;
                frm.ShowDialog();
                VarGeneral.IsGeneralUsed = false;
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("buttonItem_RepGuestsData_Click:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void textBox_ID_No_Click(object sender, EventArgs e)
        {
            textBox_ID.SelectAll();
        }
        private void buttonItem_RepAcc_Click(object sender, EventArgs e)
        {
            if (State == FormState.Saved && !string.IsNullOrEmpty(textBox_ID.Text))
            {
                FrmRepRevenue frm = new FrmRepRevenue(13);
                frm.Tag = LangArEn;
                frm.Text = buttonItem_RepAcc.Text;
                frm.FillCombo();
                frm.SerTypeCount += db.FillServTyp_2("").ToList().Count;
                frm.txtUserNo.Text = data_this.perno.ToString();
                frm.ButOk_Click(sender, e);
            }
        }
        private void FrmGuests_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                VarGeneral.Tmp6 = "";
            }
            catch
            {
            }
        }
    }
}
