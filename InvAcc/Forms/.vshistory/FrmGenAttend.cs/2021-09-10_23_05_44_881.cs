using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.DotNetBar.SuperGrid;
using DevComponents.Editors;
using DevComponents.Editors.DateTimeAdv;
using InvAcc.GeneralM;
using InvAcc.Stock_Data;
using Microsoft.Office.Interop.Excel;
using SSSDateTime.Date;
using SSSLanguage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial  class FrmGenAttend : Form
    { void avs(int arln)

{ 
 button_GetFromPath.Text=   (arln == 0 ? "  ..  " : "  ..") ; ButImportFile.Text=   (arln == 0 ? "  حفــــظ  " : "  save") ; buttonX_ImportFile.Text=   (arln == 0 ? "  عرض البيانات  " : "  Display data") ; label6.Text=   (arln == 0 ? "  وقت الإنصراف الرسمي :  " : "  Official departure time:") ; label7.Text=   (arln == 0 ? "  وقت الحضــــور الرسمي:  " : "  Official attendance time:") ; label8.Text=   (arln == 0 ? "  رقم الموظف :  " : "  Employee number :") ; label9.Text=   (arln == 0 ? "  تاريخ الدوام :  " : "  Opening date:") ; label10.Text=   (arln == 0 ? "  وقت إنصراف الموظف :  " : "  Employee leave time:") ; label11.Text=   (arln == 0 ? "  وقت حضور الموظف :  " : "  Employee attendance time:") ; label15.Text=   (arln == 0 ? "  الإنصراف للفترة الثانيـة :  " : "  Withdrawal for the second period:") ; label21.Text=   (arln == 0 ? "  الحضـور للفترة الثانية :  " : "  Attendance for the second period:") ; label24.Text=   (arln == 0 ? "  الإنصراف للفترة الأولى :  " : "  Withdrawal for the first period:") ; label25.Text=   (arln == 0 ? "  الحضور للفترة الأولى :  " : "  Attendance for the first period:") ; radioButton_BreakDayOMR.Text=   (arln == 0 ? "  راحـــــــة  " : "  rest") ; radioButton_PeriodsOMR2.Text=   (arln == 0 ? "  فترتــــــان  " : "  two shifts") ; radioButton_PeriodsOMR1.Text=   (arln == 0 ? "  فتـــرة واحدة  " : "  one time") ; textBox_DateOMR.Text=   (arln == 0 ? "  --  " : "  --") ; textBox_Day.Text=   (arln == 0 ? "  --  " : "  --") ; bubbleButton_Ok.Text=   (arln == 0 ? "  حضـــــــــور  " : "  my presence") ; bubbleButton_Leave.Text=   (arln == 0 ? "  إنصـــــراف  " : "  severance") ; bubbleButton_RepAttend.Text=   (arln == 0 ? "  كشــــــف  " : "  revealed") ; label23.Text=   (arln == 0 ? "  موقع العمل ( المشروع ) :  " : "  Work location (project):") ; textBox_Pass.Text=   (arln == 0 ? "  +  " : "  +") ; label16.Text=   (arln == 0 ? "  ( دقيقة )  " : "  ( Accurate )") ; label17.Text=   (arln == 0 ? "  فتــرة التأخيـــــــــــــــــر :  " : "  Delay period:") ; label20.Text=   (arln == 0 ? "  وقت الوصــــــــــــــــــول :  " : "  Arrival time:") ; label22.Text=   (arln == 0 ? "  الموظـــــــــــــــــــــــــف :  " : "  The employee:") ; label36.Text=   (arln == 0 ? "  رقم الموظــف :  " : "  Employee Number:") ; groupPanel_Time2.Text=   (arln == 0 ? "  الفترة الثانيـــة  " : "  second period") ; label3.Text=   (arln == 0 ? "  الانصـــراف :  " : "  Disbursement:") ; label4.Text=   (arln == 0 ? "  حتــــــــــى :  " : "  until:") ; label5.Text=   (arln == 0 ? "  الحضــــــور :  " : "  Attendees:") ; groupPanel_Time1.Text=   (arln == 0 ? "  الفترة الأولــــي  " : "  first period") ; label19.Text=   (arln == 0 ? "  الانصـــراف :  " : "  Disbursement:") ; label18.Text=   (arln == 0 ? "  حتــــــــــى :  " : "  until:") ; label14.Text=   (arln == 0 ? "  الحضــــــور :  " : "  Attendees:") ; radioButton_BreakDay.Text=   (arln == 0 ? "  راحة  " : "  Comfort") ; radioButton_Periods2.Text=   (arln == 0 ? "  فترتان  " : "  two terms") ; radioButton_Periods1.Text=   (arln == 0 ? "  فتـــرة  " : "  period") ; ButSetAllDays.Text=   (arln == 0 ? "  تعميم لكل ايام الأسبوع  " : "  Circulation for all days of the week") ; ButOk.Text=   (arln == 0 ? "  تعميم حسب اليوم  " : "  Circulation by day") ; button_Relay.Text=   (arln == 0 ? "  معالجة النتائج  " : "  Processing results") ; button_OpenLate.Text=   (arln == 0 ? "  عرض البيانات  " : "  Display data") ; label32.Text=   (arln == 0 ? "  الـوظيفة :  " : "  Job:") ; label33.Text=   (arln == 0 ? "  القســم :  " : "  Section:") ; label34.Text=   (arln == 0 ? "  الإدارة :  " : "  Administration :") ; label31.Text=   (arln == 0 ? "  الشهــــر:  " : "  month:") ; vTime1.Text=   (arln == 0 ? "    :  " : "    :") ; vLeaveTime1.Text=   (arln == 0 ? "    :  " : "    :") ; vTime2.Text=   (arln == 0 ? "    :  " : "    :") ; vLeaveTime2.Text=   (arln == 0 ? "    :  " : "    :") ; button_Save.Text=   (arln == 0 ? "  حفــــظ  " : "  save") ; button_Open.Text=   (arln == 0 ? "  عرض البيانات  " : "  Display data") ; label29.Text=   (arln == 0 ? "  التاريـــخ :  " : "  date:") ; label30.Text=   (arln == 0 ? "  الموظف :  " : "  employee:") ; label28.Text=   (arln == 0 ? "  موقع العمل ( المشروع ) :  " : "  Work location (project):") ; label26.Text=   (arln == 0 ? "  اليــــوم :  " : "  Today:") ; label12.Text=   (arln == 0 ? "  الإنصــــراف  " : "  disbursement") ; label13.Text=   (arln == 0 ? "  الحضــــــــور  " : "  attendees") ; textBox_DayMenual.Text=   (arln == 0 ? "  --  " : "  --") ; label27.Text=   (arln == 0 ? "  التاريـــخ :  " : "  date:") ; ButSaveMenual.Text=   (arln == 0 ? "  حفــــــــــــظ  " : "  save") ; radioButton_PeriodsMenual2.Text=   (arln == 0 ? "  الفترة الثانية  " : "  second period") ; radioButton_PeriodsMenual1.Text=   (arln == 0 ? "  الفترة الأولى  " : "  The first period") ; itemPanel4.Text=   (arln == 0 ? "  itemPanel4  " : "  itemPanel4") ; itemPanel3.Text=   (arln == 0 ? "  itemPanel3  " : "  itemPanel3") ; itemPanel2.Text=   (arln == 0 ? "  itemPanel2  " : "  itemPanel2") ; itemPanel1.Text=   (arln == 0 ? "  itemPanel1  " : "  itemPanel1") ; explorerBar1.Text=   (arln == 0 ? "  explorerBar1  " : "  explorerBar1") ; explorerBarGroupItem_AttendTime.Text=   (arln == 0 ? "  التحضير والإنصراف  " : "  Preparation and departure") ; buttonItem_Attend.Text=   (arln == 0 ? "  تسجيل الحضور والإنصراف  " : "  Recording attendance and departure") ; buttonItem_AttendHand.Text=   (arln == 0 ? "  الحضور والإنصراف يدويـــاُ  " : "  Manual attendance and departure") ; buttonItem_ImportAttend.Text=   (arln == 0 ? "  استيراد بيانات الــدوام  " : "  Import time data") ; explorerBarGroupItem_AttendMissions.Text=   (arln == 0 ? "  المهام والعمليات  " : "  Tasks and Operations") ; buttonItem_GenAttend.Text=   (arln == 0 ? "  تعميم أوقات الدوام  " : "  General working hours") ; buttonItem_AttendEdit.Text=   (arln == 0 ? "  التعديل على الدوام  " : "  Always edit") ; buttonItem_AttendLate.Text=   (arln == 0 ? "  معالجة بيانات الدوام  " : "  Time data processing") ; explorerBarGroupItem2.Text=   (arln == 0 ? "  التقــــارير  " : "  Reports") ; buttonItem_RepAttend.Text=   (arln == 0 ? "  تقرير الحضور والإنصراف - الدوام  " : "  Attendance and leave report - working hours") ; buttonItem_RepPRojectFilter.Text=   (arln == 0 ? "  فرز الموظف حسب المشروع  " : "  Sort employee by project") ; explorerBarGroupItem_Exit.Text=   (arln == 0 ? "  النافــذة  " : "  window") ; buttonItem_Close.Text=   (arln == 0 ? "  خــــــروج  " : "  exit") ; mainmenu.Text=   (arln == 0 ? "  Main Menu  " : "  Main Menu") ; bChangeStyle.Text=   (arln == 0 ? "  الإستايل  " : "  Style") ; cmdStyleOffice2003.Text=   (arln == 0 ? "  Office 2003  " : "  Office 2003") ; cmdStyleVS2005.Text=   (arln == 0 ? "  VS 2005  " : "  VS 2005") ; cmdStyleOfficeXP.Text=   (arln == 0 ? "  Office XP  " : "  Office XP") ; cmdStyleOffice2007Blue.Text=   (arln == 0 ? "  Office 2007  " : "  Office 2007") ; TaskPane2.Text=   (arln == 0 ? "  Research  " : "  Research") ; buttonItem26.Text=   (arln == 0 ? "  · Automatically update this list from web  " : "  Automatically update this list from the web") ; buttonItem32.Text=   (arln == 0 ? "  · Connect to DevComponents Online  " : "  Connect to DevComponents Online") ; explorerBarGroupItem1.Text=   (arln == 0 ? "  Assistance  " : "  Assistance") ; buttonItem31.Text=   (arln == 0 ? "  · Get latest news about using this product  " : "  · Get ​​latest news about using this product") ; dockContainerItem1.Text=   (arln == 0 ? "  dockContainerItem1  " : "  dockContainerItem1") ; Text = "نظــام الـــــــدوام";this.Text=   (arln == 0 ? "  نظــام الـــــــدوام  " : "  working hours") ;}
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
        public class ColumnDictinaryLate
        {
            public string EmpNo;
            public ColumnDictinaryLate(string empNo)
            {
                EmpNo = empNo;
            }
        }
       // private IContainer components = null;
        private void netResize1_AfterControlResize(object sender, Softgroup.NetResize.AfterControlResizeEventArgs e)
        {
            if (e.Control.GetType() == typeof(System.Windows.Forms.Label))
            {
                System.Windows.Forms.Label c = (e.Control as System.Windows.Forms.Label); if ((c.BackColor != System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))))) && (c.BackColor != System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))))) && (c.BackColor != System.Drawing.Color.SteelBlue))
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
        public Softgroup.NetResize.NetResize netResize1;
        private RibbonBar ribbonBar1;
        private Panel panel1;
        protected PanelEx Main_Panel;
        private DockSite barLeftDockSite;
        private DockSite barTopDockSite;
        private DockSite barBottomDockSite;
        private DockSite barRightDockSite;
        private Bar barTaskPane;
        private PanelDockContainer panelDockContainer4;
        private DockContainerItem TaskPane1;
        private DockContainerItem TaskPane2;
        private MdiClient mdiClient1;
        private DockSite dockSite1;
        private DockSite dockSite2;
        private DockSite dockSite3;
        private Bar mainmenu;
        private ButtonItem bChangeStyle;
        private ButtonItem cmdStyleOffice2003;
        private ButtonItem cmdStyleVS2005;
        private ButtonItem cmdStyleOfficeXP;
        private ButtonItem cmdStyleOffice2007Blue;
        private DockSite dockSite4;
        private ImageList imageList1;
        public DotNetBarManager dotNetBarManager1;
        private ExplorerBar explorerBar1;
        private ButtonItem buttonItem26;
        private ButtonItem buttonItem32;
        private ExplorerBarGroupItem explorerBarGroupItem1;
        private ButtonItem buttonItem31;
        private DockContainerItem dockContainerItem1;
        private ExplorerBarGroupItem explorerBarGroupItem_AttendTime;
        private ButtonItem buttonItem_Attend;
        private ButtonItem buttonItem_AttendHand;
        private ButtonItem buttonItem_ImportAttend;
        private ExpandablePanel expandablePanel_Girds;
        private ExpandablePanel expandablePanel_Dept;
        private ItemPanel itemPanel1;
        private SuperGridControl dataGridViewX_Dept;
        private ExpandablePanel expandablePanel_Emp;
        private ItemPanel itemPanel4;
        private SuperGridControl dataGridViewX_Emp;
        private ExpandablePanel expandablePanel_Job;
        private ItemPanel itemPanel3;
        private SuperGridControl dataGridViewX_Job;
        private ExpandablePanel expandablePanel_Section;
        private ItemPanel itemPanel2;
        private SuperGridControl dataGridViewX_Section;
        private ExplorerBarGroupItem explorerBarGroupItem_AttendMissions;
        private ButtonItem buttonItem_GenAttend;
        private ButtonItem buttonItem_AttendEdit;
        private ButtonItem buttonItem_AttendLate;
        private RibbonBar ribbonBar_AttendMain;
        private PanelEx panelEx_GeneralAttend;
        private ButtonX ButSetAllDays;
        private ButtonX ButOk;
        private PanelEx panelEx_ImportAttend;
        private ButtonX ButImportFile;
        private ButtonX buttonX_ImportFile;
        private System.Windows.Forms.GroupBox groupBox2;
        private SwitchButton switchButton_FileSts;
        private System.Windows.Forms.TextBox textBox_SearchFilePath;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_Start;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox_End;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox_EmpNo;
        private System.Windows.Forms.TextBox textBox_Date;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox_TimeLeave1;
        private System.Windows.Forms.TextBox textBox_TimeT1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private DataGridView ExcelGridView;
        private System.Windows.Forms.GroupBox groupPanel_Day;
        private RadioButton radioButton_BreakDay;
        private RadioButton radioButton_Periods2;
        private RadioButton radioButton_Periods1;
        private ComboBoxEx comboBox_Days;
        private System.Windows.Forms.GroupBox groupPanel_Time1;
        private MaskedTextBox textBox_LeaveTime1;
        private System.Windows.Forms.Label label19;
        private MaskedTextBox textBox_TimeAllow1;
        private System.Windows.Forms.Label label18;
        private MaskedTextBox textBox_Time1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.GroupBox groupPanel_Time2;
        private MaskedTextBox textBox_LeaveTime2;
        private System.Windows.Forms.Label label3;
        private MaskedTextBox textBox_TimeAllow2;
        private System.Windows.Forms.Label label4;
        private MaskedTextBox textBox_Time2;
        private System.Windows.Forms.Label label5;
        private ButtonX button_GetFromPath;
        private PanelEx panelEx_Attend;
        private Panel panel3;
        private MaskedTextBox textBox_ComeTime;
        private DoubleInput textBox_LateTime;
        private System.Windows.Forms.TextBox textBox_ID;
        protected System.Windows.Forms.Label label16;
        protected System.Windows.Forms.Label label17;
        protected System.Windows.Forms.Label label_TimeTimer;
        protected System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label22;
        protected System.Windows.Forms.Label label36;
        private System.Windows.Forms.Label label23;
        private ComboBoxEx comboBox_PRoject;
        private ButtonX button_ADDPRoject;
        private ButtonX button_SrchPRoject;
        private ComboBoxEx comboBox_Emp;
        private ButtonX button_SrchEmp;
        private TextBoxX textBox_Pass;
        private TextBoxX textBox_Note;
        private ButtonX bubbleButton_Leave;
        private ButtonX bubbleButton_RepAttend;
        private ButtonX bubbleButton_Ok;
        protected System.Windows.Forms.Label textBox_DateOMR;
        protected System.Windows.Forms.Label textBox_Day;
        private Panel panel5;
        private MaskedTextBox textBox_LeaveTimeOMR2;
        private MaskedTextBox textBox_TimeOMR2;
        protected System.Windows.Forms.Label label15;
        protected System.Windows.Forms.Label label21;
        private Panel panel4;
        private MaskedTextBox textBox_LeaveTimeOMR1;
        private MaskedTextBox textBox_TimeOMR1;
        protected System.Windows.Forms.Label label24;
        protected System.Windows.Forms.Label label25;
        private Panel panel2;
        private RadioButton radioButton_BreakDayOMR;
        private RadioButton radioButton_PeriodsOMR2;
        private RadioButton radioButton_PeriodsOMR1;
        private Timer timer1;
        private Panel panel_PROJECTs;
        private PanelEx panelEx_MenualAttend;
        private ButtonX ButSaveMenual;
        private Panel panel6;
        private MaskedTextBox textBox_TimeLeaveMenual1;
        protected System.Windows.Forms.Label label12;
        private MaskedTextBox textBox_ComeTimeMenual;
        protected System.Windows.Forms.Label label13;
        protected System.Windows.Forms.Label textBox_DayMenual;
        protected System.Windows.Forms.Label label27;
        private MaskedTextBox textBox_DateMenual;
        private Panel panel7;
        private RadioButton radioButton_PeriodsMenual2;
        private RadioButton radioButton_PeriodsMenual1;
        protected System.Windows.Forms.Label label26;
        private ComboBoxEx comboBox_PRojectMenual;
        private ButtonX button_ADDPRojectMenual;
        private ButtonX button_SrchPRojectMenual;
        private System.Windows.Forms.Label label28;
        private PanelEx panelEx_EditAttend;
        private MaskedTextBox textBox_DateEdit;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label30;
        private ComboBoxEx comboBox_EmpNo;
        private ButtonX button_SEmp;
        private ButtonX button_Save;
        private ButtonX button_Open;
        private DataGridViewX dataGridViewX_RepDetils;
        private PanelEx panelEx_LateAttend;
        private MaskedTextBox textBox_DateLate;
        private System.Windows.Forms.Label label31;
        private SuperGridControl DataGridViewX_RepResult;
        private ComboBox comboBox_Job;
        private System.Windows.Forms.Label label32;
        private ComboBox comboBox_Section;
        private System.Windows.Forms.Label label33;
        private ComboBox comboBox_Dept;
        private System.Windows.Forms.Label label34;
        private ButtonX button_Relay;
        private ButtonX button_OpenLate;
        private ExplorerBarGroupItem explorerBarGroupItem2;
        private ButtonItem buttonItem_RepAttend;
        private ButtonItem buttonItem_RepPRojectFilter;
        private ExplorerBarGroupItem explorerBarGroupItem_Exit;
        private ButtonItem buttonItem_Close;
        private DataGridViewTextBoxColumn vDate;
        private DataGridViewTextBoxColumn vDay;
        private DataGridViewMaskedTextBoxAdvColumn vTime1;
        private DataGridViewMaskedTextBoxAdvColumn vLeaveTime1;
        private DataGridViewMaskedTextBoxAdvColumn vTime2;
        private DataGridViewMaskedTextBoxAdvColumn vLeaveTime2;
        private DataGridViewDoubleInputColumn vLateTime;
        private DataGridViewTextBoxColumn vNote;
        private DataGridViewTextBoxColumn vEmpID;
        private DataGridViewTextBoxColumn AttTime1;
        private DataGridViewTextBoxColumn AttTime2;
        private DataGridViewTextBoxColumn AttLeaveTime1;
        private DataGridViewTextBoxColumn AttLeaveTime2;
        private DataGridViewTextBoxColumn Pardon1;
        private DataGridViewTextBoxColumn Pardon2;
        private DataGridViewTextBoxColumn DateEdi;
        private DataGridViewTextBoxColumn UsrName;
        private Dictionary<string, ColumnDictinary> Dir_ButSearch = new Dictionary<string, ColumnDictinary>();
        private List<string> ColumnsFinger = new List<string>();
        private int LangArEn = 0;
        private FormState statex;
        public bool CanEdit = true;
        private HijriGreg.HijriGregDates n = new HijriGreg.HijriGregDates();
        public List<Control> controls;
        public Control codeControl = new Control();
        private List<string> pkeys = new List<string>();
        private T_Emp data_this;
        private T_Attend Data_this_Attend;
        private BindingList<T_Attend> Update_Attend;
        private T_AttendOperat Data_this_AttendOp;
        private string StartDate;
        private string StartTime;
        private bool AutoOut;
        private int OutPeriode;
        private string T;
        private bool ModifyActiveTime;
        private T_Emp data_thisOMR;
        private T_Attend Data_this_AttendOMR;
        private T_AttendOperat Data_this_AttendOpOMR;
        private T_AttendOperat Data_this_CheckOp;
        private T_AttendOperat Data_this_UpdateOpOMR;
        private T_Emp data_thisMenual;
        private T_Attend Data_this_AttendMenual;
        private BindingList<T_Attend> Update_AttendMenual;
        private T_AttendOperat Data_this_AttendOpMenual;
        private T_AttendOperat data_thisEdit;
        private Stock_DataDataContext dbInstance;
        private Rate_DataDataContext dbInstanceRate;
        private T_User permission = new T_User();
        private T_AttendOperat Data_this_UpdateOp;
        private string A1 = "00:00";
        private string B1 = "00:00";
        private string A2 = "00:00";
        private string B2 = "00:00";
        private string vDat;
        private Dictionary<string, ColumnDictinaryLate> FlagLte = new Dictionary<string, ColumnDictinaryLate>();
        private Dictionary<string, ColumnDictinaryLate> FlagSlp = new Dictionary<string, ColumnDictinaryLate>();
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
        public T_AttendOperat Datathis_AttendOp
        {
            get
            {
                return Data_this_AttendOp;
            }
            set
            {
                Data_this_AttendOp = value;
            }
        }
        public T_Emp DataThisOMR
        {
            get
            {
                return data_thisOMR;
            }
            set
            {
                data_thisOMR = value;
                if (!string.IsNullOrEmpty(data_thisOMR.Emp_ID))
                {
                    SetDataOMR(data_thisOMR);
                }
            }
        }
        public T_Attend Datathis_AttendOMR
        {
            get
            {
                return Data_this_AttendOMR;
            }
            set
            {
                Data_this_AttendOMR = value;
            }
        }
        public T_AttendOperat Datathis_AttendOpOMR
        {
            get
            {
                return Data_this_AttendOpOMR;
            }
            set
            {
                Data_this_AttendOpOMR = value;
            }
        }
        public T_AttendOperat Datathis_CheckOp
        {
            get
            {
                return Data_this_CheckOp;
            }
            set
            {
                Data_this_CheckOp = value;
            }
        }
        public T_AttendOperat Datathis_UpdateOpOMR
        {
            get
            {
                return Data_this_UpdateOpOMR;
            }
            set
            {
                Data_this_UpdateOpOMR = value;
            }
        }
        public T_Emp DataThisMenual
        {
            get
            {
                return data_thisMenual;
            }
            set
            {
                data_thisMenual = value;
                SetDataMenual(data_thisMenual);
            }
        }
        public T_Attend Datathis_AttendMenual
        {
            get
            {
                return Data_this_AttendMenual;
            }
            set
            {
                Data_this_AttendMenual = value;
            }
        }
        public BindingList<T_Attend> UpdateAttendMenual
        {
            get
            {
                return Update_AttendMenual;
            }
            set
            {
                Update_AttendMenual = value;
            }
        }
        public T_AttendOperat Datathis_AttendOpMenual => Data_this_AttendOpMenual;
        public T_AttendOperat DataThisEdit
        {
            get
            {
                return data_thisEdit;
            }
            set
            {
                data_thisEdit = value;
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
                    if (!VarGeneral.TString.ChkStatShow(value.Emp_GenStr, 1))
                    {
                        buttonItem_Attend.Enabled = false;
                    }
                    else
                    {
                        buttonItem_Attend.Enabled = true;
                    }
                    if (!VarGeneral.TString.ChkStatShow(value.Emp_GenStr, 2))
                    {
                        buttonItem_AttendHand.Enabled = false;
                    }
                    else
                    {
                        buttonItem_AttendHand.Enabled = true;
                    }
                    if (!VarGeneral.TString.ChkStatShow(value.Emp_GenStr, 3))
                    {
                        buttonItem_ImportAttend.Enabled = false;
                    }
                    else
                    {
                        buttonItem_ImportAttend.Enabled = true;
                    }
                    if (!VarGeneral.TString.ChkStatShow(value.Emp_GenStr, 4))
                    {
                        buttonItem_GenAttend.Enabled = false;
                    }
                    else
                    {
                        buttonItem_GenAttend.Enabled = true;
                    }
                    if (!VarGeneral.TString.ChkStatShow(value.Emp_GenStr, 5))
                    {
                        buttonItem_AttendEdit.Enabled = false;
                    }
                    else
                    {
                        buttonItem_AttendEdit.Enabled = true;
                    }
                    if (!VarGeneral.TString.ChkStatShow(value.Emp_GenStr, 6))
                    {
                        buttonItem_AttendLate.Enabled = false;
                    }
                    else
                    {
                        buttonItem_AttendLate.Enabled = true;
                    }
                    if (!VarGeneral.TString.ChkStatShow(value.Emp_RepStr, 21))
                    {
                        buttonItem_RepAttend.Enabled = false;
                    }
                    else
                    {
                        buttonItem_RepAttend.Enabled = true;
                    }
                    if (!VarGeneral.TString.ChkStatShow(value.Emp_RepStr, 22))
                    {
                        buttonItem_RepPRojectFilter.Enabled = false;
                    }
                    else
                    {
                        buttonItem_RepPRojectFilter.Enabled = true;
                    }
                }
            }
        }
        public bool SetReadOnlyOMR
        {
            set
            {
                if (value)
                {
                    State = FormState.Saved;
                }
                bubbleButton_RepAttend.Enabled = !value;
            }
        }
        public bool SetRead_Coming
        {
            set
            {
                if (value)
                {
                    State = FormState.Saved;
                }
                bubbleButton_Ok.Enabled = !value;
            }
        }
        public bool SetRead_Leaving
        {
            set
            {
                if (value)
                {
                    State = FormState.Saved;
                }
                bubbleButton_Leave.Enabled = !value;
            }
        }
        public T_AttendOperat Datathis_UpdateOp
        {
            get
            {
                return Data_this_UpdateOp;
            }
            set
            {
                Data_this_UpdateOp = value;
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
            }
        }
        public string VDate
        {
            get
            {
                return vDat;
            }
            set
            {
                vDat = value;
            }
        }
        public void RefreshPKeys()
        {
            PKeys.Clear();
            var qkeys = from item in db.T_Emps
                        orderby item.Emp_No
                        where item.EmpState == (bool?)true
                        select new
                        {
                            Code = item.Emp_No
                        };
            int count = 0;
            foreach (var item2 in qkeys)
            {
                count++;
                PKeys.Add(item2.Code);
            }
        }
        public FrmGenAttend()
        {
            InitializeComponent();this.Load += langloads;
            SetColumns();
        }
        private void SetColumns()
        {
            ColumnsFinger.Clear();
            ColumnsFinger.Add("A");
            ColumnsFinger.Add("B");
            ColumnsFinger.Add("C");
            ColumnsFinger.Add("D");
            ColumnsFinger.Add("E");
            ColumnsFinger.Add("F");
            ColumnsFinger.Add("G");
            ColumnsFinger.Add("H");
            ColumnsFinger.Add("I");
            ColumnsFinger.Add("J");
            ColumnsFinger.Add("K");
            ColumnsFinger.Add("L");
            ColumnsFinger.Add("M");
            ColumnsFinger.Add("N");
            ColumnsFinger.Add("O");
            ColumnsFinger.Add("P");
            ColumnsFinger.Add("Q");
            ColumnsFinger.Add("S");
            ColumnsFinger.Add("T");
            ColumnsFinger.Add("U");
            ColumnsFinger.Add("V");
            ColumnsFinger.Add("W");
            ColumnsFinger.Add("Y");
            ColumnsFinger.Add("Z");
            ColumnsFinger.Add("AA");
            ColumnsFinger.Add("AB");
            ColumnsFinger.Add("AC");
            ColumnsFinger.Add("AD");
            ColumnsFinger.Add("AE");
            ColumnsFinger.Add("AF");
            ColumnsFinger.Add("AG");
            ColumnsFinger.Add("AH");
            ColumnsFinger.Add("AI");
            ColumnsFinger.Add("AJ");
            ColumnsFinger.Add("AK");
            ColumnsFinger.Add("AL");
            ColumnsFinger.Add("AM");
            ColumnsFinger.Add("AN");
            ColumnsFinger.Add("AO");
            ColumnsFinger.Add("AP");
            ColumnsFinger.Add("AQ");
            ColumnsFinger.Add("AS");
            ColumnsFinger.Add("AT");
            ColumnsFinger.Add("AU");
            ColumnsFinger.Add("AV");
            ColumnsFinger.Add("AW");
            ColumnsFinger.Add("AY");
            ColumnsFinger.Add("AZ");
            ColumnsFinger.Add("BA");
            ColumnsFinger.Add("BB");
            ColumnsFinger.Add("BC");
            ColumnsFinger.Add("BD");
            ColumnsFinger.Add("BE");
            ColumnsFinger.Add("BF");
            ColumnsFinger.Add("BG");
            ColumnsFinger.Add("BH");
            ColumnsFinger.Add("BI");
            ColumnsFinger.Add("BJ");
            ColumnsFinger.Add("BK");
            ColumnsFinger.Add("BL");
            ColumnsFinger.Add("BM");
            ColumnsFinger.Add("BN");
            ColumnsFinger.Add("BO");
            ColumnsFinger.Add("BP");
            ColumnsFinger.Add("BQ");
            ColumnsFinger.Add("BS");
            ColumnsFinger.Add("BT");
            ColumnsFinger.Add("BU");
            ColumnsFinger.Add("BV");
            ColumnsFinger.Add("BW");
            ColumnsFinger.Add("BY");
            ColumnsFinger.Add("BZ");
            ColumnsFinger.Add("CA");
            ColumnsFinger.Add("CB");
            ColumnsFinger.Add("CC");
            ColumnsFinger.Add("CD");
            ColumnsFinger.Add("CE");
            ColumnsFinger.Add("CF");
            ColumnsFinger.Add("CG");
            ColumnsFinger.Add("CH");
            ColumnsFinger.Add("CI");
            ColumnsFinger.Add("CJ");
            ColumnsFinger.Add("CK");
            ColumnsFinger.Add("CL");
            ColumnsFinger.Add("CM");
            ColumnsFinger.Add("CN");
            ColumnsFinger.Add("CO");
            ColumnsFinger.Add("CP");
            ColumnsFinger.Add("CQ");
            ColumnsFinger.Add("CS");
            ColumnsFinger.Add("CT");
            ColumnsFinger.Add("CU");
            ColumnsFinger.Add("CV");
            ColumnsFinger.Add("CW");
            ColumnsFinger.Add("CY");
            ColumnsFinger.Add("CZ");
            ColumnsFinger.Add("DA");
            ColumnsFinger.Add("DB");
            ColumnsFinger.Add("DC");
            ColumnsFinger.Add("DE");
            ColumnsFinger.Add("DD");
            ColumnsFinger.Add("DF");
            ColumnsFinger.Add("DG");
            ColumnsFinger.Add("DH");
            ColumnsFinger.Add("DI");
            ColumnsFinger.Add("DJ");
            ColumnsFinger.Add("DK");
            ColumnsFinger.Add("DL");
            ColumnsFinger.Add("DM");
            ColumnsFinger.Add("DN");
            ColumnsFinger.Add("DO");
            ColumnsFinger.Add("DP");
            ColumnsFinger.Add("DQ");
            ColumnsFinger.Add("DS");
            ColumnsFinger.Add("DT");
            ColumnsFinger.Add("DU");
            ColumnsFinger.Add("DV");
            ColumnsFinger.Add("DW");
            ColumnsFinger.Add("DY");
            ColumnsFinger.Add("DZ");
            ColumnsFinger.Add("EA");
            ColumnsFinger.Add("EB");
            ColumnsFinger.Add("EC");
            ColumnsFinger.Add("ED");
            ColumnsFinger.Add("EE");
            ColumnsFinger.Add("EF");
            ColumnsFinger.Add("EG");
            ColumnsFinger.Add("EH");
            ColumnsFinger.Add("EI");
            ColumnsFinger.Add("EJ");
            ColumnsFinger.Add("EK");
            ColumnsFinger.Add("EL");
            ColumnsFinger.Add("EM");
            ColumnsFinger.Add("EN");
            ColumnsFinger.Add("EO");
            ColumnsFinger.Add("EP");
            ColumnsFinger.Add("EQ");
            ColumnsFinger.Add("ES");
            ColumnsFinger.Add("ET");
            ColumnsFinger.Add("EU");
            ColumnsFinger.Add("EV");
            ColumnsFinger.Add("EW");
            ColumnsFinger.Add("EY");
            ColumnsFinger.Add("EZ");
            ColumnsFinger.Add("FA");
            ColumnsFinger.Add("FB");
            ColumnsFinger.Add("FC");
            ColumnsFinger.Add("FD");
            ColumnsFinger.Add("FE");
            ColumnsFinger.Add("FF");
            ColumnsFinger.Add("FG");
            ColumnsFinger.Add("FH");
            ColumnsFinger.Add("FI");
            ColumnsFinger.Add("FJ");
            ColumnsFinger.Add("FK");
            ColumnsFinger.Add("FL");
            ColumnsFinger.Add("FM");
            ColumnsFinger.Add("FN");
            ColumnsFinger.Add("FO");
            ColumnsFinger.Add("FP");
            ColumnsFinger.Add("FQ");
            ColumnsFinger.Add("FS");
            ColumnsFinger.Add("FT");
            ColumnsFinger.Add("FU");
            ColumnsFinger.Add("FV");
            ColumnsFinger.Add("FW");
            ColumnsFinger.Add("FY");
            ColumnsFinger.Add("FZ");
            ColumnsFinger.Add("GA");
            ColumnsFinger.Add("GB");
            ColumnsFinger.Add("GC");
            ColumnsFinger.Add("GD");
            ColumnsFinger.Add("GE");
            ColumnsFinger.Add("GF");
            ColumnsFinger.Add("GG");
            ColumnsFinger.Add("GH");
            ColumnsFinger.Add("GI");
            ColumnsFinger.Add("GJ");
            ColumnsFinger.Add("GK");
            ColumnsFinger.Add("GL");
            ColumnsFinger.Add("GM");
            ColumnsFinger.Add("GN");
            ColumnsFinger.Add("GO");
            ColumnsFinger.Add("GP");
            ColumnsFinger.Add("GQ");
            ColumnsFinger.Add("GS");
            ColumnsFinger.Add("GT");
            ColumnsFinger.Add("GU");
            ColumnsFinger.Add("GV");
            ColumnsFinger.Add("GW");
            ColumnsFinger.Add("GY");
            ColumnsFinger.Add("GZ");
        }
        private void RibunButtons()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                barTaskPane.Text = "الملفــــات";
                explorerBarGroupItem_AttendTime.Text = "التحضير والإنصراف";
                buttonItem_Attend.Text = "تسجيل الحضور والإنصراف";
                buttonItem_AttendHand.Text = "الحضور والإنصراف يدويـــا\u064f";
                buttonItem_ImportAttend.Text = "استيراد بيانات الــدوام";
                explorerBarGroupItem_AttendMissions.Text = "المهام والعمليات";
                buttonItem_GenAttend.Text = "تعميم أوقات الدوام";
                buttonItem_AttendEdit.Text = "التعديل على الدوام";
                buttonItem_AttendLate.Text = "معالجة بيانات الدوام";
                explorerBarGroupItem_Exit.Text = "النافــذة";
                buttonItem_Close.Text = "خــــــروج";
                expandablePanel_Dept.Text = "الإدارة";
                expandablePanel_Section.Text = "القسم";
                expandablePanel_Job.Text = "الوظيفة";
                expandablePanel_Emp.Text = "الموظف";
                expandablePanel_Girds.TitleText = "على حســــب";
                radioButton_Periods1.Text = "فتـــرة";
                radioButton_Periods2.Text = "فترتان";
                radioButton_BreakDay.Text = "راحة";
                ButOk.Text = "تعميم حسب اليوم";
                ButSetAllDays.Text = "تعميم لكل ايام الأسبوع";
                bChangeStyle.Text = "الإستايل";
                cmdStyleOffice2003.Text = "أوفيس 2003";
                cmdStyleVS2005.Text = "فيجوال 2005";
                cmdStyleOfficeXP.Text = "أوفيس إكس بي";
                cmdStyleOffice2007Blue.Text = "أوفيس 2007";
                switchButton_FileSts.OffText = "ملف أكسيل";
                switchButton_FileSts.OnText = "ملف نصي";
                ButImportFile.Text = "حفــظ";
                buttonX_ImportFile.Tooltip = "عرض البيانات";
                textBox_Pass.WatermarkText = "كلمة السر";
                textBox_Note.WatermarkText = "الملاحظــــات";
                bubbleButton_Ok.Text = "حضـــــــــور";
                bubbleButton_Leave.Text = "إنصـــــراف";
                bubbleButton_RepAttend.Text = "كشــــــف";
                ButSaveMenual.Text = "حفــــــــــــظ";
                button_Open.Text = "عرض البيانات";
                button_Save.Text = "حفــــظ";
                button_OpenLate.Text = "عرض البيانات";
                button_Relay.Text = "معالجة النتائج";
                Text = "نظــــام الـــدوام";
            }
            else
            {
                barTaskPane.Text = "Files";
                explorerBarGroupItem_AttendTime.Text = "Attend or leave";
                buttonItem_Attend.Text = "Attend or leave register";
                buttonItem_AttendHand.Text = "Attend or leave manual";
                buttonItem_ImportAttend.Text = "Import Attend or leave";
                explorerBarGroupItem_AttendMissions.Text = "Operating";
                buttonItem_GenAttend.Text = "Attend or leave Generalization";
                buttonItem_AttendEdit.Text = "Attend or leave Edite";
                buttonItem_AttendLate.Text = "Attend Data Process";
                explorerBarGroupItem_Exit.Text = "Window";
                buttonItem_Close.Text = "Close";
                expandablePanel_Dept.Text = "Dept";
                expandablePanel_Section.Text = "Section";
                expandablePanel_Job.Text = "Job";
                expandablePanel_Emp.Text = "Employee";
                expandablePanel_Girds.TitleText = "By";
                radioButton_Periods1.Text = "Period";
                radioButton_Periods2.Text = "Two periods";
                radioButton_BreakDay.Text = "OFF";
                ButOk.Text = "By Days";
                ButSetAllDays.Text = "All Days in Weak";
                bChangeStyle.Text = "Style";
                cmdStyleOffice2003.Text = "Office 2003";
                cmdStyleVS2005.Text = "VS 2005";
                cmdStyleOfficeXP.Text = "Office XP";
                cmdStyleOffice2007Blue.Text = "Office 2007";
                switchButton_FileSts.OffText = "Excel File";
                switchButton_FileSts.OnText = "Text File";
                ButImportFile.Text = "Save";
                buttonX_ImportFile.Tooltip = "Show Data";
                textBox_Pass.WatermarkText = "Password";
                textBox_Note.WatermarkText = "Note";
                bubbleButton_Ok.Text = "Attend";
                bubbleButton_Leave.Text = "Leave";
                bubbleButton_RepAttend.Text = "Report";
                ButSaveMenual.Text = "Save";
                button_Open.Text = "Show Data";
                button_Save.Text = "Save";
                button_OpenLate.Text = "Show Data";
                button_Relay.Text = "Processing the results";
                Text = "Attend System";
            }
        }
        private void FrmGenAttend_Load(object sender, EventArgs e)
        {
            try
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmGenAttend));
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
                ChangeDotNetBarStyle(eDotNetBarStyle.Office2007);
                RibunButtons();
                SuperGridColumns();
                ADD_Controls();
                RefreshPKeys();
                Permmission = dbc.Get_PermissionID(VarGeneral.UserID);
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Load:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void buttonItem_GenAttend_Click(object sender, EventArgs e)
        {
            if (panelEx_GeneralAttend.Visible)
            {
                buttonItem_GenAttend.Checked = true;
                return;
            }
            Clear();
            FillCombo();
            radioButton_BreakDay.Checked = true;
            buttonItem_Attend.Checked = false;
            buttonItem_AttendHand.Checked = false;
            buttonItem_ImportAttend.Checked = false;
            buttonItem_GenAttend.Checked = true;
            buttonItem_AttendEdit.Checked = false;
            buttonItem_AttendLate.Checked = false;
            expandablePanel_Girds.ExpandButtonVisible = true;
            panelEx_GeneralAttend.Visible = true;
            panelEx_ImportAttend.Visible = false;
            panelEx_Attend.Visible = false;
            panelEx_MenualAttend.Visible = false;
            panelEx_EditAttend.Visible = false;
            panelEx_LateAttend.Visible = false;
        }
        private void buttonItem_Attend_Click(object sender, EventArgs e)
        {
            if (panelEx_Attend.Visible)
            {
                buttonItem_Attend.Checked = true;
                return;
            }
            VarGeneral.FlagState = "";
            ADD_Controls();
            FillComboOMR();
            Clear();
            int? calendr = VarGeneral.Settings_Sys.Calendr;
            if (calendr.Value == 0 && calendr.HasValue)
            {
                textBox_DateOMR.Text = VarGeneral.Gdate;
            }
            else
            {
                textBox_DateOMR.Text = VarGeneral.Hdate;
            }
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                textBox_Day.Text = n.GetDayH();
            }
            else
            {
                textBox_Day.Text = n.GetDayG();
            }
            VarGeneral.Day_No = n.GetDayNo("") + 1;
            textBox_Day.Tag = VarGeneral.Day_No;
            AutoOut = VarGeneral.Settings_Sys.AutoLeave.Value;
            OutPeriode = VarGeneral.Settings_Sys.EmpLeaveAfter.Value;
            if (VarGeneral.Settings_Sys.AttendanceManually.Value)
            {
                textBox_ComeTime.Enabled = true;
            }
            else
            {
                textBox_ComeTime.Enabled = false;
            }
            calendr = VarGeneral.Settings_Sys.Calendr;
            if (calendr.Value == 0 && calendr.HasValue)
            {
                try
                {
                    StartDate = VarGeneral.Gdate;
                }
                catch
                {
                    StartDate = n.FormatGreg(DateTime.Now.ToString(), "yyyy/MM/dd");
                }
                StartTime = DateTime.Now.ToString("HH:mm", DateTimeFormatInfo.InvariantInfo);
            }
            else
            {
                try
                {
                    StartDate = VarGeneral.Hdate;
                }
                catch
                {
                    StartDate = n.FormatHijri(DateTime.Now.ToString(), "yyyy/MM/dd");
                }
                StartTime = DateTime.Now.ToString("HH:mm", DateTimeFormatInfo.InvariantInfo);
            }
            EndTest();
            UpdateAttend_IN2();
            buttonItem_Attend.Checked = true;
            buttonItem_AttendHand.Checked = false;
            buttonItem_ImportAttend.Checked = false;
            buttonItem_GenAttend.Checked = false;
            buttonItem_AttendEdit.Checked = false;
            buttonItem_AttendLate.Checked = false;
            expandablePanel_Girds.ExpandButtonVisible = false;
            panelEx_GeneralAttend.Visible = false;
            panelEx_ImportAttend.Visible = false;
            panelEx_Attend.Visible = true;
            panelEx_MenualAttend.Visible = false;
            panelEx_EditAttend.Visible = false;
            panelEx_LateAttend.Visible = false;
        }
        private void buttonItem_AttendHand_Click(object sender, EventArgs e)
        {
            if (panelEx_MenualAttend.Visible)
            {
                buttonItem_AttendHand.Checked = true;
                return;
            }
            Clear();
            textBox_DateMenual_Leave(sender, e);
            FillComboMenual();
            buttonItem_Attend.Checked = false;
            buttonItem_AttendHand.Checked = true;
            buttonItem_ImportAttend.Checked = false;
            buttonItem_GenAttend.Checked = false;
            buttonItem_AttendEdit.Checked = false;
            buttonItem_AttendLate.Checked = false;
            expandablePanel_Girds.ExpandButtonVisible = true;
            panelEx_GeneralAttend.Visible = false;
            panelEx_ImportAttend.Visible = false;
            panelEx_Attend.Visible = false;
            panelEx_MenualAttend.Visible = true;
            panelEx_EditAttend.Visible = false;
            panelEx_LateAttend.Visible = false;
        }
        private void buttonItem_ImportAttend_Click(object sender, EventArgs e)
        {
            if (panelEx_ImportAttend.Visible)
            {
                buttonItem_ImportAttend.Checked = true;
                return;
            }
            Clear();
            switchButton_FileSts.Value = false;
            ButImportFile.Enabled = false;
            try
            {
                ExcelGridView.DataSource = null;
                ExcelGridView.Rows.Clear();
                ExcelGridView.Columns.Clear();
            }
            catch
            {
            }
            buttonItem_Attend.Checked = false;
            buttonItem_AttendHand.Checked = false;
            buttonItem_ImportAttend.Checked = true;
            buttonItem_GenAttend.Checked = false;
            buttonItem_AttendEdit.Checked = false;
            buttonItem_AttendLate.Checked = false;
            expandablePanel_Girds.ExpandButtonVisible = false;
            panelEx_GeneralAttend.Visible = false;
            panelEx_ImportAttend.Visible = true;
            panelEx_Attend.Visible = false;
            panelEx_MenualAttend.Visible = false;
            panelEx_EditAttend.Visible = false;
            panelEx_LateAttend.Visible = false;
        }
        private void buttonItem_AttendEdit_Click(object sender, EventArgs e)
        {
            if (panelEx_EditAttend.Visible)
            {
                buttonItem_AttendEdit.Checked = true;
                return;
            }
            Clear();
            if (VarGeneral.CheckDate(VDate))
            {
                textBox_DateEdit.Text = Convert.ToDateTime(VDate).ToString("yyyy/MM/dd");
            }
            else
            {
                textBox_DateEdit.Text = "";
            }
            FillComboEdit();
            SuperGridColumnsEdit();
            buttonItem_Attend.Checked = false;
            buttonItem_AttendHand.Checked = false;
            buttonItem_ImportAttend.Checked = false;
            buttonItem_GenAttend.Checked = false;
            buttonItem_AttendEdit.Checked = true;
            buttonItem_AttendLate.Checked = false;
            expandablePanel_Girds.ExpandButtonVisible = false;
            panelEx_GeneralAttend.Visible = false;
            panelEx_ImportAttend.Visible = false;
            panelEx_Attend.Visible = false;
            panelEx_MenualAttend.Visible = false;
            panelEx_EditAttend.Visible = true;
            panelEx_LateAttend.Visible = false;
        }
        private void buttonItem_AttendLate_Click(object sender, EventArgs e)
        {
            if (panelEx_LateAttend.Visible)
            {
                buttonItem_AttendLate.Checked = true;
                return;
            }
            Clear();
            VarGeneral.FlagDis = true;
            int? calendr = VarGeneral.Settings_Sys.Calendr;
            if (calendr.Value == 0 && calendr.HasValue)
            {
                textBox_DateLate.Text = n.FormatGreg(VarGeneral.Gdate, "yyyy/MM");
            }
            else
            {
                textBox_DateLate.Text = n.FormatHijri(VarGeneral.Hdate, "yyyy/MM");
            }
            FillComboLate();
            SettingGridLate();
            buttonItem_Attend.Checked = false;
            buttonItem_AttendHand.Checked = false;
            buttonItem_ImportAttend.Checked = false;
            buttonItem_GenAttend.Checked = false;
            buttonItem_AttendEdit.Checked = false;
            buttonItem_AttendLate.Checked = true;
            expandablePanel_Girds.ExpandButtonVisible = false;
            panelEx_GeneralAttend.Visible = false;
            panelEx_ImportAttend.Visible = false;
            panelEx_Attend.Visible = false;
            panelEx_MenualAttend.Visible = false;
            panelEx_EditAttend.Visible = false;
            panelEx_LateAttend.Visible = true;
        }
        private void buttonItem_Close_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void FrmGenAttend_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                SendKeys.Send("{Tab}");
            }
        }
        private void FrmGenAttend_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
        private void FrmGenAttend_FormClosed(object sender, FormClosedEventArgs e)
        {
            EndTest();
            UpdateAttend_IN2();
        }
        private void SuperGridColumns()
        {
            dataGridViewX_Emp.PrimaryGrid.Columns[1].HeaderText = ((LangArEn == 0) ? "الموظف" : "Employee");
            dataGridViewX_Dept.PrimaryGrid.Columns[1].HeaderText = ((LangArEn == 0) ? "الادارة" : "Management");
            dataGridViewX_Job.PrimaryGrid.Columns[1].HeaderText = ((LangArEn == 0) ? "الوظيفة" : "Job");
            dataGridViewX_Section.PrimaryGrid.Columns[1].HeaderText = ((LangArEn == 0) ? "القسم" : "Section");
            dataGridViewX_Emp.PrimaryGrid.DefaultVisualStyles.FilterColumnHeaderStyles.Default.Background.Color1 = SystemColors.ActiveCaption;
            dataGridViewX_Dept.PrimaryGrid.DefaultVisualStyles.FilterColumnHeaderStyles.Default.Background.Color1 = SystemColors.ActiveCaption;
            dataGridViewX_Job.PrimaryGrid.DefaultVisualStyles.FilterColumnHeaderStyles.Default.Background.Color1 = SystemColors.ActiveCaption;
            dataGridViewX_Section.PrimaryGrid.DefaultVisualStyles.FilterColumnHeaderStyles.Default.Background.Color1 = SystemColors.ActiveCaption;
            dataGridViewX_Emp.PrimaryGrid.UseAlternateColumnStyle = false;
            dataGridViewX_Dept.PrimaryGrid.UseAlternateColumnStyle = false;
            dataGridViewX_Job.PrimaryGrid.UseAlternateColumnStyle = false;
            dataGridViewX_Section.PrimaryGrid.UseAlternateColumnStyle = false;
        }
        private void ADD_Controls()
        {
            try
            {
                controls = new List<Control>();
                controls.Add(textBox_LeaveTime1);
                controls.Add(textBox_LeaveTime2);
                controls.Add(textBox_Time1);
                controls.Add(textBox_Time2);
                controls.Add(textBox_TimeAllow1);
                controls.Add(textBox_TimeAllow2);
                controls.Add(radioButton_BreakDay);
                controls.Add(radioButton_Periods1);
                controls.Add(radioButton_Periods2);
                controls.Add(comboBox_Days);
                controls.Add(ButSetAllDays);
                controls.Add(textBox_Date);
                controls.Add(textBox_EmpNo);
                controls.Add(textBox_SearchFilePath);
                controls.Add(textBox_TimeT1);
                controls.Add(textBox_TimeLeave1);
                controls.Add(ButImportFile);
                controls.Add(switchButton_FileSts);
                controls.Add(buttonX_ImportFile);
                controls.Add(ExcelGridView);
                controls.Add(textBox_ComeTime);
                controls.Add(textBox_Pass);
                controls.Add(textBox_ID);
                controls.Add(textBox_LateTime);
                controls.Add(textBox_LeaveTimeOMR1);
                controls.Add(textBox_LeaveTimeOMR2);
                controls.Add(textBox_Note);
                controls.Add(textBox_Pass);
                controls.Add(textBox_TimeOMR1);
                controls.Add(textBox_TimeOMR2);
                controls.Add(radioButton_BreakDayOMR);
                controls.Add(radioButton_PeriodsOMR1);
                controls.Add(radioButton_PeriodsOMR2);
                controls.Add(comboBox_Emp);
                controls.Add(comboBox_PRoject);
                controls.Add(textBox_DateMenual);
                controls.Add(textBox_DayMenual);
                controls.Add(comboBox_PRojectMenual);
                controls.Add(radioButton_PeriodsMenual1);
                controls.Add(radioButton_PeriodsMenual2);
                controls.Add(textBox_ComeTimeMenual);
                controls.Add(textBox_TimeLeaveMenual1);
                controls.Add(comboBox_PRojectMenual);
                controls.Add(textBox_DateEdit);
                controls.Add(comboBox_EmpNo);
                controls.Add(button_Open);
                controls.Add(dataGridViewX_RepDetils);
            }
            catch (SqlException)
            {
            }
        }
        public void Clear()
        {
            data_this = new T_Emp();
            data_thisOMR = new T_Emp();
            Data_this_Attend = new T_Attend();
            Update_Attend = new BindingList<T_Attend>();
            Data_this_AttendOp = new T_AttendOperat();
            Data_this_AttendOMR = new T_Attend();
            Data_this_AttendOpOMR = new T_AttendOperat();
            Data_this_CheckOp = new T_AttendOperat();
            Data_this_UpdateOpOMR = new T_AttendOperat();
            Data_this_UpdateOp = new T_AttendOperat();
            data_thisMenual = new T_Emp();
            Data_this_AttendMenual = new T_Attend();
            Update_AttendMenual = new BindingList<T_Attend>();
            data_thisEdit = new T_AttendOperat();
            int? calendr;
            for (int i = 0; i < controls.Count; i++)
            {
                try
                {
                    if (controls[i].GetType() == typeof(DateTimePicker))
                    {
                        calendr = VarGeneral.Settings_Sys.Calendr;
                        if (calendr.Value == 0 && calendr.HasValue)
                        {
                            (controls[i] as DateTimePicker).Text = VarGeneral.Gdate;
                        }
                        else
                        {
                            (controls[i] as DateTimePicker).Text = VarGeneral.Hdate;
                        }
                    }
                    else if (controls[i].GetType() == typeof(DateTimeInput))
                    {
                        (controls[i] as DateTimeInput).Value = DateTime.Now;
                    }
                    else if (controls[i].GetType() == typeof(ComboBox))
                    {
                        try
                        {
                            comboBox_Emp.SelectedValueChanged -= comboBox_Emp_SelectedValueChanged;
                            (controls[i] as ComboBox).SelectedValue = -1;
                            comboBox_Emp.SelectedValueChanged += comboBox_Emp_SelectedValueChanged;
                        }
                        catch
                        {
                            (controls[i] as ComboBox).SelectedIndex = -1;
                        }
                    }
                    else if (controls[i].GetType() == typeof(System.Windows.Forms.CheckBox))
                    {
                        (controls[i] as System.Windows.Forms.CheckBox).Checked = false;
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
                        else if (controls[i].GetType() == typeof(System.Windows.Forms.TextBox) || controls[i].GetType() == typeof(TextBoxX) || controls[i].GetType() == typeof(MaskedTextBox))
                        {
                            controls[i].Text = "";
                        }
                        else if (controls[i].GetType() == typeof(System.Windows.Forms.CheckBox))
                        {
                            (controls[i] as System.Windows.Forms.CheckBox).Checked = false;
                        }
                        else if (controls[i].GetType() == typeof(RadioButton))
                        {
                            (controls[i] as RadioButton).Checked = false;
                        }
                        else if (controls[i].GetType() == typeof(ComboBoxEx))
                        {
                            try
                            {
                                comboBox_Emp.SelectedValueChanged -= comboBox_Emp_SelectedValueChanged;
                                (controls[i] as ComboBoxEx).SelectedIndex = -1;
                                comboBox_Emp.SelectedValueChanged += comboBox_Emp_SelectedValueChanged;
                            }
                            catch
                            {
                            }
                        }
                        continue;
                    }
                }
                catch
                {
                }
            }
            SetReadOnlyOMR = true;
            SetRead_Coming = true;
            SetRead_Leaving = true;
            radioButton_PeriodsMenual1.Checked = true;
            calendr = VarGeneral.Settings_Sys.Calendr;
            if (calendr.Value == 0 && calendr.HasValue)
            {
                textBox_DateMenual.Text = VarGeneral.Gdate;
            }
            else
            {
                textBox_DateMenual.Text = VarGeneral.Hdate;
            }
            FillGrid();
        }
        private void FillGrid()
        {
            dataGridViewX_Dept.PrimaryGrid.Rows.Clear();
            dataGridViewX_Emp.PrimaryGrid.Rows.Clear();
            dataGridViewX_Job.PrimaryGrid.Rows.Clear();
            dataGridViewX_Section.PrimaryGrid.Rows.Clear();
            GridRow row = new GridRow();
            List<T_Emp> listEmp = db.FillEmps_2("").ToList();
            for (int i = 0; i < listEmp.Count; i++)
            {
                row = new GridRow();
                row.Cells.Add(new GridCell(""));
                row.Cells.Add(new GridCell(""));
                row.Cells.Add(new GridCell(""));
                dataGridViewX_Emp.PrimaryGrid.Rows.Add(row);
                dataGridViewX_Emp.PrimaryGrid.GetCell(i, 1).Value = ((LangArEn == 0) ? listEmp[i].NameA.ToString() : listEmp[i].NameE.ToString());
                dataGridViewX_Emp.PrimaryGrid.GetCell(i, 2).Value = listEmp[i].Emp_ID.ToString();
            }
            List<T_Dept> listDept = db.FillDept_2("").ToList();
            for (int i = 0; i < listDept.Count; i++)
            {
                row = new GridRow();
                row.Cells.Add(new GridCell(""));
                row.Cells.Add(new GridCell(""));
                row.Cells.Add(new GridCell(""));
                dataGridViewX_Dept.PrimaryGrid.Rows.Add(row);
                dataGridViewX_Dept.PrimaryGrid.GetCell(i, 1).Value = ((LangArEn == 0) ? listDept[i].NameA.ToString() : listDept[i].NameE.ToString());
                dataGridViewX_Dept.PrimaryGrid.GetCell(i, 2).Value = listDept[i].Dept_No.ToString();
            }
            List<T_Section> listSection = db.FillSection_2("").ToList();
            for (int i = 0; i < listSection.Count; i++)
            {
                row = new GridRow();
                row.Cells.Add(new GridCell(""));
                row.Cells.Add(new GridCell(""));
                row.Cells.Add(new GridCell(""));
                dataGridViewX_Section.PrimaryGrid.Rows.Add(row);
                dataGridViewX_Section.PrimaryGrid.GetCell(i, 1).Value = ((LangArEn == 0) ? listSection[i].NameA.ToString() : listSection[i].NameE.ToString());
                dataGridViewX_Section.PrimaryGrid.GetCell(i, 2).Value = listSection[i].Section_No.ToString();
            }
            List<T_Job> listJob = db.FillJob_2("").ToList();
            for (int i = 0; i < listJob.Count; i++)
            {
                row = new GridRow();
                row.Cells.Add(new GridCell(""));
                row.Cells.Add(new GridCell(""));
                row.Cells.Add(new GridCell(""));
                dataGridViewX_Job.PrimaryGrid.Rows.Add(row);
                dataGridViewX_Job.PrimaryGrid.GetCell(i, 1).Value = ((LangArEn == 0) ? listJob[i].NameA.ToString() : listJob[i].NameE.ToString());
                dataGridViewX_Job.PrimaryGrid.GetCell(i, 2).Value = listJob[i].Job_No.ToString();
            }
        }
        private string[] getDeptNo()
        {
            string[] listSalse = new string[dataGridViewX_Dept.PrimaryGrid.Rows.Count];
            for (int i = 0; i < dataGridViewX_Dept.PrimaryGrid.Rows.Count; i++)
            {
                if (dataGridViewX_Dept.PrimaryGrid.GetCell(i, 0).Value.ToString() == "True")
                {
                    listSalse[i] = dataGridViewX_Dept.PrimaryGrid.GetCell(i, 2).Value.ToString();
                }
            }
            return listSalse;
        }
        private string[] getEmpNo()
        {
            string[] listSalse = new string[dataGridViewX_Emp.PrimaryGrid.Rows.Count];
            for (int i = 0; i < dataGridViewX_Emp.PrimaryGrid.Rows.Count; i++)
            {
                if (dataGridViewX_Emp.PrimaryGrid.GetCell(i, 0).Value.ToString() == "True")
                {
                    listSalse[i] = dataGridViewX_Emp.PrimaryGrid.GetCell(i, 2).Value.ToString();
                }
            }
            return listSalse;
        }
        private string[] getJobNo()
        {
            string[] listSalse = new string[dataGridViewX_Job.PrimaryGrid.Rows.Count];
            for (int i = 0; i < dataGridViewX_Job.PrimaryGrid.Rows.Count; i++)
            {
                if (dataGridViewX_Job.PrimaryGrid.GetCell(i, 0).Value.ToString() == "True")
                {
                    listSalse[i] = dataGridViewX_Job.PrimaryGrid.GetCell(i, 2).Value.ToString();
                }
            }
            return listSalse;
        }
        private string[] getSectionNo()
        {
            string[] listSalse = new string[dataGridViewX_Section.PrimaryGrid.Rows.Count];
            for (int i = 0; i < dataGridViewX_Section.PrimaryGrid.Rows.Count; i++)
            {
                if (dataGridViewX_Section.PrimaryGrid.GetCell(i, 0).Value.ToString() == "True")
                {
                    listSalse[i] = dataGridViewX_Section.PrimaryGrid.GetCell(i, 2).Value.ToString();
                }
            }
            return listSalse;
        }
        private void expandablePanel_Girds_ExpandedChanging(object sender, ExpandedChangeEventArgs e)
        {
            if (!expandablePanel_Girds.ExpandButtonVisible)
            {
                e.Cancel = true;
                return;
            }
            expandablePanel_Emp.Expanded = false;
            expandablePanel_Dept.Expanded = false;
            expandablePanel_Job.Expanded = false;
            expandablePanel_Section.Expanded = false;
        }
        private void expandablePanel_Girds_ExpandedChanged(object sender, ExpandedChangeEventArgs e)
        {
            expandablePanel_Dept.Expanded = false;
            expandablePanel_Emp.Expanded = false;
            expandablePanel_Job.Expanded = false;
            expandablePanel_Section.Expanded = false;
        }
        private void expandablePanel_Dept_ExpandedChanging(object sender, ExpandedChangeEventArgs e)
        {
            if (!expandablePanel_Girds.ExpandButtonVisible)
            {
                e.Cancel = true;
            }
        }
        private void expandablePanel_Emp_ExpandedChanging(object sender, ExpandedChangeEventArgs e)
        {
            if (!expandablePanel_Girds.ExpandButtonVisible)
            {
                e.Cancel = true;
            }
        }
        private void expandablePanel_Job_ExpandedChanging(object sender, ExpandedChangeEventArgs e)
        {
            if (!expandablePanel_Girds.ExpandButtonVisible)
            {
                e.Cancel = true;
            }
        }
        private void expandablePanel_Section_ExpandedChanging(object sender, ExpandedChangeEventArgs e)
        {
            if (!expandablePanel_Girds.ExpandButtonVisible)
            {
                e.Cancel = true;
            }
        }
        private void cmdStyleOffice2003_Click(object sender, EventArgs e)
        {
            ChangeDotNetBarStyle(eDotNetBarStyle.Office2003);
        }
        private void ChangeDotNetBarStyle(eDotNetBarStyle style)
        {
            cmdStyleOffice2007Blue.Checked = style == eDotNetBarStyle.Office2007;
            cmdStyleOffice2003.Checked = style == eDotNetBarStyle.Office2003;
            cmdStyleOfficeXP.Checked = style == eDotNetBarStyle.OfficeXP;
            cmdStyleVS2005.Checked = style == eDotNetBarStyle.VS2005;
            explorerBar1.ColorScheme = new ColorScheme(style);
            dotNetBarManager1.Style = style;
        }
        private void cmdStyleVS2005_Click(object sender, EventArgs e)
        {
            ChangeDotNetBarStyle(eDotNetBarStyle.VS2005);
        }
        private void cmdStyleOfficeXP_Click(object sender, EventArgs e)
        {
            ChangeDotNetBarStyle(eDotNetBarStyle.OfficeXP);
        }
        private void cmdStyleOffice2007Blue_Click(object sender, EventArgs e)
        {
            ChangeDotNetBarStyle(eDotNetBarStyle.Office2007);
        }
        public void FillCombo()
        {
            List<T_DayOfWeek> listDayOfWeek = new List<T_DayOfWeek>(db.T_DayOfWeeks.OrderBy((T_DayOfWeek item) => item.Day_No).ToList());
            comboBox_Days.DataSource = listDayOfWeek;
            comboBox_Days.DisplayMember = ((LangArEn == 0) ? "NameA" : "NameE");
            comboBox_Days.ValueMember = "Day_No";
            VarGeneral.Day_No = n.GetDayNo("") + 1;
            comboBox_Days.SelectedValue = VarGeneral.Day_No;
        }
        private void textBox_Time1_Leave(object sender, EventArgs e)
        {
            if (VarGeneral.CheckTime(textBox_Time1.Text))
            {
                textBox_Time1.Text = TimeSpan.Parse(textBox_Time1.Text).ToString();
            }
            else
            {
                textBox_Time1.Text = "";
            }
        }
        private void textBox_Time2_Leave(object sender, EventArgs e)
        {
            if (VarGeneral.CheckTime(textBox_Time2.Text))
            {
                textBox_Time2.Text = TimeSpan.Parse(textBox_Time2.Text).ToString();
            }
            else
            {
                textBox_Time2.Text = "";
            }
        }
        private void textBox_TimeAllow1_Leave(object sender, EventArgs e)
        {
            if (VarGeneral.CheckTime(textBox_TimeAllow1.Text))
            {
                textBox_TimeAllow1.Text = TimeSpan.Parse(textBox_TimeAllow1.Text).ToString();
            }
            else
            {
                textBox_TimeAllow1.Text = "";
            }
        }
        private void textBox_TimeAllow2_Leave(object sender, EventArgs e)
        {
            if (VarGeneral.CheckTime(textBox_TimeAllow2.Text))
            {
                textBox_TimeAllow2.Text = TimeSpan.Parse(textBox_TimeAllow2.Text).ToString();
            }
            else
            {
                textBox_TimeAllow2.Text = "";
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
                textBox_LeaveTime1.Text = "";
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
                textBox_LeaveTime2.Text = "";
            }
        }
        private void Save(bool value)
        {
            string tmpStr = "";
            string QStr = "";
            string[] GetSql = getDeptNo();
            for (int num2 = 0; num2 < GetSql.Length; num2++)
            {
                if (!string.IsNullOrEmpty(GetSql[num2]))
                {
                    tmpStr = ((!string.IsNullOrEmpty(tmpStr)) ? (tmpStr + " OR ") : (tmpStr + " AND ( "));
                    tmpStr = tmpStr + " ( Dept = " + GetSql[num2].Trim() + " ) ";
                }
            }
            QStr += ((tmpStr != "") ? (tmpStr + " )") : "");
            tmpStr = "";
            GetSql = getEmpNo();
            for (int num2 = 0; num2 < GetSql.Length; num2++)
            {
                if (!string.IsNullOrEmpty(GetSql[num2]))
                {
                    tmpStr = ((!string.IsNullOrEmpty(tmpStr)) ? (tmpStr + " OR ") : (tmpStr + " AND ( "));
                    tmpStr = tmpStr + " ( Emp_ID = '" + GetSql[num2].Trim() + "' ) ";
                }
            }
            QStr += ((tmpStr != "") ? (tmpStr + " )") : "");
            tmpStr = "";
            GetSql = getJobNo();
            for (int num2 = 0; num2 < GetSql.Length; num2++)
            {
                if (!string.IsNullOrEmpty(GetSql[num2]))
                {
                    tmpStr = ((!string.IsNullOrEmpty(tmpStr)) ? (tmpStr + " OR ") : (tmpStr + " AND ( "));
                    tmpStr = tmpStr + " ( Job = " + GetSql[num2].Trim() + " ) ";
                }
            }
            QStr += ((tmpStr != "") ? (tmpStr + " )") : "");
            tmpStr = "";
            GetSql = getSectionNo();
            for (int num2 = 0; num2 < GetSql.Length; num2++)
            {
                if (!string.IsNullOrEmpty(GetSql[num2]))
                {
                    tmpStr = ((!string.IsNullOrEmpty(tmpStr)) ? (tmpStr + " OR ") : (tmpStr + " AND ( "));
                    tmpStr = tmpStr + " ( Section = " + GetSql[num2].Trim() + " ) ";
                }
            }
            QStr += ((tmpStr != "") ? (tmpStr + " )") : "");
            tmpStr = "";
            for (int i = 0; i < pkeys.Count; i++)
            {
                string query = "SELECT * FROM [dbo].[T_Emp] as [t0] WHERE EmpState = " + 1 + " AND Emp_No = " + pkeys[i] + QStr + " ORDER BY [Emp_No]";
                try
                {
                    T_Emp newData = db.ExecuteQuery<T_Emp>(query, new object[0]).First();
                    if (newData == null && !(newData.Emp_No != ""))
                    {
                        continue;
                    }
                    DataThis = newData;
                    if (Update_Attend.Count <= 0)
                    {
                        continue;
                    }
                    if (value)
                    {
                        Save_DataAttend(int.Parse(comboBox_Days.SelectedValue.ToString()));
                        continue;
                    }
                    for (int iCnt = 1; iCnt <= 7; iCnt++)
                    {
                        Save_DataAttend(iCnt);
                    }
                }
                catch
                {
                }
            }
        }
        public void SetData(T_Emp value)
        {
            Update_Attend = new BindingList<T_Attend>(value.T_Attends);
        }
        private T_Emp GetData()
        {
            try
            {
                data_this.Emp_No = data_this.Emp_No;
            }
            catch
            {
            }
            return data_this;
        }
        private void Save_DataAttend(int Dayno)
        {
            Data_this_Attend = Update_Attend[Dayno - 1];
            Datathis_Attend.EmpID = data_this.Emp_ID;
            Datathis_Attend.Day_No = Dayno;
            try
            {
                Datathis_Attend.Time1 = TimeSpan.Parse(textBox_Time1.Text).ToString();
            }
            catch
            {
                Datathis_Attend.Time1 = "__:__";
            }
            try
            {
                Datathis_Attend.Time2 = TimeSpan.Parse(textBox_Time2.Text).ToString();
            }
            catch
            {
                Datathis_Attend.Time2 = "__:__";
            }
            try
            {
                Datathis_Attend.TimeAllow1 = TimeSpan.Parse(textBox_TimeAllow1.Text).ToString();
            }
            catch
            {
                Datathis_Attend.TimeAllow1 = "__:__";
            }
            try
            {
                Datathis_Attend.TimeAlow2 = TimeSpan.Parse(textBox_TimeAllow2.Text).ToString();
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
                Datathis_Attend.LeaveTime2 = TimeSpan.Parse(textBox_LeaveTime2.Text).ToString();
            }
            catch
            {
                Datathis_Attend.LeaveTime2 = "__:__";
            }
            if (radioButton_Periods1.Checked)
            {
                Datathis_Attend.Periods = 1;
            }
            else if (radioButton_Periods2.Checked)
            {
                Datathis_Attend.Periods = 2;
            }
            else
            {
                Datathis_Attend.Periods = 0;
            }
            db.Log = VarGeneral.DebugLog;
            db.SubmitChanges(ConflictMode.ContinueOnConflict);
        }
        private void textBox_Time1_Click(object sender, EventArgs e)
        {
            textBox_Time1.SelectAll();
        }
        private void textBox_TimeAllow1_Click(object sender, EventArgs e)
        {
            textBox_TimeAllow1.SelectAll();
        }
        private void textBox_LeaveTime1_Click(object sender, EventArgs e)
        {
            textBox_LeaveTime1.SelectAll();
        }
        private void textBox_Time2_Click(object sender, EventArgs e)
        {
            textBox_Time2.SelectAll();
        }
        private void textBox_TimeAllow2_Click(object sender, EventArgs e)
        {
            textBox_TimeAllow2.SelectAll();
        }
        private void textBox_LeaveTime2_Click(object sender, EventArgs e)
        {
            textBox_LeaveTime2.SelectAll();
        }
        private void textBox_Time1_TextChanged(object sender, EventArgs e)
        {
            textBox_TimeAllow1.Text = textBox_Time1.Text;
        }
        private void textBox_Time2_TextChanged(object sender, EventArgs e)
        {
            textBox_TimeAllow2.Text = textBox_Time2.Text;
        }
        private void ButSetAllDays_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox_Days.SelectedIndex != -1 && MessageBox.Show((LangArEn == 0) ? "سيتم تعميم اوقات الدوام التالية على جميع ايام الأسبوع ..هل تريد المتابعة ؟ ?" : "Are you sure you want to repeat this consistently for a whole week?", VarGeneral.ProdectNam, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.No)
                {
                    Save(value: false);
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("button_SetAllDays_Click:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void ButOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox_Days.SelectedIndex != -1 && MessageBox.Show((LangArEn == 0) ? ("سوف يتم تعميم الدوام للموظفين ليوم " + comboBox_Days.Text.Trim() + " هل تريد المتابعة ?") : ("Are you sure you want circulating time on day " + comboBox_Days.Text.Trim() + " by specific items"), VarGeneral.ProdectNam, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.No)
                {
                    Save(value: true);
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Button_Ok_Click:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void radioButton_SatPeriods1_CheckedChanged(object sender, EventArgs e)
        {
            textBox_Time1.Enabled = true;
            textBox_Time2.Enabled = false;
            textBox_LeaveTime1.Enabled = true;
            textBox_LeaveTime2.Enabled = false;
            textBox_TimeAllow1.Enabled = true;
            textBox_TimeAllow2.Enabled = false;
        }
        private void radioButton_SatPeriods2_CheckedChanged(object sender, EventArgs e)
        {
            textBox_Time1.Enabled = true;
            textBox_Time2.Enabled = true;
            textBox_TimeAllow1.Enabled = true;
            textBox_TimeAllow2.Enabled = true;
            textBox_LeaveTime1.Enabled = true;
            textBox_LeaveTime2.Enabled = true;
        }
        private void radioButton_SatBreakDay_CheckedChanged(object sender, EventArgs e)
        {
            textBox_Time1.Enabled = false;
            textBox_Time2.Enabled = false;
            textBox_TimeAllow1.Enabled = false;
            textBox_TimeAllow2.Enabled = false;
            textBox_LeaveTime1.Enabled = false;
            textBox_LeaveTime2.Enabled = false;
            textBox_Time1.Text = "";
            textBox_Time2.Text = "";
            textBox_TimeAllow1.Text = "";
            textBox_TimeAllow2.Text = "";
            textBox_LeaveTime1.Text = "";
            textBox_LeaveTime2.Text = "";
        }
        private void UpdateAttend_IN2()
        {
            try
            {
                List<T_AttendOperat> q = db.T_AttendOperats.Where((T_AttendOperat t) => t.Operation == "IN2" && t.Date.Contains(Convert.ToDateTime(StartDate).ToString("yyyy/MM"))).ToList();
                if (q.Count <= 0)
                {
                    return;
                }
                int i = 0;
                while (true)
                {
                    if (i >= q.Count)
                    {
                        break;
                    }
                    List<T_Attend> listEmps = new List<T_Attend>(db.T_Attends.Where((T_Attend item) => item.EmpID == q[i].EmpID && item.Day_No == (int?)q[i].Day.Value).ToList()).ToList();
                    if (VarGeneral.CheckTime(listEmps[0].LeaveTime2) && (TimeSpan.Parse(Convert.ToDateTime(StartTime).ToString("HH:mm")) > TimeSpan.Parse(listEmps.First().LeaveTime2) || Convert.ToDateTime(Convert.ToDateTime(q[i].Date).ToString("yyyy/MM/dd")) < Convert.ToDateTime(Convert.ToDateTime(StartDate).ToString("yyyy/MM/dd"))))
                    {
                        T_AttendOperat Data_this_AttendOpOMR = new T_AttendOperat();
                        Data_this_AttendOpOMR = q[i];
                        if (string.IsNullOrEmpty(Data_this_AttendOpOMR.Time2))
                        {
                            Data_this_AttendOpOMR.Time2 = listEmps[0].LeaveTime2;
                        }
                        if (string.IsNullOrEmpty(Data_this_AttendOpOMR.LeaveTime2))
                        {
                            Data_this_AttendOpOMR.LeaveTime2 = listEmps[0].LeaveTime2;
                        }
                        T_AttendOperat t_AttendOperat = Data_this_AttendOpOMR;
                        t_AttendOperat.LateTime += (double)DTime(listEmps[0].Time2.Trim(), listEmps[0].LeaveTime2.Trim());
                        Data_this_AttendOpOMR.Operation = "DONE";
                        db.Log = VarGeneral.DebugLog;
                        db.SubmitChanges(ConflictMode.ContinueOnConflict);
                    }
                    i++;
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("FrmAttend_UpdateAttend_IN2:", error, enable: true);
            }
        }
        private void EndTest()
        {
            try
            {
                string tmpTime = "";
                bool flagSt = true;
                if (!AutoOut)
                {
                    return;
                }
                List<T_AttendOperat> newData = db.T_AttendOperats.Where((T_AttendOperat t) => t.T_Emp.EmpState == (bool?)true && t.Date.Contains(Convert.ToDateTime(StartDate).ToString("yyyy/MM")) && (t.Operation == "OUT1" || t.Operation == "OUT2")).ToList();
                for (int i = 0; i < newData.Count(); i++)
                {
                    T_Attend vAttend = db.EmpsAttends(newData[i].Day.Value);
                    if (vAttend == null || string.IsNullOrEmpty(vAttend.EmpID) || string.IsNullOrEmpty(vAttend.Attend_ID))
                    {
                        continue;
                    }
                    while (true)
                    {
                        if (newData[i].Operation == "OUT1")
                        {
                            if (VarGeneral.CheckTime(vAttend.LeaveTime1))
                            {
                                int Ind = int.Parse(vAttend.LeaveTime1.Substring(3, 2));
                                Ind += OutPeriode;
                                tmpTime = Convert.ToString(int.Parse(vAttend.LeaveTime1.Substring(0, 2)) + Ind / 60).Trim();
                                tmpTime = Convert.ToDateTime(tmpTime + ":" + Math.Round((double)Ind % 60.0, 2).ToString().Trim()).ToString("HH:mm");
                            }
                            else
                            {
                                tmpTime = "00:00";
                            }
                        }
                        else if (newData[i].Operation == "OUT2")
                        {
                            if (VarGeneral.CheckTime(vAttend.LeaveTime1))
                            {
                                int Ind = int.Parse(vAttend.LeaveTime2.Substring(3, 2));
                                Ind += OutPeriode;
                                tmpTime = Convert.ToString(int.Parse(vAttend.LeaveTime2.Substring(0, 2)) + Ind / 60).Trim();
                                tmpTime = Convert.ToDateTime(tmpTime + ":" + Math.Round((double)Ind % 60.0, 2).ToString().Trim()).ToString("HH:mm");
                            }
                            else
                            {
                                tmpTime = "00:00";
                            }
                        }
                        else
                        {
                            flagSt = false;
                        }
                        if (!flagSt || (!(TimeSpan.Parse(tmpTime) <= TimeSpan.Parse(Convert.ToDateTime(StartTime).ToString("HH:mm"))) && !(Convert.ToDateTime(Convert.ToDateTime(newData[i].Date).ToString("yyyy/MM/dd")) < Convert.ToDateTime(Convert.ToDateTime(StartDate).ToString("yyyy/MM/dd")))))
                        {
                            break;
                        }
                        Data_this_AttendOpOMR = new T_AttendOperat();
                        Data_this_AttendOpOMR = newData[i];
                        if (newData[i].Operation == "OUT1")
                        {
                            Data_this_AttendOpOMR.LeaveTime = tmpTime;
                            if (vAttend.Periods.Value == 1)
                            {
                                Data_this_AttendOpOMR.Operation = "DONE";
                                Data_this_AttendOpOMR.LeaveTime2 = "~~~~";
                                Data_this_AttendOpOMR.Time2 = "~~~~";
                            }
                            else if (vAttend.Periods.Value == 2)
                            {
                                Data_this_AttendOpOMR.Operation = "IN2";
                            }
                        }
                        else
                        {
                            Data_this_AttendOpOMR.Operation = "DONE";
                            Data_this_AttendOpOMR.LeaveTime2 = tmpTime;
                        }
                        db.Log = VarGeneral.DebugLog;
                        db.SubmitChanges(ConflictMode.ContinueOnConflict);
                    }
                    flagSt = true;
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("EndTest:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private T_AttendOperat UpdateAttend2(string value)
        {
            try
            {
                Data_this_UpdateOp.Note = textBox_Note.Text;
            }
            catch
            {
            }
            try
            {
                if (value == "OUT1")
                {
                    Data_this_UpdateOp.LeaveTime = textBox_ComeTime.Text;
                    if (radioButton_Periods1.Checked)
                    {
                        Data_this_UpdateOp.Operation = "DONE";
                        Data_this_UpdateOp.Time2 = "~~~~";
                        Data_this_UpdateOp.LeaveTime2 = "~~~~";
                    }
                    else
                    {
                        Data_this_UpdateOp.Operation = "IN2";
                    }
                }
                else
                {
                    Data_this_UpdateOp.LeaveTime2 = textBox_ComeTime.Text;
                    Data_this_UpdateOp.Operation = "DONE";
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("UpdateAttend2:", error, enable: true);
                MessageBox.Show(error.Message);
            }
            Clear();
            textBox_ID.Text = "";
            comboBox_Emp.SelectedIndex = -1;
            return Data_this_UpdateOp;
        }
        private void AutoSave_Attend(string vEmpID)
        {
            try
            {
                List<T_Emp> listEmps = db.T_Emps.Where((T_Emp t) => t.EmpState == (bool?)true && t.Emp_ID == vEmpID).ToList();
                if (listEmps.Count > 0)
                {
                    List<T_AttendOperat> q = db.T_AttendOperats.Where((T_AttendOperat item) => item.EmpID == vEmpID && item.Date == StartDate).ToList();
                    if (q.Count() == 0)
                    {
                        Data_this_AttendOpOMR = new T_AttendOperat();
                        GetDataOMR(listEmps.First());
                        Guid id = Guid.NewGuid();
                        Data_this_AttendOpOMR.AttendOperat_ID = id.ToString();
                        db.T_AttendOperats.InsertOnSubmit(Data_this_AttendOpOMR);
                        db.SubmitChanges();
                    }
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("AutoSave_Attend:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        public void FillComboOMR()
        {
            comboBox_Emp.SelectedValueChanged -= comboBox_Emp_SelectedValueChanged;
            List<T_Emp> listEmp = new List<T_Emp>(db.T_Emps.Where((T_Emp item) => item.EmpState == (bool?)true).ToList());
            comboBox_Emp.DataSource = listEmp;
            comboBox_Emp.DisplayMember = ((LangArEn == 0) ? "NameA" : "NameE");
            comboBox_Emp.ValueMember = "Emp_ID";
            comboBox_Emp.SelectedValueChanged += comboBox_Emp_SelectedValueChanged;
            List<T_Project> listSection = new List<T_Project>(db.T_Projects.Select((T_Project item) => item).ToList());
            comboBox_PRoject.DataSource = null;
            listSection.Insert(0, new T_Project());
            comboBox_PRoject.DataSource = listSection;
            comboBox_PRoject.DisplayMember = ((LangArEn == 0) ? "NameA" : "NameE");
            comboBox_PRoject.ValueMember = "Project_No";
        }
        public void SetDataOMR(T_Emp value)
        {
            State = FormState.Saved;
            ModifyActiveTime = false;
            bubbleButton_Ok.Enabled = false;
            bubbleButton_Leave.Enabled = false;
            textBox_ID.Tag = value.Emp_ID;
            if (string.IsNullOrEmpty(VarGeneral.Decrypt(value.Pass.Trim())))
            {
                textBox_Pass.ButtonCustom.Visible = true;
            }
            else
            {
                textBox_Pass.ButtonCustom.Visible = false;
            }
            SetReadOnlyOMR = true;
            SetRead_Coming = true;
            SetRead_Leaving = true;
            comboBox_Emp.SelectedValueChanged -= comboBox_Emp_SelectedValueChanged;
            textBox_ID.Text = value.Emp_No;
            comboBox_Emp.SelectedValue = value.Emp_ID;
            if (value.ProjectNo.HasValue)
            {
                comboBox_PRoject.SelectedValue = value.ProjectNo.Value;
            }
            else
            {
                comboBox_PRoject.SelectedIndex = 0;
            }
            comboBox_Emp.SelectedValueChanged += comboBox_Emp_SelectedValueChanged;
            BindingList<T_Attend> lines = new BindingList<T_Attend>(value.T_Attends);
            FillAttendBox(lines);
        }
        private void FillAttendBox(BindingList<T_Attend> linesList)
        {
            if (!string.IsNullOrEmpty(textBox_Day.Tag.ToString()))
            {
                VarGeneral.Day_No = (int)textBox_Day.Tag;
            }
            if (linesList.Count <= 0 || string.IsNullOrEmpty(textBox_ID.Text))
            {
                return;
            }
            for (int i = 0; i < linesList.Count; i++)
            {
                if (i == VarGeneral.Day_No - 1)
                {
                    textBox_TimeOMR1.Text = linesList[i].Time1;
                    textBox_TimeOMR2.Text = linesList[i].Time2;
                    textBox_LeaveTimeOMR1.Text = linesList[i].LeaveTime1;
                    textBox_LeaveTimeOMR2.Text = linesList[i].LeaveTime2;
                    if (linesList[i].Periods == 1)
                    {
                        radioButton_PeriodsOMR1.Checked = true;
                    }
                    else if (linesList[i].Periods == 2)
                    {
                        radioButton_PeriodsOMR2.Checked = true;
                    }
                    else
                    {
                        radioButton_BreakDayOMR.Checked = true;
                    }
                }
            }
        }
        private void bubbleButton_Leave_Click(object sender, ClickEventArgs e)
        {
            try
            {
                T_Emp Emplist = db.EmpsEmpNo(textBox_ID.Text);
                if (string.IsNullOrEmpty(Emplist.Emp_ID))
                {
                    return;
                }
                State = FormState.Edit;
                Data_this_AttendOpOMR.EmpID = comboBox_Emp.SelectedValue.ToString();
                Data_this_AttendOpOMR.Day = int.Parse(textBox_Day.Tag.ToString());
                Data_this_AttendOpOMR.Date = Convert.ToDateTime(StartDate).ToString("yyyy/MM/dd");
                if (VarGeneral.FlagState == "OUT1")
                {
                    Data_this_AttendOpOMR.LeaveTime = Convert.ToDateTime(textBox_ComeTime.Text).ToString("HH:mm");
                }
                else
                {
                    Data_this_AttendOpOMR.LeaveTime2 = Convert.ToDateTime(textBox_ComeTime.Text).ToString("HH:mm");
                }
                if (VarGeneral.FlagState == "OUT1")
                {
                    if (Data_this_AttendOMR.Periods == 1)
                    {
                        Data_this_AttendOpOMR.Operation = "DONE";
                        Data_this_AttendOpOMR.Time2 = "~~~~";
                        Data_this_AttendOpOMR.LeaveTime2 = "~~~~";
                    }
                    else
                    {
                        Data_this_AttendOpOMR.Operation = "IN2";
                    }
                }
                else
                {
                    Data_this_AttendOpOMR.Operation = "DONE";
                }
                if (!string.IsNullOrEmpty(textBox_Note.Text))
                {
                    if (!string.IsNullOrEmpty(Data_this_AttendOpOMR.Note))
                    {
                        Data_this_AttendOpOMR.Note = Data_this_AttendOpOMR.Note + " | " + textBox_Note.Text;
                    }
                    else
                    {
                        Data_this_AttendOpOMR.Note = textBox_Note.Text;
                    }
                }
                else
                {
                    Data_this_AttendOpOMR.Note = textBox_Note.Text;
                }
                db.Log = VarGeneral.DebugLog;
                db.SubmitChanges(ConflictMode.ContinueOnConflict);
                State = FormState.Saved;
                textBox_ID.Text = "";
                textBox_ID_Leave(sender, e);
                comboBox_Emp.SelectedIndex = -1;
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("bubbleButton_Leave_Click:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void textBox_ComeTime_Leave(object sender, EventArgs e)
        {
            try
            {
                if (textBox_ComeTime.Enabled)
                {
                    if (VarGeneral.CheckTime(textBox_ComeTime.Text))
                    {
                        textBox_ComeTime.Text = Convert.ToDateTime(textBox_ComeTime.Text).ToString("HH:mm");
                    }
                    else
                    {
                        textBox_ComeTime.Text = Convert.ToDateTime(label_TimeTimer.Text).ToString("HH:mm");
                    }
                    ModifyActiveTime = true;
                    textBox_Pass_Leave(sender, e);
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("textBox_ComeTime_Leave:", error, enable: true);
            }
        }
        private void vMain(string vEmpID)
        {
            try
            {
                textBox_ID.Leave -= textBox_ID_Leave;
                T_Emp newData = db.EmpsEmpNo(vEmpID);
                textBox_Pass.Text = "";
                if (newData == null || string.IsNullOrEmpty(newData.Emp_ID))
                {
                    Clear();
                    textBox_ID.Focus();
                    goto IL_01a8;
                }
                DataThisOMR = newData;
                int indexA = PKeys.IndexOf(newData.Emp_No ?? "");
                indexA++;
                if (db.CheckEmpVac(vEmpID, StartDate))
                {
                    bubbleButton_Ok.Visible = false;
                    bubbleButton_Leave.Visible = false;
                    textBox_Pass.ReadOnly = true;
                    textBox_Note.Text = ((LangArEn == 0) ? "الموظف في اجازة" : "Employee on vacation");
                    return;
                }
                bubbleButton_Ok.Visible = true;
                textBox_Pass.ReadOnly = false;
                bubbleButton_Leave.Visible = true;
                if (radioButton_BreakDayOMR.Checked)
                {
                    bubbleButton_Ok.Visible = false;
                    bubbleButton_Leave.Visible = false;
                    textBox_Pass.ReadOnly = true;
                    textBox_Note.Text = ((LangArEn == 0) ? "الموظف في راحة" : "Employee in comfort");
                }
                else
                {
                    bubbleButton_Ok.Visible = true;
                    textBox_Pass.ReadOnly = false;
                    bubbleButton_Leave.Visible = true;
                }
                goto IL_01a8;
            IL_01a8:
                if (textBox_Pass.ButtonCustom.Visible)
                {
                    textBox_Pass.ReadOnly = true;
                    textBox_Note.Focus();
                }
                else
                {
                    textBox_Pass.ReadOnly = false;
                    textBox_Pass.Focus();
                }
                textBox_ID.Leave += textBox_ID_Leave;
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("vMain:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private int DTimeOMR(string BTime, string Etime)
        {
            try
            {
                if (string.IsNullOrEmpty(BTime) || string.IsNullOrEmpty(Etime))
                {
                    return 0;
                }
                if (!VarGeneral.CheckDate(BTime) || !VarGeneral.CheckDate(Etime))
                {
                    return 0;
                }
                int LAmount = 0;
                if (TimeSpan.Parse(Etime) > TimeSpan.Parse(BTime))
                {
                    LAmount = int.Parse(Etime.Substring(3, 2)) - int.Parse(BTime.Substring(3, 2));
                    LAmount += 60 * (int.Parse(Etime.Substring(0, 2)) - int.Parse(BTime.Substring(0, 2)));
                }
                return LAmount;
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("DTimeOMR:", error, enable: true);
                MessageBox.Show(error.Message);
                return 0;
            }
        }
        private void textBox_Pass_Leave(object sender, EventArgs e)
        {
            try
            {
                if (comboBox_Emp.SelectedIndex == -1 || textBox_Pass.Text == "" || VarGeneral.Decrypt(data_thisOMR.Pass).ToUpper() != textBox_Pass.Text.ToUpper())
                {
                    return;
                }
                string ActiveTime = ((!ModifyActiveTime) ? TimeSpan.Parse(label_TimeTimer.Text).ToString() : TimeSpan.Parse(textBox_ComeTime.Text).ToString());
                textBox_ComeTime.Text = ActiveTime;
                List<T_Attend> Quary = (from t in db.T_Attends
                                        where t.EmpID == comboBox_Emp.SelectedValue.ToString()
                                        where t.Day_No == (int?)VarGeneral.Day_No
                                        select t).ToList();
                if (Quary.Count <= 0)
                {
                    return;
                }
                Data_this_AttendOMR = new T_Attend();
                Data_this_AttendOMR = Quary.First();
                textBox_ComeTime.Text = ActiveTime;
                string sqlQuary = "Select * from [T_AttendOperat] where [EmpID]='" + comboBox_Emp.SelectedValue.ToString() + "' And [Date] like '" + Convert.ToDateTime(StartDate).ToString("yyyy/MM/dd") + "' Order By [AttendOperat_ID]";
                List<T_AttendOperat> q = db.ExecuteQuery<T_AttendOperat>(sqlQuary, new object[0]).ToList();
                if (q.Count == 0)
                {
                    SetRead_Coming = false;
                    SetRead_Leaving = true;
                    SetReadOnlyOMR = false;
                    VarGeneral.FlagState = "";
                    if (VarGeneral.CheckTime(Data_this_AttendOMR.LeaveTime1) && TimeSpan.Parse(ActiveTime) > TimeSpan.Parse(Data_this_AttendOMR.LeaveTime1))
                    {
                        AutoSave_Attend(comboBox_Emp.SelectedValue.ToString());
                        Data_this_AttendOpOMR.Time1 = Data_this_AttendOMR.LeaveTime1;
                        Data_this_AttendOpOMR.LeaveTime = Data_this_AttendOMR.LeaveTime1;
                        Data_this_AttendOpOMR.LateTime = DTime(Data_this_AttendOMR.Time1.Trim(), Data_this_AttendOMR.LeaveTime1.Trim());
                        if (Data_this_AttendOMR.Periods == 1)
                        {
                            Data_this_AttendOpOMR.Operation = "DONE";
                            Data_this_AttendOpOMR.Time2 = "~~~~";
                            Data_this_AttendOpOMR.LeaveTime2 = "~~~~";
                        }
                        else
                        {
                            Data_this_AttendOpOMR.Operation = "IN2";
                        }
                        db.Log = VarGeneral.DebugLog;
                        db.SubmitChanges(ConflictMode.ContinueOnConflict);
                        SetRead_Coming = true;
                        SetRead_Leaving = true;
                        SetReadOnlyOMR = false;
                    }
                    if (VarGeneral.CheckTime(Data_this_AttendOMR.TimeAllow1))
                    {
                        if (TimeSpan.Parse(ActiveTime) > TimeSpan.Parse(Data_this_AttendOMR.TimeAllow1))
                        {
                            textBox_LateTime.Value = DTime(Data_this_AttendOMR.Time1.Trim(), ActiveTime.Trim());
                        }
                        else
                        {
                            textBox_LateTime.Value = 0.0;
                        }
                    }
                    return;
                }
                Data_this_AttendOpOMR = new T_AttendOperat();
                Data_this_AttendOpOMR = q.First();
                if (Data_this_AttendOpOMR.Operation == "IN1")
                {
                    VarGeneral.FlagState = "IN1";
                    SetRead_Coming = false;
                    SetRead_Leaving = true;
                    SetReadOnlyOMR = false;
                    if (VarGeneral.CheckTime(Data_this_AttendOMR.TimeAllow1))
                    {
                        if (TimeSpan.Parse(ActiveTime) > TimeSpan.Parse(Data_this_AttendOMR.TimeAllow1))
                        {
                            textBox_LateTime.Value = DTime(Data_this_AttendOMR.Time1.Trim(), ActiveTime.Trim());
                        }
                        else
                        {
                            textBox_LateTime.Value = 0.0;
                        }
                    }
                    goto IL_0b91;
                }
                if (Data_this_AttendOpOMR.Operation == "OUT1")
                {
                    VarGeneral.FlagState = "OUT1";
                    if (AutoOut)
                    {
                        if (VarGeneral.CheckTime(Data_this_AttendOMR.LeaveTime1))
                        {
                            int Ind = int.Parse(Data_this_AttendOMR.LeaveTime1.Substring(3, 2));
                            Ind += OutPeriode;
                            string tmpTime = Convert.ToString(int.Parse(Data_this_AttendOMR.LeaveTime1.Substring(0, 2)) + Ind / 60).Trim();
                            tmpTime = Convert.ToDateTime(tmpTime + ":" + Math.Round((double)Ind % 60.0, 2)).ToString("HH:mm").Trim();
                            if (TimeSpan.Parse(tmpTime) <= TimeSpan.Parse(ActiveTime))
                            {
                                Data_this_AttendOpOMR.LeaveTime = tmpTime;
                                if (Data_this_AttendOMR.Periods.Value == 1)
                                {
                                    Data_this_AttendOpOMR.Operation = "DONE";
                                    Data_this_AttendOpOMR.LeaveTime2 = "~~~~";
                                    Data_this_AttendOpOMR.Time2 = "~~~~";
                                }
                                else
                                {
                                    Data_this_AttendOpOMR.Operation = "IN2";
                                }
                                db.Log = VarGeneral.DebugLog;
                                db.SubmitChanges(ConflictMode.ContinueOnConflict);
                                SetRead_Coming = true;
                                SetRead_Leaving = true;
                                SetReadOnlyOMR = false;
                            }
                            else
                            {
                                SetRead_Coming = true;
                                SetRead_Leaving = false;
                                SetReadOnlyOMR = false;
                            }
                        }
                        else
                        {
                            SetRead_Coming = true;
                            SetRead_Leaving = false;
                            SetReadOnlyOMR = false;
                        }
                    }
                    else
                    {
                        SetRead_Coming = true;
                        SetRead_Leaving = false;
                        SetReadOnlyOMR = false;
                    }
                    goto IL_0b91;
                }
                if (Data_this_AttendOpOMR.Operation == "IN2")
                {
                    if (VarGeneral.CheckTime(Data_this_AttendOMR.LeaveTime2) && TimeSpan.Parse(ActiveTime) > TimeSpan.Parse(Data_this_AttendOMR.LeaveTime2))
                    {
                        Data_this_AttendOpOMR.Time2 = Data_this_AttendOMR.LeaveTime2;
                        Data_this_AttendOpOMR.LeaveTime2 = Data_this_AttendOMR.LeaveTime2;
                        T_AttendOperat data_this_AttendOpOMR = Data_this_AttendOpOMR;
                        data_this_AttendOpOMR.LateTime += (double)DTime(Data_this_AttendOMR.Time2.Trim(), Data_this_AttendOMR.LeaveTime2.Trim());
                        Data_this_AttendOpOMR.Operation = "DONE";
                        db.Log = VarGeneral.DebugLog;
                        db.SubmitChanges(ConflictMode.ContinueOnConflict);
                        SetRead_Coming = true;
                        SetRead_Leaving = true;
                        SetReadOnlyOMR = false;
                        return;
                    }
                    if (VarGeneral.CheckTime(Data_this_AttendOMR.TimeAlow2))
                    {
                        if (TimeSpan.Parse(ActiveTime) > TimeSpan.Parse(Data_this_AttendOMR.TimeAlow2))
                        {
                            textBox_LateTime.Value = DTime(Data_this_AttendOMR.Time2.Trim(), ActiveTime.Trim());
                        }
                        else
                        {
                            textBox_LateTime.Value = 0.0;
                        }
                    }
                    SetRead_Coming = false;
                    SetRead_Leaving = true;
                    SetReadOnlyOMR = false;
                    VarGeneral.FlagState = "IN2";
                    goto IL_0b91;
                }
                if (Data_this_AttendOpOMR.Operation.Trim() == "OUT2")
                {
                    if (AutoOut)
                    {
                        if (VarGeneral.CheckTime(Data_this_AttendOMR.LeaveTime2))
                        {
                            int Ind = int.Parse(Data_this_AttendOMR.LeaveTime2.Substring(3, 2));
                            Ind += OutPeriode;
                            string tmpTime = Convert.ToString(int.Parse(Data_this_AttendOMR.LeaveTime2.Substring(0, 2)) + Ind / 60).Trim();
                            tmpTime = Convert.ToDateTime(tmpTime + ":" + Math.Round((double)Ind % 60.0, 2)).ToString("HH:mm").Trim();
                            if (TimeSpan.Parse(tmpTime) <= TimeSpan.Parse(ActiveTime))
                            {
                                Data_this_AttendOpOMR.LeaveTime2 = tmpTime;
                                Data_this_AttendOpOMR.Operation = "DONE";
                                db.Log = VarGeneral.DebugLog;
                                db.SubmitChanges(ConflictMode.ContinueOnConflict);
                                SetRead_Coming = true;
                                SetRead_Leaving = true;
                                SetReadOnlyOMR = false;
                            }
                            else
                            {
                                SetRead_Coming = true;
                                SetRead_Leaving = false;
                                SetReadOnlyOMR = false;
                            }
                        }
                        else
                        {
                            SetRead_Coming = true;
                            SetRead_Leaving = false;
                            SetReadOnlyOMR = false;
                        }
                    }
                    else
                    {
                        SetRead_Coming = true;
                        SetRead_Leaving = false;
                        SetReadOnlyOMR = false;
                    }
                }
                else if (Data_this_AttendOpOMR.Operation.Trim() == "DONE")
                {
                    SetRead_Coming = true;
                    SetRead_Leaving = true;
                    SetReadOnlyOMR = false;
                }
                goto IL_0b91;
            IL_0b91:
                try
                {
                    textBox_Pass.Leave -= textBox_Pass_Leave;
                    if (textBox_ComeTime.Enabled)
                    {
                        textBox_ComeTime.Focus();
                    }
                    else
                    {
                        textBox_Note.Focus();
                    }
                    textBox_Pass.Leave += textBox_Pass_Leave;
                }
                catch
                {
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("textBox_Pass_Leave:", error, enable: true);
            }
        }
        private void maskedTextBox1_Leave(object sender, EventArgs e)
        {
            ModifyActiveTime = true;
            textBox_Pass_TextChanged(sender, e);
        }
        private void textBox_Pass_ButtonCustomClick(object sender, EventArgs e)
        {
            if (comboBox_Emp.SelectedIndex != -1)
            {
                FrmSetPass frm = new FrmSetPass();
                frm.Emp_no = textBox_ID.Tag.ToString();
                frm.Tag = LangArEn;
                frm.TopMost = true;
                frm.ShowDialog();
                dbInstance = null;
                vMain(textBox_ID.Text);
            }
        }
        private void comboBox_Emp_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboBox_Emp.SelectedIndex != -1)
            {
                textBox_ID.Tag = comboBox_Emp.SelectedValue.ToString() ?? "";
                T_Emp vEmpNo = db.EmpsEmp(textBox_ID.Tag.ToString());
                vMain(vEmpNo.Emp_No);
            }
        }
        private void textBox_Pass_TextChanged(object sender, EventArgs e)
        {
            if (comboBox_Emp.SelectedIndex != -1 && VarGeneral.Decrypt(data_thisOMR.Pass).ToUpper() == textBox_Pass.Text.ToUpper())
            {
                textBox_Pass_Leave(sender, e);
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            label_TimeTimer.Text = DateTime.Now.ToString("HH:mm:ss");
        }
        private T_AttendOperat GetDataOMR(T_Emp value)
        {
            try
            {
                Data_this_AttendOpOMR.EmpID = value.Emp_ID;
            }
            catch
            {
            }
            try
            {
                Data_this_AttendOpOMR.Date = Convert.ToDateTime(StartDate).ToString("yyyy/MM/dd");
            }
            catch
            {
            }
            try
            {
                Data_this_AttendOpOMR.Day = VarGeneral.Day_No;
            }
            catch
            {
            }
            try
            {
                Data_this_AttendOpOMR.Note = "";
            }
            catch
            {
            }
            try
            {
                Data_this_AttendOpOMR.ComeTime = "";
            }
            catch
            {
            }
            try
            {
                Data_this_AttendOpOMR.LateTime = 0.0;
            }
            catch
            {
            }
            try
            {
                Data_this_AttendOpOMR.Time1 = "";
            }
            catch
            {
            }
            try
            {
                Data_this_AttendOpOMR.Time2 = "";
            }
            catch
            {
            }
            try
            {
                Data_this_AttendOpOMR.LeaveTime = "";
            }
            catch
            {
            }
            try
            {
                Data_this_AttendOpOMR.LeaveTime2 = "";
            }
            catch
            {
            }
            try
            {
                Data_this_AttendOpOMR.Operation = "";
            }
            catch
            {
            }
            return Data_this_AttendOpOMR;
        }
        private void textBox_Day_TextChanged(object sender, EventArgs e)
        {
            UpdateDays();
        }
        private void UpdateDays()
        {
            if (textBox_Day.Text.Contains("السبت") || textBox_Day.Text.Contains("Sat"))
            {
                if (LangArEn != 0)
                {
                    textBox_Day.Text = "Sat";
                }
                else
                {
                    textBox_Day.Text = "السبت";
                }
            }
            if (textBox_Day.Text.Contains("الاحد") || textBox_Day.Text.Contains("Sun"))
            {
                if (LangArEn != 0)
                {
                    textBox_Day.Text = "Sun";
                }
                else
                {
                    textBox_Day.Text = "الاحد";
                }
            }
            if (textBox_Day.Text.Contains("الاثنين") || textBox_Day.Text.Contains("Mon"))
            {
                if (LangArEn != 0)
                {
                    textBox_Day.Text = "Mon";
                }
                else
                {
                    textBox_Day.Text = "الاثنين";
                }
            }
            if (textBox_Day.Text.Contains("الثلاثاء") || textBox_Day.Text.Contains("Tues"))
            {
                if (LangArEn != 0)
                {
                    textBox_Day.Text = "Tuse";
                }
                else
                {
                    textBox_Day.Text = "الثلاثاء";
                }
            }
            if (textBox_Day.Text.Contains("الاربعاء") || textBox_Day.Text.Contains("Wen"))
            {
                if (LangArEn != 0)
                {
                    textBox_Day.Text = "Wen";
                }
                else
                {
                    textBox_Day.Text = "الاربعاء";
                }
            }
            if (textBox_Day.Text.Contains("الخميس") || textBox_Day.Text.Contains("Thur"))
            {
                if (LangArEn != 0)
                {
                    textBox_Day.Text = "Thur";
                }
                else
                {
                    textBox_Day.Text = "الخميس";
                }
            }
            if (textBox_Day.Text.Contains("الجمعة") || textBox_Day.Text.Contains("Fri"))
            {
                if (LangArEn != 0)
                {
                    textBox_Day.Text = "Fri";
                }
                else
                {
                    textBox_Day.Text = "الجمعة";
                }
            }
        }
        private void textBox_ID_Leave(object sender, EventArgs e)
        {
            vMain(textBox_ID.Text);
        }
        private void button_ADDPRoject_Click(object sender, EventArgs e)
        {
            FrmPRoject frm = new FrmPRoject();
            frm.Tag = LangArEn;
            string vList = "";
            if (comboBox_PRoject.SelectedIndex != -1)
            {
                vList = comboBox_PRoject.SelectedValue.ToString();
            }
            frm.TopMost = true;
            frm.ShowDialog();
            Stock_DataDataContext dbc = new Stock_DataDataContext(VarGeneral.BranchCS);
            List<T_Project> list = new List<T_Project>(dbc.T_Projects.Select((T_Project item) => item).ToList());
            comboBox_PRoject.DataSource = null;
            list.Insert(0, new T_Project());
            comboBox_PRoject.DataSource = list;
            comboBox_PRoject.DisplayMember = ((LangArEn == 0) ? "NameA" : "NameE");
            comboBox_PRoject.ValueMember = "Project_No";
            if (vList != "")
            {
                for (int i = 0; i < comboBox_PRoject.Items.Count; i++)
                {
                    comboBox_PRoject.SelectedIndex = i;
                    if (comboBox_PRoject.SelectedValue.ToString() == vList)
                    {
                        break;
                    }
                }
            }
            else
            {
                comboBox_PRoject.SelectedIndex = -1;
            }
        }
        private void textBox_ID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (e.KeyChar != '\b'))
            {
                e.Handled = true;
            }
        }
        private void button_SrchPRoject_Click(object sender, EventArgs e)
        {
            try
            {
                Dir_ButSearch.Add("Project_No", new ColumnDictinary("رقم المشروع", "Project No", ifDefault: true, ""));
                Dir_ButSearch.Add("NameA", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, ""));
                Dir_ButSearch.Add("NameE", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: false, ""));
                Dir_ButSearch.Add("Note", new ColumnDictinary("الملاحظات", "Note", ifDefault: true, ""));
                FrmSearch frm = new FrmSearch();
                frm.Tag = LangArEn;
                ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = Dir_ButSearch;
                foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
                {
                    frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, ""));
                }
                VarGeneral.SFrmTyp = "T_Project";
                frm.TopMost = true;
                frm.ShowDialog();
                if (frm.SerachNo != "")
                {
                    comboBox_PRoject.SelectedValue = int.Parse(frm.SerachNo);
                }
                Dir_ButSearch.Clear();
            }
            catch
            {
            }
        }
        private void button_SrchEmp_Click(object sender, EventArgs e)
        {
            try
            {
                Dir_ButSearch.Add("Emp_No", new ColumnDictinary("رقم الموظف", "Employee No", ifDefault: true, ""));
                Dir_ButSearch.Add("NameA", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, ""));
                Dir_ButSearch.Add("NameE", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: false, ""));
                Dir_ButSearch.Add("DateAppointment", new ColumnDictinary("تاريخ التعيين", "Appointment Date", ifDefault: false, ""));
                Dir_ButSearch.Add("StartContr", new ColumnDictinary("بداية العقد", "Start Contract Date", ifDefault: false, ""));
                Dir_ButSearch.Add("EndContr", new ColumnDictinary("نهاية العقد", "End Contract Date", ifDefault: false, ""));
                Dir_ButSearch.Add("MainSal", new ColumnDictinary("الراتب الأساسي", "Main Salary", ifDefault: false, ""));
                Dir_ButSearch.Add("ID_No", new ColumnDictinary("رقم الهوية", "ID No", ifDefault: false, ""));
                Dir_ButSearch.Add("Passport_No", new ColumnDictinary("رقم الجواز", "Passport No", ifDefault: false, ""));
                Dir_ButSearch.Add("AddressA", new ColumnDictinary("العنوان", "Address", ifDefault: false, ""));
                Dir_ButSearch.Add("Tel", new ColumnDictinary("الهاتف", "Tel", ifDefault: false, ""));
                Dir_ButSearch.Add("Note", new ColumnDictinary(" الملاحظــات", "Note", ifDefault: false, ""));
                FrmSearch frm = new FrmSearch();
                frm.Tag = LangArEn;
                ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = Dir_ButSearch;
                foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
                {
                    frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, ""));
                }
                VarGeneral.SFrmTyp = "T_Emp";
                VarGeneral.FrmEmpStat = true;
                frm.TopMost = true;
                frm.ShowDialog();
                if (frm.SerachNo != "")
                {
                    frm.Serach_No = db.EmpsEmpNo(frm.Serach_No).Emp_ID;
                    comboBox_Emp.SelectedValue = frm.SerachNo;
                }
                Dir_ButSearch.Clear();
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("button_SrchEmp_Click:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void textBox_ComeTime_Click(object sender, EventArgs e)
        {
            textBox_ComeTime.SelectAll();
        }
        private void bubbleButton_Ok_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox_ComeTime.Text.Length != 5)
                {
                    return;
                }
                T_Emp Emplist = db.EmpsEmpNo(textBox_ID.Text);
                if (!string.IsNullOrEmpty(Emplist.Emp_ID))
                {
                    if (VarGeneral.FlagState == "")
                    {
                        VarGeneral.FlagState = "IN1";
                        State = FormState.New;
                        Data_this_AttendOpOMR = new T_AttendOperat();
                        Data_this_AttendOpOMR.Time1 = "";
                        Data_this_AttendOpOMR.Time2 = "";
                        Data_this_AttendOpOMR.LeaveTime = "";
                        Data_this_AttendOpOMR.LeaveTime2 = "";
                        Data_this_AttendOpOMR.LateTime = 0.0;
                    }
                    else
                    {
                        State = FormState.Edit;
                    }
                    Data_this_AttendOpOMR.EmpID = comboBox_Emp.SelectedValue.ToString();
                    Data_this_AttendOpOMR.Day = VarGeneral.Day_No;
                    Data_this_AttendOpOMR.Date = Convert.ToDateTime(StartDate).ToString("yyyy/MM/dd");
                    if (VarGeneral.FlagState == "IN1")
                    {
                        Data_this_AttendOpOMR.Time1 = Convert.ToDateTime(textBox_ComeTime.Text).ToString("HH:mm");
                    }
                    else
                    {
                        Data_this_AttendOpOMR.Time2 = Convert.ToDateTime(textBox_ComeTime.Text).ToString("HH:mm");
                    }
                    if (VarGeneral.FlagState == "IN1")
                    {
                        Data_this_AttendOpOMR.LateTime = textBox_LateTime.Value;
                    }
                    else
                    {
                        T_AttendOperat data_this_AttendOpOMR = Data_this_AttendOpOMR;
                        data_this_AttendOpOMR.LateTime += textBox_LateTime.Value;
                    }
                    if (VarGeneral.FlagState == "IN1")
                    {
                        Data_this_AttendOpOMR.Operation = "OUT1";
                    }
                    else
                    {
                        Data_this_AttendOpOMR.Operation = "OUT2";
                    }
                    Data_this_AttendOpOMR.Note = textBox_Note.Text;
                    Data_this_AttendOpOMR.ComeTime = Convert.ToDateTime(textBox_ComeTime.Text).ToString("HH:mm");
                    try
                    {
                        if (comboBox_PRoject.SelectedIndex > 0)
                        {
                            Data_this_AttendOpOMR.ProjectNo = int.Parse(comboBox_PRoject.SelectedValue.ToString());
                        }
                        else
                        {
                            Data_this_AttendOpOMR.ProjectNo = null;
                        }
                    }
                    catch
                    {
                        Data_this_AttendOpOMR.ProjectNo = null;
                    }
                    if (State == FormState.Edit)
                    {
                        db.Log = VarGeneral.DebugLog;
                        db.SubmitChanges(ConflictMode.ContinueOnConflict);
                    }
                    else
                    {
                        Guid id = Guid.NewGuid();
                        Data_this_AttendOpOMR.AttendOperat_ID = id.ToString();
                        db.T_AttendOperats.InsertOnSubmit(Data_this_AttendOpOMR);
                        db.SubmitChanges();
                    }
                }
                try
                {
                    if (comboBox_PRoject.SelectedIndex > 0)
                    {
                        db.ExecuteCommand("UPDATE [T_Emp] SET T_Emp.ProjectNo = " + Data_this_AttendOpOMR.ProjectNo.Value + " WHERE T_Emp.Emp_ID = '" + Data_this_AttendOpOMR.EmpID + "'");
                    }
                    else
                    {
                        db.ExecuteCommand("UPDATE [T_Emp] SET T_Emp.ProjectNo = null  WHERE T_Emp.Emp_ID = '" + Data_this_AttendOpOMR.EmpID + "'");
                    }
                }
                catch
                {
                    db.ExecuteCommand("UPDATE [T_Emp] SET T_Emp.ProjectNo = null  WHERE T_Emp.Emp_ID = '" + Data_this_AttendOpOMR.EmpID + "'");
                }
                db.CheckPreviousDays(textBox_ID.Tag.ToString(), StartDate, null, 0);
                State = FormState.Saved;
                dbInstance = null;
                textBox_ID.Text = "";
                textBox_ID_Leave(sender, e);
                comboBox_Emp.SelectedIndex = -1;
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("bubbleButton_Ok_Click:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void bubbleButton_Leave_Click(object sender, EventArgs e)
        {
            try
            {
                T_Emp Emplist = db.EmpsEmpNo(textBox_ID.Text);
                if (string.IsNullOrEmpty(Emplist.Emp_ID))
                {
                    return;
                }
                State = FormState.Edit;
                Data_this_AttendOpOMR.EmpID = comboBox_Emp.SelectedValue.ToString();
                Data_this_AttendOpOMR.Day = int.Parse(textBox_Day.Tag.ToString());
                Data_this_AttendOpOMR.Date = Convert.ToDateTime(StartDate).ToString("yyyy/MM/dd");
                if (VarGeneral.FlagState == "OUT1")
                {
                    Data_this_AttendOpOMR.LeaveTime = Convert.ToDateTime(textBox_ComeTime.Text).ToString("HH:mm");
                }
                else
                {
                    Data_this_AttendOpOMR.LeaveTime2 = Convert.ToDateTime(textBox_ComeTime.Text).ToString("HH:mm");
                }
                if (VarGeneral.FlagState == "OUT1")
                {
                    if (Data_this_AttendOMR.Periods == 1)
                    {
                        Data_this_AttendOpOMR.Operation = "DONE";
                        Data_this_AttendOpOMR.Time2 = "~~~~";
                        Data_this_AttendOpOMR.LeaveTime2 = "~~~~";
                    }
                    else
                    {
                        Data_this_AttendOpOMR.Operation = "IN2";
                    }
                }
                else
                {
                    Data_this_AttendOpOMR.Operation = "DONE";
                }
                if (!string.IsNullOrEmpty(textBox_Note.Text))
                {
                    if (!string.IsNullOrEmpty(Data_this_AttendOpOMR.Note))
                    {
                        Data_this_AttendOpOMR.Note = Data_this_AttendOpOMR.Note + " | " + textBox_Note.Text;
                    }
                    else
                    {
                        Data_this_AttendOpOMR.Note = textBox_Note.Text;
                    }
                }
                else
                {
                    Data_this_AttendOpOMR.Note = textBox_Note.Text;
                }
                db.Log = VarGeneral.DebugLog;
                db.SubmitChanges(ConflictMode.ContinueOnConflict);
                State = FormState.Saved;
                textBox_ID.Text = "";
                textBox_ID_Leave(sender, e);
                comboBox_Emp.SelectedIndex = -1;
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("bubbleButton_Leave_Click:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void bubbleButton_RepAttend_Click(object sender, EventArgs e)
        {
            try
            {
                FrmReportsViewer frm = new FrmReportsViewer();
                frm.Tag = LangArEn;
                frm.Tag = LangArEn;
                frm.Repvalue = "AttEmpRep";
                VarGeneral.vTitle = Text;
                frm.SqlWhere = "  AND [EmpID] ='" + comboBox_Emp.SelectedValue.ToString() + "' And ([Date] BETWEEN '" + VarGeneral.Gdate.Substring(0, 7) + "/01' And '" + VarGeneral.Gdate.Substring(0, 7) + "/31') OR ([Date] BETWEEN '" + VarGeneral.Hdate.Substring(0, 7) + "/01' And '" + VarGeneral.Hdate.Substring(0, 7) + "/31')";
                frm.TopMost = true;
                frm.ShowDialog();
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("bubbleButton_RepAttend_Click:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void bubbleButton_Ok_EnabledChanged(object sender, EventArgs e)
        {
            if (bubbleButton_Ok.Enabled)
            {
                panel_PROJECTs.Enabled = true;
            }
            else
            {
                panel_PROJECTs.Enabled = false;
            }
        }
        public void SplashStart()
        {
            System.Windows.Forms.Application.Run(new FrmImports());
        }
        private void FillGridImport()
        {
            if (!switchButton_FileSts.Value)
            {
                if (string.IsNullOrEmpty(textBox_SearchFilePath.Text))
                {
                    return;
                }
                if (File.Exists(textBox_SearchFilePath.Text))
                {
                    try
                    {
                        ExcelGridView.DataSource = null;
                        ExcelGridView.Rows.Clear();
                        ExcelGridView.Columns.Clear();
                    }
                    catch
                    {
                    }
                    object misValue = Missing.Value;
                    Microsoft.Office.Interop.Excel.Application xlApp = new ApplicationClass();
                    Workbook xlWorkBook = xlApp.Workbooks.Open(textBox_SearchFilePath.Text, 0, true, 5, "", "", true, XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                    Worksheet xlWorkSheet = (Worksheet)xlWorkBook.Worksheets.get_Item((object)1);
                    int ii = 0;
                    int iRowCount = 0;
                    for (int c = 0; c < 30; c++)
                    {
                        ExcelGridView.Columns.Add(ColumnsFinger[c], ColumnsFinger[c]);
                        try
                        {
                            for (int i = 1; i < xlWorkSheet.Rows.Count; i++)
                            {
                                string celladdr = ColumnsFinger[c] + i;
                                string cell = ((_Worksheet)xlWorkSheet).get_Range((object)celladdr, (object)celladdr).Value2.ToString();
                                if (ii == 0)
                                {
                                    ExcelGridView.Rows.Add();
                                }
                                ExcelGridView.Rows[i - 1].Cells[ii].Value = cell;
                                ExcelGridView.Rows[i - 1].HeaderCell.Value = i.ToString();
                                iRowCount = i;
                            }
                        }
                        catch
                        {
                        }
                        ii++;
                    }
                }
            }
            else
            {
                if (string.IsNullOrEmpty(textBox_SearchFilePath.Text))
                {
                    return;
                }
                if (File.Exists(textBox_SearchFilePath.Text))
                {
                    try
                    {
                        ExcelGridView.DataSource = null;
                        ExcelGridView.Rows.Clear();
                        ExcelGridView.Columns.Clear();
                    }
                    catch
                    {
                    }
                    StreamReader file = new StreamReader(textBox_SearchFilePath.Text, Encoding.Default, detectEncodingFromByteOrderMarks: true);
                    textBox_TimeT1.Text = file.ReadToEnd();
                    int iicnt = 0;
                    for (int c = 0; c < ColumnsFinger.Count; c++)
                    {
                        ExcelGridView.Columns.Add(ColumnsFinger[c], ColumnsFinger[c]);
                    }
                    for (int i = 0; i < textBox_TimeT1.Lines.Count(); i++)
                    {
                        ExcelGridView.Rows.Add();
                        if (!string.IsNullOrEmpty(textBox_TimeT1.Lines[i]))
                        {
                            string newline = textBox_TimeT1.Lines[i];
                            string[] values = newline.TrimStart().Split(' ');
                            for (int q = 0; q < values.Count(); q++)
                            {
                                if (IsInteger(values[q]) || string.IsNullOrEmpty(values[q]))
                                {
                                    ExcelGridView.Rows[i].Cells[iicnt].Value = values[q].ToString();
                                    iicnt++;
                                }
                            }
                        }
                        iicnt = 0;
                    }
                    try
                    {
                        ExcelGridView.Rows.RemoveAt(0);
                    }
                    catch
                    {
                    }
                    try
                    {
                        bool Empty = true;
                        for (int i = 0; i < ExcelGridView.Rows.Count; i++)
                        {
                            Empty = true;
                            for (int j = 0; j < ExcelGridView.Columns.Count; j++)
                            {
                                if (ExcelGridView.Rows[i].Cells[j].Value != null && ExcelGridView.Rows[i].Cells[j].Value.ToString() != "")
                                {
                                    Empty = false;
                                    break;
                                }
                            }
                            if (Empty)
                            {
                                ExcelGridView.Rows.RemoveAt(i);
                            }
                        }
                    }
                    catch
                    {
                    }
                }
            }
            GridStyle();
        }
        private void GridStyle()
        {
            try
            {
                for (int i = 0; i < ExcelGridView.Rows.Count; i += 2)
                {
                    ExcelGridView.Rows[i].DefaultCellStyle.BackColor = Color.LightBlue;
                }
            }
            catch
            {
            }
        }
        private bool IsInteger(string num)
        {
            bool vState = false;
            try
            {
                double.Parse(num);
                return true;
            }
            catch
            {
                vState = false;
            }
            try
            {
                TimeSpan dt = TimeSpan.Parse(num);
                return true;
            }
            catch
            {
                vState = false;
            }
            try
            {
                if (n.IsGreg(num) || n.IsHijri(num))
                {
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
        private void button_GetFromPath_Click(object sender, EventArgs e)
        {
            if (!switchButton_FileSts.Value)
            {
                try
                {
               System.Windows.Forms. OpenFileDialog  openFileDialog1 = new System.Windows.Forms. OpenFileDialog (); 
                    openFileDialog1.Filter = "Excel Files(.xls)|*.xls|Excel Files(.xlsx)|*.xlsx| Excel Files(*.xlsm)|*.xlsm";
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
                    openFileDialog1.Title = "اختيار ملف الحضور والانصراف";
                    if (openFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        textBox_SearchFilePath.Text = openFileDialog1.FileName;
                        return;
                    }
                }
                catch (Exception error2)
                {
                    VarGeneral.DebLog.writeLog("button_SelectPath_Click:", error2, enable: true);
                    MessageBox.Show(error2.Message);
                }
            }
            else
            {
                try
                {
               System.Windows.Forms. OpenFileDialog  openFileDialog1 = new System.Windows.Forms. OpenFileDialog (); 
                    openFileDialog1.Filter = "TXT files|*.txt";
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
                    openFileDialog1.Title = "اختيار ملف الحضور والانصراف";
                    if (openFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        textBox_SearchFilePath.Text = openFileDialog1.FileName;
                        return;
                    }
                }
                catch (Exception error2)
                {
                    VarGeneral.DebLog.writeLog("button_SelectPath_Click:", error2, enable: true);
                    MessageBox.Show(error2.Message);
                }
            }
            try
            {
                MessageBox.Show((LangArEn == 0) ? "تأكد من صحة مسار الملف " : "File Path Is Rong ", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                textBox_SearchFilePath.Text = "";
                ExcelGridView.DataSource = null;
                ExcelGridView.Rows.Clear();
                ExcelGridView.Columns.Clear();
            }
            catch
            {
            }
        }
        private void buttonX_ImportFile_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(textBox_SearchFilePath.Text) && File.Exists(textBox_SearchFilePath.Text))
                {
                    FillGridImport();
                    ExcelGridView_DataBindingComplete(null, null);
                    return;
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("button_SelectPath_Click:", error, enable: true);
            }
            ExcelGridView_DataBindingComplete(null, null);
            try
            {
                MessageBox.Show((LangArEn == 0) ? "تأكد من صحة مسار الملف " : "File Path Is Rong ", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                textBox_SearchFilePath.Text = "";
                ExcelGridView.DataSource = null;
                ExcelGridView.Rows.Clear();
                ExcelGridView.Columns.Clear();
            }
            catch
            {
            }
        }
        private void switchButton_FileSts_ValueChanged(object sender, EventArgs e)
        {
            textBox_SearchFilePath.Text = "";
        }
        private void textBox_EmpNo_Click(object sender, EventArgs e)
        {
            textBox_EmpNo.SelectAll();
        }
        private void textBox_Date_Click(object sender, EventArgs e)
        {
            textBox_Date.SelectAll();
        }
        private void textBox_TimeT1_Click(object sender, EventArgs e)
        {
            textBox_TimeT1.SelectAll();
        }
        private void textBox_TimeLeave1_Click(object sender, EventArgs e)
        {
            textBox_TimeLeave1.SelectAll();
        }
        private void ExcelGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            int col = e.ColumnIndex;
            try
            {
                if (!string.IsNullOrEmpty(textBox_TimeT1.Text) && ExcelGridView.Columns[col].Name == textBox_TimeT1.Text)
                {
                    if (!VarGeneral.CheckTime(ExcelGridView.Rows[row].Cells[col].Value.ToString()))
                    {
                        ExcelGridView.Rows[row].Cells[col].Value = "";
                    }
                    else
                    {
                        ExcelGridView.Rows[row].Cells[col].Value = Convert.ToDateTime(ExcelGridView.Rows[row].Cells[col].Value.ToString()).ToString("HH:mm");
                    }
                }
                if (!string.IsNullOrEmpty(textBox_TimeLeave1.Text) && ExcelGridView.Columns[col].Name == textBox_TimeLeave1.Text)
                {
                    if (!VarGeneral.CheckTime(ExcelGridView.Rows[row].Cells[col].Value.ToString()))
                    {
                        ExcelGridView.Rows[row].Cells[col].Value = "";
                    }
                    else
                    {
                        ExcelGridView.Rows[row].Cells[col].Value = Convert.ToDateTime(ExcelGridView.Rows[row].Cells[col].Value.ToString()).ToString("HH:mm");
                    }
                }
            }
            catch
            {
                ExcelGridView.Rows[row].Cells[col].Value = "";
            }
        }
        private void textBox_Start_Click(object sender, EventArgs e)
        {
            textBox_Start.SelectAll();
        }
        private void textBox_End_Click(object sender, EventArgs e)
        {
            textBox_End.SelectAll();
        }
        private void ButImportFile_Click(object sender, EventArgs e)
        {
            try
            {
                if (ExcelGridView.Rows.Count <= 0)
                {
                    return;
                }
                if (string.IsNullOrEmpty(textBox_EmpNo.Text))
                {
                    MessageBox.Show((LangArEn == 0) ? "تأكد من صحة خانة رقم الموظف" : "Must customize column employee number ?", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    textBox_EmpNo.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(textBox_Date.Text))
                {
                    MessageBox.Show((LangArEn == 0) ? "تأكد من صحة خانة التاريخ" : "Must customize column Date ?", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    textBox_Date.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(textBox_TimeT1.Text))
                {
                    MessageBox.Show((LangArEn == 0) ? "تأكد من صحة خانة وقت حضور الموظف " : "Must customize column Time Attendance ?", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    textBox_TimeT1.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(textBox_TimeLeave1.Text))
                {
                    MessageBox.Show((LangArEn == 0) ? "تأكد من صحة خانة وقت إنصراف الموظف " : "Must customize column Leaver Time ?", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    textBox_TimeLeave1.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(textBox_Start.Text))
                {
                    MessageBox.Show((LangArEn == 0) ? "تأكد من صحة خانة وقت الحضور الرسمي" : "Must customize column Time Attendance ?", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    textBox_Start.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(textBox_End.Text))
                {
                    MessageBox.Show((LangArEn == 0) ? "تأكد من صحة خانة وقت الإنصراف الرسمي" : "Must customize column Leaver Time ?", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    textBox_End.Focus();
                    return;
                }
                string EmpID = "";
                int xDay = 0;
                List<int> iRows = new List<int>();
                List<T_Attend> attend = new List<T_Attend>();
                bool vLoop = false;
                DateTime dt;
                for (int i = 0; i < ExcelGridView.Rows.Count; i++)
                {
                    try
                    {
                        if (vLoop)
                        {
                            i = 0;
                            vLoop = false;
                        }
                        State = FormState.New;
                        if (string.IsNullOrEmpty(ExcelGridView.Rows[i].Cells[textBox_EmpNo.Text].Value.ToString()) || !VarGeneral.CheckDate(Convert.ToDateTime(ExcelGridView.Rows[i].Cells[textBox_Date.Text].Value.ToString(), CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat).ToString("yyyy/MM/dd")))
                        {
                            continue;
                        }
                        try
                        {
                            EmpID = db.EmpsEmpNo(ExcelGridView.Rows[i].Cells[textBox_EmpNo.Text].Value.ToString()).Emp_ID;
                            xDay = n.GetDayNo(n.IsHijri(ExcelGridView.Rows[i].Cells[textBox_Date.Text].Value.ToString()) ? n.HijriToGreg(n.FormatHijri(Convert.ToDateTime(ExcelGridView.Rows[i].Cells[textBox_Date.Text].Value.ToString()).AddDays(VarGeneral.Settings_Sys.HDat.Value).ToString("yyyy/MM/dd"), "yyyy/MM/dd"), "yyyy/MM/dd") : n.FormatGreg(ExcelGridView.Rows[i].Cells[textBox_Date.Text].Value.ToString(), "yyyy/MM/dd")) + 1;
                            dt = Convert.ToDateTime(ExcelGridView.Rows[i].Cells[textBox_Date.Text].Value.ToString(), CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);
                        }
                        catch
                        {
                            continue;
                        }
                        try
                        {
                            double d = double.Parse(ExcelGridView.Rows[i].Cells[textBox_Start.Text].Value.ToString());
                            string dtToString = DateTime.FromOADate(d).ToString("HH:mm");
                            if (VarGeneral.CheckDate(dtToString))
                            {
                                ExcelGridView.Rows[i].Cells[textBox_Start.Text].Value = dtToString;
                            }
                        }
                        catch
                        {
                        }
                        try
                        {
                            double d = double.Parse(ExcelGridView.Rows[i].Cells[textBox_End.Text].Value.ToString());
                            string dtToString = DateTime.FromOADate(d).ToString("HH:mm");
                            if (VarGeneral.CheckDate(dtToString))
                            {
                                ExcelGridView.Rows[i].Cells[textBox_End.Text].Value = dtToString;
                            }
                        }
                        catch
                        {
                        }
                        try
                        {
                            double d = double.Parse(ExcelGridView.Rows[i].Cells[textBox_TimeT1.Text].Value.ToString());
                            string dtToString = DateTime.FromOADate(d).ToString("HH:mm");
                            if (VarGeneral.CheckDate(dtToString))
                            {
                                ExcelGridView.Rows[i].Cells[textBox_TimeT1.Text].Value = dtToString;
                            }
                        }
                        catch
                        {
                        }
                        try
                        {
                            double d = double.Parse(ExcelGridView.Rows[i].Cells[textBox_TimeLeave1.Text].Value.ToString());
                            string dtToString = DateTime.FromOADate(d).ToString("HH:mm");
                            if (VarGeneral.CheckDate(dtToString))
                            {
                                ExcelGridView.Rows[i].Cells[textBox_TimeLeave1.Text].Value = dtToString;
                            }
                        }
                        catch
                        {
                        }
                        attend = db.T_Attends.Where((T_Attend t) => t.EmpID == EmpID && t.Day_No == (int?)xDay).ToList();
                        if (attend.Count <= 0)
                        {
                            continue;
                        }
                        try
                        {
                            db.ExecuteCommand("Delete from T_AttendOperat where EmpID = '" + EmpID + "' and Day <> " + xDay + " and Date = '" + dt.ToString("yyyy/MM/dd") + "'");
                            dbInstance = null;
                        }
                        catch
                        {
                            dbInstance = null;
                        }
                        try
                        {
                            List<T_AttendOperat> q = db.T_AttendOperats.Where((T_AttendOperat t) => t.EmpID == EmpID && t.Day == (int?)xDay && t.Date == dt.ToString("yyyy/MM/dd")).ToList();
                            if (q.Count > 0)
                            {
                                Data_this_AttendOp = q.First();
                                State = FormState.Edit;
                            }
                            else
                            {
                                Data_this_AttendOp = new T_AttendOperat();
                                State = FormState.New;
                                Data_this_AttendOp.Time1 = "";
                                Data_this_AttendOp.Time2 = "";
                                Data_this_AttendOp.LeaveTime = "";
                                Data_this_AttendOp.LeaveTime2 = "";
                                Data_this_AttendOp.LateTime = 0.0;
                            }
                        }
                        catch
                        {
                            Data_this_AttendOp = new T_AttendOperat();
                            State = FormState.New;
                        }
                        Data_this_AttendOp.EmpID = EmpID;
                        Data_this_AttendOp.Date = dt.ToString("yyyy/MM/dd");
                        Data_this_AttendOp.Day = xDay;
                        Data_this_AttendOp.Note = "";
                        if (db.CheckEmpVac(Data_this_AttendOp.EmpID, Data_this_AttendOp.Date))
                        {
                            Data_this_AttendOp.Time1 = "-----";
                            Data_this_AttendOp.Time2 = "-----";
                            Data_this_AttendOp.LeaveTime = "-----";
                            Data_this_AttendOp.LeaveTime2 = "-----";
                            Data_this_AttendOp.Note = "إجازة";
                            Data_this_AttendOp.LateTime = 0.0;
                            Data_this_AttendOp.ComeTime = "";
                            Data_this_AttendOp.Operation = "DONE";
                            goto IL_1dfa;
                        }
                        int? periods = attend.First().Periods;
                        if (periods.Value == 0 && periods.HasValue)
                        {
                            Data_this_AttendOp.ComeTime = "";
                            Data_this_AttendOp.LateTime = 0.0;
                            Data_this_AttendOp.LeaveTime = "-----";
                            Data_this_AttendOp.Time1 = "-----";
                            Data_this_AttendOp.LeaveTime2 = "-----";
                            Data_this_AttendOp.Time2 = "-----";
                            Data_this_AttendOp.Note = "راحة";
                            Data_this_AttendOp.Operation = "DONE";
                            goto IL_1dfa;
                        }
                        if (attend.First().Periods == 1)
                        {
                            if (!(TimeSpan.Parse(ExcelGridView.Rows[i].Cells[textBox_Start.Text].Value.ToString()) == TimeSpan.Parse(attend[0].Time1)) || !(TimeSpan.Parse(ExcelGridView.Rows[i].Cells[textBox_End.Text].Value.ToString()) == TimeSpan.Parse(attend[0].LeaveTime1)))
                            {
                                continue;
                            }
                            Data_this_AttendOp.ComeTime = " " + ExcelGridView.Rows[i].Cells[textBox_TimeT1.Text].Value.ToString();
                            Data_this_AttendOp.Time1 = " " + ExcelGridView.Rows[i].Cells[textBox_TimeT1.Text].Value.ToString();
                            Data_this_AttendOp.LeaveTime = " " + ExcelGridView.Rows[i].Cells[textBox_TimeLeave1.Text].Value.ToString();
                            Data_this_AttendOp.Time2 = "~~~~";
                            Data_this_AttendOp.LeaveTime2 = "~~~~";
                            try
                            {
                                if (VarGeneral.CheckTime(Data_this_AttendOp.LeaveTime))
                                {
                                    Data_this_AttendOp.Operation = "DONE";
                                }
                                else if (VarGeneral.CheckTime(attend.First().LeaveTime1))
                                {
                                    Data_this_AttendOp.LeaveTime = attend.First().LeaveTime1;
                                    Data_this_AttendOp.Operation = "DONE";
                                }
                                else
                                {
                                    Data_this_AttendOp.LeaveTime = "";
                                    Data_this_AttendOp.Operation = "OUT1";
                                }
                            }
                            catch
                            {
                            }
                            if (!VarGeneral.CheckTime(Data_this_AttendOp.Time1))
                            {
                                Data_this_AttendOp.LateTime = 0.0;
                                Data_this_AttendOp.LeaveTime = "xxx";
                                Data_this_AttendOp.Time1 = "xxx";
                                Data_this_AttendOp.LeaveTime2 = "~~~~";
                                Data_this_AttendOp.Time2 = "~~~~";
                                Data_this_AttendOp.Note = "غياب";
                                Data_this_AttendOp.Operation = "DONE";
                            }
                            else
                            {
                                if (VarGeneral.CheckTime(attend.First().LeaveTime1))
                                {
                                }
                                if (VarGeneral.CheckTime(Data_this_AttendOp.LeaveTime))
                                {
                                    Data_this_AttendOp.Operation = "DONE";
                                }
                                else if (VarGeneral.CheckTime(attend.First().LeaveTime1))
                                {
                                    Data_this_AttendOp.LeaveTime = attend.First().LeaveTime1;
                                    Data_this_AttendOp.Operation = "DONE";
                                }
                                else
                                {
                                    Data_this_AttendOp.LeaveTime = "";
                                    Data_this_AttendOp.Operation = "OUT1";
                                }
                                try
                                {
                                    if (VarGeneral.CheckTime(attend.First().TimeAllow1))
                                    {
                                        if (TimeSpan.Parse(Data_this_AttendOp.Time1) > TimeSpan.Parse(attend.First().TimeAllow1))
                                        {
                                            if (VarGeneral.CheckTime(Data_this_AttendOp.Time1) && VarGeneral.CheckTime(attend.First().Time1))
                                            {
                                                Data_this_AttendOp.LateTime = DTime(attend.First().Time1.Trim(), Data_this_AttendOp.Time1.Trim());
                                            }
                                            else
                                            {
                                                Data_this_AttendOp.LateTime = 0.0;
                                            }
                                        }
                                    }
                                    else if (VarGeneral.CheckTime(Data_this_AttendOp.Time1) && VarGeneral.CheckTime(attend.First().Time1))
                                    {
                                        Data_this_AttendOp.LateTime = DTime(attend.First().Time1.Trim(), Data_this_AttendOp.Time1.Trim());
                                    }
                                    else
                                    {
                                        Data_this_AttendOp.LateTime = 0.0;
                                    }
                                }
                                catch
                                {
                                    Data_this_AttendOp.LateTime = 0.0;
                                }
                            }
                            goto IL_1dfa;
                        }
                        if (TimeSpan.Parse(ExcelGridView.Rows[i].Cells[textBox_Start.Text].Value.ToString()) == TimeSpan.Parse(attend[0].Time1) && TimeSpan.Parse(ExcelGridView.Rows[i].Cells[textBox_End.Text].Value.ToString()) == TimeSpan.Parse(attend[0].LeaveTime1))
                        {
                            Data_this_AttendOp.LateTime = 0.0;
                            Data_this_AttendOp.ComeTime = " " + ExcelGridView.Rows[i].Cells[textBox_TimeT1.Text].Value.ToString();
                            Data_this_AttendOp.Time1 = " " + ExcelGridView.Rows[i].Cells[textBox_TimeT1.Text].Value.ToString();
                            Data_this_AttendOp.LeaveTime = " " + ExcelGridView.Rows[i].Cells[textBox_TimeLeave1.Text].Value.ToString();
                            try
                            {
                                if (VarGeneral.CheckTime(Data_this_AttendOp.LeaveTime))
                                {
                                    Data_this_AttendOp.Operation = "IN2";
                                }
                                else if (VarGeneral.CheckTime(attend.First().LeaveTime1))
                                {
                                    Data_this_AttendOp.LeaveTime = attend.First().LeaveTime1;
                                    Data_this_AttendOp.Operation = "IN2";
                                }
                                else
                                {
                                    Data_this_AttendOp.LeaveTime = "";
                                    Data_this_AttendOp.Operation = "OUT1";
                                }
                            }
                            catch
                            {
                            }
                            if (!VarGeneral.CheckTime(Data_this_AttendOp.Time1))
                            {
                                Data_this_AttendOp.LeaveTime = "xxx";
                                Data_this_AttendOp.Time1 = "xxx";
                                Data_this_AttendOp.Operation = "IN2";
                                try
                                {
                                    T_AttendOperat data_this_AttendOp = Data_this_AttendOp;
                                    data_this_AttendOp.LateTime += (double)DTime(attend.First().Time1.Trim(), attend.First().LeaveTime1);
                                }
                                catch
                                {
                                    T_AttendOperat data_this_AttendOp2 = Data_this_AttendOp;
                                    data_this_AttendOp2.LateTime += 0.0;
                                }
                            }
                            else
                            {
                                if (VarGeneral.CheckTime(attend.First().LeaveTime1))
                                {
                                }
                                if (VarGeneral.CheckTime(Data_this_AttendOp.LeaveTime))
                                {
                                    Data_this_AttendOp.Operation = "IN2";
                                }
                                else if (VarGeneral.CheckTime(attend.First().LeaveTime1))
                                {
                                    Data_this_AttendOp.LeaveTime = attend.First().LeaveTime1;
                                    Data_this_AttendOp.Operation = "IN2";
                                }
                                else
                                {
                                    Data_this_AttendOp.LeaveTime = "";
                                    Data_this_AttendOp.Operation = "OUT1";
                                }
                                try
                                {
                                    if (VarGeneral.CheckTime(attend.First().TimeAllow1))
                                    {
                                        if (TimeSpan.Parse(Data_this_AttendOp.Time1) > TimeSpan.Parse(attend.First().TimeAllow1))
                                        {
                                            if (VarGeneral.CheckTime(Data_this_AttendOp.Time1) && VarGeneral.CheckTime(attend.First().Time1))
                                            {
                                                T_AttendOperat data_this_AttendOp3 = Data_this_AttendOp;
                                                data_this_AttendOp3.LateTime += (double)DTime(attend.First().Time1.Trim(), Data_this_AttendOp.Time1.Trim());
                                            }
                                            else
                                            {
                                                T_AttendOperat data_this_AttendOp4 = Data_this_AttendOp;
                                                data_this_AttendOp4.LateTime += 0.0;
                                            }
                                        }
                                    }
                                    else if (VarGeneral.CheckTime(Data_this_AttendOp.Time1) && VarGeneral.CheckTime(attend.First().Time1))
                                    {
                                        T_AttendOperat data_this_AttendOp5 = Data_this_AttendOp;
                                        data_this_AttendOp5.LateTime += (double)DTime(attend.First().Time1.Trim(), Data_this_AttendOp.Time1.Trim());
                                    }
                                    else
                                    {
                                        T_AttendOperat data_this_AttendOp6 = Data_this_AttendOp;
                                        data_this_AttendOp6.LateTime += 0.0;
                                    }
                                }
                                catch
                                {
                                    T_AttendOperat data_this_AttendOp7 = Data_this_AttendOp;
                                    data_this_AttendOp7.LateTime += 0.0;
                                }
                            }
                            goto IL_1dfa;
                        }
                        if (!(TimeSpan.Parse(ExcelGridView.Rows[i].Cells[textBox_Start.Text].Value.ToString()) == TimeSpan.Parse(attend[0].Time2)) || !(TimeSpan.Parse(ExcelGridView.Rows[i].Cells[textBox_End.Text].Value.ToString()) == TimeSpan.Parse(attend[0].LeaveTime2)))
                        {
                            continue;
                        }
                        try
                        {
                            T_AttendOperat data_this_AttendOp8 = Data_this_AttendOp;
                            data_this_AttendOp8.LateTime += 0.0;
                        }
                        catch
                        {
                            T_AttendOperat data_this_AttendOp9 = Data_this_AttendOp;
                            data_this_AttendOp9.LateTime += 0.0;
                        }
                        Data_this_AttendOp.Time2 = " " + ExcelGridView.Rows[i].Cells[textBox_TimeT1.Text].Value.ToString();
                        Data_this_AttendOp.LeaveTime2 = " " + ExcelGridView.Rows[i].Cells[textBox_TimeLeave1.Text].Value.ToString();
                        try
                        {
                            if (VarGeneral.CheckTime(Data_this_AttendOp.LeaveTime2))
                            {
                                Data_this_AttendOp.Operation = "DONE";
                            }
                            else if (VarGeneral.CheckTime(attend.First().LeaveTime2))
                            {
                                Data_this_AttendOp.LeaveTime2 = attend.First().LeaveTime2;
                                Data_this_AttendOp.Operation = "DONE";
                            }
                            else
                            {
                                Data_this_AttendOp.LeaveTime2 = "";
                                Data_this_AttendOp.Operation = "OUT2";
                            }
                        }
                        catch
                        {
                        }
                        if (!VarGeneral.CheckTime(Data_this_AttendOp.Time2))
                        {
                            Data_this_AttendOp.LeaveTime2 = "xxx";
                            Data_this_AttendOp.Time2 = "xxx";
                            Data_this_AttendOp.Operation = "DONE";
                            try
                            {
                                T_AttendOperat data_this_AttendOp10 = Data_this_AttendOp;
                                data_this_AttendOp10.LateTime += (double)DTime(attend.First().Time2.Trim(), attend.First().LeaveTime2);
                            }
                            catch
                            {
                                T_AttendOperat data_this_AttendOp11 = Data_this_AttendOp;
                                data_this_AttendOp11.LateTime += 0.0;
                            }
                        }
                        else
                        {
                            if (VarGeneral.CheckTime(attend.First().LeaveTime2))
                            {
                            }
                            if (VarGeneral.CheckTime(Data_this_AttendOp.LeaveTime2))
                            {
                                Data_this_AttendOp.Operation = "DONE";
                            }
                            else if (VarGeneral.CheckTime(attend.First().LeaveTime2))
                            {
                                Data_this_AttendOp.LeaveTime2 = attend.First().LeaveTime2;
                                Data_this_AttendOp.Operation = "DONE";
                            }
                            else
                            {
                                Data_this_AttendOp.LeaveTime2 = "";
                                Data_this_AttendOp.Operation = "OUT2";
                            }
                            try
                            {
                                if (VarGeneral.CheckTime(attend.First().TimeAllow1))
                                {
                                    if (TimeSpan.Parse(Data_this_AttendOp.Time2) > TimeSpan.Parse(attend.First().TimeAlow2))
                                    {
                                        if (VarGeneral.CheckTime(Data_this_AttendOp.Time2) && VarGeneral.CheckTime(attend.First().Time2))
                                        {
                                            T_AttendOperat data_this_AttendOp12 = Data_this_AttendOp;
                                            data_this_AttendOp12.LateTime += (double)DTime(attend.First().Time2.Trim(), Data_this_AttendOp.Time2.Trim());
                                        }
                                        else
                                        {
                                            T_AttendOperat data_this_AttendOp13 = Data_this_AttendOp;
                                            data_this_AttendOp13.LateTime += 0.0;
                                        }
                                    }
                                }
                                else if (VarGeneral.CheckTime(Data_this_AttendOp.Time2) && VarGeneral.CheckTime(attend.First().Time2))
                                {
                                    T_AttendOperat data_this_AttendOp14 = Data_this_AttendOp;
                                    data_this_AttendOp14.LateTime += (double)DTime(attend.First().Time2.Trim(), Data_this_AttendOp.Time2.Trim());
                                }
                                else
                                {
                                    T_AttendOperat data_this_AttendOp15 = Data_this_AttendOp;
                                    data_this_AttendOp15.LateTime += 0.0;
                                }
                            }
                            catch
                            {
                                T_AttendOperat data_this_AttendOp16 = Data_this_AttendOp;
                                data_this_AttendOp16.LateTime += 0.0;
                            }
                        }
                        goto IL_1dfa;
                    IL_1dfa:
                        if (State == FormState.New)
                        {
                            Guid id = Guid.NewGuid();
                            Datathis_AttendOp.AttendOperat_ID = id.ToString();
                            db.T_AttendOperats.InsertOnSubmit(Data_this_AttendOp);
                            db.SubmitChanges();
                        }
                        else
                        {
                            db.Log = VarGeneral.DebugLog;
                            db.SubmitChanges(ConflictMode.ContinueOnConflict);
                        }
                        try
                        {
                            ExcelGridView.Rows.RemoveAt(i);
                            i = 0;
                        }
                        catch
                        {
                        }
                        vLoop = true;
                    }
                    catch
                    {
                    }
                }
                MessageBox.Show((LangArEn == 0) ? "تم سحب بيانات دوام الموظفين بنجاح " : "Data were imported attendance successfully", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                GridStyle();
                State = FormState.Saved;
                SetReadOnly = true;
                ExcelGridView_DataBindingComplete(null, null);
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("button_OK_Click:", error, enable: true);
                MessageBox.Show(error.Message);
                GridStyle();
                State = FormState.Saved;
                SetReadOnly = true;
            }
        }
        private int DTime(string BTime, string Etime)
        {
            try
            {
                if (string.IsNullOrEmpty(BTime) || string.IsNullOrEmpty(Etime))
                {
                    return 0;
                }
                if (!VarGeneral.CheckDate(BTime) || !VarGeneral.CheckDate(Etime))
                {
                    return 0;
                }
                int LAmount = 0;
                if (TimeSpan.Parse(Etime) > TimeSpan.Parse(BTime))
                {
                    LAmount = int.Parse(Etime.Substring(3, 2)) - int.Parse(BTime.Substring(3, 2));
                    LAmount += 60 * (int.Parse(Etime.Substring(0, 2)) - int.Parse(BTime.Substring(0, 2)));
                }
                return LAmount;
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("DTime:", error, enable: true);
                MessageBox.Show(error.Message);
                return 0;
            }
        }
        private void releaseObject(object obj)
        {
            try
            {
                Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Unable to release the Object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }
        private void ExcelGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                if (ExcelGridView.Rows.Count <= 0)
                {
                    ButImportFile.Enabled = false;
                }
                else
                {
                    ButImportFile.Enabled = true;
                }
            }
            catch
            {
                ButImportFile.Enabled = true;
            }
        }
        private void textBox_DateMenual_Leave(object sender, EventArgs e)
        {
            try
            {
                if (VarGeneral.CheckDate(textBox_DateMenual.Text))
                {
                    textBox_DateMenual.Text = Convert.ToDateTime(textBox_DateMenual.Text).ToString("yyyy/MM/dd");
                }
                else
                {
                    int? calendr = VarGeneral.Settings_Sys.Calendr;
                    if (calendr.Value == 0 && calendr.HasValue)
                    {
                        textBox_DateMenual.Text = VarGeneral.Gdate;
                    }
                    else
                    {
                        textBox_DateMenual.Text = VarGeneral.Hdate;
                    }
                }
            }
            catch
            {
                int? calendr = VarGeneral.Settings_Sys.Calendr;
                if (calendr.Value == 0 && calendr.HasValue)
                {
                    textBox_DateMenual.Text = VarGeneral.Gdate;
                }
                else
                {
                    textBox_DateMenual.Text = VarGeneral.Hdate;
                }
                return;
            }
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                textBox_DayMenual.Text = n.GetDayH2(textBox_DateMenual.Text);
            }
            else
            {
                textBox_DayMenual.Text = n.GetDayG2(textBox_DateMenual.Text);
            }
            VarGeneral.Day_No = n.GetDayNo(textBox_DateMenual.Text) + 1;
            textBox_DayMenual.Tag = VarGeneral.Day_No;
        }
        private void textBox_DateMenual_Click(object sender, EventArgs e)
        {
            textBox_DateMenual.SelectAll();
        }
        public void SetDataMenual(T_Emp value)
        {
            Update_AttendMenual = new BindingList<T_Attend>(value.T_Attends);
        }
        private int DTimeMenual(string BTime, string Etime)
        {
            try
            {
                if (string.IsNullOrEmpty(BTime) || string.IsNullOrEmpty(Etime))
                {
                    return 0;
                }
                if (!VarGeneral.CheckDate(BTime) || !VarGeneral.CheckDate(Etime))
                {
                    return 0;
                }
                int LAmount = 0;
                if (TimeSpan.Parse(Etime) > TimeSpan.Parse(BTime))
                {
                    LAmount = int.Parse(Etime.Substring(3, 2)) - int.Parse(BTime.Substring(3, 2));
                    LAmount += 60 * (int.Parse(Etime.Substring(0, 2)) - int.Parse(BTime.Substring(0, 2)));
                }
                return LAmount;
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("DTimeMenual:", error, enable: true);
                MessageBox.Show(error.Message);
                return 0;
            }
        }
        private void SaveMenual(bool value)
        {
            string tmpStr = "";
            string QStr = "";
            string[] GetSql = getDeptNo();
            for (int num2 = 0; num2 < GetSql.Length; num2++)
            {
                if (!string.IsNullOrEmpty(GetSql[num2]))
                {
                    tmpStr = ((!string.IsNullOrEmpty(tmpStr)) ? (tmpStr + " OR ") : (tmpStr + " AND ( "));
                    tmpStr = tmpStr + " ( Dept = " + GetSql[num2].Trim() + " ) ";
                }
            }
            QStr += ((tmpStr != "") ? (tmpStr + " )") : "");
            tmpStr = "";
            GetSql = getEmpNo();
            for (int num2 = 0; num2 < GetSql.Length; num2++)
            {
                if (!string.IsNullOrEmpty(GetSql[num2]))
                {
                    tmpStr = ((!string.IsNullOrEmpty(tmpStr)) ? (tmpStr + " OR ") : (tmpStr + " AND ( "));
                    tmpStr = tmpStr + " ( Emp_ID = '" + GetSql[num2].Trim() + "' ) ";
                }
            }
            QStr += ((tmpStr != "") ? (tmpStr + " )") : "");
            tmpStr = "";
            GetSql = getSectionNo();
            for (int num2 = 0; num2 < GetSql.Length; num2++)
            {
                if (!string.IsNullOrEmpty(GetSql[num2]))
                {
                    tmpStr = ((!string.IsNullOrEmpty(tmpStr)) ? (tmpStr + " OR ") : (tmpStr + " AND ( "));
                    tmpStr = tmpStr + " ( Section = " + GetSql[num2].Trim() + " ) ";
                }
            }
            QStr += ((tmpStr != "") ? (tmpStr + " )") : "");
            tmpStr = "";
            string EmpID = "";
            int xDay = 0;
            List<int> iRows = new List<int>();
            List<T_Attend> attend = new List<T_Attend>();
            bool vLoop = false;
            DateTime dt;
            for (int i = 0; i < pkeys.Count; i++)
            {
                string query = "SELECT * FROM [dbo].[T_Emp] as [t0] WHERE EmpState = " + 1 + " AND Emp_No = " + pkeys[i] + QStr + " ORDER BY [Emp_No]";
                try
                {
                    T_Emp newData = db.ExecuteQuery<T_Emp>(query, new object[0]).First();
                    if (newData == null && !(newData.Emp_No != ""))
                    {
                        continue;
                    }
                    DataThisMenual = newData;
                    EmpID = newData.Emp_ID;
                    xDay = int.Parse(textBox_DayMenual.Tag.ToString());
                    dt = Convert.ToDateTime(textBox_DateMenual.Text, CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);
                    attend = db.T_Attends.Where((T_Attend t) => t.EmpID == EmpID && t.Day_No == (int?)xDay).ToList();
                    if (attend.Count <= 0)
                    {
                        continue;
                    }
                    try
                    {
                        db.ExecuteCommand("Delete from T_AttendOperat where EmpID = '" + EmpID + "' and Day <> " + xDay + " and Date = '" + dt.ToString("yyyy/MM/dd") + "'");
                        dbInstance = null;
                    }
                    catch
                    {
                        dbInstance = null;
                    }
                    try
                    {
                        List<T_AttendOperat> q = db.T_AttendOperats.Where((T_AttendOperat t) => t.EmpID == EmpID && t.Day == (int?)xDay && t.Date == dt.ToString("yyyy/MM/dd")).ToList();
                        if (q.Count > 0)
                        {
                            Data_this_AttendOpMenual = q.First();
                            State = FormState.Edit;
                        }
                        else
                        {
                            Data_this_AttendOpMenual = new T_AttendOperat();
                            State = FormState.New;
                            Data_this_AttendOpMenual.Time1 = "";
                            Data_this_AttendOpMenual.Time2 = "";
                            Data_this_AttendOpMenual.LeaveTime = "";
                            Data_this_AttendOpMenual.LeaveTime2 = "";
                            Data_this_AttendOpMenual.LateTime = 0.0;
                        }
                    }
                    catch
                    {
                        Data_this_AttendOpMenual = new T_AttendOperat();
                        State = FormState.New;
                    }
                    Data_this_AttendOpMenual.EmpID = EmpID;
                    Data_this_AttendOpMenual.Date = $"{dt.Year:0000}" + "/" + $"{dt.Month:00}" + "/" + $"{dt.Day:00}";
                    Data_this_AttendOpMenual.Day = xDay;
                    Data_this_AttendOpMenual.Note = "";
                    if (db.CheckEmpVac(Data_this_AttendOpMenual.EmpID, Data_this_AttendOpMenual.Date))
                    {
                        Data_this_AttendOpMenual.Time1 = "-----";
                        Data_this_AttendOpMenual.Time2 = "-----";
                        Data_this_AttendOpMenual.LeaveTime = "-----";
                        Data_this_AttendOpMenual.LeaveTime2 = "-----";
                        Data_this_AttendOpMenual.Note = "إجازة";
                        Data_this_AttendOpMenual.LateTime = 0.0;
                        Data_this_AttendOpMenual.ComeTime = "";
                        Data_this_AttendOpMenual.Operation = "DONE";
                        goto IL_1b6b;
                    }
                    int? periods = attend.First().Periods;
                    if (periods.Value == 0 && periods.HasValue)
                    {
                        Data_this_AttendOpMenual.ComeTime = "";
                        Data_this_AttendOpMenual.LateTime = 0.0;
                        Data_this_AttendOpMenual.LeaveTime = "-----";
                        Data_this_AttendOpMenual.Time1 = "-----";
                        Data_this_AttendOpMenual.LeaveTime2 = "-----";
                        Data_this_AttendOpMenual.Time2 = "-----";
                        Data_this_AttendOpMenual.Note = "راحة";
                        Data_this_AttendOpMenual.Operation = "DONE";
                        goto IL_1b6b;
                    }
                    if (attend.First().Periods == 1)
                    {
                        if (!radioButton_PeriodsMenual1.Checked)
                        {
                            continue;
                        }
                        Data_this_AttendOpMenual.ComeTime = textBox_ComeTimeMenual.Text;
                        Data_this_AttendOpMenual.Time1 = textBox_ComeTimeMenual.Text;
                        Data_this_AttendOpMenual.LeaveTime = (VarGeneral.CheckTime(textBox_TimeLeaveMenual1.Text) ? textBox_TimeLeaveMenual1.Text : Data_this_AttendMenual.LeaveTime1);
                        Data_this_AttendOpMenual.Time2 = "~~~~";
                        Data_this_AttendOpMenual.LeaveTime2 = "~~~~";
                        try
                        {
                            if (VarGeneral.CheckTime(Data_this_AttendOpMenual.LeaveTime))
                            {
                                Data_this_AttendOpMenual.Operation = "DONE";
                            }
                            else if (VarGeneral.CheckTime(attend.First().LeaveTime1))
                            {
                                Data_this_AttendOpMenual.LeaveTime = attend.First().LeaveTime1;
                                Data_this_AttendOpMenual.Operation = "DONE";
                            }
                            else
                            {
                                Data_this_AttendOpMenual.LeaveTime = "";
                                Data_this_AttendOpMenual.Operation = "OUT1";
                            }
                        }
                        catch
                        {
                        }
                        if (!VarGeneral.CheckTime(Data_this_AttendOpMenual.Time1))
                        {
                            Data_this_AttendOpMenual.LateTime = 0.0;
                            Data_this_AttendOpMenual.LeaveTime = "xxx";
                            Data_this_AttendOpMenual.Time1 = "xxx";
                            Data_this_AttendOpMenual.LeaveTime2 = "~~~~";
                            Data_this_AttendOpMenual.Time2 = "~~~~";
                            Data_this_AttendOpMenual.Note = "غياب";
                            Data_this_AttendOpMenual.Operation = "DONE";
                        }
                        else if (VarGeneral.CheckTime(attend.First().LeaveTime1) && TimeSpan.Parse(Data_this_AttendOpMenual.Time1) > TimeSpan.Parse(attend.First().LeaveTime1))
                        {
                            Data_this_AttendOpMenual.LateTime = 0.0;
                            Data_this_AttendOpMenual.LeaveTime = "xxx";
                            Data_this_AttendOpMenual.Time1 = "xxx";
                            Data_this_AttendOpMenual.LeaveTime2 = "~~~~";
                            Data_this_AttendOpMenual.Time2 = "~~~~";
                            Data_this_AttendOpMenual.Note = "غياب";
                            Data_this_AttendOpMenual.Operation = "DONE";
                        }
                        else
                        {
                            if (VarGeneral.CheckTime(Data_this_AttendOpMenual.LeaveTime))
                            {
                                Data_this_AttendOpMenual.Operation = "DONE";
                            }
                            else if (VarGeneral.CheckTime(attend.First().LeaveTime1))
                            {
                                Data_this_AttendOpMenual.LeaveTime = attend.First().LeaveTime1;
                                Data_this_AttendOpMenual.Operation = "DONE";
                            }
                            else
                            {
                                Data_this_AttendOpMenual.LeaveTime = "";
                                Data_this_AttendOpMenual.Operation = "OUT1";
                            }
                            try
                            {
                                if (VarGeneral.CheckTime(attend.First().TimeAllow1))
                                {
                                    if (TimeSpan.Parse(Data_this_AttendOpMenual.Time1) > TimeSpan.Parse(attend.First().TimeAllow1))
                                    {
                                        if (VarGeneral.CheckTime(Data_this_AttendOpMenual.Time1) && VarGeneral.CheckTime(attend.First().Time1))
                                        {
                                            Data_this_AttendOpMenual.LateTime = DTimeMenual(attend.First().Time1.Trim(), Data_this_AttendOpMenual.Time1.Trim());
                                        }
                                        else
                                        {
                                            Data_this_AttendOpMenual.LateTime = 0.0;
                                        }
                                    }
                                }
                                else if (VarGeneral.CheckTime(Data_this_AttendOpMenual.Time1) && VarGeneral.CheckTime(attend.First().Time1))
                                {
                                    Data_this_AttendOpMenual.LateTime = DTimeMenual(attend.First().Time1.Trim(), Data_this_AttendOpMenual.Time1.Trim());
                                }
                                else
                                {
                                    Data_this_AttendOpMenual.LateTime = 0.0;
                                }
                            }
                            catch
                            {
                                Data_this_AttendOpMenual.LateTime = 0.0;
                            }
                        }
                        goto IL_1b6b;
                    }
                    if (radioButton_PeriodsMenual1.Checked)
                    {
                        Data_this_AttendOpMenual.LateTime = 0.0;
                        Data_this_AttendOpMenual.ComeTime = textBox_ComeTimeMenual.Text;
                        Data_this_AttendOpMenual.Time1 = textBox_ComeTimeMenual.Text;
                        Data_this_AttendOpMenual.LeaveTime = (VarGeneral.CheckTime(textBox_TimeLeaveMenual1.Text) ? textBox_TimeLeaveMenual1.Text : Data_this_AttendMenual.LeaveTime1);
                        try
                        {
                            if (VarGeneral.CheckTime(Data_this_AttendOpMenual.LeaveTime))
                            {
                                Data_this_AttendOpMenual.Operation = "IN2";
                            }
                            else if (VarGeneral.CheckTime(attend.First().LeaveTime1))
                            {
                                Data_this_AttendOpMenual.LeaveTime = attend.First().LeaveTime1;
                                Data_this_AttendOpMenual.Operation = "IN2";
                            }
                            else
                            {
                                Data_this_AttendOpMenual.LeaveTime = "";
                                Data_this_AttendOpMenual.Operation = "OUT1";
                            }
                        }
                        catch
                        {
                        }
                        if (!VarGeneral.CheckTime(Data_this_AttendOpMenual.Time1))
                        {
                            Data_this_AttendOpMenual.LeaveTime = "xxx";
                            Data_this_AttendOpMenual.Time1 = "xxx";
                            Data_this_AttendOpMenual.Operation = "IN2";
                            try
                            {
                                T_AttendOperat data_this_AttendOpMenual = Data_this_AttendOpMenual;
                                data_this_AttendOpMenual.LateTime += (double)DTimeMenual(attend.First().Time1.Trim(), attend.First().LeaveTime1);
                            }
                            catch
                            {
                                T_AttendOperat data_this_AttendOpMenual2 = Data_this_AttendOpMenual;
                                data_this_AttendOpMenual2.LateTime += 0.0;
                            }
                        }
                        else if (VarGeneral.CheckTime(attend.First().LeaveTime1) && TimeSpan.Parse(Data_this_AttendOpMenual.Time1) > TimeSpan.Parse(attend.First().LeaveTime1))
                        {
                            Data_this_AttendOpMenual.LeaveTime = "xxx";
                            Data_this_AttendOpMenual.Time1 = "xxx";
                            Data_this_AttendOpMenual.Operation = "IN2";
                            try
                            {
                                T_AttendOperat data_this_AttendOpMenual3 = Data_this_AttendOpMenual;
                                data_this_AttendOpMenual3.LateTime += (double)DTimeMenual(attend.First().Time1.Trim(), attend.First().LeaveTime1);
                            }
                            catch
                            {
                                T_AttendOperat data_this_AttendOpMenual4 = Data_this_AttendOpMenual;
                                data_this_AttendOpMenual4.LateTime += 0.0;
                            }
                        }
                        else
                        {
                            if (VarGeneral.CheckTime(Data_this_AttendOpMenual.LeaveTime))
                            {
                                Data_this_AttendOpMenual.Operation = "IN2";
                            }
                            else if (VarGeneral.CheckTime(attend.First().LeaveTime1))
                            {
                                Data_this_AttendOpMenual.LeaveTime = attend.First().LeaveTime1;
                                Data_this_AttendOpMenual.Operation = "IN2";
                            }
                            else
                            {
                                Data_this_AttendOpMenual.LeaveTime = "";
                                Data_this_AttendOpMenual.Operation = "OUT1";
                            }
                            try
                            {
                                if (VarGeneral.CheckTime(attend.First().TimeAllow1))
                                {
                                    if (TimeSpan.Parse(Data_this_AttendOpMenual.Time1) > TimeSpan.Parse(attend.First().TimeAllow1))
                                    {
                                        if (VarGeneral.CheckTime(Data_this_AttendOpMenual.Time1) && VarGeneral.CheckTime(attend.First().Time1))
                                        {
                                            T_AttendOperat data_this_AttendOpMenual5 = Data_this_AttendOpMenual;
                                            data_this_AttendOpMenual5.LateTime += (double)DTimeMenual(attend.First().Time1.Trim(), Data_this_AttendOpMenual.Time1.Trim());
                                        }
                                        else
                                        {
                                            T_AttendOperat data_this_AttendOpMenual6 = Data_this_AttendOpMenual;
                                            data_this_AttendOpMenual6.LateTime += 0.0;
                                        }
                                    }
                                }
                                else if (VarGeneral.CheckTime(Data_this_AttendOpMenual.Time1) && VarGeneral.CheckTime(attend.First().Time1))
                                {
                                    T_AttendOperat data_this_AttendOpMenual7 = Data_this_AttendOpMenual;
                                    data_this_AttendOpMenual7.LateTime += (double)DTimeMenual(attend.First().Time1.Trim(), Data_this_AttendOpMenual.Time1.Trim());
                                }
                                else
                                {
                                    T_AttendOperat data_this_AttendOpMenual8 = Data_this_AttendOpMenual;
                                    data_this_AttendOpMenual8.LateTime += 0.0;
                                }
                            }
                            catch
                            {
                                T_AttendOperat data_this_AttendOpMenual9 = Data_this_AttendOpMenual;
                                data_this_AttendOpMenual9.LateTime += 0.0;
                            }
                        }
                        goto IL_1b6b;
                    }
                    if (!radioButton_PeriodsMenual2.Checked)
                    {
                        continue;
                    }
                    if (!VarGeneral.CheckTime(Data_this_AttendOpMenual.Time1))
                    {
                        Data_this_AttendOpMenual.LateTime = 0.0;
                        Data_this_AttendOpMenual.LeaveTime = "xxx";
                        Data_this_AttendOpMenual.Time1 = "xxx";
                        Data_this_AttendOpMenual.LeaveTime2 = "xxx";
                        Data_this_AttendOpMenual.Time2 = "xxx";
                        Data_this_AttendOpMenual.Note = "غياب";
                        Data_this_AttendOpMenual.Operation = "DONE";
                    }
                    else
                    {
                        try
                        {
                            T_AttendOperat data_this_AttendOpMenual10 = Data_this_AttendOpMenual;
                            data_this_AttendOpMenual10.LateTime += 0.0;
                        }
                        catch
                        {
                            T_AttendOperat data_this_AttendOpMenual11 = Data_this_AttendOpMenual;
                            data_this_AttendOpMenual11.LateTime += 0.0;
                        }
                        Data_this_AttendOpMenual.Time2 = textBox_ComeTimeMenual.Text;
                        Data_this_AttendOpMenual.LeaveTime2 = (VarGeneral.CheckTime(textBox_TimeLeaveMenual1.Text) ? textBox_TimeLeaveMenual1.Text : Data_this_AttendMenual.LeaveTime2);
                        try
                        {
                            if (VarGeneral.CheckTime(Data_this_AttendOpMenual.LeaveTime2))
                            {
                                Data_this_AttendOpMenual.Operation = "DONE";
                            }
                            else if (VarGeneral.CheckTime(attend.First().LeaveTime2))
                            {
                                Data_this_AttendOpMenual.LeaveTime2 = attend.First().LeaveTime2;
                                Data_this_AttendOpMenual.Operation = "DONE";
                            }
                            else
                            {
                                Data_this_AttendOpMenual.LeaveTime2 = "";
                                Data_this_AttendOpMenual.Operation = "OUT2";
                            }
                        }
                        catch
                        {
                        }
                        if (!VarGeneral.CheckTime(Data_this_AttendOpMenual.Time2))
                        {
                            Data_this_AttendOpMenual.LeaveTime2 = "xxx";
                            Data_this_AttendOpMenual.Time2 = "xxx";
                            Data_this_AttendOpMenual.Operation = "DONE";
                            try
                            {
                                T_AttendOperat data_this_AttendOpMenual12 = Data_this_AttendOpMenual;
                                data_this_AttendOpMenual12.LateTime += (double)DTimeMenual(attend.First().Time2.Trim(), attend.First().LeaveTime2);
                            }
                            catch
                            {
                                T_AttendOperat data_this_AttendOpMenual13 = Data_this_AttendOpMenual;
                                data_this_AttendOpMenual13.LateTime += 0.0;
                            }
                        }
                        else
                        {
                            if (VarGeneral.CheckTime(attend.First().LeaveTime2) && TimeSpan.Parse(Data_this_AttendOpMenual.Time2) > TimeSpan.Parse(attend.First().LeaveTime2))
                            {
                                Data_this_AttendOpMenual.LeaveTime2 = "xxx";
                                Data_this_AttendOpMenual.Time2 = "xxx";
                                Data_this_AttendOpMenual.Operation = "DONE";
                                try
                                {
                                    T_AttendOperat data_this_AttendOpMenual14 = Data_this_AttendOpMenual;
                                    data_this_AttendOpMenual14.LateTime += (double)DTimeMenual(attend.First().Time2.Trim(), attend.First().LeaveTime2);
                                }
                                catch
                                {
                                    T_AttendOperat data_this_AttendOpMenual15 = Data_this_AttendOpMenual;
                                    data_this_AttendOpMenual15.LateTime += 0.0;
                                }
                            }
                            if (VarGeneral.CheckTime(Data_this_AttendOpMenual.LeaveTime2))
                            {
                                Data_this_AttendOpMenual.Operation = "DONE";
                            }
                            else if (VarGeneral.CheckTime(attend.First().LeaveTime2))
                            {
                                Data_this_AttendOpMenual.LeaveTime2 = attend.First().LeaveTime2;
                                Data_this_AttendOpMenual.Operation = "DONE";
                            }
                            else
                            {
                                Data_this_AttendOpMenual.LeaveTime2 = "";
                                Data_this_AttendOpMenual.Operation = "OUT2";
                            }
                            try
                            {
                                if (VarGeneral.CheckTime(attend.First().TimeAllow1))
                                {
                                    if (TimeSpan.Parse(Data_this_AttendOpMenual.Time2) > TimeSpan.Parse(attend.First().TimeAlow2))
                                    {
                                        if (VarGeneral.CheckTime(Data_this_AttendOpMenual.Time2) && VarGeneral.CheckTime(attend.First().Time2))
                                        {
                                            T_AttendOperat data_this_AttendOpMenual16 = Data_this_AttendOpMenual;
                                            data_this_AttendOpMenual16.LateTime += (double)DTimeMenual(attend.First().Time2.Trim(), Data_this_AttendOpMenual.Time2.Trim());
                                        }
                                        else
                                        {
                                            T_AttendOperat data_this_AttendOpMenual17 = Data_this_AttendOpMenual;
                                            data_this_AttendOpMenual17.LateTime += 0.0;
                                        }
                                    }
                                }
                                else if (VarGeneral.CheckTime(Data_this_AttendOpMenual.Time2) && VarGeneral.CheckTime(attend.First().Time2))
                                {
                                    T_AttendOperat data_this_AttendOpMenual18 = Data_this_AttendOpMenual;
                                    data_this_AttendOpMenual18.LateTime += (double)DTimeMenual(attend.First().Time2.Trim(), Data_this_AttendOpMenual.Time2.Trim());
                                }
                                else
                                {
                                    T_AttendOperat data_this_AttendOpMenual19 = Data_this_AttendOpMenual;
                                    data_this_AttendOpMenual19.LateTime += 0.0;
                                }
                            }
                            catch
                            {
                                T_AttendOperat data_this_AttendOpMenual20 = Data_this_AttendOpMenual;
                                data_this_AttendOpMenual20.LateTime += 0.0;
                            }
                        }
                    }
                    goto IL_1b6b;
                IL_1b6b:
                    if (State == FormState.New)
                    {
                        Guid id = Guid.NewGuid();
                        Datathis_AttendOpMenual.AttendOperat_ID = id.ToString();
                        try
                        {
                            if (comboBox_PRojectMenual.SelectedIndex > 0)
                            {
                                Data_this_AttendOpMenual.ProjectNo = int.Parse(comboBox_PRojectMenual.SelectedValue.ToString());
                            }
                            else
                            {
                                Data_this_AttendOpMenual.ProjectNo = null;
                            }
                        }
                        catch
                        {
                            Data_this_AttendOpMenual.ProjectNo = null;
                        }
                        db.T_AttendOperats.InsertOnSubmit(Data_this_AttendOpMenual);
                        db.SubmitChanges();
                    }
                    else
                    {
                        try
                        {
                            if (comboBox_PRojectMenual.SelectedIndex > 0)
                            {
                                Data_this_AttendOpMenual.ProjectNo = int.Parse(comboBox_PRojectMenual.SelectedValue.ToString());
                            }
                            else
                            {
                                Data_this_AttendOpMenual.ProjectNo = null;
                            }
                        }
                        catch
                        {
                            Data_this_AttendOpMenual.ProjectNo = null;
                        }
                        db.Log = VarGeneral.DebugLog;
                        db.SubmitChanges(ConflictMode.ContinueOnConflict);
                    }
                    vLoop = true;
                }
                catch
                {
                }
            }
        }
        private void textBox_DayMenual_TextChanged(object sender, EventArgs e)
        {
            UpdateDays();
        }
        private void textBox_ComeTimeMenual_Leave(object sender, EventArgs e)
        {
            if (VarGeneral.CheckTime(textBox_ComeTimeMenual.Text))
            {
                textBox_ComeTimeMenual.Text = TimeSpan.Parse(textBox_ComeTimeMenual.Text).ToString();
            }
            else
            {
                textBox_ComeTimeMenual.Text = "";
            }
        }
        private void textBox_ComeTimeMenual_Click(object sender, EventArgs e)
        {
            textBox_ComeTimeMenual.SelectAll();
        }
        private void textBox_TimeLeaveMenual1_Click(object sender, EventArgs e)
        {
            textBox_TimeLeaveMenual1.SelectAll();
        }
        private void textBox_TimeLeaveMenual1_Leave(object sender, EventArgs e)
        {
            if (VarGeneral.CheckTime(textBox_TimeLeaveMenual1.Text))
            {
                textBox_TimeLeaveMenual1.Text = TimeSpan.Parse(textBox_TimeLeaveMenual1.Text).ToString();
            }
            else
            {
                textBox_TimeLeaveMenual1.Text = "";
            }
        }
        public void FillComboMenual()
        {
            List<T_Project> listSection = new List<T_Project>(db.T_Projects.Select((T_Project item) => item).ToList());
            comboBox_PRojectMenual.DataSource = null;
            listSection.Insert(0, new T_Project());
            comboBox_PRojectMenual.DataSource = listSection;
            comboBox_PRojectMenual.DisplayMember = ((LangArEn == 0) ? "NameA" : "NameE");
            comboBox_PRojectMenual.ValueMember = "Project_No";
        }
        private void button_ADDPRojectMenual_Click(object sender, EventArgs e)
        {
            FrmPRoject frm = new FrmPRoject();
            frm.Tag = LangArEn;
            string vList = "";
            if (comboBox_PRojectMenual.SelectedIndex != -1)
            {
                vList = comboBox_PRojectMenual.SelectedValue.ToString();
            }
            frm.TopMost = true;
            frm.ShowDialog();
            Stock_DataDataContext dbc = new Stock_DataDataContext(VarGeneral.BranchCS);
            List<T_Project> list = new List<T_Project>(dbc.T_Projects.Select((T_Project item) => item).ToList());
            comboBox_PRojectMenual.DataSource = null;
            list.Insert(0, new T_Project());
            comboBox_PRojectMenual.DataSource = list;
            comboBox_PRojectMenual.DisplayMember = ((LangArEn == 0) ? "NameA" : "NameE");
            comboBox_PRojectMenual.ValueMember = "Project_No";
            if (vList != "")
            {
                for (int i = 0; i < comboBox_PRojectMenual.Items.Count; i++)
                {
                    comboBox_PRojectMenual.SelectedIndex = i;
                    if (comboBox_PRojectMenual.SelectedValue.ToString() == vList)
                    {
                        break;
                    }
                }
            }
            else
            {
                comboBox_PRojectMenual.SelectedIndex = -1;
            }
        }
        private void button_SrchPRojectMenual_Click(object sender, EventArgs e)
        {
            try
            {
                Dir_ButSearch.Add("Project_No", new ColumnDictinary("رقم المشروع", "Project No", ifDefault: true, ""));
                Dir_ButSearch.Add("NameA", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, ""));
                Dir_ButSearch.Add("NameE", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: false, ""));
                Dir_ButSearch.Add("Note", new ColumnDictinary("الملاحظات", "Note", ifDefault: true, ""));
                FrmSearch frm = new FrmSearch();
                frm.Tag = LangArEn;
                ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = Dir_ButSearch;
                foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
                {
                    frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, ""));
                }
                VarGeneral.SFrmTyp = "T_Project";
                frm.TopMost = true;
                frm.ShowDialog();
                if (frm.SerachNo != "")
                {
                    comboBox_PRojectMenual.SelectedValue = int.Parse(frm.SerachNo);
                }
                Dir_ButSearch.Clear();
            }
            catch
            {
            }
        }
        private void ButSaveMenual_Click(object sender, EventArgs e)
        {
            try
            {
                if (!VarGeneral.CheckTime(textBox_ComeTimeMenual.Text))
                {
                    MessageBox.Show((LangArEn == 0) ? "تأكد من صحة وقت الحضور" : "Must insert Time ?", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    textBox_ComeTimeMenual.Focus();
                    return;
                }
                if (!VarGeneral.CheckTime(textBox_TimeLeaveMenual1.Text))
                {
                    MessageBox.Show((LangArEn == 0) ? "تأكد من صحة وقت الإنصراف" : "Must insert Time ?", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    textBox_TimeLeaveMenual1.Focus();
                    return;
                }
                if (!VarGeneral.CheckDate(textBox_DateMenual.Text))
                {
                    MessageBox.Show((LangArEn == 0) ? "تأكد من صحة التاريخ" : "Must insert Date ?", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    textBox_DateMenual.Focus();
                    return;
                }
                if (!radioButton_PeriodsMenual1.Checked && !radioButton_PeriodsMenual2.Checked)
                {
                    MessageBox.Show((LangArEn == 0) ? "يجب تحديد الفترة قبل القيام بعملية الحفظ" : "Must select Time one or Time tow ?", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    textBox_DateMenual.Focus();
                    return;
                }
                try
                {
                    if (string.IsNullOrEmpty(textBox_DayMenual.Tag.ToString()))
                    {
                        return;
                    }
                }
                catch
                {
                    return;
                }
                SaveMenual(value: true);
                MessageBox.Show((LangArEn == 0) ? "لقد تمت العملية بنجاح" : "Attendance has operations and leave successfully", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                Clear();
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("ButSaveMenual_Click:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void SuperGridColumnsEdit()
        {
            dataGridViewX_RepDetils.Columns["vDate"].HeaderText = ((LangArEn == 1) ? "Date" : "التاريخ");
            dataGridViewX_RepDetils.Columns["vDay"].HeaderText = ((LangArEn == 1) ? "Day" : "اليوم");
            dataGridViewX_RepDetils.Columns["vTime1"].HeaderText = ((LangArEn == 1) ? "Come" : "حضور");
            dataGridViewX_RepDetils.Columns["vLeaveTime1"].HeaderText = ((LangArEn == 1) ? "Leave" : "انصراف");
            dataGridViewX_RepDetils.Columns["vTime2"].HeaderText = ((LangArEn == 1) ? "Come" : "حضور");
            dataGridViewX_RepDetils.Columns["vLeaveTime2"].HeaderText = ((LangArEn == 1) ? "Leave" : "انصراف");
            dataGridViewX_RepDetils.Columns["vLateTime"].HeaderText = ((LangArEn == 1) ? "Late" : "تأخير");
            dataGridViewX_RepDetils.Columns["vNote"].HeaderText = ((LangArEn == 1) ? "Note" : "الملاحظـات");
            dataGridViewX_RepDetils.Columns["UsrName"].HeaderText = ((LangArEn == 1) ? "By" : "مسؤولية التعديل");
            dataGridViewX_RepDetils.Columns["DateEdi"].HeaderText = ((LangArEn == 1) ? "Edite" : "آخر تعديل");
        }
        public void FillComboEdit()
        {
            comboBox_EmpNo.SelectedValueChanged -= comboBox_EmpNo_SelectedValueChanged;
            List<T_Emp> listEmps = new List<T_Emp>(db.T_Emps.Where((T_Emp item) => item.EmpState == (bool?)true).ToList());
            comboBox_EmpNo.DataSource = listEmps;
            comboBox_EmpNo.DisplayMember = ((LangArEn == 0) ? "NameA" : "NameE");
            comboBox_EmpNo.ValueMember = "Emp_ID";
            comboBox_EmpNo.SelectedIndex = -1;
            comboBox_EmpNo.SelectedValueChanged += comboBox_EmpNo_SelectedValueChanged;
        }
        private void comboBox_EmpNo_SelectedValueChanged(object sender, EventArgs e)
        {
            button_Open_Click(sender, e);
        }
        private void button_Print_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewX_RepDetils.Rows.Count > 0 && comboBox_EmpNo.SelectedIndex != -1 && VarGeneral.CheckDate(textBox_DateEdit.Text))
                {
                    FrmReportsViewer frm = new FrmReportsViewer();
                    frm.Tag = LangArEn;
                    frm.Repvalue = "AttEmpRep";
                    VarGeneral.vTitle = Text;
                    frm.SqlWhere = " AND [EmpID] ='" + comboBox_EmpNo.SelectedValue.ToString() + "' And ([Date] BETWEEN '" + Convert.ToDateTime(textBox_DateEdit.Text).ToString("yyyy/MM") + "/01' And '" + Convert.ToDateTime(textBox_DateEdit.Text).ToString("yyyy/MM") + "/31')";
                    frm.TopMost = true;
                    frm.ShowDialog();
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("bubbleButton_RepAttend_Click:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void SetEntry(int row, int col)
        {
            try
            {
                if (dataGridViewX_RepDetils.Rows[row].Cells[col].Value.ToString() == "----" || dataGridViewX_RepDetils.Rows[row].Cells[col].Value.ToString() == "~~~~" || dataGridViewX_RepDetils.Rows[row].Cells[col].Value.ToString() == "xxx")
                {
                    return;
                }
                if (col == 2 || col == 3)
                {
                    if (VarGeneral.CheckTime(dataGridViewX_RepDetils.Rows[row].Cells["Pardon1"].Value.ToString()))
                    {
                        dataGridViewX_RepDetils.Rows[row].Cells[col].ReadOnly = false;
                        dataGridViewX_RepDetils.SelectAll();
                    }
                    else
                    {
                        dataGridViewX_RepDetils.Rows[row].Cells[col].ReadOnly = true;
                    }
                }
                else if (col == 4 || col == 5)
                {
                    if (VarGeneral.CheckTime(dataGridViewX_RepDetils.Rows[row].Cells["Pardon2"].Value.ToString()))
                    {
                        dataGridViewX_RepDetils.Rows[row].Cells[col].ReadOnly = false;
                        dataGridViewX_RepDetils.SelectAll();
                    }
                    else
                    {
                        dataGridViewX_RepDetils.Rows[row].Cells[col].ReadOnly = true;
                    }
                }
            }
            catch
            {
            }
        }
        private void dataGridViewX_RepDetils_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                A1 = dataGridViewX_RepDetils.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            }
            else if (e.ColumnIndex == 3)
            {
                B1 = dataGridViewX_RepDetils.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            }
            else if (e.ColumnIndex == 4)
            {
                A2 = dataGridViewX_RepDetils.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            }
            else if (e.ColumnIndex == 5)
            {
                B2 = dataGridViewX_RepDetils.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            }
        }
        private int DTimeEdit(string BTime, string Etime)
        {
            try
            {
                if (string.IsNullOrEmpty(BTime) || string.IsNullOrEmpty(Etime))
                {
                    return 0;
                }
                if (!VarGeneral.CheckDate(BTime) || !VarGeneral.CheckDate(Etime))
                {
                    return 0;
                }
                int LAmount = 0;
                if (TimeSpan.Parse(Etime) > TimeSpan.Parse(BTime))
                {
                    LAmount = int.Parse(Etime.Substring(3, 2)) - int.Parse(BTime.Substring(3, 2));
                    LAmount += 60 * (int.Parse(Etime.Substring(0, 2)) - int.Parse(BTime.Substring(0, 2)));
                }
                return LAmount;
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("DTimeEdit:", error, enable: true);
                MessageBox.Show(error.Message);
                return 0;
            }
        }
        private void dataGridViewX_RepDetils_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                try
                {
                    if (!VarGeneral.CheckTime(dataGridViewX_RepDetils.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()))
                    {
                        dataGridViewX_RepDetils.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = A1;
                    }
                    else
                    {
                        dataGridViewX_RepDetils.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = Convert.ToDateTime(dataGridViewX_RepDetils.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()).ToString("HH:mm");
                    }
                    if (Convert.ToDateTime(dataGridViewX_RepDetils.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()).ToString("HH:mm") != Convert.ToDateTime(A1).ToString("HH:mm"))
                    {
                        button_Save.Enabled = true;
                        int dtLate = 0;
                        if (VarGeneral.CheckTime(dataGridViewX_RepDetils.Rows[e.RowIndex].Cells["AttTime1"].Value.ToString()))
                        {
                            dtLate = DTimeEdit(dataGridViewX_RepDetils.Rows[e.RowIndex].Cells["AttTime1"].Value.ToString(), dataGridViewX_RepDetils.Rows[e.RowIndex].Cells[2].Value.ToString());
                        }
                        if (VarGeneral.CheckTime(dataGridViewX_RepDetils.Rows[e.RowIndex].Cells["AttTime2"].Value.ToString()))
                        {
                            dtLate += DTimeEdit(dataGridViewX_RepDetils.Rows[e.RowIndex].Cells["AttTime2"].Value.ToString(), dataGridViewX_RepDetils.Rows[e.RowIndex].Cells[4].Value.ToString());
                        }
                        dataGridViewX_RepDetils.Rows[e.RowIndex].Cells[6].Value = VarGeneral.TString.TEmpty(string.Concat(dtLate));
                    }
                }
                catch (Exception)
                {
                    dataGridViewX_RepDetils.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = A1;
                }
            }
            else if (e.ColumnIndex == 3)
            {
                try
                {
                    if (!VarGeneral.CheckTime(dataGridViewX_RepDetils.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()))
                    {
                        dataGridViewX_RepDetils.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = B1;
                    }
                    else
                    {
                        dataGridViewX_RepDetils.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = Convert.ToDateTime(dataGridViewX_RepDetils.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()).ToString("HH:mm");
                    }
                    if (!button_Save.Enabled && Convert.ToDateTime(dataGridViewX_RepDetils.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()).ToString("HH:mm") != Convert.ToDateTime(B1).ToString("HH:mm"))
                    {
                        button_Save.Enabled = true;
                    }
                }
                catch (Exception)
                {
                    dataGridViewX_RepDetils.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = B1;
                }
            }
            else if (e.ColumnIndex == 4)
            {
                try
                {
                    if (!VarGeneral.CheckTime(dataGridViewX_RepDetils.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()))
                    {
                        dataGridViewX_RepDetils.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = A2;
                    }
                    else
                    {
                        dataGridViewX_RepDetils.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = Convert.ToDateTime(dataGridViewX_RepDetils.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()).ToString("HH:mm");
                    }
                    if (Convert.ToDateTime(dataGridViewX_RepDetils.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()).ToString("HH:mm") != Convert.ToDateTime(A2).ToString("HH:mm"))
                    {
                        button_Save.Enabled = true;
                        int dtLate = 0;
                        if (VarGeneral.CheckTime(dataGridViewX_RepDetils.Rows[e.RowIndex].Cells["AttTime1"].Value.ToString()))
                        {
                            dtLate = DTimeEdit(dataGridViewX_RepDetils.Rows[e.RowIndex].Cells["AttTime1"].Value.ToString(), dataGridViewX_RepDetils.Rows[e.RowIndex].Cells[2].Value.ToString());
                        }
                        if (VarGeneral.CheckTime(dataGridViewX_RepDetils.Rows[e.RowIndex].Cells["AttTime2"].Value.ToString()))
                        {
                            dtLate += DTimeEdit(dataGridViewX_RepDetils.Rows[e.RowIndex].Cells["AttTime2"].Value.ToString(), dataGridViewX_RepDetils.Rows[e.RowIndex].Cells[4].Value.ToString());
                        }
                        dataGridViewX_RepDetils.Rows[e.RowIndex].Cells[6].Value = VarGeneral.TString.TEmpty(string.Concat(dtLate));
                    }
                }
                catch (Exception)
                {
                    dataGridViewX_RepDetils.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = A2;
                }
            }
            else
            {
                if (e.ColumnIndex != 5)
                {
                    return;
                }
                try
                {
                    if (!VarGeneral.CheckTime(dataGridViewX_RepDetils.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()))
                    {
                        dataGridViewX_RepDetils.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = B2;
                    }
                    else
                    {
                        dataGridViewX_RepDetils.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = Convert.ToDateTime(dataGridViewX_RepDetils.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()).ToString("HH:mm");
                    }
                    if (!button_Save.Enabled && Convert.ToDateTime(dataGridViewX_RepDetils.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()).ToString("HH:mm") != Convert.ToDateTime(B2).ToString("HH:mm"))
                    {
                        button_Save.Enabled = true;
                    }
                }
                catch (Exception)
                {
                    dataGridViewX_RepDetils.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = B2;
                }
            }
        }
        private void button_Open_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox_DateEdit.Text.Length != 7 || !VarGeneral.CheckDate(textBox_DateEdit.Text) || comboBox_EmpNo.SelectedIndex == -1)
                {
                    return;
                }
                string Qstr = "Select * From T_AttendOperat Where EmpID='" + comboBox_EmpNo.SelectedValue.ToString() + "' And Date Between '" + Convert.ToDateTime(textBox_DateEdit.Text).ToString("yyyy/MM/01") + "' And '" + Convert.ToDateTime(textBox_DateEdit.Text).ToString("yyyy/MM/31") + "' Order By Date";
                List<T_AttendOperat> ListAttendop = db.ExecuteQuery<T_AttendOperat>(Qstr, new object[0]).ToList();
                try
                {
                    dataGridViewX_RepDetils.Rows.Clear();
                }
                catch
                {
                }
                if (ListAttendop.Count <= 0)
                {
                    return;
                }
                int i = 0;
                while (true)
                {
                    if (i >= ListAttendop.Count)
                    {
                        break;
                    }
                    dataGridViewX_RepDetils.Rows.Add();
                    dataGridViewX_RepDetils.Rows[i].Cells["vDate"].Value = ListAttendop[i].Date;
                    dataGridViewX_RepDetils.Rows[i].Cells["vDay"].Value = ListAttendop[i].T_DayOfWeek.NameA;
                    dataGridViewX_RepDetils.Rows[i].Cells["vTime1"].Value = ListAttendop[i].Time1;
                    try
                    {
                        dataGridViewX_RepDetils.Rows[i].Cells["vTime1"].Value = Convert.ToDateTime(dataGridViewX_RepDetils.Rows[i].Cells["vTime1"].Value).ToString("HH:mm");
                    }
                    catch
                    {
                    }
                    dataGridViewX_RepDetils.Rows[i].Cells["vLeaveTime1"].Value = ListAttendop[i].LeaveTime;
                    try
                    {
                        dataGridViewX_RepDetils.Rows[i].Cells["vLeaveTime1"].Value = Convert.ToDateTime(dataGridViewX_RepDetils.Rows[i].Cells["vLeaveTime1"].Value).ToString("HH:mm");
                    }
                    catch
                    {
                    }
                    dataGridViewX_RepDetils.Rows[i].Cells["vTime2"].Value = ListAttendop[i].Time2;
                    try
                    {
                        dataGridViewX_RepDetils.Rows[i].Cells["vTime2"].Value = Convert.ToDateTime(dataGridViewX_RepDetils.Rows[i].Cells["vTime2"].Value).ToString("HH:mm");
                    }
                    catch
                    {
                    }
                    dataGridViewX_RepDetils.Rows[i].Cells["vLeaveTime2"].Value = ListAttendop[i].LeaveTime2;
                    try
                    {
                        dataGridViewX_RepDetils.Rows[i].Cells["vLeaveTime2"].Value = Convert.ToDateTime(dataGridViewX_RepDetils.Rows[i].Cells["vLeaveTime2"].Value).ToString("HH:mm");
                    }
                    catch
                    {
                    }
                    dataGridViewX_RepDetils.Rows[i].Cells["vLateTime"].Value = ListAttendop[i].LateTime.Value;
                    dataGridViewX_RepDetils.Rows[i].Cells["vNote"].Value = ListAttendop[i].Note;
                    dataGridViewX_RepDetils.Rows[i].Cells["vEmpID"].Value = ListAttendop[i].EmpID;
                    dataGridViewX_RepDetils.Rows[i].Cells["DateEdi"].Value = ListAttendop[i].DateEdit;
                    if (ListAttendop[i].Usr_No.HasValue)
                    {
                        dataGridViewX_RepDetils.Rows[i].Cells["UsrName"].Value = ((LangArEn == 0) ? dbc.Get_PermissionID(ListAttendop[i].Usr_No.Value).UsrNamA : dbc.Get_PermissionID(ListAttendop[i].Usr_No.Value).UsrNamE);
                    }
                    List<T_Attend> q = db.T_Attends.Where((T_Attend t) => t.EmpID == comboBox_EmpNo.SelectedValue.ToString() && t.Day_No == (int?)ListAttendop[i].Day.Value).ToList();
                    if (q.Count > 0)
                    {
                        dataGridViewX_RepDetils.Rows[i].Cells["AttTime1"].Value = q.First().Time1;
                        try
                        {
                            dataGridViewX_RepDetils.Rows[i].Cells["AttTime1"].Value = Convert.ToDateTime(dataGridViewX_RepDetils.Rows[i].Cells["AttTime1"].Value).ToString("HH:mm");
                        }
                        catch
                        {
                        }
                        dataGridViewX_RepDetils.Rows[i].Cells["AttTime2"].Value = q.First().Time2;
                        try
                        {
                            dataGridViewX_RepDetils.Rows[i].Cells["AttTime2"].Value = Convert.ToDateTime(dataGridViewX_RepDetils.Rows[i].Cells["AttTime2"].Value).ToString("HH:mm");
                        }
                        catch
                        {
                        }
                        dataGridViewX_RepDetils.Rows[i].Cells["AttLeaveTime1"].Value = q.First().LeaveTime1;
                        try
                        {
                            dataGridViewX_RepDetils.Rows[i].Cells["AttLeaveTime1"].Value = Convert.ToDateTime(dataGridViewX_RepDetils.Rows[i].Cells["AttLeaveTime1"].Value).ToString("HH:mm");
                        }
                        catch
                        {
                        }
                        dataGridViewX_RepDetils.Rows[i].Cells["AttLeaveTime2"].Value = q.First().LeaveTime2;
                        try
                        {
                            dataGridViewX_RepDetils.Rows[i].Cells["AttLeaveTime2"].Value = Convert.ToDateTime(dataGridViewX_RepDetils.Rows[i].Cells["AttLeaveTime2"].Value).ToString("HH:mm");
                        }
                        catch
                        {
                        }
                        dataGridViewX_RepDetils.Rows[i].Cells["Pardon1"].Value = q.First().TimeAllow1;
                        dataGridViewX_RepDetils.Rows[i].Cells["Pardon2"].Value = q.First().TimeAlow2;
                    }
                    i++;
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("button_Open_Click:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void button_Save_Click(object sender, EventArgs e)
        {
            try
            {
                int i = 0;
                while (true)
                {
                    if (i >= dataGridViewX_RepDetils.Rows.Count)
                    {
                        break;
                    }
                    T_AttendOperat newData = new T_AttendOperat();
                    List<T_AttendOperat> q = (from t in db.T_AttendOperats
                                              where t.Date == dataGridViewX_RepDetils.Rows[i].Cells["vDate"].Value.ToString()
                                              where t.T_DayOfWeek.NameA == dataGridViewX_RepDetils.Rows[i].Cells["vDay"].Value.ToString()
                                              where t.EmpID == dataGridViewX_RepDetils.Rows[i].Cells["vEmpID"].Value.ToString()
                                              select t).ToList();
                    if (q.Count > 0)
                    {
                        try
                        {
                            newData = q.First();
                            try
                            {
                                newData.Time1 = Convert.ToDateTime(dataGridViewX_RepDetils.Rows[i].Cells[2].Value).ToString("HH:mm");
                            }
                            catch
                            {
                            }
                            try
                            {
                                newData.LeaveTime = Convert.ToDateTime(dataGridViewX_RepDetils.Rows[i].Cells[3].Value).ToString("HH:mm");
                            }
                            catch
                            {
                            }
                            try
                            {
                                newData.Time2 = Convert.ToDateTime(dataGridViewX_RepDetils.Rows[i].Cells[4].Value).ToString("HH:mm");
                            }
                            catch
                            {
                            }
                            try
                            {
                                newData.LeaveTime2 = Convert.ToDateTime(dataGridViewX_RepDetils.Rows[i].Cells[5].Value).ToString("HH:mm");
                            }
                            catch
                            {
                            }
                            try
                            {
                                newData.LateTime = int.Parse(dataGridViewX_RepDetils.Rows[i].Cells[6].Value.ToString());
                            }
                            catch
                            {
                            }
                            newData.Usr_No = VarGeneral.UserID;
                            int? calendr = VarGeneral.Settings_Sys.Calendr;
                            if (calendr.Value == 0 && calendr.HasValue)
                            {
                                newData.DateEdit = n.GDateNow("yyyy/MM/dd");
                            }
                            else
                            {
                                newData.DateEdit = n.HDateNow("yyyy/MM/dd");
                            }
                            db.Log = VarGeneral.DebugLog;
                            db.SubmitChanges(ConflictMode.ContinueOnConflict);
                        }
                        catch
                        {
                        }
                    }
                    i++;
                }
                MessageBox.Show((LangArEn == 0) ? "تم عملية التعديل على سجلات الحضور والانصراف بنجاح" : "Update Records is successfully", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                try
                {
                    dataGridViewX_RepDetils.Rows.Clear();
                }
                catch
                {
                }
                textBox_DateEdit.Text = "";
                button_Save.Enabled = false;
            }
            catch (Exception error)
            {
                try
                {
                    dataGridViewX_RepDetils.Rows.Clear();
                }
                catch
                {
                }
                textBox_DateEdit.Text = "";
                button_Save.Enabled = false;
                VarGeneral.DebLog.writeLog("Button_Save_Click:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void button_SEmp_Click(object sender, EventArgs e)
        {
            try
            {
                Dir_ButSearch.Add("Emp_No", new ColumnDictinary("رقم الموظف", "Employee No", ifDefault: true, ""));
                Dir_ButSearch.Add("NameA", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, ""));
                Dir_ButSearch.Add("NameE", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: false, ""));
                Dir_ButSearch.Add("DateAppointment", new ColumnDictinary("تاريخ التعيين", "Appointment Date", ifDefault: false, ""));
                Dir_ButSearch.Add("StartContr", new ColumnDictinary("بداية العقد", "Start Contract Date", ifDefault: false, ""));
                Dir_ButSearch.Add("EndContr", new ColumnDictinary("نهاية العقد", "End Contract Date", ifDefault: false, ""));
                Dir_ButSearch.Add("MainSal", new ColumnDictinary("الراتب الأساسي", "Main Salary", ifDefault: false, ""));
                Dir_ButSearch.Add("ID_No", new ColumnDictinary("رقم الهوية", "ID No", ifDefault: false, ""));
                Dir_ButSearch.Add("Passport_No", new ColumnDictinary("رقم الجواز", "Passport No", ifDefault: false, ""));
                Dir_ButSearch.Add("AddressA", new ColumnDictinary("العنوان", "Address", ifDefault: false, ""));
                Dir_ButSearch.Add("Tel", new ColumnDictinary("الهاتف", "Tel", ifDefault: false, ""));
                Dir_ButSearch.Add("Note", new ColumnDictinary(" الملاحظــات", "Note", ifDefault: false, ""));
                FrmSearch frm = new FrmSearch();
                frm.Tag = LangArEn;
                ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = Dir_ButSearch;
                foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
                {
                    frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, ""));
                }
                VarGeneral.SFrmTyp = "T_Emp";
                VarGeneral.FrmEmpStat = true;
                frm.TopMost = true;
                frm.ShowDialog();
                if (frm.SerachNo != "")
                {
                    frm.Serach_No = db.EmpsEmpNo(frm.Serach_No).Emp_ID;
                    comboBox_EmpNo.SelectedValue = frm.SerachNo;
                }
                Dir_ButSearch.Clear();
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("button_SrchEmp_Click:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void textBox_DateEdit_Leave(object sender, EventArgs e)
        {
            try
            {
                if (VarGeneral.CheckDate(textBox_DateEdit.Text))
                {
                    textBox_DateEdit.Text = TimeSpan.Parse(textBox_DateEdit.Text).ToString();
                }
                else
                {
                    textBox_DateEdit.Text = "";
                }
            }
            catch
            {
            }
        }
        private void textBox_DateEdit_Click(object sender, EventArgs e)
        {
            textBox_DateEdit.SelectAll();
        }
        public void FillComboLate()
        {
            List<T_Job> listJob = new List<T_Job>(db.T_Jobs.Select((T_Job item) => item).ToList());
            comboBox_Job.DataSource = listJob;
            comboBox_Job.DisplayMember = ((LangArEn == 0) ? "NameA" : "NameE");
            comboBox_Job.ValueMember = "Job_No";
            comboBox_Job.SelectedIndex = -1;
            List<T_Dept> listDept = new List<T_Dept>(db.T_Depts.Select((T_Dept item) => item).ToList());
            comboBox_Dept.DataSource = listDept;
            comboBox_Dept.DisplayMember = ((LangArEn == 0) ? "NameA" : "NameE");
            comboBox_Dept.ValueMember = "Dept_No";
            comboBox_Dept.SelectedIndex = -1;
            List<T_Section> listSection = new List<T_Section>(db.T_Sections.Select((T_Section item) => item).ToList());
            comboBox_Section.DataSource = listSection;
            comboBox_Section.DisplayMember = ((LangArEn == 0) ? "NameA" : "NameE");
            comboBox_Section.ValueMember = "Section_No";
            comboBox_Section.SelectedIndex = -1;
        }
        private void textBox_DateLate_Leave(object sender, EventArgs e)
        {
            try
            {
                if (VarGeneral.CheckDate(textBox_DateLate.Text))
                {
                    textBox_DateLate.Text = Convert.ToDateTime(textBox_DateLate.Text).ToString("yyyy/MM");
                    return;
                }
                int? calendr = VarGeneral.Settings_Sys.Calendr;
                if (calendr.Value == 0 && calendr.HasValue)
                {
                    textBox_DateLate.Text = n.FormatGreg(VarGeneral.Gdate, "yyyy/MM");
                }
                else
                {
                    textBox_DateLate.Text = n.FormatHijri(VarGeneral.Hdate, "yyyy/MM");
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("textBox_Date_Leave:", error, enable: true);
            }
        }
        private void button_OpenLate_Click(object sender, EventArgs e)
        {
            UpdateAttend_IN2Late();
            try
            {
                string QStr = "";
                try
                {
                    DataGridViewX_RepResult.PrimaryGrid.Rows.Clear();
                }
                catch
                {
                }
                if (string.IsNullOrEmpty(textBox_DateLate.Text) || !VarGeneral.CheckDate(textBox_DateLate.Text))
                {
                    return;
                }
                string maxdate = "";
                int Tot_H = 0;
                double Tot_M = 0.0;
                maxdate = (from y in db.T_AttendOperats
                           where y.Date.StartsWith(textBox_DateLate.Text)
                           select y.Date).Max();
                if (string.IsNullOrEmpty(maxdate))
                {
                    maxdate = Convert.ToDateTime(textBox_DateLate.Text).ToString("yyyy/MM/01");
                }
                int QDept = 0;
                int QJob = 0;
                int QSection = 0;
                if (GetComboItemLate(comboBox_Dept) > 0)
                {
                    QDept = GetComboItemLate(comboBox_Dept);
                    QStr = QStr + " AND T_Emp.Dept = " + QDept;
                }
                if (GetComboItemLate(comboBox_Job) > 0)
                {
                    QJob = GetComboItemLate(comboBox_Job);
                    QStr = QStr + " AND T_Emp.Job = " + QJob;
                }
                if (GetComboItemLate(comboBox_Section) > 0)
                {
                    QSection = GetComboItemLate(comboBox_Section);
                    QStr = QStr + " AND T_Emp.Section = " + QSection;
                }
                List<T_Emp> EmpList = db.ExecuteQuery<T_Emp>("Select * From [T_Emp] Where [EmpState]=1 " + QStr, new object[0]).ToList();
                for (int i = 0; i < EmpList.Count(); i++)
                {
                    db.CheckPreviousDays(EmpList[i].Emp_ID, maxdate, null, 0);
                }
                var total = (from p in db.T_Emps
                             join c in db.T_AttendOperats on p.Emp_ID equals c.EmpID into j1
                             from j2 in j1.DefaultIfEmpty()
                             where p.EmpState == (bool?)true && j2.Operation == "DONE" && ((QDept > 0) ? (p.Dept == (int?)QDept) : true) && ((QJob > 0) ? (p.Job == (int?)QJob) : true) && ((QSection > 0) ? (p.Section == (int?)QSection) : true) && j2.Date.Substring(0, 7) == Convert.ToDateTime(textBox_DateLate.Text).ToString("yyyy/MM")
                             group new
                             {
                                 j2,
                                 j1
                             } by new
                             {
                                 p.Emp_No,
                                 p.Emp_ID,
                                 p.NameE,
                                 p.NameA,
                                 p.DisOneDay,
                                 p.LateHours,
                                 p.Section,
                                 p.Job,
                                 p.Dept
                             } into grouped
                             orderby grouped.Key.Emp_No
                             select new
                             {
                                 EmpID = grouped.Key.Emp_ID,
                                 EmpNo = grouped.Key.Emp_No,
                                 NameA = grouped.Key.NameA,
                                 NameE = grouped.Key.NameE,
                                 LateHours = grouped.Key.LateHours,
                                 SubDay = grouped.Key.DisOneDay,
                                 SumOfLater = grouped.Sum(t3 => t3.j2.LateTime)
                             }).ToList();
                for (int i = 0; i < total.Count(); i++)
                {
                    long TotalAbsence = GetTotalAbsenceLate(total[i].EmpID, Convert.ToDateTime(textBox_DateLate.Text).ToString("yyyy/MM/01"), Convert.ToDateTime(textBox_DateLate.Text).ToString("yyyy/MM/31"));
                    if (TotalAbsence != 0 || int.Parse(VarGeneral.TString.TEmpty(string.Concat(total[i].SumOfLater))) != 0)
                    {
                        GridRow row = new GridRow();
                        row.Cells.Add(new GridCell(""));
                        row.Cells.Add(new GridCell(""));
                        row.Cells.Add(new GridCell(""));
                        row.Cells.Add(new GridCell(""));
                        row.Cells.Add(new GridCell(""));
                        row.Cells.Add(new GridCell(""));
                        row.Cells.Add(new GridCell(""));
                        row.Cells.Add(new GridCell(""));
                        row.Cells[7].Value = total[i].EmpNo;
                        row.Cells[6].Value = ((LangArEn == 0) ? total[i].NameA : total[i].NameE);
                        Tot_H = int.Parse(VarGeneral.TString.TEmpty(string.Concat(total[i].SumOfLater.Value))) / 60;
                        Tot_M = total[i].SumOfLater.Value % 60.0;
                        row.Cells[5].Value = Tot_H + ":" + Math.Round(Tot_M, 2);
                        row.Cells[4].Value = Math.Round(total[i].SumOfLater.Value / 60.0 * total[i].LateHours.Value, 2);
                        row.Cells[3].Value = total[i].EmpID;
                        row.Cells[2].Value = total[i].SumOfLater;
                        row.Cells[1].Value = GetTotalAbsenceLate(total[i].EmpID, Convert.ToDateTime(textBox_DateLate.Text).ToString("yyyy/MM/01"), Convert.ToDateTime(textBox_DateLate.Text).ToString("yyyy/MM/31"));
                        row.Cells[0].Value = Math.Round(total[i].SubDay.Value * (double)GetTotalAbsenceLate(total[i].EmpNo, Convert.ToDateTime(textBox_DateLate.Text).ToString("yyyy/MM/01"), Convert.ToDateTime(textBox_DateLate.Text).ToString("yyyy/MM/31")), 2);
                        DataGridViewX_RepResult.PrimaryGrid.Rows.Add(row);
                    }
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("button_OpenLate_Click:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private int DTimeLate(string BTime, string Etime)
        {
            try
            {
                if (string.IsNullOrEmpty(BTime) || string.IsNullOrEmpty(Etime))
                {
                    return 0;
                }
                if (!VarGeneral.CheckDate(BTime) || !VarGeneral.CheckDate(Etime))
                {
                    return 0;
                }
                int LAmount = 0;
                if (TimeSpan.Parse(Etime) > TimeSpan.Parse(BTime))
                {
                    LAmount = int.Parse(Etime.Substring(3, 2)) - int.Parse(BTime.Substring(3, 2));
                    LAmount += 60 * (int.Parse(Etime.Substring(0, 2)) - int.Parse(BTime.Substring(0, 2)));
                }
                return LAmount;
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("DTimeLate:", error, enable: true);
                MessageBox.Show(error.Message);
                return 0;
            }
        }
        private void UpdateAttend_IN2Late()
        {
            try
            {
                string StartTime = DateTime.Now.ToString("HH:mm", DateTimeFormatInfo.InvariantInfo);
                List<T_AttendOperat> q = db.T_AttendOperats.Where((T_AttendOperat t) => t.Operation == "IN2" && t.Date.Contains(Convert.ToDateTime(textBox_DateLate.Text).ToString("yyyy/MM"))).ToList();
                if (q.Count <= 0)
                {
                    return;
                }
                int i = 0;
                while (true)
                {
                    if (i < q.Count)
                    {
                        List<T_Attend> listEmps = new List<T_Attend>(db.T_Attends.Where((T_Attend item) => item.EmpID == q[i].EmpID && item.Day_No == (int?)q[i].Day.Value).ToList());
                        string vD = Convert.ToDateTime(q[i].Date).ToString("yyyy/MM/dd");
                        if (VarGeneral.CheckTime(listEmps[0].LeaveTime2) && (TimeSpan.Parse(Convert.ToDateTime(StartTime).ToString("HH:mm")) > TimeSpan.Parse(listEmps.First().LeaveTime2) || Convert.ToDateTime(vD) < Convert.ToDateTime(n.IsGreg(vD) ? VarGeneral.Gdate : VarGeneral.Hdate)))
                        {
                            T_AttendOperat Data_this_AttendOpLate = new T_AttendOperat();
                            Data_this_AttendOpLate = q[i];
                            Data_this_AttendOpLate.Time2 = listEmps[i].LeaveTime2;
                            Data_this_AttendOpLate.LeaveTime2 = listEmps[i].LeaveTime2;
                            T_AttendOperat t_AttendOperat = Data_this_AttendOpLate;
                            t_AttendOperat.LateTime += (double)DTimeLate(listEmps[i].Time2.Trim(), listEmps[i].LeaveTime2.Trim());
                            Data_this_AttendOpLate.Operation = "DONE";
                            db.Log = VarGeneral.DebugLog;
                            db.SubmitChanges(ConflictMode.ContinueOnConflict);
                        }
                        i++;
                        continue;
                    }
                    break;
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("FrmAttendLate_UpdateAttend_IN2:", error, enable: true);
            }
        }
        private void SettingGridLate()
        {
            DataGridViewX_RepResult.PrimaryGrid.Columns[0].HeaderText = ((LangArEn == 0) ? "قيمة الغياب" : "Absent Value");
            DataGridViewX_RepResult.PrimaryGrid.Columns[1].HeaderText = ((LangArEn == 0) ? "الغياب" : "Absent");
            DataGridViewX_RepResult.PrimaryGrid.Columns[2].HeaderText = "";
            DataGridViewX_RepResult.PrimaryGrid.Columns[3].HeaderText = "";
            DataGridViewX_RepResult.PrimaryGrid.Columns[4].HeaderText = ((LangArEn == 0) ? "قيمة التأخير" : "Late Value");
            DataGridViewX_RepResult.PrimaryGrid.Columns[5].HeaderText = ((LangArEn == 0) ? "مدة التأخير" : "Late Time");
            DataGridViewX_RepResult.PrimaryGrid.Columns[6].HeaderText = ((LangArEn == 0) ? "اسم الموظف" : "Employee Name");
            DataGridViewX_RepResult.PrimaryGrid.Columns[7].HeaderText = ((LangArEn == 0) ? "رقم الموظف" : "Emp No");
            DataGridViewX_RepResult.PrimaryGrid.Columns[0].Width = 90;
            DataGridViewX_RepResult.PrimaryGrid.Columns[0].Visible = false;
            DataGridViewX_RepResult.PrimaryGrid.Columns[1].Width = 90;
            DataGridViewX_RepResult.PrimaryGrid.Columns[2].Width = 0;
            DataGridViewX_RepResult.PrimaryGrid.Columns[3].Width = 0;
            DataGridViewX_RepResult.PrimaryGrid.Columns[4].Width = 90;
            DataGridViewX_RepResult.PrimaryGrid.Columns[4].Visible = false;
            DataGridViewX_RepResult.PrimaryGrid.Columns[5].Width = 90;
            DataGridViewX_RepResult.PrimaryGrid.Columns[6].Width = 220;
            DataGridViewX_RepResult.PrimaryGrid.Columns[7].Width = 80;
        }
        private long GetTotalAbsenceLate(string vEmpID, string vDate1, string vDate2)
        {
            try
            {
                int q = db.ExecuteQuery<T_AttendOperat>("Select * from T_AttendOperat where [EmpID] = '" + vEmpID + "' AND Time1 = 'xxx' AND [Date] Between '" + vDate1 + "' And '" + vDate2 + "'", new object[0]).Count();
                if (q > 0)
                {
                    return q;
                }
                return 0L;
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("GetTotalAbsenceLate:", error, enable: true);
                MessageBox.Show(error.Message);
                return 0L;
            }
        }
        private int GetComboItemLate(ComboBox combX)
        {
            if (combX.SelectedIndex == -1)
            {
                return -1;
            }
            return int.Parse(combX.SelectedValue.ToString());
        }
        private void button_Relay_Click(object sender, EventArgs e)
        {
            try
            {
                if (DataGridViewX_RepResult.PrimaryGrid.Rows.Count() <= 0 || MessageBox.Show((LangArEn == 0) ? "هل تريد تحويل النتائج التاليـة إلى سجلات خصــم .. ؟" : "Do you want to transfer these results to the discount records ..?", VarGeneral.ProdectNam, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
                {
                    return;
                }
                FlagLte.Clear();
                FlagSlp.Clear();
                for (int i = 0; i < DataGridViewX_RepResult.PrimaryGrid.Rows.Count; i++)
                {
                    double FlagLate = Math.Round((double)(int.Parse(DataGridViewX_RepResult.PrimaryGrid.GetCell(i, 2).Value.ToString()) / 60) + double.Parse(DataGridViewX_RepResult.PrimaryGrid.GetCell(i, 2).Value.ToString()) % 60.0 / 100.0, 2);
                    double FlagSleep = int.Parse(DataGridViewX_RepResult.PrimaryGrid.GetCell(i, 1).Value.ToString());
                    if (FlagLate > 0.0)
                    {
                        FlagLte.Add(DataGridViewX_RepResult.PrimaryGrid.GetCell(i, 3).Value.ToString() + " / " + FlagLate, new ColumnDictinaryLate(DataGridViewX_RepResult.PrimaryGrid.GetCell(i, 3).Value.ToString()));
                    }
                    if (FlagSleep > 0.0)
                    {
                        FlagSlp.Add(DataGridViewX_RepResult.PrimaryGrid.GetCell(i, 3).Value.ToString() + " / " + FlagSleep, new ColumnDictinaryLate(DataGridViewX_RepResult.PrimaryGrid.GetCell(i, 3).Value.ToString()));
                    }
                }
                FrmDiscount frm = new FrmDiscount();
                for (int i = 0; i < frm.controls.Count; i++)
                {
                    if (frm.controls[i].Name == "comboBox_AmontLate" && FlagLte.Count > 0)
                    {
                        (frm.controls[i] as ComboBox).DataSource = new BindingSource(FlagLte, null);
                        (frm.controls[i] as ComboBox).DisplayMember = "Key";
                        (frm.controls[i] as ComboBox).ValueMember = "Value";
                    }
                    if (frm.controls[i].Name == "comboBox_AmontSleep" && FlagSlp.Count > 0)
                    {
                        (frm.controls[i] as ComboBox).DataSource = new BindingSource(FlagSlp, null);
                        (frm.controls[i] as ComboBox).DisplayMember = "Key";
                        (frm.controls[i] as ComboBox).ValueMember = "Value";
                    }
                    if (frm.controls[i].Name == "textBox_SalDate")
                    {
                        (frm.controls[i] as MaskedTextBox).Text = Convert.ToDateTime(textBox_DateLate.Text).ToString("yyyy/MM");
                    }
                }
                VarGeneral.FlagDis = false;
                frm.SalDt = Convert.ToDateTime(textBox_DateLate.Text).ToString("yyyy/MM/dd");
                ICollection<KeyValuePair<string, ColumnDictinaryLate>> animalsAsCollection = FlagLte;
                foreach (KeyValuePair<string, ColumnDictinaryLate> kvp in animalsAsCollection)
                {
                    frm.FlagLte.Add(kvp.Key, new FrmDiscount.ColumnDictinary_Dis(kvp.Value.EmpNo));
                }
                animalsAsCollection = FlagSlp;
                foreach (KeyValuePair<string, ColumnDictinaryLate> kvp in animalsAsCollection)
                {
                    frm.FlagSlp.Add(kvp.Key, new FrmDiscount.ColumnDictinary_Dis(kvp.Value.EmpNo));
                }
                frm.Tag = LangArEn;
                frm.TopMost = true;
                frm.ShowDialog();
                button_OpenLate_Click(sender, e);
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("button_Relay_Click:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void textBox_DateLate_Click(object sender, EventArgs e)
        {
            textBox_DateLate.SelectAll();
        }
        private void buttonItem_RepAttend_Click(object sender, EventArgs e)
        {
            FrmRepAttnd frm = new FrmRepAttnd();
            frm.Tag = LangArEn;
            frm.TopMost = true;
            frm.ShowDialog();
        }
        private void buttonItem_RepPRojectFilter_Click(object sender, EventArgs e)
        {
            FrmRepProject frm = new FrmRepProject();
            frm.Tag = LangArEn;
            frm.TopMost = true;
            frm.ShowDialog();
        }
    }
}
