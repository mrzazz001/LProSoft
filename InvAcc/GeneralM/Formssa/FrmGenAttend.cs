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
    public partial class FrmGenAttend : Form
    {
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
        private IContainer components = null;
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            DevComponents.DotNetBar.SuperGrid.Style.Background background1 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn1 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn2 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn3 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn4 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn5 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn6 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn7 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn8 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn9 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn10 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn11 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.Style.Background background2 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.Style.Background background3 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn12 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn13 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn14 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.Style.Background background4 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.Style.Background background5 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn15 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn16 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn17 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.Style.Background background6 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.Style.Background background7 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn18 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn19 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn20 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.Style.Background background8 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.Style.Background background9 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmGenAttend));
            this.PanelSpecialContainer = new System.Windows.Forms.Panel();
            this.ribbonBar1 = new DevComponents.DotNetBar.RibbonBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ribbonBar_AttendMain = new DevComponents.DotNetBar.RibbonBar();
            this.panelEx_ImportAttend = new DevComponents.DotNetBar.PanelEx();
            this.button_GetFromPath = new DevComponents.DotNetBar.ButtonX();
            this.ButImportFile = new DevComponents.DotNetBar.ButtonX();
            this.buttonX_ImportFile = new DevComponents.DotNetBar.ButtonX();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.switchButton_FileSts = new DevComponents.DotNetBar.Controls.SwitchButton();
            this.textBox_SearchFilePath = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_Start = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_End = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox_EmpNo = new System.Windows.Forms.TextBox();
            this.textBox_Date = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox_TimeLeave1 = new System.Windows.Forms.TextBox();
            this.textBox_TimeT1 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.ExcelGridView = new System.Windows.Forms.DataGridView();
            this.panelEx_Attend = new DevComponents.DotNetBar.PanelEx();
            this.panel5 = new System.Windows.Forms.Panel();
            this.textBox_LeaveTimeOMR2 = new System.Windows.Forms.MaskedTextBox();
            this.textBox_TimeOMR2 = new System.Windows.Forms.MaskedTextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.textBox_LeaveTimeOMR1 = new System.Windows.Forms.MaskedTextBox();
            this.textBox_TimeOMR1 = new System.Windows.Forms.MaskedTextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.radioButton_BreakDayOMR = new System.Windows.Forms.RadioButton();
            this.radioButton_PeriodsOMR2 = new System.Windows.Forms.RadioButton();
            this.radioButton_PeriodsOMR1 = new System.Windows.Forms.RadioButton();
            this.textBox_DateOMR = new System.Windows.Forms.Label();
            this.textBox_Day = new System.Windows.Forms.Label();
            this.bubbleButton_Ok = new DevComponents.DotNetBar.ButtonX();
            this.bubbleButton_Leave = new DevComponents.DotNetBar.ButtonX();
            this.bubbleButton_RepAttend = new DevComponents.DotNetBar.ButtonX();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel_PROJECTs = new System.Windows.Forms.Panel();
            this.comboBox_PRoject = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.button_ADDPRoject = new DevComponents.DotNetBar.ButtonX();
            this.button_SrchPRoject = new DevComponents.DotNetBar.ButtonX();
            this.label23 = new System.Windows.Forms.Label();
            this.textBox_Note = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.textBox_Pass = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.comboBox_Emp = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.button_SrchEmp = new DevComponents.DotNetBar.ButtonX();
            this.textBox_ComeTime = new System.Windows.Forms.MaskedTextBox();
            this.textBox_LateTime = new DevComponents.Editors.DoubleInput();
            this.textBox_ID = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label_TimeTimer = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.panelEx_GeneralAttend = new DevComponents.DotNetBar.PanelEx();
            this.groupPanel_Time2 = new System.Windows.Forms.GroupBox();
            this.textBox_LeaveTime2 = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_TimeAllow2 = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_Time2 = new System.Windows.Forms.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupPanel_Time1 = new System.Windows.Forms.GroupBox();
            this.textBox_LeaveTime1 = new System.Windows.Forms.MaskedTextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.textBox_TimeAllow1 = new System.Windows.Forms.MaskedTextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.textBox_Time1 = new System.Windows.Forms.MaskedTextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.groupPanel_Day = new System.Windows.Forms.GroupBox();
            this.radioButton_BreakDay = new System.Windows.Forms.RadioButton();
            this.radioButton_Periods2 = new System.Windows.Forms.RadioButton();
            this.radioButton_Periods1 = new System.Windows.Forms.RadioButton();
            this.comboBox_Days = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.ButSetAllDays = new DevComponents.DotNetBar.ButtonX();
            this.ButOk = new DevComponents.DotNetBar.ButtonX();
            this.panelEx_LateAttend = new DevComponents.DotNetBar.PanelEx();
            this.button_Relay = new DevComponents.DotNetBar.ButtonX();
            this.button_OpenLate = new DevComponents.DotNetBar.ButtonX();
            this.comboBox_Job = new System.Windows.Forms.ComboBox();
            this.label32 = new System.Windows.Forms.Label();
            this.comboBox_Section = new System.Windows.Forms.ComboBox();
            this.label33 = new System.Windows.Forms.Label();
            this.comboBox_Dept = new System.Windows.Forms.ComboBox();
            this.label34 = new System.Windows.Forms.Label();
            this.textBox_DateLate = new System.Windows.Forms.MaskedTextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.DataGridViewX_RepResult = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            this.panelEx_EditAttend = new DevComponents.DotNetBar.PanelEx();
            this.dataGridViewX_RepDetils = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.vDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vDay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vTime1 = new DevComponents.DotNetBar.Controls.DataGridViewMaskedTextBoxAdvColumn();
            this.vLeaveTime1 = new DevComponents.DotNetBar.Controls.DataGridViewMaskedTextBoxAdvColumn();
            this.vTime2 = new DevComponents.DotNetBar.Controls.DataGridViewMaskedTextBoxAdvColumn();
            this.vLeaveTime2 = new DevComponents.DotNetBar.Controls.DataGridViewMaskedTextBoxAdvColumn();
            this.vLateTime = new DevComponents.DotNetBar.Controls.DataGridViewDoubleInputColumn();
            this.vNote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vEmpID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AttTime1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AttTime2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AttLeaveTime1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AttLeaveTime2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pardon1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pardon2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateEdi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UsrName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button_Save = new DevComponents.DotNetBar.ButtonX();
            this.comboBox_EmpNo = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.button_Open = new DevComponents.DotNetBar.ButtonX();
            this.button_SEmp = new DevComponents.DotNetBar.ButtonX();
            this.textBox_DateEdit = new System.Windows.Forms.MaskedTextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.panelEx_MenualAttend = new DevComponents.DotNetBar.PanelEx();
            this.panel6 = new System.Windows.Forms.Panel();
            this.comboBox_PRojectMenual = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.button_ADDPRojectMenual = new DevComponents.DotNetBar.ButtonX();
            this.button_SrchPRojectMenual = new DevComponents.DotNetBar.ButtonX();
            this.label28 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.textBox_TimeLeaveMenual1 = new System.Windows.Forms.MaskedTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.textBox_ComeTimeMenual = new System.Windows.Forms.MaskedTextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.textBox_DayMenual = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.textBox_DateMenual = new System.Windows.Forms.MaskedTextBox();
            this.ButSaveMenual = new DevComponents.DotNetBar.ButtonX();
            this.panel7 = new System.Windows.Forms.Panel();
            this.radioButton_PeriodsMenual2 = new System.Windows.Forms.RadioButton();
            this.radioButton_PeriodsMenual1 = new System.Windows.Forms.RadioButton();
            this.expandablePanel_Girds = new DevComponents.DotNetBar.ExpandablePanel();
            this.expandablePanel_Emp = new DevComponents.DotNetBar.ExpandablePanel();
            this.itemPanel4 = new DevComponents.DotNetBar.ItemPanel();
            this.dataGridViewX_Emp = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            this.expandablePanel_Job = new DevComponents.DotNetBar.ExpandablePanel();
            this.itemPanel3 = new DevComponents.DotNetBar.ItemPanel();
            this.dataGridViewX_Job = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            this.expandablePanel_Section = new DevComponents.DotNetBar.ExpandablePanel();
            this.itemPanel2 = new DevComponents.DotNetBar.ItemPanel();
            this.dataGridViewX_Section = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            this.expandablePanel_Dept = new DevComponents.DotNetBar.ExpandablePanel();
            this.itemPanel1 = new DevComponents.DotNetBar.ItemPanel();
            this.dataGridViewX_Dept = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            this.barLeftDockSite = new DevComponents.DotNetBar.DockSite();
            this.barTopDockSite = new DevComponents.DotNetBar.DockSite();
            this.barBottomDockSite = new DevComponents.DotNetBar.DockSite();
            this.barRightDockSite = new DevComponents.DotNetBar.DockSite();
            this.barTaskPane = new DevComponents.DotNetBar.Bar();
            this.panelDockContainer4 = new DevComponents.DotNetBar.PanelDockContainer();
            this.explorerBar1 = new DevComponents.DotNetBar.ExplorerBar();
            this.explorerBarGroupItem_AttendTime = new DevComponents.DotNetBar.ExplorerBarGroupItem();
            this.buttonItem_Attend = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem_AttendHand = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem_ImportAttend = new DevComponents.DotNetBar.ButtonItem();
            this.explorerBarGroupItem_AttendMissions = new DevComponents.DotNetBar.ExplorerBarGroupItem();
            this.buttonItem_GenAttend = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem_AttendEdit = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem_AttendLate = new DevComponents.DotNetBar.ButtonItem();
            this.explorerBarGroupItem2 = new DevComponents.DotNetBar.ExplorerBarGroupItem();
            this.buttonItem_RepAttend = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem_RepPRojectFilter = new DevComponents.DotNetBar.ButtonItem();
            this.explorerBarGroupItem_Exit = new DevComponents.DotNetBar.ExplorerBarGroupItem();
            this.buttonItem_Close = new DevComponents.DotNetBar.ButtonItem();
            this.TaskPane1 = new DevComponents.DotNetBar.DockContainerItem();
            this.mdiClient1 = new System.Windows.Forms.MdiClient();
            this.dockSite1 = new DevComponents.DotNetBar.DockSite();
            this.dockSite2 = new DevComponents.DotNetBar.DockSite();
            this.dockSite3 = new DevComponents.DotNetBar.DockSite();
            this.mainmenu = new DevComponents.DotNetBar.Bar();
            this.bChangeStyle = new DevComponents.DotNetBar.ButtonItem();
            this.cmdStyleOffice2003 = new DevComponents.DotNetBar.ButtonItem();
            this.cmdStyleVS2005 = new DevComponents.DotNetBar.ButtonItem();
            this.cmdStyleOfficeXP = new DevComponents.DotNetBar.ButtonItem();
            this.cmdStyleOffice2007Blue = new DevComponents.DotNetBar.ButtonItem();
            this.dockSite4 = new DevComponents.DotNetBar.DockSite();
            this.TaskPane2 = new DevComponents.DotNetBar.DockContainerItem();
            this.Main_Panel = new DevComponents.DotNetBar.PanelEx();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.dotNetBarManager1 = new DevComponents.DotNetBar.DotNetBarManager(this.components);
            this.buttonItem26 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem32 = new DevComponents.DotNetBar.ButtonItem();
            this.explorerBarGroupItem1 = new DevComponents.DotNetBar.ExplorerBarGroupItem();
            this.buttonItem31 = new DevComponents.DotNetBar.ButtonItem();
            this.dockContainerItem1 = new DevComponents.DotNetBar.DockContainerItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.netResize1 = new Softgroup.NetResize.NetResize(this.components);
            this.netResize1.AfterControlResize += new Softgroup.NetResize.NetResize.AfterControlResizeEventHandler(this.netResize1_AfterControlResize);
            this.Shown += new System.EventHandler(this.FrmInvSale_Shown);
            this.SizeChanged += new System.EventHandler(this.FrmInvSale_SizeChanged);
            this.ribbonBar1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.ribbonBar_AttendMain.SuspendLayout();
            this.panelEx_ImportAttend.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ExcelGridView)).BeginInit();
            this.panelEx_Attend.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel_PROJECTs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_LateTime)).BeginInit();
            this.panelEx_GeneralAttend.SuspendLayout();
            this.groupPanel_Time2.SuspendLayout();
            this.groupPanel_Time1.SuspendLayout();
            this.groupPanel_Day.SuspendLayout();
            this.panelEx_LateAttend.SuspendLayout();
            this.panelEx_EditAttend.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX_RepDetils)).BeginInit();
            this.panelEx_MenualAttend.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.expandablePanel_Girds.SuspendLayout();
            this.expandablePanel_Emp.SuspendLayout();
            this.itemPanel4.SuspendLayout();
            this.expandablePanel_Job.SuspendLayout();
            this.itemPanel3.SuspendLayout();
            this.expandablePanel_Section.SuspendLayout();
            this.itemPanel2.SuspendLayout();
            this.expandablePanel_Dept.SuspendLayout();
            this.itemPanel1.SuspendLayout();
            this.barRightDockSite.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barTaskPane)).BeginInit();
            this.barTaskPane.SuspendLayout();
            this.panelDockContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.explorerBar1)).BeginInit();
            this.dockSite3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainmenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelSpecialContainer
            // 
            this.PanelSpecialContainer.Location = new System.Drawing.Point(0, 0);
            this.PanelSpecialContainer.Name = "PanelSpecialContainer";
            this.PanelSpecialContainer.Size = new System.Drawing.Size(200, 100);
            this.PanelSpecialContainer.TabIndex = 0;
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
            this.ribbonBar1.BackgroundStyle.BackColor = System.Drawing.Color.AliceBlue;
            this.ribbonBar1.BackgroundStyle.BackColor2 = System.Drawing.SystemColors.GradientActiveCaption;
            this.ribbonBar1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar1.ContainerControlProcessDialogKey = true;
            this.ribbonBar1.Controls.Add(this.panel1);
            this.ribbonBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonBar1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.ribbonBar1.Location = new System.Drawing.Point(0, 0);
            this.ribbonBar1.Name = "ribbonBar1";
            this.ribbonBar1.Size = new System.Drawing.Size(709, 459);
            this.ribbonBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this.ribbonBar1.TabIndex = 1102;
            // 
            // 
            // 
            this.ribbonBar1.TitleStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.ribbonBar1.TitleStyle.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.ribbonBar1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar1.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.ribbonBar_AttendMain);
            this.panel1.Controls.Add(this.expandablePanel_Girds);
            this.panel1.Controls.Add(this.barLeftDockSite);
            this.panel1.Controls.Add(this.barTopDockSite);
            this.panel1.Controls.Add(this.barBottomDockSite);
            this.panel1.Controls.Add(this.barRightDockSite);
            this.panel1.Controls.Add(this.mdiClient1);
            this.panel1.Controls.Add(this.dockSite1);
            this.panel1.Controls.Add(this.dockSite2);
            this.panel1.Controls.Add(this.dockSite3);
            this.panel1.Controls.Add(this.dockSite4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(709, 442);
            this.panel1.TabIndex = 0;
            // 
            // ribbonBar_AttendMain
            // 
            this.ribbonBar_AttendMain.AutoOverflowEnabled = true;
            // 
            // 
            // 
            this.ribbonBar_AttendMain.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar_AttendMain.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar_AttendMain.ContainerControlProcessDialogKey = true;
            this.ribbonBar_AttendMain.Controls.Add(this.panelEx_ImportAttend);
            this.ribbonBar_AttendMain.Controls.Add(this.panelEx_Attend);
            this.ribbonBar_AttendMain.Controls.Add(this.panelEx_GeneralAttend);
            this.ribbonBar_AttendMain.Controls.Add(this.panelEx_LateAttend);
            this.ribbonBar_AttendMain.Controls.Add(this.panelEx_EditAttend);
            this.ribbonBar_AttendMain.Controls.Add(this.panelEx_MenualAttend);
            this.ribbonBar_AttendMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonBar_AttendMain.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.ribbonBar_AttendMain.Location = new System.Drawing.Point(26, 25);
            this.ribbonBar_AttendMain.Name = "ribbonBar_AttendMain";
            this.ribbonBar_AttendMain.Size = new System.Drawing.Size(491, 417);
            this.ribbonBar_AttendMain.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonBar_AttendMain.TabIndex = 6777;
            // 
            // 
            // 
            this.ribbonBar_AttendMain.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar_AttendMain.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // panelEx_ImportAttend
            // 
            this.panelEx_ImportAttend.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx_ImportAttend.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx_ImportAttend.Controls.Add(this.button_GetFromPath);
            this.panelEx_ImportAttend.Controls.Add(this.ButImportFile);
            this.panelEx_ImportAttend.Controls.Add(this.buttonX_ImportFile);
            this.panelEx_ImportAttend.Controls.Add(this.groupBox2);
            this.panelEx_ImportAttend.Controls.Add(this.textBox_SearchFilePath);
            this.panelEx_ImportAttend.Controls.Add(this.groupBox1);
            this.panelEx_ImportAttend.Controls.Add(this.ExcelGridView);
            this.panelEx_ImportAttend.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx_ImportAttend.Location = new System.Drawing.Point(0, 0);
            this.panelEx_ImportAttend.Name = "panelEx_ImportAttend";
            this.panelEx_ImportAttend.Size = new System.Drawing.Size(491, 402);
            this.panelEx_ImportAttend.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx_ImportAttend.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx_ImportAttend.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx_ImportAttend.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx_ImportAttend.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx_ImportAttend.Style.GradientAngle = 90;
            this.panelEx_ImportAttend.TabIndex = 6778;
            this.panelEx_ImportAttend.Visible = false;
            // 
            // button_GetFromPath
            // 
            this.button_GetFromPath.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_GetFromPath.ColorTable = DevComponents.DotNetBar.eButtonColor.Blue;
            this.button_GetFromPath.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.button_GetFromPath.Location = new System.Drawing.Point(13, 88);
            this.button_GetFromPath.Name = "button_GetFromPath";
            this.button_GetFromPath.Size = new System.Drawing.Size(20, 22);
            this.button_GetFromPath.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2003;
            this.button_GetFromPath.SubItemsExpandWidth = 15;
            this.button_GetFromPath.SymbolSize = 15F;
            this.button_GetFromPath.TabIndex = 1597;
            this.button_GetFromPath.Text = "..";
            this.button_GetFromPath.Tooltip = "إستعراض";
            this.button_GetFromPath.Click += new System.EventHandler(this.button_GetFromPath_Click);
            // 
            // ButImportFile
            // 
            this.ButImportFile.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.ButImportFile.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.ButImportFile.Enabled = false;
            this.ButImportFile.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.ButImportFile.Location = new System.Drawing.Point(7, 24);
            this.ButImportFile.Name = "ButImportFile";
            this.ButImportFile.Size = new System.Drawing.Size(134, 36);
            this.ButImportFile.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ButImportFile.Symbol = "";
            this.ButImportFile.SymbolSize = 16F;
            this.ButImportFile.TabIndex = 1596;
            this.ButImportFile.Text = "حفــــظ";
            this.ButImportFile.TextColor = System.Drawing.Color.White;
            this.ButImportFile.Click += new System.EventHandler(this.ButImportFile_Click);
            // 
            // buttonX_ImportFile
            // 
            this.buttonX_ImportFile.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX_ImportFile.Checked = true;
            this.buttonX_ImportFile.ColorTable = DevComponents.DotNetBar.eButtonColor.Blue;
            this.buttonX_ImportFile.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.buttonX_ImportFile.Location = new System.Drawing.Point(143, 24);
            this.buttonX_ImportFile.Name = "buttonX_ImportFile";
            this.buttonX_ImportFile.Size = new System.Drawing.Size(134, 36);
            this.buttonX_ImportFile.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2003;
            this.buttonX_ImportFile.SubItemsExpandWidth = 15;
            this.buttonX_ImportFile.Symbol = "";
            this.buttonX_ImportFile.SymbolSize = 13F;
            this.buttonX_ImportFile.TabIndex = 876;
            this.buttonX_ImportFile.Text = "عرض البيانات";
            this.buttonX_ImportFile.Click += new System.EventHandler(this.buttonX_ImportFile_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.switchButton_FileSts);
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.groupBox2.Location = new System.Drawing.Point(283, 10);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(196, 63);
            this.groupBox2.TabIndex = 875;
            this.groupBox2.TabStop = false;
            // 
            // switchButton_FileSts
            // 
            // 
            // 
            // 
            this.switchButton_FileSts.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.switchButton_FileSts.IsReadOnly = true;
            this.switchButton_FileSts.Location = new System.Drawing.Point(8, 18);
            this.switchButton_FileSts.Name = "switchButton_FileSts";
            this.switchButton_FileSts.OffText = "ملف أكسيل";
            this.switchButton_FileSts.OnText = "ملف نصي";
            this.switchButton_FileSts.Size = new System.Drawing.Size(181, 33);
            this.switchButton_FileSts.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.switchButton_FileSts.TabIndex = 0;
            this.switchButton_FileSts.ValueChanged += new System.EventHandler(this.switchButton_FileSts_ValueChanged);
            // 
            // textBox_SearchFilePath
            // 
            this.textBox_SearchFilePath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.textBox_SearchFilePath.Enabled = false;
            this.textBox_SearchFilePath.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.textBox_SearchFilePath.ForeColor = System.Drawing.Color.Red;
            this.textBox_SearchFilePath.Location = new System.Drawing.Point(35, 88);
            this.textBox_SearchFilePath.Name = "textBox_SearchFilePath";
            this.textBox_SearchFilePath.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_SearchFilePath, false);
            this.textBox_SearchFilePath.Size = new System.Drawing.Size(443, 21);
            this.textBox_SearchFilePath.TabIndex = 872;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.textBox_Start);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.textBox_End);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.textBox_EmpNo);
            this.groupBox1.Controls.Add(this.textBox_Date);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.textBox_TimeLeave1);
            this.groupBox1.Controls.Add(this.textBox_TimeT1);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(7, 114);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(471, 78);
            this.groupBox1.TabIndex = 868;
            this.groupBox1.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(213, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(120, 13);
            this.label6.TabIndex = 871;
            this.label6.Text = "وقت الإنصراف الرسمي :";
            // 
            // textBox_Start
            // 
            this.textBox_Start.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.textBox_Start.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.textBox_Start.Location = new System.Drawing.Point(168, 13);
            this.textBox_Start.MaxLength = 2;
            this.textBox_Start.Name = "textBox_Start";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_Start, false);
            this.textBox_Start.Size = new System.Drawing.Size(43, 22);
            this.textBox_Start.TabIndex = 3;
            this.textBox_Start.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_Start.Click += new System.EventHandler(this.textBox_Start_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(213, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(120, 13);
            this.label7.TabIndex = 872;
            this.label7.Text = "وقت الحضــــور الرسمي:";
            // 
            // textBox_End
            // 
            this.textBox_End.BackColor = System.Drawing.Color.White;
            this.textBox_End.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.textBox_End.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.textBox_End.Location = new System.Drawing.Point(168, 46);
            this.textBox_End.MaxLength = 2;
            this.textBox_End.Name = "textBox_End";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_End, false);
            this.textBox_End.Size = new System.Drawing.Size(43, 22);
            this.textBox_End.TabIndex = 4;
            this.textBox_End.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_End.Click += new System.EventHandler(this.textBox_End_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(396, 18);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 13);
            this.label8.TabIndex = 866;
            this.label8.Text = "رقم الموظف :";
            // 
            // textBox_EmpNo
            // 
            this.textBox_EmpNo.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.textBox_EmpNo.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.textBox_EmpNo.Location = new System.Drawing.Point(352, 13);
            this.textBox_EmpNo.MaxLength = 2;
            this.textBox_EmpNo.Name = "textBox_EmpNo";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_EmpNo, false);
            this.textBox_EmpNo.Size = new System.Drawing.Size(43, 22);
            this.textBox_EmpNo.TabIndex = 1;
            this.textBox_EmpNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_EmpNo.Click += new System.EventHandler(this.textBox_EmpNo_Click);
            // 
            // textBox_Date
            // 
            this.textBox_Date.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.textBox_Date.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.textBox_Date.Location = new System.Drawing.Point(352, 46);
            this.textBox_Date.MaxLength = 2;
            this.textBox_Date.Name = "textBox_Date";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_Date, false);
            this.textBox_Date.Size = new System.Drawing.Size(43, 22);
            this.textBox_Date.TabIndex = 2;
            this.textBox_Date.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_Date.Click += new System.EventHandler(this.textBox_Date_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label9.Location = new System.Drawing.Point(397, 51);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 13);
            this.label9.TabIndex = 868;
            this.label9.Text = "تاريخ الدوام :";
            // 
            // textBox_TimeLeave1
            // 
            this.textBox_TimeLeave1.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.textBox_TimeLeave1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.textBox_TimeLeave1.ForeColor = System.Drawing.Color.White;
            this.textBox_TimeLeave1.Location = new System.Drawing.Point(6, 46);
            this.textBox_TimeLeave1.MaxLength = 2;
            this.textBox_TimeLeave1.Name = "textBox_TimeLeave1";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_TimeLeave1, false);
            this.textBox_TimeLeave1.Size = new System.Drawing.Size(43, 22);
            this.textBox_TimeLeave1.TabIndex = 6;
            this.textBox_TimeLeave1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_TimeLeave1.Click += new System.EventHandler(this.textBox_TimeLeave1_Click);
            // 
            // textBox_TimeT1
            // 
            this.textBox_TimeT1.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.textBox_TimeT1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.textBox_TimeT1.ForeColor = System.Drawing.Color.White;
            this.textBox_TimeT1.Location = new System.Drawing.Point(6, 13);
            this.textBox_TimeT1.MaxLength = 2;
            this.textBox_TimeT1.Name = "textBox_TimeT1";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_TimeT1, false);
            this.textBox_TimeT1.Size = new System.Drawing.Size(43, 22);
            this.textBox_TimeT1.TabIndex = 5;
            this.textBox_TimeT1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_TimeT1.Click += new System.EventHandler(this.textBox_TimeT1_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label10.Location = new System.Drawing.Point(51, 51);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(108, 13);
            this.label10.TabIndex = 106;
            this.label10.Text = "وقت إنصراف الموظف :";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label11.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label11.Location = new System.Drawing.Point(51, 18);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(100, 13);
            this.label11.TabIndex = 864;
            this.label11.Text = "وقت حضور الموظف :";
            // 
            // ExcelGridView
            // 
            this.ExcelGridView.AllowUserToAddRows = false;
            this.ExcelGridView.AllowUserToDeleteRows = false;
            this.ExcelGridView.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ExcelGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Red;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ExcelGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.ExcelGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ExcelGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.ExcelGridView.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ExcelGridView.Location = new System.Drawing.Point(0, 202);
            this.ExcelGridView.MultiSelect = false;
            this.ExcelGridView.Name = "ExcelGridView";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Red;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ExcelGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.ExcelGridView.RowHeadersVisible = false;
            this.ExcelGridView.Size = new System.Drawing.Size(491, 200);
            this.ExcelGridView.TabIndex = 855;
            this.ExcelGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.ExcelGridView_CellEndEdit);
            this.ExcelGridView.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.ExcelGridView_DataBindingComplete);
            // 
            // panelEx_Attend
            // 
            this.panelEx_Attend.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx_Attend.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx_Attend.Controls.Add(this.panel5);
            this.panelEx_Attend.Controls.Add(this.panel4);
            this.panelEx_Attend.Controls.Add(this.panel2);
            this.panelEx_Attend.Controls.Add(this.textBox_DateOMR);
            this.panelEx_Attend.Controls.Add(this.textBox_Day);
            this.panelEx_Attend.Controls.Add(this.bubbleButton_Ok);
            this.panelEx_Attend.Controls.Add(this.bubbleButton_Leave);
            this.panelEx_Attend.Controls.Add(this.bubbleButton_RepAttend);
            this.panelEx_Attend.Controls.Add(this.panel3);
            this.panelEx_Attend.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx_Attend.Location = new System.Drawing.Point(0, 0);
            this.panelEx_Attend.Name = "panelEx_Attend";
            this.panelEx_Attend.Size = new System.Drawing.Size(491, 402);
            this.panelEx_Attend.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx_Attend.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx_Attend.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx_Attend.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx_Attend.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx_Attend.Style.GradientAngle = 90;
            this.panelEx_Attend.TabIndex = 6779;
            this.panelEx_Attend.Visible = false;
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.textBox_LeaveTimeOMR2);
            this.panel5.Controls.Add(this.textBox_TimeOMR2);
            this.panel5.Controls.Add(this.label15);
            this.panel5.Controls.Add(this.label21);
            this.panel5.Location = new System.Drawing.Point(548, 407);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(427, 41);
            this.panel5.TabIndex = 1606;
            // 
            // textBox_LeaveTimeOMR2
            // 
            this.textBox_LeaveTimeOMR2.Location = new System.Drawing.Point(7, 9);
            this.textBox_LeaveTimeOMR2.Mask = "##:##";
            this.textBox_LeaveTimeOMR2.Name = "textBox_LeaveTimeOMR2";
            this.textBox_LeaveTimeOMR2.ReadOnly = true;
            this.textBox_LeaveTimeOMR2.Size = new System.Drawing.Size(71, 20);
            this.textBox_LeaveTimeOMR2.TabIndex = 138;
            this.textBox_LeaveTimeOMR2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_TimeOMR2
            // 
            this.textBox_TimeOMR2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.textBox_TimeOMR2.Location = new System.Drawing.Point(237, 9);
            this.textBox_TimeOMR2.Mask = "##:##";
            this.textBox_TimeOMR2.Name = "textBox_TimeOMR2";
            this.textBox_TimeOMR2.ReadOnly = true;
            this.textBox_TimeOMR2.Size = new System.Drawing.Size(71, 20);
            this.textBox_TimeOMR2.TabIndex = 137;
            this.textBox_TimeOMR2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label15.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label15.Location = new System.Drawing.Point(81, 13);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(116, 13);
            this.label15.TabIndex = 83;
            this.label15.Text = "الإنصراف للفترة الثانيـة :";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.BackColor = System.Drawing.Color.Transparent;
            this.label21.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label21.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label21.Location = new System.Drawing.Point(310, 13);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(107, 13);
            this.label21.TabIndex = 75;
            this.label21.Text = "الحضـور للفترة الثانية :";
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.textBox_LeaveTimeOMR1);
            this.panel4.Controls.Add(this.textBox_TimeOMR1);
            this.panel4.Controls.Add(this.label24);
            this.panel4.Controls.Add(this.label25);
            this.panel4.Location = new System.Drawing.Point(548, 363);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(427, 41);
            this.panel4.TabIndex = 1605;
            // 
            // textBox_LeaveTimeOMR1
            // 
            this.textBox_LeaveTimeOMR1.Location = new System.Drawing.Point(7, 10);
            this.textBox_LeaveTimeOMR1.Mask = "##:##";
            this.textBox_LeaveTimeOMR1.Name = "textBox_LeaveTimeOMR1";
            this.textBox_LeaveTimeOMR1.ReadOnly = true;
            this.textBox_LeaveTimeOMR1.Size = new System.Drawing.Size(71, 20);
            this.textBox_LeaveTimeOMR1.TabIndex = 136;
            this.textBox_LeaveTimeOMR1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_TimeOMR1
            // 
            this.textBox_TimeOMR1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.textBox_TimeOMR1.Location = new System.Drawing.Point(237, 10);
            this.textBox_TimeOMR1.Mask = "##:##";
            this.textBox_TimeOMR1.Name = "textBox_TimeOMR1";
            this.textBox_TimeOMR1.ReadOnly = true;
            this.textBox_TimeOMR1.Size = new System.Drawing.Size(71, 20);
            this.textBox_TimeOMR1.TabIndex = 134;
            this.textBox_TimeOMR1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.BackColor = System.Drawing.Color.Transparent;
            this.label24.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label24.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label24.Location = new System.Drawing.Point(81, 13);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(116, 13);
            this.label24.TabIndex = 83;
            this.label24.Text = "الإنصراف للفترة الأولى :";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.BackColor = System.Drawing.Color.Transparent;
            this.label25.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label25.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label25.Location = new System.Drawing.Point(310, 13);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(107, 13);
            this.label25.TabIndex = 75;
            this.label25.Text = "الحضور للفترة الأولى :";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.radioButton_BreakDayOMR);
            this.panel2.Controls.Add(this.radioButton_PeriodsOMR2);
            this.panel2.Controls.Add(this.radioButton_PeriodsOMR1);
            this.panel2.Location = new System.Drawing.Point(548, 319);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(427, 41);
            this.panel2.TabIndex = 1604;
            // 
            // radioButton_BreakDayOMR
            // 
            this.radioButton_BreakDayOMR.AutoCheck = false;
            this.radioButton_BreakDayOMR.AutoSize = true;
            this.radioButton_BreakDayOMR.BackColor = System.Drawing.Color.Transparent;
            this.radioButton_BreakDayOMR.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.radioButton_BreakDayOMR.ForeColor = System.Drawing.Color.RoyalBlue;
            this.radioButton_BreakDayOMR.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radioButton_BreakDayOMR.Location = new System.Drawing.Point(14, 11);
            this.radioButton_BreakDayOMR.Name = "radioButton_BreakDayOMR";
            this.radioButton_BreakDayOMR.Size = new System.Drawing.Size(70, 17);
            this.radioButton_BreakDayOMR.TabIndex = 116;
            this.radioButton_BreakDayOMR.Text = "راحـــــــة";
            this.radioButton_BreakDayOMR.UseVisualStyleBackColor = false;
            // 
            // radioButton_PeriodsOMR2
            // 
            this.radioButton_PeriodsOMR2.AutoCheck = false;
            this.radioButton_PeriodsOMR2.AutoSize = true;
            this.radioButton_PeriodsOMR2.BackColor = System.Drawing.Color.Transparent;
            this.radioButton_PeriodsOMR2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.radioButton_PeriodsOMR2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.radioButton_PeriodsOMR2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radioButton_PeriodsOMR2.Location = new System.Drawing.Point(168, 11);
            this.radioButton_PeriodsOMR2.Name = "radioButton_PeriodsOMR2";
            this.radioButton_PeriodsOMR2.Size = new System.Drawing.Size(76, 17);
            this.radioButton_PeriodsOMR2.TabIndex = 115;
            this.radioButton_PeriodsOMR2.Text = "فترتــــــان";
            this.radioButton_PeriodsOMR2.UseVisualStyleBackColor = false;
            // 
            // radioButton_PeriodsOMR1
            // 
            this.radioButton_PeriodsOMR1.AutoCheck = false;
            this.radioButton_PeriodsOMR1.AutoSize = true;
            this.radioButton_PeriodsOMR1.BackColor = System.Drawing.Color.Transparent;
            this.radioButton_PeriodsOMR1.Checked = true;
            this.radioButton_PeriodsOMR1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.radioButton_PeriodsOMR1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.radioButton_PeriodsOMR1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radioButton_PeriodsOMR1.Location = new System.Drawing.Point(326, 11);
            this.radioButton_PeriodsOMR1.Name = "radioButton_PeriodsOMR1";
            this.radioButton_PeriodsOMR1.Size = new System.Drawing.Size(89, 17);
            this.radioButton_PeriodsOMR1.TabIndex = 114;
            this.radioButton_PeriodsOMR1.TabStop = true;
            this.radioButton_PeriodsOMR1.Text = "فتـــرة واحدة";
            this.radioButton_PeriodsOMR1.UseVisualStyleBackColor = false;
            // 
            // textBox_DateOMR
            // 
            this.textBox_DateOMR.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.textBox_DateOMR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_DateOMR.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.textBox_DateOMR.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.textBox_DateOMR.Location = new System.Drawing.Point(259, 19);
            this.textBox_DateOMR.Name = "textBox_DateOMR";
            this.textBox_DateOMR.Size = new System.Drawing.Size(106, 20);
            this.textBox_DateOMR.TabIndex = 1603;
            this.textBox_DateOMR.Text = "--";
            this.textBox_DateOMR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox_Day
            // 
            this.textBox_Day.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.textBox_Day.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_Day.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.textBox_Day.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.textBox_Day.Location = new System.Drawing.Point(368, 19);
            this.textBox_Day.Name = "textBox_Day";
            this.textBox_Day.Size = new System.Drawing.Size(106, 20);
            this.textBox_Day.TabIndex = 1602;
            this.textBox_Day.Text = "--";
            this.textBox_Day.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.textBox_Day.TextChanged += new System.EventHandler(this.textBox_Day_TextChanged);
            // 
            // bubbleButton_Ok
            // 
            this.bubbleButton_Ok.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.bubbleButton_Ok.Checked = true;
            this.bubbleButton_Ok.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.bubbleButton_Ok.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.bubbleButton_Ok.Location = new System.Drawing.Point(329, 354);
            this.bubbleButton_Ok.Name = "bubbleButton_Ok";
            this.bubbleButton_Ok.Size = new System.Drawing.Size(150, 35);
            this.bubbleButton_Ok.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bubbleButton_Ok.Symbol = "";
            this.bubbleButton_Ok.SymbolSize = 16F;
            this.bubbleButton_Ok.TabIndex = 1599;
            this.bubbleButton_Ok.Text = "حضـــــــــور";
            this.bubbleButton_Ok.TextColor = System.Drawing.Color.Navy;
            this.bubbleButton_Ok.EnabledChanged += new System.EventHandler(this.bubbleButton_Ok_EnabledChanged);
            this.bubbleButton_Ok.Click += new System.EventHandler(this.bubbleButton_Ok_Click);
            // 
            // bubbleButton_Leave
            // 
            this.bubbleButton_Leave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.bubbleButton_Leave.Checked = true;
            this.bubbleButton_Leave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.bubbleButton_Leave.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.bubbleButton_Leave.Location = new System.Drawing.Point(172, 353);
            this.bubbleButton_Leave.Name = "bubbleButton_Leave";
            this.bubbleButton_Leave.Size = new System.Drawing.Size(150, 35);
            this.bubbleButton_Leave.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bubbleButton_Leave.Symbol = "";
            this.bubbleButton_Leave.SymbolSize = 16F;
            this.bubbleButton_Leave.TabIndex = 1598;
            this.bubbleButton_Leave.Text = "إنصـــــراف";
            this.bubbleButton_Leave.TextColor = System.Drawing.Color.Navy;
            this.bubbleButton_Leave.Click += new System.EventHandler(this.bubbleButton_Leave_Click);
            // 
            // bubbleButton_RepAttend
            // 
            this.bubbleButton_RepAttend.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.bubbleButton_RepAttend.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.bubbleButton_RepAttend.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.bubbleButton_RepAttend.Location = new System.Drawing.Point(15, 353);
            this.bubbleButton_RepAttend.Name = "bubbleButton_RepAttend";
            this.bubbleButton_RepAttend.Size = new System.Drawing.Size(150, 35);
            this.bubbleButton_RepAttend.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bubbleButton_RepAttend.Symbol = "";
            this.bubbleButton_RepAttend.SymbolSize = 16F;
            this.bubbleButton_RepAttend.TabIndex = 1597;
            this.bubbleButton_RepAttend.Text = "كشــــــف";
            this.bubbleButton_RepAttend.TextColor = System.Drawing.Color.White;
            this.bubbleButton_RepAttend.Click += new System.EventHandler(this.bubbleButton_RepAttend_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.panel_PROJECTs);
            this.panel3.Controls.Add(this.textBox_Note);
            this.panel3.Controls.Add(this.textBox_Pass);
            this.panel3.Controls.Add(this.comboBox_Emp);
            this.panel3.Controls.Add(this.button_SrchEmp);
            this.panel3.Controls.Add(this.textBox_ComeTime);
            this.panel3.Controls.Add(this.textBox_LateTime);
            this.panel3.Controls.Add(this.textBox_ID);
            this.panel3.Controls.Add(this.label16);
            this.panel3.Controls.Add(this.label17);
            this.panel3.Controls.Add(this.label_TimeTimer);
            this.panel3.Controls.Add(this.label20);
            this.panel3.Controls.Add(this.label22);
            this.panel3.Controls.Add(this.label36);
            this.panel3.Location = new System.Drawing.Point(6, 5);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(475, 337);
            this.panel3.TabIndex = 87;
            // 
            // panel_PROJECTs
            // 
            this.panel_PROJECTs.Controls.Add(this.comboBox_PRoject);
            this.panel_PROJECTs.Controls.Add(this.button_ADDPRoject);
            this.panel_PROJECTs.Controls.Add(this.button_SrchPRoject);
            this.panel_PROJECTs.Controls.Add(this.label23);
            this.panel_PROJECTs.Enabled = false;
            this.panel_PROJECTs.Location = new System.Drawing.Point(7, 44);
            this.panel_PROJECTs.Name = "panel_PROJECTs";
            this.panel_PROJECTs.Size = new System.Drawing.Size(464, 53);
            this.panel_PROJECTs.TabIndex = 6695;
            // 
            // comboBox_PRoject
            // 
            this.comboBox_PRoject.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox_PRoject.DisplayMember = "Text";
            this.comboBox_PRoject.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBox_PRoject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_PRoject.FormattingEnabled = true;
            this.comboBox_PRoject.ItemHeight = 14;
            this.comboBox_PRoject.Location = new System.Drawing.Point(57, 23);
            this.comboBox_PRoject.Name = "comboBox_PRoject";
            this.comboBox_PRoject.Size = new System.Drawing.Size(277, 20);
            this.comboBox_PRoject.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBox_PRoject.TabIndex = 6681;
            // 
            // button_ADDPRoject
            // 
            this.button_ADDPRoject.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_ADDPRoject.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_ADDPRoject.Location = new System.Drawing.Point(3, 23);
            this.button_ADDPRoject.Name = "button_ADDPRoject";
            this.button_ADDPRoject.Size = new System.Drawing.Size(26, 20);
            this.button_ADDPRoject.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_ADDPRoject.Symbol = "";
            this.button_ADDPRoject.SymbolSize = 11F;
            this.button_ADDPRoject.TabIndex = 6683;
            this.button_ADDPRoject.TextColor = System.Drawing.Color.SteelBlue;
            this.button_ADDPRoject.Click += new System.EventHandler(this.button_ADDPRoject_Click);
            // 
            // button_SrchPRoject
            // 
            this.button_SrchPRoject.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchPRoject.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchPRoject.Location = new System.Drawing.Point(30, 23);
            this.button_SrchPRoject.Name = "button_SrchPRoject";
            this.button_SrchPRoject.Size = new System.Drawing.Size(26, 20);
            this.button_SrchPRoject.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchPRoject.Symbol = "";
            this.button_SrchPRoject.SymbolSize = 12F;
            this.button_SrchPRoject.TabIndex = 6682;
            this.button_SrchPRoject.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchPRoject.Click += new System.EventHandler(this.button_SrchPRoject_Click);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.BackColor = System.Drawing.Color.Transparent;
            this.label23.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label23.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label23.Location = new System.Drawing.Point(336, 23);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(125, 13);
            this.label23.TabIndex = 6680;
            this.label23.Text = "موقع العمل ( المشروع ) :";
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
            this.textBox_Note.Location = new System.Drawing.Point(6, 227);
            this.textBox_Note.Multiline = true;
            this.textBox_Note.Name = "textBox_Note";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_Note, false);
            this.textBox_Note.Size = new System.Drawing.Size(463, 105);
            this.textBox_Note.TabIndex = 6694;
            this.textBox_Note.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_Note.WatermarkText = "الملاحظـــــــات";
            // 
            // textBox_Pass
            // 
            this.textBox_Pass.BackColor = System.Drawing.Color.AliceBlue;
            // 
            // 
            // 
            this.textBox_Pass.Border.Class = "TextBoxBorder";
            this.textBox_Pass.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBox_Pass.ButtonCustom.Text = "+";
            this.textBox_Pass.ForeColor = System.Drawing.Color.Black;
            this.textBox_Pass.Location = new System.Drawing.Point(9, 105);
            this.textBox_Pass.Name = "textBox_Pass";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_Pass, false);
            this.textBox_Pass.Size = new System.Drawing.Size(110, 20);
            this.textBox_Pass.TabIndex = 6686;
            this.textBox_Pass.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_Pass.WatermarkColor = System.Drawing.Color.RosyBrown;
            this.textBox_Pass.WatermarkFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Pass.WatermarkImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.textBox_Pass.WatermarkText = "كلمة السر";
            this.textBox_Pass.ButtonCustomClick += new System.EventHandler(this.textBox_Pass_ButtonCustomClick);
            this.textBox_Pass.TextChanged += new System.EventHandler(this.textBox_Pass_TextChanged);
            this.textBox_Pass.Leave += new System.EventHandler(this.textBox_Pass_Leave);
            // 
            // comboBox_Emp
            // 
            this.comboBox_Emp.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox_Emp.DisplayMember = "Text";
            this.comboBox_Emp.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBox_Emp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Emp.FormattingEnabled = true;
            this.comboBox_Emp.ItemHeight = 14;
            this.comboBox_Emp.Location = new System.Drawing.Point(148, 105);
            this.comboBox_Emp.Name = "comboBox_Emp";
            this.comboBox_Emp.Size = new System.Drawing.Size(193, 20);
            this.comboBox_Emp.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBox_Emp.TabIndex = 6684;
            this.comboBox_Emp.SelectedValueChanged += new System.EventHandler(this.comboBox_Emp_SelectedValueChanged);
            // 
            // button_SrchEmp
            // 
            this.button_SrchEmp.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchEmp.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchEmp.Location = new System.Drawing.Point(121, 105);
            this.button_SrchEmp.Name = "button_SrchEmp";
            this.button_SrchEmp.Size = new System.Drawing.Size(26, 20);
            this.button_SrchEmp.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchEmp.Symbol = "";
            this.button_SrchEmp.SymbolSize = 12F;
            this.button_SrchEmp.TabIndex = 6685;
            this.button_SrchEmp.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchEmp.Click += new System.EventHandler(this.button_SrchEmp_Click);
            // 
            // textBox_ComeTime
            // 
            this.textBox_ComeTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.textBox_ComeTime.Location = new System.Drawing.Point(244, 147);
            this.textBox_ComeTime.Mask = "##:##";
            this.textBox_ComeTime.Name = "textBox_ComeTime";
            this.textBox_ComeTime.Size = new System.Drawing.Size(97, 20);
            this.textBox_ComeTime.TabIndex = 477;
            this.textBox_ComeTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_ComeTime.Click += new System.EventHandler(this.textBox_ComeTime_Click);
            this.textBox_ComeTime.Leave += new System.EventHandler(this.textBox_ComeTime_Leave);
            // 
            // textBox_LateTime
            // 
            this.textBox_LateTime.AllowEmptyState = false;
            // 
            // 
            // 
            this.textBox_LateTime.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.textBox_LateTime.BackgroundStyle.Class = "DateTimeInputBackground";
            this.textBox_LateTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBox_LateTime.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.textBox_LateTime.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.textBox_LateTime.ForeColor = System.Drawing.Color.White;
            this.textBox_LateTime.Increment = 1D;
            this.textBox_LateTime.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.textBox_LateTime.IsInputReadOnly = true;
            this.textBox_LateTime.Location = new System.Drawing.Point(244, 189);
            this.textBox_LateTime.MinValue = 0D;
            this.textBox_LateTime.Name = "textBox_LateTime";
            this.textBox_LateTime.Size = new System.Drawing.Size(97, 21);
            this.textBox_LateTime.TabIndex = 4;
            // 
            // textBox_ID
            // 
            this.textBox_ID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.textBox_ID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_ID.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.textBox_ID.Location = new System.Drawing.Point(254, -62);
            this.textBox_ID.MaxLength = 6;
            this.textBox_ID.Name = "textBox_ID";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_ID, false);
            this.textBox_ID.Size = new System.Drawing.Size(82, 21);
            this.textBox_ID.TabIndex = 1;
            this.textBox_ID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_ID_KeyPress);
            this.textBox_ID.Leave += new System.EventHandler(this.textBox_ID_Leave);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label16.Location = new System.Drawing.Point(196, 193);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(47, 13);
            this.label16.TabIndex = 103;
            this.label16.Text = "( دقيقة )";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label17.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label17.Location = new System.Drawing.Point(343, 193);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(122, 13);
            this.label17.TabIndex = 101;
            this.label17.Text = "فتــرة التأخيـــــــــــــــــر :";
            // 
            // label_TimeTimer
            // 
            this.label_TimeTimer.AutoSize = true;
            this.label_TimeTimer.BackColor = System.Drawing.Color.Transparent;
            this.label_TimeTimer.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label_TimeTimer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label_TimeTimer.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_TimeTimer.Location = new System.Drawing.Point(163, 105);
            this.label_TimeTimer.Name = "label_TimeTimer";
            this.label_TimeTimer.Size = new System.Drawing.Size(0, 13);
            this.label_TimeTimer.TabIndex = 100;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.Transparent;
            this.label20.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label20.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label20.Location = new System.Drawing.Point(343, 151);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(123, 13);
            this.label20.TabIndex = 98;
            this.label20.Text = "وقت الوصــــــــــــــــــول :";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.BackColor = System.Drawing.Color.Transparent;
            this.label22.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label22.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label22.Location = new System.Drawing.Point(343, 109);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(124, 13);
            this.label22.TabIndex = 93;
            this.label22.Text = "الموظـــــــــــــــــــــــــف :";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.BackColor = System.Drawing.Color.Transparent;
            this.label36.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label36.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label36.Location = new System.Drawing.Point(340, -60);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(83, 13);
            this.label36.TabIndex = 83;
            this.label36.Text = "رقم الموظــف :";
            // 
            // panelEx_GeneralAttend
            // 
            this.panelEx_GeneralAttend.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx_GeneralAttend.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx_GeneralAttend.Controls.Add(this.groupPanel_Time2);
            this.panelEx_GeneralAttend.Controls.Add(this.groupPanel_Time1);
            this.panelEx_GeneralAttend.Controls.Add(this.groupPanel_Day);
            this.panelEx_GeneralAttend.Controls.Add(this.ButSetAllDays);
            this.panelEx_GeneralAttend.Controls.Add(this.ButOk);
            this.panelEx_GeneralAttend.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx_GeneralAttend.Location = new System.Drawing.Point(0, 0);
            this.panelEx_GeneralAttend.Name = "panelEx_GeneralAttend";
            this.panelEx_GeneralAttend.Size = new System.Drawing.Size(491, 402);
            this.panelEx_GeneralAttend.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx_GeneralAttend.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx_GeneralAttend.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx_GeneralAttend.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx_GeneralAttend.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx_GeneralAttend.Style.GradientAngle = 90;
            this.panelEx_GeneralAttend.TabIndex = 6777;
            this.panelEx_GeneralAttend.Visible = false;
            // 
            // groupPanel_Time2
            // 
            this.groupPanel_Time2.Controls.Add(this.textBox_LeaveTime2);
            this.groupPanel_Time2.Controls.Add(this.label3);
            this.groupPanel_Time2.Controls.Add(this.textBox_TimeAllow2);
            this.groupPanel_Time2.Controls.Add(this.label4);
            this.groupPanel_Time2.Controls.Add(this.textBox_Time2);
            this.groupPanel_Time2.Controls.Add(this.label5);
            this.groupPanel_Time2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.groupPanel_Time2.ForeColor = System.Drawing.Color.Navy;
            this.groupPanel_Time2.Location = new System.Drawing.Point(12, 173);
            this.groupPanel_Time2.Name = "groupPanel_Time2";
            this.groupPanel_Time2.Size = new System.Drawing.Size(224, 157);
            this.groupPanel_Time2.TabIndex = 1600;
            this.groupPanel_Time2.TabStop = false;
            this.groupPanel_Time2.Text = "الفترة الثانيـــة";
            // 
            // textBox_LeaveTime2
            // 
            this.textBox_LeaveTime2.Location = new System.Drawing.Point(39, 108);
            this.textBox_LeaveTime2.Mask = "##:##";
            this.textBox_LeaveTime2.Name = "textBox_LeaveTime2";
            this.textBox_LeaveTime2.Size = new System.Drawing.Size(78, 20);
            this.textBox_LeaveTime2.TabIndex = 142;
            this.textBox_LeaveTime2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_LeaveTime2.Click += new System.EventHandler(this.textBox_LeaveTime2_Click);
            this.textBox_LeaveTime2.Leave += new System.EventHandler(this.textBox_LeaveTime2_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(120, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 141;
            this.label3.Text = "الانصـــراف :";
            // 
            // textBox_TimeAllow2
            // 
            this.textBox_TimeAllow2.BackColor = System.Drawing.SystemColors.HotTrack;
            this.textBox_TimeAllow2.ForeColor = System.Drawing.Color.White;
            this.textBox_TimeAllow2.Location = new System.Drawing.Point(39, 69);
            this.textBox_TimeAllow2.Mask = "##:##";
            this.textBox_TimeAllow2.Name = "textBox_TimeAllow2";
            this.textBox_TimeAllow2.Size = new System.Drawing.Size(78, 20);
            this.textBox_TimeAllow2.TabIndex = 140;
            this.textBox_TimeAllow2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_TimeAllow2.Click += new System.EventHandler(this.textBox_TimeAllow2_Click);
            this.textBox_TimeAllow2.Leave += new System.EventHandler(this.textBox_TimeAllow2_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(120, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 139;
            this.label4.Text = "حتــــــــــى :";
            // 
            // textBox_Time2
            // 
            this.textBox_Time2.Location = new System.Drawing.Point(39, 29);
            this.textBox_Time2.Mask = "##:##";
            this.textBox_Time2.Name = "textBox_Time2";
            this.textBox_Time2.Size = new System.Drawing.Size(78, 20);
            this.textBox_Time2.TabIndex = 138;
            this.textBox_Time2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_Time2.Click += new System.EventHandler(this.textBox_Time2_Click);
            this.textBox_Time2.Leave += new System.EventHandler(this.textBox_Time2_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(120, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 137;
            this.label5.Text = "الحضــــــور :";
            // 
            // groupPanel_Time1
            // 
            this.groupPanel_Time1.Controls.Add(this.textBox_LeaveTime1);
            this.groupPanel_Time1.Controls.Add(this.label19);
            this.groupPanel_Time1.Controls.Add(this.textBox_TimeAllow1);
            this.groupPanel_Time1.Controls.Add(this.label18);
            this.groupPanel_Time1.Controls.Add(this.textBox_Time1);
            this.groupPanel_Time1.Controls.Add(this.label14);
            this.groupPanel_Time1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.groupPanel_Time1.ForeColor = System.Drawing.Color.Navy;
            this.groupPanel_Time1.Location = new System.Drawing.Point(252, 173);
            this.groupPanel_Time1.Name = "groupPanel_Time1";
            this.groupPanel_Time1.Size = new System.Drawing.Size(224, 157);
            this.groupPanel_Time1.TabIndex = 1599;
            this.groupPanel_Time1.TabStop = false;
            this.groupPanel_Time1.Text = "الفترة الأولــــي";
            // 
            // textBox_LeaveTime1
            // 
            this.textBox_LeaveTime1.Location = new System.Drawing.Point(39, 108);
            this.textBox_LeaveTime1.Mask = "##:##";
            this.textBox_LeaveTime1.Name = "textBox_LeaveTime1";
            this.textBox_LeaveTime1.Size = new System.Drawing.Size(78, 20);
            this.textBox_LeaveTime1.TabIndex = 142;
            this.textBox_LeaveTime1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_LeaveTime1.Click += new System.EventHandler(this.textBox_LeaveTime1_Click);
            this.textBox_LeaveTime1.Leave += new System.EventHandler(this.textBox_LeaveTime1_Leave);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.Color.Transparent;
            this.label19.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label19.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label19.Location = new System.Drawing.Point(120, 112);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(63, 13);
            this.label19.TabIndex = 141;
            this.label19.Text = "الانصـــراف :";
            // 
            // textBox_TimeAllow1
            // 
            this.textBox_TimeAllow1.BackColor = System.Drawing.SystemColors.HotTrack;
            this.textBox_TimeAllow1.ForeColor = System.Drawing.Color.White;
            this.textBox_TimeAllow1.Location = new System.Drawing.Point(39, 69);
            this.textBox_TimeAllow1.Mask = "##:##";
            this.textBox_TimeAllow1.Name = "textBox_TimeAllow1";
            this.textBox_TimeAllow1.Size = new System.Drawing.Size(78, 20);
            this.textBox_TimeAllow1.TabIndex = 140;
            this.textBox_TimeAllow1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_TimeAllow1.Click += new System.EventHandler(this.textBox_TimeAllow1_Click);
            this.textBox_TimeAllow1.Leave += new System.EventHandler(this.textBox_TimeAllow1_Leave);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.Transparent;
            this.label18.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label18.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label18.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label18.Location = new System.Drawing.Point(120, 73);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(66, 13);
            this.label18.TabIndex = 139;
            this.label18.Text = "حتــــــــــى :";
            // 
            // textBox_Time1
            // 
            this.textBox_Time1.Location = new System.Drawing.Point(39, 29);
            this.textBox_Time1.Mask = "##:##";
            this.textBox_Time1.Name = "textBox_Time1";
            this.textBox_Time1.Size = new System.Drawing.Size(78, 20);
            this.textBox_Time1.TabIndex = 138;
            this.textBox_Time1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_Time1.Click += new System.EventHandler(this.textBox_Time1_Click);
            this.textBox_Time1.Leave += new System.EventHandler(this.textBox_Time1_Leave);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label14.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label14.Location = new System.Drawing.Point(120, 33);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(63, 13);
            this.label14.TabIndex = 137;
            this.label14.Text = "الحضــــــور :";
            // 
            // groupPanel_Day
            // 
            this.groupPanel_Day.Controls.Add(this.radioButton_BreakDay);
            this.groupPanel_Day.Controls.Add(this.radioButton_Periods2);
            this.groupPanel_Day.Controls.Add(this.radioButton_Periods1);
            this.groupPanel_Day.Controls.Add(this.comboBox_Days);
            this.groupPanel_Day.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.groupPanel_Day.ForeColor = System.Drawing.Color.Navy;
            this.groupPanel_Day.Location = new System.Drawing.Point(12, 17);
            this.groupPanel_Day.Name = "groupPanel_Day";
            this.groupPanel_Day.Size = new System.Drawing.Size(464, 123);
            this.groupPanel_Day.TabIndex = 1598;
            this.groupPanel_Day.TabStop = false;
            // 
            // radioButton_BreakDay
            // 
            this.radioButton_BreakDay.AutoSize = true;
            this.radioButton_BreakDay.BackColor = System.Drawing.Color.Transparent;
            this.radioButton_BreakDay.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.radioButton_BreakDay.ForeColor = System.Drawing.Color.Red;
            this.radioButton_BreakDay.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radioButton_BreakDay.Location = new System.Drawing.Point(60, 74);
            this.radioButton_BreakDay.Name = "radioButton_BreakDay";
            this.radioButton_BreakDay.Size = new System.Drawing.Size(52, 18);
            this.radioButton_BreakDay.TabIndex = 1595;
            this.radioButton_BreakDay.Text = "راحة";
            this.radioButton_BreakDay.UseVisualStyleBackColor = false;
            this.radioButton_BreakDay.CheckedChanged += new System.EventHandler(this.radioButton_SatBreakDay_CheckedChanged);
            // 
            // radioButton_Periods2
            // 
            this.radioButton_Periods2.AutoSize = true;
            this.radioButton_Periods2.BackColor = System.Drawing.Color.Transparent;
            this.radioButton_Periods2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.radioButton_Periods2.ForeColor = System.Drawing.Color.Red;
            this.radioButton_Periods2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radioButton_Periods2.Location = new System.Drawing.Point(199, 74);
            this.radioButton_Periods2.Name = "radioButton_Periods2";
            this.radioButton_Periods2.Size = new System.Drawing.Size(60, 18);
            this.radioButton_Periods2.TabIndex = 1594;
            this.radioButton_Periods2.Text = "فترتان";
            this.radioButton_Periods2.UseVisualStyleBackColor = false;
            this.radioButton_Periods2.CheckedChanged += new System.EventHandler(this.radioButton_SatPeriods2_CheckedChanged);
            // 
            // radioButton_Periods1
            // 
            this.radioButton_Periods1.AutoSize = true;
            this.radioButton_Periods1.BackColor = System.Drawing.Color.Transparent;
            this.radioButton_Periods1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.radioButton_Periods1.ForeColor = System.Drawing.Color.Red;
            this.radioButton_Periods1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radioButton_Periods1.Location = new System.Drawing.Point(346, 74);
            this.radioButton_Periods1.Name = "radioButton_Periods1";
            this.radioButton_Periods1.Size = new System.Drawing.Size(59, 18);
            this.radioButton_Periods1.TabIndex = 1593;
            this.radioButton_Periods1.Text = "فتـــرة";
            this.radioButton_Periods1.UseVisualStyleBackColor = false;
            this.radioButton_Periods1.CheckedChanged += new System.EventHandler(this.radioButton_SatPeriods1_CheckedChanged);
            // 
            // comboBox_Days
            // 
            this.comboBox_Days.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox_Days.DisplayMember = "Text";
            this.comboBox_Days.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBox_Days.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Days.FormattingEnabled = true;
            this.comboBox_Days.ItemHeight = 14;
            this.comboBox_Days.Location = new System.Drawing.Point(93, 31);
            this.comboBox_Days.Name = "comboBox_Days";
            this.comboBox_Days.Size = new System.Drawing.Size(294, 20);
            this.comboBox_Days.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBox_Days.TabIndex = 1592;
            // 
            // ButSetAllDays
            // 
            this.ButSetAllDays.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.ButSetAllDays.Checked = true;
            this.ButSetAllDays.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.ButSetAllDays.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.ButSetAllDays.Location = new System.Drawing.Point(16, 351);
            this.ButSetAllDays.Name = "ButSetAllDays";
            this.ButSetAllDays.Size = new System.Drawing.Size(220, 35);
            this.ButSetAllDays.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ButSetAllDays.Symbol = "";
            this.ButSetAllDays.SymbolSize = 16F;
            this.ButSetAllDays.TabIndex = 1596;
            this.ButSetAllDays.Text = "تعميم لكل ايام الأسبوع";
            this.ButSetAllDays.TextColor = System.Drawing.Color.Black;
            this.ButSetAllDays.Click += new System.EventHandler(this.ButSetAllDays_Click);
            // 
            // ButOk
            // 
            this.ButOk.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.ButOk.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.ButOk.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.ButOk.Location = new System.Drawing.Point(250, 351);
            this.ButOk.Name = "ButOk";
            this.ButOk.Size = new System.Drawing.Size(220, 35);
            this.ButOk.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ButOk.Symbol = "";
            this.ButOk.SymbolSize = 16F;
            this.ButOk.TabIndex = 1595;
            this.ButOk.Text = "تعميم حسب اليوم";
            this.ButOk.TextColor = System.Drawing.Color.White;
            this.ButOk.Click += new System.EventHandler(this.ButOk_Click);
            // 
            // panelEx_LateAttend
            // 
            this.panelEx_LateAttend.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx_LateAttend.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx_LateAttend.Controls.Add(this.button_Relay);
            this.panelEx_LateAttend.Controls.Add(this.button_OpenLate);
            this.panelEx_LateAttend.Controls.Add(this.comboBox_Job);
            this.panelEx_LateAttend.Controls.Add(this.label32);
            this.panelEx_LateAttend.Controls.Add(this.comboBox_Section);
            this.panelEx_LateAttend.Controls.Add(this.label33);
            this.panelEx_LateAttend.Controls.Add(this.comboBox_Dept);
            this.panelEx_LateAttend.Controls.Add(this.label34);
            this.panelEx_LateAttend.Controls.Add(this.textBox_DateLate);
            this.panelEx_LateAttend.Controls.Add(this.label31);
            this.panelEx_LateAttend.Controls.Add(this.DataGridViewX_RepResult);
            this.panelEx_LateAttend.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx_LateAttend.Location = new System.Drawing.Point(0, 0);
            this.panelEx_LateAttend.Name = "panelEx_LateAttend";
            this.panelEx_LateAttend.Size = new System.Drawing.Size(491, 402);
            this.panelEx_LateAttend.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx_LateAttend.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx_LateAttend.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx_LateAttend.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx_LateAttend.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx_LateAttend.Style.GradientAngle = 90;
            this.panelEx_LateAttend.TabIndex = 6782;
            this.panelEx_LateAttend.Visible = false;
            // 
            // button_Relay
            // 
            this.button_Relay.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_Relay.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.button_Relay.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.button_Relay.Location = new System.Drawing.Point(45, 92);
            this.button_Relay.Name = "button_Relay";
            this.button_Relay.Size = new System.Drawing.Size(119, 33);
            this.button_Relay.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_Relay.Symbol = "";
            this.button_Relay.SymbolSize = 16F;
            this.button_Relay.TabIndex = 1600;
            this.button_Relay.Text = "معالجة النتائج";
            this.button_Relay.TextColor = System.Drawing.Color.White;
            this.button_Relay.Click += new System.EventHandler(this.button_Relay_Click);
            // 
            // button_OpenLate
            // 
            this.button_OpenLate.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_OpenLate.Checked = true;
            this.button_OpenLate.ColorTable = DevComponents.DotNetBar.eButtonColor.Blue;
            this.button_OpenLate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.button_OpenLate.Location = new System.Drawing.Point(166, 92);
            this.button_OpenLate.Name = "button_OpenLate";
            this.button_OpenLate.Size = new System.Drawing.Size(119, 33);
            this.button_OpenLate.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2003;
            this.button_OpenLate.SubItemsExpandWidth = 15;
            this.button_OpenLate.Symbol = "";
            this.button_OpenLate.SymbolSize = 13F;
            this.button_OpenLate.TabIndex = 1599;
            this.button_OpenLate.Text = "عرض البيانات";
            this.button_OpenLate.Tooltip = "إستعراض";
            this.button_OpenLate.Click += new System.EventHandler(this.button_OpenLate_Click);
            // 
            // comboBox_Job
            // 
            this.comboBox_Job.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox_Job.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.comboBox_Job.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Job.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboBox_Job.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.comboBox_Job.ForeColor = System.Drawing.Color.White;
            this.comboBox_Job.FormattingEnabled = true;
            this.comboBox_Job.Location = new System.Drawing.Point(47, 66);
            this.comboBox_Job.Name = "comboBox_Job";
            this.comboBox_Job.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.comboBox_Job.Size = new System.Drawing.Size(347, 21);
            this.comboBox_Job.TabIndex = 872;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.BackColor = System.Drawing.Color.Transparent;
            this.label32.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label32.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label32.Location = new System.Drawing.Point(398, 70);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(51, 13);
            this.label32.TabIndex = 875;
            this.label32.Text = "الـوظيفة :";
            // 
            // comboBox_Section
            // 
            this.comboBox_Section.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox_Section.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.comboBox_Section.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Section.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboBox_Section.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.comboBox_Section.ForeColor = System.Drawing.Color.White;
            this.comboBox_Section.FormattingEnabled = true;
            this.comboBox_Section.Location = new System.Drawing.Point(47, 39);
            this.comboBox_Section.Name = "comboBox_Section";
            this.comboBox_Section.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.comboBox_Section.Size = new System.Drawing.Size(347, 21);
            this.comboBox_Section.TabIndex = 871;
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.BackColor = System.Drawing.Color.Transparent;
            this.label33.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label33.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label33.Location = new System.Drawing.Point(398, 43);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(52, 13);
            this.label33.TabIndex = 874;
            this.label33.Text = "القســم :";
            // 
            // comboBox_Dept
            // 
            this.comboBox_Dept.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox_Dept.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.comboBox_Dept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Dept.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboBox_Dept.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.comboBox_Dept.ForeColor = System.Drawing.Color.White;
            this.comboBox_Dept.FormattingEnabled = true;
            this.comboBox_Dept.Location = new System.Drawing.Point(47, 12);
            this.comboBox_Dept.Name = "comboBox_Dept";
            this.comboBox_Dept.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.comboBox_Dept.Size = new System.Drawing.Size(347, 21);
            this.comboBox_Dept.TabIndex = 870;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.BackColor = System.Drawing.Color.Transparent;
            this.label34.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label34.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label34.Location = new System.Drawing.Point(398, 16);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(41, 13);
            this.label34.TabIndex = 873;
            this.label34.Text = "الإدارة :";
            // 
            // textBox_DateLate
            // 
            this.textBox_DateLate.BackColor = System.Drawing.Color.Red;
            this.textBox_DateLate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.textBox_DateLate.ForeColor = System.Drawing.Color.White;
            this.textBox_DateLate.Location = new System.Drawing.Point(291, 102);
            this.textBox_DateLate.Mask = "0000/00";
            this.textBox_DateLate.Name = "textBox_DateLate";
            this.textBox_DateLate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox_DateLate.Size = new System.Drawing.Size(102, 21);
            this.textBox_DateLate.TabIndex = 865;
            this.textBox_DateLate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_DateLate.Click += new System.EventHandler(this.textBox_DateLate_Click);
            this.textBox_DateLate.Leave += new System.EventHandler(this.textBox_DateLate_Leave);
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.BackColor = System.Drawing.Color.Transparent;
            this.label31.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label31.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label31.Location = new System.Drawing.Point(398, 106);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(55, 13);
            this.label31.TabIndex = 869;
            this.label31.Text = "الشهــــر:";
            // 
            // DataGridViewX_RepResult
            // 
            this.DataGridViewX_RepResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DataGridViewX_RepResult.BackColor = System.Drawing.SystemColors.ControlLight;
            background1.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.DataGridViewX_RepResult.DefaultVisualStyles.AlternateRowCellStyles.Default.Background = background1;
            this.DataGridViewX_RepResult.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            this.DataGridViewX_RepResult.ForeColor = System.Drawing.Color.Black;
            this.DataGridViewX_RepResult.HScrollBarVisible = false;
            this.DataGridViewX_RepResult.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.DataGridViewX_RepResult.Location = new System.Drawing.Point(3, 132);
            this.DataGridViewX_RepResult.Name = "DataGridViewX_RepResult";
            this.DataGridViewX_RepResult.PrimaryGrid.AllowEdit = false;
            this.DataGridViewX_RepResult.PrimaryGrid.ColumnHeader.RowHeight = 30;
            gridColumn3.Visible = false;
            gridColumn4.Visible = false;
            this.DataGridViewX_RepResult.PrimaryGrid.Columns.Add(gridColumn1);
            this.DataGridViewX_RepResult.PrimaryGrid.Columns.Add(gridColumn2);
            this.DataGridViewX_RepResult.PrimaryGrid.Columns.Add(gridColumn3);
            this.DataGridViewX_RepResult.PrimaryGrid.Columns.Add(gridColumn4);
            this.DataGridViewX_RepResult.PrimaryGrid.Columns.Add(gridColumn5);
            this.DataGridViewX_RepResult.PrimaryGrid.Columns.Add(gridColumn6);
            this.DataGridViewX_RepResult.PrimaryGrid.Columns.Add(gridColumn7);
            this.DataGridViewX_RepResult.PrimaryGrid.Columns.Add(gridColumn8);
            this.DataGridViewX_RepResult.PrimaryGrid.DefaultRowHeight = 24;
            this.DataGridViewX_RepResult.PrimaryGrid.DefaultVisualStyles.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            this.DataGridViewX_RepResult.PrimaryGrid.DefaultVisualStyles.FilterColumnHeaderStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            this.DataGridViewX_RepResult.PrimaryGrid.EnableColumnFiltering = true;
            this.DataGridViewX_RepResult.PrimaryGrid.EnableFiltering = true;
            this.DataGridViewX_RepResult.PrimaryGrid.EnableRowFiltering = true;
            this.DataGridViewX_RepResult.PrimaryGrid.Filter.Visible = true;
            this.DataGridViewX_RepResult.PrimaryGrid.FilterLevel = ((DevComponents.DotNetBar.SuperGrid.FilterLevel)((DevComponents.DotNetBar.SuperGrid.FilterLevel.Root | DevComponents.DotNetBar.SuperGrid.FilterLevel.Expanded)));
            this.DataGridViewX_RepResult.PrimaryGrid.FilterMatchType = DevComponents.DotNetBar.SuperGrid.FilterMatchType.RegularExpressions;
            this.DataGridViewX_RepResult.PrimaryGrid.NullString = "<<null>>";
            this.DataGridViewX_RepResult.PrimaryGrid.RowHeaderWidth = 45;
            this.DataGridViewX_RepResult.PrimaryGrid.ShowRowGridIndex = true;
            this.DataGridViewX_RepResult.PrimaryGrid.ShowRowHeaders = false;
            this.DataGridViewX_RepResult.PrimaryGrid.UseAlternateRowStyle = true;
            this.DataGridViewX_RepResult.Size = new System.Drawing.Size(483, 266);
            this.DataGridViewX_RepResult.TabIndex = 868;
            // 
            // panelEx_EditAttend
            // 
            this.panelEx_EditAttend.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx_EditAttend.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx_EditAttend.Controls.Add(this.dataGridViewX_RepDetils);
            this.panelEx_EditAttend.Controls.Add(this.button_Save);
            this.panelEx_EditAttend.Controls.Add(this.comboBox_EmpNo);
            this.panelEx_EditAttend.Controls.Add(this.button_Open);
            this.panelEx_EditAttend.Controls.Add(this.button_SEmp);
            this.panelEx_EditAttend.Controls.Add(this.textBox_DateEdit);
            this.panelEx_EditAttend.Controls.Add(this.label29);
            this.panelEx_EditAttend.Controls.Add(this.label30);
            this.panelEx_EditAttend.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx_EditAttend.Location = new System.Drawing.Point(0, 0);
            this.panelEx_EditAttend.Name = "panelEx_EditAttend";
            this.panelEx_EditAttend.Size = new System.Drawing.Size(491, 402);
            this.panelEx_EditAttend.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx_EditAttend.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx_EditAttend.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx_EditAttend.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx_EditAttend.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx_EditAttend.Style.GradientAngle = 90;
            this.panelEx_EditAttend.TabIndex = 6781;
            this.panelEx_EditAttend.Visible = false;
            // 
            // dataGridViewX_RepDetils
            // 
            this.dataGridViewX_RepDetils.AllowUserToAddRows = false;
            this.dataGridViewX_RepDetils.AllowUserToDeleteRows = false;
            this.dataGridViewX_RepDetils.AllowUserToResizeColumns = false;
            this.dataGridViewX_RepDetils.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.White;
            this.dataGridViewX_RepDetils.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewX_RepDetils.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dataGridViewX_RepDetils.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewX_RepDetils.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewX_RepDetils.ColumnHeadersHeight = 45;
            this.dataGridViewX_RepDetils.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewX_RepDetils.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.vDate,
            this.vDay,
            this.vTime1,
            this.vLeaveTime1,
            this.vTime2,
            this.vLeaveTime2,
            this.vLateTime,
            this.vNote,
            this.vEmpID,
            this.AttTime1,
            this.AttTime2,
            this.AttLeaveTime1,
            this.AttLeaveTime2,
            this.Pardon1,
            this.Pardon2,
            this.DateEdi,
            this.UsrName});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewX_RepDetils.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewX_RepDetils.EnableHeadersVisualStyles = false;
            this.dataGridViewX_RepDetils.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.dataGridViewX_RepDetils.HighlightSelectedColumnHeaders = false;
            this.dataGridViewX_RepDetils.Location = new System.Drawing.Point(2, 104);
            this.dataGridViewX_RepDetils.MultiSelect = false;
            this.dataGridViewX_RepDetils.Name = "dataGridViewX_RepDetils";
            this.dataGridViewX_RepDetils.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dataGridViewX_RepDetils.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewX_RepDetils.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewX_RepDetils.RowHeadersVisible = false;
            this.dataGridViewX_RepDetils.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.White;
            this.dataGridViewX_RepDetils.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewX_RepDetils.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewX_RepDetils.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.dataGridViewX_RepDetils.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewX_RepDetils.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            this.dataGridViewX_RepDetils.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewX_RepDetils.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridViewX_RepDetils.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridViewX_RepDetils.Size = new System.Drawing.Size(483, 293);
            this.dataGridViewX_RepDetils.TabIndex = 6689;
            this.dataGridViewX_RepDetils.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridViewX_RepDetils_CellBeginEdit);
            this.dataGridViewX_RepDetils.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewX_RepDetils_CellEndEdit);
            // 
            // vDate
            // 
            this.vDate.HeaderText = "التاريخ";
            this.vDate.Name = "vDate";
            this.vDate.ReadOnly = true;
            this.vDate.Width = 65;
            // 
            // vDay
            // 
            this.vDay.HeaderText = "اليوم";
            this.vDay.Name = "vDay";
            this.vDay.ReadOnly = true;
            this.vDay.Width = 60;
            // 
            // vTime1
            // 
            this.vTime1.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.vTime1.BackgroundStyle.Class = "DataGridViewBorder";
            this.vTime1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.vTime1.Culture = new System.Globalization.CultureInfo("ar-SA");
            this.vTime1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.vTime1.HeaderText = "حضور";
            this.vTime1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.vTime1.Mask = "##:##";
            this.vTime1.Name = "vTime1";
            this.vTime1.PasswordChar = '\0';
            this.vTime1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.vTime1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.vTime1.Text = "  :";
            this.vTime1.Width = 40;
            // 
            // vLeaveTime1
            // 
            this.vLeaveTime1.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.vLeaveTime1.BackgroundStyle.Class = "DataGridViewBorder";
            this.vLeaveTime1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.vLeaveTime1.Culture = new System.Globalization.CultureInfo("ar-SA");
            this.vLeaveTime1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.vLeaveTime1.HeaderText = "إنصراف";
            this.vLeaveTime1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.vLeaveTime1.Mask = "##:##";
            this.vLeaveTime1.Name = "vLeaveTime1";
            this.vLeaveTime1.PasswordChar = '\0';
            this.vLeaveTime1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.vLeaveTime1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.vLeaveTime1.Text = "  :";
            this.vLeaveTime1.Width = 40;
            // 
            // vTime2
            // 
            this.vTime2.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.vTime2.BackgroundStyle.Class = "DataGridViewBorder";
            this.vTime2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.vTime2.Culture = new System.Globalization.CultureInfo("ar-SA");
            this.vTime2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.vTime2.HeaderText = "حضور";
            this.vTime2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.vTime2.Mask = "##:##";
            this.vTime2.Name = "vTime2";
            this.vTime2.PasswordChar = '\0';
            this.vTime2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.vTime2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.vTime2.Text = "  :";
            this.vTime2.Width = 40;
            // 
            // vLeaveTime2
            // 
            this.vLeaveTime2.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.vLeaveTime2.BackgroundStyle.Class = "DataGridViewBorder";
            this.vLeaveTime2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.vLeaveTime2.Culture = new System.Globalization.CultureInfo("ar-SA");
            this.vLeaveTime2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.vLeaveTime2.HeaderText = "إنصراف";
            this.vLeaveTime2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.vLeaveTime2.Mask = "##:##";
            this.vLeaveTime2.Name = "vLeaveTime2";
            this.vLeaveTime2.PasswordChar = '\0';
            this.vLeaveTime2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.vLeaveTime2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.vLeaveTime2.Text = "  :";
            this.vLeaveTime2.Width = 40;
            // 
            // vLateTime
            // 
            // 
            // 
            // 
            this.vLateTime.BackgroundStyle.Class = "DataGridViewNumericBorder";
            this.vLateTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.vLateTime.HeaderText = "تأخير";
            this.vLateTime.Increment = 1D;
            this.vLateTime.Name = "vLateTime";
            this.vLateTime.ReadOnly = true;
            this.vLateTime.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.vLateTime.Width = 45;
            // 
            // vNote
            // 
            this.vNote.HeaderText = "ملاحظـــــــات";
            this.vNote.Name = "vNote";
            this.vNote.ReadOnly = true;
            this.vNote.Width = 70;
            // 
            // vEmpID
            // 
            this.vEmpID.HeaderText = "Column5";
            this.vEmpID.Name = "vEmpID";
            this.vEmpID.Visible = false;
            // 
            // AttTime1
            // 
            this.AttTime1.HeaderText = "Column5";
            this.AttTime1.Name = "AttTime1";
            this.AttTime1.Visible = false;
            // 
            // AttTime2
            // 
            this.AttTime2.HeaderText = "Column5";
            this.AttTime2.Name = "AttTime2";
            this.AttTime2.Visible = false;
            // 
            // AttLeaveTime1
            // 
            this.AttLeaveTime1.HeaderText = "Column5";
            this.AttLeaveTime1.Name = "AttLeaveTime1";
            this.AttLeaveTime1.Visible = false;
            // 
            // AttLeaveTime2
            // 
            this.AttLeaveTime2.HeaderText = "Column5";
            this.AttLeaveTime2.Name = "AttLeaveTime2";
            this.AttLeaveTime2.Visible = false;
            // 
            // Pardon1
            // 
            this.Pardon1.HeaderText = "Column5";
            this.Pardon1.Name = "Pardon1";
            this.Pardon1.Visible = false;
            // 
            // Pardon2
            // 
            this.Pardon2.HeaderText = "Column5";
            this.Pardon2.Name = "Pardon2";
            this.Pardon2.Visible = false;
            // 
            // DateEdi
            // 
            this.DateEdi.HeaderText = "اخر تعديل";
            this.DateEdi.Name = "DateEdi";
            this.DateEdi.ReadOnly = true;
            this.DateEdi.Visible = false;
            this.DateEdi.Width = 60;
            // 
            // UsrName
            // 
            this.UsrName.HeaderText = "مسؤولية التعديل";
            this.UsrName.Name = "UsrName";
            this.UsrName.ReadOnly = true;
            this.UsrName.Width = 80;
            // 
            // button_Save
            // 
            this.button_Save.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_Save.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.button_Save.Enabled = false;
            this.button_Save.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.button_Save.Location = new System.Drawing.Point(7, 65);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(119, 33);
            this.button_Save.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_Save.Symbol = "";
            this.button_Save.SymbolSize = 16F;
            this.button_Save.TabIndex = 1598;
            this.button_Save.Text = "حفــــظ";
            this.button_Save.TextColor = System.Drawing.Color.White;
            this.button_Save.Click += new System.EventHandler(this.button_Save_Click);
            // 
            // comboBox_EmpNo
            // 
            this.comboBox_EmpNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox_EmpNo.DisplayMember = "Text";
            this.comboBox_EmpNo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBox_EmpNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_EmpNo.FormattingEnabled = true;
            this.comboBox_EmpNo.ItemHeight = 14;
            this.comboBox_EmpNo.Location = new System.Drawing.Point(35, 15);
            this.comboBox_EmpNo.Name = "comboBox_EmpNo";
            this.comboBox_EmpNo.Size = new System.Drawing.Size(393, 20);
            this.comboBox_EmpNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBox_EmpNo.TabIndex = 6687;
            // 
            // button_Open
            // 
            this.button_Open.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_Open.Checked = true;
            this.button_Open.ColorTable = DevComponents.DotNetBar.eButtonColor.Blue;
            this.button_Open.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.button_Open.Location = new System.Drawing.Point(128, 65);
            this.button_Open.Name = "button_Open";
            this.button_Open.Size = new System.Drawing.Size(119, 33);
            this.button_Open.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2003;
            this.button_Open.SubItemsExpandWidth = 15;
            this.button_Open.Symbol = "";
            this.button_Open.SymbolSize = 13F;
            this.button_Open.TabIndex = 1597;
            this.button_Open.Text = "عرض البيانات";
            this.button_Open.Tooltip = "إستعراض";
            this.button_Open.Click += new System.EventHandler(this.button_Open_Click);
            // 
            // button_SEmp
            // 
            this.button_SEmp.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SEmp.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SEmp.Location = new System.Drawing.Point(8, 15);
            this.button_SEmp.Name = "button_SEmp";
            this.button_SEmp.Size = new System.Drawing.Size(26, 20);
            this.button_SEmp.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SEmp.Symbol = "";
            this.button_SEmp.SymbolSize = 12F;
            this.button_SEmp.TabIndex = 6688;
            this.button_SEmp.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SEmp.Click += new System.EventHandler(this.button_SEmp_Click);
            // 
            // textBox_DateEdit
            // 
            this.textBox_DateEdit.BackColor = System.Drawing.Color.Red;
            this.textBox_DateEdit.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.textBox_DateEdit.ForeColor = System.Drawing.Color.White;
            this.textBox_DateEdit.Location = new System.Drawing.Point(291, 45);
            this.textBox_DateEdit.Mask = "0000/00";
            this.textBox_DateEdit.Name = "textBox_DateEdit";
            this.textBox_DateEdit.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox_DateEdit.Size = new System.Drawing.Size(137, 21);
            this.textBox_DateEdit.TabIndex = 6672;
            this.textBox_DateEdit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_DateEdit.Click += new System.EventHandler(this.textBox_DateEdit_Click);
            this.textBox_DateEdit.Leave += new System.EventHandler(this.textBox_DateEdit_Leave);
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.BackColor = System.Drawing.Color.Transparent;
            this.label29.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label29.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label29.Location = new System.Drawing.Point(430, 51);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(51, 13);
            this.label29.TabIndex = 6679;
            this.label29.Text = "التاريـــخ :";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.BackColor = System.Drawing.Color.Transparent;
            this.label30.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label30.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label30.Location = new System.Drawing.Point(430, 19);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(49, 13);
            this.label30.TabIndex = 6678;
            this.label30.Text = "الموظف :";
            // 
            // panelEx_MenualAttend
            // 
            this.panelEx_MenualAttend.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx_MenualAttend.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx_MenualAttend.Controls.Add(this.panel6);
            this.panelEx_MenualAttend.Controls.Add(this.ButSaveMenual);
            this.panelEx_MenualAttend.Controls.Add(this.panel7);
            this.panelEx_MenualAttend.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx_MenualAttend.Location = new System.Drawing.Point(0, 0);
            this.panelEx_MenualAttend.Name = "panelEx_MenualAttend";
            this.panelEx_MenualAttend.Size = new System.Drawing.Size(491, 402);
            this.panelEx_MenualAttend.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx_MenualAttend.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx_MenualAttend.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx_MenualAttend.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx_MenualAttend.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx_MenualAttend.Style.GradientAngle = 90;
            this.panelEx_MenualAttend.TabIndex = 6780;
            this.panelEx_MenualAttend.Visible = false;
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel6.Controls.Add(this.comboBox_PRojectMenual);
            this.panel6.Controls.Add(this.button_ADDPRojectMenual);
            this.panel6.Controls.Add(this.button_SrchPRojectMenual);
            this.panel6.Controls.Add(this.label28);
            this.panel6.Controls.Add(this.label26);
            this.panel6.Controls.Add(this.textBox_TimeLeaveMenual1);
            this.panel6.Controls.Add(this.label12);
            this.panel6.Controls.Add(this.textBox_ComeTimeMenual);
            this.panel6.Controls.Add(this.label13);
            this.panel6.Controls.Add(this.textBox_DayMenual);
            this.panel6.Controls.Add(this.label27);
            this.panel6.Controls.Add(this.textBox_DateMenual);
            this.panel6.Location = new System.Drawing.Point(18, 30);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(453, 210);
            this.panel6.TabIndex = 1597;
            // 
            // comboBox_PRojectMenual
            // 
            this.comboBox_PRojectMenual.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox_PRojectMenual.DisplayMember = "Text";
            this.comboBox_PRojectMenual.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBox_PRojectMenual.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_PRojectMenual.FormattingEnabled = true;
            this.comboBox_PRojectMenual.ItemHeight = 14;
            this.comboBox_PRojectMenual.Location = new System.Drawing.Point(75, 96);
            this.comboBox_PRojectMenual.Name = "comboBox_PRojectMenual";
            this.comboBox_PRojectMenual.Size = new System.Drawing.Size(355, 20);
            this.comboBox_PRojectMenual.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBox_PRojectMenual.TabIndex = 6691;
            // 
            // button_ADDPRojectMenual
            // 
            this.button_ADDPRojectMenual.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_ADDPRojectMenual.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_ADDPRojectMenual.Location = new System.Drawing.Point(19, 95);
            this.button_ADDPRojectMenual.Name = "button_ADDPRojectMenual";
            this.button_ADDPRojectMenual.Size = new System.Drawing.Size(26, 20);
            this.button_ADDPRojectMenual.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_ADDPRojectMenual.Symbol = "";
            this.button_ADDPRojectMenual.SymbolSize = 11F;
            this.button_ADDPRojectMenual.TabIndex = 6693;
            this.button_ADDPRojectMenual.TextColor = System.Drawing.Color.SteelBlue;
            this.button_ADDPRojectMenual.Click += new System.EventHandler(this.button_ADDPRojectMenual_Click);
            // 
            // button_SrchPRojectMenual
            // 
            this.button_SrchPRojectMenual.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchPRojectMenual.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchPRojectMenual.Location = new System.Drawing.Point(46, 95);
            this.button_SrchPRojectMenual.Name = "button_SrchPRojectMenual";
            this.button_SrchPRojectMenual.Size = new System.Drawing.Size(26, 20);
            this.button_SrchPRojectMenual.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchPRojectMenual.Symbol = "";
            this.button_SrchPRojectMenual.SymbolSize = 12F;
            this.button_SrchPRojectMenual.TabIndex = 6692;
            this.button_SrchPRojectMenual.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchPRojectMenual.Click += new System.EventHandler(this.button_SrchPRojectMenual_Click);
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.BackColor = System.Drawing.Color.Transparent;
            this.label28.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label28.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label28.Location = new System.Drawing.Point(306, 72);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(125, 13);
            this.label28.TabIndex = 6690;
            this.label28.Text = "موقع العمل ( المشروع ) :";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.BackColor = System.Drawing.Color.Transparent;
            this.label26.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label26.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label26.Location = new System.Drawing.Point(101, 25);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(48, 13);
            this.label26.TabIndex = 6689;
            this.label26.Text = "اليــــوم :";
            // 
            // textBox_TimeLeaveMenual1
            // 
            this.textBox_TimeLeaveMenual1.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.textBox_TimeLeaveMenual1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.textBox_TimeLeaveMenual1.ForeColor = System.Drawing.Color.White;
            this.textBox_TimeLeaveMenual1.Location = new System.Drawing.Point(76, 163);
            this.textBox_TimeLeaveMenual1.Mask = "##:##";
            this.textBox_TimeLeaveMenual1.Name = "textBox_TimeLeaveMenual1";
            this.textBox_TimeLeaveMenual1.Size = new System.Drawing.Size(106, 20);
            this.textBox_TimeLeaveMenual1.TabIndex = 4;
            this.textBox_TimeLeaveMenual1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_TimeLeaveMenual1.Click += new System.EventHandler(this.textBox_TimeLeaveMenual1_Click);
            this.textBox_TimeLeaveMenual1.Leave += new System.EventHandler(this.textBox_TimeLeaveMenual1_Leave);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label12.ForeColor = System.Drawing.Color.Red;
            this.label12.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label12.Location = new System.Drawing.Point(96, 139);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(67, 13);
            this.label12.TabIndex = 6688;
            this.label12.Text = "الإنصــــراف";
            // 
            // textBox_ComeTimeMenual
            // 
            this.textBox_ComeTimeMenual.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.textBox_ComeTimeMenual.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.textBox_ComeTimeMenual.ForeColor = System.Drawing.Color.White;
            this.textBox_ComeTimeMenual.Location = new System.Drawing.Point(270, 163);
            this.textBox_ComeTimeMenual.Mask = "##:##";
            this.textBox_ComeTimeMenual.Name = "textBox_ComeTimeMenual";
            this.textBox_ComeTimeMenual.Size = new System.Drawing.Size(106, 20);
            this.textBox_ComeTimeMenual.TabIndex = 3;
            this.textBox_ComeTimeMenual.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_ComeTimeMenual.Click += new System.EventHandler(this.textBox_ComeTimeMenual_Click);
            this.textBox_ComeTimeMenual.Leave += new System.EventHandler(this.textBox_ComeTimeMenual_Leave);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label13.ForeColor = System.Drawing.Color.Red;
            this.label13.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label13.Location = new System.Drawing.Point(289, 139);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(69, 13);
            this.label13.TabIndex = 6683;
            this.label13.Text = "الحضــــــــور";
            // 
            // textBox_DayMenual
            // 
            this.textBox_DayMenual.BackColor = System.Drawing.Color.White;
            this.textBox_DayMenual.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_DayMenual.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.textBox_DayMenual.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.textBox_DayMenual.Location = new System.Drawing.Point(19, 21);
            this.textBox_DayMenual.Name = "textBox_DayMenual";
            this.textBox_DayMenual.Size = new System.Drawing.Size(80, 20);
            this.textBox_DayMenual.TabIndex = 85;
            this.textBox_DayMenual.Text = "--";
            this.textBox_DayMenual.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.textBox_DayMenual.TextChanged += new System.EventHandler(this.textBox_DayMenual_TextChanged);
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.BackColor = System.Drawing.Color.Transparent;
            this.label27.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label27.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label27.Location = new System.Drawing.Point(375, 25);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(51, 13);
            this.label27.TabIndex = 83;
            this.label27.Text = "التاريـــخ :";
            // 
            // textBox_DateMenual
            // 
            this.textBox_DateMenual.Location = new System.Drawing.Point(268, 21);
            this.textBox_DateMenual.Mask = "0000/00/00";
            this.textBox_DateMenual.Name = "textBox_DateMenual";
            this.textBox_DateMenual.Size = new System.Drawing.Size(106, 20);
            this.textBox_DateMenual.TabIndex = 1;
            this.textBox_DateMenual.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_DateMenual.Click += new System.EventHandler(this.textBox_DateMenual_Click);
            this.textBox_DateMenual.Leave += new System.EventHandler(this.textBox_DateMenual_Leave);
            // 
            // ButSaveMenual
            // 
            this.ButSaveMenual.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.ButSaveMenual.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.ButSaveMenual.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.ButSaveMenual.Location = new System.Drawing.Point(95, 345);
            this.ButSaveMenual.Name = "ButSaveMenual";
            this.ButSaveMenual.Size = new System.Drawing.Size(301, 36);
            this.ButSaveMenual.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ButSaveMenual.Symbol = "";
            this.ButSaveMenual.SymbolSize = 16F;
            this.ButSaveMenual.TabIndex = 1596;
            this.ButSaveMenual.Text = "حفــــــــــــظ";
            this.ButSaveMenual.TextColor = System.Drawing.Color.White;
            this.ButSaveMenual.Click += new System.EventHandler(this.ButSaveMenual_Click);
            // 
            // panel7
            // 
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Controls.Add(this.radioButton_PeriodsMenual2);
            this.panel7.Controls.Add(this.radioButton_PeriodsMenual1);
            this.panel7.Location = new System.Drawing.Point(18, 258);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(450, 48);
            this.panel7.TabIndex = 6682;
            // 
            // radioButton_PeriodsMenual2
            // 
            this.radioButton_PeriodsMenual2.AutoSize = true;
            this.radioButton_PeriodsMenual2.BackColor = System.Drawing.Color.Transparent;
            this.radioButton_PeriodsMenual2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.radioButton_PeriodsMenual2.ForeColor = System.Drawing.Color.Gray;
            this.radioButton_PeriodsMenual2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radioButton_PeriodsMenual2.Location = new System.Drawing.Point(87, 16);
            this.radioButton_PeriodsMenual2.Name = "radioButton_PeriodsMenual2";
            this.radioButton_PeriodsMenual2.Size = new System.Drawing.Size(89, 17);
            this.radioButton_PeriodsMenual2.TabIndex = 115;
            this.radioButton_PeriodsMenual2.Text = "الفترة الثانية";
            this.radioButton_PeriodsMenual2.UseVisualStyleBackColor = false;
            // 
            // radioButton_PeriodsMenual1
            // 
            this.radioButton_PeriodsMenual1.AutoSize = true;
            this.radioButton_PeriodsMenual1.BackColor = System.Drawing.Color.Transparent;
            this.radioButton_PeriodsMenual1.Checked = true;
            this.radioButton_PeriodsMenual1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.radioButton_PeriodsMenual1.ForeColor = System.Drawing.Color.Gray;
            this.radioButton_PeriodsMenual1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radioButton_PeriodsMenual1.Location = new System.Drawing.Point(260, 16);
            this.radioButton_PeriodsMenual1.Name = "radioButton_PeriodsMenual1";
            this.radioButton_PeriodsMenual1.Size = new System.Drawing.Size(92, 17);
            this.radioButton_PeriodsMenual1.TabIndex = 114;
            this.radioButton_PeriodsMenual1.TabStop = true;
            this.radioButton_PeriodsMenual1.Text = "الفترة الأولى";
            this.radioButton_PeriodsMenual1.UseVisualStyleBackColor = false;
            // 
            // expandablePanel_Girds
            // 
            this.expandablePanel_Girds.CanvasColor = System.Drawing.SystemColors.Control;
            this.expandablePanel_Girds.CollapseDirection = DevComponents.DotNetBar.eCollapseDirection.RightToLeft;
            this.expandablePanel_Girds.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.expandablePanel_Girds.Controls.Add(this.expandablePanel_Emp);
            this.expandablePanel_Girds.Controls.Add(this.expandablePanel_Job);
            this.expandablePanel_Girds.Controls.Add(this.expandablePanel_Section);
            this.expandablePanel_Girds.Controls.Add(this.expandablePanel_Dept);
            this.expandablePanel_Girds.Dock = System.Windows.Forms.DockStyle.Left;
            this.expandablePanel_Girds.ExpandButtonVisible = false;
            this.expandablePanel_Girds.Expanded = false;
            this.expandablePanel_Girds.ExpandedBounds = new System.Drawing.Rectangle(0, 27, 314, 415);
            this.expandablePanel_Girds.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.expandablePanel_Girds.Location = new System.Drawing.Point(0, 25);
            this.expandablePanel_Girds.Name = "expandablePanel_Girds";
            this.expandablePanel_Girds.Size = new System.Drawing.Size(26, 417);
            this.expandablePanel_Girds.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanel_Girds.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.expandablePanel_Girds.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandablePanel_Girds.Style.GradientAngle = 90;
            this.expandablePanel_Girds.TabIndex = 6775;
            this.expandablePanel_Girds.TitleStyle.Alignment = System.Drawing.StringAlignment.Far;
            this.expandablePanel_Girds.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandablePanel_Girds.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            this.expandablePanel_Girds.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandablePanel_Girds.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.expandablePanel_Girds.TitleStyle.GradientAngle = 90;
            this.expandablePanel_Girds.TitleStyle.MarginLeft = 6;
            this.expandablePanel_Girds.TitleText = "على حســــب";
            this.expandablePanel_Girds.ExpandedChanging += new DevComponents.DotNetBar.ExpandChangeEventHandler(this.expandablePanel_Girds_ExpandedChanging);
            this.expandablePanel_Girds.ExpandedChanged += new DevComponents.DotNetBar.ExpandChangeEventHandler(this.expandablePanel_Girds_ExpandedChanged);
            // 
            // expandablePanel_Emp
            // 
            this.expandablePanel_Emp.CanvasColor = System.Drawing.SystemColors.Control;
            this.expandablePanel_Emp.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.expandablePanel_Emp.Controls.Add(this.itemPanel4);
            this.expandablePanel_Emp.Dock = System.Windows.Forms.DockStyle.Top;
            this.expandablePanel_Emp.Expanded = false;
            this.expandablePanel_Emp.ExpandedBounds = new System.Drawing.Rectangle(0, 104, 314, 226);
            this.expandablePanel_Emp.ExpandOnTitleClick = true;
            this.expandablePanel_Emp.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.expandablePanel_Emp.Location = new System.Drawing.Point(0, 104);
            this.expandablePanel_Emp.Name = "expandablePanel_Emp";
            this.expandablePanel_Emp.Size = new System.Drawing.Size(26, 26);
            this.expandablePanel_Emp.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanel_Emp.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.expandablePanel_Emp.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.expandablePanel_Emp.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandablePanel_Emp.Style.GradientAngle = 90;
            this.expandablePanel_Emp.TabIndex = 6;
            this.expandablePanel_Emp.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandablePanel_Emp.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            this.expandablePanel_Emp.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandablePanel_Emp.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.expandablePanel_Emp.TitleStyle.GradientAngle = 90;
            this.expandablePanel_Emp.TitleStyle.MarginLeft = 12;
            this.expandablePanel_Emp.TitleText = "الموظف";
            this.expandablePanel_Emp.ExpandedChanging += new DevComponents.DotNetBar.ExpandChangeEventHandler(this.expandablePanel_Emp_ExpandedChanging);
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
            this.itemPanel4.Controls.Add(this.dataGridViewX_Emp);
            this.itemPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.itemPanel4.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.itemPanel4.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.itemPanel4.Location = new System.Drawing.Point(0, 26);
            this.itemPanel4.Name = "itemPanel4";
            this.itemPanel4.Size = new System.Drawing.Size(26, 0);
            this.itemPanel4.TabIndex = 3;
            this.itemPanel4.Text = "itemPanel4";
            // 
            // dataGridViewX_Emp
            // 
            this.dataGridViewX_Emp.BackColor = System.Drawing.SystemColors.ControlLight;
            this.dataGridViewX_Emp.Dock = System.Windows.Forms.DockStyle.Left;
            this.dataGridViewX_Emp.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            this.dataGridViewX_Emp.ForeColor = System.Drawing.Color.Black;
            this.dataGridViewX_Emp.HScrollBarVisible = false;
            this.dataGridViewX_Emp.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.dataGridViewX_Emp.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewX_Emp.Name = "dataGridViewX_Emp";
            this.dataGridViewX_Emp.PrimaryGrid.AllowRowHeaderResize = true;
            this.dataGridViewX_Emp.PrimaryGrid.AllowRowResize = true;
            this.dataGridViewX_Emp.PrimaryGrid.ColumnHeader.RowHeight = 30;
            this.dataGridViewX_Emp.PrimaryGrid.ColumnHeader.SortImageAlignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            this.dataGridViewX_Emp.PrimaryGrid.ColumnHeader.Visible = false;
            gridColumn9.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleLeft;
            gridColumn9.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridCheckBoxXEditControl);
            gridColumn9.FilterEditType = DevComponents.DotNetBar.SuperGrid.FilterEditType.None;
            gridColumn9.HeaderStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gridColumn9.Name = "*";
            gridColumn9.Width = 50;
            gridColumn10.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleLeft;
            gridColumn10.ColumnSortMode = DevComponents.DotNetBar.SuperGrid.ColumnSortMode.None;
            gridColumn10.FilterAutoScan = true;
            gridColumn10.HeaderStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gridColumn10.InfoImageAlignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gridColumn10.Name = "رقم / إسم الإدارة";
            gridColumn10.ReadOnly = true;
            gridColumn10.Width = 263;
            gridColumn11.ReadOnly = true;
            gridColumn11.Visible = false;
            this.dataGridViewX_Emp.PrimaryGrid.Columns.Add(gridColumn9);
            this.dataGridViewX_Emp.PrimaryGrid.Columns.Add(gridColumn10);
            this.dataGridViewX_Emp.PrimaryGrid.Columns.Add(gridColumn11);
            this.dataGridViewX_Emp.PrimaryGrid.DefaultRowHeight = 24;
            background2.Color1 = System.Drawing.Color.White;
            background2.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dataGridViewX_Emp.PrimaryGrid.DefaultVisualStyles.AlternateColumnCellStyles.Default.Background = background2;
            background3.Color1 = System.Drawing.Color.White;
            background3.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dataGridViewX_Emp.PrimaryGrid.DefaultVisualStyles.AlternateRowCellStyles.Default.Background = background3;
            this.dataGridViewX_Emp.PrimaryGrid.DefaultVisualStyles.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            this.dataGridViewX_Emp.PrimaryGrid.DefaultVisualStyles.FilterColumnHeaderStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            this.dataGridViewX_Emp.PrimaryGrid.EnableColumnFiltering = true;
            this.dataGridViewX_Emp.PrimaryGrid.EnableFiltering = true;
            this.dataGridViewX_Emp.PrimaryGrid.EnableRowFiltering = true;
            this.dataGridViewX_Emp.PrimaryGrid.Filter.Visible = true;
            this.dataGridViewX_Emp.PrimaryGrid.FilterLevel = ((DevComponents.DotNetBar.SuperGrid.FilterLevel)((DevComponents.DotNetBar.SuperGrid.FilterLevel.Root | DevComponents.DotNetBar.SuperGrid.FilterLevel.Expanded)));
            this.dataGridViewX_Emp.PrimaryGrid.FilterMatchType = DevComponents.DotNetBar.SuperGrid.FilterMatchType.RegularExpressions;
            this.dataGridViewX_Emp.PrimaryGrid.MultiSelect = false;
            this.dataGridViewX_Emp.PrimaryGrid.NullString = "-----";
            this.dataGridViewX_Emp.PrimaryGrid.RowHeaderWidth = 45;
            this.dataGridViewX_Emp.PrimaryGrid.ShowColumnHeader = false;
            this.dataGridViewX_Emp.PrimaryGrid.ShowRowGridIndex = true;
            this.dataGridViewX_Emp.PrimaryGrid.ShowRowHeaders = false;
            this.dataGridViewX_Emp.PrimaryGrid.UseAlternateRowStyle = true;
            this.dataGridViewX_Emp.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dataGridViewX_Emp.Size = new System.Drawing.Size(313, 0);
            this.dataGridViewX_Emp.TabIndex = 481;
            // 
            // expandablePanel_Job
            // 
            this.expandablePanel_Job.CanvasColor = System.Drawing.SystemColors.Control;
            this.expandablePanel_Job.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.expandablePanel_Job.Controls.Add(this.itemPanel3);
            this.expandablePanel_Job.Dock = System.Windows.Forms.DockStyle.Top;
            this.expandablePanel_Job.Expanded = false;
            this.expandablePanel_Job.ExpandedBounds = new System.Drawing.Rectangle(0, 78, 314, 226);
            this.expandablePanel_Job.ExpandOnTitleClick = true;
            this.expandablePanel_Job.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.expandablePanel_Job.Location = new System.Drawing.Point(0, 78);
            this.expandablePanel_Job.Name = "expandablePanel_Job";
            this.expandablePanel_Job.Size = new System.Drawing.Size(26, 26);
            this.expandablePanel_Job.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanel_Job.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.expandablePanel_Job.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.expandablePanel_Job.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandablePanel_Job.Style.GradientAngle = 90;
            this.expandablePanel_Job.TabIndex = 5;
            this.expandablePanel_Job.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandablePanel_Job.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            this.expandablePanel_Job.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandablePanel_Job.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.expandablePanel_Job.TitleStyle.GradientAngle = 90;
            this.expandablePanel_Job.TitleStyle.MarginLeft = 12;
            this.expandablePanel_Job.TitleText = "الوظيفة";
            this.expandablePanel_Job.ExpandedChanging += new DevComponents.DotNetBar.ExpandChangeEventHandler(this.expandablePanel_Job_ExpandedChanging);
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
            this.itemPanel3.Controls.Add(this.dataGridViewX_Job);
            this.itemPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.itemPanel3.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.itemPanel3.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.itemPanel3.Location = new System.Drawing.Point(0, 26);
            this.itemPanel3.Name = "itemPanel3";
            this.itemPanel3.Size = new System.Drawing.Size(26, 0);
            this.itemPanel3.TabIndex = 3;
            this.itemPanel3.Text = "itemPanel3";
            // 
            // dataGridViewX_Job
            // 
            this.dataGridViewX_Job.BackColor = System.Drawing.SystemColors.ControlLight;
            this.dataGridViewX_Job.Dock = System.Windows.Forms.DockStyle.Left;
            this.dataGridViewX_Job.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            this.dataGridViewX_Job.ForeColor = System.Drawing.Color.Black;
            this.dataGridViewX_Job.HScrollBarVisible = false;
            this.dataGridViewX_Job.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.dataGridViewX_Job.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewX_Job.Name = "dataGridViewX_Job";
            this.dataGridViewX_Job.PrimaryGrid.AllowRowHeaderResize = true;
            this.dataGridViewX_Job.PrimaryGrid.AllowRowResize = true;
            this.dataGridViewX_Job.PrimaryGrid.ColumnHeader.RowHeight = 30;
            this.dataGridViewX_Job.PrimaryGrid.ColumnHeader.SortImageAlignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            this.dataGridViewX_Job.PrimaryGrid.ColumnHeader.Visible = false;
            gridColumn12.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleLeft;
            gridColumn12.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridCheckBoxXEditControl);
            gridColumn12.FilterEditType = DevComponents.DotNetBar.SuperGrid.FilterEditType.None;
            gridColumn12.HeaderStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gridColumn12.Name = "*";
            gridColumn12.Width = 50;
            gridColumn13.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleLeft;
            gridColumn13.ColumnSortMode = DevComponents.DotNetBar.SuperGrid.ColumnSortMode.None;
            gridColumn13.FilterAutoScan = true;
            gridColumn13.HeaderStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gridColumn13.InfoImageAlignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gridColumn13.Name = "رقم / إسم الإدارة";
            gridColumn13.ReadOnly = true;
            gridColumn13.Width = 263;
            gridColumn14.ReadOnly = true;
            gridColumn14.Visible = false;
            this.dataGridViewX_Job.PrimaryGrid.Columns.Add(gridColumn12);
            this.dataGridViewX_Job.PrimaryGrid.Columns.Add(gridColumn13);
            this.dataGridViewX_Job.PrimaryGrid.Columns.Add(gridColumn14);
            this.dataGridViewX_Job.PrimaryGrid.DefaultRowHeight = 24;
            background4.Color1 = System.Drawing.Color.White;
            background4.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dataGridViewX_Job.PrimaryGrid.DefaultVisualStyles.AlternateColumnCellStyles.Default.Background = background4;
            background5.Color1 = System.Drawing.Color.White;
            background5.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dataGridViewX_Job.PrimaryGrid.DefaultVisualStyles.AlternateRowCellStyles.Default.Background = background5;
            this.dataGridViewX_Job.PrimaryGrid.DefaultVisualStyles.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            this.dataGridViewX_Job.PrimaryGrid.DefaultVisualStyles.FilterColumnHeaderStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            this.dataGridViewX_Job.PrimaryGrid.EnableColumnFiltering = true;
            this.dataGridViewX_Job.PrimaryGrid.EnableFiltering = true;
            this.dataGridViewX_Job.PrimaryGrid.EnableRowFiltering = true;
            this.dataGridViewX_Job.PrimaryGrid.Filter.Visible = true;
            this.dataGridViewX_Job.PrimaryGrid.FilterLevel = ((DevComponents.DotNetBar.SuperGrid.FilterLevel)((DevComponents.DotNetBar.SuperGrid.FilterLevel.Root | DevComponents.DotNetBar.SuperGrid.FilterLevel.Expanded)));
            this.dataGridViewX_Job.PrimaryGrid.FilterMatchType = DevComponents.DotNetBar.SuperGrid.FilterMatchType.RegularExpressions;
            this.dataGridViewX_Job.PrimaryGrid.MultiSelect = false;
            this.dataGridViewX_Job.PrimaryGrid.NullString = "-----";
            this.dataGridViewX_Job.PrimaryGrid.RowHeaderWidth = 45;
            this.dataGridViewX_Job.PrimaryGrid.ShowColumnHeader = false;
            this.dataGridViewX_Job.PrimaryGrid.ShowRowGridIndex = true;
            this.dataGridViewX_Job.PrimaryGrid.ShowRowHeaders = false;
            this.dataGridViewX_Job.PrimaryGrid.UseAlternateRowStyle = true;
            this.dataGridViewX_Job.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dataGridViewX_Job.Size = new System.Drawing.Size(313, 0);
            this.dataGridViewX_Job.TabIndex = 481;
            // 
            // expandablePanel_Section
            // 
            this.expandablePanel_Section.CanvasColor = System.Drawing.SystemColors.Control;
            this.expandablePanel_Section.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.expandablePanel_Section.Controls.Add(this.itemPanel2);
            this.expandablePanel_Section.Dock = System.Windows.Forms.DockStyle.Top;
            this.expandablePanel_Section.Expanded = false;
            this.expandablePanel_Section.ExpandedBounds = new System.Drawing.Rectangle(0, 52, 314, 226);
            this.expandablePanel_Section.ExpandOnTitleClick = true;
            this.expandablePanel_Section.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.expandablePanel_Section.Location = new System.Drawing.Point(0, 52);
            this.expandablePanel_Section.Name = "expandablePanel_Section";
            this.expandablePanel_Section.Size = new System.Drawing.Size(26, 26);
            this.expandablePanel_Section.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanel_Section.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.expandablePanel_Section.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.expandablePanel_Section.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandablePanel_Section.Style.GradientAngle = 90;
            this.expandablePanel_Section.TabIndex = 4;
            this.expandablePanel_Section.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandablePanel_Section.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            this.expandablePanel_Section.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandablePanel_Section.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.expandablePanel_Section.TitleStyle.GradientAngle = 90;
            this.expandablePanel_Section.TitleStyle.MarginLeft = 12;
            this.expandablePanel_Section.TitleText = "القسم";
            this.expandablePanel_Section.ExpandedChanging += new DevComponents.DotNetBar.ExpandChangeEventHandler(this.expandablePanel_Section_ExpandedChanging);
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
            this.itemPanel2.Controls.Add(this.dataGridViewX_Section);
            this.itemPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.itemPanel2.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.itemPanel2.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.itemPanel2.Location = new System.Drawing.Point(0, 26);
            this.itemPanel2.Name = "itemPanel2";
            this.itemPanel2.Size = new System.Drawing.Size(26, 0);
            this.itemPanel2.TabIndex = 3;
            this.itemPanel2.Text = "itemPanel2";
            // 
            // dataGridViewX_Section
            // 
            this.dataGridViewX_Section.BackColor = System.Drawing.SystemColors.ControlLight;
            this.dataGridViewX_Section.Dock = System.Windows.Forms.DockStyle.Left;
            this.dataGridViewX_Section.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            this.dataGridViewX_Section.ForeColor = System.Drawing.Color.Black;
            this.dataGridViewX_Section.HScrollBarVisible = false;
            this.dataGridViewX_Section.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.dataGridViewX_Section.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewX_Section.Name = "dataGridViewX_Section";
            this.dataGridViewX_Section.PrimaryGrid.AllowRowHeaderResize = true;
            this.dataGridViewX_Section.PrimaryGrid.AllowRowResize = true;
            this.dataGridViewX_Section.PrimaryGrid.ColumnHeader.RowHeight = 30;
            this.dataGridViewX_Section.PrimaryGrid.ColumnHeader.SortImageAlignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            this.dataGridViewX_Section.PrimaryGrid.ColumnHeader.Visible = false;
            gridColumn15.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleLeft;
            gridColumn15.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridCheckBoxXEditControl);
            gridColumn15.FilterEditType = DevComponents.DotNetBar.SuperGrid.FilterEditType.None;
            gridColumn15.HeaderStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gridColumn15.Name = "*";
            gridColumn15.Width = 50;
            gridColumn16.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleLeft;
            gridColumn16.ColumnSortMode = DevComponents.DotNetBar.SuperGrid.ColumnSortMode.None;
            gridColumn16.FilterAutoScan = true;
            gridColumn16.HeaderStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gridColumn16.InfoImageAlignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gridColumn16.Name = "رقم / إسم الإدارة";
            gridColumn16.ReadOnly = true;
            gridColumn16.Width = 263;
            gridColumn17.ReadOnly = true;
            gridColumn17.Visible = false;
            this.dataGridViewX_Section.PrimaryGrid.Columns.Add(gridColumn15);
            this.dataGridViewX_Section.PrimaryGrid.Columns.Add(gridColumn16);
            this.dataGridViewX_Section.PrimaryGrid.Columns.Add(gridColumn17);
            this.dataGridViewX_Section.PrimaryGrid.DefaultRowHeight = 24;
            background6.Color1 = System.Drawing.Color.White;
            background6.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dataGridViewX_Section.PrimaryGrid.DefaultVisualStyles.AlternateColumnCellStyles.Default.Background = background6;
            background7.Color1 = System.Drawing.Color.White;
            background7.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dataGridViewX_Section.PrimaryGrid.DefaultVisualStyles.AlternateRowCellStyles.Default.Background = background7;
            this.dataGridViewX_Section.PrimaryGrid.DefaultVisualStyles.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            this.dataGridViewX_Section.PrimaryGrid.DefaultVisualStyles.FilterColumnHeaderStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            this.dataGridViewX_Section.PrimaryGrid.EnableColumnFiltering = true;
            this.dataGridViewX_Section.PrimaryGrid.EnableFiltering = true;
            this.dataGridViewX_Section.PrimaryGrid.EnableRowFiltering = true;
            this.dataGridViewX_Section.PrimaryGrid.Filter.Visible = true;
            this.dataGridViewX_Section.PrimaryGrid.FilterLevel = ((DevComponents.DotNetBar.SuperGrid.FilterLevel)((DevComponents.DotNetBar.SuperGrid.FilterLevel.Root | DevComponents.DotNetBar.SuperGrid.FilterLevel.Expanded)));
            this.dataGridViewX_Section.PrimaryGrid.FilterMatchType = DevComponents.DotNetBar.SuperGrid.FilterMatchType.RegularExpressions;
            this.dataGridViewX_Section.PrimaryGrid.MultiSelect = false;
            this.dataGridViewX_Section.PrimaryGrid.NullString = "-----";
            this.dataGridViewX_Section.PrimaryGrid.RowHeaderWidth = 45;
            this.dataGridViewX_Section.PrimaryGrid.ShowColumnHeader = false;
            this.dataGridViewX_Section.PrimaryGrid.ShowRowGridIndex = true;
            this.dataGridViewX_Section.PrimaryGrid.ShowRowHeaders = false;
            this.dataGridViewX_Section.PrimaryGrid.UseAlternateRowStyle = true;
            this.dataGridViewX_Section.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dataGridViewX_Section.Size = new System.Drawing.Size(313, 0);
            this.dataGridViewX_Section.TabIndex = 481;
            // 
            // expandablePanel_Dept
            // 
            this.expandablePanel_Dept.CanvasColor = System.Drawing.SystemColors.Control;
            this.expandablePanel_Dept.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.expandablePanel_Dept.Controls.Add(this.itemPanel1);
            this.expandablePanel_Dept.Dock = System.Windows.Forms.DockStyle.Top;
            this.expandablePanel_Dept.Expanded = false;
            this.expandablePanel_Dept.ExpandedBounds = new System.Drawing.Rectangle(0, 26, 30, 226);
            this.expandablePanel_Dept.ExpandOnTitleClick = true;
            this.expandablePanel_Dept.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.expandablePanel_Dept.Location = new System.Drawing.Point(0, 26);
            this.expandablePanel_Dept.Name = "expandablePanel_Dept";
            this.expandablePanel_Dept.Size = new System.Drawing.Size(26, 26);
            this.expandablePanel_Dept.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanel_Dept.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.expandablePanel_Dept.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.expandablePanel_Dept.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandablePanel_Dept.Style.GradientAngle = 90;
            this.expandablePanel_Dept.TabIndex = 3;
            this.expandablePanel_Dept.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandablePanel_Dept.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            this.expandablePanel_Dept.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandablePanel_Dept.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.expandablePanel_Dept.TitleStyle.GradientAngle = 90;
            this.expandablePanel_Dept.TitleStyle.MarginLeft = 12;
            this.expandablePanel_Dept.TitleText = "الإدارة";
            this.expandablePanel_Dept.ExpandedChanging += new DevComponents.DotNetBar.ExpandChangeEventHandler(this.expandablePanel_Dept_ExpandedChanging);
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
            this.itemPanel1.Controls.Add(this.dataGridViewX_Dept);
            this.itemPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.itemPanel1.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.itemPanel1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.itemPanel1.Location = new System.Drawing.Point(0, 26);
            this.itemPanel1.Name = "itemPanel1";
            this.itemPanel1.Size = new System.Drawing.Size(26, 0);
            this.itemPanel1.TabIndex = 3;
            this.itemPanel1.Text = "itemPanel1";
            // 
            // dataGridViewX_Dept
            // 
            this.dataGridViewX_Dept.BackColor = System.Drawing.SystemColors.ControlLight;
            this.dataGridViewX_Dept.Dock = System.Windows.Forms.DockStyle.Left;
            this.dataGridViewX_Dept.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            this.dataGridViewX_Dept.ForeColor = System.Drawing.Color.Black;
            this.dataGridViewX_Dept.HScrollBarVisible = false;
            this.dataGridViewX_Dept.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.dataGridViewX_Dept.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewX_Dept.Name = "dataGridViewX_Dept";
            this.dataGridViewX_Dept.PrimaryGrid.AllowRowHeaderResize = true;
            this.dataGridViewX_Dept.PrimaryGrid.AllowRowResize = true;
            this.dataGridViewX_Dept.PrimaryGrid.ColumnHeader.RowHeight = 30;
            this.dataGridViewX_Dept.PrimaryGrid.ColumnHeader.SortImageAlignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            this.dataGridViewX_Dept.PrimaryGrid.ColumnHeader.Visible = false;
            gridColumn18.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleLeft;
            gridColumn18.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridCheckBoxXEditControl);
            gridColumn18.FilterEditType = DevComponents.DotNetBar.SuperGrid.FilterEditType.None;
            gridColumn18.HeaderStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gridColumn18.Name = "*";
            gridColumn18.Width = 50;
            gridColumn19.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleLeft;
            gridColumn19.ColumnSortMode = DevComponents.DotNetBar.SuperGrid.ColumnSortMode.None;
            gridColumn19.FilterAutoScan = true;
            gridColumn19.HeaderStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gridColumn19.InfoImageAlignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gridColumn19.Name = "رقم / إسم الإدارة";
            gridColumn19.ReadOnly = true;
            gridColumn19.Width = 263;
            gridColumn20.ReadOnly = true;
            gridColumn20.Visible = false;
            this.dataGridViewX_Dept.PrimaryGrid.Columns.Add(gridColumn18);
            this.dataGridViewX_Dept.PrimaryGrid.Columns.Add(gridColumn19);
            this.dataGridViewX_Dept.PrimaryGrid.Columns.Add(gridColumn20);
            this.dataGridViewX_Dept.PrimaryGrid.DefaultRowHeight = 24;
            background8.Color1 = System.Drawing.Color.White;
            background8.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dataGridViewX_Dept.PrimaryGrid.DefaultVisualStyles.AlternateColumnCellStyles.Default.Background = background8;
            background9.Color1 = System.Drawing.Color.White;
            background9.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dataGridViewX_Dept.PrimaryGrid.DefaultVisualStyles.AlternateRowCellStyles.Default.Background = background9;
            this.dataGridViewX_Dept.PrimaryGrid.DefaultVisualStyles.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            this.dataGridViewX_Dept.PrimaryGrid.DefaultVisualStyles.FilterColumnHeaderStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            this.dataGridViewX_Dept.PrimaryGrid.EnableColumnFiltering = true;
            this.dataGridViewX_Dept.PrimaryGrid.EnableFiltering = true;
            this.dataGridViewX_Dept.PrimaryGrid.EnableRowFiltering = true;
            this.dataGridViewX_Dept.PrimaryGrid.Filter.Visible = true;
            this.dataGridViewX_Dept.PrimaryGrid.FilterLevel = ((DevComponents.DotNetBar.SuperGrid.FilterLevel)((DevComponents.DotNetBar.SuperGrid.FilterLevel.Root | DevComponents.DotNetBar.SuperGrid.FilterLevel.Expanded)));
            this.dataGridViewX_Dept.PrimaryGrid.FilterMatchType = DevComponents.DotNetBar.SuperGrid.FilterMatchType.RegularExpressions;
            this.dataGridViewX_Dept.PrimaryGrid.MultiSelect = false;
            this.dataGridViewX_Dept.PrimaryGrid.NullString = "-----";
            this.dataGridViewX_Dept.PrimaryGrid.RowHeaderWidth = 45;
            this.dataGridViewX_Dept.PrimaryGrid.ShowColumnHeader = false;
            this.dataGridViewX_Dept.PrimaryGrid.ShowRowGridIndex = true;
            this.dataGridViewX_Dept.PrimaryGrid.ShowRowHeaders = false;
            this.dataGridViewX_Dept.PrimaryGrid.UseAlternateRowStyle = true;
            this.dataGridViewX_Dept.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dataGridViewX_Dept.Size = new System.Drawing.Size(313, 0);
            this.dataGridViewX_Dept.TabIndex = 481;
            // 
            // barLeftDockSite
            // 
            this.barLeftDockSite.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.barLeftDockSite.Dock = System.Windows.Forms.DockStyle.Left;
            this.barLeftDockSite.DocumentDockContainer = new DevComponents.DotNetBar.DocumentDockContainer();
            this.barLeftDockSite.Location = new System.Drawing.Point(0, 25);
            this.barLeftDockSite.Name = "barLeftDockSite";
            this.barLeftDockSite.Size = new System.Drawing.Size(0, 417);
            this.barLeftDockSite.TabIndex = 15;
            this.barLeftDockSite.TabStop = false;
            // 
            // barTopDockSite
            // 
            this.barTopDockSite.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.barTopDockSite.Dock = System.Windows.Forms.DockStyle.Top;
            this.barTopDockSite.DocumentDockContainer = new DevComponents.DotNetBar.DocumentDockContainer();
            this.barTopDockSite.Location = new System.Drawing.Point(0, 25);
            this.barTopDockSite.Name = "barTopDockSite";
            this.barTopDockSite.Size = new System.Drawing.Size(517, 0);
            this.barTopDockSite.TabIndex = 13;
            this.barTopDockSite.TabStop = false;
            // 
            // barBottomDockSite
            // 
            this.barBottomDockSite.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.barBottomDockSite.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barBottomDockSite.DocumentDockContainer = new DevComponents.DotNetBar.DocumentDockContainer();
            this.barBottomDockSite.Location = new System.Drawing.Point(0, 442);
            this.barBottomDockSite.Name = "barBottomDockSite";
            this.barBottomDockSite.Size = new System.Drawing.Size(517, 0);
            this.barBottomDockSite.TabIndex = 14;
            this.barBottomDockSite.TabStop = false;
            // 
            // barRightDockSite
            // 
            this.barRightDockSite.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.barRightDockSite.Controls.Add(this.barTaskPane);
            this.barRightDockSite.Dock = System.Windows.Forms.DockStyle.Right;
            this.barRightDockSite.DocumentDockContainer = new DevComponents.DotNetBar.DocumentDockContainer(new DevComponents.DotNetBar.DocumentBaseContainer[] {
            ((DevComponents.DotNetBar.DocumentBaseContainer)(new DevComponents.DotNetBar.DocumentBarContainer(this.barTaskPane, 189, 417)))}, DevComponents.DotNetBar.eOrientation.Horizontal);
            this.barRightDockSite.Location = new System.Drawing.Point(517, 25);
            this.barRightDockSite.Name = "barRightDockSite";
            this.barRightDockSite.Size = new System.Drawing.Size(192, 417);
            this.barRightDockSite.TabIndex = 16;
            this.barRightDockSite.TabStop = false;
            // 
            // barTaskPane
            // 
            this.barTaskPane.AccessibleDescription = "DotNetBar Bar (barTaskPane)";
            this.barTaskPane.AccessibleName = "DotNetBar Bar";
            this.barTaskPane.AccessibleRole = System.Windows.Forms.AccessibleRole.ToolBar;
            this.barTaskPane.AutoSyncBarCaption = true;
            this.barTaskPane.CanReorderTabs = false;
            this.barTaskPane.CanUndock = false;
            this.barTaskPane.Controls.Add(this.panelDockContainer4);
            this.barTaskPane.DockOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.barTaskPane.Font = new System.Drawing.Font("Tahoma", 8F);
            this.barTaskPane.GrabHandleStyle = DevComponents.DotNetBar.eGrabHandleStyle.CaptionTaskPane;
            this.barTaskPane.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.TaskPane1});
            this.barTaskPane.LayoutType = DevComponents.DotNetBar.eLayoutType.DockContainer;
            this.barTaskPane.Location = new System.Drawing.Point(3, 0);
            this.barTaskPane.Name = "barTaskPane";
            this.barTaskPane.Size = new System.Drawing.Size(189, 417);
            this.barTaskPane.Stretch = true;
            this.barTaskPane.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.barTaskPane.TabIndex = 0;
            this.barTaskPane.TabStop = false;
            // 
            // panelDockContainer4
            // 
            this.panelDockContainer4.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.panelDockContainer4.Controls.Add(this.explorerBar1);
            this.panelDockContainer4.Location = new System.Drawing.Point(3, 26);
            this.panelDockContainer4.Name = "panelDockContainer4";
            this.panelDockContainer4.Size = new System.Drawing.Size(183, 388);
            this.panelDockContainer4.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelDockContainer4.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.panelDockContainer4.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.panelDockContainer4.Style.GradientAngle = 90;
            this.panelDockContainer4.TabIndex = 2;
            // 
            // explorerBar1
            // 
            this.explorerBar1.AccessibleRole = System.Windows.Forms.AccessibleRole.ToolBar;
            this.explorerBar1.BackColor = System.Drawing.SystemColors.Control;
            // 
            // 
            // 
            this.explorerBar1.BackStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.explorerBar1.BackStyle.BackColorGradientAngle = 90;
            this.explorerBar1.BackStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.explorerBar1.BackStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.explorerBar1.Cursor = System.Windows.Forms.Cursors.Default;
            this.explorerBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.explorerBar1.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.explorerBar1.GroupImages = null;
            this.explorerBar1.Groups.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.explorerBarGroupItem_AttendTime,
            this.explorerBarGroupItem_AttendMissions,
            this.explorerBarGroupItem2,
            this.explorerBarGroupItem_Exit});
            this.explorerBar1.Images = null;
            this.explorerBar1.Location = new System.Drawing.Point(0, 0);
            this.explorerBar1.Name = "explorerBar1";
            this.explorerBar1.Size = new System.Drawing.Size(183, 388);
            this.explorerBar1.TabIndex = 4;
            this.explorerBar1.Text = "explorerBar1";
            // 
            // explorerBarGroupItem_AttendTime
            // 
            // 
            // 
            // 
            this.explorerBarGroupItem_AttendTime.BackStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(223)))), ((int)(((byte)(247)))));
            this.explorerBarGroupItem_AttendTime.BackStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.explorerBarGroupItem_AttendTime.BackStyle.BorderBottomWidth = 1;
            this.explorerBarGroupItem_AttendTime.BackStyle.BorderColor = System.Drawing.Color.White;
            this.explorerBarGroupItem_AttendTime.BackStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.explorerBarGroupItem_AttendTime.BackStyle.BorderLeftWidth = 1;
            this.explorerBarGroupItem_AttendTime.BackStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.explorerBarGroupItem_AttendTime.BackStyle.BorderRightWidth = 1;
            this.explorerBarGroupItem_AttendTime.BackStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.explorerBarGroupItem_AttendTime.Cursor = System.Windows.Forms.Cursors.Default;
            this.explorerBarGroupItem_AttendTime.Expanded = true;
            this.explorerBarGroupItem_AttendTime.Name = "explorerBarGroupItem_AttendTime";
            this.explorerBarGroupItem_AttendTime.StockStyle = DevComponents.DotNetBar.eExplorerBarStockStyle.SystemColors;
            this.explorerBarGroupItem_AttendTime.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.buttonItem_Attend,
            this.buttonItem_AttendHand,
            this.buttonItem_ImportAttend});
            this.explorerBarGroupItem_AttendTime.Text = "التحضير والإنصراف";
            // 
            // 
            // 
            this.explorerBarGroupItem_AttendTime.TitleHotStyle.BackColor = System.Drawing.Color.White;
            this.explorerBarGroupItem_AttendTime.TitleHotStyle.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(211)))), ((int)(((byte)(247)))));
            this.explorerBarGroupItem_AttendTime.TitleHotStyle.CornerDiameter = 3;
            this.explorerBarGroupItem_AttendTime.TitleHotStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.explorerBarGroupItem_AttendTime.TitleHotStyle.CornerTypeTopLeft = DevComponents.DotNetBar.eCornerType.Rounded;
            this.explorerBarGroupItem_AttendTime.TitleHotStyle.CornerTypeTopRight = DevComponents.DotNetBar.eCornerType.Rounded;
            this.explorerBarGroupItem_AttendTime.TitleHotStyle.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(142)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.explorerBarGroupItem_AttendTime.TitleStyle.BackColor = System.Drawing.Color.White;
            this.explorerBarGroupItem_AttendTime.TitleStyle.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(211)))), ((int)(((byte)(247)))));
            this.explorerBarGroupItem_AttendTime.TitleStyle.CornerDiameter = 3;
            this.explorerBarGroupItem_AttendTime.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.explorerBarGroupItem_AttendTime.TitleStyle.CornerTypeTopLeft = DevComponents.DotNetBar.eCornerType.Rounded;
            this.explorerBarGroupItem_AttendTime.TitleStyle.CornerTypeTopRight = DevComponents.DotNetBar.eCornerType.Rounded;
            this.explorerBarGroupItem_AttendTime.TitleStyle.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(93)))), ((int)(((byte)(198)))));
            // 
            // buttonItem_Attend
            // 
            this.buttonItem_Attend.AutoCheckOnClick = true;
            this.buttonItem_Attend.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonItem_Attend.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonItem_Attend.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(93)))), ((int)(((byte)(198)))));
            this.buttonItem_Attend.HotFontUnderline = true;
            this.buttonItem_Attend.HotForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(142)))), ((int)(((byte)(255)))));
            this.buttonItem_Attend.HotTrackingStyle = DevComponents.DotNetBar.eHotTrackingStyle.None;
            this.buttonItem_Attend.Name = "buttonItem_Attend";
            this.buttonItem_Attend.Text = "تسجيل الحضور والإنصراف";
            this.buttonItem_Attend.Click += new System.EventHandler(this.buttonItem_Attend_Click);
            // 
            // buttonItem_AttendHand
            // 
            this.buttonItem_AttendHand.AutoCheckOnClick = true;
            this.buttonItem_AttendHand.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonItem_AttendHand.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonItem_AttendHand.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(93)))), ((int)(((byte)(198)))));
            this.buttonItem_AttendHand.HotFontUnderline = true;
            this.buttonItem_AttendHand.HotForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(142)))), ((int)(((byte)(255)))));
            this.buttonItem_AttendHand.HotTrackingStyle = DevComponents.DotNetBar.eHotTrackingStyle.None;
            this.buttonItem_AttendHand.Name = "buttonItem_AttendHand";
            this.buttonItem_AttendHand.Text = "الحضور والإنصراف يدويـــاُ";
            this.buttonItem_AttendHand.Click += new System.EventHandler(this.buttonItem_AttendHand_Click);
            // 
            // buttonItem_ImportAttend
            // 
            this.buttonItem_ImportAttend.AutoCheckOnClick = true;
            this.buttonItem_ImportAttend.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonItem_ImportAttend.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonItem_ImportAttend.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(93)))), ((int)(((byte)(198)))));
            this.buttonItem_ImportAttend.HotFontUnderline = true;
            this.buttonItem_ImportAttend.HotForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(142)))), ((int)(((byte)(255)))));
            this.buttonItem_ImportAttend.HotTrackingStyle = DevComponents.DotNetBar.eHotTrackingStyle.None;
            this.buttonItem_ImportAttend.Name = "buttonItem_ImportAttend";
            this.buttonItem_ImportAttend.Text = "استيراد بيانات الــدوام";
            this.buttonItem_ImportAttend.Click += new System.EventHandler(this.buttonItem_ImportAttend_Click);
            // 
            // explorerBarGroupItem_AttendMissions
            // 
            // 
            // 
            // 
            this.explorerBarGroupItem_AttendMissions.BackStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(223)))), ((int)(((byte)(247)))));
            this.explorerBarGroupItem_AttendMissions.BackStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.explorerBarGroupItem_AttendMissions.BackStyle.BorderBottomWidth = 1;
            this.explorerBarGroupItem_AttendMissions.BackStyle.BorderColor = System.Drawing.Color.White;
            this.explorerBarGroupItem_AttendMissions.BackStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.explorerBarGroupItem_AttendMissions.BackStyle.BorderLeftWidth = 1;
            this.explorerBarGroupItem_AttendMissions.BackStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.explorerBarGroupItem_AttendMissions.BackStyle.BorderRightWidth = 1;
            this.explorerBarGroupItem_AttendMissions.BackStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.explorerBarGroupItem_AttendMissions.Cursor = System.Windows.Forms.Cursors.Default;
            this.explorerBarGroupItem_AttendMissions.Expanded = true;
            this.explorerBarGroupItem_AttendMissions.Name = "explorerBarGroupItem_AttendMissions";
            this.explorerBarGroupItem_AttendMissions.StockStyle = DevComponents.DotNetBar.eExplorerBarStockStyle.SystemColors;
            this.explorerBarGroupItem_AttendMissions.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.buttonItem_GenAttend,
            this.buttonItem_AttendEdit,
            this.buttonItem_AttendLate});
            this.explorerBarGroupItem_AttendMissions.Text = "المهام والعمليات";
            // 
            // 
            // 
            this.explorerBarGroupItem_AttendMissions.TitleHotStyle.BackColor = System.Drawing.Color.White;
            this.explorerBarGroupItem_AttendMissions.TitleHotStyle.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(211)))), ((int)(((byte)(247)))));
            this.explorerBarGroupItem_AttendMissions.TitleHotStyle.CornerDiameter = 3;
            this.explorerBarGroupItem_AttendMissions.TitleHotStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.explorerBarGroupItem_AttendMissions.TitleHotStyle.CornerTypeTopLeft = DevComponents.DotNetBar.eCornerType.Rounded;
            this.explorerBarGroupItem_AttendMissions.TitleHotStyle.CornerTypeTopRight = DevComponents.DotNetBar.eCornerType.Rounded;
            this.explorerBarGroupItem_AttendMissions.TitleHotStyle.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(142)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.explorerBarGroupItem_AttendMissions.TitleStyle.BackColor = System.Drawing.Color.White;
            this.explorerBarGroupItem_AttendMissions.TitleStyle.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(211)))), ((int)(((byte)(247)))));
            this.explorerBarGroupItem_AttendMissions.TitleStyle.CornerDiameter = 3;
            this.explorerBarGroupItem_AttendMissions.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.explorerBarGroupItem_AttendMissions.TitleStyle.CornerTypeTopLeft = DevComponents.DotNetBar.eCornerType.Rounded;
            this.explorerBarGroupItem_AttendMissions.TitleStyle.CornerTypeTopRight = DevComponents.DotNetBar.eCornerType.Rounded;
            this.explorerBarGroupItem_AttendMissions.TitleStyle.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(93)))), ((int)(((byte)(198)))));
            // 
            // buttonItem_GenAttend
            // 
            this.buttonItem_GenAttend.AutoCheckOnClick = true;
            this.buttonItem_GenAttend.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonItem_GenAttend.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonItem_GenAttend.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(93)))), ((int)(((byte)(198)))));
            this.buttonItem_GenAttend.HotFontUnderline = true;
            this.buttonItem_GenAttend.HotForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(142)))), ((int)(((byte)(255)))));
            this.buttonItem_GenAttend.HotTrackingStyle = DevComponents.DotNetBar.eHotTrackingStyle.None;
            this.buttonItem_GenAttend.Name = "buttonItem_GenAttend";
            this.buttonItem_GenAttend.Text = "تعميم أوقات الدوام";
            this.buttonItem_GenAttend.Click += new System.EventHandler(this.buttonItem_GenAttend_Click);
            // 
            // buttonItem_AttendEdit
            // 
            this.buttonItem_AttendEdit.AutoCheckOnClick = true;
            this.buttonItem_AttendEdit.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonItem_AttendEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonItem_AttendEdit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(93)))), ((int)(((byte)(198)))));
            this.buttonItem_AttendEdit.HotFontUnderline = true;
            this.buttonItem_AttendEdit.HotForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(142)))), ((int)(((byte)(255)))));
            this.buttonItem_AttendEdit.HotTrackingStyle = DevComponents.DotNetBar.eHotTrackingStyle.None;
            this.buttonItem_AttendEdit.Name = "buttonItem_AttendEdit";
            this.buttonItem_AttendEdit.Text = "التعديل على الدوام";
            this.buttonItem_AttendEdit.Click += new System.EventHandler(this.buttonItem_AttendEdit_Click);
            // 
            // buttonItem_AttendLate
            // 
            this.buttonItem_AttendLate.AutoCheckOnClick = true;
            this.buttonItem_AttendLate.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonItem_AttendLate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonItem_AttendLate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(93)))), ((int)(((byte)(198)))));
            this.buttonItem_AttendLate.HotFontUnderline = true;
            this.buttonItem_AttendLate.HotForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(142)))), ((int)(((byte)(255)))));
            this.buttonItem_AttendLate.HotTrackingStyle = DevComponents.DotNetBar.eHotTrackingStyle.None;
            this.buttonItem_AttendLate.Name = "buttonItem_AttendLate";
            this.buttonItem_AttendLate.Text = "معالجة بيانات الدوام";
            this.buttonItem_AttendLate.Click += new System.EventHandler(this.buttonItem_AttendLate_Click);
            // 
            // explorerBarGroupItem2
            // 
            // 
            // 
            // 
            this.explorerBarGroupItem2.BackStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(223)))), ((int)(((byte)(247)))));
            this.explorerBarGroupItem2.BackStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.explorerBarGroupItem2.BackStyle.BorderBottomWidth = 1;
            this.explorerBarGroupItem2.BackStyle.BorderColor = System.Drawing.Color.White;
            this.explorerBarGroupItem2.BackStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.explorerBarGroupItem2.BackStyle.BorderLeftWidth = 1;
            this.explorerBarGroupItem2.BackStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.explorerBarGroupItem2.BackStyle.BorderRightWidth = 1;
            this.explorerBarGroupItem2.BackStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.explorerBarGroupItem2.Cursor = System.Windows.Forms.Cursors.Default;
            this.explorerBarGroupItem2.Expanded = true;
            this.explorerBarGroupItem2.Name = "explorerBarGroupItem2";
            this.explorerBarGroupItem2.StockStyle = DevComponents.DotNetBar.eExplorerBarStockStyle.SystemColors;
            this.explorerBarGroupItem2.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.buttonItem_RepAttend,
            this.buttonItem_RepPRojectFilter});
            this.explorerBarGroupItem2.Text = "التقــــارير";
            // 
            // 
            // 
            this.explorerBarGroupItem2.TitleHotStyle.BackColor = System.Drawing.Color.White;
            this.explorerBarGroupItem2.TitleHotStyle.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(211)))), ((int)(((byte)(247)))));
            this.explorerBarGroupItem2.TitleHotStyle.CornerDiameter = 3;
            this.explorerBarGroupItem2.TitleHotStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.explorerBarGroupItem2.TitleHotStyle.CornerTypeTopLeft = DevComponents.DotNetBar.eCornerType.Rounded;
            this.explorerBarGroupItem2.TitleHotStyle.CornerTypeTopRight = DevComponents.DotNetBar.eCornerType.Rounded;
            this.explorerBarGroupItem2.TitleHotStyle.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(142)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.explorerBarGroupItem2.TitleStyle.BackColor = System.Drawing.Color.White;
            this.explorerBarGroupItem2.TitleStyle.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(211)))), ((int)(((byte)(247)))));
            this.explorerBarGroupItem2.TitleStyle.CornerDiameter = 3;
            this.explorerBarGroupItem2.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.explorerBarGroupItem2.TitleStyle.CornerTypeTopLeft = DevComponents.DotNetBar.eCornerType.Rounded;
            this.explorerBarGroupItem2.TitleStyle.CornerTypeTopRight = DevComponents.DotNetBar.eCornerType.Rounded;
            this.explorerBarGroupItem2.TitleStyle.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(93)))), ((int)(((byte)(198)))));
            // 
            // buttonItem_RepAttend
            // 
            this.buttonItem_RepAttend.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonItem_RepAttend.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonItem_RepAttend.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(93)))), ((int)(((byte)(198)))));
            this.buttonItem_RepAttend.HotFontUnderline = true;
            this.buttonItem_RepAttend.HotForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(142)))), ((int)(((byte)(255)))));
            this.buttonItem_RepAttend.HotTrackingStyle = DevComponents.DotNetBar.eHotTrackingStyle.None;
            this.buttonItem_RepAttend.Name = "buttonItem_RepAttend";
            this.buttonItem_RepAttend.Text = "تقرير الحضور والإنصراف - الدوام";
            this.buttonItem_RepAttend.Click += new System.EventHandler(this.buttonItem_RepAttend_Click);
            // 
            // buttonItem_RepPRojectFilter
            // 
            this.buttonItem_RepPRojectFilter.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonItem_RepPRojectFilter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonItem_RepPRojectFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(93)))), ((int)(((byte)(198)))));
            this.buttonItem_RepPRojectFilter.HotFontUnderline = true;
            this.buttonItem_RepPRojectFilter.HotForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(142)))), ((int)(((byte)(255)))));
            this.buttonItem_RepPRojectFilter.HotTrackingStyle = DevComponents.DotNetBar.eHotTrackingStyle.None;
            this.buttonItem_RepPRojectFilter.Name = "buttonItem_RepPRojectFilter";
            this.buttonItem_RepPRojectFilter.Text = "فرز الموظف حسب المشروع";
            this.buttonItem_RepPRojectFilter.Click += new System.EventHandler(this.buttonItem_RepPRojectFilter_Click);
            // 
            // explorerBarGroupItem_Exit
            // 
            // 
            // 
            // 
            this.explorerBarGroupItem_Exit.BackStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(223)))), ((int)(((byte)(247)))));
            this.explorerBarGroupItem_Exit.BackStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.explorerBarGroupItem_Exit.BackStyle.BorderBottomWidth = 1;
            this.explorerBarGroupItem_Exit.BackStyle.BorderColor = System.Drawing.Color.White;
            this.explorerBarGroupItem_Exit.BackStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.explorerBarGroupItem_Exit.BackStyle.BorderLeftWidth = 1;
            this.explorerBarGroupItem_Exit.BackStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.explorerBarGroupItem_Exit.BackStyle.BorderRightWidth = 1;
            this.explorerBarGroupItem_Exit.BackStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.explorerBarGroupItem_Exit.Cursor = System.Windows.Forms.Cursors.Default;
            this.explorerBarGroupItem_Exit.Expanded = true;
            this.explorerBarGroupItem_Exit.Name = "explorerBarGroupItem_Exit";
            this.explorerBarGroupItem_Exit.StockStyle = DevComponents.DotNetBar.eExplorerBarStockStyle.SystemColors;
            this.explorerBarGroupItem_Exit.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.buttonItem_Close});
            this.explorerBarGroupItem_Exit.Text = "النافــذة";
            // 
            // 
            // 
            this.explorerBarGroupItem_Exit.TitleHotStyle.BackColor = System.Drawing.Color.White;
            this.explorerBarGroupItem_Exit.TitleHotStyle.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(211)))), ((int)(((byte)(247)))));
            this.explorerBarGroupItem_Exit.TitleHotStyle.CornerDiameter = 3;
            this.explorerBarGroupItem_Exit.TitleHotStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.explorerBarGroupItem_Exit.TitleHotStyle.CornerTypeTopLeft = DevComponents.DotNetBar.eCornerType.Rounded;
            this.explorerBarGroupItem_Exit.TitleHotStyle.CornerTypeTopRight = DevComponents.DotNetBar.eCornerType.Rounded;
            this.explorerBarGroupItem_Exit.TitleHotStyle.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(142)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.explorerBarGroupItem_Exit.TitleStyle.BackColor = System.Drawing.Color.White;
            this.explorerBarGroupItem_Exit.TitleStyle.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(211)))), ((int)(((byte)(247)))));
            this.explorerBarGroupItem_Exit.TitleStyle.CornerDiameter = 3;
            this.explorerBarGroupItem_Exit.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.explorerBarGroupItem_Exit.TitleStyle.CornerTypeTopLeft = DevComponents.DotNetBar.eCornerType.Rounded;
            this.explorerBarGroupItem_Exit.TitleStyle.CornerTypeTopRight = DevComponents.DotNetBar.eCornerType.Rounded;
            this.explorerBarGroupItem_Exit.TitleStyle.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(93)))), ((int)(((byte)(198)))));
            // 
            // buttonItem_Close
            // 
            this.buttonItem_Close.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonItem_Close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonItem_Close.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(93)))), ((int)(((byte)(198)))));
            this.buttonItem_Close.HotFontUnderline = true;
            this.buttonItem_Close.HotForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(142)))), ((int)(((byte)(255)))));
            this.buttonItem_Close.HotTrackingStyle = DevComponents.DotNetBar.eHotTrackingStyle.None;
            this.buttonItem_Close.Name = "buttonItem_Close";
            this.buttonItem_Close.Text = "خــــــروج";
            this.buttonItem_Close.Click += new System.EventHandler(this.buttonItem_Close_Click);
            // 
            // TaskPane1
            // 
            this.TaskPane1.Control = this.panelDockContainer4;
            this.TaskPane1.DefaultFloatingSize = new System.Drawing.Size(193, 290);
            this.TaskPane1.GlobalItem = true;
            this.TaskPane1.GlobalName = "TaskPane1";
            this.TaskPane1.Name = "TaskPane1";
            // 
            // mdiClient1
            // 
            this.mdiClient1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mdiClient1.Location = new System.Drawing.Point(26, 25);
            this.mdiClient1.Name = "mdiClient1";
            this.mdiClient1.Size = new System.Drawing.Size(491, 417);
            this.mdiClient1.TabIndex = 17;
            // 
            // dockSite1
            // 
            this.dockSite1.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite1.Dock = System.Windows.Forms.DockStyle.Left;
            this.dockSite1.Location = new System.Drawing.Point(0, 25);
            this.dockSite1.Name = "dockSite1";
            this.dockSite1.Size = new System.Drawing.Size(0, 417);
            this.dockSite1.TabIndex = 20;
            this.dockSite1.TabStop = false;
            // 
            // dockSite2
            // 
            this.dockSite2.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite2.Dock = System.Windows.Forms.DockStyle.Right;
            this.dockSite2.Location = new System.Drawing.Point(709, 25);
            this.dockSite2.Name = "dockSite2";
            this.dockSite2.Size = new System.Drawing.Size(0, 417);
            this.dockSite2.TabIndex = 21;
            this.dockSite2.TabStop = false;
            // 
            // dockSite3
            // 
            this.dockSite3.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite3.Controls.Add(this.mainmenu);
            this.dockSite3.Dock = System.Windows.Forms.DockStyle.Top;
            this.dockSite3.Location = new System.Drawing.Point(0, 0);
            this.dockSite3.Name = "dockSite3";
            this.dockSite3.Size = new System.Drawing.Size(709, 25);
            this.dockSite3.TabIndex = 22;
            this.dockSite3.TabStop = false;
            // 
            // mainmenu
            // 
            this.mainmenu.AccessibleDescription = "Main Menu (mainmenu)";
            this.mainmenu.AccessibleName = "Main Menu";
            this.mainmenu.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuBar;
            this.mainmenu.DockSide = DevComponents.DotNetBar.eDockSide.Top;
            this.mainmenu.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.mainmenu.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.bChangeStyle});
            this.mainmenu.Location = new System.Drawing.Point(0, 0);
            this.mainmenu.LockDockPosition = true;
            this.mainmenu.MenuBar = true;
            this.mainmenu.Name = "mainmenu";
            this.mainmenu.Size = new System.Drawing.Size(709, 24);
            this.mainmenu.Stretch = true;
            this.mainmenu.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.mainmenu.TabIndex = 0;
            this.mainmenu.TabStop = false;
            this.mainmenu.Text = "Main Menu";
            // 
            // bChangeStyle
            // 
            this.bChangeStyle.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.bChangeStyle.GlobalName = "bChangeStyle";
            this.bChangeStyle.Image = ((System.Drawing.Image)(resources.GetObject("bChangeStyle.Image")));
            this.bChangeStyle.ImagePosition = DevComponents.DotNetBar.eImagePosition.Right;
            this.bChangeStyle.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far;
            this.bChangeStyle.Name = "bChangeStyle";
            this.bChangeStyle.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.cmdStyleOffice2003,
            this.cmdStyleVS2005,
            this.cmdStyleOfficeXP,
            this.cmdStyleOffice2007Blue});
            this.bChangeStyle.Text = "الإستايل";
            // 
            // cmdStyleOffice2003
            // 
            this.cmdStyleOffice2003.GlobalName = "StyleOffice2003";
            this.cmdStyleOffice2003.Name = "cmdStyleOffice2003";
            this.cmdStyleOffice2003.Text = "Office 2003";
            this.cmdStyleOffice2003.Click += new System.EventHandler(this.cmdStyleOffice2003_Click);
            // 
            // cmdStyleVS2005
            // 
            this.cmdStyleVS2005.GlobalName = "StyleVS2005";
            this.cmdStyleVS2005.Name = "cmdStyleVS2005";
            this.cmdStyleVS2005.Text = "VS 2005";
            this.cmdStyleVS2005.Click += new System.EventHandler(this.cmdStyleVS2005_Click);
            // 
            // cmdStyleOfficeXP
            // 
            this.cmdStyleOfficeXP.GlobalName = "StyleOfficeXP";
            this.cmdStyleOfficeXP.Name = "cmdStyleOfficeXP";
            this.cmdStyleOfficeXP.Text = "Office XP";
            this.cmdStyleOfficeXP.Click += new System.EventHandler(this.cmdStyleOfficeXP_Click);
            // 
            // cmdStyleOffice2007Blue
            // 
            this.cmdStyleOffice2007Blue.GlobalName = "StyleOffice2007Blue";
            this.cmdStyleOffice2007Blue.Name = "cmdStyleOffice2007Blue";
            this.cmdStyleOffice2007Blue.Text = "Office 2007";
            this.cmdStyleOffice2007Blue.Click += new System.EventHandler(this.cmdStyleOffice2007Blue_Click);
            // 
            // dockSite4
            // 
            this.dockSite4.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dockSite4.Location = new System.Drawing.Point(0, 442);
            this.dockSite4.Name = "dockSite4";
            this.dockSite4.Size = new System.Drawing.Size(709, 0);
            this.dockSite4.TabIndex = 23;
            this.dockSite4.TabStop = false;
            // 
            // TaskPane2
            // 
            this.TaskPane2.DefaultFloatingSize = new System.Drawing.Size(193, 290);
            this.TaskPane2.GlobalItem = true;
            this.TaskPane2.GlobalName = "TaskPane2";
            this.TaskPane2.Name = "TaskPane2";
            this.TaskPane2.Text = "Research";
            // 
            // Main_Panel
            // 
            this.Main_Panel.CanvasColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Main_Panel.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this.Main_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Main_Panel.Location = new System.Drawing.Point(0, 0);
            this.Main_Panel.Name = "Main_Panel";
            this.Main_Panel.Size = new System.Drawing.Size(709, 459);
            this.Main_Panel.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.Main_Panel.Style.BackColor1.Color = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Main_Panel.Style.BackgroundImagePosition = DevComponents.DotNetBar.eBackgroundImagePosition.Tile;
            this.Main_Panel.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.Main_Panel.Style.GradientAngle = 90;
            this.Main_Panel.Style.WordWrap = true;
            this.Main_Panel.TabIndex = 1103;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Magenta;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            this.imageList1.Images.SetKeyName(2, "");
            this.imageList1.Images.SetKeyName(3, "");
            this.imageList1.Images.SetKeyName(4, "");
            this.imageList1.Images.SetKeyName(5, "");
            this.imageList1.Images.SetKeyName(6, "");
            this.imageList1.Images.SetKeyName(7, "");
            this.imageList1.Images.SetKeyName(8, "");
            this.imageList1.Images.SetKeyName(9, "");
            this.imageList1.Images.SetKeyName(10, "");
            this.imageList1.Images.SetKeyName(11, "");
            this.imageList1.Images.SetKeyName(12, "");
            this.imageList1.Images.SetKeyName(13, "");
            this.imageList1.Images.SetKeyName(14, "");
            this.imageList1.Images.SetKeyName(15, "");
            this.imageList1.Images.SetKeyName(16, "");
            this.imageList1.Images.SetKeyName(17, "");
            this.imageList1.Images.SetKeyName(18, "");
            this.imageList1.Images.SetKeyName(19, "");
            this.imageList1.Images.SetKeyName(20, "");
            this.imageList1.Images.SetKeyName(21, "");
            this.imageList1.Images.SetKeyName(22, "");
            this.imageList1.Images.SetKeyName(23, "");
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
            this.dotNetBarManager1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.dotNetBarManager1.ToolbarBottomDockSite = this.dockSite4;
            this.dotNetBarManager1.ToolbarLeftDockSite = this.dockSite1;
            this.dotNetBarManager1.ToolbarRightDockSite = this.dockSite2;
            this.dotNetBarManager1.ToolbarTopDockSite = this.dockSite3;
            this.dotNetBarManager1.TopDockSite = this.barTopDockSite;
            // 
            // buttonItem26
            // 
            this.buttonItem26.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(93)))), ((int)(((byte)(198)))));
            this.buttonItem26.HotFontUnderline = true;
            this.buttonItem26.HotForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(142)))), ((int)(((byte)(255)))));
            this.buttonItem26.HotTrackingStyle = DevComponents.DotNetBar.eHotTrackingStyle.None;
            this.buttonItem26.Name = "buttonItem26";
            this.buttonItem26.PopupSide = DevComponents.DotNetBar.ePopupSide.Left;
            this.buttonItem26.Text = "· Automatically update this list from web";
            // 
            // buttonItem32
            // 
            this.buttonItem32.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(93)))), ((int)(((byte)(198)))));
            this.buttonItem32.HotFontUnderline = true;
            this.buttonItem32.HotForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(142)))), ((int)(((byte)(255)))));
            this.buttonItem32.HotTrackingStyle = DevComponents.DotNetBar.eHotTrackingStyle.None;
            this.buttonItem32.Name = "buttonItem32";
            this.buttonItem32.PopupSide = DevComponents.DotNetBar.ePopupSide.Left;
            this.buttonItem32.Text = "· Connect to DevComponents Online";
            // 
            // explorerBarGroupItem1
            // 
            // 
            // 
            // 
            this.explorerBarGroupItem1.BackStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.explorerBarGroupItem1.BackStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.explorerBarGroupItem1.BackStyle.BorderColor = System.Drawing.Color.White;
            this.explorerBarGroupItem1.BackStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.explorerBarGroupItem1.BackStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.explorerBarGroupItem1.BackStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.explorerBarGroupItem1.BackStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.explorerBarGroupItem1.Cursor = System.Windows.Forms.Cursors.Default;
            this.explorerBarGroupItem1.ExpandBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(182)))), ((int)(((byte)(216)))));
            this.explorerBarGroupItem1.ExpandButtonVisible = false;
            this.explorerBarGroupItem1.Expanded = true;
            this.explorerBarGroupItem1.ExpandForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(60)))), ((int)(((byte)(165)))));
            this.explorerBarGroupItem1.ExpandHotBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(182)))), ((int)(((byte)(216)))));
            this.explorerBarGroupItem1.ExpandHotForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(142)))), ((int)(((byte)(255)))));
            this.explorerBarGroupItem1.HeaderExpands = false;
            this.explorerBarGroupItem1.Name = "explorerBarGroupItem1";
            this.explorerBarGroupItem1.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.buttonItem32,
            this.buttonItem26});
            this.explorerBarGroupItem1.Text = "Assistance";
            // 
            // 
            // 
            this.explorerBarGroupItem1.TitleHotStyle.BackColor = System.Drawing.Color.White;
            this.explorerBarGroupItem1.TitleHotStyle.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(211)))), ((int)(((byte)(247)))));
            this.explorerBarGroupItem1.TitleHotStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.explorerBarGroupItem1.TitleHotStyle.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World);
            this.explorerBarGroupItem1.TitleHotStyle.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(142)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.explorerBarGroupItem1.TitleStyle.BackColor = System.Drawing.Color.White;
            this.explorerBarGroupItem1.TitleStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.explorerBarGroupItem1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.explorerBarGroupItem1.TitleStyle.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World);
            this.explorerBarGroupItem1.TitleStyle.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(93)))), ((int)(((byte)(198)))));
            // 
            // buttonItem31
            // 
            this.buttonItem31.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(93)))), ((int)(((byte)(198)))));
            this.buttonItem31.HotFontUnderline = true;
            this.buttonItem31.HotForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(142)))), ((int)(((byte)(255)))));
            this.buttonItem31.HotTrackingStyle = DevComponents.DotNetBar.eHotTrackingStyle.None;
            this.buttonItem31.Name = "buttonItem31";
            this.buttonItem31.PopupSide = DevComponents.DotNetBar.ePopupSide.Left;
            this.buttonItem31.Text = "· Get latest news about using this product";
            // 
            // dockContainerItem1
            // 
            this.dockContainerItem1.Name = "dockContainerItem1";
            this.dockContainerItem1.Text = "dockContainerItem1";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // netResize1
            // 
            this.netResize1.AutoSaveLayout = true;
            this.netResize1.ParentControl = this;
            // 
            // FrmGenAttend
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(709, 459);
            this.Controls.Add(this.ribbonBar1);
            this.Controls.Add(this.Main_Panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "FrmGenAttend";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "نظــام الـــــــدوام";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmGenAttend_FormClosed);
            this.Load += new System.EventHandler(this.FrmGenAttend_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmGenAttend_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FrmGenAttend_KeyPress);
            this.ribbonBar1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ribbonBar_AttendMain.ResumeLayout(false);
            this.panelEx_ImportAttend.ResumeLayout(false);
            this.panelEx_ImportAttend.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ExcelGridView)).EndInit();
            this.panelEx_Attend.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel_PROJECTs.ResumeLayout(false);
            this.panel_PROJECTs.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_LateTime)).EndInit();
            this.panelEx_GeneralAttend.ResumeLayout(false);
            this.groupPanel_Time2.ResumeLayout(false);
            this.groupPanel_Time2.PerformLayout();
            this.groupPanel_Time1.ResumeLayout(false);
            this.groupPanel_Time1.PerformLayout();
            this.groupPanel_Day.ResumeLayout(false);
            this.groupPanel_Day.PerformLayout();
            this.panelEx_LateAttend.ResumeLayout(false);
            this.panelEx_LateAttend.PerformLayout();
            this.panelEx_EditAttend.ResumeLayout(false);
            this.panelEx_EditAttend.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX_RepDetils)).EndInit();
            this.panelEx_MenualAttend.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.expandablePanel_Girds.ResumeLayout(false);
            this.expandablePanel_Emp.ResumeLayout(false);
            this.itemPanel4.ResumeLayout(false);
            this.expandablePanel_Job.ResumeLayout(false);
            this.itemPanel3.ResumeLayout(false);
            this.expandablePanel_Section.ResumeLayout(false);
            this.itemPanel2.ResumeLayout(false);
            this.expandablePanel_Dept.ResumeLayout(false);
            this.itemPanel1.ResumeLayout(false);
            this.barRightDockSite.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.barTaskPane)).EndInit();
            this.barTaskPane.ResumeLayout(false);
            this.panelDockContainer4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.explorerBar1)).EndInit();
            this.dockSite3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainmenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).EndInit();
            this.ResumeLayout(false);
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
            InitializeComponent();
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
                    OpenFileDialog openFileDialog1 = new OpenFileDialog();
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
                    OpenFileDialog openFileDialog1 = new OpenFileDialog();
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
