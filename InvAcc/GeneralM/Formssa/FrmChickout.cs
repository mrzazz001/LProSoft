using C1.Win.C1FlexGrid;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
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
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial class FrmChickout : Form
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
        private Timer timer1;
        private SaveFileDialog saveFileDialog1;
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
        private PanelEx panelEx2;
        private RibbonBar ribbonBar1;
        private RibbonBar ribbonBar_Tasks;
        private SuperTabControl superTabControl_Main1;
        protected ButtonItem Button_Close;
        protected ButtonItem Button_GaidSerf;
        protected ButtonItem Button_GaidGabth;
        protected ButtonItem Button_Save;
        private Panel panel2;
        internal Label label6z;
        private MaskedTextBox txtDate;
        private TextBox txtGuestAcc;
        internal Label label5z;
        private TextBox txtRoom;
        internal Label label13z;
        private Label label1;
        private Label label2;
        private ComboBoxEx comboBox_RoomTyp;
        private ComboBoxEx Cmb_PayMethod;
        protected TextBox txtName;
        protected Label label36;
        private C1FlexGrid VS1;
        private C1FlexGrid VS;
        private Label label14z;
        private DoubleInput Label17;
        private Label label3;
        private DoubleInput Label15;
        private ComboBoxEx comboBox_DisTo;
        internal Label label12z;
        private ComboBoxEx comboBox_DisType;
        private Label label10z;
        private DoubleInput Label14;
        private Label label9z;
        private DoubleInput Text1;
        private Label label7z;
        private DoubleInput Label6;
        private DoubleInput Label12;
        private DoubleInput Label10;
        private DoubleInput Label19;
        private DoubleInput Label5;
        private DoubleInput Label8;
        private DoubleInput Label9;
        private DoubleInput Label11;
        private DoubleInput Label13;
        private DoubleInput Label16;
        private DoubleInput Label7;
        protected ButtonItem buttonItem_EditDays;
        private Label labelPercentage;
        private SwitchButton switchButton_Lock;
        private Panel panel_Gaid;
        private TextBoxX txtDebit1;
        private TextBoxX txtCredit1;
        internal Label labelD1;
        internal Label labelC1;
        private Label label4;
        private ComboBoxEx CmbCurr;
        private DoubleInput txtroomTot;
        protected Label label21;
        private DoubleInput txtroomDays;
        protected Label label20;
        private DoubleInput txtroomPrice;
        protected Label label18;
        private Panel panel3;
        internal Label label22;
        protected ButtonItem Button_GaidGabthAcc;
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
        private T_GDHEAD data_this;
        private T_Snd data_this_Snd;
        private List<string> pkeys = new List<string>();
        private Stock_DataDataContext dbInstance;
        private Rate_DataDataContext dbInstanceRate;
        private int R1;
        private int R2;
        private int R3;
        private int R4;
        private int Fin;
        private int M;
        private int Mm;
        private T_Rom RoomOp = new T_Rom();
        private T_per PerOp = new T_per();
        private double Tot = 0.0;
        private double TotResturant = 0.0;
        private T_GDHEAD _GdHead2 = new T_GDHEAD();
        private T_GDHEAD _GdHead = new T_GDHEAD();
        private List<T_GDHEAD> listGdHead = new List<T_GDHEAD>();
        private T_GDDET _GdDet = new T_GDDET();
        private List<T_GDDET> listGdDet = new List<T_GDDET>();
        private ScriptNumber ScriptNumber1 = new ScriptNumber();
        public Dictionary<string, ColumnDictinary> columns_Names_visible2 = new Dictionary<string, ColumnDictinary>();
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
            }
        }
        public bool IfDelete
        {
            set
            {
                Button_GaidGabth.Visible = value;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmChickout));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.timerInfoBallon = new System.Windows.Forms.Timer(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelEx2 = new DevComponents.DotNetBar.PanelEx();
            this.ribbonBar1 = new DevComponents.DotNetBar.RibbonBar();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.Label17 = new DevComponents.Editors.DoubleInput();
            this.label4 = new System.Windows.Forms.Label();
            this.CmbCurr = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelPercentage = new System.Windows.Forms.Label();
            this.Label15 = new DevComponents.Editors.DoubleInput();
            this.comboBox_DisTo = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label12z = new System.Windows.Forms.Label();
            this.label10z = new System.Windows.Forms.Label();
            this.Label14 = new DevComponents.Editors.DoubleInput();
            this.Text1 = new DevComponents.Editors.DoubleInput();
            this.label14z = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label9z = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.txtroomDays = new DevComponents.Editors.DoubleInput();
            this.label20 = new System.Windows.Forms.Label();
            this.txtroomPrice = new DevComponents.Editors.DoubleInput();
            this.label18 = new System.Windows.Forms.Label();
            this.switchButton_Lock = new DevComponents.DotNetBar.Controls.SwitchButton();
            this.panel_Gaid = new System.Windows.Forms.Panel();
            this.txtDebit1 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtCredit1 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelD1 = new System.Windows.Forms.Label();
            this.labelC1 = new System.Windows.Forms.Label();
            this.Label7 = new DevComponents.Editors.DoubleInput();
            this.Label16 = new DevComponents.Editors.DoubleInput();
            this.Label13 = new DevComponents.Editors.DoubleInput();
            this.Label11 = new DevComponents.Editors.DoubleInput();
            this.Label9 = new DevComponents.Editors.DoubleInput();
            this.Label8 = new DevComponents.Editors.DoubleInput();
            this.Label5 = new DevComponents.Editors.DoubleInput();
            this.Label19 = new DevComponents.Editors.DoubleInput();
            this.Label6 = new DevComponents.Editors.DoubleInput();
            this.Label12 = new DevComponents.Editors.DoubleInput();
            this.Label10 = new DevComponents.Editors.DoubleInput();
            this.label7z = new System.Windows.Forms.Label();
            this.comboBox_DisType = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.VS = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.label6z = new System.Windows.Forms.Label();
            this.txtGuestAcc = new System.Windows.Forms.TextBox();
            this.label5z = new System.Windows.Forms.Label();
            this.label13z = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox_RoomTyp = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.Cmb_PayMethod = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label36 = new System.Windows.Forms.Label();
            this.txtDate = new System.Windows.Forms.MaskedTextBox();
            this.txtRoom = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.VS1 = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.txtroomTot = new DevComponents.Editors.DoubleInput();
            this.label22 = new System.Windows.Forms.Label();
            this.ribbonBar_Tasks = new DevComponents.DotNetBar.RibbonBar();
            this.superTabControl_Main1 = new DevComponents.DotNetBar.SuperTabControl();
            this.Button_Close = new DevComponents.DotNetBar.ButtonItem();
            this.Button_GaidSerf = new DevComponents.DotNetBar.ButtonItem();
            this.Button_GaidGabth = new DevComponents.DotNetBar.ButtonItem();
            this.Button_Save = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem_EditDays = new DevComponents.DotNetBar.ButtonItem();
            this.Button_GaidGabthAcc = new DevComponents.DotNetBar.ButtonItem();
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
            this.panel1.SuspendLayout();
            this.panelEx2.SuspendLayout();
            this.ribbonBar1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Label17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Text1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtroomDays)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtroomPrice)).BeginInit();
            this.panel_Gaid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Label7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VS1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtroomTot)).BeginInit();
            this.ribbonBar_Tasks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl_Main1)).BeginInit();
            this.contextMenuStrip2.SuspendLayout();
            this.SuspendLayout();
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
            // panel1
            // 
            this.panel1.Controls.Add(this.panelEx2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(537, 433);
            this.panel1.TabIndex = 897;
            // 
            // panelEx2
            // 
            this.panelEx2.Controls.Add(this.ribbonBar1);
            this.panelEx2.Controls.Add(this.ribbonBar_Tasks);
            this.panelEx2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx2.Location = new System.Drawing.Point(0, 0);
            this.panelEx2.MinimumSize = new System.Drawing.Size(659, 228);
            this.panelEx2.Name = "panelEx2";
            this.panelEx2.Size = new System.Drawing.Size(659, 433);
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
            this.ribbonBar1.BackgroundStyle.BackColor = System.Drawing.Color.AliceBlue;
            this.ribbonBar1.BackgroundStyle.BackColor2 = System.Drawing.SystemColors.GradientActiveCaption;
            this.ribbonBar1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar1.ContainerControlProcessDialogKey = true;
            this.ribbonBar1.Controls.Add(this.panel2);
            this.ribbonBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonBar1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.ribbonBar1.Location = new System.Drawing.Point(0, 0);
            this.ribbonBar1.Name = "ribbonBar1";
            this.ribbonBar1.Size = new System.Drawing.Size(659, 382);
            this.ribbonBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this.ribbonBar1.TabIndex = 869;
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
            // panel2
            // 
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.label21);
            this.panel2.Controls.Add(this.txtroomDays);
            this.panel2.Controls.Add(this.label20);
            this.panel2.Controls.Add(this.txtroomPrice);
            this.panel2.Controls.Add(this.label18);
            this.panel2.Controls.Add(this.switchButton_Lock);
            this.panel2.Controls.Add(this.panel_Gaid);
            this.panel2.Controls.Add(this.Label7);
            this.panel2.Controls.Add(this.Label16);
            this.panel2.Controls.Add(this.Label13);
            this.panel2.Controls.Add(this.Label11);
            this.panel2.Controls.Add(this.Label9);
            this.panel2.Controls.Add(this.Label8);
            this.panel2.Controls.Add(this.Label5);
            this.panel2.Controls.Add(this.Label19);
            this.panel2.Controls.Add(this.Label6);
            this.panel2.Controls.Add(this.Label12);
            this.panel2.Controls.Add(this.Label10);
            this.panel2.Controls.Add(this.label7z);
            this.panel2.Controls.Add(this.comboBox_DisType);
            this.panel2.Controls.Add(this.VS);
            this.panel2.Controls.Add(this.label6z);
            this.panel2.Controls.Add(this.txtGuestAcc);
            this.panel2.Controls.Add(this.label5z);
            this.panel2.Controls.Add(this.label13z);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.comboBox_RoomTyp);
            this.panel2.Controls.Add(this.Cmb_PayMethod);
            this.panel2.Controls.Add(this.label36);
            this.panel2.Controls.Add(this.txtDate);
            this.panel2.Controls.Add(this.txtRoom);
            this.panel2.Controls.Add(this.txtName);
            this.panel2.Controls.Add(this.VS1);
            this.panel2.Controls.Add(this.txtroomTot);
            this.panel2.Controls.Add(this.label22);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(659, 365);
            this.panel2.TabIndex = 88;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.Label17);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.CmbCurr);
            this.panel3.Controls.Add(this.labelPercentage);
            this.panel3.Controls.Add(this.Label15);
            this.panel3.Controls.Add(this.comboBox_DisTo);
            this.panel3.Controls.Add(this.label12z);
            this.panel3.Controls.Add(this.label10z);
            this.panel3.Controls.Add(this.Label14);
            this.panel3.Controls.Add(this.Text1);
            this.panel3.Controls.Add(this.label14z);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label9z);
            this.panel3.Location = new System.Drawing.Point(13, 270);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(506, 87);
            this.panel3.TabIndex = 6763;
            // 
            // Label17
            // 
            this.Label17.AllowEmptyState = false;
            // 
            // 
            // 
            this.Label17.BackgroundStyle.Class = "DateTimeInputBackground";
            this.Label17.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Label17.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.Label17.DisplayFormat = "0.00";
            this.Label17.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Label17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Label17.Increment = 0D;
            this.Label17.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.Label17.IsInputReadOnly = true;
            this.Label17.Location = new System.Drawing.Point(6, 60);
            this.Label17.Name = "Label17";
            this.Label17.Size = new System.Drawing.Size(420, 21);
            this.Label17.TabIndex = 6731;
            this.Label17.ValueChanged += new System.EventHandler(this.Label17_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(166, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 13);
            this.label4.TabIndex = 6753;
            this.label4.Text = "العملـــــــــة :";
            this.label4.Visible = false;
            // 
            // CmbCurr
            // 
            this.CmbCurr.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbCurr.DisplayMember = "Text";
            this.CmbCurr.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.CmbCurr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbCurr.FormattingEnabled = true;
            this.CmbCurr.ItemHeight = 14;
            this.CmbCurr.Location = new System.Drawing.Point(5, 60);
            this.CmbCurr.Name = "CmbCurr";
            this.CmbCurr.Size = new System.Drawing.Size(158, 20);
            this.CmbCurr.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.CmbCurr.TabIndex = 6752;
            this.CmbCurr.Visible = false;
            // 
            // labelPercentage
            // 
            this.labelPercentage.AutoSize = true;
            this.labelPercentage.BackColor = System.Drawing.Color.Transparent;
            this.labelPercentage.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelPercentage.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelPercentage.Location = new System.Drawing.Point(262, 10);
            this.labelPercentage.Name = "labelPercentage";
            this.labelPercentage.Size = new System.Drawing.Size(20, 13);
            this.labelPercentage.TabIndex = 6749;
            this.labelPercentage.Text = "%";
            this.labelPercentage.Visible = false;
            // 
            // Label15
            // 
            this.Label15.AllowEmptyState = false;
            // 
            // 
            // 
            this.Label15.BackgroundStyle.Class = "DateTimeInputBackground";
            this.Label15.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Label15.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.Label15.DisplayFormat = "0.00";
            this.Label15.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Label15.Increment = 0D;
            this.Label15.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.Label15.IsInputReadOnly = true;
            this.Label15.Location = new System.Drawing.Point(286, 33);
            this.Label15.Name = "Label15";
            this.Label15.Size = new System.Drawing.Size(140, 21);
            this.Label15.TabIndex = 6730;
            // 
            // comboBox_DisTo
            // 
            this.comboBox_DisTo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox_DisTo.DisplayMember = "Text";
            this.comboBox_DisTo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBox_DisTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.comboBox_DisTo.Enabled = false;
            this.comboBox_DisTo.FormattingEnabled = true;
            this.comboBox_DisTo.ItemHeight = 14;
            this.comboBox_DisTo.Location = new System.Drawing.Point(6, 6);
            this.comboBox_DisTo.Name = "comboBox_DisTo";
            this.comboBox_DisTo.Size = new System.Drawing.Size(140, 21);
            this.comboBox_DisTo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBox_DisTo.TabIndex = 6728;
            // 
            // label12z
            // 
            this.label12z.AutoSize = true;
            this.label12z.BackColor = System.Drawing.Color.Transparent;
            this.label12z.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label12z.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label12z.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label12z.Location = new System.Drawing.Point(149, 10);
            this.label12z.Name = "label12z";
            this.label12z.Size = new System.Drawing.Size(66, 13);
            this.label12z.TabIndex = 6734;
            this.label12z.Text = "خصم على :";
            // 
            // label10z
            // 
            this.label10z.AutoSize = true;
            this.label10z.BackColor = System.Drawing.Color.Transparent;
            this.label10z.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label10z.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label10z.Location = new System.Drawing.Point(149, 37);
            this.label10z.Name = "label10z";
            this.label10z.Size = new System.Drawing.Size(73, 13);
            this.label10z.TabIndex = 6733;
            this.label10z.Text = "الإجمالــــي :";
            // 
            // Label14
            // 
            this.Label14.AllowEmptyState = false;
            // 
            // 
            // 
            this.Label14.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
            this.Label14.BackgroundStyle.Class = "DateTimeInputBackground";
            this.Label14.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Label14.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.Label14.DisplayFormat = "0.00";
            this.Label14.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Label14.Increment = 0D;
            this.Label14.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.Label14.IsInputReadOnly = true;
            this.Label14.Location = new System.Drawing.Point(6, 33);
            this.Label14.Name = "Label14";
            this.Label14.Size = new System.Drawing.Size(140, 21);
            this.Label14.TabIndex = 6729;
            // 
            // Text1
            // 
            this.Text1.AllowEmptyState = false;
            // 
            // 
            // 
            this.Text1.BackgroundStyle.Class = "DateTimeInputBackground";
            this.Text1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Text1.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.Text1.DisplayFormat = "0.00";
            this.Text1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Text1.Increment = 0D;
            this.Text1.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.Text1.IsInputReadOnly = true;
            this.Text1.Location = new System.Drawing.Point(286, 6);
            this.Text1.Name = "Text1";
            this.Text1.Size = new System.Drawing.Size(140, 21);
            this.Text1.TabIndex = 6727;
            // 
            // label14z
            // 
            this.label14z.AutoSize = true;
            this.label14z.BackColor = System.Drawing.Color.Transparent;
            this.label14z.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label14z.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label14z.Location = new System.Drawing.Point(428, 64);
            this.label14z.Name = "label14z";
            this.label14z.Size = new System.Drawing.Size(67, 13);
            this.label14z.TabIndex = 6736;
            this.label14z.Text = "الصــــافي :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(428, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 6735;
            this.label3.Text = "المدفوعات :";
            // 
            // label9z
            // 
            this.label9z.AutoSize = true;
            this.label9z.BackColor = System.Drawing.Color.Transparent;
            this.label9z.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label9z.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label9z.Location = new System.Drawing.Point(428, 10);
            this.label9z.Name = "label9z";
            this.label9z.Size = new System.Drawing.Size(66, 13);
            this.label9z.TabIndex = 6732;
            this.label9z.Text = "الخصــــــم :";
            // 
            // label21
            // 
            this.label21.BackColor = System.Drawing.Color.Gainsboro;
            this.label21.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label21.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label21.ForeColor = System.Drawing.Color.Red;
            this.label21.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label21.Location = new System.Drawing.Point(12, 217);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(158, 21);
            this.label21.TabIndex = 6761;
            this.label21.Text = "إجمالي فترة الإقامة";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtroomDays
            // 
            this.txtroomDays.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtroomDays.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtroomDays.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtroomDays.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtroomDays.DisplayFormat = "0.00";
            this.txtroomDays.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtroomDays.Increment = 0D;
            this.txtroomDays.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtroomDays.IsInputReadOnly = true;
            this.txtroomDays.Location = new System.Drawing.Point(186, 241);
            this.txtroomDays.MinValue = 0D;
            this.txtroomDays.Name = "txtroomDays";
            this.txtroomDays.Size = new System.Drawing.Size(158, 21);
            this.txtroomDays.TabIndex = 6760;
            // 
            // label20
            // 
            this.label20.BackColor = System.Drawing.Color.Transparent;
            this.label20.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label20.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label20.ForeColor = System.Drawing.Color.Red;
            this.label20.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label20.Location = new System.Drawing.Point(186, 217);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(158, 21);
            this.label20.TabIndex = 6759;
            this.label20.Text = "أيام السكن";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtroomPrice
            // 
            this.txtroomPrice.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtroomPrice.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtroomPrice.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtroomPrice.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtroomPrice.DisplayFormat = "0.00";
            this.txtroomPrice.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtroomPrice.Increment = 0D;
            this.txtroomPrice.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtroomPrice.IsInputReadOnly = true;
            this.txtroomPrice.Location = new System.Drawing.Point(360, 241);
            this.txtroomPrice.MinValue = 0D;
            this.txtroomPrice.Name = "txtroomPrice";
            this.txtroomPrice.Size = new System.Drawing.Size(158, 21);
            this.txtroomPrice.TabIndex = 6758;
            // 
            // label18
            // 
            this.label18.BackColor = System.Drawing.Color.Transparent;
            this.label18.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label18.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label18.ForeColor = System.Drawing.Color.Red;
            this.label18.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label18.Location = new System.Drawing.Point(360, 217);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(158, 21);
            this.label18.TabIndex = 6755;
            this.label18.Text = "سعر الغرفة";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // switchButton_Lock
            // 
            // 
            // 
            // 
            this.switchButton_Lock.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.switchButton_Lock.Font = new System.Drawing.Font("Tahoma", 8F);
            this.switchButton_Lock.Location = new System.Drawing.Point(283, 379);
            this.switchButton_Lock.Name = "switchButton_Lock";
            this.switchButton_Lock.OffBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(80)))), ((int)(((byte)(77)))));
            this.switchButton_Lock.OffText = "إنشاء قيد محاسبي";
            this.switchButton_Lock.OffTextColor = System.Drawing.Color.White;
            this.switchButton_Lock.OnBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.switchButton_Lock.OnText = "إنشاء قيد محاسبي";
            this.switchButton_Lock.OnTextColor = System.Drawing.Color.White;
            this.switchButton_Lock.Size = new System.Drawing.Size(236, 26);
            this.switchButton_Lock.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.switchButton_Lock.SwitchWidth = 50;
            this.switchButton_Lock.TabIndex = 6751;
            this.switchButton_Lock.Visible = false;
            this.switchButton_Lock.ValueChanged += new System.EventHandler(this.switchButton_Lock_ValueChanged);
            // 
            // panel_Gaid
            // 
            this.panel_Gaid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_Gaid.Controls.Add(this.txtDebit1);
            this.panel_Gaid.Controls.Add(this.txtCredit1);
            this.panel_Gaid.Controls.Add(this.labelD1);
            this.panel_Gaid.Controls.Add(this.labelC1);
            this.panel_Gaid.Enabled = false;
            this.panel_Gaid.Location = new System.Drawing.Point(13, 372);
            this.panel_Gaid.Name = "panel_Gaid";
            this.panel_Gaid.Size = new System.Drawing.Size(506, 55);
            this.panel_Gaid.TabIndex = 6750;
            this.panel_Gaid.Visible = false;
            // 
            // txtDebit1
            // 
            this.txtDebit1.BackColor = System.Drawing.SystemColors.Control;
            // 
            // 
            // 
            this.txtDebit1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDebit1.ButtonCustom.Visible = true;
            this.txtDebit1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.txtDebit1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtDebit1.Location = new System.Drawing.Point(265, 24);
            this.txtDebit1.Name = "txtDebit1";
            this.txtDebit1.ReadOnly = true;
            this.txtDebit1.Size = new System.Drawing.Size(179, 16);
            this.txtDebit1.TabIndex = 1130;
            this.txtDebit1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDebit1.ButtonCustomClick += new System.EventHandler(this.txtDebit1_ButtonCustomClick);
            // 
            // txtCredit1
            // 
            this.txtCredit1.BackColor = System.Drawing.SystemColors.Control;
            // 
            // 
            // 
            this.txtCredit1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtCredit1.ButtonCustom.Visible = true;
            this.txtCredit1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.txtCredit1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtCredit1.Location = new System.Drawing.Point(24, 24);
            this.txtCredit1.Name = "txtCredit1";
            this.txtCredit1.ReadOnly = true;
            this.txtCredit1.Size = new System.Drawing.Size(179, 16);
            this.txtCredit1.TabIndex = 1131;
            this.txtCredit1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCredit1.ButtonCustomClick += new System.EventHandler(this.txtCredit1_ButtonCustomClick);
            // 
            // labelD1
            // 
            this.labelD1.AutoSize = true;
            this.labelD1.BackColor = System.Drawing.Color.Transparent;
            this.labelD1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelD1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.labelD1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelD1.Location = new System.Drawing.Point(441, 26);
            this.labelD1.Name = "labelD1";
            this.labelD1.Size = new System.Drawing.Size(44, 13);
            this.labelD1.TabIndex = 1128;
            this.labelD1.Text = "المدين :";
            // 
            // labelC1
            // 
            this.labelC1.AutoSize = true;
            this.labelC1.BackColor = System.Drawing.Color.Transparent;
            this.labelC1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelC1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.labelC1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelC1.Location = new System.Drawing.Point(201, 26);
            this.labelC1.Name = "labelC1";
            this.labelC1.Size = new System.Drawing.Size(40, 13);
            this.labelC1.TabIndex = 1129;
            this.labelC1.Text = "الدائن :";
            // 
            // Label7
            // 
            this.Label7.AllowEmptyState = false;
            this.Label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.Label7.BackgroundStyle.Class = "DateTimeInputBackground";
            this.Label7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Label7.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.Label7.DisplayFormat = "0.00";
            this.Label7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Label7.Increment = 0D;
            this.Label7.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.Label7.IsInputReadOnly = true;
            this.Label7.Location = new System.Drawing.Point(428, 529);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(83, 21);
            this.Label7.TabIndex = 6748;
            this.Label7.Visible = false;
            // 
            // Label16
            // 
            this.Label16.AllowEmptyState = false;
            this.Label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.Label16.BackgroundStyle.Class = "DateTimeInputBackground";
            this.Label16.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Label16.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.Label16.DisplayFormat = "0.00";
            this.Label16.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Label16.Increment = 0D;
            this.Label16.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.Label16.IsInputReadOnly = true;
            this.Label16.Location = new System.Drawing.Point(11, 531);
            this.Label16.Name = "Label16";
            this.Label16.Size = new System.Drawing.Size(83, 21);
            this.Label16.TabIndex = 6747;
            this.Label16.Visible = false;
            // 
            // Label13
            // 
            this.Label13.AllowEmptyState = false;
            this.Label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.Label13.BackgroundStyle.Class = "DateTimeInputBackground";
            this.Label13.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Label13.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.Label13.DisplayFormat = "0.00";
            this.Label13.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Label13.Increment = 0D;
            this.Label13.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.Label13.IsInputReadOnly = true;
            this.Label13.Location = new System.Drawing.Point(340, 529);
            this.Label13.Name = "Label13";
            this.Label13.Size = new System.Drawing.Size(83, 21);
            this.Label13.TabIndex = 6746;
            this.Label13.Visible = false;
            // 
            // Label11
            // 
            this.Label11.AllowEmptyState = false;
            this.Label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.Label11.BackgroundStyle.Class = "DateTimeInputBackground";
            this.Label11.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Label11.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.Label11.DisplayFormat = "0.00";
            this.Label11.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Label11.Increment = 0D;
            this.Label11.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.Label11.IsInputReadOnly = true;
            this.Label11.Location = new System.Drawing.Point(100, 529);
            this.Label11.Name = "Label11";
            this.Label11.Size = new System.Drawing.Size(83, 21);
            this.Label11.TabIndex = 6745;
            this.Label11.Visible = false;
            // 
            // Label9
            // 
            this.Label9.AllowEmptyState = false;
            this.Label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.Label9.BackgroundStyle.Class = "DateTimeInputBackground";
            this.Label9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Label9.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.Label9.DisplayFormat = "0.00";
            this.Label9.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Label9.Increment = 0D;
            this.Label9.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.Label9.IsInputReadOnly = true;
            this.Label9.Location = new System.Drawing.Point(206, 529);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(83, 21);
            this.Label9.TabIndex = 6744;
            this.Label9.Visible = false;
            // 
            // Label8
            // 
            this.Label8.AllowEmptyState = false;
            this.Label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.Label8.BackgroundStyle.Class = "DateTimeInputBackground";
            this.Label8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Label8.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.Label8.DisplayFormat = "0.00";
            this.Label8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Label8.Increment = 0D;
            this.Label8.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.Label8.IsInputReadOnly = true;
            this.Label8.Location = new System.Drawing.Point(204, 556);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(83, 21);
            this.Label8.TabIndex = 6743;
            this.Label8.Visible = false;
            // 
            // Label5
            // 
            this.Label5.AllowEmptyState = false;
            this.Label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.Label5.BackgroundStyle.Class = "DateTimeInputBackground";
            this.Label5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Label5.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.Label5.DisplayFormat = "0.00";
            this.Label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Label5.Increment = 0D;
            this.Label5.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.Label5.IsInputReadOnly = true;
            this.Label5.Location = new System.Drawing.Point(26, 558);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(83, 21);
            this.Label5.TabIndex = 6742;
            this.Label5.Visible = false;
            // 
            // Label19
            // 
            this.Label19.AllowEmptyState = false;
            this.Label19.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.Label19.BackgroundStyle.Class = "DateTimeInputBackground";
            this.Label19.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Label19.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.Label19.DisplayFormat = "0.00";
            this.Label19.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Label19.Increment = 0D;
            this.Label19.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.Label19.IsInputReadOnly = true;
            this.Label19.Location = new System.Drawing.Point(261, 525);
            this.Label19.Name = "Label19";
            this.Label19.Size = new System.Drawing.Size(83, 21);
            this.Label19.TabIndex = 6741;
            this.Label19.Visible = false;
            // 
            // Label6
            // 
            this.Label6.AllowEmptyState = false;
            this.Label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.Label6.BackgroundStyle.Class = "DateTimeInputBackground";
            this.Label6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Label6.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.Label6.DisplayFormat = "0.00";
            this.Label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Label6.Increment = 0D;
            this.Label6.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.Label6.IsInputReadOnly = true;
            this.Label6.Location = new System.Drawing.Point(429, 558);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(83, 21);
            this.Label6.TabIndex = 6740;
            this.Label6.Visible = false;
            // 
            // Label12
            // 
            this.Label12.AllowEmptyState = false;
            this.Label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.Label12.BackgroundStyle.Class = "DateTimeInputBackground";
            this.Label12.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Label12.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.Label12.DisplayFormat = "0.00";
            this.Label12.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Label12.Increment = 0D;
            this.Label12.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.Label12.IsInputReadOnly = true;
            this.Label12.Location = new System.Drawing.Point(115, 556);
            this.Label12.Name = "Label12";
            this.Label12.Size = new System.Drawing.Size(83, 21);
            this.Label12.TabIndex = 6739;
            this.Label12.Visible = false;
            // 
            // Label10
            // 
            this.Label10.AllowEmptyState = false;
            this.Label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.Label10.BackgroundStyle.Class = "DateTimeInputBackground";
            this.Label10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Label10.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.Label10.DisplayFormat = "0.00";
            this.Label10.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Label10.Increment = 0D;
            this.Label10.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.Label10.IsInputReadOnly = true;
            this.Label10.Location = new System.Drawing.Point(340, 560);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(83, 21);
            this.Label10.TabIndex = 6738;
            this.Label10.Visible = false;
            // 
            // label7z
            // 
            this.label7z.AutoSize = true;
            this.label7z.BackColor = System.Drawing.Color.Transparent;
            this.label7z.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label7z.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7z.Location = new System.Drawing.Point(-93, 301);
            this.label7z.Name = "label7z";
            this.label7z.Size = new System.Drawing.Size(48, 13);
            this.label7z.TabIndex = 6737;
            this.label7z.Text = "الخصم :";
            this.label7z.Visible = false;
            // 
            // comboBox_DisType
            // 
            this.comboBox_DisType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox_DisType.DisplayMember = "Text";
            this.comboBox_DisType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBox_DisType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.comboBox_DisType.Enabled = false;
            this.comboBox_DisType.FormattingEnabled = true;
            this.comboBox_DisType.ItemHeight = 14;
            this.comboBox_DisType.Location = new System.Drawing.Point(-199, 297);
            this.comboBox_DisType.Name = "comboBox_DisType";
            this.comboBox_DisType.Size = new System.Drawing.Size(104, 20);
            this.comboBox_DisType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBox_DisType.TabIndex = 6726;
            this.comboBox_DisType.Visible = false;
            this.comboBox_DisType.SelectedIndexChanged += new System.EventHandler(this.comboBox_DisType_SelectedIndexChanged);
            // 
            // VS
            // 
            this.VS.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None;
            this.VS.AllowEditing = false;
            this.VS.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None;
            this.VS.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
            this.VS.ColumnInfo = resources.GetString("VS.ColumnInfo");
            this.VS.ExtendLastCol = true;
            this.VS.Font = new System.Drawing.Font("Tahoma", 8F);
            this.VS.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.VS.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross;
            this.VS.Location = new System.Drawing.Point(13, 135);
            this.VS.Name = "VS";
            this.VS.Rows.Count = 6;
            this.VS.Rows.DefaultSize = 19;
            this.VS.Rows.MinSize = 22;
            this.VS.ShowSortPosition = C1.Win.C1FlexGrid.ShowSortPositionEnum.None;
            this.VS.Size = new System.Drawing.Size(506, 70);
            this.VS.StyleInfo = resources.GetString("VS.StyleInfo");
            this.VS.TabIndex = 1104;
            this.VS.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Blue;
            // 
            // label6z
            // 
            this.label6z.AutoSize = true;
            this.label6z.BackColor = System.Drawing.Color.Transparent;
            this.label6z.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label6z.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label6z.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6z.Location = new System.Drawing.Point(449, 77);
            this.label6z.Name = "label6z";
            this.label6z.Size = new System.Drawing.Size(70, 13);
            this.label6z.TabIndex = 1101;
            this.label6z.Text = "تاريخ السكن :";
            // 
            // txtGuestAcc
            // 
            this.txtGuestAcc.BackColor = System.Drawing.Color.White;
            this.txtGuestAcc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtGuestAcc.Location = new System.Drawing.Point(13, 73);
            this.txtGuestAcc.MaxLength = 30;
            this.txtGuestAcc.Name = "txtGuestAcc";
            this.txtGuestAcc.ReadOnly = true;
            this.txtGuestAcc.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtGuestAcc.Size = new System.Drawing.Size(150, 20);
            this.txtGuestAcc.TabIndex = 1098;
            this.txtGuestAcc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5z
            // 
            this.label5z.AutoSize = true;
            this.label5z.BackColor = System.Drawing.Color.Transparent;
            this.label5z.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label5z.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label5z.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5z.Location = new System.Drawing.Point(165, 77);
            this.label5z.Name = "label5z";
            this.label5z.Size = new System.Drawing.Size(74, 13);
            this.label5z.TabIndex = 1099;
            this.label5z.Text = "حساب النزيل :";
            // 
            // label13z
            // 
            this.label13z.AutoSize = true;
            this.label13z.BackColor = System.Drawing.Color.Transparent;
            this.label13z.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label13z.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label13z.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label13z.Location = new System.Drawing.Point(452, 19);
            this.label13z.Name = "label13z";
            this.label13z.Size = new System.Drawing.Size(62, 13);
            this.label13z.TabIndex = 1097;
            this.label13z.Text = "رقم الغرفة :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(-120, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 986;
            this.label1.Text = "نوع التسكين :";
            this.label1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(165, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 984;
            this.label2.Text = "طريقة الدفع :";
            // 
            // comboBox_RoomTyp
            // 
            this.comboBox_RoomTyp.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox_RoomTyp.DisplayMember = "Text";
            this.comboBox_RoomTyp.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBox_RoomTyp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.comboBox_RoomTyp.Enabled = false;
            this.comboBox_RoomTyp.FocusHighlightColor = System.Drawing.Color.Empty;
            this.comboBox_RoomTyp.FormattingEnabled = true;
            this.comboBox_RoomTyp.ItemHeight = 15;
            this.comboBox_RoomTyp.Location = new System.Drawing.Point(-272, 105);
            this.comboBox_RoomTyp.Name = "comboBox_RoomTyp";
            this.comboBox_RoomTyp.Size = new System.Drawing.Size(150, 21);
            this.comboBox_RoomTyp.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBox_RoomTyp.TabIndex = 985;
            this.comboBox_RoomTyp.Visible = false;
            // 
            // Cmb_PayMethod
            // 
            this.Cmb_PayMethod.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.Cmb_PayMethod.DisplayMember = "Text";
            this.Cmb_PayMethod.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.Cmb_PayMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cmb_PayMethod.FocusHighlightColor = System.Drawing.Color.Empty;
            this.Cmb_PayMethod.FormattingEnabled = true;
            this.Cmb_PayMethod.ItemHeight = 15;
            this.Cmb_PayMethod.Location = new System.Drawing.Point(13, 15);
            this.Cmb_PayMethod.Name = "Cmb_PayMethod";
            this.Cmb_PayMethod.Size = new System.Drawing.Size(150, 21);
            this.Cmb_PayMethod.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.Cmb_PayMethod.TabIndex = 983;
            this.Cmb_PayMethod.SelectedIndexChanged += new System.EventHandler(this.Cmb_PayMethod_SelectedIndexChanged);
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.BackColor = System.Drawing.Color.Transparent;
            this.label36.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label36.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label36.Location = new System.Drawing.Point(453, 48);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(65, 13);
            this.label36.TabIndex = 90;
            this.label36.Text = "إسم النزيل :";
            // 
            // txtDate
            // 
            this.txtDate.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtDate.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.txtDate.Location = new System.Drawing.Point(322, 73);
            this.txtDate.Mask = "0000/00/00";
            this.txtDate.Name = "txtDate";
            this.txtDate.ReadOnly = true;
            this.txtDate.Size = new System.Drawing.Size(124, 21);
            this.txtDate.TabIndex = 1100;
            this.txtDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtRoom
            // 
            this.txtRoom.BackColor = System.Drawing.Color.White;
            this.txtRoom.Location = new System.Drawing.Point(355, 15);
            this.txtRoom.MaxLength = 100;
            this.txtRoom.Name = "txtRoom";
            this.txtRoom.ReadOnly = true;
            this.txtRoom.Size = new System.Drawing.Size(91, 20);
            this.txtRoom.TabIndex = 1096;
            // 
            // txtName
            // 
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.Font = new System.Drawing.Font("Tahoma", 8F);
            this.txtName.ForeColor = System.Drawing.Color.Black;
            this.txtName.Location = new System.Drawing.Point(13, 44);
            this.txtName.MaxLength = 30;
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(433, 20);
            this.txtName.TabIndex = 87;
            // 
            // VS1
            // 
            this.VS1.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None;
            this.VS1.AllowEditing = false;
            this.VS1.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None;
            this.VS1.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
            this.VS1.ColumnInfo = resources.GetString("VS1.ColumnInfo");
            this.VS1.ExtendLastCol = true;
            this.VS1.Font = new System.Drawing.Font("Tahoma", 8F);
            this.VS1.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.VS1.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross;
            this.VS1.Location = new System.Drawing.Point(13, 158);
            this.VS1.Name = "VS1";
            this.VS1.Rows.Count = 1;
            this.VS1.Rows.DefaultSize = 19;
            this.VS1.Rows.MaxSize = 17;
            this.VS1.ShowSortPosition = C1.Win.C1FlexGrid.ShowSortPositionEnum.None;
            this.VS1.Size = new System.Drawing.Size(506, 38);
            this.VS1.StyleInfo = resources.GetString("VS1.StyleInfo");
            this.VS1.TabIndex = 1103;
            this.VS1.Visible = false;
            this.VS1.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Blue;
            // 
            // txtroomTot
            // 
            this.txtroomTot.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtroomTot.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtroomTot.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtroomTot.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtroomTot.DisplayFormat = "0.00";
            this.txtroomTot.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtroomTot.Increment = 0D;
            this.txtroomTot.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtroomTot.IsInputReadOnly = true;
            this.txtroomTot.Location = new System.Drawing.Point(12, 241);
            this.txtroomTot.MinValue = 0D;
            this.txtroomTot.Name = "txtroomTot";
            this.txtroomTot.Size = new System.Drawing.Size(158, 21);
            this.txtroomTot.TabIndex = 6762;
            // 
            // label22
            // 
            this.label22.BackColor = System.Drawing.Color.Maroon;
            this.label22.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label22.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label22.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label22.ForeColor = System.Drawing.Color.White;
            this.label22.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label22.Location = new System.Drawing.Point(12, 103);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(506, 29);
            this.label22.TabIndex = 6765;
            this.label22.Text = "تفـــاصيـــــل حســــاب النزيـــــل";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.ribbonBar_Tasks.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ribbonBar_Tasks.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.ribbonBar_Tasks.Location = new System.Drawing.Point(0, 382);
            this.ribbonBar_Tasks.Name = "ribbonBar_Tasks";
            this.ribbonBar_Tasks.Size = new System.Drawing.Size(659, 51);
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
            this.superTabControl_Main1.Size = new System.Drawing.Size(659, 51);
            this.superTabControl_Main1.TabFont = new System.Drawing.Font("Tahoma", 8F);
            this.superTabControl_Main1.TabIndex = 10;
            this.superTabControl_Main1.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.Button_Close,
            this.Button_GaidSerf,
            this.Button_GaidGabth,
            this.Button_Save,
            this.buttonItem_EditDays,
            this.Button_GaidGabthAcc});
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
            this.Button_Close.Click += new System.EventHandler(this.Button_Close_Click);
            // 
            // Button_GaidSerf
            // 
            this.Button_GaidSerf.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.Button_GaidSerf.FontBold = true;
            this.Button_GaidSerf.FontItalic = true;
            this.Button_GaidSerf.ForeColor = System.Drawing.Color.Teal;
            this.Button_GaidSerf.Image = ((System.Drawing.Image)(resources.GetObject("Button_GaidSerf.Image")));
            this.Button_GaidSerf.ImageFixedSize = new System.Drawing.Size(28, 28);
            this.Button_GaidSerf.ImagePaddingHorizontal = 15;
            this.Button_GaidSerf.ImagePaddingVertical = 11;
            this.Button_GaidSerf.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.Button_GaidSerf.Name = "Button_GaidSerf";
            this.Button_GaidSerf.Stretch = true;
            this.Button_GaidSerf.SubItemsExpandWidth = 14;
            this.Button_GaidSerf.Symbol = "";
            this.Button_GaidSerf.SymbolSize = 15F;
            this.Button_GaidSerf.Text = "سند صرف نزيل";
            this.Button_GaidSerf.Click += new System.EventHandler(this.Button_GaidSerf_Click);
            // 
            // Button_GaidGabth
            // 
            this.Button_GaidGabth.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.Button_GaidGabth.FontBold = true;
            this.Button_GaidGabth.FontItalic = true;
            this.Button_GaidGabth.ForeColor = System.Drawing.Color.SteelBlue;
            this.Button_GaidGabth.Image = ((System.Drawing.Image)(resources.GetObject("Button_GaidGabth.Image")));
            this.Button_GaidGabth.ImageFixedSize = new System.Drawing.Size(28, 28);
            this.Button_GaidGabth.ImagePaddingHorizontal = 15;
            this.Button_GaidGabth.ImagePaddingVertical = 11;
            this.Button_GaidGabth.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.Button_GaidGabth.Name = "Button_GaidGabth";
            this.Button_GaidGabth.Stretch = true;
            this.Button_GaidGabth.SubItemsExpandWidth = 14;
            this.Button_GaidGabth.Symbol = "";
            this.Button_GaidGabth.SymbolSize = 15F;
            this.Button_GaidGabth.Text = "سند قبض نزيل";
            this.Button_GaidGabth.Click += new System.EventHandler(this.Button_GaidGabth_Click);
            // 
            // Button_Save
            // 
            this.Button_Save.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.Button_Save.Enabled = false;
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
            this.Button_Save.Text = "مغادرة";
            this.Button_Save.Click += new System.EventHandler(this.Button_Save_Click);
            // 
            // buttonItem_EditDays
            // 
            this.buttonItem_EditDays.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonItem_EditDays.FontBold = true;
            this.buttonItem_EditDays.FontItalic = true;
            this.buttonItem_EditDays.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.buttonItem_EditDays.Image = ((System.Drawing.Image)(resources.GetObject("buttonItem_EditDays.Image")));
            this.buttonItem_EditDays.ImageFixedSize = new System.Drawing.Size(28, 28);
            this.buttonItem_EditDays.ImagePaddingHorizontal = 15;
            this.buttonItem_EditDays.ImagePaddingVertical = 11;
            this.buttonItem_EditDays.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.buttonItem_EditDays.Name = "buttonItem_EditDays";
            this.buttonItem_EditDays.Stretch = true;
            this.buttonItem_EditDays.SubItemsExpandWidth = 14;
            this.buttonItem_EditDays.Symbol = "";
            this.buttonItem_EditDays.SymbolSize = 15F;
            this.buttonItem_EditDays.Text = "تعديل عدد أيام الإقامة";
            this.buttonItem_EditDays.Click += new System.EventHandler(this.buttonItem_EditDays_Click);
            // 
            // Button_GaidGabthAcc
            // 
            this.Button_GaidGabthAcc.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.Button_GaidGabthAcc.Checked = true;
            this.Button_GaidGabthAcc.FontBold = true;
            this.Button_GaidGabthAcc.FontItalic = true;
            this.Button_GaidGabthAcc.ForeColor = System.Drawing.Color.SteelBlue;
            this.Button_GaidGabthAcc.Image = ((System.Drawing.Image)(resources.GetObject("Button_GaidGabthAcc.Image")));
            this.Button_GaidGabthAcc.ImageFixedSize = new System.Drawing.Size(28, 28);
            this.Button_GaidGabthAcc.ImagePaddingHorizontal = 15;
            this.Button_GaidGabthAcc.ImagePaddingVertical = 11;
            this.Button_GaidGabthAcc.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.Button_GaidGabthAcc.Name = "Button_GaidGabthAcc";
            this.Button_GaidGabthAcc.Stretch = true;
            this.Button_GaidGabthAcc.SubItemsExpandWidth = 14;
            this.Button_GaidGabthAcc.Symbol = "";
            this.Button_GaidGabthAcc.SymbolSize = 15F;
            this.Button_GaidGabthAcc.Text = "قبض محاسبي";
            this.Button_GaidGabthAcc.Visible = false;
            this.Button_GaidGabthAcc.Click += new System.EventHandler(this.Button_GaidGabthAcc_Click);
            // 
            // barTopDockSite
            // 
            this.barTopDockSite.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.barTopDockSite.Dock = System.Windows.Forms.DockStyle.Top;
            this.barTopDockSite.DocumentDockContainer = new DevComponents.DotNetBar.DocumentDockContainer();
            this.barTopDockSite.Location = new System.Drawing.Point(0, 0);
            this.barTopDockSite.Name = "barTopDockSite";
            this.barTopDockSite.Size = new System.Drawing.Size(537, 0);
            this.barTopDockSite.TabIndex = 889;
            this.barTopDockSite.TabStop = false;
            // 
            // barBottomDockSite
            // 
            this.barBottomDockSite.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.barBottomDockSite.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barBottomDockSite.DocumentDockContainer = new DevComponents.DotNetBar.DocumentDockContainer();
            this.barBottomDockSite.Location = new System.Drawing.Point(0, 433);
            this.barBottomDockSite.Name = "barBottomDockSite";
            this.barBottomDockSite.Size = new System.Drawing.Size(537, 0);
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
            this.barLeftDockSite.Size = new System.Drawing.Size(0, 433);
            this.barLeftDockSite.TabIndex = 891;
            this.barLeftDockSite.TabStop = false;
            // 
            // barRightDockSite
            // 
            this.barRightDockSite.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.barRightDockSite.Dock = System.Windows.Forms.DockStyle.Right;
            this.barRightDockSite.DocumentDockContainer = new DevComponents.DotNetBar.DocumentDockContainer();
            this.barRightDockSite.Location = new System.Drawing.Point(537, 0);
            this.barRightDockSite.Name = "barRightDockSite";
            this.barRightDockSite.Size = new System.Drawing.Size(0, 433);
            this.barRightDockSite.TabIndex = 892;
            this.barRightDockSite.TabStop = false;
            // 
            // dockSite4
            // 
            this.dockSite4.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dockSite4.Location = new System.Drawing.Point(0, 433);
            this.dockSite4.Name = "dockSite4";
            this.dockSite4.Size = new System.Drawing.Size(537, 0);
            this.dockSite4.TabIndex = 896;
            this.dockSite4.TabStop = false;
            // 
            // dockSite1
            // 
            this.dockSite1.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite1.Dock = System.Windows.Forms.DockStyle.Left;
            this.dockSite1.Location = new System.Drawing.Point(0, 0);
            this.dockSite1.Name = "dockSite1";
            this.dockSite1.Size = new System.Drawing.Size(0, 433);
            this.dockSite1.TabIndex = 893;
            this.dockSite1.TabStop = false;
            // 
            // dockSite2
            // 
            this.dockSite2.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite2.Dock = System.Windows.Forms.DockStyle.Right;
            this.dockSite2.Location = new System.Drawing.Point(537, 0);
            this.dockSite2.Name = "dockSite2";
            this.dockSite2.Size = new System.Drawing.Size(0, 433);
            this.dockSite2.TabIndex = 894;
            this.dockSite2.TabStop = false;
            // 
            // dockSite3
            // 
            this.dockSite3.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite3.Dock = System.Windows.Forms.DockStyle.Top;
            this.dockSite3.Location = new System.Drawing.Point(0, 0);
            this.dockSite3.Name = "dockSite3";
            this.dockSite3.Size = new System.Drawing.Size(537, 0);
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
            // FrmChickout
            // 
            this.ClientSize = new System.Drawing.Size(537, 433);
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
            this.Name = "FrmChickout";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "مغادرة النزلاء";
            this.Load += new System.EventHandler(this.FrmChickout_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Frm_KeyPress);
            this.panel1.ResumeLayout(false);
            this.panelEx2.ResumeLayout(false);
            this.ribbonBar1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Label17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Text1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtroomDays)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtroomPrice)).EndInit();
            this.panel_Gaid.ResumeLayout(false);
            this.panel_Gaid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Label7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VS1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtroomTot)).EndInit();
            this.ribbonBar_Tasks.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl_Main1)).EndInit();
            this.contextMenuStrip2.ResumeLayout(false);
            this.Icon = ((System.Drawing.Icon)(InvAcc.Properties.Resources.favicon));
            this.ResumeLayout(false);
        }
        private void Button_Close_Click(object sender, EventArgs e)
        {
            Close();
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
            if (e.KeyCode != Keys.F1)
            {
                if (e.KeyCode == Keys.F2 && Button_Save.Enabled && Button_Save.Visible && State != 0)
                {
                    Button_Save_Click(sender, e);
                }
                else if (e.KeyCode != Keys.F5 && e.KeyCode == Keys.Escape)
                {
                    Close();
                }
            }
        }
        public FrmChickout()
        {
            InitializeComponent();
        }
        private void RibunButtons()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                Button_Close.Text = "اغلاق";
                Button_GaidGabth.Text = "سند قبض نزيل";
                Button_Save.Text = "مغادرة";
                Button_GaidSerf.Text = "سند صرف نزيل";
                Button_Close.Tooltip = "Esc";
                Button_GaidGabth.Tooltip = "F3";
                Button_Save.Tooltip = "F2";
                Button_GaidSerf.Tooltip = "F4";
                switchButton_Lock.OffText = "إنشاء قيد محاسبي";
                switchButton_Lock.OnText = "إنشاء قيد محاسبي";
                Button_GaidGabthAcc.Text = "قبض محاسبي";
                Text = "مغادرة النزلاء";
            }
            else
            {
                Button_Close.Text = "Close";
                Button_GaidGabth.Text = "arrest Guest";
                Button_Save.Text = "Leave";
                Button_GaidSerf.Text = "Exchange Guest";
                Button_Close.Tooltip = "Esc";
                Button_GaidGabth.Tooltip = "F3";
                Button_Save.Tooltip = "F2";
                Button_GaidSerf.Tooltip = "F4";
                VS1.Cols[0].Caption = "Room No";
                VS1.Cols[1].Caption = "Rent";
                VS1.Cols[2].Caption = "Days";
                VS1.Cols[3].Caption = "Tax";
                VS1.Cols[4].Caption = "Service Ratio";
                VS1.Cols[5].Caption = "Total";
                buttonItem_EditDays.Text = "Modify days";
                switchButton_Lock.OffText = "Create an accounting record";
                switchButton_Lock.OnText = "Create an accounting record";
                Button_GaidGabthAcc.Text = "catch Acc";
                VS.Cols[0].Caption = "Service Name";
                VS.Cols[1].Caption = "Total services";
                Text = "Guests Leaving";
            }
        }
        private void FrmChickout_Load(object sender, EventArgs e)
        {
            try
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmChickout));
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
                CmbCurr.SelectedIndex = 0;
                if (VarGeneral.vDemo && VarGeneral.UserID != 1)
                {
                    buttonItem_EditDays.Visible = false;
                }
                VarGeneral.Day1 = 0;
                VarGeneral.DayEdit = 0;
                R1 = VarGeneral.Trn;
                R2 = VarGeneral._hotelrom;
                R3 = VarGeneral._hotelper;
                SetData();
                VS.RowSel = 3;
                VS.Row = 3;
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Load:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        public void SetData()
        {
            try
            {
                PerOp = new T_per();
                RoomOp = new T_Rom();
                double aa = 0.0;
                M = 1;
                FillCombo();
                txtRoom.Text = VarGeneral._hotelrom.ToString();
                RoomOp = db.StockRoom(VarGeneral._hotelrom);
                PerOp = db.StockPer(VarGeneral._hotelper);
                comboBox_DisType.SelectedIndex = PerOp.disknd.Value;
                comboBox_DisTo.SelectedIndex = PerOp.distyp.Value;
                comboBox_RoomTyp.SelectedIndex = PerOp.KindPer.Value;
                if (PerOp.DayOfM.HasValue)
                {
                    VarGeneral.GDayM = PerOp.DayOfM.Value;
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
                if (!string.IsNullOrEmpty(PerOp.Cust_no))
                {
                    txtGuestAcc.Text = PerOp.Cust_no.ToString();
                }
                else
                {
                    txtGuestAcc.Text = "";
                }
                txtName.Text = PerOp.nm;
                Cmb_PayMethod.SelectedIndex = PerOp.cc.Value;
                Label6.Value = PerOp.price.Value;
                Label10.Value = PerOp.ser.Value;
                Label12.Value = PerOp.tax.Value;
                txtDate.Text = PerOp.dt2;
                List<T_sertyp> q = db.T_sertyps.Select((T_sertyp t) => t).ToList();
                VS.Rows.Count = q.Count + 6;
                VS.SetData(1, 0, (LangArEn == 0) ? "إجمالي قيمة فترة الإقامة" : "Residence");
                VS.SetData(2, 0, (LangArEn == 0) ? "إجمالي قيمة الضريبة" : "Tax");
                VS.SetData(3, 0, (LangArEn == 0) ? "إجمالي قيمة الخدمات الإضافية" : "service");
                VS.SetData(4, 0, (LangArEn == 0) ? "المكالمات الهاتفية" : "Phones");
                VS.SetData(5, 0, (LangArEn == 0) ? "المطلوب من حركات محاسبية أخرى" : "Required from other accounting movements");
                VS.SetCellStyle(5, 1, "SubTotal0");
                VS.SetData(1, 2, "401001");
                VS.SetData(2, 2, "401002");
                VS.SetData(3, 2, "401003");
                VS.SetData(4, 2, "401004");
                VS.SetData(5, 2, "401005");
                VS.Rows[0].Visible = false;
                VS.Rows[2].Visible = false;
                VS.Rows[3].Visible = false;
                aa = q.Count;
                for (int i = 6; i < VS.Rows.Count; i++)
                {
                    VS.SetData(i, 0, (LangArEn == 0) ? q[i - 6].Arb_Des : q[i - 6].Eng_Des);
                    VS.SetData(i, 1, 0);
                    VS.SetData(i, 2, q[i - 6].Serv_No);
                }
                if (VarGeneral.Day1 == 0)
                {
                    if (comboBox_RoomTyp.SelectedIndex == 0)
                    {
                        aa = VarGeneral.Dy(PerOp.dt2, PerOp.tm1 + " " + PerOp.vAmPm);
                    }
                    else
                    {
                        VarGeneral.Dy(PerOp.dt2, PerOp.tm1 + " " + PerOp.vAmPm);
                        VarGeneral.Dy2(PerOp.dt2, PerOp.tm1 + " " + PerOp.vAmPm);
                    }
                    Label19.Value = aa;
                }
                else if (comboBox_RoomTyp.SelectedIndex == 0)
                {
                    aa = Label19.Value;
                }
                else
                {
                    aa = Label19.Value;
                    VarGeneral.Dy3();
                }
                double TotP1 = ((comboBox_RoomTyp.SelectedIndex != 0) ? (PerOp.price.Value * (double)VarGeneral.CS) : (PerOp.price.Value * aa));
                Label5.Value = aa;
                Text1.Value = PerOp.dis.Value;
                if (VS1.Rows.Count < 2)
                {
                    VS1.Rows.Add();
                }
                VS1.SetData(1, 0, PerOp.romno);
                VS1.SetData(1, 1, PerOp.price);
                txtroomPrice.Value = PerOp.price.Value;
                VS1.SetData(1, 2, aa);
                txtroomDays.Value = aa;
                VS1.SetData(1, 3, PerOp.tax);
                VS1.SetData(1, 4, PerOp.ser);
                VS1.SetData(1, 5, TotP1);
                txtroomTot.Value = TotP1;
                Total();
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("SetData:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void Total()
        {
            double tot11 = 0.0;
            double tot12 = 0.0;
            double tot13 = 0.0;
            double Tot1 = 0.0;
            double Tot3 = 0.0;
            double Tot4 = 0.0;
            double Tot5 = 0.0;
            double Tot6 = 0.0;
            double Tot7 = 0.0;
            double Tot8 = 0.0;
            double Tot9 = 0.0;
            double Tot2 = 0.0;
            TotResturant = 0.0;
            for (int i = 5; i < VS.Rows.Count; i++)
            {
                try
                {
                    List<double> sqlst = db.ExecuteQuery<double>("select sum(price) as SumPrice from [T_tran] where perno=" + VarGeneral._hotelper + " and typ = " + VS.GetData(i, 2), new object[0]).ToList();
                    if (sqlst.Count > 0)
                    {
                        tot11 = ((!string.IsNullOrEmpty(sqlst.FirstOrDefault().ToString())) ? sqlst.FirstOrDefault() : 0.0);
                        Tot1 += tot11;
                        VS.SetData(i, 1, tot11);
                    }
                }
                catch
                {
                }
            }
            try
            {
                List<double> sqlst = db.ExecuteQuery<double>("select sum(price) as SumPrice from [T_tel] where perno=" + VarGeneral._hotelper, new object[0]).ToList();
                if (sqlst.Count > 0)
                {
                    Tot3 = ((!string.IsNullOrEmpty(sqlst.FirstOrDefault().ToString())) ? sqlst.FirstOrDefault() : 0.0);
                }
                VS.SetData(4, 1, Tot3);
            }
            catch
            {
                Tot3 = 0.0;
                VS.SetData(4, 1, Tot3);
            }
            try
            {
                List<double> sqlst = db.ExecuteQuery<double>("SELECT Sum(case when [T_Snd].[typ]=1 then [T_Snd].[price]*[T_Snd].[curcost] else -[T_Snd].[price]*[T_Snd].[curcost] end) AS SumPrice FROM [T_Snd] where perno=" + VarGeneral._hotelper + " and ch<>3", new object[0]).ToList();
                if (sqlst.Count > 0)
                {
                    Tot4 = ((!string.IsNullOrEmpty(sqlst.FirstOrDefault().ToString())) ? sqlst.FirstOrDefault() : 0.0);
                }
            }
            catch
            {
                Tot4 = 0.0;
            }
            try
            {
                Stock_DataDataContext _DB = new Stock_DataDataContext(VarGeneral.BranchCS);
                List<T_AccDef> sqlst2 = (from er in _DB.T_AccDefs
                                         where er.AccDef_No == txtGuestAcc.Text
                                         orderby er.AccDef_No
                                         select er).ToList();
                if (sqlst2.Count() > 0)
                {
                    sqlst2.First().Debit = sqlst2.First().T_GDDETs.Where((T_GDDET g) => !g.T_GDHEAD.gdLok && g.T_AccDef.Lev == 4 && g.gdValue > 0.0 && g.T_GDHEAD.gdTyp != 15 && g.T_GDHEAD.gdTyp != 27 && g.T_GDHEAD.gdTyp != 28).Sum((T_GDDET g) => g.gdValue.Value);
                    sqlst2.First().Credit = Math.Abs(sqlst2.First().T_GDDETs.Where((T_GDDET g) => !g.T_GDHEAD.gdLok && g.T_AccDef.Lev == 4 && g.gdValue < 0.0 && g.T_GDHEAD.gdTyp != 15 && g.T_GDHEAD.gdTyp != 27 && g.T_GDHEAD.gdTyp != 28).Sum((T_GDDET g) => g.gdValue.Value));
                    sqlst2.First().Balance = sqlst2.First().T_GDDETs.Where((T_GDDET g) => !g.T_GDHEAD.gdLok && g.T_AccDef.Lev == 4 && g.T_GDHEAD.gdTyp != 15 && g.T_GDHEAD.gdTyp != 27 && g.T_GDHEAD.gdTyp != 28).Sum((T_GDDET g) => g.gdValue.Value);
                }
                if (sqlst2.Count > 0)
                {
                    TotResturant = sqlst2.FirstOrDefault().Balance.Value;
                }
            }
            catch
            {
                TotResturant = 0.0;
            }
            try
            {
                if (TotResturant < 0.0)
                {
                    TotResturant = 0.0;
                }
            }
            catch
            {
            }
            Label8.Value = Tot1;
            Label9.Value = Tot3;
            Label15.Value = Tot4;
            for (int i = 1; i < VS1.Rows.Count; i++)
            {
                Tot5 += double.Parse(VS1.GetData(i, 5).ToString());
                tot12 += Tot5 * double.Parse(VS1.GetData(i, 3).ToString()) / 100.0;
                tot13 += Tot5 * double.Parse(VS1.GetData(i, 4).ToString()) / 100.0;
            }
            Tot6 = tot12;
            Tot7 = tot13;
            tot12 = 0.0;
            tot13 = 0.0;
            Tot2 = Tot1 + Tot3 + Tot5 + Tot6 + Tot7;
            if (comboBox_DisType.SelectedIndex == 1)
            {
                if (comboBox_DisTo.SelectedIndex == 0)
                {
                    Tot8 = Tot5 * Text1.Value / 100.0;
                    Tot5 -= Tot8;
                    Tot6 = Tot5 * (double)RoomOp.tax.Value / 100.0;
                    Tot7 = Tot5 * (double)RoomOp.ser.Value / 100.0;
                }
                else if (comboBox_DisTo.SelectedIndex == 1)
                {
                    Tot9 = Tot2 * Text1.Value / 100.0;
                }
            }
            else if (comboBox_DisType.SelectedIndex == 2)
            {
                if (comboBox_DisTo.SelectedIndex == 0)
                {
                    Tot8 = Text1.Value * Label5.Value;
                    Tot5 -= Tot8;
                    Tot6 = Tot5 * (double)RoomOp.tax.Value / 100.0;
                    Tot7 = Tot5 * (double)RoomOp.ser.Value / 100.0;
                }
                else if (comboBox_DisTo.SelectedIndex == 1)
                {
                    Tot9 = Text1.Value;
                }
            }
            if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 48))
            {
                Label14.Value = Tot1 + Tot3 + Tot5 + Tot6 + Tot7 + TotResturant;
                Tot2 = Tot1 + Tot3 + Tot5 + Tot6 + Tot7 + TotResturant - Tot9;
            }
            else
            {
                Label14.Value = Tot1 + Tot3 + Tot5 + Tot6 + Tot7;
                Tot2 = Tot1 + Tot3 + Tot5 + Tot6 + Tot7 - Tot9;
            }
            Label11.Value = Tot6;
            Label13.Value = Tot7;
            Label16.Value = Tot8 + Tot9;
            Tot = Tot2 - Tot4;
            Tot2 = ((!VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 48)) ? (Tot1 + Tot3 + Tot5 + Tot6 + Tot7 - Tot9) : (Tot1 + Tot3 + Tot5 + Tot6 + Tot7 + TotResturant - Tot9));
            Label11.Value = Tot6;
            Label13.Value = Tot7;
            Label16.Value = Tot8 + Tot9;
            Label7.Value = Tot5;
            Tot = Tot2 - Tot4;
            VS.SetData(1, 1, Label7.Value);
            VS.SetData(2, 1, Label11.Value);
            VS.SetData(3, 1, Label13.Value);
            VS.SetData(4, 1, Label9.Value);
            VS.SetData(5, 1, TotResturant);
            if (TotResturant > 0.0)
            {
                Button_GaidGabthAcc.Visible = true;
            }
            else
            {
                Button_GaidGabthAcc.Visible = false;
            }
            Label15.Value = Tot4;
            Label17.Value = Tot;
            if (Label17.Value < 0.0)
            {
                Label17.ForeColor = Color.Red;
            }
            else
            {
                Label17.ForeColor = Color.Blue;
            }
            if (Label17.Value <= 0.0 || Cmb_PayMethod.SelectedIndex > 0)
            {
                Button_Save.Enabled = true;
                Button_Save.Focus();
            }
            else
            {
                Button_Save.Enabled = false;
            }
        }
        public void FillCombo()
        {
            Cmb_PayMethod.Items.Clear();
            Cmb_PayMethod.Items.Add((LangArEn == 0) ? "نقــدي" : "Cash");
            Cmb_PayMethod.Items.Add((LangArEn == 0) ? "آجــــل" : "Credit");
            Cmb_PayMethod.SelectedIndex = 0;
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
        }
        private T_Snd GetData()
        {
            data_this_Snd = new T_Snd();
            data_this_Snd.fNo = db.MaxSndNo;
            try
            {
                data_this_Snd.curr = int.Parse(CmbCurr.SelectedValue.ToString());
            }
            catch
            {
                data_this_Snd.curr = null;
            }
            data_this_Snd.perno = VarGeneral._hotelper;
            data_this_Snd.SndName = txtName.Text;
            data_this_Snd.romno = int.Parse(txtRoom.Text);
            data_this_Snd.price = Label17.Value;
            data_this_Snd.typ = VarGeneral.SndTyp;
            data_this_Snd.typN = 0;
            data_this_Snd.det = "مغادرة نزيل آجل || Departure of a guest";
            data_this_Snd.ShekDate = "";
            data_this_Snd.ShekNo = "";
            if (switchButton_Lock.Value)
            {
                data_this_Snd.ShekBank = "1";
            }
            else
            {
                data_this_Snd.ShekBank = "0";
            }
            data_this_Snd.curcost = 1.0;
            data_this_Snd.ch = 1;
            T_Snd t_Snd = data_this_Snd;
            int? calendr = VarGeneral.Settings_Sys.Calendr;
            t_Snd.dt = ((calendr.Value == 0 && calendr.HasValue) ? n.FormatGreg(VarGeneral.Gdate, "yyyy/MM/dd") : n.FormatHijri(VarGeneral.Hdate, "yyyy/MM/dd"));
            data_this_Snd.tm = DateTime.Now.ToString("HH:mm");
            data_this_Snd.Usr = VarGeneral.UserNo;
            data_this_Snd.IfTrans = 0;
            return data_this_Snd;
        }
        private T_GDHEAD GetDataGd(double _val, int maxGd)
        {
            _GdHead2.gdHDate = VarGeneral.Hdate;
            _GdHead2.gdGDate = VarGeneral.Gdate;
            _GdHead2.gdNo = maxGd.ToString();
            _GdHead2.ArbTaf = ScriptNumber1.ScriptNum(decimal.Parse("0" + _val));
            _GdHead2.BName = _GdHead2.BName;
            _GdHead2.ChekNo = "GuestLeave";
            _GdHead2.CurTyp = 1;
            _GdHead2.EngTaf = ScriptNumber1.TafEng(decimal.Parse("0" + _val));
            _GdHead2.gdCstNo = 1;
            _GdHead2.gdID = 0;
            _GdHead2.gdLok = false;
            _GdHead2.gdMem = "قيد تلقائي لعملية مغادرة نزيل بقيمة إجمالي فترة الإقامة  | Auto Bound to check-out of the total stay ";
            _GdHead2.gdMnd = null;
            _GdHead2.gdRcptID = (_GdHead2.gdRcptID.HasValue ? _GdHead2.gdRcptID.Value : 0.0);
            _GdHead2.gdTot = _val;
            _GdHead2.gdTp = (_GdHead2.gdTp.HasValue ? _GdHead2.gdTp.Value : 0);
            _GdHead2.gdTyp = 15;
            _GdHead2.RefNo = "";
            _GdHead2.AdminLock = true;
            _GdHead2.DATE_MODIFIED = DateTime.Now;
            _GdHead2.salMonth = "";
            _GdHead2.gdUser = VarGeneral.UserNumber;
            _GdHead2.gdUserNam = VarGeneral.UserNameA;
            _GdHead2.CompanyID = 1;
            return _GdHead2;
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
                            string dtAction = n.HDateNow("yyyy/MM/dd");
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
                if (false)
                {
                    Environment.Exit(0);
                    return;
                }
                int maxGd = 1;
                if (!VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 70) && txtroomTot.Value > 0.0)
                {
                    try
                    {
                        string AccCrdt = "";
                        string AccDbt = "";
                        if (txtroomTot.Value > 0.0)
                        {
                            try
                            {
                                AccCrdt = VarGeneral.Settings_Sys.GuestBoxAcc;
                            }
                            catch
                            {
                                AccCrdt = "";
                            }
                            try
                            {
                                AccDbt = db.StockPer(PerOp.perno).Cust_no;
                            }
                            catch
                            {
                                AccDbt = "";
                            }
                        }
                        if (AccCrdt == "" && txtroomTot.Value > 0.0)
                        {
                            MessageBox.Show((LangArEn == 0) ? "لا يمكن إتمام العملية .. تأكد من صحة الطرف الدائن للقيد .. " : "You can not complete the operation .. Make sure the creditor under the party ..", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            return;
                        }
                        if (AccDbt == "" && txtroomTot.Value > 0.0)
                        {
                            MessageBox.Show((LangArEn == 0) ? "لا يمكن إتمام العملية .. تأكد من صحة الطرف المدين للقيد .. " : "You can not complete the operation .. Make sure the debtor under the party ..", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            return;
                        }
                        if (txtroomTot.Value > 0.0 && !string.IsNullOrEmpty(AccCrdt) && !string.IsNullOrEmpty(AccDbt))
                        {
                            int num = 1;
                            try
                            {
                                num = db.T_GDHEADs.Where((T_GDHEAD q) => q.gdTyp == (int?)15).Max((T_GDHEAD lgl) => Convert.ToInt32(lgl.gdNo)) + 1;
                            }
                            catch
                            {
                            }
                            maxGd = num;
                            IDatabase db_ = Database.GetDatabase(VarGeneral.BranchCS);
                            Stock_DataDataContext dbc = new Stock_DataDataContext(VarGeneral.BranchCS);
                            GetDataGd(txtroomTot.Value, maxGd);
                            _GdHead2.DATE_CREATED = DateTime.Now;
                            dbc.T_GDHEADs.InsertOnSubmit(_GdHead2);
                            dbc.SubmitChanges();
                            if (txtroomTot.Value > 0.0 && !string.IsNullOrEmpty(AccCrdt) && !string.IsNullOrEmpty(AccDbt))
                            {
                                db_.StartTransaction();
                                db_.ClearParameters();
                                db_.AddParameter("GDDET_ID", DbType.Int32, 0);
                                db_.AddParameter("gdID", DbType.Int32, _GdHead2.gdhead_ID);
                                db_.AddParameter("gdNo", DbType.String, maxGd);
                                db_.AddParameter("gdDes", DbType.String, "قيد تلقائي (مغادرة نزيل) بقيمة إجمالي فترة الإقامة غرفة/شقة  " + txtRoom.Text);
                                db_.AddParameter("gdDesE", DbType.String, "Automatic entry with total value of room / apartment stay period" + txtRoom.Text);
                                db_.AddParameter("recptTyp", DbType.String, "1");
                                db_.AddParameter("AccNo", DbType.String, AccCrdt);
                                db_.AddParameter("AccName", DbType.String, "");
                                db_.AddParameter("gdValue", DbType.Double, 0.0 - txtroomTot.Value);
                                db_.AddParameter("recptNo", DbType.String, maxGd);
                                db_.AddParameter("Lin", DbType.Int32, 1);
                                db_.AddParameter("AccNoDestruction", DbType.String, null);
                                db_.ExecuteNonQueryWithoutCommit(storedProcedure: true, "S_T_GDDET_INSERT");
                                db_.EndTransaction();
                                db_.StartTransaction();
                                db_.ClearParameters();
                                db_.AddParameter("GDDET_ID", DbType.Int32, 0);
                                db_.AddParameter("gdID", DbType.Int32, _GdHead2.gdhead_ID);
                                db_.AddParameter("gdNo", DbType.String, maxGd);
                                db_.AddParameter("gdDes", DbType.String, "قيد تلقائي (مغادرة نزيل) بقيمة إجمالي فترة الإقامة غرفة/شقة  " + txtRoom.Text);
                                db_.AddParameter("gdDesE", DbType.String, "Automatic entry with total value of room / apartment stay period" + txtRoom.Text);
                                db_.AddParameter("recptTyp", DbType.String, "1");
                                db_.AddParameter("AccNo", DbType.String, AccDbt);
                                db_.AddParameter("AccName", DbType.String, "");
                                db_.AddParameter("gdValue", DbType.Double, txtroomTot.Value);
                                db_.AddParameter("recptNo", DbType.String, maxGd);
                                db_.AddParameter("Lin", DbType.Int32, 1);
                                db_.AddParameter("AccNoDestruction", DbType.String, null);
                                db_.ExecuteNonQueryWithoutCommit(storedProcedure: true, "S_T_GDDET_INSERT");
                                db_.EndTransaction();
                            }
                        }
                    }
                    catch (Exception error2)
                    {
                        VarGeneral.DebLog.writeLog("CreateGaid:", error2, enable: true);
                        MessageBox.Show(error2.Message);
                    }
                }
                PerOp.ch = 3;
                PerOp.ps2 = VarGeneral.UserNo;
                PerOp.tm2 = DateTime.Now.ToString("hh:mm:ss tt");
                T_per perOp = PerOp;
                int? calendr = VarGeneral.Settings_Sys.Calendr;
                perOp.dt3 = ((calendr.Value == 0 && calendr.HasValue) ? n.FormatGreg(VarGeneral.Gdate, "yyyy/MM/dd") : n.FormatHijri(VarGeneral.Hdate, "yyyy/MM/dd"));
                PerOp.dis = Text1.Value;
                PerOp.disknd = comboBox_DisType.SelectedIndex;
                PerOp.distyp = comboBox_DisTo.SelectedIndex;
                PerOp.DayEdit = VarGeneral.DayEdit;
                if (Cmb_PayMethod.SelectedIndex > 0)
                {
                    PerOp.cc = 2;
                    PerOp.fat = 0.0;
                }
                else
                {
                    PerOp.fat = Label15.Value;
                }
                if (comboBox_RoomTyp.SelectedIndex == 0)
                {
                    PerOp.DayOfM = null;
                }
                PerOp.Totel = int.Parse((Label17.Value - TotResturant).ToString());
                PerOp.price = Label6.Value;
                PerOp.KindPer = comboBox_RoomTyp.SelectedIndex;
                if (!PerOp.DayOfM.HasValue && comboBox_RoomTyp.SelectedIndex == 1)
                {
                    PerOp.DayOfM = VarGeneral.GDayM;
                }
                if (comboBox_RoomTyp.SelectedIndex == 0)
                {
                    PerOp.DayOfM = null;
                }
                RoomOp.price = Label6.Value;
                db.Log = VarGeneral.DebugLog;
                db.SubmitChanges(ConflictMode.ContinueOnConflict);
                for (int i = 1; i < VS1.Rows.Count; i++)
                {
                    T_romtrn dataThis_RomTrn = new T_romtrn();
                    db.EmptyRom(int.Parse(VS1.GetData(i, 0).ToString()));
                    dataThis_RomTrn.ID = db.MaxRomTrnNo;
                    dataThis_RomTrn.romno1 = int.Parse(VS1.GetData(i, 0).ToString());
                    dataThis_RomTrn.romno2 = null;
                    dataThis_RomTrn.perno = PerOp.perno;
                    calendr = VarGeneral.Settings_Sys.Calendr;
                    dataThis_RomTrn.dt = ((calendr.Value == 0 && calendr.HasValue) ? VarGeneral.Gdate : VarGeneral.Hdate);
                    dataThis_RomTrn.tm = DateTime.Now.ToString("hh:mm:ss tt");
                    dataThis_RomTrn.Usr = VarGeneral.UserNumber;
                    dataThis_RomTrn.typ = 3;
                    dataThis_RomTrn.UsrNam = ((LangArEn == 0) ? VarGeneral.UserNameA : VarGeneral.UserNameE);
                    db.T_romtrns.InsertOnSubmit(dataThis_RomTrn);
                    db.SubmitChanges();
                }
                if (Cmb_PayMethod.SelectedIndex > 0 && Label17.Value - TotResturant > 0.0)
                {
                }
                if (MessageBox.Show((LangArEn == 0) ? "سيتم طباعة كشف حساب نزيل .. هل تريد المتابعة ؟" : "A guest account statement will be printed .. Do you want to continue? ", VarGeneral.ProdectNam, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    FrmRepRevenue frm = new FrmRepRevenue(13);
                    frm.Tag = LangArEn;
                    frm.Text = ((LangArEn == 0) ? "كشف حساب نزيل" : "Guest account statement");
                    frm.tp = 13;
                    frm.FillCombo();
                    frm.comboBox_AdvancStatus.SelectedIndex = 1;
                    frm.txtUserNo.Text = R3.ToString();
                    frm.SerTypeCount += db.FillServTyp_2("").ToList().Count;
                    frm.ButOk_Click(sender, e);
                }
                Close();
            }
            catch (Exception error2)
            {
                VarGeneral.DebLog.writeLog("Save:", error2, enable: true);
                MessageBox.Show(error2.Message);
            }
        }
        private T_GDHEAD GetDataGd()
        {
            _GdHead = new T_GDHEAD();
            _GdHead.gdHDate = VarGeneral.Hdate;
            _GdHead.gdGDate = VarGeneral.Gdate;
            _GdHead.gdNo = data_this_Snd.fNo.ToString();
            _GdHead.ArbTaf = ScriptNumber1.ScriptNum(decimal.Parse("0" + Label17.Value));
            _GdHead.BName = _GdHead.BName;
            _GdHead.ChekNo = _GdHead.ChekNo;
            _GdHead.CurTyp = int.Parse(CmbCurr.SelectedValue.ToString());
            _GdHead.EngTaf = ScriptNumber1.TafEng(decimal.Parse("0" + Label17.Value));
            _GdHead.gdCstNo = 1;
            _GdHead.gdID = 0;
            _GdHead.gdLok = false;
            _GdHead.gdMem = "مغادرة نزيل آجل || Departure of a guest";
            _GdHead.gdMnd = null;
            _GdHead.gdRcptID = (_GdHead.gdRcptID.HasValue ? _GdHead.gdRcptID.Value : 0.0);
            _GdHead.gdTot = Label17.Value;
            _GdHead.gdTp = (_GdHead.gdTp.HasValue ? _GdHead.gdTp.Value : 0);
            _GdHead.gdTyp = VarGeneral.InvTyp;
            _GdHead.RefNo = "";
            _GdHead.AdminLock = false;
            _GdHead.DATE_MODIFIED = DateTime.Now;
            _GdHead.salMonth = "";
            _GdHead.gdUser = VarGeneral.UserNumber;
            _GdHead.gdUserNam = VarGeneral.UserNameA;
            _GdHead.CompanyID = 1;
            return _GdHead;
        }
        private void textBox_ID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (e.KeyChar != '\b'))
            {
                e.Handled = true;
            }
        }
        private void Cmb_PayMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            Total();
        }
        private void Button_GaidGabth_Click(object sender, EventArgs e)
        {
            try
            {
                VarGeneral.vGaidHotel = true;
                VarGeneral.InvTyp = 27;
                FrmSnd frm = new FrmSnd();
                frm.Tag = LangArEn;
                VarGeneral.SndTyp = 1;
                VarGeneral.tot_Guest_val = Label17.Value;
                frm.TopMost = true;
                frm.ShowDialog();
            }
            catch
            {
                VarGeneral.StockOnly = false;
            }
            VarGeneral.vGaidHotel = false;
            SetData();
        }
        private void Button_GaidSerf_Click(object sender, EventArgs e)
        {
            try
            {
                VarGeneral.vGaidHotel = true;
                VarGeneral.InvTyp = 28;
                FrmSnd frm = new FrmSnd();
                frm.Tag = LangArEn;
                VarGeneral.SndTyp = 2;
                frm.TopMost = true;
                frm.ShowDialog();
            }
            catch
            {
                VarGeneral.StockOnly = false;
            }
            VarGeneral.vGaidHotel = false;
            SetData();
        }
        private void buttonItem_EditDays_Click(object sender, EventArgs e)
        {
            FrmEditDay frm = new FrmEditDay(int.Parse(Label19.Value.ToString()));
            frm.Tag = LangArEn;
            frm.TopMost = true;
            frm.ShowDialog();
            Label19.Value = VarGeneral.Cc2;
            SetData();
        }
        private void comboBox_DisType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_DisType.SelectedIndex == 1)
            {
                labelPercentage.Visible = true;
                label12z.Visible = true;
                comboBox_DisTo.Visible = true;
                return;
            }
            labelPercentage.Visible = false;
            if (comboBox_DisType.SelectedIndex == 0)
            {
                label12z.Visible = false;
                comboBox_DisTo.Visible = false;
            }
            else
            {
                label12z.Visible = true;
                comboBox_DisTo.Visible = true;
            }
        }
        private void Label17_ValueChanged(object sender, EventArgs e)
        {
            if (Label17.Value <= 0.0)
            {
                Cmb_PayMethod.SelectedIndex = 0;
                Cmb_PayMethod.DropDownStyle = ComboBoxStyle.Simple;
                Cmb_PayMethod.Enabled = false;
            }
            else
            {
                Cmb_PayMethod.DropDownStyle = ComboBoxStyle.DropDownList;
                Cmb_PayMethod.Enabled = true;
            }
        }
        private void switchButton_Lock_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (switchButton_Lock.Value)
                {
                    panel_Gaid.Enabled = true;
                    if (!switchButton_Lock.Value)
                    {
                        return;
                    }
                    if (string.IsNullOrEmpty(txtDebit1.Text))
                    {
                        try
                        {
                            T_per q = db.StockPer(VarGeneral._hotelper);
                            txtDebit1.Tag = q.Cust_no;
                            txtDebit1.Text = ((LangArEn == 0) ? db.StockAccDefWithOutBalance(q.Cust_no).Arb_Des : db.StockAccDefWithOutBalance(q.Cust_no).Eng_Des);
                        }
                        catch
                        {
                            txtDebit1.Text = "";
                            txtDebit1.Tag = "";
                        }
                    }
                    if (!string.IsNullOrEmpty(txtCredit1.Text))
                    {
                        return;
                    }
                    try
                    {
                        if (!string.IsNullOrEmpty(VarGeneral.Settings_Sys.GuestBoxAcc))
                        {
                            txtCredit1.Tag = VarGeneral.Settings_Sys.GuestBoxAcc;
                            txtCredit1.Text = ((LangArEn == 0) ? db.StockAccDefWithOutBalance(VarGeneral.Settings_Sys.GuestBoxAcc).Arb_Des : db.StockAccDefWithOutBalance(VarGeneral.Settings_Sys.GuestBoxAcc).Eng_Des);
                        }
                        else
                        {
                            txtCredit1.Text = "";
                            txtCredit1.Tag = "";
                        }
                    }
                    catch
                    {
                        txtCredit1.Text = "";
                        txtCredit1.Tag = "";
                    }
                    return;
                }
                panel_Gaid.Enabled = false;
                txtDebit1.Text = "";
                txtDebit1.Tag = "";
                txtCredit1.Text = "";
                txtCredit1.Tag = "";
            }
            catch
            {
            }
        }
        private void txtCredit1_ButtonCustomClick(object sender, EventArgs e)
        {
            columns_Names_visible2.Clear();
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
            if (VarGeneral.SSSTyp == 0)
            {
                VarGeneral.SFrmTyp = "T_AccDef";
                VarGeneral.AccTyp = 4;
            }
            else
            {
                VarGeneral.SFrmTyp = "AccDefID_Setting";
            }
            frm.TopMost = true;
            frm.ShowDialog();
            try
            {
                if (frm.SerachNo != "")
                {
                    T_AccDef _AccDef = db.StockAccDefs(int.Parse(frm.Serach_No));
                    txtCredit1.Tag = _AccDef.AccDef_No;
                    if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                    {
                        txtCredit1.Text = _AccDef.Arb_Des;
                    }
                    else
                    {
                        txtCredit1.Text = _AccDef.Eng_Des;
                    }
                }
                else
                {
                    txtCredit1.Text = "";
                    txtCredit1.Tag = "";
                }
            }
            catch
            {
                txtCredit1.Text = "";
                txtCredit1.Tag = "";
            }
        }
        private void txtDebit1_ButtonCustomClick(object sender, EventArgs e)
        {
            columns_Names_visible2.Clear();
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
            if (VarGeneral.SSSTyp == 0)
            {
                VarGeneral.SFrmTyp = "T_AccDef";
                VarGeneral.AccTyp = 4;
            }
            else
            {
                VarGeneral.SFrmTyp = "AccDefID_Setting";
            }
            frm.TopMost = true;
            frm.ShowDialog();
            try
            {
                if (frm.SerachNo != "")
                {
                    T_AccDef _AccDef = db.StockAccDefs(int.Parse(frm.Serach_No));
                    txtDebit1.Tag = _AccDef.AccDef_No;
                    if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                    {
                        txtDebit1.Text = _AccDef.Arb_Des;
                    }
                    else
                    {
                        txtDebit1.Text = _AccDef.Eng_Des;
                    }
                }
                else
                {
                    txtDebit1.Text = "";
                    txtDebit1.Tag = "";
                }
            }
            catch
            {
                txtDebit1.Text = "";
                txtDebit1.Tag = "";
            }
        }
        private void Button_GaidGabthAcc_Click(object sender, EventArgs e)
        {
            try
            {
                VarGeneral.vGaidHotel = true;
                VarGeneral.InvTyp = 12;
                FMReceiptVoucher frm = new FMReceiptVoucher();
                frm.Tag = LangArEn;
                frm.TopMost = true;
                frm.ShowDialog();
            }
            catch
            {
                VarGeneral.vGaidHotel = false;
            }
            VarGeneral.vGaidHotel = false;
            SetData();
        }
    }
}
