using C1.Win.C1FlexGrid;
using DevComponents.AdvTree;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.Editors;
using InvAcc.GeneralM;
using InvAcc.Properties;
using InvAcc.Stock_Data;
using Microsoft.Win32;
using SSSDateTime.Date;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Linq;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial class FrmSystemSetting : Form
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
        private IContainer components = null;
        private void netResize1_AfterControlResize(object sender, Softgroup.NetResize.AfterControlResizeEventArgs e)
        {
            if (e.Control.GetType() == typeof(Label))
            {
                Label c = (e.Control as Label); if ((c.BackColor != System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))))) && (c.BackColor != System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))))) && (c.BackColor != System.Drawing.Color.SteelBlue))
                    c.BackColor = Color.Transparent; Size cc = c.PreferredSize;
                c.AutoSize = false;
                c.Size = cc;

                //  e.Control.Font= new System.Drawing.Font("Tahoma",(float) (c-0.5));

            }
        }


        private RibbonBar ribbonBar1;
        private SuperTabControl superTabControl1;
        private SuperTabControlPanel superTabControlPanel1;
        private SuperTabItem superTabItem_Banner;
        private SuperTabControlPanel superTabControlPanel3;
        private SuperTabItem superTabItem_Acc;
        private SuperTabControlPanel superTabControlPanel2;
        private SuperTabItem superTabItem_Inv;
        private GroupPanel groupPanel_Banner;
        private ButtonX button_ClearPic;
        private ButtonX button_EnterImg;
        private Label label9;
        private Label label8;
        private ComboBoxEx CmbInvMode;
        private ComboBoxEx CmbCost;
        private OpenFileDialog openFileDialog1;
        private SuperTabControlPanel superTabControlPanel5;
        private SuperTabItem superTabItem_General;
        private GroupPanel groupPanel2;
        private MaskedTextBox txtGregDate;
        private Button ButDayMinus;
        private MaskedTextBox txtHijriDate;
        private Button ButAddDay;
        private Label label6;
        private Label label7;
        private GroupPanel groupPanel_Backup;
        private TextBoxX textBox_BackupPath;
        private GroupPanel groupPanel4;
        private CheckBoxX chk1;
        private IntegerInput txtAutoNumber;
        private CheckBoxX chk3;
        private CheckBoxX chk2;
        private ComboBoxEx CmbDateTyp;
        private IntegerInput txtDateAlarm;
        private CheckBoxX ChkHead;
        private GroupPanel groupPanel5;
        private CheckBoxX ChkPageNumber;
        private CheckBoxX ChkGreg;
        private CheckBoxX ChkHijri;
        private ExpandablePanel expandablePanel_AutoAcc;
        private PictureBox PicItemImg;
        private Label label24;
        private Label label25;
        private ButtonX button_RemoveBackgroud;
        private ButtonX button_Background;
        private ReflectionImage pictureBox_EnterPic;
        private PictureBox picture_SSS;
        private LabelItem labelItem1;
        private CheckBoxX checkBox_AutoBackup;
        private ComboBoxEx comboBox_AutoBackup;
        private Label label5;
        private ComboBoxEx CmbCalendar;
        private TextBoxX dateTimeInput_DT;
        private GroupPanel groupPanel1;
        private GroupPanel groupPanel3;
        private Label label4;
        private TextBoxX txtHeadingL2;
        private Label label3;
        private TextBoxX txtHeadingL1;
        private Label label2;
        private TextBoxX txtHeadingR2;
        private Label label1;
        private TextBoxX txtHeadingR1;
        private TextBoxX txtHeadingL4;
        private TextBoxX txtHeadingR4;
        private TextBoxX txtHeadingL3;
        private TextBoxX txtHeadingR3;
        private GroupPanel groupPanel6;
        private TextBox txtRemark;
        private TextBox txtTel2;
        private Label label20;
        private Label label23;
        private TextBox txtMailCode;
        private Label label22;
        private TextBox txtPOBox;
        private Label label21;
        private TextBox txtFax;
        private Label label18;
        private TextBox txtMobile;
        private Label label19;
        private TextBox txtTel1;
        private Label label17;
        private TextBox txtAddr;
        private Label label16;
        private TextBox txtAct;
        private Label label15;
        private TextBox txtCompany;
        private Label label14;
        private CheckBoxX radioButton_IsNotBackground;
        private SuperTabControlPanel superTabControlPanel6;
        private GroupPanel groupPanel7;
        private CheckBoxX checkBox_VacationManually;
        private SuperTabItem superTabItem_Employee;
        private CheckBoxX checkBox_Sponer;
        private ExpandablePanel expandablePanel_Alarm;
        private GroupPanel groupPanel8;
        private Label label39;
        private IntegerInput textBox_AutoEmpLeaveAfter;
        private CheckBoxX checkBox_AttendanceManually;
        private CheckBoxX checkBox_AutoLeave;
        private GroupPanel groupPanel9;
        private Label label50;
        private CheckBoxX checkBox_IsAlarmEndVaction;
        private Label label49;
        private IntegerInput integerInput_AlarmVisaGoBack;
        private CheckBoxX checkBox_IsAlarmVisaGoBack;
        private Label label46;
        private IntegerInput integerInput_AlarmCarDocBefore;
        private CheckBoxX checkBox_IsAlarmCarDoc;
        private Label label45;
        private IntegerInput integerInput_AlarmSecretariatsBefore;
        private CheckBoxX checkBox_IsAlarmSecretariatsDoc;
        private Label label44;
        private IntegerInput integerInput_AlarmFamilyPassportBefore;
        private CheckBoxX checkBox_IsAlarmFamilyPassport;
        private Label label43;
        private IntegerInput integerInput_AlarmEmpContractBefore;
        private CheckBoxX checkBox_IsAlarmEmpContract;
        private Label label42;
        private IntegerInput integerInput_AlarmEmpDocBefore;
        private CheckBoxX checkBox_IsAlarmEmpDoc;
        private Label label41;
        private IntegerInput integerInput_AlarmGuarantorDocBefore;
        private CheckBoxX checkBox_IsAlarmGuarantorDoc;
        private Label label40;
        private IntegerInput integerInput_AlarmDeptsBefore;
        private CheckBoxX checkBox_IsAlarmDepts;
        private Panel panel11;
        private ButtonX button_DocPath;
        private TextBox textBox_DocPath;
        private Label label38;
        private ComboBox comboBox2;
        private IntegerInput integerInput_AlarmEndVactionBefore;
        private GroupBox groupBox3;
        private Label label37;
        private ComboBoxEx comboBox_DisVacationType;
        private Label label36;
        private ComboBoxEx comboBox_CalculateNo;
        private Label label35;
        private ComboBoxEx comboBox_CalculatliquidNo;
        private ButtonX button_DayofMonth;
        private Label label47;
        private IntegerInput txtDateAlarmEmps;
        private CheckBoxX chk19;
        private ExpandablePanel expandablePanel_NewColumn;
        private Panel panel1;
        private TextBox textBox_LineDetailNameE;
        private Label label55;
        private TextBox textBox_LineDetailNameA;
        private Label label53;
        private ProgressBarX progressBarX1;
        private AdvTree Tree_NewCol;
        private ElementStyle elementStyle4;
        private DevComponents.AdvTree.Node node1;
        private DevComponents.AdvTree.Node chk1Show;
        private DevComponents.AdvTree.Node chk1Print;
        private DevComponents.AdvTree.Node node2;
        private DevComponents.AdvTree.Node chk2Show;
        private DevComponents.AdvTree.Node chk2Print;
        private DevComponents.AdvTree.Node node3;
        private DevComponents.AdvTree.Node chk3Show;
        private DevComponents.AdvTree.Node chk3Print;
        private DevComponents.AdvTree.Node node4;
        private DevComponents.AdvTree.Node chk4Show;
        private DevComponents.AdvTree.Node chk4Print;
        private DevComponents.AdvTree.Node node5;
        private DevComponents.AdvTree.Node chk5Show;
        private DevComponents.AdvTree.Node chk5Print;
        private DevComponents.AdvTree.Node node6;
        private DevComponents.AdvTree.Node chk6Show;
        private DevComponents.AdvTree.Node chk6Print;
        private DevComponents.AdvTree.Node node7;
        private DevComponents.AdvTree.Node chk7Show;
        private DevComponents.AdvTree.Node chk7Print;
        private DevComponents.AdvTree.Node node8;
        private DevComponents.AdvTree.Node chk8Show;
        private DevComponents.AdvTree.Node chk8Print;
        private DevComponents.AdvTree.Node node9;
        private DevComponents.AdvTree.Node chk9Show;
        private DevComponents.AdvTree.Node chk9Print;
        private DevComponents.AdvTree.Node node10;
        private DevComponents.AdvTree.Node chk10Show;
        private DevComponents.AdvTree.Node chk10Print;
        private DevComponents.AdvTree.Node node11;
        private DevComponents.AdvTree.Node chk11Show;
        private DevComponents.AdvTree.Node chk11Print;
        private DevComponents.AdvTree.Node node12;
        private DevComponents.AdvTree.Node chk12Show;
        private DevComponents.AdvTree.Node chk12Print;
        private DevComponents.AdvTree.Node node13;
        private DevComponents.AdvTree.Node chk13Show;
        private DevComponents.AdvTree.Node chk13Print;
        private NodeConnector nodeConnector1;
        private ElementStyle elementStyle3;
        private TextBoxX textBox_BackupElectronic;
        private C1FlexGrid c1FlexGrid1;
        private Label label12;
        private Label label11;
        private Label label13;
        private TextBoxX txtProfits;
        private Label label10;
        private TextBoxX txtFirstInventory;
        private TextBoxX txtBoxAccount;
        private TextBoxX txtLastInventory;
        private C1FlexGrid FlxInv;
        private GroupPanel groupbox_AutoAcc;
        private Label label48;
        private ComboBoxEx CmbPrintTyp;
        private ComboBoxEx CmbPointImages;
        private Label label51;
        private DevComponents.AdvTree.Node node14;
        private DevComponents.AdvTree.Node chk14Show;
        private DevComponents.AdvTree.Node chk14Print;
        private TextBox txtEmailPass;
        private Label label54;
        private TextBox txtEmailBoss;
        private Label label52;
        private Label label56;
        private ComboBoxEx CmbMail;
        private GroupPanel groupPanel_Acc;
        private CheckBoxX chk27;
        private ComboBoxEx CmbCurr;
        private Label label57;
        private SwitchButton chk37;
        private Label label58;
        private ComboBoxEx chk39;
        private CheckBoxX chk24;
        private SuperTabControlPanel superTabControlPanel7;
        private SuperTabItem superTabItem_Hotel;
        private GroupPanel groupPanel10;
        private CheckBoxX checkBoxX3;
        private IntegerInput txtFloors;
        private Label label61;
        private IntegerInput txtRoom;
        private Label label64;
        private Label label63;
        private MaskedTextBox txtLeavePeriod;
        private MaskedTextBox txtAllowPeriod;
        internal GroupBox groupBox5;
        private CheckBoxX checkBox_NetWork;
        private CheckBoxX RadioBox_AllowPM;
        private CheckBoxX RadioBox_AllowAM;
        private Label label65;
        private IntegerInput txtDayofMonth;
        internal GroupBox groupBox6;
        private CheckBoxX checkBoxX1;
        private CheckBoxX RadioBox_LeavePM;
        private CheckBoxX RadioBox_LeaveAM;
        private Label label68;
        private Label label69;
        private IntegerInput txtLongitudinal;
        private Label label70;
        private Label label71;
        private IntegerInput txtWidthitudinal;
        private GroupPanel groupPanel11;
        private CheckBoxX checkBoxX12;
        private Label txtRLeave;
        private Label txtRRepair;
        private Label txtRBussyAppendix;
        private Label txtRAvailable;
        private Label txtRBussyMonthly;
        private Label txtRClean;
        private Label txtRBussyDaily;
        private Label txtREmpty;
        private ButtonX button_B3;
        private ButtonX button_F3;
        private ButtonX button_B1;
        private ButtonX button_F1;
        private ButtonX button_B8;
        private ButtonX button_F8;
        private ButtonX button_B6;
        private ButtonX button_F6;
        private ButtonX button_B4;
        private ButtonX button_F4;
        private ButtonX button_B2;
        private ButtonX button_F2;
        private ButtonX button_B7;
        private ButtonX button_F7;
        private ButtonX button_B5;
        private ButtonX button_F5;
        private Label label80;
        private Label label59;
        private Label label66;
        private Label label62;
        private Label label60;
        private TextBoxX txtGuestsFatherAcc;
        private Label label67;
        private TextBoxX txtGuestBoxAcc;
        private Label label72;
        private CheckBoxX chk42;
        private TextBoxX txtGuestsFatherAccName;
        private TextBoxX txtGuestBoxAccName;
        private CheckBoxX chk43;
        private Line line2;
        private CheckBoxX chk44;
        private CheckBoxX chk45;
        private ComboBoxEx chk46;
        private Label label73;
        private TextBoxX txtKeyNational;
        private MaskedTextBoxAdv masked00;
        private Label label74;
        private ComboBoxEx CmbOrderTyp;
        private Label label75;
        private ButtonX button_ManageRoom;
        private IntegerInput txtLinesInv;
        private Label label77;
        private SwitchButton switchButton_NewColumnName;
        private CheckBoxX chk65;
        private CheckBoxX ChkEmp1;
        private TextBoxX textBox_SyncPath;
        private Label label78;
        private CheckBoxX chk71;
        private Label label79;
        private SuperTabControlPanel superTabControlPanel11;
        private GroupPanel groupPanel13;
        private TextBoxX txttenantFatherAccName;
        private TextBoxX txtEqarsFatherAccName;
        private TextBoxX txtTenantFatherAcc;
        private Label label90;
        private TextBoxX txtEqarsFatherAcc;
        private Label label91;
        private Label label92;
        private Label label94;
        private IntegerInput txtEqarDayOfPayAlarm;
        private IntegerInput txtEqarContractEndAlarm;
        private CheckBoxX checkBoxX14;
        private Label label98;
        private Label label99;
        private SuperTabItem superTabItem_Eqar;
        private CheckBoxX chk76;
        private CheckBoxX chk77;
        private ButtonX button_RestoreDefContract;
        private PictureBox pictureBox1;
        public Dictionary<string, ColumnDictinary> columns_Names_visible = new Dictionary<string, ColumnDictinary>();
        private List<T_INVSETTING> listInvSetting = new List<T_INVSETTING>();
        private T_INVSETTING _InvSetting = new T_INVSETTING();
        private List<T_SYSSETTING> listSysSetting = new List<T_SYSSETTING>();
        private T_SYSSETTING _SysSetting = new T_SYSSETTING();
        private List<T_AccDef> listAccDef = new List<T_AccDef>();
        private T_AccDef _AccDef = new T_AccDef();
        private List<T_Company> listCompany = new List<T_Company>();
        private T_Company _Company = new T_Company();
        private List<T_GdAuto> listGdAuto = new List<T_GdAuto>();
        private T_GdAuto _GdAuto = new T_GdAuto();
        private List<T_InfoTb> listInfotb = new List<T_InfoTb>();
        private T_InfoTb _Infotb = new T_InfoTb();
        private int LangArEn = 0;
        private Stock_DataDataContext dbInstance;
        private HijriGreg.HijriGregDates n = new HijriGreg.HijriGregDates();
        private List<T_Room> listTableFamily = new List<T_Room>();
        private T_Room _TableFamily = new T_Room();
        private List<T_Room> listTableBoys = new List<T_Room>();
        private T_Room _TableBoys = new T_Room();
        private List<T_Room> listTableOut = new List<T_Room>();
        private T_Room _TableOut = new T_Room();
        private List<T_Room> listTableOther = new List<T_Room>();
        private T_Room _TableOther = new T_Room();
        protected bool ifOkDelete;
        public bool CanEdit = true;
        protected bool CanInsert = true;
        private FormState statex;
        public List<Control> controls;
        public Control codeControl = new Control();
        private SuperTabControlPanel superTabControlPanel12;
        private SuperTabItem superTabItem4;
        private SplitContainer splitContainer2;
        private SplitContainer splitContainer1;
        private TextBox textBox1;
        private C1FlexGrid c1FlexGrid2;
        private Label labelAlarmDueo;
        private IntegerInput txtAlarmDeuDateBefor;
        private CheckBoxX chk69;
        private Label label76;
        private IntegerInput txtDateofInv;
        private CheckBoxX chk58;
        private ComboBoxEx chk36;
        private SuperTabControl superTabControl2;
        private SuperTabControlPanel superTabControlPanel8;
        private CheckBoxX chk70;
        private CheckBoxX chk56;
        private CheckBoxX chk48;
        private CheckBoxX chk38;
        private ComboBoxEx comboBoxEx1;
        private CheckBoxX chk35;
        private CheckBoxX chk32;
        private CheckBoxX chk29;
        private CheckBoxX chk10;
        private CheckBoxX chk22;
        private CheckBoxX chk23;
        private CheckBoxX chk47;
        private CheckBoxX chk14;
        private CheckBoxX chk20;
        private CheckBoxX chk26;
        private CheckBoxX chk16;
        private CheckBoxX chk12;
        private CheckBoxX chk11;
        private CheckBoxX chk4;
        private CheckBoxX chk51;
        private CheckBoxX chk49;
        private CheckBoxX chk40;
        private CheckBoxX chk34;
        private CheckBoxX chk33;
        private CheckBoxX chk31;
        private CheckBoxX chk28;
        private CheckBoxX chk25;
        private CheckBoxX chk17;
        private CheckBoxX chk15;
        private CheckBoxX chk13;
        private CheckBoxX chk9;
        private CheckBoxX chk8;
        private CheckBoxX chk6;
        private CheckBoxX chk5;
        private CheckBoxX chk21;
        private CheckBoxX chk7;
        private CheckBoxX chk41;
        private SuperTabItem superTabItem2;
        private SuperTabControlPanel superTabControlPanel9;
        private CheckBoxX chk75;
        private CheckBoxX chk74;
        private CheckBoxX chk73;
        private CheckBoxX chk72;
        private Label label81;
        private IntegerInput integerInput1;
        private CheckBoxX checkBoxX2;
        private CheckBoxX chk68;
        private CheckBoxX chk67;
        private CheckBoxX chk66;
        private CheckBoxX chk64;
        private CheckBoxX chk50;
        private CheckBoxX chk63;
        private CheckBoxX chk62;
        private CheckBoxX chk61;
        private CheckBoxX chk60;
        private CheckBoxX chk59;
        private Label label82;
        private IntegerInput integerInput2;
        private CheckBoxX checkBoxX4;
        private CheckBoxX chk57;
        private CheckBoxX chk55;
        private CheckBoxX chk54;
        private CheckBoxX chk53;
        private CheckBoxX chk52;
        private CheckBoxX chk18;
        private SuperTabItem superTabItem3;
        private SuperTabControlPanel superTabControlPanel10;
        private SplitContainer splitContainer3;
        private SuperTabControlPanel superTabControlPanel13;
        private SuperTabItem superTabItem5;
        internal TextBox txtTaxNote;
        internal Label label83;
        private Panel panel2;
        internal TextBox txtTaxID;
        private ButtonX button_SrchTaxNo;
        private TextBox txtTaxNo;
        internal TextBox txtTaxName;
        internal Label label84;
        internal Label label4Tax;
        private Button ButGeneralPurchaesTax;
        private Label label2Tax;
        private Label label3Tax;
        private DoubleInput txtPurchaesTax;
        private Button ButGeneralSalesTax;
        private Label label1Tax;
        private Label label30Tax;
        private DoubleInput txtSalesTax;
        private C1FlexGrid c1FlexGriadTax;
        private ButtonX ButWithoutSave;
        private SplitContainer splitContainer4;
        private ButtonX ButWithSave;
        private GroupPanel groupPanel12;
        private C1FlexGrid c1FlexGrid1Bankopp;
        private SuperTabControlPanel superTabControlPanel14;
        private GroupPanel groupPanel14;
        private SuperTabItem superTabItem6;
        private CheckBoxX chkIsActive;
        private GroupPanel groupPanel_Main;
        private Label label2custDis;
        private ComboBoxEx cmbShowState;
        private ButtonX button_CheckConn;
        private TextBox txtHello;
        private Label label14CustDis;
        private GroupPanel groupPanel3CustDis;
        private CheckBoxX chkSync5;
        private CheckBoxX chkSync4;
        private CheckBoxX chkSync3;
        private CheckBoxX chkSync2;
        private CheckBoxX chkSync1;
        private GroupPanel groupPanel2CustDis;
        private CheckBoxX chkData5;
        private CheckBoxX chkData4;
        private CheckBoxX chkData3;
        private CheckBoxX chkData2;
        private CheckBoxX chkData1;
        private GroupPanel groupPanel1CustDis;
        private CheckBoxX chkStop3;
        private CheckBoxX chkStop2;
        private CheckBoxX chkStop1;
        private Label label1CustDis;
        private ComboBoxEx cmbFast;
        private Label label8CustDis;
        private ComboBoxEx cmbPort;
        private GroupPanel groupPanel15;
        private GroupBox groupBox7;
        private IntegerInput txtPriceQ;
        private Label label85;
        private IntegerInput txtWieghtQ;
        private Label label86;
        private IntegerInput txtPriceTo;
        private IntegerInput txtPriceFrom;
        private IntegerInput txtWightTo;
        private IntegerInput txtWightFrom;
        private IntegerInput txtBarcodTo;
        private IntegerInput txtBarcodFrom;
        private Label label87;
        private Label label88;
        private GroupBox groupBox8;
        private RadioButton RedButWightPrice;
        private RadioButton RedButPrice;
        private RadioButton RedButWight;
        private Label label89;
        private Label label93;
        private Label label95;
        private Label label96;
        private CheckBox checkBox_BalanceActivated;
        private ButtonX button_PointOfCust;
        private Label label97;
        private SuperTabControlPanel superTabControlPanel15;
        private SuperTabItem superTabItem7;
        private GroupPanel groupPanel16;
        private Label label100;
        private GroupPanel groupPanel17;
        private IntegerInput numbersafterdecimal;
        private Softgroup.NetResize.NetResize netResize1;
        private bool canUpdate = true;
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
        public bool SetReadOnly
        {
            set
            {
                if (value)
                {
                    State = FormState.Saved;
                }
                ButWithSave.Enabled = !value;
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
            DevComponents.DotNetBar.Rendering.SuperTabColorTable superTabColorTable1 = new DevComponents.DotNetBar.Rendering.SuperTabColorTable();
            DevComponents.DotNetBar.Rendering.SuperTabLinearGradientColorTable superTabLinearGradientColorTable7 = new DevComponents.DotNetBar.Rendering.SuperTabLinearGradientColorTable();
            DevComponents.DotNetBar.Rendering.SuperTabPanelColorTable superTabPanelColorTable2 = new DevComponents.DotNetBar.Rendering.SuperTabPanelColorTable();
            DevComponents.DotNetBar.Rendering.SuperTabPanelItemColorTable superTabPanelItemColorTable2 = new DevComponents.DotNetBar.Rendering.SuperTabPanelItemColorTable();
            DevComponents.DotNetBar.Rendering.SuperTabLinearGradientColorTable superTabLinearGradientColorTable2 = new DevComponents.DotNetBar.Rendering.SuperTabLinearGradientColorTable();
            DevComponents.DotNetBar.Rendering.SuperTabPanelColorTable superTabPanelColorTable1 = new DevComponents.DotNetBar.Rendering.SuperTabPanelColorTable();
            DevComponents.DotNetBar.Rendering.SuperTabPanelItemColorTable superTabPanelItemColorTable1 = new DevComponents.DotNetBar.Rendering.SuperTabPanelItemColorTable();
            DevComponents.DotNetBar.Rendering.SuperTabLinearGradientColorTable superTabLinearGradientColorTable1 = new DevComponents.DotNetBar.Rendering.SuperTabLinearGradientColorTable();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSystemSetting));
            DevComponents.DotNetBar.Rendering.SuperTabPanelColorTable superTabPanelColorTable3 = new DevComponents.DotNetBar.Rendering.SuperTabPanelColorTable();
            DevComponents.DotNetBar.Rendering.SuperTabPanelItemColorTable superTabPanelItemColorTable3 = new DevComponents.DotNetBar.Rendering.SuperTabPanelItemColorTable();
            DevComponents.DotNetBar.Rendering.SuperTabLinearGradientColorTable superTabLinearGradientColorTable3 = new DevComponents.DotNetBar.Rendering.SuperTabLinearGradientColorTable();
            DevComponents.DotNetBar.Rendering.SuperTabPanelColorTable superTabPanelColorTable4 = new DevComponents.DotNetBar.Rendering.SuperTabPanelColorTable();
            DevComponents.DotNetBar.Rendering.SuperTabPanelItemColorTable superTabPanelItemColorTable4 = new DevComponents.DotNetBar.Rendering.SuperTabPanelItemColorTable();
            DevComponents.DotNetBar.Rendering.SuperTabLinearGradientColorTable superTabLinearGradientColorTable4 = new DevComponents.DotNetBar.Rendering.SuperTabLinearGradientColorTable();
            DevComponents.DotNetBar.Rendering.SuperTabPanelColorTable superTabPanelColorTable5 = new DevComponents.DotNetBar.Rendering.SuperTabPanelColorTable();
            DevComponents.DotNetBar.Rendering.SuperTabPanelItemColorTable superTabPanelItemColorTable5 = new DevComponents.DotNetBar.Rendering.SuperTabPanelItemColorTable();
            DevComponents.DotNetBar.Rendering.SuperTabLinearGradientColorTable superTabLinearGradientColorTable5 = new DevComponents.DotNetBar.Rendering.SuperTabLinearGradientColorTable();
            DevComponents.DotNetBar.Rendering.SuperTabPanelColorTable superTabPanelColorTable6 = new DevComponents.DotNetBar.Rendering.SuperTabPanelColorTable();
            DevComponents.DotNetBar.Rendering.SuperTabPanelItemColorTable superTabPanelItemColorTable6 = new DevComponents.DotNetBar.Rendering.SuperTabPanelItemColorTable();
            DevComponents.DotNetBar.Rendering.SuperTabLinearGradientColorTable superTabLinearGradientColorTable6 = new DevComponents.DotNetBar.Rendering.SuperTabLinearGradientColorTable();
            this.ribbonBar1 = new DevComponents.DotNetBar.RibbonBar();
            this.superTabControl1 = new DevComponents.DotNetBar.SuperTabControl();
            this.superTabControlPanel5 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.numbersafterdecimal = new DevComponents.Editors.IntegerInput();
            this.txtKeyNational = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.masked00 = new DevComponents.DotNetBar.Controls.MaskedTextBoxAdv();
            this.label73 = new System.Windows.Forms.Label();
            this.chk45 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chk37 = new DevComponents.DotNetBar.Controls.SwitchButton();
            this.CmbCurr = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label57 = new System.Windows.Forms.Label();
            this.groupPanel_Acc = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.chk71 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chk27 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chk24 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.checkBox_AutoBackup = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.comboBox_AutoBackup = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.groupPanel_Backup = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.textBox_SyncPath = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label78 = new System.Windows.Forms.Label();
            this.textBox_BackupElectronic = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.dateTimeInput_DT = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.textBox_BackupPath = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.CmbCalendar = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.txtGregDate = new System.Windows.Forms.MaskedTextBox();
            this.ButDayMinus = new System.Windows.Forms.Button();
            this.txtHijriDate = new System.Windows.Forms.MaskedTextBox();
            this.ButAddDay = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupPanel4 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.txtLinesInv = new DevComponents.Editors.IntegerInput();
            this.label77 = new System.Windows.Forms.Label();
            this.chk46 = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label58 = new System.Windows.Forms.Label();
            this.txtDateAlarmEmps = new DevComponents.Editors.IntegerInput();
            this.label47 = new System.Windows.Forms.Label();
            this.chk19 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.txtAutoNumber = new DevComponents.Editors.IntegerInput();
            this.txtDateAlarm = new DevComponents.Editors.IntegerInput();
            this.chk1 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chk3 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chk2 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.CmbDateTyp = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.picture_SSS = new System.Windows.Forms.PictureBox();
            this.superTabItem_General = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControlPanel2 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.c1FlexGrid2 = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.label97 = new System.Windows.Forms.Label();
            this.labelAlarmDueo = new System.Windows.Forms.Label();
            this.txtAlarmDeuDateBefor = new DevComponents.Editors.IntegerInput();
            this.chk69 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.label76 = new System.Windows.Forms.Label();
            this.txtDateofInv = new DevComponents.Editors.IntegerInput();
            this.chk58 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chk36 = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label74 = new System.Windows.Forms.Label();
            this.label48 = new System.Windows.Forms.Label();
            this.CmbOrderTyp = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.CmbPrintTyp = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label51 = new System.Windows.Forms.Label();
            this.CmbPointImages = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label75 = new System.Windows.Forms.Label();
            this.chk39 = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.expandablePanel_NewColumn = new DevComponents.DotNetBar.ExpandablePanel();
            this.Tree_NewCol = new DevComponents.AdvTree.AdvTree();
            this.node1 = new DevComponents.AdvTree.Node();
            this.chk1Show = new DevComponents.AdvTree.Node();
            this.chk1Print = new DevComponents.AdvTree.Node();
            this.node2 = new DevComponents.AdvTree.Node();
            this.chk2Show = new DevComponents.AdvTree.Node();
            this.chk2Print = new DevComponents.AdvTree.Node();
            this.node3 = new DevComponents.AdvTree.Node();
            this.chk3Show = new DevComponents.AdvTree.Node();
            this.chk3Print = new DevComponents.AdvTree.Node();
            this.node4 = new DevComponents.AdvTree.Node();
            this.chk4Show = new DevComponents.AdvTree.Node();
            this.chk4Print = new DevComponents.AdvTree.Node();
            this.node5 = new DevComponents.AdvTree.Node();
            this.chk5Show = new DevComponents.AdvTree.Node();
            this.chk5Print = new DevComponents.AdvTree.Node();
            this.node6 = new DevComponents.AdvTree.Node();
            this.chk6Show = new DevComponents.AdvTree.Node();
            this.chk6Print = new DevComponents.AdvTree.Node();
            this.node7 = new DevComponents.AdvTree.Node();
            this.chk7Show = new DevComponents.AdvTree.Node();
            this.chk7Print = new DevComponents.AdvTree.Node();
            this.node8 = new DevComponents.AdvTree.Node();
            this.chk8Show = new DevComponents.AdvTree.Node();
            this.chk8Print = new DevComponents.AdvTree.Node();
            this.node9 = new DevComponents.AdvTree.Node();
            this.chk9Show = new DevComponents.AdvTree.Node();
            this.chk9Print = new DevComponents.AdvTree.Node();
            this.node10 = new DevComponents.AdvTree.Node();
            this.chk10Show = new DevComponents.AdvTree.Node();
            this.chk10Print = new DevComponents.AdvTree.Node();
            this.node11 = new DevComponents.AdvTree.Node();
            this.chk11Show = new DevComponents.AdvTree.Node();
            this.chk11Print = new DevComponents.AdvTree.Node();
            this.node12 = new DevComponents.AdvTree.Node();
            this.chk12Show = new DevComponents.AdvTree.Node();
            this.chk12Print = new DevComponents.AdvTree.Node();
            this.node13 = new DevComponents.AdvTree.Node();
            this.chk13Show = new DevComponents.AdvTree.Node();
            this.chk13Print = new DevComponents.AdvTree.Node();
            this.node14 = new DevComponents.AdvTree.Node();
            this.chk14Show = new DevComponents.AdvTree.Node();
            this.chk14Print = new DevComponents.AdvTree.Node();
            this.nodeConnector1 = new DevComponents.AdvTree.NodeConnector();
            this.elementStyle3 = new DevComponents.DotNetBar.ElementStyle();
            this.elementStyle4 = new DevComponents.DotNetBar.ElementStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.switchButton_NewColumnName = new DevComponents.DotNetBar.Controls.SwitchButton();
            this.textBox_LineDetailNameE = new System.Windows.Forms.TextBox();
            this.label55 = new System.Windows.Forms.Label();
            this.textBox_LineDetailNameA = new System.Windows.Forms.TextBox();
            this.label53 = new System.Windows.Forms.Label();
            this.label79 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.CmbInvMode = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.CmbCost = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.superTabItem_Inv = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControlPanel1 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.label100 = new System.Windows.Forms.Label();
            this.groupPanel17 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.groupPanel6 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.radioButton_IsNotBackground = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.pictureBox_EnterPic = new DevComponents.DotNetBar.Controls.ReflectionImage();
            this.button_RemoveBackgroud = new DevComponents.DotNetBar.ButtonX();
            this.button_Background = new DevComponents.DotNetBar.ButtonX();
            this.label56 = new System.Windows.Forms.Label();
            this.txtEmailPass = new System.Windows.Forms.TextBox();
            this.CmbMail = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label14 = new System.Windows.Forms.Label();
            this.txtEmailBoss = new System.Windows.Forms.TextBox();
            this.txtCompany = new System.Windows.Forms.TextBox();
            this.label52 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtAct = new System.Windows.Forms.TextBox();
            this.label54 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.txtAddr = new System.Windows.Forms.TextBox();
            this.txtTel2 = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.txtTel1 = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.txtMailCode = new System.Windows.Forms.TextBox();
            this.txtMobile = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.txtPOBox = new System.Windows.Forms.TextBox();
            this.txtFax = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.groupPanel16 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.txtHeadingL1 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtHeadingL2 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtHeadingL3 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label3 = new System.Windows.Forms.Label();
            this.txtHeadingL4 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.groupPanel5 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.ChkPageNumber = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.ChkGreg = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.ChkHijri = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.ChkHead = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.groupPanel_Banner = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.PicItemImg = new System.Windows.Forms.PictureBox();
            this.button_ClearPic = new DevComponents.DotNetBar.ButtonX();
            this.button_EnterImg = new DevComponents.DotNetBar.ButtonX();
            this.groupPanel3 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.txtHeadingR2 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label1 = new System.Windows.Forms.Label();
            this.txtHeadingR1 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtHeadingR4 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtHeadingR3 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.superTabItem_Banner = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControlPanel3 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.expandablePanel_AutoAcc = new DevComponents.DotNetBar.ExpandablePanel();
            this.FlxInv = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.c1FlexGrid1 = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.groupbox_AutoAcc = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtProfits = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label10 = new System.Windows.Forms.Label();
            this.txtFirstInventory = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtBoxAccount = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtLastInventory = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.superTabItem_Acc = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControlPanel15 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.groupPanel12 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.c1FlexGrid1Bankopp = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.superTabItem7 = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControlPanel6 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.expandablePanel_Alarm = new DevComponents.DotNetBar.ExpandablePanel();
            this.groupPanel9 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.label50 = new System.Windows.Forms.Label();
            this.integerInput_AlarmEndVactionBefore = new DevComponents.Editors.IntegerInput();
            this.checkBox_IsAlarmEndVaction = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.label49 = new System.Windows.Forms.Label();
            this.integerInput_AlarmVisaGoBack = new DevComponents.Editors.IntegerInput();
            this.checkBox_IsAlarmVisaGoBack = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.label46 = new System.Windows.Forms.Label();
            this.integerInput_AlarmCarDocBefore = new DevComponents.Editors.IntegerInput();
            this.checkBox_IsAlarmCarDoc = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.label45 = new System.Windows.Forms.Label();
            this.integerInput_AlarmSecretariatsBefore = new DevComponents.Editors.IntegerInput();
            this.checkBox_IsAlarmSecretariatsDoc = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.label44 = new System.Windows.Forms.Label();
            this.integerInput_AlarmFamilyPassportBefore = new DevComponents.Editors.IntegerInput();
            this.checkBox_IsAlarmFamilyPassport = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.label43 = new System.Windows.Forms.Label();
            this.integerInput_AlarmEmpContractBefore = new DevComponents.Editors.IntegerInput();
            this.checkBox_IsAlarmEmpContract = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.label42 = new System.Windows.Forms.Label();
            this.integerInput_AlarmEmpDocBefore = new DevComponents.Editors.IntegerInput();
            this.checkBox_IsAlarmEmpDoc = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.label41 = new System.Windows.Forms.Label();
            this.integerInput_AlarmGuarantorDocBefore = new DevComponents.Editors.IntegerInput();
            this.checkBox_IsAlarmGuarantorDoc = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.label40 = new System.Windows.Forms.Label();
            this.integerInput_AlarmDeptsBefore = new DevComponents.Editors.IntegerInput();
            this.checkBox_IsAlarmDepts = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.panel11 = new System.Windows.Forms.Panel();
            this.button_DocPath = new DevComponents.DotNetBar.ButtonX();
            this.textBox_DocPath = new System.Windows.Forms.TextBox();
            this.label38 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.groupPanel7 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label37 = new System.Windows.Forms.Label();
            this.comboBox_DisVacationType = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label36 = new System.Windows.Forms.Label();
            this.comboBox_CalculateNo = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label35 = new System.Windows.Forms.Label();
            this.comboBox_CalculatliquidNo = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.groupPanel8 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.ChkEmp1 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.label39 = new System.Windows.Forms.Label();
            this.textBox_AutoEmpLeaveAfter = new DevComponents.Editors.IntegerInput();
            this.checkBox_AttendanceManually = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.checkBox_AutoLeave = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.checkBox_Sponer = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.checkBox_VacationManually = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.button_DayofMonth = new DevComponents.DotNetBar.ButtonX();
            this.superTabItem_Employee = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControlPanel13 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.txtTaxNote = new System.Windows.Forms.TextBox();
            this.label83 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtTaxID = new System.Windows.Forms.TextBox();
            this.button_SrchTaxNo = new DevComponents.DotNetBar.ButtonX();
            this.txtTaxNo = new System.Windows.Forms.TextBox();
            this.txtTaxName = new System.Windows.Forms.TextBox();
            this.label84 = new System.Windows.Forms.Label();
            this.label4Tax = new System.Windows.Forms.Label();
            this.ButGeneralPurchaesTax = new System.Windows.Forms.Button();
            this.label2Tax = new System.Windows.Forms.Label();
            this.label3Tax = new System.Windows.Forms.Label();
            this.txtPurchaesTax = new DevComponents.Editors.DoubleInput();
            this.ButGeneralSalesTax = new System.Windows.Forms.Button();
            this.label1Tax = new System.Windows.Forms.Label();
            this.label30Tax = new System.Windows.Forms.Label();
            this.txtSalesTax = new DevComponents.Editors.DoubleInput();
            this.c1FlexGriadTax = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.superTabItem5 = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControlPanel7 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.groupPanel11 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.label80 = new System.Windows.Forms.Label();
            this.button_B7 = new DevComponents.DotNetBar.ButtonX();
            this.button_F7 = new DevComponents.DotNetBar.ButtonX();
            this.button_B5 = new DevComponents.DotNetBar.ButtonX();
            this.button_F5 = new DevComponents.DotNetBar.ButtonX();
            this.button_B3 = new DevComponents.DotNetBar.ButtonX();
            this.button_F3 = new DevComponents.DotNetBar.ButtonX();
            this.button_B1 = new DevComponents.DotNetBar.ButtonX();
            this.button_F1 = new DevComponents.DotNetBar.ButtonX();
            this.txtRBussyMonthly = new System.Windows.Forms.Label();
            this.txtRClean = new System.Windows.Forms.Label();
            this.txtRBussyDaily = new System.Windows.Forms.Label();
            this.txtREmpty = new System.Windows.Forms.Label();
            this.checkBoxX12 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.button_F8 = new DevComponents.DotNetBar.ButtonX();
            this.button_F6 = new DevComponents.DotNetBar.ButtonX();
            this.button_F4 = new DevComponents.DotNetBar.ButtonX();
            this.button_F2 = new DevComponents.DotNetBar.ButtonX();
            this.button_B8 = new DevComponents.DotNetBar.ButtonX();
            this.button_B6 = new DevComponents.DotNetBar.ButtonX();
            this.button_B4 = new DevComponents.DotNetBar.ButtonX();
            this.button_B2 = new DevComponents.DotNetBar.ButtonX();
            this.txtRLeave = new System.Windows.Forms.Label();
            this.txtRRepair = new System.Windows.Forms.Label();
            this.txtRBussyAppendix = new System.Windows.Forms.Label();
            this.txtRAvailable = new System.Windows.Forms.Label();
            this.groupPanel10 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.chk65 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.button_ManageRoom = new DevComponents.DotNetBar.ButtonX();
            this.line2 = new DevComponents.DotNetBar.Controls.Line();
            this.chk43 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.txtGuestBoxAccName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtGuestsFatherAccName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.chk42 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.txtGuestBoxAcc = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label72 = new System.Windows.Forms.Label();
            this.txtGuestsFatherAcc = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label59 = new System.Windows.Forms.Label();
            this.label67 = new System.Windows.Forms.Label();
            this.label66 = new System.Windows.Forms.Label();
            this.txtDayofMonth = new DevComponents.Editors.IntegerInput();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.checkBoxX1 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.RadioBox_LeavePM = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.RadioBox_LeaveAM = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.checkBox_NetWork = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.RadioBox_AllowPM = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.RadioBox_AllowAM = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.txtLeavePeriod = new System.Windows.Forms.MaskedTextBox();
            this.txtAllowPeriod = new System.Windows.Forms.MaskedTextBox();
            this.label62 = new System.Windows.Forms.Label();
            this.txtRoom = new DevComponents.Editors.IntegerInput();
            this.txtFloors = new DevComponents.Editors.IntegerInput();
            this.checkBoxX3 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.label65 = new System.Windows.Forms.Label();
            this.label64 = new System.Windows.Forms.Label();
            this.label63 = new System.Windows.Forms.Label();
            this.label61 = new System.Windows.Forms.Label();
            this.label60 = new System.Windows.Forms.Label();
            this.label68 = new System.Windows.Forms.Label();
            this.label69 = new System.Windows.Forms.Label();
            this.txtLongitudinal = new DevComponents.Editors.IntegerInput();
            this.label70 = new System.Windows.Forms.Label();
            this.label71 = new System.Windows.Forms.Label();
            this.txtWidthitudinal = new DevComponents.Editors.IntegerInput();
            this.chk44 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.superTabItem_Hotel = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControlPanel11 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupPanel13 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.chk77 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chk76 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.txttenantFatherAccName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtEqarsFatherAccName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtTenantFatherAcc = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label90 = new System.Windows.Forms.Label();
            this.txtEqarsFatherAcc = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label91 = new System.Windows.Forms.Label();
            this.label92 = new System.Windows.Forms.Label();
            this.label94 = new System.Windows.Forms.Label();
            this.txtEqarDayOfPayAlarm = new DevComponents.Editors.IntegerInput();
            this.txtEqarContractEndAlarm = new DevComponents.Editors.IntegerInput();
            this.checkBoxX14 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.label98 = new System.Windows.Forms.Label();
            this.label99 = new System.Windows.Forms.Label();
            this.button_RestoreDefContract = new DevComponents.DotNetBar.ButtonX();
            this.superTabItem_Eqar = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControlPanel14 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.button_PointOfCust = new DevComponents.DotNetBar.ButtonX();
            this.groupPanel15 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.checkBox_BalanceActivated = new System.Windows.Forms.CheckBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.txtPriceQ = new DevComponents.Editors.IntegerInput();
            this.label85 = new System.Windows.Forms.Label();
            this.txtWieghtQ = new DevComponents.Editors.IntegerInput();
            this.label86 = new System.Windows.Forms.Label();
            this.txtPriceTo = new DevComponents.Editors.IntegerInput();
            this.txtPriceFrom = new DevComponents.Editors.IntegerInput();
            this.txtWightTo = new DevComponents.Editors.IntegerInput();
            this.txtWightFrom = new DevComponents.Editors.IntegerInput();
            this.txtBarcodTo = new DevComponents.Editors.IntegerInput();
            this.txtBarcodFrom = new DevComponents.Editors.IntegerInput();
            this.label87 = new System.Windows.Forms.Label();
            this.label88 = new System.Windows.Forms.Label();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.RedButWightPrice = new System.Windows.Forms.RadioButton();
            this.RedButPrice = new System.Windows.Forms.RadioButton();
            this.RedButWight = new System.Windows.Forms.RadioButton();
            this.label89 = new System.Windows.Forms.Label();
            this.label93 = new System.Windows.Forms.Label();
            this.label95 = new System.Windows.Forms.Label();
            this.label96 = new System.Windows.Forms.Label();
            this.groupPanel14 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.chkIsActive = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.groupPanel_Main = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.label2custDis = new System.Windows.Forms.Label();
            this.cmbShowState = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.button_CheckConn = new DevComponents.DotNetBar.ButtonX();
            this.txtHello = new System.Windows.Forms.TextBox();
            this.label14CustDis = new System.Windows.Forms.Label();
            this.groupPanel3CustDis = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.chkSync5 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chkSync4 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chkSync3 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chkSync2 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chkSync1 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.groupPanel2CustDis = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.chkData5 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chkData4 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chkData3 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chkData2 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chkData1 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.groupPanel1CustDis = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.chkStop3 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chkStop2 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chkStop1 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.label1CustDis = new System.Windows.Forms.Label();
            this.cmbFast = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label8CustDis = new System.Windows.Forms.Label();
            this.cmbPort = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.superTabItem6 = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControlPanel12 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.superTabControl2 = new DevComponents.DotNetBar.SuperTabControl();
            this.superTabControlPanel8 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.chk70 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chk56 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chk48 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chk38 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.comboBoxEx1 = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.chk35 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chk32 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chk29 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chk10 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chk22 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chk23 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chk47 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chk14 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chk20 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chk26 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chk16 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chk12 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chk11 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chk4 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chk51 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chk49 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chk40 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chk34 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chk33 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chk31 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chk28 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chk25 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chk17 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chk15 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chk13 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chk9 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chk8 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chk6 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chk5 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chk21 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chk7 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chk41 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.superTabItem2 = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControlPanel9 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.chk75 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chk74 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chk73 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chk72 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.label81 = new System.Windows.Forms.Label();
            this.integerInput1 = new DevComponents.Editors.IntegerInput();
            this.checkBoxX2 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chk68 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chk67 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chk66 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chk64 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chk50 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chk63 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chk62 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chk61 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chk60 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chk59 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.label82 = new System.Windows.Forms.Label();
            this.integerInput2 = new DevComponents.Editors.IntegerInput();
            this.checkBoxX4 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chk57 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chk55 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chk54 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chk53 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chk52 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chk18 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.superTabItem3 = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControlPanel10 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.superTabItem4 = new DevComponents.DotNetBar.SuperTabItem();
            this.labelItem1 = new DevComponents.DotNetBar.LabelItem();
            this.progressBarX1 = new DevComponents.DotNetBar.Controls.ProgressBarX();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.ButWithoutSave = new DevComponents.DotNetBar.ButtonX();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.ButWithSave = new DevComponents.DotNetBar.ButtonX();
            this.netResize1 = new Softgroup.NetResize.NetResize(this.components);
            this.ribbonBar1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl1)).BeginInit();
            this.superTabControl1.SuspendLayout();
            this.superTabControlPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numbersafterdecimal)).BeginInit();
            this.groupPanel_Acc.SuspendLayout();
            this.groupPanel_Backup.SuspendLayout();
            this.groupPanel2.SuspendLayout();
            this.groupPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtLinesInv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateAlarmEmps)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAutoNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateAlarm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_SSS)).BeginInit();
            this.superTabControlPanel2.SuspendLayout();
            this.groupPanel1.SuspendLayout();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c1FlexGrid2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAlarmDeuDateBefor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateofInv)).BeginInit();
            this.expandablePanel_NewColumn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Tree_NewCol)).BeginInit();
            this.panel1.SuspendLayout();
            this.superTabControlPanel1.SuspendLayout();
            this.groupPanel17.SuspendLayout();
            this.groupPanel6.SuspendLayout();
            this.groupPanel16.SuspendLayout();
            this.groupPanel5.SuspendLayout();
            this.groupPanel_Banner.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicItemImg)).BeginInit();
            this.groupPanel3.SuspendLayout();
            this.superTabControlPanel3.SuspendLayout();
            this.expandablePanel_AutoAcc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FlxInv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1FlexGrid1)).BeginInit();
            this.groupbox_AutoAcc.SuspendLayout();
            this.superTabControlPanel15.SuspendLayout();
            this.groupPanel12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c1FlexGrid1Bankopp)).BeginInit();
            this.superTabControlPanel6.SuspendLayout();
            this.expandablePanel_Alarm.SuspendLayout();
            this.groupPanel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.integerInput_AlarmEndVactionBefore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.integerInput_AlarmVisaGoBack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.integerInput_AlarmCarDocBefore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.integerInput_AlarmSecretariatsBefore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.integerInput_AlarmFamilyPassportBefore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.integerInput_AlarmEmpContractBefore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.integerInput_AlarmEmpDocBefore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.integerInput_AlarmGuarantorDocBefore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.integerInput_AlarmDeptsBefore)).BeginInit();
            this.panel11.SuspendLayout();
            this.groupPanel7.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupPanel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_AutoEmpLeaveAfter)).BeginInit();
            this.superTabControlPanel13.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPurchaesTax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSalesTax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1FlexGriadTax)).BeginInit();
            this.superTabControlPanel7.SuspendLayout();
            this.groupPanel11.SuspendLayout();
            this.groupPanel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDayofMonth)).BeginInit();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtRoom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFloors)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLongitudinal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWidthitudinal)).BeginInit();
            this.superTabControlPanel11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupPanel13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtEqarDayOfPayAlarm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEqarContractEndAlarm)).BeginInit();
            this.superTabControlPanel14.SuspendLayout();
            this.groupPanel15.SuspendLayout();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPriceQ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWieghtQ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPriceTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPriceFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWightTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWightFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBarcodTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBarcodFrom)).BeginInit();
            this.groupBox8.SuspendLayout();
            this.groupPanel14.SuspendLayout();
            this.groupPanel_Main.SuspendLayout();
            this.groupPanel3CustDis.SuspendLayout();
            this.groupPanel2CustDis.SuspendLayout();
            this.groupPanel1CustDis.SuspendLayout();
            this.superTabControlPanel12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl2)).BeginInit();
            this.superTabControl2.SuspendLayout();
            this.superTabControlPanel8.SuspendLayout();
            this.superTabControlPanel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.integerInput1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.integerInput2)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonBar1
            // 
            this.ribbonBar1.AutoOverflowEnabled = true;
            this.ribbonBar1.AutoScroll = true;
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
            this.ribbonBar1.Controls.Add(this.superTabControl1);
            this.ribbonBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonBar1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.ribbonBar1.Location = new System.Drawing.Point(0, 0);
            this.ribbonBar1.Name = "ribbonBar1";
            this.ribbonBar1.Size = new System.Drawing.Size(1069, 529);
            this.ribbonBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonBar1.TabIndex = 868;
            // 
            // 
            // 
            this.ribbonBar1.TitleStyle.BackColor = System.Drawing.Color.Black;
            this.ribbonBar1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar1.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar1.ItemClick += new System.EventHandler(this.ribbonBar1_ItemClick);
            // 
            // superTabControl1
            // 
            this.superTabControl1.BackColor = System.Drawing.Color.Gainsboro;
            // 
            // 
            // 
            this.superTabControl1.ControlBox.Category = null;
            // 
            // 
            // 
            this.superTabControl1.ControlBox.CloseBox.Category = null;
            this.superTabControl1.ControlBox.CloseBox.Description = null;
            this.superTabControl1.ControlBox.CloseBox.Name = string.Empty;
            this.superTabControl1.ControlBox.CloseBox.Tag = null;
            this.superTabControl1.ControlBox.Description = null;
            // 
            // 
            // 
            this.superTabControl1.ControlBox.MenuBox.Category = null;
            this.superTabControl1.ControlBox.MenuBox.Description = null;
            this.superTabControl1.ControlBox.MenuBox.Name = string.Empty;
            this.superTabControl1.ControlBox.MenuBox.Tag = null;
            this.superTabControl1.ControlBox.Name = string.Empty;
            this.superTabControl1.ControlBox.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.superTabControl1.ControlBox.MenuBox,
            this.superTabControl1.ControlBox.CloseBox});
            this.superTabControl1.ControlBox.Tag = null;
            this.superTabControl1.ControlBox.Visible = false;
            this.superTabControl1.Controls.Add(this.superTabControlPanel2);
            this.superTabControl1.Controls.Add(this.superTabControlPanel6);
            this.superTabControl1.Controls.Add(this.superTabControlPanel5);
            this.superTabControl1.Controls.Add(this.superTabControlPanel1);
            this.superTabControl1.Controls.Add(this.superTabControlPanel3);
            this.superTabControl1.Controls.Add(this.superTabControlPanel15);
            this.superTabControl1.Controls.Add(this.superTabControlPanel13);
            this.superTabControl1.Controls.Add(this.superTabControlPanel7);
            this.superTabControl1.Controls.Add(this.superTabControlPanel11);
            this.superTabControl1.Controls.Add(this.superTabControlPanel14);
            this.superTabControl1.Controls.Add(this.superTabControlPanel12);
            this.superTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControl1.ForeColor = System.Drawing.Color.Black;
            this.superTabControl1.Location = new System.Drawing.Point(0, 0);
            this.superTabControl1.Name = "superTabControl1";
            this.superTabControl1.ReorderTabsEnabled = true;
            this.superTabControl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.superTabControl1.SelectedTabFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.superTabControl1.SelectedTabIndex = 0;
            this.superTabControl1.Size = new System.Drawing.Size(1069, 514);
            this.superTabControl1.TabFont = new System.Drawing.Font("Tahoma", 8F);
            this.superTabControl1.TabHorizontalSpacing = 7;
            this.superTabControl1.TabIndex = 0;
            this.superTabControl1.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.superTabItem_General,
            this.superTabItem_Banner,
            this.superTabItem_Acc,
            this.superTabItem7,
            this.superTabItem_Inv,
            this.superTabItem_Employee,
            this.superTabItem5,
            this.superTabItem_Hotel,
            this.superTabItem_Eqar,
            this.labelItem1,
            this.superTabItem4,
            this.superTabItem6});
            superTabLinearGradientColorTable7.Colors = new System.Drawing.Color[] {
        System.Drawing.Color.DimGray};
            superTabColorTable1.Background = superTabLinearGradientColorTable7;
            this.superTabControl1.TabStripColor = superTabColorTable1;
            this.superTabControl1.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.WinMediaPlayer12;
            this.superTabControl1.TabVerticalSpacing = 8;
            this.superTabControl1.TextAlignment = DevComponents.DotNetBar.eItemAlignment.Center;
            // 
            // superTabControlPanel5
            // 
            this.superTabControlPanel5.AutoScroll = true;
            this.superTabControlPanel5.Controls.Add(this.numbersafterdecimal);
            this.superTabControlPanel5.Controls.Add(this.txtKeyNational);
            this.superTabControlPanel5.Controls.Add(this.masked00);
            this.superTabControlPanel5.Controls.Add(this.label73);
            this.superTabControlPanel5.Controls.Add(this.chk45);
            this.superTabControlPanel5.Controls.Add(this.chk37);
            this.superTabControlPanel5.Controls.Add(this.CmbCurr);
            this.superTabControlPanel5.Controls.Add(this.label57);
            this.superTabControlPanel5.Controls.Add(this.groupPanel_Acc);
            this.superTabControlPanel5.Controls.Add(this.checkBox_AutoBackup);
            this.superTabControlPanel5.Controls.Add(this.comboBox_AutoBackup);
            this.superTabControlPanel5.Controls.Add(this.groupPanel_Backup);
            this.superTabControlPanel5.Controls.Add(this.groupPanel2);
            this.superTabControlPanel5.Controls.Add(this.groupPanel4);
            this.superTabControlPanel5.Controls.Add(this.picture_SSS);
            this.superTabControlPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel5.Location = new System.Drawing.Point(0, 31);
            this.superTabControlPanel5.Name = "superTabControlPanel5";
            superTabLinearGradientColorTable2.Colors = new System.Drawing.Color[] {
        System.Drawing.Color.Gainsboro};
            superTabPanelItemColorTable2.Background = superTabLinearGradientColorTable2;
            superTabPanelColorTable2.Default = superTabPanelItemColorTable2;
            this.superTabControlPanel5.PanelColor = superTabPanelColorTable2;
            this.superTabControlPanel5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.superTabControlPanel5.Size = new System.Drawing.Size(1069, 483);
            this.superTabControlPanel5.TabIndex = 0;
            this.superTabControlPanel5.TabItem = this.superTabItem_General;
            // 
            // numbersafterdecimal
            // 
            this.numbersafterdecimal.AllowEmptyState = false;
            // 
            // 
            // 
            this.numbersafterdecimal.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(198)))));
            this.numbersafterdecimal.BackgroundStyle.Class = "DateTimeInputBackground";
            this.numbersafterdecimal.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.numbersafterdecimal.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.numbersafterdecimal.DisplayFormat = "0";
            this.numbersafterdecimal.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.numbersafterdecimal.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.numbersafterdecimal.Location = new System.Drawing.Point(9, 235);
            this.numbersafterdecimal.MaxValue = 7;
            this.numbersafterdecimal.MinValue = 3;
            this.numbersafterdecimal.Name = "numbersafterdecimal";
            this.numbersafterdecimal.ShowUpDown = true;
            this.numbersafterdecimal.Size = new System.Drawing.Size(100, 21);
            this.numbersafterdecimal.TabIndex = 1025;
            this.numbersafterdecimal.Value = 3;
            this.numbersafterdecimal.Click += new System.EventHandler(this.Button_Edit_Click);
            // 
            // txtKeyNational
            // 
            this.txtKeyNational.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            // 
            // 
            // 
            this.txtKeyNational.Border.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtKeyNational.Border.BorderBottomWidth = 1;
            this.txtKeyNational.Border.BorderColor = System.Drawing.Color.Black;
            this.txtKeyNational.Border.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtKeyNational.Border.BorderLeftWidth = 1;
            this.txtKeyNational.Border.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtKeyNational.Border.BorderRightWidth = 1;
            this.txtKeyNational.Border.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtKeyNational.Border.BorderTopWidth = 1;
            this.txtKeyNational.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtKeyNational.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.txtKeyNational.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtKeyNational.Location = new System.Drawing.Point(54, 175);
            this.txtKeyNational.MaxLength = 7;
            this.txtKeyNational.Name = "txtKeyNational";
            this.netResize1.SetResizeTextBoxMultiline(this.txtKeyNational, false);
            this.txtKeyNational.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtKeyNational.Size = new System.Drawing.Size(94, 21);
            this.txtKeyNational.TabIndex = 1050;
            this.txtKeyNational.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtKeyNational.WatermarkText = "966";
            this.txtKeyNational.Click += new System.EventHandler(this.txtKeyNational_Click);
            this.txtKeyNational.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMobile_KeyPress);
            // 
            // masked00
            // 
            this.masked00.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            // 
            // 
            // 
            this.masked00.BackgroundStyle.Class = "TextBoxBorder";
            this.masked00.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.masked00.ButtonCustom.Text = "+";
            this.masked00.Cursor = System.Windows.Forms.Cursors.Hand;
            this.masked00.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.masked00.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.masked00.Location = new System.Drawing.Point(12, 174);
            this.masked00.Name = "masked00";
            this.masked00.ReadOnly = true;
            this.masked00.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.masked00.Size = new System.Drawing.Size(39, 22);
            this.masked00.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.masked00.TabIndex = 1049;
            this.masked00.Text = "00";
            this.masked00.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label73
            // 
            this.label73.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label73.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label73.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label73.ForeColor = System.Drawing.Color.Black;
            this.label73.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label73.Location = new System.Drawing.Point(151, 175);
            this.label73.Name = "label73";
            this.label73.Size = new System.Drawing.Size(110, 22);
            this.label73.TabIndex = 1047;
            this.label73.Text = "مفتاح الدولة :";
            this.label73.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chk45
            // 
            this.chk45.AutoSize = true;
            this.chk45.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chk45.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chk45.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.chk45.Location = new System.Drawing.Point(117, 237);
            this.chk45.Name = "chk45";
            this.chk45.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chk45.Size = new System.Drawing.Size(131, 16);
            this.chk45.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this.chk45.TabIndex = 1045;
            this.chk45.Text = "تعدد الخانات العشريه";
            this.chk45.CheckedChanged += new System.EventHandler(this.chk45_CheckedChanged);
            // 
            // chk37
            // 
            // 
            // 
            // 
            this.chk37.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chk37.Location = new System.Drawing.Point(12, 203);
            this.chk37.Name = "chk37";
            this.chk37.OffBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(80)))), ((int)(((byte)(77)))));
            this.chk37.OffText = "المزامنة بشكل تلقائي";
            this.chk37.OffTextColor = System.Drawing.Color.White;
            this.chk37.OnText = "المزامنة بشكل تلقائي";
            this.chk37.Size = new System.Drawing.Size(246, 27);
            this.chk37.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chk37.SwitchWidth = 20;
            this.chk37.TabIndex = 1023;
            this.chk37.ValueChanged += new System.EventHandler(this.chk37_ValueChanged);
            // 
            // CmbCurr
            // 
            this.CmbCurr.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbCurr.DisplayMember = "Text";
            this.CmbCurr.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.CmbCurr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbCurr.FormattingEnabled = true;
            this.CmbCurr.ItemHeight = 14;
            this.CmbCurr.Location = new System.Drawing.Point(12, 262);
            this.CmbCurr.Name = "CmbCurr";
            this.CmbCurr.Size = new System.Drawing.Size(135, 20);
            this.CmbCurr.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.CmbCurr.TabIndex = 1021;
            // 
            // label57
            // 
            this.label57.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label57.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label57.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label57.ForeColor = System.Drawing.Color.Black;
            this.label57.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label57.Location = new System.Drawing.Point(148, 262);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(110, 20);
            this.label57.TabIndex = 1022;
            this.label57.Text = "العملة الإفتراضية :";
            this.label57.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupPanel_Acc
            // 
            this.groupPanel_Acc.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel_Acc.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel_Acc.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel_Acc.Controls.Add(this.chk71);
            this.groupPanel_Acc.Controls.Add(this.chk27);
            this.groupPanel_Acc.Controls.Add(this.chk24);
            this.groupPanel_Acc.Location = new System.Drawing.Point(12, 143);
            this.groupPanel_Acc.Name = "groupPanel_Acc";
            this.groupPanel_Acc.Size = new System.Drawing.Size(989, 26);
            // 
            // 
            // 
            this.groupPanel_Acc.Style.BackColor = System.Drawing.Color.Gainsboro;
            this.groupPanel_Acc.Style.BackColor2 = System.Drawing.Color.Gainsboro;
            this.groupPanel_Acc.Style.BackColorGradientAngle = 90;
            this.groupPanel_Acc.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel_Acc.Style.BorderBottomWidth = 1;
            this.groupPanel_Acc.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel_Acc.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel_Acc.Style.BorderLeftWidth = 1;
            this.groupPanel_Acc.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel_Acc.Style.BorderRightWidth = 1;
            this.groupPanel_Acc.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel_Acc.Style.BorderTopWidth = 1;
            this.groupPanel_Acc.Style.CornerDiameter = 4;
            this.groupPanel_Acc.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel_Acc.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Far;
            this.groupPanel_Acc.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            // 
            // 
            // 
            this.groupPanel_Acc.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel_Acc.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel_Acc.TabIndex = 976;
            // 
            // chk71
            // 
            this.chk71.AutoSize = true;
            this.chk71.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chk71.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chk71.Location = new System.Drawing.Point(21, 2);
            this.chk71.Name = "chk71";
            this.chk71.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chk71.Size = new System.Drawing.Size(150, 15);
            this.chk71.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chk71.TabIndex = 989;
            this.chk71.Text = "ايقاف تعبئة الدليل المحاسبية";
            // 
            // chk27
            // 
            this.chk27.AutoSize = true;
            this.chk27.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chk27.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chk27.Location = new System.Drawing.Point(425, 2);
            this.chk27.Name = "chk27";
            this.chk27.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chk27.Size = new System.Drawing.Size(145, 15);
            this.chk27.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chk27.TabIndex = 988;
            this.chk27.Text = "اعتماد البحث السريع للسند";
            // 
            // chk24
            // 
            this.chk24.AutoSize = true;
            this.chk24.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chk24.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chk24.Location = new System.Drawing.Point(778, 1);
            this.chk24.Name = "chk24";
            this.chk24.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chk24.Size = new System.Drawing.Size(138, 15);
            this.chk24.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chk24.TabIndex = 976;
            this.chk24.Text = "اظهار كل الحسابات للسند";
            // 
            // checkBox_AutoBackup
            // 
            this.checkBox_AutoBackup.AutoSize = true;
            this.checkBox_AutoBackup.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.checkBox_AutoBackup.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBox_AutoBackup.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.checkBox_AutoBackup.Location = new System.Drawing.Point(749, 457);
            this.checkBox_AutoBackup.Name = "checkBox_AutoBackup";
            this.checkBox_AutoBackup.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBox_AutoBackup.Size = new System.Drawing.Size(160, 15);
            this.checkBox_AutoBackup.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBox_AutoBackup.TabIndex = 973;
            this.checkBox_AutoBackup.Text = "تمكين النسخ الإحتياطي كل ";
            this.checkBox_AutoBackup.CheckedChanged += new System.EventHandler(this.checkBox_AutoBackup_CheckedChanged);
            // 
            // comboBox_AutoBackup
            // 
            this.comboBox_AutoBackup.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox_AutoBackup.DisplayMember = "Text";
            this.comboBox_AutoBackup.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBox_AutoBackup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_AutoBackup.FormattingEnabled = true;
            this.comboBox_AutoBackup.ItemHeight = 14;
            this.comboBox_AutoBackup.Location = new System.Drawing.Point(266, 455);
            this.comboBox_AutoBackup.Name = "comboBox_AutoBackup";
            this.comboBox_AutoBackup.Size = new System.Drawing.Size(479, 20);
            this.comboBox_AutoBackup.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBox_AutoBackup.TabIndex = 972;
            // 
            // groupPanel_Backup
            // 
            this.groupPanel_Backup.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel_Backup.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel_Backup.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel_Backup.Controls.Add(this.textBox_SyncPath);
            this.groupPanel_Backup.Controls.Add(this.label78);
            this.groupPanel_Backup.Controls.Add(this.textBox_BackupElectronic);
            this.groupPanel_Backup.Controls.Add(this.dateTimeInput_DT);
            this.groupPanel_Backup.Controls.Add(this.textBox_BackupPath);
            this.groupPanel_Backup.Controls.Add(this.label25);
            this.groupPanel_Backup.Controls.Add(this.label24);
            this.groupPanel_Backup.Location = new System.Drawing.Point(12, 289);
            this.groupPanel_Backup.Name = "groupPanel_Backup";
            this.groupPanel_Backup.Size = new System.Drawing.Size(989, 160);
            // 
            // 
            // 
            this.groupPanel_Backup.Style.BackColor = System.Drawing.Color.Gainsboro;
            this.groupPanel_Backup.Style.BackColor2 = System.Drawing.Color.Gainsboro;
            this.groupPanel_Backup.Style.BackColorGradientAngle = 90;
            this.groupPanel_Backup.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel_Backup.Style.BorderBottomWidth = 1;
            this.groupPanel_Backup.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel_Backup.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel_Backup.Style.BorderLeftWidth = 1;
            this.groupPanel_Backup.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel_Backup.Style.BorderRightWidth = 1;
            this.groupPanel_Backup.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel_Backup.Style.BorderTopWidth = 1;
            this.groupPanel_Backup.Style.CornerDiameter = 4;
            this.groupPanel_Backup.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel_Backup.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Far;
            this.groupPanel_Backup.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            // 
            // 
            // 
            this.groupPanel_Backup.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel_Backup.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel_Backup.TabIndex = 947;
            this.groupPanel_Backup.Click += new System.EventHandler(this.groupPanel_Backup_Click);
            // 
            // textBox_SyncPath
            // 
            this.textBox_SyncPath.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.textBox_SyncPath.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBox_SyncPath.ButtonCustom.Visible = true;
            this.textBox_SyncPath.Font = new System.Drawing.Font("Tahoma", 8F);
            this.textBox_SyncPath.ForeColor = System.Drawing.Color.Maroon;
            this.textBox_SyncPath.Location = new System.Drawing.Point(21, 111);
            this.textBox_SyncPath.Multiline = true;
            this.textBox_SyncPath.Name = "textBox_SyncPath";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_SyncPath, false);
            this.textBox_SyncPath.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBox_SyncPath.Size = new System.Drawing.Size(934, 19);
            this.textBox_SyncPath.TabIndex = 936;
            this.textBox_SyncPath.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_SyncPath.WatermarkColor = System.Drawing.Color.White;
            this.textBox_SyncPath.ButtonCustomClick += new System.EventHandler(this.textBox_SyncPath_ButtonCustomClick);
            this.textBox_SyncPath.Click += new System.EventHandler(this.textBox_SyncPath_Click);
            // 
            // label78
            // 
            this.label78.AutoSize = true;
            this.label78.BackColor = System.Drawing.Color.Transparent;
            this.label78.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label78.ForeColor = System.Drawing.Color.SteelBlue;
            this.label78.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label78.Location = new System.Drawing.Point(813, 93);
            this.label78.Name = "label78";
            this.label78.Size = new System.Drawing.Size(143, 13);
            this.label78.TabIndex = 935;
            this.label78.Text = "مسار برنامج المزامنة | Sync :";
            // 
            // textBox_BackupElectronic
            // 
            this.textBox_BackupElectronic.BackColor = System.Drawing.SystemColors.Control;
            // 
            // 
            // 
            this.textBox_BackupElectronic.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBox_BackupElectronic.ButtonCustom.Visible = true;
            this.textBox_BackupElectronic.Font = new System.Drawing.Font("Tahoma", 8F);
            this.textBox_BackupElectronic.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.textBox_BackupElectronic.Location = new System.Drawing.Point(23, 67);
            this.textBox_BackupElectronic.Multiline = true;
            this.textBox_BackupElectronic.Name = "textBox_BackupElectronic";
            this.textBox_BackupElectronic.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_BackupElectronic, false);
            this.textBox_BackupElectronic.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBox_BackupElectronic.Size = new System.Drawing.Size(934, 19);
            this.textBox_BackupElectronic.TabIndex = 934;
            this.textBox_BackupElectronic.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_BackupElectronic.WatermarkColor = System.Drawing.Color.White;
            this.textBox_BackupElectronic.ButtonCustomClick += new System.EventHandler(this.textBox_BackupElectronic_ButtonCustomClick);
            this.textBox_BackupElectronic.ButtonCustom2Click += new System.EventHandler(this.textBox_BackupElectronic_ButtonCustom2Click);
            // 
            // dateTimeInput_DT
            // 
            this.dateTimeInput_DT.BackColor = System.Drawing.SystemColors.Control;
            // 
            // 
            // 
            this.dateTimeInput_DT.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTimeInput_DT.ButtonCustom.Text = "تاريخ نهاية الإشتراك في الخدمة";
            this.dateTimeInput_DT.ButtonCustom.Visible = true;
            this.dateTimeInput_DT.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dateTimeInput_DT.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.dateTimeInput_DT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.dateTimeInput_DT.Location = new System.Drawing.Point(0, 134);
            this.dateTimeInput_DT.Multiline = true;
            this.dateTimeInput_DT.Name = "dateTimeInput_DT";
            this.dateTimeInput_DT.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.dateTimeInput_DT, false);
            this.dateTimeInput_DT.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dateTimeInput_DT.Size = new System.Drawing.Size(983, 20);
            this.dateTimeInput_DT.TabIndex = 932;
            this.dateTimeInput_DT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dateTimeInput_DT.WatermarkColor = System.Drawing.Color.White;
            // 
            // textBox_BackupPath
            // 
            this.textBox_BackupPath.BackColor = System.Drawing.SystemColors.Control;
            // 
            // 
            // 
            this.textBox_BackupPath.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBox_BackupPath.ButtonCustom.Visible = true;
            this.textBox_BackupPath.Font = new System.Drawing.Font("Tahoma", 8F);
            this.textBox_BackupPath.ForeColor = System.Drawing.Color.Gray;
            this.textBox_BackupPath.Location = new System.Drawing.Point(23, 25);
            this.textBox_BackupPath.Multiline = true;
            this.textBox_BackupPath.Name = "textBox_BackupPath";
            this.textBox_BackupPath.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_BackupPath, false);
            this.textBox_BackupPath.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBox_BackupPath.Size = new System.Drawing.Size(934, 19);
            this.textBox_BackupPath.TabIndex = 927;
            this.textBox_BackupPath.WatermarkColor = System.Drawing.Color.White;
            this.textBox_BackupPath.ButtonCustomClick += new System.EventHandler(this.textBox_BackupPath_ButtonCustomClick);
            this.textBox_BackupPath.Click += new System.EventHandler(this.textBox_BackupPath_Click);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.BackColor = System.Drawing.Color.Transparent;
            this.label25.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label25.ForeColor = System.Drawing.Color.SteelBlue;
            this.label25.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label25.Location = new System.Drawing.Point(817, 4);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(139, 13);
            this.label25.TabIndex = 930;
            this.label25.Text = "مسار النسخ الإحتياطــــــي :";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.BackColor = System.Drawing.Color.Transparent;
            this.label24.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label24.ForeColor = System.Drawing.Color.SteelBlue;
            this.label24.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label24.Location = new System.Drawing.Point(785, 49);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(171, 13);
            this.label24.TabIndex = 928;
            this.label24.Text = "خدمة النسخ الإحتياطي الألكتروني :";
            // 
            // groupPanel2
            // 
            this.groupPanel2.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.label5);
            this.groupPanel2.Controls.Add(this.CmbCalendar);
            this.groupPanel2.Controls.Add(this.txtGregDate);
            this.groupPanel2.Controls.Add(this.ButDayMinus);
            this.groupPanel2.Controls.Add(this.txtHijriDate);
            this.groupPanel2.Controls.Add(this.ButAddDay);
            this.groupPanel2.Controls.Add(this.label6);
            this.groupPanel2.Controls.Add(this.label7);
            this.groupPanel2.Location = new System.Drawing.Point(264, 179);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(737, 104);
            // 
            // 
            // 
            this.groupPanel2.Style.BackColor = System.Drawing.Color.Gainsboro;
            this.groupPanel2.Style.BackColor2 = System.Drawing.Color.Gainsboro;
            this.groupPanel2.Style.BackColorGradientAngle = 90;
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
            this.groupPanel2.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Far;
            this.groupPanel2.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            // 
            // 
            // 
            this.groupPanel2.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel2.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel2.TabIndex = 966;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(630, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 13);
            this.label5.TabIndex = 967;
            this.label5.Text = "التقويم المعتمد :";
            // 
            // CmbCalendar
            // 
            this.CmbCalendar.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbCalendar.DisplayMember = "Text";
            this.CmbCalendar.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.CmbCalendar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbCalendar.FocusHighlightColor = System.Drawing.Color.Empty;
            this.CmbCalendar.FormattingEnabled = true;
            this.CmbCalendar.ItemHeight = 14;
            this.CmbCalendar.Location = new System.Drawing.Point(80, 5);
            this.CmbCalendar.Name = "CmbCalendar";
            this.CmbCalendar.Size = new System.Drawing.Size(549, 20);
            this.CmbCalendar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.CmbCalendar.TabIndex = 966;
            // 
            // txtGregDate
            // 
            this.txtGregDate.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.txtGregDate.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.txtGregDate.ForeColor = System.Drawing.Color.White;
            this.txtGregDate.Location = new System.Drawing.Point(294, 32);
            this.txtGregDate.Mask = "0000/00/00";
            this.txtGregDate.Name = "txtGregDate";
            this.txtGregDate.ReadOnly = true;
            this.txtGregDate.Size = new System.Drawing.Size(335, 21);
            this.txtGregDate.TabIndex = 100;
            this.txtGregDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtGregDate.Click += new System.EventHandler(this.txtGregDate_Click);
            // 
            // ButDayMinus
            // 
            this.ButDayMinus.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ButDayMinus.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ButDayMinus.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.ButDayMinus.ForeColor = System.Drawing.Color.White;
            this.ButDayMinus.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ButDayMinus.Location = new System.Drawing.Point(243, 59);
            this.ButDayMinus.Name = "ButDayMinus";
            this.ButDayMinus.Size = new System.Drawing.Size(21, 21);
            this.ButDayMinus.TabIndex = 98;
            this.ButDayMinus.Text = "-";
            this.ButDayMinus.UseVisualStyleBackColor = false;
            this.ButDayMinus.Click += new System.EventHandler(this.ButDayMinus_Click);
            // 
            // txtHijriDate
            // 
            this.txtHijriDate.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.txtHijriDate.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.txtHijriDate.ForeColor = System.Drawing.Color.White;
            this.txtHijriDate.Location = new System.Drawing.Point(294, 59);
            this.txtHijriDate.Mask = "0000/00/00";
            this.txtHijriDate.Name = "txtHijriDate";
            this.txtHijriDate.ReadOnly = true;
            this.txtHijriDate.Size = new System.Drawing.Size(335, 21);
            this.txtHijriDate.TabIndex = 99;
            this.txtHijriDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtHijriDate.Click += new System.EventHandler(this.txtHijriDate_Click);
            // 
            // ButAddDay
            // 
            this.ButAddDay.BackColor = System.Drawing.Color.White;
            this.ButAddDay.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ButAddDay.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.ButAddDay.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.ButAddDay.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ButAddDay.Location = new System.Drawing.Point(266, 59);
            this.ButAddDay.Name = "ButAddDay";
            this.ButAddDay.Size = new System.Drawing.Size(21, 21);
            this.ButAddDay.TabIndex = 97;
            this.ButAddDay.Text = "+";
            this.ButAddDay.UseVisualStyleBackColor = false;
            this.ButAddDay.Click += new System.EventHandler(this.ButAddDay_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(630, 36);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 13);
            this.label6.TabIndex = 102;
            this.label6.Text = "التاريخ / ميلادي :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(630, 63);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 13);
            this.label7.TabIndex = 101;
            this.label7.Text = "التاريخ / هجري :";
            // 
            // groupPanel4
            // 
            this.groupPanel4.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel4.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel4.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel4.Controls.Add(this.txtLinesInv);
            this.groupPanel4.Controls.Add(this.label77);
            this.groupPanel4.Controls.Add(this.chk46);
            this.groupPanel4.Controls.Add(this.label58);
            this.groupPanel4.Controls.Add(this.txtDateAlarmEmps);
            this.groupPanel4.Controls.Add(this.label47);
            this.groupPanel4.Controls.Add(this.chk19);
            this.groupPanel4.Controls.Add(this.txtAutoNumber);
            this.groupPanel4.Controls.Add(this.txtDateAlarm);
            this.groupPanel4.Controls.Add(this.chk1);
            this.groupPanel4.Controls.Add(this.chk3);
            this.groupPanel4.Controls.Add(this.chk2);
            this.groupPanel4.Controls.Add(this.CmbDateTyp);
            this.groupPanel4.Location = new System.Drawing.Point(12, 15);
            this.groupPanel4.Name = "groupPanel4";
            this.groupPanel4.Size = new System.Drawing.Size(989, 119);
            // 
            // 
            // 
            this.groupPanel4.Style.BackColor = System.Drawing.Color.Gainsboro;
            this.groupPanel4.Style.BackColor2 = System.Drawing.Color.Gainsboro;
            this.groupPanel4.Style.BackColorGradientAngle = 90;
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
            this.groupPanel4.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Far;
            this.groupPanel4.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            // 
            // 
            // 
            this.groupPanel4.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel4.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel4.TabIndex = 967;
            // 
            // txtLinesInv
            // 
            this.txtLinesInv.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtLinesInv.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(198)))));
            this.txtLinesInv.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtLinesInv.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtLinesInv.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtLinesInv.DisplayFormat = "0";
            this.txtLinesInv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtLinesInv.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtLinesInv.Location = new System.Drawing.Point(323, 87);
            this.txtLinesInv.MaxValue = 1000000;
            this.txtLinesInv.MinValue = 100;
            this.txtLinesInv.Name = "txtLinesInv";
            this.txtLinesInv.ShowUpDown = true;
            this.txtLinesInv.Size = new System.Drawing.Size(100, 21);
            this.txtLinesInv.TabIndex = 1024;
            this.txtLinesInv.Value = 100;
            // 
            // label77
            // 
            this.label77.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label77.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label77.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label77.ForeColor = System.Drawing.Color.Black;
            this.label77.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label77.Location = new System.Drawing.Point(425, 87);
            this.label77.Name = "label77";
            this.label77.Size = new System.Drawing.Size(103, 21);
            this.label77.TabIndex = 1023;
            this.label77.Text = "عدد سطور الفاتورة";
            this.label77.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chk46
            // 
            this.chk46.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.chk46.DisplayMember = "Text";
            this.chk46.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.chk46.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.chk46.FormattingEnabled = true;
            this.chk46.ItemHeight = 14;
            this.chk46.Location = new System.Drawing.Point(3, 9);
            this.chk46.Name = "chk46";
            this.chk46.Size = new System.Drawing.Size(727, 20);
            this.chk46.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chk46.TabIndex = 1022;
            // 
            // label58
            // 
            this.label58.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label58.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label58.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label58.ForeColor = System.Drawing.Color.SteelBlue;
            this.label58.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label58.Location = new System.Drawing.Point(3, 57);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(806, 25);
            this.label58.TabIndex = 1021;
            this.label58.Text = "إختصار فك الدرج : F9";
            this.label58.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtDateAlarmEmps
            // 
            this.txtDateAlarmEmps.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtDateAlarmEmps.BackgroundStyle.BackColor = System.Drawing.Color.SlateGray;
            this.txtDateAlarmEmps.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtDateAlarmEmps.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDateAlarmEmps.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtDateAlarmEmps.DisplayFormat = "0";
            this.txtDateAlarmEmps.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtDateAlarmEmps.ForeColor = System.Drawing.Color.White;
            this.txtDateAlarmEmps.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtDateAlarmEmps.Location = new System.Drawing.Point(734, 86);
            this.txtDateAlarmEmps.MinValue = 0;
            this.txtDateAlarmEmps.Name = "txtDateAlarmEmps";
            this.txtDateAlarmEmps.ShowUpDown = true;
            this.txtDateAlarmEmps.Size = new System.Drawing.Size(75, 21);
            this.txtDateAlarmEmps.TabIndex = 1018;
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.BackColor = System.Drawing.Color.Transparent;
            this.label47.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label47.ForeColor = System.Drawing.Color.Black;
            this.label47.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label47.Location = new System.Drawing.Point(698, 89);
            this.label47.Name = "label47";
            this.netResize1.SetResizeFont(this.label47, false);
            this.label47.Size = new System.Drawing.Size(33, 13);
            this.label47.TabIndex = 1020;
            this.label47.Text = "يومـــاُ";
            // 
            // chk19
            // 
            this.chk19.AutoSize = true;
            this.chk19.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chk19.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chk19.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.chk19.Location = new System.Drawing.Point(814, 88);
            this.chk19.Name = "chk19";
            this.chk19.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chk19.Size = new System.Drawing.Size(160, 16);
            this.chk19.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chk19.TabIndex = 1019;
            this.chk19.Text = "تنبيه عن وثائق <font color=\"#BA1419\">الموظفين </font>قبل";
            this.chk19.CheckedChanged += new System.EventHandler(this.chk19_CheckedChanged);
            // 
            // txtAutoNumber
            // 
            this.txtAutoNumber.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtAutoNumber.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(198)))));
            this.txtAutoNumber.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtAutoNumber.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtAutoNumber.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtAutoNumber.DisplayFormat = "0";
            this.txtAutoNumber.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Bold);
            this.txtAutoNumber.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtAutoNumber.Location = new System.Drawing.Point(734, 10);
            this.txtAutoNumber.MinValue = 1;
            this.txtAutoNumber.Name = "txtAutoNumber";
            this.txtAutoNumber.Size = new System.Drawing.Size(37, 19);
            this.txtAutoNumber.TabIndex = 14;
            this.txtAutoNumber.Value = 1;
            // 
            // txtDateAlarm
            // 
            this.txtDateAlarm.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtDateAlarm.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(198)))));
            this.txtDateAlarm.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtDateAlarm.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDateAlarm.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtDateAlarm.DisplayFormat = "0";
            this.txtDateAlarm.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Bold);
            this.txtDateAlarm.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtDateAlarm.Location = new System.Drawing.Point(734, 35);
            this.txtDateAlarm.MinValue = 0;
            this.txtDateAlarm.Name = "txtDateAlarm";
            this.txtDateAlarm.Size = new System.Drawing.Size(75, 19);
            this.txtDateAlarm.TabIndex = 16;
            // 
            // chk1
            // 
            this.chk1.AutoSize = true;
            this.chk1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chk1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chk1.Location = new System.Drawing.Point(778, 11);
            this.chk1.Name = "chk1";
            this.chk1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chk1.Size = new System.Drawing.Size(196, 15);
            this.chk1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chk1.TabIndex = 13;
            this.chk1.Text = "تمكين الترقيم التلقائي للأصناف إبتدا من ";
            this.chk1.CheckedChanged += new System.EventHandler(this.chk1_CheckedChanged);
            // 
            // chk3
            // 
            this.chk3.AutoSize = true;
            this.chk3.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chk3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chk3.Location = new System.Drawing.Point(816, 38);
            this.chk3.Name = "chk3";
            this.chk3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chk3.Size = new System.Drawing.Size(158, 15);
            this.chk3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chk3.TabIndex = 15;
            this.chk3.Text = "تنبيه بانتهاء صلاحية الصنف قبل";
            this.chk3.CheckedChanged += new System.EventHandler(this.chk3_CheckedChanged);
            // 
            // chk2
            // 
            this.chk2.AutoSize = true;
            this.chk2.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chk2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chk2.Location = new System.Drawing.Point(837, 61);
            this.chk2.Name = "chk2";
            this.chk2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chk2.Size = new System.Drawing.Size(137, 15);
            this.chk2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chk2.TabIndex = 18;
            this.chk2.Text = "التنبيه التلقائي لحد الطلب";
            // 
            // CmbDateTyp
            // 
            this.CmbDateTyp.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbDateTyp.DisplayMember = "Text";
            this.CmbDateTyp.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.CmbDateTyp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbDateTyp.FormattingEnabled = true;
            this.CmbDateTyp.ItemHeight = 14;
            this.CmbDateTyp.Location = new System.Drawing.Point(3, 34);
            this.CmbDateTyp.Name = "CmbDateTyp";
            this.CmbDateTyp.Size = new System.Drawing.Size(727, 20);
            this.CmbDateTyp.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.CmbDateTyp.TabIndex = 17;
            this.CmbDateTyp.SelectedIndexChanged += new System.EventHandler(this.CmbDateTyp_SelectedIndexChanged);
            // 
            // picture_SSS
            // 
            this.picture_SSS.BackColor = System.Drawing.Color.Transparent;
            this.picture_SSS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picture_SSS.Image = global::InvAcc.Properties.Resources.Untitled_2_copy;
            this.picture_SSS.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.picture_SSS.Location = new System.Drawing.Point(264, 14);
            this.picture_SSS.Name = "picture_SSS";
            this.picture_SSS.Size = new System.Drawing.Size(526, 119);
            this.picture_SSS.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picture_SSS.TabIndex = 969;
            this.picture_SSS.TabStop = false;
            this.picture_SSS.Visible = false;
            // 
            // superTabItem_General
            // 
            this.superTabItem_General.AttachedControl = this.superTabControlPanel5;
            this.superTabItem_General.GlobalItem = false;
            this.superTabItem_General.Name = "superTabItem_General";
            this.superTabItem_General.Text = "عــــام";
            // 
            // superTabControlPanel2
            // 
            this.superTabControlPanel2.AutoScroll = true;
            this.superTabControlPanel2.Controls.Add(this.groupPanel1);
            this.superTabControlPanel2.Controls.Add(this.label9);
            this.superTabControlPanel2.Controls.Add(this.label8);
            this.superTabControlPanel2.Controls.Add(this.CmbInvMode);
            this.superTabControlPanel2.Controls.Add(this.CmbCost);
            this.superTabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel2.Location = new System.Drawing.Point(0, 31);
            this.superTabControlPanel2.Name = "superTabControlPanel2";
            superTabLinearGradientColorTable1.Colors = new System.Drawing.Color[] {
        System.Drawing.Color.Gainsboro};
            superTabPanelItemColorTable1.Background = superTabLinearGradientColorTable1;
            superTabPanelColorTable1.Default = superTabPanelItemColorTable1;
            this.superTabControlPanel2.PanelColor = superTabPanelColorTable1;
            this.superTabControlPanel2.Size = new System.Drawing.Size(1069, 483);
            this.superTabControlPanel2.TabIndex = 0;
            this.superTabControlPanel2.TabItem = this.superTabItem_Inv;
            // 
            // groupPanel1
            // 
            this.groupPanel1.BackColor = System.Drawing.Color.White;
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.splitContainer3);
            this.groupPanel1.Controls.Add(this.expandablePanel_NewColumn);
            this.groupPanel1.Controls.Add(this.label79);
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel1.Location = new System.Drawing.Point(0, 0);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(1069, 483);
            // 
            // 
            // 
            this.groupPanel1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel1.Style.BackColorGradientAngle = 90;
            this.groupPanel1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
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
            this.groupPanel1.TabIndex = 970;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.splitContainer2);
            this.splitContainer3.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.splitContainer3.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer3_Panel1_Paint);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.splitContainer3.Panel2.Controls.Add(this.label74);
            this.splitContainer3.Panel2.Controls.Add(this.label48);
            this.splitContainer3.Panel2.Controls.Add(this.CmbOrderTyp);
            this.splitContainer3.Panel2.Controls.Add(this.CmbPrintTyp);
            this.splitContainer3.Panel2.Controls.Add(this.label51);
            this.splitContainer3.Panel2.Controls.Add(this.CmbPointImages);
            this.splitContainer3.Panel2.Controls.Add(this.label75);
            this.splitContainer3.Panel2.Controls.Add(this.chk39);
            this.splitContainer3.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.splitContainer3.Size = new System.Drawing.Size(1063, 451);
            this.splitContainer3.SplitterDistance = 364;
            this.splitContainer3.TabIndex = 1042;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer1);
            this.splitContainer2.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.label97);
            this.splitContainer2.Panel2.Controls.Add(this.labelAlarmDueo);
            this.splitContainer2.Panel2.Controls.Add(this.txtAlarmDeuDateBefor);
            this.splitContainer2.Panel2.Controls.Add(this.chk69);
            this.splitContainer2.Panel2.Controls.Add(this.label76);
            this.splitContainer2.Panel2.Controls.Add(this.txtDateofInv);
            this.splitContainer2.Panel2.Controls.Add(this.chk58);
            this.splitContainer2.Panel2.Controls.Add(this.chk36);
            this.splitContainer2.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.splitContainer2.Size = new System.Drawing.Size(1063, 364);
            this.splitContainer2.SplitterDistance = 311;
            this.splitContainer2.TabIndex = 1041;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.textBox1);
            this.splitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.c1FlexGrid2);
            this.splitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.splitContainer1.Size = new System.Drawing.Size(1063, 311);
            this.splitContainer1.SplitterDistance = 25;
            this.splitContainer1.TabIndex = 23;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.OrangeRed;
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Font = new System.Drawing.Font("Tahoma", 12F);
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Name = "textBox1";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox1, false);
            this.textBox1.Size = new System.Drawing.Size(1063, 27);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // c1FlexGrid2
            // 
            this.c1FlexGrid2.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.RestrictAll;
            this.c1FlexGrid2.ColumnInfo = resources.GetString("c1FlexGrid2.ColumnInfo");
            this.c1FlexGrid2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.c1FlexGrid2.Font = new System.Drawing.Font("Tahoma", 8F);
            this.c1FlexGrid2.Location = new System.Drawing.Point(0, 0);
            this.c1FlexGrid2.Name = "c1FlexGrid2";
            this.c1FlexGrid2.Rows.Count = 60;
            this.c1FlexGrid2.Rows.DefaultSize = 19;
            this.c1FlexGrid2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.c1FlexGrid2.Size = new System.Drawing.Size(1063, 282);
            this.c1FlexGrid2.StyleInfo = resources.GetString("c1FlexGrid2.StyleInfo");
            this.c1FlexGrid2.TabIndex = 22;
            this.c1FlexGrid2.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2007Black;
            this.c1FlexGrid2.SelChange += new System.EventHandler(this.c1FlexGrid2_SelChange);
            this.c1FlexGrid2.Click += new System.EventHandler(this.c1FlexGrid2_Click);
            // 
            // label97
            // 
            this.label97.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right));
            this.label97.AutoSize = true;
            this.label97.BackColor = System.Drawing.Color.Transparent;
            this.label97.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label97.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label97.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label97.Location = new System.Drawing.Point(231, 13);
            this.label97.Name = "label97";
            this.label97.Size = new System.Drawing.Size(119, 13);
            this.label97.TabIndex = 1083;
            this.label97.Text = "قالب الرسائل المستخدم";
            // 
            // labelAlarmDueo
            // 
            this.labelAlarmDueo.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right));
            this.labelAlarmDueo.AutoSize = true;
            this.labelAlarmDueo.BackColor = System.Drawing.Color.Transparent;
            this.labelAlarmDueo.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.labelAlarmDueo.ForeColor = System.Drawing.Color.MidnightBlue;
            this.labelAlarmDueo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelAlarmDueo.Location = new System.Drawing.Point(410, 16);
            this.labelAlarmDueo.Name = "labelAlarmDueo";
            this.labelAlarmDueo.Size = new System.Drawing.Size(22, 13);
            this.labelAlarmDueo.TabIndex = 1082;
            this.labelAlarmDueo.Text = "يوم";
            // 
            // txtAlarmDeuDateBefor
            // 
            this.txtAlarmDeuDateBefor.AllowEmptyState = false;
            this.txtAlarmDeuDateBefor.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right));
            // 
            // 
            // 
            this.txtAlarmDeuDateBefor.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(198)))));
            this.txtAlarmDeuDateBefor.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtAlarmDeuDateBefor.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtAlarmDeuDateBefor.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtAlarmDeuDateBefor.DisplayFormat = "0";
            this.txtAlarmDeuDateBefor.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Bold);
            this.txtAlarmDeuDateBefor.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtAlarmDeuDateBefor.Location = new System.Drawing.Point(443, 12);
            this.txtAlarmDeuDateBefor.MinValue = 0;
            this.txtAlarmDeuDateBefor.Name = "txtAlarmDeuDateBefor";
            this.txtAlarmDeuDateBefor.Size = new System.Drawing.Size(118, 19);
            this.txtAlarmDeuDateBefor.TabIndex = 1081;
            // 
            // chk69
            // 
            this.chk69.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right));
            this.chk69.AutoSize = true;
            this.chk69.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chk69.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chk69.Location = new System.Drawing.Point(499, 14);
            this.chk69.Name = "chk69";
            this.chk69.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chk69.Size = new System.Drawing.Size(141, 15);
            this.chk69.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chk69.TabIndex = 1080;
            this.chk69.Text = "تنبيه بتاريخ الإستحقاق قبل";
            this.chk69.CheckedChanged += new System.EventHandler(this.chk69_CheckedChanged);
            // 
            // label76
            // 
            this.label76.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right));
            this.label76.AutoSize = true;
            this.label76.BackColor = System.Drawing.Color.Transparent;
            this.label76.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label76.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label76.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label76.Location = new System.Drawing.Point(681, 12);
            this.label76.Name = "label76";
            this.label76.Size = new System.Drawing.Size(22, 13);
            this.label76.TabIndex = 1069;
            this.label76.Text = "يوم";
            // 
            // txtDateofInv
            // 
            this.txtDateofInv.AllowEmptyState = false;
            this.txtDateofInv.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right));
            // 
            // 
            // 
            this.txtDateofInv.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(198)))));
            this.txtDateofInv.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtDateofInv.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDateofInv.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtDateofInv.DisplayFormat = "0";
            this.txtDateofInv.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Bold);
            this.txtDateofInv.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtDateofInv.Location = new System.Drawing.Point(707, 11);
            this.txtDateofInv.MinValue = 0;
            this.txtDateofInv.Name = "txtDateofInv";
            this.txtDateofInv.Size = new System.Drawing.Size(172, 19);
            this.txtDateofInv.TabIndex = 1068;
            // 
            // chk58
            // 
            this.chk58.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right));
            this.chk58.AutoSize = true;
            this.chk58.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chk58.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chk58.Location = new System.Drawing.Point(821, 13);
            this.chk58.Name = "chk58";
            this.chk58.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chk58.Size = new System.Drawing.Size(152, 15);
            this.chk58.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chk58.TabIndex = 1067;
            this.chk58.Text = "احتساب تاريخ الأستحقاق بعد";
            this.chk58.CheckedChanged += new System.EventHandler(this.chk58_CheckedChanged);
            // 
            // chk36
            // 
            this.chk36.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right));
            this.chk36.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.chk36.DisplayMember = "Text";
            this.chk36.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.chk36.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.chk36.FocusHighlightColor = System.Drawing.Color.Empty;
            this.chk36.FormattingEnabled = true;
            this.chk36.ItemHeight = 14;
            this.chk36.Location = new System.Drawing.Point(16, 10);
            this.chk36.Name = "chk36";
            this.chk36.Size = new System.Drawing.Size(272, 20);
            this.chk36.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chk36.TabIndex = 1066;
            // 
            // label74
            // 
            this.label74.AutoSize = true;
            this.label74.BackColor = System.Drawing.Color.Transparent;
            this.label74.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label74.Location = new System.Drawing.Point(385, 48);
            this.label74.Name = "label74";
            this.label74.Size = new System.Drawing.Size(53, 13);
            this.label74.TabIndex = 971;
            this.label74.Text = "نوع الطلب";
            // 
            // label48
            // 
            this.label48.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label48.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label48.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label48.ForeColor = System.Drawing.Color.SteelBlue;
            this.label48.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label48.Location = new System.Drawing.Point(703, 7);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(275, 20);
            this.label48.TabIndex = 981;
            this.label48.Text = "طباعة المبيعات  حسب إعدادات طباعة :";
            this.label48.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label48.Visible = false;
            this.label48.Click += new System.EventHandler(this.label48_Click);
            // 
            // CmbOrderTyp
            // 
            this.CmbOrderTyp.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbOrderTyp.DisplayMember = "Text";
            this.CmbOrderTyp.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.CmbOrderTyp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbOrderTyp.FocusHighlightColor = System.Drawing.Color.Empty;
            this.CmbOrderTyp.FormattingEnabled = true;
            this.CmbOrderTyp.ItemHeight = 14;
            this.CmbOrderTyp.Location = new System.Drawing.Point(301, 43);
            this.CmbOrderTyp.Name = "CmbOrderTyp";
            this.CmbOrderTyp.Size = new System.Drawing.Size(78, 20);
            this.CmbOrderTyp.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.CmbOrderTyp.TabIndex = 972;
            // 
            // CmbPrintTyp
            // 
            this.CmbPrintTyp.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbPrintTyp.DisplayMember = "Text";
            this.CmbPrintTyp.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.CmbPrintTyp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbPrintTyp.FocusHighlightColor = System.Drawing.Color.Empty;
            this.CmbPrintTyp.FormattingEnabled = true;
            this.CmbPrintTyp.ItemHeight = 14;
            this.CmbPrintTyp.Location = new System.Drawing.Point(538, 7);
            this.CmbPrintTyp.Name = "CmbPrintTyp";
            this.CmbPrintTyp.Size = new System.Drawing.Size(160, 20);
            this.CmbPrintTyp.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.CmbPrintTyp.TabIndex = 982;
            this.CmbPrintTyp.Visible = false;
            this.CmbPrintTyp.SelectedIndexChanged += new System.EventHandler(this.CmbPrintTyp_SelectedIndexChanged);
            // 
            // label51
            // 
            this.label51.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label51.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label51.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label51.ForeColor = System.Drawing.Color.SteelBlue;
            this.label51.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label51.Location = new System.Drawing.Point(705, 33);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(275, 20);
            this.label51.TabIndex = 984;
            this.label51.Text = "خيارات عرض الصور في شاشة نقاط البيع :";
            this.label51.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CmbPointImages
            // 
            this.CmbPointImages.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbPointImages.DisplayMember = "Text";
            this.CmbPointImages.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.CmbPointImages.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbPointImages.FocusHighlightColor = System.Drawing.Color.Empty;
            this.CmbPointImages.FormattingEnabled = true;
            this.CmbPointImages.ItemHeight = 14;
            this.CmbPointImages.Location = new System.Drawing.Point(538, 33);
            this.CmbPointImages.Name = "CmbPointImages";
            this.CmbPointImages.Size = new System.Drawing.Size(160, 20);
            this.CmbPointImages.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.CmbPointImages.TabIndex = 983;
            // 
            // label75
            // 
            this.label75.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label75.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label75.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label75.ForeColor = System.Drawing.Color.SteelBlue;
            this.label75.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label75.Location = new System.Drawing.Point(244, 20);
            this.label75.Name = "label75";
            this.label75.Size = new System.Drawing.Size(143, 20);
            this.label75.TabIndex = 1008;
            this.label75.Text = "خيارات طباعة التصنيفات";
            this.label75.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label75.Visible = false;
            // 
            // chk39
            // 
            this.chk39.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.chk39.DisplayMember = "Text";
            this.chk39.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.chk39.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.chk39.FocusHighlightColor = System.Drawing.Color.Empty;
            this.chk39.FormattingEnabled = true;
            this.chk39.ItemHeight = 14;
            this.chk39.Location = new System.Drawing.Point(96, 22);
            this.chk39.Name = "chk39";
            this.chk39.Size = new System.Drawing.Size(143, 20);
            this.chk39.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chk39.TabIndex = 999;
            this.chk39.Visible = false;
            // 
            // expandablePanel_NewColumn
            // 
            this.expandablePanel_NewColumn.CanvasColor = System.Drawing.Color.Gainsboro;
            this.expandablePanel_NewColumn.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.expandablePanel_NewColumn.Controls.Add(this.Tree_NewCol);
            this.expandablePanel_NewColumn.Controls.Add(this.panel1);
            this.expandablePanel_NewColumn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.expandablePanel_NewColumn.Expanded = false;
            this.expandablePanel_NewColumn.ExpandedBounds = new System.Drawing.Rectangle(0, -12, 999, 441);
            this.expandablePanel_NewColumn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.expandablePanel_NewColumn.Location = new System.Drawing.Point(0, 451);
            this.expandablePanel_NewColumn.Name = "expandablePanel_NewColumn";
            this.expandablePanel_NewColumn.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.expandablePanel_NewColumn.Size = new System.Drawing.Size(1063, 26);
            this.expandablePanel_NewColumn.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanel_NewColumn.Style.BackColor1.Color = System.Drawing.Color.Gainsboro;
            this.expandablePanel_NewColumn.Style.BackColor2.Color = System.Drawing.Color.Gainsboro;
            this.expandablePanel_NewColumn.Style.BackgroundImagePosition = DevComponents.DotNetBar.eBackgroundImagePosition.Tile;
            this.expandablePanel_NewColumn.Style.BorderColor.Color = System.Drawing.Color.Gainsboro;
            this.expandablePanel_NewColumn.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandablePanel_NewColumn.Style.GradientAngle = 90;
            this.expandablePanel_NewColumn.TabIndex = 977;
            this.expandablePanel_NewColumn.TitleStyle.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanel_NewColumn.TitleStyle.BackColor1.Color = System.Drawing.Color.Gainsboro;
            this.expandablePanel_NewColumn.TitleStyle.BackColor2.Color = System.Drawing.Color.Gainsboro;
            this.expandablePanel_NewColumn.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.expandablePanel_NewColumn.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandablePanel_NewColumn.TitleStyle.ForeColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.expandablePanel_NewColumn.TitleStyle.GradientAngle = 90;
            this.expandablePanel_NewColumn.TitleText = "خيارات إضافة عمود للفواتير";
            // 
            // Tree_NewCol
            // 
            this.Tree_NewCol.AllowDrop = true;
            this.Tree_NewCol.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.Tree_NewCol.BackgroundStyle.BackColor = System.Drawing.Color.White;
            this.Tree_NewCol.BackgroundStyle.BackColor2 = System.Drawing.Color.MintCream;
            this.Tree_NewCol.BackgroundStyle.BackColorGradientAngle = 90;
            this.Tree_NewCol.BackgroundStyle.Class = "TreeBorderKey";
            this.Tree_NewCol.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Tree_NewCol.Dock = System.Windows.Forms.DockStyle.Top;
            this.Tree_NewCol.ExpandButtonSize = new System.Drawing.Size(10, 10);
            this.Tree_NewCol.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.Tree_NewCol.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.Tree_NewCol.Location = new System.Drawing.Point(0, 64);
            this.Tree_NewCol.Name = "Tree_NewCol";
            this.Tree_NewCol.NodeHorizontalSpacing = 6;
            this.Tree_NewCol.Nodes.AddRange(new DevComponents.AdvTree.Node[] {
            this.node1,
            this.node2,
            this.node3,
            this.node4,
            this.node5,
            this.node6,
            this.node7,
            this.node8,
            this.node9,
            this.node10,
            this.node11,
            this.node12,
            this.node13,
            this.node14});
            this.Tree_NewCol.NodesConnector = this.nodeConnector1;
            this.Tree_NewCol.NodeSpacing = 4;
            this.Tree_NewCol.NodeStyle = this.elementStyle3;
            this.Tree_NewCol.PathSeparator = ";";
            this.Tree_NewCol.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Tree_NewCol.ScrollBarAppearance = DevComponents.DotNetBar.eScrollBarAppearance.ApplicationScroll;
            this.Tree_NewCol.Size = new System.Drawing.Size(1063, 360);
            this.Tree_NewCol.Styles.Add(this.elementStyle3);
            this.Tree_NewCol.Styles.Add(this.elementStyle4);
            this.Tree_NewCol.TabIndex = 105;
            this.Tree_NewCol.TileSize = new System.Drawing.Size(0, 0);
            this.Tree_NewCol.View = DevComponents.AdvTree.eView.Tile;
            // 
            // node1
            // 
            this.node1.Expanded = true;
            this.node1.Name = "node1";
            this.node1.Nodes.AddRange(new DevComponents.AdvTree.Node[] {
            this.chk1Show,
            this.chk1Print});
            this.node1.Text = "فاتورة المبيعات";
            // 
            // chk1Show
            // 
            this.chk1Show.CheckBoxVisible = true;
            this.chk1Show.Expanded = true;
            this.chk1Show.Name = "chk1Show";
            this.chk1Show.Text = "شاشة العرض";
            // 
            // chk1Print
            // 
            this.chk1Print.CheckBoxVisible = true;
            this.chk1Print.Expanded = true;
            this.chk1Print.Name = "chk1Print";
            this.chk1Print.Text = "طباعة التقرير";
            // 
            // node2
            // 
            this.node2.Expanded = true;
            this.node2.Name = "node2";
            this.node2.Nodes.AddRange(new DevComponents.AdvTree.Node[] {
            this.chk2Show,
            this.chk2Print});
            this.node2.Text = "مرتجع مبيعات ";
            // 
            // chk2Show
            // 
            this.chk2Show.CheckBoxVisible = true;
            this.chk2Show.Expanded = true;
            this.chk2Show.Name = "chk2Show";
            this.chk2Show.Text = "شاشة العرض";
            // 
            // chk2Print
            // 
            this.chk2Print.CheckBoxVisible = true;
            this.chk2Print.Expanded = true;
            this.chk2Print.Name = "chk2Print";
            this.chk2Print.Text = "طباعة التقرير";
            // 
            // node3
            // 
            this.node3.Expanded = true;
            this.node3.Name = "node3";
            this.node3.Nodes.AddRange(new DevComponents.AdvTree.Node[] {
            this.chk3Show,
            this.chk3Print});
            this.node3.Text = "فاتورة مشتريات";
            // 
            // chk3Show
            // 
            this.chk3Show.CheckBoxVisible = true;
            this.chk3Show.Expanded = true;
            this.chk3Show.Name = "chk3Show";
            this.chk3Show.Text = "شاشة العرض";
            // 
            // chk3Print
            // 
            this.chk3Print.CheckBoxVisible = true;
            this.chk3Print.Expanded = true;
            this.chk3Print.Name = "chk3Print";
            this.chk3Print.Text = "طباعة التقرير";
            // 
            // node4
            // 
            this.node4.Expanded = true;
            this.node4.Name = "node4";
            this.node4.Nodes.AddRange(new DevComponents.AdvTree.Node[] {
            this.chk4Show,
            this.chk4Print});
            this.node4.Text = "مرتجع مشتريات";
            // 
            // chk4Show
            // 
            this.chk4Show.CheckBoxVisible = true;
            this.chk4Show.Expanded = true;
            this.chk4Show.Name = "chk4Show";
            this.chk4Show.Text = "شاشة العرض";
            // 
            // chk4Print
            // 
            this.chk4Print.CheckBoxVisible = true;
            this.chk4Print.Expanded = true;
            this.chk4Print.Name = "chk4Print";
            this.chk4Print.Text = "طباعة التقرير";
            // 
            // node5
            // 
            this.node5.Name = "node5";
            this.node5.Nodes.AddRange(new DevComponents.AdvTree.Node[] {
            this.chk5Show,
            this.chk5Print});
            this.node5.Text = "عرض سعر للعملاء";
            // 
            // chk5Show
            // 
            this.chk5Show.CheckBoxVisible = true;
            this.chk5Show.Expanded = true;
            this.chk5Show.Name = "chk5Show";
            this.chk5Show.Text = "شاشة العرض";
            // 
            // chk5Print
            // 
            this.chk5Print.CheckBoxVisible = true;
            this.chk5Print.Expanded = true;
            this.chk5Print.Name = "chk5Print";
            this.chk5Print.Text = "طباعة التقرير";
            // 
            // node6
            // 
            this.node6.Name = "node6";
            this.node6.Nodes.AddRange(new DevComponents.AdvTree.Node[] {
            this.chk6Show,
            this.chk6Print});
            this.node6.Text = "عرض سعر للموردين";
            // 
            // chk6Show
            // 
            this.chk6Show.CheckBoxVisible = true;
            this.chk6Show.Expanded = true;
            this.chk6Show.Name = "chk6Show";
            this.chk6Show.Text = "شاشة العرض";
            // 
            // chk6Print
            // 
            this.chk6Print.CheckBoxVisible = true;
            this.chk6Print.Expanded = true;
            this.chk6Print.Name = "chk6Print";
            this.chk6Print.Text = "طباعة التقرير";
            // 
            // node7
            // 
            this.node7.Name = "node7";
            this.node7.Nodes.AddRange(new DevComponents.AdvTree.Node[] {
            this.chk7Show,
            this.chk7Print});
            this.node7.Text = "طلب شراء";
            // 
            // chk7Show
            // 
            this.chk7Show.CheckBoxVisible = true;
            this.chk7Show.Expanded = true;
            this.chk7Show.Name = "chk7Show";
            this.chk7Show.Text = "شاشة العرض";
            // 
            // chk7Print
            // 
            this.chk7Print.CheckBoxVisible = true;
            this.chk7Print.Expanded = true;
            this.chk7Print.Name = "chk7Print";
            this.chk7Print.Text = "طباعة التقرير";
            // 
            // node8
            // 
            this.node8.Name = "node8";
            this.node8.Nodes.AddRange(new DevComponents.AdvTree.Node[] {
            this.chk8Show,
            this.chk8Print});
            this.node8.Text = "بضاعة اول المدة";
            // 
            // chk8Show
            // 
            this.chk8Show.CheckBoxVisible = true;
            this.chk8Show.Expanded = true;
            this.chk8Show.Name = "chk8Show";
            this.chk8Show.Text = "شاشة العرض";
            // 
            // chk8Print
            // 
            this.chk8Print.CheckBoxVisible = true;
            this.chk8Print.Expanded = true;
            this.chk8Print.Name = "chk8Print";
            this.chk8Print.Text = "طباعة التقرير";
            // 
            // node9
            // 
            this.node9.Name = "node9";
            this.node9.Nodes.AddRange(new DevComponents.AdvTree.Node[] {
            this.chk9Show,
            this.chk9Print});
            this.node9.Text = "إدخال بضاعة";
            // 
            // chk9Show
            // 
            this.chk9Show.CheckBoxVisible = true;
            this.chk9Show.Expanded = true;
            this.chk9Show.Name = "chk9Show";
            this.chk9Show.Text = "شاشة العرض";
            // 
            // chk9Print
            // 
            this.chk9Print.CheckBoxVisible = true;
            this.chk9Print.Expanded = true;
            this.chk9Print.Name = "chk9Print";
            this.chk9Print.Text = "طباعة التقرير";
            // 
            // node10
            // 
            this.node10.Name = "node10";
            this.node10.Nodes.AddRange(new DevComponents.AdvTree.Node[] {
            this.chk10Show,
            this.chk10Print});
            this.node10.Text = "اخراج بضاعة";
            // 
            // chk10Show
            // 
            this.chk10Show.CheckBoxVisible = true;
            this.chk10Show.Expanded = true;
            this.chk10Show.Name = "chk10Show";
            this.chk10Show.Text = "شاشة العرض";
            // 
            // chk10Print
            // 
            this.chk10Print.CheckBoxVisible = true;
            this.chk10Print.Expanded = true;
            this.chk10Print.Name = "chk10Print";
            this.chk10Print.Text = "طباعة التقرير";
            // 
            // node11
            // 
            this.node11.Name = "node11";
            this.node11.Nodes.AddRange(new DevComponents.AdvTree.Node[] {
            this.chk11Show,
            this.chk11Print});
            this.node11.Text = "صرف بضاعة";
            // 
            // chk11Show
            // 
            this.chk11Show.CheckBoxVisible = true;
            this.chk11Show.Expanded = true;
            this.chk11Show.Name = "chk11Show";
            this.chk11Show.Text = "شاشة العرض";
            // 
            // chk11Print
            // 
            this.chk11Print.CheckBoxVisible = true;
            this.chk11Print.Expanded = true;
            this.chk11Print.Name = "chk11Print";
            this.chk11Print.Text = "طباعة التقرير";
            // 
            // node12
            // 
            this.node12.Expanded = true;
            this.node12.Name = "node12";
            this.node12.Nodes.AddRange(new DevComponents.AdvTree.Node[] {
            this.chk12Show,
            this.chk12Print});
            this.node12.Text = "مرتجع صرف بضاعة";
            // 
            // chk12Show
            // 
            this.chk12Show.CheckBoxVisible = true;
            this.chk12Show.Expanded = true;
            this.chk12Show.Name = "chk12Show";
            this.chk12Show.Text = "شاشة العرض";
            // 
            // chk12Print
            // 
            this.chk12Print.CheckBoxVisible = true;
            this.chk12Print.Expanded = true;
            this.chk12Print.Name = "chk12Print";
            this.chk12Print.Text = "طباعة التقرير";
            // 
            // node13
            // 
            this.node13.Name = "node13";
            this.node13.Nodes.AddRange(new DevComponents.AdvTree.Node[] {
            this.chk13Show,
            this.chk13Print});
            this.node13.Text = "تسوية البضاعة";
            // 
            // chk13Show
            // 
            this.chk13Show.CheckBoxVisible = true;
            this.chk13Show.Expanded = true;
            this.chk13Show.Name = "chk13Show";
            this.chk13Show.Text = "شاشة العرض";
            // 
            // chk13Print
            // 
            this.chk13Print.CheckBoxVisible = true;
            this.chk13Print.Expanded = true;
            this.chk13Print.Name = "chk13Print";
            this.chk13Print.Text = "طباعة التقرير";
            // 
            // node14
            // 
            this.node14.Name = "node14";
            this.node14.Nodes.AddRange(new DevComponents.AdvTree.Node[] {
            this.chk14Show,
            this.chk14Print});
            this.node14.Text = "شاشة نقاط البيع";
            // 
            // chk14Show
            // 
            this.chk14Show.CheckBoxVisible = true;
            this.chk14Show.Name = "chk14Show";
            this.chk14Show.Text = "شاشة العرض";
            // 
            // chk14Print
            // 
            this.chk14Print.CheckBoxVisible = true;
            this.chk14Print.Name = "chk14Print";
            this.chk14Print.Text = "طباعة التقارير";
            // 
            // nodeConnector1
            // 
            this.nodeConnector1.LineColor = System.Drawing.SystemColors.ControlText;
            // 
            // elementStyle3
            // 
            this.elementStyle3.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.elementStyle3.Name = "elementStyle3";
            this.elementStyle3.TextColor = System.Drawing.SystemColors.ControlText;
            // 
            // elementStyle4
            // 
            this.elementStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(215)))), ((int)(((byte)(255)))));
            this.elementStyle4.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.elementStyle4.BackColorGradientAngle = 90;
            this.elementStyle4.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle4.BorderBottomWidth = 1;
            this.elementStyle4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(105)))), ((int)(((byte)(140)))));
            this.elementStyle4.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.elementStyle4.Description = "Blue";
            this.elementStyle4.Name = "elementStyle4";
            this.elementStyle4.PaddingBottom = 1;
            this.elementStyle4.PaddingLeft = 1;
            this.elementStyle4.PaddingRight = 1;
            this.elementStyle4.PaddingTop = 1;
            this.elementStyle4.TextColor = System.Drawing.Color.Black;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.switchButton_NewColumnName);
            this.panel1.Controls.Add(this.textBox_LineDetailNameE);
            this.panel1.Controls.Add(this.label55);
            this.panel1.Controls.Add(this.textBox_LineDetailNameA);
            this.panel1.Controls.Add(this.label53);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 26);
            this.panel1.Name = "panel1";
            this.panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.panel1.Size = new System.Drawing.Size(1063, 38);
            this.panel1.TabIndex = 102;
            // 
            // switchButton_NewColumnName
            // 
            // 
            // 
            // 
            this.switchButton_NewColumnName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.switchButton_NewColumnName.Font = new System.Drawing.Font("Tahoma", 7F);
            this.switchButton_NewColumnName.Location = new System.Drawing.Point(8, 9);
            this.switchButton_NewColumnName.Name = "switchButton_NewColumnName";
            this.switchButton_NewColumnName.OffBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(80)))), ((int)(((byte)(77)))));
            this.switchButton_NewColumnName.OffText = "الهــدية";
            this.switchButton_NewColumnName.OffTextColor = System.Drawing.Color.White;
            this.switchButton_NewColumnName.OnText = "تفاصيل اخرى";
            this.switchButton_NewColumnName.Size = new System.Drawing.Size(193, 21);
            this.switchButton_NewColumnName.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.switchButton_NewColumnName.TabIndex = 1153;
            this.switchButton_NewColumnName.Value = true;
            this.switchButton_NewColumnName.ValueObject = "Y";
            this.switchButton_NewColumnName.ValueChanged += new System.EventHandler(this.switchButton_NewColumnName_ValueChanged);
            // 
            // textBox_LineDetailNameE
            // 
            this.textBox_LineDetailNameE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_LineDetailNameE.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.textBox_LineDetailNameE.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.textBox_LineDetailNameE.Location = new System.Drawing.Point(245, 9);
            this.textBox_LineDetailNameE.MaxLength = 30;
            this.textBox_LineDetailNameE.Name = "textBox_LineDetailNameE";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_LineDetailNameE, false);
            this.textBox_LineDetailNameE.Size = new System.Drawing.Size(155, 20);
            this.textBox_LineDetailNameE.TabIndex = 104;
            this.textBox_LineDetailNameE.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.BackColor = System.Drawing.Color.Transparent;
            this.label55.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label55.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label55.Location = new System.Drawing.Point(402, 13);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(89, 13);
            this.label55.TabIndex = 105;
            this.label55.Text = "الإسم الإنجليزي :";
            // 
            // textBox_LineDetailNameA
            // 
            this.textBox_LineDetailNameA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_LineDetailNameA.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.textBox_LineDetailNameA.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.textBox_LineDetailNameA.Location = new System.Drawing.Point(526, 9);
            this.textBox_LineDetailNameA.MaxLength = 30;
            this.textBox_LineDetailNameA.Name = "textBox_LineDetailNameA";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_LineDetailNameA, false);
            this.textBox_LineDetailNameA.Size = new System.Drawing.Size(155, 20);
            this.textBox_LineDetailNameA.TabIndex = 102;
            this.textBox_LineDetailNameA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.BackColor = System.Drawing.Color.Transparent;
            this.label53.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label53.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label53.Location = new System.Drawing.Point(683, 13);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(77, 13);
            this.label53.TabIndex = 103;
            this.label53.Text = "الإسم العربي :";
            // 
            // label79
            // 
            this.label79.BackColor = System.Drawing.Color.AliceBlue;
            this.label79.Location = new System.Drawing.Point(-1, 366);
            this.label79.Name = "label79";
            this.label79.Size = new System.Drawing.Size(784, 20);
            this.label79.TabIndex = 1040;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label9.Location = new System.Drawing.Point(543, 454);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(104, 13);
            this.label9.TabIndex = 963;
            this.label9.Text = "طريقة الدفع المعتمدة";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(779, 454);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(108, 13);
            this.label8.TabIndex = 962;
            this.label8.Text = "سعر التكلفة المعتمدة";
            this.label8.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // CmbInvMode
            // 
            this.CmbInvMode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbInvMode.DisplayMember = "Text";
            this.CmbInvMode.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.CmbInvMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbInvMode.FocusHighlightColor = System.Drawing.Color.Empty;
            this.CmbInvMode.FormattingEnabled = true;
            this.CmbInvMode.ItemHeight = 14;
            this.CmbInvMode.Location = new System.Drawing.Point(460, 450);
            this.CmbInvMode.Name = "CmbInvMode";
            this.CmbInvMode.Size = new System.Drawing.Size(82, 20);
            this.CmbInvMode.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.CmbInvMode.TabIndex = 967;
            // 
            // CmbCost
            // 
            this.CmbCost.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbCost.DisplayMember = "Text";
            this.CmbCost.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.CmbCost.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbCost.FocusHighlightColor = System.Drawing.Color.Empty;
            this.CmbCost.FormattingEnabled = true;
            this.CmbCost.ItemHeight = 14;
            this.CmbCost.Location = new System.Drawing.Point(650, 450);
            this.CmbCost.Name = "CmbCost";
            this.CmbCost.Size = new System.Drawing.Size(128, 20);
            this.CmbCost.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.CmbCost.TabIndex = 966;
            // 
            // superTabItem_Inv
            // 
            this.superTabItem_Inv.AttachedControl = this.superTabControlPanel2;
            this.superTabItem_Inv.GlobalItem = false;
            this.superTabItem_Inv.Name = "superTabItem_Inv";
            this.superTabItem_Inv.Text = "الفواتير";
            // 
            // superTabControlPanel1
            // 
            this.superTabControlPanel1.AutoScroll = true;
            this.superTabControlPanel1.Controls.Add(this.label100);
            this.superTabControlPanel1.Controls.Add(this.groupPanel17);
            this.superTabControlPanel1.Controls.Add(this.groupPanel16);
            this.superTabControlPanel1.Controls.Add(this.groupPanel5);
            this.superTabControlPanel1.Controls.Add(this.groupPanel_Banner);
            this.superTabControlPanel1.Controls.Add(this.groupPanel3);
            this.superTabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel1.Location = new System.Drawing.Point(0, 0);
            this.superTabControlPanel1.Name = "superTabControlPanel1";
            superTabLinearGradientColorTable3.Colors = new System.Drawing.Color[] {
        System.Drawing.Color.Gainsboro};
            superTabPanelItemColorTable3.Background = superTabLinearGradientColorTable3;
            superTabPanelColorTable3.Default = superTabPanelItemColorTable3;
            this.superTabControlPanel1.PanelColor = superTabPanelColorTable3;
            this.superTabControlPanel1.Size = new System.Drawing.Size(1069, 514);
            this.superTabControlPanel1.TabIndex = 1;
            this.superTabControlPanel1.TabItem = this.superTabItem_Banner;
            // 
            // label100
            // 
            this.label100.AutoSize = true;
            this.label100.Location = new System.Drawing.Point(611, 165);
            this.label100.Name = "label100";
            this.label100.Size = new System.Drawing.Size(72, 13);
            this.label100.TabIndex = 6813;
            this.label100.Text = "بيانات المنشأه";
            // 
            // groupPanel17
            // 
            this.groupPanel17.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel17.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel17.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel17.Controls.Add(this.groupPanel6);
            this.groupPanel17.Controls.Add(this.label56);
            this.groupPanel17.Controls.Add(this.txtEmailPass);
            this.groupPanel17.Controls.Add(this.CmbMail);
            this.groupPanel17.Controls.Add(this.label14);
            this.groupPanel17.Controls.Add(this.txtEmailBoss);
            this.groupPanel17.Controls.Add(this.txtCompany);
            this.groupPanel17.Controls.Add(this.label52);
            this.groupPanel17.Controls.Add(this.label15);
            this.groupPanel17.Controls.Add(this.txtAct);
            this.groupPanel17.Controls.Add(this.label54);
            this.groupPanel17.Controls.Add(this.label16);
            this.groupPanel17.Controls.Add(this.txtRemark);
            this.groupPanel17.Controls.Add(this.txtAddr);
            this.groupPanel17.Controls.Add(this.txtTel2);
            this.groupPanel17.Controls.Add(this.label17);
            this.groupPanel17.Controls.Add(this.label20);
            this.groupPanel17.Controls.Add(this.txtTel1);
            this.groupPanel17.Controls.Add(this.label23);
            this.groupPanel17.Controls.Add(this.label19);
            this.groupPanel17.Controls.Add(this.txtMailCode);
            this.groupPanel17.Controls.Add(this.txtMobile);
            this.groupPanel17.Controls.Add(this.label22);
            this.groupPanel17.Controls.Add(this.label18);
            this.groupPanel17.Controls.Add(this.txtPOBox);
            this.groupPanel17.Controls.Add(this.txtFax);
            this.groupPanel17.Controls.Add(this.label21);
            this.groupPanel17.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupPanel17.Location = new System.Drawing.Point(0, 232);
            this.groupPanel17.Name = "groupPanel17";
            this.groupPanel17.Size = new System.Drawing.Size(1069, 238);
            // 
            // 
            // 
            this.groupPanel17.Style.BackColor = System.Drawing.Color.Gainsboro;
            this.groupPanel17.Style.BackColor2 = System.Drawing.Color.Gainsboro;
            this.groupPanel17.Style.BackColorGradientAngle = 90;
            this.groupPanel17.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel17.Style.BorderBottomWidth = 1;
            this.groupPanel17.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel17.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel17.Style.BorderLeftWidth = 1;
            this.groupPanel17.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel17.Style.BorderRightWidth = 1;
            this.groupPanel17.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel17.Style.BorderTopWidth = 1;
            this.groupPanel17.Style.CornerDiameter = 4;
            this.groupPanel17.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel17.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Far;
            this.groupPanel17.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            // 
            // 
            // 
            this.groupPanel17.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel17.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel17.TabIndex = 6812;
            // 
            // groupPanel6
            // 
            this.groupPanel6.BackColor = System.Drawing.Color.Silver;
            this.groupPanel6.CanvasColor = System.Drawing.Color.Silver;
            this.groupPanel6.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel6.Controls.Add(this.radioButton_IsNotBackground);
            this.groupPanel6.Controls.Add(this.pictureBox_EnterPic);
            this.groupPanel6.Controls.Add(this.button_RemoveBackgroud);
            this.groupPanel6.Controls.Add(this.button_Background);
            this.groupPanel6.Location = new System.Drawing.Point(6, 0);
            this.groupPanel6.Name = "groupPanel6";
            this.groupPanel6.Size = new System.Drawing.Size(285, 238);
            // 
            // 
            // 
            this.groupPanel6.Style.BackColor = System.Drawing.Color.Gainsboro;
            this.groupPanel6.Style.BackColor2 = System.Drawing.Color.Gainsboro;
            this.groupPanel6.Style.BackColorGradientAngle = 90;
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
            this.groupPanel6.TabIndex = 971;
            // 
            // radioButton_IsNotBackground
            // 
            this.radioButton_IsNotBackground.AutoSize = true;
            this.radioButton_IsNotBackground.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.radioButton_IsNotBackground.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.radioButton_IsNotBackground.CheckBoxPosition = DevComponents.DotNetBar.eCheckBoxPosition.Right;
            this.radioButton_IsNotBackground.Font = new System.Drawing.Font("Tahoma", 8F);
            this.radioButton_IsNotBackground.Location = new System.Drawing.Point(103, 195);
            this.radioButton_IsNotBackground.Name = "radioButton_IsNotBackground";
            this.radioButton_IsNotBackground.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.radioButton_IsNotBackground.Size = new System.Drawing.Size(105, 15);
            this.radioButton_IsNotBackground.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.radioButton_IsNotBackground.TabIndex = 973;
            this.radioButton_IsNotBackground.Text = "إيقاف خلفية النظام";
            this.radioButton_IsNotBackground.TextColor = System.Drawing.Color.Red;
            // 
            // pictureBox_EnterPic
            // 
            this.pictureBox_EnterPic.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.pictureBox_EnterPic.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.pictureBox_EnterPic.BackgroundStyle.BorderBottomColor = System.Drawing.Color.SteelBlue;
            this.pictureBox_EnterPic.BackgroundStyle.BorderBottomWidth = 1;
            this.pictureBox_EnterPic.BackgroundStyle.BorderColor = System.Drawing.Color.SteelBlue;
            this.pictureBox_EnterPic.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.pictureBox_EnterPic.BackgroundStyle.BorderLeftColor = System.Drawing.Color.SteelBlue;
            this.pictureBox_EnterPic.BackgroundStyle.BorderLeftWidth = 1;
            this.pictureBox_EnterPic.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.pictureBox_EnterPic.BackgroundStyle.BorderRightWidth = 1;
            this.pictureBox_EnterPic.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.pictureBox_EnterPic.BackgroundStyle.BorderTopWidth = 1;
            this.pictureBox_EnterPic.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.pictureBox_EnterPic.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.pictureBox_EnterPic.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_EnterPic.Image")));
            this.pictureBox_EnterPic.Location = new System.Drawing.Point(3, 29);
            this.pictureBox_EnterPic.Name = "pictureBox_EnterPic";
            this.pictureBox_EnterPic.Size = new System.Drawing.Size(266, 160);
            this.pictureBox_EnterPic.TabIndex = 941;
            // 
            // button_RemoveBackgroud
            // 
            this.button_RemoveBackgroud.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_RemoveBackgroud.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_RemoveBackgroud.Location = new System.Drawing.Point(32, 195);
            this.button_RemoveBackgroud.Name = "button_RemoveBackgroud";
            this.button_RemoveBackgroud.Size = new System.Drawing.Size(65, 22);
            this.button_RemoveBackgroud.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_RemoveBackgroud.Symbol = "";
            this.button_RemoveBackgroud.SymbolSize = 11F;
            this.button_RemoveBackgroud.TabIndex = 938;
            this.button_RemoveBackgroud.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button_RemoveBackgroud.Click += new System.EventHandler(this.button_RemoveBackgroud_Click);
            // 
            // button_Background
            // 
            this.button_Background.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_Background.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_Background.Location = new System.Drawing.Point(6, 195);
            this.button_Background.Name = "button_Background";
            this.button_Background.Size = new System.Drawing.Size(23, 22);
            this.button_Background.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_Background.Symbol = "";
            this.button_Background.SymbolSize = 11F;
            this.button_Background.TabIndex = 937;
            this.button_Background.TextColor = System.Drawing.Color.SteelBlue;
            this.button_Background.Click += new System.EventHandler(this.button_Background_Click);
            // 
            // label56
            // 
            this.label56.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
            this.label56.AutoSize = true;
            this.label56.BackColor = System.Drawing.Color.Transparent;
            this.label56.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label56.ForeColor = System.Drawing.Color.Red;
            this.label56.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label56.Location = new System.Drawing.Point(382, 31);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(79, 13);
            this.label56.TabIndex = 971;
            this.label56.Text = "عنوان الخادم :";
            // 
            // txtEmailPass
            // 
            this.txtEmailPass.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
            this.txtEmailPass.BackColor = System.Drawing.Color.Red;
            this.txtEmailPass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmailPass.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.txtEmailPass.ForeColor = System.Drawing.Color.White;
            this.txtEmailPass.Location = new System.Drawing.Point(326, 134);
            this.txtEmailPass.MaxLength = 100;
            this.txtEmailPass.Name = "txtEmailPass";
            this.txtEmailPass.PasswordChar = '*';
            this.netResize1.SetResizeTextBoxMultiline(this.txtEmailPass, false);
            this.txtEmailPass.Size = new System.Drawing.Size(117, 22);
            this.txtEmailPass.TabIndex = 108;
            this.txtEmailPass.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtEmailPass.Click += new System.EventHandler(this.txtEmailPass_Click);
            // 
            // CmbMail
            // 
            this.CmbMail.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
            this.CmbMail.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbMail.DisplayMember = "Text";
            this.CmbMail.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.CmbMail.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbMail.FocusHighlightColor = System.Drawing.Color.Empty;
            this.CmbMail.FormattingEnabled = true;
            this.CmbMail.ItemHeight = 14;
            this.CmbMail.Location = new System.Drawing.Point(326, 27);
            this.CmbMail.Name = "CmbMail";
            this.CmbMail.Size = new System.Drawing.Size(108, 20);
            this.CmbMail.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.CmbMail.TabIndex = 970;
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label14.Location = new System.Drawing.Point(910, 4);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(91, 13);
            this.label14.TabIndex = 98;
            this.label14.Text = "الإســــــــــــــــم :";
            // 
            // txtEmailBoss
            // 
            this.txtEmailBoss.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
            this.txtEmailBoss.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmailBoss.Location = new System.Drawing.Point(518, 110);
            this.txtEmailBoss.MaxLength = 50;
            this.txtEmailBoss.Name = "txtEmailBoss";
            this.netResize1.SetResizeTextBoxMultiline(this.txtEmailBoss, false);
            this.txtEmailBoss.Size = new System.Drawing.Size(381, 20);
            this.txtEmailBoss.TabIndex = 886;
            this.txtEmailBoss.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtEmailBoss.Click += new System.EventHandler(this.txtEmailBoss_Click);
            this.txtEmailBoss.Enter += new System.EventHandler(this.txtEmailBoss_Enter);
            this.txtEmailBoss.Leave += new System.EventHandler(this.txtEmailBoss_Leave);
            // 
            // txtCompany
            // 
            this.txtCompany.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
            this.txtCompany.BackColor = System.Drawing.Color.White;
            this.txtCompany.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCompany.Location = new System.Drawing.Point(326, 0);
            this.txtCompany.MaxLength = 50;
            this.txtCompany.Name = "txtCompany";
            this.netResize1.SetResizeTextBoxMultiline(this.txtCompany, false);
            this.txtCompany.Size = new System.Drawing.Size(576, 20);
            this.txtCompany.TabIndex = 88;
            this.txtCompany.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCompany.Click += new System.EventHandler(this.txtCompany_Click);
            // 
            // label52
            // 
            this.label52.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
            this.label52.AutoSize = true;
            this.label52.BackColor = System.Drawing.Color.Transparent;
            this.label52.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label52.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label52.Location = new System.Drawing.Point(909, 112);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(93, 13);
            this.label52.TabIndex = 887;
            this.label52.Text = "إيميــــل المــــدير :";
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label15.Location = new System.Drawing.Point(909, 29);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(91, 13);
            this.label15.TabIndex = 99;
            this.label15.Text = "النشـــــــــــــــاط :";
            // 
            // txtAct
            // 
            this.txtAct.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
            this.txtAct.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAct.Location = new System.Drawing.Point(518, 27);
            this.txtAct.MaxLength = 20;
            this.txtAct.Name = "txtAct";
            this.netResize1.SetResizeTextBoxMultiline(this.txtAct, false);
            this.txtAct.Size = new System.Drawing.Size(381, 20);
            this.txtAct.TabIndex = 89;
            this.txtAct.Click += new System.EventHandler(this.txtAct_Click);
            // 
            // label54
            // 
            this.label54.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
            this.label54.AutoSize = true;
            this.label54.BackColor = System.Drawing.Color.Transparent;
            this.label54.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label54.Location = new System.Drawing.Point(389, 139);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(64, 13);
            this.label54.TabIndex = 109;
            this.label54.Text = "البــاســورد :";
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label16.Location = new System.Drawing.Point(909, 56);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(90, 13);
            this.label16.TabIndex = 100;
            this.label16.Text = "العنـــــــــــــــوان :";
            // 
            // txtRemark
            // 
            this.txtRemark.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
            this.txtRemark.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRemark.Location = new System.Drawing.Point(326, 193);
            this.txtRemark.MaxLength = 100;
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.netResize1.SetResizeTextBoxMultiline(this.txtRemark, false);
            this.txtRemark.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtRemark.Size = new System.Drawing.Size(577, 29);
            this.txtRemark.TabIndex = 97;
            this.txtRemark.Click += new System.EventHandler(this.txtRemark_Click);
            // 
            // txtAddr
            // 
            this.txtAddr.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
            this.txtAddr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAddr.Location = new System.Drawing.Point(270, 54);
            this.txtAddr.MaxLength = 50;
            this.txtAddr.Name = "txtAddr";
            this.netResize1.SetResizeTextBoxMultiline(this.txtAddr, false);
            this.txtAddr.Size = new System.Drawing.Size(577, 20);
            this.txtAddr.TabIndex = 90;
            this.txtAddr.Click += new System.EventHandler(this.txtAddr_Click);
            // 
            // txtTel2
            // 
            this.txtTel2.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
            this.txtTel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTel2.Location = new System.Drawing.Point(518, 135);
            this.txtTel2.MaxLength = 50;
            this.txtTel2.Name = "txtTel2";
            this.netResize1.SetResizeTextBoxMultiline(this.txtTel2, false);
            this.txtTel2.Size = new System.Drawing.Size(381, 20);
            this.txtTel2.TabIndex = 94;
            this.txtTel2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTel2.Click += new System.EventHandler(this.txtTel2_Click);
            this.txtTel2.Enter += new System.EventHandler(this.txtEmailBoss_Enter);
            this.txtTel2.Leave += new System.EventHandler(this.txtEmailBoss_Leave);
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label17.Location = new System.Drawing.Point(909, 83);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(96, 13);
            this.label17.TabIndex = 101;
            this.label17.Text = "  الهاتــــــــــــــــف :";
            // 
            // label20
            // 
            this.label20.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.Transparent;
            this.label20.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label20.Location = new System.Drawing.Point(909, 137);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(94, 13);
            this.label20.TabIndex = 107;
            this.label20.Text = "إيميــــل المنشـآة :";
            // 
            // txtTel1
            // 
            this.txtTel1.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
            this.txtTel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTel1.Location = new System.Drawing.Point(518, 81);
            this.txtTel1.MaxLength = 20;
            this.txtTel1.Name = "txtTel1";
            this.netResize1.SetResizeTextBoxMultiline(this.txtTel1, false);
            this.txtTel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtTel1.Size = new System.Drawing.Size(381, 20);
            this.txtTel1.TabIndex = 91;
            this.txtTel1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTel1.Click += new System.EventHandler(this.txtTel1_Click);
            this.txtTel1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHeadingR3_KeyPress);
            // 
            // label23
            // 
            this.label23.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
            this.label23.AutoSize = true;
            this.label23.BackColor = System.Drawing.Color.Transparent;
            this.label23.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label23.Location = new System.Drawing.Point(909, 191);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(89, 13);
            this.label23.TabIndex = 106;
            this.label23.Text = "الملاحظـــــــــات :";
            // 
            // label19
            // 
            this.label19.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.Color.Transparent;
            this.label19.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label19.Location = new System.Drawing.Point(445, 112);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(63, 13);
            this.label19.TabIndex = 102;
            this.label19.Text = "جـــــــــوال :";
            // 
            // txtMailCode
            // 
            this.txtMailCode.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
            this.txtMailCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMailCode.Location = new System.Drawing.Point(325, 162);
            this.txtMailCode.MaxLength = 20;
            this.txtMailCode.Name = "txtMailCode";
            this.netResize1.SetResizeTextBoxMultiline(this.txtMailCode, false);
            this.txtMailCode.Size = new System.Drawing.Size(117, 20);
            this.txtMailCode.TabIndex = 96;
            this.txtMailCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMailCode.Click += new System.EventHandler(this.txtMailCode_Click);
            // 
            // txtMobile
            // 
            this.txtMobile.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
            this.txtMobile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMobile.Location = new System.Drawing.Point(325, 108);
            this.txtMobile.MaxLength = 15;
            this.txtMobile.Name = "txtMobile";
            this.netResize1.SetResizeTextBoxMultiline(this.txtMobile, false);
            this.txtMobile.Size = new System.Drawing.Size(117, 20);
            this.txtMobile.TabIndex = 93;
            this.txtMobile.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMobile.Click += new System.EventHandler(this.txtMobile_Click);
            this.txtMobile.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMobile_KeyPress);
            // 
            // label22
            // 
            this.label22.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
            this.label22.AutoSize = true;
            this.label22.BackColor = System.Drawing.Color.Transparent;
            this.label22.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label22.Location = new System.Drawing.Point(445, 166);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(73, 13);
            this.label22.TabIndex = 105;
            this.label22.Text = "الرمز البريدي :";
            // 
            // label18
            // 
            this.label18.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.Transparent;
            this.label18.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label18.Location = new System.Drawing.Point(445, 85);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(59, 13);
            this.label18.TabIndex = 103;
            this.label18.Text = "فاكــــــس :";
            // 
            // txtPOBox
            // 
            this.txtPOBox.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
            this.txtPOBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPOBox.Location = new System.Drawing.Point(518, 162);
            this.txtPOBox.MaxLength = 20;
            this.txtPOBox.Name = "txtPOBox";
            this.netResize1.SetResizeTextBoxMultiline(this.txtPOBox, false);
            this.txtPOBox.Size = new System.Drawing.Size(381, 20);
            this.txtPOBox.TabIndex = 95;
            this.txtPOBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPOBox.Click += new System.EventHandler(this.txtPOBox_Click);
            // 
            // txtFax
            // 
            this.txtFax.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
            this.txtFax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFax.Location = new System.Drawing.Point(325, 81);
            this.txtFax.MaxLength = 20;
            this.txtFax.Name = "txtFax";
            this.netResize1.SetResizeTextBoxMultiline(this.txtFax, false);
            this.txtFax.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtFax.Size = new System.Drawing.Size(117, 20);
            this.txtFax.TabIndex = 92;
            this.txtFax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtFax.Click += new System.EventHandler(this.txtFax_Click);
            this.txtFax.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHeadingR3_KeyPress);
            // 
            // label21
            // 
            this.label21.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
            this.label21.AutoSize = true;
            this.label21.BackColor = System.Drawing.Color.Transparent;
            this.label21.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label21.Location = new System.Drawing.Point(909, 164);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(87, 13);
            this.label21.TabIndex = 104;
            this.label21.Text = "صنــدوق البريــد :";
            // 
            // groupPanel16
            // 
            this.groupPanel16.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel16.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel16.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel16.Controls.Add(this.label4);
            this.groupPanel16.Controls.Add(this.txtHeadingL1);
            this.groupPanel16.Controls.Add(this.txtHeadingL2);
            this.groupPanel16.Controls.Add(this.txtHeadingL3);
            this.groupPanel16.Controls.Add(this.label3);
            this.groupPanel16.Controls.Add(this.txtHeadingL4);
            this.groupPanel16.Location = new System.Drawing.Point(4, 17);
            this.groupPanel16.Name = "groupPanel16";
            this.groupPanel16.Size = new System.Drawing.Size(429, 139);
            // 
            // 
            // 
            this.groupPanel16.Style.BackColor = System.Drawing.Color.Gainsboro;
            this.groupPanel16.Style.BackColor2 = System.Drawing.Color.Gainsboro;
            this.groupPanel16.Style.BackColorGradientAngle = 90;
            this.groupPanel16.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel16.Style.BorderBottomWidth = 1;
            this.groupPanel16.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel16.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel16.Style.BorderLeftWidth = 1;
            this.groupPanel16.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel16.Style.BorderRightWidth = 1;
            this.groupPanel16.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel16.Style.BorderTopWidth = 1;
            this.groupPanel16.Style.CornerDiameter = 4;
            this.groupPanel16.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel16.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Far;
            this.groupPanel16.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            // 
            // 
            // 
            this.groupPanel16.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel16.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel16.TabIndex = 985;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(332, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 13);
            this.label4.TabIndex = 983;
            this.label4.Text = "العنوان الإنجليزي :";
            // 
            // txtHeadingL1
            // 
            this.txtHeadingL1.BackColor = System.Drawing.SystemColors.Control;
            // 
            // 
            // 
            this.txtHeadingL1.Border.Class = "TextBoxBorder";
            this.txtHeadingL1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtHeadingL1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtHeadingL1.Location = new System.Drawing.Point(3, 3);
            this.txtHeadingL1.Name = "txtHeadingL1";
            this.netResize1.SetResizeTextBoxMultiline(this.txtHeadingL1, false);
            this.txtHeadingL1.Size = new System.Drawing.Size(329, 20);
            this.txtHeadingL1.TabIndex = 976;
            this.txtHeadingL1.Tag = "lTrwes1";
            this.txtHeadingL1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtHeadingL1.Click += new System.EventHandler(this.txtHeadingL1_Click);
            this.txtHeadingL1.Enter += new System.EventHandler(this.textbox_Eng_Des_Enter);
            this.txtHeadingL1.Leave += new System.EventHandler(this.textbox_Arb_Des_Enter);
            // 
            // txtHeadingL2
            // 
            this.txtHeadingL2.BackColor = System.Drawing.SystemColors.Control;
            // 
            // 
            // 
            this.txtHeadingL2.Border.Class = "TextBoxBorder";
            this.txtHeadingL2.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtHeadingL2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtHeadingL2.Location = new System.Drawing.Point(3, 36);
            this.txtHeadingL2.Name = "txtHeadingL2";
            this.netResize1.SetResizeTextBoxMultiline(this.txtHeadingL2, false);
            this.txtHeadingL2.Size = new System.Drawing.Size(329, 20);
            this.txtHeadingL2.TabIndex = 977;
            this.txtHeadingL2.Tag = "lTrwes2";
            this.txtHeadingL2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtHeadingL2.Click += new System.EventHandler(this.txtHeadingL2_Click);
            this.txtHeadingL2.Enter += new System.EventHandler(this.textbox_Eng_Des_Enter);
            this.txtHeadingL2.Leave += new System.EventHandler(this.textbox_Arb_Des_Enter);
            // 
            // txtHeadingL3
            // 
            this.txtHeadingL3.BackColor = System.Drawing.SystemColors.Control;
            // 
            // 
            // 
            this.txtHeadingL3.Border.Class = "TextBoxBorder";
            this.txtHeadingL3.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtHeadingL3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtHeadingL3.Location = new System.Drawing.Point(3, 69);
            this.txtHeadingL3.Name = "txtHeadingL3";
            this.netResize1.SetResizeTextBoxMultiline(this.txtHeadingL3, false);
            this.txtHeadingL3.Size = new System.Drawing.Size(411, 20);
            this.txtHeadingL3.TabIndex = 978;
            this.txtHeadingL3.Tag = "lTrwes3";
            this.txtHeadingL3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtHeadingL3.Click += new System.EventHandler(this.txtHeadingL3_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(332, -1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 982;
            this.label3.Text = "الإسم الإنجليزي :";
            // 
            // txtHeadingL4
            // 
            this.txtHeadingL4.BackColor = System.Drawing.SystemColors.Control;
            // 
            // 
            // 
            this.txtHeadingL4.Border.Class = "TextBoxBorder";
            this.txtHeadingL4.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtHeadingL4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtHeadingL4.Location = new System.Drawing.Point(3, 102);
            this.txtHeadingL4.Name = "txtHeadingL4";
            this.netResize1.SetResizeTextBoxMultiline(this.txtHeadingL4, false);
            this.txtHeadingL4.Size = new System.Drawing.Size(411, 20);
            this.txtHeadingL4.TabIndex = 979;
            this.txtHeadingL4.Tag = "lTrwes4";
            this.txtHeadingL4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtHeadingL4.Click += new System.EventHandler(this.txtHeadingL4_Click);
            // 
            // groupPanel5
            // 
            this.groupPanel5.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel5.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel5.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel5.Controls.Add(this.ChkPageNumber);
            this.groupPanel5.Controls.Add(this.ChkGreg);
            this.groupPanel5.Controls.Add(this.ChkHijri);
            this.groupPanel5.Controls.Add(this.ChkHead);
            this.groupPanel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupPanel5.Location = new System.Drawing.Point(0, 470);
            this.groupPanel5.Name = "groupPanel5";
            this.groupPanel5.Size = new System.Drawing.Size(1069, 44);
            // 
            // 
            // 
            this.groupPanel5.Style.BackColor = System.Drawing.Color.Gainsboro;
            this.groupPanel5.Style.BackColor2 = System.Drawing.Color.Gainsboro;
            this.groupPanel5.Style.BackColorGradientAngle = 90;
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
            this.groupPanel5.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Far;
            this.groupPanel5.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            // 
            // 
            // 
            this.groupPanel5.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel5.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel5.TabIndex = 970;
            // 
            // ChkPageNumber
            // 
            this.ChkPageNumber.AutoSize = true;
            this.ChkPageNumber.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.ChkPageNumber.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ChkPageNumber.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.ChkPageNumber.Location = new System.Drawing.Point(216, 20);
            this.ChkPageNumber.Name = "ChkPageNumber";
            this.ChkPageNumber.Size = new System.Drawing.Size(113, 15);
            this.ChkPageNumber.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ChkPageNumber.TabIndex = 12;
            this.ChkPageNumber.Text = "إظهار رقم الصفحة";
            this.ChkPageNumber.TextColor = System.Drawing.Color.SteelBlue;
            // 
            // ChkGreg
            // 
            this.ChkGreg.AutoSize = true;
            this.ChkGreg.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.ChkGreg.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ChkGreg.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.ChkGreg.Location = new System.Drawing.Point(501, 20);
            this.ChkGreg.Name = "ChkGreg";
            this.ChkGreg.Size = new System.Drawing.Size(129, 15);
            this.ChkGreg.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ChkGreg.TabIndex = 11;
            this.ChkGreg.Text = "إظهار التاريخ الميلادي";
            this.ChkGreg.TextColor = System.Drawing.Color.SteelBlue;
            // 
            // ChkHijri
            // 
            this.ChkHijri.AutoSize = true;
            this.ChkHijri.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.ChkHijri.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ChkHijri.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.ChkHijri.Location = new System.Drawing.Point(847, 20);
            this.ChkHijri.Name = "ChkHijri";
            this.ChkHijri.Size = new System.Drawing.Size(124, 15);
            this.ChkHijri.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ChkHijri.TabIndex = 10;
            this.ChkHijri.Text = "إظهار التاريخ الهجري";
            this.ChkHijri.TextColor = System.Drawing.Color.SteelBlue;
            // 
            // ChkHead
            // 
            this.ChkHead.AutoSize = true;
            this.ChkHead.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.ChkHead.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ChkHead.Location = new System.Drawing.Point(3, 20);
            this.ChkHead.Name = "ChkHead";
            this.ChkHead.Size = new System.Drawing.Size(138, 15);
            this.ChkHead.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ChkHead.TabIndex = 9;
            this.ChkHead.Text = "إظهار الترويسة في التقارير";
            this.ChkHead.TextColor = System.Drawing.Color.Red;
            // 
            // groupPanel_Banner
            // 
            this.groupPanel_Banner.BackColor = System.Drawing.Color.Gainsboro;
            this.groupPanel_Banner.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel_Banner.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel_Banner.Controls.Add(this.PicItemImg);
            this.groupPanel_Banner.Controls.Add(this.button_ClearPic);
            this.groupPanel_Banner.Controls.Add(this.button_EnterImg);
            this.groupPanel_Banner.Location = new System.Drawing.Point(439, 3);
            this.groupPanel_Banner.Name = "groupPanel_Banner";
            this.groupPanel_Banner.Size = new System.Drawing.Size(168, 153);
            // 
            // 
            // 
            this.groupPanel_Banner.Style.BackColor = System.Drawing.Color.Gainsboro;
            this.groupPanel_Banner.Style.BackColor2 = System.Drawing.Color.Gainsboro;
            this.groupPanel_Banner.Style.BackColorGradientAngle = 90;
            this.groupPanel_Banner.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel_Banner.Style.BorderBottomWidth = 1;
            this.groupPanel_Banner.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel_Banner.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel_Banner.Style.BorderLeftWidth = 1;
            this.groupPanel_Banner.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel_Banner.Style.BorderRightWidth = 1;
            this.groupPanel_Banner.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel_Banner.Style.BorderTopWidth = 1;
            this.groupPanel_Banner.Style.CornerDiameter = 4;
            this.groupPanel_Banner.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel_Banner.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel_Banner.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel_Banner.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel_Banner.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel_Banner.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel_Banner.TabIndex = 103;
            this.groupPanel_Banner.Text = "Banner";
            // 
            // PicItemImg
            // 
            this.PicItemImg.BackColor = System.Drawing.Color.Transparent;
            this.PicItemImg.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PicItemImg.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.PicItemImg.Location = new System.Drawing.Point(4, 10);
            this.PicItemImg.Name = "PicItemImg";
            this.PicItemImg.Size = new System.Drawing.Size(134, 120);
            this.PicItemImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PicItemImg.TabIndex = 928;
            this.PicItemImg.TabStop = false;
            // 
            // button_ClearPic
            // 
            this.button_ClearPic.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_ClearPic.Checked = true;
            this.button_ClearPic.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_ClearPic.Location = new System.Drawing.Point(142, 9);
            this.button_ClearPic.Name = "button_ClearPic";
            this.button_ClearPic.Size = new System.Drawing.Size(19, 20);
            this.button_ClearPic.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_ClearPic.Symbol = "";
            this.button_ClearPic.SymbolSize = 11F;
            this.button_ClearPic.TabIndex = 926;
            this.button_ClearPic.TextColor = System.Drawing.Color.SteelBlue;
            this.button_ClearPic.Tooltip = "إزالة الصورة";
            this.button_ClearPic.Click += new System.EventHandler(this.button_ClearPic_Click);
            // 
            // button_EnterImg
            // 
            this.button_EnterImg.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_EnterImg.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_EnterImg.Location = new System.Drawing.Point(142, 31);
            this.button_EnterImg.Name = "button_EnterImg";
            this.button_EnterImg.Size = new System.Drawing.Size(19, 20);
            this.button_EnterImg.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_EnterImg.Symbol = "";
            this.button_EnterImg.SymbolSize = 11F;
            this.button_EnterImg.TabIndex = 927;
            this.button_EnterImg.TextColor = System.Drawing.Color.SteelBlue;
            this.button_EnterImg.Tooltip = "إضافة صورة للصنف";
            this.button_EnterImg.Click += new System.EventHandler(this.button_EnterImg_Click);
            // 
            // groupPanel3
            // 
            this.groupPanel3.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel3.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel3.Controls.Add(this.label2);
            this.groupPanel3.Controls.Add(this.txtHeadingR2);
            this.groupPanel3.Controls.Add(this.label1);
            this.groupPanel3.Controls.Add(this.txtHeadingR1);
            this.groupPanel3.Controls.Add(this.txtHeadingR4);
            this.groupPanel3.Controls.Add(this.txtHeadingR3);
            this.groupPanel3.Location = new System.Drawing.Point(611, 14);
            this.groupPanel3.Name = "groupPanel3";
            this.groupPanel3.Size = new System.Drawing.Size(390, 142);
            // 
            // 
            // 
            this.groupPanel3.Style.BackColor = System.Drawing.Color.Gainsboro;
            this.groupPanel3.Style.BackColor2 = System.Drawing.Color.Gainsboro;
            this.groupPanel3.Style.BackColorGradientAngle = 90;
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
            this.groupPanel3.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Far;
            this.groupPanel3.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            // 
            // 
            // 
            this.groupPanel3.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel3.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel3.TabIndex = 972;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(303, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 981;
            this.label2.Text = "العنوان العربي :";
            // 
            // txtHeadingR2
            // 
            this.txtHeadingR2.BackColor = System.Drawing.SystemColors.Control;
            // 
            // 
            // 
            this.txtHeadingR2.Border.Class = "TextBoxBorder";
            this.txtHeadingR2.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtHeadingR2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtHeadingR2.Location = new System.Drawing.Point(11, 37);
            this.txtHeadingR2.Name = "txtHeadingR2";
            this.netResize1.SetResizeTextBoxMultiline(this.txtHeadingR2, false);
            this.txtHeadingR2.Size = new System.Drawing.Size(292, 20);
            this.txtHeadingR2.TabIndex = 973;
            this.txtHeadingR2.Tag = "rTrwes2";
            this.txtHeadingR2.Click += new System.EventHandler(this.txtHeadingR2_Click);
            this.txtHeadingR2.Enter += new System.EventHandler(this.textbox_Arb_Des_Enter);
            this.txtHeadingR2.Leave += new System.EventHandler(this.textbox_Arb_Des_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(303, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 980;
            this.label1.Text = "الإسم العربي :";
            // 
            // txtHeadingR1
            // 
            this.txtHeadingR1.BackColor = System.Drawing.SystemColors.Control;
            // 
            // 
            // 
            this.txtHeadingR1.Border.Class = "TextBoxBorder";
            this.txtHeadingR1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtHeadingR1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtHeadingR1.Location = new System.Drawing.Point(11, 4);
            this.txtHeadingR1.Name = "txtHeadingR1";
            this.netResize1.SetResizeTextBoxMultiline(this.txtHeadingR1, false);
            this.txtHeadingR1.Size = new System.Drawing.Size(292, 20);
            this.txtHeadingR1.TabIndex = 972;
            this.txtHeadingR1.Tag = "rTrwes1";
            this.txtHeadingR1.Click += new System.EventHandler(this.txtHeadingR1_Click);
            this.txtHeadingR1.Enter += new System.EventHandler(this.textbox_Arb_Des_Enter);
            this.txtHeadingR1.Leave += new System.EventHandler(this.textbox_Arb_Des_Enter);
            // 
            // txtHeadingR4
            // 
            this.txtHeadingR4.BackColor = System.Drawing.SystemColors.Control;
            // 
            // 
            // 
            this.txtHeadingR4.Border.Class = "TextBoxBorder";
            this.txtHeadingR4.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtHeadingR4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtHeadingR4.Location = new System.Drawing.Point(11, 103);
            this.txtHeadingR4.Name = "txtHeadingR4";
            this.netResize1.SetResizeTextBoxMultiline(this.txtHeadingR4, false);
            this.txtHeadingR4.Size = new System.Drawing.Size(374, 20);
            this.txtHeadingR4.TabIndex = 975;
            this.txtHeadingR4.Tag = "rTrwes4";
            this.txtHeadingR4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtHeadingR4.Click += new System.EventHandler(this.txtHeadingR4_Click);
            // 
            // txtHeadingR3
            // 
            this.txtHeadingR3.BackColor = System.Drawing.SystemColors.Control;
            // 
            // 
            // 
            this.txtHeadingR3.Border.Class = "TextBoxBorder";
            this.txtHeadingR3.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtHeadingR3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtHeadingR3.Location = new System.Drawing.Point(11, 70);
            this.txtHeadingR3.Name = "txtHeadingR3";
            this.netResize1.SetResizeTextBoxMultiline(this.txtHeadingR3, false);
            this.txtHeadingR3.Size = new System.Drawing.Size(374, 20);
            this.txtHeadingR3.TabIndex = 974;
            this.txtHeadingR3.Tag = "rTrwes3";
            this.txtHeadingR3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtHeadingR3.Click += new System.EventHandler(this.txtHeadingR3_Click);
            // 
            // superTabItem_Banner
            // 
            this.superTabItem_Banner.AttachedControl = this.superTabControlPanel1;
            this.superTabItem_Banner.GlobalItem = false;
            this.superTabItem_Banner.Name = "superTabItem_Banner";
            this.superTabItem_Banner.Text = "بيانات الشركه";
            // 
            // superTabControlPanel3
            // 
            this.superTabControlPanel3.Controls.Add(this.expandablePanel_AutoAcc);
            this.superTabControlPanel3.Controls.Add(this.c1FlexGrid1);
            this.superTabControlPanel3.Controls.Add(this.groupbox_AutoAcc);
            this.superTabControlPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel3.Location = new System.Drawing.Point(0, 0);
            this.superTabControlPanel3.Name = "superTabControlPanel3";
            superTabLinearGradientColorTable4.Colors = new System.Drawing.Color[] {
        System.Drawing.Color.Gainsboro};
            superTabPanelItemColorTable4.Background = superTabLinearGradientColorTable4;
            superTabPanelColorTable4.Default = superTabPanelItemColorTable4;
            this.superTabControlPanel3.PanelColor = superTabPanelColorTable4;
            this.superTabControlPanel3.Size = new System.Drawing.Size(1069, 514);
            this.superTabControlPanel3.TabIndex = 0;
            this.superTabControlPanel3.TabItem = this.superTabItem_Acc;
            // 
            // expandablePanel_AutoAcc
            // 
            this.expandablePanel_AutoAcc.CanvasColor = System.Drawing.SystemColors.Control;
            this.expandablePanel_AutoAcc.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.expandablePanel_AutoAcc.Controls.Add(this.FlxInv);
            this.expandablePanel_AutoAcc.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.expandablePanel_AutoAcc.ExpandButtonVisible = false;
            this.expandablePanel_AutoAcc.Expanded = false;
            this.expandablePanel_AutoAcc.ExpandedBounds = new System.Drawing.Rectangle(0, 0, 691, 474);
            this.expandablePanel_AutoAcc.HideControlsWhenCollapsed = true;
            this.expandablePanel_AutoAcc.Location = new System.Drawing.Point(0, 488);
            this.expandablePanel_AutoAcc.Name = "expandablePanel_AutoAcc";
            this.expandablePanel_AutoAcc.Size = new System.Drawing.Size(1069, 26);
            this.expandablePanel_AutoAcc.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanel_AutoAcc.Style.BackColor1.Color = System.Drawing.Color.Gainsboro;
            this.expandablePanel_AutoAcc.Style.BackColor2.Color = System.Drawing.Color.Gainsboro;
            this.expandablePanel_AutoAcc.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.expandablePanel_AutoAcc.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandablePanel_AutoAcc.Style.GradientAngle = 90;
            this.expandablePanel_AutoAcc.TabIndex = 872;
            this.expandablePanel_AutoAcc.TitleStyle.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanel_AutoAcc.TitleStyle.BackColor1.Color = System.Drawing.Color.Silver;
            this.expandablePanel_AutoAcc.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            this.expandablePanel_AutoAcc.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandablePanel_AutoAcc.TitleStyle.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.expandablePanel_AutoAcc.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.expandablePanel_AutoAcc.TitleStyle.GradientAngle = 90;
            this.expandablePanel_AutoAcc.TitleText = "Title Bar";
            // 
            // FlxInv
            // 
            this.FlxInv.ColumnInfo = resources.GetString("FlxInv.ColumnInfo");
            this.FlxInv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FlxInv.Font = new System.Drawing.Font("Tahoma", 8F);
            this.FlxInv.Location = new System.Drawing.Point(0, 26);
            this.FlxInv.Name = "FlxInv";
            this.FlxInv.Rows.Count = 1;
            this.FlxInv.Rows.DefaultSize = 19;
            this.FlxInv.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.FlxInv.Size = new System.Drawing.Size(1069, 0);
            this.FlxInv.StyleInfo = resources.GetString("FlxInv.StyleInfo");
            this.FlxInv.TabIndex = 22;
            this.FlxInv.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2007Black;
            this.FlxInv.Click += new System.EventHandler(this.c1FlexGrid1_Click);
            this.FlxInv.DoubleClick += new System.EventHandler(this.FlxInv_DoubleClick);
            // 
            // c1FlexGrid1
            // 
            this.c1FlexGrid1.ColumnInfo = resources.GetString("c1FlexGrid1.ColumnInfo");
            this.c1FlexGrid1.Font = new System.Drawing.Font("Tahoma", 8F);
            this.c1FlexGrid1.Location = new System.Drawing.Point(6, 8);
            this.c1FlexGrid1.Name = "c1FlexGrid1";
            this.c1FlexGrid1.Rows.Count = 37;
            this.c1FlexGrid1.Rows.DefaultSize = 19;
            this.c1FlexGrid1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.c1FlexGrid1.Size = new System.Drawing.Size(1004, 370);
            this.c1FlexGrid1.StyleInfo = resources.GetString("c1FlexGrid1.StyleInfo");
            this.c1FlexGrid1.TabIndex = 21;
            this.c1FlexGrid1.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2007Black;
            this.c1FlexGrid1.BeforeEdit += new C1.Win.C1FlexGrid.RowColEventHandler(this.c1FlexGrid1_BeforeEdit);
            this.c1FlexGrid1.Click += new System.EventHandler(this.c1FlexGrid1_Click);
            this.c1FlexGrid1.DoubleClick += new System.EventHandler(this.c1FlexGrid1_DoubleClick);
            // 
            // groupbox_AutoAcc
            // 
            this.groupbox_AutoAcc.BackColor = System.Drawing.Color.Transparent;
            this.groupbox_AutoAcc.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupbox_AutoAcc.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupbox_AutoAcc.Controls.Add(this.label12);
            this.groupbox_AutoAcc.Controls.Add(this.label11);
            this.groupbox_AutoAcc.Controls.Add(this.label13);
            this.groupbox_AutoAcc.Controls.Add(this.txtProfits);
            this.groupbox_AutoAcc.Controls.Add(this.label10);
            this.groupbox_AutoAcc.Controls.Add(this.txtFirstInventory);
            this.groupbox_AutoAcc.Controls.Add(this.txtBoxAccount);
            this.groupbox_AutoAcc.Controls.Add(this.txtLastInventory);
            this.groupbox_AutoAcc.Font = new System.Drawing.Font("Tahoma", 8F);
            this.groupbox_AutoAcc.Location = new System.Drawing.Point(16, 384);
            this.groupbox_AutoAcc.Name = "groupbox_AutoAcc";
            this.groupbox_AutoAcc.Size = new System.Drawing.Size(985, 71);
            // 
            // 
            // 
            this.groupbox_AutoAcc.Style.BackColor = System.Drawing.Color.Gainsboro;
            this.groupbox_AutoAcc.Style.BackColor2 = System.Drawing.Color.Gainsboro;
            this.groupbox_AutoAcc.Style.BackColorGradientAngle = 90;
            this.groupbox_AutoAcc.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupbox_AutoAcc.Style.BorderBottomWidth = 1;
            this.groupbox_AutoAcc.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupbox_AutoAcc.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupbox_AutoAcc.Style.BorderLeftWidth = 1;
            this.groupbox_AutoAcc.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupbox_AutoAcc.Style.BorderRightWidth = 1;
            this.groupbox_AutoAcc.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupbox_AutoAcc.Style.BorderTopWidth = 1;
            this.groupbox_AutoAcc.Style.CornerDiameter = 4;
            this.groupbox_AutoAcc.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupbox_AutoAcc.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupbox_AutoAcc.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupbox_AutoAcc.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupbox_AutoAcc.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupbox_AutoAcc.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupbox_AutoAcc.TabIndex = 881;
            this.groupbox_AutoAcc.Text = "الحسابات التلقائية";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label12.Location = new System.Drawing.Point(340, 6);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(102, 13);
            this.label12.TabIndex = 875;
            this.label12.Text = "حساب الصنـــــــدوق";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label11.Location = new System.Drawing.Point(523, 6);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(114, 13);
            this.label11.TabIndex = 874;
            this.label11.Text = "حساب بضاعة أخر المدة";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label13.Location = new System.Drawing.Point(146, 6);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(112, 13);
            this.label13.TabIndex = 873;
            this.label13.Text = "حساب الأرباح والخسائر";
            // 
            // txtProfits
            // 
            this.txtProfits.BackColor = System.Drawing.SystemColors.Control;
            // 
            // 
            // 
            this.txtProfits.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtProfits.ButtonCustom.Visible = true;
            this.txtProfits.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtProfits.Location = new System.Drawing.Point(134, 28);
            this.txtProfits.Name = "txtProfits";
            this.txtProfits.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtProfits, false);
            this.txtProfits.Size = new System.Drawing.Size(137, 14);
            this.txtProfits.TabIndex = 880;
            this.txtProfits.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label10.Location = new System.Drawing.Point(712, 6);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(114, 13);
            this.label10.TabIndex = 876;
            this.label10.Text = "حساب بضاعة أول المدة";
            // 
            // txtFirstInventory
            // 
            this.txtFirstInventory.BackColor = System.Drawing.SystemColors.Control;
            // 
            // 
            // 
            this.txtFirstInventory.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtFirstInventory.ButtonCustom.Visible = true;
            this.txtFirstInventory.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtFirstInventory.Location = new System.Drawing.Point(701, 28);
            this.txtFirstInventory.Name = "txtFirstInventory";
            this.txtFirstInventory.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtFirstInventory, false);
            this.txtFirstInventory.Size = new System.Drawing.Size(137, 14);
            this.txtFirstInventory.TabIndex = 877;
            this.txtFirstInventory.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtBoxAccount
            // 
            this.txtBoxAccount.BackColor = System.Drawing.SystemColors.Control;
            // 
            // 
            // 
            this.txtBoxAccount.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtBoxAccount.ButtonCustom.Visible = true;
            this.txtBoxAccount.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtBoxAccount.Location = new System.Drawing.Point(323, 28);
            this.txtBoxAccount.Name = "txtBoxAccount";
            this.txtBoxAccount.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtBoxAccount, false);
            this.txtBoxAccount.Size = new System.Drawing.Size(137, 14);
            this.txtBoxAccount.TabIndex = 879;
            this.txtBoxAccount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtLastInventory
            // 
            this.txtLastInventory.BackColor = System.Drawing.SystemColors.Control;
            // 
            // 
            // 
            this.txtLastInventory.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtLastInventory.ButtonCustom.Visible = true;
            this.txtLastInventory.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtLastInventory.Location = new System.Drawing.Point(512, 28);
            this.txtLastInventory.Name = "txtLastInventory";
            this.txtLastInventory.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtLastInventory, false);
            this.txtLastInventory.Size = new System.Drawing.Size(137, 14);
            this.txtLastInventory.TabIndex = 878;
            this.txtLastInventory.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // superTabItem_Acc
            // 
            this.superTabItem_Acc.AttachedControl = this.superTabControlPanel3;
            this.superTabItem_Acc.GlobalItem = false;
            this.superTabItem_Acc.Name = "superTabItem_Acc";
            this.superTabItem_Acc.Text = "اعدادات الحسابات";
            // 
            // superTabControlPanel15
            // 
            this.superTabControlPanel15.Controls.Add(this.groupPanel12);
            this.superTabControlPanel15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel15.Location = new System.Drawing.Point(0, 0);
            this.superTabControlPanel15.Name = "superTabControlPanel15";
            this.superTabControlPanel15.Size = new System.Drawing.Size(1069, 514);
            this.superTabControlPanel15.TabIndex = 0;
            this.superTabControlPanel15.TabItem = this.superTabItem7;
            // 
            // groupPanel12
            // 
            this.groupPanel12.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel12.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel12.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel12.Controls.Add(this.c1FlexGrid1Bankopp);
            this.groupPanel12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel12.Font = new System.Drawing.Font("Tahoma", 8F);
            this.groupPanel12.Location = new System.Drawing.Point(0, 0);
            this.groupPanel12.Name = "groupPanel12";
            this.groupPanel12.Size = new System.Drawing.Size(1069, 514);
            // 
            // 
            // 
            this.groupPanel12.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel12.Style.BackColorGradientAngle = 90;
            this.groupPanel12.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
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
            this.groupPanel12.TabIndex = 881;
            this.groupPanel12.Text = "العمولات البنكية";
            // 
            // c1FlexGrid1Bankopp
            // 
            this.c1FlexGrid1Bankopp.ColumnInfo = resources.GetString("c1FlexGrid1Bankopp.ColumnInfo");
            this.c1FlexGrid1Bankopp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.c1FlexGrid1Bankopp.Font = new System.Drawing.Font("Tahoma", 8F);
            this.c1FlexGrid1Bankopp.Location = new System.Drawing.Point(0, 0);
            this.c1FlexGrid1Bankopp.Name = "c1FlexGrid1Bankopp";
            this.c1FlexGrid1Bankopp.Rows.Count = 15;
            this.c1FlexGrid1Bankopp.Rows.DefaultSize = 19;
            this.c1FlexGrid1Bankopp.Size = new System.Drawing.Size(1063, 493);
            this.c1FlexGrid1Bankopp.StyleInfo = resources.GetString("c1FlexGrid1Bankopp.StyleInfo");
            this.c1FlexGrid1Bankopp.TabIndex = 24;
            this.c1FlexGrid1Bankopp.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2007Black;
            this.c1FlexGrid1Bankopp.Click += new System.EventHandler(this.Button_Edit_Click);
            // 
            // superTabItem7
            // 
            this.superTabItem7.AttachedControl = this.superTabControlPanel15;
            this.superTabItem7.GlobalItem = false;
            this.superTabItem7.Name = "superTabItem7";
            this.superTabItem7.Text = "العمولات البنكيه";
            // 
            // superTabControlPanel6
            // 
            this.superTabControlPanel6.Controls.Add(this.expandablePanel_Alarm);
            this.superTabControlPanel6.Controls.Add(this.panel11);
            this.superTabControlPanel6.Controls.Add(this.groupPanel7);
            this.superTabControlPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel6.Location = new System.Drawing.Point(0, 31);
            this.superTabControlPanel6.Name = "superTabControlPanel6";
            this.superTabControlPanel6.Size = new System.Drawing.Size(1069, 483);
            this.superTabControlPanel6.TabIndex = 0;
            this.superTabControlPanel6.TabItem = this.superTabItem_Employee;
            // 
            // expandablePanel_Alarm
            // 
            this.expandablePanel_Alarm.CanvasColor = System.Drawing.SystemColors.Control;
            this.expandablePanel_Alarm.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.expandablePanel_Alarm.Controls.Add(this.groupPanel9);
            this.expandablePanel_Alarm.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.expandablePanel_Alarm.Expanded = false;
            this.expandablePanel_Alarm.ExpandedBounds = new System.Drawing.Rectangle(0, 12, 1013, 471);
            this.expandablePanel_Alarm.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.expandablePanel_Alarm.Location = new System.Drawing.Point(0, 457);
            this.expandablePanel_Alarm.Name = "expandablePanel_Alarm";
            this.expandablePanel_Alarm.Size = new System.Drawing.Size(1069, 26);
            this.expandablePanel_Alarm.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanel_Alarm.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.expandablePanel_Alarm.Style.BackgroundImagePosition = DevComponents.DotNetBar.eBackgroundImagePosition.Tile;
            this.expandablePanel_Alarm.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandablePanel_Alarm.Style.GradientAngle = 90;
            this.expandablePanel_Alarm.TabIndex = 969;
            this.expandablePanel_Alarm.TitleStyle.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanel_Alarm.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandablePanel_Alarm.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            this.expandablePanel_Alarm.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandablePanel_Alarm.TitleStyle.ForeColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.expandablePanel_Alarm.TitleStyle.GradientAngle = 90;
            this.expandablePanel_Alarm.TitleText = "التنبيهــــــات";
            // 
            // groupPanel9
            // 
            this.groupPanel9.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel9.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel9.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel9.Controls.Add(this.label50);
            this.groupPanel9.Controls.Add(this.integerInput_AlarmEndVactionBefore);
            this.groupPanel9.Controls.Add(this.checkBox_IsAlarmEndVaction);
            this.groupPanel9.Controls.Add(this.label49);
            this.groupPanel9.Controls.Add(this.integerInput_AlarmVisaGoBack);
            this.groupPanel9.Controls.Add(this.checkBox_IsAlarmVisaGoBack);
            this.groupPanel9.Controls.Add(this.label46);
            this.groupPanel9.Controls.Add(this.integerInput_AlarmCarDocBefore);
            this.groupPanel9.Controls.Add(this.checkBox_IsAlarmCarDoc);
            this.groupPanel9.Controls.Add(this.label45);
            this.groupPanel9.Controls.Add(this.integerInput_AlarmSecretariatsBefore);
            this.groupPanel9.Controls.Add(this.checkBox_IsAlarmSecretariatsDoc);
            this.groupPanel9.Controls.Add(this.label44);
            this.groupPanel9.Controls.Add(this.integerInput_AlarmFamilyPassportBefore);
            this.groupPanel9.Controls.Add(this.checkBox_IsAlarmFamilyPassport);
            this.groupPanel9.Controls.Add(this.label43);
            this.groupPanel9.Controls.Add(this.integerInput_AlarmEmpContractBefore);
            this.groupPanel9.Controls.Add(this.checkBox_IsAlarmEmpContract);
            this.groupPanel9.Controls.Add(this.label42);
            this.groupPanel9.Controls.Add(this.integerInput_AlarmEmpDocBefore);
            this.groupPanel9.Controls.Add(this.checkBox_IsAlarmEmpDoc);
            this.groupPanel9.Controls.Add(this.label41);
            this.groupPanel9.Controls.Add(this.integerInput_AlarmGuarantorDocBefore);
            this.groupPanel9.Controls.Add(this.checkBox_IsAlarmGuarantorDoc);
            this.groupPanel9.Controls.Add(this.label40);
            this.groupPanel9.Controls.Add(this.integerInput_AlarmDeptsBefore);
            this.groupPanel9.Controls.Add(this.checkBox_IsAlarmDepts);
            this.groupPanel9.Location = new System.Drawing.Point(4, 28);
            this.groupPanel9.Name = "groupPanel9";
            this.groupPanel9.Size = new System.Drawing.Size(1006, 440);
            // 
            // 
            // 
            this.groupPanel9.Style.BackColor2 = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupPanel9.Style.BackColorGradientAngle = 90;
            this.groupPanel9.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
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
            this.groupPanel9.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Far;
            this.groupPanel9.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            // 
            // 
            // 
            this.groupPanel9.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel9.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel9.TabIndex = 1009;
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.BackColor = System.Drawing.Color.Transparent;
            this.label50.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label50.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label50.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label50.Location = new System.Drawing.Point(488, 280);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(33, 13);
            this.label50.TabIndex = 1035;
            this.label50.Text = "يومـــاُ";
            // 
            // integerInput_AlarmEndVactionBefore
            // 
            this.integerInput_AlarmEndVactionBefore.AllowEmptyState = false;
            // 
            // 
            // 
            this.integerInput_AlarmEndVactionBefore.BackgroundStyle.BackColor = System.Drawing.Color.SlateGray;
            this.integerInput_AlarmEndVactionBefore.BackgroundStyle.Class = "DateTimeInputBackground";
            this.integerInput_AlarmEndVactionBefore.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.integerInput_AlarmEndVactionBefore.ButtonClear.Visible = true;
            this.integerInput_AlarmEndVactionBefore.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.integerInput_AlarmEndVactionBefore.DisplayFormat = "0";
            this.integerInput_AlarmEndVactionBefore.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.integerInput_AlarmEndVactionBefore.ForeColor = System.Drawing.Color.White;
            this.integerInput_AlarmEndVactionBefore.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.integerInput_AlarmEndVactionBefore.Location = new System.Drawing.Point(525, 276);
            this.integerInput_AlarmEndVactionBefore.MinValue = 0;
            this.integerInput_AlarmEndVactionBefore.Name = "integerInput_AlarmEndVactionBefore";
            this.integerInput_AlarmEndVactionBefore.ShowUpDown = true;
            this.integerInput_AlarmEndVactionBefore.Size = new System.Drawing.Size(83, 21);
            this.integerInput_AlarmEndVactionBefore.TabIndex = 1033;
            // 
            // checkBox_IsAlarmEndVaction
            // 
            this.checkBox_IsAlarmEndVaction.AutoSize = true;
            this.checkBox_IsAlarmEndVaction.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.checkBox_IsAlarmEndVaction.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBox_IsAlarmEndVaction.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.checkBox_IsAlarmEndVaction.Location = new System.Drawing.Point(618, 278);
            this.checkBox_IsAlarmEndVaction.Name = "checkBox_IsAlarmEndVaction";
            this.checkBox_IsAlarmEndVaction.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBox_IsAlarmEndVaction.Size = new System.Drawing.Size(147, 16);
            this.checkBox_IsAlarmEndVaction.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBox_IsAlarmEndVaction.TabIndex = 1034;
            this.checkBox_IsAlarmEndVaction.Text = "تنبيه عن انتهاء <font color=\"#BA1419\">الأجازة </font>قبل";
            this.checkBox_IsAlarmEndVaction.CheckedChanged += new System.EventHandler(this.checkBox_IsAlarmEndVaction_CheckedChanged);
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.BackColor = System.Drawing.Color.Transparent;
            this.label49.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label49.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label49.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label49.Location = new System.Drawing.Point(447, 362);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(33, 13);
            this.label49.TabIndex = 1032;
            this.label49.Text = "يومـــاُ";
            // 
            // integerInput_AlarmVisaGoBack
            // 
            this.integerInput_AlarmVisaGoBack.AllowEmptyState = false;
            // 
            // 
            // 
            this.integerInput_AlarmVisaGoBack.BackgroundStyle.BackColor = System.Drawing.Color.SlateGray;
            this.integerInput_AlarmVisaGoBack.BackgroundStyle.Class = "DateTimeInputBackground";
            this.integerInput_AlarmVisaGoBack.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.integerInput_AlarmVisaGoBack.ButtonClear.Visible = true;
            this.integerInput_AlarmVisaGoBack.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.integerInput_AlarmVisaGoBack.DisplayFormat = "0";
            this.integerInput_AlarmVisaGoBack.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.integerInput_AlarmVisaGoBack.ForeColor = System.Drawing.Color.White;
            this.integerInput_AlarmVisaGoBack.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.integerInput_AlarmVisaGoBack.Location = new System.Drawing.Point(486, 358);
            this.integerInput_AlarmVisaGoBack.MinValue = 0;
            this.integerInput_AlarmVisaGoBack.Name = "integerInput_AlarmVisaGoBack";
            this.integerInput_AlarmVisaGoBack.ShowUpDown = true;
            this.integerInput_AlarmVisaGoBack.Size = new System.Drawing.Size(83, 21);
            this.integerInput_AlarmVisaGoBack.TabIndex = 1030;
            // 
            // checkBox_IsAlarmVisaGoBack
            // 
            this.checkBox_IsAlarmVisaGoBack.AutoSize = true;
            this.checkBox_IsAlarmVisaGoBack.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.checkBox_IsAlarmVisaGoBack.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBox_IsAlarmVisaGoBack.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.checkBox_IsAlarmVisaGoBack.Location = new System.Drawing.Point(582, 360);
            this.checkBox_IsAlarmVisaGoBack.Name = "checkBox_IsAlarmVisaGoBack";
            this.checkBox_IsAlarmVisaGoBack.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBox_IsAlarmVisaGoBack.Size = new System.Drawing.Size(183, 16);
            this.checkBox_IsAlarmVisaGoBack.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBox_IsAlarmVisaGoBack.TabIndex = 1031;
            this.checkBox_IsAlarmVisaGoBack.Text = "تنبيه عن وثائق <font color=\"#BA1419\">الخروج والعودة </font>قبل";
            this.checkBox_IsAlarmVisaGoBack.CheckedChanged += new System.EventHandler(this.checkBox_IsAlarmVisaGoBack_CheckedChanged);
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.BackColor = System.Drawing.Color.Transparent;
            this.label46.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label46.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label46.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label46.Location = new System.Drawing.Point(471, 321);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(33, 13);
            this.label46.TabIndex = 1029;
            this.label46.Text = "يومـــاُ";
            // 
            // integerInput_AlarmCarDocBefore
            // 
            this.integerInput_AlarmCarDocBefore.AllowEmptyState = false;
            // 
            // 
            // 
            this.integerInput_AlarmCarDocBefore.BackgroundStyle.BackColor = System.Drawing.Color.SlateGray;
            this.integerInput_AlarmCarDocBefore.BackgroundStyle.Class = "DateTimeInputBackground";
            this.integerInput_AlarmCarDocBefore.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.integerInput_AlarmCarDocBefore.ButtonClear.Visible = true;
            this.integerInput_AlarmCarDocBefore.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.integerInput_AlarmCarDocBefore.DisplayFormat = "0";
            this.integerInput_AlarmCarDocBefore.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.integerInput_AlarmCarDocBefore.ForeColor = System.Drawing.Color.White;
            this.integerInput_AlarmCarDocBefore.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.integerInput_AlarmCarDocBefore.Location = new System.Drawing.Point(510, 317);
            this.integerInput_AlarmCarDocBefore.MinValue = 0;
            this.integerInput_AlarmCarDocBefore.Name = "integerInput_AlarmCarDocBefore";
            this.integerInput_AlarmCarDocBefore.ShowUpDown = true;
            this.integerInput_AlarmCarDocBefore.Size = new System.Drawing.Size(83, 21);
            this.integerInput_AlarmCarDocBefore.TabIndex = 1027;
            // 
            // checkBox_IsAlarmCarDoc
            // 
            this.checkBox_IsAlarmCarDoc.AutoSize = true;
            this.checkBox_IsAlarmCarDoc.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.checkBox_IsAlarmCarDoc.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBox_IsAlarmCarDoc.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.checkBox_IsAlarmCarDoc.Location = new System.Drawing.Point(607, 319);
            this.checkBox_IsAlarmCarDoc.Name = "checkBox_IsAlarmCarDoc";
            this.checkBox_IsAlarmCarDoc.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBox_IsAlarmCarDoc.Size = new System.Drawing.Size(158, 16);
            this.checkBox_IsAlarmCarDoc.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBox_IsAlarmCarDoc.TabIndex = 1028;
            this.checkBox_IsAlarmCarDoc.Text = "تنبيه عن وثائق <font color=\"#BA1419\">السيارات </font>قبل";
            this.checkBox_IsAlarmCarDoc.CheckedChanged += new System.EventHandler(this.checkBox_IsAlarmCarDoc_CheckedChanged);
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.BackColor = System.Drawing.Color.Transparent;
            this.label45.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label45.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label45.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label45.Location = new System.Drawing.Point(486, 239);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(33, 13);
            this.label45.TabIndex = 1026;
            this.label45.Text = "يومـــاُ";
            // 
            // integerInput_AlarmSecretariatsBefore
            // 
            this.integerInput_AlarmSecretariatsBefore.AllowEmptyState = false;
            // 
            // 
            // 
            this.integerInput_AlarmSecretariatsBefore.BackgroundStyle.BackColor = System.Drawing.Color.SlateGray;
            this.integerInput_AlarmSecretariatsBefore.BackgroundStyle.Class = "DateTimeInputBackground";
            this.integerInput_AlarmSecretariatsBefore.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.integerInput_AlarmSecretariatsBefore.ButtonClear.Visible = true;
            this.integerInput_AlarmSecretariatsBefore.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.integerInput_AlarmSecretariatsBefore.DisplayFormat = "0";
            this.integerInput_AlarmSecretariatsBefore.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.integerInput_AlarmSecretariatsBefore.ForeColor = System.Drawing.Color.White;
            this.integerInput_AlarmSecretariatsBefore.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.integerInput_AlarmSecretariatsBefore.Location = new System.Drawing.Point(525, 235);
            this.integerInput_AlarmSecretariatsBefore.MinValue = 0;
            this.integerInput_AlarmSecretariatsBefore.Name = "integerInput_AlarmSecretariatsBefore";
            this.integerInput_AlarmSecretariatsBefore.ShowUpDown = true;
            this.integerInput_AlarmSecretariatsBefore.Size = new System.Drawing.Size(83, 21);
            this.integerInput_AlarmSecretariatsBefore.TabIndex = 1024;
            // 
            // checkBox_IsAlarmSecretariatsDoc
            // 
            this.checkBox_IsAlarmSecretariatsDoc.AutoSize = true;
            this.checkBox_IsAlarmSecretariatsDoc.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.checkBox_IsAlarmSecretariatsDoc.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBox_IsAlarmSecretariatsDoc.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.checkBox_IsAlarmSecretariatsDoc.Location = new System.Drawing.Point(616, 237);
            this.checkBox_IsAlarmSecretariatsDoc.Name = "checkBox_IsAlarmSecretariatsDoc";
            this.checkBox_IsAlarmSecretariatsDoc.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBox_IsAlarmSecretariatsDoc.Size = new System.Drawing.Size(149, 16);
            this.checkBox_IsAlarmSecretariatsDoc.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBox_IsAlarmSecretariatsDoc.TabIndex = 1025;
            this.checkBox_IsAlarmSecretariatsDoc.Text = "تنبيه عن وثائق <font color=\"#BA1419\">العهـــد </font>قبل";
            this.checkBox_IsAlarmSecretariatsDoc.CheckedChanged += new System.EventHandler(this.checkBox_IsAlarmSecretariatsDoc_CheckedChanged);
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.BackColor = System.Drawing.Color.Transparent;
            this.label44.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label44.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label44.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label44.Location = new System.Drawing.Point(471, 198);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(33, 13);
            this.label44.TabIndex = 1023;
            this.label44.Text = "يومـــاُ";
            // 
            // integerInput_AlarmFamilyPassportBefore
            // 
            this.integerInput_AlarmFamilyPassportBefore.AllowEmptyState = false;
            // 
            // 
            // 
            this.integerInput_AlarmFamilyPassportBefore.BackgroundStyle.BackColor = System.Drawing.Color.SlateGray;
            this.integerInput_AlarmFamilyPassportBefore.BackgroundStyle.Class = "DateTimeInputBackground";
            this.integerInput_AlarmFamilyPassportBefore.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.integerInput_AlarmFamilyPassportBefore.ButtonClear.Visible = true;
            this.integerInput_AlarmFamilyPassportBefore.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.integerInput_AlarmFamilyPassportBefore.DisplayFormat = "0";
            this.integerInput_AlarmFamilyPassportBefore.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.integerInput_AlarmFamilyPassportBefore.ForeColor = System.Drawing.Color.White;
            this.integerInput_AlarmFamilyPassportBefore.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.integerInput_AlarmFamilyPassportBefore.Location = new System.Drawing.Point(510, 194);
            this.integerInput_AlarmFamilyPassportBefore.MinValue = 0;
            this.integerInput_AlarmFamilyPassportBefore.Name = "integerInput_AlarmFamilyPassportBefore";
            this.integerInput_AlarmFamilyPassportBefore.ShowUpDown = true;
            this.integerInput_AlarmFamilyPassportBefore.Size = new System.Drawing.Size(83, 21);
            this.integerInput_AlarmFamilyPassportBefore.TabIndex = 1021;
            // 
            // checkBox_IsAlarmFamilyPassport
            // 
            this.checkBox_IsAlarmFamilyPassport.AutoSize = true;
            this.checkBox_IsAlarmFamilyPassport.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.checkBox_IsAlarmFamilyPassport.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBox_IsAlarmFamilyPassport.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.checkBox_IsAlarmFamilyPassport.Location = new System.Drawing.Point(605, 196);
            this.checkBox_IsAlarmFamilyPassport.Name = "checkBox_IsAlarmFamilyPassport";
            this.checkBox_IsAlarmFamilyPassport.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBox_IsAlarmFamilyPassport.Size = new System.Drawing.Size(160, 16);
            this.checkBox_IsAlarmFamilyPassport.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBox_IsAlarmFamilyPassport.TabIndex = 1022;
            this.checkBox_IsAlarmFamilyPassport.Text = "تنبيه عن وثائق <font color=\"#BA1419\">المرافقين </font>قبل";
            this.checkBox_IsAlarmFamilyPassport.CheckedChanged += new System.EventHandler(this.checkBox_IsAlarmFamilyPassport_CheckedChanged);
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.BackColor = System.Drawing.Color.Transparent;
            this.label43.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label43.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label43.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label43.Location = new System.Drawing.Point(447, 157);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(33, 13);
            this.label43.TabIndex = 1020;
            this.label43.Text = "يومـــاُ";
            // 
            // integerInput_AlarmEmpContractBefore
            // 
            this.integerInput_AlarmEmpContractBefore.AllowEmptyState = false;
            // 
            // 
            // 
            this.integerInput_AlarmEmpContractBefore.BackgroundStyle.BackColor = System.Drawing.Color.SlateGray;
            this.integerInput_AlarmEmpContractBefore.BackgroundStyle.Class = "DateTimeInputBackground";
            this.integerInput_AlarmEmpContractBefore.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.integerInput_AlarmEmpContractBefore.ButtonClear.Visible = true;
            this.integerInput_AlarmEmpContractBefore.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.integerInput_AlarmEmpContractBefore.DisplayFormat = "0";
            this.integerInput_AlarmEmpContractBefore.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.integerInput_AlarmEmpContractBefore.ForeColor = System.Drawing.Color.White;
            this.integerInput_AlarmEmpContractBefore.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.integerInput_AlarmEmpContractBefore.Location = new System.Drawing.Point(486, 153);
            this.integerInput_AlarmEmpContractBefore.MinValue = 0;
            this.integerInput_AlarmEmpContractBefore.Name = "integerInput_AlarmEmpContractBefore";
            this.integerInput_AlarmEmpContractBefore.ShowUpDown = true;
            this.integerInput_AlarmEmpContractBefore.Size = new System.Drawing.Size(83, 21);
            this.integerInput_AlarmEmpContractBefore.TabIndex = 1018;
            // 
            // checkBox_IsAlarmEmpContract
            // 
            this.checkBox_IsAlarmEmpContract.AutoSize = true;
            this.checkBox_IsAlarmEmpContract.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.checkBox_IsAlarmEmpContract.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBox_IsAlarmEmpContract.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.checkBox_IsAlarmEmpContract.Location = new System.Drawing.Point(578, 155);
            this.checkBox_IsAlarmEmpContract.Name = "checkBox_IsAlarmEmpContract";
            this.checkBox_IsAlarmEmpContract.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBox_IsAlarmEmpContract.Size = new System.Drawing.Size(187, 16);
            this.checkBox_IsAlarmEmpContract.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBox_IsAlarmEmpContract.TabIndex = 1019;
            this.checkBox_IsAlarmEmpContract.Text = "تنبيه عن وثائق <font color=\"#BA1419\">عقود الموظفين </font>قبل";
            this.checkBox_IsAlarmEmpContract.CheckedChanged += new System.EventHandler(this.checkBox_IsAlarmEmpContract_CheckedChanged);
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.BackColor = System.Drawing.Color.Transparent;
            this.label42.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label42.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label42.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label42.Location = new System.Drawing.Point(471, 116);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(33, 13);
            this.label42.TabIndex = 1017;
            this.label42.Text = "يومـــاُ";
            // 
            // integerInput_AlarmEmpDocBefore
            // 
            this.integerInput_AlarmEmpDocBefore.AllowEmptyState = false;
            // 
            // 
            // 
            this.integerInput_AlarmEmpDocBefore.BackgroundStyle.BackColor = System.Drawing.Color.SlateGray;
            this.integerInput_AlarmEmpDocBefore.BackgroundStyle.Class = "DateTimeInputBackground";
            this.integerInput_AlarmEmpDocBefore.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.integerInput_AlarmEmpDocBefore.ButtonClear.Visible = true;
            this.integerInput_AlarmEmpDocBefore.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.integerInput_AlarmEmpDocBefore.DisplayFormat = "0";
            this.integerInput_AlarmEmpDocBefore.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.integerInput_AlarmEmpDocBefore.ForeColor = System.Drawing.Color.White;
            this.integerInput_AlarmEmpDocBefore.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.integerInput_AlarmEmpDocBefore.Location = new System.Drawing.Point(510, 112);
            this.integerInput_AlarmEmpDocBefore.MinValue = 0;
            this.integerInput_AlarmEmpDocBefore.Name = "integerInput_AlarmEmpDocBefore";
            this.integerInput_AlarmEmpDocBefore.ShowUpDown = true;
            this.integerInput_AlarmEmpDocBefore.Size = new System.Drawing.Size(83, 21);
            this.integerInput_AlarmEmpDocBefore.TabIndex = 1015;
            // 
            // checkBox_IsAlarmEmpDoc
            // 
            this.checkBox_IsAlarmEmpDoc.AutoSize = true;
            this.checkBox_IsAlarmEmpDoc.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.checkBox_IsAlarmEmpDoc.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBox_IsAlarmEmpDoc.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.checkBox_IsAlarmEmpDoc.Location = new System.Drawing.Point(605, 114);
            this.checkBox_IsAlarmEmpDoc.Name = "checkBox_IsAlarmEmpDoc";
            this.checkBox_IsAlarmEmpDoc.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBox_IsAlarmEmpDoc.Size = new System.Drawing.Size(160, 16);
            this.checkBox_IsAlarmEmpDoc.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBox_IsAlarmEmpDoc.TabIndex = 1016;
            this.checkBox_IsAlarmEmpDoc.Text = "تنبيه عن وثائق <font color=\"#BA1419\">الموظفين </font>قبل";
            this.checkBox_IsAlarmEmpDoc.CheckedChanged += new System.EventHandler(this.checkBox_IsAlarmEmpDoc_CheckedChanged);
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.BackColor = System.Drawing.Color.Transparent;
            this.label41.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label41.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label41.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label41.Location = new System.Drawing.Point(483, 75);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(33, 13);
            this.label41.TabIndex = 1014;
            this.label41.Text = "يومـــاُ";
            // 
            // integerInput_AlarmGuarantorDocBefore
            // 
            this.integerInput_AlarmGuarantorDocBefore.AllowEmptyState = false;
            // 
            // 
            // 
            this.integerInput_AlarmGuarantorDocBefore.BackgroundStyle.BackColor = System.Drawing.Color.SlateGray;
            this.integerInput_AlarmGuarantorDocBefore.BackgroundStyle.Class = "DateTimeInputBackground";
            this.integerInput_AlarmGuarantorDocBefore.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.integerInput_AlarmGuarantorDocBefore.ButtonClear.Visible = true;
            this.integerInput_AlarmGuarantorDocBefore.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.integerInput_AlarmGuarantorDocBefore.DisplayFormat = "0";
            this.integerInput_AlarmGuarantorDocBefore.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.integerInput_AlarmGuarantorDocBefore.ForeColor = System.Drawing.Color.White;
            this.integerInput_AlarmGuarantorDocBefore.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.integerInput_AlarmGuarantorDocBefore.Location = new System.Drawing.Point(525, 71);
            this.integerInput_AlarmGuarantorDocBefore.MinValue = 0;
            this.integerInput_AlarmGuarantorDocBefore.Name = "integerInput_AlarmGuarantorDocBefore";
            this.integerInput_AlarmGuarantorDocBefore.ShowUpDown = true;
            this.integerInput_AlarmGuarantorDocBefore.Size = new System.Drawing.Size(83, 21);
            this.integerInput_AlarmGuarantorDocBefore.TabIndex = 1012;
            // 
            // checkBox_IsAlarmGuarantorDoc
            // 
            this.checkBox_IsAlarmGuarantorDoc.AutoSize = true;
            this.checkBox_IsAlarmGuarantorDoc.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.checkBox_IsAlarmGuarantorDoc.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBox_IsAlarmGuarantorDoc.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.checkBox_IsAlarmGuarantorDoc.Location = new System.Drawing.Point(618, 73);
            this.checkBox_IsAlarmGuarantorDoc.Name = "checkBox_IsAlarmGuarantorDoc";
            this.checkBox_IsAlarmGuarantorDoc.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBox_IsAlarmGuarantorDoc.Size = new System.Drawing.Size(147, 16);
            this.checkBox_IsAlarmGuarantorDoc.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBox_IsAlarmGuarantorDoc.TabIndex = 1013;
            this.checkBox_IsAlarmGuarantorDoc.Text = "تنبيه عن وثائق <font color=\"#BA1419\">الكفلاء </font>قبل";
            this.checkBox_IsAlarmGuarantorDoc.CheckedChanged += new System.EventHandler(this.checkBox_IsAlarmGuarantorDoc_CheckedChanged);
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.BackColor = System.Drawing.Color.Transparent;
            this.label40.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label40.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label40.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label40.Location = new System.Drawing.Point(483, 34);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(33, 13);
            this.label40.TabIndex = 1011;
            this.label40.Text = "يومـــاُ";
            // 
            // integerInput_AlarmDeptsBefore
            // 
            this.integerInput_AlarmDeptsBefore.AllowEmptyState = false;
            // 
            // 
            // 
            this.integerInput_AlarmDeptsBefore.BackgroundStyle.BackColor = System.Drawing.Color.SlateGray;
            this.integerInput_AlarmDeptsBefore.BackgroundStyle.Class = "DateTimeInputBackground";
            this.integerInput_AlarmDeptsBefore.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.integerInput_AlarmDeptsBefore.ButtonClear.Visible = true;
            this.integerInput_AlarmDeptsBefore.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.integerInput_AlarmDeptsBefore.DisplayFormat = "0";
            this.integerInput_AlarmDeptsBefore.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.integerInput_AlarmDeptsBefore.ForeColor = System.Drawing.Color.White;
            this.integerInput_AlarmDeptsBefore.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.integerInput_AlarmDeptsBefore.Location = new System.Drawing.Point(525, 30);
            this.integerInput_AlarmDeptsBefore.MinValue = 0;
            this.integerInput_AlarmDeptsBefore.Name = "integerInput_AlarmDeptsBefore";
            this.integerInput_AlarmDeptsBefore.ShowUpDown = true;
            this.integerInput_AlarmDeptsBefore.Size = new System.Drawing.Size(83, 21);
            this.integerInput_AlarmDeptsBefore.TabIndex = 1009;
            // 
            // checkBox_IsAlarmDepts
            // 
            this.checkBox_IsAlarmDepts.AutoSize = true;
            this.checkBox_IsAlarmDepts.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.checkBox_IsAlarmDepts.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBox_IsAlarmDepts.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.checkBox_IsAlarmDepts.Location = new System.Drawing.Point(615, 32);
            this.checkBox_IsAlarmDepts.Name = "checkBox_IsAlarmDepts";
            this.checkBox_IsAlarmDepts.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBox_IsAlarmDepts.Size = new System.Drawing.Size(150, 16);
            this.checkBox_IsAlarmDepts.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBox_IsAlarmDepts.TabIndex = 1010;
            this.checkBox_IsAlarmDepts.Text = "تنبيه عن وثائق <font color=\"#BA1419\">الإدارات </font>قبل";
            this.checkBox_IsAlarmDepts.CheckedChanged += new System.EventHandler(this.checkBox_IsAlarmDepts_CheckedChanged);
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel11.Controls.Add(this.button_DocPath);
            this.panel11.Controls.Add(this.textBox_DocPath);
            this.panel11.Controls.Add(this.label38);
            this.panel11.Controls.Add(this.comboBox2);
            this.panel11.Location = new System.Drawing.Point(7, 280);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(945, 162);
            this.panel11.TabIndex = 992;
            // 
            // button_DocPath
            // 
            this.button_DocPath.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_DocPath.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_DocPath.Location = new System.Drawing.Point(69, 90);
            this.button_DocPath.Name = "button_DocPath";
            this.button_DocPath.Size = new System.Drawing.Size(30, 24);
            this.button_DocPath.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_DocPath.Symbol = "";
            this.button_DocPath.SymbolSize = 11F;
            this.button_DocPath.TabIndex = 993;
            this.button_DocPath.TextColor = System.Drawing.Color.SteelBlue;
            this.button_DocPath.Tooltip = "إستعراض";
            this.button_DocPath.Click += new System.EventHandler(this.button_DocPath_Click);
            // 
            // textBox_DocPath
            // 
            this.textBox_DocPath.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.textBox_DocPath.Enabled = false;
            this.textBox_DocPath.Location = new System.Drawing.Point(101, 92);
            this.textBox_DocPath.Name = "textBox_DocPath";
            this.textBox_DocPath.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_DocPath, false);
            this.textBox_DocPath.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBox_DocPath.Size = new System.Drawing.Size(775, 20);
            this.textBox_DocPath.TabIndex = 991;
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.BackColor = System.Drawing.Color.Transparent;
            this.label38.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label38.ForeColor = System.Drawing.Color.Red;
            this.label38.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label38.Location = new System.Drawing.Point(702, 61);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(177, 13);
            this.label38.TabIndex = 992;
            this.label38.Text = "المسار الإفتراضي لملفات الموظفين :";
            // 
            // comboBox2
            // 
            this.comboBox2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox2.BackColor = System.Drawing.Color.White;
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(194, 506);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.comboBox2.Size = new System.Drawing.Size(10, 24);
            this.comboBox2.TabIndex = 9;
            // 
            // groupPanel7
            // 
            this.groupPanel7.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel7.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel7.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel7.Controls.Add(this.groupBox3);
            this.groupPanel7.Controls.Add(this.groupPanel8);
            this.groupPanel7.Controls.Add(this.checkBox_Sponer);
            this.groupPanel7.Controls.Add(this.checkBox_VacationManually);
            this.groupPanel7.Controls.Add(this.button_DayofMonth);
            this.groupPanel7.Location = new System.Drawing.Point(8, 7);
            this.groupPanel7.Name = "groupPanel7";
            this.groupPanel7.Size = new System.Drawing.Size(996, 270);
            // 
            // 
            // 
            this.groupPanel7.Style.BackColor2 = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupPanel7.Style.BackColorGradientAngle = 90;
            this.groupPanel7.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
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
            this.groupPanel7.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Far;
            this.groupPanel7.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            // 
            // 
            // 
            this.groupPanel7.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel7.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel7.TabIndex = 968;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label37);
            this.groupBox3.Controls.Add(this.comboBox_DisVacationType);
            this.groupBox3.Controls.Add(this.label36);
            this.groupBox3.Controls.Add(this.comboBox_CalculateNo);
            this.groupBox3.Controls.Add(this.label35);
            this.groupBox3.Controls.Add(this.comboBox_CalculatliquidNo);
            this.groupBox3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.groupBox3.ForeColor = System.Drawing.Color.MidnightBlue;
            this.groupBox3.Location = new System.Drawing.Point(53, 129);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(866, 133);
            this.groupBox3.TabIndex = 989;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "حســــاب";
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.BackColor = System.Drawing.Color.Transparent;
            this.label37.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label37.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label37.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label37.Location = new System.Drawing.Point(706, 103);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(137, 13);
            this.label37.TabIndex = 986;
            this.label37.Text = "خصـــم من الإجـــازة حسب :";
            // 
            // comboBox_DisVacationType
            // 
            this.comboBox_DisVacationType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox_DisVacationType.DisplayMember = "Text";
            this.comboBox_DisVacationType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBox_DisVacationType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_DisVacationType.FocusHighlightColor = System.Drawing.Color.Empty;
            this.comboBox_DisVacationType.FormattingEnabled = true;
            this.comboBox_DisVacationType.ItemHeight = 15;
            this.comboBox_DisVacationType.Location = new System.Drawing.Point(61, 99);
            this.comboBox_DisVacationType.Name = "comboBox_DisVacationType";
            this.comboBox_DisVacationType.Size = new System.Drawing.Size(642, 21);
            this.comboBox_DisVacationType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBox_DisVacationType.TabIndex = 985;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.BackColor = System.Drawing.Color.Transparent;
            this.label36.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label36.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label36.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label36.Location = new System.Drawing.Point(706, 68);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(139, 13);
            this.label36.TabIndex = 984;
            this.label36.Text = " التأمينات الإجتماعية حسب :";
            // 
            // comboBox_CalculateNo
            // 
            this.comboBox_CalculateNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox_CalculateNo.DisplayMember = "Text";
            this.comboBox_CalculateNo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBox_CalculateNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_CalculateNo.FocusHighlightColor = System.Drawing.Color.Empty;
            this.comboBox_CalculateNo.FormattingEnabled = true;
            this.comboBox_CalculateNo.ItemHeight = 15;
            this.comboBox_CalculateNo.Location = new System.Drawing.Point(61, 64);
            this.comboBox_CalculateNo.Name = "comboBox_CalculateNo";
            this.comboBox_CalculateNo.Size = new System.Drawing.Size(642, 21);
            this.comboBox_CalculateNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBox_CalculateNo.TabIndex = 983;
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.BackColor = System.Drawing.Color.Transparent;
            this.label35.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label35.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label35.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label35.Location = new System.Drawing.Point(706, 33);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(136, 13);
            this.label35.TabIndex = 982;
            this.label35.Text = "تصفيـــــة الموظـــف حسب :";
            // 
            // comboBox_CalculatliquidNo
            // 
            this.comboBox_CalculatliquidNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox_CalculatliquidNo.DisplayMember = "Text";
            this.comboBox_CalculatliquidNo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBox_CalculatliquidNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_CalculatliquidNo.FocusHighlightColor = System.Drawing.Color.Empty;
            this.comboBox_CalculatliquidNo.FormattingEnabled = true;
            this.comboBox_CalculatliquidNo.ItemHeight = 15;
            this.comboBox_CalculatliquidNo.Location = new System.Drawing.Point(61, 29);
            this.comboBox_CalculatliquidNo.Name = "comboBox_CalculatliquidNo";
            this.comboBox_CalculatliquidNo.Size = new System.Drawing.Size(642, 21);
            this.comboBox_CalculatliquidNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBox_CalculatliquidNo.TabIndex = 981;
            // 
            // groupPanel8
            // 
            this.groupPanel8.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel8.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel8.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel8.Controls.Add(this.ChkEmp1);
            this.groupPanel8.Controls.Add(this.label39);
            this.groupPanel8.Controls.Add(this.textBox_AutoEmpLeaveAfter);
            this.groupPanel8.Controls.Add(this.checkBox_AttendanceManually);
            this.groupPanel8.Controls.Add(this.checkBox_AutoLeave);
            this.groupPanel8.Location = new System.Drawing.Point(280, 7);
            this.groupPanel8.Name = "groupPanel8";
            this.groupPanel8.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupPanel8.Size = new System.Drawing.Size(639, 113);
            // 
            // 
            // 
            this.groupPanel8.Style.BackColor2 = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupPanel8.Style.BackColorGradientAngle = 90;
            this.groupPanel8.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
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
            this.groupPanel8.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Far;
            this.groupPanel8.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            // 
            // 
            // 
            this.groupPanel8.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel8.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel8.TabIndex = 988;
            // 
            // ChkEmp1
            // 
            this.ChkEmp1.AutoSize = true;
            this.ChkEmp1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.ChkEmp1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ChkEmp1.Location = new System.Drawing.Point(379, 39);
            this.ChkEmp1.Name = "ChkEmp1";
            this.ChkEmp1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ChkEmp1.Size = new System.Drawing.Size(229, 15);
            this.ChkEmp1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ChkEmp1.TabIndex = 980;
            this.ChkEmp1.TabStop = false;
            this.ChkEmp1.Text = "إيقاف التفعيل التلقائي للراتب عند ترحيل الإجازة";
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.BackColor = System.Drawing.Color.Transparent;
            this.label39.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label39.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label39.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label39.Location = new System.Drawing.Point(267, 69);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(36, 13);
            this.label39.TabIndex = 979;
            this.label39.Text = "دقيقـة";
            // 
            // textBox_AutoEmpLeaveAfter
            // 
            this.textBox_AutoEmpLeaveAfter.AllowEmptyState = false;
            // 
            // 
            // 
            this.textBox_AutoEmpLeaveAfter.BackgroundStyle.BackColor = System.Drawing.Color.SlateGray;
            this.textBox_AutoEmpLeaveAfter.BackgroundStyle.Class = "DateTimeInputBackground";
            this.textBox_AutoEmpLeaveAfter.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBox_AutoEmpLeaveAfter.ButtonClear.Visible = true;
            this.textBox_AutoEmpLeaveAfter.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.textBox_AutoEmpLeaveAfter.DisplayFormat = "0";
            this.textBox_AutoEmpLeaveAfter.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.textBox_AutoEmpLeaveAfter.ForeColor = System.Drawing.Color.White;
            this.textBox_AutoEmpLeaveAfter.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.textBox_AutoEmpLeaveAfter.Location = new System.Drawing.Point(304, 64);
            this.textBox_AutoEmpLeaveAfter.MinValue = 0;
            this.textBox_AutoEmpLeaveAfter.Name = "textBox_AutoEmpLeaveAfter";
            this.textBox_AutoEmpLeaveAfter.ShowUpDown = true;
            this.textBox_AutoEmpLeaveAfter.Size = new System.Drawing.Size(137, 21);
            this.textBox_AutoEmpLeaveAfter.TabIndex = 977;
            // 
            // checkBox_AttendanceManually
            // 
            this.checkBox_AttendanceManually.AutoSize = true;
            this.checkBox_AttendanceManually.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.checkBox_AttendanceManually.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBox_AttendanceManually.Location = new System.Drawing.Point(445, 12);
            this.checkBox_AttendanceManually.Name = "checkBox_AttendanceManually";
            this.checkBox_AttendanceManually.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBox_AttendanceManually.Size = new System.Drawing.Size(165, 15);
            this.checkBox_AttendanceManually.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBox_AttendanceManually.TabIndex = 976;
            this.checkBox_AttendanceManually.Text = "السماح بإدخال وقت الحضور يدوياَ";
            // 
            // checkBox_AutoLeave
            // 
            this.checkBox_AutoLeave.AutoSize = true;
            this.checkBox_AutoLeave.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.checkBox_AutoLeave.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBox_AutoLeave.Location = new System.Drawing.Point(446, 66);
            this.checkBox_AutoLeave.Name = "checkBox_AutoLeave";
            this.checkBox_AutoLeave.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBox_AutoLeave.Size = new System.Drawing.Size(165, 15);
            this.checkBox_AutoLeave.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBox_AutoLeave.TabIndex = 978;
            this.checkBox_AutoLeave.Text = "صـــرف الموظفــــين تلقــــائيا بعد ";
            this.checkBox_AutoLeave.CheckedChanged += new System.EventHandler(this.checkBox_AutoLeave_CheckedChanged);
            // 
            // checkBox_Sponer
            // 
            this.checkBox_Sponer.AutoSize = true;
            this.checkBox_Sponer.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.checkBox_Sponer.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBox_Sponer.Location = new System.Drawing.Point(771, 119);
            this.checkBox_Sponer.Name = "checkBox_Sponer";
            this.checkBox_Sponer.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBox_Sponer.Size = new System.Drawing.Size(148, 15);
            this.checkBox_Sponer.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBox_Sponer.TabIndex = 976;
            this.checkBox_Sponer.Text = "تحديد كفيل لكل موظف جديد";
            // 
            // checkBox_VacationManually
            // 
            this.checkBox_VacationManually.AutoSize = true;
            this.checkBox_VacationManually.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.checkBox_VacationManually.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBox_VacationManually.Location = new System.Drawing.Point(952, 96);
            this.checkBox_VacationManually.Name = "checkBox_VacationManually";
            this.checkBox_VacationManually.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBox_VacationManually.Size = new System.Drawing.Size(193, 15);
            this.checkBox_VacationManually.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBox_VacationManually.TabIndex = 18;
            this.checkBox_VacationManually.Text = "احتساب تلقائي للاجازة في قرار الاجازة";
            // 
            // button_DayofMonth
            // 
            this.button_DayofMonth.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_DayofMonth.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_DayofMonth.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.button_DayofMonth.Location = new System.Drawing.Point(53, 7);
            this.button_DayofMonth.Name = "button_DayofMonth";
            this.button_DayofMonth.Size = new System.Drawing.Size(197, 110);
            this.button_DayofMonth.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_DayofMonth.Symbol = "";
            this.button_DayofMonth.SymbolSize = 20F;
            this.button_DayofMonth.TabIndex = 990;
            this.button_DayofMonth.Text = "شهـــــور السنـــة";
            this.button_DayofMonth.TextColor = System.Drawing.Color.SteelBlue;
            this.button_DayofMonth.Click += new System.EventHandler(this.button_DayofMonth_Click);
            // 
            // superTabItem_Employee
            // 
            this.superTabItem_Employee.AttachedControl = this.superTabControlPanel6;
            this.superTabItem_Employee.GlobalItem = false;
            this.superTabItem_Employee.Name = "superTabItem_Employee";
            this.superTabItem_Employee.Text = "شؤون الموظفين";
            this.superTabItem_Employee.Visible = false;
            // 
            // superTabControlPanel13
            // 
            this.superTabControlPanel13.CanvasColor = System.Drawing.Color.Silver;
            this.superTabControlPanel13.Controls.Add(this.txtTaxNote);
            this.superTabControlPanel13.Controls.Add(this.label83);
            this.superTabControlPanel13.Controls.Add(this.panel2);
            this.superTabControlPanel13.Controls.Add(this.ButGeneralPurchaesTax);
            this.superTabControlPanel13.Controls.Add(this.label2Tax);
            this.superTabControlPanel13.Controls.Add(this.label3Tax);
            this.superTabControlPanel13.Controls.Add(this.txtPurchaesTax);
            this.superTabControlPanel13.Controls.Add(this.ButGeneralSalesTax);
            this.superTabControlPanel13.Controls.Add(this.label1Tax);
            this.superTabControlPanel13.Controls.Add(this.label30Tax);
            this.superTabControlPanel13.Controls.Add(this.txtSalesTax);
            this.superTabControlPanel13.Controls.Add(this.c1FlexGriadTax);
            this.superTabControlPanel13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel13.Location = new System.Drawing.Point(0, 0);
            this.superTabControlPanel13.Name = "superTabControlPanel13";
            superTabLinearGradientColorTable5.Colors = new System.Drawing.Color[] {
        System.Drawing.Color.Gainsboro};
            superTabPanelItemColorTable5.Background = superTabLinearGradientColorTable5;
            superTabPanelColorTable5.Default = superTabPanelItemColorTable5;
            this.superTabControlPanel13.PanelColor = superTabPanelColorTable5;
            this.superTabControlPanel13.Size = new System.Drawing.Size(1069, 514);
            this.superTabControlPanel13.TabIndex = 0;
            this.superTabControlPanel13.TabItem = this.superTabItem5;
            // 
            // txtTaxNote
            // 
            this.txtTaxNote.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.txtTaxNote.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtTaxNote.Location = new System.Drawing.Point(6, 455);
            this.txtTaxNote.MaxLength = 150;
            this.txtTaxNote.Name = "txtTaxNote";
            this.netResize1.SetResizeTextBoxMultiline(this.txtTaxNote, false);
            this.txtTaxNote.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTaxNote.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtTaxNote.Size = new System.Drawing.Size(853, 21);
            this.txtTaxNote.TabIndex = 6810;
            this.txtTaxNote.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label83
            // 
            this.label83.BackColor = System.Drawing.Color.Transparent;
            this.label83.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label83.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label83.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label83.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label83.Location = new System.Drawing.Point(866, 455);
            this.label83.Name = "label83";
            this.label83.Size = new System.Drawing.Size(128, 20);
            this.label83.TabIndex = 6809;
            this.label83.Text = "ملاحظة بالضريبـة";
            this.label83.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.txtTaxID);
            this.panel2.Controls.Add(this.button_SrchTaxNo);
            this.panel2.Controls.Add(this.txtTaxNo);
            this.panel2.Controls.Add(this.txtTaxName);
            this.panel2.Controls.Add(this.label84);
            this.panel2.Controls.Add(this.label4Tax);
            this.panel2.Location = new System.Drawing.Point(5, 402);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1004, 51);
            this.panel2.TabIndex = 6808;
            // 
            // txtTaxID
            // 
            this.txtTaxID.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.txtTaxID.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtTaxID.Location = new System.Drawing.Point(3, 25);
            this.txtTaxID.Name = "txtTaxID";
            this.txtTaxID.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtTaxID, false);
            this.txtTaxID.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTaxID.Size = new System.Drawing.Size(847, 21);
            this.txtTaxID.TabIndex = 1098;
            this.txtTaxID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button_SrchTaxNo
            // 
            this.button_SrchTaxNo.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.button_SrchTaxNo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchTaxNo.Location = new System.Drawing.Point(392, 2);
            this.button_SrchTaxNo.Name = "button_SrchTaxNo";
            this.button_SrchTaxNo.Size = new System.Drawing.Size(26, 20);
            this.button_SrchTaxNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchTaxNo.Symbol = "";
            this.button_SrchTaxNo.SymbolSize = 12F;
            this.button_SrchTaxNo.TabIndex = 1094;
            this.button_SrchTaxNo.TextColor = System.Drawing.Color.SteelBlue;
            // 
            // txtTaxNo
            // 
            this.txtTaxNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtTaxNo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtTaxNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtTaxNo.Location = new System.Drawing.Point(424, 2);
            this.txtTaxNo.MaxLength = 30;
            this.txtTaxNo.Name = "txtTaxNo";
            this.txtTaxNo.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtTaxNo, false);
            this.txtTaxNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTaxNo.Size = new System.Drawing.Size(426, 21);
            this.txtTaxNo.TabIndex = 1093;
            this.txtTaxNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTaxName
            // 
            this.txtTaxName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtTaxName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtTaxName.Location = new System.Drawing.Point(3, 2);
            this.txtTaxName.Name = "txtTaxName";
            this.txtTaxName.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtTaxName, false);
            this.txtTaxName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTaxName.Size = new System.Drawing.Size(383, 21);
            this.txtTaxName.TabIndex = 1095;
            this.txtTaxName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label84
            // 
            this.label84.BackColor = System.Drawing.Color.Transparent;
            this.label84.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label84.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label84.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label84.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label84.Location = new System.Drawing.Point(856, 25);
            this.label84.Name = "label84";
            this.label84.Size = new System.Drawing.Size(131, 20);
            this.label84.TabIndex = 1097;
            this.label84.Text = "الرقم الضريبـــي";
            this.label84.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label4Tax
            // 
            this.label4Tax.BackColor = System.Drawing.Color.Transparent;
            this.label4Tax.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4Tax.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4Tax.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label4Tax.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4Tax.Location = new System.Drawing.Point(856, 2);
            this.label4Tax.Name = "label4Tax";
            this.label4Tax.Size = new System.Drawing.Size(131, 20);
            this.label4Tax.TabIndex = 1096;
            this.label4Tax.Text = "حساب الضريبــة";
            this.label4Tax.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // ButGeneralPurchaesTax
            // 
            this.ButGeneralPurchaesTax.BackColor = System.Drawing.Color.Transparent;
            this.ButGeneralPurchaesTax.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ButGeneralPurchaesTax.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.ButGeneralPurchaesTax.ForeColor = System.Drawing.Color.Maroon;
            this.ButGeneralPurchaesTax.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ButGeneralPurchaesTax.Location = new System.Drawing.Point(7, 377);
            this.ButGeneralPurchaesTax.Name = "ButGeneralPurchaesTax";
            this.ButGeneralPurchaesTax.Size = new System.Drawing.Size(109, 22);
            this.ButGeneralPurchaesTax.TabIndex = 6807;
            this.ButGeneralPurchaesTax.Text = "تعميم";
            this.ButGeneralPurchaesTax.UseVisualStyleBackColor = false;
            // 
            // label2Tax
            // 
            this.label2Tax.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2Tax.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label2Tax.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2Tax.Location = new System.Drawing.Point(119, 377);
            this.label2Tax.Name = "label2Tax";
            this.label2Tax.Size = new System.Drawing.Size(28, 22);
            this.label2Tax.TabIndex = 6806;
            this.label2Tax.Text = "%";
            this.label2Tax.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3Tax
            // 
            this.label3Tax.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3Tax.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label3Tax.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3Tax.Location = new System.Drawing.Point(209, 377);
            this.label3Tax.Name = "label3Tax";
            this.label3Tax.Size = new System.Drawing.Size(139, 22);
            this.label3Tax.TabIndex = 6804;
            this.label3Tax.Text = "ضريبة المشتريات";
            this.label3Tax.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label3Tax.Click += new System.EventHandler(this.label3Tax_Click);
            // 
            // txtPurchaesTax
            // 
            this.txtPurchaesTax.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtPurchaesTax.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(198)))));
            this.txtPurchaesTax.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtPurchaesTax.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtPurchaesTax.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtPurchaesTax.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.txtPurchaesTax.Increment = 1D;
            this.txtPurchaesTax.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtPurchaesTax.Location = new System.Drawing.Point(149, 377);
            this.txtPurchaesTax.MinValue = 0D;
            this.txtPurchaesTax.Name = "txtPurchaesTax";
            this.txtPurchaesTax.Size = new System.Drawing.Size(58, 22);
            this.txtPurchaesTax.TabIndex = 6805;
            // 
            // ButGeneralSalesTax
            // 
            this.ButGeneralSalesTax.BackColor = System.Drawing.Color.Transparent;
            this.ButGeneralSalesTax.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ButGeneralSalesTax.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.ButGeneralSalesTax.ForeColor = System.Drawing.Color.Maroon;
            this.ButGeneralSalesTax.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ButGeneralSalesTax.Location = new System.Drawing.Point(669, 376);
            this.ButGeneralSalesTax.Name = "ButGeneralSalesTax";
            this.ButGeneralSalesTax.Size = new System.Drawing.Size(109, 22);
            this.ButGeneralSalesTax.TabIndex = 6803;
            this.ButGeneralSalesTax.Text = "تعميم";
            this.ButGeneralSalesTax.UseVisualStyleBackColor = false;
            // 
            // label1Tax
            // 
            this.label1Tax.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1Tax.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label1Tax.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1Tax.Location = new System.Drawing.Point(780, 376);
            this.label1Tax.Name = "label1Tax";
            this.label1Tax.Size = new System.Drawing.Size(28, 22);
            this.label1Tax.TabIndex = 6802;
            this.label1Tax.Text = "%";
            this.label1Tax.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label30Tax
            // 
            this.label30Tax.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label30Tax.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label30Tax.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label30Tax.Location = new System.Drawing.Point(873, 376);
            this.label30Tax.Name = "label30Tax";
            this.label30Tax.Size = new System.Drawing.Size(128, 22);
            this.label30Tax.TabIndex = 6800;
            this.label30Tax.Text = "ضريبة المبيعات";
            this.label30Tax.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtSalesTax
            // 
            this.txtSalesTax.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtSalesTax.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(198)))));
            this.txtSalesTax.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtSalesTax.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtSalesTax.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtSalesTax.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.txtSalesTax.Increment = 1D;
            this.txtSalesTax.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtSalesTax.Location = new System.Drawing.Point(810, 376);
            this.txtSalesTax.MinValue = 0D;
            this.txtSalesTax.Name = "txtSalesTax";
            this.txtSalesTax.Size = new System.Drawing.Size(58, 22);
            this.txtSalesTax.TabIndex = 6801;
            // 
            // c1FlexGriadTax
            // 
            this.c1FlexGriadTax.ColumnInfo = resources.GetString("c1FlexGriadTax.ColumnInfo");
            this.c1FlexGriadTax.Font = new System.Drawing.Font("Tahoma", 8F);
            this.c1FlexGriadTax.Location = new System.Drawing.Point(3, 0);
            this.c1FlexGriadTax.Name = "c1FlexGriadTax";
            this.c1FlexGriadTax.Rows.Count = 15;
            this.c1FlexGriadTax.Rows.DefaultSize = 19;
            this.c1FlexGriadTax.Size = new System.Drawing.Size(1006, 368);
            this.c1FlexGriadTax.StyleInfo = resources.GetString("c1FlexGriadTax.StyleInfo");
            this.c1FlexGriadTax.TabIndex = 6799;
            this.c1FlexGriadTax.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2007Black;
            this.c1FlexGriadTax.CellChecked += new C1.Win.C1FlexGrid.RowColEventHandler(this.c1FlexGriadTax_CellChecked);
            this.c1FlexGriadTax.Click += new System.EventHandler(this.c1FlexGriadTax_Click);
            this.c1FlexGriadTax.DoubleClick += new System.EventHandler(this.c1FlexGriadTax_DoubleClick);
            // 
            // superTabItem5
            // 
            this.superTabItem5.AttachedControl = this.superTabControlPanel13;
            this.superTabItem5.GlobalItem = false;
            this.superTabItem5.Name = "superTabItem5";
            this.superTabItem5.Text = "إعدادت الضريبه";
            // 
            // superTabControlPanel7
            // 
            this.superTabControlPanel7.Controls.Add(this.groupPanel11);
            this.superTabControlPanel7.Controls.Add(this.groupPanel10);
            this.superTabControlPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel7.Location = new System.Drawing.Point(0, 0);
            this.superTabControlPanel7.Name = "superTabControlPanel7";
            this.superTabControlPanel7.Size = new System.Drawing.Size(1069, 514);
            this.superTabControlPanel7.TabIndex = 0;
            this.superTabControlPanel7.TabItem = this.superTabItem_Hotel;
            // 
            // groupPanel11
            // 
            this.groupPanel11.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel11.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel11.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel11.Controls.Add(this.label80);
            this.groupPanel11.Controls.Add(this.button_B7);
            this.groupPanel11.Controls.Add(this.button_F7);
            this.groupPanel11.Controls.Add(this.button_B5);
            this.groupPanel11.Controls.Add(this.button_F5);
            this.groupPanel11.Controls.Add(this.button_B3);
            this.groupPanel11.Controls.Add(this.button_F3);
            this.groupPanel11.Controls.Add(this.button_B1);
            this.groupPanel11.Controls.Add(this.button_F1);
            this.groupPanel11.Controls.Add(this.txtRBussyMonthly);
            this.groupPanel11.Controls.Add(this.txtRClean);
            this.groupPanel11.Controls.Add(this.txtRBussyDaily);
            this.groupPanel11.Controls.Add(this.txtREmpty);
            this.groupPanel11.Controls.Add(this.checkBoxX12);
            this.groupPanel11.Controls.Add(this.button_F8);
            this.groupPanel11.Controls.Add(this.button_F6);
            this.groupPanel11.Controls.Add(this.button_F4);
            this.groupPanel11.Controls.Add(this.button_F2);
            this.groupPanel11.Controls.Add(this.button_B8);
            this.groupPanel11.Controls.Add(this.button_B6);
            this.groupPanel11.Controls.Add(this.button_B4);
            this.groupPanel11.Controls.Add(this.button_B2);
            this.groupPanel11.Controls.Add(this.txtRLeave);
            this.groupPanel11.Controls.Add(this.txtRRepair);
            this.groupPanel11.Controls.Add(this.txtRBussyAppendix);
            this.groupPanel11.Controls.Add(this.txtRAvailable);
            this.groupPanel11.Location = new System.Drawing.Point(6, 282);
            this.groupPanel11.Name = "groupPanel11";
            this.groupPanel11.Size = new System.Drawing.Size(786, 184);
            // 
            // 
            // 
            this.groupPanel11.Style.BackColor2 = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupPanel11.Style.BackColorGradientAngle = 90;
            this.groupPanel11.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
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
            this.groupPanel11.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Far;
            this.groupPanel11.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            // 
            // 
            // 
            this.groupPanel11.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel11.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel11.TabIndex = 970;
            // 
            // label80
            // 
            this.label80.BackColor = System.Drawing.Color.SteelBlue;
            this.label80.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label80.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label80.ForeColor = System.Drawing.Color.White;
            this.label80.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label80.Location = new System.Drawing.Point(12, 13);
            this.label80.Name = "label80";
            this.label80.Size = new System.Drawing.Size(754, 26);
            this.label80.TabIndex = 1053;
            this.label80.Text = "خيارات الألوان لمربعات الغرف / الشقق";
            this.label80.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button_B7
            // 
            this.button_B7.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_B7.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_B7.Location = new System.Drawing.Point(460, 141);
            this.button_B7.Name = "button_B7";
            this.button_B7.Size = new System.Drawing.Size(27, 19);
            this.button_B7.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_B7.Symbol = "";
            this.button_B7.SymbolSize = 11F;
            this.button_B7.TabIndex = 1044;
            this.button_B7.TextColor = System.Drawing.Color.SteelBlue;
            this.button_B7.Tooltip = "لون خلفية المربع";
            this.button_B7.Click += new System.EventHandler(this.button_B7_Click);
            // 
            // button_F7
            // 
            this.button_F7.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_F7.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_F7.Location = new System.Drawing.Point(488, 141);
            this.button_F7.Name = "button_F7";
            this.button_F7.Size = new System.Drawing.Size(27, 19);
            this.button_F7.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_F7.Symbol = "";
            this.button_F7.SymbolSize = 11F;
            this.button_F7.TabIndex = 1043;
            this.button_F7.TextColor = System.Drawing.Color.SteelBlue;
            this.button_F7.Tooltip = "لون خط الكتابة";
            this.button_F7.Click += new System.EventHandler(this.button_F7_Click);
            // 
            // button_B5
            // 
            this.button_B5.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_B5.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_B5.Location = new System.Drawing.Point(460, 111);
            this.button_B5.Name = "button_B5";
            this.button_B5.Size = new System.Drawing.Size(27, 19);
            this.button_B5.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_B5.Symbol = "";
            this.button_B5.SymbolSize = 11F;
            this.button_B5.TabIndex = 1042;
            this.button_B5.TextColor = System.Drawing.Color.SteelBlue;
            this.button_B5.Tooltip = "لون خلفية المربع";
            this.button_B5.Click += new System.EventHandler(this.button_B5_Click);
            // 
            // button_F5
            // 
            this.button_F5.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_F5.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_F5.Location = new System.Drawing.Point(488, 111);
            this.button_F5.Name = "button_F5";
            this.button_F5.Size = new System.Drawing.Size(27, 19);
            this.button_F5.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_F5.Symbol = "";
            this.button_F5.SymbolSize = 11F;
            this.button_F5.TabIndex = 1041;
            this.button_F5.TextColor = System.Drawing.Color.SteelBlue;
            this.button_F5.Tooltip = "لون خط الكتابة";
            this.button_F5.Click += new System.EventHandler(this.button_F5_Click);
            // 
            // button_B3
            // 
            this.button_B3.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_B3.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_B3.Location = new System.Drawing.Point(460, 81);
            this.button_B3.Name = "button_B3";
            this.button_B3.Size = new System.Drawing.Size(27, 19);
            this.button_B3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_B3.Symbol = "";
            this.button_B3.SymbolSize = 11F;
            this.button_B3.TabIndex = 1040;
            this.button_B3.TextColor = System.Drawing.Color.SteelBlue;
            this.button_B3.Tooltip = "لون خلفية المربع";
            this.button_B3.Click += new System.EventHandler(this.button_B3_Click);
            // 
            // button_F3
            // 
            this.button_F3.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_F3.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_F3.Location = new System.Drawing.Point(488, 81);
            this.button_F3.Name = "button_F3";
            this.button_F3.Size = new System.Drawing.Size(27, 19);
            this.button_F3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_F3.Symbol = "";
            this.button_F3.SymbolSize = 11F;
            this.button_F3.TabIndex = 1039;
            this.button_F3.TextColor = System.Drawing.Color.SteelBlue;
            this.button_F3.Tooltip = "لون خط الكتابة";
            this.button_F3.Click += new System.EventHandler(this.button_F3_Click);
            // 
            // button_B1
            // 
            this.button_B1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_B1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_B1.Image = ((System.Drawing.Image)(resources.GetObject("button_B1.Image")));
            this.button_B1.Location = new System.Drawing.Point(460, 51);
            this.button_B1.Name = "button_B1";
            this.button_B1.Size = new System.Drawing.Size(27, 19);
            this.button_B1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_B1.Symbol = "";
            this.button_B1.SymbolSize = 11F;
            this.button_B1.TabIndex = 1054;
            this.button_B1.TextColor = System.Drawing.Color.SteelBlue;
            this.button_B1.Tooltip = "لون خلفية المربع";
            this.button_B1.Click += new System.EventHandler(this.button_B1_Click);
            // 
            // button_F1
            // 
            this.button_F1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_F1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_F1.Location = new System.Drawing.Point(488, 51);
            this.button_F1.Name = "button_F1";
            this.button_F1.Size = new System.Drawing.Size(27, 19);
            this.button_F1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_F1.Symbol = "";
            this.button_F1.SymbolSize = 11F;
            this.button_F1.TabIndex = 1037;
            this.button_F1.TextColor = System.Drawing.Color.SteelBlue;
            this.button_F1.Tooltip = "لون خط الكتابة";
            this.button_F1.Click += new System.EventHandler(this.button_F1_Click);
            // 
            // txtRBussyMonthly
            // 
            this.txtRBussyMonthly.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.txtRBussyMonthly.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRBussyMonthly.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtRBussyMonthly.Location = new System.Drawing.Point(518, 141);
            this.txtRBussyMonthly.Name = "txtRBussyMonthly";
            this.txtRBussyMonthly.Size = new System.Drawing.Size(248, 19);
            this.txtRBussyMonthly.TabIndex = 1032;
            this.txtRBussyMonthly.Text = "مشغول شهري";
            this.txtRBussyMonthly.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtRClean
            // 
            this.txtRClean.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.txtRClean.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRClean.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtRClean.Location = new System.Drawing.Point(518, 111);
            this.txtRClean.Name = "txtRClean";
            this.txtRClean.Size = new System.Drawing.Size(248, 19);
            this.txtRClean.TabIndex = 1031;
            this.txtRClean.Text = "نظـــــــــافة";
            this.txtRClean.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtRBussyDaily
            // 
            this.txtRBussyDaily.BackColor = System.Drawing.Color.Red;
            this.txtRBussyDaily.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRBussyDaily.ForeColor = System.Drawing.Color.White;
            this.txtRBussyDaily.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtRBussyDaily.Location = new System.Drawing.Point(518, 81);
            this.txtRBussyDaily.Name = "txtRBussyDaily";
            this.txtRBussyDaily.Size = new System.Drawing.Size(248, 19);
            this.txtRBussyDaily.TabIndex = 1030;
            this.txtRBussyDaily.Text = "مشغول يومي";
            this.txtRBussyDaily.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtREmpty
            // 
            this.txtREmpty.BackColor = System.Drawing.Color.White;
            this.txtREmpty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtREmpty.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.txtREmpty.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtREmpty.Location = new System.Drawing.Point(518, 51);
            this.txtREmpty.Name = "txtREmpty";
            this.txtREmpty.Size = new System.Drawing.Size(248, 19);
            this.txtREmpty.TabIndex = 1029;
            this.txtREmpty.Text = "فارغـــــة";
            this.txtREmpty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // checkBoxX12
            // 
            this.checkBoxX12.AutoSize = true;
            this.checkBoxX12.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.checkBoxX12.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBoxX12.Location = new System.Drawing.Point(771, 119);
            this.checkBoxX12.Name = "checkBoxX12";
            this.checkBoxX12.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBoxX12.Size = new System.Drawing.Size(148, 15);
            this.checkBoxX12.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBoxX12.TabIndex = 976;
            this.checkBoxX12.Text = "تحديد كفيل لكل موظف جديد";
            // 
            // button_F8
            // 
            this.button_F8.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_F8.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_F8.Location = new System.Drawing.Point(44, 141);
            this.button_F8.Name = "button_F8";
            this.button_F8.Size = new System.Drawing.Size(27, 19);
            this.button_F8.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_F8.Symbol = "";
            this.button_F8.SymbolSize = 11F;
            this.button_F8.TabIndex = 1051;
            this.button_F8.TextColor = System.Drawing.Color.SteelBlue;
            this.button_F8.Tooltip = "لون خط الكتابة";
            this.button_F8.Click += new System.EventHandler(this.button_F8_Click);
            // 
            // button_F6
            // 
            this.button_F6.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_F6.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_F6.Location = new System.Drawing.Point(44, 111);
            this.button_F6.Name = "button_F6";
            this.button_F6.Size = new System.Drawing.Size(27, 19);
            this.button_F6.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_F6.Symbol = "";
            this.button_F6.SymbolSize = 11F;
            this.button_F6.TabIndex = 1049;
            this.button_F6.TextColor = System.Drawing.Color.SteelBlue;
            this.button_F6.Tooltip = "لون خط الكتابة";
            this.button_F6.Click += new System.EventHandler(this.button_F6_Click);
            // 
            // button_F4
            // 
            this.button_F4.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_F4.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_F4.Location = new System.Drawing.Point(44, 81);
            this.button_F4.Name = "button_F4";
            this.button_F4.Size = new System.Drawing.Size(27, 19);
            this.button_F4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_F4.Symbol = "";
            this.button_F4.SymbolSize = 11F;
            this.button_F4.TabIndex = 1047;
            this.button_F4.TextColor = System.Drawing.Color.SteelBlue;
            this.button_F4.Tooltip = "لون خط الكتابة";
            this.button_F4.Click += new System.EventHandler(this.button_F4_Click);
            // 
            // button_F2
            // 
            this.button_F2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_F2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_F2.Location = new System.Drawing.Point(44, 51);
            this.button_F2.Name = "button_F2";
            this.button_F2.Size = new System.Drawing.Size(27, 19);
            this.button_F2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_F2.Symbol = "";
            this.button_F2.SymbolSize = 11F;
            this.button_F2.TabIndex = 1045;
            this.button_F2.TextColor = System.Drawing.Color.SteelBlue;
            this.button_F2.Tooltip = "لون خط الكتابة";
            this.button_F2.Visible = false;
            this.button_F2.Click += new System.EventHandler(this.button_F2_Click);
            // 
            // button_B8
            // 
            this.button_B8.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_B8.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_B8.Location = new System.Drawing.Point(16, 141);
            this.button_B8.Name = "button_B8";
            this.button_B8.Size = new System.Drawing.Size(27, 19);
            this.button_B8.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_B8.Symbol = "";
            this.button_B8.SymbolSize = 11F;
            this.button_B8.TabIndex = 1052;
            this.button_B8.TextColor = System.Drawing.Color.SteelBlue;
            this.button_B8.Tooltip = "لون خلفية المربع";
            this.button_B8.Click += new System.EventHandler(this.button_B8_Click);
            // 
            // button_B6
            // 
            this.button_B6.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_B6.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_B6.Location = new System.Drawing.Point(16, 111);
            this.button_B6.Name = "button_B6";
            this.button_B6.Size = new System.Drawing.Size(27, 19);
            this.button_B6.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_B6.Symbol = "";
            this.button_B6.SymbolSize = 11F;
            this.button_B6.TabIndex = 1050;
            this.button_B6.TextColor = System.Drawing.Color.SteelBlue;
            this.button_B6.Tooltip = "لون خلفية المربع";
            this.button_B6.Click += new System.EventHandler(this.button_B6_Click);
            // 
            // button_B4
            // 
            this.button_B4.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_B4.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_B4.Location = new System.Drawing.Point(16, 81);
            this.button_B4.Name = "button_B4";
            this.button_B4.Size = new System.Drawing.Size(27, 19);
            this.button_B4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_B4.Symbol = "";
            this.button_B4.SymbolSize = 11F;
            this.button_B4.TabIndex = 1048;
            this.button_B4.TextColor = System.Drawing.Color.SteelBlue;
            this.button_B4.Tooltip = "لون خلفية المربع";
            this.button_B4.Click += new System.EventHandler(this.button_B4_Click);
            // 
            // button_B2
            // 
            this.button_B2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_B2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_B2.Location = new System.Drawing.Point(16, 51);
            this.button_B2.Name = "button_B2";
            this.button_B2.Size = new System.Drawing.Size(27, 19);
            this.button_B2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_B2.Symbol = "";
            this.button_B2.SymbolSize = 11F;
            this.button_B2.TabIndex = 1046;
            this.button_B2.TextColor = System.Drawing.Color.SteelBlue;
            this.button_B2.Tooltip = "لون خلفية المربع";
            this.button_B2.Visible = false;
            this.button_B2.Click += new System.EventHandler(this.button_B2_Click);
            // 
            // txtRLeave
            // 
            this.txtRLeave.BackColor = System.Drawing.Color.Green;
            this.txtRLeave.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRLeave.ForeColor = System.Drawing.Color.White;
            this.txtRLeave.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtRLeave.Location = new System.Drawing.Point(74, 141);
            this.txtRLeave.Name = "txtRLeave";
            this.txtRLeave.Size = new System.Drawing.Size(248, 19);
            this.txtRLeave.TabIndex = 1036;
            this.txtRLeave.Text = "مغــــــــــادرة";
            this.txtRLeave.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtRRepair
            // 
            this.txtRRepair.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtRRepair.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRRepair.ForeColor = System.Drawing.Color.White;
            this.txtRRepair.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtRRepair.Location = new System.Drawing.Point(74, 111);
            this.txtRRepair.Name = "txtRRepair";
            this.txtRRepair.Size = new System.Drawing.Size(248, 19);
            this.txtRRepair.TabIndex = 1035;
            this.txtRRepair.Text = "صيــــــــــانة";
            this.txtRRepair.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtRBussyAppendix
            // 
            this.txtRBussyAppendix.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.txtRBussyAppendix.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRBussyAppendix.ForeColor = System.Drawing.Color.White;
            this.txtRBussyAppendix.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtRBussyAppendix.Location = new System.Drawing.Point(74, 81);
            this.txtRBussyAppendix.Name = "txtRBussyAppendix";
            this.txtRBussyAppendix.Size = new System.Drawing.Size(248, 19);
            this.txtRBussyAppendix.TabIndex = 1034;
            this.txtRBussyAppendix.Text = "مشغولة ملحق";
            this.txtRBussyAppendix.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtRAvailable
            // 
            this.txtRAvailable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtRAvailable.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRAvailable.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.txtRAvailable.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtRAvailable.Location = new System.Drawing.Point(74, 51);
            this.txtRAvailable.Name = "txtRAvailable";
            this.txtRAvailable.Size = new System.Drawing.Size(248, 19);
            this.txtRAvailable.TabIndex = 1033;
            this.txtRAvailable.Text = "متاحة للعملية";
            this.txtRAvailable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.txtRAvailable.Visible = false;
            // 
            // groupPanel10
            // 
            this.groupPanel10.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel10.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel10.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel10.Controls.Add(this.chk65);
            this.groupPanel10.Controls.Add(this.button_ManageRoom);
            this.groupPanel10.Controls.Add(this.line2);
            this.groupPanel10.Controls.Add(this.chk43);
            this.groupPanel10.Controls.Add(this.txtGuestBoxAccName);
            this.groupPanel10.Controls.Add(this.txtGuestsFatherAccName);
            this.groupPanel10.Controls.Add(this.chk42);
            this.groupPanel10.Controls.Add(this.txtGuestBoxAcc);
            this.groupPanel10.Controls.Add(this.label72);
            this.groupPanel10.Controls.Add(this.txtGuestsFatherAcc);
            this.groupPanel10.Controls.Add(this.label59);
            this.groupPanel10.Controls.Add(this.label67);
            this.groupPanel10.Controls.Add(this.label66);
            this.groupPanel10.Controls.Add(this.txtDayofMonth);
            this.groupPanel10.Controls.Add(this.groupBox6);
            this.groupPanel10.Controls.Add(this.groupBox5);
            this.groupPanel10.Controls.Add(this.txtLeavePeriod);
            this.groupPanel10.Controls.Add(this.txtAllowPeriod);
            this.groupPanel10.Controls.Add(this.label62);
            this.groupPanel10.Controls.Add(this.txtRoom);
            this.groupPanel10.Controls.Add(this.txtFloors);
            this.groupPanel10.Controls.Add(this.checkBoxX3);
            this.groupPanel10.Controls.Add(this.label65);
            this.groupPanel10.Controls.Add(this.label64);
            this.groupPanel10.Controls.Add(this.label63);
            this.groupPanel10.Controls.Add(this.label61);
            this.groupPanel10.Controls.Add(this.label60);
            this.groupPanel10.Controls.Add(this.label68);
            this.groupPanel10.Controls.Add(this.label69);
            this.groupPanel10.Controls.Add(this.txtLongitudinal);
            this.groupPanel10.Controls.Add(this.label70);
            this.groupPanel10.Controls.Add(this.label71);
            this.groupPanel10.Controls.Add(this.txtWidthitudinal);
            this.groupPanel10.Controls.Add(this.chk44);
            this.groupPanel10.Location = new System.Drawing.Point(6, 6);
            this.groupPanel10.Name = "groupPanel10";
            this.groupPanel10.Size = new System.Drawing.Size(786, 269);
            // 
            // 
            // 
            this.groupPanel10.Style.BackColor2 = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupPanel10.Style.BackColorGradientAngle = 90;
            this.groupPanel10.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
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
            this.groupPanel10.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Far;
            this.groupPanel10.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            // 
            // 
            // 
            this.groupPanel10.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel10.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel10.TabIndex = 969;
            // 
            // chk65
            // 
            this.chk65.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chk65.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chk65.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.chk65.Location = new System.Drawing.Point(42, 148);
            this.chk65.Name = "chk65";
            this.chk65.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chk65.Size = new System.Drawing.Size(167, 41);
            this.chk65.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chk65.TabIndex = 1049;
            this.chk65.Text = "إيقاف القيد المحاسبي بإجمالي\r\n قيمة الإقامة عند المغادرة";
            // 
            // button_ManageRoom
            // 
            this.button_ManageRoom.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_ManageRoom.Checked = true;
            this.button_ManageRoom.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.button_ManageRoom.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.button_ManageRoom.Location = new System.Drawing.Point(241, 51);
            this.button_ManageRoom.Name = "button_ManageRoom";
            this.button_ManageRoom.Size = new System.Drawing.Size(530, 21);
            this.button_ManageRoom.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_ManageRoom.Symbol = "";
            this.button_ManageRoom.SymbolSize = 11F;
            this.button_ManageRoom.TabIndex = 1048;
            this.button_ManageRoom.Text = "إدارة الغرف / الشقق في الطوابق";
            this.button_ManageRoom.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button_ManageRoom.Click += new System.EventHandler(this.button_ManageRoom_Click);
            // 
            // line2
            // 
            this.line2.ForeColor = System.Drawing.Color.DimGray;
            this.line2.Location = new System.Drawing.Point(225, 19);
            this.line2.Name = "line2";
            this.line2.Size = new System.Drawing.Size(7, 239);
            this.line2.TabIndex = 1046;
            this.line2.Text = "line2";
            this.line2.Thickness = 2;
            this.line2.VerticalLine = true;
            // 
            // chk43
            // 
            this.chk43.AutoSize = true;
            this.chk43.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chk43.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chk43.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.chk43.Location = new System.Drawing.Point(33, 65);
            this.chk43.Name = "chk43";
            this.chk43.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chk43.Size = new System.Drawing.Size(168, 16);
            this.chk43.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chk43.TabIndex = 1044;
            this.chk43.Text = "إظهار حسابات النزلاء في الفواتير";
            // 
            // txtGuestBoxAccName
            // 
            this.txtGuestBoxAccName.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtGuestBoxAccName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtGuestBoxAccName.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.txtGuestBoxAccName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtGuestBoxAccName.Location = new System.Drawing.Point(240, 242);
            this.txtGuestBoxAccName.Name = "txtGuestBoxAccName";
            this.txtGuestBoxAccName.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtGuestBoxAccName, false);
            this.txtGuestBoxAccName.Size = new System.Drawing.Size(157, 16);
            this.txtGuestBoxAccName.TabIndex = 1043;
            this.txtGuestBoxAccName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtGuestBoxAccName.Click += new System.EventHandler(this.txtGuestBoxAccName_Click);
            // 
            // txtGuestsFatherAccName
            // 
            this.txtGuestsFatherAccName.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtGuestsFatherAccName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtGuestsFatherAccName.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.txtGuestsFatherAccName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtGuestsFatherAccName.Location = new System.Drawing.Point(509, 242);
            this.txtGuestsFatherAccName.Name = "txtGuestsFatherAccName";
            this.txtGuestsFatherAccName.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtGuestsFatherAccName, false);
            this.txtGuestsFatherAccName.Size = new System.Drawing.Size(157, 16);
            this.txtGuestsFatherAccName.TabIndex = 1042;
            this.txtGuestsFatherAccName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtGuestsFatherAccName.Click += new System.EventHandler(this.txtGuestsFatherAccName_Click);
            // 
            // chk42
            // 
            this.chk42.AutoSize = true;
            this.chk42.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chk42.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chk42.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.chk42.Location = new System.Drawing.Point(63, 129);
            this.chk42.Name = "chk42";
            this.chk42.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chk42.Size = new System.Drawing.Size(139, 16);
            this.chk42.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chk42.TabIndex = 1040;
            this.chk42.Text = "ايقــــاف القيد التلقــــــائي";
            // 
            // txtGuestBoxAcc
            // 
            this.txtGuestBoxAcc.BackColor = System.Drawing.SystemColors.Control;
            // 
            // 
            // 
            this.txtGuestBoxAcc.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtGuestBoxAcc.ButtonCustom.Visible = true;
            this.txtGuestBoxAcc.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.txtGuestBoxAcc.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtGuestBoxAcc.Location = new System.Drawing.Point(400, 242);
            this.txtGuestBoxAcc.Name = "txtGuestBoxAcc";
            this.txtGuestBoxAcc.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtGuestBoxAcc, false);
            this.txtGuestBoxAcc.Size = new System.Drawing.Size(103, 16);
            this.txtGuestBoxAcc.TabIndex = 1039;
            this.txtGuestBoxAcc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtGuestBoxAcc.ButtonCustomClick += new System.EventHandler(this.txtGuestBoxAcc_ButtonCustomClick);
            this.txtGuestBoxAcc.Click += new System.EventHandler(this.txtGuestBoxAcc_Click);
            // 
            // label72
            // 
            this.label72.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label72.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label72.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label72.ForeColor = System.Drawing.Color.Black;
            this.label72.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label72.Location = new System.Drawing.Point(240, 208);
            this.label72.Name = "label72";
            this.label72.Size = new System.Drawing.Size(263, 28);
            this.label72.TabIndex = 1038;
            this.label72.Text = "القيود التلقائية للعمليات المحاسبية";
            this.label72.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtGuestsFatherAcc
            // 
            this.txtGuestsFatherAcc.BackColor = System.Drawing.SystemColors.Control;
            // 
            // 
            // 
            this.txtGuestsFatherAcc.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtGuestsFatherAcc.ButtonCustom.Visible = true;
            this.txtGuestsFatherAcc.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.txtGuestsFatherAcc.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtGuestsFatherAcc.Location = new System.Drawing.Point(669, 242);
            this.txtGuestsFatherAcc.Name = "txtGuestsFatherAcc";
            this.txtGuestsFatherAcc.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtGuestsFatherAcc, false);
            this.txtGuestsFatherAcc.Size = new System.Drawing.Size(103, 16);
            this.txtGuestsFatherAcc.TabIndex = 1037;
            this.txtGuestsFatherAcc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtGuestsFatherAcc.ButtonCustomClick += new System.EventHandler(this.txtGuestsFatherAcc_ButtonCustomClick);
            this.txtGuestsFatherAcc.Click += new System.EventHandler(this.txtGuestsFatherAcc_Click);
            // 
            // label59
            // 
            this.label59.BackColor = System.Drawing.Color.Transparent;
            this.label59.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label59.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label59.ForeColor = System.Drawing.Color.Black;
            this.label59.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label59.Location = new System.Drawing.Point(241, 19);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(146, 21);
            this.label59.TabIndex = 1035;
            this.label59.Text = "دور / طابق";
            this.label59.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label67
            // 
            this.label67.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label67.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label67.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label67.ForeColor = System.Drawing.Color.Black;
            this.label67.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label67.Location = new System.Drawing.Point(509, 208);
            this.label67.Name = "label67";
            this.label67.Size = new System.Drawing.Size(263, 28);
            this.label67.TabIndex = 1028;
            this.label67.Text = "حساب الأب للنزلاء الفندق";
            this.label67.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label66
            // 
            this.label66.BackColor = System.Drawing.Color.Transparent;
            this.label66.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label66.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label66.ForeColor = System.Drawing.Color.Black;
            this.label66.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label66.Location = new System.Drawing.Point(240, 147);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(147, 21);
            this.label66.TabIndex = 1026;
            this.label66.Text = "يوم";
            this.label66.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtDayofMonth
            // 
            this.txtDayofMonth.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtDayofMonth.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtDayofMonth.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtDayofMonth.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDayofMonth.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtDayofMonth.DisplayFormat = "0";
            this.txtDayofMonth.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtDayofMonth.ForeColor = System.Drawing.Color.Black;
            this.txtDayofMonth.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtDayofMonth.Location = new System.Drawing.Point(393, 147);
            this.txtDayofMonth.MaxValue = 31;
            this.txtDayofMonth.MinValue = 28;
            this.txtDayofMonth.Name = "txtDayofMonth";
            this.txtDayofMonth.ShowUpDown = true;
            this.txtDayofMonth.Size = new System.Drawing.Size(110, 21);
            this.txtDayofMonth.TabIndex = 1025;
            this.txtDayofMonth.Value = 30;
            this.txtDayofMonth.WatermarkAlignment = DevComponents.Editors.eTextAlignment.Center;
            this.txtDayofMonth.WatermarkColor = System.Drawing.Color.White;
            // 
            // groupBox6
            // 
            this.groupBox6.BackColor = System.Drawing.Color.Transparent;
            this.groupBox6.Controls.Add(this.checkBoxX1);
            this.groupBox6.Controls.Add(this.RadioBox_LeavePM);
            this.groupBox6.Controls.Add(this.RadioBox_LeaveAM);
            this.groupBox6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.groupBox6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupBox6.Location = new System.Drawing.Point(240, 107);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox6.Size = new System.Drawing.Size(147, 30);
            this.groupBox6.TabIndex = 1024;
            this.groupBox6.TabStop = false;
            // 
            // checkBoxX1
            // 
            this.checkBoxX1.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
            this.checkBoxX1.AutoSize = true;
            this.checkBoxX1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.checkBoxX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBoxX1.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.checkBoxX1.CheckSignSize = new System.Drawing.Size(14, 14);
            this.checkBoxX1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.checkBoxX1.Location = new System.Drawing.Point(59, 54);
            this.checkBoxX1.Name = "checkBoxX1";
            this.checkBoxX1.Size = new System.Drawing.Size(63, 16);
            this.checkBoxX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBoxX1.TabIndex = 1022;
            this.checkBoxX1.Text = "شبكـــة";
            // 
            // RadioBox_LeavePM
            // 
            this.RadioBox_LeavePM.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
            this.RadioBox_LeavePM.AutoSize = true;
            this.RadioBox_LeavePM.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.RadioBox_LeavePM.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.RadioBox_LeavePM.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.RadioBox_LeavePM.Checked = true;
            this.RadioBox_LeavePM.CheckSignSize = new System.Drawing.Size(14, 14);
            this.RadioBox_LeavePM.CheckState = System.Windows.Forms.CheckState.Checked;
            this.RadioBox_LeavePM.CheckValue = "Y";
            this.RadioBox_LeavePM.Font = new System.Drawing.Font("Tahoma", 6F, System.Drawing.FontStyle.Bold);
            this.RadioBox_LeavePM.Location = new System.Drawing.Point(32, 9);
            this.RadioBox_LeavePM.Name = "RadioBox_LeavePM";
            this.RadioBox_LeavePM.Size = new System.Drawing.Size(29, 16);
            this.RadioBox_LeavePM.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.RadioBox_LeavePM.TabIndex = 16;
            this.RadioBox_LeavePM.Text = "م";
            // 
            // RadioBox_LeaveAM
            // 
            this.RadioBox_LeaveAM.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
            this.RadioBox_LeaveAM.AutoSize = true;
            this.RadioBox_LeaveAM.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.RadioBox_LeaveAM.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.RadioBox_LeaveAM.BackgroundStyle.TextShadowColor = System.Drawing.SystemColors.ControlLight;
            this.RadioBox_LeaveAM.BackgroundStyle.TextShadowOffset = new System.Drawing.Point(3, 3);
            this.RadioBox_LeaveAM.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.RadioBox_LeaveAM.CheckSignSize = new System.Drawing.Size(14, 14);
            this.RadioBox_LeaveAM.Font = new System.Drawing.Font("Tahoma", 6F, System.Drawing.FontStyle.Bold);
            this.RadioBox_LeaveAM.Location = new System.Drawing.Point(92, 9);
            this.RadioBox_LeaveAM.Name = "RadioBox_LeaveAM";
            this.RadioBox_LeaveAM.Size = new System.Drawing.Size(35, 16);
            this.RadioBox_LeaveAM.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.RadioBox_LeaveAM.TabIndex = 15;
            this.RadioBox_LeaveAM.Text = "ص";
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.Color.Transparent;
            this.groupBox5.Controls.Add(this.checkBox_NetWork);
            this.groupBox5.Controls.Add(this.RadioBox_AllowPM);
            this.groupBox5.Controls.Add(this.RadioBox_AllowAM);
            this.groupBox5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.groupBox5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupBox5.Location = new System.Drawing.Point(240, 73);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox5.Size = new System.Drawing.Size(147, 30);
            this.groupBox5.TabIndex = 1023;
            this.groupBox5.TabStop = false;
            // 
            // checkBox_NetWork
            // 
            this.checkBox_NetWork.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
            this.checkBox_NetWork.AutoSize = true;
            this.checkBox_NetWork.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.checkBox_NetWork.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBox_NetWork.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.checkBox_NetWork.CheckSignSize = new System.Drawing.Size(14, 14);
            this.checkBox_NetWork.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.checkBox_NetWork.Location = new System.Drawing.Point(59, 54);
            this.checkBox_NetWork.Name = "checkBox_NetWork";
            this.checkBox_NetWork.Size = new System.Drawing.Size(63, 16);
            this.checkBox_NetWork.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBox_NetWork.TabIndex = 1022;
            this.checkBox_NetWork.Text = "شبكـــة";
            // 
            // RadioBox_AllowPM
            // 
            this.RadioBox_AllowPM.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
            this.RadioBox_AllowPM.AutoSize = true;
            this.RadioBox_AllowPM.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.RadioBox_AllowPM.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.RadioBox_AllowPM.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.RadioBox_AllowPM.CheckSignSize = new System.Drawing.Size(14, 14);
            this.RadioBox_AllowPM.Font = new System.Drawing.Font("Tahoma", 6F, System.Drawing.FontStyle.Bold);
            this.RadioBox_AllowPM.Location = new System.Drawing.Point(32, 9);
            this.RadioBox_AllowPM.Name = "RadioBox_AllowPM";
            this.RadioBox_AllowPM.Size = new System.Drawing.Size(29, 16);
            this.RadioBox_AllowPM.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.RadioBox_AllowPM.TabIndex = 16;
            this.RadioBox_AllowPM.Text = "م";
            // 
            // RadioBox_AllowAM
            // 
            this.RadioBox_AllowAM.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
            this.RadioBox_AllowAM.AutoSize = true;
            this.RadioBox_AllowAM.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.RadioBox_AllowAM.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.RadioBox_AllowAM.BackgroundStyle.TextShadowColor = System.Drawing.SystemColors.ControlLight;
            this.RadioBox_AllowAM.BackgroundStyle.TextShadowOffset = new System.Drawing.Point(3, 3);
            this.RadioBox_AllowAM.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.RadioBox_AllowAM.Checked = true;
            this.RadioBox_AllowAM.CheckSignSize = new System.Drawing.Size(14, 14);
            this.RadioBox_AllowAM.CheckState = System.Windows.Forms.CheckState.Checked;
            this.RadioBox_AllowAM.CheckValue = "Y";
            this.RadioBox_AllowAM.Font = new System.Drawing.Font("Tahoma", 6F, System.Drawing.FontStyle.Bold);
            this.RadioBox_AllowAM.Location = new System.Drawing.Point(92, 9);
            this.RadioBox_AllowAM.Name = "RadioBox_AllowAM";
            this.RadioBox_AllowAM.Size = new System.Drawing.Size(35, 16);
            this.RadioBox_AllowAM.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.RadioBox_AllowAM.TabIndex = 15;
            this.RadioBox_AllowAM.Text = "ص";
            // 
            // txtLeavePeriod
            // 
            this.txtLeavePeriod.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.txtLeavePeriod.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.txtLeavePeriod.ForeColor = System.Drawing.Color.White;
            this.txtLeavePeriod.Location = new System.Drawing.Point(393, 115);
            this.txtLeavePeriod.Mask = "##:##:##";
            this.txtLeavePeriod.Name = "txtLeavePeriod";
            this.txtLeavePeriod.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtLeavePeriod.Size = new System.Drawing.Size(110, 21);
            this.txtLeavePeriod.TabIndex = 989;
            this.txtLeavePeriod.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtLeavePeriod.Click += new System.EventHandler(this.txtLeavePeriod_Click);
            this.txtLeavePeriod.Leave += new System.EventHandler(this.txtLeavePeriod_Leave);
            // 
            // txtAllowPeriod
            // 
            this.txtAllowPeriod.BackColor = System.Drawing.Color.Maroon;
            this.txtAllowPeriod.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.txtAllowPeriod.ForeColor = System.Drawing.Color.White;
            this.txtAllowPeriod.Location = new System.Drawing.Point(393, 83);
            this.txtAllowPeriod.Mask = "##:##:##";
            this.txtAllowPeriod.Name = "txtAllowPeriod";
            this.txtAllowPeriod.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtAllowPeriod.Size = new System.Drawing.Size(110, 21);
            this.txtAllowPeriod.TabIndex = 988;
            this.txtAllowPeriod.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtAllowPeriod.Click += new System.EventHandler(this.txtAllowPeriod_Click);
            this.txtAllowPeriod.Leave += new System.EventHandler(this.txtAllowPeriod_Leave);
            // 
            // label62
            // 
            this.label62.BackColor = System.Drawing.Color.Transparent;
            this.label62.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label62.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label62.ForeColor = System.Drawing.Color.Black;
            this.label62.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label62.Location = new System.Drawing.Point(310, 51);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(77, 21);
            this.label62.TabIndex = 984;
            this.label62.Text = "غرفة / شقة";
            this.label62.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtRoom
            // 
            this.txtRoom.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtRoom.BackgroundStyle.BackColor = System.Drawing.Color.SlateGray;
            this.txtRoom.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtRoom.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtRoom.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtRoom.DisplayFormat = "0";
            this.txtRoom.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtRoom.ForeColor = System.Drawing.Color.White;
            this.txtRoom.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtRoom.IsInputReadOnly = true;
            this.txtRoom.Location = new System.Drawing.Point(393, 51);
            this.txtRoom.MinValue = 1;
            this.txtRoom.Name = "txtRoom";
            this.txtRoom.Size = new System.Drawing.Size(110, 21);
            this.txtRoom.TabIndex = 983;
            this.txtRoom.Value = 1;
            this.txtRoom.Visible = false;
            this.txtRoom.WatermarkAlignment = DevComponents.Editors.eTextAlignment.Center;
            // 
            // txtFloors
            // 
            this.txtFloors.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtFloors.BackgroundStyle.BackColor = System.Drawing.Color.SlateGray;
            this.txtFloors.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtFloors.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtFloors.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtFloors.DisplayFormat = "0";
            this.txtFloors.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtFloors.ForeColor = System.Drawing.Color.White;
            this.txtFloors.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtFloors.Location = new System.Drawing.Point(393, 19);
            this.txtFloors.MinValue = 1;
            this.txtFloors.Name = "txtFloors";
            this.txtFloors.Size = new System.Drawing.Size(110, 21);
            this.txtFloors.TabIndex = 980;
            this.txtFloors.Value = 1;
            this.txtFloors.WatermarkAlignment = DevComponents.Editors.eTextAlignment.Center;
            // 
            // checkBoxX3
            // 
            this.checkBoxX3.AutoSize = true;
            this.checkBoxX3.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.checkBoxX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBoxX3.Location = new System.Drawing.Point(771, 119);
            this.checkBoxX3.Name = "checkBoxX3";
            this.checkBoxX3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBoxX3.Size = new System.Drawing.Size(148, 15);
            this.checkBoxX3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBoxX3.TabIndex = 976;
            this.checkBoxX3.Text = "تحديد كفيل لكل موظف جديد";
            // 
            // label65
            // 
            this.label65.BackColor = System.Drawing.Color.Transparent;
            this.label65.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label65.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label65.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label65.Location = new System.Drawing.Point(509, 147);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(263, 21);
            this.label65.TabIndex = 1027;
            this.label65.Text = "عدد أيام الشهر";
            this.label65.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label64
            // 
            this.label64.BackColor = System.Drawing.Color.Transparent;
            this.label64.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label64.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label64.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label64.Location = new System.Drawing.Point(509, 115);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(263, 21);
            this.label64.TabIndex = 987;
            this.label64.Text = "فترة المغادرة";
            this.label64.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label63
            // 
            this.label63.BackColor = System.Drawing.Color.Transparent;
            this.label63.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label63.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label63.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label63.Location = new System.Drawing.Point(509, 83);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(263, 21);
            this.label63.TabIndex = 986;
            this.label63.Text = "فترة السماح";
            this.label63.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label61
            // 
            this.label61.BackColor = System.Drawing.Color.Transparent;
            this.label61.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label61.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label61.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label61.Location = new System.Drawing.Point(509, 51);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(263, 21);
            this.label61.TabIndex = 985;
            this.label61.Text = "عدد الغرف / الشقق  في الدور";
            this.label61.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label61.Visible = false;
            // 
            // label60
            // 
            this.label60.BackColor = System.Drawing.Color.Transparent;
            this.label60.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label60.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label60.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label60.Location = new System.Drawing.Point(509, 19);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(263, 21);
            this.label60.TabIndex = 982;
            this.label60.Text = "عدد الأدوار/ طوابق في الفندق";
            this.label60.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label68
            // 
            this.label68.BackColor = System.Drawing.Color.Transparent;
            this.label68.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label68.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label68.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label68.Location = new System.Drawing.Point(654, 180);
            this.label68.Name = "label68";
            this.label68.Size = new System.Drawing.Size(118, 21);
            this.label68.TabIndex = 1031;
            this.label68.Text = "البعد الطولي";
            this.label68.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label69
            // 
            this.label69.BackColor = System.Drawing.Color.Transparent;
            this.label69.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label69.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label69.ForeColor = System.Drawing.Color.Black;
            this.label69.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label69.Location = new System.Drawing.Point(509, 180);
            this.label69.Name = "label69";
            this.label69.Size = new System.Drawing.Size(64, 21);
            this.label69.TabIndex = 1030;
            this.label69.Text = "نقطة";
            this.label69.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtLongitudinal
            // 
            this.txtLongitudinal.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtLongitudinal.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
            this.txtLongitudinal.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtLongitudinal.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtLongitudinal.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtLongitudinal.DisplayFormat = "0";
            this.txtLongitudinal.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtLongitudinal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtLongitudinal.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtLongitudinal.Location = new System.Drawing.Point(577, 180);
            this.txtLongitudinal.MaxValue = 1000;
            this.txtLongitudinal.MinValue = 50;
            this.txtLongitudinal.Name = "txtLongitudinal";
            this.txtLongitudinal.ShowUpDown = true;
            this.txtLongitudinal.Size = new System.Drawing.Size(74, 21);
            this.txtLongitudinal.TabIndex = 1029;
            this.txtLongitudinal.Value = 50;
            this.txtLongitudinal.WatermarkAlignment = DevComponents.Editors.eTextAlignment.Center;
            // 
            // label70
            // 
            this.label70.BackColor = System.Drawing.Color.Transparent;
            this.label70.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label70.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label70.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label70.Location = new System.Drawing.Point(393, 180);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(110, 21);
            this.label70.TabIndex = 1034;
            this.label70.Text = "البعد العرضي";
            this.label70.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label71
            // 
            this.label71.BackColor = System.Drawing.Color.Transparent;
            this.label71.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label71.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label71.ForeColor = System.Drawing.Color.Black;
            this.label71.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label71.Location = new System.Drawing.Point(241, 180);
            this.label71.Name = "label71";
            this.label71.Size = new System.Drawing.Size(64, 21);
            this.label71.TabIndex = 1033;
            this.label71.Text = "نقطة";
            this.label71.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtWidthitudinal
            // 
            this.txtWidthitudinal.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtWidthitudinal.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
            this.txtWidthitudinal.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtWidthitudinal.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtWidthitudinal.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtWidthitudinal.DisplayFormat = "0";
            this.txtWidthitudinal.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtWidthitudinal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtWidthitudinal.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtWidthitudinal.Location = new System.Drawing.Point(313, 180);
            this.txtWidthitudinal.MaxValue = 1000;
            this.txtWidthitudinal.MinValue = 50;
            this.txtWidthitudinal.Name = "txtWidthitudinal";
            this.txtWidthitudinal.ShowUpDown = true;
            this.txtWidthitudinal.Size = new System.Drawing.Size(74, 21);
            this.txtWidthitudinal.TabIndex = 1032;
            this.txtWidthitudinal.Value = 50;
            this.txtWidthitudinal.WatermarkAlignment = DevComponents.Editors.eTextAlignment.Center;
            // 
            // chk44
            // 
            this.chk44.AutoSize = true;
            this.chk44.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chk44.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chk44.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.chk44.Location = new System.Drawing.Point(27, 97);
            this.chk44.Name = "chk44";
            this.chk44.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chk44.Size = new System.Drawing.Size(174, 16);
            this.chk44.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chk44.TabIndex = 1047;
            this.chk44.Text = "اضافة المديونية الى حساب النزيل";
            // 
            // superTabItem_Hotel
            // 
            this.superTabItem_Hotel.AttachedControl = this.superTabControlPanel7;
            this.superTabItem_Hotel.GlobalItem = false;
            this.superTabItem_Hotel.Name = "superTabItem_Hotel";
            this.superTabItem_Hotel.Text = "خيارات الفندق";
            this.superTabItem_Hotel.Visible = false;
            // 
            // superTabControlPanel11
            // 
            this.superTabControlPanel11.Controls.Add(this.pictureBox1);
            this.superTabControlPanel11.Controls.Add(this.groupPanel13);
            this.superTabControlPanel11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel11.Location = new System.Drawing.Point(0, 0);
            this.superTabControlPanel11.Name = "superTabControlPanel11";
            this.superTabControlPanel11.Size = new System.Drawing.Size(1069, 514);
            this.superTabControlPanel11.TabIndex = 2;
            this.superTabControlPanel11.TabItem = this.superTabItem_Eqar;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Image = global::InvAcc.Properties.Resources.Untitled_2_copy;
            this.pictureBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBox1.Location = new System.Drawing.Point(6, 193);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(785, 276);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 970;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // groupPanel13
            // 
            this.groupPanel13.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel13.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel13.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel13.Controls.Add(this.chk77);
            this.groupPanel13.Controls.Add(this.chk76);
            this.groupPanel13.Controls.Add(this.txttenantFatherAccName);
            this.groupPanel13.Controls.Add(this.txtEqarsFatherAccName);
            this.groupPanel13.Controls.Add(this.txtTenantFatherAcc);
            this.groupPanel13.Controls.Add(this.label90);
            this.groupPanel13.Controls.Add(this.txtEqarsFatherAcc);
            this.groupPanel13.Controls.Add(this.label91);
            this.groupPanel13.Controls.Add(this.label92);
            this.groupPanel13.Controls.Add(this.label94);
            this.groupPanel13.Controls.Add(this.txtEqarDayOfPayAlarm);
            this.groupPanel13.Controls.Add(this.txtEqarContractEndAlarm);
            this.groupPanel13.Controls.Add(this.checkBoxX14);
            this.groupPanel13.Controls.Add(this.label98);
            this.groupPanel13.Controls.Add(this.label99);
            this.groupPanel13.Controls.Add(this.button_RestoreDefContract);
            this.groupPanel13.Location = new System.Drawing.Point(6, 4);
            this.groupPanel13.Name = "groupPanel13";
            this.groupPanel13.Size = new System.Drawing.Size(786, 185);
            // 
            // 
            // 
            this.groupPanel13.Style.BackColor2 = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupPanel13.Style.BackColorGradientAngle = 90;
            this.groupPanel13.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
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
            this.groupPanel13.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Far;
            this.groupPanel13.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            // 
            // 
            // 
            this.groupPanel13.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel13.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel13.TabIndex = 969;
            // 
            // chk77
            // 
            // 
            // 
            // 
            this.chk77.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chk77.CheckSignSize = new System.Drawing.Size(20, 20);
            this.chk77.Location = new System.Drawing.Point(744, 56);
            this.chk77.Name = "chk77";
            this.chk77.Size = new System.Drawing.Size(21, 27);
            this.chk77.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chk77.TabIndex = 1051;
            // 
            // chk76
            // 
            // 
            // 
            // 
            this.chk76.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chk76.CheckSignSize = new System.Drawing.Size(20, 20);
            this.chk76.Location = new System.Drawing.Point(744, 25);
            this.chk76.Name = "chk76";
            this.chk76.Size = new System.Drawing.Size(21, 27);
            this.chk76.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chk76.TabIndex = 1050;
            // 
            // txttenantFatherAccName
            // 
            this.txttenantFatherAccName.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txttenantFatherAccName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txttenantFatherAccName.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.txttenantFatherAccName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txttenantFatherAccName.Location = new System.Drawing.Point(18, 121);
            this.txttenantFatherAccName.Name = "txttenantFatherAccName";
            this.txttenantFatherAccName.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txttenantFatherAccName, false);
            this.txttenantFatherAccName.Size = new System.Drawing.Size(237, 16);
            this.txttenantFatherAccName.TabIndex = 1043;
            this.txttenantFatherAccName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtEqarsFatherAccName
            // 
            this.txtEqarsFatherAccName.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtEqarsFatherAccName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtEqarsFatherAccName.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.txtEqarsFatherAccName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtEqarsFatherAccName.Location = new System.Drawing.Point(394, 121);
            this.txtEqarsFatherAccName.Name = "txtEqarsFatherAccName";
            this.txtEqarsFatherAccName.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtEqarsFatherAccName, false);
            this.txtEqarsFatherAccName.Size = new System.Drawing.Size(237, 16);
            this.txtEqarsFatherAccName.TabIndex = 1042;
            this.txtEqarsFatherAccName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTenantFatherAcc
            // 
            this.txtTenantFatherAcc.BackColor = System.Drawing.SystemColors.Control;
            // 
            // 
            // 
            this.txtTenantFatherAcc.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtTenantFatherAcc.ButtonCustom.Visible = true;
            this.txtTenantFatherAcc.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.txtTenantFatherAcc.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtTenantFatherAcc.Location = new System.Drawing.Point(258, 121);
            this.txtTenantFatherAcc.Name = "txtTenantFatherAcc";
            this.txtTenantFatherAcc.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtTenantFatherAcc, false);
            this.txtTenantFatherAcc.Size = new System.Drawing.Size(132, 16);
            this.txtTenantFatherAcc.TabIndex = 1039;
            this.txtTenantFatherAcc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTenantFatherAcc.ButtonCustomClick += new System.EventHandler(this.txtTenantFatherAcc_ButtonCustomClick);
            this.txtTenantFatherAcc.Click += new System.EventHandler(this.txtTenantFatherAcc_Click);
            // 
            // label90
            // 
            this.label90.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label90.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label90.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label90.ForeColor = System.Drawing.Color.Black;
            this.label90.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label90.Location = new System.Drawing.Point(18, 88);
            this.label90.Name = "label90";
            this.label90.Size = new System.Drawing.Size(372, 28);
            this.label90.TabIndex = 1038;
            this.label90.Text = "الحساب الأب للمستأجــــرين";
            this.label90.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtEqarsFatherAcc
            // 
            this.txtEqarsFatherAcc.BackColor = System.Drawing.SystemColors.Control;
            // 
            // 
            // 
            this.txtEqarsFatherAcc.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtEqarsFatherAcc.ButtonCustom.Visible = true;
            this.txtEqarsFatherAcc.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.txtEqarsFatherAcc.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtEqarsFatherAcc.Location = new System.Drawing.Point(633, 121);
            this.txtEqarsFatherAcc.Name = "txtEqarsFatherAcc";
            this.txtEqarsFatherAcc.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtEqarsFatherAcc, false);
            this.txtEqarsFatherAcc.Size = new System.Drawing.Size(132, 16);
            this.txtEqarsFatherAcc.TabIndex = 1037;
            this.txtEqarsFatherAcc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtEqarsFatherAcc.ButtonCustomClick += new System.EventHandler(this.txtEqarsFatherAcc_ButtonCustomClick);
            this.txtEqarsFatherAcc.Click += new System.EventHandler(this.txtEqarsFatherAcc_Click);
            // 
            // label91
            // 
            this.label91.BackColor = System.Drawing.Color.Transparent;
            this.label91.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label91.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label91.ForeColor = System.Drawing.Color.Black;
            this.label91.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label91.Location = new System.Drawing.Point(18, 28);
            this.label91.Name = "label91";
            this.label91.Size = new System.Drawing.Size(205, 21);
            this.label91.TabIndex = 1035;
            this.label91.Text = "يــــــــــــــــوم";
            this.label91.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label92
            // 
            this.label92.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label92.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label92.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label92.ForeColor = System.Drawing.Color.Black;
            this.label92.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label92.Location = new System.Drawing.Point(393, 88);
            this.label92.Name = "label92";
            this.label92.Size = new System.Drawing.Size(372, 28);
            this.label92.TabIndex = 1028;
            this.label92.Text = "حساب الأب للعقــــــارات";
            this.label92.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label94
            // 
            this.label94.BackColor = System.Drawing.Color.Transparent;
            this.label94.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label94.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label94.ForeColor = System.Drawing.Color.Black;
            this.label94.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label94.Location = new System.Drawing.Point(18, 58);
            this.label94.Name = "label94";
            this.label94.Size = new System.Drawing.Size(205, 21);
            this.label94.TabIndex = 984;
            this.label94.Text = "في الشهـــر";
            this.label94.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtEqarDayOfPayAlarm
            // 
            this.txtEqarDayOfPayAlarm.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtEqarDayOfPayAlarm.BackgroundStyle.BackColor = System.Drawing.Color.SlateGray;
            this.txtEqarDayOfPayAlarm.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtEqarDayOfPayAlarm.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtEqarDayOfPayAlarm.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtEqarDayOfPayAlarm.DisplayFormat = "0";
            this.txtEqarDayOfPayAlarm.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtEqarDayOfPayAlarm.ForeColor = System.Drawing.Color.White;
            this.txtEqarDayOfPayAlarm.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtEqarDayOfPayAlarm.Location = new System.Drawing.Point(225, 58);
            this.txtEqarDayOfPayAlarm.MinValue = 1;
            this.txtEqarDayOfPayAlarm.Name = "txtEqarDayOfPayAlarm";
            this.txtEqarDayOfPayAlarm.ShowUpDown = true;
            this.txtEqarDayOfPayAlarm.Size = new System.Drawing.Size(165, 21);
            this.txtEqarDayOfPayAlarm.TabIndex = 983;
            this.txtEqarDayOfPayAlarm.Value = 1;
            this.txtEqarDayOfPayAlarm.WatermarkAlignment = DevComponents.Editors.eTextAlignment.Center;
            // 
            // txtEqarContractEndAlarm
            // 
            this.txtEqarContractEndAlarm.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtEqarContractEndAlarm.BackgroundStyle.BackColor = System.Drawing.Color.SlateGray;
            this.txtEqarContractEndAlarm.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtEqarContractEndAlarm.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtEqarContractEndAlarm.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtEqarContractEndAlarm.DisplayFormat = "0";
            this.txtEqarContractEndAlarm.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtEqarContractEndAlarm.ForeColor = System.Drawing.Color.White;
            this.txtEqarContractEndAlarm.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtEqarContractEndAlarm.Location = new System.Drawing.Point(225, 28);
            this.txtEqarContractEndAlarm.MinValue = 1;
            this.txtEqarContractEndAlarm.Name = "txtEqarContractEndAlarm";
            this.txtEqarContractEndAlarm.ShowUpDown = true;
            this.txtEqarContractEndAlarm.Size = new System.Drawing.Size(165, 21);
            this.txtEqarContractEndAlarm.TabIndex = 980;
            this.txtEqarContractEndAlarm.Value = 1;
            this.txtEqarContractEndAlarm.WatermarkAlignment = DevComponents.Editors.eTextAlignment.Center;
            // 
            // checkBoxX14
            // 
            this.checkBoxX14.AutoSize = true;
            this.checkBoxX14.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.checkBoxX14.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBoxX14.Location = new System.Drawing.Point(771, 119);
            this.checkBoxX14.Name = "checkBoxX14";
            this.checkBoxX14.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBoxX14.Size = new System.Drawing.Size(148, 15);
            this.checkBoxX14.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBoxX14.TabIndex = 976;
            this.checkBoxX14.Text = "تحديد كفيل لكل موظف جديد";
            // 
            // label98
            // 
            this.label98.BackColor = System.Drawing.Color.Transparent;
            this.label98.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label98.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label98.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label98.Location = new System.Drawing.Point(394, 58);
            this.label98.Name = "label98";
            this.label98.Size = new System.Drawing.Size(348, 21);
            this.label98.TabIndex = 985;
            this.label98.Text = "تبيه بموعد تحصيل الإيجارات قبل ";
            this.label98.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label99
            // 
            this.label99.BackColor = System.Drawing.Color.Transparent;
            this.label99.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label99.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label99.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label99.Location = new System.Drawing.Point(394, 28);
            this.label99.Name = "label99";
            this.label99.Size = new System.Drawing.Size(348, 21);
            this.label99.TabIndex = 982;
            this.label99.Text = "تنبيه بالعقود المنتهية قبل ";
            this.label99.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button_RestoreDefContract
            // 
            this.button_RestoreDefContract.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_RestoreDefContract.Checked = true;
            this.button_RestoreDefContract.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.button_RestoreDefContract.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.button_RestoreDefContract.Location = new System.Drawing.Point(18, 142);
            this.button_RestoreDefContract.Name = "button_RestoreDefContract";
            this.button_RestoreDefContract.Size = new System.Drawing.Size(372, 33);
            this.button_RestoreDefContract.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_RestoreDefContract.Symbol = "";
            this.button_RestoreDefContract.SymbolSize = 11F;
            this.button_RestoreDefContract.TabIndex = 1052;
            this.button_RestoreDefContract.Text = "إستعادة تصميم العقـد الإفتراضـــي";
            this.button_RestoreDefContract.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button_RestoreDefContract.Click += new System.EventHandler(this.button_RestoreDefContract_Click);
            // 
            // superTabItem_Eqar
            // 
            this.superTabItem_Eqar.AttachedControl = this.superTabControlPanel11;
            this.superTabItem_Eqar.GlobalItem = false;
            this.superTabItem_Eqar.Name = "superTabItem_Eqar";
            this.superTabItem_Eqar.Text = "خيارات العقار";
            this.superTabItem_Eqar.Visible = false;
            // 
            // superTabControlPanel14
            // 
            this.superTabControlPanel14.AutoScroll = true;
            this.superTabControlPanel14.CanvasColor = System.Drawing.Color.Gainsboro;
            this.superTabControlPanel14.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Windows7;
            this.superTabControlPanel14.Controls.Add(this.button_PointOfCust);
            this.superTabControlPanel14.Controls.Add(this.groupPanel15);
            this.superTabControlPanel14.Controls.Add(this.groupPanel14);
            this.superTabControlPanel14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel14.Location = new System.Drawing.Point(0, 0);
            this.superTabControlPanel14.Name = "superTabControlPanel14";
            superTabLinearGradientColorTable6.Colors = new System.Drawing.Color[] {
        System.Drawing.Color.Gainsboro};
            superTabPanelItemColorTable6.Background = superTabLinearGradientColorTable6;
            superTabPanelColorTable6.Default = superTabPanelItemColorTable6;
            this.superTabControlPanel14.PanelColor = superTabPanelColorTable6;
            this.superTabControlPanel14.Size = new System.Drawing.Size(1069, 514);
            this.superTabControlPanel14.TabIndex = 0;
            this.superTabControlPanel14.TabItem = this.superTabItem6;
            // 
            // button_PointOfCust
            // 
            this.button_PointOfCust.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_PointOfCust.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.button_PointOfCust.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button_PointOfCust.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold);
            this.button_PointOfCust.Location = new System.Drawing.Point(0, 461);
            this.button_PointOfCust.Name = "button_PointOfCust";
            this.button_PointOfCust.Size = new System.Drawing.Size(1069, 53);
            this.button_PointOfCust.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2003;
            this.button_PointOfCust.Symbol = "";
            this.button_PointOfCust.SymbolSize = 16F;
            this.button_PointOfCust.TabIndex = 6789;
            this.button_PointOfCust.Text = "نقاط العملاء";
            this.button_PointOfCust.TextColor = System.Drawing.Color.White;
            this.button_PointOfCust.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // groupPanel15
            // 
            this.groupPanel15.BackColor = System.Drawing.Color.Gainsboro;
            this.groupPanel15.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel15.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel15.Controls.Add(this.checkBox_BalanceActivated);
            this.groupPanel15.Controls.Add(this.groupBox7);
            this.groupPanel15.Font = new System.Drawing.Font("Tahoma", 8F);
            this.groupPanel15.Location = new System.Drawing.Point(5, 3);
            this.groupPanel15.Name = "groupPanel15";
            this.groupPanel15.Size = new System.Drawing.Size(436, 323);
            // 
            // 
            // 
            this.groupPanel15.Style.BackColor = System.Drawing.Color.Gainsboro;
            this.groupPanel15.Style.BackColor2 = System.Drawing.Color.Gainsboro;
            this.groupPanel15.Style.BackColorGradientAngle = 90;
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
            this.groupPanel15.TabIndex = 883;
            this.groupPanel15.Text = "اعدادات الميزان";
            // 
            // checkBox_BalanceActivated
            // 
            this.checkBox_BalanceActivated.AutoSize = true;
            this.checkBox_BalanceActivated.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.checkBox_BalanceActivated.ForeColor = System.Drawing.Color.Blue;
            this.checkBox_BalanceActivated.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.checkBox_BalanceActivated.Location = new System.Drawing.Point(226, 10);
            this.checkBox_BalanceActivated.Name = "checkBox_BalanceActivated";
            this.checkBox_BalanceActivated.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBox_BalanceActivated.Size = new System.Drawing.Size(174, 17);
            this.checkBox_BalanceActivated.TabIndex = 1022;
            this.checkBox_BalanceActivated.Text = "تفعيل خاصية الميزان مع الأصناف";
            this.checkBox_BalanceActivated.UseVisualStyleBackColor = true;
            // 
            // groupBox7
            // 
            this.groupBox7.BackColor = System.Drawing.Color.Transparent;
            this.groupBox7.Controls.Add(this.txtPriceQ);
            this.groupBox7.Controls.Add(this.label85);
            this.groupBox7.Controls.Add(this.txtWieghtQ);
            this.groupBox7.Controls.Add(this.label86);
            this.groupBox7.Controls.Add(this.txtPriceTo);
            this.groupBox7.Controls.Add(this.txtPriceFrom);
            this.groupBox7.Controls.Add(this.txtWightTo);
            this.groupBox7.Controls.Add(this.txtWightFrom);
            this.groupBox7.Controls.Add(this.txtBarcodTo);
            this.groupBox7.Controls.Add(this.txtBarcodFrom);
            this.groupBox7.Controls.Add(this.label87);
            this.groupBox7.Controls.Add(this.label88);
            this.groupBox7.Controls.Add(this.groupBox8);
            this.groupBox7.Controls.Add(this.label89);
            this.groupBox7.Controls.Add(this.label93);
            this.groupBox7.Controls.Add(this.label95);
            this.groupBox7.Controls.Add(this.label96);
            this.groupBox7.Enabled = false;
            this.groupBox7.Location = new System.Drawing.Point(0, 28);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(433, 248);
            this.groupBox7.TabIndex = 1022;
            this.groupBox7.TabStop = false;
            // 
            // txtPriceQ
            // 
            this.txtPriceQ.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtPriceQ.BackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.DockSiteBackColor2;
            this.txtPriceQ.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtPriceQ.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtPriceQ.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtPriceQ.DisplayFormat = "0";
            this.txtPriceQ.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtPriceQ.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtPriceQ.Location = new System.Drawing.Point(5, 137);
            this.txtPriceQ.MinValue = 0;
            this.txtPriceQ.Name = "txtPriceQ";
            this.txtPriceQ.ShowUpDown = true;
            this.txtPriceQ.Size = new System.Drawing.Size(68, 21);
            this.txtPriceQ.TabIndex = 1013;
            // 
            // label85
            // 
            this.label85.AutoSize = true;
            this.label85.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label85.Location = new System.Drawing.Point(76, 141);
            this.label85.Name = "label85";
            this.label85.Size = new System.Drawing.Size(156, 13);
            this.label85.TabIndex = 1012;
            this.label85.Text = "بداية فاصلة السعر العشرية بعد :";
            // 
            // txtWieghtQ
            // 
            this.txtWieghtQ.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtWieghtQ.BackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.DockSiteBackColor2;
            this.txtWieghtQ.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtWieghtQ.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtWieghtQ.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtWieghtQ.DisplayFormat = "0";
            this.txtWieghtQ.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtWieghtQ.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtWieghtQ.Location = new System.Drawing.Point(6, 113);
            this.txtWieghtQ.MinValue = 0;
            this.txtWieghtQ.Name = "txtWieghtQ";
            this.txtWieghtQ.ShowUpDown = true;
            this.txtWieghtQ.Size = new System.Drawing.Size(68, 21);
            this.txtWieghtQ.TabIndex = 1011;
            // 
            // label86
            // 
            this.label86.AutoSize = true;
            this.label86.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label86.Location = new System.Drawing.Point(77, 117);
            this.label86.Name = "label86";
            this.label86.Size = new System.Drawing.Size(155, 13);
            this.label86.TabIndex = 1010;
            this.label86.Text = "بداية فاصلة الــوزن العشرية بعد :";
            // 
            // txtPriceTo
            // 
            this.txtPriceTo.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtPriceTo.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(198)))));
            this.txtPriceTo.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtPriceTo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtPriceTo.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtPriceTo.DisplayFormat = "0";
            this.txtPriceTo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtPriceTo.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtPriceTo.Location = new System.Drawing.Point(250, 185);
            this.txtPriceTo.MinValue = 1;
            this.txtPriceTo.Name = "txtPriceTo";
            this.txtPriceTo.ShowUpDown = true;
            this.txtPriceTo.Size = new System.Drawing.Size(68, 21);
            this.txtPriceTo.TabIndex = 1009;
            this.txtPriceTo.Value = 1;
            // 
            // txtPriceFrom
            // 
            this.txtPriceFrom.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtPriceFrom.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(198)))));
            this.txtPriceFrom.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtPriceFrom.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtPriceFrom.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtPriceFrom.DisplayFormat = "0";
            this.txtPriceFrom.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtPriceFrom.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtPriceFrom.Location = new System.Drawing.Point(250, 161);
            this.txtPriceFrom.MinValue = 1;
            this.txtPriceFrom.Name = "txtPriceFrom";
            this.txtPriceFrom.ShowUpDown = true;
            this.txtPriceFrom.Size = new System.Drawing.Size(68, 21);
            this.txtPriceFrom.TabIndex = 1008;
            this.txtPriceFrom.Value = 1;
            // 
            // txtWightTo
            // 
            this.txtWightTo.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtWightTo.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(198)))));
            this.txtWightTo.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtWightTo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtWightTo.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtWightTo.DisplayFormat = "0";
            this.txtWightTo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtWightTo.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtWightTo.Location = new System.Drawing.Point(250, 137);
            this.txtWightTo.MinValue = 1;
            this.txtWightTo.Name = "txtWightTo";
            this.txtWightTo.ShowUpDown = true;
            this.txtWightTo.Size = new System.Drawing.Size(68, 21);
            this.txtWightTo.TabIndex = 1005;
            this.txtWightTo.Value = 1;
            // 
            // txtWightFrom
            // 
            this.txtWightFrom.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtWightFrom.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(198)))));
            this.txtWightFrom.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtWightFrom.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtWightFrom.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtWightFrom.DisplayFormat = "0";
            this.txtWightFrom.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtWightFrom.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtWightFrom.Location = new System.Drawing.Point(250, 113);
            this.txtWightFrom.MinValue = 1;
            this.txtWightFrom.Name = "txtWightFrom";
            this.txtWightFrom.ShowUpDown = true;
            this.txtWightFrom.Size = new System.Drawing.Size(68, 21);
            this.txtWightFrom.TabIndex = 1004;
            this.txtWightFrom.Value = 1;
            // 
            // txtBarcodTo
            // 
            this.txtBarcodTo.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtBarcodTo.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(198)))));
            this.txtBarcodTo.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtBarcodTo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtBarcodTo.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtBarcodTo.DisplayFormat = "0";
            this.txtBarcodTo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtBarcodTo.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtBarcodTo.Location = new System.Drawing.Point(6, 185);
            this.txtBarcodTo.MinValue = 1;
            this.txtBarcodTo.Name = "txtBarcodTo";
            this.txtBarcodTo.ShowUpDown = true;
            this.txtBarcodTo.Size = new System.Drawing.Size(68, 21);
            this.txtBarcodTo.TabIndex = 1003;
            this.txtBarcodTo.Value = 1;
            // 
            // txtBarcodFrom
            // 
            this.txtBarcodFrom.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtBarcodFrom.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(198)))));
            this.txtBarcodFrom.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtBarcodFrom.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtBarcodFrom.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtBarcodFrom.DisplayFormat = "0";
            this.txtBarcodFrom.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtBarcodFrom.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtBarcodFrom.Location = new System.Drawing.Point(6, 161);
            this.txtBarcodFrom.MinValue = 1;
            this.txtBarcodFrom.Name = "txtBarcodFrom";
            this.txtBarcodFrom.ShowUpDown = true;
            this.txtBarcodFrom.Size = new System.Drawing.Size(68, 21);
            this.txtBarcodFrom.TabIndex = 1002;
            this.txtBarcodFrom.Value = 1;
            // 
            // label87
            // 
            this.label87.AutoSize = true;
            this.label87.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label87.Location = new System.Drawing.Point(77, 189);
            this.label87.Name = "label87";
            this.label87.Size = new System.Drawing.Size(111, 13);
            this.label87.TabIndex = 93;
            this.label87.Text = "إجمالي خانات الباركود :";
            // 
            // label88
            // 
            this.label88.AutoSize = true;
            this.label88.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label88.Location = new System.Drawing.Point(77, 165);
            this.label88.Name = "label88";
            this.label88.Size = new System.Drawing.Size(90, 13);
            this.label88.TabIndex = 91;
            this.label88.Text = "رقم بداية الباركود :";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.RedButWightPrice);
            this.groupBox8.Controls.Add(this.RedButPrice);
            this.groupBox8.Controls.Add(this.RedButWight);
            this.groupBox8.Location = new System.Drawing.Point(13, 28);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(418, 54);
            this.groupBox8.TabIndex = 90;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "نوع الميزان";
            // 
            // RedButWightPrice
            // 
            this.RedButWightPrice.AutoSize = true;
            this.RedButWightPrice.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.RedButWightPrice.Location = new System.Drawing.Point(19, 24);
            this.RedButWightPrice.Name = "RedButWightPrice";
            this.RedButWightPrice.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RedButWightPrice.Size = new System.Drawing.Size(131, 17);
            this.RedButWightPrice.TabIndex = 15;
            this.RedButWightPrice.Text = "إستخدام بالوزن والسعر";
            this.RedButWightPrice.UseVisualStyleBackColor = true;
            // 
            // RedButPrice
            // 
            this.RedButPrice.AutoSize = true;
            this.RedButPrice.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.RedButPrice.Location = new System.Drawing.Point(172, 24);
            this.RedButPrice.Name = "RedButPrice";
            this.RedButPrice.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RedButPrice.Size = new System.Drawing.Size(101, 17);
            this.RedButPrice.TabIndex = 14;
            this.RedButPrice.Text = "إستخدام بالسعر";
            this.RedButPrice.UseVisualStyleBackColor = true;
            // 
            // RedButWight
            // 
            this.RedButWight.AutoSize = true;
            this.RedButWight.Checked = true;
            this.RedButWight.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.RedButWight.Location = new System.Drawing.Point(295, 24);
            this.RedButWight.Name = "RedButWight";
            this.RedButWight.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RedButWight.Size = new System.Drawing.Size(94, 17);
            this.RedButWight.TabIndex = 13;
            this.RedButWight.TabStop = true;
            this.RedButWight.Text = "إستخدام بالوزن";
            this.RedButWight.UseVisualStyleBackColor = true;
            // 
            // label89
            // 
            this.label89.AutoSize = true;
            this.label89.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label89.Location = new System.Drawing.Point(321, 165);
            this.label89.Name = "label89";
            this.label89.Size = new System.Drawing.Size(88, 13);
            this.label89.TabIndex = 1007;
            this.label89.Text = "عدد بداية السعر :";
            // 
            // label93
            // 
            this.label93.AutoSize = true;
            this.label93.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label93.Location = new System.Drawing.Point(321, 189);
            this.label93.Name = "label93";
            this.label93.Size = new System.Drawing.Size(108, 13);
            this.label93.TabIndex = 1006;
            this.label93.Text = "إجمالي خانات السعر :";
            this.label93.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label95
            // 
            this.label95.AutoSize = true;
            this.label95.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label95.Location = new System.Drawing.Point(321, 117);
            this.label95.Name = "label95";
            this.label95.Size = new System.Drawing.Size(81, 13);
            this.label95.TabIndex = 96;
            this.label95.Text = "عدد بداية الوزن :";
            // 
            // label96
            // 
            this.label96.AutoSize = true;
            this.label96.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label96.Location = new System.Drawing.Point(321, 141);
            this.label96.Name = "label96";
            this.label96.Size = new System.Drawing.Size(101, 13);
            this.label96.TabIndex = 92;
            this.label96.Text = "إجمالي خانات الوزن :";
            this.label96.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupPanel14
            // 
            this.groupPanel14.BackColor = System.Drawing.Color.Silver;
            this.groupPanel14.CanvasColor = System.Drawing.Color.Silver;
            this.groupPanel14.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel14.Controls.Add(this.chkIsActive);
            this.groupPanel14.Controls.Add(this.groupPanel_Main);
            this.groupPanel14.Font = new System.Drawing.Font("Tahoma", 8F);
            this.groupPanel14.Location = new System.Drawing.Point(447, 4);
            this.groupPanel14.Name = "groupPanel14";
            this.groupPanel14.Size = new System.Drawing.Size(566, 323);
            // 
            // 
            // 
            this.groupPanel14.Style.BackColor = System.Drawing.Color.Gainsboro;
            this.groupPanel14.Style.BackColor2 = System.Drawing.Color.Gainsboro;
            this.groupPanel14.Style.BackColorGradientAngle = 90;
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
            this.groupPanel14.TabIndex = 882;
            this.groupPanel14.Text = "اعدادات شاشة الزبون";
            // 
            // chkIsActive
            // 
            this.chkIsActive.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chkIsActive.BackgroundStyle.BorderBottomWidth = 1;
            this.chkIsActive.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarCaptionBackground2;
            this.chkIsActive.BackgroundStyle.BorderLeftWidth = 1;
            this.chkIsActive.BackgroundStyle.BorderRightWidth = 1;
            this.chkIsActive.BackgroundStyle.BorderTopWidth = 1;
            this.chkIsActive.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkIsActive.CheckBoxPosition = DevComponents.DotNetBar.eCheckBoxPosition.Top;
            this.chkIsActive.CheckSignSize = new System.Drawing.Size(15, 15);
            this.chkIsActive.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.chkIsActive.Location = new System.Drawing.Point(19, 5);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkIsActive.Size = new System.Drawing.Size(459, 40);
            this.chkIsActive.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chkIsActive.TabIndex = 980;
            this.chkIsActive.Text = "تفعيل شاشة الــزبــون";
            this.chkIsActive.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            // 
            // groupPanel_Main
            // 
            this.groupPanel_Main.BackColor = System.Drawing.Color.Gainsboro;
            this.groupPanel_Main.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel_Main.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel_Main.Controls.Add(this.label2custDis);
            this.groupPanel_Main.Controls.Add(this.cmbShowState);
            this.groupPanel_Main.Controls.Add(this.button_CheckConn);
            this.groupPanel_Main.Controls.Add(this.txtHello);
            this.groupPanel_Main.Controls.Add(this.label14CustDis);
            this.groupPanel_Main.Controls.Add(this.groupPanel3CustDis);
            this.groupPanel_Main.Controls.Add(this.groupPanel2CustDis);
            this.groupPanel_Main.Controls.Add(this.groupPanel1CustDis);
            this.groupPanel_Main.Controls.Add(this.label1CustDis);
            this.groupPanel_Main.Controls.Add(this.cmbFast);
            this.groupPanel_Main.Controls.Add(this.label8CustDis);
            this.groupPanel_Main.Controls.Add(this.cmbPort);
            this.groupPanel_Main.Enabled = false;
            this.groupPanel_Main.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.groupPanel_Main.Location = new System.Drawing.Point(33, 49);
            this.groupPanel_Main.Name = "groupPanel_Main";
            this.groupPanel_Main.Size = new System.Drawing.Size(457, 246);
            // 
            // 
            // 
            this.groupPanel_Main.Style.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel_Main.Style.BackColor2 = System.Drawing.Color.Transparent;
            this.groupPanel_Main.Style.BackColorGradientAngle = 90;
            this.groupPanel_Main.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel_Main.Style.BorderBottomWidth = 1;
            this.groupPanel_Main.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel_Main.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel_Main.Style.BorderLeftWidth = 1;
            this.groupPanel_Main.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel_Main.Style.BorderRightWidth = 1;
            this.groupPanel_Main.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel_Main.Style.BorderTopWidth = 1;
            this.groupPanel_Main.Style.CornerDiameter = 4;
            this.groupPanel_Main.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel_Main.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Far;
            this.groupPanel_Main.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            // 
            // 
            // 
            this.groupPanel_Main.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel_Main.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel_Main.TabIndex = 979;
            // 
            // label2custDis
            // 
            this.label2custDis.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label2custDis.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2custDis.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2custDis.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2custDis.Location = new System.Drawing.Point(334, 217);
            this.label2custDis.Name = "label2custDis";
            this.label2custDis.Size = new System.Drawing.Size(105, 20);
            this.label2custDis.TabIndex = 994;
            this.label2custDis.Text = "طريقة العرض";
            this.label2custDis.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbShowState
            // 
            this.cmbShowState.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbShowState.DisplayMember = "Text";
            this.cmbShowState.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbShowState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbShowState.FocusHighlightColor = System.Drawing.Color.Empty;
            this.cmbShowState.FormattingEnabled = true;
            this.cmbShowState.ItemHeight = 14;
            this.cmbShowState.Location = new System.Drawing.Point(114, 217);
            this.cmbShowState.Name = "cmbShowState";
            this.cmbShowState.Size = new System.Drawing.Size(218, 20);
            this.cmbShowState.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbShowState.TabIndex = 993;
            // 
            // button_CheckConn
            // 
            this.button_CheckConn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_CheckConn.Checked = true;
            this.button_CheckConn.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.button_CheckConn.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.button_CheckConn.Location = new System.Drawing.Point(12, 191);
            this.button_CheckConn.Name = "button_CheckConn";
            this.button_CheckConn.Size = new System.Drawing.Size(100, 46);
            this.button_CheckConn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_CheckConn.Symbol = "";
            this.button_CheckConn.SymbolSize = 13F;
            this.button_CheckConn.TabIndex = 991;
            this.button_CheckConn.Text = "إختبــــار";
            this.button_CheckConn.TextColor = System.Drawing.Color.SteelBlue;
            // 
            // txtHello
            // 
            this.txtHello.BackColor = System.Drawing.Color.White;
            this.txtHello.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHello.Location = new System.Drawing.Point(114, 191);
            this.txtHello.MaxLength = 50;
            this.txtHello.Name = "txtHello";
            this.netResize1.SetResizeTextBoxMultiline(this.txtHello, false);
            this.txtHello.Size = new System.Drawing.Size(218, 20);
            this.txtHello.TabIndex = 980;
            this.txtHello.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label14CustDis
            // 
            this.label14CustDis.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label14CustDis.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label14CustDis.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label14CustDis.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label14CustDis.Location = new System.Drawing.Point(334, 191);
            this.label14CustDis.Name = "label14CustDis";
            this.label14CustDis.Size = new System.Drawing.Size(105, 20);
            this.label14CustDis.TabIndex = 981;
            this.label14CustDis.Text = "رسالة ترحيبية";
            this.label14CustDis.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupPanel3CustDis
            // 
            this.groupPanel3CustDis.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel3CustDis.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel3CustDis.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel3CustDis.Controls.Add(this.chkSync5);
            this.groupPanel3CustDis.Controls.Add(this.chkSync4);
            this.groupPanel3CustDis.Controls.Add(this.chkSync3);
            this.groupPanel3CustDis.Controls.Add(this.chkSync2);
            this.groupPanel3CustDis.Controls.Add(this.chkSync1);
            this.groupPanel3CustDis.Location = new System.Drawing.Point(12, 48);
            this.groupPanel3CustDis.Name = "groupPanel3CustDis";
            this.groupPanel3CustDis.Size = new System.Drawing.Size(101, 135);
            // 
            // 
            // 
            this.groupPanel3CustDis.Style.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel3CustDis.Style.BackColor2 = System.Drawing.Color.Transparent;
            this.groupPanel3CustDis.Style.BackColorGradientAngle = 90;
            this.groupPanel3CustDis.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3CustDis.Style.BorderBottomWidth = 1;
            this.groupPanel3CustDis.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel3CustDis.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3CustDis.Style.BorderLeftWidth = 1;
            this.groupPanel3CustDis.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3CustDis.Style.BorderRightWidth = 1;
            this.groupPanel3CustDis.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3CustDis.Style.BorderTopWidth = 1;
            this.groupPanel3CustDis.Style.CornerDiameter = 4;
            this.groupPanel3CustDis.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel3CustDis.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel3CustDis.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            // 
            // 
            // 
            this.groupPanel3CustDis.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel3CustDis.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel3CustDis.TabIndex = 979;
            this.groupPanel3CustDis.Text = "التمـــاثل";
            // 
            // chkSync5
            // 
            this.chkSync5.AutoSize = true;
            this.chkSync5.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chkSync5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkSync5.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.chkSync5.Location = new System.Drawing.Point(13, 90);
            this.chkSync5.Name = "chkSync5";
            this.chkSync5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkSync5.Size = new System.Drawing.Size(58, 15);
            this.chkSync5.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chkSync5.TabIndex = 980;
            this.chkSync5.Text = "مسافة";
            // 
            // chkSync4
            // 
            this.chkSync4.AutoSize = true;
            this.chkSync4.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chkSync4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkSync4.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.chkSync4.Location = new System.Drawing.Point(20, 69);
            this.chkSync4.Name = "chkSync4";
            this.chkSync4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkSync4.Size = new System.Drawing.Size(51, 15);
            this.chkSync4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chkSync4.TabIndex = 979;
            this.chkSync4.Text = "علامة";
            // 
            // chkSync3
            // 
            this.chkSync3.AutoSize = true;
            this.chkSync3.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chkSync3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkSync3.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.chkSync3.Location = new System.Drawing.Point(37, 48);
            this.chkSync3.Name = "chkSync3";
            this.chkSync3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkSync3.Size = new System.Drawing.Size(34, 15);
            this.chkSync3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chkSync3.TabIndex = 978;
            this.chkSync3.Text = "بلا";
            // 
            // chkSync2
            // 
            this.chkSync2.AutoSize = true;
            this.chkSync2.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chkSync2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkSync2.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.chkSync2.Location = new System.Drawing.Point(17, 27);
            this.chkSync2.Name = "chkSync2";
            this.chkSync2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkSync2.Size = new System.Drawing.Size(53, 15);
            this.chkSync2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chkSync2.TabIndex = 977;
            this.chkSync2.Text = "زوجي";
            // 
            // chkSync1
            // 
            this.chkSync1.AutoSize = true;
            this.chkSync1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chkSync1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkSync1.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.chkSync1.Location = new System.Drawing.Point(21, 6);
            this.chkSync1.Name = "chkSync1";
            this.chkSync1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkSync1.Size = new System.Drawing.Size(50, 15);
            this.chkSync1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chkSync1.TabIndex = 976;
            this.chkSync1.Text = "فردي";
            // 
            // groupPanel2CustDis
            // 
            this.groupPanel2CustDis.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel2CustDis.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2CustDis.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2CustDis.Controls.Add(this.chkData5);
            this.groupPanel2CustDis.Controls.Add(this.chkData4);
            this.groupPanel2CustDis.Controls.Add(this.chkData3);
            this.groupPanel2CustDis.Controls.Add(this.chkData2);
            this.groupPanel2CustDis.Controls.Add(this.chkData1);
            this.groupPanel2CustDis.Location = new System.Drawing.Point(174, 48);
            this.groupPanel2CustDis.Name = "groupPanel2CustDis";
            this.groupPanel2CustDis.Size = new System.Drawing.Size(101, 135);
            // 
            // 
            // 
            this.groupPanel2CustDis.Style.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel2CustDis.Style.BackColor2 = System.Drawing.Color.Transparent;
            this.groupPanel2CustDis.Style.BackColorGradientAngle = 90;
            this.groupPanel2CustDis.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2CustDis.Style.BorderBottomWidth = 1;
            this.groupPanel2CustDis.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel2CustDis.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2CustDis.Style.BorderLeftWidth = 1;
            this.groupPanel2CustDis.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2CustDis.Style.BorderRightWidth = 1;
            this.groupPanel2CustDis.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2CustDis.Style.BorderTopWidth = 1;
            this.groupPanel2CustDis.Style.CornerDiameter = 4;
            this.groupPanel2CustDis.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel2CustDis.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel2CustDis.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            // 
            // 
            // 
            this.groupPanel2CustDis.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel2CustDis.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel2CustDis.TabIndex = 978;
            this.groupPanel2CustDis.Text = "البيــانات";
            // 
            // chkData5
            // 
            this.chkData5.AutoSize = true;
            this.chkData5.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chkData5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkData5.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.chkData5.Location = new System.Drawing.Point(31, 90);
            this.chkData5.Name = "chkData5";
            this.chkData5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkData5.Size = new System.Drawing.Size(29, 15);
            this.chkData5.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chkData5.TabIndex = 980;
            this.chkData5.Text = "8";
            // 
            // chkData4
            // 
            this.chkData4.AutoSize = true;
            this.chkData4.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chkData4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkData4.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.chkData4.Location = new System.Drawing.Point(31, 69);
            this.chkData4.Name = "chkData4";
            this.chkData4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkData4.Size = new System.Drawing.Size(29, 15);
            this.chkData4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chkData4.TabIndex = 979;
            this.chkData4.Text = "7";
            // 
            // chkData3
            // 
            this.chkData3.AutoSize = true;
            this.chkData3.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chkData3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkData3.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.chkData3.Location = new System.Drawing.Point(32, 48);
            this.chkData3.Name = "chkData3";
            this.chkData3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkData3.Size = new System.Drawing.Size(29, 15);
            this.chkData3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chkData3.TabIndex = 978;
            this.chkData3.Text = "6";
            // 
            // chkData2
            // 
            this.chkData2.AutoSize = true;
            this.chkData2.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chkData2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkData2.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.chkData2.Location = new System.Drawing.Point(32, 27);
            this.chkData2.Name = "chkData2";
            this.chkData2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkData2.Size = new System.Drawing.Size(29, 15);
            this.chkData2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chkData2.TabIndex = 977;
            this.chkData2.Text = "5";
            // 
            // chkData1
            // 
            this.chkData1.AutoSize = true;
            this.chkData1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chkData1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkData1.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.chkData1.Location = new System.Drawing.Point(32, 6);
            this.chkData1.Name = "chkData1";
            this.chkData1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkData1.Size = new System.Drawing.Size(29, 15);
            this.chkData1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chkData1.TabIndex = 976;
            this.chkData1.Text = "4";
            // 
            // groupPanel1CustDis
            // 
            this.groupPanel1CustDis.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel1CustDis.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1CustDis.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1CustDis.Controls.Add(this.chkStop3);
            this.groupPanel1CustDis.Controls.Add(this.chkStop2);
            this.groupPanel1CustDis.Controls.Add(this.chkStop1);
            this.groupPanel1CustDis.Location = new System.Drawing.Point(336, 48);
            this.groupPanel1CustDis.Name = "groupPanel1CustDis";
            this.groupPanel1CustDis.Size = new System.Drawing.Size(101, 135);
            // 
            // 
            // 
            this.groupPanel1CustDis.Style.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel1CustDis.Style.BackColor2 = System.Drawing.Color.Transparent;
            this.groupPanel1CustDis.Style.BackColorGradientAngle = 90;
            this.groupPanel1CustDis.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1CustDis.Style.BorderBottomWidth = 1;
            this.groupPanel1CustDis.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel1CustDis.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1CustDis.Style.BorderLeftWidth = 1;
            this.groupPanel1CustDis.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1CustDis.Style.BorderRightWidth = 1;
            this.groupPanel1CustDis.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1CustDis.Style.BorderTopWidth = 1;
            this.groupPanel1CustDis.Style.CornerDiameter = 4;
            this.groupPanel1CustDis.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel1CustDis.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel1CustDis.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            // 
            // 
            // 
            this.groupPanel1CustDis.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel1CustDis.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel1CustDis.TabIndex = 977;
            this.groupPanel1CustDis.Text = "التــوقـف";
            // 
            // chkStop3
            // 
            this.chkStop3.AutoSize = true;
            this.chkStop3.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chkStop3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkStop3.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.chkStop3.Location = new System.Drawing.Point(32, 83);
            this.chkStop3.Name = "chkStop3";
            this.chkStop3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkStop3.Size = new System.Drawing.Size(29, 15);
            this.chkStop3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chkStop3.TabIndex = 978;
            this.chkStop3.Text = "2";
            // 
            // chkStop2
            // 
            this.chkStop2.AutoSize = true;
            this.chkStop2.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chkStop2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkStop2.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.chkStop2.Location = new System.Drawing.Point(22, 47);
            this.chkStop2.Name = "chkStop2";
            this.chkStop2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkStop2.Size = new System.Drawing.Size(39, 15);
            this.chkStop2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chkStop2.TabIndex = 977;
            this.chkStop2.Text = "1.5";
            // 
            // chkStop1
            // 
            this.chkStop1.AutoSize = true;
            this.chkStop1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chkStop1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkStop1.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.chkStop1.Location = new System.Drawing.Point(32, 11);
            this.chkStop1.Name = "chkStop1";
            this.chkStop1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkStop1.Size = new System.Drawing.Size(29, 15);
            this.chkStop1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chkStop1.TabIndex = 976;
            this.chkStop1.Text = "1";
            // 
            // label1CustDis
            // 
            this.label1CustDis.AutoSize = true;
            this.label1CustDis.BackColor = System.Drawing.Color.Transparent;
            this.label1CustDis.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label1CustDis.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1CustDis.Location = new System.Drawing.Point(134, 18);
            this.label1CustDis.Name = "label1CustDis";
            this.label1CustDis.Size = new System.Drawing.Size(56, 13);
            this.label1CustDis.TabIndex = 969;
            this.label1CustDis.Text = "الســرعة :";
            this.label1CustDis.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // cmbFast
            // 
            this.cmbFast.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbFast.DisplayMember = "Text";
            this.cmbFast.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbFast.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFast.FocusHighlightColor = System.Drawing.Color.Empty;
            this.cmbFast.FormattingEnabled = true;
            this.cmbFast.ItemHeight = 14;
            this.cmbFast.Location = new System.Drawing.Point(14, 14);
            this.cmbFast.Name = "cmbFast";
            this.cmbFast.Size = new System.Drawing.Size(116, 20);
            this.cmbFast.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbFast.TabIndex = 970;
            // 
            // label8CustDis
            // 
            this.label8CustDis.AutoSize = true;
            this.label8CustDis.BackColor = System.Drawing.Color.Transparent;
            this.label8CustDis.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label8CustDis.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8CustDis.Location = new System.Drawing.Point(390, 18);
            this.label8CustDis.Name = "label8CustDis";
            this.label8CustDis.Size = new System.Drawing.Size(52, 13);
            this.label8CustDis.TabIndex = 967;
            this.label8CustDis.Text = "المنفـــذ :";
            this.label8CustDis.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // cmbPort
            // 
            this.cmbPort.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbPort.DisplayMember = "Text";
            this.cmbPort.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPort.FocusHighlightColor = System.Drawing.Color.Empty;
            this.cmbPort.FormattingEnabled = true;
            this.cmbPort.ItemHeight = 14;
            this.cmbPort.Location = new System.Drawing.Point(270, 14);
            this.cmbPort.Name = "cmbPort";
            this.cmbPort.Size = new System.Drawing.Size(116, 20);
            this.cmbPort.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbPort.TabIndex = 968;
            // 
            // superTabItem6
            // 
            this.superTabItem6.AttachedControl = this.superTabControlPanel14;
            this.superTabItem6.GlobalItem = false;
            this.superTabItem6.Name = "superTabItem6";
            this.superTabItem6.Text = "اعدادات اخرى";
            // 
            // superTabControlPanel12
            // 
            this.superTabControlPanel12.Controls.Add(this.superTabControl2);
            this.superTabControlPanel12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel12.Location = new System.Drawing.Point(0, 0);
            this.superTabControlPanel12.Name = "superTabControlPanel12";
            this.superTabControlPanel12.Size = new System.Drawing.Size(1069, 514);
            this.superTabControlPanel12.TabIndex = 0;
            this.superTabControlPanel12.TabItem = this.superTabItem4;
            // 
            // superTabControl2
            // 
            this.superTabControl2.AutoCloseTabs = false;
            this.superTabControl2.CloseButtonOnTabsAlwaysDisplayed = false;
            // 
            // 
            // 
            // 
            // 
            // 
            this.superTabControl2.ControlBox.CloseBox.Name = string.Empty;
            // 
            // 
            // 
            this.superTabControl2.ControlBox.MenuBox.Name = string.Empty;
            this.superTabControl2.ControlBox.Name = string.Empty;
            this.superTabControl2.ControlBox.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.superTabControl2.ControlBox.MenuBox,
            this.superTabControl2.ControlBox.CloseBox});
            this.superTabControl2.ControlBox.Visible = false;
            this.superTabControl2.Controls.Add(this.superTabControlPanel8);
            this.superTabControl2.Controls.Add(this.superTabControlPanel9);
            this.superTabControl2.Controls.Add(this.superTabControlPanel10);
            this.superTabControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.superTabControl2.Location = new System.Drawing.Point(0, 0);
            this.superTabControl2.Name = "superTabControl2";
            this.superTabControl2.ReorderTabsEnabled = false;
            this.superTabControl2.SelectedTabFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.superTabControl2.SelectedTabIndex = 0;
            this.superTabControl2.Size = new System.Drawing.Size(1069, 363);
            this.superTabControl2.TabFont = new System.Drawing.Font("Tahoma", 8F);
            this.superTabControl2.TabIndex = 1040;
            this.superTabControl2.TabLayoutType = DevComponents.DotNetBar.eSuperTabLayoutType.MultiLineFit;
            this.superTabControl2.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.superTabItem2,
            this.superTabItem3});
            this.superTabControl2.TabStripTabStop = false;
            this.superTabControl2.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.WinMediaPlayer12;
            this.superTabControl2.Text = "superTabControl2";
            // 
            // superTabControlPanel8
            // 
            this.superTabControlPanel8.Controls.Add(this.chk70);
            this.superTabControlPanel8.Controls.Add(this.chk56);
            this.superTabControlPanel8.Controls.Add(this.chk48);
            this.superTabControlPanel8.Controls.Add(this.chk38);
            this.superTabControlPanel8.Controls.Add(this.comboBoxEx1);
            this.superTabControlPanel8.Controls.Add(this.chk35);
            this.superTabControlPanel8.Controls.Add(this.chk32);
            this.superTabControlPanel8.Controls.Add(this.chk29);
            this.superTabControlPanel8.Controls.Add(this.chk10);
            this.superTabControlPanel8.Controls.Add(this.chk22);
            this.superTabControlPanel8.Controls.Add(this.chk23);
            this.superTabControlPanel8.Controls.Add(this.chk47);
            this.superTabControlPanel8.Controls.Add(this.chk14);
            this.superTabControlPanel8.Controls.Add(this.chk20);
            this.superTabControlPanel8.Controls.Add(this.chk26);
            this.superTabControlPanel8.Controls.Add(this.chk16);
            this.superTabControlPanel8.Controls.Add(this.chk12);
            this.superTabControlPanel8.Controls.Add(this.chk11);
            this.superTabControlPanel8.Controls.Add(this.chk4);
            this.superTabControlPanel8.Controls.Add(this.chk51);
            this.superTabControlPanel8.Controls.Add(this.chk49);
            this.superTabControlPanel8.Controls.Add(this.chk40);
            this.superTabControlPanel8.Controls.Add(this.chk34);
            this.superTabControlPanel8.Controls.Add(this.chk33);
            this.superTabControlPanel8.Controls.Add(this.chk31);
            this.superTabControlPanel8.Controls.Add(this.chk28);
            this.superTabControlPanel8.Controls.Add(this.chk25);
            this.superTabControlPanel8.Controls.Add(this.chk17);
            this.superTabControlPanel8.Controls.Add(this.chk15);
            this.superTabControlPanel8.Controls.Add(this.chk13);
            this.superTabControlPanel8.Controls.Add(this.chk9);
            this.superTabControlPanel8.Controls.Add(this.chk8);
            this.superTabControlPanel8.Controls.Add(this.chk6);
            this.superTabControlPanel8.Controls.Add(this.chk5);
            this.superTabControlPanel8.Controls.Add(this.chk21);
            this.superTabControlPanel8.Controls.Add(this.chk7);
            this.superTabControlPanel8.Controls.Add(this.chk41);
            this.superTabControlPanel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel8.Location = new System.Drawing.Point(0, 23);
            this.superTabControlPanel8.Name = "superTabControlPanel8";
            this.superTabControlPanel8.Size = new System.Drawing.Size(1069, 340);
            this.superTabControlPanel8.TabIndex = 1;
            this.superTabControlPanel8.TabItem = this.superTabItem2;
            // 
            // chk70
            // 
            this.chk70.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right));
            this.chk70.AutoSize = true;
            this.chk70.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chk70.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chk70.Location = new System.Drawing.Point(66, 116);
            this.chk70.Name = "chk70";
            this.chk70.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chk70.Size = new System.Drawing.Size(186, 15);
            this.chk70.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chk70.TabIndex = 1070;
            this.chk70.Text = "إخفاء كامل لجميع خيارات نقاط العملاء";
            // 
            // chk56
            // 
            this.chk56.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right));
            this.chk56.AutoSize = true;
            this.chk56.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chk56.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chk56.Location = new System.Drawing.Point(37, 89);
            this.chk56.Name = "chk56";
            this.chk56.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chk56.Size = new System.Drawing.Size(213, 15);
            this.chk56.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chk56.TabIndex = 1069;
            this.chk56.Text = "سعر اخر صرف للمندوب من الوحدة 1 للصنف";
            // 
            // chk48
            // 
            this.chk48.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right));
            this.chk48.AutoSize = true;
            this.chk48.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chk48.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chk48.Location = new System.Drawing.Point(10, 35);
            this.chk48.Name = "chk48";
            this.chk48.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chk48.Size = new System.Drawing.Size(240, 15);
            this.chk48.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chk48.TabIndex = 1068;
            this.chk48.Text = "اصدار فاتورة ادخال بضاعة بعد اخراج البضاعة تلقائيا";
            // 
            // chk38
            // 
            this.chk38.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right));
            this.chk38.AutoSize = true;
            this.chk38.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chk38.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chk38.Location = new System.Drawing.Point(332, 305);
            this.chk38.Name = "chk38";
            this.chk38.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chk38.Size = new System.Drawing.Size(189, 15);
            this.chk38.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chk38.TabIndex = 1066;
            this.chk38.Text = "إظهار  شاشة المدفوعات في المبيعات";
            // 
            // comboBoxEx1
            // 
            this.comboBoxEx1.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right));
            this.comboBoxEx1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxEx1.DisplayMember = "Text";
            this.comboBoxEx1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxEx1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEx1.FocusHighlightColor = System.Drawing.Color.Empty;
            this.comboBoxEx1.FormattingEnabled = true;
            this.comboBoxEx1.ItemHeight = 14;
            this.comboBoxEx1.Location = new System.Drawing.Point(5, 5);
            this.comboBoxEx1.Name = "comboBoxEx1";
            this.comboBoxEx1.Size = new System.Drawing.Size(391, 20);
            this.comboBoxEx1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBoxEx1.TabIndex = 1065;
            // 
            // chk35
            // 
            this.chk35.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right));
            this.chk35.AutoSize = true;
            this.chk35.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chk35.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chk35.Location = new System.Drawing.Point(106, 8);
            this.chk35.Name = "chk35";
            this.chk35.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chk35.Size = new System.Drawing.Size(147, 15);
            this.chk35.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chk35.TabIndex = 1064;
            this.chk35.Text = "رسالة نصية للعميل بعد البيع";
            // 
            // chk32
            // 
            this.chk32.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right));
            this.chk32.AutoSize = true;
            this.chk32.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chk32.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chk32.Location = new System.Drawing.Point(58, 278);
            this.chk32.Name = "chk32";
            this.chk32.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chk32.Size = new System.Drawing.Size(193, 15);
            this.chk32.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chk32.TabIndex = 1062;
            this.chk32.Text = "السماح باصدار فاتورة محلية بدون طاولة";
            // 
            // chk29
            // 
            this.chk29.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right));
            this.chk29.AutoSize = true;
            this.chk29.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chk29.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chk29.Location = new System.Drawing.Point(68, 251);
            this.chk29.Name = "chk29";
            this.chk29.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chk29.Size = new System.Drawing.Size(184, 15);
            this.chk29.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chk29.TabIndex = 1061;
            this.chk29.Text = "طباعة التصنيفات حسب اسم الطابعة";
            // 
            // chk10
            // 
            this.chk10.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right));
            this.chk10.AutoSize = true;
            this.chk10.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chk10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chk10.Location = new System.Drawing.Point(16, 170);
            this.chk10.Name = "chk10";
            this.chk10.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chk10.Size = new System.Drawing.Size(234, 15);
            this.chk10.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chk10.TabIndex = 1058;
            this.chk10.Text = "تمكين الإضافة التلقائية لفاتورة المبيعات - الباركود";
            // 
            // chk22
            // 
            this.chk22.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right));
            this.chk22.AutoSize = true;
            this.chk22.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chk22.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chk22.Location = new System.Drawing.Point(52, 224);
            this.chk22.Name = "chk22";
            this.chk22.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chk22.Size = new System.Drawing.Size(199, 15);
            this.chk22.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chk22.TabIndex = 1060;
            this.chk22.Text = "إعتماد شاشة نقاط البيع لفاتورة المبيعات";
            // 
            // chk23
            // 
            this.chk23.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right));
            this.chk23.AutoSize = true;
            this.chk23.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chk23.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chk23.Location = new System.Drawing.Point(29, 143);
            this.chk23.Name = "chk23";
            this.chk23.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chk23.Size = new System.Drawing.Size(221, 15);
            this.chk23.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chk23.TabIndex = 1063;
            this.chk23.Text = "إعتماد الحجم القياسي لشاشة نقـــاط البيـــع";
            // 
            // chk47
            // 
            this.chk47.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right));
            this.chk47.AutoSize = true;
            this.chk47.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chk47.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chk47.Location = new System.Drawing.Point(20, 62);
            this.chk47.Name = "chk47";
            this.chk47.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chk47.Size = new System.Drawing.Size(230, 15);
            this.chk47.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chk47.TabIndex = 1067;
            this.chk47.Text = "إظهار رسالة الطباعة عند حفظ فاتورة المشتريات";
            // 
            // chk14
            // 
            this.chk14.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right));
            this.chk14.AutoSize = true;
            this.chk14.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chk14.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chk14.Location = new System.Drawing.Point(18, 197);
            this.chk14.Name = "chk14";
            this.chk14.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chk14.Size = new System.Drawing.Size(233, 15);
            this.chk14.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chk14.TabIndex = 1059;
            this.chk14.Text = "إظهار التكلفة الإضافية عند إصدار فاتورة مشتريات";
            // 
            // chk20
            // 
            this.chk20.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right));
            this.chk20.AutoSize = true;
            this.chk20.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chk20.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chk20.Location = new System.Drawing.Point(324, 278);
            this.chk20.Name = "chk20";
            this.chk20.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chk20.Size = new System.Drawing.Size(196, 15);
            this.chk20.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chk20.TabIndex = 1053;
            this.chk20.Text = "إظهار ازرار إدراج الأصناف في فواتير الجرد";
            // 
            // chk26
            // 
            this.chk26.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right));
            this.chk26.AutoSize = true;
            this.chk26.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chk26.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chk26.Location = new System.Drawing.Point(322, 251);
            this.chk26.Name = "chk26";
            this.chk26.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chk26.Size = new System.Drawing.Size(198, 15);
            this.chk26.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chk26.TabIndex = 1052;
            this.chk26.Text = "إعتماد شاشة البحث السريع في الفواتير";
            // 
            // chk16
            // 
            this.chk16.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right));
            this.chk16.AutoSize = true;
            this.chk16.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chk16.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chk16.Location = new System.Drawing.Point(329, 170);
            this.chk16.Name = "chk16";
            this.chk16.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chk16.Size = new System.Drawing.Size(192, 15);
            this.chk16.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chk16.TabIndex = 1051;
            this.chk16.Text = "إظهار رقم ســيريــال الصنف في الفواتير ";
            // 
            // chk12
            // 
            this.chk12.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right));
            this.chk12.AutoSize = true;
            this.chk12.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chk12.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chk12.Location = new System.Drawing.Point(336, 224);
            this.chk12.Name = "chk12";
            this.chk12.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chk12.Size = new System.Drawing.Size(184, 15);
            this.chk12.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chk12.TabIndex = 1050;
            this.chk12.Text = "ظهور رقم المستودع في تقرير الفواتير";
            // 
            // chk11
            // 
            this.chk11.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right));
            this.chk11.AutoSize = true;
            this.chk11.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chk11.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chk11.Location = new System.Drawing.Point(312, 197);
            this.chk11.Name = "chk11";
            this.chk11.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chk11.Size = new System.Drawing.Size(208, 15);
            this.chk11.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chk11.TabIndex = 1049;
            this.chk11.Text = "ظهور محتويات الصنف التجميعي في التقرير";
            // 
            // chk4
            // 
            this.chk4.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right));
            this.chk4.AutoSize = true;
            this.chk4.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chk4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chk4.Location = new System.Drawing.Point(259, 143);
            this.chk4.Name = "chk4";
            this.chk4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chk4.Size = new System.Drawing.Size(259, 15);
            this.chk4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chk4.TabIndex = 1048;
            this.chk4.Text = "السماح بالكميات الغير صحيحة ( الكسرية ) في الفواتير";
            // 
            // chk51
            // 
            this.chk51.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right));
            this.chk51.AutoSize = true;
            this.chk51.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chk51.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chk51.Location = new System.Drawing.Point(567, 197);
            this.chk51.Name = "chk51";
            this.chk51.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chk51.Size = new System.Drawing.Size(201, 15);
            this.chk51.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chk51.TabIndex = 1025;
            this.chk51.Text = "إظهار اعدادات الطباعة عند طباعة الباركود";
            // 
            // chk49
            // 
            this.chk49.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right));
            this.chk49.AutoSize = true;
            this.chk49.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chk49.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chk49.Location = new System.Drawing.Point(627, 224);
            this.chk49.Name = "chk49";
            this.chk49.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chk49.Size = new System.Drawing.Size(143, 15);
            this.chk49.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chk49.TabIndex = 1024;
            this.chk49.Text = "ايقاف مزامنة التاريخ للويندوز";
            // 
            // chk40
            // 
            this.chk40.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right));
            this.chk40.AutoSize = true;
            this.chk40.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chk40.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chk40.Location = new System.Drawing.Point(62, 305);
            this.chk40.Name = "chk40";
            this.chk40.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chk40.Size = new System.Drawing.Size(189, 15);
            this.chk40.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chk40.TabIndex = 1022;
            this.chk40.Text = "إفراغ الطاولة عند استخدم طلب محلي";
            // 
            // chk34
            // 
            this.chk34.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right));
            this.chk34.AutoSize = true;
            this.chk34.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chk34.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chk34.Location = new System.Drawing.Point(594, 278);
            this.chk34.Name = "chk34";
            this.chk34.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chk34.Size = new System.Drawing.Size(175, 15);
            this.chk34.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chk34.TabIndex = 1021;
            this.chk34.Text = "إختيار العميــــل في فاتورة المبيعات";
            // 
            // chk33
            // 
            this.chk33.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right));
            this.chk33.AutoSize = true;
            this.chk33.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chk33.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chk33.Location = new System.Drawing.Point(288, 35);
            this.chk33.Name = "chk33";
            this.chk33.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chk33.Size = new System.Drawing.Size(231, 15);
            this.chk33.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chk33.TabIndex = 1020;
            this.chk33.Text = "إعتماد تصميم الشاشة المكبرّة للفاتورة المبيعات";
            // 
            // chk31
            // 
            this.chk31.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right));
            this.chk31.AutoSize = true;
            this.chk31.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chk31.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chk31.Location = new System.Drawing.Point(279, 8);
            this.chk31.Name = "chk31";
            this.chk31.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chk31.Size = new System.Drawing.Size(240, 15);
            this.chk31.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chk31.TabIndex = 1019;
            this.chk31.Text = "رسالة بإعادة تسلسل الفواتير عند ترحيل الصندوق";
            // 
            // chk28
            // 
            this.chk28.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right));
            this.chk28.AutoSize = true;
            this.chk28.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chk28.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chk28.Location = new System.Drawing.Point(570, 251);
            this.chk28.Name = "chk28";
            this.chk28.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chk28.Size = new System.Drawing.Size(199, 15);
            this.chk28.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chk28.TabIndex = 1018;
            this.chk28.Text = "طباعة الباركود في الفاتورة حسب الكمية";
            // 
            // chk25
            // 
            this.chk25.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right));
            this.chk25.AutoSize = true;
            this.chk25.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chk25.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chk25.Location = new System.Drawing.Point(532, 143);
            this.chk25.Name = "chk25";
            this.chk25.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chk25.Size = new System.Drawing.Size(235, 15);
            this.chk25.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chk25.TabIndex = 1017;
            this.chk25.Text = "إظهار الوصف العكسي عرب/ انج  لفواتير الكاشيير";
            // 
            // chk17
            // 
            this.chk17.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right));
            this.chk17.AutoSize = true;
            this.chk17.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chk17.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chk17.Location = new System.Drawing.Point(563, 89);
            this.chk17.Name = "chk17";
            this.chk17.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chk17.Size = new System.Drawing.Size(205, 15);
            this.chk17.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chk17.TabIndex = 1015;
            this.chk17.Text = "إظهار رقم تصنيع الصنف عند طباعة الفواتير";
            // 
            // chk15
            // 
            this.chk15.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right));
            this.chk15.AutoSize = true;
            this.chk15.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chk15.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chk15.Location = new System.Drawing.Point(550, 62);
            this.chk15.Name = "chk15";
            this.chk15.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chk15.Size = new System.Drawing.Size(217, 15);
            this.chk15.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chk15.TabIndex = 1014;
            this.chk15.Text = "إظهار تاريخ صلاحية الصنف عند طباعة الفواتير";
            // 
            // chk13
            // 
            this.chk13.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right));
            this.chk13.AutoSize = true;
            this.chk13.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chk13.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chk13.Location = new System.Drawing.Point(576, 170);
            this.chk13.Name = "chk13";
            this.chk13.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chk13.Size = new System.Drawing.Size(192, 15);
            this.chk13.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chk13.TabIndex = 1013;
            this.chk13.Text = "دمج الأصناف المكررة تلقائيا في الفاتورة";
            // 
            // chk9
            // 
            this.chk9.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right));
            this.chk9.AutoSize = true;
            this.chk9.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chk9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chk9.Location = new System.Drawing.Point(614, 8);
            this.chk9.Name = "chk9";
            this.chk9.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chk9.Size = new System.Drawing.Size(155, 15);
            this.chk9.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chk9.TabIndex = 1012;
            this.chk9.Text = "ظهور الخصم عند اصدار الفاتورة";
            // 
            // chk8
            // 
            this.chk8.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right));
            this.chk8.AutoSize = true;
            this.chk8.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chk8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chk8.Location = new System.Drawing.Point(599, 35);
            this.chk8.Name = "chk8";
            this.chk8.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chk8.Size = new System.Drawing.Size(170, 15);
            this.chk8.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chk8.TabIndex = 1011;
            this.chk8.Text = "إختيار المندوب في فاتورة المبيعات";
            // 
            // chk6
            // 
            this.chk6.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right));
            this.chk6.AutoSize = true;
            this.chk6.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chk6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chk6.Location = new System.Drawing.Point(369, 89);
            this.chk6.Name = "chk6";
            this.chk6.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chk6.Size = new System.Drawing.Size(152, 15);
            this.chk6.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chk6.TabIndex = 1009;
            this.chk6.Text = "ظهور العملاء في فواتير الشراء";
            // 
            // chk5
            // 
            this.chk5.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right));
            this.chk5.AutoSize = true;
            this.chk5.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chk5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chk5.Location = new System.Drawing.Point(370, 116);
            this.chk5.Name = "chk5";
            this.chk5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chk5.Size = new System.Drawing.Size(151, 15);
            this.chk5.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chk5.TabIndex = 1008;
            this.chk5.Text = "ظهور الموردين في فواتير البيع ";
            // 
            // chk21
            // 
            this.chk21.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right));
            this.chk21.AutoSize = true;
            this.chk21.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chk21.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chk21.Location = new System.Drawing.Point(587, 305);
            this.chk21.Name = "chk21";
            this.chk21.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chk21.Size = new System.Drawing.Size(182, 15);
            this.chk21.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chk21.TabIndex = 1016;
            this.chk21.Text = "تمكين نوع الفاتورة الآجلة  لنقاط البيع";
            // 
            // chk7
            // 
            this.chk7.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right));
            this.chk7.AutoSize = true;
            this.chk7.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chk7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chk7.Location = new System.Drawing.Point(320, 62);
            this.chk7.Name = "chk7";
            this.chk7.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chk7.Size = new System.Drawing.Size(200, 15);
            this.chk7.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chk7.TabIndex = 1010;
            this.chk7.Text = "إظهار جميع الحسابات المالية في الفواتير";
            // 
            // chk41
            // 
            this.chk41.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right));
            this.chk41.AutoSize = true;
            this.chk41.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chk41.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chk41.Location = new System.Drawing.Point(543, 116);
            this.chk41.Name = "chk41";
            this.chk41.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chk41.Size = new System.Drawing.Size(225, 15);
            this.chk41.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chk41.TabIndex = 1023;
            this.chk41.Text = "تحويل تكلفة الصنف الى سعر العملة الإفتراضية";
            // 
            // superTabItem2
            // 
            this.superTabItem2.AttachedControl = this.superTabControlPanel8;
            this.superTabItem2.GlobalItem = false;
            this.superTabItem2.Name = "superTabItem2";
            this.superTabItem2.Text = "<<<";
            // 
            // superTabControlPanel9
            // 
            this.superTabControlPanel9.Controls.Add(this.chk75);
            this.superTabControlPanel9.Controls.Add(this.chk74);
            this.superTabControlPanel9.Controls.Add(this.chk73);
            this.superTabControlPanel9.Controls.Add(this.chk72);
            this.superTabControlPanel9.Controls.Add(this.label81);
            this.superTabControlPanel9.Controls.Add(this.integerInput1);
            this.superTabControlPanel9.Controls.Add(this.checkBoxX2);
            this.superTabControlPanel9.Controls.Add(this.chk68);
            this.superTabControlPanel9.Controls.Add(this.chk67);
            this.superTabControlPanel9.Controls.Add(this.chk66);
            this.superTabControlPanel9.Controls.Add(this.chk64);
            this.superTabControlPanel9.Controls.Add(this.chk50);
            this.superTabControlPanel9.Controls.Add(this.chk63);
            this.superTabControlPanel9.Controls.Add(this.chk62);
            this.superTabControlPanel9.Controls.Add(this.chk61);
            this.superTabControlPanel9.Controls.Add(this.chk60);
            this.superTabControlPanel9.Controls.Add(this.chk59);
            this.superTabControlPanel9.Controls.Add(this.label82);
            this.superTabControlPanel9.Controls.Add(this.integerInput2);
            this.superTabControlPanel9.Controls.Add(this.checkBoxX4);
            this.superTabControlPanel9.Controls.Add(this.chk57);
            this.superTabControlPanel9.Controls.Add(this.chk55);
            this.superTabControlPanel9.Controls.Add(this.chk54);
            this.superTabControlPanel9.Controls.Add(this.chk53);
            this.superTabControlPanel9.Controls.Add(this.chk52);
            this.superTabControlPanel9.Controls.Add(this.chk18);
            this.superTabControlPanel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel9.Location = new System.Drawing.Point(0, 0);
            this.superTabControlPanel9.Name = "superTabControlPanel9";
            this.superTabControlPanel9.Size = new System.Drawing.Size(1069, 363);
            this.superTabControlPanel9.TabIndex = 0;
            this.superTabControlPanel9.TabItem = this.superTabItem3;
            // 
            // chk75
            // 
            this.chk75.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right));
            this.chk75.AutoSize = true;
            this.chk75.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chk75.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.chk75.BackgroundStyle.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.chk75.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.chk75.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.chk75.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.chk75.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chk75.Location = new System.Drawing.Point(202, 197);
            this.chk75.Name = "chk75";
            this.chk75.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chk75.Size = new System.Drawing.Size(254, 15);
            this.chk75.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chk75.TabIndex = 1083;
            this.chk75.Text = "عرض قائمة بتواريخ الصلاحية للصنف عند قراءة الباركود";
            // 
            // chk74
            // 
            this.chk74.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right));
            this.chk74.AutoSize = true;
            this.chk74.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chk74.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.chk74.BackgroundStyle.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.chk74.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.chk74.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.chk74.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.chk74.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chk74.Location = new System.Drawing.Point(169, 251);
            this.chk74.Name = "chk74";
            this.chk74.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chk74.Size = new System.Drawing.Size(286, 15);
            this.chk74.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chk74.TabIndex = 1082;
            this.chk74.Text = "ايقاف طباعة التصنيفات للطلب المحلي في شاشة نقاط البيع";
            // 
            // chk73
            // 
            this.chk73.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right));
            this.chk73.AutoSize = true;
            this.chk73.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chk73.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chk73.Enabled = false;
            this.chk73.Location = new System.Drawing.Point(517, 116);
            this.chk73.Name = "chk73";
            this.chk73.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chk73.Size = new System.Drawing.Size(247, 15);
            this.chk73.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chk73.TabIndex = 1081;
            this.chk73.Text = "جبر سعر البيع بعد إضافة الضريبة عند طباعة الباركود";
            // 
            // chk72
            // 
            this.chk72.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right));
            this.chk72.AutoSize = true;
            this.chk72.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chk72.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.chk72.BackgroundStyle.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.chk72.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.chk72.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.chk72.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.chk72.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chk72.Location = new System.Drawing.Point(218, 170);
            this.chk72.Name = "chk72";
            this.chk72.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chk72.Size = new System.Drawing.Size(239, 15);
            this.chk72.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chk72.TabIndex = 1080;
            this.chk72.Text = "تحكم يدوي للتواريخ الهجرية والميلادية في الفواتير";
            // 
            // label81
            // 
            this.label81.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right));
            this.label81.AutoSize = true;
            this.label81.BackColor = System.Drawing.Color.Transparent;
            this.label81.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label81.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label81.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label81.Location = new System.Drawing.Point(233, 89);
            this.label81.Name = "label81";
            this.label81.Size = new System.Drawing.Size(22, 13);
            this.label81.TabIndex = 1079;
            this.label81.Text = "يوم";
            // 
            // integerInput1
            // 
            this.integerInput1.AllowEmptyState = false;
            this.integerInput1.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right));
            // 
            // 
            // 
            this.integerInput1.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(198)))));
            this.integerInput1.BackgroundStyle.Class = "DateTimeInputBackground";
            this.integerInput1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.integerInput1.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.integerInput1.DisplayFormat = "0";
            this.integerInput1.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Bold);
            this.integerInput1.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.integerInput1.Location = new System.Drawing.Point(260, 87);
            this.integerInput1.MinValue = 0;
            this.integerInput1.Name = "integerInput1";
            this.integerInput1.Size = new System.Drawing.Size(341, 19);
            this.integerInput1.TabIndex = 1078;
            // 
            // checkBoxX2
            // 
            this.checkBoxX2.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right));
            this.checkBoxX2.AutoSize = true;
            this.checkBoxX2.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.checkBoxX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBoxX2.Location = new System.Drawing.Point(319, 89);
            this.checkBoxX2.Name = "checkBoxX2";
            this.checkBoxX2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBoxX2.Size = new System.Drawing.Size(141, 15);
            this.checkBoxX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBoxX2.TabIndex = 1077;
            this.checkBoxX2.Text = "تنبيه بتاريخ الإستحقاق قبل";
            // 
            // chk68
            // 
            this.chk68.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right));
            this.chk68.AutoSize = true;
            this.chk68.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chk68.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chk68.Location = new System.Drawing.Point(231, 62);
            this.chk68.Name = "chk68";
            this.chk68.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chk68.Size = new System.Drawing.Size(227, 15);
            this.chk68.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chk68.TabIndex = 1076;
            this.chk68.Text = "تشغيل الشاشات الفرعية لقراءة باركود الأصناف";
            // 
            // chk67
            // 
            this.chk67.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right));
            this.chk67.AutoSize = true;
            this.chk67.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chk67.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chk67.Location = new System.Drawing.Point(229, 35);
            this.chk67.Name = "chk67";
            this.chk67.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chk67.Size = new System.Drawing.Size(228, 15);
            this.chk67.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chk67.TabIndex = 1075;
            this.chk67.Text = "إخفاء ايقونات الاصناف والتصنيفات في نقاط البيع";
            // 
            // chk66
            // 
            this.chk66.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right));
            this.chk66.AutoSize = true;
            this.chk66.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chk66.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chk66.Location = new System.Drawing.Point(239, 8);
            this.chk66.Name = "chk66";
            this.chk66.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chk66.Size = new System.Drawing.Size(218, 15);
            this.chk66.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chk66.TabIndex = 1074;
            this.chk66.Text = "إخفاء قائمة الأسعار في المبيعات والمشتريات";
            // 
            // chk64
            // 
            this.chk64.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right));
            this.chk64.AutoSize = true;
            this.chk64.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chk64.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chk64.Location = new System.Drawing.Point(304, 143);
            this.chk64.Name = "chk64";
            this.chk64.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chk64.Size = new System.Drawing.Size(155, 15);
            this.chk64.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chk64.TabIndex = 1073;
            this.chk64.Text = "تفعيل خيار النقاط في المبيعات";
            // 
            // chk50
            // 
            this.chk50.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right));
            this.chk50.AutoSize = true;
            this.chk50.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chk50.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.chk50.BackgroundStyle.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.chk50.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.chk50.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.chk50.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.chk50.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chk50.Location = new System.Drawing.Point(363, 224);
            this.chk50.Name = "chk50";
            this.chk50.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chk50.Size = new System.Drawing.Size(98, 15);
            this.chk50.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chk50.TabIndex = 1072;
            this.chk50.Text = "طباعة رقم الطلب";
            // 
            // chk63
            // 
            this.chk63.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right));
            this.chk63.AutoSize = true;
            this.chk63.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chk63.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chk63.Location = new System.Drawing.Point(544, 305);
            this.chk63.Name = "chk63";
            this.chk63.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chk63.Size = new System.Drawing.Size(221, 15);
            this.chk63.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chk63.TabIndex = 1071;
            this.chk63.Text = "منع إدخال المدفوع بمبلغ اقل من المدفوع نقداً";
            // 
            // chk62
            // 
            this.chk62.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right));
            this.chk62.AutoSize = true;
            this.chk62.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chk62.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chk62.Location = new System.Drawing.Point(543, 278);
            this.chk62.Name = "chk62";
            this.chk62.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chk62.Size = new System.Drawing.Size(221, 15);
            this.chk62.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chk62.TabIndex = 1070;
            this.chk62.Text = "اظهار زر الاضافات الخاصة مع ملاحظات الفاتورة";
            // 
            // chk61
            // 
            this.chk61.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right));
            this.chk61.AutoSize = true;
            this.chk61.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chk61.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chk61.Location = new System.Drawing.Point(585, 251);
            this.chk61.Name = "chk61";
            this.chk61.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chk61.Size = new System.Drawing.Size(180, 15);
            this.chk61.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chk61.TabIndex = 1069;
            this.chk61.Text = "إظهار شاشة الإضافات الخاصة تلقائيا";
            // 
            // chk60
            // 
            this.chk60.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right));
            this.chk60.AutoSize = true;
            this.chk60.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chk60.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chk60.Location = new System.Drawing.Point(545, 197);
            this.chk60.Name = "chk60";
            this.chk60.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chk60.Size = new System.Drawing.Size(220, 15);
            this.chk60.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chk60.TabIndex = 1068;
            this.chk60.Text = "إظهار اجمالي الفاتورة مع الضريبة عند الطباعة";
            // 
            // chk59
            // 
            this.chk59.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right));
            this.chk59.AutoSize = true;
            this.chk59.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chk59.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chk59.Location = new System.Drawing.Point(581, 170);
            this.chk59.Name = "chk59";
            this.chk59.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chk59.Size = new System.Drawing.Size(184, 15);
            this.chk59.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chk59.TabIndex = 1067;
            this.chk59.Text = "إخفاء سطور قيمة الضريبة في الفواتير";
            // 
            // label82
            // 
            this.label82.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right));
            this.label82.AutoSize = true;
            this.label82.BackColor = System.Drawing.Color.Transparent;
            this.label82.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label82.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label82.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label82.Location = new System.Drawing.Point(539, 224);
            this.label82.Name = "label82";
            this.label82.Size = new System.Drawing.Size(22, 13);
            this.label82.TabIndex = 1066;
            this.label82.Text = "يوم";
            // 
            // integerInput2
            // 
            this.integerInput2.AllowEmptyState = false;
            this.integerInput2.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right));
            // 
            // 
            // 
            this.integerInput2.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(198)))));
            this.integerInput2.BackgroundStyle.Class = "DateTimeInputBackground";
            this.integerInput2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.integerInput2.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.integerInput2.DisplayFormat = "0";
            this.integerInput2.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Bold);
            this.integerInput2.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.integerInput2.Location = new System.Drawing.Point(566, 222);
            this.integerInput2.MinValue = 0;
            this.integerInput2.Name = "integerInput2";
            this.integerInput2.Size = new System.Drawing.Size(334, 19);
            this.integerInput2.TabIndex = 1065;
            // 
            // checkBoxX4
            // 
            this.checkBoxX4.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right));
            this.checkBoxX4.AutoSize = true;
            this.checkBoxX4.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.checkBoxX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBoxX4.Location = new System.Drawing.Point(615, 224);
            this.checkBoxX4.Name = "checkBoxX4";
            this.checkBoxX4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBoxX4.Size = new System.Drawing.Size(152, 15);
            this.checkBoxX4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBoxX4.TabIndex = 1064;
            this.checkBoxX4.Text = "احتساب تاريخ الأستحقاق بعد";
            // 
            // chk57
            // 
            this.chk57.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right));
            this.chk57.AutoSize = true;
            this.chk57.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chk57.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chk57.Location = new System.Drawing.Point(575, 143);
            this.chk57.Name = "chk57";
            this.chk57.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chk57.Size = new System.Drawing.Size(190, 15);
            this.chk57.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chk57.TabIndex = 1063;
            this.chk57.Text = "احتساب الربح في المبيعات مع الضريبة";
            // 
            // chk55
            // 
            this.chk55.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right));
            this.chk55.AutoSize = true;
            this.chk55.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chk55.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chk55.Location = new System.Drawing.Point(519, 89);
            this.chk55.Name = "chk55";
            this.chk55.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chk55.Size = new System.Drawing.Size(245, 15);
            this.chk55.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chk55.TabIndex = 1062;
            this.chk55.Text = "اعتمـــاد سعـــر البيع مع الضريبة عند طباعة الباركود";
            // 
            // chk54
            // 
            this.chk54.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right));
            this.chk54.AutoSize = true;
            this.chk54.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chk54.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chk54.Location = new System.Drawing.Point(536, 62);
            this.chk54.Name = "chk54";
            this.chk54.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chk54.Size = new System.Drawing.Size(229, 15);
            this.chk54.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chk54.TabIndex = 1061;
            this.chk54.Text = "إعتماد سعر اخر بيع حسب العميل في المبيعات";
            // 
            // chk53
            // 
            this.chk53.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right));
            this.chk53.AutoSize = true;
            this.chk53.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chk53.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chk53.Location = new System.Drawing.Point(569, 35);
            this.chk53.Name = "chk53";
            this.chk53.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chk53.Size = new System.Drawing.Size(196, 15);
            this.chk53.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chk53.TabIndex = 1060;
            this.chk53.Text = "جمع خصم السطور  وقيمة خصم الفاتورة";
            // 
            // chk52
            // 
            this.chk52.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right));
            this.chk52.AutoSize = true;
            this.chk52.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chk52.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chk52.Location = new System.Drawing.Point(604, 8);
            this.chk52.Name = "chk52";
            this.chk52.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chk52.Size = new System.Drawing.Size(163, 15);
            this.chk52.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chk52.TabIndex = 1059;
            this.chk52.Text = "جبر إجمــالي الفواتيــر الكســرية";
            // 
            // chk18
            // 
            this.chk18.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right));
            this.chk18.AutoSize = true;
            this.chk18.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chk18.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chk18.Location = new System.Drawing.Point(248, 116);
            this.chk18.Name = "chk18";
            this.chk18.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chk18.Size = new System.Drawing.Size(209, 15);
            this.chk18.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chk18.TabIndex = 1058;
            this.chk18.Text = "إعتماد شاشة المبيعات الداخلية لنقاط البيع";
            // 
            // superTabItem3
            // 
            this.superTabItem3.AttachedControl = this.superTabControlPanel9;
            this.superTabItem3.GlobalItem = false;
            this.superTabItem3.Name = "superTabItem3";
            this.superTabItem3.Text = "<<<";
            // 
            // superTabControlPanel10
            // 
            this.superTabControlPanel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel10.Location = new System.Drawing.Point(0, 0);
            this.superTabControlPanel10.Name = "superTabControlPanel10";
            this.superTabControlPanel10.Size = new System.Drawing.Size(1069, 363);
            this.superTabControlPanel10.TabIndex = 0;
            // 
            // superTabItem4
            // 
            this.superTabItem4.AttachedControl = this.superTabControlPanel12;
            this.superTabItem4.GlobalItem = false;
            this.superTabItem4.Name = "superTabItem4";
            this.superTabItem4.Text = "superTabItem4";
            this.superTabItem4.Visible = false;
            // 
            // labelItem1
            // 
            this.labelItem1.Name = "labelItem1";
            // 
            // progressBarX1
            // 
            // 
            // 
            // 
            this.progressBarX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.progressBarX1.ColorTable = DevComponents.DotNetBar.eProgressBarItemColor.Paused;
            this.progressBarX1.Location = new System.Drawing.Point(58, 106);
            this.progressBarX1.Name = "progressBarX1";
            this.progressBarX1.Size = new System.Drawing.Size(140, 20);
            this.progressBarX1.TabIndex = 4;
            this.progressBarX1.Text = "progressBarX1";
            this.progressBarX1.Value = 63;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "*.bmp|*.dip|*.gif|*.jpg|*.wmf|*.emf";
            this.openFileDialog1.SupportMultiDottedExtensions = true;
            // 
            // ButWithoutSave
            // 
            this.ButWithoutSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.ButWithoutSave.Checked = true;
            this.ButWithoutSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.ButWithoutSave.Dock = System.Windows.Forms.DockStyle.Left;
            this.ButWithoutSave.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.ButWithoutSave.Location = new System.Drawing.Point(0, 0);
            this.ButWithoutSave.Name = "ButWithoutSave";
            this.netResize1.SetResizeFont(this.ButWithoutSave, false);
            this.ButWithoutSave.Size = new System.Drawing.Size(501, 42);
            this.ButWithoutSave.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ButWithoutSave.Symbol = "";
            this.ButWithoutSave.SymbolSize = 16F;
            this.ButWithoutSave.TabIndex = 6787;
            this.ButWithoutSave.Text = "خـــروج";
            this.ButWithoutSave.TextColor = System.Drawing.Color.Black;
            this.ButWithoutSave.Click += new System.EventHandler(this.ButWithoutSave_Click);
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.ribbonBar1);
            this.splitContainer4.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.ButWithSave);
            this.splitContainer4.Panel2.Controls.Add(this.ButWithoutSave);
            this.splitContainer4.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.splitContainer4.Size = new System.Drawing.Size(1069, 575);
            this.splitContainer4.SplitterDistance = 529;
            this.splitContainer4.TabIndex = 6811;
            // 
            // ButWithSave
            // 
            this.ButWithSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.ButWithSave.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.ButWithSave.Dock = System.Windows.Forms.DockStyle.Right;
            this.ButWithSave.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.ButWithSave.Location = new System.Drawing.Point(557, 0);
            this.ButWithSave.Name = "ButWithSave";
            this.netResize1.SetResizeFont(this.ButWithSave, false);
            this.ButWithSave.Size = new System.Drawing.Size(512, 42);
            this.ButWithSave.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ButWithSave.Symbol = "";
            this.ButWithSave.SymbolSize = 16F;
            this.ButWithSave.TabIndex = 6788;
            this.ButWithSave.Text = "حفــــظ";
            this.ButWithSave.TextColor = System.Drawing.Color.White;
            this.ButWithSave.Click += new System.EventHandler(this.ButWithSave_Click);
            // 
            // netResize1
            // 
            this.netResize1.ParentControl = this;
            this.netResize1.AfterControlResize += new Softgroup.NetResize.NetResize.AfterControlResizeEventHandler(this.netResize1_AfterControlResize);
            // 
            // FrmSystemSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1069, 575);
            this.Controls.Add(this.splitContainer4);
            this.Icon = global::InvAcc.Properties.Resources.favicon;
            this.KeyPreview = true;
            this.Name = "FrmSystemSetting";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmSystemSetting_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Frm_KeyPress);
            this.ribbonBar1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl1)).EndInit();
            this.superTabControl1.ResumeLayout(false);
            this.superTabControlPanel5.ResumeLayout(false);
            this.superTabControlPanel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numbersafterdecimal)).EndInit();
            this.groupPanel_Acc.ResumeLayout(false);
            this.groupPanel_Acc.PerformLayout();
            this.groupPanel_Backup.ResumeLayout(false);
            this.groupPanel_Backup.PerformLayout();
            this.groupPanel2.ResumeLayout(false);
            this.groupPanel2.PerformLayout();
            this.groupPanel4.ResumeLayout(false);
            this.groupPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtLinesInv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateAlarmEmps)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAutoNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateAlarm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_SSS)).EndInit();
            this.superTabControlPanel2.ResumeLayout(false);
            this.superTabControlPanel2.PerformLayout();
            this.groupPanel1.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.Panel2.PerformLayout();
            this.splitContainer3.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c1FlexGrid2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAlarmDeuDateBefor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateofInv)).EndInit();
            this.expandablePanel_NewColumn.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Tree_NewCol)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.superTabControlPanel1.ResumeLayout(false);
            this.superTabControlPanel1.PerformLayout();
            this.groupPanel17.ResumeLayout(false);
            this.groupPanel17.PerformLayout();
            this.groupPanel6.ResumeLayout(false);
            this.groupPanel6.PerformLayout();
            this.groupPanel16.ResumeLayout(false);
            this.groupPanel16.PerformLayout();
            this.groupPanel5.ResumeLayout(false);
            this.groupPanel5.PerformLayout();
            this.groupPanel_Banner.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PicItemImg)).EndInit();
            this.groupPanel3.ResumeLayout(false);
            this.groupPanel3.PerformLayout();
            this.superTabControlPanel3.ResumeLayout(false);
            this.expandablePanel_AutoAcc.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FlxInv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1FlexGrid1)).EndInit();
            this.groupbox_AutoAcc.ResumeLayout(false);
            this.groupbox_AutoAcc.PerformLayout();
            this.superTabControlPanel15.ResumeLayout(false);
            this.groupPanel12.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c1FlexGrid1Bankopp)).EndInit();
            this.superTabControlPanel6.ResumeLayout(false);
            this.expandablePanel_Alarm.ResumeLayout(false);
            this.groupPanel9.ResumeLayout(false);
            this.groupPanel9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.integerInput_AlarmEndVactionBefore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.integerInput_AlarmVisaGoBack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.integerInput_AlarmCarDocBefore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.integerInput_AlarmSecretariatsBefore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.integerInput_AlarmFamilyPassportBefore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.integerInput_AlarmEmpContractBefore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.integerInput_AlarmEmpDocBefore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.integerInput_AlarmGuarantorDocBefore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.integerInput_AlarmDeptsBefore)).EndInit();
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            this.groupPanel7.ResumeLayout(false);
            this.groupPanel7.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupPanel8.ResumeLayout(false);
            this.groupPanel8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_AutoEmpLeaveAfter)).EndInit();
            this.superTabControlPanel13.ResumeLayout(false);
            this.superTabControlPanel13.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPurchaesTax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSalesTax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1FlexGriadTax)).EndInit();
            this.superTabControlPanel7.ResumeLayout(false);
            this.groupPanel11.ResumeLayout(false);
            this.groupPanel11.PerformLayout();
            this.groupPanel10.ResumeLayout(false);
            this.groupPanel10.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDayofMonth)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtRoom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFloors)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLongitudinal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWidthitudinal)).EndInit();
            this.superTabControlPanel11.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupPanel13.ResumeLayout(false);
            this.groupPanel13.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtEqarDayOfPayAlarm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEqarContractEndAlarm)).EndInit();
            this.superTabControlPanel14.ResumeLayout(false);
            this.groupPanel15.ResumeLayout(false);
            this.groupPanel15.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPriceQ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWieghtQ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPriceTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPriceFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWightTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWightFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBarcodTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBarcodFrom)).EndInit();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupPanel14.ResumeLayout(false);
            this.groupPanel_Main.ResumeLayout(false);
            this.groupPanel_Main.PerformLayout();
            this.groupPanel3CustDis.ResumeLayout(false);
            this.groupPanel3CustDis.PerformLayout();
            this.groupPanel2CustDis.ResumeLayout(false);
            this.groupPanel2CustDis.PerformLayout();
            this.groupPanel1CustDis.ResumeLayout(false);
            this.groupPanel1CustDis.PerformLayout();
            this.superTabControlPanel12.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl2)).EndInit();
            this.superTabControl2.ResumeLayout(false);
            this.superTabControlPanel8.ResumeLayout(false);
            this.superTabControlPanel8.PerformLayout();
            this.superTabControlPanel9.ResumeLayout(false);
            this.superTabControlPanel9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.integerInput1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.integerInput2)).EndInit();
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            this.splitContainer4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).EndInit();
            this.ResumeLayout(false);

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

        public FrmSystemSetting()
        {
            InitializeComponent();
            //this.Shown += FrmInvSale_Shown;
            this.SizeChanged += FrmInvSale_SizeChanged;
            textBox_LineDetailNameA.Click += Button_Edit_Click;
            textBox_LineDetailNameE.Click += Button_Edit_Click;
            txtAct.Click += Button_Edit_Click;
            txtAddr.Click += Button_Edit_Click;
            txtAutoNumber.Click += Button_Edit_Click;

            txtBoxAccount.Click += Button_Edit_Click;
            txtCompany.Click += Button_Edit_Click;
            txtDateAlarm.Click += Button_Edit_Click;
            txtDateofInv.Click += Button_Edit_Click;
            txtAlarmDeuDateBefor.Click += Button_Edit_Click;
            txtKeyNational.Click += Button_Edit_Click;
            txtDateAlarmEmps.Click += Button_Edit_Click;
            txtLinesInv.Click += Button_Edit_Click;
            //	txtDistance.Click += Button_Edit_Click;
            txtFax.Click += Button_Edit_Click;
            txtFirstInventory.Click += Button_Edit_Click;
            txtGuestsFatherAcc.Click += Button_Edit_Click;
            txtGuestBoxAcc.Click += Button_Edit_Click;
            radioButton_IsNotBackground.Click += Button_Edit_Click;
            txtGregDate.Click += Button_Edit_Click;
            txtEmailBoss.Click += Button_Edit_Click;
            txtEmailPass.Click += Button_Edit_Click;
            txtHeadingL1.Click += Button_Edit_Click;
            txtHeadingL2.Click += Button_Edit_Click;
            txtHeadingL3.Click += Button_Edit_Click;
            txtHeadingL4.Click += Button_Edit_Click;
            txtHeadingR1.Click += Button_Edit_Click;
            txtHeadingR2.Click += Button_Edit_Click;
            txtHeadingR3.Click += Button_Edit_Click;
            txtHeadingR4.Click += Button_Edit_Click;
            txtHijriDate.Click += Button_Edit_Click;
            txtLastInventory.Click += Button_Edit_Click;


            txtMailCode.Click += Button_Edit_Click;
            txtMobile.Click += Button_Edit_Click;
            txtPOBox.Click += Button_Edit_Click;
            txtProfits.Click += Button_Edit_Click;
            txtRemark.Click += Button_Edit_Click;
            txtTel1.Click += Button_Edit_Click;
            txtTel2.Click += Button_Edit_Click;

            ChkPageNumber.Click += Button_Edit_Click;
            ChkGreg.Click += Button_Edit_Click;
            ChkHijri.Click += Button_Edit_Click;
            ChkHead.Click += Button_Edit_Click;
            textBox_SyncPath.ButtonCustomClick += Button_Edit_Click;
            textBox_BackupPath.ButtonCustomClick += Button_Edit_Click;
            textBox_BackupElectronic.ButtonCustomClick += Button_Edit_Click;
            checkBox_AutoBackup.Click += Button_Edit_Click;

            CmbCalendar.Click += Button_Edit_Click;
            CmbCost.Click += Button_Edit_Click;
            CmbDateTyp.Click += Button_Edit_Click;
            CmbCurr.Click += Button_Edit_Click;
            CmbInvMode.Click += Button_Edit_Click;

            CmbMail.Click += Button_Edit_Click;
            chk1.Click += Button_Edit_Click;
            chk2.Click += Button_Edit_Click;
            chk3.Click += Button_Edit_Click;
            //chk4.Click += Button_Edit_Click;
            //chk5.Click += Button_Edit_Click;
            //chk6.Click += Button_Edit_Click;
            //chk7.Click += Button_Edit_Click;
            //chk8.Click += Button_Edit_Click;
            //chk9.Click += Button_Edit_Click;
            //chk10.Click += Button_Edit_Click;
            //chk11.Click += Button_Edit_Click;
            //chk12.Click += Button_Edit_Click;
            //chk13.Click += Button_Edit_Click;
            //chk14.Click += Button_Edit_Click;
            //chk15.Click += Button_Edit_Click;
            //chk16.Click += Button_Edit_Click;
            //chk17.Click += Button_Edit_Click;
            //chk18.Click += Button_Edit_Click;
            //chk19.Click += Button_Edit_Click;
            //chk20.Click += Button_Edit_Click;
            //chk21.Click += Button_Edit_Click;
            //chk22.Click += Button_Edit_Click;
            //chk23.Click += Button_Edit_Click;
            //chk24.Click += Button_Edit_Click;
            //chk25.Click += Button_Edit_Click;
            //chk26.Click += Button_Edit_Click;
            //chk27.Click += Button_Edit_Click;
            //chk28.Click += Button_Edit_Click;
            //chk29.Click += Button_Edit_Click;
            //chk31.Click += Button_Edit_Click;
            //chk32.Click += Button_Edit_Click;
            //chk33.Click += Button_Edit_Click;
            //chk34.Click += Button_Edit_Click;
            //chk35.Click += Button_Edit_Click;
            //chk36.Click += Button_Edit_Click;
            //chk37.Click += Button_Edit_Click;
            //chk38.Click += Button_Edit_Click;
            //chk39.Click += Button_Edit_Click;
            //chk40.Click += Button_Edit_Click;
            //chk41.Click += Button_Edit_Click;
            chk42.Click += Button_Edit_Click;
            chk43.Click += Button_Edit_Click;
            chk44.Click += Button_Edit_Click;
            chk45.Click += Button_Edit_Click;
            chk46.Click += Button_Edit_Click;
            //chk47.Click += Button_Edit_Click;
            //chk48.Click += Button_Edit_Click;
            //chk49.Click += Button_Edit_Click;
            //chk50.Click += Button_Edit_Click;
            //chk51.Click += Button_Edit_Click;
            //chk52.Click += Button_Edit_Click;
            //chk53.Click += Button_Edit_Click;
            //chk54.Click += Button_Edit_Click;
            //chk55.Click += Button_Edit_Click;
            //chk56.Click += Button_Edit_Click;
            //chk57.Click += Button_Edit_Click;
            //chk58.Click += Button_Edit_Click;
            //chk59.Click += Button_Edit_Click;
            //chk60.Click += Button_Edit_Click;
            //chk61.Click += Button_Edit_Click;
            //chk62.Click += Button_Edit_Click;
            //chk63.Click += Button_Edit_Click;
            //chk64.Click += Button_Edit_Click;
            //chk65.Click += Button_Edit_Click;
            //chk66.Click += Button_Edit_Click;
            //chk67.Click += Button_Edit_Click;
            //chk68.Click += Button_Edit_Click;
            //chk69.Click += Button_Edit_Click;
            //chk70.Click += Button_Edit_Click;
            //chk71.Click += Button_Edit_Click;
            //chk72.Click += Button_Edit_Click;
            //chk73.Click += Button_Edit_Click;
            //chk74.Click += Button_Edit_Click;
            //chk75.Click += Button_Edit_Click;
            chk76.Click += Button_Edit_Click;
            chk77.Click += Button_Edit_Click;
            Tree_NewCol.Click += Button_Edit_Click;
            CmbPrintTyp.Click += Button_Edit_Click;
            CmbPointImages.Click += Button_Edit_Click;
            CmbOrderTyp.Click += Button_Edit_Click;
            txtFloors.Click += Button_Edit_Click;
            txtRoom.Click += Button_Edit_Click;
            txtAllowPeriod.Click += Button_Edit_Click;
            txtLeavePeriod.Click += Button_Edit_Click;
            txtDayofMonth.Click += Button_Edit_Click;
            txtLongitudinal.Click += Button_Edit_Click;
            txtWidthitudinal.Click += Button_Edit_Click;
            button_B1.Click += Button_Edit_Click;
            button_B2.Click += Button_Edit_Click;
            button_B3.Click += Button_Edit_Click;
            button_B4.Click += Button_Edit_Click;
            button_B5.Click += Button_Edit_Click;
            button_B6.Click += Button_Edit_Click;
            button_B7.Click += Button_Edit_Click;
            button_B8.Click += Button_Edit_Click;
            button_F1.Click += Button_Edit_Click;
            button_F2.Click += Button_Edit_Click;
            button_F3.Click += Button_Edit_Click;
            button_F4.Click += Button_Edit_Click;
            button_F5.Click += Button_Edit_Click;
            button_F6.Click += Button_Edit_Click;
            button_F7.Click += Button_Edit_Click;
            button_F8.Click += Button_Edit_Click;
            RadioBox_AllowAM.Click += Button_Edit_Click;
            RadioBox_AllowPM.Click += Button_Edit_Click;
            RadioBox_LeaveAM.Click += Button_Edit_Click;
            RadioBox_LeavePM.Click += Button_Edit_Click;
            txtEqarContractEndAlarm.Click += Button_Edit_Click;
            txtEqarDayOfPayAlarm.Click += Button_Edit_Click;
            txtEqarsFatherAcc.Click += Button_Edit_Click;
            txtEqarsFatherAccName.Click += Button_Edit_Click;
            txtTenantFatherAcc.Click += Button_Edit_Click;
            txttenantFatherAccName.Click += Button_Edit_Click;
            ChkEmp1.Click += Button_Edit_Click;
            textBox_AutoEmpLeaveAfter.Click += Button_Edit_Click;
            integerInput_AlarmEmpContractBefore.Click += Button_Edit_Click;
            integerInput_AlarmEmpDocBefore.Click += Button_Edit_Click;
            integerInput_AlarmEndVactionBefore.Click += Button_Edit_Click;
            integerInput_AlarmFamilyPassportBefore.Click += Button_Edit_Click;
            integerInput_AlarmGuarantorDocBefore.Click += Button_Edit_Click;
            integerInput_AlarmCarDocBefore.Click += Button_Edit_Click;
            integerInput_AlarmSecretariatsBefore.Click += Button_Edit_Click;
            integerInput_AlarmVisaGoBack.Click += Button_Edit_Click;
            integerInput_AlarmDeptsBefore.Click += Button_Edit_Click;
            checkBox_IsAlarmEmpContract.Click += Button_Edit_Click;
            checkBox_IsAlarmEmpDoc.Click += Button_Edit_Click;
            checkBox_IsAlarmEndVaction.Click += Button_Edit_Click;
            checkBox_IsAlarmFamilyPassport.Click += Button_Edit_Click;
            checkBox_IsAlarmGuarantorDoc.Click += Button_Edit_Click;
            checkBox_IsAlarmCarDoc.Click += Button_Edit_Click;
            checkBox_IsAlarmSecretariatsDoc.Click += Button_Edit_Click;
            checkBox_IsAlarmVisaGoBack.Click += Button_Edit_Click;
            checkBox_IsAlarmDepts.Click += Button_Edit_Click;
            radioButton_IsNotBackground.Click += Button_Edit_Click;
            checkBox_AttendanceManually.Click += Button_Edit_Click;
            checkBox_AutoLeave.Click += Button_Edit_Click;
            checkBox_VacationManually.Click += Button_Edit_Click;
            checkBox_Sponer.Click += Button_Edit_Click;
            comboBox_CalculateNo.Click += Button_Edit_Click;
            comboBox_DisVacationType.Click += Button_Edit_Click;
            comboBox_CalculatliquidNo.Click += Button_Edit_Click;
            button_DocPath.Click += Button_Edit_Click;
            comboBox_AutoBackup.Click += Button_Edit_Click;
            if (VarGeneral.SSSLev == "S")
            {
                chk10.Visible = false;
            }
            else
            {
                chk10.Visible = true;
                if (VarGeneral.SSSLev == "D" || VarGeneral.SSSLev == "E")
                {
                    superTabItem_Employee.Visible = true;
                    chk19.Visible = false;
                    txtDateAlarmEmps.Visible = false;
                    if (VarGeneral.SSSLev == "E")
                    {
                        chk20.Visible = false;
                        chk21.Visible = false;
                        chk22.Visible = false;
                        chk23.Visible = false;
                        chk29.Visible = false;
                        label51.Visible = false;
                        CmbPointImages.Visible = false;
                    }
                    label47.Visible = false;
                }
            }
            if (VarGeneral.gUserName == "runsetting" && VarGeneral.UserID != 1)
            {
                chk37.IsReadOnly = true;
                checkBox_AutoBackup.Enabled = false;
                comboBox_AutoBackup.Enabled = false;
            }
            if (VarGeneral.gUserName == "runsetting" && VarGeneral.UserID == 1)
            {
                textBox_BackupElectronic.ButtonCustom2.Visible = true;
            }
            if (!VarGeneral.EmpSystem)
            {
                superTabItem_Employee.Visible = false;
            }
            if (VarGeneral.UserID != 1)
            {
                textBox_SyncPath.ReadOnly = true;
                textBox_SyncPath.ForeColor = Color.White;
            }
        }
        private void Frm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                SendKeys.Send("{Tab}");
            }
            FrmTaxOpiton_KeyPress(sender, e);
        }
        private void Frm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2 && ButWithSave.Enabled && ButWithSave.Visible)
            {
                ButWithSave_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
            FrmTaxOpiton_KeyDown(sender, e);
        }
        protected override void OnParentRightToLeftChanged(EventArgs e)
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmSystemSetting));
                if (base.Parent.RightToLeft == RightToLeft.Yes)
                {
                    SSSLanguage.Language.ChangeLanguage("ar-SA", this, resources);
                    LangArEn = 0;
                }
                else
                {
                    SSSLanguage.Language.ChangeLanguage("en", this, resources);
                    LangArEn = 1;
                }
            }
            FillCombo();
            BindData();
        }
        private void NewColumnData()
        {
            textBox_LineDetailNameA.Text = (switchButton_NewColumnName.Value ? _SysSetting.LineDetailNameA : _SysSetting.LineGiftlNameA);
            textBox_LineDetailNameE.Text = (switchButton_NewColumnName.Value ? _SysSetting.LineDetailNameE : _SysSetting.LineGiftlNameE);
            chk1Show.Checked = (switchButton_NewColumnName.Value ? VarGeneral.TString.ChkStatShow(_SysSetting.LineDetailSts, 0) : VarGeneral.TString.ChkStatShow(_SysSetting.LineGiftSts, 0));
            chk1Print.Checked = (switchButton_NewColumnName.Value ? VarGeneral.TString.ChkStatShow(_SysSetting.LineDetailSts, 1) : VarGeneral.TString.ChkStatShow(_SysSetting.LineGiftSts, 1));
            chk2Show.Checked = (switchButton_NewColumnName.Value ? VarGeneral.TString.ChkStatShow(_SysSetting.LineDetailSts, 2) : VarGeneral.TString.ChkStatShow(_SysSetting.LineGiftSts, 2));
            chk2Print.Checked = (switchButton_NewColumnName.Value ? VarGeneral.TString.ChkStatShow(_SysSetting.LineDetailSts, 3) : VarGeneral.TString.ChkStatShow(_SysSetting.LineGiftSts, 3));
            chk3Show.Checked = (switchButton_NewColumnName.Value ? VarGeneral.TString.ChkStatShow(_SysSetting.LineDetailSts, 4) : VarGeneral.TString.ChkStatShow(_SysSetting.LineGiftSts, 4));
            chk3Print.Checked = (switchButton_NewColumnName.Value ? VarGeneral.TString.ChkStatShow(_SysSetting.LineDetailSts, 5) : VarGeneral.TString.ChkStatShow(_SysSetting.LineGiftSts, 5));
            chk4Show.Checked = (switchButton_NewColumnName.Value ? VarGeneral.TString.ChkStatShow(_SysSetting.LineDetailSts, 6) : VarGeneral.TString.ChkStatShow(_SysSetting.LineGiftSts, 6));
            chk4Print.Checked = (switchButton_NewColumnName.Value ? VarGeneral.TString.ChkStatShow(_SysSetting.LineDetailSts, 7) : VarGeneral.TString.ChkStatShow(_SysSetting.LineGiftSts, 7));
            chk5Show.Checked = (switchButton_NewColumnName.Value ? VarGeneral.TString.ChkStatShow(_SysSetting.LineDetailSts, 8) : VarGeneral.TString.ChkStatShow(_SysSetting.LineGiftSts, 8));
            chk5Print.Checked = (switchButton_NewColumnName.Value ? VarGeneral.TString.ChkStatShow(_SysSetting.LineDetailSts, 9) : VarGeneral.TString.ChkStatShow(_SysSetting.LineGiftSts, 9));
            chk6Show.Checked = (switchButton_NewColumnName.Value ? VarGeneral.TString.ChkStatShow(_SysSetting.LineDetailSts, 10) : VarGeneral.TString.ChkStatShow(_SysSetting.LineGiftSts, 10));
            chk6Print.Checked = (switchButton_NewColumnName.Value ? VarGeneral.TString.ChkStatShow(_SysSetting.LineDetailSts, 11) : VarGeneral.TString.ChkStatShow(_SysSetting.LineGiftSts, 11));
            chk7Show.Checked = (switchButton_NewColumnName.Value ? VarGeneral.TString.ChkStatShow(_SysSetting.LineDetailSts, 12) : VarGeneral.TString.ChkStatShow(_SysSetting.LineGiftSts, 12));
            chk7Print.Checked = (switchButton_NewColumnName.Value ? VarGeneral.TString.ChkStatShow(_SysSetting.LineDetailSts, 13) : VarGeneral.TString.ChkStatShow(_SysSetting.LineGiftSts, 13));
            chk8Show.Checked = (switchButton_NewColumnName.Value ? VarGeneral.TString.ChkStatShow(_SysSetting.LineDetailSts, 14) : VarGeneral.TString.ChkStatShow(_SysSetting.LineGiftSts, 14));
            chk8Print.Checked = (switchButton_NewColumnName.Value ? VarGeneral.TString.ChkStatShow(_SysSetting.LineDetailSts, 15) : VarGeneral.TString.ChkStatShow(_SysSetting.LineGiftSts, 15));
            chk9Show.Checked = (switchButton_NewColumnName.Value ? VarGeneral.TString.ChkStatShow(_SysSetting.LineDetailSts, 16) : VarGeneral.TString.ChkStatShow(_SysSetting.LineGiftSts, 16));
            chk9Print.Checked = (switchButton_NewColumnName.Value ? VarGeneral.TString.ChkStatShow(_SysSetting.LineDetailSts, 17) : VarGeneral.TString.ChkStatShow(_SysSetting.LineGiftSts, 17));
            chk10Show.Checked = (switchButton_NewColumnName.Value ? VarGeneral.TString.ChkStatShow(_SysSetting.LineDetailSts, 18) : VarGeneral.TString.ChkStatShow(_SysSetting.LineGiftSts, 18));
            chk10Print.Checked = (switchButton_NewColumnName.Value ? VarGeneral.TString.ChkStatShow(_SysSetting.LineDetailSts, 19) : VarGeneral.TString.ChkStatShow(_SysSetting.LineGiftSts, 19));
            chk11Show.Checked = (switchButton_NewColumnName.Value ? VarGeneral.TString.ChkStatShow(_SysSetting.LineDetailSts, 20) : VarGeneral.TString.ChkStatShow(_SysSetting.LineGiftSts, 20));
            chk11Print.Checked = (switchButton_NewColumnName.Value ? VarGeneral.TString.ChkStatShow(_SysSetting.LineDetailSts, 21) : VarGeneral.TString.ChkStatShow(_SysSetting.LineGiftSts, 21));
            chk12Show.Checked = (switchButton_NewColumnName.Value ? VarGeneral.TString.ChkStatShow(_SysSetting.LineDetailSts, 22) : VarGeneral.TString.ChkStatShow(_SysSetting.LineGiftSts, 22));
            chk12Print.Checked = (switchButton_NewColumnName.Value ? VarGeneral.TString.ChkStatShow(_SysSetting.LineDetailSts, 23) : VarGeneral.TString.ChkStatShow(_SysSetting.LineGiftSts, 23));
            chk13Show.Checked = (switchButton_NewColumnName.Value ? VarGeneral.TString.ChkStatShow(_SysSetting.LineDetailSts, 24) : VarGeneral.TString.ChkStatShow(_SysSetting.LineGiftSts, 24));
            chk13Print.Checked = (switchButton_NewColumnName.Value ? VarGeneral.TString.ChkStatShow(_SysSetting.LineDetailSts, 25) : VarGeneral.TString.ChkStatShow(_SysSetting.LineGiftSts, 25));
            chk14Show.Checked = (switchButton_NewColumnName.Value ? VarGeneral.TString.ChkStatShow(_SysSetting.LineDetailSts, 26) : VarGeneral.TString.ChkStatShow(_SysSetting.LineGiftSts, 26));
            chk14Print.Checked = (switchButton_NewColumnName.Value ? VarGeneral.TString.ChkStatShow(_SysSetting.LineDetailSts, 27) : VarGeneral.TString.ChkStatShow(_SysSetting.LineGiftSts, 27));
        }
        private void BindData()
        {
            try
            {
                State = FormState.Saved;
                ButWithSave.Enabled = false;
                txtHijriDate.Tag = _SysSetting.HDat;
                txtGregDate.Text = VarGeneral.Gdate;
                txtHijriDate.Text = VarGeneral.Hdate;
                CmbCalendar.SelectedIndex = _SysSetting.Calendr.Value;
                txtAutoNumber.Text = _SysSetting.AutoItm.ToString();
                CmbDateTyp.SelectedIndex = int.Parse(_SysSetting.DMY.ToString());
                CmbMail.SelectedIndex = int.Parse(_SysSetting.DataBaseNm.ToString());
                if (!string.IsNullOrEmpty(_SysSetting.ImportIp))
                {
                    CmbCurr.SelectedValue = int.Parse(_SysSetting.ImportIp);
                }
                txtDateAlarm.Text = _SysSetting.LrnExp.ToString();
                try
                {
                    txtKeyNational.Text = _SysSetting.AccSup.Trim();
                }
                catch
                {
                    txtKeyNational.Text = string.Empty;
                }
                try
                {
                    if (!string.IsNullOrEmpty(_SysSetting.AccCus))
                    {
                        txtDateofInv.Value = int.Parse(_SysSetting.AccCus);
                    }
                    else
                    {
                        txtDateofInv.Value = 0;
                    }
                }
                catch
                {
                    txtDateofInv.Value = 0;
                }
                try
                {
                    if (_SysSetting.AlarmDueoBefore.HasValue)
                    {
                        txtAlarmDeuDateBefor.Value = _SysSetting.AlarmDueoBefore.Value;
                    }
                    else
                    {
                        txtAlarmDeuDateBefor.Value = 0;
                    }
                }
                catch
                {
                    txtAlarmDeuDateBefor.Value = 0;
                }
                txtDateAlarmEmps.Value = _SysSetting.AlarmEmployee.Value;
                try
                {
                    txtLinesInv.Value = _SysSetting.LineOfInvoices.Value;
                }
                catch
                {
                    txtLinesInv.Value = 100;
                }
                chk1.Checked = VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 0);
                chk2.Checked = VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 1);
                chk3.Checked = VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 2);
                chk9.Checked = VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 8);
                ChkHead.Checked = VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 9);
                ChkGreg.Checked = VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 10);
                ChkHijri.Checked = VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 11);
                ChkPageNumber.Checked = VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 12);
                CmbCost.SelectedIndex = int.Parse(_SysSetting.Seting.Substring(13, 1));
                chk10.Checked = VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 14);
                chk11.Checked = VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 15);
                chk12.Checked = VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 16);
                chk13.Checked = VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 17);
                chk14.Checked = VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 18);
                chk15.Checked = VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 19);
                chk16.Checked = VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 20);
                chk17.Checked = VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 21);
                chk18.Checked = VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 22);
                chk19.Checked = VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 23);
                chk20.Checked = VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 24);
                chk21.Checked = VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 25);
                chk22.Checked = VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 26);
                chk23.Checked = VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 27);
                chk24.Checked = VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 28);
                chk25.Checked = VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 29);
                chk26.Checked = VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 30);
                chk27.Checked = VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 31);
                chk28.Checked = VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 32);
                chk29.Checked = VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 33);
                chk31.Checked = VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 35);
                chk32.Checked = VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 36);
                chk33.Checked = VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 37);
                chk34.Checked = VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 38);
                chk35.Checked = VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 39);
                try
                {
                    chk36.SelectedIndex = int.Parse(_SysSetting.Seting.Substring(40, 1));
                }
                catch
                {
                    chk36.SelectedIndex = 0;
                }
                string g = getbno();
                if (g == "1")
                    chk37.Value = true;
                else
                    chk37.Value = false;
                chk38.Checked = VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 42);
                if (VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 34) && VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 43))
                {
                    chk39.SelectedIndex = 0;
                }
                else if (!VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 34) && !VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 43))
                {
                    chk39.SelectedIndex = 3;
                }
                else if (!VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 34))
                {
                    chk39.SelectedIndex = 1;
                }
                else
                {
                    chk39.SelectedIndex = 2;
                }
                chk40.Checked = VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 44);
                chk41.Checked = VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 45);
                chk42.Checked = VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 46);
                chk43.Checked = VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 47);
                chk44.Checked = VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 48);
                chk45.Checked = VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 49);
                if (_SysSetting.AfterDotNum == null)
                    _SysSetting.AfterDotNum = 3;
                numbersafterdecimal.Value = (int)_SysSetting.AfterDotNum;
                if (_SysSetting.AfterDotNum == null)
                    VarGeneral.setDecimalPointSettings(3);
                else
                    VarGeneral.setDecimalPointSettings((int)_SysSetting.AfterDotNum);
                chk45_CheckedChanged(null, null);
                try
                {
                    chk46.SelectedIndex = int.Parse(_SysSetting.Seting.Substring(50, 1));
                }
                catch
                {
                    chk46.SelectedIndex = 0;
                }
                chk47.Checked = VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 51);
                chk48.Checked = VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 52);
                chk49.Checked = VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 53);
                chk50.Checked = VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 54);
                chk51.Checked = VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 55);
                chk52.Checked = VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 56);
                chk53.Checked = VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 57);
                chk54.Checked = VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 58);
                if (!VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 59))
                {
                    CmbOrderTyp.SelectedIndex = 0;
                }
                else
                {
                    CmbOrderTyp.SelectedIndex = 1;
                }
                chk55.Checked = VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 60);
                chk56.Checked = VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 61);
                chk57.Checked = VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 62);
                chk58.Checked = VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 63);
                chk59.Checked = VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 64);
                chk60.Checked = VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 65);
                chk61.Checked = VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 66);
                chk62.Checked = VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 67);
                chk63.Checked = VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 68);
                chk64.Checked = VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 69);
                chk65.Checked = VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 70);
                chk66.Checked = VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 71);
                chk67.Checked = VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 72);
                chk68.Checked = VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 73);
                chk69.Checked = VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 74);
                chk70.Checked = VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 75);
                chk71.Checked = VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 76);
                chk72.Checked = VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 77);
                chk73.Checked = VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 78);
                chk74.Checked = VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 79);
                chk75.Checked = VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 80);
                chk76.Checked = VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 81);
                chk77.Checked = VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 82);
                if (_SysSetting.LogImg != null)
                {
                    byte[] arr = _SysSetting.LogImg.ToArray();
                    MemoryStream stream = new MemoryStream(arr);
                    PicItemImg.Image = Image.FromStream(stream);
                }
                radioButton_IsNotBackground.Checked = _SysSetting.IsNotBackground.Value;
                textBox_BackupPath.Text = _SysSetting.BackPath;
                textBox_BackupElectronic.Tag = _SysSetting.SysDir;
                textBox_SyncPath.Text = _SysSetting.SyncPath;
                checkBox_AutoBackup.Checked = _SysSetting.IsAutoBackup.Value;
                comboBox_AutoBackup.SelectedIndex = _SysSetting.AutoBackup.Value;
                if (CmbCost.SelectedIndex < 0)
                {
                    CmbCost.SelectedIndex = 0;
                }
                if (CmbCalendar.SelectedIndex < 0)
                {
                    CmbCalendar.SelectedIndex = 0;
                }
                if (CmbDateTyp.SelectedIndex < 0)
                {
                    CmbDateTyp.SelectedIndex = 0;
                }
                CmbInvMode.SelectedIndex = int.Parse(_SysSetting.InvMod.ToString());
                if (CmbInvMode.SelectedIndex < 0)
                {
                    CmbInvMode.SelectedIndex = 0;
                }
                CmbPrintTyp.SelectedIndex = _SysSetting.AutoEmp.Value;
                CmbPointImages.SelectedIndex = _SysSetting.Path_Kind.Value;
                txtEmailBoss.Text = _SysSetting.ServerNm.Trim();
                txtEmailPass.Text = _SysSetting.Sa_Pass;
                NewColumnData();
                if (string.IsNullOrEmpty(textBox_BackupElectronic.Tag.ToString()) || !Directory.Exists(VarGeneral.Settings_Sys.SysDir))
                {
                    textBox_BackupElectronic.Text = ((LangArEn == 0) ? "يتعذر الوصول الى مسار النسخ الإحتياطي" : "It not been determined path");
                }
                else
                {
                    textBox_BackupElectronic.Text = ((LangArEn == 0) ? "لقد تم تحديد مسار النسخ الالكتروني" : "It has been determined path");
                }
                txtEqarContractEndAlarm.Value = _SysSetting.EqarAlarmContractEnd.Value;
                txtEqarDayOfPayAlarm.Value = _SysSetting.EqarAlarmDayPay.Value;
                if (!string.IsNullOrEmpty(_SysSetting.EqarAcc))
                {
                    txtEqarsFatherAcc.Text = _SysSetting.EqarAcc.ToString();
                    txtEqarsFatherAccName.Text = ((LangArEn == 0) ? db.StockAccDefWithOutBalance(_SysSetting.EqarAcc.ToString()).Arb_Des : db.StockAccDefWithOutBalance(_SysSetting.EqarAcc.ToString()).Eng_Des);
                }
                if (!string.IsNullOrEmpty(_SysSetting.tenantAcc))
                {
                    txtTenantFatherAcc.Text = _SysSetting.tenantAcc.ToString();
                    txttenantFatherAccName.Text = ((LangArEn == 0) ? db.StockAccDefWithOutBalance(_SysSetting.tenantAcc.ToString()).Arb_Des : db.StockAccDefWithOutBalance(_SysSetting.tenantAcc.ToString()).Eng_Des);
                }
                List<T_Rom> _RoomSts = db.FillRoomWCondition();
                if (_RoomSts.Count > 0)
                {
                    txtFloors.IsInputReadOnly = true;
                }
                else
                {
                    List<T_Reserv> _ReservChk = db.ExecuteQuery<T_Reserv>("SELECT T_Reserv.ResrvNo, T_Reserv.Dat, T_Reserv.Rom, T_Reserv.Sts, T_Reserv.PerNm, T_Reserv.IdNo, T_Reserv.Nat , T_Reserv.Dat2 FROM T_Reserv where T_Reserv.sts=0 ", new object[0]).ToList();
                    if (_ReservChk.Count > 0)
                    {
                        txtFloors.IsInputReadOnly = true;
                    }
                }
                txtFloors.Value = _SysSetting.flore.Value;
                txtRoom.Value = _SysSetting.rom.Value;
                txtAllowPeriod.Text = _SysSetting.vStart;
                txtLeavePeriod.Text = _SysSetting.vEnd;
                txtDayofMonth.Value = _SysSetting.DayOfM.Value;
                txtLongitudinal.Value = _SysSetting.Fld_H.Value;
                txtWidthitudinal.Value = _SysSetting.Fld_w.Value;
                if (!string.IsNullOrEmpty(_SysSetting.GuestAcc))
                {
                    txtGuestsFatherAcc.Text = _SysSetting.GuestAcc.ToString();
                    txtGuestsFatherAccName.Text = ((LangArEn == 0) ? db.StockAccDefWithOutBalance(_SysSetting.GuestAcc.ToString()).Arb_Des : db.StockAccDefWithOutBalance(_SysSetting.GuestAcc.ToString()).Eng_Des);
                }
                if (!string.IsNullOrEmpty(_SysSetting.GuestBoxAcc))
                {
                    txtGuestBoxAcc.Text = _SysSetting.GuestBoxAcc.ToString();
                    txtGuestBoxAccName.Text = ((LangArEn == 0) ? db.StockAccDefWithOutBalance(_SysSetting.GuestBoxAcc.ToString()).Arb_Des : db.StockAccDefWithOutBalance(_SysSetting.GuestBoxAcc.ToString()).Eng_Des);
                }
                if (_SysSetting.vStartTyp.Trim() == "AM")
                {
                    RadioBox_AllowAM.Checked = true;
                }
                else
                {
                    RadioBox_AllowPM.Checked = true;
                }
                if (_SysSetting.vEndTyp.Trim() == "AM")
                {
                    RadioBox_LeaveAM.Checked = true;
                }
                else
                {
                    RadioBox_LeavePM.Checked = true;
                }
                try
                {
                    txtREmpty.BackColor = Color.FromArgb(int.Parse(_SysSetting.BColor0.Split(',').ToList()[0].Trim()), int.Parse(_SysSetting.BColor0.Split(',').ToList()[1].Trim()), int.Parse(_SysSetting.BColor0.Split(',').ToList()[2].Trim()));
                }
                catch
                {
                }
                try
                {
                    txtRAvailable.BackColor = Color.FromArgb(int.Parse(_SysSetting.BColor1.Split(',').ToList()[0].Trim()), int.Parse(_SysSetting.BColor1.Split(',').ToList()[1].Trim()), int.Parse(_SysSetting.BColor1.Split(',').ToList()[2].Trim()));
                }
                catch
                {
                }
                try
                {
                    txtRBussyDaily.BackColor = Color.FromArgb(int.Parse(_SysSetting.BColor2.Split(',').ToList()[0].Trim()), int.Parse(_SysSetting.BColor2.Split(',').ToList()[1].Trim()), int.Parse(_SysSetting.BColor2.Split(',').ToList()[2].Trim()));
                }
                catch
                {
                }
                try
                {
                    txtRBussyAppendix.BackColor = Color.FromArgb(int.Parse(_SysSetting.BColor3.Split(',').ToList()[0].Trim()), int.Parse(_SysSetting.BColor3.Split(',').ToList()[1].Trim()), int.Parse(_SysSetting.BColor3.Split(',').ToList()[2].Trim()));
                }
                catch
                {
                }
                try
                {
                    txtRClean.BackColor = Color.FromArgb(int.Parse(_SysSetting.BColor4.Split(',').ToList()[0].Trim()), int.Parse(_SysSetting.BColor4.Split(',').ToList()[1].Trim()), int.Parse(_SysSetting.BColor4.Split(',').ToList()[2].Trim()));
                }
                catch
                {
                }
                try
                {
                    txtRRepair.BackColor = Color.FromArgb(int.Parse(_SysSetting.BColor5.Split(',').ToList()[0].Trim()), int.Parse(_SysSetting.BColor5.Split(',').ToList()[1].Trim()), int.Parse(_SysSetting.BColor5.Split(',').ToList()[2].Trim()));
                }
                catch
                {
                }
                try
                {
                    txtRBussyMonthly.BackColor = Color.FromArgb(int.Parse(_SysSetting.BColor6.Split(',').ToList()[0].Trim()), int.Parse(_SysSetting.BColor6.Split(',').ToList()[1].Trim()), int.Parse(_SysSetting.BColor6.Split(',').ToList()[2].Trim()));
                }
                catch
                {
                }
                try
                {
                    txtRLeave.BackColor = Color.FromArgb(int.Parse(_SysSetting.BColor7.Split(',').ToList()[0].Trim()), int.Parse(_SysSetting.BColor7.Split(',').ToList()[1].Trim()), int.Parse(_SysSetting.BColor7.Split(',').ToList()[2].Trim()));
                }
                catch
                {
                }
                try
                {
                    txtREmpty.ForeColor = Color.FromArgb(int.Parse(_SysSetting.FColor0.Split(',').ToList()[0].Trim()), int.Parse(_SysSetting.FColor0.Split(',').ToList()[1].Trim()), int.Parse(_SysSetting.FColor0.Split(',').ToList()[2].Trim()));
                }
                catch
                {
                }
                try
                {
                    txtRAvailable.ForeColor = Color.FromArgb(int.Parse(_SysSetting.FColor1.Split(',').ToList()[0].Trim()), int.Parse(_SysSetting.FColor1.Split(',').ToList()[1].Trim()), int.Parse(_SysSetting.FColor1.Split(',').ToList()[2].Trim()));
                }
                catch
                {
                }
                try
                {
                    txtRBussyDaily.ForeColor = Color.FromArgb(int.Parse(_SysSetting.FColor2.Split(',').ToList()[0].Trim()), int.Parse(_SysSetting.FColor2.Split(',').ToList()[1].Trim()), int.Parse(_SysSetting.FColor2.Split(',').ToList()[2].Trim()));
                }
                catch
                {
                }
                try
                {
                    txtRBussyAppendix.ForeColor = Color.FromArgb(int.Parse(_SysSetting.FColor3.Split(',').ToList()[0].Trim()), int.Parse(_SysSetting.FColor3.Split(',').ToList()[1].Trim()), int.Parse(_SysSetting.FColor3.Split(',').ToList()[2].Trim()));
                }
                catch
                {
                }
                try
                {
                    txtRClean.ForeColor = Color.FromArgb(int.Parse(_SysSetting.FColor4.Split(',').ToList()[0].Trim()), int.Parse(_SysSetting.FColor4.Split(',').ToList()[1].Trim()), int.Parse(_SysSetting.FColor4.Split(',').ToList()[2].Trim()));
                }
                catch
                {
                }
                try
                {
                    txtRRepair.ForeColor = Color.FromArgb(int.Parse(_SysSetting.FColor5.Split(',').ToList()[0].Trim()), int.Parse(_SysSetting.FColor5.Split(',').ToList()[1].Trim()), int.Parse(_SysSetting.FColor5.Split(',').ToList()[2].Trim()));
                }
                catch
                {
                }
                try
                {
                    txtRBussyMonthly.ForeColor = Color.FromArgb(int.Parse(_SysSetting.FColor6.Split(',').ToList()[0].Trim()), int.Parse(_SysSetting.FColor6.Split(',').ToList()[1].Trim()), int.Parse(_SysSetting.FColor6.Split(',').ToList()[2].Trim()));
                }
                catch
                {
                }
                try
                {
                    txtRLeave.ForeColor = Color.FromArgb(int.Parse(_SysSetting.FColor7.Split(',').ToList()[0].Trim()), int.Parse(_SysSetting.FColor7.Split(',').ToList()[1].Trim()), int.Parse(_SysSetting.FColor7.Split(',').ToList()[2].Trim()));
                }
                catch
                {
                }
                txtAct.Text = _Company.Active;
                txtAddr.Text = _Company.Adder;
                txtCompany.Text = _Company.CopNam;
                txtFax.Text = _Company.Fax;
                txtMailCode.Text = _Company.Symbl;
                txtMobile.Text = _Company.Mobl;
                txtPOBox.Text = _Company.Pox;
                txtRemark.Text = _Company.Eamil;
                txtTel1.Text = _Company.Tel1;
                txtTel2.Text = _Company.Tel2;
                txtBoxAccount.Text = _GdAuto.Acc0.ToString();
                txtFirstInventory.Text = _GdAuto.Acc2.ToString();
                txtLastInventory.Text = _GdAuto.Acc3.ToString();
                txtProfits.Text = _GdAuto.Acc1.ToString();
                for (int iiCnt = 1; iiCnt < c1FlexGrid1.Rows.Count; iiCnt++)
                {
                    for (int i = 0; i < listInvSetting.Count; i++)
                    {
                        _InvSetting = listInvSetting[i];
                        if (_InvSetting.InvID == int.Parse(c1FlexGrid1.GetData(iiCnt, 6).ToString()))
                        {
                            if (c1FlexGrid1.GetData(iiCnt, 7).ToString() == "0")
                            {
                                c1FlexGrid1.SetData(iiCnt, 4, (VarGeneral.TString.TEmpty(_InvSetting.AccDebit0) != "0") ? VarGeneral.TString.TEmpty(_InvSetting.AccDebit0) : string.Empty);
                                c1FlexGrid1.SetData(iiCnt, 5, (VarGeneral.TString.TEmpty(_InvSetting.AccCredit0) != "0") ? VarGeneral.TString.TEmpty(_InvSetting.AccCredit0) : string.Empty);
                                c1FlexGrid1.SetData(iiCnt, 3, VarGeneral.TString.ChkStatShow(_InvSetting.InvSetting, 1));
                            }
                            else if (c1FlexGrid1.GetData(iiCnt, 7).ToString() == "1")
                            {
                                c1FlexGrid1.SetData(iiCnt, 4, (VarGeneral.TString.TEmpty(_InvSetting.AccDebit1) != "0") ? VarGeneral.TString.TEmpty(_InvSetting.AccDebit1) : string.Empty);
                                c1FlexGrid1.SetData(iiCnt, 5, (VarGeneral.TString.TEmpty(_InvSetting.AccCredit1) != "0") ? VarGeneral.TString.TEmpty(_InvSetting.AccCredit1) : string.Empty);
                                c1FlexGrid1.SetData(iiCnt, 3, VarGeneral.TString.ChkStatShow(_InvSetting.InvSetting, 1));
                            }
                            else if (c1FlexGrid1.GetData(iiCnt, 7).ToString() == "2")
                            {
                                c1FlexGrid1.SetData(iiCnt, 4, (VarGeneral.TString.TEmpty(_InvSetting.AccDebit2) != "0") ? VarGeneral.TString.TEmpty(_InvSetting.AccDebit2) : string.Empty);
                                c1FlexGrid1.SetData(iiCnt, 5, (VarGeneral.TString.TEmpty(_InvSetting.AccCredit2) != "0") ? VarGeneral.TString.TEmpty(_InvSetting.AccCredit2) : string.Empty);
                                c1FlexGrid1.SetData(iiCnt, 3, VarGeneral.TString.ChkStatShow(_InvSetting.InvSetting, 1));
                            }
                            else if (c1FlexGrid1.GetData(iiCnt, 7).ToString() == "3")
                            {
                                c1FlexGrid1.SetData(iiCnt, 4, VarGeneral.TString.TEmpty(_InvSetting.DisDebit));
                                c1FlexGrid1.SetData(iiCnt, 5, VarGeneral.TString.TEmpty(_InvSetting.DisCredit));
                                c1FlexGrid1.SetData(iiCnt, 3, _InvSetting.autoDisGaid.Value);
                            }
                            break;
                        }
                    }
                }
                for (int iiCnt = 0; iiCnt < listInfotb.Count; iiCnt++)
                {
                    _Infotb = listInfotb[iiCnt];
                    if (txtHeadingL1.Tag.ToString() == _Infotb.fldFlag.ToString())
                    {
                        txtHeadingL1.Text = _Infotb.fldValue;
                    }
                    else if (txtHeadingL2.Tag.ToString() == _Infotb.fldFlag.ToString())
                    {
                        txtHeadingL2.Text = _Infotb.fldValue;
                    }
                    else if (txtHeadingL3.Tag.ToString() == _Infotb.fldFlag.ToString())
                    {
                        txtHeadingL3.Text = _Infotb.fldValue;
                    }
                    else if (txtHeadingL4.Tag.ToString() == _Infotb.fldFlag.ToString())
                    {
                        txtHeadingL4.Text = _Infotb.fldValue;
                    }
                    else if (txtHeadingR1.Tag.ToString() == _Infotb.fldFlag.ToString())
                    {
                        txtHeadingR1.Text = _Infotb.fldValue;
                    }
                    else if (txtHeadingR2.Tag.ToString() == _Infotb.fldFlag.ToString())
                    {
                        txtHeadingR2.Text = _Infotb.fldValue;
                    }
                    else if (txtHeadingR3.Tag.ToString() == _Infotb.fldFlag.ToString())
                    {
                        txtHeadingR3.Text = _Infotb.fldValue;
                    }
                    else if (txtHeadingR4.Tag.ToString() == _Infotb.fldFlag.ToString())
                    {
                        txtHeadingR4.Text = _Infotb.fldValue;
                    }
                }
                checkBox_AutoBackup_CheckedChanged(null, null);
                chk1_CheckedChanged(null, null);
                chk3_CheckedChanged(null, null);
                chk58_CheckedChanged(null, null);
                chk19_CheckedChanged(null, null);
                chk69_CheckedChanged(null, null);
                try
                {
                    if (_SysSetting.BackgroundPic != null)
                    {
                        byte[] arr = _SysSetting.BackgroundPic.ToArray();
                        MemoryStream stream = new MemoryStream(arr);
                        pictureBox_EnterPic.Image = Image.FromStream(stream);
                    }
                    else
                    {
                        pictureBox_EnterPic.Image = Resources.sssBackground;
                    }
                }
                catch
                {
                    pictureBox_EnterPic.Image = Resources.sssBackground;
                }
                if (superTabItem_Employee.Visible)
                {
                    ChkEmp1.Checked = VarGeneral.TString.ChkStatShow(_SysSetting.EmpSeting, 0);
                    textBox_AutoEmpLeaveAfter.Value = _SysSetting.EmpLeaveAfter.Value;
                    radioButton_IsNotBackground.Checked = _SysSetting.IsNotBackground.Value;
                    checkBox_AttendanceManually.Checked = _SysSetting.AttendanceManually.Value;
                    checkBox_AutoLeave.Checked = _SysSetting.AutoLeave.Value;
                    checkBox_IsAlarmEmpContract.Checked = _SysSetting.IsAlarmEmpContract.Value;
                    checkBox_IsAlarmEmpDoc.Checked = _SysSetting.IsAlarmEmpDoc.Value;
                    checkBox_IsAlarmSecretariatsDoc.Checked = _SysSetting.IsAlarmSecretariatsDoc.Value;
                    checkBox_IsAlarmVisaGoBack.Checked = _SysSetting.IsAlarmVisaGoBack.Value;
                    checkBox_IsAlarmDepts.Checked = _SysSetting.IsAlarmDepts.Value;
                    checkBox_IsAlarmEndVaction.Checked = _SysSetting.IsAlarmEndVaction.Value;
                    checkBox_IsAlarmFamilyPassport.Checked = _SysSetting.IsAlarmFamilyPassport.Value;
                    checkBox_IsAlarmGuarantorDoc.Checked = _SysSetting.IsAlarmGuarantorDoc.Value;
                    checkBox_IsAlarmCarDoc.Checked = _SysSetting.IsAlarmCarDoc.Value;
                    integerInput_AlarmEmpContractBefore.Value = _SysSetting.AlarmEmpContractBefore.Value;
                    integerInput_AlarmEmpDocBefore.Value = _SysSetting.AlarmEmpDocBefore.Value;
                    integerInput_AlarmEndVactionBefore.Value = _SysSetting.AlarmEndVactionBefore.Value;
                    integerInput_AlarmFamilyPassportBefore.Value = _SysSetting.AlarmFamilyPassportBefore.Value;
                    integerInput_AlarmGuarantorDocBefore.Value = _SysSetting.AlarmGuarantorDocBefore.Value;
                    integerInput_AlarmCarDocBefore.Value = _SysSetting.AlarmCarDocBefore.Value;
                    integerInput_AlarmSecretariatsBefore.Value = _SysSetting.AlarmSecretariatsBefore.Value;
                    integerInput_AlarmVisaGoBack.Value = _SysSetting.AlarmVisaGoBack.Value;
                    integerInput_AlarmDeptsBefore.Value = _SysSetting.AlarmDeptsBefore.Value;
                    checkBox_VacationManually.Checked = _SysSetting.VacationManually.Value;
                    checkBox_Sponer.Checked = _SysSetting.Sponer.Value;
                    checkBox_AutoBackup.Checked = _SysSetting.IsAutoBackup.Value;
                    comboBox_AutoBackup.SelectedIndex = _SysSetting.AutoBackup.Value;
                    textBox_BackupPath.Text = _SysSetting.BackPath;
                    textBox_DocPath.Text = _SysSetting.DocumentPath;
                    if (_SysSetting.CalculateNo.HasValue)
                    {
                        comboBox_CalculateNo.SelectedValue = _SysSetting.CalculateNo.Value;
                    }
                    if (_SysSetting.CalculatliquidNo.HasValue)
                    {
                        comboBox_CalculatliquidNo.SelectedValue = _SysSetting.CalculatliquidNo.Value;
                    }
                    if (_SysSetting.DisVacationType.HasValue)
                    {
                        comboBox_DisVacationType.SelectedIndex = _SysSetting.DisVacationType.Value;
                    }
                    checkBox_AutoLeave_CheckedChanged(null, null);
                    checkBox_IsAlarmEmpContract_CheckedChanged(null, null);
                    checkBox_IsAlarmEmpDoc_CheckedChanged(null, null);
                    checkBox_IsAlarmEndVaction_CheckedChanged(null, null);
                    checkBox_IsAlarmFamilyPassport_CheckedChanged(null, null);
                    checkBox_IsAlarmGuarantorDoc_CheckedChanged(null, null);
                    checkBox_IsAlarmCarDoc_CheckedChanged(null, null);
                    checkBox_IsAlarmSecretariatsDoc_CheckedChanged(null, null);
                    checkBox_IsAlarmVisaGoBack_CheckedChanged(null, null);
                    checkBox_IsAlarmDepts_CheckedChanged(null, null);
                }
                FlxInv.Rows.Count = listAccDef.Count + 2;
                for (int iiCnt = 2; iiCnt <= listAccDef.Count + 1; iiCnt++)
                {
                    _AccDef = listAccDef[iiCnt - 2];
                    FlxInv.SetData(iiCnt, 0, iiCnt - 1);
                    FlxInv.SetData(iiCnt, 1, (LangArEn == 0) ? _AccDef.Arb_Des.Trim() : _AccDef.Eng_Des.Trim());
                    FlxInv.SetData(iiCnt, 2, VarGeneral.TString.TEmpty(_AccDef.DepreciationPercent.ToString()));
                    try
                    {
                        FlxInv.SetData(iiCnt, 3, _AccDef.ProofAcc);
                    }
                    catch
                    {
                        FlxInv.SetData(iiCnt, 3, " ");
                    }
                    try
                    {
                        FlxInv.SetData(iiCnt, 4, _AccDef.RelayAcc);
                    }
                    catch
                    {
                        FlxInv.SetData(iiCnt, 4, " ");
                    }
                    FlxInv.SetData(iiCnt, 5, _AccDef.AccDef_No);
                }
                FlxInv.SetData(1, 3, (LangArEn == 0) ? "حسـاب المصــروف - المدين" : "Expense Acc - debtor");
                FlxInv.SetData(1, 4, (LangArEn == 0) ? "الصندوق / البنك - الدائن" : "Box / Bank - creditor");
                FlxInv.SetCellStyle(1, 3, "SubTotal0");
                FlxInv.SetCellStyle(1, 4, "SubTotal0");
                FlxInv.SetCellStyle(1, 2, "SubTotal0");
                FlxInv.SetCellStyle(1, 1, "SubTotal0");
                CmbPrintTyp_SelectedIndexChanged(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void checkBox_IsAlarmVisaGoBack_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_IsAlarmVisaGoBack.Checked)
            {
                integerInput_AlarmVisaGoBack.Enabled = true;
                return;
            }
            integerInput_AlarmVisaGoBack.Enabled = false;
            integerInput_AlarmVisaGoBack.Value = 0;
        }
        private void checkBox_IsAlarmDepts_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_IsAlarmDepts.Checked)
            {
                integerInput_AlarmDeptsBefore.Enabled = true;
                return;
            }
            integerInput_AlarmDeptsBefore.Enabled = false;
            integerInput_AlarmDeptsBefore.Value = 0;
        }
        private void checkBox_IsAlarmEmpDoc_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_IsAlarmEmpDoc.Checked)
            {
                integerInput_AlarmEmpDocBefore.Enabled = true;
                return;
            }
            integerInput_AlarmEmpDocBefore.Enabled = false;
            integerInput_AlarmEmpDocBefore.Value = 0;
        }
        private void checkBox_IsAlarmEmpContract_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_IsAlarmEmpContract.Checked)
            {
                integerInput_AlarmEmpContractBefore.Enabled = true;
                return;
            }
            integerInput_AlarmEmpContractBefore.Enabled = false;
            integerInput_AlarmEmpContractBefore.Value = 0;
        }
        private void checkBox_IsAlarmFamilyPassport_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_IsAlarmFamilyPassport.Checked)
            {
                integerInput_AlarmFamilyPassportBefore.Enabled = true;
                return;
            }
            integerInput_AlarmFamilyPassportBefore.Enabled = false;
            integerInput_AlarmFamilyPassportBefore.Value = 0;
        }
        private void checkBox_IsAlarmGuarantorDoc_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_IsAlarmGuarantorDoc.Checked)
            {
                integerInput_AlarmGuarantorDocBefore.Enabled = true;
                return;
            }
            integerInput_AlarmGuarantorDocBefore.Enabled = false;
            integerInput_AlarmGuarantorDocBefore.Value = 0;
        }
        private void checkBox_IsAlarmEndVaction_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_IsAlarmEndVaction.Checked)
            {
                integerInput_AlarmEndVactionBefore.Enabled = true;
                return;
            }
            integerInput_AlarmEndVactionBefore.Enabled = false;
            integerInput_AlarmEndVactionBefore.Value = 0;
        }
        private void checkBox_IsAlarmCarDoc_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_IsAlarmCarDoc.Checked)
            {
                integerInput_AlarmCarDocBefore.Enabled = true;
                return;
            }
            integerInput_AlarmCarDocBefore.Enabled = false;
            integerInput_AlarmCarDocBefore.Value = 0;
        }
        private void checkBox_IsAlarmSecretariatsDoc_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_IsAlarmSecretariatsDoc.Checked)
            {
                integerInput_AlarmSecretariatsBefore.Enabled = true;
                return;
            }
            integerInput_AlarmSecretariatsBefore.Enabled = false;
            integerInput_AlarmSecretariatsBefore.Value = 0;
        }
        private void checkBox_AutoLeave_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_AutoLeave.Checked)
            {
                textBox_AutoEmpLeaveAfter.Enabled = true;
                return;
            }
            textBox_AutoEmpLeaveAfter.Enabled = false;
            textBox_AutoEmpLeaveAfter.Value = 0;
        }
        public static Image resizeImage(Image imgToResize, Size size)
        {
            return new Bitmap(imgToResize, size);
        }
        private void SaveData()
        {

            string setting = string.Empty;
            string Empsetting = string.Empty;
            string settingNewLine = string.Empty;
            try
            {
                _SysSetting.IsBackground = true;
                _SysSetting.IsNotBackground = false;
                if (pictureBox_EnterPic.Image != null)
                {
                    MemoryStream stream = new MemoryStream();
                    pictureBox_EnterPic.Image.Save(stream, ImageFormat.Jpeg);
                    byte[] arr = stream.GetBuffer();
                    _SysSetting.BackgroundPic = arr;
                }
                else
                {
                    _SysSetting.BackgroundPic = null;
                }
                try
                {
                    _SysSetting.IsNotBackground = radioButton_IsNotBackground.Checked;
                    if (radioButton_IsNotBackground.Checked)
                    {
                        _SysSetting.IsBackground = false;
                    }
                    else
                    {
                        _SysSetting.IsBackground = true;
                    }
                }
                catch
                {
                    _SysSetting.IsNotBackground = false;
                    _SysSetting.IsBackground = true;
                }
                _SysSetting.HDat = int.Parse(txtHijriDate.Tag.ToString());
                _SysSetting.Calendr = CmbCalendar.SelectedIndex;
                _SysSetting.AutoItm = txtAutoNumber.Value;
                _SysSetting.DMY = CmbDateTyp.SelectedIndex;
                _SysSetting.ImportIp = int.Parse(CmbCurr.SelectedValue.ToString()).ToString();
                _SysSetting.DataBaseNm = CmbMail.SelectedIndex.ToString();
                _SysSetting.InvMod = CmbInvMode.SelectedIndex;
                _SysSetting.LrnExp = int.Parse(txtDateAlarm.Text);
                _SysSetting.AccCus = txtDateofInv.Value.ToString();
                _SysSetting.AlarmDueoBefore = txtAlarmDeuDateBefor.Value;
                try
                {
                    if (int.TryParse(txtKeyNational.Text, out var _) && !string.IsNullOrEmpty(txtKeyNational.Text.Trim()) && txtKeyNational.Text != "966")
                    {
                        _SysSetting.AccSup = txtKeyNational.Text.Trim();
                    }
                    else
                    {
                        _SysSetting.AccSup = string.Empty;
                    }
                }
                catch
                {
                    _SysSetting.AccSup = string.Empty;
                }
                setting = VarGeneral.TString.ChkStatSave(chk1.Checked);
                setting += VarGeneral.TString.ChkStatSave(chk2.Checked);
                setting += VarGeneral.TString.ChkStatSave(chk3.Checked);
                setting += VarGeneral.TString.ChkStatSave((bool)c1FlexGrid2.GetData(18, 2));
                setting += VarGeneral.TString.ChkStatSave((bool)c1FlexGrid2.GetData(17, 2));
                setting += VarGeneral.TString.ChkStatSave((bool)c1FlexGrid2.GetData(16, 2));
                setting += VarGeneral.TString.ChkStatSave((bool)c1FlexGrid2.GetData(15, 2));
                setting += VarGeneral.TString.ChkStatSave((bool)c1FlexGrid2.GetData(2, 2));
                setting += VarGeneral.TString.ChkStatSave((bool)c1FlexGrid2.GetData(1, 2));
                setting += VarGeneral.TString.ChkStatSave(ChkHead.Checked);
                setting += VarGeneral.TString.ChkStatSave(ChkGreg.Checked);
                setting += VarGeneral.TString.ChkStatSave(ChkHijri.Checked);
                setting += VarGeneral.TString.ChkStatSave(ChkPageNumber.Checked);
                setting += CmbCost.SelectedIndex;
                setting += VarGeneral.TString.ChkStatSave((bool)c1FlexGrid2.GetData(31, 2));
                setting += VarGeneral.TString.ChkStatSave((bool)c1FlexGrid2.GetData(20, 2));
                setting += VarGeneral.TString.ChkStatSave((bool)c1FlexGrid2.GetData(21, 2));
                setting += VarGeneral.TString.ChkStatSave((bool)c1FlexGrid2.GetData(7, 2));
                setting += VarGeneral.TString.ChkStatSave((bool)c1FlexGrid2.GetData(32, 2));
                setting += VarGeneral.TString.ChkStatSave((bool)c1FlexGrid2.GetData(3, 2));
                setting += VarGeneral.TString.ChkStatSave((bool)c1FlexGrid2.GetData(19, 2));
                setting += VarGeneral.TString.ChkStatSave((bool)c1FlexGrid2.GetData(4, 2));
                setting += VarGeneral.TString.ChkStatSave((bool)c1FlexGrid2.GetData(51, 2));
                setting += VarGeneral.TString.ChkStatSave(chk19.Checked);
                setting += VarGeneral.TString.ChkStatSave((bool)c1FlexGrid2.GetData(23, 2));
                setting += VarGeneral.TString.ChkStatSave((bool)c1FlexGrid2.GetData(12, 2));
                setting += VarGeneral.TString.ChkStatSave((bool)c1FlexGrid2.GetData(33, 2));
                setting += VarGeneral.TString.ChkStatSave((bool)c1FlexGrid2.GetData(30, 2)); ;
                setting += VarGeneral.TString.ChkStatSave(chk24.Checked);
                setting += VarGeneral.TString.ChkStatSave((bool)c1FlexGrid2.GetData(6, 2));
                setting += VarGeneral.TString.ChkStatSave((bool)c1FlexGrid2.GetData(22, 2));
                setting += VarGeneral.TString.ChkStatSave(chk27.Checked);
                setting += VarGeneral.TString.ChkStatSave((bool)c1FlexGrid2.GetData(10, 2));
                setting += VarGeneral.TString.ChkStatSave((bool)c1FlexGrid2.GetData(34, 2));
                if (chk39.SelectedIndex == 0 || chk39.SelectedIndex == 2)
                {
                    setting += "1";
                }
                else if ((chk39.SelectedIndex == 1) | (chk39.SelectedIndex == 3))
                {
                    setting += "0";
                }
                setting += VarGeneral.TString.ChkStatSave((bool)c1FlexGrid2.GetData(13, 2));
                setting += VarGeneral.TString.ChkStatSave((bool)c1FlexGrid2.GetData(35, 2));
                setting += VarGeneral.TString.ChkStatSave((bool)c1FlexGrid2.GetData(14, 2));
                setting += VarGeneral.TString.ChkStatSave((bool)c1FlexGrid2.GetData(11, 2));
                setting += VarGeneral.TString.ChkStatSave((bool)c1FlexGrid2.GetData(25, 2));
                setting += chk36.SelectedIndex;
                setting += VarGeneral.TString.ChkStatSave(chk37.Value);
                setting += VarGeneral.TString.ChkStatSave((bool)c1FlexGrid2.GetData(24, 2));
                if (chk39.SelectedIndex == 0 || chk39.SelectedIndex == 1)
                {
                    setting += "1";
                }
                else if ((chk39.SelectedIndex == 2) | (chk39.SelectedIndex == 3))
                {
                    setting += "0";
                }
                setting += VarGeneral.TString.ChkStatSave((bool)c1FlexGrid2.GetData(36, 2));
                setting += VarGeneral.TString.ChkStatSave((bool)c1FlexGrid2.GetData(5, 2));
                setting += VarGeneral.TString.ChkStatSave(chk42.Checked);
                setting += VarGeneral.TString.ChkStatSave(chk43.Checked);
                setting += VarGeneral.TString.ChkStatSave(chk44.Checked);
                setting += VarGeneral.TString.ChkStatSave(chk45.Checked);
                _SysSetting.AfterDotNum = numbersafterdecimal.Value;
                VarGeneral.setDecimalPointSettings((int)_SysSetting.AfterDotNum);
                chk45_CheckedChanged(null, null);
                setting += chk46.SelectedIndex;
                setting += VarGeneral.TString.ChkStatSave((bool)c1FlexGrid2.GetData(27, 2));
                setting += VarGeneral.TString.ChkStatSave((bool)c1FlexGrid2.GetData(26, 2));
                setting += VarGeneral.TString.ChkStatSave((bool)c1FlexGrid2.GetData(9, 2));
                setting += VarGeneral.TString.ChkStatSave((bool)c1FlexGrid2.GetData(55, 2));
                setting += VarGeneral.TString.ChkStatSave((bool)c1FlexGrid2.GetData(8, 2));
                setting += VarGeneral.TString.ChkStatSave((bool)c1FlexGrid2.GetData(37, 2));
                setting += VarGeneral.TString.ChkStatSave((bool)c1FlexGrid2.GetData(38, 2));
                try
                {
                    setting += VarGeneral.TString.ChkStatSave((bool)c1FlexGrid2.GetData(39, 2));
                }
                catch
                { setting += "0"; }
                setting += CmbOrderTyp.SelectedIndex;
                setting += VarGeneral.TString.ChkStatSave((bool)c1FlexGrid2.GetData(40, 2));
                setting += VarGeneral.TString.ChkStatSave((bool)c1FlexGrid2.GetData(28, 2));
                setting += VarGeneral.TString.ChkStatSave((bool)c1FlexGrid2.GetData(42, 2));
                setting += VarGeneral.TString.ChkStatSave(chk58.Checked);
                setting += VarGeneral.TString.ChkStatSave((bool)c1FlexGrid2.GetData(43, 2));
                setting += VarGeneral.TString.ChkStatSave((bool)c1FlexGrid2.GetData(44, 2));
                setting += VarGeneral.TString.ChkStatSave((bool)c1FlexGrid2.GetData(45, 2));
                setting += VarGeneral.TString.ChkStatSave((bool)c1FlexGrid2.GetData(46, 2));
                setting += VarGeneral.TString.ChkStatSave((bool)c1FlexGrid2.GetData(47, 2));
                setting += VarGeneral.TString.ChkStatSave((bool)c1FlexGrid2.GetData(52, 2));
                setting += VarGeneral.TString.ChkStatSave(chk65.Checked);
                setting += VarGeneral.TString.ChkStatSave((bool)c1FlexGrid2.GetData(48, 2));
                setting += VarGeneral.TString.ChkStatSave((bool)c1FlexGrid2.GetData(49, 2));
                setting += VarGeneral.TString.ChkStatSave((bool)c1FlexGrid2.GetData(50, 2));
                setting += VarGeneral.TString.ChkStatSave(chk69.Checked);
                setting += VarGeneral.TString.ChkStatSave((bool)c1FlexGrid2.GetData(29, 2));
                setting += VarGeneral.TString.ChkStatSave(chk71.Checked);
                setting += VarGeneral.TString.ChkStatSave((bool)c1FlexGrid2.GetData(53, 2));
                setting += VarGeneral.TString.ChkStatSave((bool)c1FlexGrid2.GetData(41, 2));
                setting += VarGeneral.TString.ChkStatSave((bool)c1FlexGrid2.GetData(56, 2));
                setting += VarGeneral.TString.ChkStatSave((bool)c1FlexGrid2.GetData(54, 2));
                setting += VarGeneral.TString.ChkStatSave(chk76.Checked);
                setting += VarGeneral.TString.ChkStatSave(chk77.Checked);
                setting += VarGeneral.TString.ChkStatSave((bool)c1FlexGrid2.GetData(57, 2));
                setting += VarGeneral.TString.ChkStatSave((bool)c1FlexGrid2.GetData(58, 2));
                setting += VarGeneral.TString.ChkStatSave((bool)c1FlexGrid2.GetData(59, 2));
                _SysSetting.Seting = setting;
                _SysSetting.LineOfInvoices = txtLinesInv.Value;

                VarGeneral.Settings_Sys.LineOfInvoices = txtLinesInv.Value;
                VarGeneral.Settings_Sys.Seting = setting;

                if (PicItemImg.Image != null)
                {
                    MemoryStream stream = new MemoryStream();
                    PicItemImg.Image = resizeImage(PicItemImg.Image, new Size(140, 140));
                    PicItemImg.Image.Save(stream, ImageFormat.Jpeg);
                    byte[] arr = stream.GetBuffer();
                    _SysSetting.LogImg = arr;
                }
                else
                {
                    _SysSetting.LogImg = null;
                }
                try
                {
                    _SysSetting.SyncPath = textBox_SyncPath.Text;
                }
                catch
                {
                    _SysSetting.SyncPath = string.Empty;
                }
                try
                {
                    _SysSetting.BackPath = textBox_BackupPath.Text;
                }
                catch
                {
                    _SysSetting.BackPath = string.Empty;
                }
                try
                {
                    _SysSetting.SysDir = textBox_BackupElectronic.Tag.ToString();
                }
                catch
                {
                    _SysSetting.SysDir = string.Empty;
                }
                try
                {
                    _SysSetting.IsAutoBackup = checkBox_AutoBackup.Checked;
                }
                catch
                {
                    _SysSetting.IsAutoBackup = false;
                }
                try
                {
                    _SysSetting.AutoBackup = comboBox_AutoBackup.SelectedIndex;
                }
                catch
                {
                    _SysSetting.AutoBackup = 0;
                }

                if (switchButton_NewColumnName.Value)
                {
                    _SysSetting.LineDetailNameA = textBox_LineDetailNameA.Text;
                    _SysSetting.LineDetailNameE = textBox_LineDetailNameE.Text;
                }
                else
                {
                    _SysSetting.LineGiftlNameA = textBox_LineDetailNameA.Text;
                    _SysSetting.LineGiftlNameE = textBox_LineDetailNameE.Text;
                }
                _SysSetting.AutoEmp = CmbPrintTyp.SelectedIndex;
                _SysSetting.Path_Kind = CmbPointImages.SelectedIndex;
                _SysSetting.ServerNm = txtEmailBoss.Text.Trim();
                _SysSetting.Sa_Pass = txtEmailPass.Text;
                _SysSetting.EqarAlarmDayPay = txtEqarDayOfPayAlarm.Value;
                _SysSetting.EqarAlarmContractEnd = txtEqarContractEndAlarm.Value;
                _SysSetting.EqarAcc = txtEqarsFatherAcc.Text;
                _SysSetting.tenantAcc = txtTenantFatherAcc.Text;
                if (_SysSetting.rom.Value != txtRoom.Value || _SysSetting.flore.Value != txtFloors.Value)
                {
                    db.ExecuteCommand("DELETE FROM [T_RomChart]");
                    db.ExecuteCommand("DELETE FROM [T_Rom]");
                    string _format = "1";
                    int _ID = 1;
                    int iicnt;
                    for (iicnt = 1; iicnt <= txtFloors.Value; iicnt++)
                    {
                        _format = iicnt + "0";
                        for (int i = 1; i <= txtRoom.Value; i++)
                        {
                            db.ExecuteCommand("SET ANSI_PADDING OFF\r\n                                                INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID],[Furnished],[AreaDetail],[RoomCount],[loungesCount],[kitchensCount]) VALUES (" + _format + i.ToString() + ", " + iicnt + ", 0, 1, 1, 1, 0, 0, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1,0,'',1,0,0)");
                            List<T_RomChart> q = db.T_RomCharts.Where((T_RomChart t) => t.FName == "الطابق " + iicnt).ToList();
                            if (q.Count <= 0)
                            {
                                db.ExecuteCommand("SET ANSI_PADDING OFF\r\n                                                    SET IDENTITY_INSERT [dbo].[T_RomChart] ON\r\n                                                    INSERT [dbo].[T_RomChart] ([ID], [FName], [FNameE],[col1], [col2], [col3], [col4], [col5], [col6], [col7], [col8], [col9], [col10], [col11], [col12], [col13], [col14], [col15], [col16], [col17], [col18], [col19], [col20], [col21], [col22], [col23], [col24], [col25], [col26], [col27], [col28], [col29], [col30], [col31], [col32], [col33], [col34], [col35], [col36], [col37], [col38], [col39], [col40], [col41], [col42], [col43], [col44], [col45], [col46], [col47], [col48], [col49], [col50], [col51], [col52], [col53], [col54], [col55], [col56], [col57], [col58], [col59], [col60], [col61], [col62], [col63], [col64], [col65], [col66], [col67], [col68], [col69], [col70], [col71], [col72], [col73], [col74], [col75], [col76], [col77], [col78], [col79], [col80], [col81], [col82], [col83], [col84], [col85], [col86], [col87], [col88], [col89], [col90], [col91], [col92], [col93], [col94], [col95], [col96], [col97], [col98], [col99], [col100]) VALUES (" + _ID + ", N'الطابق " + iicnt + "', N'floor " + iicnt + "', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)\r\n                                                    SET IDENTITY_INSERT [dbo].[T_RomChart] OFF");
                                db.ExecuteCommand("UPDATE [T_RomChart] SET col" + i + " = " + _format + i.ToString() + " where FName = 'الطابق " + iicnt + "'");
                                _ID++;
                            }
                            else
                            {
                                db.ExecuteCommand("UPDATE [T_RomChart] SET col" + i + " = " + _format + i.ToString() + " where FName = 'الطابق " + iicnt + "'");
                            }
                        }
                    }
                }
                _SysSetting.flore = txtFloors.Value;
                _SysSetting.rom = txtRoom.Value;
                _SysSetting.vStart = txtAllowPeriod.Text;
                _SysSetting.vEnd = txtLeavePeriod.Text;
                _SysSetting.DayOfM = txtDayofMonth.Value;
                _SysSetting.Fld_H = txtLongitudinal.Value;
                _SysSetting.Fld_w = txtWidthitudinal.Value;
                if (RadioBox_AllowAM.Checked)
                {
                    _SysSetting.vStartTyp = "AM";
                }
                else
                {
                    _SysSetting.vStartTyp = "PM";
                }
                if (RadioBox_LeaveAM.Checked)
                {
                    _SysSetting.vEndTyp = "AM";
                }
                else
                {
                    _SysSetting.vEndTyp = "PM";
                }
                _SysSetting.BColor0 = txtREmpty.BackColor.R + "," + txtREmpty.BackColor.G + "," + txtREmpty.BackColor.B;
                _SysSetting.BColor1 = txtRAvailable.BackColor.R + "," + txtRAvailable.BackColor.G + "," + txtRAvailable.BackColor.B;
                _SysSetting.BColor2 = txtRBussyDaily.BackColor.R + "," + txtRBussyDaily.BackColor.G + "," + txtRBussyDaily.BackColor.B;
                _SysSetting.BColor3 = txtRBussyAppendix.BackColor.R + "," + txtRBussyAppendix.BackColor.G + "," + txtRBussyAppendix.BackColor.B;
                _SysSetting.BColor4 = txtRClean.BackColor.R + "," + txtRClean.BackColor.G + "," + txtRClean.BackColor.B;
                _SysSetting.BColor5 = txtRRepair.BackColor.R + "," + txtRRepair.BackColor.G + "," + txtRRepair.BackColor.B;
                _SysSetting.BColor6 = txtRBussyMonthly.BackColor.R + "," + txtRBussyMonthly.BackColor.G + "," + txtRBussyMonthly.BackColor.B;
                _SysSetting.BColor7 = txtRLeave.BackColor.R + "," + txtRLeave.BackColor.G + "," + txtRLeave.BackColor.B;
                _SysSetting.FColor0 = txtREmpty.ForeColor.R + "," + txtREmpty.ForeColor.G + "," + txtREmpty.ForeColor.B;
                _SysSetting.FColor1 = txtRAvailable.ForeColor.R + "," + txtRAvailable.ForeColor.G + "," + txtRAvailable.ForeColor.B;
                _SysSetting.FColor2 = txtRBussyDaily.ForeColor.R + "," + txtRBussyDaily.ForeColor.G + "," + txtRBussyDaily.ForeColor.B;
                _SysSetting.FColor3 = txtRBussyAppendix.ForeColor.R + "," + txtRBussyAppendix.ForeColor.G + "," + txtRBussyAppendix.ForeColor.B;
                _SysSetting.FColor4 = txtRClean.ForeColor.R + "," + txtRClean.ForeColor.G + "," + txtRClean.ForeColor.B;
                _SysSetting.FColor5 = txtRRepair.ForeColor.R + "," + txtRRepair.ForeColor.G + "," + txtRRepair.ForeColor.B;
                _SysSetting.FColor6 = txtRBussyMonthly.ForeColor.R + "," + txtRBussyMonthly.ForeColor.G + "," + txtRBussyMonthly.ForeColor.B;
                _SysSetting.FColor7 = txtRLeave.ForeColor.R + "," + txtRLeave.ForeColor.G + "," + txtRLeave.ForeColor.B;
                if (superTabItem_Employee.Visible)
                {
                    Empsetting = VarGeneral.TString.ChkStatSave(ChkEmp1.Checked);
                    _SysSetting.EmpSeting = Empsetting;
                    try
                    {
                        _SysSetting.DocumentPath = textBox_DocPath.Text;
                    }
                    catch
                    {
                        _SysSetting.DocumentPath = string.Empty;
                    }
                    try
                    {
                        _SysSetting.AccUsrNo = null;
                    }
                    catch
                    {
                        _SysSetting.AccUsrNo = null;
                    }
                    try
                    {
                        _SysSetting.AttendanceManually = checkBox_AttendanceManually.Checked;
                    }
                    catch
                    {
                        _SysSetting.AttendanceManually = false;
                    }
                    try
                    {
                        _SysSetting.AutoLeave = checkBox_AutoLeave.Checked;
                    }
                    catch
                    {
                        _SysSetting.AutoLeave = false;
                    }
                    try
                    {
                        _SysSetting.CalculateNo = int.Parse(comboBox_CalculateNo.SelectedValue.ToString());
                    }
                    catch
                    {
                        _SysSetting.CalculateNo = 0;
                    }
                    try
                    {
                        _SysSetting.CalculatliquidNo = int.Parse(comboBox_CalculatliquidNo.SelectedValue.ToString());
                    }
                    catch
                    {
                        _SysSetting.CalculatliquidNo = 0;
                    }
                    try
                    {
                        _SysSetting.DisVacationType = comboBox_DisVacationType.SelectedIndex;
                    }
                    catch
                    {
                        _SysSetting.DisVacationType = 0;
                    }
                    try
                    {
                        _SysSetting.EmpLeaveAfter = textBox_AutoEmpLeaveAfter.Value;
                    }
                    catch
                    {
                        _SysSetting.EmpLeaveAfter = 0;
                    }
                    try
                    {
                        _SysSetting.AlarmEmpContractBefore = integerInput_AlarmEmpContractBefore.Value;
                    }
                    catch
                    {
                        _SysSetting.AlarmEmpContractBefore = 0;
                    }
                    try
                    {
                        _SysSetting.AlarmEmpDocBefore = integerInput_AlarmEmpDocBefore.Value;
                    }
                    catch
                    {
                        _SysSetting.AlarmEmpDocBefore = 0;
                    }
                    try
                    {
                        _SysSetting.AlarmEndVactionBefore = integerInput_AlarmEndVactionBefore.Value;
                    }
                    catch
                    {
                        _SysSetting.AlarmEndVactionBefore = 0;
                    }
                    try
                    {
                        _SysSetting.AlarmFamilyPassportBefore = integerInput_AlarmFamilyPassportBefore.Value;
                    }
                    catch
                    {
                        _SysSetting.AlarmFamilyPassportBefore = 0;
                    }
                    try
                    {
                        _SysSetting.AlarmGuarantorDocBefore = integerInput_AlarmGuarantorDocBefore.Value;
                    }
                    catch
                    {
                        _SysSetting.AlarmGuarantorDocBefore = 0;
                    }
                    try
                    {
                        _SysSetting.AlarmBranchDocBefore = 0;
                    }
                    catch
                    {
                        _SysSetting.AlarmBranchDocBefore = 0;
                    }
                    try
                    {
                        _SysSetting.AlarmCarDocBefore = integerInput_AlarmCarDocBefore.Value;
                    }
                    catch
                    {
                        _SysSetting.AlarmCarDocBefore = 0;
                    }
                    try
                    {
                        _SysSetting.AlarmCarDocBefore = integerInput_AlarmCarDocBefore.Value;
                    }
                    catch
                    {
                        _SysSetting.AlarmCarDocBefore = 0;
                    }
                    try
                    {
                        _SysSetting.AlarmSecretariatsBefore = integerInput_AlarmSecretariatsBefore.Value;
                    }
                    catch
                    {
                        _SysSetting.AlarmSecretariatsBefore = 0;
                    }
                    try
                    {
                        _SysSetting.IsAlarmEmpContract = checkBox_IsAlarmEmpContract.Checked;
                    }
                    catch
                    {
                        _SysSetting.IsAlarmEmpContract = false;
                    }
                    try
                    {
                        _SysSetting.IsAlarmEmpDoc = checkBox_IsAlarmEmpDoc.Checked;
                    }
                    catch
                    {
                        _SysSetting.IsAlarmEmpDoc = false;
                    }
                    try
                    {
                        _SysSetting.IsAlarmSecretariatsDoc = checkBox_IsAlarmSecretariatsDoc.Checked;
                    }
                    catch
                    {
                        _SysSetting.IsAlarmSecretariatsDoc = false;
                    }
                    try
                    {
                        _SysSetting.IsAlarmVisaGoBack = checkBox_IsAlarmVisaGoBack.Checked;
                    }
                    catch
                    {
                        _SysSetting.IsAlarmVisaGoBack = false;
                    }
                    try
                    {
                        _SysSetting.IsAlarmVisaIntro = false;
                    }
                    catch
                    {
                        _SysSetting.IsAlarmVisaIntro = false;
                    }
                    try
                    {
                        _SysSetting.IsAlarmDepts = checkBox_IsAlarmDepts.Checked;
                    }
                    catch
                    {
                        _SysSetting.IsAlarmDepts = false;
                    }
                    try
                    {
                        _SysSetting.IsAlarmEndVaction = checkBox_IsAlarmEndVaction.Checked;
                    }
                    catch
                    {
                        _SysSetting.IsAlarmEndVaction = false;
                    }
                    try
                    {
                        _SysSetting.IsAlarmBranchDoc = false;
                    }
                    catch
                    {
                        _SysSetting.IsAlarmBranchDoc = false;
                    }
                    try
                    {
                        _SysSetting.IsAlarmFamilyPassport = checkBox_IsAlarmFamilyPassport.Checked;
                    }
                    catch
                    {
                        _SysSetting.IsAlarmFamilyPassport = false;
                    }
                    try
                    {
                        _SysSetting.IsAlarmGuarantorDoc = checkBox_IsAlarmGuarantorDoc.Checked;
                    }
                    catch
                    {
                        _SysSetting.IsAlarmGuarantorDoc = false;
                    }
                    try
                    {
                        _SysSetting.IsAlarmCarDoc = checkBox_IsAlarmCarDoc.Checked;
                    }
                    catch
                    {
                        _SysSetting.IsAlarmCarDoc = false;
                    }
                    try
                    {
                        _SysSetting.AttendanceManually = checkBox_AttendanceManually.Checked;
                    }
                    catch
                    {
                        _SysSetting.AttendanceManually = false;
                    }
                    try
                    {
                        _SysSetting.AutoLeave = checkBox_AutoLeave.Checked;
                    }
                    catch
                    {
                        _SysSetting.AutoLeave = false;
                    }
                    try
                    {
                        _SysSetting.VacationManually = checkBox_VacationManually.Checked;
                    }
                    catch
                    {
                        _SysSetting.VacationManually = false;
                    }
                    try
                    {
                        _SysSetting.AutoChangSalStatus = false;
                    }
                    catch
                    {
                        _SysSetting.AutoChangSalStatus = false;
                    }
                    try
                    {
                        _SysSetting.Sponer = checkBox_Sponer.Checked;
                    }
                    catch
                    {
                        _SysSetting.Sponer = false;
                    }
                    try
                    {
                        _SysSetting.IsAutoBackup = checkBox_AutoBackup.Checked;
                    }
                    catch
                    {
                        _SysSetting.IsAutoBackup = false;
                    }
                    try
                    {
                        _SysSetting.AutoBackup = comboBox_AutoBackup.SelectedIndex;
                    }
                    catch
                    {
                        _SysSetting.AutoBackup = 0;
                    }
                }
                settingNewLine = VarGeneral.TString.ChkStatSave(chk1Show.Checked);
                settingNewLine += VarGeneral.TString.ChkStatSave(chk1Print.Checked);
                settingNewLine += VarGeneral.TString.ChkStatSave(chk2Show.Checked);
                settingNewLine += VarGeneral.TString.ChkStatSave(chk2Print.Checked);
                settingNewLine += VarGeneral.TString.ChkStatSave(chk3Show.Checked);
                settingNewLine += VarGeneral.TString.ChkStatSave(chk3Print.Checked);
                settingNewLine += VarGeneral.TString.ChkStatSave(chk4Show.Checked);
                settingNewLine += VarGeneral.TString.ChkStatSave(chk4Print.Checked);
                settingNewLine += VarGeneral.TString.ChkStatSave(chk5Show.Checked);
                settingNewLine += VarGeneral.TString.ChkStatSave(chk5Print.Checked);
                settingNewLine += VarGeneral.TString.ChkStatSave(chk6Show.Checked);
                settingNewLine += VarGeneral.TString.ChkStatSave(chk6Print.Checked);
                settingNewLine += VarGeneral.TString.ChkStatSave(chk7Show.Checked);
                settingNewLine += VarGeneral.TString.ChkStatSave(chk7Print.Checked);
                settingNewLine += VarGeneral.TString.ChkStatSave(chk8Show.Checked);
                settingNewLine += VarGeneral.TString.ChkStatSave(chk8Print.Checked);
                settingNewLine += VarGeneral.TString.ChkStatSave(chk9Show.Checked);
                settingNewLine += VarGeneral.TString.ChkStatSave(chk9Print.Checked);
                settingNewLine += VarGeneral.TString.ChkStatSave(chk10Show.Checked);
                settingNewLine += VarGeneral.TString.ChkStatSave(chk10Print.Checked);
                settingNewLine += VarGeneral.TString.ChkStatSave(chk11Show.Checked);
                settingNewLine += VarGeneral.TString.ChkStatSave(chk11Print.Checked);
                settingNewLine += VarGeneral.TString.ChkStatSave(chk12Show.Checked);
                settingNewLine += VarGeneral.TString.ChkStatSave(chk12Print.Checked);
                settingNewLine += VarGeneral.TString.ChkStatSave(chk13Show.Checked);
                settingNewLine += VarGeneral.TString.ChkStatSave(chk13Print.Checked);
                settingNewLine += VarGeneral.TString.ChkStatSave(chk14Show.Checked);
                settingNewLine += VarGeneral.TString.ChkStatSave(chk14Print.Checked);
                if (switchButton_NewColumnName.Value)
                {
                    _SysSetting.LineDetailSts = settingNewLine;
                    VarGeneral.Settings_Sys.LineDetailSts = settingNewLine;
                }
                else
                {
                    _SysSetting.LineGiftSts = settingNewLine;
                    VarGeneral.Settings_Sys.LineGiftSts = settingNewLine;
                }
                _SysSetting.GuestAcc = txtGuestsFatherAcc.Text;
                _SysSetting.GuestBoxAcc = txtGuestBoxAcc.Text;
                //    _SysSetting.DefLines_Setting = txtpageCountRep.Value;
                db.Log = VarGeneral.DebugLog;
                db.SubmitChanges(ConflictMode.ContinueOnConflict);
                _Company.Active = txtAct.Text;
                _Company.Adder = txtAddr.Text;
                _Company.CopNam = txtCompany.Text;
                _Company.Eamil = txtRemark.Text;
                _Company.Fax = txtFax.Text;
                _Company.Mobl = txtMobile.Text;
                _Company.Pox = txtPOBox.Text;
                _Company.Symbl = txtMailCode.Text;
                _Company.Tel1 = txtTel1.Text;
                _Company.Tel2 = txtTel2.Text;
                db.Log = VarGeneral.DebugLog;
                db.SubmitChanges(ConflictMode.ContinueOnConflict);
                _GdAuto.Acc0 = int.Parse(txtBoxAccount.Text);
                _GdAuto.Acc1 = int.Parse(txtProfits.Text);
                _GdAuto.Acc2 = int.Parse(txtFirstInventory.Text);
                _GdAuto.Acc3 = int.Parse(txtLastInventory.Text);
                db.Log = VarGeneral.DebugLog;
                db.SubmitChanges(ConflictMode.ContinueOnConflict);
                for (int iiCnt = 1; iiCnt < c1FlexGrid1.Rows.Count; iiCnt++)
                {
                    for (int i = 0; i < listInvSetting.Count; i++)
                    {
                        _InvSetting = listInvSetting[i];
                        if (_InvSetting.InvID == int.Parse(c1FlexGrid1.GetData(iiCnt, 6).ToString()))
                        {
                            if (c1FlexGrid1.GetData(iiCnt, 7).ToString() == "0")
                            {
                                _InvSetting.AccDebit0 = c1FlexGrid1.GetData(iiCnt, 4).ToString();
                                _InvSetting.AccCredit0 = c1FlexGrid1.GetData(iiCnt, 5).ToString();
                                _InvSetting.InvSetting = _InvSetting.InvSetting.Substring(0, 1) + VarGeneral.TString.ChkStatSave((bool)c1FlexGrid1.GetData(iiCnt, 3)) + _InvSetting.InvSetting.Substring(0, 1);
                            }
                            else if (c1FlexGrid1.GetData(iiCnt, 7).ToString() == "1")
                            {
                                _InvSetting.AccDebit1 = c1FlexGrid1.GetData(iiCnt, 4).ToString();
                                _InvSetting.AccCredit1 = c1FlexGrid1.GetData(iiCnt, 5).ToString();
                                _InvSetting.InvSetting = _InvSetting.InvSetting.Substring(0, 1) + VarGeneral.TString.ChkStatSave((bool)c1FlexGrid1.GetData(iiCnt, 3)) + _InvSetting.InvSetting.Substring(0, 1);
                            }
                            else if (c1FlexGrid1.GetData(iiCnt, 7).ToString() == "2")
                            {
                                _InvSetting.AccDebit2 = c1FlexGrid1.GetData(iiCnt, 4).ToString();
                                _InvSetting.AccCredit2 = c1FlexGrid1.GetData(iiCnt, 5).ToString();
                                _InvSetting.InvSetting = _InvSetting.InvSetting.Substring(0, 1) + VarGeneral.TString.ChkStatSave((bool)c1FlexGrid1.GetData(iiCnt, 3)) + _InvSetting.InvSetting.Substring(0, 1);
                            }
                            else if (c1FlexGrid1.GetData(iiCnt, 7).ToString() == "3")
                            {
                                _InvSetting.DisDebit = c1FlexGrid1.GetData(iiCnt, 4).ToString();
                                _InvSetting.DisCredit = c1FlexGrid1.GetData(iiCnt, 5).ToString();
                                _InvSetting.autoDisGaid = Convert.ToBoolean(c1FlexGrid1.GetData(iiCnt, 3));
                            }
                            db.Log = VarGeneral.DebugLog;
                            db.SubmitChanges(ConflictMode.ContinueOnConflict);
                            break;
                        }
                    }
                }
                db.ExecuteCommand(string.Concat("update T_InfoTb set fldValue = '", txtHeadingR1.Text, "' where fldFlag = '", txtHeadingR1.Tag, "'"));
                db.ExecuteCommand(string.Concat("update T_InfoTb set fldValue = '", txtHeadingR2.Text, "' where fldFlag = '", txtHeadingR2.Tag, "'"));
                db.ExecuteCommand(string.Concat("update T_InfoTb set fldValue = '", txtHeadingR3.Text, "' where fldFlag = '", txtHeadingR3.Tag, "'"));
                db.ExecuteCommand(string.Concat("update T_InfoTb set fldValue = '", txtHeadingR4.Text, "' where fldFlag = '", txtHeadingR4.Tag, "'"));
                db.ExecuteCommand(string.Concat("update T_InfoTb set fldValue = '", txtHeadingL1.Text, "' where fldFlag = '", txtHeadingL1.Tag, "'"));
                db.ExecuteCommand(string.Concat("update T_InfoTb set fldValue = '", txtHeadingL2.Text, "' where fldFlag = '", txtHeadingL2.Tag, "'"));
                db.ExecuteCommand(string.Concat("update T_InfoTb set fldValue = '", txtHeadingL3.Text, "' where fldFlag = '", txtHeadingL3.Tag, "'"));
                db.ExecuteCommand(string.Concat("update T_InfoTb set fldValue = '", txtHeadingL4.Text, "' where fldFlag = '", txtHeadingL4.Tag, "'"));
                for (int i = 2; i < FlxInv.Rows.Count; i++)
                {
                    db.ExecuteCommand(string.Concat("update T_AccDef set DepreciationPercent = ", FlxInv.GetData(i, 2), ", ProofAcc = '", FlxInv.GetData(i, 3), "',RelayAcc = '", FlxInv.GetData(i, 4), "' where AccDef_No = '", FlxInv.GetData(i, 5), "'"));
                }
                db.ExecuteCommand("update T_Curency set Rate = 1 where Curency_ID = " + int.Parse(_SysSetting.ImportIp));
                MessageBox.Show((LangArEn == 0) ? "لقد تم اتمام العملية بنجاح .." : "This Opration Is Done", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                try
                {
                    Stock_DataDataContext dbc = new Stock_DataDataContext(VarGeneral.BranchCS);
                    VarGeneral.Settings_Sys = new T_SYSSETTING();
                    VarGeneral.Settings_Sys = dbc.SystemSettingStock();
                    VarGeneral._SysDirPath = VarGeneral.Settings_Sys.SysDir;
                    VarGeneral._BackPath = VarGeneral.Settings_Sys.BackPath;
                    try
                    {
                        VarGeneral._AutoSync = VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 41);
                    }
                    catch
                    {
                        VarGeneral._AutoSync = false;
                    }
                    dbc.getdate = string.Empty;
                }
                catch
                {
                    Application.Exit();
                }
                if (VarGeneral.Settings_Sys.Calendr.Value == 0)
                {
                    CultureInfo sa = new CultureInfo("en-US", useUserOverride: false);
                    sa.DateTimeFormat.Calendar = new GregorianCalendar();
                    Thread.CurrentThread.CurrentCulture = sa;
                    Thread.CurrentThread.CurrentUICulture = sa;
                }
                else
                {
                    CultureInfo sa = new CultureInfo("ar-SA", useUserOverride: false);
                    sa.DateTimeFormat.Calendar = new HijriCalendar();
                    Thread.CurrentThread.CurrentCulture = sa;
                    Thread.CurrentThread.CurrentUICulture = sa;
                }
                Close();
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Save:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void FillCombo()
        {
            int _CmbIndex = 0;
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
            {
                try
                {

                }
                catch
                {
                }
                List<T_Curency> listCurr = new List<T_Curency>(db.T_Curencies.Select((T_Curency item) => item).ToList());
                CmbCurr.DataSource = listCurr;
                CmbCurr.DisplayMember = "Arb_Des";
                CmbCurr.ValueMember = "Curency_ID";
                CmbCurr.SelectedIndex = 0;
                _CmbIndex = CmbDateTyp.SelectedIndex;
                CmbDateTyp.Items.Clear();
                CmbDateTyp.Items.Add("يوم");
                CmbDateTyp.Items.Add("شهر");
                CmbDateTyp.Items.Add("سنة");
                CmbDateTyp.SelectedIndex = 0;
                CmbPrintTyp.Items.Clear();
                CmbPrintTyp.Items.Add("فاتورة المبيعات فقط");
                CmbPrintTyp.Items.Add("اعدادات التصنيفات فقط");
                CmbPrintTyp.Items.Add("الكــــل");
                try
                {
                    CmbPointImages.Items.Clear();
                    CmbPointImages.Items.Add("عشـــوائــي");
                    CmbPointImages.Items.Add("حسب صورة الصنف");
                    CmbPointImages.Items.Add("بدون صور");
                    CmbPointImages.SelectedIndex = 0;
                }
                catch
                {
                }
                try
                {
                    CmbOrderTyp.Items.Clear();
                    CmbOrderTyp.Items.Add("محلي");
                    CmbOrderTyp.Items.Add("سفري");
                    CmbOrderTyp.SelectedIndex = 0;
                }
                catch
                {
                }
                _CmbIndex = CmbCost.SelectedIndex;
                CmbCost.Items.Clear();
                CmbCost.Items.Add("آخر تكلفة");
                CmbCost.Items.Add("متوسط التكلفة");
                CmbCost.SelectedIndex = 0;
                _CmbIndex = CmbInvMode.SelectedIndex;
                CmbInvMode.Items.Clear();
                CmbInvMode.Items.Add("نقدي");
                CmbInvMode.Items.Add("آجل");
                CmbInvMode.SelectedIndex = 0;
                try
                {
                    FlxInv.SetData(0, 1, "الحساب");
                    FlxInv.SetData(0, 2, "% الإهلاك");
                    FlxInv.SetData(0, 3, "قيـد الإثبـــات");
                    FlxInv.SetData(0, 4, "قيـد الترحيــل");
                }
                catch
                {
                }
                chk36.Items.Clear();
                chk36.Items.Add("القالب الأول");
                chk36.Items.Add("القالب الثاني");
                chk36.Items.Add("القالب الثالث");
                chk36.Items.Add("القالب الرابع");
                chk36.SelectedIndex = 0;
                chk39.Items.Clear();
                chk39.Items.Add("-------");
                chk39.Items.Add("إخفاء الشعار");
                chk39.Items.Add("إخفاء الأسعار");
                chk39.Items.Add("إخفاء الكل");
                chk39.SelectedIndex = 0;
                chk46.Items.Clear();
                chk46.Items.Add("العمولة : نسبـة من الإجمالـي");
                chk46.Items.Add("العمولة : مبلغ ثابت في الكمية");
                chk46.Items.Add("العمولة : مبــــلغ مقطـــــــــوع");
                chk46.SelectedIndex = 0;
                try
                {
                    c1FlexGrid1.SetData(0, 1, "السند");
                    c1FlexGrid1.SetData(0, 2, "طريقة السند");
                    c1FlexGrid1.SetData(0, 3, "إصدار قيد");
                    c1FlexGrid1.SetData(0, 4, "حساب مدين");
                    c1FlexGrid1.SetData(0, 5, "حساب دائن");
                    c1FlexGrid1.SetData(1, 1, "فاتورة مبيعات");
                    c1FlexGrid1.SetData(1, 2, "نقدي");
                    c1FlexGrid1.SetData(1, 6, 1);
                    c1FlexGrid1.SetData(1, 7, 0);
                    c1FlexGrid1.SetData(2, 1, "فاتورة مبيعات");
                    c1FlexGrid1.SetData(2, 2, "آجل");
                    c1FlexGrid1.SetData(2, 6, 1);
                    c1FlexGrid1.SetData(2, 7, 1);
                    c1FlexGrid1.SetData(3, 1, "فاتورة مبيعات");
                    c1FlexGrid1.SetData(3, 2, "شيك");
                    c1FlexGrid1.SetData(3, 6, 1);
                    c1FlexGrid1.SetData(3, 7, 2);
                    c1FlexGrid1.SetData(4, 1, "الخصــــم");
                    c1FlexGrid1.SetData(4, 2, "سند");
                    c1FlexGrid1.SetData(4, 6, 1);
                    c1FlexGrid1.SetData(4, 7, 3);
                    c1FlexGrid1.SetData(5, 1, "فاتورة مشتريات");
                    c1FlexGrid1.SetData(5, 2, "نقدي");
                    c1FlexGrid1.SetData(5, 6, 2);
                    c1FlexGrid1.SetData(5, 7, 0);
                    c1FlexGrid1.SetData(6, 1, "فاتورة مشتريات");
                    c1FlexGrid1.SetData(6, 2, "آجل");
                    c1FlexGrid1.SetData(6, 6, 2);
                    c1FlexGrid1.SetData(6, 7, 1);
                    c1FlexGrid1.SetData(7, 1, "فاتورة مشتريات");
                    c1FlexGrid1.SetData(7, 2, "شيك");
                    c1FlexGrid1.SetData(7, 6, 2);
                    c1FlexGrid1.SetData(7, 7, 2);
                    c1FlexGrid1.SetData(8, 1, "الخصــــم");
                    c1FlexGrid1.SetData(8, 2, "سند");
                    c1FlexGrid1.SetData(8, 6, 2);
                    c1FlexGrid1.SetData(8, 7, 3);
                    c1FlexGrid1.SetData(9, 1, "مرتجع مبيعات");
                    c1FlexGrid1.SetData(9, 2, "نقدي");
                    c1FlexGrid1.SetData(9, 6, 3);
                    c1FlexGrid1.SetData(9, 7, 0);
                    c1FlexGrid1.SetData(10, 1, "مرتجع مبيعات");
                    c1FlexGrid1.SetData(10, 2, "آجل");
                    c1FlexGrid1.SetData(10, 6, 3);
                    c1FlexGrid1.SetData(10, 7, 1);
                    c1FlexGrid1.SetData(11, 1, "مرتجع مبيعات");
                    c1FlexGrid1.SetData(11, 2, "شيك");
                    c1FlexGrid1.SetData(11, 6, 3);
                    c1FlexGrid1.SetData(11, 7, 2);
                    c1FlexGrid1.SetData(12, 1, "الخصــــم");
                    c1FlexGrid1.SetData(12, 2, "سند");
                    c1FlexGrid1.SetData(12, 6, 3);
                    c1FlexGrid1.SetData(12, 7, 3);
                    c1FlexGrid1.SetData(13, 1, "مرتجع مشتريات");
                    c1FlexGrid1.SetData(13, 2, "نقدي");
                    c1FlexGrid1.SetData(13, 6, 4);
                    c1FlexGrid1.SetData(13, 7, 0);
                    c1FlexGrid1.SetData(14, 1, "مرتجع مشتريات");
                    c1FlexGrid1.SetData(14, 2, "آجل");
                    c1FlexGrid1.SetData(14, 6, 4);
                    c1FlexGrid1.SetData(14, 7, 1);
                    c1FlexGrid1.SetData(15, 1, "مرتجع مشتريات");
                    c1FlexGrid1.SetData(15, 2, "شيك");
                    c1FlexGrid1.SetData(15, 6, 4);
                    c1FlexGrid1.SetData(15, 7, 2);
                    c1FlexGrid1.SetData(16, 1, "الخصــــم");
                    c1FlexGrid1.SetData(16, 2, "سند");
                    c1FlexGrid1.SetData(16, 6, 4);
                    c1FlexGrid1.SetData(16, 7, 3);
                    c1FlexGrid1.SetData(17, 1, "سند أدخال بضاعة");
                    c1FlexGrid1.SetData(17, 2, "سند");
                    c1FlexGrid1.SetData(17, 6, 5);
                    c1FlexGrid1.SetData(17, 7, 0);
                    c1FlexGrid1.SetData(18, 1, "الخصــــم");
                    c1FlexGrid1.SetData(18, 2, "سند");
                    c1FlexGrid1.SetData(18, 6, 5);
                    c1FlexGrid1.SetData(18, 7, 3);
                    c1FlexGrid1.SetData(19, 1, "سند أخراج بضاعة");
                    c1FlexGrid1.SetData(19, 2, "سند");
                    c1FlexGrid1.SetData(19, 6, 6);
                    c1FlexGrid1.SetData(19, 7, 0);
                    c1FlexGrid1.SetData(20, 1, "الخصــــم");
                    c1FlexGrid1.SetData(20, 2, "سند");
                    c1FlexGrid1.SetData(20, 6, 6);
                    c1FlexGrid1.SetData(20, 7, 3);
                    c1FlexGrid1.SetData(21, 1, "عرض سعر عملاء");
                    c1FlexGrid1.SetData(21, 2, "سند");
                    c1FlexGrid1.SetData(21, 6, 7);
                    c1FlexGrid1.SetData(21, 7, 0);
                    c1FlexGrid1.SetData(22, 1, "الخصــــم");
                    c1FlexGrid1.SetData(22, 2, "سند");
                    c1FlexGrid1.SetData(22, 6, 7);
                    c1FlexGrid1.SetData(22, 7, 3);
                    c1FlexGrid1.SetData(23, 1, "عرض سعر مورد");
                    c1FlexGrid1.SetData(23, 2, "سند");
                    c1FlexGrid1.SetData(23, 6, 8);
                    c1FlexGrid1.SetData(23, 7, 0);
                    c1FlexGrid1.SetData(24, 1, "الخصــــم");
                    c1FlexGrid1.SetData(24, 2, "سند");
                    c1FlexGrid1.SetData(24, 6, 8);
                    c1FlexGrid1.SetData(24, 7, 3);
                    c1FlexGrid1.SetData(25, 1, "طلب شراء");
                    c1FlexGrid1.SetData(25, 2, "سند");
                    c1FlexGrid1.SetData(25, 6, 9);
                    c1FlexGrid1.SetData(25, 7, 0);
                    c1FlexGrid1.SetData(26, 1, "الخصــــم");
                    c1FlexGrid1.SetData(26, 2, "سند");
                    c1FlexGrid1.SetData(26, 6, 9);
                    c1FlexGrid1.SetData(26, 7, 3);
                    c1FlexGrid1.SetData(27, 1, "سند تسوية بضاعة");
                    c1FlexGrid1.SetData(27, 2, "سند");
                    c1FlexGrid1.SetData(27, 6, 10);
                    c1FlexGrid1.SetData(27, 7, 0);
                    c1FlexGrid1.SetData(28, 1, "الخصــــم");
                    c1FlexGrid1.SetData(28, 2, "سند");
                    c1FlexGrid1.SetData(28, 6, 10);
                    c1FlexGrid1.SetData(28, 7, 3);
                    c1FlexGrid1.SetData(29, 1, "بضاعة اول المدة");
                    c1FlexGrid1.SetData(29, 2, "سند");
                    c1FlexGrid1.SetData(29, 6, 14);
                    c1FlexGrid1.SetData(29, 7, 0);
                    c1FlexGrid1.SetData(30, 1, "الخصــــم");
                    c1FlexGrid1.SetData(30, 2, "سند");
                    c1FlexGrid1.SetData(30, 6, 14);
                    c1FlexGrid1.SetData(30, 7, 3);
                    c1FlexGrid1.SetData(31, 1, "أمر صرف بضاعة");
                    c1FlexGrid1.SetData(31, 2, "سند");
                    c1FlexGrid1.SetData(31, 6, 17);
                    c1FlexGrid1.SetData(31, 7, 0);
                    c1FlexGrid1.SetData(32, 1, "الخصــــم");
                    c1FlexGrid1.SetData(32, 2, "سند");
                    c1FlexGrid1.SetData(32, 6, 17);
                    c1FlexGrid1.SetData(32, 7, 3);
                    c1FlexGrid1.SetData(33, 1, "مرتجع صرف بضاعة");
                    c1FlexGrid1.SetData(33, 2, "سند");
                    c1FlexGrid1.SetData(33, 6, 20);
                    c1FlexGrid1.SetData(33, 7, 0);
                    c1FlexGrid1.SetData(34, 1, "الخصــــم");
                    c1FlexGrid1.SetData(34, 2, "سند");
                    c1FlexGrid1.SetData(34, 6, 20);
                    c1FlexGrid1.SetData(34, 7, 3);
                    c1FlexGrid1.SetData(35, 1, "إنتاج الأصناف - تصنيع");
                    c1FlexGrid1.SetData(35, 2, "سند");
                    c1FlexGrid1.SetData(35, 6, 16);
                    c1FlexGrid1.SetData(35, 7, 0);
                    c1FlexGrid1.SetData(36, 1, "الخصــــم");
                    c1FlexGrid1.SetData(36, 2, "سند");
                    c1FlexGrid1.SetData(36, 6, 16);
                    c1FlexGrid1.SetData(36, 7, 3);
                }
                catch
                {
                }
            }
            else
            {
                List<T_Curency> listCurr = new List<T_Curency>(db.T_Curencies.Select((T_Curency item) => item).ToList());
                CmbCurr.DataSource = listCurr;
                CmbCurr.DisplayMember = "Eng_Des";
                CmbCurr.ValueMember = "Curency_ID";
                CmbCurr.SelectedIndex = 0;
                _CmbIndex = CmbDateTyp.SelectedIndex;
                CmbDateTyp.Items.Clear();
                CmbDateTyp.Items.Add("Day");
                CmbDateTyp.Items.Add("Month");
                CmbDateTyp.Items.Add("Year");
                CmbDateTyp.SelectedIndex = 0;
                _CmbIndex = CmbCost.SelectedIndex;
                CmbCost.Items.Clear();
                CmbCost.Items.Add("Last Cost");
                CmbCost.Items.Add("Average Cost");
                CmbCost.SelectedIndex = 0;
                CmbPrintTyp.Items.Clear();
                CmbPrintTyp.Items.Add("Sales only");
                CmbPrintTyp.Items.Add("Categories only");
                CmbPrintTyp.Items.Add("ALL");
                CmbPrintTyp.SelectedIndex = 0;
                try
                {
                    CmbPointImages.Items.Clear();
                    CmbPointImages.Items.Add("Random");
                    CmbPointImages.Items.Add("By Image Item");
                    CmbPointImages.Items.Add("WithOut Images");
                    CmbPointImages.SelectedIndex = 0;
                }
                catch
                {
                }
                try
                {
                    CmbOrderTyp.Items.Clear();
                    CmbOrderTyp.Items.Add("Localy");
                    CmbOrderTyp.Items.Add("Out");
                    CmbOrderTyp.SelectedIndex = 0;
                }
                catch
                {
                }
                _CmbIndex = CmbInvMode.SelectedIndex;
                CmbInvMode.Items.Clear();
                CmbInvMode.Items.Add("Cash");
                CmbInvMode.Items.Add("Credit");
                CmbInvMode.SelectedIndex = 0;
                try
                {
                    FlxInv.SetData(0, 1, "Account Name");
                    FlxInv.SetData(0, 2, "destruction %");
                    FlxInv.SetData(0, 3, "Proof");
                    FlxInv.SetData(0, 4, "Relay");
                }
                catch
                {
                }
                chk36.Items.Clear();
                chk36.Items.Add("First Template");
                chk36.Items.Add("Second Template");
                chk36.Items.Add("Third Template");
                chk36.Items.Add("Four Template");
                chk36.SelectedIndex = 0;
                chk39.Items.Clear();
                chk39.Items.Add("-------");
                chk39.Items.Add("Logo Hide");
                chk39.Items.Add("Prices Hide");
                chk39.Items.Add("ALL Hide");
                chk39.SelectedIndex = 0;
                chk46.Items.Clear();
                chk46.Items.Add("Comm %");
                chk46.Items.Add("Comm Amount * Quantity");
                chk46.Items.Add("Comm Static Value");
                chk46.SelectedIndex = 0;
                try
                {
                    c1FlexGrid1.SetData(0, 1, "Receipt");
                    c1FlexGrid1.SetData(0, 2, "Type");
                    c1FlexGrid1.SetData(0, 3, "Launch");
                    c1FlexGrid1.SetData(0, 4, "Debit Account");
                    c1FlexGrid1.SetData(0, 5, "Credit Account");
                    c1FlexGrid1.SetData(1, 1, "Sales Invoice");
                    c1FlexGrid1.SetData(1, 2, "Cash");
                    c1FlexGrid1.SetData(1, 6, 1);
                    c1FlexGrid1.SetData(1, 7, 0);
                    c1FlexGrid1.SetData(2, 1, "Sales Invoice");
                    c1FlexGrid1.SetData(2, 2, "Credit");
                    c1FlexGrid1.SetData(2, 6, 1);
                    c1FlexGrid1.SetData(2, 7, 1);
                    c1FlexGrid1.SetData(3, 1, "Sales Invoice");
                    c1FlexGrid1.SetData(3, 2, "Check");
                    c1FlexGrid1.SetData(3, 6, 1);
                    c1FlexGrid1.SetData(3, 7, 2);
                    c1FlexGrid1.SetData(4, 1, "Discount");
                    c1FlexGrid1.SetData(4, 2, "Receipt");
                    c1FlexGrid1.SetData(4, 6, 1);
                    c1FlexGrid1.SetData(4, 7, 3);
                    c1FlexGrid1.SetData(5, 1, "Purchase Receipt");
                    c1FlexGrid1.SetData(5, 2, "Cash");
                    c1FlexGrid1.SetData(5, 6, 2);
                    c1FlexGrid1.SetData(5, 7, 0);
                    c1FlexGrid1.SetData(6, 1, "Purchase Receipt");
                    c1FlexGrid1.SetData(6, 2, "Credit");
                    c1FlexGrid1.SetData(6, 6, 2);
                    c1FlexGrid1.SetData(6, 7, 1);
                    c1FlexGrid1.SetData(7, 1, "Purchase Receipt");
                    c1FlexGrid1.SetData(7, 2, "Check");
                    c1FlexGrid1.SetData(7, 6, 2);
                    c1FlexGrid1.SetData(7, 7, 2);
                    c1FlexGrid1.SetData(8, 1, "Discount");
                    c1FlexGrid1.SetData(8, 2, "Receipt");
                    c1FlexGrid1.SetData(8, 6, 2);
                    c1FlexGrid1.SetData(8, 7, 3);
                    c1FlexGrid1.SetData(9, 1, "Sales Return");
                    c1FlexGrid1.SetData(9, 2, "Cash");
                    c1FlexGrid1.SetData(9, 6, 3);
                    c1FlexGrid1.SetData(9, 7, 0);
                    c1FlexGrid1.SetData(10, 1, "Sales Return");
                    c1FlexGrid1.SetData(10, 2, "Credit");
                    c1FlexGrid1.SetData(10, 6, 3);
                    c1FlexGrid1.SetData(10, 7, 1);
                    c1FlexGrid1.SetData(11, 1, "Sales Return");
                    c1FlexGrid1.SetData(11, 2, "Check");
                    c1FlexGrid1.SetData(11, 6, 3);
                    c1FlexGrid1.SetData(11, 7, 2);
                    c1FlexGrid1.SetData(12, 1, "Discount");
                    c1FlexGrid1.SetData(12, 2, "Receipt");
                    c1FlexGrid1.SetData(12, 6, 3);
                    c1FlexGrid1.SetData(12, 7, 3);
                    c1FlexGrid1.SetData(13, 1, "Purchase Return");
                    c1FlexGrid1.SetData(13, 2, "Cash");
                    c1FlexGrid1.SetData(13, 6, 4);
                    c1FlexGrid1.SetData(13, 7, 0);
                    c1FlexGrid1.SetData(14, 1, "Purchase Return");
                    c1FlexGrid1.SetData(14, 2, "Credit");
                    c1FlexGrid1.SetData(14, 6, 4);
                    c1FlexGrid1.SetData(14, 7, 1);
                    c1FlexGrid1.SetData(15, 1, "Purchase Return");
                    c1FlexGrid1.SetData(15, 2, "Check");
                    c1FlexGrid1.SetData(15, 6, 4);
                    c1FlexGrid1.SetData(15, 7, 2);
                    c1FlexGrid1.SetData(16, 1, "Discount");
                    c1FlexGrid1.SetData(16, 2, "Receipt");
                    c1FlexGrid1.SetData(16, 6, 4);
                    c1FlexGrid1.SetData(16, 7, 3);
                    c1FlexGrid1.SetData(17, 1, "Transfer In");
                    c1FlexGrid1.SetData(17, 2, "Receipt");
                    c1FlexGrid1.SetData(17, 6, 5);
                    c1FlexGrid1.SetData(17, 7, 0);
                    c1FlexGrid1.SetData(18, 1, "Discount");
                    c1FlexGrid1.SetData(18, 2, "Receipt");
                    c1FlexGrid1.SetData(18, 6, 5);
                    c1FlexGrid1.SetData(18, 7, 3);
                    c1FlexGrid1.SetData(19, 1, "Transfer Out");
                    c1FlexGrid1.SetData(19, 2, "Receipt");
                    c1FlexGrid1.SetData(19, 6, 6);
                    c1FlexGrid1.SetData(19, 7, 0);
                    c1FlexGrid1.SetData(20, 1, "Discount");
                    c1FlexGrid1.SetData(20, 2, "Receipt");
                    c1FlexGrid1.SetData(20, 6, 6);
                    c1FlexGrid1.SetData(20, 7, 3);
                    c1FlexGrid1.SetData(21, 1, "Customer Qutation");
                    c1FlexGrid1.SetData(21, 2, "Receipt");
                    c1FlexGrid1.SetData(21, 6, 7);
                    c1FlexGrid1.SetData(21, 7, 0);
                    c1FlexGrid1.SetData(22, 1, "Discount");
                    c1FlexGrid1.SetData(22, 2, "Receipt");
                    c1FlexGrid1.SetData(22, 6, 7);
                    c1FlexGrid1.SetData(22, 7, 3);
                    c1FlexGrid1.SetData(23, 1, "Supplier Qutation");
                    c1FlexGrid1.SetData(23, 2, "Receipt");
                    c1FlexGrid1.SetData(23, 6, 8);
                    c1FlexGrid1.SetData(23, 7, 0);
                    c1FlexGrid1.SetData(24, 1, "Discount");
                    c1FlexGrid1.SetData(24, 2, "Receipt");
                    c1FlexGrid1.SetData(24, 6, 8);
                    c1FlexGrid1.SetData(24, 7, 3);
                    c1FlexGrid1.SetData(25, 1, "Purchase Order");
                    c1FlexGrid1.SetData(25, 2, "Receipt");
                    c1FlexGrid1.SetData(25, 6, 9);
                    c1FlexGrid1.SetData(25, 7, 0);
                    c1FlexGrid1.SetData(26, 1, "Discount");
                    c1FlexGrid1.SetData(26, 2, "Receipt");
                    c1FlexGrid1.SetData(26, 6, 9);
                    c1FlexGrid1.SetData(26, 7, 3);
                    c1FlexGrid1.SetData(27, 1, "Stock Adjustment");
                    c1FlexGrid1.SetData(27, 2, "Receipt");
                    c1FlexGrid1.SetData(27, 6, 10);
                    c1FlexGrid1.SetData(27, 7, 0);
                    c1FlexGrid1.SetData(28, 1, "Discount");
                    c1FlexGrid1.SetData(28, 2, "Receipt");
                    c1FlexGrid1.SetData(28, 6, 10);
                    c1FlexGrid1.SetData(28, 7, 3);
                    c1FlexGrid1.SetData(29, 1, "Open Quantities");
                    c1FlexGrid1.SetData(29, 2, "Receipt");
                    c1FlexGrid1.SetData(29, 6, 14);
                    c1FlexGrid1.SetData(29, 7, 0);
                    c1FlexGrid1.SetData(30, 1, "Discount");
                    c1FlexGrid1.SetData(30, 2, "Receipt");
                    c1FlexGrid1.SetData(30, 6, 14);
                    c1FlexGrid1.SetData(30, 7, 3);
                    c1FlexGrid1.SetData(31, 1, "Payment Order");
                    c1FlexGrid1.SetData(31, 2, "Receipt");
                    c1FlexGrid1.SetData(31, 6, 17);
                    c1FlexGrid1.SetData(31, 7, 0);
                    c1FlexGrid1.SetData(32, 1, "Discount");
                    c1FlexGrid1.SetData(32, 2, "Receipt");
                    c1FlexGrid1.SetData(32, 6, 17);
                    c1FlexGrid1.SetData(32, 7, 3);
                    c1FlexGrid1.SetData(33, 1, "Payment Order Return");
                    c1FlexGrid1.SetData(33, 2, "Receipt");
                    c1FlexGrid1.SetData(33, 6, 20);
                    c1FlexGrid1.SetData(33, 7, 0);
                    c1FlexGrid1.SetData(34, 1, "Discount");
                    c1FlexGrid1.SetData(34, 2, "Receipt");
                    c1FlexGrid1.SetData(34, 6, 20);
                    c1FlexGrid1.SetData(34, 7, 3);
                    c1FlexGrid1.SetData(35, 1, "Production of varieties - Manufacture");
                    c1FlexGrid1.SetData(35, 2, "Receipt");
                    c1FlexGrid1.SetData(35, 6, 16);
                    c1FlexGrid1.SetData(35, 7, 0);
                    c1FlexGrid1.SetData(36, 1, "Discount");
                    c1FlexGrid1.SetData(36, 2, "Receipt");
                    c1FlexGrid1.SetData(36, 6, 16);
                    c1FlexGrid1.SetData(36, 7, 3);
                }
                catch
                {
                }
            }
            CmbCalendar.Items.Clear();
            CmbCalendar.Items.Add((LangArEn == 0) ? "التقويم الميــلادي" : "Gregoian");
            CmbCalendar.Items.Add((LangArEn == 0) ? "التقويم الهجري" : "Hijri");
            CmbCalendar.SelectedIndex = 0;
            comboBox_AutoBackup.Items.Clear();
            comboBox_AutoBackup.Items.Add((LangArEn == 0) ? "كل ربع ساعة" : "Every quarter of an hour");
            comboBox_AutoBackup.Items.Add((LangArEn == 0) ? "كل نصف ساعة" : "Every half-hour");
            comboBox_AutoBackup.Items.Add((LangArEn == 0) ? "كل ساعة" : "Every hour");
            comboBox_AutoBackup.Items.Add((LangArEn == 0) ? "كل يوم" : "Every Day");
            comboBox_AutoBackup.Items.Add((LangArEn == 0) ? "كل يومين" : "Every Tow Day");
            comboBox_AutoBackup.Items.Add((LangArEn == 0) ? "كل ثلاث أيام" : "Every Three Day");
            comboBox_AutoBackup.Items.Add((LangArEn == 0) ? "كل أسبوع" : "Every Week");
            comboBox_AutoBackup.Items.Add((LangArEn == 0) ? "كل أسبوعين" : "Every Tow Week");
            comboBox_AutoBackup.Items.Add((LangArEn == 0) ? "كل شهر" : "Every Month");
            comboBox_AutoBackup.SelectedIndex = 0;
            CmbMail.Items.Clear();
            CmbMail.Items.Add("Hotmail");
            CmbMail.Items.Add("Gmail");
            CmbMail.Items.Add("Yahoo");
            CmbMail.SelectedIndex = 0;
            try
            {
                if (superTabItem_Employee.Visible)
                {
                    List<T_OpMethod> listCalculateNo = new List<T_OpMethod>((from item in db.T_OpMethods
                                                                             orderby item.Method_No
                                                                             where item.Method_No != 1 && item.Method_No != 5 && item.Method_No != 6 && item.Method_No != 7 && item.Method_No != 9 && item.Method_No != 10 && item.Method_No != 10 && item.Method_No != 11 && item.Method_No != 12 && item.Method_No != 13
                                                                             select item).ToList());
                    comboBox_CalculateNo.DataSource = listCalculateNo;
                    comboBox_CalculateNo.DisplayMember = ((LangArEn == 0) ? "Name" : "NameE");
                    comboBox_CalculateNo.ValueMember = "Method_No";
                    List<T_OpMethod> listCalculatliquidNo = new List<T_OpMethod>((from item in db.T_OpMethods
                                                                                  orderby item.Method_No
                                                                                  where item.Method_No != 1 && item.Method_No != 5 && item.Method_No != 6 && item.Method_No != 7 && item.Method_No != 8 && item.Method_No != 9 && item.Method_No != 10 && item.Method_No != 10 && item.Method_No != 11 && item.Method_No != 12 && item.Method_No != 13
                                                                                  select item).ToList());
                    comboBox_CalculatliquidNo.DataSource = listCalculatliquidNo;
                    comboBox_CalculatliquidNo.DisplayMember = ((LangArEn == 0) ? "Name" : "NameE");
                    comboBox_CalculatliquidNo.ValueMember = "Method_No";
                    List<T_OpMethod> listVacTypeNo = new List<T_OpMethod>((from item in db.T_OpMethods
                                                                           orderby item.Method_No
                                                                           where item.Method_No == 3 || item.Method_No == 4 || item.Method_No == 7
                                                                           select item).ToList());
                    comboBox_DisVacationType.DataSource = listVacTypeNo;
                    comboBox_DisVacationType.DisplayMember = ((LangArEn == 0) ? "Name" : "NameE");
                    comboBox_DisVacationType.ValueMember = "Method_No";
                }
            }
            catch
            {
            }
            CmbCurr.SelectedIndex = _CmbIndex;
            RibunButtons();
        }
        private void RibunButtons()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
            {
                ButWithSave.Text = "حفظ";
                ButWithSave.Tooltip = "F2";
                ButWithoutSave.Text = "خروج";
                ButWithoutSave.Tooltip = "Esc";
                label1.Text = "الإسم العربي :";
                label2.Text = "العنوان العربي :";
                label3.Text = "الإسم الإنجليزي :";
                label4.Text = "العنوان الإنجليزي :";
                label5.Text = "تقويم النظام :";
                label6.Text = "التاريخ / ميلادي :";
                label7.Text = "التاريخ / هجري :";
                label8.Text = "سعر التكلفة المعتمدة :";
                label9.Text = "طريقة الدفع المعتمدة :";
                label10.Text = "حساب بضاعة أول المدة";
                label11.Text = "حساب بضاعة أخر المدة";
                label12.Text = "حساب الصنـــــــــدوق";
                label13.Text = "حساب الأرباح والخسائر";
                superTabItem_Banner.Text = "بيانات الشركة";
                //superTabItem_Company.Text = "المنشأة";
                superTabItem_Acc.Text = "اعدادات الحسابات";
                superTabItem_Inv.Text = "الفواتير";
                superTabItem_General.Text = "عــــام";
                groupPanel_Banner.Text = "الشعــار";
                label25.Text = "مسار النسخ الإحتياطــــــي :";
                label24.Text = "خدمة النسخ الإحتياطي الألكتروني :";
                dateTimeInput_DT.ButtonCustom.Text = "تاريخ إنتهاء إشتراكك في الخدمة";
                button_Background.Tooltip = "صورة خلفية النظام";
                button_RemoveBackgroud.Tooltip = "ازالة صورة خلفية النظام";
                groupbox_AutoAcc.Text = "الحسابات التلقائيــة";
                expandablePanel_AutoAcc.TitleText = string.Empty;
                //checkBox_previewPrintRep.Text = "تعيين الإعدادات الإفتراضية";
                //RedButCasherRep.Text = "ورق كاشيير";
                //superTabItem1.Text = "الطابعات";
                superTabItem_Employee.Text = "شؤون الموظفين";
                checkBox_AttendanceManually.Text = "السماح بإدخال وقت الحضور يدويا\u064e";
                checkBox_AutoLeave.Text = "صـــرف الموظفــــين تلقــــائيا بعد ";
                button_DayofMonth.Text = "شهـــــور السنـــة";
                button_DocPath.Tooltip = "إستعراض";
                expandablePanel_Alarm.TitleText = "التنبيهــــــات";
                expandablePanel_NewColumn.TitleText = "خيارات إضافة عمود للفواتير";
                node1.Text = "فاتورة مبيعات";
                chk1Show.Text = "شاشة العرض";
                chk1Print.Text = "طباعة التقرير";
                node2.Text = "مرتجع مبيعات";
                chk2Show.Text = "شاشة العرض";
                chk2Print.Text = "طباعة التقرير";
                node3.Text = "فاتورة مشتريات";
                chk3Show.Text = "شاشة العرض";
                chk3Print.Text = "طباعة التقرير";
                node4.Text = "مرتجع مشتريات";
                chk4Show.Text = "شاشة العرض";
                chk4Print.Text = "طباعة التقرير";
                node5.Text = "عرض سعر للعملاء";
                chk5Show.Text = "شاشة العرض";
                chk5Print.Text = "طباعة التقرير";
                node6.Text = "عرض سعر للموردين";
                chk6Show.Text = "شاشة العرض";
                chk6Print.Text = "طباعة التقرير";
                node7.Text = "طلب شراء";
                chk7Show.Text = "شاشة العرض";
                chk7Print.Text = "طباعة التقرير";
                node8.Text = "بضاعة أول المدة";
                chk8Show.Text = "شاشة العرض";
                chk8Print.Text = "طباعة التقرير";
                node9.Text = "إدخال بضاعة";
                chk9Show.Text = "شاشة العرض";
                chk9Print.Text = "طباعة التقرير";
                node10.Text = "إخراج بضاعة";
                chk10Show.Text = "شاشة العرض";
                chk10Print.Text = "طباعة التقرير";
                node11.Text = "صرف بضاعة";
                chk11Show.Text = "شاشة العرض";
                chk11Print.Text = "طباعة التقرير";
                node12.Text = "مرتجع صرف بضاعة";
                chk12Show.Text = "شاشة العرض";
                chk12Print.Text = "طباعة التقرير";
                node13.Text = "تسوية البضاعة";
                chk13Show.Text = "شاشة العرض";
                chk13Print.Text = "طباعة التقرير";
                node14.Text = "شاشة نقـاط البيـع";
                chk14Show.Text = "شاشة العرض";
                chk14Print.Text = "طباعة التقرير";
                chk37.OffText = "المزامنة بشكل تلقائي";
                chk37.OnText = "المزامنة بشكل تلقائي";
                button_ManageRoom.Text = "إدارة الغرف / الشقق في الطوابق";
                superTabItem_Eqar.Text = "خيارات العقار";
                Text = "تهيئة النظام";
            }
            else
            {
                ButWithSave.Text = "Save";
                ButWithoutSave.Text = "Exit";
                ButWithSave.Tooltip = "F2";
                ButWithoutSave.Tooltip = "Esc";
                label1.Text = "Arabic Name :";
                label2.Text = "Arabic Address :";
                label3.Text = "English Name :";
                label4.Text = "English Address :";
                label5.Text = "Calendar system :";
                label6.Text = "Date / Gregorian :";
                label7.Text = "Date / Hijri :";
                label8.Text = "Approved cost price :";
                label9.Text = "Approved payment method :";
                label10.Text = "first-term stock account";
                label11.Text = "last-term stock account";
                label12.Text = "Box Account";
                label13.Text = "Profit and loss account";
                superTabItem_Banner.Text = "Banner Data";
                //superTabItem_Company.Text = "Company";
                superTabItem_Acc.Text = "Accounting";
                superTabItem_Inv.Text = "Invoices";
                superTabItem_General.Text = "General";
                groupPanel_Banner.Text = "Banner";
                label25.Text = "Backup Path :";
                label24.Text = "Electronic Backup Service:";
                dateTimeInput_DT.ButtonCustom.Text = "Service End Date";
                button_Background.Tooltip = "Backgroud Image";
                button_RemoveBackgroud.Tooltip = "Remove Background Image";
                groupbox_AutoAcc.Text = "Auto Accounts";
                expandablePanel_AutoAcc.TitleText = string.Empty;
                //checkBox_previewPrintRep.Text = "Defualt Setting";
                //RedButPaperA4Rep.Text = "A4 Peaper";
                //RedButCasherRep.Text = "Cashier Peaper";
                //superTabItem1.Text = "Printers";
                superTabItem_Employee.Text = "Employee";
                checkBox_AttendanceManually.Text = "Allow the introduction of time attendance manually";
                checkBox_AutoLeave.Text = "Staff exchange automatically after";
                button_DayofMonth.Text = "Months of the year";
                button_DocPath.Tooltip = "Browser";
                expandablePanel_Alarm.TitleText = "Alerts";
                expandablePanel_NewColumn.TitleText = "New Column In Invoices Options";
                node1.Text = "Sales invoice";
                chk1Show.Text = "Show Form";
                chk1Print.Text = "Print Report";
                node2.Text = "Returned sales invoice";
                chk2Show.Text = "Show Form";
                chk2Print.Text = "Print Report";
                node3.Text = "Purchases invoice";
                chk3Show.Text = "Show Form";
                chk3Print.Text = "Print Report";
                node4.Text = "Returned Purchases invoice";
                chk4Show.Text = "Show Form";
                chk4Print.Text = "Print Report";
                node5.Text = "Quote clients";
                chk5Show.Text = "Show Form";
                chk5Print.Text = "Print Report";
                node6.Text = "Quote suppliers";
                chk6Show.Text = "Show Form";
                chk6Print.Text = "Print Report";
                node7.Text = "Purchase Order";
                chk7Show.Text = "Show Form";
                chk7Print.Text = "Print Report";
                node8.Text = "Quantitative opening";
                chk8Show.Text = "Show Form";
                chk8Print.Text = "Print Report";
                node9.Text = "The introduction of goods";
                chk9Show.Text = "Show Form";
                chk9Print.Text = "Print Report";
                node10.Text = "Directed by goods";
                chk10Show.Text = "Show Form";
                chk10Print.Text = "Print Report";
                node11.Text = "Exchange of goods";
                chk11Show.Text = "Show Form";
                chk11Print.Text = "Print Report";
                node12.Text = "Returned Exchange of goods";
                chk12Show.Text = "Show Form";
                chk12Print.Text = "Print Report";
                node13.Text = "Settlement goods";
                chk13Show.Text = "Show Form";
                chk13Print.Text = "Print Report";
                node14.Text = "POS Form";
                chk14Show.Text = "Show Form";
                chk14Print.Text = "Print Report";
                chk37.OffText = "Synchronize data Automatically";
                chk37.OnText = "Synchronize data Automatically";
                superTabItem_Eqar.Text = "Real Estate";
                superTabItem_Hotel.Text = "Hotel Options";
                label60.Text = "Number of floors in the hotel";
                label59.Text = "Floor";
                label61.Text = "Number of rooms in the floor";
                label62.Text = "Room";
                label63.Text = "Grace period";
                label64.Text = "Departure Period";
                label65.Text = "Days Of Month";
                label66.Text = "Day";
                label67.Text = "Distance the area of the boxes of rooms";
                label68.Text = "linear";
                label69.Text = "Point";
                label70.Text = "accidental";
                label71.Text = "Point";
                label80.Text = "Color Options Boxes Rooms";
                txtREmpty.Text = "Empty";
                txtRAvailable.Text = "Available";
                txtRBussyDaily.Text = "Bussy Daily";
                txtRBussyAppendix.Text = "Bussy Appendix";
                txtRClean.Text = "Cleaning";
                txtRRepair.Text = "Maintenance";
                txtRBussyMonthly.Text = "Bussy Monthly";
                txtRLeave.Text = "Departure";
                button_F1.Tooltip = "Font Color";
                button_F2.Tooltip = "Font Color";
                button_F3.Tooltip = "Font Color";
                button_F4.Tooltip = "Font Color";
                button_F5.Tooltip = "Font Color";
                button_F6.Tooltip = "Font Color";
                button_F7.Tooltip = "Font Color";
                button_F8.Tooltip = "Font Color";
                button_B1.Tooltip = "Background Color";
                button_B2.Tooltip = "Background Color";
                button_B3.Tooltip = "Background Color";
                button_B4.Tooltip = "Background Color";
                button_B5.Tooltip = "Background Color";
                button_B6.Tooltip = "Background Color";
                button_B7.Tooltip = "Background Color";
                button_B8.Tooltip = "Background Color";
                button_ManageRoom.Text = "Management of rooms / apartments on floors";
                Text = "System Settings";
            }
        }
        void setbilloption(int r, bool t)
        {
            c1FlexGrid2.SetData(r, 2, t);
        }
        char getbool(int i)
        {
            bool c = (bool)c1FlexGrid2.GetData(i, 2);
            if (c == true)
                return '1';
            else
                return '0';
        }
        void filloptions()
        {
            // c1FlexGrid2.SetData(1, 0, "ظهور الخصم عند اصدار الفاتورة");
            c1FlexGrid2.SetData(1, 1, "ظهور الخصم عند اصدار الفاتورة");
            c1FlexGrid2.SetData(2, 1, "اختيار المندوب في فاتورة المبيعات");
            c1FlexGrid2.SetData(3, 1, "إضهار تاريخ صلاحية الصنف عند طباعة الفواتير ");
            c1FlexGrid2.SetData(4, 1, "إضهار رقم تصنيع الصنف عند طباعة الفواتير");
            c1FlexGrid2.SetData(5, 1, "تحويل تكلفة الصنف الى سعر العملة الإفتراضيه");
            c1FlexGrid2.SetData(6, 1, "إظهار الوصف العكسي عرب / انج لفواتير الكاشير");
            c1FlexGrid2.SetData(7, 1, "دمج الإصناف المكرره تلقائيا في الفاتورة");
            c1FlexGrid2.SetData(8, 1, "إضهار اعدادات الطباعه عند طباعه الباركود");
            c1FlexGrid2.SetData(9, 1, "إيقاف مزامنه التاريخ للويندوز");
            c1FlexGrid2.SetData(10, 1, "طباعة الباركود في الفاتورة حسب الكمية");
            c1FlexGrid2.SetData(11, 1, "إختيار العميل في فاتورة المبيعات");
            c1FlexGrid2.SetData(12, 1, "تمكين نوع الفاتورة الآجلة لنقاط البيع");
            c1FlexGrid2.SetData(13, 1, "رسالة بإعادة تسلسل الفواتير عند ترحيل الصندوق");
            c1FlexGrid2.SetData(14, 1, "إعتماد تصميم الشاشه المكبرة للفاتورة المبيعات");
            c1FlexGrid2.SetData(15, 1, "إظهار جميع الحسابات المالية في الفواتير ");
            c1FlexGrid2.SetData(16, 1, "ظهور العملاء في فواتير الشراء");
            c1FlexGrid2.SetData(17, 1, "ظهور الموردين في فواتير البيع");
            c1FlexGrid2.SetData(18, 1, "السماح بالكميات الغير صحيحة (الكسرية ) في الفواتير");
            c1FlexGrid2.SetData(19, 1, "إظهار رقم سيريال الصنف في الفواتير");
            c1FlexGrid2.SetData(20, 1, "ظهور محتويات الصنف التجميعي في التقرير");
            c1FlexGrid2.SetData(21, 1, "ظهور رقم المستودع في تقرير الفواتير");
            c1FlexGrid2.SetData(22, 1, "إعتماد شاشه البحث السريع في الفواتير");
            c1FlexGrid2.SetData(23, 1, "إظهار ازرار إدراج الأصناف في فواتير الجرد");
            c1FlexGrid2.SetData(24, 1, "إظهار شاشة المدفوعات في المبيعات");
            c1FlexGrid2.SetData(25, 1, "رسالة نصية للعميل بعد البيع");
            c1FlexGrid2.SetData(26, 1, "اصدار فاتورة ادخال بضاعة بعد اخراج البضاعة تلقائيا");
            c1FlexGrid2.SetData(27, 1, "إظهار رسالة الطباعة عند حفظ فاتورة المشتريات");
            c1FlexGrid2.SetData(28, 1, "سعر اخر صرف للمندوب من الوحدة 1 للصنف");
            c1FlexGrid2.SetData(29, 1, "إخفاء كامل لجميع خيارات نقاط العملاء");
            c1FlexGrid2.SetData(30, 1, "إعتماد الحجم القياسي لشاشه نقاط البيع");
            c1FlexGrid2.SetData(31, 1, "تمكين الإضافة التلقائية لفاتورة المبيعات - الباركود");
            c1FlexGrid2.SetData(32, 1, "إظهار التكلفة الإضافيه عند اصدار فاتورة مشتريات");
            c1FlexGrid2.SetData(33, 1, "إعتماد شاشه نقاط البيع لفاتورة اللمبيعات");
            c1FlexGrid2.SetData(34, 1, "طباعة التصنيفات حسب اسم الطابعة");
            c1FlexGrid2.SetData(35, 1, "السماح باصدار فاتورة محلية بدون طاولة");
            c1FlexGrid2.SetData(36, 1, "إفراغ الطاولة عند استخدام طلب محلي");
            c1FlexGrid2.SetData(37, 1, "جبر إجمالي الفواتير الكسرية");
            c1FlexGrid2.SetData(38, 1, "جمع خصم السطور وقيمة خصم الفاتورة");
            c1FlexGrid2.SetData(39, 1, "إعتماد سعر اخر بيع حسب العميل في المبيعات");
            c1FlexGrid2.SetData(40, 1, "إعتماد سعر البيع مع الضريبة عند طباعة الباركود");
            c1FlexGrid2.SetData(41, 1, "جبر سعر البيع بعد إضافة الضريبه عند طباعة الباركود");
            c1FlexGrid2.SetData(42, 1, "احتساب الربح في المبيعات مع الضريبة");
            c1FlexGrid2.SetData(43, 1, "إخفاء سطور قيمة الضريبة في الفواتير");

            c1FlexGrid2.SetData(44, 1, "إظهار اجمالي الفاتوره مع الضريبة عند الطباعة");
            c1FlexGrid2.SetData(45, 1, "إظهار شاشة الضافات الخاصة تلقائيا");
            c1FlexGrid2.SetData(46, 1, "إضهار زر الاضافات الخاصه مع ملاحظات الفاتوره");
            c1FlexGrid2.SetData(47, 1, "منع إدخال المدفوع بمبلغ اقل من المدفوع نقدا");
            c1FlexGrid2.SetData(48, 1, "إخفاء قائمة الأسعار في البيعات والمشتريات");
            c1FlexGrid2.SetData(49, 1, "إخفاء ايقونات الاصناف والتصنيفات في نقاط البيع");
            c1FlexGrid2.SetData(50, 1, "تشغيل الشاشات الفرعية لقراءة باركود الأصناف");
            c1FlexGrid2.SetData(51, 1, "إعتماد شاشة المبيعات الداخلية لنقاط البيع ");
            c1FlexGrid2.SetData(52, 1, "تفعيل خيار النقاط في المبيعات");
            c1FlexGrid2.SetData(53, 1, "تحكم يدوي للتواريخ الهجرية والميلادية في الفواتير");
            c1FlexGrid2.SetData(54, 1, "عرض قائمة بتواريخ الصلاحية للصنف عند قراءة الباركود");
            c1FlexGrid2.SetData(55, 1, "طباعة رقم الطلب");
            c1FlexGrid2.SetData(56, 1, "ايقاف طباعة التصنيفات للطلب المحلي في شاشة نقاط البيع ");
            c1FlexGrid2.SetData(57, 1, "الافتراضي السعر شامل الضريبه ");
            c1FlexGrid2.SetData(58, 1, "تصفير الكميات في فاتورة مرتجع مبيعات عند ارجاع فاتورة مبيعات  ");
            c1FlexGrid2.SetData(59, 1, "اخفاء تمت الموافقة  ");

            //c1FlexGrid2.SetData(59, 1, "");
            //c1FlexGrid2.SetData(60, 1, "");
            //c1FlexGrid2.SetData(61, 1, "");
            //c1FlexGrid2.SetData(62, 1, "");
            if (nn.Count == 0) optionflag = 1;
            setbilloption(1, VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 8));
            setbilloption(2, VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 7));
            setbilloption(3, VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 19));
            setbilloption(4, VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 21));
            setbilloption(5, VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 45));
            setbilloption(6, VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 29));
            setbilloption(7, VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 17));
            setbilloption(8, VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 55));
            setbilloption(9, VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 53));
            setbilloption(10, VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 32));
            setbilloption(11, VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 38));
            setbilloption(12, VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 25));
            setbilloption(13, VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 35));
            setbilloption(14, VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 37));
            setbilloption(15, VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 6));
            setbilloption(16, VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 5));
            setbilloption(17, VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 4));
            setbilloption(18, VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 3));
            setbilloption(19, VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 20));
            setbilloption(20, VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 15));
            setbilloption(21, VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 16));
            setbilloption(22, VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 30));
            setbilloption(23, VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 24));
            setbilloption(24, VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 42));
            setbilloption(25, VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 39));
            setbilloption(26, VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 52));
            setbilloption(27, VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 51));
            setbilloption(28, VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 61));
            setbilloption(29, VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 75));
            setbilloption(30, VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 27));
            setbilloption(31, VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 14));
            setbilloption(32, VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 18));
            setbilloption(33, VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 26));
            setbilloption(34, VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 33));
            setbilloption(35, VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 36));
            setbilloption(36, VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 44));
            setbilloption(37, VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 56));
            setbilloption(38, VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 57));
            setbilloption(39, VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 58));
            setbilloption(40, VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 60));
            setbilloption(41, VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 78));
            setbilloption(42, VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 62));
            setbilloption(43, VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 64));
            setbilloption(44, VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 65));
            setbilloption(45, VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 66));
            setbilloption(46, VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 67));
            setbilloption(47, VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 68));
            setbilloption(48, VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 71));
            setbilloption(49, VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 72));
            setbilloption(50, VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 73));
            setbilloption(51, VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 22));
            setbilloption(52, VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 69));
            setbilloption(53, VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 77));
            setbilloption(54, VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 80));
            setbilloption(55, VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 54));
            setbilloption(56, VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 79));
            setbilloption(57, VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 83));
            setbilloption(58, VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 84));
            setbilloption(59, VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 85));
            optionflag = 0;
        }
        public class ColumnDictinaryBankopp
        {
            public string AText = string.Empty;
            public string EText = string.Empty;
            public bool IfDefault = false;
            public string Format = string.Empty;
            public ColumnDictinaryBankopp(string aText, string eText, bool ifDefault, string format)
            {
                AText = aText;
                EText = eText;
                IfDefault = ifDefault;
                Format = format;
            }
        }
        void loadBankop()
        {
            try
            {
                //   ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmCommOpiton));
                //if (VarGeneral.CurrentLang.ToString() == "0"||VarGeneral.CurrentLang.ToString() == "")
                //   {
                //       Language.ChangeLanguage("ar-SA", this, resources);
                //       LangArEn = 0;
                //   }
                //   else
                //   {
                //       Language.ChangeLanguage("en", this, resources);
                //       LangArEn = 1;
                //   }
                //  RibunButtonsBankopp();
                listInvSettingBankopp = db.StockInvSettingList(VarGeneral.UserID);
                _InvSettingBankopp = listInvSettingBankopp[0];
                _SysSettingBankopp = db.SystemSettingStock();
                listCompanyBankopp = db.StockCompanyList();
                _CompanyBankopp = listCompanyBankopp[0];
                _GdAutoBankopp = db.GdAutoStock();
                listInfotbBankopp = db.StockInfoList();
                _InfotbBankopp = listInfotbBankopp[0];
                listAccDefBankopp = db.FillAccDef_2(string.Empty).ToList();
                listAccDefBankopp = listAccDefBankopp.Where((T_AccDef q) => q.Trn == 3 && q.Lev == 4 && q.AccDef_No.StartsWith("1") && q.AccCat != 2 && q.AccCat != 3).ToList();
                try
                {
                    FillComboBankopp();
                }
                catch
                {
                }
                try
                {
                    BindDataBankopp();
                }
                catch
                {
                }
                if (VarGeneral.SSSTyp == 0)
                {
                    c1FlexGrid1Bankopp.Cols[9].Visible = false;
                    c1FlexGrid1Bankopp.Cols[10].Visible = false;
                    c1FlexGrid1Bankopp.Cols[11].Visible = false;
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Load:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void RibunButtonsBankopp()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
            {
                ButWithSave.Text = "حفظ";
                ButWithSave.Tooltip = "F2";
                ButWithoutSave.Text = "خروج";
                ButWithoutSave.Tooltip = "Esc";
                Text = "خيارات العمولات البنكية";
            }
            else
            {
                ButWithSave.Text = "Save";
                ButWithoutSave.Text = "Exit";
                ButWithSave.Tooltip = "F2";
                ButWithoutSave.Tooltip = "Esc";
                Text = "Taxes Options";
            }
        }
        private void FillComboBankopp()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
            {
                try
                {
                    c1FlexGrid1Bankopp.SetData(0, 1, "الفاتورة");
                    c1FlexGrid1Bankopp.SetData(0, 2, "إحتســــاب");
                    c1FlexGrid1Bankopp.SetData(0, 9, "حساب المدين");
                    c1FlexGrid1Bankopp.SetData(0, 10, "حساب الدائن");
                    c1FlexGrid1Bankopp.SetData(0, 11, "قيد محاسبي");
                    c1FlexGrid1Bankopp.SetData(1, 1, "فاتورة مبيعات");
                    c1FlexGrid1Bankopp.SetData(1, 6, 1);
                    c1FlexGrid1Bankopp.SetData(1, 7, 0);
                    c1FlexGrid1Bankopp.SetData(2, 1, "فاتورة مشتريات");
                    c1FlexGrid1Bankopp.SetData(2, 6, 2);
                    c1FlexGrid1Bankopp.SetData(2, 7, 0);
                    c1FlexGrid1Bankopp.SetData(3, 1, "مرتجع مبيعات");
                    c1FlexGrid1Bankopp.SetData(3, 6, 3);
                    c1FlexGrid1Bankopp.SetData(3, 7, 0);
                    c1FlexGrid1Bankopp.Rows[3].Visible = false;
                    c1FlexGrid1Bankopp.SetData(4, 1, "مرتجع مشتريات");
                    c1FlexGrid1Bankopp.SetData(4, 6, 4);
                    c1FlexGrid1Bankopp.SetData(4, 7, 0);
                    c1FlexGrid1Bankopp.Rows[4].Visible = false;
                    c1FlexGrid1Bankopp.SetData(5, 1, "سند أدخال بضاعة");
                    c1FlexGrid1Bankopp.SetData(5, 6, 5);
                    c1FlexGrid1Bankopp.SetData(5, 7, 0);
                    c1FlexGrid1Bankopp.Rows[5].Visible = false;
                    c1FlexGrid1Bankopp.SetData(6, 1, "سند أخراج بضاعة");
                    c1FlexGrid1Bankopp.SetData(6, 6, 6);
                    c1FlexGrid1Bankopp.SetData(6, 7, 0);
                    c1FlexGrid1Bankopp.Rows[6].Visible = false;
                    c1FlexGrid1Bankopp.SetData(7, 1, "عرض سعر عملاء");
                    c1FlexGrid1Bankopp.SetData(7, 6, 7);
                    c1FlexGrid1Bankopp.SetData(7, 7, 0);
                    c1FlexGrid1Bankopp.Rows[7].Visible = false;
                    c1FlexGrid1Bankopp.SetData(8, 1, "عرض سعر مورد");
                    c1FlexGrid1Bankopp.SetData(8, 6, 8);
                    c1FlexGrid1Bankopp.SetData(8, 7, 0);
                    c1FlexGrid1Bankopp.Rows[8].Visible = false;
                    c1FlexGrid1Bankopp.SetData(9, 1, "طلب شراء");
                    c1FlexGrid1Bankopp.SetData(9, 6, 9);
                    c1FlexGrid1Bankopp.SetData(9, 7, 0);
                    c1FlexGrid1Bankopp.Rows[9].Visible = false;
                    c1FlexGrid1Bankopp.SetData(10, 1, "سند تسوية بضاعة");
                    c1FlexGrid1Bankopp.SetData(10, 6, 10);
                    c1FlexGrid1Bankopp.SetData(10, 7, 0);
                    c1FlexGrid1Bankopp.Rows[10].Visible = false;
                    c1FlexGrid1Bankopp.SetData(11, 1, "بضاعة اول المدة");
                    c1FlexGrid1Bankopp.SetData(11, 6, 14);
                    c1FlexGrid1Bankopp.SetData(11, 7, 0);
                    c1FlexGrid1Bankopp.Rows[11].Visible = false;
                    c1FlexGrid1Bankopp.SetData(12, 1, "أمر صرف بضاعة");
                    c1FlexGrid1Bankopp.SetData(12, 6, 17);
                    c1FlexGrid1Bankopp.SetData(12, 7, 0);
                    c1FlexGrid1Bankopp.Rows[12].Visible = false;
                    c1FlexGrid1Bankopp.SetData(13, 1, "مرتجع صرف بضاعة");
                    c1FlexGrid1Bankopp.SetData(13, 6, 20);
                    c1FlexGrid1Bankopp.SetData(13, 7, 0);
                    c1FlexGrid1Bankopp.Rows[13].Visible = false;
                    c1FlexGrid1Bankopp.SetData(14, 1, "إنتاج الأصناف - تصنيع");
                    c1FlexGrid1Bankopp.SetData(14, 6, 16);
                    c1FlexGrid1Bankopp.SetData(14, 7, 0);
                    c1FlexGrid1Bankopp.Rows[14].Visible = false;
                }
                catch
                {
                }
                return;
            }
            try
            {
                c1FlexGrid1Bankopp.SetData(0, 1, "Invoice");
                c1FlexGrid1Bankopp.SetData(0, 2, "Issuance");
                c1FlexGrid1Bankopp.SetData(0, 3, "Print");
                c1FlexGrid1Bankopp.SetData(0, 4, "Sales Tax");
                c1FlexGrid1Bankopp.SetData(0, 5, "Purchaes Tax");
                c1FlexGrid1Bankopp.SetData(0, 9, "Debitor Acc");
                c1FlexGrid1Bankopp.SetData(0, 10, "Creditor Acc");
                c1FlexGrid1Bankopp.SetData(0, 11, "Create Gaid");
                c1FlexGrid1Bankopp.SetData(1, 1, "Sales Invoice");
                c1FlexGrid1Bankopp.SetData(1, 6, 1);
                c1FlexGrid1Bankopp.SetData(1, 7, 0);
                c1FlexGrid1Bankopp.SetData(2, 1, "Purchase Receipt");
                c1FlexGrid1Bankopp.SetData(2, 6, 2);
                c1FlexGrid1Bankopp.SetData(2, 7, 0);
                c1FlexGrid1Bankopp.SetData(3, 1, "Sales Return");
                c1FlexGrid1Bankopp.SetData(3, 6, 3);
                c1FlexGrid1Bankopp.SetData(3, 7, 0);
                c1FlexGrid1Bankopp.Rows[3].Visible = false;
                c1FlexGrid1Bankopp.SetData(4, 1, "Purchase Return");
                c1FlexGrid1Bankopp.SetData(4, 6, 4);
                c1FlexGrid1Bankopp.SetData(4, 7, 0);
                c1FlexGrid1Bankopp.Rows[4].Visible = false;
                c1FlexGrid1Bankopp.SetData(5, 1, "Transfer In");
                c1FlexGrid1Bankopp.SetData(5, 6, 5);
                c1FlexGrid1Bankopp.SetData(5, 7, 0);
                c1FlexGrid1Bankopp.Rows[5].Visible = false;
                c1FlexGrid1Bankopp.SetData(6, 1, "Transfer Out");
                c1FlexGrid1Bankopp.SetData(6, 6, 6);
                c1FlexGrid1Bankopp.SetData(6, 7, 0);
                c1FlexGrid1Bankopp.Rows[6].Visible = false;
                c1FlexGrid1Bankopp.SetData(7, 1, "Customer Qutation");
                c1FlexGrid1Bankopp.SetData(7, 6, 7);
                c1FlexGrid1Bankopp.SetData(7, 7, 0);
                c1FlexGrid1Bankopp.Rows[7].Visible = false;
                c1FlexGrid1Bankopp.SetData(8, 1, "Supplier Qutation");
                c1FlexGrid1Bankopp.SetData(8, 6, 8);
                c1FlexGrid1Bankopp.SetData(8, 7, 0);
                c1FlexGrid1Bankopp.Rows[8].Visible = false;
                c1FlexGrid1Bankopp.SetData(9, 1, "Purchase Order");
                c1FlexGrid1Bankopp.SetData(9, 6, 9);
                c1FlexGrid1Bankopp.SetData(9, 7, 0);
                c1FlexGrid1Bankopp.Rows[9].Visible = false;
                c1FlexGrid1Bankopp.SetData(10, 1, "Stock Adjustment");
                c1FlexGrid1Bankopp.SetData(10, 6, 10);
                c1FlexGrid1Bankopp.SetData(10, 7, 0);
                c1FlexGrid1Bankopp.Rows[10].Visible = false;
                c1FlexGrid1Bankopp.SetData(11, 1, "Open Quantities");
                c1FlexGrid1Bankopp.SetData(11, 6, 14);
                c1FlexGrid1Bankopp.SetData(11, 7, 0);
                c1FlexGrid1Bankopp.Rows[11].Visible = false;
                c1FlexGrid1Bankopp.SetData(12, 1, "Payment Order");
                c1FlexGrid1Bankopp.SetData(12, 6, 17);
                c1FlexGrid1Bankopp.SetData(12, 7, 0);
                c1FlexGrid1Bankopp.Rows[12].Visible = false;
                c1FlexGrid1Bankopp.SetData(13, 1, "Payment Order Return");
                c1FlexGrid1Bankopp.SetData(13, 6, 20);
                c1FlexGrid1Bankopp.SetData(13, 7, 0);
                c1FlexGrid1Bankopp.Rows[13].Visible = false;
                c1FlexGrid1Bankopp.SetData(14, 1, "Production of varieties - Manufacture");
                c1FlexGrid1Bankopp.SetData(14, 6, 16);
                c1FlexGrid1Bankopp.SetData(14, 7, 0);
                c1FlexGrid1Bankopp.Rows[14].Visible = false;
            }
            catch
            {
            }
        }
        private void SaveDataBankopp()
        {
            try
            {
                for (int iiCnt = 1; iiCnt < c1FlexGrid1Bankopp.Rows.Count; iiCnt++)
                {
                    for (int i = 0; i < listInvSettingBankopp.Count; i++)
                    {
                        _InvSettingBankopp = listInvSettingBankopp[i];
                        if (_InvSettingBankopp.InvID == int.Parse(c1FlexGrid1Bankopp.GetData(iiCnt, 6).ToString()))
                        {
                            _InvSettingBankopp.CommOptions = VarGeneral.TString.ChkStatSave((bool)c1FlexGrid1Bankopp.GetData(iiCnt, 2)) + VarGeneral.TString.ChkStatSave((bool)c1FlexGrid1Bankopp.GetData(iiCnt, 3));
                            try
                            {
                                _InvSettingBankopp.CommDebit = c1FlexGrid1Bankopp.GetData(iiCnt, 9).ToString();
                            }
                            catch
                            {
                                _InvSettingBankopp.CommDebit = "***";
                            }
                            try
                            {
                                _InvSettingBankopp.CommCredit = c1FlexGrid1Bankopp.GetData(iiCnt, 10).ToString();
                            }
                            catch
                            {
                                _InvSettingBankopp.CommCredit = "***";
                            }
                            _InvSettingBankopp.autoCommGaid = Convert.ToBoolean(c1FlexGrid1Bankopp.GetData(iiCnt, 11));
                            db.Log = VarGeneral.DebugLog;
                            db.SubmitChanges(ConflictMode.ContinueOnConflict);
                            break;
                        }
                    }
                }
                //MessageBox.Show((LangArEn == 0) ? "لقد تم اتمام العملية بنجاح .." : "This Opration Is Done", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                Close();
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Save:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void BindDataBankopp()
        {
            try
            {
                State = FormState.Saved;
                ButWithSave.Enabled = false;
                for (int iiCnt = 1; iiCnt < c1FlexGrid1Bankopp.Rows.Count; iiCnt++)
                {
                    for (int i = 0; i < listInvSettingBankopp.Count; i++)
                    {
                        _InvSettingBankopp = listInvSettingBankopp[i];
                        if (_InvSettingBankopp.InvID == int.Parse(c1FlexGrid1Bankopp.GetData(iiCnt, 6).ToString()))
                        {
                            c1FlexGrid1Bankopp.SetData(iiCnt, 2, VarGeneral.TString.ChkStatShow(_InvSettingBankopp.CommOptions, 0));
                            c1FlexGrid1Bankopp.SetData(iiCnt, 3, VarGeneral.TString.ChkStatShow(_InvSettingBankopp.CommOptions, 1));
                            c1FlexGrid1Bankopp.SetData(iiCnt, 9, _InvSettingBankopp.CommDebit);
                            c1FlexGrid1Bankopp.SetData(iiCnt, 10, _InvSettingBankopp.CommCredit);
                            c1FlexGrid1Bankopp.SetData(iiCnt, 11, _InvSettingBankopp.autoCommGaid);
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public Dictionary<string, ColumnDictinaryBankopp> columns_Names_visibleBankopp = new Dictionary<string, ColumnDictinaryBankopp>();
        private List<T_INVSETTING> listInvSettingBankopp = new List<T_INVSETTING>();
        private T_INVSETTING _InvSettingBankopp = new T_INVSETTING();
        private List<T_SYSSETTING> listSysSettingBankopp = new List<T_SYSSETTING>();
        private T_SYSSETTING _SysSettingBankopp = new T_SYSSETTING();
        private List<T_AccDef> listAccDefBankopp = new List<T_AccDef>();
        private T_AccDef _AccDefBankopp = new T_AccDef();
        private List<T_Company> listCompanyBankopp = new List<T_Company>();
        private T_Company _CompanyBankopp = new T_Company();
        private List<T_GdAuto> listGdAutoBankopp = new List<T_GdAuto>();
        private T_GdAuto _GdAutoBankopp = new T_GdAuto();
        private List<T_InfoTb> listInfotbBankopp = new List<T_InfoTb>();
        private T_InfoTb _InfotbBankopp = new T_InfoTb();
        public Dictionary<string, ColumnDictinaryCusDis> columns_Names_visibleCustDis = new Dictionary<string, ColumnDictinaryCusDis>();
        private List<T_INVSETTING> listInvSettingCustDis = new List<T_INVSETTING>();
        private T_INVSETTING _InvSettingCustDis = new T_INVSETTING();
        private List<T_SYSSETTING> listSysSettingCustDis = new List<T_SYSSETTING>();
        private T_SYSSETTING _SysSettingCustDis = new T_SYSSETTING();
        private void RibunButtonsCustDis()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
            {
                ButWithSave.Text = "حفظ";
                ButWithSave.Tooltip = "F2";
                ButWithoutSave.Text = "خروج";
                ButWithoutSave.Tooltip = "Esc";
                chkIsActive.Text = "تفعيل شاشة الــزبــون";
                groupPanel1CustDis.Text = "التــوقـف";
                groupPanel2CustDis.Text = "البيــانات";
                groupPanel3CustDis.Text = "التمـــاثل";
                chkSync1.Text = "فردي";
                chkSync2.Text = "زوجي";
                chkSync3.Text = "بلا";
                chkSync4.Text = "علامة";
                chkSync5.Text = "مسافة";
                button_CheckConn.Text = "إختبــــار";
                Text = "شـاشـة الــزيــون";
            }
            else
            {
                ButWithSave.Text = "Save";
                ButWithoutSave.Text = "Exit";
                ButWithSave.Tooltip = "F2";
                ButWithoutSave.Tooltip = "Esc";
                chkIsActive.Text = "Custome Display Active";
                groupPanel1CustDis.Text = "Bit Stop";
                groupPanel2CustDis.Text = "Bit Data";
                groupPanel3CustDis.Text = "Parity";
                chkSync1.Text = "Single";
                chkSync2.Text = "Double";
                chkSync3.Text = "None";
                chkSync4.Text = "sign";
                chkSync5.Text = "Space";
                button_CheckConn.Text = "Check";
                Text = "Customer Display";
            }
        }
        private void FillComboCustDis()
        {
            cmbPort.Items.Clear();
            cmbPort.Items.Add("COM1");
            cmbPort.Items.Add("COM2");
            cmbPort.Items.Add("COM3");
            cmbPort.Items.Add("COM4");
            cmbPort.Items.Add("COM5");
            cmbPort.Items.Add("COM6");
            cmbPort.Items.Add("COM7");
            cmbPort.Items.Add("COM8");
            cmbPort.Items.Add("COM9");
            cmbPort.Items.Add("COM10");
            cmbPort.Items.Add("COM11");
            cmbPort.Items.Add("COM12");
            cmbPort.Items.Add("COM13");
            cmbPort.Items.Add("COM14");
            cmbPort.Items.Add("COM15");
            cmbPort.Items.Add("USB");
            cmbPort.Items.Add("USB1");
            cmbPort.Items.Add("USB2");
            cmbPort.Items.Add("USB3");
            cmbPort.Items.Add("USB4");
            cmbPort.Items.Add("USB5");
            cmbPort.Items.Add("USB6");
            cmbPort.SelectedIndex = 0;
            cmbFast.Items.Clear();
            cmbFast.Items.Add("110");
            cmbFast.Items.Add("300");
            cmbFast.Items.Add("600");
            cmbFast.Items.Add("1200");
            cmbFast.Items.Add("2400");
            cmbFast.Items.Add("9600");
            cmbFast.Items.Add("14400");
            cmbFast.Items.Add("19200");
            cmbFast.Items.Add("28800");
            cmbFast.Items.Add("38400");
            cmbFast.Items.Add("56000");
            cmbFast.Items.Add("128000");
            cmbFast.Items.Add("256000");
            cmbFast.SelectedIndex = 0;
            cmbShowState.Items.Clear();
            cmbShowState.Items.Add((LangArEn == 0) ? "الكـــــــل" : "ALL");
            cmbShowState.Items.Add((LangArEn == 0) ? "السعــر فقط" : "Only Price");
            cmbShowState.Items.Add((LangArEn == 0) ? "الإجمالي فقط" : "Only Total");
            cmbShowState.SelectedIndex = 0;
        }
        private void BindDataCustDis()
        {
            chkIsActive.CheckedChanged -= chkIsActive_CheckedChanged;
            try
            {
                State = FormState.Saved;
                ButWithSave.Enabled = false;
                chkIsActive.Checked = _SysSettingCustDis.IsCustomerDisplay.Value;
                cmbPort.Text = _SysSettingCustDis.Port;
                cmbFast.Text = _SysSettingCustDis.Fast.Value.ToString();
                cmbShowState.SelectedIndex = _SysSettingCustDis.DisplayTypeShow.Value;
                if (_SysSettingCustDis.BitStop.Value == 1)
                {
                    chkStop1.Checked = true;
                }
                else if (_SysSettingCustDis.BitStop.Value == 2)
                {
                    chkStop2.Checked = true;
                }
                else
                {
                    chkStop3.Checked = true;
                }
                if (_SysSettingCustDis.BitData.Value == 4)
                {
                    chkData1.Checked = true;
                }
                else if (_SysSettingCustDis.BitData.Value == 5)
                {
                    chkData2.Checked = true;
                }
                else if (_SysSettingCustDis.BitData.Value == 6)
                {
                    chkData3.Checked = true;
                }
                else if (_SysSettingCustDis.BitData.Value == 7)
                {
                    chkData4.Checked = true;
                }
                else
                {
                    chkData5.Checked = true;
                }
                if (_SysSettingCustDis.Parity.Value == 1)
                {
                    chkSync1.Checked = true;
                }
                else if (_SysSettingCustDis.Parity.Value == 2)
                {
                    chkSync2.Checked = true;
                }
                else if (_SysSettingCustDis.Parity.Value == 3)
                {
                    chkSync3.Checked = true;
                }
                else if (_SysSettingCustDis.Parity.Value == 4)
                {
                    chkSync4.Checked = true;
                }
                else
                {
                    chkSync5.Checked = true;
                }
                txtHello.Text = _SysSettingCustDis.CustomerHello;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            chkIsActive.CheckedChanged += chkIsActive_CheckedChanged;
            chkIsActive_CheckedChanged(null, null);
        }
        private void SaveDataCustDis()
        {
            try
            {
                db.ExecuteCommand("update T_SYSSETTING set IsCustomerDisplay = " + (chkIsActive.Checked ? 1 : 0));
                db.ExecuteCommand("update T_SYSSETTING set Port = '" + cmbPort.Text + "'");
                db.ExecuteCommand("update T_SYSSETTING set Fast = " + cmbFast.Text);
                db.ExecuteCommand("update T_SYSSETTING set DisplayTypeShow = " + cmbShowState.SelectedIndex);
                db.ExecuteCommand("update T_SYSSETTING set BitStop = " + (chkStop1.Checked ? 1 : (chkStop2.Checked ? 2 : 3)));
                db.ExecuteCommand("update T_SYSSETTING set BitData = " + (chkData1.Checked ? 4 : (chkData2.Checked ? 5 : (chkData3.Checked ? 6 : (chkData4.Checked ? 7 : 8)))));
                db.ExecuteCommand("update T_SYSSETTING set Parity = " + (chkSync1.Checked ? 1 : (chkSync2.Checked ? 2 : (chkSync3.Checked ? 3 : (chkSync4.Checked ? 4 : 5)))));
                db.ExecuteCommand("update T_SYSSETTING set CustomerHello = '" + txtHello.Text + "'");
                using (Stock_DataDataContext dbc = new Stock_DataDataContext(VarGeneral.BranchCS))
                {
                    VarGeneral.Settings_Sys = new T_SYSSETTING();
                    VarGeneral.Settings_Sys = dbc.SystemSettingStock();
                    VarGeneral._SysDirPath = VarGeneral.Settings_Sys.SysDir;
                    VarGeneral._BackPath = VarGeneral.Settings_Sys.BackPath;
                    try
                    {
                        VarGeneral._AutoSync = VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 41);
                    }
                    catch
                    {
                        VarGeneral._AutoSync = false;
                    }
                }
                //                MessageBox.Show((LangArEn == 0) ? "لقد تم اتمام العملية بنجاح .." : "This Opration Is Done", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                Close();
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Save:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void chkIsActive_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIsActive.Checked)
            {
                groupPanel_Main.Enabled = true;
            }
            else
            {
                groupPanel_Main.Enabled = false;
            }
        }
        private void txtHello_Click(object sender, EventArgs e)
        {
            txtHello.SelectAll();
        }
        private void button_CheckConn_Click(object sender, EventArgs e)
        {
            CustomerDisplayData(0.0, 0.0);
        }
        private void CustomerDisplayData(double _vTot, double _price)
        {
            try
            {
                SerialPort sport = new SerialPort(VarGeneral.Settings_Sys.Port, VarGeneral.Settings_Sys.Fast.Value, (VarGeneral.Settings_Sys.Parity.Value == 1) ? Parity.Even : ((VarGeneral.Settings_Sys.Parity.Value == 2) ? Parity.Mark : ((VarGeneral.Settings_Sys.Parity.Value != 3) ? ((VarGeneral.Settings_Sys.Parity.Value == 4) ? Parity.Odd : Parity.Space) : Parity.None)), VarGeneral.Settings_Sys.BitData.Value, (VarGeneral.Settings_Sys.BitStop.Value == 1) ? StopBits.One : ((VarGeneral.Settings_Sys.BitStop.Value == 2) ? StopBits.OnePointFive : StopBits.Two));
                sport.Open();
                sport.Write(new byte[1]
                {
                    12
                }, 0, 1);
                sport.Write(txtHello.Text);
                sport.Write(new byte[2]
                {
                    10,
                    13
                }, 0, 2);
                if (cmbShowState.SelectedIndex == 0)
                {
                    sport.Write("Price:" + _price + " Total:" + _vTot);
                }
                else if (cmbShowState.SelectedIndex == 1)
                {
                    sport.Write("Price:" + _price);
                }
                else
                {
                    sport.Write(" Total:" + _vTot);
                }
                sport.Close();
            }
            catch (Exception error)
            {
                MessageBox.Show((LangArEn == 0) ? "توجد هناك مشكلة في الإتصال بالجهاز الآخر يرجى التأكد من الإعدادات .. ثم المحاولة مرة اخرى " : "There is a problem connecting to the other device Please make sure the settings .. then try again", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                VarGeneral.DebLog.writeLog("CustomerDisplayData :", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private List<T_AccDef> listAccDefCustDis = new List<T_AccDef>();
        private T_AccDef _AccDefCustDis = new T_AccDef();
        private List<T_Company> listCompanyCustDis = new List<T_Company>();
        private T_Company _CompanyCustDis = new T_Company();
        private List<T_GdAuto> listGdAutoCustDis = new List<T_GdAuto>();
        private T_GdAuto _GdAutoCustDis = new T_GdAuto();
        private List<T_InfoTb> listInfotbCustDis = new List<T_InfoTb>();
        private T_InfoTb _InfotbCustDis = new T_InfoTb();
        public class ColumnDictinaryCusDis
        {
            public string AText = string.Empty;
            public string EText = string.Empty;
            public bool IfDefault = false;
            public string Format = string.Empty;
            public ColumnDictinaryCusDis(string aText, string eText, bool ifDefault, string format)
            {
                AText = aText;
                EText = eText;
                IfDefault = ifDefault;
                Format = format;
            }
        }
        void loadcustdis()
        {
            this.button_CheckConn.Click += new System.EventHandler(this.button_CheckConn_Click);
            this.txtHello.Click += new System.EventHandler(this.txtHello_Click);
            this.chkIsActive.CheckedChanged += new System.EventHandler(this.chkIsActive_CheckedChanged);
            cmbPort.Click += Button_Edit_Click;
            cmbFast.Click += Button_Edit_Click;
            cmbShowState.Click += Button_Edit_Click;
            chkStop1.Click += Button_Edit_Click;
            chkStop2.Click += Button_Edit_Click;
            chkStop3.Click += Button_Edit_Click;
            chkData1.Click += Button_Edit_Click;
            chkData2.Click += Button_Edit_Click;
            chkData3.Click += Button_Edit_Click;
            chkData4.Click += Button_Edit_Click;
            chkData5.Click += Button_Edit_Click;
            chkSync1.Click += Button_Edit_Click;
            chkSync2.Click += Button_Edit_Click;
            chkSync3.Click += Button_Edit_Click;
            chkSync4.Click += Button_Edit_Click;
            chkSync5.Click += Button_Edit_Click;
            txtHello.Click += Button_Edit_Click;
            chkIsActive.Click += Button_Edit_Click;
            try
            {
                //ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmCustomerDisplay));
                //if (VarGeneral.CurrentLang.ToString() == "0"||VarGeneral.CurrentLang.ToString() == "")
                //{
                //    Language.ChangeLanguage("ar-SA", this, resources);
                //    LangArEn = 0;
                //}
                //else
                //{
                //    Language.ChangeLanguage("en", this, resources);
                //    LangArEn = 1;
                //}
                //RibunButtonsCustDis();
                listInvSettingCustDis = db.StockInvSettingList(VarGeneral.UserID);
                _InvSettingCustDis = listInvSettingCustDis[0];
                _SysSettingCustDis = db.SystemSettingStock();
                listCompanyCustDis = db.StockCompanyList();
                _CompanyCustDis = listCompanyCustDis[0];
                _GdAutoCustDis = db.GdAutoStock();
                listInfotbCustDis = db.StockInfoList();
                _InfotbCustDis = listInfotbCustDis[0];
                listAccDefCustDis = db.FillAccDef_2(string.Empty).ToList();
                listAccDefCustDis = listAccDefCustDis.Where((T_AccDef q) => q.Trn == 3 && q.Lev == 4 && q.AccDef_No.StartsWith("1") && q.AccCat != 2 && q.AccCat != 3).ToList();
                try
                {
                    FillComboCustDis();
                }
                catch
                {
                }
                try
                {
                    BindDataCustDis();
                }
                catch
                {
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Load:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void FrmSystemSetting_Load(object sender, EventArgs e)
        {
            // filloptions();
            try
            {
                loadcustdis();
                load(); loadBankop(); LoadBalance();
                ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmSystemSetting));
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
                expandablePanel_NewColumn.Expanded = false;
                if (VarGeneral.SSSTyp == 0)
                {
                    chk5.Visible = false;
                    chk6.Visible = false;
                    chk7.Visible = false;
                    superTabItem_Acc.Visible = false;
                    label54.Visible = false;
                    txtEmailPass.Visible = false;
                    CmbMail.Visible = false;
                    label56.Visible = false;
                    chk19.Visible = false;
                    txtDateAlarmEmps.Visible = false;
                    label47.Visible = false;
                    if (VarGeneral.SSSLev == "M")
                    {
                        chk21.Visible = false;
                        chk22.Visible = false;
                        chk23.Visible = false;
                        chk29.Visible = false;
                        label51.Visible = false;
                        CmbPointImages.Visible = false;
                        groupPanel_Acc.Visible = false;
                        groupPanel2.Location = new Point(groupPanel2.Location.X, groupPanel2.Location.Y - 17);
                    }
                }
                else if (VarGeneral.SSSTyp == 1)
                {
                    superTabItem_Acc.Visible = false;
                    superTabItem_Inv.Visible = false;
                    groupPanel4.Visible = false;
                    picture_SSS.Visible = true;
                    chk19.Visible = false;
                    chk20.Visible = false;
                    chk21.Visible = false;
                    chk22.Visible = false;
                    chk23.Visible = false;
                    chk29.Visible = false;
                    chk14.Visible = false;
                    txtDateAlarmEmps.Visible = false;
                    label47.Visible = false;
                    label51.Visible = false;
                    CmbPointImages.Visible = false;
                }
                if (VarGeneral.SSSLev != "R" && VarGeneral.SSSLev != "C" && VarGeneral.SSSLev != "H")
                {
                    if (VarGeneral.SSSLev != "B" && VarGeneral.SSSLev != "G" && VarGeneral.SSSLev != "S")
                    {
                        chk22.Visible = false;
                    }
                    chk29.Visible = false;
                    label48.Visible = false;
                    CmbPrintTyp.Visible = false;
                    chk39.Visible = false;
                    label75.Visible = false;
                    chk32.Visible = false;
                    chk40.Visible = false;
                    chk50.Visible = false;
                    chk74.Visible = false;
                    CmbOrderTyp.Visible = false;
                    label74.Visible = false;
                    if (VarGeneral.SSSLev == "X")
                    {
                        superTabItem_Hotel.Visible = true;
                    }
                    if (VarGeneral.SSSLev == "Q")
                    {
                        superTabItem_Eqar.Visible = true;
                    }
                }
                else
                {
                    chk22.Visible = true;
                    chk29.Visible = true;
                    label48.Visible = true;
                    CmbPrintTyp.Visible = true;
                    if (VarGeneral.SSSLev == "H")
                    {
                        superTabItem_Hotel.Visible = true;
                    }
                }
                listInvSetting = db.StockInvSettingList(VarGeneral.UserID);
                _InvSetting = listInvSetting[0];
                _SysSetting = db.SystemSettingStock();
                listCompany = db.StockCompanyList();
                _Company = listCompany[0];
                _GdAuto = db.GdAutoStock();
                listInfotb = db.StockInfoList();
                _Infotb = listInfotb[0];
                listAccDef = db.FillAccDef_2(string.Empty).ToList();
                listAccDef = listAccDef.Where((T_AccDef q) => q.Trn == 3 && q.Lev == 4 && q.AccDef_No.StartsWith("1") && q.AccCat != 2 && q.AccCat != 3).ToList();
                try
                {
                    FillCombo();
                }
                catch
                {
                }
                try
                {
                    BindData();
                    filloptions();
                }
                catch
                {
                }
                try
                {
                    listTableFamily = db.FillTable_2(1).ToList();
                }
                catch
                {
                }
                try
                {
                    listTableBoys = db.FillTable_2(2).ToList();
                }
                catch
                {
                }
                try
                {
                    listTableOut = db.FillTable_2(3).ToList();
                }
                catch
                {
                }
                try
                {
                    listTableOther = db.FillTable_2(4).ToList();
                }
                catch
                {
                }
                try
                {
                    RegistryKey hKey = Registry.CurrentUser.OpenSubKey("Software\\PRS AND PR Settings\\MrdSoft\\Register", writable: true);
                    string regval = string.Empty;
                    string DT_H = string.Empty;
                    try
                    {
                        regval = n.FormatGreg(hKey.GetValue("DTBackup").ToString(), "yyyy/MM/dd");
                        DT_H = n.GregToHijri(regval);
                    }
                    catch
                    {
                        regval = string.Empty;
                        DT_H = string.Empty;
                    }
                    try
                    {
                        if (VarGeneral.gUserName == "runsetting")
                        {
                            DT_H = Convert.ToDateTime(VarGeneral.Hdate).AddYears(1).ToString("yyyy/MM/dd");
                            regval = Convert.ToDateTime(VarGeneral.Gdate).AddYears(1).ToString("yyyy/MM/dd");
                        }
                    }
                    catch
                    {
                    }
                    if (Convert.ToDateTime(VarGeneral.Hdate) > Convert.ToDateTime(n.FormatHijri(DT_H, "yyyy/MM/dd")))
                    {
                        dateTimeInput_DT.Text = ((LangArEn == 0) ? "الخدمة موقوفة حاليا" : "Service is Stoped");
                    }
                    else
                    {
                        CultureInfo sa = new CultureInfo("en-US", useUserOverride: false);
                        sa.DateTimeFormat.Calendar = new GregorianCalendar();
                        Thread.CurrentThread.CurrentCulture = sa;
                        Thread.CurrentThread.CurrentUICulture = sa;
                        dateTimeInput_DT.Text = regval;
                        if (VarGeneral.Settings_Sys.Calendr.Value != 0)
                        {
                            sa = new CultureInfo("ar-SA", useUserOverride: false);
                            sa.DateTimeFormat.Calendar = new HijriCalendar();
                            Thread.CurrentThread.CurrentCulture = sa;
                            Thread.CurrentThread.CurrentUICulture = sa;
                        }
                    }
                }
                catch
                {
                    dateTimeInput_DT.Text = ((LangArEn == 0) ? "الخدمة موقوفة حاليا" : "Service is Stoped");
                    if (VarGeneral.Settings_Sys.Calendr.Value != 0)
                    {
                        CultureInfo sa = new CultureInfo("ar-SA", useUserOverride: false);
                        sa.DateTimeFormat.Calendar = new HijriCalendar();
                        Thread.CurrentThread.CurrentCulture = sa;
                        Thread.CurrentThread.CurrentUICulture = sa;
                    }
                }
                switchButton_NewColumnName.OnText = ((LangArEn == 0) ? ("عمود " + VarGeneral.Settings_Sys.LineDetailNameA) : ("Column " + VarGeneral.Settings_Sys.LineDetailNameE));
                switchButton_NewColumnName.OffText = ((LangArEn == 0) ? ("عمود " + VarGeneral.Settings_Sys.LineGiftlNameA) : ("Column " + VarGeneral.Settings_Sys.LineGiftlNameE));
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Load:", error, enable: true);
                MessageBox.Show(error.Message);
            }
            if (File.Exists(Application.StartupPath + "\\Script\\SecriptInvitationCards.dll"))
            {
                Script_InvitationCards();
            }
            if (File.Exists(Application.StartupPath + "\\Script\\SecriptTegnicalCollage.dll"))
            {
                TegnicalCollage();
            }
            if (File.Exists(Application.StartupPath + "\\Script\\SecriptWaterPackages.dll"))
            {
                button_PointOfCust.Visible = false;
                chk64.Enabled = false;
            }
        }
        private void TegnicalCollage()
        {
            node1.Visible = false;
            node2.Visible = false;
            node5.Visible = false;
            node6.Visible = false;
            node9.Visible = false;
            node10.Visible = false;
            node14.Visible = false;
            labelAlarmDueo.Visible = false;
            txtAlarmDeuDateBefor.Visible = false;
            chk69.Enabled = false;
            chk68.Enabled = false;
            chk67.Enabled = false;
            chk66.Enabled = false;
            chk64.Enabled = false;
            chk63.Enabled = false;
            chk62.Enabled = false;
            chk61.Enabled = false;
            chk58.Enabled = false;
            txtDateofInv.Visible = false;
            label76.Visible = false;
            chk34.Enabled = false;
            chk21.Enabled = false;
            chk31.Enabled = false;
            chk33.Enabled = false;
            chk7.Enabled = false;
            chk6.Enabled = false;
            chk5.Enabled = false;
            chk56.Enabled = false;
            chk23.Enabled = false;
            chk10.Enabled = false;
            chk22.Enabled = false;
            chk16.Enabled = false;
            chk38.Enabled = false;
            chk48.Enabled = false;
            chk8.Enabled = false;
            chk15.Enabled = false;
            chk17.Enabled = false;
            chk18.Enabled = false;
            chk55.Enabled = false;
            chk54.Enabled = false;
            groupPanel_Acc.Visible = false;
            chk3.Enabled = false;
            txtDateAlarm.Enabled = false;
            CmbDateTyp.Enabled = false;
            chk2.Enabled = false;
            //button_CustomerDisplay.Visible = false;
            //button_Balance.Visible = false;
            button_PointOfCust.Visible = false;
            //button_CommOption.Visible = false;
            //button_TaxOption.Location = button_CommOption.Location;
            label51.Visible = false;
            CmbPointImages.Visible = false;
            label58.Visible = false;
            chk35.Text = ((LangArEn == 0) ? "رسالة نصية بعد صرف العهدة" : "Message after discharge of custody");
        }
        private void BindDataBalance()
        {
            try
            {
                State = FormState.Saved;
                ButWithSave.Enabled = false;
                checkBox_BalanceActivated.Checked = _SysSettingBalance.IsActiveBalance.Value;
                if (_SysSettingBalance.BalanceType.Value == 0)
                {
                    RedButWight.Checked = true;
                }
                else if (_SysSettingBalance.BalanceType.Value == 1)
                {
                    RedButPrice.Checked = true;
                }
                else
                {
                    RedButWightPrice.Checked = true;
                }
                txtBarcodFrom.Value = _SysSettingBalance.BarcodFrom.Value;
                txtBarcodTo.Value = _SysSettingBalance.BarcodTo.Value;
                txtWightFrom.Value = _SysSettingBalance.WightFrom.Value;
                txtWightTo.Value = _SysSettingBalance.WightTo.Value;
                txtPriceFrom.Value = _SysSettingBalance.PriceFrom.Value;
                txtPriceTo.Value = _SysSettingBalance.PriceTo.Value;
                txtWieghtQ.Value = _SysSettingBalance.WightQ.Value;
                txtPriceQ.Value = _SysSettingBalance.PriceQ.Value;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void SaveDataBalance()
        {
            try
            {
                if (txtWieghtQ.Value > txtWightTo.Value)
                {
                    MessageBox.Show((LangArEn == 0) ? "تأكد من صحة رقم الفاصلة العشرية للوزن" : "Make sure the decimal point number is correct", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                if (txtPriceQ.Value > txtPriceTo.Value)
                {
                    MessageBox.Show((LangArEn == 0) ? "تأكد من صحة رقم الفاصلة العشرية للسعر" : "Make sure the decimal point number is correct", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                db.ExecuteCommand("update T_SYSSETTING set IsActiveBalance = " + (checkBox_BalanceActivated.Checked ? 1 : 0));
                db.ExecuteCommand("update T_SYSSETTING set BalanceType = " + ((!RedButWight.Checked) ? (RedButPrice.Checked ? 1 : 2) : 0));
                db.ExecuteCommand("update T_SYSSETTING set BarcodFrom = " + txtBarcodFrom.Value);
                db.ExecuteCommand("update T_SYSSETTING set BarcodTo = " + txtBarcodTo.Value);
                db.ExecuteCommand("update T_SYSSETTING set WightFrom = " + txtWightFrom.Value);
                db.ExecuteCommand("update T_SYSSETTING set WightTo = " + txtWightTo.Value);
                db.ExecuteCommand("update T_SYSSETTING set PriceFrom = " + txtPriceFrom.Value);
                db.ExecuteCommand("update T_SYSSETTING set PriceTo = " + txtPriceTo.Value);
                db.ExecuteCommand("update T_SYSSETTING set WightQ = " + txtWieghtQ.Value);
                db.ExecuteCommand("update T_SYSSETTING set PriceQ = " + txtPriceQ.Value);
                using (Stock_DataDataContext dbc = new Stock_DataDataContext(VarGeneral.BranchCS))
                {
                    VarGeneral.Settings_Sys = new T_SYSSETTING();
                    VarGeneral.Settings_Sys = dbc.SystemSettingStock();
                    VarGeneral._SysDirPath = VarGeneral.Settings_Sys.SysDir;
                    VarGeneral._BackPath = VarGeneral.Settings_Sys.BackPath;
                    try
                    {
                        VarGeneral._AutoSync = VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 41);
                    }
                    catch
                    {
                        VarGeneral._AutoSync = false;
                    }
                }
                //	MessageBox.Show((LangArEn == 0) ? "لقد تم اتمام العملية بنجاح .." : "This Opration Is Done", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                Close();
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Save:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private T_SYSSETTING _SysSettingBalance = new T_SYSSETTING();
        private void checkBox_BalanceActivated_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_BalanceActivated.Checked)
            {
                groupBox7.Enabled = true;
            }
            else
            {
                groupBox7.Enabled = false;
            }
        }
        void LoadBalance()
        {
            // this.labelHeader.Click += new System.EventHandler(this.labelHeader_Click);
            this.checkBox_BalanceActivated.CheckedChanged += new System.EventHandler(this.checkBox_BalanceActivated_CheckedChanged);
            checkBox_BalanceActivated.Click += Button_Edit_Click;
            RedButWight.Click += Button_Edit_Click;
            RedButPrice.Click += Button_Edit_Click;
            RedButWightPrice.Click += Button_Edit_Click;
            txtWightFrom.Click += Button_Edit_Click;
            txtWightTo.Click += Button_Edit_Click;
            txtPriceFrom.Click += Button_Edit_Click;
            txtPriceTo.Click += Button_Edit_Click;
            txtBarcodFrom.Click += Button_Edit_Click;
            txtBarcodTo.Click += Button_Edit_Click;
            txtWieghtQ.Click += Button_Edit_Click;
            txtPriceQ.Click += Button_Edit_Click;
            try
            {
                //ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmBalance));
                //if (VarGeneral.CurrentLang.ToString() == "0"||VarGeneral.CurrentLang.ToString() == "")
                //{
                //    Language.ChangeLanguage("ar-SA", this, resources);
                //    LangArEn = 0;
                //}
                //else
                //{
                //    Language.ChangeLanguage("en", this, resources);
                //    LangArEn = 1;
                //}
                //RibunButtonsBalance();
                _SysSettingBalance = db.SystemSettingStock();
                try
                {
                    BindDataBalance();
                }
                catch
                {
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("FrmBalance_Load:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void RibunButtonsBalance()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
            {
                ButWithSave.Text = "حفظ";
                //	ButWithSave.Tooltip = "F2";
                ButWithoutSave.Text = "خروج";
                //ButWithoutSave.Tooltip = "Esc";
                //    labelHeader.Text = "إعدادات الميزان الباركود";
            }
            else
            {
                ButWithSave.Text = "Save";
                ButWithoutSave.Text = "Exit";
                //ButWithSave.Tooltip = "F2";
                //ButWithoutSave.Tooltip = "Esc";
                //  labelHeader.Text = "Balance Setting";
            }
        }
        private void Script_InvitationCards()
        {
            chk46.Enabled = false;
            label51.Visible = false;
            CmbPointImages.Visible = false;
            //button_TaxOption.Visible = false;
            //button_CommOption.Visible = false;
            expandablePanel_NewColumn.Visible = false;
            label8.Visible = false;
            CmbCost.Visible = false;
            chk53.Enabled = false;
            chk54.Enabled = false;
            chk55.Enabled = false;
            chk56.Enabled = false;
            chk57.Enabled = false;
            chk58.Enabled = false;
            chk59.Enabled = false;
            chk60.Enabled = false;
            chk61.Enabled = false;
            chk52.Enabled = false;
            chk51.Enabled = false;
            chk21.Enabled = false;
            chk31.Enabled = false;
            chk6.Enabled = false;
            chk5.Enabled = false;
            chk4.Enabled = false;
            chk16.Enabled = false;
            chk11.Enabled = false;
            chk12.Enabled = false;
            chk20.Enabled = false;
            chk48.Enabled = false;
            chk47.Enabled = false;
            chk18.Enabled = false;
            chk14.Enabled = false;
            chk10.Enabled = false;
            chk23.Enabled = false;
            chk22.Enabled = false;
            for (int i = 4; i < c1FlexGrid1.Rows.Count; i++)
            {
                c1FlexGrid1.Rows[i].Visible = false;
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
                    PicItemImg.Image = Image.FromFile(mypic_path);
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
        private void ButWithSave_Click(object sender, EventArgs e)
        {
            SaveData();
            State = FormState.Saved;
            SetReadOnly = true;
            SaveDataTax();
            State = FormState.Saved;
            SaveDataBankopp();
            SetReadOnly = true; SaveDataBalance();
            SaveDataCustDis();
        }
        private void ButWithoutSave_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void ButAddDay_Click(object sender, EventArgs e)
        {
            txtHijriDate.Tag = int.Parse(txtHijriDate.Tag.ToString()) + 1;
            txtGregDate.Text = n.GDateNow();
            txtHijriDate.Text = n.FormatHijri(n.GDateAdd2(n.GregToHijri(txtGregDate.Text, "yyyy/MM/dd"), double.Parse(txtHijriDate.Tag.ToString())), "yyyy/MM/dd");
            Button_Edit_Click(sender, e);
        }
        private void ButDayMinus_Click(object sender, EventArgs e)
        {
            txtHijriDate.Tag = int.Parse(txtHijriDate.Tag.ToString()) - 1;
            txtGregDate.Text = n.GDateNow();
            txtHijriDate.Text = n.FormatHijri(n.GDateAdd2(n.GregToHijri(txtGregDate.Text, "yyyy/MM/dd"), double.Parse(txtHijriDate.Tag.ToString())), "yyyy/MM/dd");
            Button_Edit_Click(sender, e);
        }
        private void textBox_BackupPath_ButtonCustomClick(object sender, EventArgs e)
        {
            try
            {
                if (!(VarGeneral.gUserName == "runsetting") || VarGeneral.UserID == 1)
                {
                    FolderBrowserDialog fbd = new FolderBrowserDialog();
                    DialogResult result = fbd.ShowDialog();
                    textBox_BackupPath.Text = fbd.SelectedPath;
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("textBox_BackupPath_ButtonCustomClick:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void checkBox_AutoBackup_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_AutoBackup.Checked)
            {
                comboBox_AutoBackup.Enabled = true;
            }
            else
            {
                comboBox_AutoBackup.Enabled = false;
            }
        }
        private void txtFirstInventory_ButtonCustomClick(object sender, EventArgs e)
        {
            columns_Names_visible.Clear();
            columns_Names_visible.Add("AccDef_No", new ColumnDictinary("الرقم ", " No", ifDefault: true, string.Empty));
            columns_Names_visible.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, string.Empty));
            columns_Names_visible.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, string.Empty));
            columns_Names_visible.Add("AccDef_ID", new ColumnDictinary(" ", " ", ifDefault: false, string.Empty));
            columns_Names_visible.Add("Mobile", new ColumnDictinary("الجوال", "Mobile", ifDefault: false, string.Empty));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
            }
            VarGeneral.SFrmTyp = "AccDefID_Setting";
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != string.Empty)
            {
                T_AccDef _AccDef = db.StockAccDefs(int.Parse(frm.Serach_No));
                txtFirstInventory.Text = _AccDef.AccDef_No.ToString();
            }
            VarGeneral.Flush();
        }
        private void txtLastInventory_ButtonCustomClick(object sender, EventArgs e)
        {
            columns_Names_visible.Clear();
            columns_Names_visible.Add("AccDef_No", new ColumnDictinary("الرقم ", " No", ifDefault: true, string.Empty));
            columns_Names_visible.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, string.Empty));
            columns_Names_visible.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, string.Empty));
            columns_Names_visible.Add("AccDef_ID", new ColumnDictinary(" ", " ", ifDefault: false, string.Empty));
            columns_Names_visible.Add("Mobile", new ColumnDictinary("الجوال", "Mobile", ifDefault: false, string.Empty));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
            }
            VarGeneral.SFrmTyp = "AccDefID_Setting";
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != string.Empty)
            {
                T_AccDef _AccDef = db.StockAccDefs(int.Parse(frm.Serach_No));
                txtLastInventory.Text = _AccDef.AccDef_No.ToString();
            }
            VarGeneral.Flush();
        }
        private void txtBoxAccount_ButtonCustomClick(object sender, EventArgs e)
        {
            columns_Names_visible.Clear();
            columns_Names_visible.Add("AccDef_No", new ColumnDictinary("الرقم ", " No", ifDefault: true, string.Empty));
            columns_Names_visible.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, string.Empty));
            columns_Names_visible.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, string.Empty));
            columns_Names_visible.Add("AccDef_ID", new ColumnDictinary(" ", " ", ifDefault: false, string.Empty));
            columns_Names_visible.Add("Mobile", new ColumnDictinary("الجوال", "Mobile", ifDefault: false, string.Empty));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
            }
            VarGeneral.SFrmTyp = "AccDefID_Setting";
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != string.Empty)
            {
                T_AccDef _AccDef = db.StockAccDefs(int.Parse(frm.Serach_No));
                txtBoxAccount.Text = _AccDef.AccDef_No.ToString();
            }
            VarGeneral.Flush();
        }
        private void txtProfits_ButtonCustomClick(object sender, EventArgs e)
        {
            columns_Names_visible.Clear();
            columns_Names_visible.Add("AccDef_No", new ColumnDictinary("الرقم ", " No", ifDefault: true, string.Empty));
            columns_Names_visible.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, string.Empty));
            columns_Names_visible.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, string.Empty));
            columns_Names_visible.Add("AccDef_ID", new ColumnDictinary(" ", " ", ifDefault: false, string.Empty));
            columns_Names_visible.Add("Mobile", new ColumnDictinary("الجوال", "Mobile", ifDefault: false, string.Empty));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
            }
            VarGeneral.SFrmTyp = "AccDefID_Setting";
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != string.Empty)
            {
                T_AccDef _AccDef = db.StockAccDefs(int.Parse(frm.Serach_No));
                txtProfits.Text = _AccDef.AccDef_No.ToString();
            }
            VarGeneral.Flush();
        }
        private void chk1_CheckedChanged(object sender, EventArgs e)
        {
            if (chk1.Checked)
            {
                txtAutoNumber.Enabled = true;
            }
            else
            {
                txtAutoNumber.Enabled = false;
            }
        }
        private void chk3_CheckedChanged(object sender, EventArgs e)
        {
            if (chk3.Checked)
            {
                txtDateAlarm.Enabled = true;
                CmbDateTyp.Enabled = true;
            }
            else
            {
                txtDateAlarm.Enabled = false;
                CmbDateTyp.Enabled = false;
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
        private void txtHeadingR3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsNumber(e.KeyChar) & (e.KeyChar != '\b')) && e.KeyChar != '-' && e.KeyChar != '\\')
            {
                e.Handled = true;
            }
        }
        private void textBox_BackupPath_Click(object sender, EventArgs e)
        {
            textBox_BackupPath.SelectAll();
        }
        private void txtGregDate_Click(object sender, EventArgs e)
        {
            txtGregDate.SelectAll();
        }
        private void txtHijriDate_Click(object sender, EventArgs e)
        {
            txtHijriDate.SelectAll();
        }
        private void txtFirstInventory_Click(object sender, EventArgs e)
        {
            txtFirstInventory.SelectAll();
        }
        private void txtLastInventory_Click(object sender, EventArgs e)
        {
            txtLastInventory.SelectAll();
        }
        private void txtBoxAccount_Click(object sender, EventArgs e)
        {
            txtBoxAccount.SelectAll();
        }
        private void txtProfits_Click(object sender, EventArgs e)
        {
            txtProfits.SelectAll();
        }
        private void txtCompany_Click(object sender, EventArgs e)
        {
            txtCompany.SelectAll();
        }
        private void txtAct_Click(object sender, EventArgs e)
        {
            txtAct.SelectAll();
        }
        private void txtAddr_Click(object sender, EventArgs e)
        {
            txtAddr.SelectAll();
        }
        private void txtTel1_Click(object sender, EventArgs e)
        {
            txtTel1.SelectAll();
        }
        private void txtFax_Click(object sender, EventArgs e)
        {
            txtFax.SelectAll();
        }
        private void txtMobile_Click(object sender, EventArgs e)
        {
            txtMobile.SelectAll();
        }
        private void txtTel2_Click(object sender, EventArgs e)
        {
            txtTel2.SelectAll();
        }
        private void txtPOBox_Click(object sender, EventArgs e)
        {
            txtPOBox.SelectAll();
        }
        private void txtMailCode_Click(object sender, EventArgs e)
        {
            txtMailCode.SelectAll();
        }
        private void txtRemark_Click(object sender, EventArgs e)
        {
            txtRemark.SelectAll();
        }
        private void txtHeadingR1_Click(object sender, EventArgs e)
        {
            txtHeadingR1.SelectAll();
        }
        private void txtHeadingR2_Click(object sender, EventArgs e)
        {
            txtHeadingR2.SelectAll();
        }
        private void txtHeadingR3_Click(object sender, EventArgs e)
        {
            txtHeadingR3.SelectAll();
        }
        private void txtHeadingR4_Click(object sender, EventArgs e)
        {
            txtHeadingR4.SelectAll();
        }
        private void txtHeadingL1_Click(object sender, EventArgs e)
        {
            txtHeadingL1.SelectAll();
        }
        private void txtHeadingL2_Click(object sender, EventArgs e)
        {
            txtHeadingL2.SelectAll();
        }
        private void txtHeadingL3_Click(object sender, EventArgs e)
        {
            txtHeadingL3.SelectAll();
        }
        private void txtHeadingL4_Click(object sender, EventArgs e)
        {
            txtHeadingL4.SelectAll();
        }
        private void c1FlexGrid1_BeforeEdit(object sender, RowColEventArgs e)
        {
            if (e.Col != 3 || !(c1FlexGrid1.GetData(e.Row, 7).ToString() != "3"))
            {
                return;
            }
            for (int iiCnt = 1; iiCnt < c1FlexGrid1.Rows.Count; iiCnt++)
            {
                if (iiCnt != e.Row && c1FlexGrid1.GetData(iiCnt, 6).ToString() == c1FlexGrid1.GetData(e.Row, 6).ToString() && c1FlexGrid1.GetData(iiCnt, 7).ToString() != "3")
                {
                    c1FlexGrid1.SetData(iiCnt, 3, c1FlexGrid1.GetData(e.Row, 3));
                }
            }
        }
        private void c1FlexGrid1_Click(object sender, EventArgs e)
        {
            Button_Edit_Click(sender, e);
        }
        private void c1FlexGrid1_DoubleClick(object sender, EventArgs e)
        {
            if ((c1FlexGrid1.Col != 4 && c1FlexGrid1.Col != 5) || c1FlexGrid1.Row <= 0)
            {
                return;
            }
            columns_Names_visible.Clear();
            columns_Names_visible.Add("AccDef_No", new ColumnDictinary("الرقم ", " No", ifDefault: true, string.Empty));
            columns_Names_visible.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, string.Empty));
            columns_Names_visible.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, string.Empty));
            columns_Names_visible.Add("AccDef_ID", new ColumnDictinary(" ", " ", ifDefault: false, string.Empty));
            columns_Names_visible.Add("Mobile", new ColumnDictinary("الجوال", "Mobile", ifDefault: false, string.Empty));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
            }
            VarGeneral.SFrmTyp = "AccDefID_Setting";
            frm.TopMost = true;
            frm.ShowDialog();
            try
            {
                if (frm.SerachNo != string.Empty)
                {
                    T_AccDef _AccDef = db.StockAccDefs(int.Parse(frm.Serach_No));
                    c1FlexGrid1.SetData(c1FlexGrid1.Row, c1FlexGrid1.Col, _AccDef.AccDef_No.ToString());
                }
                else
                {
                    c1FlexGrid1.SetData(c1FlexGrid1.Row, c1FlexGrid1.Col, "***");
                }
            }
            catch
            {
                c1FlexGrid1.SetData(c1FlexGrid1.Row, c1FlexGrid1.Col, "***");
            }
            VarGeneral.Flush();
        }
        private void button_Background_Click(object sender, EventArgs e)
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
                    Button_Edit_Click(sender, e);
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("button_Background_Click:", error, enable: true);
                MessageBox.Show(error.Message);
            }
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
        private void button_RemoveBackgroud_Click(object sender, EventArgs e)
        {
            Button_Edit_Click(sender, e);
            Image image2 = (pictureBox_EnterPic.Image = (BackgroundImage = Resources.sssBackground));
        }
        private void CmbPrinter_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void checkBox_previewPrint_CheckedChanged(object sender, CheckBoxChangeEventArgs e)
        {

        }
        private void Button_Edit_Click(object sender, EventArgs e)
        {
            if (CanEdit && State != FormState.Edit && State != FormState.New)
            {
                if (State != FormState.New)
                {
                    State = FormState.Edit;
                }
                SetReadOnly = false;
            }
        }
        private void CmbPaperSize_MouseClick(object sender, MouseEventArgs e)
        {

        }
        private void txtLinePage_LockUpdateChanged(object sender, EventArgs e)
        {

        }
        private void txtLinePage_ValueChanged(object sender, EventArgs e)
        {

        }
        private void button_DocPath_Click(object sender, EventArgs e)
        {
            try
            {
                if (!(VarGeneral.gUserName == "runsetting") || VarGeneral.UserID == 1)
                {
                    FolderBrowserDialog fbd = new FolderBrowserDialog();
                    DialogResult result = fbd.ShowDialog();
                    textBox_DocPath.Text = fbd.SelectedPath;
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("button_Pic_Click:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void button_DayofMonth_Click(object sender, EventArgs e)
        {
            FrmDaysOfMonth frm = new FrmDaysOfMonth();
            frm.Tag = LangArEn;
            frm.TopMost = true;
            frm.ShowDialog();
        }
        private void chk19_CheckedChanged(object sender, EventArgs e)
        {
            if (chk19.Checked)
            {
                txtDateAlarmEmps.Enabled = true;
            }
            else
            {
                txtDateAlarmEmps.Enabled = false;
            }
        }
        private void textBox_BackupElectronic_ButtonCustomClick(object sender, EventArgs e)
        {
            if (VarGeneral.UserID != 1 || !VarGeneral.CheckDate(dateTimeInput_DT.Text))
            {
                return;
            }
            try
            {
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                DialogResult result = fbd.ShowDialog();
                textBox_BackupElectronic.Tag = fbd.SelectedPath;
                if (string.IsNullOrEmpty(textBox_BackupElectronic.Tag.ToString()))
                {
                    textBox_BackupElectronic.Text = ((LangArEn == 0) ? "لم يتم تحديد مسار النسخ الالكتروني" : "It not been determined path");
                }
                else
                {
                    textBox_BackupElectronic.Text = ((LangArEn == 0) ? "لقد تم تحديد مسار النسخ الالكتروني" : "It has been determined path");
                }
            }
            catch (Exception error)
            {
                textBox_BackupElectronic.Tag = string.Empty;
                textBox_BackupElectronic.Text = ((LangArEn == 0) ? "لم يتم تحديد مسار النسخ الالكتروني" : "It not been determined path");
                VarGeneral.DebLog.writeLog("textBox_BackupElectronic_ButtonCustomClick:", error, enable: true);
            }
        }
        private void FlxInv_DoubleClick(object sender, EventArgs e)
        {
            if (FlxInv.Row <= 0 || FlxInv.Row == 1)
            {
                return;
            }
            if (FlxInv.Col == 3)
            {
                columns_Names_visible.Clear();
                columns_Names_visible.Add("AccDef_No", new ColumnDictinary("الرقم ", " No", ifDefault: true, string.Empty));
                columns_Names_visible.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, string.Empty));
                columns_Names_visible.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, string.Empty));
                columns_Names_visible.Add("AccDef_ID", new ColumnDictinary(" ", " ", ifDefault: false, string.Empty));
                columns_Names_visible.Add("Mobile", new ColumnDictinary("الجوال", "Mobile", ifDefault: false, string.Empty));
                FrmSearch frm = new FrmSearch();
                frm.Tag = LangArEn;
                ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible;
                foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
                {
                    frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
                }
                VarGeneral.SFrmTyp = "T_AccDef";
                VarGeneral.AccTyp = 8;
                frm.TopMost = true;
                frm.ShowDialog();
                try
                {
                    if (frm.SerachNo != string.Empty)
                    {
                        T_AccDef _AccDef = db.StockAccDefs(int.Parse(frm.Serach_No));
                        FlxInv.SetData(FlxInv.Row, FlxInv.Col, _AccDef.AccDef_No.ToString());
                    }
                    else
                    {
                        FlxInv.SetData(FlxInv.Row, FlxInv.Col, string.Empty);
                    }
                }
                catch
                {
                    FlxInv.SetData(FlxInv.Row, FlxInv.Col, string.Empty);
                }
                VarGeneral.Flush();
            }
            else
            {
                if (FlxInv.Col != 4)
                {
                    return;
                }
                columns_Names_visible.Clear();
                columns_Names_visible.Add("AccDef_No", new ColumnDictinary("الرقم ", " No", ifDefault: true, string.Empty));
                columns_Names_visible.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, string.Empty));
                columns_Names_visible.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, string.Empty));
                columns_Names_visible.Add("AccDef_ID", new ColumnDictinary(" ", " ", ifDefault: false, string.Empty));
                columns_Names_visible.Add("Mobile", new ColumnDictinary("الجوال", "Mobile", ifDefault: false, string.Empty));
                FrmSearch frm = new FrmSearch();
                frm.Tag = LangArEn;
                ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible;
                foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
                {
                    frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
                }
                VarGeneral.SFrmTyp = "T_AccDef3";
                frm.TopMost = true;
                frm.ShowDialog();
                try
                {
                    if (frm.SerachNo != string.Empty)
                    {
                        T_AccDef _AccDef = db.StockAccDefs(int.Parse(frm.Serach_No));
                        FlxInv.SetData(FlxInv.Row, FlxInv.Col, _AccDef.AccDef_No.ToString());
                    }
                    else
                    {
                        FlxInv.SetData(FlxInv.Row, FlxInv.Col, string.Empty);
                    }
                }
                catch
                {
                    FlxInv.SetData(FlxInv.Row, FlxInv.Col, string.Empty);
                }
                VarGeneral.Flush();
            }
        }
        private void txtEmailBoss_Click(object sender, EventArgs e)
        {
            txtEmailBoss.SelectAll();
        }
        private void txtEmailPass_Click(object sender, EventArgs e)
        {
            txtEmailPass.SelectAll();
        }
        private void txtEmailBoss_Enter(object sender, EventArgs e)
        {
            Framework.Keyboard.Language.Switch("English");
        }
        private void txtEmailBoss_Leave(object sender, EventArgs e)
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
            {
                Framework.Keyboard.Language.Switch("Arabic");
            }
        }
        private void txtMobile_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (e.KeyChar != '\b'))
            {
                e.Handled = true;
            }
        }
        private void CmbPrintTyp_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (VarGeneral.SSSLev == "R" || VarGeneral.SSSLev == "C" || VarGeneral.SSSLev == "H")
                {
                    chk39.Visible = true;
                    label75.Visible = true;
                }
                else
                {
                    chk39.Visible = false;
                    label75.Visible = false;
                }
                if ((CmbPrintTyp.SelectedIndex == 0 || CmbPrintTyp.SelectedIndex == 2) && (VarGeneral.SSSLev == "R" || VarGeneral.SSSLev == "C" || VarGeneral.SSSLev == "H"))
                {
                    chk50.Visible = true;
                }
                else
                {
                    chk50.Visible = false;
                }
            }
            catch
            {
                chk39.Visible = false;
                label75.Visible = false;
                chk50.Visible = false;
            }
        }
        private void button_B1_Click(object sender, EventArgs e)
        {
            _BackColor(0);
        }
        private void button_B2_Click(object sender, EventArgs e)
        {
            _BackColor(1);
        }
        private void button_B3_Click(object sender, EventArgs e)
        {
            _BackColor(2);
        }
        private void button_B4_Click(object sender, EventArgs e)
        {
            _BackColor(3);
        }
        private void button_B5_Click(object sender, EventArgs e)
        {
            _BackColor(4);
        }
        private void button_B6_Click(object sender, EventArgs e)
        {
            _BackColor(5);
        }
        private void button_B7_Click(object sender, EventArgs e)
        {
            _BackColor(6);
        }
        private void button_B8_Click(object sender, EventArgs e)
        {
            _BackColor(7);
        }
        private void button_F1_Click(object sender, EventArgs e)
        {
            _ForeColor(0);
        }
        private void button_F2_Click(object sender, EventArgs e)
        {
            _ForeColor(1);
        }
        private void button_F3_Click(object sender, EventArgs e)
        {
            _ForeColor(2);
        }
        private void button_F4_Click(object sender, EventArgs e)
        {
            _ForeColor(3);
        }
        private void button_F5_Click(object sender, EventArgs e)
        {
            _ForeColor(4);
        }
        private void button_F6_Click(object sender, EventArgs e)
        {
            _ForeColor(5);
        }
        private void button_F7_Click(object sender, EventArgs e)
        {
            _ForeColor(6);
        }
        private void button_F8_Click(object sender, EventArgs e)
        {
            _ForeColor(7);
        }
        private void _BackColor(int i)
        {
            ColorDialog dlg = new ColorDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                switch (i)
                {
                    case 0:
                        txtREmpty.BackColor = dlg.Color;
                        break;
                    case 1:
                        txtRAvailable.BackColor = dlg.Color;
                        break;
                    case 2:
                        txtRBussyDaily.BackColor = dlg.Color;
                        break;
                    case 3:
                        txtRBussyAppendix.BackColor = dlg.Color;
                        break;
                    case 4:
                        txtRClean.BackColor = dlg.Color;
                        break;
                    case 5:
                        txtRRepair.BackColor = dlg.Color;
                        break;
                    case 6:
                        txtRBussyMonthly.BackColor = dlg.Color;
                        break;
                    case 7:
                        txtRLeave.BackColor = dlg.Color;
                        break;
                }
            }
        }
        private void _ForeColor(int i)
        {
            ColorDialog dlg = new ColorDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                switch (i)
                {
                    case 0:
                        txtREmpty.ForeColor = dlg.Color;
                        break;
                    case 1:
                        txtRAvailable.ForeColor = dlg.Color;
                        break;
                    case 2:
                        txtRBussyDaily.ForeColor = dlg.Color;
                        break;
                    case 3:
                        txtRBussyAppendix.ForeColor = dlg.Color;
                        break;
                    case 4:
                        txtRClean.ForeColor = dlg.Color;
                        break;
                    case 5:
                        txtRRepair.ForeColor = dlg.Color;
                        break;
                    case 6:
                        txtRBussyMonthly.ForeColor = dlg.Color;
                        break;
                    case 7:
                        txtRLeave.ForeColor = dlg.Color;
                        break;
                }
            }
        }
        private void txtAllowPeriod_Leave(object sender, EventArgs e)
        {
            try
            {
                if (VarGeneral.CheckTime(txtAllowPeriod.Text))
                {
                    txtAllowPeriod.Text = TimeSpan.Parse(txtAllowPeriod.Text).ToString();
                }
                else
                {
                    txtAllowPeriod.Text = "05:00:00";
                }
            }
            catch
            {
                txtAllowPeriod.Text = "05:00:00";
            }
            try
            {
                if (int.Parse(txtAllowPeriod.Text.Substring(0, 2)) > 12 || txtAllowPeriod.Text.Substring(0, 2) == "00")
                {
                    if (txtAllowPeriod.Text.Substring(0, 2) == "13")
                    {
                        txtAllowPeriod.Text = "01" + txtAllowPeriod.Text.Remove(0, 2);
                    }
                    else if (txtAllowPeriod.Text.Substring(0, 2) == "14")
                    {
                        txtAllowPeriod.Text = "02" + txtAllowPeriod.Text.Remove(0, 2);
                    }
                    else if (txtAllowPeriod.Text.Substring(0, 2) == "15")
                    {
                        txtAllowPeriod.Text = "03" + txtAllowPeriod.Text.Remove(0, 2);
                    }
                    else if (txtAllowPeriod.Text.Substring(0, 2) == "16")
                    {
                        txtAllowPeriod.Text = "04" + txtAllowPeriod.Text.Remove(0, 2);
                    }
                    else if (txtAllowPeriod.Text.Substring(0, 2) == "17")
                    {
                        txtAllowPeriod.Text = "05" + txtAllowPeriod.Text.Remove(0, 2);
                    }
                    else if (txtAllowPeriod.Text.Substring(0, 2) == "18")
                    {
                        txtAllowPeriod.Text = "06" + txtAllowPeriod.Text.Remove(0, 2);
                    }
                    else if (txtAllowPeriod.Text.Substring(0, 2) == "19")
                    {
                        txtAllowPeriod.Text = "07" + txtAllowPeriod.Text.Remove(0, 2);
                    }
                    else if (txtAllowPeriod.Text.Substring(0, 2) == "20")
                    {
                        txtAllowPeriod.Text = "08" + txtAllowPeriod.Text.Remove(0, 2);
                    }
                    else if (txtAllowPeriod.Text.Substring(0, 2) == "21")
                    {
                        txtAllowPeriod.Text = "09" + txtAllowPeriod.Text.Remove(0, 2);
                    }
                    else if (txtAllowPeriod.Text.Substring(0, 2) == "22")
                    {
                        txtAllowPeriod.Text = "10" + txtAllowPeriod.Text.Remove(0, 2);
                    }
                    else if (txtAllowPeriod.Text.Substring(0, 2) == "23")
                    {
                        txtAllowPeriod.Text = "11" + txtAllowPeriod.Text.Remove(0, 2);
                    }
                    else if (txtAllowPeriod.Text.Substring(0, 2) == "00")
                    {
                        txtAllowPeriod.Text = "12" + txtAllowPeriod.Text.Remove(0, 2);
                    }
                }
            }
            catch
            {
            }
        }
        private void txtLeavePeriod_Leave(object sender, EventArgs e)
        {
            try
            {
                if (VarGeneral.CheckTime(txtLeavePeriod.Text))
                {
                    txtLeavePeriod.Text = TimeSpan.Parse(txtLeavePeriod.Text).ToString();
                }
                else
                {
                    txtLeavePeriod.Text = "06:00:00";
                }
            }
            catch
            {
                txtLeavePeriod.Text = "06:00:00";
            }
            try
            {
                if (int.Parse(txtLeavePeriod.Text.Substring(0, 2)) > 12 || txtLeavePeriod.Text.Substring(0, 2) == "00")
                {
                    if (txtLeavePeriod.Text.Substring(0, 2) == "13")
                    {
                        txtLeavePeriod.Text = "01" + txtLeavePeriod.Text.Remove(0, 2);
                    }
                    else if (txtLeavePeriod.Text.Substring(0, 2) == "14")
                    {
                        txtLeavePeriod.Text = "02" + txtLeavePeriod.Text.Remove(0, 2);
                    }
                    else if (txtLeavePeriod.Text.Substring(0, 2) == "15")
                    {
                        txtLeavePeriod.Text = "03" + txtLeavePeriod.Text.Remove(0, 2);
                    }
                    else if (txtLeavePeriod.Text.Substring(0, 2) == "16")
                    {
                        txtLeavePeriod.Text = "04" + txtLeavePeriod.Text.Remove(0, 2);
                    }
                    else if (txtLeavePeriod.Text.Substring(0, 2) == "17")
                    {
                        txtLeavePeriod.Text = "05" + txtLeavePeriod.Text.Remove(0, 2);
                    }
                    else if (txtLeavePeriod.Text.Substring(0, 2) == "18")
                    {
                        txtLeavePeriod.Text = "06" + txtLeavePeriod.Text.Remove(0, 2);
                    }
                    else if (txtLeavePeriod.Text.Substring(0, 2) == "19")
                    {
                        txtLeavePeriod.Text = "07" + txtLeavePeriod.Text.Remove(0, 2);
                    }
                    else if (txtLeavePeriod.Text.Substring(0, 2) == "20")
                    {
                        txtLeavePeriod.Text = "08" + txtLeavePeriod.Text.Remove(0, 2);
                    }
                    else if (txtLeavePeriod.Text.Substring(0, 2) == "21")
                    {
                        txtLeavePeriod.Text = "09" + txtLeavePeriod.Text.Remove(0, 2);
                    }
                    else if (txtLeavePeriod.Text.Substring(0, 2) == "22")
                    {
                        txtLeavePeriod.Text = "10" + txtLeavePeriod.Text.Remove(0, 2);
                    }
                    else if (txtLeavePeriod.Text.Substring(0, 2) == "23")
                    {
                        txtLeavePeriod.Text = "11" + txtLeavePeriod.Text.Remove(0, 2);
                    }
                    else if (txtLeavePeriod.Text.Substring(0, 2) == "00")
                    {
                        txtLeavePeriod.Text = "12" + txtLeavePeriod.Text.Remove(0, 2);
                    }
                }
            }
            catch
            {
            }
        }
        private void txtLeavePeriod_Click(object sender, EventArgs e)
        {
            txtLeavePeriod.SelectAll();
        }
        private void txtAllowPeriod_Click(object sender, EventArgs e)
        {
            txtAllowPeriod.SelectAll();
        }
        private void txtGuestsFatherAcc_ButtonCustomClick(object sender, EventArgs e)
        {
            Button_Edit_Click(sender, e);
            columns_Names_visible.Clear();
            columns_Names_visible.Add("AccDef_No", new ColumnDictinary("الرقم ", " No", ifDefault: true, string.Empty));
            columns_Names_visible.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, string.Empty));
            columns_Names_visible.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, string.Empty));
            columns_Names_visible.Add("AccDef_ID", new ColumnDictinary(" ", " ", ifDefault: false, string.Empty));
            columns_Names_visible.Add("Mobile", new ColumnDictinary("الجوال", "Mobile", ifDefault: false, string.Empty));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
            }
            VarGeneral.SFrmTyp = "T_AccDef_Banks";
            VarGeneral.AccTyp = 11;
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != string.Empty)
            {
                T_AccDef _AccDef = db.StockAccDefs(int.Parse(frm.Serach_No));
                txtGuestsFatherAcc.Text = _AccDef.AccDef_No.ToString();
                txtGuestsFatherAccName.Text = ((LangArEn == 0) ? db.StockAccDefWithOutBalance(txtGuestsFatherAcc.Text).Arb_Des : db.StockAccDefWithOutBalance(txtGuestsFatherAcc.Text).Eng_Des);
            }
            else
            {
                txtGuestsFatherAcc.Text = string.Empty;
                txtGuestsFatherAccName.Text = string.Empty;
            }
            VarGeneral.Flush();
        }
        private void txtGuestsFatherAcc_Click(object sender, EventArgs e)
        {
            txtGuestsFatherAcc.SelectAll();
        }
        private void txtGuestBoxAcc_ButtonCustomClick(object sender, EventArgs e)
        {
            Button_Edit_Click(sender, e);
            columns_Names_visible.Clear();
            columns_Names_visible.Add("AccDef_No", new ColumnDictinary("الرقم ", " No", ifDefault: true, string.Empty));
            columns_Names_visible.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, string.Empty));
            columns_Names_visible.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, string.Empty));
            columns_Names_visible.Add("AccDef_ID", new ColumnDictinary(" ", " ", ifDefault: false, string.Empty));
            columns_Names_visible.Add("Mobile", new ColumnDictinary("الجوال", "Mobile", ifDefault: false, string.Empty));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
            }
            VarGeneral.SFrmTyp = "AccDefID_Setting";
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != string.Empty)
            {
                T_AccDef _AccDef = db.StockAccDefs(int.Parse(frm.Serach_No));
                txtGuestBoxAcc.Text = _AccDef.AccDef_No.ToString();
                txtGuestBoxAccName.Text = ((LangArEn == 0) ? db.StockAccDefWithOutBalance(txtGuestBoxAcc.Text).Arb_Des : db.StockAccDefWithOutBalance(txtGuestBoxAcc.Text).Eng_Des);
            }
            else
            {
                txtGuestBoxAcc.Text = string.Empty;
                txtGuestBoxAccName.Text = string.Empty;
            }
        }
        private void txtGuestBoxAcc_Click(object sender, EventArgs e)
        {
            txtGuestBoxAcc.SelectAll();
        }
        private void txtGuestsFatherAccName_Click(object sender, EventArgs e)
        {
            txtGuestsFatherAccName.SelectAll();
        }
        private void txtGuestBoxAccName_Click(object sender, EventArgs e)
        {
            txtGuestBoxAccName.SelectAll();
        }
        private void txtKeyNational_Click(object sender, EventArgs e)
        {
            txtKeyNational.SelectAll();
        }
        private void button_TaxOption_Click(object sender, EventArgs e)
        {
            try
            {
                FrmTaxOpiton frm = new FrmTaxOpiton();
                frm.Tag = LangArEn;
                frm.TopMost = true;
                frm.ShowDialog();
                dbInstance = null;
                listInvSetting = db.StockInvSettingList(VarGeneral.UserID);
                _InvSetting = listInvSetting[0];
                _SysSetting = db.SystemSettingStock();
                listCompany = db.StockCompanyList();
                _Company = listCompany[0];
                _GdAuto = db.GdAutoStock();
                listInfotb = db.StockInfoList();
                _Infotb = listInfotb[0];
                listAccDef = db.FillAccDef_2(string.Empty).ToList();
                listAccDef = listAccDef.Where((T_AccDef q) => q.Trn == 3 && q.Lev == 4 && q.AccDef_No.StartsWith("1") && q.AccCat != 2 && q.AccCat != 3).ToList();
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("button_TaxOption_Click:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void button_CommOption_Click(object sender, EventArgs e)
        {
            try
            {
                FrmCommOpiton frm = new FrmCommOpiton();
                frm.Tag = LangArEn;
                frm.TopMost = true;
                frm.ShowDialog();
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("button_CommOption_Click:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void button_CustomerDisplay_Click(object sender, EventArgs e)
        {
            try
            {
                FrmCustomerDisplay frm = new FrmCustomerDisplay();
                frm.Tag = LangArEn;
                frm.TopMost = true;
                frm.ShowDialog();
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("button_CustomerDisplay_Click:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        public static int optionflag = 0;
        public static List<int> nn = new List<int>();
        private void button_ManageRoom_Click(object sender, EventArgs e)
        {
            if (txtFloors.IsInputReadOnly)
            {
                return;
            }
            if (_SysSetting.flore.Value != txtFloors.Value)
            {
                MessageBox.Show((LangArEn == 0) ? "لقد تم تغيير عدد الطوابق .. يرجى اتمام عملية الحفظ قبل القيام بعملية التحكم في غرف / شقق الطوابق ثم المحاولة مرة اخرى" : "The number of floors has been changed. Please complete the process of conservation before controlling the rooms / apartments of the floors and then try again", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            try
            {
                FrmRoomManage frm = new FrmRoomManage();
                frm.Tag = LangArEn;
                frm.TopMost = true;
                frm.ShowDialog();
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("button_ManageRoom_Click:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void chk58_CheckedChanged(object sender, EventArgs e)
        {
            if (chk58.Checked)
            {
                txtDateofInv.Enabled = true;
            }
            else
            {
                txtDateofInv.Enabled = false;
            }
        }
        private void button_Balance_Click(object sender, EventArgs e)
        {
            try
            {
                FrmBalance frm = new FrmBalance();
                frm.Tag = LangArEn;
                frm.TopMost = true;
                frm.ShowDialog();
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("button_Balance_Click:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void switchButton_NewColumnName_ValueChanged(object sender, EventArgs e)
        {
            NewColumnData();
        }
        private void textBox_BackupElectronic_ButtonCustom2Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(textBox_BackupElectronic.Tag.ToString()) && Directory.Exists(VarGeneral.Settings_Sys.SysDir))
                {
                    MessageBox.Show(VarGeneral.Settings_Sys.SysDir);
                }
                else
                {
                    MessageBox.Show((LangArEn == 0) ? "يتعذر الوصول الى مسار النسخ الإحتياطي" : "It not been determined path");
                }
            }
            catch
            {
            }
        }
        private void button_PointOfCust_Click(object sender, EventArgs e)
        {
            try
            {
                FrmPointsCalc frm = new FrmPointsCalc();
                frm.Tag = LangArEn;
                frm.TopMost = true;
                frm.ShowDialog();
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("button_PointOfCust_Click:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void chk69_CheckedChanged(object sender, EventArgs e)
        {
            if (chk69.Checked)
            {
                txtAlarmDeuDateBefor.Enabled = true;
            }
            else
            {
                txtAlarmDeuDateBefor.Enabled = false;
            }
        }
        private void textBox_SyncPath_ButtonCustomClick(object sender, EventArgs e)
        {
            try
            {
                if (VarGeneral.UserID == 1)
                {
                    FolderBrowserDialog fbd = new FolderBrowserDialog();
                    DialogResult result = fbd.ShowDialog();
                    textBox_SyncPath.Text = fbd.SelectedPath;
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("textBox_SyncPath_ButtonCustomClick:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void textBox_SyncPath_Click(object sender, EventArgs e)
        {
            textBox_SyncPath.SelectAll();
        }
        private void chk55_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                chk73.Enabled = chk55.Checked;
            }
            catch
            {
                chk73.Enabled = true;
            }
        }
        private void txtEqarsFatherAcc_Click(object sender, EventArgs e)
        {
            txtEqarsFatherAcc.SelectAll();
        }
        private void txtEqarsFatherAcc_ButtonCustomClick(object sender, EventArgs e)
        {
            Button_Edit_Click(sender, e);
            columns_Names_visible.Clear();
            columns_Names_visible.Add("AccDef_No", new ColumnDictinary("الرقم ", " No", ifDefault: true, string.Empty));
            columns_Names_visible.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, string.Empty));
            columns_Names_visible.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, string.Empty));
            columns_Names_visible.Add("AccDef_ID", new ColumnDictinary(" ", " ", ifDefault: false, string.Empty));
            columns_Names_visible.Add("Mobile", new ColumnDictinary("الجوال", "Mobile", ifDefault: false, string.Empty));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
            }
            VarGeneral.SFrmTyp = "T_AccDef_Banks";
            VarGeneral.AccTyp = 1;
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != string.Empty)
            {
                T_AccDef _AccDef = db.StockAccDefs(int.Parse(frm.Serach_No));
                txtEqarsFatherAcc.Text = _AccDef.AccDef_No.ToString();
                txtEqarsFatherAccName.Text = ((LangArEn == 0) ? db.StockAccDefWithOutBalance(txtEqarsFatherAcc.Text).Arb_Des : db.StockAccDefWithOutBalance(txtEqarsFatherAcc.Text).Eng_Des);
            }
            else
            {
                txtEqarsFatherAcc.Text = string.Empty;
                txtEqarsFatherAccName.Text = string.Empty;
            }
            VarGeneral.Flush();
        }
        private void txtTenantFatherAcc_Click(object sender, EventArgs e)
        {
            txtTenantFatherAcc.SelectAll();
        }
        private void txtTenantFatherAcc_ButtonCustomClick(object sender, EventArgs e)
        {
            Button_Edit_Click(sender, e);
            columns_Names_visible.Clear();
            columns_Names_visible.Add("AccDef_No", new ColumnDictinary("الرقم ", " No", ifDefault: true, string.Empty));
            columns_Names_visible.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, string.Empty));
            columns_Names_visible.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, string.Empty));
            columns_Names_visible.Add("AccDef_ID", new ColumnDictinary(" ", " ", ifDefault: false, string.Empty));
            columns_Names_visible.Add("Mobile", new ColumnDictinary("الجوال", "Mobile", ifDefault: false, string.Empty));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
            }
            VarGeneral.SFrmTyp = "T_AccDef_Banks";
            VarGeneral.AccTyp = 12;
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != string.Empty)
            {
                T_AccDef _AccDef = db.StockAccDefs(int.Parse(frm.Serach_No));
                txtTenantFatherAcc.Text = _AccDef.AccDef_No.ToString();
                txttenantFatherAccName.Text = ((LangArEn == 0) ? db.StockAccDefWithOutBalance(txtTenantFatherAcc.Text).Arb_Des : db.StockAccDefWithOutBalance(txtTenantFatherAcc.Text).Eng_Des);
            }
            else
            {
                txtTenantFatherAcc.Text = string.Empty;
                txttenantFatherAccName.Text = string.Empty;
            }
            VarGeneral.Flush();
        }
        private void button_RestoreDefContract_Click(object sender, EventArgs e)
        {
            try
            {
                string DefPath = Application.StartupPath + "\\ContractMain.doc";
                File.Copy(DefPath, Application.StartupPath + "\\Contract.doc", overwrite: true);
                MessageBox.Show((LangArEn == 0) ? "لقد تم إستعادة التصميم الإفتراضي بنجاح .." : "This Opration Is Done", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("button_RestoreDefContract_Click:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        public static void setsyncvalue(string no)
        {
            RegistryKey hKeyNeew1 = Registry.CurrentUser.OpenSubKey("Software\\MrdHrdw\\ItIntel", writable: true);
            try
            {
                object q = hKeyNeew1.GetValue("vAutoSync");
                if (string.IsNullOrEmpty(q.ToString()))
                {
                    hKeyNeew1.CreateSubKey("vAutoSync");
                    hKeyNeew1.SetValue("vAutoSync", no);
                }
                else
                {
                    hKeyNeew1.SetValue("vAutoSync", no);
                }
            }
            catch
            {
                hKeyNeew1.CreateSubKey("vAutoSync");
                hKeyNeew1.SetValue("vAutoSync", no);
            }
        }
        public static string getbno()
        {
            RegistryKey hKeyNeew1 = Registry.CurrentUser.OpenSubKey("Software\\MrdHrdw\\ItIntel", writable: true);
            string bno = "0";
            try
            {
                object q = hKeyNeew1.GetValue("vAutoSync");
                bno = q.ToString();
            }
            catch
            {
                hKeyNeew1.CreateSubKey("vAutoSync");
                hKeyNeew1.SetValue("vAutoSync", 0);
                return bno;
            }
            return bno;
        }
        private void chk37_ValueChanged(object sender, EventArgs e)
        {
            if (chk37.Value)
            {
                setsyncvalue("1");
            }
            else
            {
                setsyncvalue("0");
            }
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
        }
        private void c1FlexGrid2_Click(object sender, EventArgs e)
        {
            Button_Edit_Click(null, null);
        }
        private void splitContainer3_Panel1_Paint(object sender, PaintEventArgs e)
        {
        }
        private void label48_Click(object sender, EventArgs e)
        {
        }
        public class ColumnDictinaryTax
        {
            public string AText = string.Empty;
            public string EText = string.Empty;
            public bool IfDefault = false;
            public string Format = string.Empty;
            public ColumnDictinaryTax(string aText, string eText, bool ifDefault, string format)
            {
                AText = aText;
                EText = eText;
                IfDefault = ifDefault;
                Format = format;
            }
        }
        public Dictionary<string, ColumnDictinaryTax> columns_Names_visibleTax = new Dictionary<string, ColumnDictinaryTax>();
        private List<T_INVSETTING> listInvSettingTax = new List<T_INVSETTING>();
        private T_INVSETTING _InvSettingTax = new T_INVSETTING();
        private List<T_SYSSETTING> listSysSettingTax = new List<T_SYSSETTING>();
        private T_SYSSETTING _SysSettingTax = new T_SYSSETTING();
        private List<T_AccDef> listAccDefTax = new List<T_AccDef>();
        private T_AccDef _AccDefTax = new T_AccDef();
        private List<T_Company> listCompanyTax = new List<T_Company>();
        private T_Company _CompanyTax = new T_Company();
        private List<T_GdAuto> listGdAutoTax = new List<T_GdAuto>();
        private T_GdAuto _GdAutoTax = new T_GdAuto();
        private List<T_InfoTb> listInfotbTax = new List<T_InfoTb>();
        private void FillComboTax()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
            {
                try
                {
                    c1FlexGriadTax.SetData(0, 1, "الفاتورة");
                    c1FlexGriadTax.SetData(0, 2, "إظهار");
                    c1FlexGriadTax.SetData(0, 3, "طباعة");
                    c1FlexGriadTax.SetData(0, 4, "ض .مبيعات");
                    c1FlexGriadTax.SetData(0, 5, "ض .مشتريات");
                    c1FlexGriadTax.SetData(0, 9, "ح. المدين - نقدي");
                    c1FlexGriadTax.SetData(0, 10, "ح. الدائن - نقدي");
                    c1FlexGriadTax.SetData(0, 11, "إصدار قيد");
                    c1FlexGriadTax.SetData(0, 12, "+ الصافي");
                    c1FlexGriadTax.SetData(0, 13, "+ السطور");
                    c1FlexGriadTax.SetData(0, 14, "إجمالي السطر");
                    c1FlexGriadTax.SetData(0, 15, "صافي الفاتورة");
                    c1FlexGriadTax.SetData(0, 16, "ح. المدين - آجل");
                    c1FlexGriadTax.SetData(0, 17, "ح. الدائن - آجل");
                    c1FlexGriadTax.SetData(1, 1, "فاتورة مبيعات");
                    c1FlexGriadTax.SetData(1, 6, 1);
                    c1FlexGriadTax.SetData(1, 7, 0);
                    c1FlexGriadTax.SetData(2, 1, "فاتورة مشتريات");
                    c1FlexGriadTax.SetData(2, 6, 2);
                    c1FlexGriadTax.SetData(2, 7, 0);
                    c1FlexGriadTax.SetData(3, 1, "مرتجع مبيعات");
                    c1FlexGriadTax.SetData(3, 6, 3);
                    c1FlexGriadTax.SetData(3, 7, 0);
                    c1FlexGriadTax.SetData(4, 1, "مرتجع مشتريات");
                    c1FlexGriadTax.SetData(4, 6, 4);
                    c1FlexGriadTax.SetData(4, 7, 0);
                    c1FlexGriadTax.SetData(5, 1, "سند أدخال بضاعة");
                    c1FlexGriadTax.SetData(5, 6, 5);
                    c1FlexGriadTax.SetData(5, 7, 0);
                    c1FlexGriadTax.SetData(6, 1, "سند أخراج بضاعة");
                    c1FlexGriadTax.SetData(6, 6, 6);
                    c1FlexGriadTax.SetData(6, 7, 0);
                    c1FlexGriadTax.SetData(7, 1, "عرض سعر عملاء");
                    c1FlexGriadTax.SetData(7, 6, 7);
                    c1FlexGriadTax.SetData(7, 7, 0);
                    c1FlexGriadTax.SetData(8, 1, "عرض سعر مورد");
                    c1FlexGriadTax.SetData(8, 6, 8);
                    c1FlexGriadTax.SetData(8, 7, 0);
                    c1FlexGriadTax.SetData(9, 1, "طلب شراء");
                    c1FlexGriadTax.SetData(9, 6, 9);
                    c1FlexGriadTax.SetData(9, 7, 0);
                    c1FlexGriadTax.SetData(10, 1, "سند تسوية بضاعة");
                    c1FlexGriadTax.SetData(10, 6, 10);
                    c1FlexGriadTax.SetData(10, 7, 0);
                    c1FlexGriadTax.SetData(11, 1, "بضاعة اول المدة");
                    c1FlexGriadTax.SetData(11, 6, 14);
                    c1FlexGriadTax.SetData(11, 7, 0);
                    c1FlexGriadTax.SetData(12, 1, "أمر صرف بضاعة");
                    c1FlexGriadTax.SetData(12, 6, 17);
                    c1FlexGriadTax.SetData(12, 7, 0);
                    c1FlexGriadTax.SetData(13, 1, "مرتجع صرف بضاعة");
                    c1FlexGriadTax.SetData(13, 6, 20);
                    c1FlexGriadTax.SetData(13, 7, 0);
                    c1FlexGriadTax.SetData(14, 1, "الطلبات المحلية");
                    c1FlexGriadTax.SetData(14, 6, 21);
                    c1FlexGriadTax.SetData(14, 7, 0);
                    if (VarGeneral.SSSLev == "R" || VarGeneral.SSSLev == "C" || VarGeneral.SSSLev == "H")
                    {
                        c1FlexGriadTax.Rows[14].Visible = true;
                    }
                    else
                    {
                        c1FlexGriadTax.Rows[14].Visible = false;
                    }
                }
                catch
                {
                }
                return;
            }
            try
            {
                c1FlexGriadTax.SetData(0, 1, "Invoice");
                c1FlexGriadTax.SetData(0, 2, "Show");
                c1FlexGriadTax.SetData(0, 3, "Print");
                c1FlexGriadTax.SetData(0, 4, "Sale Tax");
                c1FlexGriadTax.SetData(0, 5, "Purch Tax");
                c1FlexGriadTax.SetData(0, 9, "Debit Acc Cash");
                c1FlexGriadTax.SetData(0, 10, "Credit Acc Cash");
                c1FlexGriadTax.SetData(0, 11, "Create Gaid");
                c1FlexGriadTax.SetData(0, 12, "+ Net");
                c1FlexGriadTax.SetData(0, 13, "+ Lines");
                c1FlexGriadTax.SetData(0, 14, "Line Total");
                c1FlexGriadTax.SetData(0, 15, "Invoice Net");
                c1FlexGriadTax.SetData(0, 16, "Debit Acc Cr");
                c1FlexGriadTax.SetData(0, 17, "Credit Acc Cr");
                c1FlexGriadTax.SetData(1, 1, "Sales Invoice");
                c1FlexGriadTax.SetData(1, 6, 1);
                c1FlexGriadTax.SetData(1, 7, 0);
                c1FlexGriadTax.SetData(2, 1, "Purchase Receipt");
                c1FlexGriadTax.SetData(2, 6, 2);
                c1FlexGriadTax.SetData(2, 7, 0);
                c1FlexGriadTax.SetData(3, 1, "Sales Return");
                c1FlexGriadTax.SetData(3, 6, 3);
                c1FlexGriadTax.SetData(3, 7, 0);
                c1FlexGriadTax.SetData(4, 1, "Purchase Return");
                c1FlexGriadTax.SetData(4, 6, 4);
                c1FlexGriadTax.SetData(4, 7, 0);
                c1FlexGriadTax.SetData(5, 1, "Transfer In");
                c1FlexGriadTax.SetData(5, 6, 5);
                c1FlexGriadTax.SetData(5, 7, 0);
                c1FlexGriadTax.SetData(6, 1, "Transfer Out");
                c1FlexGriadTax.SetData(6, 6, 6);
                c1FlexGriadTax.SetData(6, 7, 0);
                c1FlexGriadTax.SetData(7, 1, "Customer Qutation");
                c1FlexGriadTax.SetData(7, 6, 7);
                c1FlexGriadTax.SetData(7, 7, 0);
                c1FlexGriadTax.SetData(8, 1, "Supplier Qutation");
                c1FlexGriadTax.SetData(8, 6, 8);
                c1FlexGriadTax.SetData(8, 7, 0);
                c1FlexGriadTax.SetData(9, 1, "Purchase Order");
                c1FlexGriadTax.SetData(9, 6, 9);
                c1FlexGriadTax.SetData(9, 7, 0);
                c1FlexGriadTax.SetData(10, 1, "Stock Adjustment");
                c1FlexGriadTax.SetData(10, 6, 10);
                c1FlexGriadTax.SetData(10, 7, 0);
                c1FlexGriadTax.SetData(11, 1, "Open Quantities");
                c1FlexGriadTax.SetData(11, 6, 14);
                c1FlexGriadTax.SetData(11, 7, 0);
                c1FlexGriadTax.SetData(12, 1, "Payment Order");
                c1FlexGriadTax.SetData(12, 6, 17);
                c1FlexGriadTax.SetData(12, 7, 0);
                c1FlexGriadTax.SetData(13, 1, "Payment Order Return");
                c1FlexGriadTax.SetData(13, 6, 20);
                c1FlexGriadTax.SetData(13, 7, 0);
                c1FlexGriadTax.SetData(14, 1, "Local Orders");
                c1FlexGriadTax.SetData(14, 6, 21);
                c1FlexGriadTax.SetData(14, 7, 0);
                if (VarGeneral.SSSLev == "R" || VarGeneral.SSSLev == "C" || VarGeneral.SSSLev == "H")
                {
                    c1FlexGriadTax.Rows[14].Visible = true;
                }
                else
                {
                    c1FlexGriadTax.Rows[14].Visible = false;
                }
            }
            catch
            {
            }
        }
        private void BindDataTax()
        {
            try
            {
                State = FormState.Saved;
                ButWithSave.Enabled = false;
                for (int iiCnt = 1; iiCnt < c1FlexGriadTax.Rows.Count; iiCnt++)
                {
                    for (int i = 0; i < listInvSettingTax.Count; i++)
                    {
                        _InvSettingTax = listInvSettingTax[i];
                        if (_InvSettingTax.InvID == int.Parse(c1FlexGriadTax.GetData(iiCnt, 6).ToString()))
                        {
                            c1FlexGriadTax.SetData(iiCnt, 2, VarGeneral.TString.ChkStatShow(_InvSettingTax.TaxOptions, 0));
                            c1FlexGriadTax.SetData(iiCnt, 3, VarGeneral.TString.ChkStatShow(_InvSettingTax.TaxOptions, 1));
                            c1FlexGriadTax.SetData(iiCnt, 4, VarGeneral.TString.ChkStatShow(_InvSettingTax.TaxOptions, 2));
                            c1FlexGriadTax.SetData(iiCnt, 5, VarGeneral.TString.ChkStatShow(_InvSettingTax.TaxOptions, 3));
                            c1FlexGriadTax.SetData(iiCnt, 9, _InvSettingTax.TaxDebit);
                            c1FlexGriadTax.SetData(iiCnt, 10, _InvSettingTax.TaxCredit);
                            c1FlexGriadTax.SetData(iiCnt, 11, _InvSettingTax.autoTaxGaid);
                            c1FlexGriadTax.SetData(iiCnt, 12, VarGeneral.TString.ChkStatShow(_InvSettingTax.TaxOptions, 4));
                            c1FlexGriadTax.SetData(iiCnt, 13, VarGeneral.TString.ChkStatShow(_InvSettingTax.TaxOptions, 5));
                            c1FlexGriadTax.SetData(iiCnt, 14, VarGeneral.TString.ChkStatShow(_InvSettingTax.TaxOptions, 6));
                            c1FlexGriadTax.SetData(iiCnt, 15, VarGeneral.TString.ChkStatShow(_InvSettingTax.TaxOptions, 7));
                            c1FlexGriadTax.SetData(iiCnt, 16, _InvSettingTax.TaxDebitCredit);
                            c1FlexGriadTax.SetData(iiCnt, 17, _InvSettingTax.TaxCreditCredit);
                            break;
                        }
                    }
                }
                txtPurchaesTax.Value = _SysSettingTax.DefPurchaesTax.Value;
                txtSalesTax.Value = _SysSettingTax.DefSalesTax.Value;
                txtTaxNote.Text = _SysSettingTax.TaxNoteInv;
                if (!string.IsNullOrEmpty(_SysSettingTax.TaxAcc))
                {
                    txtTaxNo.Text = _SysSettingTax.TaxAcc;
                    txtTaxName.Text = ((LangArEn == 0) ? db.StockAccDefWithOutBalance(_SysSettingTax.TaxAcc.ToString()).Arb_Des : db.StockAccDefWithOutBalance(_SysSettingTax.TaxAcc.ToString()).Eng_Des);
                    txtTaxID.Text = db.StockAccDefWithOutBalance(_SysSettingTax.TaxAcc.ToString()).TaxNo;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private T_InfoTb _InfotbTax = new T_InfoTb();
        private void RibunButtonsTax()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
            {
                ButWithSave.Text = "حفظ";
                ButWithSave.Tooltip = "F2";
                ButWithoutSave.Text = "خروج";
                ButWithoutSave.Tooltip = "Esc";
                Text = "خيارات الضريبة";
            }
            else
            {
                ButWithSave.Text = "Save";
                ButWithoutSave.Text = "Exit";
                ButWithSave.Tooltip = "F2";
                ButWithoutSave.Tooltip = "Esc";
                Text = "Taxes Options";
            }
        }
        private void c1FlexGrid1_CellChecked(object sender, RowColEventArgs e)
        {
        }
        private void txtSalesTax_Click(object sender, EventArgs e)
        {
            Button_Edit_Click(sender, e);
        }
        private void txtPurchaesTax_Click(object sender, EventArgs e)
        {
            Button_Edit_Click(sender, e);
        }
        private void ButGeneralSalesTax_Click(object sender, EventArgs e)
        {
            FrmGeneralTax frm = new FrmGeneralTax(0);
            frm.Tag = LangArEn;
            frm.txtSalesTax.Value = txtSalesTax.Value;
            frm.TopMost = true;
            frm.ShowDialog();
        }
        private void ButGeneralPurchaesTax_Click(object sender, EventArgs e)
        {
            FrmGeneralTax frm = new FrmGeneralTax(1);
            frm.Tag = LangArEn;
            frm.txtSalesTax.Value = txtPurchaesTax.Value;
            frm.TopMost = true;
            frm.ShowDialog();
        }
        private void c1FlexGrid1Tax_DoubleClick(object sender, EventArgs e)
        {
            if ((c1FlexGriadTax.Col != 9 && c1FlexGriadTax.Col != 10 && c1FlexGriadTax.Col != 16 && c1FlexGriadTax.Col != 17) || c1FlexGriadTax.Row <= 0)
            {
                return;
            }
            columns_Names_visibleTax.Clear();
            columns_Names_visibleTax.Add("AccDef_No", new ColumnDictinaryTax("الرقم ", " No", ifDefault: true, string.Empty));
            columns_Names_visibleTax.Add("Arb_Des", new ColumnDictinaryTax("الاسم عربي", "Arabic Name", ifDefault: true, string.Empty));
            columns_Names_visibleTax.Add("Eng_Des", new ColumnDictinaryTax("الاسم الانجليزي", "English Name", ifDefault: true, string.Empty));
            columns_Names_visibleTax.Add("AccDef_ID", new ColumnDictinaryTax(" ", " ", ifDefault: false, string.Empty));
            columns_Names_visibleTax.Add("Mobile", new ColumnDictinaryTax("الجوال", "Mobile", ifDefault: false, string.Empty));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinaryTax>> animalsAsCollection = columns_Names_visibleTax;
            foreach (KeyValuePair<string, ColumnDictinaryTax> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
            }
            VarGeneral.SFrmTyp = "AccDefID_Setting";
            frm.TopMost = true;
            frm.ShowDialog();
            try
            {
                if (frm.SerachNo != string.Empty)
                {
                    T_AccDef _AccDef = db.StockAccDefs(int.Parse(frm.Serach_No));
                    c1FlexGriadTax.SetData(c1FlexGriadTax.Row, c1FlexGriadTax.Col, _AccDef.AccDef_No.ToString());
                }
                else
                {
                    c1FlexGriadTax.SetData(c1FlexGriadTax.Row, c1FlexGriadTax.Col, "***");
                }
            }
            catch
            {
                c1FlexGriadTax.SetData(c1FlexGriadTax.Row, c1FlexGriadTax.Col, "***");
            }
            VarGeneral.Flush();
        }
        private void button_SrchTaxNo_Click(object sender, EventArgs e)
        {
            Button_Edit_Click(sender, e);
            columns_Names_visibleTax.Clear();
            columns_Names_visibleTax.Add("AccDef_No", new ColumnDictinaryTax("الرقم ", " No", ifDefault: true, string.Empty));
            columns_Names_visibleTax.Add("Arb_Des", new ColumnDictinaryTax("الاسم عربي", "Arabic Name", ifDefault: true, string.Empty));
            columns_Names_visibleTax.Add("Eng_Des", new ColumnDictinaryTax("الاسم الانجليزي", "English Name", ifDefault: true, string.Empty));
            columns_Names_visibleTax.Add("AccDef_ID", new ColumnDictinaryTax(" ", " ", ifDefault: false, string.Empty));
            columns_Names_visibleTax.Add("Mobile", new ColumnDictinaryTax("الجوال", "Mobile", ifDefault: false, string.Empty));
            columns_Names_visibleTax.Add("TaxNo", new ColumnDictinaryTax("الرقم الضريبي", "Tax No", ifDefault: false, string.Empty));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinaryTax>> animalsAsCollection = columns_Names_visibleTax;
            foreach (KeyValuePair<string, ColumnDictinaryTax> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
            }
            VarGeneral.SFrmTyp = "AccDefID_Setting";
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != string.Empty)
            {
                T_AccDef _AccDef = db.StockAccDefs(int.Parse(frm.Serach_No));
                txtTaxNo.Text = _AccDef.AccDef_No.ToString();
                txtTaxName.Text = ((LangArEn == 0) ? db.StockAccDefWithOutBalance(txtTaxNo.Text).Arb_Des : db.StockAccDefWithOutBalance(txtTaxNo.Text).Eng_Des);
                txtTaxID.Text = db.StockAccDefWithOutBalance(txtTaxNo.Text).TaxNo;
            }
            else
            {
                txtTaxNo.Text = string.Empty;
                txtTaxName.Text = string.Empty;
                txtTaxID.Text = string.Empty;
            }
        }
        private void txtTaxNote_Click(object sender, EventArgs e)
        {
            Button_Edit_Click(sender, e);
        }
        private void SaveDataTax()
        {
            try
            {
                for (int iiCnt = 1; iiCnt < c1FlexGriadTax.Rows.Count; iiCnt++)
                {
                    for (int i = 0; i < listInvSettingTax.Count; i++)
                    {
                        _InvSettingTax = listInvSettingTax[i];
                        if (_InvSettingTax.InvID == int.Parse(c1FlexGriadTax.GetData(iiCnt, 6).ToString()))
                        {
                            _InvSettingTax.TaxOptions = VarGeneral.TString.ChkStatSave((bool)c1FlexGriadTax.GetData(iiCnt, 2)) + VarGeneral.TString.ChkStatSave((bool)c1FlexGriadTax.GetData(iiCnt, 3)) + VarGeneral.TString.ChkStatSave((bool)c1FlexGriadTax.GetData(iiCnt, 4)) + VarGeneral.TString.ChkStatSave((bool)c1FlexGriadTax.GetData(iiCnt, 5)) + VarGeneral.TString.ChkStatSave((bool)c1FlexGriadTax.GetData(iiCnt, 12)) + VarGeneral.TString.ChkStatSave((bool)c1FlexGriadTax.GetData(iiCnt, 13)) + VarGeneral.TString.ChkStatSave((bool)c1FlexGriadTax.GetData(iiCnt, 14)) + VarGeneral.TString.ChkStatSave((bool)c1FlexGriadTax.GetData(iiCnt, 15));
                            try
                            {
                                _InvSettingTax.TaxDebit = c1FlexGriadTax.GetData(iiCnt, 9).ToString();
                            }
                            catch
                            {
                                _InvSettingTax.TaxDebit = "***";
                            }
                            try
                            {
                                _InvSettingTax.TaxCredit = c1FlexGriadTax.GetData(iiCnt, 10).ToString();
                            }
                            catch
                            {
                                _InvSettingTax.TaxCredit = "***";
                            }
                            try
                            {
                                _InvSettingTax.TaxDebitCredit = c1FlexGriadTax.GetData(iiCnt, 16).ToString();
                            }
                            catch
                            {
                                _InvSettingTax.TaxDebitCredit = "***";
                            }
                            try
                            {
                                _InvSettingTax.TaxCreditCredit = c1FlexGriadTax.GetData(iiCnt, 17).ToString();
                            }
                            catch
                            {
                                _InvSettingTax.TaxCreditCredit = "***";
                            }
                            _InvSettingTax.autoTaxGaid = Convert.ToBoolean(c1FlexGriadTax.GetData(iiCnt, 11));
                            db.Log = VarGeneral.DebugLog;
                            db.SubmitChanges(ConflictMode.ContinueOnConflict);
                            break;
                        }
                    }
                }
                db.ExecuteCommand("update T_SYSSETTING set DefSalesTax = " + txtSalesTax.Value);
                db.ExecuteCommand("update T_SYSSETTING set DefPurchaesTax = " + txtPurchaesTax.Value);
                db.ExecuteCommand("update T_SYSSETTING set TaxAcc = '" + txtTaxNo.Text + "'");
                db.ExecuteCommand("update T_SYSSETTING set TaxNoteInv = '" + txtTaxNote.Text + "'");
                using (Stock_DataDataContext dbc = new Stock_DataDataContext(VarGeneral.BranchCS))
                {
                    VarGeneral.Settings_Sys = new T_SYSSETTING();
                    VarGeneral.Settings_Sys = dbc.SystemSettingStock();
                    VarGeneral._SysDirPath = VarGeneral.Settings_Sys.SysDir;
                    VarGeneral._BackPath = VarGeneral.Settings_Sys.BackPath;
                    try
                    {
                        VarGeneral._AutoSync = VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 41);
                    }
                    catch
                    {
                        VarGeneral._AutoSync = false;
                    }
                }
                //MessageBox.Show((LangArEn == 0) ? "لقد تم اتمام العملية بنجاح .." : "This Opration Is Done", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                Close();
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Save:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void FrmTaxOpiton_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2 && ButWithSave.Enabled && ButWithSave.Visible)
            {
                ButWithSave_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
        private void FrmTaxOpiton_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                SendKeys.Send("{Tab}");
            }
        }
        void load()
        {
            ButGeneralPurchaesTax.Click += new System.EventHandler(ButGeneralPurchaesTax_Click);
            ButGeneralSalesTax.Click += new System.EventHandler(ButGeneralSalesTax_Click);
            button_SrchTaxNo.Click += new System.EventHandler(button_SrchTaxNo_Click);
            txtTaxNote.Click += new System.EventHandler(txtTaxNote_Click);

            base.KeyPress += new System.Windows.Forms.KeyPressEventHandler(FrmTaxOpiton_KeyPress);
            base.KeyDown += new System.Windows.Forms.KeyEventHandler(FrmTaxOpiton_KeyDown);
            txtPurchaesTax.Click += new System.EventHandler(txtPurchaesTax_Click);
            txtSalesTax.Click += new System.EventHandler(txtSalesTax_Click);
            //ButWithSave.Click += new System.EventHandler(ButWithSave_Click);
            //ButWithoutSave.Click += new System.EventHandler(ButExit_Click);
            // c1FlexGriadTax.CellChecked += new C1.Win.C1FlexGrid.RowColEventHandler(c1FlexGrid1_CellChecked);
            //   c1FlexGriadTax.Click += new System.EventHandler(c1FlexGrid1_Click);
            // c1FlexGriadTax.DoubleClick += new System.EventHandler(c1FlexGrid1_DoubleClick);
            try
            {
                //try
                //{
                // //   ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmTaxOpiton));
                //    if (VarGeneral.CurrentLang.ToString() == "0" ||VarGeneral.CurrentLang.ToString() == "")
                //    {
                //        Language.ChangeLanguage("ar-SA", this, resources);
                //        LangArEn = 0;
                //    }
                //    else
                //    {
                //        Language.ChangeLanguage("en", this, resources);
                //        LangArEn = 1;
                //    }
                //}
                //catch
                //{
                //}
                //RibunButtonsTax();
                listInvSettingTax = db.StockInvSettingList(VarGeneral.UserID);
                _InvSettingTax = listInvSettingTax[0];
                _SysSettingTax = db.SystemSettingStock();
                listCompanyTax = db.StockCompanyList();
                _CompanyTax = listCompanyTax[0];
                _GdAutoTax = db.GdAutoStock();
                listInfotbTax = db.StockInfoList();
                _InfotbTax = listInfotbTax[0];
                listAccDefTax = db.FillAccDef_2(string.Empty).ToList();
                listAccDefTax = listAccDefTax.Where((T_AccDef q) => q.Trn == 3 && q.Lev == 4 && q.AccDef_No.StartsWith("1") && q.AccCat != 2 && q.AccCat != 3).ToList();
                try
                {
                    FillComboTax();
                }
                catch
                {
                }
                try
                {
                    BindDataTax();
                }
                catch
                {
                }
                if (VarGeneral.SSSTyp == 0)
                {
                    c1FlexGriadTax.Cols[11].Visible = false;
                    c1FlexGriadTax.Cols[16].Visible = false;
                    c1FlexGriadTax.Cols[17].Visible = false;
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Load:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void label3Tax_Click(object sender, EventArgs e)
        {
        }
        private void ribbonBar1_ItemClick(object sender, EventArgs e)
        {
        }
        private void buttonX1_Click(object sender, EventArgs e)
        {
            try
            {
                FrmPointsCalc frm = new FrmPointsCalc();
                frm.Tag = LangArEn;
                frm.TopMost = true;
                frm.ShowDialog();
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("button_PointOfCust_Click:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            c1FlexGrid2.AllowFiltering = true;
            var filter = new ConditionFilter();
            // configure filter to select items that start with "C"
            filter.Condition1.Operator = ConditionOperator.Contains;
            filter.Condition1.Parameter = textBox1.Text;
            // assign new filter to column "ProductName"
            c1FlexGrid2.Cols[1].Filter = filter;
        }
        private void txtRightRep_ValueChanged(object sender, EventArgs e)
        {
        }
        private void c1FlexGriadTax_Click(object sender, EventArgs e)
        {
            if ((c1FlexGriadTax.Col != 9 && c1FlexGriadTax.Col != 10 && c1FlexGriadTax.Col != 16 && c1FlexGriadTax.Col != 17) || c1FlexGriadTax.Row <= 0)
            {
                return;
            }
            columns_Names_visibleTax.Clear();
            columns_Names_visibleTax.Add("AccDef_No", new ColumnDictinaryTax("الرقم ", " No", ifDefault: true, string.Empty));
            columns_Names_visibleTax.Add("Arb_Des", new ColumnDictinaryTax("الاسم عربي", "Arabic Name", ifDefault: true, string.Empty));
            columns_Names_visibleTax.Add("Eng_Des", new ColumnDictinaryTax("الاسم الانجليزي", "English Name", ifDefault: true, string.Empty));
            columns_Names_visibleTax.Add("AccDef_ID", new ColumnDictinaryTax(" ", " ", ifDefault: false, string.Empty));
            columns_Names_visibleTax.Add("Mobile", new ColumnDictinaryTax("الجوال", "Mobile", ifDefault: false, string.Empty));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinaryTax>> animalsAsCollection = columns_Names_visibleTax;
            foreach (KeyValuePair<string, ColumnDictinaryTax> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
            }
            VarGeneral.SFrmTyp = "AccDefID_Setting";
            frm.TopMost = true;
            frm.ShowDialog();
            try
            {
                if (frm.SerachNo != string.Empty)
                {
                    T_AccDef _AccDef = db.StockAccDefs(int.Parse(frm.Serach_No));
                    c1FlexGriadTax.SetData(c1FlexGriadTax.Row, c1FlexGriadTax.Col, _AccDef.AccDef_No.ToString());
                }
                else
                {
                    c1FlexGriadTax.SetData(c1FlexGriadTax.Row, c1FlexGriadTax.Col, "***");
                }
            }
            catch
            {
                c1FlexGriadTax.SetData(c1FlexGriadTax.Row, c1FlexGriadTax.Col, "***");
            }
            VarGeneral.Flush();
        }
        private void c1FlexGriadTax_CellChecked(object sender, RowColEventArgs e)
        {
            if (e.Col != 4 && e.Col != 5)
            {
                return;
            }
            if (e.Col == 4)
            {
                if (Convert.ToBoolean(c1FlexGriadTax.Rows[e.Row][4]))
                {
                    c1FlexGriadTax.Rows[e.Row][5] = false;
                }
                else
                {
                    c1FlexGriadTax.Rows[e.Row][5] = true;
                }
            }
            else if (Convert.ToBoolean(c1FlexGriadTax.Rows[e.Row][5]))
            {
                c1FlexGriadTax.Rows[e.Row][4] = false;
            }
            else
            {
                c1FlexGriadTax.Rows[e.Row][4] = true;
            }
        }
        private void c1FlexGriadTax_DoubleClick(object sender, EventArgs e)
        {
            if ((c1FlexGriadTax.Col != 9 && c1FlexGriadTax.Col != 10 && c1FlexGriadTax.Col != 16 && c1FlexGriadTax.Col != 17) || c1FlexGriadTax.Row <= 0)
            {
                return;
            }
            columns_Names_visibleTax.Clear();
            columns_Names_visibleTax.Add("AccDef_No", new ColumnDictinaryTax("الرقم ", " No", ifDefault: true, string.Empty));
            columns_Names_visibleTax.Add("Arb_Des", new ColumnDictinaryTax("الاسم عربي", "Arabic Name", ifDefault: true, string.Empty));
            columns_Names_visibleTax.Add("Eng_Des", new ColumnDictinaryTax("الاسم الانجليزي", "English Name", ifDefault: true, string.Empty));
            columns_Names_visibleTax.Add("AccDef_ID", new ColumnDictinaryTax(" ", " ", ifDefault: false, string.Empty));
            columns_Names_visibleTax.Add("Mobile", new ColumnDictinaryTax("الجوال", "Mobile", ifDefault: false, string.Empty));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinaryTax>> animalsAsCollection = columns_Names_visibleTax;
            foreach (KeyValuePair<string, ColumnDictinaryTax> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
            }
            VarGeneral.SFrmTyp = "AccDefID_Setting";
            frm.TopMost = true;
            frm.ShowDialog();
            try
            {
                if (frm.SerachNo != string.Empty)
                {
                    T_AccDef _AccDef = db.StockAccDefs(int.Parse(frm.Serach_No));
                    c1FlexGriadTax.SetData(c1FlexGriadTax.Row, c1FlexGriadTax.Col, _AccDef.AccDef_No.ToString());
                }
                else
                {
                    c1FlexGriadTax.SetData(c1FlexGriadTax.Row, c1FlexGriadTax.Col, "***");
                }
            }
            catch
            {
                c1FlexGriadTax.SetData(c1FlexGriadTax.Row, c1FlexGriadTax.Col, "***");
            }
            VarGeneral.Flush();
        }
        private void groupPanel_Backup_Click(object sender, EventArgs e)
        {
        }
        private void chk45_CheckedChanged(object sender, EventArgs e)
        {
            numbersafterdecimal.Enabled = chk45.Checked;
        }
        private void numberofdecimal_KeyDown(object sender, KeyEventArgs e)
        {
            if (!char.IsDigit((char)e.KeyValue))
            {
                e.Handled = true;
            }
        }

        private void CmbDateTyp_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void c1FlexGrid2_SelChange(object sender, EventArgs e)
        {

            if (Environment.MachineName.Contains("DESKTOP-320H5U2"))
            {
                this.Text = nn[c1FlexGrid2.RowSel - 1].ToString();
            }
        }
    }
}
