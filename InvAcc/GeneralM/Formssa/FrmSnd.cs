using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.DotNetBar.SuperGrid;
using DevComponents.DotNetBar.SuperGrid.Style;
using DevComponents.Editors;
using Framework.Data;
using InvAcc.GeneralM;
using InvAcc.Stock_Data;
using Library.RepShow;
using Microsoft.VisualBasic;
using Microsoft.Win32;
using SSSDateTime.Date;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial class FrmSnd : Form
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
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (!keyData.ToString().Contains("Control") && !keyData.ToString().ToLower().Contains("delete") && keyData.ToString().Contains("Alt"))
            {
                try
                {
                    VarGeneral.Print_set_Gen_Stat = true;
                    FrmReportsViewer.IsSettingOnly = true;
                    if (textBox_ID.Text != string.Empty && State == FormState.Saved)
                    {

                        buttonItem_Print_Click(null, null);
                        VarGeneral.Print_set_Gen_Stat = false;
                    }
                    else
                    {

                        FrmReportsViewer frm = new FrmReportsViewer();
                        frm.Repvalue = "RepGaidCatchPer";
                        frm.Repvalue = "RepGaidSerfPer";

                        frm.Repvalue = "RepGaidCatchPer";
                        frm.Repvalue = "RepGaidSerfPer";
                        //ADDADD


                        frm.Tag = LangArEn;
                        frm.ShowDialog();
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
        private RibbonBar ribbonBar_DGV;
        private SuperTabControl superTabControl_DGV;
        protected TextBoxItem textBox_search;
        protected ButtonItem Button_ExportTable2;
        protected LabelItem labelItem3;
        private LabelItem lable_Records;
        private Panel panel2;
        protected TextBox textBox_NameA;
        protected Label label36;
        protected TextBox textBox_ID;
        protected Label label38;
        private MaskedTextBox txtTime;
        internal Label Label2;
        private MaskedTextBox txtDate;
        private ComboBoxEx CmbCurr;
        internal Label label19;
        protected Label label3;
        protected Label label1;
        private TextBoxX txtRemark;
        internal Label label4;
        private Label label5;
        private ComboBoxEx CmbGuestNo;
        protected ButtonItem buttonItem_Print;
        private Panel panel_Gaid;
        private TextBoxX txtDebit1;
        private TextBoxX txtCredit1;
        internal Label labelD1;
        internal Label labelC1;
        private SwitchButton switchButton_Lock;
        internal PrintPreviewDialog prnt_prev;
        private PrintDocument prnt_doc;
        private OpenFileDialog openFileDialog2;
        internal Label label7;
        internal TextBox txtRef;
        private IntegerInput txtRoom;
        private ButtonX button_SrchGuestNo;
        internal Label labelGuestStat;
        private ButtonX button_CustD1;
        private ButtonX button_CustC1;
        public DoubleInput txtPaymentLoc;
        internal Label label6;
        public DoubleInput txtGuestBalance;
        internal Label labelGaidStat;
        public Dictionary<string, ColumnDictinary> columns_Names_visible = new Dictionary<string, ColumnDictinary>();
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
        private T_Snd data_this;
        private Rate_DataDataContext dbInstanceRate;
        private T_User permission = new T_User();
        private T_INVSETTING _InvSetting = new T_INVSETTING();
        private List<T_INVSETTING> listInvSetting = new List<T_INVSETTING>();
        private T_GDHEAD _GdHead = new T_GDHEAD();
        private List<T_GDHEAD> listGdHead = new List<T_GDHEAD>();
        private T_GDDET _GdDet = new T_GDDET();
        private List<T_GDDET> listGdDet = new List<T_GDDET>();
        private ScriptNumber ScriptNumber1 = new ScriptNumber();
        private string[,] vData = new string[101, 8];
        public int SerTypeCount = 10;
        private double[] Ttot = new double[9];
        private double Tot3;
        private double Tot4;
        private double Tot10;
        private double Tot8;
        private double Tot5;
        private double Tot1;
        private double Tot2;
        private double Tot6;
        private double Tot7;
        private double tot50;
        private double tot60;
        private double tt1;
        private double Tot;
        private double TotResturant;
        private double dis;
        private double aa;
        public Dictionary<string, ColumnDictinary> columns_Names_visible2 = new Dictionary<string, ColumnDictinary>();
        private int iiRntP = 0;
        private int _page = 1;
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
        public T_Snd DataThis
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
                if (value == null || !(value.UsrNo != string.Empty))
                {
                    return;
                }
                permission = value;
                if (VarGeneral.SndTyp == 1)
                {
                    if (!VarGeneral.TString.ChkStatShow(value.RepAcc2, 21))
                    {
                        IfAdd = false;
                    }
                    else
                    {
                        IfAdd = true;
                    }
                    if (!VarGeneral.TString.ChkStatShow(value.RepAcc2, 22))
                    {
                        CanEdit = false;
                    }
                    else
                    {
                        CanEdit = true;
                    }
                    if (!VarGeneral.TString.ChkStatShow(value.RepAcc2, 23))
                    {
                        IfDelete = false;
                    }
                    else
                    {
                        IfDelete = true;
                    }
                }
                else
                {
                    if (!VarGeneral.TString.ChkStatShow(value.RepAcc2, 25))
                    {
                        IfAdd = false;
                    }
                    else
                    {
                        IfAdd = true;
                    }
                    if (!VarGeneral.TString.ChkStatShow(value.RepAcc2, 26))
                    {
                        CanEdit = false;
                    }
                    else
                    {
                        CanEdit = true;
                    }
                    if (!VarGeneral.TString.ChkStatShow(value.RepAcc2, 27))
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InvAcc.Forms.FrmSnd));
            DevComponents.DotNetBar.SuperGrid.Style.Background background1 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.Style.Background background2 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.Style.Background background3 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.Style.BorderColor borderColor1 = new DevComponents.DotNetBar.SuperGrid.Style.BorderColor();
            DevComponents.DotNetBar.SuperGrid.Style.BorderColor borderColor2 = new DevComponents.DotNetBar.SuperGrid.Style.BorderColor();
            DevComponents.DotNetBar.SuperGrid.Style.BaseTreeButtonVisualStyle baseTreeButtonVisualStyle1 = new DevComponents.DotNetBar.SuperGrid.Style.BaseTreeButtonVisualStyle();
            DevComponents.DotNetBar.SuperGrid.Style.BaseTreeButtonVisualStyle baseTreeButtonVisualStyle2 = new DevComponents.DotNetBar.SuperGrid.Style.BaseTreeButtonVisualStyle();
            DevComponents.DotNetBar.SuperGrid.Style.Background background4 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            timer1 = new System.Windows.Forms.Timer(components);
            expandableSplitter1 = new DevComponents.DotNetBar.ExpandableSplitter();
            panelEx2 = new DevComponents.DotNetBar.PanelEx();
            ribbonBar1 = new DevComponents.DotNetBar.RibbonBar();
            panel2 = new System.Windows.Forms.Panel();
            labelGaidStat = new System.Windows.Forms.Label();
            txtGuestBalance = new DevComponents.Editors.DoubleInput();
            label6 = new System.Windows.Forms.Label();
            labelGuestStat = new System.Windows.Forms.Label();
            button_SrchGuestNo = new DevComponents.DotNetBar.ButtonX();
            txtRoom = new DevComponents.Editors.IntegerInput();
            switchButton_Lock = new DevComponents.DotNetBar.Controls.SwitchButton();
            txtRemark = new DevComponents.DotNetBar.Controls.TextBoxX();
            txtPaymentLoc = new DevComponents.Editors.DoubleInput();
            CmbCurr = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            label19 = new System.Windows.Forms.Label();
            txtTime = new System.Windows.Forms.MaskedTextBox();
            Label2 = new System.Windows.Forms.Label();
            txtDate = new System.Windows.Forms.MaskedTextBox();
            textBox_NameA = new System.Windows.Forms.TextBox();
            textBox_ID = new System.Windows.Forms.TextBox();
            label4 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label36 = new System.Windows.Forms.Label();
            label38 = new System.Windows.Forms.Label();
            panel_Gaid = new System.Windows.Forms.Panel();
            button_CustC1 = new DevComponents.DotNetBar.ButtonX();
            button_CustD1 = new DevComponents.DotNetBar.ButtonX();
            txtDebit1 = new DevComponents.DotNetBar.Controls.TextBoxX();
            txtCredit1 = new DevComponents.DotNetBar.Controls.TextBoxX();
            labelD1 = new System.Windows.Forms.Label();
            labelC1 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            txtRef = new System.Windows.Forms.TextBox();
            label5 = new System.Windows.Forms.Label();
            CmbGuestNo = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            ribbonBar_Tasks = new DevComponents.DotNetBar.RibbonBar();
            superTabControl_Main1 = new DevComponents.DotNetBar.SuperTabControl();
            Button_Close = new DevComponents.DotNetBar.ButtonItem();
            buttonItem_Print = new DevComponents.DotNetBar.ButtonItem();
            Button_Search = new DevComponents.DotNetBar.ButtonItem();
            Button_Delete = new DevComponents.DotNetBar.ButtonItem();
            Button_Save = new DevComponents.DotNetBar.ButtonItem();
            Button_Add = new DevComponents.DotNetBar.ButtonItem();
            superTabControl_Main2 = new DevComponents.DotNetBar.SuperTabControl();
            labelItem1 = new DevComponents.DotNetBar.LabelItem();
            Button_First = new DevComponents.DotNetBar.ButtonItem();
            Button_Prev = new DevComponents.DotNetBar.ButtonItem();
            TextBox_Index = new DevComponents.DotNetBar.TextBoxItem();
            Label_Count = new DevComponents.DotNetBar.LabelItem();
            lable_Records = new DevComponents.DotNetBar.LabelItem();
            Button_Next = new DevComponents.DotNetBar.ButtonItem();
            Button_Last = new DevComponents.DotNetBar.ButtonItem();
            saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            DGV_Main = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            panelEx3 = new DevComponents.DotNetBar.PanelEx();
            ribbonBar_DGV = new DevComponents.DotNetBar.RibbonBar();
            superTabControl_DGV = new DevComponents.DotNetBar.SuperTabControl();
            textBox_search = new DevComponents.DotNetBar.TextBoxItem();
            Button_ExportTable2 = new DevComponents.DotNetBar.ButtonItem();
            labelItem3 = new DevComponents.DotNetBar.LabelItem();
            timerInfoBallon = new System.Windows.Forms.Timer(components);
            openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            panel1 = new System.Windows.Forms.Panel();
            barTopDockSite = new DevComponents.DotNetBar.DockSite();
            barBottomDockSite = new DevComponents.DotNetBar.DockSite();
            dotNetBarManager1 = new DevComponents.DotNetBar.DotNetBarManager(components);
            imageList1 = new System.Windows.Forms.ImageList(components);
            barLeftDockSite = new DevComponents.DotNetBar.DockSite();
            barRightDockSite = new DevComponents.DotNetBar.DockSite();
            dockSite4 = new DevComponents.DotNetBar.DockSite();
            dockSite1 = new DevComponents.DotNetBar.DockSite();
            dockSite2 = new DevComponents.DotNetBar.DockSite();
            dockSite3 = new DevComponents.DotNetBar.DockSite();
            contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(components);
            ToolStripMenuItem_Rep = new System.Windows.Forms.ToolStripMenuItem();
            ToolStripMenuItem_Det = new System.Windows.Forms.ToolStripMenuItem();
            contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(components);
            prnt_prev = new System.Windows.Forms.PrintPreviewDialog();
            prnt_doc = new System.Drawing.Printing.PrintDocument();
            openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            panelEx2.SuspendLayout();
            ribbonBar1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtGuestBalance).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtRoom).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtPaymentLoc).BeginInit();
            panel_Gaid.SuspendLayout();
            ribbonBar_Tasks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)superTabControl_Main1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)superTabControl_Main2).BeginInit();
            panelEx3.SuspendLayout();
            ribbonBar_DGV.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)superTabControl_DGV).BeginInit();
            panel1.SuspendLayout();
            contextMenuStrip2.SuspendLayout();
            SuspendLayout();
            timer1.Interval = 1000;
            expandableSplitter1.BackColor = System.Drawing.Color.FromArgb(227, 239, 255);
            expandableSplitter1.BackColor2 = System.Drawing.Color.FromArgb(101, 147, 207);
            expandableSplitter1.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.None;
            expandableSplitter1.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.None;
            resources.ApplyResources(expandableSplitter1, "expandableSplitter1");
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
            panelEx2.Controls.Add(ribbonBar1);
            panelEx2.Controls.Add(ribbonBar_Tasks);
            resources.ApplyResources(panelEx2, "panelEx2");
            panelEx2.MinimumSize = new System.Drawing.Size(659, 228);
            panelEx2.Name = "panelEx2";
            panelEx2.Style.Alignment = System.Drawing.StringAlignment.Center;
            panelEx2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            panelEx2.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            panelEx2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            panelEx2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            panelEx2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            panelEx2.Style.GradientAngle = 90;
            ribbonBar1.AutoOverflowEnabled = true;
            ribbonBar1.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            ribbonBar1.BackgroundStyle.BackColor = System.Drawing.Color.AliceBlue;
            ribbonBar1.BackgroundStyle.BackColor2 = System.Drawing.SystemColors.GradientActiveCaption;
            ribbonBar1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            ribbonBar1.ContainerControlProcessDialogKey = true;
            ribbonBar1.Controls.Add(panel2);
            resources.ApplyResources(ribbonBar1, "ribbonBar1");
            ribbonBar1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            ribbonBar1.Name = "ribbonBar1";
            ribbonBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            ribbonBar1.TitleStyle.BackColor = System.Drawing.Color.FromArgb(227, 239, 255);
            ribbonBar1.TitleStyle.BackColor2 = System.Drawing.Color.FromArgb(101, 147, 207);
            ribbonBar1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            ribbonBar1.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            panel2.Controls.Add(labelGaidStat);
            panel2.Controls.Add(txtGuestBalance);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(labelGuestStat);
            panel2.Controls.Add(button_SrchGuestNo);
            panel2.Controls.Add(txtRoom);
            panel2.Controls.Add(switchButton_Lock);
            panel2.Controls.Add(txtRemark);
            panel2.Controls.Add(txtPaymentLoc);
            panel2.Controls.Add(CmbCurr);
            panel2.Controls.Add(label19);
            panel2.Controls.Add(txtTime);
            panel2.Controls.Add(Label2);
            panel2.Controls.Add(txtDate);
            panel2.Controls.Add(textBox_NameA);
            panel2.Controls.Add(textBox_ID);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(label36);
            panel2.Controls.Add(label38);
            panel2.Controls.Add(panel_Gaid);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(txtRef);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(CmbGuestNo);
            resources.ApplyResources(panel2, "panel2");
            panel2.Name = "panel2";
            labelGaidStat.BackColor = System.Drawing.Color.DarkSeaGreen;
            labelGaidStat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            resources.ApplyResources(labelGaidStat, "labelGaidStat");
            labelGaidStat.ForeColor = System.Drawing.Color.White;
            labelGaidStat.Name = "labelGaidStat";
            txtGuestBalance.AllowEmptyState = false;
            txtGuestBalance.BackgroundStyle.BackColor = System.Drawing.Color.DarkSeaGreen;
            txtGuestBalance.BackgroundStyle.Class = "DateTimeInputBackground";
            txtGuestBalance.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            txtGuestBalance.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            txtGuestBalance.DisplayFormat = "0.00";
            resources.ApplyResources(txtGuestBalance, "txtGuestBalance");
            txtGuestBalance.Increment = 0.0;
            txtGuestBalance.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            txtGuestBalance.IsInputReadOnly = true;
            txtGuestBalance.MinValue = 0.0;
            txtGuestBalance.Name = "txtGuestBalance";
            label6.BackColor = System.Drawing.Color.Transparent;
            label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            label6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            resources.ApplyResources(label6, "label6");
            label6.Name = "label6";
            labelGuestStat.BackColor = System.Drawing.Color.FromArgb(192, 0, 0);
            labelGuestStat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            resources.ApplyResources(labelGuestStat, "labelGuestStat");
            labelGuestStat.ForeColor = System.Drawing.Color.White;
            labelGuestStat.Name = "labelGuestStat";
            button_SrchGuestNo.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            button_SrchGuestNo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            resources.ApplyResources(button_SrchGuestNo, "button_SrchGuestNo");
            button_SrchGuestNo.Name = "button_SrchGuestNo";
            button_SrchGuestNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            button_SrchGuestNo.Symbol = "\uf002";
            button_SrchGuestNo.SymbolSize = 12f;
            button_SrchGuestNo.TextColor = System.Drawing.Color.SteelBlue;
            button_SrchGuestNo.Click += new System.EventHandler(button_SrchGuestNo_Click);
            txtRoom.AllowEmptyState = false;
            txtRoom.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(255, 255, 198);
            txtRoom.BackgroundStyle.Class = "DateTimeInputBackground";
            txtRoom.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            txtRoom.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            txtRoom.DisplayFormat = "0";
            resources.ApplyResources(txtRoom, "txtRoom");
            txtRoom.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            txtRoom.IsInputReadOnly = true;
            txtRoom.MinValue = 0;
            txtRoom.Name = "txtRoom";
            switchButton_Lock.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            resources.ApplyResources(switchButton_Lock, "switchButton_Lock");
            switchButton_Lock.Name = "switchButton_Lock";
            switchButton_Lock.OffBackColor = System.Drawing.Color.FromArgb(192, 80, 77);
            switchButton_Lock.OffTextColor = System.Drawing.Color.White;
            switchButton_Lock.OnBackColor = System.Drawing.Color.FromArgb(0, 192, 0);
            switchButton_Lock.OnTextColor = System.Drawing.Color.White;
            switchButton_Lock.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            switchButton_Lock.SwitchWidth = 50;
            switchButton_Lock.ValueChanged += new System.EventHandler(switchButton_Lock_ValueChanged);
            switchButton_Lock.Click += new System.EventHandler(switchButton_Lock_Click);
            txtRemark.BackColor = System.Drawing.Color.White;
            txtRemark.Border.Class = "TextBoxBorder";
            txtRemark.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            txtRemark.ButtonCustom.Visible = true;
            txtRemark.ForeColor = System.Drawing.Color.Black;
            resources.ApplyResources(txtRemark, "txtRemark");
            txtRemark.Name = "txtRemark";
            txtPaymentLoc.AllowEmptyState = false;
            txtPaymentLoc.BackgroundStyle.Class = "DateTimeInputBackground";
            txtPaymentLoc.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            txtPaymentLoc.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            txtPaymentLoc.DisplayFormat = "0.00";
            resources.ApplyResources(txtPaymentLoc, "txtPaymentLoc");
            txtPaymentLoc.Increment = 0.0;
            txtPaymentLoc.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            txtPaymentLoc.MinValue = 0.0;
            txtPaymentLoc.Name = "txtPaymentLoc";
            CmbCurr.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            CmbCurr.DisplayMember = "Text";
            CmbCurr.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            CmbCurr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            CmbCurr.FormattingEnabled = true;
            resources.ApplyResources(CmbCurr, "CmbCurr");
            CmbCurr.Name = "CmbCurr";
            CmbCurr.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            resources.ApplyResources(label19, "label19");
            label19.BackColor = System.Drawing.Color.Transparent;
            label19.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            label19.Name = "label19";
            txtTime.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(txtTime, "txtTime");
            txtTime.Name = "txtTime";
            txtTime.Leave += new System.EventHandler(txtTime_Leave);
            txtTime.Click += new System.EventHandler(txtTime_Click);
            resources.ApplyResources(Label2, "Label2");
            Label2.BackColor = System.Drawing.Color.Transparent;
            Label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            Label2.Name = "Label2";
            txtDate.BackColor = System.Drawing.Color.WhiteSmoke;
            resources.ApplyResources(txtDate, "txtDate");
            txtDate.Name = "txtDate";
            txtDate.Leave += new System.EventHandler(txtDate_Leave);
            txtDate.Click += new System.EventHandler(txtDate_Click);
            textBox_NameA.BackColor = System.Drawing.Color.FromArgb(255, 255, 128);
            textBox_NameA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(textBox_NameA, "textBox_NameA");
            textBox_NameA.ForeColor = System.Drawing.Color.Maroon;
            textBox_NameA.Name = "textBox_NameA";
            textBox_ID.BackColor = System.Drawing.Color.FromArgb(255, 224, 192);
            textBox_ID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(textBox_ID, "textBox_ID");
            textBox_ID.Name = "textBox_ID";
            textBox_ID.ReadOnly = true;
            textBox_ID.TextChanged += new System.EventHandler(textBox_ID_TextChanged);
            textBox_ID.Click += new System.EventHandler(textBox_ID_Click);
            textBox_ID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(textBox_ID_KeyPress);
            resources.ApplyResources(label4, "label4");
            label4.BackColor = System.Drawing.Color.Transparent;
            label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            label4.Name = "label4";
            resources.ApplyResources(label3, "label3");
            label3.BackColor = System.Drawing.Color.Transparent;
            label3.Name = "label3";
            resources.ApplyResources(label1, "label1");
            label1.BackColor = System.Drawing.Color.Transparent;
            label1.Name = "label1";
            resources.ApplyResources(label36, "label36");
            label36.BackColor = System.Drawing.Color.Transparent;
            label36.Name = "label36";
            resources.ApplyResources(label38, "label38");
            label38.BackColor = System.Drawing.Color.Transparent;
            label38.Name = "label38";
            panel_Gaid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            panel_Gaid.Controls.Add(button_CustC1);
            panel_Gaid.Controls.Add(button_CustD1);
            panel_Gaid.Controls.Add(txtDebit1);
            panel_Gaid.Controls.Add(txtCredit1);
            panel_Gaid.Controls.Add(labelD1);
            panel_Gaid.Controls.Add(labelC1);
            resources.ApplyResources(panel_Gaid, "panel_Gaid");
            panel_Gaid.Name = "panel_Gaid";
            button_CustC1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            button_CustC1.Checked = true;
            button_CustC1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            resources.ApplyResources(button_CustC1, "button_CustC1");
            button_CustC1.Name = "button_CustC1";
            button_CustC1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            button_CustC1.Symbol = "\uf00c";
            button_CustC1.SymbolSize = 7f;
            button_CustC1.TextColor = System.Drawing.Color.SteelBlue;
            button_CustC1.Click += new System.EventHandler(button_CustC1_Click);
            button_CustD1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            button_CustD1.Checked = true;
            button_CustD1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            resources.ApplyResources(button_CustD1, "button_CustD1");
            button_CustD1.Name = "button_CustD1";
            button_CustD1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            button_CustD1.Symbol = "\uf00c";
            button_CustD1.SymbolSize = 7f;
            button_CustD1.TextColor = System.Drawing.Color.SteelBlue;
            button_CustD1.Click += new System.EventHandler(button_CustD1_Click);
            txtDebit1.BackColor = System.Drawing.SystemColors.Control;
            txtDebit1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            txtDebit1.ButtonCustom.Visible = true;
            resources.ApplyResources(txtDebit1, "txtDebit1");
            txtDebit1.ForeColor = System.Drawing.SystemColors.ControlText;
            txtDebit1.Name = "txtDebit1";
            txtDebit1.ReadOnly = true;
            txtCredit1.BackColor = System.Drawing.SystemColors.Control;
            txtCredit1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            txtCredit1.ButtonCustom.Visible = true;
            resources.ApplyResources(txtCredit1, "txtCredit1");
            txtCredit1.ForeColor = System.Drawing.SystemColors.ControlText;
            txtCredit1.Name = "txtCredit1";
            txtCredit1.ReadOnly = true;
            resources.ApplyResources(labelD1, "labelD1");
            labelD1.BackColor = System.Drawing.Color.Transparent;
            labelD1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            labelD1.Name = "labelD1";
            resources.ApplyResources(labelC1, "labelC1");
            labelC1.BackColor = System.Drawing.Color.Transparent;
            labelC1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            labelC1.Name = "labelC1";
            resources.ApplyResources(label7, "label7");
            label7.BackColor = System.Drawing.Color.Transparent;
            label7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            label7.Name = "label7";
            resources.ApplyResources(txtRef, "txtRef");
            txtRef.Name = "txtRef";
            resources.ApplyResources(label5, "label5");
            label5.BackColor = System.Drawing.Color.Transparent;
            label5.ForeColor = System.Drawing.Color.Black;
            label5.Name = "label5";
            CmbGuestNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            CmbGuestNo.DisplayMember = "Text";
            CmbGuestNo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            CmbGuestNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            CmbGuestNo.FocusHighlightColor = System.Drawing.Color.Empty;
            CmbGuestNo.FormattingEnabled = true;
            resources.ApplyResources(CmbGuestNo, "CmbGuestNo");
            CmbGuestNo.Name = "CmbGuestNo";
            CmbGuestNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            CmbGuestNo.SelectedIndexChanged += new System.EventHandler(CmbGuestNo_SelectedIndexChanged);
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
                buttonItem_Print,
                Button_Search,
                Button_Delete,
                Button_Save,
                Button_Add
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
            buttonItem_Print.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            buttonItem_Print.FontBold = true;
            buttonItem_Print.FontItalic = true;
            buttonItem_Print.ForeColor = System.Drawing.Color.DimGray;
            buttonItem_Print.Image = (System.Drawing.Image)resources.GetObject("buttonItem_Print.Image");
            buttonItem_Print.ImageFixedSize = new System.Drawing.Size(28, 28);
            buttonItem_Print.ImagePaddingHorizontal = 15;
            buttonItem_Print.ImagePaddingVertical = 11;
            buttonItem_Print.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            buttonItem_Print.Name = "buttonItem_Print";
            buttonItem_Print.Stretch = true;
            buttonItem_Print.SubItemsExpandWidth = 14;
            buttonItem_Print.Symbol = "\uf0c5";
            buttonItem_Print.SymbolSize = 15f;
            resources.ApplyResources(buttonItem_Print, "buttonItem_Print");
            buttonItem_Print.Click += new System.EventHandler(buttonItem_Print_Click);
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
            saveFileDialog1.DefaultExt = "*.rtf";
            saveFileDialog1.FileName = "doc1";
            resources.ApplyResources(saveFileDialog1, "saveFileDialog1");
            saveFileDialog1.FilterIndex = 2;
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
            DGV_Main.PrimaryGrid.GroupByRow.Text = "جميــع السجــــلات";
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
            superTabControl_DGV.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[3]
            {
                textBox_search,
                Button_ExportTable2,
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
            labelItem3.Name = "labelItem3";
            labelItem3.Width = 40;
            timerInfoBallon.Interval = 3000;
            openFileDialog1.DefaultExt = "*.rtf";
            resources.ApplyResources(openFileDialog1, "openFileDialog1");
            openFileDialog1.FilterIndex = 2;
            panel1.Controls.Add(panelEx3);
            panel1.Controls.Add(expandableSplitter1);
            panel1.Controls.Add(panelEx2);
            resources.ApplyResources(panel1, "panel1");
            panel1.Name = "panel1";
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
            dotNetBarManager1.BottomDockSite = barBottomDockSite;
            dotNetBarManager1.Images = imageList1;
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
            imageList1.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = System.Drawing.Color.Magenta;
            imageList1.Images.SetKeyName(0, string.Empty);
            imageList1.Images.SetKeyName(1, string.Empty);
            imageList1.Images.SetKeyName(2, string.Empty);
            imageList1.Images.SetKeyName(3, string.Empty);
            imageList1.Images.SetKeyName(4, string.Empty);
            imageList1.Images.SetKeyName(5, string.Empty);
            imageList1.Images.SetKeyName(6, string.Empty);
            imageList1.Images.SetKeyName(7, string.Empty);
            imageList1.Images.SetKeyName(8, string.Empty);
            imageList1.Images.SetKeyName(9, string.Empty);
            imageList1.Images.SetKeyName(10, string.Empty);
            imageList1.Images.SetKeyName(11, string.Empty);
            imageList1.Images.SetKeyName(12, string.Empty);
            imageList1.Images.SetKeyName(13, string.Empty);
            imageList1.Images.SetKeyName(14, string.Empty);
            imageList1.Images.SetKeyName(15, string.Empty);
            imageList1.Images.SetKeyName(16, string.Empty);
            imageList1.Images.SetKeyName(17, string.Empty);
            imageList1.Images.SetKeyName(18, string.Empty);
            imageList1.Images.SetKeyName(19, string.Empty);
            imageList1.Images.SetKeyName(20, string.Empty);
            imageList1.Images.SetKeyName(21, string.Empty);
            imageList1.Images.SetKeyName(22, string.Empty);
            imageList1.Images.SetKeyName(23, string.Empty);
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
            dockSite4.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            resources.ApplyResources(dockSite4, "dockSite4");
            dockSite4.Name = "dockSite4";
            dockSite4.TabStop = false;
            dockSite1.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            resources.ApplyResources(dockSite1, "dockSite1");
            dockSite1.Name = "dockSite1";
            dockSite1.TabStop = false;
            dockSite2.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            resources.ApplyResources(dockSite2, "dockSite2");
            dockSite2.Name = "dockSite2";
            dockSite2.TabStop = false;
            dockSite3.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            resources.ApplyResources(dockSite3, "dockSite3");
            dockSite3.Name = "dockSite3";
            dockSite3.TabStop = false;
            contextMenuStrip1.Name = "contextMenuStrip1";
            resources.ApplyResources(contextMenuStrip1, "contextMenuStrip1");
            ToolStripMenuItem_Rep.Checked = true;
            ToolStripMenuItem_Rep.CheckState = System.Windows.Forms.CheckState.Checked;
            ToolStripMenuItem_Rep.Name = "ToolStripMenuItem_Rep";
            resources.ApplyResources(ToolStripMenuItem_Rep, "ToolStripMenuItem_Rep");
            ToolStripMenuItem_Det.Name = "ToolStripMenuItem_Det";
            resources.ApplyResources(ToolStripMenuItem_Det, "ToolStripMenuItem_Det");
            contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[2]
            {
                ToolStripMenuItem_Det,
                ToolStripMenuItem_Rep
            });
            contextMenuStrip2.Name = "contextMenuStrip2";
            resources.ApplyResources(contextMenuStrip2, "contextMenuStrip2");
            resources.ApplyResources(prnt_prev, "prnt_prev");
            prnt_prev.Document = prnt_doc;
            prnt_prev.Name = "prnt_prev";
            prnt_doc.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(prnt_doc_PrintPage);
            prnt_doc.BeginPrint += new System.Drawing.Printing.PrintEventHandler(prnt_doc_BeginPrint);
            openFileDialog2.DefaultExt = "*.rtf";
            resources.ApplyResources(openFileDialog2, "openFileDialog2");
            openFileDialog2.FilterIndex = 2;
            resources.ApplyResources(this, "$this");
            base.Controls.Add(panel1);
            base.Controls.Add(barTopDockSite);
            base.Controls.Add(barBottomDockSite);
            base.Controls.Add(barLeftDockSite);
            base.Controls.Add(barRightDockSite);
            base.Controls.Add(dockSite4);
            base.Controls.Add(dockSite1);
            base.Controls.Add(dockSite2);
            base.Controls.Add(dockSite3);
            base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            base.KeyPreview = true;
            base.MaximizeBox = false;
            base.Name = "FrmSnd";
            base.Load += new System.EventHandler(FrmSnd_Load);
            base.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Frm_KeyPress);
            base.KeyDown += new System.Windows.Forms.KeyEventHandler(Frm_KeyDown);
            panelEx2.ResumeLayout(false);
            ribbonBar1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)txtGuestBalance).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtRoom).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtPaymentLoc).EndInit();
            panel_Gaid.ResumeLayout(false);
            panel_Gaid.PerformLayout();
            ribbonBar_Tasks.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)superTabControl_Main1).EndInit();
            ((System.ComponentModel.ISupportInitialize)superTabControl_Main2).EndInit();
            panelEx3.ResumeLayout(false);
            ribbonBar_DGV.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)superTabControl_DGV).EndInit();
            panel1.ResumeLayout(false);
            contextMenuStrip2.ResumeLayout(false);
            ResumeLayout(false);
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
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
            }
            VarGeneral.SFrmTyp = "T_Snd";
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != string.Empty)
            {
                textBox_ID.Text = frm.SerachNo.ToString();
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
            List<T_Snd> list = db.FillSnd_2(VarGeneral.SndTyp, textBox_search.TextBox.Text).ToList();
            if (DGV_Main.PrimaryGrid.Columns.Count == 0)
            {
                foreach (KeyValuePair<string, ColumnDictinary> item in columns_Names_visible)
                {
                    DGV_Main.PrimaryGrid.Columns.Add(new GridColumn(item.Key));
                }
            }
            FillHDGV(list);
        }
        public void FillHDGV(IEnumerable<T_Snd> new_data_enum)
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
            DGV_Main.PrimaryGrid.DataMember = "T_Snd";
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
            data_this = new T_Snd();
            _GdHead = new T_GDHEAD();
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
            switchButton_Lock.Value = false;
            CmbGuestNo_SelectedIndexChanged(null, null);
            FillCombo();
            CmbGuestNo.Enabled = true;
            labelGuestStat.Visible = false;
            labelGaidStat.Visible = false;
            txtDate.Enabled = true;
            txtTime.Enabled = true;
            txtRef.Enabled = true;
            CmbCurr.Enabled = true;
            txtRemark.Enabled = true;
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
            else if (e.KeyCode == Keys.F5 && buttonItem_Print.Enabled && buttonItem_Print.Visible && State == FormState.Saved && expandableSplitter1.Expanded)
            {
                buttonItem_Print_Click(sender, e);
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
            var qkeys = from item in db.T_Snds
                        where item.typ == (int?)VarGeneral.SndTyp
                        select new
                        {
                            Code = item.fNo + string.Empty
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
        public FrmSnd()
        {
            InitializeComponent();
            controls = new List<Control>();
            controls.Add(textBox_ID);
            codeControl = textBox_ID;
            controls.Add(textBox_NameA);
            controls.Add(txtDate);
            controls.Add(txtRemark);
            controls.Add(txtTime);
            controls.Add(txtPaymentLoc);
            controls.Add(CmbCurr);
            controls.Add(txtRoom);
            controls.Add(CmbGuestNo);
            controls.Add(txtDebit1);
            controls.Add(txtCredit1);
            controls.Add(txtRef);
            controls.Add(txtGuestBalance);
            Button_Close.Click += Button_Close_Click;
            textBox_NameA.Click += Button_Edit_Click;
            txtDate.Click += Button_Edit_Click;
            txtRemark.Click += Button_Edit_Click;
            txtTime.Click += Button_Edit_Click;
            txtPaymentLoc.Click += Button_Edit_Click;
            CmbCurr.Click += Button_Edit_Click;
            txtRoom.Click += Button_Edit_Click;
            CmbGuestNo.Click += Button_Edit_Click;
            txtDebit1.Click += Button_Edit_Click;
            txtCredit1.Click += Button_Edit_Click;
            txtRef.Click += Button_Edit_Click;
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
        protected override void OnParentRightToLeftChanged(EventArgs e)
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmSnd));
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
        private void GetInvSetting()
        {
            _InvSetting = new T_INVSETTING();
            _InvSetting = db.StockInvSetting(VarGeneral.UserID, VarGeneral.InvTyp);
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
                buttonItem_Print.Text = ((_InvSetting.InvpRINTERInfo.nTyp.Substring(2, 1) == "0") ? "طباعة" : "عــرض");
                buttonItem_Print.Tooltip = "F5";
                Button_ExportTable2.Text = "تصدير";
                Button_ExportTable2.Tooltip = "F10";
                DGV_Main.PrimaryGrid.GroupByRow.Text = "جميع السجلات";
                switchButton_Lock.OffText = "إنشاء قيد محاسبي";
                switchButton_Lock.OnText = "إنشاء قيد محاسبي";
                if (VarGeneral.SndTyp == 1)
                {
                    Text = "سند قبض نزيل";
                }
                else
                {
                    Text = "سند صرف نزيل";
                }
                return;
            }
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
            buttonItem_Print.Text = ((_InvSetting.InvpRINTERInfo.nTyp.Substring(2, 1) == "0") ? "Print" : "Show");
            buttonItem_Print.Tooltip = "F5";
            Button_ExportTable2.Text = "Export";
            Button_ExportTable2.Tooltip = "F10";
            DGV_Main.PrimaryGrid.GroupByRow.Text = "All Records";
            switchButton_Lock.OffText = "Create an accounting record";
            switchButton_Lock.OnText = "Create an accounting record";
            labelGuestStat.Text = "Guest Leaved";
            labelGaidStat.Text = "The accounting record was derecognized at the close of the year";
            if (VarGeneral.SndTyp == 1)
            {
                Text = "Under arrest Guest";
            }
            else
            {
                Text = "Under Exchange Guest";
            }
        }
        private void FrmSnd_Load(object sender, EventArgs e)
        {
            try
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmSnd));
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
                Permmission = dbc.Get_PermissionID(VarGeneral.UserID);
                if (columns_Names_visible.Count == 0)
                {
                    columns_Names_visible.Add("fNo", new ColumnDictinary("رقم السند", "No", ifDefault: true, string.Empty));
                    columns_Names_visible.Add("perno", new ColumnDictinary("رقم النزيل", "Guest No", ifDefault: true, string.Empty));
                    columns_Names_visible.Add("SndName", new ColumnDictinary("إسم النزيل عربي", "Guest Name", ifDefault: true, string.Empty));
                    columns_Names_visible.Add("SndNameE", new ColumnDictinary("إسم النزيل انجليزي", "Guest Name", ifDefault: true, string.Empty));
                    columns_Names_visible.Add("romno", new ColumnDictinary("رقم الغرفة", "Room No", ifDefault: true, string.Empty));
                    columns_Names_visible.Add("price", new ColumnDictinary("المبلــغ", "Value", ifDefault: true, string.Empty));
                    columns_Names_visible.Add("dt", new ColumnDictinary("التاريخ", "Date", ifDefault: true, string.Empty));
                    columns_Names_visible.Add("tm", new ColumnDictinary("الوقت", "Time", ifDefault: true, string.Empty));
                }
                else
                {
                    Clear();
                    textBox_ID.Text = string.Empty;
                    TextBox_Index.TextBox.Text = string.Empty;
                }
                GetInvSetting();
                RibunButtons();
                RefreshPKeys();
                SerTypeCount += db.FillServTyp_2(string.Empty).ToList().Count;
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
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
                FillCombo();
                if (VarGeneral.vGaidHotel)
                {
                    Button_Add_Click(sender, e);
                    try
                    {
                        if (CmbGuestNo.Items.Count > 0)
                        {
                            CmbGuestNo.SelectedValue = VarGeneral._hotelper;
                        }
                    }
                    catch
                    {
                    }
                    if (VarGeneral.InvTyp == 27 && VarGeneral.tot_Guest_val > 0.0)
                    {
                        txtPaymentLoc.Value = VarGeneral.tot_Guest_val;
                        txtRemark.Text = "تسديد باقي المبلغ المستحق للمغادرة | Payment of the remaining amount due for departure";
                    }
                    base.ActiveControl = txtPaymentLoc;
                }
                else
                {
                    textBox_ID.Text = PKeys.FirstOrDefault();
                }
                try
                {
                    GetGuestBalance(int.Parse(CmbGuestNo.SelectedValue.ToString()));
                }
                catch
                {
                }
                ViewDetails_Click(sender, e);
                UpdateVcr();
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Load:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void FillCombo()
        {
            try
            {
                CmbGuestNo.Items.Clear();
            }
            catch
            {
            }
            List<T_per> listGuest = new List<T_per>(db.T_pers.Where((T_per item) => (((int)State == 2 && VarGeneral.SndTyp == 2) ? (item.ch == (int?)2) : true) && item.romno.HasValue).ToList());
            CmbGuestNo.DataSource = null;
            CmbGuestNo.DataSource = listGuest;
            CmbGuestNo.DisplayMember = "perno";
            CmbGuestNo.ValueMember = "perno";
            CmbGuestNo_SelectedIndexChanged(null, null);
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
                T_Snd newData = db.StockSnd(VarGeneral.SndTyp, no);
                if (newData == null || newData.fNo == 0)
                {
                    if (!Button_Add.Visible || !Button_Add.Enabled)
                    {
                        MessageBox.Show((LangArEn == 0) ? "لا يمكن اتمام هذه العملية .. الرجاء مراجعة صلاحيات المستخدمين !" : "Can not complete this process .. please see the powers of the users!", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        textBox_ID.TextChanged -= textBox_ID_TextChanged;
                        try
                        {
                            textBox_ID.Text = data_this.fNo.ToString();
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
                    int indexA = PKeys.IndexOf(string.Concat(newData.fNo));
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
        public void SetData(T_Snd value)
        {
            try
            {
                State = FormState.Saved;
                Button_Save.Enabled = false;
                textBox_ID.Tag = value.gd_ID;
                FillCombo();
                for (int iiCnt = 0; iiCnt < CmbCurr.Items.Count; iiCnt++)
                {
                    CmbCurr.SelectedIndex = iiCnt;
                    if (CmbCurr.SelectedValue != null && CmbCurr.SelectedValue.ToString() == value.curr.Value.ToString())
                    {
                        break;
                    }
                }
                if (value.perno.HasValue)
                {
                    CmbGuestNo.SelectedValue = value.perno;
                }
                textBox_NameA.Text = value.SndName;
                if (value.romno.HasValue)
                {
                    txtRoom.Value = value.romno.Value;
                }
                txtPaymentLoc.Value = value.price.Value;
                txtRemark.Text = value.det;
                txtDate.Text = value.dt;
                txtTime.Text = value.tm;
                txtRef.Text = value.ShekNo;
                txtDebit1.Text = string.Empty;
                txtCredit1.Text = string.Empty;
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
                if (value.ShekBank == "1")
                {
                    switchButton_Lock.Value = true;
                }
                else
                {
                    switchButton_Lock.Value = false;
                }
                if (value.T_per.ch == 3)
                {
                    CmbGuestNo.Enabled = false;
                    txtDate.Enabled = false;
                    txtTime.Enabled = false;
                    txtRef.Enabled = false;
                    CmbCurr.Enabled = false;
                    txtRemark.Enabled = false;
                    labelGuestStat.Visible = true;
                }
                else
                {
                    CmbGuestNo.Enabled = true;
                    txtDate.Enabled = true;
                    txtTime.Enabled = true;
                    txtRef.Enabled = true;
                    CmbCurr.Enabled = true;
                    txtRemark.Enabled = true;
                    labelGuestStat.Visible = false;
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
        private T_Snd GetData()
        {
            textBox_ID.Focus();
            data_this.fNo = int.Parse(textBox_ID.Text);
            try
            {
                data_this.curr = int.Parse(CmbCurr.SelectedValue.ToString());
            }
            catch
            {
                data_this.curr = null;
            }
            data_this.perno = int.Parse(CmbGuestNo.SelectedValue.ToString());
            data_this.SndName = textBox_NameA.Text;
            data_this.romno = txtRoom.Value;
            data_this.price = txtPaymentLoc.Value;
            data_this.typ = VarGeneral.SndTyp;
            data_this.typN = 0;
            data_this.det = txtRemark.Text;
            data_this.ShekDate = string.Empty;
            data_this.ShekNo = txtRef.Text;
            if (switchButton_Lock.Value)
            {
                data_this.ShekBank = "1";
            }
            else
            {
                data_this.ShekBank = "0";
            }
            data_this.curcost = 1.0;
            data_this.ch = 1;
            data_this.dt = txtDate.Text;
            data_this.tm = txtTime.Text;
            data_this.Usr = VarGeneral.UserNo;
            data_this.IfTrans = 0;
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
            if (!Button_Add.Visible || !Button_Add.Enabled)
            {
                MessageBox.Show((LangArEn == 0) ? "لا يمكن اتمام هذه العملية .. الرجاء مراجعة صلاحيات المستخدمين !" : "Can not complete this process .. please see the powers of the users!", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                if (State == FormState.Edit && MessageBox.Show((LangArEn == 0) ? "تم تعديل السجل الحالي دون حفظ التغييرات .. هل تريد المتابعة؟" : "Not saved the changes, do you really want to continue?", VarGeneral.ProdectNam, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
                {
                    return;
                }
                int max = 0;
                max = db.MaxSndNo;
                Clear();
                textBox_ID.Text = max.ToString();
                MaskedTextBox maskedTextBox = txtDate;
                int? calendr = VarGeneral.Settings_Sys.Calendr;
                maskedTextBox.Text = ((calendr.Value == 0 && calendr.HasValue) ? n.FormatGreg(VarGeneral.Gdate, "yyyy/MM/dd") : n.FormatHijri(VarGeneral.Hdate, "yyyy/MM/dd"));
                txtTime.Text = DateTime.Now.ToString("HH:mm");
                try
                {
                    if (!VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 46))
                    {
                        switchButton_Lock.Value = true;
                    }
                }
                catch
                {
                    switchButton_Lock.Value = true;
                }
                State = FormState.New;
            }
        }
        private void AutoGaidAcc()
        {
            if (!(_InvSetting.InvSetting.Substring(1, 1) == "1"))
            {
                return;
            }
            txtCredit1.Tag = ((_InvSetting.AccCredit0.Trim() != "***") ? _InvSetting.AccCredit0.Trim() : string.Empty);
            if (!string.IsNullOrEmpty(txtCredit1.Tag.ToString()))
            {
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                {
                    txtCredit1.Text = db.SelectAccRootByCode(txtCredit1.Tag.ToString()).Arb_Des;
                }
                else
                {
                    txtCredit1.Text = db.SelectAccRootByCode(txtCredit1.Tag.ToString()).Eng_Des;
                }
            }
            else
            {
                txtCredit1.Text = string.Empty;
            }
            txtDebit1.Tag = ((_InvSetting.AccDebit0.Trim() != "***") ? _InvSetting.AccDebit0.Trim() : string.Empty);
            if (!string.IsNullOrEmpty(txtDebit1.Tag.ToString()))
            {
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                {
                    txtDebit1.Text = db.SelectAccRootByCode(txtDebit1.Tag.ToString()).Arb_Des;
                }
                else
                {
                    txtDebit1.Text = db.SelectAccRootByCode(txtDebit1.Tag.ToString()).Eng_Des;
                }
            }
            else
            {
                txtDebit1.Text = string.Empty;
            }
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
                            string dtAction = (n.IsHijri(txtDate.Text) ? txtDate.Text : n.GregToHijri(txtDate.Text, "yyyy/MM/dd"));
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
                if (!Button_Save.Enabled)
                {
                    return;
                }
                textBox_ID.Focus();
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
                if (textBox_ID.Text == string.Empty || string.IsNullOrEmpty(CmbGuestNo.Text))
                {
                    MessageBox.Show((LangArEn == 0) ? "لايمكن ان يكون الرقم او الإسم فارغا\u0651" : "Can not be a number or name is empty", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    textBox_ID.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(txtRoom.Text))
                {
                    MessageBox.Show((LangArEn == 0) ? "لايمكن ان رقم الغرفة فارغا" : "Can not be Room No is empty", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    txtRoom.Focus();
                    return;
                }
                if (txtPaymentLoc.Value <= 0.0)
                {
                    MessageBox.Show((LangArEn == 0) ? "تأكد من قيمة الخدمة" : "Make sure the value of the service", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    txtPaymentLoc.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(txtRemark.Text))
                {
                    MessageBox.Show((LangArEn == 0) ? "لايمكن ان يكون االوصف فارغا\u0651" : "Can not be the description is empty", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    txtRemark.Focus();
                    return;
                }
                if (switchButton_Lock.Value && (string.IsNullOrEmpty(txtCredit1.Text) || string.IsNullOrEmpty(txtDebit1.Text)))
                {
                    MessageBox.Show((LangArEn == 0) ? "لا يمكن إتمام العملية .. تأكد من صحة الطرف الدائن والمدين للقيد .. " : "You can not complete the operation .. Make sure the creditor and debitor under the party ..", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                if (false)
                {
                    Environment.Exit(0);
                    return;
                }
                if (State == FormState.New)
                {
                    GetData();
                    try
                    {
                        textBox_ID.TextChanged -= textBox_ID_TextChanged;
                        int max = 0;
                        max = db.MaxSndNo;
                        textBox_ID.Text = string.Concat(max);
                        data_this.fNo = max;
                        textBox_ID.TextChanged += textBox_ID_TextChanged;
                        data_this.gdUser = VarGeneral.UserNumber;
                        data_this.gdUserNam = VarGeneral.UserNameA;
                        db.T_Snds.InsertOnSubmit(data_this);
                        db.SubmitChanges();
                    }
                    catch (SqlException ex)
                    {
                        int max = 0;
                        max = db.MaxSndNo;
                        if (ex.Number != 2627)
                        {
                            return;
                        }
                        MessageBox.Show("رقم السند مستخدم من قبل.\n سيتم الحفظ برقم جديد [" + max + "]", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Question);
                        textBox_ID.Text = string.Concat(max);
                        data_this.fNo = max;
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
                string AccCrdt = string.Empty;
                string AccDbt = string.Empty;
                if (!switchButton_Lock.Value)
                {
                    goto IL_053c;
                }
                if (txtPaymentLoc.Value > 0.0)
                {
                    AccCrdt = txtCredit1.Tag.ToString();
                    AccDbt = txtDebit1.Tag.ToString();
                }
                if (AccCrdt == string.Empty && txtPaymentLoc.Value > 0.0)
                {
                    MessageBox.Show((LangArEn == 0) ? "لا يمكن إتمام العملية .. تأكد من صحة الطرف الدائن للقيد .. " : "You can not complete the operation .. Make sure the creditor under the party ..", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                if (!(AccDbt == string.Empty) || !(txtPaymentLoc.Value > 0.0))
                {
                    goto IL_053c;
                }
                MessageBox.Show((LangArEn == 0) ? "لا يمكن إتمام العملية .. تأكد من صحة الطرف المدين للقيد .. " : "You can not complete the operation .. Make sure the debtor under the party ..", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                goto end_IL_0001;
                IL_053c:
                if (txtPaymentLoc.Value > 0.0 && !string.IsNullOrEmpty(AccCrdt) && !string.IsNullOrEmpty(AccDbt))
                {
                    IDatabase db_ = Database.GetDatabase(VarGeneral.BranchCS);
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
                    if (txtPaymentLoc.Value > 0.0 && !string.IsNullOrEmpty(AccCrdt) && !string.IsNullOrEmpty(AccDbt))
                    {
                        db_.StartTransaction();
                        db_.ClearParameters();
                        db_.AddParameter("GDDET_ID", DbType.Int32, 0);
                        db_.AddParameter("gdID", DbType.Int32, _GdHead.gdhead_ID);
                        db_.AddParameter("gdNo", DbType.String, textBox_ID.Text);
                        db_.AddParameter("gdDes", DbType.String, (VarGeneral.SndTyp == 1) ? ("قيد تلقائي لسند قبض نزيل رقم : " + textBox_ID.Text) : ("قيد تلقائي لسند صرف نزيل رقم : " + textBox_ID.Text));
                        db_.AddParameter("gdDesE", DbType.String, (VarGeneral.SndTyp == 1) ? ("Auto Bound Catch To Guest No : " + textBox_ID.Text) : ("Auto Bound exchange To Guest No : " + textBox_ID.Text));
                        db_.AddParameter("recptTyp", DbType.String, "1");
                        db_.AddParameter("AccNo", DbType.String, AccCrdt);
                        db_.AddParameter("AccName", DbType.String, string.Empty);
                        db_.AddParameter("gdValue", DbType.Double, 0.0 - double.Parse(txtPaymentLoc.Text));
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
                        db_.AddParameter("gdDes", DbType.String, (VarGeneral.SndTyp == 1) ? ("قيد تلقائي لسند قبض نزيل رقم : " + textBox_ID.Text) : ("قيد تلقائي لسند صرف نزيل رقم : " + textBox_ID.Text));
                        db_.AddParameter("gdDesE", DbType.String, (VarGeneral.SndTyp == 1) ? ("Auto Bound Catch To Guest No : " + textBox_ID.Text) : ("Auto Bound exchange To Guest No : " + textBox_ID.Text));
                        db_.AddParameter("recptTyp", DbType.String, "1");
                        db_.AddParameter("AccNo", DbType.String, AccDbt);
                        db_.AddParameter("AccName", DbType.String, string.Empty);
                        db_.AddParameter("gdValue", DbType.Double, double.Parse(txtPaymentLoc.Text));
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
                if (txtPaymentLoc.Value > 0.0 && !string.IsNullOrEmpty(AccCrdt) && !string.IsNullOrEmpty(AccDbt))
                {
                    data_this.GadeId = _GdHead.gdhead_ID;
                    data_this.GadeNo = int.Parse(textBox_ID.Text);
                }
                else
                {
                    data_this.GadeId = null;
                    try
                    {
                        if (State == FormState.New)
                        {
                            data_this.GadeNo = null;
                        }
                        else if (data_this.GadeNo != 0.0)
                        {
                            data_this.GadeNo = null;
                        }
                    }
                    catch
                    {
                        data_this.GadeNo = null;
                    }
                }
                db.Log = VarGeneral.DebugLog;
                db.SubmitChanges(ConflictMode.ContinueOnConflict);
                State = FormState.Saved;
                RefreshPKeys();
                TextBox_Index.TextBox.Text = string.Concat(PKeys.IndexOf(string.Concat(data_this.fNo)) + 1);
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
        private T_GDHEAD GetDataGd()
        {
            _GdHead.gdHDate = (n.IsHijri(txtDate.Text) ? txtDate.Text : n.GregToHijri(txtDate.Text, "yyyy/MM/dd"));
            _GdHead.gdGDate = (n.IsGreg(txtDate.Text) ? txtDate.Text : n.HijriToGreg(txtDate.Text, "yyyy/MM/dd"));
            _GdHead.gdNo = textBox_ID.Text;
            _GdHead.ArbTaf = ScriptNumber1.ScriptNum(decimal.Parse("0" + txtPaymentLoc.Text));
            _GdHead.BName = _GdHead.BName;
            _GdHead.ChekNo = _GdHead.ChekNo;
            _GdHead.CurTyp = int.Parse(CmbCurr.SelectedValue.ToString());
            _GdHead.EngTaf = ScriptNumber1.TafEng(decimal.Parse("0" + txtPaymentLoc.Text));
            _GdHead.gdCstNo = 1;
            _GdHead.gdID = 0;
            _GdHead.gdLok = false;
            _GdHead.gdMem = txtRemark.Text;
            _GdHead.gdMnd = null;
            _GdHead.gdRcptID = (_GdHead.gdRcptID.HasValue ? _GdHead.gdRcptID.Value : 0.0);
            _GdHead.gdTot = txtPaymentLoc.Value;
            _GdHead.gdTp = (_GdHead.gdTp.HasValue ? _GdHead.gdTp.Value : 0);
            _GdHead.gdTyp = VarGeneral.InvTyp;
            _GdHead.RefNo = string.Empty;
            _GdHead.AdminLock = false;
            _GdHead.DATE_MODIFIED = DateTime.Now;
            _GdHead.salMonth = string.Empty;
            _GdHead.gdUser = VarGeneral.UserNumber;
            _GdHead.gdUserNam = VarGeneral.UserNameA;
            _GdHead.CompanyID = 1;
            return _GdHead;
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
            if (MessageBox.Show("هل أنت متاكد من حذف السجل [" + Code + "]؟ \n Are you sure that you want to delete the record [" + Code + "]?", VarGeneral.ProdectNam, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ifOkDelete = true;
            }
            else
            {
                ifOkDelete = false;
            }
            if (labelGuestStat.Visible)
            {
                try
                {
                    if (permission.RepInv5 != "1")
                    {
                        MessageBox.Show((LangArEn == 0) ? "لا يمكن اتمام العملية .. لان هذا النزيل مغادر" : "The process can not be completed ... because this guest is leaving", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        return;
                    }
                }
                catch
                {
                    MessageBox.Show((LangArEn == 0) ? "لا يمكن اتمام العملية .. لان هذا النزيل مغادر" : "The process can not be completed ... because this guest is leaving", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
            }
            if (data_this != null && data_this.fNo != 0 && ifOkDelete)
            {
                data_this = db.StockSnd(VarGeneral.SndTyp, DataThis.fNo);
                try
                {
                    IDatabase db_ = Database.GetDatabase(VarGeneral.BranchCS);
                    db_.StartTransaction();
                    db_.ClearParameters();
                    db_.AddParameter("gdhead_ID", DbType.Int32, _GdHead.gdhead_ID);
                    db_.ExecuteNonQueryWithoutCommit(storedProcedure: true, "S_T_GDHEAD_DELETE");
                    db_.EndTransaction();
                    db.T_Snds.DeleteOnSubmit(DataThis);
                    db.SubmitChanges();
                }
                catch (SqlException)
                {
                    data_this = db.StockSnd(VarGeneral.SndTyp, DataThis.fNo);
                    return;
                }
                catch (Exception)
                {
                    data_this = db.StockSnd(VarGeneral.SndTyp, DataThis.fNo);
                    return;
                }
                Clear();
                RefreshPKeys();
                textBox_ID.Text = PKeys.LastOrDefault();
            }
        }
        private void DGV_Main_DataBindingComplete(object sender, GridDataBindingCompleteEventArgs e)
        {
            GridPanel panel = e.GridPanel;
            string dataMember = panel.DataMember;
            if (dataMember != null && dataMember == "T_Snd")
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
            panel.Columns["perno"].Width = 100;
            panel.Columns["perno"].Visible = columns_Names_visible["perno"].IfDefault;
            panel.Columns["SndName"].Width = 250;
            panel.Columns["SndName"].Visible = columns_Names_visible["SndName"].IfDefault;
            panel.Columns["SndNameE"].Width = 250;
            panel.Columns["SndNameE"].Visible = columns_Names_visible["SndNameE"].IfDefault;
            panel.Columns["fNo"].Width = 120;
            panel.Columns["fNo"].Visible = columns_Names_visible["fNo"].IfDefault;
            panel.Columns["romno"].Width = 100;
            panel.Columns["romno"].Visible = columns_Names_visible["romno"].IfDefault;
            panel.Columns["price"].Width = 100;
            panel.Columns["price"].Visible = columns_Names_visible["price"].IfDefault;
            panel.Columns["dt"].Width = 100;
            panel.Columns["dt"].Visible = columns_Names_visible["dt"].IfDefault;
            panel.Columns["tm"].Width = 100;
            panel.Columns["tm"].Visible = columns_Names_visible["tm"].IfDefault;
            panel.ReadOnly = true;
        }
        private void DGV_MainGetCellStyle(object sender, GridGetCellStyleEventArgs e)
        {
        }
        private void Button_ExportTable2_Click(object sender, EventArgs e)
        {
            try
            {
                ExportExcel.ExportToExcel(DGV_Main, "تقرير سندات النزلاء");
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
        private void txtDate_Click(object sender, EventArgs e)
        {
            txtDate.SelectAll();
        }
        private void txtDate_Leave(object sender, EventArgs e)
        {
            try
            {
                if (VarGeneral.CheckDate(txtDate.Text))
                {
                    txtDate.Text = Convert.ToDateTime(txtDate.Text).ToString("yyyy/MM/dd");
                    return;
                }
                MaskedTextBox maskedTextBox = txtDate;
                int? calendr = VarGeneral.Settings_Sys.Calendr;
                maskedTextBox.Text = ((calendr.Value == 0 && calendr.HasValue) ? n.FormatGreg(VarGeneral.Gdate, "yyyy/MM/dd") : n.FormatHijri(VarGeneral.Hdate, "yyyy/MM/dd"));
            }
            catch
            {
                MaskedTextBox maskedTextBox2 = txtDate;
                int? calendr = VarGeneral.Settings_Sys.Calendr;
                maskedTextBox2.Text = ((calendr.Value == 0 && calendr.HasValue) ? n.FormatGreg(VarGeneral.Gdate, "yyyy/MM/dd") : n.FormatHijri(VarGeneral.Hdate, "yyyy/MM/dd"));
            }
        }
        private void txtTime_Click(object sender, EventArgs e)
        {
            txtTime.SelectAll();
        }
        private void txtTime_Leave(object sender, EventArgs e)
        {
            try
            {
                if (VarGeneral.CheckTime(txtTime.Text))
                {
                    txtTime.Text = TimeSpan.Parse(txtTime.Text).ToString();
                }
                else
                {
                    txtTime.Text = DateTime.Now.ToString("HH:mm");
                }
            }
            catch
            {
                txtTime.Text = DateTime.Now.ToString("HH:mm");
            }
        }
        private void Total(T_per _per)
        {
            Ttot = new double[9];
            double Pri = 0.0;
            double vTax = 0.0;
            double vSer = 0.0;
            double vDay = 0.0;
            Tot1 = 0.0;
            Tot2 = 0.0;
            Tot3 = 0.0;
            Tot4 = 0.0;
            Tot5 = 0.0;
            Tot6 = 0.0;
            Tot7 = 0.0;
            Tot8 = 0.0;
            Tot10 = 0.0;
            tot50 = 0.0;
            tot60 = 0.0;
            tt1 = 0.0;
            Tot = 0.0;
            TotResturant = 0.0;
            dis = 0.0;
            double[,] RomAr = new double[SerTypeCount + 1, 8];
            string[,] RomDt = new string[SerTypeCount + 1, 5];
            for (int q2 = 0; q2 <= SerTypeCount; q2++)
            {
                for (int q3 = 0; q3 <= 7; q3++)
                {
                    RomAr[q2, q3] = 0.0;
                }
                for (int q4 = 0; q4 <= 1; q4++)
                {
                    RomDt[q2, q4] = string.Empty;
                }
            }
            dis = _per.dis.Value;
            RomAr[0, 0] = _per.romno.Value;
            RomAr[0, 1] = _per.price.Value;
            if (_per.tax.HasValue)
            {
                RomAr[0, 2] = _per.tax.Value;
            }
            else
            {
                RomAr[0, 2] = 0.0;
            }
            if (_per.ser.HasValue)
            {
                RomAr[0, 3] = _per.ser.Value;
            }
            else
            {
                RomAr[0, 3] = 0.0;
            }
            if (_per.gropno.HasValue)
            {
                RomAr[0, 7] = _per.gropno.Value;
            }
            else
            {
                RomAr[0, 7] = 0.0;
            }
            RomDt[0, 0] = _per.dt2;
            RomDt[0, 1] = _per.tm1;
            RomDt[0, 2] = _per.dt3;
            RomDt[0, 3] = _per.tm2;
            try
            {
                VarGeneral.DayEdit = _per.DayEdit.Value;
            }
            catch
            {
                VarGeneral.DayEdit = 0;
            }
            if (_per.KindPer.Value == 1)
            {
                if (_per.DayOfM.HasValue)
                {
                    VarGeneral.GDayM = _per.DayOfM.Value;
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
            }
            for (int q = 0; q <= SerTypeCount; q++)
            {
                if (RomAr[q, 0] == 0.0)
                {
                    continue;
                }
                if (string.IsNullOrEmpty(_per.dt3))
                {
                    if (_per.KindPer.Value == 0)
                    {
                        aa = VarGeneral.Dy(RomDt[q, 0], RomDt[q, 1] + " " + _per.vAmPm) + VarGeneral.DayEdit;
                    }
                    else
                    {
                        aa = VarGeneral.Dy(RomDt[q, 0], RomDt[q, 1] + " " + _per.vAmPm) + VarGeneral.DayEdit;
                        VarGeneral.Dy2(RomDt[q, 0], RomDt[q, 1] + " " + _per.vAmPm);
                    }
                }
                else if (_per.KindPer.Value == 0)
                {
                    aa = VarGeneral.Dy1(RomDt[q, 0], RomDt[q, 1] + " " + _per.vAmPm, RomDt[q, 2], RomDt[q, 3]) + VarGeneral.DayEdit;
                }
                else
                {
                    aa = VarGeneral.Dy1(RomDt[q, 0], RomDt[q, 1] + " " + _per.vAmPm, RomDt[q, 2], RomDt[q, 3]) + VarGeneral.DayEdit;
                    VarGeneral.Dy2(RomDt[q, 0], RomDt[q, 1] + " " + _per.vAmPm);
                }
                if (_per.KindPer.Value == 0)
                {
                    RomAr[q, 6] = Conversion.Val(Strings.Format(Conversion.Val(RomAr[q, 1]) * Conversion.Val(aa), "#.00"));
                }
                else
                {
                    RomAr[q, 6] = Conversion.Val(Strings.Format(Conversion.Val(RomAr[q, 1]) * (double)VarGeneral.CS, "#.00"));
                }
                RomAr[q, 4] = Conversion.Val(RomAr[q, 2]) * Conversion.Val(RomAr[q, 6]) / 100.0;
                RomAr[q, 5] = Conversion.Val(RomAr[q, 3]) * Conversion.Val(RomAr[q, 6]) / 100.0;
                Pri += RomAr[q, 6];
                vTax += RomAr[q, 4];
                vSer += RomAr[q, 5];
                vDay += aa;
            }
            Tot1 = 0.0;
            Tot2 = 0.0;
            Tot3 = 0.0;
            Tot4 = 0.0;
            Tot5 = 0.0;
            Tot6 = 0.0;
            tot50 = 0.0;
            tot60 = 0.0;
            Tot7 = 0.0;
            Tot8 = 0.0;
            Tot10 = 0.0;
            try
            {
                List<double> sqlst2 = db.ExecuteQuery<double>("select sum(price) as SumPrice from [T_tran] where perno=" + _per.perno, new object[0]).ToList();
                if (sqlst2.Count > 0)
                {
                    Tot1 = ((!string.IsNullOrEmpty(sqlst2.FirstOrDefault().ToString())) ? sqlst2.FirstOrDefault() : 0.0);
                }
            }
            catch
            {
                Tot1 = 0.0;
            }
            try
            {
                List<double> sqlst2 = db.ExecuteQuery<double>("select sum(price) as SumPrice from [T_tel] where perno=" + _per.perno, new object[0]).ToList();
                if (sqlst2.Count > 0)
                {
                    Tot2 = ((!string.IsNullOrEmpty(sqlst2.FirstOrDefault().ToString())) ? sqlst2.FirstOrDefault() : 0.0);
                }
            }
            catch
            {
                Tot2 = 0.0;
            }
            try
            {
                List<double> sqlst2 = db.ExecuteQuery<double>("SELECT Sum(case when [T_Snd].[typ]=1 then [T_Snd].[price]*[T_Snd].[curcost] else -[T_Snd].[price]*[T_Snd].[curcost] end) AS SumPrice FROM [T_Snd] where perno=" + _per.perno + " and ch<>3", new object[0]).ToList();
                if (sqlst2.Count > 0)
                {
                    Tot3 = ((!string.IsNullOrEmpty(sqlst2.FirstOrDefault().ToString())) ? sqlst2.FirstOrDefault() : 0.0);
                }
            }
            catch
            {
                Tot3 = 0.0;
            }
            try
            {
                List<T_AccDef> sqlst = (from er in db.T_AccDefs
                                        where er.AccDef_No == _per.Cust_no
                                        orderby er.AccDef_No
                                        select er).ToList();
                if (sqlst.Count() > 0)
                {
                    sqlst.First().Debit = sqlst.First().T_GDDETs.Where((T_GDDET g) => !g.T_GDHEAD.gdLok && g.T_AccDef.Lev == 4 && g.gdValue > 0.0 && g.T_GDHEAD.gdTyp != 15 && g.T_GDHEAD.gdTyp != 27 && g.T_GDHEAD.gdTyp != 28).Sum((T_GDDET g) => g.gdValue.Value);
                    sqlst.First().Credit = Math.Abs(sqlst.First().T_GDDETs.Where((T_GDDET g) => !g.T_GDHEAD.gdLok && g.T_AccDef.Lev == 4 && g.gdValue < 0.0 && g.T_GDHEAD.gdTyp != 15 && g.T_GDHEAD.gdTyp != 27 && g.T_GDHEAD.gdTyp != 28).Sum((T_GDDET g) => g.gdValue.Value));
                    sqlst.First().Balance = sqlst.First().T_GDDETs.Where((T_GDDET g) => !g.T_GDHEAD.gdLok && g.T_AccDef.Lev == 4 && g.T_GDHEAD.gdTyp != 15 && g.T_GDHEAD.gdTyp != 27 && g.T_GDHEAD.gdTyp != 28).Sum((T_GDDET g) => g.gdValue.Value);
                }
                if (sqlst.Count > 0)
                {
                    TotResturant = sqlst.FirstOrDefault().Balance.Value;
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
            Tot4 = Pri;
            Tot10 = Tot1 + Tot2 + Tot4;
            double vTx = 0.0;
            double vSr = 0.0;
            try
            {
                vTx = db.StockRoom(_per.romno.Value).tax.Value;
            }
            catch
            {
                vTx = 0.0;
            }
            try
            {
                vSr = db.StockRoom(_per.romno.Value).ser.Value;
            }
            catch
            {
                vSr = 0.0;
            }
            Tot5 = Tot4 * vTx / 100.0;
            Tot6 = Tot4 * vSer / 100.0;
            Tot10 = Tot1 + Tot2 + Tot4 + Tot5 + Tot6;
            if (_per.disknd.Value == 1)
            {
                if (_per.distyp.Value == 0)
                {
                    for (int i = 0; i <= SerTypeCount; i++)
                    {
                        if (RomAr[i, 0] != 0.0)
                        {
                            tt1 = RomAr[i, 6];
                            Tot7 = Conversion.Val(tt1) * Conversion.Val(dis) / 100.0;
                            tt1 = Conversion.Val(tt1) - Conversion.Val(Tot7);
                            Tot4 -= Tot7;
                            tot50 += Conversion.Val(tt1) * Conversion.Val(RomAr[i, 2]) / 100.0;
                            tot60 += Conversion.Val(tt1) * Conversion.Val(RomAr[i, 3]) / 100.0;
                        }
                    }
                    Tot5 = tot50;
                    Tot6 = tot60;
                }
                else if (_per.distyp.Value == 1)
                {
                    Tot8 = Tot10 * dis / 100.0;
                }
            }
            if (_per.disknd.Value == 2)
            {
                if (_per.distyp.Value == 0)
                {
                    Tot7 = Conversion.Val(dis * vDay);
                    for (int i = 0; i <= SerTypeCount; i++)
                    {
                        if (RomAr[i, 0] != 0.0)
                        {
                            tt1 = RomAr[i, 6];
                            tt1 = Conversion.Val(tt1) - Conversion.Val(Tot7);
                            Tot4 -= Tot7;
                            tot50 += Conversion.Val(tt1) * Conversion.Val(RomAr[i, 2]) / 100.0;
                            tot60 += Conversion.Val(tt1) * Conversion.Val(RomAr[i, 3]) / 100.0;
                        }
                    }
                    Tot5 = tot50;
                    Tot6 = tot60;
                }
                else if (_per.distyp.Value == 1)
                {
                    Tot8 = dis;
                }
            }
            if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 48))
            {
                Tot10 = Tot1 + Tot2 + Tot4 + Tot5 + Tot6 - Tot8;
            }
            else
            {
                Tot10 = Tot1 + Tot2 + Tot4 + Tot5 + Tot6 - Tot8;
            }
            Tot = Tot10 - Tot3;
            double Snd = 0.0;
            double Ser = 0.0;
            double Tel = 0.0;
            Pri = Tot4;
            vTax = Tot5;
            vSer = Tot6;
            Snd = Tot3;
            Ser = Tot1;
            Tel = Tot2;
            Ttot[0] = vDay;
            Ttot[1] = Pri;
            if (vDay != 0.0)
            {
                if (_per.KindPer.Value == 0)
                {
                    Ttot[2] = Pri / vDay;
                }
                else if (_per.KindPer.Value == 1)
                {
                    Ttot[2] = Pri / (double)VarGeneral.CS;
                }
            }
            Ttot[3] = vSer;
            Ttot[4] = Ser;
            Ttot[5] = Tel;
            Ttot[6] = Snd;
            Ttot[7] = Tot;
            Ttot[8] = Tot8;
        }
        private void GetGuestBalance(int _perno)
        {
            txtGuestBalance.Value = 0.0;
            txtPaymentLoc.MaxValue = double.MaxValue;
            RepShow _RepShow = new RepShow();
            _RepShow.Tables = " T_per ";
            string Fields = " T_per.*,(select LogImg from T_SYSSETTING where T_SYSSETTING.SYSSETTING_ID = 1) as LogImg,(select T_AccDef.Arb_Des from T_AccDef where T_AccDef.AccDef_No = T_per.Cust_no) as AccDefNm,(select T_AccDef.Eng_Des from T_AccDef where T_AccDef.AccDef_No = T_per.Cust_no) as AccDefNmE";
            _RepShow.Rule = " where T_per.perno = " + _perno;
            _RepShow.Fields = Fields;
            try
            {
                _RepShow = _RepShow.Save();
                VarGeneral.RepData = _RepShow.RepData;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            if (VarGeneral.RepData.Tables[0].Rows.Count <= 0)
            {
                return;
            }
            int i = 6;
            vData = new string[SerTypeCount + 1, 8];
            vData[0, 0] = ((LangArEn == 0) ? "عدد أيام السكن" : "Number of days of residence");
            vData[1, 0] = ((LangArEn == 0) ? "إجمالي قيمة فترة الإقامة" : "Total Length of Stay");
            vData[2, 0] = ((LangArEn == 0) ? "السعــــر" : "Price");
            vData[3, 0] = ((LangArEn == 0) ? "إجمالي قيمة الخدمات الإضافية" : "Total of additional services");
            vData[4, 0] = ((LangArEn == 0) ? "إجمالي قيمة الخصم" : "Total Discount Value");
            vData[5, 0] = ((LangArEn == 0) ? "إجمالي المطلوب من حركات محاسبية أخرى" : "Total required from other accounting movements");
            List<T_sertyp> q = db.T_sertyps.Select((T_sertyp t) => t).ToList();
            for (i = 6; i < q.Count + 6; i++)
            {
                vData[i, 0] = ((LangArEn == 0) ? q[i - 6].Arb_Des : q[i - 6].Eng_Des);
                vData[i, 2] = q[i - 6].Serv_No;
            }
            for (int j = 6; j < i; j++)
            {
                try
                {
                    List<double> sqlst = db.ExecuteQuery<double>("select sum(price) as SumPrice from [T_tran] where perno=" + _perno + " and typ = " + vData[j, 2], new object[0]).ToList();
                    if (sqlst.Count > 0)
                    {
                        double tot11 = ((!string.IsNullOrEmpty(sqlst.FirstOrDefault().ToString())) ? sqlst.FirstOrDefault() : 0.0);
                        Tot1 += tot11;
                        vData[j, 1] = Tot1.ToString();
                    }
                }
                catch
                {
                    Tot1 += 0.0;
                    vData[j, 1] = "0";
                }
            }
            try
            {
                List<double> sqlst = db.ExecuteQuery<double>("select sum(price) as SumPrice from [T_tel] where perno=" + _perno, new object[0]).ToList();
                if (sqlst.Count > 0)
                {
                    Tot2 = ((!string.IsNullOrEmpty(sqlst.FirstOrDefault().ToString())) ? sqlst.FirstOrDefault() : 0.0);
                }
            }
            catch
            {
                Tot2 = 0.0;
            }
            i++;
            vData[i, 0] = ((LangArEn == 0) ? "المكالمات الهاتفية" : "Phone calls");
            vData[i, 1] = Tot2.ToString();
            try
            {
                Stock_DataDataContext _DB2 = new Stock_DataDataContext(VarGeneral.BranchCS);
                try
                {
                    List<T_AccDef> sqlst3 = (from er in _DB2.T_AccDefs
                                             where er.AccDef_No == _DB2.StockPer(_perno).Cust_no
                                             orderby er.AccDef_No
                                             select er).ToList();
                    if (sqlst3.Count() > 0)
                    {
                        sqlst3.First().Debit = sqlst3.First().T_GDDETs.Where((T_GDDET g) => !g.T_GDHEAD.gdLok && g.T_AccDef.Lev == 4 && g.gdValue > 0.0 && g.T_GDHEAD.gdTyp != 15 && g.T_GDHEAD.gdTyp != 27 && g.T_GDHEAD.gdTyp != 28).Sum((T_GDDET g) => g.gdValue.Value);
                        sqlst3.First().Credit = Math.Abs(sqlst3.First().T_GDDETs.Where((T_GDDET g) => !g.T_GDHEAD.gdLok && g.T_AccDef.Lev == 4 && g.gdValue < 0.0 && g.T_GDHEAD.gdTyp != 15 && g.T_GDHEAD.gdTyp != 27 && g.T_GDHEAD.gdTyp != 28).Sum((T_GDDET g) => g.gdValue.Value));
                        sqlst3.First().Balance = sqlst3.First().T_GDDETs.Where((T_GDDET g) => !g.T_GDHEAD.gdLok && g.T_AccDef.Lev == 4 && g.T_GDHEAD.gdTyp != 15 && g.T_GDHEAD.gdTyp != 27 && g.T_GDHEAD.gdTyp != 28).Sum((T_GDDET g) => g.gdValue.Value);
                    }
                    if (sqlst3.Count > 0)
                    {
                        if (sqlst3.FirstOrDefault().Balance.Value < 0.0)
                        {
                            Tot3 = Math.Abs(sqlst3.FirstOrDefault().Balance.Value);
                        }
                        else
                        {
                            Tot3 = 0.0 - sqlst3.FirstOrDefault().Balance.Value;
                        }
                    }
                }
                finally
                {
                    if (_DB2 != null)
                    {
                        ((IDisposable)_DB2).Dispose();
                    }
                }
            }
            catch
            {
                Tot3 = 0.0;
            }
            try
            {
                if (Tot3 < 0.0)
                {
                    Tot3 = 0.0;
                }
                if (Tot3 > 0.0)
                {
                    Stock_DataDataContext _DB = new Stock_DataDataContext(VarGeneral.BranchCS);
                    try
                    {
                        List<T_per> sqlst2 = _DB.T_pers.Where((T_per er) => er.Cust_no == _DB.StockPer(_perno).Cust_no).ToList();
                        if (sqlst2.Count > 0)
                        {
                            double cc = sqlst2.Sum((T_per g) => g.fat.Value);
                            if (cc > 0.0 && cc <= Tot3)
                            {
                                Tot3 -= cc;
                            }
                        }
                    }
                    finally
                    {
                        if (_DB != null)
                        {
                            ((IDisposable)_DB).Dispose();
                        }
                    }
                }
            }
            catch
            {
            }
            i++;
            Total(db.StockPer(_perno));
            vData[i, 0] = ((LangArEn == 0) ? "إجمالي المدفوع" : "Total Paid");
            vData[i, 1] = Tot3.ToString();
            vData[0, 1] = Ttot[0].ToString();
            vData[1, 1] = Ttot[1].ToString();
            vData[2, 1] = Ttot[2].ToString();
            vData[3, 1] = Ttot[3].ToString();
            if (db.StockPer(_perno).disknd.Value == 1)
            {
                if (db.StockPer(_perno).distyp.Value == 0)
                {
                    vData[4, 1] = Tot7.ToString();
                }
                else if (db.StockPer(_perno).distyp.Value == 1)
                {
                    vData[4, 1] = Tot8.ToString();
                }
            }
            else if (db.StockPer(_perno).disknd.Value == 2)
            {
                if (db.StockPer(_perno).distyp.Value == 0)
                {
                    vData[4, 1] = Tot7.ToString();
                }
                else if (db.StockPer(_perno).distyp.Value == 1)
                {
                    vData[4, 1] = Tot8.ToString();
                }
            }
            vData[5, 1] = TotResturant.ToString();
            if (data_this.price.HasValue && VarGeneral.SndTyp == 1)
            {
                txtGuestBalance.Value = double.Parse(VarGeneral.TString.TEmpty(Ttot[7].ToString())) + data_this.price.Value;
            }
            else
            {
                txtGuestBalance.Value = double.Parse(VarGeneral.TString.TEmpty(Ttot[7].ToString()));
            }
            if (VarGeneral.SndTyp == 1)
            {
                txtPaymentLoc.MaxValue = txtGuestBalance.Value;
            }
        }
        private void CmbGuestNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                T_per Q = db.StockPer(int.Parse(CmbGuestNo.SelectedValue.ToString()));
                if (Q == null || Q.perno == 0)
                {
                    return;
                }
                txtRoom.Value = Q.romno.Value;
                textBox_NameA.Text = ((LangArEn == 0) ? Q.T_AccDef.Arb_Des : Q.T_AccDef.Eng_Des);
                try
                {
                    if (State != FormState.Edit)
                    {
                        switchButton_Lock_ValueChanged(sender, e);
                    }
                }
                catch
                {
                }
                try
                {
                    GetGuestBalance(int.Parse(CmbGuestNo.SelectedValue.ToString()));
                }
                catch
                {
                }
            }
            catch
            {
            }
        }
        private void buttonItem_Print_Click(object sender, EventArgs e)
        {
            try
            {
                if (!(textBox_ID.Text != string.Empty) || State != 0)
                {
                    return;
                }
                if (_InvSetting.InvpRINTERInfo.nTyp.Substring(0, 1) == "1")
                {
                    RepShow _RepShow = new RepShow();
                    _RepShow.Tables = " T_Snd left JOIN T_per ON T_Snd.perno = T_per.perno left JOIN T_AccDef ON T_per.Cust_no = T_AccDef.AccDef_No left JOIN T_SYSSETTING ON T_AccDef.CompanyID = T_SYSSETTING.SYSSETTING_ID ";
                    string Fields = " T_Snd.SndName, T_Snd.fNo, T_Snd.gd_ID, T_Snd.romno, T_Snd.price, T_Snd.det, T_Snd.Usr, T_Snd.gdUser, T_Snd.gdUserNam, T_Snd.perno, T_Snd.curr, T_Snd.tm, \r\n                                             T_Snd.ch, T_Snd.curcost, T_Snd.sala, T_Snd.dt, T_Snd.typN, T_Snd.ShekNo, T_Snd.ShekDate, T_Snd.ShekBank, T_Snd.IfTrans, T_Snd.RStat, T_Snd.GadeId, \r\n                                             T_Snd.GadeNo,T_AccDef.Arb_Des as AccDefNm, T_AccDef.Eng_Des as AccDefNmE,T_SYSSETTING.LogImg";
                    VarGeneral.HeaderRep[0] = Text;
                    VarGeneral.HeaderRep[1] = string.Empty;
                    VarGeneral.HeaderRep[2] = string.Empty;
                    _RepShow.Rule = " where T_Snd.gd_ID = " + data_this.gd_ID;
                    _RepShow.Fields = Fields;
                    try
                    {
                        _RepShow = _RepShow.Save();
                        VarGeneral.RepData = _RepShow.RepData;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    if (VarGeneral.RepData.Tables[0].Rows.Count == 0)
                    {
                        return;
                    }
                    try
                    {
                        FrmReportsViewer frm = new FrmReportsViewer();
                        frm.Repvalue = "RepGaidCatchPer";
                        frm.Repvalue = "RepGaidSerfPer";

                        frm.Tag = LangArEn;
                        if (VarGeneral.SndTyp == 1)
                        {
                            frm.Repvalue = "RepGaidCatchPer";
                        }
                        else
                        {
                            frm.Repvalue = "RepGaidSerfPer";
                        }
                        VarGeneral.vTitle = Text;
                        frm.TopMost = true;
                        frm.ShowDialog();
                    }
                    catch (Exception error)
                    {
                        VarGeneral.DebLog.writeLog("button_ShowRep_Click:", error, enable: true);
                        MessageBox.Show(error.Message);
                    }
                    return;
                }
                PrintSet();
                prnt_doc.Print();
            }
            catch
            {
                MessageBox.Show((LangArEn == 0) ? "لا توجد حقول للطباعة تأكد من إعدادات الطباعة" : "No printing fields make sure the print settings", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
        private void PrintSet()
        {
            string _PrinterName = prnt_doc.PrinterSettings.PrinterName;
            prnt_doc.PrinterSettings.PrinterName = _InvSetting.defPrn;
            if (!prnt_doc.PrinterSettings.IsValid)
            {
                prnt_doc.PrinterSettings.PrinterName = _PrinterName;
            }
            if (_InvSetting.Orientation == 1)
            {
                prnt_doc.PrinterSettings.DefaultPageSettings.Landscape = false;
            }
            else
            {
                prnt_doc.PrinterSettings.DefaultPageSettings.Landscape = true;
            }
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
                if (frm.SerachNo != string.Empty)
                {
                    T_AccDef _AccDef = db.StockAccDefs(int.Parse(frm.Serach_No));
                    txtDebit1.Tag = _AccDef.AccDef_No;
                    if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
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
                    txtDebit1.Text = string.Empty;
                    txtDebit1.Tag = string.Empty;
                }
            }
            catch
            {
                txtDebit1.Text = string.Empty;
                txtDebit1.Tag = string.Empty;
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
                if (frm.SerachNo != string.Empty)
                {
                    T_AccDef _AccDef = db.StockAccDefs(int.Parse(frm.Serach_No));
                    txtCredit1.Tag = _AccDef.AccDef_No;
                    if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
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
                    txtCredit1.Text = string.Empty;
                    txtCredit1.Tag = string.Empty;
                }
            }
            catch
            {
                txtCredit1.Text = string.Empty;
                txtCredit1.Tag = string.Empty;
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
                    if (VarGeneral.SndTyp == 1)
                    {
                        try
                        {
                            if (!string.IsNullOrEmpty(VarGeneral.Settings_Sys.GuestBoxAcc))
                            {
                                txtDebit1.Tag = VarGeneral.Settings_Sys.GuestBoxAcc;
                                txtDebit1.Text = ((LangArEn == 0) ? db.StockAccDefWithOutBalance(VarGeneral.Settings_Sys.GuestBoxAcc).Arb_Des : db.StockAccDefWithOutBalance(VarGeneral.Settings_Sys.GuestBoxAcc).Eng_Des);
                            }
                            else
                            {
                                txtDebit1.Text = string.Empty;
                                txtDebit1.Tag = string.Empty;
                            }
                        }
                        catch
                        {
                            txtDebit1.Text = string.Empty;
                            txtDebit1.Tag = string.Empty;
                        }
                    }
                    else
                    {
                        try
                        {
                            T_per q = db.StockPer(int.Parse(CmbGuestNo.SelectedValue.ToString()));
                            txtDebit1.Tag = q.Cust_no;
                            txtDebit1.Text = ((LangArEn == 0) ? db.StockAccDefWithOutBalance(q.Cust_no).Arb_Des : db.StockAccDefWithOutBalance(q.Cust_no).Eng_Des);
                        }
                        catch
                        {
                            txtDebit1.Text = string.Empty;
                            txtDebit1.Tag = string.Empty;
                        }
                    }
                    if (VarGeneral.SndTyp == 1)
                    {
                        try
                        {
                            T_per q = db.StockPer(int.Parse(CmbGuestNo.SelectedValue.ToString()));
                            txtCredit1.Tag = q.Cust_no;
                            txtCredit1.Text = ((LangArEn == 0) ? db.StockAccDefWithOutBalance(q.Cust_no).Arb_Des : db.StockAccDefWithOutBalance(q.Cust_no).Eng_Des);
                        }
                        catch
                        {
                            txtCredit1.Text = string.Empty;
                            txtCredit1.Tag = string.Empty;
                        }
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
                            txtCredit1.Text = string.Empty;
                            txtCredit1.Tag = string.Empty;
                        }
                    }
                    catch
                    {
                        txtCredit1.Text = string.Empty;
                        txtCredit1.Tag = string.Empty;
                    }
                    return;
                }
                panel_Gaid.Enabled = false;
            }
            catch
            {
            }
        }
        private void switchButton_Lock_Click(object sender, EventArgs e)
        {
            Button_Edit_Click(sender, e);
        }
        private void prnt_doc_BeginPrint(object sender, PrintEventArgs e)
        {
            if (!(textBox_ID.Text != string.Empty))
            {
                return;
            }
            RepShow _RepShow = new RepShow();
            _RepShow.Tables = " T_Snd left JOIN T_per ON T_Snd.perno = T_per.perno left JOIN T_AccDef ON T_per.Cust_no = T_AccDef.AccDef_No left JOIN T_SYSSETTING ON T_AccDef.CompanyID = T_SYSSETTING.SYSSETTING_ID ";
            string Fields = " T_Snd.SndName, T_Snd.fNo, T_Snd.gd_ID, T_Snd.romno, T_Snd.price, T_Snd.det, T_Snd.Usr, T_Snd.gdUser, T_Snd.gdUserNam, T_Snd.perno, T_Snd.curr, T_Snd.tm, \r\n                                             T_Snd.ch, T_Snd.curcost, T_Snd.sala, T_Snd.dt, T_Snd.typN, T_Snd.ShekNo, T_Snd.ShekDate, T_Snd.ShekBank, T_Snd.IfTrans, T_Snd.RStat, T_Snd.GadeId, \r\n                                             T_Snd.GadeNo,T_AccDef.Arb_Des as AccDefNm, T_AccDef.Eng_Des as AccDefNmE,T_SYSSETTING.LogImg";
            VarGeneral.HeaderRep[0] = Text;
            VarGeneral.HeaderRep[1] = string.Empty;
            VarGeneral.HeaderRep[2] = string.Empty;
            _RepShow.Rule = " where T_Snd.gd_ID = " + data_this.gd_ID;
            _RepShow.Fields = Fields;
            if (!string.IsNullOrEmpty(Fields))
            {
                _RepShow.Fields = Fields;
                try
                {
                    _RepShow = _RepShow.Save();
                    VarGeneral.RepData = _RepShow.RepData;
                    iiRntP = 0;
                    _page = 1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void prnt_doc_PrintPage(object sender, PrintPageEventArgs e)
        {
            if (VarGeneral.RepData.Tables[0].Rows.Count == 0)
            {
                return;
            }
            List<T_mInvPrint> listmInvPrint = new List<T_mInvPrint>();
            T_mInvPrint _mInvPrint = new T_mInvPrint();
            listmInvPrint = (from item in db.T_mInvPrints
                             where item.repTyp == (int?)12
                             where item.repNum == (int?)2
                             where item.IsPrint == (int?)1
                             select item).ToList();
            if (listmInvPrint.Count == 0)
            {
                return;
            }
            e.PageSettings.Margins.Bottom = Convert.ToInt32(_InvSetting.InvpRINTERInfo.hAs);
            e.PageSettings.Margins.Top = Convert.ToInt32(_InvSetting.InvpRINTERInfo.hAl);
            e.PageSettings.Margins.Left = Convert.ToInt32(_InvSetting.InvpRINTERInfo.hYs);
            e.PageSettings.Margins.Right = Convert.ToInt32(_InvSetting.InvpRINTERInfo.hYm);
            e.PageSettings.PrinterSettings.Copies = short.Parse(_InvSetting.InvpRINTERInfo.DefLines.Value.ToString());
            double _isRows = 0.0;
            float _Row = 0f;
            double _PageLine = _InvSetting.InvpRINTERInfo.lnPg.Value;
            double _LineSp = _InvSetting.InvpRINTERInfo.lnSpc.Value;
            int _PageCount = Convert.ToInt32((double)VarGeneral.RepData.Tables[0].Rows.Count / _PageLine);
            double _VPage = (double)VarGeneral.RepData.Tables[0].Rows.Count / _PageLine;
            StringFormat strformat = new StringFormat((StringFormatFlags)0, 1);
            if (_VPage - (double)_PageCount != 0.0)
            {
                _PageCount++;
            }
            for (int iiRnt = iiRntP; iiRnt < VarGeneral.RepData.Tables[0].Rows.Count; iiRnt++)
            {
                for (int iiCnt = 0; iiCnt < listmInvPrint.Count; iiCnt++)
                {
                    _mInvPrint = listmInvPrint[iiCnt];
                    if (!(_mInvPrint.vFont != "0") || _mInvPrint.vSize.Value == 0)
                    {
                        continue;
                    }
                    strformat.FormatFlags = StringFormatFlags.DirectionRightToLeft;
                    if (_mInvPrint.vEt.Value == 0)
                    {
                        strformat.Alignment = StringAlignment.Near;
                    }
                    else if (_mInvPrint.vEt.Value == 1)
                    {
                        strformat.Alignment = StringAlignment.Far;
                    }
                    else if (_mInvPrint.vEt.Value == 2)
                    {
                        strformat.Alignment = StringAlignment.Center;
                    }
                    if (_mInvPrint.uChr == "mm")
                    {
                        e.Graphics.PageUnit = GraphicsUnit.Millimeter;
                    }
                    else if (_mInvPrint.uChr == "doc")
                    {
                        e.Graphics.PageUnit = GraphicsUnit.Document;
                    }
                    else if (_mInvPrint.uChr == "in")
                    {
                        e.Graphics.PageUnit = GraphicsUnit.Inch;
                    }
                    else if (_mInvPrint.uChr == "point")
                    {
                        e.Graphics.PageUnit = GraphicsUnit.Point;
                    }
                    else if (_mInvPrint.uChr == "pixel")
                    {
                        e.Graphics.PageUnit = GraphicsUnit.Pixel;
                    }
                    Font _font = new Font(_mInvPrint.vFont, _mInvPrint.vSize.Value, e.Graphics.PageUnit);
                    if (_mInvPrint.vBold.Value == 1)
                    {
                        _font = new Font(_mInvPrint.vFont, _mInvPrint.vSize.Value, FontStyle.Bold, e.Graphics.PageUnit);
                    }
                    _Row = ((_mInvPrint.IsPrntHd.Value != 1) ? ((float)_mInvPrint.vRow.Value) : ((float)_mInvPrint.vRow.Value + (float)_isRows));
                    string strfiled = string.Empty;
                    strfiled = ((!(_mInvPrint.pField == "PageNo")) ? VarGeneral.TString.TEmpty_Stock(string.Concat(VarGeneral.RepData.Tables[0].Rows[iiRnt][_mInvPrint.pField])) : (_page + " / " + _PageCount));
                    if (_mInvPrint.IsPrntHd == 1)
                    {
                        e.Graphics.DrawString(strfiled, _font, Brushes.Black, _mInvPrint.vCol.Value, _Row, strformat);
                        continue;
                    }
                    int? nTyp = _mInvPrint.nTyp;
                    if (nTyp.Value == 0 && nTyp.HasValue && _isRows == 0.0)
                    {
                        e.Graphics.DrawString(strfiled, _font, Brushes.Black, _mInvPrint.vCol.Value, _Row, strformat);
                    }
                    else if (_mInvPrint.nTyp == 1 && _page == 1)
                    {
                        e.Graphics.DrawString(strfiled, _font, Brushes.Black, _mInvPrint.vCol.Value, _Row, strformat);
                    }
                    else if (_mInvPrint.nTyp == 2 && _page == _PageCount)
                    {
                        e.Graphics.DrawString(strfiled, _font, Brushes.Black, _mInvPrint.vCol.Value, _Row, strformat);
                    }
                }
                _isRows += _InvSetting.InvpRINTERInfo.lnSpc.Value;
                if ((double)(iiRnt + 1) >= (double)_page * _PageLine)
                {
                    _page++;
                    _isRows = 0.0;
                    iiRntP = iiRnt + 1;
                    if (_page <= _PageCount)
                    {
                        e.HasMorePages = true;
                        return;
                    }
                }
            }
            e.HasMorePages = false;
        }
        private void button_SrchGuestNo_Click(object sender, EventArgs e)
        {
            if (!CmbGuestNo.Enabled)
            {
                return;
            }
            Button_Edit_Click(sender, e);
            if (State == FormState.Saved)
            {
                return;
            }
            columns_Names_visible2.Clear();
            columns_Names_visible2.Add("perno", new ColumnDictinary("رقم النزيل", "Ghoust No", ifDefault: true, string.Empty));
            columns_Names_visible2.Add("nmA", new ColumnDictinary("الإسم العربي", "Arabic Name", ifDefault: true, string.Empty));
            columns_Names_visible2.Add("nmE", new ColumnDictinary("الإسم الانجليزي", "English Name", ifDefault: true, string.Empty));
            columns_Names_visible2.Add("price", new ColumnDictinary("سعر الغرفة", "Price", ifDefault: true, string.Empty));
            columns_Names_visible2.Add("day", new ColumnDictinary("الأيام المطلوبة", "Days", ifDefault: true, string.Empty));
            columns_Names_visible2.Add("pasno", new ColumnDictinary("رقم الهوية", "ID No", ifDefault: true, string.Empty));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible2;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
            }
            if (State == FormState.New)
            {
                if (VarGeneral.SndTyp == 2)
                {
                    VarGeneral.SFrmTyp = "T_per";
                }
                else
                {
                    VarGeneral.SFrmTyp = "T_per3";
                }
            }
            else
            {
                VarGeneral.SFrmTyp = "T_per3";
            }
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != string.Empty)
            {
                CmbGuestNo.SelectedValue = frm.SerachNo;
            }
        }
        private void button_CustD1_Click(object sender, EventArgs e)
        {
            if (switchButton_Lock.Value)
            {
                try
                {
                    T_per q = db.StockPer(int.Parse(CmbGuestNo.SelectedValue.ToString()));
                    txtDebit1.Tag = q.Cust_no;
                    txtDebit1.Text = ((LangArEn == 0) ? db.StockAccDefWithOutBalance(q.Cust_no).Arb_Des : db.StockAccDefWithOutBalance(q.Cust_no).Eng_Des);
                }
                catch
                {
                    txtDebit1.Text = string.Empty;
                    txtDebit1.Tag = string.Empty;
                }
            }
        }
        private void button_CustC1_Click(object sender, EventArgs e)
        {
            if (switchButton_Lock.Value)
            {
                try
                {
                    T_per q = db.StockPer(int.Parse(CmbGuestNo.SelectedValue.ToString()));
                    txtCredit1.Tag = q.Cust_no;
                    txtCredit1.Text = ((LangArEn == 0) ? db.StockAccDefWithOutBalance(q.Cust_no).Arb_Des : db.StockAccDefWithOutBalance(q.Cust_no).Eng_Des);
                }
                catch
                {
                    txtCredit1.Text = string.Empty;
                    txtCredit1.Tag = string.Empty;
                }
            }
        }
    }
}
