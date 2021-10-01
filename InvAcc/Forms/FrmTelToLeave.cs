using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.DotNetBar.SuperGrid;
using DevComponents.DotNetBar.SuperGrid.Style;
using DevComponents.Editors;
using Framework.Data;
using Framework.Keyboard;
using ProShared.GeneralM;using ProShared;
using ProShared.Stock_Data;
using SSSDateTime.Date;
using SSSLanguage;
using TFG;

namespace InvAcc.Forms
{
	public class FrmTelToLeave : Form
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

		private ExpandableSplitter expandableSplitter1;

		private PanelEx panelEx2;

		private RibbonBar ribbonBar1;

		private System.Windows.Forms. SaveFileDialog saveFileDialog1;

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

		protected ButtonItem Button_Save;

		protected LabelItem labelItem2;

		private RibbonBar ribbonBar_DGV;

		private SuperTabControl superTabControl_DGV;

		protected TextBoxItem textBox_search;

		protected ButtonItem Button_ExportTable2;

		protected LabelItem labelItem3;

		private LabelItem lable_Records;

		private Panel panel2;

		protected TextBox textBox_ID;

		protected Label label38;

		internal Label Label2;

		private MaskedTextBox Label15;

		protected TextBox Text2;

		protected Label label1;

		internal Label label19;

		protected TextBox Label16;

		protected Label label36;

		internal Label label6;

		internal Label label5;

		internal Label label4;

		private DoubleInput Text6;

		internal Label label17;

		private ButtonX Command3;

		private IntegerInput Text5;

		private IntegerInput Text4;

		private IntegerInput Text3;

		private SwitchButton switchButton_Lock;

		private Panel panel_Gaid;

		private ButtonX button_CustC1;

		private ButtonX button_CustD1;

		private TextBoxX txtDebit1;

		private TextBoxX txtCredit1;

		internal Label labelD1;

		internal Label labelC1;

		internal Label labelGuestStat;

		private TextBox txtRoom;

		internal Label labelGaidStat;

		public Dictionary<string, ColumnDictinary> columns_Names_visible = new Dictionary<string, ColumnDictinary>();

		private HijriGreg.HijriGregDates n = new HijriGreg.HijriGregDates();

		private T_AccDef _AccDefBind = new T_AccDef();

		private int LangArEn = 0;

		protected bool ifOkDelete;

		public bool CanEdit = true;

		protected bool CanInsert = true;

#pragma warning disable CS0414 // The field 'FrmTelToLeave.FlagUpdate' is assigned but its value is never used
		private string FlagUpdate = "";
#pragma warning restore CS0414 // The field 'FrmTelToLeave.FlagUpdate' is assigned but its value is never used

		public ViewState ViewState = ViewState.Deiles;

		private FormState statex;

		public List<Control> controls;

		public Control codeControl = new Control();

		private bool canUpdate = true;

		private List<string> pkeys = new List<string>();

		private Stock_DataDataContext dbInstance;

		private T_tel data_this;

		private Rate_DataDataContext dbInstanceRate;

		private T_User permission = new T_User();

#pragma warning disable CS0414 // The field 'FrmTelToLeave.Pas' is assigned but its value is never used
		private bool Pas;
#pragma warning restore CS0414 // The field 'FrmTelToLeave.Pas' is assigned but its value is never used

#pragma warning disable CS0414 // The field 'FrmTelToLeave.Ps' is assigned but its value is never used
		private string Ps;
#pragma warning restore CS0414 // The field 'FrmTelToLeave.Ps' is assigned but its value is never used

		private int Op;

#pragma warning disable CS0414 // The field 'FrmTelToLeave.M' is assigned but its value is never used
		private int M;
#pragma warning restore CS0414 // The field 'FrmTelToLeave.M' is assigned but its value is never used

#pragma warning disable CS0169 // The field 'FrmTelToLeave.R1' is never used
		private int R1;
#pragma warning restore CS0169 // The field 'FrmTelToLeave.R1' is never used

#pragma warning disable CS0169 // The field 'FrmTelToLeave.R2' is never used
		private int R2;
#pragma warning restore CS0169 // The field 'FrmTelToLeave.R2' is never used

#pragma warning disable CS0169 // The field 'FrmTelToLeave.R3' is never used
		private int R3;
#pragma warning restore CS0169 // The field 'FrmTelToLeave.R3' is never used

#pragma warning disable CS0414 // The field 'FrmTelToLeave.vChk' is assigned but its value is never used
		private bool vChk;
#pragma warning restore CS0414 // The field 'FrmTelToLeave.vChk' is assigned but its value is never used

		private T_GDHEAD _GdHead = new T_GDHEAD();

		private List<T_GDHEAD> listGdHead = new List<T_GDHEAD>();

		private T_GDDET _GdDet = new T_GDDET();

		private List<T_GDDET> listGdDet = new List<T_GDDET>();

		private ProShared.ScriptNumber ScriptNumber1 = new ProShared.ScriptNumber();

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

