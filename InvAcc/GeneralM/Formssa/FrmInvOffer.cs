using C1.Win.C1BarCode;
using C1.Win.C1FlexGrid;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.DotNetBar.SuperGrid;
using DevComponents.DotNetBar.SuperGrid.Style;
using DevComponents.Editors;
using Framework.Data;
using InvAcc.GeneralM;
using InvAcc.Stock_Data;
using Library.RepShow;
using SSSDateTime.Date;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;
using TFG;
namespace InvAcc.Forms
{
    public partial class FrmInvOffer : Form
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

        protected ToolStripMenuItem ToolStripMenuItem_Rep;
        private RibbonBar ribbonBar1;
        private ImageList imageList1;
        protected ContextMenuStrip contextMenuStrip1;
        protected ContextMenuStrip contextMenuStrip2;
        protected ToolStripMenuItem ToolStripMenuItem_Det;
        private SaveFileDialog saveFileDialog1;
        private PanelEx panelEx3;
        private PanelEx panelEx2;
        private ExpandableSplitter expandableSplitter1;
        private Panel panel1;
        private RibbonBar ribbonBar_Tasks;
        private SuperTabControl superTabControl_Main1;
        protected ButtonItem Button_Close;
        protected ButtonItem Button_Search;
        protected ButtonItem Button_Delete;
        protected ButtonItem Button_Save;
        protected ButtonItem Button_Add;
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
        protected LabelItem labelItem3;
        private ControlContainerItem controlContainerItem1;
        private LabelItem lable_Records;
        private C1BarCode c1BarCode1;
        internal Label labelPharmacy3;
        internal Label labelPharmacy2;
        internal Label labelPharmacy1;
        private SuperTabControlPanel superTabControlPanel10;
        internal Label label44;
        internal Label label45;
        internal Label label46;
        private TextBoxX txtCredit8;
        internal Label label47;
        private ExpandableSplitter expandableSplitter2;
        private PanelEx panelEx3x;
        private C1FlexGrid FlxInvDet;
        private PanelEx panelEx2x;
        private C1FlexGrid FlxInv;
        private Panel panel2;
        protected TextBox textBox_OfferName;
        internal Label label7;
        private TextBoxX txtRemark;
        internal Label label27;
        private TextBox textBox_Usr;
        internal Label label3;
        internal GroupBox groupBox5;
        private CheckBoxX checkBox_NetWork;
        private CheckBoxX checkBox_DisRate;
        private CheckBoxX checkBox_DisVal;
        private TextBoxX textBox_ID;
        private ButtonX button_SrchCustNo;
        private TextBox txtCustNo;
        internal TextBox txtCustName;
        internal Label label4;
        private ComboBoxEx CmbInvPrice;
        internal Label Label2;
        internal Label Label1;
        private MaskedTextBox txtStartDate;
        private MaskedTextBox txtEndDate;
        internal Label label5;
        private SwitchButton switchButton_OfferTyp;
        private C1FlexGrid FlxDat;
        private ScriptNumber ScriptNumber1 = new ScriptNumber();
        public Dictionary<string, string> columns_Nams_Sums = new Dictionary<string, string>();
        public Dictionary<string, ColumnDictinary> columns_Names_visible = new Dictionary<string, ColumnDictinary>();
        public Dictionary<string, ColumnDictinary> columns_Names_visible2 = new Dictionary<string, ColumnDictinary>();
        private HijriGreg.HijriGregDates n = new HijriGreg.HijriGregDates();
        private int RowSel = 0;
        private string oldUnit = "";
        private string oldUnitDet = "";
        private int DefPack = 0;
        private double Pack = 0.0;
        private double PackDet = 0.0;
        public static int LangArEn = 0;
        public string DocType = "";
        private T_SYSSETTING _SysSetting = new T_SYSSETTING();
        private List<T_SYSSETTING> listSysSetting = new List<T_SYSSETTING>();
        private T_INVSETTING _InvSetting = new T_INVSETTING();
        private List<T_INVSETTING> listInvSetting = new List<T_INVSETTING>();
        private T_Unit _Unit = new T_Unit();
        private List<T_Unit> listUnit = new List<T_Unit>();
        private T_Item _Items = new T_Item();
        private List<T_Item> listItems = new List<T_Item>();
        private T_OfferDet _InvDet = new T_OfferDet();
        private T_OfferQFree _InvDetQFree = new T_OfferQFree();
        private T_Offer data_this;
        private T_STKSQTY data_this_stkQ;
        private List<T_OfferDet> LData_This;
        private List<T_OfferQFree> LData_ThisQFree;
        public bool ifCheckData = false;
        public long TimeFinish = 0L;
        public long TimeStart = 0L;
        public TextBox textBox_Type = new TextBox();
        public List<string> pkeys = new List<string>();
        public bool canUpdate = true;
        protected bool CanInsert = true;
        public FormState statex;
        public ViewState ViewState = ViewState.Deiles;
        public string tableName = "";
        protected bool ifModify = true;
        public List<Control> controls;
        public Control codeControl = new Control();
        public bool CanEdit = true;
        protected bool ifOkDelete;
        private bool ifAutoOrderColumn = true;
        private Stock_DataDataContext dbInstance;
        private Rate_DataDataContext dbInstanceRate;
        private Stock_DataDataContext dbInstanceReturn;
        private T_User permission = new T_User();
        private List<string> _StorePr = new List<string>();
        private T_Store _Store = new T_Store();
        private List<T_Store> listStore = new List<T_Store>();
        private List<T_STKSQTY> listStkQty = new List<T_STKSQTY>();
        private List<T_QTYEXP> listQtyExp = new List<T_QTYEXP>();
        private T_QTYEXP _QtyExp = new T_QTYEXP();
        private T_STKSQTY _StksQty = new T_STKSQTY();
        public T_Offer DataThis
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
        public T_STKSQTY DataThis_stkQ
        {
            get
            {
                return data_this_stkQ;
            }
            set
            {
                data_this_stkQ = value;
            }
        }
        public List<T_OfferDet> LDataThis
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
        public List<T_OfferQFree> LDataThisQFree
        {
            get
            {
                return LData_ThisQFree;
            }
            set
            {
                LData_ThisQFree = value;
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
        public string TableName
        {
            get
            {
                return tableName;
            }
            set
            {
                tableName = value;
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
        public bool IfClose
        {
            set
            {
                Button_Close.Visible = value;
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
        private Stock_DataDataContext dbReturn
        {
            get
            {
                if (dbInstanceReturn == null)
                {
                    dbInstanceReturn = new Stock_DataDataContext(VarGeneral.BranchCS);
                }
                return dbInstanceReturn;
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
                    if (!VarGeneral.TString.ChkStatShow(value.InvStr, 53))
                    {
                        IfAdd = false;
                    }
                    else
                    {
                        IfAdd = true;
                    }
                    if (!VarGeneral.TString.ChkStatShow(value.InvStr, 54))
                    {
                        CanEdit = false;
                    }
                    else
                    {
                        CanEdit = true;
                    }
                    if (!VarGeneral.TString.ChkStatShow(value.InvStr, 55))
                    {
                        IfDelete = false;
                    }
                    else
                    {
                        IfDelete = true;
                    }
                    if (VarGeneral.vDemo && VarGeneral.UserID != 1)
                    {
                        IfDelete = false;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmInvOffer));
            DevComponents.DotNetBar.Rendering.SuperTabColorTable superTabColorTable1 = new DevComponents.DotNetBar.Rendering.SuperTabColorTable();
            DevComponents.DotNetBar.Rendering.SuperTabLinearGradientColorTable superTabLinearGradientColorTable1 = new DevComponents.DotNetBar.Rendering.SuperTabLinearGradientColorTable();
            DevComponents.DotNetBar.Rendering.SuperTabColorTable superTabColorTable2 = new DevComponents.DotNetBar.Rendering.SuperTabColorTable();
            DevComponents.DotNetBar.Rendering.SuperTabLinearGradientColorTable superTabLinearGradientColorTable2 = new DevComponents.DotNetBar.Rendering.SuperTabLinearGradientColorTable();
            DevComponents.DotNetBar.SuperGrid.Style.Background background1 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.Style.Background background2 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.Style.Background background3 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.Style.BorderColor borderColor1 = new DevComponents.DotNetBar.SuperGrid.Style.BorderColor();
            DevComponents.DotNetBar.SuperGrid.Style.BorderColor borderColor2 = new DevComponents.DotNetBar.SuperGrid.Style.BorderColor();
            DevComponents.DotNetBar.SuperGrid.Style.BaseTreeButtonVisualStyle baseTreeButtonVisualStyle1 = new DevComponents.DotNetBar.SuperGrid.Style.BaseTreeButtonVisualStyle();
            DevComponents.DotNetBar.SuperGrid.Style.BaseTreeButtonVisualStyle baseTreeButtonVisualStyle2 = new DevComponents.DotNetBar.SuperGrid.Style.BaseTreeButtonVisualStyle();
            DevComponents.DotNetBar.SuperGrid.Style.Background background4 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            this.PanelSpecialContainer = new System.Windows.Forms.Panel();
            this.ribbonBar1 = new DevComponents.DotNetBar.RibbonBar();
            this.panelEx2x = new DevComponents.DotNetBar.PanelEx();
            this.FlxInv = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.labelPharmacy3 = new System.Windows.Forms.Label();
            this.labelPharmacy2 = new System.Windows.Forms.Label();
            this.labelPharmacy1 = new System.Windows.Forms.Label();
            this.c1BarCode1 = new C1.Win.C1BarCode.C1BarCode();
            this.expandableSplitter2 = new DevComponents.DotNetBar.ExpandableSplitter();
            this.panelEx3x = new DevComponents.DotNetBar.PanelEx();
            this.FlxInvDet = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.panel2 = new System.Windows.Forms.Panel();
            this.switchButton_OfferTyp = new DevComponents.DotNetBar.Controls.SwitchButton();
            this.textBox_OfferName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtRemark = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label27 = new System.Windows.Forms.Label();
            this.textBox_Usr = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.checkBox_NetWork = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.checkBox_DisRate = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.checkBox_DisVal = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.textBox_ID = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.button_SrchCustNo = new DevComponents.DotNetBar.ButtonX();
            this.txtCustNo = new System.Windows.Forms.TextBox();
            this.txtCustName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.CmbInvPrice = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.txtStartDate = new System.Windows.Forms.MaskedTextBox();
            this.txtEndDate = new System.Windows.Forms.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ribbonBar_Tasks = new DevComponents.DotNetBar.RibbonBar();
            this.superTabControl_Main1 = new DevComponents.DotNetBar.SuperTabControl();
            this.Button_Close = new DevComponents.DotNetBar.ButtonItem();
            this.Button_Search = new DevComponents.DotNetBar.ButtonItem();
            this.Button_Delete = new DevComponents.DotNetBar.ButtonItem();
            this.Button_Save = new DevComponents.DotNetBar.ButtonItem();
            this.Button_Add = new DevComponents.DotNetBar.ButtonItem();
            this.superTabControl_Main2 = new DevComponents.DotNetBar.SuperTabControl();
            this.labelItem1 = new DevComponents.DotNetBar.LabelItem();
            this.Button_First = new DevComponents.DotNetBar.ButtonItem();
            this.Button_Prev = new DevComponents.DotNetBar.ButtonItem();
            this.TextBox_Index = new DevComponents.DotNetBar.TextBoxItem();
            this.Label_Count = new DevComponents.DotNetBar.LabelItem();
            this.lable_Records = new DevComponents.DotNetBar.LabelItem();
            this.Button_Next = new DevComponents.DotNetBar.ButtonItem();
            this.Button_Last = new DevComponents.DotNetBar.ButtonItem();
            this.ToolStripMenuItem_Rep = new System.Windows.Forms.ToolStripMenuItem();
            this.superTabControlPanel10 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.label44 = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.label46 = new System.Windows.Forms.Label();
            this.txtCredit8 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label47 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItem_Det = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.panelEx3 = new DevComponents.DotNetBar.PanelEx();
            this.DGV_Main = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            this.ribbonBar_DGV = new DevComponents.DotNetBar.RibbonBar();
            this.superTabControl_DGV = new DevComponents.DotNetBar.SuperTabControl();
            this.textBox_search = new DevComponents.DotNetBar.TextBoxItem();
            this.labelItem3 = new DevComponents.DotNetBar.LabelItem();
            this.panelEx2 = new DevComponents.DotNetBar.PanelEx();
            this.expandableSplitter1 = new DevComponents.DotNetBar.ExpandableSplitter();
            this.panel1 = new System.Windows.Forms.Panel();
            this.controlContainerItem1 = new DevComponents.DotNetBar.ControlContainerItem();
            this.FlxDat = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.netResize1 = new Softgroup.NetResize.NetResize(this.components);
            this.PanelSpecialContainer.SuspendLayout();
            this.ribbonBar1.SuspendLayout();
            this.panelEx2x.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FlxInv)).BeginInit();
            this.panelEx3x.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FlxInvDet)).BeginInit();
            this.panel2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.ribbonBar_Tasks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl_Main1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl_Main2)).BeginInit();
            this.superTabControlPanel10.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.panelEx3.SuspendLayout();
            this.ribbonBar_DGV.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl_DGV)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FlxDat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelSpecialContainer
            // 
            this.PanelSpecialContainer.Controls.Add(this.ribbonBar1);
            this.PanelSpecialContainer.Controls.Add(this.ribbonBar_Tasks);
            this.PanelSpecialContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelSpecialContainer.Location = new System.Drawing.Point(0, 0);
            this.PanelSpecialContainer.Name = "PanelSpecialContainer";
            this.PanelSpecialContainer.Size = new System.Drawing.Size(1278, 514);
            this.PanelSpecialContainer.TabIndex = 1220;
            // 
            // ribbonBar1
            // 
            this.ribbonBar1.AutoOverflowEnabled = true;
            this.ribbonBar1.BackColor = System.Drawing.Color.Gainsboro;
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
            this.ribbonBar1.Controls.Add(this.panelEx2x);
            this.ribbonBar1.Controls.Add(this.labelPharmacy3);
            this.ribbonBar1.Controls.Add(this.labelPharmacy2);
            this.ribbonBar1.Controls.Add(this.labelPharmacy1);
            this.ribbonBar1.Controls.Add(this.c1BarCode1);
            this.ribbonBar1.Controls.Add(this.expandableSplitter2);
            this.ribbonBar1.Controls.Add(this.panel2);
            this.ribbonBar1.Controls.Add(this.panelEx3x);
            this.ribbonBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonBar1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.ribbonBar1.Location = new System.Drawing.Point(0, 0);
            this.ribbonBar1.Name = "ribbonBar1";
            this.ribbonBar1.Size = new System.Drawing.Size(1278, 463);
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
            // panelEx2x
            // 
            this.panelEx2x.Controls.Add(this.FlxInv);
            this.panelEx2x.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx2x.Location = new System.Drawing.Point(0, 105);
            this.panelEx2x.Name = "panelEx2x";
            this.panelEx2x.Size = new System.Drawing.Size(1278, 330);
            this.panelEx2x.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx2x.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.panelEx2x.Style.BackColor2.Color = System.Drawing.SystemColors.GradientActiveCaption;
            this.panelEx2x.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx2x.Style.BorderColor.Color = System.Drawing.Color.White;
            this.panelEx2x.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx2x.Style.GradientAngle = 90;
            this.panelEx2x.TabIndex = 1227;
            // 
            // FlxInv
            // 
            this.FlxInv.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None;
            this.FlxInv.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
            this.FlxInv.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.FlxInv.ColumnInfo = resources.GetString("FlxInv.ColumnInfo");
            this.FlxInv.ExtendLastCol = true;
            this.FlxInv.Font = new System.Drawing.Font("Tahoma", 8F);
            this.FlxInv.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.FlxInv.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross;
            this.FlxInv.Location = new System.Drawing.Point(0, 0);
            this.FlxInv.Name = "FlxInv";
            this.FlxInv.Rows.Count = 13;
            this.FlxInv.Rows.DefaultSize = 19;
            this.FlxInv.ShowSortPosition = C1.Win.C1FlexGrid.ShowSortPositionEnum.None;
            this.FlxInv.Size = new System.Drawing.Size(1278, 328);
            this.FlxInv.StyleInfo = resources.GetString("FlxInv.StyleInfo");
            this.FlxInv.TabIndex = 1227;
            this.FlxInv.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.System;
            // 
            // labelPharmacy3
            // 
            this.labelPharmacy3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPharmacy3.AutoSize = true;
            this.labelPharmacy3.BackColor = System.Drawing.Color.Transparent;
            this.labelPharmacy3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelPharmacy3.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.labelPharmacy3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelPharmacy3.Location = new System.Drawing.Point(618, -104);
            this.labelPharmacy3.Name = "labelPharmacy3";
            this.labelPharmacy3.Size = new System.Drawing.Size(22, 13);
            this.labelPharmacy3.TabIndex = 1212;
            this.labelPharmacy3.Text = "يوم";
            // 
            // labelPharmacy2
            // 
            this.labelPharmacy2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPharmacy2.AutoSize = true;
            this.labelPharmacy2.BackColor = System.Drawing.Color.Transparent;
            this.labelPharmacy2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelPharmacy2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.labelPharmacy2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelPharmacy2.Location = new System.Drawing.Point(732, -88);
            this.labelPharmacy2.Name = "labelPharmacy2";
            this.labelPharmacy2.Size = new System.Drawing.Size(78, 13);
            this.labelPharmacy2.TabIndex = 1211;
            this.labelPharmacy2.Text = "يوم ,يصرف منها";
            // 
            // labelPharmacy1
            // 
            this.labelPharmacy1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPharmacy1.AutoSize = true;
            this.labelPharmacy1.BackColor = System.Drawing.Color.Transparent;
            this.labelPharmacy1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelPharmacy1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.labelPharmacy1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelPharmacy1.Location = new System.Drawing.Point(824, -104);
            this.labelPharmacy1.Name = "labelPharmacy1";
            this.labelPharmacy1.Size = new System.Drawing.Size(61, 13);
            this.labelPharmacy1.TabIndex = 1210;
            this.labelPharmacy1.Text = "مدة العلاج :";
            // 
            // c1BarCode1
            // 
            this.c1BarCode1.BarWide = 1;
            this.c1BarCode1.CodeType = C1.Win.C1BarCode.CodeTypeEnum.Code128;
            this.c1BarCode1.Font = new System.Drawing.Font("Tahoma", 8F);
            this.c1BarCode1.Location = new System.Drawing.Point(837, -52);
            this.c1BarCode1.Name = "c1BarCode1";
            this.c1BarCode1.ShowText = true;
            this.c1BarCode1.Size = new System.Drawing.Size(142, 40);
            this.c1BarCode1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.c1BarCode1.TabIndex = 1124;
            this.c1BarCode1.Text = "1225";
            // 
            // expandableSplitter2
            // 
            this.expandableSplitter2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.expandableSplitter2.BackColor2 = System.Drawing.Color.Empty;
            this.expandableSplitter2.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.None;
            this.expandableSplitter2.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.None;
            this.expandableSplitter2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.expandableSplitter2.Expandable = false;
            this.expandableSplitter2.ExpandableControl = this.panelEx3x;
            this.expandableSplitter2.ExpandActionDoubleClick = true;
            this.expandableSplitter2.Expanded = false;
            this.expandableSplitter2.ExpandFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(142)))), ((int)(((byte)(75)))));
            this.expandableSplitter2.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground;
            this.expandableSplitter2.ExpandLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.expandableSplitter2.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBorder;
            this.expandableSplitter2.GripDarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.expandableSplitter2.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBorder;
            this.expandableSplitter2.GripLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.expandableSplitter2.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.MenuBackground;
            this.expandableSplitter2.HotBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(213)))), ((int)(((byte)(140)))));
            this.expandableSplitter2.HotBackColor2 = System.Drawing.Color.Empty;
            this.expandableSplitter2.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.None;
            this.expandableSplitter2.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemCheckedBackground;
            this.expandableSplitter2.HotExpandFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(142)))), ((int)(((byte)(75)))));
            this.expandableSplitter2.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground;
            this.expandableSplitter2.HotExpandLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.expandableSplitter2.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBorder;
            this.expandableSplitter2.HotGripDarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.expandableSplitter2.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBorder;
            this.expandableSplitter2.HotGripLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.expandableSplitter2.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.MenuBackground;
            this.expandableSplitter2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.expandableSplitter2.Location = new System.Drawing.Point(0, 435);
            this.expandableSplitter2.Name = "expandableSplitter2";
            this.expandableSplitter2.Size = new System.Drawing.Size(1278, 11);
            this.expandableSplitter2.Style = DevComponents.DotNetBar.eSplitterStyle.Mozilla;
            this.expandableSplitter2.TabIndex = 1224;
            this.expandableSplitter2.TabStop = false;
            // 
            // panelEx3x
            // 
            this.panelEx3x.Controls.Add(this.FlxInvDet);
            this.panelEx3x.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelEx3x.Location = new System.Drawing.Point(0, 259);
            this.panelEx3x.Name = "panelEx3x";
            this.panelEx3x.Size = new System.Drawing.Size(824, 134);
            this.panelEx3x.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx3x.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.panelEx3x.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.panelEx3x.Style.BackgroundImagePosition = DevComponents.DotNetBar.eBackgroundImagePosition.Tile;
            this.panelEx3x.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.panelEx3x.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.panelEx3x.Style.GradientAngle = 90;
            this.panelEx3x.TabIndex = 1225;
            this.panelEx3x.Visible = false;
            // 
            // FlxInvDet
            // 
            this.FlxInvDet.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None;
            this.FlxInvDet.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
            this.FlxInvDet.ColumnInfo = resources.GetString("FlxInvDet.ColumnInfo");
            this.FlxInvDet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FlxInvDet.ExtendLastCol = true;
            this.FlxInvDet.Font = new System.Drawing.Font("Tahoma", 8F);
            this.FlxInvDet.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.FlxInvDet.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross;
            this.FlxInvDet.Location = new System.Drawing.Point(0, 0);
            this.FlxInvDet.Name = "FlxInvDet";
            this.FlxInvDet.Rows.Count = 13;
            this.FlxInvDet.Rows.DefaultSize = 19;
            this.FlxInvDet.ShowSortPosition = C1.Win.C1FlexGrid.ShowSortPositionEnum.None;
            this.FlxInvDet.Size = new System.Drawing.Size(824, 134);
            this.FlxInvDet.StyleInfo = resources.GetString("FlxInvDet.StyleInfo");
            this.FlxInvDet.TabIndex = 1224;
            this.FlxInvDet.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.System;
            this.FlxInvDet.RowColChange += new System.EventHandler(this.FlxInvDet_RowColChange);
            this.FlxInvDet.SelChange += new System.EventHandler(this.FlxInvDet_SelChange);
            this.FlxInvDet.BeforeEdit += new C1.Win.C1FlexGrid.RowColEventHandler(this.FlxInvDet_BeforeEdit);
            this.FlxInvDet.AfterEdit += new C1.Win.C1FlexGrid.RowColEventHandler(this.FlxInvDet_AfterEdit);
            this.FlxInvDet.Click += new System.EventHandler(this.FlxInv_Click);
            this.FlxInvDet.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FlxInvDet_KeyDown);
            this.FlxInvDet.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FlxInvDet_MouseDown);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.panel2.Controls.Add(this.switchButton_OfferTyp);
            this.panel2.Controls.Add(this.textBox_OfferName);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.txtRemark);
            this.panel2.Controls.Add(this.label27);
            this.panel2.Controls.Add(this.textBox_Usr);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.groupBox5);
            this.panel2.Controls.Add(this.textBox_ID);
            this.panel2.Controls.Add(this.button_SrchCustNo);
            this.panel2.Controls.Add(this.txtCustNo);
            this.panel2.Controls.Add(this.txtCustName);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.CmbInvPrice);
            this.panel2.Controls.Add(this.Label2);
            this.panel2.Controls.Add(this.Label1);
            this.panel2.Controls.Add(this.txtStartDate);
            this.panel2.Controls.Add(this.txtEndDate);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1278, 105);
            this.panel2.TabIndex = 1228;
            // 
            // switchButton_OfferTyp
            // 
            // 
            // 
            // 
            this.switchButton_OfferTyp.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.switchButton_OfferTyp.Font = new System.Drawing.Font("Tahoma", 9F);
            this.switchButton_OfferTyp.Location = new System.Drawing.Point(5, 42);
            this.switchButton_OfferTyp.Name = "switchButton_OfferTyp";
            this.switchButton_OfferTyp.OffBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.switchButton_OfferTyp.OffText = "تخفيض الأسعـــار";
            this.switchButton_OfferTyp.OffTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.switchButton_OfferTyp.OnBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.switchButton_OfferTyp.OnText = "كميــات مجــانيـة";
            this.switchButton_OfferTyp.OnTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.switchButton_OfferTyp.ReadOnlyMarkerColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.switchButton_OfferTyp.Size = new System.Drawing.Size(287, 33);
            this.switchButton_OfferTyp.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.switchButton_OfferTyp.TabIndex = 1243;
            this.switchButton_OfferTyp.ValueChanged += new System.EventHandler(this.switchButton_OfferTyp_ValueChanged);
            // 
            // textBox_OfferName
            // 
            this.textBox_OfferName.Font = new System.Drawing.Font("Tahoma", 8F);
            this.textBox_OfferName.ForeColor = System.Drawing.Color.Black;
            this.textBox_OfferName.Location = new System.Drawing.Point(298, 9);
            this.textBox_OfferName.MaxLength = 30;
            this.textBox_OfferName.Name = "textBox_OfferName";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_OfferName, false);
            this.textBox_OfferName.Size = new System.Drawing.Size(436, 20);
            this.textBox_OfferName.TabIndex = 1242;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label7.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(740, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 13);
            this.label7.TabIndex = 1241;
            this.label7.Text = "إســم العـــرض :";
            // 
            // txtRemark
            // 
            this.txtRemark.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtRemark.Border.Class = "TextBoxBorder";
            this.txtRemark.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtRemark.ButtonCustom.Text = "ملاحظة";
            this.txtRemark.ButtonCustom.Visible = true;
            this.txtRemark.ButtonCustom2.Image = ((System.Drawing.Image)(resources.GetObject("txtRemark.ButtonCustom2.Image")));
            this.txtRemark.ForeColor = System.Drawing.Color.Black;
            this.txtRemark.Location = new System.Drawing.Point(5, 79);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.netResize1.SetResizeTextBoxMultiline(this.txtRemark, false);
            this.txtRemark.Size = new System.Drawing.Size(819, 20);
            this.txtRemark.TabIndex = 1238;
            this.txtRemark.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.BackColor = System.Drawing.Color.Transparent;
            this.label27.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label27.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label27.Location = new System.Drawing.Point(1199, 82);
            this.label27.Name = "label27";
            this.label27.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label27.Size = new System.Drawing.Size(67, 14);
            this.label27.TabIndex = 1236;
            this.label27.Text = "المستخدم :";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox_Usr
            // 
            this.textBox_Usr.BackColor = System.Drawing.Color.SteelBlue;
            this.textBox_Usr.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.textBox_Usr.ForeColor = System.Drawing.Color.White;
            this.textBox_Usr.Location = new System.Drawing.Point(830, 79);
            this.textBox_Usr.MaxLength = 30;
            this.textBox_Usr.Name = "textBox_Usr";
            this.textBox_Usr.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_Usr, false);
            this.textBox_Usr.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox_Usr.Size = new System.Drawing.Size(363, 20);
            this.textBox_Usr.TabIndex = 1237;
            this.textBox_Usr.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(1199, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 1235;
            this.label3.Text = "تاريخ النهاية :";
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.Color.Transparent;
            this.groupBox5.Controls.Add(this.checkBox_NetWork);
            this.groupBox5.Controls.Add(this.checkBox_DisRate);
            this.groupBox5.Controls.Add(this.checkBox_DisVal);
            this.groupBox5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.groupBox5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupBox5.Location = new System.Drawing.Point(5, 3);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox5.Size = new System.Drawing.Size(287, 38);
            this.groupBox5.TabIndex = 1228;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "طريقة الخصم";
            // 
            // checkBox_NetWork
            // 
            this.checkBox_NetWork.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox_NetWork.AutoSize = true;
            this.checkBox_NetWork.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.checkBox_NetWork.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBox_NetWork.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.checkBox_NetWork.CheckSignSize = new System.Drawing.Size(14, 14);
            this.checkBox_NetWork.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.checkBox_NetWork.Location = new System.Drawing.Point(199, 54);
            this.checkBox_NetWork.Name = "checkBox_NetWork";
            this.checkBox_NetWork.Size = new System.Drawing.Size(63, 16);
            this.checkBox_NetWork.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBox_NetWork.TabIndex = 1022;
            this.checkBox_NetWork.Text = "شبكـــة";
            // 
            // checkBox_DisRate
            // 
            this.checkBox_DisRate.AutoSize = true;
            this.checkBox_DisRate.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.checkBox_DisRate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBox_DisRate.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.checkBox_DisRate.CheckSignSize = new System.Drawing.Size(14, 14);
            this.checkBox_DisRate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.checkBox_DisRate.Location = new System.Drawing.Point(35, 15);
            this.checkBox_DisRate.Name = "checkBox_DisRate";
            this.checkBox_DisRate.Size = new System.Drawing.Size(61, 16);
            this.checkBox_DisRate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBox_DisRate.TabIndex = 16;
            this.checkBox_DisRate.Text = "نسبـــة";
            this.checkBox_DisRate.CheckedChanged += new System.EventHandler(this.checkBox_Chash_CheckedChanged);
            // 
            // checkBox_DisVal
            // 
            this.checkBox_DisVal.AutoSize = true;
            this.checkBox_DisVal.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.checkBox_DisVal.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBox_DisVal.BackgroundStyle.TextShadowColor = System.Drawing.SystemColors.ControlLight;
            this.checkBox_DisVal.BackgroundStyle.TextShadowOffset = new System.Drawing.Point(3, 3);
            this.checkBox_DisVal.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.checkBox_DisVal.CheckSignSize = new System.Drawing.Size(14, 14);
            this.checkBox_DisVal.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.checkBox_DisVal.Location = new System.Drawing.Point(129, 15);
            this.checkBox_DisVal.Name = "checkBox_DisVal";
            this.checkBox_DisVal.Size = new System.Drawing.Size(58, 16);
            this.checkBox_DisVal.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBox_DisVal.TabIndex = 15;
            this.checkBox_DisVal.Text = "قيمـــة";
            this.checkBox_DisVal.CheckedChanged += new System.EventHandler(this.checkBox_Chash_CheckedChanged);
            // 
            // textBox_ID
            // 
            // 
            // 
            // 
            this.textBox_ID.Border.Class = "TextBoxBorder";
            this.textBox_ID.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBox_ID.Location = new System.Drawing.Point(830, 9);
            this.textBox_ID.Name = "textBox_ID";
            this.textBox_ID.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_ID, false);
            this.textBox_ID.Size = new System.Drawing.Size(363, 20);
            this.textBox_ID.TabIndex = 1234;
            // 
            // button_SrchCustNo
            // 
            this.button_SrchCustNo.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.button_SrchCustNo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchCustNo.Location = new System.Drawing.Point(527, 32);
            this.button_SrchCustNo.Name = "button_SrchCustNo";
            this.button_SrchCustNo.Size = new System.Drawing.Size(26, 20);
            this.button_SrchCustNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchCustNo.Symbol = "";
            this.button_SrchCustNo.SymbolSize = 12F;
            this.button_SrchCustNo.TabIndex = 1231;
            this.button_SrchCustNo.TextColor = System.Drawing.Color.SteelBlue;
            // 
            // txtCustNo
            // 
            this.txtCustNo.BackColor = System.Drawing.Color.White;
            this.txtCustNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtCustNo.Location = new System.Drawing.Point(559, 32);
            this.txtCustNo.MaxLength = 30;
            this.txtCustNo.Name = "txtCustNo";
            this.txtCustNo.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtCustNo, false);
            this.txtCustNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtCustNo.Size = new System.Drawing.Size(175, 20);
            this.txtCustNo.TabIndex = 1230;
            this.txtCustNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtCustName
            // 
            this.txtCustName.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.txtCustName.Location = new System.Drawing.Point(298, 32);
            this.txtCustName.Name = "txtCustName";
            this.netResize1.SetResizeTextBoxMultiline(this.txtCustName, false);
            this.txtCustName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtCustName.Size = new System.Drawing.Size(223, 21);
            this.txtCustName.TabIndex = 1232;
            this.txtCustName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(740, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 1233;
            this.label4.Text = "حساب العميــل :";
            // 
            // CmbInvPrice
            // 
            this.CmbInvPrice.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbInvPrice.DisplayMember = "Text";
            this.CmbInvPrice.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.CmbInvPrice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbInvPrice.FormattingEnabled = true;
            this.CmbInvPrice.ItemHeight = 14;
            this.CmbInvPrice.Location = new System.Drawing.Point(298, 55);
            this.CmbInvPrice.Name = "CmbInvPrice";
            this.CmbInvPrice.Size = new System.Drawing.Size(436, 20);
            this.CmbInvPrice.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.CmbInvPrice.TabIndex = 1225;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.BackColor = System.Drawing.Color.Transparent;
            this.Label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Label2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Label2.Location = new System.Drawing.Point(1199, 36);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(66, 13);
            this.Label2.TabIndex = 1227;
            this.Label2.Text = "تاريخ البداية :";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.BackColor = System.Drawing.Color.Transparent;
            this.Label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Label1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Label1.Location = new System.Drawing.Point(1199, 13);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(64, 13);
            this.Label1.TabIndex = 1226;
            this.Label1.Text = "رقم العرض :";
            // 
            // txtStartDate
            // 
            this.txtStartDate.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtStartDate.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.txtStartDate.Location = new System.Drawing.Point(830, 32);
            this.txtStartDate.Mask = "0000/00/00";
            this.txtStartDate.Name = "txtStartDate";
            this.txtStartDate.Size = new System.Drawing.Size(363, 21);
            this.txtStartDate.TabIndex = 1223;
            this.txtStartDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtEndDate
            // 
            this.txtEndDate.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtEndDate.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.txtEndDate.Location = new System.Drawing.Point(830, 55);
            this.txtEndDate.Mask = "0000/00/00";
            this.txtEndDate.Name = "txtEndDate";
            this.txtEndDate.Size = new System.Drawing.Size(363, 21);
            this.txtEndDate.TabIndex = 1224;
            this.txtEndDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(737, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 13);
            this.label5.TabIndex = 1229;
            this.label5.Text = "السعر المعتمــد :";
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
            this.ribbonBar_Tasks.Location = new System.Drawing.Point(0, 463);
            this.ribbonBar_Tasks.Name = "ribbonBar_Tasks";
            this.ribbonBar_Tasks.Size = new System.Drawing.Size(1278, 51);
            this.ribbonBar_Tasks.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonBar_Tasks.TabIndex = 871;
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
            this.superTabControl_Main1.ControlBox.Category = null;
            // 
            // 
            // 
            this.superTabControl_Main1.ControlBox.CloseBox.Category = null;
            this.superTabControl_Main1.ControlBox.CloseBox.Description = null;
            this.superTabControl_Main1.ControlBox.CloseBox.Name = "";
            this.superTabControl_Main1.ControlBox.CloseBox.Tag = null;
            this.superTabControl_Main1.ControlBox.Description = null;
            // 
            // 
            // 
            this.superTabControl_Main1.ControlBox.MenuBox.Category = null;
            this.superTabControl_Main1.ControlBox.MenuBox.Description = null;
            this.superTabControl_Main1.ControlBox.MenuBox.Name = "";
            this.superTabControl_Main1.ControlBox.MenuBox.Tag = null;
            this.superTabControl_Main1.ControlBox.Name = "";
            this.superTabControl_Main1.ControlBox.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.superTabControl_Main1.ControlBox.MenuBox,
            this.superTabControl_Main1.ControlBox.CloseBox});
            this.superTabControl_Main1.ControlBox.Tag = null;
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
            this.superTabControl_Main1.Size = new System.Drawing.Size(916, 51);
            this.superTabControl_Main1.TabFont = new System.Drawing.Font("Tahoma", 8F);
            this.superTabControl_Main1.TabIndex = 10;
            this.superTabControl_Main1.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.Button_Close,
            this.Button_Search,
            this.Button_Delete,
            this.Button_Save,
            this.Button_Add});
            superTabLinearGradientColorTable1.Colors = new System.Drawing.Color[] {
        System.Drawing.Color.Empty};
            superTabColorTable1.Background = superTabLinearGradientColorTable1;
            this.superTabControl_Main1.TabStripColor = superTabColorTable1;
            this.superTabControl_Main1.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.WinMediaPlayer12;
            this.superTabControl_Main1.Text = "superTabControl3";
            this.superTabControl_Main1.TextAlignment = DevComponents.DotNetBar.eItemAlignment.Center;
            this.superTabControl_Main1.RightToLeftChanged += new System.EventHandler(this.superTabControl_Main1_RightToLeftChanged);
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
            this.Button_Delete.Symbol = "";
            this.Button_Delete.SymbolSize = 15F;
            this.Button_Delete.Text = "حذف";
            this.Button_Delete.Tooltip = "حذف السجل الحالي";
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
            this.Button_Add.Symbol = "";
            this.Button_Add.SymbolSize = 15F;
            this.Button_Add.Text = "إضافة";
            this.Button_Add.Tooltip = "إضافة سجل جديد";
            // 
            // superTabControl_Main2
            // 
            this.superTabControl_Main2.BackColor = System.Drawing.Color.White;
            this.superTabControl_Main2.CausesValidation = false;
            // 
            // 
            // 
            this.superTabControl_Main2.ControlBox.Category = null;
            // 
            // 
            // 
            this.superTabControl_Main2.ControlBox.CloseBox.Category = null;
            this.superTabControl_Main2.ControlBox.CloseBox.Description = null;
            this.superTabControl_Main2.ControlBox.CloseBox.Name = "";
            this.superTabControl_Main2.ControlBox.CloseBox.Tag = null;
            this.superTabControl_Main2.ControlBox.Description = null;
            // 
            // 
            // 
            this.superTabControl_Main2.ControlBox.MenuBox.Category = null;
            this.superTabControl_Main2.ControlBox.MenuBox.Description = null;
            this.superTabControl_Main2.ControlBox.MenuBox.Name = "";
            this.superTabControl_Main2.ControlBox.MenuBox.Tag = null;
            this.superTabControl_Main2.ControlBox.Name = "";
            this.superTabControl_Main2.ControlBox.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.superTabControl_Main2.ControlBox.MenuBox,
            this.superTabControl_Main2.ControlBox.CloseBox});
            this.superTabControl_Main2.ControlBox.Tag = null;
            this.superTabControl_Main2.ControlBox.Visible = false;
            this.superTabControl_Main2.Dock = System.Windows.Forms.DockStyle.Right;
            this.superTabControl_Main2.ForeColor = System.Drawing.Color.Black;
            this.superTabControl_Main2.ItemPadding.Bottom = 4;
            this.superTabControl_Main2.ItemPadding.Left = 4;
            this.superTabControl_Main2.ItemPadding.Right = 4;
            this.superTabControl_Main2.ItemPadding.Top = 4;
            this.superTabControl_Main2.Location = new System.Drawing.Point(916, 0);
            this.superTabControl_Main2.Name = "superTabControl_Main2";
            this.superTabControl_Main2.ReorderTabsEnabled = true;
            this.superTabControl_Main2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.superTabControl_Main2.SelectedTabFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.superTabControl_Main2.SelectedTabIndex = -1;
            this.superTabControl_Main2.Size = new System.Drawing.Size(362, 51);
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
            superTabLinearGradientColorTable2.Colors = new System.Drawing.Color[] {
        System.Drawing.Color.Empty};
            superTabColorTable2.Background = superTabLinearGradientColorTable2;
            this.superTabControl_Main2.TabStripColor = superTabColorTable2;
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
            this.TextBox_Index.TextBoxWidth = 45;
            this.TextBox_Index.Visible = false;
            this.TextBox_Index.WatermarkColor = System.Drawing.SystemColors.GrayText;
            // 
            // Label_Count
            // 
            this.Label_Count.Name = "Label_Count";
            this.Label_Count.Visible = false;
            this.Label_Count.Width = 35;
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
            // ToolStripMenuItem_Rep
            // 
            this.ToolStripMenuItem_Rep.Checked = true;
            this.ToolStripMenuItem_Rep.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ToolStripMenuItem_Rep.Name = "ToolStripMenuItem_Rep";
            this.ToolStripMenuItem_Rep.Size = new System.Drawing.Size(148, 22);
            this.ToolStripMenuItem_Rep.Text = "إظهار التقرير";
            // 
            // superTabControlPanel10
            // 
            this.superTabControlPanel10.Controls.Add(this.label44);
            this.superTabControlPanel10.Controls.Add(this.label45);
            this.superTabControlPanel10.Controls.Add(this.label46);
            this.superTabControlPanel10.Controls.Add(this.txtCredit8);
            this.superTabControlPanel10.Controls.Add(this.label47);
            this.superTabControlPanel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel10.Location = new System.Drawing.Point(0, 0);
            this.superTabControlPanel10.Name = "superTabControlPanel10";
            this.superTabControlPanel10.Size = new System.Drawing.Size(542, 82);
            this.superTabControlPanel10.TabIndex = 3;
            // 
            // label44
            // 
            this.label44.BackColor = System.Drawing.Color.Transparent;
            this.label44.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label44.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label44.ForeColor = System.Drawing.Color.Navy;
            this.label44.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label44.Location = new System.Drawing.Point(437, 6);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(99, 21);
            this.label44.TabIndex = 1163;
            this.label44.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.BackColor = System.Drawing.Color.Transparent;
            this.label45.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label45.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label45.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label45.Location = new System.Drawing.Point(279, 33);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(0, 13);
            this.label45.TabIndex = 1162;
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.BackColor = System.Drawing.Color.Transparent;
            this.label46.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label46.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label46.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label46.Location = new System.Drawing.Point(279, 10);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(0, 13);
            this.label46.TabIndex = 1161;
            // 
            // txtCredit8
            // 
            this.txtCredit8.BackColor = System.Drawing.SystemColors.Control;
            // 
            // 
            // 
            this.txtCredit8.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtCredit8.ButtonCustom.Visible = true;
            this.txtCredit8.Enabled = false;
            this.txtCredit8.Font = new System.Drawing.Font("Tahoma", 8F);
            this.txtCredit8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtCredit8.Location = new System.Drawing.Point(116, 32);
            this.txtCredit8.Name = "txtCredit8";
            this.txtCredit8.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtCredit8, false);
            this.txtCredit8.Size = new System.Drawing.Size(163, 14);
            this.txtCredit8.TabIndex = 1159;
            this.txtCredit8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label47
            // 
            this.label47.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label47.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label47.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label47.ForeColor = System.Drawing.Color.White;
            this.label47.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label47.Location = new System.Drawing.Point(336, 6);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(99, 21);
            this.label47.TabIndex = 1155;
            this.label47.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
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
            // ToolStripMenuItem_Det
            // 
            this.ToolStripMenuItem_Det.Name = "ToolStripMenuItem_Det";
            this.ToolStripMenuItem_Det.Size = new System.Drawing.Size(148, 22);
            this.ToolStripMenuItem_Det.Text = "إظهار التفاصيل";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "*.rtf";
            this.saveFileDialog1.FileName = "doc1";
            this.saveFileDialog1.Filter = "Text Files (*.txt)|*.txt|RTF Files (*.rtf)|*.rtf|All Files(*.*)|*.*";
            this.saveFileDialog1.FilterIndex = 2;
            this.saveFileDialog1.Title = "Save File";
            // 
            // panelEx3
            // 
            this.panelEx3.Controls.Add(this.DGV_Main);
            this.panelEx3.Controls.Add(this.ribbonBar_DGV);
            this.panelEx3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx3.Location = new System.Drawing.Point(0, 0);
            this.panelEx3.Name = "panelEx3";
            this.panelEx3.Size = new System.Drawing.Size(1278, 0);
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
            this.DGV_Main.PrimaryGrid.GroupByRow.Text = "جميــع السجــــلات";
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
            this.DGV_Main.Size = new System.Drawing.Size(1278, 0);
            this.DGV_Main.TabIndex = 874;
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
            this.ribbonBar_DGV.Size = new System.Drawing.Size(1278, 51);
            this.ribbonBar_DGV.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonBar_DGV.TabIndex = 875;
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
            this.superTabControl_DGV.ControlBox.Category = null;
            // 
            // 
            // 
            this.superTabControl_DGV.ControlBox.CloseBox.Category = null;
            this.superTabControl_DGV.ControlBox.CloseBox.Description = null;
            this.superTabControl_DGV.ControlBox.CloseBox.Name = "";
            this.superTabControl_DGV.ControlBox.CloseBox.Tag = null;
            this.superTabControl_DGV.ControlBox.Description = null;
            // 
            // 
            // 
            this.superTabControl_DGV.ControlBox.MenuBox.Category = null;
            this.superTabControl_DGV.ControlBox.MenuBox.Description = null;
            this.superTabControl_DGV.ControlBox.MenuBox.Name = "";
            this.superTabControl_DGV.ControlBox.MenuBox.Tag = null;
            this.superTabControl_DGV.ControlBox.Name = "";
            this.superTabControl_DGV.ControlBox.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.superTabControl_DGV.ControlBox.MenuBox,
            this.superTabControl_DGV.ControlBox.CloseBox});
            this.superTabControl_DGV.ControlBox.Tag = null;
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
            this.superTabControl_DGV.Size = new System.Drawing.Size(1278, 51);
            this.superTabControl_DGV.TabFont = new System.Drawing.Font("Tahoma", 8F);
            this.superTabControl_DGV.TabIndex = 12;
            this.superTabControl_DGV.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.textBox_search,
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
            // labelItem3
            // 
            this.labelItem3.Name = "labelItem3";
            this.labelItem3.Width = 40;
            // 
            // panelEx2
            // 
            this.panelEx2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelEx2.Location = new System.Drawing.Point(0, 0);
            this.panelEx2.MinimumSize = new System.Drawing.Size(824, 461);
            this.panelEx2.Name = "panelEx2";
            this.panelEx2.Size = new System.Drawing.Size(1278, 514);
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
            // expandableSplitter1
            // 
            this.expandableSplitter1.BackColor = System.Drawing.Color.Black;
            this.expandableSplitter1.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.expandableSplitter1.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.None;
            this.expandableSplitter1.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.None;
            this.expandableSplitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.expandableSplitter1.Enabled = false;
            this.expandableSplitter1.Expandable = false;
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
            this.expandableSplitter1.Location = new System.Drawing.Point(0, -14);
            this.expandableSplitter1.Name = "expandableSplitter1";
            this.expandableSplitter1.Size = new System.Drawing.Size(1278, 14);
            this.expandableSplitter1.TabIndex = 1;
            this.expandableSplitter1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panelEx3);
            this.panel1.Controls.Add(this.expandableSplitter1);
            this.panel1.Controls.Add(this.panelEx2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1278, 514);
            this.panel1.TabIndex = 877;
            // 
            // controlContainerItem1
            // 
            this.controlContainerItem1.AllowItemResize = true;
            this.controlContainerItem1.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways;
            this.controlContainerItem1.Name = "controlContainerItem1";
            // 
            // FlxDat
            // 
            this.FlxDat.AllowEditing = false;
            this.FlxDat.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.None;
            this.FlxDat.ColumnInfo = resources.GetString("FlxDat.ColumnInfo");
            this.FlxDat.Font = new System.Drawing.Font("Tahoma", 8F);
            this.FlxDat.Location = new System.Drawing.Point(341, 310);
            this.FlxDat.Name = "FlxDat";
            this.FlxDat.Rows.DefaultSize = 19;
            this.FlxDat.Size = new System.Drawing.Size(229, 77);
            this.FlxDat.StyleInfo = resources.GetString("FlxDat.StyleInfo");
            this.FlxDat.TabIndex = 1245;
            this.FlxDat.Visible = false;
            this.FlxDat.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2007Black;
            // 
            // netResize1
            // 
            this.netResize1.AutoSaveLayout = true;
            this.netResize1.ParentControl = this;
            this.netResize1.AfterControlResize += new Softgroup.NetResize.NetResize.AfterControlResizeEventHandler(this.netResize1_AfterControlResize);
            // 
            // FrmInvOffer
            // 
            this.ClientSize = new System.Drawing.Size(1278, 514);
            this.Controls.Add(this.PanelSpecialContainer);
            this.Controls.Add(this.FlxDat);
            this.Controls.Add(this.panel1);
            this.Icon = global::InvAcc.Properties.Resources.favicon;
            this.KeyPreview = true;
            this.Name = "FrmInvOffer";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "العـــروض الخـــاصة";
            this.Load += new System.EventHandler(this.FrmInvOffer_Load);
            this.Shown += new System.EventHandler(this.FrmInvSale_Shown);
            this.SizeChanged += new System.EventHandler(this.FrmInvSale_SizeChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Frm_KeyPress);
            this.PanelSpecialContainer.ResumeLayout(false);
            this.ribbonBar1.ResumeLayout(false);
            this.ribbonBar1.PerformLayout();
            this.panelEx2x.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FlxInv)).EndInit();
            this.panelEx3x.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FlxInvDet)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ribbonBar_Tasks.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl_Main1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl_Main2)).EndInit();
            this.superTabControlPanel10.ResumeLayout(false);
            this.superTabControlPanel10.PerformLayout();
            this.contextMenuStrip2.ResumeLayout(false);
            this.panelEx3.ResumeLayout(false);
            this.ribbonBar_DGV.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl_DGV)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FlxDat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).EndInit();
            this.ResumeLayout(false);

        }
        protected bool Check()
        {
            if (!ifCheckData)
            {
                return true;
            }
            return true;
        }
        public void FillHDGV(IEnumerable<T_Offer> new_data_enum)
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
                    DGV_Main.PrimaryGrid.Columns[i].MinimumWidth = 90;
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
            DGV_Main.PrimaryGrid.DataMember = "T_Offer";
        }
        public void FillHDGVQ(IQueryable new_data_enum)
        {
            SetReadOnly = true;
            DGV_Main.PrimaryGrid.DataSource = new_data_enum;
            DGV_Main.PrimaryGrid.DataMember = "T_Offer";
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
                DGV_Main.PrimaryGrid.Columns[name].MinimumWidth = 100;
                DGV_Main.PrimaryGrid.Columns[name].HeaderText = ((LangArEn == 0) ? columns_Names_visible[name].AText : columns_Names_visible[name].EText);
            }
            DGV_Main.PrimaryGrid.Columns[name].Visible = (sender as ToolStripMenuItem).Checked;
            for (int i = 0; i < DGV_Main.PrimaryGrid.Rows.Count; i++)
            {
                DGV_Main.PrimaryGrid.Rows[i].GridPanel.CheckBoxes = true;
            }
            try
            {
                DGV_Main.PrimaryGrid.SetSelectedCells(1, 0, 1, 1, selected: true);
            }
            catch
            {
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
        public void Button_First_Click(object sender, EventArgs e)
        {
            if (ContinueIfEditOrNew())
            {
                TextBox_Index.TextBox.Text = string.Concat(1);
                UpdateVcr();
            }
        }
        public void Button_Prevouse_Click(object sender, EventArgs e)
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
        public bool CheckNotificationMassage()
        {
            return false;
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
        public void expandableSplitter1_Click(object sender, EventArgs e)
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
        private void Button_Edit_Click(object sender, EventArgs e)
        {
            if (CanEdit && State != FormState.Edit && State != FormState.New && !string.IsNullOrEmpty(textBox_ID.Text))
            {
                if (State != FormState.New)
                {
                    State = FormState.Edit;
                }
                FlxInv.Rows.Count = FlxInv.Rows.Count + VarGeneral.Settings_Sys.LineOfInvoices.Value;
                FlxInvDet.Rows.Count = FlxInvDet.Rows.Count + VarGeneral.Settings_Sys.LineOfInvoices.Value;
                SetReadOnly = false;
            }
        }
        private void Button_Close_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void textBox_ID_Click(object sender, EventArgs e)
        {
            textBox_ID.SelectAll();
        }
        private void textBox_ID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (e.KeyChar != '\b'))
            {
                e.Handled = true;
            }
        }
        private void FrmInvices_CheckFouce(object sender, EventArgs e)
        {
            if (switchButton_OfferTyp.Value)
            {
                VarGeneral.InvTyp = 1;
            }
            else
            {
                VarGeneral.InvTyp = 0;
            }
        }
        public FrmInvOffer()
        {
            InitializeComponent();
            base.Activated += FrmInvices_CheckFouce;
            textBox_ID.KeyPress += textBox_ID_KeyPress;
            textBox_OfferName.Click += Button_Edit_Click;
            textBox_Type.Click += Button_Edit_Click;
            txtCustName.Click += Button_Edit_Click;
            txtCustNo.Click += Button_Edit_Click;
            txtStartDate.Click += Button_Edit_Click;
            txtEndDate.Click += Button_Edit_Click;
            txtRemark.Click += Button_Edit_Click;
            checkBox_DisVal.Click += Button_Edit_Click;
            checkBox_DisRate.Click += Button_Edit_Click;
            CmbInvPrice.Click += Button_Edit_Click;
            switchButton_OfferTyp.Click += Button_Edit_Click;
            expandableSplitter1.Click += expandableSplitter1_Click;
            ToolStripMenuItem_Det.Click += ToolStripMenuItem_Det_Click;
            textBox_search.InputTextChanged += TextBox_Search_InputTextChanged;
            textBox_search.ButtonCustomClick += TextBox_Search_ButtonCustomClick;
            TextBox_Index.InputTextChanged += TextBox_Index_InputTextChanged;
            Button_Close.Click += Button_Close_Click;
            Button_First.Click += Button_First_Click;
            Button_Prev.Click += Button_Prevouse_Click;
            Button_Next.Click += Button_Next_Click;
            Button_Last.Click += Button_Last_Click;
            Button_Add.Click += Button_Add_Click;
            Button_Search.Click += Button_Search_Click;
            Button_Delete.Click += Button_Delete_Click;
            Button_Save.Click += Button_Save_Click;
            FlxDat.DoubleClick += FlxDat_DoubleClick;
            FlxDat.KeyDown += FlxDat_KeyDown;
            FlxDat.Leave += FlxDat_Leave;
            TextBox_Index.InputTextChanged += TextBox_Index_InputTextChanged;
            expandableSplitter1.Click += expandableSplitter1_Click;
            DGV_Main.PrimaryGrid.CheckBoxes = true;
            DGV_Main.PrimaryGrid.ShowCheckBox = true;
            DGV_Main.PrimaryGrid.ShowTreeButton = true;
            DGV_Main.PrimaryGrid.ShowTreeButtons = true;
            DGV_Main.PrimaryGrid.ShowTreeLines = true;
            DGV_Main.PrimaryGrid.ShowRowGridIndex = true;
            DGV_Main.PrimaryGrid.RowHeaderWidth = 25;
            DGV_Main.DataBindingComplete += DGV_Main_DataBindingComplete;
            DGV_Main.CellClick += DGV_Main_CellClick;
            DGV_Main.CellDoubleClick += DGV_Main_CellDoubleClick;
            DGV_Main.GetCellStyle += DGV_MainGetCellStyle;
            DGV_Main.MouseDown += DGV_Main_MouseDown;
            DGV_Main.AfterCheck += DGV_Main_AfterCheck;
            textBox_ID.TextChanged += textBox_ID_TextChanged;
            textBox_ID.Click += textBox_ID_Click;
            txtEndDate.Click += txtHDate_Click;
            txtEndDate.Leave += txtHDate_Leave;
            txtStartDate.Click += txtGDate_Click;
            txtStartDate.Leave += txtGDate_Leave;
            button_SrchCustNo.Click += button_SrchCustNo_Click;
            FlxInv.Click += FlxInv_Click;
            FlxInv.AfterEdit += FlxInv_AfterEdit;
            FlxInv.BeforeEdit += FlxInv_BeforeEdit;
            FlxInv.KeyDown += FlxInv_KeyDown;
            FlxInv.RowColChange += FlxInv_RowColChange;
            FlxInv.SelChange += FlxInv_SelChange;
            FlxInv.MouseDown += FlxInv_MouseDown;
            if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49))
            {
                FlxInv.Cols[6].Format = VarGeneral.DicimalNN;
                FlxInv.Cols[7].Format = VarGeneral.DicimalNN;
                FlxInv.Cols[8].Format = VarGeneral.DicimalNN;
                FlxInv.Cols[9].Format = VarGeneral.DicimalNN;
                FlxInv.Cols[10].Format = VarGeneral.DicimalNN;
                FlxInvDet.Cols[7].Format = VarGeneral.DicimalNN;
                FlxInvDet.Cols[8].Format = VarGeneral.DicimalNN;
                FlxInvDet.Cols[9].Format = VarGeneral.DicimalNN;
                FlxInvDet.Cols[10].Format = VarGeneral.DicimalNN;
                FlxInvDet.Cols[11].Format = VarGeneral.DicimalNN;
            }
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
            VarGeneral.SFrmTyp = "T_Offer";
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != "")
            {
                textBox_ID.Text = frm.SerachNo.ToString();
            }
        }
        public void ReorderColumns()
        {
            if (!ifAutoOrderColumn)
            {
                return;
            }
            int i = 0;
            foreach (string item in columns_Names_visible.Keys)
            {
                try
                {
                    DGV_Main.PrimaryGrid.Columns[item].DisplayIndex = i;
                }
                catch
                {
                }
                i++;
            }
        }
        public void DGV_Main_ColumnResized(object sender, GridColumnEventArgs e)
        {
            if (ViewState == ViewState.Deiles)
            {
                return;
            }
            foreach (KeyValuePair<string, string> item in columns_Nams_Sums)
            {
                TextBox textBox = new TextBox();
                textBox.Visible = DGV_Main.PrimaryGrid.Columns[item.Key].IsOnScreen;
                textBox.Text = item.Value;
                textBox.Location = new Point(DGV_Main.PrimaryGrid.Columns[item.Key].Bounds.X, 3);
                textBox.Size = new Size(DGV_Main.PrimaryGrid.Columns[item.Key].Width, 20);
            }
        }
        private void DGV_Main_DataBindingComplete(object sender, GridDataBindingCompleteEventArgs e)
        {
            ReorderColumns();
            DGV_Main_ColumnResized(new object(), new GridColumnEventArgs(new GridPanel(), new GridColumn()));
            GridPanel panel = e.GridPanel;
            switch (panel.DataMember)
            {
                case "T_Offer":
                    PropHIOfferPanel(panel);
                    break;
                case "Line":
                    PropLOfferPanel(panel);
                    break;
            }
        }
        public void Clear()
        {
            if (State == FormState.New)
            {
                return;
            }
            State = FormState.New;
            data_this = new T_Offer();
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
                    else if (controls[i].GetType() == typeof(ComboBox))
                    {
                        (controls[i] as ComboBox).SelectedIndex = 0;
                    }
                    else
                    {
                        if (controls[i].GetType() != typeof(ComboBoxEx))
                        {
                            continue;
                        }
                        try
                        {
                            if (controls[i].Name != "CmbInvPrice")
                            {
                                (controls[i] as ComboBoxEx).SelectedIndex = 0;
                            }
                        }
                        catch
                        {
                        }
                    }
                }
            }
            if (FlxInv.Rows.Count <= 1)
            {
                FlxInv.Rows.Count = VarGeneral.Settings_Sys.LineOfInvoices.Value;
            }
            else
            {
                FlxInv.Clear(ClearFlags.Content, 1, 1, FlxInv.Rows.Count - 1, 10);
            }
            if (FlxInvDet.Rows.Count <= 1)
            {
                FlxInvDet.Rows.Count = VarGeneral.Settings_Sys.LineOfInvoices.Value;
            }
            else
            {
                FlxInvDet.Clear(ClearFlags.Content, 1, 1, FlxInvDet.Rows.Count - 1, 16);
            }
            checkBox_DisVal.Checked = true;
            checkBox_DisRate.Checked = false;
            textBox_Usr.Text = ((LangArEn == 0) ? VarGeneral.UserNameA : VarGeneral.UserNameE);
            FillLines();
            SetReadOnly = false;
        }
        private void button_SrchCustNo_Click(object sender, EventArgs e)
        {
            Button_Edit_Click(sender, e);
            if (State == FormState.Saved)
            {
                return;
            }
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
            VarGeneral.SFrmTyp = "T_AccDef";
            VarGeneral.AccTyp = 4;
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != "")
            {
                txtCustNo.Text = db.StockAccDefs(int.Parse(frm.Serach_No)).AccDef_No;
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                {
                    txtCustName.Text = db.StockAccDefs(int.Parse(frm.Serach_No)).Arb_Des;
                }
                else
                {
                    txtCustName.Text = db.StockAccDefs(int.Parse(frm.Serach_No)).Eng_Des;
                }
            }
            else
            {
                txtCustNo.Text = "";
                txtCustName.Text = "";
            }
        }
        private void ArbEng()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                LangArEn = 0;
                FlxInv.Cols[1].Caption = "رمز الصنف";
                FlxInv.Cols[2].Visible = true;
                FlxInv.Cols[3].Visible = true;
                FlxInv.Cols[4].Visible = false;
                FlxInv.Cols[5].Visible = false;
                FlxInv.Cols[6].Caption = "السعر";
                FlxInv.Cols[7].Caption = "قيمة الخصم";
                FlxInv.Cols[8].Caption = "السعر الجديد";
                FlxInv.Cols[9].Caption = "من الكمية";
                FlxInv.Cols[10].Caption = "إلى الكمية";
                FlxInvDet.Cols[1].Caption = "رمز الصنف";
                FlxInvDet.Cols[2].Visible = true;
                FlxInvDet.Cols[3].Visible = true;
                FlxInvDet.Cols[4].Visible = false;
                FlxInvDet.Cols[5].Visible = false;
                FlxInvDet.Cols[6].Caption = "مستودع";
                FlxInvDet.Cols[7].Caption = "السعر";
                FlxInvDet.Cols[8].Caption = "قيمة الخصم";
                FlxInvDet.Cols[9].Caption = "السعر الجديد";
                FlxInvDet.Cols[10].Caption = "الكميــة";
                FlxInvDet.Cols[16].Caption = "س.الرئيسي";
                FlxInvDet.Cols[11].Caption = "ضريبة %";
                FlxInvDet.Cols[14].Caption = "تاريخ صلاحية";
                FlxInvDet.Cols[15].Caption = "رقم تصنيع";
                FlxDat.Cols[0].Caption = "تاريخ الصلاحية";
                FlxDat.Cols[1].Caption = "الكمية";
                FlxDat.Cols[2].Caption = "رقم التصنيع";
            }
            else
            {
                LangArEn = 1;
                FlxInv.Cols[1].Caption = "Item Code";
                FlxInv.Cols[2].Visible = false;
                FlxInv.Cols[3].Visible = false;
                FlxInv.Cols[4].Visible = true;
                FlxInv.Cols[5].Visible = true;
                FlxInv.Cols[6].Caption = "Price";
                FlxInv.Cols[7].Caption = "Dis Val";
                FlxInv.Cols[8].Caption = "New Price";
                FlxInv.Cols[9].Caption = "From Quantity";
                FlxInv.Cols[10].Caption = "To Quantity";
                FlxInvDet.Cols[1].Caption = "Item Code";
                FlxInvDet.Cols[2].Visible = false;
                FlxInvDet.Cols[3].Visible = false;
                FlxInvDet.Cols[4].Visible = true;
                FlxInvDet.Cols[5].Visible = true;
                FlxInvDet.Cols[6].Caption = "Store";
                FlxInvDet.Cols[7].Caption = "Price";
                FlxInvDet.Cols[8].Caption = "Dis Val";
                FlxInvDet.Cols[9].Caption = "New Price";
                FlxInvDet.Cols[10].Caption = "Quantity";
                FlxInvDet.Cols[16].Caption = "Main Line";
                FlxInvDet.Cols[11].Caption = "Tax %";
                FlxInvDet.Cols[14].Caption = "Expir Date";
                FlxInvDet.Cols[15].Caption = "Make No";
                FlxDat.Cols[0].Caption = "Expir Date";
                FlxDat.Cols[1].Caption = "Quantity";
                FlxDat.Cols[2].Caption = "Make No";
            }
            if (!switchButton_OfferTyp.Value)
            {
                FlxInv.Cols[6].Visible = true;
                FlxInv.Cols[7].Visible = true;
                FlxInv.Cols[8].Visible = true;
            }
            RibunButtons();
        }
        private void DGV_MainGetCellStyle(object sender, GridGetCellStyleEventArgs e)
        {
            GridPanel panel = e.GridPanel;
            if (panel.DataMember.Equals("HISale") && e.GridCell.GridColumn.Name.Equals("Date"))
            {
                DateTime dt = default(DateTime);
                dt = Convert.ToDateTime(e.GridCell.Value);
            }
        }
        private void ADD_Controls()
        {
            try
            {
                controls = new List<Control>();
                controls.Add(textBox_ID);
                codeControl = textBox_ID;
                controls.Add(textBox_Type);
                controls.Add(txtCustName);
                controls.Add(txtCustNo);
                controls.Add(txtStartDate);
                controls.Add(txtEndDate);
                controls.Add(txtRemark);
                controls.Add(checkBox_DisVal);
                controls.Add(checkBox_DisRate);
                controls.Add(textBox_OfferName);
                controls.Add(CmbInvPrice);
                controls.Add(switchButton_OfferTyp);
                controls.Add(textBox_Usr);
            }
            catch (SqlException)
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
            if (MessageBox.Show("هل أنت متاكد من حذف السجل [" + Code + "]؟ \n Are you sure that you want to delete the record [" + Code + "]?", VarGeneral.ProdectNam, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ifOkDelete = true;
            }
            else
            {
                ifOkDelete = false;
            }
            if (data_this != null && !(data_this.OfferHeadNo == 0.ToString()) && ifOkDelete)
            {
                data_this = db.StockOffer(VarGeneral.InvTyp, DataThis.OfferHeadNo);
                try
                {
                    db.ExecuteCommand("DELETE FROM [dbo].[T_OfferQFree] WHERE OfferIDQ =" + DataThis.OfferHeadID);
                    db.ExecuteCommand("DELETE FROM [dbo].[T_OfferDet] WHERE OfferID =" + DataThis.OfferHeadID);
                    db.T_Offers.DeleteOnSubmit(DataThis);
                    db.SubmitChanges();
                }
                catch (SqlException)
                {
                    data_this = db.StockOffer(VarGeneral.InvTyp, DataThis.OfferHeadNo);
                    return;
                }
                catch (Exception)
                {
                    data_this = db.StockOffer(VarGeneral.InvTyp, DataThis.OfferHeadNo);
                    return;
                }
                Clear();
                RefreshPKeys();
                textBox_ID.Text = PKeys.LastOrDefault();
            }
        }
        private void Button_Add_Click(object sender, EventArgs e)
        {
            if (!Button_Add.Visible || !Button_Add.Enabled)
            {
                MessageBox.Show((LangArEn == 0) ? "لا يمكن اتمام هذه العملية .. الرجاء مراجعة صلاحيات المستخدمين !" : "Can not complete this process .. please see the powers of the users!", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else if (State != FormState.Edit || MessageBox.Show((LangArEn == 0) ? "تم تعديل السجل الحالي دون حفظ التغييرات .. هل تريد المتابعة؟" : "Not saved the changes, do you really want to continue?", VarGeneral.ProdectNam, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                Clear();
                MaskedTextBox maskedTextBox = txtStartDate;
                int? calendr = VarGeneral.Settings_Sys.Calendr;
                maskedTextBox.Text = ((calendr.Value == 0 && calendr.HasValue) ? n.FormatGreg(VarGeneral.Gdate, "yyyy/MM/dd") : n.FormatHijri(VarGeneral.Hdate, "yyyy/MM/dd"));
                GetInvSetting();
                textBox_ID.Text = db.MaxOfferNo.ToString();
                FlxInv.Rows.Count = VarGeneral.Settings_Sys.LineOfInvoices.Value;
                FlxInvDet.Rows.Count = VarGeneral.Settings_Sys.LineOfInvoices.Value;
                State = FormState.New;
                try
                {
                    base.ActiveControl = FlxInv;
                    FlxInv.Row = 1;
                    FlxInv.Col = 1;
                }
                catch
                {
                }
            }
        }
        public void RefreshPKeys()
        {
            PKeys.Clear();
            try
            {
                PKeys = db.ExecuteQuery<string>("select OfferHeadNo from T_Offer where OfferHeadTyp =" + (switchButton_OfferTyp.Value ? 1 : 0), new object[0]).ToList();
            }
            catch
            {
                PKeys.Clear();
            }
            int count = 0;
            count = PKeys.Count;
            Label_Count.Text = string.Concat(count);
            UpdateVcr();
        }
        public void Fill_DGV_Main()
        {
            DGV_Main.PrimaryGrid.VirtualMode = true;
            Stock_DataDataContext db = new Stock_DataDataContext(VarGeneral.BranchCS);
            List<T_Offer> list = db.FillInvOffer_2(VarGeneral.InvTyp, textBox_search.TextBox.Text).ToList();
            DGV_Main.PrimaryGrid.VirtualRowCount = list.Count;
            if (DGV_Main.PrimaryGrid.Columns.Count == 0)
            {
                foreach (KeyValuePair<string, ColumnDictinary> item in columns_Names_visible)
                {
                    DGV_Main.PrimaryGrid.Columns.Add(new GridColumn(item.Key));
                }
            }
            FillHDGV(list);
        }
        protected override void OnParentRightToLeftChanged(EventArgs e)
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmInvOffer));
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
            ArbEng();
            FillCombo();
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
                DGV_Main.PrimaryGrid.GroupByRow.Text = "جميع السجلات";
                checkBox_DisVal.Text = "قيمـــة";
                checkBox_DisRate.Text = "نسبـــة";
                switchButton_OfferTyp.OffText = "تخفيض الأسعـــار";
                switchButton_OfferTyp.OnText = "كميــات مجــانيـة";
                txtRemark.ButtonCustom.Text = "ملاحظــة";
                groupBox5.Text = "طريقة الخصم";
                Text = "العــروض الخـــاصة";
            }
            else
            {
                Button_First.Text = "First";
                Button_Last.Text = "Last";
                Button_Next.Text = "Next";
                Button_Prev.Text = "Previous";
                Button_Add.Text = "New";
                Button_Close.Text = "Close";
                Button_Delete.Text = "Del";
                Button_Save.Text = "Save";
                Button_Search.Text = "Srch";
                Button_First.Tooltip = "First Record";
                Button_Last.Tooltip = "Last Record";
                Button_Next.Tooltip = "Next Record";
                Button_Prev.Tooltip = "Previous Record";
                Button_Add.Tooltip = "F1";
                Button_Close.Tooltip = "Esc";
                Button_Delete.Tooltip = "F3";
                Button_Save.Tooltip = "F2";
                Button_Search.Tooltip = "F4";
                DGV_Main.PrimaryGrid.GroupByRow.Text = "All Records";
                checkBox_DisVal.Text = "Value";
                checkBox_DisRate.Text = "Rate";
                switchButton_OfferTyp.OffText = "Low prices";
                switchButton_OfferTyp.OnText = "Free quantities";
                txtRemark.ButtonCustom.Text = "Note";
                groupBox5.Text = "Discound Method";
                Text = "Spicial Offers";
            }
        }
        private void _ownerDraw(object sender, OwnerDrawCellEventArgs e)
        {
            if (e.Col == 0 && e.Row > 0)
            {
                e.Text = e.Row.ToString();
            }
        }
        private void FrmInvOffer_Load(object sender, EventArgs e)
        {
            try
            {
                Location = Frm_Main.loc;
                if (!VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 59))
                {
                    //switchButton_Lock.Visible = false;
                }
                ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmInvOffer));
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
                _StorePr = permission.StorePrmission.Split(',').ToList();
                if (columns_Names_visible.Count == 0)
                {
                    columns_Names_visible.Add("OfferHeadNo", new ColumnDictinary("رقم العــرض", "offer No", ifDefault: true, ""));
                    columns_Names_visible.Add("OfferHeadName", new ColumnDictinary("إسم العرض", "Offer Name", ifDefault: true, ""));
                    columns_Names_visible.Add("OfferSalsManNo", new ColumnDictinary("رقم البائع", "SalsMan No", ifDefault: false, ""));
                    columns_Names_visible.Add("EndDat", new ColumnDictinary("تاريخ البداية", "Start Date", ifDefault: true, ""));
                    columns_Names_visible.Add("StartDat", new ColumnDictinary("تاريخ النهاية", "End Date", ifDefault: true, ""));
                }
                else
                {
                    Clear();
                    textBox_ID.Text = "";
                    TextBox_Index.TextBox.Text = "";
                }
                VarGeneral.InvTyp = 0;
                MainProcess();
                string Co = "";
                for (int iiCnt = 0; iiCnt < listStore.Count; iiCnt++)
                {
                    _Store = listStore[iiCnt];
                    Co = ((!(Co != "")) ? _Store.Stor_ID.ToString() : (Co + "|" + _Store.Stor_ID));
                }
                FlxInvDet.Cols[6].ComboList = Co;
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Load:", error, enable: true);
                MessageBox.Show(error.Message);
            }
            FlxInv.DrawMode = DrawModeEnum.OwnerDraw;
            FlxInv.OwnerDrawCell += _ownerDraw;
        }
        private void MainProcess()
        {
            FillCombo();
            GetInvSetting();
            ArbEng();
            RefreshPKeys();
            textBox_ID.Text = PKeys.FirstOrDefault();
            listUnit = new List<T_Unit>();
            listUnit = db.FillUnit_2("").ToList();
            listStore = db.FillStore_2("").ToList();
            UpdateVcr();
        }
        private void TextBox_Search_ButtonCustomClick(object sender, EventArgs e)
        {
            textBox_search.Text = "";
        }
        private void DGV_Main_AfterCheck(object sender, GridAfterCheckEventArgs e)
        {
            DGV_Main.PrimaryGrid.VirtualMode = false;
            GridRow crow = e.Item as GridRow;
            if (crow != null && crow.Checked)
            {
                GridPanel panel = new GridPanel();
                var q = db.StockOffer(VarGeneral.InvTyp, crow.Cells["OfferHeadNo"].Value.ToString()).T_OfferDets.Select((T_OfferDet item) => new
                {
                    ItmNo = item.ItmNo,
                    Arb_Des = item.T_Item.Arb_Des,
                    Eng_Des = item.T_Item.Eng_Des,
                    UntNm_A = item.T_Unit.Arb_Des,
                    UntNm_E = item.T_Unit.Eng_Des,
                    Price = item.Price,
                    DisVal = item.DisVal,
                    UnitPriVal = item.UnitPriVal
                });
                panel.DataSource = q.ToList();
                panel.DataMember = "Line";
                crow.Rows.Add(panel);
                crow.SuperGrid.DataBindingComplete += DGV_Main_DataBindingComplete;
                panel.EnsureVisible(center: true);
            }
            else
            {
                crow?.Rows.Clear();
            }
        }
        private void PropHIOfferPanel(GridPanel panel)
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
            panel.Columns["OfferHeadNo"].Width = 150;
            panel.Columns["OfferHeadNo"].Visible = columns_Names_visible["OfferHeadNo"].IfDefault;
            panel.Columns["OfferHeadName"].Width = 200;
            panel.Columns["OfferHeadName"].Visible = columns_Names_visible["OfferHeadName"].IfDefault;
            panel.Columns["OfferSalsManNo"].Width = 100;
            panel.Columns["OfferSalsManNo"].Visible = columns_Names_visible["OfferSalsManNo"].IfDefault;
            panel.Columns["EndDat"].Width = 100;
            panel.Columns["EndDat"].Visible = columns_Names_visible["EndDat"].IfDefault;
            panel.Columns["StartDat"].Width = 100;
            panel.Columns["StartDat"].Visible = columns_Names_visible["StartDat"].IfDefault;
        }
        private void PropLOfferPanel(GridPanel panel)
        {
            panel.ColumnAutoSizeMode = ColumnAutoSizeMode.DisplayedCells;
            panel.Columns["ItmNo"].HeaderText = ((LangArEn == 0) ? "رقم الصنف" : "Item No");
            panel.Columns["Arb_Des"].HeaderText = ((LangArEn == 0) ? "الوصف " : "Description");
            panel.Columns["Eng_Des"].HeaderText = ((LangArEn == 0) ? "الوصف" : "Description");
            panel.Columns["UntNm_A"].HeaderText = ((LangArEn == 0) ? "الوحدة" : "Unit");
            panel.Columns["UntNm_E"].HeaderText = ((LangArEn == 0) ? "الوحدة" : "Unit");
            panel.Columns["Price"].HeaderText = ((LangArEn == 0) ? "السعر" : "Price");
            panel.Columns["DisVal"].HeaderText = ((LangArEn == 0) ? "الخصم" : "Discount");
            panel.Columns["UnitPriVal"].HeaderText = ((LangArEn == 0) ? "السعر الجديد" : "New Pric");
            panel.Footer.Text = ((LangArEn == 0) ? "عدد الأسطر: " : "Lines Count: ") + panel.Rows.Count;
            panel.ReadOnly = true;
            panel.ShowRowDirtyMarker = true;
            panel.ColumnHeader.RowHeight = 30;
            for (int i = 0; i < panel.Columns.Count; i++)
            {
                panel.Columns[i].AutoSizeMode = ColumnAutoSizeMode.AllCells;
            }
            panel.Columns[1].Width = 160;
            panel.Columns[2].Width = 300;
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                panel.Columns["Eng_Des"].Visible = false;
                panel.Columns["UntNm_E"].Visible = false;
                panel.Columns["Arb_Des"].Visible = true;
                panel.Columns["UntNm_A"].Visible = true;
            }
            else
            {
                panel.Columns["Arb_Des"].Visible = false;
                panel.Columns["UntNm_A"].Visible = false;
                panel.Columns["Eng_Des"].Visible = true;
                panel.Columns["UntNm_E"].Visible = true;
            }
            panel.DefaultVisualStyles.CaptionStyles.Default.Alignment = Alignment.MiddleCenter;
            panel.DefaultVisualStyles.CellStyles.Default.Alignment = Alignment.MiddleCenter;
            panel.GroupByRow.Visible = false;
            panel.AllowEdit = false;
            panel.CheckBoxes = false;
            panel.ShowCheckBox = false;
            panel.ShowRowGridIndex = true;
        }
        private void DateTimePicker_Search_From_ValueChanged(object sender, EventArgs e)
        {
            Fill_DGV_Main();
        }
        private void TextBox_Search_InputTextChanged(object sender)
        {
            Fill_DGV_Main();
        }
        private void Button_Save_Click(object sender, EventArgs e)
        {
            try
            {
                textBox_ID.Focus();
                if (SaveData())
                {
                    State = FormState.Saved;
                    RefreshPKeys();
                    TextBox_Index.TextBox.Text = string.Concat(PKeys.IndexOf(data_this.OfferHeadNo ?? "") + 1);
                    dbInstance = null;
                    textBox_ID_TextChanged(sender, e);
                    SetReadOnly = true;
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Button_Save_Click:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        public void TextBox_Index_InputTextChanged(object sender)
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
        private void GetInvSetting()
        {
            _InvSetting = new T_INVSETTING();
            _SysSetting = new T_SYSSETTING();
            _InvSetting = db.StockInvSetting(VarGeneral.UserID, 1);
            _SysSetting = db.SystemSettingStock();
        }
        private void textBox_ID_TextChanged(object sender, EventArgs e)
        {
            string no = "";
            try
            {
                no = textBox_ID.Text;
            }
            catch
            {
            }
            try
            {
                T_Offer newData = db.StockOffer(VarGeneral.InvTyp, no);
                if (newData == null || string.IsNullOrEmpty(newData.OfferHeadNo))
                {
                    if (!Button_Add.Visible || !Button_Add.Enabled)
                    {
                        MessageBox.Show((LangArEn == 0) ? "لا يمكن اتمام هذه العملية .. الرجاء مراجعة صلاحيات المستخدمين !" : "Can not complete this process .. please see the powers of the users!", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        textBox_ID.TextChanged -= textBox_ID_TextChanged;
                        try
                        {
                            textBox_ID.Text = data_this.OfferHeadNo;
                        }
                        catch
                        {
                        }
                        textBox_ID.TextChanged += textBox_ID_TextChanged;
                        return;
                    }
                    Clear();
                    FlxInv.Rows.Count = VarGeneral.Settings_Sys.LineOfInvoices.Value;
                    FlxInvDet.Rows.Count = VarGeneral.Settings_Sys.LineOfInvoices.Value;
                    State = FormState.New;
                    TextBox_Index.InputTextChanged -= TextBox_Index_InputTextChanged;
                    TextBox_Index.TextBox.Text = string.Concat(PKeys.Count + 1);
                    TextBox_Index.InputTextChanged += TextBox_Index_InputTextChanged;
                }
                else
                {
                    DataThis = newData;
                    int indexA = PKeys.IndexOf(newData.OfferHeadNo ?? "");
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
            FlxDat.Visible = false;
            UpdateVcr();
        }
        private void Button_Filter_Click(object sender, EventArgs e)
        {
            Fill_DGV_Main();
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
        private void ToolStripMenuItem_Det_Click(object sender, EventArgs e)
        {
            int rowIndex = Convert.ToInt32(DGV_Main.PrimaryGrid.Tag);
            TextBox_Index.TextBox.Text = string.Concat(rowIndex + 1);
            expandableSplitter1.Expanded = true;
            ViewDetails_Click(sender, e);
        }
        private void DGV_Main_CellMouseDown(object sender, GridCellMouseEventArgs e)
        {
            DGV_Main.PrimaryGrid.Tag = e.GridCell.RowIndex;
        }
        private void DGV_Main_CellDoubleClick(object sender, GridCellDoubleClickEventArgs e)
        {
            ToolStripMenuItem_Det_Click(sender, e);
        }
        private void DGV_Main_CellClick(object sender, GridCellClickEventArgs e)
        {
            DGV_Main.PrimaryGrid.Tag = e.GridCell.RowIndex;
        }
        private void txtHDate_Leave(object sender, EventArgs e)
        {
            try
            {
                txtEndDate.Text = Convert.ToDateTime(txtEndDate.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                txtEndDate.Text = "";
            }
        }
        private void txtGDate_Leave(object sender, EventArgs e)
        {
            try
            {
                txtStartDate.Text = Convert.ToDateTime(txtStartDate.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                txtStartDate.Text = "";
            }
        }
        private void txtGDate_Click(object sender, EventArgs e)
        {
            txtStartDate.SelectAll();
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
            else if (e.KeyCode == Keys.F9)
            {
                try
                {
                    PrintDocument prnt_doc = new PrintDocument();
                    T_INVSETTING _InvSetting = new T_INVSETTING();
                    _InvSetting = db.StockInvSetting(VarGeneral.UserID, VarGeneral.InvTyp);
                    string _PrinterName = prnt_doc.PrinterSettings.PrinterName;
                    try
                    {
                        prnt_doc.PrinterSettings.PrinterName = _InvSetting.defPrn;
                        if (prnt_doc.PrinterSettings.IsValid)
                        {
                            _PrinterName = _InvSetting.defPrn;
                        }
                    }
                    catch
                    {
                    }
                    CashDrawer.OpenDrawer(_PrinterName);
                }
                catch (Exception error)
                {
                    try
                    {
                        VarGeneral.DebLog.writeLog("button_openCasheir_Click:", error, enable: true);
                    }
                    catch
                    {
                    }
                }
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
        private bool ChkBarCod(string BarCod)
        {
            DefPack = 0;
            T_Item _ItmBarCod = new T_Item();
            listItems = db.FillItemBarCode_2(BarCod).ToList();
            for (int iiCnt = 0; iiCnt < listItems.Count; iiCnt++)
            {
                _ItmBarCod = listItems[iiCnt];
                if (BarCod == _ItmBarCod.BarCod1)
                {
                    _Items = _ItmBarCod;
                    DefPack = 1;
                    return true;
                }
                if (BarCod == _ItmBarCod.BarCod2)
                {
                    _Items = _ItmBarCod;
                    DefPack = 2;
                    return true;
                }
                if (BarCod == _ItmBarCod.BarCod3)
                {
                    _Items = _ItmBarCod;
                    DefPack = 3;
                    return true;
                }
                if (BarCod == _ItmBarCod.BarCod4)
                {
                    _Items = _ItmBarCod;
                    DefPack = 4;
                    return true;
                }
                if (BarCod == _ItmBarCod.BarCod5)
                {
                    _Items = _ItmBarCod;
                    DefPack = 5;
                    return true;
                }
            }
            return false;
        }
        private void txtHDate_Click(object sender, EventArgs e)
        {
            txtEndDate.SelectAll();
        }
        private void FlxInv_Click(object sender, EventArgs e)
        {
            Button_Edit_Click(sender, e);
        }
        private void FillCombo()
        {
            CmbInvPrice.Items.Clear();
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                CmbInvPrice.Items.Add("الأفتراضي");
                CmbInvPrice.Items.Add("سعر الجملة");
                CmbInvPrice.Items.Add("سعر الموزع");
                CmbInvPrice.Items.Add("سعر المندوب");
                CmbInvPrice.Items.Add("سعر التجزئة");
                CmbInvPrice.Items.Add("سعر آخر");
            }
            else
            {
                CmbInvPrice.Items.Add("Default");
                CmbInvPrice.Items.Add("Wholesale price");
                CmbInvPrice.Items.Add("Distributor price");
                CmbInvPrice.Items.Add("Legates Price");
                CmbInvPrice.Items.Add("Retail price");
                CmbInvPrice.Items.Add("Other price");
            }
            CmbInvPrice.SelectedIndex = 0;
        }
        public void SetData(T_Offer value)
        {
            switchButton_OfferTyp.ValueChanged -= switchButton_OfferTyp_ValueChanged;
            try
            {
                State = FormState.Saved;
                Button_Save.Enabled = false;
                textBox_OfferName.Text = value.OfferHeadName;
                textBox_ID.Tag = value.OfferHeadID;
                try
                {
                    if (VarGeneral.CheckDate(value.StartDat))
                    {
                        txtStartDate.Text = Convert.ToDateTime(value.StartDat).ToString("yyyy/MM/dd");
                    }
                }
                catch
                {
                    txtStartDate.Text = value.StartDat;
                }
                try
                {
                    if (VarGeneral.CheckDate(value.EndDat))
                    {
                        txtEndDate.Text = Convert.ToDateTime(value.EndDat).ToString("yyyy/MM/dd");
                    }
                }
                catch
                {
                    txtEndDate.Text = value.EndDat;
                }
                txtCustNo.Text = value.CusVenNo.ToString();
                try
                {
                    if (!string.IsNullOrEmpty(value.CusVenNo))
                    {
                        txtCustName.Text = ((LangArEn == 0) ? db.StockAccDefWithOutBalance(value.CusVenNo).Arb_Des : db.StockAccDefWithOutBalance(value.CusVenNo).Eng_Des);
                    }
                    else
                    {
                        txtCustName.Text = "";
                    }
                }
                catch
                {
                    txtCustName.Text = "";
                }
                if (VarGeneral.SSSLev == "M")
                {
                    txtCustNo.Text = "";
                }
                txtRemark.Text = value.OfferRemark;
                textBox_Usr.Text = ((LangArEn == 0) ? dbc.RateUsr(value.OfferSalsManNo).UsrNamA : dbc.RateUsr(value.OfferSalsManNo).UsrNamE);
                if (value.CustPri.HasValue)
                {
                    CmbInvPrice.SelectedIndex = value.CustPri.Value;
                }
                switchButton_OfferTyp.Value = ((value.OfferHeadTyp.Value == 1) ? true : false);
                if (value.OfferHeadCashCredit.HasValue)
                {
                    int? offerHeadCashCredit = value.OfferHeadCashCredit;
                    if (offerHeadCashCredit.Value == 0 && offerHeadCashCredit.HasValue)
                    {
                        checkBox_DisVal.Checked = true;
                    }
                    else if (value.OfferHeadCashCredit == 1)
                    {
                        checkBox_DisRate.Checked = true;
                    }
                }
                LDataThis = new BindingList<T_OfferDet>(value.T_OfferDets).ToList();
                SetLines(LDataThis);
                if (switchButton_OfferTyp.Value)
                {
                    LDataThisQFree = new BindingList<T_OfferQFree>(value.T_OfferQFrees).ToList();
                    SetLinesQFree(LDataThisQFree);
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("SetData:", error, enable: true);
                MessageBox.Show(error.Message);
            }
            switchButton_OfferTyp.ValueChanged += switchButton_OfferTyp_ValueChanged;
        }
        public void SetLines(List<T_OfferDet> listDet)
        {
            try
            {
                FlxInv.Rows.Count = listDet.Count + 1;
                for (int iiCnt = 1; iiCnt <= listDet.Count; iiCnt++)
                {
                    _InvDet = listDet[iiCnt - 1];
                    int Ser = _InvDet.OfferDetSer.GetValueOrDefault();
                    FlxInv.SetData(iiCnt, 0, Ser.ToString());
                    FlxInv.SetData(iiCnt, 1, _InvDet.ItmNo.Trim());
                    FlxInv.SetData(iiCnt, 2, _InvDet.T_Item.Arb_Des.ToString());
                    FlxInv.SetData(iiCnt, 3, _InvDet.T_Unit.Arb_Des.ToString());
                    FlxInv.SetData(iiCnt, 4, _InvDet.T_Item.Eng_Des.ToString());
                    FlxInv.SetData(iiCnt, 5, _InvDet.T_Unit.Eng_Des.ToString());
                    FlxInv.SetData(iiCnt, 6, _InvDet.Price.Value);
                    FlxInv.SetData(iiCnt, 7, _InvDet.DisVal.Value);
                    FlxInv.SetData(iiCnt, 8, _InvDet.UnitPriVal.Value);
                    FlxInv.SetData(iiCnt, 9, _InvDet.Qty.Value);
                    FlxInv.SetData(iiCnt, 10, _InvDet.QtyTo.Value);
                }
            }
            catch
            {
                MessageBox.Show((LangArEn == 0) ? "حدث خطأ أثناء تعبئة الأسطر .." : "An error occurred while filling lines ..", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
        public void SetLinesQFree(List<T_OfferQFree> listDet)
        {
            try
            {
                FillLines();
                FlxInvDet.Rows.Count = listDet.Count + 1;
                for (int iiCnt = 1; iiCnt <= listDet.Count; iiCnt++)
                {
                    _InvDetQFree = listDet[iiCnt - 1];
                    int Ser = _InvDetQFree.OfferQFreeSer.GetValueOrDefault();
                    FlxInvDet.SetData(iiCnt, 0, Ser.ToString());
                    FlxInvDet.SetData(iiCnt, 1, _InvDetQFree.OfferQFreeItmNo.Trim());
                    FlxInvDet.SetData(iiCnt, 2, _InvDetQFree.T_Item.Arb_Des.ToString());
                    FlxInvDet.SetData(iiCnt, 3, _InvDetQFree.T_Unit.Arb_Des.ToString());
                    FlxInvDet.SetData(iiCnt, 4, _InvDetQFree.T_Item.Eng_Des.ToString());
                    FlxInvDet.SetData(iiCnt, 5, _InvDetQFree.T_Unit.Eng_Des.ToString());
                    FlxInvDet.SetData(iiCnt, 6, _InvDetQFree.OfferQFreeStoreNo.Value);
                    FlxInvDet.SetData(iiCnt, 7, _InvDetQFree.OfferQFreePrice.Value);
                    FlxInvDet.SetData(iiCnt, 8, _InvDetQFree.OfferQFreeDisVal.Value);
                    FlxInvDet.SetData(iiCnt, 9, _InvDetQFree.OfferQFreeUnitPriVal.Value);
                    FlxInvDet.SetData(iiCnt, 10, _InvDetQFree.OfferQFreeQty.Value);
                    FlxInvDet.SetData(iiCnt, 16, LDataThis.Where((T_OfferDet g) => g.OfferDet_ID == _InvDetQFree.OfferQFreeID).FirstOrDefault().OfferDetSer);
                    FlxInvDet.SetData(iiCnt, 12, LDataThis.Where((T_OfferDet g) => g.OfferDet_ID == _InvDetQFree.OfferQFreeID).FirstOrDefault().ItmNo);
                    FlxInvDet.SetData(iiCnt, 13, LDataThis.Where((T_OfferDet g) => g.OfferDet_ID == _InvDetQFree.OfferQFreeID).FirstOrDefault().T_Unit.Arb_Des);
                    FlxInvDet.SetData(iiCnt, 14, _InvDetQFree.OfferQFreeDatExper);
                    FlxInvDet.SetData(iiCnt, 15, _InvDetQFree.OfferQFreeRunCod);
                    FlxInvDet.SetData(iiCnt, 11, _InvDetQFree.OfferQFreeItmTax.Value);
                }
            }
            catch
            {
                MessageBox.Show((LangArEn == 0) ? "حدث خطأ أثناء تعبئة الأسطر .." : "An error occurred while filling lines ..", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
        private bool ValidData()
        {
            if (textBox_ID.Text == "0" || textBox_ID.Text == "")
            {
                MessageBox.Show((LangArEn == 0) ? "لا يمكن الحفظ بدون رقم العــرض - السند" : "Can not save without the offer number", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                textBox_ID.Focus();
                return false;
            }
            for (int iiCnt = 1; iiCnt < FlxInv.Rows.Count; iiCnt++)
            {
                if (!(string.Concat(FlxInv.GetData(iiCnt, 1)) != ""))
                {
                    continue;
                }
                for (int i = 1; i < 9; i++)
                {
                    if ((!switchButton_OfferTyp.Value || i != 9) && (switchButton_OfferTyp.Value || (i != 6 && i != 7 && i != 8)) && string.Concat(FlxInv.GetData(iiCnt, i)) == "")
                    {
                        MessageBox.Show((LangArEn == 0) ? "لا يمكن إتمام العملية .. تأكد من تعبئة جميع البيانات المطلوبة" : "We must not be empty value .. Please make sure there are items in the bill.", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        FlxInv.Row = iiCnt;
                        FlxInv.Col = i;
                        FlxInv.Focus();
                        return false;
                    }
                }
                if (!switchButton_OfferTyp.Value)
                {
                    if (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 7))).ToString()) <= 0.0)
                    {
                        MessageBox.Show((LangArEn == 0) ? "يرجى التأكد من صحة قيمة الخصم" : "Please confirm discount value are correct", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        FlxInv.Row = iiCnt;
                        FlxInv.Col = 7;
                        FlxInv.Focus();
                        return false;
                    }
                    if (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 8))).ToString()) < 0.0)
                    {
                        MessageBox.Show((LangArEn == 0) ? "يرجى التأكد من صحة الأسعار الجديدة" : "Please confirm new prices are correct", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        FlxInv.Row = iiCnt;
                        FlxInv.Col = 8;
                        FlxInv.Focus();
                        return false;
                    }
                }
                if (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 9))).ToString()) <= 0.0)
                {
                    MessageBox.Show((LangArEn == 0) ? "يرجى التأكد من صحة الكمية" : "Please confirm Quantity are correct", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    FlxInv.Row = iiCnt;
                    FlxInv.Col = 9;
                    FlxInv.Focus();
                    return false;
                }
                for (int c = 1; c < FlxInv.Rows.Count; c++)
                {
                    try
                    {
                        if (string.Concat(FlxInv.GetData(c, 1)) != "" && !string.IsNullOrEmpty(string.Concat(FlxInv.GetData(c, 1))) && c != iiCnt && FlxInv.GetData(c, 1).ToString() == FlxInv.GetData(iiCnt, 1).ToString() && FlxInv.GetData(c, 3).ToString() == FlxInv.GetData(iiCnt, 3).ToString())
                        {
                            MessageBox.Show((LangArEn == 0) ? "يجب عدم تكرار الصنف أكثر من مرة .. يرجى التأكد من السطور والمحاولة مجددا" : "The category should not be repeated more than once .. Please specify the lines and try again", VarGeneral.ProdectNam);
                            return false;
                        }
                    }
                    catch
                    {
                    }
                }
                if (!switchButton_OfferTyp.Value)
                {
                    continue;
                }
                for (int j = 1; j < FlxInvDet.Rows.Count; j++)
                {
                    if (j >= FlxInvDet.Rows.Count - 1)
                    {
                        MessageBox.Show((LangArEn == 0) ? "هناك اصناف لم يتم ربطها بأصناف أخرى ككميات مجانية .. يرجى التاكد من صحة الإدخال والمحاولة مجددا" : "There are varieties that are not matched by other varieties free quantities .. Please check the validity of the assistant and try again", VarGeneral.ProdectNam);
                        return false;
                    }
                    try
                    {
                        if (string.Concat(FlxInvDet.GetData(j, 1)) != "")
                        {
                            string xx = FlxInvDet.GetData(j, 16).ToString();
                            string xxxx = iiCnt.ToString();
                            if (FlxInvDet.GetData(j, 16).ToString() == iiCnt.ToString())
                            {
                                goto IL_052c;
                            }
                        }
                    }
                    catch
                    {
                    }
                }
            IL_052c:;
            }
            for (int iiCnt = 1; iiCnt < FlxInvDet.Rows.Count; iiCnt++)
            {
                if (!(string.Concat(FlxInvDet.GetData(iiCnt, 1)) != ""))
                {
                    continue;
                }
                for (int i = 1; i < 17; i++)
                {
                    if (i != 14 && i != 15 && i != 6 && string.Concat(FlxInvDet.GetData(iiCnt, i)) == "")
                    {
                        MessageBox.Show((LangArEn == 0) ? "لا يمكن إتمام العملية .. تأكد من تعبئة جميع البيانات المطلوبة" : "We must not be empty value .. Please make sure there are items in the bill.", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        FlxInvDet.Row = iiCnt;
                        FlxInvDet.Col = i;
                        FlxInvDet.Focus();
                        return false;
                    }
                }
                if (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInvDet.GetData(iiCnt, 9))).ToString()) < 0.0)
                {
                    MessageBox.Show((LangArEn == 0) ? "يرجى التأكد من صحة الأسعار الجديدة" : "Please confirm new prices are correct", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    FlxInvDet.Row = iiCnt;
                    FlxInvDet.Col = 9;
                    FlxInvDet.Focus();
                    return false;
                }
                if (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInvDet.GetData(iiCnt, 10))).ToString()) <= 0.0)
                {
                    MessageBox.Show((LangArEn == 0) ? "يرجى التأكد من صحة الكمية" : "Please confirm Quantity are correct", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    FlxInvDet.Row = iiCnt;
                    FlxInvDet.Col = 10;
                    FlxInvDet.Focus();
                    return false;
                }
                for (int j = 1; j < FlxInv.Rows.Count; j++)
                {
                    if (j >= FlxInv.Rows.Count - 1)
                    {
                        MessageBox.Show((LangArEn == 0) ? "هناك اصناف لم يتم ربطها بأصناف أخرى ككميات مجانية .. يرجى التاكد من صحة الإدخال والمحاولة مجددا" : "There are varieties that are not matched by other varieties free quantities .. Please check the validity of the assistant and try again", VarGeneral.ProdectNam);
                        return false;
                    }
                    try
                    {
                        if (string.Concat(FlxInv.GetData(j, 1)) != "")
                        {
                            int xx2 = j;
                            string xxxx = FlxInvDet.GetData(iiCnt, 16).ToString();
                            if (j.ToString() == FlxInvDet.GetData(iiCnt, 16).ToString())
                            {
                                goto IL_082e;
                            }
                        }
                    }
                    catch
                    {
                    }
                }
            IL_082e:;
            }
            if (State == FormState.Edit)
            {
                T_Offer newData = db.StockOffer(VarGeneral.InvTyp, textBox_ID.Text);
                if ((!string.IsNullOrEmpty(newData.OfferHeadNo) || newData.OfferHeadID > 0) && newData.OfferHeadID != data_this.OfferHeadID)
                {
                    MessageBox.Show((LangArEn == 0) ? " رقم العــرض مكرر يرجى تغييره" : "Employee No It's a existing", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    textBox_ID.Focus();
                    return false;
                }
            }
            if (!VarGeneral.CheckDate(txtStartDate.Text))
            {
                MessageBox.Show((LangArEn == 0) ? " يرجى التاكد من صحة تاريخ البداية" : "Please make sure the date is correct", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                txtStartDate.Focus();
                return false;
            }
            if (!VarGeneral.CheckDate(txtEndDate.Text))
            {
                MessageBox.Show((LangArEn == 0) ? " يرجى التاكد من صحة تاريخ النهاية" : "Please make sure the date is correct", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                txtEndDate.Focus();
                return false;
            }
            if (Convert.ToDateTime(txtEndDate.Text) < Convert.ToDateTime(txtStartDate.Text))
            {
                MessageBox.Show((LangArEn == 0) ? "تأكد من صحة تاريخ البداية والنهاية " : "Start Date and End Date is Uncorrecte", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                txtEndDate.Text = "";
                txtStartDate.Focus();
                return false;
            }
            return true;
        }
        private bool SaveData()
        {
            if (State == FormState.New)
            {
                dbInstance = null;
            }
            if (!ValidData())
            {
                return false;
            }
            IDatabase db_ = Database.GetDatabase(VarGeneral.BranchCS);
            try
            {
                GetData();
                if (State == FormState.New)
                {
                    try
                    {
                        GetInvSetting();
                        textBox_ID.TextChanged -= textBox_ID_TextChanged;
                        T_Offer newData = db.StockOffer(VarGeneral.InvTyp, data_this.OfferHeadNo);
                        if (!string.IsNullOrEmpty(newData.OfferHeadNo) || newData.OfferHeadID > 0)
                        {
                            string max = "";
                            dbInstance = null;
                            max = db.MaxOfferNo.ToString();
                            MessageBox.Show("الرمز مستخدم من قبل.\n سيتم الحفظ برقم جديد [" + max + "]", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            textBox_ID.Text = max ?? "";
                            data_this.OfferHeadNo = max ?? "";
                        }
                        textBox_ID.TextChanged += textBox_ID_TextChanged;
                        data_this.OfferSalsManNo = VarGeneral.UserNumber;
                        db.T_Offers.InsertOnSubmit(data_this);
                        db.SubmitChanges();
                    }
                    catch (SqlException ex2)
                    {
                        try
                        {
                            VarGeneral.DebLog.writeLog("SaveData:", ex2, enable: true);
                        }
                        catch
                        {
                        }
                        string max = "";
                        dbInstance = null;
                        max = db.MaxOfferNo.ToString();
                        if (ex2.Number == 2627)
                        {
                            MessageBox.Show("الرمز مستخدم من قبل.\n سيتم الحفظ برقم جديد [" + max + "]", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            textBox_ID.Text = max ?? "";
                            data_this.OfferHeadNo = max ?? "";
                            Button_Save_Click(null, null);
                        }
                    }
                    catch (Exception ex3)
                    {
                        try
                        {
                            VarGeneral.DebLog.writeLog("SaveData2:", ex3, enable: true);
                        }
                        catch
                        {
                        }
                        return false;
                    }
                }
                else
                {
                    db.ExecuteCommand("DELETE FROM [dbo].[T_OfferQFree] WHERE OfferIDQ =" + DataThis.OfferHeadID);
                    db.ExecuteCommand("DELETE FROM [dbo].[T_OfferDet] WHERE OfferID =" + DataThis.OfferHeadID);
                    db.Log = VarGeneral.DebugLog;
                    db.SubmitChanges(ConflictMode.ContinueOnConflict);
                }
                int iiCnt = 0;
                int seqID = 1;
                int seqIDQFree = 1;
                int i;
                for (iiCnt = 1; iiCnt < FlxInv.Rows.Count; iiCnt++)
                {
                    if (FlxInv.GetData(iiCnt, 1) == null)
                    {
                        continue;
                    }
                    T_OfferDet _data = new T_OfferDet();
                    _data.DisVal = double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 7))));
                    _data.ItmNo = FlxInv.GetData(iiCnt, 1).ToString();
                    _data.ItmUnt = db.T_Units.Where((T_Unit t) => t.Arb_Des == FlxInv.GetData(iiCnt, 3).ToString()).ToList().FirstOrDefault()
                        .Unit_ID;
                    _data.OfferDetNo = textBox_ID.Text.Trim();
                    _data.OfferDetSer = seqID;
                    _data.OfferID = data_this.OfferHeadID;
                    _data.Price = double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 6))));
                    _data.UnitPriVal = double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 8))));
                    try
                    {
                        _data.Qty = double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 9))));
                    }
                    catch
                    {
                        _data.Qty = 1.0;
                    }
                    if (_data.Qty.Value <= 0.0)
                    {
                        _data.Qty = 1.0;
                    }
                    try
                    {
                        _data.QtyTo = double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 10))));
                    }
                    catch
                    {
                        _data.QtyTo = 0.0;
                    }
                    if (_data.QtyTo.Value < 0.0)
                    {
                        _data.QtyTo = 0.0;
                    }
                    if (_data.QtyTo < _data.Qty)
                    {
                        _data.QtyTo = 0.0;
                    }
                    db.T_OfferDets.InsertOnSubmit(_data);
                    db.SubmitChanges();
                    seqID++;
                    if (!switchButton_OfferTyp.Value)
                    {
                        continue;
                    }
                    i = 1;
                    while (true)
                    {
                        if (i >= FlxInvDet.Rows.Count)
                        {
                            break;
                        }
                        if (FlxInvDet.GetData(i, 1) != null && FlxInvDet.GetData(i, 16) != null && FlxInvDet.GetData(i, 12).ToString() == _data.ItmNo && db.T_Units.Where((T_Unit t) => t.Arb_Des == FlxInvDet.GetData(iiCnt, 13).ToString()).ToList().FirstOrDefault()
                            .Unit_ID == _data.ItmUnt.Value)
                        {
                            T_OfferQFree _dataQFree = new T_OfferQFree();
                            _dataQFree.OfferQFreeDisVal = double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInvDet.GetData(i, 8))));
                            _dataQFree.OfferQFreeItmNo = FlxInvDet.GetData(i, 1).ToString();
                            _dataQFree.OfferQFreeItmUnt = db.T_Units.Where((T_Unit t) => t.Arb_Des == FlxInvDet.GetData(i, 3).ToString()).ToList().FirstOrDefault()
                                .Unit_ID;
                            _dataQFree.OfferQFreeNo = textBox_ID.Text.Trim();
                            _dataQFree.OfferQFreeSer = seqIDQFree;
                            _dataQFree.OfferQFreeID = _data.OfferDet_ID;
                            _dataQFree.OfferQFreeStoreNo = int.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInvDet.GetData(i, 6))));
                            _dataQFree.OfferQFreePrice = double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInvDet.GetData(i, 7))));
                            _dataQFree.OfferQFreeUnitPriVal = double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInvDet.GetData(i, 9))));
                            _dataQFree.OfferQFreeQty = double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInvDet.GetData(i, 10))));
                            _dataQFree.OfferQFreeItmTax = double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInvDet.GetData(i, 11))));
                            _dataQFree.OfferQFreeDatExper = FlxInvDet.GetData(i, 14).ToString();
                            _dataQFree.OfferQFreeRunCod = FlxInvDet.GetData(i, 15).ToString();
                            _dataQFree.OfferIDQ = data_this.OfferHeadID;
                            db.T_OfferQFrees.InsertOnSubmit(_dataQFree);
                            db.SubmitChanges();
                            seqIDQFree++;
                        }
                        i++;
                    }
                }
                MessageBox.Show((LangArEn == 0) ? "لقد تم اتمام العملية بنجاح .." : "This Opration Is Done", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (Exception ex3)
            {
                VarGeneral.DebLog.writeLog("MainSaveData:", ex3, enable: true);
                MessageBox.Show(ex3.Message);
                return false;
            }
            return true;
        }
        private T_Offer GetData()
        {
            try
            {
                if (CmbInvPrice.SelectedIndex >= 0)
                {
                    data_this.CustPri = CmbInvPrice.SelectedIndex;
                }
                else
                {
                    data_this.CustPri = 0;
                }
            }
            catch
            {
                data_this.CustPri = 0;
            }
            data_this.OfferHeadTyp = (switchButton_OfferTyp.Value ? 1 : 0);
            data_this.CusVenNo = txtCustNo.Text;
            data_this.OfferRemark = txtRemark.Text;
            data_this.OfferHeadNo = textBox_ID.Text;
            data_this.EndDat = txtEndDate.Text;
            data_this.StartDat = txtStartDate.Text;
            data_this.OfferHeadName = textBox_OfferName.Text;
            try
            {
                if (checkBox_DisVal.Checked)
                {
                    data_this.OfferHeadCashCredit = 0;
                }
                else if (checkBox_DisRate.Checked)
                {
                    data_this.OfferHeadCashCredit = 1;
                }
                else
                {
                    data_this.OfferHeadCashCredit = 3;
                }
            }
            catch
            {
                data_this.OfferHeadCashCredit = 3;
            }
            return data_this;
        }
        private void FlxInv_AfterEdit(object sender, RowColEventArgs e)
        {
            double ItmDis = 0.0;
            try
            {
                if (checkBox_DisRate.Checked && double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7)))) > 0.0)
                {
                    ItmDis = double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 6)))) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7)))) / 100.0);
                }
            }
            catch
            {
            }
            if (e.Col == 1)
            {
                BindDataOfItem();
            }
            else if (((e.Col == 2 || e.Col == 4) && (string)FlxInv.GetData(e.Row, 1) == "") || FlxInv.GetData(e.Row, 1) == null)
            {
                BindDataOfItem();
            }
            else if ((e.Col == 3 || e.Col == 5) && FlxInv.GetData(e.Row, e.Col).ToString() != oldUnit)
            {
                int ItemIndex = -1;
                if (e.Col == 3)
                {
                    string[] Items = FlxInv.Cols[e.Col].ComboList.Split('|');
                    for (int i = 0; i < Items.Length; i++)
                    {
                        if (Items[i] == FlxInv.GetData(e.Row, e.Col).ToString())
                        {
                            ItemIndex = i + 1;
                        }
                    }
                    string[] Items2 = FlxInv.Cols[5].ComboList.Split('|');
                    if (Items2.Length > 1 && ItemIndex > -1)
                    {
                        FlxInv.SetData(e.Row, 5, Items2[ItemIndex - 1]);
                    }
                }
                else if (e.Col == 5)
                {
                    string[] Items = FlxInv.Cols[e.Col].ComboList.Split('|');
                    for (int i = 0; i < Items.Length; i++)
                    {
                        if (Items[i] == FlxInv.GetData(e.Row, e.Col).ToString())
                        {
                            ItemIndex = i + 1;
                        }
                    }
                    string[] Items2 = FlxInv.Cols[3].ComboList.Split('|');
                    if (Items2.Length > 1 && ItemIndex > -1)
                    {
                        FlxInv.SetData(e.Row, 3, Items2[ItemIndex - 1]);
                    }
                }
                switch (ItemIndex)
                {
                    case 1:
                        FlxInv.SetData(FlxInv.Row, 6, _Items.UntPri1);
                        break;
                    case 2:
                        FlxInv.SetData(FlxInv.Row, 6, _Items.UntPri2);
                        break;
                    case 3:
                        FlxInv.SetData(FlxInv.Row, 6, _Items.UntPri3);
                        break;
                    case 4:
                        FlxInv.SetData(FlxInv.Row, 6, _Items.UntPri4);
                        break;
                    case 5:
                        FlxInv.SetData(FlxInv.Row, 6, _Items.UntPri5);
                        break;
                }
                Pack = ItemIndex;
                BindDataofItemPrice();
                FlxInv.SetData(e.Row, 8, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 6)))) - (checkBox_DisVal.Checked ? double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7)))) : ItmDis));
            }
            else if (e.Col == 7)
            {
                FlxInv.SetData(e.Row, 8, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 6)))) - (checkBox_DisVal.Checked ? double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7)))) : ItmDis));
            }
        }
        private void FillLines()
        {
            string Co = " ";
            for (int iiCnt = 1; iiCnt < FlxInv.Rows.Count; iiCnt++)
            {
                if (string.Concat(FlxInv.GetData(iiCnt, 1)) != "")
                {
                    Co = ((!(Co != "")) ? iiCnt.ToString() : (Co + "|" + iiCnt));
                }
            }
            FlxInvDet.Cols[16].ComboList = Co;
        }
        private void FlxInv_BeforeEdit(object sender, RowColEventArgs e)
        {
            try
            {
                if ((e.Col == 3 || e.Col == 5) && FlxInv.GetData(e.Row, e.Col) != null)
                {
                    oldUnit = FlxInv.GetData(e.Row, 3).ToString() ?? "";
                }
            }
            catch
            {
            }
        }
        private void FlxInv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Delete)
            {
                return;
            }
            try
            {
                if (FlxInv.GetData(RowSel, 1).ToString() != null)
                {
                    FlxInv.RemoveItem(FlxInv.Row);
                }
            }
            catch
            {
                FlxInv.RemoveItem(FlxInv.Row);
            }
        }
        private void FlxInv_RowColChange(object sender, EventArgs e)
        {
            if (FlxInv.Col == 1)
            {
                Framework.Keyboard.Language.Switch("English");
            }
            if (FlxInv.Col == 2)
            {
                Framework.Keyboard.Language.Switch("Arabic");
            }
            if (FlxInv.Col == 4)
            {
                Framework.Keyboard.Language.Switch("English");
            }
        }
        private void FlxInv_SelChange(object sender, EventArgs e)
        {
            try
            {
                if (RowSel == 0 || RowSel == FlxInv.Row || FlxInv.Row <= 0 || !(string.Concat(FlxInv.GetData(FlxInv.Row, 1)) != ""))
                {
                    return;
                }
                List<T_Item> listSer = new List<T_Item>();
                listSer = db.StockItemList(string.Concat(FlxInv.GetData(FlxInv.RowSel, 1)));
                if (listSer.Count == 0)
                {
                    return;
                }
                _Items = listSer[0];
                string CoA = "";
                string CoE = "";
                for (int iiCnt = 0; iiCnt < listUnit.Count; iiCnt++)
                {
                    _Unit = listUnit[iiCnt];
                    if (_Items.Unit1 == _Unit.Unit_ID)
                    {
                        if (CoA != "")
                        {
                            CoA += "|";
                            CoE += "|";
                        }
                        CoA += _Unit.Arb_Des;
                        CoE += _Unit.Eng_Des;
                        break;
                    }
                }
                for (int iiCnt = 0; iiCnt < listUnit.Count; iiCnt++)
                {
                    _Unit = listUnit[iiCnt];
                    if (_Items.Unit2 == _Unit.Unit_ID)
                    {
                        if (CoA != "")
                        {
                            CoA += "|";
                            CoE += "|";
                        }
                        CoA += _Unit.Arb_Des;
                        CoE += _Unit.Eng_Des;
                        break;
                    }
                }
                for (int iiCnt = 0; iiCnt < listUnit.Count; iiCnt++)
                {
                    _Unit = listUnit[iiCnt];
                    if (_Items.Unit3 == _Unit.Unit_ID)
                    {
                        if (CoA != "")
                        {
                            CoA += "|";
                            CoE += "|";
                        }
                        CoA += _Unit.Arb_Des;
                        CoE += _Unit.Eng_Des;
                        break;
                    }
                }
                for (int iiCnt = 0; iiCnt < listUnit.Count; iiCnt++)
                {
                    _Unit = listUnit[iiCnt];
                    if (_Items.Unit4 == _Unit.Unit_ID)
                    {
                        if (CoA != "")
                        {
                            CoA += "|";
                            CoE += "|";
                        }
                        CoA += _Unit.Arb_Des;
                        CoE += _Unit.Eng_Des;
                        break;
                    }
                }
                for (int iiCnt = 0; iiCnt < listUnit.Count; iiCnt++)
                {
                    _Unit = listUnit[iiCnt];
                    if (_Items.Unit5 == _Unit.Unit_ID)
                    {
                        if (CoA != "")
                        {
                            CoA += "|";
                            CoE += "|";
                        }
                        CoA += _Unit.Arb_Des;
                        CoE += _Unit.Eng_Des;
                        break;
                    }
                }
                FlxInv.Cols[3].ComboList = CoA;
                FlxInv.Cols[5].ComboList = CoE;
            }
            catch
            {
            }
        }
        private void FlxInv_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                try
                {
                    if (string.Concat(FlxInv.GetData(FlxInv.RowSel, 1)) != "" && State != 0)
                    {
                        _Items = db.StockItem(string.Concat(FlxInv.GetData(FlxInv.RowSel, 1)));
                    }
                }
                catch
                {
                }
                if (string.Concat(FlxInv.GetData(FlxInv.RowSel, 1)) != "")
                {
                    _Items = db.StockItem(string.Concat(FlxInv.GetData(FlxInv.RowSel, 1)));
                    string CoA = "";
                    string CoE = "";
                    for (int iiCnt = 0; iiCnt < listUnit.Count; iiCnt++)
                    {
                        _Unit = listUnit[iiCnt];
                        if (_Items.Unit1 == _Unit.Unit_ID)
                        {
                            if (CoA != "")
                            {
                                CoA += "|";
                                CoE += "|";
                            }
                            CoA += _Unit.Arb_Des;
                            CoE += _Unit.Eng_Des;
                            break;
                        }
                    }
                    for (int iiCnt = 0; iiCnt < listUnit.Count; iiCnt++)
                    {
                        _Unit = listUnit[iiCnt];
                        if (_Items.Unit2 == _Unit.Unit_ID)
                        {
                            if (CoA != "")
                            {
                                CoA += "|";
                                CoE += "|";
                            }
                            CoA += _Unit.Arb_Des;
                            CoE += _Unit.Eng_Des;
                            break;
                        }
                    }
                    for (int iiCnt = 0; iiCnt < listUnit.Count; iiCnt++)
                    {
                        _Unit = listUnit[iiCnt];
                        if (_Items.Unit3 == _Unit.Unit_ID)
                        {
                            if (CoA != "")
                            {
                                CoA += "|";
                                CoE += "|";
                            }
                            CoA += _Unit.Arb_Des;
                            CoE += _Unit.Eng_Des;
                            break;
                        }
                    }
                    for (int iiCnt = 0; iiCnt < listUnit.Count; iiCnt++)
                    {
                        _Unit = listUnit[iiCnt];
                        if (_Items.Unit4 == _Unit.Unit_ID)
                        {
                            if (CoA != "")
                            {
                                CoA += "|";
                                CoE += "|";
                            }
                            CoA += _Unit.Arb_Des;
                            CoE += _Unit.Eng_Des;
                            break;
                        }
                    }
                    for (int iiCnt = 0; iiCnt < listUnit.Count; iiCnt++)
                    {
                        _Unit = listUnit[iiCnt];
                        if (_Items.Unit5 == _Unit.Unit_ID)
                        {
                            if (CoA != "")
                            {
                                CoA += "|";
                                CoE += "|";
                            }
                            CoA += _Unit.Arb_Des;
                            CoE += _Unit.Eng_Des;
                            break;
                        }
                    }
                    FlxInv.Cols[3].ComboList = CoA;
                    FlxInv.Cols[5].ComboList = CoE;
                }
            }
            catch
            {
            }
            FillLines();
        }
        private void BindDataOfItem()
        {
            if (!base.Visible)
            {
                return;
            }
            columns_Names_visible2.Clear();
            columns_Names_visible2.Add("Itm_No", new ColumnDictinary("رقم الصنف", "Item No", ifDefault: true, ""));
            columns_Names_visible2.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, ""));
            columns_Names_visible2.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: false, ""));
            columns_Names_visible2.Add("StartCost", new ColumnDictinary("التكلفةالافتتاحية", "Start Cost", ifDefault: false, ""));
            columns_Names_visible2.Add("AvrageCost", new ColumnDictinary("متوسط التكلفة", "Average Cost", ifDefault: false, ""));
            columns_Names_visible2.Add("LastCost", new ColumnDictinary("آخر تكلفة", "Last Cost", ifDefault: false, ""));
            columns_Names_visible2.Add("Arb_Des_Cat", new ColumnDictinary("الاسم العربي لمجموعة الصنف", "CATEGORY Arabic Name", ifDefault: false, ""));
            columns_Names_visible2.Add("Eng_Des_Cat", new ColumnDictinary("الاسم الانجليزي لمجموعة الصنف", "CATEGORY English Name", ifDefault: false, ""));
            List<T_Item> listSer = new List<T_Item>();
            bool Barcod = false;
            if ((string)FlxInv.GetData(FlxInv.Row, 1) != "" && FlxInv.GetData(FlxInv.Row, 1) != null)
            {
                Barcod = ChkBarCod((string)FlxInv.GetData(FlxInv.Row, 1));
                if (!Barcod || (VarGeneral.SSSLev != "D" && VarGeneral.SSSLev != "G" && VarGeneral.SSSLev != "S" && VarGeneral.SSSLev != "B" && VarGeneral.SSSLev != "F" && VarGeneral.SSSLev != "C" && VarGeneral.SSSLev != "R" && VarGeneral.SSSLev != "H" && VarGeneral.SSSLev != "M"))
                {
                    listSer = db.StockItemList(FlxInv.GetData(FlxInv.Row, 1).ToString());
                    if (listSer.Count != 0)
                    {
                        _Items = listSer[0];
                    }
                }
            }
            else if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 30))
            {
                string _SearchNo = "";
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_Items ";
                string Fields = "";
                Fields = ((LangArEn != 0) ? " T_Items.Itm_No as [ID Number], T_Items.Itm_No as [Item No] , T_Items.Arb_Des as [Arabic Description], T_Items.Eng_Des as [English Description] , T_Items.OpenQty as [Quantity]  " : " T_Items.Itm_No as [رقم التعريف], T_Items.Itm_No as [رقــم الصنــــف] , T_Items.Arb_Des as [الوصــف العربـــي], T_Items.Eng_Des as [الوصــف إنجلـــيزي] , T_Items.OpenQty as [الكمية] ");
                _RepShow.Rule = " Where 1 = 1 and T_Items.ItmTyp != 1 and InvSaleStoped = 0 ";
                try
                {
                    db.ExecuteCommand("select " + Fields + " From " + _RepShow.Tables + _RepShow.Rule + " order by  CONVERT(INT, LEFT(T_Items.Itm_No, PATINDEX('%[^0-9]%', T_Items.Itm_No + 'z')-1)) ");
                    _RepShow.Rule += " order by  CONVERT(INT, LEFT(T_Items.Itm_No, PATINDEX('%[^0-9]%', T_Items.Itm_No + 'z')-1)) ";
                }
                catch
                {
                    _RepShow.Rule += " order by T_Items.Itm_No ";
                }
                if (!string.IsNullOrEmpty(Fields))
                {
                    _RepShow.Fields = Fields;
                    _RepShow = _RepShow.Save();
                    VarGeneral.RepData = _RepShow.RepData;
                    if (VarGeneral.RepData.Tables[0].Rows.Count == 0)
                    {
                        return;
                    }
                    string ItmDes = "";
                    int ItmDesIndex = 1;
                    if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                    {
                        if ((string)FlxInv.GetData(FlxInv.Row, 2) != "" && FlxInv.GetData(FlxInv.Row, 2) != null)
                        {
                            ItmDes = (string)FlxInv.GetData(FlxInv.Row, 2);
                            ItmDesIndex = 2;
                        }
                    }
                    else if ((string)FlxInv.GetData(FlxInv.Row, 4) != "" && FlxInv.GetData(FlxInv.Row, 4) != null)
                    {
                        ItmDes = (string)FlxInv.GetData(FlxInv.Row, 4);
                        ItmDesIndex = 3;
                    }
                    FMFind FmQuikSerch = new FMFind(ItmDes, ItmDesIndex);
                    FmQuikSerch.Tag = LangArEn;
                    FmQuikSerch.TopMost = true;
                    FmQuikSerch.ShowDialog();
                    _SearchNo = FmQuikSerch.SerachNo;
                }
                if (!(_SearchNo != ""))
                {
                    try
                    {
                        FlxInv.RemoveItem(FlxInv.Row);
                        try
                        {
                            FlxInv.Rows.Add();
                        }
                        catch
                        {
                        }
                        FlxInv.Row = FlxInv.RowSel;
                        FlxInv.Col = 1;
                    }
                    catch
                    {
                    }
                    return;
                }
                listSer = db.StockItemList(_SearchNo);
                _Items = listSer[0];
            }
            else
            {
                List<T_Item> q = (from t in db.T_Items
                                  where t.ItmTyp != (int?)1 && !t.InvSaleStoped.Value
                                  orderby t.Itm_No
                                  select t).ToList();
                if (q.Count == 0)
                {
                    return;
                }
                string ItmDes = "";
                int ItmDesIndex = 1;
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                {
                    if ((string)FlxInv.GetData(FlxInv.Row, 2) != "" && FlxInv.GetData(FlxInv.Row, 2) != null)
                    {
                        ItmDes = (string)FlxInv.GetData(FlxInv.Row, 2);
                        ItmDesIndex = 2;
                    }
                }
                else if ((string)FlxInv.GetData(FlxInv.Row, 4) != "" && FlxInv.GetData(FlxInv.Row, 4) != null)
                {
                    ItmDes = (string)FlxInv.GetData(FlxInv.Row, 4);
                    ItmDesIndex = 3;
                }
                FrmSearch FmSerch = new FrmSearch();
                VarGeneral.SFrmTyp = "T_InvGrid";
                VarGeneral.vItmTyp = 1;
                FmSerch.Tag = LangArEn;
                VarGeneral.itmDes = ItmDes;
                VarGeneral.itmDesIndex = ItmDesIndex;
                ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible2;
                foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
                {
                    FmSerch.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, ""));
                }
                FmSerch.TopMost = true;
                FmSerch.ShowDialog();
                VarGeneral.itmDesIndex = 0;
                VarGeneral.itmDes = "";
                if (!(FmSerch.SerachNo != ""))
                {
                    try
                    {
                        FlxInv.RemoveItem(FlxInv.Row);
                        try
                        {
                            FlxInv.Rows.Add();
                        }
                        catch
                        {
                        }
                        FlxInv.Row = FlxInv.RowSel;
                        FlxInv.Col = 1;
                    }
                    catch
                    {
                    }
                    return;
                }
                listSer = db.StockItemList(FmSerch.SerachNo);
                _Items = listSer[0];
            }
            if ((!Barcod || (VarGeneral.SSSLev != "D" && VarGeneral.SSSLev != "G" && VarGeneral.SSSLev != "S" && VarGeneral.SSSLev != "B" && VarGeneral.SSSLev != "F" && VarGeneral.SSSLev != "C" && VarGeneral.SSSLev != "R" && VarGeneral.SSSLev != "H" && VarGeneral.SSSLev != "M")) && listSer.Count == 0)
            {
                if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 30))
                {
                    string _SearchNo = "";
                    RepShow _RepShow = new RepShow();
                    _RepShow.Tables = " T_Items ";
                    string Fields = "";
                    Fields = ((LangArEn != 0) ? " T_Items.Itm_No as [ID Number], T_Items.Itm_No as [Item No] , T_Items.Arb_Des as [Arabic Description], T_Items.Eng_Des as [English Description] , T_Items.OpenQty as [Quantity]  " : " T_Items.Itm_No as [رقم التعريف], T_Items.Itm_No as [رقــم الصنــــف] , T_Items.Arb_Des as [الوصــف العربـــي], T_Items.Eng_Des as [الوصــف إنجلـــيزي] , T_Items.OpenQty as [الكمية] ");
                    _RepShow.Rule = " Where 1 = 1 and T_Items.ItmTyp != 1 and InvSaleStoped = 0";
                    try
                    {
                        db.ExecuteCommand("select " + Fields + " From " + _RepShow.Tables + _RepShow.Rule + " order by  CONVERT(INT, LEFT(T_Items.Itm_No, PATINDEX('%[^0-9]%', T_Items.Itm_No + 'z')-1)) ");
                        _RepShow.Rule += " order by  CONVERT(INT, LEFT(T_Items.Itm_No, PATINDEX('%[^0-9]%', T_Items.Itm_No + 'z')-1)) ";
                    }
                    catch
                    {
                        _RepShow.Rule += " order by T_Items.Itm_No ";
                    }
                    if (!string.IsNullOrEmpty(Fields))
                    {
                        _RepShow.Fields = Fields;
                        _RepShow = _RepShow.Save();
                        VarGeneral.RepData = _RepShow.RepData;
                        if (VarGeneral.RepData.Tables[0].Rows.Count == 0)
                        {
                            return;
                        }
                        FMFind FmQuikSerch = new FMFind((string)FlxInv.GetData(FlxInv.Row, 1), 1);
                        FmQuikSerch.Tag = LangArEn;
                        FmQuikSerch.TopMost = true;
                        FmQuikSerch.ShowDialog();
                        _SearchNo = FmQuikSerch.SerachNo;
                    }
                    if (!(_SearchNo != ""))
                    {
                        try
                        {
                            FlxInv.RemoveItem(FlxInv.Row);
                            try
                            {
                                FlxInv.Rows.Add();
                            }
                            catch
                            {
                            }
                            FlxInv.Row = FlxInv.RowSel;
                            FlxInv.Col = 1;
                        }
                        catch
                        {
                        }
                        return;
                    }
                    listSer = db.StockItemList(_SearchNo);
                    _Items = listSer[0];
                }
                else
                {
                    List<T_Item> q = (from t in db.T_Items
                                      where t.ItmTyp != (int?)1 && !t.InvSaleStoped.Value
                                      orderby t.Itm_No
                                      select t).ToList();
                    if (q.Count == 0)
                    {
                        return;
                    }
                    FrmSearch FmSerch = new FrmSearch();
                    VarGeneral.SFrmTyp = "T_InvGrid";
                    VarGeneral.vItmTyp = 1;
                    FmSerch.Tag = LangArEn;
                    VarGeneral.itmDes = (string)FlxInv.GetData(FlxInv.Row, 1);
                    VarGeneral.itmDesIndex = 1;
                    ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible2;
                    foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
                    {
                        FmSerch.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, ""));
                    }
                    FmSerch.TopMost = true;
                    FmSerch.ShowDialog();
                    VarGeneral.itmDesIndex = 0;
                    VarGeneral.itmDes = "";
                    if (!(FmSerch.SerachNo != ""))
                    {
                        try
                        {
                            FlxInv.RemoveItem(FlxInv.Row);
                            try
                            {
                                FlxInv.Rows.Add();
                            }
                            catch
                            {
                            }
                            FlxInv.Row = FlxInv.RowSel;
                            FlxInv.Col = 1;
                        }
                        catch
                        {
                        }
                        return;
                    }
                    listSer = db.StockItemList(FmSerch.SerachNo);
                    _Items = listSer[0];
                }
            }
            double ItmDis = 0.0;
            FlxInv.SetData(FlxInv.Row, 1, _Items.Itm_No.Trim());
            FlxInv.SetData(FlxInv.Row, 2, _Items.Arb_Des.Trim());
            FlxInv.SetData(FlxInv.Row, 4, _Items.Eng_Des.Trim());
            string CoA = "";
            string CoE = "";
            string DefUnitA = "";
            string DefUnitE = "";
            for (int iiCnt = 0; iiCnt < listUnit.Count; iiCnt++)
            {
                _Unit = listUnit[iiCnt];
                if (_Items.Unit1 == _Unit.Unit_ID)
                {
                    if (CoA != "")
                    {
                        CoA += "|";
                        CoE += "|";
                    }
                    CoA += _Unit.Arb_Des;
                    CoE += _Unit.Eng_Des;
                    if (_Items.DefultUnit == 1 && DefPack == 0)
                    {
                        Pack = _Items.Pack1.Value;
                        DefUnitA = _Unit.Arb_Des;
                        DefUnitE = _Unit.Eng_Des;
                        FlxInv.SetData(FlxInv.Row, 6, _Items.UntPri1.Value);
                    }
                    else if (DefPack == 1)
                    {
                        Pack = _Items.Pack1.Value;
                        DefUnitA = _Unit.Arb_Des;
                        DefUnitE = _Unit.Eng_Des;
                        FlxInv.SetData(FlxInv.Row, 6, _Items.UntPri1.Value);
                    }
                    break;
                }
            }
            for (int iiCnt = 0; iiCnt < listUnit.Count; iiCnt++)
            {
                _Unit = listUnit[iiCnt];
                if (_Items.Unit2 == _Unit.Unit_ID)
                {
                    if (CoA != "")
                    {
                        CoA += "|";
                        CoE += "|";
                    }
                    CoA += _Unit.Arb_Des;
                    CoE += _Unit.Arb_Des;
                    if (_Items.DefultUnit == 2 && DefPack == 0)
                    {
                        Pack = _Items.Pack2.Value;
                        DefUnitA = _Unit.Arb_Des;
                        DefUnitE = _Unit.Eng_Des;
                        FlxInv.SetData(FlxInv.Row, 6, _Items.UntPri2.Value);
                    }
                    else if (DefPack == 2)
                    {
                        Pack = _Items.Pack2.Value;
                        DefUnitA = _Unit.Arb_Des;
                        DefUnitE = _Unit.Eng_Des;
                        FlxInv.SetData(FlxInv.Row, 6, _Items.UntPri2.Value);
                    }
                    break;
                }
            }
            for (int iiCnt = 0; iiCnt < listUnit.Count; iiCnt++)
            {
                _Unit = listUnit[iiCnt];
                if (_Items.Unit3 == _Unit.Unit_ID)
                {
                    if (CoA != "")
                    {
                        CoA += "|";
                        CoE += "|";
                    }
                    CoA += _Unit.Arb_Des;
                    CoE += _Unit.Eng_Des;
                    if (_Items.DefultUnit == 3 && DefPack == 0)
                    {
                        Pack = _Items.Pack3.Value;
                        DefUnitA = _Unit.Arb_Des;
                        DefUnitE = _Unit.Eng_Des;
                        FlxInv.SetData(FlxInv.Row, 6, _Items.UntPri3.Value);
                    }
                    else if (DefPack == 3)
                    {
                        Pack = _Items.Pack3.Value;
                        DefUnitA = _Unit.Arb_Des;
                        DefUnitE = _Unit.Eng_Des;
                        FlxInv.SetData(FlxInv.Row, 6, _Items.UntPri3.Value);
                    }
                    break;
                }
            }
            for (int iiCnt = 0; iiCnt < listUnit.Count; iiCnt++)
            {
                _Unit = listUnit[iiCnt];
                if (_Items.Unit4 == _Unit.Unit_ID)
                {
                    if (CoA != "")
                    {
                        CoA += "|";
                        CoE += "|";
                    }
                    CoA += _Unit.Arb_Des;
                    CoE += _Unit.Eng_Des;
                    if (_Items.DefultUnit == 4 && DefPack == 0)
                    {
                        Pack = _Items.Pack4.Value;
                        DefUnitA = _Unit.Arb_Des;
                        DefUnitE = _Unit.Eng_Des;
                        FlxInv.SetData(FlxInv.Row, 6, _Items.UntPri4.Value);
                    }
                    else if (DefPack == 4)
                    {
                        Pack = _Items.Pack4.Value;
                        DefUnitA = _Unit.Arb_Des;
                        DefUnitE = _Unit.Eng_Des;
                        FlxInv.SetData(FlxInv.Row, 6, _Items.UntPri4.Value);
                    }
                    break;
                }
            }
            for (int iiCnt = 0; iiCnt < listUnit.Count; iiCnt++)
            {
                _Unit = listUnit[iiCnt];
                if (_Items.Unit5 == _Unit.Unit_ID)
                {
                    if (CoA != "")
                    {
                        CoA += "|";
                        CoE += "|";
                    }
                    CoA += _Unit.Arb_Des;
                    CoE += _Unit.Eng_Des;
                    if (_Items.DefultUnit == 5 && DefPack == 0)
                    {
                        Pack = _Items.Pack5.Value;
                        DefUnitA = _Unit.Arb_Des;
                        DefUnitE = _Unit.Eng_Des;
                        FlxInv.SetData(FlxInv.Row, 6, _Items.UntPri5.Value);
                    }
                    else if (DefPack == 5)
                    {
                        Pack = _Items.Pack5.Value;
                        DefUnitA = _Unit.Arb_Des;
                        DefUnitE = _Unit.Eng_Des;
                        FlxInv.SetData(FlxInv.Row, 6, _Items.UntPri5.Value);
                    }
                    break;
                }
            }
            FlxInv.Cols[3].ComboList = CoA;
            FlxInv.Cols[5].ComboList = CoE;
            FlxInv.SetData(FlxInv.Row, 3, DefUnitA);
            FlxInv.SetData(FlxInv.Row, 5, DefUnitE);
            BindDataofItemPrice();
            FlxInv.SetData(FlxInv.Row, 6, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.Row, 6)))));
            FlxInv.SetData(FlxInv.Row, 7, 0);
            FlxInv.SetData(FlxInv.Row, 8, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.Row, 6)))) - (checkBox_DisVal.Checked ? double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.Row, 7)))) : ItmDis));
            FlxInv.SetData(FlxInv.Row, 9, 1);
            FlxInv.SetData(FlxInv.Row, 10, 0);
            FillLines();
        }
        private void BindDataofItemPrice()
        {
            if (CmbInvPrice.SelectedIndex == 1 && _Items.Price1.HasValue)
            {
                FlxInv.SetData(FlxInv.Row, 6, _Items.Price1.Value / _Items.DefPack.Value * Pack);
            }
            else if (CmbInvPrice.SelectedIndex == 2 && _Items.Price2.HasValue)
            {
                FlxInv.SetData(FlxInv.Row, 6, _Items.Price2.Value / _Items.DefPack.Value * Pack);
            }
            else if (CmbInvPrice.SelectedIndex == 3 && _Items.Price3.HasValue)
            {
                FlxInv.SetData(FlxInv.Row, 6, _Items.Price3.Value / _Items.DefPack.Value * Pack);
            }
            else if (CmbInvPrice.SelectedIndex == 4 && _Items.Price4.HasValue)
            {
                FlxInv.SetData(FlxInv.Row, 6, _Items.Price4.Value / _Items.DefPack.Value * Pack);
            }
            else if (CmbInvPrice.SelectedIndex == 5 && _Items.Price5.HasValue)
            {
                FlxInv.SetData(FlxInv.Row, 6, _Items.Price5.Value / _Items.DefPack.Value * Pack);
            }
        }
        private void FlxInvDet_BeforeEdit(object sender, RowColEventArgs e)
        {
            try
            {
                if ((e.Col == 3 || e.Col == 5) && FlxInvDet.GetData(e.Row, e.Col) != null)
                {
                    oldUnitDet = FlxInvDet.GetData(e.Row, 3).ToString() ?? "";
                }
            }
            catch
            {
            }
        }
        private void FlxInvDet_AfterEdit(object sender, RowColEventArgs e)
        {
            try
            {
                if (int.Parse(FlxInvDet.GetData(FlxInvDet.Row, 16).ToString()) <= 0)
                {
                    FlxInvDet.SetData(e.Row, 1, "");
                    FlxInvDet.SetData(e.Row, 2, "");
                    FlxInvDet.SetData(e.Row, 3, "");
                    FlxInvDet.SetData(e.Row, 4, "");
                    FlxInvDet.SetData(e.Row, 5, "");
                    FlxInvDet.SetData(e.Row, 7, 0);
                    FlxInvDet.SetData(e.Row, 8, 0);
                    FlxInvDet.SetData(e.Row, 9, 0);
                    FlxInvDet.SetData(e.Row, 10, 0);
                    FlxInvDet.SetData(e.Row, 11, 0);
                    FlxInvDet.SetData(e.Row, 12, "");
                    FlxInvDet.SetData(e.Row, 13, "");
                    FlxInvDet.SetData(e.Row, 14, "");
                    FlxInvDet.SetData(e.Row, 15, "");
                    return;
                }
            }
            catch
            {
                FlxInvDet.SetData(e.Row, 1, "");
                FlxInvDet.SetData(e.Row, 2, "");
                FlxInvDet.SetData(e.Row, 3, "");
                FlxInvDet.SetData(e.Row, 4, "");
                FlxInvDet.SetData(e.Row, 5, "");
                FlxInvDet.SetData(e.Row, 7, 0);
                FlxInvDet.SetData(e.Row, 8, 0);
                FlxInvDet.SetData(e.Row, 9, 0);
                FlxInvDet.SetData(e.Row, 10, 0);
                FlxInvDet.SetData(e.Row, 11, 0);
                FlxInvDet.SetData(e.Row, 12, "");
                FlxInvDet.SetData(e.Row, 13, "");
                FlxInvDet.SetData(e.Row, 14, "");
                FlxInvDet.SetData(e.Row, 15, "");
                return;
            }
            if (e.Col == 16)
            {
                try
                {
                    int c = int.Parse(FlxInvDet.GetData(e.Row, 16).ToString());
                    FlxInvDet.SetData(e.Row, 12, FlxInv.GetData(c, 1));
                    FlxInvDet.SetData(e.Row, 13, FlxInv.GetData(c, 3));
                }
                catch
                {
                    FlxInvDet.SetData(e.Row, 1, "");
                    FlxInvDet.SetData(e.Row, 2, "");
                    FlxInvDet.SetData(e.Row, 3, "");
                    FlxInvDet.SetData(e.Row, 4, "");
                    FlxInvDet.SetData(e.Row, 5, "");
                    FlxInvDet.SetData(e.Row, 7, 0);
                    FlxInvDet.SetData(e.Row, 8, 0);
                    FlxInvDet.SetData(e.Row, 9, 0);
                    FlxInvDet.SetData(e.Row, 10, 0);
                    FlxInvDet.SetData(e.Row, 11, 0);
                    FlxInvDet.SetData(e.Row, 12, "");
                    FlxInvDet.SetData(e.Row, 13, "");
                    FlxInvDet.SetData(e.Row, 14, "");
                    FlxInvDet.SetData(e.Row, 15, "");
                }
                return;
            }
            double ItmDis = 0.0;
            try
            {
                if (checkBox_DisRate.Checked && double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInvDet.GetData(e.Row, 8)))) > 0.0)
                {
                    ItmDis = double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInvDet.GetData(e.Row, 7)))) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInvDet.GetData(e.Row, 8)))) / 100.0);
                }
            }
            catch
            {
            }
            if (e.Col == 1)
            {
                BindDataOfItemDet();
            }
            else if (((e.Col == 2 || e.Col == 4) && (string)FlxInvDet.GetData(e.Row, 1) == "") || FlxInvDet.GetData(e.Row, 1) == null)
            {
                BindDataOfItemDet();
            }
            else if ((e.Col == 3 || e.Col == 5) && FlxInvDet.GetData(e.Row, e.Col).ToString() != oldUnitDet)
            {
                int ItemIndex = -1;
                if (e.Col == 3)
                {
                    string[] Items = FlxInvDet.Cols[e.Col].ComboList.Split('|');
                    for (int i = 0; i < Items.Length; i++)
                    {
                        if (Items[i] == FlxInvDet.GetData(e.Row, e.Col).ToString())
                        {
                            ItemIndex = i + 1;
                        }
                    }
                    string[] Items2 = FlxInvDet.Cols[5].ComboList.Split('|');
                    if (Items2.Length > 1 && ItemIndex > -1)
                    {
                        FlxInvDet.SetData(e.Row, 5, Items2[ItemIndex - 1]);
                    }
                }
                else if (e.Col == 5)
                {
                    string[] Items = FlxInvDet.Cols[e.Col].ComboList.Split('|');
                    for (int i = 0; i < Items.Length; i++)
                    {
                        if (Items[i] == FlxInvDet.GetData(e.Row, e.Col).ToString())
                        {
                            ItemIndex = i + 1;
                        }
                    }
                    string[] Items2 = FlxInvDet.Cols[3].ComboList.Split('|');
                    if (Items2.Length > 1 && ItemIndex > -1)
                    {
                        FlxInvDet.SetData(e.Row, 3, Items2[ItemIndex - 1]);
                    }
                }
                switch (ItemIndex)
                {
                    case 1:
                        FlxInvDet.SetData(FlxInvDet.Row, 7, _Items.UntPri1);
                        break;
                    case 2:
                        FlxInvDet.SetData(FlxInvDet.Row, 7, _Items.UntPri2);
                        break;
                    case 3:
                        FlxInvDet.SetData(FlxInvDet.Row, 7, _Items.UntPri3);
                        break;
                    case 4:
                        FlxInvDet.SetData(FlxInvDet.Row, 7, _Items.UntPri4);
                        break;
                    case 5:
                        FlxInvDet.SetData(FlxInvDet.Row, 7, _Items.UntPri5);
                        break;
                }
                PackDet = ItemIndex;
                BindDataofItemPriceDet();
                FlxInvDet.SetData(e.Row, 9, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInvDet.GetData(e.Row, 7)))) - (checkBox_DisVal.Checked ? double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInvDet.GetData(e.Row, 8)))) : ItmDis));
            }
            else if (e.Col == 6)
            {
                listStkQty = (from t in db.T_STKSQTies
                              where t.itmNo == FlxInvDet.GetData(e.Row, 1).ToString()
                              where t.storeNo == (int?)int.Parse(FlxInvDet.GetData(e.Row, 6).ToString())
                              select t).ToList();
                FlxInvDet.SetData(e.Row, 14, "");
                FlxInvDet.SetData(e.Row, 15, "");
                try
                {
                    FlxDat.Clear(ClearFlags.Content, 1, 0, FlxDat.Rows.Count - 1, 1);
                    listQtyExp = (from t in db.T_QTYEXPs
                                  orderby t.DatExper
                                  where t.itmNo == FlxInvDet.GetData(e.Row, 1).ToString()
                                  where t.storeNo == (int?)int.Parse(FlxInvDet.GetData(e.Row, 6).ToString())
                                  select t).ToList();
                    if (listQtyExp.Count != 0)
                    {
                        for (int iiCnt = 0; iiCnt < listQtyExp.Count; iiCnt++)
                        {
                            _QtyExp = listQtyExp[iiCnt];
                            FlxDat.Rows.Count = iiCnt + 2;
                            FlxDat.SetData(iiCnt + 1, 0, _QtyExp.DatExper.ToString());
                            FlxDat.SetData(iiCnt + 1, 1, _QtyExp.stkQty.Value.ToString());
                            FlxDat.SetData(iiCnt + 1, 2, _QtyExp.RunCod.ToString());
                        }
                        FlxDat.Visible = true;
                        FlxDat.Focus();
                    }
                    else
                    {
                        FlxDat.Visible = false;
                    }
                }
                catch
                {
                    FlxDat.Visible = false;
                }
            }
            else if (e.Col == 8)
            {
                FlxInvDet.SetData(e.Row, 9, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInvDet.GetData(e.Row, 7)))) - (checkBox_DisVal.Checked ? double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInvDet.GetData(e.Row, 8)))) : ItmDis));
            }
        }
        private void BindDataOfItemDet()
        {
            if (!base.Visible)
            {
                return;
            }
            columns_Names_visible2.Clear();
            columns_Names_visible2.Add("Itm_No", new ColumnDictinary("رقم الصنف", "Item No", ifDefault: true, ""));
            columns_Names_visible2.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, ""));
            columns_Names_visible2.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: false, ""));
            columns_Names_visible2.Add("StartCost", new ColumnDictinary("التكلفةالافتتاحية", "Start Cost", ifDefault: false, ""));
            columns_Names_visible2.Add("AvrageCost", new ColumnDictinary("متوسط التكلفة", "Average Cost", ifDefault: false, ""));
            columns_Names_visible2.Add("LastCost", new ColumnDictinary("آخر تكلفة", "Last Cost", ifDefault: false, ""));
            columns_Names_visible2.Add("Arb_Des_Cat", new ColumnDictinary("الاسم العربي لمجموعة الصنف", "CATEGORY Arabic Name", ifDefault: false, ""));
            columns_Names_visible2.Add("Eng_Des_Cat", new ColumnDictinary("الاسم الانجليزي لمجموعة الصنف", "CATEGORY English Name", ifDefault: false, ""));
            List<T_Item> listSer = new List<T_Item>();
            bool Barcod = false;
            if ((string)FlxInvDet.GetData(FlxInvDet.Row, 1) != "" && FlxInvDet.GetData(FlxInvDet.Row, 1) != null)
            {
                Barcod = ChkBarCod((string)FlxInvDet.GetData(FlxInvDet.Row, 1));
                if (!Barcod || (VarGeneral.SSSLev != "D" && VarGeneral.SSSLev != "G" && VarGeneral.SSSLev != "S" && VarGeneral.SSSLev != "B" && VarGeneral.SSSLev != "F" && VarGeneral.SSSLev != "C" && VarGeneral.SSSLev != "R" && VarGeneral.SSSLev != "H" && VarGeneral.SSSLev != "M"))
                {
                    listSer = db.StockItemList(FlxInvDet.GetData(FlxInvDet.Row, 1).ToString());
                    if (listSer.Count != 0)
                    {
                        _Items = listSer[0];
                    }
                }
            }
            else if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 30))
            {
                string _SearchNo = "";
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_Items ";
                string Fields = "";
                Fields = ((LangArEn != 0) ? " T_Items.Itm_No as [ID Number], T_Items.Itm_No as [Item No] , T_Items.Arb_Des as [Arabic Description], T_Items.Eng_Des as [English Description] , T_Items.OpenQty as [Quantity]  " : " T_Items.Itm_No as [رقم التعريف], T_Items.Itm_No as [رقــم الصنــــف] , T_Items.Arb_Des as [الوصــف العربـــي], T_Items.Eng_Des as [الوصــف إنجلـــيزي] , T_Items.OpenQty as [الكمية] ");
                _RepShow.Rule = " Where 1 = 1 and T_Items.ItmTyp != 1 and InvSaleStoped = 0 ";
                try
                {
                    db.ExecuteCommand("select " + Fields + " From " + _RepShow.Tables + _RepShow.Rule + " order by  CONVERT(INT, LEFT(T_Items.Itm_No, PATINDEX('%[^0-9]%', T_Items.Itm_No + 'z')-1)) ");
                    _RepShow.Rule += " order by  CONVERT(INT, LEFT(T_Items.Itm_No, PATINDEX('%[^0-9]%', T_Items.Itm_No + 'z')-1)) ";
                }
                catch
                {
                    _RepShow.Rule += " order by T_Items.Itm_No ";
                }
                if (!string.IsNullOrEmpty(Fields))
                {
                    _RepShow.Fields = Fields;
                    _RepShow = _RepShow.Save();
                    VarGeneral.RepData = _RepShow.RepData;
                    if (VarGeneral.RepData.Tables[0].Rows.Count == 0)
                    {
                        return;
                    }
                    string ItmDes = "";
                    int ItmDesIndex = 1;
                    if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                    {
                        if ((string)FlxInvDet.GetData(FlxInvDet.Row, 2) != "" && FlxInvDet.GetData(FlxInvDet.Row, 2) != null)
                        {
                            ItmDes = (string)FlxInvDet.GetData(FlxInvDet.Row, 2);
                            ItmDesIndex = 2;
                        }
                    }
                    else if ((string)FlxInvDet.GetData(FlxInvDet.Row, 4) != "" && FlxInvDet.GetData(FlxInvDet.Row, 4) != null)
                    {
                        ItmDes = (string)FlxInvDet.GetData(FlxInvDet.Row, 4);
                        ItmDesIndex = 3;
                    }
                    FMFind FmQuikSerch = new FMFind(ItmDes, ItmDesIndex);
                    FmQuikSerch.Tag = LangArEn;
                    FmQuikSerch.TopMost = true;
                    FmQuikSerch.ShowDialog();
                    _SearchNo = FmQuikSerch.SerachNo;
                }
                if (!(_SearchNo != ""))
                {
                    try
                    {
                        FlxInvDet.RemoveItem(FlxInvDet.Row);
                        try
                        {
                            FlxInvDet.Rows.Add();
                        }
                        catch
                        {
                        }
                        FlxInvDet.Row = FlxInvDet.RowSel;
                        FlxInvDet.Col = 1;
                    }
                    catch
                    {
                    }
                    return;
                }
                listSer = db.StockItemList(_SearchNo);
                _Items = listSer[0];
            }
            else
            {
                List<T_Item> q = (from t in db.T_Items
                                  where t.ItmTyp != (int?)1 && !t.InvSaleStoped.Value
                                  orderby t.Itm_No
                                  select t).ToList();
                if (q.Count == 0)
                {
                    return;
                }
                string ItmDes = "";
                int ItmDesIndex = 1;
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                {
                    if ((string)FlxInvDet.GetData(FlxInvDet.Row, 2) != "" && FlxInvDet.GetData(FlxInvDet.Row, 2) != null)
                    {
                        ItmDes = (string)FlxInvDet.GetData(FlxInvDet.Row, 2);
                        ItmDesIndex = 2;
                    }
                }
                else if ((string)FlxInvDet.GetData(FlxInvDet.Row, 4) != "" && FlxInvDet.GetData(FlxInvDet.Row, 4) != null)
                {
                    ItmDes = (string)FlxInvDet.GetData(FlxInvDet.Row, 4);
                    ItmDesIndex = 3;
                }
                FrmSearch FmSerch = new FrmSearch();
                VarGeneral.SFrmTyp = "T_InvGrid";
                VarGeneral.vItmTyp = 1;
                FmSerch.Tag = LangArEn;
                VarGeneral.itmDes = ItmDes;
                VarGeneral.itmDesIndex = ItmDesIndex;
                ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible2;
                foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
                {
                    FmSerch.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, ""));
                }
                FmSerch.TopMost = true;
                FmSerch.ShowDialog();
                VarGeneral.itmDesIndex = 0;
                VarGeneral.itmDes = "";
                if (!(FmSerch.SerachNo != ""))
                {
                    try
                    {
                        FlxInvDet.RemoveItem(FlxInvDet.Row);
                        try
                        {
                            FlxInvDet.Rows.Add();
                        }
                        catch
                        {
                        }
                        FlxInvDet.Row = FlxInvDet.RowSel;
                        FlxInvDet.Col = 1;
                    }
                    catch
                    {
                    }
                    return;
                }
                listSer = db.StockItemList(FmSerch.SerachNo);
                _Items = listSer[0];
            }
            if ((!Barcod || (VarGeneral.SSSLev != "D" && VarGeneral.SSSLev != "G" && VarGeneral.SSSLev != "S" && VarGeneral.SSSLev != "B" && VarGeneral.SSSLev != "F" && VarGeneral.SSSLev != "C" && VarGeneral.SSSLev != "R" && VarGeneral.SSSLev != "H" && VarGeneral.SSSLev != "M")) && listSer.Count == 0)
            {
                if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 30))
                {
                    string _SearchNo = "";
                    RepShow _RepShow = new RepShow();
                    _RepShow.Tables = " T_Items ";
                    string Fields = "";
                    Fields = ((LangArEn != 0) ? " T_Items.Itm_No as [ID Number], T_Items.Itm_No as [Item No] , T_Items.Arb_Des as [Arabic Description], T_Items.Eng_Des as [English Description] , T_Items.OpenQty as [Quantity]  " : " T_Items.Itm_No as [رقم التعريف], T_Items.Itm_No as [رقــم الصنــــف] , T_Items.Arb_Des as [الوصــف العربـــي], T_Items.Eng_Des as [الوصــف إنجلـــيزي] , T_Items.OpenQty as [الكمية] ");
                    _RepShow.Rule = " Where 1 = 1 and T_Items.ItmTyp != 1 and InvSaleStoped = 0";
                    try
                    {
                        db.ExecuteCommand("select " + Fields + " From " + _RepShow.Tables + _RepShow.Rule + " order by  CONVERT(INT, LEFT(T_Items.Itm_No, PATINDEX('%[^0-9]%', T_Items.Itm_No + 'z')-1)) ");
                        _RepShow.Rule += " order by  CONVERT(INT, LEFT(T_Items.Itm_No, PATINDEX('%[^0-9]%', T_Items.Itm_No + 'z')-1)) ";
                    }
                    catch
                    {
                        _RepShow.Rule += " order by T_Items.Itm_No ";
                    }
                    if (!string.IsNullOrEmpty(Fields))
                    {
                        _RepShow.Fields = Fields;
                        _RepShow = _RepShow.Save();
                        VarGeneral.RepData = _RepShow.RepData;
                        if (VarGeneral.RepData.Tables[0].Rows.Count == 0)
                        {
                            return;
                        }
                        FMFind FmQuikSerch = new FMFind((string)FlxInvDet.GetData(FlxInvDet.Row, 1), 1);
                        FmQuikSerch.Tag = LangArEn;
                        FmQuikSerch.TopMost = true;
                        FmQuikSerch.ShowDialog();
                        _SearchNo = FmQuikSerch.SerachNo;
                    }
                    if (!(_SearchNo != ""))
                    {
                        try
                        {
                            FlxInvDet.RemoveItem(FlxInvDet.Row);
                            try
                            {
                                FlxInvDet.Rows.Add();
                            }
                            catch
                            {
                            }
                            FlxInvDet.Row = FlxInvDet.RowSel;
                            FlxInvDet.Col = 1;
                        }
                        catch
                        {
                        }
                        return;
                    }
                    listSer = db.StockItemList(_SearchNo);
                    _Items = listSer[0];
                }
                else
                {
                    List<T_Item> q = (from t in db.T_Items
                                      where t.ItmTyp != (int?)1 && !t.InvSaleStoped.Value
                                      orderby t.Itm_No
                                      select t).ToList();
                    if (q.Count == 0)
                    {
                        return;
                    }
                    FrmSearch FmSerch = new FrmSearch();
                    VarGeneral.SFrmTyp = "T_InvGrid";
                    VarGeneral.vItmTyp = 1;
                    FmSerch.Tag = LangArEn;
                    VarGeneral.itmDes = (string)FlxInvDet.GetData(FlxInvDet.Row, 1);
                    VarGeneral.itmDesIndex = 1;
                    ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible2;
                    foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
                    {
                        FmSerch.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, ""));
                    }
                    FmSerch.TopMost = true;
                    FmSerch.ShowDialog();
                    VarGeneral.itmDesIndex = 0;
                    VarGeneral.itmDes = "";
                    if (!(FmSerch.SerachNo != ""))
                    {
                        try
                        {
                            FlxInvDet.RemoveItem(FlxInvDet.Row);
                            try
                            {
                                FlxInvDet.Rows.Add();
                            }
                            catch
                            {
                            }
                            FlxInvDet.Row = FlxInvDet.RowSel;
                            FlxInvDet.Col = 1;
                        }
                        catch
                        {
                        }
                        return;
                    }
                    listSer = db.StockItemList(FmSerch.SerachNo);
                    _Items = listSer[0];
                }
            }
            double ItmDis = 0.0;
            FlxInvDet.SetData(FlxInvDet.Row, 1, _Items.Itm_No.Trim());
            FlxInvDet.SetData(FlxInvDet.Row, 2, _Items.Arb_Des.Trim());
            FlxInvDet.SetData(FlxInvDet.Row, 4, _Items.Eng_Des.Trim());
            FlxInvDet.SetData(FlxInvDet.Row, 6, 1);
            try
            {
                if (permission.DefStores.HasValue && permission.DefStores.Value > 0)
                {
                    FlxInvDet.SetData(FlxInvDet.Row, 6, permission.DefStores.Value);
                }
            }
            catch
            {
                FlxInvDet.SetData(FlxInvDet.Row, 6, 1);
            }
            FlxInvDet.SetData(FlxInvDet.Row, 14, "");
            FlxInvDet.SetData(FlxInvDet.Row, 15, "");
            string CoA = "";
            string CoE = "";
            string DefUnitA = "";
            string DefUnitE = "";
            for (int iiCnt = 0; iiCnt < listUnit.Count; iiCnt++)
            {
                _Unit = listUnit[iiCnt];
                if (_Items.Unit1 == _Unit.Unit_ID)
                {
                    if (CoA != "")
                    {
                        CoA += "|";
                        CoE += "|";
                    }
                    CoA += _Unit.Arb_Des;
                    CoE += _Unit.Eng_Des;
                    if (_Items.DefultUnit == 1 && DefPack == 0)
                    {
                        PackDet = _Items.Pack1.Value;
                        DefUnitA = _Unit.Arb_Des;
                        DefUnitE = _Unit.Eng_Des;
                        FlxInvDet.SetData(FlxInvDet.Row, 7, _Items.UntPri1.Value);
                    }
                    else if (DefPack == 1)
                    {
                        PackDet = _Items.Pack1.Value;
                        DefUnitA = _Unit.Arb_Des;
                        DefUnitE = _Unit.Eng_Des;
                        FlxInvDet.SetData(FlxInvDet.Row, 7, _Items.UntPri1.Value);
                    }
                    break;
                }
            }
            for (int iiCnt = 0; iiCnt < listUnit.Count; iiCnt++)
            {
                _Unit = listUnit[iiCnt];
                if (_Items.Unit2 == _Unit.Unit_ID)
                {
                    if (CoA != "")
                    {
                        CoA += "|";
                        CoE += "|";
                    }
                    CoA += _Unit.Arb_Des;
                    CoE += _Unit.Arb_Des;
                    if (_Items.DefultUnit == 2 && DefPack == 0)
                    {
                        PackDet = _Items.Pack2.Value;
                        DefUnitA = _Unit.Arb_Des;
                        DefUnitE = _Unit.Eng_Des;
                        FlxInvDet.SetData(FlxInvDet.Row, 7, _Items.UntPri2.Value);
                    }
                    else if (DefPack == 2)
                    {
                        PackDet = _Items.Pack2.Value;
                        DefUnitA = _Unit.Arb_Des;
                        DefUnitE = _Unit.Eng_Des;
                        FlxInvDet.SetData(FlxInvDet.Row, 7, _Items.UntPri2.Value);
                    }
                    break;
                }
            }
            for (int iiCnt = 0; iiCnt < listUnit.Count; iiCnt++)
            {
                _Unit = listUnit[iiCnt];
                if (_Items.Unit3 == _Unit.Unit_ID)
                {
                    if (CoA != "")
                    {
                        CoA += "|";
                        CoE += "|";
                    }
                    CoA += _Unit.Arb_Des;
                    CoE += _Unit.Eng_Des;
                    if (_Items.DefultUnit == 3 && DefPack == 0)
                    {
                        PackDet = _Items.Pack3.Value;
                        DefUnitA = _Unit.Arb_Des;
                        DefUnitE = _Unit.Eng_Des;
                        FlxInvDet.SetData(FlxInvDet.Row, 7, _Items.UntPri3.Value);
                    }
                    else if (DefPack == 3)
                    {
                        PackDet = _Items.Pack3.Value;
                        DefUnitA = _Unit.Arb_Des;
                        DefUnitE = _Unit.Eng_Des;
                        FlxInvDet.SetData(FlxInvDet.Row, 7, _Items.UntPri3.Value);
                    }
                    break;
                }
            }
            for (int iiCnt = 0; iiCnt < listUnit.Count; iiCnt++)
            {
                _Unit = listUnit[iiCnt];
                if (_Items.Unit4 == _Unit.Unit_ID)
                {
                    if (CoA != "")
                    {
                        CoA += "|";
                        CoE += "|";
                    }
                    CoA += _Unit.Arb_Des;
                    CoE += _Unit.Eng_Des;
                    if (_Items.DefultUnit == 4 && DefPack == 0)
                    {
                        PackDet = _Items.Pack4.Value;
                        DefUnitA = _Unit.Arb_Des;
                        DefUnitE = _Unit.Eng_Des;
                        FlxInvDet.SetData(FlxInvDet.Row, 7, _Items.UntPri4.Value);
                    }
                    else if (DefPack == 4)
                    {
                        PackDet = _Items.Pack4.Value;
                        DefUnitA = _Unit.Arb_Des;
                        DefUnitE = _Unit.Eng_Des;
                        FlxInvDet.SetData(FlxInvDet.Row, 7, _Items.UntPri4.Value);
                    }
                    break;
                }
            }
            for (int iiCnt = 0; iiCnt < listUnit.Count; iiCnt++)
            {
                _Unit = listUnit[iiCnt];
                if (_Items.Unit5 == _Unit.Unit_ID)
                {
                    if (CoA != "")
                    {
                        CoA += "|";
                        CoE += "|";
                    }
                    CoA += _Unit.Arb_Des;
                    CoE += _Unit.Eng_Des;
                    if (_Items.DefultUnit == 5 && DefPack == 0)
                    {
                        PackDet = _Items.Pack5.Value;
                        DefUnitA = _Unit.Arb_Des;
                        DefUnitE = _Unit.Eng_Des;
                        FlxInvDet.SetData(FlxInvDet.Row, 7, _Items.UntPri5.Value);
                    }
                    else if (DefPack == 5)
                    {
                        PackDet = _Items.Pack5.Value;
                        DefUnitA = _Unit.Arb_Des;
                        DefUnitE = _Unit.Eng_Des;
                        FlxInvDet.SetData(FlxInvDet.Row, 7, _Items.UntPri5.Value);
                    }
                    break;
                }
            }
            FlxInvDet.Cols[3].ComboList = CoA;
            FlxInvDet.Cols[5].ComboList = CoE;
            FlxInvDet.SetData(FlxInvDet.Row, 3, DefUnitA);
            FlxInvDet.SetData(FlxInvDet.Row, 5, DefUnitE);
            BindDataofItemPrice();
            FlxInvDet.SetData(FlxInvDet.Row, 7, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInvDet.GetData(FlxInvDet.Row, 7)))));
            FlxInvDet.SetData(FlxInvDet.Row, 8, 0);
            FlxInvDet.SetData(FlxInvDet.Row, 9, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInvDet.GetData(FlxInvDet.Row, 7)))) - (checkBox_DisVal.Checked ? double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInvDet.GetData(FlxInvDet.Row, 8)))) : ItmDis));
            FlxInvDet.SetData(FlxInvDet.Row, 10, 1);
            if (FlxInvDet.Cols[11].Visible)
            {
                FlxInvDet.SetData(FlxInvDet.Row, 11, VarGeneral.TString.ChkStatShow(_InvSetting.TaxOptions, 2) ? _Items.TaxPurchas : _Items.TaxSales);
            }
            else
            {
                FlxInvDet.SetData(FlxInvDet.Row, 11, 0);
            }
        }
        private void BindDataofItemPriceDet()
        {
            if (CmbInvPrice.SelectedIndex == 1 && _Items.Price1.HasValue)
            {
                FlxInvDet.SetData(FlxInvDet.Row, 7, _Items.Price1.Value / _Items.DefPack.Value * PackDet);
            }
            else if (CmbInvPrice.SelectedIndex == 2 && _Items.Price2.HasValue)
            {
                FlxInvDet.SetData(FlxInvDet.Row, 7, _Items.Price2.Value / _Items.DefPack.Value * PackDet);
            }
            else if (CmbInvPrice.SelectedIndex == 3 && _Items.Price3.HasValue)
            {
                FlxInvDet.SetData(FlxInvDet.Row, 7, _Items.Price3.Value / _Items.DefPack.Value * PackDet);
            }
            else if (CmbInvPrice.SelectedIndex == 4 && _Items.Price4.HasValue)
            {
                FlxInvDet.SetData(FlxInvDet.Row, 7, _Items.Price4.Value / _Items.DefPack.Value * PackDet);
            }
            else if (CmbInvPrice.SelectedIndex == 5 && _Items.Price5.HasValue)
            {
                FlxInvDet.SetData(FlxInvDet.Row, 7, _Items.Price5.Value / _Items.DefPack.Value * PackDet);
            }
        }
        private void FlxInvDet_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Delete)
            {
                return;
            }
            try
            {
                if (FlxInvDet.GetData(RowSel, 1).ToString() != null)
                {
                    FlxInvDet.RemoveItem(FlxInvDet.Row);
                }
            }
            catch
            {
                FlxInvDet.RemoveItem(FlxInvDet.Row);
            }
        }
        private void FlxInvDet_RowColChange(object sender, EventArgs e)
        {
            if (FlxInvDet.Col == 1)
            {
                Framework.Keyboard.Language.Switch("English");
            }
            if (FlxInvDet.Col == 2)
            {
                Framework.Keyboard.Language.Switch("Arabic");
            }
            if (FlxInvDet.Col == 4)
            {
                Framework.Keyboard.Language.Switch("English");
            }
        }
        private void FlxInvDet_SelChange(object sender, EventArgs e)
        {
            try
            {
                if (RowSel == 0 || RowSel == FlxInvDet.Row || FlxInvDet.Row <= 0 || !(string.Concat(FlxInvDet.GetData(FlxInvDet.Row, 1)) != ""))
                {
                    return;
                }
                List<T_Item> listSer = new List<T_Item>();
                listSer = db.StockItemList(string.Concat(FlxInvDet.GetData(FlxInvDet.RowSel, 1)));
                if (listSer.Count == 0)
                {
                    return;
                }
                _Items = listSer[0];
                string CoA = "";
                string CoE = "";
                for (int iiCnt = 0; iiCnt < listUnit.Count; iiCnt++)
                {
                    _Unit = listUnit[iiCnt];
                    if (_Items.Unit1 == _Unit.Unit_ID)
                    {
                        if (CoA != "")
                        {
                            CoA += "|";
                            CoE += "|";
                        }
                        CoA += _Unit.Arb_Des;
                        CoE += _Unit.Eng_Des;
                        break;
                    }
                }
                for (int iiCnt = 0; iiCnt < listUnit.Count; iiCnt++)
                {
                    _Unit = listUnit[iiCnt];
                    if (_Items.Unit2 == _Unit.Unit_ID)
                    {
                        if (CoA != "")
                        {
                            CoA += "|";
                            CoE += "|";
                        }
                        CoA += _Unit.Arb_Des;
                        CoE += _Unit.Eng_Des;
                        break;
                    }
                }
                for (int iiCnt = 0; iiCnt < listUnit.Count; iiCnt++)
                {
                    _Unit = listUnit[iiCnt];
                    if (_Items.Unit3 == _Unit.Unit_ID)
                    {
                        if (CoA != "")
                        {
                            CoA += "|";
                            CoE += "|";
                        }
                        CoA += _Unit.Arb_Des;
                        CoE += _Unit.Eng_Des;
                        break;
                    }
                }
                for (int iiCnt = 0; iiCnt < listUnit.Count; iiCnt++)
                {
                    _Unit = listUnit[iiCnt];
                    if (_Items.Unit4 == _Unit.Unit_ID)
                    {
                        if (CoA != "")
                        {
                            CoA += "|";
                            CoE += "|";
                        }
                        CoA += _Unit.Arb_Des;
                        CoE += _Unit.Eng_Des;
                        break;
                    }
                }
                for (int iiCnt = 0; iiCnt < listUnit.Count; iiCnt++)
                {
                    _Unit = listUnit[iiCnt];
                    if (_Items.Unit5 == _Unit.Unit_ID)
                    {
                        if (CoA != "")
                        {
                            CoA += "|";
                            CoE += "|";
                        }
                        CoA += _Unit.Arb_Des;
                        CoE += _Unit.Eng_Des;
                        break;
                    }
                }
                FlxInvDet.Cols[3].ComboList = CoA;
                FlxInvDet.Cols[5].ComboList = CoE;
            }
            catch
            {
            }
        }
        private void FlxInvDet_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                try
                {
                    if (string.Concat(FlxInvDet.GetData(FlxInvDet.RowSel, 1)) != "" && State != 0)
                    {
                        _Items = db.StockItem(string.Concat(FlxInvDet.GetData(FlxInvDet.RowSel, 1)));
                    }
                }
                catch
                {
                }
                if (string.Concat(FlxInvDet.GetData(FlxInvDet.RowSel, 1)) != "")
                {
                    _Items = db.StockItem(string.Concat(FlxInvDet.GetData(FlxInvDet.RowSel, 1)));
                    string CoA = "";
                    string CoE = "";
                    for (int iiCnt = 0; iiCnt < listUnit.Count; iiCnt++)
                    {
                        _Unit = listUnit[iiCnt];
                        if (_Items.Unit1 == _Unit.Unit_ID)
                        {
                            if (CoA != "")
                            {
                                CoA += "|";
                                CoE += "|";
                            }
                            CoA += _Unit.Arb_Des;
                            CoE += _Unit.Eng_Des;
                            break;
                        }
                    }
                    for (int iiCnt = 0; iiCnt < listUnit.Count; iiCnt++)
                    {
                        _Unit = listUnit[iiCnt];
                        if (_Items.Unit2 == _Unit.Unit_ID)
                        {
                            if (CoA != "")
                            {
                                CoA += "|";
                                CoE += "|";
                            }
                            CoA += _Unit.Arb_Des;
                            CoE += _Unit.Eng_Des;
                            break;
                        }
                    }
                    for (int iiCnt = 0; iiCnt < listUnit.Count; iiCnt++)
                    {
                        _Unit = listUnit[iiCnt];
                        if (_Items.Unit3 == _Unit.Unit_ID)
                        {
                            if (CoA != "")
                            {
                                CoA += "|";
                                CoE += "|";
                            }
                            CoA += _Unit.Arb_Des;
                            CoE += _Unit.Eng_Des;
                            break;
                        }
                    }
                    for (int iiCnt = 0; iiCnt < listUnit.Count; iiCnt++)
                    {
                        _Unit = listUnit[iiCnt];
                        if (_Items.Unit4 == _Unit.Unit_ID)
                        {
                            if (CoA != "")
                            {
                                CoA += "|";
                                CoE += "|";
                            }
                            CoA += _Unit.Arb_Des;
                            CoE += _Unit.Eng_Des;
                            break;
                        }
                    }
                    for (int iiCnt = 0; iiCnt < listUnit.Count; iiCnt++)
                    {
                        _Unit = listUnit[iiCnt];
                        if (_Items.Unit5 == _Unit.Unit_ID)
                        {
                            if (CoA != "")
                            {
                                CoA += "|";
                                CoE += "|";
                            }
                            CoA += _Unit.Arb_Des;
                            CoE += _Unit.Eng_Des;
                            break;
                        }
                    }
                    FlxInvDet.Cols[3].ComboList = CoA;
                    FlxInvDet.Cols[5].ComboList = CoE;
                }
            }
            catch
            {
            }
            FillLines();
        }
        private void FlxDat_DoubleClick(object sender, EventArgs e)
        {
            if (FlxDat.MouseRow > 0)
            {
                FlxInvDet.SetData(FlxInvDet.Row, 14, FlxDat.GetData(FlxDat.Row, 0));
                FlxInvDet.SetData(FlxInvDet.Row, 15, FlxDat.GetData(FlxDat.Row, 2));
                FlxDat.Visible = false;
                FlxInvDet.Col = 6;
                FlxInvDet.Focus();
            }
        }
        private void FlxDat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return && FlxDat.Row > 0)
            {
                FlxInvDet.SetData(FlxInvDet.Row, 14, FlxDat.GetData(FlxDat.Row, 0));
                FlxInvDet.SetData(FlxInvDet.Row, 15, FlxDat.GetData(FlxDat.Row, 2));
                FlxDat.Visible = false;
                FlxInvDet.Col = 6;
                FlxInvDet.Focus();
            }
        }
        private void FlxDat_Leave(object sender, EventArgs e)
        {
            if (FlxDat.Visible && State == FormState.New)
            {
                FlxDat.Focus();
            }
            else
            {
                FlxDat.Visible = false;
            }
        }
        private void switchButton_OfferTyp_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (switchButton_OfferTyp.Value)
                {
                    expandableSplitter2.Expanded = true;
                    VarGeneral.InvTyp = 1;
                }
                else
                {
                    expandableSplitter2.Expanded = false;
                    VarGeneral.InvTyp = 0;
                }
                textBox_ID.TextChanged -= textBox_ID_TextChanged;
                textBox_ID.Text = "";
                textBox_ID.TextChanged += textBox_ID_TextChanged;
                State = FormState.Saved;
                Clear();
                MainProcess();
            }
            catch
            {
            }
        }
        private void checkBox_Chash_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_DisVal.Checked)
            {
                FlxInv.Cols[7].Caption = ((LangArEn == 0) ? "قيمة الخصم" : "Dis Value");
                FlxInvDet.Cols[8].Caption = ((LangArEn == 0) ? "قيمة الخصم" : "Dis Value");
            }
            else
            {
                FlxInv.Cols[7].Caption = ((LangArEn == 0) ? "نسبة الخصم" : "Rate Value");
                FlxInvDet.Cols[8].Caption = ((LangArEn == 0) ? "نسبة الخصم" : "Rate Value");
            }
            try
            {
                for (int iiCnt = 1; iiCnt < FlxInv.Rows.Count; iiCnt++)
                {
                    try
                    {
                        if (!(string.Concat(FlxInv.GetData(iiCnt, 1)) != ""))
                        {
                            continue;
                        }
                        double ItmDis = 0.0;
                        try
                        {
                            if (checkBox_DisRate.Checked && double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 7)))) > 0.0)
                            {
                                ItmDis = double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 6)))) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 7)))) / 100.0);
                            }
                        }
                        catch
                        {
                        }
                        FlxInv.SetData(iiCnt, 8, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 6)))) - (checkBox_DisVal.Checked ? double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 7)))) : ItmDis));
                    }
                    catch
                    {
                    }
                }
            }
            catch
            {
            }
            try
            {
                for (int iiCnt = 1; iiCnt < FlxInvDet.Rows.Count; iiCnt++)
                {
                    try
                    {
                        if (!(string.Concat(FlxInvDet.GetData(iiCnt, 1)) != ""))
                        {
                            continue;
                        }
                        double ItmDis = 0.0;
                        try
                        {
                            if (checkBox_DisRate.Checked && double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInvDet.GetData(iiCnt, 8)))) > 0.0)
                            {
                                ItmDis = double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInvDet.GetData(iiCnt, 7)))) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInvDet.GetData(iiCnt, 8)))) / 100.0);
                            }
                        }
                        catch
                        {
                        }
                        FlxInvDet.SetData(iiCnt, 9, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInvDet.GetData(iiCnt, 7)))) - (checkBox_DisVal.Checked ? double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInvDet.GetData(iiCnt, 8)))) : ItmDis));
                    }
                    catch
                    {
                    }
                }
            }
            catch
            {
            }
        }
    }
}
