using C1.Win.C1BarCode;
using C1.Win.C1FlexGrid;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.DotNetBar.SuperGrid;
using DevComponents.DotNetBar.SuperGrid.Style;
using DevComponents.Editors;
using InvAcc.GeneralM;
using InvAcc.Stock_Data;
using SSSDateTime.Date;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial class FrmTenantPayment : Form
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
        private C1BarCode c1BarCode1;
        private DoubleInput txtRentOfYear;
        private LabelItem lable_Records;
        internal Label label22;
        private Label label3;
        private Label label7;
        public TextBox txtTenantName;
        public TextBox txtTenantNo;
        public TextBox textBox_ID;
        private Label label18;
        private ComboBox CmbTenanPayMethod;
        private C1FlexGrid FlxPayment;
        public MaskedTextBox txtContractStart;
        public MaskedTextBox txtContractEnd;
        private SuperTabControl superTabControl_Main1;
        protected ButtonItem Button_Close;
        protected ButtonItem Button_Search;
        protected ButtonItem Button_Delete;
        protected ButtonItem Button_Save;
        protected ButtonItem Button_Add;
        protected LabelItem labelItem2;
        public Dictionary<string, ColumnDictinary> columns_Names_visible = new Dictionary<string, ColumnDictinary>();
        public Dictionary<string, ColumnDictinary> columns_Names_visible2 = new Dictionary<string, ColumnDictinary>();
        private HijriGreg.HijriGregDates n = new HijriGreg.HijriGregDates();
        private T_AccDef _AccDefBind = new T_AccDef();
        private int LangArEn = 0;
        public int ProcessTyp = 0;
        protected bool ifOkDelete;
        public bool CanEdit = true;
        protected bool CanInsert = true;
        private string FlagUpdate = string.Empty;
        public ViewState ViewState = ViewState.Deiles;
        private FormState statex;
        public List<Control> controls;
        public Control codeControl = new Control();
        private T_INVSETTING _InvSetting = new T_INVSETTING();
        private T_Company _Company = new T_Company();
        private T_TenantPayment _TenantPayment = new T_TenantPayment();
        private bool canUpdate = true;
        public T_TenantContract data_this;
        private List<T_TenantPayment> LData_This;
        private Stock_DataDataContext dbInstance;
        private List<string> pkeys = new List<string>();
        private Rate_DataDataContext dbInstanceRate;
        private T_User permission = new T_User();
        public bool FrmTyp = false;
        public bool SelectPayment = false;
        public int _ContractNo;
        public int Payment_No = 0;
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
        public List<T_TenantPayment> LDataThis
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
                }
            }
        }
        public int PaymentNo
        {
            get
            {
                return Payment_No;
            }
            set
            {
                Payment_No = value;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InvAcc.Forms.FrmTenantPayment));
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
            FlxPayment = new C1.Win.C1FlexGrid.C1FlexGrid();
            label18 = new System.Windows.Forms.Label();
            CmbTenanPayMethod = new System.Windows.Forms.ComboBox();
            txtTenantNo = new System.Windows.Forms.TextBox();
            txtContractEnd = new System.Windows.Forms.MaskedTextBox();
            label7 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            txtContractStart = new System.Windows.Forms.MaskedTextBox();
            label22 = new System.Windows.Forms.Label();
            label19 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            txtRentOfYear = new DevComponents.Editors.DoubleInput();
            c1BarCode1 = new C1.Win.C1BarCode.C1BarCode();
            textBox_ID = new System.Windows.Forms.TextBox();
            txtTenantName = new System.Windows.Forms.TextBox();
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
            Button_Search = new DevComponents.DotNetBar.ButtonItem();
            Button_Delete = new DevComponents.DotNetBar.ButtonItem();
            Button_Save = new DevComponents.DotNetBar.ButtonItem();
            Button_Add = new DevComponents.DotNetBar.ButtonItem();
            labelItem2 = new DevComponents.DotNetBar.LabelItem();
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
            ((System.ComponentModel.ISupportInitialize)FlxPayment).BeginInit();
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
            ribbonBar1.Controls.Add(FlxPayment);
            ribbonBar1.Controls.Add(label18);
            ribbonBar1.Controls.Add(CmbTenanPayMethod);
            ribbonBar1.Controls.Add(txtTenantNo);
            ribbonBar1.Controls.Add(txtContractEnd);
            ribbonBar1.Controls.Add(label7);
            ribbonBar1.Controls.Add(label3);
            ribbonBar1.Controls.Add(txtContractStart);
            ribbonBar1.Controls.Add(label22);
            ribbonBar1.Controls.Add(label19);
            ribbonBar1.Controls.Add(label4);
            ribbonBar1.Controls.Add(txtRentOfYear);
            ribbonBar1.Controls.Add(c1BarCode1);
            ribbonBar1.Controls.Add(textBox_ID);
            ribbonBar1.Controls.Add(txtTenantName);
            resources.ApplyResources(ribbonBar1, "ribbonBar1");
            ribbonBar1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            ribbonBar1.Name = "ribbonBar1";
            ribbonBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            ribbonBar1.TitleStyle.BackColor = System.Drawing.Color.FromArgb(227, 239, 255);
            ribbonBar1.TitleStyle.BackColor2 = System.Drawing.Color.FromArgb(101, 147, 207);
            ribbonBar1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            ribbonBar1.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            FlxPayment.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None;
            FlxPayment.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None;
            FlxPayment.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
            resources.ApplyResources(FlxPayment, "FlxPayment");
            FlxPayment.ExtendLastCol = true;
            FlxPayment.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            FlxPayment.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross;
            FlxPayment.Name = "FlxPayment";
            FlxPayment.Rows.DefaultSize = 19;
            FlxPayment.ShowSortPosition = C1.Win.C1FlexGrid.ShowSortPositionEnum.None;
            FlxPayment.StyleInfo = resources.GetString("FlxPayment.StyleInfo");
            FlxPayment.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Blue;
            FlxPayment.KeyDown += new System.Windows.Forms.KeyEventHandler(FlxPayment_KeyDown);
            FlxPayment.BeforeEdit += new C1.Win.C1FlexGrid.RowColEventHandler(FlxPayment_BeforeEdit);
            FlxPayment.AfterEdit += new C1.Win.C1FlexGrid.RowColEventHandler(FlxPayment_AfterEdit);
            resources.ApplyResources(label18, "label18");
            label18.Name = "label18";
            CmbTenanPayMethod.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            CmbTenanPayMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(CmbTenanPayMethod, "CmbTenanPayMethod");
            CmbTenanPayMethod.FormattingEnabled = true;
            CmbTenanPayMethod.Name = "CmbTenanPayMethod";
            CmbTenanPayMethod.SelectedIndexChanged += new System.EventHandler(CmbTenanPayMethod_SelectedIndexChanged);
            txtTenantNo.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
            txtTenantNo.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
            resources.ApplyResources(txtTenantNo, "txtTenantNo");
            txtTenantNo.Name = "txtTenantNo";
            txtTenantNo.ReadOnly = true;
            txtContractEnd.BackColor = System.Drawing.Color.WhiteSmoke;
            resources.ApplyResources(txtContractEnd, "txtContractEnd");
            txtContractEnd.Name = "txtContractEnd";
            txtContractEnd.ReadOnly = true;
            txtContractEnd.Leave += new System.EventHandler(txtContractEnd_Leave);
            txtContractEnd.Click += new System.EventHandler(txtContractEnd_Click);
            resources.ApplyResources(label7, "label7");
            label7.Name = "label7";
            resources.ApplyResources(label3, "label3");
            label3.Name = "label3";
            txtContractStart.BackColor = System.Drawing.Color.WhiteSmoke;
            resources.ApplyResources(txtContractStart, "txtContractStart");
            txtContractStart.Name = "txtContractStart";
            txtContractStart.ReadOnly = true;
            txtContractStart.Leave += new System.EventHandler(txtContractStart_Leave);
            txtContractStart.Click += new System.EventHandler(txtContractStart_Click);
            resources.ApplyResources(label22, "label22");
            label22.BackColor = System.Drawing.Color.Transparent;
            label22.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            label22.Name = "label22";
            resources.ApplyResources(label19, "label19");
            label19.Name = "label19";
            resources.ApplyResources(label4, "label4");
            label4.Name = "label4";
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
            txtRentOfYear.Leave += new System.EventHandler(txtRentOfYear_Leave);
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
            textBox_ID.Tag = string.Empty;
            textBox_ID.TextChanged += new System.EventHandler(textBox_ID_TextChanged);
            textBox_ID.Click += new System.EventHandler(textBox_ID_Click);
            textBox_ID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(textBox_ID_KeyPress);
            txtTenantName.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
            txtTenantName.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
            resources.ApplyResources(txtTenantName, "txtTenantName");
            txtTenantName.Name = "txtTenantName";
            txtTenantName.ReadOnly = true;
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
            DGV_Main.PrimaryGrid.Caption.Text = string.Empty;
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
            DGV_Main.PrimaryGrid.GroupByRow.Text = "???????????? ??????????????????????";
            DGV_Main.PrimaryGrid.GroupByRow.Visible = true;
            DGV_Main.PrimaryGrid.GroupByRow.WatermarkText = string.Empty;
            DGV_Main.PrimaryGrid.InitialActiveRow = DevComponents.DotNetBar.SuperGrid.RelativeRow.None;
            DGV_Main.PrimaryGrid.InitialSelection = DevComponents.DotNetBar.SuperGrid.RelativeSelection.None;
            DGV_Main.PrimaryGrid.MultiSelect = false;
            DGV_Main.PrimaryGrid.ShowRowGridIndex = true;
            DGV_Main.PrimaryGrid.Title.AllowSelection = false;
            DGV_Main.PrimaryGrid.Title.Text = string.Empty;
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
            superTabControl_DGV.ControlBox.CloseBox.Name = string.Empty;
            superTabControl_DGV.ControlBox.MenuBox.Name = string.Empty;
            superTabControl_DGV.ControlBox.Name = string.Empty;
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
            panelEx2.MinimumSize = new System.Drawing.Size(734, 346);
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
            superTabControl_Main1.ControlBox.CloseBox.Name = string.Empty;
            superTabControl_Main1.ControlBox.MenuBox.Name = string.Empty;
            superTabControl_Main1.ControlBox.Name = string.Empty;
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
            superTabControl_Main1.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[6]
            {
                Button_Close,
                Button_Search,
                Button_Delete,
                Button_Save,
                Button_Add,
                labelItem2
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
            Button_Search.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            Button_Search.FontBold = true;
            Button_Search.FontItalic = true;
            Button_Search.ForeColor = System.Drawing.Color.Green;
            Button_Search.Image = (System.Drawing.Image)resources.GetObject("Button_Search.Image");
            Button_Search.ImageFixedSize = new System.Drawing.Size(28, 28);
            Button_Search.ImagePaddingHorizontal = 15;
            Button_Search.ImagePaddingVertical = 11;
            Button_Search.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            Button_Search.Name = "Button_Search";
            Button_Search.Stretch = true;
            Button_Search.SubItemsExpandWidth = 14;
            Button_Search.Symbol = "\uf002";
            Button_Search.SymbolSize = 15f;
            resources.ApplyResources(Button_Search, "Button_Search");
            Button_Search.Visible = false;
            Button_Delete.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            Button_Delete.FontBold = true;
            Button_Delete.FontItalic = true;
            Button_Delete.ForeColor = System.Drawing.Color.SteelBlue;
            Button_Delete.Image = (System.Drawing.Image)resources.GetObject("Button_Delete.Image");
            Button_Delete.ImageFixedSize = new System.Drawing.Size(28, 28);
            Button_Delete.ImagePaddingHorizontal = 15;
            Button_Delete.ImagePaddingVertical = 11;
            Button_Delete.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            Button_Delete.Name = "Button_Delete";
            Button_Delete.Stretch = true;
            Button_Delete.SubItemsExpandWidth = 14;
            Button_Delete.Symbol = "\uf014";
            Button_Delete.SymbolSize = 15f;
            resources.ApplyResources(Button_Delete, "Button_Delete");
            Button_Delete.Click += new System.EventHandler(Button_Delete_Click);
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
            labelItem2.Width = 40;
            superTabControl_Main2.BackColor = System.Drawing.Color.White;
            superTabControl_Main2.CausesValidation = false;
            superTabControl_Main2.ControlBox.CloseBox.Name = string.Empty;
            superTabControl_Main2.ControlBox.MenuBox.Name = string.Empty;
            superTabControl_Main2.ControlBox.Name = string.Empty;
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
            base.Name = "FrmTenantPayment";
            base.Load += new System.EventHandler(FrmTenantPayment_Load);
            base.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Frm_KeyPress);
            base.KeyDown += new System.Windows.Forms.KeyEventHandler(Frm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)Rep_RecCount).EndInit();
            ribbonBar1.ResumeLayout(false);
            ribbonBar1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)FlxPayment).EndInit();
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
        public FrmTenantPayment()
        {
            InitializeComponent();
            txtContractEnd.Click += Button_Edit_Click;
            txtContractStart.Click += Button_Edit_Click;
            txtRentOfYear.Click += Button_Edit_Click;
            txtTenantName.Click += Button_Edit_Click;
            txtTenantNo.Click += Button_Edit_Click;
            CmbTenanPayMethod.Click += Button_Edit_Click;
            FlxPayment.Click += Button_Edit_Click;
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
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
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
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
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
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
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
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
            {
                lable_Records.Text = "?????????? " + vPosition + " ???? " + vCount;
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
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmTenantPayment));
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
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
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
                Text = "????????????????????????????";
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
                Text = "Payments Card";
            }
            ArbEng();
        }
        private void ArbEng()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
            {
                LangArEn = 0;
                FlxPayment.Cols[1].Caption = "????????????????";
                FlxPayment.Cols[2].Caption = "?????? ????????????";
                FlxPayment.Cols[3].Caption = "???????? ????????????";
                FlxPayment.Cols[4].Caption = "??????????????";
                FlxPayment.Cols[5].Caption = "??????????";
                FlxPayment.Cols[6].Caption = "??????????????";
                FlxPayment.Cols[7].Caption = (SelectPayment ? "???????????? ????????????" : "?????? ????????????");
            }
            else
            {
                LangArEn = 1;
                FlxPayment.Cols[1].Caption = "Amount";
                FlxPayment.Cols[2].Caption = "Month repayment";
                FlxPayment.Cols[3].Caption = "Status";
                FlxPayment.Cols[4].Caption = "Residual";
                FlxPayment.Cols[5].Caption = "Bond";
                FlxPayment.Cols[6].Caption = "Sequence";
                FlxPayment.Cols[7].Caption = (SelectPayment ? "Select" : "Delete line");
            }
        }
        private void FrmTenantPayment_Load(object sender, EventArgs e)
        {
            try
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmTenantPayment));
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
                if (columns_Names_visible.Count == 0)
                {
                    columns_Names_visible.Add("PaymentNo", new ColumnDictinary("?????????? ", " No", ifDefault: true, string.Empty));
                }
                else
                {
                    Clear();
                    textBox_ID.Text = string.Empty;
                    TextBox_Index.TextBox.Text = string.Empty;
                }
                RibunButtons();
                FillCombo();
                ViewDetails_Click(sender, e);
                FlxPayment.DrawMode = DrawModeEnum.OwnerDraw;
                FlxPayment.OwnerDrawCell += _ownerDraw;
                LDataThis = new BindingList<T_TenantPayment>(data_this.T_TenantPayments).OrderBy((T_TenantPayment g) => g.PaymentNo).ToList();
                if (LDataThis.Count <= 0)
                {
                    Button_Add_Click(sender, e);
                    textBox_ID.Text = data_this.ContractNo.ToString();
                    txtRentOfYear.Value = data_this.RentOfYear.Value;
                    try
                    {
                        if (VarGeneral.CheckDate(data_this.ContractEnd))
                        {
                            txtContractEnd.Text = data_this.ContractEnd;
                        }
                        else
                        {
                            txtContractEnd.Text = string.Empty;
                        }
                    }
                    catch
                    {
                        txtContractEnd.Text = string.Empty;
                    }
                    try
                    {
                        if (VarGeneral.CheckDate(data_this.ContractStart))
                        {
                            txtContractStart.Text = data_this.ContractStart;
                        }
                        else
                        {
                            txtContractStart.Text = string.Empty;
                        }
                    }
                    catch
                    {
                        txtContractStart.Text = string.Empty;
                    }
                    txtTenantName.Text = ((LangArEn == 0) ? data_this.T_Tenant.NameA : data_this.T_Tenant.NameE);
                    txtTenantNo.Text = data_this.T_Tenant.tenantNo.ToString();
                    txtTenantNo.Tag = data_this.T_Tenant.tenantID;
                    CmbTenanPayMethod.SelectedIndex = 0;
                }
                else
                {
                    int ContractId = data_this.ContractID;
                    Clear();
                    data_this = new T_TenantContract();
                    data_this = db.StockTenantContractDataID(ContractId);
                    SetData(data_this);
                    Button_Add.Visible = false;
                    CmbTenanPayMethod.Enabled = false;
                }
                if (FrmTyp)
                {
                    FlxPayment.Dock = DockStyle.Fill;
                    Button_Delete.Visible = false;
                    Button_Save.Visible = false;
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
        }
        public void Clear()
        {
            if (State == FormState.New)
            {
                return;
            }
            State = FormState.New;
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
                        (controls[i] as ComboBox).SelectedIndex = -1;
                    }
                }
            }
            textBox_ID.Focus();
            FlxPayment.Clear(ClearFlags.Content, 1, 1, FlxPayment.Rows.Count, 7);
            FlxPayment.Rows.Count = 50;
            SetReadOnly = false;
        }
        public void SetData(T_TenantContract value)
        {
            try
            {
                State = FormState.Saved;
                Button_Save.Enabled = false;
                textBox_ID.Text = value.ContractNo.ToString();
                textBox_ID.Tag = value.ContractID.ToString();
                try
                {
                    if (VarGeneral.CheckDate(value.ContractEnd))
                    {
                        txtContractEnd.Text = value.ContractEnd;
                    }
                    else
                    {
                        txtContractEnd.Text = string.Empty;
                    }
                }
                catch
                {
                    txtContractEnd.Text = string.Empty;
                }
                try
                {
                    if (VarGeneral.CheckDate(value.ContractStart))
                    {
                        txtContractStart.Text = value.ContractStart;
                    }
                    else
                    {
                        txtContractStart.Text = string.Empty;
                    }
                }
                catch
                {
                    txtContractStart.Text = string.Empty;
                }
                txtRentOfYear.Value = value.RentOfYearPayment.Value;
                txtTenantName.Text = ((LangArEn == 0) ? value.T_Tenant.NameA : value.T_Tenant.NameE);
                txtTenantNo.Text = value.T_Tenant.tenantNo.ToString();
                txtTenantNo.Tag = value.T_Tenant.tenantID;
                CmbTenanPayMethod.SelectedIndex = value.PayMethod.Value;
                LDataThis = new BindingList<T_TenantPayment>(data_this.T_TenantPayments).OrderBy((T_TenantPayment g) => g.PaymentNo).ToList();
                if (LData_This.Count > 0)
                {
                    SetLines(LDataThis);
                }
                else
                {
                    txtRentOfYear.Value = value.RentOfYear.Value;
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("SetData:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        public void SetLines(List<T_TenantPayment> listDet)
        {
            try
            {
                FlxPayment.Rows.Count = listDet.Count + 1;
                for (int iiCnt = 1; iiCnt <= listDet.Count; iiCnt++)
                {
                    _TenantPayment = listDet[iiCnt - 1];
                    FlxPayment.SetData(iiCnt, 0, _TenantPayment.PaymentNo);
                    FlxPayment.SetData(iiCnt, 1, _TenantPayment.Value);
                    FlxPayment.SetData(iiCnt, 2, _TenantPayment.PayMonth);
                    FlxPayment.SetData(iiCnt, 4, _TenantPayment.Remining.Value);
                    if (_TenantPayment.SndNo.HasValue)
                    {
                        FlxPayment.SetData(iiCnt, 5, _TenantPayment.T_GDHEAD.gdNo);
                        FlxPayment.SetData(iiCnt, 3, true);
                    }
                    else
                    {
                        FlxPayment.SetData(iiCnt, 5, 0);
                        FlxPayment.SetData(iiCnt, 3, false);
                    }
                    FlxPayment.SetData(iiCnt, 6, _TenantPayment.PaymentID);
                }
                if (LDataThis.Where((T_TenantPayment g) => g.SndNo.HasValue).ToList().Count > 0)
                {
                    IfDelete = false;
                }
            }
            catch
            {
                MessageBox.Show((LangArEn == 0) ? "?????? ?????? ?????????? ?????????? ???????????? .." : "An error occurred while filling lines ..", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
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
            data_this.RentOfYearPayment = txtRentOfYear.Value;
            data_this.PayMethod = CmbTenanPayMethod.SelectedIndex;
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
            if (State != FormState.Edit || MessageBox.Show((LangArEn == 0) ? "???? ?????????? ?????????? ???????????? ?????? ?????? ?????????????????? .. ???? ???????? ??????????????????" : "Not saved the changes, do you really want to continue?", VarGeneral.ProdectNam, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                Clear();
                State = FormState.New;
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
                MessageBox.Show((LangArEn == 0) ? "???? ???????? ?????????? ?????? ?????????????? .. ???????????? ???????????? ?????????????? ???????????????????? !" : "Can not complete this process .. please see the powers of the users!", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }
            if (textBox_ID.Text == "0" || textBox_ID.Text == string.Empty)
            {
                MessageBox.Show((LangArEn == 0) ? "???? ???????? ?????????? ???????? ?????? ??????????" : "Can not save without the Contract No", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                textBox_ID.Focus();
                return false;
            }
            if (!VarGeneral.CheckDate(txtContractStart.Text))
            {
                MessageBox.Show((LangArEn == 0) ? "???????????? ???? ???????? ?????????????? ??????????\u0651" : "Can not be Date is empty", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                txtContractStart.Focus();
                return false;
            }
            if (!VarGeneral.CheckDate(txtContractEnd.Text))
            {
                MessageBox.Show((LangArEn == 0) ? "???????????? ???? ???????? ?????????????? ??????????\u0651" : "Can not be Date is empty", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                txtContractEnd.Focus();
                return false;
            }
            return true;
        }
        private void Button_Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidData())
                {
                    return;
                }
                if (State == FormState.Edit)
                {
                    for (int i = 0; i < LData_This.ToList().Count; i++)
                    {
                        if (!LDataThis[i].SndNo.HasValue)
                        {
                            db.T_TenantPayments.DeleteOnSubmit(LData_This[i]);
                            db.SubmitChanges();
                        }
                    }
                }
                GetData();
                try
                {
                    db.Log = VarGeneral.DebugLog;
                    db.SubmitChanges(ConflictMode.ContinueOnConflict);
                }
                catch (Exception)
                {
                    return;
                }
                int ii = 0;
                int Seq = 0;
                for (ii = 1; ii < FlxPayment.Rows.Count; ii++)
                {
                    try
                    {
                        if (!(double.Parse(FlxPayment.GetData(ii, 1).ToString()) > 0.0) || !VarGeneral.CheckDate(FlxPayment.GetData(ii, 2).ToString()))
                        {
                            continue;
                        }
                        try
                        {
                            if (Convert.ToBoolean(FlxPayment.GetData(ii, 3).ToString()))
                            {
                                _TenantPayment = new T_TenantPayment();
                                _TenantPayment = LData_This.Where((T_TenantPayment g) => g.PaymentID == int.Parse(FlxPayment.GetData(ii, 6).ToString())).FirstOrDefault();
                                if (_TenantPayment != null && _TenantPayment.PaymentID > 0)
                                {
                                    goto IL_02bd;
                                }
                                continue;
                            }
                            _TenantPayment = new T_TenantPayment();
                            goto IL_01ec;
                        }
                        catch
                        {
                            _TenantPayment = new T_TenantPayment();
                            goto IL_01ec;
                        }
                        IL_02bd:
                        _TenantPayment.PaymentNo = Seq;
                        db.T_TenantPayments.InsertOnSubmit(_TenantPayment);
                        db.SubmitChanges();
                        goto end_IL_00ef;
                        IL_01ec:
                        Seq++;
                        _TenantPayment.Statue = false;
                        _TenantPayment.tenantContract_ID = data_this.ContractID;
                        _TenantPayment.PayMonth = FlxPayment.GetData(ii, 2).ToString();
                        _TenantPayment.SndNo = null;
                        try
                        {
                            _TenantPayment.Value = double.Parse(FlxPayment.GetData(ii, 1).ToString());
                        }
                        catch
                        {
                            _TenantPayment.Value = 0.0;
                        }
                        _TenantPayment.Remining = _TenantPayment.Value;
                        goto IL_02bd;
                        end_IL_00ef:;
                    }
                    catch
                    {
                    }
                }
                MessageBox.Show((LangArEn == 0) ? "?????? ???? ?????????? ?????????????? ?????????? .." : "This Opration Is Done", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                State = FormState.Saved;
                SetReadOnly = true;
                Close();
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
            panel.Columns["PaymentNo"].Width = 120;
            panel.Columns["PaymentNo"].Visible = columns_Names_visible["PaymentNo"].IfDefault;
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
                ExportExcel.ExportToExcel(DGV_Main, "?????????? ????????????????");
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
                controls.Add(txtContractEnd);
                controls.Add(txtContractStart);
                controls.Add(txtRentOfYear);
                controls.Add(txtTenantName);
                controls.Add(txtTenantNo);
                controls.Add(CmbTenanPayMethod);
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
            }
        }
        private void textBox_ID_Click(object sender, EventArgs e)
        {
            textBox_ID.SelectAll();
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
                    txtContractStart.Text = string.Empty;
                }
            }
            catch
            {
                txtContractStart.Text = string.Empty;
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
                    txtContractEnd.Text = string.Empty;
                }
            }
            catch
            {
                txtContractEnd.Text = string.Empty;
            }
        }
        private void txtContractEnd_Click(object sender, EventArgs e)
        {
            txtContractEnd.SelectAll();
        }
        private void FillCombo()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
            {
                CmbTenanPayMethod.Items.Add("???? ??????");
                CmbTenanPayMethod.Items.Add("???? 2 ??????");
                CmbTenanPayMethod.Items.Add("???? 3 ????????");
                CmbTenanPayMethod.Items.Add("???? 4 ????????");
                CmbTenanPayMethod.Items.Add("???? 6 ????????");
                CmbTenanPayMethod.Items.Add("???? ??????");
            }
            else
            {
                CmbTenanPayMethod.Items.Add("Every month");
                CmbTenanPayMethod.Items.Add("Every 2 months");
                CmbTenanPayMethod.Items.Add("Every 3 months");
                CmbTenanPayMethod.Items.Add("Every 4 months");
                CmbTenanPayMethod.Items.Add("Every 6 months");
                CmbTenanPayMethod.Items.Add("Every years");
            }
            CmbTenanPayMethod.SelectedIndex = 0;
        }
        private void CheckAqsat()
        {
            try
            {
                if (!(txtRentOfYear.Value < 1.0) && VarGeneral.CheckDate(txtContractStart.Text) && VarGeneral.CheckDate(txtContractEnd.Text))
                {
                    int AqNo = 0;
                    int MnStep = 0;
                    int iiCnt = 0;
                    int AqMn = 0;
                    DateTime date1 = Convert.ToDateTime(txtContractStart.Text);
                    DateTime date2 = Convert.ToDateTime(txtContractEnd.Text);
                    DateTime sdt = Convert.ToDateTime(txtContractStart.Text);
                    DateTime edt = Convert.ToDateTime(txtContractEnd.Text);
                    while (sdt < edt)
                    {
                        sdt = sdt.AddMonths(1);
                        AqNo++;
                    }
                    AqNo++;
                    switch (CmbTenanPayMethod.SelectedIndex)
                    {
                        case 0:
                            MnStep = 1;
                            AqNo = int.Parse((AqNo / 1).ToString());
                            break;
                        case 1:
                            MnStep = 2;
                            AqNo = int.Parse((AqNo / 2).ToString());
                            break;
                        case 2:
                            MnStep = 3;
                            AqNo = int.Parse((AqNo / 3).ToString());
                            break;
                        case 3:
                            MnStep = 4;
                            AqNo = int.Parse((AqNo / 4).ToString());
                            break;
                        case 4:
                            MnStep = 6;
                            AqNo = int.Parse((AqNo / 6).ToString());
                            break;
                        case 5:
                            MnStep = 12;
                            AqNo = int.Parse((AqNo / 12).ToString());
                            break;
                    }
                    double lstqst = txtRentOfYear.Value % (double)AqNo;
                    double qstVal = Math.Truncate(txtRentOfYear.Value / (double)AqNo);
                    FlxPayment.Clear(ClearFlags.Content, 1, 1, FlxPayment.Rows.Count, 7);
                    FlxPayment.Rows.Count = int.Parse(AqNo.ToString()) + 50;
                    for (int oo = 1; oo <= AqNo; oo++)
                    {
                        iiCnt++;
                        FlxPayment.SetData(iiCnt, 1, (oo == AqNo) ? (qstVal + lstqst) : qstVal);
                        FlxPayment.SetData(iiCnt, 2, Convert.ToDateTime(txtContractStart.Text).AddMonths(AqMn).ToString("yyyy/MM"));
                        FlxPayment.SetData(iiCnt, 4, 0);
                        AqMn += MnStep;
                    }
                }
            }
            catch
            {
            }
        }
        private void CmbTenanPayMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckAqsat();
        }
        private void FlxPayment_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (!FrmTyp && e.KeyCode == Keys.Delete && (!(double.Parse(FlxPayment.GetData(FlxPayment.Row, 1).ToString()) > 0.0) || !VarGeneral.CheckDate(FlxPayment.GetData(FlxPayment.Row, 2).ToString()) || MessageBox.Show("???? ?????? ?????????? ???? ?????? ?????????? [" + FlxPayment.Row + "]?? \n Are you sure that you want to delete the line [" + FlxPayment.Row + "]?", VarGeneral.ProdectNam, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.No) && !Convert.ToBoolean(FlxPayment.GetData(FlxPayment.Row, 3).ToString()))
                {
                    FlxPayment.RemoveItem(FlxPayment.Row);
                    FlxPayment.Rows.Add();
                }
            }
            catch
            {
                FlxPayment.RemoveItem(FlxPayment.Row);
                FlxPayment.Rows.Add();
            }
        }
        private void FlxPayment_BeforeEdit(object sender, RowColEventArgs e)
        {
            try
            {
                if (Convert.ToBoolean(FlxPayment.GetData(e.Row, 3).ToString()) || (FrmTyp && e.Col != 7))
                {
                    e.Cancel = true;
                }
            }
            catch
            {
            }
        }
        private void Button_Delete_Click(object sender, EventArgs e)
        {
            if (!Button_Delete.Enabled || !Button_Delete.Visible || State != 0)
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
            if (MessageBox.Show("???? ?????? ?????????? ???? ?????? ?????????? [" + Code + "]?? \n Are you sure that you want to delete the record [" + Code + "]?", VarGeneral.ProdectNam, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ifOkDelete = true;
            }
            else
            {
                ifOkDelete = false;
            }
            if (data_this != null && data_this.ContractID != 0 && ifOkDelete)
            {
                try
                {
                    db.T_TenantPayments.DeleteAllOnSubmit(data_this.T_TenantPayments);
                    db.SubmitChanges();
                }
                catch (SqlException)
                {
                }
                catch (Exception)
                {
                }
                Close();
            }
        }
        private void FlxPayment_AfterEdit(object sender, RowColEventArgs e)
        {
            if (e.Col != 7)
            {
                return;
            }
            if (SelectPayment)
            {
                PaymentNo = 0;
                if (!Convert.ToBoolean(FlxPayment.GetData(e.Row, e.Col).ToString()))
                {
                    return;
                }
                try
                {
                    if (double.Parse(FlxPayment.GetData(e.Row, 1).ToString()) > 0.0 && VarGeneral.CheckDate(FlxPayment.GetData(e.Row, 2).ToString()))
                    {
                        if (MessageBox.Show("???? ???????? ?????? ???????????? ?????????? ?????? [" + e.Row + "]?? \n Are you sure that you want to delete the line [" + e.Row + "]?", VarGeneral.ProdectNam, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        {
                            FlxPayment.SetData(e.Row, e.Col, false);
                        }
                        else if (!Convert.ToBoolean(FlxPayment.GetData(e.Row, 3).ToString()))
                        {
                            PaymentNo = int.Parse(FlxPayment.GetData(e.Row, 6).ToString());
                            Close();
                        }
                    }
                }
                catch
                {
                }
            }
            else
            {
                if (!Convert.ToBoolean(FlxPayment.GetData(e.Row, e.Col).ToString()))
                {
                    return;
                }
                try
                {
                    if (double.Parse(FlxPayment.GetData(e.Row, 1).ToString()) > 0.0 && VarGeneral.CheckDate(FlxPayment.GetData(e.Row, 2).ToString()))
                    {
                        if (MessageBox.Show("???? ?????? ?????????? ???? ?????? ?????????? [" + e.Row + "]?? \n Are you sure that you want to delete the line [" + e.Row + "]?", VarGeneral.ProdectNam, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        {
                            FlxPayment.SetData(e.Row, e.Col, false);
                        }
                        else if (!Convert.ToBoolean(FlxPayment.GetData(e.Row, 3).ToString()))
                        {
                            if (State == FormState.Saved)
                            {
                                Button_Edit_Click(sender, e);
                            }
                            FlxPayment.RemoveItem(e.Row);
                            if (!FrmTyp)
                            {
                                FlxPayment.Rows.Add();
                            }
                        }
                    }
                    else
                    {
                        FlxPayment.RemoveItem(e.Row);
                        if (!FrmTyp)
                        {
                            FlxPayment.Rows.Add();
                        }
                    }
                }
                catch
                {
                    FlxPayment.RemoveItem(e.Row);
                    if (!FrmTyp)
                    {
                        FlxPayment.Rows.Add();
                    }
                }
            }
        }
        private void txtRentOfYear_Leave(object sender, EventArgs e)
        {
            try
            {
                if (CmbTenanPayMethod.Enabled)
                {
                    CheckAqsat();
                }
            }
            catch
            {
            }
        }
    }
}