		public T_tel DataThis
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
					if (!VarGeneral.TString.ChkStatShow(value.RepAcc2, 6))
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTelToLeave));
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
            this.labelGaidStat = new System.Windows.Forms.Label();
            this.txtRoom = new System.Windows.Forms.TextBox();
            this.labelGuestStat = new System.Windows.Forms.Label();
            this.switchButton_Lock = new DevComponents.DotNetBar.Controls.SwitchButton();
            this.panel_Gaid = new System.Windows.Forms.Panel();
            this.button_CustC1 = new DevComponents.DotNetBar.ButtonX();
            this.button_CustD1 = new DevComponents.DotNetBar.ButtonX();
            this.txtDebit1 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtCredit1 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelD1 = new System.Windows.Forms.Label();
            this.labelC1 = new System.Windows.Forms.Label();
            this.Text6 = new DevComponents.Editors.DoubleInput();
            this.Text4 = new DevComponents.Editors.IntegerInput();
            this.Text3 = new DevComponents.Editors.IntegerInput();
            this.Text5 = new DevComponents.Editors.IntegerInput();
            this.Command3 = new DevComponents.DotNetBar.ButtonX();
            this.label17 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Text2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label15 = new System.Windows.Forms.MaskedTextBox();
            this.Label16 = new System.Windows.Forms.TextBox();
            this.label36 = new System.Windows.Forms.Label();
            this.textBox_ID = new System.Windows.Forms.TextBox();
            this.label38 = new System.Windows.Forms.Label();
            this.ribbonBar_Tasks = new DevComponents.DotNetBar.RibbonBar();
            this.superTabControl_Main1 = new DevComponents.DotNetBar.SuperTabControl();
            this.Button_Close = new DevComponents.DotNetBar.ButtonItem();
            this.Button_Search = new DevComponents.DotNetBar.ButtonItem();
            this.Button_Save = new DevComponents.DotNetBar.ButtonItem();
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
            this.panelEx2.SuspendLayout();
            this.ribbonBar1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel_Gaid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Text6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Text4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Text3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Text5)).BeginInit();
            this.ribbonBar_Tasks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl_Main1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl_Main2)).BeginInit();
            this.panelEx3.SuspendLayout();
            this.ribbonBar_DGV.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl_DGV)).BeginInit();
            this.panel1.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            // 
            // expandableSplitter1
            // 
            this.expandableSplitter1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
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
            this.expandableSplitter1.Location = new System.Drawing.Point(0, 1);
            this.expandableSplitter1.Name = "expandableSplitter1";
            this.expandableSplitter1.Size = new System.Drawing.Size(649, 14);
            this.expandableSplitter1.TabIndex = 1;
            this.expandableSplitter1.TabStop = false;
            // 
            // panelEx2
            // 
            this.panelEx2.Controls.Add(this.ribbonBar1);
            this.panelEx2.Controls.Add(this.ribbonBar_Tasks);
            this.panelEx2.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelEx2.Location = new System.Drawing.Point(0, 15);
            this.panelEx2.MinimumSize = new System.Drawing.Size(659, 273);
            this.panelEx2.Name = "panelEx2";
            this.panelEx2.Size = new System.Drawing.Size(659, 273);
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
            this.ribbonBar1.DragDropSupport = true;
            this.ribbonBar1.Location = new System.Drawing.Point(0, 0);
            this.ribbonBar1.Name = "ribbonBar1";
            this.ribbonBar1.Size = new System.Drawing.Size(659, 222);
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
            // panel2
            // 
            this.panel2.Controls.Add(this.labelGaidStat);
            this.panel2.Controls.Add(this.txtRoom);
            this.panel2.Controls.Add(this.labelGuestStat);
            this.panel2.Controls.Add(this.switchButton_Lock);
            this.panel2.Controls.Add(this.panel_Gaid);
            this.panel2.Controls.Add(this.Text6);
            this.panel2.Controls.Add(this.Text4);
            this.panel2.Controls.Add(this.Text3);
            this.panel2.Controls.Add(this.Text5);
            this.panel2.Controls.Add(this.Command3);
            this.panel2.Controls.Add(this.label17);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.Text2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label19);
            this.panel2.Controls.Add(this.Label2);
            this.panel2.Controls.Add(this.Label15);
            this.panel2.Controls.Add(this.Label16);
            this.panel2.Controls.Add(this.label36);
            this.panel2.Controls.Add(this.textBox_ID);
            this.panel2.Controls.Add(this.label38);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(659, 205);
            this.panel2.TabIndex = 87;
            // 
            // labelGaidStat
            // 
            this.labelGaidStat.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.labelGaidStat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelGaidStat.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.labelGaidStat.ForeColor = System.Drawing.Color.White;
            this.labelGaidStat.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelGaidStat.Location = new System.Drawing.Point(42, 141);
            this.labelGaidStat.Name = "labelGaidStat";
            this.labelGaidStat.Size = new System.Drawing.Size(529, 60);
            this.labelGaidStat.TabIndex = 6747;
            this.labelGaidStat.Text = "لقد تم انشاء قيد محاسبي لهذا السجل مسبقا \r\n\r\nوتم ترحيله واحتسابه مع عملية إقفــال" +
    " السنة";
            this.labelGaidStat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelGaidStat.Visible = false;
            // 
            // txtRoom
            // 
            this.txtRoom.BackColor = System.Drawing.Color.White;
            this.txtRoom.Enabled = false;
            this.txtRoom.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.txtRoom.ForeColor = System.Drawing.Color.Maroon;
            this.txtRoom.Location = new System.Drawing.Point(397, 37);
            this.txtRoom.MaxLength = 150;
            this.txtRoom.Name = "txtRoom";
            this.txtRoom.ReadOnly = true;
            this.txtRoom.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtRoom.Size = new System.Drawing.Size(106, 20);
            this.txtRoom.TabIndex = 6746;
            this.txtRoom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelGuestStat
            // 
            this.labelGuestStat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelGuestStat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelGuestStat.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.labelGuestStat.ForeColor = System.Drawing.Color.White;
            this.labelGuestStat.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelGuestStat.Location = new System.Drawing.Point(578, 141);
            this.labelGuestStat.Name = "labelGuestStat";
            this.labelGuestStat.Size = new System.Drawing.Size(66, 60);
            this.labelGuestStat.TabIndex = 6745;
            this.labelGuestStat.Text = "نزيل\r\n\r\nمغادر";
            this.labelGuestStat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // switchButton_Lock
            // 
            // 
            // 
            // 
            this.switchButton_Lock.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.switchButton_Lock.Font = new System.Drawing.Font("Tahoma", 8F);
            this.switchButton_Lock.Location = new System.Drawing.Point(321, 142);
            this.switchButton_Lock.Name = "switchButton_Lock";
            this.switchButton_Lock.OffBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(80)))), ((int)(((byte)(77)))));
            this.switchButton_Lock.OffText = "إنشاء قيد محاسبي";
            this.switchButton_Lock.OffTextColor = System.Drawing.Color.White;
            this.switchButton_Lock.OnBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.switchButton_Lock.OnText = "إنشاء قيد محاسبي";
            this.switchButton_Lock.OnTextColor = System.Drawing.Color.White;
            this.switchButton_Lock.Size = new System.Drawing.Size(249, 26);
            this.switchButton_Lock.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.switchButton_Lock.SwitchWidth = 50;
            this.switchButton_Lock.TabIndex = 6744;
            this.switchButton_Lock.ValueChanged += new System.EventHandler(this.switchButton_Lock_ValueChanged);
            this.switchButton_Lock.Click += new System.EventHandler(this.switchButton_Lock_Click);
            // 
            // panel_Gaid
            // 
            this.panel_Gaid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_Gaid.Controls.Add(this.button_CustC1);
            this.panel_Gaid.Controls.Add(this.button_CustD1);
            this.panel_Gaid.Controls.Add(this.txtDebit1);
            this.panel_Gaid.Controls.Add(this.txtCredit1);
            this.panel_Gaid.Controls.Add(this.labelD1);
            this.panel_Gaid.Controls.Add(this.labelC1);
            this.panel_Gaid.Enabled = false;
            this.panel_Gaid.Location = new System.Drawing.Point(42, 151);
            this.panel_Gaid.Name = "panel_Gaid";
            this.panel_Gaid.Size = new System.Drawing.Size(529, 50);
            this.panel_Gaid.TabIndex = 6743;
            // 
            // button_CustC1
            // 
            this.button_CustC1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_CustC1.Checked = true;
            this.button_CustC1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_CustC1.Location = new System.Drawing.Point(13, 22);
            this.button_CustC1.Name = "button_CustC1";
            this.button_CustC1.Size = new System.Drawing.Size(15, 16);
            this.button_CustC1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_CustC1.Symbol = "";
            this.button_CustC1.SymbolSize = 7F;
            this.button_CustC1.TabIndex = 1133;
            this.button_CustC1.TextColor = System.Drawing.Color.SteelBlue;
            this.button_CustC1.Tooltip = "حساب النزيل";
            this.button_CustC1.Click += new System.EventHandler(this.button_CustC1_Click);
            // 
            // button_CustD1
            // 
            this.button_CustD1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_CustD1.Checked = true;
            this.button_CustD1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_CustD1.Location = new System.Drawing.Point(262, 22);
            this.button_CustD1.Name = "button_CustD1";
            this.button_CustD1.Size = new System.Drawing.Size(15, 16);
            this.button_CustD1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_CustD1.Symbol = "";
            this.button_CustD1.SymbolSize = 7F;
            this.button_CustD1.TabIndex = 1132;
            this.button_CustD1.TextColor = System.Drawing.Color.SteelBlue;
            this.button_CustD1.Tooltip = "حساب العميل";
            this.button_CustD1.Click += new System.EventHandler(this.button_CustD1_Click);
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
            this.txtDebit1.Location = new System.Drawing.Point(280, 22);
            this.txtDebit1.Name = "txtDebit1";
            this.txtDebit1.ReadOnly = true;
            this.txtDebit1.Size = new System.Drawing.Size(179, 16);
            this.txtDebit1.TabIndex = 1130;
            this.txtDebit1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            this.txtCredit1.Location = new System.Drawing.Point(31, 22);
            this.txtCredit1.Name = "txtCredit1";
            this.txtCredit1.ReadOnly = true;
            this.txtCredit1.Size = new System.Drawing.Size(179, 16);
            this.txtCredit1.TabIndex = 1131;
            this.txtCredit1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelD1
            // 
            this.labelD1.AutoSize = true;
            this.labelD1.BackColor = System.Drawing.Color.Transparent;
            this.labelD1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelD1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.labelD1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelD1.Location = new System.Drawing.Point(460, 24);
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
            this.labelC1.Location = new System.Drawing.Point(212, 24);
            this.labelC1.Name = "labelC1";
            this.labelC1.Size = new System.Drawing.Size(40, 13);
            this.labelC1.TabIndex = 1129;
            this.labelC1.Text = "الدائن :";
            // 
            // Text6
            // 
            this.Text6.AllowEmptyState = false;
            this.Text6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.Text6.BackgroundStyle.Class = "DateTimeInputBackground";
            this.Text6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Text6.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.Text6.DisplayFormat = "0.00";
            this.Text6.Enabled = false;
            this.Text6.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.Text6.Increment = 0D;
            this.Text6.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.Text6.Location = new System.Drawing.Point(45, 112);
            this.Text6.MinValue = 0D;
            this.Text6.Name = "Text6";
            this.Text6.Size = new System.Drawing.Size(458, 27);
            this.Text6.TabIndex = 8;
            // 
            // Text4
            // 
            this.Text4.AllowEmptyState = false;
            // 
            // 
            // 
            this.Text4.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
            this.Text4.BackgroundStyle.Class = "DateTimeInputBackground";
            this.Text4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Text4.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.Text4.DisplayFormat = "0";
            this.Text4.Enabled = false;
            this.Text4.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.Text4.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.Text4.Location = new System.Drawing.Point(259, 85);
            this.Text4.MinValue = 0;
            this.Text4.Name = "Text4";
            this.Text4.Size = new System.Drawing.Size(67, 24);
            this.Text4.TabIndex = 6;
            this.Text4.Leave += new System.EventHandler(this.Text5_Leave);
            // 
            // Text3
            // 
            this.Text3.AllowEmptyState = false;
            // 
            // 
            // 
            this.Text3.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
            this.Text3.BackgroundStyle.Class = "DateTimeInputBackground";
            this.Text3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Text3.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.Text3.DisplayFormat = "0";
            this.Text3.Enabled = false;
            this.Text3.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.Text3.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.Text3.Location = new System.Drawing.Point(87, 85);
            this.Text3.MinValue = 0;
            this.Text3.Name = "Text3";
            this.Text3.Size = new System.Drawing.Size(67, 24);
            this.Text3.TabIndex = 7;
            this.Text3.Leave += new System.EventHandler(this.Text5_Leave);
            // 
            // Text5
            // 
            this.Text5.AllowEmptyState = false;
            // 
            // 
            // 
            this.Text5.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
            this.Text5.BackgroundStyle.Class = "DateTimeInputBackground";
            this.Text5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Text5.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.Text5.DisplayFormat = "0";
            this.Text5.Enabled = false;
            this.Text5.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.Text5.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.Text5.Location = new System.Drawing.Point(436, 85);
            this.Text5.MinValue = 0;
            this.Text5.Name = "Text5";
            this.Text5.Size = new System.Drawing.Size(67, 24);
            this.Text5.TabIndex = 5;
            this.Text5.Leave += new System.EventHandler(this.Text5_Leave);
            // 
            // Command3
            // 
            this.Command3.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.Command3.Checked = true;
            this.Command3.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.Command3.Location = new System.Drawing.Point(45, 112);
            this.Command3.Name = "Command3";
            this.Command3.Size = new System.Drawing.Size(231, 27);
            this.Command3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.Command3.Symbol = "";
            this.Command3.SymbolSize = 12F;
            this.Command3.TabIndex = 9;
            this.Command3.Text = "حساب التكلفة";
            this.Command3.TextColor = System.Drawing.Color.SteelBlue;
            this.Command3.Visible = false;
            this.Command3.Click += new System.EventHandler(this.Command3_Click);
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label17.ForeColor = System.Drawing.Color.Navy;
            this.label17.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label17.Location = new System.Drawing.Point(504, 123);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(69, 14);
            this.label17.TabIndex = 1096;
            this.label17.Text = "القيمــــــة :";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.Maroon;
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(49, 90);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 14);
            this.label6.TabIndex = 1095;
            this.label6.Text = "ثانية";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.Maroon;
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(213, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 14);
            this.label5.TabIndex = 1093;
            this.label5.Text = "دقيقة";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.Maroon;
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(390, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 14);
            this.label4.TabIndex = 1091;
            this.label4.Text = "ساعة";
            // 
            // Text2
            // 
            this.Text2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Text2.Enabled = false;
            this.Text2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.Text2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Text2.Location = new System.Drawing.Point(45, 61);
            this.Text2.MaxLength = 25;
            this.Text2.Name = "Text2";
            this.Text2.Size = new System.Drawing.Size(118, 20);
            this.Text2.TabIndex = 4;
            this.Text2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Text2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_ID_KeyPress);
            this.Text2.Leave += new System.EventHandler(this.Text5_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(166, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 1053;
            this.label1.Text = "الهاتف :";
            // 
            // label19
            // 
            this.label19.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.Color.Transparent;
            this.label19.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label19.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label19.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label19.Location = new System.Drawing.Point(504, 41);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(66, 13);
            this.label19.TabIndex = 1051;
            this.label19.Text = "الغــــــرفــة :";
            // 
            // Label2
            // 
            this.Label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Label2.AutoSize = true;
            this.Label2.BackColor = System.Drawing.Color.Transparent;
            this.Label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Label2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Label2.Location = new System.Drawing.Point(166, 18);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(45, 13);
            this.Label2.TabIndex = 482;
            this.Label2.Text = "التاريـخ :";
            // 
            // Label15
            // 
            this.Label15.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Label15.Enabled = false;
            this.Label15.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.Label15.Location = new System.Drawing.Point(45, 14);
            this.Label15.Mask = "0000/00/00";
            this.Label15.Name = "Label15";
            this.Label15.Size = new System.Drawing.Size(118, 21);
            this.Label15.TabIndex = 2;
            this.Label15.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Label15.Click += new System.EventHandler(this.Label15_Click);
            this.Label15.Leave += new System.EventHandler(this.Label15_Leave);
            // 
            // Label16
            // 
            this.Label16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label16.Enabled = false;
            this.Label16.Font = new System.Drawing.Font("Tahoma", 8F);
            this.Label16.ForeColor = System.Drawing.Color.Black;
            this.Label16.Location = new System.Drawing.Point(226, 60);
            this.Label16.MaxLength = 100;
            this.Label16.Name = "Label16";
            this.Label16.ReadOnly = true;
            this.Label16.Size = new System.Drawing.Size(277, 20);
            this.Label16.TabIndex = 10;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.BackColor = System.Drawing.Color.Transparent;
            this.label36.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label36.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label36.Location = new System.Drawing.Point(504, 64);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(65, 13);
            this.label36.TabIndex = 90;
            this.label36.Text = "إسم النزيل :";
            // 
            // textBox_ID
            // 
            this.textBox_ID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.textBox_ID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_ID.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.textBox_ID.Location = new System.Drawing.Point(335, 14);
            this.textBox_ID.Name = "textBox_ID";
            this.textBox_ID.ReadOnly = true;
            this.textBox_ID.Size = new System.Drawing.Size(168, 21);
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
            this.label38.Location = new System.Drawing.Point(504, 18);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(66, 13);
            this.label38.TabIndex = 89;
            this.label38.Text = "رقم الفاتورة :";
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
            this.ribbonBar_Tasks.DragDropSupport = true;
            this.ribbonBar_Tasks.Location = new System.Drawing.Point(0, 222);
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
            this.superTabControl_Main1.Size = new System.Drawing.Size(249, 51);
            this.superTabControl_Main1.TabFont = new System.Drawing.Font("Tahoma", 8F);
            this.superTabControl_Main1.TabIndex = 10;
            this.superTabControl_Main1.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.Button_Close,
            this.Button_Search,
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
            this.superTabControl_Main2.Location = new System.Drawing.Point(249, 0);
            this.superTabControl_Main2.Name = "superTabControl_Main2";
            this.superTabControl_Main2.ReorderTabsEnabled = true;
            this.superTabControl_Main2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.superTabControl_Main2.SelectedTabFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.superTabControl_Main2.SelectedTabIndex = -1;
            this.superTabControl_Main2.Size = new System.Drawing.Size(410, 51);
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
            this.DGV_Main.Location = new System.Drawing.Point(0, 0);
            this.DGV_Main.Name = "DGV_Main";
            // 
            // 
            // 
            this.DGV_Main.PrimaryGrid.ActiveRowIndicatorStyle = DevComponents.DotNetBar.SuperGrid.ActiveRowIndicatorStyle.Both;
            this.DGV_Main.PrimaryGrid.AllowEdit = false;
            // 
            // 
            // 
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
            // 
            // 
            // 
            this.DGV_Main.PrimaryGrid.GroupByRow.RowHeaderVisibility = DevComponents.DotNetBar.SuperGrid.RowHeaderVisibility.Never;
            this.DGV_Main.PrimaryGrid.GroupByRow.Text = "جميــع السجــــلات";
            this.DGV_Main.PrimaryGrid.GroupByRow.Visible = true;
            this.DGV_Main.PrimaryGrid.GroupByRow.WatermarkText = "";
            this.DGV_Main.PrimaryGrid.InitialActiveRow = DevComponents.DotNetBar.SuperGrid.RelativeRow.None;
            this.DGV_Main.PrimaryGrid.InitialSelection = DevComponents.DotNetBar.SuperGrid.RelativeSelection.None;
            this.DGV_Main.PrimaryGrid.MultiSelect = false;
            this.DGV_Main.PrimaryGrid.ShowRowGridIndex = true;
            // 
            // 
            // 
            this.DGV_Main.PrimaryGrid.Title.AllowSelection = false;
            this.DGV_Main.PrimaryGrid.Title.Text = "";
            this.DGV_Main.PrimaryGrid.Title.Visible = false;
            this.DGV_Main.PrimaryGrid.Visible = false;
            this.DGV_Main.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.DGV_Main.Size = new System.Drawing.Size(649, 0);
            this.DGV_Main.TabIndex = 862;
            // 
            // panelEx3
            // 
            this.panelEx3.Controls.Add(this.DGV_Main);
            this.panelEx3.Controls.Add(this.ribbonBar_DGV);
            this.panelEx3.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx3.Location = new System.Drawing.Point(0, 0);
            this.panelEx3.Name = "panelEx3";
            this.panelEx3.Size = new System.Drawing.Size(649, 1);
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
            this.ribbonBar_DGV.DragDropSupport = true;
            this.ribbonBar_DGV.Location = new System.Drawing.Point(0, -50);
            this.ribbonBar_DGV.Name = "ribbonBar_DGV";
            this.ribbonBar_DGV.Size = new System.Drawing.Size(649, 51);
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
            this.superTabControl_DGV.Size = new System.Drawing.Size(649, 51);
            this.superTabControl_DGV.TabFont = new System.Drawing.Font("Tahoma", 8F);
            this.superTabControl_DGV.TabIndex = 12;
            this.superTabControl_DGV.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.textBox_search,
            this.Button_ExportTable2,
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
            this.panel1.Size = new System.Drawing.Size(649, 288);
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
            this.barBottomDockSite.Location = new System.Drawing.Point(0, 288);
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
            this.barLeftDockSite.Size = new System.Drawing.Size(0, 288);
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
            this.barRightDockSite.Size = new System.Drawing.Size(0, 288);
            this.barRightDockSite.TabIndex = 892;
            this.barRightDockSite.TabStop = false;
            // 
            // dockSite4
            // 
            this.dockSite4.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dockSite4.Location = new System.Drawing.Point(0, 288);
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
            this.dockSite1.Size = new System.Drawing.Size(0, 288);
            this.dockSite1.TabIndex = 893;
            this.dockSite1.TabStop = false;
            // 
            // dockSite2
            // 
            this.dockSite2.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite2.Dock = System.Windows.Forms.DockStyle.Right;
            this.dockSite2.Location = new System.Drawing.Point(649, 0);
            this.dockSite2.Name = "dockSite2";
            this.dockSite2.Size = new System.Drawing.Size(0, 288);
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
            // FrmTelToLeave
            // 
            this.ClientSize = new System.Drawing.Size(649, 288);
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
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "FrmTelToLeave";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "مكالمات النزلاء";
            this.Load += new System.EventHandler(this.FrmTelToLeave_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Frm_KeyPress);
            this.panelEx2.ResumeLayout(false);
            this.ribbonBar1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel_Gaid.ResumeLayout(false);
            this.panel_Gaid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Text6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Text4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Text3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Text5)).EndInit();
            this.ribbonBar_Tasks.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl_Main1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl_Main2)).EndInit();
            this.panelEx3.ResumeLayout(false);
            this.ribbonBar_DGV.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl_DGV)).EndInit();
            this.panel1.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
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
				if (LangArEn == 0)
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
				if (LangArEn == 0)
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
				if (LangArEn == 0)
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
			if (LangArEn == 0)
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
			VarGeneral.SFrmTyp = "T_telToLeave";
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
			List<T_tel> list = db.FillTelToLeave_2(textBox_search.TextBox.Text).ToList();
			if (DGV_Main.PrimaryGrid.Columns.Count == 0)
			{
				foreach (KeyValuePair<string, ColumnDictinary> item in columns_Names_visible)
				{
					DGV_Main.PrimaryGrid.Columns.Add(new GridColumn(item.Key));
				}
			}
			FillHDGV(list);
		}

		public void FillHDGV(IEnumerable<T_tel> new_data_enum)
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
			DGV_Main.PrimaryGrid.DataMember = "T_tel";
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
			data_this = new T_tel();
			_GdHead = new T_GDHEAD();
			State = FormState.New;
			for (int i = 0; i < controls.Count; i++)
			{
				if (controls[i].GetType() == typeof(DateTimePicker))
				{
					int? calendr = VarGeneral.Settings_Sys.Calendr;
					if (calendr.GetValueOrDefault() == 0 && calendr.HasValue)
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
			textBox_ID.Focus();
			M = 1;
			Op = 0;
			Ps = "";
			Pas = true;
			vChk = false;
			switchButton_Lock.Value = false;
			labelGaidStat.Visible = false;
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
			if (e.KeyCode == Keys.F2 && Button_Save.Enabled && Button_Save.Visible && State != 0)
			{
				Button_Save_Click(sender, e);
			}
			else if (e.KeyCode == Keys.F4 && Button_Search.Enabled && Button_Search.Visible)
			{
				Button_Search_Click(sender, e);
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
			var qkeys = from item in db.T_tels
				where item.T_per.ch == (int?)3
				select new
				{
					Code = item.ID + ""
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

		public FrmTelToLeave()
		{
			InitializeComponent();
			controls = new List<Control>();
			controls.Add(textBox_ID);
			codeControl = textBox_ID;
			controls.Add(Label16);
			controls.Add(Text2);
			controls.Add(Text3);
			controls.Add(Text4);
			controls.Add(Text5);
			controls.Add(Text6);
			controls.Add(Label15);
			controls.Add(txtRoom);
			controls.Add(txtDebit1);
			controls.Add(txtCredit1);
			controls.Add(switchButton_Lock);
			Button_Close.Click += Button_Close_Click;
			Label16.Click += Button_Edit_Click;
			Text2.Click += Button_Edit_Click;
			Text3.Click += Button_Edit_Click;
			Text4.Click += Button_Edit_Click;
			Text5.Click += Button_Edit_Click;
			Text6.Click += Button_Edit_Click;
			Label15.Click += Button_Edit_Click;
			txtDebit1.Click += Button_Edit_Click;
			txtCredit1.Click += Button_Edit_Click;
			expandableSplitter1.Click += expandableSplitter1_Click;
			ToolStripMenuItem_Det.Click += ToolStripMenuItem_Det_Click;
			Button_ExportTable2.Click += Button_ExportTable2_Click;
			Button_First.Click += Button_First_Click;
			Button_Prev.Click += Button_Prev_Click;
			Button_Next.Click += Button_Next_Click;
			Button_Last.Click += Button_Last_Click;
			Button_Search.Click += Button_Search_Click;
			Button_Save.Click += Button_Save_Click;
			txtDebit1.ButtonCustomClick += txtDebit1_ButtonCustomClick;
			txtCredit1.ButtonCustomClick += txtCredit1_ButtonCustomClick;
			textBox_search.InputTextChanged += TextBox_Search_InputTextChanged;
			textBox_search.ButtonCustomClick += TextBox_Search_ButtonCustomClick;
			TextBox_Index.InputTextChanged += TextBox_Index_InputTextChanged;
			DGV_Main.MouseDown += DGV_Main_MouseDown;
			DGV_Main.CellDoubleClick += DGV_Main_CellDoubleClick;
			DGV_Main.CellClick += DGV_Main_CellClick;
			DGV_Main.GetCellStyle += DGV_MainGetCellStyle;
			DGV_Main.CellDoubleClick += DGV_Main_CellDoubleClick;
			DGV_Main.DataBindingComplete += DGV_Main_DataBindingComplete;
		}

		private void RibunButtons()
		{
			if (LangArEn == 0)
			{
				Button_First.Text = "الأول";
				Button_Last.Text = "الأخير";
				Button_Next.Text = "التالي";
				Button_Prev.Text = "السابق";
				Button_Close.Text = "اغلاق";
				Button_Save.Text = "حفظ";
				Button_Search.Text = "بحث";
				Button_First.Tooltip = "السجل الاول";
				Button_Last.Tooltip = "السجل الاخير";
				Button_Next.Tooltip = "السجل التالي";
				Button_Prev.Tooltip = "السجل السابق";
				Button_Close.Tooltip = "Esc";
				Button_Save.Tooltip = "F2";
				Button_Search.Tooltip = "F4";
				Button_ExportTable2.Text = "تصدير";
				Button_ExportTable2.Tooltip = "F10";
				switchButton_Lock.OffText = "إنشاء قيد محاسبي";
				switchButton_Lock.OnText = "إنشاء قيد محاسبي";
				DGV_Main.PrimaryGrid.GroupByRow.Text = "جميع السجلات";
				Text = "المكالمات الهاتفية للنزلاء المغادرين";
			}
			else
			{
				Button_First.Text = "First";
				Button_Last.Text = "Last";
				Button_Next.Text = "Next";
				Button_Prev.Text = "Previous";
				Button_Close.Text = "Close";
				Button_Save.Text = "Save";
				Button_Search.Text = "Search";
				Button_First.Tooltip = "First Record";
				Button_Last.Tooltip = "Last Record";
				Button_Next.Tooltip = "Next Record";
				Button_Prev.Tooltip = "Previous Record";
				Button_Close.Tooltip = "Esc";
				Button_Save.Tooltip = "F2";
				Button_Search.Tooltip = "F4";
				Button_ExportTable2.Text = "Export";
				Button_ExportTable2.Tooltip = "F10";
				switchButton_Lock.OffText = "Create an accounting record";
				switchButton_Lock.OnText = "Create an accounting record";
				DGV_Main.PrimaryGrid.GroupByRow.Text = "All Records";
				labelGuestStat.Text = "Guest Leaved";
				labelGaidStat.Text = "The accounting record was derecognized at the close of the year";
				Text = "Telephone calls to departing guests";
			}
		}

		private void FrmTelToLeave_Load(object sender, EventArgs e)
		{
			try
			{
				ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmTelToLeave));
				if (base.Tag.ToString() == "0")
				{
					SSSLanguage.Language.ChangeLanguage("ar-SA", this, resources);
					LangArEn = 0;
				}
				else
				{
					SSSLanguage.Language.ChangeLanguage("en", this, resources);
					LangArEn = 1;
				}
				Permmission = dbc.Get_PermissionID(VarGeneral.UserID);
				if (columns_Names_visible.Count == 0)
				{
					columns_Names_visible.Add("ID", new ColumnDictinary("رقم الفاتورة", "Inv No", ifDefault: true, ""));
					columns_Names_visible.Add("perno", new ColumnDictinary("رقم النزيل", "Guest No", ifDefault: true, ""));
					columns_Names_visible.Add("romno", new ColumnDictinary("رقم الغرفة", "Room Np", ifDefault: true, ""));
					columns_Names_visible.Add("price", new ColumnDictinary("المبلغ المطلوب", "Value", ifDefault: true, ""));
				}
				else
				{
					Clear();
					textBox_ID.Text = "";
					TextBox_Index.TextBox.Text = "";
				}
				RibunButtons();
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
			try
			{
				T_tel newData = db.StockTel(no);
				if (newData == null || newData.ID == 0)
				{
					Clear();
					TextBox_Index.InputTextChanged -= TextBox_Index_InputTextChanged;
					TextBox_Index.TextBox.Text = string.Concat(PKeys.Count + 1);
					TextBox_Index.InputTextChanged += TextBox_Index_InputTextChanged;
				}
				else
				{
					DataThis = newData;
					int indexA = PKeys.IndexOf(string.Concat(newData.ID));
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

		public void SetData(T_tel value)
		{
			switchButton_Lock.ValueChanged -= switchButton_Lock_ValueChanged;
			try
			{
				State = FormState.Saved;
				Button_Save.Enabled = false;
				Label16.Tag = data_this.perno;
				Label16.Text = ((LangArEn == 0) ? data_this.T_per.T_AccDef.Arb_Des : data_this.T_per.T_AccDef.Eng_Des);
				if (value.romno.HasValue)
				{
					txtRoom.Text = data_this.romno.Value.ToString();
				}
				Text2.Text = data_this.tel;
				Text3.Value = int.Parse(data_this.s.Value.ToString());
				Text4.Value = int.Parse(data_this.m.Value.ToString());
				Text5.Value = int.Parse(data_this.h.Value.ToString());
				Op = data_this.op.Value;
				Text6.Value = data_this.price.Value;
				Label15.Text = data_this.dt;
				txtDebit1.Text = "";
				txtCredit1.Text = "";
				if (value.GadeId.HasValue)
				{
					listGdHead = db.StockGdHeadid((int)value.GadeId.Value);
					if (listGdHead.Count != 0)
					{
						_GdHead = listGdHead[0];
						listGdDet = _GdHead.T_GDDETs.ToList();
						for (int i = 0; i < listGdDet.Count; i++)
						{
							if (listGdDet[i].Lin == 1)
							{
								if (listGdDet[i].gdValue > 0.0)
								{
									txtDebit1.Tag = listGdDet[i].AccNo;
									txtDebit1.Text = ((LangArEn == 0) ? db.SelectAccRootByCode(listGdDet[i].AccNo).Arb_Des : db.SelectAccRootByCode(listGdDet[i].AccNo).Eng_Des);
								}
								else
								{
									txtCredit1.Tag = listGdDet[i].AccNo;
									txtCredit1.Text = ((LangArEn == 0) ? db.SelectAccRootByCode(listGdDet[i].AccNo).Arb_Des : db.SelectAccRootByCode(listGdDet[i].AccNo).Eng_Des);
								}
							}
						}
					}
					else
					{
						_GdHead = new T_GDHEAD();
					}
				}
				try
				{
					switchButton_Lock.Value = value.IsGaid.Value;
					panel_Gaid.Enabled = value.IsGaid.Value;
				}
				catch
				{
					switchButton_Lock.Value = false;
					panel_Gaid.Enabled = false;
				}
				if (data_this.GadeNo == 0.0 && VarGeneral.UserID != 1)
				{
					labelGaidStat.Visible = true;
				}
				else
				{
					labelGaidStat.Visible = false;
				}
			}
			catch (Exception error)
			{
				VarGeneral.DebLog.writeLog("SetData:", error, enable: true);
				MessageBox.Show(error.Message);
			}
			switchButton_Lock.ValueChanged += switchButton_Lock_ValueChanged;
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

		private T_tel GetData()
		{
			textBox_ID.Focus();
			data_this.perno = int.Parse(Label16.Tag.ToString());
			data_this.ino = int.Parse(textBox_ID.Text);
			data_this.ID = int.Parse(textBox_ID.Text);
			data_this.romno = int.Parse(txtRoom.Text);
			data_this.tel = Text2.Text;
			data_this.s = Text3.Value;
			data_this.m = Text4.Value;
			data_this.h = Text5.Value;
			data_this.op = Op;
			data_this.price = Text6.Value;
			data_this.Usr = VarGeneral.UserNo;
			data_this.dt = Label15.Text;
			data_this.IsGaid = switchButton_Lock.Value;
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
				if (State == FormState.New)
				{
					MessageBox.Show((LangArEn == 0) ? "لا يمكن اتمام هذه العملية .. الرجاء مراجعة صلاحيات المستخدمين !" : "Can not complete this process .. please see the powers of the users!", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
					return;
				}
				textBox_ID.Focus();
				if (textBox_ID.Text == "" || Label16.Text == "" || txtRoom.Text == "" || Text6.Value <= 0.0 || string.IsNullOrEmpty(Text2.Text))
				{
					MessageBox.Show((LangArEn == 0) ? "هناك بيانات ناقصة .. حاول مرة اخرى" : "There are incomplete data .. Try again", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
					return;
				}
				if (switchButton_Lock.Value && (string.IsNullOrEmpty(txtCredit1.Text) || string.IsNullOrEmpty(txtDebit1.Text)))
				{
					MessageBox.Show((LangArEn == 0) ? "لا يمكن إتمام العملية .. تأكد من صحة الطرف الدائن والمدين للقيد .. " : "You can not complete the operation .. Make sure the creditor and debitor under the party ..", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
					return;
				}
				if (State == FormState.New)
				{
					GetData();
					try
					{
						db.T_tels.InsertOnSubmit(data_this);
						db.SubmitChanges();
					}
					catch (SqlException ex)
					{
						int max = 0;
						max = db.MaxTelNo;
						if (ex.Number != 2627)
						{
							return;
						}
						MessageBox.Show("رقم الوحدة مستخدم من قبل.\n سيتم الحفظ برقم جديد [" + max + "]", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Question);
						textBox_ID.Text = string.Concat(max);
						data_this.ID = max;
						Button_Save_Click(sender, e);
					}
					catch (Exception)
					{
						return;
					}
				}
				else if (State == FormState.Edit)
				{
					GetData();
					try
					{
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
				}
				string AccCrdt = "";
				string AccDbt = "";
				if (!switchButton_Lock.Value)
				{
					goto IL_03e2;
				}
				if (Text6.Value > 0.0)
				{
					AccCrdt = txtCredit1.Tag.ToString();
					AccDbt = txtDebit1.Tag.ToString();
				}
				if (AccCrdt == "" && Text6.Value > 0.0)
				{
					MessageBox.Show((LangArEn == 0) ? "لا يمكن إتمام العملية .. تأكد من صحة الطرف الدائن للقيد .. " : "You can not complete the operation .. Make sure the creditor under the party ..", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
					return;
				}
				if (!(AccDbt == "") || !(Text6.Value > 0.0))
				{
					goto IL_03e2;
				}
				MessageBox.Show((LangArEn == 0) ? "لا يمكن إتمام العملية .. تأكد من صحة الطرف المدين للقيد .. " : "You can not complete the operation .. Make sure the debtor under the party ..", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
				goto end_IL_0001;
				IL_03e2:
				if (Text6.Value > 0.0 && !string.IsNullOrEmpty(AccCrdt) && !string.IsNullOrEmpty(AccDbt))
				{
					IDatabase db_ = Database.GetDatabase(VarGeneral.BranchCS);
					 Stock_DataDataContext dbc = new Stock_DataDataContext(VarGeneral.BranchCS);
					if (State == FormState.New)
					{
						GetDataGd();
						_GdHead.DATE_CREATED = DateTime.Now;
						dbc.T_GDHEADs.InsertOnSubmit(_GdHead);
						dbc.SubmitChanges();
					}
					else
					{
						dbInstance = null;
						if (!data_this.GadeId.HasValue)
						{
							_GdHead = new T_GDHEAD();
						}
						textBox_ID_TextChanged(null, null);
						GetDataGd();
						if (!data_this.GadeId.HasValue)
						{
							dbc.T_GDHEADs.InsertOnSubmit(_GdHead);
							dbc.SubmitChanges();
						}
						else
						{
							db.Log = VarGeneral.DebugLog;
							db.SubmitChanges(ConflictMode.ContinueOnConflict);
						}
						for (int i = 0; i < _GdHead.T_GDDETs.Count; i++)
						{
							db_.StartTransaction();
							db_.ClearParameters();
							db_.AddParameter("GDDET_ID", DbType.Int32, _GdHead.T_GDDETs[i].GDDET_ID);
							db_.ExecuteNonQueryWithoutCommit(storedProcedure: true, "S_T_GDDET_DELETE");
							db_.EndTransaction();
						}
					}
					if (Text6.Value > 0.0 && !string.IsNullOrEmpty(AccCrdt) && !string.IsNullOrEmpty(AccDbt))
					{
						db_.StartTransaction();
						db_.ClearParameters();
						db_.AddParameter("GDDET_ID", DbType.Int32, 0);
						db_.AddParameter("gdID", DbType.Int32, _GdHead.gdhead_ID);
						db_.AddParameter("gdNo", DbType.String, textBox_ID.Text);
						db_.AddParameter("gdDes", DbType.String, "قيد تلقائي لعملية اضافة خدمة نزيل رقم : " + textBox_ID.Text);
						db_.AddParameter("gdDesE", DbType.String, "Auto Bound to add guest service : " + textBox_ID.Text);
						db_.AddParameter("recptTyp", DbType.String, "1");
						db_.AddParameter("AccNo", DbType.String, AccCrdt);
						db_.AddParameter("AccName", DbType.String, "");
						db_.AddParameter("gdValue", DbType.Double, 0.0 - double.Parse(Text6.Text));
						db_.AddParameter("recptNo", DbType.String, textBox_ID.Text);
						db_.AddParameter("Lin", DbType.Int32, 1);
						db_.AddParameter("AccNoDestruction", DbType.String, null);
						db_.ExecuteNonQueryWithoutCommit(storedProcedure: true, "S_T_GDDET_INSERT");
						db_.EndTransaction();
						db_.StartTransaction();
						db_.ClearParameters();
						db_.AddParameter("GDDET_ID", DbType.Int32, 0);
						db_.AddParameter("gdID", DbType.Int32, _GdHead.gdhead_ID);
						db_.AddParameter("gdNo", DbType.String, textBox_ID.Text);
						db_.AddParameter("gdDes", DbType.String, "قيد تلقائي لعملية اضافة خدمة نزيل رقم : " + textBox_ID.Text);
						db_.AddParameter("gdDesE", DbType.String, "Auto Bound to add guest service : " + textBox_ID.Text);
						db_.AddParameter("recptTyp", DbType.String, "1");
						db_.AddParameter("AccNo", DbType.String, AccDbt);
						db_.AddParameter("AccName", DbType.String, "");
						db_.AddParameter("gdValue", DbType.Double, double.Parse(Text6.Text));
						db_.AddParameter("recptNo", DbType.String, textBox_ID.Text);
						db_.AddParameter("Lin", DbType.Int32, 1);
						db_.AddParameter("AccNoDestruction", DbType.String, null);
						db_.ExecuteNonQueryWithoutCommit(storedProcedure: true, "S_T_GDDET_INSERT");
						db_.EndTransaction();
					}
				}
				else if (State == FormState.Edit && data_this.GadeId.HasValue)
				{
					db.ExecuteCommand("UPDATE T_GDHEAD SET T_GDHEAD.gdLok = 1  where gdhead_ID = " + data_this.GadeId);
				}
				dbInstance = null;
				textBox_ID_TextChanged(null, null);
				if (Text6.Value > 0.0 && !string.IsNullOrEmpty(AccCrdt) && !string.IsNullOrEmpty(AccDbt))
				{
					data_this.IsGaid = true;
					data_this.GadeId = _GdHead.gdhead_ID;
					data_this.GadeNo = int.Parse(textBox_ID.Text);
				}
				else
				{
					data_this.IsGaid = false;
					data_this.GadeId = null;
					data_this.GadeNo = null;
				}
				db.Log = VarGeneral.DebugLog;
				db.SubmitChanges(ConflictMode.ContinueOnConflict);
				State = FormState.Saved;
				RefreshPKeys();
				TextBox_Index.TextBox.Text = string.Concat(PKeys.IndexOf(string.Concat(data_this.ID)) + 1);
				textBox_ID_TextChanged(null, null);
				SetReadOnly = true;
				end_IL_0001:;
			}
			catch (Exception error)
			{
				VarGeneral.DebLog.writeLog("Save:", error, enable: true);
				MessageBox.Show(error.Message);
			}
		}

		private void Total()
		{
			try
			{
				string Cod = Text2.Text;
				string q = Cod.Substring(0, 1);
				if (int.Parse(q) != 0)
				{
					Op = 0;
				}
				else if (int.Parse(q) == 0)
				{
					string lp = "0";
					try
					{
						lp = Cod.Substring(0, 2);
					}
					catch
					{
						lp = "0";
					}
					string q2 = lp;
					if (int.Parse(q2) != 0)
					{
						Op = 1;
					}
					else if (int.Parse(q2) == 0)
					{
						int Cd;
						try
						{
							Cd = int.Parse(Cod.Substring(0, 5));
						}
						catch
						{
							Cd = 0;
						}
						List<cod> c = db.cods.Where((cod t) => t.cod1 == Cd).ToList();
						if (c.Count > 0)
						{
							Op = 2;
						}
						else if (Cd == 871 || Cd == 872 || Cd == 873)
						{
							Op = 4;
						}
						else
						{
							Op = 3;
						}
					}
				}
				List<T_telmn> Query = db.T_telmns.Where((T_telmn t) => t.pl == Op).ToList();
				int qq = 0;
				qq = ((Text3.Value > 0) ? 1 : 0);
				int hh = Text5.Value * 60;
				double Tot = (double)(Text4.Value + qq + hh) * Query[0].price.Value;
				double Tt = Tot * (double)Query[0].d.Value / 100.0;
				Text6.Value = Tot + Tt;
				Text6.Value = Text6.Value;
			}
			catch
			{
				Text6.Value = 0.0;
			}
		}

		private T_GDHEAD GetDataGd()
		{
			_GdHead.gdNo = textBox_ID.Text;
			_GdHead.ArbTaf = ScriptNumber1.ScriptNum(decimal.Parse("0" + Text6.Text));
			_GdHead.BName = _GdHead.BName;
			_GdHead.ChekNo = _GdHead.ChekNo;
			_GdHead.CurTyp = 1;
			_GdHead.EngTaf = ScriptNumber1.TafEng(decimal.Parse("0" + Text6.Text));
			_GdHead.gdCstNo = 1;
			_GdHead.gdID = 0;
			_GdHead.gdLok = false;
			_GdHead.gdMem = "قيد تلقائي لعملية اضافة خدمة نزيل  | Auto Bound to add guest service ";
			_GdHead.gdMnd = null;
			_GdHead.gdRcptID = (_GdHead.gdRcptID.HasValue ? _GdHead.gdRcptID.Value : 0.0);
			_GdHead.gdTot = Text6.Value;
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

		private void DGV_Main_DataBindingComplete(object sender, GridDataBindingCompleteEventArgs e)
		{
			GridPanel panel = e.GridPanel;
			string dataMember = panel.DataMember;
			if (dataMember != null && dataMember == "T_tel")
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
			panel.Columns["perno"].Width = 250;
			panel.Columns["perno"].Visible = columns_Names_visible["perno"].IfDefault;
			panel.Columns["romno"].Width = 250;
			panel.Columns["romno"].Visible = columns_Names_visible["romno"].IfDefault;
			panel.Columns["ID"].Width = 200;
			panel.Columns["ID"].Visible = columns_Names_visible["ID"].IfDefault;
			panel.Columns["price"].Width = 200;
			panel.Columns["price"].Visible = columns_Names_visible["price"].IfDefault;
			panel.ReadOnly = true;
		}

		private void DGV_MainGetCellStyle(object sender, GridGetCellStyleEventArgs e)
		{
		}

		private void Button_ExportTable2_Click(object sender, EventArgs e)
		{
			try
			{
				ExportExcel.ExportToExcel(DGV_Main, "تقرير مكالمات النزلاء");
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

		private void Command3_Click(object sender, EventArgs e)
		{
			if (!VarGeneral.vDemo || VarGeneral.UserID == 1)
			{
				Total();
			}
		}

		private void Label15_Click(object sender, EventArgs e)
		{
			Label15.SelectAll();
		}

		private void Label15_Leave(object sender, EventArgs e)
		{
			try
			{
				if (VarGeneral.CheckDate(Label15.Text))
				{
					Label15.Text = Convert.ToDateTime(Label15.Text).ToString("yyyy/MM/dd");
					return;
				}
				MaskedTextBox label = Label15;
				int? calendr = VarGeneral.Settings_Sys.Calendr;
				label.Text = ((calendr.GetValueOrDefault() == 0 && calendr.HasValue) ? n.FormatGreg(VarGeneral.Gdate, "yyyy/MM/dd") : n.FormatHijri(VarGeneral.Hdate, "yyyy/MM/dd"));
			}
			catch
			{
				MaskedTextBox label2 = Label15;
				int? calendr = VarGeneral.Settings_Sys.Calendr;
				label2.Text = ((calendr.GetValueOrDefault() == 0 && calendr.HasValue) ? n.FormatGreg(VarGeneral.Gdate, "yyyy/MM/dd") : n.FormatHijri(VarGeneral.Hdate, "yyyy/MM/dd"));
			}
		}

		private void Text5_Leave(object sender, EventArgs e)
		{
			Command3_Click(sender, e);
		}

		private void txtDebit1_ButtonCustomClick(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(textBox_ID.Text))
			{
				return;
			}
			Button_Edit_Click(sender, e);
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
					if (LangArEn == 0)
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

		private void txtCredit1_ButtonCustomClick(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(textBox_ID.Text))
			{
				return;
			}
			Button_Edit_Click(sender, e);
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
					if (LangArEn == 0)
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

		private void switchButton_Lock_ValueChanged(object sender, EventArgs e)
		{
			try
			{
				if (switchButton_Lock.Value)
				{
					panel_Gaid.Enabled = true;
					if (switchButton_Lock.Value)
					{
						try
						{
							T_per q2 = db.StockPer(int.Parse(Label16.Tag.ToString()));
							txtDebit1.Tag = q2.Cust_no;
							txtDebit1.Text = ((LangArEn == 0) ? db.StockAccDefWithOutBalance(q2.Cust_no).Arb_Des : db.StockAccDefWithOutBalance(q2.Cust_no).Eng_Des);
						}
						catch
						{
							txtDebit1.Text = "";
							txtDebit1.Tag = "";
						}
						try
						{
							T_telmn q = db.StockTelMn(0);
							txtCredit1.Tag = q.accno;
							txtCredit1.Text = ((LangArEn == 0) ? db.StockAccDefWithOutBalance(q.accno).Arb_Des : db.StockAccDefWithOutBalance(q.accno).Eng_Des);
						}
						catch
						{
							txtCredit1.Text = "";
							txtCredit1.Tag = "";
						}
					}
				}
				else
				{
					panel_Gaid.Enabled = false;
				}
			}
			catch
			{
			}
		}

		private void switchButton_Lock_Click(object sender, EventArgs e)
		{
			Button_Edit_Click(sender, e);
		}

		private void button_CustD1_Click(object sender, EventArgs e)
		{
			if (switchButton_Lock.Value)
			{
				try
				{
					T_per q = db.StockPer(int.Parse(Label16.Tag.ToString()));
					txtDebit1.Tag = q.Cust_no;
					txtDebit1.Text = ((LangArEn == 0) ? db.StockAccDefWithOutBalance(q.Cust_no).Arb_Des : db.StockAccDefWithOutBalance(q.Cust_no).Eng_Des);
				}
				catch
				{
					txtDebit1.Text = "";
					txtDebit1.Tag = "";
				}
			}
		}

		private void button_CustC1_Click(object sender, EventArgs e)
		{
			if (switchButton_Lock.Value)
			{
				try
				{
					T_per q = db.StockPer(int.Parse(Label16.Tag.ToString()));
					txtCredit1.Tag = q.Cust_no;
					txtCredit1.Text = ((LangArEn == 0) ? db.StockAccDefWithOutBalance(q.Cust_no).Arb_Des : db.StockAccDefWithOutBalance(q.Cust_no).Eng_Des);
				}
				catch
				{
					txtCredit1.Text = "";
					txtCredit1.Tag = "";
				}
			}
		}
	}
}
