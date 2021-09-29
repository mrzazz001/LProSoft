using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.Editors;
using InvAcc.GeneralM;
using InvAcc.Stock_Data;
using SSSDateTime.Date;
using SSSLanguage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial class FrmPhoneCall : Form
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
        private PanelEx panelEx2;
        private RibbonBar ribbonBar1;
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
        private RibbonBar ribbonBar_Tasks;
        private SuperTabControl superTabControl_Main1;
        protected ButtonItem Button_Close;
        protected ButtonItem Button_Save;
        protected LabelItem labelItem2;
        private DoubleInput txtInsideComm;
        private DoubleInput txtArCountryComm;
        private DoubleInput txtEngCountryComm;
        private DoubleInput txtByMoonComm;
        private DoubleInput txtLocalComm;
        protected Label label4;
        private TextBoxX txtServiceAccName;
        private TextBoxX txtServiceAcc;
        private Label label72;
        protected Label label3;
        private DoubleInput txtInside;
        private DoubleInput txtArCountry;
        private DoubleInput txtEngCountry;
        private DoubleInput txtByMoon;
        private DoubleInput txtLocal;
        protected Label label1;
        protected Label label2;
        protected Label labelx;
        protected Label labelxx;
        protected Label label38;
        public Dictionary<string, ColumnDictinary> columns_Names_visible = new Dictionary<string, ColumnDictinary>();
        public Dictionary<string, ColumnDictinary> columns_Names_visible2 = new Dictionary<string, ColumnDictinary>();
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
        private Rate_DataDataContext dbInstanceRate;
        private T_User permission = new T_User();
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
                    if (!VarGeneral.TString.ChkStatShow(value.RepAcc4, 11))
                    {
                        CanEdit = false;
                    }
                    else
                    {
                        CanEdit = true;
                    }
                }
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPhoneCall));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panelEx2 = new DevComponents.DotNetBar.PanelEx();
            this.ribbonBar1 = new DevComponents.DotNetBar.RibbonBar();
            this.txtServiceAccName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtServiceAcc = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtInsideComm = new DevComponents.Editors.DoubleInput();
            this.txtArCountryComm = new DevComponents.Editors.DoubleInput();
            this.txtEngCountryComm = new DevComponents.Editors.DoubleInput();
            this.txtByMoonComm = new DevComponents.Editors.DoubleInput();
            this.txtLocalComm = new DevComponents.Editors.DoubleInput();
            this.txtInside = new DevComponents.Editors.DoubleInput();
            this.txtArCountry = new DevComponents.Editors.DoubleInput();
            this.txtEngCountry = new DevComponents.Editors.DoubleInput();
            this.txtByMoon = new DevComponents.Editors.DoubleInput();
            this.txtLocal = new DevComponents.Editors.DoubleInput();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelx = new System.Windows.Forms.Label();
            this.labelxx = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.label72 = new System.Windows.Forms.Label();
            this.ribbonBar_Tasks = new DevComponents.DotNetBar.RibbonBar();
            this.superTabControl_Main1 = new DevComponents.DotNetBar.SuperTabControl();
            this.Button_Close = new DevComponents.DotNetBar.ButtonItem();
            this.Button_Save = new DevComponents.DotNetBar.ButtonItem();
            this.labelItem2 = new DevComponents.DotNetBar.LabelItem();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
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
            this.panelEx2.SuspendLayout();
            this.ribbonBar1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtInsideComm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtArCountryComm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEngCountryComm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtByMoonComm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLocalComm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInside)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtArCountry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEngCountry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtByMoon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLocal)).BeginInit();
            this.ribbonBar_Tasks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl_Main1)).BeginInit();
            this.panel1.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            // 
            // panelEx2
            // 
            this.panelEx2.Controls.Add(this.ribbonBar1);
            this.panelEx2.Controls.Add(this.ribbonBar_Tasks);
            this.panelEx2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx2.Location = new System.Drawing.Point(0, 0);
            this.panelEx2.MinimumSize = new System.Drawing.Size(659, 228);
            this.panelEx2.Name = "panelEx2";
            this.panelEx2.Size = new System.Drawing.Size(659, 285);
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
            this.ribbonBar1.Controls.Add(this.txtServiceAccName);
            this.ribbonBar1.Controls.Add(this.txtServiceAcc);
            this.ribbonBar1.Controls.Add(this.label4);
            this.ribbonBar1.Controls.Add(this.label3);
            this.ribbonBar1.Controls.Add(this.txtInsideComm);
            this.ribbonBar1.Controls.Add(this.txtArCountryComm);
            this.ribbonBar1.Controls.Add(this.txtEngCountryComm);
            this.ribbonBar1.Controls.Add(this.txtByMoonComm);
            this.ribbonBar1.Controls.Add(this.txtLocalComm);
            this.ribbonBar1.Controls.Add(this.txtInside);
            this.ribbonBar1.Controls.Add(this.txtArCountry);
            this.ribbonBar1.Controls.Add(this.txtEngCountry);
            this.ribbonBar1.Controls.Add(this.txtByMoon);
            this.ribbonBar1.Controls.Add(this.txtLocal);
            this.ribbonBar1.Controls.Add(this.label1);
            this.ribbonBar1.Controls.Add(this.label2);
            this.ribbonBar1.Controls.Add(this.labelx);
            this.ribbonBar1.Controls.Add(this.labelxx);
            this.ribbonBar1.Controls.Add(this.label38);
            this.ribbonBar1.Controls.Add(this.label72);
            this.ribbonBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonBar1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.ribbonBar1.Location = new System.Drawing.Point(0, 0);
            this.ribbonBar1.Name = "ribbonBar1";
            this.ribbonBar1.Size = new System.Drawing.Size(659, 234);
            this.ribbonBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this.ribbonBar1.TabIndex = 867;
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
            // txtServiceAccName
            // 
            this.txtServiceAccName.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtServiceAccName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtServiceAccName.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.txtServiceAccName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtServiceAccName.Location = new System.Drawing.Point(89, 196);
            this.txtServiceAccName.Name = "txtServiceAccName";
            this.txtServiceAccName.ReadOnly = true;
            this.txtServiceAccName.Size = new System.Drawing.Size(259, 14);
            this.txtServiceAccName.TabIndex = 1049;
            this.txtServiceAccName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtServiceAccName.Click += new System.EventHandler(this.txtServiceAccName_Click);
            // 
            // txtServiceAcc
            // 
            this.txtServiceAcc.BackColor = System.Drawing.SystemColors.Control;
            // 
            // 
            // 
            this.txtServiceAcc.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtServiceAcc.ButtonCustom.Visible = true;
            this.txtServiceAcc.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.txtServiceAcc.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtServiceAcc.Location = new System.Drawing.Point(351, 196);
            this.txtServiceAcc.Name = "txtServiceAcc";
            this.txtServiceAcc.ReadOnly = true;
            this.txtServiceAcc.Size = new System.Drawing.Size(139, 14);
            this.txtServiceAcc.TabIndex = 1048;
            this.txtServiceAcc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtServiceAcc.ButtonCustomClick += new System.EventHandler(this.txtServiceAcc_ButtonCustomClick);
            this.txtServiceAcc.Click += new System.EventHandler(this.txtServiceAcc_Click);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(-169, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(143, 38);
            this.label4.TabIndex = 1003;
            this.label4.Text = "الضريبة";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label4.Visible = false;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(89, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(401, 30);
            this.label3.TabIndex = 1002;
            this.label3.Text = "سعر الدقيقة للمكالمات";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtInsideComm
            // 
            this.txtInsideComm.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtInsideComm.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(198)))));
            this.txtInsideComm.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtInsideComm.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtInsideComm.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtInsideComm.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.txtInsideComm.Increment = 1D;
            this.txtInsideComm.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtInsideComm.Location = new System.Drawing.Point(-169, 82);
            this.txtInsideComm.MinValue = 0D;
            this.txtInsideComm.Name = "txtInsideComm";
            this.txtInsideComm.Size = new System.Drawing.Size(143, 22);
            this.txtInsideComm.TabIndex = 1001;
            this.txtInsideComm.Visible = false;
            // 
            // txtArCountryComm
            // 
            this.txtArCountryComm.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtArCountryComm.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(198)))));
            this.txtArCountryComm.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtArCountryComm.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtArCountryComm.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtArCountryComm.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.txtArCountryComm.Increment = 1D;
            this.txtArCountryComm.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtArCountryComm.Location = new System.Drawing.Point(-169, 106);
            this.txtArCountryComm.MinValue = 0D;
            this.txtArCountryComm.Name = "txtArCountryComm";
            this.txtArCountryComm.Size = new System.Drawing.Size(143, 22);
            this.txtArCountryComm.TabIndex = 1000;
            this.txtArCountryComm.Visible = false;
            // 
            // txtEngCountryComm
            // 
            this.txtEngCountryComm.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtEngCountryComm.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(198)))));
            this.txtEngCountryComm.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtEngCountryComm.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtEngCountryComm.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtEngCountryComm.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.txtEngCountryComm.Increment = 1D;
            this.txtEngCountryComm.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtEngCountryComm.Location = new System.Drawing.Point(-169, 130);
            this.txtEngCountryComm.MinValue = 0D;
            this.txtEngCountryComm.Name = "txtEngCountryComm";
            this.txtEngCountryComm.Size = new System.Drawing.Size(143, 22);
            this.txtEngCountryComm.TabIndex = 999;
            this.txtEngCountryComm.Visible = false;
            // 
            // txtByMoonComm
            // 
            this.txtByMoonComm.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtByMoonComm.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(198)))));
            this.txtByMoonComm.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtByMoonComm.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtByMoonComm.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtByMoonComm.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.txtByMoonComm.Increment = 1D;
            this.txtByMoonComm.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtByMoonComm.Location = new System.Drawing.Point(-169, 154);
            this.txtByMoonComm.MinValue = 0D;
            this.txtByMoonComm.Name = "txtByMoonComm";
            this.txtByMoonComm.Size = new System.Drawing.Size(143, 22);
            this.txtByMoonComm.TabIndex = 998;
            this.txtByMoonComm.Visible = false;
            // 
            // txtLocalComm
            // 
            this.txtLocalComm.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtLocalComm.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(198)))));
            this.txtLocalComm.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtLocalComm.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtLocalComm.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtLocalComm.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.txtLocalComm.Increment = 1D;
            this.txtLocalComm.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtLocalComm.Location = new System.Drawing.Point(-169, 58);
            this.txtLocalComm.MinValue = 0D;
            this.txtLocalComm.Name = "txtLocalComm";
            this.txtLocalComm.Size = new System.Drawing.Size(143, 22);
            this.txtLocalComm.TabIndex = 997;
            this.txtLocalComm.Visible = false;
            // 
            // txtInside
            // 
            this.txtInside.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtInside.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(198)))));
            this.txtInside.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtInside.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtInside.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtInside.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.txtInside.Increment = 1D;
            this.txtInside.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtInside.Location = new System.Drawing.Point(89, 67);
            this.txtInside.MinValue = 0D;
            this.txtInside.Name = "txtInside";
            this.txtInside.Size = new System.Drawing.Size(401, 22);
            this.txtInside.TabIndex = 996;
            // 
            // txtArCountry
            // 
            this.txtArCountry.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtArCountry.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(198)))));
            this.txtArCountry.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtArCountry.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtArCountry.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtArCountry.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.txtArCountry.Increment = 1D;
            this.txtArCountry.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtArCountry.Location = new System.Drawing.Point(89, 91);
            this.txtArCountry.MinValue = 0D;
            this.txtArCountry.Name = "txtArCountry";
            this.txtArCountry.Size = new System.Drawing.Size(401, 22);
            this.txtArCountry.TabIndex = 995;
            // 
            // txtEngCountry
            // 
            this.txtEngCountry.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtEngCountry.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(198)))));
            this.txtEngCountry.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtEngCountry.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtEngCountry.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtEngCountry.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.txtEngCountry.Increment = 1D;
            this.txtEngCountry.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtEngCountry.Location = new System.Drawing.Point(89, 115);
            this.txtEngCountry.MinValue = 0D;
            this.txtEngCountry.Name = "txtEngCountry";
            this.txtEngCountry.Size = new System.Drawing.Size(401, 22);
            this.txtEngCountry.TabIndex = 994;
            // 
            // txtByMoon
            // 
            this.txtByMoon.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtByMoon.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(198)))));
            this.txtByMoon.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtByMoon.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtByMoon.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtByMoon.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.txtByMoon.Increment = 1D;
            this.txtByMoon.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtByMoon.Location = new System.Drawing.Point(89, 139);
            this.txtByMoon.MinValue = 0D;
            this.txtByMoon.Name = "txtByMoon";
            this.txtByMoon.Size = new System.Drawing.Size(401, 22);
            this.txtByMoon.TabIndex = 993;
            // 
            // txtLocal
            // 
            this.txtLocal.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtLocal.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(198)))));
            this.txtLocal.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtLocal.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtLocal.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtLocal.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.txtLocal.Increment = 1D;
            this.txtLocal.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtLocal.Location = new System.Drawing.Point(89, 43);
            this.txtLocal.MinValue = 0D;
            this.txtLocal.Name = "txtLocal";
            this.txtLocal.Size = new System.Drawing.Size(401, 22);
            this.txtLocal.TabIndex = 990;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(496, 144);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 13);
            this.label1.TabIndex = 87;
            this.label1.Text = "عبر الأقمار الصناعية :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(496, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 86;
            this.label2.Text = "حول الدول الأجنبية :";
            // 
            // labelx
            // 
            this.labelx.AutoSize = true;
            this.labelx.BackColor = System.Drawing.Color.Transparent;
            this.labelx.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.labelx.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelx.Location = new System.Drawing.Point(496, 96);
            this.labelx.Name = "labelx";
            this.labelx.Size = new System.Drawing.Size(99, 13);
            this.labelx.TabIndex = 85;
            this.labelx.Text = "حــول الدول العربية :";
            // 
            // labelxx
            // 
            this.labelxx.AutoSize = true;
            this.labelxx.BackColor = System.Drawing.Color.Transparent;
            this.labelxx.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.labelxx.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelxx.Location = new System.Drawing.Point(496, 72);
            this.labelxx.Name = "labelxx";
            this.labelxx.Size = new System.Drawing.Size(97, 13);
            this.labelxx.TabIndex = 83;
            this.labelxx.Text = "المكالمات الداخلية :";
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.BackColor = System.Drawing.Color.Transparent;
            this.label38.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label38.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label38.Location = new System.Drawing.Point(496, 48);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(95, 13);
            this.label38.TabIndex = 81;
            this.label38.Text = "المكالمات المحلية :";
            // 
            // label72
            // 
            this.label72.BackColor = System.Drawing.Color.Gainsboro;
            this.label72.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label72.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label72.ForeColor = System.Drawing.Color.Black;
            this.label72.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label72.Location = new System.Drawing.Point(89, 164);
            this.label72.Name = "label72";
            this.label72.Size = new System.Drawing.Size(401, 28);
            this.label72.TabIndex = 1047;
            this.label72.Text = "حساب القيد التلقائي لمستخدمين الخدمة";
            this.label72.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.ribbonBar_Tasks.Location = new System.Drawing.Point(0, 234);
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
            this.Button_Save,
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
            this.Button_Save.Click += new System.EventHandler(this.Button_Save_Click);
            // 
            // labelItem2
            // 
            this.labelItem2.Name = "labelItem2";
            this.labelItem2.Width = 40;
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
            this.panel1.Size = new System.Drawing.Size(649, 285);
            this.panel1.TabIndex = 897;
            // 
            // barTopDockSite
            // 
            this.barTopDockSite.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.barTopDockSite.Dock = System.Windows.Forms.DockStyle.Top;
            this.barTopDockSite.DocumentDockContainer = new DevComponents.DotNetBar.DocumentDockContainer();
            this.barTopDockSite.Location = new System.Drawing.Point(0, 0);
            this.barTopDockSite.Name = "barTopDockSite";
            this.barTopDockSite.Size = new System.Drawing.Size(649, 0);
            this.barTopDockSite.TabIndex = 889;
            this.barTopDockSite.TabStop = false;
            // 
            // barBottomDockSite
            // 
            this.barBottomDockSite.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.barBottomDockSite.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barBottomDockSite.DocumentDockContainer = new DevComponents.DotNetBar.DocumentDockContainer();
            this.barBottomDockSite.Location = new System.Drawing.Point(0, 285);
            this.barBottomDockSite.Name = "barBottomDockSite";
            this.barBottomDockSite.Size = new System.Drawing.Size(649, 0);
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
            this.barLeftDockSite.Size = new System.Drawing.Size(0, 285);
            this.barLeftDockSite.TabIndex = 891;
            this.barLeftDockSite.TabStop = false;
            // 
            // barRightDockSite
            // 
            this.barRightDockSite.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.barRightDockSite.Dock = System.Windows.Forms.DockStyle.Right;
            this.barRightDockSite.DocumentDockContainer = new DevComponents.DotNetBar.DocumentDockContainer();
            this.barRightDockSite.Location = new System.Drawing.Point(649, 0);
            this.barRightDockSite.Name = "barRightDockSite";
            this.barRightDockSite.Size = new System.Drawing.Size(0, 285);
            this.barRightDockSite.TabIndex = 892;
            this.barRightDockSite.TabStop = false;
            // 
            // dockSite4
            // 
            this.dockSite4.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dockSite4.Location = new System.Drawing.Point(0, 285);
            this.dockSite4.Name = "dockSite4";
            this.dockSite4.Size = new System.Drawing.Size(649, 0);
            this.dockSite4.TabIndex = 896;
            this.dockSite4.TabStop = false;
            // 
            // dockSite1
            // 
            this.dockSite1.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite1.Dock = System.Windows.Forms.DockStyle.Left;
            this.dockSite1.Location = new System.Drawing.Point(0, 0);
            this.dockSite1.Name = "dockSite1";
            this.dockSite1.Size = new System.Drawing.Size(0, 285);
            this.dockSite1.TabIndex = 893;
            this.dockSite1.TabStop = false;
            // 
            // dockSite2
            // 
            this.dockSite2.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite2.Dock = System.Windows.Forms.DockStyle.Right;
            this.dockSite2.Location = new System.Drawing.Point(649, 0);
            this.dockSite2.Name = "dockSite2";
            this.dockSite2.Size = new System.Drawing.Size(0, 285);
            this.dockSite2.TabIndex = 894;
            this.dockSite2.TabStop = false;
            // 
            // dockSite3
            // 
            this.dockSite3.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite3.Dock = System.Windows.Forms.DockStyle.Top;
            this.dockSite3.Location = new System.Drawing.Point(0, 0);
            this.dockSite3.Name = "dockSite3";
            this.dockSite3.Size = new System.Drawing.Size(649, 0);
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
            // FrmPhoneCall
            // 
            this.ClientSize = new System.Drawing.Size(649, 285);
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
            this.Name = "FrmPhoneCall";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "كرت تعديل أسعار المكالمات";
            this.Load += new System.EventHandler(this.FrmPhoneCall_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Frm_KeyPress);
            this.panelEx2.ResumeLayout(false);
            this.ribbonBar1.ResumeLayout(false);
            this.ribbonBar1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtInsideComm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtArCountryComm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEngCountryComm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtByMoonComm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLocalComm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInside)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtArCountry)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEngCountry)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtByMoon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLocal)).EndInit();
            this.ribbonBar_Tasks.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl_Main1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            this.Icon = ((System.Drawing.Icon)(InvAcc.Properties.Resources.favicon));
            this.ResumeLayout(false);
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
            if (e.KeyCode == Keys.F2 && Button_Save.Enabled && Button_Save.Visible && State != 0)
            {
                Button_Save_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
        public FrmPhoneCall()
        {
            InitializeComponent();
            controls = new List<Control>();
            codeControl = txtArCountryComm;
            controls.Add(txtArCountry);
            controls.Add(txtArCountryComm);
            controls.Add(txtByMoon);
            controls.Add(txtByMoonComm);
            controls.Add(txtEngCountry);
            controls.Add(txtEngCountryComm);
            controls.Add(txtInside);
            controls.Add(txtInsideComm);
            controls.Add(txtLocal);
            controls.Add(txtLocalComm);
            controls.Add(txtServiceAcc);
            controls.Add(txtServiceAccName);
            Button_Close.Click += Button_Close_Click;
            txtArCountry.Click += Button_Edit_Click;
            txtArCountryComm.Click += Button_Edit_Click;
            txtByMoon.Click += Button_Edit_Click;
            txtByMoonComm.Click += Button_Edit_Click;
            txtEngCountry.Click += Button_Edit_Click;
            txtEngCountryComm.Click += Button_Edit_Click;
            txtInside.Click += Button_Edit_Click;
            txtInsideComm.Click += Button_Edit_Click;
            txtLocal.Click += Button_Edit_Click;
            txtLocalComm.Click += Button_Edit_Click;
        }
        private void RibunButtons()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                Button_Close.Text = "اغلاق";
                Button_Save.Text = "حفظ";
                Button_Close.Tooltip = "Esc";
                Button_Save.Tooltip = "F2";
                Text = "كرت تعديل أسعار المكالمات";
            }
            else
            {
                Button_Close.Text = "Close";
                Button_Save.Text = "Save";
                Button_Close.Tooltip = "Esc";
                Button_Save.Tooltip = "F2";
                Text = "Call rate adjustment card";
            }
        }
        private void FrmPhoneCall_Load(object sender, EventArgs e)
        {
            try
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmPhoneCall));
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
                Permmission = dbc.Get_PermissionID(VarGeneral.UserID);
                RibunButtons();
                BinData();
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Load:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        public void BinData()
        {
            try
            {
                State = FormState.Saved;
                Button_Save.Enabled = false;
                txtLocal.Value = db.StockTelMn(0).price.Value;
                txtLocalComm.Value = db.StockTelMn(0).d.Value;
                txtInside.Value = db.StockTelMn(1).price.Value;
                txtInsideComm.Value = db.StockTelMn(1).d.Value;
                txtArCountry.Value = db.StockTelMn(2).price.Value;
                txtArCountryComm.Value = db.StockTelMn(2).d.Value;
                txtEngCountry.Value = db.StockTelMn(3).price.Value;
                txtEngCountryComm.Value = db.StockTelMn(3).d.Value;
                txtByMoon.Value = db.StockTelMn(4).price.Value;
                txtByMoonComm.Value = db.StockTelMn(4).d.Value;
                try
                {
                    if (!string.IsNullOrEmpty(db.StockTelMn(0).accno))
                    {
                        txtServiceAcc.Text = db.StockTelMn(0).accno;
                        txtServiceAccName.Text = ((LangArEn == 0) ? db.StockAccDefWithOutBalance(db.StockTelMn(0).accno).Arb_Des : db.StockAccDefWithOutBalance(db.StockTelMn(0).accno).Eng_Des);
                    }
                    else
                    {
                        txtServiceAcc.Text = "";
                        txtServiceAccName.Text = "";
                    }
                }
                catch
                {
                    txtServiceAcc.Text = "";
                    txtServiceAccName.Text = "";
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("SetData:", error, enable: true);
                MessageBox.Show(error.Message);
            }
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
                try
                {
                    db.ExecuteCommand("UPDATE [T_telmn] SET [price] = " + txtLocal.Value + " ,[d] = " + txtLocalComm.Value + ",accno = '" + txtServiceAcc.Text + "' WHERE pl = 0");
                    db.ExecuteCommand("UPDATE [T_telmn] SET [price] = " + txtInside.Value + " ,[d] = " + txtInsideComm.Value + ",accno = '" + txtServiceAcc.Text + "' WHERE pl = 1");
                    db.ExecuteCommand("UPDATE [T_telmn] SET [price] = " + txtArCountry.Value + " ,[d] = " + txtArCountryComm.Value + ",accno = '" + txtServiceAcc.Text + "' WHERE pl = 2");
                    db.ExecuteCommand("UPDATE [T_telmn] SET [price] = " + txtEngCountry.Value + " ,[d] = " + txtEngCountryComm.Value + ",accno = '" + txtServiceAcc.Text + "' WHERE pl = 3");
                    db.ExecuteCommand("UPDATE [T_telmn] SET [price] = " + txtByMoon.Value + " ,[d] = " + txtByMoonComm.Value + ",accno = '" + txtServiceAcc.Text + "' WHERE pl = 4");
                }
                catch (SqlException)
                {
                    return;
                }
                Close();
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Save:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void txtServiceAcc_ButtonCustomClick(object sender, EventArgs e)
        {
            Button_Edit_Click(sender, e);
            columns_Names_visible.Clear();
            columns_Names_visible.Add("AccDef_No", new ColumnDictinary("الرقم ", " No", ifDefault: true, ""));
            columns_Names_visible.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, ""));
            columns_Names_visible.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, ""));
            columns_Names_visible.Add("AccDef_ID", new ColumnDictinary(" ", " ", ifDefault: false, ""));
            columns_Names_visible.Add("Mobile", new ColumnDictinary("الجوال", "Mobile", ifDefault: false, ""));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, ""));
            }
            VarGeneral.SFrmTyp = "AccDefID_Setting";
            VarGeneral.AccTyp = 11;
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != "")
            {
                T_AccDef _AccDef = db.StockAccDefs(int.Parse(frm.Serach_No));
                txtServiceAcc.Text = _AccDef.AccDef_No.ToString();
                txtServiceAccName.Text = ((LangArEn == 0) ? db.StockAccDefWithOutBalance(txtServiceAcc.Text).Arb_Des : db.StockAccDefWithOutBalance(txtServiceAcc.Text).Eng_Des);
            }
            else
            {
                txtServiceAcc.Text = "";
                txtServiceAccName.Text = "";
            }
        }
        private void txtServiceAcc_Click(object sender, EventArgs e)
        {
            txtServiceAcc.SelectAll();
        }
        private void txtServiceAccName_Click(object sender, EventArgs e)
        {
            txtServiceAccName.SelectAll();
        }
    }
}
