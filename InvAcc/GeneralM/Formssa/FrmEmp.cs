using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.DotNetBar.SuperGrid;
using DevComponents.DotNetBar.SuperGrid.Style;
using DevComponents.Editors;
using InputKey;
using InvAcc.GeneralM;
using InvAcc.Stock_Data;
//using InvAcc.Reports;
using Microsoft.VisualBasic;
//using Microsoft.VisualBasic.FileIO;
using SSSDateTime.Date;
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
    public partial class FrmEmp : Form
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
        private Dictionary<string, ColumnDictinary> Dir_ButSearch = new Dictionary<string, ColumnDictinary>();
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
        private T_Emp data_this;
        private T_Family DataThis_Family;
        private T_Attend Data_this_Attend;
        private BindingList<T_Attend> Update_Attend;
        private Rate_DataDataContext dbInstanceRate;
        private T_User permission = new T_User();
        public Dictionary<string, ColumnDictinary> columns_Names_visible2 = new Dictionary<string, ColumnDictinary>();
        private IContainer components = null;
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (!keyData.ToString().Contains("Control") && !keyData.ToString().ToLower().Contains("delete") && keyData.ToString().Contains("Alt"))
            {
                try
                {
                    VarGeneral.Print_set_Gen_Stat = true;
                    FrmReportsViewer.IsSettingOnly = true;
                    VarGeneral.IsGeneralUsed = true;

                    {

                        FrmReportsViewer frm = new FrmReportsViewer();
                        frm.Repvalue = "EmpsRepShort";


                        frm.Repvalue = "EmpsRepShort";
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
        private SaveFileDialog saveFileDialog1;
        private Timer timerInfoBallon;
        private OpenFileDialog openFileDialog1;
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
        private SuperTabControl superTabControl_Employee;
        private SuperTabControlPanel superTabControlPanel18;
        private LabelX labelX19;
        private SuperTabItem superTabItem_Acc;
        private SuperTabControlPanel superTabControlPanel17;
        private LabelX labelX18;
        private SuperTabItem superTabItem_Contract;
        private SuperTabControlPanel superTabControlPanel19;
        private LabelX labelX20;
        private SuperTabItem superTabItem_Doc;
        private SuperTabControlPanel superTabControlPanel15;
        private LabelX labelX15;
        private SuperTabItem superTabItem_Gen;
        private RibbonBar ribbonBar_Tasks;
        private SuperTabControl superTabControl_Main1;
        protected ButtonItem Button_Close;
        protected ButtonItem Button_Search;
        protected ButtonItem Button_Delete;
        protected ButtonItem Button_Save;
        protected ButtonItem Button_Add;
        protected LabelItem labelItem2;
        private SuperTabControl superTabControl_Main2;
        protected LabelItem labelItem1;
        protected ButtonItem Button_First;
        protected ButtonItem Button_Prev;
        protected TextBoxItem TextBox_Index;
        protected LabelItem Label_Count;
        protected ButtonItem Button_Next;
        protected ButtonItem Button_Last;
        private ExpandableSplitter expandableSplitter1;
        private PanelEx panelEx3;
        protected SuperGridControl DGV_Main;
        private RibbonBar ribbonBar_DGV;
        private SuperTabControl superTabControl_DGV;
        protected TextBoxItem textBox_search;
        protected ButtonItem Button_ExportTable2;
        protected ButtonItem Button_PrintTable;
        protected LabelItem labelItem3;
        private Panel panel1;
        private PanelEx panelEx1;
        private GroupBox groupBox1;
        private TextBoxX textBox_SocialInsuranceNo;
        private Panel panel2;
        private TextBox textBox_ExperiencesA;
        private Label label127;
        private ComboBoxEx comboBox_BloodTyp;
        private ComboBoxEx comboBox_BirthPlace;
        private Label label133;
        private TextBox textBox_Email;
        private Label label125;
        private TextBox textBox_Tel;
        private Label label124;
        private ComboBoxEx comboBox_CityNo;
        private Label label9;
        private ButtonX button_AddNewCity;
        private ButtonX button_SrchCities;
        private TextBox textBox_AddressA;
        private Label label126;
        private ComboBoxEx comboBox_Sex;
        private ComboBoxEx comboBox_MaritalStatus;
        private ComboBoxEx comboBox_Religion;
        private MaskedTextBox dateTimeInput_BirthDate;
        private Label label119;
        private Label label118;
        private Label label117;
        private Label label115;
        private Label label114;
        private Label label113;
        private ButtonX button_AddNewReligon;
        private ButtonX button_SrchReligon;
        private TextBox textBox_QualificationA;
        private ButtonX button_PhotoShoot;
        private LabelX labelX1;
        private ButtonX checkBox_ClearPic;
        private ButtonX button_Pic;
        private ComboBoxEx comboBox_Nationalty;
        private ButtonX button_AddNewNation;
        private ButtonX button_SrchNation;
        private Label label5;
        private ComboBoxEx comboBox_Guarantor;
        private ButtonX button_AddNewSponser;
        private ButtonX button_SrchGuartor;
        private Label label4;
        private ComboBoxEx comboBox_Job;
        private ButtonX button_AddNewJob;
        private ButtonX button_SrchJob;
        private Label label3;
        private ComboBoxEx comboBox_Section;
        private ButtonX button_AddNewSection;
        private ButtonX button_SrchSection;
        private Label label2;
        private ComboBoxEx comboBox_Dept;
        private ButtonX button_AddNewDept;
        private ButtonX button_SrchDept;
        private Label label12;
        private TextBox textBox_Pass;
        private Label label52;
        private Label label40;
        private Label label36;
        private Label label38;
        private GroupBox groupBox2;
        protected Label label1;
        protected Label label6;
        protected Label label7;
        protected Label label8;
        private DoubleInput textBox_CompPaying;
        private DoubleInput textBox_SalSubtract;
        private PanelEx panelEx4;
        private Label label11;
        private ComboBoxEx comboBox_ContrTyp;
        private DoubleInput textBox_HousingAllowance;
        private DoubleInput textBox_TransferAllowance;
        private DoubleInput textBox_NaturalWorkAllowance;
        private DoubleInput textBox_OtherAllowance;
        private DoubleInput textBox_MainSal;
        private Label label130;
        private Panel panel4;
        private DoubleInput textBox_InsuranceMedicalCom;
        private DoubleInput textBox_SocialInsuranceComp;
        private Label label80;
        private Label label78;
        private Label label79;
        private Label label74;
        private Label label75;
        private Label label76;
        private Label label73;
        private Label label72;
        private Label label70;
        private DoubleInput textBox_SubsistenceAllowance;
        private Line line1;
        private ComboBoxEx comboBox_Allowances;
        private ComboBoxEx comboBox_AllowancesTime;
        private Panel panel3;
        private MaskedTextBox dateTimeInput_LastFilter;
        private MaskedTextBox dateTimeInput_DateAppointment;
        private Label label56;
        private Label label53;
        private ComboBoxEx comboBox_DirBoss;
        private ButtonX button_AddNewBoss;
        private ButtonX button_SrchBoss;
        private Label label10;
        private IntegerInput textBox_DayOfMonth;
        private CheckBox checkBox_AutoReturnContr;
        private GroupBox groupBox4;
        private MaskedTextBox dateTimeInput_StartContr;
        private Label label54;
        private MaskedTextBox dateTimeInput_EndContr;
        private Label label55;
        private Label label137;
        private Label label140;
        private DoubleInput textBox_WorkHours;
        private Label label60;
        private Label label59;
        private Label label57;
        private GroupBox groupBox5;
        private GroupBox groupBox6;
        private DoubleInput textBox_SocialInsurance;
        private DoubleInput textBox_InsuranceMedical;
        private DoubleInput textBox_LateHours;
        private DoubleInput textBox_DisOneDay;
        private Label label86;
        private Label label84;
        private Label label82;
        private Label label83;
        private Label label85;
        private GroupBox groupBox7;
        private DoubleInput textBox_MandateDay;
        private DoubleInput textBox_AddHours;
        private DoubleInput textBox_AddDay;
        private Label label89;
        private Label label90;
        private Label label91;
        private PanelEx panelEx5;
        private GroupBox groupBox3;
        private ExpandablePanel expandablePanel_attends;
        private ExpandablePanel expandablePanel_Sat;
        private ItemPanel itemPanel1;
        private ExpandablePanel expandablePanel_Fri;
        private ItemPanel itemPanel7;
        private ExpandablePanel expandablePanel_Thurs;
        private ItemPanel itemPanel6;
        private ExpandablePanel expandablePanel_Wen;
        private ItemPanel itemPanel5;
        private ExpandablePanel expandablePanel_Tuse;
        private ItemPanel itemPanel4;
        private ExpandablePanel expandablePanel_Mon;
        private ItemPanel itemPanel3;
        private ExpandablePanel expandablePanel_Sun;
        private ItemPanel itemPanel2;
        private GroupBox groupBox8;
        private DoubleInput textBox_TicketsCount;
        private DoubleInput textBox_TicketsBalance;
        private DoubleInput textBox_TicketsPrice;
        private Label label68;
        private Label label65;
        private Label label67;
        private DoubleInput textBox_VacationBalance;
        private Label label64;
        private GroupBox groupBox10;
        private IntegerInput textBox_VacationCount;
        private Label label62;
        private Label label63;
        private PanelEx panelEx6;
        private ComboBoxEx comboBox_ID_From;
        private ButtonX button_SrchID;
        private MaskedTextBox dateTimeInput_ID_Date;
        private MaskedTextBox dateTimeInput_ID_DateEnd;
        private TextBox textBox_ID_No;
        private Label label88;
        private Label label97;
        private Label label95;
        private Label label92;
        private Line line3;
        private ComboBoxEx comboBox_Passport_From;
        private ButtonX button_SrchPassport;
        private MaskedTextBox dateTimeInput_Pass_Date;
        private MaskedTextBox dateTimeInput_Passport_DateEnd;
        private TextBox textBox_Passport_No;
        private Label label96;
        private Label label98;
        private Label label99;
        private Label label100;
        private ComboBoxEx comboBox_Insurance_From;
        private ButtonX button_SrchInsurance;
        private Line line4;
        private MaskedTextBox dateTimeInput_Insurance_Date;
        private MaskedTextBox dateTimeInput_Insurance_DateEnd;
        private TextBox textBox_Insurance_No;
        private Label label101;
        private Label label102;
        private Label label103;
        private Label label104;
        private ComboBoxEx comboBox_License_From;
        private ButtonX button_SrchLicense;
        private Line line6;
        protected BubbleBar bubbleBar5;
        protected BubbleBarTab bubbleBarTab11;
        public BubbleButton bubbleButton5;
        private MaskedTextBox dateTimeInput_License_Date;
        private MaskedTextBox dateTimeInput_License_DateEnd;
        private TextBox textBox_License_No;
        private Label label109;
        private Label label110;
        private Label label111;
        private Label label112;
        private ComboBoxEx comboBox_Form_From;
        private ButtonX button_SrchForms;
        private Line line5;
        private MaskedTextBox dateTimeInput_Form_Date;
        private MaskedTextBox dateTimeInput_Form_DateEnd;
        private TextBox textBox_Form_No;
        private Label label105;
        private Label label106;
        private Label label107;
        private Label label108;
        protected TextBox textBox_NameE;
        protected TextBox textBox_NameA;
        protected TextBox textBox_ID;
        private LinkLabel linkLabel_ChangeEmpNo;
        private SwitchButton switchButton_SalStatus;
        private ComboBoxEx comboBox_CalculateNo;
        private TextBoxX textBox_WorkNo;
        private ButtonX button_AddNewBirthPlaces;
        private ButtonX button_SrchBirthPlaces;
        private ButtonX button_SrchReligion;
        private ButtonX button_AddNewContract;
        //private CachedRepGeneral cachedRepGeneral1;
        private ListBox listBox_ImageFiles;
        private ListBox listBox_ImageFiles2;
        private SwitchButton switchButton_AccType;
        private TextBox txtBXBankName;
        private ButtonX button_SrchBXBankNo;
        private TextBox txtBXBankNo;
        private RadioButton radioButton_SatBreakDay;
        private RadioButton radioButton_SatPeriods2;
        private RadioButton radioButton_SatPeriods1;
        private GroupPanel groupPanel1;
        private MaskedTextBox textBox_SatTimeAllow1;
        private Label label18;
        private MaskedTextBox textBox_SatTime1;
        private Label label14;
        private MaskedTextBox textBox_SatLeaveTime1;
        private Label label19;
        private GroupPanel groupPanel2;
        private MaskedTextBox textBox_SatLeaveTime2;
        private Label label20;
        private MaskedTextBox textBox_SatTimeAllow2;
        private Label label21;
        private MaskedTextBox textBox_SatTime2;
        private Label label22;
        private GroupPanel groupPanel3;
        private MaskedTextBox textBox_SunLeaveTime2;
        private Label label23;
        private MaskedTextBox textBox_SunTimeAllow2;
        private Label label24;
        private MaskedTextBox textBox_SunTime2;
        private Label label25;
        private GroupPanel groupPanel4;
        private MaskedTextBox textBox_SunLeaveTime1;
        private Label label26;
        private MaskedTextBox textBox_SunTimeAllow1;
        private Label label27;
        private MaskedTextBox textBox_SunTime1;
        private Label label28;
        private RadioButton radioButton_SunBreakDay;
        private RadioButton radioButton_SunPeriods2;
        private RadioButton radioButton_SunPeriods1;
        private GroupPanel groupPanel5;
        private MaskedTextBox textBox_MonLeaveTime2;
        private Label label29;
        private MaskedTextBox textBox_MonTimeAllow2;
        private Label label30;
        private MaskedTextBox textBox_MonTime2;
        private Label label31;
        private GroupPanel groupPanel6;
        private MaskedTextBox textBox_MonLeaveTime1;
        private Label label32;
        private MaskedTextBox textBox_MonTimeAllow1;
        private Label label33;
        private MaskedTextBox textBox_MonTime1;
        private Label label34;
        private RadioButton radioButton_MonBreakDay;
        private RadioButton radioButton_MonPeriods2;
        private RadioButton radioButton_MonPeriods1;
        private GroupPanel groupPanel11;
        private MaskedTextBox textBox_LeaveTime2;
        private Label label50;
        private MaskedTextBox textBox_FriTimeAllow2;
        private Label label51;
        private MaskedTextBox textBox_FriTime2;
        private Label label58;
        private GroupPanel groupPanel12;
        private MaskedTextBox textBox_LeaveTime1;
        private Label label61;
        private MaskedTextBox textBox_FriTimeAllow1;
        private Label label66;
        private MaskedTextBox textBox_FriTime1;
        private Label label69;
        private RadioButton radioButton_FriBreakDay;
        private RadioButton radioButton_FriPeriods2;
        private RadioButton radioButton_FriPeriods1;
        private GroupPanel groupPanel13;
        private MaskedTextBox textBox_ThurLeaveTime2;
        private Label label71;
        private MaskedTextBox textBox_ThurTimeAllow2;
        private Label label77;
        private MaskedTextBox textBox_ThurTime2;
        private Label label81;
        private GroupPanel groupPanel14;
        private MaskedTextBox textBox_ThurLeaveTime1;
        private Label label87;
        private MaskedTextBox textBox_ThurTimeAllow1;
        private Label label93;
        private MaskedTextBox textBox_ThurTime1;
        private Label label94;
        private RadioButton radioButton_ThurBreakDay;
        private RadioButton radioButton_ThurPeriods2;
        private RadioButton radioButton_ThurPeriods1;
        private GroupPanel groupPanel9;
        private MaskedTextBox textBox_WenLeaveTime2;
        private Label label44;
        private MaskedTextBox textBox_WenTimeAllow2;
        private Label label45;
        private MaskedTextBox textBox_WenTime2;
        private Label label46;
        private GroupPanel groupPanel10;
        private MaskedTextBox textBox_WenLeaveTime1;
        private Label label47;
        private MaskedTextBox textBox_WenTimeAllow1;
        private Label label48;
        private MaskedTextBox textBox_WenTime1;
        private Label label49;
        private RadioButton radioButton_WenBreakDay;
        private RadioButton radioButton_WenPeriods2;
        private RadioButton radioButton_WenPeriods1;
        private GroupPanel groupPanel7;
        private MaskedTextBox textBox_TusLeaveTime2;
        private Label label35;
        private MaskedTextBox textBox_TusTimeAllow2;
        private Label label37;
        private MaskedTextBox textBox_TusTime2;
        private Label label39;
        private GroupPanel groupPanel8;
        private MaskedTextBox textBox_TusLeaveTime1;
        private Label label41;
        private MaskedTextBox textBox_TusTimeAllow1;
        private Label label42;
        private MaskedTextBox textBox_TusTime1;
        private Label label43;
        private RadioButton radioButton_TusBreakDay;
        private RadioButton radioButton_TusPeriods2;
        private RadioButton radioButton_TusPeriods1;
        private PictureBox pictureBox_EnterPic;
        protected ButtonItem buttonItem_Back;
        private GroupBox groupBox14;
        private MaskedTextBox dateTimeInput_VisaDate;
        private TextBox textBox_VisaCountry;
        private Label label136;
        private Label label135;
        private TextBox textBox_VisaEnterNo;
        private Label label134;
        private TextBox textBox_VisaNo;
        private Label label131;
        private Line line2;
        private SuperTabControlPanel superTabControlPanel1;
        private PanelEx panelEx8;
        private SuperTabItem superTabItem_Family;
        private MaskedTextBox dateTimeInput_PassportDateEnd15;
        private MaskedTextBox dateTimeInput_PassportDateEnd14;
        private MaskedTextBox dateTimeInput_PassportDateEnd13;
        private MaskedTextBox dateTimeInput_PassportDateEnd12;
        private MaskedTextBox dateTimeInput_PassportDateEnd11;
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
        private MaskedTextBox dateTimeInput_BirthDate15;
        private MaskedTextBox dateTimeInput_BirthDate14;
        private MaskedTextBox dateTimeInput_BirthDate13;
        private MaskedTextBox dateTimeInput_BirthDate12;
        private MaskedTextBox dateTimeInput_BirthDate11;
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
        private Label label128;
        private Label label129;
        private TextBox textBox_PassporntNo15;
        private TextBox textBox_Relation15;
        private TextBox textBox_Name15;
        private TextBox textBox_PassporntNo14;
        private TextBox textBox_Relation14;
        private TextBox textBox_Name14;
        private TextBox textBox_PassporntNo13;
        private TextBox textBox_Relation13;
        private TextBox textBox_Name13;
        private TextBox textBox_PassporntNo12;
        private TextBox textBox_Relation12;
        private TextBox textBox_Name12;
        private TextBox textBox_PassporntNo11;
        private TextBox textBox_Relation11;
        private TextBox textBox_Name11;
        private TextBox textBox_PassporntNo10;
        private TextBox textBox_Relation10;
        private TextBox textBox_Name10;
        private TextBox textBox_PassporntNo9;
        private TextBox textBox_Relation9;
        private TextBox textBox_Name9;
        private TextBox textBox_PassporntNo8;
        private TextBox textBox_Relation8;
        private TextBox textBox_Name8;
        private TextBox textBox_PassporntNo7;
        private TextBox textBox_Relation7;
        private TextBox textBox_Name7;
        private TextBox textBox_PassporntNo6;
        private TextBox textBox_Relation6;
        private TextBox textBox_Name6;
        private TextBox textBox_PassporntNo5;
        private TextBox textBox_Relation5;
        private TextBox textBox_Name5;
        private TextBox textBox_PassporntNo4;
        private TextBox textBox_Relation4;
        private TextBox textBox_Name4;
        private TextBox textBox_PassporntNo3;
        private TextBox textBox_Relation3;
        private TextBox textBox_Name3;
        private TextBox textBox_PassporntNo2;
        private TextBox textBox_Relation2;
        private TextBox textBox_Name2;
        private TextBox textBox_PassporntNo1;
        private TextBox textBox_Relation1;
        private TextBox textBox_Name1;
        private Label label132;
        private ButtonX button_SaveFamily;
        private GroupBox groupBox9;
        private TextBox textBox_Insurance_Class;
        private Label label121;
        private ComboBoxEx comboBox_InsuranceType;
        private ButtonX button_InsuranceType;
        private ButtonX bubbleButton_InsuranceType;
        private Label label120;
        private TextBoxX textBox_Note;
        private ButtonItem buttonX_OpenFiles;
        private ButtonItem buttonX_BrowserScannerFiles;
        private ButtonItem buttonItem_EmpOut;
        private GroupPanel groupPanel15;
        private ButtonX button_SrchCostCenterAcc;
        private TextBox textBox_CostCenter;
        private Label label116;
        internal TextBox textBox_CostCenterName;
        private ButtonX button_SrchAdvancAcc;
        private TextBox textBox_AccLoan;
        private Label label17;
        internal TextBox textBox_AccLoanName;
        private ButtonX button_SrchHousAcc;
        private TextBox textBox_AccHousing;
        private Label label16;
        internal TextBox textBox_AccHousingName;
        private ButtonX button_SrchSalAcc;
        private TextBox textBox_AccSal;
        private Label label15;
        internal TextBox textBox_AccSalName;
        private LabelItem lable_Records;
        private ButtonX button_BankCall;
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
                buttonX_OpenFiles.Enabled = value;
                buttonX_BrowserScannerFiles.Enabled = value;
                linkLabel_ChangeEmpNo.Enabled = value;
                button_SaveFamily.Enabled = value;
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
        public T_Emp DataThis
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
        public T_Family DataThisFamily
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
        public T_Attend Datathis_Attend
        {
            get
            {
                return Data_this_Attend;
            }
            set
            {
                Data_this_Attend = value;
            }
        }
        public BindingList<T_Attend> UpdateAttend
        {
            get
            {
                return Update_Attend;
            }
            set
            {
                Update_Attend = value;
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
                    if (!VarGeneral.TString.ChkStatShow(value.Emp_FilStr, 1) || buttonItem_EmpOut.Checked)
                    {
                        IfAdd = false;
                    }
                    else
                    {
                        IfAdd = true;
                    }
                    if (!VarGeneral.TString.ChkStatShow(value.Emp_FilStr, 2) || buttonItem_EmpOut.Checked)
                    {
                        CanEdit = false;
                    }
                    else
                    {
                        CanEdit = true;
                    }
                    if (!VarGeneral.TString.ChkStatShow(value.Emp_FilStr, 3) || buttonItem_EmpOut.Checked)
                    {
                        IfDelete = false;
                    }
                    else
                    {
                        IfDelete = true;
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
            try
            {
                FrmSearch frm = new FrmSearch();
                frm.Tag = LangArEn;
                ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible;
                foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
                {
                    frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
                }
                VarGeneral.SFrmTyp = "T_Emp";
                VarGeneral.FrmEmpStat = VarGeneral.FrmEmpStat;
                frm.TopMost = true;
                frm.ShowDialog();
                if (frm.SerachNo != string.Empty)
                {
                    T_Emp q = db.EmpsEmpNo(frm.SerachNo);
                    if (!string.IsNullOrEmpty(q.Emp_ID))
                    {
                        textBox_ID.Text = q.Emp_No;
                    }
                }
            }
            catch
            {
            }
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
            List<T_Emp> list = db.FillEmps_2(textBox_search.TextBox.Text).ToList();
            if (DGV_Main.PrimaryGrid.Columns.Count == 0)
            {
                foreach (KeyValuePair<string, ColumnDictinary> item in columns_Names_visible)
                {
                    DGV_Main.PrimaryGrid.Columns.Add(new GridColumn(item.Key));
                }
            }
            FillHDGV(list);
        }
        public void FillHDGV(IEnumerable<T_Emp> new_data_enum)
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
            DGV_Main.PrimaryGrid.DataMember = "T_Emp";
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
            data_this = new T_Emp();
            Data_this_Attend = new T_Attend();
            Update_Attend = new BindingList<T_Attend>();
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
                    else if (controls[i].GetType() == typeof(SwitchButton))
                    {
                        (controls[i] as SwitchButton).Value = true;
                    }
                }
            }
            textBox_ID.Focus();
            if (State == FormState.New)
            {
                int? calendr = VarGeneral.Settings_Sys.Calendr;
                if (calendr.Value == 0 && calendr.HasValue)
                {
                    dateTimeInput_DateAppointment.Text = Convert.ToDateTime(VarGeneral.Gdate).ToString("yyyy/MM/dd");
                }
                else
                {
                    dateTimeInput_DateAppointment.Text = Convert.ToDateTime(VarGeneral.Hdate).ToString("yyyy/MM/dd");
                }
            }
            Guid id = Guid.NewGuid();
            textBox_ID.Tag = id.ToString();
            textBox_DayOfMonth.Value = 30;
            textBox_WorkHours.Value = 9.0;
            radioButton_SatPeriods1.Checked = false;
            radioButton_SatPeriods2.Checked = false;
            radioButton_SatBreakDay.Checked = false;
            radioButton_SunPeriods1.Checked = false;
            radioButton_SunPeriods2.Checked = false;
            radioButton_SunBreakDay.Checked = false;
            radioButton_MonPeriods1.Checked = false;
            radioButton_MonPeriods2.Checked = false;
            radioButton_MonBreakDay.Checked = false;
            radioButton_TusPeriods1.Checked = false;
            radioButton_TusPeriods2.Checked = false;
            radioButton_TusBreakDay.Checked = false;
            radioButton_WenPeriods1.Checked = false;
            radioButton_WenPeriods2.Checked = false;
            radioButton_WenBreakDay.Checked = false;
            radioButton_ThurPeriods1.Checked = false;
            radioButton_ThurPeriods2.Checked = false;
            radioButton_ThurBreakDay.Checked = false;
            radioButton_FriPeriods1.Checked = false;
            radioButton_FriPeriods2.Checked = false;
            radioButton_FriBreakDay.Checked = false;
            textBox_SatTime1.Text = string.Empty;
            textBox_SatTime2.Text = string.Empty;
            textBox_SatLeaveTime1.Text = string.Empty;
            textBox_SatLeaveTime2.Text = string.Empty;
            textBox_SatTimeAllow1.Text = string.Empty;
            textBox_SatTimeAllow2.Text = string.Empty;
            textBox_SunTime1.Text = string.Empty;
            textBox_SunTime2.Text = string.Empty;
            textBox_SunLeaveTime1.Text = string.Empty;
            textBox_SunLeaveTime2.Text = string.Empty;
            textBox_SunTimeAllow1.Text = string.Empty;
            textBox_SunTimeAllow2.Text = string.Empty;
            textBox_MonTime1.Text = string.Empty;
            textBox_MonTime2.Text = string.Empty;
            textBox_MonLeaveTime1.Text = string.Empty;
            textBox_MonLeaveTime2.Text = string.Empty;
            textBox_MonTimeAllow1.Text = string.Empty;
            textBox_MonTimeAllow2.Text = string.Empty;
            textBox_TusTime1.Text = string.Empty;
            textBox_TusTime2.Text = string.Empty;
            textBox_TusLeaveTime1.Text = string.Empty;
            textBox_TusLeaveTime2.Text = string.Empty;
            textBox_TusTimeAllow1.Text = string.Empty;
            textBox_TusTimeAllow2.Text = string.Empty;
            textBox_WenTime1.Text = string.Empty;
            textBox_WenTime2.Text = string.Empty;
            textBox_WenLeaveTime1.Text = string.Empty;
            textBox_WenLeaveTime2.Text = string.Empty;
            textBox_WenTimeAllow1.Text = string.Empty;
            textBox_WenTimeAllow2.Text = string.Empty;
            textBox_ThurTime1.Text = string.Empty;
            textBox_ThurTime2.Text = string.Empty;
            textBox_ThurLeaveTime1.Text = string.Empty;
            textBox_ThurLeaveTime2.Text = string.Empty;
            textBox_ThurTimeAllow1.Text = string.Empty;
            textBox_ThurTimeAllow2.Text = string.Empty;
            textBox_FriTime1.Text = string.Empty;
            textBox_FriTime2.Text = string.Empty;
            textBox_LeaveTime1.Text = string.Empty;
            textBox_LeaveTime2.Text = string.Empty;
            textBox_FriTimeAllow1.Text = string.Empty;
            textBox_FriTimeAllow2.Text = string.Empty;
            if (comboBox_CalculateNo.Items.Count > 1)
            {
                comboBox_CalculateNo.SelectedIndex = 1;
            }
            if (comboBox_Dept.Items.Count > 1)
            {
                comboBox_Dept.SelectedIndex = 1;
            }
            if (comboBox_Job.Items.Count > 1)
            {
                comboBox_Job.SelectedIndex = 1;
            }
            if (comboBox_Section.Items.Count > 1)
            {
                comboBox_Section.SelectedIndex = 1;
            }
            if (comboBox_Guarantor.Items.Count > 1)
            {
                comboBox_Guarantor.SelectedIndex = 1;
            }
            if (comboBox_ContrTyp.Items.Count > 1)
            {
                comboBox_ContrTyp.SelectedIndex = 1;
            }
            if (comboBox_Allowances.Items.Count > 0)
            {
                comboBox_Allowances.SelectedIndex = 0;
            }
            if (comboBox_AllowancesTime.Items.Count > 0)
            {
                comboBox_AllowancesTime.SelectedIndex = 0;
            }
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
            Framework.Keyboard.Language.Switch("Arabic");
        }
        private void textBox_NameE_Enter(object sender, EventArgs e)
        {
            Framework.Keyboard.Language.Switch("English");
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
            else if (e.KeyCode == Keys.F6 && buttonItem_Back.Enabled && buttonItem_Back.Visible && buttonItem_EmpOut.Checked)
            {
                buttonItem_Back_Click(sender, e);
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
        public void RefreshPKeys()
        {
            PKeys.Clear();
            try
            {
                PKeys = db.ExecuteQuery<string>("select Emp_No from T_Emp where EmpState =" + (VarGeneral.FrmEmpStat ? 1 : 0) + " order by Emp_No", new object[0]).ToList();
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
        private void ADD_Controls()
        {
            try
            {
                controls = new List<Control>();
                controls.Add(textBox_SalSubtract);
                controls.Add(textBox_CompPaying);
                controls.Add(checkBox_ClearPic);
                controls.Add(comboBox_Allowances);
                controls.Add(comboBox_AllowancesTime);
                controls.Add(textBox_ID);
                codeControl = textBox_ID;
                controls.Add(listBox_ImageFiles);
                controls.Add(textBox_NameA);
                controls.Add(textBox_AccSal);
                controls.Add(textBox_AccLoan);
                controls.Add(textBox_VisaNo);
                controls.Add(textBox_VisaEnterNo);
                controls.Add(dateTimeInput_VisaDate);
                controls.Add(textBox_VisaCountry);
                controls.Add(textBox_CostCenter);
                controls.Add(textBox_CostCenterName);
                controls.Add(textBox_AccHousing);
                controls.Add(textBox_AccSalName);
                controls.Add(textBox_AccHousingName);
                controls.Add(textBox_AccLoanName);
                controls.Add(txtBXBankNo);
                controls.Add(txtBXBankName);
                controls.Add(switchButton_AccType);
                controls.Add(switchButton_SalStatus);
                controls.Add(textBox_NameE);
                controls.Add(textBox_Note);
                controls.Add(textBox_ID_No);
                controls.Add(textBox_AddDay);
                controls.Add(textBox_AddHours);
                controls.Add(textBox_AddressA);
                controls.Add(textBox_DayOfMonth);
                controls.Add(textBox_DisOneDay);
                controls.Add(textBox_Email);
                controls.Add(textBox_ID);
                controls.Add(textBox_ExperiencesA);
                controls.Add(textBox_Form_No);
                controls.Add(textBox_HousingAllowance);
                controls.Add(textBox_ID);
                controls.Add(textBox_Insurance_No);
                controls.Add(textBox_Insurance_Class);
                controls.Add(textBox_InsuranceMedical);
                controls.Add(textBox_LateHours);
                controls.Add(textBox_License_No);
                controls.Add(textBox_MainSal);
                controls.Add(textBox_MandateDay);
                controls.Add(textBox_NaturalWorkAllowance);
                controls.Add(textBox_Note);
                controls.Add(textBox_OtherAllowance);
                controls.Add(textBox_Pass);
                controls.Add(textBox_Passport_No);
                controls.Add(textBox_QualificationA);
                controls.Add(textBox_SocialInsurance);
                controls.Add(textBox_SocialInsuranceComp);
                controls.Add(textBox_InsuranceMedicalCom);
                controls.Add(textBox_SocialInsuranceNo);
                controls.Add(textBox_WorkNo);
                controls.Add(textBox_SubsistenceAllowance);
                controls.Add(textBox_Tel);
                controls.Add(textBox_TicketsBalance);
                controls.Add(textBox_TicketsCount);
                controls.Add(textBox_TicketsPrice);
                controls.Add(textBox_TransferAllowance);
                controls.Add(textBox_VacationBalance);
                controls.Add(textBox_VacationCount);
                controls.Add(textBox_WorkHours);
                controls.Add(checkBox_AutoReturnContr);
                controls.Add(dateTimeInput_BirthDate);
                controls.Add(dateTimeInput_DateAppointment);
                controls.Add(dateTimeInput_EndContr);
                controls.Add(dateTimeInput_Form_Date);
                controls.Add(dateTimeInput_Form_DateEnd);
                controls.Add(dateTimeInput_ID_Date);
                controls.Add(dateTimeInput_ID_DateEnd);
                controls.Add(dateTimeInput_Insurance_Date);
                controls.Add(dateTimeInput_Insurance_DateEnd);
                controls.Add(dateTimeInput_LastFilter);
                controls.Add(dateTimeInput_License_Date);
                controls.Add(dateTimeInput_License_DateEnd);
                controls.Add(dateTimeInput_Pass_Date);
                controls.Add(dateTimeInput_Passport_DateEnd);
                controls.Add(dateTimeInput_StartContr);
                controls.Add(comboBox_BirthPlace);
                controls.Add(comboBox_BloodTyp);
                controls.Add(comboBox_CalculateNo);
                controls.Add(comboBox_CityNo);
                controls.Add(comboBox_ContrTyp);
                controls.Add(comboBox_Dept);
                controls.Add(comboBox_DirBoss);
                controls.Add(comboBox_Form_From);
                controls.Add(comboBox_Guarantor);
                controls.Add(comboBox_ID_From);
                controls.Add(comboBox_Insurance_From);
                controls.Add(comboBox_Job);
                controls.Add(comboBox_License_From);
                controls.Add(comboBox_MaritalStatus);
                controls.Add(comboBox_Nationalty);
                controls.Add(comboBox_Passport_From);
                controls.Add(comboBox_Religion);
                controls.Add(comboBox_Section);
                controls.Add(comboBox_Sex);
                controls.Add(pictureBox_EnterPic);
                controls.Add(comboBox_InsuranceType);
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
                controls.Add(dateTimeInput_BirthDate11);
                controls.Add(dateTimeInput_BirthDate12);
                controls.Add(dateTimeInput_BirthDate13);
                controls.Add(dateTimeInput_BirthDate14);
                controls.Add(dateTimeInput_BirthDate15);
                controls.Add(dateTimeInput_PassportDateEnd1);
                controls.Add(dateTimeInput_PassportDateEnd2);
                controls.Add(dateTimeInput_PassportDateEnd3);
                controls.Add(dateTimeInput_PassportDateEnd4);
                controls.Add(dateTimeInput_PassportDateEnd5);
                controls.Add(dateTimeInput_PassportDateEnd6);
                controls.Add(dateTimeInput_PassportDateEnd6);
                controls.Add(dateTimeInput_PassportDateEnd6);
                controls.Add(dateTimeInput_PassportDateEnd9);
                controls.Add(dateTimeInput_PassportDateEnd10);
                controls.Add(dateTimeInput_PassportDateEnd11);
                controls.Add(dateTimeInput_PassportDateEnd12);
                controls.Add(dateTimeInput_PassportDateEnd13);
                controls.Add(dateTimeInput_PassportDateEnd14);
                controls.Add(dateTimeInput_PassportDateEnd15);
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
                controls.Add(textBox_Name11);
                controls.Add(textBox_Name12);
                controls.Add(textBox_Name13);
                controls.Add(textBox_Name14);
                controls.Add(textBox_Name15);
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
                controls.Add(textBox_PassporntNo11);
                controls.Add(textBox_PassporntNo12);
                controls.Add(textBox_PassporntNo13);
                controls.Add(textBox_PassporntNo14);
                controls.Add(textBox_PassporntNo15);
                controls.Add(textBox_Relation1);
                controls.Add(textBox_Relation2);
                controls.Add(textBox_Relation3);
                controls.Add(textBox_Relation4);
                controls.Add(textBox_Relation5);
                controls.Add(textBox_Relation6);
                controls.Add(textBox_Relation7);
                controls.Add(textBox_Relation8);
                controls.Add(textBox_Relation9);
                controls.Add(textBox_Relation10);
                controls.Add(textBox_Relation11);
                controls.Add(textBox_Relation12);
                controls.Add(textBox_Relation13);
                controls.Add(textBox_Relation14);
                controls.Add(textBox_Relation15);
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("FrmEmpOn_ADD_Controls:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        public FrmEmp()
        {
            InitializeComponent();
            radioButton_FriBreakDay.Click += Button_Edit_Click;
            radioButton_FriPeriods1.Click += Button_Edit_Click;
            radioButton_FriPeriods2.Click += Button_Edit_Click;
            radioButton_MonBreakDay.Click += Button_Edit_Click;
            radioButton_MonPeriods1.Click += Button_Edit_Click;
            radioButton_MonPeriods2.Click += Button_Edit_Click;
            radioButton_SatBreakDay.Click += Button_Edit_Click;
            radioButton_SatPeriods1.Click += Button_Edit_Click;
            radioButton_SatPeriods2.Click += Button_Edit_Click;
            radioButton_SunBreakDay.Click += Button_Edit_Click;
            radioButton_SunPeriods1.Click += Button_Edit_Click;
            radioButton_SunPeriods2.Click += Button_Edit_Click;
            radioButton_ThurBreakDay.Click += Button_Edit_Click;
            radioButton_ThurPeriods1.Click += Button_Edit_Click;
            radioButton_ThurPeriods2.Click += Button_Edit_Click;
            radioButton_TusBreakDay.Click += Button_Edit_Click;
            radioButton_TusPeriods1.Click += Button_Edit_Click;
            radioButton_TusPeriods2.Click += Button_Edit_Click;
            radioButton_WenBreakDay.Click += Button_Edit_Click;
            radioButton_WenPeriods1.Click += Button_Edit_Click;
            radioButton_WenPeriods2.Click += Button_Edit_Click;
            textBox_ID_No.Click += Button_Edit_Click;
            textBox_ID.Click += Button_Edit_Click;
            textBox_NameA.Click += Button_Edit_Click;
            textBox_NameE.Click += Button_Edit_Click;
            textBox_Note.Click += Button_Edit_Click;
            textBox_AddDay.Click += Button_Edit_Click;
            textBox_AddHours.Click += Button_Edit_Click;
            textBox_AddressA.Click += Button_Edit_Click;
            textBox_DayOfMonth.Click += Button_Edit_Click;
            textBox_DisOneDay.Click += Button_Edit_Click;
            textBox_Email.Click += Button_Edit_Click;
            textBox_ExperiencesA.Click += Button_Edit_Click;
            textBox_Form_No.Click += Button_Edit_Click;
            textBox_FriTime1.Click += Button_Edit_Click;
            textBox_FriTime2.Click += Button_Edit_Click;
            textBox_FriTimeAllow1.Click += Button_Edit_Click;
            textBox_FriTimeAllow2.Click += Button_Edit_Click;
            textBox_HousingAllowance.Click += Button_Edit_Click;
            textBox_Insurance_No.Click += Button_Edit_Click;
            textBox_InsuranceMedical.Click += Button_Edit_Click;
            textBox_LateHours.Click += Button_Edit_Click;
            textBox_LeaveTime1.Click += Button_Edit_Click;
            textBox_LeaveTime2.Click += Button_Edit_Click;
            textBox_License_No.Click += Button_Edit_Click;
            textBox_MainSal.Click += Button_Edit_Click;
            textBox_MandateDay.Click += Button_Edit_Click;
            textBox_MonLeaveTime1.Click += Button_Edit_Click;
            textBox_MonLeaveTime2.Click += Button_Edit_Click;
            textBox_MonTime1.Click += Button_Edit_Click;
            textBox_MonTime2.Click += Button_Edit_Click;
            textBox_MonTimeAllow1.Click += Button_Edit_Click;
            textBox_MonTimeAllow2.Click += Button_Edit_Click;
            textBox_NaturalWorkAllowance.Click += Button_Edit_Click;
            textBox_OtherAllowance.Click += Button_Edit_Click;
            textBox_Pass.Click += Button_Edit_Click;
            textBox_Passport_No.Click += Button_Edit_Click;
            textBox_QualificationA.Click += Button_Edit_Click;
            textBox_SatLeaveTime1.Click += Button_Edit_Click;
            textBox_SatLeaveTime2.Click += Button_Edit_Click;
            textBox_SatTime1.Click += Button_Edit_Click;
            textBox_SatTime2.Click += Button_Edit_Click;
            textBox_LeaveTime1.Click += Button_Edit_Click;
            textBox_LeaveTime2.Click += Button_Edit_Click;
            textBox_SatTimeAllow1.Click += Button_Edit_Click;
            textBox_SatTimeAllow2.Click += Button_Edit_Click;
            textBox_SocialInsurance.Click += Button_Edit_Click;
            textBox_SocialInsuranceComp.Click += Button_Edit_Click;
            textBox_InsuranceMedicalCom.Click += Button_Edit_Click;
            textBox_SocialInsuranceNo.Click += Button_Edit_Click;
            textBox_WorkNo.Click += Button_Edit_Click;
            textBox_SubsistenceAllowance.Click += Button_Edit_Click;
            textBox_SunLeaveTime1.Click += Button_Edit_Click;
            textBox_SunLeaveTime2.Click += Button_Edit_Click;
            textBox_SunTime1.Click += Button_Edit_Click;
            textBox_SunTime2.Click += Button_Edit_Click;
            textBox_SunTimeAllow1.Click += Button_Edit_Click;
            textBox_SunTimeAllow2.Click += Button_Edit_Click;
            textBox_Tel.Click += Button_Edit_Click;
            textBox_ThurLeaveTime1.Click += Button_Edit_Click;
            textBox_ThurLeaveTime2.Click += Button_Edit_Click;
            textBox_ThurTime1.Click += Button_Edit_Click;
            textBox_ThurTime2.Click += Button_Edit_Click;
            textBox_ThurTimeAllow1.Click += Button_Edit_Click;
            textBox_ThurTimeAllow2.Click += Button_Edit_Click;
            textBox_TicketsBalance.Click += Button_Edit_Click;
            textBox_TicketsCount.Click += Button_Edit_Click;
            textBox_TicketsPrice.Click += Button_Edit_Click;
            textBox_TransferAllowance.Click += Button_Edit_Click;
            textBox_TusLeaveTime1.Click += Button_Edit_Click;
            textBox_TusLeaveTime2.Click += Button_Edit_Click;
            textBox_TusTimeAllow1.Click += Button_Edit_Click;
            textBox_TusTimeAllow2.Click += Button_Edit_Click;
            textBox_TusTime1.Click += Button_Edit_Click;
            textBox_TusTime2.Click += Button_Edit_Click;
            textBox_VacationBalance.Click += Button_Edit_Click;
            textBox_VacationCount.Click += Button_Edit_Click;
            textBox_WenLeaveTime1.Click += Button_Edit_Click;
            textBox_WenLeaveTime2.Click += Button_Edit_Click;
            textBox_WenTime1.Click += Button_Edit_Click;
            textBox_WenTime2.Click += Button_Edit_Click;
            textBox_WenTimeAllow1.Click += Button_Edit_Click;
            textBox_WenTimeAllow2.Click += Button_Edit_Click;
            textBox_WorkHours.Click += Button_Edit_Click;
            checkBox_AutoReturnContr.Click += Button_Edit_Click;
            comboBox_InsuranceType.Click += Button_Edit_Click;
            textBox_Insurance_Class.Click += Button_Edit_Click;
            dateTimeInput_DateAppointment.MouseDown += Button_Edit_Click;
            dateTimeInput_EndContr.MouseDown += Button_Edit_Click;
            dateTimeInput_Form_Date.MouseDown += Button_Edit_Click;
            dateTimeInput_Form_DateEnd.MouseDown += Button_Edit_Click;
            dateTimeInput_ID_Date.MouseDown += Button_Edit_Click;
            dateTimeInput_ID_DateEnd.MouseDown += Button_Edit_Click;
            dateTimeInput_Insurance_Date.MouseDown += Button_Edit_Click;
            dateTimeInput_Insurance_DateEnd.MouseDown += Button_Edit_Click;
            dateTimeInput_LastFilter.MouseDown += Button_Edit_Click;
            dateTimeInput_License_Date.MouseDown += Button_Edit_Click;
            dateTimeInput_License_DateEnd.MouseDown += Button_Edit_Click;
            dateTimeInput_Pass_Date.MouseDown += Button_Edit_Click;
            dateTimeInput_Passport_DateEnd.MouseDown += Button_Edit_Click;
            dateTimeInput_StartContr.MouseDown += Button_Edit_Click;
            comboBox_BirthPlace.Click += Button_Edit_Click;
            comboBox_BloodTyp.Click += Button_Edit_Click;
            comboBox_CalculateNo.Click += Button_Edit_Click;
            comboBox_CityNo.Click += Button_Edit_Click;
            comboBox_ContrTyp.Click += Button_Edit_Click;
            comboBox_Dept.Click += Button_Edit_Click;
            comboBox_DirBoss.Click += Button_Edit_Click;
            comboBox_Form_From.Click += Button_Edit_Click;
            comboBox_ID_From.Click += Button_Edit_Click;
            comboBox_Insurance_From.Click += Button_Edit_Click;
            comboBox_Job.Click += Button_Edit_Click;
            comboBox_License_From.Click += Button_Edit_Click;
            comboBox_MaritalStatus.Click += Button_Edit_Click;
            comboBox_Nationalty.Click += Button_Edit_Click;
            comboBox_Passport_From.Click += Button_Edit_Click;
            comboBox_Religion.Click += Button_Edit_Click;
            comboBox_Section.Click += Button_Edit_Click;
            comboBox_Sex.Click += Button_Edit_Click;
            switchButton_SalStatus.Click += Button_Edit_Click;
            switchButton_AccType.Click += Button_Edit_Click;
            button_Pic.Click += Button_Edit_Click;
            button_PhotoShoot.Click += Button_Edit_Click;
            checkBox_ClearPic.Click += Button_Edit_Click;
            textBox_AccHousing.Click += Button_Edit_Click;
            textBox_AccLoan.Click += Button_Edit_Click;
            textBox_AccSal.Click += Button_Edit_Click;
            textBox_CostCenter.Click += Button_Edit_Click;
            textBox_VisaNo.Click += Button_Edit_Click;
            textBox_VisaEnterNo.Click += Button_Edit_Click;
            dateTimeInput_VisaDate.Click += Button_Edit_Click;
            textBox_VisaCountry.Click += Button_Edit_Click;
            comboBox_Allowances.Click += Button_Edit_Click;
            comboBox_AllowancesTime.Click += Button_Edit_Click;
            Button_Close.Click += Button_Close_Click;
            Button_First.Click += Button_First_Click;
            Button_Prev.Click += Button_Prev_Click;
            Button_Next.Click += Button_Next_Click;
            Button_Last.Click += Button_Last_Click;
            Button_Add.Click += Button_Add_Click;
            textBox_ID.Click += textBox_ID_Click;
            Button_Search.Click += Button_Search_Click;
            Button_Delete.Click += Button_Delete_Click;
            Button_Save.Click += Button_Save_Click;
            textBox_search.ButtonCustomClick += TextBox_Search_ButtonCustomClick;
            TextBox_Index.InputTextChanged += TextBox_Index_InputTextChanged;
            expandableSplitter1.Click += expandableSplitter1_Click;
            ToolStripMenuItem_Det.Click += ToolStripMenuItem_Det_Click;
            Button_ExportTable2.Click += Button_ExportTable2_Click;
            textBox_search.InputTextChanged += TextBox_Search_InputTextChanged;
            DGV_Main.MouseDown += DGV_Main_MouseDown;
            DGV_Main.CellDoubleClick += DGV_Main_CellDoubleClick;
            DGV_Main.CellClick += DGV_Main_CellClick;
            DGV_Main.GetCellStyle += DGV_MainGetCellStyle;
            DGV_Main.CellDoubleClick += DGV_Main_CellDoubleClick;
            DGV_Main.DataBindingComplete += DGV_Main_DataBindingComplete;
            Button_PrintTable.Click += Button_Print_Click;
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
                Button_PrintTable.Text = ((VarGeneral.GeneralPrinter.nTyp_Setting.Substring(2, 1) == "0") ? "طباعة" : "عــرض");
                Button_PrintTable.Tooltip = "F5";
                Button_ExportTable2.Text = "تصدير";
                Button_ExportTable2.Tooltip = "F10";
                DGV_Main.PrimaryGrid.GroupByRow.Text = "جميع السجلات";
                buttonX_BrowserScannerFiles.Text = "  عرض الوثائق";
                buttonX_BrowserScannerFiles.Tooltip = "عرض وثائق وصور الموظف";
                buttonX_OpenFiles.Text = "  إضافة الوثائق";
                buttonX_OpenFiles.Tooltip = "إضافة وثائق وصور الموظف";
                superTabItem_Gen.Text = "عــــــــــام";
                superTabItem_Contract.Text = "العقــــــــد";
                superTabItem_Acc.Text = "الحسـابات";
                superTabItem_Doc.Text = "الـوثـــائق";
                superTabItem_Family.Text = "المرافقــين";
                textBox_SocialInsuranceNo.WatermarkText = "رقم التأمين الإجتماعي";
                textBox_SocialInsuranceNo.ButtonCustom.Text = "التأمين الإجتماعي  ";
                textBox_WorkNo.ButtonCustom.Text = "مكتب العمل";
                textBox_WorkNo.WatermarkText = "رقم مكتب العمل والعمال";
                button_BankCall.Tooltip = "حساب البنك";
                Text = "كرت الموظفــــــين";
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
                buttonX_BrowserScannerFiles.Text = "     Show Doc";
                buttonX_BrowserScannerFiles.Tooltip = "Show Documents and images the Employee";
                buttonX_OpenFiles.Text = "     ADD Doc";
                buttonX_OpenFiles.Tooltip = "Add Documents and images to Employee";
                superTabItem_Gen.Text = "General";
                superTabItem_Contract.Text = "Contract";
                superTabItem_Acc.Text = "Acc";
                superTabItem_Doc.Text = "Doc";
                superTabItem_Family.Text = "Facilities";
                textBox_SocialInsuranceNo.WatermarkText = "Social Security No";
                textBox_SocialInsuranceNo.ButtonCustom.Text = "Social Security  ";
                textBox_WorkNo.ButtonCustom.Text = "Labor Office";
                textBox_WorkNo.WatermarkText = "Work and office workers";
                button_BankCall.Tooltip = "Bank Account";
                Text = "Staff Card";
            }
            expandablePanel_attends.TitleText = ((LangArEn == 0) ? "أوقات الدوام" : "Working hours");
        }
        private void FrmEmp_Load(object sender, EventArgs e)
        {
            try
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmEmp));
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                {
                    SSSLanguage.Language.ChangeLanguage("ar-SA", this, resources);
                    RightToLeft = RightToLeft.Yes;
                    LangArEn = 0;
                }
                else
                {
                    SSSLanguage.Language.ChangeLanguage("en", this, resources);
                    RightToLeft = RightToLeft.Yes;
                    LangArEn = 1;
                }
                RibunButtons();
                ADD_Controls();
                buttonItem_EmpOut_CheckedChanged(sender, e);
                UpdateVcr();
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Load:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void vMain()
        {
            Permmission = dbc.Get_PermissionID(VarGeneral.UserID);
            if (columns_Names_visible.Count == 0)
            {
                columns_Names_visible.Add("Emp_No", new ColumnDictinary("رقم الموظف", "Employee No", ifDefault: true, string.Empty));
                columns_Names_visible.Add("NameA", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, string.Empty));
                columns_Names_visible.Add("NameE", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, string.Empty));
                columns_Names_visible.Add("DateAppointment", new ColumnDictinary("تاريخ التعيين", "Appointment Date", ifDefault: true, string.Empty));
                columns_Names_visible.Add("StartContr", new ColumnDictinary("بداية العقد", "Start Contract Date", ifDefault: false, string.Empty));
                columns_Names_visible.Add("EndContr", new ColumnDictinary("نهاية العقد", "End Contract Date", ifDefault: false, string.Empty));
                columns_Names_visible.Add("MainSal", new ColumnDictinary("الراتب الأساسي", "Main Salary", ifDefault: true, string.Empty));
                columns_Names_visible.Add("ID_No", new ColumnDictinary("رقم الهوية", "ID No", ifDefault: false, string.Empty));
                columns_Names_visible.Add("Passport_No", new ColumnDictinary("رقم الجواز", "Passport No", ifDefault: false, string.Empty));
                columns_Names_visible.Add("AddressA", new ColumnDictinary("العنوان", "Address", ifDefault: false, string.Empty));
                columns_Names_visible.Add("Tel", new ColumnDictinary("الجوال", "Mobile", ifDefault: false, string.Empty));
                columns_Names_visible.Add("Note", new ColumnDictinary(" الملاحظــات", "Note", ifDefault: true, string.Empty));
            }
            else
            {
                Clear();
                textBox_ID.Text = string.Empty;
                TextBox_Index.TextBox.Text = string.Empty;
            }
            FillCombo();
            RefreshPKeys();
            textBox_ID.Text = PKeys.FirstOrDefault();
            ViewDetails_Click(null, null);
            comboBox_InsuranceType_SelectedIndexChanged(null, null);
        }
        public void FillCombo()
        {
            comboBox_Allowances.Items.Clear();
            comboBox_Allowances.Items.Add("1");
            comboBox_Allowances.Items.Add("2");
            comboBox_Allowances.Items.Add("3");
            comboBox_Allowances.Items.Add("4");
            comboBox_Allowances.Items.Add("6");
            comboBox_Allowances.Items.Add("12");
            comboBox_Allowances.SelectedIndex = 0;
            comboBox_AllowancesTime.Items.Clear();
            comboBox_AllowancesTime.Items.Add((LangArEn == 0) ? "في أول المدة" : "Begining Preriod");
            comboBox_AllowancesTime.Items.Add((LangArEn == 0) ? "في آخر المدة" : "End Preriod");
            comboBox_AllowancesTime.SelectedIndex = 0;
            List<T_Job> listJob = new List<T_Job>(db.T_Jobs.Select((T_Job item) => item).ToList());
            listJob.Insert(0, new T_Job());
            comboBox_Job.DataSource = null;
            comboBox_Job.DataSource = listJob;
            comboBox_Job.DisplayMember = ((LangArEn == 0) ? "NameA" : "NameE");
            comboBox_Job.ValueMember = "Job_No";
            List<T_Dept> listDept = new List<T_Dept>(db.T_Depts.Select((T_Dept item) => item).ToList());
            listDept.Insert(0, new T_Dept());
            comboBox_Dept.DataSource = null;
            comboBox_Dept.DataSource = listDept;
            comboBox_Dept.DisplayMember = ((LangArEn == 0) ? "NameA" : "NameE");
            comboBox_Dept.ValueMember = "Dept_No";
            List<T_Section> listSection = new List<T_Section>(db.T_Sections.Select((T_Section item) => item).ToList());
            listSection.Insert(0, new T_Section());
            comboBox_Section.DataSource = null;
            comboBox_Section.DataSource = listSection;
            comboBox_Section.DisplayMember = ((LangArEn == 0) ? "NameA" : "NameE");
            comboBox_Section.ValueMember = "Section_No";
            List<T_Guarantor> listGuarantor = new List<T_Guarantor>(db.T_Guarantors.Select((T_Guarantor item) => item).ToList());
            listGuarantor.Insert(0, new T_Guarantor());
            comboBox_Guarantor.DataSource = null;
            comboBox_Guarantor.DataSource = listGuarantor;
            comboBox_Guarantor.DisplayMember = ((LangArEn == 0) ? "NameA" : "NameE");
            comboBox_Guarantor.ValueMember = "Guarantor_No";
            List<T_Sex> listSex = new List<T_Sex>(db.T_Sexes.Select((T_Sex item) => item).ToList());
            listSex.Insert(0, new T_Sex());
            comboBox_Sex.DataSource = null;
            comboBox_Sex.DataSource = listSex;
            comboBox_Sex.DisplayMember = ((LangArEn == 0) ? "NameA" : "NameE");
            comboBox_Sex.ValueMember = "SexNo";
            List<T_Religion> listReligion = new List<T_Religion>(db.T_Religions.Select((T_Religion item) => item).ToList());
            listReligion.Insert(0, new T_Religion());
            comboBox_Religion.DataSource = null;
            comboBox_Religion.DataSource = listReligion;
            comboBox_Religion.DisplayMember = ((LangArEn == 0) ? "NameA" : "NameE");
            comboBox_Religion.ValueMember = "Religion_No";
            List<T_MStatus> listMStatus = new List<T_MStatus>(db.T_MStatus.Select((T_MStatus item) => item).ToList());
            listMStatus.Insert(0, new T_MStatus());
            comboBox_MaritalStatus.DataSource = null;
            comboBox_MaritalStatus.DataSource = listMStatus;
            comboBox_MaritalStatus.DisplayMember = ((LangArEn == 0) ? "NameA" : "NameE");
            comboBox_MaritalStatus.ValueMember = "MStatusNo";
            comboBox_Nationalty.SelectedValueChanged -= comboBox_Nationalty_SelectedValueChanged;
            List<T_Nationality> listNation = new List<T_Nationality>(db.T_Nationalities.Select((T_Nationality item) => item).ToList());
            listNation.Insert(0, new T_Nationality());
            comboBox_Nationalty.DataSource = null;
            comboBox_Nationalty.DataSource = listNation;
            comboBox_Nationalty.DisplayMember = ((LangArEn == 0) ? "NameA" : "NameE");
            comboBox_Nationalty.ValueMember = "Nation_No";
            comboBox_Nationalty.SelectedValueChanged += comboBox_Nationalty_SelectedValueChanged;
            List<T_City> listCity = new List<T_City>(db.T_Cities.Select((T_City item) => item).ToList());
            listCity.Insert(0, new T_City());
            comboBox_CityNo.DataSource = null;
            comboBox_CityNo.DataSource = listCity;
            comboBox_CityNo.DisplayMember = ((LangArEn == 0) ? "NameA" : "NameE");
            comboBox_CityNo.ValueMember = "City_No";
            List<T_BirthPlace> listBirthPlace = new List<T_BirthPlace>(db.T_BirthPlaces.Select((T_BirthPlace item) => item).ToList());
            listBirthPlace.Insert(0, new T_BirthPlace());
            comboBox_BirthPlace.DataSource = null;
            comboBox_BirthPlace.DataSource = listBirthPlace;
            comboBox_BirthPlace.DisplayMember = ((LangArEn == 0) ? "NameA" : "NameE");
            comboBox_BirthPlace.ValueMember = "BirthPlaceNo";
            List<T_City> listFormFrom = new List<T_City>(db.T_Cities.Select((T_City item) => item).ToList());
            listFormFrom.Insert(0, new T_City());
            comboBox_Form_From.DataSource = null;
            comboBox_Form_From.DataSource = listFormFrom;
            comboBox_Form_From.DisplayMember = ((LangArEn == 0) ? "NameA" : "NameE");
            comboBox_Form_From.ValueMember = "City_No";
            List<T_City> listIDFrom = new List<T_City>(db.T_Cities.Select((T_City item) => item).ToList());
            listIDFrom.Insert(0, new T_City());
            comboBox_ID_From.DataSource = null;
            comboBox_ID_From.DataSource = listIDFrom;
            comboBox_ID_From.DisplayMember = ((LangArEn == 0) ? "NameA" : "NameE");
            comboBox_ID_From.ValueMember = "City_No";
            List<T_City> listInsurance = new List<T_City>(db.T_Cities.Select((T_City item) => item).ToList());
            listInsurance.Insert(0, new T_City());
            comboBox_Insurance_From.DataSource = null;
            comboBox_Insurance_From.DataSource = listInsurance;
            comboBox_Insurance_From.DisplayMember = ((LangArEn == 0) ? "NameA" : "NameE");
            comboBox_Insurance_From.ValueMember = "City_No";
            List<T_City> listLicenseFrom = new List<T_City>(db.T_Cities.Select((T_City item) => item).ToList());
            listLicenseFrom.Insert(0, new T_City());
            comboBox_License_From.DataSource = null;
            comboBox_License_From.DataSource = listLicenseFrom;
            comboBox_License_From.DisplayMember = ((LangArEn == 0) ? "NameA" : "NameE");
            comboBox_License_From.ValueMember = "City_No";
            List<T_City> listPassport = new List<T_City>(db.T_Cities.Select((T_City item) => item).ToList());
            listPassport.Insert(0, new T_City());
            comboBox_Passport_From.DataSource = null;
            comboBox_Passport_From.DataSource = listPassport;
            comboBox_Passport_From.DisplayMember = ((LangArEn == 0) ? "NameA" : "NameE");
            comboBox_Passport_From.ValueMember = "City_No";
            List<T_BloodTyp> listBlood = new List<T_BloodTyp>(db.T_BloodTyps.Select((T_BloodTyp item) => item).ToList());
            listBlood.Insert(0, new T_BloodTyp());
            comboBox_BloodTyp.DataSource = null;
            comboBox_BloodTyp.DataSource = listBlood;
            comboBox_BloodTyp.DisplayMember = ((LangArEn == 0) ? "NameA" : "NameE");
            comboBox_BloodTyp.ValueMember = "BloodTyp_No";
            comboBox_CalculateNo.SelectedValueChanged -= comboBox_CalculateNo_SelectedValueChanged;
            List<T_OpMethod> listOpMethod = new List<T_OpMethod>((from item in db.T_OpMethods
                                                                  orderby item.Method_No
                                                                  where item.Method_No != 1 && item.Method_No != 8 && item.Method_No != 9 && item.Method_No != 10 && item.Method_No != 10 && item.Method_No != 11 && item.Method_No != 12 && item.Method_No != 13
                                                                  select item).ToList());
            listOpMethod.Insert(0, new T_OpMethod());
            comboBox_CalculateNo.DataSource = null;
            comboBox_CalculateNo.DataSource = listOpMethod;
            comboBox_CalculateNo.DisplayMember = ((LangArEn == 0) ? "Name" : "NameE");
            comboBox_CalculateNo.ValueMember = "Method_No";
            comboBox_CalculateNo.SelectedValueChanged += comboBox_CalculateNo_SelectedValueChanged;
            List<T_Contract> listContract = new List<T_Contract>(db.T_Contracts.Select((T_Contract item) => item).ToList());
            listContract.Insert(0, new T_Contract());
            comboBox_ContrTyp.DataSource = null;
            comboBox_ContrTyp.DataSource = listContract;
            comboBox_ContrTyp.DisplayMember = ((LangArEn == 0) ? "NameA" : "NameE");
            comboBox_ContrTyp.ValueMember = "Contract_No";
            List<T_Insurance> listInsuranceTyp = new List<T_Insurance>(db.T_Insurances.Select((T_Insurance item) => item).ToList());
            listInsuranceTyp.Insert(0, new T_Insurance());
            comboBox_InsuranceType.DataSource = null;
            comboBox_InsuranceType.DataSource = listInsuranceTyp;
            comboBox_InsuranceType.DisplayMember = ((LangArEn == 0) ? "NameA" : "NameE");
            comboBox_InsuranceType.ValueMember = "Insurance_No";
            List<T_Boss> listBoss = new List<T_Boss>(db.T_Bosses.Select((T_Boss item) => item).ToList());
            listBoss.Insert(0, new T_Boss());
            comboBox_DirBoss.DataSource = null;
            comboBox_DirBoss.DataSource = listBoss;
            comboBox_DirBoss.DisplayMember = ((LangArEn == 0) ? "NameA" : "NameE");
            comboBox_DirBoss.ValueMember = "Boss_No";
        }
        private void comboBox_CalculateNo_SelectedValueChanged(object sender, EventArgs e)
        {
            CalcAddSub();
        }
        private void CalcAddSub()
        {
            if (comboBox_CalculateNo.SelectedIndex <= 0 || (State != FormState.Edit && State != FormState.New))
            {
                return;
            }
            try
            {
                double vHour = 0.0;
                double vDay = 0.0;
                if (textBox_DayOfMonth.Value <= 0 || !(textBox_WorkHours.Value > 0.0))
                {
                    return;
                }
                switch (comboBox_CalculateNo.SelectedIndex)
                {
                    case 1:
                        vDay = Math.Round(textBox_MainSal.Value / (double)textBox_DayOfMonth.Value, 2);
                        vHour = Math.Round(vDay / textBox_WorkHours.Value, 2);
                        break;
                    case 2:
                        if (textBox_HousingAllowance.Value > 0.0)
                        {
                            vDay = Math.Round((textBox_HousingAllowance.Value / 12.0 + textBox_MainSal.Value) / (double)textBox_DayOfMonth.Value, 2);
                            vHour = Math.Round(vDay / textBox_WorkHours.Value, 2);
                        }
                        else
                        {
                            vDay = Math.Round(textBox_MainSal.Value / (double)textBox_DayOfMonth.Value, 2);
                            vHour = Math.Round(vDay / textBox_WorkHours.Value, 2);
                        }
                        break;
                    case 3:
                        if (textBox_HousingAllowance.Value > 0.0)
                        {
                            vDay = textBox_HousingAllowance.Value / 12.0;
                        }
                        vDay += textBox_MainSal.Value;
                        vDay = vDay + textBox_TransferAllowance.Value + textBox_SubsistenceAllowance.Value + textBox_NaturalWorkAllowance.Value + textBox_OtherAllowance.Value;
                        vDay = Math.Round(vDay / (double)textBox_DayOfMonth.Value, 2);
                        vHour = Math.Round(vDay / textBox_WorkHours.Value, 2);
                        break;
                    case 4:
                        if (textBox_HousingAllowance.Value > 0.0)
                        {
                            vDay = textBox_HousingAllowance.Value / 12.0;
                        }
                        vDay += textBox_MainSal.Value;
                        vDay += textBox_TransferAllowance.Value;
                        vDay = Math.Round(vDay / (double)textBox_DayOfMonth.Value, 2);
                        vHour = Math.Round(vDay / textBox_WorkHours.Value, 2);
                        break;
                    case 5:
                        vDay = textBox_MainSal.Value;
                        vDay += textBox_SubsistenceAllowance.Value;
                        vDay = Math.Round(vDay / (double)textBox_DayOfMonth.Value, 2);
                        vHour = Math.Round(vDay / textBox_WorkHours.Value, 2);
                        break;
                    case 6:
                        vDay = textBox_MainSal.Value;
                        vDay += textBox_TransferAllowance.Value;
                        vDay = Math.Round(vDay / (double)textBox_DayOfMonth.Value, 2);
                        vHour = Math.Round(vDay / textBox_WorkHours.Value, 2);
                        break;
                }
                textBox_AddHours.Value = Math.Round(vHour, 2);
                textBox_LateHours.Value = Math.Round(textBox_AddHours.Value, 2);
                textBox_AddDay.Value = Math.Round(vDay, 2);
                textBox_DisOneDay.Value = textBox_AddDay.Value;
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("FrmEmp_CalcAddSub:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void comboBox_Nationalty_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBox_Nationalty.Items.Count > 0 && comboBox_Nationalty.SelectedIndex > 0 && (State == FormState.New || State == FormState.Edit))
                {
                    List<T_Nationality> listNationality = new List<T_Nationality>(db.T_Nationalities.Where((T_Nationality item) => item.Nation_No == int.Parse(comboBox_Nationalty.SelectedValue.ToString())).ToList());
                    if (listNationality.Count > 0)
                    {
                        textBox_SocialInsurance.Value = listNationality.FirstOrDefault().SalSubtract.Value;
                        textBox_SocialInsuranceComp.Value = listNationality.FirstOrDefault().CompPaying.Value;
                    }
                }
            }
            catch
            {
                textBox_SocialInsurance.Value = 0.0;
                textBox_SocialInsuranceComp.Value = 0.0;
            }
        }
        private void textBox_DayOfMonth_ValueChanged(object sender, EventArgs e)
        {
            if (State == FormState.New && State == FormState.Edit && textBox_DayOfMonth.Value > 0)
            {
                textBox_AddDay.Value = Math.Round(textBox_MainSal.Value / (double)textBox_DayOfMonth.Value, 2);
                textBox_DisOneDay.Value = textBox_AddDay.Value;
            }
        }
        private void textBox_WorkHours_ValueChanged(object sender, EventArgs e)
        {
            if ((State == FormState.Edit || State == FormState.New) && textBox_WorkHours.Value > 0.0)
            {
                textBox_AddHours.Value = Math.Round(textBox_AddDay.Value / textBox_WorkHours.Value, 2);
                textBox_LateHours.Value = textBox_AddHours.Value;
            }
        }
        private void textBox_TransferAllowance_KeyUp(object sender, KeyEventArgs e)
        {
            CalcAddSub();
        }
        private void textBox_HousingAllowance_KeyUp(object sender, KeyEventArgs e)
        {
            CalcAddSub();
        }
        private void textBox_MainSal_KeyUp(object sender, KeyEventArgs e)
        {
            CalcAddSub();
        }
        private void textBox_OtherAllowance_KeyUp(object sender, KeyEventArgs e)
        {
            CalcAddSub();
        }
        private void textBox_NaturalWorkAllowance_KeyUp(object sender, KeyEventArgs e)
        {
            CalcAddSub();
        }
        private void textBox_SubsistenceAllowance_KeyUp(object sender, KeyEventArgs e)
        {
            CalcAddSub();
        }
        private void textBox_AddDay_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if ((State == FormState.Edit || State == FormState.New) && textBox_WorkHours.Value > 0.0)
                {
                    textBox_AddHours.Value = Math.Round(textBox_AddDay.Value / textBox_WorkHours.Value, 2);
                }
            }
            catch
            {
            }
        }
        private void textBox_ID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                T_Emp newData = db.EmpsEmpNo(textBox_ID.Text);
                if (newData == null || string.IsNullOrEmpty(newData.Emp_ID))
                {
                    if ((!Button_Add.Visible || !Button_Add.Enabled) && !buttonItem_EmpOut.Checked)
                    {
                        MessageBox.Show((LangArEn == 0) ? "لا يمكن اتمام هذه العملية .. الرجاء مراجعة صلاحيات المستخدمين !" : "Can not complete this process .. please see the powers of the users!", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        return;
                    }
                    Clear();
                    TextBox_Index.InputTextChanged -= TextBox_Index_InputTextChanged;
                    TextBox_Index.TextBox.Text = string.Concat(PKeys.Count + 1);
                    TextBox_Index.InputTextChanged += TextBox_Index_InputTextChanged;
                    goto IL_0160;
                }
                DataThis = newData;
                int indexA = PKeys.IndexOf(newData.Emp_No ?? string.Empty);
                indexA++;
                TextBox_Index.InputTextChanged -= TextBox_Index_InputTextChanged;
                TextBox_Index.TextBox.Text = string.Concat(indexA);
                TextBox_Index.InputTextChanged += TextBox_Index_InputTextChanged;
                goto IL_0160;
                IL_0160:
                UpdateVcr();
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("textBox_ID_TextChanged:", error, enable: true);
            }
        }
        public void SetData(T_Emp value)
        {
            State = FormState.Saved;
            Button_Save.Enabled = false;
            FillCombo();
            if (value.EmpPic != null)
            {
                byte[] arr = value.EmpPic.ToArray();
                MemoryStream stream = new MemoryStream(arr);
                pictureBox_EnterPic.Image = Image.FromStream(stream);
            }
            else
            {
                pictureBox_EnterPic.Image = null;
            }
            textBox_ID.Tag = value.Emp_ID;
            textBox_Pass.Text = VarGeneral.Decrypt(value.Pass);
            textBox_NameA.Text = value.NameA;
            textBox_NameE.Text = value.NameE;
            textBox_Note.Text = value.Note;
            textBox_AddDay.Value = value.AddDay.Value;
            textBox_AddHours.Value = value.AddHours.Value;
            textBox_AddressA.Text = value.AddressA;
            textBox_DayOfMonth.Value = value.DayOfMonth.Value;
            textBox_DisOneDay.Value = value.DisOneDay.Value;
            textBox_Email.Text = value.Email;
            textBox_ExperiencesA.Text = value.ExperiencesA;
            textBox_Form_No.Text = value.Form_No;
            textBox_HousingAllowance.Value = value.HousingAllowance.Value;
            textBox_ID_No.Text = value.ID_No;
            textBox_Insurance_No.Text = value.Insurance_No;
            textBox_LateHours.Value = value.LateHours.Value;
            textBox_License_No.Text = value.License_No;
            textBox_MainSal.Value = value.MainSal.Value;
            textBox_MandateDay.Value = value.MandateDay.Value;
            textBox_NaturalWorkAllowance.Value = value.NaturalWorkAllowance.Value;
            textBox_OtherAllowance.Value = value.OtherAllowance.Value;
            textBox_Passport_No.Text = value.Passport_No;
            textBox_QualificationA.Text = value.QualificationA;
            textBox_SocialInsuranceComp.Value = value.SocialInsuranceComp.Value;
            textBox_SocialInsurance.Value = value.SocialInsurance.Value;
            textBox_InsuranceMedicalCom.Value = value.InsuranceMedicalCom.Value;
            textBox_InsuranceMedical.Value = value.InsuranceMedical.Value;
            textBox_SocialInsuranceNo.Text = value.SocialInsuranceNo;
            textBox_WorkNo.Text = value.WorkNo;
            textBox_VisaNo.Text = value.VisaNo;
            textBox_VisaEnterNo.Text = value.VisaEnterNo;
            textBox_VisaCountry.Text = value.VisaCountry;
            textBox_SubsistenceAllowance.Value = value.SubsistenceAllowance.Value;
            textBox_Tel.Text = value.Tel;
            textBox_TicketsBalance.Value = value.TicketsBalance.Value;
            textBox_TicketsCount.Value = value.TicketsCount.Value;
            textBox_TicketsPrice.Value = value.TicketsPrice.Value;
            textBox_TransferAllowance.Value = value.TransferAllowance.Value;
            textBox_VacationBalance.Value = value.VacationBalance.Value;
            textBox_VacationCount.Value = value.VacationCount.Value;
            textBox_WorkHours.Value = value.WorkHours.Value;
            checkBox_AutoReturnContr.Checked = value.AutoReturnContr.Value;
            if (value.BirthPlace.HasValue)
            {
                comboBox_BirthPlace.SelectedValue = value.BirthPlace.Value;
            }
            if (value.BloodTyp.HasValue)
            {
                comboBox_BloodTyp.SelectedValue = value.BloodTyp.Value;
            }
            if (value.CalculateNo.HasValue)
            {
                comboBox_CalculateNo.SelectedValue = value.CalculateNo.Value;
            }
            if (value.CityNo.HasValue)
            {
                comboBox_CityNo.SelectedValue = value.CityNo.Value;
            }
            if (value.ContrTyp.HasValue)
            {
                comboBox_ContrTyp.SelectedValue = value.ContrTyp.Value;
            }
            if (value.Dept.HasValue)
            {
                comboBox_Dept.SelectedValue = value.Dept.Value;
            }
            if (value.DirBoss.HasValue)
            {
                comboBox_DirBoss.SelectedValue = value.DirBoss.Value;
            }
            if (value.Form_From.HasValue)
            {
                comboBox_Form_From.SelectedValue = value.Form_From.Value;
            }
            if (value.Guarantor.HasValue)
            {
                comboBox_Guarantor.SelectedValue = value.Guarantor.Value;
            }
            if (value.ID_From.HasValue)
            {
                comboBox_ID_From.SelectedValue = value.ID_From.Value;
            }
            if (value.Insurance_From.HasValue)
            {
                comboBox_Insurance_From.SelectedValue = value.Insurance_From.Value;
            }
            if (value.Job.HasValue)
            {
                comboBox_Job.SelectedValue = value.Job.Value;
            }
            if (value.License_From.HasValue)
            {
                comboBox_License_From.SelectedValue = value.License_From.Value;
            }
            if (value.MaritalStatus.HasValue)
            {
                comboBox_MaritalStatus.SelectedValue = value.MaritalStatus.Value;
            }
            if (value.Nationalty.HasValue)
            {
                comboBox_Nationalty.SelectedValue = value.Nationalty.Value;
            }
            if (value.Passport_From.HasValue)
            {
                comboBox_Passport_From.SelectedValue = value.Passport_From.Value;
            }
            if (value.Religion.HasValue)
            {
                comboBox_Religion.SelectedValue = value.Religion.Value;
            }
            if (value.Section.HasValue)
            {
                comboBox_Section.SelectedValue = value.Section.Value;
            }
            if (value.Sex.HasValue)
            {
                comboBox_Sex.SelectedValue = value.Sex.Value;
            }
            if (value.InsuranceNo.HasValue)
            {
                comboBox_InsuranceType.SelectedValue = value.InsuranceNo.Value;
            }
            textBox_Insurance_Class.Text = value.Insurance_Name;
            if (value.StatusSal.HasValue)
            {
                if (value.StatusSal.Value == 1)
                {
                    switchButton_SalStatus.Value = true;
                }
                else
                {
                    switchButton_SalStatus.Value = false;
                }
            }
            if (value.FatherA == "1")
            {
                switchButton_AccType.Value = true;
            }
            else
            {
                switchButton_AccType.Value = false;
            }
            try
            {
                if (VarGeneral.CheckDate(value.DateAppointment))
                {
                    dateTimeInput_DateAppointment.Text = Convert.ToDateTime(value.DateAppointment).ToString("yyyy/MM/dd");
                }
                else
                {
                    dateTimeInput_DateAppointment.Text = string.Empty;
                }
            }
            catch
            {
                dateTimeInput_DateAppointment.Text = string.Empty;
            }
            try
            {
                if (VarGeneral.CheckDate(value.BirthDate))
                {
                    dateTimeInput_BirthDate.Text = Convert.ToDateTime(value.BirthDate).ToString("yyyy/MM/dd");
                }
                else
                {
                    dateTimeInput_BirthDate.Text = string.Empty;
                }
            }
            catch
            {
                dateTimeInput_BirthDate.Text = string.Empty;
            }
            try
            {
                if (VarGeneral.CheckDate(value.VisaDate))
                {
                    dateTimeInput_VisaDate.Text = Convert.ToDateTime(value.VisaDate).ToString("yyyy/MM/dd");
                }
                else
                {
                    dateTimeInput_VisaDate.Text = string.Empty;
                }
            }
            catch
            {
                dateTimeInput_VisaDate.Text = string.Empty;
            }
            try
            {
                if (VarGeneral.CheckDate(value.StartContr))
                {
                    dateTimeInput_StartContr.Text = Convert.ToDateTime(value.StartContr).ToString("yyyy/MM/dd");
                }
                else
                {
                    dateTimeInput_StartContr.Text = string.Empty;
                }
            }
            catch
            {
                dateTimeInput_StartContr.Text = string.Empty;
            }
            try
            {
                if (VarGeneral.CheckDate(value.EndContr))
                {
                    dateTimeInput_EndContr.Text = Convert.ToDateTime(value.EndContr).ToString("yyyy/MM/dd");
                }
                else
                {
                    dateTimeInput_EndContr.Text = string.Empty;
                }
            }
            catch
            {
                dateTimeInput_EndContr.Text = string.Empty;
            }
            try
            {
                if (VarGeneral.CheckDate(value.Form_Date))
                {
                    dateTimeInput_Form_Date.Text = Convert.ToDateTime(value.Form_Date).ToString("yyyy/MM/dd");
                }
                else
                {
                    dateTimeInput_Form_Date.Text = string.Empty;
                }
            }
            catch
            {
                dateTimeInput_Form_Date.Text = string.Empty;
            }
            try
            {
                if (VarGeneral.CheckDate(value.Form_DateEnd))
                {
                    dateTimeInput_Form_DateEnd.Text = Convert.ToDateTime(value.Form_DateEnd).ToString("yyyy/MM/dd");
                }
                else
                {
                    dateTimeInput_Form_DateEnd.Text = string.Empty;
                }
            }
            catch
            {
                dateTimeInput_Form_DateEnd.Text = string.Empty;
            }
            try
            {
                if (VarGeneral.CheckDate(value.ID_Date))
                {
                    dateTimeInput_ID_Date.Text = Convert.ToDateTime(value.ID_Date).ToString("yyyy/MM/dd");
                }
                else
                {
                    dateTimeInput_ID_Date.Text = string.Empty;
                }
            }
            catch
            {
                dateTimeInput_ID_Date.Text = string.Empty;
            }
            try
            {
                if (VarGeneral.CheckDate(value.ID_DateEnd))
                {
                    dateTimeInput_ID_DateEnd.Text = Convert.ToDateTime(value.ID_DateEnd).ToString("yyyy/MM/dd");
                }
                else
                {
                    dateTimeInput_ID_DateEnd.Text = string.Empty;
                }
            }
            catch
            {
                dateTimeInput_ID_DateEnd.Text = string.Empty;
            }
            try
            {
                if (VarGeneral.CheckDate(value.Insurance_Date))
                {
                    dateTimeInput_Insurance_Date.Text = Convert.ToDateTime(value.Insurance_Date).ToString("yyyy/MM/dd");
                }
                else
                {
                    dateTimeInput_Insurance_Date.Text = string.Empty;
                }
            }
            catch
            {
                dateTimeInput_Insurance_Date.Text = string.Empty;
            }
            try
            {
                if (VarGeneral.CheckDate(value.Insurance_DateEnd))
                {
                    dateTimeInput_Insurance_DateEnd.Text = Convert.ToDateTime(value.Insurance_DateEnd).ToString("yyyy/MM/dd");
                }
                else
                {
                    dateTimeInput_Insurance_DateEnd.Text = string.Empty;
                }
            }
            catch
            {
                dateTimeInput_Insurance_DateEnd.Text = string.Empty;
            }
            try
            {
                if (VarGeneral.CheckDate(value.LastFilter))
                {
                    dateTimeInput_LastFilter.Text = Convert.ToDateTime(value.LastFilter).ToString("yyyy/MM/dd");
                }
                else
                {
                    dateTimeInput_LastFilter.Text = string.Empty;
                }
            }
            catch
            {
                dateTimeInput_LastFilter.Text = string.Empty;
            }
            try
            {
                if (VarGeneral.CheckDate(value.LastFilter))
                {
                    dateTimeInput_License_Date.Text = Convert.ToDateTime(value.License_Date).ToString("yyyy/MM/dd");
                }
                else
                {
                    dateTimeInput_License_Date.Text = string.Empty;
                }
            }
            catch
            {
                dateTimeInput_License_Date.Text = string.Empty;
            }
            try
            {
                if (VarGeneral.CheckDate(value.License_DateEnd))
                {
                    dateTimeInput_License_DateEnd.Text = Convert.ToDateTime(value.License_DateEnd).ToString("yyyy/MM/dd");
                }
                else
                {
                    dateTimeInput_License_DateEnd.Text = string.Empty;
                }
            }
            catch
            {
                dateTimeInput_License_DateEnd.Text = string.Empty;
            }
            try
            {
                if (VarGeneral.CheckDate(value.Passport_Date))
                {
                    dateTimeInput_Pass_Date.Text = Convert.ToDateTime(value.Passport_Date).ToString("yyyy/MM/dd");
                }
                else
                {
                    dateTimeInput_Pass_Date.Text = string.Empty;
                }
            }
            catch
            {
                dateTimeInput_Pass_Date.Text = string.Empty;
            }
            try
            {
                if (VarGeneral.CheckDate(value.Passport_DateEnd))
                {
                    dateTimeInput_Passport_DateEnd.Text = Convert.ToDateTime(value.Passport_DateEnd).ToString("yyyy/MM/dd");
                }
                else
                {
                    dateTimeInput_Passport_DateEnd.Text = string.Empty;
                }
            }
            catch
            {
                dateTimeInput_Passport_DateEnd.Text = string.Empty;
            }
            try
            {
                if (!string.IsNullOrEmpty(value.Allowances.Value.ToString() ?? string.Empty))
                {
                    for (int i = 0; i < comboBox_Allowances.Items.Count; i++)
                    {
                        comboBox_Allowances.SelectedIndex = i;
                        if (comboBox_Allowances.Text == value.Allowances.Value.ToString())
                        {
                            break;
                        }
                    }
                }
            }
            catch
            {
                comboBox_Allowances.SelectedIndex = 0;
            }
            if (value.AllowancesTime.HasValue)
            {
                comboBox_AllowancesTime.SelectedIndex = value.AllowancesTime.Value;
            }
            if (!string.IsNullOrEmpty(value.SalAcc))
            {
                textBox_AccSal.Text = value.SalAcc;
                textBox_AccSalName.Text = ((LangArEn == 0) ? value.T_AccDef4.Arb_Des : value.T_AccDef4.Eng_Des);
            }
            else
            {
                textBox_AccSal.Text = string.Empty;
                textBox_AccSalName.Text = string.Empty;
            }
            if (!string.IsNullOrEmpty(value.LoanAcc))
            {
                textBox_AccLoan.Text = value.LoanAcc;
                textBox_AccLoanName.Text = ((LangArEn == 0) ? value.T_AccDef3.Arb_Des : value.T_AccDef3.Eng_Des);
            }
            else
            {
                textBox_AccLoan.Text = string.Empty;
                textBox_AccLoanName.Text = string.Empty;
            }
            if (!string.IsNullOrEmpty(value.HouseAcc))
            {
                textBox_AccHousing.Text = value.HouseAcc;
                textBox_AccHousingName.Text = ((LangArEn == 0) ? value.T_AccDef2.Arb_Des : value.T_AccDef2.Eng_Des);
            }
            else
            {
                textBox_AccHousing.Text = string.Empty;
                textBox_AccHousingName.Text = string.Empty;
            }
            if (value.CostCenterEmp.HasValue)
            {
                textBox_CostCenter.Text = value.CostCenterEmp.Value.ToString();
                textBox_CostCenterName.Text = ((LangArEn == 0) ? value.T_CstTbl.Arb_Des : value.T_CstTbl.Eng_Des);
            }
            else
            {
                textBox_CostCenter.Text = string.Empty;
                textBox_CostCenterName.Text = string.Empty;
            }
            if (!string.IsNullOrEmpty(value.AccountID))
            {
                txtBXBankNo.Text = value.AccountID;
                txtBXBankName.Text = ((LangArEn == 0) ? value.T_AccDef.Arb_Des : value.T_AccDef.Eng_Des);
            }
            else
            {
                txtBXBankNo.Text = string.Empty;
                txtBXBankName.Text = string.Empty;
            }
            BindingList<T_Family> Family_line = new BindingList<T_Family>(value.T_Families);
            FillFamilyBox(Family_line);
            try
            {
                Update_Attend = new BindingList<T_Attend>(value.T_Attends);
                FillAttendBox(Update_Attend);
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("FormEmpOn_FillAttendBox:", error, enable: true);
                MessageBox.Show(error.Message);
            }
            try
            {
                FillImageList();
            }
            catch
            {
            }
            try
            {
                FillImageList2();
            }
            catch
            {
            }
            textBox_SocialInsuranceNo_Leave(null, null);
            textBox_WorkNo_Leave(null, null);
            SetReadOnly = true;
        }
        private void FillAttendBox(BindingList<T_Attend> linesList)
        {
            if (linesList.Count > 0)
            {
                textBox_SatTime1.Text = linesList[0].Time1;
                textBox_SatTime2.Text = linesList[0].Time2;
                textBox_SatTimeAllow1.Text = linesList[0].TimeAllow1;
                textBox_SatTimeAllow2.Text = linesList[0].TimeAlow2;
                textBox_SatLeaveTime1.Text = linesList[0].LeaveTime1;
                textBox_SatLeaveTime2.Text = linesList[0].LeaveTime2;
                if (linesList[0].Periods == 1)
                {
                    radioButton_SatPeriods1.Checked = true;
                }
                else if (linesList[0].Periods == 2)
                {
                    radioButton_SatPeriods2.Checked = true;
                }
                else
                {
                    radioButton_SatBreakDay.Checked = true;
                }
                textBox_SunTime1.Text = linesList[1].Time1;
                textBox_SunTime2.Text = linesList[1].Time2;
                textBox_SunTimeAllow1.Text = linesList[1].TimeAllow1;
                textBox_SunTimeAllow2.Text = linesList[1].TimeAlow2;
                textBox_SunLeaveTime1.Text = linesList[1].LeaveTime1;
                textBox_SunLeaveTime2.Text = linesList[1].LeaveTime2;
                if (linesList[1].Periods == 1)
                {
                    radioButton_SunPeriods1.Checked = true;
                }
                else if (linesList[1].Periods == 2)
                {
                    radioButton_SunPeriods2.Checked = true;
                }
                else
                {
                    radioButton_SunBreakDay.Checked = true;
                }
                textBox_MonTime1.Text = linesList[2].Time1;
                textBox_MonTime2.Text = linesList[2].Time2;
                textBox_MonTimeAllow1.Text = linesList[2].TimeAllow1;
                textBox_MonTimeAllow2.Text = linesList[2].TimeAlow2;
                textBox_MonLeaveTime1.Text = linesList[2].LeaveTime1;
                textBox_MonLeaveTime2.Text = linesList[2].LeaveTime2;
                if (linesList[2].Periods == 1)
                {
                    radioButton_MonPeriods1.Checked = true;
                }
                else if (linesList[2].Periods == 2)
                {
                    radioButton_MonPeriods2.Checked = true;
                }
                else
                {
                    radioButton_MonBreakDay.Checked = true;
                }
                textBox_TusTime1.Text = linesList[3].Time1;
                textBox_TusTime2.Text = linesList[3].Time2;
                textBox_TusTimeAllow1.Text = linesList[3].TimeAllow1;
                textBox_TusTimeAllow2.Text = linesList[3].TimeAlow2;
                textBox_TusLeaveTime1.Text = linesList[3].LeaveTime1;
                textBox_TusLeaveTime2.Text = linesList[3].LeaveTime2;
                if (linesList[3].Periods == 1)
                {
                    radioButton_TusPeriods1.Checked = true;
                }
                else if (linesList[3].Periods == 2)
                {
                    radioButton_TusPeriods2.Checked = true;
                }
                else
                {
                    radioButton_TusBreakDay.Checked = true;
                }
                textBox_WenTime1.Text = linesList[4].Time1;
                textBox_WenTime2.Text = linesList[4].Time2;
                textBox_WenTimeAllow1.Text = linesList[4].TimeAllow1;
                textBox_WenTimeAllow2.Text = linesList[4].TimeAlow2;
                textBox_WenLeaveTime1.Text = linesList[4].LeaveTime1;
                textBox_WenLeaveTime2.Text = linesList[4].LeaveTime2;
                if (linesList[4].Periods == 1)
                {
                    radioButton_WenPeriods1.Checked = true;
                }
                else if (linesList[4].Periods == 2)
                {
                    radioButton_WenPeriods2.Checked = true;
                }
                else
                {
                    radioButton_WenBreakDay.Checked = true;
                }
                textBox_ThurTime1.Text = linesList[5].Time1;
                textBox_ThurTime2.Text = linesList[5].Time2;
                textBox_ThurTimeAllow1.Text = linesList[5].TimeAllow1;
                textBox_ThurTimeAllow2.Text = linesList[5].TimeAlow2;
                textBox_ThurLeaveTime1.Text = linesList[5].LeaveTime1;
                textBox_ThurLeaveTime2.Text = linesList[5].LeaveTime2;
                if (linesList[5].Periods == 1)
                {
                    radioButton_ThurPeriods1.Checked = true;
                }
                else if (linesList[5].Periods == 2)
                {
                    radioButton_ThurPeriods2.Checked = true;
                }
                else
                {
                    radioButton_ThurBreakDay.Checked = true;
                }
                textBox_FriTime1.Text = linesList[6].Time1;
                textBox_FriTime2.Text = linesList[6].Time2;
                textBox_FriTimeAllow1.Text = linesList[6].TimeAllow1;
                textBox_FriTimeAllow2.Text = linesList[6].TimeAlow2;
                textBox_LeaveTime1.Text = linesList[6].LeaveTime1;
                textBox_LeaveTime2.Text = linesList[6].LeaveTime2;
                if (linesList[6].Periods == 1)
                {
                    radioButton_FriPeriods1.Checked = true;
                }
                else if (linesList[6].Periods == 2)
                {
                    radioButton_FriPeriods2.Checked = true;
                }
                else
                {
                    radioButton_FriBreakDay.Checked = true;
                }
            }
        }
        private void FillFamilyBox(BindingList<T_Family> linesList)
        {
            if (linesList.Count <= 0)
            {
                return;
            }
            for (int i = 0; i < linesList.Count; i++)
            {
                if (i == 0)
                {
                    textBox_Name1.Text = linesList[i].Name;
                    textBox_Relation1.Text = linesList[i].Link;
                    try
                    {
                        dateTimeInput_BirthDate1.Text = Convert.ToDateTime(linesList[i].BirthDay).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_BirthDate1.Text = string.Empty;
                    }
                    try
                    {
                        dateTimeInput_PassportDateEnd1.Text = Convert.ToDateTime(linesList[i].PassEnd).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_PassportDateEnd1.Text = string.Empty;
                    }
                    textBox_PassporntNo1.Text = linesList[i].PassNo;
                }
                if (i == 1)
                {
                    textBox_Name2.Text = linesList[i].Name;
                    textBox_Relation2.Text = linesList[i].Link;
                    try
                    {
                        dateTimeInput_BirthDate2.Text = Convert.ToDateTime(linesList[i].BirthDay).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_BirthDate2.Text = string.Empty;
                    }
                    try
                    {
                        dateTimeInput_PassportDateEnd2.Text = Convert.ToDateTime(linesList[i].PassEnd).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_PassportDateEnd2.Text = string.Empty;
                    }
                    textBox_PassporntNo2.Text = linesList[i].PassNo;
                }
                if (i == 2)
                {
                    textBox_Name3.Text = linesList[i].Name;
                    textBox_Relation3.Text = linesList[i].Link;
                    try
                    {
                        dateTimeInput_BirthDate3.Text = Convert.ToDateTime(linesList[i].BirthDay).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_BirthDate3.Text = string.Empty;
                    }
                    try
                    {
                        dateTimeInput_PassportDateEnd3.Text = Convert.ToDateTime(linesList[i].PassEnd).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_PassportDateEnd3.Text = string.Empty;
                    }
                    textBox_PassporntNo3.Text = linesList[i].PassNo;
                }
                if (i == 3)
                {
                    textBox_Name4.Text = linesList[i].Name;
                    textBox_Relation4.Text = linesList[i].Link;
                    try
                    {
                        dateTimeInput_BirthDate4.Text = Convert.ToDateTime(linesList[i].BirthDay).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_BirthDate4.Text = string.Empty;
                    }
                    try
                    {
                        dateTimeInput_PassportDateEnd4.Text = Convert.ToDateTime(linesList[i].PassEnd).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_PassportDateEnd4.Text = string.Empty;
                    }
                    textBox_PassporntNo4.Text = linesList[i].PassNo;
                }
                if (i == 4)
                {
                    textBox_Name5.Text = linesList[i].Name;
                    textBox_Relation5.Text = linesList[i].Link;
                    try
                    {
                        dateTimeInput_BirthDate5.Text = Convert.ToDateTime(linesList[i].BirthDay).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_BirthDate5.Text = string.Empty;
                    }
                    try
                    {
                        dateTimeInput_PassportDateEnd5.Text = Convert.ToDateTime(linesList[i].PassEnd).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_PassportDateEnd5.Text = string.Empty;
                    }
                    textBox_PassporntNo5.Text = linesList[i].PassNo;
                }
                if (i == 5)
                {
                    textBox_Name6.Text = linesList[i].Name;
                    textBox_Relation6.Text = linesList[i].Link;
                    try
                    {
                        dateTimeInput_BirthDate6.Text = Convert.ToDateTime(linesList[i].BirthDay).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_BirthDate6.Text = string.Empty;
                    }
                    try
                    {
                        dateTimeInput_PassportDateEnd6.Text = Convert.ToDateTime(linesList[i].PassEnd).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_PassportDateEnd6.Text = string.Empty;
                    }
                    textBox_PassporntNo6.Text = linesList[i].PassNo;
                }
                if (i == 6)
                {
                    textBox_Name7.Text = linesList[i].Name;
                    textBox_Relation7.Text = linesList[i].Link;
                    try
                    {
                        dateTimeInput_BirthDate7.Text = Convert.ToDateTime(linesList[i].BirthDay).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_BirthDate7.Text = string.Empty;
                    }
                    try
                    {
                        dateTimeInput_PassportDateEnd6.Text = Convert.ToDateTime(linesList[i].PassEnd).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_PassportDateEnd6.Text = string.Empty;
                    }
                    textBox_PassporntNo7.Text = linesList[i].PassNo;
                }
                if (i == 7)
                {
                    textBox_Name8.Text = linesList[i].Name;
                    textBox_Relation8.Text = linesList[i].Link;
                    try
                    {
                        dateTimeInput_BirthDate8.Text = Convert.ToDateTime(linesList[i].BirthDay).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_BirthDate8.Text = string.Empty;
                    }
                    try
                    {
                        dateTimeInput_PassportDateEnd6.Text = Convert.ToDateTime(linesList[i].PassEnd).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_PassportDateEnd6.Text = string.Empty;
                    }
                    textBox_PassporntNo8.Text = linesList[i].PassNo;
                }
                if (i == 8)
                {
                    textBox_Name9.Text = linesList[i].Name;
                    textBox_Relation9.Text = linesList[i].Link;
                    try
                    {
                        dateTimeInput_BirthDate9.Text = Convert.ToDateTime(linesList[i].BirthDay).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_BirthDate9.Text = string.Empty;
                    }
                    try
                    {
                        dateTimeInput_PassportDateEnd9.Text = Convert.ToDateTime(linesList[i].PassEnd).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_PassportDateEnd9.Text = string.Empty;
                    }
                    textBox_PassporntNo9.Text = linesList[i].PassNo;
                }
                if (i == 9)
                {
                    textBox_Name10.Text = linesList[i].Name;
                    textBox_Relation10.Text = linesList[i].Link;
                    try
                    {
                        dateTimeInput_BirthDate10.Text = Convert.ToDateTime(linesList[i].BirthDay).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_BirthDate10.Text = string.Empty;
                    }
                    try
                    {
                        dateTimeInput_PassportDateEnd10.Text = Convert.ToDateTime(linesList[i].PassEnd).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_PassportDateEnd10.Text = string.Empty;
                    }
                    textBox_PassporntNo10.Text = linesList[i].PassNo;
                }
                if (i == 10)
                {
                    textBox_Name11.Text = linesList[i].Name;
                    textBox_Relation11.Text = linesList[i].Link;
                    try
                    {
                        dateTimeInput_BirthDate11.Text = Convert.ToDateTime(linesList[i].BirthDay).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_BirthDate11.Text = string.Empty;
                    }
                    try
                    {
                        dateTimeInput_PassportDateEnd11.Text = Convert.ToDateTime(linesList[i].PassEnd).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_PassportDateEnd11.Text = string.Empty;
                    }
                    textBox_PassporntNo11.Text = linesList[i].PassNo;
                }
                if (i == 11)
                {
                    textBox_Name12.Text = linesList[i].Name;
                    textBox_Relation12.Text = linesList[i].Link;
                    try
                    {
                        dateTimeInput_BirthDate12.Text = Convert.ToDateTime(linesList[i].BirthDay).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_BirthDate12.Text = string.Empty;
                    }
                    try
                    {
                        dateTimeInput_PassportDateEnd12.Text = Convert.ToDateTime(linesList[i].PassEnd).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_PassportDateEnd12.Text = string.Empty;
                    }
                    textBox_PassporntNo12.Text = linesList[i].PassNo;
                }
                if (i == 12)
                {
                    textBox_Name13.Text = linesList[i].Name;
                    textBox_Relation13.Text = linesList[i].Link;
                    try
                    {
                        dateTimeInput_BirthDate13.Text = Convert.ToDateTime(linesList[i].BirthDay).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_BirthDate13.Text = string.Empty;
                    }
                    try
                    {
                        dateTimeInput_PassportDateEnd13.Text = Convert.ToDateTime(linesList[i].PassEnd).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_PassportDateEnd13.Text = string.Empty;
                    }
                    textBox_PassporntNo13.Text = linesList[i].PassNo;
                }
                if (i == 13)
                {
                    textBox_Name14.Text = linesList[i].Name;
                    textBox_Relation14.Text = linesList[i].Link;
                    try
                    {
                        dateTimeInput_BirthDate14.Text = Convert.ToDateTime(linesList[i].BirthDay).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_BirthDate14.Text = string.Empty;
                    }
                    try
                    {
                        dateTimeInput_PassportDateEnd14.Text = Convert.ToDateTime(linesList[i].PassEnd).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_PassportDateEnd14.Text = string.Empty;
                    }
                    textBox_PassporntNo14.Text = linesList[i].PassNo;
                }
                if (i == 14)
                {
                    textBox_Name15.Text = linesList[i].Name;
                    textBox_Relation15.Text = linesList[i].Link;
                    try
                    {
                        dateTimeInput_BirthDate15.Text = Convert.ToDateTime(linesList[i].BirthDay).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_BirthDate15.Text = string.Empty;
                    }
                    try
                    {
                        dateTimeInput_PassportDateEnd15.Text = Convert.ToDateTime(linesList[i].PassEnd).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_PassportDateEnd15.Text = string.Empty;
                    }
                    textBox_PassporntNo15.Text = linesList[i].PassNo;
                }
            }
        }
        private byte[] ImageToByteArray(Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, ImageFormat.Gif);
            return ms.ToArray();
        }
        public Image ByteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            return Image.FromStream(ms);
        }
        public static string[] GetFilesFrom(string searchFolder, string[] filters, bool isRecursive)
        {
            List<string> filesFound = new List<string>();
            System.IO.SearchOption searchOption = (isRecursive ? System.IO.SearchOption.AllDirectories : System.IO.SearchOption.TopDirectoryOnly);
            filesFound.AddRange(Directory.GetFiles(searchFolder, $"*.*", searchOption));
            return filesFound.ToArray();
        }
        private void FillImageList()
        {
            try
            {
                listBox_ImageFiles.Items.Clear();
            }
            catch
            {
            }
            try
            {
                listBox_ImageFiles.DataSource = null;
            }
            catch
            {
            }
            try
            {
                string[] filters = new string[15]
                {
                    "jpeg",
                    "docx",
                    "BMP",
                    "JPG",
                    "GIF",
                    "PNG",
                    "TIF",
                    "PDF",
                    "PCX",
                    "TGA",
                    "JP2",
                    "JPC",
                    "RAS",
                    "PGX",
                    "PNM"
                };
                string[] filePaths = GetFilesFrom(string.IsNullOrEmpty(VarGeneral.Settings_Sys.DocumentPath) ? (Application.StartupPath + "\\EmpDocuments") : VarGeneral.Settings_Sys.DocumentPath, filters, isRecursive: false);
                if (filePaths.Count() <= 0)
                {
                    return;
                }
                for (int i = 0; i < filePaths.Count(); i++)
                {
                    try
                    {
                        if (Path.GetFileName(filePaths[i]).StartsWith(data_this.Emp_No))
                        {
                            listBox_ImageFiles.Items.Add(Path.GetFileName(filePaths[i]));
                        }
                    }
                    catch
                    {
                    }
                }
                listBox_ImageFiles.Sorted = true;
            }
            catch
            {
            }
        }
        private void FillImageList2()
        {
            try
            {
                listBox_ImageFiles2.Items.Clear();
            }
            catch
            {
            }
            try
            {
                listBox_ImageFiles2.DataSource = null;
            }
            catch
            {
            }
            try
            {
                string[] filters = new string[15]
                {
                    "jpeg",
                    "docx",
                    "BMP",
                    "JPG",
                    "GIF",
                    "PNG",
                    "TIF",
                    "PDF",
                    "PCX",
                    "TGA",
                    "JP2",
                    "JPC",
                    "RAS",
                    "PGX",
                    "PNM"
                };
                string[] filePaths = GetFilesFrom(string.IsNullOrEmpty(VarGeneral.Settings_Sys.DocumentPath) ? (Application.StartupPath + "\\EmpDocuments") : VarGeneral.Settings_Sys.DocumentPath, filters, isRecursive: false);
                if (filePaths.Count() <= 0)
                {
                    return;
                }
                for (int i = 0; i < filePaths.Count(); i++)
                {
                    try
                    {
                        if (!Path.GetFileName(filePaths[i]).StartsWith(data_this.Emp_No))
                        {
                            continue;
                        }
                        for (int iicnt = 0; iicnt < Path.GetFileName(filePaths[i]).Length; iicnt++)
                        {
                            try
                            {
                                if (Path.GetFileName(filePaths[i]).Substring(iicnt, 1) == "-" && Information.IsNumeric(Path.GetFileName(filePaths[i]).Substring(iicnt + 1, 5)) && Path.GetFileName(filePaths[i]).Substring(iicnt + 1, 5).Length == 5)
                                {
                                    listBox_ImageFiles2.Items.Add(Path.GetFileName(filePaths[i]).Substring(iicnt + 1, 5));
                                }
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
                listBox_ImageFiles2.Sorted = true;
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
        private T_Emp GetData()
        {
            textBox_ID.Focus();
            try
            {
                data_this.Emp_No = textBox_ID.Text;
            }
            catch
            {
            }
            try
            {
                data_this.NameA = textBox_NameA.Text;
            }
            catch
            {
            }
            try
            {
                data_this.NameE = textBox_NameE.Text;
            }
            catch
            {
            }
            try
            {
                data_this.Note = textBox_Note.Text;
            }
            catch
            {
            }
            try
            {
                data_this.AddDay = textBox_AddDay.Value;
            }
            catch
            {
                data_this.AddDay = 0.0;
            }
            try
            {
                data_this.AddHours = textBox_AddHours.Value;
            }
            catch
            {
                data_this.AddHours = 0.0;
            }
            try
            {
                data_this.AddressA = textBox_AddressA.Text;
            }
            catch
            {
            }
            try
            {
                data_this.DayOfMonth = textBox_DayOfMonth.Value;
            }
            catch
            {
                data_this.DayOfMonth = 0;
            }
            try
            {
                data_this.DisOneDay = textBox_DisOneDay.Value;
            }
            catch
            {
                data_this.DisOneDay = 0.0;
            }
            try
            {
                data_this.Email = textBox_Email.Text;
            }
            catch
            {
            }
            try
            {
                data_this.EmpState = VarGeneral.FrmEmpStat;
            }
            catch
            {
                data_this.EmpState = true;
            }
            try
            {
                data_this.ExperiencesA = textBox_ExperiencesA.Text;
            }
            catch
            {
            }
            try
            {
                data_this.Form_No = textBox_Form_No.Text;
            }
            catch
            {
            }
            try
            {
                data_this.HousingAllowance = textBox_HousingAllowance.Value;
            }
            catch
            {
                data_this.HousingAllowance = 0.0;
            }
            try
            {
                data_this.ID_No = textBox_ID_No.Text;
            }
            catch
            {
            }
            try
            {
                data_this.Insurance_No = textBox_Insurance_No.Text;
            }
            catch
            {
            }
            try
            {
                data_this.LateHours = textBox_LateHours.Value;
            }
            catch
            {
                data_this.LateHours = 0.0;
            }
            try
            {
                data_this.License_No = textBox_License_No.Text;
            }
            catch
            {
            }
            try
            {
                data_this.MainSal = textBox_MainSal.Value;
            }
            catch
            {
                data_this.MainSal = 0.0;
            }
            try
            {
                data_this.MandateDay = textBox_MandateDay.Value;
            }
            catch
            {
                data_this.MandateDay = 0.0;
            }
            try
            {
                data_this.NaturalWorkAllowance = textBox_NaturalWorkAllowance.Value;
            }
            catch
            {
                data_this.NaturalWorkAllowance = 0.0;
            }
            try
            {
                data_this.OtherAllowance = textBox_OtherAllowance.Value;
            }
            catch
            {
                data_this.OtherAllowance = 0.0;
            }
            try
            {
                data_this.Pass = VarGeneral.Encrypt(textBox_Pass.Text);
            }
            catch
            {
            }
            try
            {
                data_this.Passport_No = textBox_Passport_No.Text;
            }
            catch
            {
            }
            try
            {
                data_this.QualificationA = textBox_QualificationA.Text;
            }
            catch
            {
            }
            try
            {
                data_this.SocialInsurance = textBox_SocialInsurance.Value;
            }
            catch
            {
                data_this.SocialInsurance = 0.0;
            }
            try
            {
                data_this.SocialInsuranceComp = textBox_SocialInsuranceComp.Value;
            }
            catch
            {
                data_this.SocialInsuranceComp = 0.0;
            }
            try
            {
                data_this.InsuranceMedicalCom = textBox_InsuranceMedicalCom.Value;
            }
            catch
            {
                data_this.InsuranceMedicalCom = 0.0;
            }
            try
            {
                data_this.InsuranceMedical = textBox_InsuranceMedical.Value;
            }
            catch
            {
                data_this.InsuranceMedical = 0.0;
            }
            try
            {
                data_this.SocialInsuranceNo = textBox_SocialInsuranceNo.Text;
            }
            catch
            {
            }
            try
            {
                data_this.WorkNo = textBox_WorkNo.Text;
            }
            catch
            {
            }
            try
            {
                data_this.VisaNo = textBox_VisaNo.Text;
            }
            catch
            {
            }
            try
            {
                data_this.VisaEnterNo = textBox_VisaEnterNo.Text;
            }
            catch
            {
            }
            try
            {
                data_this.VisaCountry = textBox_VisaCountry.Text;
            }
            catch
            {
            }
            try
            {
                data_this.SubsistenceAllowance = textBox_SubsistenceAllowance.Value;
            }
            catch
            {
                data_this.SubsistenceAllowance = 0.0;
            }
            try
            {
                data_this.Tel = textBox_Tel.Text;
            }
            catch
            {
            }
            try
            {
                data_this.TicketsCount = textBox_TicketsCount.Value;
            }
            catch
            {
                data_this.TicketsCount = 0.0;
            }
            try
            {
                data_this.TicketsPrice = textBox_TicketsPrice.Value;
            }
            catch
            {
                data_this.TicketsPrice = 0.0;
            }
            try
            {
                data_this.TransferAllowance = textBox_TransferAllowance.Value;
            }
            catch
            {
                data_this.TransferAllowance = 0.0;
            }
            try
            {
                data_this.VacationCount = textBox_VacationCount.Value;
            }
            catch
            {
                data_this.VacationCount = 0;
            }
            try
            {
                data_this.WorkHours = textBox_WorkHours.Value;
            }
            catch
            {
                data_this.WorkHours = 0.0;
            }
            try
            {
                data_this.AutoReturnContr = checkBox_AutoReturnContr.Checked;
            }
            catch
            {
            }
            try
            {
                data_this.DateAppointment = Convert.ToDateTime(dateTimeInput_DateAppointment.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_DateAppointment.Text = string.Empty;
                int? calendr = VarGeneral.Settings_Sys.Calendr;
                if (calendr.Value == 0 && calendr.HasValue)
                {
                    dateTimeInput_DateAppointment.Text = n.FormatGreg(VarGeneral.Gdate, "yyyy/MM/dd");
                }
                else
                {
                    dateTimeInput_DateAppointment.Text = n.FormatHijri(VarGeneral.Hdate, "yyyy/MM/dd");
                }
                data_this.DateAppointment = Convert.ToDateTime(dateTimeInput_DateAppointment.Text).ToString("yyyy/MM/dd");
            }
            try
            {
                data_this.StartContr = Convert.ToDateTime(dateTimeInput_StartContr.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_StartContr.Text = string.Empty;
                data_this.StartContr = string.Empty;
            }
            try
            {
                data_this.Insurance_Date = Convert.ToDateTime(dateTimeInput_Insurance_Date.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_Insurance_Date.Text = string.Empty;
                data_this.Insurance_Date = string.Empty;
            }
            try
            {
                data_this.VisaDate = Convert.ToDateTime(dateTimeInput_VisaDate.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_VisaDate.Text = string.Empty;
                data_this.VisaDate = string.Empty;
            }
            try
            {
                data_this.BirthDate = Convert.ToDateTime(dateTimeInput_BirthDate.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_BirthDate.Text = string.Empty;
                data_this.BirthDate = string.Empty;
            }
            try
            {
                data_this.EndContr = Convert.ToDateTime(dateTimeInput_EndContr.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_EndContr.Text = string.Empty;
                data_this.EndContr = string.Empty;
            }
            try
            {
                data_this.Form_Date = Convert.ToDateTime(dateTimeInput_Form_Date.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_Form_Date.Text = string.Empty;
                data_this.Form_Date = string.Empty;
            }
            try
            {
                data_this.Form_DateEnd = Convert.ToDateTime(dateTimeInput_Form_DateEnd.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_Form_DateEnd.Text = string.Empty;
                data_this.Form_DateEnd = string.Empty;
            }
            try
            {
                data_this.ID_Date = Convert.ToDateTime(dateTimeInput_ID_Date.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_ID_Date.Text = string.Empty;
                data_this.ID_Date = string.Empty;
            }
            try
            {
                if (!db.CheckEmp_Salary(data_this.Emp_ID))
                {
                    data_this.ID_DateEnd = Convert.ToDateTime(dateTimeInput_ID_DateEnd.Text).ToString("yyyy/MM/dd");
                }
            }
            catch
            {
                dateTimeInput_ID_DateEnd.Text = string.Empty;
                data_this.ID_DateEnd = string.Empty;
            }
            try
            {
                if (!db.CheckEmp_Salary(data_this.Emp_ID))
                {
                    data_this.Insurance_DateEnd = Convert.ToDateTime(dateTimeInput_Insurance_DateEnd.Text).ToString("yyyy/MM/dd");
                }
            }
            catch
            {
                dateTimeInput_Insurance_DateEnd.Text = string.Empty;
                data_this.Insurance_DateEnd = string.Empty;
            }
            try
            {
                data_this.LastFilter = Convert.ToDateTime(dateTimeInput_LastFilter.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_LastFilter.Text = string.Empty;
                data_this.LastFilter = string.Empty;
            }
            try
            {
                data_this.License_Date = Convert.ToDateTime(dateTimeInput_License_Date.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_License_Date.Text = string.Empty;
                data_this.License_Date = string.Empty;
            }
            try
            {
                if (!db.CheckEmp_Salary(data_this.Emp_ID))
                {
                    data_this.License_DateEnd = Convert.ToDateTime(dateTimeInput_License_DateEnd.Text).ToString("yyyy/MM/dd");
                }
            }
            catch
            {
                dateTimeInput_License_DateEnd.Text = string.Empty;
                data_this.License_DateEnd = string.Empty;
            }
            try
            {
                data_this.Passport_Date = Convert.ToDateTime(dateTimeInput_Pass_Date.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_Pass_Date.Text = string.Empty;
                data_this.Passport_Date = string.Empty;
            }
            try
            {
                if (!db.CheckEmp_Salary(data_this.Emp_ID))
                {
                    data_this.Passport_DateEnd = Convert.ToDateTime(dateTimeInput_Passport_DateEnd.Text).ToString("yyyy/MM/dd");
                }
            }
            catch
            {
                dateTimeInput_Passport_DateEnd.Text = string.Empty;
                data_this.Passport_DateEnd = string.Empty;
            }
            if (pictureBox_EnterPic.Image != null)
            {
                MemoryStream stream = new MemoryStream();
                pictureBox_EnterPic.Image.Save(stream, ImageFormat.Jpeg);
                byte[] arr = stream.GetBuffer();
                data_this.EmpPic = arr;
            }
            else
            {
                data_this.EmpPic = null;
            }
            try
            {
                if (comboBox_BirthPlace.SelectedIndex > 0)
                {
                    data_this.BirthPlace = int.Parse(comboBox_BirthPlace.SelectedValue.ToString());
                }
                else
                {
                    data_this.BirthPlace = null;
                }
            }
            catch
            {
                data_this.BirthPlace = null;
            }
            try
            {
                if (comboBox_BloodTyp.SelectedIndex > 0)
                {
                    data_this.BloodTyp = int.Parse(comboBox_BloodTyp.SelectedValue.ToString());
                }
                else
                {
                    data_this.BloodTyp = null;
                }
            }
            catch
            {
                data_this.BloodTyp = null;
            }
            try
            {
                if (comboBox_CalculateNo.SelectedIndex > 0)
                {
                    data_this.CalculateNo = int.Parse(comboBox_CalculateNo.SelectedValue.ToString());
                }
                else
                {
                    data_this.CalculateNo = null;
                }
            }
            catch
            {
                data_this.CalculateNo = null;
            }
            try
            {
                if (comboBox_CityNo.SelectedIndex > 0)
                {
                    data_this.CityNo = int.Parse(comboBox_CityNo.SelectedValue.ToString());
                }
                else
                {
                    data_this.CityNo = null;
                }
            }
            catch
            {
                data_this.CityNo = null;
            }
            try
            {
                if (comboBox_ContrTyp.SelectedIndex > 0)
                {
                    data_this.ContrTyp = int.Parse(comboBox_ContrTyp.SelectedValue.ToString());
                }
                else
                {
                    data_this.ContrTyp = null;
                }
            }
            catch
            {
                data_this.ContrTyp = null;
            }
            try
            {
                if (comboBox_Dept.SelectedIndex > 0)
                {
                    data_this.Dept = int.Parse(comboBox_Dept.SelectedValue.ToString());
                }
                else
                {
                    data_this.Dept = null;
                }
            }
            catch
            {
                data_this.Dept = null;
            }
            try
            {
                if (comboBox_DirBoss.SelectedIndex > 0)
                {
                    data_this.DirBoss = int.Parse(comboBox_DirBoss.SelectedValue.ToString());
                }
                else
                {
                    data_this.DirBoss = null;
                }
            }
            catch
            {
                data_this.DirBoss = null;
            }
            try
            {
                if (comboBox_Form_From.SelectedIndex > 0)
                {
                    data_this.Form_From = int.Parse(comboBox_Form_From.SelectedValue.ToString());
                }
                else
                {
                    data_this.Form_From = null;
                }
            }
            catch
            {
                data_this.Form_From = null;
            }
            try
            {
                if (comboBox_Guarantor.SelectedIndex > 0)
                {
                    data_this.Guarantor = int.Parse(comboBox_Guarantor.SelectedValue.ToString());
                }
                else
                {
                    data_this.Guarantor = null;
                }
            }
            catch
            {
                data_this.Guarantor = null;
            }
            try
            {
                if (comboBox_ID_From.SelectedIndex > 0)
                {
                    data_this.ID_From = int.Parse(comboBox_ID_From.SelectedValue.ToString());
                }
                else
                {
                    data_this.ID_From = null;
                }
            }
            catch
            {
                data_this.ID_From = null;
            }
            try
            {
                if (comboBox_Insurance_From.SelectedIndex > 0)
                {
                    data_this.Insurance_From = int.Parse(comboBox_Insurance_From.SelectedValue.ToString());
                }
                else
                {
                    data_this.Insurance_From = null;
                }
            }
            catch
            {
                data_this.Insurance_From = null;
            }
            try
            {
                if (comboBox_Job.SelectedIndex > 0)
                {
                    data_this.Job = int.Parse(comboBox_Job.SelectedValue.ToString());
                }
                else
                {
                    data_this.Job = null;
                }
            }
            catch
            {
                data_this.Job = null;
            }
            try
            {
                if (comboBox_License_From.SelectedIndex > 0)
                {
                    data_this.License_From = int.Parse(comboBox_License_From.SelectedValue.ToString());
                }
                else
                {
                    data_this.License_From = null;
                }
            }
            catch
            {
                data_this.License_From = null;
            }
            try
            {
                if (comboBox_MaritalStatus.SelectedIndex > 0)
                {
                    data_this.MaritalStatus = int.Parse(comboBox_MaritalStatus.SelectedValue.ToString());
                }
                else
                {
                    data_this.MaritalStatus = null;
                }
            }
            catch
            {
                data_this.MaritalStatus = null;
            }
            try
            {
                if (comboBox_Nationalty.SelectedIndex > 0)
                {
                    data_this.Nationalty = int.Parse(comboBox_Nationalty.SelectedValue.ToString());
                }
                else
                {
                    data_this.Nationalty = null;
                }
            }
            catch
            {
                data_this.Nationalty = null;
            }
            try
            {
                if (comboBox_Passport_From.SelectedIndex > 0)
                {
                    data_this.Passport_From = int.Parse(comboBox_Passport_From.SelectedValue.ToString());
                }
                else
                {
                    data_this.Passport_From = null;
                }
            }
            catch
            {
                data_this.Passport_From = null;
            }
            try
            {
                if (comboBox_Religion.SelectedIndex > 0)
                {
                    data_this.Religion = int.Parse(comboBox_Religion.SelectedValue.ToString());
                }
                else
                {
                    data_this.Religion = null;
                }
            }
            catch
            {
                data_this.Religion = null;
            }
            try
            {
                if (comboBox_Section.SelectedIndex > 0)
                {
                    data_this.Section = int.Parse(comboBox_Section.SelectedValue.ToString());
                }
                else
                {
                    data_this.Section = null;
                }
            }
            catch
            {
                data_this.Section = null;
            }
            try
            {
                if (comboBox_Sex.SelectedIndex > 0)
                {
                    data_this.Sex = int.Parse(comboBox_Sex.SelectedValue.ToString());
                }
                else
                {
                    data_this.Sex = null;
                }
            }
            catch
            {
                data_this.Sex = null;
            }
            try
            {
                if (switchButton_SalStatus.Value)
                {
                    data_this.StatusSal = 1;
                }
                else
                {
                    data_this.StatusSal = 2;
                }
            }
            catch
            {
                data_this.StatusSal = 2;
            }
            try
            {
                if (switchButton_AccType.Value)
                {
                    data_this.FatherA = "1";
                }
                else
                {
                    data_this.FatherA = "0";
                }
            }
            catch
            {
                data_this.FatherA = "1";
            }
            try
            {
                if (State == FormState.New)
                {
                    if (comboBox_InsuranceType.SelectedIndex > 0)
                    {
                        data_this.Insurance_Name = textBox_Insurance_Class.Text;
                    }
                    else
                    {
                        data_this.Insurance_Name = string.Empty;
                    }
                }
            }
            catch
            {
                data_this.Insurance_Name = string.Empty;
            }
            try
            {
                if (State == FormState.New)
                {
                    if (comboBox_InsuranceType.SelectedIndex > 0)
                    {
                        data_this.InsuranceNo = int.Parse(comboBox_InsuranceType.SelectedValue.ToString());
                    }
                    else
                    {
                        data_this.InsuranceNo = null;
                    }
                }
            }
            catch
            {
                data_this.InsuranceNo = null;
            }
            string vD = string.Empty;
            string vD2 = string.Empty;
            string vD3 = string.Empty;
            string vD4 = string.Empty;
            if (VarGeneral.CheckDate(dateTimeInput_LastFilter.Text))
            {
                vD = Convert.ToDateTime(dateTimeInput_LastFilter.Text).ToString("yyyy/MM/dd");
            }
            if (VarGeneral.CheckDate(dateTimeInput_DateAppointment.Text))
            {
                vD2 = Convert.ToDateTime(dateTimeInput_DateAppointment.Text).ToString("yyyy/MM/dd");
            }
            if (VarGeneral.CheckDate(dateTimeInput_EndContr.Text))
            {
                vD3 = Convert.ToDateTime(dateTimeInput_EndContr.Text).ToString("yyyy/MM/dd");
            }
            double TicketUse = 0.0;
            int VacUse = 0;
            TicketUse = db.ExecuteQuery<double>("select dbo.GetTickeUsed('" + data_this.Emp_ID + "')", new object[0]).FirstOrDefault();
            VacUse = db.ExecuteQuery<int>("select dbo.GetVacUsed('" + data_this.Emp_ID + "')", new object[0]).FirstOrDefault();
            vD4 = (VarGeneral.CheckDate(vD) ? vD : vD2);
            if (State == FormState.New)
            {
                textBox_TicketsBalance.Value = db.TicktAmount(vD2, n.IsGreg(vD2) ? n.FormatGreg(VarGeneral.Gdate, "yyyy/MM/dd") : n.FormatHijri(VarGeneral.Hdate, "yyyy/MM/dd"), textBox_TicketsCount.Value) - TicketUse;
                textBox_VacationBalance.Value = db.VacAmount(vD2, n.IsGreg(vD2) ? n.FormatGreg(VarGeneral.Gdate, "yyyy/MM/dd") : n.FormatHijri(VarGeneral.Hdate, "yyyy/MM/dd"), textBox_VacationCount.Value) - VacUse;
            }
            else
            {
                textBox_TicketsBalance.Value = db.TicktAmount(vD4, VarGeneral.CheckDate(vD3) ? vD3 : (n.IsGreg(vD4) ? n.FormatGreg(VarGeneral.Gdate, "yyyy/MM/dd") : n.FormatHijri(VarGeneral.Hdate, "yyyy/MM/dd")), textBox_TicketsCount.Value) - TicketUse;
                textBox_VacationBalance.Value = db.VacAmount(vD4, VarGeneral.CheckDate(vD3) ? vD3 : (n.IsGreg(vD4) ? n.FormatGreg(VarGeneral.Gdate, "yyyy/MM/dd") : n.FormatHijri(VarGeneral.Hdate, "yyyy/MM/dd")), textBox_VacationCount.Value) - VacUse;
            }
            try
            {
                data_this.VacationBalance = textBox_VacationBalance.Value;
            }
            catch
            {
                data_this.VacationBalance = 0.0;
            }
            try
            {
                data_this.TicketsBalance = textBox_TicketsBalance.Value;
            }
            catch
            {
                data_this.TicketsBalance = 0.0;
            }
            data_this.CompanyID = null;
            try
            {
                if (!string.IsNullOrEmpty(textBox_AccSal.Text))
                {
                    data_this.SalAcc = textBox_AccSal.Text;
                }
                else
                {
                    data_this.SalAcc = null;
                }
            }
            catch
            {
                data_this.SalAcc = null;
            }
            try
            {
                if (!string.IsNullOrEmpty(textBox_AccLoan.Text))
                {
                    data_this.LoanAcc = textBox_AccLoan.Text;
                }
                else
                {
                    data_this.LoanAcc = null;
                }
            }
            catch
            {
                data_this.LoanAcc = null;
            }
            try
            {
                if (!string.IsNullOrEmpty(textBox_AccHousing.Text))
                {
                    data_this.HouseAcc = textBox_AccHousing.Text;
                }
                else
                {
                    data_this.HouseAcc = null;
                }
            }
            catch
            {
                data_this.HouseAcc = null;
            }
            try
            {
                if (!string.IsNullOrEmpty(textBox_CostCenter.Text))
                {
                    data_this.CostCenterEmp = int.Parse(textBox_CostCenter.Text);
                }
                else
                {
                    data_this.CostCenterEmp = null;
                }
            }
            catch
            {
                data_this.CostCenterEmp = null;
            }
            if (switchButton_AccType.Value)
            {
                try
                {
                    if (!string.IsNullOrEmpty(txtBXBankNo.Text))
                    {
                        data_this.AccountID = txtBXBankNo.Text;
                    }
                    else
                    {
                        data_this.AccountID = null;
                    }
                }
                catch
                {
                    data_this.AccountID = null;
                }
                data_this.BankBR = null;
            }
            else
            {
                try
                {
                    if (!string.IsNullOrEmpty(txtBXBankNo.Text))
                    {
                        data_this.AccountID = txtBXBankNo.Text;
                    }
                    else
                    {
                        data_this.AccountID = null;
                    }
                }
                catch
                {
                    data_this.AccountID = null;
                }
                data_this.BankBR = null;
            }
            try
            {
                data_this.Allowances = int.Parse(comboBox_Allowances.Text);
            }
            catch
            {
                data_this.Allowances = 0;
            }
            try
            {
                data_this.AllowancesTime = comboBox_AllowancesTime.SelectedIndex;
            }
            catch
            {
                data_this.AllowancesTime = 0;
            }
            return data_this;
        }
        private void Save_DataAttend()
        {
            for (int i = 0; i <= 6; i++)
            {
                Datathis_Attend = new T_Attend();
                if (State == FormState.Edit)
                {
                    Data_this_Attend = Update_Attend[i];
                }
                switch (i)
                {
                    case 0:
                        try
                        {
                            Datathis_Attend.EmpID = textBox_ID.Tag.ToString();
                        }
                        catch
                        {
                        }
                        try
                        {
                            Datathis_Attend.Day_No = i + 1;
                        }
                        catch
                        {
                        }
                        try
                        {
                            Datathis_Attend.Time1 = TimeSpan.Parse(textBox_SatTime1.Text).ToString();
                        }
                        catch
                        {
                            Datathis_Attend.Time1 = "__:__";
                        }
                        try
                        {
                            Datathis_Attend.Time2 = TimeSpan.Parse(textBox_SatTime2.Text).ToString();
                        }
                        catch
                        {
                            Datathis_Attend.Time2 = "__:__";
                        }
                        try
                        {
                            Datathis_Attend.TimeAllow1 = TimeSpan.Parse(textBox_SatTimeAllow1.Text).ToString();
                        }
                        catch
                        {
                            Datathis_Attend.TimeAllow1 = "__:__";
                        }
                        try
                        {
                            Datathis_Attend.TimeAlow2 = TimeSpan.Parse(textBox_SatTimeAllow2.Text).ToString();
                        }
                        catch
                        {
                            Datathis_Attend.TimeAlow2 = "__:__";
                        }
                        try
                        {
                            Datathis_Attend.LeaveTime1 = TimeSpan.Parse(textBox_SatLeaveTime1.Text).ToString();
                        }
                        catch
                        {
                            Datathis_Attend.LeaveTime1 = "__:__";
                        }
                        try
                        {
                            Datathis_Attend.LeaveTime2 = TimeSpan.Parse(textBox_SatLeaveTime2.Text).ToString();
                        }
                        catch
                        {
                            Datathis_Attend.LeaveTime2 = "__:__";
                        }
                        if (radioButton_SatPeriods1.Checked)
                        {
                            Datathis_Attend.Periods = 1;
                        }
                        else if (radioButton_SatPeriods2.Checked)
                        {
                            Datathis_Attend.Periods = 2;
                        }
                        else
                        {
                            Datathis_Attend.Periods = 0;
                        }
                        break;
                    case 1:
                        try
                        {
                            Datathis_Attend.EmpID = textBox_ID.Tag.ToString();
                        }
                        catch
                        {
                        }
                        try
                        {
                            Datathis_Attend.Day_No = i + 1;
                        }
                        catch
                        {
                        }
                        try
                        {
                            Datathis_Attend.Time1 = TimeSpan.Parse(textBox_SunTime1.Text).ToString();
                        }
                        catch
                        {
                            Datathis_Attend.Time1 = "__:__";
                        }
                        try
                        {
                            Datathis_Attend.Time2 = TimeSpan.Parse(textBox_SunTime2.Text).ToString();
                        }
                        catch
                        {
                            Datathis_Attend.Time2 = "__:__";
                        }
                        try
                        {
                            Datathis_Attend.TimeAllow1 = TimeSpan.Parse(textBox_SunTimeAllow1.Text).ToString();
                        }
                        catch
                        {
                            Datathis_Attend.TimeAllow1 = "__:__";
                        }
                        try
                        {
                            Datathis_Attend.TimeAlow2 = TimeSpan.Parse(textBox_SunTimeAllow2.Text).ToString();
                        }
                        catch
                        {
                            Datathis_Attend.TimeAlow2 = "__:__";
                        }
                        try
                        {
                            Datathis_Attend.LeaveTime1 = TimeSpan.Parse(textBox_SunLeaveTime1.Text).ToString();
                        }
                        catch
                        {
                            Datathis_Attend.LeaveTime1 = "__:__";
                        }
                        try
                        {
                            Datathis_Attend.LeaveTime2 = TimeSpan.Parse(textBox_SunLeaveTime2.Text).ToString();
                        }
                        catch
                        {
                            Datathis_Attend.LeaveTime2 = "__:__";
                        }
                        if (radioButton_SunPeriods1.Checked)
                        {
                            Datathis_Attend.Periods = 1;
                        }
                        else if (radioButton_SunPeriods2.Checked)
                        {
                            Datathis_Attend.Periods = 2;
                        }
                        else
                        {
                            Datathis_Attend.Periods = 0;
                        }
                        break;
                    case 2:
                        try
                        {
                            Datathis_Attend.EmpID = textBox_ID.Tag.ToString();
                        }
                        catch
                        {
                        }
                        try
                        {
                            Datathis_Attend.Day_No = i + 1;
                        }
                        catch
                        {
                        }
                        try
                        {
                            Datathis_Attend.Time1 = TimeSpan.Parse(textBox_MonTime1.Text).ToString();
                        }
                        catch
                        {
                            Datathis_Attend.Time1 = "__:__";
                        }
                        try
                        {
                            Datathis_Attend.Time2 = TimeSpan.Parse(textBox_MonTime2.Text).ToString();
                        }
                        catch
                        {
                            Datathis_Attend.Time2 = "__:__";
                        }
                        try
                        {
                            Datathis_Attend.TimeAllow1 = TimeSpan.Parse(textBox_MonTimeAllow1.Text).ToString();
                        }
                        catch
                        {
                            Datathis_Attend.TimeAllow1 = "__:__";
                        }
                        try
                        {
                            Datathis_Attend.TimeAlow2 = TimeSpan.Parse(textBox_MonTimeAllow2.Text).ToString();
                        }
                        catch
                        {
                            Datathis_Attend.TimeAlow2 = "__:__";
                        }
                        try
                        {
                            Datathis_Attend.LeaveTime1 = TimeSpan.Parse(textBox_MonLeaveTime1.Text).ToString();
                        }
                        catch
                        {
                            Datathis_Attend.LeaveTime1 = "__:__";
                        }
                        try
                        {
                            Datathis_Attend.LeaveTime2 = TimeSpan.Parse(textBox_MonLeaveTime2.Text).ToString();
                        }
                        catch
                        {
                            Datathis_Attend.LeaveTime2 = "__:__";
                        }
                        if (radioButton_MonPeriods1.Checked)
                        {
                            Datathis_Attend.Periods = 1;
                        }
                        else if (radioButton_MonPeriods2.Checked)
                        {
                            Datathis_Attend.Periods = 2;
                        }
                        else
                        {
                            Datathis_Attend.Periods = 0;
                        }
                        break;
                    case 3:
                        try
                        {
                            Datathis_Attend.EmpID = textBox_ID.Tag.ToString();
                        }
                        catch
                        {
                        }
                        try
                        {
                            Datathis_Attend.Day_No = i + 1;
                        }
                        catch
                        {
                        }
                        try
                        {
                            Datathis_Attend.Time1 = TimeSpan.Parse(textBox_TusTime1.Text).ToString();
                        }
                        catch
                        {
                            Datathis_Attend.Time1 = "__:__";
                        }
                        try
                        {
                            Datathis_Attend.Time2 = TimeSpan.Parse(textBox_TusTime2.Text).ToString();
                        }
                        catch
                        {
                            Datathis_Attend.Time2 = "__:__";
                        }
                        try
                        {
                            Datathis_Attend.TimeAllow1 = TimeSpan.Parse(textBox_TusTimeAllow1.Text).ToString();
                        }
                        catch
                        {
                            Datathis_Attend.TimeAllow1 = "__:__";
                        }
                        try
                        {
                            Datathis_Attend.TimeAlow2 = TimeSpan.Parse(textBox_TusTimeAllow2.Text).ToString();
                        }
                        catch
                        {
                            Datathis_Attend.TimeAlow2 = "__:__";
                        }
                        try
                        {
                            Datathis_Attend.LeaveTime1 = TimeSpan.Parse(textBox_TusLeaveTime1.Text).ToString();
                        }
                        catch
                        {
                            Datathis_Attend.LeaveTime1 = "__:__";
                        }
                        try
                        {
                            Datathis_Attend.LeaveTime2 = TimeSpan.Parse(textBox_TusLeaveTime2.Text).ToString();
                        }
                        catch
                        {
                            Datathis_Attend.LeaveTime2 = "__:__";
                        }
                        if (radioButton_TusPeriods1.Checked)
                        {
                            Datathis_Attend.Periods = 1;
                        }
                        else if (radioButton_TusPeriods2.Checked)
                        {
                            Datathis_Attend.Periods = 2;
                        }
                        else
                        {
                            Datathis_Attend.Periods = 0;
                        }
                        break;
                    case 4:
                        try
                        {
                            Datathis_Attend.EmpID = textBox_ID.Tag.ToString();
                        }
                        catch
                        {
                        }
                        try
                        {
                            Datathis_Attend.Day_No = i + 1;
                        }
                        catch
                        {
                        }
                        try
                        {
                            Datathis_Attend.Time1 = TimeSpan.Parse(textBox_WenTime1.Text).ToString();
                        }
                        catch
                        {
                            Datathis_Attend.Time1 = "__:__";
                        }
                        try
                        {
                            Datathis_Attend.Time2 = TimeSpan.Parse(textBox_WenTime2.Text).ToString();
                        }
                        catch
                        {
                            Datathis_Attend.Time2 = "__:__";
                        }
                        try
                        {
                            Datathis_Attend.TimeAllow1 = TimeSpan.Parse(textBox_WenTimeAllow1.Text).ToString();
                        }
                        catch
                        {
                            Datathis_Attend.TimeAllow1 = "__:__";
                        }
                        try
                        {
                            Datathis_Attend.TimeAlow2 = TimeSpan.Parse(textBox_WenTimeAllow2.Text).ToString();
                        }
                        catch
                        {
                            Datathis_Attend.TimeAlow2 = "__:__";
                        }
                        try
                        {
                            Datathis_Attend.LeaveTime1 = TimeSpan.Parse(textBox_WenLeaveTime1.Text).ToString();
                        }
                        catch
                        {
                            Datathis_Attend.LeaveTime1 = "__:__";
                        }
                        try
                        {
                            Datathis_Attend.LeaveTime2 = TimeSpan.Parse(textBox_WenLeaveTime2.Text).ToString();
                        }
                        catch
                        {
                            Datathis_Attend.LeaveTime2 = "__:__";
                        }
                        if (radioButton_WenPeriods1.Checked)
                        {
                            Datathis_Attend.Periods = 1;
                        }
                        else if (radioButton_WenPeriods2.Checked)
                        {
                            Datathis_Attend.Periods = 2;
                        }
                        else
                        {
                            Datathis_Attend.Periods = 0;
                        }
                        break;
                    case 5:
                        try
                        {
                            Datathis_Attend.EmpID = textBox_ID.Tag.ToString();
                        }
                        catch
                        {
                        }
                        try
                        {
                            Datathis_Attend.Day_No = i + 1;
                        }
                        catch
                        {
                        }
                        try
                        {
                            Datathis_Attend.Time1 = TimeSpan.Parse(textBox_ThurTime1.Text).ToString();
                        }
                        catch
                        {
                            Datathis_Attend.Time1 = "__:__";
                        }
                        try
                        {
                            Datathis_Attend.Time2 = TimeSpan.Parse(textBox_ThurTime2.Text).ToString();
                        }
                        catch
                        {
                            Datathis_Attend.Time2 = "__:__";
                        }
                        try
                        {
                            Datathis_Attend.TimeAllow1 = TimeSpan.Parse(textBox_ThurTimeAllow1.Text).ToString();
                        }
                        catch
                        {
                            Datathis_Attend.TimeAllow1 = "__:__";
                        }
                        try
                        {
                            Datathis_Attend.TimeAlow2 = TimeSpan.Parse(textBox_ThurTimeAllow2.Text).ToString();
                        }
                        catch
                        {
                            Datathis_Attend.TimeAlow2 = "__:__";
                        }
                        try
                        {
                            Datathis_Attend.LeaveTime1 = TimeSpan.Parse(textBox_ThurLeaveTime1.Text).ToString();
                        }
                        catch
                        {
                            Datathis_Attend.LeaveTime1 = "__:__";
                        }
                        try
                        {
                            Datathis_Attend.LeaveTime2 = TimeSpan.Parse(textBox_ThurLeaveTime2.Text).ToString();
                        }
                        catch
                        {
                            Datathis_Attend.LeaveTime2 = "__:__";
                        }
                        if (radioButton_ThurPeriods1.Checked)
                        {
                            Datathis_Attend.Periods = 1;
                        }
                        else if (radioButton_ThurPeriods2.Checked)
                        {
                            Datathis_Attend.Periods = 2;
                        }
                        else
                        {
                            Datathis_Attend.Periods = 0;
                        }
                        break;
                    case 6:
                        try
                        {
                            Datathis_Attend.EmpID = textBox_ID.Tag.ToString();
                        }
                        catch
                        {
                        }
                        try
                        {
                            Datathis_Attend.Day_No = i + 1;
                        }
                        catch
                        {
                        }
                        try
                        {
                            Datathis_Attend.Time1 = TimeSpan.Parse(textBox_FriTime1.Text).ToString();
                        }
                        catch
                        {
                            Datathis_Attend.Time1 = "__:__";
                        }
                        try
                        {
                            Datathis_Attend.Time2 = TimeSpan.Parse(textBox_FriTime2.Text).ToString();
                        }
                        catch
                        {
                            Datathis_Attend.Time2 = "__:__";
                        }
                        try
                        {
                            Datathis_Attend.TimeAllow1 = TimeSpan.Parse(textBox_FriTimeAllow1.Text).ToString();
                        }
                        catch
                        {
                            Datathis_Attend.TimeAllow1 = "__:__";
                        }
                        try
                        {
                            Datathis_Attend.TimeAlow2 = TimeSpan.Parse(textBox_FriTimeAllow2.Text).ToString();
                        }
                        catch
                        {
                            Datathis_Attend.TimeAlow2 = "__:__";
                        }
                        try
                        {
                            Datathis_Attend.LeaveTime1 = TimeSpan.Parse(textBox_LeaveTime1.Text).ToString();
                        }
                        catch
                        {
                            Datathis_Attend.LeaveTime1 = "__:__";
                        }
                        try
                        {
                            Datathis_Attend.LeaveTime2 = TimeSpan.Parse(textBox_ThurLeaveTime2.Text).ToString();
                        }
                        catch
                        {
                            Datathis_Attend.LeaveTime2 = "__:__";
                        }
                        if (radioButton_FriPeriods1.Checked)
                        {
                            Datathis_Attend.Periods = 1;
                        }
                        else if (radioButton_FriPeriods2.Checked)
                        {
                            Datathis_Attend.Periods = 2;
                        }
                        else
                        {
                            Datathis_Attend.Periods = 0;
                        }
                        break;
                }
                try
                {
                    if (State == FormState.New)
                    {
                        Guid Newid = Guid.NewGuid();
                        Data_this_Attend.Attend_ID = Newid.ToString();
                        db.T_Attends.InsertOnSubmit(Datathis_Attend);
                        db.SubmitChanges();
                    }
                    else
                    {
                        db.Log = VarGeneral.DebugLog;
                        db.SubmitChanges(ConflictMode.ContinueOnConflict);
                    }
                }
                catch (Exception error)
                {
                    VarGeneral.DebLog.writeLog("FormEmpOn_Save_DataAttend:", error, enable: true);
                    MessageBox.Show(error.Message);
                }
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
        private void Button_Add_Click(object sender, EventArgs e)
        {
            if (!Button_Add.Visible || !Button_Add.Enabled)
            {
                MessageBox.Show((LangArEn == 0) ? "لا يمكن اتمام هذه العملية .. الرجاء مراجعة صلاحيات المستخدمين !" : "Can not complete this process .. please see the powers of the users!", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else if (State != FormState.Edit || MessageBox.Show((LangArEn == 0) ? "تم تعديل السجل الحالي دون حفظ التغييرات .. هل تريد المتابعة؟" : "Not saved the changes, do you really want to continue?", VarGeneral.ProdectNam, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                int max = 0;
                max = db.MaxEmpsNo;
                Clear();
                textBox_ID.Text = max.ToString();
                State = FormState.New;
            }
        }
        private bool ValidData()
        {
            try
            {
                if (int.Parse(textBox_ID.Text) <= 0)
                {
                    MessageBox.Show((LangArEn == 0) ? " خطأ,, الرجاء التأكد من رقم الموظف " : "error, please make sure of the Employee No", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    textBox_ID.Focus();
                    return false;
                }
            }
            catch
            {
            }
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
            if (textBox_ID.Text == string.Empty)
            {
                MessageBox.Show((LangArEn == 0) ? "لايمكن ان يكون الرمز" : "Can not be a number is empty", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                textBox_ID.Focus();
                return false;
            }
            if (textBox_NameA.Text == string.Empty)
            {
                MessageBox.Show((LangArEn == 0) ? "لايمكن ان يكون الإسم فارغا\u0651" : "Can not be a name is empty", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                textBox_NameA.Focus();
                return false;
            }
            if (textBox_NameE.Text == string.Empty)
            {
                MessageBox.Show((LangArEn == 0) ? "لايمكن ان يكون الإسم فارغا\u0651" : "Can not be a name is empty", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                textBox_NameE.Focus();
                return false;
            }
            T_Emp q = db.EmpsEmpNo(textBox_ID.Text);
            if (!string.IsNullOrEmpty(q.Emp_ID) && State == FormState.New)
            {
                MessageBox.Show((LangArEn == 0) ? " رقم الموظف مكرر يرجى تغييره" : "Employee No It's a existing", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                textBox_ID.Focus();
                return false;
            }
            if (comboBox_CalculateNo.SelectedIndex <= 0)
            {
                MessageBox.Show((LangArEn == 0) ? "يرجى اختيار طريقة الخصم والاضافي قبل عملية الحفظ" : "Most Select Method Overtime and Deducion Before Save", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                comboBox_CalculateNo.Focus();
                return false;
            }
            if (comboBox_ContrTyp.SelectedIndex <= 0)
            {
                MessageBox.Show((LangArEn == 0) ? "يرجى اختيار نوع العقد قبل عملية الحفظ" : "Most Select Contract Type Before Save", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                comboBox_CalculateNo.Focus();
                return false;
            }
            if (comboBox_Dept.SelectedIndex <= 0)
            {
                MessageBox.Show((LangArEn == 0) ? "لايمكن ان يكون اسم الإدارة فارغا" : "Can not be a dept name is empty", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                comboBox_Dept.Focus();
                return false;
            }
            if (comboBox_Guarantor.SelectedIndex <= 0 && VarGeneral.Settings_Sys.Sponer.Value)
            {
                MessageBox.Show((LangArEn == 0) ? "لايمكن ان يكون اسم الكفيل فارغا" : "Can not be a Sponser name is empty", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                comboBox_Guarantor.Focus();
                return false;
            }
            if (comboBox_Job.SelectedIndex <= 0)
            {
                MessageBox.Show((LangArEn == 0) ? "لايمكن ان يكون اسم الوظيفة فارغا" : "Can not be a Job name is empty", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                comboBox_Job.Focus();
                return false;
            }
            if (comboBox_Section.SelectedIndex <= 0)
            {
                MessageBox.Show((LangArEn == 0) ? "لايمكن ان يكون اسم الفسم فارغا" : "Can not be a Section name is empty", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                comboBox_Section.Focus();
                return false;
            }
            if (textBox_DayOfMonth.Value <= 0)
            {
                MessageBox.Show((LangArEn == 0) ? "يجب تحديد عدد الأيام/الشهر" : "Most Set days of month", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                textBox_DayOfMonth.Focus();
                return false;
            }
            if (!VarGeneral.CheckDate(dateTimeInput_DateAppointment.Text))
            {
                MessageBox.Show((LangArEn == 0) ? "تحقق من تاريخ التعيين" : "Check the Apponintment Date", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                dateTimeInput_DateAppointment.Focus();
                return false;
            }
            if (VarGeneral.CheckDate(dateTimeInput_StartContr.Text) && VarGeneral.CheckDate(dateTimeInput_EndContr.Text) && Convert.ToDateTime(dateTimeInput_EndContr.Text) < Convert.ToDateTime(dateTimeInput_StartContr.Text))
            {
                MessageBox.Show((LangArEn == 0) ? "تأكد من صحة تاريخ بداية ونهاية العقد " : "Start Date and End Date is Uncorrecte", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                dateTimeInput_EndContr.Text = string.Empty;
                dateTimeInput_StartContr.Focus();
                return false;
            }
            return true;
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
                if (!ValidData())
                {
                    return;
                }
                try
                {
                    dateTimeInput_DateAppointment.Text = Convert.ToDateTime(dateTimeInput_DateAppointment.Text).ToString("yyyy/MM/dd");
                }
                catch
                {
                    MessageBox.Show((LangArEn == 0) ? "تحقق من تاريخ التعيين" : "Check the Apponintment Date", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    dateTimeInput_DateAppointment.Focus();
                    return;
                }
                if (State == FormState.New)
                {
                    try
                    {
                        GetData();
                        data_this.Emp_ID = textBox_ID.Tag.ToString();
                        db.T_Emps.InsertOnSubmit(data_this);
                        db.SubmitChanges();
                        Save_DataAttend();
                    }
                    catch (SqlException error2)
                    {
                        int max = 0;
                        max = db.MaxEmpsNo;
                        if (error2.Number == 2627)
                        {
                            MessageBox.Show((LangArEn == 0) ? ("رقم الأمر مستخدم من قبل.\nسيتم الحفظ برقم جديد [" + max + "]") : ("This No is user before.\nWill be save a new number [" + max + "]"), VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            textBox_ID.TextChanged -= textBox_ID_TextChanged;
                            textBox_ID.Text = string.Concat(max);
                            textBox_ID.TextChanged += textBox_ID_TextChanged;
                            data_this.Emp_No = string.Concat(max);
                            Guid id = Guid.NewGuid();
                            data_this.Emp_ID = id.ToString();
                            textBox_ID.Tag = data_this.Emp_ID;
                            Button_Save_Click(sender, e);
                        }
                        else
                        {
                            VarGeneral.DebLog.writeLog("Button_Save_Click:", error2, enable: true);
                            MessageBox.Show(error2.Message);
                        }
                        return;
                    }
                }
                else if (State == FormState.Edit)
                {
                    string vEmpNo = data_this.Emp_No;
                    try
                    {
                        db.ExecuteCommand("Update T_Emp Set HouseAcc= null where Emp_ID='" + data_this.Emp_ID + "'");
                    }
                    catch
                    {
                    }
                    dbInstance = null;
                    data_this = db.EmpsEmp(data_this.Emp_ID);
                    GetData();
                    Refresh();
                    try
                    {
                        if (vEmpNo != data_this.Emp_No)
                        {
                            for (int i = 0; i < listBox_ImageFiles.Items.Count; i++)
                            {
                                try
                                {
                                    Microsoft.VisualBasic.FileIO.FileSystem.RenameFile(string.IsNullOrEmpty(VarGeneral.Settings_Sys.DocumentPath) ? (Application.StartupPath + "\\EmpDocuments\\" + listBox_ImageFiles.Items[i]) : (VarGeneral.Settings_Sys.DocumentPath + "\\" + listBox_ImageFiles.Items[i]), data_this.Emp_No + listBox_ImageFiles.Items[i].ToString().Substring(vEmpNo.Length));
                                }
                                catch
                                {
                                }
                            }
                            FillImageList();
                        }
                    }
                    catch
                    {
                    }
                    db.Log = VarGeneral.DebugLog;
                    db.SubmitChanges(ConflictMode.ContinueOnConflict);
                    Save_DataAttend();
                }
                State = FormState.Saved;
                RefreshPKeys();
                TextBox_Index.TextBox.Text = string.Concat(PKeys.IndexOf(data_this.Emp_No ?? string.Empty) + 1);
                dbInstance = null;
                textBox_ID_TextChanged(sender, e);
                SetReadOnly = true;
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Button_Save_Click:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void Button_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(textBox_ID.Text))
                {
                    return;
                }
                if (!Button_Delete.Enabled || !Button_Delete.Visible)
                {
                    ifOkDelete = false;
                    return;
                }
                if (!checkEmpOperate(textBox_ID.Tag.ToString()))
                {
                    MessageBox.Show((LangArEn == 0) ? "لايمكن حذف الموظف .. لان عليه حركات سابقة" : "You can not delete Employee ..", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
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
                if (data_this == null || string.IsNullOrEmpty(data_this.Emp_ID) || !ifOkDelete)
                {
                    return;
                }
                data_this = db.EmpsEmp(DataThis.Emp_ID);
                if (db.CheckEmp_Attend(data_this.Emp_ID))
                {
                    db.T_Attends.DeleteAllOnSubmit(data_this.T_Attends);
                    db.SubmitChanges();
                }
                if (db.CheckEmp_AttendOpetation(data_this.Emp_ID))
                {
                    db.T_AttendOperats.DeleteAllOnSubmit(data_this.T_AttendOperats);
                    db.SubmitChanges();
                }
                if (db.CheckEmp_Family(textBox_ID.Tag.ToString()))
                {
                    db.T_Families.DeleteAllOnSubmit(data_this.T_Families);
                    db.SubmitChanges();
                }
                db.T_Advances.DeleteAllOnSubmit(data_this.T_Advances);
                db.SubmitChanges();
                db.T_Authorizations.DeleteAllOnSubmit(data_this.T_Authorizations);
                db.SubmitChanges();
                db.T_Rewards.DeleteAllOnSubmit(data_this.T_Rewards);
                db.SubmitChanges();
                db.T_SalDiscounts.DeleteAllOnSubmit(data_this.T_SalDiscounts);
                db.SubmitChanges();
                db.T_Tickets.DeleteAllOnSubmit(data_this.T_Tickets);
                db.SubmitChanges();
                db.T_Vacations.DeleteAllOnSubmit(data_this.T_Vacations);
                db.SubmitChanges();
                db.T_Adds.DeleteAllOnSubmit(data_this.T_Adds);
                db.SubmitChanges();
                db.T_Emps.DeleteOnSubmit(DataThis);
                db.SubmitChanges();
                for (int i = 0; i < listBox_ImageFiles.Items.Count; i++)
                {
                    try
                    {
                        File.Delete(string.IsNullOrEmpty(VarGeneral.Settings_Sys.DocumentPath) ? (Application.StartupPath + "\\EmpDocuments\\" + listBox_ImageFiles.Items[i]) : (VarGeneral.Settings_Sys.DocumentPath + "\\" + listBox_ImageFiles.Items[i]));
                    }
                    catch
                    {
                    }
                }
                Clear();
                RefreshPKeys();
                textBox_ID.Text = PKeys.LastOrDefault();
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Button_Delete_Click:", error, enable: true);
                MessageBox.Show(error.Message);
                DataThis = db.EmpsEmp(DataThis.Emp_ID);
            }
        }
        private bool checkEmpOperate(string value)
        {
            try
            {
                if (db.CheckEmp_Add(data_this.Emp_ID))
                {
                    return false;
                }
                if (db.CheckEmp_Addvance(data_this.Emp_ID))
                {
                    return false;
                }
                if (db.CheckEmp_Authorization(data_this.Emp_ID))
                {
                    return false;
                }
                if (db.CheckEmp_Discount(data_this.Emp_ID))
                {
                    return false;
                }
                if (db.CheckEmp_Reward(data_this.Emp_ID))
                {
                    return false;
                }
                if (db.CheckEmp_Ticket(data_this.Emp_ID))
                {
                    return false;
                }
                if (db.CheckEmp_vacation(data_this.Emp_ID))
                {
                    return false;
                }
                if (db.CheckEmp_Salary(data_this.Emp_ID))
                {
                    return false;
                }
                return true;
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("FrmEmpOn_checkEmpOperate:", error, enable: true);
                return false;
            }
        }
        private void DGV_Main_DataBindingComplete(object sender, GridDataBindingCompleteEventArgs e)
        {
            GridPanel panel = e.GridPanel;
            string dataMember = panel.DataMember;
            if (dataMember != null && dataMember == "T_Emp")
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
            panel.Columns["Emp_No"].Width = 120;
            panel.Columns["Emp_No"].Visible = columns_Names_visible["Emp_No"].IfDefault;
            panel.Columns["NameA"].Width = 250;
            panel.Columns["NameA"].Visible = columns_Names_visible["NameA"].IfDefault;
            panel.Columns["NameE"].Width = 250;
            panel.Columns["NameE"].Visible = columns_Names_visible["NameE"].IfDefault;
            panel.Columns["StartContr"].Width = 100;
            panel.Columns["StartContr"].Visible = columns_Names_visible["StartContr"].IfDefault;
            panel.Columns["EndContr"].Width = 100;
            panel.Columns["EndContr"].Visible = columns_Names_visible["EndContr"].IfDefault;
            panel.Columns["MainSal"].Width = 150;
            panel.Columns["MainSal"].Visible = columns_Names_visible["MainSal"].IfDefault;
            panel.Columns["ID_No"].Width = 120;
            panel.Columns["ID_No"].Visible = columns_Names_visible["ID_No"].IfDefault;
            panel.Columns["Passport_No"].Width = 120;
            panel.Columns["Passport_No"].Visible = columns_Names_visible["Passport_No"].IfDefault;
            panel.Columns["AddressA"].Width = 250;
            panel.Columns["AddressA"].Visible = columns_Names_visible["AddressA"].IfDefault;
            panel.Columns["Tel"].Width = 200;
            panel.Columns["Tel"].Visible = columns_Names_visible["Tel"].IfDefault;
            panel.Columns["Note"].Width = 399;
            panel.Columns["Note"].Visible = columns_Names_visible["Note"].IfDefault;
            panel.ReadOnly = true;
        }
        private void DGV_MainGetCellStyle(object sender, GridGetCellStyleEventArgs e)
        {
        }
        private void Button_ExportTable2_Click(object sender, EventArgs e)
        {
            try
            {
                ExportExcel.ExportToExcel(DGV_Main, "تقرير الموظفــــين");
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
            if (ViewState == ViewState.Table)
            {
                VarGeneral.IsGeneralUsed = true;
                FrmReportsViewer frm = new FrmReportsViewer();
                frm.Repvalue = "EmpsRepShort";



                frm.Tag = LangArEn;
                frm.Repvalue = "EmpsRepShort";
                VarGeneral.vTitle = Text;
                frm.SqlWhere = string.Empty;
                frm.TopMost = true;
                frm.ShowDialog();
                VarGeneral.IsGeneralUsed = false;

            }
        }
        private void button_AddNewDept_Click(object sender, EventArgs e)
        {
            FrmDept frm = new FrmDept();
            frm.Tag = LangArEn;
            string vList = string.Empty;
            if (comboBox_Dept.SelectedIndex > 0)
            {
                vList = comboBox_Dept.SelectedValue.ToString();
            }
            frm.TopMost = true;
            frm.ShowDialog();
            Stock_DataDataContext dbc = new Stock_DataDataContext(VarGeneral.BranchCS);
            List<T_Dept> listDept = new List<T_Dept>(dbc.T_Depts.Select((T_Dept item) => item).ToList());
            listDept.Insert(0, new T_Dept());
            comboBox_Dept.DataSource = null;
            comboBox_Dept.DataSource = listDept;
            comboBox_Dept.DisplayMember = ((LangArEn == 0) ? "NameA" : "NameE");
            comboBox_Dept.ValueMember = "Dept_No";
            if (vList != string.Empty)
            {
                for (int i = 0; i < comboBox_Dept.Items.Count; i++)
                {
                    comboBox_Dept.SelectedIndex = i;
                    if (comboBox_Dept.SelectedValue.ToString() == vList)
                    {
                        break;
                    }
                }
            }
            else
            {
                comboBox_Dept.SelectedIndex = 0;
            }
        }
        private void button_SrchDept_Click(object sender, EventArgs e)
        {
            try
            {
                Button_Edit_Click(sender, e);
                Dir_ButSearch.Add("Dept_No", new ColumnDictinary("رقم الإدارة", "Department No", ifDefault: true, string.Empty));
                Dir_ButSearch.Add("NameA", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, string.Empty));
                Dir_ButSearch.Add("NameE", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: false, string.Empty));
                Dir_ButSearch.Add("Note", new ColumnDictinary("الملاحظات", "Note", ifDefault: true, string.Empty));
                FrmSearch frm = new FrmSearch();
                frm.Tag = LangArEn;
                ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = Dir_ButSearch;
                foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
                {
                    frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
                }
                VarGeneral.SFrmTyp = "T_Dept";
                frm.TopMost = true;
                frm.ShowDialog();
                if (frm.SerachNo != string.Empty)
                {
                    comboBox_Dept.SelectedValue = int.Parse(frm.SerachNo);
                }
                Dir_ButSearch.Clear();
            }
            catch
            {
            }
        }
        private void button_AddNewJob_Click(object sender, EventArgs e)
        {
            FrmJob frm = new FrmJob();
            frm.Tag = LangArEn;
            string vList = string.Empty;
            if (comboBox_Job.SelectedIndex > 0)
            {
                vList = comboBox_Job.SelectedValue.ToString();
            }
            frm.TopMost = true;
            frm.ShowDialog();
            Stock_DataDataContext dbc = new Stock_DataDataContext(VarGeneral.BranchCS);
            List<T_Job> list = new List<T_Job>(dbc.T_Jobs.Select((T_Job item) => item).ToList());
            list.Insert(0, new T_Job());
            comboBox_Job.DataSource = null;
            comboBox_Job.DataSource = list;
            comboBox_Job.DisplayMember = ((LangArEn == 0) ? "NameA" : "NameE");
            comboBox_Job.ValueMember = "Job_No";
            if (vList != string.Empty)
            {
                for (int i = 0; i < comboBox_Job.Items.Count; i++)
                {
                    comboBox_Job.SelectedIndex = i;
                    if (comboBox_Job.SelectedValue.ToString() == vList)
                    {
                        break;
                    }
                }
            }
            else
            {
                comboBox_Job.SelectedIndex = 0;
            }
        }
        private void button_AddNewSection_Click(object sender, EventArgs e)
        {
            FrmSection frm = new FrmSection();
            frm.Tag = LangArEn;
            string vList = string.Empty;
            if (comboBox_Section.SelectedIndex > 0)
            {
                vList = comboBox_Section.SelectedValue.ToString();
            }
            frm.TopMost = true;
            frm.ShowDialog();
            Stock_DataDataContext dbc = new Stock_DataDataContext(VarGeneral.BranchCS);
            List<T_Section> list = new List<T_Section>(dbc.T_Sections.Select((T_Section item) => item).ToList());
            list.Insert(0, new T_Section());
            comboBox_Section.DataSource = null;
            comboBox_Section.DataSource = list;
            comboBox_Section.DisplayMember = ((LangArEn == 0) ? "NameA" : "NameE");
            comboBox_Section.ValueMember = "Section_No";
            if (vList != string.Empty)
            {
                for (int i = 0; i < comboBox_Section.Items.Count; i++)
                {
                    comboBox_Section.SelectedIndex = i;
                    if (comboBox_Section.SelectedValue.ToString() == vList)
                    {
                        break;
                    }
                }
            }
            else
            {
                comboBox_Section.SelectedIndex = 0;
            }
        }
        private void button_AddNewSponser_Click(object sender, EventArgs e)
        {
            FrmSponser frm = new FrmSponser();
            frm.Tag = LangArEn;
            string vList = string.Empty;
            if (comboBox_Guarantor.SelectedIndex > 0)
            {
                vList = comboBox_Guarantor.SelectedValue.ToString();
            }
            frm.TopMost = true;
            frm.ShowDialog();
            Stock_DataDataContext dbc = new Stock_DataDataContext(VarGeneral.BranchCS);
            List<T_Guarantor> list = new List<T_Guarantor>(dbc.T_Guarantors.Select((T_Guarantor item) => item).ToList());
            list.Insert(0, new T_Guarantor());
            comboBox_Guarantor.DataSource = null;
            comboBox_Guarantor.DataSource = list;
            comboBox_Guarantor.DisplayMember = ((LangArEn == 0) ? "NameA" : "NameE");
            comboBox_Guarantor.ValueMember = "Guarantor_No";
            if (vList != string.Empty)
            {
                for (int i = 0; i < comboBox_Guarantor.Items.Count; i++)
                {
                    comboBox_Guarantor.SelectedIndex = i;
                    if (comboBox_Guarantor.SelectedValue.ToString() == vList)
                    {
                        break;
                    }
                }
            }
            else
            {
                comboBox_Guarantor.SelectedIndex = 0;
            }
        }
        private void button_AddNewCity_Click(object sender, EventArgs e)
        {
            FrmCity frm = new FrmCity();
            frm.Tag = LangArEn;
            string vList = string.Empty;
            if (comboBox_CityNo.SelectedIndex > 0)
            {
                vList = comboBox_CityNo.SelectedValue.ToString();
            }
            frm.TopMost = true;
            frm.ShowDialog();
            Stock_DataDataContext dbc = new Stock_DataDataContext(VarGeneral.BranchCS);
            List<T_City> list = new List<T_City>(dbc.T_Cities.Select((T_City item) => item).ToList());
            list.Insert(0, new T_City());
            comboBox_CityNo.DataSource = null;
            comboBox_CityNo.DataSource = list;
            comboBox_CityNo.DisplayMember = ((LangArEn == 0) ? "NameA" : "NameE");
            comboBox_CityNo.ValueMember = "City_No";
            if (vList != string.Empty)
            {
                for (int i = 0; i < comboBox_CityNo.Items.Count; i++)
                {
                    comboBox_CityNo.SelectedIndex = i;
                    if (comboBox_CityNo.SelectedValue.ToString() == vList)
                    {
                        break;
                    }
                }
            }
            else
            {
                comboBox_CityNo.SelectedIndex = 0;
            }
        }
        private void button_AddNewNation_Click(object sender, EventArgs e)
        {
            FrmNation frm = new FrmNation();
            frm.Tag = LangArEn;
            string vList = string.Empty;
            if (comboBox_Nationalty.SelectedIndex > 0)
            {
                vList = comboBox_Nationalty.SelectedValue.ToString();
            }
            frm.TopMost = true;
            frm.ShowDialog();
            Stock_DataDataContext dbc = new Stock_DataDataContext(VarGeneral.BranchCS);
            List<T_Nationality> list = new List<T_Nationality>(dbc.T_Nationalities.Select((T_Nationality item) => item).ToList());
            list.Insert(0, new T_Nationality());
            comboBox_Nationalty.DataSource = null;
            comboBox_Nationalty.DataSource = list;
            comboBox_Nationalty.DisplayMember = ((LangArEn == 0) ? "NameA" : "NameE");
            comboBox_Nationalty.ValueMember = "Nation_No";
            if (vList != string.Empty)
            {
                for (int i = 0; i < comboBox_Nationalty.Items.Count; i++)
                {
                    comboBox_Nationalty.SelectedIndex = i;
                    if (comboBox_Nationalty.SelectedValue.ToString() == vList)
                    {
                        break;
                    }
                }
            }
            else
            {
                comboBox_Nationalty.SelectedIndex = 0;
            }
        }
        private void button_AddNewReligon_Click(object sender, EventArgs e)
        {
            FrmReligions frm = new FrmReligions();
            frm.Tag = LangArEn;
            string vList = string.Empty;
            if (comboBox_Religion.SelectedIndex > 0)
            {
                vList = comboBox_Religion.SelectedValue.ToString();
            }
            frm.TopMost = true;
            frm.ShowDialog();
            Stock_DataDataContext dbc = new Stock_DataDataContext(VarGeneral.BranchCS);
            List<T_Religion> list = new List<T_Religion>(dbc.T_Religions.Select((T_Religion item) => item).ToList());
            list.Insert(0, new T_Religion());
            comboBox_Religion.DataSource = null;
            comboBox_Religion.DataSource = list;
            comboBox_Religion.DisplayMember = ((LangArEn == 0) ? "NameA" : "NameE");
            comboBox_Religion.ValueMember = "Religion_No";
            if (vList != string.Empty)
            {
                for (int i = 0; i < comboBox_Religion.Items.Count; i++)
                {
                    comboBox_Religion.SelectedIndex = i;
                    if (comboBox_Religion.SelectedValue.ToString() == vList)
                    {
                        break;
                    }
                }
            }
            else
            {
                comboBox_Religion.SelectedIndex = 0;
            }
        }
        private void button_AddNewBoss_Click(object sender, EventArgs e)
        {
            FrmBoss frm = new FrmBoss();
            frm.Tag = LangArEn;
            string vList = string.Empty;
            if (comboBox_DirBoss.SelectedIndex > 0)
            {
                vList = comboBox_DirBoss.SelectedValue.ToString();
            }
            frm.TopMost = true;
            frm.ShowDialog();
            Stock_DataDataContext dbc = new Stock_DataDataContext(VarGeneral.BranchCS);
            List<T_Boss> list = new List<T_Boss>(dbc.T_Bosses.Select((T_Boss item) => item).ToList());
            list.Insert(0, new T_Boss());
            comboBox_DirBoss.DataSource = null;
            comboBox_DirBoss.DataSource = list;
            comboBox_DirBoss.DisplayMember = ((LangArEn == 0) ? "NameA" : "NameE");
            comboBox_DirBoss.ValueMember = "Boss_No";
            if (vList != string.Empty)
            {
                for (int i = 0; i < comboBox_DirBoss.Items.Count; i++)
                {
                    comboBox_DirBoss.SelectedIndex = i;
                    if (comboBox_DirBoss.SelectedValue.ToString() == vList)
                    {
                        break;
                    }
                }
            }
            else
            {
                comboBox_DirBoss.SelectedIndex = 0;
            }
        }
        private void button_AddNewBirthPlaces_Click(object sender, EventArgs e)
        {
            FrmBirthPlace frm = new FrmBirthPlace();
            frm.Tag = LangArEn;
            string vList = string.Empty;
            if (comboBox_BirthPlace.SelectedIndex > 0)
            {
                vList = comboBox_BirthPlace.SelectedValue.ToString();
            }
            frm.TopMost = true;
            frm.ShowDialog();
            Stock_DataDataContext dbc = new Stock_DataDataContext(VarGeneral.BranchCS);
            List<T_BirthPlace> list = new List<T_BirthPlace>(dbc.T_BirthPlaces.Select((T_BirthPlace item) => item).ToList());
            list.Insert(0, new T_BirthPlace());
            comboBox_BirthPlace.DataSource = null;
            comboBox_BirthPlace.DataSource = list;
            comboBox_BirthPlace.DisplayMember = ((LangArEn == 0) ? "NameA" : "NameE");
            comboBox_BirthPlace.ValueMember = "BirthPlaceNo";
            if (vList != string.Empty)
            {
                for (int i = 0; i < comboBox_BirthPlace.Items.Count; i++)
                {
                    comboBox_BirthPlace.SelectedIndex = i;
                    if (comboBox_BirthPlace.SelectedValue.ToString() == vList)
                    {
                        break;
                    }
                }
            }
            else
            {
                comboBox_BirthPlace.SelectedIndex = 0;
            }
        }
        private void button_AddNewContract_Click(object sender, EventArgs e)
        {
            FrmContract frm = new FrmContract();
            frm.Tag = LangArEn;
            string vList = string.Empty;
            if (comboBox_ContrTyp.SelectedIndex > 0)
            {
                vList = comboBox_ContrTyp.SelectedValue.ToString();
            }
            frm.TopMost = true;
            frm.ShowDialog();
            Stock_DataDataContext dbc = new Stock_DataDataContext(VarGeneral.BranchCS);
            List<T_Contract> list = new List<T_Contract>(dbc.T_Contracts.Select((T_Contract item) => item).ToList());
            list.Insert(0, new T_Contract());
            comboBox_ContrTyp.DataSource = null;
            comboBox_ContrTyp.DataSource = list;
            comboBox_ContrTyp.DisplayMember = ((LangArEn == 0) ? "NameA" : "NameE");
            comboBox_ContrTyp.ValueMember = "Contract_No";
            if (vList != string.Empty)
            {
                for (int i = 0; i < comboBox_ContrTyp.Items.Count; i++)
                {
                    comboBox_ContrTyp.SelectedIndex = i;
                    if (comboBox_ContrTyp.SelectedValue.ToString() == vList)
                    {
                        break;
                    }
                }
            }
            else
            {
                comboBox_ContrTyp.SelectedIndex = 0;
            }
        }
        private void textBox_NameA_Leave(object sender, EventArgs e)
        {
            SSSLanguage.Language.Switch("AR");
        }
        private void button_Pic_Click(object sender, EventArgs e)
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
                    pictureBox_EnterPic.Image = Image.FromFile(mypic_path);
                    Bitmap OriginalBM = new Bitmap(pictureBox_EnterPic.Image);
                    pictureBox_EnterPic.Image = OriginalBM;
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("button_Pic_Click:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void button_SrchJob_Click(object sender, EventArgs e)
        {
            try
            {
                Button_Edit_Click(sender, e);
                Dir_ButSearch.Add("Job_No", new ColumnDictinary("رقم الوظيفة", "Job No", ifDefault: true, string.Empty));
                Dir_ButSearch.Add("NameA", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, string.Empty));
                Dir_ButSearch.Add("NameE", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: false, string.Empty));
                Dir_ButSearch.Add("Note", new ColumnDictinary("الملاحظات", "Note", ifDefault: true, string.Empty));
                FrmSearch frm = new FrmSearch();
                frm.Tag = LangArEn;
                ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = Dir_ButSearch;
                foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
                {
                    frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
                }
                VarGeneral.SFrmTyp = "T_Job";
                frm.TopMost = true;
                frm.ShowDialog();
                if (frm.SerachNo != string.Empty)
                {
                    comboBox_Job.SelectedValue = int.Parse(frm.SerachNo);
                }
                Dir_ButSearch.Clear();
            }
            catch
            {
            }
        }
        private void button_SrchSection_Click(object sender, EventArgs e)
        {
            try
            {
                Button_Edit_Click(sender, e);
                Dir_ButSearch.Add("Section_No", new ColumnDictinary("رقم القسم", "Section No", ifDefault: true, string.Empty));
                Dir_ButSearch.Add("NameA", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, string.Empty));
                Dir_ButSearch.Add("NameE", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: false, string.Empty));
                Dir_ButSearch.Add("Note", new ColumnDictinary("الملاحظات", "Note", ifDefault: true, string.Empty));
                FrmSearch frm = new FrmSearch();
                frm.Tag = LangArEn;
                ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = Dir_ButSearch;
                foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
                {
                    frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
                }
                VarGeneral.SFrmTyp = "T_Section";
                frm.TopMost = true;
                frm.ShowDialog();
                if (frm.SerachNo != string.Empty)
                {
                    comboBox_Section.SelectedValue = int.Parse(frm.SerachNo);
                }
                Dir_ButSearch.Clear();
            }
            catch
            {
            }
        }
        private void button_SrchGuartor_Click(object sender, EventArgs e)
        {
            try
            {
                Button_Edit_Click(sender, e);
                Dir_ButSearch.Add("Guarantor_No", new ColumnDictinary("رقم الكفيل", "Guarantor No", ifDefault: true, string.Empty));
                Dir_ButSearch.Add("NameA", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, string.Empty));
                Dir_ButSearch.Add("NameE", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: false, string.Empty));
                Dir_ButSearch.Add("Address", new ColumnDictinary("العنوان", "Address", ifDefault: true, string.Empty));
                Dir_ButSearch.Add("Tel", new ColumnDictinary("الهاتف", "Tel", ifDefault: true, string.Empty));
                Dir_ButSearch.Add("Fax", new ColumnDictinary("الفاكس", "Fax", ifDefault: false, string.Empty));
                Dir_ButSearch.Add("Mobil", new ColumnDictinary("جـــوال", "Mobile", ifDefault: false, string.Empty));
                Dir_ButSearch.Add("CodPc", new ColumnDictinary("رقم الحاسب الآلي", "Computer No", ifDefault: false, string.Empty));
                FrmSearch frm = new FrmSearch();
                frm.Tag = LangArEn;
                ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = Dir_ButSearch;
                foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
                {
                    frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
                }
                VarGeneral.SFrmTyp = "T_Guarantor";
                frm.TopMost = true;
                frm.ShowDialog();
                if (frm.SerachNo != string.Empty)
                {
                    comboBox_Guarantor.SelectedValue = int.Parse(frm.SerachNo);
                }
                Dir_ButSearch.Clear();
            }
            catch
            {
            }
        }
        private void button_SrchNation_Click(object sender, EventArgs e)
        {
            try
            {
                Button_Edit_Click(sender, e);
                Dir_ButSearch.Add("Nation_No", new ColumnDictinary("رقم الجنسية", "Nationality No", ifDefault: true, string.Empty));
                Dir_ButSearch.Add("NameA", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, string.Empty));
                Dir_ButSearch.Add("NameE", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: false, string.Empty));
                Dir_ButSearch.Add("Note", new ColumnDictinary("الملاحظات", "Note", ifDefault: true, string.Empty));
                Dir_ButSearch.Add("SalSubtract", new ColumnDictinary("المستقطع من الراتب", "Deducted from Salary", ifDefault: false, string.Empty));
                Dir_ButSearch.Add("CompPaying", new ColumnDictinary("المستقطع من الشركة", "Deducted from Company", ifDefault: false, string.Empty));
                FrmSearch frm = new FrmSearch();
                frm.Tag = LangArEn;
                ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = Dir_ButSearch;
                foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
                {
                    frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
                }
                VarGeneral.SFrmTyp = "T_Nationality";
                frm.TopMost = true;
                frm.ShowDialog();
                if (frm.SerachNo != string.Empty)
                {
                    comboBox_Nationalty.SelectedValue = int.Parse(frm.SerachNo);
                }
                Dir_ButSearch.Clear();
            }
            catch
            {
            }
        }
        private void checkBox_ClearPic_Click(object sender, EventArgs e)
        {
            try
            {
                Button_Edit_Click(sender, e);
                pictureBox_EnterPic.Image = null;
            }
            catch
            {
            }
        }
        private void dateTimeInput_DateAppointment_Click(object sender, EventArgs e)
        {
            dateTimeInput_DateAppointment.SelectAll();
        }
        private void dateTimeInput_DateAppointment_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_DateAppointment.Text = Convert.ToDateTime(dateTimeInput_DateAppointment.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_DateAppointment.Text = string.Empty;
                int? calendr = VarGeneral.Settings_Sys.Calendr;
                if (calendr.Value == 0 && calendr.HasValue)
                {
                    dateTimeInput_DateAppointment.Text = n.FormatGreg(VarGeneral.Gdate, "yyyy/MM/dd");
                }
                else
                {
                    dateTimeInput_DateAppointment.Text = n.FormatHijri(VarGeneral.Hdate, "yyyy/MM/dd");
                }
            }
        }
        private void dateTimeInput_StartContr_Click(object sender, EventArgs e)
        {
            dateTimeInput_StartContr.SelectAll();
        }
        private void dateTimeInput_EndContr_Click(object sender, EventArgs e)
        {
            dateTimeInput_EndContr.SelectAll();
        }
        private void dateTimeInput_StartContr_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_StartContr.Text = Convert.ToDateTime(dateTimeInput_StartContr.Text).ToString("yyyy/MM/dd");
                try
                {
                    dateTimeInput_EndContr.Text = int.Parse(dateTimeInput_StartContr.Text.Substring(0, 4)) + 1 + dateTimeInput_StartContr.Text.Substring(4);
                }
                catch
                {
                }
            }
            catch
            {
                dateTimeInput_StartContr.Text = string.Empty;
                if (VarGeneral.CheckDate(dateTimeInput_EndContr.Text) && !VarGeneral.CheckDate(dateTimeInput_StartContr.Text))
                {
                    try
                    {
                        dateTimeInput_StartContr.Text = int.Parse(dateTimeInput_EndContr.Text.Substring(0, 4)) - 1 + dateTimeInput_EndContr.Text.Substring(4);
                    }
                    catch
                    {
                    }
                }
            }
        }
        private void dateTimeInput_EndContr_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_EndContr.Text = Convert.ToDateTime(dateTimeInput_EndContr.Text).ToString("yyyy/MM/dd");
                if (!VarGeneral.CheckDate(dateTimeInput_EndContr.Text))
                {
                    return;
                }
                if (!VarGeneral.CheckDate(dateTimeInput_StartContr.Text))
                {
                    try
                    {
                        dateTimeInput_StartContr.Text = int.Parse(dateTimeInput_EndContr.Text.Substring(0, 4)) - 1 + dateTimeInput_EndContr.Text.Substring(4);
                    }
                    catch
                    {
                    }
                }
                else if (Convert.ToDateTime(dateTimeInput_StartContr.Text) >= Convert.ToDateTime(dateTimeInput_EndContr.Text))
                {
                    dateTimeInput_EndContr.Text = string.Empty;
                }
            }
            catch
            {
                dateTimeInput_EndContr.Text = string.Empty;
            }
        }
        private void dateTimeInput_LastFilter_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_LastFilter.Text = Convert.ToDateTime(dateTimeInput_LastFilter.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_LastFilter.Text = string.Empty;
            }
        }
        private void dateTimeInput_LastFilter_Click(object sender, EventArgs e)
        {
            dateTimeInput_LastFilter.SelectAll();
        }
        private void button_SrchBoss_Click(object sender, EventArgs e)
        {
            try
            {
                Button_Edit_Click(sender, e);
                Dir_ButSearch.Add("Boss_No", new ColumnDictinary("رقم المدير", "Boss No", ifDefault: true, string.Empty));
                Dir_ButSearch.Add("NameA", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, string.Empty));
                Dir_ButSearch.Add("NameE", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, string.Empty));
                Dir_ButSearch.Add("Note", new ColumnDictinary("الملاحظات", "Note", ifDefault: false, string.Empty));
                FrmSearch frm = new FrmSearch();
                frm.Tag = LangArEn;
                ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = Dir_ButSearch;
                foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
                {
                    frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
                }
                VarGeneral.SFrmTyp = "T_Boss";
                frm.TopMost = true;
                frm.ShowDialog();
                if (frm.SerachNo != string.Empty)
                {
                    comboBox_DirBoss.SelectedValue = int.Parse(frm.SerachNo);
                }
                Dir_ButSearch.Clear();
            }
            catch
            {
            }
        }
        private void textBox_SocialInsuranceNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (e.KeyChar != '\b'))
            {
                e.Handled = true;
            }
        }
        private void textBox_WorkNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (e.KeyChar != '\b'))
            {
                e.Handled = true;
            }
        }
        private void textBox_ID_No_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (e.KeyChar != '\b'))
            {
                e.Handled = true;
            }
        }
        private void dateTimeInput_ID_Date_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_ID_Date.Text = Convert.ToDateTime(dateTimeInput_ID_Date.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_ID_Date.Text = string.Empty;
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
                dateTimeInput_ID_DateEnd.Text = string.Empty;
            }
        }
        private void dateTimeInput_Pass_Date_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_Pass_Date.Text = Convert.ToDateTime(dateTimeInput_Pass_Date.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_Pass_Date.Text = string.Empty;
            }
        }
        private void dateTimeInput_Passport_DateEnd_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_Passport_DateEnd.Text = Convert.ToDateTime(dateTimeInput_Passport_DateEnd.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_Passport_DateEnd.Text = string.Empty;
            }
        }
        private void dateTimeInput_License_Date_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_License_Date.Text = Convert.ToDateTime(dateTimeInput_License_Date.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_License_Date.Text = string.Empty;
            }
        }
        private void dateTimeInput_License_DateEnd_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_License_DateEnd.Text = Convert.ToDateTime(dateTimeInput_License_DateEnd.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_License_DateEnd.Text = string.Empty;
            }
        }
        private void dateTimeInput_Form_Date_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_Form_Date.Text = Convert.ToDateTime(dateTimeInput_Form_Date.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_Form_Date.Text = string.Empty;
            }
        }
        private void dateTimeInput_Form_DateEnd_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_Form_DateEnd.Text = Convert.ToDateTime(dateTimeInput_Form_DateEnd.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_Form_DateEnd.Text = string.Empty;
            }
        }
        private void dateTimeInput_Insurance_Date_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_Insurance_Date.Text = Convert.ToDateTime(dateTimeInput_Insurance_Date.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_Insurance_Date.Text = string.Empty;
            }
        }
        private void dateTimeInput_Insurance_DateEnd_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_Insurance_DateEnd.Text = Convert.ToDateTime(dateTimeInput_Insurance_DateEnd.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_Insurance_DateEnd.Text = string.Empty;
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
                dateTimeInput_BirthDate.Text = string.Empty;
            }
        }
        private void dateTimeInput_ID_Date_Click(object sender, EventArgs e)
        {
            dateTimeInput_ID_Date.SelectAll();
        }
        private void dateTimeInput_ID_DateEnd_Click(object sender, EventArgs e)
        {
            dateTimeInput_ID_DateEnd.SelectAll();
        }
        private void dateTimeInput_Pass_Date_Click(object sender, EventArgs e)
        {
            dateTimeInput_Pass_Date.SelectAll();
        }
        private void dateTimeInput_Passport_DateEnd_Click(object sender, EventArgs e)
        {
            dateTimeInput_Passport_DateEnd.SelectAll();
        }
        private void dateTimeInput_License_DateEnd_Click(object sender, EventArgs e)
        {
            dateTimeInput_License_DateEnd.SelectAll();
        }
        private void dateTimeInput_License_Date_Click(object sender, EventArgs e)
        {
            dateTimeInput_License_Date.SelectAll();
        }
        private void dateTimeInput_Form_DateEnd_Click(object sender, EventArgs e)
        {
            dateTimeInput_Form_DateEnd.SelectAll();
        }
        private void dateTimeInput_Form_Date_Click(object sender, EventArgs e)
        {
            dateTimeInput_Form_Date.SelectAll();
        }
        private void dateTimeInput_Insurance_Date_Click(object sender, EventArgs e)
        {
            dateTimeInput_Insurance_Date.SelectAll();
        }
        private void dateTimeInput_Insurance_DateEnd_Click(object sender, EventArgs e)
        {
            dateTimeInput_Insurance_DateEnd.SelectAll();
        }
        private void dateTimeInput_BirthDate_Click(object sender, EventArgs e)
        {
            dateTimeInput_BirthDate.SelectAll();
        }
        private void button_SrchID_Click(object sender, EventArgs e)
        {
            try
            {
                Button_Edit_Click(sender, e);
                Dir_ButSearch.Add("City_No", new ColumnDictinary("رقم المدينة", "City No", ifDefault: true, string.Empty));
                Dir_ButSearch.Add("NameA", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, string.Empty));
                Dir_ButSearch.Add("NameE", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: false, string.Empty));
                Dir_ButSearch.Add("Note", new ColumnDictinary("الملاحظات", "Note", ifDefault: true, string.Empty));
                FrmSearch frm = new FrmSearch();
                frm.Tag = LangArEn;
                ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = Dir_ButSearch;
                foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
                {
                    frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
                }
                VarGeneral.SFrmTyp = "T_City";
                frm.TopMost = true;
                frm.ShowDialog();
                if (frm.SerachNo != string.Empty)
                {
                    comboBox_ID_From.SelectedValue = int.Parse(frm.SerachNo);
                }
                Dir_ButSearch.Clear();
            }
            catch
            {
            }
        }
        private void button_SrchPassport_Click(object sender, EventArgs e)
        {
            try
            {
                Button_Edit_Click(sender, e);
                Dir_ButSearch.Add("City_No", new ColumnDictinary("رقم المدينة", "City No", ifDefault: true, string.Empty));
                Dir_ButSearch.Add("NameA", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, string.Empty));
                Dir_ButSearch.Add("NameE", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: false, string.Empty));
                Dir_ButSearch.Add("Note", new ColumnDictinary("الملاحظات", "Note", ifDefault: true, string.Empty));
                FrmSearch frm = new FrmSearch();
                frm.Tag = LangArEn;
                ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = Dir_ButSearch;
                foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
                {
                    frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
                }
                VarGeneral.SFrmTyp = "T_City";
                frm.TopMost = true;
                frm.ShowDialog();
                if (frm.SerachNo != string.Empty)
                {
                    comboBox_Passport_From.SelectedValue = int.Parse(frm.SerachNo);
                }
                Dir_ButSearch.Clear();
            }
            catch
            {
            }
        }
        private void button_SrchInsurance_Click(object sender, EventArgs e)
        {
            try
            {
                Button_Edit_Click(sender, e);
                Dir_ButSearch.Add("City_No", new ColumnDictinary("رقم المدينة", "City No", ifDefault: true, string.Empty));
                Dir_ButSearch.Add("NameA", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, string.Empty));
                Dir_ButSearch.Add("NameE", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: false, string.Empty));
                Dir_ButSearch.Add("Note", new ColumnDictinary("الملاحظات", "Note", ifDefault: true, string.Empty));
                FrmSearch frm = new FrmSearch();
                frm.Tag = LangArEn;
                ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = Dir_ButSearch;
                foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
                {
                    frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
                }
                VarGeneral.SFrmTyp = "T_City";
                frm.TopMost = true;
                frm.ShowDialog();
                if (frm.SerachNo != string.Empty)
                {
                    comboBox_Insurance_From.SelectedValue = int.Parse(frm.SerachNo);
                }
                Dir_ButSearch.Clear();
            }
            catch
            {
            }
        }
        private void button_SrchLicense_Click(object sender, EventArgs e)
        {
            try
            {
                Button_Edit_Click(sender, e);
                Dir_ButSearch.Add("City_No", new ColumnDictinary("رقم المدينة", "City No", ifDefault: true, string.Empty));
                Dir_ButSearch.Add("NameA", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, string.Empty));
                Dir_ButSearch.Add("NameE", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: false, string.Empty));
                Dir_ButSearch.Add("Note", new ColumnDictinary("الملاحظات", "Note", ifDefault: true, string.Empty));
                FrmSearch frm = new FrmSearch();
                frm.Tag = LangArEn;
                ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = Dir_ButSearch;
                foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
                {
                    frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
                }
                VarGeneral.SFrmTyp = "T_City";
                frm.TopMost = true;
                frm.ShowDialog();
                if (frm.SerachNo != string.Empty)
                {
                    comboBox_License_From.SelectedValue = int.Parse(frm.SerachNo);
                }
                Dir_ButSearch.Clear();
            }
            catch
            {
            }
        }
        private void button_SrchForms_Click(object sender, EventArgs e)
        {
            try
            {
                Button_Edit_Click(sender, e);
                Dir_ButSearch.Add("City_No", new ColumnDictinary("رقم المدينة", "City No", ifDefault: true, string.Empty));
                Dir_ButSearch.Add("NameA", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, string.Empty));
                Dir_ButSearch.Add("NameE", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: false, string.Empty));
                Dir_ButSearch.Add("Note", new ColumnDictinary("الملاحظات", "Note", ifDefault: true, string.Empty));
                FrmSearch frm = new FrmSearch();
                frm.Tag = LangArEn;
                ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = Dir_ButSearch;
                foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
                {
                    frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
                }
                VarGeneral.SFrmTyp = "T_City";
                frm.TopMost = true;
                frm.ShowDialog();
                if (frm.SerachNo != string.Empty)
                {
                    comboBox_Form_From.SelectedValue = int.Parse(frm.SerachNo);
                }
                Dir_ButSearch.Clear();
            }
            catch
            {
            }
        }
        private void radioButton_SatPeriods1_CheckedChanged(object sender, EventArgs e)
        {
            textBox_SatTime1.Enabled = true;
            textBox_SatTimeAllow1.Enabled = true;
            textBox_SatLeaveTime1.Enabled = true;
            textBox_SatTime2.Enabled = false;
            textBox_SatTimeAllow2.Enabled = false;
            textBox_SatLeaveTime2.Enabled = false;
        }
        private void radioButton_SatPeriods2_CheckedChanged(object sender, EventArgs e)
        {
            textBox_SatTime1.Enabled = true;
            textBox_SatTimeAllow1.Enabled = true;
            textBox_SatLeaveTime1.Enabled = true;
            textBox_SatTime2.Enabled = true;
            textBox_SatTimeAllow2.Enabled = true;
            textBox_SatLeaveTime2.Enabled = true;
        }
        private void radioButton_SatBreakDay_CheckedChanged(object sender, EventArgs e)
        {
            textBox_SatTime1.Enabled = false;
            textBox_SatTimeAllow1.Enabled = false;
            textBox_SatLeaveTime1.Enabled = false;
            textBox_SatTime2.Enabled = false;
            textBox_SatTimeAllow2.Enabled = false;
            textBox_SatLeaveTime2.Enabled = false;
        }
        private void radioButton_SunPeriods1_CheckedChanged(object sender, EventArgs e)
        {
            textBox_SunTime1.Enabled = true;
            textBox_SunTimeAllow1.Enabled = true;
            textBox_SunLeaveTime1.Enabled = true;
            textBox_SunTime2.Enabled = false;
            textBox_SunTimeAllow2.Enabled = false;
            textBox_SunLeaveTime2.Enabled = false;
        }
        private void radioButton_SunPeriods2_CheckedChanged(object sender, EventArgs e)
        {
            textBox_SunTime1.Enabled = true;
            textBox_SunTimeAllow1.Enabled = true;
            textBox_SunLeaveTime1.Enabled = true;
            textBox_SunTime2.Enabled = true;
            textBox_SunTimeAllow2.Enabled = true;
            textBox_SunLeaveTime2.Enabled = true;
        }
        private void radioButton_SunBreakDay_CheckedChanged(object sender, EventArgs e)
        {
            textBox_SunTime1.Enabled = false;
            textBox_SunTimeAllow1.Enabled = false;
            textBox_SunLeaveTime1.Enabled = false;
            textBox_SunTime2.Enabled = false;
            textBox_SunTimeAllow2.Enabled = false;
            textBox_SunLeaveTime2.Enabled = false;
        }
        private void radioButton_MonPeriods1_CheckedChanged(object sender, EventArgs e)
        {
            textBox_MonTime1.Enabled = true;
            textBox_MonTimeAllow1.Enabled = true;
            textBox_MonLeaveTime1.Enabled = true;
            textBox_MonTime2.Enabled = false;
            textBox_MonTimeAllow2.Enabled = false;
            textBox_MonLeaveTime2.Enabled = false;
        }
        private void radioButton_MonPeriods2_CheckedChanged(object sender, EventArgs e)
        {
            textBox_MonTime1.Enabled = true;
            textBox_MonTimeAllow1.Enabled = true;
            textBox_MonLeaveTime1.Enabled = true;
            textBox_MonTime2.Enabled = true;
            textBox_MonTimeAllow2.Enabled = true;
            textBox_MonLeaveTime2.Enabled = true;
        }
        private void radioButton_MonBreakDay_CheckedChanged(object sender, EventArgs e)
        {
            textBox_MonTime1.Enabled = false;
            textBox_MonTimeAllow1.Enabled = false;
            textBox_MonLeaveTime1.Enabled = false;
            textBox_MonTime2.Enabled = false;
            textBox_MonTimeAllow2.Enabled = false;
            textBox_MonLeaveTime2.Enabled = false;
        }
        private void radioButton_TusPeriods1_CheckedChanged(object sender, EventArgs e)
        {
            textBox_TusTime1.Enabled = true;
            textBox_TusTimeAllow1.Enabled = true;
            textBox_TusLeaveTime1.Enabled = true;
            textBox_TusTime2.Enabled = false;
            textBox_TusTimeAllow2.Enabled = false;
            textBox_TusLeaveTime2.Enabled = false;
        }
        private void radioButton_TusPeriods2_CheckedChanged(object sender, EventArgs e)
        {
            textBox_TusTime1.Enabled = true;
            textBox_TusTimeAllow1.Enabled = true;
            textBox_TusLeaveTime1.Enabled = true;
            textBox_TusTime2.Enabled = true;
            textBox_TusTimeAllow2.Enabled = true;
            textBox_TusLeaveTime2.Enabled = true;
        }
        private void radioButton_TusBreakDay_CheckedChanged(object sender, EventArgs e)
        {
            textBox_TusTime1.Enabled = false;
            textBox_TusTimeAllow1.Enabled = false;
            textBox_TusLeaveTime1.Enabled = false;
            textBox_TusTime2.Enabled = false;
            textBox_TusTimeAllow2.Enabled = false;
            textBox_TusLeaveTime2.Enabled = false;
        }
        private void radioButton_FriPeriods1_CheckedChanged(object sender, EventArgs e)
        {
            textBox_FriTime1.Enabled = true;
            textBox_FriTimeAllow1.Enabled = true;
            textBox_LeaveTime1.Enabled = true;
            textBox_FriTime2.Enabled = false;
            textBox_FriTimeAllow2.Enabled = false;
            textBox_LeaveTime2.Enabled = false;
        }
        private void radioButton_FriPeriods2_CheckedChanged(object sender, EventArgs e)
        {
            textBox_FriTime1.Enabled = true;
            textBox_FriTimeAllow1.Enabled = true;
            textBox_LeaveTime1.Enabled = true;
            textBox_FriTime2.Enabled = true;
            textBox_FriTimeAllow2.Enabled = true;
            textBox_LeaveTime2.Enabled = true;
        }
        private void radioButton_FriBreakDay_CheckedChanged(object sender, EventArgs e)
        {
            textBox_FriTime1.Enabled = false;
            textBox_FriTimeAllow1.Enabled = false;
            textBox_LeaveTime1.Enabled = false;
            textBox_FriTime2.Enabled = false;
            textBox_FriTimeAllow2.Enabled = false;
            textBox_LeaveTime2.Enabled = false;
        }
        private void radioButton_ThurPeriods1_CheckedChanged(object sender, EventArgs e)
        {
            textBox_ThurTime1.Enabled = true;
            textBox_ThurTimeAllow1.Enabled = true;
            textBox_ThurLeaveTime1.Enabled = true;
            textBox_ThurTime2.Enabled = false;
            textBox_ThurTimeAllow2.Enabled = false;
            textBox_ThurLeaveTime2.Enabled = false;
        }
        private void radioButton_ThurPeriods2_CheckedChanged(object sender, EventArgs e)
        {
            textBox_ThurTime1.Enabled = true;
            textBox_ThurTimeAllow1.Enabled = true;
            textBox_ThurLeaveTime1.Enabled = true;
            textBox_ThurTime2.Enabled = true;
            textBox_ThurTimeAllow2.Enabled = true;
            textBox_ThurLeaveTime2.Enabled = true;
        }
        private void radioButton_ThurBreakDay_CheckedChanged(object sender, EventArgs e)
        {
            textBox_ThurTime1.Enabled = false;
            textBox_ThurTimeAllow1.Enabled = false;
            textBox_ThurLeaveTime1.Enabled = false;
            textBox_ThurTime2.Enabled = false;
            textBox_ThurTimeAllow2.Enabled = false;
            textBox_ThurLeaveTime2.Enabled = false;
        }
        private void radioButton_WenPeriods1_CheckedChanged(object sender, EventArgs e)
        {
            textBox_WenTime1.Enabled = true;
            textBox_WenTimeAllow1.Enabled = true;
            textBox_WenLeaveTime1.Enabled = true;
            textBox_WenTime2.Enabled = false;
            textBox_WenTimeAllow2.Enabled = false;
            textBox_WenLeaveTime2.Enabled = false;
        }
        private void radioButton_WenPeriods2_CheckedChanged(object sender, EventArgs e)
        {
            textBox_WenTime1.Enabled = true;
            textBox_WenTimeAllow1.Enabled = true;
            textBox_WenLeaveTime1.Enabled = true;
            textBox_WenTime2.Enabled = true;
            textBox_WenTimeAllow2.Enabled = true;
            textBox_WenLeaveTime2.Enabled = true;
        }
        private void radioButton_WenBreakDay_CheckedChanged(object sender, EventArgs e)
        {
            textBox_WenTime1.Enabled = false;
            textBox_WenTimeAllow1.Enabled = false;
            textBox_WenLeaveTime1.Enabled = false;
            textBox_WenTime2.Enabled = false;
            textBox_WenTimeAllow2.Enabled = false;
            textBox_WenLeaveTime2.Enabled = false;
        }
        private void textBox_SatTime1_Click(object sender, EventArgs e)
        {
            textBox_SatTime1.SelectAll();
        }
        private void textBox_SatTimeAllow1_Click(object sender, EventArgs e)
        {
            textBox_SatTimeAllow1.SelectAll();
        }
        private void textBox_SatLeaveTime1_Click(object sender, EventArgs e)
        {
            textBox_SatLeaveTime1.SelectAll();
        }
        private void textBox_SatTime2_Click(object sender, EventArgs e)
        {
            textBox_SatTime2.SelectAll();
        }
        private void textBox_SatTimeAllow2_Click(object sender, EventArgs e)
        {
            textBox_SatTimeAllow2.SelectAll();
        }
        private void textBox_SatLeaveTime2_Click(object sender, EventArgs e)
        {
            textBox_SatLeaveTime2.SelectAll();
        }
        private void textBox_SunTime1_Click(object sender, EventArgs e)
        {
            textBox_SunTime1.SelectAll();
        }
        private void textBox_SunTimeAllow1_Click(object sender, EventArgs e)
        {
            textBox_SunTimeAllow1.SelectAll();
        }
        private void textBox_SunLeaveTime1_Click(object sender, EventArgs e)
        {
            textBox_SunLeaveTime1.SelectAll();
        }
        private void textBox_SunTime2_Click(object sender, EventArgs e)
        {
            textBox_SunTime2.SelectAll();
        }
        private void textBox_SunTimeAllow2_Click(object sender, EventArgs e)
        {
            textBox_SunTimeAllow2.SelectAll();
        }
        private void textBox_SunLeaveTime2_Click(object sender, EventArgs e)
        {
            textBox_SunLeaveTime2.SelectAll();
        }
        private void textBox_MonTime1_Click(object sender, EventArgs e)
        {
            textBox_MonTime1.SelectAll();
        }
        private void textBox_MonTimeAllow1_Click(object sender, EventArgs e)
        {
            textBox_MonTimeAllow1.SelectAll();
        }
        private void textBox_MonLeaveTime1_Click(object sender, EventArgs e)
        {
            textBox_MonLeaveTime1.SelectAll();
        }
        private void textBox_MonTime2_Click(object sender, EventArgs e)
        {
            textBox_MonTime2.SelectAll();
        }
        private void textBox_MonTimeAllow2_Click(object sender, EventArgs e)
        {
            textBox_MonTimeAllow2.SelectAll();
        }
        private void textBox_MonLeaveTime2_Click(object sender, EventArgs e)
        {
            textBox_MonLeaveTime2.SelectAll();
        }
        private void textBox_TusTime1_Click(object sender, EventArgs e)
        {
            textBox_TusTime1.SelectAll();
        }
        private void textBox_TusTimeAllow1_Click(object sender, EventArgs e)
        {
            textBox_TusTimeAllow1.SelectAll();
        }
        private void textBox_TusLeaveTime1_Click(object sender, EventArgs e)
        {
            textBox_TusLeaveTime1.SelectAll();
        }
        private void textBox_TusTime2_Click(object sender, EventArgs e)
        {
            textBox_TusTime2.SelectAll();
        }
        private void textBox_TusTimeAllow2_Click(object sender, EventArgs e)
        {
            textBox_TusTimeAllow2.SelectAll();
        }
        private void textBox_TusLeaveTime2_Click(object sender, EventArgs e)
        {
            textBox_TusLeaveTime2.SelectAll();
        }
        private void textBox_WenTime1_Click(object sender, EventArgs e)
        {
            textBox_WenTime1.SelectAll();
        }
        private void textBox_WenTimeAllow1_Click(object sender, EventArgs e)
        {
            textBox_WenTimeAllow1.SelectAll();
        }
        private void textBox_WenLeaveTime1_Click(object sender, EventArgs e)
        {
            textBox_WenLeaveTime1.SelectAll();
        }
        private void textBox_WenTime2_Click(object sender, EventArgs e)
        {
            textBox_WenTime2.SelectAll();
        }
        private void textBox_WenTimeAllow2_Click(object sender, EventArgs e)
        {
            textBox_WenTimeAllow2.SelectAll();
        }
        private void textBox_WenLeaveTime2_Click(object sender, EventArgs e)
        {
            textBox_WenLeaveTime2.SelectAll();
        }
        private void textBox_ThurTime1_Click(object sender, EventArgs e)
        {
            textBox_ThurTime1.SelectAll();
        }
        private void textBox_ThurTimeAllow1_Click(object sender, EventArgs e)
        {
            textBox_ThurTimeAllow1.SelectAll();
        }
        private void textBox_ThurLeaveTime1_Click(object sender, EventArgs e)
        {
            textBox_ThurLeaveTime1.SelectAll();
        }
        private void textBox_ThurTime2_Click(object sender, EventArgs e)
        {
            textBox_ThurTime2.SelectAll();
        }
        private void textBox_ThurTimeAllow2_Click(object sender, EventArgs e)
        {
            textBox_ThurTimeAllow2.SelectAll();
        }
        private void textBox_ThurLeaveTime2_Click(object sender, EventArgs e)
        {
            textBox_ThurLeaveTime2.SelectAll();
        }
        private void textBox_FriTime2_Click(object sender, EventArgs e)
        {
            textBox_FriTime2.SelectAll();
        }
        private void textBox_FriTime1_Click(object sender, EventArgs e)
        {
            textBox_FriTime1.SelectAll();
        }
        private void textBox_FriTimeAllow1_Click(object sender, EventArgs e)
        {
            textBox_FriTimeAllow1.SelectAll();
        }
        private void textBox_FriTimeAllow2_Click(object sender, EventArgs e)
        {
            textBox_FriTimeAllow2.SelectAll();
        }
        private void textBox_LeaveTime1_Click(object sender, EventArgs e)
        {
            textBox_LeaveTime1.SelectAll();
        }
        private void textBox_LeaveTime2_Click(object sender, EventArgs e)
        {
            textBox_LeaveTime2.SelectAll();
        }
        private void textBox_SatTime1_Leave(object sender, EventArgs e)
        {
            if (VarGeneral.CheckTime(textBox_SatTime1.Text))
            {
                textBox_SatTime1.Text = TimeSpan.Parse(textBox_SatTime1.Text).ToString();
            }
            else
            {
                textBox_SatTime1.Text = string.Empty;
            }
        }
        private void textBox_SatTimeAllow1_Leave(object sender, EventArgs e)
        {
            if (VarGeneral.CheckTime(textBox_SatTimeAllow1.Text))
            {
                textBox_SatTimeAllow1.Text = TimeSpan.Parse(textBox_SatTimeAllow1.Text).ToString();
            }
            else
            {
                textBox_SatTimeAllow1.Text = string.Empty;
            }
        }
        private void textBox_SatLeaveTime1_Leave(object sender, EventArgs e)
        {
            if (VarGeneral.CheckTime(textBox_SatLeaveTime1.Text))
            {
                textBox_SatLeaveTime1.Text = TimeSpan.Parse(textBox_SatLeaveTime1.Text).ToString();
            }
            else
            {
                textBox_SatLeaveTime1.Text = string.Empty;
            }
        }
        private void textBox_SatTime2_Leave(object sender, EventArgs e)
        {
            if (VarGeneral.CheckTime(textBox_SatTime2.Text))
            {
                textBox_SatTime2.Text = TimeSpan.Parse(textBox_SatTime2.Text).ToString();
            }
            else
            {
                textBox_SatTime2.Text = string.Empty;
            }
        }
        private void textBox_SatTimeAllow2_Leave(object sender, EventArgs e)
        {
            if (VarGeneral.CheckTime(textBox_SatTimeAllow2.Text))
            {
                textBox_SatTimeAllow2.Text = TimeSpan.Parse(textBox_SatTimeAllow2.Text).ToString();
            }
            else
            {
                textBox_SatTimeAllow2.Text = string.Empty;
            }
        }
        private void textBox_SatLeaveTime2_Leave(object sender, EventArgs e)
        {
            if (VarGeneral.CheckTime(textBox_SatLeaveTime2.Text))
            {
                textBox_SatLeaveTime2.Text = TimeSpan.Parse(textBox_SatLeaveTime2.Text).ToString();
            }
            else
            {
                textBox_SatLeaveTime2.Text = string.Empty;
            }
        }
        private void textBox_SunTime1_Leave(object sender, EventArgs e)
        {
            if (VarGeneral.CheckTime(textBox_SunTime1.Text))
            {
                textBox_SunTime1.Text = TimeSpan.Parse(textBox_SunTime1.Text).ToString();
            }
            else
            {
                textBox_SunTime1.Text = string.Empty;
            }
        }
        private void textBox_SunTimeAllow1_Leave(object sender, EventArgs e)
        {
            if (VarGeneral.CheckTime(textBox_SunTimeAllow1.Text))
            {
                textBox_SunTimeAllow1.Text = TimeSpan.Parse(textBox_SunTimeAllow1.Text).ToString();
            }
            else
            {
                textBox_SunTimeAllow1.Text = string.Empty;
            }
        }
        private void textBox_SunLeaveTime1_Leave(object sender, EventArgs e)
        {
            if (VarGeneral.CheckTime(textBox_SunLeaveTime1.Text))
            {
                textBox_SunLeaveTime1.Text = TimeSpan.Parse(textBox_SunLeaveTime1.Text).ToString();
            }
            else
            {
                textBox_SunLeaveTime1.Text = string.Empty;
            }
        }
        private void textBox_SunTime2_Leave(object sender, EventArgs e)
        {
            if (VarGeneral.CheckTime(textBox_SunTime2.Text))
            {
                textBox_SunTime2.Text = TimeSpan.Parse(textBox_SunTime2.Text).ToString();
            }
            else
            {
                textBox_SunTime2.Text = string.Empty;
            }
        }
        private void textBox_SunTimeAllow2_Leave(object sender, EventArgs e)
        {
            if (VarGeneral.CheckTime(textBox_SunTimeAllow2.Text))
            {
                textBox_SunTimeAllow2.Text = TimeSpan.Parse(textBox_SunTimeAllow2.Text).ToString();
            }
            else
            {
                textBox_SunTimeAllow2.Text = string.Empty;
            }
        }
        private void textBox_SunLeaveTime2_Leave(object sender, EventArgs e)
        {
            if (VarGeneral.CheckTime(textBox_SunLeaveTime2.Text))
            {
                textBox_SunLeaveTime2.Text = TimeSpan.Parse(textBox_SunLeaveTime2.Text).ToString();
            }
            else
            {
                textBox_SunLeaveTime2.Text = string.Empty;
            }
        }
        private void textBox_MonTime1_Leave(object sender, EventArgs e)
        {
            if (VarGeneral.CheckTime(textBox_MonTime1.Text))
            {
                textBox_MonTime1.Text = TimeSpan.Parse(textBox_MonTime1.Text).ToString();
            }
            else
            {
                textBox_MonTime1.Text = string.Empty;
            }
        }
        private void textBox_MonTimeAllow1_Leave(object sender, EventArgs e)
        {
            if (VarGeneral.CheckTime(textBox_MonTimeAllow1.Text))
            {
                textBox_MonTimeAllow1.Text = TimeSpan.Parse(textBox_MonTimeAllow1.Text).ToString();
            }
            else
            {
                textBox_MonTimeAllow1.Text = string.Empty;
            }
        }
        private void textBox_MonLeaveTime1_Leave(object sender, EventArgs e)
        {
            if (VarGeneral.CheckTime(textBox_MonLeaveTime1.Text))
            {
                textBox_MonLeaveTime1.Text = TimeSpan.Parse(textBox_MonLeaveTime1.Text).ToString();
            }
            else
            {
                textBox_MonLeaveTime1.Text = string.Empty;
            }
        }
        private void textBox_MonTime2_Leave(object sender, EventArgs e)
        {
            if (VarGeneral.CheckTime(textBox_MonTime2.Text))
            {
                textBox_MonTime2.Text = TimeSpan.Parse(textBox_MonTime2.Text).ToString();
            }
            else
            {
                textBox_MonTime2.Text = string.Empty;
            }
        }
        private void textBox_MonTimeAllow2_Leave(object sender, EventArgs e)
        {
            if (VarGeneral.CheckTime(textBox_MonTimeAllow2.Text))
            {
                textBox_MonTimeAllow2.Text = TimeSpan.Parse(textBox_MonTimeAllow2.Text).ToString();
            }
            else
            {
                textBox_MonTimeAllow2.Text = string.Empty;
            }
        }
        private void textBox_MonLeaveTime2_Leave(object sender, EventArgs e)
        {
            if (VarGeneral.CheckTime(textBox_MonLeaveTime2.Text))
            {
                textBox_MonLeaveTime2.Text = TimeSpan.Parse(textBox_MonLeaveTime2.Text).ToString();
            }
            else
            {
                textBox_MonLeaveTime2.Text = string.Empty;
            }
        }
        private void textBox_TusTime1_Leave(object sender, EventArgs e)
        {
            if (VarGeneral.CheckTime(textBox_TusTime1.Text))
            {
                textBox_TusTime1.Text = TimeSpan.Parse(textBox_TusTime1.Text).ToString();
            }
            else
            {
                textBox_TusTime1.Text = string.Empty;
            }
        }
        private void textBox_TusTimeAllow1_Leave(object sender, EventArgs e)
        {
            if (VarGeneral.CheckTime(textBox_TusTimeAllow1.Text))
            {
                textBox_TusTimeAllow1.Text = TimeSpan.Parse(textBox_TusTimeAllow1.Text).ToString();
            }
            else
            {
                textBox_TusTimeAllow1.Text = string.Empty;
            }
        }
        private void textBox_TusLeaveTime1_Leave(object sender, EventArgs e)
        {
            if (VarGeneral.CheckTime(textBox_TusLeaveTime1.Text))
            {
                textBox_TusLeaveTime1.Text = TimeSpan.Parse(textBox_TusLeaveTime1.Text).ToString();
            }
            else
            {
                textBox_TusLeaveTime1.Text = string.Empty;
            }
        }
        private void textBox_TusTime2_Leave(object sender, EventArgs e)
        {
            if (VarGeneral.CheckTime(textBox_TusTime2.Text))
            {
                textBox_TusTime2.Text = TimeSpan.Parse(textBox_TusTime2.Text).ToString();
            }
            else
            {
                textBox_TusTime2.Text = string.Empty;
            }
        }
        private void textBox_TusTimeAllow2_Leave(object sender, EventArgs e)
        {
            if (VarGeneral.CheckTime(textBox_TusTimeAllow2.Text))
            {
                textBox_TusTimeAllow2.Text = TimeSpan.Parse(textBox_TusTimeAllow2.Text).ToString();
            }
            else
            {
                textBox_TusTimeAllow2.Text = string.Empty;
            }
        }
        private void textBox_TusLeaveTime2_Leave(object sender, EventArgs e)
        {
            if (VarGeneral.CheckTime(textBox_TusLeaveTime2.Text))
            {
                textBox_TusLeaveTime2.Text = TimeSpan.Parse(textBox_TusLeaveTime2.Text).ToString();
            }
            else
            {
                textBox_TusLeaveTime2.Text = string.Empty;
            }
        }
        private void textBox_WenTime1_Leave(object sender, EventArgs e)
        {
            if (VarGeneral.CheckTime(textBox_WenTime1.Text))
            {
                textBox_WenTime1.Text = TimeSpan.Parse(textBox_WenTime1.Text).ToString();
            }
            else
            {
                textBox_WenTime1.Text = string.Empty;
            }
        }
        private void textBox_WenTimeAllow1_Leave(object sender, EventArgs e)
        {
            if (VarGeneral.CheckTime(textBox_WenTimeAllow1.Text))
            {
                textBox_WenTimeAllow1.Text = TimeSpan.Parse(textBox_WenTimeAllow1.Text).ToString();
            }
            else
            {
                textBox_WenTimeAllow1.Text = string.Empty;
            }
        }
        private void textBox_WenLeaveTime1_Leave(object sender, EventArgs e)
        {
            if (VarGeneral.CheckTime(textBox_WenLeaveTime1.Text))
            {
                textBox_WenLeaveTime1.Text = TimeSpan.Parse(textBox_WenLeaveTime1.Text).ToString();
            }
            else
            {
                textBox_WenLeaveTime1.Text = string.Empty;
            }
        }
        private void textBox_WenTime2_Leave(object sender, EventArgs e)
        {
            if (VarGeneral.CheckTime(textBox_WenTime2.Text))
            {
                textBox_WenTime2.Text = TimeSpan.Parse(textBox_WenTime2.Text).ToString();
            }
            else
            {
                textBox_WenTime2.Text = string.Empty;
            }
        }
        private void textBox_WenTimeAllow2_Leave(object sender, EventArgs e)
        {
            if (VarGeneral.CheckTime(textBox_WenTimeAllow2.Text))
            {
                textBox_WenTimeAllow2.Text = TimeSpan.Parse(textBox_WenTimeAllow2.Text).ToString();
            }
            else
            {
                textBox_WenTimeAllow2.Text = string.Empty;
            }
        }
        private void textBox_WenLeaveTime2_Leave(object sender, EventArgs e)
        {
            if (VarGeneral.CheckTime(textBox_WenLeaveTime2.Text))
            {
                textBox_WenLeaveTime2.Text = TimeSpan.Parse(textBox_WenLeaveTime2.Text).ToString();
            }
            else
            {
                textBox_WenLeaveTime2.Text = string.Empty;
            }
        }
        private void textBox_ThurTime1_Leave(object sender, EventArgs e)
        {
            if (VarGeneral.CheckTime(textBox_ThurTime1.Text))
            {
                textBox_ThurTime1.Text = TimeSpan.Parse(textBox_ThurTime1.Text).ToString();
            }
            else
            {
                textBox_ThurTime1.Text = string.Empty;
            }
        }
        private void textBox_ThurTimeAllow1_Leave(object sender, EventArgs e)
        {
            if (VarGeneral.CheckTime(textBox_ThurTimeAllow1.Text))
            {
                textBox_ThurTimeAllow1.Text = TimeSpan.Parse(textBox_ThurTimeAllow1.Text).ToString();
            }
            else
            {
                textBox_ThurTimeAllow1.Text = string.Empty;
            }
        }
        private void textBox_ThurLeaveTime1_Leave(object sender, EventArgs e)
        {
            if (VarGeneral.CheckTime(textBox_ThurLeaveTime1.Text))
            {
                textBox_ThurLeaveTime1.Text = TimeSpan.Parse(textBox_ThurLeaveTime1.Text).ToString();
            }
            else
            {
                textBox_ThurLeaveTime1.Text = string.Empty;
            }
        }
        private void textBox_ThurTime2_Leave(object sender, EventArgs e)
        {
            if (VarGeneral.CheckTime(textBox_ThurTime2.Text))
            {
                textBox_ThurTime2.Text = TimeSpan.Parse(textBox_ThurTime2.Text).ToString();
            }
            else
            {
                textBox_ThurTime2.Text = string.Empty;
            }
        }
        private void textBox_ThurTimeAllow2_Leave(object sender, EventArgs e)
        {
            if (VarGeneral.CheckTime(textBox_ThurTimeAllow2.Text))
            {
                textBox_ThurTimeAllow2.Text = TimeSpan.Parse(textBox_ThurTimeAllow2.Text).ToString();
            }
            else
            {
                textBox_ThurTimeAllow2.Text = string.Empty;
            }
        }
        private void textBox_ThurLeaveTime2_Leave(object sender, EventArgs e)
        {
            if (VarGeneral.CheckTime(textBox_ThurLeaveTime2.Text))
            {
                textBox_ThurLeaveTime2.Text = TimeSpan.Parse(textBox_ThurLeaveTime2.Text).ToString();
            }
            else
            {
                textBox_ThurLeaveTime2.Text = string.Empty;
            }
        }
        private void textBox_FriTime1_Leave(object sender, EventArgs e)
        {
            if (VarGeneral.CheckTime(textBox_FriTime1.Text))
            {
                textBox_FriTime1.Text = TimeSpan.Parse(textBox_FriTime1.Text).ToString();
            }
            else
            {
                textBox_FriTime1.Text = string.Empty;
            }
        }
        private void textBox_FriTimeAllow1_Leave(object sender, EventArgs e)
        {
            if (VarGeneral.CheckTime(textBox_FriTimeAllow1.Text))
            {
                textBox_FriTimeAllow1.Text = TimeSpan.Parse(textBox_FriTimeAllow1.Text).ToString();
            }
            else
            {
                textBox_FriTimeAllow1.Text = string.Empty;
            }
        }
        private void textBox_LeaveTime1_Leave(object sender, EventArgs e)
        {
            if (VarGeneral.CheckTime(textBox_LeaveTime1.Text))
            {
                textBox_LeaveTime1.Text = TimeSpan.Parse(textBox_LeaveTime1.Text).ToString();
            }
            else
            {
                textBox_LeaveTime1.Text = string.Empty;
            }
        }
        private void textBox_FriTime2_Leave(object sender, EventArgs e)
        {
            if (VarGeneral.CheckTime(textBox_FriTime2.Text))
            {
                textBox_FriTime2.Text = TimeSpan.Parse(textBox_FriTime2.Text).ToString();
            }
            else
            {
                textBox_FriTime2.Text = string.Empty;
            }
        }
        private void textBox_FriTimeAllow2_Leave(object sender, EventArgs e)
        {
            if (VarGeneral.CheckTime(textBox_FriTimeAllow2.Text))
            {
                textBox_FriTimeAllow2.Text = TimeSpan.Parse(textBox_FriTimeAllow2.Text).ToString();
            }
            else
            {
                textBox_FriTimeAllow2.Text = string.Empty;
            }
        }
        private void textBox_LeaveTime2_Leave(object sender, EventArgs e)
        {
            if (VarGeneral.CheckTime(textBox_LeaveTime2.Text))
            {
                textBox_LeaveTime2.Text = TimeSpan.Parse(textBox_LeaveTime2.Text).ToString();
            }
            else
            {
                textBox_LeaveTime2.Text = string.Empty;
            }
        }
        private void textBox_SatTime1_TextChanged(object sender, EventArgs e)
        {
            if (State != 0)
            {
                textBox_SatTimeAllow1.Text = textBox_SatTime1.Text;
            }
        }
        private void textBox_SatTime2_TextChanged(object sender, EventArgs e)
        {
            if (State != 0)
            {
                textBox_SatTimeAllow2.Text = textBox_SatTime2.Text;
            }
        }
        private void textBox_SunTime1_TextChanged(object sender, EventArgs e)
        {
            if (State != 0)
            {
                textBox_SunTimeAllow1.Text = textBox_SunTime1.Text;
            }
        }
        private void textBox_SunTime2_TextChanged(object sender, EventArgs e)
        {
            if (State != 0)
            {
                textBox_SunTimeAllow2.Text = textBox_SunTime2.Text;
            }
        }
        private void textBox_MonTime1_TextChanged(object sender, EventArgs e)
        {
            if (State != 0)
            {
                textBox_MonTimeAllow1.Text = textBox_MonTime1.Text;
            }
        }
        private void textBox_MonTime2_TextChanged(object sender, EventArgs e)
        {
            if (State != 0)
            {
                textBox_MonTimeAllow2.Text = textBox_MonTime2.Text;
            }
        }
        private void textBox_TusTime1_TextChanged(object sender, EventArgs e)
        {
            if (State != 0)
            {
                textBox_TusTimeAllow1.Text = textBox_TusTime1.Text;
            }
        }
        private void textBox_TusTime2_TextChanged(object sender, EventArgs e)
        {
            if (State != 0)
            {
                textBox_TusTimeAllow2.Text = textBox_TusTime2.Text;
            }
        }
        private void textBox_WenTime1_TextChanged(object sender, EventArgs e)
        {
            if (State != 0)
            {
                textBox_WenTimeAllow1.Text = textBox_WenTime1.Text;
            }
        }
        private void textBox_WenTime2_TextChanged(object sender, EventArgs e)
        {
            if (State != 0)
            {
                textBox_WenTimeAllow2.Text = textBox_WenTime2.Text;
            }
        }
        private void textBox_ThurTime1_TextChanged(object sender, EventArgs e)
        {
            if (State != 0)
            {
                textBox_ThurTimeAllow1.Text = textBox_ThurTime1.Text;
            }
        }
        private void textBox_ThurTime2_TextChanged(object sender, EventArgs e)
        {
            if (State != 0)
            {
                textBox_ThurTimeAllow2.Text = textBox_ThurTime2.Text;
            }
        }
        private void textBox_FriTime1_TextChanged(object sender, EventArgs e)
        {
            if (State != 0)
            {
                textBox_FriTimeAllow1.Text = textBox_FriTime1.Text;
            }
        }
        private void textBox_FriTime2_TextChanged(object sender, EventArgs e)
        {
            if (State != 0)
            {
                textBox_FriTimeAllow2.Text = textBox_FriTime2.Text;
            }
        }
        private void dateTimeInput_VisaDate_Click(object sender, EventArgs e)
        {
            dateTimeInput_VisaDate.SelectAll();
        }
        private void dateTimeInput_VisaDate_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_VisaDate.Text = Convert.ToDateTime(dateTimeInput_VisaDate.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_VisaDate.Text = string.Empty;
            }
        }
        private void comboBox_InsuranceType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_InsuranceType.SelectedIndex > 0)
            {
                textBox_Insurance_Class.Enabled = true;
            }
            else
            {
                textBox_Insurance_Class.Enabled = false;
            }
        }
        private void button_InsuranceType_Click(object sender, EventArgs e)
        {
            FrmInsuranceHealth frm = new FrmInsuranceHealth();
            frm.Tag = LangArEn;
            string vList = string.Empty;
            if (comboBox_InsuranceType.SelectedIndex > 0)
            {
                vList = comboBox_InsuranceType.SelectedValue.ToString();
            }
            frm.TopMost = true;
            frm.ShowDialog();
            Stock_DataDataContext dbc = new Stock_DataDataContext(VarGeneral.BranchCS);
            List<T_Insurance> listGur = new List<T_Insurance>(dbc.T_Insurances.Select((T_Insurance item) => item).ToList());
            listGur.Insert(0, new T_Insurance());
            comboBox_InsuranceType.DataSource = null;
            listGur.Insert(0, new T_Insurance());
            comboBox_InsuranceType.DataSource = listGur;
            comboBox_InsuranceType.DisplayMember = ((LangArEn == 0) ? "NameA" : "NameE");
            comboBox_InsuranceType.ValueMember = "Insurance_No";
            if (vList != string.Empty)
            {
                for (int i = 0; i < comboBox_InsuranceType.Items.Count; i++)
                {
                    comboBox_InsuranceType.SelectedIndex = i;
                    if (comboBox_InsuranceType.SelectedValue.ToString() == vList)
                    {
                        break;
                    }
                }
            }
            else
            {
                comboBox_InsuranceType.SelectedIndex = 0;
            }
        }
        private void bubbleButton_InsuranceType_Click(object sender, EventArgs e)
        {
            try
            {
                Button_Edit_Click(sender, e);
                Dir_ButSearch.Add("Insurance_No", new ColumnDictinary("الرقم", "Job No", ifDefault: true, string.Empty));
                Dir_ButSearch.Add("NameA", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, string.Empty));
                Dir_ButSearch.Add("NameE", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: false, string.Empty));
                Dir_ButSearch.Add("Note", new ColumnDictinary("الملاحظات", "Note", ifDefault: true, string.Empty));
                FrmSearch frm = new FrmSearch();
                frm.Tag = LangArEn;
                ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = Dir_ButSearch;
                foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
                {
                    frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
                }
                VarGeneral.SFrmTyp = "T_Insurance";
                frm.TopMost = true;
                frm.ShowDialog();
                if (frm.SerachNo != string.Empty)
                {
                    comboBox_InsuranceType.SelectedValue = int.Parse(frm.SerachNo);
                }
                Dir_ButSearch.Clear();
            }
            catch
            {
            }
        }
        private void buttonX_OpenFiles_Click(object sender, EventArgs e)
        {
            try
            {
                if (Button_Save.Enabled || string.IsNullOrEmpty(data_this.Emp_No))
                {
                    return;
                }
                int b = 0;
                string ServiceNm = string.Empty;
                for (b = 0; b < VarGeneral.gServerName.Length && !(VarGeneral.gServerName.Substring(b, 1) == "\\"); b++)
                {
                }
                try
                {
                    ServiceNm = VarGeneral.gServerName.Substring(b + 1);
                }
                catch
                {
                    ServiceNm = string.Empty;
                }
                if (string.IsNullOrEmpty(ServiceNm))
                {
                    ServiceNm = VarGeneral.DBNo.Replace("DBPROSOFT_", null);
                }
                try
                {
                    if (!Directory.Exists((string.IsNullOrEmpty(VarGeneral.Settings_Sys.DocumentPath) ? Application.StartupPath : VarGeneral.Settings_Sys.DocumentPath) + "\\" + ServiceNm))
                    {
                        Directory.CreateDirectory((string.IsNullOrEmpty(VarGeneral.Settings_Sys.DocumentPath) ? Application.StartupPath : VarGeneral.Settings_Sys.DocumentPath) + "\\" + ServiceNm);
                    }
                }
                catch
                {
                }
                try
                {
                    if (!Directory.Exists((string.IsNullOrEmpty(VarGeneral.Settings_Sys.DocumentPath) ? Application.StartupPath : VarGeneral.Settings_Sys.DocumentPath) + "\\" + ServiceNm + "\\" + VarGeneral.DBNo.Replace("DBPROSOFT", "PROSOFT") + "_" + VarGeneral.BranchNumber))
                    {
                        Directory.CreateDirectory((string.IsNullOrEmpty(VarGeneral.Settings_Sys.DocumentPath) ? Application.StartupPath : VarGeneral.Settings_Sys.DocumentPath) + "\\" + ServiceNm + "\\" + VarGeneral.DBNo.Replace("DBPROSOFT", "PROSOFT") + "_" + VarGeneral.BranchNumber);
                    }
                }
                catch
                {
                }
                string filename = string.Empty;
                try
                {
                    if (!Directory.Exists((string.IsNullOrEmpty(VarGeneral.Settings_Sys.DocumentPath) ? Application.StartupPath : VarGeneral.Settings_Sys.DocumentPath) + "\\" + ServiceNm + "\\" + VarGeneral.DBNo.Replace("DBPROSOFT", "PROSOFT") + "_" + VarGeneral.BranchNumber + "\\EmpDocuments"))
                    {
                        Directory.CreateDirectory((string.IsNullOrEmpty(VarGeneral.Settings_Sys.DocumentPath) ? Application.StartupPath : VarGeneral.Settings_Sys.DocumentPath) + "\\" + ServiceNm + "\\" + VarGeneral.DBNo.Replace("DBPROSOFT", "PROSOFT") + "_" + VarGeneral.BranchNumber + "\\EmpDocuments");
                    }
                }
                catch
                {
                }
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif|TIFF Files (*.tiff)|*.tiff|BMP Files (*.bmp)|*.bmp";
                try
                {
                    if (VarGeneral.gUserName == "runsetting")
                    {
                        ofd.InitialDirectory = "::{20D04FE0-3AEA-1069-A2D8-08002B30309D}";
                    }
                }
                catch
                {
                }
                ofd.ShowDialog();
                filename = ofd.FileName;
                if (string.IsNullOrEmpty(filename) || !File.Exists(filename))
                {
                    return;
                }
                string FileNm = "00001";
                if (listBox_ImageFiles2.Items.Count > 0)
                {
                    FileNm = listBox_ImageFiles2.Items[listBox_ImageFiles2.Items.Count - 1].ToString();
                    FileNm = (int.Parse(FileNm) + 1).ToString();
                    while (FileNm.Length < 5)
                    {
                        FileNm = "0" + FileNm;
                    }
                }
                string pType = string.Empty;
                for (int iicnt = 0; iicnt < filename.Length; iicnt++)
                {
                    try
                    {
                        if (filename.Substring(iicnt, 1) == ".")
                        {
                            pType = filename.Substring(iicnt);
                            break;
                        }
                    }
                    catch
                    {
                    }
                }
                string strTmpFile = string.Empty;
                strTmpFile = ((!string.IsNullOrEmpty(VarGeneral.Settings_Sys.DocumentPath)) ? (VarGeneral.Settings_Sys.DocumentPath + "\\" + ServiceNm + "\\" + VarGeneral.DBNo.Replace("DBPROSOFT", "PROSOFT") + "_" + VarGeneral.BranchNumber + "\\EmpDocuments\\" + data_this.Emp_No + "-" + FileNm.Trim() + pType) : (Application.StartupPath + "\\" + ServiceNm + "\\" + VarGeneral.DBNo.Replace("DBPROSOFT", "PROSOFT") + "_" + VarGeneral.BranchNumber + "\\EmpDocuments\\" + data_this.Emp_No + "-" + FileNm.Trim() + pType));
                File.Copy(filename, strTmpFile, overwrite: true);
                FillImageList2();
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("buttonX_OpenFiles_Click:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void buttonX_BrowserScannerFiles_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(data_this.Emp_No))
                {
                    FrmScannerFiles frm = new FrmScannerFiles(data_this.Emp_No, (LangArEn == 0) ? data_this.NameA : data_this.NameE);
                    frm.Tag = LangArEn;
                    frm.TopMost = true;
                    frm.ShowDialog();
                }
            }
            catch
            {
            }
        }
        private void linkLabel_ChangeEmpNo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (State != 0 || string.IsNullOrEmpty(textBox_ID.Text))
            {
                return;
            }
            string vNewNo = InputDialog.mostrar((LangArEn == 0) ? "أدخل رقم الموظف الجديد : " : "Insert New Employee No : ", (LangArEn == 0) ? "تعديل رقم الموظف" : "Employee No Edite");
            if (string.IsNullOrEmpty(vNewNo))
            {
                return;
            }
            try
            {
                List<T_Emp> q = db.T_Emps.Where((T_Emp t) => t.Emp_No == vNewNo).ToList();
                if (q.Count > 0)
                {
                    MessageBox.Show((LangArEn == 0) ? " رقم الموظف مكرر يرجى تغييره" : "Employee No It's a existing", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    textBox_ID.Focus();
                    return;
                }
                textBox_ID.TextChanged -= textBox_ID_TextChanged;
                textBox_ID.Text = vNewNo;
                State = FormState.Edit;
                Button_Save.Enabled = true;
                Button_Save_Click(sender, e);
                textBox_ID.TextChanged += textBox_ID_TextChanged;
            }
            catch (Exception error)
            {
                textBox_ID.TextChanged += textBox_ID_TextChanged;
                VarGeneral.DebLog.writeLog("linkLabel_ChangeEmpNo_LinkClicked:", error, enable: true);
                MessageBox.Show((LangArEn == 0) ? "حصل خطأ ما .. لم يتم عملية التعديل بنجاح" : "Error .. Editing is not Done", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                MessageBox.Show(error.Message);
            }
        }
        private void button_SrchSalAcc_Click(object sender, EventArgs e)
        {
            Button_Edit_Click(sender, e);
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
            VarGeneral.SFrmTyp = "AccDefID_Setting";
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != string.Empty)
            {
                textBox_AccSal.Text = db.StockAccDefs(int.Parse(frm.Serach_No)).AccDef_No;
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                {
                    textBox_AccSalName.Text = db.StockAccDefs(int.Parse(frm.Serach_No)).Arb_Des;
                }
                else
                {
                    textBox_AccSalName.Text = db.StockAccDefs(int.Parse(frm.Serach_No)).Eng_Des;
                }
            }
            else
            {
                textBox_AccSal.Text = string.Empty;
                textBox_AccSalName.Text = string.Empty;
            }
        }
        private void button_SrchHousAcc_Click(object sender, EventArgs e)
        {
            Button_Edit_Click(sender, e);
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
            VarGeneral.SFrmTyp = "AccDefID_Setting";
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != string.Empty)
            {
                textBox_AccHousing.Text = db.StockAccDefs(int.Parse(frm.Serach_No)).AccDef_No;
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                {
                    textBox_AccHousingName.Text = db.StockAccDefs(int.Parse(frm.Serach_No)).Arb_Des;
                }
                else
                {
                    textBox_AccHousingName.Text = db.StockAccDefs(int.Parse(frm.Serach_No)).Eng_Des;
                }
            }
            else
            {
                textBox_AccHousing.Text = string.Empty;
                textBox_AccHousingName.Text = string.Empty;
            }
        }
        private void button_SrchAdvancAcc_Click(object sender, EventArgs e)
        {
            Button_Edit_Click(sender, e);
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
            VarGeneral.SFrmTyp = "AccDefID_Setting";
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != string.Empty)
            {
                textBox_AccLoan.Text = db.StockAccDefs(int.Parse(frm.Serach_No)).AccDef_No;
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                {
                    textBox_AccLoanName.Text = db.StockAccDefs(int.Parse(frm.Serach_No)).Arb_Des;
                }
                else
                {
                    textBox_AccLoanName.Text = db.StockAccDefs(int.Parse(frm.Serach_No)).Eng_Des;
                }
            }
            else
            {
                textBox_AccLoan.Text = string.Empty;
                textBox_AccLoanName.Text = string.Empty;
            }
        }
        private void button_SrchCostCenterAcc_Click(object sender, EventArgs e)
        {
            Button_Edit_Click(sender, e);
            columns_Names_visible2.Clear();
            columns_Names_visible2.Add("Cst_No", new ColumnDictinary("الرقم", "No", ifDefault: true, string.Empty));
            columns_Names_visible2.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, string.Empty));
            columns_Names_visible2.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, string.Empty));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible2;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
            }
            VarGeneral.SFrmTyp = "T_CstTbl";
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != string.Empty)
            {
                textBox_CostCenter.Text = db.StockCst(frm.Serach_No).Cst_ID.ToString();
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                {
                    textBox_CostCenterName.Text = db.StockCst(frm.Serach_No).Arb_Des.ToString();
                }
                else
                {
                    textBox_CostCenterName.Text = db.StockCst(frm.Serach_No).Eng_Des.ToString();
                }
            }
            else
            {
                textBox_CostCenter.Text = string.Empty;
                textBox_CostCenterName.Text = string.Empty;
            }
        }
        private void button_SrchBXBankNo_Click(object sender, EventArgs e)
        {
            Button_Edit_Click(sender, e);
            FrmSearch frm;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection;
            if (!switchButton_AccType.Value)
            {
                columns_Names_visible2.Clear();
                columns_Names_visible2.Add("AccDef_No", new ColumnDictinary("الرقم ", " No", ifDefault: true, string.Empty));
                columns_Names_visible2.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, string.Empty));
                columns_Names_visible2.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, string.Empty));
                columns_Names_visible2.Add("AccDef_ID", new ColumnDictinary(" ", " ", ifDefault: false, string.Empty));
                columns_Names_visible2.Add("Mobile", new ColumnDictinary("الجوال", "Mobile", ifDefault: false, string.Empty));
                frm = new FrmSearch();
                frm.Tag = LangArEn;
                animalsAsCollection = columns_Names_visible2;
                foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
                {
                    frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
                }
                VarGeneral.SFrmTyp = "T_AccDef2";
                VarGeneral.AccTyp = 2;
                frm.TopMost = true;
                frm.ShowDialog();
                if (frm.SerachNo != string.Empty)
                {
                    T_AccDef _AccDef = db.StockAccDefs(int.Parse(frm.Serach_No));
                    txtBXBankNo.Text = _AccDef.AccDef_No.ToString();
                    if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                    {
                        txtBXBankName.Text = _AccDef.Arb_Des.ToString();
                    }
                    else
                    {
                        txtBXBankName.Text = _AccDef.Eng_Des.ToString();
                    }
                }
                else
                {
                    txtBXBankNo.Text = string.Empty;
                    txtBXBankName.Text = string.Empty;
                }
                return;
            }
            columns_Names_visible2.Clear();
            columns_Names_visible2.Add("AccDef_No", new ColumnDictinary("الرقم ", " No", ifDefault: true, string.Empty));
            columns_Names_visible2.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, string.Empty));
            columns_Names_visible2.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, string.Empty));
            columns_Names_visible2.Add("AccDef_ID", new ColumnDictinary(" ", " ", ifDefault: false, string.Empty));
            columns_Names_visible2.Add("Mobile", new ColumnDictinary("الجوال", "Mobile", ifDefault: false, string.Empty));
            frm = new FrmSearch();
            frm.Tag = LangArEn;
            animalsAsCollection = columns_Names_visible2;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
            }
            VarGeneral.SFrmTyp = "T_AccDef2";
            VarGeneral.AccTyp = 3;
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != string.Empty)
            {
                T_AccDef _AccDef = db.StockAccDefs(int.Parse(frm.Serach_No));
                txtBXBankNo.Text = _AccDef.AccDef_No.ToString();
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                {
                    txtBXBankName.Text = _AccDef.Arb_Des.ToString();
                }
                else
                {
                    txtBXBankName.Text = _AccDef.Eng_Des.ToString();
                }
            }
            else
            {
                txtBXBankNo.Text = string.Empty;
                txtBXBankName.Text = string.Empty;
            }
        }
        private void buttonItem_EmpOut_CheckedChanged(object sender, EventArgs e)
        {
            if (buttonItem_EmpOut.Checked)
            {
                if (!ContinueIfEditOrNew())
                {
                    buttonItem_EmpOut.CheckedChanged -= buttonItem_EmpOut_CheckedChanged;
                    buttonItem_EmpOut.Checked = false;
                    buttonItem_EmpOut.CheckedChanged += buttonItem_EmpOut_CheckedChanged;
                    return;
                }
                VarGeneral.FrmEmpStat = false;
                Button_Save.Visible = false;
                buttonItem_Back.Visible = true;
                buttonItem_EmpOut.Text = ((LangArEn == 0) ? "    العاملـين" : "     Emp On");
            }
            else
            {
                VarGeneral.FrmEmpStat = true;
                Button_Save.Visible = true;
                buttonItem_Back.Visible = false;
                buttonItem_EmpOut.Text = ((LangArEn == 0) ? "    المفصولين" : "     Emp Off");
            }
            vMain();
        }
        private void buttonItem_Back_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox_ID.Text) && !string.IsNullOrEmpty(data_this.Emp_ID) && MessageBox.Show("سيتم تغيير حالة الموظف من المفصولين الى العاملين .. هل تريد المتبابعة ؟", VarGeneral.ProdectNam, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                data_this.EmpState = true;
                db.Log = VarGeneral.DebugLog;
                db.SubmitChanges(ConflictMode.ContinueOnConflict);
                State = FormState.Saved;
                RefreshPKeys();
                TextBox_Index.TextBox.Text = string.Concat(PKeys.IndexOf(data_this.Emp_No ?? string.Empty) + 1);
                dbInstance = null;
                textBox_ID_TextChanged(sender, e);
            }
        }
        private void buttonItem_EmpOut_Click(object sender, EventArgs e)
        {
        }
        private void textBox_VisaEnterNo_Click(object sender, EventArgs e)
        {
            textBox_VisaEnterNo.SelectAll();
        }
        private void textBox_VisaNo_Click(object sender, EventArgs e)
        {
            textBox_VisaNo.SelectAll();
        }
        private void textBox_VisaCountry_Click(object sender, EventArgs e)
        {
            textBox_VisaCountry.SelectAll();
        }
        private void button_SaveFamily_Click(object sender, EventArgs e)
        {
            if (Button_Save.Enabled || string.IsNullOrEmpty(data_this.Emp_No) || buttonItem_EmpOut.Checked)
            {
                return;
            }
            try
            {
                if (string.IsNullOrEmpty(textBox_ID.Text))
                {
                    return;
                }
                if (!buttonItem_EmpOut.Checked)
                {
                    if (db.CheckEmp_Family(textBox_ID.Tag.ToString()))
                    {
                        db.T_Families.DeleteAllOnSubmit(data_this.T_Families);
                        db.SubmitChanges();
                        dbInstance = null;
                    }
                    for (int i = 1; i <= 15; i++)
                    {
                        DataThisFamily = new T_Family();
                        if (i == 1 && !string.IsNullOrEmpty(textBox_Name1.Text))
                        {
                            Guid id = Guid.NewGuid();
                            DataThisFamily.Family_ID = id.ToString();
                            try
                            {
                                DataThisFamily.EmpID = textBox_ID.Tag.ToString();
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.Person_No = db.MaxFamilyNo;
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.Name = textBox_Name1.Text;
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.Link = textBox_Relation1.Text;
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.PassNo = textBox_PassporntNo1.Text;
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.PassEnd = Convert.ToDateTime(dateTimeInput_PassportDateEnd1.Text).ToString("yyyy/MM/dd");
                            }
                            catch
                            {
                                dateTimeInput_PassportDateEnd1.Text = string.Empty;
                                DataThisFamily.PassEnd = string.Empty;
                            }
                            try
                            {
                                DataThisFamily.BirthDay = Convert.ToDateTime(dateTimeInput_BirthDate1.Text).ToString("yyyy/MM/dd");
                            }
                            catch
                            {
                                dateTimeInput_BirthDate1.Text = string.Empty;
                                DataThisFamily.BirthDay = string.Empty;
                            }
                            db.T_Families.InsertOnSubmit(DataThisFamily);
                            db.SubmitChanges();
                        }
                        if (i == 2 && !string.IsNullOrEmpty(textBox_Name2.Text) && !string.IsNullOrEmpty(textBox_Name1.Text))
                        {
                            Guid id = Guid.NewGuid();
                            DataThisFamily.Family_ID = id.ToString();
                            try
                            {
                                DataThisFamily.EmpID = textBox_ID.Tag.ToString();
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.Person_No = db.MaxFamilyNo;
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.Name = textBox_Name2.Text;
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.Link = textBox_Relation2.Text;
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.PassNo = textBox_PassporntNo2.Text;
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.PassEnd = Convert.ToDateTime(dateTimeInput_PassportDateEnd2.Text).ToString("yyyy/MM/dd");
                            }
                            catch
                            {
                                dateTimeInput_PassportDateEnd2.Text = string.Empty;
                                DataThisFamily.PassEnd = string.Empty;
                            }
                            try
                            {
                                DataThisFamily.BirthDay = Convert.ToDateTime(dateTimeInput_BirthDate2.Text).ToString("yyyy/MM/dd");
                            }
                            catch
                            {
                                dateTimeInput_BirthDate2.Text = string.Empty;
                                DataThisFamily.BirthDay = string.Empty;
                            }
                            db.T_Families.InsertOnSubmit(DataThisFamily);
                            db.SubmitChanges();
                        }
                        if (i == 3 && !string.IsNullOrEmpty(textBox_Name3.Text) && !string.IsNullOrEmpty(textBox_Name2.Text))
                        {
                            Guid id = Guid.NewGuid();
                            DataThisFamily.Family_ID = id.ToString();
                            try
                            {
                                DataThisFamily.EmpID = textBox_ID.Tag.ToString();
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.Person_No = db.MaxFamilyNo;
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.Name = textBox_Name3.Text;
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.Link = textBox_Relation3.Text;
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.PassNo = textBox_PassporntNo3.Text;
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.PassEnd = Convert.ToDateTime(dateTimeInput_PassportDateEnd3.Text).ToString("yyyy/MM/dd");
                            }
                            catch
                            {
                                dateTimeInput_PassportDateEnd3.Text = string.Empty;
                                DataThisFamily.PassEnd = string.Empty;
                            }
                            try
                            {
                                DataThisFamily.BirthDay = Convert.ToDateTime(dateTimeInput_BirthDate3.Text).ToString("yyyy/MM/dd");
                            }
                            catch
                            {
                                dateTimeInput_BirthDate3.Text = string.Empty;
                                DataThisFamily.BirthDay = string.Empty;
                            }
                            db.T_Families.InsertOnSubmit(DataThisFamily);
                            db.SubmitChanges();
                        }
                        if (i == 4 && !string.IsNullOrEmpty(textBox_Name4.Text) && !string.IsNullOrEmpty(textBox_Name3.Text))
                        {
                            Guid id = Guid.NewGuid();
                            DataThisFamily.Family_ID = id.ToString();
                            try
                            {
                                DataThisFamily.EmpID = textBox_ID.Tag.ToString();
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.Person_No = db.MaxFamilyNo;
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.Name = textBox_Name4.Text;
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.Link = textBox_Relation4.Text;
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.PassNo = textBox_PassporntNo4.Text;
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.PassEnd = Convert.ToDateTime(dateTimeInput_PassportDateEnd4.Text).ToString("yyyy/MM/dd");
                            }
                            catch
                            {
                                dateTimeInput_PassportDateEnd4.Text = string.Empty;
                                DataThisFamily.PassEnd = string.Empty;
                            }
                            try
                            {
                                DataThisFamily.BirthDay = Convert.ToDateTime(dateTimeInput_BirthDate4.Text).ToString("yyyy/MM/dd");
                            }
                            catch
                            {
                                dateTimeInput_BirthDate4.Text = string.Empty;
                                DataThisFamily.BirthDay = string.Empty;
                            }
                            db.T_Families.InsertOnSubmit(DataThisFamily);
                            db.SubmitChanges();
                        }
                        if (i == 5 && !string.IsNullOrEmpty(textBox_Name5.Text) && !string.IsNullOrEmpty(textBox_Name4.Text))
                        {
                            Guid id = Guid.NewGuid();
                            DataThisFamily.Family_ID = id.ToString();
                            try
                            {
                                DataThisFamily.EmpID = textBox_ID.Tag.ToString();
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.Person_No = db.MaxFamilyNo;
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.Name = textBox_Name5.Text;
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.Link = textBox_Relation5.Text;
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.PassNo = textBox_PassporntNo5.Text;
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.PassEnd = Convert.ToDateTime(dateTimeInput_PassportDateEnd5.Text).ToString("yyyy/MM/dd");
                            }
                            catch
                            {
                                dateTimeInput_PassportDateEnd5.Text = string.Empty;
                                DataThisFamily.PassEnd = string.Empty;
                            }
                            try
                            {
                                DataThisFamily.BirthDay = Convert.ToDateTime(dateTimeInput_BirthDate5.Text).ToString("yyyy/MM/dd");
                            }
                            catch
                            {
                                dateTimeInput_BirthDate5.Text = string.Empty;
                                DataThisFamily.BirthDay = string.Empty;
                            }
                            db.T_Families.InsertOnSubmit(DataThisFamily);
                            db.SubmitChanges();
                        }
                        if (i == 6 && !string.IsNullOrEmpty(textBox_Name6.Text) && !string.IsNullOrEmpty(textBox_Name5.Text))
                        {
                            Guid id = Guid.NewGuid();
                            DataThisFamily.Family_ID = id.ToString();
                            try
                            {
                                DataThisFamily.EmpID = textBox_ID.Tag.ToString();
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.Person_No = db.MaxFamilyNo;
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.Name = textBox_Name6.Text;
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.Link = textBox_Relation6.Text;
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.PassNo = textBox_PassporntNo6.Text;
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.PassEnd = Convert.ToDateTime(dateTimeInput_PassportDateEnd6.Text).ToString("yyyy/MM/dd");
                            }
                            catch
                            {
                                dateTimeInput_PassportDateEnd6.Text = string.Empty;
                                DataThisFamily.PassEnd = string.Empty;
                            }
                            try
                            {
                                DataThisFamily.BirthDay = Convert.ToDateTime(dateTimeInput_BirthDate6.Text).ToString("yyyy/MM/dd");
                            }
                            catch
                            {
                                dateTimeInput_BirthDate6.Text = string.Empty;
                                DataThisFamily.BirthDay = string.Empty;
                            }
                            db.T_Families.InsertOnSubmit(DataThisFamily);
                            db.SubmitChanges();
                        }
                        if (i == 7 && !string.IsNullOrEmpty(textBox_Name7.Text) && !string.IsNullOrEmpty(textBox_Name6.Text))
                        {
                            Guid id = Guid.NewGuid();
                            DataThisFamily.Family_ID = id.ToString();
                            try
                            {
                                DataThisFamily.EmpID = textBox_ID.Tag.ToString();
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.Person_No = db.MaxFamilyNo;
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.Name = textBox_Name7.Text;
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.Link = textBox_Relation7.Text;
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.PassNo = textBox_PassporntNo7.Text;
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.PassEnd = Convert.ToDateTime(dateTimeInput_PassportDateEnd6.Text).ToString("yyyy/MM/dd");
                            }
                            catch
                            {
                                dateTimeInput_PassportDateEnd6.Text = string.Empty;
                                DataThisFamily.PassEnd = string.Empty;
                            }
                            try
                            {
                                DataThisFamily.BirthDay = Convert.ToDateTime(dateTimeInput_BirthDate7.Text).ToString("yyyy/MM/dd");
                            }
                            catch
                            {
                                dateTimeInput_BirthDate7.Text = string.Empty;
                                DataThisFamily.BirthDay = string.Empty;
                            }
                            db.T_Families.InsertOnSubmit(DataThisFamily);
                            db.SubmitChanges();
                        }
                        if (i == 8 && !string.IsNullOrEmpty(textBox_Name8.Text) && !string.IsNullOrEmpty(textBox_Name7.Text))
                        {
                            Guid id = Guid.NewGuid();
                            DataThisFamily.Family_ID = id.ToString();
                            try
                            {
                                DataThisFamily.EmpID = textBox_ID.Tag.ToString();
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.Person_No = db.MaxFamilyNo;
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.Name = textBox_Name8.Text;
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.Link = textBox_Relation8.Text;
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.PassNo = textBox_PassporntNo8.Text;
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.PassEnd = Convert.ToDateTime(dateTimeInput_PassportDateEnd6.Text).ToString("yyyy/MM/dd");
                            }
                            catch
                            {
                                dateTimeInput_PassportDateEnd6.Text = string.Empty;
                                DataThisFamily.PassEnd = string.Empty;
                            }
                            try
                            {
                                DataThisFamily.BirthDay = Convert.ToDateTime(dateTimeInput_BirthDate8.Text).ToString("yyyy/MM/dd");
                            }
                            catch
                            {
                                dateTimeInput_BirthDate8.Text = string.Empty;
                                DataThisFamily.BirthDay = string.Empty;
                            }
                            db.T_Families.InsertOnSubmit(DataThisFamily);
                            db.SubmitChanges();
                        }
                        if (i == 9 && !string.IsNullOrEmpty(textBox_Name9.Text) && !string.IsNullOrEmpty(textBox_Name8.Text))
                        {
                            Guid id = Guid.NewGuid();
                            DataThisFamily.Family_ID = id.ToString();
                            try
                            {
                                DataThisFamily.EmpID = textBox_ID.Tag.ToString();
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.Person_No = db.MaxFamilyNo;
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.Name = textBox_Name9.Text;
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.Link = textBox_Relation9.Text;
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.PassNo = textBox_PassporntNo9.Text;
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.PassEnd = Convert.ToDateTime(dateTimeInput_PassportDateEnd9.Text).ToString("yyyy/MM/dd");
                            }
                            catch
                            {
                                dateTimeInput_PassportDateEnd9.Text = string.Empty;
                                DataThisFamily.PassEnd = string.Empty;
                            }
                            try
                            {
                                DataThisFamily.BirthDay = Convert.ToDateTime(dateTimeInput_BirthDate9.Text).ToString("yyyy/MM/dd");
                            }
                            catch
                            {
                                dateTimeInput_BirthDate9.Text = string.Empty;
                                DataThisFamily.BirthDay = string.Empty;
                            }
                            db.T_Families.InsertOnSubmit(DataThisFamily);
                            db.SubmitChanges();
                        }
                        if (i == 10 && !string.IsNullOrEmpty(textBox_Name10.Text) && !string.IsNullOrEmpty(textBox_Name9.Text))
                        {
                            Guid id = Guid.NewGuid();
                            DataThisFamily.Family_ID = id.ToString();
                            try
                            {
                                DataThisFamily.EmpID = textBox_ID.Tag.ToString();
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.Person_No = db.MaxFamilyNo;
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.Name = textBox_Name10.Text;
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.Link = textBox_Relation10.Text;
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.PassNo = textBox_PassporntNo10.Text;
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.PassEnd = Convert.ToDateTime(dateTimeInput_PassportDateEnd10.Text).ToString("yyyy/MM/dd");
                            }
                            catch
                            {
                                dateTimeInput_PassportDateEnd10.Text = string.Empty;
                                DataThisFamily.PassEnd = string.Empty;
                            }
                            try
                            {
                                DataThisFamily.BirthDay = Convert.ToDateTime(dateTimeInput_BirthDate10.Text).ToString("yyyy/MM/dd");
                            }
                            catch
                            {
                                dateTimeInput_BirthDate10.Text = string.Empty;
                                DataThisFamily.BirthDay = string.Empty;
                            }
                            db.T_Families.InsertOnSubmit(DataThisFamily);
                            db.SubmitChanges();
                        }
                        if (i == 11 && !string.IsNullOrEmpty(textBox_Name11.Text))
                        {
                            Guid id = Guid.NewGuid();
                            DataThisFamily.Family_ID = id.ToString();
                            try
                            {
                                DataThisFamily.EmpID = textBox_ID.Tag.ToString();
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.Person_No = db.MaxFamilyNo;
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.Name = textBox_Name11.Text;
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.Link = textBox_Relation11.Text;
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.PassNo = textBox_PassporntNo11.Text;
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.PassEnd = Convert.ToDateTime(dateTimeInput_PassportDateEnd11.Text).ToString("yyyy/MM/dd");
                            }
                            catch
                            {
                                dateTimeInput_PassportDateEnd11.Text = string.Empty;
                                DataThisFamily.PassEnd = string.Empty;
                            }
                            try
                            {
                                DataThisFamily.BirthDay = Convert.ToDateTime(dateTimeInput_BirthDate11.Text).ToString("yyyy/MM/dd");
                            }
                            catch
                            {
                                dateTimeInput_BirthDate11.Text = string.Empty;
                                DataThisFamily.BirthDay = string.Empty;
                            }
                            db.T_Families.InsertOnSubmit(DataThisFamily);
                            db.SubmitChanges();
                        }
                        if (i == 12 && !string.IsNullOrEmpty(textBox_Name12.Text))
                        {
                            Guid id = Guid.NewGuid();
                            DataThisFamily.Family_ID = id.ToString();
                            try
                            {
                                DataThisFamily.EmpID = textBox_ID.Tag.ToString();
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.Person_No = db.MaxFamilyNo;
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.Name = textBox_Name12.Text;
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.Link = textBox_Relation12.Text;
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.PassNo = textBox_PassporntNo12.Text;
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.PassEnd = Convert.ToDateTime(dateTimeInput_PassportDateEnd12.Text).ToString("yyyy/MM/dd");
                            }
                            catch
                            {
                                dateTimeInput_PassportDateEnd12.Text = string.Empty;
                                DataThisFamily.PassEnd = string.Empty;
                            }
                            try
                            {
                                DataThisFamily.BirthDay = Convert.ToDateTime(dateTimeInput_BirthDate12.Text).ToString("yyyy/MM/dd");
                            }
                            catch
                            {
                                dateTimeInput_BirthDate12.Text = string.Empty;
                                DataThisFamily.BirthDay = string.Empty;
                            }
                            db.T_Families.InsertOnSubmit(DataThisFamily);
                            db.SubmitChanges();
                        }
                        if (i == 13 && !string.IsNullOrEmpty(textBox_Name13.Text))
                        {
                            Guid id = Guid.NewGuid();
                            DataThisFamily.Family_ID = id.ToString();
                            try
                            {
                                DataThisFamily.EmpID = textBox_ID.Tag.ToString();
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.Person_No = db.MaxFamilyNo;
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.Name = textBox_Name13.Text;
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.Link = textBox_Relation13.Text;
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.PassNo = textBox_PassporntNo13.Text;
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.PassEnd = Convert.ToDateTime(dateTimeInput_PassportDateEnd13.Text).ToString("yyyy/MM/dd");
                            }
                            catch
                            {
                                dateTimeInput_PassportDateEnd13.Text = string.Empty;
                                DataThisFamily.PassEnd = string.Empty;
                            }
                            try
                            {
                                DataThisFamily.BirthDay = Convert.ToDateTime(dateTimeInput_BirthDate13.Text).ToString("yyyy/MM/dd");
                            }
                            catch
                            {
                                dateTimeInput_BirthDate13.Text = string.Empty;
                                DataThisFamily.BirthDay = string.Empty;
                            }
                            db.T_Families.InsertOnSubmit(DataThisFamily);
                            db.SubmitChanges();
                        }
                        if (i == 14 && !string.IsNullOrEmpty(textBox_Name14.Text))
                        {
                            Guid id = Guid.NewGuid();
                            DataThisFamily.Family_ID = id.ToString();
                            try
                            {
                                DataThisFamily.EmpID = textBox_ID.Tag.ToString();
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.Person_No = db.MaxFamilyNo;
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.Name = textBox_Name14.Text;
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.Link = textBox_Relation14.Text;
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.PassNo = textBox_PassporntNo14.Text;
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.PassEnd = Convert.ToDateTime(dateTimeInput_PassportDateEnd14.Text).ToString("yyyy/MM/dd");
                            }
                            catch
                            {
                                dateTimeInput_PassportDateEnd14.Text = string.Empty;
                                DataThisFamily.PassEnd = string.Empty;
                            }
                            try
                            {
                                DataThisFamily.BirthDay = Convert.ToDateTime(dateTimeInput_BirthDate14.Text).ToString("yyyy/MM/dd");
                            }
                            catch
                            {
                                dateTimeInput_BirthDate14.Text = string.Empty;
                                DataThisFamily.BirthDay = string.Empty;
                            }
                            db.T_Families.InsertOnSubmit(DataThisFamily);
                            db.SubmitChanges();
                        }
                        if (i == 15 && !string.IsNullOrEmpty(textBox_Name15.Text))
                        {
                            Guid id = Guid.NewGuid();
                            DataThisFamily.Family_ID = id.ToString();
                            try
                            {
                                DataThisFamily.EmpID = textBox_ID.Tag.ToString();
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.Person_No = db.MaxFamilyNo;
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.Name = textBox_Name15.Text;
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.Link = textBox_Relation15.Text;
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.PassNo = textBox_PassporntNo15.Text;
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.PassEnd = Convert.ToDateTime(dateTimeInput_PassportDateEnd15.Text).ToString("yyyy/MM/dd");
                            }
                            catch
                            {
                                dateTimeInput_PassportDateEnd15.Text = string.Empty;
                                DataThisFamily.PassEnd = string.Empty;
                            }
                            try
                            {
                                DataThisFamily.BirthDay = Convert.ToDateTime(dateTimeInput_BirthDate15.Text).ToString("yyyy/MM/dd");
                            }
                            catch
                            {
                                dateTimeInput_BirthDate15.Text = string.Empty;
                                DataThisFamily.BirthDay = string.Empty;
                            }
                            db.T_Families.InsertOnSubmit(DataThisFamily);
                            db.SubmitChanges();
                        }
                    }
                    textBox_ID_TextChanged(sender, e);
                }
                else
                {
                    MessageBox.Show((LangArEn == 0) ? "لايمكن تحديث بيانات موظف موقوف .. الرجاء استرجاع الموظف اولا !" : "The Employee is Suspended", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Button_Ok_Click:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void textBox_Insurance_Class_Click(object sender, EventArgs e)
        {
            textBox_Insurance_Class.SelectAll();
        }
        private void dateTimeInput_BirthDate1_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_BirthDate1.Text = Convert.ToDateTime(dateTimeInput_BirthDate1.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_BirthDate1.Text = string.Empty;
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
                dateTimeInput_BirthDate2.Text = string.Empty;
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
                dateTimeInput_BirthDate3.Text = string.Empty;
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
                dateTimeInput_BirthDate4.Text = string.Empty;
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
                dateTimeInput_BirthDate5.Text = string.Empty;
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
                dateTimeInput_BirthDate6.Text = string.Empty;
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
                dateTimeInput_BirthDate7.Text = string.Empty;
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
                dateTimeInput_BirthDate8.Text = string.Empty;
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
                dateTimeInput_BirthDate9.Text = string.Empty;
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
                dateTimeInput_BirthDate10.Text = string.Empty;
            }
        }
        private void dateTimeInput_BirthDate11_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_BirthDate11.Text = Convert.ToDateTime(dateTimeInput_BirthDate11.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_BirthDate11.Text = string.Empty;
            }
        }
        private void dateTimeInput_BirthDate12_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_BirthDate12.Text = Convert.ToDateTime(dateTimeInput_BirthDate12.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_BirthDate12.Text = string.Empty;
            }
        }
        private void dateTimeInput_BirthDate13_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_BirthDate13.Text = Convert.ToDateTime(dateTimeInput_BirthDate13.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_BirthDate13.Text = string.Empty;
            }
        }
        private void dateTimeInput_BirthDate14_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_BirthDate14.Text = Convert.ToDateTime(dateTimeInput_BirthDate14.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_BirthDate14.Text = string.Empty;
            }
        }
        private void dateTimeInput_BirthDate15_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_BirthDate15.Text = Convert.ToDateTime(dateTimeInput_BirthDate15.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_BirthDate15.Text = string.Empty;
            }
        }
        private void dateTimeInput_PassportDateEnd1_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_PassportDateEnd1.Text = Convert.ToDateTime(dateTimeInput_PassportDateEnd1.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_PassportDateEnd1.Text = string.Empty;
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
                dateTimeInput_PassportDateEnd2.Text = string.Empty;
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
                dateTimeInput_PassportDateEnd3.Text = string.Empty;
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
                dateTimeInput_PassportDateEnd4.Text = string.Empty;
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
                dateTimeInput_PassportDateEnd5.Text = string.Empty;
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
                dateTimeInput_PassportDateEnd6.Text = string.Empty;
            }
        }
        private void dateTimeInput_PassportDateEnd7_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_PassportDateEnd6.Text = Convert.ToDateTime(dateTimeInput_PassportDateEnd6.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_PassportDateEnd6.Text = string.Empty;
            }
        }
        private void dateTimeInput_PassportDateEnd8_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_PassportDateEnd6.Text = Convert.ToDateTime(dateTimeInput_PassportDateEnd6.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_PassportDateEnd6.Text = string.Empty;
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
                dateTimeInput_PassportDateEnd9.Text = string.Empty;
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
                dateTimeInput_PassportDateEnd10.Text = string.Empty;
            }
        }
        private void dateTimeInput_PassportDateEnd11_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_PassportDateEnd11.Text = Convert.ToDateTime(dateTimeInput_PassportDateEnd11.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_PassportDateEnd11.Text = string.Empty;
            }
        }
        private void dateTimeInput_PassportDateEnd12_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_PassportDateEnd12.Text = Convert.ToDateTime(dateTimeInput_PassportDateEnd12.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_PassportDateEnd12.Text = string.Empty;
            }
        }
        private void dateTimeInput_PassportDateEnd13_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_PassportDateEnd13.Text = Convert.ToDateTime(dateTimeInput_PassportDateEnd13.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_PassportDateEnd13.Text = string.Empty;
            }
        }
        private void dateTimeInput_PassportDateEnd14_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_PassportDateEnd14.Text = Convert.ToDateTime(dateTimeInput_PassportDateEnd14.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_PassportDateEnd14.Text = string.Empty;
            }
        }
        private void dateTimeInput_PassportDateEnd15_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_PassportDateEnd15.Text = Convert.ToDateTime(dateTimeInput_PassportDateEnd15.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_PassportDateEnd15.Text = string.Empty;
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
        private void dateTimeInput_BirthDate11_Click(object sender, EventArgs e)
        {
            dateTimeInput_BirthDate11.SelectAll();
        }
        private void dateTimeInput_BirthDate12_Click(object sender, EventArgs e)
        {
            dateTimeInput_BirthDate12.SelectAll();
        }
        private void dateTimeInput_BirthDate13_Click(object sender, EventArgs e)
        {
            dateTimeInput_BirthDate13.SelectAll();
        }
        private void dateTimeInput_BirthDate14_Click(object sender, EventArgs e)
        {
            dateTimeInput_BirthDate14.SelectAll();
        }
        private void dateTimeInput_BirthDate15_Click(object sender, EventArgs e)
        {
            dateTimeInput_BirthDate15.SelectAll();
        }
        private void dateTimeInput_PassportDateEnd15_Click(object sender, EventArgs e)
        {
            dateTimeInput_PassportDateEnd15.SelectAll();
        }
        private void dateTimeInput_PassportDateEnd14_Click(object sender, EventArgs e)
        {
            dateTimeInput_PassportDateEnd14.SelectAll();
        }
        private void dateTimeInput_PassportDateEnd13_Click(object sender, EventArgs e)
        {
            dateTimeInput_PassportDateEnd13.SelectAll();
        }
        private void dateTimeInput_PassportDateEnd12_Click(object sender, EventArgs e)
        {
            dateTimeInput_PassportDateEnd12.SelectAll();
        }
        private void dateTimeInput_PassportDateEnd11_Click(object sender, EventArgs e)
        {
            dateTimeInput_PassportDateEnd11.SelectAll();
        }
        private void dateTimeInput_PassportDateEnd10_Click(object sender, EventArgs e)
        {
            dateTimeInput_PassportDateEnd10.SelectAll();
        }
        private void dateTimeInput_PassportDateEnd9_Click(object sender, EventArgs e)
        {
            dateTimeInput_PassportDateEnd9.SelectAll();
        }
        private void dateTimeInput_PassportDateEnd8_Click(object sender, EventArgs e)
        {
            dateTimeInput_PassportDateEnd8.SelectAll();
        }
        private void dateTimeInput_PassportDateEnd7_Click(object sender, EventArgs e)
        {
            dateTimeInput_PassportDateEnd7.SelectAll();
        }
        private void dateTimeInput_PassportDateEnd6_Click(object sender, EventArgs e)
        {
            dateTimeInput_PassportDateEnd6.SelectAll();
        }
        private void dateTimeInput_PassportDateEnd5_Click(object sender, EventArgs e)
        {
            dateTimeInput_PassportDateEnd5.SelectAll();
        }
        private void dateTimeInput_PassportDateEnd4_Click(object sender, EventArgs e)
        {
            dateTimeInput_PassportDateEnd4.SelectAll();
        }
        private void dateTimeInput_PassportDateEnd3_Click(object sender, EventArgs e)
        {
            dateTimeInput_PassportDateEnd3.SelectAll();
        }
        private void dateTimeInput_PassportDateEnd2_Click(object sender, EventArgs e)
        {
            dateTimeInput_PassportDateEnd2.SelectAll();
        }
        private void dateTimeInput_PassportDateEnd1_Click(object sender, EventArgs e)
        {
            dateTimeInput_PassportDateEnd1.SelectAll();
        }
        private void textBox_PassporntNo1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (e.KeyChar != '\b'))
            {
                e.Handled = true;
            }
        }
        private void button_PhotoShoot_Click(object sender, EventArgs e)
        {
        }
        private void textBox_Name2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_Name1.Text))
            {
                e.Handled = true;
            }
        }
        private void textBox_Name3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_Name2.Text))
            {
                e.Handled = true;
            }
        }
        private void textBox_Name4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_Name3.Text))
            {
                e.Handled = true;
            }
        }
        private void textBox_Name5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_Name4.Text))
            {
                e.Handled = true;
            }
        }
        private void textBox_Name6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_Name5.Text))
            {
                e.Handled = true;
            }
        }
        private void textBox_Name7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_Name6.Text))
            {
                e.Handled = true;
            }
        }
        private void textBox_Name8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_Name7.Text))
            {
                e.Handled = true;
            }
        }
        private void textBox_Name9_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_Name8.Text))
            {
                e.Handled = true;
            }
        }
        private void textBox_Name10_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_Name9.Text))
            {
                e.Handled = true;
            }
        }
        private void button_SrchReligion_Click(object sender, EventArgs e)
        {
            try
            {
                Button_Edit_Click(sender, e);
                Dir_ButSearch.Add("Religion_No", new ColumnDictinary("رقم الديانة", "Religion No", ifDefault: true, string.Empty));
                Dir_ButSearch.Add("NameA", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, string.Empty));
                Dir_ButSearch.Add("NameE", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: false, string.Empty));
                Dir_ButSearch.Add("Note", new ColumnDictinary("الملاحظات", "Note", ifDefault: true, string.Empty));
                FrmSearch frm = new FrmSearch();
                frm.Tag = LangArEn;
                ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = Dir_ButSearch;
                foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
                {
                    frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
                }
                VarGeneral.SFrmTyp = "T_Religion";
                frm.TopMost = true;
                frm.ShowDialog();
                if (frm.SerachNo != string.Empty)
                {
                    comboBox_Religion.SelectedValue = int.Parse(frm.SerachNo);
                }
                Dir_ButSearch.Clear();
            }
            catch
            {
            }
        }
        private void button_SrchBirthPlaces_Click(object sender, EventArgs e)
        {
            try
            {
                Button_Edit_Click(sender, e);
                Dir_ButSearch.Add("BirthPlaceNo", new ColumnDictinary("الرقم", "No", ifDefault: true, string.Empty));
                Dir_ButSearch.Add("NameA", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, string.Empty));
                Dir_ButSearch.Add("NameE", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: false, string.Empty));
                FrmSearch frm = new FrmSearch();
                frm.Tag = LangArEn;
                ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = Dir_ButSearch;
                foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
                {
                    frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
                }
                VarGeneral.SFrmTyp = "BirthPlaceNo";
                frm.TopMost = true;
                frm.ShowDialog();
                if (frm.SerachNo != string.Empty)
                {
                    comboBox_BirthPlace.SelectedValue = int.Parse(frm.SerachNo);
                }
                Dir_ButSearch.Clear();
            }
            catch
            {
            }
        }
        private void button_SrchCities_Click(object sender, EventArgs e)
        {
            try
            {
                Button_Edit_Click(sender, e);
                Dir_ButSearch.Add("City_No", new ColumnDictinary("رقم المدينة", "City No", ifDefault: true, string.Empty));
                Dir_ButSearch.Add("NameA", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, string.Empty));
                Dir_ButSearch.Add("NameE", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: false, string.Empty));
                Dir_ButSearch.Add("Note", new ColumnDictinary("الملاحظات", "Note", ifDefault: true, string.Empty));
                FrmSearch frm = new FrmSearch();
                frm.Tag = LangArEn;
                ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = Dir_ButSearch;
                foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
                {
                    frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
                }
                VarGeneral.SFrmTyp = "T_City";
                frm.TopMost = true;
                frm.ShowDialog();
                if (frm.SerachNo != string.Empty)
                {
                    comboBox_CityNo.SelectedValue = int.Parse(frm.SerachNo);
                }
                Dir_ButSearch.Clear();
            }
            catch
            {
            }
        }
        private void textBox_SocialInsuranceNo_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_SocialInsuranceNo.Text))
            {
                textBox_SocialInsuranceNo.ButtonCustom.Visible = false;
            }
            else
            {
                textBox_SocialInsuranceNo.ButtonCustom.Visible = true;
            }
        }
        private void textBox_WorkNo_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_WorkNo.Text))
            {
                textBox_WorkNo.ButtonCustom.Visible = false;
            }
            else
            {
                textBox_WorkNo.ButtonCustom.Visible = true;
            }
        }
        private void expandablePanel_attends_ExpandedChanged(object sender, ExpandedChangeEventArgs e)
        {
        }
        private void expandablePanel_Sat_ExpandedChanging(object sender, ExpandedChangeEventArgs e)
        {
            if (!expandablePanel_attends.Expanded)
            {
                e.Cancel = true;
            }
        }
        private void button_BankCall_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBXBankNo.Text))
            {
                Button_Edit_Click(sender, e);
                textBox_AccSal.Text = txtBXBankNo.Text;
                textBox_AccSalName.Text = txtBXBankName.Text;
            }
        }
        private void groupBox3_Enter(object sender, EventArgs e)
        {
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
            this.components = new System.ComponentModel.Container();
            this.PanelSpecialContainer = new System.Windows.Forms.Panel();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEmp));
            DevComponents.DotNetBar.Rendering.SuperTabColorTable superTabColorTable1 = new DevComponents.DotNetBar.Rendering.SuperTabColorTable();
            DevComponents.DotNetBar.Rendering.SuperTabLinearGradientColorTable superTabLinearGradientColorTable1 = new DevComponents.DotNetBar.Rendering.SuperTabLinearGradientColorTable();
            DevComponents.DotNetBar.SuperGrid.Style.Background background1 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.Style.Background background2 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.Style.Background background3 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.Style.BorderColor borderColor1 = new DevComponents.DotNetBar.SuperGrid.Style.BorderColor();
            DevComponents.DotNetBar.SuperGrid.Style.BorderColor borderColor2 = new DevComponents.DotNetBar.SuperGrid.Style.BorderColor();
            DevComponents.DotNetBar.SuperGrid.Style.BaseTreeButtonVisualStyle baseTreeButtonVisualStyle1 = new DevComponents.DotNetBar.SuperGrid.Style.BaseTreeButtonVisualStyle();
            DevComponents.DotNetBar.SuperGrid.Style.BaseTreeButtonVisualStyle baseTreeButtonVisualStyle2 = new DevComponents.DotNetBar.SuperGrid.Style.BaseTreeButtonVisualStyle();
            DevComponents.DotNetBar.SuperGrid.Style.Background background4 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.timerInfoBallon = new System.Windows.Forms.Timer(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.barTopDockSite = new DevComponents.DotNetBar.DockSite();
            this.barBottomDockSite = new DevComponents.DotNetBar.DockSite();
            this.dotNetBarManager1 = new DevComponents.DotNetBar.DotNetBarManager(this.components);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.barLeftDockSite = new DevComponents.DotNetBar.DockSite();
            this.barRightDockSite = new DevComponents.DotNetBar.DockSite();
            this.dockSite4 = new DevComponents.DotNetBar.DockSite();
            this.dockSite1 = new DevComponents.DotNetBar.DockSite();
            this.dockSite2 = new DevComponents.DotNetBar.DockSite();
            this.dockSite3 = new DevComponents.DotNetBar.DockSite();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItem_Rep = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Det = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.panelEx2 = new DevComponents.DotNetBar.PanelEx();
            this.ribbonBar1 = new DevComponents.DotNetBar.RibbonBar();
            this.superTabControl_Employee = new DevComponents.DotNetBar.SuperTabControl();
            this.superTabControlPanel18 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.panelEx5 = new DevComponents.DotNetBar.PanelEx();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.textBox_TicketsCount = new DevComponents.Editors.DoubleInput();
            this.textBox_TicketsBalance = new DevComponents.Editors.DoubleInput();
            this.textBox_TicketsPrice = new DevComponents.Editors.DoubleInput();
            this.label68 = new System.Windows.Forms.Label();
            this.label65 = new System.Windows.Forms.Label();
            this.label67 = new System.Windows.Forms.Label();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.textBox_VacationBalance = new DevComponents.Editors.DoubleInput();
            this.textBox_VacationCount = new DevComponents.Editors.IntegerInput();
            this.label64 = new System.Windows.Forms.Label();
            this.label62 = new System.Windows.Forms.Label();
            this.label63 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupPanel15 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.button_BankCall = new DevComponents.DotNetBar.ButtonX();
            this.button_SrchCostCenterAcc = new DevComponents.DotNetBar.ButtonX();
            this.textBox_CostCenter = new System.Windows.Forms.TextBox();
            this.label116 = new System.Windows.Forms.Label();
            this.textBox_CostCenterName = new System.Windows.Forms.TextBox();
            this.button_SrchAdvancAcc = new DevComponents.DotNetBar.ButtonX();
            this.textBox_AccLoan = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.textBox_AccLoanName = new System.Windows.Forms.TextBox();
            this.button_SrchHousAcc = new DevComponents.DotNetBar.ButtonX();
            this.textBox_AccHousing = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.textBox_AccHousingName = new System.Windows.Forms.TextBox();
            this.button_SrchSalAcc = new DevComponents.DotNetBar.ButtonX();
            this.textBox_AccSal = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.textBox_AccSalName = new System.Windows.Forms.TextBox();
            this.switchButton_AccType = new DevComponents.DotNetBar.Controls.SwitchButton();
            this.txtBXBankName = new System.Windows.Forms.TextBox();
            this.button_SrchBXBankNo = new DevComponents.DotNetBar.ButtonX();
            this.txtBXBankNo = new System.Windows.Forms.TextBox();
            this.expandablePanel_attends = new DevComponents.DotNetBar.ExpandablePanel();
            this.expandablePanel_Fri = new DevComponents.DotNetBar.ExpandablePanel();
            this.itemPanel7 = new DevComponents.DotNetBar.ItemPanel();
            this.groupPanel11 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.textBox_LeaveTime2 = new System.Windows.Forms.MaskedTextBox();
            this.label50 = new System.Windows.Forms.Label();
            this.textBox_FriTimeAllow2 = new System.Windows.Forms.MaskedTextBox();
            this.label51 = new System.Windows.Forms.Label();
            this.textBox_FriTime2 = new System.Windows.Forms.MaskedTextBox();
            this.label58 = new System.Windows.Forms.Label();
            this.groupPanel12 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.textBox_LeaveTime1 = new System.Windows.Forms.MaskedTextBox();
            this.label61 = new System.Windows.Forms.Label();
            this.textBox_FriTimeAllow1 = new System.Windows.Forms.MaskedTextBox();
            this.label66 = new System.Windows.Forms.Label();
            this.textBox_FriTime1 = new System.Windows.Forms.MaskedTextBox();
            this.label69 = new System.Windows.Forms.Label();
            this.radioButton_FriBreakDay = new System.Windows.Forms.RadioButton();
            this.radioButton_FriPeriods2 = new System.Windows.Forms.RadioButton();
            this.radioButton_FriPeriods1 = new System.Windows.Forms.RadioButton();
            this.expandablePanel_Thurs = new DevComponents.DotNetBar.ExpandablePanel();
            this.itemPanel6 = new DevComponents.DotNetBar.ItemPanel();
            this.groupPanel13 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.textBox_ThurLeaveTime2 = new System.Windows.Forms.MaskedTextBox();
            this.label71 = new System.Windows.Forms.Label();
            this.textBox_ThurTimeAllow2 = new System.Windows.Forms.MaskedTextBox();
            this.label77 = new System.Windows.Forms.Label();
            this.textBox_ThurTime2 = new System.Windows.Forms.MaskedTextBox();
            this.label81 = new System.Windows.Forms.Label();
            this.groupPanel14 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.textBox_ThurLeaveTime1 = new System.Windows.Forms.MaskedTextBox();
            this.label87 = new System.Windows.Forms.Label();
            this.textBox_ThurTimeAllow1 = new System.Windows.Forms.MaskedTextBox();
            this.label93 = new System.Windows.Forms.Label();
            this.textBox_ThurTime1 = new System.Windows.Forms.MaskedTextBox();
            this.label94 = new System.Windows.Forms.Label();
            this.radioButton_ThurBreakDay = new System.Windows.Forms.RadioButton();
            this.radioButton_ThurPeriods2 = new System.Windows.Forms.RadioButton();
            this.radioButton_ThurPeriods1 = new System.Windows.Forms.RadioButton();
            this.expandablePanel_Wen = new DevComponents.DotNetBar.ExpandablePanel();
            this.itemPanel5 = new DevComponents.DotNetBar.ItemPanel();
            this.groupPanel9 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.textBox_WenLeaveTime2 = new System.Windows.Forms.MaskedTextBox();
            this.label44 = new System.Windows.Forms.Label();
            this.textBox_WenTimeAllow2 = new System.Windows.Forms.MaskedTextBox();
            this.label45 = new System.Windows.Forms.Label();
            this.textBox_WenTime2 = new System.Windows.Forms.MaskedTextBox();
            this.label46 = new System.Windows.Forms.Label();
            this.groupPanel10 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.textBox_WenLeaveTime1 = new System.Windows.Forms.MaskedTextBox();
            this.label47 = new System.Windows.Forms.Label();
            this.textBox_WenTimeAllow1 = new System.Windows.Forms.MaskedTextBox();
            this.label48 = new System.Windows.Forms.Label();
            this.textBox_WenTime1 = new System.Windows.Forms.MaskedTextBox();
            this.label49 = new System.Windows.Forms.Label();
            this.radioButton_WenBreakDay = new System.Windows.Forms.RadioButton();
            this.radioButton_WenPeriods2 = new System.Windows.Forms.RadioButton();
            this.radioButton_WenPeriods1 = new System.Windows.Forms.RadioButton();
            this.expandablePanel_Tuse = new DevComponents.DotNetBar.ExpandablePanel();
            this.itemPanel4 = new DevComponents.DotNetBar.ItemPanel();
            this.groupPanel7 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.textBox_TusLeaveTime2 = new System.Windows.Forms.MaskedTextBox();
            this.label35 = new System.Windows.Forms.Label();
            this.textBox_TusTimeAllow2 = new System.Windows.Forms.MaskedTextBox();
            this.label37 = new System.Windows.Forms.Label();
            this.textBox_TusTime2 = new System.Windows.Forms.MaskedTextBox();
            this.label39 = new System.Windows.Forms.Label();
            this.groupPanel8 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.textBox_TusLeaveTime1 = new System.Windows.Forms.MaskedTextBox();
            this.label41 = new System.Windows.Forms.Label();
            this.textBox_TusTimeAllow1 = new System.Windows.Forms.MaskedTextBox();
            this.label42 = new System.Windows.Forms.Label();
            this.textBox_TusTime1 = new System.Windows.Forms.MaskedTextBox();
            this.label43 = new System.Windows.Forms.Label();
            this.radioButton_TusBreakDay = new System.Windows.Forms.RadioButton();
            this.radioButton_TusPeriods2 = new System.Windows.Forms.RadioButton();
            this.radioButton_TusPeriods1 = new System.Windows.Forms.RadioButton();
            this.expandablePanel_Mon = new DevComponents.DotNetBar.ExpandablePanel();
            this.itemPanel3 = new DevComponents.DotNetBar.ItemPanel();
            this.groupPanel5 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.textBox_MonLeaveTime2 = new System.Windows.Forms.MaskedTextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.textBox_MonTimeAllow2 = new System.Windows.Forms.MaskedTextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.textBox_MonTime2 = new System.Windows.Forms.MaskedTextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.groupPanel6 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.textBox_MonLeaveTime1 = new System.Windows.Forms.MaskedTextBox();
            this.label32 = new System.Windows.Forms.Label();
            this.textBox_MonTimeAllow1 = new System.Windows.Forms.MaskedTextBox();
            this.label33 = new System.Windows.Forms.Label();
            this.textBox_MonTime1 = new System.Windows.Forms.MaskedTextBox();
            this.label34 = new System.Windows.Forms.Label();
            this.radioButton_MonBreakDay = new System.Windows.Forms.RadioButton();
            this.radioButton_MonPeriods2 = new System.Windows.Forms.RadioButton();
            this.radioButton_MonPeriods1 = new System.Windows.Forms.RadioButton();
            this.expandablePanel_Sun = new DevComponents.DotNetBar.ExpandablePanel();
            this.itemPanel2 = new DevComponents.DotNetBar.ItemPanel();
            this.groupPanel3 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.textBox_SunLeaveTime2 = new System.Windows.Forms.MaskedTextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.textBox_SunTimeAllow2 = new System.Windows.Forms.MaskedTextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.textBox_SunTime2 = new System.Windows.Forms.MaskedTextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.groupPanel4 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.textBox_SunLeaveTime1 = new System.Windows.Forms.MaskedTextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.textBox_SunTimeAllow1 = new System.Windows.Forms.MaskedTextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.textBox_SunTime1 = new System.Windows.Forms.MaskedTextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.radioButton_SunBreakDay = new System.Windows.Forms.RadioButton();
            this.radioButton_SunPeriods2 = new System.Windows.Forms.RadioButton();
            this.radioButton_SunPeriods1 = new System.Windows.Forms.RadioButton();
            this.expandablePanel_Sat = new DevComponents.DotNetBar.ExpandablePanel();
            this.itemPanel1 = new DevComponents.DotNetBar.ItemPanel();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.textBox_SatLeaveTime2 = new System.Windows.Forms.MaskedTextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.textBox_SatTimeAllow2 = new System.Windows.Forms.MaskedTextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.textBox_SatTime2 = new System.Windows.Forms.MaskedTextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.textBox_SatLeaveTime1 = new System.Windows.Forms.MaskedTextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.textBox_SatTimeAllow1 = new System.Windows.Forms.MaskedTextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.textBox_SatTime1 = new System.Windows.Forms.MaskedTextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.radioButton_SatBreakDay = new System.Windows.Forms.RadioButton();
            this.radioButton_SatPeriods2 = new System.Windows.Forms.RadioButton();
            this.radioButton_SatPeriods1 = new System.Windows.Forms.RadioButton();
            this.labelX19 = new DevComponents.DotNetBar.LabelX();
            this.superTabItem_Acc = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControlPanel17 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.panelEx4 = new DevComponents.DotNetBar.PanelEx();
            this.button_AddNewContract = new DevComponents.DotNetBar.ButtonX();
            this.comboBox_CalculateNo = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label11 = new System.Windows.Forms.Label();
            this.comboBox_ContrTyp = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.textBox_HousingAllowance = new DevComponents.Editors.DoubleInput();
            this.textBox_TransferAllowance = new DevComponents.Editors.DoubleInput();
            this.textBox_NaturalWorkAllowance = new DevComponents.Editors.DoubleInput();
            this.textBox_OtherAllowance = new DevComponents.Editors.DoubleInput();
            this.textBox_MainSal = new DevComponents.Editors.DoubleInput();
            this.label130 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.textBox_InsuranceMedicalCom = new DevComponents.Editors.DoubleInput();
            this.textBox_SocialInsuranceComp = new DevComponents.Editors.DoubleInput();
            this.label80 = new System.Windows.Forms.Label();
            this.label78 = new System.Windows.Forms.Label();
            this.label79 = new System.Windows.Forms.Label();
            this.label74 = new System.Windows.Forms.Label();
            this.label75 = new System.Windows.Forms.Label();
            this.label76 = new System.Windows.Forms.Label();
            this.label73 = new System.Windows.Forms.Label();
            this.label72 = new System.Windows.Forms.Label();
            this.label70 = new System.Windows.Forms.Label();
            this.textBox_SubsistenceAllowance = new DevComponents.Editors.DoubleInput();
            this.line1 = new DevComponents.DotNetBar.Controls.Line();
            this.comboBox_Allowances = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboBox_AllowancesTime = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dateTimeInput_LastFilter = new System.Windows.Forms.MaskedTextBox();
            this.dateTimeInput_DateAppointment = new System.Windows.Forms.MaskedTextBox();
            this.label56 = new System.Windows.Forms.Label();
            this.label53 = new System.Windows.Forms.Label();
            this.comboBox_DirBoss = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.button_AddNewBoss = new DevComponents.DotNetBar.ButtonX();
            this.button_SrchBoss = new DevComponents.DotNetBar.ButtonX();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox_DayOfMonth = new DevComponents.Editors.IntegerInput();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dateTimeInput_StartContr = new System.Windows.Forms.MaskedTextBox();
            this.label54 = new System.Windows.Forms.Label();
            this.dateTimeInput_EndContr = new System.Windows.Forms.MaskedTextBox();
            this.label55 = new System.Windows.Forms.Label();
            this.label137 = new System.Windows.Forms.Label();
            this.label140 = new System.Windows.Forms.Label();
            this.textBox_WorkHours = new DevComponents.Editors.DoubleInput();
            this.label60 = new System.Windows.Forms.Label();
            this.label59 = new System.Windows.Forms.Label();
            this.label57 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.switchButton_SalStatus = new DevComponents.DotNetBar.Controls.SwitchButton();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.textBox_SocialInsurance = new DevComponents.Editors.DoubleInput();
            this.textBox_InsuranceMedical = new DevComponents.Editors.DoubleInput();
            this.textBox_LateHours = new DevComponents.Editors.DoubleInput();
            this.textBox_DisOneDay = new DevComponents.Editors.DoubleInput();
            this.label86 = new System.Windows.Forms.Label();
            this.label84 = new System.Windows.Forms.Label();
            this.label82 = new System.Windows.Forms.Label();
            this.label83 = new System.Windows.Forms.Label();
            this.label85 = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.textBox_MandateDay = new DevComponents.Editors.DoubleInput();
            this.textBox_AddHours = new DevComponents.Editors.DoubleInput();
            this.textBox_AddDay = new DevComponents.Editors.DoubleInput();
            this.label89 = new System.Windows.Forms.Label();
            this.label90 = new System.Windows.Forms.Label();
            this.label91 = new System.Windows.Forms.Label();
            this.textBox_WorkNo = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.checkBox_AutoReturnContr = new System.Windows.Forms.CheckBox();
            this.labelX18 = new DevComponents.DotNetBar.LabelX();
            this.superTabItem_Contract = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControlPanel15 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button_SrchNation = new DevComponents.DotNetBar.ButtonX();
            this.button_SrchGuartor = new DevComponents.DotNetBar.ButtonX();
            this.button_SrchJob = new DevComponents.DotNetBar.ButtonX();
            this.button_SrchSection = new DevComponents.DotNetBar.ButtonX();
            this.button_SrchDept = new DevComponents.DotNetBar.ButtonX();
            this.pictureBox_EnterPic = new System.Windows.Forms.PictureBox();
            this.textBox_NameE = new System.Windows.Forms.TextBox();
            this.textBox_NameA = new System.Windows.Forms.TextBox();
            this.textBox_SocialInsuranceNo = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textBox_QualificationA = new System.Windows.Forms.TextBox();
            this.button_AddNewBirthPlaces = new DevComponents.DotNetBar.ButtonX();
            this.button_SrchBirthPlaces = new DevComponents.DotNetBar.ButtonX();
            this.textBox_ExperiencesA = new System.Windows.Forms.TextBox();
            this.label127 = new System.Windows.Forms.Label();
            this.comboBox_BloodTyp = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboBox_BirthPlace = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label133 = new System.Windows.Forms.Label();
            this.textBox_Email = new System.Windows.Forms.TextBox();
            this.label125 = new System.Windows.Forms.Label();
            this.textBox_Tel = new System.Windows.Forms.TextBox();
            this.label124 = new System.Windows.Forms.Label();
            this.comboBox_CityNo = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label9 = new System.Windows.Forms.Label();
            this.button_AddNewCity = new DevComponents.DotNetBar.ButtonX();
            this.button_SrchCities = new DevComponents.DotNetBar.ButtonX();
            this.textBox_AddressA = new System.Windows.Forms.TextBox();
            this.label126 = new System.Windows.Forms.Label();
            this.comboBox_Sex = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboBox_MaritalStatus = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboBox_Religion = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.dateTimeInput_BirthDate = new System.Windows.Forms.MaskedTextBox();
            this.label119 = new System.Windows.Forms.Label();
            this.label118 = new System.Windows.Forms.Label();
            this.label117 = new System.Windows.Forms.Label();
            this.label115 = new System.Windows.Forms.Label();
            this.label114 = new System.Windows.Forms.Label();
            this.label113 = new System.Windows.Forms.Label();
            this.button_AddNewReligon = new DevComponents.DotNetBar.ButtonX();
            this.button_SrchReligion = new DevComponents.DotNetBar.ButtonX();
            this.button_SrchReligon = new DevComponents.DotNetBar.ButtonX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.checkBox_ClearPic = new DevComponents.DotNetBar.ButtonX();
            this.button_Pic = new DevComponents.DotNetBar.ButtonX();
            this.comboBox_Nationalty = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.button_AddNewNation = new DevComponents.DotNetBar.ButtonX();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox_Guarantor = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.button_AddNewSponser = new DevComponents.DotNetBar.ButtonX();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox_Job = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.button_AddNewJob = new DevComponents.DotNetBar.ButtonX();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox_Section = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.button_AddNewSection = new DevComponents.DotNetBar.ButtonX();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox_Dept = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.button_AddNewDept = new DevComponents.DotNetBar.ButtonX();
            this.label12 = new System.Windows.Forms.Label();
            this.textBox_Pass = new System.Windows.Forms.TextBox();
            this.label52 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox_CompPaying = new DevComponents.Editors.DoubleInput();
            this.textBox_SalSubtract = new DevComponents.Editors.DoubleInput();
            this.textBox_ID = new System.Windows.Forms.TextBox();
            this.linkLabel_ChangeEmpNo = new System.Windows.Forms.LinkLabel();
            this.button_PhotoShoot = new DevComponents.DotNetBar.ButtonX();
            this.labelX15 = new DevComponents.DotNetBar.LabelX();
            this.superTabItem_Gen = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControlPanel1 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.panelEx8 = new DevComponents.DotNetBar.PanelEx();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.textBox_Insurance_Class = new System.Windows.Forms.TextBox();
            this.label121 = new System.Windows.Forms.Label();
            this.comboBox_InsuranceType = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.button_InsuranceType = new DevComponents.DotNetBar.ButtonX();
            this.bubbleButton_InsuranceType = new DevComponents.DotNetBar.ButtonX();
            this.label120 = new System.Windows.Forms.Label();
            this.button_SaveFamily = new DevComponents.DotNetBar.ButtonX();
            this.dateTimeInput_PassportDateEnd15 = new System.Windows.Forms.MaskedTextBox();
            this.dateTimeInput_PassportDateEnd14 = new System.Windows.Forms.MaskedTextBox();
            this.dateTimeInput_PassportDateEnd13 = new System.Windows.Forms.MaskedTextBox();
            this.dateTimeInput_PassportDateEnd12 = new System.Windows.Forms.MaskedTextBox();
            this.dateTimeInput_PassportDateEnd11 = new System.Windows.Forms.MaskedTextBox();
            this.dateTimeInput_PassportDateEnd10 = new System.Windows.Forms.MaskedTextBox();
            this.dateTimeInput_PassportDateEnd9 = new System.Windows.Forms.MaskedTextBox();
            this.dateTimeInput_PassportDateEnd8 = new System.Windows.Forms.MaskedTextBox();
            this.dateTimeInput_PassportDateEnd7 = new System.Windows.Forms.MaskedTextBox();
            this.dateTimeInput_PassportDateEnd6 = new System.Windows.Forms.MaskedTextBox();
            this.dateTimeInput_PassportDateEnd5 = new System.Windows.Forms.MaskedTextBox();
            this.dateTimeInput_PassportDateEnd4 = new System.Windows.Forms.MaskedTextBox();
            this.dateTimeInput_PassportDateEnd3 = new System.Windows.Forms.MaskedTextBox();
            this.dateTimeInput_PassportDateEnd2 = new System.Windows.Forms.MaskedTextBox();
            this.dateTimeInput_PassportDateEnd1 = new System.Windows.Forms.MaskedTextBox();
            this.dateTimeInput_BirthDate15 = new System.Windows.Forms.MaskedTextBox();
            this.dateTimeInput_BirthDate14 = new System.Windows.Forms.MaskedTextBox();
            this.dateTimeInput_BirthDate13 = new System.Windows.Forms.MaskedTextBox();
            this.dateTimeInput_BirthDate12 = new System.Windows.Forms.MaskedTextBox();
            this.dateTimeInput_BirthDate11 = new System.Windows.Forms.MaskedTextBox();
            this.dateTimeInput_BirthDate10 = new System.Windows.Forms.MaskedTextBox();
            this.dateTimeInput_BirthDate9 = new System.Windows.Forms.MaskedTextBox();
            this.dateTimeInput_BirthDate8 = new System.Windows.Forms.MaskedTextBox();
            this.dateTimeInput_BirthDate7 = new System.Windows.Forms.MaskedTextBox();
            this.dateTimeInput_BirthDate6 = new System.Windows.Forms.MaskedTextBox();
            this.dateTimeInput_BirthDate5 = new System.Windows.Forms.MaskedTextBox();
            this.dateTimeInput_BirthDate4 = new System.Windows.Forms.MaskedTextBox();
            this.dateTimeInput_BirthDate3 = new System.Windows.Forms.MaskedTextBox();
            this.dateTimeInput_BirthDate2 = new System.Windows.Forms.MaskedTextBox();
            this.dateTimeInput_BirthDate1 = new System.Windows.Forms.MaskedTextBox();
            this.label122 = new System.Windows.Forms.Label();
            this.label123 = new System.Windows.Forms.Label();
            this.label128 = new System.Windows.Forms.Label();
            this.label129 = new System.Windows.Forms.Label();
            this.textBox_PassporntNo15 = new System.Windows.Forms.TextBox();
            this.textBox_Relation15 = new System.Windows.Forms.TextBox();
            this.textBox_Name15 = new System.Windows.Forms.TextBox();
            this.textBox_PassporntNo14 = new System.Windows.Forms.TextBox();
            this.textBox_Relation14 = new System.Windows.Forms.TextBox();
            this.textBox_Name14 = new System.Windows.Forms.TextBox();
            this.textBox_PassporntNo13 = new System.Windows.Forms.TextBox();
            this.textBox_Relation13 = new System.Windows.Forms.TextBox();
            this.textBox_Name13 = new System.Windows.Forms.TextBox();
            this.textBox_PassporntNo12 = new System.Windows.Forms.TextBox();
            this.textBox_Relation12 = new System.Windows.Forms.TextBox();
            this.textBox_Name12 = new System.Windows.Forms.TextBox();
            this.textBox_PassporntNo11 = new System.Windows.Forms.TextBox();
            this.textBox_Relation11 = new System.Windows.Forms.TextBox();
            this.textBox_Name11 = new System.Windows.Forms.TextBox();
            this.textBox_PassporntNo10 = new System.Windows.Forms.TextBox();
            this.textBox_Relation10 = new System.Windows.Forms.TextBox();
            this.textBox_Name10 = new System.Windows.Forms.TextBox();
            this.textBox_PassporntNo9 = new System.Windows.Forms.TextBox();
            this.textBox_Relation9 = new System.Windows.Forms.TextBox();
            this.textBox_Name9 = new System.Windows.Forms.TextBox();
            this.textBox_PassporntNo8 = new System.Windows.Forms.TextBox();
            this.textBox_Relation8 = new System.Windows.Forms.TextBox();
            this.textBox_Name8 = new System.Windows.Forms.TextBox();
            this.textBox_PassporntNo7 = new System.Windows.Forms.TextBox();
            this.textBox_Relation7 = new System.Windows.Forms.TextBox();
            this.textBox_Name7 = new System.Windows.Forms.TextBox();
            this.textBox_PassporntNo6 = new System.Windows.Forms.TextBox();
            this.textBox_Relation6 = new System.Windows.Forms.TextBox();
            this.textBox_Name6 = new System.Windows.Forms.TextBox();
            this.textBox_PassporntNo5 = new System.Windows.Forms.TextBox();
            this.textBox_Relation5 = new System.Windows.Forms.TextBox();
            this.textBox_Name5 = new System.Windows.Forms.TextBox();
            this.textBox_PassporntNo4 = new System.Windows.Forms.TextBox();
            this.textBox_Relation4 = new System.Windows.Forms.TextBox();
            this.textBox_Name4 = new System.Windows.Forms.TextBox();
            this.textBox_PassporntNo3 = new System.Windows.Forms.TextBox();
            this.textBox_Relation3 = new System.Windows.Forms.TextBox();
            this.textBox_Name3 = new System.Windows.Forms.TextBox();
            this.textBox_PassporntNo2 = new System.Windows.Forms.TextBox();
            this.textBox_Relation2 = new System.Windows.Forms.TextBox();
            this.textBox_Name2 = new System.Windows.Forms.TextBox();
            this.textBox_PassporntNo1 = new System.Windows.Forms.TextBox();
            this.textBox_Relation1 = new System.Windows.Forms.TextBox();
            this.textBox_Name1 = new System.Windows.Forms.TextBox();
            this.label132 = new System.Windows.Forms.Label();
            this.textBox_Note = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.superTabItem_Family = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControlPanel19 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.panelEx6 = new DevComponents.DotNetBar.PanelEx();
            this.line2 = new DevComponents.DotNetBar.Controls.Line();
            this.groupBox14 = new System.Windows.Forms.GroupBox();
            this.dateTimeInput_VisaDate = new System.Windows.Forms.MaskedTextBox();
            this.textBox_VisaCountry = new System.Windows.Forms.TextBox();
            this.label136 = new System.Windows.Forms.Label();
            this.label135 = new System.Windows.Forms.Label();
            this.textBox_VisaEnterNo = new System.Windows.Forms.TextBox();
            this.label134 = new System.Windows.Forms.Label();
            this.textBox_VisaNo = new System.Windows.Forms.TextBox();
            this.label131 = new System.Windows.Forms.Label();
            this.comboBox_License_From = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.button_SrchLicense = new DevComponents.DotNetBar.ButtonX();
            this.line6 = new DevComponents.DotNetBar.Controls.Line();
            this.bubbleBar5 = new DevComponents.DotNetBar.BubbleBar();
            this.bubbleBarTab11 = new DevComponents.DotNetBar.BubbleBarTab(this.components);
            this.bubbleButton5 = new DevComponents.DotNetBar.BubbleButton();
            this.dateTimeInput_License_Date = new System.Windows.Forms.MaskedTextBox();
            this.dateTimeInput_License_DateEnd = new System.Windows.Forms.MaskedTextBox();
            this.textBox_License_No = new System.Windows.Forms.TextBox();
            this.label109 = new System.Windows.Forms.Label();
            this.label110 = new System.Windows.Forms.Label();
            this.label111 = new System.Windows.Forms.Label();
            this.label112 = new System.Windows.Forms.Label();
            this.comboBox_Form_From = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.button_SrchForms = new DevComponents.DotNetBar.ButtonX();
            this.line5 = new DevComponents.DotNetBar.Controls.Line();
            this.dateTimeInput_Form_Date = new System.Windows.Forms.MaskedTextBox();
            this.dateTimeInput_Form_DateEnd = new System.Windows.Forms.MaskedTextBox();
            this.textBox_Form_No = new System.Windows.Forms.TextBox();
            this.label105 = new System.Windows.Forms.Label();
            this.label106 = new System.Windows.Forms.Label();
            this.label107 = new System.Windows.Forms.Label();
            this.label108 = new System.Windows.Forms.Label();
            this.comboBox_Insurance_From = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.button_SrchInsurance = new DevComponents.DotNetBar.ButtonX();
            this.line4 = new DevComponents.DotNetBar.Controls.Line();
            this.dateTimeInput_Insurance_Date = new System.Windows.Forms.MaskedTextBox();
            this.dateTimeInput_Insurance_DateEnd = new System.Windows.Forms.MaskedTextBox();
            this.textBox_Insurance_No = new System.Windows.Forms.TextBox();
            this.label101 = new System.Windows.Forms.Label();
            this.label102 = new System.Windows.Forms.Label();
            this.label103 = new System.Windows.Forms.Label();
            this.label104 = new System.Windows.Forms.Label();
            this.comboBox_Passport_From = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.button_SrchPassport = new DevComponents.DotNetBar.ButtonX();
            this.dateTimeInput_Pass_Date = new System.Windows.Forms.MaskedTextBox();
            this.dateTimeInput_Passport_DateEnd = new System.Windows.Forms.MaskedTextBox();
            this.textBox_Passport_No = new System.Windows.Forms.TextBox();
            this.label96 = new System.Windows.Forms.Label();
            this.label98 = new System.Windows.Forms.Label();
            this.label99 = new System.Windows.Forms.Label();
            this.label100 = new System.Windows.Forms.Label();
            this.line3 = new DevComponents.DotNetBar.Controls.Line();
            this.comboBox_ID_From = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.button_SrchID = new DevComponents.DotNetBar.ButtonX();
            this.dateTimeInput_ID_Date = new System.Windows.Forms.MaskedTextBox();
            this.dateTimeInput_ID_DateEnd = new System.Windows.Forms.MaskedTextBox();
            this.textBox_ID_No = new System.Windows.Forms.TextBox();
            this.label88 = new System.Windows.Forms.Label();
            this.label97 = new System.Windows.Forms.Label();
            this.label95 = new System.Windows.Forms.Label();
            this.label92 = new System.Windows.Forms.Label();
            this.labelX20 = new DevComponents.DotNetBar.LabelX();
            this.superTabItem_Doc = new DevComponents.DotNetBar.SuperTabItem();
            this.buttonX_OpenFiles = new DevComponents.DotNetBar.ButtonItem();
            this.buttonX_BrowserScannerFiles = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem_EmpOut = new DevComponents.DotNetBar.ButtonItem();
            this.ribbonBar_Tasks = new DevComponents.DotNetBar.RibbonBar();
            this.superTabControl_Main1 = new DevComponents.DotNetBar.SuperTabControl();
            this.Button_Close = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem_Back = new DevComponents.DotNetBar.ButtonItem();
            this.Button_Search = new DevComponents.DotNetBar.ButtonItem();
            this.Button_Delete = new DevComponents.DotNetBar.ButtonItem();
            this.Button_Save = new DevComponents.DotNetBar.ButtonItem();
            this.Button_Add = new DevComponents.DotNetBar.ButtonItem();
            this.labelItem2 = new DevComponents.DotNetBar.LabelItem();
            this.superTabControl_Main2 = new DevComponents.DotNetBar.SuperTabControl();
            this.labelItem1 = new DevComponents.DotNetBar.LabelItem();
            this.Button_First = new DevComponents.DotNetBar.ButtonItem();
            this.Button_Prev = new DevComponents.DotNetBar.ButtonItem();
            this.TextBox_Index = new DevComponents.DotNetBar.TextBoxItem();
            this.Label_Count = new DevComponents.DotNetBar.LabelItem();
            this.lable_Records = new DevComponents.DotNetBar.LabelItem();
            this.Button_Next = new DevComponents.DotNetBar.ButtonItem();
            this.Button_Last = new DevComponents.DotNetBar.ButtonItem();
            this.expandableSplitter1 = new DevComponents.DotNetBar.ExpandableSplitter();
            this.panelEx3 = new DevComponents.DotNetBar.PanelEx();
            this.DGV_Main = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            this.ribbonBar_DGV = new DevComponents.DotNetBar.RibbonBar();
            this.superTabControl_DGV = new DevComponents.DotNetBar.SuperTabControl();
            this.textBox_search = new DevComponents.DotNetBar.TextBoxItem();
            this.Button_ExportTable2 = new DevComponents.DotNetBar.ButtonItem();
            this.Button_PrintTable = new DevComponents.DotNetBar.ButtonItem();
            this.labelItem3 = new DevComponents.DotNetBar.LabelItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.listBox_ImageFiles = new System.Windows.Forms.ListBox();
            this.listBox_ImageFiles2 = new System.Windows.Forms.ListBox();
            this.netResize1 = new Softgroup.NetResize.NetResize(this.components);
            this.netResize1.AfterControlResize += new Softgroup.NetResize.NetResize.AfterControlResizeEventHandler(this.netResize1_AfterControlResize);
            this.Shown += new System.EventHandler(this.FrmInvSale_Shown);
            this.SizeChanged += new System.EventHandler(this.FrmInvSale_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).BeginInit();
            this.contextMenuStrip2.SuspendLayout();
            this.panelEx2.SuspendLayout();
            this.ribbonBar1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl_Employee)).BeginInit();
            this.superTabControl_Employee.SuspendLayout();
            this.superTabControlPanel18.SuspendLayout();
            this.panelEx5.SuspendLayout();
            this.groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_TicketsCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_TicketsBalance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_TicketsPrice)).BeginInit();
            this.groupBox10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_VacationBalance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_VacationCount)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupPanel15.SuspendLayout();
            this.expandablePanel_attends.SuspendLayout();
            this.expandablePanel_Fri.SuspendLayout();
            this.itemPanel7.SuspendLayout();
            this.groupPanel11.SuspendLayout();
            this.groupPanel12.SuspendLayout();
            this.expandablePanel_Thurs.SuspendLayout();
            this.itemPanel6.SuspendLayout();
            this.groupPanel13.SuspendLayout();
            this.groupPanel14.SuspendLayout();
            this.expandablePanel_Wen.SuspendLayout();
            this.itemPanel5.SuspendLayout();
            this.groupPanel9.SuspendLayout();
            this.groupPanel10.SuspendLayout();
            this.expandablePanel_Tuse.SuspendLayout();
            this.itemPanel4.SuspendLayout();
            this.groupPanel7.SuspendLayout();
            this.groupPanel8.SuspendLayout();
            this.expandablePanel_Mon.SuspendLayout();
            this.itemPanel3.SuspendLayout();
            this.groupPanel5.SuspendLayout();
            this.groupPanel6.SuspendLayout();
            this.expandablePanel_Sun.SuspendLayout();
            this.itemPanel2.SuspendLayout();
            this.groupPanel3.SuspendLayout();
            this.groupPanel4.SuspendLayout();
            this.expandablePanel_Sat.SuspendLayout();
            this.itemPanel1.SuspendLayout();
            this.groupPanel2.SuspendLayout();
            this.groupPanel1.SuspendLayout();
            this.superTabControlPanel17.SuspendLayout();
            this.panelEx4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_HousingAllowance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_TransferAllowance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_NaturalWorkAllowance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_OtherAllowance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_MainSal)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_InsuranceMedicalCom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_SocialInsuranceComp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_SubsistenceAllowance)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_DayOfMonth)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_WorkHours)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_SocialInsurance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_InsuranceMedical)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_LateHours)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_DisOneDay)).BeginInit();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_MandateDay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_AddHours)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_AddDay)).BeginInit();
            this.superTabControlPanel15.SuspendLayout();
            this.panelEx1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_EnterPic)).BeginInit();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_CompPaying)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_SalSubtract)).BeginInit();
            this.superTabControlPanel1.SuspendLayout();
            this.panelEx8.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.superTabControlPanel19.SuspendLayout();
            this.panelEx6.SuspendLayout();
            this.groupBox14.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bubbleBar5)).BeginInit();
            this.ribbonBar_Tasks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl_Main1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl_Main2)).BeginInit();
            this.panelEx3.SuspendLayout();
            this.ribbonBar_DGV.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl_DGV)).BeginInit();
            this.panel1.SuspendLayout();
            this.PanelSpecialContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelSpecialContainer.Location = new System.Drawing.Point(0, 0);
            this.PanelSpecialContainer.Name = "PanelSpecialContainer";
            this.PanelSpecialContainer.Size = new System.Drawing.Size(1278, 514);
            this.PanelSpecialContainer.TabIndex = 1220;
            this.Controls.Add(this.PanelSpecialContainer);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "*.rtf";
            this.saveFileDialog1.FileName = "doc1";
            this.saveFileDialog1.Filter = "Text Files (*.txt)|*.txt|RTF Files (*.rtf)|*.rtf|All Files(*.*)|*.*";
            this.saveFileDialog1.FilterIndex = 2;
            this.saveFileDialog1.Title = "Save File";
            // 
            // timerInfoBallon
            // 
            this.timerInfoBallon.Interval = 3000;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "*.rtf";
            this.openFileDialog1.Filter = "Text Files (*.txt)|*.txt|RTF Files (*.rtf)|*.rtf|All Files(*.*)|*.*";
            this.openFileDialog1.FilterIndex = 2;
            this.openFileDialog1.Title = "Open File";
            // 
            // barTopDockSite
            // 
            this.barTopDockSite.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.barTopDockSite.Dock = System.Windows.Forms.DockStyle.Top;
            this.barTopDockSite.DocumentDockContainer = new DevComponents.DotNetBar.DocumentDockContainer();
            this.barTopDockSite.Location = new System.Drawing.Point(0, 0);
            this.barTopDockSite.Name = "barTopDockSite";
            this.barTopDockSite.Size = new System.Drawing.Size(677, 0);
            this.barTopDockSite.TabIndex = 889;
            this.barTopDockSite.TabStop = false;
            // 
            // barBottomDockSite
            // 
            this.barBottomDockSite.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.barBottomDockSite.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barBottomDockSite.DocumentDockContainer = new DevComponents.DotNetBar.DocumentDockContainer();
            this.barBottomDockSite.Location = new System.Drawing.Point(0, 500);
            this.barBottomDockSite.Name = "barBottomDockSite";
            this.barBottomDockSite.Size = new System.Drawing.Size(677, 0);
            this.barBottomDockSite.TabIndex = 890;
            this.barBottomDockSite.TabStop = false;
            // 
            // dotNetBarManager1
            // 
            this.dotNetBarManager1.BottomDockSite = this.barBottomDockSite;
            this.dotNetBarManager1.Images = this.imageList1;
            this.dotNetBarManager1.LeftDockSite = this.barLeftDockSite;
            this.dotNetBarManager1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.dotNetBarManager1.MdiSystemItemVisible = false;
            this.dotNetBarManager1.ParentForm = null;
            this.dotNetBarManager1.RightDockSite = this.barRightDockSite;
            this.dotNetBarManager1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2000;
            this.dotNetBarManager1.ToolbarBottomDockSite = this.dockSite4;
            this.dotNetBarManager1.ToolbarLeftDockSite = this.dockSite1;
            this.dotNetBarManager1.ToolbarRightDockSite = this.dockSite2;
            this.dotNetBarManager1.ToolbarTopDockSite = this.dockSite3;
            this.dotNetBarManager1.TopDockSite = this.barTopDockSite;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Magenta;
            this.imageList1.Images.SetKeyName(0, string.Empty);
            this.imageList1.Images.SetKeyName(1, string.Empty);
            this.imageList1.Images.SetKeyName(2, string.Empty);
            this.imageList1.Images.SetKeyName(3, string.Empty);
            this.imageList1.Images.SetKeyName(4, string.Empty);
            this.imageList1.Images.SetKeyName(5, string.Empty);
            this.imageList1.Images.SetKeyName(6, string.Empty);
            this.imageList1.Images.SetKeyName(7, string.Empty);
            this.imageList1.Images.SetKeyName(8, string.Empty);
            this.imageList1.Images.SetKeyName(9, string.Empty);
            this.imageList1.Images.SetKeyName(10, string.Empty);
            this.imageList1.Images.SetKeyName(11, string.Empty);
            this.imageList1.Images.SetKeyName(12, string.Empty);
            this.imageList1.Images.SetKeyName(13, string.Empty);
            this.imageList1.Images.SetKeyName(14, string.Empty);
            this.imageList1.Images.SetKeyName(15, string.Empty);
            this.imageList1.Images.SetKeyName(16, string.Empty);
            this.imageList1.Images.SetKeyName(17, string.Empty);
            this.imageList1.Images.SetKeyName(18, string.Empty);
            this.imageList1.Images.SetKeyName(19, string.Empty);
            this.imageList1.Images.SetKeyName(20, string.Empty);
            this.imageList1.Images.SetKeyName(21, string.Empty);
            this.imageList1.Images.SetKeyName(22, string.Empty);
            this.imageList1.Images.SetKeyName(23, string.Empty);
            // 
            // barLeftDockSite
            // 
            this.barLeftDockSite.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.barLeftDockSite.Dock = System.Windows.Forms.DockStyle.Left;
            this.barLeftDockSite.DocumentDockContainer = new DevComponents.DotNetBar.DocumentDockContainer();
            this.barLeftDockSite.Location = new System.Drawing.Point(0, 0);
            this.barLeftDockSite.Name = "barLeftDockSite";
            this.barLeftDockSite.Size = new System.Drawing.Size(0, 500);
            this.barLeftDockSite.TabIndex = 891;
            this.barLeftDockSite.TabStop = false;
            // 
            // barRightDockSite
            // 
            this.barRightDockSite.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.barRightDockSite.Dock = System.Windows.Forms.DockStyle.Right;
            this.barRightDockSite.DocumentDockContainer = new DevComponents.DotNetBar.DocumentDockContainer();
            this.barRightDockSite.Location = new System.Drawing.Point(677, 0);
            this.barRightDockSite.Name = "barRightDockSite";
            this.barRightDockSite.Size = new System.Drawing.Size(0, 500);
            this.barRightDockSite.TabIndex = 892;
            this.barRightDockSite.TabStop = false;
            // 
            // dockSite4
            // 
            this.dockSite4.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dockSite4.Location = new System.Drawing.Point(0, 500);
            this.dockSite4.Name = "dockSite4";
            this.dockSite4.Size = new System.Drawing.Size(677, 0);
            this.dockSite4.TabIndex = 896;
            this.dockSite4.TabStop = false;
            // 
            // dockSite1
            // 
            this.dockSite1.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite1.Dock = System.Windows.Forms.DockStyle.Left;
            this.dockSite1.Location = new System.Drawing.Point(0, 0);
            this.dockSite1.Name = "dockSite1";
            this.dockSite1.Size = new System.Drawing.Size(0, 500);
            this.dockSite1.TabIndex = 893;
            this.dockSite1.TabStop = false;
            // 
            // dockSite2
            // 
            this.dockSite2.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite2.Dock = System.Windows.Forms.DockStyle.Right;
            this.dockSite2.Location = new System.Drawing.Point(677, 0);
            this.dockSite2.Name = "dockSite2";
            this.dockSite2.Size = new System.Drawing.Size(0, 500);
            this.dockSite2.TabIndex = 894;
            this.dockSite2.TabStop = false;
            // 
            // dockSite3
            // 
            this.dockSite3.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite3.Dock = System.Windows.Forms.DockStyle.Top;
            this.dockSite3.Location = new System.Drawing.Point(0, 0);
            this.dockSite3.Name = "dockSite3";
            this.dockSite3.Size = new System.Drawing.Size(677, 0);
            this.dockSite3.TabIndex = 895;
            this.dockSite3.TabStop = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // ToolStripMenuItem_Rep
            // 
            this.ToolStripMenuItem_Rep.Checked = true;
            this.ToolStripMenuItem_Rep.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ToolStripMenuItem_Rep.Name = "ToolStripMenuItem_Rep";
            this.ToolStripMenuItem_Rep.Size = new System.Drawing.Size(148, 22);
            this.ToolStripMenuItem_Rep.Text = "إظهار التقرير";
            // 
            // ToolStripMenuItem_Det
            // 
            this.ToolStripMenuItem_Det.Name = "ToolStripMenuItem_Det";
            this.ToolStripMenuItem_Det.Size = new System.Drawing.Size(148, 22);
            this.ToolStripMenuItem_Det.Text = "إظهار التفاصيل";
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_Det,
            this.ToolStripMenuItem_Rep});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.contextMenuStrip2.Size = new System.Drawing.Size(149, 48);
            // 
            // panelEx2
            // 
            this.PanelSpecialContainer.Controls.Add(this.ribbonBar1);
            this.ribbonBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelSpecialContainer.Controls.Add(this.ribbonBar_Tasks);
            this.superTabControl_Main1.RightToLeftChanged += new System.EventHandler(this.superTabControl_Main1_RightToLeftChanged);
            this.panelEx2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelEx2.Location = new System.Drawing.Point(0, 13);
            this.panelEx2.MinimumSize = new System.Drawing.Size(677, 487);
            this.panelEx2.Name = "panelEx2";
            this.panelEx2.Size = new System.Drawing.Size(677, 487);
            this.panelEx2.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx2.Style.BackColor1.Color = System.Drawing.Color.AliceBlue;
            this.panelEx2.Style.BackColor2.Color = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panelEx2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx2.Style.GradientAngle = 90;
            this.panelEx2.TabIndex = 0;
            this.panelEx2.Text = "Click to collapse";
            // 
            // ribbonBar1
            // 
            this.ribbonBar1.AutoOverflowEnabled = true;
            // 
            // 
            // 
            this.ribbonBar1.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar1.BackgroundStyle.BackColor = System.Drawing.Color.Silver;
            this.ribbonBar1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar1.ContainerControlProcessDialogKey = true;
            this.ribbonBar1.Controls.Add(this.superTabControl_Employee);
            this.ribbonBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonBar1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.ribbonBar1.Location = new System.Drawing.Point(0, 0);
            this.ribbonBar1.Name = "ribbonBar1";
            this.ribbonBar1.Size = new System.Drawing.Size(677, 436);
            this.ribbonBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this.ribbonBar1.TabIndex = 867;
            // 
            // 
            // 
            this.ribbonBar1.TitleStyle.BackColor = System.Drawing.Color.Black;
            this.ribbonBar1.TitleStyle.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.ribbonBar1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar1.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // superTabControl_Employee
            // 
            this.superTabControl_Employee.CloseButtonOnTabsAlwaysDisplayed = false;
            this.superTabControl_Employee.CloseButtonOnTabsVisible = true;
            this.superTabControl_Employee.CloseButtonPosition = DevComponents.DotNetBar.eTabCloseButtonPosition.Left;
            // 
            // 
            // 
            // 
            // 
            // 
            this.superTabControl_Employee.ControlBox.CloseBox.Name = string.Empty;
            // 
            // 
            // 
            this.superTabControl_Employee.ControlBox.MenuBox.Name = string.Empty;
            this.superTabControl_Employee.ControlBox.Name = string.Empty;
            this.superTabControl_Employee.ControlBox.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.superTabControl_Employee.ControlBox.MenuBox,
            this.superTabControl_Employee.ControlBox.CloseBox});
            this.superTabControl_Employee.ControlBox.Visible = false;
            this.superTabControl_Employee.Controls.Add(this.superTabControlPanel15);
            this.superTabControl_Employee.Controls.Add(this.superTabControlPanel18);
            this.superTabControl_Employee.Controls.Add(this.superTabControlPanel17);
            this.superTabControl_Employee.Controls.Add(this.superTabControlPanel1);
            this.superTabControl_Employee.Controls.Add(this.superTabControlPanel19);
            this.superTabControl_Employee.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControl_Employee.Location = new System.Drawing.Point(0, 0);
            this.superTabControl_Employee.Name = "superTabControl_Employee";
            this.superTabControl_Employee.ReorderTabsEnabled = true;
            this.superTabControl_Employee.SelectedTabFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.superTabControl_Employee.SelectedTabIndex = 0;
            this.superTabControl_Employee.Size = new System.Drawing.Size(677, 419);
            this.superTabControl_Employee.TabAlignment = DevComponents.DotNetBar.eTabStripAlignment.Right;
            this.superTabControl_Employee.TabFont = new System.Drawing.Font("Segoe UI", 9F);
            this.superTabControl_Employee.TabIndex = 4;
            this.superTabControl_Employee.TabLayoutType = DevComponents.DotNetBar.eSuperTabLayoutType.SingleLineFit;
            this.superTabControl_Employee.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.superTabItem_Gen,
            this.superTabItem_Contract,
            this.superTabItem_Acc,
            this.superTabItem_Doc,
            this.superTabItem_Family,
            this.buttonX_OpenFiles,
            this.buttonX_BrowserScannerFiles,
            this.buttonItem_EmpOut});
            superTabLinearGradientColorTable1.Colors = new System.Drawing.Color[] {
        System.Drawing.SystemColors.GradientInactiveCaption};
            superTabColorTable1.Background = superTabLinearGradientColorTable1;
            this.superTabControl_Employee.TabStripColor = superTabColorTable1;
            this.superTabControl_Employee.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.OneNote2007;
            this.superTabControl_Employee.TabVerticalSpacing = 2;
            this.superTabControl_Employee.TextAlignment = DevComponents.DotNetBar.eItemAlignment.Center;
            // 
            // superTabControlPanel18
            // 
            this.superTabControlPanel18.Controls.Add(this.panelEx5);
            this.superTabControlPanel18.Controls.Add(this.labelX19);
            this.superTabControlPanel18.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel18.Location = new System.Drawing.Point(0, 0);
            this.superTabControlPanel18.Name = "superTabControlPanel18";
            this.superTabControlPanel18.Size = new System.Drawing.Size(594, 419);
            this.superTabControlPanel18.TabIndex = 0;
            this.superTabControlPanel18.TabItem = this.superTabItem_Acc;
            // 
            // panelEx5
            // 
            this.panelEx5.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx5.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx5.Controls.Add(this.groupBox8);
            this.panelEx5.Controls.Add(this.groupBox10);
            this.panelEx5.Controls.Add(this.groupBox3);
            this.panelEx5.Controls.Add(this.expandablePanel_attends);
            this.panelEx5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx5.Location = new System.Drawing.Point(0, 0);
            this.panelEx5.Name = "panelEx5";
            this.panelEx5.Size = new System.Drawing.Size(594, 419);
            this.panelEx5.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx5.Style.BackColor1.Color = System.Drawing.Color.AliceBlue;
            this.panelEx5.Style.BackColor2.Color = System.Drawing.SystemColors.GradientActiveCaption;
            this.panelEx5.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx5.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx5.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx5.Style.GradientAngle = 90;
            this.panelEx5.TabIndex = 10;
            // 
            // groupBox8
            // 
            this.groupBox8.BackColor = System.Drawing.Color.Transparent;
            this.groupBox8.Controls.Add(this.textBox_TicketsCount);
            this.groupBox8.Controls.Add(this.textBox_TicketsBalance);
            this.groupBox8.Controls.Add(this.textBox_TicketsPrice);
            this.groupBox8.Controls.Add(this.label68);
            this.groupBox8.Controls.Add(this.label65);
            this.groupBox8.Controls.Add(this.label67);
            this.groupBox8.Location = new System.Drawing.Point(408, 232);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(181, 187);
            this.groupBox8.TabIndex = 6776;
            this.groupBox8.TabStop = false;
            this.groupBox8.Tag = string.Empty;
            this.groupBox8.Text = "التذاكـــر";
            // 
            // textBox_TicketsCount
            // 
            this.textBox_TicketsCount.AllowEmptyState = false;
            this.textBox_TicketsCount.AutoOffFreeTextEntry = true;
            this.textBox_TicketsCount.AutoResolveFreeTextEntries = false;
            // 
            // 
            // 
            this.textBox_TicketsCount.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.textBox_TicketsCount.BackgroundStyle.BorderBottomWidth = 1;
            this.textBox_TicketsCount.BackgroundStyle.Class = "DateTimeInputBackground";
            this.textBox_TicketsCount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBox_TicketsCount.BackgroundStyle.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_TicketsCount.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.textBox_TicketsCount.DisplayFormat = "0.00";
            this.textBox_TicketsCount.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.textBox_TicketsCount.Increment = 1D;
            this.textBox_TicketsCount.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.textBox_TicketsCount.Location = new System.Drawing.Point(25, 38);
            this.textBox_TicketsCount.MinValue = 0D;
            this.textBox_TicketsCount.Name = "textBox_TicketsCount";
            this.textBox_TicketsCount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox_TicketsCount.Size = new System.Drawing.Size(73, 21);
            this.textBox_TicketsCount.TabIndex = 115;
            // 
            // textBox_TicketsBalance
            // 
            this.textBox_TicketsBalance.AllowEmptyState = false;
            // 
            // 
            // 
            this.textBox_TicketsBalance.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(198)))));
            this.textBox_TicketsBalance.BackgroundStyle.Class = "DateTimeInputBackground";
            this.textBox_TicketsBalance.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBox_TicketsBalance.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.textBox_TicketsBalance.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.textBox_TicketsBalance.Increment = 1D;
            this.textBox_TicketsBalance.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.textBox_TicketsBalance.IsInputReadOnly = true;
            this.textBox_TicketsBalance.Location = new System.Drawing.Point(25, 130);
            this.textBox_TicketsBalance.Name = "textBox_TicketsBalance";
            this.textBox_TicketsBalance.Size = new System.Drawing.Size(73, 20);
            this.textBox_TicketsBalance.TabIndex = 120;
            // 
            // textBox_TicketsPrice
            // 
            this.textBox_TicketsPrice.AllowEmptyState = false;
            // 
            // 
            // 
            this.textBox_TicketsPrice.BackgroundStyle.Class = "DateTimeInputBackground";
            this.textBox_TicketsPrice.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBox_TicketsPrice.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.textBox_TicketsPrice.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.textBox_TicketsPrice.Increment = 1D;
            this.textBox_TicketsPrice.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.textBox_TicketsPrice.Location = new System.Drawing.Point(25, 84);
            this.textBox_TicketsPrice.MinValue = 0D;
            this.textBox_TicketsPrice.Name = "textBox_TicketsPrice";
            this.textBox_TicketsPrice.Size = new System.Drawing.Size(73, 20);
            this.textBox_TicketsPrice.TabIndex = 116;
            // 
            // label68
            // 
            this.label68.AutoSize = true;
            this.label68.BackColor = System.Drawing.Color.Transparent;
            this.label68.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label68.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label68.Location = new System.Drawing.Point(100, 131);
            this.label68.Name = "label68";
            this.label68.Size = new System.Drawing.Size(69, 13);
            this.label68.TabIndex = 121;
            this.label68.Text = "رصيد التذاكر :";
            // 
            // label65
            // 
            this.label65.AutoSize = true;
            this.label65.BackColor = System.Drawing.Color.Transparent;
            this.label65.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label65.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label65.Location = new System.Drawing.Point(100, 85);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(70, 13);
            this.label65.TabIndex = 119;
            this.label65.Text = "سعر التذكرة :";
            // 
            // label67
            // 
            this.label67.AutoSize = true;
            this.label67.BackColor = System.Drawing.Color.Transparent;
            this.label67.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label67.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label67.Location = new System.Drawing.Point(100, 39);
            this.label67.Name = "label67";
            this.label67.Size = new System.Drawing.Size(67, 13);
            this.label67.TabIndex = 117;
            this.label67.Text = "تذاكر السنة :";
            // 
            // groupBox10
            // 
            this.groupBox10.BackColor = System.Drawing.Color.Transparent;
            this.groupBox10.Controls.Add(this.textBox_VacationBalance);
            this.groupBox10.Controls.Add(this.textBox_VacationCount);
            this.groupBox10.Controls.Add(this.label64);
            this.groupBox10.Controls.Add(this.label62);
            this.groupBox10.Controls.Add(this.label63);
            this.groupBox10.Location = new System.Drawing.Point(222, 232);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(183, 187);
            this.groupBox10.TabIndex = 6777;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "الإجازات";
            // 
            // textBox_VacationBalance
            // 
            this.textBox_VacationBalance.AllowEmptyState = false;
            // 
            // 
            // 
            this.textBox_VacationBalance.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(198)))));
            this.textBox_VacationBalance.BackgroundStyle.Class = "DateTimeInputBackground";
            this.textBox_VacationBalance.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBox_VacationBalance.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.textBox_VacationBalance.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.textBox_VacationBalance.Increment = 1D;
            this.textBox_VacationBalance.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.textBox_VacationBalance.IsInputReadOnly = true;
            this.textBox_VacationBalance.Location = new System.Drawing.Point(36, 96);
            this.textBox_VacationBalance.Name = "textBox_VacationBalance";
            this.textBox_VacationBalance.Size = new System.Drawing.Size(53, 20);
            this.textBox_VacationBalance.TabIndex = 109;
            // 
            // textBox_VacationCount
            // 
            this.textBox_VacationCount.AllowEmptyState = false;
            // 
            // 
            // 
            this.textBox_VacationCount.BackgroundStyle.Class = "DateTimeInputBackground";
            this.textBox_VacationCount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBox_VacationCount.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.textBox_VacationCount.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.textBox_VacationCount.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.textBox_VacationCount.Location = new System.Drawing.Point(36, 50);
            this.textBox_VacationCount.MinValue = 0;
            this.textBox_VacationCount.Name = "textBox_VacationCount";
            this.textBox_VacationCount.Size = new System.Drawing.Size(53, 20);
            this.textBox_VacationCount.TabIndex = 104;
            // 
            // label64
            // 
            this.label64.AutoSize = true;
            this.label64.BackColor = System.Drawing.Color.Transparent;
            this.label64.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label64.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label64.Location = new System.Drawing.Point(91, 100);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(85, 13);
            this.label64.TabIndex = 105;
            this.label64.Text = "رصيد الإجـــازات :";
            // 
            // label62
            // 
            this.label62.AutoSize = true;
            this.label62.BackColor = System.Drawing.Color.Transparent;
            this.label62.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label62.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label62.Location = new System.Drawing.Point(11, 54);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(22, 13);
            this.label62.TabIndex = 106;
            this.label62.Text = "يوم";
            // 
            // label63
            // 
            this.label63.AutoSize = true;
            this.label63.BackColor = System.Drawing.Color.Transparent;
            this.label63.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label63.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label63.Location = new System.Drawing.Point(91, 54);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(82, 13);
            this.label63.TabIndex = 105;
            this.label63.Text = "الاجازة السنوية :";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.groupPanel15);
            this.groupBox3.Controls.Add(this.switchButton_AccType);
            this.groupBox3.Controls.Add(this.txtBXBankName);
            this.groupBox3.Controls.Add(this.button_SrchBXBankNo);
            this.groupBox3.Controls.Add(this.txtBXBankNo);
            this.groupBox3.Location = new System.Drawing.Point(222, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(367, 232);
            this.groupBox3.TabIndex = 1600;
            this.groupBox3.TabStop = false;
            this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // groupPanel15
            // 
            this.groupPanel15.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel15.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel15.Controls.Add(this.button_BankCall);
            this.groupPanel15.Controls.Add(this.button_SrchCostCenterAcc);
            this.groupPanel15.Controls.Add(this.textBox_CostCenter);
            this.groupPanel15.Controls.Add(this.label116);
            this.groupPanel15.Controls.Add(this.textBox_CostCenterName);
            this.groupPanel15.Controls.Add(this.button_SrchAdvancAcc);
            this.groupPanel15.Controls.Add(this.textBox_AccLoan);
            this.groupPanel15.Controls.Add(this.label17);
            this.groupPanel15.Controls.Add(this.textBox_AccLoanName);
            this.groupPanel15.Controls.Add(this.button_SrchHousAcc);
            this.groupPanel15.Controls.Add(this.textBox_AccHousing);
            this.groupPanel15.Controls.Add(this.label16);
            this.groupPanel15.Controls.Add(this.textBox_AccHousingName);
            this.groupPanel15.Controls.Add(this.button_SrchSalAcc);
            this.groupPanel15.Controls.Add(this.textBox_AccSal);
            this.groupPanel15.Controls.Add(this.label15);
            this.groupPanel15.Controls.Add(this.textBox_AccSalName);
            this.groupPanel15.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.groupPanel15.Location = new System.Drawing.Point(7, 66);
            this.groupPanel15.Name = "groupPanel15";
            this.groupPanel15.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupPanel15.Size = new System.Drawing.Size(354, 153);
            // 
            // 
            // 
            this.groupPanel15.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel15.Style.BackColorGradientAngle = 90;
            this.groupPanel15.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel15.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel15.Style.BorderBottomWidth = 1;
            this.groupPanel15.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel15.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel15.Style.BorderLeftWidth = 1;
            this.groupPanel15.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel15.Style.BorderRightWidth = 1;
            this.groupPanel15.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel15.Style.BorderTopWidth = 1;
            this.groupPanel15.Style.CornerDiameter = 4;
            this.groupPanel15.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel15.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel15.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel15.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel15.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel15.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel15.TabIndex = 1601;
            this.groupPanel15.Text = "معطيات القيد المحاسبي التلقائي للراتب";
            // 
            // button_BankCall
            // 
            this.button_BankCall.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_BankCall.Checked = true;
            this.button_BankCall.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_BankCall.Location = new System.Drawing.Point(133, 22);
            this.button_BankCall.Name = "button_BankCall";
            this.button_BankCall.Size = new System.Drawing.Size(14, 0);
            this.button_BankCall.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_BankCall.Symbol = "";
            this.button_BankCall.SymbolSize = 7F;
            this.button_BankCall.TabIndex = 1619;
            this.button_BankCall.TextColor = System.Drawing.Color.SteelBlue;
            this.button_BankCall.Tooltip = "حساب البنك";
            this.button_BankCall.Click += new System.EventHandler(this.button_BankCall_Click);
            // 
            // button_SrchCostCenterAcc
            // 
            this.button_SrchCostCenterAcc.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchCostCenterAcc.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
            this.button_SrchCostCenterAcc.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchCostCenterAcc.Location = new System.Drawing.Point(-615, 130);
            this.button_SrchCostCenterAcc.Name = "button_SrchCostCenterAcc";
            this.button_SrchCostCenterAcc.Size = new System.Drawing.Size(26, 20);
            this.button_SrchCostCenterAcc.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchCostCenterAcc.Symbol = "";
            this.button_SrchCostCenterAcc.SymbolSize = 12F;
            this.button_SrchCostCenterAcc.TabIndex = 1617;
            this.button_SrchCostCenterAcc.TextColor = System.Drawing.Color.SteelBlue;
            // 
            // textBox_CostCenter
            // 
            this.textBox_CostCenter.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Right));
            this.textBox_CostCenter.BackColor = System.Drawing.Color.White;
            this.textBox_CostCenter.Font = new System.Drawing.Font("Tahoma", 9F);
            this.textBox_CostCenter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.textBox_CostCenter.Location = new System.Drawing.Point(-588, 159);
            this.textBox_CostCenter.MaxLength = 30;
            this.textBox_CostCenter.Name = "textBox_CostCenter";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_CostCenter, false);
            this.textBox_CostCenter.ReadOnly = true;
            this.textBox_CostCenter.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox_CostCenter.Size = new System.Drawing.Size(142, 22);
            this.textBox_CostCenter.TabIndex = 1615;
            this.textBox_CostCenter.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label116
            // 
            this.label116.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Right));
            this.label116.AutoSize = true;
            this.label116.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label116.Location = new System.Drawing.Point(-445, 135);
            this.label116.Name = "label116";
            this.label116.Size = new System.Drawing.Size(83, 13);
            this.label116.TabIndex = 1618;
            this.label116.Text = "مركز التكلفــة :";
            // 
            // textBox_CostCenterName
            // 
            this.textBox_CostCenterName.Anchor = ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right));
            this.textBox_CostCenterName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.textBox_CostCenterName.Font = new System.Drawing.Font("Tahoma", 9F);
            this.textBox_CostCenterName.Location = new System.Drawing.Point(16, 151);
            this.textBox_CostCenterName.Name = "textBox_CostCenterName";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_CostCenterName, false);
            this.textBox_CostCenterName.ReadOnly = true;
            this.textBox_CostCenterName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox_CostCenterName.Size = new System.Drawing.Size(0, 22);
            this.textBox_CostCenterName.TabIndex = 1616;
            this.textBox_CostCenterName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button_SrchAdvancAcc
            // 
            this.button_SrchAdvancAcc.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchAdvancAcc.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchAdvancAcc.Location = new System.Drawing.Point(160, 88);
            this.button_SrchAdvancAcc.Name = "button_SrchAdvancAcc";
            this.button_SrchAdvancAcc.Size = new System.Drawing.Size(26, 20);
            this.button_SrchAdvancAcc.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchAdvancAcc.Symbol = "";
            this.button_SrchAdvancAcc.SymbolSize = 12F;
            this.button_SrchAdvancAcc.TabIndex = 1613;
            this.button_SrchAdvancAcc.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchAdvancAcc.Click += new System.EventHandler(this.button_SrchAdvancAcc_Click);
            // 
            // textBox_AccLoan
            // 
            this.textBox_AccLoan.BackColor = System.Drawing.Color.White;
            this.textBox_AccLoan.Font = new System.Drawing.Font("Tahoma", 9F);
            this.textBox_AccLoan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.textBox_AccLoan.Location = new System.Drawing.Point(187, 88);
            this.textBox_AccLoan.MaxLength = 30;
            this.textBox_AccLoan.Name = "textBox_AccLoan";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_AccLoan, false);
            this.textBox_AccLoan.ReadOnly = true;
            this.textBox_AccLoan.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox_AccLoan.Size = new System.Drawing.Size(71, 22);
            this.textBox_AccLoan.TabIndex = 1611;
            this.textBox_AccLoan.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label17.Location = new System.Drawing.Point(258, 93);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(88, 13);
            this.label17.TabIndex = 1614;
            this.label17.Text = "حساب السلف :";
            // 
            // textBox_AccLoanName
            // 
            this.textBox_AccLoanName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.textBox_AccLoanName.Font = new System.Drawing.Font("Tahoma", 9F);
            this.textBox_AccLoanName.Location = new System.Drawing.Point(1, 88);
            this.textBox_AccLoanName.Name = "textBox_AccLoanName";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_AccLoanName, false);
            this.textBox_AccLoanName.ReadOnly = true;
            this.textBox_AccLoanName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox_AccLoanName.Size = new System.Drawing.Size(157, 22);
            this.textBox_AccLoanName.TabIndex = 1612;
            this.textBox_AccLoanName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button_SrchHousAcc
            // 
            this.button_SrchHousAcc.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchHousAcc.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchHousAcc.Location = new System.Drawing.Point(160, 55);
            this.button_SrchHousAcc.Name = "button_SrchHousAcc";
            this.button_SrchHousAcc.Size = new System.Drawing.Size(26, 20);
            this.button_SrchHousAcc.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchHousAcc.Symbol = "";
            this.button_SrchHousAcc.SymbolSize = 12F;
            this.button_SrchHousAcc.TabIndex = 1609;
            this.button_SrchHousAcc.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchHousAcc.Click += new System.EventHandler(this.button_SrchHousAcc_Click);
            // 
            // textBox_AccHousing
            // 
            this.textBox_AccHousing.BackColor = System.Drawing.Color.White;
            this.textBox_AccHousing.Font = new System.Drawing.Font("Tahoma", 9F);
            this.textBox_AccHousing.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.textBox_AccHousing.Location = new System.Drawing.Point(187, 55);
            this.textBox_AccHousing.MaxLength = 30;
            this.textBox_AccHousing.Name = "textBox_AccHousing";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_AccHousing, false);
            this.textBox_AccHousing.ReadOnly = true;
            this.textBox_AccHousing.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox_AccHousing.Size = new System.Drawing.Size(71, 22);
            this.textBox_AccHousing.TabIndex = 1607;
            this.textBox_AccHousing.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label16.Location = new System.Drawing.Point(258, 60);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(88, 13);
            this.label16.TabIndex = 1610;
            this.label16.Text = "حساب السكن :";
            // 
            // textBox_AccHousingName
            // 
            this.textBox_AccHousingName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.textBox_AccHousingName.Font = new System.Drawing.Font("Tahoma", 9F);
            this.textBox_AccHousingName.Location = new System.Drawing.Point(1, 55);
            this.textBox_AccHousingName.Name = "textBox_AccHousingName";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_AccHousingName, false);
            this.textBox_AccHousingName.ReadOnly = true;
            this.textBox_AccHousingName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox_AccHousingName.Size = new System.Drawing.Size(157, 22);
            this.textBox_AccHousingName.TabIndex = 1608;
            this.textBox_AccHousingName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button_SrchSalAcc
            // 
            this.button_SrchSalAcc.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchSalAcc.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchSalAcc.Location = new System.Drawing.Point(160, 22);
            this.button_SrchSalAcc.Name = "button_SrchSalAcc";
            this.button_SrchSalAcc.Size = new System.Drawing.Size(26, 20);
            this.button_SrchSalAcc.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchSalAcc.Symbol = "";
            this.button_SrchSalAcc.SymbolSize = 12F;
            this.button_SrchSalAcc.TabIndex = 1605;
            this.button_SrchSalAcc.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchSalAcc.Click += new System.EventHandler(this.button_SrchSalAcc_Click);
            // 
            // textBox_AccSal
            // 
            this.textBox_AccSal.BackColor = System.Drawing.Color.White;
            this.textBox_AccSal.Font = new System.Drawing.Font("Tahoma", 9F);
            this.textBox_AccSal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.textBox_AccSal.Location = new System.Drawing.Point(187, 22);
            this.textBox_AccSal.MaxLength = 30;
            this.textBox_AccSal.Name = "textBox_AccSal";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_AccSal, false);
            this.textBox_AccSal.ReadOnly = true;
            this.textBox_AccSal.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox_AccSal.Size = new System.Drawing.Size(71, 22);
            this.textBox_AccSal.TabIndex = 1603;
            this.textBox_AccSal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label15.Location = new System.Drawing.Point(258, 27);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(84, 13);
            this.label15.TabIndex = 1606;
            this.label15.Text = "حساب الراتب :";
            // 
            // textBox_AccSalName
            // 
            this.textBox_AccSalName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.textBox_AccSalName.Font = new System.Drawing.Font("Tahoma", 9F);
            this.textBox_AccSalName.Location = new System.Drawing.Point(1, 22);
            this.textBox_AccSalName.Name = "textBox_AccSalName";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_AccSalName, false);
            this.textBox_AccSalName.ReadOnly = true;
            this.textBox_AccSalName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox_AccSalName.Size = new System.Drawing.Size(157, 22);
            this.textBox_AccSalName.TabIndex = 1604;
            this.textBox_AccSalName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // switchButton_AccType
            // 
            // 
            // 
            // 
            this.switchButton_AccType.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.switchButton_AccType.IsReadOnly = true;
            this.switchButton_AccType.Location = new System.Drawing.Point(261, 26);
            this.switchButton_AccType.Name = "switchButton_AccType";
            this.switchButton_AccType.OffText = "الصندوق";
            this.switchButton_AccType.OnText = "البنك";
            this.switchButton_AccType.Size = new System.Drawing.Size(100, 22);
            this.switchButton_AccType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.switchButton_AccType.TabIndex = 1048;
            this.switchButton_AccType.Value = true;
            this.switchButton_AccType.ValueObject = "Y";
            // 
            // txtBXBankName
            // 
            this.txtBXBankName.BackColor = System.Drawing.Color.White;
            this.txtBXBankName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtBXBankName.Location = new System.Drawing.Point(5, 28);
            this.txtBXBankName.Name = "txtBXBankName";
            this.netResize1.SetResizeTextBoxMultiline(this.txtBXBankName, false);
            this.txtBXBankName.ReadOnly = true;
            this.txtBXBankName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtBXBankName.Size = new System.Drawing.Size(138, 20);
            this.txtBXBankName.TabIndex = 1046;
            this.txtBXBankName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button_SrchBXBankNo
            // 
            this.button_SrchBXBankNo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchBXBankNo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchBXBankNo.Location = new System.Drawing.Point(145, 28);
            this.button_SrchBXBankNo.Name = "button_SrchBXBankNo";
            this.button_SrchBXBankNo.Size = new System.Drawing.Size(26, 20);
            this.button_SrchBXBankNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchBXBankNo.Symbol = "";
            this.button_SrchBXBankNo.SymbolSize = 12F;
            this.button_SrchBXBankNo.TabIndex = 1042;
            this.button_SrchBXBankNo.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchBXBankNo.Click += new System.EventHandler(this.button_SrchBXBankNo_Click);
            // 
            // txtBXBankNo
            // 
            this.txtBXBankNo.BackColor = System.Drawing.Color.White;
            this.txtBXBankNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtBXBankNo.Location = new System.Drawing.Point(172, 28);
            this.txtBXBankNo.MaxLength = 30;
            this.txtBXBankNo.Name = "txtBXBankNo";
            this.netResize1.SetResizeTextBoxMultiline(this.txtBXBankNo, false);
            this.txtBXBankNo.ReadOnly = true;
            this.txtBXBankNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtBXBankNo.Size = new System.Drawing.Size(87, 20);
            this.txtBXBankNo.TabIndex = 1041;
            this.txtBXBankNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // expandablePanel_attends
            // 
            this.expandablePanel_attends.CanvasColor = System.Drawing.SystemColors.Control;
            this.expandablePanel_attends.CollapseDirection = DevComponents.DotNetBar.eCollapseDirection.RightToLeft;
            this.expandablePanel_attends.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.expandablePanel_attends.Controls.Add(this.expandablePanel_Fri);
            this.expandablePanel_attends.Controls.Add(this.expandablePanel_Thurs);
            this.expandablePanel_attends.Controls.Add(this.expandablePanel_Wen);
            this.expandablePanel_attends.Controls.Add(this.expandablePanel_Tuse);
            this.expandablePanel_attends.Controls.Add(this.expandablePanel_Mon);
            this.expandablePanel_attends.Controls.Add(this.expandablePanel_Sun);
            this.expandablePanel_attends.Controls.Add(this.expandablePanel_Sat);
            this.expandablePanel_attends.Dock = System.Windows.Forms.DockStyle.Left;
            this.expandablePanel_attends.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.expandablePanel_attends.Location = new System.Drawing.Point(0, 0);
            this.expandablePanel_attends.Name = "expandablePanel_attends";
            this.expandablePanel_attends.Size = new System.Drawing.Size(222, 419);
            this.expandablePanel_attends.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanel_attends.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.expandablePanel_attends.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.expandablePanel_attends.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandablePanel_attends.Style.GradientAngle = 90;
            this.expandablePanel_attends.TabIndex = 6774;
            this.expandablePanel_attends.TitleStyle.Alignment = System.Drawing.StringAlignment.Far;
            this.expandablePanel_attends.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandablePanel_attends.TitleStyle.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.expandablePanel_attends.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            this.expandablePanel_attends.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandablePanel_attends.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.expandablePanel_attends.TitleStyle.GradientAngle = 90;
            this.expandablePanel_attends.TitleStyle.MarginLeft = 6;
            this.expandablePanel_attends.TitleText = "مــواعيـــد الـــــــــــدوام";
            this.expandablePanel_attends.ExpandedChanged += new DevComponents.DotNetBar.ExpandChangeEventHandler(this.expandablePanel_attends_ExpandedChanged);
            // 
            // expandablePanel_Fri
            // 
            this.expandablePanel_Fri.CanvasColor = System.Drawing.SystemColors.Control;
            this.expandablePanel_Fri.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.expandablePanel_Fri.Controls.Add(this.itemPanel7);
            this.expandablePanel_Fri.Dock = System.Windows.Forms.DockStyle.Top;
            this.expandablePanel_Fri.Expanded = false;
            this.expandablePanel_Fri.ExpandedBounds = new System.Drawing.Rectangle(0, 182, 222, 226);
            this.expandablePanel_Fri.ExpandOnTitleClick = true;
            this.expandablePanel_Fri.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.expandablePanel_Fri.Location = new System.Drawing.Point(0, 182);
            this.expandablePanel_Fri.Name = "expandablePanel_Fri";
            this.expandablePanel_Fri.Size = new System.Drawing.Size(222, 26);
            this.expandablePanel_Fri.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanel_Fri.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.expandablePanel_Fri.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.expandablePanel_Fri.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.expandablePanel_Fri.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.expandablePanel_Fri.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandablePanel_Fri.Style.GradientAngle = 90;
            this.expandablePanel_Fri.TabIndex = 9;
            this.expandablePanel_Fri.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandablePanel_Fri.TitleStyle.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.expandablePanel_Fri.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            this.expandablePanel_Fri.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandablePanel_Fri.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.expandablePanel_Fri.TitleStyle.GradientAngle = 90;
            this.expandablePanel_Fri.TitleStyle.MarginLeft = 12;
            this.expandablePanel_Fri.TitleText = "الجمعة";
            this.expandablePanel_Fri.ExpandedChanging += new DevComponents.DotNetBar.ExpandChangeEventHandler(this.expandablePanel_Sat_ExpandedChanging);
            // 
            // itemPanel7
            // 
            // 
            // 
            // 
            this.itemPanel7.BackgroundStyle.BackColor = System.Drawing.Color.AliceBlue;
            this.itemPanel7.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.itemPanel7.BackgroundStyle.BorderBottomWidth = 1;
            this.itemPanel7.BackgroundStyle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            this.itemPanel7.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.itemPanel7.BackgroundStyle.BorderLeftWidth = 1;
            this.itemPanel7.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.itemPanel7.BackgroundStyle.BorderRightWidth = 1;
            this.itemPanel7.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.itemPanel7.BackgroundStyle.BorderTopWidth = 1;
            this.itemPanel7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.itemPanel7.BackgroundStyle.PaddingBottom = 1;
            this.itemPanel7.BackgroundStyle.PaddingLeft = 1;
            this.itemPanel7.BackgroundStyle.PaddingRight = 1;
            this.itemPanel7.BackgroundStyle.PaddingTop = 1;
            this.itemPanel7.ContainerControlProcessDialogKey = true;
            this.itemPanel7.Controls.Add(this.groupPanel11);
            this.itemPanel7.Controls.Add(this.groupPanel12);
            this.itemPanel7.Controls.Add(this.radioButton_FriBreakDay);
            this.itemPanel7.Controls.Add(this.radioButton_FriPeriods2);
            this.itemPanel7.Controls.Add(this.radioButton_FriPeriods1);
            this.itemPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.itemPanel7.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.itemPanel7.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.itemPanel7.Location = new System.Drawing.Point(0, 26);
            this.itemPanel7.Name = "itemPanel7";
            this.itemPanel7.Size = new System.Drawing.Size(222, 0);
            this.itemPanel7.TabIndex = 3;
            this.itemPanel7.Text = "itemPanel7";
            // 
            // groupPanel11
            // 
            this.groupPanel11.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel11.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel11.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel11.Controls.Add(this.textBox_LeaveTime2);
            this.groupPanel11.Controls.Add(this.label50);
            this.groupPanel11.Controls.Add(this.textBox_FriTimeAllow2);
            this.groupPanel11.Controls.Add(this.label51);
            this.groupPanel11.Controls.Add(this.textBox_FriTime2);
            this.groupPanel11.Controls.Add(this.label58);
            this.groupPanel11.Location = new System.Drawing.Point(11, 114);
            this.groupPanel11.Name = "groupPanel11";
            this.groupPanel11.Size = new System.Drawing.Size(200, 79);
            // 
            // 
            // 
            this.groupPanel11.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel11.Style.BackColorGradientAngle = 90;
            this.groupPanel11.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.MenuBackground;
            this.groupPanel11.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel11.Style.BorderBottomWidth = 1;
            this.groupPanel11.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel11.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel11.Style.BorderLeftWidth = 1;
            this.groupPanel11.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel11.Style.BorderRightWidth = 1;
            this.groupPanel11.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel11.Style.BorderTopWidth = 1;
            this.groupPanel11.Style.CornerDiameter = 4;
            this.groupPanel11.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel11.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel11.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel11.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel11.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel11.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel11.TabIndex = 13;
            this.groupPanel11.Text = "الفترة الثانية";
            // 
            // textBox_LeaveTime2
            // 
            this.textBox_LeaveTime2.Location = new System.Drawing.Point(5, 32);
            this.textBox_LeaveTime2.Mask = "##:##";
            this.textBox_LeaveTime2.Name = "textBox_LeaveTime2";
            this.textBox_LeaveTime2.Size = new System.Drawing.Size(47, 21);
            this.textBox_LeaveTime2.TabIndex = 136;
            this.textBox_LeaveTime2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_LeaveTime2.Click += new System.EventHandler(this.textBox_LeaveTime2_Click);
            this.textBox_LeaveTime2.Leave += new System.EventHandler(this.textBox_LeaveTime2_Leave);
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.BackColor = System.Drawing.Color.Transparent;
            this.label50.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label50.Location = new System.Drawing.Point(54, 36);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(54, 13);
            this.label50.TabIndex = 135;
            this.label50.Text = "الانصراف :";
            // 
            // textBox_FriTimeAllow2
            // 
            this.textBox_FriTimeAllow2.Location = new System.Drawing.Point(5, 5);
            this.textBox_FriTimeAllow2.Mask = "##:##";
            this.textBox_FriTimeAllow2.Name = "textBox_FriTimeAllow2";
            this.textBox_FriTimeAllow2.Size = new System.Drawing.Size(47, 21);
            this.textBox_FriTimeAllow2.TabIndex = 134;
            this.textBox_FriTimeAllow2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_FriTimeAllow2.Click += new System.EventHandler(this.textBox_FriTimeAllow2_Click);
            this.textBox_FriTimeAllow2.Leave += new System.EventHandler(this.textBox_FriTimeAllow2_Leave);
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.BackColor = System.Drawing.Color.Transparent;
            this.label51.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label51.Location = new System.Drawing.Point(54, 9);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(36, 13);
            this.label51.TabIndex = 133;
            this.label51.Text = "حتى :";
            // 
            // textBox_FriTime2
            // 
            this.textBox_FriTime2.Location = new System.Drawing.Point(101, 4);
            this.textBox_FriTime2.Mask = "##:##";
            this.textBox_FriTime2.Name = "textBox_FriTime2";
            this.textBox_FriTime2.Size = new System.Drawing.Size(47, 21);
            this.textBox_FriTime2.TabIndex = 130;
            this.textBox_FriTime2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_FriTime2.Click += new System.EventHandler(this.textBox_FriTime2_Click);
            this.textBox_FriTime2.TextChanged += new System.EventHandler(this.textBox_FriTime2_TextChanged);
            this.textBox_FriTime2.Leave += new System.EventHandler(this.textBox_FriTime2_Leave);
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.BackColor = System.Drawing.Color.Transparent;
            this.label58.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label58.Location = new System.Drawing.Point(149, 8);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(39, 13);
            this.label58.TabIndex = 129;
            this.label58.Text = "حضور :";
            // 
            // groupPanel12
            // 
            this.groupPanel12.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel12.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel12.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel12.Controls.Add(this.textBox_LeaveTime1);
            this.groupPanel12.Controls.Add(this.label61);
            this.groupPanel12.Controls.Add(this.textBox_FriTimeAllow1);
            this.groupPanel12.Controls.Add(this.label66);
            this.groupPanel12.Controls.Add(this.textBox_FriTime1);
            this.groupPanel12.Controls.Add(this.label69);
            this.groupPanel12.Location = new System.Drawing.Point(11, 30);
            this.groupPanel12.Name = "groupPanel12";
            this.groupPanel12.Size = new System.Drawing.Size(200, 79);
            // 
            // 
            // 
            this.groupPanel12.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel12.Style.BackColorGradientAngle = 90;
            this.groupPanel12.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.MenuBackground;
            this.groupPanel12.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel12.Style.BorderBottomWidth = 1;
            this.groupPanel12.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel12.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel12.Style.BorderLeftWidth = 1;
            this.groupPanel12.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel12.Style.BorderRightWidth = 1;
            this.groupPanel12.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel12.Style.BorderTopWidth = 1;
            this.groupPanel12.Style.CornerDiameter = 4;
            this.groupPanel12.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel12.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel12.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel12.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel12.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel12.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel12.TabIndex = 12;
            this.groupPanel12.Text = "الفترة الاولى";
            // 
            // textBox_LeaveTime1
            // 
            this.textBox_LeaveTime1.Location = new System.Drawing.Point(5, 32);
            this.textBox_LeaveTime1.Mask = "##:##";
            this.textBox_LeaveTime1.Name = "textBox_LeaveTime1";
            this.textBox_LeaveTime1.Size = new System.Drawing.Size(47, 21);
            this.textBox_LeaveTime1.TabIndex = 136;
            this.textBox_LeaveTime1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_LeaveTime1.Click += new System.EventHandler(this.textBox_LeaveTime1_Click);
            this.textBox_LeaveTime1.Leave += new System.EventHandler(this.textBox_LeaveTime1_Leave);
            // 
            // label61
            // 
            this.label61.AutoSize = true;
            this.label61.BackColor = System.Drawing.Color.Transparent;
            this.label61.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label61.Location = new System.Drawing.Point(53, 36);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(54, 13);
            this.label61.TabIndex = 135;
            this.label61.Text = "الانصراف :";
            // 
            // textBox_FriTimeAllow1
            // 
            this.textBox_FriTimeAllow1.Location = new System.Drawing.Point(5, 5);
            this.textBox_FriTimeAllow1.Mask = "##:##";
            this.textBox_FriTimeAllow1.Name = "textBox_FriTimeAllow1";
            this.textBox_FriTimeAllow1.Size = new System.Drawing.Size(47, 21);
            this.textBox_FriTimeAllow1.TabIndex = 134;
            this.textBox_FriTimeAllow1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_FriTimeAllow1.Click += new System.EventHandler(this.textBox_FriTimeAllow1_Click);
            this.textBox_FriTimeAllow1.Leave += new System.EventHandler(this.textBox_FriTimeAllow1_Leave);
            // 
            // label66
            // 
            this.label66.AutoSize = true;
            this.label66.BackColor = System.Drawing.Color.Transparent;
            this.label66.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label66.Location = new System.Drawing.Point(53, 9);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(36, 13);
            this.label66.TabIndex = 133;
            this.label66.Text = "حتى :";
            // 
            // textBox_FriTime1
            // 
            this.textBox_FriTime1.Location = new System.Drawing.Point(101, 4);
            this.textBox_FriTime1.Mask = "##:##";
            this.textBox_FriTime1.Name = "textBox_FriTime1";
            this.textBox_FriTime1.Size = new System.Drawing.Size(47, 21);
            this.textBox_FriTime1.TabIndex = 130;
            this.textBox_FriTime1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_FriTime1.Click += new System.EventHandler(this.textBox_FriTime1_Click);
            this.textBox_FriTime1.TextChanged += new System.EventHandler(this.textBox_FriTime1_TextChanged);
            this.textBox_FriTime1.Leave += new System.EventHandler(this.textBox_FriTime1_Leave);
            // 
            // label69
            // 
            this.label69.AutoSize = true;
            this.label69.BackColor = System.Drawing.Color.Transparent;
            this.label69.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label69.Location = new System.Drawing.Point(149, 8);
            this.label69.Name = "label69";
            this.label69.Size = new System.Drawing.Size(39, 13);
            this.label69.TabIndex = 129;
            this.label69.Text = "حضور :";
            // 
            // radioButton_FriBreakDay
            // 
            this.radioButton_FriBreakDay.AutoSize = true;
            this.radioButton_FriBreakDay.BackColor = System.Drawing.Color.Transparent;
            this.radioButton_FriBreakDay.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radioButton_FriBreakDay.Location = new System.Drawing.Point(11, 7);
            this.radioButton_FriBreakDay.Name = "radioButton_FriBreakDay";
            this.radioButton_FriBreakDay.Size = new System.Drawing.Size(45, 17);
            this.radioButton_FriBreakDay.TabIndex = 11;
            this.radioButton_FriBreakDay.Text = "راحة";
            this.radioButton_FriBreakDay.UseVisualStyleBackColor = false;
            this.radioButton_FriBreakDay.CheckedChanged += new System.EventHandler(this.radioButton_FriBreakDay_CheckedChanged);
            // 
            // radioButton_FriPeriods2
            // 
            this.radioButton_FriPeriods2.AutoSize = true;
            this.radioButton_FriPeriods2.BackColor = System.Drawing.Color.Transparent;
            this.radioButton_FriPeriods2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radioButton_FriPeriods2.Location = new System.Drawing.Point(79, 7);
            this.radioButton_FriPeriods2.Name = "radioButton_FriPeriods2";
            this.radioButton_FriPeriods2.Size = new System.Drawing.Size(52, 17);
            this.radioButton_FriPeriods2.TabIndex = 10;
            this.radioButton_FriPeriods2.Text = "فترتان";
            this.radioButton_FriPeriods2.UseVisualStyleBackColor = false;
            this.radioButton_FriPeriods2.CheckedChanged += new System.EventHandler(this.radioButton_FriPeriods2_CheckedChanged);
            // 
            // radioButton_FriPeriods1
            // 
            this.radioButton_FriPeriods1.AutoSize = true;
            this.radioButton_FriPeriods1.BackColor = System.Drawing.Color.Transparent;
            this.radioButton_FriPeriods1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radioButton_FriPeriods1.Location = new System.Drawing.Point(154, 7);
            this.radioButton_FriPeriods1.Name = "radioButton_FriPeriods1";
            this.radioButton_FriPeriods1.Size = new System.Drawing.Size(53, 17);
            this.radioButton_FriPeriods1.TabIndex = 9;
            this.radioButton_FriPeriods1.Text = "فتـــرة";
            this.radioButton_FriPeriods1.UseVisualStyleBackColor = false;
            this.radioButton_FriPeriods1.CheckedChanged += new System.EventHandler(this.radioButton_FriPeriods1_CheckedChanged);
            // 
            // expandablePanel_Thurs
            // 
            this.expandablePanel_Thurs.CanvasColor = System.Drawing.SystemColors.Control;
            this.expandablePanel_Thurs.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.expandablePanel_Thurs.Controls.Add(this.itemPanel6);
            this.expandablePanel_Thurs.Dock = System.Windows.Forms.DockStyle.Top;
            this.expandablePanel_Thurs.Expanded = false;
            this.expandablePanel_Thurs.ExpandedBounds = new System.Drawing.Rectangle(0, 156, 222, 226);
            this.expandablePanel_Thurs.ExpandOnTitleClick = true;
            this.expandablePanel_Thurs.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.expandablePanel_Thurs.Location = new System.Drawing.Point(0, 156);
            this.expandablePanel_Thurs.Name = "expandablePanel_Thurs";
            this.expandablePanel_Thurs.Size = new System.Drawing.Size(222, 26);
            this.expandablePanel_Thurs.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanel_Thurs.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.expandablePanel_Thurs.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.expandablePanel_Thurs.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.expandablePanel_Thurs.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.expandablePanel_Thurs.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandablePanel_Thurs.Style.GradientAngle = 90;
            this.expandablePanel_Thurs.TabIndex = 8;
            this.expandablePanel_Thurs.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandablePanel_Thurs.TitleStyle.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.expandablePanel_Thurs.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            this.expandablePanel_Thurs.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandablePanel_Thurs.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.expandablePanel_Thurs.TitleStyle.GradientAngle = 90;
            this.expandablePanel_Thurs.TitleStyle.MarginLeft = 12;
            this.expandablePanel_Thurs.TitleText = "الخميس";
            this.expandablePanel_Thurs.ExpandedChanging += new DevComponents.DotNetBar.ExpandChangeEventHandler(this.expandablePanel_Sat_ExpandedChanging);
            // 
            // itemPanel6
            // 
            // 
            // 
            // 
            this.itemPanel6.BackgroundStyle.BackColor = System.Drawing.Color.AliceBlue;
            this.itemPanel6.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.itemPanel6.BackgroundStyle.BorderBottomWidth = 1;
            this.itemPanel6.BackgroundStyle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            this.itemPanel6.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.itemPanel6.BackgroundStyle.BorderLeftWidth = 1;
            this.itemPanel6.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.itemPanel6.BackgroundStyle.BorderRightWidth = 1;
            this.itemPanel6.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.itemPanel6.BackgroundStyle.BorderTopWidth = 1;
            this.itemPanel6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.itemPanel6.BackgroundStyle.PaddingBottom = 1;
            this.itemPanel6.BackgroundStyle.PaddingLeft = 1;
            this.itemPanel6.BackgroundStyle.PaddingRight = 1;
            this.itemPanel6.BackgroundStyle.PaddingTop = 1;
            this.itemPanel6.ContainerControlProcessDialogKey = true;
            this.itemPanel6.Controls.Add(this.groupPanel13);
            this.itemPanel6.Controls.Add(this.groupPanel14);
            this.itemPanel6.Controls.Add(this.radioButton_ThurBreakDay);
            this.itemPanel6.Controls.Add(this.radioButton_ThurPeriods2);
            this.itemPanel6.Controls.Add(this.radioButton_ThurPeriods1);
            this.itemPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.itemPanel6.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.itemPanel6.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.itemPanel6.Location = new System.Drawing.Point(0, 26);
            this.itemPanel6.Name = "itemPanel6";
            this.itemPanel6.Size = new System.Drawing.Size(222, 0);
            this.itemPanel6.TabIndex = 3;
            this.itemPanel6.Text = "itemPanel6";
            // 
            // groupPanel13
            // 
            this.groupPanel13.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel13.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel13.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel13.Controls.Add(this.textBox_ThurLeaveTime2);
            this.groupPanel13.Controls.Add(this.label71);
            this.groupPanel13.Controls.Add(this.textBox_ThurTimeAllow2);
            this.groupPanel13.Controls.Add(this.label77);
            this.groupPanel13.Controls.Add(this.textBox_ThurTime2);
            this.groupPanel13.Controls.Add(this.label81);
            this.groupPanel13.Location = new System.Drawing.Point(11, 114);
            this.groupPanel13.Name = "groupPanel13";
            this.groupPanel13.Size = new System.Drawing.Size(200, 79);
            // 
            // 
            // 
            this.groupPanel13.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel13.Style.BackColorGradientAngle = 90;
            this.groupPanel13.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.MenuBackground;
            this.groupPanel13.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel13.Style.BorderBottomWidth = 1;
            this.groupPanel13.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel13.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel13.Style.BorderLeftWidth = 1;
            this.groupPanel13.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel13.Style.BorderRightWidth = 1;
            this.groupPanel13.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel13.Style.BorderTopWidth = 1;
            this.groupPanel13.Style.CornerDiameter = 4;
            this.groupPanel13.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel13.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel13.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel13.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel13.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel13.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel13.TabIndex = 13;
            this.groupPanel13.Text = "الفترة الثانية";
            // 
            // textBox_ThurLeaveTime2
            // 
            this.textBox_ThurLeaveTime2.Location = new System.Drawing.Point(5, 32);
            this.textBox_ThurLeaveTime2.Mask = "##:##";
            this.textBox_ThurLeaveTime2.Name = "textBox_ThurLeaveTime2";
            this.textBox_ThurLeaveTime2.Size = new System.Drawing.Size(47, 21);
            this.textBox_ThurLeaveTime2.TabIndex = 136;
            this.textBox_ThurLeaveTime2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_ThurLeaveTime2.Click += new System.EventHandler(this.textBox_ThurLeaveTime2_Click);
            this.textBox_ThurLeaveTime2.Leave += new System.EventHandler(this.textBox_ThurLeaveTime2_Leave);
            // 
            // label71
            // 
            this.label71.AutoSize = true;
            this.label71.BackColor = System.Drawing.Color.Transparent;
            this.label71.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label71.Location = new System.Drawing.Point(54, 36);
            this.label71.Name = "label71";
            this.label71.Size = new System.Drawing.Size(54, 13);
            this.label71.TabIndex = 135;
            this.label71.Text = "الانصراف :";
            // 
            // textBox_ThurTimeAllow2
            // 
            this.textBox_ThurTimeAllow2.Location = new System.Drawing.Point(5, 5);
            this.textBox_ThurTimeAllow2.Mask = "##:##";
            this.textBox_ThurTimeAllow2.Name = "textBox_ThurTimeAllow2";
            this.textBox_ThurTimeAllow2.Size = new System.Drawing.Size(47, 21);
            this.textBox_ThurTimeAllow2.TabIndex = 134;
            this.textBox_ThurTimeAllow2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_ThurTimeAllow2.Click += new System.EventHandler(this.textBox_ThurTimeAllow2_Click);
            this.textBox_ThurTimeAllow2.Leave += new System.EventHandler(this.textBox_ThurTimeAllow2_Leave);
            // 
            // label77
            // 
            this.label77.AutoSize = true;
            this.label77.BackColor = System.Drawing.Color.Transparent;
            this.label77.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label77.Location = new System.Drawing.Point(54, 9);
            this.label77.Name = "label77";
            this.label77.Size = new System.Drawing.Size(36, 13);
            this.label77.TabIndex = 133;
            this.label77.Text = "حتى :";
            // 
            // textBox_ThurTime2
            // 
            this.textBox_ThurTime2.Location = new System.Drawing.Point(101, 4);
            this.textBox_ThurTime2.Mask = "##:##";
            this.textBox_ThurTime2.Name = "textBox_ThurTime2";
            this.textBox_ThurTime2.Size = new System.Drawing.Size(47, 21);
            this.textBox_ThurTime2.TabIndex = 130;
            this.textBox_ThurTime2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_ThurTime2.Click += new System.EventHandler(this.textBox_ThurTime2_Click);
            this.textBox_ThurTime2.TextChanged += new System.EventHandler(this.textBox_ThurTime2_TextChanged);
            this.textBox_ThurTime2.Leave += new System.EventHandler(this.textBox_ThurTime2_Leave);
            // 
            // label81
            // 
            this.label81.AutoSize = true;
            this.label81.BackColor = System.Drawing.Color.Transparent;
            this.label81.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label81.Location = new System.Drawing.Point(149, 8);
            this.label81.Name = "label81";
            this.label81.Size = new System.Drawing.Size(39, 13);
            this.label81.TabIndex = 129;
            this.label81.Text = "حضور :";
            // 
            // groupPanel14
            // 
            this.groupPanel14.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel14.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel14.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel14.Controls.Add(this.textBox_ThurLeaveTime1);
            this.groupPanel14.Controls.Add(this.label87);
            this.groupPanel14.Controls.Add(this.textBox_ThurTimeAllow1);
            this.groupPanel14.Controls.Add(this.label93);
            this.groupPanel14.Controls.Add(this.textBox_ThurTime1);
            this.groupPanel14.Controls.Add(this.label94);
            this.groupPanel14.Location = new System.Drawing.Point(11, 30);
            this.groupPanel14.Name = "groupPanel14";
            this.groupPanel14.Size = new System.Drawing.Size(200, 79);
            // 
            // 
            // 
            this.groupPanel14.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel14.Style.BackColorGradientAngle = 90;
            this.groupPanel14.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.MenuBackground;
            this.groupPanel14.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel14.Style.BorderBottomWidth = 1;
            this.groupPanel14.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel14.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel14.Style.BorderLeftWidth = 1;
            this.groupPanel14.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel14.Style.BorderRightWidth = 1;
            this.groupPanel14.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel14.Style.BorderTopWidth = 1;
            this.groupPanel14.Style.CornerDiameter = 4;
            this.groupPanel14.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel14.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel14.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel14.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel14.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel14.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel14.TabIndex = 12;
            this.groupPanel14.Text = "الفترة الاولى";
            // 
            // textBox_ThurLeaveTime1
            // 
            this.textBox_ThurLeaveTime1.Location = new System.Drawing.Point(5, 32);
            this.textBox_ThurLeaveTime1.Mask = "##:##";
            this.textBox_ThurLeaveTime1.Name = "textBox_ThurLeaveTime1";
            this.textBox_ThurLeaveTime1.Size = new System.Drawing.Size(47, 21);
            this.textBox_ThurLeaveTime1.TabIndex = 136;
            this.textBox_ThurLeaveTime1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_ThurLeaveTime1.Click += new System.EventHandler(this.textBox_ThurLeaveTime1_Click);
            this.textBox_ThurLeaveTime1.Leave += new System.EventHandler(this.textBox_ThurLeaveTime1_Leave);
            // 
            // label87
            // 
            this.label87.AutoSize = true;
            this.label87.BackColor = System.Drawing.Color.Transparent;
            this.label87.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label87.Location = new System.Drawing.Point(53, 36);
            this.label87.Name = "label87";
            this.label87.Size = new System.Drawing.Size(54, 13);
            this.label87.TabIndex = 135;
            this.label87.Text = "الانصراف :";
            // 
            // textBox_ThurTimeAllow1
            // 
            this.textBox_ThurTimeAllow1.Location = new System.Drawing.Point(5, 5);
            this.textBox_ThurTimeAllow1.Mask = "##:##";
            this.textBox_ThurTimeAllow1.Name = "textBox_ThurTimeAllow1";
            this.textBox_ThurTimeAllow1.Size = new System.Drawing.Size(47, 21);
            this.textBox_ThurTimeAllow1.TabIndex = 134;
            this.textBox_ThurTimeAllow1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_ThurTimeAllow1.Click += new System.EventHandler(this.textBox_ThurTimeAllow1_Click);
            this.textBox_ThurTimeAllow1.Leave += new System.EventHandler(this.textBox_ThurTimeAllow1_Leave);
            // 
            // label93
            // 
            this.label93.AutoSize = true;
            this.label93.BackColor = System.Drawing.Color.Transparent;
            this.label93.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label93.Location = new System.Drawing.Point(53, 9);
            this.label93.Name = "label93";
            this.label93.Size = new System.Drawing.Size(36, 13);
            this.label93.TabIndex = 133;
            this.label93.Text = "حتى :";
            // 
            // textBox_ThurTime1
            // 
            this.textBox_ThurTime1.Location = new System.Drawing.Point(101, 4);
            this.textBox_ThurTime1.Mask = "##:##";
            this.textBox_ThurTime1.Name = "textBox_ThurTime1";
            this.textBox_ThurTime1.Size = new System.Drawing.Size(47, 21);
            this.textBox_ThurTime1.TabIndex = 130;
            this.textBox_ThurTime1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_ThurTime1.Click += new System.EventHandler(this.textBox_ThurTime1_Click);
            this.textBox_ThurTime1.TextChanged += new System.EventHandler(this.textBox_ThurTime1_TextChanged);
            this.textBox_ThurTime1.Leave += new System.EventHandler(this.textBox_ThurTime1_Leave);
            // 
            // label94
            // 
            this.label94.AutoSize = true;
            this.label94.BackColor = System.Drawing.Color.Transparent;
            this.label94.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label94.Location = new System.Drawing.Point(149, 8);
            this.label94.Name = "label94";
            this.label94.Size = new System.Drawing.Size(39, 13);
            this.label94.TabIndex = 129;
            this.label94.Text = "حضور :";
            // 
            // radioButton_ThurBreakDay
            // 
            this.radioButton_ThurBreakDay.AutoSize = true;
            this.radioButton_ThurBreakDay.BackColor = System.Drawing.Color.Transparent;
            this.radioButton_ThurBreakDay.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radioButton_ThurBreakDay.Location = new System.Drawing.Point(11, 7);
            this.radioButton_ThurBreakDay.Name = "radioButton_ThurBreakDay";
            this.radioButton_ThurBreakDay.Size = new System.Drawing.Size(45, 17);
            this.radioButton_ThurBreakDay.TabIndex = 11;
            this.radioButton_ThurBreakDay.Text = "راحة";
            this.radioButton_ThurBreakDay.UseVisualStyleBackColor = false;
            this.radioButton_ThurBreakDay.CheckedChanged += new System.EventHandler(this.radioButton_ThurBreakDay_CheckedChanged);
            // 
            // radioButton_ThurPeriods2
            // 
            this.radioButton_ThurPeriods2.AutoSize = true;
            this.radioButton_ThurPeriods2.BackColor = System.Drawing.Color.Transparent;
            this.radioButton_ThurPeriods2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radioButton_ThurPeriods2.Location = new System.Drawing.Point(79, 7);
            this.radioButton_ThurPeriods2.Name = "radioButton_ThurPeriods2";
            this.radioButton_ThurPeriods2.Size = new System.Drawing.Size(52, 17);
            this.radioButton_ThurPeriods2.TabIndex = 10;
            this.radioButton_ThurPeriods2.Text = "فترتان";
            this.radioButton_ThurPeriods2.UseVisualStyleBackColor = false;
            this.radioButton_ThurPeriods2.CheckedChanged += new System.EventHandler(this.radioButton_ThurPeriods2_CheckedChanged);
            // 
            // radioButton_ThurPeriods1
            // 
            this.radioButton_ThurPeriods1.AutoSize = true;
            this.radioButton_ThurPeriods1.BackColor = System.Drawing.Color.Transparent;
            this.radioButton_ThurPeriods1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radioButton_ThurPeriods1.Location = new System.Drawing.Point(154, 7);
            this.radioButton_ThurPeriods1.Name = "radioButton_ThurPeriods1";
            this.radioButton_ThurPeriods1.Size = new System.Drawing.Size(53, 17);
            this.radioButton_ThurPeriods1.TabIndex = 9;
            this.radioButton_ThurPeriods1.Text = "فتـــرة";
            this.radioButton_ThurPeriods1.UseVisualStyleBackColor = false;
            this.radioButton_ThurPeriods1.CheckedChanged += new System.EventHandler(this.radioButton_ThurPeriods1_CheckedChanged);
            // 
            // expandablePanel_Wen
            // 
            this.expandablePanel_Wen.CanvasColor = System.Drawing.SystemColors.Control;
            this.expandablePanel_Wen.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.expandablePanel_Wen.Controls.Add(this.itemPanel5);
            this.expandablePanel_Wen.Dock = System.Windows.Forms.DockStyle.Top;
            this.expandablePanel_Wen.Expanded = false;
            this.expandablePanel_Wen.ExpandedBounds = new System.Drawing.Rectangle(0, 130, 30, 226);
            this.expandablePanel_Wen.ExpandOnTitleClick = true;
            this.expandablePanel_Wen.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.expandablePanel_Wen.Location = new System.Drawing.Point(0, 130);
            this.expandablePanel_Wen.Name = "expandablePanel_Wen";
            this.expandablePanel_Wen.Size = new System.Drawing.Size(222, 26);
            this.expandablePanel_Wen.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanel_Wen.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.expandablePanel_Wen.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.expandablePanel_Wen.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.expandablePanel_Wen.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.expandablePanel_Wen.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandablePanel_Wen.Style.GradientAngle = 90;
            this.expandablePanel_Wen.TabIndex = 7;
            this.expandablePanel_Wen.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandablePanel_Wen.TitleStyle.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.expandablePanel_Wen.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            this.expandablePanel_Wen.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandablePanel_Wen.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.expandablePanel_Wen.TitleStyle.GradientAngle = 90;
            this.expandablePanel_Wen.TitleStyle.MarginLeft = 12;
            this.expandablePanel_Wen.TitleText = "الأربعاء";
            this.expandablePanel_Wen.ExpandedChanging += new DevComponents.DotNetBar.ExpandChangeEventHandler(this.expandablePanel_Sat_ExpandedChanging);
            // 
            // itemPanel5
            // 
            // 
            // 
            // 
            this.itemPanel5.BackgroundStyle.BackColor = System.Drawing.Color.AliceBlue;
            this.itemPanel5.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.itemPanel5.BackgroundStyle.BorderBottomWidth = 1;
            this.itemPanel5.BackgroundStyle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            this.itemPanel5.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.itemPanel5.BackgroundStyle.BorderLeftWidth = 1;
            this.itemPanel5.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.itemPanel5.BackgroundStyle.BorderRightWidth = 1;
            this.itemPanel5.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.itemPanel5.BackgroundStyle.BorderTopWidth = 1;
            this.itemPanel5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.itemPanel5.BackgroundStyle.PaddingBottom = 1;
            this.itemPanel5.BackgroundStyle.PaddingLeft = 1;
            this.itemPanel5.BackgroundStyle.PaddingRight = 1;
            this.itemPanel5.BackgroundStyle.PaddingTop = 1;
            this.itemPanel5.ContainerControlProcessDialogKey = true;
            this.itemPanel5.Controls.Add(this.groupPanel9);
            this.itemPanel5.Controls.Add(this.groupPanel10);
            this.itemPanel5.Controls.Add(this.radioButton_WenBreakDay);
            this.itemPanel5.Controls.Add(this.radioButton_WenPeriods2);
            this.itemPanel5.Controls.Add(this.radioButton_WenPeriods1);
            this.itemPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.itemPanel5.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.itemPanel5.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.itemPanel5.Location = new System.Drawing.Point(0, 26);
            this.itemPanel5.Name = "itemPanel5";
            this.itemPanel5.Size = new System.Drawing.Size(222, 0);
            this.itemPanel5.TabIndex = 3;
            this.itemPanel5.Text = "itemPanel5";
            // 
            // groupPanel9
            // 
            this.groupPanel9.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel9.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel9.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel9.Controls.Add(this.textBox_WenLeaveTime2);
            this.groupPanel9.Controls.Add(this.label44);
            this.groupPanel9.Controls.Add(this.textBox_WenTimeAllow2);
            this.groupPanel9.Controls.Add(this.label45);
            this.groupPanel9.Controls.Add(this.textBox_WenTime2);
            this.groupPanel9.Controls.Add(this.label46);
            this.groupPanel9.Location = new System.Drawing.Point(11, 114);
            this.groupPanel9.Name = "groupPanel9";
            this.groupPanel9.Size = new System.Drawing.Size(200, 79);
            // 
            // 
            // 
            this.groupPanel9.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel9.Style.BackColorGradientAngle = 90;
            this.groupPanel9.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.MenuBackground;
            this.groupPanel9.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel9.Style.BorderBottomWidth = 1;
            this.groupPanel9.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel9.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel9.Style.BorderLeftWidth = 1;
            this.groupPanel9.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel9.Style.BorderRightWidth = 1;
            this.groupPanel9.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel9.Style.BorderTopWidth = 1;
            this.groupPanel9.Style.CornerDiameter = 4;
            this.groupPanel9.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel9.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel9.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel9.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel9.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel9.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel9.TabIndex = 13;
            this.groupPanel9.Text = "الفترة الثانية";
            // 
            // textBox_WenLeaveTime2
            // 
            this.textBox_WenLeaveTime2.Location = new System.Drawing.Point(5, 32);
            this.textBox_WenLeaveTime2.Mask = "##:##";
            this.textBox_WenLeaveTime2.Name = "textBox_WenLeaveTime2";
            this.textBox_WenLeaveTime2.Size = new System.Drawing.Size(47, 21);
            this.textBox_WenLeaveTime2.TabIndex = 136;
            this.textBox_WenLeaveTime2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_WenLeaveTime2.Click += new System.EventHandler(this.textBox_WenLeaveTime2_Click);
            this.textBox_WenLeaveTime2.Leave += new System.EventHandler(this.textBox_WenLeaveTime2_Leave);
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.BackColor = System.Drawing.Color.Transparent;
            this.label44.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label44.Location = new System.Drawing.Point(54, 36);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(54, 13);
            this.label44.TabIndex = 135;
            this.label44.Text = "الانصراف :";
            // 
            // textBox_WenTimeAllow2
            // 
            this.textBox_WenTimeAllow2.Location = new System.Drawing.Point(5, 5);
            this.textBox_WenTimeAllow2.Mask = "##:##";
            this.textBox_WenTimeAllow2.Name = "textBox_WenTimeAllow2";
            this.textBox_WenTimeAllow2.Size = new System.Drawing.Size(47, 21);
            this.textBox_WenTimeAllow2.TabIndex = 134;
            this.textBox_WenTimeAllow2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_WenTimeAllow2.Click += new System.EventHandler(this.textBox_WenTimeAllow2_Click);
            this.textBox_WenTimeAllow2.Leave += new System.EventHandler(this.textBox_WenTimeAllow2_Leave);
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.BackColor = System.Drawing.Color.Transparent;
            this.label45.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label45.Location = new System.Drawing.Point(54, 9);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(36, 13);
            this.label45.TabIndex = 133;
            this.label45.Text = "حتى :";
            // 
            // textBox_WenTime2
            // 
            this.textBox_WenTime2.Location = new System.Drawing.Point(101, 4);
            this.textBox_WenTime2.Mask = "##:##";
            this.textBox_WenTime2.Name = "textBox_WenTime2";
            this.textBox_WenTime2.Size = new System.Drawing.Size(47, 21);
            this.textBox_WenTime2.TabIndex = 130;
            this.textBox_WenTime2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_WenTime2.Click += new System.EventHandler(this.textBox_WenTime2_Click);
            this.textBox_WenTime2.TextChanged += new System.EventHandler(this.textBox_WenTime2_TextChanged);
            this.textBox_WenTime2.Leave += new System.EventHandler(this.textBox_WenTime2_Leave);
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.BackColor = System.Drawing.Color.Transparent;
            this.label46.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label46.Location = new System.Drawing.Point(149, 8);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(39, 13);
            this.label46.TabIndex = 129;
            this.label46.Text = "حضور :";
            // 
            // groupPanel10
            // 
            this.groupPanel10.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel10.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel10.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel10.Controls.Add(this.textBox_WenLeaveTime1);
            this.groupPanel10.Controls.Add(this.label47);
            this.groupPanel10.Controls.Add(this.textBox_WenTimeAllow1);
            this.groupPanel10.Controls.Add(this.label48);
            this.groupPanel10.Controls.Add(this.textBox_WenTime1);
            this.groupPanel10.Controls.Add(this.label49);
            this.groupPanel10.Location = new System.Drawing.Point(11, 30);
            this.groupPanel10.Name = "groupPanel10";
            this.groupPanel10.Size = new System.Drawing.Size(200, 79);
            // 
            // 
            // 
            this.groupPanel10.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel10.Style.BackColorGradientAngle = 90;
            this.groupPanel10.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.MenuBackground;
            this.groupPanel10.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel10.Style.BorderBottomWidth = 1;
            this.groupPanel10.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel10.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel10.Style.BorderLeftWidth = 1;
            this.groupPanel10.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel10.Style.BorderRightWidth = 1;
            this.groupPanel10.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel10.Style.BorderTopWidth = 1;
            this.groupPanel10.Style.CornerDiameter = 4;
            this.groupPanel10.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel10.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel10.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel10.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel10.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel10.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel10.TabIndex = 12;
            this.groupPanel10.Text = "الفترة الاولى";
            // 
            // textBox_WenLeaveTime1
            // 
            this.textBox_WenLeaveTime1.Location = new System.Drawing.Point(5, 32);
            this.textBox_WenLeaveTime1.Mask = "##:##";
            this.textBox_WenLeaveTime1.Name = "textBox_WenLeaveTime1";
            this.textBox_WenLeaveTime1.Size = new System.Drawing.Size(47, 21);
            this.textBox_WenLeaveTime1.TabIndex = 136;
            this.textBox_WenLeaveTime1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_WenLeaveTime1.Click += new System.EventHandler(this.textBox_WenLeaveTime1_Click);
            this.textBox_WenLeaveTime1.Leave += new System.EventHandler(this.textBox_WenLeaveTime1_Leave);
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.BackColor = System.Drawing.Color.Transparent;
            this.label47.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label47.Location = new System.Drawing.Point(53, 36);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(54, 13);
            this.label47.TabIndex = 135;
            this.label47.Text = "الانصراف :";
            // 
            // textBox_WenTimeAllow1
            // 
            this.textBox_WenTimeAllow1.Location = new System.Drawing.Point(5, 5);
            this.textBox_WenTimeAllow1.Mask = "##:##";
            this.textBox_WenTimeAllow1.Name = "textBox_WenTimeAllow1";
            this.textBox_WenTimeAllow1.Size = new System.Drawing.Size(47, 21);
            this.textBox_WenTimeAllow1.TabIndex = 134;
            this.textBox_WenTimeAllow1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_WenTimeAllow1.Click += new System.EventHandler(this.textBox_WenTimeAllow1_Click);
            this.textBox_WenTimeAllow1.Leave += new System.EventHandler(this.textBox_WenTimeAllow1_Leave);
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.BackColor = System.Drawing.Color.Transparent;
            this.label48.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label48.Location = new System.Drawing.Point(53, 9);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(36, 13);
            this.label48.TabIndex = 133;
            this.label48.Text = "حتى :";
            // 
            // textBox_WenTime1
            // 
            this.textBox_WenTime1.Location = new System.Drawing.Point(101, 4);
            this.textBox_WenTime1.Mask = "##:##";
            this.textBox_WenTime1.Name = "textBox_WenTime1";
            this.textBox_WenTime1.Size = new System.Drawing.Size(47, 21);
            this.textBox_WenTime1.TabIndex = 130;
            this.textBox_WenTime1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_WenTime1.Click += new System.EventHandler(this.textBox_WenTime1_Click);
            this.textBox_WenTime1.TextChanged += new System.EventHandler(this.textBox_WenTime1_TextChanged);
            this.textBox_WenTime1.Leave += new System.EventHandler(this.textBox_WenTime1_Leave);
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.BackColor = System.Drawing.Color.Transparent;
            this.label49.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label49.Location = new System.Drawing.Point(149, 8);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(39, 13);
            this.label49.TabIndex = 129;
            this.label49.Text = "حضور :";
            // 
            // radioButton_WenBreakDay
            // 
            this.radioButton_WenBreakDay.AutoSize = true;
            this.radioButton_WenBreakDay.BackColor = System.Drawing.Color.Transparent;
            this.radioButton_WenBreakDay.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radioButton_WenBreakDay.Location = new System.Drawing.Point(11, 7);
            this.radioButton_WenBreakDay.Name = "radioButton_WenBreakDay";
            this.radioButton_WenBreakDay.Size = new System.Drawing.Size(45, 17);
            this.radioButton_WenBreakDay.TabIndex = 11;
            this.radioButton_WenBreakDay.Text = "راحة";
            this.radioButton_WenBreakDay.UseVisualStyleBackColor = false;
            this.radioButton_WenBreakDay.CheckedChanged += new System.EventHandler(this.radioButton_WenBreakDay_CheckedChanged);
            // 
            // radioButton_WenPeriods2
            // 
            this.radioButton_WenPeriods2.AutoSize = true;
            this.radioButton_WenPeriods2.BackColor = System.Drawing.Color.Transparent;
            this.radioButton_WenPeriods2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radioButton_WenPeriods2.Location = new System.Drawing.Point(79, 7);
            this.radioButton_WenPeriods2.Name = "radioButton_WenPeriods2";
            this.radioButton_WenPeriods2.Size = new System.Drawing.Size(52, 17);
            this.radioButton_WenPeriods2.TabIndex = 10;
            this.radioButton_WenPeriods2.Text = "فترتان";
            this.radioButton_WenPeriods2.UseVisualStyleBackColor = false;
            this.radioButton_WenPeriods2.CheckedChanged += new System.EventHandler(this.radioButton_WenPeriods2_CheckedChanged);
            // 
            // radioButton_WenPeriods1
            // 
            this.radioButton_WenPeriods1.AutoSize = true;
            this.radioButton_WenPeriods1.BackColor = System.Drawing.Color.Transparent;
            this.radioButton_WenPeriods1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radioButton_WenPeriods1.Location = new System.Drawing.Point(154, 7);
            this.radioButton_WenPeriods1.Name = "radioButton_WenPeriods1";
            this.radioButton_WenPeriods1.Size = new System.Drawing.Size(53, 17);
            this.radioButton_WenPeriods1.TabIndex = 9;
            this.radioButton_WenPeriods1.Text = "فتـــرة";
            this.radioButton_WenPeriods1.UseVisualStyleBackColor = false;
            this.radioButton_WenPeriods1.CheckedChanged += new System.EventHandler(this.radioButton_WenPeriods1_CheckedChanged);
            // 
            // expandablePanel_Tuse
            // 
            this.expandablePanel_Tuse.CanvasColor = System.Drawing.SystemColors.Control;
            this.expandablePanel_Tuse.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.expandablePanel_Tuse.Controls.Add(this.itemPanel4);
            this.expandablePanel_Tuse.Dock = System.Windows.Forms.DockStyle.Top;
            this.expandablePanel_Tuse.Expanded = false;
            this.expandablePanel_Tuse.ExpandedBounds = new System.Drawing.Rectangle(0, 104, 222, 226);
            this.expandablePanel_Tuse.ExpandOnTitleClick = true;
            this.expandablePanel_Tuse.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.expandablePanel_Tuse.Location = new System.Drawing.Point(0, 104);
            this.expandablePanel_Tuse.Name = "expandablePanel_Tuse";
            this.expandablePanel_Tuse.Size = new System.Drawing.Size(222, 26);
            this.expandablePanel_Tuse.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanel_Tuse.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.expandablePanel_Tuse.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.expandablePanel_Tuse.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.expandablePanel_Tuse.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.expandablePanel_Tuse.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandablePanel_Tuse.Style.GradientAngle = 90;
            this.expandablePanel_Tuse.TabIndex = 6;
            this.expandablePanel_Tuse.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandablePanel_Tuse.TitleStyle.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.expandablePanel_Tuse.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            this.expandablePanel_Tuse.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandablePanel_Tuse.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.expandablePanel_Tuse.TitleStyle.GradientAngle = 90;
            this.expandablePanel_Tuse.TitleStyle.MarginLeft = 12;
            this.expandablePanel_Tuse.TitleText = "الثلاثاء";
            this.expandablePanel_Tuse.ExpandedChanging += new DevComponents.DotNetBar.ExpandChangeEventHandler(this.expandablePanel_Sat_ExpandedChanging);
            // 
            // itemPanel4
            // 
            // 
            // 
            // 
            this.itemPanel4.BackgroundStyle.BackColor = System.Drawing.Color.AliceBlue;
            this.itemPanel4.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.itemPanel4.BackgroundStyle.BorderBottomWidth = 1;
            this.itemPanel4.BackgroundStyle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            this.itemPanel4.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.itemPanel4.BackgroundStyle.BorderLeftWidth = 1;
            this.itemPanel4.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.itemPanel4.BackgroundStyle.BorderRightWidth = 1;
            this.itemPanel4.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.itemPanel4.BackgroundStyle.BorderTopWidth = 1;
            this.itemPanel4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.itemPanel4.BackgroundStyle.PaddingBottom = 1;
            this.itemPanel4.BackgroundStyle.PaddingLeft = 1;
            this.itemPanel4.BackgroundStyle.PaddingRight = 1;
            this.itemPanel4.BackgroundStyle.PaddingTop = 1;
            this.itemPanel4.ContainerControlProcessDialogKey = true;
            this.itemPanel4.Controls.Add(this.groupPanel7);
            this.itemPanel4.Controls.Add(this.groupPanel8);
            this.itemPanel4.Controls.Add(this.radioButton_TusBreakDay);
            this.itemPanel4.Controls.Add(this.radioButton_TusPeriods2);
            this.itemPanel4.Controls.Add(this.radioButton_TusPeriods1);
            this.itemPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.itemPanel4.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.itemPanel4.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.itemPanel4.Location = new System.Drawing.Point(0, 26);
            this.itemPanel4.Name = "itemPanel4";
            this.itemPanel4.Size = new System.Drawing.Size(222, 0);
            this.itemPanel4.TabIndex = 3;
            this.itemPanel4.Text = "itemPanel4";
            // 
            // groupPanel7
            // 
            this.groupPanel7.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel7.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel7.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel7.Controls.Add(this.textBox_TusLeaveTime2);
            this.groupPanel7.Controls.Add(this.label35);
            this.groupPanel7.Controls.Add(this.textBox_TusTimeAllow2);
            this.groupPanel7.Controls.Add(this.label37);
            this.groupPanel7.Controls.Add(this.textBox_TusTime2);
            this.groupPanel7.Controls.Add(this.label39);
            this.groupPanel7.Location = new System.Drawing.Point(11, 114);
            this.groupPanel7.Name = "groupPanel7";
            this.groupPanel7.Size = new System.Drawing.Size(200, 79);
            // 
            // 
            // 
            this.groupPanel7.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel7.Style.BackColorGradientAngle = 90;
            this.groupPanel7.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.MenuBackground;
            this.groupPanel7.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel7.Style.BorderBottomWidth = 1;
            this.groupPanel7.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel7.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel7.Style.BorderLeftWidth = 1;
            this.groupPanel7.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel7.Style.BorderRightWidth = 1;
            this.groupPanel7.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel7.Style.BorderTopWidth = 1;
            this.groupPanel7.Style.CornerDiameter = 4;
            this.groupPanel7.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel7.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel7.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel7.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel7.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel7.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel7.TabIndex = 13;
            this.groupPanel7.Text = "الفترة الثانية";
            // 
            // textBox_TusLeaveTime2
            // 
            this.textBox_TusLeaveTime2.Location = new System.Drawing.Point(5, 32);
            this.textBox_TusLeaveTime2.Mask = "##:##";
            this.textBox_TusLeaveTime2.Name = "textBox_TusLeaveTime2";
            this.textBox_TusLeaveTime2.Size = new System.Drawing.Size(47, 21);
            this.textBox_TusLeaveTime2.TabIndex = 136;
            this.textBox_TusLeaveTime2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_TusLeaveTime2.Click += new System.EventHandler(this.textBox_TusLeaveTime2_Click);
            this.textBox_TusLeaveTime2.Leave += new System.EventHandler(this.textBox_TusLeaveTime2_Leave);
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.BackColor = System.Drawing.Color.Transparent;
            this.label35.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label35.Location = new System.Drawing.Point(54, 36);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(54, 13);
            this.label35.TabIndex = 135;
            this.label35.Text = "الانصراف :";
            // 
            // textBox_TusTimeAllow2
            // 
            this.textBox_TusTimeAllow2.Location = new System.Drawing.Point(5, 5);
            this.textBox_TusTimeAllow2.Mask = "##:##";
            this.textBox_TusTimeAllow2.Name = "textBox_TusTimeAllow2";
            this.textBox_TusTimeAllow2.Size = new System.Drawing.Size(47, 21);
            this.textBox_TusTimeAllow2.TabIndex = 134;
            this.textBox_TusTimeAllow2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_TusTimeAllow2.Click += new System.EventHandler(this.textBox_TusTimeAllow2_Click);
            this.textBox_TusTimeAllow2.Leave += new System.EventHandler(this.textBox_TusTimeAllow2_Leave);
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.BackColor = System.Drawing.Color.Transparent;
            this.label37.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label37.Location = new System.Drawing.Point(54, 9);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(36, 13);
            this.label37.TabIndex = 133;
            this.label37.Text = "حتى :";
            // 
            // textBox_TusTime2
            // 
            this.textBox_TusTime2.Location = new System.Drawing.Point(101, 4);
            this.textBox_TusTime2.Mask = "##:##";
            this.textBox_TusTime2.Name = "textBox_TusTime2";
            this.textBox_TusTime2.Size = new System.Drawing.Size(47, 21);
            this.textBox_TusTime2.TabIndex = 130;
            this.textBox_TusTime2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_TusTime2.Click += new System.EventHandler(this.textBox_TusTime2_Click);
            this.textBox_TusTime2.TextChanged += new System.EventHandler(this.textBox_TusTime2_TextChanged);
            this.textBox_TusTime2.Leave += new System.EventHandler(this.textBox_TusTime2_Leave);
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.BackColor = System.Drawing.Color.Transparent;
            this.label39.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label39.Location = new System.Drawing.Point(149, 8);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(39, 13);
            this.label39.TabIndex = 129;
            this.label39.Text = "حضور :";
            // 
            // groupPanel8
            // 
            this.groupPanel8.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel8.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel8.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel8.Controls.Add(this.textBox_TusLeaveTime1);
            this.groupPanel8.Controls.Add(this.label41);
            this.groupPanel8.Controls.Add(this.textBox_TusTimeAllow1);
            this.groupPanel8.Controls.Add(this.label42);
            this.groupPanel8.Controls.Add(this.textBox_TusTime1);
            this.groupPanel8.Controls.Add(this.label43);
            this.groupPanel8.Location = new System.Drawing.Point(11, 30);
            this.groupPanel8.Name = "groupPanel8";
            this.groupPanel8.Size = new System.Drawing.Size(200, 79);
            // 
            // 
            // 
            this.groupPanel8.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel8.Style.BackColorGradientAngle = 90;
            this.groupPanel8.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.MenuBackground;
            this.groupPanel8.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel8.Style.BorderBottomWidth = 1;
            this.groupPanel8.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel8.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel8.Style.BorderLeftWidth = 1;
            this.groupPanel8.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel8.Style.BorderRightWidth = 1;
            this.groupPanel8.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel8.Style.BorderTopWidth = 1;
            this.groupPanel8.Style.CornerDiameter = 4;
            this.groupPanel8.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel8.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel8.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel8.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel8.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel8.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel8.TabIndex = 12;
            this.groupPanel8.Text = "الفترة الاولى";
            // 
            // textBox_TusLeaveTime1
            // 
            this.textBox_TusLeaveTime1.Location = new System.Drawing.Point(5, 32);
            this.textBox_TusLeaveTime1.Mask = "##:##";
            this.textBox_TusLeaveTime1.Name = "textBox_TusLeaveTime1";
            this.textBox_TusLeaveTime1.Size = new System.Drawing.Size(47, 21);
            this.textBox_TusLeaveTime1.TabIndex = 136;
            this.textBox_TusLeaveTime1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_TusLeaveTime1.Click += new System.EventHandler(this.textBox_TusLeaveTime1_Click);
            this.textBox_TusLeaveTime1.Leave += new System.EventHandler(this.textBox_TusLeaveTime1_Leave);
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.BackColor = System.Drawing.Color.Transparent;
            this.label41.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label41.Location = new System.Drawing.Point(53, 36);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(54, 13);
            this.label41.TabIndex = 135;
            this.label41.Text = "الانصراف :";
            // 
            // textBox_TusTimeAllow1
            // 
            this.textBox_TusTimeAllow1.Location = new System.Drawing.Point(5, 5);
            this.textBox_TusTimeAllow1.Mask = "##:##";
            this.textBox_TusTimeAllow1.Name = "textBox_TusTimeAllow1";
            this.textBox_TusTimeAllow1.Size = new System.Drawing.Size(47, 21);
            this.textBox_TusTimeAllow1.TabIndex = 134;
            this.textBox_TusTimeAllow1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_TusTimeAllow1.Click += new System.EventHandler(this.textBox_TusTimeAllow1_Click);
            this.textBox_TusTimeAllow1.Leave += new System.EventHandler(this.textBox_TusTimeAllow1_Leave);
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.BackColor = System.Drawing.Color.Transparent;
            this.label42.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label42.Location = new System.Drawing.Point(53, 9);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(36, 13);
            this.label42.TabIndex = 133;
            this.label42.Text = "حتى :";
            // 
            // textBox_TusTime1
            // 
            this.textBox_TusTime1.Location = new System.Drawing.Point(101, 4);
            this.textBox_TusTime1.Mask = "##:##";
            this.textBox_TusTime1.Name = "textBox_TusTime1";
            this.textBox_TusTime1.Size = new System.Drawing.Size(47, 21);
            this.textBox_TusTime1.TabIndex = 130;
            this.textBox_TusTime1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_TusTime1.Click += new System.EventHandler(this.textBox_TusTime1_Click);
            this.textBox_TusTime1.TextChanged += new System.EventHandler(this.textBox_TusTime1_TextChanged);
            this.textBox_TusTime1.Leave += new System.EventHandler(this.textBox_TusTime1_Leave);
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.BackColor = System.Drawing.Color.Transparent;
            this.label43.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label43.Location = new System.Drawing.Point(149, 8);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(39, 13);
            this.label43.TabIndex = 129;
            this.label43.Text = "حضور :";
            // 
            // radioButton_TusBreakDay
            // 
            this.radioButton_TusBreakDay.AutoSize = true;
            this.radioButton_TusBreakDay.BackColor = System.Drawing.Color.Transparent;
            this.radioButton_TusBreakDay.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radioButton_TusBreakDay.Location = new System.Drawing.Point(11, 7);
            this.radioButton_TusBreakDay.Name = "radioButton_TusBreakDay";
            this.radioButton_TusBreakDay.Size = new System.Drawing.Size(45, 17);
            this.radioButton_TusBreakDay.TabIndex = 11;
            this.radioButton_TusBreakDay.Text = "راحة";
            this.radioButton_TusBreakDay.UseVisualStyleBackColor = false;
            this.radioButton_TusBreakDay.CheckedChanged += new System.EventHandler(this.radioButton_TusBreakDay_CheckedChanged);
            // 
            // radioButton_TusPeriods2
            // 
            this.radioButton_TusPeriods2.AutoSize = true;
            this.radioButton_TusPeriods2.BackColor = System.Drawing.Color.Transparent;
            this.radioButton_TusPeriods2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radioButton_TusPeriods2.Location = new System.Drawing.Point(79, 7);
            this.radioButton_TusPeriods2.Name = "radioButton_TusPeriods2";
            this.radioButton_TusPeriods2.Size = new System.Drawing.Size(52, 17);
            this.radioButton_TusPeriods2.TabIndex = 10;
            this.radioButton_TusPeriods2.Text = "فترتان";
            this.radioButton_TusPeriods2.UseVisualStyleBackColor = false;
            this.radioButton_TusPeriods2.CheckedChanged += new System.EventHandler(this.radioButton_TusPeriods2_CheckedChanged);
            // 
            // radioButton_TusPeriods1
            // 
            this.radioButton_TusPeriods1.AutoSize = true;
            this.radioButton_TusPeriods1.BackColor = System.Drawing.Color.Transparent;
            this.radioButton_TusPeriods1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radioButton_TusPeriods1.Location = new System.Drawing.Point(154, 7);
            this.radioButton_TusPeriods1.Name = "radioButton_TusPeriods1";
            this.radioButton_TusPeriods1.Size = new System.Drawing.Size(53, 17);
            this.radioButton_TusPeriods1.TabIndex = 9;
            this.radioButton_TusPeriods1.Text = "فتـــرة";
            this.radioButton_TusPeriods1.UseVisualStyleBackColor = false;
            this.radioButton_TusPeriods1.CheckedChanged += new System.EventHandler(this.radioButton_TusPeriods1_CheckedChanged);
            // 
            // expandablePanel_Mon
            // 
            this.expandablePanel_Mon.CanvasColor = System.Drawing.SystemColors.Control;
            this.expandablePanel_Mon.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.expandablePanel_Mon.Controls.Add(this.itemPanel3);
            this.expandablePanel_Mon.Dock = System.Windows.Forms.DockStyle.Top;
            this.expandablePanel_Mon.Expanded = false;
            this.expandablePanel_Mon.ExpandedBounds = new System.Drawing.Rectangle(0, 78, 222, 226);
            this.expandablePanel_Mon.ExpandOnTitleClick = true;
            this.expandablePanel_Mon.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.expandablePanel_Mon.Location = new System.Drawing.Point(0, 78);
            this.expandablePanel_Mon.Name = "expandablePanel_Mon";
            this.expandablePanel_Mon.Size = new System.Drawing.Size(222, 26);
            this.expandablePanel_Mon.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanel_Mon.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.expandablePanel_Mon.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.expandablePanel_Mon.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.expandablePanel_Mon.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.expandablePanel_Mon.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandablePanel_Mon.Style.GradientAngle = 90;
            this.expandablePanel_Mon.TabIndex = 5;
            this.expandablePanel_Mon.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandablePanel_Mon.TitleStyle.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.expandablePanel_Mon.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            this.expandablePanel_Mon.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandablePanel_Mon.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.expandablePanel_Mon.TitleStyle.GradientAngle = 90;
            this.expandablePanel_Mon.TitleStyle.MarginLeft = 12;
            this.expandablePanel_Mon.TitleText = "الإثنين";
            this.expandablePanel_Mon.ExpandedChanging += new DevComponents.DotNetBar.ExpandChangeEventHandler(this.expandablePanel_Sat_ExpandedChanging);
            // 
            // itemPanel3
            // 
            // 
            // 
            // 
            this.itemPanel3.BackgroundStyle.BackColor = System.Drawing.Color.AliceBlue;
            this.itemPanel3.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.itemPanel3.BackgroundStyle.BorderBottomWidth = 1;
            this.itemPanel3.BackgroundStyle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            this.itemPanel3.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.itemPanel3.BackgroundStyle.BorderLeftWidth = 1;
            this.itemPanel3.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.itemPanel3.BackgroundStyle.BorderRightWidth = 1;
            this.itemPanel3.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.itemPanel3.BackgroundStyle.BorderTopWidth = 1;
            this.itemPanel3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.itemPanel3.BackgroundStyle.PaddingBottom = 1;
            this.itemPanel3.BackgroundStyle.PaddingLeft = 1;
            this.itemPanel3.BackgroundStyle.PaddingRight = 1;
            this.itemPanel3.BackgroundStyle.PaddingTop = 1;
            this.itemPanel3.ContainerControlProcessDialogKey = true;
            this.itemPanel3.Controls.Add(this.groupPanel5);
            this.itemPanel3.Controls.Add(this.groupPanel6);
            this.itemPanel3.Controls.Add(this.radioButton_MonBreakDay);
            this.itemPanel3.Controls.Add(this.radioButton_MonPeriods2);
            this.itemPanel3.Controls.Add(this.radioButton_MonPeriods1);
            this.itemPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.itemPanel3.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.itemPanel3.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.itemPanel3.Location = new System.Drawing.Point(0, 26);
            this.itemPanel3.Name = "itemPanel3";
            this.itemPanel3.Size = new System.Drawing.Size(222, 0);
            this.itemPanel3.TabIndex = 3;
            this.itemPanel3.Text = "itemPanel3";
            // 
            // groupPanel5
            // 
            this.groupPanel5.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel5.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel5.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel5.Controls.Add(this.textBox_MonLeaveTime2);
            this.groupPanel5.Controls.Add(this.label29);
            this.groupPanel5.Controls.Add(this.textBox_MonTimeAllow2);
            this.groupPanel5.Controls.Add(this.label30);
            this.groupPanel5.Controls.Add(this.textBox_MonTime2);
            this.groupPanel5.Controls.Add(this.label31);
            this.groupPanel5.Location = new System.Drawing.Point(11, 114);
            this.groupPanel5.Name = "groupPanel5";
            this.groupPanel5.Size = new System.Drawing.Size(200, 79);
            // 
            // 
            // 
            this.groupPanel5.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel5.Style.BackColorGradientAngle = 90;
            this.groupPanel5.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.MenuBackground;
            this.groupPanel5.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel5.Style.BorderBottomWidth = 1;
            this.groupPanel5.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel5.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel5.Style.BorderLeftWidth = 1;
            this.groupPanel5.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel5.Style.BorderRightWidth = 1;
            this.groupPanel5.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel5.Style.BorderTopWidth = 1;
            this.groupPanel5.Style.CornerDiameter = 4;
            this.groupPanel5.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel5.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel5.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel5.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel5.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel5.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel5.TabIndex = 13;
            this.groupPanel5.Text = "الفترة الثانية";
            // 
            // textBox_MonLeaveTime2
            // 
            this.textBox_MonLeaveTime2.Location = new System.Drawing.Point(5, 32);
            this.textBox_MonLeaveTime2.Mask = "##:##";
            this.textBox_MonLeaveTime2.Name = "textBox_MonLeaveTime2";
            this.textBox_MonLeaveTime2.Size = new System.Drawing.Size(47, 21);
            this.textBox_MonLeaveTime2.TabIndex = 136;
            this.textBox_MonLeaveTime2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_MonLeaveTime2.Click += new System.EventHandler(this.textBox_MonLeaveTime2_Click);
            this.textBox_MonLeaveTime2.Leave += new System.EventHandler(this.textBox_MonLeaveTime2_Leave);
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.BackColor = System.Drawing.Color.Transparent;
            this.label29.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label29.Location = new System.Drawing.Point(54, 36);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(54, 13);
            this.label29.TabIndex = 135;
            this.label29.Text = "الانصراف :";
            // 
            // textBox_MonTimeAllow2
            // 
            this.textBox_MonTimeAllow2.Location = new System.Drawing.Point(5, 5);
            this.textBox_MonTimeAllow2.Mask = "##:##";
            this.textBox_MonTimeAllow2.Name = "textBox_MonTimeAllow2";
            this.textBox_MonTimeAllow2.Size = new System.Drawing.Size(47, 21);
            this.textBox_MonTimeAllow2.TabIndex = 134;
            this.textBox_MonTimeAllow2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_MonTimeAllow2.Click += new System.EventHandler(this.textBox_MonTimeAllow2_Click);
            this.textBox_MonTimeAllow2.Leave += new System.EventHandler(this.textBox_MonTimeAllow2_Leave);
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.BackColor = System.Drawing.Color.Transparent;
            this.label30.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label30.Location = new System.Drawing.Point(54, 9);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(36, 13);
            this.label30.TabIndex = 133;
            this.label30.Text = "حتى :";
            // 
            // textBox_MonTime2
            // 
            this.textBox_MonTime2.Location = new System.Drawing.Point(101, 4);
            this.textBox_MonTime2.Mask = "##:##";
            this.textBox_MonTime2.Name = "textBox_MonTime2";
            this.textBox_MonTime2.Size = new System.Drawing.Size(47, 21);
            this.textBox_MonTime2.TabIndex = 130;
            this.textBox_MonTime2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_MonTime2.Click += new System.EventHandler(this.textBox_MonTime2_Click);
            this.textBox_MonTime2.TextChanged += new System.EventHandler(this.textBox_MonTime2_TextChanged);
            this.textBox_MonTime2.Leave += new System.EventHandler(this.textBox_MonTime2_Leave);
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.BackColor = System.Drawing.Color.Transparent;
            this.label31.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label31.Location = new System.Drawing.Point(149, 8);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(39, 13);
            this.label31.TabIndex = 129;
            this.label31.Text = "حضور :";
            // 
            // groupPanel6
            // 
            this.groupPanel6.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel6.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel6.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel6.Controls.Add(this.textBox_MonLeaveTime1);
            this.groupPanel6.Controls.Add(this.label32);
            this.groupPanel6.Controls.Add(this.textBox_MonTimeAllow1);
            this.groupPanel6.Controls.Add(this.label33);
            this.groupPanel6.Controls.Add(this.textBox_MonTime1);
            this.groupPanel6.Controls.Add(this.label34);
            this.groupPanel6.Location = new System.Drawing.Point(11, 30);
            this.groupPanel6.Name = "groupPanel6";
            this.groupPanel6.Size = new System.Drawing.Size(200, 79);
            // 
            // 
            // 
            this.groupPanel6.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel6.Style.BackColorGradientAngle = 90;
            this.groupPanel6.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.MenuBackground;
            this.groupPanel6.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel6.Style.BorderBottomWidth = 1;
            this.groupPanel6.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel6.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel6.Style.BorderLeftWidth = 1;
            this.groupPanel6.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel6.Style.BorderRightWidth = 1;
            this.groupPanel6.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel6.Style.BorderTopWidth = 1;
            this.groupPanel6.Style.CornerDiameter = 4;
            this.groupPanel6.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel6.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel6.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel6.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel6.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel6.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel6.TabIndex = 12;
            this.groupPanel6.Text = "الفترة الاولى";
            // 
            // textBox_MonLeaveTime1
            // 
            this.textBox_MonLeaveTime1.Location = new System.Drawing.Point(5, 32);
            this.textBox_MonLeaveTime1.Mask = "##:##";
            this.textBox_MonLeaveTime1.Name = "textBox_MonLeaveTime1";
            this.textBox_MonLeaveTime1.Size = new System.Drawing.Size(47, 21);
            this.textBox_MonLeaveTime1.TabIndex = 136;
            this.textBox_MonLeaveTime1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_MonLeaveTime1.Click += new System.EventHandler(this.textBox_MonLeaveTime1_Click);
            this.textBox_MonLeaveTime1.Leave += new System.EventHandler(this.textBox_MonLeaveTime1_Leave);
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.BackColor = System.Drawing.Color.Transparent;
            this.label32.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label32.Location = new System.Drawing.Point(53, 36);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(54, 13);
            this.label32.TabIndex = 135;
            this.label32.Text = "الانصراف :";
            // 
            // textBox_MonTimeAllow1
            // 
            this.textBox_MonTimeAllow1.Location = new System.Drawing.Point(5, 5);
            this.textBox_MonTimeAllow1.Mask = "##:##";
            this.textBox_MonTimeAllow1.Name = "textBox_MonTimeAllow1";
            this.textBox_MonTimeAllow1.Size = new System.Drawing.Size(47, 21);
            this.textBox_MonTimeAllow1.TabIndex = 134;
            this.textBox_MonTimeAllow1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_MonTimeAllow1.Click += new System.EventHandler(this.textBox_MonTimeAllow1_Click);
            this.textBox_MonTimeAllow1.Leave += new System.EventHandler(this.textBox_MonTimeAllow1_Leave);
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.BackColor = System.Drawing.Color.Transparent;
            this.label33.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label33.Location = new System.Drawing.Point(53, 9);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(36, 13);
            this.label33.TabIndex = 133;
            this.label33.Text = "حتى :";
            // 
            // textBox_MonTime1
            // 
            this.textBox_MonTime1.Location = new System.Drawing.Point(101, 4);
            this.textBox_MonTime1.Mask = "##:##";
            this.textBox_MonTime1.Name = "textBox_MonTime1";
            this.textBox_MonTime1.Size = new System.Drawing.Size(47, 21);
            this.textBox_MonTime1.TabIndex = 130;
            this.textBox_MonTime1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_MonTime1.Click += new System.EventHandler(this.textBox_MonTime1_Click);
            this.textBox_MonTime1.TextChanged += new System.EventHandler(this.textBox_MonTime1_TextChanged);
            this.textBox_MonTime1.Leave += new System.EventHandler(this.textBox_MonTime1_Leave);
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.BackColor = System.Drawing.Color.Transparent;
            this.label34.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label34.Location = new System.Drawing.Point(149, 8);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(39, 13);
            this.label34.TabIndex = 129;
            this.label34.Text = "حضور :";
            // 
            // radioButton_MonBreakDay
            // 
            this.radioButton_MonBreakDay.AutoSize = true;
            this.radioButton_MonBreakDay.BackColor = System.Drawing.Color.Transparent;
            this.radioButton_MonBreakDay.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radioButton_MonBreakDay.Location = new System.Drawing.Point(11, 7);
            this.radioButton_MonBreakDay.Name = "radioButton_MonBreakDay";
            this.radioButton_MonBreakDay.Size = new System.Drawing.Size(45, 17);
            this.radioButton_MonBreakDay.TabIndex = 11;
            this.radioButton_MonBreakDay.Text = "راحة";
            this.radioButton_MonBreakDay.UseVisualStyleBackColor = false;
            this.radioButton_MonBreakDay.CheckedChanged += new System.EventHandler(this.radioButton_MonBreakDay_CheckedChanged);
            // 
            // radioButton_MonPeriods2
            // 
            this.radioButton_MonPeriods2.AutoSize = true;
            this.radioButton_MonPeriods2.BackColor = System.Drawing.Color.Transparent;
            this.radioButton_MonPeriods2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radioButton_MonPeriods2.Location = new System.Drawing.Point(79, 7);
            this.radioButton_MonPeriods2.Name = "radioButton_MonPeriods2";
            this.radioButton_MonPeriods2.Size = new System.Drawing.Size(52, 17);
            this.radioButton_MonPeriods2.TabIndex = 10;
            this.radioButton_MonPeriods2.Text = "فترتان";
            this.radioButton_MonPeriods2.UseVisualStyleBackColor = false;
            this.radioButton_MonPeriods2.CheckedChanged += new System.EventHandler(this.radioButton_MonPeriods2_CheckedChanged);
            // 
            // radioButton_MonPeriods1
            // 
            this.radioButton_MonPeriods1.AutoSize = true;
            this.radioButton_MonPeriods1.BackColor = System.Drawing.Color.Transparent;
            this.radioButton_MonPeriods1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radioButton_MonPeriods1.Location = new System.Drawing.Point(154, 7);
            this.radioButton_MonPeriods1.Name = "radioButton_MonPeriods1";
            this.radioButton_MonPeriods1.Size = new System.Drawing.Size(53, 17);
            this.radioButton_MonPeriods1.TabIndex = 9;
            this.radioButton_MonPeriods1.Text = "فتـــرة";
            this.radioButton_MonPeriods1.UseVisualStyleBackColor = false;
            this.radioButton_MonPeriods1.CheckedChanged += new System.EventHandler(this.radioButton_MonPeriods1_CheckedChanged);
            // 
            // expandablePanel_Sun
            // 
            this.expandablePanel_Sun.CanvasColor = System.Drawing.SystemColors.Control;
            this.expandablePanel_Sun.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.expandablePanel_Sun.Controls.Add(this.itemPanel2);
            this.expandablePanel_Sun.Dock = System.Windows.Forms.DockStyle.Top;
            this.expandablePanel_Sun.Expanded = false;
            this.expandablePanel_Sun.ExpandedBounds = new System.Drawing.Rectangle(0, 52, 222, 226);
            this.expandablePanel_Sun.ExpandOnTitleClick = true;
            this.expandablePanel_Sun.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.expandablePanel_Sun.Location = new System.Drawing.Point(0, 52);
            this.expandablePanel_Sun.Name = "expandablePanel_Sun";
            this.expandablePanel_Sun.Size = new System.Drawing.Size(222, 26);
            this.expandablePanel_Sun.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanel_Sun.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.expandablePanel_Sun.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.expandablePanel_Sun.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.expandablePanel_Sun.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.expandablePanel_Sun.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandablePanel_Sun.Style.GradientAngle = 90;
            this.expandablePanel_Sun.TabIndex = 4;
            this.expandablePanel_Sun.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandablePanel_Sun.TitleStyle.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.expandablePanel_Sun.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            this.expandablePanel_Sun.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandablePanel_Sun.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.expandablePanel_Sun.TitleStyle.GradientAngle = 90;
            this.expandablePanel_Sun.TitleStyle.MarginLeft = 12;
            this.expandablePanel_Sun.TitleText = "الأحد";
            this.expandablePanel_Sun.ExpandedChanging += new DevComponents.DotNetBar.ExpandChangeEventHandler(this.expandablePanel_Sat_ExpandedChanging);
            // 
            // itemPanel2
            // 
            // 
            // 
            // 
            this.itemPanel2.BackgroundStyle.BackColor = System.Drawing.Color.AliceBlue;
            this.itemPanel2.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.itemPanel2.BackgroundStyle.BorderBottomWidth = 1;
            this.itemPanel2.BackgroundStyle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            this.itemPanel2.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.itemPanel2.BackgroundStyle.BorderLeftWidth = 1;
            this.itemPanel2.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.itemPanel2.BackgroundStyle.BorderRightWidth = 1;
            this.itemPanel2.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.itemPanel2.BackgroundStyle.BorderTopWidth = 1;
            this.itemPanel2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.itemPanel2.BackgroundStyle.PaddingBottom = 1;
            this.itemPanel2.BackgroundStyle.PaddingLeft = 1;
            this.itemPanel2.BackgroundStyle.PaddingRight = 1;
            this.itemPanel2.BackgroundStyle.PaddingTop = 1;
            this.itemPanel2.ContainerControlProcessDialogKey = true;
            this.itemPanel2.Controls.Add(this.groupPanel3);
            this.itemPanel2.Controls.Add(this.groupPanel4);
            this.itemPanel2.Controls.Add(this.radioButton_SunBreakDay);
            this.itemPanel2.Controls.Add(this.radioButton_SunPeriods2);
            this.itemPanel2.Controls.Add(this.radioButton_SunPeriods1);
            this.itemPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.itemPanel2.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.itemPanel2.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.itemPanel2.Location = new System.Drawing.Point(0, 26);
            this.itemPanel2.Name = "itemPanel2";
            this.itemPanel2.Size = new System.Drawing.Size(222, 0);
            this.itemPanel2.TabIndex = 3;
            this.itemPanel2.Text = "itemPanel2";
            // 
            // groupPanel3
            // 
            this.groupPanel3.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel3.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel3.Controls.Add(this.textBox_SunLeaveTime2);
            this.groupPanel3.Controls.Add(this.label23);
            this.groupPanel3.Controls.Add(this.textBox_SunTimeAllow2);
            this.groupPanel3.Controls.Add(this.label24);
            this.groupPanel3.Controls.Add(this.textBox_SunTime2);
            this.groupPanel3.Controls.Add(this.label25);
            this.groupPanel3.Location = new System.Drawing.Point(11, 114);
            this.groupPanel3.Name = "groupPanel3";
            this.groupPanel3.Size = new System.Drawing.Size(200, 79);
            // 
            // 
            // 
            this.groupPanel3.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel3.Style.BackColorGradientAngle = 90;
            this.groupPanel3.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.MenuBackground;
            this.groupPanel3.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderBottomWidth = 1;
            this.groupPanel3.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel3.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderLeftWidth = 1;
            this.groupPanel3.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderRightWidth = 1;
            this.groupPanel3.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderTopWidth = 1;
            this.groupPanel3.Style.CornerDiameter = 4;
            this.groupPanel3.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel3.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel3.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel3.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel3.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel3.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel3.TabIndex = 13;
            this.groupPanel3.Text = "الفترة الثانية";
            // 
            // textBox_SunLeaveTime2
            // 
            this.textBox_SunLeaveTime2.Location = new System.Drawing.Point(5, 32);
            this.textBox_SunLeaveTime2.Mask = "##:##";
            this.textBox_SunLeaveTime2.Name = "textBox_SunLeaveTime2";
            this.textBox_SunLeaveTime2.Size = new System.Drawing.Size(47, 21);
            this.textBox_SunLeaveTime2.TabIndex = 136;
            this.textBox_SunLeaveTime2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_SunLeaveTime2.Click += new System.EventHandler(this.textBox_SunLeaveTime2_Click);
            this.textBox_SunLeaveTime2.Leave += new System.EventHandler(this.textBox_SunLeaveTime2_Leave);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.BackColor = System.Drawing.Color.Transparent;
            this.label23.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label23.Location = new System.Drawing.Point(54, 36);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(54, 13);
            this.label23.TabIndex = 135;
            this.label23.Text = "الانصراف :";
            // 
            // textBox_SunTimeAllow2
            // 
            this.textBox_SunTimeAllow2.Location = new System.Drawing.Point(5, 5);
            this.textBox_SunTimeAllow2.Mask = "##:##";
            this.textBox_SunTimeAllow2.Name = "textBox_SunTimeAllow2";
            this.textBox_SunTimeAllow2.Size = new System.Drawing.Size(47, 21);
            this.textBox_SunTimeAllow2.TabIndex = 134;
            this.textBox_SunTimeAllow2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_SunTimeAllow2.Click += new System.EventHandler(this.textBox_SunTimeAllow2_Click);
            this.textBox_SunTimeAllow2.Leave += new System.EventHandler(this.textBox_SunTimeAllow2_Leave);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.BackColor = System.Drawing.Color.Transparent;
            this.label24.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label24.Location = new System.Drawing.Point(54, 9);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(36, 13);
            this.label24.TabIndex = 133;
            this.label24.Text = "حتى :";
            // 
            // textBox_SunTime2
            // 
            this.textBox_SunTime2.Location = new System.Drawing.Point(101, 4);
            this.textBox_SunTime2.Mask = "##:##";
            this.textBox_SunTime2.Name = "textBox_SunTime2";
            this.textBox_SunTime2.Size = new System.Drawing.Size(47, 21);
            this.textBox_SunTime2.TabIndex = 130;
            this.textBox_SunTime2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_SunTime2.Click += new System.EventHandler(this.textBox_SunTime2_Click);
            this.textBox_SunTime2.TextChanged += new System.EventHandler(this.textBox_SunTime2_TextChanged);
            this.textBox_SunTime2.Leave += new System.EventHandler(this.textBox_SunTime2_Leave);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.BackColor = System.Drawing.Color.Transparent;
            this.label25.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label25.Location = new System.Drawing.Point(149, 8);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(39, 13);
            this.label25.TabIndex = 129;
            this.label25.Text = "حضور :";
            // 
            // groupPanel4
            // 
            this.groupPanel4.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel4.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel4.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel4.Controls.Add(this.textBox_SunLeaveTime1);
            this.groupPanel4.Controls.Add(this.label26);
            this.groupPanel4.Controls.Add(this.textBox_SunTimeAllow1);
            this.groupPanel4.Controls.Add(this.label27);
            this.groupPanel4.Controls.Add(this.textBox_SunTime1);
            this.groupPanel4.Controls.Add(this.label28);
            this.groupPanel4.Location = new System.Drawing.Point(11, 30);
            this.groupPanel4.Name = "groupPanel4";
            this.groupPanel4.Size = new System.Drawing.Size(200, 79);
            // 
            // 
            // 
            this.groupPanel4.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel4.Style.BackColorGradientAngle = 90;
            this.groupPanel4.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.MenuBackground;
            this.groupPanel4.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel4.Style.BorderBottomWidth = 1;
            this.groupPanel4.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel4.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel4.Style.BorderLeftWidth = 1;
            this.groupPanel4.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel4.Style.BorderRightWidth = 1;
            this.groupPanel4.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel4.Style.BorderTopWidth = 1;
            this.groupPanel4.Style.CornerDiameter = 4;
            this.groupPanel4.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel4.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel4.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel4.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel4.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel4.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel4.TabIndex = 12;
            this.groupPanel4.Text = "الفترة الاولى";
            // 
            // textBox_SunLeaveTime1
            // 
            this.textBox_SunLeaveTime1.Location = new System.Drawing.Point(5, 32);
            this.textBox_SunLeaveTime1.Mask = "##:##";
            this.textBox_SunLeaveTime1.Name = "textBox_SunLeaveTime1";
            this.textBox_SunLeaveTime1.Size = new System.Drawing.Size(47, 21);
            this.textBox_SunLeaveTime1.TabIndex = 136;
            this.textBox_SunLeaveTime1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_SunLeaveTime1.Click += new System.EventHandler(this.textBox_SunLeaveTime1_Click);
            this.textBox_SunLeaveTime1.Leave += new System.EventHandler(this.textBox_SunLeaveTime1_Leave);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.BackColor = System.Drawing.Color.Transparent;
            this.label26.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label26.Location = new System.Drawing.Point(53, 36);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(54, 13);
            this.label26.TabIndex = 135;
            this.label26.Text = "الانصراف :";
            // 
            // textBox_SunTimeAllow1
            // 
            this.textBox_SunTimeAllow1.Location = new System.Drawing.Point(5, 5);
            this.textBox_SunTimeAllow1.Mask = "##:##";
            this.textBox_SunTimeAllow1.Name = "textBox_SunTimeAllow1";
            this.textBox_SunTimeAllow1.Size = new System.Drawing.Size(47, 21);
            this.textBox_SunTimeAllow1.TabIndex = 134;
            this.textBox_SunTimeAllow1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_SunTimeAllow1.Click += new System.EventHandler(this.textBox_SunTimeAllow1_Click);
            this.textBox_SunTimeAllow1.Leave += new System.EventHandler(this.textBox_SunTimeAllow1_Leave);
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.BackColor = System.Drawing.Color.Transparent;
            this.label27.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label27.Location = new System.Drawing.Point(53, 9);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(36, 13);
            this.label27.TabIndex = 133;
            this.label27.Text = "حتى :";
            // 
            // textBox_SunTime1
            // 
            this.textBox_SunTime1.Location = new System.Drawing.Point(101, 4);
            this.textBox_SunTime1.Mask = "##:##";
            this.textBox_SunTime1.Name = "textBox_SunTime1";
            this.textBox_SunTime1.Size = new System.Drawing.Size(47, 21);
            this.textBox_SunTime1.TabIndex = 130;
            this.textBox_SunTime1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_SunTime1.Click += new System.EventHandler(this.textBox_SunTime1_Click);
            this.textBox_SunTime1.TextChanged += new System.EventHandler(this.textBox_SunTime1_TextChanged);
            this.textBox_SunTime1.Leave += new System.EventHandler(this.textBox_SunTime1_Leave);
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.BackColor = System.Drawing.Color.Transparent;
            this.label28.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label28.Location = new System.Drawing.Point(149, 8);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(39, 13);
            this.label28.TabIndex = 129;
            this.label28.Text = "حضور :";
            // 
            // radioButton_SunBreakDay
            // 
            this.radioButton_SunBreakDay.AutoSize = true;
            this.radioButton_SunBreakDay.BackColor = System.Drawing.Color.Transparent;
            this.radioButton_SunBreakDay.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radioButton_SunBreakDay.Location = new System.Drawing.Point(11, 7);
            this.radioButton_SunBreakDay.Name = "radioButton_SunBreakDay";
            this.radioButton_SunBreakDay.Size = new System.Drawing.Size(45, 17);
            this.radioButton_SunBreakDay.TabIndex = 11;
            this.radioButton_SunBreakDay.Text = "راحة";
            this.radioButton_SunBreakDay.UseVisualStyleBackColor = false;
            this.radioButton_SunBreakDay.CheckedChanged += new System.EventHandler(this.radioButton_SunBreakDay_CheckedChanged);
            // 
            // radioButton_SunPeriods2
            // 
            this.radioButton_SunPeriods2.AutoSize = true;
            this.radioButton_SunPeriods2.BackColor = System.Drawing.Color.Transparent;
            this.radioButton_SunPeriods2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radioButton_SunPeriods2.Location = new System.Drawing.Point(79, 7);
            this.radioButton_SunPeriods2.Name = "radioButton_SunPeriods2";
            this.radioButton_SunPeriods2.Size = new System.Drawing.Size(52, 17);
            this.radioButton_SunPeriods2.TabIndex = 10;
            this.radioButton_SunPeriods2.Text = "فترتان";
            this.radioButton_SunPeriods2.UseVisualStyleBackColor = false;
            this.radioButton_SunPeriods2.CheckedChanged += new System.EventHandler(this.radioButton_SunPeriods2_CheckedChanged);
            // 
            // radioButton_SunPeriods1
            // 
            this.radioButton_SunPeriods1.AutoSize = true;
            this.radioButton_SunPeriods1.BackColor = System.Drawing.Color.Transparent;
            this.radioButton_SunPeriods1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radioButton_SunPeriods1.Location = new System.Drawing.Point(154, 7);
            this.radioButton_SunPeriods1.Name = "radioButton_SunPeriods1";
            this.radioButton_SunPeriods1.Size = new System.Drawing.Size(53, 17);
            this.radioButton_SunPeriods1.TabIndex = 9;
            this.radioButton_SunPeriods1.Text = "فتـــرة";
            this.radioButton_SunPeriods1.UseVisualStyleBackColor = false;
            this.radioButton_SunPeriods1.CheckedChanged += new System.EventHandler(this.radioButton_SunPeriods1_CheckedChanged);
            // 
            // expandablePanel_Sat
            // 
            this.expandablePanel_Sat.CanvasColor = System.Drawing.SystemColors.Control;
            this.expandablePanel_Sat.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.expandablePanel_Sat.Controls.Add(this.itemPanel1);
            this.expandablePanel_Sat.Dock = System.Windows.Forms.DockStyle.Top;
            this.expandablePanel_Sat.Expanded = false;
            this.expandablePanel_Sat.ExpandedBounds = new System.Drawing.Rectangle(0, 26, 222, 226);
            this.expandablePanel_Sat.ExpandOnTitleClick = true;
            this.expandablePanel_Sat.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.expandablePanel_Sat.Location = new System.Drawing.Point(0, 26);
            this.expandablePanel_Sat.Name = "expandablePanel_Sat";
            this.expandablePanel_Sat.Size = new System.Drawing.Size(222, 26);
            this.expandablePanel_Sat.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanel_Sat.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.expandablePanel_Sat.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.expandablePanel_Sat.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.expandablePanel_Sat.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.expandablePanel_Sat.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandablePanel_Sat.Style.GradientAngle = 90;
            this.expandablePanel_Sat.TabIndex = 3;
            this.expandablePanel_Sat.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandablePanel_Sat.TitleStyle.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.expandablePanel_Sat.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            this.expandablePanel_Sat.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandablePanel_Sat.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.expandablePanel_Sat.TitleStyle.GradientAngle = 90;
            this.expandablePanel_Sat.TitleStyle.MarginLeft = 12;
            this.expandablePanel_Sat.TitleText = "السبت";
            this.expandablePanel_Sat.ExpandedChanging += new DevComponents.DotNetBar.ExpandChangeEventHandler(this.expandablePanel_Sat_ExpandedChanging);
            // 
            // itemPanel1
            // 
            // 
            // 
            // 
            this.itemPanel1.BackgroundStyle.BackColor = System.Drawing.Color.AliceBlue;
            this.itemPanel1.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.itemPanel1.BackgroundStyle.BorderBottomWidth = 1;
            this.itemPanel1.BackgroundStyle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            this.itemPanel1.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.itemPanel1.BackgroundStyle.BorderLeftWidth = 1;
            this.itemPanel1.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.itemPanel1.BackgroundStyle.BorderRightWidth = 1;
            this.itemPanel1.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.itemPanel1.BackgroundStyle.BorderTopWidth = 1;
            this.itemPanel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.itemPanel1.BackgroundStyle.PaddingBottom = 1;
            this.itemPanel1.BackgroundStyle.PaddingLeft = 1;
            this.itemPanel1.BackgroundStyle.PaddingRight = 1;
            this.itemPanel1.BackgroundStyle.PaddingTop = 1;
            this.itemPanel1.ContainerControlProcessDialogKey = true;
            this.itemPanel1.Controls.Add(this.groupPanel2);
            this.itemPanel1.Controls.Add(this.groupPanel1);
            this.itemPanel1.Controls.Add(this.radioButton_SatBreakDay);
            this.itemPanel1.Controls.Add(this.radioButton_SatPeriods2);
            this.itemPanel1.Controls.Add(this.radioButton_SatPeriods1);
            this.itemPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.itemPanel1.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.itemPanel1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.itemPanel1.Location = new System.Drawing.Point(0, 26);
            this.itemPanel1.Name = "itemPanel1";
            this.itemPanel1.Size = new System.Drawing.Size(222, 0);
            this.itemPanel1.TabIndex = 3;
            this.itemPanel1.Text = "itemPanel1";
            // 
            // groupPanel2
            // 
            this.groupPanel2.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.textBox_SatLeaveTime2);
            this.groupPanel2.Controls.Add(this.label20);
            this.groupPanel2.Controls.Add(this.textBox_SatTimeAllow2);
            this.groupPanel2.Controls.Add(this.label21);
            this.groupPanel2.Controls.Add(this.textBox_SatTime2);
            this.groupPanel2.Controls.Add(this.label22);
            this.groupPanel2.Location = new System.Drawing.Point(11, 116);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(200, 79);
            // 
            // 
            // 
            this.groupPanel2.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel2.Style.BackColorGradientAngle = 90;
            this.groupPanel2.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.MenuBackground;
            this.groupPanel2.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderBottomWidth = 1;
            this.groupPanel2.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel2.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderLeftWidth = 1;
            this.groupPanel2.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderRightWidth = 1;
            this.groupPanel2.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderTopWidth = 1;
            this.groupPanel2.Style.CornerDiameter = 4;
            this.groupPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel2.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel2.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel2.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel2.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel2.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel2.TabIndex = 8;
            this.groupPanel2.Text = "الفترة الثانية";
            // 
            // textBox_SatLeaveTime2
            // 
            this.textBox_SatLeaveTime2.Location = new System.Drawing.Point(5, 32);
            this.textBox_SatLeaveTime2.Mask = "##:##";
            this.textBox_SatLeaveTime2.Name = "textBox_SatLeaveTime2";
            this.textBox_SatLeaveTime2.Size = new System.Drawing.Size(47, 21);
            this.textBox_SatLeaveTime2.TabIndex = 136;
            this.textBox_SatLeaveTime2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_SatLeaveTime2.Click += new System.EventHandler(this.textBox_SatLeaveTime2_Click);
            this.textBox_SatLeaveTime2.Leave += new System.EventHandler(this.textBox_SatLeaveTime2_Leave);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.Transparent;
            this.label20.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label20.Location = new System.Drawing.Point(54, 36);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(54, 13);
            this.label20.TabIndex = 135;
            this.label20.Text = "الانصراف :";
            // 
            // textBox_SatTimeAllow2
            // 
            this.textBox_SatTimeAllow2.Location = new System.Drawing.Point(5, 5);
            this.textBox_SatTimeAllow2.Mask = "##:##";
            this.textBox_SatTimeAllow2.Name = "textBox_SatTimeAllow2";
            this.textBox_SatTimeAllow2.Size = new System.Drawing.Size(47, 21);
            this.textBox_SatTimeAllow2.TabIndex = 134;
            this.textBox_SatTimeAllow2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_SatTimeAllow2.Click += new System.EventHandler(this.textBox_SatTimeAllow2_Click);
            this.textBox_SatTimeAllow2.Leave += new System.EventHandler(this.textBox_SatTimeAllow2_Leave);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.BackColor = System.Drawing.Color.Transparent;
            this.label21.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label21.Location = new System.Drawing.Point(54, 9);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(36, 13);
            this.label21.TabIndex = 133;
            this.label21.Text = "حتى :";
            // 
            // textBox_SatTime2
            // 
            this.textBox_SatTime2.Location = new System.Drawing.Point(101, 4);
            this.textBox_SatTime2.Mask = "##:##";
            this.textBox_SatTime2.Name = "textBox_SatTime2";
            this.textBox_SatTime2.Size = new System.Drawing.Size(47, 21);
            this.textBox_SatTime2.TabIndex = 130;
            this.textBox_SatTime2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_SatTime2.Click += new System.EventHandler(this.textBox_SatTime2_Click);
            this.textBox_SatTime2.TextChanged += new System.EventHandler(this.textBox_SatTime2_TextChanged);
            this.textBox_SatTime2.Leave += new System.EventHandler(this.textBox_SatTime2_Leave);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.BackColor = System.Drawing.Color.Transparent;
            this.label22.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label22.Location = new System.Drawing.Point(149, 8);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(39, 13);
            this.label22.TabIndex = 129;
            this.label22.Text = "حضور :";
            // 
            // groupPanel1
            // 
            this.groupPanel1.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.textBox_SatLeaveTime1);
            this.groupPanel1.Controls.Add(this.label19);
            this.groupPanel1.Controls.Add(this.textBox_SatTimeAllow1);
            this.groupPanel1.Controls.Add(this.label18);
            this.groupPanel1.Controls.Add(this.textBox_SatTime1);
            this.groupPanel1.Controls.Add(this.label14);
            this.groupPanel1.Location = new System.Drawing.Point(11, 32);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(200, 79);
            // 
            // 
            // 
            this.groupPanel1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel1.Style.BackColorGradientAngle = 90;
            this.groupPanel1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.MenuBackground;
            this.groupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderBottomWidth = 1;
            this.groupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderLeftWidth = 1;
            this.groupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderRightWidth = 1;
            this.groupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderTopWidth = 1;
            this.groupPanel1.Style.CornerDiameter = 4;
            this.groupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel1.TabIndex = 7;
            this.groupPanel1.Text = "الفترة الاولى";
            // 
            // textBox_SatLeaveTime1
            // 
            this.textBox_SatLeaveTime1.Location = new System.Drawing.Point(5, 32);
            this.textBox_SatLeaveTime1.Mask = "##:##";
            this.textBox_SatLeaveTime1.Name = "textBox_SatLeaveTime1";
            this.textBox_SatLeaveTime1.Size = new System.Drawing.Size(47, 21);
            this.textBox_SatLeaveTime1.TabIndex = 136;
            this.textBox_SatLeaveTime1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_SatLeaveTime1.Click += new System.EventHandler(this.textBox_SatLeaveTime1_Click);
            this.textBox_SatLeaveTime1.Leave += new System.EventHandler(this.textBox_SatLeaveTime1_Leave);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.Color.Transparent;
            this.label19.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label19.Location = new System.Drawing.Point(53, 36);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(54, 13);
            this.label19.TabIndex = 135;
            this.label19.Text = "الانصراف :";
            // 
            // textBox_SatTimeAllow1
            // 
            this.textBox_SatTimeAllow1.Location = new System.Drawing.Point(5, 5);
            this.textBox_SatTimeAllow1.Mask = "##:##";
            this.textBox_SatTimeAllow1.Name = "textBox_SatTimeAllow1";
            this.textBox_SatTimeAllow1.Size = new System.Drawing.Size(47, 21);
            this.textBox_SatTimeAllow1.TabIndex = 134;
            this.textBox_SatTimeAllow1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_SatTimeAllow1.Click += new System.EventHandler(this.textBox_SatTimeAllow1_Click);
            this.textBox_SatTimeAllow1.Leave += new System.EventHandler(this.textBox_SatTimeAllow1_Leave);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.Transparent;
            this.label18.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label18.Location = new System.Drawing.Point(53, 9);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(36, 13);
            this.label18.TabIndex = 133;
            this.label18.Text = "حتى :";
            // 
            // textBox_SatTime1
            // 
            this.textBox_SatTime1.Location = new System.Drawing.Point(101, 4);
            this.textBox_SatTime1.Mask = "##:##";
            this.textBox_SatTime1.Name = "textBox_SatTime1";
            this.textBox_SatTime1.Size = new System.Drawing.Size(47, 21);
            this.textBox_SatTime1.TabIndex = 130;
            this.textBox_SatTime1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_SatTime1.Click += new System.EventHandler(this.textBox_SatTime1_Click);
            this.textBox_SatTime1.TextChanged += new System.EventHandler(this.textBox_SatTime1_TextChanged);
            this.textBox_SatTime1.Leave += new System.EventHandler(this.textBox_SatTime1_Leave);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label14.Location = new System.Drawing.Point(149, 8);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(39, 13);
            this.label14.TabIndex = 129;
            this.label14.Text = "حضور :";
            // 
            // radioButton_SatBreakDay
            // 
            this.radioButton_SatBreakDay.AutoSize = true;
            this.radioButton_SatBreakDay.BackColor = System.Drawing.Color.Transparent;
            this.radioButton_SatBreakDay.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radioButton_SatBreakDay.Location = new System.Drawing.Point(11, 9);
            this.radioButton_SatBreakDay.Name = "radioButton_SatBreakDay";
            this.radioButton_SatBreakDay.Size = new System.Drawing.Size(45, 17);
            this.radioButton_SatBreakDay.TabIndex = 6;
            this.radioButton_SatBreakDay.Text = "راحة";
            this.radioButton_SatBreakDay.UseVisualStyleBackColor = false;
            this.radioButton_SatBreakDay.CheckedChanged += new System.EventHandler(this.radioButton_SatBreakDay_CheckedChanged);
            // 
            // radioButton_SatPeriods2
            // 
            this.radioButton_SatPeriods2.AutoSize = true;
            this.radioButton_SatPeriods2.BackColor = System.Drawing.Color.Transparent;
            this.radioButton_SatPeriods2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radioButton_SatPeriods2.Location = new System.Drawing.Point(79, 9);
            this.radioButton_SatPeriods2.Name = "radioButton_SatPeriods2";
            this.radioButton_SatPeriods2.Size = new System.Drawing.Size(52, 17);
            this.radioButton_SatPeriods2.TabIndex = 5;
            this.radioButton_SatPeriods2.Text = "فترتان";
            this.radioButton_SatPeriods2.UseVisualStyleBackColor = false;
            this.radioButton_SatPeriods2.CheckedChanged += new System.EventHandler(this.radioButton_SatPeriods2_CheckedChanged);
            // 
            // radioButton_SatPeriods1
            // 
            this.radioButton_SatPeriods1.AutoSize = true;
            this.radioButton_SatPeriods1.BackColor = System.Drawing.Color.Transparent;
            this.radioButton_SatPeriods1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radioButton_SatPeriods1.Location = new System.Drawing.Point(154, 9);
            this.radioButton_SatPeriods1.Name = "radioButton_SatPeriods1";
            this.radioButton_SatPeriods1.Size = new System.Drawing.Size(53, 17);
            this.radioButton_SatPeriods1.TabIndex = 4;
            this.radioButton_SatPeriods1.Text = "فتـــرة";
            this.radioButton_SatPeriods1.UseVisualStyleBackColor = false;
            this.radioButton_SatPeriods1.CheckedChanged += new System.EventHandler(this.radioButton_SatPeriods1_CheckedChanged);
            // 
            // labelX19
            // 
            this.labelX19.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX19.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX19.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelX19.Location = new System.Drawing.Point(0, 0);
            this.labelX19.Name = "labelX19";
            this.labelX19.Size = new System.Drawing.Size(594, 419);
            this.labelX19.TabIndex = 8;
            this.labelX19.Text = "This space intentionally left blank.";
            this.labelX19.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // superTabItem_Acc
            // 
            this.superTabItem_Acc.AttachedControl = this.superTabControlPanel18;
            this.superTabItem_Acc.CloseButtonVisible = false;
            this.superTabItem_Acc.GlobalItem = false;
            this.superTabItem_Acc.Name = "superTabItem_Acc";
            this.superTabItem_Acc.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Green;
            this.superTabItem_Acc.Text = "الحسـابات";
            // 
            // superTabControlPanel17
            // 
            this.superTabControlPanel17.Controls.Add(this.panelEx4);
            this.superTabControlPanel17.Controls.Add(this.labelX18);
            this.superTabControlPanel17.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel17.Location = new System.Drawing.Point(0, 0);
            this.superTabControlPanel17.Name = "superTabControlPanel17";
            this.superTabControlPanel17.Size = new System.Drawing.Size(594, 419);
            this.superTabControlPanel17.TabIndex = 0;
            this.superTabControlPanel17.TabItem = this.superTabItem_Contract;
            // 
            // panelEx4
            // 
            this.panelEx4.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx4.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx4.Controls.Add(this.button_AddNewContract);
            this.panelEx4.Controls.Add(this.comboBox_CalculateNo);
            this.panelEx4.Controls.Add(this.label11);
            this.panelEx4.Controls.Add(this.comboBox_ContrTyp);
            this.panelEx4.Controls.Add(this.textBox_HousingAllowance);
            this.panelEx4.Controls.Add(this.textBox_TransferAllowance);
            this.panelEx4.Controls.Add(this.textBox_NaturalWorkAllowance);
            this.panelEx4.Controls.Add(this.textBox_OtherAllowance);
            this.panelEx4.Controls.Add(this.textBox_MainSal);
            this.panelEx4.Controls.Add(this.label130);
            this.panelEx4.Controls.Add(this.panel4);
            this.panelEx4.Controls.Add(this.label74);
            this.panelEx4.Controls.Add(this.label75);
            this.panelEx4.Controls.Add(this.label76);
            this.panelEx4.Controls.Add(this.label73);
            this.panelEx4.Controls.Add(this.label72);
            this.panelEx4.Controls.Add(this.label70);
            this.panelEx4.Controls.Add(this.textBox_SubsistenceAllowance);
            this.panelEx4.Controls.Add(this.line1);
            this.panelEx4.Controls.Add(this.comboBox_Allowances);
            this.panelEx4.Controls.Add(this.comboBox_AllowancesTime);
            this.panelEx4.Controls.Add(this.panel3);
            this.panelEx4.Controls.Add(this.comboBox_DirBoss);
            this.panelEx4.Controls.Add(this.button_AddNewBoss);
            this.panelEx4.Controls.Add(this.button_SrchBoss);
            this.panelEx4.Controls.Add(this.label10);
            this.panelEx4.Controls.Add(this.textBox_DayOfMonth);
            this.panelEx4.Controls.Add(this.groupBox4);
            this.panelEx4.Controls.Add(this.label137);
            this.panelEx4.Controls.Add(this.label140);
            this.panelEx4.Controls.Add(this.textBox_WorkHours);
            this.panelEx4.Controls.Add(this.label60);
            this.panelEx4.Controls.Add(this.label59);
            this.panelEx4.Controls.Add(this.label57);
            this.panelEx4.Controls.Add(this.groupBox5);
            this.panelEx4.Controls.Add(this.groupBox6);
            this.panelEx4.Controls.Add(this.groupBox7);
            this.panelEx4.Controls.Add(this.textBox_WorkNo);
            this.panelEx4.Controls.Add(this.checkBox_AutoReturnContr);
            this.panelEx4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx4.Location = new System.Drawing.Point(0, 0);
            this.panelEx4.Name = "panelEx4";
            this.panelEx4.Size = new System.Drawing.Size(594, 419);
            this.panelEx4.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx4.Style.BackColor1.Color = System.Drawing.Color.AliceBlue;
            this.panelEx4.Style.BackColor2.Color = System.Drawing.SystemColors.GradientActiveCaption;
            this.panelEx4.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx4.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx4.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx4.Style.GradientAngle = 90;
            this.panelEx4.TabIndex = 10;
            // 
            // button_AddNewContract
            // 
            this.button_AddNewContract.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_AddNewContract.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_AddNewContract.Location = new System.Drawing.Point(358, 19);
            this.button_AddNewContract.Name = "button_AddNewContract";
            this.button_AddNewContract.Size = new System.Drawing.Size(26, 20);
            this.button_AddNewContract.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_AddNewContract.Symbol = "";
            this.button_AddNewContract.SymbolSize = 11F;
            this.button_AddNewContract.TabIndex = 6780;
            this.button_AddNewContract.TextColor = System.Drawing.Color.SteelBlue;
            this.button_AddNewContract.Click += new System.EventHandler(this.button_AddNewContract_Click);
            // 
            // comboBox_CalculateNo
            // 
            this.comboBox_CalculateNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox_CalculateNo.DisplayMember = "Text";
            this.comboBox_CalculateNo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBox_CalculateNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_CalculateNo.FormattingEnabled = true;
            this.comboBox_CalculateNo.ItemHeight = 14;
            this.comboBox_CalculateNo.Location = new System.Drawing.Point(11, 277);
            this.comboBox_CalculateNo.Name = "comboBox_CalculateNo";
            this.comboBox_CalculateNo.Size = new System.Drawing.Size(569, 20);
            this.comboBox_CalculateNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBox_CalculateNo.TabIndex = 6778;
            this.comboBox_CalculateNo.SelectedValueChanged += new System.EventHandler(this.comboBox_CalculateNo_SelectedValueChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label11.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label11.Location = new System.Drawing.Point(175, 159);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(106, 13);
            this.label11.TabIndex = 6775;
            this.label11.Text = "التأمينـــات المستحقة";
            // 
            // comboBox_ContrTyp
            // 
            this.comboBox_ContrTyp.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox_ContrTyp.DisplayMember = "Text";
            this.comboBox_ContrTyp.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBox_ContrTyp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_ContrTyp.FormattingEnabled = true;
            this.comboBox_ContrTyp.ItemHeight = 14;
            this.comboBox_ContrTyp.Location = new System.Drawing.Point(385, 20);
            this.comboBox_ContrTyp.Name = "comboBox_ContrTyp";
            this.comboBox_ContrTyp.Size = new System.Drawing.Size(119, 20);
            this.comboBox_ContrTyp.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBox_ContrTyp.TabIndex = 6770;
            // 
            // textBox_HousingAllowance
            // 
            this.textBox_HousingAllowance.AllowEmptyState = false;
            // 
            // 
            // 
            this.textBox_HousingAllowance.BackgroundStyle.BackColor = System.Drawing.Color.AliceBlue;
            this.textBox_HousingAllowance.BackgroundStyle.Class = "DateTimeInputBackground";
            this.textBox_HousingAllowance.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBox_HousingAllowance.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.textBox_HousingAllowance.DisplayFormat = "0.00";
            this.textBox_HousingAllowance.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.textBox_HousingAllowance.Increment = 1D;
            this.textBox_HousingAllowance.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.textBox_HousingAllowance.Location = new System.Drawing.Point(452, 189);
            this.textBox_HousingAllowance.Name = "textBox_HousingAllowance";
            this.textBox_HousingAllowance.Size = new System.Drawing.Size(50, 21);
            this.textBox_HousingAllowance.TabIndex = 6756;
            this.textBox_HousingAllowance.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_HousingAllowance_KeyUp);
            // 
            // textBox_TransferAllowance
            // 
            this.textBox_TransferAllowance.AllowEmptyState = false;
            // 
            // 
            // 
            this.textBox_TransferAllowance.BackgroundStyle.BackColor = System.Drawing.Color.AliceBlue;
            this.textBox_TransferAllowance.BackgroundStyle.Class = "DateTimeInputBackground";
            this.textBox_TransferAllowance.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBox_TransferAllowance.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.textBox_TransferAllowance.DisplayFormat = "0.00";
            this.textBox_TransferAllowance.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.textBox_TransferAllowance.Increment = 1D;
            this.textBox_TransferAllowance.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.textBox_TransferAllowance.Location = new System.Drawing.Point(452, 214);
            this.textBox_TransferAllowance.Name = "textBox_TransferAllowance";
            this.textBox_TransferAllowance.Size = new System.Drawing.Size(50, 21);
            this.textBox_TransferAllowance.TabIndex = 6757;
            this.textBox_TransferAllowance.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_TransferAllowance_KeyUp);
            // 
            // textBox_NaturalWorkAllowance
            // 
            this.textBox_NaturalWorkAllowance.AllowEmptyState = false;
            // 
            // 
            // 
            this.textBox_NaturalWorkAllowance.BackgroundStyle.BackColor = System.Drawing.Color.AliceBlue;
            this.textBox_NaturalWorkAllowance.BackgroundStyle.Class = "DateTimeInputBackground";
            this.textBox_NaturalWorkAllowance.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBox_NaturalWorkAllowance.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.textBox_NaturalWorkAllowance.DisplayFormat = "0.00";
            this.textBox_NaturalWorkAllowance.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.textBox_NaturalWorkAllowance.Increment = 1D;
            this.textBox_NaturalWorkAllowance.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.textBox_NaturalWorkAllowance.Location = new System.Drawing.Point(303, 189);
            this.textBox_NaturalWorkAllowance.Name = "textBox_NaturalWorkAllowance";
            this.textBox_NaturalWorkAllowance.Size = new System.Drawing.Size(50, 21);
            this.textBox_NaturalWorkAllowance.TabIndex = 6759;
            this.textBox_NaturalWorkAllowance.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_NaturalWorkAllowance_KeyUp);
            // 
            // textBox_OtherAllowance
            // 
            this.textBox_OtherAllowance.AllowEmptyState = false;
            // 
            // 
            // 
            this.textBox_OtherAllowance.BackgroundStyle.BackColor = System.Drawing.Color.AliceBlue;
            this.textBox_OtherAllowance.BackgroundStyle.Class = "DateTimeInputBackground";
            this.textBox_OtherAllowance.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBox_OtherAllowance.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.textBox_OtherAllowance.DisplayFormat = "0.00";
            this.textBox_OtherAllowance.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.textBox_OtherAllowance.Increment = 1D;
            this.textBox_OtherAllowance.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.textBox_OtherAllowance.Location = new System.Drawing.Point(303, 214);
            this.textBox_OtherAllowance.Name = "textBox_OtherAllowance";
            this.textBox_OtherAllowance.Size = new System.Drawing.Size(50, 21);
            this.textBox_OtherAllowance.TabIndex = 6760;
            this.textBox_OtherAllowance.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_OtherAllowance_KeyUp);
            // 
            // textBox_MainSal
            // 
            this.textBox_MainSal.AllowEmptyState = false;
            // 
            // 
            // 
            this.textBox_MainSal.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(198)))));
            this.textBox_MainSal.BackgroundStyle.Class = "DateTimeInputBackground";
            this.textBox_MainSal.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBox_MainSal.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.textBox_MainSal.DisplayFormat = "0.00";
            this.textBox_MainSal.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.textBox_MainSal.Increment = 1D;
            this.textBox_MainSal.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.textBox_MainSal.Location = new System.Drawing.Point(452, 164);
            this.textBox_MainSal.Name = "textBox_MainSal";
            this.textBox_MainSal.Size = new System.Drawing.Size(50, 21);
            this.textBox_MainSal.TabIndex = 6755;
            this.textBox_MainSal.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_MainSal_KeyUp);
            // 
            // label130
            // 
            this.label130.BackColor = System.Drawing.SystemColors.Control;
            this.label130.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label130.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label130.ForeColor = System.Drawing.Color.SteelBlue;
            this.label130.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label130.Location = new System.Drawing.Point(11, 247);
            this.label130.Name = "label130";
            this.label130.Size = new System.Drawing.Size(569, 24);
            this.label130.TabIndex = 6769;
            this.label130.Text = "إحتساب المستحقات والمقطوعـــات من  :";
            this.label130.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.textBox_InsuranceMedicalCom);
            this.panel4.Controls.Add(this.textBox_SocialInsuranceComp);
            this.panel4.Controls.Add(this.label80);
            this.panel4.Controls.Add(this.label78);
            this.panel4.Controls.Add(this.label79);
            this.panel4.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.panel4.Location = new System.Drawing.Point(12, 167);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(278, 69);
            this.panel4.TabIndex = 6768;
            // 
            // textBox_InsuranceMedicalCom
            // 
            this.textBox_InsuranceMedicalCom.AllowEmptyState = false;
            this.textBox_InsuranceMedicalCom.AutoOffFreeTextEntry = true;
            this.textBox_InsuranceMedicalCom.AutoResolveFreeTextEntries = false;
            // 
            // 
            // 
            this.textBox_InsuranceMedicalCom.BackgroundStyle.BackColor = System.Drawing.Color.AliceBlue;
            this.textBox_InsuranceMedicalCom.BackgroundStyle.BorderBottomWidth = 1;
            this.textBox_InsuranceMedicalCom.BackgroundStyle.Class = "DateTimeInputBackground";
            this.textBox_InsuranceMedicalCom.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBox_InsuranceMedicalCom.BackgroundStyle.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_InsuranceMedicalCom.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.textBox_InsuranceMedicalCom.DisplayFormat = "0.00";
            this.textBox_InsuranceMedicalCom.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.textBox_InsuranceMedicalCom.Increment = 1D;
            this.textBox_InsuranceMedicalCom.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.textBox_InsuranceMedicalCom.Location = new System.Drawing.Point(27, 38);
            this.textBox_InsuranceMedicalCom.Name = "textBox_InsuranceMedicalCom";
            this.textBox_InsuranceMedicalCom.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox_InsuranceMedicalCom.Size = new System.Drawing.Size(40, 21);
            this.textBox_InsuranceMedicalCom.TabIndex = 35;
            // 
            // textBox_SocialInsuranceComp
            // 
            this.textBox_SocialInsuranceComp.AllowEmptyState = false;
            this.textBox_SocialInsuranceComp.AutoOffFreeTextEntry = true;
            this.textBox_SocialInsuranceComp.AutoResolveFreeTextEntries = false;
            // 
            // 
            // 
            this.textBox_SocialInsuranceComp.BackgroundStyle.BackColor = System.Drawing.Color.AliceBlue;
            this.textBox_SocialInsuranceComp.BackgroundStyle.BorderBottomWidth = 1;
            this.textBox_SocialInsuranceComp.BackgroundStyle.Class = "DateTimeInputBackground";
            this.textBox_SocialInsuranceComp.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBox_SocialInsuranceComp.BackgroundStyle.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_SocialInsuranceComp.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.textBox_SocialInsuranceComp.DisplayFormat = "0.00";
            this.textBox_SocialInsuranceComp.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.textBox_SocialInsuranceComp.Increment = 1D;
            this.textBox_SocialInsuranceComp.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.textBox_SocialInsuranceComp.Location = new System.Drawing.Point(27, 13);
            this.textBox_SocialInsuranceComp.MaxValue = 100D;
            this.textBox_SocialInsuranceComp.MinValue = 0D;
            this.textBox_SocialInsuranceComp.Name = "textBox_SocialInsuranceComp";
            this.textBox_SocialInsuranceComp.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox_SocialInsuranceComp.Size = new System.Drawing.Size(40, 21);
            this.textBox_SocialInsuranceComp.TabIndex = 34;
            // 
            // label80
            // 
            this.label80.AutoSize = true;
            this.label80.BackColor = System.Drawing.Color.Transparent;
            this.label80.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label80.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label80.Location = new System.Drawing.Point(4, 16);
            this.label80.Name = "label80";
            this.label80.Size = new System.Drawing.Size(20, 13);
            this.label80.TabIndex = 129;
            this.label80.Text = "%";
            // 
            // label78
            // 
            this.label78.AutoSize = true;
            this.label78.BackColor = System.Drawing.Color.Transparent;
            this.label78.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label78.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label78.Location = new System.Drawing.Point(68, 41);
            this.label78.Name = "label78";
            this.label78.Size = new System.Drawing.Size(206, 13);
            this.label78.TabIndex = 127;
            this.label78.Text = "التأمين الطبـــــــي المدفوع من جهة العمل :";
            // 
            // label79
            // 
            this.label79.AutoSize = true;
            this.label79.BackColor = System.Drawing.Color.Transparent;
            this.label79.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label79.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label79.Location = new System.Drawing.Point(68, 17);
            this.label79.Name = "label79";
            this.label79.Size = new System.Drawing.Size(205, 13);
            this.label79.TabIndex = 125;
            this.label79.Text = "التأمين الإجتماعي المدفوع من جهة العمل :";
            // 
            // label74
            // 
            this.label74.AutoSize = true;
            this.label74.BackColor = System.Drawing.Color.Transparent;
            this.label74.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label74.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label74.Location = new System.Drawing.Point(357, 218);
            this.label74.Name = "label74";
            this.label74.Size = new System.Drawing.Size(85, 13);
            this.label74.TabIndex = 6767;
            this.label74.Text = "بــدلات أخــــرى :";
            // 
            // label75
            // 
            this.label75.AutoSize = true;
            this.label75.BackColor = System.Drawing.Color.Transparent;
            this.label75.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label75.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label75.Location = new System.Drawing.Point(357, 193);
            this.label75.Name = "label75";
            this.label75.Size = new System.Drawing.Size(85, 13);
            this.label75.TabIndex = 6766;
            this.label75.Text = "بدل طبيعة عمل :";
            // 
            // label76
            // 
            this.label76.AutoSize = true;
            this.label76.BackColor = System.Drawing.Color.Transparent;
            this.label76.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label76.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label76.Location = new System.Drawing.Point(357, 168);
            this.label76.Name = "label76";
            this.label76.Size = new System.Drawing.Size(87, 13);
            this.label76.TabIndex = 6765;
            this.label76.Text = "بدل إعاشــــــــة :";
            // 
            // label73
            // 
            this.label73.AutoSize = true;
            this.label73.BackColor = System.Drawing.Color.Transparent;
            this.label73.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label73.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label73.Location = new System.Drawing.Point(504, 218);
            this.label73.Name = "label73";
            this.label73.Size = new System.Drawing.Size(73, 13);
            this.label73.TabIndex = 6764;
            this.label73.Text = "بدل مواصلات :";
            // 
            // label72
            // 
            this.label72.AutoSize = true;
            this.label72.BackColor = System.Drawing.Color.Transparent;
            this.label72.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label72.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label72.Location = new System.Drawing.Point(504, 193);
            this.label72.Name = "label72";
            this.label72.Size = new System.Drawing.Size(75, 13);
            this.label72.TabIndex = 6763;
            this.label72.Text = "سكن / سنوياّ :";
            // 
            // label70
            // 
            this.label70.AutoSize = true;
            this.label70.BackColor = System.Drawing.Color.Transparent;
            this.label70.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label70.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label70.Location = new System.Drawing.Point(504, 168);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(76, 13);
            this.label70.TabIndex = 6762;
            this.label70.Text = "راتب أساسي :";
            // 
            // textBox_SubsistenceAllowance
            // 
            this.textBox_SubsistenceAllowance.AllowEmptyState = false;
            // 
            // 
            // 
            this.textBox_SubsistenceAllowance.BackgroundStyle.BackColor = System.Drawing.Color.AliceBlue;
            this.textBox_SubsistenceAllowance.BackgroundStyle.Class = "DateTimeInputBackground";
            this.textBox_SubsistenceAllowance.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBox_SubsistenceAllowance.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.textBox_SubsistenceAllowance.DisplayFormat = "0.00";
            this.textBox_SubsistenceAllowance.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.textBox_SubsistenceAllowance.Increment = 1D;
            this.textBox_SubsistenceAllowance.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.textBox_SubsistenceAllowance.Location = new System.Drawing.Point(303, 164);
            this.textBox_SubsistenceAllowance.Name = "textBox_SubsistenceAllowance";
            this.textBox_SubsistenceAllowance.Size = new System.Drawing.Size(50, 21);
            this.textBox_SubsistenceAllowance.TabIndex = 6758;
            this.textBox_SubsistenceAllowance.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_SubsistenceAllowance_KeyUp);
            // 
            // line1
            // 
            this.line1.Location = new System.Drawing.Point(9, 145);
            this.line1.Name = "line1";
            this.line1.Size = new System.Drawing.Size(577, 8);
            this.line1.TabIndex = 6754;
            this.line1.Text = "line1";
            // 
            // comboBox_Allowances
            // 
            this.comboBox_Allowances.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox_Allowances.DisplayMember = "Text";
            this.comboBox_Allowances.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBox_Allowances.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Allowances.FormattingEnabled = true;
            this.comboBox_Allowances.ItemHeight = 14;
            this.comboBox_Allowances.Location = new System.Drawing.Point(405, 107);
            this.comboBox_Allowances.Name = "comboBox_Allowances";
            this.comboBox_Allowances.Size = new System.Drawing.Size(68, 20);
            this.comboBox_Allowances.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBox_Allowances.TabIndex = 6753;
            // 
            // comboBox_AllowancesTime
            // 
            this.comboBox_AllowancesTime.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox_AllowancesTime.DisplayMember = "Text";
            this.comboBox_AllowancesTime.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBox_AllowancesTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_AllowancesTime.FormattingEnabled = true;
            this.comboBox_AllowancesTime.ItemHeight = 14;
            this.comboBox_AllowancesTime.Location = new System.Drawing.Point(270, 107);
            this.comboBox_AllowancesTime.Name = "comboBox_AllowancesTime";
            this.comboBox_AllowancesTime.Size = new System.Drawing.Size(99, 20);
            this.comboBox_AllowancesTime.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBox_AllowancesTime.TabIndex = 6752;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.dateTimeInput_LastFilter);
            this.panel3.Controls.Add(this.dateTimeInput_DateAppointment);
            this.panel3.Controls.Add(this.label56);
            this.panel3.Controls.Add(this.label53);
            this.panel3.Location = new System.Drawing.Point(9, 79);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(255, 62);
            this.panel3.TabIndex = 6751;
            // 
            // dateTimeInput_LastFilter
            // 
            this.dateTimeInput_LastFilter.BackColor = System.Drawing.SystemColors.ControlLight;
            this.dateTimeInput_LastFilter.Location = new System.Drawing.Point(23, 33);
            this.dateTimeInput_LastFilter.Mask = "0000/00/00";
            this.dateTimeInput_LastFilter.Name = "dateTimeInput_LastFilter";
            this.dateTimeInput_LastFilter.ReadOnly = true;
            this.dateTimeInput_LastFilter.Size = new System.Drawing.Size(110, 20);
            this.dateTimeInput_LastFilter.TabIndex = 6695;
            this.dateTimeInput_LastFilter.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dateTimeInput_LastFilter.Click += new System.EventHandler(this.dateTimeInput_LastFilter_Click);
            this.dateTimeInput_LastFilter.Leave += new System.EventHandler(this.dateTimeInput_LastFilter_Leave);
            // 
            // dateTimeInput_DateAppointment
            // 
            this.dateTimeInput_DateAppointment.Location = new System.Drawing.Point(23, 7);
            this.dateTimeInput_DateAppointment.Mask = "0000/00/00";
            this.dateTimeInput_DateAppointment.Name = "dateTimeInput_DateAppointment";
            this.dateTimeInput_DateAppointment.Size = new System.Drawing.Size(110, 20);
            this.dateTimeInput_DateAppointment.TabIndex = 6678;
            this.dateTimeInput_DateAppointment.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dateTimeInput_DateAppointment.Click += new System.EventHandler(this.dateTimeInput_DateAppointment_Click);
            this.dateTimeInput_DateAppointment.Leave += new System.EventHandler(this.dateTimeInput_DateAppointment_Leave);
            // 
            // label56
            // 
            this.label56.AutoSize = true;
            this.label56.BackColor = System.Drawing.Color.Transparent;
            this.label56.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label56.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label56.Location = new System.Drawing.Point(139, 35);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(84, 13);
            this.label56.TabIndex = 6688;
            this.label56.Text = "تاريخ اخر تصفية :";
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.BackColor = System.Drawing.Color.Transparent;
            this.label53.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label53.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label53.Location = new System.Drawing.Point(137, 9);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(85, 13);
            this.label53.TabIndex = 6685;
            this.label53.Text = "تاريخ التعـــــيين :";
            // 
            // comboBox_DirBoss
            // 
            this.comboBox_DirBoss.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox_DirBoss.DisplayMember = "Text";
            this.comboBox_DirBoss.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBox_DirBoss.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_DirBoss.FormattingEnabled = true;
            this.comboBox_DirBoss.ItemHeight = 14;
            this.comboBox_DirBoss.Location = new System.Drawing.Point(325, 78);
            this.comboBox_DirBoss.Name = "comboBox_DirBoss";
            this.comboBox_DirBoss.Size = new System.Drawing.Size(179, 20);
            this.comboBox_DirBoss.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBox_DirBoss.TabIndex = 6747;
            // 
            // button_AddNewBoss
            // 
            this.button_AddNewBoss.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_AddNewBoss.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_AddNewBoss.Location = new System.Drawing.Point(271, 78);
            this.button_AddNewBoss.Name = "button_AddNewBoss";
            this.button_AddNewBoss.Size = new System.Drawing.Size(26, 20);
            this.button_AddNewBoss.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_AddNewBoss.Symbol = "";
            this.button_AddNewBoss.SymbolSize = 11F;
            this.button_AddNewBoss.TabIndex = 6749;
            this.button_AddNewBoss.TextColor = System.Drawing.Color.SteelBlue;
            this.button_AddNewBoss.Click += new System.EventHandler(this.button_AddNewBoss_Click);
            // 
            // button_SrchBoss
            // 
            this.button_SrchBoss.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchBoss.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchBoss.Location = new System.Drawing.Point(298, 78);
            this.button_SrchBoss.Name = "button_SrchBoss";
            this.button_SrchBoss.Size = new System.Drawing.Size(26, 20);
            this.button_SrchBoss.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchBoss.Symbol = "";
            this.button_SrchBoss.SymbolSize = 12F;
            this.button_SrchBoss.TabIndex = 6748;
            this.button_SrchBoss.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchBoss.Click += new System.EventHandler(this.button_SrchBoss_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label10.Location = new System.Drawing.Point(506, 82);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 13);
            this.label10.TabIndex = 6750;
            this.label10.Text = "المدير :";
            // 
            // textBox_DayOfMonth
            // 
            this.textBox_DayOfMonth.AllowEmptyState = false;
            // 
            // 
            // 
            this.textBox_DayOfMonth.BackgroundStyle.Class = "DateTimeInputBackground";
            this.textBox_DayOfMonth.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBox_DayOfMonth.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.textBox_DayOfMonth.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.textBox_DayOfMonth.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.textBox_DayOfMonth.Location = new System.Drawing.Point(271, 49);
            this.textBox_DayOfMonth.MinValue = 1;
            this.textBox_DayOfMonth.Name = "textBox_DayOfMonth";
            this.textBox_DayOfMonth.Size = new System.Drawing.Size(49, 20);
            this.textBox_DayOfMonth.TabIndex = 6746;
            this.textBox_DayOfMonth.Value = 1;
            this.textBox_DayOfMonth.ValueChanged += new System.EventHandler(this.textBox_DayOfMonth_ValueChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dateTimeInput_StartContr);
            this.groupBox4.Controls.Add(this.label54);
            this.groupBox4.Controls.Add(this.dateTimeInput_EndContr);
            this.groupBox4.Controls.Add(this.label55);
            this.groupBox4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.groupBox4.Location = new System.Drawing.Point(9, 13);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(255, 57);
            this.groupBox4.TabIndex = 6744;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "تــاريخ العقـــــد";
            // 
            // dateTimeInput_StartContr
            // 
            this.dateTimeInput_StartContr.Location = new System.Drawing.Point(132, 25);
            this.dateTimeInput_StartContr.Mask = "0000/00/00";
            this.dateTimeInput_StartContr.Name = "dateTimeInput_StartContr";
            this.dateTimeInput_StartContr.Size = new System.Drawing.Size(83, 21);
            this.dateTimeInput_StartContr.TabIndex = 6679;
            this.dateTimeInput_StartContr.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dateTimeInput_StartContr.Click += new System.EventHandler(this.dateTimeInput_StartContr_Click);
            this.dateTimeInput_StartContr.Leave += new System.EventHandler(this.dateTimeInput_StartContr_Leave);
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.BackColor = System.Drawing.Color.Transparent;
            this.label54.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label54.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label54.Location = new System.Drawing.Point(214, 29);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(28, 13);
            this.label54.TabIndex = 6686;
            this.label54.Text = "من :";
            // 
            // dateTimeInput_EndContr
            // 
            this.dateTimeInput_EndContr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.dateTimeInput_EndContr.Location = new System.Drawing.Point(12, 25);
            this.dateTimeInput_EndContr.Mask = "0000/00/00";
            this.dateTimeInput_EndContr.Name = "dateTimeInput_EndContr";
            this.dateTimeInput_EndContr.Size = new System.Drawing.Size(83, 21);
            this.dateTimeInput_EndContr.TabIndex = 6680;
            this.dateTimeInput_EndContr.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dateTimeInput_EndContr.Click += new System.EventHandler(this.dateTimeInput_EndContr_Click);
            this.dateTimeInput_EndContr.Leave += new System.EventHandler(this.dateTimeInput_EndContr_Leave);
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.BackColor = System.Drawing.Color.Transparent;
            this.label55.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label55.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label55.Location = new System.Drawing.Point(94, 29);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(31, 13);
            this.label55.TabIndex = 6687;
            this.label55.Text = "إلى :";
            // 
            // label137
            // 
            this.label137.AutoSize = true;
            this.label137.BackColor = System.Drawing.Color.Transparent;
            this.label137.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label137.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label137.Location = new System.Drawing.Point(374, 111);
            this.label137.Name = "label137";
            this.label137.Size = new System.Drawing.Size(29, 13);
            this.label137.TabIndex = 6743;
            this.label137.Text = "شهر";
            // 
            // label140
            // 
            this.label140.AutoSize = true;
            this.label140.BackColor = System.Drawing.Color.Transparent;
            this.label140.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label140.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label140.Location = new System.Drawing.Point(475, 111);
            this.label140.Name = "label140";
            this.label140.Size = new System.Drawing.Size(108, 13);
            this.label140.TabIndex = 6742;
            this.label140.Text = "صرف بدل السكن كل :";
            // 
            // textBox_WorkHours
            // 
            this.textBox_WorkHours.AllowEmptyState = false;
            // 
            // 
            // 
            this.textBox_WorkHours.BackgroundStyle.Class = "DateTimeInputBackground";
            this.textBox_WorkHours.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBox_WorkHours.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.textBox_WorkHours.DisplayFormat = "0";
            this.textBox_WorkHours.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.textBox_WorkHours.Increment = 1D;
            this.textBox_WorkHours.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.textBox_WorkHours.Location = new System.Drawing.Point(455, 49);
            this.textBox_WorkHours.MinValue = 1D;
            this.textBox_WorkHours.Name = "textBox_WorkHours";
            this.textBox_WorkHours.Size = new System.Drawing.Size(49, 20);
            this.textBox_WorkHours.TabIndex = 6738;
            this.textBox_WorkHours.Value = 1D;
            this.textBox_WorkHours.ValueChanged += new System.EventHandler(this.textBox_WorkHours_ValueChanged);
            // 
            // label60
            // 
            this.label60.AutoSize = true;
            this.label60.BackColor = System.Drawing.Color.Transparent;
            this.label60.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label60.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label60.Location = new System.Drawing.Point(321, 53);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(109, 13);
            this.label60.TabIndex = 6741;
            this.label60.Text = "عدد الأيام في الشهر :";
            // 
            // label59
            // 
            this.label59.AutoSize = true;
            this.label59.BackColor = System.Drawing.Color.Transparent;
            this.label59.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label59.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label59.Location = new System.Drawing.Point(506, 53);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(77, 13);
            this.label59.TabIndex = 6740;
            this.label59.Text = "ساعات العمل :";
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.BackColor = System.Drawing.Color.Transparent;
            this.label57.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label57.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label57.Location = new System.Drawing.Point(506, 24);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(65, 13);
            this.label57.TabIndex = 6739;
            this.label57.Text = "نوع العقـــد :";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.switchButton_SalStatus);
            this.groupBox5.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.groupBox5.Location = new System.Drawing.Point(9, 306);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(158, 107);
            this.groupBox5.TabIndex = 6771;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "حالة الــــراتب";
            // 
            // switchButton_SalStatus
            // 
            this.switchButton_SalStatus.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left));
            // 
            // 
            // 
            this.switchButton_SalStatus.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.switchButton_SalStatus.Location = new System.Drawing.Point(16, 41);
            this.switchButton_SalStatus.Name = "switchButton_SalStatus";
            this.switchButton_SalStatus.OffBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(80)))), ((int)(((byte)(77)))));
            this.switchButton_SalStatus.OffText = "متوقــــــــف";
            this.switchButton_SalStatus.OffTextColor = System.Drawing.Color.White;
            this.switchButton_SalStatus.OnText = "جـــاري";
            this.switchButton_SalStatus.Size = new System.Drawing.Size(124, 41);
            this.switchButton_SalStatus.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.switchButton_SalStatus.TabIndex = 1049;
            this.switchButton_SalStatus.Value = true;
            this.switchButton_SalStatus.ValueObject = "Y";
            // 
            // groupBox6
            // 
            this.groupBox6.BackColor = System.Drawing.Color.Transparent;
            this.groupBox6.Controls.Add(this.textBox_SocialInsurance);
            this.groupBox6.Controls.Add(this.textBox_InsuranceMedical);
            this.groupBox6.Controls.Add(this.textBox_LateHours);
            this.groupBox6.Controls.Add(this.textBox_DisOneDay);
            this.groupBox6.Controls.Add(this.label86);
            this.groupBox6.Controls.Add(this.label84);
            this.groupBox6.Controls.Add(this.label82);
            this.groupBox6.Controls.Add(this.label83);
            this.groupBox6.Controls.Add(this.label85);
            this.groupBox6.Location = new System.Drawing.Point(329, 306);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(254, 104);
            this.groupBox6.TabIndex = 6773;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "المستقطعـــات ( الخصومات )";
            // 
            // textBox_SocialInsurance
            // 
            this.textBox_SocialInsurance.AllowEmptyState = false;
            this.textBox_SocialInsurance.AutoOffFreeTextEntry = true;
            this.textBox_SocialInsurance.AutoResolveFreeTextEntries = false;
            // 
            // 
            // 
            this.textBox_SocialInsurance.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(195)))), ((int)(((byte)(198)))));
            this.textBox_SocialInsurance.BackgroundStyle.BorderBottomWidth = 1;
            this.textBox_SocialInsurance.BackgroundStyle.Class = "DateTimeInputBackground";
            this.textBox_SocialInsurance.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBox_SocialInsurance.BackgroundStyle.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_SocialInsurance.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.textBox_SocialInsurance.DisplayFormat = "0.00";
            this.textBox_SocialInsurance.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.textBox_SocialInsurance.Increment = 1D;
            this.textBox_SocialInsurance.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.textBox_SocialInsurance.Location = new System.Drawing.Point(21, 49);
            this.textBox_SocialInsurance.MaxValue = 100D;
            this.textBox_SocialInsurance.MinValue = 0D;
            this.textBox_SocialInsurance.Name = "textBox_SocialInsurance";
            this.textBox_SocialInsurance.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox_SocialInsurance.ShowUpDown = true;
            this.textBox_SocialInsurance.Size = new System.Drawing.Size(85, 21);
            this.textBox_SocialInsurance.TabIndex = 39;
            // 
            // textBox_InsuranceMedical
            // 
            this.textBox_InsuranceMedical.AllowEmptyState = false;
            // 
            // 
            // 
            this.textBox_InsuranceMedical.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(195)))), ((int)(((byte)(198)))));
            this.textBox_InsuranceMedical.BackgroundStyle.Class = "DateTimeInputBackground";
            this.textBox_InsuranceMedical.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBox_InsuranceMedical.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.textBox_InsuranceMedical.DisplayFormat = "0.00";
            this.textBox_InsuranceMedical.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.textBox_InsuranceMedical.Increment = 1D;
            this.textBox_InsuranceMedical.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.textBox_InsuranceMedical.Location = new System.Drawing.Point(21, 77);
            this.textBox_InsuranceMedical.Name = "textBox_InsuranceMedical";
            this.textBox_InsuranceMedical.Size = new System.Drawing.Size(85, 21);
            this.textBox_InsuranceMedical.TabIndex = 40;
            // 
            // textBox_LateHours
            // 
            this.textBox_LateHours.AllowEmptyState = false;
            // 
            // 
            // 
            this.textBox_LateHours.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.textBox_LateHours.BackgroundStyle.Class = "DateTimeInputBackground";
            this.textBox_LateHours.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBox_LateHours.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.textBox_LateHours.DisplayFormat = "0.00";
            this.textBox_LateHours.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.textBox_LateHours.Increment = 1D;
            this.textBox_LateHours.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.textBox_LateHours.Location = new System.Drawing.Point(21, 19);
            this.textBox_LateHours.Name = "textBox_LateHours";
            this.textBox_LateHours.Size = new System.Drawing.Size(44, 21);
            this.textBox_LateHours.TabIndex = 38;
            // 
            // textBox_DisOneDay
            // 
            this.textBox_DisOneDay.AllowEmptyState = false;
            // 
            // 
            // 
            this.textBox_DisOneDay.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.textBox_DisOneDay.BackgroundStyle.Class = "DateTimeInputBackground";
            this.textBox_DisOneDay.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBox_DisOneDay.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.textBox_DisOneDay.DisplayFormat = "0.00";
            this.textBox_DisOneDay.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.textBox_DisOneDay.Increment = 1D;
            this.textBox_DisOneDay.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.textBox_DisOneDay.Location = new System.Drawing.Point(146, 19);
            this.textBox_DisOneDay.Name = "textBox_DisOneDay";
            this.textBox_DisOneDay.Size = new System.Drawing.Size(44, 21);
            this.textBox_DisOneDay.TabIndex = 37;
            // 
            // label86
            // 
            this.label86.AutoSize = true;
            this.label86.BackColor = System.Drawing.Color.Transparent;
            this.label86.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label86.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label86.Location = new System.Drawing.Point(4, 52);
            this.label86.Name = "label86";
            this.label86.Size = new System.Drawing.Size(18, 13);
            this.label86.TabIndex = 135;
            this.label86.Text = "%";
            // 
            // label84
            // 
            this.label84.AutoSize = true;
            this.label84.BackColor = System.Drawing.Color.Transparent;
            this.label84.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label84.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label84.Location = new System.Drawing.Point(109, 81);
            this.label84.Name = "label84";
            this.label84.Size = new System.Drawing.Size(77, 13);
            this.label84.TabIndex = 134;
            this.label84.Text = "التأمين الطبي :";
            // 
            // label82
            // 
            this.label82.AutoSize = true;
            this.label82.BackColor = System.Drawing.Color.Transparent;
            this.label82.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label82.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label82.Location = new System.Drawing.Point(109, 53);
            this.label82.Name = "label82";
            this.label82.Size = new System.Drawing.Size(97, 13);
            this.label82.TabIndex = 132;
            this.label82.Text = "التأمين الإجتماعي :";
            // 
            // label83
            // 
            this.label83.AutoSize = true;
            this.label83.BackColor = System.Drawing.Color.Transparent;
            this.label83.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label83.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label83.Location = new System.Drawing.Point(66, 23);
            this.label83.Name = "label83";
            this.label83.Size = new System.Drawing.Size(68, 13);
            this.label83.TabIndex = 130;
            this.label83.Text = "خصم ساعة :";
            // 
            // label85
            // 
            this.label85.AutoSize = true;
            this.label85.BackColor = System.Drawing.Color.Transparent;
            this.label85.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label85.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label85.Location = new System.Drawing.Point(192, 23);
            this.label85.Name = "label85";
            this.label85.Size = new System.Drawing.Size(56, 13);
            this.label85.TabIndex = 128;
            this.label85.Text = "خصم يوم :";
            // 
            // groupBox7
            // 
            this.groupBox7.BackColor = System.Drawing.Color.Transparent;
            this.groupBox7.Controls.Add(this.textBox_MandateDay);
            this.groupBox7.Controls.Add(this.textBox_AddHours);
            this.groupBox7.Controls.Add(this.textBox_AddDay);
            this.groupBox7.Controls.Add(this.label89);
            this.groupBox7.Controls.Add(this.label90);
            this.groupBox7.Controls.Add(this.label91);
            this.groupBox7.Location = new System.Drawing.Point(173, 306);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(153, 104);
            this.groupBox7.TabIndex = 6774;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "المستحقات ( الإضافي )";
            // 
            // textBox_MandateDay
            // 
            this.textBox_MandateDay.AllowEmptyState = false;
            // 
            // 
            // 
            this.textBox_MandateDay.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.textBox_MandateDay.BackgroundStyle.Class = "DateTimeInputBackground";
            this.textBox_MandateDay.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBox_MandateDay.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.textBox_MandateDay.DisplayFormat = "0.00";
            this.textBox_MandateDay.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.textBox_MandateDay.Increment = 1D;
            this.textBox_MandateDay.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.textBox_MandateDay.Location = new System.Drawing.Point(22, 73);
            this.textBox_MandateDay.Name = "textBox_MandateDay";
            this.textBox_MandateDay.Size = new System.Drawing.Size(54, 21);
            this.textBox_MandateDay.TabIndex = 43;
            // 
            // textBox_AddHours
            // 
            this.textBox_AddHours.AllowEmptyState = false;
            // 
            // 
            // 
            this.textBox_AddHours.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.textBox_AddHours.BackgroundStyle.Class = "DateTimeInputBackground";
            this.textBox_AddHours.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBox_AddHours.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.textBox_AddHours.DisplayFormat = "0.00";
            this.textBox_AddHours.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.textBox_AddHours.Increment = 1D;
            this.textBox_AddHours.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.textBox_AddHours.Location = new System.Drawing.Point(22, 46);
            this.textBox_AddHours.Name = "textBox_AddHours";
            this.textBox_AddHours.Size = new System.Drawing.Size(54, 21);
            this.textBox_AddHours.TabIndex = 42;
            // 
            // textBox_AddDay
            // 
            this.textBox_AddDay.AllowEmptyState = false;
            // 
            // 
            // 
            this.textBox_AddDay.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.textBox_AddDay.BackgroundStyle.Class = "DateTimeInputBackground";
            this.textBox_AddDay.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBox_AddDay.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.textBox_AddDay.DisplayFormat = "0.00";
            this.textBox_AddDay.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.textBox_AddDay.Increment = 1D;
            this.textBox_AddDay.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.textBox_AddDay.Location = new System.Drawing.Point(22, 19);
            this.textBox_AddDay.Name = "textBox_AddDay";
            this.textBox_AddDay.Size = new System.Drawing.Size(54, 21);
            this.textBox_AddDay.TabIndex = 41;
            // 
            // label89
            // 
            this.label89.AutoSize = true;
            this.label89.BackColor = System.Drawing.Color.Transparent;
            this.label89.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label89.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label89.Location = new System.Drawing.Point(80, 77);
            this.label89.Name = "label89";
            this.label89.Size = new System.Drawing.Size(67, 13);
            this.label89.TabIndex = 132;
            this.label89.Text = "إنتداب سفر :";
            // 
            // label90
            // 
            this.label90.AutoSize = true;
            this.label90.BackColor = System.Drawing.Color.Transparent;
            this.label90.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label90.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label90.Location = new System.Drawing.Point(80, 50);
            this.label90.Name = "label90";
            this.label90.Size = new System.Drawing.Size(65, 13);
            this.label90.TabIndex = 130;
            this.label90.Text = "ساعــــــــة :";
            // 
            // label91
            // 
            this.label91.AutoSize = true;
            this.label91.BackColor = System.Drawing.Color.Transparent;
            this.label91.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label91.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label91.Location = new System.Drawing.Point(80, 23);
            this.label91.Name = "label91";
            this.label91.Size = new System.Drawing.Size(63, 13);
            this.label91.TabIndex = 128;
            this.label91.Text = "إضافي يوم :";
            // 
            // textBox_WorkNo
            // 
            this.textBox_WorkNo.BackColor = System.Drawing.Color.AliceBlue;
            // 
            // 
            // 
            this.textBox_WorkNo.Border.Class = "TextBoxBorder";
            this.textBox_WorkNo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBox_WorkNo.ButtonCustom.Text = "مكتب العمل";
            this.textBox_WorkNo.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.textBox_WorkNo.ForeColor = System.Drawing.Color.Black;
            this.textBox_WorkNo.Location = new System.Drawing.Point(9, 370);
            this.textBox_WorkNo.Multiline = true;
            this.textBox_WorkNo.Name = "textBox_WorkNo";
            this.textBox_WorkNo.Size = new System.Drawing.Size(158, 40);
            this.textBox_WorkNo.TabIndex = 6779;
            this.textBox_WorkNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_WorkNo.Visible = false;
            this.textBox_WorkNo.WatermarkColor = System.Drawing.Color.RosyBrown;
            this.textBox_WorkNo.WatermarkFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_WorkNo.WatermarkImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.textBox_WorkNo.WatermarkText = "رقم مكتب العمل والعمال";
            this.textBox_WorkNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_WorkNo_KeyPress);
            this.textBox_WorkNo.Leave += new System.EventHandler(this.textBox_WorkNo_Leave);
            // 
            // checkBox_AutoReturnContr
            // 
            this.checkBox_AutoReturnContr.AutoSize = true;
            this.checkBox_AutoReturnContr.BackColor = System.Drawing.Color.Transparent;
            this.checkBox_AutoReturnContr.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.checkBox_AutoReturnContr.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.checkBox_AutoReturnContr.Location = new System.Drawing.Point(270, 23);
            this.checkBox_AutoReturnContr.Name = "checkBox_AutoReturnContr";
            this.checkBox_AutoReturnContr.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBox_AutoReturnContr.Size = new System.Drawing.Size(84, 17);
            this.checkBox_AutoReturnContr.TabIndex = 6745;
            this.checkBox_AutoReturnContr.Text = "تجديد تلقائي";
            this.checkBox_AutoReturnContr.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBox_AutoReturnContr.UseVisualStyleBackColor = false;
            // 
            // labelX18
            // 
            this.labelX18.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX18.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX18.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelX18.Location = new System.Drawing.Point(0, 0);
            this.labelX18.Name = "labelX18";
            this.labelX18.Size = new System.Drawing.Size(594, 419);
            this.labelX18.TabIndex = 8;
            this.labelX18.Text = "This space intentionally left blank.";
            this.labelX18.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // superTabItem_Contract
            // 
            this.superTabItem_Contract.AttachedControl = this.superTabControlPanel17;
            this.superTabItem_Contract.CloseButtonVisible = false;
            this.superTabItem_Contract.GlobalItem = false;
            this.superTabItem_Contract.Name = "superTabItem_Contract";
            this.superTabItem_Contract.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Cyan;
            this.superTabItem_Contract.Text = "العقــــــــد";
            // 
            // superTabControlPanel15
            // 
            this.superTabControlPanel15.Controls.Add(this.panelEx1);
            this.superTabControlPanel15.Controls.Add(this.labelX15);
            this.superTabControlPanel15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel15.Location = new System.Drawing.Point(0, 0);
            this.superTabControlPanel15.Name = "superTabControlPanel15";
            this.superTabControlPanel15.Size = new System.Drawing.Size(594, 419);
            this.superTabControlPanel15.TabIndex = 0;
            this.superTabControlPanel15.TabItem = this.superTabItem_Gen;
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.groupBox1);
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(594, 419);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.Color = System.Drawing.Color.AliceBlue;
            this.panelEx1.Style.BackColor2.Color = System.Drawing.SystemColors.GradientActiveCaption;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 9;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Gainsboro;
            this.groupBox1.Controls.Add(this.button_SrchNation);
            this.groupBox1.Controls.Add(this.button_SrchGuartor);
            this.groupBox1.Controls.Add(this.button_SrchJob);
            this.groupBox1.Controls.Add(this.button_SrchSection);
            this.groupBox1.Controls.Add(this.button_SrchDept);
            this.groupBox1.Controls.Add(this.pictureBox_EnterPic);
            this.groupBox1.Controls.Add(this.textBox_NameE);
            this.groupBox1.Controls.Add(this.textBox_NameA);
            this.groupBox1.Controls.Add(this.textBox_SocialInsuranceNo);
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Controls.Add(this.labelX1);
            this.groupBox1.Controls.Add(this.checkBox_ClearPic);
            this.groupBox1.Controls.Add(this.button_Pic);
            this.groupBox1.Controls.Add(this.comboBox_Nationalty);
            this.groupBox1.Controls.Add(this.button_AddNewNation);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.comboBox_Guarantor);
            this.groupBox1.Controls.Add(this.button_AddNewSponser);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.comboBox_Job);
            this.groupBox1.Controls.Add(this.button_AddNewJob);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.comboBox_Section);
            this.groupBox1.Controls.Add(this.button_AddNewSection);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.comboBox_Dept);
            this.groupBox1.Controls.Add(this.button_AddNewDept);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.textBox_Pass);
            this.groupBox1.Controls.Add(this.label52);
            this.groupBox1.Controls.Add(this.label40);
            this.groupBox1.Controls.Add(this.label36);
            this.groupBox1.Controls.Add(this.label38);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.textBox_ID);
            this.groupBox1.Controls.Add(this.linkLabel_ChangeEmpNo);
            this.groupBox1.Controls.Add(this.button_PhotoShoot);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(594, 419);
            this.groupBox1.TabIndex = 103;
            this.groupBox1.TabStop = false;
            // 
            // button_SrchNation
            // 
            this.button_SrchNation.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchNation.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchNation.Location = new System.Drawing.Point(31, 194);
            this.button_SrchNation.Name = "button_SrchNation";
            this.button_SrchNation.Size = new System.Drawing.Size(26, 20);
            this.button_SrchNation.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchNation.Symbol = "";
            this.button_SrchNation.SymbolSize = 12F;
            this.button_SrchNation.TabIndex = 1600;
            this.button_SrchNation.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchNation.Click += new System.EventHandler(this.button_SrchNation_Click);
            // 
            // button_SrchGuartor
            // 
            this.button_SrchGuartor.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchGuartor.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchGuartor.Location = new System.Drawing.Point(182, 170);
            this.button_SrchGuartor.Name = "button_SrchGuartor";
            this.button_SrchGuartor.Size = new System.Drawing.Size(26, 20);
            this.button_SrchGuartor.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchGuartor.Symbol = "";
            this.button_SrchGuartor.SymbolSize = 12F;
            this.button_SrchGuartor.TabIndex = 1596;
            this.button_SrchGuartor.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchGuartor.Click += new System.EventHandler(this.button_SrchGuartor_Click);
            // 
            // button_SrchJob
            // 
            this.button_SrchJob.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchJob.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchJob.Location = new System.Drawing.Point(182, 144);
            this.button_SrchJob.Name = "button_SrchJob";
            this.button_SrchJob.Size = new System.Drawing.Size(26, 20);
            this.button_SrchJob.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchJob.Symbol = "";
            this.button_SrchJob.SymbolSize = 12F;
            this.button_SrchJob.TabIndex = 1592;
            this.button_SrchJob.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchJob.Click += new System.EventHandler(this.button_SrchJob_Click);
            // 
            // button_SrchSection
            // 
            this.button_SrchSection.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchSection.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchSection.Location = new System.Drawing.Point(182, 118);
            this.button_SrchSection.Name = "button_SrchSection";
            this.button_SrchSection.Size = new System.Drawing.Size(26, 20);
            this.button_SrchSection.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchSection.Symbol = "";
            this.button_SrchSection.SymbolSize = 12F;
            this.button_SrchSection.TabIndex = 1588;
            this.button_SrchSection.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchSection.Click += new System.EventHandler(this.button_SrchSection_Click);
            // 
            // button_SrchDept
            // 
            this.button_SrchDept.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchDept.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchDept.Location = new System.Drawing.Point(182, 93);
            this.button_SrchDept.Name = "button_SrchDept";
            this.button_SrchDept.Size = new System.Drawing.Size(26, 20);
            this.button_SrchDept.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchDept.Symbol = "";
            this.button_SrchDept.SymbolSize = 12F;
            this.button_SrchDept.TabIndex = 1584;
            this.button_SrchDept.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchDept.Click += new System.EventHandler(this.button_SrchDept_Click);
            // 
            // pictureBox_EnterPic
            // 
            this.pictureBox_EnterPic.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_EnterPic.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox_EnterPic.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBox_EnterPic.Location = new System.Drawing.Point(3, 44);
            this.pictureBox_EnterPic.Name = "pictureBox_EnterPic";
            this.pictureBox_EnterPic.Size = new System.Drawing.Size(148, 126);
            this.pictureBox_EnterPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_EnterPic.TabIndex = 6686;
            this.pictureBox_EnterPic.TabStop = false;
            // 
            // textBox_NameE
            // 
            this.textBox_NameE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_NameE.ForeColor = System.Drawing.Color.Black;
            this.textBox_NameE.Location = new System.Drawing.Point(154, 69);
            this.textBox_NameE.MaxLength = 30;
            this.textBox_NameE.Name = "textBox_NameE";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_NameE, false);
            this.textBox_NameE.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBox_NameE.Size = new System.Drawing.Size(336, 20);
            this.textBox_NameE.TabIndex = 4;
            this.textBox_NameE.Enter += new System.EventHandler(this.textBox_NameE_Enter);
            this.textBox_NameE.Leave += new System.EventHandler(this.textBox_NameA_Leave);
            // 
            // textBox_NameA
            // 
            this.textBox_NameA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_NameA.ForeColor = System.Drawing.Color.Black;
            this.textBox_NameA.Location = new System.Drawing.Point(154, 44);
            this.textBox_NameA.MaxLength = 30;
            this.textBox_NameA.Name = "textBox_NameA";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_NameA, false);
            this.textBox_NameA.Size = new System.Drawing.Size(336, 20);
            this.textBox_NameA.TabIndex = 3;
            this.textBox_NameA.Enter += new System.EventHandler(this.textBox_NameA_Enter);
            this.textBox_NameA.Leave += new System.EventHandler(this.textBox_NameA_Leave);
            // 
            // textBox_SocialInsuranceNo
            // 
            this.textBox_SocialInsuranceNo.AutoSelectAll = true;
            this.textBox_SocialInsuranceNo.BackColor = System.Drawing.Color.AliceBlue;
            // 
            // 
            // 
            this.textBox_SocialInsuranceNo.Border.Class = "TextBoxBorder";
            this.textBox_SocialInsuranceNo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBox_SocialInsuranceNo.ButtonCustom.Text = ": التأمين الإجتماعي";
            this.textBox_SocialInsuranceNo.ForeColor = System.Drawing.Color.Black;
            this.textBox_SocialInsuranceNo.Location = new System.Drawing.Point(3, 218);
            this.textBox_SocialInsuranceNo.Multiline = true;
            this.textBox_SocialInsuranceNo.Name = "textBox_SocialInsuranceNo";
            this.textBox_SocialInsuranceNo.Size = new System.Drawing.Size(575, 42);
            this.textBox_SocialInsuranceNo.TabIndex = 10;
            this.textBox_SocialInsuranceNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_SocialInsuranceNo.WatermarkColor = System.Drawing.Color.RosyBrown;
            this.textBox_SocialInsuranceNo.WatermarkFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_SocialInsuranceNo.WatermarkImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.textBox_SocialInsuranceNo.WatermarkText = "...";
            this.textBox_SocialInsuranceNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_SocialInsuranceNo_KeyPress);
            this.textBox_SocialInsuranceNo.Leave += new System.EventHandler(this.textBox_SocialInsuranceNo_Leave);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.textBox_QualificationA);
            this.panel2.Controls.Add(this.button_AddNewBirthPlaces);
            this.panel2.Controls.Add(this.button_SrchBirthPlaces);
            this.panel2.Controls.Add(this.textBox_ExperiencesA);
            this.panel2.Controls.Add(this.label127);
            this.panel2.Controls.Add(this.comboBox_BloodTyp);
            this.panel2.Controls.Add(this.comboBox_BirthPlace);
            this.panel2.Controls.Add(this.label133);
            this.panel2.Controls.Add(this.textBox_Email);
            this.panel2.Controls.Add(this.label125);
            this.panel2.Controls.Add(this.textBox_Tel);
            this.panel2.Controls.Add(this.label124);
            this.panel2.Controls.Add(this.comboBox_CityNo);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.button_AddNewCity);
            this.panel2.Controls.Add(this.button_SrchCities);
            this.panel2.Controls.Add(this.textBox_AddressA);
            this.panel2.Controls.Add(this.label126);
            this.panel2.Controls.Add(this.comboBox_Sex);
            this.panel2.Controls.Add(this.comboBox_MaritalStatus);
            this.panel2.Controls.Add(this.comboBox_Religion);
            this.panel2.Controls.Add(this.dateTimeInput_BirthDate);
            this.panel2.Controls.Add(this.label119);
            this.panel2.Controls.Add(this.label118);
            this.panel2.Controls.Add(this.label117);
            this.panel2.Controls.Add(this.label115);
            this.panel2.Controls.Add(this.label114);
            this.panel2.Controls.Add(this.label113);
            this.panel2.Controls.Add(this.button_AddNewReligon);
            this.panel2.Controls.Add(this.button_SrchReligion);
            this.panel2.Controls.Add(this.button_SrchReligon);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(3, 266);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(588, 150);
            this.panel2.TabIndex = 6677;
            // 
            // textBox_QualificationA
            // 
            this.textBox_QualificationA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.textBox_QualificationA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_QualificationA.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.textBox_QualificationA.Location = new System.Drawing.Point(10, 92);
            this.textBox_QualificationA.MaxLength = 50;
            this.textBox_QualificationA.Name = "textBox_QualificationA";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_QualificationA, false);
            this.textBox_QualificationA.Size = new System.Drawing.Size(476, 21);
            this.textBox_QualificationA.TabIndex = 21;
            // 
            // button_AddNewBirthPlaces
            // 
            this.button_AddNewBirthPlaces.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_AddNewBirthPlaces.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_AddNewBirthPlaces.Location = new System.Drawing.Point(131, 26);
            this.button_AddNewBirthPlaces.Name = "button_AddNewBirthPlaces";
            this.button_AddNewBirthPlaces.Size = new System.Drawing.Size(26, 20);
            this.button_AddNewBirthPlaces.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_AddNewBirthPlaces.Symbol = "";
            this.button_AddNewBirthPlaces.SymbolSize = 11F;
            this.button_AddNewBirthPlaces.TabIndex = 6700;
            this.button_AddNewBirthPlaces.TextColor = System.Drawing.Color.SteelBlue;
            this.button_AddNewBirthPlaces.Click += new System.EventHandler(this.button_AddNewBirthPlaces_Click);
            // 
            // button_SrchBirthPlaces
            // 
            this.button_SrchBirthPlaces.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchBirthPlaces.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchBirthPlaces.Location = new System.Drawing.Point(158, 26);
            this.button_SrchBirthPlaces.Name = "button_SrchBirthPlaces";
            this.button_SrchBirthPlaces.Size = new System.Drawing.Size(26, 20);
            this.button_SrchBirthPlaces.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchBirthPlaces.Symbol = "";
            this.button_SrchBirthPlaces.SymbolSize = 12F;
            this.button_SrchBirthPlaces.TabIndex = 6699;
            this.button_SrchBirthPlaces.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchBirthPlaces.Click += new System.EventHandler(this.button_SrchBirthPlaces_Click);
            // 
            // textBox_ExperiencesA
            // 
            this.textBox_ExperiencesA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.textBox_ExperiencesA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_ExperiencesA.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.textBox_ExperiencesA.Location = new System.Drawing.Point(10, 115);
            this.textBox_ExperiencesA.MaxLength = 100;
            this.textBox_ExperiencesA.Multiline = true;
            this.textBox_ExperiencesA.Name = "textBox_ExperiencesA";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_ExperiencesA, false);
            this.textBox_ExperiencesA.Size = new System.Drawing.Size(476, 29);
            this.textBox_ExperiencesA.TabIndex = 22;
            // 
            // label127
            // 
            this.label127.AutoSize = true;
            this.label127.BackColor = System.Drawing.Color.Transparent;
            this.label127.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label127.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label127.Location = new System.Drawing.Point(489, 118);
            this.label127.Name = "label127";
            this.label127.Size = new System.Drawing.Size(87, 13);
            this.label127.TabIndex = 6698;
            this.label127.Text = "الخبـــــــــــــرات :";
            // 
            // comboBox_BloodTyp
            // 
            this.comboBox_BloodTyp.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox_BloodTyp.DisplayMember = "Text";
            this.comboBox_BloodTyp.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBox_BloodTyp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_BloodTyp.FormattingEnabled = true;
            this.comboBox_BloodTyp.ItemHeight = 14;
            this.comboBox_BloodTyp.Location = new System.Drawing.Point(10, 26);
            this.comboBox_BloodTyp.Name = "comboBox_BloodTyp";
            this.comboBox_BloodTyp.Size = new System.Drawing.Size(54, 20);
            this.comboBox_BloodTyp.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBox_BloodTyp.TabIndex = 16;
            // 
            // comboBox_BirthPlace
            // 
            this.comboBox_BirthPlace.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox_BirthPlace.DisplayMember = "Text";
            this.comboBox_BirthPlace.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBox_BirthPlace.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_BirthPlace.FormattingEnabled = true;
            this.comboBox_BirthPlace.ItemHeight = 14;
            this.comboBox_BirthPlace.Location = new System.Drawing.Point(185, 26);
            this.comboBox_BirthPlace.Name = "comboBox_BirthPlace";
            this.comboBox_BirthPlace.Size = new System.Drawing.Size(130, 20);
            this.comboBox_BirthPlace.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBox_BirthPlace.TabIndex = 15;
            // 
            // label133
            // 
            this.label133.AutoSize = true;
            this.label133.BackColor = System.Drawing.Color.Transparent;
            this.label133.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label133.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label133.Location = new System.Drawing.Point(489, 96);
            this.label133.Name = "label133";
            this.label133.Size = new System.Drawing.Size(85, 13);
            this.label133.TabIndex = 6694;
            this.label133.Text = "المؤهل العلمي :";
            // 
            // textBox_Email
            // 
            this.textBox_Email.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_Email.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.textBox_Email.Location = new System.Drawing.Point(10, 70);
            this.textBox_Email.MaxLength = 30;
            this.textBox_Email.Name = "textBox_Email";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_Email, false);
            this.textBox_Email.Size = new System.Drawing.Size(193, 21);
            this.textBox_Email.TabIndex = 20;
            // 
            // label125
            // 
            this.label125.AutoSize = true;
            this.label125.BackColor = System.Drawing.Color.Transparent;
            this.label125.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label125.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label125.Location = new System.Drawing.Point(204, 74);
            this.label125.Name = "label125";
            this.label125.Size = new System.Drawing.Size(88, 13);
            this.label125.TabIndex = 6692;
            this.label125.Text = "البريد الإلكتروني :";
            // 
            // textBox_Tel
            // 
            this.textBox_Tel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_Tel.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.textBox_Tel.Location = new System.Drawing.Point(296, 70);
            this.textBox_Tel.MaxLength = 15;
            this.textBox_Tel.Name = "textBox_Tel";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_Tel, false);
            this.textBox_Tel.Size = new System.Drawing.Size(190, 21);
            this.textBox_Tel.TabIndex = 19;
            this.textBox_Tel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_ID_No_KeyPress);
            // 
            // label124
            // 
            this.label124.AutoSize = true;
            this.label124.BackColor = System.Drawing.Color.Transparent;
            this.label124.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label124.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label124.Location = new System.Drawing.Point(489, 74);
            this.label124.Name = "label124";
            this.label124.Size = new System.Drawing.Size(84, 13);
            this.label124.TabIndex = 6691;
            this.label124.Text = "الجــــــــــــــوال :";
            // 
            // comboBox_CityNo
            // 
            this.comboBox_CityNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox_CityNo.DisplayMember = "Text";
            this.comboBox_CityNo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBox_CityNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_CityNo.FormattingEnabled = true;
            this.comboBox_CityNo.ItemHeight = 14;
            this.comboBox_CityNo.Location = new System.Drawing.Point(65, 48);
            this.comboBox_CityNo.Name = "comboBox_CityNo";
            this.comboBox_CityNo.Size = new System.Drawing.Size(138, 20);
            this.comboBox_CityNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBox_CityNo.TabIndex = 18;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label9.Location = new System.Drawing.Point(204, 52);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 13);
            this.label9.TabIndex = 6685;
            this.label9.Text = "المدينة :";
            // 
            // button_AddNewCity
            // 
            this.button_AddNewCity.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_AddNewCity.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_AddNewCity.Location = new System.Drawing.Point(10, 48);
            this.button_AddNewCity.Name = "button_AddNewCity";
            this.button_AddNewCity.Size = new System.Drawing.Size(26, 20);
            this.button_AddNewCity.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_AddNewCity.Symbol = "";
            this.button_AddNewCity.SymbolSize = 11F;
            this.button_AddNewCity.TabIndex = 6688;
            this.button_AddNewCity.TextColor = System.Drawing.Color.SteelBlue;
            this.button_AddNewCity.Click += new System.EventHandler(this.button_AddNewCity_Click);
            // 
            // button_SrchCities
            // 
            this.button_SrchCities.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchCities.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchCities.Location = new System.Drawing.Point(37, 48);
            this.button_SrchCities.Name = "button_SrchCities";
            this.button_SrchCities.Size = new System.Drawing.Size(26, 20);
            this.button_SrchCities.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchCities.Symbol = "";
            this.button_SrchCities.SymbolSize = 12F;
            this.button_SrchCities.TabIndex = 6687;
            this.button_SrchCities.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchCities.Click += new System.EventHandler(this.button_SrchCities_Click);
            // 
            // textBox_AddressA
            // 
            this.textBox_AddressA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_AddressA.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.textBox_AddressA.Location = new System.Drawing.Point(252, 48);
            this.textBox_AddressA.MaxLength = 30;
            this.textBox_AddressA.Name = "textBox_AddressA";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_AddressA, false);
            this.textBox_AddressA.Size = new System.Drawing.Size(234, 21);
            this.textBox_AddressA.TabIndex = 17;
            // 
            // label126
            // 
            this.label126.AutoSize = true;
            this.label126.BackColor = System.Drawing.Color.Transparent;
            this.label126.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label126.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label126.Location = new System.Drawing.Point(489, 52);
            this.label126.Name = "label126";
            this.label126.Size = new System.Drawing.Size(84, 13);
            this.label126.TabIndex = 6684;
            this.label126.Text = "العنـــــــــــــوان :";
            // 
            // comboBox_Sex
            // 
            this.comboBox_Sex.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox_Sex.DisplayMember = "Text";
            this.comboBox_Sex.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBox_Sex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Sex.FormattingEnabled = true;
            this.comboBox_Sex.ItemHeight = 14;
            this.comboBox_Sex.Location = new System.Drawing.Point(410, 4);
            this.comboBox_Sex.Name = "comboBox_Sex";
            this.comboBox_Sex.Size = new System.Drawing.Size(76, 20);
            this.comboBox_Sex.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBox_Sex.TabIndex = 11;
            // 
            // comboBox_MaritalStatus
            // 
            this.comboBox_MaritalStatus.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox_MaritalStatus.DisplayMember = "Text";
            this.comboBox_MaritalStatus.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBox_MaritalStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_MaritalStatus.FormattingEnabled = true;
            this.comboBox_MaritalStatus.ItemHeight = 14;
            this.comboBox_MaritalStatus.Location = new System.Drawing.Point(223, 4);
            this.comboBox_MaritalStatus.Name = "comboBox_MaritalStatus";
            this.comboBox_MaritalStatus.Size = new System.Drawing.Size(92, 20);
            this.comboBox_MaritalStatus.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBox_MaritalStatus.TabIndex = 12;
            // 
            // comboBox_Religion
            // 
            this.comboBox_Religion.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox_Religion.DisplayMember = "Text";
            this.comboBox_Religion.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBox_Religion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Religion.FormattingEnabled = true;
            this.comboBox_Religion.ItemHeight = 14;
            this.comboBox_Religion.Location = new System.Drawing.Point(65, 4);
            this.comboBox_Religion.Name = "comboBox_Religion";
            this.comboBox_Religion.Size = new System.Drawing.Size(113, 20);
            this.comboBox_Religion.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBox_Religion.TabIndex = 13;
            // 
            // dateTimeInput_BirthDate
            // 
            this.dateTimeInput_BirthDate.Location = new System.Drawing.Point(410, 26);
            this.dateTimeInput_BirthDate.Mask = "0000/00/00";
            this.dateTimeInput_BirthDate.Name = "dateTimeInput_BirthDate";
            this.dateTimeInput_BirthDate.Size = new System.Drawing.Size(76, 20);
            this.dateTimeInput_BirthDate.TabIndex = 14;
            this.dateTimeInput_BirthDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label119
            // 
            this.label119.AutoSize = true;
            this.label119.BackColor = System.Drawing.Color.Transparent;
            this.label119.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label119.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label119.Location = new System.Drawing.Point(489, 30);
            this.label119.Name = "label119";
            this.label119.Size = new System.Drawing.Size(83, 13);
            this.label119.TabIndex = 887;
            this.label119.Text = "تاريـخ الميــــلاد :";
            // 
            // label118
            // 
            this.label118.AutoSize = true;
            this.label118.BackColor = System.Drawing.Color.Transparent;
            this.label118.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label118.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label118.Location = new System.Drawing.Point(315, 8);
            this.label118.Name = "label118";
            this.label118.Size = new System.Drawing.Size(90, 13);
            this.label118.TabIndex = 886;
            this.label118.Text = "الحالة الإجتماعية :";
            // 
            // label117
            // 
            this.label117.AutoSize = true;
            this.label117.BackColor = System.Drawing.Color.Transparent;
            this.label117.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label117.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label117.Location = new System.Drawing.Point(315, 30);
            this.label117.Name = "label117";
            this.label117.Size = new System.Drawing.Size(90, 13);
            this.label117.TabIndex = 881;
            this.label117.Text = "مكان الميـــــــلاد :";
            // 
            // label115
            // 
            this.label115.AutoSize = true;
            this.label115.BackColor = System.Drawing.Color.Transparent;
            this.label115.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label115.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label115.Location = new System.Drawing.Point(65, 30);
            this.label115.Name = "label115";
            this.label115.Size = new System.Drawing.Size(64, 13);
            this.label115.TabIndex = 877;
            this.label115.Text = "فصيلة الدم :";
            // 
            // label114
            // 
            this.label114.AutoSize = true;
            this.label114.BackColor = System.Drawing.Color.Transparent;
            this.label114.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label114.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label114.Location = new System.Drawing.Point(489, 8);
            this.label114.Name = "label114";
            this.label114.Size = new System.Drawing.Size(81, 13);
            this.label114.TabIndex = 875;
            this.label114.Text = "الجنــــــــــــس :";
            // 
            // label113
            // 
            this.label113.AutoSize = true;
            this.label113.BackColor = System.Drawing.Color.Transparent;
            this.label113.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label113.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label113.Location = new System.Drawing.Point(180, 8);
            this.label113.Name = "label113";
            this.label113.Size = new System.Drawing.Size(41, 13);
            this.label113.TabIndex = 873;
            this.label113.Text = "الديانة :";
            // 
            // button_AddNewReligon
            // 
            this.button_AddNewReligon.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_AddNewReligon.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_AddNewReligon.Location = new System.Drawing.Point(10, 4);
            this.button_AddNewReligon.Name = "button_AddNewReligon";
            this.button_AddNewReligon.Size = new System.Drawing.Size(26, 20);
            this.button_AddNewReligon.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_AddNewReligon.Symbol = "";
            this.button_AddNewReligon.SymbolSize = 11F;
            this.button_AddNewReligon.TabIndex = 6680;
            this.button_AddNewReligon.TextColor = System.Drawing.Color.SteelBlue;
            this.button_AddNewReligon.Click += new System.EventHandler(this.button_AddNewReligon_Click);
            // 
            // button_SrchReligion
            // 
            this.button_SrchReligion.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchReligion.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchReligion.Location = new System.Drawing.Point(37, 4);
            this.button_SrchReligion.Name = "button_SrchReligion";
            this.button_SrchReligion.Size = new System.Drawing.Size(26, 20);
            this.button_SrchReligion.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchReligion.Symbol = "";
            this.button_SrchReligion.SymbolSize = 12F;
            this.button_SrchReligion.TabIndex = 6679;
            this.button_SrchReligion.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchReligion.Click += new System.EventHandler(this.button_SrchReligion_Click);
            // 
            // button_SrchReligon
            // 
            this.button_SrchReligon.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchReligon.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchReligon.Location = new System.Drawing.Point(37, 4);
            this.button_SrchReligon.Name = "button_SrchReligon";
            this.button_SrchReligon.Size = new System.Drawing.Size(26, 20);
            this.button_SrchReligon.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchReligon.Symbol = "";
            this.button_SrchReligon.SymbolSize = 12F;
            this.button_SrchReligon.TabIndex = 6679;
            this.button_SrchReligon.TextColor = System.Drawing.Color.SteelBlue;
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Dash;
            this.labelX1.BackgroundStyle.BorderBottomColor = System.Drawing.Color.SteelBlue;
            this.labelX1.BackgroundStyle.BorderBottomWidth = 1;
            this.labelX1.BackgroundStyle.BorderColor = System.Drawing.Color.SteelBlue;
            this.labelX1.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Dash;
            this.labelX1.BackgroundStyle.BorderLeftColor = System.Drawing.Color.SteelBlue;
            this.labelX1.BackgroundStyle.BorderLeftWidth = 1;
            this.labelX1.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Dash;
            this.labelX1.BackgroundStyle.BorderRightColor = System.Drawing.Color.SteelBlue;
            this.labelX1.BackgroundStyle.BorderRightWidth = 1;
            this.labelX1.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Dash;
            this.labelX1.BackgroundStyle.BorderTopColor = System.Drawing.Color.SteelBlue;
            this.labelX1.BackgroundStyle.BorderTopWidth = 1;
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.ForeColor = System.Drawing.Color.Red;
            this.labelX1.Location = new System.Drawing.Point(24, 171);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(127, 19);
            this.labelX1.Symbol = "";
            this.labelX1.SymbolColor = System.Drawing.Color.SteelBlue;
            this.labelX1.SymbolSize = 12F;
            this.labelX1.TabIndex = 1605;
            this.labelX1.Text = "صورة الموظف";
            this.labelX1.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // checkBox_ClearPic
            // 
            this.checkBox_ClearPic.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.checkBox_ClearPic.Checked = true;
            this.checkBox_ClearPic.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.checkBox_ClearPic.Location = new System.Drawing.Point(3, 44);
            this.checkBox_ClearPic.Name = "checkBox_ClearPic";
            this.checkBox_ClearPic.Size = new System.Drawing.Size(19, 125);
            this.checkBox_ClearPic.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBox_ClearPic.Symbol = "";
            this.checkBox_ClearPic.SymbolSize = 11F;
            this.checkBox_ClearPic.TabIndex = 1603;
            this.checkBox_ClearPic.TextColor = System.Drawing.Color.SteelBlue;
            this.checkBox_ClearPic.Tooltip = "إزالة الصورة";
            this.checkBox_ClearPic.Click += new System.EventHandler(this.checkBox_ClearPic_Click);
            // 
            // button_Pic
            // 
            this.button_Pic.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_Pic.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_Pic.Location = new System.Drawing.Point(3, 170);
            this.button_Pic.Name = "button_Pic";
            this.button_Pic.Size = new System.Drawing.Size(19, 20);
            this.button_Pic.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_Pic.Symbol = "";
            this.button_Pic.SymbolSize = 11F;
            this.button_Pic.TabIndex = 1604;
            this.button_Pic.TextColor = System.Drawing.Color.SteelBlue;
            this.button_Pic.Tooltip = "إضافة صورة للصنف";
            this.button_Pic.Click += new System.EventHandler(this.button_Pic_Click);
            // 
            // comboBox_Nationalty
            // 
            this.comboBox_Nationalty.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox_Nationalty.DisplayMember = "Text";
            this.comboBox_Nationalty.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBox_Nationalty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Nationalty.FormattingEnabled = true;
            this.comboBox_Nationalty.ItemHeight = 14;
            this.comboBox_Nationalty.Location = new System.Drawing.Point(60, 194);
            this.comboBox_Nationalty.Name = "comboBox_Nationalty";
            this.comboBox_Nationalty.Size = new System.Drawing.Size(430, 20);
            this.comboBox_Nationalty.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBox_Nationalty.TabIndex = 9;
            this.comboBox_Nationalty.SelectedValueChanged += new System.EventHandler(this.comboBox_Nationalty_SelectedValueChanged);
            // 
            // button_AddNewNation
            // 
            this.button_AddNewNation.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_AddNewNation.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_AddNewNation.Location = new System.Drawing.Point(3, 194);
            this.button_AddNewNation.Name = "button_AddNewNation";
            this.button_AddNewNation.Size = new System.Drawing.Size(26, 20);
            this.button_AddNewNation.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_AddNewNation.Symbol = "";
            this.button_AddNewNation.SymbolSize = 11F;
            this.button_AddNewNation.TabIndex = 1601;
            this.button_AddNewNation.TextColor = System.Drawing.Color.SteelBlue;
            this.button_AddNewNation.Visible = false;
            this.button_AddNewNation.Click += new System.EventHandler(this.button_AddNewNation_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(490, 198);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 13);
            this.label5.TabIndex = 1602;
            this.label5.Text = "الجنسيـــــــــــــة :";
            // 
            // comboBox_Guarantor
            // 
            this.comboBox_Guarantor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox_Guarantor.DisplayMember = "Text";
            this.comboBox_Guarantor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBox_Guarantor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Guarantor.FormattingEnabled = true;
            this.comboBox_Guarantor.ItemHeight = 14;
            this.comboBox_Guarantor.Location = new System.Drawing.Point(211, 169);
            this.comboBox_Guarantor.Name = "comboBox_Guarantor";
            this.comboBox_Guarantor.Size = new System.Drawing.Size(279, 20);
            this.comboBox_Guarantor.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBox_Guarantor.TabIndex = 8;
            // 
            // button_AddNewSponser
            // 
            this.button_AddNewSponser.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_AddNewSponser.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_AddNewSponser.Location = new System.Drawing.Point(154, 170);
            this.button_AddNewSponser.Name = "button_AddNewSponser";
            this.button_AddNewSponser.Size = new System.Drawing.Size(26, 20);
            this.button_AddNewSponser.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_AddNewSponser.Symbol = "";
            this.button_AddNewSponser.SymbolSize = 11F;
            this.button_AddNewSponser.TabIndex = 1597;
            this.button_AddNewSponser.TextColor = System.Drawing.Color.SteelBlue;
            this.button_AddNewSponser.Click += new System.EventHandler(this.button_AddNewSponser_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(490, 173);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 13);
            this.label4.TabIndex = 1598;
            this.label4.Text = "إســـــــم الكفيل :";
            // 
            // comboBox_Job
            // 
            this.comboBox_Job.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox_Job.DisplayMember = "Text";
            this.comboBox_Job.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBox_Job.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Job.FormattingEnabled = true;
            this.comboBox_Job.ItemHeight = 14;
            this.comboBox_Job.Location = new System.Drawing.Point(211, 144);
            this.comboBox_Job.Name = "comboBox_Job";
            this.comboBox_Job.Size = new System.Drawing.Size(279, 20);
            this.comboBox_Job.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBox_Job.TabIndex = 7;
            // 
            // button_AddNewJob
            // 
            this.button_AddNewJob.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_AddNewJob.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_AddNewJob.Location = new System.Drawing.Point(154, 144);
            this.button_AddNewJob.Name = "button_AddNewJob";
            this.button_AddNewJob.Size = new System.Drawing.Size(26, 20);
            this.button_AddNewJob.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_AddNewJob.Symbol = "";
            this.button_AddNewJob.SymbolSize = 11F;
            this.button_AddNewJob.TabIndex = 1593;
            this.button_AddNewJob.TextColor = System.Drawing.Color.SteelBlue;
            this.button_AddNewJob.Click += new System.EventHandler(this.button_AddNewJob_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(490, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 1594;
            this.label3.Text = "إســـــم الوظيفة :";
            // 
            // comboBox_Section
            // 
            this.comboBox_Section.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox_Section.DisplayMember = "Text";
            this.comboBox_Section.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBox_Section.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Section.FormattingEnabled = true;
            this.comboBox_Section.ItemHeight = 14;
            this.comboBox_Section.Location = new System.Drawing.Point(211, 119);
            this.comboBox_Section.Name = "comboBox_Section";
            this.comboBox_Section.Size = new System.Drawing.Size(279, 20);
            this.comboBox_Section.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBox_Section.TabIndex = 6;
            // 
            // button_AddNewSection
            // 
            this.button_AddNewSection.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_AddNewSection.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_AddNewSection.Location = new System.Drawing.Point(154, 118);
            this.button_AddNewSection.Name = "button_AddNewSection";
            this.button_AddNewSection.Size = new System.Drawing.Size(26, 20);
            this.button_AddNewSection.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_AddNewSection.Symbol = "";
            this.button_AddNewSection.SymbolSize = 11F;
            this.button_AddNewSection.TabIndex = 1589;
            this.button_AddNewSection.TextColor = System.Drawing.Color.SteelBlue;
            this.button_AddNewSection.Click += new System.EventHandler(this.button_AddNewSection_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(490, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 1590;
            this.label2.Text = "إســــــم القسم :";
            // 
            // comboBox_Dept
            // 
            this.comboBox_Dept.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox_Dept.DisplayMember = "Text";
            this.comboBox_Dept.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBox_Dept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Dept.FormattingEnabled = true;
            this.comboBox_Dept.ItemHeight = 14;
            this.comboBox_Dept.Location = new System.Drawing.Point(211, 94);
            this.comboBox_Dept.Name = "comboBox_Dept";
            this.comboBox_Dept.Size = new System.Drawing.Size(279, 20);
            this.comboBox_Dept.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBox_Dept.TabIndex = 5;
            // 
            // button_AddNewDept
            // 
            this.button_AddNewDept.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_AddNewDept.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_AddNewDept.Location = new System.Drawing.Point(154, 93);
            this.button_AddNewDept.Name = "button_AddNewDept";
            this.button_AddNewDept.Size = new System.Drawing.Size(26, 20);
            this.button_AddNewDept.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_AddNewDept.Symbol = "";
            this.button_AddNewDept.SymbolSize = 11F;
            this.button_AddNewDept.TabIndex = 1585;
            this.button_AddNewDept.TextColor = System.Drawing.Color.SteelBlue;
            this.button_AddNewDept.Click += new System.EventHandler(this.button_AddNewDept_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label12.Location = new System.Drawing.Point(490, 98);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(90, 13);
            this.label12.TabIndex = 1586;
            this.label12.Text = "إســــــــم الإدارة :";
            // 
            // textBox_Pass
            // 
            this.textBox_Pass.BackColor = System.Drawing.Color.Red;
            this.textBox_Pass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_Pass.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.textBox_Pass.ForeColor = System.Drawing.Color.White;
            this.textBox_Pass.Location = new System.Drawing.Point(3, 19);
            this.textBox_Pass.MaxLength = 10;
            this.textBox_Pass.Name = "textBox_Pass";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_Pass, false);
            this.textBox_Pass.PasswordChar = '*';
            this.textBox_Pass.Size = new System.Drawing.Size(148, 20);
            this.textBox_Pass.TabIndex = 2;
            this.textBox_Pass.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.BackColor = System.Drawing.Color.Transparent;
            this.label52.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label52.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label52.Location = new System.Drawing.Point(152, 23);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(93, 13);
            this.label52.TabIndex = 99;
            this.label52.Text = "كلمة سر الموظف :";
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.BackColor = System.Drawing.Color.Transparent;
            this.label40.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label40.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label40.Location = new System.Drawing.Point(490, 73);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(89, 13);
            this.label40.TabIndex = 71;
            this.label40.Text = "الإسم الإنجليزي :";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.BackColor = System.Drawing.Color.Transparent;
            this.label36.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label36.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label36.Location = new System.Drawing.Point(490, 48);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(89, 13);
            this.label36.TabIndex = 69;
            this.label36.Text = "الإسم العــــربي :";
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.BackColor = System.Drawing.Color.Transparent;
            this.label38.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label38.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label38.Location = new System.Drawing.Point(490, 23);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(89, 13);
            this.label38.TabIndex = 67;
            this.label38.Text = "الرقـــــــــــــــــم :";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.textBox_CompPaying);
            this.groupBox2.Controls.Add(this.textBox_SalSubtract);
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.groupBox2.ForeColor = System.Drawing.Color.SteelBlue;
            this.groupBox2.Location = new System.Drawing.Point(-258, 196);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(224, 63);
            this.groupBox2.TabIndex = 1608;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "التأمين الإجتماعي";
            this.groupBox2.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(10, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 82;
            this.label1.Text = "%";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(10, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(20, 13);
            this.label6.TabIndex = 81;
            this.label6.Text = "%";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(109, 41);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(107, 13);
            this.label7.TabIndex = 79;
            this.label7.Text = "مستحق من الشركة :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(109, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(106, 13);
            this.label8.TabIndex = 77;
            this.label8.Text = "يخصــــــم من الراتب :";
            // 
            // textBox_CompPaying
            // 
            this.textBox_CompPaying.AllowEmptyState = false;
            this.textBox_CompPaying.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
            this.textBox_CompPaying.AutoOffFreeTextEntry = true;
            this.textBox_CompPaying.AutoResolveFreeTextEntries = false;
            // 
            // 
            // 
            this.textBox_CompPaying.BackgroundStyle.BorderBottomWidth = 1;
            this.textBox_CompPaying.BackgroundStyle.Class = "DateTimeInputBackground";
            this.textBox_CompPaying.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBox_CompPaying.BackgroundStyle.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_CompPaying.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.textBox_CompPaying.DisplayFormat = "0.00";
            this.textBox_CompPaying.Enabled = false;
            this.textBox_CompPaying.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.textBox_CompPaying.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.textBox_CompPaying.Increment = 1D;
            this.textBox_CompPaying.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.textBox_CompPaying.Location = new System.Drawing.Point(35, 37);
            this.textBox_CompPaying.MaxValue = 100D;
            this.textBox_CompPaying.MinValue = 0D;
            this.textBox_CompPaying.Name = "textBox_CompPaying";
            this.textBox_CompPaying.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox_CompPaying.Size = new System.Drawing.Size(68, 21);
            this.textBox_CompPaying.TabIndex = 841;
            // 
            // textBox_SalSubtract
            // 
            this.textBox_SalSubtract.AllowEmptyState = false;
            this.textBox_SalSubtract.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
            this.textBox_SalSubtract.AutoOffFreeTextEntry = true;
            this.textBox_SalSubtract.AutoResolveFreeTextEntries = false;
            // 
            // 
            // 
            this.textBox_SalSubtract.BackgroundStyle.BorderBottomWidth = 1;
            this.textBox_SalSubtract.BackgroundStyle.Class = "DateTimeInputBackground";
            this.textBox_SalSubtract.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBox_SalSubtract.BackgroundStyle.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_SalSubtract.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.textBox_SalSubtract.DisplayFormat = "0.00";
            this.textBox_SalSubtract.Enabled = false;
            this.textBox_SalSubtract.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.textBox_SalSubtract.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.textBox_SalSubtract.Increment = 1D;
            this.textBox_SalSubtract.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.textBox_SalSubtract.Location = new System.Drawing.Point(35, 16);
            this.textBox_SalSubtract.MaxValue = 100D;
            this.textBox_SalSubtract.MinValue = 0D;
            this.textBox_SalSubtract.Name = "textBox_SalSubtract";
            this.textBox_SalSubtract.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox_SalSubtract.Size = new System.Drawing.Size(68, 21);
            this.textBox_SalSubtract.TabIndex = 840;
            // 
            // textBox_ID
            // 
            this.textBox_ID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.textBox_ID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_ID.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.textBox_ID.Location = new System.Drawing.Point(360, 19);
            this.textBox_ID.MaxLength = 6;
            this.textBox_ID.Name = "textBox_ID";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_ID, false);
            this.textBox_ID.Size = new System.Drawing.Size(130, 21);
            this.textBox_ID.TabIndex = 1;
            this.textBox_ID.TextChanged += new System.EventHandler(this.textBox_ID_TextChanged);
            this.textBox_ID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_ID_KeyPress);
            // 
            // linkLabel_ChangeEmpNo
            // 
            this.linkLabel_ChangeEmpNo.AutoSize = true;
            this.linkLabel_ChangeEmpNo.Font = new System.Drawing.Font("Tahoma", 8F);
            this.linkLabel_ChangeEmpNo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.linkLabel_ChangeEmpNo.Location = new System.Drawing.Point(325, 22);
            this.linkLabel_ChangeEmpNo.Name = "linkLabel_ChangeEmpNo";
            this.linkLabel_ChangeEmpNo.Size = new System.Drawing.Size(32, 13);
            this.linkLabel_ChangeEmpNo.TabIndex = 6685;
            this.linkLabel_ChangeEmpNo.TabStop = true;
            this.linkLabel_ChangeEmpNo.Text = "تغـيير";
            this.linkLabel_ChangeEmpNo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_ChangeEmpNo_LinkClicked);
            // 
            // button_PhotoShoot
            // 
            this.button_PhotoShoot.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_PhotoShoot.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_PhotoShoot.Location = new System.Drawing.Point(3, 170);
            this.button_PhotoShoot.Name = "button_PhotoShoot";
            this.button_PhotoShoot.Size = new System.Drawing.Size(19, 20);
            this.button_PhotoShoot.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_PhotoShoot.Symbol = "";
            this.button_PhotoShoot.SymbolSize = 11F;
            this.button_PhotoShoot.TabIndex = 1607;
            this.button_PhotoShoot.TextColor = System.Drawing.Color.SteelBlue;
            this.button_PhotoShoot.Tooltip = "إضافة صورة للصنف";
            this.button_PhotoShoot.Visible = false;
            this.button_PhotoShoot.Click += new System.EventHandler(this.button_PhotoShoot_Click);
            // 
            // labelX15
            // 
            this.labelX15.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX15.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelX15.Location = new System.Drawing.Point(0, 0);
            this.labelX15.Name = "labelX15";
            this.labelX15.Size = new System.Drawing.Size(594, 419);
            this.labelX15.TabIndex = 8;
            this.labelX15.Text = "This space intentionally left blank.";
            this.labelX15.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // superTabItem_Gen
            // 
            this.superTabItem_Gen.AttachedControl = this.superTabControlPanel15;
            this.superTabItem_Gen.CloseButtonVisible = false;
            this.superTabItem_Gen.GlobalItem = false;
            this.superTabItem_Gen.Name = "superTabItem_Gen";
            this.superTabItem_Gen.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Apple;
            this.superTabItem_Gen.Text = "عــــــــــام";
            // 
            // superTabControlPanel1
            // 
            this.superTabControlPanel1.Controls.Add(this.panelEx8);
            this.superTabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel1.Location = new System.Drawing.Point(0, 0);
            this.superTabControlPanel1.Name = "superTabControlPanel1";
            this.superTabControlPanel1.Size = new System.Drawing.Size(594, 419);
            this.superTabControlPanel1.TabIndex = 0;
            this.superTabControlPanel1.TabItem = this.superTabItem_Family;
            // 
            // panelEx8
            // 
            this.panelEx8.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx8.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx8.Controls.Add(this.groupBox9);
            this.panelEx8.Controls.Add(this.button_SaveFamily);
            this.panelEx8.Controls.Add(this.dateTimeInput_PassportDateEnd15);
            this.panelEx8.Controls.Add(this.dateTimeInput_PassportDateEnd14);
            this.panelEx8.Controls.Add(this.dateTimeInput_PassportDateEnd13);
            this.panelEx8.Controls.Add(this.dateTimeInput_PassportDateEnd12);
            this.panelEx8.Controls.Add(this.dateTimeInput_PassportDateEnd11);
            this.panelEx8.Controls.Add(this.dateTimeInput_PassportDateEnd10);
            this.panelEx8.Controls.Add(this.dateTimeInput_PassportDateEnd9);
            this.panelEx8.Controls.Add(this.dateTimeInput_PassportDateEnd8);
            this.panelEx8.Controls.Add(this.dateTimeInput_PassportDateEnd7);
            this.panelEx8.Controls.Add(this.dateTimeInput_PassportDateEnd6);
            this.panelEx8.Controls.Add(this.dateTimeInput_PassportDateEnd5);
            this.panelEx8.Controls.Add(this.dateTimeInput_PassportDateEnd4);
            this.panelEx8.Controls.Add(this.dateTimeInput_PassportDateEnd3);
            this.panelEx8.Controls.Add(this.dateTimeInput_PassportDateEnd2);
            this.panelEx8.Controls.Add(this.dateTimeInput_PassportDateEnd1);
            this.panelEx8.Controls.Add(this.dateTimeInput_BirthDate15);
            this.panelEx8.Controls.Add(this.dateTimeInput_BirthDate14);
            this.panelEx8.Controls.Add(this.dateTimeInput_BirthDate13);
            this.panelEx8.Controls.Add(this.dateTimeInput_BirthDate12);
            this.panelEx8.Controls.Add(this.dateTimeInput_BirthDate11);
            this.panelEx8.Controls.Add(this.dateTimeInput_BirthDate10);
            this.panelEx8.Controls.Add(this.dateTimeInput_BirthDate9);
            this.panelEx8.Controls.Add(this.dateTimeInput_BirthDate8);
            this.panelEx8.Controls.Add(this.dateTimeInput_BirthDate7);
            this.panelEx8.Controls.Add(this.dateTimeInput_BirthDate6);
            this.panelEx8.Controls.Add(this.dateTimeInput_BirthDate5);
            this.panelEx8.Controls.Add(this.dateTimeInput_BirthDate4);
            this.panelEx8.Controls.Add(this.dateTimeInput_BirthDate3);
            this.panelEx8.Controls.Add(this.dateTimeInput_BirthDate2);
            this.panelEx8.Controls.Add(this.dateTimeInput_BirthDate1);
            this.panelEx8.Controls.Add(this.label122);
            this.panelEx8.Controls.Add(this.label123);
            this.panelEx8.Controls.Add(this.label128);
            this.panelEx8.Controls.Add(this.label129);
            this.panelEx8.Controls.Add(this.textBox_PassporntNo15);
            this.panelEx8.Controls.Add(this.textBox_Relation15);
            this.panelEx8.Controls.Add(this.textBox_Name15);
            this.panelEx8.Controls.Add(this.textBox_PassporntNo14);
            this.panelEx8.Controls.Add(this.textBox_Relation14);
            this.panelEx8.Controls.Add(this.textBox_Name14);
            this.panelEx8.Controls.Add(this.textBox_PassporntNo13);
            this.panelEx8.Controls.Add(this.textBox_Relation13);
            this.panelEx8.Controls.Add(this.textBox_Name13);
            this.panelEx8.Controls.Add(this.textBox_PassporntNo12);
            this.panelEx8.Controls.Add(this.textBox_Relation12);
            this.panelEx8.Controls.Add(this.textBox_Name12);
            this.panelEx8.Controls.Add(this.textBox_PassporntNo11);
            this.panelEx8.Controls.Add(this.textBox_Relation11);
            this.panelEx8.Controls.Add(this.textBox_Name11);
            this.panelEx8.Controls.Add(this.textBox_PassporntNo10);
            this.panelEx8.Controls.Add(this.textBox_Relation10);
            this.panelEx8.Controls.Add(this.textBox_Name10);
            this.panelEx8.Controls.Add(this.textBox_PassporntNo9);
            this.panelEx8.Controls.Add(this.textBox_Relation9);
            this.panelEx8.Controls.Add(this.textBox_Name9);
            this.panelEx8.Controls.Add(this.textBox_PassporntNo8);
            this.panelEx8.Controls.Add(this.textBox_Relation8);
            this.panelEx8.Controls.Add(this.textBox_Name8);
            this.panelEx8.Controls.Add(this.textBox_PassporntNo7);
            this.panelEx8.Controls.Add(this.textBox_Relation7);
            this.panelEx8.Controls.Add(this.textBox_Name7);
            this.panelEx8.Controls.Add(this.textBox_PassporntNo6);
            this.panelEx8.Controls.Add(this.textBox_Relation6);
            this.panelEx8.Controls.Add(this.textBox_Name6);
            this.panelEx8.Controls.Add(this.textBox_PassporntNo5);
            this.panelEx8.Controls.Add(this.textBox_Relation5);
            this.panelEx8.Controls.Add(this.textBox_Name5);
            this.panelEx8.Controls.Add(this.textBox_PassporntNo4);
            this.panelEx8.Controls.Add(this.textBox_Relation4);
            this.panelEx8.Controls.Add(this.textBox_Name4);
            this.panelEx8.Controls.Add(this.textBox_PassporntNo3);
            this.panelEx8.Controls.Add(this.textBox_Relation3);
            this.panelEx8.Controls.Add(this.textBox_Name3);
            this.panelEx8.Controls.Add(this.textBox_PassporntNo2);
            this.panelEx8.Controls.Add(this.textBox_Relation2);
            this.panelEx8.Controls.Add(this.textBox_Name2);
            this.panelEx8.Controls.Add(this.textBox_PassporntNo1);
            this.panelEx8.Controls.Add(this.textBox_Relation1);
            this.panelEx8.Controls.Add(this.textBox_Name1);
            this.panelEx8.Controls.Add(this.label132);
            this.panelEx8.Controls.Add(this.textBox_Note);
            this.panelEx8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx8.Location = new System.Drawing.Point(0, 0);
            this.panelEx8.Name = "panelEx8";
            this.panelEx8.Size = new System.Drawing.Size(594, 419);
            this.panelEx8.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx8.Style.BackColor1.Color = System.Drawing.Color.AliceBlue;
            this.panelEx8.Style.BackColor2.Color = System.Drawing.SystemColors.GradientActiveCaption;
            this.panelEx8.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx8.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx8.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx8.Style.GradientAngle = 90;
            this.panelEx8.TabIndex = 6682;
            // 
            // groupBox9
            // 
            this.groupBox9.BackColor = System.Drawing.Color.Transparent;
            this.groupBox9.Controls.Add(this.textBox_Insurance_Class);
            this.groupBox9.Controls.Add(this.label121);
            this.groupBox9.Controls.Add(this.comboBox_InsuranceType);
            this.groupBox9.Controls.Add(this.button_InsuranceType);
            this.groupBox9.Controls.Add(this.bubbleButton_InsuranceType);
            this.groupBox9.Controls.Add(this.label120);
            this.groupBox9.Location = new System.Drawing.Point(10, 2);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(568, 74);
            this.groupBox9.TabIndex = 6692;
            this.groupBox9.TabStop = false;
            // 
            // textBox_Insurance_Class
            // 
            this.textBox_Insurance_Class.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_Insurance_Class.Enabled = false;
            this.textBox_Insurance_Class.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.textBox_Insurance_Class.Location = new System.Drawing.Point(160, 45);
            this.textBox_Insurance_Class.MaxLength = 30;
            this.textBox_Insurance_Class.Name = "textBox_Insurance_Class";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_Insurance_Class, false);
            this.textBox_Insurance_Class.Size = new System.Drawing.Size(234, 21);
            this.textBox_Insurance_Class.TabIndex = 6692;
            this.textBox_Insurance_Class.Click += new System.EventHandler(this.textBox_Insurance_Class_Click);
            // 
            // label121
            // 
            this.label121.AutoSize = true;
            this.label121.BackColor = System.Drawing.Color.Transparent;
            this.label121.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label121.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label121.Location = new System.Drawing.Point(395, 47);
            this.label121.Name = "label121";
            this.label121.Size = new System.Drawing.Size(72, 13);
            this.label121.TabIndex = 6693;
            this.label121.Text = "الفئــــــــــــة :";
            // 
            // comboBox_InsuranceType
            // 
            this.comboBox_InsuranceType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox_InsuranceType.DisplayMember = "Text";
            this.comboBox_InsuranceType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBox_InsuranceType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_InsuranceType.FormattingEnabled = true;
            this.comboBox_InsuranceType.ItemHeight = 14;
            this.comboBox_InsuranceType.Location = new System.Drawing.Point(146, 17);
            this.comboBox_InsuranceType.Name = "comboBox_InsuranceType";
            this.comboBox_InsuranceType.Size = new System.Drawing.Size(248, 20);
            this.comboBox_InsuranceType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBox_InsuranceType.TabIndex = 6688;
            this.comboBox_InsuranceType.SelectedIndexChanged += new System.EventHandler(this.comboBox_InsuranceType_SelectedIndexChanged);
            // 
            // button_InsuranceType
            // 
            this.button_InsuranceType.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_InsuranceType.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_InsuranceType.Location = new System.Drawing.Point(92, 17);
            this.button_InsuranceType.Name = "button_InsuranceType";
            this.button_InsuranceType.Size = new System.Drawing.Size(26, 20);
            this.button_InsuranceType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_InsuranceType.Symbol = "";
            this.button_InsuranceType.SymbolSize = 11F;
            this.button_InsuranceType.TabIndex = 6690;
            this.button_InsuranceType.TextColor = System.Drawing.Color.SteelBlue;
            this.button_InsuranceType.Click += new System.EventHandler(this.button_InsuranceType_Click);
            // 
            // bubbleButton_InsuranceType
            // 
            this.bubbleButton_InsuranceType.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.bubbleButton_InsuranceType.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.bubbleButton_InsuranceType.Location = new System.Drawing.Point(119, 17);
            this.bubbleButton_InsuranceType.Name = "bubbleButton_InsuranceType";
            this.bubbleButton_InsuranceType.Size = new System.Drawing.Size(26, 20);
            this.bubbleButton_InsuranceType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bubbleButton_InsuranceType.Symbol = "";
            this.bubbleButton_InsuranceType.SymbolSize = 12F;
            this.bubbleButton_InsuranceType.TabIndex = 6689;
            this.bubbleButton_InsuranceType.TextColor = System.Drawing.Color.SteelBlue;
            this.bubbleButton_InsuranceType.Click += new System.EventHandler(this.bubbleButton_InsuranceType_Click);
            // 
            // label120
            // 
            this.label120.AutoSize = true;
            this.label120.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label120.Location = new System.Drawing.Point(395, 21);
            this.label120.Name = "label120";
            this.label120.Size = new System.Drawing.Size(111, 13);
            this.label120.TabIndex = 6691;
            this.label120.Text = "شركة التأمين الصحي :";
            // 
            // button_SaveFamily
            // 
            this.button_SaveFamily.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SaveFamily.Checked = true;
            this.button_SaveFamily.ColorTable = DevComponents.DotNetBar.eButtonColor.Orange;
            this.button_SaveFamily.Location = new System.Drawing.Point(6, 375);
            this.button_SaveFamily.Name = "button_SaveFamily";
            this.button_SaveFamily.Size = new System.Drawing.Size(573, 40);
            this.button_SaveFamily.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SaveFamily.Symbol = "";
            this.button_SaveFamily.TabIndex = 6691;
            this.button_SaveFamily.Text = "حفظ المرافقين";
            this.button_SaveFamily.Click += new System.EventHandler(this.button_SaveFamily_Click);
            // 
            // dateTimeInput_PassportDateEnd15
            // 
            this.dateTimeInput_PassportDateEnd15.Location = new System.Drawing.Point(-615, 355);
            this.dateTimeInput_PassportDateEnd15.Mask = "0000/00/00";
            this.dateTimeInput_PassportDateEnd15.Name = "dateTimeInput_PassportDateEnd15";
            this.dateTimeInput_PassportDateEnd15.Size = new System.Drawing.Size(98, 20);
            this.dateTimeInput_PassportDateEnd15.TabIndex = 298;
            this.dateTimeInput_PassportDateEnd15.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dateTimeInput_PassportDateEnd15.Click += new System.EventHandler(this.dateTimeInput_PassportDateEnd15_Click);
            this.dateTimeInput_PassportDateEnd15.Leave += new System.EventHandler(this.dateTimeInput_PassportDateEnd15_Leave);
            // 
            // dateTimeInput_PassportDateEnd14
            // 
            this.dateTimeInput_PassportDateEnd14.Location = new System.Drawing.Point(-615, 334);
            this.dateTimeInput_PassportDateEnd14.Mask = "0000/00/00";
            this.dateTimeInput_PassportDateEnd14.Name = "dateTimeInput_PassportDateEnd14";
            this.dateTimeInput_PassportDateEnd14.Size = new System.Drawing.Size(98, 20);
            this.dateTimeInput_PassportDateEnd14.TabIndex = 293;
            this.dateTimeInput_PassportDateEnd14.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dateTimeInput_PassportDateEnd14.Click += new System.EventHandler(this.dateTimeInput_PassportDateEnd14_Click);
            this.dateTimeInput_PassportDateEnd14.Leave += new System.EventHandler(this.dateTimeInput_PassportDateEnd14_Leave);
            // 
            // dateTimeInput_PassportDateEnd13
            // 
            this.dateTimeInput_PassportDateEnd13.Location = new System.Drawing.Point(-615, 313);
            this.dateTimeInput_PassportDateEnd13.Mask = "0000/00/00";
            this.dateTimeInput_PassportDateEnd13.Name = "dateTimeInput_PassportDateEnd13";
            this.dateTimeInput_PassportDateEnd13.Size = new System.Drawing.Size(98, 20);
            this.dateTimeInput_PassportDateEnd13.TabIndex = 288;
            this.dateTimeInput_PassportDateEnd13.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dateTimeInput_PassportDateEnd13.Click += new System.EventHandler(this.dateTimeInput_PassportDateEnd13_Click);
            this.dateTimeInput_PassportDateEnd13.Leave += new System.EventHandler(this.dateTimeInput_PassportDateEnd13_Leave);
            // 
            // dateTimeInput_PassportDateEnd12
            // 
            this.dateTimeInput_PassportDateEnd12.Location = new System.Drawing.Point(-615, 292);
            this.dateTimeInput_PassportDateEnd12.Mask = "0000/00/00";
            this.dateTimeInput_PassportDateEnd12.Name = "dateTimeInput_PassportDateEnd12";
            this.dateTimeInput_PassportDateEnd12.Size = new System.Drawing.Size(98, 20);
            this.dateTimeInput_PassportDateEnd12.TabIndex = 283;
            this.dateTimeInput_PassportDateEnd12.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dateTimeInput_PassportDateEnd12.Click += new System.EventHandler(this.dateTimeInput_PassportDateEnd12_Click);
            this.dateTimeInput_PassportDateEnd12.Leave += new System.EventHandler(this.dateTimeInput_PassportDateEnd12_Leave);
            // 
            // dateTimeInput_PassportDateEnd11
            // 
            this.dateTimeInput_PassportDateEnd11.Location = new System.Drawing.Point(-615, 271);
            this.dateTimeInput_PassportDateEnd11.Mask = "0000/00/00";
            this.dateTimeInput_PassportDateEnd11.Name = "dateTimeInput_PassportDateEnd11";
            this.dateTimeInput_PassportDateEnd11.Size = new System.Drawing.Size(98, 20);
            this.dateTimeInput_PassportDateEnd11.TabIndex = 278;
            this.dateTimeInput_PassportDateEnd11.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dateTimeInput_PassportDateEnd11.Click += new System.EventHandler(this.dateTimeInput_PassportDateEnd11_Click);
            this.dateTimeInput_PassportDateEnd11.Leave += new System.EventHandler(this.dateTimeInput_PassportDateEnd11_Leave);
            // 
            // dateTimeInput_PassportDateEnd10
            // 
            this.dateTimeInput_PassportDateEnd10.Location = new System.Drawing.Point(6, 351);
            this.dateTimeInput_PassportDateEnd10.Mask = "0000/00/00";
            this.dateTimeInput_PassportDateEnd10.Name = "dateTimeInput_PassportDateEnd10";
            this.dateTimeInput_PassportDateEnd10.Size = new System.Drawing.Size(98, 20);
            this.dateTimeInput_PassportDateEnd10.TabIndex = 273;
            this.dateTimeInput_PassportDateEnd10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dateTimeInput_PassportDateEnd10.Click += new System.EventHandler(this.dateTimeInput_PassportDateEnd10_Click);
            this.dateTimeInput_PassportDateEnd10.Leave += new System.EventHandler(this.dateTimeInput_PassportDateEnd10_Leave);
            // 
            // dateTimeInput_PassportDateEnd9
            // 
            this.dateTimeInput_PassportDateEnd9.Location = new System.Drawing.Point(6, 330);
            this.dateTimeInput_PassportDateEnd9.Mask = "0000/00/00";
            this.dateTimeInput_PassportDateEnd9.Name = "dateTimeInput_PassportDateEnd9";
            this.dateTimeInput_PassportDateEnd9.Size = new System.Drawing.Size(98, 20);
            this.dateTimeInput_PassportDateEnd9.TabIndex = 268;
            this.dateTimeInput_PassportDateEnd9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dateTimeInput_PassportDateEnd9.Click += new System.EventHandler(this.dateTimeInput_PassportDateEnd9_Click);
            this.dateTimeInput_PassportDateEnd9.Leave += new System.EventHandler(this.dateTimeInput_PassportDateEnd9_Leave);
            // 
            // dateTimeInput_PassportDateEnd8
            // 
            this.dateTimeInput_PassportDateEnd8.Location = new System.Drawing.Point(6, 309);
            this.dateTimeInput_PassportDateEnd8.Mask = "0000/00/00";
            this.dateTimeInput_PassportDateEnd8.Name = "dateTimeInput_PassportDateEnd8";
            this.dateTimeInput_PassportDateEnd8.Size = new System.Drawing.Size(98, 20);
            this.dateTimeInput_PassportDateEnd8.TabIndex = 263;
            this.dateTimeInput_PassportDateEnd8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dateTimeInput_PassportDateEnd8.Click += new System.EventHandler(this.dateTimeInput_PassportDateEnd8_Click);
            this.dateTimeInput_PassportDateEnd8.Leave += new System.EventHandler(this.dateTimeInput_PassportDateEnd8_Leave);
            // 
            // dateTimeInput_PassportDateEnd7
            // 
            this.dateTimeInput_PassportDateEnd7.Location = new System.Drawing.Point(6, 288);
            this.dateTimeInput_PassportDateEnd7.Mask = "0000/00/00";
            this.dateTimeInput_PassportDateEnd7.Name = "dateTimeInput_PassportDateEnd7";
            this.dateTimeInput_PassportDateEnd7.Size = new System.Drawing.Size(98, 20);
            this.dateTimeInput_PassportDateEnd7.TabIndex = 258;
            this.dateTimeInput_PassportDateEnd7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dateTimeInput_PassportDateEnd7.Click += new System.EventHandler(this.dateTimeInput_PassportDateEnd7_Click);
            this.dateTimeInput_PassportDateEnd7.Leave += new System.EventHandler(this.dateTimeInput_PassportDateEnd7_Leave);
            // 
            // dateTimeInput_PassportDateEnd6
            // 
            this.dateTimeInput_PassportDateEnd6.Location = new System.Drawing.Point(6, 267);
            this.dateTimeInput_PassportDateEnd6.Mask = "0000/00/00";
            this.dateTimeInput_PassportDateEnd6.Name = "dateTimeInput_PassportDateEnd6";
            this.dateTimeInput_PassportDateEnd6.Size = new System.Drawing.Size(98, 20);
            this.dateTimeInput_PassportDateEnd6.TabIndex = 253;
            this.dateTimeInput_PassportDateEnd6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dateTimeInput_PassportDateEnd6.Click += new System.EventHandler(this.dateTimeInput_PassportDateEnd6_Click);
            this.dateTimeInput_PassportDateEnd6.Leave += new System.EventHandler(this.dateTimeInput_PassportDateEnd6_Leave);
            // 
            // dateTimeInput_PassportDateEnd5
            // 
            this.dateTimeInput_PassportDateEnd5.Location = new System.Drawing.Point(6, 246);
            this.dateTimeInput_PassportDateEnd5.Mask = "0000/00/00";
            this.dateTimeInput_PassportDateEnd5.Name = "dateTimeInput_PassportDateEnd5";
            this.dateTimeInput_PassportDateEnd5.Size = new System.Drawing.Size(98, 20);
            this.dateTimeInput_PassportDateEnd5.TabIndex = 248;
            this.dateTimeInput_PassportDateEnd5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dateTimeInput_PassportDateEnd5.Click += new System.EventHandler(this.dateTimeInput_PassportDateEnd5_Click);
            this.dateTimeInput_PassportDateEnd5.Leave += new System.EventHandler(this.dateTimeInput_PassportDateEnd5_Leave);
            // 
            // dateTimeInput_PassportDateEnd4
            // 
            this.dateTimeInput_PassportDateEnd4.Location = new System.Drawing.Point(6, 225);
            this.dateTimeInput_PassportDateEnd4.Mask = "0000/00/00";
            this.dateTimeInput_PassportDateEnd4.Name = "dateTimeInput_PassportDateEnd4";
            this.dateTimeInput_PassportDateEnd4.Size = new System.Drawing.Size(98, 20);
            this.dateTimeInput_PassportDateEnd4.TabIndex = 243;
            this.dateTimeInput_PassportDateEnd4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dateTimeInput_PassportDateEnd4.Click += new System.EventHandler(this.dateTimeInput_PassportDateEnd4_Click);
            this.dateTimeInput_PassportDateEnd4.Leave += new System.EventHandler(this.dateTimeInput_PassportDateEnd4_Leave);
            // 
            // dateTimeInput_PassportDateEnd3
            // 
            this.dateTimeInput_PassportDateEnd3.Location = new System.Drawing.Point(6, 204);
            this.dateTimeInput_PassportDateEnd3.Mask = "0000/00/00";
            this.dateTimeInput_PassportDateEnd3.Name = "dateTimeInput_PassportDateEnd3";
            this.dateTimeInput_PassportDateEnd3.Size = new System.Drawing.Size(98, 20);
            this.dateTimeInput_PassportDateEnd3.TabIndex = 238;
            this.dateTimeInput_PassportDateEnd3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dateTimeInput_PassportDateEnd3.Click += new System.EventHandler(this.dateTimeInput_PassportDateEnd3_Click);
            this.dateTimeInput_PassportDateEnd3.Leave += new System.EventHandler(this.dateTimeInput_PassportDateEnd3_Leave);
            // 
            // dateTimeInput_PassportDateEnd2
            // 
            this.dateTimeInput_PassportDateEnd2.Location = new System.Drawing.Point(6, 183);
            this.dateTimeInput_PassportDateEnd2.Mask = "0000/00/00";
            this.dateTimeInput_PassportDateEnd2.Name = "dateTimeInput_PassportDateEnd2";
            this.dateTimeInput_PassportDateEnd2.Size = new System.Drawing.Size(98, 20);
            this.dateTimeInput_PassportDateEnd2.TabIndex = 233;
            this.dateTimeInput_PassportDateEnd2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dateTimeInput_PassportDateEnd2.Click += new System.EventHandler(this.dateTimeInput_PassportDateEnd2_Click);
            this.dateTimeInput_PassportDateEnd2.Leave += new System.EventHandler(this.dateTimeInput_PassportDateEnd2_Leave);
            // 
            // dateTimeInput_PassportDateEnd1
            // 
            this.dateTimeInput_PassportDateEnd1.Location = new System.Drawing.Point(6, 162);
            this.dateTimeInput_PassportDateEnd1.Mask = "0000/00/00";
            this.dateTimeInput_PassportDateEnd1.Name = "dateTimeInput_PassportDateEnd1";
            this.dateTimeInput_PassportDateEnd1.Size = new System.Drawing.Size(98, 20);
            this.dateTimeInput_PassportDateEnd1.TabIndex = 227;
            this.dateTimeInput_PassportDateEnd1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dateTimeInput_PassportDateEnd1.Click += new System.EventHandler(this.dateTimeInput_PassportDateEnd1_Click);
            this.dateTimeInput_PassportDateEnd1.Leave += new System.EventHandler(this.dateTimeInput_PassportDateEnd1_Leave);
            // 
            // dateTimeInput_BirthDate15
            // 
            this.dateTimeInput_BirthDate15.Location = new System.Drawing.Point(-361, 356);
            this.dateTimeInput_BirthDate15.Mask = "0000/00/00";
            this.dateTimeInput_BirthDate15.Name = "dateTimeInput_BirthDate15";
            this.dateTimeInput_BirthDate15.Size = new System.Drawing.Size(98, 20);
            this.dateTimeInput_BirthDate15.TabIndex = 295;
            this.dateTimeInput_BirthDate15.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dateTimeInput_BirthDate15.Click += new System.EventHandler(this.dateTimeInput_BirthDate15_Click);
            this.dateTimeInput_BirthDate15.Leave += new System.EventHandler(this.dateTimeInput_BirthDate15_Leave);
            // 
            // dateTimeInput_BirthDate14
            // 
            this.dateTimeInput_BirthDate14.Location = new System.Drawing.Point(-361, 335);
            this.dateTimeInput_BirthDate14.Mask = "0000/00/00";
            this.dateTimeInput_BirthDate14.Name = "dateTimeInput_BirthDate14";
            this.dateTimeInput_BirthDate14.Size = new System.Drawing.Size(98, 20);
            this.dateTimeInput_BirthDate14.TabIndex = 290;
            this.dateTimeInput_BirthDate14.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dateTimeInput_BirthDate14.Click += new System.EventHandler(this.dateTimeInput_BirthDate14_Click);
            this.dateTimeInput_BirthDate14.Leave += new System.EventHandler(this.dateTimeInput_BirthDate14_Leave);
            // 
            // dateTimeInput_BirthDate13
            // 
            this.dateTimeInput_BirthDate13.Location = new System.Drawing.Point(-361, 314);
            this.dateTimeInput_BirthDate13.Mask = "0000/00/00";
            this.dateTimeInput_BirthDate13.Name = "dateTimeInput_BirthDate13";
            this.dateTimeInput_BirthDate13.Size = new System.Drawing.Size(98, 20);
            this.dateTimeInput_BirthDate13.TabIndex = 285;
            this.dateTimeInput_BirthDate13.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dateTimeInput_BirthDate13.Click += new System.EventHandler(this.dateTimeInput_BirthDate13_Click);
            this.dateTimeInput_BirthDate13.Leave += new System.EventHandler(this.dateTimeInput_BirthDate13_Leave);
            // 
            // dateTimeInput_BirthDate12
            // 
            this.dateTimeInput_BirthDate12.Location = new System.Drawing.Point(-361, 293);
            this.dateTimeInput_BirthDate12.Mask = "0000/00/00";
            this.dateTimeInput_BirthDate12.Name = "dateTimeInput_BirthDate12";
            this.dateTimeInput_BirthDate12.Size = new System.Drawing.Size(98, 20);
            this.dateTimeInput_BirthDate12.TabIndex = 280;
            this.dateTimeInput_BirthDate12.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dateTimeInput_BirthDate12.Click += new System.EventHandler(this.dateTimeInput_BirthDate12_Click);
            this.dateTimeInput_BirthDate12.Leave += new System.EventHandler(this.dateTimeInput_BirthDate12_Leave);
            // 
            // dateTimeInput_BirthDate11
            // 
            this.dateTimeInput_BirthDate11.Location = new System.Drawing.Point(-361, 272);
            this.dateTimeInput_BirthDate11.Mask = "0000/00/00";
            this.dateTimeInput_BirthDate11.Name = "dateTimeInput_BirthDate11";
            this.dateTimeInput_BirthDate11.Size = new System.Drawing.Size(98, 20);
            this.dateTimeInput_BirthDate11.TabIndex = 275;
            this.dateTimeInput_BirthDate11.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dateTimeInput_BirthDate11.Click += new System.EventHandler(this.dateTimeInput_BirthDate11_Click);
            this.dateTimeInput_BirthDate11.Leave += new System.EventHandler(this.dateTimeInput_BirthDate11_Leave);
            // 
            // dateTimeInput_BirthDate10
            // 
            this.dateTimeInput_BirthDate10.Location = new System.Drawing.Point(260, 352);
            this.dateTimeInput_BirthDate10.Mask = "0000/00/00";
            this.dateTimeInput_BirthDate10.Name = "dateTimeInput_BirthDate10";
            this.dateTimeInput_BirthDate10.Size = new System.Drawing.Size(98, 20);
            this.dateTimeInput_BirthDate10.TabIndex = 270;
            this.dateTimeInput_BirthDate10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dateTimeInput_BirthDate10.Click += new System.EventHandler(this.dateTimeInput_BirthDate10_Click);
            this.dateTimeInput_BirthDate10.Leave += new System.EventHandler(this.dateTimeInput_BirthDate10_Leave);
            // 
            // dateTimeInput_BirthDate9
            // 
            this.dateTimeInput_BirthDate9.Location = new System.Drawing.Point(260, 331);
            this.dateTimeInput_BirthDate9.Mask = "0000/00/00";
            this.dateTimeInput_BirthDate9.Name = "dateTimeInput_BirthDate9";
            this.dateTimeInput_BirthDate9.Size = new System.Drawing.Size(98, 20);
            this.dateTimeInput_BirthDate9.TabIndex = 265;
            this.dateTimeInput_BirthDate9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dateTimeInput_BirthDate9.Click += new System.EventHandler(this.dateTimeInput_BirthDate9_Click);
            this.dateTimeInput_BirthDate9.Leave += new System.EventHandler(this.dateTimeInput_BirthDate9_Leave);
            // 
            // dateTimeInput_BirthDate8
            // 
            this.dateTimeInput_BirthDate8.Location = new System.Drawing.Point(260, 310);
            this.dateTimeInput_BirthDate8.Mask = "0000/00/00";
            this.dateTimeInput_BirthDate8.Name = "dateTimeInput_BirthDate8";
            this.dateTimeInput_BirthDate8.Size = new System.Drawing.Size(98, 20);
            this.dateTimeInput_BirthDate8.TabIndex = 260;
            this.dateTimeInput_BirthDate8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dateTimeInput_BirthDate8.Click += new System.EventHandler(this.dateTimeInput_BirthDate8_Click);
            this.dateTimeInput_BirthDate8.Leave += new System.EventHandler(this.dateTimeInput_BirthDate8_Leave);
            // 
            // dateTimeInput_BirthDate7
            // 
            this.dateTimeInput_BirthDate7.Location = new System.Drawing.Point(260, 289);
            this.dateTimeInput_BirthDate7.Mask = "0000/00/00";
            this.dateTimeInput_BirthDate7.Name = "dateTimeInput_BirthDate7";
            this.dateTimeInput_BirthDate7.Size = new System.Drawing.Size(98, 20);
            this.dateTimeInput_BirthDate7.TabIndex = 255;
            this.dateTimeInput_BirthDate7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dateTimeInput_BirthDate7.Click += new System.EventHandler(this.dateTimeInput_BirthDate7_Click);
            this.dateTimeInput_BirthDate7.Leave += new System.EventHandler(this.dateTimeInput_BirthDate7_Leave);
            // 
            // dateTimeInput_BirthDate6
            // 
            this.dateTimeInput_BirthDate6.Location = new System.Drawing.Point(260, 268);
            this.dateTimeInput_BirthDate6.Mask = "0000/00/00";
            this.dateTimeInput_BirthDate6.Name = "dateTimeInput_BirthDate6";
            this.dateTimeInput_BirthDate6.Size = new System.Drawing.Size(98, 20);
            this.dateTimeInput_BirthDate6.TabIndex = 250;
            this.dateTimeInput_BirthDate6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dateTimeInput_BirthDate6.Click += new System.EventHandler(this.dateTimeInput_BirthDate6_Click);
            this.dateTimeInput_BirthDate6.Leave += new System.EventHandler(this.dateTimeInput_BirthDate6_Leave);
            // 
            // dateTimeInput_BirthDate5
            // 
            this.dateTimeInput_BirthDate5.Location = new System.Drawing.Point(260, 247);
            this.dateTimeInput_BirthDate5.Mask = "0000/00/00";
            this.dateTimeInput_BirthDate5.Name = "dateTimeInput_BirthDate5";
            this.dateTimeInput_BirthDate5.Size = new System.Drawing.Size(98, 20);
            this.dateTimeInput_BirthDate5.TabIndex = 245;
            this.dateTimeInput_BirthDate5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dateTimeInput_BirthDate5.Click += new System.EventHandler(this.dateTimeInput_BirthDate5_Click);
            this.dateTimeInput_BirthDate5.Leave += new System.EventHandler(this.dateTimeInput_BirthDate5_Leave);
            // 
            // dateTimeInput_BirthDate4
            // 
            this.dateTimeInput_BirthDate4.Location = new System.Drawing.Point(260, 226);
            this.dateTimeInput_BirthDate4.Mask = "0000/00/00";
            this.dateTimeInput_BirthDate4.Name = "dateTimeInput_BirthDate4";
            this.dateTimeInput_BirthDate4.Size = new System.Drawing.Size(98, 20);
            this.dateTimeInput_BirthDate4.TabIndex = 240;
            this.dateTimeInput_BirthDate4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dateTimeInput_BirthDate4.Click += new System.EventHandler(this.dateTimeInput_BirthDate4_Click);
            this.dateTimeInput_BirthDate4.Leave += new System.EventHandler(this.dateTimeInput_BirthDate4_Leave);
            // 
            // dateTimeInput_BirthDate3
            // 
            this.dateTimeInput_BirthDate3.Location = new System.Drawing.Point(260, 205);
            this.dateTimeInput_BirthDate3.Mask = "0000/00/00";
            this.dateTimeInput_BirthDate3.Name = "dateTimeInput_BirthDate3";
            this.dateTimeInput_BirthDate3.Size = new System.Drawing.Size(98, 20);
            this.dateTimeInput_BirthDate3.TabIndex = 235;
            this.dateTimeInput_BirthDate3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dateTimeInput_BirthDate3.Click += new System.EventHandler(this.dateTimeInput_BirthDate3_Click);
            this.dateTimeInput_BirthDate3.Leave += new System.EventHandler(this.dateTimeInput_BirthDate3_Leave);
            // 
            // dateTimeInput_BirthDate2
            // 
            this.dateTimeInput_BirthDate2.Location = new System.Drawing.Point(260, 184);
            this.dateTimeInput_BirthDate2.Mask = "0000/00/00";
            this.dateTimeInput_BirthDate2.Name = "dateTimeInput_BirthDate2";
            this.dateTimeInput_BirthDate2.Size = new System.Drawing.Size(98, 20);
            this.dateTimeInput_BirthDate2.TabIndex = 230;
            this.dateTimeInput_BirthDate2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dateTimeInput_BirthDate2.Click += new System.EventHandler(this.dateTimeInput_BirthDate2_Click);
            this.dateTimeInput_BirthDate2.Leave += new System.EventHandler(this.dateTimeInput_BirthDate2_Leave);
            // 
            // dateTimeInput_BirthDate1
            // 
            this.dateTimeInput_BirthDate1.Location = new System.Drawing.Point(260, 163);
            this.dateTimeInput_BirthDate1.Mask = "0000/00/00";
            this.dateTimeInput_BirthDate1.Name = "dateTimeInput_BirthDate1";
            this.dateTimeInput_BirthDate1.Size = new System.Drawing.Size(98, 20);
            this.dateTimeInput_BirthDate1.TabIndex = 225;
            this.dateTimeInput_BirthDate1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dateTimeInput_BirthDate1.Click += new System.EventHandler(this.dateTimeInput_BirthDate1_Click);
            this.dateTimeInput_BirthDate1.Leave += new System.EventHandler(this.dateTimeInput_BirthDate1_Leave);
            // 
            // label122
            // 
            this.label122.BackColor = System.Drawing.Color.Maroon;
            this.label122.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label122.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label122.ForeColor = System.Drawing.Color.White;
            this.label122.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label122.Location = new System.Drawing.Point(6, 136);
            this.label122.Name = "label122";
            this.label122.Size = new System.Drawing.Size(98, 25);
            this.label122.TabIndex = 303;
            this.label122.Text = "تاريخ الإنتهاء";
            this.label122.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label123
            // 
            this.label123.BackColor = System.Drawing.Color.Transparent;
            this.label123.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label123.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label123.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label123.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label123.Location = new System.Drawing.Point(106, 136);
            this.label123.Name = "label123";
            this.label123.Size = new System.Drawing.Size(76, 25);
            this.label123.TabIndex = 302;
            this.label123.Text = "جواز السفر";
            this.label123.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label128
            // 
            this.label128.BackColor = System.Drawing.Color.Transparent;
            this.label128.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label128.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label128.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label128.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label128.Location = new System.Drawing.Point(183, 136);
            this.label128.Name = "label128";
            this.label128.Size = new System.Drawing.Size(76, 25);
            this.label128.TabIndex = 301;
            this.label128.Text = "الصلــــة";
            this.label128.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label129
            // 
            this.label129.BackColor = System.Drawing.Color.Transparent;
            this.label129.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label129.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label129.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label129.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label129.Location = new System.Drawing.Point(260, 136);
            this.label129.Name = "label129";
            this.label129.Size = new System.Drawing.Size(98, 25);
            this.label129.TabIndex = 300;
            this.label129.Text = "تاريخ الميلاد";
            this.label129.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox_PassporntNo15
            // 
            this.textBox_PassporntNo15.BackColor = System.Drawing.Color.White;
            this.textBox_PassporntNo15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_PassporntNo15.Location = new System.Drawing.Point(-515, 356);
            this.textBox_PassporntNo15.MaxLength = 15;
            this.textBox_PassporntNo15.Name = "textBox_PassporntNo15";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_PassporntNo15, false);
            this.textBox_PassporntNo15.Size = new System.Drawing.Size(76, 20);
            this.textBox_PassporntNo15.TabIndex = 297;
            this.textBox_PassporntNo15.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_Relation15
            // 
            this.textBox_Relation15.BackColor = System.Drawing.Color.White;
            this.textBox_Relation15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_Relation15.Location = new System.Drawing.Point(-438, 356);
            this.textBox_Relation15.MaxLength = 15;
            this.textBox_Relation15.Name = "textBox_Relation15";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_Relation15, false);
            this.textBox_Relation15.Size = new System.Drawing.Size(76, 20);
            this.textBox_Relation15.TabIndex = 296;
            this.textBox_Relation15.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_Name15
            // 
            this.textBox_Name15.BackColor = System.Drawing.Color.White;
            this.textBox_Name15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_Name15.Location = new System.Drawing.Point(-261, 356);
            this.textBox_Name15.MaxLength = 20;
            this.textBox_Name15.Name = "textBox_Name15";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_Name15, false);
            this.textBox_Name15.Size = new System.Drawing.Size(219, 20);
            this.textBox_Name15.TabIndex = 294;
            // 
            // textBox_PassporntNo14
            // 
            this.textBox_PassporntNo14.BackColor = System.Drawing.Color.White;
            this.textBox_PassporntNo14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_PassporntNo14.Location = new System.Drawing.Point(-515, 335);
            this.textBox_PassporntNo14.MaxLength = 15;
            this.textBox_PassporntNo14.Name = "textBox_PassporntNo14";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_PassporntNo14, false);
            this.textBox_PassporntNo14.Size = new System.Drawing.Size(76, 20);
            this.textBox_PassporntNo14.TabIndex = 292;
            this.textBox_PassporntNo14.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_Relation14
            // 
            this.textBox_Relation14.BackColor = System.Drawing.Color.White;
            this.textBox_Relation14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_Relation14.Location = new System.Drawing.Point(-438, 335);
            this.textBox_Relation14.MaxLength = 15;
            this.textBox_Relation14.Name = "textBox_Relation14";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_Relation14, false);
            this.textBox_Relation14.Size = new System.Drawing.Size(76, 20);
            this.textBox_Relation14.TabIndex = 291;
            this.textBox_Relation14.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_Name14
            // 
            this.textBox_Name14.BackColor = System.Drawing.Color.White;
            this.textBox_Name14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_Name14.Location = new System.Drawing.Point(-261, 335);
            this.textBox_Name14.MaxLength = 20;
            this.textBox_Name14.Name = "textBox_Name14";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_Name14, false);
            this.textBox_Name14.Size = new System.Drawing.Size(219, 20);
            this.textBox_Name14.TabIndex = 289;
            // 
            // textBox_PassporntNo13
            // 
            this.textBox_PassporntNo13.BackColor = System.Drawing.Color.White;
            this.textBox_PassporntNo13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_PassporntNo13.Location = new System.Drawing.Point(-515, 314);
            this.textBox_PassporntNo13.MaxLength = 15;
            this.textBox_PassporntNo13.Name = "textBox_PassporntNo13";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_PassporntNo13, false);
            this.textBox_PassporntNo13.Size = new System.Drawing.Size(76, 20);
            this.textBox_PassporntNo13.TabIndex = 287;
            this.textBox_PassporntNo13.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_Relation13
            // 
            this.textBox_Relation13.BackColor = System.Drawing.Color.White;
            this.textBox_Relation13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_Relation13.Location = new System.Drawing.Point(-438, 314);
            this.textBox_Relation13.MaxLength = 15;
            this.textBox_Relation13.Name = "textBox_Relation13";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_Relation13, false);
            this.textBox_Relation13.Size = new System.Drawing.Size(76, 20);
            this.textBox_Relation13.TabIndex = 286;
            this.textBox_Relation13.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_Name13
            // 
            this.textBox_Name13.BackColor = System.Drawing.Color.White;
            this.textBox_Name13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_Name13.Location = new System.Drawing.Point(-261, 314);
            this.textBox_Name13.MaxLength = 20;
            this.textBox_Name13.Name = "textBox_Name13";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_Name13, false);
            this.textBox_Name13.Size = new System.Drawing.Size(219, 20);
            this.textBox_Name13.TabIndex = 284;
            // 
            // textBox_PassporntNo12
            // 
            this.textBox_PassporntNo12.BackColor = System.Drawing.Color.White;
            this.textBox_PassporntNo12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_PassporntNo12.Location = new System.Drawing.Point(-515, 293);
            this.textBox_PassporntNo12.MaxLength = 15;
            this.textBox_PassporntNo12.Name = "textBox_PassporntNo12";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_PassporntNo12, false);
            this.textBox_PassporntNo12.Size = new System.Drawing.Size(76, 20);
            this.textBox_PassporntNo12.TabIndex = 282;
            this.textBox_PassporntNo12.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_Relation12
            // 
            this.textBox_Relation12.BackColor = System.Drawing.Color.White;
            this.textBox_Relation12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_Relation12.Location = new System.Drawing.Point(-438, 293);
            this.textBox_Relation12.MaxLength = 15;
            this.textBox_Relation12.Name = "textBox_Relation12";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_Relation12, false);
            this.textBox_Relation12.Size = new System.Drawing.Size(76, 20);
            this.textBox_Relation12.TabIndex = 281;
            this.textBox_Relation12.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_Name12
            // 
            this.textBox_Name12.BackColor = System.Drawing.Color.White;
            this.textBox_Name12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_Name12.Location = new System.Drawing.Point(-261, 293);
            this.textBox_Name12.MaxLength = 20;
            this.textBox_Name12.Name = "textBox_Name12";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_Name12, false);
            this.textBox_Name12.Size = new System.Drawing.Size(219, 20);
            this.textBox_Name12.TabIndex = 279;
            // 
            // textBox_PassporntNo11
            // 
            this.textBox_PassporntNo11.BackColor = System.Drawing.Color.White;
            this.textBox_PassporntNo11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_PassporntNo11.Location = new System.Drawing.Point(-515, 272);
            this.textBox_PassporntNo11.MaxLength = 15;
            this.textBox_PassporntNo11.Name = "textBox_PassporntNo11";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_PassporntNo11, false);
            this.textBox_PassporntNo11.Size = new System.Drawing.Size(76, 20);
            this.textBox_PassporntNo11.TabIndex = 277;
            this.textBox_PassporntNo11.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_Relation11
            // 
            this.textBox_Relation11.BackColor = System.Drawing.Color.White;
            this.textBox_Relation11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_Relation11.Location = new System.Drawing.Point(-438, 272);
            this.textBox_Relation11.MaxLength = 15;
            this.textBox_Relation11.Name = "textBox_Relation11";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_Relation11, false);
            this.textBox_Relation11.Size = new System.Drawing.Size(76, 20);
            this.textBox_Relation11.TabIndex = 276;
            this.textBox_Relation11.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_Name11
            // 
            this.textBox_Name11.BackColor = System.Drawing.Color.White;
            this.textBox_Name11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_Name11.Location = new System.Drawing.Point(-261, 272);
            this.textBox_Name11.MaxLength = 20;
            this.textBox_Name11.Name = "textBox_Name11";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_Name11, false);
            this.textBox_Name11.Size = new System.Drawing.Size(219, 20);
            this.textBox_Name11.TabIndex = 274;
            // 
            // textBox_PassporntNo10
            // 
            this.textBox_PassporntNo10.BackColor = System.Drawing.Color.White;
            this.textBox_PassporntNo10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_PassporntNo10.Location = new System.Drawing.Point(106, 352);
            this.textBox_PassporntNo10.MaxLength = 15;
            this.textBox_PassporntNo10.Name = "textBox_PassporntNo10";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_PassporntNo10, false);
            this.textBox_PassporntNo10.Size = new System.Drawing.Size(76, 20);
            this.textBox_PassporntNo10.TabIndex = 272;
            this.textBox_PassporntNo10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_PassporntNo10.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_PassporntNo1_KeyPress);
            // 
            // textBox_Relation10
            // 
            this.textBox_Relation10.BackColor = System.Drawing.Color.White;
            this.textBox_Relation10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_Relation10.Location = new System.Drawing.Point(183, 352);
            this.textBox_Relation10.MaxLength = 15;
            this.textBox_Relation10.Name = "textBox_Relation10";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_Relation10, false);
            this.textBox_Relation10.Size = new System.Drawing.Size(76, 20);
            this.textBox_Relation10.TabIndex = 271;
            this.textBox_Relation10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_Name10
            // 
            this.textBox_Name10.BackColor = System.Drawing.Color.White;
            this.textBox_Name10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_Name10.Location = new System.Drawing.Point(360, 352);
            this.textBox_Name10.MaxLength = 20;
            this.textBox_Name10.Name = "textBox_Name10";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_Name10, false);
            this.textBox_Name10.Size = new System.Drawing.Size(219, 20);
            this.textBox_Name10.TabIndex = 269;
            this.textBox_Name10.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_Name10_KeyPress);
            // 
            // textBox_PassporntNo9
            // 
            this.textBox_PassporntNo9.BackColor = System.Drawing.Color.White;
            this.textBox_PassporntNo9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_PassporntNo9.Location = new System.Drawing.Point(106, 331);
            this.textBox_PassporntNo9.MaxLength = 15;
            this.textBox_PassporntNo9.Name = "textBox_PassporntNo9";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_PassporntNo9, false);
            this.textBox_PassporntNo9.Size = new System.Drawing.Size(76, 20);
            this.textBox_PassporntNo9.TabIndex = 267;
            this.textBox_PassporntNo9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_PassporntNo9.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_PassporntNo1_KeyPress);
            // 
            // textBox_Relation9
            // 
            this.textBox_Relation9.BackColor = System.Drawing.Color.White;
            this.textBox_Relation9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_Relation9.Location = new System.Drawing.Point(183, 331);
            this.textBox_Relation9.MaxLength = 15;
            this.textBox_Relation9.Name = "textBox_Relation9";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_Relation9, false);
            this.textBox_Relation9.Size = new System.Drawing.Size(76, 20);
            this.textBox_Relation9.TabIndex = 266;
            this.textBox_Relation9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_Name9
            // 
            this.textBox_Name9.BackColor = System.Drawing.Color.White;
            this.textBox_Name9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_Name9.Location = new System.Drawing.Point(360, 331);
            this.textBox_Name9.MaxLength = 20;
            this.textBox_Name9.Name = "textBox_Name9";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_Name9, false);
            this.textBox_Name9.Size = new System.Drawing.Size(219, 20);
            this.textBox_Name9.TabIndex = 264;
            this.textBox_Name9.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_Name9_KeyPress);
            // 
            // textBox_PassporntNo8
            // 
            this.textBox_PassporntNo8.BackColor = System.Drawing.Color.White;
            this.textBox_PassporntNo8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_PassporntNo8.Location = new System.Drawing.Point(106, 310);
            this.textBox_PassporntNo8.MaxLength = 15;
            this.textBox_PassporntNo8.Name = "textBox_PassporntNo8";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_PassporntNo8, false);
            this.textBox_PassporntNo8.Size = new System.Drawing.Size(76, 20);
            this.textBox_PassporntNo8.TabIndex = 262;
            this.textBox_PassporntNo8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_PassporntNo8.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_PassporntNo1_KeyPress);
            // 
            // textBox_Relation8
            // 
            this.textBox_Relation8.BackColor = System.Drawing.Color.White;
            this.textBox_Relation8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_Relation8.Location = new System.Drawing.Point(183, 310);
            this.textBox_Relation8.MaxLength = 15;
            this.textBox_Relation8.Name = "textBox_Relation8";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_Relation8, false);
            this.textBox_Relation8.Size = new System.Drawing.Size(76, 20);
            this.textBox_Relation8.TabIndex = 261;
            this.textBox_Relation8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_Name8
            // 
            this.textBox_Name8.BackColor = System.Drawing.Color.White;
            this.textBox_Name8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_Name8.Location = new System.Drawing.Point(360, 310);
            this.textBox_Name8.MaxLength = 20;
            this.textBox_Name8.Name = "textBox_Name8";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_Name8, false);
            this.textBox_Name8.Size = new System.Drawing.Size(219, 20);
            this.textBox_Name8.TabIndex = 259;
            this.textBox_Name8.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_Name8_KeyPress);
            // 
            // textBox_PassporntNo7
            // 
            this.textBox_PassporntNo7.BackColor = System.Drawing.Color.White;
            this.textBox_PassporntNo7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_PassporntNo7.Location = new System.Drawing.Point(106, 289);
            this.textBox_PassporntNo7.MaxLength = 15;
            this.textBox_PassporntNo7.Name = "textBox_PassporntNo7";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_PassporntNo7, false);
            this.textBox_PassporntNo7.Size = new System.Drawing.Size(76, 20);
            this.textBox_PassporntNo7.TabIndex = 257;
            this.textBox_PassporntNo7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_PassporntNo7.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_PassporntNo1_KeyPress);
            // 
            // textBox_Relation7
            // 
            this.textBox_Relation7.BackColor = System.Drawing.Color.White;
            this.textBox_Relation7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_Relation7.Location = new System.Drawing.Point(183, 289);
            this.textBox_Relation7.MaxLength = 15;
            this.textBox_Relation7.Name = "textBox_Relation7";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_Relation7, false);
            this.textBox_Relation7.Size = new System.Drawing.Size(76, 20);
            this.textBox_Relation7.TabIndex = 256;
            this.textBox_Relation7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_Name7
            // 
            this.textBox_Name7.BackColor = System.Drawing.Color.White;
            this.textBox_Name7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_Name7.Location = new System.Drawing.Point(360, 289);
            this.textBox_Name7.MaxLength = 20;
            this.textBox_Name7.Name = "textBox_Name7";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_Name7, false);
            this.textBox_Name7.Size = new System.Drawing.Size(219, 20);
            this.textBox_Name7.TabIndex = 254;
            this.textBox_Name7.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_Name7_KeyPress);
            // 
            // textBox_PassporntNo6
            // 
            this.textBox_PassporntNo6.BackColor = System.Drawing.Color.White;
            this.textBox_PassporntNo6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_PassporntNo6.Location = new System.Drawing.Point(106, 268);
            this.textBox_PassporntNo6.MaxLength = 15;
            this.textBox_PassporntNo6.Name = "textBox_PassporntNo6";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_PassporntNo6, false);
            this.textBox_PassporntNo6.Size = new System.Drawing.Size(76, 20);
            this.textBox_PassporntNo6.TabIndex = 252;
            this.textBox_PassporntNo6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_PassporntNo6.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_PassporntNo1_KeyPress);
            // 
            // textBox_Relation6
            // 
            this.textBox_Relation6.BackColor = System.Drawing.Color.White;
            this.textBox_Relation6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_Relation6.Location = new System.Drawing.Point(183, 268);
            this.textBox_Relation6.MaxLength = 15;
            this.textBox_Relation6.Name = "textBox_Relation6";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_Relation6, false);
            this.textBox_Relation6.Size = new System.Drawing.Size(76, 20);
            this.textBox_Relation6.TabIndex = 251;
            this.textBox_Relation6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_Name6
            // 
            this.textBox_Name6.BackColor = System.Drawing.Color.White;
            this.textBox_Name6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_Name6.Location = new System.Drawing.Point(360, 268);
            this.textBox_Name6.MaxLength = 20;
            this.textBox_Name6.Name = "textBox_Name6";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_Name6, false);
            this.textBox_Name6.Size = new System.Drawing.Size(219, 20);
            this.textBox_Name6.TabIndex = 249;
            this.textBox_Name6.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_Name6_KeyPress);
            // 
            // textBox_PassporntNo5
            // 
            this.textBox_PassporntNo5.BackColor = System.Drawing.Color.White;
            this.textBox_PassporntNo5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_PassporntNo5.Location = new System.Drawing.Point(106, 247);
            this.textBox_PassporntNo5.MaxLength = 15;
            this.textBox_PassporntNo5.Name = "textBox_PassporntNo5";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_PassporntNo5, false);
            this.textBox_PassporntNo5.Size = new System.Drawing.Size(76, 20);
            this.textBox_PassporntNo5.TabIndex = 247;
            this.textBox_PassporntNo5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_PassporntNo5.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_PassporntNo1_KeyPress);
            // 
            // textBox_Relation5
            // 
            this.textBox_Relation5.BackColor = System.Drawing.Color.White;
            this.textBox_Relation5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_Relation5.Location = new System.Drawing.Point(183, 247);
            this.textBox_Relation5.MaxLength = 15;
            this.textBox_Relation5.Name = "textBox_Relation5";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_Relation5, false);
            this.textBox_Relation5.Size = new System.Drawing.Size(76, 20);
            this.textBox_Relation5.TabIndex = 246;
            this.textBox_Relation5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_Name5
            // 
            this.textBox_Name5.BackColor = System.Drawing.Color.White;
            this.textBox_Name5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_Name5.Location = new System.Drawing.Point(360, 247);
            this.textBox_Name5.MaxLength = 20;
            this.textBox_Name5.Name = "textBox_Name5";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_Name5, false);
            this.textBox_Name5.Size = new System.Drawing.Size(219, 20);
            this.textBox_Name5.TabIndex = 244;
            this.textBox_Name5.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_Name5_KeyPress);
            // 
            // textBox_PassporntNo4
            // 
            this.textBox_PassporntNo4.BackColor = System.Drawing.Color.White;
            this.textBox_PassporntNo4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_PassporntNo4.Location = new System.Drawing.Point(106, 226);
            this.textBox_PassporntNo4.MaxLength = 15;
            this.textBox_PassporntNo4.Name = "textBox_PassporntNo4";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_PassporntNo4, false);
            this.textBox_PassporntNo4.Size = new System.Drawing.Size(76, 20);
            this.textBox_PassporntNo4.TabIndex = 242;
            this.textBox_PassporntNo4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_PassporntNo4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_PassporntNo1_KeyPress);
            // 
            // textBox_Relation4
            // 
            this.textBox_Relation4.BackColor = System.Drawing.Color.White;
            this.textBox_Relation4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_Relation4.Location = new System.Drawing.Point(183, 226);
            this.textBox_Relation4.MaxLength = 15;
            this.textBox_Relation4.Name = "textBox_Relation4";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_Relation4, false);
            this.textBox_Relation4.Size = new System.Drawing.Size(76, 20);
            this.textBox_Relation4.TabIndex = 241;
            this.textBox_Relation4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_Name4
            // 
            this.textBox_Name4.BackColor = System.Drawing.Color.White;
            this.textBox_Name4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_Name4.Location = new System.Drawing.Point(360, 226);
            this.textBox_Name4.MaxLength = 20;
            this.textBox_Name4.Name = "textBox_Name4";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_Name4, false);
            this.textBox_Name4.Size = new System.Drawing.Size(219, 20);
            this.textBox_Name4.TabIndex = 239;
            this.textBox_Name4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_Name4_KeyPress);
            // 
            // textBox_PassporntNo3
            // 
            this.textBox_PassporntNo3.BackColor = System.Drawing.Color.White;
            this.textBox_PassporntNo3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_PassporntNo3.Location = new System.Drawing.Point(106, 205);
            this.textBox_PassporntNo3.MaxLength = 15;
            this.textBox_PassporntNo3.Name = "textBox_PassporntNo3";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_PassporntNo3, false);
            this.textBox_PassporntNo3.Size = new System.Drawing.Size(76, 20);
            this.textBox_PassporntNo3.TabIndex = 237;
            this.textBox_PassporntNo3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_PassporntNo3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_PassporntNo1_KeyPress);
            // 
            // textBox_Relation3
            // 
            this.textBox_Relation3.BackColor = System.Drawing.Color.White;
            this.textBox_Relation3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_Relation3.Location = new System.Drawing.Point(183, 205);
            this.textBox_Relation3.MaxLength = 15;
            this.textBox_Relation3.Name = "textBox_Relation3";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_Relation3, false);
            this.textBox_Relation3.Size = new System.Drawing.Size(76, 20);
            this.textBox_Relation3.TabIndex = 236;
            this.textBox_Relation3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_Name3
            // 
            this.textBox_Name3.BackColor = System.Drawing.Color.White;
            this.textBox_Name3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_Name3.Location = new System.Drawing.Point(360, 205);
            this.textBox_Name3.MaxLength = 20;
            this.textBox_Name3.Name = "textBox_Name3";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_Name3, false);
            this.textBox_Name3.Size = new System.Drawing.Size(219, 20);
            this.textBox_Name3.TabIndex = 234;
            this.textBox_Name3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_Name3_KeyPress);
            // 
            // textBox_PassporntNo2
            // 
            this.textBox_PassporntNo2.BackColor = System.Drawing.Color.White;
            this.textBox_PassporntNo2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_PassporntNo2.Location = new System.Drawing.Point(106, 184);
            this.textBox_PassporntNo2.MaxLength = 15;
            this.textBox_PassporntNo2.Name = "textBox_PassporntNo2";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_PassporntNo2, false);
            this.textBox_PassporntNo2.Size = new System.Drawing.Size(76, 20);
            this.textBox_PassporntNo2.TabIndex = 232;
            this.textBox_PassporntNo2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_PassporntNo2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_PassporntNo1_KeyPress);
            // 
            // textBox_Relation2
            // 
            this.textBox_Relation2.BackColor = System.Drawing.Color.White;
            this.textBox_Relation2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_Relation2.Location = new System.Drawing.Point(183, 184);
            this.textBox_Relation2.MaxLength = 15;
            this.textBox_Relation2.Name = "textBox_Relation2";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_Relation2, false);
            this.textBox_Relation2.Size = new System.Drawing.Size(76, 20);
            this.textBox_Relation2.TabIndex = 231;
            this.textBox_Relation2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_Name2
            // 
            this.textBox_Name2.BackColor = System.Drawing.Color.White;
            this.textBox_Name2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_Name2.Location = new System.Drawing.Point(360, 184);
            this.textBox_Name2.MaxLength = 20;
            this.textBox_Name2.Name = "textBox_Name2";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_Name2, false);
            this.textBox_Name2.Size = new System.Drawing.Size(219, 20);
            this.textBox_Name2.TabIndex = 229;
            this.textBox_Name2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_Name2_KeyPress);
            // 
            // textBox_PassporntNo1
            // 
            this.textBox_PassporntNo1.BackColor = System.Drawing.Color.White;
            this.textBox_PassporntNo1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_PassporntNo1.Location = new System.Drawing.Point(106, 163);
            this.textBox_PassporntNo1.MaxLength = 15;
            this.textBox_PassporntNo1.Name = "textBox_PassporntNo1";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_PassporntNo1, false);
            this.textBox_PassporntNo1.Size = new System.Drawing.Size(76, 20);
            this.textBox_PassporntNo1.TabIndex = 228;
            this.textBox_PassporntNo1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_PassporntNo1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_PassporntNo1_KeyPress);
            // 
            // textBox_Relation1
            // 
            this.textBox_Relation1.BackColor = System.Drawing.Color.White;
            this.textBox_Relation1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_Relation1.Location = new System.Drawing.Point(183, 163);
            this.textBox_Relation1.MaxLength = 15;
            this.textBox_Relation1.Name = "textBox_Relation1";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_Relation1, false);
            this.textBox_Relation1.Size = new System.Drawing.Size(76, 20);
            this.textBox_Relation1.TabIndex = 226;
            this.textBox_Relation1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_Name1
            // 
            this.textBox_Name1.BackColor = System.Drawing.Color.White;
            this.textBox_Name1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_Name1.Location = new System.Drawing.Point(360, 163);
            this.textBox_Name1.MaxLength = 20;
            this.textBox_Name1.Name = "textBox_Name1";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_Name1, false);
            this.textBox_Name1.Size = new System.Drawing.Size(219, 20);
            this.textBox_Name1.TabIndex = 224;
            // 
            // label132
            // 
            this.label132.BackColor = System.Drawing.Color.Transparent;
            this.label132.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label132.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label132.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label132.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label132.Location = new System.Drawing.Point(360, 136);
            this.label132.Name = "label132";
            this.label132.Size = new System.Drawing.Size(219, 25);
            this.label132.TabIndex = 299;
            this.label132.Text = "إسم المـــــرافق";
            this.label132.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox_Note
            // 
            this.textBox_Note.BackColor = System.Drawing.Color.AliceBlue;
            // 
            // 
            // 
            this.textBox_Note.Border.Class = "TextBoxBorder";
            this.textBox_Note.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBox_Note.ButtonCustom.Checked = true;
            this.textBox_Note.ButtonCustom.Visible = true;
            this.textBox_Note.ForeColor = System.Drawing.Color.Black;
            this.textBox_Note.Location = new System.Drawing.Point(10, 79);
            this.textBox_Note.Multiline = true;
            this.textBox_Note.Name = "textBox_Note";
            this.textBox_Note.Size = new System.Drawing.Size(568, 53);
            this.textBox_Note.TabIndex = 6693;
            this.textBox_Note.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_Note.WatermarkText = "الملاحظـــــــات";
            // 
            // superTabItem_Family
            // 
            this.superTabItem_Family.AttachedControl = this.superTabControlPanel1;
            this.superTabItem_Family.CloseButtonVisible = false;
            this.superTabItem_Family.GlobalItem = false;
            this.superTabItem_Family.Name = "superTabItem_Family";
            this.superTabItem_Family.Text = "المرافقــين";
            // 
            // superTabControlPanel19
            // 
            this.superTabControlPanel19.Controls.Add(this.panelEx6);
            this.superTabControlPanel19.Controls.Add(this.labelX20);
            this.superTabControlPanel19.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel19.Location = new System.Drawing.Point(0, 0);
            this.superTabControlPanel19.Name = "superTabControlPanel19";
            this.superTabControlPanel19.Size = new System.Drawing.Size(594, 419);
            this.superTabControlPanel19.TabIndex = 0;
            this.superTabControlPanel19.TabItem = this.superTabItem_Doc;
            // 
            // panelEx6
            // 
            this.panelEx6.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx6.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx6.Controls.Add(this.line2);
            this.panelEx6.Controls.Add(this.groupBox14);
            this.panelEx6.Controls.Add(this.comboBox_License_From);
            this.panelEx6.Controls.Add(this.button_SrchLicense);
            this.panelEx6.Controls.Add(this.line6);
            this.panelEx6.Controls.Add(this.bubbleBar5);
            this.panelEx6.Controls.Add(this.dateTimeInput_License_Date);
            this.panelEx6.Controls.Add(this.dateTimeInput_License_DateEnd);
            this.panelEx6.Controls.Add(this.textBox_License_No);
            this.panelEx6.Controls.Add(this.label109);
            this.panelEx6.Controls.Add(this.label110);
            this.panelEx6.Controls.Add(this.label111);
            this.panelEx6.Controls.Add(this.label112);
            this.panelEx6.Controls.Add(this.comboBox_Form_From);
            this.panelEx6.Controls.Add(this.button_SrchForms);
            this.panelEx6.Controls.Add(this.line5);
            this.panelEx6.Controls.Add(this.dateTimeInput_Form_Date);
            this.panelEx6.Controls.Add(this.dateTimeInput_Form_DateEnd);
            this.panelEx6.Controls.Add(this.textBox_Form_No);
            this.panelEx6.Controls.Add(this.label105);
            this.panelEx6.Controls.Add(this.label106);
            this.panelEx6.Controls.Add(this.label107);
            this.panelEx6.Controls.Add(this.label108);
            this.panelEx6.Controls.Add(this.comboBox_Insurance_From);
            this.panelEx6.Controls.Add(this.button_SrchInsurance);
            this.panelEx6.Controls.Add(this.line4);
            this.panelEx6.Controls.Add(this.dateTimeInput_Insurance_Date);
            this.panelEx6.Controls.Add(this.dateTimeInput_Insurance_DateEnd);
            this.panelEx6.Controls.Add(this.textBox_Insurance_No);
            this.panelEx6.Controls.Add(this.label101);
            this.panelEx6.Controls.Add(this.label102);
            this.panelEx6.Controls.Add(this.label103);
            this.panelEx6.Controls.Add(this.label104);
            this.panelEx6.Controls.Add(this.comboBox_Passport_From);
            this.panelEx6.Controls.Add(this.button_SrchPassport);
            this.panelEx6.Controls.Add(this.dateTimeInput_Pass_Date);
            this.panelEx6.Controls.Add(this.dateTimeInput_Passport_DateEnd);
            this.panelEx6.Controls.Add(this.textBox_Passport_No);
            this.panelEx6.Controls.Add(this.label96);
            this.panelEx6.Controls.Add(this.label98);
            this.panelEx6.Controls.Add(this.label99);
            this.panelEx6.Controls.Add(this.label100);
            this.panelEx6.Controls.Add(this.line3);
            this.panelEx6.Controls.Add(this.comboBox_ID_From);
            this.panelEx6.Controls.Add(this.button_SrchID);
            this.panelEx6.Controls.Add(this.dateTimeInput_ID_Date);
            this.panelEx6.Controls.Add(this.dateTimeInput_ID_DateEnd);
            this.panelEx6.Controls.Add(this.textBox_ID_No);
            this.panelEx6.Controls.Add(this.label88);
            this.panelEx6.Controls.Add(this.label97);
            this.panelEx6.Controls.Add(this.label95);
            this.panelEx6.Controls.Add(this.label92);
            this.panelEx6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx6.Location = new System.Drawing.Point(0, 0);
            this.panelEx6.Name = "panelEx6";
            this.panelEx6.Size = new System.Drawing.Size(594, 419);
            this.panelEx6.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx6.Style.BackColor1.Color = System.Drawing.Color.AliceBlue;
            this.panelEx6.Style.BackColor2.Color = System.Drawing.SystemColors.GradientActiveCaption;
            this.panelEx6.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx6.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx6.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx6.Style.GradientAngle = 90;
            this.panelEx6.TabIndex = 10;
            // 
            // line2
            // 
            this.line2.Location = new System.Drawing.Point(6, 120);
            this.line2.Name = "line2";
            this.line2.Size = new System.Drawing.Size(574, 8);
            this.line2.TabIndex = 6804;
            this.line2.Text = "line2";
            // 
            // groupBox14
            // 
            this.groupBox14.BackColor = System.Drawing.Color.Transparent;
            this.groupBox14.Controls.Add(this.dateTimeInput_VisaDate);
            this.groupBox14.Controls.Add(this.textBox_VisaCountry);
            this.groupBox14.Controls.Add(this.label136);
            this.groupBox14.Controls.Add(this.label135);
            this.groupBox14.Controls.Add(this.textBox_VisaEnterNo);
            this.groupBox14.Controls.Add(this.label134);
            this.groupBox14.Controls.Add(this.textBox_VisaNo);
            this.groupBox14.Controls.Add(this.label131);
            this.groupBox14.Location = new System.Drawing.Point(14, 19);
            this.groupBox14.Name = "groupBox14";
            this.groupBox14.Size = new System.Drawing.Size(561, 94);
            this.groupBox14.TabIndex = 6803;
            this.groupBox14.TabStop = false;
            this.groupBox14.Text = "تأشيرة الإستقدام";
            // 
            // dateTimeInput_VisaDate
            // 
            this.dateTimeInput_VisaDate.Location = new System.Drawing.Point(184, 59);
            this.dateTimeInput_VisaDate.Mask = "0000/00/00";
            this.dateTimeInput_VisaDate.Name = "dateTimeInput_VisaDate";
            this.dateTimeInput_VisaDate.Size = new System.Drawing.Size(90, 20);
            this.dateTimeInput_VisaDate.TabIndex = 864;
            this.dateTimeInput_VisaDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dateTimeInput_VisaDate.Click += new System.EventHandler(this.dateTimeInput_VisaDate_Click);
            this.dateTimeInput_VisaDate.Leave += new System.EventHandler(this.dateTimeInput_VisaDate_Leave);
            // 
            // textBox_VisaCountry
            // 
            this.textBox_VisaCountry.AcceptsReturn = true;
            this.textBox_VisaCountry.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_VisaCountry.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.textBox_VisaCountry.Location = new System.Drawing.Point(11, 58);
            this.textBox_VisaCountry.MaxLength = 30;
            this.textBox_VisaCountry.Name = "textBox_VisaCountry";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_VisaCountry, false);
            this.textBox_VisaCountry.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox_VisaCountry.Size = new System.Drawing.Size(123, 21);
            this.textBox_VisaCountry.TabIndex = 862;
            this.textBox_VisaCountry.Click += new System.EventHandler(this.textBox_VisaCountry_Click);
            // 
            // label136
            // 
            this.label136.AutoSize = true;
            this.label136.BackColor = System.Drawing.Color.Transparent;
            this.label136.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label136.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label136.Location = new System.Drawing.Point(135, 62);
            this.label136.Name = "label136";
            this.label136.Size = new System.Drawing.Size(43, 13);
            this.label136.TabIndex = 863;
            this.label136.Text = "المنفذ :";
            // 
            // label135
            // 
            this.label135.AutoSize = true;
            this.label135.BackColor = System.Drawing.Color.Transparent;
            this.label135.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label135.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label135.Location = new System.Drawing.Point(277, 62);
            this.label135.Name = "label135";
            this.label135.Size = new System.Drawing.Size(69, 13);
            this.label135.TabIndex = 861;
            this.label135.Text = "تاريخ الدخول :";
            // 
            // textBox_VisaEnterNo
            // 
            this.textBox_VisaEnterNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_VisaEnterNo.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.textBox_VisaEnterNo.Location = new System.Drawing.Point(353, 58);
            this.textBox_VisaEnterNo.MaxLength = 30;
            this.textBox_VisaEnterNo.Name = "textBox_VisaEnterNo";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_VisaEnterNo, false);
            this.textBox_VisaEnterNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox_VisaEnterNo.Size = new System.Drawing.Size(127, 21);
            this.textBox_VisaEnterNo.TabIndex = 858;
            this.textBox_VisaEnterNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_VisaEnterNo.Click += new System.EventHandler(this.textBox_VisaEnterNo_Click);
            this.textBox_VisaEnterNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_ID_No_KeyPress);
            // 
            // label134
            // 
            this.label134.AutoSize = true;
            this.label134.BackColor = System.Drawing.Color.Transparent;
            this.label134.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label134.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label134.Location = new System.Drawing.Point(481, 62);
            this.label134.Name = "label134";
            this.label134.Size = new System.Drawing.Size(65, 13);
            this.label134.TabIndex = 859;
            this.label134.Text = "رقم الدخول :";
            // 
            // textBox_VisaNo
            // 
            this.textBox_VisaNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.textBox_VisaNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_VisaNo.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.textBox_VisaNo.Location = new System.Drawing.Point(254, 25);
            this.textBox_VisaNo.MaxLength = 30;
            this.textBox_VisaNo.Name = "textBox_VisaNo";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_VisaNo, false);
            this.textBox_VisaNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox_VisaNo.Size = new System.Drawing.Size(226, 20);
            this.textBox_VisaNo.TabIndex = 856;
            this.textBox_VisaNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_VisaNo.Click += new System.EventHandler(this.textBox_VisaNo_Click);
            this.textBox_VisaNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_ID_KeyPress);
            // 
            // label131
            // 
            this.label131.AutoSize = true;
            this.label131.BackColor = System.Drawing.Color.Transparent;
            this.label131.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label131.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label131.Location = new System.Drawing.Point(481, 29);
            this.label131.Name = "label131";
            this.label131.Size = new System.Drawing.Size(72, 13);
            this.label131.TabIndex = 857;
            this.label131.Text = "رقم التأشيرة :";
            // 
            // comboBox_License_From
            // 
            this.comboBox_License_From.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox_License_From.DisplayMember = "Text";
            this.comboBox_License_From.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBox_License_From.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_License_From.FormattingEnabled = true;
            this.comboBox_License_From.Location = new System.Drawing.Point(41, 352);
            this.comboBox_License_From.Name = "comboBox_License_From";
            this.comboBox_License_From.Size = new System.Drawing.Size(168, 21);
            this.comboBox_License_From.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBox_License_From.TabIndex = 0;
            // 
            // button_SrchLicense
            // 
            this.button_SrchLicense.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchLicense.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchLicense.Location = new System.Drawing.Point(14, 352);
            this.button_SrchLicense.Name = "button_SrchLicense";
            this.button_SrchLicense.Size = new System.Drawing.Size(26, 20);
            this.button_SrchLicense.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchLicense.Symbol = "";
            this.button_SrchLicense.SymbolSize = 12F;
            this.button_SrchLicense.TabIndex = 6801;
            this.button_SrchLicense.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchLicense.Click += new System.EventHandler(this.button_SrchLicense_Click);
            // 
            // line6
            // 
            this.line6.Location = new System.Drawing.Point(-587, 305);
            this.line6.Name = "line6";
            this.line6.Size = new System.Drawing.Size(574, 8);
            this.line6.TabIndex = 6799;
            this.line6.Text = "line6";
            // 
            // bubbleBar5
            // 
            this.bubbleBar5.Alignment = DevComponents.DotNetBar.eBubbleButtonAlignment.Bottom;
            this.bubbleBar5.AntiAlias = true;
            // 
            // 
            // 
            this.bubbleBar5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.bubbleBar5.ButtonBackAreaStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.bubbleBar5.ImageSizeLarge = new System.Drawing.Size(22, 22);
            this.bubbleBar5.ImageSizeNormal = new System.Drawing.Size(22, 22);
            this.bubbleBar5.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.bubbleBar5.Location = new System.Drawing.Point(0, 0);
            this.bubbleBar5.MouseOverTabColors.BorderColor = System.Drawing.SystemColors.Highlight;
            this.bubbleBar5.Name = "bubbleBar5";
            this.bubbleBar5.SelectedTab = this.bubbleBarTab11;
            this.bubbleBar5.SelectedTabColors.BorderColor = System.Drawing.Color.Black;
            this.bubbleBar5.Size = new System.Drawing.Size(0, 0);
            this.bubbleBar5.TabIndex = 6802;
            this.bubbleBar5.Tabs.Add(this.bubbleBarTab11);
            this.bubbleBar5.TabsVisible = false;
            // 
            // bubbleBarTab11
            // 
            this.bubbleBarTab11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(230)))), ((int)(((byte)(247)))));
            this.bubbleBarTab11.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(168)))), ((int)(((byte)(228)))));
            this.bubbleBarTab11.Buttons.AddRange(new DevComponents.DotNetBar.BubbleButton[] {
            this.bubbleButton5});
            this.bubbleBarTab11.DarkBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.bubbleBarTab11.LightBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.bubbleBarTab11.Name = "bubbleBarTab11";
            this.bubbleBarTab11.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Blue;
            this.bubbleBarTab11.Text = string.Empty;
            this.bubbleBarTab11.TextColor = System.Drawing.Color.Black;
            // 
            // bubbleButton5
            // 
            this.bubbleButton5.Name = "bubbleButton5";
            // 
            // dateTimeInput_License_Date
            // 
            this.dateTimeInput_License_Date.Location = new System.Drawing.Point(352, 376);
            this.dateTimeInput_License_Date.Mask = "0000/00/00";
            this.dateTimeInput_License_Date.Name = "dateTimeInput_License_Date";
            this.dateTimeInput_License_Date.Size = new System.Drawing.Size(110, 20);
            this.dateTimeInput_License_Date.TabIndex = 6792;
            this.dateTimeInput_License_Date.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dateTimeInput_License_Date.Click += new System.EventHandler(this.dateTimeInput_License_Date_Click);
            this.dateTimeInput_License_Date.Leave += new System.EventHandler(this.dateTimeInput_License_Date_Leave);
            // 
            // dateTimeInput_License_DateEnd
            // 
            this.dateTimeInput_License_DateEnd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.dateTimeInput_License_DateEnd.Location = new System.Drawing.Point(99, 376);
            this.dateTimeInput_License_DateEnd.Mask = "0000/00/00";
            this.dateTimeInput_License_DateEnd.Name = "dateTimeInput_License_DateEnd";
            this.dateTimeInput_License_DateEnd.Size = new System.Drawing.Size(110, 20);
            this.dateTimeInput_License_DateEnd.TabIndex = 6793;
            this.dateTimeInput_License_DateEnd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dateTimeInput_License_DateEnd.Click += new System.EventHandler(this.dateTimeInput_License_DateEnd_Click);
            this.dateTimeInput_License_DateEnd.Leave += new System.EventHandler(this.dateTimeInput_License_DateEnd_Leave);
            // 
            // textBox_License_No
            // 
            this.textBox_License_No.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.textBox_License_No.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_License_No.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.textBox_License_No.Location = new System.Drawing.Point(333, 352);
            this.textBox_License_No.MaxLength = 15;
            this.textBox_License_No.Name = "textBox_License_No";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_License_No, false);
            this.textBox_License_No.Size = new System.Drawing.Size(129, 21);
            this.textBox_License_No.TabIndex = 6790;
            this.textBox_License_No.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_ID_No_KeyPress);
            // 
            // label109
            // 
            this.label109.AutoSize = true;
            this.label109.BackColor = System.Drawing.Color.Transparent;
            this.label109.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label109.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label109.Location = new System.Drawing.Point(467, 379);
            this.label109.Name = "label109";
            this.label109.Size = new System.Drawing.Size(107, 13);
            this.label109.TabIndex = 6795;
            this.label109.Text = "تــــاريخ إصـــــــدارها :";
            // 
            // label110
            // 
            this.label110.AutoSize = true;
            this.label110.BackColor = System.Drawing.Color.Transparent;
            this.label110.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label110.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label110.Location = new System.Drawing.Point(465, 356);
            this.label110.Name = "label110";
            this.label110.Size = new System.Drawing.Size(111, 13);
            this.label110.TabIndex = 6794;
            this.label110.Text = "رخصـــــــة الموظــــف :";
            // 
            // label111
            // 
            this.label111.AutoSize = true;
            this.label111.BackColor = System.Drawing.Color.Transparent;
            this.label111.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label111.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label111.Location = new System.Drawing.Point(212, 356);
            this.label111.Name = "label111";
            this.label111.Size = new System.Drawing.Size(82, 13);
            this.label111.TabIndex = 6797;
            this.label111.Text = "المصــــــــــــدر :";
            // 
            // label112
            // 
            this.label112.AutoSize = true;
            this.label112.BackColor = System.Drawing.Color.Transparent;
            this.label112.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label112.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label112.Location = new System.Drawing.Point(212, 379);
            this.label112.Name = "label112";
            this.label112.Size = new System.Drawing.Size(81, 13);
            this.label112.TabIndex = 6796;
            this.label112.Text = "تاريخ إنتهائهــــا :";
            // 
            // comboBox_Form_From
            // 
            this.comboBox_Form_From.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox_Form_From.DisplayMember = "Text";
            this.comboBox_Form_From.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBox_Form_From.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Form_From.FormattingEnabled = true;
            this.comboBox_Form_From.ItemHeight = 14;
            this.comboBox_Form_From.Location = new System.Drawing.Point(-548, 254);
            this.comboBox_Form_From.Name = "comboBox_Form_From";
            this.comboBox_Form_From.Size = new System.Drawing.Size(167, 20);
            this.comboBox_Form_From.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBox_Form_From.TabIndex = 6788;
            // 
            // button_SrchForms
            // 
            this.button_SrchForms.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchForms.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchForms.Location = new System.Drawing.Point(-576, 254);
            this.button_SrchForms.Name = "button_SrchForms";
            this.button_SrchForms.Size = new System.Drawing.Size(26, 20);
            this.button_SrchForms.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchForms.Symbol = "";
            this.button_SrchForms.SymbolSize = 12F;
            this.button_SrchForms.TabIndex = 6789;
            this.button_SrchForms.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchForms.Click += new System.EventHandler(this.button_SrchForms_Click);
            // 
            // line5
            // 
            this.line5.Location = new System.Drawing.Point(6, 333);
            this.line5.Name = "line5";
            this.line5.Size = new System.Drawing.Size(574, 8);
            this.line5.TabIndex = 6787;
            this.line5.Text = "line5";
            // 
            // dateTimeInput_Form_Date
            // 
            this.dateTimeInput_Form_Date.Location = new System.Drawing.Point(-238, 278);
            this.dateTimeInput_Form_Date.Mask = "0000/00/00";
            this.dateTimeInput_Form_Date.Name = "dateTimeInput_Form_Date";
            this.dateTimeInput_Form_Date.Size = new System.Drawing.Size(110, 20);
            this.dateTimeInput_Form_Date.TabIndex = 6780;
            this.dateTimeInput_Form_Date.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dateTimeInput_Form_Date.Click += new System.EventHandler(this.dateTimeInput_Form_Date_Click);
            this.dateTimeInput_Form_Date.Leave += new System.EventHandler(this.dateTimeInput_Form_Date_Leave);
            // 
            // dateTimeInput_Form_DateEnd
            // 
            this.dateTimeInput_Form_DateEnd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.dateTimeInput_Form_DateEnd.Location = new System.Drawing.Point(-491, 278);
            this.dateTimeInput_Form_DateEnd.Mask = "0000/00/00";
            this.dateTimeInput_Form_DateEnd.Name = "dateTimeInput_Form_DateEnd";
            this.dateTimeInput_Form_DateEnd.Size = new System.Drawing.Size(110, 20);
            this.dateTimeInput_Form_DateEnd.TabIndex = 6781;
            this.dateTimeInput_Form_DateEnd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dateTimeInput_Form_DateEnd.Click += new System.EventHandler(this.dateTimeInput_Form_DateEnd_Click);
            this.dateTimeInput_Form_DateEnd.Leave += new System.EventHandler(this.dateTimeInput_Form_DateEnd_Leave);
            // 
            // textBox_Form_No
            // 
            this.textBox_Form_No.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.textBox_Form_No.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_Form_No.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.textBox_Form_No.Location = new System.Drawing.Point(-256, 254);
            this.textBox_Form_No.MaxLength = 15;
            this.textBox_Form_No.Name = "textBox_Form_No";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_Form_No, false);
            this.textBox_Form_No.Size = new System.Drawing.Size(129, 21);
            this.textBox_Form_No.TabIndex = 6778;
            this.textBox_Form_No.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_ID_No_KeyPress);
            // 
            // label105
            // 
            this.label105.AutoSize = true;
            this.label105.BackColor = System.Drawing.Color.Transparent;
            this.label105.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label105.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label105.Location = new System.Drawing.Point(-122, 281);
            this.label105.Name = "label105";
            this.label105.Size = new System.Drawing.Size(107, 13);
            this.label105.TabIndex = 6783;
            this.label105.Text = "تــــاريخ إصـــــــدارها :";
            // 
            // label106
            // 
            this.label106.AutoSize = true;
            this.label106.BackColor = System.Drawing.Color.Transparent;
            this.label106.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label106.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label106.Location = new System.Drawing.Point(-124, 258);
            this.label106.Name = "label106";
            this.label106.Size = new System.Drawing.Size(110, 13);
            this.label106.TabIndex = 6782;
            this.label106.Text = "إستمـــارة الموظــــف :";
            // 
            // label107
            // 
            this.label107.AutoSize = true;
            this.label107.BackColor = System.Drawing.Color.Transparent;
            this.label107.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label107.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label107.Location = new System.Drawing.Point(-377, 258);
            this.label107.Name = "label107";
            this.label107.Size = new System.Drawing.Size(82, 13);
            this.label107.TabIndex = 6785;
            this.label107.Text = "المصــــــــــــدر :";
            // 
            // label108
            // 
            this.label108.AutoSize = true;
            this.label108.BackColor = System.Drawing.Color.Transparent;
            this.label108.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label108.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label108.Location = new System.Drawing.Point(-377, 281);
            this.label108.Name = "label108";
            this.label108.Size = new System.Drawing.Size(81, 13);
            this.label108.TabIndex = 6784;
            this.label108.Text = "تاريخ إنتهائهــــا :";
            // 
            // comboBox_Insurance_From
            // 
            this.comboBox_Insurance_From.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox_Insurance_From.DisplayMember = "Text";
            this.comboBox_Insurance_From.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBox_Insurance_From.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Insurance_From.FormattingEnabled = true;
            this.comboBox_Insurance_From.ItemHeight = 14;
            this.comboBox_Insurance_From.Location = new System.Drawing.Point(44, 284);
            this.comboBox_Insurance_From.Name = "comboBox_Insurance_From";
            this.comboBox_Insurance_From.Size = new System.Drawing.Size(167, 20);
            this.comboBox_Insurance_From.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBox_Insurance_From.TabIndex = 6776;
            // 
            // button_SrchInsurance
            // 
            this.button_SrchInsurance.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchInsurance.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchInsurance.Location = new System.Drawing.Point(16, 284);
            this.button_SrchInsurance.Name = "button_SrchInsurance";
            this.button_SrchInsurance.Size = new System.Drawing.Size(26, 20);
            this.button_SrchInsurance.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchInsurance.Symbol = "";
            this.button_SrchInsurance.SymbolSize = 12F;
            this.button_SrchInsurance.TabIndex = 6777;
            this.button_SrchInsurance.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchInsurance.Click += new System.EventHandler(this.button_SrchInsurance_Click);
            // 
            // line4
            // 
            this.line4.Location = new System.Drawing.Point(6, 265);
            this.line4.Name = "line4";
            this.line4.Size = new System.Drawing.Size(574, 8);
            this.line4.TabIndex = 6775;
            this.line4.Text = "line4";
            // 
            // dateTimeInput_Insurance_Date
            // 
            this.dateTimeInput_Insurance_Date.Location = new System.Drawing.Point(355, 308);
            this.dateTimeInput_Insurance_Date.Mask = "0000/00/00";
            this.dateTimeInput_Insurance_Date.Name = "dateTimeInput_Insurance_Date";
            this.dateTimeInput_Insurance_Date.Size = new System.Drawing.Size(110, 20);
            this.dateTimeInput_Insurance_Date.TabIndex = 6769;
            this.dateTimeInput_Insurance_Date.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dateTimeInput_Insurance_Date.Click += new System.EventHandler(this.dateTimeInput_Insurance_Date_Click);
            this.dateTimeInput_Insurance_Date.Leave += new System.EventHandler(this.dateTimeInput_Insurance_Date_Leave);
            // 
            // dateTimeInput_Insurance_DateEnd
            // 
            this.dateTimeInput_Insurance_DateEnd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.dateTimeInput_Insurance_DateEnd.Location = new System.Drawing.Point(100, 308);
            this.dateTimeInput_Insurance_DateEnd.Mask = "0000/00/00";
            this.dateTimeInput_Insurance_DateEnd.Name = "dateTimeInput_Insurance_DateEnd";
            this.dateTimeInput_Insurance_DateEnd.Size = new System.Drawing.Size(110, 20);
            this.dateTimeInput_Insurance_DateEnd.TabIndex = 6770;
            this.dateTimeInput_Insurance_DateEnd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dateTimeInput_Insurance_DateEnd.Click += new System.EventHandler(this.dateTimeInput_Insurance_DateEnd_Click);
            this.dateTimeInput_Insurance_DateEnd.Leave += new System.EventHandler(this.dateTimeInput_Insurance_DateEnd_Leave);
            // 
            // textBox_Insurance_No
            // 
            this.textBox_Insurance_No.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.textBox_Insurance_No.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_Insurance_No.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.textBox_Insurance_No.Location = new System.Drawing.Point(336, 284);
            this.textBox_Insurance_No.MaxLength = 15;
            this.textBox_Insurance_No.Name = "textBox_Insurance_No";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_Insurance_No, false);
            this.textBox_Insurance_No.Size = new System.Drawing.Size(129, 21);
            this.textBox_Insurance_No.TabIndex = 6767;
            this.textBox_Insurance_No.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_ID_No_KeyPress);
            // 
            // label101
            // 
            this.label101.AutoSize = true;
            this.label101.BackColor = System.Drawing.Color.Transparent;
            this.label101.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label101.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label101.Location = new System.Drawing.Point(469, 311);
            this.label101.Name = "label101";
            this.label101.Size = new System.Drawing.Size(107, 13);
            this.label101.TabIndex = 6772;
            this.label101.Text = "تــــاريخ إصـــــــدارها :";
            // 
            // label102
            // 
            this.label102.AutoSize = true;
            this.label102.BackColor = System.Drawing.Color.Transparent;
            this.label102.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label102.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label102.Location = new System.Drawing.Point(469, 288);
            this.label102.Name = "label102";
            this.label102.Size = new System.Drawing.Size(109, 13);
            this.label102.TabIndex = 6771;
            this.label102.Text = "تأمـــــــين الموظــــف :";
            // 
            // label103
            // 
            this.label103.AutoSize = true;
            this.label103.BackColor = System.Drawing.Color.Transparent;
            this.label103.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label103.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label103.Location = new System.Drawing.Point(215, 288);
            this.label103.Name = "label103";
            this.label103.Size = new System.Drawing.Size(82, 13);
            this.label103.TabIndex = 6774;
            this.label103.Text = "المصــــــــــــدر :";
            // 
            // label104
            // 
            this.label104.AutoSize = true;
            this.label104.BackColor = System.Drawing.Color.Transparent;
            this.label104.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label104.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label104.Location = new System.Drawing.Point(215, 311);
            this.label104.Name = "label104";
            this.label104.Size = new System.Drawing.Size(81, 13);
            this.label104.TabIndex = 6773;
            this.label104.Text = "تاريخ إنتهائهــــا :";
            // 
            // comboBox_Passport_From
            // 
            this.comboBox_Passport_From.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox_Passport_From.DisplayMember = "Text";
            this.comboBox_Passport_From.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBox_Passport_From.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Passport_From.FormattingEnabled = true;
            this.comboBox_Passport_From.ItemHeight = 14;
            this.comboBox_Passport_From.Location = new System.Drawing.Point(44, 209);
            this.comboBox_Passport_From.Name = "comboBox_Passport_From";
            this.comboBox_Passport_From.Size = new System.Drawing.Size(167, 20);
            this.comboBox_Passport_From.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBox_Passport_From.TabIndex = 6765;
            // 
            // button_SrchPassport
            // 
            this.button_SrchPassport.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchPassport.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchPassport.Location = new System.Drawing.Point(16, 209);
            this.button_SrchPassport.Name = "button_SrchPassport";
            this.button_SrchPassport.Size = new System.Drawing.Size(26, 20);
            this.button_SrchPassport.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchPassport.Symbol = "";
            this.button_SrchPassport.SymbolSize = 12F;
            this.button_SrchPassport.TabIndex = 6766;
            this.button_SrchPassport.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchPassport.Click += new System.EventHandler(this.button_SrchPassport_Click);
            // 
            // dateTimeInput_Pass_Date
            // 
            this.dateTimeInput_Pass_Date.Location = new System.Drawing.Point(354, 233);
            this.dateTimeInput_Pass_Date.Mask = "0000/00/00";
            this.dateTimeInput_Pass_Date.Name = "dateTimeInput_Pass_Date";
            this.dateTimeInput_Pass_Date.Size = new System.Drawing.Size(110, 20);
            this.dateTimeInput_Pass_Date.TabIndex = 6758;
            this.dateTimeInput_Pass_Date.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dateTimeInput_Pass_Date.Click += new System.EventHandler(this.dateTimeInput_Pass_Date_Click);
            this.dateTimeInput_Pass_Date.Leave += new System.EventHandler(this.dateTimeInput_Pass_Date_Leave);
            // 
            // dateTimeInput_Passport_DateEnd
            // 
            this.dateTimeInput_Passport_DateEnd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.dateTimeInput_Passport_DateEnd.Location = new System.Drawing.Point(101, 233);
            this.dateTimeInput_Passport_DateEnd.Mask = "0000/00/00";
            this.dateTimeInput_Passport_DateEnd.Name = "dateTimeInput_Passport_DateEnd";
            this.dateTimeInput_Passport_DateEnd.Size = new System.Drawing.Size(110, 20);
            this.dateTimeInput_Passport_DateEnd.TabIndex = 6759;
            this.dateTimeInput_Passport_DateEnd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dateTimeInput_Passport_DateEnd.Click += new System.EventHandler(this.dateTimeInput_Passport_DateEnd_Click);
            this.dateTimeInput_Passport_DateEnd.Leave += new System.EventHandler(this.dateTimeInput_Passport_DateEnd_Leave);
            // 
            // textBox_Passport_No
            // 
            this.textBox_Passport_No.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.textBox_Passport_No.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_Passport_No.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.textBox_Passport_No.Location = new System.Drawing.Point(336, 209);
            this.textBox_Passport_No.MaxLength = 15;
            this.textBox_Passport_No.Name = "textBox_Passport_No";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_Passport_No, false);
            this.textBox_Passport_No.Size = new System.Drawing.Size(129, 21);
            this.textBox_Passport_No.TabIndex = 6756;
            this.textBox_Passport_No.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_ID_No_KeyPress);
            // 
            // label96
            // 
            this.label96.AutoSize = true;
            this.label96.BackColor = System.Drawing.Color.Transparent;
            this.label96.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label96.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label96.Location = new System.Drawing.Point(468, 236);
            this.label96.Name = "label96";
            this.label96.Size = new System.Drawing.Size(107, 13);
            this.label96.TabIndex = 6761;
            this.label96.Text = "تــــاريخ إصـــــــدارها :";
            // 
            // label98
            // 
            this.label98.AutoSize = true;
            this.label98.BackColor = System.Drawing.Color.Transparent;
            this.label98.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label98.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label98.Location = new System.Drawing.Point(469, 213);
            this.label98.Name = "label98";
            this.label98.Size = new System.Drawing.Size(107, 13);
            this.label98.TabIndex = 6760;
            this.label98.Text = "جــــــــواز الموظــــف :";
            // 
            // label99
            // 
            this.label99.AutoSize = true;
            this.label99.BackColor = System.Drawing.Color.Transparent;
            this.label99.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label99.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label99.Location = new System.Drawing.Point(215, 213);
            this.label99.Name = "label99";
            this.label99.Size = new System.Drawing.Size(82, 13);
            this.label99.TabIndex = 6763;
            this.label99.Text = "المصــــــــــــدر :";
            // 
            // label100
            // 
            this.label100.AutoSize = true;
            this.label100.BackColor = System.Drawing.Color.Transparent;
            this.label100.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label100.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label100.Location = new System.Drawing.Point(215, 236);
            this.label100.Name = "label100";
            this.label100.Size = new System.Drawing.Size(81, 13);
            this.label100.TabIndex = 6762;
            this.label100.Text = "تاريخ إنتهائهــــا :";
            // 
            // line3
            // 
            this.line3.Location = new System.Drawing.Point(6, 195);
            this.line3.Name = "line3";
            this.line3.Size = new System.Drawing.Size(574, 8);
            this.line3.TabIndex = 6755;
            this.line3.Text = "line3";
            // 
            // comboBox_ID_From
            // 
            this.comboBox_ID_From.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox_ID_From.DisplayMember = "Text";
            this.comboBox_ID_From.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBox_ID_From.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_ID_From.FormattingEnabled = true;
            this.comboBox_ID_From.ItemHeight = 14;
            this.comboBox_ID_From.Location = new System.Drawing.Point(45, 137);
            this.comboBox_ID_From.Name = "comboBox_ID_From";
            this.comboBox_ID_From.Size = new System.Drawing.Size(167, 20);
            this.comboBox_ID_From.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBox_ID_From.TabIndex = 6749;
            // 
            // button_SrchID
            // 
            this.button_SrchID.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchID.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchID.Location = new System.Drawing.Point(17, 137);
            this.button_SrchID.Name = "button_SrchID";
            this.button_SrchID.Size = new System.Drawing.Size(26, 20);
            this.button_SrchID.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchID.Symbol = "";
            this.button_SrchID.SymbolSize = 12F;
            this.button_SrchID.TabIndex = 6750;
            this.button_SrchID.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchID.Click += new System.EventHandler(this.button_SrchID_Click);
            // 
            // dateTimeInput_ID_Date
            // 
            this.dateTimeInput_ID_Date.Location = new System.Drawing.Point(355, 162);
            this.dateTimeInput_ID_Date.Mask = "0000/00/00";
            this.dateTimeInput_ID_Date.Name = "dateTimeInput_ID_Date";
            this.dateTimeInput_ID_Date.Size = new System.Drawing.Size(110, 20);
            this.dateTimeInput_ID_Date.TabIndex = 6677;
            this.dateTimeInput_ID_Date.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dateTimeInput_ID_Date.Click += new System.EventHandler(this.dateTimeInput_ID_Date_Click);
            this.dateTimeInput_ID_Date.Leave += new System.EventHandler(this.dateTimeInput_ID_Date_Leave);
            // 
            // dateTimeInput_ID_DateEnd
            // 
            this.dateTimeInput_ID_DateEnd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.dateTimeInput_ID_DateEnd.Location = new System.Drawing.Point(102, 162);
            this.dateTimeInput_ID_DateEnd.Mask = "0000/00/00";
            this.dateTimeInput_ID_DateEnd.Name = "dateTimeInput_ID_DateEnd";
            this.dateTimeInput_ID_DateEnd.Size = new System.Drawing.Size(110, 20);
            this.dateTimeInput_ID_DateEnd.TabIndex = 6678;
            this.dateTimeInput_ID_DateEnd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dateTimeInput_ID_DateEnd.Click += new System.EventHandler(this.dateTimeInput_ID_DateEnd_Click);
            this.dateTimeInput_ID_DateEnd.Leave += new System.EventHandler(this.dateTimeInput_ID_DateEnd_Leave);
            // 
            // textBox_ID_No
            // 
            this.textBox_ID_No.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.textBox_ID_No.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_ID_No.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.textBox_ID_No.Location = new System.Drawing.Point(336, 137);
            this.textBox_ID_No.MaxLength = 15;
            this.textBox_ID_No.Name = "textBox_ID_No";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_ID_No, false);
            this.textBox_ID_No.Size = new System.Drawing.Size(129, 21);
            this.textBox_ID_No.TabIndex = 6675;
            this.textBox_ID_No.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_ID_No_KeyPress);
            // 
            // label88
            // 
            this.label88.AutoSize = true;
            this.label88.BackColor = System.Drawing.Color.Transparent;
            this.label88.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label88.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label88.Location = new System.Drawing.Point(469, 164);
            this.label88.Name = "label88";
            this.label88.Size = new System.Drawing.Size(107, 13);
            this.label88.TabIndex = 6680;
            this.label88.Text = "تــــاريخ إصـــــــدارها :";
            // 
            // label97
            // 
            this.label97.AutoSize = true;
            this.label97.BackColor = System.Drawing.Color.Transparent;
            this.label97.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label97.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label97.Location = new System.Drawing.Point(469, 141);
            this.label97.Name = "label97";
            this.label97.Size = new System.Drawing.Size(104, 13);
            this.label97.TabIndex = 6679;
            this.label97.Text = "هــــــوية الموظــــف :";
            // 
            // label95
            // 
            this.label95.AutoSize = true;
            this.label95.BackColor = System.Drawing.Color.Transparent;
            this.label95.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label95.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label95.Location = new System.Drawing.Point(215, 141);
            this.label95.Name = "label95";
            this.label95.Size = new System.Drawing.Size(82, 13);
            this.label95.TabIndex = 6682;
            this.label95.Text = "المصــــــــــــدر :";
            // 
            // label92
            // 
            this.label92.AutoSize = true;
            this.label92.BackColor = System.Drawing.Color.Transparent;
            this.label92.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label92.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label92.Location = new System.Drawing.Point(215, 164);
            this.label92.Name = "label92";
            this.label92.Size = new System.Drawing.Size(81, 13);
            this.label92.TabIndex = 6681;
            this.label92.Text = "تاريخ إنتهائهــــا :";
            // 
            // labelX20
            // 
            this.labelX20.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX20.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX20.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelX20.Location = new System.Drawing.Point(0, 0);
            this.labelX20.Name = "labelX20";
            this.labelX20.Size = new System.Drawing.Size(594, 419);
            this.labelX20.TabIndex = 8;
            this.labelX20.Text = "This space intentionally left blank.";
            this.labelX20.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // superTabItem_Doc
            // 
            this.superTabItem_Doc.AttachedControl = this.superTabControlPanel19;
            this.superTabItem_Doc.CloseButtonVisible = false;
            this.superTabItem_Doc.GlobalItem = false;
            this.superTabItem_Doc.Name = "superTabItem_Doc";
            this.superTabItem_Doc.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Lemon;
            this.superTabItem_Doc.Text = "الـوثـــائق";
            // 
            // buttonX_OpenFiles
            // 
            this.buttonX_OpenFiles.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonX_OpenFiles.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.buttonX_OpenFiles.FontBold = true;
            this.buttonX_OpenFiles.HotFontBold = true;
            this.buttonX_OpenFiles.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Center;
            this.buttonX_OpenFiles.Name = "buttonX_OpenFiles";
            this.buttonX_OpenFiles.Stretch = true;
            this.buttonX_OpenFiles.Text = "  إضافة الوثائق";
            this.buttonX_OpenFiles.Tooltip = "إضافة وثائق وصور الموظف";
            this.buttonX_OpenFiles.Click += new System.EventHandler(this.buttonX_OpenFiles_Click);
            // 
            // buttonX_BrowserScannerFiles
            // 
            this.buttonX_BrowserScannerFiles.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonX_BrowserScannerFiles.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.buttonX_BrowserScannerFiles.FontBold = true;
            this.buttonX_BrowserScannerFiles.HotFontBold = true;
            this.buttonX_BrowserScannerFiles.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Center;
            this.buttonX_BrowserScannerFiles.Name = "buttonX_BrowserScannerFiles";
            this.buttonX_BrowserScannerFiles.Stretch = true;
            this.buttonX_BrowserScannerFiles.Text = "  عرض الوثائق";
            this.buttonX_BrowserScannerFiles.Tooltip = "عرض وثائق وصور الموظف";
            this.buttonX_BrowserScannerFiles.Click += new System.EventHandler(this.buttonX_BrowserScannerFiles_Click);
            // 
            // buttonItem_EmpOut
            // 
            this.buttonItem_EmpOut.AutoCheckOnClick = true;
            this.buttonItem_EmpOut.BeginGroup = true;
            this.buttonItem_EmpOut.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonItem_EmpOut.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.buttonItem_EmpOut.FontBold = true;
            this.buttonItem_EmpOut.HotFontBold = true;
            this.buttonItem_EmpOut.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Center;
            this.buttonItem_EmpOut.Name = "buttonItem_EmpOut";
            this.buttonItem_EmpOut.Stretch = true;
            this.buttonItem_EmpOut.SymbolSize = 5F;
            this.buttonItem_EmpOut.Text = "    المفصولين";
            this.buttonItem_EmpOut.CheckedChanged += new System.EventHandler(this.buttonItem_EmpOut_CheckedChanged);
            // 
            // ribbonBar_Tasks
            // 
            this.ribbonBar_Tasks.AutoOverflowEnabled = true;
            // 
            // 
            // 
            this.ribbonBar_Tasks.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar_Tasks.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar_Tasks.ContainerControlProcessDialogKey = true;
            this.ribbonBar_Tasks.Controls.Add(this.superTabControl_Main1);
            this.ribbonBar_Tasks.Controls.Add(this.superTabControl_Main2);
            this.ribbonBar_Tasks.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ribbonBar_Tasks.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.ribbonBar_Tasks.Location = new System.Drawing.Point(0, 436);
            this.ribbonBar_Tasks.Name = "ribbonBar_Tasks";
            this.ribbonBar_Tasks.Size = new System.Drawing.Size(677, 51);
            this.ribbonBar_Tasks.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonBar_Tasks.TabIndex = 868;
            // 
            // 
            // 
            this.ribbonBar_Tasks.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar_Tasks.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar_Tasks.TitleVisible = false;
            // 
            // superTabControl_Main1
            // 
            this.superTabControl_Main1.BackColor = System.Drawing.Color.White;
            this.superTabControl_Main1.CausesValidation = false;
            // 
            // 
            // 
            // 
            // 
            // 
            this.superTabControl_Main1.ControlBox.CloseBox.Name = string.Empty;
            // 
            // 
            // 
            this.superTabControl_Main1.ControlBox.MenuBox.Name = string.Empty;
            this.superTabControl_Main1.ControlBox.Name = string.Empty;
            this.superTabControl_Main1.ControlBox.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.superTabControl_Main1.ControlBox.MenuBox,
            this.superTabControl_Main1.ControlBox.CloseBox});
            this.superTabControl_Main1.ControlBox.Visible = false;
            this.superTabControl_Main1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControl_Main1.ForeColor = System.Drawing.Color.Black;
            this.superTabControl_Main1.ItemPadding.Bottom = 4;
            this.superTabControl_Main1.ItemPadding.Left = 2;
            this.superTabControl_Main1.ItemPadding.Top = 4;
            this.superTabControl_Main1.Location = new System.Drawing.Point(0, 0);
            this.superTabControl_Main1.Name = "superTabControl_Main1";
            this.superTabControl_Main1.ReorderTabsEnabled = true;
            this.superTabControl_Main1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.superTabControl_Main1.SelectedTabFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.superTabControl_Main1.SelectedTabIndex = -1;
            this.superTabControl_Main1.Size = new System.Drawing.Size(310, 51);
            this.superTabControl_Main1.TabFont = new System.Drawing.Font("Tahoma", 8F);
            this.superTabControl_Main1.TabIndex = 10;
            this.superTabControl_Main1.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.Button_Close,
            this.buttonItem_Back,
            this.Button_Search,
            this.Button_Delete,
            this.Button_Save,
            this.Button_Add,
            this.labelItem2});
            this.superTabControl_Main1.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.WinMediaPlayer12;
            this.superTabControl_Main1.Text = "superTabControl3";
            this.superTabControl_Main1.TextAlignment = DevComponents.DotNetBar.eItemAlignment.Center;
            // 
            // Button_Close
            // 
            this.Button_Close.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.Button_Close.Checked = true;
            this.Button_Close.FontBold = true;
            this.Button_Close.FontItalic = true;
            this.Button_Close.ForeColor = System.Drawing.Color.Black;
            this.Button_Close.Image = ((System.Drawing.Image)(resources.GetObject("Button_Close.Image")));
            this.Button_Close.ImageFixedSize = new System.Drawing.Size(28, 28);
            this.Button_Close.ImagePaddingHorizontal = 15;
            this.Button_Close.ImagePaddingVertical = 11;
            this.Button_Close.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.Button_Close.Name = "Button_Close";
            this.Button_Close.Stretch = true;
            this.Button_Close.SubItemsExpandWidth = 14;
            this.Button_Close.Symbol = "";
            this.Button_Close.SymbolSize = 15F;
            this.Button_Close.Text = "إغلاق";
            this.Button_Close.Tooltip = "إغلاق النافذة الحالية";
            // 
            // buttonItem_Back
            // 
            this.buttonItem_Back.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonItem_Back.FontBold = true;
            this.buttonItem_Back.FontItalic = true;
            this.buttonItem_Back.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.buttonItem_Back.Image = ((System.Drawing.Image)(resources.GetObject("buttonItem_Back.Image")));
            this.buttonItem_Back.ImageFixedSize = new System.Drawing.Size(28, 28);
            this.buttonItem_Back.ImagePaddingHorizontal = 15;
            this.buttonItem_Back.ImagePaddingVertical = 11;
            this.buttonItem_Back.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.buttonItem_Back.Name = "buttonItem_Back";
            this.buttonItem_Back.Stretch = true;
            this.buttonItem_Back.SubItemsExpandWidth = 14;
            this.buttonItem_Back.Symbol = "";
            this.buttonItem_Back.SymbolSize = 15F;
            this.buttonItem_Back.Text = "إسترجاع";
            this.buttonItem_Back.Tooltip = "إسترجاع الموظف";
            this.buttonItem_Back.Visible = false;
            this.buttonItem_Back.Click += new System.EventHandler(this.buttonItem_Back_Click);
            // 
            // Button_Search
            // 
            this.Button_Search.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.Button_Search.FontBold = true;
            this.Button_Search.FontItalic = true;
            this.Button_Search.ForeColor = System.Drawing.Color.Green;
            this.Button_Search.Image = ((System.Drawing.Image)(resources.GetObject("Button_Search.Image")));
            this.Button_Search.ImageFixedSize = new System.Drawing.Size(28, 28);
            this.Button_Search.ImagePaddingHorizontal = 15;
            this.Button_Search.ImagePaddingVertical = 11;
            this.Button_Search.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.Button_Search.Name = "Button_Search";
            this.Button_Search.Stretch = true;
            this.Button_Search.SubItemsExpandWidth = 14;
            this.Button_Search.Symbol = "";
            this.Button_Search.SymbolSize = 15F;
            this.Button_Search.Text = "بحث";
            this.Button_Search.Tooltip = "البحث عن سجل ما";
            // 
            // Button_Delete
            // 
            this.Button_Delete.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.Button_Delete.FontBold = true;
            this.Button_Delete.FontItalic = true;
            this.Button_Delete.ForeColor = System.Drawing.Color.SteelBlue;
            this.Button_Delete.Image = ((System.Drawing.Image)(resources.GetObject("Button_Delete.Image")));
            this.Button_Delete.ImageFixedSize = new System.Drawing.Size(28, 28);
            this.Button_Delete.ImagePaddingHorizontal = 15;
            this.Button_Delete.ImagePaddingVertical = 11;
            this.Button_Delete.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.Button_Delete.Name = "Button_Delete";
            this.Button_Delete.Stretch = true;
            this.Button_Delete.SubItemsExpandWidth = 14;
            this.Button_Delete.Symbol = "";
            this.Button_Delete.SymbolSize = 15F;
            this.Button_Delete.Text = "حذف";
            this.Button_Delete.Tooltip = "حذف السجل الحالي";
            // 
            // Button_Save
            // 
            this.Button_Save.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.Button_Save.FontBold = true;
            this.Button_Save.FontItalic = true;
            this.Button_Save.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.Button_Save.Image = ((System.Drawing.Image)(resources.GetObject("Button_Save.Image")));
            this.Button_Save.ImageFixedSize = new System.Drawing.Size(28, 28);
            this.Button_Save.ImagePaddingHorizontal = 15;
            this.Button_Save.ImagePaddingVertical = 11;
            this.Button_Save.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.Button_Save.Name = "Button_Save";
            this.Button_Save.Stretch = true;
            this.Button_Save.SubItemsExpandWidth = 14;
            this.Button_Save.Symbol = "";
            this.Button_Save.SymbolSize = 15F;
            this.Button_Save.Text = "حفظ";
            this.Button_Save.Tooltip = "حفظ التغييرات";
            // 
            // Button_Add
            // 
            this.Button_Add.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.Button_Add.FontBold = true;
            this.Button_Add.FontItalic = true;
            this.Button_Add.ForeColor = System.Drawing.Color.Blue;
            this.Button_Add.Image = ((System.Drawing.Image)(resources.GetObject("Button_Add.Image")));
            this.Button_Add.ImageFixedSize = new System.Drawing.Size(28, 28);
            this.Button_Add.ImagePaddingHorizontal = 15;
            this.Button_Add.ImagePaddingVertical = 11;
            this.Button_Add.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.Button_Add.Name = "Button_Add";
            this.Button_Add.Stretch = true;
            this.Button_Add.SubItemsExpandWidth = 14;
            this.Button_Add.Symbol = "";
            this.Button_Add.SymbolSize = 15F;
            this.Button_Add.Text = "إضافة";
            this.Button_Add.Tooltip = "إضافة سجل جديد";
            // 
            // labelItem2
            // 
            this.labelItem2.Name = "labelItem2";
            this.labelItem2.Width = 40;
            // 
            // superTabControl_Main2
            // 
            this.superTabControl_Main2.BackColor = System.Drawing.Color.White;
            this.superTabControl_Main2.CausesValidation = false;
            // 
            // 
            // 
            // 
            // 
            // 
            this.superTabControl_Main2.ControlBox.CloseBox.Name = string.Empty;
            // 
            // 
            // 
            this.superTabControl_Main2.ControlBox.MenuBox.Name = string.Empty;
            this.superTabControl_Main2.ControlBox.Name = string.Empty;
            this.superTabControl_Main2.ControlBox.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.superTabControl_Main2.ControlBox.MenuBox,
            this.superTabControl_Main2.ControlBox.CloseBox});
            this.superTabControl_Main2.ControlBox.Visible = false;
            this.superTabControl_Main2.Dock = System.Windows.Forms.DockStyle.Right;
            this.superTabControl_Main2.ForeColor = System.Drawing.Color.Black;
            this.superTabControl_Main2.ItemPadding.Bottom = 4;
            this.superTabControl_Main2.ItemPadding.Left = 4;
            this.superTabControl_Main2.ItemPadding.Right = 4;
            this.superTabControl_Main2.ItemPadding.Top = 4;
            this.superTabControl_Main2.Location = new System.Drawing.Point(310, 0);
            this.superTabControl_Main2.Name = "superTabControl_Main2";
            this.superTabControl_Main2.ReorderTabsEnabled = true;
            this.superTabControl_Main2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.superTabControl_Main2.SelectedTabFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.superTabControl_Main2.SelectedTabIndex = -1;
            this.superTabControl_Main2.Size = new System.Drawing.Size(367, 51);
            this.superTabControl_Main2.TabFont = new System.Drawing.Font("Tahoma", 8F);
            this.superTabControl_Main2.TabIndex = 11;
            this.superTabControl_Main2.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.labelItem1,
            this.Button_First,
            this.Button_Prev,
            this.TextBox_Index,
            this.Label_Count,
            this.lable_Records,
            this.Button_Next,
            this.Button_Last});
            this.superTabControl_Main2.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.WinMediaPlayer12;
            this.superTabControl_Main2.Text = "superTabControl1";
            this.superTabControl_Main2.TextAlignment = DevComponents.DotNetBar.eItemAlignment.Center;
            // 
            // labelItem1
            // 
            this.labelItem1.Name = "labelItem1";
            this.labelItem1.Width = 2;
            // 
            // Button_First
            // 
            this.Button_First.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.Button_First.FontBold = true;
            this.Button_First.FontItalic = true;
            this.Button_First.ForeColor = System.Drawing.Color.SteelBlue;
            this.Button_First.Image = ((System.Drawing.Image)(resources.GetObject("Button_First.Image")));
            this.Button_First.ImageFixedSize = new System.Drawing.Size(28, 28);
            this.Button_First.ImagePaddingHorizontal = 15;
            this.Button_First.ImagePaddingVertical = 11;
            this.Button_First.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.Button_First.Name = "Button_First";
            this.Button_First.SplitButton = true;
            this.Button_First.Stretch = true;
            this.Button_First.SubItemsExpandWidth = 14;
            this.Button_First.Symbol = "";
            this.Button_First.SymbolSize = 15F;
            this.Button_First.Text = "الأول";
            this.Button_First.Tooltip = "السجل الاول";
            // 
            // Button_Prev
            // 
            this.Button_Prev.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.Button_Prev.FontBold = true;
            this.Button_Prev.FontItalic = true;
            this.Button_Prev.ForeColor = System.Drawing.Color.SteelBlue;
            this.Button_Prev.Image = ((System.Drawing.Image)(resources.GetObject("Button_Prev.Image")));
            this.Button_Prev.ImageFixedSize = new System.Drawing.Size(28, 28);
            this.Button_Prev.ImagePaddingHorizontal = 15;
            this.Button_Prev.ImagePaddingVertical = 11;
            this.Button_Prev.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.Button_Prev.Name = "Button_Prev";
            this.Button_Prev.SplitButton = true;
            this.Button_Prev.Stretch = true;
            this.Button_Prev.SubItemsExpandWidth = 14;
            this.Button_Prev.Symbol = "";
            this.Button_Prev.SymbolSize = 15F;
            this.Button_Prev.Text = "السابق";
            this.Button_Prev.Tooltip = "السجل السابق";
            // 
            // TextBox_Index
            // 
            this.TextBox_Index.Name = "TextBox_Index";
            this.TextBox_Index.TextBoxWidth = 40;
            this.TextBox_Index.Visible = false;
            this.TextBox_Index.WatermarkColor = System.Drawing.SystemColors.GrayText;
            // 
            // Label_Count
            // 
            this.Label_Count.Name = "Label_Count";
            this.Label_Count.Visible = false;
            this.Label_Count.Width = 35;
            // 
            // lable_Records
            // 
            this.lable_Records.BackColor = System.Drawing.Color.SteelBlue;
            this.lable_Records.ForeColor = System.Drawing.Color.White;
            this.lable_Records.Name = "lable_Records";
            this.lable_Records.Text = "---";
            // 
            // Button_Next
            // 
            this.Button_Next.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.Button_Next.FontBold = true;
            this.Button_Next.FontItalic = true;
            this.Button_Next.ForeColor = System.Drawing.Color.SteelBlue;
            this.Button_Next.Image = ((System.Drawing.Image)(resources.GetObject("Button_Next.Image")));
            this.Button_Next.ImageFixedSize = new System.Drawing.Size(28, 28);
            this.Button_Next.ImagePaddingHorizontal = 15;
            this.Button_Next.ImagePaddingVertical = 11;
            this.Button_Next.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.Button_Next.Name = "Button_Next";
            this.Button_Next.SplitButton = true;
            this.Button_Next.Stretch = true;
            this.Button_Next.SubItemsExpandWidth = 14;
            this.Button_Next.Symbol = "";
            this.Button_Next.SymbolSize = 15F;
            this.Button_Next.Text = "التالي";
            this.Button_Next.Tooltip = " السجل التالي";
            // 
            // Button_Last
            // 
            this.Button_Last.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.Button_Last.FontBold = true;
            this.Button_Last.FontItalic = true;
            this.Button_Last.ForeColor = System.Drawing.Color.SteelBlue;
            this.Button_Last.Image = ((System.Drawing.Image)(resources.GetObject("Button_Last.Image")));
            this.Button_Last.ImageFixedSize = new System.Drawing.Size(28, 28);
            this.Button_Last.ImagePaddingHorizontal = 15;
            this.Button_Last.ImagePaddingVertical = 11;
            this.Button_Last.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.Button_Last.Name = "Button_Last";
            this.Button_Last.SplitButton = true;
            this.Button_Last.Stretch = true;
            this.Button_Last.SubItemsExpandWidth = 14;
            this.Button_Last.Symbol = "";
            this.Button_Last.SymbolSize = 15F;
            this.Button_Last.Text = "الأخير";
            this.Button_Last.Tooltip = " السجل الاخير";
            // 
            // expandableSplitter1
            // 
            this.expandableSplitter1.BackColor = System.Drawing.Color.Black;
            this.expandableSplitter1.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.expandableSplitter1.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.None;
            this.expandableSplitter1.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.None;
            this.expandableSplitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.expandableSplitter1.ExpandableControl = this.panelEx2;
            this.expandableSplitter1.ExpandFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(45)))), ((int)(((byte)(150)))));
            this.expandableSplitter1.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter1.ExpandLineColor = System.Drawing.SystemColors.ControlText;
            this.expandableSplitter1.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandableSplitter1.ForeColor = System.Drawing.Color.Black;
            this.expandableSplitter1.GripDarkColor = System.Drawing.SystemColors.ControlText;
            this.expandableSplitter1.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandableSplitter1.GripLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.expandableSplitter1.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.expandableSplitter1.HotBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(142)))), ((int)(((byte)(75)))));
            this.expandableSplitter1.HotBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(207)))), ((int)(((byte)(139)))));
            this.expandableSplitter1.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2;
            this.expandableSplitter1.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground;
            this.expandableSplitter1.HotExpandFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(45)))), ((int)(((byte)(150)))));
            this.expandableSplitter1.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter1.HotExpandLineColor = System.Drawing.SystemColors.ControlText;
            this.expandableSplitter1.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandableSplitter1.HotGripDarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(45)))), ((int)(((byte)(150)))));
            this.expandableSplitter1.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter1.HotGripLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.expandableSplitter1.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.expandableSplitter1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.expandableSplitter1.Location = new System.Drawing.Point(0, -1);
            this.expandableSplitter1.Name = "expandableSplitter1";
            this.expandableSplitter1.Size = new System.Drawing.Size(677, 14);
            this.expandableSplitter1.TabIndex = 1;
            this.expandableSplitter1.TabStop = false;
            // 
            // panelEx3
            // 
            this.panelEx3.Controls.Add(this.DGV_Main);
            this.panelEx3.Controls.Add(this.ribbonBar_DGV);
            this.panelEx3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx3.Location = new System.Drawing.Point(0, 0);
            this.panelEx3.Name = "panelEx3";
            this.panelEx3.Size = new System.Drawing.Size(677, 0);
            this.panelEx3.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx3.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.panelEx3.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.panelEx3.Style.BackgroundImagePosition = DevComponents.DotNetBar.eBackgroundImagePosition.Tile;
            this.panelEx3.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.panelEx3.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.panelEx3.Style.GradientAngle = 90;
            this.panelEx3.TabIndex = 2;
            this.panelEx3.Text = "Fill Panel";
            // 
            // DGV_Main
            // 
            this.DGV_Main.BackColor = System.Drawing.Color.Transparent;
            background1.BackFillType = DevComponents.DotNetBar.SuperGrid.Style.BackFillType.VerticalCenter;
            background1.Color1 = System.Drawing.Color.Silver;
            background1.Color2 = System.Drawing.Color.White;
            this.DGV_Main.DefaultVisualStyles.GroupByStyles.Default.Background = background1;
            background2.BackFillType = DevComponents.DotNetBar.SuperGrid.Style.BackFillType.Center;
            background2.Color1 = System.Drawing.Color.LightSteelBlue;
            this.DGV_Main.DefaultVisualStyles.RowStyles.Default.Background = background2;
            background3.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.DGV_Main.DefaultVisualStyles.RowStyles.MouseOver.Background = background3;
            this.DGV_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGV_Main.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            this.DGV_Main.Font = new System.Drawing.Font("Tahoma", 9F);
            this.DGV_Main.ForeColor = System.Drawing.Color.Black;
            this.DGV_Main.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.DGV_Main.Location = new System.Drawing.Point(0, 0);
            this.DGV_Main.Name = "DGV_Main";
            this.DGV_Main.PrimaryGrid.ActiveRowIndicatorStyle = DevComponents.DotNetBar.SuperGrid.ActiveRowIndicatorStyle.Both;
            this.DGV_Main.PrimaryGrid.AllowEdit = false;
            this.DGV_Main.PrimaryGrid.Caption.BackgroundImageLayout = DevComponents.DotNetBar.SuperGrid.GridBackgroundImageLayout.Center;
            this.DGV_Main.PrimaryGrid.Caption.Text = string.Empty;
            this.DGV_Main.PrimaryGrid.Caption.Visible = false;
            this.DGV_Main.PrimaryGrid.DefaultVisualStyles.AlternateColumnCellStyles.Default.AllowWrap = DevComponents.DotNetBar.SuperGrid.Style.Tbool.False;
            this.DGV_Main.PrimaryGrid.DefaultVisualStyles.AlternateColumnCellStyles.Default.TextColor = System.Drawing.Color.Black;
            this.DGV_Main.PrimaryGrid.DefaultVisualStyles.AlternateRowCellStyles.Default.AllowWrap = DevComponents.DotNetBar.SuperGrid.Style.Tbool.False;
            this.DGV_Main.PrimaryGrid.DefaultVisualStyles.AlternateRowCellStyles.Default.TextColor = System.Drawing.Color.Black;
            this.DGV_Main.PrimaryGrid.DefaultVisualStyles.CaptionStyles.Default.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DGV_Main.PrimaryGrid.DefaultVisualStyles.CaptionStyles.Default.TextColor = System.Drawing.Color.White;
            this.DGV_Main.PrimaryGrid.DefaultVisualStyles.CaptionStyles.ReadOnly.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            this.DGV_Main.PrimaryGrid.DefaultVisualStyles.CellStyles.Selected.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            this.DGV_Main.PrimaryGrid.DefaultVisualStyles.ColumnHeaderRowStyles.Default.RowHeader.AllowWrap = DevComponents.DotNetBar.SuperGrid.Style.Tbool.True;
            borderColor1.Bottom = System.Drawing.Color.Black;
            borderColor1.Left = System.Drawing.Color.Black;
            borderColor1.Right = System.Drawing.Color.Black;
            borderColor1.Top = System.Drawing.Color.Black;
            this.DGV_Main.PrimaryGrid.DefaultVisualStyles.ColumnHeaderStyles.Default.BorderColor = borderColor1;
            this.DGV_Main.PrimaryGrid.DefaultVisualStyles.ColumnHeaderStyles.Default.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DGV_Main.PrimaryGrid.DefaultVisualStyles.ColumnHeaderStyles.Default.TextColor = System.Drawing.Color.SteelBlue;
            this.DGV_Main.PrimaryGrid.DefaultVisualStyles.FilterColumnHeaderStyles.Default.TextColor = System.Drawing.Color.White;
            this.DGV_Main.PrimaryGrid.DefaultVisualStyles.FooterStyles.Default.TextColor = System.Drawing.Color.White;
            this.DGV_Main.PrimaryGrid.DefaultVisualStyles.GridPanelStyle.AllowWrap = DevComponents.DotNetBar.SuperGrid.Style.Tbool.False;
            borderColor2.Bottom = System.Drawing.Color.Black;
            borderColor2.Left = System.Drawing.Color.Black;
            borderColor2.Right = System.Drawing.Color.Black;
            borderColor2.Top = System.Drawing.Color.Black;
            this.DGV_Main.PrimaryGrid.DefaultVisualStyles.GridPanelStyle.BorderColor = borderColor2;
            baseTreeButtonVisualStyle1.BorderColor = System.Drawing.Color.White;
            baseTreeButtonVisualStyle1.LineColor = System.Drawing.Color.White;
            this.DGV_Main.PrimaryGrid.DefaultVisualStyles.GridPanelStyle.CircleTreeButtonStyle.ExpandButton = baseTreeButtonVisualStyle1;
            this.DGV_Main.PrimaryGrid.DefaultVisualStyles.GridPanelStyle.HeaderHLinePattern = DevComponents.DotNetBar.SuperGrid.Style.LinePattern.None;
            background4.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            baseTreeButtonVisualStyle2.Background = background4;
            this.DGV_Main.PrimaryGrid.DefaultVisualStyles.GridPanelStyle.SquareTreeButtonStyle.ExpandButton = baseTreeButtonVisualStyle2;
            this.DGV_Main.PrimaryGrid.DefaultVisualStyles.GridPanelStyle.TextColor = System.Drawing.Color.White;
            this.DGV_Main.PrimaryGrid.DefaultVisualStyles.TitleStyles.Default.RowHeaderStyle.TextAlignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            this.DGV_Main.PrimaryGrid.GroupByRow.RowHeaderVisibility = DevComponents.DotNetBar.SuperGrid.RowHeaderVisibility.Never;
            this.DGV_Main.PrimaryGrid.GroupByRow.Text = "جميــع السجــــلات";
            this.DGV_Main.PrimaryGrid.GroupByRow.Visible = true;
            this.DGV_Main.PrimaryGrid.GroupByRow.WatermarkText = string.Empty;
            this.DGV_Main.PrimaryGrid.InitialActiveRow = DevComponents.DotNetBar.SuperGrid.RelativeRow.None;
            this.DGV_Main.PrimaryGrid.InitialSelection = DevComponents.DotNetBar.SuperGrid.RelativeSelection.None;
            this.DGV_Main.PrimaryGrid.MultiSelect = false;
            this.DGV_Main.PrimaryGrid.ShowRowGridIndex = true;
            this.DGV_Main.PrimaryGrid.Title.AllowSelection = false;
            this.DGV_Main.PrimaryGrid.Title.Text = string.Empty;
            this.DGV_Main.PrimaryGrid.Title.Visible = false;
            this.DGV_Main.PrimaryGrid.Visible = false;
            this.DGV_Main.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.DGV_Main.Size = new System.Drawing.Size(677, 0);
            this.DGV_Main.TabIndex = 862;
            // 
            // ribbonBar_DGV
            // 
            this.ribbonBar_DGV.AutoOverflowEnabled = true;
            // 
            // 
            // 
            this.ribbonBar_DGV.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar_DGV.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar_DGV.ContainerControlProcessDialogKey = true;
            this.ribbonBar_DGV.Controls.Add(this.superTabControl_DGV);
            this.ribbonBar_DGV.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ribbonBar_DGV.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.ribbonBar_DGV.Location = new System.Drawing.Point(0, -51);
            this.ribbonBar_DGV.Name = "ribbonBar_DGV";
            this.ribbonBar_DGV.Size = new System.Drawing.Size(677, 51);
            this.ribbonBar_DGV.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonBar_DGV.TabIndex = 869;
            // 
            // 
            // 
            this.ribbonBar_DGV.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar_DGV.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar_DGV.TitleVisible = false;
            // 
            // superTabControl_DGV
            // 
            this.superTabControl_DGV.BackColor = System.Drawing.Color.White;
            this.superTabControl_DGV.CausesValidation = false;
            // 
            // 
            // 
            // 
            // 
            // 
            this.superTabControl_DGV.ControlBox.CloseBox.Name = string.Empty;
            // 
            // 
            // 
            this.superTabControl_DGV.ControlBox.MenuBox.Name = string.Empty;
            this.superTabControl_DGV.ControlBox.Name = string.Empty;
            this.superTabControl_DGV.ControlBox.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.superTabControl_DGV.ControlBox.MenuBox,
            this.superTabControl_DGV.ControlBox.CloseBox});
            this.superTabControl_DGV.ControlBox.Visible = false;
            this.superTabControl_DGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControl_DGV.ForeColor = System.Drawing.Color.Black;
            this.superTabControl_DGV.ItemPadding.Bottom = 4;
            this.superTabControl_DGV.ItemPadding.Left = 4;
            this.superTabControl_DGV.ItemPadding.Right = 4;
            this.superTabControl_DGV.ItemPadding.Top = 4;
            this.superTabControl_DGV.Location = new System.Drawing.Point(0, 0);
            this.superTabControl_DGV.Name = "superTabControl_DGV";
            this.superTabControl_DGV.ReorderTabsEnabled = true;
            this.superTabControl_DGV.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.superTabControl_DGV.SelectedTabFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.superTabControl_DGV.SelectedTabIndex = -1;
            this.superTabControl_DGV.Size = new System.Drawing.Size(677, 51);
            this.superTabControl_DGV.TabFont = new System.Drawing.Font("Tahoma", 8F);
            this.superTabControl_DGV.TabIndex = 12;
            this.superTabControl_DGV.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.textBox_search,
            this.Button_ExportTable2,
            this.Button_PrintTable,
            this.labelItem3});
            this.superTabControl_DGV.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.WinMediaPlayer12;
            this.superTabControl_DGV.Text = "superTabControl1";
            this.superTabControl_DGV.TextAlignment = DevComponents.DotNetBar.eItemAlignment.Center;
            // 
            // textBox_search
            // 
            this.textBox_search.ButtonCustom.Text = "...";
            this.textBox_search.ButtonCustom.Visible = true;
            this.textBox_search.Name = "textBox_search";
            this.textBox_search.TextBoxHeight = 44;
            this.textBox_search.TextBoxWidth = 150;
            this.textBox_search.WatermarkColor = System.Drawing.SystemColors.GrayText;
            // 
            // Button_ExportTable2
            // 
            this.Button_ExportTable2.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.Button_ExportTable2.FontBold = true;
            this.Button_ExportTable2.FontItalic = true;
            this.Button_ExportTable2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Button_ExportTable2.Image = ((System.Drawing.Image)(resources.GetObject("Button_ExportTable2.Image")));
            this.Button_ExportTable2.ImageFixedSize = new System.Drawing.Size(32, 32);
            this.Button_ExportTable2.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.Button_ExportTable2.Name = "Button_ExportTable2";
            this.Button_ExportTable2.SubItemsExpandWidth = 14;
            this.Button_ExportTable2.Symbol = "";
            this.Button_ExportTable2.SymbolSize = 15F;
            this.Button_ExportTable2.Text = "تصدير";
            this.Button_ExportTable2.Tooltip = "تصدير الى الأكسيل";
            // 
            // Button_PrintTable
            // 
            this.Button_PrintTable.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.Button_PrintTable.Checked = true;
            this.Button_PrintTable.FontBold = true;
            this.Button_PrintTable.FontItalic = true;
            this.Button_PrintTable.Image = ((System.Drawing.Image)(resources.GetObject("Button_PrintTable.Image")));
            this.Button_PrintTable.ImageFixedSize = new System.Drawing.Size(32, 32);
            this.Button_PrintTable.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.Button_PrintTable.Name = "Button_PrintTable";
            this.Button_PrintTable.SubItemsExpandWidth = 14;
            this.Button_PrintTable.Symbol = "";
            this.Button_PrintTable.SymbolSize = 15F;
            this.Button_PrintTable.Text = "طباعة";
            this.Button_PrintTable.Tooltip = "طباعة";
            // 
            // labelItem3
            // 
            this.labelItem3.Name = "labelItem3";
            this.labelItem3.Width = 40;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panelEx3);
            this.panel1.Controls.Add(this.expandableSplitter1);
            this.panel1.Controls.Add(this.panelEx2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(677, 500);
            this.panel1.TabIndex = 897;
            // 
            // listBox_ImageFiles
            // 
            this.listBox_ImageFiles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.listBox_ImageFiles.ForeColor = System.Drawing.Color.Silver;
            this.listBox_ImageFiles.FormattingEnabled = true;
            this.listBox_ImageFiles.Location = new System.Drawing.Point(-42, 341);
            this.listBox_ImageFiles.Name = "listBox_ImageFiles";
            this.listBox_ImageFiles.Size = new System.Drawing.Size(20, 30);
            this.listBox_ImageFiles.TabIndex = 898;
            // 
            // listBox_ImageFiles2
            // 
            this.listBox_ImageFiles2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.listBox_ImageFiles2.ForeColor = System.Drawing.Color.Silver;
            this.listBox_ImageFiles2.FormattingEnabled = true;
            this.listBox_ImageFiles2.Location = new System.Drawing.Point(-46, 348);
            this.listBox_ImageFiles2.Name = "listBox_ImageFiles2";
            this.listBox_ImageFiles2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.listBox_ImageFiles2.Size = new System.Drawing.Size(29, 17);
            this.listBox_ImageFiles2.TabIndex = 899;
            // 
            // FrmEmp
            // 
            this.ClientSize = new System.Drawing.Size(677, 500);
            this.Controls.Add(this.listBox_ImageFiles2);
            this.Controls.Add(this.listBox_ImageFiles);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.barTopDockSite);
            this.Controls.Add(this.barBottomDockSite);
            this.Controls.Add(this.barLeftDockSite);
            this.Controls.Add(this.barRightDockSite);
            this.Controls.Add(this.dockSite4);
            this.Controls.Add(this.dockSite1);
            this.Controls.Add(this.dockSite2);
            this.Controls.Add(this.dockSite3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = (InvAcc.Properties.Resources.favicon);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "FrmEmp";
            this.netResize1.AutoSaveLayout = true;
            this.netResize1.ParentControl = this;
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "كرت الموظفـــــين";
            this.Load += new System.EventHandler(this.FrmEmp_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Frm_KeyPress);
            this.contextMenuStrip2.ResumeLayout(false);
            this.panelEx2.ResumeLayout(false);
            this.ribbonBar1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl_Employee)).EndInit();
            this.superTabControl_Employee.ResumeLayout(false);
            this.superTabControlPanel18.ResumeLayout(false);
            this.panelEx5.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_TicketsCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_TicketsBalance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_TicketsPrice)).EndInit();
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_VacationBalance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_VacationCount)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupPanel15.ResumeLayout(false);
            this.groupPanel15.PerformLayout();
            this.expandablePanel_attends.ResumeLayout(false);
            this.expandablePanel_Fri.ResumeLayout(false);
            this.itemPanel7.ResumeLayout(false);
            this.itemPanel7.PerformLayout();
            this.groupPanel11.ResumeLayout(false);
            this.groupPanel11.PerformLayout();
            this.groupPanel12.ResumeLayout(false);
            this.groupPanel12.PerformLayout();
            this.expandablePanel_Thurs.ResumeLayout(false);
            this.itemPanel6.ResumeLayout(false);
            this.itemPanel6.PerformLayout();
            this.groupPanel13.ResumeLayout(false);
            this.groupPanel13.PerformLayout();
            this.groupPanel14.ResumeLayout(false);
            this.groupPanel14.PerformLayout();
            this.expandablePanel_Wen.ResumeLayout(false);
            this.itemPanel5.ResumeLayout(false);
            this.itemPanel5.PerformLayout();
            this.groupPanel9.ResumeLayout(false);
            this.groupPanel9.PerformLayout();
            this.groupPanel10.ResumeLayout(false);
            this.groupPanel10.PerformLayout();
            this.expandablePanel_Tuse.ResumeLayout(false);
            this.itemPanel4.ResumeLayout(false);
            this.itemPanel4.PerformLayout();
            this.groupPanel7.ResumeLayout(false);
            this.groupPanel7.PerformLayout();
            this.groupPanel8.ResumeLayout(false);
            this.groupPanel8.PerformLayout();
            this.expandablePanel_Mon.ResumeLayout(false);
            this.itemPanel3.ResumeLayout(false);
            this.itemPanel3.PerformLayout();
            this.groupPanel5.ResumeLayout(false);
            this.groupPanel5.PerformLayout();
            this.groupPanel6.ResumeLayout(false);
            this.groupPanel6.PerformLayout();
            this.expandablePanel_Sun.ResumeLayout(false);
            this.itemPanel2.ResumeLayout(false);
            this.itemPanel2.PerformLayout();
            this.groupPanel3.ResumeLayout(false);
            this.groupPanel3.PerformLayout();
            this.groupPanel4.ResumeLayout(false);
            this.groupPanel4.PerformLayout();
            this.expandablePanel_Sat.ResumeLayout(false);
            this.itemPanel1.ResumeLayout(false);
            this.itemPanel1.PerformLayout();
            this.groupPanel2.ResumeLayout(false);
            this.groupPanel2.PerformLayout();
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            this.superTabControlPanel17.ResumeLayout(false);
            this.panelEx4.ResumeLayout(false);
            this.panelEx4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_HousingAllowance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_TransferAllowance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_NaturalWorkAllowance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_OtherAllowance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_MainSal)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_InsuranceMedicalCom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_SocialInsuranceComp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_SubsistenceAllowance)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_DayOfMonth)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_WorkHours)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_SocialInsurance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_InsuranceMedical)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_LateHours)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_DisOneDay)).EndInit();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_MandateDay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_AddHours)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_AddDay)).EndInit();
            this.superTabControlPanel15.ResumeLayout(false);
            this.panelEx1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_EnterPic)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_CompPaying)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_SalSubtract)).EndInit();
            this.superTabControlPanel1.ResumeLayout(false);
            this.panelEx8.ResumeLayout(false);
            this.panelEx8.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.superTabControlPanel19.ResumeLayout(false);
            this.panelEx6.ResumeLayout(false);
            this.panelEx6.PerformLayout();
            this.groupBox14.ResumeLayout(false);
            this.groupBox14.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bubbleBar5)).EndInit();
            this.ribbonBar_Tasks.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl_Main1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl_Main2)).EndInit();
            this.panelEx3.ResumeLayout(false);
            this.ribbonBar_DGV.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl_DGV)).EndInit();
            this.panel1.ResumeLayout(false);
            this.Icon = (InvAcc.Properties.Resources.favicon);
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).EndInit();
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.ResumeLayout(false);
        }
    }
}
