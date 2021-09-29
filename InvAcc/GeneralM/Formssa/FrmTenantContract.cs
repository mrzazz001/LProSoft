using C1.Win.C1BarCode;
using C1.Win.C1FlexGrid;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.DotNetBar.SuperGrid;
using DevComponents.DotNetBar.SuperGrid.Style;
using DevComponents.Editors;
using InvAcc.GeneralM;
using InvAcc.Stock_Data;
using Library.RepShow;
using Microsoft.Office.Interop.Word;
using SSSDateTime.Date;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial class FrmTenantContract : Form
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
        protected IntegerInput Rep_RecCount;
        protected ToolStripMenuItem ToolStripMenuItem_Rep;
        private RibbonBar ribbonBar1;
        private DockSite barTopDockSite;
        private DockSite barBottomDockSite;
        private DockSite barLeftDockSite;
        private DockSite barRightDockSite;
        private DockSite dockSite1;
        private DockSite dockSite2;
        public DotNetBarManager dotNetBarManager1;
        private DockSite dockSite4;
        private DockSite dockSite3;
        protected ContextMenuStrip contextMenuStrip1;
        protected ContextMenuStrip contextMenuStrip2;
        protected ToolStripMenuItem ToolStripMenuItem_Det;
        private OpenFileDialog openFileDialog1;
        private SaveFileDialog saveFileDialog1;
        private PanelEx panelEx3;
        private PanelEx panelEx2;
        private ExpandableSplitter expandableSplitter1;
        private Panel panel1;
        private RibbonBar ribbonBar_Tasks;
        private SuperTabControl superTabControl_Main1;
        protected ButtonItem Button_Close;
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
        protected SuperGridControl DGV_Main;
        private RibbonBar ribbonBar_DGV;
        private SuperTabControl superTabControl_DGV;
        protected TextBoxItem textBox_search;
        protected ButtonItem Button_ExportTable2;
        protected ButtonItem Button_PrintTable;
        protected LabelItem labelItem3;
        private Label label19;
        private Label label4;
        private Label label2;
        private Label label1;
        private C1BarCode c1BarCode1;
        private ButtonX button_SrchEqarADD;
        private ButtonX button_SrchEqarNo;
        private DoubleInput txtRentOfYear;
        private MaskedTextBox txtContractStart;
        internal TextBox txtEqarName;
        private TextBox txtEqarNo;
        private LabelItem lable_Records;
        internal Label label22;
        private TextBox txtAinNo;
        private ButtonX button_SrchAinNo;
        private Label label3;
        private MaskedTextBox txtContractEnd;
        private Label label7;
        private TextBox txtAinTyp;
        public TextBox txtTenantName;
        public TextBox txtTenantNo;
        public ButtonItem Button_Payment;
        public ButtonItem Button_Renwal;
        public TextBox textBox_ID;
        public ButtonItem Button_ShowContract;
        public ButtonItem Button_DelContract;
        public Dictionary<string, ColumnDictinary> columns_Names_visible = new Dictionary<string, ColumnDictinary>();
        public Dictionary<string, ColumnDictinary> columns_Names_visible2 = new Dictionary<string, ColumnDictinary>();
        private ScriptNumber ScriptNumber1 = new ScriptNumber();
        private HijriGreg.HijriGregDates n = new HijriGreg.HijriGregDates();
        private T_AccDef _AccDefBind = new T_AccDef();
        private int LangArEn = 0;
        public int ProcessTyp = 0;
        public string TenantNo_ = "";
        public string TenantNm_ = "";
        public string TenantID_ = "";
        protected bool ifOkDelete;
        public bool CanEdit = true;
        protected bool CanInsert = true;
        private string FlagUpdate = "";
        public ViewState ViewState = ViewState.Deiles;
        private FormState statex;
        public List<Control> controls;
        public Control codeControl = new Control();
        private T_INVSETTING _InvSetting = new T_INVSETTING();
        private T_Company _Company = new T_Company();
        private T_AinsData _AinDet = new T_AinsData();
        private List<T_AinTyp> listAinTyp = new List<T_AinTyp>();
        private List<T_AinNatural> listAinNature = new List<T_AinNatural>();
        private T_AinTyp _AinTyp = new T_AinTyp();
        private T_AinNatural _AinNature = new T_AinNatural();
        private bool canUpdate = true;
        private T_TenantContract data_this;
        private Stock_DataDataContext dbInstance;
        private List<string> pkeys = new List<string>();
        private Rate_DataDataContext dbInstanceRate;
        private T_User permission = new T_User();
        public int _ContractNo;
        private T_TenantContract oldData = new T_TenantContract();
        private bool IsNew = false;
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
        public T_TenantContract DataThis
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
                Button_Renwal.Enabled = value;
                Button_Payment.Enabled = value;
                Button_ShowContract.Enabled = value;
                Button_DelContract.Enabled = value;
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
                }
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InvAcc.Forms.FrmTenantContract));
            DevComponents.DotNetBar.SuperGrid.Style.Background background1 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.Style.Background background2 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.Style.Background background3 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.Style.BorderColor borderColor1 = new DevComponents.DotNetBar.SuperGrid.Style.BorderColor();
            DevComponents.DotNetBar.SuperGrid.Style.BorderColor borderColor2 = new DevComponents.DotNetBar.SuperGrid.Style.BorderColor();
            DevComponents.DotNetBar.SuperGrid.Style.BaseTreeButtonVisualStyle baseTreeButtonVisualStyle1 = new DevComponents.DotNetBar.SuperGrid.Style.BaseTreeButtonVisualStyle();
            DevComponents.DotNetBar.SuperGrid.Style.BaseTreeButtonVisualStyle baseTreeButtonVisualStyle2 = new DevComponents.DotNetBar.SuperGrid.Style.BaseTreeButtonVisualStyle();
            DevComponents.DotNetBar.SuperGrid.Style.Background background4 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            Rep_RecCount = new DevComponents.Editors.IntegerInput();
            ToolStripMenuItem_Rep = new System.Windows.Forms.ToolStripMenuItem();
            ribbonBar1 = new DevComponents.DotNetBar.RibbonBar();
            txtAinTyp = new System.Windows.Forms.TextBox();
            txtTenantNo = new System.Windows.Forms.TextBox();
            txtContractEnd = new System.Windows.Forms.MaskedTextBox();
            label7 = new System.Windows.Forms.Label();
            button_SrchAinNo = new DevComponents.DotNetBar.ButtonX();
            label3 = new System.Windows.Forms.Label();
            txtContractStart = new System.Windows.Forms.MaskedTextBox();
            txtEqarName = new System.Windows.Forms.TextBox();
            button_SrchEqarADD = new DevComponents.DotNetBar.ButtonX();
            txtEqarNo = new System.Windows.Forms.TextBox();
            button_SrchEqarNo = new DevComponents.DotNetBar.ButtonX();
            label22 = new System.Windows.Forms.Label();
            label19 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            txtRentOfYear = new DevComponents.Editors.DoubleInput();
            c1BarCode1 = new C1.Win.C1BarCode.C1BarCode();
            textBox_ID = new System.Windows.Forms.TextBox();
            txtTenantName = new System.Windows.Forms.TextBox();
            txtAinNo = new System.Windows.Forms.TextBox();
            barTopDockSite = new DevComponents.DotNetBar.DockSite();
            barBottomDockSite = new DevComponents.DotNetBar.DockSite();
            barLeftDockSite = new DevComponents.DotNetBar.DockSite();
            barRightDockSite = new DevComponents.DotNetBar.DockSite();
            dockSite1 = new DevComponents.DotNetBar.DockSite();
            dockSite2 = new DevComponents.DotNetBar.DockSite();
            dotNetBarManager1 = new DevComponents.DotNetBar.DotNetBarManager(components);
            dockSite4 = new DevComponents.DotNetBar.DockSite();
            dockSite3 = new DevComponents.DotNetBar.DockSite();
            contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(components);
            contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(components);
            ToolStripMenuItem_Det = new System.Windows.Forms.ToolStripMenuItem();
            openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            panelEx3 = new DevComponents.DotNetBar.PanelEx();
            DGV_Main = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            ribbonBar_DGV = new DevComponents.DotNetBar.RibbonBar();
            superTabControl_DGV = new DevComponents.DotNetBar.SuperTabControl();
            textBox_search = new DevComponents.DotNetBar.TextBoxItem();
            Button_ExportTable2 = new DevComponents.DotNetBar.ButtonItem();
            Button_PrintTable = new DevComponents.DotNetBar.ButtonItem();
            labelItem3 = new DevComponents.DotNetBar.LabelItem();
            panelEx2 = new DevComponents.DotNetBar.PanelEx();
            ribbonBar_Tasks = new DevComponents.DotNetBar.RibbonBar();
            superTabControl_Main1 = new DevComponents.DotNetBar.SuperTabControl();
            Button_Close = new DevComponents.DotNetBar.ButtonItem();
            Button_Payment = new DevComponents.DotNetBar.ButtonItem();
            Button_Renwal = new DevComponents.DotNetBar.ButtonItem();
            Button_Save = new DevComponents.DotNetBar.ButtonItem();
            Button_Add = new DevComponents.DotNetBar.ButtonItem();
            labelItem2 = new DevComponents.DotNetBar.LabelItem();
            Button_ShowContract = new DevComponents.DotNetBar.ButtonItem();
            Button_DelContract = new DevComponents.DotNetBar.ButtonItem();
            superTabControl_Main2 = new DevComponents.DotNetBar.SuperTabControl();
            labelItem1 = new DevComponents.DotNetBar.LabelItem();
            Button_First = new DevComponents.DotNetBar.ButtonItem();
            Button_Prev = new DevComponents.DotNetBar.ButtonItem();
            TextBox_Index = new DevComponents.DotNetBar.TextBoxItem();
            Label_Count = new DevComponents.DotNetBar.LabelItem();
            lable_Records = new DevComponents.DotNetBar.LabelItem();
            Button_Next = new DevComponents.DotNetBar.ButtonItem();
            Button_Last = new DevComponents.DotNetBar.ButtonItem();
            expandableSplitter1 = new DevComponents.DotNetBar.ExpandableSplitter();
            panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)Rep_RecCount).BeginInit();
            ribbonBar1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtRentOfYear).BeginInit();
            contextMenuStrip2.SuspendLayout();
            panelEx3.SuspendLayout();
            ribbonBar_DGV.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)superTabControl_DGV).BeginInit();
            panelEx2.SuspendLayout();
            ribbonBar_Tasks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)superTabControl_Main1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)superTabControl_Main2).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            Rep_RecCount.AllowEmptyState = false;
            Rep_RecCount.BackgroundStyle.Class = "DateTimeInputBackground";
            Rep_RecCount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            Rep_RecCount.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            resources.ApplyResources(Rep_RecCount, "Rep_RecCount");
            Rep_RecCount.Increment = 0;
            Rep_RecCount.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            Rep_RecCount.IsInputReadOnly = true;
            Rep_RecCount.Name = "Rep_RecCount";
            Rep_RecCount.WatermarkAlignment = DevComponents.Editors.eTextAlignment.Center;
            ToolStripMenuItem_Rep.Checked = true;
            ToolStripMenuItem_Rep.CheckState = System.Windows.Forms.CheckState.Checked;
            ToolStripMenuItem_Rep.Name = "ToolStripMenuItem_Rep";
            resources.ApplyResources(ToolStripMenuItem_Rep, "ToolStripMenuItem_Rep");
            ribbonBar1.AutoOverflowEnabled = true;
            ribbonBar1.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            ribbonBar1.BackgroundStyle.BackColor = System.Drawing.Color.AliceBlue;
            ribbonBar1.BackgroundStyle.BackColor2 = System.Drawing.SystemColors.GradientActiveCaption;
            ribbonBar1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            ribbonBar1.ContainerControlProcessDialogKey = true;
            ribbonBar1.Controls.Add(txtAinTyp);
            ribbonBar1.Controls.Add(txtTenantNo);
            ribbonBar1.Controls.Add(txtContractEnd);
            ribbonBar1.Controls.Add(label7);
            ribbonBar1.Controls.Add(button_SrchAinNo);
            ribbonBar1.Controls.Add(label3);
            ribbonBar1.Controls.Add(txtContractStart);
            ribbonBar1.Controls.Add(txtEqarName);
            ribbonBar1.Controls.Add(button_SrchEqarADD);
            ribbonBar1.Controls.Add(txtEqarNo);
            ribbonBar1.Controls.Add(button_SrchEqarNo);
            ribbonBar1.Controls.Add(label22);
            ribbonBar1.Controls.Add(label19);
            ribbonBar1.Controls.Add(label4);
            ribbonBar1.Controls.Add(label2);
            ribbonBar1.Controls.Add(label1);
            ribbonBar1.Controls.Add(txtRentOfYear);
            ribbonBar1.Controls.Add(c1BarCode1);
            ribbonBar1.Controls.Add(textBox_ID);
            ribbonBar1.Controls.Add(txtTenantName);
            ribbonBar1.Controls.Add(txtAinNo);
            resources.ApplyResources(ribbonBar1, "ribbonBar1");
            ribbonBar1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            ribbonBar1.Name = "ribbonBar1";
            ribbonBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            ribbonBar1.TitleStyle.BackColor = System.Drawing.Color.FromArgb(227, 239, 255);
            ribbonBar1.TitleStyle.BackColor2 = System.Drawing.Color.FromArgb(101, 147, 207);
            ribbonBar1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            ribbonBar1.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            txtAinTyp.BackColor = System.Drawing.Color.DarkSeaGreen;
            txtAinTyp.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
            resources.ApplyResources(txtAinTyp, "txtAinTyp");
            txtAinTyp.Name = "txtAinTyp";
            txtAinTyp.ReadOnly = true;
            txtTenantNo.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
            txtTenantNo.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
            resources.ApplyResources(txtTenantNo, "txtTenantNo");
            txtTenantNo.Name = "txtTenantNo";
            txtTenantNo.ReadOnly = true;
            txtContractEnd.BackColor = System.Drawing.Color.WhiteSmoke;
            resources.ApplyResources(txtContractEnd, "txtContractEnd");
            txtContractEnd.Name = "txtContractEnd";
            txtContractEnd.Leave += new System.EventHandler(txtContractEnd_Leave);
            txtContractEnd.Click += new System.EventHandler(txtContractEnd_Click);
            resources.ApplyResources(label7, "label7");
            label7.Name = "label7";
            button_SrchAinNo.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            button_SrchAinNo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            resources.ApplyResources(button_SrchAinNo, "button_SrchAinNo");
            button_SrchAinNo.Name = "button_SrchAinNo";
            button_SrchAinNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            button_SrchAinNo.Symbol = "\uf002";
            button_SrchAinNo.SymbolSize = 12f;
            button_SrchAinNo.TextColor = System.Drawing.Color.SteelBlue;
            button_SrchAinNo.Click += new System.EventHandler(button_SrchAinNo_Click);
            resources.ApplyResources(label3, "label3");
            label3.Name = "label3";
            txtContractStart.BackColor = System.Drawing.Color.WhiteSmoke;
            resources.ApplyResources(txtContractStart, "txtContractStart");
            txtContractStart.Name = "txtContractStart";
            txtContractStart.Leave += new System.EventHandler(txtContractStart_Leave);
            txtContractStart.Click += new System.EventHandler(txtContractStart_Click);
            resources.ApplyResources(txtEqarName, "txtEqarName");
            txtEqarName.BackColor = System.Drawing.SystemColors.Window;
            txtEqarName.Name = "txtEqarName";
            txtEqarName.ReadOnly = true;
            button_SrchEqarADD.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            button_SrchEqarADD.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            resources.ApplyResources(button_SrchEqarADD, "button_SrchEqarADD");
            button_SrchEqarADD.Name = "button_SrchEqarADD";
            button_SrchEqarADD.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            button_SrchEqarADD.Symbol = "\uf055";
            button_SrchEqarADD.SymbolSize = 12f;
            button_SrchEqarADD.TextColor = System.Drawing.Color.SteelBlue;
            button_SrchEqarADD.Click += new System.EventHandler(button_SrchOwnerADD_Click);
            txtEqarNo.BackColor = System.Drawing.Color.White;
            txtEqarNo.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
            resources.ApplyResources(txtEqarNo, "txtEqarNo");
            txtEqarNo.Name = "txtEqarNo";
            txtEqarNo.ReadOnly = true;
            button_SrchEqarNo.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            button_SrchEqarNo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            resources.ApplyResources(button_SrchEqarNo, "button_SrchEqarNo");
            button_SrchEqarNo.Name = "button_SrchEqarNo";
            button_SrchEqarNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            button_SrchEqarNo.Symbol = "\uf002";
            button_SrchEqarNo.SymbolSize = 12f;
            button_SrchEqarNo.TextColor = System.Drawing.Color.SteelBlue;
            button_SrchEqarNo.Click += new System.EventHandler(button_SrchEqarNo_Click);
            resources.ApplyResources(label22, "label22");
            label22.BackColor = System.Drawing.Color.Transparent;
            label22.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            label22.Name = "label22";
            resources.ApplyResources(label19, "label19");
            label19.Name = "label19";
            resources.ApplyResources(label4, "label4");
            label4.Name = "label4";
            resources.ApplyResources(label2, "label2");
            label2.Name = "label2";
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            txtRentOfYear.AllowEmptyState = false;
            txtRentOfYear.BackgroundStyle.Class = "DateTimeInputBackground";
            txtRentOfYear.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            txtRentOfYear.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            txtRentOfYear.DisplayFormat = "0.00";
            resources.ApplyResources(txtRentOfYear, "txtRentOfYear");
            txtRentOfYear.Increment = 1.0;
            txtRentOfYear.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            txtRentOfYear.Name = "txtRentOfYear";
            txtRentOfYear.ShowUpDown = true;
            c1BarCode1.BarWide = 1;
            c1BarCode1.CodeType = C1.Win.C1BarCode.CodeTypeEnum.Code128;
            resources.ApplyResources(c1BarCode1, "c1BarCode1");
            c1BarCode1.Name = "c1BarCode1";
            c1BarCode1.ShowText = true;
            c1BarCode1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            textBox_ID.BackColor = System.Drawing.Color.FromArgb(255, 224, 192);
            resources.ApplyResources(textBox_ID, "textBox_ID");
            textBox_ID.Name = "textBox_ID";
            textBox_ID.ReadOnly = true;
            textBox_ID.Tag = "";
            textBox_ID.TextChanged += new System.EventHandler(textBox_ID_TextChanged);
            textBox_ID.Click += new System.EventHandler(textBox_ID_Click);
            textBox_ID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(textBox_ID_KeyPress);
            txtTenantName.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
            txtTenantName.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
            resources.ApplyResources(txtTenantName, "txtTenantName");
            txtTenantName.Name = "txtTenantName";
            txtTenantName.ReadOnly = true;
            txtAinNo.BackColor = System.Drawing.Color.White;
            txtAinNo.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
            resources.ApplyResources(txtAinNo, "txtAinNo");
            txtAinNo.Name = "txtAinNo";
            txtAinNo.ReadOnly = true;
            barTopDockSite.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            resources.ApplyResources(barTopDockSite, "barTopDockSite");
            barTopDockSite.DocumentDockContainer = new DevComponents.DotNetBar.DocumentDockContainer();
            barTopDockSite.Name = "barTopDockSite";
            barTopDockSite.TabStop = false;
            barBottomDockSite.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            resources.ApplyResources(barBottomDockSite, "barBottomDockSite");
            barBottomDockSite.DocumentDockContainer = new DevComponents.DotNetBar.DocumentDockContainer();
            barBottomDockSite.Name = "barBottomDockSite";
            barBottomDockSite.TabStop = false;
            barLeftDockSite.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            resources.ApplyResources(barLeftDockSite, "barLeftDockSite");
            barLeftDockSite.DocumentDockContainer = new DevComponents.DotNetBar.DocumentDockContainer();
            barLeftDockSite.Name = "barLeftDockSite";
            barLeftDockSite.TabStop = false;
            barRightDockSite.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            resources.ApplyResources(barRightDockSite, "barRightDockSite");
            barRightDockSite.DocumentDockContainer = new DevComponents.DotNetBar.DocumentDockContainer();
            barRightDockSite.Name = "barRightDockSite";
            barRightDockSite.TabStop = false;
            dockSite1.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            resources.ApplyResources(dockSite1, "dockSite1");
            dockSite1.Name = "dockSite1";
            dockSite1.TabStop = false;
            dockSite2.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            resources.ApplyResources(dockSite2, "dockSite2");
            dockSite2.Name = "dockSite2";
            dockSite2.TabStop = false;
            dotNetBarManager1.BottomDockSite = barBottomDockSite;
            dotNetBarManager1.LeftDockSite = barLeftDockSite;
            dotNetBarManager1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            dotNetBarManager1.MdiSystemItemVisible = false;
            dotNetBarManager1.ParentForm = null;
            dotNetBarManager1.RightDockSite = barRightDockSite;
            dotNetBarManager1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2000;
            dotNetBarManager1.ToolbarBottomDockSite = dockSite4;
            dotNetBarManager1.ToolbarLeftDockSite = dockSite1;
            dotNetBarManager1.ToolbarRightDockSite = dockSite2;
            dotNetBarManager1.ToolbarTopDockSite = dockSite3;
            dotNetBarManager1.TopDockSite = barTopDockSite;
            dockSite4.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            resources.ApplyResources(dockSite4, "dockSite4");
            dockSite4.Name = "dockSite4";
            dockSite4.TabStop = false;
            dockSite3.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            resources.ApplyResources(dockSite3, "dockSite3");
            dockSite3.Name = "dockSite3";
            dockSite3.TabStop = false;
            contextMenuStrip1.Name = "contextMenuStrip1";
            resources.ApplyResources(contextMenuStrip1, "contextMenuStrip1");
            contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[2]
            {
                ToolStripMenuItem_Det,
                ToolStripMenuItem_Rep
            });
            contextMenuStrip2.Name = "contextMenuStrip2";
            resources.ApplyResources(contextMenuStrip2, "contextMenuStrip2");
            ToolStripMenuItem_Det.Name = "ToolStripMenuItem_Det";
            resources.ApplyResources(ToolStripMenuItem_Det, "ToolStripMenuItem_Det");
            openFileDialog1.DefaultExt = "*.rtf";
            resources.ApplyResources(openFileDialog1, "openFileDialog1");
            openFileDialog1.FilterIndex = 2;
            saveFileDialog1.DefaultExt = "*.rtf";
            saveFileDialog1.FileName = "doc1";
            resources.ApplyResources(saveFileDialog1, "saveFileDialog1");
            saveFileDialog1.FilterIndex = 2;
            panelEx3.Controls.Add(DGV_Main);
            panelEx3.Controls.Add(ribbonBar_DGV);
            resources.ApplyResources(panelEx3, "panelEx3");
            panelEx3.Name = "panelEx3";
            panelEx3.Style.Alignment = System.Drawing.StringAlignment.Center;
            panelEx3.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            panelEx3.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            panelEx3.Style.BackgroundImagePosition = DevComponents.DotNetBar.eBackgroundImagePosition.Tile;
            panelEx3.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            panelEx3.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            panelEx3.Style.GradientAngle = 90;
            DGV_Main.BackColor = System.Drawing.Color.Transparent;
            background1.BackFillType = DevComponents.DotNetBar.SuperGrid.Style.BackFillType.VerticalCenter;
            background1.Color1 = System.Drawing.Color.Silver;
            background1.Color2 = System.Drawing.Color.White;
            DGV_Main.DefaultVisualStyles.GroupByStyles.Default.Background = background1;
            background2.BackFillType = DevComponents.DotNetBar.SuperGrid.Style.BackFillType.Center;
            background2.Color1 = System.Drawing.Color.LightSteelBlue;
            DGV_Main.DefaultVisualStyles.RowStyles.Default.Background = background2;
            background3.Color1 = System.Drawing.Color.FromArgb(255, 255, 192);
            DGV_Main.DefaultVisualStyles.RowStyles.MouseOver.Background = background3;
            resources.ApplyResources(DGV_Main, "DGV_Main");
            DGV_Main.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            DGV_Main.ForeColor = System.Drawing.Color.Black;
            DGV_Main.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            DGV_Main.Name = "DGV_Main";
            DGV_Main.PrimaryGrid.ActiveRowIndicatorStyle = DevComponents.DotNetBar.SuperGrid.ActiveRowIndicatorStyle.Both;
            DGV_Main.PrimaryGrid.AllowEdit = false;
            DGV_Main.PrimaryGrid.Caption.BackgroundImageLayout = DevComponents.DotNetBar.SuperGrid.GridBackgroundImageLayout.Center;
            DGV_Main.PrimaryGrid.Caption.Text = "";
            DGV_Main.PrimaryGrid.Caption.Visible = false;
            DGV_Main.PrimaryGrid.DefaultVisualStyles.AlternateColumnCellStyles.Default.AllowWrap = DevComponents.DotNetBar.SuperGrid.Style.Tbool.False;
            DGV_Main.PrimaryGrid.DefaultVisualStyles.AlternateColumnCellStyles.Default.TextColor = System.Drawing.Color.Black;
            DGV_Main.PrimaryGrid.DefaultVisualStyles.AlternateRowCellStyles.Default.AllowWrap = DevComponents.DotNetBar.SuperGrid.Style.Tbool.False;
            DGV_Main.PrimaryGrid.DefaultVisualStyles.AlternateRowCellStyles.Default.TextColor = System.Drawing.Color.Black;
            DGV_Main.PrimaryGrid.DefaultVisualStyles.CaptionStyles.Default.Font = new System.Drawing.Font("Tahoma", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            DGV_Main.PrimaryGrid.DefaultVisualStyles.CaptionStyles.Default.TextColor = System.Drawing.Color.White;
            DGV_Main.PrimaryGrid.DefaultVisualStyles.CaptionStyles.ReadOnly.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            DGV_Main.PrimaryGrid.DefaultVisualStyles.CellStyles.Selected.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            DGV_Main.PrimaryGrid.DefaultVisualStyles.ColumnHeaderRowStyles.Default.RowHeader.AllowWrap = DevComponents.DotNetBar.SuperGrid.Style.Tbool.True;
            borderColor1.Bottom = System.Drawing.Color.Black;
            borderColor1.Left = System.Drawing.Color.Black;
            borderColor1.Right = System.Drawing.Color.Black;
            borderColor1.Top = System.Drawing.Color.Black;
            DGV_Main.PrimaryGrid.DefaultVisualStyles.ColumnHeaderStyles.Default.BorderColor = borderColor1;
            DGV_Main.PrimaryGrid.DefaultVisualStyles.ColumnHeaderStyles.Default.Font = new System.Drawing.Font("Tahoma", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            DGV_Main.PrimaryGrid.DefaultVisualStyles.ColumnHeaderStyles.Default.TextColor = System.Drawing.Color.SteelBlue;
            DGV_Main.PrimaryGrid.DefaultVisualStyles.FilterColumnHeaderStyles.Default.TextColor = System.Drawing.Color.White;
            DGV_Main.PrimaryGrid.DefaultVisualStyles.FooterStyles.Default.TextColor = System.Drawing.Color.White;
            DGV_Main.PrimaryGrid.DefaultVisualStyles.GridPanelStyle.AllowWrap = DevComponents.DotNetBar.SuperGrid.Style.Tbool.False;
            borderColor2.Bottom = System.Drawing.Color.Black;
            borderColor2.Left = System.Drawing.Color.Black;
            borderColor2.Right = System.Drawing.Color.Black;
            borderColor2.Top = System.Drawing.Color.Black;
            DGV_Main.PrimaryGrid.DefaultVisualStyles.GridPanelStyle.BorderColor = borderColor2;
            baseTreeButtonVisualStyle1.BorderColor = System.Drawing.Color.White;
            baseTreeButtonVisualStyle1.LineColor = System.Drawing.Color.White;
            DGV_Main.PrimaryGrid.DefaultVisualStyles.GridPanelStyle.CircleTreeButtonStyle.ExpandButton = baseTreeButtonVisualStyle1;
            DGV_Main.PrimaryGrid.DefaultVisualStyles.GridPanelStyle.HeaderHLinePattern = DevComponents.DotNetBar.SuperGrid.Style.LinePattern.None;
            background4.Color1 = System.Drawing.Color.FromArgb(255, 255, 192);
            baseTreeButtonVisualStyle2.Background = background4;
            DGV_Main.PrimaryGrid.DefaultVisualStyles.GridPanelStyle.SquareTreeButtonStyle.ExpandButton = baseTreeButtonVisualStyle2;
            DGV_Main.PrimaryGrid.DefaultVisualStyles.GridPanelStyle.TextColor = System.Drawing.Color.White;
            DGV_Main.PrimaryGrid.DefaultVisualStyles.TitleStyles.Default.RowHeaderStyle.TextAlignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            DGV_Main.PrimaryGrid.GroupByRow.RowHeaderVisibility = DevComponents.DotNetBar.SuperGrid.RowHeaderVisibility.Never;
            DGV_Main.PrimaryGrid.GroupByRow.Text = "جميــع السجــــلات";
            DGV_Main.PrimaryGrid.GroupByRow.Visible = true;
            DGV_Main.PrimaryGrid.GroupByRow.WatermarkText = "";
            DGV_Main.PrimaryGrid.InitialActiveRow = DevComponents.DotNetBar.SuperGrid.RelativeRow.None;
            DGV_Main.PrimaryGrid.InitialSelection = DevComponents.DotNetBar.SuperGrid.RelativeSelection.None;
            DGV_Main.PrimaryGrid.MultiSelect = false;
            DGV_Main.PrimaryGrid.ShowRowGridIndex = true;
            DGV_Main.PrimaryGrid.Title.AllowSelection = false;
            DGV_Main.PrimaryGrid.Title.Text = "";
            DGV_Main.PrimaryGrid.Title.Visible = false;
            DGV_Main.PrimaryGrid.Visible = false;
            ribbonBar_DGV.AutoOverflowEnabled = true;
            ribbonBar_DGV.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            ribbonBar_DGV.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            ribbonBar_DGV.ContainerControlProcessDialogKey = true;
            ribbonBar_DGV.Controls.Add(superTabControl_DGV);
            resources.ApplyResources(ribbonBar_DGV, "ribbonBar_DGV");
            ribbonBar_DGV.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            ribbonBar_DGV.Name = "ribbonBar_DGV";
            ribbonBar_DGV.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            ribbonBar_DGV.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            ribbonBar_DGV.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            ribbonBar_DGV.TitleVisible = false;
            superTabControl_DGV.BackColor = System.Drawing.Color.White;
            superTabControl_DGV.CausesValidation = false;
            superTabControl_DGV.ControlBox.CloseBox.Name = "";
            superTabControl_DGV.ControlBox.MenuBox.Name = "";
            superTabControl_DGV.ControlBox.Name = "";
            superTabControl_DGV.ControlBox.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[2]
            {
                superTabControl_DGV.ControlBox.MenuBox,
                superTabControl_DGV.ControlBox.CloseBox
            });
            superTabControl_DGV.ControlBox.Visible = false;
            resources.ApplyResources(superTabControl_DGV, "superTabControl_DGV");
            superTabControl_DGV.ForeColor = System.Drawing.Color.Black;
            superTabControl_DGV.ItemPadding.Bottom = 4;
            superTabControl_DGV.ItemPadding.Left = 4;
            superTabControl_DGV.ItemPadding.Right = 4;
            superTabControl_DGV.ItemPadding.Top = 4;
            superTabControl_DGV.Name = "superTabControl_DGV";
            superTabControl_DGV.ReorderTabsEnabled = true;
            superTabControl_DGV.SelectedTabIndex = -1;
            superTabControl_DGV.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[4]
            {
                textBox_search,
                Button_ExportTable2,
                Button_PrintTable,
                labelItem3
            });
            superTabControl_DGV.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.WinMediaPlayer12;
            superTabControl_DGV.TextAlignment = DevComponents.DotNetBar.eItemAlignment.Center;
            textBox_search.ButtonCustom.Text = resources.GetString("textBox_search.ButtonCustom.Text");
            textBox_search.ButtonCustom.Visible = true;
            textBox_search.Name = "textBox_search";
            resources.ApplyResources(textBox_search, "textBox_search");
            textBox_search.TextBoxHeight = 44;
            textBox_search.TextBoxWidth = 150;
            textBox_search.WatermarkColor = System.Drawing.SystemColors.GrayText;
            Button_ExportTable2.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            Button_ExportTable2.FontBold = true;
            Button_ExportTable2.FontItalic = true;
            Button_ExportTable2.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
            Button_ExportTable2.Image = (System.Drawing.Image)resources.GetObject("Button_ExportTable2.Image");
            Button_ExportTable2.ImageFixedSize = new System.Drawing.Size(32, 32);
            Button_ExportTable2.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            Button_ExportTable2.Name = "Button_ExportTable2";
            Button_ExportTable2.SubItemsExpandWidth = 14;
            Button_ExportTable2.Symbol = "\uf064";
            Button_ExportTable2.SymbolSize = 15f;
            resources.ApplyResources(Button_ExportTable2, "Button_ExportTable2");
            Button_PrintTable.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            Button_PrintTable.Checked = true;
            Button_PrintTable.FontBold = true;
            Button_PrintTable.FontItalic = true;
            Button_PrintTable.Image = (System.Drawing.Image)resources.GetObject("Button_PrintTable.Image");
            Button_PrintTable.ImageFixedSize = new System.Drawing.Size(32, 32);
            Button_PrintTable.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            Button_PrintTable.Name = "Button_PrintTable";
            Button_PrintTable.SubItemsExpandWidth = 14;
            Button_PrintTable.Symbol = "\uf0c5";
            Button_PrintTable.SymbolSize = 15f;
            resources.ApplyResources(Button_PrintTable, "Button_PrintTable");
            labelItem3.Name = "labelItem3";
            labelItem3.Width = 40;
            panelEx2.Controls.Add(ribbonBar1);
            panelEx2.Controls.Add(ribbonBar_Tasks);
            resources.ApplyResources(panelEx2, "panelEx2");
            panelEx2.MinimumSize = new System.Drawing.Size(658, 227);
            panelEx2.Name = "panelEx2";
            panelEx2.Style.Alignment = System.Drawing.StringAlignment.Center;
            panelEx2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            panelEx2.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            panelEx2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            panelEx2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            panelEx2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            panelEx2.Style.GradientAngle = 90;
            ribbonBar_Tasks.AutoOverflowEnabled = true;
            ribbonBar_Tasks.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            ribbonBar_Tasks.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            ribbonBar_Tasks.ContainerControlProcessDialogKey = true;
            ribbonBar_Tasks.Controls.Add(superTabControl_Main1);
            ribbonBar_Tasks.Controls.Add(superTabControl_Main2);
            resources.ApplyResources(ribbonBar_Tasks, "ribbonBar_Tasks");
            ribbonBar_Tasks.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            ribbonBar_Tasks.Name = "ribbonBar_Tasks";
            ribbonBar_Tasks.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            ribbonBar_Tasks.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            ribbonBar_Tasks.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            ribbonBar_Tasks.TitleVisible = false;
            superTabControl_Main1.BackColor = System.Drawing.Color.White;
            superTabControl_Main1.CausesValidation = false;
            superTabControl_Main1.ControlBox.CloseBox.Name = "";
            superTabControl_Main1.ControlBox.MenuBox.Name = "";
            superTabControl_Main1.ControlBox.Name = "";
            superTabControl_Main1.ControlBox.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[2]
            {
                superTabControl_Main1.ControlBox.MenuBox,
                superTabControl_Main1.ControlBox.CloseBox
            });
            superTabControl_Main1.ControlBox.Visible = false;
            resources.ApplyResources(superTabControl_Main1, "superTabControl_Main1");
            superTabControl_Main1.ForeColor = System.Drawing.Color.Black;
            superTabControl_Main1.ItemPadding.Bottom = 4;
            superTabControl_Main1.ItemPadding.Left = 2;
            superTabControl_Main1.ItemPadding.Top = 4;
            superTabControl_Main1.Name = "superTabControl_Main1";
            superTabControl_Main1.ReorderTabsEnabled = true;
            superTabControl_Main1.SelectedTabIndex = -1;
            superTabControl_Main1.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[8]
            {
                Button_Close,
                Button_Payment,
                Button_Renwal,
                Button_Save,
                Button_Add,
                labelItem2,
                Button_ShowContract,
                Button_DelContract
            });
            superTabControl_Main1.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.WinMediaPlayer12;
            superTabControl_Main1.TextAlignment = DevComponents.DotNetBar.eItemAlignment.Center;
            Button_Close.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            Button_Close.Checked = true;
            Button_Close.FontBold = true;
            Button_Close.FontItalic = true;
            Button_Close.ForeColor = System.Drawing.Color.Black;
            Button_Close.Image = (System.Drawing.Image)resources.GetObject("Button_Close.Image");
            Button_Close.ImageFixedSize = new System.Drawing.Size(28, 28);
            Button_Close.ImagePaddingHorizontal = 15;
            Button_Close.ImagePaddingVertical = 11;
            Button_Close.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            Button_Close.Name = "Button_Close";
            Button_Close.Stretch = true;
            Button_Close.SubItemsExpandWidth = 14;
            Button_Close.Symbol = "\uf057";
            Button_Close.SymbolSize = 15f;
            resources.ApplyResources(Button_Close, "Button_Close");
            Button_Payment.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            Button_Payment.Enabled = false;
            Button_Payment.FontBold = true;
            Button_Payment.FontItalic = true;
            Button_Payment.ForeColor = System.Drawing.Color.Green;
            Button_Payment.Image = (System.Drawing.Image)resources.GetObject("Button_Payment.Image");
            Button_Payment.ImageFixedSize = new System.Drawing.Size(28, 28);
            Button_Payment.ImagePaddingHorizontal = 15;
            Button_Payment.ImagePaddingVertical = 11;
            Button_Payment.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            Button_Payment.Name = "Button_Payment";
            Button_Payment.Stretch = true;
            Button_Payment.SubItemsExpandWidth = 14;
            Button_Payment.Symbol = "\uf002";
            Button_Payment.SymbolSize = 15f;
            resources.ApplyResources(Button_Payment, "Button_Payment");
            Button_Payment.Click += new System.EventHandler(Button_Payment_Click);
            Button_Renwal.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            Button_Renwal.Enabled = false;
            Button_Renwal.FontBold = true;
            Button_Renwal.FontItalic = true;
            Button_Renwal.ForeColor = System.Drawing.Color.SteelBlue;
            Button_Renwal.Image = (System.Drawing.Image)resources.GetObject("Button_Renwal.Image");
            Button_Renwal.ImageFixedSize = new System.Drawing.Size(28, 28);
            Button_Renwal.ImagePaddingHorizontal = 15;
            Button_Renwal.ImagePaddingVertical = 11;
            Button_Renwal.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            Button_Renwal.Name = "Button_Renwal";
            Button_Renwal.Stretch = true;
            Button_Renwal.SubItemsExpandWidth = 14;
            Button_Renwal.Symbol = "\uf021";
            Button_Renwal.SymbolSize = 15f;
            resources.ApplyResources(Button_Renwal, "Button_Renwal");
            Button_Renwal.Click += new System.EventHandler(Button_Renwal_Click);
            Button_Save.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            Button_Save.FontBold = true;
            Button_Save.FontItalic = true;
            Button_Save.ForeColor = System.Drawing.Color.FromArgb(192, 64, 0);
            Button_Save.Image = (System.Drawing.Image)resources.GetObject("Button_Save.Image");
            Button_Save.ImageFixedSize = new System.Drawing.Size(28, 28);
            Button_Save.ImagePaddingHorizontal = 15;
            Button_Save.ImagePaddingVertical = 11;
            Button_Save.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            Button_Save.Name = "Button_Save";
            Button_Save.Stretch = true;
            Button_Save.SubItemsExpandWidth = 14;
            Button_Save.Symbol = "\uf0c7";
            Button_Save.SymbolSize = 15f;
            resources.ApplyResources(Button_Save, "Button_Save");
            Button_Add.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            Button_Add.FontBold = true;
            Button_Add.FontItalic = true;
            Button_Add.ForeColor = System.Drawing.Color.Blue;
            Button_Add.Image = (System.Drawing.Image)resources.GetObject("Button_Add.Image");
            Button_Add.ImageFixedSize = new System.Drawing.Size(28, 28);
            Button_Add.ImagePaddingHorizontal = 15;
            Button_Add.ImagePaddingVertical = 11;
            Button_Add.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            Button_Add.Name = "Button_Add";
            Button_Add.Stretch = true;
            Button_Add.SubItemsExpandWidth = 14;
            Button_Add.Symbol = "\uf055";
            Button_Add.SymbolSize = 15f;
            resources.ApplyResources(Button_Add, "Button_Add");
            Button_Add.Visible = false;
            labelItem2.Name = "labelItem2";
            labelItem2.Width = 180;
            Button_ShowContract.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            Button_ShowContract.Enabled = false;
            Button_ShowContract.FontBold = true;
            Button_ShowContract.FontItalic = true;
            Button_ShowContract.ForeColor = System.Drawing.Color.SteelBlue;
            Button_ShowContract.Image = (System.Drawing.Image)resources.GetObject("Button_ShowContract.Image");
            Button_ShowContract.ImageFixedSize = new System.Drawing.Size(28, 28);
            Button_ShowContract.ImagePaddingHorizontal = 15;
            Button_ShowContract.ImagePaddingVertical = 11;
            Button_ShowContract.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            Button_ShowContract.Name = "Button_ShowContract";
            Button_ShowContract.Stretch = true;
            Button_ShowContract.SubItemsExpandWidth = 14;
            Button_ShowContract.Symbol = "\uf016";
            Button_ShowContract.SymbolSize = 15f;
            resources.ApplyResources(Button_ShowContract, "Button_ShowContract");
            Button_ShowContract.Click += new System.EventHandler(Button_ShowContract_Click);
            Button_DelContract.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            Button_DelContract.Enabled = false;
            Button_DelContract.FontBold = true;
            Button_DelContract.FontItalic = true;
            Button_DelContract.ForeColor = System.Drawing.Color.FromArgb(192, 64, 0);
            Button_DelContract.Image = (System.Drawing.Image)resources.GetObject("Button_DelContract.Image");
            Button_DelContract.ImageFixedSize = new System.Drawing.Size(28, 28);
            Button_DelContract.ImagePaddingHorizontal = 15;
            Button_DelContract.ImagePaddingVertical = 11;
            Button_DelContract.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            Button_DelContract.Name = "Button_DelContract";
            Button_DelContract.Stretch = true;
            Button_DelContract.SubItemsExpandWidth = 14;
            Button_DelContract.Symbol = "\uf014";
            Button_DelContract.SymbolSize = 15f;
            resources.ApplyResources(Button_DelContract, "Button_DelContract");
            Button_DelContract.Click += new System.EventHandler(Button_DelContract_Click);
            superTabControl_Main2.BackColor = System.Drawing.Color.White;
            superTabControl_Main2.CausesValidation = false;
            superTabControl_Main2.ControlBox.CloseBox.Name = "";
            superTabControl_Main2.ControlBox.MenuBox.Name = "";
            superTabControl_Main2.ControlBox.Name = "";
            superTabControl_Main2.ControlBox.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[2]
            {
                superTabControl_Main2.ControlBox.MenuBox,
                superTabControl_Main2.ControlBox.CloseBox
            });
            superTabControl_Main2.ControlBox.Visible = false;
            resources.ApplyResources(superTabControl_Main2, "superTabControl_Main2");
            superTabControl_Main2.ForeColor = System.Drawing.Color.Black;
            superTabControl_Main2.ItemPadding.Bottom = 4;
            superTabControl_Main2.ItemPadding.Left = 4;
            superTabControl_Main2.ItemPadding.Right = 4;
            superTabControl_Main2.ItemPadding.Top = 4;
            superTabControl_Main2.Name = "superTabControl_Main2";
            superTabControl_Main2.ReorderTabsEnabled = true;
            superTabControl_Main2.SelectedTabIndex = -1;
            superTabControl_Main2.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[8]
            {
                labelItem1,
                Button_First,
                Button_Prev,
                TextBox_Index,
                Label_Count,
                lable_Records,
                Button_Next,
                Button_Last
            });
            superTabControl_Main2.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.WinMediaPlayer12;
            superTabControl_Main2.TextAlignment = DevComponents.DotNetBar.eItemAlignment.Center;
            labelItem1.Name = "labelItem1";
            labelItem1.Width = 2;
            Button_First.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            Button_First.FontBold = true;
            Button_First.FontItalic = true;
            Button_First.ForeColor = System.Drawing.Color.SteelBlue;
            Button_First.Image = (System.Drawing.Image)resources.GetObject("Button_First.Image");
            Button_First.ImageFixedSize = new System.Drawing.Size(28, 28);
            Button_First.ImagePaddingHorizontal = 15;
            Button_First.ImagePaddingVertical = 11;
            Button_First.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            Button_First.Name = "Button_First";
            Button_First.SplitButton = true;
            Button_First.Stretch = true;
            Button_First.SubItemsExpandWidth = 14;
            Button_First.Symbol = "\uf051";
            Button_First.SymbolSize = 15f;
            resources.ApplyResources(Button_First, "Button_First");
            Button_Prev.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            Button_Prev.FontBold = true;
            Button_Prev.FontItalic = true;
            Button_Prev.ForeColor = System.Drawing.Color.SteelBlue;
            Button_Prev.Image = (System.Drawing.Image)resources.GetObject("Button_Prev.Image");
            Button_Prev.ImageFixedSize = new System.Drawing.Size(28, 28);
            Button_Prev.ImagePaddingHorizontal = 15;
            Button_Prev.ImagePaddingVertical = 11;
            Button_Prev.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            Button_Prev.Name = "Button_Prev";
            Button_Prev.SplitButton = true;
            Button_Prev.Stretch = true;
            Button_Prev.SubItemsExpandWidth = 14;
            Button_Prev.Symbol = "\uf04e";
            Button_Prev.SymbolSize = 15f;
            resources.ApplyResources(Button_Prev, "Button_Prev");
            TextBox_Index.Name = "TextBox_Index";
            resources.ApplyResources(TextBox_Index, "TextBox_Index");
            TextBox_Index.TextBoxWidth = 50;
            TextBox_Index.Visible = false;
            TextBox_Index.WatermarkColor = System.Drawing.SystemColors.GrayText;
            Label_Count.Name = "Label_Count";
            Label_Count.Visible = false;
            Label_Count.Width = 40;
            lable_Records.BackColor = System.Drawing.Color.SteelBlue;
            lable_Records.ForeColor = System.Drawing.Color.White;
            lable_Records.Name = "lable_Records";
            resources.ApplyResources(lable_Records, "lable_Records");
            Button_Next.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            Button_Next.FontBold = true;
            Button_Next.FontItalic = true;
            Button_Next.ForeColor = System.Drawing.Color.SteelBlue;
            Button_Next.Image = (System.Drawing.Image)resources.GetObject("Button_Next.Image");
            Button_Next.ImageFixedSize = new System.Drawing.Size(28, 28);
            Button_Next.ImagePaddingHorizontal = 15;
            Button_Next.ImagePaddingVertical = 11;
            Button_Next.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            Button_Next.Name = "Button_Next";
            Button_Next.SplitButton = true;
            Button_Next.Stretch = true;
            Button_Next.SubItemsExpandWidth = 14;
            Button_Next.Symbol = "\uf04a";
            Button_Next.SymbolSize = 15f;
            resources.ApplyResources(Button_Next, "Button_Next");
            Button_Last.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            Button_Last.FontBold = true;
            Button_Last.FontItalic = true;
            Button_Last.ForeColor = System.Drawing.Color.SteelBlue;
            Button_Last.Image = (System.Drawing.Image)resources.GetObject("Button_Last.Image");
            Button_Last.ImageFixedSize = new System.Drawing.Size(28, 28);
            Button_Last.ImagePaddingHorizontal = 15;
            Button_Last.ImagePaddingVertical = 11;
            Button_Last.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            Button_Last.Name = "Button_Last";
            Button_Last.SplitButton = true;
            Button_Last.Stretch = true;
            Button_Last.SubItemsExpandWidth = 14;
            Button_Last.Symbol = "\uf048";
            Button_Last.SymbolSize = 15f;
            resources.ApplyResources(Button_Last, "Button_Last");
            expandableSplitter1.BackColor = System.Drawing.Color.FromArgb(227, 239, 255);
            expandableSplitter1.BackColor2 = System.Drawing.Color.FromArgb(101, 147, 207);
            expandableSplitter1.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.None;
            expandableSplitter1.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.None;
            resources.ApplyResources(expandableSplitter1, "expandableSplitter1");
            expandableSplitter1.Expandable = false;
            expandableSplitter1.ExpandableControl = panelEx2;
            expandableSplitter1.ExpandFillColor = System.Drawing.Color.FromArgb(0, 45, 150);
            expandableSplitter1.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            expandableSplitter1.ExpandLineColor = System.Drawing.SystemColors.ControlText;
            expandableSplitter1.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            expandableSplitter1.ForeColor = System.Drawing.Color.Black;
            expandableSplitter1.GripDarkColor = System.Drawing.SystemColors.ControlText;
            expandableSplitter1.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            expandableSplitter1.GripLightColor = System.Drawing.Color.FromArgb(223, 237, 254);
            expandableSplitter1.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            expandableSplitter1.HotBackColor = System.Drawing.Color.FromArgb(254, 142, 75);
            expandableSplitter1.HotBackColor2 = System.Drawing.Color.FromArgb(255, 207, 139);
            expandableSplitter1.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2;
            expandableSplitter1.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground;
            expandableSplitter1.HotExpandFillColor = System.Drawing.Color.FromArgb(0, 45, 150);
            expandableSplitter1.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            expandableSplitter1.HotExpandLineColor = System.Drawing.SystemColors.ControlText;
            expandableSplitter1.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            expandableSplitter1.HotGripDarkColor = System.Drawing.Color.FromArgb(0, 45, 150);
            expandableSplitter1.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            expandableSplitter1.HotGripLightColor = System.Drawing.Color.FromArgb(223, 237, 254);
            expandableSplitter1.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            expandableSplitter1.Name = "expandableSplitter1";
            expandableSplitter1.TabStop = false;
            panel1.Controls.Add(panelEx3);
            panel1.Controls.Add(expandableSplitter1);
            panel1.Controls.Add(panelEx2);
            resources.ApplyResources(panel1, "panel1");
            panel1.Name = "panel1";
            resources.ApplyResources(this, "$this");
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            base.Controls.Add(panel1);
            base.Controls.Add(Rep_RecCount);
            base.Controls.Add(barTopDockSite);
            base.Controls.Add(barBottomDockSite);
            base.Controls.Add(barLeftDockSite);
            base.Controls.Add(barRightDockSite);
            base.Controls.Add(dockSite1);
            base.Controls.Add(dockSite2);
            base.Controls.Add(dockSite3);
            base.Controls.Add(dockSite4);
            base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            base.KeyPreview = true;
            base.MaximizeBox = false;
            base.Name = "FrmTenantContract";
            base.Load += new System.EventHandler(FrmTenantContract_Load);
            base.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Frm_KeyPress);
            base.KeyDown += new System.Windows.Forms.KeyEventHandler(Frm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)Rep_RecCount).EndInit();
            ribbonBar1.ResumeLayout(false);
            ribbonBar1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)txtRentOfYear).EndInit();
            contextMenuStrip2.ResumeLayout(false);
            panelEx3.ResumeLayout(false);
            ribbonBar_DGV.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)superTabControl_DGV).EndInit();
            panelEx2.ResumeLayout(false);
            ribbonBar_Tasks.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)superTabControl_Main1).EndInit();
            ((System.ComponentModel.ISupportInitialize)superTabControl_Main2).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
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
                SetReadOnly = true;
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
        public void RefreshPKeys()
        {
            PKeys.Clear();
            var qkeys = from item in db.T_TenantContracts
                        orderby item.ContractNo
                        select new
                        {
                            Code = item.ContractNo + ""
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
        public FrmTenantContract()
        {
            InitializeComponent();
            txtAinNo.Click += Button_Edit_Click;
            txtContractEnd.Click += Button_Edit_Click;
            txtContractStart.Click += Button_Edit_Click;
            txtEqarNo.Click += Button_Edit_Click;
            txtRentOfYear.Click += Button_Edit_Click;
            txtTenantName.Click += Button_Edit_Click;
            txtTenantNo.Click += Button_Edit_Click;
            DGV_Main.PrimaryGrid.CheckBoxes = false;
            DGV_Main.PrimaryGrid.ShowCheckBox = false;
            DGV_Main.PrimaryGrid.ShowTreeButton = false;
            DGV_Main.PrimaryGrid.ShowTreeButtons = false;
            DGV_Main.PrimaryGrid.ShowTreeLines = false;
            DGV_Main.PrimaryGrid.RowHeaderWidth = 25;
            DGV_Main.PrimaryGrid.VirtualMode = true;
            DGV_Main.MouseDown += DGV_Main_MouseDown;
            expandableSplitter1.Click += expandableSplitter1_Click;
            DGV_Main.CellDoubleClick += DGV_Main_CellDoubleClick;
            DGV_Main.CellClick += DGV_Main_CellClick;
            ToolStripMenuItem_Det.Click += ToolStripMenuItem_Det_Click;
            Button_ExportTable2.Click += Button_ExportTable2_Click;
            DGV_Main.CellDoubleClick += DGV_Main_CellDoubleClick;
            textBox_search.InputTextChanged += TextBox_Search_InputTextChanged;
            textBox_search.ButtonCustomClick += TextBox_Search_ButtonCustomClick;
            TextBox_Index.InputTextChanged += TextBox_Index_InputTextChanged;
            DGV_Main.DataBindingComplete += DGV_Main_DataBindingComplete;
            Button_Close.Click += Button_Close_Click;
            Button_First.Click += Button_First_Click;
            Button_Prev.Click += Button_Prev_Click;
            Button_Next.Click += Button_Next_Click;
            Button_Last.Click += Button_Last_Click;
            Button_Add.Click += Button_Add_Click;
            Button_Save.Click += Button_Save_Click;
            TextBox_Index.InputTextChanged += TextBox_Index_InputTextChanged;
            Button_PrintTable.Click += Button_Print_Click;
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
            List<T_TenantContract> list = db.FillTenantContractData_2(textBox_search.TextBox.Text).ToList();
            if (DGV_Main.PrimaryGrid.Columns.Count == 0)
            {
                foreach (KeyValuePair<string, ColumnDictinary> item in columns_Names_visible)
                {
                    DGV_Main.PrimaryGrid.Columns.Add(new GridColumn(item.Key));
                }
            }
            FillHDGV(list);
        }
        public void FillHDGV(IEnumerable<T_TenantContract> new_data_enum)
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
            DGV_Main.PrimaryGrid.DataMember = "T_TenantContract";
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
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmTenantContract));
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
                Button_Renwal.Text = "تجديد العقد";
                Button_Save.Text = "حفظ";
                Button_Payment.Text = "الدفعات";
                Button_ShowContract.Text = "عرض العقد";
                Button_DelContract.Text = "حذف العقد";
                Button_First.Tooltip = "السجل الاول";
                Button_Last.Tooltip = "السجل الاخير";
                Button_Next.Tooltip = "السجل التالي";
                Button_Prev.Tooltip = "السجل السابق";
                Button_PrintTable.Tooltip = "F5";
                Button_ExportTable2.Text = "تصدير";
                Button_ExportTable2.Tooltip = "F10";
                DGV_Main.PrimaryGrid.GroupByRow.Text = "جميع السجلات";
                Text = "كرت العقــــود";
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
                Button_Renwal.Text = "contract renewal";
                Button_Payment.Text = "Payments";
                Button_ShowContract.Text = "Contract";
                Button_DelContract.Text = "Delete Contract";
                Button_First.Tooltip = "First Record";
                Button_Last.Tooltip = "Last Record";
                Button_Next.Tooltip = "Next Record";
                Button_Prev.Tooltip = "Previous Record";
                Button_PrintTable.Tooltip = "F5";
                Button_ExportTable2.Text = "Export";
                Button_ExportTable2.Tooltip = "F10";
                DGV_Main.PrimaryGrid.GroupByRow.Text = "All Records";
                Text = "Contracts Card";
            }
        }
        private void FrmTenantContract_Load(object sender, EventArgs e)
        {
            try
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmTenantContract));
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
                    columns_Names_visible.Add("ContractNo", new ColumnDictinary("الرقم ", " No", ifDefault: true, ""));
                }
                else
                {
                    Clear();
                    textBox_ID.Text = "";
                    TextBox_Index.TextBox.Text = "";
                }
                RefreshPKeys();
                RibunButtons();
                ViewDetails_Click(sender, e);
                if (ProcessTyp == 0)
                {
                    Button_Add_Click(sender, e);
                    txtTenantNo.Text = TenantNo_;
                    txtTenantNo.Tag = TenantID_;
                    txtTenantName.Text = TenantNm_;
                }
                else
                {
                    textBox_ID.Text = _ContractNo.ToString();
                    SetReadOnly = true;
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Load:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void _ownerDraw(object sender, OwnerDrawCellEventArgs e)
        {
            if (e.Col == 0 && e.Row > 0)
            {
                e.Text = e.Row.ToString();
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
                T_TenantContract newData = db.StockTenantContractData(no, int.Parse(TenantID_));
                if (newData == null || newData.ContractNo == 0)
                {
                    Clear();
                    TextBox_Index.InputTextChanged -= TextBox_Index_InputTextChanged;
                    TextBox_Index.TextBox.Text = string.Concat(PKeys.Count + 1);
                    TextBox_Index.InputTextChanged += TextBox_Index_InputTextChanged;
                }
                else
                {
                    DataThis = newData;
                    int indexA = PKeys.IndexOf(string.Concat(newData.ContractNo));
                    indexA++;
                    TextBox_Index.InputTextChanged -= TextBox_Index_InputTextChanged;
                    TextBox_Index.TextBox.Text = string.Concat(indexA);
                    TextBox_Index.InputTextChanged += TextBox_Index_InputTextChanged;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
            data_this = new T_TenantContract();
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
                else if (controls[i].GetType() == typeof(System.Windows.Forms.CheckBox))
                {
                    (controls[i] as System.Windows.Forms.CheckBox).Checked = false;
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
                    else if (controls[i].GetType() == typeof(System.Windows.Forms.CheckBox))
                    {
                        (controls[i] as System.Windows.Forms.CheckBox).Checked = false;
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
            textBox_ID.Focus();
            SetReadOnly = false;
        }
        public void SetData(T_TenantContract value)
        {
            try
            {
                State = FormState.Saved;
                Button_Save.Enabled = false;
                textBox_ID.Tag = value.ContractID.ToString();
                try
                {
                    if (!string.IsNullOrEmpty(value.Ain_ID.ToString()))
                    {
                        txtAinNo.Text = value.T_AinsData.AinNo;
                        txtAinNo.Tag = value.T_AinsData.AinID;
                        txtAinTyp.Text = ((LangArEn == 0) ? data_this.T_AinsData.T_AinTyp.NameA : data_this.T_AinsData.T_AinTyp.NameE);
                    }
                }
                catch
                {
                }
                try
                {
                    if (VarGeneral.CheckDate(value.ContractEnd))
                    {
                        txtContractEnd.Text = value.ContractEnd;
                    }
                    else
                    {
                        txtContractEnd.Text = "";
                    }
                }
                catch
                {
                    txtContractEnd.Text = "";
                }
                try
                {
                    if (VarGeneral.CheckDate(value.ContractStart))
                    {
                        txtContractStart.Text = value.ContractStart;
                    }
                    else
                    {
                        txtContractStart.Text = "";
                    }
                }
                catch
                {
                    txtContractStart.Text = "";
                }
                txtEqarName.Text = ((LangArEn == 0) ? value.T_EqarsData.NameA : value.T_EqarsData.NameE);
                txtEqarNo.Text = value.T_EqarsData.EqarNo.ToString();
                txtEqarNo.Tag = value.T_EqarsData.EqarID;
                txtRentOfYear.Value = value.RentOfYear.Value;
                txtTenantName.Text = ((LangArEn == 0) ? value.T_Tenant.NameA : value.T_Tenant.NameE);
                txtTenantNo.Text = value.T_Tenant.tenantNo.ToString();
                txtTenantNo.Tag = value.T_Tenant.tenantID;
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
        private T_TenantContract GetData()
        {
            textBox_ID.Focus();
            data_this.ContractNo = int.Parse(textBox_ID.Text);
            if (!string.IsNullOrEmpty(txtAinNo.Text))
            {
                data_this.Ain_ID = int.Parse(txtAinNo.Tag.ToString());
            }
            else
            {
                data_this.Ain_ID = null;
            }
            try
            {
                if (VarGeneral.CheckDate(txtContractEnd.Text))
                {
                    data_this.ContractEnd = txtContractEnd.Text;
                }
                else
                {
                    data_this.ContractEnd = "";
                }
            }
            catch
            {
                data_this.ContractEnd = "";
            }
            try
            {
                if (VarGeneral.CheckDate(txtContractStart.Text))
                {
                    data_this.ContractStart = txtContractStart.Text;
                }
                else
                {
                    data_this.ContractStart = "";
                }
            }
            catch
            {
                data_this.ContractStart = "";
            }
            data_this.Eqar_ID = int.Parse(txtEqarNo.Tag.ToString());
            data_this.RentOfYear = txtRentOfYear.Value;
            data_this.tenant_ID = int.Parse(TenantID_);
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
            if (State == FormState.Edit && MessageBox.Show((LangArEn == 0) ? "تم تعديل السجل الحالي دون حفظ التغييرات .. هل تريد المتابعة؟" : "Not saved the changes, do you really want to continue?", VarGeneral.ProdectNam, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
            {
                return;
            }
            Clear();
            int tt = 1;
            try
            {
                List<T_TenantContract> Quary = (from er in db.T_TenantContracts
                                                where er.tenant_ID == int.Parse(TenantID_)
                                                orderby er.ContractNo
                                                select er).ToList();
                if (Quary.Count() > 0)
                {
                    tt = Quary.Max().ContractNo + 1;
                }
            }
            catch
            {
                tt = 1;
            }
            textBox_ID.Text = tt.ToString();
            State = FormState.New;
            try
            {
                txtContractStart.Text = ((VarGeneral.Settings_Sys.Calendr.Value == 0) ? n.FormatGreg(VarGeneral.Gdate, "yyyy/MM/dd") : n.FormatHijri(VarGeneral.Hdate, "yyyy/MM/dd"));
                txtContractEnd.Focus();
            }
            catch
            {
            }
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
            if (textBox_ID.Text == "0" || textBox_ID.Text == "")
            {
                MessageBox.Show((LangArEn == 0) ? "لا يمكن الحفظ بدون رقم العقد" : "Can not save without the Contract No", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                textBox_ID.Focus();
                return false;
            }
            if (txtEqarNo.Text == "" || string.IsNullOrEmpty(txtEqarNo.Tag.ToString()))
            {
                MessageBox.Show((LangArEn == 0) ? "لا يمكن الحفظ بدون رقم العقار" : "Can not save without the Number", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                txtEqarNo.Focus();
                return false;
            }
            if (!VarGeneral.CheckDate(txtContractStart.Text))
            {
                MessageBox.Show((LangArEn == 0) ? "لايمكن ان يكون التاريخ فارغا\u0651" : "Can not be Date is empty", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                txtContractStart.Focus();
                return false;
            }
            if (!VarGeneral.CheckDate(txtContractEnd.Text))
            {
                MessageBox.Show((LangArEn == 0) ? "لايمكن ان يكون التاريخ فارغا\u0651" : "Can not be Date is empty", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                txtContractEnd.Focus();
                return false;
            }
            if (txtTenantNo.Text == "" || string.IsNullOrEmpty(txtTenantNo.Tag.ToString()))
            {
                MessageBox.Show((LangArEn == 0) ? "لايمكن ان يكون رقم المستأجر فارغا\u0651" : "Can not be Tenant No is empty", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                txtEqarNo.Focus();
                return false;
            }
            if (txtAinNo.Text == "")
            {
                T_EqarsData q = db.StockEqarData(int.Parse(txtEqarNo.Tag.ToString()));
                for (int i = 0; i < q.T_AinsDatas.Count; i++)
                {
                    try
                    {
                        if (q.T_AinsDatas[i].AinStatus.Value > 0)
                        {
                            MessageBox.Show((LangArEn == 0) ? "لا يمكنك استخدام هذا العقار بالكامل لانه يحتوي على عقد او اكثر لاحد عيونه" : "You cannot use this property entirely", VarGeneral.ProdectNam);
                            return false;
                        }
                    }
                    catch
                    {
                        MessageBox.Show((LangArEn == 0) ? "لا يمكنك استخدام هذا العقار بالكامل لانه يحتوي على عقد او اكثر لاحد عيونه" : "You cannot use this property entirely", VarGeneral.ProdectNam);
                        return false;
                    }
                }
            }
            return true;
        }
        private void Eqar_Ain_StatusControl(int ProcessTyp, int StatusValue, T_TenantContract vData)
        {
            if (ProcessTyp == 0)
            {
                db.ExecuteCommand("  UPDATE T_EqarsData SET  EqarStatus = " + StatusValue + " Where EqarID = " + vData.Eqar_ID);
            }
            else
            {
                db.ExecuteCommand("  UPDATE T_AinsData SET  AinStatus = " + StatusValue + " Where AinID = " + vData.Ain_ID);
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
                if (State == FormState.New)
                {
                    GetData();
                    try
                    {
                        data_this.RentOfYearPayment = txtRentOfYear.Value;
                        data_this.PayMethod = 0;
                        db.T_TenantContracts.InsertOnSubmit(data_this);
                        db.SubmitChanges();
                    }
                    catch (SqlException ex)
                    {
                        int max = 1;
                        try
                        {
                            List<T_TenantContract> Quary = (from er in db.T_TenantContracts
                                                            where er.tenant_ID == int.Parse(TenantID_)
                                                            orderby er.ContractNo
                                                            select er).ToList();
                            if (Quary.Count() > 0)
                            {
                                max = Quary.Max().ContractNo + 1;
                            }
                        }
                        catch
                        {
                            max = 1;
                        }
                        if (ex.Number != 2627)
                        {
                            return;
                        }
                        MessageBox.Show("الرقم مستخدم من قبل.\n سيتم الحفظ برقم جديد [" + max + "]", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Question);
                        textBox_ID.Text = string.Concat(max);
                        data_this.ContractNo = max;
                        Button_Save_Click(sender, e);
                    }
                    catch (Exception)
                    {
                        return;
                    }
                }
                else if (State == FormState.Edit)
                {
                    oldData = new T_TenantContract();
                    oldData = data_this;
                    if (data_this.Ain_ID.HasValue)
                    {
                        Eqar_Ain_StatusControl(1, 0, data_this);
                    }
                    else
                    {
                        Eqar_Ain_StatusControl(0, 0, data_this);
                    }
                    GetData();
                    try
                    {
                        db.Log = VarGeneral.DebugLog;
                        db.SubmitChanges(ConflictMode.ContinueOnConflict);
                    }
                    catch (Exception)
                    {
                        if (!string.IsNullOrEmpty(oldData.Ain_ID.Value.ToString()))
                        {
                            Eqar_Ain_StatusControl(1, 1, oldData);
                        }
                        else
                        {
                            Eqar_Ain_StatusControl(0, 1, oldData);
                        }
                        return;
                    }
                }
                if (data_this.Ain_ID.HasValue)
                {
                    Eqar_Ain_StatusControl(1, 1, data_this);
                }
                else
                {
                    Eqar_Ain_StatusControl(0, 1, data_this);
                }
                MessageBox.Show((LangArEn == 0) ? "لقد تم اتمام العملية بنجاح .." : "This Opration Is Done", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                State = FormState.Saved;
                RefreshPKeys();
                TextBox_Index.TextBox.Text = string.Concat(PKeys.IndexOf(string.Concat(data_this.ContractNo)) + 1);
                dbInstance = null;
                textBox_ID_TextChanged(sender, e);
                SetReadOnly = true;
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Save:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void DGV_Main_DataBindingComplete(object sender, GridDataBindingCompleteEventArgs e)
        {
            GridPanel panel = e.GridPanel;
            string dataMember = panel.DataMember;
            if (dataMember != null && dataMember == "T_TenantContract")
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
            panel.Columns["ContractNo"].Width = 120;
            panel.Columns["ContractNo"].Visible = columns_Names_visible["ContractNo"].IfDefault;
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
                ExportExcel.ExportToExcel(DGV_Main, "تقرير العقــود");
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
                controls.Add(textBox_ID);
                controls.Add(txtAinNo);
                controls.Add(txtAinTyp);
                controls.Add(txtContractEnd);
                controls.Add(txtContractStart);
                controls.Add(txtEqarName);
                controls.Add(txtEqarNo);
                controls.Add(txtRentOfYear);
                controls.Add(txtTenantName);
                controls.Add(txtTenantNo);
            }
            catch (SqlException)
            {
            }
        }
        private void txtArbDes_Enter(object sender, EventArgs e)
        {
            Framework.Keyboard.Language.Switch("Arabic");
        }
        private void txtEngDes_Enter(object sender, EventArgs e)
        {
            Framework.Keyboard.Language.Switch("English");
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
                _RepShow.Tables = " T_TenantContract  ";
                string Fields = "";
                Fields = " T_TenantContract.EqarID , T_TenantContract.ContractNo as No , T_TenantContract.NameA as NmA, T_TenantContract.NameE as NmE ,(select T_SYSSETTING.LogImg from T_SYSSETTING) as LogImg";
                _RepShow.Rule = " ";
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
                        FrmReportsViewer frm = new FrmReportsViewer();
                        frm.Tag = LangArEn;
                        frm.Repvalue = "RepGeneral";
                        VarGeneral.vTitle = Text;
                        frm.TopMost = true;
                        frm.ShowDialog();
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
        private void textBox_ID_Click(object sender, EventArgs e)
        {
            textBox_ID.SelectAll();
        }
        private void button_SrchOwnerADD_Click(object sender, EventArgs e)
        {
            FrmEqars frm = new FrmEqars();
            frm.Tag = LangArEn;
            frm.TopMost = true;
            frm.ShowDialog();
        }
        private void button_SrchEqarNo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_ID.Text))
            {
                return;
            }
            Button_Edit_Click(sender, e);
            columns_Names_visible2.Clear();
            columns_Names_visible2.Add("EqarNo", new ColumnDictinary("الرقم ", " No", ifDefault: true, ""));
            columns_Names_visible2.Add("NameA", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, ""));
            columns_Names_visible2.Add("NameE", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, ""));
            columns_Names_visible2.Add("ContractValue", new ColumnDictinary("قيمة العقار", "Property value", ifDefault: true, ""));
            columns_Names_visible2.Add("ContractRentValue", new ColumnDictinary("إيجار العقار", "Rent the property", ifDefault: false, ""));
            columns_Names_visible2.Add("FloorsCount", new ColumnDictinary("عدد الطوابق", "Floors Count", ifDefault: false, ""));
            columns_Names_visible2.Add("EyesCount", new ColumnDictinary("عدد العيون", "Eyes Count", ifDefault: false, ""));
            columns_Names_visible2.Add("Space", new ColumnDictinary("مساحة العقار", "Space", ifDefault: false, ""));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible2;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, ""));
            }
            VarGeneral.SFrmTyp = "T_EqarsDataSale";
            VarGeneral.EqarSaleWhere = "";
            try
            {
                if (State == FormState.Edit)
                {
                    if (!string.IsNullOrEmpty(data_this.Eqar_ID.ToString()))
                    {
                        VarGeneral.EqarSaleWhere = " or EqarID = " + data_this.Eqar_ID;
                    }
                    else
                    {
                        VarGeneral.EqarSaleWhere = "";
                    }
                }
            }
            catch
            {
                VarGeneral.EqarSaleWhere = "";
            }
            frm.TopMost = true;
            frm.ShowDialog();
            try
            {
                if (frm.SerachNo != "")
                {
                    T_EqarsData _Eqar = db.EqarsDataEmp(int.Parse(frm.Serach_No));
                    txtEqarNo.Text = frm.Serach_No;
                    txtEqarNo.Tag = _Eqar.EqarID;
                    if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                    {
                        txtEqarName.Text = _Eqar.NameA;
                    }
                    else
                    {
                        txtEqarName.Text = _Eqar.NameE;
                    }
                }
                else
                {
                    txtEqarNo.Text = "";
                    txtEqarName.Text = "";
                    txtEqarNo.Tag = "";
                }
            }
            catch
            {
                txtEqarNo.Text = "";
                txtEqarName.Text = "";
                txtEqarNo.Tag = "";
            }
        }
        private void txtContractStart_Click(object sender, EventArgs e)
        {
            txtContractStart.SelectAll();
        }
        private void txtContractStart_Leave(object sender, EventArgs e)
        {
            try
            {
                if (VarGeneral.CheckDate(txtContractStart.Text))
                {
                    txtContractStart.Text = Convert.ToDateTime(txtContractStart.Text).ToString("yyyy/MM/dd");
                }
                else
                {
                    txtContractStart.Text = "";
                }
            }
            catch
            {
                txtContractStart.Text = "";
            }
        }
        private void txtContractEnd_Leave(object sender, EventArgs e)
        {
            try
            {
                if (VarGeneral.CheckDate(txtContractEnd.Text))
                {
                    txtContractEnd.Text = Convert.ToDateTime(txtContractEnd.Text).ToString("yyyy/MM/dd");
                }
                else
                {
                    txtContractEnd.Text = "";
                }
            }
            catch
            {
                txtContractEnd.Text = "";
            }
        }
        private void txtContractEnd_Click(object sender, EventArgs e)
        {
            txtContractEnd.SelectAll();
        }
        private void button_SrchAinNo_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(textBox_ID.Text) || string.IsNullOrEmpty(txtEqarNo.Text) || string.IsNullOrEmpty(txtEqarNo.Tag.ToString()))
                {
                    return;
                }
                Button_Edit_Click(sender, e);
                columns_Names_visible2.Clear();
                columns_Names_visible2.Add("AinNo", new ColumnDictinary("رقم العين", "Eye No", ifDefault: true, ""));
                columns_Names_visible2.Add("EqarNo", new ColumnDictinary("رقم العقار", "Real Estate No", ifDefault: true, ""));
                columns_Names_visible2.Add("NameA", new ColumnDictinary("اسم العقار -عربي", "Real Estate Name A", ifDefault: true, ""));
                columns_Names_visible2.Add("NameE", new ColumnDictinary("اسم العقار -انجليزي", "Real Estate Name E", ifDefault: false, ""));
                FrmSearch frm = new FrmSearch();
                frm.Tag = LangArEn;
                ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible2;
                foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
                {
                    frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, ""));
                }
                VarGeneral.SFrmTyp = "T_AinsDataSale";
                VarGeneral.EqarSaleWhere = "";
                try
                {
                    if (State == FormState.Edit)
                    {
                        if (!string.IsNullOrEmpty(data_this.Ain_ID.ToString()))
                        {
                            VarGeneral.EqarSaleWhere = " or T_AinsData.AinID = " + data_this.Ain_ID + ") ";
                        }
                        else
                        {
                            VarGeneral.EqarSaleWhere = "";
                        }
                    }
                }
                catch
                {
                    VarGeneral.EqarSaleWhere = "";
                }
                if (string.IsNullOrEmpty(VarGeneral.EqarSaleWhere))
                {
                    VarGeneral.EqarSaleWhere = " )";
                }
                VarGeneral.EqarSaleWhere = VarGeneral.EqarSaleWhere + " and T_AinsData.EqarID = " + txtEqarNo.Tag.ToString();
                frm.TopMost = true;
                frm.ShowDialog();
                if (frm.SerachNo != "")
                {
                    T_AinsData _Ain = db.AinsDataDataNo(frm.Serach_No, int.Parse(txtEqarNo.Tag.ToString()));
                    txtAinNo.Text = frm.Serach_No;
                    txtAinNo.Tag = _Ain.AinID;
                    txtAinTyp.Text = ((LangArEn == 0) ? _Ain.T_AinTyp.NameA : _Ain.T_AinTyp.NameE);
                }
                else
                {
                    txtAinNo.Text = "";
                    txtAinNo.Tag = "";
                    txtAinTyp.Text = "";
                }
            }
            catch
            {
                txtAinNo.Text = "";
                txtAinNo.Tag = "";
                txtAinTyp.Text = "";
            }
        }
        private void Button_Renwal_Click(object sender, EventArgs e)
        {
            if (VarGeneral.CheckDate(txtContractEnd.Text))
            {
                txtContractStart.Text = txtContractEnd.Text;
                txtContractEnd.Text = "";
                txtContractEnd.Focus();
                Button_Edit_Click(sender, e);
            }
        }
        private void Button_Payment_Click(object sender, EventArgs e)
        {
            if (State == FormState.Saved)
            {
                FrmTenantPayment frm = new FrmTenantPayment();
                frm.Tag = LangArEn;
                frm.data_this = data_this;
                frm.TopMost = true;
                frm.ShowDialog();
                dbInstance = null;
                textBox_ID_TextChanged(sender, e);
            }
        }
        private void Button_ShowContract_Click(object sender, EventArgs e)
        {
            if (State != 0)
            {
                return;
            }
            if (VarGeneral.vDemo && VarGeneral.UserID != 1)
            {
                MessageBox.Show((LangArEn == 0) ? "يرجى تفعيل المنتج للاستفادة من جميع مميزات النظام \n  لا تستطيع استخدام هذه الميزة لان النسخة الحالية تجريبية..  " : "Please activate the product to take advantage of all system features \n You can not use this feature because the current version is experimental ..", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.DefaultDesktopOnly);
                return;
            }
            IsNew = false;
            string vPth = System.Windows.Forms.Application.StartupPath + "\\ContractRent\\Contract" + textBox_ID.Text + ".doc";
            if (!File.Exists(vPth))
            {
                string DefPath = System.Windows.Forms.Application.StartupPath + "\\Contract.doc";
                File.Copy(DefPath, vPth, overwrite: true);
                IsNew = true;
            }
            object path_YourDocsName = vPth;
            object o = Missing.Value;
            object oFalse = false;
            object oTrue = true;
            _Application app = null;
            Documents docs = null;
            Document doc = null;
            app = new ApplicationClass();
            app.Visible = false;
            app.DisplayAlerts = WdAlertLevel.wdAlertsNone;
            docs = app.Documents;
            doc = docs.Open(ref path_YourDocsName, ref o, ref o, ref o, ref o, ref o, ref o, ref o, ref o, ref o, ref o, ref o, ref o, ref o, ref o, ref o);
            doc.Activate();
            if (IsNew)
            {
                foreach (Range range in doc.StoryRanges)
                {
                    Find find1 = range.Find;
                    object findText1 = "<CRentNo>";
                    object replacText1 = textBox_ID.Text;
                    object replace1 = WdReplace.wdReplaceAll;
                    object findWrap1 = WdFindWrap.wdFindContinue;
                    find1.Execute(ref findText1, ref o, ref o, ref o, ref oFalse, ref o, ref o, ref findWrap1, ref o, ref replacText1, ref replace1, ref o, ref o, ref o, ref o);
                    Marshal.FinalReleaseComObject(find1);
                    try
                    {
                        find1 = range.Find;
                        findText1 = "<HDat>";
                        replacText1 = VarGeneral.Hdate;
                        replace1 = WdReplace.wdReplaceAll;
                        findWrap1 = WdFindWrap.wdFindContinue;
                        find1.Execute(ref findText1, ref o, ref o, ref o, ref oFalse, ref o, ref o, ref findWrap1, ref o, ref replacText1, ref replace1, ref o, ref o, ref o, ref o);
                        Marshal.FinalReleaseComObject(find1);
                    }
                    catch
                    {
                    }
                    try
                    {
                        find1 = range.Find;
                        findText1 = "<GDat>";
                        replacText1 = VarGeneral.Gdate;
                        replace1 = WdReplace.wdReplaceAll;
                        findWrap1 = WdFindWrap.wdFindContinue;
                        find1.Execute(ref findText1, ref o, ref o, ref o, ref oFalse, ref o, ref o, ref findWrap1, ref o, ref replacText1, ref replace1, ref o, ref o, ref o, ref o);
                        Marshal.FinalReleaseComObject(find1);
                    }
                    catch
                    {
                    }
                    try
                    {
                        find1 = range.Find;
                        findText1 = "<OwnerNam>";
                        replacText1 = ((LangArEn == 0) ? data_this.T_EqarsData.T_Owner.NameA : data_this.T_EqarsData.T_Owner.NameE);
                        replace1 = WdReplace.wdReplaceAll;
                        findWrap1 = WdFindWrap.wdFindContinue;
                        find1.Execute(ref findText1, ref o, ref o, ref o, ref oFalse, ref o, ref o, ref findWrap1, ref o, ref replacText1, ref replace1, ref o, ref o, ref o, ref o);
                        Marshal.FinalReleaseComObject(find1);
                    }
                    catch
                    {
                    }
                    try
                    {
                        find1 = range.Find;
                        findText1 = "<RentNam>";
                        replacText1 = ((LangArEn == 0) ? data_this.T_Tenant.NameA : data_this.T_Tenant.NameE);
                        replace1 = WdReplace.wdReplaceAll;
                        findWrap1 = WdFindWrap.wdFindContinue;
                        find1.Execute(ref findText1, ref o, ref o, ref o, ref oFalse, ref o, ref o, ref findWrap1, ref o, ref replacText1, ref replace1, ref o, ref o, ref o, ref o);
                        Marshal.FinalReleaseComObject(find1);
                    }
                    catch
                    {
                    }
                    try
                    {
                        find1 = range.Find;
                        findText1 = "<Nat>";
                        replacText1 = ((LangArEn == 0) ? data_this.T_Tenant.T_Nationality.NameA : data_this.T_Tenant.T_Nationality.NameE);
                        replace1 = WdReplace.wdReplaceAll;
                        findWrap1 = WdFindWrap.wdFindContinue;
                        find1.Execute(ref findText1, ref o, ref o, ref o, ref oFalse, ref o, ref o, ref findWrap1, ref o, ref replacText1, ref replace1, ref o, ref o, ref o, ref o);
                        Marshal.FinalReleaseComObject(find1);
                    }
                    catch
                    {
                    }
                    try
                    {
                        find1 = range.Find;
                        findText1 = "<IdNo>";
                        replacText1 = data_this.T_Tenant.IDNo;
                        replace1 = WdReplace.wdReplaceAll;
                        findWrap1 = WdFindWrap.wdFindContinue;
                        find1.Execute(ref findText1, ref o, ref o, ref o, ref oFalse, ref o, ref o, ref findWrap1, ref o, ref replacText1, ref replace1, ref o, ref o, ref o, ref o);
                        Marshal.FinalReleaseComObject(find1);
                    }
                    catch
                    {
                    }
                    try
                    {
                        find1 = range.Find;
                        findText1 = "<IdNoSorc>";
                        replacText1 = data_this.T_Tenant.IDSource;
                        replace1 = WdReplace.wdReplaceAll;
                        findWrap1 = WdFindWrap.wdFindContinue;
                        find1.Execute(ref findText1, ref o, ref o, ref o, ref oFalse, ref o, ref o, ref findWrap1, ref o, ref replacText1, ref replace1, ref o, ref o, ref o, ref o);
                        Marshal.FinalReleaseComObject(find1);
                    }
                    catch
                    {
                    }
                    try
                    {
                        find1 = range.Find;
                        findText1 = "<IdNoDate>";
                        replacText1 = data_this.T_Tenant.IDDate;
                        replace1 = WdReplace.wdReplaceAll;
                        findWrap1 = WdFindWrap.wdFindContinue;
                        find1.Execute(ref findText1, ref o, ref o, ref o, ref oFalse, ref o, ref o, ref findWrap1, ref o, ref replacText1, ref replace1, ref o, ref o, ref o, ref o);
                        Marshal.FinalReleaseComObject(find1);
                    }
                    catch
                    {
                    }
                    try
                    {
                        find1 = range.Find;
                        findText1 = "<EyeTyp>";
                        replacText1 = ((LangArEn == 0) ? data_this.T_EqarsData.T_AinsDatas.Where((T_AinsData g) => g.AinID == data_this.T_AinsData.AinID).FirstOrDefault().T_AinTyp.NameA : data_this.T_EqarsData.T_AinsDatas.Where((T_AinsData g) => g.AinID == data_this.T_AinsData.AinID).FirstOrDefault().T_AinTyp.NameE);
                        if (LangArEn == 0 && !replacText1.ToString().StartsWith("ال"))
                        {
                            replacText1 = "ال" + replacText1;
                        }
                        replace1 = WdReplace.wdReplaceAll;
                        findWrap1 = WdFindWrap.wdFindContinue;
                        find1.Execute(ref findText1, ref o, ref o, ref o, ref oFalse, ref o, ref o, ref findWrap1, ref o, ref replacText1, ref replace1, ref o, ref o, ref o, ref o);
                        Marshal.FinalReleaseComObject(find1);
                    }
                    catch
                    {
                    }
                    try
                    {
                        find1 = range.Find;
                        findText1 = "<EyeNo>";
                        replacText1 = data_this.T_EqarsData.T_AinsDatas.Where((T_AinsData g) => g.AinID == data_this.T_AinsData.AinID).FirstOrDefault().AinNo;
                        replace1 = WdReplace.wdReplaceAll;
                        findWrap1 = WdFindWrap.wdFindContinue;
                        find1.Execute(ref findText1, ref o, ref o, ref o, ref oFalse, ref o, ref o, ref findWrap1, ref o, ref replacText1, ref replace1, ref o, ref o, ref o, ref o);
                        Marshal.FinalReleaseComObject(find1);
                    }
                    catch
                    {
                    }
                    try
                    {
                        find1 = range.Find;
                        findText1 = "<Streat>";
                        replacText1 = data_this.T_EqarsData.Street;
                        replace1 = WdReplace.wdReplaceAll;
                        findWrap1 = WdFindWrap.wdFindContinue;
                        find1.Execute(ref findText1, ref o, ref o, ref o, ref oFalse, ref o, ref o, ref findWrap1, ref o, ref replacText1, ref replace1, ref o, ref o, ref o, ref o);
                        Marshal.FinalReleaseComObject(find1);
                    }
                    catch
                    {
                    }
                    try
                    {
                        find1 = range.Find;
                        findText1 = "<Dist>";
                        replacText1 = data_this.T_EqarsData.Neighborhood;
                        replace1 = WdReplace.wdReplaceAll;
                        findWrap1 = WdFindWrap.wdFindContinue;
                        find1.Execute(ref findText1, ref o, ref o, ref o, ref oFalse, ref o, ref o, ref findWrap1, ref o, ref replacText1, ref replace1, ref o, ref o, ref o, ref o);
                        Marshal.FinalReleaseComObject(find1);
                    }
                    catch
                    {
                    }
                    try
                    {
                        find1 = range.Find;
                        findText1 = "<City>";
                        replacText1 = ((LangArEn == 0) ? data_this.T_EqarsData.T_City.NameA : data_this.T_EqarsData.T_City.NameE);
                        replace1 = WdReplace.wdReplaceAll;
                        findWrap1 = WdFindWrap.wdFindContinue;
                        find1.Execute(ref findText1, ref o, ref o, ref o, ref oFalse, ref o, ref o, ref findWrap1, ref o, ref replacText1, ref replace1, ref o, ref o, ref o, ref o);
                        Marshal.FinalReleaseComObject(find1);
                    }
                    catch
                    {
                    }
                    try
                    {
                        find1 = range.Find;
                        findText1 = "<StrCon>";
                        replacText1 = data_this.ContractStart;
                        replace1 = WdReplace.wdReplaceAll;
                        findWrap1 = WdFindWrap.wdFindContinue;
                        find1.Execute(ref findText1, ref o, ref o, ref o, ref oFalse, ref o, ref o, ref findWrap1, ref o, ref replacText1, ref replace1, ref o, ref o, ref o, ref o);
                        Marshal.FinalReleaseComObject(find1);
                    }
                    catch
                    {
                    }
                    try
                    {
                        find1 = range.Find;
                        findText1 = "<EndCon>";
                        replacText1 = data_this.ContractEnd;
                        replace1 = WdReplace.wdReplaceAll;
                        findWrap1 = WdFindWrap.wdFindContinue;
                        find1.Execute(ref findText1, ref o, ref o, ref o, ref oFalse, ref o, ref o, ref findWrap1, ref o, ref replacText1, ref replace1, ref o, ref o, ref o, ref o);
                        Marshal.FinalReleaseComObject(find1);
                    }
                    catch
                    {
                    }
                    try
                    {
                        find1 = range.Find;
                        findText1 = "<YearRent>";
                        replacText1 = data_this.RentOfYear;
                        replace1 = WdReplace.wdReplaceAll;
                        findWrap1 = WdFindWrap.wdFindContinue;
                        find1.Execute(ref findText1, ref o, ref o, ref o, ref oFalse, ref o, ref o, ref findWrap1, ref o, ref replacText1, ref replace1, ref o, ref o, ref o, ref o);
                        Marshal.FinalReleaseComObject(find1);
                    }
                    catch
                    {
                    }
                    try
                    {
                        find1 = range.Find;
                        findText1 = "<YearRentHr>";
                        replacText1 = ScriptNumber1.ScriptNum(decimal.Parse(VarGeneral.TString.TEmpty(string.Concat(data_this.RentOfYear.Value))));
                        replace1 = WdReplace.wdReplaceAll;
                        findWrap1 = WdFindWrap.wdFindContinue;
                        find1.Execute(ref findText1, ref o, ref o, ref o, ref oFalse, ref o, ref o, ref findWrap1, ref o, ref replacText1, ref replace1, ref o, ref o, ref o, ref o);
                        Marshal.FinalReleaseComObject(find1);
                    }
                    catch
                    {
                    }
                }
            }
            try
            {
                doc.Save();
            }
            catch
            {
            }
            app.Visible = true;
            try
            {
                Window window = app.ActiveWindow;
                window.SetFocus();
                window.Activate();
                if (window != null)
                {
                    Marshal.ReleaseComObject(window);
                }
            }
            catch
            {
            }
            doc = null;
            app = null;
            try
            {
                for (int i = System.Windows.Forms.Application.OpenForms.Count - 1; i >= 0; i--)
                {
                    if (System.Windows.Forms.Application.OpenForms[i].Name != "FrmMn")
                    {
                        System.Windows.Forms.Application.OpenForms[i].Close();
                    }
                }
            }
            catch
            {
            }
        }
        private void Button_DelContract_Click(object sender, EventArgs e)
        {
            if (State != 0)
            {
                return;
            }
            string vPth = System.Windows.Forms.Application.StartupPath + "\\ContractRent\\Contract" + textBox_ID.Text + ".doc";
            if (File.Exists(vPth) && MessageBox.Show("هل أنت متاكد من حذف العقد رقم [" + textBox_ID.Text + "]؟ \n Are you sure that you want to delete the Contract No [" + textBox_ID.Text + "]?", VarGeneral.ProdectNam, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.No)
            {
                try
                {
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    File.Delete(vPth);
                    MessageBox.Show((LangArEn == 0) ? "لقد تم اتمام العملية بنجاح .." : "This Opration Is Done", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                catch
                {
                }
            }
        }
    }
}
