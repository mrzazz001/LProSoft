using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.DotNetBar.SuperGrid;
using DevComponents.DotNetBar.SuperGrid.Style;
using DevComponents.Editors;
using Framework.Data;
using InvAcc.GeneralM;
using InvAcc.Stock_Data;
using Microsoft.Win32;
using SSSDateTime.Date;
using SSSLanguage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial class FrmAdvances : Form
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
                        frm.Repvalue = "AdvancRep";


                        frm.Repvalue = "AdvancRep";
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
        private ExpandableSplitter expandableSplitter1;
        private PanelEx panelEx2;
        private RibbonBar ribbonBar1;
        private SaveFileDialog saveFileDialog1;
        protected SuperGridControl DGV_Main;
        private PanelEx panelEx3;
        private Timer timerInfoBallon;
        private OpenFileDialog openFileDialog1;
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
        protected ButtonItem Button_Delete;
        protected ButtonItem Button_Save;
        protected ButtonItem Button_Add;
        protected LabelItem labelItem2;
        private RibbonBar ribbonBar_DGV;
        private SuperTabControl superTabControl_DGV;
        protected TextBoxItem textBox_search;
        protected ButtonItem Button_ExportTable2;
        protected ButtonItem Button_PrintTable;
        protected LabelItem labelItem3;
        private Panel panel2;
        private MaskedTextBox textBox_SalDate;
        private ComboBoxEx comboBox_EmpNo;
        private ButtonX button_SrchEmp;
        private Label label12;
        private MaskedTextBox dateTimeInput_warnDate;
        protected TextBox textBox_ID;
        protected Label label38;
        private TextBoxX textBox_Note;
        private DataGridViewX dataGridViewX_Advances;
        private IntegerInput textBox_TotalPremiums;
        private DoubleInput textBox_ValueAdvances;
        private Label label11;
        private Label label2;
        private GroupPanel groupPanel1;
        private Panel panel3;
        private Panel panel4;
        private Panel panel_Acc;
        private SwitchButton switchButton_AccType;
        private TextBox txtBXBankName;
        private ButtonX button_SrchBXBankNo;
        private TextBox txtBXBankNo;
        private CheckBoxX checkBox_AccID;
        private Panel panel6;
        private DoubleInput textBox_ValuePremium;
        private DataGridViewTextBoxColumn Premiums_No;
        private DataGridViewTextBoxColumn PremiumsDate;
        private DataGridViewDoubleInputColumn ValuePremiums;
        private DataGridViewDoubleInputColumn Paying;
        private DataGridViewCheckBoxColumn IFState;
        private DataGridViewTextBoxColumn Premiums_ID;
        private DataGridViewTextBoxColumn Advances_No;
        private Label label1;
        private DoubleInput textBox_ResidualValue;
        private Label label4;
        private DoubleInput textBox_Remaining;
        private Label label3;
        private ButtonX button_SavePremuim;
        private ButtonItem buttonItem_Cancel;
        private TextBox txtBXLoanNo;
        internal Label label5;
        private ButtonX button_ScrhLoan;
        private TextBox txtBXLoanName;
        private TextBox txtBXCostCenterNo;
        private TextBox txtBXCostCenterName;
        private ButtonX button_SrchCostCenter;
        internal Label label6;
        private ButtonX button_CustD3;
        private ButtonX button_CustD1;
        private DoubleInput textBox_Salary;
        private Label label7;
        private LabelItem lable_Records;
        internal Label label8;
        private ComboBoxEx CmbCurr;
        public Dictionary<string, ColumnDictinary> columns_Names_visible = new Dictionary<string, ColumnDictinary>();
        private HijriGreg.HijriGregDates n = new HijriGreg.HijriGregDates();
        private T_AccDef _AccDefBind = new T_AccDef();
        private int LangArEn = 0;
        protected bool ifOkDelete;
        public bool CanEdit = true;
        protected bool CanInsert = true;
        private string FlagUpdate = "";
        public ViewState ViewState = ViewState.Deiles;
        private FormState statex;
        public List<Control> controls;
        public Control codeControl = new Control();
        private bool canUpdate = true;
        private List<string> pkeys = new List<string>();
        private Stock_DataDataContext dbInstance;
        private T_Advance data_this;
        private BindingList<T_Premium> Ldata_instance;
        private Rate_DataDataContext dbInstanceRate;
        private T_User permission = new T_User();
        private Dictionary<string, ColumnDictinary> Dir_ButSearch = new Dictionary<string, ColumnDictinary>();
        private T_GDHEAD _GdHead = new T_GDHEAD();
        private List<T_GDHEAD> listGdHead = new List<T_GDHEAD>();
        private T_GDDET _GdDet = new T_GDDET();
        private List<T_GDDET> listGdDet = new List<T_GDDET>();
        private bool StopSetData = false;
        private ScriptNumber ScriptNumber1 = new ScriptNumber();
        private T_Premium data_this_Pre;
        public Dictionary<string, ColumnDictinary> columns_Names_visible2 = new Dictionary<string, ColumnDictinary>();
        private double oldValue = 0.0;
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
        public T_Advance DataThis
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
        public T_Premium getLineNewInstance => new T_Premium();
        public BindingList<T_Premium> LDataThis
        {
            get
            {
                return Ldata_instance;
            }
            set
            {
                Ldata_instance = value;
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
                    if (!VarGeneral.TString.ChkStatShow(value.Emp_MovStr, 17))
                    {
                        IfAdd = false;
                    }
                    else
                    {
                        IfAdd = true;
                    }
                    if (!VarGeneral.TString.ChkStatShow(value.Emp_MovStr, 18) || !canUpdate)
                    {
                        CanEdit = false;
                    }
                    else
                    {
                        CanEdit = true;
                    }
                    if (!VarGeneral.TString.ChkStatShow(value.Emp_MovStr, 19) || !canUpdate)
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
        public T_Premium DataThisPre
        {
            get
            {
                return data_this_Pre;
            }
            set
            {
                data_this_Pre = value;
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
            this.PanelSpecialContainer = new System.Windows.Forms.Panel();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAdvances));
            DevComponents.DotNetBar.SuperGrid.Style.Background background1 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.Style.Background background2 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.Style.Background background3 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.Style.BorderColor borderColor1 = new DevComponents.DotNetBar.SuperGrid.Style.BorderColor();
            DevComponents.DotNetBar.SuperGrid.Style.BorderColor borderColor2 = new DevComponents.DotNetBar.SuperGrid.Style.BorderColor();
            DevComponents.DotNetBar.SuperGrid.Style.BaseTreeButtonVisualStyle baseTreeButtonVisualStyle1 = new DevComponents.DotNetBar.SuperGrid.Style.BaseTreeButtonVisualStyle();
            DevComponents.DotNetBar.SuperGrid.Style.BaseTreeButtonVisualStyle baseTreeButtonVisualStyle2 = new DevComponents.DotNetBar.SuperGrid.Style.BaseTreeButtonVisualStyle();
            DevComponents.DotNetBar.SuperGrid.Style.Background background4 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.expandableSplitter1 = new DevComponents.DotNetBar.ExpandableSplitter();
            this.panelEx2 = new DevComponents.DotNetBar.PanelEx();
            this.ribbonBar1 = new DevComponents.DotNetBar.RibbonBar();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_Salary = new DevComponents.Editors.DoubleInput();
            this.label1 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.checkBox_AccID = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.panel4 = new System.Windows.Forms.Panel();
            this.button_SavePremuim = new DevComponents.DotNetBar.ButtonX();
            this.buttonItem_Cancel = new DevComponents.DotNetBar.ButtonItem();
            this.textBox_ResidualValue = new DevComponents.Editors.DoubleInput();
            this.label4 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.textBox_Remaining = new DevComponents.Editors.DoubleInput();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_TotalPremiums = new DevComponents.Editors.IntegerInput();
            this.textBox_ValueAdvances = new DevComponents.Editors.DoubleInput();
            this.label11 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_Note = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.textBox_SalDate = new System.Windows.Forms.MaskedTextBox();
            this.button_SrchEmp = new DevComponents.DotNetBar.ButtonX();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.dataGridViewX_Advances = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.Premiums_No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PremiumsDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValuePremiums = new DevComponents.DotNetBar.Controls.DataGridViewDoubleInputColumn();
            this.Paying = new DevComponents.DotNetBar.Controls.DataGridViewDoubleInputColumn();
            this.IFState = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Premiums_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Advances_No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textBox_ValuePremium = new DevComponents.Editors.DoubleInput();
            this.comboBox_EmpNo = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label12 = new System.Windows.Forms.Label();
            this.dateTimeInput_warnDate = new System.Windows.Forms.MaskedTextBox();
            this.textBox_ID = new System.Windows.Forms.TextBox();
            this.label38 = new System.Windows.Forms.Label();
            this.panel_Acc = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.CmbCurr = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.button_CustD3 = new DevComponents.DotNetBar.ButtonX();
            this.button_CustD1 = new DevComponents.DotNetBar.ButtonX();
            this.txtBXCostCenterNo = new System.Windows.Forms.TextBox();
            this.txtBXLoanNo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button_ScrhLoan = new DevComponents.DotNetBar.ButtonX();
            this.switchButton_AccType = new DevComponents.DotNetBar.Controls.SwitchButton();
            this.button_SrchBXBankNo = new DevComponents.DotNetBar.ButtonX();
            this.txtBXBankNo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button_SrchCostCenter = new DevComponents.DotNetBar.ButtonX();
            this.txtBXCostCenterName = new System.Windows.Forms.TextBox();
            this.txtBXLoanName = new System.Windows.Forms.TextBox();
            this.txtBXBankName = new System.Windows.Forms.TextBox();
            this.ribbonBar_Tasks = new DevComponents.DotNetBar.RibbonBar();
            this.superTabControl_Main1 = new DevComponents.DotNetBar.SuperTabControl();
            this.Button_Close = new DevComponents.DotNetBar.ButtonItem();
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
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.DGV_Main = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            this.panelEx3 = new DevComponents.DotNetBar.PanelEx();
            this.ribbonBar_DGV = new DevComponents.DotNetBar.RibbonBar();
            this.superTabControl_DGV = new DevComponents.DotNetBar.SuperTabControl();
            this.textBox_search = new DevComponents.DotNetBar.TextBoxItem();
            this.Button_ExportTable2 = new DevComponents.DotNetBar.ButtonItem();
            this.Button_PrintTable = new DevComponents.DotNetBar.ButtonItem();
            this.labelItem3 = new DevComponents.DotNetBar.LabelItem();
            this.timerInfoBallon = new System.Windows.Forms.Timer(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
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
            this.netResize1 = new Softgroup.NetResize.NetResize(this.components);
            this.netResize1.AfterControlResize += new Softgroup.NetResize.NetResize.AfterControlResizeEventHandler(this.netResize1_AfterControlResize);
            this.Shown += new System.EventHandler(this.FrmInvSale_Shown);
            this.SizeChanged += new System.EventHandler(this.FrmInvSale_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).BeginInit();
            this.panelEx2.SuspendLayout();
            this.ribbonBar1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_Salary)).BeginInit();
            this.panel6.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_ResidualValue)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_Remaining)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_TotalPremiums)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_ValueAdvances)).BeginInit();
            this.groupPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX_Advances)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_ValuePremium)).BeginInit();
            this.panel_Acc.SuspendLayout();
            this.ribbonBar_Tasks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl_Main1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl_Main2)).BeginInit();
            this.panelEx3.SuspendLayout();
            this.ribbonBar_DGV.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl_DGV)).BeginInit();
            this.panel1.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
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
            this.expandableSplitter1.Location = new System.Drawing.Point(0, -2);
            this.expandableSplitter1.Name = "expandableSplitter1";
            this.expandableSplitter1.Size = new System.Drawing.Size(647, 14);
            this.expandableSplitter1.TabIndex = 1;
            this.expandableSplitter1.TabStop = false;
            // 
            // panelEx2
            // 
            this.PanelSpecialContainer.Controls.Add(this.ribbonBar1);
            this.ribbonBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelSpecialContainer.Controls.Add(this.ribbonBar_Tasks);
            this.superTabControl_Main1.RightToLeftChanged += new System.EventHandler(this.superTabControl_Main1_RightToLeftChanged);
            this.panelEx2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelEx2.Location = new System.Drawing.Point(0, 12);
            this.panelEx2.Name = "panelEx2";
            this.panelEx2.Size = new System.Drawing.Size(647, 416);
            this.panelEx2.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx2.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
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
            this.ribbonBar1.BackgroundStyle.BackColor = System.Drawing.Color.Gainsboro;
            this.ribbonBar1.BackgroundStyle.BackColor2 = System.Drawing.Color.Gainsboro;
            this.ribbonBar1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar1.ContainerControlProcessDialogKey = true;
            this.ribbonBar1.Controls.Add(this.panel2);
            this.ribbonBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonBar1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.ribbonBar1.Location = new System.Drawing.Point(0, 0);
            this.ribbonBar1.Name = "ribbonBar1";
            this.ribbonBar1.Size = new System.Drawing.Size(647, 365);
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
            // panel2
            // 
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.textBox_Salary);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.textBox_Note);
            this.panel2.Controls.Add(this.textBox_SalDate);
            this.panel2.Controls.Add(this.button_SrchEmp);
            this.panel2.Controls.Add(this.groupPanel1);
            this.panel2.Controls.Add(this.comboBox_EmpNo);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.dateTimeInput_warnDate);
            this.panel2.Controls.Add(this.textBox_ID);
            this.panel2.Controls.Add(this.label38);
            this.panel2.Controls.Add(this.panel_Acc);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(647, 348);
            this.panel2.TabIndex = 6709;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(110, 45);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 13);
            this.label7.TabIndex = 8557;
            this.label7.Text = "?????????????????????????? :";
            // 
            // textBox_Salary
            // 
            this.textBox_Salary.AllowEmptyState = false;
            this.textBox_Salary.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Salary.AutoOffFreeTextEntry = true;
            this.textBox_Salary.AutoResolveFreeTextEntries = false;
            // 
            // 
            // 
            this.textBox_Salary.BackgroundStyle.BorderBottomWidth = 1;
            this.textBox_Salary.BackgroundStyle.Class = "DateTimeInputBackground";
            this.textBox_Salary.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBox_Salary.BackgroundStyle.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Salary.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.textBox_Salary.DisplayFormat = "0.00";
            this.textBox_Salary.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.textBox_Salary.Increment = 1D;
            this.textBox_Salary.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.textBox_Salary.IsInputReadOnly = true;
            this.textBox_Salary.Location = new System.Drawing.Point(16, 41);
            this.textBox_Salary.MinValue = 0D;
            this.textBox_Salary.Name = "textBox_Salary";
            this.textBox_Salary.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox_Salary.Size = new System.Drawing.Size(93, 21);
            this.textBox_Salary.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(110, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 8554;
            this.label1.Text = "???????? ?????????? :";
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel6.Controls.Add(this.checkBox_AccID);
            this.panel6.Location = new System.Drawing.Point(16, 215);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(176, 31);
            this.panel6.TabIndex = 8553;
            // 
            // checkBox_AccID
            // 
            // 
            // 
            // 
            this.checkBox_AccID.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBox_AccID.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.checkBox_AccID.Location = new System.Drawing.Point(7, 4);
            this.checkBox_AccID.Name = "checkBox_AccID";
            this.checkBox_AccID.Size = new System.Drawing.Size(159, 23);
            this.checkBox_AccID.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBox_AccID.TabIndex = 9;
            this.checkBox_AccID.Text = "?????????? ?????? ???????????? ????????????";
            this.checkBox_AccID.CheckedChanged += new System.EventHandler(this.checkBox_AccID_CheckedChanged);
            this.checkBox_AccID.Click += new System.EventHandler(this.checkBox_AccID_Click);
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.button_SavePremuim);
            this.panel4.Controls.Add(this.textBox_ResidualValue);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Location = new System.Drawing.Point(16, 158);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(176, 56);
            this.panel4.TabIndex = 6773;
            // 
            // button_SavePremuim
            // 
            this.button_SavePremuim.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SavePremuim.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SavePremuim.Location = new System.Drawing.Point(7, 7);
            this.button_SavePremuim.Name = "button_SavePremuim";
            this.button_SavePremuim.Size = new System.Drawing.Size(158, 43);
            this.button_SavePremuim.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SavePremuim.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.buttonItem_Cancel});
            this.button_SavePremuim.Symbol = "???";
            this.button_SavePremuim.SymbolSize = 12F;
            this.button_SavePremuim.TabIndex = 6743;
            this.button_SavePremuim.Text = "?????? ??????????????";
            this.button_SavePremuim.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SavePremuim.Visible = false;
            this.button_SavePremuim.VisibleChanged += new System.EventHandler(this.button_SavePremuim_VisibleChanged);
            this.button_SavePremuim.Click += new System.EventHandler(this.button_SavePremuim_Click);
            // 
            // buttonItem_Cancel
            // 
            this.buttonItem_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.MagentaWithBackground;
            this.buttonItem_Cancel.GlobalItem = false;
            this.buttonItem_Cancel.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Center;
            this.buttonItem_Cancel.Name = "buttonItem_Cancel";
            this.buttonItem_Cancel.Symbol = "???";
            this.buttonItem_Cancel.SymbolSize = 11F;
            this.buttonItem_Cancel.Text = "??????????";
            this.buttonItem_Cancel.Click += new System.EventHandler(this.buttonItem_Cancel_Click);
            // 
            // textBox_ResidualValue
            // 
            this.textBox_ResidualValue.AllowEmptyState = false;
            this.textBox_ResidualValue.AutoOffFreeTextEntry = true;
            this.textBox_ResidualValue.AutoResolveFreeTextEntries = false;
            // 
            // 
            // 
            this.textBox_ResidualValue.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.textBox_ResidualValue.BackgroundStyle.BorderBottomWidth = 1;
            this.textBox_ResidualValue.BackgroundStyle.Class = "DateTimeInputBackground";
            this.textBox_ResidualValue.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBox_ResidualValue.BackgroundStyle.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_ResidualValue.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.textBox_ResidualValue.DisplayFormat = "0.00";
            this.textBox_ResidualValue.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.textBox_ResidualValue.ForeColor = System.Drawing.Color.White;
            this.textBox_ResidualValue.Increment = 1D;
            this.textBox_ResidualValue.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.textBox_ResidualValue.IsInputReadOnly = true;
            this.textBox_ResidualValue.Location = new System.Drawing.Point(27, 27);
            this.textBox_ResidualValue.MinValue = 0D;
            this.textBox_ResidualValue.Name = "textBox_ResidualValue";
            this.textBox_ResidualValue.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox_ResidualValue.Size = new System.Drawing.Size(121, 21);
            this.textBox_ResidualValue.TabIndex = 6742;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.Navy;
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(17, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 13);
            this.label4.TabIndex = 6741;
            this.label4.Text = "???????????? ?????????? ???????? ????????";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.textBox_Remaining);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.textBox_TotalPremiums);
            this.panel3.Controls.Add(this.textBox_ValueAdvances);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Location = new System.Drawing.Point(16, 70);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(176, 87);
            this.panel3.TabIndex = 6772;
            // 
            // textBox_Remaining
            // 
            this.textBox_Remaining.AllowEmptyState = false;
            this.textBox_Remaining.AutoOffFreeTextEntry = true;
            this.textBox_Remaining.AutoResolveFreeTextEntries = false;
            // 
            // 
            // 
            this.textBox_Remaining.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.textBox_Remaining.BackgroundStyle.BorderBottomWidth = 1;
            this.textBox_Remaining.BackgroundStyle.Class = "DateTimeInputBackground";
            this.textBox_Remaining.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBox_Remaining.BackgroundStyle.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Remaining.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.textBox_Remaining.DisplayFormat = "0.00";
            this.textBox_Remaining.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.textBox_Remaining.Increment = 1D;
            this.textBox_Remaining.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.textBox_Remaining.IsInputReadOnly = true;
            this.textBox_Remaining.Location = new System.Drawing.Point(7, 59);
            this.textBox_Remaining.MinValue = 0D;
            this.textBox_Remaining.Name = "textBox_Remaining";
            this.textBox_Remaining.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox_Remaining.Size = new System.Drawing.Size(87, 21);
            this.textBox_Remaining.TabIndex = 8;
            this.textBox_Remaining.ValueChanged += new System.EventHandler(this.textBox_Remaining_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(93, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 6741;
            this.label3.Text = "?????????????????????????????? :";
            // 
            // textBox_TotalPremiums
            // 
            this.textBox_TotalPremiums.AllowEmptyState = false;
            // 
            // 
            // 
            this.textBox_TotalPremiums.BackgroundStyle.BackColor = System.Drawing.Color.SteelBlue;
            this.textBox_TotalPremiums.BackgroundStyle.Class = "DateTimeInputBackground";
            this.textBox_TotalPremiums.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBox_TotalPremiums.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.textBox_TotalPremiums.DisplayFormat = "0";
            this.textBox_TotalPremiums.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.textBox_TotalPremiums.ForeColor = System.Drawing.Color.White;
            this.textBox_TotalPremiums.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.textBox_TotalPremiums.Location = new System.Drawing.Point(7, 33);
            this.textBox_TotalPremiums.MinValue = 0;
            this.textBox_TotalPremiums.Name = "textBox_TotalPremiums";
            this.textBox_TotalPremiums.Size = new System.Drawing.Size(87, 21);
            this.textBox_TotalPremiums.TabIndex = 7;
            this.textBox_TotalPremiums.WatermarkAlignment = DevComponents.Editors.eTextAlignment.Center;
            this.textBox_TotalPremiums.ValueChanged += new System.EventHandler(this.textBox_TotalPremiums_ValueChanged);
            // 
            // textBox_ValueAdvances
            // 
            this.textBox_ValueAdvances.AllowEmptyState = false;
            this.textBox_ValueAdvances.AutoOffFreeTextEntry = true;
            this.textBox_ValueAdvances.AutoResolveFreeTextEntries = false;
            // 
            // 
            // 
            this.textBox_ValueAdvances.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.textBox_ValueAdvances.BackgroundStyle.BorderBottomWidth = 1;
            this.textBox_ValueAdvances.BackgroundStyle.Class = "DateTimeInputBackground";
            this.textBox_ValueAdvances.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBox_ValueAdvances.BackgroundStyle.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_ValueAdvances.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.textBox_ValueAdvances.DisplayFormat = "0.00";
            this.textBox_ValueAdvances.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.textBox_ValueAdvances.Increment = 1D;
            this.textBox_ValueAdvances.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.textBox_ValueAdvances.Location = new System.Drawing.Point(7, 6);
            this.textBox_ValueAdvances.MinValue = 0D;
            this.textBox_ValueAdvances.Name = "textBox_ValueAdvances";
            this.textBox_ValueAdvances.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox_ValueAdvances.Size = new System.Drawing.Size(87, 21);
            this.textBox_ValueAdvances.TabIndex = 6;
            this.textBox_ValueAdvances.ValueChanged += new System.EventHandler(this.textBox_ValueAdvances_ValueChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label11.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label11.Location = new System.Drawing.Point(93, 37);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(75, 13);
            this.label11.TabIndex = 6738;
            this.label11.Text = "???????? ?????????????? :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(93, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 6737;
            this.label2.Text = "???????? ?????????????? :";
            // 
            // textBox_Note
            // 
            this.textBox_Note.BackColor = System.Drawing.Color.AliceBlue;
            // 
            // 
            // 
            this.textBox_Note.Border.Class = "TextBoxBorder";
            this.textBox_Note.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBox_Note.ButtonCustom.Visible = true;
            this.textBox_Note.ForeColor = System.Drawing.Color.Black;
            this.textBox_Note.Location = new System.Drawing.Point(16, 310);
            this.textBox_Note.Multiline = true;
            this.textBox_Note.Name = "textBox_Note";
            this.textBox_Note.Size = new System.Drawing.Size(615, 33);
            this.textBox_Note.TabIndex = 10;
            this.textBox_Note.WatermarkColor = System.Drawing.Color.RosyBrown;
            this.textBox_Note.WatermarkFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Note.WatermarkImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.textBox_Note.WatermarkText = "???????????????????????????? ????????????????????????";
            // 
            // textBox_SalDate
            // 
            this.textBox_SalDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.textBox_SalDate.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.textBox_SalDate.ForeColor = System.Drawing.Color.Black;
            this.textBox_SalDate.Location = new System.Drawing.Point(16, 14);
            this.textBox_SalDate.Mask = "0000/00";
            this.textBox_SalDate.Name = "textBox_SalDate";
            this.textBox_SalDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox_SalDate.Size = new System.Drawing.Size(93, 21);
            this.textBox_SalDate.TabIndex = 3;
            this.textBox_SalDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_SalDate.Click += new System.EventHandler(this.textBox_SalDate_Click);
            this.textBox_SalDate.Leave += new System.EventHandler(this.textBox_SalDate_Leave);
            // 
            // button_SrchEmp
            // 
            this.button_SrchEmp.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchEmp.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchEmp.Location = new System.Drawing.Point(195, 42);
            this.button_SrchEmp.Name = "button_SrchEmp";
            this.button_SrchEmp.Size = new System.Drawing.Size(26, 20);
            this.button_SrchEmp.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchEmp.Symbol = "???";
            this.button_SrchEmp.SymbolSize = 12F;
            this.button_SrchEmp.TabIndex = 6714;
            this.button_SrchEmp.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchEmp.Click += new System.EventHandler(this.button_SrchEmp_Click);
            // 
            // groupPanel1
            // 
            this.groupPanel1.BackColor = System.Drawing.Color.White;
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.dataGridViewX_Advances);
            this.groupPanel1.Controls.Add(this.textBox_ValuePremium);
            this.groupPanel1.Location = new System.Drawing.Point(195, 70);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(436, 177);
            // 
            // 
            // 
            this.groupPanel1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.CustomizeBackground;
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
            // 
            // 
            // 
            this.groupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel1.TabIndex = 6769;
            this.groupPanel1.Text = "?????????????? ??????????????????????";
            // 
            // dataGridViewX_Advances
            // 
            this.dataGridViewX_Advances.AllowUserToAddRows = false;
            this.dataGridViewX_Advances.AllowUserToDeleteRows = false;
            this.dataGridViewX_Advances.AllowUserToResizeColumns = false;
            this.dataGridViewX_Advances.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            this.dataGridViewX_Advances.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewX_Advances.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGridViewX_Advances.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewX_Advances.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewX_Advances.ColumnHeadersHeight = 25;
            this.dataGridViewX_Advances.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewX_Advances.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Premiums_No,
            this.PremiumsDate,
            this.ValuePremiums,
            this.Paying,
            this.IFState,
            this.Premiums_ID,
            this.Advances_No});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewX_Advances.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewX_Advances.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridViewX_Advances.EnableHeadersVisualStyles = false;
            this.dataGridViewX_Advances.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dataGridViewX_Advances.HighlightSelectedColumnHeaders = false;
            this.dataGridViewX_Advances.Location = new System.Drawing.Point(3, 5);
            this.dataGridViewX_Advances.MultiSelect = false;
            this.dataGridViewX_Advances.Name = "dataGridViewX_Advances";
            this.dataGridViewX_Advances.PaintEnhancedSelection = false;
            this.dataGridViewX_Advances.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewX_Advances.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewX_Advances.RowHeadersVisible = false;
            this.dataGridViewX_Advances.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.White;
            this.dataGridViewX_Advances.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewX_Advances.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewX_Advances.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.dataGridViewX_Advances.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewX_Advances.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            this.dataGridViewX_Advances.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewX_Advances.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridViewX_Advances.Size = new System.Drawing.Size(422, 146);
            this.dataGridViewX_Advances.TabIndex = 6734;
            this.dataGridViewX_Advances.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridViewX_Advances_CellBeginEdit);
            this.dataGridViewX_Advances.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewX_Advances_CellEndEdit);
            this.dataGridViewX_Advances.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewX_Advances_CellMouseClick);
            this.dataGridViewX_Advances.Click += new System.EventHandler(this.dataGridViewX_Advances_Click);
            // 
            // Premiums_No
            // 
            this.Premiums_No.HeaderText = "Premiums_No";
            this.Premiums_No.Name = "Premiums_No";
            this.Premiums_No.ReadOnly = true;
            this.Premiums_No.Width = 55;
            // 
            // PremiumsDate
            // 
            this.PremiumsDate.HeaderText = "PremiumsDate";
            this.PremiumsDate.Name = "PremiumsDate";
            this.PremiumsDate.ReadOnly = true;
            this.PremiumsDate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.PremiumsDate.Width = 70;
            // 
            // ValuePremiums
            // 
            // 
            // 
            // 
            this.ValuePremiums.BackgroundStyle.Class = "DataGridViewNumericBorder";
            this.ValuePremiums.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ValuePremiums.HeaderText = "ValuePremiums";
            this.ValuePremiums.Increment = 1D;
            this.ValuePremiums.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.ValuePremiums.MinValue = 0D;
            this.ValuePremiums.Name = "ValuePremiums";
            this.ValuePremiums.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ValuePremiums.Width = 115;
            // 
            // Paying
            // 
            // 
            // 
            // 
            this.Paying.BackgroundStyle.Class = "DataGridViewNumericBorder";
            this.Paying.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Paying.HeaderText = "Paying";
            this.Paying.Increment = 1D;
            this.Paying.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.Paying.MinValue = 0D;
            this.Paying.Name = "Paying";
            this.Paying.ReadOnly = true;
            this.Paying.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Paying.Width = 115;
            // 
            // IFState
            // 
            this.IFState.HeaderText = "IFState";
            this.IFState.Name = "IFState";
            this.IFState.ReadOnly = true;
            this.IFState.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IFState.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.IFState.Width = 63;
            // 
            // Premiums_ID
            // 
            this.Premiums_ID.HeaderText = "Premiums_ID";
            this.Premiums_ID.Name = "Premiums_ID";
            this.Premiums_ID.Visible = false;
            // 
            // Advances_No
            // 
            this.Advances_No.HeaderText = "Advances_No";
            this.Advances_No.Name = "Advances_No";
            this.Advances_No.Visible = false;
            // 
            // textBox_ValuePremium
            // 
            this.textBox_ValuePremium.AllowEmptyState = false;
            this.textBox_ValuePremium.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_ValuePremium.AutoOffFreeTextEntry = true;
            this.textBox_ValuePremium.AutoResolveFreeTextEntries = false;
            // 
            // 
            // 
            this.textBox_ValuePremium.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(227)))), ((int)(((byte)(231)))));
            this.textBox_ValuePremium.BackgroundStyle.BorderBottomWidth = 1;
            this.textBox_ValuePremium.BackgroundStyle.Class = "DateTimeInputBackground";
            this.textBox_ValuePremium.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBox_ValuePremium.BackgroundStyle.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_ValuePremium.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.textBox_ValuePremium.DisplayFormat = "0.00";
            this.textBox_ValuePremium.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.textBox_ValuePremium.Increment = 1D;
            this.textBox_ValuePremium.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.textBox_ValuePremium.IsInputReadOnly = true;
            this.textBox_ValuePremium.Location = new System.Drawing.Point(-14, 102);
            this.textBox_ValuePremium.MinValue = 0D;
            this.textBox_ValuePremium.Name = "textBox_ValuePremium";
            this.textBox_ValuePremium.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox_ValuePremium.Size = new System.Drawing.Size(109, 21);
            this.textBox_ValuePremium.TabIndex = 898;
            // 
            // comboBox_EmpNo
            // 
            this.comboBox_EmpNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox_EmpNo.DisplayMember = "Text";
            this.comboBox_EmpNo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBox_EmpNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_EmpNo.FormattingEnabled = true;
            this.comboBox_EmpNo.ItemHeight = 14;
            this.comboBox_EmpNo.Location = new System.Drawing.Point(223, 43);
            this.comboBox_EmpNo.Name = "comboBox_EmpNo";
            this.comboBox_EmpNo.Size = new System.Drawing.Size(353, 20);
            this.comboBox_EmpNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBox_EmpNo.TabIndex = 4;
            this.comboBox_EmpNo.SelectedValueChanged += new System.EventHandler(this.comboBox_EmpNo_SelectedValueChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label12.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label12.Location = new System.Drawing.Point(580, 47);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(49, 13);
            this.label12.TabIndex = 6715;
            this.label12.Text = "???????????? :";
            // 
            // dateTimeInput_warnDate
            // 
            this.dateTimeInput_warnDate.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.dateTimeInput_warnDate.Location = new System.Drawing.Point(303, 14);
            this.dateTimeInput_warnDate.Mask = "0000/00/00";
            this.dateTimeInput_warnDate.Name = "dateTimeInput_warnDate";
            this.dateTimeInput_warnDate.Size = new System.Drawing.Size(127, 21);
            this.dateTimeInput_warnDate.TabIndex = 2;
            this.dateTimeInput_warnDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dateTimeInput_warnDate.Click += new System.EventHandler(this.dateTimeInput_warnDate_Click);
            this.dateTimeInput_warnDate.Leave += new System.EventHandler(this.dateTimeInput_warnDate_Leave);
            // 
            // textBox_ID
            // 
            this.textBox_ID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.textBox_ID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_ID.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.textBox_ID.Location = new System.Drawing.Point(432, 14);
            this.textBox_ID.Name = "textBox_ID";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_ID, false);
            this.textBox_ID.Size = new System.Drawing.Size(144, 21);
            this.textBox_ID.TabIndex = 1;
            this.textBox_ID.Click += new System.EventHandler(this.textBox_ID_Click);
            this.textBox_ID.TextChanged += new System.EventHandler(this.textBox_ID_TextChanged);
            this.textBox_ID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_ID_KeyPress);
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.BackColor = System.Drawing.Color.Transparent;
            this.label38.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label38.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label38.Location = new System.Drawing.Point(580, 18);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(36, 13);
            this.label38.TabIndex = 6710;
            this.label38.Text = "?????????? :";
            // 
            // panel_Acc
            // 
            this.panel_Acc.BackColor = System.Drawing.Color.Transparent;
            this.panel_Acc.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_Acc.Controls.Add(this.label8);
            this.panel_Acc.Controls.Add(this.CmbCurr);
            this.panel_Acc.Controls.Add(this.button_CustD3);
            this.panel_Acc.Controls.Add(this.button_CustD1);
            this.panel_Acc.Controls.Add(this.txtBXCostCenterNo);
            this.panel_Acc.Controls.Add(this.txtBXLoanNo);
            this.panel_Acc.Controls.Add(this.label5);
            this.panel_Acc.Controls.Add(this.button_ScrhLoan);
            this.panel_Acc.Controls.Add(this.switchButton_AccType);
            this.panel_Acc.Controls.Add(this.button_SrchBXBankNo);
            this.panel_Acc.Controls.Add(this.txtBXBankNo);
            this.panel_Acc.Controls.Add(this.label6);
            this.panel_Acc.Controls.Add(this.button_SrchCostCenter);
            this.panel_Acc.Controls.Add(this.txtBXCostCenterName);
            this.panel_Acc.Controls.Add(this.txtBXLoanName);
            this.panel_Acc.Controls.Add(this.txtBXBankName);
            this.panel_Acc.Enabled = false;
            this.panel_Acc.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.panel_Acc.Location = new System.Drawing.Point(16, 250);
            this.panel_Acc.Name = "panel_Acc";
            this.panel_Acc.Size = new System.Drawing.Size(615, 57);
            this.panel_Acc.TabIndex = 8549;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label8.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label8.ForeColor = System.Drawing.Color.Navy;
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(210, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 13);
            this.label8.TabIndex = 1124;
            this.label8.Text = "???????????????????????????? :";
            // 
            // CmbCurr
            // 
            this.CmbCurr.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbCurr.DisplayMember = "Text";
            this.CmbCurr.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.CmbCurr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbCurr.FormattingEnabled = true;
            this.CmbCurr.ItemHeight = 15;
            this.CmbCurr.Location = new System.Drawing.Point(34, 28);
            this.CmbCurr.Name = "CmbCurr";
            this.CmbCurr.Size = new System.Drawing.Size(174, 21);
            this.CmbCurr.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.CmbCurr.TabIndex = 1123;
            // 
            // button_CustD3
            // 
            this.button_CustD3.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_CustD3.Checked = true;
            this.button_CustD3.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_CustD3.Location = new System.Drawing.Point(285, 28);
            this.button_CustD3.Name = "button_CustD3";
            this.button_CustD3.Size = new System.Drawing.Size(26, 21);
            this.button_CustD3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_CustD3.Symbol = "???";
            this.button_CustD3.SymbolSize = 7F;
            this.button_CustD3.TabIndex = 1122;
            this.button_CustD3.TextColor = System.Drawing.Color.SteelBlue;
            this.button_CustD3.Tooltip = "?????????????? ?????????????????? ???? ???????? ????????????";
            this.button_CustD3.Click += new System.EventHandler(this.button_CustD3_Click);
            // 
            // button_CustD1
            // 
            this.button_CustD1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_CustD1.Checked = true;
            this.button_CustD1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_CustD1.Location = new System.Drawing.Point(285, 4);
            this.button_CustD1.Name = "button_CustD1";
            this.button_CustD1.Size = new System.Drawing.Size(26, 21);
            this.button_CustD1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_CustD1.Symbol = "???";
            this.button_CustD1.SymbolSize = 7F;
            this.button_CustD1.TabIndex = 1121;
            this.button_CustD1.TextColor = System.Drawing.Color.SteelBlue;
            this.button_CustD1.Tooltip = "?????????????? ?????????????????? ???? ???????? ????????????";
            this.button_CustD1.Click += new System.EventHandler(this.button_CustD1_Click);
            // 
            // txtBXCostCenterNo
            // 
            this.txtBXCostCenterNo.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtBXCostCenterNo.BackColor = System.Drawing.Color.White;
            this.txtBXCostCenterNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtBXCostCenterNo.Location = new System.Drawing.Point(185, 65);
            this.txtBXCostCenterNo.Name = "txtBXCostCenterNo";
            this.netResize1.SetResizeTextBoxMultiline(this.txtBXCostCenterNo, false);
            this.txtBXCostCenterNo.ReadOnly = true;
            this.txtBXCostCenterNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtBXCostCenterNo.Size = new System.Drawing.Size(169, 21);
            this.txtBXCostCenterNo.TabIndex = 1064;
            this.txtBXCostCenterNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtBXLoanNo
            // 
            this.txtBXLoanNo.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtBXLoanNo.BackColor = System.Drawing.Color.White;
            this.txtBXLoanNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtBXLoanNo.Location = new System.Drawing.Point(271, 52);
            this.txtBXLoanNo.Name = "txtBXLoanNo";
            this.netResize1.SetResizeTextBoxMultiline(this.txtBXLoanNo, false);
            this.txtBXLoanNo.ReadOnly = true;
            this.txtBXLoanNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtBXLoanNo.Size = new System.Drawing.Size(182, 21);
            this.txtBXLoanNo.TabIndex = 1059;
            this.txtBXLoanNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label5.ForeColor = System.Drawing.Color.Navy;
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(494, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 13);
            this.label5.TabIndex = 1058;
            this.label5.Text = "???????? ?????? ???????????? :";
            // 
            // button_ScrhLoan
            // 
            this.button_ScrhLoan.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_ScrhLoan.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_ScrhLoan.Location = new System.Drawing.Point(312, 28);
            this.button_ScrhLoan.Name = "button_ScrhLoan";
            this.button_ScrhLoan.Size = new System.Drawing.Size(26, 21);
            this.button_ScrhLoan.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_ScrhLoan.Symbol = "???";
            this.button_ScrhLoan.SymbolSize = 12F;
            this.button_ScrhLoan.TabIndex = 1057;
            this.button_ScrhLoan.TextColor = System.Drawing.Color.SteelBlue;
            this.button_ScrhLoan.Click += new System.EventHandler(this.button_ScrhLoan_Click);
            // 
            // switchButton_AccType
            // 
            // 
            // 
            // 
            this.switchButton_AccType.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.switchButton_AccType.Location = new System.Drawing.Point(494, 4);
            this.switchButton_AccType.Name = "switchButton_AccType";
            this.switchButton_AccType.OffText = "??????????????";
            this.switchButton_AccType.OnText = "??????????";
            this.switchButton_AccType.Size = new System.Drawing.Size(109, 21);
            this.switchButton_AccType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.switchButton_AccType.TabIndex = 1056;
            this.switchButton_AccType.ValueChanged += new System.EventHandler(this.switchButton_AccType_ValueChanged);
            this.switchButton_AccType.Click += new System.EventHandler(this.switchButton_AccType_Click);
            // 
            // button_SrchBXBankNo
            // 
            this.button_SrchBXBankNo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchBXBankNo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchBXBankNo.Location = new System.Drawing.Point(312, 4);
            this.button_SrchBXBankNo.Name = "button_SrchBXBankNo";
            this.button_SrchBXBankNo.Size = new System.Drawing.Size(26, 21);
            this.button_SrchBXBankNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchBXBankNo.Symbol = "???";
            this.button_SrchBXBankNo.SymbolSize = 12F;
            this.button_SrchBXBankNo.TabIndex = 1050;
            this.button_SrchBXBankNo.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchBXBankNo.Click += new System.EventHandler(this.button_SrchBXBankNo_Click);
            // 
            // txtBXBankNo
            // 
            this.txtBXBankNo.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtBXBankNo.BackColor = System.Drawing.Color.White;
            this.txtBXBankNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtBXBankNo.Location = new System.Drawing.Point(343, 52);
            this.txtBXBankNo.MaxLength = 30;
            this.txtBXBankNo.Name = "txtBXBankNo";
            this.netResize1.SetResizeTextBoxMultiline(this.txtBXBankNo, false);
            this.txtBXBankNo.ReadOnly = true;
            this.txtBXBankNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtBXBankNo.Size = new System.Drawing.Size(108, 21);
            this.txtBXBankNo.TabIndex = 1049;
            this.txtBXBankNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label6.ForeColor = System.Drawing.Color.Navy;
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(210, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 13);
            this.label6.TabIndex = 1062;
            this.label6.Text = "???????? ?????????????? :";
            // 
            // button_SrchCostCenter
            // 
            this.button_SrchCostCenter.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchCostCenter.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchCostCenter.Location = new System.Drawing.Point(6, 4);
            this.button_SrchCostCenter.Name = "button_SrchCostCenter";
            this.button_SrchCostCenter.Size = new System.Drawing.Size(26, 21);
            this.button_SrchCostCenter.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchCostCenter.Symbol = "???";
            this.button_SrchCostCenter.SymbolSize = 12F;
            this.button_SrchCostCenter.TabIndex = 1061;
            this.button_SrchCostCenter.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchCostCenter.Click += new System.EventHandler(this.button_SrchCostCenter_Click);
            // 
            // txtBXCostCenterName
            // 
            this.txtBXCostCenterName.BackColor = System.Drawing.Color.White;
            this.txtBXCostCenterName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtBXCostCenterName.Location = new System.Drawing.Point(34, 4);
            this.txtBXCostCenterName.Name = "txtBXCostCenterName";
            this.netResize1.SetResizeTextBoxMultiline(this.txtBXCostCenterName, false);
            this.txtBXCostCenterName.ReadOnly = true;
            this.txtBXCostCenterName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtBXCostCenterName.Size = new System.Drawing.Size(174, 21);
            this.txtBXCostCenterName.TabIndex = 1063;
            this.txtBXCostCenterName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtBXLoanName
            // 
            this.txtBXLoanName.BackColor = System.Drawing.Color.White;
            this.txtBXLoanName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtBXLoanName.Location = new System.Drawing.Point(339, 28);
            this.txtBXLoanName.Name = "txtBXLoanName";
            this.netResize1.SetResizeTextBoxMultiline(this.txtBXLoanName, false);
            this.txtBXLoanName.ReadOnly = true;
            this.txtBXLoanName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtBXLoanName.Size = new System.Drawing.Size(153, 21);
            this.txtBXLoanName.TabIndex = 1060;
            this.txtBXLoanName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtBXBankName
            // 
            this.txtBXBankName.BackColor = System.Drawing.Color.White;
            this.txtBXBankName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtBXBankName.Location = new System.Drawing.Point(339, 4);
            this.txtBXBankName.Name = "txtBXBankName";
            this.netResize1.SetResizeTextBoxMultiline(this.txtBXBankName, false);
            this.txtBXBankName.ReadOnly = true;
            this.txtBXBankName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtBXBankName.Size = new System.Drawing.Size(153, 21);
            this.txtBXBankName.TabIndex = 1054;
            this.txtBXBankName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            this.ribbonBar_Tasks.Location = new System.Drawing.Point(0, 365);
            this.ribbonBar_Tasks.Name = "ribbonBar_Tasks";
            this.ribbonBar_Tasks.Size = new System.Drawing.Size(647, 51);
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
            this.superTabControl_Main1.ControlBox.CloseBox.Name = "";
            // 
            // 
            // 
            this.superTabControl_Main1.ControlBox.MenuBox.Name = "";
            this.superTabControl_Main1.ControlBox.Name = "";
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
            this.superTabControl_Main1.Size = new System.Drawing.Size(257, 51);
            this.superTabControl_Main1.TabFont = new System.Drawing.Font("Tahoma", 8F);
            this.superTabControl_Main1.TabIndex = 10;
            this.superTabControl_Main1.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.Button_Close,
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
            this.Button_Close.Symbol = "???";
            this.Button_Close.SymbolSize = 15F;
            this.Button_Close.Text = "??????????";
            this.Button_Close.Tooltip = "?????????? ?????????????? ??????????????";
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
            this.Button_Search.Symbol = "???";
            this.Button_Search.SymbolSize = 15F;
            this.Button_Search.Text = "??????";
            this.Button_Search.Tooltip = "?????????? ???? ?????? ????";
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
            this.Button_Delete.Symbol = "???";
            this.Button_Delete.SymbolSize = 15F;
            this.Button_Delete.Text = "??????";
            this.Button_Delete.Tooltip = "?????? ?????????? ????????????";
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
            this.Button_Save.Symbol = "???";
            this.Button_Save.SymbolSize = 15F;
            this.Button_Save.Text = "??????";
            this.Button_Save.Tooltip = "?????? ??????????????????";
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
            this.Button_Add.Symbol = "???";
            this.Button_Add.SymbolSize = 15F;
            this.Button_Add.Text = "??????????";
            this.Button_Add.Tooltip = "?????????? ?????? ????????";
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
            this.superTabControl_Main2.ControlBox.CloseBox.Name = "";
            // 
            // 
            // 
            this.superTabControl_Main2.ControlBox.MenuBox.Name = "";
            this.superTabControl_Main2.ControlBox.Name = "";
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
            this.superTabControl_Main2.Location = new System.Drawing.Point(257, 0);
            this.superTabControl_Main2.Name = "superTabControl_Main2";
            this.superTabControl_Main2.ReorderTabsEnabled = true;
            this.superTabControl_Main2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.superTabControl_Main2.SelectedTabFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.superTabControl_Main2.SelectedTabIndex = -1;
            this.superTabControl_Main2.Size = new System.Drawing.Size(390, 51);
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
            this.Button_First.Symbol = "???";
            this.Button_First.SymbolSize = 15F;
            this.Button_First.Text = "??????????";
            this.Button_First.Tooltip = "?????????? ??????????";
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
            this.Button_Prev.Symbol = "???";
            this.Button_Prev.SymbolSize = 15F;
            this.Button_Prev.Text = "????????????";
            this.Button_Prev.Tooltip = "?????????? ????????????";
            // 
            // TextBox_Index
            // 
            this.TextBox_Index.Name = "TextBox_Index";
            this.TextBox_Index.TextBoxWidth = 50;
            this.TextBox_Index.Visible = false;
            this.TextBox_Index.WatermarkColor = System.Drawing.SystemColors.GrayText;
            // 
            // Label_Count
            // 
            this.Label_Count.Name = "Label_Count";
            this.Label_Count.Visible = false;
            this.Label_Count.Width = 40;
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
            this.Button_Next.Symbol = "???";
            this.Button_Next.SymbolSize = 15F;
            this.Button_Next.Text = "????????????";
            this.Button_Next.Tooltip = " ?????????? ????????????";
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
            this.Button_Last.Symbol = "???";
            this.Button_Last.SymbolSize = 15F;
            this.Button_Last.Text = "????????????";
            this.Button_Last.Tooltip = " ?????????? ????????????";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "*.rtf";
            this.saveFileDialog1.FileName = "doc1";
            this.saveFileDialog1.Filter = "Text Files (*.txt)|*.txt|RTF Files (*.rtf)|*.rtf|All Files(*.*)|*.*";
            this.saveFileDialog1.FilterIndex = 2;
            this.saveFileDialog1.Title = "Save File";
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
            this.DGV_Main.PrimaryGrid.Caption.Text = "";
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
            this.DGV_Main.PrimaryGrid.GroupByRow.Text = "???????????? ??????????????????????";
            this.DGV_Main.PrimaryGrid.GroupByRow.Visible = true;
            this.DGV_Main.PrimaryGrid.GroupByRow.WatermarkText = "";
            this.DGV_Main.PrimaryGrid.InitialActiveRow = DevComponents.DotNetBar.SuperGrid.RelativeRow.None;
            this.DGV_Main.PrimaryGrid.InitialSelection = DevComponents.DotNetBar.SuperGrid.RelativeSelection.None;
            this.DGV_Main.PrimaryGrid.MultiSelect = false;
            this.DGV_Main.PrimaryGrid.ShowRowGridIndex = true;
            this.DGV_Main.PrimaryGrid.Title.AllowSelection = false;
            this.DGV_Main.PrimaryGrid.Title.Text = "";
            this.DGV_Main.PrimaryGrid.Title.Visible = false;
            this.DGV_Main.PrimaryGrid.Visible = false;
            this.DGV_Main.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.DGV_Main.Size = new System.Drawing.Size(647, 0);
            this.DGV_Main.TabIndex = 862;
            // 
            // panelEx3
            // 
            this.panelEx3.Controls.Add(this.DGV_Main);
            this.panelEx3.Controls.Add(this.ribbonBar_DGV);
            this.panelEx3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx3.Location = new System.Drawing.Point(0, 0);
            this.panelEx3.Name = "panelEx3";
            this.panelEx3.Size = new System.Drawing.Size(647, 0);
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
            this.ribbonBar_DGV.Size = new System.Drawing.Size(647, 51);
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
            this.superTabControl_DGV.ControlBox.CloseBox.Name = "";
            // 
            // 
            // 
            this.superTabControl_DGV.ControlBox.MenuBox.Name = "";
            this.superTabControl_DGV.ControlBox.Name = "";
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
            this.superTabControl_DGV.Size = new System.Drawing.Size(647, 51);
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
            this.Button_ExportTable2.Symbol = "???";
            this.Button_ExportTable2.SymbolSize = 15F;
            this.Button_ExportTable2.Text = "??????????";
            this.Button_ExportTable2.Tooltip = "?????????? ?????? ??????????????";
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
            this.Button_PrintTable.Symbol = "???";
            this.Button_PrintTable.SymbolSize = 15F;
            this.Button_PrintTable.Text = "??????????";
            this.Button_PrintTable.Tooltip = "??????????";
            this.Button_PrintTable.Click += new System.EventHandler(this.Button_PrintTable_Click);
            // 
            // labelItem3
            // 
            this.labelItem3.Name = "labelItem3";
            this.labelItem3.Width = 40;
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
            // panel1
            // 
            this.panel1.Controls.Add(this.panelEx3);
            this.panel1.Controls.Add(this.expandableSplitter1);
            this.panel1.Controls.Add(this.panelEx2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(647, 428);
            this.panel1.TabIndex = 897;
            // 
            // barTopDockSite
            // 
            this.barTopDockSite.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.barTopDockSite.Dock = System.Windows.Forms.DockStyle.Top;
            this.barTopDockSite.DocumentDockContainer = new DevComponents.DotNetBar.DocumentDockContainer();
            this.barTopDockSite.Location = new System.Drawing.Point(0, 0);
            this.barTopDockSite.Name = "barTopDockSite";
            this.barTopDockSite.Size = new System.Drawing.Size(647, 0);
            this.barTopDockSite.TabIndex = 889;
            this.barTopDockSite.TabStop = false;
            // 
            // barBottomDockSite
            // 
            this.barBottomDockSite.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.barBottomDockSite.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barBottomDockSite.DocumentDockContainer = new DevComponents.DotNetBar.DocumentDockContainer();
            this.barBottomDockSite.Location = new System.Drawing.Point(0, 428);
            this.barBottomDockSite.Name = "barBottomDockSite";
            this.barBottomDockSite.Size = new System.Drawing.Size(647, 0);
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
            // barLeftDockSite
            // 
            this.barLeftDockSite.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.barLeftDockSite.Dock = System.Windows.Forms.DockStyle.Left;
            this.barLeftDockSite.DocumentDockContainer = new DevComponents.DotNetBar.DocumentDockContainer();
            this.barLeftDockSite.Location = new System.Drawing.Point(0, 0);
            this.barLeftDockSite.Name = "barLeftDockSite";
            this.barLeftDockSite.Size = new System.Drawing.Size(0, 428);
            this.barLeftDockSite.TabIndex = 891;
            this.barLeftDockSite.TabStop = false;
            // 
            // barRightDockSite
            // 
            this.barRightDockSite.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.barRightDockSite.Dock = System.Windows.Forms.DockStyle.Right;
            this.barRightDockSite.DocumentDockContainer = new DevComponents.DotNetBar.DocumentDockContainer();
            this.barRightDockSite.Location = new System.Drawing.Point(647, 0);
            this.barRightDockSite.Name = "barRightDockSite";
            this.barRightDockSite.Size = new System.Drawing.Size(0, 428);
            this.barRightDockSite.TabIndex = 892;
            this.barRightDockSite.TabStop = false;
            // 
            // dockSite4
            // 
            this.dockSite4.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dockSite4.Location = new System.Drawing.Point(0, 428);
            this.dockSite4.Name = "dockSite4";
            this.dockSite4.Size = new System.Drawing.Size(647, 0);
            this.dockSite4.TabIndex = 896;
            this.dockSite4.TabStop = false;
            // 
            // dockSite1
            // 
            this.dockSite1.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite1.Dock = System.Windows.Forms.DockStyle.Left;
            this.dockSite1.Location = new System.Drawing.Point(0, 0);
            this.dockSite1.Name = "dockSite1";
            this.dockSite1.Size = new System.Drawing.Size(0, 428);
            this.dockSite1.TabIndex = 893;
            this.dockSite1.TabStop = false;
            // 
            // dockSite2
            // 
            this.dockSite2.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite2.Dock = System.Windows.Forms.DockStyle.Right;
            this.dockSite2.Location = new System.Drawing.Point(647, 0);
            this.dockSite2.Name = "dockSite2";
            this.dockSite2.Size = new System.Drawing.Size(0, 428);
            this.dockSite2.TabIndex = 894;
            this.dockSite2.TabStop = false;
            // 
            // dockSite3
            // 
            this.dockSite3.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite3.Dock = System.Windows.Forms.DockStyle.Top;
            this.dockSite3.Location = new System.Drawing.Point(0, 0);
            this.dockSite3.Name = "dockSite3";
            this.dockSite3.Size = new System.Drawing.Size(647, 0);
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
            this.ToolStripMenuItem_Rep.Text = "?????????? ??????????????";
            // 
            // ToolStripMenuItem_Det
            // 
            this.ToolStripMenuItem_Det.Name = "ToolStripMenuItem_Det";
            this.ToolStripMenuItem_Det.Size = new System.Drawing.Size(148, 22);
            this.ToolStripMenuItem_Det.Text = "?????????? ????????????????";
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
            // FrmAdvances
            // 
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(647, 428);
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
            this.Icon = ((System.Drawing.Icon)(InvAcc.Properties.Resources.favicon));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "FrmAdvances";
            this.netResize1.AutoSaveLayout = true;
            this.netResize1.ParentControl = this;
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "?????? ??????????????????????";
            this.Load += new System.EventHandler(this.FrmAdvances_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Frm_KeyPress);
            this.panelEx2.ResumeLayout(false);
            this.ribbonBar1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_Salary)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_ResidualValue)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_Remaining)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_TotalPremiums)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_ValueAdvances)).EndInit();
            this.groupPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX_Advances)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_ValuePremium)).EndInit();
            this.panel_Acc.ResumeLayout(false);
            this.panel_Acc.PerformLayout();
            this.ribbonBar_Tasks.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl_Main1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl_Main2)).EndInit();
            this.panelEx3.ResumeLayout(false);
            this.ribbonBar_DGV.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl_DGV)).EndInit();
            this.panel1.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            this.Icon = ((System.Drawing.Icon)(InvAcc.Properties.Resources.favicon));
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).EndInit();
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.ResumeLayout(false);
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
                    lable_Records.Text = ((vCount == 0) ? "???????????? ??????????" : "?????? ???????? ??????");
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
                    lable_Records.Text = "?????????? ???? " + vCount + " ??????????";
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
                    lable_Records.Text = "???????????? ???? " + vCount + " ??????????";
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
                lable_Records.Text = "?????????? " + vPosition + " ???? " + vCount;
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
                if (MessageBox.Show((LangArEn == 0) ? "???? ?????????? ?????????? ???????????? ?????? ?????? ?????????????????? .. ???? ???????? ??????????????????" : "Not saved the changes, do you really want to continue?", VarGeneral.ProdectNam, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
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
            VarGeneral.SFrmTyp = "T_Advance";
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
        private void textBox_Note_ButtonCustomClick(object sender, EventArgs e)
        {
            textBox_Note.Text = "";
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
            List<T_Advance> list = db.FillAdvances_2(textBox_search.TextBox.Text).ToList();
            if (DGV_Main.PrimaryGrid.Columns.Count == 0)
            {
                foreach (KeyValuePair<string, ColumnDictinary> item in columns_Names_visible)
                {
                    DGV_Main.PrimaryGrid.Columns.Add(new GridColumn(item.Key));
                }
            }
            FillHDGV(list);
        }
        public void FillHDGV(IEnumerable<T_Advance> new_data_enum)
        {
            bool contextMenuSet = false;
            if (contextMenuStrip1.Items.Count > 0)
            {
                contextMenuSet = true;
            }
            for (int i = 0; i < DGV_Main.PrimaryGrid.Columns.Count; i++)
            {
                if (columns_Names_visible.ContainsKey(DGV_Main.PrimaryGrid.Columns[i].Name) && DGV_Main.PrimaryGrid.Columns[i].Name != "EmpNm" && DGV_Main.PrimaryGrid.Columns[i].Name != "Emp_No")
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
            DGV_Main.PrimaryGrid.DataMember = "T_Advance";
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
        public void FillCombo()
        {
            List<T_Emp> listEmps = new List<T_Emp>(db.T_Emps.Select((T_Emp item) => item).ToList());
            comboBox_EmpNo.DataSource = listEmps;
            comboBox_EmpNo.DisplayMember = ((LangArEn == 0) ? "NameA" : "NameE");
            comboBox_EmpNo.ValueMember = "Emp_ID";
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
            try
            {
                CmbCurr.SelectedValue = int.Parse(VarGeneral.Settings_Sys.ImportIp.ToString());
            }
            catch
            {
            }
        }
        public void Clear()
        {
            if (State == FormState.New)
            {
                return;
            }
            State = FormState.New;
            data_this = new T_Advance();
            _GdHead = new T_GDHEAD();
            State = FormState.New;
            int? calendr;
            for (int i = 0; i < controls.Count; i++)
            {
                if (controls[i].GetType() == typeof(DateTimePicker))
                {
                    calendr = VarGeneral.Settings_Sys.Calendr;
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
                    else if (controls[i].GetType() == typeof(ComboBox) && (controls[i] as ComboBox).Items.Count > 0)
                    {
                        try
                        {
                            (controls[i] as ComboBox).SelectedIndex = 0;
                        }
                        catch
                        {
                            (controls[i] as ComboBox).SelectedIndex = -1;
                        }
                    }
                    else if (controls[i].GetType() == typeof(ComboBoxEx) && (controls[i] as ComboBoxEx).Items.Count > 0)
                    {
                        try
                        {
                            (controls[i] as ComboBoxEx).SelectedIndex = 0;
                        }
                        catch
                        {
                            (controls[i] as ComboBoxEx).SelectedIndex = -1;
                        }
                    }
                }
            }
            try
            {
                if (dataGridViewX_Advances.Rows.Count > 0)
                {
                    dataGridViewX_Advances.Rows.Clear();
                }
            }
            catch
            {
            }
            Guid id = Guid.NewGuid();
            textBox_ID.Tag = id.ToString();
            calendr = VarGeneral.Settings_Sys.Calendr;
            if (calendr.Value == 0 && calendr.HasValue)
            {
                textBox_SalDate.Text = n.FormatGreg(VarGeneral.Gdate, "yyyy/MM");
                dateTimeInput_warnDate.Text = n.FormatGreg(VarGeneral.Gdate, "yyyy/MM/dd");
            }
            else
            {
                textBox_SalDate.Text = n.FormatHijri(VarGeneral.Hdate, "yyyy/MM");
                dateTimeInput_warnDate.Text = n.FormatHijri(VarGeneral.Hdate, "yyyy/MM/dd");
            }
            if (comboBox_EmpNo.Items.Count > 0)
            {
                comboBox_EmpNo.SelectedValueChanged -= comboBox_EmpNo_SelectedValueChanged;
                comboBox_EmpNo.SelectedIndex = 0;
                comboBox_EmpNo.SelectedValueChanged += comboBox_EmpNo_SelectedValueChanged;
                comboBox_EmpNo_SelectedValueChanged(null, null);
            }
            checkBox_AccID.CheckedChanged -= checkBox_AccID_CheckedChanged;
            checkBox_AccID.Checked = false;
            checkBox_AccID.CheckedChanged += checkBox_AccID_CheckedChanged;
            checkBox_AccID_CheckedChanged(null, null);
            switchButton_AccType.ValueChanged -= switchButton_AccType_ValueChanged;
            switchButton_AccType.Value = false;
            switchButton_AccType.ValueChanged += switchButton_AccType_ValueChanged;
            switchButton_AccType_ValueChanged(null, null);
            canUpdate = true;
            button_SavePremuim.Visible = false;
            try
            {
                CmbCurr.SelectedValue = int.Parse(VarGeneral.Settings_Sys.ImportIp.ToString());
            }
            catch
            {
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
                Button_PrintTable_Click(sender, e);
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
        public void RefreshPKeys()
        {
            PKeys.Clear();
            var qkeys = db.T_Advances.Select((T_Advance item) => new
            {
                Code = item.Advances_No + ""
            });
            int count = 0;
            foreach (var item2 in qkeys)
            {
                count++;
                PKeys.Add(item2.Code);
            }
            Label_Count.Text = string.Concat(count);
            UpdateVcr();
        }
        public FrmAdvances()
        {
            InitializeComponent();
            textBox_Note.Click += Button_Edit_Click;
            textBox_SalDate.Click += Button_Edit_Click;
            textBox_TotalPremiums.Click += Button_Edit_Click;
            textBox_ValueAdvances.Click += Button_Edit_Click;
            textBox_ValuePremium.Click += Button_Edit_Click;
            dateTimeInput_warnDate.MouseDown += Button_Edit_Click;
            comboBox_EmpNo.Click += Button_Edit_Click;
            textBox_ID.KeyPress += textBox_ID_KeyPress;
            Button_Close.Click += Button_Close_Click;
            expandableSplitter1.Click += expandableSplitter1_Click;
            ToolStripMenuItem_Det.Click += ToolStripMenuItem_Det_Click;
            Button_ExportTable2.Click += Button_ExportTable2_Click;
            Button_First.Click += Button_First_Click;
            Button_Prev.Click += Button_Prev_Click;
            Button_Next.Click += Button_Next_Click;
            Button_Last.Click += Button_Last_Click;
            Button_Add.Click += Button_Add_Click;
            Button_Search.Click += Button_Search_Click;
            Button_Delete.Click += Button_Delete_Click;
            Button_Save.Click += Button_Save_Click;
            textBox_search.InputTextChanged += TextBox_Search_InputTextChanged;
            textBox_search.ButtonCustomClick += TextBox_Search_ButtonCustomClick;
            textBox_Note.ButtonCustomClick += textBox_Note_ButtonCustomClick;
            TextBox_Index.InputTextChanged += TextBox_Index_InputTextChanged;
            DGV_Main.MouseDown += DGV_Main_MouseDown;
            DGV_Main.CellDoubleClick += DGV_Main_CellDoubleClick;
            DGV_Main.CellClick += DGV_Main_CellClick;
            DGV_Main.GetCellStyle += DGV_MainGetCellStyle;
            DGV_Main.CellDoubleClick += DGV_Main_CellDoubleClick;
            DGV_Main.DataBindingComplete += DGV_Main_DataBindingComplete;
        }
        protected override void OnParentRightToLeftChanged(EventArgs e)
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmAdvances));
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
            RibunButtons();
            FillCombo();
            GridSetting();
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
                Button_First.Text = "??????????";
                Button_Last.Text = "????????????";
                Button_Next.Text = "????????????";
                Button_Prev.Text = "????????????";
                Button_Add.Text = "????????";
                Button_Close.Text = "??????????";
                Button_Delete.Text = "??????";
                Button_Save.Text = "??????";
                Button_Search.Text = "??????";
                Button_First.Tooltip = "?????????? ??????????";
                Button_Last.Tooltip = "?????????? ????????????";
                Button_Next.Tooltip = "?????????? ????????????";
                Button_Prev.Tooltip = "?????????? ????????????";
                Button_Add.Tooltip = "F1";
                Button_Close.Tooltip = "Esc";
                Button_Delete.Tooltip = "F3";
                Button_Save.Tooltip = "F2";
                Button_Search.Tooltip = "F4";
                Button_PrintTable.Text = ((VarGeneral.GeneralPrinter.nTyp_Setting.Substring(2, 1) == "0") ? "??????????" : "??????????");
                Button_PrintTable.Tooltip = "F5";
                Button_ExportTable2.Text = "??????????";
                Button_ExportTable2.Tooltip = "F10";
                DGV_Main.PrimaryGrid.GroupByRow.Text = "???????? ??????????????";
                label38.Text = "?????????? :";
                textBox_Note.WatermarkText = "???????????????????????????? ??????????????????????????";
                button_CustD1.Tooltip = "?????????????? ?????????????????? ???? ???????? ????????????";
                button_CustD3.Tooltip = "?????????????? ?????????????????? ???? ???????? ????????????";
                Text = "?????? ??????????????????????";
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
                label38.Text = "Code :";
                textBox_Note.WatermarkText = "Notes";
                button_CustD1.Tooltip = "Call Auto Account from Employe form";
                button_CustD3.Tooltip = "Call Auto Account from Employe form";
                Text = "Advances Card";
            }
        }
        private void GridSetting()
        {
            try
            {
                dataGridViewX_Advances.Columns["Premiums_No"].Visible = true;
                dataGridViewX_Advances.Columns["Premiums_No"].MinimumWidth = 55;
                dataGridViewX_Advances.Columns["Premiums_No"].HeaderText = ((LangArEn == 0) ? "??????????" : "Loan No");
                dataGridViewX_Advances.Columns["PremiumsDate"].Visible = true;
                dataGridViewX_Advances.Columns["PremiumsDate"].Width = 75;
                dataGridViewX_Advances.Columns["PremiumsDate"].HeaderText = ((LangArEn == 0) ? "???????? ???? ??????" : "Loan Date");
                dataGridViewX_Advances.Columns["ValuePremiums"].Visible = true;
                dataGridViewX_Advances.Columns["ValuePremiums"].Width = 115;
                dataGridViewX_Advances.Columns["ValuePremiums"].HeaderText = ((LangArEn == 0) ? "???????? ??????????" : "Loan Value");
                dataGridViewX_Advances.Columns["Paying"].Visible = true;
                dataGridViewX_Advances.Columns["Paying"].Width = 115;
                dataGridViewX_Advances.Columns["Paying"].HeaderText = ((LangArEn == 0) ? "??????????????" : "Paid");
                dataGridViewX_Advances.Columns["IFState"].Visible = true;
                dataGridViewX_Advances.Columns["IFState"].Width = 63;
                dataGridViewX_Advances.Columns["IFState"].HeaderText = ((LangArEn == 0) ? "????????????" : "Curryover");
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("GridSetting:", error, enable: true);
            }
        }
        private void FrmAdvances_Load(object sender, EventArgs e)
        {
            try
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmAdvances));
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
                ADD_Controls();
                Permmission = dbc.Get_PermissionID(VarGeneral.UserID);
                if (columns_Names_visible.Count == 0)
                {
                    columns_Names_visible.Add("Advances_No", new ColumnDictinary("?????? ??????????????", "No", ifDefault: true, ""));
                    columns_Names_visible.Add("EmpNm", new ColumnDictinary("?????? ????????????", "Employee Name", ifDefault: false, ""));
                    columns_Names_visible.Add("Emp_No", new ColumnDictinary("?????? ????????????", "Employee No", ifDefault: false, ""));
                    columns_Names_visible.Add("ResolutionDate", new ColumnDictinary("?????????? ??????????????", "Date", ifDefault: true, ""));
                    columns_Names_visible.Add("ValueAdvances", new ColumnDictinary("???????? ????????????", "Advance Value", ifDefault: true, ""));
                    columns_Names_visible.Add("TotalPremiums", new ColumnDictinary("?????? ??????????????", "Total Premiums", ifDefault: true, ""));
                    columns_Names_visible.Add("SalDate", new ColumnDictinary("?????????? ?????????? ??????????", "Date Advance", ifDefault: true, ""));
                    columns_Names_visible.Add("Note", new ColumnDictinary("??????????????????", "Note", ifDefault: true, ""));
                }
                else
                {
                    Clear();
                    textBox_ID.Text = "";
                    TextBox_Index.TextBox.Text = "";
                }
                RibunButtons();
                GridSetting();
                FillCombo();
                RefreshPKeys();
                textBox_ID.Text = PKeys.FirstOrDefault();
                ViewDetails_Click(sender, e);
                UpdateVcr();
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Load:", error, enable: true);
                MessageBox.Show(error.Message);
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
            textBox_TotalPremiums.ValueChanged -= textBox_TotalPremiums_ValueChanged;
            try
            {
                T_Advance newData = db.AdvanceEmp(no);
                if (newData == null || newData.Advances_No == 0 || string.IsNullOrEmpty(newData.Advances_ID))
                {
                    if (!Button_Add.Visible || !Button_Add.Enabled)
                    {
                        MessageBox.Show((LangArEn == 0) ? "???? ???????? ?????????? ?????? ?????????????? .. ???????????? ???????????? ?????????????? ???????????????????? !" : "Can not complete this process .. please see the powers of the users!", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        textBox_ID.TextChanged -= textBox_ID_TextChanged;
                        try
                        {
                            textBox_ID.Text = data_this.Advances_No.ToString();
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
                    int indexA = PKeys.IndexOf(string.Concat(newData.Advances_No));
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
            button_SavePremuim.Visible = false;
            textBox_TotalPremiums.ValueChanged += textBox_TotalPremiums_ValueChanged;
            UpdateVcr();
        }
        public void SetData(T_Advance value)
        {
            State = FormState.Saved;
            Button_Save.Enabled = false;
            canUpdate = true;
            textBox_ID.Tag = value.Advances_ID;
            textBox_Note.Text = value.Note;
            textBox_Remaining.Value = value.Remaining.Value;
            textBox_SalDate.Text = value.SalDate;
            textBox_Salary.Value = value.Salary.Value;
            textBox_TotalPremiums.Value = value.TotalPremiums.Value;
            textBox_ValueAdvances.Value = value.ValueAdvances.Value;
            textBox_ValuePremium.Value = value.ValuePremium.Value;
            checkBox_AccID.Checked = value.AccID.Value;
            switchButton_AccType.Value = value.AutoDisFromSalary.Value;
            try
            {
                if (VarGeneral.CheckDate(value.ResolutionDate))
                {
                    dateTimeInput_warnDate.Text = Convert.ToDateTime(value.ResolutionDate).ToString("yyyy/MM/dd");
                }
                else
                {
                    dateTimeInput_warnDate.Text = "";
                }
            }
            catch
            {
                dateTimeInput_warnDate.Text = "";
            }
            if (!string.IsNullOrEmpty(value.EmpID))
            {
                comboBox_EmpNo.SelectedValue = value.EmpID;
            }
            comboBox_EmpNo_SelectedValueChanged(null, null);
            FillGrid(value.Advances_No);
            if (value.GadeId.HasValue && checkBox_AccID.Checked)
            {
                listGdHead = db.StockGdHeadid((int)value.GadeId.Value);
                if (listGdHead.Count != 0)
                {
                    _GdHead = listGdHead[0];
                    if (_GdHead.gdCstNo.HasValue && !StopSetData)
                    {
                        txtBXCostCenterNo.Text = _GdHead.gdCstNo.Value.ToString();
                        txtBXCostCenterName.Text = ((LangArEn == 0) ? _GdHead.T_CstTbl.Arb_Des : _GdHead.T_CstTbl.Eng_Des);
                    }
                    listGdDet = _GdHead.T_GDDETs.ToList();
                    if (value.AutoDisFromSalary.Value)
                    {
                        int j = 0;
                        while (true)
                        {
                            if (j >= listGdDet.Count)
                            {
                                break;
                            }
                            if (listGdDet[j].gdValue < 0.0)
                            {
                                List<T_AccDef> q = db.T_AccDefs.Where((T_AccDef t) => t.AccDef_No == listGdDet[j].T_AccDef.ParAcc).ToList();
                                txtBXBankNo.Text = q.First().AccDef_No;
                                txtBXBankName.Text = ((LangArEn == 0) ? q.First().Arb_Des : q.First().Eng_Des);
                            }
                            else
                            {
                                txtBXLoanNo.Text = listGdDet[j].AccNo;
                                txtBXLoanName.Text = ((LangArEn == 0) ? listGdDet[j].T_AccDef.Arb_Des : listGdDet[j].T_AccDef.Eng_Des);
                            }
                            j++;
                        }
                    }
                    else
                    {
                        int i = 0;
                        while (true)
                        {
                            if (i >= listGdDet.Count)
                            {
                                break;
                            }
                            if (listGdDet[i].gdValue < 0.0)
                            {
                                List<T_AccDef> q = db.T_AccDefs.Where((T_AccDef t) => t.AccDef_No == listGdDet[i].T_AccDef.ParAcc).ToList();
                                txtBXBankNo.Text = listGdDet[i].AccNo;
                                txtBXBankName.Text = ((LangArEn == 0) ? listGdDet[i].T_AccDef.Arb_Des : listGdDet[i].T_AccDef.Eng_Des);
                            }
                            else
                            {
                                txtBXLoanNo.Text = listGdDet[i].AccNo;
                                txtBXLoanName.Text = ((LangArEn == 0) ? listGdDet[i].T_AccDef.Arb_Des : listGdDet[i].T_AccDef.Eng_Des);
                            }
                            i++;
                        }
                    }
                    try
                    {
                        CmbCurr.SelectedValue = _GdHead.CurTyp.Value;
                    }
                    catch
                    {
                        try
                        {
                            CmbCurr.SelectedValue = int.Parse(VarGeneral.Settings_Sys.ImportIp.ToString());
                        }
                        catch
                        {
                        }
                    }
                }
                else
                {
                    _GdHead = new T_GDHEAD();
                    try
                    {
                        CmbCurr.SelectedValue = int.Parse(VarGeneral.Settings_Sys.ImportIp.ToString());
                    }
                    catch
                    {
                    }
                }
            }
            SetReadOnly = true;
        }
        private void FillGrid(int vEmp)
        {
            try
            {
                try
                {
                    if (dataGridViewX_Advances.Rows.Count > 0)
                    {
                        dataGridViewX_Advances.Rows.Clear();
                    }
                }
                catch
                {
                }
                var q = (from t in db.T_Premiums
                         where t.Advances_No == (int?)vEmp
                         orderby t.Premiums_No
                         select new
                         {
                             t.Advances_No,
                             t.Premiums_ID,
                             t.Premiums_No,
                             t.PremiumsDate,
                             t.ValuePremiums,
                             t.Paying,
                             t.IFState
                         }).ToList();
                for (int i = 0; i < q.Count; i++)
                {
                    dataGridViewX_Advances.Rows.Add();
                    dataGridViewX_Advances.Rows[i].Cells["Premiums_ID"].Value = q[i].Premiums_ID;
                    dataGridViewX_Advances.Rows[i].Cells["Advances_No"].Value = q[i].Advances_No;
                    dataGridViewX_Advances.Rows[i].Cells["Premiums_No"].Value = q[i].Premiums_No;
                    dataGridViewX_Advances.Rows[i].Cells["PremiumsDate"].Value = q[i].PremiumsDate;
                    dataGridViewX_Advances.Rows[i].Cells["ValuePremiums"].Value = q[i].ValuePremiums.Value;
                    dataGridViewX_Advances.Rows[i].Cells["Paying"].Value = q[i].Paying.Value;
                    dataGridViewX_Advances.Rows[i].Cells["IFState"].Value = q[i].IFState.Value;
                    if ((bool)dataGridViewX_Advances.Rows[i].Cells["IFState"].Value)
                    {
                        canUpdate = false;
                    }
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("FillGrid:", error, enable: true);
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
        private T_Advance GetData()
        {
            textBox_ID.Focus();
            try
            {
                data_this.Advances_No = int.Parse(textBox_ID.Text);
            }
            catch
            {
            }
            data_this.ResolutionNo = "1";
            data_this.Note = textBox_Note.Text;
            try
            {
                data_this.Remaining = textBox_Remaining.Value;
            }
            catch
            {
                data_this.Remaining = 0.0;
            }
            try
            {
                data_this.ValuePremiumEdit = textBox_ValuePremium.Value;
            }
            catch
            {
                data_this.ValuePremiumEdit = textBox_ValuePremium.Value;
            }
            try
            {
                data_this.TotalPremiums = textBox_TotalPremiums.Value;
            }
            catch
            {
                data_this.TotalPremiums = 0;
            }
            try
            {
                data_this.ValueAdvances = textBox_ValueAdvances.Value;
            }
            catch
            {
                data_this.ValueAdvances = 0.0;
            }
            try
            {
                data_this.ValuePremium = textBox_ValuePremium.Value;
            }
            catch
            {
                data_this.ValuePremium = textBox_ValuePremium.Value;
            }
            try
            {
                data_this.ResolutionDate = Convert.ToDateTime(dateTimeInput_warnDate.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_warnDate.Text = "";
                data_this.ResolutionDate = "";
            }
            try
            {
                data_this.SalDate = Convert.ToDateTime(textBox_SalDate.Text).ToString("yyyy/MM");
            }
            catch
            {
                data_this.SalDate = DateTime.Now.ToString("yyyy/MM");
            }
            data_this.Salary = textBox_Salary.Value;
            try
            {
                data_this.EmpID = comboBox_EmpNo.SelectedValue.ToString();
            }
            catch
            {
                data_this.EmpID = null;
            }
            data_this.AccID = checkBox_AccID.Checked;
            data_this.AutoDisFromSalary = switchButton_AccType.Value;
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
        private void Button_Add_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Button_Add.Visible || !Button_Add.Enabled)
                {
                    MessageBox.Show((LangArEn == 0) ? "???? ???????? ???????????????? ?????? ?????????????? .. ???????? ???????????? ??????????????????" : "You are not permission this operation .. Please check permissions", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                else if (State != FormState.Edit || !(textBox_ID.Text != "") || MessageBox.Show((LangArEn == 0) ? "???? ?????? ?????? ????????????????, ???? ??????\u064b ???????? ??????????????????" : "Not saved the changes, do you really want to continue?", VarGeneral.ProdectNam, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    int max = 0;
                    max = db.MaxAdvanceNo;
                    textBox_ID.Text = max.ToString();
                    textBox_ValueAdvances.ValueChanged -= textBox_ValueAdvances_ValueChanged;
                    Clear();
                    textBox_ValueAdvances.ValueChanged += textBox_ValueAdvances_ValueChanged;
                    State = FormState.New;
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Button_Add_Click:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private bool ValidData()
        {
            try
            {
                if (int.Parse(textBox_ID.Text) <= 0)
                {
                    MessageBox.Show((LangArEn == 0) ? "???????? ?????? ???? ???????????????? ,, ???????????? ???????????? ???? ?????????? " : "There is an error in the input, please make sure of the No", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
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
                MessageBox.Show((LangArEn == 0) ? "???? ???????? ???????????????? ?????? ?????????????? .. ???????? ???????????? ??????????????????" : "You are not permission this operation .. Please check permissions", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }
            if (State == FormState.New && !Button_Add.Enabled)
            {
                MessageBox.Show((LangArEn == 0) ? "???? ???????? ???????????????? ?????? ?????????????? .. ???????? ???????????? ??????????????????" : "You are not permission this operation .. Please check permissions", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }
            if (textBox_ID.Text == "")
            {
                MessageBox.Show((LangArEn == 0) ? "???????? ???? ?????????? ?????????? ???????????????? " : "Most Set Auto No", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                textBox_ID.Focus();
                return false;
            }
            if (comboBox_EmpNo.Items.Count <= 0)
            {
                MessageBox.Show((LangArEn == 0) ? "???????? ???? ???????????? ????????" : "Most Select Employee", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                comboBox_EmpNo.Focus();
                return false;
            }
            if (textBox_SalDate.Text.Trim().Length != 7)
            {
                MessageBox.Show((LangArEn == 0) ? "???????? ???? ?????????? ????????????" : "Make sure the date of salary", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                textBox_SalDate.Focus();
                return false;
            }
            if (dateTimeInput_warnDate.Text.Length != 10)
            {
                MessageBox.Show((LangArEn == 0) ? "?????? ?????????? ?????????? ????????????" : "You must specify the date of the decision", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                dateTimeInput_warnDate.Focus();
                return false;
            }
            if (textBox_ValueAdvances.Value <= 0.0)
            {
                MessageBox.Show((LangArEn == 0) ? "????????\u064b , ?????? ?????????? ???????? ???????????? " : "Sorry .. Most Set Loan Value !", VarGeneral.ProdectNam);
                textBox_ValueAdvances.Focus();
                return false;
            }
            if (textBox_TotalPremiums.Value <= 0)
            {
                MessageBox.Show((LangArEn == 0) ? "????????\u064b , ?????? ?????????? ?????? ?????????????? " : "Sorry .. Most Set Loan Count", VarGeneral.ProdectNam);
                textBox_TotalPremiums.Focus();
                return false;
            }
            if (textBox_ValueAdvances.Value > textBox_Salary.Value && MessageBox.Show((LangArEn == 0) ? "???????? ?????????? ???????? ???? ???????? ???????????? .. ???? ?????? ???????? ????????????????????" : "The value of the premium is greater than the value of the salary .. Do you really want to continue?", VarGeneral.ProdectNam, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
            {
                return false;
            }
            if (checkBox_AccID.Checked && txtBXBankName.Text == "")
            {
                MessageBox.Show((LangArEn == 0) ? "???????? ???? ???????? ???????????? (??????????????-??????????)" : "Credit Account is Rong", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                txtBXBankName.Focus();
                return false;
            }
            if (checkBox_AccID.Checked && txtBXLoanName.Text == "")
            {
                MessageBox.Show((LangArEn == 0) ? "???????? ???? ???????? ???????????? (???????? ?????? ????????????)" : "Debit Account is Rong", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                txtBXLoanName.Focus();
                return false;
            }
            double vSum = 0.0;
            for (int i = 0; i < dataGridViewX_Advances.Rows.Count; i++)
            {
                vSum += Math.Abs((double)dataGridViewX_Advances.Rows[i].Cells["ValuePremiums"].Value + 0.0);
            }
            if (Math.Round(vSum, 0) != Math.Round(textBox_ValueAdvances.Value, 0))
            {
                if (MessageBox.Show((LangArEn == 0) ? " ?????????? ?????????????? ???? ?????????? ???????????? ???????????? .. ???? ???????? ?????????????? ?????????????? ????????????????" : "Total premiums are not equal to the total advance .. Do you want to retrieve the previous installments?", VarGeneral.ProdectNam, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.No)
                {
                    dbInstance = null;
                    textBox_TotalPremiums_ValueChanged(null, null);
                }
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
                            string dtAction = (n.IsHijri(textBox_SalDate.Text + "/01") ? (textBox_SalDate.Text + "/01") : n.GregToHijri(textBox_SalDate.Text + "/01", "yyyy/MM/dd"));
                            if (Convert.ToDateTime(n.GregToHijri(hKeyNew.GetValue("vBackup_New").ToString(), "yyyy/MM/dd")) < Convert.ToDateTime(n.FormatHijri(dtAction, "yyyy/MM/dd")))
                            {
                                MessageBox.Show((LangArEn == 0) ? "???? ???????? ?????????? ?????????????? .. ?????? ?????????? ?????????? ?????????????? ???????????? ???????????? \n ???????? ?????????????? ???? ?????????????? ?????????????????? ???? ?????????? ???????????? " : "We can not complete the operation .. have you skip the fiscal year specified for the system", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                return false;
                            }
                        }
                        catch
                        {
                            MessageBox.Show((LangArEn == 0) ? "???? ???????? ?????????? ?????????????? .. ?????? ?????????? ?????????? ?????????????? ???????????? ???????????? \n ???????? ?????????????? ???? ?????????????? ?????????????????? ???? ?????????? ???????????? " : "We can not complete the operation .. have you skip the fiscal year specified for the system", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
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
        private void Button_Save_Click(object sender, EventArgs e)
        {
            try
            {
                textBox_ID.Focus();
                if (!ValidData())
                {
                    return;
                }
                string AccCrdt = "";
                string AccDbt = "";
                if (!checkBox_AccID.Checked)
                {
                    goto IL_00d4;
                }
                AccCrdt = txtBXBankNo.Text;
                AccDbt = txtBXLoanNo.Text;
                if (AccCrdt == "")
                {
                    MessageBox.Show((LangArEn == 0) ? " ???????? ???? ?????? ?????????? ???????????? ( ???????? ?????????? - ?????????????? ) .. ???? ???????????????? ?????? ???????? .. " : "You can not complete the operation .. Make sure the creditor Account ", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                if (!(AccDbt == ""))
                {
                    goto IL_00d4;
                }
                MessageBox.Show((LangArEn == 0) ? " ???????? ???? ?????? ?????????? ???????????? ( ???????? ?????????? ) .. ???? ???????????????? ?????? ???????? " : "You can not complete the operation .. Make sure the debtor Account", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                goto end_IL_0001;
            IL_036d:
                IDatabase db_;
                if (textBox_ValueAdvances.Value > 0.0 && checkBox_AccID.Checked)
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
                        StopSetData = true;
                        textBox_ID_TextChanged(null, null);
                        StopSetData = false;
                        GetDataGd();
                        db.Log = VarGeneral.DebugLog;
                        db.SubmitChanges(ConflictMode.ContinueOnConflict);
                        for (int i = 0; i < _GdHead.T_GDDETs.Count; i++)
                        {
                            db_.StartTransaction();
                            db_.ClearParameters();
                            db_.AddParameter("GDDET_ID", DbType.Int32, _GdHead.T_GDDETs[i].GDDET_ID);
                            db_.ExecuteNonQueryWithoutCommit(storedProcedure: true, "S_T_GDDET_DELETE");
                            db_.EndTransaction();
                        }
                    }
                    db_.StartTransaction();
                    db_.ClearParameters();
                    db_.AddParameter("GDDET_ID", DbType.Int32, 0);
                    db_.AddParameter("gdID", DbType.Int32, _GdHead.gdhead_ID);
                    db_.AddParameter("gdNo", DbType.String, _GdHead.gdNo);
                    db_.AddParameter("gdDes", DbType.String, "?????? ?????? ???????? ???????? ?????? ???????????? :" + data_this.T_Emp.NameA);
                    db_.AddParameter("gdDesE", DbType.String, "Sand advance to the employee : " + data_this.T_Emp.NameE);
                    db_.AddParameter("recptTyp", DbType.String, "16");
                    db_.AddParameter("AccNo", DbType.String, AccCrdt);
                    db_.AddParameter("AccName", DbType.String, "");
                    db_.AddParameter("gdValue", DbType.Double, 0.0 - double.Parse(textBox_ValueAdvances.Text));
                    db_.AddParameter("recptNo", DbType.String, _GdHead.gdNo);
                    db_.AddParameter("Lin", DbType.Int32, 1);
                    db_.AddParameter("AccNoDestruction", DbType.String, null);
                    db_.ExecuteNonQueryWithoutCommit(storedProcedure: true, "S_T_GDDET_INSERT");
                    db_.EndTransaction();
                    db_.StartTransaction();
                    db_.ClearParameters();
                    db_.AddParameter("GDDET_ID", DbType.Int32, 0);
                    db_.AddParameter("gdID", DbType.Int32, _GdHead.gdhead_ID);
                    db_.AddParameter("gdNo", DbType.String, _GdHead.gdNo);
                    db_.AddParameter("gdDes", DbType.String, "?????? ?????? ???????? ???????? ?????? ???????????? :" + data_this.T_Emp.NameA);
                    db_.AddParameter("gdDesE", DbType.String, "Sand advance to the employee : " + data_this.T_Emp.NameE);
                    db_.AddParameter("recptTyp", DbType.String, "16");
                    db_.AddParameter("AccNo", DbType.String, AccDbt);
                    db_.AddParameter("AccName", DbType.String, "");
                    db_.AddParameter("gdValue", DbType.Double, double.Parse(textBox_ValueAdvances.Text));
                    db_.AddParameter("recptNo", DbType.String, _GdHead.gdNo);
                    db_.AddParameter("Lin", DbType.Int32, 2);
                    db_.AddParameter("AccNoDestruction", DbType.String, null);
                    db_.ExecuteNonQueryWithoutCommit(storedProcedure: true, "S_T_GDDET_INSERT");
                    db_.EndTransaction();
                }
                dbInstance = null;
                textBox_ID_TextChanged(null, null);
                data_this.GadeId = _GdHead.gdhead_ID;
                db.Log = VarGeneral.DebugLog;
                db.SubmitChanges(ConflictMode.ContinueOnConflict);
                State = FormState.Saved;
                RefreshPKeys();
                TextBox_Index.TextBox.Text = string.Concat(PKeys.IndexOf(string.Concat(data_this.Advances_No)) + 1);
                SetReadOnly = true;
                goto end_IL_0001;
            IL_02f6:
                GetData();
                if (db.CheckEmp_Premium(data_this.Advances_No))
                {
                    db.T_Premiums.DeleteAllOnSubmit(DataThis.T_Premiums);
                    db.SubmitChanges();
                }
                db.Log = VarGeneral.DebugLog;
                db.SubmitChanges(ConflictMode.ContinueOnConflict);
                AqsaatOp();
                goto IL_036d;
            IL_00d4:
                db_ = Database.GetDatabase(VarGeneral.BranchCS);
                if (State == FormState.New)
                {
                    GetData();
                    try
                    {
                        data_this.Advances_ID = textBox_ID.Tag.ToString();
                        db.T_Advances.InsertOnSubmit(data_this);
                        db.SubmitChanges();
                        AqsaatOp();
                    }
                    catch (SqlException error2)
                    {
                        int max = 0;
                        max = db.MaxAdvanceNo;
                        if (error2.Number == 2627)
                        {
                            MessageBox.Show((LangArEn == 0) ? ("?????? ?????????? ???????????? ???? ??????.\n???????? ?????????? ???????? ???????? [" + max + "]") : ("This No is user before.\nWill be save a new number [" + max + "]"), VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            textBox_ID.TextChanged -= textBox_ID_TextChanged;
                            textBox_ID.Text = string.Concat(max);
                            textBox_ID.TextChanged += textBox_ID_TextChanged;
                            data_this.Advances_No = max;
                            Button_Save_Click(sender, e);
                        }
                        else
                        {
                            VarGeneral.DebLog.writeLog("Button_Save_Click:", error2, enable: true);
                            MessageBox.Show(error2.Message);
                        }
                        return;
                    }
                    goto IL_036d;
                }
                if (State != FormState.Edit)
                {
                    goto IL_036d;
                }
                if (!data_this.AccID.Value || checkBox_AccID.Checked)
                {
                    goto IL_02f6;
                }
                if (MessageBox.Show((LangArEn == 0) ? "???????? ???????????? ?????? ???????????? ???????? ???????? ???????? .. ???? ???????? ??????????????????" : "This advance is a former accounting entry will be deleted .. Do you want to continue?", VarGeneral.ProdectNam, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
                {
                    return;
                }
                db_.StartTransaction();
                db_.ClearParameters();
                db_.AddParameter("gdhead_ID", DbType.Int32, _GdHead.gdhead_ID);
                db_.ExecuteNonQueryWithoutCommit(storedProcedure: true, "S_T_GDHEAD_DELETE");
                db_.EndTransaction();
                goto IL_02f6;
            end_IL_0001:;
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Button_Save_Click:", error, enable: true);
                MessageBox.Show(error.Message);
                StopSetData = false;
            }
        }
        private T_GDHEAD GetDataGd()
        {
            _GdHead.gdHDate = (n.IsHijri(dateTimeInput_warnDate.Text) ? dateTimeInput_warnDate.Text : n.GregToHijri(dateTimeInput_warnDate.Text, "yyyy/MM/dd"));
            _GdHead.gdGDate = (n.IsGreg(dateTimeInput_warnDate.Text) ? dateTimeInput_warnDate.Text : n.HijriToGreg(dateTimeInput_warnDate.Text, "yyyy/MM/dd"));
            if (string.IsNullOrEmpty(_GdHead.gdNo) || State == FormState.New)
            {
                _GdHead.gdNo = db.MaxGDHEADsNo.ToString();
            }
            _GdHead.ArbTaf = ScriptNumber1.ScriptNum(decimal.Parse("0" + textBox_ValueAdvances.Text));
            _GdHead.BName = _GdHead.BName;
            _GdHead.ChekNo = "EmpAdvance";
            _GdHead.CurTyp = int.Parse(CmbCurr.SelectedValue.ToString());
            _GdHead.EngTaf = ScriptNumber1.TafEng(decimal.Parse("0" + textBox_ValueAdvances.Text));
            if (!string.IsNullOrEmpty(txtBXCostCenterNo.Text))
            {
                _GdHead.gdCstNo = int.Parse(txtBXCostCenterNo.Text);
            }
            else
            {
                _GdHead.gdCstNo = null;
            }
            _GdHead.gdID = 0;
            _GdHead.gdLok = false;
            _GdHead.AdminLock = false;
            _GdHead.gdMem = ((LangArEn == 0) ? ("?????? ?????? ???????? ???????? ?????? ???????????? :" + data_this.T_Emp.NameA) : ("Sand advance to the employee : " + data_this.T_Emp.NameE));
            _GdHead.gdMnd = null;
            _GdHead.gdRcptID = (_GdHead.gdRcptID.HasValue ? _GdHead.gdRcptID.Value : 0.0);
            _GdHead.gdTot = textBox_ValueAdvances.Value;
            _GdHead.gdTp = (_GdHead.gdTp.HasValue ? _GdHead.gdTp.Value : 0);
            _GdHead.gdTyp = 16;
            _GdHead.RefNo = "";
            _GdHead.DATE_MODIFIED = DateTime.Now;
            _GdHead.salMonth = "";
            _GdHead.gdUser = VarGeneral.UserNumber;
            _GdHead.gdUserNam = VarGeneral.UserNameA;
            _GdHead.CompanyID = 1;
            return _GdHead;
        }
        private void AqsaatOp()
        {
            if (db.CheckEmp_Premium(int.Parse(textBox_ID.Text)))
            {
                db.T_Premiums.DeleteAllOnSubmit(DataThis.T_Premiums);
                db.SubmitChanges();
            }
            SavePremuim();
        }
        private void SavePremuim()
        {
            try
            {
                for (int i = 0; i < dataGridViewX_Advances.Rows.Count; i++)
                {
                    DataThisPre = new T_Premium();
                    data_this_Pre.Premiums_ID = dataGridViewX_Advances.Rows[i].Cells["Premiums_ID"].Value.ToString();
                    data_this_Pre.Advances_No = int.Parse(dataGridViewX_Advances.Rows[i].Cells["Advances_No"].Value.ToString());
                    data_this_Pre.IFState = Convert.ToBoolean(dataGridViewX_Advances.Rows[i].Cells["IFState"].Value);
                    data_this_Pre.Paying = double.Parse(dataGridViewX_Advances.Rows[i].Cells["Paying"].Value.ToString());
                    data_this_Pre.Premiums_No = int.Parse(dataGridViewX_Advances.Rows[i].Cells["Premiums_No"].Value.ToString());
                    data_this_Pre.PremiumsDate = dataGridViewX_Advances.Rows[i].Cells["PremiumsDate"].Value.ToString();
                    data_this_Pre.ValuePremiums = double.Parse(dataGridViewX_Advances.Rows[i].Cells["ValuePremiums"].Value.ToString());
                    db.T_Premiums.InsertOnSubmit(data_this_Pre);
                    db.SubmitChanges();
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("SavePremuim:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void Button_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Button_Delete.Enabled || !Button_Delete.Visible)
                {
                    ifOkDelete = false;
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
                if (MessageBox.Show((LangArEn == 0) ? ("???? ?????? ?????????? ???? ?????? ?????????? " + Code) : ("Are you sure you want to delete the record ? " + Code), VarGeneral.ProdectNam, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ifOkDelete = true;
                }
                else
                {
                    ifOkDelete = false;
                }
                if (data_this == null || data_this.Advances_No == 0 || string.IsNullOrEmpty(data_this.Advances_ID) || !ifOkDelete)
                {
                    return;
                }
                data_this = db.AdvanceEmp(DataThis.Advances_No);
                try
                {
                    if (data_this.AccID.Value)
                    {
                        if (MessageBox.Show((LangArEn == 0) ? "???????? ???????????? ?????? ???????????? ???????? ???????? ???????? .. ???? ???????? ??????????????????" : "This advance is a former accounting entry will be deleted .. Do you want to continue?", VarGeneral.ProdectNam, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
                        {
                            return;
                        }
                        IDatabase db_ = Database.GetDatabase(VarGeneral.BranchCS);
                        db_.StartTransaction();
                        db_.ClearParameters();
                        db_.AddParameter("gdhead_ID", DbType.Int32, _GdHead.gdhead_ID);
                        db_.ExecuteNonQueryWithoutCommit(storedProcedure: true, "S_T_GDHEAD_DELETE");
                        db_.EndTransaction();
                    }
                }
                catch (Exception error2)
                {
                    VarGeneral.DebLog.writeLog("Del Gaid:", error2, enable: true);
                    MessageBox.Show(error2.Message);
                }
                if (db.CheckEmp_Premium(int.Parse(textBox_ID.Text)))
                {
                    db.T_Premiums.DeleteAllOnSubmit(data_this.T_Premiums);
                    db.SubmitChanges();
                }
                db.T_Advances.DeleteOnSubmit(DataThis);
                db.SubmitChanges();
                Clear();
                RefreshPKeys();
                textBox_ID.Text = PKeys.LastOrDefault();
            }
            catch (Exception error2)
            {
                VarGeneral.DebLog.writeLog("Button_Delete_Click:", error2, enable: true);
                MessageBox.Show(error2.Message);
                DataThis = db.AdvanceEmp(DataThis.Advances_No);
            }
        }
        private void DGV_Main_DataBindingComplete(object sender, GridDataBindingCompleteEventArgs e)
        {
            GridPanel panel = e.GridPanel;
            string dataMember = panel.DataMember;
            if (dataMember != null && dataMember == "T_Advance")
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
            panel.Columns["Advances_No"].Width = 120;
            panel.Columns["Advances_No"].Visible = columns_Names_visible["Advances_No"].IfDefault;
            panel.Columns["ResolutionDate"].Width = 120;
            panel.Columns["ResolutionDate"].Visible = columns_Names_visible["ResolutionDate"].IfDefault;
            panel.Columns["Emp_No"].Width = 120;
            panel.Columns["Emp_No"].Visible = columns_Names_visible["Emp_No"].IfDefault;
            panel.Columns["EmpNm"].Width = 250;
            panel.Columns["EmpNm"].Visible = columns_Names_visible["EmpNm"].IfDefault;
            panel.Columns["ValueAdvances"].Width = 120;
            panel.Columns["ValueAdvances"].Visible = columns_Names_visible["ValueAdvances"].IfDefault;
            panel.Columns["TotalPremiums"].Width = 120;
            panel.Columns["TotalPremiums"].Visible = columns_Names_visible["TotalPremiums"].IfDefault;
            panel.Columns["SalDate"].Width = 100;
            panel.Columns["SalDate"].Visible = columns_Names_visible["SalDate"].IfDefault;
            panel.Columns["Note"].Width = 350;
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
                ExportExcel.ExportToExcel(DGV_Main, "?????????? ???????????? ????????????????");
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
        private void textBox_Note_Click(object sender, EventArgs e)
        {
            textBox_Note.SelectAll();
        }
        private void dateTimeInput_warnDate_Click(object sender, EventArgs e)
        {
            dateTimeInput_warnDate.SelectAll();
        }
        private void textBox_SalDate_Click(object sender, EventArgs e)
        {
            textBox_SalDate.SelectAll();
        }
        private void ADD_Controls()
        {
            try
            {
                controls = new List<Control>();
                controls.Add(textBox_ID);
                codeControl = textBox_ID;
                controls.Add(textBox_Note);
                controls.Add(textBox_ResidualValue);
                controls.Add(textBox_SalDate);
                controls.Add(textBox_Salary);
                controls.Add(textBox_TotalPremiums);
                controls.Add(textBox_ValueAdvances);
                controls.Add(textBox_ValuePremium);
                controls.Add(textBox_Remaining);
                controls.Add(dateTimeInput_warnDate);
                controls.Add(checkBox_AccID);
                controls.Add(switchButton_AccType);
                controls.Add(comboBox_EmpNo);
                controls.Add(txtBXBankName);
                controls.Add(txtBXBankNo);
                controls.Add(txtBXLoanName);
                controls.Add(txtBXLoanNo);
                controls.Add(txtBXCostCenterName);
                controls.Add(txtBXCostCenterNo);
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("ADD_Controls:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void textBox_SalDate_Leave(object sender, EventArgs e)
        {
            try
            {
                if (VarGeneral.CheckDate(textBox_SalDate.Text))
                {
                    textBox_SalDate.Text = Convert.ToDateTime(textBox_SalDate.Text).ToString("yyyy/MM/dd");
                }
                else
                {
                    textBox_SalDate.Text = "";
                }
            }
            catch
            {
                textBox_SalDate.Text = "";
                return;
            }
            textBox_TotalPremiums_ValueChanged(sender, e);
        }
        private void dateTimeInput_warnDate_Leave(object sender, EventArgs e)
        {
            try
            {
                if (VarGeneral.CheckDate(dateTimeInput_warnDate.Text))
                {
                    dateTimeInput_warnDate.Text = Convert.ToDateTime(dateTimeInput_warnDate.Text).ToString("yyyy/MM/dd");
                    return;
                }
                int? calendr = VarGeneral.Settings_Sys.Calendr;
                if (calendr.Value == 0 && calendr.HasValue)
                {
                    dateTimeInput_warnDate.Text = n.FormatGreg(VarGeneral.Gdate, "yyyy/MM/dd");
                }
                else
                {
                    dateTimeInput_warnDate.Text = n.FormatHijri(VarGeneral.Hdate, "yyyy/MM/dd");
                }
            }
            catch
            {
                int? calendr = VarGeneral.Settings_Sys.Calendr;
                if (calendr.Value == 0 && calendr.HasValue)
                {
                    dateTimeInput_warnDate.Text = n.FormatGreg(VarGeneral.Gdate, "yyyy/MM/dd");
                }
                else
                {
                    dateTimeInput_warnDate.Text = n.FormatHijri(VarGeneral.Hdate, "yyyy/MM/dd");
                }
            }
        }
        private void button_SrchEmp_Click(object sender, EventArgs e)
        {
            if (!comboBox_EmpNo.Enabled)
            {
                return;
            }
            try
            {
                Dir_ButSearch.Add("Emp_No", new ColumnDictinary("?????? ????????????", "Employee No", ifDefault: true, ""));
                Dir_ButSearch.Add("NameA", new ColumnDictinary("?????????? ????????", "Arabic Name", ifDefault: true, ""));
                Dir_ButSearch.Add("NameE", new ColumnDictinary("?????????? ??????????????????", "English Name", ifDefault: false, ""));
                Dir_ButSearch.Add("DateAppointment", new ColumnDictinary("?????????? ??????????????", "Appointment Date", ifDefault: false, ""));
                Dir_ButSearch.Add("StartContr", new ColumnDictinary("?????????? ??????????", "Start Contract Date", ifDefault: false, ""));
                Dir_ButSearch.Add("EndContr", new ColumnDictinary("?????????? ??????????", "End Contract Date", ifDefault: false, ""));
                Dir_ButSearch.Add("MainSal", new ColumnDictinary("???????????? ??????????????", "Main Salary", ifDefault: false, ""));
                Dir_ButSearch.Add("ID_No", new ColumnDictinary("?????? ????????????", "ID No", ifDefault: false, ""));
                Dir_ButSearch.Add("Passport_No", new ColumnDictinary("?????? ????????????", "Passport No", ifDefault: false, ""));
                Dir_ButSearch.Add("AddressA", new ColumnDictinary("??????????????", "Address", ifDefault: false, ""));
                Dir_ButSearch.Add("Tel", new ColumnDictinary("????????????", "Tel", ifDefault: false, ""));
                Dir_ButSearch.Add("Note", new ColumnDictinary(" ??????????????????????", "Note", ifDefault: false, ""));
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
        private void textBox_ValueAdvances_ValueChanged(object sender, EventArgs e)
        {
            if (State == FormState.Saved)
            {
                return;
            }
            if (!VarGeneral.CheckDate(textBox_SalDate.Text))
            {
                try
                {
                    if (dataGridViewX_Advances.Rows.Count > 0)
                    {
                        dataGridViewX_Advances.Rows.Clear();
                    }
                }
                catch
                {
                }
                return;
            }
            textBox_Remaining.Value = textBox_ValueAdvances.Value;
            if (textBox_ValueAdvances.Value > 0.0 && textBox_TotalPremiums.Value > 0)
            {
                textBox_ValuePremium.Value = Math.Round(textBox_ValueAdvances.Value / (double)textBox_TotalPremiums.Value, 2);
                textBox_ValuePremium_ValueChanged(sender, e);
                return;
            }
            try
            {
                if (dataGridViewX_Advances.Rows.Count > 0)
                {
                    dataGridViewX_Advances.Rows.Clear();
                }
            }
            catch
            {
            }
        }
        private void textBox_TotalPremiums_ValueChanged(object sender, EventArgs e)
        {
            if (State == FormState.Saved)
            {
                button_SavePremuim.Visible = true;
                try
                {
                    if (State == FormState.Saved && dataGridViewX_Advances.Rows.Count > 0)
                    {
                        for (int i = 0; i < dataGridViewX_Advances.Rows.Count; i++)
                        {
                            if (!(dataGridViewX_Advances.Rows[i].Cells["IFState"].Value.ToString() == "False"))
                            {
                                continue;
                            }
                            for (int ii = i; ii < dataGridViewX_Advances.Rows.Count; ii++)
                            {
                                if (dataGridViewX_Advances.Rows[ii].Cells["IFState"].Value.ToString() == "True")
                                {
                                    MessageBox.Show((LangArEn == 0) ? "???????????? ?????????? ?????????? .. ???????????? ???????????? ???? ?????? ???????? ?????????????? ?????????????? ???????????????? !" : "Can not be modified Loan .. Please confirm previous salary account and carryover!", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                    buttonItem_Cancel_Click(sender, e);
                                    return;
                                }
                            }
                        }
                    }
                }
                catch
                {
                    buttonItem_Cancel_Click(sender, e);
                    return;
                }
            }
            else
            {
                button_SavePremuim.Visible = false;
            }
            try
            {
                if (dataGridViewX_Advances.Rows.Count > 0)
                {
                    dataGridViewX_Advances.Rows.Clear();
                }
            }
            catch
            {
            }
            if (!VarGeneral.CheckDate(textBox_SalDate.Text))
            {
                return;
            }
            textBox_Remaining.Value = textBox_ValueAdvances.Value;
            if (textBox_ValueAdvances.Value > 0.0 && textBox_TotalPremiums.Value > 0)
            {
                textBox_ValuePremium.Value = Math.Round(textBox_ValueAdvances.Value / (double)textBox_TotalPremiums.Value, 2);
                textBox_ValuePremium_ValueChanged(sender, e);
                return;
            }
            try
            {
                if (dataGridViewX_Advances.Rows.Count > 0)
                {
                    dataGridViewX_Advances.Rows.Clear();
                }
            }
            catch
            {
            }
        }
        private void comboBox_EmpNo_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBox_EmpNo.SelectedIndex == -1)
                {
                    textBox_ResidualValue.Value = 0.0;
                    checkBox_AccID_CheckedChanged(sender, e);
                    return;
                }
            }
            catch
            {
                textBox_ResidualValue.Value = 0.0;
                checkBox_AccID_CheckedChanged(sender, e);
            }
            try
            {
                textBox_ResidualValue.Value = (from t in db.T_Premiums
                                               where t.T_Advance.T_Emp.Emp_ID == comboBox_EmpNo.SelectedValue.ToString()
                                               select t.ValuePremiums).Sum().Value - (from t in db.T_Premiums
                                                                                      where t.T_Advance.T_Emp.Emp_ID == comboBox_EmpNo.SelectedValue.ToString()
                                                                                      select t.Paying).Sum().Value;
            }
            catch
            {
                textBox_ResidualValue.Value = 0.0;
            }
            try
            {
                if (State == FormState.New)
                {
                    T_Emp q = db.EmpsEmp(comboBox_EmpNo.SelectedValue.ToString());
                    textBox_Salary.Value = q.MainSal.Value;
                    txtBXLoanNo.Text = q.LoanAcc;
                    if (!string.IsNullOrEmpty(txtBXLoanNo.Text))
                    {
                        txtBXLoanName.Text = ((LangArEn == 0) ? q.T_AccDef3.Arb_Des : q.T_AccDef3.Eng_Des);
                    }
                    else
                    {
                        txtBXLoanName.Text = "";
                    }
                    if (q.CostCenterEmp.HasValue)
                    {
                        txtBXCostCenterNo.Text = q.CostCenterEmp.Value.ToString();
                        txtBXCostCenterName.Text = ((LangArEn == 0) ? q.T_CstTbl.Arb_Des : q.T_CstTbl.Eng_Des);
                    }
                    else
                    {
                        txtBXCostCenterName.Text = "";
                        txtBXCostCenterNo.Text = "";
                    }
                    switchButton_AccType.Value = false;
                    txtBXBankNo.Text = "";
                    txtBXBankName.Text = "";
                }
            }
            catch
            {
                switchButton_AccType.Value = false;
                txtBXBankNo.Text = "";
                txtBXBankName.Text = "";
                txtBXLoanName.Text = "";
                txtBXLoanNo.Text = "";
                txtBXCostCenterName.Text = "";
                txtBXCostCenterNo.Text = "";
                textBox_Salary.Value = 0.0;
            }
        }
        private void checkBox_AccID_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_AccID.Checked)
            {
                panel_Acc.Enabled = true;
                comboBox_EmpNo_SelectedValueChanged(sender, e);
                return;
            }
            panel_Acc.Enabled = false;
            if (State == FormState.New)
            {
                txtBXBankName.Text = "";
                txtBXBankNo.Text = "";
                txtBXLoanName.Text = "";
                txtBXLoanNo.Text = "";
                txtBXCostCenterName.Text = "";
                txtBXCostCenterNo.Text = "";
            }
        }
        private void button_SrchBXBankNo_Click(object sender, EventArgs e)
        {
            FrmSearch frm;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection;
            if (!switchButton_AccType.Value)
            {
                columns_Names_visible2.Clear();
                columns_Names_visible2.Add("AccDef_No", new ColumnDictinary("?????????? ", " No", ifDefault: true, ""));
                columns_Names_visible2.Add("Arb_Des", new ColumnDictinary("?????????? ????????", "Arabic Name", ifDefault: true, ""));
                columns_Names_visible2.Add("Eng_Des", new ColumnDictinary("?????????? ??????????????????", "English Name", ifDefault: true, ""));
                columns_Names_visible2.Add("AccDef_ID", new ColumnDictinary(" ", " ", ifDefault: false, ""));
                columns_Names_visible2.Add("Mobile", new ColumnDictinary("????????????", "Mobile", ifDefault: false, ""));
                frm = new FrmSearch();
                frm.Tag = LangArEn;
                animalsAsCollection = columns_Names_visible2;
                foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
                {
                    frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, ""));
                }
                VarGeneral.SFrmTyp = "T_AccDef2";
                VarGeneral.AccTyp = 2;
                frm.TopMost = true;
                frm.ShowDialog();
                if (frm.SerachNo != "")
                {
                    Button_Edit_Click(sender, e);
                    T_AccDef _AccDef = db.StockAccDefs(int.Parse(frm.Serach_No));
                    txtBXBankNo.Text = _AccDef.AccDef_No.ToString();
                    if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
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
                    txtBXBankNo.Text = "";
                    txtBXBankName.Text = "";
                }
                return;
            }
            columns_Names_visible2.Clear();
            columns_Names_visible2.Add("AccDef_No", new ColumnDictinary("?????????? ", " No", ifDefault: true, ""));
            columns_Names_visible2.Add("Arb_Des", new ColumnDictinary("?????????? ????????", "Arabic Name", ifDefault: true, ""));
            columns_Names_visible2.Add("Eng_Des", new ColumnDictinary("?????????? ??????????????????", "English Name", ifDefault: true, ""));
            columns_Names_visible2.Add("AccDef_ID", new ColumnDictinary(" ", " ", ifDefault: false, ""));
            columns_Names_visible2.Add("Mobile", new ColumnDictinary("????????????", "Mobile", ifDefault: false, ""));
            frm = new FrmSearch();
            frm.Tag = LangArEn;
            animalsAsCollection = columns_Names_visible2;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, ""));
            }
            VarGeneral.SFrmTyp = "T_AccDef2";
            VarGeneral.AccTyp = 3;
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != "")
            {
                Button_Edit_Click(sender, e);
                T_AccDef _AccDef = db.StockAccDefs(int.Parse(frm.Serach_No));
                txtBXBankNo.Text = _AccDef.AccDef_No.ToString();
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
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
                txtBXBankNo.Text = "";
                txtBXBankName.Text = "";
            }
        }
        private void dataGridViewX_Advances_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if ((bool)dataGridViewX_Advances.Rows[e.RowIndex].Cells["IFState"].Value)
                {
                    MessageBox.Show((LangArEn == 0) ? " ???????????? ?????????? ???????? ?????????? ,, ???????? ????????" : "Can not adjust the value of the premium, because it is a relay", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    textBox_ID.Focus();
                }
            }
            catch
            {
            }
        }
        private void dataGridViewX_Advances_Click(object sender, EventArgs e)
        {
            Button_Edit_Click(sender, e);
        }
        private void checkBox_AccID_Click(object sender, EventArgs e)
        {
            Button_Edit_Click(sender, e);
        }
        private void textBox_ValuePremium_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewX_Advances.Rows.Count > 0)
                {
                    dataGridViewX_Advances.Rows.Clear();
                }
            }
            catch
            {
            }
            if (State == FormState.Edit || button_SavePremuim.Visible)
            {
                if (textBox_Remaining.Value <= 0.0 || db.T_Premiums.Where((T_Premium t) => t.Advances_No == (int?)data_this.Advances_No && !t.IFState.Value).ToList().Count == 0)
                {
                    return;
                }
                if (dataGridViewX_Advances.Rows.Count > 0)
                {
                    for (int i = 0; i < dataGridViewX_Advances.Rows.Count; i++)
                    {
                        if (!(dataGridViewX_Advances.Rows[i].Cells["IFState"].Value.ToString() == "False"))
                        {
                            continue;
                        }
                        for (int ii = i; ii < dataGridViewX_Advances.Rows.Count; ii++)
                        {
                            if (dataGridViewX_Advances.Rows[ii].Cells["IFState"].Value.ToString() == "True")
                            {
                                MessageBox.Show((LangArEn == 0) ? "???????????? ?????????? ?????????? .. ???????????? ???????????? ???? ?????? ???????? ?????????????? ?????????????? ???????????????? !" : "Can not be modified Loan .. Please confirm previous salary account and carryover!", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                return;
                            }
                        }
                    }
                }
                List<T_Premium> q = (from t in db.T_Premiums
                                     where t.Advances_No == (int?)int.Parse(textBox_ID.Text)
                                     where t.IFState == (bool?)true
                                     orderby t.Premiums_No
                                     select t).ToList();
                int iiCnt = 0;
                if (q.Count > 0)
                {
                    for (iiCnt = 0; iiCnt < q.Count; iiCnt++)
                    {
                        dataGridViewX_Advances.Rows.Add();
                        dataGridViewX_Advances.Rows[iiCnt].Cells["Premiums_ID"].Value = q[iiCnt].Premiums_ID.ToString();
                        dataGridViewX_Advances.Rows[iiCnt].Cells["Advances_No"].Value = q[iiCnt].Advances_No.Value.ToString();
                        dataGridViewX_Advances.Rows[iiCnt].Cells["Premiums_No"].Value = q[iiCnt].Premiums_No;
                        dataGridViewX_Advances.Rows[iiCnt].Cells["PremiumsDate"].Value = q[iiCnt].PremiumsDate;
                        dataGridViewX_Advances.Rows[iiCnt].Cells["ValuePremiums"].Value = q[iiCnt].ValuePremiums.Value;
                        dataGridViewX_Advances.Rows[iiCnt].Cells["Paying"].Value = q[iiCnt].Paying.Value;
                        dataGridViewX_Advances.Rows[iiCnt].Cells["IFState"].Value = q[iiCnt].IFState.Value;
                    }
                }
                int vValue1 = textBox_TotalPremiums.Value - dataGridViewX_Advances.Rows.Count;
                double vPaying = 0.0;
                try
                {
                    vPaying = double.Parse(VarGeneral.TString.TEmpty(string.Concat((from t in db.T_Premiums
                                                                                    where t.Advances_No == (int?)data_this.Advances_No
                                                                                    where t.Advances_No == (int?)data_this.Advances_No && t.IFState.Value
                                                                                    select t.Paying).Sum().Value)));
                }
                catch
                {
                    vPaying = 0.0;
                }
                double vValue2 = Math.Round(textBox_ValueAdvances.Value - vPaying, 2);
                double vValue3 = Math.Round(vValue2 / (double)vValue1, 2);
                for (int i = iiCnt; i < textBox_TotalPremiums.Value; i++)
                {
                    dataGridViewX_Advances.Rows.Add();
                    Guid id = Guid.NewGuid();
                    dataGridViewX_Advances.Rows[i].Cells["Premiums_ID"].Value = id.ToString();
                    dataGridViewX_Advances.Rows[i].Cells["Advances_No"].Value = int.Parse(textBox_ID.Text);
                    dataGridViewX_Advances.Rows[i].Cells["IFState"].Value = false;
                    dataGridViewX_Advances.Rows[i].Cells["Paying"].Value = 0;
                    dataGridViewX_Advances.Rows[i].Cells["Premiums_No"].Value = i + 1;
                    dataGridViewX_Advances.Rows[i].Cells["PremiumsDate"].Value = Convert.ToDateTime(dateTimeInput_warnDate.Text).AddMonths(i).ToString("yyyy/MM");
                    dataGridViewX_Advances.Rows[i].Cells["ValuePremiums"].Value = vValue3;
                }
            }
            else
            {
                for (int i = 0; i < textBox_TotalPremiums.Value; i++)
                {
                    dataGridViewX_Advances.Rows.Add();
                    Guid id = Guid.NewGuid();
                    dataGridViewX_Advances.Rows[i].Cells["Premiums_ID"].Value = id.ToString();
                    dataGridViewX_Advances.Rows[i].Cells["Advances_No"].Value = int.Parse(textBox_ID.Text);
                    dataGridViewX_Advances.Rows[i].Cells["IFState"].Value = false;
                    dataGridViewX_Advances.Rows[i].Cells["Paying"].Value = 0;
                    dataGridViewX_Advances.Rows[i].Cells["Premiums_No"].Value = i + 1;
                    dataGridViewX_Advances.Rows[i].Cells["PremiumsDate"].Value = Convert.ToDateTime(textBox_SalDate.Text).AddMonths(i).ToString("yyyy/MM");
                    dataGridViewX_Advances.Rows[i].Cells["ValuePremiums"].Value = textBox_ValuePremium.Value;
                }
            }
        }
        private void textBox_Remaining_ValueChanged(object sender, EventArgs e)
        {
            if (State == FormState.New || State == FormState.Edit)
            {
                return;
            }
            try
            {
                List<T_Premium> q = (from tt in db.T_Premiums
                                     orderby tt.Premiums_No
                                     where tt.Advances_No == (int?)int.Parse(textBox_ID.Text) && tt.IFState == (bool?)false
                                     select tt).ToList();
                textBox_Remaining.Value = ((q.Count == 0) ? data_this.ValueAdvances.Value : q.Sum((T_Premium g) => g.ValuePremiums.Value));
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("textBox_Remaining_ValueChanged:", error, enable: true);
            }
        }
        private void buttonItem_Cancel_Click(object sender, EventArgs e)
        {
            textBox_ID_TextChanged(sender, e);
        }
        private void button_SavePremuim_Click(object sender, EventArgs e)
        {
            double vSum = 0.0;
            for (int i = 0; i < dataGridViewX_Advances.Rows.Count; i++)
            {
                vSum += Math.Abs((double)dataGridViewX_Advances.Rows[i].Cells["ValuePremiums"].Value + 0.0);
            }
            if (Math.Round(vSum, 0) != Math.Round(data_this.ValueAdvances.Value, 0))
            {
                if (MessageBox.Show((LangArEn == 0) ? " ?????????? ?????????????? ???? ?????????? ???????????? ???????????? .. ???? ???????? ?????????????? ?????????????? ????????????????" : "Total premiums are not equal to the total advance .. Do you want to retrieve the previous installments?", VarGeneral.ProdectNam, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.No)
                {
                    buttonItem_Cancel_Click(sender, e);
                }
                return;
            }
            if (db.CheckEmp_Premium(data_this.Advances_No))
            {
                db.T_Premiums.DeleteAllOnSubmit(DataThis.T_Premiums);
                db.SubmitChanges();
            }
            try
            {
                data_this.TotalPremiums = textBox_TotalPremiums.Value;
            }
            catch
            {
                data_this.TotalPremiums = 0;
            }
            db.Log = VarGeneral.DebugLog;
            db.SubmitChanges(ConflictMode.ContinueOnConflict);
            AqsaatOp();
            buttonItem_Cancel_Click(sender, e);
        }
        private void button_SavePremuim_VisibleChanged(object sender, EventArgs e)
        {
            try
            {
                if (State != 0)
                {
                    textBox_ValueAdvances.IsInputReadOnly = false;
                }
                else if (button_SavePremuim.Visible)
                {
                    textBox_ValueAdvances.Value = data_this.ValueAdvances.Value;
                    textBox_ValueAdvances.IsInputReadOnly = true;
                }
                else
                {
                    textBox_ValueAdvances.IsInputReadOnly = false;
                }
            }
            catch
            {
                textBox_ValueAdvances.IsInputReadOnly = false;
            }
        }
        private void button_ScrhLoan_Click(object sender, EventArgs e)
        {
            columns_Names_visible2.Clear();
            columns_Names_visible2.Add("AccDef_No", new ColumnDictinary("?????????? ", " No", ifDefault: true, ""));
            columns_Names_visible2.Add("Arb_Des", new ColumnDictinary("?????????? ????????", "Arabic Name", ifDefault: true, ""));
            columns_Names_visible2.Add("Eng_Des", new ColumnDictinary("?????????? ??????????????????", "English Name", ifDefault: true, ""));
            columns_Names_visible2.Add("AccDef_ID", new ColumnDictinary(" ", " ", ifDefault: false, ""));
            columns_Names_visible2.Add("Mobile", new ColumnDictinary("????????????", "Mobile", ifDefault: false, ""));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible2;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, ""));
            }
            VarGeneral.SFrmTyp = "AccDefID_Setting";
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != "")
            {
                Button_Edit_Click(sender, e);
                txtBXLoanNo.Text = db.StockAccDefs(int.Parse(frm.Serach_No)).AccDef_No;
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                {
                    txtBXLoanName.Text = db.StockAccDefs(int.Parse(frm.Serach_No)).Arb_Des;
                }
                else
                {
                    txtBXLoanName.Text = db.StockAccDefs(int.Parse(frm.Serach_No)).Eng_Des;
                }
            }
            else
            {
                txtBXLoanNo.Text = "";
                txtBXLoanName.Text = "";
            }
        }
        private void switchButton_AccType_ValueChanged(object sender, EventArgs e)
        {
            if (!switchButton_AccType.Value)
            {
                button_CustD1.Enabled = false;
            }
            else
            {
                button_CustD1.Enabled = true;
            }
            txtBXBankNo.Text = "";
            txtBXBankName.Text = "";
        }
        private void button_SrchCostCenter_Click(object sender, EventArgs e)
        {
            columns_Names_visible2.Clear();
            columns_Names_visible2.Add("Cst_No", new ColumnDictinary("??????????", "No", ifDefault: true, ""));
            columns_Names_visible2.Add("Arb_Des", new ColumnDictinary("?????????? ????????", "Arabic Name", ifDefault: true, ""));
            columns_Names_visible2.Add("Eng_Des", new ColumnDictinary("?????????? ??????????????????", "English Name", ifDefault: true, ""));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible2;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, ""));
            }
            VarGeneral.SFrmTyp = "T_CstTbl";
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != "")
            {
                Button_Edit_Click(sender, e);
                txtBXCostCenterNo.Text = db.StockCst(frm.Serach_No).Cst_ID.ToString();
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                {
                    txtBXCostCenterName.Text = db.StockCst(frm.Serach_No).Arb_Des.ToString();
                }
                else
                {
                    txtBXCostCenterName.Text = db.StockCst(frm.Serach_No).Eng_Des.ToString();
                }
            }
            else
            {
                txtBXCostCenterNo.Text = "";
                txtBXCostCenterName.Text = "";
            }
        }
        private void switchButton_AccType_Click(object sender, EventArgs e)
        {
            Button_Edit_Click(sender, e);
        }
        private void button_CustD1_Click(object sender, EventArgs e)
        {
            if (State == FormState.Saved || comboBox_EmpNo.SelectedIndex == -1 || comboBox_EmpNo.SelectedIndex < 0)
            {
                return;
            }
            T_Emp q = db.EmpsEmp(comboBox_EmpNo.SelectedValue.ToString());
            if (!string.IsNullOrEmpty(q.AccountID))
            {
                txtBXBankNo.Text = q.AccountID;
                if (!string.IsNullOrEmpty(txtBXBankNo.Text))
                {
                    txtBXBankName.Text = ((LangArEn == 0) ? q.T_AccDef.Arb_Des : q.T_AccDef.Eng_Des);
                }
            }
        }
        private void button_CustD3_Click(object sender, EventArgs e)
        {
            if (State != 0 && comboBox_EmpNo.SelectedIndex != -1 && comboBox_EmpNo.SelectedIndex >= 0)
            {
                T_Emp q = db.EmpsEmp(comboBox_EmpNo.SelectedValue.ToString());
                txtBXLoanNo.Text = q.LoanAcc;
                if (!string.IsNullOrEmpty(txtBXLoanNo.Text))
                {
                    txtBXLoanName.Text = ((LangArEn == 0) ? q.T_AccDef3.Arb_Des : q.T_AccDef3.Eng_Des);
                }
            }
        }
        private void Button_PrintTable_Click(object sender, EventArgs e)
        {
            VarGeneral.IsGeneralUsed = true;
            FrmReportsViewer frm = new FrmReportsViewer();
            frm.Repvalue = "AdvancRep";



            frm.Tag = LangArEn;
            frm.Repvalue = "AdvancRep";
            VarGeneral.vTitle = Text;
            frm.SqlWhere = "";
            frm.TopMost = true;
            frm.ShowDialog();
            VarGeneral.IsGeneralUsed = false;

        }
        private void dataGridViewX_Advances_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 2 && dataGridViewX_Advances.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    oldValue = double.Parse(VarGeneral.TString.TEmpty(string.Concat(dataGridViewX_Advances.Rows[e.RowIndex].Cells[e.ColumnIndex].Value)));
                }
            }
            catch
            {
            }
        }
        private void dataGridViewX_Advances_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 2 && double.Parse(VarGeneral.TString.TEmpty(string.Concat(dataGridViewX_Advances.Rows[e.RowIndex].Cells[2].Value))) != oldValue)
                {
                    double newValue = 0.0;
                    newValue = oldValue - double.Parse(VarGeneral.TString.TEmpty(string.Concat(dataGridViewX_Advances.Rows[e.RowIndex].Cells[2].Value)));
                    dataGridViewX_Advances.Rows[dataGridViewX_Advances.Rows.Count - 1].Cells[e.ColumnIndex].Value = double.Parse(VarGeneral.TString.TEmpty(string.Concat(dataGridViewX_Advances.Rows[dataGridViewX_Advances.Rows.Count - 1].Cells[e.ColumnIndex].Value))) + newValue;
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("dataGridViewX_Advances_CellEndEdit:", error, enable: true);
            }
        }
    }
}
